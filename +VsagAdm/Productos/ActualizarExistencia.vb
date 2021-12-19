Public Class ActualizarExistencia

    Private Sub ActualizarExistencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ActualizarExistencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ActualizarExistencia_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            With MisGrid1
                .Columns.Add("col0", "Deposito")
                .Columns.Add("col1", "Cod/Dep")
                .Columns.Add("col2", "Ex. Real")
                .Columns.Add("col3", "Ex. Res")
                .Columns.Add("col4", "Ex. Disp")

                .Columns(0).Width = 120
                .Columns(1).Width = 90
                .Columns(2).Width = 90
                .Columns(3).Width = 90
                .Columns(4).Width = 90
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class