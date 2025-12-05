Imports MySql.Data.MySqlClient


Public Class ManageStock
    Private db As New Database()

    ' [PERBAIKAN IDE1006] Mengubah nama variabel menjadi PascalCase (Huruf depan besar)
    Private WithEvents SaldoTimer As New Timer()
    Private barangTable As New DataTable()
    Private selectedBarangId As String = ""

    ' Variabel untuk menyimpan saldo ekonomi
    Private currentSaldoCash As Decimal = 0
    Private currentSaldoBank As Decimal = 0

    ' ------------------------------------------
    '  Event Form
    ' ------------------------------------------
    Private Sub ManageStock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub ManageStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Timer untuk update saldo setiap detik
        SaldoTimer.Interval = 1000 ' 1 detik
        SaldoTimer.Start()

        ' Setup DataGridView
        SiapkanKolomGrid()

        ' Muat data barang
        LoadDataBarang()

        ' Update saldo pertama kali
        UpdateLabelUang()

        ' Setup placeholder untuk TextBoxNama
        SetupTextBoxPlaceholder()

        ' Atur default metode bayar
        RadioTunai.Checked = True
    End Sub

    ' ------------------------------------------
    '  Setup Placeholder untuk TextBox
    ' ------------------------------------------
    Private Sub SetupTextBoxPlaceholder()
        TextBoxNama.Text = "Cari nama barang..."
        TextBoxNama.ForeColor = Color.Gray
    End Sub

    ' ------------------------------------------
    '  [PERBAIKAN IDE1006] Nama Event Handler mengikuti nama variabel timer
    ' ------------------------------------------
    Private Sub SaldoTimer_Tick(sender As Object, e As EventArgs) Handles SaldoTimer.Tick
        UpdateLabelUang()
    End Sub

    ' ------------------------------------------
    '  Update Label Uang (Saldo Perusahaan)
    ' ------------------------------------------
    Private Sub UpdateLabelUang()
        RefreshSaldoEkonomi()
        ' [PERBAIKAN IDE0071] Interpolasi string yang lebih bersih
        LabelUang.Text = $"Kas: Rp {currentSaldoCash:N0} | Bank: Rp {currentSaldoBank:N0}"
    End Sub

    ' ------------------------------------------
    '  Refresh saldo dari tabel EKONOMI
    ' ------------------------------------------
    Private Sub RefreshSaldoEkonomi()
        Try
            db.Koneksi()
            Dim sql As String = "SELECT saldo_cash, saldo_bank FROM ekonomi WHERE id_utama = 'UTAMA'"
            Using cmd As New MySqlCommand(sql, db.Connection)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        currentSaldoCash = Convert.ToDecimal(reader("saldo_cash"))
                        currentSaldoBank = Convert.ToDecimal(reader("saldo_bank"))
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Silent fail agar tidak mengganggu timer
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
        With PanelDataStock
            .AutoGenerateColumns = False
            .Columns.Clear()
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "IdBarang", .HeaderText = "ID", .DataPropertyName = "IdBarang", .Width = 0, .Visible = False})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Nama", .HeaderText = "Nama Barang", .DataPropertyName = "Nama", .Width = 200})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "HargaBeli", .HeaderText = "Harga Beli", .DataPropertyName = "HargaBeli", .Width = 120, .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N0", .Alignment = DataGridViewContentAlignment.MiddleRight}})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Stock", .HeaderText = "Stock", .DataPropertyName = "Stock", .Width = 100, .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Warna", .HeaderText = "Warna", .DataPropertyName = "Warna", .Width = 100})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Ukuran", .HeaderText = "Ukuran", .DataPropertyName = "Ukuran", .Width = 100})
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
    End Sub

    ' ------------------------------------------
    '  Load Data Barang
    ' ------------------------------------------
    Private Sub LoadDataBarang(Optional searchTerm As String = "")
        Try
            db.Koneksi()
            Dim sql As String = "SELECT IdBarang, Nama, HargaBeli, Stock, Warna, Ukuran FROM barang"

            If Not String.IsNullOrEmpty(searchTerm) AndAlso searchTerm <> "Cari nama barang..." Then
                sql &= " WHERE Nama LIKE @searchTerm"
            End If
            sql &= " ORDER BY Nama;"

            Using cmd As New MySqlCommand(sql, db.Connection)
                If Not String.IsNullOrEmpty(searchTerm) AndAlso searchTerm <> "Cari nama barang..." Then
                    cmd.Parameters.AddWithValue("@searchTerm", "%" & searchTerm & "%")
                End If
                Using adp As New MySqlDataAdapter(cmd)
                    barangTable = New DataTable()
                    adp.Fill(barangTable)
                End Using
            End Using
            PanelDataStock.DataSource = barangTable

            If String.IsNullOrEmpty(searchTerm) OrElse searchTerm = "Cari nama barang..." Then
                ResetFormSelection()
            End If

        Catch ex As Exception
            MessageBox.Show("Error saat memuat data barang: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ' ------------------------------------------
    '  Event UI (Search & Selection)
    ' ------------------------------------------
    Private Sub TextBoxNama_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNama.TextChanged
        If TextBoxNama.Text <> "Cari nama barang..." Then
            LoadDataBarang(TextBoxNama.Text.Trim())
        End If
    End Sub

    Private Sub TextBoxNama_Enter(sender As Object, e As EventArgs) Handles TextBoxNama.Enter
        If TextBoxNama.Text = "Cari nama barang..." Then
            TextBoxNama.Text = ""
            TextBoxNama.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBoxNama_Leave(sender As Object, e As EventArgs) Handles TextBoxNama.Leave
        If String.IsNullOrEmpty(TextBoxNama.Text) Then
            SetupTextBoxPlaceholder()
        End If
    End Sub

    Private Sub PanelDataStock_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles PanelDataStock.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = PanelDataStock.Rows(e.RowIndex)
            selectedBarangId = row.Cells("IdBarang").Value.ToString()

            Dim selectedRow As DataRow = barangTable.AsEnumerable().FirstOrDefault(Function(r) r("IdBarang").ToString() = selectedBarangId)
            If selectedRow IsNot Nothing Then
                LabelHarga.Text = "Harga: Rp " & Convert.ToInt32(selectedRow("HargaBeli")).ToString("N0")
                HitungTotal()
                TextBoxNama.Text = selectedRow("Nama").ToString()
                TextBoxNama.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub NumericBeli_ValueChanged(sender As Object, e As EventArgs) Handles NumericBeli.ValueChanged
        HitungTotal()
    End Sub

    Private Sub HitungTotal()
        If Not String.IsNullOrEmpty(selectedBarangId) Then
            Dim selectedRow As DataRow = barangTable.AsEnumerable().FirstOrDefault(Function(r) r("IdBarang").ToString() = selectedBarangId)
            If selectedRow IsNot Nothing Then
                Dim harga As Integer = Convert.ToInt32(selectedRow("HargaBeli"))
                Dim jumlah As Integer = CInt(NumericBeli.Value)
                Dim total As Integer = harga * jumlah
                LabelTotal.Text = "Total: Rp " & total.ToString("N0")
            End If
        Else
            LabelTotal.Text = "Total: Rp 0"
        End If
    End Sub

    ' ------------------------------------------
    '  LOGIKA UTAMA: Proses Pembelian
    ' ------------------------------------------
    Private Sub BeliBtn_Click(sender As Object, e As EventArgs) Handles BeliBtn.Click
        ' --- Validasi Input ---
        If String.IsNullOrEmpty(selectedBarangId) Then
            MessageBox.Show("Pilih barang terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If
        If NumericBeli.Value <= 0 Then
            MessageBox.Show("Jumlah pembelian minimal 1.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If

        Dim selectedRow As DataRow = barangTable.AsEnumerable().FirstOrDefault(Function(r) r("IdBarang").ToString() = selectedBarangId)
        If selectedRow Is Nothing Then Return

        Dim hargaBeli As Integer = Convert.ToInt32(selectedRow("HargaBeli"))
        Dim jumlah As Integer = CInt(NumericBeli.Value)
        Dim totalBiaya As Integer = hargaBeli * jumlah
        Dim namaBarang As String = selectedRow("Nama").ToString()
        Dim metodeBayar As String = If(RadioTunai.Checked, "CASH", "BANK")

        ' --- Validasi Saldo ---
        RefreshSaldoEkonomi()
        Dim saldoTersedia As Decimal = If(metodeBayar = "CASH", currentSaldoCash, currentSaldoBank)

        If saldoTersedia < totalBiaya Then
            MessageBox.Show($"Saldo {metodeBayar} Toko tidak cukup!" & vbCrLf &
                            $"Saldo: Rp {saldoTersedia:N0}" & vbCrLf &
                            $"Biaya: Rp {totalBiaya:N0}", "Transaksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' --- Konfirmasi ---
        If MessageBox.Show($"Beli {jumlah} unit {namaBarang} seharga Rp {totalBiaya:N0} menggunakan {metodeBayar}?",
                           "Konfirmasi Pembelian", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            ProsesPembelian(selectedBarangId, namaBarang, jumlah, totalBiaya, metodeBayar)
        End If
    End Sub

    Private Sub ProsesPembelian(idBarang As String, namaBarang As String, jumlah As Integer, totalBiaya As Integer, metodeBayar As String)
        ' [PERBAIKAN IDE0059] Hapus inisialisasi '= Nothing' agar lebih efisien
        Dim conn As MySqlConnection
        Dim transaction As MySqlTransaction = Nothing

        Try
            db.Koneksi()
            conn = db.Connection

            If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
                Throw New Exception("Koneksi database terputus.")
            End If

            transaction = conn.BeginTransaction()

            ' 1. Tambah Stok Barang
            Dim sqlStock As String = "UPDATE barang SET Stock = Stock + @jumlah WHERE IdBarang = @id"
            Using cmd As New MySqlCommand(sqlStock, conn, transaction)
                cmd.Parameters.AddWithValue("@jumlah", jumlah)
                cmd.Parameters.AddWithValue("@id", idBarang)
                cmd.ExecuteNonQuery()
            End Using

            ' 2. Kurangi Saldo Toko (Ekonomi)
            Dim colSaldo As String = If(metodeBayar = "CASH", "saldo_cash", "saldo_bank")
            Dim sqlEko As String = $"UPDATE ekonomi SET {colSaldo} = {colSaldo} - @biaya, total_pengeluaran = total_pengeluaran + @biaya WHERE id_utama = 'UTAMA'"
            Using cmd As New MySqlCommand(sqlEko, conn, transaction)
                cmd.Parameters.AddWithValue("@biaya", totalBiaya)
                cmd.ExecuteNonQuery()
            End Using

            ' 3. Catat Jurnal (Arus Keluar / Pengeluaran)
            Dim idJurnal As String = "JRNL-" & DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim sqlJurnal As String = "INSERT INTO jurnal_keuangan (id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff) VALUES (@id, 'BELI STOK', @nom, 'KELUAR', @metode, @ket, @staff)"
            Using cmd As New MySqlCommand(sqlJurnal, conn, transaction)
                cmd.Parameters.AddWithValue("@id", idJurnal)
                cmd.Parameters.AddWithValue("@nom", -totalBiaya) ' Negatif karena uang keluar
                cmd.Parameters.AddWithValue("@metode", metodeBayar)
                cmd.Parameters.AddWithValue("@ket", $"Pembelian Stok: {namaBarang} ({jumlah} pcs)")
                cmd.Parameters.AddWithValue("@staff", SessionManager.AkunID)
                cmd.ExecuteNonQuery()
            End Using

            transaction.Commit()

            MessageBox.Show("Pembelian berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reset UI
            LoadDataBarang(TextBoxNama.Text)
            ResetFormSelection()

        Catch ex As Exception
            Try : transaction?.Rollback() : Catch : End Try
            MessageBox.Show("Gagal memproses pembelian: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            db.CloseConnection()
        End Try
    End Sub

    Private Sub ResetFormSelection()
        selectedBarangId = ""
        NumericBeli.Value = 0
        LabelHarga.Text = "Harga: Rp 0"
        LabelTotal.Text = "Total: Rp 0"
        PanelDataStock.ClearSelection()
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        SetupTextBoxPlaceholder()
        LoadDataBarang()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub LabelUang_Click(sender As Object, e As EventArgs) Handles LabelUang.Click
        UpdateLabelUang()
    End Sub
End Class