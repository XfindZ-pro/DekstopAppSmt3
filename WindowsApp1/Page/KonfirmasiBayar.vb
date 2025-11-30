Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO ' Diperlukan untuk FileStream, Path
Imports iTextSharp.text ' Diperlukan untuk Document, Paragraph, dll.
Imports iTextSharp.text.pdf ' Diperlukan untuk PdfWriter, PdfPTable, dll.

Public Class KonfirmasiBayar

    ' --- Variabel Internal ---
    Private DB As New Database()
    Private totalBelanja As Decimal
    Private jumlahBayar As Decimal
    Private kembalian As Decimal
    Private namaPelanggan As String
    Private metodeBayar As String
    Private memberAkunId As String ' Untuk menyimpan akunID member
    Private newIdTransaksi As String = ""

    ''' <summary>
    ''' Constructor (Sub New) untuk MENERIMA data dari Form Kasir.
    ''' </summary>
    Public Sub New(total As Decimal, bayar As Decimal, kembali As Decimal, pelanggan As String, metode As String, memberId As String)
        InitializeComponent()
        Me.totalBelanja = total
        Me.jumlahBayar = bayar
        Me.kembalian = kembali
        Me.namaPelanggan = pelanggan
        Me.metodeBayar = metode
        Me.memberAkunId = memberId
    End Sub

    ' Biarkan kosong agar tidak menutup seluruh aplikasi saat form ditutup.
    Private Sub KonfirmasiBayar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Biarkan kosong
    End Sub

    ' Tombol ini mengirim sinyal "Batal" dan kembali ke form Kasir
    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Mengisi label dengan data yang diterima saat form muncul.
    Private Sub KonfirmasiBayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblTotalBelanja.Text = "Total Belanja: Rp. " & Me.totalBelanja.ToString("N0")
        LblJumlahBayar.Text = "Jumlah Bayar: Rp. " & Me.jumlahBayar.ToString("N0")
        LblKembalian.Text = "Kembalian: Rp. " & Me.kembalian.ToString("N0")
        LblNamaPelanggan.Text = "Pelanggan: " & If(String.IsNullOrEmpty(Me.namaPelanggan) OrElse Me.namaPelanggan = "Non-Member", "-", Me.namaPelanggan)
        LblMetodeBayar.Text = "Metode Bayar: " & Me.metodeBayar

        BtnDownloadStruk.Visible = False
        BtnTutup.Visible = False
    End Sub

    ''' <summary>
    ''' **[PERUBAHAN LOGIKA]**
    ''' GATEWAY utama. Menjalankan SEMUA query SQL, termasuk validasi saldo cash untuk kembalian.
    ''' </summary>
    Private Sub BtnKonfirmasi_Click(sender As Object, e As EventArgs) Handles BtnKonfirmasi.Click
        Me.newIdTransaksi = "TRX-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")
        Dim conn As MySqlConnection
        Dim sqlTransaction As MySqlTransaction = Nothing

        Try
            DB.Koneksi()
            conn = DB.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi database tidak berhasil dibuka.")
            sqlTransaction = conn.BeginTransaction()

            ' --- 1. INSERT Header Transaksi (Struk) ---
            ' (Kode ini tetap sama)
            Dim queryHeader As String = "INSERT INTO transaksi_kasir (IdTransaksi, akunID, NamaPelanggan, memberId, MetodeBayar, TotalBelanja, Diskon, TotalAkhir, JumlahBayar, Kembalian) VALUES (@IdTransaksi, @akunID, @NamaPelanggan, @memberId, @MetodeBayar, @TotalBelanja, @Diskon, @TotalAkhir, @JumlahBayar, @Kembalian)"
            Using cmdHeader As New MySqlCommand(queryHeader, conn, sqlTransaction)
                With cmdHeader.Parameters
                    .AddWithValue("@IdTransaksi", Me.newIdTransaksi)
                    .AddWithValue("@akunID", SessionManager.AkunID) ' ID Kasir
                    .AddWithValue("@NamaPelanggan", If(Me.namaPelanggan = "Non-Member", CObj(DBNull.Value), Me.namaPelanggan))
                    If String.IsNullOrEmpty(Me.memberAkunId) OrElse Me.namaPelanggan = "Non-Member" Then
                        .AddWithValue("@memberId", CObj(DBNull.Value))
                    Else
                        .AddWithValue("@memberId", Me.memberAkunId)
                    End If
                    .AddWithValue("@MetodeBayar", Me.metodeBayar)
                    .AddWithValue("@TotalBelanja", Me.totalBelanja)
                    .AddWithValue("@Diskon", 0)
                    .AddWithValue("@TotalAkhir", Me.totalBelanja)
                    .AddWithValue("@JumlahBayar", Me.jumlahBayar)
                    .AddWithValue("@Kembalian", Me.kembalian)
                End With
                cmdHeader.ExecuteNonQuery()
            End Using

            ' --- 2. Ambil Keranjang ---
            ' (Kode ini tetap sama)
            Dim queryGetKeranjang As String = "SELECT IdBarang, qty, (Harga / qty) AS HargaSatuan, Harga FROM keranjang WHERE akunID = @akunId"
            Dim dtKeranjang As New DataTable()
            Using cmdGetKeranjang As New MySqlCommand(queryGetKeranjang, conn, sqlTransaction)
                cmdGetKeranjang.Parameters.AddWithValue("@akunId", SessionManager.AkunID)
                Using adapter As New MySqlDataAdapter(cmdGetKeranjang)
                    adapter.Fill(dtKeranjang)
                End Using
            End Using
            If dtKeranjang.Rows.Count = 0 Then Throw New Exception("Keranjang kosong.")

            ' --- 3. Loop: INSERT Detail (Struk) & UPDATE Stok Barang ---
            ' (Kode ini tetap sama)
            Dim detailCounter As Integer = 1
            For Each row As DataRow In dtKeranjang.Rows
                Dim idBarang As String = row("IdBarang").ToString()
                Dim qty As Integer = CInt(row("qty"))
                Dim hargaSatuan As Integer = CInt(row("HargaSatuan"))
                Dim totalHarga As Long = CLng(row("Harga"))
                Dim idDetail As String = Me.newIdTransaksi & "-D" & detailCounter.ToString("D3")
                detailCounter += 1

                ' 3a. INSERT Detail
                Dim queryDetail As String = "INSERT INTO transaksi_detail (IdDetailTransaksi, IdTransaksi, IdBarang, qty, HargaSatuan, TotalHarga) VALUES (@IdDetail, @IdTransaksi, @IdBarang, @qty, @HargaSatuan, @TotalHarga)"
                Using cmdDetail As New MySqlCommand(queryDetail, conn, sqlTransaction)
                    ' ... (Parameter AddWithValue)
                    cmdDetail.Parameters.AddWithValue("@IdDetail", idDetail)
                    cmdDetail.Parameters.AddWithValue("@IdTransaksi", Me.newIdTransaksi)
                    cmdDetail.Parameters.AddWithValue("@IdBarang", idBarang)
                    cmdDetail.Parameters.AddWithValue("@qty", qty)
                    cmdDetail.Parameters.AddWithValue("@HargaSatuan", hargaSatuan)
                    cmdDetail.Parameters.AddWithValue("@TotalHarga", totalHarga)
                    cmdDetail.ExecuteNonQuery()
                End Using

                ' 3b. UPDATE Stok
                Dim queryUpdateStock As String = "UPDATE barang SET Stock = Stock - @qty WHERE IdBarang = @idBarang"
                Using cmdUpdateStock As New MySqlCommand(queryUpdateStock, conn, sqlTransaction)
                    cmdUpdateStock.Parameters.AddWithValue("@qty", qty)
                    cmdUpdateStock.Parameters.AddWithValue("@idBarang", idBarang)
                    cmdUpdateStock.ExecuteNonQuery()
                End Using
            Next

            ' --- 4. Hapus Keranjang ---
            ' (Kode ini tetap sama)
            Dim queryDeleteKeranjang As String = "DELETE FROM keranjang WHERE akunID = @akunId"
            Using cmdDeleteKeranjang As New MySqlCommand(queryDeleteKeranjang, conn, sqlTransaction)
                cmdDeleteKeranjang.Parameters.AddWithValue("@akunId", SessionManager.AkunID)
                cmdDeleteKeranjang.ExecuteNonQuery()
            End Using

            ' --- 5. Update Saldo & Jurnal (Logika Akuntansi) ---
            Dim idJurnal As String = "JRNL-" & DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim queryJurnal As String = "INSERT INTO jurnal_keuangan (id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff) " &
                                        "VALUES (@idJurnal, 'PENJUALAN', @nominal, 'MASUK', @MetodeBayar, @keterangan, @akunIdStaff)"
            Dim queryEkonomi As String = ""

            If Me.metodeBayar = "Tunai" Then
                ' **[LOGIKA BARU]** Cek ketersediaan uang kembalian di kas
                If Me.kembalian > 0 Then
                    Dim currentCash As Decimal = 0
                    ' Kunci baris ekonomi untuk pengecekan dan update
                    Dim queryCheckCash As String = "SELECT saldo_cash FROM ekonomi WHERE id_utama = 'UTAMA' FOR UPDATE"
                    Using cmdCheck As New MySqlCommand(queryCheckCash, conn, sqlTransaction)
                        Dim result = cmdCheck.ExecuteScalar()
                        If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                            currentCash = Convert.ToDecimal(result)
                        Else
                            Throw New Exception("Data ekonomi 'UTAMA' tidak ditemukan.")
                        End If
                    End Using

                    ' Validasi jika saldo cash tidak cukup untuk kembalian
                    If currentCash < Me.kembalian Then
                        Throw New Exception($"Saldo cash di kasir (Rp {currentCash.ToString("N0")}) tidak cukup untuk memberikan kembalian (Rp {Me.kembalian.ToString("N0")}).")
                    End If
                End If
                ' **[AKHIR LOGIKA BARU]**

                ' Uang tunai masuk ke kas perusahaan (Netto = total belanja)
                ' (saldo_cash + jumlahBayar - kembalian) = (saldo_cash + totalBelanja)
                queryEkonomi = "UPDATE ekonomi SET saldo_cash = saldo_cash + @total, total_pemasukkan = total_pemasukkan + @total WHERE id_utama = 'UTAMA'"

                Using cmdJurnal As New MySqlCommand(queryJurnal, conn, sqlTransaction)
                    cmdJurnal.Parameters.AddWithValue("@idJurnal", idJurnal)
                    cmdJurnal.Parameters.AddWithValue("@nominal", Me.totalBelanja)
                    cmdJurnal.Parameters.AddWithValue("@MetodeBayar", "CASH")
                    cmdJurnal.Parameters.AddWithValue("@keterangan", $"Penjualan tunai ke: {Me.namaPelanggan}")
                    cmdJurnal.Parameters.AddWithValue("@akunIdStaff", SessionManager.AkunID)
                    If cmdJurnal.ExecuteNonQuery() = 0 Then Throw New Exception("Gagal catat jurnal (Tunai).")
                End Using

            ElseIf Me.metodeBayar = "E-money" Then
                ' Hutang E-money ke member berkurang (karena dibayar)
                queryEkonomi = "UPDATE ekonomi SET total_saldo_emoney_member = total_saldo_emoney_member - @total, total_pemasukkan = total_pemasukkan + @total WHERE id_utama = 'UTAMA'"

                ' Kurangi saldo emoney member
                Dim queryPotongSaldo As String = "UPDATE akun SET emoney = emoney - @totalBelanja WHERE akunID = @memberAkunId"
                Using cmdPotongSaldo As New MySqlCommand(queryPotongSaldo, conn, sqlTransaction)
                    cmdPotongSaldo.Parameters.AddWithValue("@totalBelanja", Me.totalBelanja)
                    cmdPotongSaldo.Parameters.AddWithValue("@memberAkunId", Me.memberAkunId)
                    If cmdPotongSaldo.ExecuteNonQuery() = 0 Then Throw New Exception("Gagal potong saldo E-money member.")
                End Using

                Using cmdJurnal As New MySqlCommand(queryJurnal, conn, sqlTransaction)
                    cmdJurnal.Parameters.AddWithValue("@idJurnal", idJurnal)
                    cmdJurnal.Parameters.AddWithValue("@nominal", Me.totalBelanja)
                    cmdJurnal.Parameters.AddWithValue("@MetodeBayar", "E-MONEY")
                    cmdJurnal.Parameters.AddWithValue("@keterangan", $"Penjualan via E-money ke: {Me.namaPelanggan}")
                    cmdJurnal.Parameters.AddWithValue("@akunIdStaff", SessionManager.AkunID)
                    If cmdJurnal.ExecuteNonQuery() = 0 Then Throw New Exception("Gagal catat jurnal (E-money).")
                End Using
            End If

            ' --- 6. Jalankan query ekonomi ---
            If Not String.IsNullOrEmpty(queryEkonomi) Then
                Using cmdEkonomi As New MySqlCommand(queryEkonomi, conn, sqlTransaction)
                    cmdEkonomi.Parameters.AddWithValue("@total", Me.totalBelanja)
                    If cmdEkonomi.ExecuteNonQuery() = 0 Then Throw New Exception("Gagal update tabel ekonomi.")
                End Using
            End If

            ' --- 7. Commit ---
            sqlTransaction.Commit()

            ' --- 8. Ubah Tampilan ---
            LblJudulKonfirmasi.Text = "Transaksi Berhasil!"
            BtnKonfirmasi.Visible = False
            BtnKembali.Visible = False
            BtnDownloadStruk.Visible = True
            BtnTutup.Visible = True

        Catch ex As Exception
            Try : sqlTransaction?.Rollback() : Catch : End Try
            MessageBox.Show("Transaksi GAGAL: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB.CloseConnection()
        End Try
    End Sub

    ''' <summary>
    ''' Tombol ini akan muncul setelah transaksi sukses. Memanggil fungsi GenerateStrukPDF.
    ''' </summary>
    Private Sub BtnDownloadStruk_Click(sender As Object, e As EventArgs) Handles BtnDownloadStruk.Click
        If String.IsNullOrEmpty(Me.newIdTransaksi) Then
            MessageBox.Show("ID Transaksi tidak ditemukan.", "Error")
            Return
        End If
        Dim saveDlg As New SaveFileDialog()
        saveDlg.Filter = "PDF files (*.pdf)|*.pdf"
        saveDlg.FileName = "Struk_" & Me.newIdTransaksi & ".pdf"
        If saveDlg.ShowDialog() = DialogResult.OK Then
            Try
                GenerateStrukPDF(Me.newIdTransaksi, saveDlg.FileName)
                MessageBox.Show("Struk berhasil disimpan di:" & vbCrLf & saveDlg.FileName, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal membuat PDF Struk: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Fungsi inti untuk membuat file PDF struk menggunakan iTextSharp.
    ''' </summary>
    Private Sub GenerateStrukPDF(idTransaksi As String, filePath As String)
        Dim doc As New Document(PageSize.A7, 10, 10, 10, 10)
        Dim writer As PdfWriter = Nothing

        ' **[PERBAIKAN FONT]**
        Dim baseFont As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
        Dim headerFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD)
        Dim normalFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8)
        Dim smallFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6)

        Try
            Dim dtHeader As New DataTable()
            Dim dtDetail As New DataTable()
            DB.Koneksi()
            Dim conn As MySqlConnection = DB.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi gagal untuk cetak struk.")

            ' Query Header
            Dim queryHeader As String = "SELECT tk.*, a.username AS NamaKasir FROM transaksi_kasir tk JOIN akun a ON tk.akunID = a.akunID WHERE tk.IdTransaksi = @id"
            Using cmdH As New MySqlCommand(queryHeader, conn)
                cmdH.Parameters.AddWithValue("@id", idTransaksi)
                Using adapterH As New MySqlDataAdapter(cmdH) : adapterH.Fill(dtHeader) : End Using
            End Using

            ' Query Detail
            Dim queryDetail As String = "SELECT td.*, b.Nama AS NamaBarang FROM transaksi_detail td JOIN barang b ON td.IdBarang = b.IdBarang WHERE td.IdTransaksi = @id"
            Using cmdD As New MySqlCommand(queryDetail, conn)
                cmdD.Parameters.AddWithValue("@id", idTransaksi)
                Using adapterD As New MySqlDataAdapter(cmdD) : adapterD.Fill(dtDetail) : End Using
            End Using
            DB.CloseConnection()

            If dtHeader.Rows.Count = 0 Then Throw New Exception("Data transaksi tidak ditemukan.")
            Dim headerRow As DataRow = dtHeader.Rows(0)

            ' Setup PDF
            writer = PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
            doc.Open()

            ' Konten Header
            doc.Add(New Paragraph("--- STRUK PEMBELIAN ---", headerFont) With {.Alignment = Element.ALIGN_CENTER})
            doc.Add(New Paragraph("Nama Toko Anda", normalFont) With {.Alignment = Element.ALIGN_CENTER}) ' Ganti Nama Toko
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

    ''' <summary>
    ''' Tombol ini akan muncul setelah transaksi sukses. Menutup form.
    ''' </summary>
    Private Sub BtnTutup_Click(sender As Object, e As EventArgs) Handles BtnTutup.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' --- Event Handler Kosong ---
    Private Sub LblTotalBelanja_Click(sender As Object, e As EventArgs) Handles LblTotalBelanja.Click : End Sub
    Private Sub LblJumlahBayar_Click(sender As Object, e As EventArgs) Handles LblJumlahBayar.Click : End Sub
    Private Sub LblKembalian_Click(sender As Object, e As EventArgs) Handles LblKembalian.Click : End Sub
    Private Sub LblNamaPelanggan_Click(sender As Object, e As EventArgs) Handles LblNamaPelanggan.Click : End Sub
    Private Sub LblMetodeBayar_Click(sender As Object, e As EventArgs) Handles LblMetodeBayar.Click : End Sub
    Private Sub LblJudulKonfirmasi_Click(sender As Object, e As EventArgs) Handles LblJudulKonfirmasi.Click : End Sub

    Private Sub CrystalReportView_Load(sender As Object, e As EventArgs) Handles CrystalReportView.Load

    End Sub
End Class