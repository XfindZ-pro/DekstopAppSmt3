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
        Me.BtnKembali.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKembali.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnKembali.Location = New System.Drawing.Point(24, 21)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(139, 36)
        Me.BtnKembali.TabIndex = 12
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'LabelNominalSetor
        '
        Me.LabelNominalSetor.AutoSize = True
        Me.LabelNominalSetor.BackColor = System.Drawing.Color.Transparent
        Me.LabelNominalSetor.Font = New System.Drawing.Font("Montserrat SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNominalSetor.ForeColor = System.Drawing.Color.White
        Me.LabelNominalSetor.Location = New System.Drawing.Point(70, 180)
        Me.LabelNominalSetor.Name = "LabelNominalSetor"
        Me.LabelNominalSetor.Size = New System.Drawing.Size(167, 31)
        Me.LabelNominalSetor.TabIndex = 13
        Me.LabelNominalSetor.Text = "Nominal Setor:"
        '
        'LabelSaldoCashDimiliki
        '
        Me.LabelSaldoCashDimiliki.AutoSize = True
        Me.LabelSaldoCashDimiliki.BackColor = System.Drawing.Color.Transparent
        Me.LabelSaldoCashDimiliki.Font = New System.Drawing.Font("Montserrat SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSaldoCashDimiliki.ForeColor = System.Drawing.Color.White
        Me.LabelSaldoCashDimiliki.Location = New System.Drawing.Point(70, 87)
        Me.LabelSaldoCashDimiliki.Name = "LabelSaldoCashDimiliki"
        Me.LabelSaldoCashDimiliki.Size = New System.Drawing.Size(164, 31)
        Me.LabelSaldoCashDimiliki.TabIndex = 14
        Me.LabelSaldoCashDimiliki.Text = "Tunai Dimiliki:"
        '
        'NumericNominal
        '
        Me.NumericNominal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericNominal.Location = New System.Drawing.Point(268, 180)
        Me.NumericNominal.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.NumericNominal.Name = "NumericNominal"
        Me.NumericNominal.Size = New System.Drawing.Size(136, 30)
        Me.NumericNominal.TabIndex = 15
        '
        'BtnSetor
        '
        Me.BtnSetor.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSetor.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnSetor.Location = New System.Drawing.Point(268, 286)
        Me.BtnSetor.Name = "BtnSetor"
        Me.BtnSetor.Size = New System.Drawing.Size(136, 42)
        Me.BtnSetor.TabIndex = 16
        Me.BtnSetor.Text = "Setor"
        Me.BtnSetor.UseVisualStyleBackColor = True
        '
        'RadioButtonCash
        '
        Me.RadioButtonCash.AutoSize = True
        Me.RadioButtonCash.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonCash.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonCash.ForeColor = System.Drawing.Color.White
        Me.RadioButtonCash.Location = New System.Drawing.Point(268, 233)
        Me.RadioButtonCash.Name = "RadioButtonCash"
        Me.RadioButtonCash.Size = New System.Drawing.Size(85, 35)
        Me.RadioButtonCash.TabIndex = 17
        Me.RadioButtonCash.TabStop = True
        Me.RadioButtonCash.Text = "Cash"
        Me.RadioButtonCash.UseVisualStyleBackColor = False
        '
        'RadioButtonBank
        '
        Me.RadioButtonBank.AutoSize = True
        Me.RadioButtonBank.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonBank.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonBank.ForeColor = System.Drawing.Color.White
        Me.RadioButtonBank.Location = New System.Drawing.Point(366, 233)
        Me.RadioButtonBank.Name = "RadioButtonBank"
        Me.RadioButtonBank.Size = New System.Drawing.Size(88, 35)
        Me.RadioButtonBank.TabIndex = 18
        Me.RadioButtonBank.TabStop = True
        Me.RadioButtonBank.Text = "Bank"
        Me.RadioButtonBank.UseVisualStyleBackColor = False
        '
        'LabelSaldoEmoneyDimiliki
        '
        Me.LabelSaldoEmoneyDimiliki.AutoSize = True
        Me.LabelSaldoEmoneyDimiliki.BackColor = System.Drawing.Color.Transparent
        Me.LabelSaldoEmoneyDimiliki.Font = New System.Drawing.Font("Montserrat SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSaldoEmoneyDimiliki.ForeColor = System.Drawing.Color.White
        Me.LabelSaldoEmoneyDimiliki.Location = New System.Drawing.Point(70, 131)
        Me.LabelSaldoEmoneyDimiliki.Name = "LabelSaldoEmoneyDimiliki"
        Me.LabelSaldoEmoneyDimiliki.Size = New System.Drawing.Size(186, 31)
        Me.LabelSaldoEmoneyDimiliki.TabIndex = 19
        Me.LabelSaldoEmoneyDimiliki.Text = "Emoney Dimiliki"
        '
        'SetorKas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.aksieii
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
