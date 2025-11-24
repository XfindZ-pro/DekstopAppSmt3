<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Akun
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list....
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelIDAkun = New System.Windows.Forms.Label()
        Me.TextBoxID = New System.Windows.Forms.TextBox()
        Me.TextBoxUsername = New System.Windows.Forms.TextBox()
        Me.LabelUsername = New System.Windows.Forms.Label()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.LabelEmail = New System.Windows.Forms.Label()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.BtnUbah = New System.Windows.Forms.Button()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DBstatus = New System.Windows.Forms.Label()
        Me.KembaliBtn = New System.Windows.Forms.Button()
        Me.PanelDataAkun = New System.Windows.Forms.DataGridView()
        Me.IdAkun = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Uang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peran = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelPeran = New System.Windows.Forms.Label()
        Me.ComboBoxPeran = New System.Windows.Forms.ComboBox()
        Me.TextBoxPencarian = New System.Windows.Forms.TextBox()
        Me.LabelCariUsername = New System.Windows.Forms.Label()
        CType(Me.PanelDataAkun, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Location = New System.Drawing.Point(-4, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1354, 22)
        Me.Panel1.TabIndex = 0
        '
        'LabelIDAkun
        '
        Me.LabelIDAkun.AutoSize = True
        Me.LabelIDAkun.Location = New System.Drawing.Point(88, 162)
        Me.LabelIDAkun.Name = "LabelIDAkun"
        Me.LabelIDAkun.Size = New System.Drawing.Size(53, 16)
        Me.LabelIDAkun.TabIndex = 1
        Me.LabelIDAkun.Text = "ID Akun"
        '
        'TextBoxID
        '
        Me.TextBoxID.Location = New System.Drawing.Point(255, 162)
        Me.TextBoxID.Name = "TextBoxID"
        Me.TextBoxID.ReadOnly = True
        Me.TextBoxID.Size = New System.Drawing.Size(311, 22)
        Me.TextBoxID.TabIndex = 3
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.Location = New System.Drawing.Point(255, 199)
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.Size = New System.Drawing.Size(311, 22)
        Me.TextBoxUsername.TabIndex = 5
        '
        'LabelUsername
        '
        Me.LabelUsername.AutoSize = True
        Me.LabelUsername.Location = New System.Drawing.Point(88, 199)
        Me.LabelUsername.Name = "LabelUsername"
        Me.LabelUsername.Size = New System.Drawing.Size(70, 16)
        Me.LabelUsername.TabIndex = 4
        Me.LabelUsername.Text = "Username"
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Location = New System.Drawing.Point(255, 233)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(311, 22)
        Me.TextBoxEmail.TabIndex = 7
        '
        'LabelEmail
        '
        Me.LabelEmail.AutoSize = True
        Me.LabelEmail.Location = New System.Drawing.Point(88, 233)
        Me.LabelEmail.Name = "LabelEmail"
        Me.LabelEmail.Size = New System.Drawing.Size(41, 16)
        Me.LabelEmail.TabIndex = 6
        Me.LabelEmail.Text = "Email"
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Location = New System.Drawing.Point(782, 233)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(75, 23)
        Me.BtnSimpan.TabIndex = 13
        Me.BtnSimpan.Text = "Simpan"
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'BtnUbah
        '
        Me.BtnUbah.Location = New System.Drawing.Point(899, 233)
        Me.BtnUbah.Name = "BtnUbah"
        Me.BtnUbah.Size = New System.Drawing.Size(75, 23)
        Me.BtnUbah.TabIndex = 14
        Me.BtnUbah.Text = "Ubah"
        Me.BtnUbah.UseVisualStyleBackColor = True
        '
        'BtnHapus
        '
        Me.BtnHapus.Location = New System.Drawing.Point(1009, 233)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(75, 23)
        Me.BtnHapus.TabIndex = 29
        Me.BtnHapus.Text = "Hapus"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'DBstatus
        '
        Me.DBstatus.AutoSize = True
        Me.DBstatus.Location = New System.Drawing.Point(1006, 9)
        Me.DBstatus.Name = "DBstatus"
        Me.DBstatus.Size = New System.Drawing.Size(42, 16)
        Me.DBstatus.TabIndex = 35
        Me.DBstatus.Text = "offline"
        '
        'KembaliBtn
        '
        Me.KembaliBtn.Location = New System.Drawing.Point(31, 29)
        Me.KembaliBtn.Name = "KembaliBtn"
        Me.KembaliBtn.Size = New System.Drawing.Size(120, 29)
        Me.KembaliBtn.TabIndex = 37
        Me.KembaliBtn.Text = "Kembali"
        Me.KembaliBtn.UseVisualStyleBackColor = True
        '
        'PanelDataAkun
        '
        Me.PanelDataAkun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PanelDataAkun.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdAkun, Me.Username, Me.Email, Me.Uang, Me.Peran})
        Me.PanelDataAkun.Location = New System.Drawing.Point(13, 362)
        Me.PanelDataAkun.Name = "PanelDataAkun"
        Me.PanelDataAkun.RowHeadersWidth = 51
        Me.PanelDataAkun.RowTemplate.Height = 24
        Me.PanelDataAkun.Size = New System.Drawing.Size(1322, 150)
        Me.PanelDataAkun.TabIndex = 38
        '
        'IdAkun
        '
        Me.IdAkun.HeaderText = "ID Akun"
        Me.IdAkun.MinimumWidth = 6
        Me.IdAkun.Name = "IdAkun"
        Me.IdAkun.Width = 125
        '
        'Username
        '
        Me.Username.HeaderText = "Username"
        Me.Username.MinimumWidth = 6
        Me.Username.Name = "Username"
        Me.Username.Width = 125
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.MinimumWidth = 6
        Me.Email.Name = "Email"
        Me.Email.Width = 125
        '
        'Uang
        '
        Me.Uang.HeaderText = "Uang"
        Me.Uang.MinimumWidth = 6
        Me.Uang.Name = "Uang"
        Me.Uang.Width = 125
        '
        'Peran
        '
        Me.Peran.HeaderText = "Peran"
        Me.Peran.MinimumWidth = 6
        Me.Peran.Name = "Peran"
        Me.Peran.Width = 125
        '
        'LabelPeran
        '
        Me.LabelPeran.AutoSize = True
        Me.LabelPeran.Location = New System.Drawing.Point(743, 146)
        Me.LabelPeran.Name = "LabelPeran"
        Me.LabelPeran.Size = New System.Drawing.Size(43, 16)
        Me.LabelPeran.TabIndex = 40
        Me.LabelPeran.Text = "Peran"
        '
        'ComboBoxPeran
        '
        Me.ComboBoxPeran.FormattingEnabled = True
        Me.ComboBoxPeran.Location = New System.Drawing.Point(807, 143)
        Me.ComboBoxPeran.Name = "ComboBoxPeran"
        Me.ComboBoxPeran.Size = New System.Drawing.Size(241, 24)
        Me.ComboBoxPeran.TabIndex = 41
        '
        'TextBoxPencarian
        '
        Me.TextBoxPencarian.Location = New System.Drawing.Point(605, 317)
        Me.TextBoxPencarian.Name = "TextBoxPencarian"
        Me.TextBoxPencarian.Size = New System.Drawing.Size(236, 22)
        Me.TextBoxPencarian.TabIndex = 42
        '
        'LabelCariUsername
        '
        Me.LabelCariUsername.AutoSize = True
        Me.LabelCariUsername.Location = New System.Drawing.Point(502, 320)
        Me.LabelCariUsername.Name = "LabelCariUsername"
        Me.LabelCariUsername.Size = New System.Drawing.Size(97, 16)
        Me.LabelCariUsername.TabIndex = 43
        Me.LabelCariUsername.Text = "Cari username:"
        '
        'Akun
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1347, 556)
        Me.Controls.Add(Me.LabelCariUsername)
        Me.Controls.Add(Me.TextBoxPencarian)
        Me.Controls.Add(Me.ComboBoxPeran)
        Me.Controls.Add(Me.LabelPeran)
        Me.Controls.Add(Me.PanelDataAkun)
        Me.Controls.Add(Me.KembaliBtn)
        Me.Controls.Add(Me.DBstatus)
        Me.Controls.Add(Me.BtnHapus)
        Me.Controls.Add(Me.BtnUbah)
        Me.Controls.Add(Me.BtnSimpan)
        Me.Controls.Add(Me.TextBoxEmail)
        Me.Controls.Add(Me.LabelEmail)
        Me.Controls.Add(Me.TextBoxUsername)
        Me.Controls.Add(Me.LabelUsername)
        Me.Controls.Add(Me.TextBoxID)
        Me.Controls.Add(Me.LabelIDAkun)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Akun"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Akun"
        CType(Me.PanelDataAkun, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelIDAkun As Label
    Friend WithEvents TextBoxID As TextBox
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents LabelUsername As Label
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents LabelEmail As Label
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents BtnUbah As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DBstatus As Label
    Friend WithEvents KembaliBtn As Button
    Friend WithEvents PanelDataAkun As DataGridView
    Friend WithEvents IdAkun As DataGridViewTextBoxColumn
    Friend WithEvents Username As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents Uang As DataGridViewTextBoxColumn
    Friend WithEvents Peran As DataGridViewTextBoxColumn
    Friend WithEvents LabelPeran As Label
    Friend WithEvents ComboBoxPeran As ComboBox
    Friend WithEvents TextBoxPencarian As TextBox
    Friend WithEvents LabelCariUsername As Label
End Class
