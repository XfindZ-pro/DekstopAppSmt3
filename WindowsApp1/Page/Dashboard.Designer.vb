<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelUp = New System.Windows.Forms.Panel()
        Me.GroupAdmin = New System.Windows.Forms.GroupBox()
        Me.PanelAdmin = New System.Windows.Forms.Panel()
        Me.KeuanganBtn = New System.Windows.Forms.Button()
        Me.RakBtn = New System.Windows.Forms.Button()
        Me.KategoriBtn = New System.Windows.Forms.Button()
        Me.BarangBtn = New System.Windows.Forms.Button()
        Me.AkunBtn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LabelWarung = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.LogoutBtn = New System.Windows.Forms.Button()
        Me.PanelUser = New System.Windows.Forms.GroupBox()
        Me.HistoriBelanjaBtn = New System.Windows.Forms.Button()
        Me.PanelStaff = New System.Windows.Forms.GroupBox()
        Me.IsiSaldoBtn = New System.Windows.Forms.Button()
        Me.KasirBtn = New System.Windows.Forms.Button()
        Me.ManageStockBtn = New System.Windows.Forms.Button()
        Me.GroupAdmin.SuspendLayout()
        Me.PanelAdmin.SuspendLayout()
        Me.PanelUser.SuspendLayout()
        Me.PanelStaff.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelUp
        '
        Me.PanelUp.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelUp.Location = New System.Drawing.Point(-8, 150)
        Me.PanelUp.Name = "PanelUp"
        Me.PanelUp.Size = New System.Drawing.Size(1294, 16)
        Me.PanelUp.TabIndex = 0
        '
        'GroupAdmin
        '
        Me.GroupAdmin.Controls.Add(Me.PanelAdmin)
        Me.GroupAdmin.Controls.Add(Me.GroupBox2)
        Me.GroupAdmin.Location = New System.Drawing.Point(81, 378)
        Me.GroupAdmin.Name = "GroupAdmin"
        Me.GroupAdmin.Size = New System.Drawing.Size(1077, 152)
        Me.GroupAdmin.TabIndex = 1
        Me.GroupAdmin.TabStop = False
        Me.GroupAdmin.Text = "Admin "
        '
        'PanelAdmin
        '
        Me.PanelAdmin.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PanelAdmin.Controls.Add(Me.KeuanganBtn)
        Me.PanelAdmin.Controls.Add(Me.RakBtn)
        Me.PanelAdmin.Controls.Add(Me.KategoriBtn)
        Me.PanelAdmin.Controls.Add(Me.BarangBtn)
        Me.PanelAdmin.Controls.Add(Me.AkunBtn)
        Me.PanelAdmin.Location = New System.Drawing.Point(22, 22)
        Me.PanelAdmin.Name = "PanelAdmin"
        Me.PanelAdmin.Size = New System.Drawing.Size(1029, 100)
        Me.PanelAdmin.TabIndex = 2
        '
        'KeuanganBtn
        '
        Me.KeuanganBtn.Location = New System.Drawing.Point(62, 54)
        Me.KeuanganBtn.Name = "KeuanganBtn"
        Me.KeuanganBtn.Size = New System.Drawing.Size(136, 31)
        Me.KeuanganBtn.TabIndex = 4
        Me.KeuanganBtn.Text = "Keuangan"
        Me.KeuanganBtn.UseVisualStyleBackColor = True
        '
        'RakBtn
        '
        Me.RakBtn.Location = New System.Drawing.Point(234, 63)
        Me.RakBtn.Name = "RakBtn"
        Me.RakBtn.Size = New System.Drawing.Size(136, 31)
        Me.RakBtn.TabIndex = 3
        Me.RakBtn.Text = "Rak"
        Me.RakBtn.UseVisualStyleBackColor = True
        '
        'KategoriBtn
        '
        Me.KategoriBtn.Location = New System.Drawing.Point(408, 63)
        Me.KategoriBtn.Name = "KategoriBtn"
        Me.KategoriBtn.Size = New System.Drawing.Size(136, 31)
        Me.KategoriBtn.TabIndex = 2
        Me.KategoriBtn.Text = "Kategori"
        Me.KategoriBtn.UseVisualStyleBackColor = True
        '
        'BarangBtn
        '
        Me.BarangBtn.Location = New System.Drawing.Point(315, 13)
        Me.BarangBtn.Name = "BarangBtn"
        Me.BarangBtn.Size = New System.Drawing.Size(136, 31)
        Me.BarangBtn.TabIndex = 1
        Me.BarangBtn.Text = "Barang"
        Me.BarangBtn.UseVisualStyleBackColor = True
        '
        'AkunBtn
        '
        Me.AkunBtn.Location = New System.Drawing.Point(62, 13)
        Me.AkunBtn.Name = "AkunBtn"
        Me.AkunBtn.Size = New System.Drawing.Size(136, 31)
        Me.AkunBtn.TabIndex = 0
        Me.AkunBtn.Text = "Akun"
        Me.AkunBtn.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(84, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(8, 8)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'LabelWarung
        '
        Me.LabelWarung.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelWarung.Font = New System.Drawing.Font("Microsoft YaHei", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWarung.Location = New System.Drawing.Point(435, 9)
        Me.LabelWarung.Name = "LabelWarung"
        Me.LabelWarung.Size = New System.Drawing.Size(442, 123)
        Me.LabelWarung.TabIndex = 2
        Me.LabelWarung.Text = "Toko Pakaian" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "JL. Taman Pondok Jati, Sidoarjo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(085) 635-572-57" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.Location = New System.Drawing.Point(1035, 183)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(86, 20)
        Me.UsernameLabel.TabIndex = 3
        Me.UsernameLabel.Text = "Username"
        '
        'LogoutBtn
        '
        Me.LogoutBtn.Location = New System.Drawing.Point(884, 179)
        Me.LogoutBtn.Name = "LogoutBtn"
        Me.LogoutBtn.Size = New System.Drawing.Size(75, 30)
        Me.LogoutBtn.TabIndex = 4
        Me.LogoutBtn.Text = "Logout"
        Me.LogoutBtn.UseVisualStyleBackColor = True
        '
        'PanelUser
        '
        Me.PanelUser.Controls.Add(Me.HistoriBelanjaBtn)
        Me.PanelUser.Location = New System.Drawing.Point(81, 215)
        Me.PanelUser.Name = "PanelUser"
        Me.PanelUser.Size = New System.Drawing.Size(1077, 67)
        Me.PanelUser.TabIndex = 5
        Me.PanelUser.TabStop = False
        Me.PanelUser.Text = "User"
        '
        'HistoriBelanjaBtn
        '
        Me.HistoriBelanjaBtn.Location = New System.Drawing.Point(116, 21)
        Me.HistoriBelanjaBtn.Name = "HistoriBelanjaBtn"
        Me.HistoriBelanjaBtn.Size = New System.Drawing.Size(153, 23)
        Me.HistoriBelanjaBtn.TabIndex = 2
        Me.HistoriBelanjaBtn.Text = "Histori Belanja"
        Me.HistoriBelanjaBtn.UseVisualStyleBackColor = True
        '
        'PanelStaff
        '
        Me.PanelStaff.Controls.Add(Me.IsiSaldoBtn)
        Me.PanelStaff.Controls.Add(Me.KasirBtn)
        Me.PanelStaff.Controls.Add(Me.ManageStockBtn)
        Me.PanelStaff.Location = New System.Drawing.Point(81, 288)
        Me.PanelStaff.Name = "PanelStaff"
        Me.PanelStaff.Size = New System.Drawing.Size(1077, 67)
        Me.PanelStaff.TabIndex = 6
        Me.PanelStaff.TabStop = False
        Me.PanelStaff.Text = "Staff"
        '
        'IsiSaldoBtn
        '
        Me.IsiSaldoBtn.Location = New System.Drawing.Point(405, 22)
        Me.IsiSaldoBtn.Name = "IsiSaldoBtn"
        Me.IsiSaldoBtn.Size = New System.Drawing.Size(91, 23)
        Me.IsiSaldoBtn.TabIndex = 0
        Me.IsiSaldoBtn.Text = "Isi saldo"
        Me.IsiSaldoBtn.UseVisualStyleBackColor = True
        '
        'KasirBtn
        '
        Me.KasirBtn.Location = New System.Drawing.Point(288, 22)
        Me.KasirBtn.Name = "KasirBtn"
        Me.KasirBtn.Size = New System.Drawing.Size(75, 23)
        Me.KasirBtn.TabIndex = 1
        Me.KasirBtn.Text = "Kasir"
        Me.KasirBtn.UseVisualStyleBackColor = True
        '
        'ManageStockBtn
        '
        Me.ManageStockBtn.Location = New System.Drawing.Point(116, 22)
        Me.ManageStockBtn.Name = "ManageStockBtn"
        Me.ManageStockBtn.Size = New System.Drawing.Size(147, 23)
        Me.ManageStockBtn.TabIndex = 0
        Me.ManageStockBtn.Text = "Manajemen Stock"
        Me.ManageStockBtn.UseVisualStyleBackColor = True
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.Desain_tanpa_judul
        Me.ClientSize = New System.Drawing.Size(1283, 567)
        Me.Controls.Add(Me.PanelStaff)
        Me.Controls.Add(Me.PanelUser)
        Me.Controls.Add(Me.LogoutBtn)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LabelWarung)
        Me.Controls.Add(Me.GroupAdmin)
        Me.Controls.Add(Me.PanelUp)
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        Me.GroupAdmin.ResumeLayout(False)
        Me.PanelAdmin.ResumeLayout(False)
        Me.PanelUser.ResumeLayout(False)
        Me.PanelStaff.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelUp As Panel
    Friend WithEvents GroupAdmin As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PanelAdmin As Panel
    Friend WithEvents AkunBtn As Button
    Friend WithEvents LabelWarung As Label
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents LogoutBtn As Button
    Friend WithEvents BarangBtn As Button
    Friend WithEvents PanelUser As GroupBox
    Friend WithEvents KategoriBtn As Button
    Friend WithEvents RakBtn As Button
    Friend WithEvents PanelStaff As GroupBox
    Friend WithEvents ManageStockBtn As Button
    Friend WithEvents KasirBtn As Button
    Friend WithEvents IsiSaldoBtn As Button
    Friend WithEvents KeuanganBtn As Button
    Friend WithEvents HistoriBelanjaBtn As Button
End Class
