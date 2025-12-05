Public Class SessionManager

#Region "1. Properties Data User"
    ' Menyimpan data pengguna yang sedang login (Shared/Static agar bisa diakses global)
    Public Shared Property AkunID As String
    Public Shared Property Username As String
    Public Shared Property Email As String
    Public Shared Property Role As String

    ' Saldo Digital (Milik Member / Hutang Toko)
    Public Shared Property Emoney As Integer

    ' [BARU] Saldo Tunai (Uang Fisik Pegangan Kasir/Admin)
    Public Shared Property Cash As Integer
#End Region

#Region "2. Manajemen Sesi (Login/Logout)"

    ''' <summary>
    ''' Mengisi data sesi saat user berhasil login.
    ''' </summary>
    Public Shared Sub SetSession(id As String, user As String, mail As String, userRole As String, emoneyVal As Integer, cashVal As Integer)
        AkunID = id
        Username = user
        Email = mail
        Role = userRole
        Emoney = emoneyVal
        Cash = cashVal
    End Sub

    ''' <summary>
    ''' Menghapus data sesi (Logout). Reset semua ke default.
    ''' </summary>
    Public Shared Sub ClearSession()
        AkunID = Nothing
        Username = Nothing
        Email = Nothing
        Role = Nothing
        Emoney = 0
        Cash = 0
    End Sub

    ''' <summary>
    ''' Cek apakah ada user yang sedang login.
    ''' </summary>
    Public Shared Function IsUserLoggedIn() As Boolean
        Return Not String.IsNullOrEmpty(AkunID) AndAlso Not String.IsNullOrEmpty(Username)
    End Function

    ''' <summary>
    ''' Mengambil info user dalam format string (untuk Debugging/Log).
    ''' </summary>
    Public Shared Function GetUserInfo() As String
        If IsUserLoggedIn() Then
            Return $"ID: {AkunID} | User: {Username} | Role: {Role} | E-Money: {Emoney:N0} | Cash: {Cash:N0}"
        Else
            Return "User belum login."
        End If
    End Function

#End Region

#Region "3. Logika Keuangan (E-Money)"

    ''' <summary>
    ''' Update nilai E-Money secara absolut (timpa nilai lama).
    ''' </summary>
    Public Shared Sub UpdateEmoney(newValue As Integer)
        If IsUserLoggedIn() Then
            If newValue < 0 Then Throw New ArgumentException("Nilai E-Money tidak boleh negatif.")
            Emoney = newValue
        End If
    End Sub

    ''' <summary>
    ''' Menambah saldo E-Money (TopUp/Terima Transfer).
    ''' </summary>
    Public Shared Sub AddEmoney(amount As Integer)
        If IsUserLoggedIn() Then
            If amount <= 0 Then Throw New ArgumentException("Jumlah penambahan harus lebih dari 0.")
            Emoney += amount
        End If
    End Sub

    ''' <summary>
    ''' Mengurangi saldo E-Money (Belanja/Transfer Keluar).
    ''' </summary>
    Public Shared Sub SubtractEmoney(amount As Integer)
        If IsUserLoggedIn() Then
            If amount <= 0 Then Throw New ArgumentException("Jumlah pengurangan harus lebih dari 0.")
            If Not HasSufficientEmoney(amount) Then Throw New InvalidOperationException("Saldo E-Money tidak mencukupi.")

            Emoney -= amount
        End If
    End Sub

    ''' <summary>
    ''' Cek kecukupan saldo E-Money.
    ''' </summary>
    Public Shared Function HasSufficientEmoney(amount As Integer) As Boolean
        Return IsUserLoggedIn() AndAlso Emoney >= amount
    End Function

#End Region

#Region "4. Logika Keuangan (Cash / Tunai)"

    ''' <summary>
    ''' Update nilai Cash secara absolut.
    ''' </summary>
    Public Shared Sub UpdateCash(newValue As Integer)
        If IsUserLoggedIn() Then
            If newValue < 0 Then Throw New ArgumentException("Nilai Cash tidak boleh negatif.")
            Cash = newValue
        End If
    End Sub

    ''' <summary>
    ''' Menambah uang tunai di tangan (Terima pembayaran tunai).
    ''' </summary>
    Public Shared Sub AddCash(amount As Integer)
        If IsUserLoggedIn() Then
            If amount <= 0 Then Throw New ArgumentException("Jumlah penambahan cash harus lebih dari 0.")
            Cash += amount
        End If
    End Sub

    ''' <summary>
    ''' Mengurangi uang tunai di tangan (Setor ke toko / Kembalian).
    ''' </summary>
    Public Shared Sub SubtractCash(amount As Integer)
        If IsUserLoggedIn() Then
            If amount <= 0 Then Throw New ArgumentException("Jumlah pengurangan cash harus lebih dari 0.")
            If Not HasSufficientCash(amount) Then Throw New InvalidOperationException("Uang tunai (Cash) di tangan tidak mencukupi.")

            Cash -= amount
        End If
    End Sub

    ''' <summary>
    ''' Cek kecukupan uang tunai.
    ''' </summary>
    Public Shared Function HasSufficientCash(amount As Integer) As Boolean
        Return IsUserLoggedIn() AndAlso Cash >= amount
    End Function

#End Region

End Class