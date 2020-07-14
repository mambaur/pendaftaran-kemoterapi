Imports CrystalDecisions.CrystalReports.Engine

Public Class kartu
    Private Sub kartu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim kartu As New ReportDocument
        kartu.Load("..\..\kartuPasien.rpt")
        kartu.SetParameterValue("no_rm", home.tcetakKartu.Text)
        CRkartu.ReportSource = kartu
    End Sub
End Class