<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageStock
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
        Me.PanelDataStock = New System.Windows.Forms.DataGridView()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HargaBeli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warna = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ukuran = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelNama = New System.Windows.Forms.Label()
        Me.NumericBeli = New System.Windows.Forms.NumericUpDown()
        Me.LabelJumlahBeli = New System.Windows.Forms.Label()
        Me.LabelUang = New System.Windows.Forms.Label()
        Me.BeliBtn = New System.Windows.Forms.Button()
        Me.LabelHarga = New System.Windows.Forms.Label()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.TextBoxNama = New System.Windows.Forms.TextBox()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.LabelBeliStock = New System.Windows.Forms.Label()
        Me.RadioTunai = New System.Windows.Forms.RadioButton()
        Me.RadioBank = New System.Windows.Forms.RadioButton()
        CType(Me.PanelDataStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericBeli, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelDataStock
        '
        Me.PanelDataStock.AllowUserToOrderColumns = True
        Me.PanelDataStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.PanelDataStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.PanelDataStock.CausesValidation = False
        Me.PanelDataStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PanelDataStock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nama, Me.HargaBeli, Me.Stock, Me.Warna, Me.Ukuran})
        Me.PanelDataStock.Location = New System.Drawing.Point(69, 263)
        Me.PanelDataStock.Name = "PanelDataStock"
        Me.PanelDataStock.RowHeadersWidth = 80
        Me.PanelDataStock.RowTemplate.Height = 24
        Me.PanelDataStock.Size = New System.Drawing.Size(1084, 270)
        Me.PanelDataStock.TabIndex = 0
        '
        'Nama
        '
        Me.Nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Nama.HeaderText = "Nama Barang"
        Me.Nama.MinimumWidth = 6
        Me.Nama.Name = "Nama"
        Me.Nama.Width = 200
        '
        'HargaBeli
        '
        Me.HargaBeli.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.HargaBeli.HeaderText = "Harga Beli"
        Me.HargaBeli.MinimumWidth = 6
        Me.HargaBeli.Name = "HargaBeli"
        Me.HargaBeli.Width = 200
        '
        'Stock
        '
        Me.Stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Stock.HeaderText = "Stock Barang"
        Me.Stock.MinimumWidth = 6
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 200
        '
        'Warna
        '
        Me.Warna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Warna.HeaderText = "Warna "
        Me.Warna.MinimumWidth = 6
        Me.Warna.Name = "Warna"
        Me.Warna.Width = 200
        '
        'Ukuran
        '
        Me.Ukuran.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Ukuran.HeaderText = "Ukuran"
        Me.Ukuran.MinimumWidth = 6
        Me.Ukuran.Name = "Ukuran"
        Me.Ukuran.Width = 200
        '
        'LabelNama
        '
        Me.LabelNama.AutoSize = True
        Me.LabelNama.BackColor = System.Drawing.Color.Transparent
        Me.LabelNama.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNama.ForeColor = System.Drawing.Color.White
        Me.LabelNama.Location = New System.Drawing.Point(116, 57)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(154, 31)
        Me.LabelNama.TabIndex = 1
        Me.LabelNama.Text = "Nama Barang"
        '
        'NumericBeli
        '
        Me.NumericBeli.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericBeli.Location = New System.Drawing.Point(868, 54)
        Me.NumericBeli.Name = "NumericBeli"
        Me.NumericBeli.Size = New System.Drawing.Size(154, 32)
        Me.NumericBeli.TabIndex = 3
        '
        'LabelJumlahBeli
        '
        Me.LabelJumlahBeli.AutoSize = True
        Me.LabelJumlahBeli.BackColor = System.Drawing.Color.Transparent
        Me.LabelJumlahBeli.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelJumlahBeli.ForeColor = System.Drawing.Color.White
        Me.LabelJumlahBeli.Location = New System.Drawing.Point(731, 57)
        Me.LabelJumlahBeli.Name = "LabelJumlahBeli"
        Me.LabelJumlahBeli.Size = New System.Drawing.Size(131, 31)
        Me.LabelJumlahBeli.TabIndex = 4
        Me.LabelJumlahBeli.Text = "Jumlah Beli"
        '
        'LabelUang
        '
        Me.LabelUang.AutoSize = True
        Me.LabelUang.BackColor = System.Drawing.Color.Transparent
        Me.LabelUang.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUang.ForeColor = System.Drawing.Color.White
        Me.LabelUang.Location = New System.Drawing.Point(731, 150)
        Me.LabelUang.Name = "LabelUang"
        Me.LabelUang.Size = New System.Drawing.Size(211, 31)
        Me.LabelUang.TabIndex = 5
        Me.LabelUang.Text = "Saldo Yang Dimiliki:"
        '
        'BeliBtn
        '
        Me.BeliBtn.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BeliBtn.ForeColor = System.Drawing.Color.SteelBlue
        Me.BeliBtn.Location = New System.Drawing.Point(551, 181)
        Me.BeliBtn.Name = "BeliBtn"
        Me.BeliBtn.Size = New System.Drawing.Size(151, 47)
        Me.BeliBtn.TabIndex = 6
        Me.BeliBtn.Text = "Beli"
        Me.BeliBtn.UseVisualStyleBackColor = True
        '
        'LabelHarga
        '
        Me.LabelHarga.AutoSize = True
        Me.LabelHarga.BackColor = System.Drawing.Color.Transparent
        Me.LabelHarga.Font = New System.Drawing.Font("Montserrat SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHarga.ForeColor = System.Drawing.Color.White
        Me.LabelHarga.Location = New System.Drawing.Point(270, 121)
        Me.LabelHarga.Name = "LabelHarga"
        Me.LabelHarga.Size = New System.Drawing.Size(76, 31)
        Me.LabelHarga.TabIndex = 7
        Me.LabelHarga.Text = "Harga"
        '
        'LabelTotal
        '
        Me.LabelTotal.AutoSize = True
        Me.LabelTotal.BackColor = System.Drawing.Color.Transparent
        Me.LabelTotal.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.ForeColor = System.Drawing.Color.White
        Me.LabelTotal.Location = New System.Drawing.Point(731, 193)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(268, 31)
        Me.LabelTotal.TabIndex = 8
        Me.LabelTotal.Text = "Total yang harus Dibayar:"
        '
        'TextBoxNama
        '
        Me.TextBoxNama.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNama.Location = New System.Drawing.Point(276, 56)
        Me.TextBoxNama.Name = "TextBoxNama"
        Me.TextBoxNama.Size = New System.Drawing.Size(266, 32)
        Me.TextBoxNama.TabIndex = 9
        '
        'BtnReset
        '
        Me.BtnReset.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReset.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnReset.Location = New System.Drawing.Point(581, 53)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(121, 41)
        Me.BtnReset.TabIndex = 10
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnKembali
        '
        Me.BtnKembali.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKembali.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnKembali.Location = New System.Drawing.Point(12, 12)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(146, 40)
        Me.BtnKembali.TabIndex = 11
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'LabelBeliStock
        '
        Me.LabelBeliStock.AutoSize = True
        Me.LabelBeliStock.BackColor = System.Drawing.Color.Transparent
        Me.LabelBeliStock.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBeliStock.ForeColor = System.Drawing.Color.White
        Me.LabelBeliStock.Location = New System.Drawing.Point(270, 191)
        Me.LabelBeliStock.Name = "LabelBeliStock"
        Me.LabelBeliStock.Size = New System.Drawing.Size(232, 31)
        Me.LabelBeliStock.TabIndex = 12
        Me.LabelBeliStock.Text = "Ingin Membeli Stock?"
        '
        'RadioTunai
        '
        Me.RadioTunai.AutoSize = True
        Me.RadioTunai.BackColor = System.Drawing.Color.Transparent
        Me.RadioTunai.Font = New System.Drawing.Font("Montserrat SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioTunai.ForeColor = System.Drawing.Color.White
        Me.RadioTunai.Location = New System.Drawing.Point(746, 107)
        Me.RadioTunai.Name = "RadioTunai"
        Me.RadioTunai.Size = New System.Drawing.Size(93, 35)
        Me.RadioTunai.TabIndex = 13
        Me.RadioTunai.TabStop = True
        Me.RadioTunai.Text = "Tunai"
        Me.RadioTunai.UseVisualStyleBackColor = False
        '
        'RadioBank
        '
        Me.RadioBank.AutoSize = True
        Me.RadioBank.BackColor = System.Drawing.Color.Transparent
        Me.RadioBank.Font = New System.Drawing.Font("Montserrat SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioBank.ForeColor = System.Drawing.Color.White
        Me.RadioBank.Location = New System.Drawing.Point(853, 107)
        Me.RadioBank.Name = "RadioBank"
        Me.RadioBank.Size = New System.Drawing.Size(89, 35)
        Me.RadioBank.TabIndex = 14
        Me.RadioBank.TabStop = True
        Me.RadioBank.Text = "Bank"
        Me.RadioBank.UseVisualStyleBackColor = False
        '
        'ManageStock
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.aksieii
        Me.ClientSize = New System.Drawing.Size(1184, 545)
        Me.Controls.Add(Me.RadioBank)
        Me.Controls.Add(Me.RadioTunai)
        Me.Controls.Add(Me.LabelBeliStock)
        Me.Controls.Add(Me.BtnKembali)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.TextBoxNama)
        Me.Controls.Add(Me.LabelTotal)
        Me.Controls.Add(Me.LabelHarga)
        Me.Controls.Add(Me.BeliBtn)
        Me.Controls.Add(Me.LabelUang)
        Me.Controls.Add(Me.LabelJumlahBeli)
        Me.Controls.Add(Me.NumericBeli)
        Me.Controls.Add(Me.LabelNama)
        Me.Controls.Add(Me.PanelDataStock)
        Me.Name = "ManageStock"
        Me.Text = "ManageStock"
        CType(Me.PanelDataStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericBeli, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelDataStock As DataGridView
    Friend WithEvents LabelNama As Label
    Friend WithEvents NumericBeli As NumericUpDown
    Friend WithEvents LabelJumlahBeli As Label
    Friend WithEvents LabelUang As Label
    Friend WithEvents BeliBtn As Button
    Friend WithEvents LabelHarga As Label
    Friend WithEvents LabelTotal As Label
    Friend WithEvents TextBoxNama As TextBox
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnKembali As Button
    Friend WithEvents LabelBeliStock As Label
    Friend WithEvents RadioTunai As RadioButton
    Friend WithEvents RadioBank As RadioButton
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents HargaBeli As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents Warna As DataGridViewTextBoxColumn
    Friend WithEvents Ukuran As DataGridViewTextBoxColumn
End Class
