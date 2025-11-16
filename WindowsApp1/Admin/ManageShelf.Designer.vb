<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageShelf
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
        Me.KembaliBtn = New System.Windows.Forms.Button()
        Me.PanelDataShelf = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lokasi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.BtnUbah = New System.Windows.Forms.Button()
        Me.BtnBaru = New System.Windows.Forms.Button()
        Me.TextLokasiShelf = New System.Windows.Forms.RichTextBox()
        Me.LabelLokasi = New System.Windows.Forms.Label()
        Me.TextNamaShelf = New System.Windows.Forms.TextBox()
        Me.TextIDShelf = New System.Windows.Forms.TextBox()
        Me.LabelNama = New System.Windows.Forms.Label()
        Me.LabelID = New System.Windows.Forms.Label()
        Me.DBstatus = New System.Windows.Forms.Label()
        Me.TextPencarian = New System.Windows.Forms.TextBox()
        Me.LabelPencarian = New System.Windows.Forms.Label()
        CType(Me.PanelDataShelf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KembaliBtn
        '
        Me.KembaliBtn.Location = New System.Drawing.Point(81, 25)
        Me.KembaliBtn.Name = "KembaliBtn"
        Me.KembaliBtn.Size = New System.Drawing.Size(133, 32)
        Me.KembaliBtn.TabIndex = 47
        Me.KembaliBtn.Text = "Kembali"
        Me.KembaliBtn.UseVisualStyleBackColor = True
        '
        'PanelDataShelf
        '
        Me.PanelDataShelf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PanelDataShelf.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Nama, Me.Lokasi})
        Me.PanelDataShelf.Location = New System.Drawing.Point(20, 279)
        Me.PanelDataShelf.Name = "PanelDataShelf"
        Me.PanelDataShelf.RowHeadersWidth = 51
        Me.PanelDataShelf.RowTemplate.Height = 24
        Me.PanelDataShelf.Size = New System.Drawing.Size(1375, 267)
        Me.PanelDataShelf.TabIndex = 46
        '
        'Id
        '
        Me.Id.HeaderText = "ID Rak"
        Me.Id.MinimumWidth = 6
        Me.Id.Name = "Id"
        Me.Id.Width = 125
        '
        'Nama
        '
        Me.Nama.HeaderText = "Nama Rak"
        Me.Nama.MinimumWidth = 6
        Me.Nama.Name = "Nama"
        Me.Nama.Width = 125
        '
        'Lokasi
        '
        Me.Lokasi.HeaderText = "Lokasi Rak"
        Me.Lokasi.MinimumWidth = 6
        Me.Lokasi.Name = "Lokasi"
        Me.Lokasi.Width = 125
        '
        'BtnHapus
        '
        Me.BtnHapus.Location = New System.Drawing.Point(987, 112)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(75, 23)
        Me.BtnHapus.TabIndex = 45
        Me.BtnHapus.Text = "Hapus"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Location = New System.Drawing.Point(877, 112)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(75, 23)
        Me.BtnSimpan.TabIndex = 44
        Me.BtnSimpan.Text = "Simpan"
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'BtnUbah
        '
        Me.BtnUbah.Location = New System.Drawing.Point(765, 112)
        Me.BtnUbah.Name = "BtnUbah"
        Me.BtnUbah.Size = New System.Drawing.Size(75, 23)
        Me.BtnUbah.TabIndex = 43
        Me.BtnUbah.Text = "Ubah"
        Me.BtnUbah.UseVisualStyleBackColor = True
        '
        'BtnBaru
        '
        Me.BtnBaru.Location = New System.Drawing.Point(648, 112)
        Me.BtnBaru.Name = "BtnBaru"
        Me.BtnBaru.Size = New System.Drawing.Size(75, 23)
        Me.BtnBaru.TabIndex = 42
        Me.BtnBaru.Text = "Baru"
        Me.BtnBaru.UseVisualStyleBackColor = True
        '
        'TextLokasiShelf
        '
        Me.TextLokasiShelf.Location = New System.Drawing.Point(259, 157)
        Me.TextLokasiShelf.Name = "TextLokasiShelf"
        Me.TextLokasiShelf.Size = New System.Drawing.Size(223, 96)
        Me.TextLokasiShelf.TabIndex = 41
        Me.TextLokasiShelf.Text = ""
        '
        'LabelLokasi
        '
        Me.LabelLokasi.Location = New System.Drawing.Point(115, 165)
        Me.LabelLokasi.Name = "LabelLokasi"
        Me.LabelLokasi.Size = New System.Drawing.Size(180, 33)
        Me.LabelLokasi.TabIndex = 40
        Me.LabelLokasi.Text = "Lokasi"
        '
        'TextNamaShelf
        '
        Me.TextNamaShelf.Location = New System.Drawing.Point(259, 113)
        Me.TextNamaShelf.Name = "TextNamaShelf"
        Me.TextNamaShelf.Size = New System.Drawing.Size(223, 22)
        Me.TextNamaShelf.TabIndex = 39
        '
        'TextIDShelf
        '
        Me.TextIDShelf.Location = New System.Drawing.Point(259, 74)
        Me.TextIDShelf.Name = "TextIDShelf"
        Me.TextIDShelf.ReadOnly = True
        Me.TextIDShelf.Size = New System.Drawing.Size(223, 22)
        Me.TextIDShelf.TabIndex = 38
        '
        'LabelNama
        '
        Me.LabelNama.Location = New System.Drawing.Point(115, 121)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(180, 33)
        Me.LabelNama.TabIndex = 37
        Me.LabelNama.Text = "Nama Rak" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'LabelID
        '
        Me.LabelID.Location = New System.Drawing.Point(115, 77)
        Me.LabelID.Name = "LabelID"
        Me.LabelID.Size = New System.Drawing.Size(180, 33)
        Me.LabelID.TabIndex = 36
        Me.LabelID.Text = "ID Rak"
        '
        'DBstatus
        '
        Me.DBstatus.AutoSize = True
        Me.DBstatus.Location = New System.Drawing.Point(1225, 33)
        Me.DBstatus.Name = "DBstatus"
        Me.DBstatus.Size = New System.Drawing.Size(67, 16)
        Me.DBstatus.TabIndex = 35
        Me.DBstatus.Text = "Database"
        '
        'TextPencarian
        '
        Me.TextPencarian.Location = New System.Drawing.Point(702, 230)
        Me.TextPencarian.Name = "TextPencarian"
        Me.TextPencarian.Size = New System.Drawing.Size(215, 22)
        Me.TextPencarian.TabIndex = 48
        '
        'LabelPencarian
        '
        Me.LabelPencarian.AutoSize = True
        Me.LabelPencarian.Location = New System.Drawing.Point(603, 233)
        Me.LabelPencarian.Name = "LabelPencarian"
        Me.LabelPencarian.Size = New System.Drawing.Size(62, 16)
        Me.LabelPencarian.TabIndex = 49
        Me.LabelPencarian.Text = "Cari Rak:"
        '
        'ManageShelf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1414, 571)
        Me.Controls.Add(Me.LabelPencarian)
        Me.Controls.Add(Me.TextPencarian)
        Me.Controls.Add(Me.KembaliBtn)
        Me.Controls.Add(Me.PanelDataShelf)
        Me.Controls.Add(Me.BtnHapus)
        Me.Controls.Add(Me.BtnSimpan)
        Me.Controls.Add(Me.BtnUbah)
        Me.Controls.Add(Me.BtnBaru)
        Me.Controls.Add(Me.TextLokasiShelf)
        Me.Controls.Add(Me.LabelLokasi)
        Me.Controls.Add(Me.TextNamaShelf)
        Me.Controls.Add(Me.TextIDShelf)
        Me.Controls.Add(Me.LabelNama)
        Me.Controls.Add(Me.LabelID)
        Me.Controls.Add(Me.DBstatus)
        Me.Name = "ManageShelf"
        Me.Text = "ManageShelf"
        CType(Me.PanelDataShelf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KembaliBtn As Button
    Friend WithEvents PanelDataShelf As DataGridView
    Friend WithEvents BtnHapus As Button
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents BtnUbah As Button
    Friend WithEvents BtnBaru As Button
    Friend WithEvents TextLokasiShelf As RichTextBox
    Friend WithEvents LabelLokasi As Label
    Friend WithEvents TextNamaShelf As TextBox
    Friend WithEvents TextIDShelf As TextBox
    Friend WithEvents LabelNama As Label
    Friend WithEvents LabelID As Label
    Friend WithEvents DBstatus As Label
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Lokasi As DataGridViewTextBoxColumn
    Friend WithEvents TextPencarian As TextBox
    Friend WithEvents LabelPencarian As Label
End Class
