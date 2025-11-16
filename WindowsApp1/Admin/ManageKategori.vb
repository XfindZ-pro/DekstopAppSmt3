Imports MySql.Data.MySqlClient
Imports System.Diagnostics
Imports System.Data

Public Class ManageKategori
    ' --- Koneksi
    Private db As New Database()

    ' --- Timer untuk ping DB
    Private WithEvents dbTimer As New Timer()

    ' --- DataGridView untuk menampilkan data kategori
    Private kategoriTable As New DataTable()

    ' --- Mode Form ---
    Private isEditMode As Boolean = False
    Private originalIdKategori As String = ""

    ' ------------------------------------------
    '  Event Form
    ' ------------------------------------------

    Private Sub ManageKategori_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    ' **[PERBAIKAN]** Hanya ada SATU Form_Load
    Private Sub ManageKategori_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Timer ping DB
        dbTimer.Interval = 3000
        dbTimer.Start()

        ' Siapkan kolom DataGridView
        SiapkanKolomGrid()

        ' **[PERUBAHAN]** Buat TextIDKategori ReadOnly
        TextIDKategori.ReadOnly = True

        ' Inisialisasi state form
        ResetForm()

        ' Muat data awal
        LoadData()
    End Sub

    ' ------------------------------------------
    '  Ping DB
    ' ------------------------------------------
    Private Function PingDatabase() As String
        Dim sw As New Stopwatch()
        Try
            sw.Start()
            db.Koneksi()
            sw.Stop()
            Return sw.ElapsedMilliseconds.ToString() & "ms"
        Catch
            Return "Connection failed"
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Function

    Private Sub dbTimer_Tick(sender As Object, e As EventArgs) Handles dbTimer.Tick
        Dim pingResult As String = PingDatabase()
        DBstatus.Text = "Database Ping: " & pingResult
    End Sub

    ' ------------------------------------------
    '  Load Data
    ' ------------------------------------------
    Private Sub LoadData(Optional ByVal keyword As String = "")
        Try
            db.Koneksi()
            Dim sql As String =
                "SELECT IdKategori, NamaKategori, Deskripsi FROM kategori " &
                "WHERE (@kw = '' OR IdKategori LIKE CONCAT('%',@kw,'%') OR NamaKategori LIKE CONCAT('%',@kw,'%')) " &
                "ORDER BY NamaKategori ASC"

            Using cmd As New MySqlCommand(sql, db.Connection)
                cmd.Parameters.AddWithValue("@kw", keyword.Trim())
                Using adp As New MySqlDataAdapter(cmd)
                    kategoriTable = New DataTable()
                    adp.Fill(kategoriTable)
                End Using
            End Using

            PanelDataKategori.DataSource = kategoriTable
        Catch ex As Exception
            MessageBox.Show("Error saat memuat data: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ' ------------------------------------------
    '  Setup DataGridView
    ' ------------------------------------------
    Private Sub SiapkanKolomGrid()
        With PanelDataKategori
            .AutoGenerateColumns = False
            .Columns.Clear()

            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "IdKategori", .HeaderText = "ID Kategori", .DataPropertyName = "IdKategori", .Width = 120
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "NamaKategori", .HeaderText = "Nama Kategori", .DataPropertyName = "NamaKategori", .Width = 250
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Deskripsi", .HeaderText = "Deskripsi Kategori", .DataPropertyName = "Deskripsi", .Width = 300, .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            })

            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
    End Sub

    ' ------------------------------------------
    '  Utilities Form
    ' ------------------------------------------
    Private Function BacaFormKeArray() As String()
        Return {
            TextIDKategori.Text.Trim(),
            TextNamaKategori.Text.Trim(),
            TextDeskripsiKategori.Text.Trim()
        }
    End Function

    Private Function Validasi(data() As String) As Boolean
        ' **[PERUBAHAN]** Validasi ID sekarang memeriksa format KTG
        If String.IsNullOrWhiteSpace(data(0)) OrElse Not data(0).StartsWith("KTG") Then
            MessageBox.Show("ID Kategori tidak valid. Klik 'Baru' untuk membuat ID.") : Return False
        End If
        If String.IsNullOrWhiteSpace(data(1)) Then
            MessageBox.Show("Nama Kategori wajib diisi") : TextNamaKategori.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(data(2)) Then
            MessageBox.Show("Deskripsi Kategori wajib diisi") : TextDeskripsiKategori.Focus() : Return False
        End If
        Return True
    End Function

    Private Sub ResetForm()
        TextIDKategori.Clear()
        TextNamaKategori.Clear()
        TextDeskripsiKategori.Clear()
        PanelDataKategori.ClearSelection()

        ' **[PERUBAHAN]** Sesuaikan UI untuk mode auto-ID
        isEditMode = False
        originalIdKategori = ""
        BtnSimpan.Text = "Simpan"
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        TextIDKategori.ReadOnly = True ' Kunci ID
        TextNamaKategori.Focus() ' Fokus ke Nama
    End Sub

    ' ------------------------------------------
    '  **[FUNGSI BARU]** Auto-Generate ID Kategori
    ' ------------------------------------------
    ''' <summary>
    ''' Menghasilkan IdKategori berikutnya, mengisi celah (gap) jika ada.
    ''' Format: KTG0001
    ''' </summary>
    ''' <returns>String ID Kategori baru, atau String.Empty jika gagal.</returns>
    Private Function GenerateNextIdKategori() As String
        Try
            db.Koneksi()
            Dim nextNumber As Integer = 1 ' Default jika tabel kosong

            ' Query SQL untuk mencari gap (celah) ID terendah
            Dim sql As String =
                "SELECT MIN(t1.num + 1) " &
                "FROM (SELECT 0 AS num UNION ALL SELECT CAST(SUBSTRING(IdKategori, 4) AS UNSIGNED) AS num FROM kategori WHERE IdKategori LIKE 'KTG%') AS t1 " &
                "LEFT JOIN (SELECT CAST(SUBSTRING(IdKategori, 4) AS UNSIGNED) AS num FROM kategori WHERE IdKategori LIKE 'KTG%') AS t2 ON t1.num + 1 = t2.num " &
                "WHERE t2.num IS NULL"

            Using cmd As New MySqlCommand(sql, db.Connection)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    nextNumber = Convert.ToInt32(result)
                End If
            End Using

            ' Format angka menjadi 4 digit (misal: 1 -> "0001") dan tambahkan prefix
            Return "KTG" & nextNumber.ToString("D4")

        Catch ex As Exception
            MessageBox.Show("Gagal generate ID Kategori: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Function

    ' ------------------------------------------
    '  Tombol Aksi
    ' ------------------------------------------
    Private Sub KembaliBtn_Click(sender As Object, e As EventArgs) Handles KembaliBtn.Click
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Hide()
    End Sub

    ''' <summary>
    ''' **[LOGIKA DIISI]**
    ''' Tombol "Baru" sekarang mereset form dan meng-generate ID baru
    ''' </summary>
    Private Sub BtnBaru_Click(sender As Object, e As EventArgs) Handles BtnBaru.Click
        ResetForm()
        TextIDKategori.Text = "Generating..."
        Dim newId As String = GenerateNextIdKategori()
        If String.IsNullOrEmpty(newId) Then
            MessageBox.Show("Gagal membuat ID Kategori baru.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextIDKategori.Clear()
        Else
            TextIDKategori.Text = newId
        End If
        TextNamaKategori.Focus()
    End Sub

    ' ------------------------------------------
    '  CRUD
    ' ------------------------------------------

    ' Create / Insert Data
    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        ' **[PERBAIKAN]** Logika dipisah ke UpdateData dan SimpanDataBaru
        If isEditMode Then
            UpdateData()
        Else
            SimpanDataBaru()
        End If
    End Sub

    Private Sub SimpanDataBaru()
        Dim data = BacaFormKeArray()
        If Not Validasi(data) Then Exit Sub

        ' Cek duplikat ID (Client-side)
        If kategoriTable.AsEnumerable().Any(Function(r) String.Equals(CStr(r("IdKategori")), data(0), StringComparison.OrdinalIgnoreCase)) Then
            MessageBox.Show("ID Kategori sudah ada (client-side). Klik 'Baru' lagi.") : Exit Sub
        End If

        Try
            db.Koneksi()
            Dim q As String =
                "INSERT INTO kategori (IdKategori, NamaKategori, Deskripsi) " &
                "VALUES (@IdKategori, @NamaKategori, @Deskripsi);"

            Using cmd As New MySqlCommand(q, db.Connection)
                cmd.Parameters.AddWithValue("@IdKategori", data(0))
                cmd.Parameters.AddWithValue("@NamaKategori", data(1))
                cmd.Parameters.AddWithValue("@Deskripsi", data(2))
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Kategori baru berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ResetForm()
        Catch ex As MySqlException
            If ex.Number = 1062 Then ' Error Duplikat Primary Key
                MessageBox.Show("ID Kategori '" & data(0) & "' sudah ada di database. Silakan klik 'Baru' lagi.", "Duplikat ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error saat menyimpan data: " & ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saat menyimpan data: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ' Update Data
    ' **[PERBAIKAN]** Mengganti event BtnUbah_Click dengan fungsi UpdateData
    Private Sub UpdateData()
        Dim data = BacaFormKeArray()
        If Not Validasi(data) Then Exit Sub

        ' Pastikan ID lama (original) ada
        If String.IsNullOrEmpty(originalIdKategori) Then
            MessageBox.Show("ID Kategori asli tidak ditemukan. Klik baris data lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            db.Koneksi()
            Dim q As String =
                "UPDATE kategori SET IdKategori = @NewId, NamaKategori=@NamaKategori, Deskripsi=@Deskripsi " &
                "WHERE IdKategori=@OriginalId;"

            Using cmd As New MySqlCommand(q, db.Connection)
                cmd.Parameters.AddWithValue("@NewId", data(0)) ' ID baru dari form
                cmd.Parameters.AddWithValue("@NamaKategori", data(1))
                cmd.Parameters.AddWithValue("@Deskripsi", data(2))
                cmd.Parameters.AddWithValue("@OriginalId", originalIdKategori) ' ID lama

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Data berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ResetForm()
        Catch ex As MySqlException
            If ex.Number = 1062 Then ' Error Duplikat Primary Key
                MessageBox.Show("ID Kategori '" & data(0) & "' sudah digunakan oleh data lain.", "Duplikat ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error saat memperbarui data: " & ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saat memperbarui data: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ' **[BARU]** Event untuk tombol Ubah (mengaktifkan mode edit)
    Private Sub BtnUbah_Click(sender As Object, e As EventArgs) Handles BtnUbah.Click
        If String.IsNullOrEmpty(originalIdKategori) Then
            MessageBox.Show("Pilih baris yang akan diubah di tabel.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        isEditMode = True
        BtnSimpan.Text = "Update"
        TextIDKategori.ReadOnly = False ' Izinkan edit ID
        TextNamaKategori.Focus()
    End Sub


    ' Delete Data
    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        Dim kode As String = TextIDKategori.Text.Trim()

        ' Jika TextIDKategori kosong, ambil dari ID asli yang tersimpan
        If String.IsNullOrWhiteSpace(kode) Then
            kode = originalIdKategori
        End If

        If String.IsNullOrWhiteSpace(kode) Then
            MessageBox.Show("Pilih baris di tabel untuk menghapus.")
            Exit Sub
        End If

        If MessageBox.Show($"Hapus data dengan ID Kategori '{kode}'?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            db.Koneksi()
            Using cmd As New MySqlCommand("DELETE FROM kategori WHERE IdKategori=@IdKategori;", db.Connection)
                cmd.Parameters.AddWithValue("@IdKategori", kode)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ResetForm()
        Catch ex As MySqlException
            ' **[PENTING]** Tangani error jika kategori masih digunakan
            If ex.Number = 1451 Then ' Error Foreign Key Constraint
                MessageBox.Show("Gagal menghapus! Kategori ini masih digunakan oleh data barang.", "Error Relasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error saat menghapus data: " & ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saat menghapus data: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ' ------------------------------------------
    '  Grid → Form (klik baris)
    ' ------------------------------------------
    Private Sub PanelDataKategori_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles PanelDataKategori.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim r = PanelDataKategori.Rows(e.RowIndex)

        ' Set data ke form
        Dim id As String = CStr(r.Cells("IdKategori").Value)
        TextIDKategori.Text = id
        TextNamaKategori.Text = CStr(r.Cells("NamaKategori").Value)
        TextDeskripsiKategori.Text = If(IsDBNull(r.Cells("Deskripsi").Value), "", CStr(r.Cells("Deskripsi").Value))

        ' **[PERUBAHAN]** Siapkan mode edit
        isEditMode = False ' Belum mode edit, hanya terpilih
        originalIdKategori = id ' Simpan ID asli
        BtnSimpan.Text = "Simpan" ' Reset tombol simpan
        BtnUbah.Enabled = True ' Aktifkan tombol Ubah
        BtnHapus.Enabled = True ' Aktifkan tombol Hapus
        TextIDKategori.ReadOnly = True ' Kunci ID sampai klik "Ubah"
    End Sub

    ' ------------------------------------------
    '  Pencarian
    ' ------------------------------------------
    Private Sub TextPencarian_TextChanged(sender As Object, e As EventArgs) Handles TextPencarian.TextChanged
        LoadData(TextPencarian.Text.Trim())
    End Sub

End Class