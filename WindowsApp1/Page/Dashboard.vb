Public Class Dashboard
    ' Event ketika form Dashboard ditutup
    Private Sub Dashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit() ' Ini yang menghentikan aplikasi sepenuhnya
    End Sub

    ' Event ketika form Dashboard dimuat
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ambil username dan role dari SessionManager dan tampilkan di UsernameLabel
        If SessionManager.IsUserLoggedIn() Then
            UsernameLabel.Text = "Hai, " & SessionManager.Username

            ' Atur visibilitas panel berdasarkan role
            SetPanelVisibilityBasedOnRole()
        Else
            UsernameLabel.Text = "User not logged in"
            ' Default: sembunyikan semua panel jika tidak login
            PanelAdmin.Visible = False
            PanelStaff.Visible = False
            PanelUser.Visible = False
        End If
    End Sub

    ' Method untuk mengatur visibilitas panel berdasarkan role
    Private Sub SetPanelVisibilityBasedOnRole()
        Select Case SessionManager.Role.ToLower()
            Case "admin"
                ' Admin: tampilkan semua panel
                PanelAdmin.Visible = True
                PanelStaff.Visible = True
                PanelUser.Visible = True
            Case "staff"
                ' Staff: tampilkan PanelStaff dan PanelUser, sembunyikan PanelAdmin
                PanelAdmin.Visible = False
                PanelStaff.Visible = True
                PanelUser.Visible = True
            Case "user"
                ' User: hanya tampilkan PanelUser
                PanelAdmin.Visible = False
                PanelStaff.Visible = False
                PanelUser.Visible = True
            Case Else
                ' Default: sembunyikan semua panel
                PanelAdmin.Visible = False
                PanelStaff.Visible = False
                PanelUser.Visible = False
        End Select
    End Sub

    ' Event ketika UsernameLabel diklik (opsional)
    Private Sub UsernameLabel_Click(sender As Object, e As EventArgs) Handles UsernameLabel.Click
        ' Anda bisa menambahkan logika tambahan jika diperlukan ketika label di klik
    End Sub

    ' Event ketika PegawaiBtn diklik
    Private Sub AkunBtn_Click(sender As Object, e As EventArgs) Handles AkunBtn.Click
        ' Arahkan ke form Pegawai
        Dim akunForm As New Akun() ' Form Akun
        akunForm.Show()
        Me.Hide() ' Menyembunyikan form Dashboard jika perlu
    End Sub

    ' Event ketika LogoutBtn diklik
    Private Sub LogoutBtn_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click
        ' Hapus sesi pengguna
        SessionManager.ClearSession()

        ' Arahkan ke form Welcome setelah logout
        Dim welcomeForm As New Welcome() ' Form Welcome
        welcomeForm.Show()

        ' Menyembunyikan form Dashboard setelah logout
        Me.Hide()
    End Sub

    Private Sub BarangBtn_Click(sender As Object, e As EventArgs) Handles BarangBtn.Click
        ' Arahkan ke form Barang
        Dim barangForm As New ManageBarang() ' Form Barang
        barangForm.Show()
        Me.Hide() ' Menyembunyikan form Dashboard jika perlu
    End Sub

    Private Sub LabelWarung_Click(sender As Object, e As EventArgs) Handles LabelWarung.Click
        ' Kosong atau tambahkan logika sesuai kebutuhan
    End Sub

    Private Sub KategoriBtn_Click(sender As Object, e As EventArgs) Handles KategoriBtn.Click
        ' Arahkan ke form Kategori
        Dim kategoriForm As New ManageKategori() ' Form Kategori
        kategoriForm.Show()
        Me.Hide() ' Menyembunyikan form Dashboard jika perlu
    End Sub

    Private Sub RakBtn_Click(sender As Object, e As EventArgs) Handles RakBtn.Click
        ' Arahkan ke form Shelf
        Dim shelfForm As New ManageShelf() ' Form Shelf
        shelfForm.Show()
        Me.Hide() ' Menyembunyikan form Dashboard jika perlu
    End Sub

    Private Sub StockBtn_Click(sender As Object, e As EventArgs) Handles ManageStockBtn.Click
        ' Arahkan ke form Stock
        Dim stockForm As New ManageStock() ' Form Stock
        stockForm.Show()
        Me.Hide() ' Menyembunyikan form Dashboard jika perlu
    End Sub

    Private Sub KasirBtn_Click(sender As Object, e As EventArgs) Handles KasirBtn.Click
        ' Arahkan ke form Kasir
        Dim kasirForm As New Kasir() ' Form Kasir
        kasirForm.Show()
        Me.Hide() ' Menyembunyikan form Dashboard jika perlu
    End Sub

    Private Sub HistoriBelanjaBtn_Click(sender As Object, e As EventArgs) Handles HistoriBelanjaBtn.Click
        ' Arahkan ke form Histori Belanja
        Dim historiBelanjaForm As New HistoriBelanja() ' Form HistoriBelanja
        historiBelanjaForm.Show()
        Me.Hide() ' Menyembunyikan form Dashboard jika perlu
    End Sub

    Private Sub IsiSaldoBtn_Click(sender As Object, e As EventArgs) Handles IsiSaldoBtn.Click
        ' Arahkan ke form Isi Saldo
        Dim isiSaldoForm As New IsiSaldo() ' Form IsiSaldo
        isiSaldoForm.Show()
        Me.Hide() ' Menyembunyikan form Dashboard jika perlu
    End Sub

    Private Sub KeuanganBtn_Click(sender As Object, e As EventArgs) Handles KeuanganBtn.Click
        ' Arahkan ke form Keuangan
        Dim keuanganForm As New Keuangan() ' Form Keuangan
        keuanganForm.Show()
        Me.Hide() ' Menyembunyikan form Dashboard jika perlu
    End Sub
    Private Sub PanelStaff_Enter(sender As Object, e As EventArgs) Handles PanelStaff.Enter
        ' Kosong atau tambahkan logika sesuai kebutuhan
    End Sub

    ' Event untuk PanelAdmin (jika ada interaksi khusus)
    Private Sub PanelAdmin_Enter(sender As Object, e As EventArgs) Handles PanelAdmin.Enter
        ' Kosong atau tambahkan logika sesuai kebutuhan
    End Sub

    ' Event untuk PanelUser (jika ada interaksi khusus)
    Private Sub PanelUser_Enter(sender As Object, e As EventArgs) Handles PanelUser.Enter
        ' Kosong atau tambahkan logika sesuai kebutuhan
    End Sub

End Class