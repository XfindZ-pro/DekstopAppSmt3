Imports MySql.Data.MySqlClient

Public Class Database
    Private cn As New MySqlConnection

    '--- Koneksi ke Database
    Public Sub Koneksi()
        Try
            ' Menutup koneksi jika sudah ada
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            ' Membuat koneksi baru
            cn = New MySqlConnection("server=localhost;database=pendes;Uid=root;PWD=;")

            ' Coba membuka koneksi
            cn.Open()
        Catch ex As MySqlException
            MessageBox.Show("Koneksi ke database gagal: " & ex.Message)
        End Try
    End Sub

    '--- Menutup koneksi
    Public Sub CloseConnection()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    '--- Properti untuk mendapatkan koneksi
    Public ReadOnly Property Connection As MySqlConnection
        Get
            Return cn
        End Get
    End Property
End Class
