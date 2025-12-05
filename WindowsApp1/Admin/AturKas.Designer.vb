<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AturKas
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
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.LabelNamaPegawai = New System.Windows.Forms.Label()
        Me.LabelNominal = New System.Windows.Forms.Label()
        Me.RadioButtonTunai = New System.Windows.Forms.RadioButton()
        Me.RadioButtonBank = New System.Windows.Forms.RadioButton()
        Me.BtnKirimKas = New System.Windows.Forms.Button()
        Me.ComboBoxNamaPegawai = New System.Windows.Forms.ComboBox()
        Me.NumericNominal = New System.Windows.Forms.NumericUpDown()
        Me.BtnTarikKas = New System.Windows.Forms.Button()
        Me.BtnAturKas = New System.Windows.Forms.Button()
        Me.LabelAturKas = New System.Windows.Forms.Label()
        Me.BtnDepositKas = New System.Windows.Forms.Button()
        CType(Me.NumericNominal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnKembali
        '
        Me.BtnKembali.Location = New System.Drawing.Point(12, 12)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(75, 23)
        Me.BtnKembali.TabIndex = 14
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'LabelNamaPegawai
        '
        Me.LabelNamaPegawai.AutoSize = True
        Me.LabelNamaPegawai.Location = New System.Drawing.Point(96, 96)
        Me.LabelNamaPegawai.Name = "LabelNamaPegawai"
        Me.LabelNamaPegawai.Size = New System.Drawing.Size(103, 16)
        Me.LabelNamaPegawai.TabIndex = 15
        Me.LabelNamaPegawai.Text = "Nama Pegawai:"
        '
        'LabelNominal
        '
        Me.LabelNominal.AutoSize = True
        Me.LabelNominal.Location = New System.Drawing.Point(96, 139)
        Me.LabelNominal.Name = "LabelNominal"
        Me.LabelNominal.Size = New System.Drawing.Size(72, 16)
        Me.LabelNominal.TabIndex = 16
        Me.LabelNominal.Text = "Nominal    :"
        '
        'RadioButtonTunai
        '
        Me.RadioButtonTunai.AutoSize = True
        Me.RadioButtonTunai.Location = New System.Drawing.Point(99, 198)
        Me.RadioButtonTunai.Name = "RadioButtonTunai"
        Me.RadioButtonTunai.Size = New System.Drawing.Size(62, 20)
        Me.RadioButtonTunai.TabIndex = 17
        Me.RadioButtonTunai.TabStop = True
        Me.RadioButtonTunai.Text = "Tunai"
        Me.RadioButtonTunai.UseVisualStyleBackColor = True
        '
        'RadioButtonBank
        '
        Me.RadioButtonBank.AutoSize = True
        Me.RadioButtonBank.Location = New System.Drawing.Point(228, 198)
        Me.RadioButtonBank.Name = "RadioButtonBank"
        Me.RadioButtonBank.Size = New System.Drawing.Size(59, 20)
        Me.RadioButtonBank.TabIndex = 18
        Me.RadioButtonBank.TabStop = True
        Me.RadioButtonBank.Text = "Bank"
        Me.RadioButtonBank.UseVisualStyleBackColor = True
        '
        'BtnKirimKas
        '
        Me.BtnKirimKas.Location = New System.Drawing.Point(99, 266)
        Me.BtnKirimKas.Name = "BtnKirimKas"
        Me.BtnKirimKas.Size = New System.Drawing.Size(148, 32)
        Me.BtnKirimKas.TabIndex = 19
        Me.BtnKirimKas.Text = "Kirim Kas"
        Me.BtnKirimKas.UseVisualStyleBackColor = True
        '
        'ComboBoxNamaPegawai
        '
        Me.ComboBoxNamaPegawai.FormattingEnabled = True
        Me.ComboBoxNamaPegawai.Location = New System.Drawing.Point(228, 87)
        Me.ComboBoxNamaPegawai.Name = "ComboBoxNamaPegawai"
        Me.ComboBoxNamaPegawai.Size = New System.Drawing.Size(264, 24)
        Me.ComboBoxNamaPegawai.TabIndex = 20
        '
        'NumericNominal
        '
        Me.NumericNominal.Location = New System.Drawing.Point(228, 132)
        Me.NumericNominal.Name = "NumericNominal"
        Me.NumericNominal.Size = New System.Drawing.Size(264, 22)
        Me.NumericNominal.TabIndex = 21
        '
        'BtnTarikKas
        '
        Me.BtnTarikKas.Location = New System.Drawing.Point(317, 266)
        Me.BtnTarikKas.Name = "BtnTarikKas"
        Me.BtnTarikKas.Size = New System.Drawing.Size(191, 23)
        Me.BtnTarikKas.TabIndex = 22
        Me.BtnTarikKas.Text = "Tarik Kas"
        Me.BtnTarikKas.UseVisualStyleBackColor = True
        '
        'BtnAturKas
        '
        Me.BtnAturKas.Location = New System.Drawing.Point(211, 42)
        Me.BtnAturKas.Name = "BtnAturKas"
        Me.BtnAturKas.Size = New System.Drawing.Size(75, 23)
        Me.BtnAturKas.TabIndex = 23
        Me.BtnAturKas.Text = "Atur Kas"
        Me.BtnAturKas.UseVisualStyleBackColor = True
        '
        'LabelAturKas
        '
        Me.LabelAturKas.AutoSize = True
        Me.LabelAturKas.Location = New System.Drawing.Point(317, 42)
        Me.LabelAturKas.Name = "LabelAturKas"
        Me.LabelAturKas.Size = New System.Drawing.Size(178, 16)
        Me.LabelAturKas.TabIndex = 24
        Me.LabelAturKas.Text = "Pengiriman/Menarik/Deposit"
        '
        'BtnDepositKas
        '
        Me.BtnDepositKas.Location = New System.Drawing.Point(542, 266)
        Me.BtnDepositKas.Name = "BtnDepositKas"
        Me.BtnDepositKas.Size = New System.Drawing.Size(191, 23)
        Me.BtnDepositKas.TabIndex = 25
        Me.BtnDepositKas.Text = "Deposit Kas"
        Me.BtnDepositKas.UseVisualStyleBackColor = True
        '
        'AturKas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 365)
        Me.Controls.Add(Me.BtnDepositKas)
        Me.Controls.Add(Me.LabelAturKas)
        Me.Controls.Add(Me.BtnAturKas)
        Me.Controls.Add(Me.BtnTarikKas)
        Me.Controls.Add(Me.NumericNominal)
        Me.Controls.Add(Me.ComboBoxNamaPegawai)
        Me.Controls.Add(Me.BtnKirimKas)
        Me.Controls.Add(Me.RadioButtonBank)
        Me.Controls.Add(Me.RadioButtonTunai)
        Me.Controls.Add(Me.LabelNominal)
        Me.Controls.Add(Me.LabelNamaPegawai)
        Me.Controls.Add(Me.BtnKembali)
        Me.Name = "AturKas"
        Me.Text = "Atur Kas"
        CType(Me.NumericNominal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnKembali As Button
    Friend WithEvents LabelNamaPegawai As Label
    Friend WithEvents LabelNominal As Label
    Friend WithEvents RadioButtonTunai As RadioButton
    Friend WithEvents RadioButtonBank As RadioButton
    Friend WithEvents BtnKirimKas As Button
    Friend WithEvents ComboBoxNamaPegawai As ComboBox
    Friend WithEvents NumericNominal As NumericUpDown
    Friend WithEvents BtnTarikKas As Button
    Friend WithEvents BtnAturKas As Button
    Friend WithEvents LabelAturKas As Label
    Friend WithEvents BtnDepositKas As Button
End Class
