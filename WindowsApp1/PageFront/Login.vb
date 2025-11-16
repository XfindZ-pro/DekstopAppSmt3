Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Login
    Dim db As New Database() ' Objek untuk koneksi database

    Private Sub Login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit() ' Ini yang menghentikan aplikasi sepenuhnya
    End Sub

    ' ----------- Event untuk menangani placeholder pada UsernameText dan PasswordText
    Private Sub UsernameText_Enter(sender As Object, e As EventArgs) Handles UsernameText.Enter
        If UsernameText.Text = "Username" Then
            UsernameText.Text = ""
            UsernameText.ForeColor = Color.Black ' Teks kembali normal
        End If
    End Sub

    Private Sub PasswordText_Enter(sender As Object, e As EventArgs) Handles PasswordText.Enter
        If PasswordText.Text = "Password" Then
            PasswordText.Text = ""
            PasswordText.ForeColor = Color.Black ' Teks kembali normal
            PasswordText.UseSystemPasswordChar = True ' Menampilkan karakter password (●)
        End If
    End Sub

    Private Sub UsernameText_Leave(sender As Object, e As EventArgs) Handles UsernameText.Leave
        If UsernameText.Text = "" Then
            UsernameText.Text = "Username"
            UsernameText.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub PasswordText_Leave(sender As Object, e As EventArgs) Handles PasswordText.Leave
        If PasswordText.Text = "" Then
            PasswordText.Text = "Password"
            PasswordText.ForeColor = Color.Gray
            PasswordText.UseSystemPasswordChar = False
        End If
    End Sub

    ' Fungsi untuk mengenkripsi password menggunakan SHA-256
    Private Function EncryptPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ' Event ketika tombol login ditekan
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        ' Ambil nilai username dan password dari TextBox
        Dim username As String = UsernameText.Text.Trim()
        Dim password As String = PasswordText.Text.Trim()

        ' Validasi input (pastikan username dan password tidak kosong)
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) OrElse username = "Username" OrElse password = "Password" Then
            MessageBox.Show("Username dan Password harus diisi!")
            Return
        End If

        ' Koneksi ke database
        db.Koneksi()

        ' Enkripsi password yang dimasukkan
        Dim encryptedPassword As String = EncryptPassword(password)

        ' **[PERBAIKAN]** Mengganti 'money' menjadi 'emoney'
        Dim query As String = "SELECT akunID, username, email, role, emoney FROM akun WHERE username = @username AND password = @password"
        Dim cm As New MySqlCommand(query, db.Connection)
        cm.Parameters.AddWithValue("@username", username)
        cm.Parameters.AddWithValue("@password", encryptedPassword) ' Membandingkan dengan password terenkripsi

        ' Mengeksekusi query dan mendapatkan hasil
        Dim reader As MySqlDataReader = Nothing ' Inisialisasi
        Try
            reader = cm.ExecuteReader()

            If reader.HasRows Then
                ' Jika ditemukan data login yang cocok
                reader.Read() ' Membaca data pertama

                ' **[PERBAIKAN]** Ambil nilai emoney dari database
                Dim userEmoney As Integer = 0
                If Not IsDBNull(reader("emoney")) Then
                    userEmoney = Convert.ToInt32(reader("emoney"))
                End If

                ' **[PERBAIKAN]** Menyimpan data login ke SessionManager dengan emoney
                ' (Asumsi SessionManager.SetSession masih menerima parameter ke-5 untuk saldo)
                SessionManager.SetSession(
                    reader("akunID").ToString(),
                    reader("username").ToString(),
                    reader("email").ToString(),
                    reader("role").ToString(),
                    userEmoney
                )

                reader.Close()

                ' Arahkan ke form Dashboard
                Dim dashboardForm As New Dashboard()
                dashboardForm.Show()

                ' Menutup form Login
                Me.Hide()
            Else
                ' Jika username atau password salah
                MessageBox.Show("Username atau Password salah!")
                reader.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi error saat login: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then
                reader.Close()
            End If
        Finally
            ' Tutup koneksi
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ' Event ketika teks berubah di LoginText (untuk validasi atau lainnya)
    Private Sub LoginText_TextChanged(sender As Object, e As EventArgs) Handles UsernameText.TextChanged
        ' Validasi atau logika lain jika diperlukan
    End Sub

    ' Event ketika teks berubah di PasswordText (untuk validasi atau lainnya)
    Private Sub PasswordText_TextChanged(sender As Object, e As EventArgs) Handles PasswordText.TextChanged
        ' Validasi atau logika lain jika diperlukan
    End Sub

    Private Sub kembaliBtn_Click(sender As Object, e As EventArgs) Handles kembaliBtn.Click
        ' Arahkan ke form Welcome
        Dim kembaliForm As New Welcome()
        kembaliForm.Show()
        Me.Hide() ' Menyembunyikan form Login
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inisialisasi placeholder
        UsernameText_Leave(UsernameText, EventArgs.Empty)
        PasswordText_Leave(PasswordText, EventArgs.Empty)
    End Sub

    ' Event untuk tombol Enter (opsional - untuk UX yang lebih baik)
    Private Sub UsernameText_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UsernameText.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            PasswordText.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub PasswordText_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PasswordText.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LoginBtn.PerformClick()
            e.Handled = True
        End If
    End Sub
End Class