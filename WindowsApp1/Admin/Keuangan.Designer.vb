<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Keuangan
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
        Me.DataGridKeuangan = New System.Windows.Forms.DataGridView()
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.NumericHalaman = New System.Windows.Forms.NumericUpDown()
        Me.LabelHalaman = New System.Windows.Forms.Label()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jenis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nominal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipeAliran = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MetodeBayar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Staff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelSaldoBank = New System.Windows.Forms.Label()
        Me.LabelSaldoCash = New System.Windows.Forms.Label()
        Me.LabelTotalSaldoEmoney = New System.Windows.Forms.Label()
        Me.LabelTotalPemasukkan = New System.Windows.Forms.Label()
        Me.LabelTotalPengeluaran = New System.Windows.Forms.Label()
        Me.BtnSinkron = New System.Windows.Forms.Button()
        CType(Me.DataGridKeuangan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericHalaman, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridKeuangan
        '
        Me.DataGridKeuangan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridKeuangan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Tanggal, Me.Jenis, Me.Nominal, Me.TipeAliran, Me.MetodeBayar, Me.Keterangan, Me.Staff})
        Me.DataGridKeuangan.Location = New System.Drawing.Point(32, 219)
        Me.DataGridKeuangan.Name = "DataGridKeuangan"
        Me.DataGridKeuangan.RowHeadersWidth = 51
        Me.DataGridKeuangan.RowTemplate.Height = 24
        Me.DataGridKeuangan.Size = New System.Drawing.Size(1419, 290)
        Me.DataGridKeuangan.TabIndex = 0
        '
        'BtnKembali
        '
        Me.BtnKembali.Location = New System.Drawing.Point(32, 13)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(75, 23)
        Me.BtnKembali.TabIndex = 1
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'NumericHalaman
        '
        Me.NumericHalaman.Location = New System.Drawing.Point(1287, 534)
        Me.NumericHalaman.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericHalaman.Name = "NumericHalaman"
        Me.NumericHalaman.Size = New System.Drawing.Size(120, 22)
        Me.NumericHalaman.TabIndex = 2
        '
        'LabelHalaman
        '
        Me.LabelHalaman.AutoSize = True
        Me.LabelHalaman.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHalaman.Location = New System.Drawing.Point(1105, 534)
        Me.LabelHalaman.Name = "LabelHalaman"
        Me.LabelHalaman.Size = New System.Drawing.Size(116, 22)
        Me.LabelHalaman.TabIndex = 3
        Me.LabelHalaman.Text = "Halaman: 0/0"
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.MinimumWidth = 6
        Me.ID.Name = "ID"
        Me.ID.Width = 125
        '
        'Tanggal
        '
        Me.Tanggal.HeaderText = "Tanggal"
        Me.Tanggal.MinimumWidth = 6
        Me.Tanggal.Name = "Tanggal"
        Me.Tanggal.Width = 125
        '
        'Jenis
        '
        Me.Jenis.HeaderText = "Jenis"
        Me.Jenis.MinimumWidth = 6
        Me.Jenis.Name = "Jenis"
        Me.Jenis.Width = 125
        '
        'Nominal
        '
        Me.Nominal.HeaderText = "Nominal"
        Me.Nominal.MinimumWidth = 6
        Me.Nominal.Name = "Nominal"
        Me.Nominal.Width = 125
        '
        'TipeAliran
        '
        Me.TipeAliran.HeaderText = "Tipe Aliran"
        Me.TipeAliran.MinimumWidth = 6
        Me.TipeAliran.Name = "TipeAliran"
        Me.TipeAliran.Width = 125
        '
        'MetodeBayar
        '
        Me.MetodeBayar.HeaderText = "Metode Bayar"
        Me.MetodeBayar.MinimumWidth = 6
        Me.MetodeBayar.Name = "MetodeBayar"
        Me.MetodeBayar.Width = 125
        '
        'Keterangan
        '
        Me.Keterangan.HeaderText = "Keterangan"
        Me.Keterangan.MinimumWidth = 6
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.Width = 125
        '
        'Staff
        '
        Me.Staff.HeaderText = "Staff"
        Me.Staff.MinimumWidth = 6
        Me.Staff.Name = "Staff"
        Me.Staff.Width = 125
        '
        'LabelSaldoBank
        '
        Me.LabelSaldoBank.AutoSize = True
        Me.LabelSaldoBank.Location = New System.Drawing.Point(186, 20)
        Me.LabelSaldoBank.Name = "LabelSaldoBank"
        Me.LabelSaldoBank.Size = New System.Drawing.Size(80, 16)
        Me.LabelSaldoBank.TabIndex = 4
        Me.LabelSaldoBank.Text = "Saldo Bank:"
        '
        'LabelSaldoCash
        '
        Me.LabelSaldoCash.AutoSize = True
        Me.LabelSaldoCash.Location = New System.Drawing.Point(186, 54)
        Me.LabelSaldoCash.Name = "LabelSaldoCash"
        Me.LabelSaldoCash.Size = New System.Drawing.Size(80, 16)
        Me.LabelSaldoCash.TabIndex = 5
        Me.LabelSaldoCash.Text = "Saldo Cash:"
        '
        'LabelTotalSaldoEmoney
        '
        Me.LabelTotalSaldoEmoney.AutoSize = True
        Me.LabelTotalSaldoEmoney.Location = New System.Drawing.Point(186, 92)
        Me.LabelTotalSaldoEmoney.Name = "LabelTotalSaldoEmoney"
        Me.LabelTotalSaldoEmoney.Size = New System.Drawing.Size(133, 16)
        Me.LabelTotalSaldoEmoney.TabIndex = 6
        Me.LabelTotalSaldoEmoney.Text = "Total Saldo Emoney:"
        '
        'LabelTotalPemasukkan
        '
        Me.LabelTotalPemasukkan.AutoSize = True
        Me.LabelTotalPemasukkan.Location = New System.Drawing.Point(186, 131)
        Me.LabelTotalPemasukkan.Name = "LabelTotalPemasukkan"
        Me.LabelTotalPemasukkan.Size = New System.Drawing.Size(123, 16)
        Me.LabelTotalPemasukkan.TabIndex = 7
        Me.LabelTotalPemasukkan.Text = "Total Pemasukkan:"
        '
        'LabelTotalPengeluaran
        '
        Me.LabelTotalPengeluaran.AutoSize = True
        Me.LabelTotalPengeluaran.Location = New System.Drawing.Point(186, 166)
        Me.LabelTotalPengeluaran.Name = "LabelTotalPengeluaran"
        Me.LabelTotalPengeluaran.Size = New System.Drawing.Size(121, 16)
        Me.LabelTotalPengeluaran.TabIndex = 8
        Me.LabelTotalPengeluaran.Text = "Total Pengeluaran:"
        '
        'BtnSinkron
        '
        Me.BtnSinkron.Location = New System.Drawing.Point(32, 103)
        Me.BtnSinkron.Name = "BtnSinkron"
        Me.BtnSinkron.Size = New System.Drawing.Size(107, 29)
        Me.BtnSinkron.TabIndex = 9
        Me.BtnSinkron.Text = "SInkronasi"
        Me.BtnSinkron.UseVisualStyleBackColor = True
        '
        'Keuangan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1475, 576)
        Me.Controls.Add(Me.BtnSinkron)
        Me.Controls.Add(Me.LabelTotalPengeluaran)
        Me.Controls.Add(Me.LabelTotalPemasukkan)
        Me.Controls.Add(Me.LabelTotalSaldoEmoney)
        Me.Controls.Add(Me.LabelSaldoCash)
        Me.Controls.Add(Me.LabelSaldoBank)
        Me.Controls.Add(Me.LabelHalaman)
        Me.Controls.Add(Me.NumericHalaman)
        Me.Controls.Add(Me.BtnKembali)
        Me.Controls.Add(Me.DataGridKeuangan)
        Me.Name = "Keuangan"
        Me.Text = "Keuangan"
        CType(Me.DataGridKeuangan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericHalaman, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridKeuangan As DataGridView
    Friend WithEvents BtnKembali As Button
    Friend WithEvents NumericHalaman As NumericUpDown
    Friend WithEvents LabelHalaman As Label
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Tanggal As DataGridViewTextBoxColumn
    Friend WithEvents Jenis As DataGridViewTextBoxColumn
    Friend WithEvents Nominal As DataGridViewTextBoxColumn
    Friend WithEvents TipeAliran As DataGridViewTextBoxColumn
    Friend WithEvents MetodeBayar As DataGridViewTextBoxColumn
    Friend WithEvents Keterangan As DataGridViewTextBoxColumn
    Friend WithEvents Staff As DataGridViewTextBoxColumn
    Friend WithEvents LabelSaldoBank As Label
    Friend WithEvents LabelSaldoCash As Label
    Friend WithEvents LabelTotalSaldoEmoney As Label
    Friend WithEvents LabelTotalPemasukkan As Label
    Friend WithEvents LabelTotalPengeluaran As Label
    Friend WithEvents BtnSinkron As Button
End Class
