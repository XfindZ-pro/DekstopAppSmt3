Imports MySql.Data.MySqlClient
Imports System.Diagnostics
Imports System.Data

Public Class ManageStock
    Private db As New Database()
    Private WithEvents saldoTimer As New Timer()
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
        saldoTimer.Interval = 1000 ' 1 detik
        saldoTimer.Start()

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
    '  Timer untuk update saldo
    ' ------------------------------------------
    Private Sub saldoTimer_Tick(sender As Object, e As EventArgs) Handles saldoTimer.Tick
        UpdateLabelUang()
    End Sub

    ' ------------------------------------------
    '  Update Label Uang (Saldo Perusahaan)
    ' ------------------------------------------
    Private Sub UpdateLabelUang()
        ' Selalu refresh saldo dari tabel ekonomi
        RefreshSaldoEkonomi()
        ' Tampilkan saldo perusahaan, bukan saldo staff
        LabelUang.Text = $"Kas: Rp {currentSaldoCash.ToString("N0")} | Bank: Rp {currentSaldoBank.ToString("N0")}"
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
            ' Gagal refresh, jangan ubah nilai
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
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Nama", .HeaderText = "Name Barang", .DataPropertyName = "Nama", .Width = 200})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "HargaBeli", .HeaderText = "Harga Beli", .DataPropertyName = "HargaBeli", .Width = 120, .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N0", .Alignment = DataGridViewContentAlignment.MiddleRight}})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Stock", .HeaderText = "Stock Barang", .DataPropertyName = "Stock", .Width = 100, .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}})
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
    '  Event TextBox Pencarian
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

    ' ------------------------------------------
    '  Event Grid Click
    ' ------------------------------------------
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

    ' ------------------------------------------
    '  Hitung Total Pembelian
    ' ------------------------------------------
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

    Private Sub NumericBeli_ValueChanged(sender As Object, e As EventArgs) Handles NumericBeli.ValueChanged
        HitungTotal()
    End Sub

    ' ------------------------------------------
    '  Proses Pembelian
    ' ------------------------------------------
    Private Sub BeliBtn_Click(sender As Object, e As EventArgs) Handles BeliBtn.Click
        ' --- Validasi 1: Input Form ---
        If String.IsNullOrEmpty(selectedBarangId) Then
            MessageBox.Show("Pilih barang terlebih dahulu dari tabel!", "Peringatan") : TextBoxNama.Focus() : Return
        End If
        If NumericBeli.Value <= 0 Then
            MessageBox.Show("Jumlah pembelian harus lebih dari 0!", "Peringatan") : NumericBeli.Focus() : Return
        End If
        If Not RadioTunai.Checked AndAlso Not RadioBank.Checked Then
            MessageBox.Show("Pilih metode pembayaran (Tunai/Bank)!", "Peringatan") : Return
        End If

        Dim selectedRow As DataRow = barangTable.AsEnumerable().FirstOrDefault(Function(r) r("IdBarang").ToString() = selectedBarangId)
        If selectedRow Is Nothing Then
            MessageBox.Show("Barang yang dipilih tidak valid.", "Error") : Return
        End If

        Dim hargaBeli As Integer = Convert.ToInt32(selectedRow("HargaBeli"))
        Dim jumlah As Integer = CInt(NumericBeli.Value)
        Dim totalBiaya As Integer = hargaBeli * jumlah
        Dim namaBarang As String = selectedRow("Nama").ToString()
        Dim metodeBayar As String = If(RadioTunai.Checked, "CASH", "BANK")

        ' --- Validasi 2: Saldo Perusahaan ---
        ' Kita refresh saldo lagi tepat sebelum validasi
        RefreshSaldoEkonomi()
        Dim saldoCukup As Boolean = False
        Dim saldoDimiliki As Decimal = 0

        If metodeBayar = "CASH" Then
            saldoDimiliki = currentSaldoCash
            If currentSaldoCash >= totalBiaya Then saldoCukup = True
        Else ' BANK
            saldoDimiliki = currentSaldoBank
            If currentSaldoBank >= totalBiaya Then saldoCukup = True
        End If

        If Not saldoCukup Then
            MessageBox.Show($"Saldo {metodeBayar} perusahaan tidak mencukupi!" & vbCrLf &
                            $"Saldo {metodeBayar}: Rp {saldoDimiliki.ToString("N0")}" & vbCrLf &
                            $"Dibutuhkan: Rp {totalBiaya.ToString("N0")}", "Saldo Kurang", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- Validasi 3: Konfirmasi User ---
        Dim konfirmasi As DialogResult = MessageBox.Show(
            "Konfirmasi Pembelian:" & vbCrLf &
            "Barang: " & namaBarang & vbCrLf &
            "Jumlah: " & jumlah.ToString() & vbCrLf &
            "Total: Rp " & totalBiaya.ToString("N0") & vbCrLf &
            "Metode: " & metodeBayar & vbCrLf & vbCrLf &
            "Lanjutkan pembelian?",
            "Konfirmasi Pembelian", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If konfirmasi = DialogResult.Yes Then
            ProsesPembelian(selectedBarangId, namaBarang, jumlah, totalBiaya, metodeBayar)
        End If
    End Sub

    ' ------------------------------------------
    '  Proses Pembelian ke Database (Logika Akuntansi Baru)
    ' ------------------------------------------
    Private Sub ProsesPembelian(idBarang As String, namaBarang As String, jumlah As Integer, totalBiaya As Integer, metodeBayar As String)
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing

        Try
            db.Koneksi()
            conn = db.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi gagal.")
            transaction = conn.BeginTransaction()

            ' 1. Update stock barang (Tambah stok)
            Dim sqlUpdateStock As String = "UPDATE barang SET Stock = Stock + @jumlah WHERE IdBarang = @idBarang;"
            Using cmdUpdate As New MySqlCommand(sqlUpdateStock, conn, transaction)
                cmdUpdate.Parameters.AddWithValue("@jumlah", jumlah)
                cmdUpdate.Parameters.AddWithValue("@idBarang", idBarang)
                cmdUpdate.ExecuteNonQuery()
            End Using

            ' 2. Update tabel ekonomi (Kurangi saldo cash/bank, tambah pengeluaran)
            Dim queryEkonomi As String = ""
            If metodeBayar = "CASH" Then
                queryEkonomi = "UPDATE ekonomi SET saldo_cash = saldo_cash - @total, total_pengeluaran = total_pengeluaran + @total WHERE id_utama = 'UTAMA'"
            Else ' BANK
                queryEkonomi = "UPDATE ekonomi SET saldo_bank = saldo_bank - @total, total_pengeluaran = total_pengeluaran + @total WHERE id_utama = 'UTAMA'"
            End If

            Using cmdEkonomi As New MySqlCommand(queryEkonomi, conn, transaction)
                cmdEkonomi.Parameters.AddWithValue("@total", totalBiaya)
                If cmdEkonomi.ExecuteNonQuery() = 0 Then Throw New Exception("Gagal update tabel ekonomi.")
            End Using

            ' 3. Catat di Jurnal Keuangan
            Dim idJurnal As String = "JRNL-" & DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim queryJurnal As String = "INSERT INTO jurnal_keuangan (id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff) " &
                                        "VALUES (@idJurnal, 'BELI STOK', @nominal, 'KELUAR', @MetodeBayar, @keterangan, @akunIdStaff)"
            Using cmdJurnal As New MySqlCommand(queryJurnal, conn, transaction)
                cmdJurnal.Parameters.AddWithValue("@idJurnal", idJurnal)
                cmdJurnal.Parameters.AddWithValue("@nominal", -totalBiaya) ' Pengeluaran dicatat sebagai negatif
                cmdJurnal.Parameters.AddWithValue("@MetodeBayar", metodeBayar)
                cmdJurnal.Parameters.AddWithValue("@keterangan", $"Beli stok: {jumlah} x {namaBarang}")
                cmdJurnal.Parameters.AddWithValue("@akunIdStaff", SessionManager.AkunID)
                If cmdJurnal.ExecuteNonQuery() = 0 Then Throw New Exception("Gagal catat jurnal keuangan.")
            End Using

            ' **[DIHAPUS]** Update saldo user (staff) dihapus total
            ' Dim sqlUpdateSaldo As String = "UPDATE akun SET emoney = emoney - @totalBiaya WHERE akunID = @userId;"

            ' Commit transaction
            transaction.Commit()

            ' Update SessionManager (tidak perlu lagi, saldo staff tidak berubah)
            ' RefreshSaldoFromDatabase() ' <-- Dihapus

            ' Refresh data grid
            LoadDataBarang(TextBoxNama.Text)

            ' Reset form selection
            ResetFormSelection()

            MessageBox.Show("Pembelian berhasil!" & vbCrLf &
                            "Stock " & namaBarang & " bertambah " & jumlah.ToString() & " unit" & vbCrLf &
                            $"Saldo {metodeBayar} perusahaan berkurang: Rp {totalBiaya.ToString("N0")}")

        Catch ex As Exception
            ' Rollback jika ada error
            Try : transaction?.Rollback() : Catch : End Try
            MessageBox.Show("Error saat proses pembelian: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ' ------------------------------------------
    '  Reset Form Selection
    ' ------------------------------------------
    Private Sub ResetFormSelection()
        selectedBarangId = ""
        NumericBeli.Value = 0
        LabelHarga.Text = "Harga: Rp 0"
        LabelTotal.Text = "Total: Rp 0"
        PanelDataStock.ClearSelection()
    End Sub

    ' ------------------------------------------
    '  Label Uang Click
    ' ------------------------------------------
    Private Sub LabelUang_Click(sender As Object, e As EventArgs) Handles LabelUang.Click
        ' Refresh saldo manual
        UpdateLabelUang()
    End Sub

    ' ------------------------------------------
    '  Tombol Reset Pencarian
    ' ------------------------------------------
    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        SetupTextBoxPlaceholder()
        LoadDataBarang()
        ResetFormSelection()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        ' Arahkan ke form dashboard
        Dim dashboardForm As New Dashboard() ' Form Dashboard
        dashboardForm.Show()
        Me.Hide() ' Menyembunyikan form stock
    End Sub
End Class