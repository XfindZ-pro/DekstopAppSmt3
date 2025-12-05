Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class Kasir
    ' Objek Database
    Private DB As New Database()

    ' Variabel State
    Private isShowingKeranjang As Boolean = False
    Private currentTotalBelanja As Decimal = 0

#Region "1. Struktur Form & Navigasi"

    Private Sub Kasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadPelangganAutoComplete()

        ' Default State
        RadioButtonMemberTidak.Checked = True
        RadioButtonTunai.Checked = True

        UpdatePanelDisplay()
    End Sub

    ' [PERBAIKAN] Hanya menutup form ini, tidak mematikan aplikasi
    Private Sub Kasir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Close()
    End Sub

#End Region

#Region "2. Manajemen Tampilan (Panel Switching)"

    Private Sub BtnSwitch_Click(sender As Object, e As EventArgs) Handles BtnSwitch.Click
        isShowingKeranjang = Not isShowingKeranjang
        UpdatePanelDisplay()
    End Sub

    Private Sub UpdatePanelDisplay()
        If isShowingKeranjang Then
            LabelPanelInfo.Text = "Mode: KERANJANG BELANJA"
            BtnTambahkanKeranjang.Visible = False
            BtnHapusKeranjang.Visible = True
            BtnUpdateJumlah.Visible = True
            LabelTotal.Visible = True
            GroupBoxPembayaran.Visible = True
            LoadDataKeranjang()
        Else
            LabelPanelInfo.Text = "Mode: PENCARIAN BARANG"
            BtnTambahkanKeranjang.Visible = True
            BtnHapusKeranjang.Visible = False
            BtnUpdateJumlah.Visible = False
            LabelTotal.Visible = False
            GroupBoxPembayaran.Visible = False
            LoadDataBarang()
        End If
    End Sub

    Private Sub SetupDataGridView()
        With PanelDataInfo
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()
            .Columns.Add("IdKeranjang", "ID")
            .Columns.Add("IdBarang", "ID Barang")
            .Columns.Add("Nama", "Nama Barang")
            .Columns.Add("Satuan", "Satuan")
            .Columns.Add("StokAtauJumlah", "Stok/Qty")
            .Columns.Add("Warna", "Warna")
            .Columns.Add("Ukuran", "Ukuran")
            .Columns.Add("Harga", "Harga")

            ' Visibilitas & Formatting
            .Columns("IdKeranjang").Visible = False
            .Columns("IdBarang").Visible = False
            .Columns("Nama").FillWeight = 200
            .Columns("Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Harga").DefaultCellStyle.Format = "N0"
        End With
    End Sub

#End Region

