<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.PanelAdmin = New System.Windows.Forms.GroupBox()
        Me.AturKasBtn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.AuditKasBtn = New System.Windows.Forms.Button()
        Me.RakBtn = New System.Windows.Forms.Button()
        Me.BarangBtn = New System.Windows.Forms.Button()
        Me.AkunBtn = New System.Windows.Forms.Button()
        Me.KategoriBtn = New System.Windows.Forms.Button()
        Me.LabelWarung = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.LogoutBtn = New System.Windows.Forms.Button()
        Me.PanelStaff = New System.Windows.Forms.GroupBox()
        Me.SetorKasBtn = New System.Windows.Forms.Button()
        Me.IsiSaldoBtn = New System.Windows.Forms.Button()
        Me.ManageStockBtn = New System.Windows.Forms.Button()
        Me.KasirBtn = New System.Windows.Forms.Button()
        Me.HistoriBelanjaBtn = New System.Windows.Forms.Button()
        Me.PanelUser = New System.Windows.Forms.GroupBox()
        Me.PanelAdmin.SuspendLayout()
        Me.PanelStaff.SuspendLayout()
        Me.PanelUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelAdmin
        '
        Me.PanelAdmin.BackColor = System.Drawing.Color.FloralWhite
        Me.PanelAdmin.Controls.Add(Me.AturKasBtn)
        Me.PanelAdmin.Controls.Add(Me.GroupBox2)
        Me.PanelAdmin.Controls.Add(Me.AuditKasBtn)
        Me.PanelAdmin.Controls.Add(Me.RakBtn)
        Me.PanelAdmin.Controls.Add(Me.BarangBtn)
        Me.PanelAdmin.Controls.Add(Me.AkunBtn)
        Me.PanelAdmin.Controls.Add(Me.KategoriBtn)
        Me.PanelAdmin.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelAdmin.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.PanelAdmin.Location = New System.Drawing.Point(40, 344)
        Me.PanelAdmin.Name = "PanelAdmin"
        Me.PanelAdmin.Size = New System.Drawing.Size(1124, 188)
        Me.PanelAdmin.TabIndex = 1
        Me.PanelAdmin.TabStop = False
        Me.PanelAdmin.Text = "Admin "
        '
        'AturKasBtn
        '
        Me.AturKasBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.AturKasBtn.BackgroundImage = CType(resources.GetObject("AturKasBtn.BackgroundImage"), System.Drawing.Image)
        Me.AturKasBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AturKasBtn.ForeColor = System.Drawing.Color.White
        Me.AturKasBtn.Location = New System.Drawing.Point(39, 54)
        Me.AturKasBtn.Name = "AturKasBtn"
        Me.AturKasBtn.Size = New System.Drawing.Size(169, 102)
        Me.AturKasBtn.TabIndex = 5
        Me.AturKasBtn.Text = "Atur Kas"
        Me.AturKasBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.AturKasBtn.UseVisualStyleBackColor = False
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
        'AuditKasBtn
        '
        Me.AuditKasBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.AuditKasBtn.BackgroundImage = CType(resources.GetObject("AuditKasBtn.BackgroundImage"), System.Drawing.Image)
        Me.AuditKasBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuditKasBtn.ForeColor = System.Drawing.Color.White
        Me.AuditKasBtn.Location = New System.Drawing.Point(214, 54)
        Me.AuditKasBtn.Name = "AuditKasBtn"
        Me.AuditKasBtn.Size = New System.Drawing.Size(166, 102)
        Me.AuditKasBtn.TabIndex = 4
        Me.AuditKasBtn.Text = "Audit Kas"
        Me.AuditKasBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.AuditKasBtn.UseVisualStyleBackColor = False
        '
        'RakBtn
        '
        Me.RakBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.RakBtn.BackgroundImage = CType(resources.GetObject("RakBtn.BackgroundImage"), System.Drawing.Image)
        Me.RakBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RakBtn.ForeColor = System.Drawing.Color.White
        Me.RakBtn.Location = New System.Drawing.Point(558, 52)
        Me.RakBtn.Name = "RakBtn"
        Me.RakBtn.Size = New System.Drawing.Size(166, 104)
        Me.RakBtn.TabIndex = 3
        Me.RakBtn.Text = "Rak"
        Me.RakBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.RakBtn.UseVisualStyleBackColor = False
        '
        'BarangBtn
        '
        Me.BarangBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.BarangBtn.BackgroundImage = CType(resources.GetObject("BarangBtn.BackgroundImage"), System.Drawing.Image)
        Me.BarangBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarangBtn.ForeColor = System.Drawing.Color.White
        Me.BarangBtn.Location = New System.Drawing.Point(902, 52)
        Me.BarangBtn.Name = "BarangBtn"
        Me.BarangBtn.Size = New System.Drawing.Size(166, 104)
        Me.BarangBtn.TabIndex = 1
        Me.BarangBtn.Text = "Barang"
        Me.BarangBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BarangBtn.UseVisualStyleBackColor = False
        '
        'AkunBtn
        '
        Me.AkunBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.AkunBtn.BackgroundImage = CType(resources.GetObject("AkunBtn.BackgroundImage"), System.Drawing.Image)
        Me.AkunBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AkunBtn.ForeColor = System.Drawing.Color.White
        Me.AkunBtn.Location = New System.Drawing.Point(386, 54)
        Me.AkunBtn.Name = "AkunBtn"
        Me.AkunBtn.Size = New System.Drawing.Size(166, 104)
        Me.AkunBtn.TabIndex = 0
        Me.AkunBtn.Text = "Akun"
        Me.AkunBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.AkunBtn.UseVisualStyleBackColor = False
        '
        'KategoriBtn
        '
        Me.KategoriBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.KategoriBtn.BackgroundImage = CType(resources.GetObject("KategoriBtn.BackgroundImage"), System.Drawing.Image)
        Me.KategoriBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KategoriBtn.ForeColor = System.Drawing.Color.White
        Me.KategoriBtn.Location = New System.Drawing.Point(730, 52)
        Me.KategoriBtn.Name = "KategoriBtn"
        Me.KategoriBtn.Size = New System.Drawing.Size(166, 104)
        Me.KategoriBtn.TabIndex = 2
        Me.KategoriBtn.Text = "Kategori"
        Me.KategoriBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.KategoriBtn.UseVisualStyleBackColor = False
        '
        'LabelWarung
        '
        Me.LabelWarung.BackColor = System.Drawing.Color.Transparent
        Me.LabelWarung.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelWarung.Font = New System.Drawing.Font("Montserrat SemiBold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWarung.ForeColor = System.Drawing.Color.White
        Me.LabelWarung.Location = New System.Drawing.Point(32, 9)
        Me.LabelWarung.Name = "LabelWarung"
        Me.LabelWarung.Size = New System.Drawing.Size(593, 190)
        Me.LabelWarung.TabIndex = 2
        Me.LabelWarung.Text = "4 Pilar Clothing" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "JL.Yang Pernah Dekat, Buduran, Sidoarjo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(085) 635-572-57" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.Font = New System.Drawing.Font("Montserrat", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.ForeColor = System.Drawing.Color.White
        Me.UsernameLabel.Location = New System.Drawing.Point(964, 40)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(200, 52)
        Me.UsernameLabel.TabIndex = 3
        Me.UsernameLabel.Text = "Username"
        '
        'LogoutBtn
        '
        Me.LogoutBtn.BackColor = System.Drawing.Color.DodgerBlue
        Me.LogoutBtn.Font = New System.Drawing.Font("Montserrat SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogoutBtn.ForeColor = System.Drawing.Color.White
        Me.LogoutBtn.Location = New System.Drawing.Point(1020, 95)
        Me.LogoutBtn.Name = "LogoutBtn"
        Me.LogoutBtn.Size = New System.Drawing.Size(132, 56)
        Me.LogoutBtn.TabIndex = 4
        Me.LogoutBtn.Text = "Logout"
        Me.LogoutBtn.UseVisualStyleBackColor = False
        '
        'PanelStaff
        '
        Me.PanelStaff.BackColor = System.Drawing.Color.FloralWhite
        Me.PanelStaff.Controls.Add(Me.SetorKasBtn)
        Me.PanelStaff.Controls.Add(Me.IsiSaldoBtn)
        Me.PanelStaff.Controls.Add(Me.ManageStockBtn)
        Me.PanelStaff.Controls.Add(Me.KasirBtn)
        Me.PanelStaff.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelStaff.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.PanelStaff.Location = New System.Drawing.Point(40, 185)
        Me.PanelStaff.Name = "PanelStaff"
        Me.PanelStaff.Size = New System.Drawing.Size(744, 153)
        Me.PanelStaff.TabIndex = 6
        Me.PanelStaff.TabStop = False
        Me.PanelStaff.Text = "Staff"
        '
        'SetorKasBtn
        '
        Me.SetorKasBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.SetorKasBtn.BackgroundImage = CType(resources.GetObject("SetorKasBtn.BackgroundImage"), System.Drawing.Image)
        Me.SetorKasBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetorKasBtn.ForeColor = System.Drawing.Color.White
        Me.SetorKasBtn.Location = New System.Drawing.Point(411, 30)
        Me.SetorKasBtn.Name = "SetorKasBtn"
        Me.SetorKasBtn.Size = New System.Drawing.Size(138, 114)
        Me.SetorKasBtn.TabIndex = 2
        Me.SetorKasBtn.Text = "Setor Kas"
        Me.SetorKasBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.SetorKasBtn.UseVisualStyleBackColor = False
        '
        'IsiSaldoBtn
        '
        Me.IsiSaldoBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.IsiSaldoBtn.BackgroundImage = CType(resources.GetObject("IsiSaldoBtn.BackgroundImage"), System.Drawing.Image)
        Me.IsiSaldoBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsiSaldoBtn.ForeColor = System.Drawing.Color.White
        Me.IsiSaldoBtn.Location = New System.Drawing.Point(558, 31)
        Me.IsiSaldoBtn.Name = "IsiSaldoBtn"
        Me.IsiSaldoBtn.Size = New System.Drawing.Size(166, 113)
        Me.IsiSaldoBtn.TabIndex = 0
        Me.IsiSaldoBtn.Text = "Isi saldo"
        Me.IsiSaldoBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.IsiSaldoBtn.UseVisualStyleBackColor = False
        '
        'ManageStockBtn
        '
        Me.ManageStockBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.ManageStockBtn.BackgroundImage = CType(resources.GetObject("ManageStockBtn.BackgroundImage"), System.Drawing.Image)
        Me.ManageStockBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManageStockBtn.ForeColor = System.Drawing.Color.White
        Me.ManageStockBtn.Location = New System.Drawing.Point(18, 32)
        Me.ManageStockBtn.Name = "ManageStockBtn"
        Me.ManageStockBtn.Size = New System.Drawing.Size(240, 113)
        Me.ManageStockBtn.TabIndex = 0
        Me.ManageStockBtn.Text = "Manajemen Stock"
        Me.ManageStockBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ManageStockBtn.UseVisualStyleBackColor = False
        '
        'KasirBtn
        '
        Me.KasirBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.KasirBtn.BackgroundImage = CType(resources.GetObject("KasirBtn.BackgroundImage"), System.Drawing.Image)
        Me.KasirBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KasirBtn.ForeColor = System.Drawing.Color.White
        Me.KasirBtn.Location = New System.Drawing.Point(265, 31)
        Me.KasirBtn.Name = "KasirBtn"
        Me.KasirBtn.Size = New System.Drawing.Size(138, 113)
        Me.KasirBtn.TabIndex = 1
        Me.KasirBtn.Text = "Kasir"
        Me.KasirBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.KasirBtn.UseVisualStyleBackColor = False
        '
        'HistoriBelanjaBtn
        '
        Me.HistoriBelanjaBtn.BackColor = System.Drawing.Color.SteelBlue
        Me.HistoriBelanjaBtn.BackgroundImage = CType(resources.GetObject("HistoriBelanjaBtn.BackgroundImage"), System.Drawing.Image)
        Me.HistoriBelanjaBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoriBelanjaBtn.ForeColor = System.Drawing.Color.White
        Me.HistoriBelanjaBtn.Location = New System.Drawing.Point(28, 31)
        Me.HistoriBelanjaBtn.Name = "HistoriBelanjaBtn"
        Me.HistoriBelanjaBtn.Size = New System.Drawing.Size(323, 113)
        Me.HistoriBelanjaBtn.TabIndex = 2
        Me.HistoriBelanjaBtn.Text = "Histori Belanja"
        Me.HistoriBelanjaBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.HistoriBelanjaBtn.UseVisualStyleBackColor = False
        '
        'PanelUser
        '
        Me.PanelUser.BackColor = System.Drawing.Color.FloralWhite
        Me.PanelUser.Controls.Add(Me.HistoriBelanjaBtn)
        Me.PanelUser.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelUser.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.PanelUser.Location = New System.Drawing.Point(790, 185)
        Me.PanelUser.Name = "PanelUser"
        Me.PanelUser.Size = New System.Drawing.Size(374, 153)
        Me.PanelUser.TabIndex = 5
        Me.PanelUser.TabStop = False
        Me.PanelUser.Text = "User"
        '
        'Dashboard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1205, 544)
        Me.Controls.Add(Me.PanelStaff)
        Me.Controls.Add(Me.PanelUser)
        Me.Controls.Add(Me.LogoutBtn)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LabelWarung)
        Me.Controls.Add(Me.PanelAdmin)
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        Me.PanelAdmin.ResumeLayout(False)
        Me.PanelStaff.ResumeLayout(False)
        Me.PanelUser.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents AkunBtn As Button
    Friend WithEvents LabelWarung As Label
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents LogoutBtn As Button
    Friend WithEvents BarangBtn As Button
    Friend WithEvents KategoriBtn As Button
    Friend WithEvents RakBtn As Button
    Friend WithEvents PanelStaff As GroupBox
    Friend WithEvents ManageStockBtn As Button
    Friend WithEvents KasirBtn As Button
    Friend WithEvents IsiSaldoBtn As Button
    Friend WithEvents AuditKasBtn As Button
    Friend WithEvents HistoriBelanjaBtn As Button
    Friend WithEvents PanelUser As GroupBox
    Friend WithEvents SetorKasBtn As Button
    Friend WithEvents AturKasBtn As Button
    Friend WithEvents PanelAdmin As GroupBox
End Class
