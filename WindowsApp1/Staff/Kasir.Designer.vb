<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Kasir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Kasir))
        Me.TextBoxNama = New System.Windows.Forms.TextBox()
        Me.LabelNama = New System.Windows.Forms.Label()
        Me.PanelDataInfo = New System.Windows.Forms.DataGridView()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Satuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warna = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ukuran = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBoxWarna = New System.Windows.Forms.TextBox()
        Me.LabelWarna = New System.Windows.Forms.Label()
        Me.LabelNamaPelanggan = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButtonMemberIya = New System.Windows.Forms.RadioButton()
        Me.NumericJumlah = New System.Windows.Forms.NumericUpDown()
        Me.NumericTunai = New System.Windows.Forms.NumericUpDown()
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.LabelPanelInfo = New System.Windows.Forms.Label()
        Me.BtnTambahkanKeranjang = New System.Windows.Forms.Button()
        Me.BtnSwitch = New System.Windows.Forms.Button()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.LabelTunai = New System.Windows.Forms.Label()
        Me.LabelMetodePembayaran = New System.Windows.Forms.Label()
        Me.RadioButtonTunai = New System.Windows.Forms.RadioButton()
        Me.BtnBayar = New System.Windows.Forms.Button()
        Me.BtnHapusKeranjang = New System.Windows.Forms.Button()
        Me.RadioButtonMemberTidak = New System.Windows.Forms.RadioButton()
        Me.BtnUpdateJumlah = New System.Windows.Forms.Button()
        Me.GroupBoxPembayaran = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelMetodeBayar = New System.Windows.Forms.Panel()
        Me.RadioButtonEmoney = New System.Windows.Forms.RadioButton()
        Me.PanelMember = New System.Windows.Forms.Panel()
        Me.ComboBoxPelanggan = New System.Windows.Forms.ComboBox()
        Me.LabelTunaiKasir = New System.Windows.Forms.Label()
        CType(Me.PanelDataInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericJumlah, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericTunai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxPembayaran.SuspendLayout()
        Me.PanelMetodeBayar.SuspendLayout()
        Me.PanelMember.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxNama
        '
        Me.TextBoxNama.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNama.Location = New System.Drawing.Point(406, 53)
        Me.TextBoxNama.Name = "TextBoxNama"
        Me.TextBoxNama.Size = New System.Drawing.Size(254, 32)
        Me.TextBoxNama.TabIndex = 0
        '
        'LabelNama
        '
        Me.LabelNama.AutoSize = True
        Me.LabelNama.BackColor = System.Drawing.Color.Transparent
        Me.LabelNama.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNama.ForeColor = System.Drawing.Color.White
        Me.LabelNama.Location = New System.Drawing.Point(171, 56)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(182, 31)
        Me.LabelNama.TabIndex = 1
        Me.LabelNama.Text = "Pencarian Nama"
        '
        'PanelDataInfo
        '
        Me.PanelDataInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.PanelDataInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PanelDataInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nama, Me.Satuan, Me.Stock, Me.Warna, Me.Ukuran, Me.Harga})
        Me.PanelDataInfo.Location = New System.Drawing.Point(30, 254)
        Me.PanelDataInfo.Name = "PanelDataInfo"
        Me.PanelDataInfo.RowHeadersWidth = 51
        Me.PanelDataInfo.RowTemplate.Height = 24
        Me.PanelDataInfo.Size = New System.Drawing.Size(1420, 270)
        Me.PanelDataInfo.TabIndex = 2
        '
        'Nama
        '
        Me.Nama.HeaderText = "Nama Barang"
        Me.Nama.MinimumWidth = 6
        Me.Nama.Name = "Nama"
        '
        'Satuan
        '
        Me.Satuan.HeaderText = "Satuan"
        Me.Satuan.MinimumWidth = 6
        Me.Satuan.Name = "Satuan"
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock Barang"
        Me.Stock.MinimumWidth = 6
        Me.Stock.Name = "Stock"
        '
        'Warna
        '
        Me.Warna.HeaderText = "Warna "
        Me.Warna.MinimumWidth = 6
        Me.Warna.Name = "Warna"
        '
        'Ukuran
        '
        Me.Ukuran.HeaderText = "Ukuran"
        Me.Ukuran.MinimumWidth = 6
        Me.Ukuran.Name = "Ukuran"
        '
        'Harga
        '
        Me.Harga.HeaderText = "Harga"
        Me.Harga.MinimumWidth = 6
        Me.Harga.Name = "Harga"
        '
        'TextBoxWarna
        '
        Me.TextBoxWarna.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxWarna.Location = New System.Drawing.Point(406, 100)
        Me.TextBoxWarna.Name = "TextBoxWarna"
        Me.TextBoxWarna.Size = New System.Drawing.Size(254, 32)
        Me.TextBoxWarna.TabIndex = 3
        '
        'LabelWarna
        '
        Me.LabelWarna.AutoSize = True
        Me.LabelWarna.BackColor = System.Drawing.Color.Transparent
        Me.LabelWarna.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWarna.ForeColor = System.Drawing.Color.White
        Me.LabelWarna.Location = New System.Drawing.Point(268, 101)
        Me.LabelWarna.Name = "LabelWarna"
        Me.LabelWarna.Size = New System.Drawing.Size(85, 31)
        Me.LabelWarna.TabIndex = 4
        Me.LabelWarna.Text = "Warna:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'LabelNamaPelanggan
        '
        Me.LabelNamaPelanggan.AutoSize = True
        Me.LabelNamaPelanggan.ForeColor = System.Drawing.Color.White
        Me.LabelNamaPelanggan.Location = New System.Drawing.Point(5, 72)
        Me.LabelNamaPelanggan.Name = "LabelNamaPelanggan"
        Me.LabelNamaPelanggan.Size = New System.Drawing.Size(195, 31)
        Me.LabelNamaPelanggan.TabIndex = 6
        Me.LabelNamaPelanggan.Text = "Nama Pelanggan:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(260, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 31)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Jumlah:"
        '
        'RadioButtonMemberIya
        '
        Me.RadioButtonMemberIya.AutoSize = True
        Me.RadioButtonMemberIya.ForeColor = System.Drawing.Color.White
        Me.RadioButtonMemberIya.Location = New System.Drawing.Point(3, 4)
        Me.RadioButtonMemberIya.Name = "RadioButtonMemberIya"
        Me.RadioButtonMemberIya.Size = New System.Drawing.Size(64, 35)
        Me.RadioButtonMemberIya.TabIndex = 8
        Me.RadioButtonMemberIya.Text = "Iya"
        Me.RadioButtonMemberIya.UseVisualStyleBackColor = True
        '
        'NumericJumlah
        '
        Me.NumericJumlah.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericJumlah.Location = New System.Drawing.Point(406, 155)
        Me.NumericJumlah.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericJumlah.Name = "NumericJumlah"
        Me.NumericJumlah.Size = New System.Drawing.Size(84, 32)
        Me.NumericJumlah.TabIndex = 11
        '
        'NumericTunai
        '
        Me.NumericTunai.Location = New System.Drawing.Point(209, 169)
        Me.NumericTunai.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericTunai.Name = "NumericTunai"
        Me.NumericTunai.Size = New System.Drawing.Size(185, 32)
        Me.NumericTunai.TabIndex = 12
        '
        'BtnKembali
        '
        Me.BtnKembali.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKembali.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnKembali.Location = New System.Drawing.Point(19, 12)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(119, 43)
        Me.BtnKembali.TabIndex = 13
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'LabelPanelInfo
        '
        Me.LabelPanelInfo.AutoSize = True
        Me.LabelPanelInfo.BackColor = System.Drawing.Color.Transparent
        Me.LabelPanelInfo.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPanelInfo.ForeColor = System.Drawing.Color.White
        Me.LabelPanelInfo.Location = New System.Drawing.Point(13, 223)
        Me.LabelPanelInfo.Name = "LabelPanelInfo"
        Me.LabelPanelInfo.Size = New System.Drawing.Size(303, 31)
        Me.LabelPanelInfo.TabIndex = 14
        Me.LabelPanelInfo.Text = "Panel Sedang Menampilkan:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'BtnTambahkanKeranjang
        '
        Me.BtnTambahkanKeranjang.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTambahkanKeranjang.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnTambahkanKeranjang.Location = New System.Drawing.Point(696, 103)
        Me.BtnTambahkanKeranjang.Name = "BtnTambahkanKeranjang"
        Me.BtnTambahkanKeranjang.Size = New System.Drawing.Size(169, 49)
        Me.BtnTambahkanKeranjang.TabIndex = 15
        Me.BtnTambahkanKeranjang.Text = "Tambahkan ke keranjang"
        Me.BtnTambahkanKeranjang.UseVisualStyleBackColor = True
        '
        'BtnSwitch
        '
        Me.BtnSwitch.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSwitch.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnSwitch.Location = New System.Drawing.Point(30, 170)
        Me.BtnSwitch.Name = "BtnSwitch"
        Me.BtnSwitch.Size = New System.Drawing.Size(174, 43)
        Me.BtnSwitch.TabIndex = 16
        Me.BtnSwitch.Text = "Switch Mode"
        Me.BtnSwitch.UseVisualStyleBackColor = True
        '
        'LabelTotal
        '
        Me.LabelTotal.AutoSize = True
        Me.LabelTotal.BackColor = System.Drawing.Color.Transparent
        Me.LabelTotal.Font = New System.Drawing.Font("Montserrat", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.ForeColor = System.Drawing.Color.White
        Me.LabelTotal.Location = New System.Drawing.Point(633, 223)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(115, 27)
        Me.LabelTotal.TabIndex = 17
        Me.LabelTotal.Text = "Total Harga:"
        '
        'LabelTunai
        '
        Me.LabelTunai.AutoSize = True
        Me.LabelTunai.ForeColor = System.Drawing.Color.White
        Me.LabelTunai.Location = New System.Drawing.Point(35, 173)
        Me.LabelTunai.Name = "LabelTunai"
        Me.LabelTunai.Size = New System.Drawing.Size(157, 31)
        Me.LabelTunai.TabIndex = 18
        Me.LabelTunai.Text = "Dibayar Tunai:"
        '
        'LabelMetodePembayaran
        '
        Me.LabelMetodePembayaran.AutoSize = True
        Me.LabelMetodePembayaran.ForeColor = System.Drawing.Color.White
        Me.LabelMetodePembayaran.Location = New System.Drawing.Point(6, 121)
        Me.LabelMetodePembayaran.Name = "LabelMetodePembayaran"
        Me.LabelMetodePembayaran.Size = New System.Drawing.Size(230, 31)
        Me.LabelMetodePembayaran.TabIndex = 19
        Me.LabelMetodePembayaran.Text = "Metode Pembayaran:"
        '
        'RadioButtonTunai
        '
        Me.RadioButtonTunai.AutoSize = True
        Me.RadioButtonTunai.ForeColor = System.Drawing.Color.White
        Me.RadioButtonTunai.Location = New System.Drawing.Point(15, 7)
        Me.RadioButtonTunai.Name = "RadioButtonTunai"
        Me.RadioButtonTunai.Size = New System.Drawing.Size(90, 35)
        Me.RadioButtonTunai.TabIndex = 20
        Me.RadioButtonTunai.Text = "Tunai"
        Me.RadioButtonTunai.UseVisualStyleBackColor = True
        '
        'BtnBayar
        '
        Me.BtnBayar.ForeColor = System.Drawing.Color.Black
        Me.BtnBayar.Location = New System.Drawing.Point(411, 162)
        Me.BtnBayar.Name = "BtnBayar"
        Me.BtnBayar.Size = New System.Drawing.Size(118, 39)
        Me.BtnBayar.TabIndex = 21
        Me.BtnBayar.Text = "Bayar"
        Me.BtnBayar.UseVisualStyleBackColor = True
        '
        'BtnHapusKeranjang
        '
        Me.BtnHapusKeranjang.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHapusKeranjang.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnHapusKeranjang.Location = New System.Drawing.Point(696, 160)
        Me.BtnHapusKeranjang.Name = "BtnHapusKeranjang"
        Me.BtnHapusKeranjang.Size = New System.Drawing.Size(169, 42)
        Me.BtnHapusKeranjang.TabIndex = 22
        Me.BtnHapusKeranjang.Text = "Hapus dari Keranjang"
        Me.BtnHapusKeranjang.UseVisualStyleBackColor = True
        '
        'RadioButtonMemberTidak
        '
        Me.RadioButtonMemberTidak.AutoSize = True
        Me.RadioButtonMemberTidak.ForeColor = System.Drawing.Color.White
        Me.RadioButtonMemberTidak.Location = New System.Drawing.Point(108, 4)
        Me.RadioButtonMemberTidak.Name = "RadioButtonMemberTidak"
        Me.RadioButtonMemberTidak.Size = New System.Drawing.Size(89, 35)
        Me.RadioButtonMemberTidak.TabIndex = 23
        Me.RadioButtonMemberTidak.Text = "Tidak"
        Me.RadioButtonMemberTidak.UseVisualStyleBackColor = True
        '
        'BtnUpdateJumlah
        '
        Me.BtnUpdateJumlah.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdateJumlah.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnUpdateJumlah.Location = New System.Drawing.Point(514, 150)
        Me.BtnUpdateJumlah.Name = "BtnUpdateJumlah"
        Me.BtnUpdateJumlah.Size = New System.Drawing.Size(135, 37)
        Me.BtnUpdateJumlah.TabIndex = 24
        Me.BtnUpdateJumlah.Text = "Perbarui Jumlah"
        Me.BtnUpdateJumlah.UseVisualStyleBackColor = True
        '
        'GroupBoxPembayaran
        '
        Me.GroupBoxPembayaran.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxPembayaran.Controls.Add(Me.Label2)
        Me.GroupBoxPembayaran.Controls.Add(Me.PanelMetodeBayar)
        Me.GroupBoxPembayaran.Controls.Add(Me.PanelMember)
        Me.GroupBoxPembayaran.Controls.Add(Me.ComboBoxPelanggan)
        Me.GroupBoxPembayaran.Controls.Add(Me.BtnBayar)
        Me.GroupBoxPembayaran.Controls.Add(Me.LabelMetodePembayaran)
        Me.GroupBoxPembayaran.Controls.Add(Me.LabelTunai)
        Me.GroupBoxPembayaran.Controls.Add(Me.LabelNamaPelanggan)
        Me.GroupBoxPembayaran.Controls.Add(Me.NumericTunai)
        Me.GroupBoxPembayaran.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxPembayaran.ForeColor = System.Drawing.Color.White
        Me.GroupBoxPembayaran.Location = New System.Drawing.Point(895, 12)
        Me.GroupBoxPembayaran.Name = "GroupBoxPembayaran"
        Me.GroupBoxPembayaran.Size = New System.Drawing.Size(568, 234)
        Me.GroupBoxPembayaran.TabIndex = 25
        Me.GroupBoxPembayaran.TabStop = False
        Me.GroupBoxPembayaran.Text = "Pembayaran"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 31)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Apakah Member?"
        '
        'PanelMetodeBayar
        '
        Me.PanelMetodeBayar.Controls.Add(Me.RadioButtonEmoney)
        Me.PanelMetodeBayar.Controls.Add(Me.RadioButtonTunai)
        Me.PanelMetodeBayar.Location = New System.Drawing.Point(261, 115)
        Me.PanelMetodeBayar.Name = "PanelMetodeBayar"
        Me.PanelMetodeBayar.Size = New System.Drawing.Size(239, 48)
        Me.PanelMetodeBayar.TabIndex = 27
        '
        'RadioButtonEmoney
        '
        Me.RadioButtonEmoney.AutoSize = True
        Me.RadioButtonEmoney.ForeColor = System.Drawing.Color.White
        Me.RadioButtonEmoney.Location = New System.Drawing.Point(112, 7)
        Me.RadioButtonEmoney.Name = "RadioButtonEmoney"
        Me.RadioButtonEmoney.Size = New System.Drawing.Size(127, 35)
        Me.RadioButtonEmoney.TabIndex = 25
        Me.RadioButtonEmoney.Text = "E-money"
        Me.RadioButtonEmoney.UseVisualStyleBackColor = True
        '
        'PanelMember
        '
        Me.PanelMember.Controls.Add(Me.RadioButtonMemberIya)
        Me.PanelMember.Controls.Add(Me.RadioButtonMemberTidak)
        Me.PanelMember.Location = New System.Drawing.Point(261, 17)
        Me.PanelMember.Name = "PanelMember"
        Me.PanelMember.Size = New System.Drawing.Size(248, 46)
        Me.PanelMember.TabIndex = 26
        '
        'ComboBoxPelanggan
        '
        Me.ComboBoxPelanggan.FormattingEnabled = True
        Me.ComboBoxPelanggan.Location = New System.Drawing.Point(261, 69)
        Me.ComboBoxPelanggan.Name = "ComboBoxPelanggan"
        Me.ComboBoxPelanggan.Size = New System.Drawing.Size(264, 39)
        Me.ComboBoxPelanggan.TabIndex = 24
        '
        'LabelTunaiKasir
        '
        Me.LabelTunaiKasir.AutoSize = True
        Me.LabelTunaiKasir.BackColor = System.Drawing.Color.Transparent
        Me.LabelTunaiKasir.Font = New System.Drawing.Font("Montserrat", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTunaiKasir.ForeColor = System.Drawing.Color.White
        Me.LabelTunaiKasir.Location = New System.Drawing.Point(365, 223)
        Me.LabelTunaiKasir.Name = "LabelTunaiKasir"
        Me.LabelTunaiKasir.Size = New System.Drawing.Size(124, 27)
        Me.LabelTunaiKasir.TabIndex = 26
        Me.LabelTunaiKasir.Text = "Tunai di kasir"
        '
        'Kasir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1486, 550)
        Me.Controls.Add(Me.LabelTunaiKasir)
        Me.Controls.Add(Me.BtnUpdateJumlah)
        Me.Controls.Add(Me.BtnHapusKeranjang)
        Me.Controls.Add(Me.LabelTotal)
        Me.Controls.Add(Me.BtnSwitch)
        Me.Controls.Add(Me.BtnTambahkanKeranjang)
        Me.Controls.Add(Me.LabelPanelInfo)
        Me.Controls.Add(Me.BtnKembali)
        Me.Controls.Add(Me.NumericJumlah)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelWarna)
        Me.Controls.Add(Me.TextBoxWarna)
        Me.Controls.Add(Me.PanelDataInfo)
        Me.Controls.Add(Me.LabelNama)
        Me.Controls.Add(Me.TextBoxNama)
        Me.Controls.Add(Me.GroupBoxPembayaran)
        Me.ForeColor = System.Drawing.Color.SteelBlue
        Me.Name = "Kasir"
        Me.Text = "Kasir"
        CType(Me.PanelDataInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericJumlah, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericTunai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxPembayaran.ResumeLayout(False)
        Me.GroupBoxPembayaran.PerformLayout()
        Me.PanelMetodeBayar.ResumeLayout(False)
        Me.PanelMetodeBayar.PerformLayout()
        Me.PanelMember.ResumeLayout(False)
        Me.PanelMember.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxNama As TextBox
    Friend WithEvents LabelNama As Label
    Friend WithEvents PanelDataInfo As DataGridView
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Satuan As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents Warna As DataGridViewTextBoxColumn
    Friend WithEvents Ukuran As DataGridViewTextBoxColumn
    Friend WithEvents Harga As DataGridViewTextBoxColumn
    Friend WithEvents TextBoxWarna As TextBox
    Friend WithEvents LabelWarna As Label
    Friend WithEvents LabelNamaPelanggan As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButtonMemberIya As RadioButton
    Friend WithEvents NumericJumlah As NumericUpDown
    Friend WithEvents NumericTunai As NumericUpDown
    Friend WithEvents BtnKembali As Button
    Friend WithEvents LabelPanelInfo As Label
    Friend WithEvents BtnTambahkanKeranjang As Button
    Friend WithEvents BtnSwitch As Button
    Friend WithEvents LabelTotal As Label
    Friend WithEvents LabelTunai As Label
    Friend WithEvents LabelMetodePembayaran As Label
    Friend WithEvents RadioButtonTunai As RadioButton
    Friend WithEvents BtnBayar As Button
    Friend WithEvents BtnHapusKeranjang As Button
    Friend WithEvents RadioButtonMemberTidak As RadioButton
    Friend WithEvents BtnUpdateJumlah As Button
    Friend WithEvents GroupBoxPembayaran As GroupBox
    Friend WithEvents ComboBoxPelanggan As ComboBox
    Friend WithEvents RadioButtonEmoney As RadioButton
    Friend WithEvents PanelMetodeBayar As Panel
    Friend WithEvents PanelMember As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelTunaiKasir As Label
End Class
