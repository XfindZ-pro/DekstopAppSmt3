Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class IsiSaldo

    Private DB As New Database()
    Private Cmd As MySqlCommand
    Private Rd As MySqlDataReader

    ' Variabel status untuk tombol Bayar/Konfirmasi
    Private isConfirming As Boolean = False
    ' Variabel untuk menyimpan username member yang dipilih
    Private selectedMemberUsername As String = ""

#Region "Form Load & Setup"

    Private Sub IsiSaldo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadMemberAutoComplete()
            PictureBoxPembayaran.Visible = False ' Sembunyikan QR di awal
            ' Atur status default form
            RadioButtonQris.Checked = False
            ComboBoxNama.DropDownStyle = ComboBoxStyle.DropDown
            ComboBoxNama.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            ComboBoxNama.AutoCompleteSource = AutoCompleteSource.CustomSource
            BtnBayar.Text = "Bayar" ' Teks tombol awal
            isConfirming = False
        Catch ex As Exception
            MessageBox.Show("Error saat memuat form: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Memuat username member untuk AutoComplete
    Private Sub LoadMemberAutoComplete()
        Dim autoCompleteCollection As New AutoCompleteStringCollection()
        Try
            DB.Koneksi()
            Dim query As String = "SELECT username FROM akun WHERE role = 'user' OR role = 'staff'"
            Cmd = New MySqlCommand(query, DB.Connection)
            Rd = Cmd.ExecuteReader()
            While Rd.Read()
                autoCompleteCollection.Add(Rd("username").ToString())
            End While
        Catch ex As Exception
            MessageBox.Show("Gagal memuat daftar member: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Rd IsNot Nothing AndAlso Not Rd.IsClosed Then Rd.Close()
            If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then
                DB.CloseConnection()
            End If
        End Try
        ' Terapkan koleksi ke ComboBox
        ComboBoxNama.AutoCompleteCustomSource = autoCompleteCollection
    End Sub

#End Region

#Region "Form Navigation & Closing"

    ' Jangan keluar dari seluruh aplikasi saat form ini ditutup
    Private Sub IsiSaldo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    ' Tombol untuk kembali ke Dashboard
    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        If isConfirming Then
            ResetForm() ' Batalkan mode konfirmasi jika ada
        End If
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Hide() ' Sembunyikan form ini
    End Sub

#End Region

#Region "Input Handling & Payment Logic"

    ' Event untuk ComboBox (bisa dibiarkan kosong)
    Private Sub ComboBoxNama_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxNama.SelectedIndexChanged
    End Sub

    ' Event untuk NumericUpDown (bisa dibiarkan kosong)
    Private Sub NumericIsiSaldo_ValueChanged(sender As Object, e As EventArgs) Handles NumericIsiSaldo.ValueChanged
    End Sub

    ' Menampilkan/Sembunyikan QR Code saat RadioButton Qris berubah
    Private Sub RadioButtonQris_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonQris.CheckedChanged
        If RadioButtonQris.Checked Then
            PictureBoxPembayaran.Visible = True
        Else
            PictureBoxPembayaran.Visible = False
        End If
    End Sub

    ' Logika 2 langkah untuk tombol Bayar/Konfirmasi
    Private Sub BtnBayar_Click(sender As Object, e As EventArgs) Handles BtnBayar.Click
        Dim amount As Decimal = NumericIsiSaldo.Value
        Dim memberUsername As String = ComboBoxNama.Text.Trim()

        If isConfirming Then
            ' --- TAHAP 2: KONFIRMASI ---
            memberUsername = Me.selectedMemberUsername ' Gunakan username yang sudah divalidasi

            If String.IsNullOrWhiteSpace(memberUsername) OrElse amount <= 0 Then
                MessageBox.Show("Data tidak valid untuk konfirmasi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ResetForm()
                Return
            End If

            Dim conn As MySqlConnection = Nothing
            Dim sqlTransaction As MySqlTransaction = Nothing

            Try
                DB.Koneksi()
                conn = DB.Connection
                If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi Gagal.")
                sqlTransaction = conn.BeginTransaction()

                ' 1. Tambah saldo E-MONEY ke Member
                Dim queryUpdateMember As String = "UPDATE akun SET emoney = emoney + @amount WHERE username = @username"
                Using cmdMember As New MySqlCommand(queryUpdateMember, conn, sqlTransaction)
                    cmdMember.Parameters.AddWithValue("@amount", amount)
                    cmdMember.Parameters.AddWithValue("@username", memberUsername)
                    If cmdMember.ExecuteNonQuery() = 0 Then
                        Throw New Exception($"Gagal update saldo emoney member '{memberUsername}'.")
                    End If
                End Using

                ' 2. Tambah saldo_bank dan total_pemasukkan di tabel EKONOMI
                Dim queryUpdateEkonomi As String = "UPDATE ekonomi SET saldo_bank = saldo_bank + @amount, total_pemasukkan = total_pemasukkan + @amount WHERE id_utama = 'UTAMA'"
                Using cmdEkonomi As New MySqlCommand(queryUpdateEkonomi, conn, sqlTransaction)
                    cmdEkonomi.Parameters.AddWithValue("@amount", amount)
                    If cmdEkonomi.ExecuteNonQuery() = 0 Then
                        Throw New Exception("Gagal update tabel ekonomi. Pastikan ID 'UTAMA' ada.")
                    End If
                End Using

                ' 3. **[PERBAIKAN]** Catat ke JURNAL KEUANGAN sesuai struktur tabel baru
                ' Kolom: id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff
                Dim idJurnal As String = "JRNL-" & DateTime.Now.ToString("yyyyMMddHHmmss")
                Dim queryJurnal As String = "INSERT INTO jurnal_keuangan (id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff) " &
                                            "VALUES (@idJurnal, @jenis, @nominal, @TipeAliran, @MetodeBayar, @keterangan, @akunIdStaff)"
                Using cmdJurnal As New MySqlCommand(queryJurnal, conn, sqlTransaction)
                    cmdJurnal.Parameters.AddWithValue("@idJurnal", idJurnal)
                    cmdJurnal.Parameters.AddWithValue("@jenis", "ISI SALDO") ' Jenis transaksi
                    cmdJurnal.Parameters.AddWithValue("@nominal", amount) ' Nominal positif (pemasukan)
                    cmdJurnal.Parameters.AddWithValue("@TipeAliran", "MASUK") ' Tipe Aliran
                    cmdJurnal.Parameters.AddWithValue("@MetodeBayar", "QRIS") ' Metode Bayar
                    cmdJurnal.Parameters.AddWithValue("@keterangan", $"Isi saldo untuk member: {memberUsername}")
                    cmdJurnal.Parameters.AddWithValue("@akunIdStaff", SessionManager.AkunID)
                    If cmdJurnal.ExecuteNonQuery() = 0 Then
                        Throw New Exception("Gagal mencatat transaksi di jurnal keuangan.")
                    End If
                End Using

                ' Commit transaksi
                sqlTransaction.Commit()
                MessageBox.Show($"Saldo E-money Rp. {amount.ToString("N0")} berhasil ditambahkan ke '{memberUsername}'.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ResetForm()

            Catch ex As Exception
                Try : sqlTransaction?.Rollback() : Catch : End Try
                MessageBox.Show("Gagal melakukan isi saldo: " & ex.Message, "Error Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ResetForm()
            Finally
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    DB.CloseConnection()
                End If
            End Try

        Else
            ' --- TAHAP 1: BAYAR (Validasi Awal) ---
            If String.IsNullOrWhiteSpace(memberUsername) Then
                MessageBox.Show("Masukkan atau pilih Nama Member.", "Input Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ComboBoxNama.Focus()
                Return
            End If

            If amount <= 0 Then
                MessageBox.Show("Jumlah isi saldo harus lebih dari 0.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                NumericIsiSaldo.Focus()
                Return
            End If

            If Not RadioButtonQris.Checked Then
                MessageBox.Show("Pilih metode pembayaran (Qris).", "Input Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validasi apakah member ada di database
            Dim memberExists As Boolean = False
            Try
                DB.Koneksi()
                Dim checkQuery As String = "SELECT COUNT(*) FROM akun WHERE username = @username"
                Cmd = New MySqlCommand(checkQuery, DB.Connection)
                Cmd.Parameters.AddWithValue("@username", memberUsername)
                If CInt(Cmd.ExecuteScalar()) > 0 Then memberExists = True
            Catch ex As Exception
                MessageBox.Show("Error saat validasi member: " & ex.Message)
                Return
            Finally
                If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then DB.CloseConnection()
            End Try

            If Not memberExists Then
                MessageBox.Show($"Member dengan username '{memberUsername}' tidak ditemukan.", "Member Tidak Ada", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' --- Semua Validasi Lolos ---
            Me.selectedMemberUsername = memberUsername ' Simpan username yang valid
            isConfirming = True
            BtnBayar.Text = "Konfirmasi"
            ' Nonaktifkan input
            ComboBoxNama.Enabled = False
            NumericIsiSaldo.Enabled = False
            RadioButtonQris.Enabled = False
        End If
    End Sub

    ' Fungsi helper untuk mengembalikan form ke status awal
    Private Sub ResetForm()
        isConfirming = False
        selectedMemberUsername = ""
        BtnBayar.Text = "Bayar"
        ComboBoxNama.Text = ""
        NumericIsiSaldo.Value = 0
        RadioButtonQris.Checked = False
        ' Aktifkan kembali input
        ComboBoxNama.Enabled = True
        NumericIsiSaldo.Enabled = True
        RadioButtonQris.Enabled = True
    End Sub

#End Region

#Region "Unused Event Handlers"

    Private Sub PictureBoxPembayaran_Click(sender As Object, e As EventArgs) Handles PictureBoxPembayaran.Click
        ' Event ini ada, bisa diisi nanti jika perlu
    End Sub

#End Region

End Class