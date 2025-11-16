<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ManageKategori
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
        Me.DBstatus = New System.Windows.Forms.Label()
        Me.TextNamaKategori = New System.Windows.Forms.TextBox()
        Me.TextIDKategori = New System.Windows.Forms.TextBox()
        Me.LabelNama = New System.Windows.Forms.Label()
        Me.LabelID = New System.Windows.Forms.Label()
        Me.LabelDeskripsi = New System.Windows.Forms.Label()
        Me.TextDeskripsiKategori = New System.Windows.Forms.RichTextBox()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.BtnUbah = New System.Windows.Forms.Button()
        Me.BtnBaru = New System.Windows.Forms.Button()
        Me.PanelDataKategori = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Deskripsi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KembaliBtn = New System.Windows.Forms.Button()
        Me.TextPencarian = New System.Windows.Forms.TextBox()
        Me.LabelCariKategori = New System.Windows.Forms.Label()
        CType(Me.PanelDataKategori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DBstatus
        '
        Me.DBstatus.AutoSize = True
        Me.DBstatus.Location = New System.Drawing.Point(1218, 23)
        Me.DBstatus.Name = "DBstatus"
        Me.DBstatus.Size = New System.Drawing.Size(67, 16)
        Me.DBstatus.TabIndex = 21
        Me.DBstatus.Text = "Database"
        '
        'TextNamaKategori
        '
        Me.TextNamaKategori.Location = New System.Drawing.Point(252, 103)
        Me.TextNamaKategori.Name = "TextNamaKategori"
        Me.TextNamaKategori.Size = New System.Drawing.Size(223, 22)
        Me.TextNamaKategori.TabIndex = 25
        '
        'TextIDKategori
        '
        Me.TextIDKategori.Location = New System.Drawing.Point(252, 64)
        Me.TextIDKategori.Name = "TextIDKategori"
        Me.TextIDKategori.ReadOnly = True
        Me.TextIDKategori.Size = New System.Drawing.Size(223, 22)
        Me.TextIDKategori.TabIndex = 24
        '
        'LabelNama
        '
        Me.LabelNama.Location = New System.Drawing.Point(108, 111)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(180, 33)
        Me.LabelNama.TabIndex = 23
        Me.LabelNama.Text = "Nama Kategori"
        '
        'LabelID
        '
        Me.LabelID.Location = New System.Drawing.Point(108, 67)
        Me.LabelID.Name = "LabelID"
        Me.LabelID.Size = New System.Drawing.Size(180, 33)
        Me.LabelID.TabIndex = 22
        Me.LabelID.Text = "ID Kategori"
        '
        'LabelDeskripsi
        '
        Me.LabelDeskripsi.Location = New System.Drawing.Point(108, 155)
        Me.LabelDeskripsi.Name = "LabelDeskripsi"
        Me.LabelDeskripsi.Size = New System.Drawing.Size(180, 33)
        Me.LabelDeskripsi.TabIndex = 26
        Me.LabelDeskripsi.Text = "Deskripsi Kategori"
        '
        'TextDeskripsiKategori
        '
        Me.TextDeskripsiKategori.Location = New System.Drawing.Point(252, 147)
        Me.TextDeskripsiKategori.Name = "TextDeskripsiKategori"
        Me.TextDeskripsiKategori.Size = New System.Drawing.Size(223, 96)
        Me.TextDeskripsiKategori.TabIndex = 28
        Me.TextDeskripsiKategori.Text = ""
        '
        'BtnHapus
        '
        Me.BtnHapus.Location = New System.Drawing.Point(997, 108)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(75, 23)
        Me.BtnHapus.TabIndex = 32
        Me.BtnHapus.Text = "Hapus"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Location = New System.Drawing.Point(887, 108)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(75, 23)
        Me.BtnSimpan.TabIndex = 31
        Me.BtnSimpan.Text = "Simpan"
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'BtnUbah
        '
        Me.BtnUbah.Location = New System.Drawing.Point(775, 108)
        Me.BtnUbah.Name = "BtnUbah"
        Me.BtnUbah.Size = New System.Drawing.Size(75, 23)
        Me.BtnUbah.TabIndex = 30
        Me.BtnUbah.Text = "Ubah"
        Me.BtnUbah.UseVisualStyleBackColor = True
        '
        'BtnBaru
        '
        Me.BtnBaru.Location = New System.Drawing.Point(658, 108)
        Me.BtnBaru.Name = "BtnBaru"
        Me.BtnBaru.Size = New System.Drawing.Size(75, 23)
        Me.BtnBaru.TabIndex = 29
        Me.BtnBaru.Text = "Baru"
        Me.BtnBaru.UseVisualStyleBackColor = True
        '
        'PanelDataKategori
        '
        Me.PanelDataKategori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PanelDataKategori.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Nama, Me.Deskripsi})
        Me.PanelDataKategori.Location = New System.Drawing.Point(13, 269)
        Me.PanelDataKategori.Name = "PanelDataKategori"
        Me.PanelDataKategori.RowHeadersWidth = 51
        Me.PanelDataKategori.RowTemplate.Height = 24
        Me.PanelDataKategori.Size = New System.Drawing.Size(1375, 267)
        Me.PanelDataKategori.TabIndex = 33
        '
        'Id
        '
        Me.Id.HeaderText = "ID Kategori"
        Me.Id.MinimumWidth = 6
        Me.Id.Name = "Id"
        Me.Id.Width = 125
        '
        'Nama
        '
        Me.Nama.HeaderText = "Nama Kategori"
        Me.Nama.MinimumWidth = 6
        Me.Nama.Name = "Nama"
        Me.Nama.Width = 125
        '
        'Deskripsi
        '
        Me.Deskripsi.HeaderText = "Deskripsi Kategori"
        Me.Deskripsi.MinimumWidth = 6
        Me.Deskripsi.Name = "Deskripsi"
        Me.Deskripsi.Width = 125
        '
        'KembaliBtn
        '
        Me.KembaliBtn.Location = New System.Drawing.Point(74, 15)
        Me.KembaliBtn.Name = "KembaliBtn"
        Me.KembaliBtn.Size = New System.Drawing.Size(133, 32)
        Me.KembaliBtn.TabIndex = 34
        Me.KembaliBtn.Text = "Kembali"
        Me.KembaliBtn.UseVisualStyleBackColor = True
        '
        'TextPencarian
        '
        Me.TextPencarian.Location = New System.Drawing.Point(691, 223)
        Me.TextPencarian.Name = "TextPencarian"
        Me.TextPencarian.Size = New System.Drawing.Size(281, 22)
        Me.TextPencarian.TabIndex = 35
        '
        'LabelCariKategori
        '
        Me.LabelCariKategori.AutoSize = True
        Me.LabelCariKategori.Location = New System.Drawing.Point(588, 226)
        Me.LabelCariKategori.Name = "LabelCariKategori"
        Me.LabelCariKategori.Size = New System.Drawing.Size(87, 16)
        Me.LabelCariKategori.TabIndex = 36
        Me.LabelCariKategori.Text = "Cari Kategori:"
        '
        'ManageKategori
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1400, 548)
        Me.Controls.Add(Me.LabelCariKategori)
        Me.Controls.Add(Me.TextPencarian)
        Me.Controls.Add(Me.KembaliBtn)
        Me.Controls.Add(Me.PanelDataKategori)
        Me.Controls.Add(Me.BtnHapus)
        Me.Controls.Add(Me.BtnSimpan)
        Me.Controls.Add(Me.BtnUbah)
        Me.Controls.Add(Me.BtnBaru)
        Me.Controls.Add(Me.TextDeskripsiKategori)
        Me.Controls.Add(Me.LabelDeskripsi)
        Me.Controls.Add(Me.TextNamaKategori)
        Me.Controls.Add(Me.TextIDKategori)
        Me.Controls.Add(Me.LabelNama)
        Me.Controls.Add(Me.LabelID)
        Me.Controls.Add(Me.DBstatus)
        Me.Name = "ManageKategori"
        Me.Text = "ManageKategori"
        CType(Me.PanelDataKategori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DBstatus As Label
    Friend WithEvents TextNamaKategori As TextBox
    Friend WithEvents TextIDKategori As TextBox
    Friend WithEvents LabelNama As Label
    Friend WithEvents LabelID As Label
    Friend WithEvents LabelDeskripsi As Label
    Friend WithEvents TextDeskripsiKategori As RichTextBox
    Friend WithEvents BtnHapus As Button
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents BtnUbah As Button
    Friend WithEvents BtnBaru As Button
    Friend WithEvents PanelDataKategori As DataGridView
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Deskripsi As DataGridViewTextBoxColumn
    Friend WithEvents KembaliBtn As Button
    Friend WithEvents TextPencarian As TextBox
    Friend WithEvents LabelCariKategori As Label
End Class
