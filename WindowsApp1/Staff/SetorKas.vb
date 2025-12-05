Imports MySql.Data.MySqlClient

Public Class SetorKas
    Private DB As New Database()

    ' --- 1. Event Load & Tampilan ---
    Private Sub SetorKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateLabelSaldo()
        RadioButtonCash.Checked = True
        NumericNominal.Value = 0
    End Sub

    Private Sub SetorKas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub UpdateLabelSaldo()
        RefreshSaldoDariDB()
        LabelSaldoCashDimiliki.Text = "Uang Tunai di Tangan: Rp " & SessionManager.Cash.ToString("N0")
        LabelSaldoEmoneyDimiliki.Text = "Saldo E-Money Pegangan: Rp " & SessionManager.Emoney.ToString("N0")
    End Sub

    Private Sub RefreshSaldoDariDB()
        Try
            DB.Koneksi()
            Using cmd As New MySqlCommand("SELECT cash, emoney FROM akun WHERE akunID = @id", DB.Connection)
                cmd.Parameters.AddWithValue("@id", SessionManager.AkunID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim dbCash As Integer = If(IsDBNull(reader("cash")), 0, Convert.ToInt32(reader("cash")))
                        Dim dbEmoney As Integer = If(IsDBNull(reader("emoney")), 0, Convert.ToInt32(reader("emoney")))

                        SessionManager.UpdateCash(dbCash)
                        SessionManager.UpdateEmoney(dbEmoney)
                    End If
                End Using
            End Using
        Catch ex As Exception
        Finally
            DB.CloseConnection()
        End Try
    End Sub

    ' --- 2. Logika Penyetoran ---
    Private Sub BtnSetor_Click(sender As Object, e As EventArgs) Handles BtnSetor.Click
        Dim nominalSetor As Integer = CInt(NumericNominal.Value)

        If nominalSetor <= 0 Then
            MessageBox.Show("Nominal setor harus lebih dari 0.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Tentukan Jenis Sumber Dana
        Dim jenisSumber As String = If(RadioButtonCash.Checked, "CASH", "EMONEY")

        ' [PERBAIKAN IDE0059] Gunakan If inline (ternary) agar tidak perlu deklarasi = 0
        Dim saldoTersedia As Integer = If(jenisSumber = "CASH", SessionManager.Cash, SessionManager.Emoney)

        ' Validasi Kecukupan Dana
        If nominalSetor > saldoTersedia Then
            MessageBox.Show($"Saldo {jenisSumber} Anda tidak mencukupi." & vbCrLf &
                            $"Dimiliki: Rp {saldoTersedia:N0}" & vbCrLf &
                            $"Disetor: Rp {nominalSetor:N0}", "Saldo Kurang", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim tujuan As String = "BANK" ' Default tujuan penyetoran

        If MessageBox.Show($"Setor {jenisSumber} sebesar Rp {nominalSetor:N0} ke {tujuan}?", "Konfirmasi Setor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ProsesSetorKeDatabase(nominalSetor, jenisSumber, tujuan)
        End If
    End Sub

    Private Sub ProsesSetorKeDatabase(nominal As Integer, jenisSumber As String, tujuan As String)
        Dim conn As MySqlConnection
        Dim trans As MySqlTransaction = Nothing

        Try
            DB.Koneksi()
            conn = DB.Connection
            trans = conn.BeginTransaction()

            ' A. Kurangi Uang di Tangan Staff
            Dim kolomSumber As String = If(jenisSumber = "CASH", "cash", "emoney")
            Dim qKurang As String = $"UPDATE akun SET {kolomSumber} = {kolomSumber} - @jml WHERE akunID = @id"

            Using cmd As New MySqlCommand(qKurang, conn, trans)
                cmd.Parameters.AddWithValue("@jml", nominal)
                cmd.Parameters.AddWithValue("@id", SessionManager.AkunID)
                cmd.ExecuteNonQuery()
            End Using

            ' B. Tambah Saldo Toko
            Dim kolomTujuan As String = "saldo_bank"
            If jenisSumber = "CASH" Then kolomTujuan = "saldo_cash"

            Dim qTambah As String = $"UPDATE ekonomi SET {kolomTujuan} = {kolomTujuan} + @jml WHERE id_utama = 'UTAMA'"
            Using cmd As New MySqlCommand(qTambah, conn, trans)
                cmd.Parameters.AddWithValue("@jml", nominal)
                cmd.ExecuteNonQuery()
            End Using

            ' C. Catat Jurnal
            Dim idJurnal As String = "JRNL-" & DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim ket As String = $"Setor {jenisSumber} oleh {SessionManager.Username}"

            Dim qJurnal As String = "INSERT INTO jurnal_keuangan (id_jurnal, jenis_transaksi, nominal, TipeAliran, MetodeBayar, keterangan, akunID_staff) VALUES (@idJ, 'SETOR KAS', @nom, 'PINDAH', 'INTERNAL', @ket, @staff)"
            Using cmd As New MySqlCommand(qJurnal, conn, trans)
                cmd.Parameters.AddWithValue("@idJ", idJurnal)
                cmd.Parameters.AddWithValue("@nom", nominal)
                cmd.Parameters.AddWithValue("@ket", ket)
                cmd.Parameters.AddWithValue("@staff", SessionManager.AkunID)
                cmd.ExecuteNonQuery()
            End Using

            trans.Commit()

            ' D. Update Session & UI
            If jenisSumber = "CASH" Then
                SessionManager.SubtractCash(nominal)
            Else
                SessionManager.SubtractEmoney(nominal)
            End If

            UpdateLabelSaldo()
            NumericNominal.Value = 0

            MessageBox.Show("Setor Berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Try : trans?.Rollback() : Catch : End Try
            MessageBox.Show("Gagal melakukan setor: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DB.CloseConnection()
        End Try
    End Sub

    ' --- Event Handler ---
    Private Sub LabelSaldoCashDimiliki_Click(sender As Object, e As EventArgs) Handles LabelSaldoCashDimiliki.Click
        UpdateLabelSaldo()
    End Sub

    Private Sub LabelSaldoEmoneyDimiliki_Click(sender As Object, e As EventArgs) Handles LabelSaldoEmoneyDimiliki.Click
        UpdateLabelSaldo()
    End Sub

    Private Sub NumericNominal_ValueChanged(sender As Object, e As EventArgs) Handles NumericNominal.ValueChanged
    End Sub

    Private Sub RadioButtonCash_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonCash.CheckedChanged
    End Sub

End Class