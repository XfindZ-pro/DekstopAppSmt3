<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ManageBarang
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
        Me.LabelID = New System.Windows.Forms.Label()
        Me.LabelNama = New System.Windows.Forms.Label()
        Me.LabelKategori = New System.Windows.Forms.Label()
        Me.LabelSatuan = New System.Windows.Forms.Label()
        Me.LabelHargaBeli = New System.Windows.Forms.Label()
        Me.LabelHargaJual = New System.Windows.Forms.Label()
        Me.LabelStock = New System.Windows.Forms.Label()
        Me.BtnBaru = New System.Windows.Forms.Button()
        Me.BtnUbah = New System.Windows.Forms.Button()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.TextIDBarang = New System.Windows.Forms.TextBox()
        Me.TextNamaBarang = New System.Windows.Forms.TextBox()
        Me.TextSatuanBarang = New System.Windows.Forms.TextBox()
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.DBstatus = New System.Windows.Forms.Label()
        Me.NumericHargaBeli = New System.Windows.Forms.NumericUpDown()
        Me.NumericHargaJual = New System.Windows.Forms.NumericUpDown()
        Me.NumericStock = New System.Windows.Forms.NumericUpDown()
        Me.PanelDataBarang = New System.Windows.Forms.DataGridView()
        Me.IdBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kategori = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Satuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HargaBeli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HargaJual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rak = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warna = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ukuran = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kategoriBarang = New System.Windows.Forms.ComboBox()
        Me.rakBarang = New System.Windows.Forms.ComboBox()
        Me.LabelRak = New System.Windows.Forms.Label()
        Me.TextSupplierBarang = New System.Windows.Forms.TextBox()
        Me.LabelSupplier = New System.Windows.Forms.Label()
        Me.LabelWarnaBarang = New System.Windows.Forms.Label()
        Me.TextWarnaBarang = New System.Windows.Forms.TextBox()
        Me.LabelUkuranBarang = New System.Windows.Forms.Label()
        Me.TextUkuranBarang = New System.Windows.Forms.TextBox()
        Me.TextPencarian = New System.Windows.Forms.TextBox()
        Me.LabelCariBarang = New System.Windows.Forms.Label()
        CType(Me.NumericHargaBeli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericHargaJual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelDataBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelID
        '
        Me.LabelID.Location = New System.Drawing.Point(28, 48)
        Me.LabelID.Name = "LabelID"
        Me.LabelID.Size = New System.Drawing.Size(180, 33)
        Me.LabelID.TabIndex = 0
        Me.LabelID.Text = "ID Barang"
        '
        'LabelNama
        '
        Me.LabelNama.Location = New System.Drawing.Point(28, 92)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(180, 33)
        Me.LabelNama.TabIndex = 1
        Me.LabelNama.Text = "Nama Barang"
        '
        'LabelKategori
        '
        Me.LabelKategori.Location = New System.Drawing.Point(28, 135)
        Me.LabelKategori.Name = "LabelKategori"
        Me.LabelKategori.Size = New System.Drawing.Size(180, 33)
        Me.LabelKategori.TabIndex = 2
        Me.LabelKategori.Text = "Kategori Barang"
        '
        'LabelSatuan
        '
        Me.LabelSatuan.Location = New System.Drawing.Point(28, 230)
        Me.LabelSatuan.Name = "LabelSatuan"
        Me.LabelSatuan.Size = New System.Drawing.Size(180, 33)
        Me.LabelSatuan.TabIndex = 3
        Me.LabelSatuan.Text = "Satuan Barang"
        '
        'LabelHargaBeli
        '
        Me.LabelHargaBeli.Location = New System.Drawing.Point(620, 48)
        Me.LabelHargaBeli.Name = "LabelHargaBeli"
        Me.LabelHargaBeli.Size = New System.Drawing.Size(180, 33)
        Me.LabelHargaBeli.TabIndex = 4
        Me.LabelHargaBeli.Text = "Harga Beli"
        '
        'LabelHargaJual
        '
        Me.LabelHargaJual.Location = New System.Drawing.Point(620, 92)
        Me.LabelHargaJual.Name = "LabelHargaJual"
        Me.LabelHargaJual.Size = New System.Drawing.Size(180, 33)
        Me.LabelHargaJual.TabIndex = 5
        Me.LabelHargaJual.Text = "Harga Jual"
        '
        'LabelStock
        '
        Me.LabelStock.Location = New System.Drawing.Point(620, 125)
        Me.LabelStock.Name = "LabelStock"
        Me.LabelStock.Size = New System.Drawing.Size(180, 33)
        Me.LabelStock.TabIndex = 6
        Me.LabelStock.Text = "Stok Awal"
        '
        'BtnBaru
        '
        Me.BtnBaru.Location = New System.Drawing.Point(623, 205)
        Me.BtnBaru.Name = "BtnBaru"
        Me.BtnBaru.Size = New System.Drawing.Size(75, 23)
        Me.BtnBaru.TabIndex = 7
        Me.BtnBaru.Text = "Baru"
        Me.BtnBaru.UseVisualStyleBackColor = True
        '
        'BtnUbah
        '
        Me.BtnUbah.Location = New System.Drawing.Point(740, 205)
        Me.BtnUbah.Name = "BtnUbah"
        Me.BtnUbah.Size = New System.Drawing.Size(75, 23)
        Me.BtnUbah.TabIndex = 8
        Me.BtnUbah.Text = "Ubah"
        Me.BtnUbah.UseVisualStyleBackColor = True
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Location = New System.Drawing.Point(852, 205)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(75, 23)
        Me.BtnSimpan.TabIndex = 9
        Me.BtnSimpan.Text = "Simpan"
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'BtnHapus
        '
        Me.BtnHapus.Location = New System.Drawing.Point(962, 205)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(75, 23)
        Me.BtnHapus.TabIndex = 10
        Me.BtnHapus.Text = "Hapus"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'TextIDBarang
        '
        Me.TextIDBarang.Location = New System.Drawing.Point(172, 45)
        Me.TextIDBarang.Name = "TextIDBarang"
        Me.TextIDBarang.ReadOnly = True
        Me.TextIDBarang.Size = New System.Drawing.Size(223, 22)
        Me.TextIDBarang.TabIndex = 12
        '
        'TextNamaBarang
        '
        Me.TextNamaBarang.Location = New System.Drawing.Point(172, 84)
        Me.TextNamaBarang.Name = "TextNamaBarang"
        Me.TextNamaBarang.Size = New System.Drawing.Size(223, 22)
        Me.TextNamaBarang.TabIndex = 13
        '
        'TextSatuanBarang
        '
        Me.TextSatuanBarang.Location = New System.Drawing.Point(172, 230)
        Me.TextSatuanBarang.Name = "TextSatuanBarang"
        Me.TextSatuanBarang.Size = New System.Drawing.Size(223, 22)
        Me.TextSatuanBarang.TabIndex = 15
        '
        'BtnKembali
        '
        Me.BtnKembali.Location = New System.Drawing.Point(13, 13)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(133, 32)
        Me.BtnKembali.TabIndex = 19
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'DBstatus
        '
        Me.DBstatus.AutoSize = True
        Me.DBstatus.Location = New System.Drawing.Point(1153, 9)
        Me.DBstatus.Name = "DBstatus"
        Me.DBstatus.Size = New System.Drawing.Size(67, 16)
        Me.DBstatus.TabIndex = 20
        Me.DBstatus.Text = "Database"
        '
        'NumericHargaBeli
        '
        Me.NumericHargaBeli.Location = New System.Drawing.Point(756, 46)
        Me.NumericHargaBeli.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.NumericHargaBeli.Name = "NumericHargaBeli"
        Me.NumericHargaBeli.Size = New System.Drawing.Size(120, 22)
        Me.NumericHargaBeli.TabIndex = 21
        '
        'NumericHargaJual
        '
        Me.NumericHargaJual.Location = New System.Drawing.Point(756, 90)
        Me.NumericHargaJual.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.NumericHargaJual.Name = "NumericHargaJual"
        Me.NumericHargaJual.Size = New System.Drawing.Size(120, 22)
        Me.NumericHargaJual.TabIndex = 22
        '
        'NumericStock
        '
        Me.NumericStock.Location = New System.Drawing.Point(756, 128)
        Me.NumericStock.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericStock.Name = "NumericStock"
        Me.NumericStock.Size = New System.Drawing.Size(120, 22)
        Me.NumericStock.TabIndex = 23
        '
        'PanelDataBarang
        '
        Me.PanelDataBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PanelDataBarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdBarang, Me.Nama, Me.Kategori, Me.Satuan, Me.HargaBeli, Me.HargaJual, Me.Stock, Me.Rak, Me.Supplier, Me.Warna, Me.Ukuran})
        Me.PanelDataBarang.Location = New System.Drawing.Point(31, 283)
        Me.PanelDataBarang.Name = "PanelDataBarang"
        Me.PanelDataBarang.RowHeadersWidth = 51
        Me.PanelDataBarang.RowTemplate.Height = 24
        Me.PanelDataBarang.Size = New System.Drawing.Size(1297, 246)
        Me.PanelDataBarang.TabIndex = 24
        '
        'IdBarang
        '
        Me.IdBarang.HeaderText = "ID Barang"
        Me.IdBarang.MinimumWidth = 6
        Me.IdBarang.Name = "IdBarang"
        Me.IdBarang.Width = 125
        '
        'Nama
        '
        Me.Nama.HeaderText = "Nama"
        Me.Nama.MinimumWidth = 6
        Me.Nama.Name = "Nama"
        Me.Nama.Width = 125
        '
        'Kategori
        '
        Me.Kategori.HeaderText = "Kategori"
        Me.Kategori.MinimumWidth = 6
        Me.Kategori.Name = "Kategori"
        Me.Kategori.Width = 125
        '
        'Satuan
        '
        Me.Satuan.HeaderText = "Satuan"
        Me.Satuan.MinimumWidth = 6
        Me.Satuan.Name = "Satuan"
        Me.Satuan.Width = 125
        '
        'HargaBeli
        '
        Me.HargaBeli.HeaderText = "Harga Beli"
        Me.HargaBeli.MinimumWidth = 6
        Me.HargaBeli.Name = "HargaBeli"
        Me.HargaBeli.Width = 125
        '
        'HargaJual
        '
        Me.HargaJual.HeaderText = "Harga Jual"
        Me.HargaJual.MinimumWidth = 6
        Me.HargaJual.Name = "HargaJual"
        Me.HargaJual.Width = 125
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock"
        Me.Stock.MinimumWidth = 6
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 125
        '
        'Rak
        '
        Me.Rak.HeaderText = "Rak"
        Me.Rak.MinimumWidth = 6
        Me.Rak.Name = "Rak"
        Me.Rak.Width = 125
        '
        'Supplier
        '
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.MinimumWidth = 6
        Me.Supplier.Name = "Supplier"
        Me.Supplier.Width = 125
        '
        'Warna
        '
        Me.Warna.HeaderText = "Warna"
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
        'kategoriBarang
        '
        Me.kategoriBarang.FormattingEnabled = True
        Me.kategoriBarang.Location = New System.Drawing.Point(172, 135)
        Me.kategoriBarang.Name = "kategoriBarang"
        Me.kategoriBarang.Size = New System.Drawing.Size(223, 24)
        Me.kategoriBarang.TabIndex = 25
        '
        'rakBarang
        '
        Me.rakBarang.FormattingEnabled = True
        Me.rakBarang.Location = New System.Drawing.Point(172, 185)
        Me.rakBarang.Name = "rakBarang"
        Me.rakBarang.Size = New System.Drawing.Size(223, 24)
        Me.rakBarang.TabIndex = 28
        '
        'LabelRak
        '
        Me.LabelRak.Location = New System.Drawing.Point(28, 185)
        Me.LabelRak.Name = "LabelRak"
        Me.LabelRak.Size = New System.Drawing.Size(180, 33)
        Me.LabelRak.TabIndex = 27
        Me.LabelRak.Text = "Rak Barang"
        '
        'TextSupplierBarang
        '
        Me.TextSupplierBarang.Location = New System.Drawing.Point(1067, 48)
        Me.TextSupplierBarang.Name = "TextSupplierBarang"
        Me.TextSupplierBarang.Size = New System.Drawing.Size(223, 22)
        Me.TextSupplierBarang.TabIndex = 30
        '
        'LabelSupplier
        '
        Me.LabelSupplier.Location = New System.Drawing.Point(923, 48)
        Me.LabelSupplier.Name = "LabelSupplier"
        Me.LabelSupplier.Size = New System.Drawing.Size(180, 33)
        Me.LabelSupplier.TabIndex = 29
        Me.LabelSupplier.Text = "Supplier Barang"
        '
        'LabelWarnaBarang
        '
        Me.LabelWarnaBarang.Location = New System.Drawing.Point(923, 84)
        Me.LabelWarnaBarang.Name = "LabelWarnaBarang"
        Me.LabelWarnaBarang.Size = New System.Drawing.Size(114, 33)
        Me.LabelWarnaBarang.TabIndex = 31
        Me.LabelWarnaBarang.Text = "Warna Barang"
        '
        'TextWarnaBarang
        '
        Me.TextWarnaBarang.Location = New System.Drawing.Point(1067, 84)
        Me.TextWarnaBarang.Name = "TextWarnaBarang"
        Me.TextWarnaBarang.Size = New System.Drawing.Size(223, 22)
        Me.TextWarnaBarang.TabIndex = 32
        '
        'LabelUkuranBarang
        '
        Me.LabelUkuranBarang.Location = New System.Drawing.Point(923, 117)
        Me.LabelUkuranBarang.Name = "LabelUkuranBarang"
        Me.LabelUkuranBarang.Size = New System.Drawing.Size(114, 33)
        Me.LabelUkuranBarang.TabIndex = 33
        Me.LabelUkuranBarang.Text = "Ukuran Barang"
        '
        'TextUkuranBarang
        '
        Me.TextUkuranBarang.Location = New System.Drawing.Point(1067, 122)
        Me.TextUkuranBarang.Name = "TextUkuranBarang"
        Me.TextUkuranBarang.Size = New System.Drawing.Size(223, 22)
        Me.TextUkuranBarang.TabIndex = 34
        '
        'TextPencarian
        '
        Me.TextPencarian.Location = New System.Drawing.Point(623, 241)
        Me.TextPencarian.Name = "TextPencarian"
        Me.TextPencarian.Size = New System.Drawing.Size(223, 22)
        Me.TextPencarian.TabIndex = 35
        '
        'LabelCariBarang
        '
        Me.LabelCariBarang.AutoSize = True
        Me.LabelCariBarang.Location = New System.Drawing.Point(517, 247)
        Me.LabelCariBarang.Name = "LabelCariBarang"
        Me.LabelCariBarang.Size = New System.Drawing.Size(81, 16)
        Me.LabelCariBarang.TabIndex = 36
        Me.LabelCariBarang.Text = "Cari Barang:"
        '
        'ManageBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 541)
        Me.Controls.Add(Me.LabelCariBarang)
        Me.Controls.Add(Me.TextPencarian)
        Me.Controls.Add(Me.TextUkuranBarang)
        Me.Controls.Add(Me.LabelUkuranBarang)
        Me.Controls.Add(Me.TextWarnaBarang)
        Me.Controls.Add(Me.LabelWarnaBarang)
        Me.Controls.Add(Me.TextSupplierBarang)
        Me.Controls.Add(Me.LabelSupplier)
        Me.Controls.Add(Me.rakBarang)
        Me.Controls.Add(Me.LabelRak)
        Me.Controls.Add(Me.kategoriBarang)
        Me.Controls.Add(Me.PanelDataBarang)
        Me.Controls.Add(Me.NumericStock)
        Me.Controls.Add(Me.NumericHargaJual)
        Me.Controls.Add(Me.NumericHargaBeli)
        Me.Controls.Add(Me.DBstatus)
        Me.Controls.Add(Me.BtnKembali)
        Me.Controls.Add(Me.TextSatuanBarang)
        Me.Controls.Add(Me.TextNamaBarang)
        Me.Controls.Add(Me.TextIDBarang)
        Me.Controls.Add(Me.BtnHapus)
        Me.Controls.Add(Me.BtnSimpan)
        Me.Controls.Add(Me.BtnUbah)
        Me.Controls.Add(Me.BtnBaru)
        Me.Controls.Add(Me.LabelStock)
        Me.Controls.Add(Me.LabelHargaJual)
        Me.Controls.Add(Me.LabelHargaBeli)
        Me.Controls.Add(Me.LabelSatuan)
        Me.Controls.Add(Me.LabelKategori)
        Me.Controls.Add(Me.LabelNama)
        Me.Controls.Add(Me.LabelID)
        Me.Name = "ManageBarang"
        Me.Text = "ManageBarang"
        CType(Me.NumericHargaBeli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericHargaJual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelDataBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelID As Label
    Friend WithEvents LabelNama As Label
    Friend WithEvents LabelKategori As Label
    Friend WithEvents LabelSatuan As Label
    Friend WithEvents LabelHargaBeli As Label
    Friend WithEvents LabelHargaJual As Label
    Friend WithEvents LabelStock As Label
    Friend WithEvents BtnBaru As Button
    Friend WithEvents BtnUbah As Button
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents TextIDBarang As TextBox
    Friend WithEvents TextNamaBarang As TextBox
    Friend WithEvents TextSatuanBarang As TextBox
    Friend WithEvents BtnKembali As Button
    Friend WithEvents DBstatus As Label
    Friend WithEvents NumericHargaBeli As NumericUpDown
    Friend WithEvents NumericHargaJual As NumericUpDown
    Friend WithEvents NumericStock As NumericUpDown
    Friend WithEvents PanelDataBarang As DataGridView
    Friend WithEvents kategoriBarang As ComboBox
    Friend WithEvents rakBarang As ComboBox
    Friend WithEvents LabelRak As Label
    Friend WithEvents TextSupplierBarang As TextBox
    Friend WithEvents LabelSupplier As Label
    Friend WithEvents LabelWarnaBarang As Label
    Friend WithEvents TextWarnaBarang As TextBox
    Friend WithEvents LabelUkuranBarang As Label
    Friend WithEvents TextUkuranBarang As TextBox
    Friend WithEvents IdBarang As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Kategori As DataGridViewTextBoxColumn
    Friend WithEvents Satuan As DataGridViewTextBoxColumn
    Friend WithEvents HargaBeli As DataGridViewTextBoxColumn
    Friend WithEvents HargaJual As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents Rak As DataGridViewTextBoxColumn
    Friend WithEvents Supplier As DataGridViewTextBoxColumn
    Friend WithEvents Warna As DataGridViewTextBoxColumn
    Friend WithEvents Ukuran As DataGridViewTextBoxColumn
    Friend WithEvents TextPencarian As TextBox
    Friend WithEvents LabelCariBarang As Label
End Class
