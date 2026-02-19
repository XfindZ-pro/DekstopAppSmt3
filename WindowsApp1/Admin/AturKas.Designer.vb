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
        Me.Labelnote = New System.Windows.Forms.Label()
        CType(Me.NumericNominal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnKembali
        '
        Me.BtnKembali.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKembali.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnKembali.Location = New System.Drawing.Point(12, 12)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(133, 39)
        Me.BtnKembali.TabIndex = 14
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'LabelNamaPegawai
        '
        Me.LabelNamaPegawai.AutoSize = True
        Me.LabelNamaPegawai.BackColor = System.Drawing.Color.Transparent
        Me.LabelNamaPegawai.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNamaPegawai.ForeColor = System.Drawing.Color.White
        Me.LabelNamaPegawai.Location = New System.Drawing.Point(209, 57)
        Me.LabelNamaPegawai.Name = "LabelNamaPegawai"
        Me.LabelNamaPegawai.Size = New System.Drawing.Size(171, 31)
        Me.LabelNamaPegawai.TabIndex = 15
        Me.LabelNamaPegawai.Text = "Nama Pegawai:"
        '
        'LabelNominal
        '
        Me.LabelNominal.AutoSize = True
        Me.LabelNominal.BackColor = System.Drawing.Color.Transparent
        Me.LabelNominal.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNominal.ForeColor = System.Drawing.Color.White
        Me.LabelNominal.Location = New System.Drawing.Point(209, 103)
        Me.LabelNominal.Name = "LabelNominal"
        Me.LabelNominal.Size = New System.Drawing.Size(124, 31)
        Me.LabelNominal.TabIndex = 16
        Me.LabelNominal.Text = "Nominal    :"
        '
        'RadioButtonTunai
        '
        Me.RadioButtonTunai.AutoSize = True
        Me.RadioButtonTunai.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonTunai.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonTunai.ForeColor = System.Drawing.Color.White
        Me.RadioButtonTunai.Location = New System.Drawing.Point(420, 154)
        Me.RadioButtonTunai.Name = "RadioButtonTunai"
        Me.RadioButtonTunai.Size = New System.Drawing.Size(90, 35)
        Me.RadioButtonTunai.TabIndex = 17
        Me.RadioButtonTunai.TabStop = True
        Me.RadioButtonTunai.Text = "Tunai"
        Me.RadioButtonTunai.UseVisualStyleBackColor = False
        '
        'RadioButtonBank
        '
        Me.RadioButtonBank.AutoSize = True
        Me.RadioButtonBank.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonBank.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonBank.ForeColor = System.Drawing.Color.White
        Me.RadioButtonBank.Location = New System.Drawing.Point(549, 154)
        Me.RadioButtonBank.Name = "RadioButtonBank"
        Me.RadioButtonBank.Size = New System.Drawing.Size(88, 35)
        Me.RadioButtonBank.TabIndex = 18
        Me.RadioButtonBank.TabStop = True
        Me.RadioButtonBank.Text = "Bank"
        Me.RadioButtonBank.UseVisualStyleBackColor = False
        '
        'BtnKirimKas
        '
        Me.BtnKirimKas.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKirimKas.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnKirimKas.Location = New System.Drawing.Point(229, 219)
        Me.BtnKirimKas.Name = "BtnKirimKas"
        Me.BtnKirimKas.Size = New System.Drawing.Size(148, 73)
        Me.BtnKirimKas.TabIndex = 19
        Me.BtnKirimKas.Text = "Kirim Kas"
        Me.BtnKirimKas.UseVisualStyleBackColor = True
        '
        'ComboBoxNamaPegawai
        '
        Me.ComboBoxNamaPegawai.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxNamaPegawai.FormattingEnabled = True
        Me.ComboBoxNamaPegawai.Location = New System.Drawing.Point(403, 57)
        Me.ComboBoxNamaPegawai.Name = "ComboBoxNamaPegawai"
        Me.ComboBoxNamaPegawai.Size = New System.Drawing.Size(264, 39)
        Me.ComboBoxNamaPegawai.TabIndex = 20
        '
        'NumericNominal
        '
        Me.NumericNominal.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericNominal.Location = New System.Drawing.Point(403, 102)
        Me.NumericNominal.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.NumericNominal.Name = "NumericNominal"
        Me.NumericNominal.Size = New System.Drawing.Size(264, 32)
        Me.NumericNominal.TabIndex = 21
        '
        'BtnTarikKas
        '
        Me.BtnTarikKas.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTarikKas.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnTarikKas.Location = New System.Drawing.Point(403, 218)
        Me.BtnTarikKas.Name = "BtnTarikKas"
        Me.BtnTarikKas.Size = New System.Drawing.Size(214, 73)
        Me.BtnTarikKas.TabIndex = 22
        Me.BtnTarikKas.Text = "Tarik Kas"
        Me.BtnTarikKas.UseVisualStyleBackColor = True
        '
        'BtnAturKas
        '
        Me.BtnAturKas.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAturKas.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnAturKas.Location = New System.Drawing.Point(879, 57)
        Me.BtnAturKas.Name = "BtnAturKas"
        Me.BtnAturKas.Size = New System.Drawing.Size(226, 45)
        Me.BtnAturKas.TabIndex = 23
        Me.BtnAturKas.Text = "Atur Kas"
        Me.BtnAturKas.UseVisualStyleBackColor = True
        '
        'LabelAturKas
        '
        Me.LabelAturKas.AutoSize = True
        Me.LabelAturKas.BackColor = System.Drawing.Color.Transparent
        Me.LabelAturKas.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAturKas.ForeColor = System.Drawing.Color.White
        Me.LabelAturKas.Location = New System.Drawing.Point(798, 114)
        Me.LabelAturKas.Name = "LabelAturKas"
        Me.LabelAturKas.Size = New System.Drawing.Size(308, 31)
        Me.LabelAturKas.TabIndex = 24
        Me.LabelAturKas.Text = "Pengiriman/Menarik/Deposit"
        '
        'BtnDepositKas
        '
        Me.BtnDepositKas.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDepositKas.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnDepositKas.Location = New System.Drawing.Point(629, 216)
        Me.BtnDepositKas.Name = "BtnDepositKas"
        Me.BtnDepositKas.Size = New System.Drawing.Size(191, 73)
        Me.BtnDepositKas.TabIndex = 25
        Me.BtnDepositKas.Text = "Deposit Kas"
        Me.BtnDepositKas.UseVisualStyleBackColor = True
        '
        'Labelnote
        '
        Me.Labelnote.AutoSize = True
        Me.Labelnote.BackColor = System.Drawing.Color.Transparent
        Me.Labelnote.Font = New System.Drawing.Font("Montserrat", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelnote.ForeColor = System.Drawing.Color.White
        Me.Labelnote.Location = New System.Drawing.Point(799, 19)
        Me.Labelnote.Name = "Labelnote"
        Me.Labelnote.Size = New System.Drawing.Size(306, 27)
        Me.Labelnote.TabIndex = 26
        Me.Labelnote.Text = "*) Klik atur kas untuk memilih opsi:"
        '
        'AturKas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.aksieii
        Me.ClientSize = New System.Drawing.Size(1134, 365)
        Me.Controls.Add(Me.Labelnote)
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
    Friend WithEvents Labelnote As Label
End Class
