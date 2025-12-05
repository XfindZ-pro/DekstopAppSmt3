Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Register
    Private db As New Database()

    '--- 1. Event Lifecycle & Navigasi ---
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPlaceholderDefaults()
    End Sub

    Private Sub Register_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub KembaliBtn_Click(sender As Object, e As EventArgs) Handles KembaliBtn.Click
        Dim welcomeForm As New Welcome()
        welcomeForm.Show()
        Me.Hide()
    End Sub

    '--- 2. Logic Utama (Tombol Register) ---
    Private Sub RegisterBtn_Click(sender As Object, e As EventArgs) Handles RegisterBtn.Click
        ' Bersihkan input dari spasi berlebih
        Dim username As String = UsernameText.Text.Trim()
        Dim password As String = PasswordText.Text.Trim()
        Dim email As String = EmailText.Text.Trim()

        ' A. Validasi Format (Tanpa Koneksi Database untuk efisiensi)
        ' Cek apakah masih default/kosong
        If IsPlaceholderOrEmpty(username, "Username") OrElse
           IsPlaceholderOrEmpty(email, "Email") OrElse
           IsPlaceholderOrEmpty(password, "Password") Then
            MessageBox.Show("Mohon lengkapi semua data pendaftaran.", "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Cek aturan penulisan (Regex & Panjang karakter)
        If Not IsValidFormat(username, password, email) Then Return

        ' B. Proses Database (Cek Duplikat & Insert)
        Try
            db.Koneksi()
            Dim conn As MySqlConnection = db.Connection

            ' Pastikan koneksi terbuka
            If conn.State <> ConnectionState.Open Then Throw New Exception("Gagal terhubung ke server database.")

            ' Cek Duplikat di Database
            If IsDataExists(conn, "username", username) Then
                MessageBox.Show("Username ini sudah terpakai. Silakan pilih yang lain.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If IsDataExists(conn, "email", email) Then
                MessageBox.Show("Email ini sudah terdaftar. Silakan gunakan email lain.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Persiapan Data
            Dim encryptedPass As String = EncryptPassword(password)
            Dim newID As String = GenerateUniqueAkunID(conn)

            ' [UPDATE] Eksekusi Query Insert dengan kolom 'cash'
            Dim query As String = "INSERT INTO akun (akunID, username, password, email, role, emoney, cash) VALUES (@id, @user, @pass, @email, 'user', @emoney, @cash)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", newID)
                cmd.Parameters.AddWithValue("@user", username)
                cmd.Parameters.AddWithValue("@pass", encryptedPass)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@emoney", 0) ' Default Saldo Digital 0
                cmd.Parameters.AddWithValue("@cash", 0)   ' [BARU] Default Uang Tunai 0
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Registrasi berhasil! Silakan login dengan akun baru Anda.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Pindah ke halaman Welcome
            Dim welcomeForm As New Welcome()
            welcomeForm.Show()
            Me.Hide()

        Catch ex As MySqlException
            ' Error khusus database (Koneksi putus, Syntax error, dll)
            MessageBox.Show("Terjadi kesalahan database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Error umum aplikasi
            MessageBox.Show("Terjadi kesalahan sistem: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Pastikan koneksi selalu tertutup
            db.CloseConnection()
        End Try
    End Sub

    '--- 3. Helper Functions (Validasi & Database) ---

    ' Cek Format Input (Regex & Length)
    Private Function IsValidFormat(user As String, pass As String, email As String) As Boolean
        If user.Length < 4 OrElse user.Length > 12 Then
            MessageBox.Show("Username harus terdiri dari 4 - 12 karakter.", "Format Salah", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return False
        End If

        If pass.Length < 8 OrElse pass.Length > 15 Then
            MessageBox.Show("Password harus terdiri dari 8 - 15 karakter.", "Format Salah", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return False
        End If

        ' Regex Email Sederhana
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        If Not Regex.IsMatch(email, emailPattern) Then
            MessageBox.Show("Format email tidak valid (contoh: user@mail.com).", "Format Salah", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return False
        End If

        Return True
    End Function

    ' Cek apakah data sudah ada di database (Reusable untuk Username & Email)
    Private Function IsDataExists(conn As MySqlConnection, columnName As String, value As String) As Boolean
        Dim query As String = $"SELECT COUNT(1) FROM akun WHERE {columnName} = @val LIMIT 1"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@val", value)
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    ' Generate ID Unik (akunXXXXXX)
    Private Function GenerateUniqueAkunID(conn As MySqlConnection) As String
        Dim rand As New Random()
        Dim newID As String
        Do
            newID = "akun" & rand.Next(10000, 1000000).ToString()
        Loop While IsDataExists(conn, "akunID", newID) ' Loop jika ID kebetulan kembar
        Return newID
    End Function

    ' Enkripsi Password (SHA-256)
    Private Function EncryptPassword(text As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(text))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ' Helper untuk cek placeholder
    Private Function IsPlaceholderOrEmpty(text As String, placeholder As String) As Boolean
        Return String.IsNullOrWhiteSpace(text) OrElse text = placeholder
    End Function

    '--- 4. UI Logic (Placeholder Handling) ---

    Private Sub SetPlaceholderDefaults()
        UsernameText_Leave(UsernameText, EventArgs.Empty)
        EmailText_Leave(EmailText, EventArgs.Empty)
        PasswordText_Leave(PasswordText, EventArgs.Empty)
    End Sub

    ' -- Username --
    Private Sub UsernameText_Enter(sender As Object, e As EventArgs) Handles UsernameText.Enter
        If UsernameText.Text = "Username" Then UsernameText.Text = "" : UsernameText.ForeColor = Color.Black
    End Sub
    Private Sub UsernameText_Leave(sender As Object, e As EventArgs) Handles UsernameText.Leave
        If String.IsNullOrWhiteSpace(UsernameText.Text) Then UsernameText.Text = "Username" : UsernameText.ForeColor = Color.Gray
    End Sub

    ' -- Email --
    Private Sub EmailText_Enter(sender As Object, e As EventArgs) Handles EmailText.Enter
        If EmailText.Text = "Email" Then EmailText.Text = "" : EmailText.ForeColor = Color.Black
    End Sub
    Private Sub EmailText_Leave(sender As Object, e As EventArgs) Handles EmailText.Leave
        If String.IsNullOrWhiteSpace(EmailText.Text) Then EmailText.Text = "Email" : EmailText.ForeColor = Color.Gray
    End Sub

    ' -- Password --
    Private Sub PasswordText_Enter(sender As Object, e As EventArgs) Handles PasswordText.Enter
        If PasswordText.Text = "Password" Then
            PasswordText.Text = "" : PasswordText.ForeColor = Color.Black : PasswordText.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub PasswordText_Leave(sender As Object, e As EventArgs) Handles PasswordText.Leave
        If String.IsNullOrWhiteSpace(PasswordText.Text) Then
            PasswordText.Text = "Password" : PasswordText.ForeColor = Color.Gray : PasswordText.UseSystemPasswordChar = False
        End If
    End Sub

End Class