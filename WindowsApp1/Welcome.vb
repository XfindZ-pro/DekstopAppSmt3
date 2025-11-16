Imports MySql.Data.MySqlClient


Public Class Welcome
    Dim cn As New MySqlConnection
    Dim cm As New MySqlCommand

    '--- Koneksi ke Database
    Sub Koneksi()
        Try
            ' Menutup koneksi jika sudah ada
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            ' Membuat koneksi baru
            cn = New MySqlConnection("server=localhost;database=pendes;Uid=root;PWD=;")

            ' Coba membuka koneksi
            cn.Open()

            ' Jika berhasil, ubah status ke Online
            DBstatus.Text = "Online"
            DBstatus.ForeColor = Color.Green ' Ubah warna menjadi hijau
        Catch ex As MySqlException
            ' Jika gagal, ubah status ke Offline
            DBstatus.Text = "Offline"
            DBstatus.ForeColor = Color.Red ' Ubah warna menjadi merah
            MessageBox.Show("Koneksi ke database gagal: " & ex.Message)
        End Try
    End Sub

    Private Sub Welcome_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit() ' Ini yang menghentikan aplikasi sepenuhnya
    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Me.Hide()

        ' Coba kedua opsi dengan error handling
        Try
            Dim LoginForm As New Login()
            LoginForm.Show()
        Catch ex As Exception
            Try
                Dim LoginForm As New Login()
                LoginForm.Show()
            Catch ex2 As Exception
                MessageBox.Show("Tidak dapat menemukan form Login: " & ex2.Message)
            End Try
        End Try
    End Sub

    Private Sub RegisterBtn_Click(sender As Object, e As EventArgs) Handles registerBtn.Click
        Me.Hide()

        ' Coba kedua opsi dengan error handling
        Try
            Dim registerForm As New Register()
            registerForm.Show()
        Catch ex As Exception
            Try
                Dim registerForm As New Register()
                registerForm.Show()
            Catch ex2 As Exception
                MessageBox.Show("Tidak dapat menemukan form Register: " & ex2.Message)
            End Try
        End Try
    End Sub

    Private Sub Welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Koneksi()
    End Sub
End Class
