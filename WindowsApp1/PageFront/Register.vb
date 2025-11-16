Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions ' Import untuk Regex

Public Class Register
    Dim db As New Database() ' Membuat objek dari class Database

    '--- Event untuk menutup aplikasi saat form ditutup
    Private Sub Register_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

#Region "Placeholder Logic"
    '--- Event untuk menangani placeholder pada text box
    Private Sub UsernameText_Enter(sender As Object, e As EventArgs) Handles UsernameText.Enter
        If UsernameText.Text = "Username" Then
            UsernameText.Text = ""
            UsernameText.ForeColor = Color.Black
        End If
    End Sub

    Private Sub EmailText_Enter(sender As Object, e As EventArgs) Handles EmailText.Enter
        If EmailText.Text = "Email" Then
            EmailText.Text = ""
            EmailText.ForeColor = Color.Black
        End If
    End Sub

    Private Sub PasswordText_Enter(sender As Object, e As EventArgs) Handles PasswordText.Enter
        If PasswordText.Text = "Password" Then
            PasswordText.Text = ""
            PasswordText.ForeColor = Color.Black
            PasswordText.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub UsernameText_Leave(sender As Object, e As EventArgs) Handles UsernameText.Leave
        If String.IsNullOrWhiteSpace(UsernameText.Text) Then
            UsernameText.Text = "Username"
            UsernameText.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub EmailText_Leave(sender As Object, e As EventArgs) Handles EmailText.Leave
        If String.IsNullOrWhiteSpace(EmailText.Text) Then
            EmailText.Text = "Email"
            EmailText.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub PasswordText_Leave(sender As Object, e As EventArgs) Handles PasswordText.Leave
        If String.IsNullOrWhiteSpace(PasswordText.Text) Then
            PasswordText.Text = "Password"
            PasswordText.ForeColor = Color.Gray
            PasswordText.UseSystemPasswordChar = False
        End If
    End Sub
