<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Welcome
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
        Me.welcomeTxt = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LoginBtn = New System.Windows.Forms.Button()
        Me.registerBtn = New System.Windows.Forms.Button()
        Me.DBstatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'welcomeTxt
        '
        Me.welcomeTxt.AutoSize = True
        Me.welcomeTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.welcomeTxt.Location = New System.Drawing.Point(30, 20)
        Me.welcomeTxt.Name = "welcomeTxt"
        Me.welcomeTxt.Size = New System.Drawing.Size(319, 48)
        Me.welcomeTxt.TabIndex = 0
        Me.welcomeTxt.Text = "Selamat Datang"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Location = New System.Drawing.Point(-4, 88)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1223, 23)
        Me.Panel1.TabIndex = 1
        '
        'LoginBtn
        '
        Me.LoginBtn.Location = New System.Drawing.Point(503, 235)
        Me.LoginBtn.Name = "LoginBtn"
        Me.LoginBtn.Size = New System.Drawing.Size(197, 40)
        Me.LoginBtn.TabIndex = 2
        Me.LoginBtn.Text = "Login"
        Me.LoginBtn.UseVisualStyleBackColor = True
        '
        'registerBtn
        '
        Me.registerBtn.Location = New System.Drawing.Point(503, 310)
        Me.registerBtn.Name = "registerBtn"
        Me.registerBtn.Size = New System.Drawing.Size(197, 40)
        Me.registerBtn.TabIndex = 3
        Me.registerBtn.Text = "Register"
        Me.registerBtn.UseVisualStyleBackColor = True
        '
        'DBstatus
        '
        Me.DBstatus.AutoSize = True
        Me.DBstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DBstatus.Location = New System.Drawing.Point(946, 20)
        Me.DBstatus.Name = "DBstatus"
        Me.DBstatus.Size = New System.Drawing.Size(273, 48)
        Me.DBstatus.TabIndex = 4
        Me.DBstatus.Text = "Status Server"
        '
        'Welcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ClientSize = New System.Drawing.Size(1217, 516)
        Me.Controls.Add(Me.DBstatus)
        Me.Controls.Add(Me.registerBtn)
        Me.Controls.Add(Me.LoginBtn)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.welcomeTxt)
        Me.Name = "Welcome"
        Me.Text = "Aplikasi Desktop"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents welcomeTxt As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LoginBtn As Button
    Friend WithEvents registerBtn As Button
    Friend WithEvents DBstatus As Label
End Class
