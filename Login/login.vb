Imports System.Data.Odbc


Public Class login

    '---------// ketika tombol login di tekan---------'
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim sql As String
        sql = "select * from data_petugas where USERNAME='" & tusername.Text & "' AND PASSWORD='" & tpassword.Text & "'"
        cmd = New OdbcCommand(sql, conn)
        cek = cmd.ExecuteReader

        If tusername.Text = "" Or tpassword.Text = "" Then
            MsgBox("Input tidak boleh kosong!")
        ElseIf cek.Read = False Then
            MsgBox("Mohon maaf cek kembali username dan password anda")
        Else
            MsgBox("Selamat Login Berhasil")
            session_id = cek.GetString(0)
            session_user = cek.GetString(1)
            home.Show()
            Me.Hide()
        End If

    End Sub

    '------// ketika tombol batal ditekan----------'
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        conn.Close()
        Close()
    End Sub

    '------// Form load----------'
    Private Sub loginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Koneksi()
    End Sub
End Class
