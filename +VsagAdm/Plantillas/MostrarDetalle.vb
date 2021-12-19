Public Class MostrarDetalle
    Dim xdetalle As String

    Property _Detalle() As String
        Get
            Return xdetalle
        End Get
        Set(ByVal value As String)
            xdetalle = value
        End Set
    End Property

    Sub New(ByVal detalle As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Detalle = detalle
    End Sub

    Private Sub MostrarDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub MostrarDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.E_DETALLE.Text = "No Hay Detalles Que Mostrar"
        If _Detalle.Trim <> "" Then
            Me.E_DETALLE.Text = _Detalle
        End If

        Me.BT_SALIDA.Select()
        Me.BT_SALIDA.Focus()
    End Sub

    Private Sub BT_SALIDA_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SALIDA.Click
        Me.Close()
    End Sub
End Class
