<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.UsernameText = New System.Windows.Forms.TextBox()
        Me.PasswordText = New System.Windows.Forms.TextBox()
        Me.LoginBtn = New System.Windows.Forms.Button()
        Me.KembaliBtn = New System.Windows.Forms.Button()
        Me.Judul = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'UsernameText
        '
        Me.UsernameText.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameText.ForeColor = System.Drawing.Color.DarkGray
        Me.UsernameText.Location = New System.Drawing.Point(783, 262)
        Me.UsernameText.Name = "UsernameText"
        Me.UsernameText.Size = New System.Drawing.Size(315, 32)
        Me.UsernameText.TabIndex = 0
        Me.UsernameText.Text = "Username"
        '
        'PasswordText
        '
        Me.PasswordText.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordText.ForeColor = System.Drawing.Color.DarkGray
        Me.PasswordText.Location = New System.Drawing.Point(783, 338)
        Me.PasswordText.Name = "PasswordText"
        Me.PasswordText.Size = New System.Drawing.Size(315, 32)
        Me.PasswordText.TabIndex = 1
        Me.PasswordText.Text = "Password"
        '
        'LoginBtn
        '
        Me.LoginBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LoginBtn.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoginBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.LoginBtn.Location = New System.Drawing.Point(863, 409)
        Me.LoginBtn.Name = "LoginBtn"
        Me.LoginBtn.Size = New System.Drawing.Size(146, 50)
        Me.LoginBtn.TabIndex = 2
        Me.LoginBtn.Text = "Login"
        Me.LoginBtn.UseVisualStyleBackColor = False
        '
        'KembaliBtn
        '
        Me.KembaliBtn.BackColor = System.Drawing.Color.DodgerBlue
        Me.KembaliBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.KembaliBtn.Font = New System.Drawing.Font("Montserrat SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KembaliBtn.Location = New System.Drawing.Point(12, 482)
        Me.KembaliBtn.Name = "KembaliBtn"
        Me.KembaliBtn.Size = New System.Drawing.Size(120, 50)
        Me.KembaliBtn.TabIndex = 3
        Me.KembaliBtn.Text = "Kembali"
        Me.KembaliBtn.UseVisualStyleBackColor = False
        '
        'Judul
        '
        Me.Judul.AutoSize = True
        Me.Judul.BackColor = System.Drawing.Color.Transparent
        Me.Judul.Font = New System.Drawing.Font("Magneto", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Judul.ForeColor = System.Drawing.Color.Navy
        Me.Judul.Location = New System.Drawing.Point(688, 27)
        Me.Judul.Name = "Judul"
        Me.Judul.Size = New System.Drawing.Size(485, 145)
        Me.Judul.TabIndex = 4
        Me.Judul.Text = "4Pilar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Magneto", 28.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.AliceBlue
        Me.Label1.Location = New System.Drawing.Point(924, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 56)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Clothing"
        '
        'Login
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1205, 544)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Judul)
        Me.Controls.Add(Me.KembaliBtn)
        Me.Controls.Add(Me.LoginBtn)
        Me.Controls.Add(Me.PasswordText)
        Me.Controls.Add(Me.UsernameText)
        Me.MaximumSize = New System.Drawing.Size(1223, 591)
        Me.Name = "Login"
        Me.RightToLeftLayout = True
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UsernameText As TextBox
    Friend WithEvents PasswordText As TextBox
    Friend WithEvents LoginBtn As Button
    Friend WithEvents KembaliBtn As Button
    Friend WithEvents Judul As Label
    Friend WithEvents Label1 As Label
End Class
