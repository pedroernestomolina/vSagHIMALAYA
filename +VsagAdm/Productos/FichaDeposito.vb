Imports DataSistema.MiDataSistema.DataSistema

Public Class FichaDeposito
    Event _ActualizarFichaProducto()

    Dim xdep As FichaProducto.Prd_Deposito
    Dim xplantilla As IFichaDeposito

    Property _Plantilla() As IFichaDeposito
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IFichaDeposito)
            xplantilla = value
        End Set
    End Property

    Property _FichaDeposito() As FichaProducto.Prd_Deposito
        Get
            Return xdep
        End Get
        Set(ByVal value As FichaProducto.Prd_Deposito)
            xdep = value
        End Set
    End Property

    Private Sub FichaDeposito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Public Sub New(ByVal xregisto As FichaProducto.Prd_Deposito)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _FichaDeposito = xregisto
    End Sub

    Sub New(ByVal xregisto As FichaProducto.Prd_Deposito, ByVal xplantilla As IFichaDeposito)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _FichaDeposito = xregisto
        _Plantilla = xplantilla
    End Sub

    Private Sub FichaDeposito_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            Dim xformato As String = "{0:#0.00}"
            Me.E_PRODUCTO.Text = ""
            Me.E_DEPOSITO.Text = ""
            Me.E_MINIMO.Text = "0.0"
            Me.E_OPTIMO.Text = "0.0"
            Me.E_PEDIDO_OPTIMO.Text = "0.0"
            Me.E_PEDIDO_MINIMO.Text = "0.0"
            Me.E_UB_1.Text = ""
            Me.E_UB_2.Text = ""
            Me.E_UB_3.Text = ""
            Me.E_UB_4.Text = ""

            With xdep.RegistroDato
                Me.E_PRODUCTO.Text = ._NombreProducto.Trim.Trim
                Me.E_DEPOSITO.Text = ._NombreDeposito.Trim
                Me.E_MINIMO.Text = String.Format(xformato, ._NivelMinimo)
                Me.E_OPTIMO.Text = String.Format(xformato, ._NivelOptimo)
                Me.E_PEDIDO_OPTIMO.Text = String.Format(xformato, ._NivelPedidoOptimo)
                Me.E_PEDIDO_MINIMO.Text = String.Format(xformato, ._NivelPedidoMinimo)
                Me.E_UB_1.Text = ._Ubicacion_1
                Me.E_UB_2.Text = ._Ubicacion_2
                Me.E_UB_3.Text = ._Ubicacion_3
                Me.E_UB_4.Text = ._Ubicacion_4
            End With

            If _Plantilla IsNot Nothing Then
                _Plantilla.Inicializa(Me)
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub BT_ACTUALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ACTUALIZAR.Click
        Dim xficha As New InvProducto_UbicacionNivel(xdep.RegistroDato)
        AddHandler xficha._FichaDepositoActualizada_ok, AddressOf ActuializacionFichaDeposito
        With xficha
            .ShowDialog()
        End With
    End Sub

    Sub ActuializacionFichaDeposito()
        RaiseEvent _ActualizarFichaProducto()
        Me.Close()
    End Sub
End Class

Public Interface IFichaDeposito
    Sub Inicializa(ByVal xobj As Object)
End Interface

Public Class FichaDeposito_SoloMostrar
    Implements IFichaDeposito

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents BT As Button

    Public Sub Inicializa(ByVal xobj As Object) Implements IFichaDeposito.Inicializa
        _Form = CType(xobj, System.Windows.Forms.Form)
        BT = _Form.Controls.Find("BT_ACTUALIZAR", True)(0)

        BT.Enabled = False
        _Form.Select()
        _Form.Focus()
    End Sub
End Class