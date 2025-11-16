Imports MySql.Data.MySqlClient
Imports System.Diagnostics
Imports System.Data

Public Class Akun
    ' Deklarasi objek db untuk koneksi ke database
    Private db As New Database()
    Private WithEvents dbTimer As New Timer()
    Private akunTable As New DataTable()
    Private isEditMode As Boolean = False
    Private originalAkunId As String = ""

    Private Sub Akun_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub Akun_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Timer untuk status database
        dbTimer.Interval = 3000
        dbTimer.Start()

        ' Setup DataGridView
        SiapkanKolomGrid()

        ' Load data akun
        LoadDataAkun()

        ' Load combo box peran
        LoadComboBoxPeran()

        ' Reset form
        ResetForm()
    End Sub

    ' ------------------------------------------
    '  Setup DataGridView
    ' ------------------------------------------
    Private Sub SiapkanKolomGrid()
        With PanelDataAkun
            .AutoGenerateColumns = False
            .Columns.Clear()

            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "akunID",
                .HeaderText = "ID Akun",
                .DataPropertyName = "akunID",
                .Width = 100
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "username",
                .HeaderText = "Username",
                .DataPropertyName = "username",
                .Width = 150
            })
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "email",
                .HeaderText = "Email",
                .DataPropertyName = "email",
                .Width = 200
            })

            ' **[PERBAIKAN]** Ganti 'money' menjadi 'emoney'
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "emoney",
                .HeaderText = "E-Money",
                .DataPropertyName = "emoney",
                .Width = 120,
                .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N0", .Alignment = DataGridViewContentAlignment.MiddleRight}
            })

            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "role",
                .HeaderText = "Peran",
                .DataPropertyName = "role",
                .Width = 100
            })

            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
    End Sub

    ' ------------------------------------------
    '  Load Data Akun
    ' ------------------------------------------
    Private Sub LoadDataAkun(Optional keyword As String = "")
        Try
            db.Koneksi()
            ' **[PERBAIKAN]** Ganti 'money' menjadi 'emoney'
            Dim sql As String = "SELECT akunID, username, email, emoney, role FROM akun"

            If Not String.IsNullOrEmpty(keyword) Then
                sql &= " WHERE akunID LIKE @keyword OR username LIKE @keyword OR email LIKE @keyword"
            End If

            sql &= " ORDER BY username;"

            Using cmd As New MySqlCommand(sql, db.Connection)
                If Not String.IsNullOrEmpty(keyword) Then
                    cmd.Parameters.AddWithValue("@keyword", "%" & keyword & "%")
                End If

                Using adp As New MySqlDataAdapter(cmd)
                    akunTable = New DataTable()
                    adp.Fill(akunTable)
                End Using
            End Using

            PanelDataAkun.DataSource = akunTable
        Catch ex As Exception
            MessageBox.Show("Error saat memuat data akun: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    ' ------------------------------------------
    '  Load ComboBox Peran
    ' ------------------------------------------
    Private Sub LoadComboBoxPeran()
        ComboBoxPeran.Items.Clear()
        ComboBoxPeran.Items.Add("user")
        ComboBoxPeran.Items.Add("staff")
        ComboBoxPeran.Items.Add("admin")
        ComboBoxPeran.SelectedIndex = -1
    End Sub

    ' ------------------------------------------
    '  Reset Form
    ' ------------------------------------------
    Private Sub ResetForm()
        TextBoxID.Clear()
        TextBoxUsername.Clear()
        TextBoxEmail.Clear() ' Ini seharusnya TextEmail, ganti nama kontrol jika perlu

        ComboBoxPeran.SelectedIndex = -1
        PanelDataAkun.ClearSelection()

        isEditMode = False
        originalAkunId = ""
        BtnSimpan.Text = "Simpan"
        BtnUbah.Enabled = False
        BtnHapus.Enabled = False
        TextBoxID.Enabled = True ' Izinkan input ID untuk data baru
    End Sub

    ' ------------------------------------------
    '  Validasi Data
    ' ------------------------------------------
    Private Function ValidasiData() As Boolean
        If String.IsNullOrWhiteSpace(TextBoxID.Text) Then
            MessageBox.Show("ID Akun harus diisi!")
            TextBoxID.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBoxUsername.Text) Then
            MessageBox.Show("Username harus diisi!")
            TextBoxUsername.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(TextBoxEmail.Text) Then
            MessageBox.Show("Email harus diisi!")
            TextBoxEmail.Focus()
            Return False
        End If

        If ComboBoxPeran.SelectedIndex = -1 Then
            MessageBox.Show("Peran harus dipilih!")
            ComboBoxPeran.Focus()
            Return False
        End If

        Return True
    End Function

    ' ------------------------------------------
    '  Tombol Aksi
    ' ------------------------------------------
    Private Sub KembaliBtn_Click(sender As Object, e As EventArgs) Handles KembaliBtn.Click
        Dim dashboardForm As New Dashboard()
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If isEditMode Then
            UpdateData()
        Else
            SimpanDataBaru()
        End If
    End Sub

    Private Sub BtnUbah_Click(sender As Object, e As EventArgs) Handles BtnUbah.Click
        If Not String.IsNullOrEmpty(originalAkunId) Then
            isEditMode = True
            BtnSimpan.Text = "Update"
            TextBoxID.Enabled = False ' Kunci ID saat mode edit
        Else
            MessageBox.Show("Pilih akun yang akan diubah terlebih dahulu!")
        End If
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        HapusData()
    End Sub



    ' ------------------------------------------
    '  Operasi Database
    ' ------------------------------------------
    Private Sub SimpanDataBaru()
        If Not ValidasiData() Then Exit Sub

        ' Cek duplikat ID
        If akunTable.AsEnumerable().Any(Function(r) String.Equals(CStr(r("akunID")), TextBoxID.Text.Trim(), StringComparison.OrdinalIgnoreCase)) Then
            MessageBox.Show("ID Akun sudah ada!")
            Exit Sub
        End If

        ' Cek duplikat username
        If akunTable.AsEnumerable().Any(Function(r) String.Equals(CStr(r("username")), TextBoxUsername.Text.Trim(), StringComparison.OrdinalIgnoreCase)) Then
            MessageBox.Show("Username sudah ada!")
            Exit Sub
        End If

        Try
            db.Koneksi()
            ' **[PERBAIKAN]** Ganti 'money' menjadi 'emoney'
            ' (Asumsi password di-handle di tempat lain atau tidak diperlukan di form ini)
            Dim sql As String = "INSERT INTO akun (akunID, username, email, emoney, role, password) VALUES (@akunID, @username, @email, @emoney, @role, @password);"

            Using cmd As New MySqlCommand(sql, db.Connection)
                cmd.Parameters.AddWithValue("@akunID", TextBoxID.Text.Trim())
                cmd.Parameters.AddWithValue("@username", TextBoxUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@role", ComboBoxPeran.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@emoney", 0) ' Default emoney 0
                cmd.Parameters.AddWithValue("@password", "default_password_hash") ' Ganti dengan hash password default

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Data akun berhasil disimpan!")
                    LoadDataAkun()
                    ResetForm()
                Else
                    MessageBox.Show("Gagal menyimpan data akun!")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saat menyimpan data: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    Private Sub UpdateData()
        If Not ValidasiData() Then Exit Sub

        Try
            db.Koneksi()
            ' **[PERBAIKAN]** Ganti 'money' menjadi 'emoney'
            ' (Tidak mengupdate emoney dari form ini, hanya data admin)
            Dim sql As String = "UPDATE akun SET username = @username, email = @email, role = @role WHERE akunID = @akunID;"

            Using cmd As New MySqlCommand(sql, db.Connection)
                cmd.Parameters.AddWithValue("@akunID", originalAkunId)
                cmd.Parameters.AddWithValue("@username", TextBoxUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@role", ComboBoxPeran.SelectedItem.ToString())

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Data akun berhasil diupdate!")
                    LoadDataAkun()
                    ResetForm()
                Else
                    MessageBox.Show("Gagal mengupdate data akun!")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saat mengupdate data: " & ex.Message)
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Sub

    Private Sub HapusData()
        If String.IsNullOrEmpty(originalAkunId) Then
            MessageBox.Show("Pilih akun yang akan dihapus terlebih dahulu!")
            Return
        End If

        ' Cek jika menghapus akun sendiri
        If originalAkunId = SessionManager.AkunID Then
            MessageBox.Show("Tidak dapat menghapus akun sendiri!")
            Return
        End If

        If MessageBox.Show("Apakah Anda yakin ingin menghapus akun ini?", "Konfirmasi Hapus",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Try
                db.Koneksi()
                Dim sql As String = "DELETE FROM akun WHERE akunID = @akunID;"

                Using cmd As New MySqlCommand(sql, db.Connection)
                    cmd.Parameters.AddWithValue("@akunID", originalAkunId)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Data akun berhasil dihapus!")
                        LoadDataAkun()
                        ResetForm()
                    Else
                        MessageBox.Show("Gagal menghapus data akun!")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error saat menghapus data: " & ex.Message)
            Finally
                If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                    db.CloseConnection()
                End If
            End Try
        End If
    End Sub

    ' ------------------------------------------
    '  Event Grid Click
    ' ------------------------------------------
    Private Sub PanelDataAkun_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles PanelDataAkun.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = PanelDataAkun.Rows(e.RowIndex)

            originalAkunId = row.Cells("akunID").Value.ToString()
            TextBoxID.Text = originalAkunId
            TextBoxUsername.Text = row.Cells("username").Value.ToString()
            TextBoxEmail.Text = If(IsDBNull(row.Cells("email").Value), "", row.Cells("email").Value.ToString())

            ' **[PERBAIKAN]** Tidak ada lagi 'emoney' di form ini untuk diedit
            ' NumericMoney.Value = If(IsDBNull(row.Cells("emoney").Value), 0D, Convert.ToDecimal(row.Cells("emoney").Value))

            ' Set combo box peran
            Dim roleValue As String = row.Cells("role").Value.ToString()
            ComboBoxPeran.SelectedIndex = ComboBoxPeran.FindStringExact(roleValue)

            ' Enable tombol ubah dan hapus
            BtnUbah.Enabled = True
            BtnHapus.Enabled = True
            TextBoxID.Enabled = False
        End If
    End Sub

    ' ------------------------------------------
    '  Timer Database
    ' ------------------------------------------
    Private Function PingDatabase() As String
        Dim stopwatch As New Stopwatch()
        Try
            stopwatch.Start()
            db.Koneksi()
            stopwatch.Stop()
            Return stopwatch.ElapsedMilliseconds.ToString() & "ms"
        Catch ex As Exception
            Return "Connection failed"
        Finally
            If db.Connection IsNot Nothing AndAlso db.Connection.State = ConnectionState.Open Then
                db.CloseConnection()
            End If
        End Try
    End Function

    Private Sub dbTimer_Tick(sender As Object, e As EventArgs) Handles dbTimer.Tick
        Dim pingResult As String = PingDatabase()
        DBstatus.Text = "Database Ping: " & pingResult
    End Sub

    ' ------------------------------------------
    '  Event Text Changed untuk Pencarian
    ' ------------------------------------------
    Private Sub TextBoxID_TextChanged(sender As Object, e As EventArgs) Handles TextBoxID.TextChanged
        If Not isEditMode Then
            PanelDataAkun.ClearSelection()
            BtnUbah.Enabled = False
            BtnHapus.Enabled = False
        End If
    End Sub


    Private Sub ComboBoxPeran_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPeran.SelectedIndexChanged
    End Sub

    ' ------------------------------------------
    '  Pencarian Data
    ' ------------------------------------------
    Private Sub TextBoxPencarian_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPencarian.TextChanged
        LoadDataAkun(TextBoxPencarian.Text.Trim())
    End Sub
End Class