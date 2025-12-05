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
        Me.UsernameText = New System.Windows.Forms.TextBox()
        Me.PasswordText = New System.Windows.Forms.TextBox()
        Me.LoginBtn = New System.Windows.Forms.Button()
        Me.KembaliBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'UsernameText
        '
        Me.UsernameText.Location = New System.Drawing.Point(500, 221)
        Me.UsernameText.Name = "UsernameText"
        Me.UsernameText.Size = New System.Drawing.Size(315, 22)
        Me.UsernameText.TabIndex = 0
        Me.UsernameText.Text = "Username"
        '
        'PasswordText
        '
        Me.PasswordText.Location = New System.Drawing.Point(500, 294)
        Me.PasswordText.Name = "PasswordText"
        Me.PasswordText.Size = New System.Drawing.Size(315, 22)
        Me.PasswordText.TabIndex = 1
        Me.PasswordText.Text = "Password"
        '
        'LoginBtn
        '
        Me.LoginBtn.Location = New System.Drawing.Point(596, 356)
        Me.LoginBtn.Name = "LoginBtn"
        Me.LoginBtn.Size = New System.Drawing.Size(146, 32)
        Me.LoginBtn.TabIndex = 2
        Me.LoginBtn.Text = "Login"
        Me.LoginBtn.UseVisualStyleBackColor = True
        '
        'KembaliBtn
        '
        Me.KembaliBtn.Location = New System.Drawing.Point(39, 31)
        Me.KembaliBtn.Name = "KembaliBtn"
        Me.KembaliBtn.Size = New System.Drawing.Size(75, 23)
        Me.KembaliBtn.TabIndex = 3
        Me.KembaliBtn.Text = "Kembali"
        Me.KembaliBtn.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 544)
        Me.Controls.Add(Me.KembaliBtn)
        Me.Controls.Add(Me.LoginBtn)
        Me.Controls.Add(Me.PasswordText)
        Me.Controls.Add(Me.UsernameText)
        Me.Name = "Login"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UsernameText As TextBox
    Friend WithEvents PasswordText As TextBox
    Friend WithEvents LoginBtn As Button
    Friend WithEvents KembaliBtn As Button
End Class
