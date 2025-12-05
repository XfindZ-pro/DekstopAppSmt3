Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Login
    Private db As New Database()

    '--- 1. Event Lifecycle ---
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPlaceholderDefaults()
    End Sub

    Private Sub Login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub KembaliBtn_Click(sender As Object, e As EventArgs) Handles KembaliBtn.Click
        Dim welcomeForm As New Welcome()
        welcomeForm.Show()
        Me.Hide()
    End Sub

    '--- 2. Logic Tombol Login ---
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Dim username As String = UsernameText.Text.Trim()
        Dim password As String = PasswordText.Text.Trim()

        ' Validasi input dasar
        If IsPlaceholderOrEmpty(username, "Username") OrElse IsPlaceholderOrEmpty(password, "Password") Then
            MessageBox.Show("Mohon masukkan Username dan Password.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            db.Koneksi()
            Dim conn As MySqlConnection = db.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Gagal terhubung ke database.")

            Dim encryptedPassword As String = EncryptPassword(password)

            ' [UPDATE] Ambil juga kolom 'cash'
            Dim query As String = "SELECT akunID, username, email, role, emoney, cash FROM akun WHERE username = @username AND password = @password"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", encryptedPassword)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Login Sukses - Ambil data
                        Dim id = reader("akunID").ToString()
                        Dim user = reader("username").ToString()
                        Dim email = reader("email").ToString()
                        Dim role = reader("role").ToString()

                        ' Handle potential DBNull
                        Dim emoneyVal As Integer = If(IsDBNull(reader("emoney")), 0, Convert.ToInt32(reader("emoney")))
                        Dim cashVal As Integer = If(IsDBNull(reader("cash")), 0, Convert.ToInt32(reader("cash")))

                        ' Simpan ke SessionManager (Lengkap dengan Cash)
                        SessionManager.SetSession(id, user, email, role, emoneyVal, cashVal)

                        ' Pindah ke Dashboard
                        Dim dashboardForm As New Dashboard()
                        dashboardForm.Show()
                        Me.Hide()
                    Else
                        ' Login Gagal
                        MessageBox.Show("Username atau Password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            db.CloseConnection()
        End Try
    End Sub

    '--- 3. Helper Functions ---

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

    Private Function IsPlaceholderOrEmpty(text As String, placeholder As String) As Boolean
        Return String.IsNullOrWhiteSpace(text) OrElse text = placeholder
    End Function

    '--- 4. UI Logic (Placeholder & Enter Key) ---

    Private Sub SetPlaceholderDefaults()
        UsernameText_Leave(UsernameText, EventArgs.Empty)
        PasswordText_Leave(PasswordText, EventArgs.Empty)
    End Sub

    ' -- Username --
    Private Sub UsernameText_Enter(sender As Object, e As EventArgs) Handles UsernameText.Enter
        If UsernameText.Text = "Username" Then UsernameText.Text = "" : UsernameText.ForeColor = Color.Black
    End Sub
    Private Sub UsernameText_Leave(sender As Object, e As EventArgs) Handles UsernameText.Leave
        If String.IsNullOrWhiteSpace(UsernameText.Text) Then UsernameText.Text = "Username" : UsernameText.ForeColor = Color.Gray
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

    ' -- KeyPress (Enter to Login) --
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