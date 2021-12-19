

Partial Public Class DataSet1
    Partial Class Detalle_ReporteDataTable

        Private Sub Detalle_ReporteDataTable_Detalle_ReporteRowChanging(ByVal sender As System.Object, ByVal e As Detalle_ReporteRowChangeEvent) Handles Me.Detalle_ReporteRowChanging

        End Sub

       

    End Class

    Partial Class CompraDataTable

        Private Sub CompraDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.base3Column.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

End Class
