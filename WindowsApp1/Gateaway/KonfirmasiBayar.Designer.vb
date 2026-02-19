<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KonfirmasiBayar
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
        Me.BtnKonfirmasi = New System.Windows.Forms.Button()
        Me.LblJudulKonfirmasi = New System.Windows.Forms.Label()
        Me.LblTotalBelanja = New System.Windows.Forms.Label()
        Me.LblJumlahBayar = New System.Windows.Forms.Label()
        Me.LblKembalian = New System.Windows.Forms.Label()
        Me.LblNamaPelanggan = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblMetodeBayar = New System.Windows.Forms.Label()
        Me.BtnDownloadStruk = New System.Windows.Forms.Button()
        Me.BtnTutup = New System.Windows.Forms.Button()
        Me.MySqlCommand1 = New MySql.Data.MySqlClient.MySqlCommand()
        Me.PanelDataInfo = New System.Windows.Forms.DataGridView()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Satuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warna = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ukuran = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PanelDataInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnKembali
        '
        Me.BtnKembali.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKembali.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnKembali.Location = New System.Drawing.Point(26, 12)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(141, 43)
        Me.BtnKembali.TabIndex = 0
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'BtnKonfirmasi
        '
        Me.BtnKonfirmasi.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKonfirmasi.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnKonfirmasi.Location = New System.Drawing.Point(1097, 518)
        Me.BtnKonfirmasi.Name = "BtnKonfirmasi"
        Me.BtnKonfirmasi.Size = New System.Drawing.Size(143, 41)
        Me.BtnKonfirmasi.TabIndex = 1
        Me.BtnKonfirmasi.Text = "Konfirmasi"
        Me.BtnKonfirmasi.UseVisualStyleBackColor = True
        '
        'LblJudulKonfirmasi
        '
        Me.LblJudulKonfirmasi.AutoSize = True
        Me.LblJudulKonfirmasi.BackColor = System.Drawing.Color.Transparent
        Me.LblJudulKonfirmasi.Font = New System.Drawing.Font("Montserrat", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJudulKonfirmasi.ForeColor = System.Drawing.Color.White
        Me.LblJudulKonfirmasi.Location = New System.Drawing.Point(492, 6)
        Me.LblJudulKonfirmasi.Name = "LblJudulKonfirmasi"
        Me.LblJudulKonfirmasi.Size = New System.Drawing.Size(438, 52)
        Me.LblJudulKonfirmasi.TabIndex = 2
        Me.LblJudulKonfirmasi.Text = "Konfirmasi Pembayaran"
        '
        'LblTotalBelanja
        '
        Me.LblTotalBelanja.AutoSize = True
        Me.LblTotalBelanja.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalBelanja.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalBelanja.ForeColor = System.Drawing.Color.White
        Me.LblTotalBelanja.Location = New System.Drawing.Point(37, 479)
        Me.LblTotalBelanja.Name = "LblTotalBelanja"
        Me.LblTotalBelanja.Size = New System.Drawing.Size(151, 31)
        Me.LblTotalBelanja.TabIndex = 3
        Me.LblTotalBelanja.Text = "Total Belanja:"
        '
        'LblJumlahBayar
        '
        Me.LblJumlahBayar.AutoSize = True
        Me.LblJumlahBayar.BackColor = System.Drawing.Color.Transparent
        Me.LblJumlahBayar.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJumlahBayar.ForeColor = System.Drawing.Color.White
        Me.LblJumlahBayar.Location = New System.Drawing.Point(37, 513)
        Me.LblJumlahBayar.Name = "LblJumlahBayar"
        Me.LblJumlahBayar.Size = New System.Drawing.Size(159, 31)
        Me.LblJumlahBayar.TabIndex = 4
        Me.LblJumlahBayar.Text = "Jumlah Bayar:"
        '
        'LblKembalian
        '
        Me.LblKembalian.AutoSize = True
        Me.LblKembalian.BackColor = System.Drawing.Color.Transparent
        Me.LblKembalian.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblKembalian.ForeColor = System.Drawing.Color.White
        Me.LblKembalian.Location = New System.Drawing.Point(37, 547)
        Me.LblKembalian.Name = "LblKembalian"
        Me.LblKembalian.Size = New System.Drawing.Size(130, 31)
        Me.LblKembalian.TabIndex = 5
        Me.LblKembalian.Text = "Kembalian:"
        '
        'LblNamaPelanggan
        '
        Me.LblNamaPelanggan.AutoSize = True
        Me.LblNamaPelanggan.BackColor = System.Drawing.Color.Transparent
        Me.LblNamaPelanggan.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNamaPelanggan.ForeColor = System.Drawing.Color.White
        Me.LblNamaPelanggan.Location = New System.Drawing.Point(425, 474)
        Me.LblNamaPelanggan.Name = "LblNamaPelanggan"
        Me.LblNamaPelanggan.Size = New System.Drawing.Size(131, 31)
        Me.LblNamaPelanggan.TabIndex = 6
        Me.LblNamaPelanggan.Text = "Pelanggan:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Location = New System.Drawing.Point(-4, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1470, 18)
        Me.Panel1.TabIndex = 7
        '
        'LblMetodeBayar
        '
        Me.LblMetodeBayar.AutoSize = True
        Me.LblMetodeBayar.BackColor = System.Drawing.Color.Transparent
        Me.LblMetodeBayar.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMetodeBayar.ForeColor = System.Drawing.Color.White
        Me.LblMetodeBayar.Location = New System.Drawing.Point(425, 518)
        Me.LblMetodeBayar.Name = "LblMetodeBayar"
        Me.LblMetodeBayar.Size = New System.Drawing.Size(160, 31)
        Me.LblMetodeBayar.TabIndex = 8
        Me.LblMetodeBayar.Text = "Metode Bayar:"
        '
        'BtnDownloadStruk
        '
        Me.BtnDownloadStruk.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDownloadStruk.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnDownloadStruk.Location = New System.Drawing.Point(900, 518)
        Me.BtnDownloadStruk.Name = "BtnDownloadStruk"
        Me.BtnDownloadStruk.Size = New System.Drawing.Size(164, 41)
        Me.BtnDownloadStruk.TabIndex = 9
        Me.BtnDownloadStruk.Text = "Download Struk"
        Me.BtnDownloadStruk.UseVisualStyleBackColor = True
        '
        'BtnTutup
        '
        Me.BtnTutup.Font = New System.Drawing.Font("Montserrat Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTutup.ForeColor = System.Drawing.Color.SteelBlue
        Me.BtnTutup.Location = New System.Drawing.Point(1097, 466)
        Me.BtnTutup.Name = "BtnTutup"
        Me.BtnTutup.Size = New System.Drawing.Size(143, 40)
        Me.BtnTutup.TabIndex = 10
        Me.BtnTutup.Text = "Tutup"
        Me.BtnTutup.UseVisualStyleBackColor = True
        '
        'MySqlCommand1
        '
        Me.MySqlCommand1.CacheAge = 0
        Me.MySqlCommand1.Connection = Nothing
        Me.MySqlCommand1.EnableCaching = False
        Me.MySqlCommand1.Transaction = Nothing
        '
        'PanelDataInfo
        '
        Me.PanelDataInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.PanelDataInfo.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelDataInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PanelDataInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nama, Me.Satuan, Me.Stock, Me.Warna, Me.Ukuran, Me.Harga})
        Me.PanelDataInfo.Location = New System.Drawing.Point(42, 115)
        Me.PanelDataInfo.Name = "PanelDataInfo"
        Me.PanelDataInfo.RowHeadersWidth = 51
        Me.PanelDataInfo.RowTemplate.Height = 24
        Me.PanelDataInfo.Size = New System.Drawing.Size(1251, 330)
        Me.PanelDataInfo.TabIndex = 11
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
        'KonfirmasiBayar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.aksieii
        Me.ClientSize = New System.Drawing.Size(1362, 596)
        Me.Controls.Add(Me.PanelDataInfo)
        Me.Controls.Add(Me.BtnTutup)
        Me.Controls.Add(Me.BtnDownloadStruk)
        Me.Controls.Add(Me.LblMetodeBayar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblNamaPelanggan)
        Me.Controls.Add(Me.LblKembalian)
        Me.Controls.Add(Me.LblJumlahBayar)
        Me.Controls.Add(Me.LblTotalBelanja)
        Me.Controls.Add(Me.LblJudulKonfirmasi)
        Me.Controls.Add(Me.BtnKonfirmasi)
        Me.Controls.Add(Me.BtnKembali)
        Me.Name = "KonfirmasiBayar"
        Me.Text = "KonfirmasiBayar"
        CType(Me.PanelDataInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnKembali As Button
    Friend WithEvents BtnKonfirmasi As Button
    Friend WithEvents LblJudulKonfirmasi As Label
    Friend WithEvents LblTotalBelanja As Label
    Friend WithEvents LblJumlahBayar As Label
    Friend WithEvents LblKembalian As Label
    Friend WithEvents LblNamaPelanggan As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblMetodeBayar As Label
    Friend WithEvents BtnDownloadStruk As Button
    Friend WithEvents BtnTutup As Button
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents PanelDataInfo As DataGridView
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Satuan As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents Warna As DataGridViewTextBoxColumn
    Friend WithEvents Ukuran As DataGridViewTextBoxColumn
    Friend WithEvents Harga As DataGridViewTextBoxColumn
    'Friend WithEvents CrystalReport11 As CrystalReport11
    'Friend WithEvents CobaSource1 As CobaSource
    'Friend WithEvents CobaSource2 As CobaSource
    'Friend WithEvents CobaSource3 As CobaSource
    'Friend WithEvents CobaSource4 As CobaSource
    'Friend WithEvents CobaSource5 As CobaSource
End Class
