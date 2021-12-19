Public Class FechaInicio
    Dim xfecha As Date

    Property _FechaIniciar() As Date
        Get
            Return xfecha.Date
        End Get
        Set(ByVal value As Date)
            xfecha = value
        End Set
    End Property

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        _FechaIniciar = MF_1.Value
        Me.Close()
    End Sub

    Private Sub FechaInicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FechaInicio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _FechaIniciar = Date.MinValue
        With MF_1
            .Focus()
            .Select()
        End With
    End Sub
End Class