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

    ' --- 1. Event Load: Setup Awal ---
    Private Sub KonfirmasiBayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tampilkan Informasi Label
        LblTotalBelanja.Text = "Total Belanja: Rp. " & Me.totalBelanja.ToString("N0")
        LblJumlahBayar.Text = "Jumlah Bayar: Rp. " & Me.jumlahBayar.ToString("N0")
        LblKembalian.Text = "Kembalian: Rp. " & Me.kembalian.ToString("N0")
        LblNamaPelanggan.Text = "Pelanggan: " & If(String.IsNullOrEmpty(Me.namaPelanggan) OrElse Me.namaPelanggan = "Non-Member", "-", Me.namaPelanggan)
        LblMetodeBayar.Text = "Metode Bayar: " & Me.metodeBayar

        ' Atur Tombol
        BtnDownloadStruk.Visible = False
        BtnTutup.Visible = False
        BtnKonfirmasi.Visible = True
        BtnKembali.Visible = True

        ' Siapkan Tabel & Muat Data Keranjang
        SetupDataGridView()
        LoadDataAwal_Keranjang()
    End Sub

    Private Sub KonfirmasiBayar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Biarkan kosong
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' --- 2. Manajemen Data Grid View ---

    Private Sub SetupDataGridView()
        With PanelDataInfo
            .ReadOnly = True
            .AllowUserToAddRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()

            .Columns.Add("Nama", "Nama Barang")
            .Columns.Add("Harga", "Harga Satuan")
            .Columns.Add("Qty", "Qty")
            .Columns.Add("Subtotal", "Subtotal")

            .Columns("Nama").FillWeight = 200
            .Columns("Harga").DefaultCellStyle.Format = "N0"
            .Columns("Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Subtotal").DefaultCellStyle.Format = "N0"
            .Columns("Subtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub

    ' [FUNGSI 1] Tampilkan data dari KERANJANG (Sebelum Konfirmasi)
    Private Sub LoadDataAwal_Keranjang()
        Try
            DB.Koneksi()
            PanelDataInfo.Rows.Clear()
            Dim query As String = "SELECT b.Nama, (k.Harga / k.qty) AS HargaSatuan, k.qty, k.Harga AS Subtotal " &
                                  "FROM keranjang k JOIN barang b ON k.IdBarang = b.IdBarang " &
                                  "WHERE k.akunID = @uid"

            Using cmd As New MySqlCommand(query, DB.Connection)
                cmd.Parameters.AddWithValue("@uid", SessionManager.AkunID)
                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        PanelDataInfo.Rows.Add(rd("Nama"), rd("HargaSatuan"), rd("qty"), rd("Subtotal"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat detail keranjang: " & ex.Message)
        Finally
            DB.CloseConnection()
        End Try
    End Sub

    ' [FUNGSI 2] Tampilkan data dari TRANSAKSI DETAIL (Setelah Konfirmasi Sukses)
    Private Sub LoadDataAkhir_Transaksi()
        Try
            DB.Koneksi()
            PanelDataInfo.Rows.Clear()
            Dim query As String = "SELECT b.Nama, td.HargaSatuan, td.qty, td.TotalHarga AS Subtotal " &
                                  "FROM transaksi_detail td JOIN barang b ON td.IdBarang = b.IdBarang " &
                                  "WHERE td.IdTransaksi = @idTrans"

            Using cmd As New MySqlCommand(query, DB.Connection)
                cmd.Parameters.AddWithValue("@idTrans", Me.newIdTransaksi)
                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        PanelDataInfo.Rows.Add(rd("Nama"), rd("HargaSatuan"), rd("qty"), rd("Subtotal"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat detail transaksi: " & ex.Message)
        Finally
            DB.CloseConnection()
        End Try
    End Sub

    ' --- 3. Logika Transaksi Utama ---

    Private Sub BtnKonfirmasi_Click(sender As Object, e As EventArgs) Handles BtnKonfirmasi.Click
        Me.newIdTransaksi = "TRX-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")
        Dim conn As MySqlConnection
        Dim trans As MySqlTransaction = Nothing

        Try
            DB.Koneksi()
            conn = DB.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi database gagal.")

            trans = conn.BeginTransaction()

            ' A. Insert Header Transaksi
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

            ' B. Ambil Item dari Keranjang
            Dim dtKeranjang As New DataTable()
            Using cmd As New MySqlCommand("SELECT IdBarang, qty, (Harga / qty) AS HargaSatuan, Harga FROM keranjang WHERE akunID = @uid", conn, trans)
                cmd.Parameters.AddWithValue("@uid", SessionManager.AkunID)
                Using adp As New MySqlDataAdapter(cmd) : adp.Fill(dtKeranjang) : End Using
            End Using

            If dtKeranjang.Rows.Count = 0 Then Throw New Exception("Keranjang belanja kosong.")

            ' C. Loop Insert Detail & Update Stok
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

            ' D. Hapus Keranjang
            Using cmd As New MySqlCommand("DELETE FROM keranjang WHERE akunID = @uid", conn, trans)
                cmd.Parameters.AddWithValue("@uid", SessionManager.AkunID)
                cmd.ExecuteNonQuery()
            End Using

            ' E. Update Keuangan (AKUN KASIR & JURNAL)
            Dim idJurnal As String = "JRNL-" & DateTime.Now.ToString("yyyyMMddHHmmss")

            If Me.metodeBayar = "Tunai" Then
                ' --- LOGIKA TUNAI ---
                ' Uang masuk ke pegangan Kasir (Tabel AKUN kolom CASH)
                ' Logika: (Cash Awal + Bayar) - Kembalian = Cash Awal + TotalBelanja
                ' Jadi kita cukup menambahkan TotalBelanja ke cash kasir.

                Dim qKasir As String = "UPDATE akun SET cash = cash + @Total WHERE akunID = @StaffId"
                Using cmd As New MySqlCommand(qKasir, conn, trans)
                    cmd.Parameters.AddWithValue("@Total", Me.totalBelanja)
                    cmd.Parameters.AddWithValue("@StaffId", SessionManager.AkunID)
                    cmd.ExecuteNonQuery()
                End Using

                ' Catat Jurnal
                Dim qJurnal As String = "INSERT INTO jurnal_keuangan (id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff) VALUES (@Id, 'PENJUALAN', @Nom, 'MASUK', 'CASH', @Ket, @Staff)"
                Using cmd As New MySqlCommand(qJurnal, conn, trans)
                    cmd.Parameters.AddWithValue("@Id", idJurnal)
                    cmd.Parameters.AddWithValue("@Nom", Me.totalBelanja)
                    cmd.Parameters.AddWithValue("@Ket", $"Penjualan Tunai: {Me.namaPelanggan}")
                    cmd.Parameters.AddWithValue("@Staff", SessionManager.AkunID)
                    cmd.ExecuteNonQuery()
                End Using

                ' Update Session Lokal (Agar UI Kasir langsung update)
                SessionManager.AddCash(CInt(Me.totalBelanja))

            ElseIf Me.metodeBayar = "E-money" Then
                ' --- LOGIKA E-MONEY ---

                ' 1. Potong Saldo Member (Pembeli)
                Dim qMember As String = "UPDATE akun SET emoney = emoney - @Total WHERE akunID = @MemId"
                Using cmd As New MySqlCommand(qMember, conn, trans)
                    cmd.Parameters.AddWithValue("@Total", Me.totalBelanja)
                    cmd.Parameters.AddWithValue("@MemId", Me.memberAkunId)
                    cmd.ExecuteNonQuery()
                End Using

                ' 2. Masukkan ke Saldo Emoney Kasir (Sesuai Request)
                ' (Kasir menerima E-money dari pelanggan)
                Dim qKasir As String = "UPDATE akun SET emoney = emoney + @Total WHERE akunID = @StaffId"
                Using cmd As New MySqlCommand(qKasir, conn, trans)
                    cmd.Parameters.AddWithValue("@Total", Me.totalBelanja)
                    cmd.Parameters.AddWithValue("@StaffId", SessionManager.AkunID)
                    cmd.ExecuteNonQuery()
                End Using

                ' 3. Catat Jurnal
                Dim qJurnal As String = "INSERT INTO jurnal_keuangan (id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff) VALUES (@Id, 'PENJUALAN', @Nom, 'MASUK', 'E-MONEY', @Ket, @Staff)"
                Using cmd As New MySqlCommand(qJurnal, conn, trans)
                    cmd.Parameters.AddWithValue("@Id", idJurnal)
                    cmd.Parameters.AddWithValue("@Nom", Me.totalBelanja)
                    cmd.Parameters.AddWithValue("@Ket", $"Penjualan E-Money: {Me.namaPelanggan}")
                    cmd.Parameters.AddWithValue("@Staff", SessionManager.AkunID)
                    cmd.ExecuteNonQuery()
                End Using

                ' Update Session Lokal
                SessionManager.AddEmoney(CInt(Me.totalBelanja))
            End If

            trans.Commit()

            ' --- F. Update UI Setelah Sukses ---
            LblJudulKonfirmasi.Text = "Transaksi Sukses!"
            LblJudulKonfirmasi.ForeColor = Color.Green
            BtnKonfirmasi.Visible = False
            BtnKembali.Visible = False
            BtnDownloadStruk.Visible = True
            BtnTutup.Visible = True

            LoadDataAkhir_Transaksi()

        Catch ex As Exception
            Try : trans?.Rollback() : Catch : End Try
            MessageBox.Show("Transaksi Gagal: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB.CloseConnection()
        End Try
    End Sub

    ' --- 4. Fitur Cetak PDF ---

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
        Dim pTitle As New Paragraph("4 PILAR CLOTHING", fontHeader) With {.Alignment = Element.ALIGN_CENTER}
        doc.Add(pTitle)
        doc.Add(New Paragraph("JL.Yang Pernah Dekat, Buduran, Sidoarjo", fontSmall) With {.Alignment = Element.ALIGN_CENTER})
        doc.Add(New Paragraph("--------------------------------", fontNormal))

        ' Info
        doc.Add(New Paragraph($"ID: {idTrans}", fontNormal))
        doc.Add(New Paragraph($"Tgl: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal))
        doc.Add(New Paragraph($"Kasir: {SessionManager.Username}", fontNormal))
        doc.Add(New Paragraph($"Pelanggan: {Me.namaPelanggan}", fontNormal))
        doc.Add(New Paragraph("--------------------------------", fontNormal))

        ' Table Items
        Dim table As New PdfPTable(3) With {.WidthPercentage = 100}
        table.SetWidths({4, 1, 2})

        ' Gunakan data dari GridView yang sudah ada (karena sudah dimuat di LoadDataAkhir_Transaksi)
        For Each dgvRow As DataGridViewRow In PanelDataInfo.Rows
            table.AddCell(New PdfPCell(New Phrase(dgvRow.Cells("Nama").Value.ToString(), fontSmall)) With {.Border = 0})
            table.AddCell(New PdfPCell(New Phrase("x" & dgvRow.Cells("Qty").Value.ToString(), fontSmall)) With {.Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER})
            table.AddCell(New PdfPCell(New Phrase(dgvRow.Cells("Subtotal").Value.ToString(), fontSmall)) With {.Border = 0, .HorizontalAlignment = Element.ALIGN_RIGHT})
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

    Private Sub BtnTutup_Click(sender As Object, e As EventArgs) Handles BtnTutup.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub PanelDataInfo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles PanelDataInfo.CellContentClick
    End Sub

End Class