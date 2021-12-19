Public Class ClaveRegistro
    Dim xclave As String

    Property _ClaveRetornar() As String
        Get
            Return xclave
        End Get
        Set(ByVal value As String)
            xclave = value
        End Set
    End Property

    Private Sub ClaveRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ClaveRegistro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _ClaveRetornar = ""
        With Me.MT_CLAVE
            .Text = ""
            .MaxLength = 36
            .Focus()
            .Select()
        End With
    End Sub

    Private Sub BT_VALIDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_VALIDAR.Click
        _ClaveRetornar = Me.MT_CLAVE.r_Valor
        Me.Close()
    End Sub
End Class