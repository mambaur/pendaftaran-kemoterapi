Imports System.Data.Odbc


Module Connection
    Public conn As OdbcConnection
    Public adapter As OdbcDataAdapter
    Public cmd As OdbcCommand
    Public cek As OdbcDataReader
    Public dataSet As DataSet
    Public myDB As String
    Public session_id As String
    Public session_user As String

    Sub Koneksi()
        myDB = "Driver={Mysql ODBC 3.51 Driver};Database=db_kemoterapi;server=localhost;uid=root"
        Try
            conn = New OdbcConnection(myDB)
            If conn.State = ConnectionState.Closed Then conn.Open()
        Catch ex As Exception
            MsgBox("Database tidak dapat terhubung, silahkan cek koneksi!", MsgBoxStyle.Information, "Info")
        End Try
    End Sub
End Module

