<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SetorKas
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
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.LabelNominalSetor = New System.Windows.Forms.Label()
        Me.LabelSaldoCashDimiliki = New System.Windows.Forms.Label()
        Me.NumericNominal = New System.Windows.Forms.NumericUpDown()
        Me.BtnSetor = New System.Windows.Forms.Button()
        Me.RadioButtonCash = New System.Windows.Forms.RadioButton()
        Me.RadioButtonBank = New System.Windows.Forms.RadioButton()
        Me.LabelSaldoEmoneyDimiliki = New System.Windows.Forms.Label()
        CType(Me.NumericNominal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnKembali
        '
        Me.BtnKembali.Location = New System.Drawing.Point(37, 34)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(75, 23)
        Me.BtnKembali.TabIndex = 12
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'LabelNominalSetor
        '
        Me.LabelNominalSetor.AutoSize = True
        Me.LabelNominalSetor.Location = New System.Drawing.Point(136, 178)
        Me.LabelNominalSetor.Name = "LabelNominalSetor"
        Me.LabelNominalSetor.Size = New System.Drawing.Size(95, 16)
        Me.LabelNominalSetor.TabIndex = 13
        Me.LabelNominalSetor.Text = "Nominal Setor:"
        '
        'LabelSaldoCashDimiliki
        '
        Me.LabelSaldoCashDimiliki.AutoSize = True
        Me.LabelSaldoCashDimiliki.Location = New System.Drawing.Point(139, 82)
        Me.LabelSaldoCashDimiliki.Name = "LabelSaldoCashDimiliki"
        Me.LabelSaldoCashDimiliki.Size = New System.Drawing.Size(90, 16)
        Me.LabelSaldoCashDimiliki.TabIndex = 14
        Me.LabelSaldoCashDimiliki.Text = "Tunai Dimiliki:"
        '
        'NumericNominal
        '
        Me.NumericNominal.Location = New System.Drawing.Point(257, 171)
        Me.NumericNominal.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.NumericNominal.Name = "NumericNominal"
        Me.NumericNominal.Size = New System.Drawing.Size(136, 22)
        Me.NumericNominal.TabIndex = 15
        '
        'BtnSetor
        '
        Me.BtnSetor.Location = New System.Drawing.Point(268, 286)
        Me.BtnSetor.Name = "BtnSetor"
        Me.BtnSetor.Size = New System.Drawing.Size(125, 23)
        Me.BtnSetor.TabIndex = 16
        Me.BtnSetor.Text = "Setor"
        Me.BtnSetor.UseVisualStyleBackColor = True
        '
        'RadioButtonCash
        '
        Me.RadioButtonCash.AutoSize = True
        Me.RadioButtonCash.Location = New System.Drawing.Point(257, 217)
        Me.RadioButtonCash.Name = "RadioButtonCash"
        Me.RadioButtonCash.Size = New System.Drawing.Size(59, 20)
        Me.RadioButtonCash.TabIndex = 17
        Me.RadioButtonCash.TabStop = True
        Me.RadioButtonCash.Text = "Csah"
        Me.RadioButtonCash.UseVisualStyleBackColor = True
        '
        'RadioButtonBank
        '
        Me.RadioButtonBank.AutoSize = True
        Me.RadioButtonBank.Location = New System.Drawing.Point(355, 217)
        Me.RadioButtonBank.Name = "RadioButtonBank"
        Me.RadioButtonBank.Size = New System.Drawing.Size(59, 20)
        Me.RadioButtonBank.TabIndex = 18
        Me.RadioButtonBank.TabStop = True
        Me.RadioButtonBank.Text = "Bank"
        Me.RadioButtonBank.UseVisualStyleBackColor = True
        '
        'LabelSaldoEmoneyDimiliki
        '
        Me.LabelSaldoEmoneyDimiliki.AutoSize = True
        Me.LabelSaldoEmoneyDimiliki.Location = New System.Drawing.Point(139, 108)
        Me.LabelSaldoEmoneyDimiliki.Name = "LabelSaldoEmoneyDimiliki"
        Me.LabelSaldoEmoneyDimiliki.Size = New System.Drawing.Size(103, 16)
        Me.LabelSaldoEmoneyDimiliki.TabIndex = 19
        Me.LabelSaldoEmoneyDimiliki.Text = "Emoney Dimiliki"
        '
        'SetorKas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 435)
        Me.Controls.Add(Me.LabelSaldoEmoneyDimiliki)
        Me.Controls.Add(Me.RadioButtonBank)
        Me.Controls.Add(Me.RadioButtonCash)
        Me.Controls.Add(Me.BtnSetor)
        Me.Controls.Add(Me.NumericNominal)
        Me.Controls.Add(Me.LabelSaldoCashDimiliki)
        Me.Controls.Add(Me.LabelNominalSetor)
        Me.Controls.Add(Me.BtnKembali)
        Me.Name = "SetorKas"
        Me.Text = "Setor Kas"
        CType(Me.NumericNominal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnKembali As Button
    Friend WithEvents LabelNominalSetor As Label
    Friend WithEvents LabelSaldoCashDimiliki As Label
    Friend WithEvents NumericNominal As NumericUpDown
    Friend WithEvents BtnSetor As Button
    Friend WithEvents RadioButtonCash As RadioButton
    Friend WithEvents RadioButtonBank As RadioButton
    Friend WithEvents LabelSaldoEmoneyDimiliki As Label
End Class
