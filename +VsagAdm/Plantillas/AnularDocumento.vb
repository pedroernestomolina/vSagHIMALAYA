Imports DataSistema.MiDataSistema.DataSistema

Public Class AnularDocumento
    Dim xestatus_salida As Boolean
    Dim xdetalle As String
    Dim xplant As IAnularDocumento

    Sub New(ByVal xplantilla As IAnularDocumento)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Plantilla = xplantilla
    End Sub

    Property _Plantilla() As IAnularDocumento
        Get
            Return xplant
        End Get
        Set(ByVal value As IAnularDocumento)
            xplant = value
        End Set
    End Property

    Property _DetalleNotas() As String
        Get
            Return xdetalle
        End Get
        Set(ByVal value As String)
            xdetalle = value
        End Set
    End Property

    Property _EstatusSalida() As Boolean
        Get
            Return xestatus_salida
        End Get
        Set(ByVal value As Boolean)
            xestatus_salida = value
        End Set
    End Property

    Private Sub AnularDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub AnularDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _EstatusSalida = False
        _DetalleNotas = ""

        With MT_DETALLE
            .Text = ""
            .Select()
            .Focus()
        End With

        Me.E_TIPO_DOC.Text = _Plantilla._TipoDocumento
    End Sub

    Private Sub BT_ANULAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ANULAR.Click
        If Me.MT_DETALLE.r_Valor <> "" Then
            If MessageBox.Show("Estas Seguro De Anular Dicho Documento ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Me._EstatusSalida = True
                Me._DetalleNotas = Me.MT_DETALLE.r_Valor
                Me.Close()
            Else
                Me.MT_DETALLE.Select()
                Me.MT_DETALLE.Focus()
            End If
        Else
            MessageBox.Show("Debes Indicar Un Motivo De La Anulacion", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_DETALLE.Select()
            Me.MT_DETALLE.Focus()
        End If
    End Sub
End Class

Public Interface IAnularDocumento
    ReadOnly Property _TipoDocumento() As String
End Interface

Public Class AnularDocumento_Venta
    Implements IAnularDocumento

    Dim xtipo_doc As String

    Sub New(ByVal xtipo As String)
        xtipo_doc = xtipo
    End Sub

    Public ReadOnly Property _TipoDocumento() As String Implements IAnularDocumento._TipoDocumento
        Get
            Return xtipo_doc
        End Get
    End Property
End Class

Public Class AnularDocumento_RetencionVenta
    Implements IAnularDocumento

    Dim xtipo_doc As String

    Sub New(ByVal xtipo As String)
        xtipo_doc = xtipo
    End Sub

    Public ReadOnly Property _TipoDocumento() As String Implements IAnularDocumento._TipoDocumento
        Get
            Return xtipo_doc
        End Get
    End Property
End Class

Public Class AnularDocumento_CuentaPorCobrar
    Implements IAnularDocumento

    Dim xtipo_doc As String

    Sub New(ByVal xtipo As String)
        xtipo_doc = xtipo
    End Sub

    Public ReadOnly Property _TipoDocumento() As String Implements IAnularDocumento._TipoDocumento
        Get
            Return xtipo_doc
        End Get
    End Property
End Class

Public Class AnularDocumento_Compra
    Implements IAnularDocumento

    Dim xtipo_doc As String

    Sub New(ByVal xtipo As String)
        xtipo_doc = xtipo
    End Sub

    Public ReadOnly Property _TipoDocumento() As String Implements IAnularDocumento._TipoDocumento
        Get
            Return xtipo_doc
        End Get
    End Property
End Class

Public Class AnularDocumento_RetencionCompra
    Implements IAnularDocumento

    Dim xtipo_doc As String

    Sub New(ByVal xtipo As String)
        xtipo_doc = xtipo
    End Sub

    Public ReadOnly Property _TipoDocumento() As String Implements IAnularDocumento._TipoDocumento
        Get
            Return xtipo_doc
        End Get
    End Property
End Class