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
        Me.LabelMasukkanNama.BackColor = System.Drawing.Color.Transparent
        Me.LabelMasukkanNama.Font = New System.Drawing.Font("Montserrat SemiBold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMasukkanNama.ForeColor = System.Drawing.Color.White
        Me.LabelMasukkanNama.Location = New System.Drawing.Point(12, 105)
        Me.LabelMasukkanNama.Name = "LabelMasukkanNama"
        Me.LabelMasukkanNama.Size = New System.Drawing.Size(328, 36)
        Me.LabelMasukkanNama.TabIndex = 0
        Me.LabelMasukkanNama.Text = "Masukkan Nama Member:"
        '
        'LabelIsiBerapa
        '
        Me.LabelIsiBerapa.AutoSize = True
        Me.LabelIsiBerapa.BackColor = System.Drawing.Color.Transparent
        Me.LabelIsiBerapa.Font = New System.Drawing.Font("Montserrat SemiBold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelIsiBerapa.ForeColor = System.Drawing.Color.White
        Me.LabelIsiBerapa.Location = New System.Drawing.Point(12, 221)
        Me.LabelIsiBerapa.Name = "LabelIsiBerapa"
        Me.LabelIsiBerapa.Size = New System.Drawing.Size(143, 36)
        Me.LabelIsiBerapa.TabIndex = 1
        Me.LabelIsiBerapa.Text = "Isi Berapa?"
        '
        'NumericIsiSaldo
        '
        Me.NumericIsiSaldo.Font = New System.Drawing.Font("Montserrat Medium", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericIsiSaldo.Location = New System.Drawing.Point(279, 232)
        Me.NumericIsiSaldo.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericIsiSaldo.Name = "NumericIsiSaldo"
        Me.NumericIsiSaldo.Size = New System.Drawing.Size(120, 36)
        Me.NumericIsiSaldo.TabIndex = 2
        '
        'ComboBoxNama
        '
        Me.ComboBoxNama.Font = New System.Drawing.Font("Montserrat Medium", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxNama.FormattingEnabled = True
        Me.ComboBoxNama.Location = New System.Drawing.Point(336, 104)
        Me.ComboBoxNama.Name = "ComboBoxNama"
        Me.ComboBoxNama.Size = New System.Drawing.Size(265, 44)
        Me.ComboBoxNama.TabIndex = 3
        '
        'LabelMetodePembayaran
        '
        Me.LabelMetodePembayaran.AutoSize = True
        Me.LabelMetodePembayaran.BackColor = System.Drawing.Color.Transparent
        Me.LabelMetodePembayaran.Font = New System.Drawing.Font("Montserrat SemiBold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMetodePembayaran.ForeColor = System.Drawing.Color.White
        Me.LabelMetodePembayaran.Location = New System.Drawing.Point(15, 345)
        Me.LabelMetodePembayaran.Name = "LabelMetodePembayaran"
        Me.LabelMetodePembayaran.Size = New System.Drawing.Size(268, 36)
        Me.LabelMetodePembayaran.TabIndex = 4
        Me.LabelMetodePembayaran.Text = "Metode Pembayaran:"
        '
        'RadioButtonQris
        '
        Me.RadioButtonQris.AutoSize = True
        Me.RadioButtonQris.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonQris.Font = New System.Drawing.Font("Montserrat Medium", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonQris.ForeColor = System.Drawing.Color.White
        Me.RadioButtonQris.Location = New System.Drawing.Point(317, 343)
        Me.RadioButtonQris.Name = "RadioButtonQris"
        Me.RadioButtonQris.Size = New System.Drawing.Size(82, 40)
        Me.RadioButtonQris.TabIndex = 5
        Me.RadioButtonQris.TabStop = True
        Me.RadioButtonQris.Text = "Qris"
        Me.RadioButtonQris.UseVisualStyleBackColor = False
        '
        'BtnBayar
        '
        Me.BtnBayar.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnBayar.Font = New System.Drawing.Font("Montserrat Medium", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBayar.ForeColor = System.Drawing.Color.White
        Me.BtnBayar.Location = New System.Drawing.Point(187, 429)
        Me.BtnBayar.Name = "BtnBayar"
        Me.BtnBayar.Size = New System.Drawing.Size(212, 61)
        Me.BtnBayar.TabIndex = 7
        Me.BtnBayar.Text = "Bayar"
        Me.BtnBayar.UseVisualStyleBackColor = False
        '
        'BtnKembali
        '
        Me.BtnKembali.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.BtnKembali.Font = New System.Drawing.Font("Montserrat SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKembali.ForeColor = System.Drawing.Color.White
        Me.BtnKembali.Location = New System.Drawing.Point(12, 24)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(163, 51)
        Me.BtnKembali.TabIndex = 8
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = False
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
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
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
