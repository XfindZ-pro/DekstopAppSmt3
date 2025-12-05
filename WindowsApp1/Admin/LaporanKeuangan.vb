Imports CrystalDecisions.CrystalReports.Engine
Imports WindowsApp1.DataSet1TableAdapters 'Memanggil alat penghubung database

Public Class LaporanKeuangan

    ' Persiapkan alat untuk mengambil data
    Private daJurnal As New jurnal_keuanganTableAdapter()
    Private daAkun As New akunTableAdapter()

    ' Persiapkan tempat penampungan data sementara
    Private dtJurnal As New DataSet1.jurnal_keuanganDataTable()
    Private dtAkun As New DataSet1.akunDataTable()

    ' Persiapkan Laporan Crystal Report
    Private rptKeuangan As New ReportKeuangan()

    Private Sub LaporanKeuangan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call MuatLaporanKeuangan()
    End Sub

    Private Sub MuatLaporanKeuangan()
        Try
            ' 1. ISI DATA JURNAL
            ' Mengambil semua data dari tabel jurnal_keuangan di database
            daJurnal.Fill(dtJurnal)

            ' 2. HITUNG TOTAL KAS (Manual via Coding agar mudah)
            ' Kita ambil data akun dulu
            daAkun.Fill(dtAkun)

            ' Kita hitung total emoney secara manual dari data yang sudah diambil
            Dim totalEmoney As Decimal = 0
            For Each baris As DataRow In dtAkun.Rows
                ' Cek agar tidak error jika data kosong
                If Not IsDBNull(baris("emoney")) Then
                    totalEmoney += Convert.ToDecimal(baris("emoney"))
                End If
            Next

            ' 3. MASUKKAN KE LAPORAN
            ' Masukkan data jurnal ke dalam laporan
            rptKeuangan.SetDataSource(CType(dtJurnal, DataTable))

            ' Kirim angka total kas ke parameter di Crystal Report
            ' Pastikan di Crystal Report Anda sudah buat Parameter bernama "TotalKasTokoParameter"
            rptKeuangan.SetParameterValue("TotalKasTokoParameter", totalEmoney)

            ' 4. TAMPILKAN
            CrystalReportViewer1.ReportSource = rptKeuangan
            CrystalReportViewer1.Refresh()

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Dim keuanganForm As New Keuangan()
        keuanganForm.Show()
        Me.Hide()
    End Sub

    Private Sub LaporanKeuangan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

End Class