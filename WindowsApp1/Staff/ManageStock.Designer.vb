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
        Me.PanelDataStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PanelDataStock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nama, Me.HargaBeli, Me.Stock, Me.Warna, Me.Ukuran})
        Me.PanelDataStock.Location = New System.Drawing.Point(32, 257)
        Me.PanelDataStock.Name = "PanelDataStock"
        Me.PanelDataStock.RowHeadersWidth = 51
        Me.PanelDataStock.RowTemplate.Height = 24
        Me.PanelDataStock.Size = New System.Drawing.Size(1420, 270)
        Me.PanelDataStock.TabIndex = 0
        '
        'Nama
        '
        Me.Nama.HeaderText = "Nama Barang"
        Me.Nama.MinimumWidth = 6
        Me.Nama.Name = "Nama"
        Me.Nama.Width = 125
        '
        'HargaBeli
        '
        Me.HargaBeli.HeaderText = "Harga Beli"
        Me.HargaBeli.MinimumWidth = 6
        Me.HargaBeli.Name = "HargaBeli"
        Me.HargaBeli.Width = 125
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock Barang"
        Me.Stock.MinimumWidth = 6
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 125
        '
        'Warna
        '
        Me.Warna.HeaderText = "Warna "
        Me.Warna.MinimumWidth = 6
        Me.Warna.Name = "Warna"
        Me.Warna.Width = 125
        '
        'Ukuran
        '
        Me.Ukuran.HeaderText = "Ukuran"
        Me.Ukuran.MinimumWidth = 6
        Me.Ukuran.Name = "Ukuran"
        Me.Ukuran.Width = 125
        '
        'LabelNama
        '
        Me.LabelNama.AutoSize = True
        Me.LabelNama.Location = New System.Drawing.Point(128, 68)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(91, 16)
        Me.LabelNama.TabIndex = 1
        Me.LabelNama.Text = "Nama Barang"
        '
        'NumericBeli
        '
        Me.NumericBeli.Location = New System.Drawing.Point(868, 62)
        Me.NumericBeli.Name = "NumericBeli"
        Me.NumericBeli.Size = New System.Drawing.Size(154, 22)
        Me.NumericBeli.TabIndex = 3
        '
        'LabelJumlahBeli
        '
        Me.LabelJumlahBeli.AutoSize = True
        Me.LabelJumlahBeli.Location = New System.Drawing.Point(743, 67)
        Me.LabelJumlahBeli.Name = "LabelJumlahBeli"
        Me.LabelJumlahBeli.Size = New System.Drawing.Size(76, 16)
        Me.LabelJumlahBeli.TabIndex = 4
        Me.LabelJumlahBeli.Text = "Jumlah Beli"
        '
        'LabelUang
        '
        Me.LabelUang.AutoSize = True
        Me.LabelUang.Location = New System.Drawing.Point(743, 148)
        Me.LabelUang.Name = "LabelUang"
        Me.LabelUang.Size = New System.Drawing.Size(127, 16)
        Me.LabelUang.TabIndex = 5
        Me.LabelUang.Text = "Saldo Yang Dimiliki:"
        '
        'BeliBtn
        '
        Me.BeliBtn.Location = New System.Drawing.Point(297, 214)
        Me.BeliBtn.Name = "BeliBtn"
        Me.BeliBtn.Size = New System.Drawing.Size(75, 23)
        Me.BeliBtn.TabIndex = 6
        Me.BeliBtn.Text = "Beli"
        Me.BeliBtn.UseVisualStyleBackColor = True
        '
        'LabelHarga
        '
        Me.LabelHarga.AutoSize = True
        Me.LabelHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHarga.Location = New System.Drawing.Point(258, 139)
        Me.LabelHarga.Name = "LabelHarga"
        Me.LabelHarga.Size = New System.Drawing.Size(65, 25)
        Me.LabelHarga.TabIndex = 7
        Me.LabelHarga.Text = "Harga"
        '
        'LabelTotal
        '
        Me.LabelTotal.AutoSize = True
        Me.LabelTotal.Location = New System.Drawing.Point(743, 184)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(161, 16)
        Me.LabelTotal.TabIndex = 8
        Me.LabelTotal.Text = "Total yang harus Dibayar:"
        '
        'TextBoxNama
        '
        Me.TextBoxNama.Location = New System.Drawing.Point(263, 62)
        Me.TextBoxNama.Name = "TextBoxNama"
        Me.TextBoxNama.Size = New System.Drawing.Size(284, 22)
        Me.TextBoxNama.TabIndex = 9
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(577, 68)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(75, 23)
        Me.BtnReset.TabIndex = 10
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnKembali
        '
        Me.BtnKembali.Location = New System.Drawing.Point(41, 13)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(75, 23)
        Me.BtnKembali.TabIndex = 11
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'LabelBeliStock
        '
        Me.LabelBeliStock.AutoSize = True
        Me.LabelBeliStock.Location = New System.Drawing.Point(260, 184)
        Me.LabelBeliStock.Name = "LabelBeliStock"
        Me.LabelBeliStock.Size = New System.Drawing.Size(134, 16)
        Me.LabelBeliStock.TabIndex = 12
        Me.LabelBeliStock.Text = "Ingin Membeli Stock?"
        '
        'RadioTunai
        '
        Me.RadioTunai.AutoSize = True
        Me.RadioTunai.Location = New System.Drawing.Point(746, 101)
        Me.RadioTunai.Name = "RadioTunai"
        Me.RadioTunai.Size = New System.Drawing.Size(62, 20)
        Me.RadioTunai.TabIndex = 13
        Me.RadioTunai.TabStop = True
        Me.RadioTunai.Text = "Tunai"
        Me.RadioTunai.UseVisualStyleBackColor = True
        '
        'RadioBank
        '
        Me.RadioBank.AutoSize = True
        Me.RadioBank.Location = New System.Drawing.Point(842, 101)
        Me.RadioBank.Name = "RadioBank"
        Me.RadioBank.Size = New System.Drawing.Size(59, 20)
        Me.RadioBank.TabIndex = 14
        Me.RadioBank.TabStop = True
        Me.RadioBank.Text = "Bank"
        Me.RadioBank.UseVisualStyleBackColor = True
        '
        'ManageStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1477, 548)
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
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents HargaBeli As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents Warna As DataGridViewTextBoxColumn
    Friend WithEvents Ukuran As DataGridViewTextBoxColumn
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
End Class
