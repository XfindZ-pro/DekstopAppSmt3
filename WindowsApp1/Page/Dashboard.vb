Imports System.Windows.Forms

Public Class Dashboard

    ' --- 1. Event Form Utama ---

    ' Event ketika form Dashboard ditutup
    Private Sub Dashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit() ' Menghentikan aplikasi sepenuhnya
    End Sub

    ' Event ketika form Dashboard dimuat
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cek apakah user sudah login melalui SessionManager
        If SessionManager.IsUserLoggedIn() Then
            UsernameLabel.Text = "Hai, " & SessionManager.Username

            ' Atur visibilitas panel sesuai Role
            SetPanelVisibilityBasedOnRole()
        Else
            UsernameLabel.Text = "Guest"
            ' Jika tidak login, sembunyikan semua panel demi keamanan
            PanelAdmin.Visible = False
            PanelStaff.Visible = False
            PanelUser.Visible = False
        End If
    End Sub

    ' --- 2. Logika Visibilitas Panel (UPDATED) ---

    Private Sub SetPanelVisibilityBasedOnRole()
        ' Reset semua panel menjadi hidden terlebih dahulu agar bersih
        PanelAdmin.Visible = False
        PanelStaff.Visible = False
        PanelUser.Visible = False

        ' Cek Role dan aktifkan panel yang sesuai
        Select Case SessionManager.Role.ToLower()
            Case "admin"
                ' Admin: Tampilkan Panel Admin DAN Panel Staff
                PanelAdmin.Visible = True
                PanelStaff.Visible = True

            Case "staff"
                ' Staff: HANYA tampilkan Panel Staff
                PanelStaff.Visible = True

            Case "user"
                ' User: HANYA tampilkan Panel User
                PanelUser.Visible = True

            Case Else
                ' Role tidak dikenali: Tetap sembunyikan semua
        End Select
    End Sub

    ' --- 3. Tombol Navigasi Umum ---

    Private Sub LogoutBtn_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click
        ' Hapus sesi pengguna
        SessionManager.ClearSession()

        ' Arahkan kembali ke form Welcome
        Dim welcomeForm As New Welcome()
        welcomeForm.Show()

        ' Sembunyikan dashboard
        Me.Hide()
    End Sub

    Private Sub UsernameLabel_Click(sender As Object, e As EventArgs) Handles UsernameLabel.Click
        ' Opsional: Bisa diarahkan ke profil user
    End Sub

    Private Sub LabelWarung_Click(sender As Object, e As EventArgs) Handles LabelWarung.Click
        ' Opsional
    End Sub

    ' --- 4. Tombol Navigasi Panel ADMIN ---

    Private Sub AturKasBtn_Click(sender As Object, e As EventArgs) Handles AturKasBtn.Click
        Dim aturKasForm As New AturKas()
        aturKasForm.Show()
        Me.Hide()
    End Sub

    Private Sub AkunBtn_Click(sender As Object, e As EventArgs) Handles AkunBtn.Click
        Dim akunForm As New Akun()
        akunForm.Show()
        Me.Hide()
    End Sub

    Private Sub KategoriBtn_Click(sender As Object, e As EventArgs) Handles KategoriBtn.Click
        Dim kategoriForm As New ManageKategori()
        kategoriForm.Show()
        Me.Hide()
    End Sub

    Private Sub AuditKasBtn_Click(sender As Object, e As EventArgs) Handles AuditKasBtn.Click
        ' Pastikan form AuditKas sudah dibuat, jika belum bisa di-comment dulu
        ' Dim auditForm As New AuditKas()
        ' auditForm.Show()
        ' Me.Hide()
    End Sub

    Private Sub RakBtn_Click(sender As Object, e As EventArgs) Handles RakBtn.Click
        Dim shelfForm As New ManageShelf()
        shelfForm.Show()
        Me.Hide()
    End Sub

    Private Sub BarangBtn_Click(sender As Object, e As EventArgs) Handles BarangBtn.Click
        Dim barangForm As New ManageBarang()
        barangForm.Show()
        Me.Hide()
    End Sub

    Private Sub KeuanganBtn_Click(sender As Object, e As EventArgs) Handles AuditKasBtn.Click
        Dim keuanganForm As New Keuangan() ' Pastikan nama form Keuangan benar
        keuanganForm.Show()
        Me.Hide()
    End Sub

    ' --- 5. Tombol Navigasi Panel STAFF ---

    Private Sub StockBtn_Click(sender As Object, e As EventArgs) Handles ManageStockBtn.Click
        Dim stockForm As New ManageStock()
        stockForm.Show()
        Me.Hide()
    End Sub

    Private Sub KasirBtn_Click(sender As Object, e As EventArgs) Handles KasirBtn.Click
        Dim kasirForm As New Kasir()
        kasirForm.Show()
        Me.Hide()
    End Sub

    Private Sub KasBtn_Click(sender As Object, e As EventArgs) Handles SetorKasBtn.Click
        Dim setorKasForm As New SetorKas()
        setorKasForm.Show()
        Me.Hide()
    End Sub

    Private Sub IsiSaldoBtn_Click(sender As Object, e As EventArgs) Handles IsiSaldoBtn.Click
        Dim isiSaldoForm As New IsiSaldo()
        isiSaldoForm.Show()
        Me.Hide()
    End Sub

    ' --- 6. Tombol Navigasi Panel USER ---

    Private Sub HistoriBelanjaBtn_Click(sender As Object, e As EventArgs) Handles HistoriBelanjaBtn.Click
        Dim historiBelanjaForm As New HistoriBelanja()
        historiBelanjaForm.Show()
        Me.Hide()
    End Sub


End Class