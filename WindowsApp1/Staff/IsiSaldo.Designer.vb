<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IsiSaldo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IsiSaldo))
        Me.LabelMasukkanNama = New System.Windows.Forms.Label()
        Me.LabelIsiBerapa = New System.Windows.Forms.Label()
        Me.NumericIsiSaldo = New System.Windows.Forms.NumericUpDown()
        Me.ComboBoxNama = New System.Windows.Forms.ComboBox()
        Me.LabelMetodePembayaran = New System.Windows.Forms.Label()
        Me.RadioButtonQris = New System.Windows.Forms.RadioButton()
        Me.BtnBayar = New System.Windows.Forms.Button()
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.PictureBoxPembayaran = New System.Windows.Forms.PictureBox()
        CType(Me.NumericIsiSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxPembayaran, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelMasukkanNama
        '
        Me.LabelMasukkanNama.AutoSize = True
        Me.LabelMasukkanNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMasukkanNama.Location = New System.Drawing.Point(135, 92)
        Me.LabelMasukkanNama.Name = "LabelMasukkanNama"
        Me.LabelMasukkanNama.Size = New System.Drawing.Size(204, 20)
        Me.LabelMasukkanNama.TabIndex = 0
        Me.LabelMasukkanNama.Text = "Masukkan Nama Member:"
        '
        'LabelIsiBerapa
        '
        Me.LabelIsiBerapa.AutoSize = True
        Me.LabelIsiBerapa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelIsiBerapa.Location = New System.Drawing.Point(135, 148)
        Me.LabelIsiBerapa.Name = "LabelIsiBerapa"
        Me.LabelIsiBerapa.Size = New System.Drawing.Size(94, 20)
        Me.LabelIsiBerapa.TabIndex = 1
        Me.LabelIsiBerapa.Text = "Isi Berapa?"
        '
        'NumericIsiSaldo
        '
        Me.NumericIsiSaldo.Location = New System.Drawing.Point(391, 145)
        Me.NumericIsiSaldo.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericIsiSaldo.Name = "NumericIsiSaldo"
        Me.NumericIsiSaldo.Size = New System.Drawing.Size(120, 22)
        Me.NumericIsiSaldo.TabIndex = 2
        '
        'ComboBoxNama
        '
        Me.ComboBoxNama.FormattingEnabled = True
        Me.ComboBoxNama.Location = New System.Drawing.Point(391, 92)
        Me.ComboBoxNama.Name = "ComboBoxNama"
        Me.ComboBoxNama.Size = New System.Drawing.Size(253, 24)
        Me.ComboBoxNama.TabIndex = 3
        '
        'LabelMetodePembayaran
        '
        Me.LabelMetodePembayaran.AutoSize = True
        Me.LabelMetodePembayaran.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMetodePembayaran.Location = New System.Drawing.Point(135, 206)
        Me.LabelMetodePembayaran.Name = "LabelMetodePembayaran"
        Me.LabelMetodePembayaran.Size = New System.Drawing.Size(167, 20)
        Me.LabelMetodePembayaran.TabIndex = 4
        Me.LabelMetodePembayaran.Text = "Metode Pembayaran:"
        '
        'RadioButtonQris
        '
        Me.RadioButtonQris.AutoSize = True
        Me.RadioButtonQris.Location = New System.Drawing.Point(391, 205)
        Me.RadioButtonQris.Name = "RadioButtonQris"
        Me.RadioButtonQris.Size = New System.Drawing.Size(52, 20)
        Me.RadioButtonQris.TabIndex = 5
        Me.RadioButtonQris.TabStop = True
        Me.RadioButtonQris.Text = "Qris"
        Me.RadioButtonQris.UseVisualStyleBackColor = True
        '
        'BtnBayar
        '
        Me.BtnBayar.Location = New System.Drawing.Point(556, 202)
        Me.BtnBayar.Name = "BtnBayar"
        Me.BtnBayar.Size = New System.Drawing.Size(152, 23)
        Me.BtnBayar.TabIndex = 7
        Me.BtnBayar.Text = "Bayar"
        Me.BtnBayar.UseVisualStyleBackColor = True
        '
        'BtnKembali
        '
        Me.BtnKembali.Location = New System.Drawing.Point(49, 24)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(75, 23)
        Me.BtnKembali.TabIndex = 8
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'PictureBoxPembayaran
        '
        Me.PictureBoxPembayaran.Image = CType(resources.GetObject("PictureBoxPembayaran.Image"), System.Drawing.Image)
        Me.PictureBoxPembayaran.Location = New System.Drawing.Point(731, 24)
        Me.PictureBoxPembayaran.Name = "PictureBoxPembayaran"
        Me.PictureBoxPembayaran.Size = New System.Drawing.Size(471, 477)
        Me.PictureBoxPembayaran.TabIndex = 9
        Me.PictureBoxPembayaran.TabStop = False
        '
        'IsiSaldo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 530)
        Me.Controls.Add(Me.PictureBoxPembayaran)
        Me.Controls.Add(Me.BtnKembali)
        Me.Controls.Add(Me.BtnBayar)
        Me.Controls.Add(Me.RadioButtonQris)
        Me.Controls.Add(Me.LabelMetodePembayaran)
        Me.Controls.Add(Me.ComboBoxNama)
        Me.Controls.Add(Me.NumericIsiSaldo)
        Me.Controls.Add(Me.LabelIsiBerapa)
        Me.Controls.Add(Me.LabelMasukkanNama)
        Me.Name = "IsiSaldo"
        Me.Text = "IsiSaldo"
        CType(Me.NumericIsiSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxPembayaran, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelMasukkanNama As Label
    Friend WithEvents LabelIsiBerapa As Label
    Friend WithEvents NumericIsiSaldo As NumericUpDown
    Friend WithEvents ComboBoxNama As ComboBox
    Friend WithEvents LabelMetodePembayaran As Label
    Friend WithEvents RadioButtonQris As RadioButton
    Friend WithEvents BtnBayar As Button
    Friend WithEvents BtnKembali As Button
    Friend WithEvents PictureBoxPembayaran As PictureBox
End Class
