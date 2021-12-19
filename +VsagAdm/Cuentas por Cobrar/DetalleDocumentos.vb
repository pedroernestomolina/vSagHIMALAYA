Imports MisControles.Controles

Public Class DetalleDocumentos
    Dim _Detalle As String
    Dim _Titulo As String

    Const FAC As String = "Detalle De La Factura Numero: "
    Const NCF As String = "Detalle De La Nota De Crédito Numero: "
    Const NDF As String = "Detalle De La Nota De Débito Numero: "
    Const CHD As String = "Detalle Del Cheque Devuelto Numero: "

    Sub New(ByVal xdetalle As String, ByVal xtipo As String, ByVal xdocumento As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Select Case xtipo
            Case "FACTURA", "FAC" : _Titulo = FAC + xdocumento + " !!!"
            Case "NOTA DÉBITO", "ND" : _Titulo = NDF + xdocumento + " !!!"
            Case "NOTA CRÉDITO", "NCF" : _Titulo = NCF + xdocumento + " !!!"
            Case "CHEQUE DEVUELTO", "CHD" : _Titulo = CHD + xdocumento + " !!!"
        End Select
        _Detalle = xdetalle
    End Sub

    Private Sub ControlCuentas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DetalleDocumentos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        LB_TITULO.Text = _Titulo
        LB_DETALLE.Text = _Detalle
    End Sub
End Class