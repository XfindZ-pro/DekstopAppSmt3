Imports System.IO
Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class KonfirmasiBayar

    ' --- Variabel Internal ---
    Private DB As New Database()
    Private totalBelanja As Decimal
    Private jumlahBayar As Decimal
    Private kembalian As Decimal
    Private namaPelanggan As String
    Private metodeBayar As String
    Private memberAkunId As String
    Private newIdTransaksi As String = ""

    ''' <summary>
    ''' Constructor: Menerima data dari form Kasir
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

    Private Sub KonfirmasiBayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblTotalBelanja.Text = "Total Belanja: Rp. " & Me.totalBelanja.ToString("N0")
        LblJumlahBayar.Text = "Jumlah Bayar: Rp. " & Me.jumlahBayar.ToString("N0")
        LblKembalian.Text = "Kembalian: Rp. " & Me.kembalian.ToString("N0")
        LblNamaPelanggan.Text = "Pelanggan: " & If(String.IsNullOrEmpty(Me.namaPelanggan) OrElse Me.namaPelanggan = "Non-Member", "-", Me.namaPelanggan)
        LblMetodeBayar.Text = "Metode Bayar: " & Me.metodeBayar

        BtnDownloadStruk.Visible = False
        BtnTutup.Visible = False
    End Sub

    ' [PERBAIKAN] Hapus Me.Dispose() di sini karena bisa menyebabkan error saat Form ditutup via ShowDialog
    Private Sub KonfirmasiBayar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Biarkan kosong atau lakukan pembersihan resource non-form jika ada
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' EKSEKUSI TRANSAKSI KE DATABASE
    ''' </summary>
    Private Sub BtnKonfirmasi_Click(sender As Object, e As EventArgs) Handles BtnKonfirmasi.Click
        Me.newIdTransaksi = "TRX-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")
        Dim conn As MySqlConnection
        Dim trans As MySqlTransaction = Nothing

        Try
            DB.Koneksi()
            conn = DB.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi database gagal.")

            trans = conn.BeginTransaction()

            ' --- 1. Insert Header Transaksi ---
            Dim qHeader As String = "INSERT INTO transaksi_kasir (IdTransaksi, akunID, NamaPelanggan, memberId, MetodeBayar, TotalBelanja, Diskon, TotalAkhir, JumlahBayar, Kembalian) VALUES (@Id, @Akun, @Nama, @MemId, @Metode, @Total, 0, @Total, @Bayar, @Kembali)"
            Using cmd As New MySqlCommand(qHeader, conn, trans)
                cmd.Parameters.AddWithValue("@Id", Me.newIdTransaksi)
                cmd.Parameters.AddWithValue("@Akun", SessionManager.AkunID)
                cmd.Parameters.AddWithValue("@Nama", If(Me.namaPelanggan = "Non-Member", DBNull.Value, Me.namaPelanggan))
                cmd.Parameters.AddWithValue("@MemId", If(String.IsNullOrEmpty(Me.memberAkunId), DBNull.Value, Me.memberAkunId))
                cmd.Parameters.AddWithValue("@Metode", Me.metodeBayar)
                cmd.Parameters.AddWithValue("@Total", Me.totalBelanja)
                cmd.Parameters.AddWithValue("@Bayar", Me.jumlahBayar)
                cmd.Parameters.AddWithValue("@Kembali", Me.kembalian)
                cmd.ExecuteNonQuery()
            End Using

            ' --- 2. Ambil Keranjang ---
            Dim dtKeranjang As New DataTable()
            Using cmd As New MySqlCommand("SELECT IdBarang, qty, (Harga / qty) AS HargaSatuan, Harga FROM keranjang WHERE akunID = @uid", conn, trans)
                cmd.Parameters.AddWithValue("@uid", SessionManager.AkunID)
                Using adp As New MySqlDataAdapter(cmd) : adp.Fill(dtKeranjang) : End Using
            End Using

            If dtKeranjang.Rows.Count = 0 Then Throw New Exception("Keranjang belanja kosong.")

            ' --- 3. Insert Detail & Update Stok Barang ---
            Dim counter As Integer = 1
            For Each row As DataRow In dtKeranjang.Rows
                Dim idBarang As String = row("IdBarang").ToString()
                Dim qty As Integer = CInt(row("qty"))
                Dim hargaSatuan As Decimal = CDec(row("HargaSatuan"))
                Dim subTotal As Decimal = CDec(row("Harga"))
                Dim idDetail As String = Me.newIdTransaksi & "-D" & counter.ToString("D3")
                counter += 1

                ' Insert Detail
                Dim qDetail As String = "INSERT INTO transaksi_detail (IdDetailTransaksi, IdTransaksi, IdBarang, qty, HargaSatuan, TotalHarga) VALUES (@IdD, @IdT, @IdB, @Q, @H, @Tot)"
                Using cmd As New MySqlCommand(qDetail, conn, trans)
                    cmd.Parameters.AddWithValue("@IdD", idDetail)
                    cmd.Parameters.AddWithValue("@IdT", Me.newIdTransaksi)
                    cmd.Parameters.AddWithValue("@IdB", idBarang)
                    cmd.Parameters.AddWithValue("@Q", qty)
                    cmd.Parameters.AddWithValue("@H", hargaSatuan)
                    cmd.Parameters.AddWithValue("@Tot", subTotal)
                    cmd.ExecuteNonQuery()
                End Using

                ' Update Stok Barang
                Using cmd As New MySqlCommand("UPDATE barang SET Stock = Stock - @Q WHERE IdBarang = @IdB", conn, trans)
                    cmd.Parameters.AddWithValue("@Q", qty)
                    cmd.Parameters.AddWithValue("@IdB", idBarang)
                    cmd.ExecuteNonQuery()
                End Using
            Next

            ' --- 4. Hapus Keranjang ---
            Using cmd As New MySqlCommand("DELETE FROM keranjang WHERE akunID = @uid", conn, trans)
                cmd.Parameters.AddWithValue("@uid", SessionManager.AkunID)
                cmd.ExecuteNonQuery()
            End Using

            ' --- 5. Update Keuangan (Ekonomi & Jurnal) ---
            Dim idJurnal As String = "JRNL-" & DateTime.Now.ToString("yyyyMMddHHmmss")

            If Me.metodeBayar = "Tunai" Then
                ' A. Validasi Uang di Brankas (Server Side Check)
                If Me.kembalian > 0 Then
                    Dim cashToko As Decimal = 0
                    Using cmd As New MySqlCommand("SELECT saldo_cash FROM ekonomi WHERE id_utama = 'UTAMA' FOR UPDATE", conn, trans)
                        Dim res = cmd.ExecuteScalar()
                        If res IsNot Nothing Then cashToko = CDec(res)
                    End Using

                    ' Jika saldo fisik toko kurang dari kembalian, throw error
                    If cashToko < Me.kembalian Then
                        Throw New Exception($"Saldo sistem (Rp {cashToko:N0}) tidak cukup untuk kembalian.")
                    End If
                End If

                ' B. Update Ekonomi (Tunai Bertambah)
                Dim qEko As String = "UPDATE ekonomi SET saldo_cash = saldo_cash + @Total, total_pemasukkan = total_pemasukkan + @Total WHERE id_utama = 'UTAMA'"
                Using cmd As New MySqlCommand(qEko, conn, trans)
                    cmd.Parameters.AddWithValue("@Total", Me.totalBelanja)
                    cmd.ExecuteNonQuery()
                End Using

                ' C. Catat Jurnal
                Dim qJurnal As String = "INSERT INTO jurnal_keuangan (id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff) VALUES (@Id, 'PENJUALAN', @Nom, 'MASUK', 'CASH', @Ket, @Staff)"
                Using cmd As New MySqlCommand(qJurnal, conn, trans)
                    cmd.Parameters.AddWithValue("@Id", idJurnal)
                    cmd.Parameters.AddWithValue("@Nom", Me.totalBelanja)
                    cmd.Parameters.AddWithValue("@Ket", $"Penjualan Tunai: {Me.namaPelanggan}")
                    cmd.Parameters.AddWithValue("@Staff", SessionManager.AkunID)
                    cmd.ExecuteNonQuery()
                End Using

                ' Update Sesi Lokal
                SessionManager.AddCash(CInt(Me.totalBelanja))

            ElseIf Me.metodeBayar = "E-money" Then
                ' A. Update Ekonomi (Alihkan Deposit Member ke Pemasukan Toko)
                Dim qEko As String = "UPDATE ekonomi SET total_saldo_emoney_member = total_saldo_emoney_member - @Total, total_pemasukkan = total_pemasukkan + @Total WHERE id_utama = 'UTAMA'"
                Using cmd As New MySqlCommand(qEko, conn, trans)
                    cmd.Parameters.AddWithValue("@Total", Me.totalBelanja)
                    cmd.ExecuteNonQuery()
                End Using

                ' B. Potong Saldo Member
                Dim qMember As String = "UPDATE akun SET emoney = emoney - @Total WHERE akunID = @MemId"
                Using cmd As New MySqlCommand(qMember, conn, trans)
                    cmd.Parameters.AddWithValue("@Total", Me.totalBelanja)
                    cmd.Parameters.AddWithValue("@MemId", Me.memberAkunId)
                    cmd.ExecuteNonQuery()
                End Using

                ' C. Catat Jurnal
                Dim qJurnal As String = "INSERT INTO jurnal_keuangan (id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff) VALUES (@Id, 'PENJUALAN', @Nom, 'MASUK', 'E-MONEY', @Ket, @Staff)"
                Using cmd As New MySqlCommand(qJurnal, conn, trans)
                    cmd.Parameters.AddWithValue("@Id", idJurnal)
                    cmd.Parameters.AddWithValue("@Nom", Me.totalBelanja)
                    cmd.Parameters.AddWithValue("@Ket", $"Penjualan E-Money: {Me.namaPelanggan}")
                    cmd.Parameters.AddWithValue("@Staff", SessionManager.AkunID)
                    cmd.ExecuteNonQuery()
                End Using
            End If

            trans.Commit()

            ' --- 6. Update UI (Tanpa MessageBox) ---
            LblJudulKonfirmasi.Text = "Transaksi Sukses!"
            LblJudulKonfirmasi.ForeColor = Color.Green
            BtnKonfirmasi.Visible = False
            BtnKembali.Visible = False
            BtnDownloadStruk.Visible = True
            BtnTutup.Visible = True

        Catch ex As Exception
            Try : trans?.Rollback() : Catch : End Try
            MessageBox.Show("Transaksi Gagal: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB.CloseConnection()
        End Try
    End Sub

    ''' <summary>
    ''' Generate PDF Struk
    ''' </summary>
    Private Sub BtnDownloadStruk_Click(sender As Object, e As EventArgs) Handles BtnDownloadStruk.Click
        Dim saveDlg As New SaveFileDialog With {
            .Filter = "PDF Files|*.pdf",
            .FileName = $"Struk_{Me.newIdTransaksi}.pdf"
        }

        If saveDlg.ShowDialog() = DialogResult.OK Then
            Try
                GenerateStrukPDF(Me.newIdTransaksi, saveDlg.FileName)
                MessageBox.Show("Struk berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal mencetak struk: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub GenerateStrukPDF(idTrans As String, path As String)
        Dim doc As New Document(PageSize.A7, 10, 10, 10, 10)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(path, FileMode.Create))

        doc.Open()

        Dim fontHeader As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)
        Dim fontNormal As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8)
        Dim fontSmall As Font = FontFactory.GetFont(FontFactory.HELVETICA, 6)

        ' Header
        Dim pTitle As New Paragraph("TOKO PAKAIAN", fontHeader) With {.Alignment = Element.ALIGN_CENTER}
        doc.Add(pTitle)
        doc.Add(New Paragraph("Jl. Contoh No. 123, Surabaya", fontSmall) With {.Alignment = Element.ALIGN_CENTER})
        doc.Add(New Paragraph("--------------------------------", fontNormal))

        ' Info Transaksi
        doc.Add(New Paragraph($"ID: {idTrans}", fontNormal))
        doc.Add(New Paragraph($"Tgl: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal))
        doc.Add(New Paragraph($"Kasir: {SessionManager.Username}", fontNormal))
        doc.Add(New Paragraph($"Pelanggan: {Me.namaPelanggan}", fontNormal))
        doc.Add(New Paragraph("--------------------------------", fontNormal))

        ' [PERBAIKAN] Menggunakan Object Initializer agar kode lebih ringkas & bersih
        Dim table As New PdfPTable(3) With {
            .WidthPercentage = 100
        }
        table.SetWidths({4, 1, 2})

        ' Ambil Detail
        Dim dt As New DataTable()
        DB.Koneksi()
        Using cmd As New MySqlCommand("SELECT b.Nama, d.qty, d.TotalHarga FROM transaksi_detail d JOIN barang b ON d.IdBarang = b.IdBarang WHERE d.IdTransaksi = @id", DB.Connection)
            cmd.Parameters.AddWithValue("@id", idTrans)
            Using adp As New MySqlDataAdapter(cmd) : adp.Fill(dt) : End Using
        End Using
        DB.CloseConnection()

        For Each row As DataRow In dt.Rows
            table.AddCell(New PdfPCell(New Phrase(row("Nama").ToString(), fontSmall)) With {.Border = 0})
            table.AddCell(New PdfPCell(New Phrase("x" & row("qty").ToString(), fontSmall)) With {.Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER})
            table.AddCell(New PdfPCell(New Phrase(CDec(row("TotalHarga")).ToString("N0"), fontSmall)) With {.Border = 0, .HorizontalAlignment = Element.ALIGN_RIGHT})
        Next
        doc.Add(table)

        doc.Add(New Paragraph("--------------------------------", fontNormal))

        ' Footer
        Dim pTotal As New Paragraph($"Total: Rp {Me.totalBelanja:N0}", fontHeader) With {.Alignment = Element.ALIGN_RIGHT}
        doc.Add(pTotal)
        doc.Add(New Paragraph($"{Me.metodeBayar}: Rp {Me.jumlahBayar:N0}", fontNormal) With {.Alignment = Element.ALIGN_RIGHT})
        doc.Add(New Paragraph($"Kembali: Rp {Me.kembalian:N0}", fontNormal) With {.Alignment = Element.ALIGN_RIGHT})

        doc.Add(New Paragraph(" ", fontNormal))
        doc.Add(New Paragraph("Terima Kasih!", fontNormal) With {.Alignment = Element.ALIGN_CENTER})

        doc.Close()
        writer.Close()
    End Sub

    ' Event Tombol Tutup
    ' [PERBAIKAN] Tidak ada MessageBox di sini. Hanya menutup form dan mengirim status OK.
    Private Sub BtnTutup_Click(sender As Object, e As EventArgs) Handles BtnTutup.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class