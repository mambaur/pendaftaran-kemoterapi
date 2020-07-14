Imports CrystalDecisions.CrystalReports.Engine

Public Class laporan
    Private Sub laporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim laporan As New ReportDocument
        laporan.Load("..\..\kunjunganPasien.rpt")
        laporan.SetParameterValue("filterMonth", home.cfilterBulan.Text)
        laporan.SetParameterValue("filterYear", home.cfilterTahun.Text)
        CrystalReportViewer1.ReportSource = laporan
    End Sub
End Class