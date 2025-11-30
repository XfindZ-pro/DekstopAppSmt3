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
        Me.CrystalReportView = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CobaSource1 = New WindowsApp1.CobaSource()
        Me.CobaSource2 = New WindowsApp1.CobaSource()
        Me.CobaSource3 = New WindowsApp1.CobaSource()
        Me.CobaSource4 = New WindowsApp1.CobaSource()
        Me.CobaSource5 = New WindowsApp1.CobaSource()
        Me.SuspendLayout()
        '
        'BtnKembali
        '
        Me.BtnKembali.Location = New System.Drawing.Point(26, 12)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(107, 30)
        Me.BtnKembali.TabIndex = 0
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'BtnKonfirmasi
        '
        Me.BtnKonfirmasi.Location = New System.Drawing.Point(1094, 528)
        Me.BtnKonfirmasi.Name = "BtnKonfirmasi"
        Me.BtnKonfirmasi.Size = New System.Drawing.Size(107, 30)
        Me.BtnKonfirmasi.TabIndex = 1
        Me.BtnKonfirmasi.Text = "Konfirmasi"
        Me.BtnKonfirmasi.UseVisualStyleBackColor = True
        '
        'LblJudulKonfirmasi
        '
        Me.LblJudulKonfirmasi.AutoSize = True
        Me.LblJudulKonfirmasi.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJudulKonfirmasi.Location = New System.Drawing.Point(582, 31)
        Me.LblJudulKonfirmasi.Name = "LblJudulKonfirmasi"
        Me.LblJudulKonfirmasi.Size = New System.Drawing.Size(239, 27)
        Me.LblJudulKonfirmasi.TabIndex = 2
        Me.LblJudulKonfirmasi.Text = "Konfirmasi Pembayaran"
        '
        'LblTotalBelanja
        '
        Me.LblTotalBelanja.AutoSize = True
        Me.LblTotalBelanja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalBelanja.Location = New System.Drawing.Point(37, 494)
        Me.LblTotalBelanja.Name = "LblTotalBelanja"
        Me.LblTotalBelanja.Size = New System.Drawing.Size(132, 25)
        Me.LblTotalBelanja.TabIndex = 3
        Me.LblTotalBelanja.Text = "Total Belanja:"
        '
        'LblJumlahBayar
        '
        Me.LblJumlahBayar.AutoSize = True
        Me.LblJumlahBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJumlahBayar.Location = New System.Drawing.Point(37, 528)
        Me.LblJumlahBayar.Name = "LblJumlahBayar"
        Me.LblJumlahBayar.Size = New System.Drawing.Size(138, 25)
        Me.LblJumlahBayar.TabIndex = 4
        Me.LblJumlahBayar.Text = "Jumlah Bayar:"
        '
        'LblKembalian
        '
        Me.LblKembalian.AutoSize = True
        Me.LblKembalian.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblKembalian.Location = New System.Drawing.Point(37, 562)
        Me.LblKembalian.Name = "LblKembalian"
        Me.LblKembalian.Size = New System.Drawing.Size(111, 25)
        Me.LblKembalian.TabIndex = 5
        Me.LblKembalian.Text = "Kembalian:"
        '
        'LblNamaPelanggan
        '
        Me.LblNamaPelanggan.AutoSize = True
        Me.LblNamaPelanggan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNamaPelanggan.Location = New System.Drawing.Point(425, 489)
        Me.LblNamaPelanggan.Name = "LblNamaPelanggan"
        Me.LblNamaPelanggan.Size = New System.Drawing.Size(112, 25)
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
        Me.LblMetodeBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMetodeBayar.Location = New System.Drawing.Point(425, 533)
        Me.LblMetodeBayar.Name = "LblMetodeBayar"
        Me.LblMetodeBayar.Size = New System.Drawing.Size(140, 25)
        Me.LblMetodeBayar.TabIndex = 8
        Me.LblMetodeBayar.Text = "Metode Bayar:"
        '
        'BtnDownloadStruk
        '
        Me.BtnDownloadStruk.Location = New System.Drawing.Point(900, 507)
        Me.BtnDownloadStruk.Name = "BtnDownloadStruk"
        Me.BtnDownloadStruk.Size = New System.Drawing.Size(164, 30)
        Me.BtnDownloadStruk.TabIndex = 9
        Me.BtnDownloadStruk.Text = "Download Struk"
        Me.BtnDownloadStruk.UseVisualStyleBackColor = True
        '
        'BtnTutup
        '
        Me.BtnTutup.Location = New System.Drawing.Point(1094, 489)
        Me.BtnTutup.Name = "BtnTutup"
        Me.BtnTutup.Size = New System.Drawing.Size(107, 30)
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
        'CrystalReportView
        '
        Me.CrystalReportView.ActiveViewIndex = -1
        Me.CrystalReportView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportView.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportView.Location = New System.Drawing.Point(26, 102)
        Me.CrystalReportView.Name = "CrystalReportView"
        Me.CrystalReportView.ShowGroupTreeButton = False
        Me.CrystalReportView.Size = New System.Drawing.Size(1308, 362)
        Me.CrystalReportView.TabIndex = 11
        Me.CrystalReportView.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'KonfirmasiBayar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 596)
        Me.Controls.Add(Me.CrystalReportView)
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
    Friend WithEvents CrystalReportView As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrystalReport11 As CrystalReport11
    Friend WithEvents CobaSource1 As CobaSource
    Friend WithEvents CobaSource2 As CobaSource
    Friend WithEvents CobaSource3 As CobaSource
    Friend WithEvents CobaSource4 As CobaSource
    Friend WithEvents CobaSource5 As CobaSource
End Class
