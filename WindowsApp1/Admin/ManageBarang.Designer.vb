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
        Me.LabelID.BackColor = System.Drawing.Color.Transparent
        Me.LabelID.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelID.ForeColor = System.Drawing.Color.White
        Me.LabelID.Location = New System.Drawing.Point(46, 47)
        Me.LabelID.Name = "LabelID"
        Me.LabelID.Size = New System.Drawing.Size(180, 33)
        Me.LabelID.TabIndex = 0
        Me.LabelID.Text = "ID Barang"
        '
        'LabelNama
        '
        Me.LabelNama.BackColor = System.Drawing.Color.Transparent
        Me.LabelNama.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNama.ForeColor = System.Drawing.Color.White
        Me.LabelNama.Location = New System.Drawing.Point(46, 91)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(180, 33)
        Me.LabelNama.TabIndex = 1
        Me.LabelNama.Text = "Nama Barang"
        '
        'LabelKategori
        '
        Me.LabelKategori.BackColor = System.Drawing.Color.Transparent
        Me.LabelKategori.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelKategori.ForeColor = System.Drawing.Color.White
        Me.LabelKategori.Location = New System.Drawing.Point(46, 134)
        Me.LabelKategori.Name = "LabelKategori"
        Me.LabelKategori.Size = New System.Drawing.Size(180, 33)
        Me.LabelKategori.TabIndex = 2
        Me.LabelKategori.Text = "Kategori Barang"
        '
        'LabelSatuan
        '
        Me.LabelSatuan.BackColor = System.Drawing.Color.Transparent
        Me.LabelSatuan.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSatuan.ForeColor = System.Drawing.Color.White
        Me.LabelSatuan.Location = New System.Drawing.Point(46, 229)
        Me.LabelSatuan.Name = "LabelSatuan"
        Me.LabelSatuan.Size = New System.Drawing.Size(180, 33)
        Me.LabelSatuan.TabIndex = 3
        Me.LabelSatuan.Text = "Satuan Barang"
        '
        'LabelHargaBeli
        '
        Me.LabelHargaBeli.BackColor = System.Drawing.Color.Transparent
        Me.LabelHargaBeli.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHargaBeli.ForeColor = System.Drawing.Color.White
        Me.LabelHargaBeli.Location = New System.Drawing.Point(486, 41)
        Me.LabelHargaBeli.Name = "LabelHargaBeli"
        Me.LabelHargaBeli.Size = New System.Drawing.Size(180, 33)
        Me.LabelHargaBeli.TabIndex = 4
        Me.LabelHargaBeli.Text = "Harga Beli"
        '
        'LabelHargaJual
        '
        Me.LabelHargaJual.BackColor = System.Drawing.Color.Transparent
        Me.LabelHargaJual.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHargaJual.ForeColor = System.Drawing.Color.White
        Me.LabelHargaJual.Location = New System.Drawing.Point(486, 87)
        Me.LabelHargaJual.Name = "LabelHargaJual"
        Me.LabelHargaJual.Size = New System.Drawing.Size(180, 33)
        Me.LabelHargaJual.TabIndex = 5
        Me.LabelHargaJual.Text = "Harga Jual"
        '
        'LabelStock
        '
        Me.LabelStock.BackColor = System.Drawing.Color.Transparent
        Me.LabelStock.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStock.ForeColor = System.Drawing.Color.White
        Me.LabelStock.Location = New System.Drawing.Point(486, 135)
        Me.LabelStock.Name = "LabelStock"
        Me.LabelStock.Size = New System.Drawing.Size(180, 33)
        Me.LabelStock.TabIndex = 6
        Me.LabelStock.Text = "Stok Awal"
        '
        'BtnBaru
        '
        Me.BtnBaru.Font = New System.Drawing.Font("Montserrat", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBaru.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnBaru.Location = New System.Drawing.Point(562, 184)
        Me.BtnBaru.Name = "BtnBaru"
        Me.BtnBaru.Size = New System.Drawing.Size(75, 40)
        Me.BtnBaru.TabIndex = 7
        Me.BtnBaru.Text = "Baru"
        Me.BtnBaru.UseVisualStyleBackColor = True
        '
        'BtnUbah
        '
        Me.BtnUbah.Font = New System.Drawing.Font("Montserrat", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUbah.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnUbah.Location = New System.Drawing.Point(679, 184)
        Me.BtnUbah.Name = "BtnUbah"
        Me.BtnUbah.Size = New System.Drawing.Size(75, 40)
        Me.BtnUbah.TabIndex = 8
        Me.BtnUbah.Text = "Ubah"
        Me.BtnUbah.UseVisualStyleBackColor = True
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Font = New System.Drawing.Font("Montserrat", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSimpan.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnSimpan.Location = New System.Drawing.Point(785, 184)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(91, 40)
        Me.BtnSimpan.TabIndex = 9
        Me.BtnSimpan.Text = "Simpan"
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'BtnHapus
        '
        Me.BtnHapus.Font = New System.Drawing.Font("Montserrat", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHapus.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnHapus.Location = New System.Drawing.Point(901, 184)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(75, 40)
        Me.BtnHapus.TabIndex = 10
        Me.BtnHapus.Text = "Hapus"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'TextIDBarang
        '
        Me.TextIDBarang.Location = New System.Drawing.Point(247, 48)
        Me.TextIDBarang.Name = "TextIDBarang"
        Me.TextIDBarang.ReadOnly = True
        Me.TextIDBarang.Size = New System.Drawing.Size(223, 22)
        Me.TextIDBarang.TabIndex = 12
        '
        'TextNamaBarang
        '
        Me.TextNamaBarang.Location = New System.Drawing.Point(247, 87)
        Me.TextNamaBarang.Name = "TextNamaBarang"
        Me.TextNamaBarang.Size = New System.Drawing.Size(223, 22)
        Me.TextNamaBarang.TabIndex = 13
        '
        'TextSatuanBarang
        '
        Me.TextSatuanBarang.Location = New System.Drawing.Point(247, 233)
        Me.TextSatuanBarang.Name = "TextSatuanBarang"
        Me.TextSatuanBarang.Size = New System.Drawing.Size(223, 22)
        Me.TextSatuanBarang.TabIndex = 15
        '
        'BtnKembali
        '
        Me.BtnKembali.Font = New System.Drawing.Font("Montserrat", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKembali.Location = New System.Drawing.Point(12, 5)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(133, 32)
        Me.BtnKembali.TabIndex = 19
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'DBstatus
        '
        Me.DBstatus.AutoSize = True
        Me.DBstatus.BackColor = System.Drawing.Color.Transparent
        Me.DBstatus.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DBstatus.ForeColor = System.Drawing.Color.White
        Me.DBstatus.Location = New System.Drawing.Point(1050, 9)
        Me.DBstatus.Name = "DBstatus"
        Me.DBstatus.Size = New System.Drawing.Size(114, 31)
        Me.DBstatus.TabIndex = 20
        Me.DBstatus.Text = "Database"
        '
        'NumericHargaBeli
        '
        Me.NumericHargaBeli.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericHargaBeli.Location = New System.Drawing.Point(648, 40)
        Me.NumericHargaBeli.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.NumericHargaBeli.Name = "NumericHargaBeli"
        Me.NumericHargaBeli.Size = New System.Drawing.Size(120, 32)
        Me.NumericHargaBeli.TabIndex = 21
        '
        'NumericHargaJual
        '
        Me.NumericHargaJual.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericHargaJual.Location = New System.Drawing.Point(648, 87)
        Me.NumericHargaJual.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.NumericHargaJual.Name = "NumericHargaJual"
        Me.NumericHargaJual.Size = New System.Drawing.Size(120, 32)
        Me.NumericHargaJual.TabIndex = 22
        '
        'NumericStock
        '
        Me.NumericStock.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericStock.Location = New System.Drawing.Point(648, 135)
        Me.NumericStock.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericStock.Name = "NumericStock"
        Me.NumericStock.Size = New System.Drawing.Size(120, 32)
        Me.NumericStock.TabIndex = 23
        '
        'PanelDataBarang
        '
        Me.PanelDataBarang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.PanelDataBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PanelDataBarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdBarang, Me.Nama, Me.Kategori, Me.Satuan, Me.HargaBeli, Me.HargaJual, Me.Stock, Me.Rak, Me.Supplier, Me.Warna, Me.Ukuran})
        Me.PanelDataBarang.Location = New System.Drawing.Point(31, 283)
        Me.PanelDataBarang.Name = "PanelDataBarang"
        Me.PanelDataBarang.RowHeadersWidth = 51
        Me.PanelDataBarang.RowTemplate.Height = 24
        Me.PanelDataBarang.Size = New System.Drawing.Size(1169, 246)
        Me.PanelDataBarang.TabIndex = 24
        '
        'IdBarang
        '
        Me.IdBarang.FillWeight = 123.2079!
        Me.IdBarang.HeaderText = "ID Barang"
        Me.IdBarang.MinimumWidth = 6
        Me.IdBarang.Name = "IdBarang"
        '
        'Nama
        '
        Me.Nama.FillWeight = 116.838!
        Me.Nama.HeaderText = "Nama"
        Me.Nama.MinimumWidth = 6
        Me.Nama.Name = "Nama"
        '
        'Kategori
        '
        Me.Kategori.FillWeight = 111.1815!
        Me.Kategori.HeaderText = "Kategori"
        Me.Kategori.MinimumWidth = 6
        Me.Kategori.Name = "Kategori"
        '
        'Satuan
        '
        Me.Satuan.FillWeight = 106.1586!
        Me.Satuan.HeaderText = "Satuan"
        Me.Satuan.MinimumWidth = 6
        Me.Satuan.Name = "Satuan"
        '
        'HargaBeli
        '
        Me.HargaBeli.FillWeight = 101.6984!
        Me.HargaBeli.HeaderText = "Harga Beli"
        Me.HargaBeli.MinimumWidth = 6
        Me.HargaBeli.Name = "HargaBeli"
        '
        'HargaJual
        '
        Me.HargaJual.FillWeight = 97.73765!
        Me.HargaJual.HeaderText = "Harga Jual"
        Me.HargaJual.MinimumWidth = 6
        Me.HargaJual.Name = "HargaJual"
        '
        'Stock
        '
        Me.Stock.FillWeight = 94.22057!
        Me.Stock.HeaderText = "Stock"
        Me.Stock.MinimumWidth = 6
        Me.Stock.Name = "Stock"
        '
        'Rak
        '
        Me.Rak.FillWeight = 91.09743!
        Me.Rak.HeaderText = "Rak"
        Me.Rak.MinimumWidth = 6
        Me.Rak.Name = "Rak"
        '
        'Supplier
        '
        Me.Supplier.FillWeight = 88.32411!
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.MinimumWidth = 6
        Me.Supplier.Name = "Supplier"
        '
        'Warna
        '
        Me.Warna.FillWeight = 85.86142!
        Me.Warna.HeaderText = "Warna"
        Me.Warna.MinimumWidth = 6
        Me.Warna.Name = "Warna"
        '
        'Ukuran
        '
        Me.Ukuran.FillWeight = 83.67457!
        Me.Ukuran.HeaderText = "Ukuran"
        Me.Ukuran.MinimumWidth = 6
        Me.Ukuran.Name = "Ukuran"
        '
        'kategoriBarang
        '
        Me.kategoriBarang.FormattingEnabled = True
        Me.kategoriBarang.Location = New System.Drawing.Point(247, 138)
        Me.kategoriBarang.Name = "kategoriBarang"
        Me.kategoriBarang.Size = New System.Drawing.Size(223, 24)
        Me.kategoriBarang.TabIndex = 25
        '
        'rakBarang
        '
        Me.rakBarang.FormattingEnabled = True
        Me.rakBarang.Location = New System.Drawing.Point(247, 188)
        Me.rakBarang.Name = "rakBarang"
        Me.rakBarang.Size = New System.Drawing.Size(223, 24)
        Me.rakBarang.TabIndex = 28
        '
        'LabelRak
        '
        Me.LabelRak.BackColor = System.Drawing.Color.Transparent
        Me.LabelRak.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRak.ForeColor = System.Drawing.Color.White
        Me.LabelRak.Location = New System.Drawing.Point(46, 184)
        Me.LabelRak.Name = "LabelRak"
        Me.LabelRak.Size = New System.Drawing.Size(180, 33)
        Me.LabelRak.TabIndex = 27
        Me.LabelRak.Text = "Rak Barang"
        '
        'TextSupplierBarang
        '
        Me.TextSupplierBarang.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSupplierBarang.Location = New System.Drawing.Point(982, 46)
        Me.TextSupplierBarang.Name = "TextSupplierBarang"
        Me.TextSupplierBarang.Size = New System.Drawing.Size(223, 32)
        Me.TextSupplierBarang.TabIndex = 30
        '
        'LabelSupplier
        '
        Me.LabelSupplier.BackColor = System.Drawing.Color.Transparent
        Me.LabelSupplier.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSupplier.ForeColor = System.Drawing.Color.White
        Me.LabelSupplier.Location = New System.Drawing.Point(796, 45)
        Me.LabelSupplier.Name = "LabelSupplier"
        Me.LabelSupplier.Size = New System.Drawing.Size(180, 33)
        Me.LabelSupplier.TabIndex = 29
        Me.LabelSupplier.Text = "Supplier Barang"
        '
        'LabelWarnaBarang
        '
        Me.LabelWarnaBarang.BackColor = System.Drawing.Color.Transparent
        Me.LabelWarnaBarang.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWarnaBarang.ForeColor = System.Drawing.Color.White
        Me.LabelWarnaBarang.Location = New System.Drawing.Point(796, 91)
        Me.LabelWarnaBarang.Name = "LabelWarnaBarang"
        Me.LabelWarnaBarang.Size = New System.Drawing.Size(114, 33)
        Me.LabelWarnaBarang.TabIndex = 31
        Me.LabelWarnaBarang.Text = "Warna Barang"
        '
        'TextWarnaBarang
        '
        Me.TextWarnaBarang.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextWarnaBarang.Location = New System.Drawing.Point(982, 92)
        Me.TextWarnaBarang.Name = "TextWarnaBarang"
        Me.TextWarnaBarang.Size = New System.Drawing.Size(223, 32)
        Me.TextWarnaBarang.TabIndex = 32
        '
        'LabelUkuranBarang
        '
        Me.LabelUkuranBarang.BackColor = System.Drawing.Color.Transparent
        Me.LabelUkuranBarang.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUkuranBarang.ForeColor = System.Drawing.Color.White
        Me.LabelUkuranBarang.Location = New System.Drawing.Point(796, 138)
        Me.LabelUkuranBarang.Name = "LabelUkuranBarang"
        Me.LabelUkuranBarang.Size = New System.Drawing.Size(114, 33)
        Me.LabelUkuranBarang.TabIndex = 33
        Me.LabelUkuranBarang.Text = "Ukuran Barang"
        '
        'TextUkuranBarang
        '
        Me.TextUkuranBarang.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextUkuranBarang.Location = New System.Drawing.Point(982, 138)
        Me.TextUkuranBarang.Name = "TextUkuranBarang"
        Me.TextUkuranBarang.Size = New System.Drawing.Size(223, 32)
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
        Me.LabelCariBarang.BackColor = System.Drawing.Color.Transparent
        Me.LabelCariBarang.Font = New System.Drawing.Font("Montserrat", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCariBarang.ForeColor = System.Drawing.SystemColors.Window
        Me.LabelCariBarang.Location = New System.Drawing.Point(501, 238)
        Me.LabelCariBarang.Name = "LabelCariBarang"
        Me.LabelCariBarang.Size = New System.Drawing.Size(116, 27)
        Me.LabelCariBarang.TabIndex = 36
        Me.LabelCariBarang.Text = "Cari Barang:"
        '
        'ManageBarang
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.gugli
        Me.ClientSize = New System.Drawing.Size(1217, 541)
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
