Public Class NotasItem
    Dim xnt As String
    Dim xsalida As Boolean

    Property _SalidaExitosa() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Property _NotasItem() As String
        Get
            Return xnt
        End Get
        Set(ByVal value As String)
            xnt = value
        End Set
    End Property

    Sub New(ByVal xnotas As String, ByVal xlargo As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _NotasItem = xnotas
        _SalidaExitosa = False

        With Me.MT_NOTAS
            .Text = ""
            .MaxLength = xlargo
        End With
    End Sub

    Private Sub NotasItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub NotasItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MT_NOTAS.Text = _NotasItem
        Me.MT_NOTAS.Select()
        Me.MT_NOTAS.Focus()
    End Sub

    Private Sub BT_LIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_LIMPIAR.Click
        _NotasItem = ""
        Me.MT_NOTAS.Text = _NotasItem
        Me.MT_NOTAS.Select()
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        _SalidaExitosa = True
        _NotasItem = Me.MT_NOTAS.Text
        Me.Close()
    End Sub
End Class