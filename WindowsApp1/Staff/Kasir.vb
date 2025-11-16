Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class Kasir
    ' Membuat satu instance objek Database untuk digunakan di seluruh form
    Private DB As New Database()
    Private Cmd As MySqlCommand
    Private Rd As MySqlDataReader

    ' Variabel untuk melacak mode tampilan PanelDataInfo (true = Keranjang, false = Pencarian Barang)
    Private isShowingKeranjang As Boolean = False

    ' Variabel untuk menyimpan total belanja saat ini
    Private currentTotalBelanja As Decimal = 0

#Region "Struktur Form & Navigasi"

    ' **[PERBAIKAN]** Jangan tutup seluruh aplikasi saat form ini ditutup
    Private Sub Kasir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    ' Event yang berjalan saat form pertama kali dimuat
    Private Sub Kasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadPelangganAutoComplete() ' Memuat daftar member untuk AutoComplete

        ' Atur kondisi awal form
        RadioButtonMemberTidak.Checked = True
        RadioButtonTunai.Checked = True

        UpdatePanelDisplay() ' Mengatur tampilan awal
    End Sub

    ' Tombol untuk kembali ke Dashboard
    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Hide()
    End Sub

#End Region

#Region "Manajemen Tampilan Panel & Switching"

    ' Tombol utama untuk beralih antara tampilan pencarian dan keranjang
    Private Sub BtnSwitch_Click(sender As Object, e As EventArgs) Handles BtnSwitch.Click
        isShowingKeranjang = Not isShowingKeranjang
        UpdatePanelDisplay()
    End Sub

    ' Fungsi pusat untuk mengatur ulang UI berdasarkan mode yang aktif
    Private Sub UpdatePanelDisplay()
        If isShowingKeranjang Then
            ' --- TAMPILAN KERANJANG ---
            LabelPanelInfo.Text = "Sedang Menampilkan: Keranjang Belanja"
            BtnTambahkanKeranjang.Visible = False
            BtnHapusKeranjang.Visible = True ' Tombol Hapus muncul
            BtnUpdateJumlah.Visible = True
            LabelTotal.Visible = True
            GroupBoxPembayaran.Visible = True
            LoadDataKeranjang()
        Else
            ' --- TAMPILAN PENCARIAN BARANG ---
            LabelPanelInfo.Text = "Sedang Menampilkan: Pencarian Barang"
            BtnTambahkanKeranjang.Visible = True
            BtnHapusKeranjang.Visible = False ' Tombol Hapus sembunyi
            BtnUpdateJumlah.Visible = False
            LabelTotal.Visible = False
            GroupBoxPembayaran.Visible = False
            LoadDataBarang()
        End If
    End Sub

    ' Fungsi untuk mengatur struktur dasar DataGridView
    Private Sub SetupDataGridView()
        PanelDataInfo.ReadOnly = True
        PanelDataInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        PanelDataInfo.AllowUserToAddRows = False
        PanelDataInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        PanelDataInfo.Columns.Clear()
        PanelDataInfo.Columns.Add("IdKeranjang", "ID Keranjang")
        PanelDataInfo.Columns.Add("IdBarang", "ID Barang")
        PanelDataInfo.Columns.Add("Nama", "Nama Barang")
        PanelDataInfo.Columns.Add("Satuan", "Satuan")
        PanelDataInfo.Columns.Add("StokAtauJumlah", "Stok")
        PanelDataInfo.Columns.Add("Warna", "Warna")
        PanelDataInfo.Columns.Add("Ukuran", "Ukuran")
        PanelDataInfo.Columns.Add("Harga", "Harga")
        PanelDataInfo.Columns("IdKeranjang").Visible = False
        PanelDataInfo.Columns("IdBarang").Visible = False
        PanelDataInfo.Columns("Nama").FillWeight = 200
        PanelDataInfo.Columns("StokAtauJumlah").FillWeight = 70
        PanelDataInfo.Columns("Satuan").FillWeight = 70
        PanelDataInfo.Columns("Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

#End Region

#Region "Fungsi Pencarian & Muat Data"

    ' Memuat data hasil pencarian barang
    Private Sub LoadDataBarang()
        PanelDataInfo.Columns("StokAtauJumlah").HeaderText = "Stok"
        Try
            DB.Koneksi()
            PanelDataInfo.Rows.Clear()
            Dim query As String = "SELECT IdBarang, Nama, Satuan, Stock, Warna, Ukuran, HargaJual FROM barang WHERE Nama LIKE @nama AND Warna LIKE @warna"
            Cmd = New MySqlCommand(query, DB.Connection)
            Cmd.Parameters.AddWithValue("@nama", "%" & TextBoxNama.Text & "%")
            Cmd.Parameters.AddWithValue("@warna", "%" & TextBoxWarna.Text & "%")
            Rd = Cmd.ExecuteReader()
            While Rd.Read()
                PanelDataInfo.Rows.Add("", Rd("IdBarang"), Rd("Nama"), Rd("Satuan"), Rd("Stock"), Rd("Warna"), Rd("Ukuran"), CInt(Rd("HargaJual")).ToString("N0"))
            End While
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data barang: " & ex.Message)
        Finally
            If Rd IsNot Nothing AndAlso Not Rd.IsClosed Then Rd.Close()
            DB.CloseConnection()
        End Try
    End Sub

    ' Memuat data dari keranjang belanja user yang sedang login
    Private Sub LoadDataKeranjang()
        PanelDataInfo.Columns("StokAtauJumlah").HeaderText = "Jumlah"
        Try
            DB.Koneksi()
            PanelDataInfo.Rows.Clear()
            Dim query As String = "SELECT k.IdKeranjang, b.IdBarang, b.Nama, b.Satuan, k.qty, b.Warna, b.Ukuran, k.Harga AS TotalHarga FROM keranjang k JOIN barang b ON k.IdBarang = b.IdBarang WHERE k.akunID = @akunId"
            Cmd = New MySqlCommand(query, DB.Connection)
            Cmd.Parameters.AddWithValue("@akunId", SessionManager.AkunID)
            Rd = Cmd.ExecuteReader()
            While Rd.Read()
                PanelDataInfo.Rows.Add(Rd("IdKeranjang"), Rd("IdBarang"), Rd("Nama"), Rd("Satuan"), Rd("qty"), Rd("Warna"), Rd("Ukuran"), CInt(Rd("TotalHarga")).ToString("N0"))
            End While
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data keranjang: " & ex.Message)
        Finally
            If Rd IsNot Nothing AndAlso Not Rd.IsClosed Then Rd.Close()
            DB.CloseConnection()
        End Try
        UpdateTotalHargaLabel()
    End Sub

    ' Fungsi untuk menghitung dan menampilkan total harga keranjang
    Private Sub UpdateTotalHargaLabel()
        Dim totalHarga As Decimal = 0
        Try
            DB.Koneksi()
            Dim query As String = "SELECT SUM(Harga) FROM keranjang WHERE akunID = @akunId"
            Cmd = New MySqlCommand(query, DB.Connection)
            Cmd.Parameters.AddWithValue("@akunId", SessionManager.AkunID)
            Dim result = Cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then totalHarga = Convert.ToDecimal(result)
        Catch ex As Exception
            MessageBox.Show("Gagal menghitung total harga: " & ex.Message)
        Finally
            If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then
                DB.CloseConnection()
            End If
        End Try
        Me.currentTotalBelanja = totalHarga
        LabelTotal.Text = "Total Harga: Rp. " & Me.currentTotalBelanja.ToString("N0")
    End Sub

    ' Fungsi untuk memuat daftar member ke AutoComplete ComboBox
    Private Sub LoadPelangganAutoComplete()
        Dim autoCompleteCollection As New AutoCompleteStringCollection()
        Try
            DB.Koneksi()
            Dim query As String = "SELECT username FROM akun WHERE role = 'user' OR role = 'staff'"
            Cmd = New MySqlCommand(query, DB.Connection)
            Rd = Cmd.ExecuteReader()
            While Rd.Read() : autoCompleteCollection.Add(Rd("username").ToString()) : End While
        Catch ex As Exception
            MessageBox.Show("Gagal memuat daftar member: " & ex.Message)
        Finally
            If Rd IsNot Nothing AndAlso Not Rd.IsClosed Then Rd.Close()
            If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then
                DB.CloseConnection()
            End If
        End Try
        ComboBoxPelanggan.AutoCompleteCustomSource = autoCompleteCollection
    End Sub

    Private Sub TextBoxNama_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNama.TextChanged
        If Not isShowingKeranjang Then LoadDataBarang()
    End Sub

    Private Sub TextBoxWarna_TextChanged(sender As Object, e As EventArgs) Handles TextBoxWarna.TextChanged
        If Not isShowingKeranjang Then LoadDataBarang()
    End Sub

#End Region

#Region "Logika Keranjang (Tambah, Hapus, Edit)"

    Private Sub BtnTambahkanKeranjang_Click(sender As Object, e As EventArgs) Handles BtnTambahkanKeranjang.Click
        If PanelDataInfo.CurrentRow Is Nothing Then MessageBox.Show("Silakan pilih barang.", "Peringatan") : Return
        If NumericJumlah.Value <= 0 Then MessageBox.Show("Jumlah barang harus minimal 1.", "Peringatan") : Return
        Dim selectedRow = PanelDataInfo.CurrentRow
        Dim idBarang = selectedRow.Cells("IdBarang").Value.ToString()
        Dim stokTersedia = CInt(selectedRow.Cells("StokAtauJumlah").Value)
        Dim hargaSatuan = CInt(selectedRow.Cells("Harga").Value.ToString().Replace(".", ""))
        Dim jumlahDiminta = CInt(NumericJumlah.Value)
        If jumlahDiminta > stokTersedia Then MessageBox.Show($"Stok tidak mencukupi. Sisa stok {stokTersedia}.", "Stok Kurang") : Return
        Try
            DB.Koneksi()
            Dim qtyDiKeranjang = 0
            Dim idKeranjangExisting = ""
            Dim checkQuery = "SELECT IdKeranjang, qty FROM keranjang WHERE IdBarang = @idBarang AND akunID = @akunId"
            Cmd = New MySqlCommand(checkQuery, DB.Connection)
            Cmd.Parameters.AddWithValue("@idBarang", idBarang)
            Cmd.Parameters.AddWithValue("@akunId", SessionManager.AkunID)
            Rd = Cmd.ExecuteReader()
            If Rd.Read() Then
                idKeranjangExisting = Rd("IdKeranjang").ToString()
                qtyDiKeranjang = CInt(Rd("qty"))
            End If
            Rd.Close()
            If idKeranjangExisting <> "" Then
                Dim qtyBaru = qtyDiKeranjang + jumlahDiminta
                If qtyBaru > stokTersedia Then MessageBox.Show($"Tidak bisa. Total di keranjang + jumlah baru akan melebihi stok.", "Stok Tidak Cukup") : Return
                Dim totalHargaBaru = hargaSatuan * qtyBaru
                Dim updateQuery = "UPDATE keranjang SET qty = @qtyBaru, Harga = @hargaBaru WHERE IdKeranjang = @idKeranjang"
                Cmd = New MySqlCommand(updateQuery, DB.Connection)
                Cmd.Parameters.AddWithValue("@qtyBaru", qtyBaru)
                Cmd.Parameters.AddWithValue("@hargaBaru", totalHargaBaru)
                Cmd.Parameters.AddWithValue("@idKeranjang", idKeranjangExisting)
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Jumlah barang diperbarui.", "Sukses")
            Else
                Dim totalHarga = hargaSatuan * jumlahDiminta
                Dim idKeranjangBaru = GenerateUniqueKeranjangID(DB.Connection)
                Dim insertQuery = "INSERT INTO keranjang (IdKeranjang, IdBarang, akunID, Harga, qty) VALUES (@idKeranjang, @idBarang, @akunId, @harga, @qty)"
                Cmd = New MySqlCommand(insertQuery, DB.Connection)
                With Cmd.Parameters
                    .AddWithValue("@idKeranjang", idKeranjangBaru)
                    .AddWithValue("@idBarang", idBarang)
                    .AddWithValue("@akunId", SessionManager.AkunID)
                    .AddWithValue("@harga", totalHarga)
                    .AddWithValue("@qty", jumlahDiminta)
                End With
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Barang ditambahkan ke keranjang.", "Sukses")
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memproses keranjang: " & ex.Message)
        Finally
            If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then
                DB.CloseConnection()
            End If
        End Try
        NumericJumlah.Value = 0
        PanelDataInfo.ClearSelection()
        If isShowingKeranjang Then LoadDataKeranjang()
    End Sub

    Private Sub BtnUpdateJumlah_Click(sender As Object, e As EventArgs) Handles BtnUpdateJumlah.Click
        If PanelDataInfo.CurrentRow Is Nothing Then MessageBox.Show("Pilih barang di keranjang yang ingin diupdate.", "Peringatan") : Return
        Dim qtyBaru = CInt(NumericJumlah.Value)
        If qtyBaru <= 0 Then MessageBox.Show("Jumlah baru harus minimal 1.", "Peringatan") : Return
        Dim selectedRow = PanelDataInfo.CurrentRow
        Dim idKeranjang = selectedRow.Cells("IdKeranjang").Value.ToString()
        Dim idBarang = selectedRow.Cells("IdBarang").Value.ToString()
        Try
            DB.Koneksi()
            Dim stokTersedia As Integer
            Cmd = New MySqlCommand("SELECT Stock FROM barang WHERE IdBarang = @idBarang", DB.Connection)
            Cmd.Parameters.AddWithValue("@idBarang", idBarang)
            stokTersedia = CInt(Cmd.ExecuteScalar())
            If qtyBaru > stokTersedia Then MessageBox.Show($"Jumlah baru ({qtyBaru}) melebihi stok yang tersedia ({stokTersedia}).", "Stok Tidak Cukup") : Return
            Dim hargaSatuan As Integer
            Cmd = New MySqlCommand("SELECT HargaJual FROM barang WHERE IdBarang = @idBarang", DB.Connection)
            Cmd.Parameters.AddWithValue("@idBarang", idBarang)
            hargaSatuan = CInt(Cmd.ExecuteScalar())
            Dim totalHargaBaru = hargaSatuan * qtyBaru
            Dim updateQuery = "UPDATE keranjang SET qty = @qtyBaru, Harga = @hargaBaru WHERE IdKeranjang = @idKeranjang"
            Cmd = New MySqlCommand(updateQuery, DB.Connection)
            Cmd.Parameters.AddWithValue("@qtyBaru", qtyBaru)
            Cmd.Parameters.AddWithValue("@hargaBaru", totalHargaBaru)
            Cmd.Parameters.AddWithValue("@idKeranjang", idKeranjang)
            Cmd.ExecuteNonQuery()
            MessageBox.Show("Jumlah barang berhasil diupdate.", "Sukses")
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui jumlah: " & ex.Message)
        Finally
            If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then
                DB.CloseConnection()
            End If
        End Try
        LoadDataKeranjang()
    End Sub

    ''' <summary>
    ''' **[LOGIKA DIISI]**
    ''' Menghapus item yang dipilih dari keranjang.
    ''' </summary>
    Private Sub BtnHapusKeranjang_Click(sender As Object, e As EventArgs) Handles BtnHapusKeranjang.Click
        ' Pastikan sedang dalam mode keranjang dan ada baris yang dipilih
        If Not isShowingKeranjang OrElse PanelDataInfo.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih barang di keranjang yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim idKeranjang = PanelDataInfo.CurrentRow.Cells("IdKeranjang").Value.ToString()
        Dim namaBarang = PanelDataInfo.CurrentRow.Cells("Nama").Value.ToString()

        If MessageBox.Show($"Yakin ingin menghapus '{namaBarang}' dari keranjang?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                DB.Koneksi()
                Dim deleteQuery = "DELETE FROM keranjang WHERE IdKeranjang = @idKeranjang"
                Cmd = New MySqlCommand(deleteQuery, DB.Connection)
                Cmd.Parameters.AddWithValue("@idKeranjang", idKeranjang)
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Barang berhasil dihapus dari keranjang.", "Sukses")
            Catch ex As Exception
                MessageBox.Show("Gagal menghapus barang: " & ex.Message)
            Finally
                If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then
                    DB.CloseConnection()
                End If
            End Try
            ' Muat ulang data keranjang untuk refresh tampilan
            LoadDataKeranjang()
        End If
    End Sub

    Private Sub PanelDataInfo_SelectionChanged(sender As Object, e As EventArgs) Handles PanelDataInfo.SelectionChanged
        If isShowingKeranjang AndAlso PanelDataInfo.CurrentRow IsNot Nothing Then
            Dim qtySaatIni = CInt(PanelDataInfo.CurrentRow.Cells("StokAtauJumlah").Value)
            NumericJumlah.Value = qtySaatIni
        End If
    End Sub

    Private Sub PanelDataInfo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles PanelDataInfo.CellDoubleClick
        ' Kosong
    End Sub

    Private Function GenerateUniqueKeranjangID(conn As MySqlConnection) As String
        Dim random As New Random()
        Dim newId As String
        Do
            newId = "Krnjg" & random.Next(10000, 99999).ToString()
            Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM keranjang WHERE IdKeranjang = @id", conn)
            checkCmd.Parameters.AddWithValue("@id", newId)
            If CInt(checkCmd.ExecuteScalar()) = 0 Then Return newId
        Loop
    End Function

#End Region

#Region "Logika Pembayaran & Event Handler"

    ''' <summary>
    ''' **[PERBAIKAN]** Ganti 'money' menjadi 'emoney'
    ''' </summary>
    Private Function GetSaldoPelanggan(username As String) As Decimal
        Try
            DB.Koneksi()
            Dim query As String = "SELECT emoney FROM akun WHERE username = @username"
            Cmd = New MySqlCommand(query, DB.Connection)
            Cmd.Parameters.AddWithValue("@username", username)
            Dim result = Cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then Return Convert.ToDecimal(result) Else Return -1
        Catch ex As Exception
            MessageBox.Show("Gagal mengecek saldo: " & ex.Message) : Return -1
        Finally
            If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then
                DB.CloseConnection()
            End If
        End Try
    End Function

    ' Fungsi helper untuk mengambil akunID pelanggan (member)
    Private Function GetMemberAkunId(username As String) As String
        Try
            DB.Koneksi()
            Dim query As String = "SELECT akunID FROM akun WHERE username = @username"
            Cmd = New MySqlCommand(query, DB.Connection)
            Cmd.Parameters.AddWithValue("@username", username)
            Dim result = Cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return result.ToString()
            Else
                Return String.Empty ' User tidak ditemukan
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal mendapatkan ID Member: " & ex.Message)
            Return String.Empty
        Finally
            If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then
                DB.CloseConnection()
            End If
        End Try
    End Function

    ' Logika utama untuk memvalidasi pembayaran dan pindah ke Form KonfirmasiBayar
    Private Sub BtnBayar_Click(sender As Object, e As EventArgs) Handles BtnBayar.Click
        If Me.currentTotalBelanja <= 0 Then MessageBox.Show("Keranjang masih kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        Dim jumlahBayar As Decimal = 0
        Dim metodeBayar As String = ""
        Dim kembalian As Decimal = 0
        Dim memberId As String = String.Empty
        Dim namaPelanggan As String = ComboBoxPelanggan.Text.Trim()

        If RadioButtonMemberIya.Checked Then
            If String.IsNullOrWhiteSpace(namaPelanggan) Then
                MessageBox.Show("Pilih member dari daftar.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
            End If
            memberId = GetMemberAkunId(namaPelanggan)
            If String.IsNullOrEmpty(memberId) Then
                MessageBox.Show($"Member dengan username '{namaPelanggan}' tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Return
            End If
        Else
            If String.IsNullOrWhiteSpace(namaPelanggan) Then namaPelanggan = "Non-Member"
            memberId = String.Empty
        End If

        If RadioButtonTunai.Checked Then
            metodeBayar = "Tunai"
            jumlahBayar = NumericTunai.Value
            If jumlahBayar < Me.currentTotalBelanja Then MessageBox.Show("Jumlah uang tunai kurang.", "Uang Kurang", MessageBoxButtons.OK, MessageBoxIcon.Error) : Return
            kembalian = jumlahBayar - Me.currentTotalBelanja
        ElseIf RadioButtonEmoney.Checked Then
            metodeBayar = "E-money"
            If RadioButtonMemberIya.Checked = False Then MessageBox.Show("E-money hanya untuk member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : RadioButtonMemberIya.Checked = True : Return
            If String.IsNullOrEmpty(memberId) Then MessageBox.Show("ID Member tidak valid untuk E-money.", "Error") : Return
            Dim saldoPelanggan As Decimal = GetSaldoPelanggan(namaPelanggan)
            If saldoPelanggan < Me.currentTotalBelanja Then MessageBox.Show($"Saldo E-money '{namaPelanggan}' tidak cukup.", "Saldo Kurang", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
            jumlahBayar = Me.currentTotalBelanja
            kembalian = 0
        Else
            MessageBox.Show("Pilih metode pembayaran.", "Peringatan") : Return
        End If

        Dim frmKonfirmasi As New KonfirmasiBayar(
            Me.currentTotalBelanja,
            jumlahBayar,
            kembalian,
            namaPelanggan,
            metodeBayar,
            memberId
        )
        Dim result As DialogResult = frmKonfirmasi.ShowDialog()

        If result = DialogResult.OK Then
            MessageBox.Show("Transaksi Selesai.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ResetFormKasir()
        End If
    End Sub

    ' Fungsi untuk membersihkan form setelah transaksi sukses
    Private Sub ResetFormKasir()
        isShowingKeranjang = False
        UpdatePanelDisplay()
        NumericTunai.Value = 0
        RadioButtonMemberTidak.Checked = True
        RadioButtonTunai.Checked = True
        ComboBoxPelanggan.Text = ""
        TextBoxNama.Text = ""
        TextBoxWarna.Text = ""
        NumericJumlah.Value = 0
        Me.currentTotalBelanja = 0
    End Sub

    ' Mengatur AutoComplete ComboBox saat "Iya" dipilih
    Private Sub RadioButtonMemberIya_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonMemberIya.CheckedChanged
        If RadioButtonMemberIya.Checked Then
            ComboBoxPelanggan.DropDownStyle = ComboBoxStyle.DropDown
            ComboBoxPelanggan.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            ComboBoxPelanggan.AutoCompleteSource = AutoCompleteSource.CustomSource
            ComboBoxPelanggan.Text = ""
        End If
    End Sub

    ' Mengatur ComboBox jadi ketik bebas saat "Tidak" dipilih
    Private Sub RadioButtonMemberTidak_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonMemberTidak.CheckedChanged
        If RadioButtonMemberTidak.Checked Then
            ComboBoxPelanggan.DropDownStyle = ComboBoxStyle.DropDown
            ComboBoxPelanggan.AutoCompleteMode = AutoCompleteMode.None
            ComboBoxPelanggan.AutoCompleteSource = AutoCompleteSource.None
            ComboBoxPelanggan.Text = ""
            If RadioButtonEmoney.Checked Then RadioButtonTunai.Checked = True
        End If
    End Sub

    ' Menampilkan/menyembunyikan NumericTunai
    Private Sub RadioButtonTunai_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonTunai.CheckedChanged
        If RadioButtonTunai.Checked Then
            NumericTunai.Visible = True
            LabelTunai.Visible = True ' Pastikan label tunai juga terlihat
        End If
    End Sub

    ' Menyembunyikan NumericTunai dan validasi member
    Private Sub RadioButtonEmoney_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonEmoney.CheckedChanged
        If RadioButtonEmoney.Checked Then
            NumericTunai.Visible = False
            LabelTunai.Visible = False ' Pastikan labelnya juga disembunyikan
            If RadioButtonMemberTidak.Checked Then
                If RadioButtonMemberIya.Checked = False Then
                    MessageBox.Show("E-money hanya untuk member. Status member akan diubah.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RadioButtonMemberIya.Checked = True
                End If
            End If
        End If
    End Sub

    ' --- Event Handler Kosong ---
    Private Sub PanelDataInfo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles PanelDataInfo.CellContentClick : End Sub
    Private Sub NumericJumlah_ValueChanged(sender As Object, e As EventArgs) Handles NumericJumlah.ValueChanged : End Sub
    Private Sub LabelPanelInfo_Click(sender As Object, e As EventArgs) Handles LabelPanelInfo.Click : End Sub
    Private Sub LabelTotal_Click(sender As Object, e As EventArgs) Handles LabelTotal.Click : End Sub
    Private Sub NumericTunai_ValueChanged(sender As Object, e As EventArgs) Handles NumericTunai.ValueChanged : End Sub
    Private Sub ComboBoxPelanggan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPelanggan.SelectedIndexChanged : End Sub

    ' **[PERBAIKAN]** Ini seharusnya merujuk ke BtnHapusKeranjang, bukan BtnHapusBarang
    ' Private Sub BtnHapusBarang_Click(sender As Object, e As EventArgs) Handles BtnHapusBarang.Click
    ' End Sub

#End Region

End Class