Public Class FichaCamara

    Private Sub FichaCamara_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim xcamara As New MisControles.Controles.MiCamaraWeb
            xcamara.M_IniciarCamara(Me.PictureBox1.Handle)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class