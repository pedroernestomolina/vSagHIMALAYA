Public Class PedirNombre
    Dim xestatus_salida As Boolean
    Dim xdato As String
    Dim xtipoficha As IPedirNombre

    Sub New(ByVal xficha As IPedirNombre)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        xtipoficha = xficha
    End Sub

    Property _EstatusSalida() As Boolean
        Get
            Return xestatus_salida
        End Get
        Set(ByVal value As Boolean)
            xestatus_salida = value

            If value Then
                Me._ValorRetornar = Me.MT_ENTRADA.r_Valor
            End If
        End Set
    End Property

    Property _ValorRetornar() As String
        Get
            Return xdato.Trim
        End Get
        Set(ByVal value As String)
            xdato = value
        End Set
    End Property

    Property _Plantilla() As IPedirNombre
        Get
            Return xtipoficha
        End Get
        Set(ByVal value As IPedirNombre)
            xtipoficha = value
        End Set
    End Property

    Private Sub PedirNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub PedirNombre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label1.Text = xtipoficha.TituloVentana
        Me.Label2.Text = xtipoficha.SubTitulo
        With Me.MT_ENTRADA
            .Text = ""
            .MaxLength = xtipoficha.LargoEntrada
        End With

        Me._EstatusSalida = False
        Me._ValorRetornar = ""
        Me.MT_ENTRADA.Text = _Plantilla._ValorPorDefecto

        Me.MT_ENTRADA.Select()
        Me.MT_ENTRADA.Focus()
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        If Me.MT_ENTRADA.r_Valor <> "" Then
            If MessageBox.Show("Seguro De Guardar Este Documento ?", "*** Mensade De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Me._EstatusSalida = True
                Me.Close()
            End If
        Else
            Me.MT_ENTRADA.Select()
            Me.MT_ENTRADA.Focus()
        End If
    End Sub
End Class

Public Interface IPedirNombre
    ReadOnly Property TituloVentana() As String
    ReadOnly Property SubTitulo() As String
    ReadOnly Property LargoEntrada() As Integer
    ReadOnly Property _ValorPorDefecto() As String
End Interface

Public Class Plantilla_PedirNombre_CtaPendienteVenta
    Implements IPedirNombre
    Dim xvalorpordefecto As String

    Sub New(Optional ByVal xvalor As String = "")
        xvalorpordefecto = xvalor
    End Sub

    Public ReadOnly Property LargoEntrada() As Integer Implements IPedirNombre.LargoEntrada
        Get
            Return 120
        End Get
    End Property

    Public ReadOnly Property SubTitulo() As String Implements IPedirNombre.SubTitulo
        Get
            Return "Indique El Nombre Por Favor. ?"
        End Get
    End Property

    Public ReadOnly Property TituloVentana() As String Implements IPedirNombre.TituloVentana
        Get
            Return "Cuenta Pendiente En Venta. !!!"
        End Get
    End Property

    Public ReadOnly Property _ValorPorDefecto1() As String Implements IPedirNombre._ValorPorDefecto
        Get
            Return xvalorpordefecto
        End Get
    End Property
End Class

Public Class Plantilla_PedirNombre_CtaPendienteCompra
    Implements IPedirNombre
    Dim xvalorpordefecto As String

    Sub New(Optional ByVal xvalor As String = "")
        xvalorpordefecto = xvalor
    End Sub

    Public ReadOnly Property LargoEntrada() As Integer Implements IPedirNombre.LargoEntrada
        Get
            Return 120
        End Get
    End Property

    Public ReadOnly Property SubTitulo() As String Implements IPedirNombre.SubTitulo
        Get
            Return "Indique El Nombre Por Favor. ?"
        End Get
    End Property

    Public ReadOnly Property TituloVentana() As String Implements IPedirNombre.TituloVentana
        Get
            Return "Cuenta Pendiente En Compra. !!!"
        End Get
    End Property

    Public ReadOnly Property _ValorPorDefecto1() As String Implements IPedirNombre._ValorPorDefecto
        Get
            Return xvalorpordefecto
        End Get
    End Property
End Class