Imports MySql.Data.MySqlClient
Imports System.Diagnostics
Imports System.Data

Public Class ManageBarang
    ' --- Koneksi
    Private db As New Database()

    ' --- Timer untuk ping DB
    Private WithEvents dbTimer As New Timer()

    ' --- Sumber data grid
    Private barangTable As New DataTable()
    Private isEditMode As Boolean = False
    Private originalIdBarang As String = ""

    ' ------------------------------------------
    '  Event Form
    ' ------------------------------------------
    Private Sub ManageBarang_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub ManageBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Timer ping DB
        dbTimer.Interval = 3000
        dbTimer.Start()

        ' Siapkan kolom DataGridView
        SiapkanKolomGrid()

        ' Inisialisasi state form
        ResetForm()

        ' Muat data awal
        LoadData()

        ' Muat kategori, rak, dan supplier
        LoadKategoriRakSupplier()
    End Sub

    ' ------------------------------------------
    '  Setup DataGridView
    ' ------------------------------------------
    Private Sub SiapkanKolomGrid()
        With PanelDataBarang
            .AutoGenerateColumns = False
            .Columns.Clear()

            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "IdBarang", .HeaderText = "ID Barang", .DataPropertyName = "IdBarang", .Width = 120
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Nama", .HeaderText = "Nama Barang", .DataPropertyName = "Nama", .Width = 250
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Kategori", .HeaderText = "Kategori", .DataPropertyName = "Kategori", .Width = 200
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Rak", .HeaderText = "Rak", .DataPropertyName = "Rak", .Width = 200
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Satuan", .HeaderText = "Satuan", .DataPropertyName = "Satuan", .Width = 90
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "HargaBeli", .HeaderText = "Beli", .DataPropertyName = "HargaBeli", .Width = 90,
                .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N0", .Alignment = DataGridViewContentAlignment.MiddleRight}
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "HargaJual", .HeaderText = "Jual", .DataPropertyName = "HargaJual", .Width = 90,
                .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N0", .Alignment = DataGridViewContentAlignment.MiddleRight}
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Stock", .HeaderText = "Stock", .DataPropertyName = "Stock", .Width = 70,
                .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Supplier", .HeaderText = "Supplier", .DataPropertyName = "Supplier", .Width = 150
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Warna", .HeaderText = "Warna", .DataPropertyName = "Warna", .Width = 100
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Ukuran", .HeaderText = "Ukuran", .DataPropertyName = "Ukuran", .Width = 100
            })

            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
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
                "SELECT b.IdBarang, b.Nama, k.NamaKategori AS Kategori, r.Nama AS Rak, b.Satuan, " &
                "b.HargaBeli, b.HargaJual, b.Stock, b.supplier, b.Warna, b.Ukuran " &
                "FROM barang b " &
                "LEFT JOIN kategori k ON b.IdKategori = k.IdKategori " &
                "LEFT JOIN shelf r ON b.IdShelf = r.IdShelf " &
                "WHERE (@kw = '' OR b.IdBarang LIKE CONCAT('%',@kw,'%') OR b.Nama LIKE CONCAT('%',@kw,'%')) " &
                "ORDER BY b.updatedAt DESC;"

            Using cmd As New MySqlCommand(sql, db.Connection)
                cmd.Parameters.AddWithValue("@kw", keyword.Trim())
                Using adp As New MySqlDataAdapter(cmd)
                    barangTable = New DataTable()
                    adp.Fill(barangTable)
                End Using
            End Using

            PanelDataBarang.DataSource = barangTable
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
        ' Mengembalikan array data form
        Return {
            TextIDBarang.Text.Trim(),
            TextNamaBarang.Text.Trim(),
            If(kategoriBarang.SelectedValue IsNot Nothing, kategoriBarang.SelectedValue.ToString(), ""),
            If(rakBarang.SelectedValue IsNot Nothing, rakBarang.SelectedValue.ToString(), ""),
            TextSatuanBarang.Text.Trim(),
            CStr(NumericHargaBeli.Value),
            CStr(NumericHargaJual.Value),
            CStr(NumericStock.Value),
            TextSupplierBarang.Text.Trim(),
            TextWarnaBarang.Text.Trim(),
            TextUkuranBarang.Text.Trim()
        }
    End Function

    Private Function Validasi(data() As String) As Boolean
        If String.IsNullOrWhiteSpace(data(0)) Then
            MessageBox.Show("ID Barang tidak boleh kosong (Klik 'Baru' untuk auto-generate).") : Return False
        End If
        If String.IsNullOrWhiteSpace(data(1)) Then
            MessageBox.Show("Nama Barang wajib diisi") : TextNamaBarang.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(data(2)) Then
            MessageBox.Show("Kategori Barang harus dipilih") : kategoriBarang.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(data(3)) Then
            MessageBox.Show("Rak Barang harus dipilih") : rakBarang.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(data(4)) Then
            MessageBox.Show("Satuan Barang wajib diisi") : TextSatuanBarang.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(data(8)) Then
            MessageBox.Show("Supplier Barang wajib diisi") : TextSupplierBarang.Focus() : Return False
        End If
        If NumericHargaBeli.Value <= 0 Then
            MessageBox.Show("Harga Beli harus lebih dari 0") : NumericHargaBeli.Focus() : Return False
        End If
        If NumericHargaJual.Value <= 0 Then
            MessageBox.Show("Harga Jual harus lebih dari 0") : NumericHargaJual.Focus() : Return False
        End If
        If NumericStock.Value < 0 Then
            MessageBox.Show("Stok tidak boleh negatif") : NumericStock.Focus() : Return False
        End If
        Return True
    End Function

    ' ------------------------------------------
    '  Load Kategori dan Rak ke ComboBox
    ' ------------------------------------------
    Private Sub LoadKategoriRakSupplier()
        ' Kategori
        Try
            db.Koneksi()
            Dim sql As String = "SELECT IdKategori, NamaKategori FROM kategori ORDER BY NamaKategori;"
            Using cmd As New MySqlCommand(sql, db.Connection)
                Using adp As New MySqlDataAdapter(cmd)
                    Dim dtKategori As New DataTable()
                    adp.Fill(dtKategori)
                    kategoriBarang.DataSource = dtKategori
                    kategoriBarang.DisplayMember = "NamaKategori"
                    kategoriBarang.ValueMember = "IdKategori"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saat memuat kategori: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try

        ' Rak
        Try
            db.Koneksi()
            Dim sql As String = "SELECT IdShelf, Nama FROM shelf ORDER BY Nama;"
            Using cmd As New MySqlCommand(sql, db.Connection)
                Using adp As New MySqlDataAdapter(cmd)
                    Dim dtRak As New DataTable()
                    adp.Fill(dtRak)
                    rakBarang.DataSource = dtRak
                    rakBarang.DisplayMember = "Nama"
                    rakBarang.ValueMember = "IdShelf"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saat memuat rak: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    Private Sub ResetForm()
        TextIDBarang.Clear()
        TextNamaBarang.Clear()
        kategoriBarang.SelectedIndex = -1
        rakBarang.SelectedIndex = -1
        TextSatuanBarang.Clear()
        NumericHargaBeli.Value = 0
        NumericHargaJual.Value = 0
        NumericStock.Value = 0
        TextSupplierBarang.Clear()
        TextWarnaBarang.Clear()
        TextUkuranBarang.Clear()
        PanelDataBarang.ClearSelection()

        ' Set UI Mode Baru
        isEditMode = False
        originalIdBarang = ""
        BtnSimpan.Text = "Simpan"
        BtnHapus.Enabled = False

        ' ID Barang ReadOnly (Paten)
        TextIDBarang.ReadOnly = True
        TextIDBarang.BackColor = SystemColors.Window ' Warna putih normal untuk input baru (nanti diisi auto)
        TextNamaBarang.Focus()
    End Sub

    ' ------------------------------------------
    '  Tombol Aksi
    ' ------------------------------------------
    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub BtnBaru_Click(sender As Object, e As EventArgs) Handles BtnBaru.Click
        ResetForm()
        TextIDBarang.Text = "Generating..."
        Dim newId As String = GenerateNextIdBarang()
        If String.IsNullOrEmpty(newId) Then
            MessageBox.Show("Gagal membuat ID Barang baru.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextIDBarang.Clear()
        Else
            TextIDBarang.Text = newId
        End If
        TextNamaBarang.Focus()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If isEditMode Then
            UpdateData()
        Else
            SimpanDataBaru()
        End If
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        HapusData()
    End Sub

    ' ------------------------------------------
    '  Auto-Generate ID Barang
    ' ------------------------------------------
    Private Function GenerateNextIdBarang() As String
        Try
            db.Koneksi()
            Dim nextNumber As Integer = 1

            Dim sql As String =
                "SELECT MIN(t1.num + 1) " &
                "FROM (SELECT 0 AS num UNION ALL SELECT CAST(SUBSTRING(IdBarang, 4) AS UNSIGNED) AS num FROM barang WHERE IdBarang LIKE 'BRG%') AS t1 " &
                "LEFT JOIN (SELECT CAST(SUBSTRING(IdBarang, 4) AS UNSIGNED) AS num FROM barang WHERE IdBarang LIKE 'BRG%') AS t2 ON t1.num + 1 = t2.num " &
                "WHERE t2.num IS NULL"

            Using cmd As New MySqlCommand(sql, db.Connection)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    nextNumber = Convert.ToInt32(result)
                End If
            End Using

            Return "BRG" & nextNumber.ToString("D4")

        Catch ex As Exception
            MessageBox.Show("Gagal generate ID Barang: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Function

    ' ------------------------------------------
    '  Operasi Database (CRUD)
    ' ------------------------------------------
    Private Sub SimpanDataBaru()
        Dim data = BacaFormKeArray()
        If Not Validasi(data) Then Exit Sub

        If barangTable.AsEnumerable().Any(Function(r) String.Equals(CStr(r("IdBarang")), data(0), StringComparison.OrdinalIgnoreCase)) Then
            MessageBox.Show("ID Barang sudah ada. Klik 'Baru' lagi.") : Exit Sub
        End If

        Try
            db.Koneksi()
            Dim q As String =
                "INSERT INTO barang (IdBarang, Nama, IdKategori, IdShelf, Satuan, HargaBeli, HargaJual, Stock, supplier, Warna, Ukuran) " &
                "VALUES (@IdBarang, @Nama, @IdKategori, @IdShelf, @Satuan, @HargaBeli, @HargaJual, @Stock, @Supplier, @Warna, @Ukuran);"

            Using cmd As New MySqlCommand(q, db.Connection)
                cmd.Parameters.AddWithValue("@IdBarang", data(0))
                cmd.Parameters.AddWithValue("@Nama", data(1))
                cmd.Parameters.AddWithValue("@IdKategori", data(2))
                cmd.Parameters.AddWithValue("@IdShelf", data(3))
                cmd.Parameters.AddWithValue("@Satuan", data(4))
                cmd.Parameters.AddWithValue("@HargaBeli", CInt(data(5)))
                cmd.Parameters.AddWithValue("@HargaJual", CInt(data(6)))
                cmd.Parameters.AddWithValue("@Stock", CInt(data(7)))
                cmd.Parameters.AddWithValue("@Supplier", data(8))
                cmd.Parameters.AddWithValue("@Warna", data(9))
                cmd.Parameters.AddWithValue("@Ukuran", data(10))

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Data berhasil disimpan.")
                    LoadData()
                    ResetForm()
                Else
                    MessageBox.Show("Data gagal disimpan.")
                End If
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("ID Barang '" & data(0) & "' sudah ada. Klik 'Baru' lagi.", "Duplikat ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub UpdateData()
        Dim data = BacaFormKeArray()
        If Not Validasi(data) Then Exit Sub

        Try
            db.Koneksi()
            ' [PERBAIKAN] Tidak mengupdate kolom IdBarang
            Dim q As String =
                "UPDATE barang SET Nama = @Nama, IdKategori = @IdKategori, IdShelf = @IdShelf, Satuan = @Satuan, " &
                "HargaBeli = @HargaBeli, HargaJual = @HargaJual, Stock = @Stock, supplier = @Supplier, " &
                "Warna = @Warna, Ukuran = @Ukuran WHERE IdBarang = @OriginalIdBarang;"

            Using cmd As New MySqlCommand(q, db.Connection)
                cmd.Parameters.AddWithValue("@Nama", data(1))
                cmd.Parameters.AddWithValue("@IdKategori", data(2))
                cmd.Parameters.AddWithValue("@IdShelf", data(3))
                cmd.Parameters.AddWithValue("@Satuan", data(4))
                cmd.Parameters.AddWithValue("@HargaBeli", CInt(data(5)))
                cmd.Parameters.AddWithValue("@HargaJual", CInt(data(6)))
                cmd.Parameters.AddWithValue("@Stock", CInt(data(7)))
                cmd.Parameters.AddWithValue("@Supplier", data(8))
                cmd.Parameters.AddWithValue("@Warna", data(9))
                cmd.Parameters.AddWithValue("@Ukuran", data(10))
                cmd.Parameters.AddWithValue("@OriginalIdBarang", originalIdBarang) ' WHERE Clause

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Data berhasil diupdate.")
                    LoadData()
                    ResetForm()
                Else
                    MessageBox.Show("Data gagal diupdate (ID tidak ditemukan).")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saat mengubah data: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    Private Sub HapusData()
        If String.IsNullOrEmpty(originalIdBarang) Then
            MessageBox.Show("Tidak ada data yang dipilih untuk dihapus.")
            Return
        End If

        If MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi Hapus",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Try
                db.Koneksi()
                Dim q As String = "DELETE FROM barang WHERE IdBarang = @IdBarang;"

                Using cmd As New MySqlCommand(q, db.Connection)
                    cmd.Parameters.AddWithValue("@IdBarang", originalIdBarang)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Data berhasil dihapus.")
                        LoadData()
                        ResetForm()
                    Else
                        MessageBox.Show("Data gagal dihapus.")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error saat menghapus data: " & ex.Message)
            Finally
                If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                    db.CloseConnection()
                End If
            End Try
        End If
    End Sub

    ' ------------------------------------------
    '  Grid → Form (klik baris)
    ' ------------------------------------------
    Private Sub PanelDataBarang_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles PanelDataBarang.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim r = PanelDataBarang.Rows(e.RowIndex)

        originalIdBarang = CStr(r.Cells("IdBarang").Value)
        isEditMode = True

        ' Isi form
        TextIDBarang.Text = originalIdBarang
        TextNamaBarang.Text = CStr(r.Cells("Nama").Value)
        TextSupplierBarang.Text = CStr(r.Cells("Supplier").Value)
        TextSatuanBarang.Text = If(IsDBNull(r.Cells("Satuan").Value), "", CStr(r.Cells("Satuan").Value))
        NumericHargaBeli.Value = If(IsDBNull(r.Cells("HargaBeli").Value), 0D, Convert.ToDecimal(r.Cells("HargaBeli").Value))
        NumericHargaJual.Value = If(IsDBNull(r.Cells("HargaJual").Value), 0D, Convert.ToDecimal(r.Cells("HargaJual").Value))
        NumericStock.Value = If(IsDBNull(r.Cells("Stock").Value), 0D, Convert.ToDecimal(r.Cells("Stock").Value))
        TextWarnaBarang.Text = If(IsDBNull(r.Cells("Warna").Value), "", CStr(r.Cells("Warna").Value))
        TextUkuranBarang.Text = If(IsDBNull(r.Cells("Ukuran").Value), "", CStr(r.Cells("Ukuran").Value))

        SetComboBoxValue(kategoriBarang, CStr(r.Cells("Kategori").Value))
        SetComboBoxValue(rakBarang, CStr(r.Cells("Rak").Value))

        ' Update UI Mode Edit
        BtnSimpan.Text = "Update"
        BtnHapus.Enabled = True

        ' [PERBAIKAN] ID Barang Paten (Tidak Bisa Diedit) & Visual Abu-abu
        TextIDBarang.ReadOnly = True
        TextIDBarang.BackColor = SystemColors.Control ' Warna abu-abu standar windows
    End Sub

    Private Sub SetComboBoxValue(combo As ComboBox, displayValue As String)
        If String.IsNullOrEmpty(displayValue) Then
            combo.SelectedIndex = -1
            Return
        End If
        combo.SelectedIndex = combo.FindStringExact(displayValue)
        If combo.SelectedIndex = -1 Then
            combo.SelectedIndex = combo.FindString(displayValue)
        End If
    End Sub

    ' ------------------------------------------
    '  Pencarian
    ' ------------------------------------------
    Private Sub TextPencarian_TextChanged(sender As Object, e As EventArgs) Handles TextPencarian.TextChanged
        LoadData(TextPencarian.Text.Trim())
    End Sub

End Class