#Region "3. Fungsi Data (Barang & Keranjang)"

    Private Sub LoadDataBarang()
        PanelDataInfo.Columns("StokAtauJumlah").HeaderText = "Stok Gudang"
        Try
            DB.Koneksi()
            PanelDataInfo.Rows.Clear()
            Dim query As String = "SELECT IdBarang, Nama, Satuan, Stock, Warna, Ukuran, HargaJual FROM barang WHERE Nama LIKE @nama AND Warna LIKE @warna"

            Using cmd As New MySqlCommand(query, DB.Connection)
                cmd.Parameters.AddWithValue("@nama", "%" & TextBoxNama.Text & "%")
                cmd.Parameters.AddWithValue("@warna", "%" & TextBoxWarna.Text & "%")

                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        PanelDataInfo.Rows.Add("", rd("IdBarang"), rd("Nama"), rd("Satuan"), rd("Stock"), rd("Warna"), rd("Ukuran"), rd("HargaJual"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error muat barang: " & ex.Message)
        Finally
            DB.CloseConnection()
        End Try
    End Sub

    Private Sub LoadDataKeranjang()
        PanelDataInfo.Columns("StokAtauJumlah").HeaderText = "Qty di Keranjang"
        Try
            DB.Koneksi()
            PanelDataInfo.Rows.Clear()
            Dim query As String = "SELECT k.IdKeranjang, b.IdBarang, b.Nama, b.Satuan, k.qty, b.Warna, b.Ukuran, k.Harga FROM keranjang k JOIN barang b ON k.IdBarang = b.IdBarang WHERE k.akunID = @akunId"

            Using cmd As New MySqlCommand(query, DB.Connection)
                cmd.Parameters.AddWithValue("@akunId", SessionManager.AkunID)
                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        PanelDataInfo.Rows.Add(rd("IdKeranjang"), rd("IdBarang"), rd("Nama"), rd("Satuan"), rd("qty"), rd("Warna"), rd("Ukuran"), rd("Harga"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error muat keranjang: " & ex.Message)
        Finally
            DB.CloseConnection()
        End Try
        UpdateTotalHargaLabel()
    End Sub

    Private Sub UpdateTotalHargaLabel()
        Try
            DB.Koneksi()
            Dim query As String = "SELECT SUM(Harga) FROM keranjang WHERE akunID = @akunId"
            Using cmd As New MySqlCommand(query, DB.Connection)
                cmd.Parameters.AddWithValue("@akunId", SessionManager.AkunID)
                Dim result = cmd.ExecuteScalar()
                currentTotalBelanja = If(IsDBNull(result) Or result Is Nothing, 0, Convert.ToDecimal(result))
            End Using
        Catch ex As Exception
            currentTotalBelanja = 0
        Finally
            DB.CloseConnection()
        End Try
        LabelTotal.Text = "Total Harga: Rp. " & currentTotalBelanja.ToString("N0")
    End Sub

    Private Sub LoadPelangganAutoComplete()
        Dim collection As New AutoCompleteStringCollection()
        Try
            DB.Koneksi()
            Dim query As String = "SELECT username FROM akun WHERE role = 'user' OR role = 'staff'"
            Using cmd As New MySqlCommand(query, DB.Connection)
                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        collection.Add(rd("username").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
        Finally
            DB.CloseConnection()
        End Try
        ComboBoxPelanggan.AutoCompleteCustomSource = collection
    End Sub

    ' Search Event Listeners
    Private Sub TextBoxNama_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNama.TextChanged
        If Not isShowingKeranjang Then LoadDataBarang()
    End Sub
    Private Sub TextBoxWarna_TextChanged(sender As Object, e As EventArgs) Handles TextBoxWarna.TextChanged
        If Not isShowingKeranjang Then LoadDataBarang()
    End Sub

#End Region

#Region "4. Logika Aksi Keranjang (Add/Update/Delete)"

    Private Sub BtnTambahkanKeranjang_Click(sender As Object, e As EventArgs) Handles BtnTambahkanKeranjang.Click
        If PanelDataInfo.CurrentRow Is Nothing Then Return
        If isShowingKeranjang Then MessageBox.Show("Anda sedang di menu keranjang. Pindah ke pencarian untuk menambah barang.") : Return

        Dim qtyInput As Integer = CInt(NumericJumlah.Value)
        If qtyInput <= 0 Then MessageBox.Show("Jumlah minimal 1.") : Return

        Dim row = PanelDataInfo.CurrentRow
        Dim idBarang = row.Cells("IdBarang").Value.ToString()
        Dim stokGudang = CInt(row.Cells("StokAtauJumlah").Value)
        Dim hargaSatuan = CInt(row.Cells("Harga").Value)

        If qtyInput > stokGudang Then MessageBox.Show($"Stok tidak cukup. Sisa: {stokGudang}") : Return

        Try
            DB.Koneksi()
            ' Cek apakah barang sudah ada di keranjang
            Dim checkQ As String = "SELECT IdKeranjang, qty FROM keranjang WHERE IdBarang = @idB AND akunID = @me"
            Dim existingID As String = ""
            Dim existingQty As Integer = 0

            Using cmd As New MySqlCommand(checkQ, DB.Connection)
                cmd.Parameters.AddWithValue("@idB", idBarang)
                cmd.Parameters.AddWithValue("@me", SessionManager.AkunID)
                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    If rd.Read() Then
                        existingID = rd("IdKeranjang").ToString()
                        existingQty = CInt(rd("qty"))
                    End If
                End Using
            End Using

            If existingID <> "" Then
                ' UPDATE EXISTING
                Dim newQty = existingQty + qtyInput
                If newQty > stokGudang Then MessageBox.Show("Total di keranjang akan melebihi stok gudang.") : Return

                Dim updateQ As String = "UPDATE keranjang SET qty = @q, Harga = @h WHERE IdKeranjang = @id"
                Using cmd As New MySqlCommand(updateQ, DB.Connection)
                    cmd.Parameters.AddWithValue("@q", newQty)
                    cmd.Parameters.AddWithValue("@h", newQty * hargaSatuan)
                    cmd.Parameters.AddWithValue("@id", existingID)
                    cmd.ExecuteNonQuery()
                End Using
            Else
                ' INSERT NEW
                Dim newID = "CART" & New Random().Next(10000, 99999)
                Dim insertQ As String = "INSERT INTO keranjang (IdKeranjang, IdBarang, akunID, Harga, qty) VALUES (@id, @idB, @me, @h, @q)"
                Using cmd As New MySqlCommand(insertQ, DB.Connection)
                    cmd.Parameters.AddWithValue("@id", newID)
                    cmd.Parameters.AddWithValue("@idB", idBarang)
                    cmd.Parameters.AddWithValue("@me", SessionManager.AkunID)
                    cmd.Parameters.AddWithValue("@h", qtyInput * hargaSatuan)
                    cmd.Parameters.AddWithValue("@q", qtyInput)
                    cmd.ExecuteNonQuery()
                End Using
            End If

            MessageBox.Show("Berhasil masuk keranjang.")
            NumericJumlah.Value = 0
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            DB.CloseConnection()
        End Try
    End Sub

    Private Sub BtnHapusKeranjang_Click(sender As Object, e As EventArgs) Handles BtnHapusKeranjang.Click
        If Not isShowingKeranjang OrElse PanelDataInfo.CurrentRow Is Nothing Then Return

        Dim idKeranjang = PanelDataInfo.CurrentRow.Cells("IdKeranjang").Value.ToString()
        Dim nama = PanelDataInfo.CurrentRow.Cells("Nama").Value.ToString()

        If MessageBox.Show($"Hapus '{nama}' dari keranjang?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                DB.Koneksi()
                Dim q As String = "DELETE FROM keranjang WHERE IdKeranjang = @id"
                Using cmd As New MySqlCommand(q, DB.Connection)
                    cmd.Parameters.AddWithValue("@id", idKeranjang)
                    cmd.ExecuteNonQuery()
                End Using
                LoadDataKeranjang()
            Catch ex As Exception
                MessageBox.Show("Gagal hapus: " & ex.Message)
            Finally
                DB.CloseConnection()
            End Try
        End If
    End Sub

    Private Sub BtnUpdateJumlah_Click(sender As Object, e As EventArgs) Handles BtnUpdateJumlah.Click
        ' Logika Update Jumlah sama dengan sebelumnya, hanya dirapikan structure-nya
        If PanelDataInfo.CurrentRow Is Nothing Then Return
        Dim qtyBaru = CInt(NumericJumlah.Value)
        Dim idKeranjang = PanelDataInfo.CurrentRow.Cells("IdKeranjang").Value.ToString()
        Dim idBarang = PanelDataInfo.CurrentRow.Cells("IdBarang").Value.ToString()

        Try
            DB.Koneksi()
            ' Cek stok realtime
            Dim stokGudang As Integer = 0
            Dim hargaSatuan As Integer = 0
            Using cmd As New MySqlCommand("SELECT Stock, HargaJual FROM barang WHERE IdBarang = @id", DB.Connection)
                cmd.Parameters.AddWithValue("@id", idBarang)
                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    If rd.Read() Then
                        stokGudang = CInt(rd("Stock"))
                        hargaSatuan = CInt(rd("HargaJual"))
                    End If
                End Using
            End Using

            If qtyBaru > stokGudang Then MessageBox.Show($"Stok tidak cukup. Maksimal: {stokGudang}") : Return

            Using cmd As New MySqlCommand("UPDATE keranjang SET qty = @q, Harga = @h WHERE IdKeranjang = @id", DB.Connection)
                cmd.Parameters.AddWithValue("@q", qtyBaru)
                cmd.Parameters.AddWithValue("@h", qtyBaru * hargaSatuan)
                cmd.Parameters.AddWithValue("@id", idKeranjang)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Jumlah diupdate.")
            LoadDataKeranjang()
        Catch ex As Exception
            MessageBox.Show("Gagal update: " & ex.Message)
        Finally
            DB.CloseConnection()
        End Try
    End Sub

    Private Sub PanelDataInfo_SelectionChanged(sender As Object, e As EventArgs) Handles PanelDataInfo.SelectionChanged
        If isShowingKeranjang AndAlso PanelDataInfo.CurrentRow IsNot Nothing Then
            NumericJumlah.Value = CInt(PanelDataInfo.CurrentRow.Cells("StokAtauJumlah").Value)
        End If
    End Sub

#End Region

#Region "5. Logika Pembayaran (Inti)"

    Private Sub BtnBayar_Click(sender As Object, e As EventArgs) Handles BtnBayar.Click
        If currentTotalBelanja <= 0 Then MessageBox.Show("Keranjang kosong.") : Return

        Dim jumlahBayar As Decimal = 0
        Dim metodeBayar As String = ""
        Dim kembalian As Decimal = 0
        Dim memberId As String = ""
        Dim namaPelanggan As String = ComboBoxPelanggan.Text.Trim()

        ' 1. Validasi Member
        If RadioButtonMemberIya.Checked Then
            If String.IsNullOrEmpty(namaPelanggan) Then MessageBox.Show("Pilih member.") : Return
            memberId = GetMemberAkunId(namaPelanggan)
            If String.IsNullOrEmpty(memberId) Then MessageBox.Show("Member tidak valid.") : Return
        Else
            namaPelanggan = If(String.IsNullOrEmpty(namaPelanggan), "Non-Member", namaPelanggan)
        End If

        ' 2. Validasi Metode Bayar
        If RadioButtonTunai.Checked Then
            metodeBayar = "Tunai"
            jumlahBayar = NumericTunai.Value

            ' Cek 1: Apakah uang pelanggan cukup?
            If jumlahBayar < currentTotalBelanja Then
                MessageBox.Show($"Uang tunai kurang Rp {(currentTotalBelanja - jumlahBayar):N0}", "Pembayaran Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            kembalian = jumlahBayar - currentTotalBelanja

            ' Cek 2: [FITUR BARU] Apakah KASIR punya uang kembalian?
            If kembalian > 0 Then
                ' Menggunakan SessionManager.Cash yang sudah kita buat sebelumnya
                If SessionManager.Cash < kembalian Then
                    MessageBox.Show($"TRANSAKSI DITOLAK!" & vbCrLf & vbCrLf &
                                    $"Kasir tidak memiliki cukup uang tunai untuk kembalian." & vbCrLf &
                                    $"Kembalian diperlukan: Rp {kembalian:N0}" & vbCrLf &
                                    $"Uang di laci kasir: Rp {SessionManager.Cash:N0}" & vbCrLf & vbCrLf &
                                    "Silakan minta uang pas atau lakukan 'Setor/Isi Kas' terlebih dahulu.",
                                    "Kasir Kurang Modal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return ' Batalkan proses
                End If
            End If

        ElseIf RadioButtonEmoney.Checked Then
            metodeBayar = "E-money"
            If Not RadioButtonMemberIya.Checked Then MessageBox.Show("E-money wajib member.") : Return

            Dim saldoMember = GetSaldoPelanggan(namaPelanggan)
            If saldoMember < currentTotalBelanja Then
                MessageBox.Show($"Saldo member tidak cukup. Sisa: Rp {saldoMember:N0}", "Gagal")
                Return
            End If
            jumlahBayar = currentTotalBelanja
            kembalian = 0
        End If

        ' 3. Proses Ke Konfirmasi
        Dim frm As New KonfirmasiBayar(currentTotalBelanja, jumlahBayar, kembalian, namaPelanggan, metodeBayar, memberId)
        If frm.ShowDialog() = DialogResult.OK Then

            ResetForm()

            ' Update Session Cash lokal karena transaksi tunai mungkin menambah uang di laci
            If metodeBayar = "Tunai" Then
                ' (Opsional) Refresh Session cash dari DB jika perlu, 
                ' tapi KonfirmasiBayar biasanya sudah update DB.
                ' Kita update Session manual agar UI Kasir sinkron tanpa relogin:
                SessionManager.AddCash(CInt(currentTotalBelanja))
            End If
        End If
    End Sub

    Private Function GetMemberAkunId(username As String) As String
        Try
            DB.Koneksi()
            Using cmd As New MySqlCommand("SELECT akunID FROM akun WHERE username = @u", DB.Connection)
                cmd.Parameters.AddWithValue("@u", username)
                Dim res = cmd.ExecuteScalar()
                Return If(res IsNot Nothing, res.ToString(), "")
            End Using
        Catch
            Return ""
        Finally
            DB.CloseConnection()
        End Try
    End Function

    Private Function GetSaldoPelanggan(username As String) As Decimal
        Try
            DB.Koneksi()
            Using cmd As New MySqlCommand("SELECT emoney FROM akun WHERE username = @u", DB.Connection)
                cmd.Parameters.AddWithValue("@u", username)
                Dim res = cmd.ExecuteScalar()
                Return If(res IsNot Nothing, Convert.ToDecimal(res), 0)
            End Using
        Catch
            Return 0
        Finally
            DB.CloseConnection()
        End Try
    End Function

    Private Sub ResetForm()
        isShowingKeranjang = False
        UpdatePanelDisplay()
        NumericTunai.Value = 0
        RadioButtonMemberTidak.Checked = True
        RadioButtonTunai.Checked = True
        ComboBoxPelanggan.Text = ""
        TextBoxNama.Text = ""
        TextBoxWarna.Text = ""
        NumericJumlah.Value = 0
    End Sub

    ' UI Event Handlers
    Private Sub RadioButtonMemberIya_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonMemberIya.CheckedChanged
        If RadioButtonMemberIya.Checked Then
            ComboBoxPelanggan.DropDownStyle = ComboBoxStyle.DropDown
            ComboBoxPelanggan.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            ComboBoxPelanggan.AutoCompleteSource = AutoCompleteSource.CustomSource
        End If
    End Sub

    Private Sub RadioButtonMemberTidak_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonMemberTidak.CheckedChanged
        If RadioButtonMemberTidak.Checked Then
            ComboBoxPelanggan.DropDownStyle = ComboBoxStyle.Simple
            ComboBoxPelanggan.AutoCompleteMode = AutoCompleteMode.None
            If RadioButtonEmoney.Checked Then RadioButtonTunai.Checked = True
        End If
    End Sub

    Private Sub RadioButtonTunai_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonTunai.CheckedChanged
        NumericTunai.Visible = RadioButtonTunai.Checked
        LabelTunai.Visible = RadioButtonTunai.Checked
    End Sub

    Private Sub RadioButtonEmoney_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonEmoney.CheckedChanged
        If RadioButtonEmoney.Checked Then
            NumericTunai.Visible = False
            LabelTunai.Visible = False
            If RadioButtonMemberTidak.Checked Then
                MessageBox.Show("Mode E-money membutuhkan Member.")
                RadioButtonMemberIya.Checked = True
            End If
        End If
    End Sub

#End Region

End Class