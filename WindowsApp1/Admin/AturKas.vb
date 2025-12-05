Imports MySql.Data.MySqlClient

Public Class AturKas
    Private DB As New Database()

    ' Enum untuk melacak Mode saat ini
    Private Enum ModeKas
        Kirim
        Tarik
        Deposit
    End Enum

    Private CurrentMode As ModeKas = ModeKas.Kirim

    ' --- 1. Event Load & Setup ---
    Private Sub AturKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDaftarPegawai()

        ' Default Setting
        RadioButtonTunai.Checked = True
        SetMode(ModeKas.Kirim)
    End Sub

    Private Sub AturKas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Hide()
    End Sub

    ' --- 2. Load Data Pegawai (AutoComplete) ---
    Private Sub LoadDaftarPegawai()
        Dim coll As New AutoCompleteStringCollection()
        Try
            DB.Koneksi()
            ' Ambil semua Admin dan Staff (kecuali diri sendiri jika perlu, tapi disini kita load semua)
            Dim query As String = "SELECT username FROM akun WHERE role IN ('admin', 'staff')"
            Using cmd As New MySqlCommand(query, DB.Connection)
                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        ComboBoxNamaPegawai.Items.Add(rd("username").ToString())
                        coll.Add(rd("username").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data pegawai: " & ex.Message)
        Finally
            DB.CloseConnection()
        End Try

        ComboBoxNamaPegawai.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxNamaPegawai.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxNamaPegawai.AutoCompleteCustomSource = coll
    End Sub

    ' --- 3. Logika Switch Mode (BtnAturKas) ---
    Private Sub BtnAturKas_Click(sender As Object, e As EventArgs) Handles BtnAturKas.Click
        ' Rotasi Mode: Kirim -> Tarik -> Deposit -> Balik ke Kirim
        Select Case CurrentMode
            Case ModeKas.Kirim
                SetMode(ModeKas.Tarik)
            Case ModeKas.Tarik
                SetMode(ModeKas.Deposit)
            Case ModeKas.Deposit
                SetMode(ModeKas.Kirim)
        End Select
    End Sub

    Private Sub SetMode(mode As ModeKas)
        CurrentMode = mode

        ' Reset Input
        NumericNominal.Value = 0
        ComboBoxNamaPegawai.Text = ""

        ' Atur UI berdasarkan Mode
        Select Case mode
            Case ModeKas.Kirim
                LabelAturKas.Text = "KIRIM KAS (Toko -> Pegawai)"
                LabelAturKas.ForeColor = Color.Blue
                ComboBoxNamaPegawai.Enabled = True

                BtnKirimKas.Visible = True
                BtnTarikKas.Visible = False
                BtnDepositKas.Visible = False

            Case ModeKas.Tarik
                LabelAturKas.Text = "TARIK KAS (Pegawai -> Toko)"
                LabelAturKas.ForeColor = Color.Red
                ComboBoxNamaPegawai.Enabled = True

                BtnKirimKas.Visible = False
                BtnTarikKas.Visible = True
                BtnDepositKas.Visible = False

            Case ModeKas.Deposit
                LabelAturKas.Text = "DEPOSIT KAS (Luar -> Toko)"
                LabelAturKas.ForeColor = Color.Green
                ComboBoxNamaPegawai.Enabled = False ' Deposit tidak butuh target pegawai
                ComboBoxNamaPegawai.Text = "-"

                BtnKirimKas.Visible = False
                BtnTarikKas.Visible = False
                BtnDepositKas.Visible = True
        End Select
    End Sub

    ' --- 4. Eksekusi: KIRIM KAS (Toko -> Pegawai) ---
    Private Sub BtnKirimKas_Click(sender As Object, e As EventArgs) Handles BtnKirimKas.Click
        If Not ValidateInput() Then Return

        Dim nominal As Integer = CInt(NumericNominal.Value)
        Dim targetUser As String = ComboBoxNamaPegawai.Text
        Dim isTunai As Boolean = RadioButtonTunai.Checked

        ' Tentukan Kolom Database
        Dim colToko As String = If(isTunai, "saldo_cash", "saldo_bank")
        Dim colStaff As String = If(isTunai, "cash", "emoney")
        Dim tipeUang As String = If(isTunai, "Tunai (Cash)", "Bank (E-money)")

        ' Cek Saldo Toko Dulu
        If GetSaldoToko(colToko) < nominal Then
            MessageBox.Show($"Saldo {tipeUang} Toko tidak mencukupi untuk dikirim.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"Kirim {tipeUang} sebesar Rp {nominal:N0} ke {targetUser}?", "Konfirmasi Kirim", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            ExecuteTransaction(
                $"UPDATE ekonomi SET {colToko} = {colToko} - @nom WHERE id_utama = 'UTAMA'",
                $"UPDATE akun SET {colStaff} = {colStaff} + @nom WHERE username = @user",
                "KIRIM KAS", nominal, targetUser, isTunai
            )
        End If
    End Sub

    ' --- 5. Eksekusi: TARIK KAS (Pegawai -> Toko) ---
    Private Sub BtnTarikKas_Click(sender As Object, e As EventArgs) Handles BtnTarikKas.Click
        If Not ValidateInput() Then Return

        Dim nominal As Integer = CInt(NumericNominal.Value)
        Dim targetUser As String = ComboBoxNamaPegawai.Text
        Dim isTunai As Boolean = RadioButtonTunai.Checked

        Dim colToko As String = If(isTunai, "saldo_cash", "saldo_bank")
        Dim colStaff As String = If(isTunai, "cash", "emoney")
        Dim tipeUang As String = If(isTunai, "Tunai (Cash)", "Bank (E-money)")

        ' Cek Saldo Pegawai Dulu
        If GetSaldoPegawai(targetUser, colStaff) < nominal Then
            MessageBox.Show($"Saldo {tipeUang} pada pegawai {targetUser} tidak mencukupi untuk ditarik.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"Tarik {tipeUang} sebesar Rp {nominal:N0} dari {targetUser} ke Toko?", "Konfirmasi Tarik", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            ExecuteTransaction(
                $"UPDATE ekonomi SET {colToko} = {colToko} + @nom WHERE id_utama = 'UTAMA'",
                $"UPDATE akun SET {colStaff} = {colStaff} - @nom WHERE username = @user",
                "TARIK KAS", nominal, targetUser, isTunai
            )
        End If
    End Sub

    ' --- 6. Eksekusi: DEPOSIT KAS (Eksternal -> Toko) ---
    Private Sub BtnDepositKas_Click(sender As Object, e As EventArgs) Handles BtnDepositKas.Click
        If NumericNominal.Value <= 0 Then MessageBox.Show("Nominal harus > 0") : Return

        Dim nominal As Integer = CInt(NumericNominal.Value)
        Dim isTunai As Boolean = RadioButtonTunai.Checked
        Dim colToko As String = If(isTunai, "saldo_cash", "saldo_bank")
        Dim tipeUang As String = If(isTunai, "Tunai", "Bank")

        If MessageBox.Show($"Depositkan modal {tipeUang} Rp {nominal:N0} ke Kas Toko?", "Konfirmasi Deposit", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            ' Deposit hanya update tabel ekonomi (tambah)
            ExecuteTransaction(
                $"UPDATE ekonomi SET {colToko} = {colToko} + @nom WHERE id_utama = 'UTAMA'",
                "", ' Tidak ada update ke akun pegawai
                "DEPOSIT KAS", nominal, "SYSTEM", isTunai
            )
        End If
    End Sub

    ' --- HELPER FUNCTIONS ---

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(ComboBoxNamaPegawai.Text) Then
            MessageBox.Show("Pilih nama pegawai.", "Validasi") : Return False
        End If
        If NumericNominal.Value <= 0 Then
            MessageBox.Show("Nominal harus lebih dari 0.", "Validasi") : Return False
        End If
        Return True
    End Function

    Private Function GetSaldoToko(columnName As String) As Decimal
        Try
            DB.Koneksi()
            Using cmd As New MySqlCommand($"SELECT {columnName} FROM ekonomi WHERE id_utama = 'UTAMA'", DB.Connection)
                Dim res = cmd.ExecuteScalar()
                Return If(res IsNot Nothing, Convert.ToDecimal(res), 0)
            End Using
        Catch
            Return 0
        Finally
            DB.CloseConnection()
        End Try
    End Function

    Private Function GetSaldoPegawai(username As String, columnName As String) As Decimal
        Try
            DB.Koneksi()
            Using cmd As New MySqlCommand($"SELECT {columnName} FROM akun WHERE username = @u", DB.Connection)
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

    ''' <summary>
    ''' Fungsi Transaksi Generic untuk menangani Kirim/Tarik/Deposit
    ''' </summary>
    Private Sub ExecuteTransaction(queryEkonomi As String, queryAkun As String, jenisTrans As String, nominal As Integer, targetUser As String, isTunai As Boolean)
        Dim conn As MySqlConnection
        Dim trans As MySqlTransaction = Nothing

        Try
            DB.Koneksi()
            conn = DB.Connection
            trans = conn.BeginTransaction()

            ' 1. Update Ekonomi
            Using cmd As New MySqlCommand(queryEkonomi, conn, trans)
                cmd.Parameters.AddWithValue("@nom", nominal)
                cmd.ExecuteNonQuery()
            End Using

            ' 2. Update Akun (Jika bukan Deposit)
            If Not String.IsNullOrEmpty(queryAkun) Then
                Using cmd As New MySqlCommand(queryAkun, conn, trans)
                    cmd.Parameters.AddWithValue("@nom", nominal)
                    cmd.Parameters.AddWithValue("@user", targetUser)
                    cmd.ExecuteNonQuery()
                End Using
            End If

            ' 3. Catat Jurnal
            Dim metode As String = If(isTunai, "CASH", "BANK")
            Dim ket As String = $"{jenisTrans} - Target: {targetUser}"
            Dim idJurnal As String = "JRNL-" & DateTime.Now.ToString("yyyyMMddHHmmss")

            Dim qJurnal As String = "INSERT INTO jurnal_keuangan (id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff) VALUES (@id, @jenis, @nom, 'PINDAH', @metode, @ket, @staff)"
            Using cmd As New MySqlCommand(qJurnal, conn, trans)
                cmd.Parameters.AddWithValue("@id", idJurnal)
                cmd.Parameters.AddWithValue("@jenis", jenisTrans)
                cmd.Parameters.AddWithValue("@nom", nominal)
                cmd.Parameters.AddWithValue("@metode", metode)
                cmd.Parameters.AddWithValue("@ket", ket)
                cmd.Parameters.AddWithValue("@staff", SessionManager.AkunID) ' Admin yg melakukan aksi
                cmd.ExecuteNonQuery()
            End Using

            trans.Commit()
            MessageBox.Show("Transaksi Berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reset UI
            NumericNominal.Value = 0

        Catch ex As Exception
            Try : trans?.Rollback() : Catch : End Try
            MessageBox.Show("Transaksi Gagal: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB.CloseConnection()
        End Try
    End Sub


End Class