Public Class SessionManager
    ' Menyimpan data pengguna yang login
    Public Shared Property AkunID As String
    Public Shared Property Username As String
    Public Shared Property Email As String
    Public Shared Property Role As String
    ' [PERBAIKAN] Mengganti Money menjadi emoney
    Public Shared Property emoney As Integer

    ' Overload method untuk kompatibilitas dengan kode lama
    Public Shared Sub SetSession(akunID As String, username As String, email As String, role As String)
        ' [PERBAIKAN] Default emoney = 0
        SetSession(akunID, username, email, role, 0)
    End Sub

    ' Method utama dengan parameter emoney
    ' [PERBAIKAN] Mengganti parameter money menjadi emoney
    Public Shared Sub SetSession(akunID As String, username As String, email As String, role As String, emoneyVal As Integer)
        SessionManager.AkunID = akunID
        SessionManager.Username = username
        SessionManager.Email = email
        SessionManager.Role = role
        SessionManager.emoney = emoneyVal
    End Sub

    ' Fungsi untuk menghapus sesi (misalnya saat logout)
    Public Shared Sub ClearSession()
        AkunID = Nothing
        Username = Nothing
        Email = Nothing
        Role = Nothing
        ' [PERBAIKAN] Mengganti Money menjadi emoney
        emoney = 0
    End Sub

    ' Fungsi untuk memeriksa apakah pengguna sudah login
    Public Shared Function IsUserLoggedIn() As Boolean
        Return Not String.IsNullOrEmpty(AkunID) AndAlso Not String.IsNullOrEmpty(Username)
    End Function

    ' Fungsi untuk mendapatkan informasi pengguna
    Public Shared Function GetUserInfo() As String
        If IsUserLoggedIn() Then
            ' [PERBAIKAN] Mengganti Money menjadi emoney
            Return $"AkunID: {AkunID}, Username: {Username}, Email: {Email}, Role: {Role}, emoney: {emoney:N0}"
        Else
            Return "User is not logged in."
        End If
    End Function

    ' [PERBAIKAN] Mengganti nama fungsi dan parameter
    ' Fungsi untuk update saldo pengguna
    Public Shared Sub Updateemoney(newemoney As Integer)
        If IsUserLoggedIn() Then
            emoney = newemoney
        End If
    End Sub

    ' [PERBAIKAN] Mengganti nama fungsi
    ' Fungsi untuk menambah saldo
    Public Shared Sub Addemoney(amount As Integer)
        If IsUserLoggedIn() Then
            emoney += amount
        End If
    End Sub

    ' [PERBAIKAN] Mengganti nama fungsi
    ' Fungsi untuk mengurangi saldo
    Public Shared Sub Subtractemoney(amount As Integer)
        If IsUserLoggedIn() Then
            emoney -= amount
        End If
    End Sub

    ' [PERBAIKAN] Mengganti nama fungsi
    ' Fungsi untuk memeriksa apakah saldo mencukupi
    Public Shared Function HasSufficientemoney(amount As Integer) As Boolean
        ' [PERBAIKAN] Mengganti Money menjadi emoney
        Return IsUserLoggedIn() AndAlso emoney >= amount
    End Function
End Class