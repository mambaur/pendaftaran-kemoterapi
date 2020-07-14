Imports System.Data.Odbc

Public Class home

    '-----------// Semua aksi Menu Master---------------'
    '-----------------------------------------------------'

    '// Menu master diklik
    Private Sub btnMaster_Click(sender As Object, e As EventArgs) Handles btnMaster.Click
        panelMaster.Show()
        PanelDaftar.Hide()
        panelPetugas.Hide()
        panelPasien.Hide()
        panelLaporan.Hide()
    End Sub

    '// Tombol Petugas di klik'
    Private Sub btnPetugas_Click(sender As Object, e As EventArgs) Handles btnPetugas.Click
        panelMaster.Hide()
        PanelDaftar.Hide()
        panelPetugas.Show()
        panelPasien.Hide()
        panelLaporan.Hide()

        Call tampilPetugas()
    End Sub

    '// Tombol tambah petugas diklik'
    Private Sub btnTambahPetugas_Click(sender As Object, e As EventArgs) Handles btnTambahPetugas.Click
        Call Koneksi()
        If idPetugas1.Text = "" Or namaPetugas.Text = "" Or alamatPetugas.Text = "" Or telpPetugas.Text = "" Or agamaPetugas.Text = "" Or usernamePetugas.Text = "" Or passwordPetugas.Text = "" Then
            MsgBox("Input tidak boleh kosong!")
        Else
            Call tambahPetugas()
        End If
    End Sub

    '// Tombol refresh petugas di klik'
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call Koneksi()
        Call refreshPetugas()
    End Sub

    '// Tombol Hapus Petugas di klik'
    Private Sub btnHapusPetugas_Click(sender As Object, e As EventArgs) Handles btnHapusPetugas.Click
        Call Koneksi()
        If idPetugas1.Text = "" Then
            MsgBox("Input id petugas tidak boleh kosong!")
        Else
            Call hapusPetugas()
            Call refreshPetugas()
        End If
    End Sub

    '// Tombol Edit petugas di klik'
    Private Sub btnEditPetugas_Click(sender As Object, e As EventArgs) Handles btnEditPetugas.Click
        Call Koneksi()
        If idPetugas1.Text = "" Or namaPetugas.Text = "" Or alamatPetugas.Text = "" Or telpPetugas.Text = "" Or agamaPetugas.Text = "" Or usernamePetugas.Text = "" Or passwordPetugas.Text = "" Then
            MsgBox("Input tidak boleh kosong!")
        Else
            Call updatePetugas()
            Call refreshPetugas()
        End If
    End Sub

    '// Tombol Kembali di petugas di klik'
    Private Sub btnKembaliPetugas_Click(sender As Object, e As EventArgs) Handles btnKembaliPetugas.Click
        panelMaster.Show()
        PanelDaftar.Hide()
        panelPetugas.Hide()
        panelPasien.Hide()
        panelLaporan.Hide()
    End Sub

    '// Tombol Pasien di klik'
    Private Sub btnPasien_Click(sender As Object, e As EventArgs) Handles btnPasien.Click
        panelMaster.Hide()
        PanelDaftar.Hide()
        panelPetugas.Hide()
        panelPasien.Show()
        panelLaporan.Hide()
    End Sub

    '// Menampilkan data petugas'
    Sub tampilPetugas()
        Call Koneksi()
        adapter = New OdbcDataAdapter("select * from data_petugas", conn)
        dataSet = New DataSet
        adapter.Fill(dataSet, "data_petugas")
        DataGridPetugas.DataSource = dataSet.Tables("data_petugas")
    End Sub

    '// Menambahkan data petugas'
    Sub tambahPetugas()
        Call Koneksi()
        Try
            Dim inputData As String = "insert into data_petugas values('" & idPetugas1.Text & "','" & namaPetugas.Text & "', '" & tanggalPetugas.Value & "', '" & alamatPetugas.Text & "', '" & agamaPetugas.Text & "','" & telpPetugas.Text & "', '" & usernamePetugas.Text & "', '" & passwordPetugas.Text & "')"
            cmd = New OdbcCommand(inputData, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Input data Petugas berhasil!")
            Call refreshPetugas()
        Catch ex As Exception
            MsgBox("Maaf id petugas sudah terdaftar")
        End Try
    End Sub

    '// Update data petugas'
    Sub updatePetugas()
        Call Koneksi()
        Try
            Dim updateData As String = "update data_petugas set NAMA_PETUGAS='" & namaPetugas.Text & "', TANGGAL_LAHIR_PETUGAS='" & tanggalPetugas.Value & "', ALAMAT_PETUGAS='" & alamatPetugas.Text & "', AGAMA_PETUGAS='" & agamaPetugas.Text & "', NOMOR_TELEPON_PETUGAS='" & telpPetugas.Text & "', USERNAME='" & usernamePetugas.Text & "', PASSWORD='" & passwordPetugas.Text & "' where ID_PETUGAS='" & idPetugas1.Text & "'"
            cmd = New OdbcCommand(updateData, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Edit data Petugas berhasil!")
            Call refreshPetugas()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    '// Hapus data petugas'
    Sub hapusPetugas()
        Call Koneksi()
        Try
            Dim hapusData As String = "delete from data_petugas where ID_PETUGAS='" & idPetugas1.Text & "'"
            cmd = New OdbcCommand(hapusData, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Petugas berhasil dihapus!")
            Call refreshPetugas()
        Catch ex As Exception
            MsgBox("Kolom id petugas tidak boleh kosong!")
        End Try
    End Sub

    '// Menampilkan data petugas di GridView'
    Private Sub DataGridPetugas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridPetugas.CellContentClick
        Call Koneksi()
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridPetugas.Rows(index)
        idPetugas1.Text = selectedRow.Cells(0).Value.ToString()
        namaPetugas.Text = selectedRow.Cells(1).Value.ToString()
        tanggalPetugas.Text = selectedRow.Cells(2).Value.ToString()
        alamatPetugas.Text = selectedRow.Cells(3).Value.ToString()
        agamaPetugas.Text = selectedRow.Cells(4).Value.ToString()
        telpPetugas.Text = selectedRow.Cells(5).Value.ToString()
        usernamePetugas.Text = selectedRow.Cells(6).Value.ToString()
        passwordPetugas.Text = selectedRow.Cells(7).Value.ToString()
    End Sub

    '// refresh data petugas'
    Sub refreshPetugas()
        Call Koneksi()
        idPetugas1.ResetText()
        namaPetugas.ResetText()
        tanggalPetugas.ResetText()
        alamatPetugas.ResetText()
        telpPetugas.ResetText()
        agamaPetugas.ResetText()
        usernamePetugas.ResetText()
        passwordPetugas.ResetText()
        Call tampilPetugas()
    End Sub

    '//Tombol Simpan data pasien'
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpanPasien.Click
        Call Koneksi()
        If tnoRM.Text = "" Or tnamaPasien.Text = "" Or talamatPasien.Text = "" Or tagamaPasien.Text = "" Or tJenisKelamin.Text = "" Or tjenisPenyakit.Text = "" Or tPekerjaanPasien.Text = "" Then
            MsgBox("Input tidak boleh ada yang kosong")
        Else
            Call tambahPasien()
        End If
    End Sub

    '// tombolkan bersihkan form pasien
    Private Sub btnBersihkanPasien_Click(sender As Object, e As EventArgs) Handles btnBersihkanPasien.Click
        Call Koneksi()
        Call refreshPasien()
    End Sub

    '//Tombol batal data pasien'
    Private Sub btnBatalPasien_Click(sender As Object, e As EventArgs) Handles btnBatalPasien.Click
        panelMaster.Show()
        PanelDaftar.Hide()
        panelPetugas.Hide()
        panelPasien.Hide()
        panelLaporan.Hide()
    End Sub

    Private Sub btnRefreshPasien_Click(sender As Object, e As EventArgs) Handles btnRefreshPasien.Click
        Call Koneksi()
        Call tampilPasien()
    End Sub

    '// Cari Pasien
    Private Sub tCariPasien_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tCariPasien.KeyPress
        Call Koneksi()
        adapter = New OdbcDataAdapter("select * from data_pasien_kemoterapi where NO_RM_PASIEN LIKE '%" & tCariPasien.Text & "%' OR NAMA_PASIEN LIKE '%" & tCariPasien.Text & "%' OR PEKERJAAN_PASIEN LIKE '%" & tCariPasien.Text & "%'", conn)
        dataSet = New DataSet
        adapter.Fill(dataSet, "data_pasien_kemoterapi")
        DataGridPasien.DataSource = dataSet.Tables("data_pasien_kemoterapi")
    End Sub

    '// Menambahkan data pasien'
    Sub tambahPasien()
        Call Koneksi()
        Try
            Dim inputData As String = "insert into data_pasien_kemoterapi values('" & tnoRM.Text & "','" & session_id & "','" & tnamaPasien.Text & "', '" & tlahirPasien.Value & "', '" & tJenisKelamin.Text & "', '" & tagamaPasien.Text & "','" & talamatPasien.Text & "', '" & tPekerjaanPasien.Text & "', '" & tNoTelpPasien.Text & "', '" & tjenisPenyakit.Text & "', '" & tTanggalKemo.Value & "')"
            cmd = New OdbcCommand(inputData, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Input data Pasien berhasil!")
            Call refreshPasien()
        Catch ex As Exception
            MsgBox("Maaf id Pasien sudah terdaftar!")
        End Try
    End Sub

    '//Refresh form pasien
    Sub refreshPasien()
        Call Koneksi()
        tnoRM.ResetText()
        tnamaPasien.ResetText()
        talamatPasien.ResetText()
        tagamaPasien.ResetText()
        tjenisPenyakit.ResetText()
        tPekerjaanPasien.ResetText()
        tNoTelpPasien.ResetText()
    End Sub

    '-----------// Semua aksi Menu Laporan---------------'
    '-----------------------------------------------------'
    Sub tampilPasien()
        Call Koneksi()
        adapter = New OdbcDataAdapter("select * from data_pasien_kemoterapi", conn)
        dataSet = New DataSet
        adapter.Fill(dataSet, "data_pasien_kemoterapi")
        DataGridPasien.DataSource = dataSet.Tables("data_pasien_kemoterapi")
    End Sub


    '-----------// Semua aksi Menu Sidebar---------------'
    '-----------------------------------------------------'

    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        panelMaster.Hide()
        PanelDaftar.Hide()
        panelPetugas.Hide()
        panelPasien.Hide()
        panelLaporan.Show()
        tampilPasien()
    End Sub

    Private Sub btnDaftar_Click(sender As Object, e As EventArgs) Handles btnDaftar.Click
        panelMaster.Hide()
        PanelDaftar.Hide()
        panelPetugas.Hide()
        panelPasien.Show()
        panelLaporan.Hide()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        login.Show()
        Me.Hide()
        MsgBox("Anda telah di logout")
    End Sub


    '-----------// Semua aksi Form terbuka(load)---------------'
    '-----------------------------------------------------'
    '// Menghubungkan ke DB saat form dibuka'
    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Koneksi()
        panelMaster.Show()
        PanelDaftar.Hide()
        panelPetugas.Hide()
        panelPasien.Hide()
        panelLaporan.Hide()
        labelPetugas.Text = session_user
    End Sub

    Private Sub btnPrintLaporan_Click(sender As Object, e As EventArgs) Handles btnPrintLaporan.Click
        Call Koneksi()
        If cfilterBulan.Text = "" Or cfilterTahun.Text = "" Then
            MsgBox("Input tidak boleh ada yang kosong")
        Else
            laporan.Show()
        End If
    End Sub

    Private Sub btnCetakKartu_Click(sender As Object, e As EventArgs) Handles btnCetakKartu.Click
        Call Koneksi()
        If tcetakKartu.Text = "" Then
            MsgBox("Input tidak boleh ada yang kosong")
        Else
            kartu.Show()
        End If
    End Sub

    Private Sub DataGridPasien_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridPasien.CellContentClick
        Call Koneksi()
        Dim indexcetak As Integer
        indexcetak = e.RowIndex
        Dim selectedRowcetak As DataGridViewRow
        selectedRowcetak = DataGridPasien.Rows(indexcetak)
        tcetakKartu.Text = selectedRowcetak.Cells(0).Value.ToString()
    End Sub
End Class