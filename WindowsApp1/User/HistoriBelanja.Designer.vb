<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HistoriBelanja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistoriBelanja))
        Me.ListViewHistori = New System.Windows.Forms.ListView()
        Me.Tanggal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Kasir = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NamaPelanggan = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnDownloadStruk = New System.Windows.Forms.Button()
        Me.LabelHalaman = New System.Windows.Forms.Label()
        Me.PanelListView = New System.Windows.Forms.Panel()
        Me.NumericHalaman = New System.Windows.Forms.NumericUpDown()
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.TextBoxFilter = New System.Windows.Forms.TextBox()
        Me.LabelCariTanggal = New System.Windows.Forms.Label()
        Me.PanelListView.SuspendLayout()
        CType(Me.NumericHalaman, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListViewHistori
        '
        Me.ListViewHistori.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Tanggal, Me.Kasir, Me.NamaPelanggan})
        Me.ListViewHistori.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewHistori.HideSelection = False
        Me.ListViewHistori.Location = New System.Drawing.Point(61, 18)
        Me.ListViewHistori.Name = "ListViewHistori"
        Me.ListViewHistori.Size = New System.Drawing.Size(1018, 266)
        Me.ListViewHistori.TabIndex = 0
        Me.ListViewHistori.UseCompatibleStateImageBehavior = False
        Me.ListViewHistori.View = System.Windows.Forms.View.Details
        '
        'Tanggal
        '
        Me.Tanggal.Text = "Tanggal"
        Me.Tanggal.Width = 210
        '
        'Kasir
        '
        Me.Kasir.Text = "Kasir"
        Me.Kasir.Width = 200
        '
        'NamaPelanggan
        '
        Me.NamaPelanggan.Text = "Nama Pelanggan"
        Me.NamaPelanggan.Width = 250
        '
        'BtnDownloadStruk
        '
        Me.BtnDownloadStruk.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnDownloadStruk.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDownloadStruk.ForeColor = System.Drawing.Color.White
        Me.BtnDownloadStruk.Location = New System.Drawing.Point(987, 85)
        Me.BtnDownloadStruk.Name = "BtnDownloadStruk"
        Me.BtnDownloadStruk.Size = New System.Drawing.Size(207, 61)
        Me.BtnDownloadStruk.TabIndex = 1
        Me.BtnDownloadStruk.Text = "Download Struk"
        Me.BtnDownloadStruk.UseVisualStyleBackColor = False
        '
        'LabelHalaman
        '
        Me.LabelHalaman.AutoSize = True
        Me.LabelHalaman.BackColor = System.Drawing.Color.Transparent
        Me.LabelHalaman.Font = New System.Drawing.Font("Montserrat SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHalaman.ForeColor = System.Drawing.Color.White
        Me.LabelHalaman.Location = New System.Drawing.Point(916, 484)
        Me.LabelHalaman.Name = "LabelHalaman"
        Me.LabelHalaman.Size = New System.Drawing.Size(137, 31)
        Me.LabelHalaman.TabIndex = 2
        Me.LabelHalaman.Text = "Halaman 1/1"
        '
        'PanelListView
        '
        Me.PanelListView.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PanelListView.Controls.Add(Me.ListViewHistori)
        Me.PanelListView.Location = New System.Drawing.Point(59, 160)
        Me.PanelListView.Name = "PanelListView"
        Me.PanelListView.Size = New System.Drawing.Size(1137, 304)
        Me.PanelListView.TabIndex = 3
        '
        'NumericHalaman
        '
        Me.NumericHalaman.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericHalaman.Location = New System.Drawing.Point(1074, 484)
        Me.NumericHalaman.Name = "NumericHalaman"
        Me.NumericHalaman.Size = New System.Drawing.Size(120, 32)
        Me.NumericHalaman.TabIndex = 4
        '
        'BtnKembali
        '
        Me.BtnKembali.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnKembali.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKembali.ForeColor = System.Drawing.Color.White
        Me.BtnKembali.Location = New System.Drawing.Point(28, 12)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(126, 48)
        Me.BtnKembali.TabIndex = 5
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = False
        '
        'TextBoxFilter
        '
        Me.TextBoxFilter.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFilter.Location = New System.Drawing.Point(205, 114)
        Me.TextBoxFilter.Name = "TextBoxFilter"
        Me.TextBoxFilter.Size = New System.Drawing.Size(218, 32)
        Me.TextBoxFilter.TabIndex = 6
        '
        'LabelCariTanggal
        '
        Me.LabelCariTanggal.AutoSize = True
        Me.LabelCariTanggal.BackColor = System.Drawing.Color.Transparent
        Me.LabelCariTanggal.Font = New System.Drawing.Font("Montserrat", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCariTanggal.ForeColor = System.Drawing.Color.White
        Me.LabelCariTanggal.Location = New System.Drawing.Point(56, 117)
        Me.LabelCariTanggal.Name = "LabelCariTanggal"
        Me.LabelCariTanggal.Size = New System.Drawing.Size(143, 31)
        Me.LabelCariTanggal.TabIndex = 7
        Me.LabelCariTanggal.Text = "Cari Tanggal:"
        '
        'HistoriBelanja
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1222, 531)
        Me.Controls.Add(Me.LabelCariTanggal)
        Me.Controls.Add(Me.TextBoxFilter)
        Me.Controls.Add(Me.BtnKembali)
        Me.Controls.Add(Me.NumericHalaman)
        Me.Controls.Add(Me.PanelListView)
        Me.Controls.Add(Me.LabelHalaman)
        Me.Controls.Add(Me.BtnDownloadStruk)
        Me.Name = "HistoriBelanja"
        Me.Text = "HistoriBelanja"
        Me.PanelListView.ResumeLayout(False)
        CType(Me.NumericHalaman, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListViewHistori As ListView
    Friend WithEvents BtnDownloadStruk As Button
    Friend WithEvents Tanggal As ColumnHeader
    Friend WithEvents Kasir As ColumnHeader
    Friend WithEvents NamaPelanggan As ColumnHeader
    Friend WithEvents LabelHalaman As Label
    Friend WithEvents PanelListView As Panel
    Friend WithEvents NumericHalaman As NumericUpDown
    Friend WithEvents BtnKembali As Button
    Friend WithEvents TextBoxFilter As TextBox
    Friend WithEvents LabelCariTanggal As Label
End Class
