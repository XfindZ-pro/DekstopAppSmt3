<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanKeuangan
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ReportKeuangan2 = New WindowsApp1.ReportKeuangan()
        Me.ReportKeuangan1 = New WindowsApp1.ReportKeuangan()
        Me.ReportKeuangan3 = New WindowsApp1.ReportKeuangan()
        Me.ReportKeuangan4 = New WindowsApp1.ReportKeuangan()
        Me.ReportKeuangan5 = New WindowsApp1.ReportKeuangan()
        Me.ReportKeuangan6 = New WindowsApp1.ReportKeuangan()
        Me.ReportKeuangan7 = New WindowsApp1.ReportKeuangan()
        Me.BtnKembali = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = 0
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(41, 44)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReportSource = "C:\Users\findo\source\repos\WindowsApp1\WindowsApp1\ReportKeuangan.rpt"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1192, 450)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'BtnKembali
        '
        Me.BtnKembali.Location = New System.Drawing.Point(12, 12)
        Me.BtnKembali.Name = "BtnKembali"
        Me.BtnKembali.Size = New System.Drawing.Size(75, 23)
        Me.BtnKembali.TabIndex = 2
        Me.BtnKembali.Text = "Kembali"
        Me.BtnKembali.UseVisualStyleBackColor = True
        '
        'LaporanKeuangan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 522)
        Me.Controls.Add(Me.BtnKembali)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "LaporanKeuangan"
        Me.Text = "LaporanKeuangan"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ReportKeuangan1 As ReportKeuangan
    Friend WithEvents ReportKeuangan2 As ReportKeuangan
    Friend WithEvents ReportKeuangan3 As ReportKeuangan
    Friend WithEvents ReportKeuangan4 As ReportKeuangan
    Friend WithEvents ReportKeuangan5 As ReportKeuangan
    Friend WithEvents ReportKeuangan6 As ReportKeuangan
    Friend WithEvents ReportKeuangan7 As ReportKeuangan
    Friend WithEvents BtnKembali As Button
End Class
