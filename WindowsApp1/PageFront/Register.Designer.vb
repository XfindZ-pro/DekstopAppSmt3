<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Register))
        Me.UsernameText = New System.Windows.Forms.TextBox()
        Me.PasswordText = New System.Windows.Forms.MaskedTextBox()
        Me.RegisterBtn = New System.Windows.Forms.Button()
        Me.EmailText = New System.Windows.Forms.TextBox()
        Me.labelInfo = New System.Windows.Forms.Label()
        Me.KembaliBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Judul = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'UsernameText
        '
        Me.UsernameText.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameText.ForeColor = System.Drawing.Color.DarkGray
        Me.UsernameText.Location = New System.Drawing.Point(793, 203)
        Me.UsernameText.Name = "UsernameText"
        Me.UsernameText.Size = New System.Drawing.Size(330, 32)
        Me.UsernameText.TabIndex = 0
        Me.UsernameText.Text = "Username"
        '
        'PasswordText
        '
        Me.PasswordText.AccessibleName = ""
        Me.PasswordText.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordText.ForeColor = System.Drawing.Color.DarkGray
        Me.PasswordText.Location = New System.Drawing.Point(793, 345)
        Me.PasswordText.Name = "PasswordText"
        Me.PasswordText.Size = New System.Drawing.Size(330, 32)
        Me.PasswordText.TabIndex = 1
        Me.PasswordText.Text = "Password"
        Me.PasswordText.UseWaitCursor = True
        '
        'RegisterBtn
        '
        Me.RegisterBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegisterBtn.Location = New System.Drawing.Point(867, 422)
        Me.RegisterBtn.Name = "RegisterBtn"
        Me.RegisterBtn.Size = New System.Drawing.Size(167, 53)
        Me.RegisterBtn.TabIndex = 2
        Me.RegisterBtn.Text = "Register"
        Me.RegisterBtn.UseVisualStyleBackColor = True
        '
        'EmailText
        '
        Me.EmailText.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailText.ForeColor = System.Drawing.Color.DarkGray
        Me.EmailText.Location = New System.Drawing.Point(793, 278)
        Me.EmailText.Name = "EmailText"
        Me.EmailText.Size = New System.Drawing.Size(330, 32)
        Me.EmailText.TabIndex = 3
        Me.EmailText.Text = "Email"
        '
        'labelInfo
        '
        Me.labelInfo.AutoSize = True
        Me.labelInfo.BackColor = System.Drawing.Color.Transparent
        Me.labelInfo.Font = New System.Drawing.Font("Montserrat", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo.ForeColor = System.Drawing.Color.Navy
        Me.labelInfo.Location = New System.Drawing.Point(761, 91)
        Me.labelInfo.Name = "labelInfo"
        Me.labelInfo.Size = New System.Drawing.Size(485, 88)
        Me.labelInfo.TabIndex = 4
        Me.labelInfo.Text = "Mohon isi " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Username, Email, dan Password"
        Me.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KembaliBtn
        '
        Me.KembaliBtn.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KembaliBtn.Location = New System.Drawing.Point(12, 481)
        Me.KembaliBtn.Name = "KembaliBtn"
        Me.KembaliBtn.Size = New System.Drawing.Size(138, 51)
        Me.KembaliBtn.TabIndex = 5
        Me.KembaliBtn.Text = "Kembali"
        Me.KembaliBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Magneto", 48.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.AliceBlue
        Me.Label1.Location = New System.Drawing.Point(186, 308)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(399, 97)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Clothing"
        '
        'Judul
        '
        Me.Judul.AutoSize = True
        Me.Judul.BackColor = System.Drawing.Color.Transparent
        Me.Judul.Font = New System.Drawing.Font("Magneto", 90.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Judul.ForeColor = System.Drawing.Color.Navy
        Me.Judul.Location = New System.Drawing.Point(-2, 138)
        Me.Judul.Name = "Judul"
        Me.Judul.Size = New System.Drawing.Size(605, 182)
        Me.Judul.TabIndex = 6
        Me.Judul.Text = "4Pilar"
        '
        'Register
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1221, 544)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Judul)
        Me.Controls.Add(Me.KembaliBtn)
        Me.Controls.Add(Me.labelInfo)
        Me.Controls.Add(Me.EmailText)
        Me.Controls.Add(Me.RegisterBtn)
        Me.Controls.Add(Me.PasswordText)
        Me.Controls.Add(Me.UsernameText)
        Me.Name = "Register"
        Me.Text = "Register"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UsernameText As TextBox
    Friend WithEvents PasswordText As MaskedTextBox
    Friend WithEvents RegisterBtn As Button
    Friend WithEvents EmailText As TextBox
    Friend WithEvents labelInfo As Label
    Friend WithEvents KembaliBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Judul As Label
End Class
