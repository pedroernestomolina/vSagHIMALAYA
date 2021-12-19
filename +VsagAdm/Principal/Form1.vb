Imports System.Net
Imports System.IO

Public Class Plantilla_66
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'Dim xentorno As IAlmacen_1 = New Departamento
            'Dim xficha As New FPlantilla_1(xentorno)
            'xficha.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim x As System.Net.WebRequest
            Dim xr As System.Net.WebResponse

            x = HttpWebRequest.Create("http://whatismyip.com/automation/n09230945.asp")
            xr = x.GetResponse


            ' Get the response stream.
            Dim strm As Stream = xr.GetResponseStream()

            ' Read the response stream.
            Dim sr As StreamReader = New StreamReader(strm)
            Dim sText As String = sr.ReadToEnd()
            strm.Close()

            MsgBox(sText)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class
