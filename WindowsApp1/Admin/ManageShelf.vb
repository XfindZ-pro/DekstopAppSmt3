Imports MySql.Data.MySqlClient
Imports System.Diagnostics
Imports System.Data

Public Class ManageShelf
    ' --- Koneksi
    Private db As New Database()

    ' --- Timer untuk ping DB
    Private WithEvents dbTimer As New Timer()

    ' --- Sumber data grid
    Private shelfTable As New DataTable()

    ' --- Mode Form ---
    Private isEditMode As Boolean = False
    Private originalIdShelf As String = ""

    ' ------------------------------------------
    '  Event Form
    ' ------------------------------------------

    Private Sub ManageShelf_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    ' **[PERBAIKAN]** Hanya ada SATU Form_Load
    Private Sub ManageShelf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Timer ping DB
        dbTimer.Interval = 3000
        dbTimer.Start()

        ' Siapkan kolom DataGridView
        SiapkanKolomGrid()

        ' **[PERUBAHAN]** Jadikan TextIDShelf ReadOnly
        TextIDShelf.ReadOnly = True

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
    '  Setup DataGridView
    ' ------------------------------------------
    Private Sub SiapkanKolomGrid()
        With PanelDataShelf
            .AutoGenerateColumns = False
            .Columns.Clear()

            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "IdShelf", .HeaderText = "ID Rak", .DataPropertyName = "IdShelf", .Width = 120
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "NamaShelf", .HeaderText = "Nama Rak", .DataPropertyName = "Nama", .Width = 200
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Lokasi", .HeaderText = "Lokasi Rak", .DataPropertyName = "Lokasi", .Width = 250, .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            })

            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
    End Sub

    ' ------------------------------------------
    '  Load Data
    ' ------------------------------------------
    Private Sub LoadData(Optional ByVal keyword As String = "")
        Try
            db.Koneksi()
            Dim sql As String =
                "SELECT IdShelf, Nama, Lokasi FROM shelf " &
                "WHERE (@kw = '' OR IdShelf LIKE CONCAT('%',@kw,'%') OR Nama LIKE CONCAT('%',@kw,'%')) " &
                "ORDER BY updatedAt DESC;"

            Using cmd As New MySqlCommand(sql, db.Connection)
                cmd.Parameters.AddWithValue("@kw", keyword.Trim())
                Using adp As New MySqlDataAdapter(cmd)
                    shelfTable = New DataTable()
                    adp.Fill(shelfTable)
                End Using
            End Using

            PanelDataShelf.DataSource = shelfTable
        Catch ex As Exception
            MessageBox.Show("Error saat memuat data: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ' ------------------------------------------
    '  Utilities Form
    ' ------------------------------------------
    Private Function BacaFormKeArray() As String()
        Return {
            TextIDShelf.Text.Trim(),
            TextNamaShelf.Text.Trim(),
            TextLokasiShelf.Text.Trim()
        }
    End Function

    Private Function Validasi(data() As String) As Boolean
        ' **[PERUBAHAN]** Validasi ID sekarang memeriksa format RAK
        If String.IsNullOrWhiteSpace(data(0)) OrElse Not data(0).StartsWith("RAK") Then
            MessageBox.Show("ID Rak tidak valid. Klik 'Baru' untuk membuat ID.") : Return False
        End If
        If String.IsNullOrWhiteSpace(data(1)) Then
            MessageBox.Show("Nama Rak wajib diisi") : TextNamaShelf.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(data(2)) Then
            MessageBox.Show("Lokasi Rak wajib diisi") : TextLokasiShelf.Focus() : Return False
        End If
        Return True
    End Function

    Private Sub ResetForm()
        TextIDShelf.Clear()
        TextNamaShelf.Clear()
        TextLokasiShelf.Clear()
        PanelDataShelf.ClearSelection()

        ' **[PERUBAHAN]** Sesuaikan UI untuk mode auto-ID
        isEditMode = False
        originalIdShelf = ""
        BtnSimpan.Text = "Simpan"
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        TextIDShelf.ReadOnly = True ' Kunci ID
        TextNamaShelf.Focus() ' Fokus ke Nama
    End Sub

    ' ------------------------------------------
    '  **[FUNGSI BARU]** Auto-Generate ID Rak
    ' ------------------------------------------
    ''' <summary>
    ''' Menghasilkan IdShelf berikutnya, mengisi celah (gap) jika ada.
    ''' Format: RAK0001
    ''' </summary>
    ''' <returns>String ID Rak baru, atau String.Empty jika gagal.</returns>
    Private Function GenerateNextIdShelf() As String
        Try
            db.Koneksi()
            Dim nextNumber As Integer = 1 ' Default jika tabel kosong

            ' Query SQL untuk mencari gap (celah) ID terendah
            Dim sql As String =
                "SELECT MIN(t1.num + 1) " &
                "FROM (SELECT 0 AS num UNION ALL SELECT CAST(SUBSTRING(IdShelf, 4) AS UNSIGNED) AS num FROM shelf WHERE IdShelf LIKE 'RAK%') AS t1 " &
                "LEFT JOIN (SELECT CAST(SUBSTRING(IdShelf, 4) AS UNSIGNED) AS num FROM shelf WHERE IdShelf LIKE 'RAK%') AS t2 ON t1.num + 1 = t2.num " &
                "WHERE t2.num IS NULL"

            Using cmd As New MySqlCommand(sql, db.Connection)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    nextNumber = Convert.ToInt32(result)
                End If
            End Using

            ' Format angka menjadi 4 digit (misal: 1 -> "0001") dan tambahkan prefix
            Return "RAK" & nextNumber.ToString("D4")

        Catch ex As Exception
            MessageBox.Show("Gagal generate ID Rak: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        TextIDShelf.Text = "Generating..."
        Dim newId As String = GenerateNextIdShelf()
        If String.IsNullOrEmpty(newId) Then
            MessageBox.Show("Gagal membuat ID Rak baru.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextIDShelf.Clear()
        Else
            TextIDShelf.Text = newId
        End If
        TextNamaShelf.Focus()
    End Sub

    ' ------------------------------------------
    '  CRUD
    ' ------------------------------------------
    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
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
        If shelfTable.AsEnumerable().Any(Function(r) String.Equals(CStr(r("IdShelf")), data(0), StringComparison.OrdinalIgnoreCase)) Then
            MessageBox.Show("ID Rak sudah ada (client-side). Klik 'Baru' lagi.") : Exit Sub
        End If

        Try
            db.Koneksi()
            Dim q As String =
                "INSERT INTO shelf (IdShelf, Nama, Lokasi) " &
                "VALUES (@IdShelf, @Nama, @Lokasi);"

            Using cmd As New MySqlCommand(q, db.Connection)
                cmd.Parameters.AddWithValue("@IdShelf", data(0))
                cmd.Parameters.AddWithValue("@Nama", data(1))
                cmd.Parameters.AddWithValue("@Lokasi", data(2))
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Rak baru berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ResetForm()
        Catch ex As MySqlException
            If ex.Number = 1062 Then ' Error Duplikat Primary Key
                MessageBox.Show("ID Rak '" & data(0) & "' sudah ada di database. Silakan klik 'Baru' lagi.", "Duplikat ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub BtnUbah_Click(sender As Object, e As EventArgs) Handles BtnUbah.Click
        ' **[PERUBAHAN]** Tombol Ubah sekarang hanya mengaktifkan mode edit
        If String.IsNullOrEmpty(originalIdShelf) Then
            MessageBox.Show("Pilih baris yang akan diubah di tabel.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        isEditMode = True
        BtnSimpan.Text = "Update"
        TextIDShelf.ReadOnly = False ' Izinkan edit ID
        TextNamaShelf.Focus()
    End Sub

    Private Sub UpdateData()
        Dim data = BacaFormKeArray()
        If Not Validasi(data) Then Exit Sub

        If String.IsNullOrEmpty(originalIdShelf) Then
            MessageBox.Show("ID Rak asli tidak ditemukan. Klik baris data lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            db.Koneksi()
            Dim q As String =
                "UPDATE shelf SET IdShelf = @NewId, Nama = @Nama, Lokasi = @Lokasi WHERE IdShelf = @OriginalId;"

            Using cmd As New MySqlCommand(q, db.Connection)
                cmd.Parameters.AddWithValue("@NewId", data(0)) ' ID baru dari form
                cmd.Parameters.AddWithValue("@Nama", data(1))
                cmd.Parameters.AddWithValue("@Lokasi", data(2))
                cmd.Parameters.AddWithValue("@OriginalId", originalIdShelf) ' ID lama
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Data berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ResetForm()
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("ID Rak '" & data(0) & "' sudah digunakan oleh data lain.", "Duplikat ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        Dim kode As String = TextIDShelf.Text.Trim()
        If String.IsNullOrWhiteSpace(kode) Then
            kode = originalIdShelf ' Ambil dari ID yang tersimpan jika form kosong
        End If
        If String.IsNullOrWhiteSpace(kode) Then
            MessageBox.Show("Pilih baris di tabel untuk menghapus.")
            Exit Sub
        End If

        If MessageBox.Show($"Hapus data dengan ID Rak '{kode}'?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            db.Koneksi()
            Using cmd As New MySqlCommand("DELETE FROM shelf WHERE IdShelf=@IdShelf;", db.Connection)
                cmd.Parameters.AddWithValue("@IdShelf", kode)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ResetForm()
        Catch ex As MySqlException
            If ex.Number = 1451 Then ' Error Foreign Key Constraint
                MessageBox.Show("Gagal menghapus! Rak ini masih digunakan oleh data barang.", "Error Relasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub PanelDataShelf_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles PanelDataShelf.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim r = PanelDataShelf.Rows(e.RowIndex)

        ' **[PERBAIKAN]** Sesuaikan nama kolom dengan DataPropertyName
        Dim id As String = CStr(r.Cells("IdShelf").Value)
        TextIDShelf.Text = id
        TextNamaShelf.Text = CStr(r.Cells("NamaShelf").Value) ' Sesuai 'Nama'
        TextLokasiShelf.Text = CStr(r.Cells("Lokasi").Value) ' Sesuai 'Lokasi'

        ' **[PERUBAHAN]** Siapkan mode edit
        isEditMode = False
        originalIdShelf = id ' Simpan ID asli
        BtnSimpan.Text = "Simpan"
        BtnUbah.Enabled = True ' Aktifkan tombol Ubah
        BtnHapus.Enabled = True ' Aktifkan tombol Hapus
        TextIDShelf.ReadOnly = True
    End Sub

    ' ------------------------------------------
    '  Pencarian
    ' ------------------------------------------
    Private Sub TextPencarian_TextChanged(sender As Object, e As EventArgs) Handles TextPencarian.TextChanged
        LoadData(TextPencarian.Text.Trim())
    End Sub

    Private Sub TextIDShelf_TextChanged(sender As Object, e As EventArgs) Handles TextIDShelf.TextChanged
        ' Kosongkan, tidak perlu logika di sini
    End Sub

End Class