#End Region

    ''' <summary>
    ''' **[PERBAIKAN]** Fungsi ini harus memeriksa keunikan di database
    ''' untuk menghindari kegagalan 'INSERT' jika ID hasil acak sudah ada.
    ''' </summary>
    Private Function GenerateUniqueAkunID(conn As MySqlConnection) As String
        Dim rand As New Random()
        Dim akunID As String
        Dim isUnique As Boolean = False

        Do
            akunID = "akun" & rand.Next(10000, 1000000).ToString()
            ' Cek ke database apakah ID ini sudah ada
            Dim query As String = "SELECT COUNT(*) FROM akun WHERE akunID = @akunID"
            Using cmdCheck As New MySqlCommand(query, conn)
                cmdCheck.Parameters.AddWithValue("@akunID", akunID)
                Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
                If count = 0 Then
                    isUnique = True ' ID unik, keluar dari loop
                End If
            End Using
        Loop While Not isUnique

        Return akunID
    End Function

    ''' <summary>
    ''' **[PERBAIKAN]** Fungsi ini sekarang menerima koneksi yang sudah terbuka.
    ''' </summary>
    Private Function IsUsernameExists(username As String, conn As MySqlConnection) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM akun WHERE username = @username"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", username)
            Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return result > 0
        End Using
    End Function

    ''' <summary>
    ''' **[PERBAIKAN]** Fungsi ini sekarang menerima koneksi yang sudah terbuka.
    ''' </summary>
    Private Function IsEmailExists(email As String, conn As MySqlConnection) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM akun WHERE email = @email"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@email", email)
            Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return result > 0
        End Using
    End Function

    ''' <summary>
    ''' **[PERBAIKAN]** Fungsi ini sekarang menerima koneksi untuk memeriksa duplikat.
    ''' </summary>
    Private Function ValidateInput(username As String, password As String, email As String, conn As MySqlConnection) As Boolean
        If username.Length < 4 OrElse username.Length > 12 Then
            MessageBox.Show("Username harus antara 4 hingga 12 karakter.") : Return False
        End If
        If password.Length < 8 OrElse password.Length > 15 Then
            MessageBox.Show("Password harus antara 8 hingga 15 karakter.") : Return False
        End If
        If Not IsValidEmail(email) Then
            MessageBox.Show("Email tidak valid.") : Return False
        End If

        ' **[PERBAIKAN]** Pengecekan duplikat sekarang menggunakan koneksi yang ada
        If IsUsernameExists(username, conn) Then
            MessageBox.Show("Username sudah ada. Silakan pilih username yang lain.") : Return False
        End If
        If IsEmailExists(email, conn) Then
            MessageBox.Show("Email sudah terdaftar. Silakan pilih email yang lain.") : Return False
        End If

        Return True
    End Function

    '--- Fungsi untuk memvalidasi email menggunakan regex
    Private Function IsValidEmail(email As String) As Boolean
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        ' Tidak perlu membuat objek Regex baru setiap kali, gunakan IsMatch statis
        Return Regex.IsMatch(email, emailPattern)
    End Function

    '--- Fungsi untuk mengenkripsi password menggunakan SHA-256
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

    '--- Event ketika tombol register ditekan
    Private Sub registerBtn_Click(sender As Object, e As EventArgs) Handles registerBtn.Click
        Dim username As String = UsernameText.Text.Trim()
        Dim password As String = PasswordText.Text.Trim()
        Dim email As String = EmailText.Text.Trim()

        ' Validasi placeholder
        If username = "Username" OrElse email = "Email" OrElse password = "Password" Then
            MessageBox.Show("Semua field harus diisi dengan benar.", "Input Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' **[PERBAIKAN]** Buka koneksi HANYA SEKALI di dalam blok Try
            db.Koneksi()
            Dim conn As MySqlConnection = db.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi ke database gagal dibuka.")

            ' **[PERBAIKAN]** Validasi input SETELAH koneksi terbuka
            If Not ValidateInput(username, password, email, conn) Then
                ' Pesan error sudah ditampilkan di dalam ValidateInput
                db.CloseConnection() ' Tutup koneksi jika validasi gagal
                Return
            End If

            Dim encryptedPassword As String = EncryptPassword(password)

            ' **[PERBAIKAN]** Generate AkunID unik menggunakan koneksi yang terbuka
            Dim akunID As String = GenerateUniqueAkunID(conn)

            ' Menambahkan data ke database
            ' **[PERBAIKAN]** Menggunakan kolom 'emoney' sesuai struktur tabel terakhir
            Dim query As String = "INSERT INTO akun (akunID, username, password, email, role, emoney) VALUES (@akunID, @username, @password, @email, @role, @emoney)"
            Using cm As New MySqlCommand(query, conn)
                cm.Parameters.AddWithValue("@akunID", akunID)
                cm.Parameters.AddWithValue("@username", username)
                cm.Parameters.AddWithValue("@password", encryptedPassword)
                cm.Parameters.AddWithValue("@email", email)
                cm.Parameters.AddWithValue("@role", "user") ' Default role
                cm.Parameters.AddWithValue("@emoney", 0) ' Default saldo 0

                cm.ExecuteNonQuery()
            End Using ' 'cm' di-dispose di sini

            MessageBox.Show("Registrasi berhasil!")

            ' Arahkan ke form Welcome
            Dim welcomeForm As New Welcome()
            welcomeForm.Show()
            Me.Hide() ' Sembunyikan form Register

        Catch ex As Exception
            ' Tangkap semua jenis error (MySQL atau lainnya)
            MessageBox.Show("Error saat registrasi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' **[PERBAIKAN]** Pastikan koneksi SELALU ditutup, baik sukses maupun gagal
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set placeholder untuk Username, Email, Password pada form load
        UsernameText_Leave(UsernameText, EventArgs.Empty)
        EmailText_Leave(EmailText, EventArgs.Empty)
        PasswordText_Leave(PasswordText, EventArgs.Empty)
    End Sub

    Private Sub kembaliBtn_Click(sender As Object, e As EventArgs) Handles kembaliBtn.Click
        ' Arahkan ke form Welcome
        Dim kembaliForm As New Welcome()
        kembaliForm.Show()
        Me.Hide()
    End Sub
End Class