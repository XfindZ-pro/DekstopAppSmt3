Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Keuangan

    Private db As New Database()
    Private Const ItemsPerPage As Integer = 10 ' Jumlah data per halaman
    Private currentPage As Integer = 1
    Private totalPages As Integer = 1

    ' Jangan tutup seluruh aplikasi saat form ini ditutup
    Private Sub Keuangan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub Keuangan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SiapkanKolomGrid()
        NumericHalaman.Minimum = 1
        NumericHalaman.Value = 1
        LoadJurnalData(currentPage)
        LoadEkonomiData()
    End Sub

    ''' <summary>
    ''' Mengatur properti dan kolom untuk DataGridKeuangan
    ''' </summary>
    Private Sub SiapkanKolomGrid()
        With DataGridKeuangan
            .AutoGenerateColumns = False
            .Columns.Clear()
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Tambahkan kolom sesuai permintaan
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "IdJurnal", .HeaderText = "ID", .DataPropertyName = "id_jurnal", .Width = 120
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Tanggal", .HeaderText = "Tanggal", .DataPropertyName = "tanggal", .Width = 150,
                .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "dd/MM/yyyy HH:mm:ss"}
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Jenis", .HeaderText = "Jenis", .DataPropertyName = "jenis_transaksi", .Width = 100
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Nominal", .HeaderText = "Nominal", .DataPropertyName = "nominal", .Width = 100,
                .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N0", .Alignment = DataGridViewContentAlignment.MiddleRight}
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "TipeAliran", .HeaderText = "Tipe Aliran", .DataPropertyName = "TipeAliran", .Width = 80
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "MetodeBayar", .HeaderText = "Metode Bayar", .DataPropertyName = "MetodeBayar", .Width = 100
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Keterangan", .HeaderText = "Keterangan", .DataPropertyName = "keterangan", .FillWeight = 150
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Staff", .HeaderText = "Staff", .DataPropertyName = "Staff", .Width = 100
            })
        End With
    End Sub

    ''' <summary>
    ''' Fungsi utama untuk memuat data dari jurnal_keuangan dengan pagination
    ''' </summary>
    ''' <param name="pageNumber">Nomor halaman yang ingin ditampilkan</param>
    Private Sub LoadJurnalData(pageNumber As Integer)
        currentPage = pageNumber
        DataGridKeuangan.DataSource = Nothing
        DataGridKeuangan.Rows.Clear()

        Dim offset As Integer = (currentPage - 1) * ItemsPerPage
        Dim totalRecords As Integer = 0
        Dim dt As New DataTable()

        Try
            db.Koneksi()
            Dim conn As MySqlConnection = db.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi Gagal.")

            ' --- 1. Query untuk menghitung total record (untuk pagination) ---
            Dim countQuery As String = "SELECT COUNT(*) FROM jurnal_keuangan"
            Using countCmd As New MySqlCommand(countQuery, conn)
                totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
            End Using

            ' Hitung total halaman
            totalPages = CInt(Math.Ceiling(totalRecords / CDbl(ItemsPerPage)))
            If totalPages = 0 Then totalPages = 1 ' Minimal 1 halaman

            ' Update kontrol pagination
            If NumericHalaman.Maximum <> totalPages Then NumericHalaman.Maximum = totalPages
            If currentPage > totalPages Then currentPage = totalPages
            If NumericHalaman.Value <> currentPage Then NumericHalaman.Value = currentPage
            LabelHalaman.Text = $"Halaman {currentPage} / {totalPages}"

            ' --- 2. Query untuk mengambil data halaman ini (Data terbaru di atas) ---
            Dim dataQuery As String = "SELECT j.id_jurnal, j.tanggal, j.jenis_transaksi, j.nominal, j.TipeAliran, j.MetodeBayar, j.keterangan, a.username AS Staff " &
                                      "FROM jurnal_keuangan j " &
                                      "JOIN akun a ON j.akunID_staff = a.akunID " &
                                      "ORDER BY j.tanggal DESC " &
                                      "LIMIT @limit OFFSET @offset"

            Using dataCmd As New MySqlCommand(dataQuery, conn)
                dataCmd.Parameters.AddWithValue("@limit", ItemsPerPage)
                dataCmd.Parameters.AddWithValue("@offset", offset)
                Using adapter As New MySqlDataAdapter(dataCmd)
                    adapter.Fill(dt)
                End Using
            End Using

            DataGridKeuangan.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data keuangan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Memuat data dari tabel 'ekonomi' dan menampilkannya di Label
    ''' </summary>
    Private Sub LoadEkonomiData()
        Try
            db.Koneksi()
            Dim sql As String = "SELECT * FROM ekonomi WHERE id_utama = 'UTAMA'"
            Using cmd As New MySqlCommand(sql, db.Connection)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Format dan tampilkan data ke label
                        LabelSaldoCash.Text = "Saldo Cash: Rp. " & CDec(reader("saldo_cash")).ToString("N0")
                        LabelSaldoBank.Text = "Saldo Bank: Rp. " & CDec(reader("saldo_bank")).ToString("N0")
                        LabelTotalSaldoEmoney.Text = "Total E-Money (Hutang): Rp. " & CDec(reader("total_saldo_emoney_member")).ToString("N0")
                        LabelTotalPemasukkan.Text = "Total Pemasukkan: Rp. " & CDec(reader("total_pemasukkan")).ToString("N0")
                        LabelTotalPengeluaran.Text = "Total Pengeluaran: Rp. " & CDec(reader("total_pengeluaran")).ToString("N0")
                    Else
                        MessageBox.Show("Data master ekonomi 'UTAMA' tidak ditemukan.", "Error Kritis", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data ekonomi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Event ini dipicu ketika nilai NumericHalaman diubah (diklik)
    ''' </summary>
    Private Sub NumericHalaman_ValueChanged(sender As Object, e As EventArgs) Handles NumericHalaman.ValueChanged
        If CInt(NumericHalaman.Value) <> currentPage Then
            LoadJurnalData(CInt(NumericHalaman.Value))
        End If
    End Sub

    ''' <summary>
    ''' **[PERBAIKAN]**
    ''' Tombol untuk menghitung ulang total emoney dari SEMUA akun,
    ''' mengupdatenya ke tabel ekonomi, dan me-refresh semua label.
    ''' </summary>
    Private Sub BtnSinkron_Click(sender As Object, e As EventArgs) Handles BtnSinkron.Click
        Dim calculatedTotalEmoney As Decimal = 0
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing

        If MessageBox.Show("Ini akan menghitung ulang total saldo e-money dari SEMUA akun (user, staff, admin) dan memperbarui tabel 'ekonomi'. Lanjutkan?", "Konfirmasi Sinkronisasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Try
            db.Koneksi()
            conn = db.Connection
            If conn.State <> ConnectionState.Open Then Throw New Exception("Koneksi Gagal.")
            transaction = conn.BeginTransaction()

            ' 1. **[PERBAIKAN]** Hitung total emoney dari SEMUA akun, tanpa filter role
            Dim querySum As String = "SELECT SUM(emoney) FROM akun"
            Using cmdSum As New MySqlCommand(querySum, conn, transaction)
                Dim result = cmdSum.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    calculatedTotalEmoney = Convert.ToDecimal(result)
                End If
            End Using

            ' 2. Update nilai total_saldo_emoney_member di tabel 'ekonomi'
            Dim queryUpdate As String = "UPDATE ekonomi SET total_saldo_emoney_member = @totalEmoney WHERE id_utama = 'UTAMA'"
            Using cmdUpdate As New MySqlCommand(queryUpdate, conn, transaction)
                cmdUpdate.Parameters.AddWithValue("@totalEmoney", calculatedTotalEmoney)
                cmdUpdate.ExecuteNonQuery()
            End Using

            ' Jika berhasil, commit
            transaction.Commit()
            MessageBox.Show("Sinkronisasi saldo E-money berhasil.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Try : transaction?.Rollback() : Catch : End Try
            MessageBox.Show("Gagal melakukan sinkronisasi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try

        ' 3. Muat ulang data ekonomi ke label setelah sinkronisasi (baik Gagal maupun Sukses)
        LoadEkonomiData()
    End Sub

    ' --- Event Handler Kosong ---
    Private Sub LabelHalaman_Click(sender As Object, e As EventArgs) Handles LabelHalaman.Click
    End Sub
    Private Sub DataGridKeuangan_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridKeuangan.CellContentClick
    End Sub
    Private Sub LabelSaldoBank_Click(sender As Object, e As EventArgs) Handles LabelSaldoBank.Click
    End Sub
    Private Sub LabelSaldoCash_Click(sender As Object, e As EventArgs) Handles LabelSaldoCash.Click
    End Sub
    Private Sub LabelTotalSaldoEmoney_Click(sender As Object, e As EventArgs) Handles LabelTotalSaldoEmoney.Click
    End Sub
    Private Sub LabelTotalPemasukkan_Click(sender As Object, e As EventArgs) Handles LabelTotalPemasukkan.Click
    End Sub
    Private Sub LabelTotalPengeluaran_Click(sender As Object, e As EventArgs) Handles LabelTotalPengeluaran.Click
    End Sub
End Class