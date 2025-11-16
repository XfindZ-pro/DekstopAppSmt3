Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class HistoriBelanja

    Private DB As New Database()
    Private Cmd As MySqlCommand

    Private Const ItemsPerPage As Integer = 10 ' Jumlah transaksi per halaman
    Private currentPage As Integer = 1
    Private totalPages As Integer = 1

#Region "Form Load & Setup"

    Private Sub HistoriBelanja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupListView()
        BtnDownloadStruk.Visible = False
        NumericHalaman.Minimum = 1
        NumericHalaman.Value = 1

        If String.IsNullOrWhiteSpace(SessionManager.AkunID) Then
            MessageBox.Show("Tidak dapat memuat histori karena ID Member tidak ditemukan. Silakan login ulang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BtnKembali.PerformClick()
            Return
        End If

        LoadHistoryData(currentPage, TextBoxFilter.Text)
    End Sub

    Private Sub SetupListView()
        ListViewHistori.View = View.Details
        ListViewHistori.FullRowSelect = True
        ListViewHistori.GridLines = True
        ListViewHistori.MultiSelect = False

        ListViewHistori.Columns.Clear()
        ListViewHistori.Columns.Add("ID Transaksi", 0)
        ListViewHistori.Columns.Add("Tanggal", 150, HorizontalAlignment.Left)
        ListViewHistori.Columns.Add("Kasir", 100, HorizontalAlignment.Left)
        ListViewHistori.Columns.Add("Nama Pelanggan", 150, HorizontalAlignment.Left)
        ListViewHistori.Columns.Add("Total Belanja", 100, HorizontalAlignment.Right)
    End Sub

#End Region

#Region "Data Loading, Filtering & Pagination"

    Private Sub LoadHistoryData(pageNumber As Integer, filterDate As String)
        currentPage = pageNumber
        ListViewHistori.Items.Clear()
        BtnDownloadStruk.Visible = False

        Dim offset As Integer = (currentPage - 1) * ItemsPerPage
        Dim totalRecords As Integer = 0

        Try
            If String.IsNullOrWhiteSpace(SessionManager.AkunID) Then Throw New Exception("ID Member sesi hilang.")

            DB.Koneksi()
            Dim conn As MySqlConnection = DB.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi Gagal.")

            Dim countQuery As String = "SELECT COUNT(*) FROM transaksi_kasir WHERE memberId = @memberId"
            If Not String.IsNullOrWhiteSpace(filterDate) Then
                countQuery &= " AND DATE(TanggalTransaksi) LIKE @filterDate"
            End If

            Using countCmd As New MySqlCommand(countQuery, conn)
                countCmd.Parameters.AddWithValue("@memberId", SessionManager.AkunID)
                If Not String.IsNullOrWhiteSpace(filterDate) Then
                    countCmd.Parameters.AddWithValue("@filterDate", "%" & filterDate & "%")
                End If
                totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
            End Using

            totalPages = CInt(Math.Ceiling(totalRecords / CDbl(ItemsPerPage)))
            If totalPages = 0 Then totalPages = 1
            NumericHalaman.Maximum = totalPages
            If currentPage > totalPages Then currentPage = totalPages
            If NumericHalaman.Value <> currentPage Then NumericHalaman.Value = currentPage
            LabelHalaman.Text = $"Halaman {currentPage} / {totalPages}"

            Dim dataQuery As String = "SELECT tk.IdTransaksi, tk.TanggalTransaksi, a_kasir.username AS NamaKasir, tk.NamaPelanggan, tk.TotalAkhir " &
                                      "FROM transaksi_kasir tk JOIN akun a_kasir ON tk.akunID = a_kasir.akunID " &
                                      "WHERE tk.memberId = @memberId "
            If Not String.IsNullOrWhiteSpace(filterDate) Then
                dataQuery &= "AND DATE(tk.TanggalTransaksi) LIKE @filterDate "
            End If
            dataQuery &= "ORDER BY tk.TanggalTransaksi DESC LIMIT @limit OFFSET @offset"

            Dim dt As New DataTable()
            Using dataCmd As New MySqlCommand(dataQuery, conn)
                dataCmd.Parameters.AddWithValue("@memberId", SessionManager.AkunID)
                If Not String.IsNullOrWhiteSpace(filterDate) Then
                    dataCmd.Parameters.AddWithValue("@filterDate", "%" & filterDate & "%")
                End If
                dataCmd.Parameters.AddWithValue("@limit", ItemsPerPage)
                dataCmd.Parameters.AddWithValue("@offset", offset)
                Using adapter As New MySqlDataAdapter(dataCmd)
                    adapter.Fill(dt)
                End Using
            End Using

            For Each row As DataRow In dt.Rows
                Dim lvItem As New ListViewItem(row("IdTransaksi").ToString())
                lvItem.SubItems.Add(CDate(row("TanggalTransaksi")).ToString("dd/MM/yyyy HH:mm"))
                lvItem.SubItems.Add(row("NamaKasir").ToString())
                lvItem.SubItems.Add(If(IsDBNull(row("NamaPelanggan")), "-", row("NamaPelanggan").ToString()))
                lvItem.SubItems.Add(CDec(row("TotalAkhir")).ToString("N0"))
                lvItem.Tag = row("IdTransaksi").ToString()
                ListViewHistori.Items.Add(lvItem)
            Next

        Catch ex As Exception
            MessageBox.Show("Gagal memuat histori: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then
                DB.CloseConnection()
            End If
        End Try
    End Sub

    Private Sub NumericHalaman_ValueChanged(sender As Object, e As EventArgs) Handles NumericHalaman.ValueChanged
        If CInt(NumericHalaman.Value) <> currentPage Then
            LoadHistoryData(CInt(NumericHalaman.Value), TextBoxFilter.Text)
        End If
    End Sub

    Private Sub TextBoxFilter_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFilter.TextChanged
        currentPage = 1
        If NumericHalaman.Value <> 1 Then NumericHalaman.Value = 1
        LoadHistoryData(currentPage, TextBoxFilter.Text)
    End Sub

#End Region

#Region "ListView Selection & Download Struk"

    Private Sub ListViewHistori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewHistori.SelectedIndexChanged
        BtnDownloadStruk.Visible = (ListViewHistori.SelectedItems.Count > 0)
    End Sub

    Private Sub BtnDownloadStruk_Click(sender As Object, e As EventArgs) Handles BtnDownloadStruk.Click
        If ListViewHistori.SelectedItems.Count = 0 Then
            MessageBox.Show("Pilih transaksi dari daftar terlebih dahulu.", "Info") : Return
        End If

        Dim selectedIdTransaksi As String = ListViewHistori.SelectedItems(0).Tag.ToString()
        Dim saveDlg As New SaveFileDialog()
        saveDlg.Filter = "PDF files (*.pdf)|*.pdf"
        saveDlg.FileName = "Struk_" & selectedIdTransaksi & ".pdf"

        If saveDlg.ShowDialog() = DialogResult.OK Then
            Try
                GenerateStrukPDF(selectedIdTransaksi, saveDlg.FileName)
                MessageBox.Show("Struk berhasil disimpan di:" & vbCrLf & saveDlg.FileName, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal membuat PDF Struk: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Fungsi untuk membuat file PDF struk.
    ''' **[PEMBENARAN]** Cara deklarasi font telah diubah.
    ''' </summary>
    Private Sub GenerateStrukPDF(idTransaksi As String, filePath As String)
        Dim doc As New Document(PageSize.A7, 10, 10, 10, 10)
        Dim writer As PdfWriter = Nothing

        ' --- [PEMBENARAN] ---
        ' Menggunakan font default dan mengatur propertinya secara manual
        Dim baseFont As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED) ' Font dasar
        Dim headerFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD)
        Dim normalFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8)
        Dim smallFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6)
        ' --- END PEMBENARAN ---

        Try
            Dim dtHeader As New DataTable()
            Dim dtDetail As New DataTable()
            DB.Koneksi()
            Dim conn As MySqlConnection = DB.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi gagal untuk cetak struk.")

            Dim queryHeader As String = "SELECT tk.*, a.username AS NamaKasir FROM transaksi_kasir tk JOIN akun a ON tk.akunID = a.akunID WHERE tk.IdTransaksi = @id"
            Using cmdH As New MySqlCommand(queryHeader, conn)
                cmdH.Parameters.AddWithValue("@id", idTransaksi)
                Using adapterH As New MySqlDataAdapter(cmdH) : adapterH.Fill(dtHeader) : End Using
            End Using

            Dim queryDetail As String = "SELECT td.*, b.Nama AS NamaBarang FROM transaksi_detail td JOIN barang b ON td.IdBarang = b.IdBarang WHERE td.IdTransaksi = @id"
            Using cmdD As New MySqlCommand(queryDetail, conn)
                cmdD.Parameters.AddWithValue("@id", idTransaksi)
                Using adapterD As New MySqlDataAdapter(cmdD) : adapterD.Fill(dtDetail) : End Using
            End Using
            DB.CloseConnection()

            If dtHeader.Rows.Count = 0 Then Throw New Exception("Data transaksi tidak ditemukan.")
            Dim headerRow As DataRow = dtHeader.Rows(0)

            writer = PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
            doc.Open()

            ' Konten Header
            doc.Add(New Paragraph("--- STRUK PEMBELIAN ---", headerFont) With {.Alignment = Element.ALIGN_CENTER})
            doc.Add(New Paragraph("Toko Pakaian", normalFont) With {.Alignment = Element.ALIGN_CENTER})
            doc.Add(New Paragraph(" ", smallFont))
            doc.Add(New Paragraph("ID Transaksi: " & headerRow("IdTransaksi").ToString(), normalFont))
            doc.Add(New Paragraph("Tanggal: " & CDate(headerRow("TanggalTransaksi")).ToString("dd/MM/yyyy HH:mm:ss"), normalFont))
            doc.Add(New Paragraph("Kasir: " & headerRow("NamaKasir").ToString(), normalFont))
            doc.Add(New Paragraph("Pelanggan: " & If(IsDBNull(headerRow("NamaPelanggan")), "-", headerRow("NamaPelanggan").ToString()), normalFont))
            doc.Add(New Paragraph("----------------------------------", normalFont))

            ' Tabel Item
            Dim table As New PdfPTable(4)
            table.WidthPercentage = 100
            table.SetWidths({5, 1, 2, 2})
            table.AddCell(New PdfPCell(New Phrase("Item", smallFont)) With {.Border = 0})
            table.AddCell(New PdfPCell(New Phrase("Qty", smallFont)) With {.Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER})
            table.AddCell(New PdfPCell(New Phrase("Harga", smallFont)) With {.Border = 0, .HorizontalAlignment = Element.ALIGN_RIGHT})
            table.AddCell(New PdfPCell(New Phrase("Subtotal", smallFont)) With {.Border = 0, .HorizontalAlignment = Element.ALIGN_RIGHT})
            For Each itemRow As DataRow In dtDetail.Rows
                table.AddCell(New PdfPCell(New Phrase(itemRow("NamaBarang").ToString(), smallFont)) With {.Border = 0})
                table.AddCell(New PdfPCell(New Phrase(itemRow("qty").ToString(), smallFont)) With {.Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER})
                table.AddCell(New PdfPCell(New Phrase(CDec(itemRow("HargaSatuan")).ToString("N0"), smallFont)) With {.Border = 0, .HorizontalAlignment = Element.ALIGN_RIGHT})
                table.AddCell(New PdfPCell(New Phrase(CDec(itemRow("TotalHarga")).ToString("N0"), smallFont)) With {.Border = 0, .HorizontalAlignment = Element.ALIGN_RIGHT})
            Next
            doc.Add(table)
            doc.Add(New Paragraph("----------------------------------", normalFont))

            ' Konten Footer
            doc.Add(New Paragraph("Total Belanja: Rp. " & CDec(headerRow("TotalBelanja")).ToString("N0"), normalFont) With {.Alignment = Element.ALIGN_RIGHT})
            doc.Add(New Paragraph("Total Akhir: Rp. " & CDec(headerRow("TotalAkhir")).ToString("N0"), headerFont) With {.Alignment = Element.ALIGN_RIGHT})
            doc.Add(New Paragraph("Metode Bayar: " & headerRow("MetodeBayar").ToString(), normalFont) With {.Alignment = Element.ALIGN_RIGHT})
            doc.Add(New Paragraph("Jumlah Bayar: Rp. " & CDec(headerRow("JumlahBayar")).ToString("N0"), normalFont) With {.Alignment = Element.ALIGN_RIGHT})
            doc.Add(New Paragraph("Kembalian: Rp. " & CDec(headerRow("Kembalian")).ToString("N0"), normalFont) With {.Alignment = Element.ALIGN_RIGHT})
            doc.Add(New Paragraph(" ", smallFont))
            doc.Add(New Paragraph("Terima Kasih!", normalFont) With {.Alignment = Element.ALIGN_CENTER})

        Catch pdfEx As DocumentException
            Throw New Exception("iTextSharp Error: " & pdfEx.Message)
        Catch dbEx As Exception
            Throw dbEx
        Finally
            If doc IsNot Nothing AndAlso doc.IsOpen() Then doc.Close()
            If writer IsNot Nothing Then writer.Close()
            If DB.Connection IsNot Nothing AndAlso DB.Connection.State = ConnectionState.Open Then DB.CloseConnection()
        End Try
    End Sub

#End Region

#Region "Navigation & Form Close"

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub HistoriBelanja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

#End Region

#Region "Event Handler Kosong"
    Private Sub LabelHalaman_Click(sender As Object, e As EventArgs) Handles LabelHalaman.Click
    End Sub
#End Region

End Class