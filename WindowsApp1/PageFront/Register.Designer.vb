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
        Me.UsernameText = New System.Windows.Forms.TextBox()
        Me.PasswordText = New System.Windows.Forms.MaskedTextBox()
        Me.RegisterBtn = New System.Windows.Forms.Button()
        Me.EmailText = New System.Windows.Forms.TextBox()
        Me.labelInfo = New System.Windows.Forms.Label()
        Me.KembaliBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'UsernameText
        '
        Me.UsernameText.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.UsernameText.Location = New System.Drawing.Point(456, 121)
        Me.UsernameText.Name = "UsernameText"
        Me.UsernameText.Size = New System.Drawing.Size(330, 22)
        Me.UsernameText.TabIndex = 0
        Me.UsernameText.Text = "Username"
        '
        'PasswordText
        '
        Me.PasswordText.AccessibleName = ""
        Me.PasswordText.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.PasswordText.Location = New System.Drawing.Point(456, 263)
        Me.PasswordText.Name = "PasswordText"
        Me.PasswordText.Size = New System.Drawing.Size(330, 22)
        Me.PasswordText.TabIndex = 1
        Me.PasswordText.Text = "Password"
        Me.PasswordText.UseWaitCursor = True
        '
        'RegisterBtn
        '
        Me.RegisterBtn.Location = New System.Drawing.Point(556, 337)
        Me.RegisterBtn.Name = "RegisterBtn"
        Me.RegisterBtn.Size = New System.Drawing.Size(126, 28)
        Me.RegisterBtn.TabIndex = 2
        Me.RegisterBtn.Text = "Register"
        Me.RegisterBtn.UseVisualStyleBackColor = True
        '
        'EmailText
        '
        Me.EmailText.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.EmailText.Location = New System.Drawing.Point(456, 196)
        Me.EmailText.Name = "EmailText"
        Me.EmailText.Size = New System.Drawing.Size(330, 22)
        Me.EmailText.TabIndex = 3
        Me.EmailText.Text = "Email"
        '
        'labelInfo
        '
        Me.labelInfo.AutoSize = True
        Me.labelInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo.Location = New System.Drawing.Point(451, 60)
        Me.labelInfo.Name = "labelInfo"
        Me.labelInfo.Size = New System.Drawing.Size(383, 25)
        Me.labelInfo.TabIndex = 4
        Me.labelInfo.Text = "Mohon isi Username, Email, dan Password"
        '
        'KembaliBtn
        '
        Me.KembaliBtn.Location = New System.Drawing.Point(58, 60)
        Me.KembaliBtn.Name = "KembaliBtn"
        Me.KembaliBtn.Size = New System.Drawing.Size(138, 34)
        Me.KembaliBtn.TabIndex = 5
        Me.KembaliBtn.Text = "Kembali"
        Me.KembaliBtn.UseVisualStyleBackColor = True
        '
        'Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1279, 596)
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
End Class
