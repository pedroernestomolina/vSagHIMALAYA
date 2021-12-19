Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema
Imports ImpresoraMatriz.ImpresoraMatriz

Public Class ProcesarDoc
    Dim xfichacli As FichaClientes.c_Clientes.c_Registro
    Dim xtipopago As String() = {"CONTADO", "CREDITO"}
    Dim xtb_vendedor As DataTable
    Dim xtotales As TotalesDoc
    Dim xplantilla As IProcesarDocumento
    Dim xestatus_salida As Boolean
    Dim xdoc As FichaVentas.V_Ventas

    ''' <summary>
    ''' INDICA EL DOCUMENTO ORIGEN, YA SEA PRESUPUESTO/NE/PEDIDO
    ''' </summary>
    Property _DocumentoOrigen() As FichaVentas.V_Ventas
        Get
            Return xdoc
        End Get
        Set(ByVal value As FichaVentas.V_Ventas)
            xdoc = value
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

    Property _Plantilla() As IProcesarDocumento
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IProcesarDocumento)
            xplantilla = value
        End Set
    End Property

    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
        Get
            Return xfichacli
        End Get
        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
            xfichacli = value
        End Set
    End Property

    Property _MisTotales() As TotalesDoc
        Get
            Return xtotales
        End Get
        Set(ByVal value As TotalesDoc)
            xtotales = value
        End Set
    End Property

    Sub New(ByVal xtipodoc As IProcesarDocumento, ByVal xcliente As FichaClientes.c_Clientes.c_Registro, ByVal xtotales As TotalesDoc)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._FichaCliente = xcliente
        Me._Plantilla = xtipodoc
        Me._MisTotales = xtotales
    End Sub

    Private Sub ProcesarDoc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _EstatusSalida = True Then
            e.Cancel = False
        Else
            If MessageBox.Show("Salir Sin Procesar Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub ProcesarDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ProcesarDoc_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            _EstatusSalida = False
            With Me.MN_DIAS_CREDITO
                ._ConSigno = False
                ._Formato = "999"
                .Text = "0"
            End With

            With Me.MN_DIAS_VALIDEZ
                ._ConSigno = False
                ._Formato = "999"
                .Text = "0"
                .Enabled = Me._Plantilla._ActivarDiasValidez
            End With

            With Me.MT_PEDIDO
                .MaxLength = 10
                .Text = ""
                .ReadOnly = Not Me._Plantilla._ActivarNumeroPedido
            End With

            With Me.MT_ORDEN_COMPRA
                .MaxLength = 10
                .Text = ""
                .Enabled = Me._Plantilla._ActivarNumeroOrdenCompra
            End With

            With Me.MT_NOTAS
                .MaxLength = 120
                .Text = ""
            End With

            With Me.MT_DIR_DESPACHO
                .MaxLength = 120
                .Text = ""
            End With

            Me.MCB_CONDICION_PAGO.DataSource = xtipopago

            xtb_vendedor = New DataTable
            g_MiData.F_GetData("select nombre,auto from vendedores where estatus='Activo' order by nombre", xtb_vendedor)
            With Me.MCB_VENDEDOR
                .DataSource = xtb_vendedor
                .DisplayMember = "nombre"
                .ValueMember = "auto"
                .SelectedValue = xfichacli.r_AutoVendedor
            End With

            _MisTotales._TasaDescuento = xfichacli.r_DescuentoGlobal
            _MisTotales._TasaCargo = xfichacli.r_CargoPorcentaje

            Me.E_FECHA_EMISION.Text = g_MiData.p_FechaDelMotorBD
            Me.E_FECHA_VENCIMIENTO.Text = g_MiData.p_FechaDelMotorBD

            With Me.MF_ORDEN_COMPRA
                .Value = g_MiData.p_FechaDelMotorBD
                .Enabled = Me._Plantilla._ActivarNumeroOrdenCompra
            End With

            Me.E_CODIGO.Text = Me._FichaCliente.r_CodigoCliente
            Me.E_DIRECCION.Text = Me._FichaCliente.r_DirFiscal
            Me.MT_DIR_DESPACHO.Text = Me._FichaCliente.r_DirDespacho
            Me.E_NOMBRE.Text = Me._FichaCliente.r_NombreRazonSocial
            Me.E_RIF.Text = Me._FichaCliente.r_CiRif

            If Me._FichaCliente.r_CreditoHabilitado Then
                Me.MN_DIAS_CREDITO.Text = Me._FichaCliente.r_DiasCredito.ToString
                Me.MN_DIAS_CREDITO.ReadOnly = False
                Me.MCB_CONDICION_PAGO.SelectedIndex = 1
            Else
                Me.MN_DIAS_CREDITO.Text = "0"
                Me.MN_DIAS_CREDITO.ReadOnly = True
                Me.MCB_CONDICION_PAGO.SelectedIndex = 0
            End If

            Me.MN_DIAS_CREDITO.Select()
            Me.MN_DIAS_CREDITO.Focus()

            Dim xtabla As New DataTable
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@autousuario", g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario)
            Dim xp3 As New SqlParameter("@tipodoc", Me._Plantilla._TipoDocumento)

            g_MiData.F_GetData("select * from temporalventa where idunico=@idunico and tipodocumento=@tipodoc and autousuario=@autousuario", xtabla, xp1, xp2, xp3)
            Dim xautodoc_origen As String = ""
            _DocumentoOrigen = New FichaVentas.V_Ventas
            For Each dr In xtabla.Rows
                If dr("n_autodoc_origen").ToString.Trim <> "" Then
                    xautodoc_origen = dr("n_autodoc_origen").ToString.Trim
                    Exit For
                End If
            Next
            If xautodoc_origen <> "" Then
                _DocumentoOrigen.F_BuscarDocumento(xautodoc_origen)
                Me.MCB_VENDEDOR.SelectedValue = xdoc.RegistroDato._AutoVendedor
                Me.MT_DIR_DESPACHO.Text = xdoc.RegistroDato._DirDespacho
                Me.MT_NOTAS.Text = xdoc.RegistroDato._NotasDocumento
                Me._Plantilla._DocumentoOrigen = _DocumentoOrigen.RegistroDato
            Else
                Me._Plantilla._DocumentoOrigen = Nothing
            End If

        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub MN_DIAS_CREDITO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MN_DIAS_CREDITO.TextChanged
        Dim xfec_e As Date = g_MiData.p_FechaDelMotorBD
        Dim xfec_v As Date = DateAdd(DateInterval.Day, Me.MN_DIAS_CREDITO._Valor, xfec_e).Date
        Me.E_FECHA_VENCIMIENTO.Text = xfec_v
        Me.Refresh()
    End Sub

    Private Sub MCB_CONDICION_PAGO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_CONDICION_PAGO.SelectedIndexChanged
        If Me.MCB_CONDICION_PAGO.SelectedIndex = 0 Then
            Me.MN_DIAS_CREDITO.Text = "0"
            Me.MN_DIAS_CREDITO.ReadOnly = True
        Else
            If Me._FichaCliente.r_CreditoHabilitado Then
                Me.MN_DIAS_CREDITO.Text = "1"
                If Me._FichaCliente.r_DiasCredito > 0 Then
                    Me.MN_DIAS_CREDITO.Text = Me._FichaCliente.r_DiasCredito.ToString
                End If
                Me.MN_DIAS_CREDITO.ReadOnly = False
            Else
                Me.MCB_CONDICION_PAGO.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        ' ESTO SOLO PARA EL CASO DE SER DOCUMENTO TIPO DE VENTA
        _MisTotales._HabilitarMediosPagos = IIf(MCB_CONDICION_PAGO.SelectedIndex = 0, True, False)
        _MisTotales._SaldoAFavorAnticipo = _FichaCliente.r_TotalAnticipos
        _MisTotales._SaldoAFavorNotaCredito = Math.Abs(_FichaCliente.r_TotalCreditos)
        _MisTotales._TasaDescuento = IIf(_DocumentoOrigen IsNot Nothing, _DocumentoOrigen.RegistroDato._TasaDescuento_1, 0)

        If xplantilla.DsctoFormaPago(_MisTotales) Then
            Try
                ''

                Dim r01 = g_MiData.TasaActualDolar_GetData()
                If r01.Result = DataSistema.MiDataSistema.DataSistema.Resultado.EnumResult.isError Then
                    MessageBox.Show(r01.Mensaje, "*** ERROR ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Throw New Exception(r01.Mensaje)
                End If

                Dim _factorCambio As Decimal = r01.Entidad

                Dim xfichavendedor As New FichaVendedores
                xfichavendedor.F_BuscarVendedor(Me.MCB_VENDEDOR.SelectedValue)

                Dim xdatosventa As New IProcesarDocumento.DatosVenta
                With xdatosventa
                    ._Cliente = _FichaCliente
                    ._Vendedor = xfichavendedor.f_Vendedor.RegistroDato
                    ._CondicionPago = IIf(MCB_CONDICION_PAGO.SelectedIndex = 0, FichaVentas.TipoCondcionPago.Contado, FichaVentas.TipoCondcionPago.Credito)
                    ._DiasCredito = MN_DIAS_CREDITO._Valor
                    ._DirDespacho = MT_DIR_DESPACHO.r_Valor
                    ._NotasDetalle = MT_NOTAS.r_Valor
                    ._NumeroOrdenCompra = MT_ORDEN_COMPRA.r_Valor
                    ._NumeroPedido = MT_PEDIDO.r_Valor
                    ._FechaOrdenCompra = MF_ORDEN_COMPRA.Value
                    ._MontoBase_1 = _MisTotales._Neto1
                    ._MontoBase_2 = _MisTotales._Neto2
                    ._MontoBase_3 = _MisTotales._Neto3
                    ._MontoExento = _MisTotales._Exento
                    ._TasaCargo = _MisTotales._TasaCargo
                    ._TasaDescuento_1 = _MisTotales._TasaDescuento
                    ._TasaDescuento_2 = 0
                    ._TasaIva_1 = _MisTotales._TasaIva1
                    ._TasaIva_2 = _MisTotales._TasaIva2
                    ._TasaIva_3 = _MisTotales._TasaIva3
                    ._TotalRenglones = _MisTotales._Lineas
                    ._MontoSubTotal = _MisTotales._Subtotal
                    ._DocChimbo = _MisTotales._DocChimbo
                    ._TablaPagos = _MisTotales._TablaPagos
                    ._DiasValidezDocumento = MN_DIAS_VALIDEZ._Valor
                    .TablaItems = _MisTotales.Items
                    .DsctoGeneralMonto = _MisTotales._MontoDescuento
                    .CargoGeneralMonto = _MisTotales.MontoCargo
                    ''
                    .FactorCambio = _factorCambio
                End With
                _EstatusSalida = xplantilla.ProcesarDoc(xdatosventa, Me)
                Me.Close()
            Catch ex As Exception
                _EstatusSalida = True
                Throw New Exception(ex.Message)
            Finally
                Me.Close()
            End Try
        Else
            Me.MN_DIAS_CREDITO.Select()
            Me.MN_DIAS_CREDITO.Focus()
            Me.Select()
        End If
    End Sub

    Private Sub MN_DIAS_CREDITO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MN_DIAS_CREDITO.Validating
        If Me._FichaCliente.r_CreditoHabilitado Then
            If Me.MN_DIAS_CREDITO._Valor = 0 Then
                Me.MN_DIAS_CREDITO.Text = "1"
            End If
        End If
    End Sub
End Class

Public Interface IProcesarDocumento
    Class DatosVenta
        Private xcliente As FichaClientes.c_Clientes.c_Registro
        Private xvendedor As FichaVendedores.c_Vendedor.c_Registro
        Private xtipopago As FichaVentas.TipoCondcionPago
        Private xdiascredito As Integer
        Private xdirdespacho As String
        Private xnotas As String
        Private xpedido As String
        Private xordencompra As String
        Private xfechaordercompra As Date
        Private xrenglones As Integer
        Private xexento As Decimal
        Private xmontobase1 As Decimal
        Private xmontobase2 As Decimal
        Private xmontobase3 As Decimal
        Private xtasaiva1 As Decimal
        Private xtasaiva2 As Decimal
        Private xtasaiva3 As Decimal
        Private xtasadescuento_1 As Decimal
        Private xtasadescuento_2 As Decimal
        Private xtasacargo As Decimal
        Private xmontosubtotal As Decimal
        Private xdiasvalidezdoc As Integer
        Private xtablapagos As DataTable
        Private xchimbo As Boolean
        Private xtabla_items As DataTable


        ''
        Property FactorCambio As Decimal
        Property EstatusDivisa As Boolean


        Property TablaItems() As DataTable
            Get
                Return xtabla_items
            End Get
            Set(ByVal value As DataTable)
                xtabla_items = value
            End Set
        End Property

        Property _TablaPagos() As DataTable
            Get
                Return xtablapagos
            End Get
            Set(ByVal value As DataTable)
                xtablapagos = value
            End Set
        End Property

        Property _DocChimbo() As Boolean
            Get
                Return xchimbo
            End Get
            Set(ByVal value As Boolean)
                xchimbo = value
            End Set
        End Property

        Property _TotalRenglones() As Integer
            Get
                Return xrenglones
            End Get
            Set(ByVal value As Integer)
                xrenglones = value
            End Set
        End Property
        Property _MontoExento() As Decimal
            Get
                Return xexento
            End Get
            Set(ByVal value As Decimal)
                xexento = value
            End Set
        End Property
        Property _MontoBase_1() As Decimal
            Get
                Return xmontobase1
            End Get
            Set(ByVal value As Decimal)
                xmontobase1 = value
            End Set
        End Property
        Property _MontoBase_2() As Decimal
            Get
                Return xmontobase2
            End Get
            Set(ByVal value As Decimal)
                xmontobase2 = value
            End Set
        End Property
        Property _MontoBase_3() As Decimal
            Get
                Return xmontobase3
            End Get
            Set(ByVal value As Decimal)
                xmontobase3 = value
            End Set
        End Property
        Property _TasaIva_1() As Decimal
            Get
                Return xtasaiva1
            End Get
            Set(ByVal value As Decimal)
                xtasaiva1 = value
            End Set
        End Property
        Property _TasaIva_2() As Decimal
            Get
                Return xtasaiva2
            End Get
            Set(ByVal value As Decimal)
                xtasaiva2 = value
            End Set
        End Property
        Property _TasaIva_3() As Decimal
            Get
                Return xtasaiva3
            End Get
            Set(ByVal value As Decimal)
                xtasaiva3 = value
            End Set
        End Property
        Property _TasaDescuento_1() As Decimal
            Get
                Return xtasadescuento_1
            End Get
            Set(ByVal value As Decimal)
                xtasadescuento_1 = value
            End Set
        End Property
        Property _TasaDescuento_2() As Decimal
            Get
                Return xtasadescuento_2
            End Get
            Set(ByVal value As Decimal)
                xtasadescuento_2 = value
            End Set
        End Property
        Property _TasaCargo() As Decimal
            Get
                Return xtasacargo
            End Get
            Set(ByVal value As Decimal)
                xtasacargo = value
            End Set
        End Property

        ''' <summary>
        ''' SUMATORIA DE BASES + EXENTO, SIN DESCUENTO NI CARGO GLOBAL
        ''' </summary>
        Property _MontoSubTotal() As Decimal
            Get
                Return xmontosubtotal
            End Get
            Set(ByVal value As Decimal)
                xmontosubtotal = value
            End Set
        End Property

        '._MontoSaldoPendiente

        Property _NotasDetalle() As String
            Get
                Return xnotas
            End Get
            Set(ByVal value As String)
                xnotas = value
            End Set
        End Property

        Property _NumeroPedido() As String
            Get
                Return xpedido
            End Get
            Set(ByVal value As String)
                xpedido = value
            End Set
        End Property

        Property _NumeroOrdenCompra() As String
            Get
                Return xordencompra
            End Get
            Set(ByVal value As String)
                xordencompra = value
            End Set
        End Property

        Property _DirDespacho() As String
            Get
                Return xdirdespacho
            End Get
            Set(ByVal value As String)
                xdirdespacho = value
            End Set
        End Property

        Property _DiasCredito() As Integer
            Get
                Return xdiascredito
            End Get
            Set(ByVal value As Integer)
                xdiascredito = value
            End Set
        End Property

        Property _Cliente() As FichaClientes.c_Clientes.c_Registro
            Get
                Return xcliente
            End Get
            Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                xcliente = value
            End Set
        End Property

        Property _Vendedor() As FichaVendedores.c_Vendedor.c_Registro
            Get
                Return xvendedor
            End Get
            Set(ByVal value As FichaVendedores.c_Vendedor.c_Registro)
                xvendedor = value
            End Set
        End Property

        Property _CondicionPago() As FichaVentas.TipoCondcionPago
            Get
                Return xtipopago
            End Get
            Set(ByVal value As FichaVentas.TipoCondcionPago)
                xtipopago = value
            End Set
        End Property

        Property _FechaOrdenCompra() As Date
            Get
                Return xfechaordercompra
            End Get
            Set(ByVal value As Date)
                xfechaordercompra = value
            End Set
        End Property

        Property _DiasValidezDocumento() As Integer
            Get
                Return xdiasvalidezdoc
            End Get
            Set(ByVal value As Integer)
                xdiasvalidezdoc = value
            End Set
        End Property

        Private _dsctoGeneralMonto As Decimal
        Property DsctoGeneralMonto() As Decimal
            Get
                Return _dsctoGeneralMonto
            End Get
            Set(ByVal value As Decimal)
                _dsctoGeneralMonto = value
            End Set
        End Property

        Private _cargoGeneralMonto As Decimal
        Property CargoGeneralMonto() As Decimal
            Get
                Return _cargoGeneralMonto
            End Get
            Set(ByVal value As Decimal)
                _cargoGeneralMonto = value
            End Set
        End Property


        Sub New()
            Me._DocChimbo = False
            Me._Cliente = Nothing
            Me._Vendedor = Nothing
            Me._DiasCredito = 0
            Me._CondicionPago = FichaVentas.TipoCondcionPago.Contado
            Me._DirDespacho = ""
            Me._NotasDetalle = ""
            Me._NumeroOrdenCompra = ""
            Me._NumeroPedido = ""
            Me._FechaOrdenCompra = Date.MinValue
            Me._DiasValidezDocumento = 0
            Me._TotalRenglones = 0
            Me._MontoExento = 0
            Me._MontoBase_1 = 0
            Me._MontoBase_2 = 0
            Me._MontoBase_3 = 0
            Me._TasaCargo = 0
            Me._TasaDescuento_1 = 0
            Me._TasaDescuento_2 = 0
            Me._TasaIva_1 = 0
            Me._TasaIva_2 = 0
            Me._TasaIva_3 = 0
            Me.TablaItems = New DataTable
            Me.DsctoGeneralMonto = 0.0
            Me.CargoGeneralMonto = 0.0
            ''
            EstatusDivisa = False
            FactorCambio = 0.0
        End Sub
    End Class

    ReadOnly Property _ActivarDiasValidez() As Boolean
    ReadOnly Property _ActivarNumeroOrdenCompra() As Boolean
    ReadOnly Property _ActivarNumeroPedido() As Boolean
    ReadOnly Property _TipoDocumento() As String
    Property _DocumentoOrigen() As FichaVentas.V_Ventas.c_Registro

    Function ProcesarDoc(ByVal xdataventa As DatosVenta, ByVal xform As Object) As Boolean
    Event DocumentoProcesado()
    Function DsctoFormaPago(ByRef xtotales As TotalesDoc) As Boolean
End Interface

Public Class ProcesarDocumentoVenta
    Implements IProcesarDocumento
    Public Event DocumentoProcesado() Implements IProcesarDocumento.DocumentoProcesado

    WithEvents _Form As Windows.Forms.Form
    Dim xdoc_origen As FichaVentas.V_Ventas.c_Registro


    Public Function ProcesarDoc(ByVal xdataventa As IProcesarDocumento.DatosVenta, ByVal xform As Object) As Boolean Implements IProcesarDocumento.ProcesarDoc
        _Form = CType(xform, Windows.Forms.Form)

        Dim xventa_encabezado As New FichaVentas.V_Ventas.AgregarVenta
        Dim xventa_detalle As New List(Of FichaVentas.V_VentasDetalle.AgregarDetalleVenta)
        Dim xventas As New FichaVentas
        Dim xtabla As New DataTable
        Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
        Dim xp2 As New SqlParameter("@autousuario", g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario)

        Try
            Dim xautodoc_origen As String = ""
            If (_DocumentoOrigen IsNot Nothing) Then
                xautodoc_origen = _DocumentoOrigen._AutoDocumento
            End If
            'g_MiData.F_GetData("select * from temporalventa where idunico=@idunico and tipodocumento='1' and autousuario=@autousuario", xtabla, xp1, xp2)
            xtabla = xdataventa.TablaItems

            With xventa_encabezado
                ._FichaCliente = xdataventa._Cliente
                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._FichaVendedor = xdataventa._Vendedor
                ._CantidadRenglones = xdataventa._TotalRenglones
                ._CodigoSucursal = g_MiData.f_FichaGlobal.f_Negocio.RegistroDato.c_CodigoSucursal.c_Texto
                ._CondicionPago = xdataventa._CondicionPago
                ._DiasCreditoOtorgado = xdataventa._DiasCredito
                ._DirDespacho = xdataventa._DirDespacho
                ._EstacionEquipoProceso = g_EquipoEstacion.p_EstacionNombre
                ._FactorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                ._FechaOrdenCompra = xdataventa._FechaOrdenCompra
                ._MontoBase_1 = xdataventa._MontoBase_1
                ._MontoBase_2 = xdataventa._MontoBase_2
                ._MontoBase_3 = xdataventa._MontoBase_3
                ._MontoExento = xdataventa._MontoExento
                ._MontoSaldoPendiente = 0
                ._MontoSubtotal = xdataventa._MontoSubTotal
                ._NotasDocumento = xdataventa._NotasDetalle
                ._NumeroPedido = xdataventa._NumeroPedido
                ._OrdenCompraNumero = xdataventa._NumeroOrdenCompra
                ._SerieFiscalAsignada = g_ConfiguracionSistema._SerieFactura
                ._TasaCargos = xdataventa._TasaCargo
                ._TasaDescuento_1 = xdataventa._TasaDescuento_1
                ._TasaDescuento_2 = xdataventa._TasaDescuento_2
                ._TasaIva_1 = xdataventa._TasaIva_1
                ._TasaIva_2 = xdataventa._TasaIva_2
                ._TasaIva_3 = xdataventa._TasaIva_3
                ._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Factura
                ._DocumentoOrigen_PresupuestoPedidoNotaEntrega = xautodoc_origen
                ._DiasValidezDocumento = 0
                ._DescuentoPorProntoPago = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCxCobrar._DescuentoPorProntoPago
                .SubTotal_1 = (xdataventa._MontoSubTotal + xdataventa.DsctoGeneralMonto - xdataventa.CargoGeneralMonto)
                .DsctoGeneralMonto = xdataventa.DsctoGeneralMonto
                .CargoGeneralMonto = xdataventa.CargoGeneralMonto
            End With

            For Each xrow As DataRow In xtabla.Rows
                Dim xreg As New FichaVentas.V_TemporalVenta.c_Registro
                Dim xdetalle As New FichaVentas.V_VentasDetalle.AgregarDetalleVenta
                Dim xprd As New FichaProducto.Prd_Producto
                Dim xdeposito As New FichaGlobal.c_Depositos

                xreg.CargarRegistro(xrow)
                xprd.F_BuscarProducto(xreg._AutoProducto)
                xdeposito.F_BuscarDeposito(xreg._AutoDeposito)

                With xdetalle
                    ._AutoDepartamento = xprd.RegistroDato._AutoDepartamento
                    ._AutoGrupo = xprd.RegistroDato._AutoGrupo
                    ._AutoProducto = xreg._AutoProducto
                    ._AutoSubGrupo = xprd.RegistroDato._AutoSubGrupo
                    ._CantidadDespachada = xreg._CantidadDespachar
                    ._ContenidoEmpaque = xreg._ContenidoEmpaque
                    ._CodigoProducto = xreg._CodigoProducto
                    'PRODUCTO SE FACTURA CON COSTO ACTUALIZADO AL DIA
                    ._CostoInventario = xprd.RegistroDato._CostoCompra._Base_Inv
                    ._CostoVenta = Decimal.Round(xprd.RegistroDato._CostoCompra._Base_Inv * xreg._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                    ._DescuentoTasa_1 = xreg._Descuento
                    ._DetalleNotas = xreg._ItemNotas
                    ._DiasGarantia = xprd.RegistroDato._DiasDeGarantia
                    ._EstatusGarantia = xprd.RegistroDato._EstatusGarantia
                    ._EstatusSerial = xprd.RegistroDato._EstatusSerial
                    ._NombreEmpaque = xreg._NombreEmpaque
                    ._NombreProducto = xreg._NombreProducto
                    ._NumeroDecimales = xreg._NumeroDecimalesMedida
                    ._PrecioNeto = xreg._PrecioNeto
                    ._PrecioSugerido = xreg._PSugerido
                    ._ReferenciaEmpaque = xreg._ReferenciaEmpaque
                    ._TasaIva = xreg._TasaIva
                    ._TipoTasaIva = xreg._TipoTasa
                    ._AutoDeposito = xdeposito.RegistroDato._Automatico
                    ._NombreDeposito = xdeposito.RegistroDato._Nombre
                    ._CodigoDeposito = xdeposito.RegistroDato._Codigo
                    ._DepositoBloqueado = xreg._BloquearExistencia
                    ._AutoMedidaEmpaque = xreg._AutoMedida
                    ._TipoCalculoUtilidad = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad
                    ._ForzarMedida = xreg._ForzarMedida
                    ._EsPesado = xreg._EsPesado
                    ._FichaItem_DocOrigen = xreg._f_FichaVentaDetalle_AutoItem_DocumentoOrigen
                    ._DescripcionCortaProducto = xprd.RegistroDato._DescripcionResumenDelProducto
                End With
                xventa_detalle.Add(xdetalle)
            Next

            Dim xlistapago As New List(Of FichaCtasCobrar.c_ModosPago.AgregarModoPago)
            For Each xregpago As DataRow In xdataventa._TablaPagos.Rows
                If xregpago.RowState <> DataRowState.Deleted Then
                    Dim xpago As New FichaCtasCobrar.c_ModosPago.AgregarModoPago
                    With xpago
                        ._AutoAgencia = ""
                        ._AutoTipoPago = xregpago("AutoTipoPago").ToString.Trim
                        ._CodigoTipoPago = xregpago("CodigoTipoPago").ToString.Trim
                        ._MontoImporte = xregpago("Monto").ToString.Trim
                        ._MontoRecibido = xregpago("Monto").ToString.Trim
                        ._NombreAgencia = xregpago("Agencia").ToString.Trim
                        ._NombreTipoPago = xregpago("TipoPago").ToString.Trim
                        ._Numero = xregpago("Planilla").ToString.Trim
                    End With
                    xlistapago.Add(xpago)
                End If
            Next

            If xtabla.Rows.Count > 0 Then
                If xdataventa._DocChimbo = True Then
                Else
                    If xautodoc_origen = "" Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_Factura > 0 Then
                            If (xtabla.Rows.Count <= g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_Factura) Then
                            Else
                                Throw New Exception("ERROR ... NUMERO DE RENGLONES SUPERA EL LIMITE")
                            End If
                        End If
                    End If
                End If
                Dim xcond As New FichaVentas.CondicionesParaVenta _
                         With {._Permitir_PrecioCero = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Precio_En_Cero, _
                               ._Permitir_PrecioMenorCosto = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Por_Debajo_Costo, _
                               ._Permitir_RupturaPorExistencia = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Ruptura_Por_Existencia}

                If xdataventa._DocChimbo Then ' NOTAS CHIMBAS / NEGRAS
                    AddHandler xventas.DocumentoProcesado, AddressOf ImprimirFacturaChimba
                    xventas.F_GrabarVentaChimba(g_ConfiguracionSistema._Id_UnicoDelEquipo, xventa_encabezado, xventa_detalle, xlistapago, xcond)
                Else ' FACTURA LEGAL
                    Dim ximpresora As New FichaVentas.ModoImprimirFactura
                    With ximpresora
                        ._FormatoNombre = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALFACTURAR_Formato
                        ._ModoImpresion = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALFACTURAR_MedioImpresion
                        ._RutaImpresora = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALFACTURAR_RutaImpresora
                        ._Impresora = g_ImpFiscal
                        ._OrdenAlImprimir = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Orden_Al_Imprimir_Items
                        ._ImprimirLineaDetalle_EmpaqueContenidoSugerio_Imp_Fiscal = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PermitirImprimirLinea_EmpaqueSugeridoContenido_ImpFiscal_AlFacturar
                        ._SubDetalleFiscal_1 = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._SubDetalleFiscal_1
                        ._SubDetalleFiscal_2 = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._SubDetalleFiscal_2
                        ._SubDetalleFiscal_3 = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._SubDetalleFiscal_3
                        ._SubDetalleFiscal_4 = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._SubDetalleFiscal_4
                    End With
                    If ximpresora._ModoImpresion = TipoImpresora.Grafico Then
                        AddHandler xventas.DocumentoProcesado, AddressOf VisualizarDoc_Ventas
                    ElseIf ximpresora._ModoImpresion = TipoImpresora.Fiscal Then
                        ximpresora._Impresora.Estatus()
                    ElseIf ximpresora._ModoImpresion = TipoImpresora.Texto Then
                        AddHandler xventas.DocumentoProcesado, AddressOf ImprimirFactura
                    End If

                    If ximpresora._ModoImpresion = TipoImpresora.Fiscal Then
                        If MiDecretoEmergencia.DecretoEmergenciaActivo Then
                            F_VerificarClaveInstalacion(MiDecretoEmergencia.ClaveSeguridad, g_ImpFiscal.Ver_RifImpresoraFiscal)
                        End If
                    End If


                    Dim zFiscal = 0
                    If ximpresora._ModoImpresion = TipoImpresora.Fiscal Then
                        zFiscal = Integer.Parse(ximpresora._Impresora.Ver_UltimoZFiscal)
                    End If
                    Dim xbase = (xdataventa._MontoBase_1 + xdataventa._MontoBase_2 + xdataventa._MontoBase_3)
                    Dim ximp1 = (xdataventa._MontoBase_1 * xdataventa._TasaIva_1 / 100)
                    Dim ximp2 = (xdataventa._MontoBase_2 * xdataventa._TasaIva_1 / 100)
                    Dim ximp3 = (xdataventa._MontoBase_3 * xdataventa._TasaIva_1 / 100)
                    Dim ximp = ximp1 + ximp2 + ximp3
                    Dim xtot = xdataventa._MontoExento + xbase + ximp
                    Dim saldoP = IIf(xdataventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado, 0, xtot)

                    Dim tserieFiscal = xventas.F_SerieFiscal_GetBySerie(g_ConfiguracionSistema._SerieFactura)
                    If tserieFiscal.IsError Then
                        Throw New Exception(tserieFiscal.Mensaje)
                    End If

                    Dim tdeposito = xventas.F_Deposito_GetById(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoInventarioVentas)
                    If tdeposito.IsError Then
                        Throw New Exception(tdeposito.Mensaje)
                    End If

                    Dim tconceptoInv = xventas.F_ConceptoInv_GetById("0000000008")
                    If tconceptoInv.IsError Then
                        Throw New Exception(tconceptoInv.Mensaje)
                    End If

                    Dim numpedido = ""
                    If Not IsNothing(_DocumentoOrigen) Then
                        numpedido = _DocumentoOrigen._Documento
                    End If

                    Dim ficha As GenFactura = New GenFactura
                    Dim encabezado As GenEncabezado = New GenEncabezado
                    With encabezado
                        .serieAuto = tserieFiscal.Entidad.auto
                        .bloquearAlmacen = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Ruptura_Por_Existencia, "1", "0")
                        .cliAuto = xdataventa._Cliente.r_Automatico
                        .cliCiRif = xdataventa._Cliente.r_CiRif
                        .cliCodigo = xdataventa._Cliente.r_CodigoCliente
                        .cliDirDespacho = xdataventa._DirDespacho
                        .cliDirFiscal = xdataventa._Cliente.r_DirFiscal
                        .cliNombre = xdataventa._Cliente.r_NombreRazonSocial
                        .cliTelefono = xdataventa._Cliente.r_Telefono_1
                        .condPago = IIf(xdataventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado, "CONTADO", "CREDITO")
                        .condPagoIsContado = xdataventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado
                        .control = ""
                        .diasCredito = xdataventa._DiasCredito
                        .estacionEquipo = g_EquipoEstacion.p_EstacionNombre
                        .factorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                        .fechaPedido = Now.Date
                        .montoBase = xbase
                        .montoBase1 = xdataventa._MontoBase_1
                        .montoBase2 = xdataventa._MontoBase_2
                        .montoBase3 = xdataventa._MontoBase_3
                        .montoCargo = xdataventa.CargoGeneralMonto
                        .montoDescuento = xdataventa.DsctoGeneralMonto
                        .montoDivisa = xtot / g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                        .montoExento = xdataventa._MontoExento
                        .montoImpuesto = ximp
                        .montoImpuesto1 = ximp1
                        .montoImpuesto2 = ximp2
                        .montoImpuesto3 = ximp3
                        .montoTotal = xtot
                        .Notas = xdataventa._NotasDetalle
                        .numPedido = numpedido
                        .ordeCompra = xdataventa._NumeroOrdenCompra
                        .porcCargo = xdataventa._TasaCargo
                        .porcDescuento = xdataventa._TasaDescuento_1
                        .renglones = xtabla.Rows.Count
                        .saldoPend = saldoP
                        .serieNombre = tserieFiscal.Entidad.nombre
                        .serieSerial = tserieFiscal.Entidad.numeroRegistroFiscal
                        .subTotal = (xdataventa._MontoSubTotal + xdataventa.DsctoGeneralMonto - xdataventa.CargoGeneralMonto)
                        .tasa1 = xdataventa._TasaIva_1
                        .tasa2 = xdataventa._TasaIva_2
                        .tasa3 = xdataventa._TasaIva_3
                        .usuAuto = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario
                        .usuCodigo = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._CodigoUsuario
                        .usuNombre = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
                        .vendAuto = xdataventa._Vendedor.r_Automatico
                        .vendCodigo = xdataventa._Vendedor.r_CodigoVendedor
                        .vendNombre = xdataventa._Vendedor.r_NombreVendedor
                        .zFiscal = zFiscal
                        .depAuto = tdeposito.Entidad.auto
                        .depCodigo = tdeposito.Entidad.codigo
                        .depNombre = tdeposito.Entidad.nombre
                        .conceptoAuto = tconceptoInv.Entidad.auto
                        .conceptoCodigo = tconceptoInv.Entidad.codigo
                        .conceptoNombre = tconceptoInv.Entidad.nombre
                        .cobradorAuto = xdataventa._Cliente.r_AutoCobrador
                        .cobradorCodigo = ""
                        .cobradorNombre = xdataventa._Cliente.r_NombreCobrador
                    End With

                    Dim lDetalles As List(Of GenDetalle) = New List(Of GenDetalle)
                    For Each xrow As DataRow In xtabla.Rows
                        Dim xreg As New FichaVentas.V_TemporalVenta.c_Registro
                        Dim xprd As New FichaProducto.Prd_Producto

                        xreg.CargarRegistro(xrow)
                        xprd.F_BuscarProducto(xreg._AutoProducto)

                        Dim xpItem = xreg._PrecioNeto - (xreg._PrecioNeto * xreg._Descuento / 100)
                        Dim xtneto = xpItem * xreg._CantidadDespachar
                        Dim ximpuesto = xtneto * xreg._TasaIva / 100
                        Dim xpFinal As Decimal = xpItem
                        xpFinal = Decimal.Round(xpFinal - (xpFinal * xdataventa._TasaDescuento_1 / 100), 2, MidpointRounding.AwayFromZero)
                        xpFinal = Decimal.Round(xpFinal + (xpFinal * xdataventa._TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
                        Dim xpFinalInv = Decimal.Round(xpFinal / xreg._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                        Dim tVenta = xpFinal * xreg._CantidadDespachar
                        Dim tCosto = (xprd.RegistroDato._CostoCompra._Base_Inv * xreg._ContenidoEmpaque) * xreg._CantidadDespachar
                        Dim tMargen = tVenta - tCosto
                        Dim tTasaMargen = 0D
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            tTasaMargen = UtilidadBaseCosto(tCosto, tMargen)
                        Else
                            tTasaMargen = UtilidadBasePrecioVenta(tVenta, tMargen)
                        End If

                        Dim detalle As GenDetalle = New GenDetalle
                        With detalle
                            .cantidad = xreg._CantidadDespachar
                            .cantUnd = xreg._CantidadDespachar * xreg._ContenidoEmpaque
                            .categoria = xprd.RegistroDato._CategoriaDelProducto
                            .codigoTasaIva = xreg._TipoTasa
                            .confTipoCalcUtilidad = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto, "C", "V")
                            .contEmpaque = xreg._ContenidoEmpaque
                            .costo = Decimal.Round(xprd.RegistroDato._CostoCompra._Base_Inv * xreg._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                            .costoUnd = xprd.RegistroDato._CostoCompra._Base_Inv
                            .departAuto = xprd.RegistroDato._AutoDepartamento
                            .descMonto_1 = xreg._DsctoMonto
                            .descMonto_2 = 0D
                            .descMonto_3 = 0D
                            .descPorc_1 = xreg._Descuento
                            .descPorc_2 = 0D
                            .descPorc_3 = 0D
                            .detalle = xreg._ItemNotas
                            .empaque = xreg._NombreEmpaque
                            .empaqueTipo = xreg._ReferenciaEmpaque
                            .grupoAuto = xprd.RegistroDato._AutoGrupo
                            .impuesto = Decimal.Round(ximpuesto, 2, MidpointRounding.AwayFromZero)
                            .medidaAuto = xreg._AutoMedida
                            .medidaDecimales = xreg._NumeroDecimalesMedida
                            .medidaForzar = IIf(xreg._ForzarMedida, "1", "0")
                            .prdAuto = xprd.RegistroDato._AutoProducto
                            .prdCodigo = xprd.RegistroDato._CodigoProducto
                            .prdDescripcion = xprd.RegistroDato._DescripcionDetallaDelProducto
                            .prdNombre = xprd.RegistroDato._DescripcionResumenDelProducto
                            .precioFinal = xpFinal
                            .precioInv = xpFinalInv
                            .precioItem = xpItem
                            .precioNeto = xreg._PrecioNeto
                            .psv = xreg._PSugerido
                            .subGrupAuto = xprd.RegistroDato._AutoSubGrupo
                            .tasaIva = xreg._TasaIva
                            .total = Decimal.Round(xtneto + ximpuesto, 2, MidpointRounding.AwayFromZero)
                            .totalNeto = Decimal.Round(xtneto, 2, MidpointRounding.AwayFromZero)
                            .medidaNombre = xreg._NombreEmpaque
                            .utilidad = tMargen
                            .utilidadPorc = tTasaMargen
                            .idItemTemp = xreg._AutoItem
                            .provDocOrigen = IIf(xreg._AutoDocumentoOrigen <> "", True, False)
                        End With
                        lDetalles.Add(detalle)
                    Next

                    With ficha
                        .LimiteRenglonesPorDoc = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_Factura
                        .Encabezado = encabezado
                        .Detalles = lDetalles
                    End With

                    If xautodoc_origen <> "" AndAlso (Not IsNothing(_DocumentoOrigen) And _DocumentoOrigen._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Pedido) Then
                        Dim xr1 = xventas.F_Pedido_Involucrado_GetData(xautodoc_origen)
                        If xr1.IsError = True Then
                            Throw New Exception(xr1.Mensaje)
                        End If

                        Dim xr2 = xventas.F_Pedido_ListaPrd_Involucrado(xautodoc_origen)
                        If xr2.IsError = True Then
                            Throw New Exception(xr2.Mensaje)
                        End If

                        If xr1.Entidad.estatus <> "0" Then
                            Throw New Exception("PROBLEMA ESTATUS DEL DOCUMENTO [ ACTIVO ], VERIFIQUE POR FAVOR")
                        End If

                        Dim docInvolucrado = New DataSistema.DocumentoInvolucrado
                        With docInvolucrado
                            .autoDoc = xautodoc_origen
                            .diasValidezDoc = xr1.Entidad.diasValidez
                            .fechaEmisionDoc = xr1.Entidad.fechaEmision
                            .numDoc = xr1.Entidad.documentoNro
                            .tipoDoc = xr1.Entidad.tipoDoc
                            .estatusBloqueoAlm = IIf(xr1.Entidad.estatusBloqueoDeposito = "1", True, False)
                            .listPrd = xr2.Lista.Select(Function(x)
                                                            Dim rg = New DataSistema.DocumentoInvolucrado_Producto(x.autoPrd, x.autoDep, x.cnt, x.nomPrd)
                                                            Return rg
                                                        End Function).ToList
                        End With

                        Dim DocGenerar = New FichaVentas.GenerarFacturas
                        With DocGenerar
                            .Lista = ficha.Documentos
                            .ListaPrdDeposito = ficha.ListaPrdDeposito
                            .DocInvloucrado = docInvolucrado
                        End With

                        Dim result = xventas.F_GenerarFactura(DocGenerar)
                        If result.IsError Then
                            Throw New Exception(result.Mensaje)
                        End If
                    Else
                        xventas.F_GrabarVenta(g_ConfiguracionSistema._Id_UnicoDelEquipo, xventa_encabezado, xventa_detalle, xlistapago, xcond, ximpresora)
                    End If
                End If
                RaiseEvent DocumentoProcesado()
                Return True
            Else
                Throw New Exception("Error... Al Parecer Otro Usuario Ya Dispuso De Esta Ficha")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Function UtilidadBaseCosto(ByVal xcosto As Decimal, ByVal xmargen As Decimal) As Decimal
        If xcosto > 0 Then
            Dim x As Decimal = 0
            x = (xmargen / xcosto) * 100
            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
            Return x
        Else
            Return 100
        End If
    End Function

    Function UtilidadBasePrecioVenta(ByVal xpventa As Decimal, ByVal xmargen As Decimal) As Decimal
        If xpventa > 0 Then
            Dim x As Decimal = 0
            x = (xmargen / xpventa) * 100
            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
            Return x
        Else
            Return -100
        End If
    End Function

    Function F_VerificarClaveInstalacion(ByVal xvalidar As String, ByVal xrif_verificar As String) As Boolean
        Try
            Dim xrif As String = xrif_verificar
            xrif = xrif.Replace("-", "")

            Dim x1 As Integer = Asc(xrif(0))
            Dim x2 As Long = 0
            Long.TryParse(xrif.Substring(1), x2)
            Dim x3 As Long = x1 + x2
            Dim xr As String = ""
            xr = String.Format("{0:X}", x3)

            Dim xg As String = xvalidar
            Dim m As Integer = 0
            Dim z As Integer = 0
            Dim xclave As String = ""
            For Each s As String In xg
                m += 1
                If (m Mod 4) = 0 Then
                    If z <= xr.Length - 1 Then
                        xclave += s
                        z += 1
                    End If
                End If
            Next

            If xclave = xr Then
                Return True
            Else
                Throw New Exception("ERROR CLAVE INCORRECTA, VERIFIQUE POR FAVOR")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public ReadOnly Property _ActivarDiasValidez() As Boolean Implements IProcesarDocumento._ActivarDiasValidez
        Get
            Return False
        End Get
    End Property

    Public Function DsctoFormaPago(ByRef xtotales As TotalesDoc) As Boolean Implements IProcesarDocumento.DsctoFormaPago
        Dim xr As Boolean = True

        If xtotales._DocChimbo = True Then
        Else
            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = TipoImpresora.Fiscal Then
                If g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Estatus = False Then
                    xr = False
                    Throw New Exception("DISCULPE, PERO EN ESTE EQUIPO NO PUEDES GENERAR LA FACTURA. DEBERAS DEJARLA PENDIENTE Y PROCESARLA EN OTRO EQUIPO")
                End If
            End If
        End If

        Dim xretorna As Boolean = False
        If xr = True Then
            Dim xficha As New Dscto_FormaPago(xtotales, xtotales._HabilitarMediosPagos, xtotales._HabilitarMediosPagos)
            With xficha
                .ShowDialog()
                xretorna = ._EstatusSalida
            End With
        End If

        Return xretorna
    End Function

    Public ReadOnly Property _ActivarNumeroOrdenCompra() As Boolean Implements IProcesarDocumento._ActivarNumeroOrdenCompra
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property _ActivarNumeroPedido() As Boolean Implements IProcesarDocumento._ActivarNumeroPedido
        Get
            If _DocumentoOrigen IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Sub ImprimirFacturaChimba(ByVal xauto As String)
        Try
            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._OTROS_MODO_IMPRESION = TipoImpresora.Texto Then
                Dim xfactura As LibImprimir.LibImprimir
                xfactura = New LibImprimir.LibImprimir(xauto, _MiCadenaConexion)
                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTextoNotas, My.Application.Info.DirectoryPath + "\FORMATOS\OTRA.XML")
            Else
                VisualizarDoc_Ventas(xauto)
            End If
        Catch ex As Exception
            _Form.Focus()
            _Form.Select()
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ImprimirFactura(ByVal xauto As String)
        Try
            Dim xfactura As LibImprimir.LibImprimir
            xfactura = New LibImprimir.LibImprimir(xauto, _MiCadenaConexion)
            xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTexto, My.Application.Info.DirectoryPath + "\FORMATOS\FACTURA.XML")
        Catch ex As Exception
            _Form.Focus()
            _Form.Select()
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Public ReadOnly Property _TipoDocumento() As String Implements IProcesarDocumento._TipoDocumento
        Get
            Return "1"
        End Get
    End Property

    Public Property _DocumentoOrigen() As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro Implements IProcesarDocumento._DocumentoOrigen
        Get
            Return xdoc_origen
        End Get
        Set(ByVal value As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro)
            xdoc_origen = value
        End Set
    End Property

End Class

Public Class ProcesarDocumentoPresupuesto
    Implements IProcesarDocumento
    Public Event DocumentoProcesado() Implements IProcesarDocumento.DocumentoProcesado

    WithEvents _form As Form

    Public Function ProcesarDoc(ByVal xdataventa As IProcesarDocumento.DatosVenta, ByVal xform As Object) As Boolean Implements IProcesarDocumento.ProcesarDoc
        Try
            Dim xventa_encabezado As New FichaVentas.V_Ventas.AgregarVenta
            Dim xventa_detalle As New List(Of FichaVentas.V_VentasDetalle.AgregarDetalleVenta)
            Dim xventas As New FichaVentas
            Dim xtabla As New DataTable
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@autousuario", g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario)
            _form = CType(xform, System.Windows.Forms.Form)

            g_MiData.F_GetData("select * from temporalventa where idunico=@idunico and tipodocumento='3' and autousuario=@autousuario", xtabla, xp1, xp2)

            With xventa_encabezado
                ._FichaCliente = xdataventa._Cliente
                ._FichaVendedor = xdataventa._Vendedor
                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._CantidadRenglones = xdataventa._TotalRenglones
                ._CodigoSucursal = g_MiData.f_FichaGlobal.f_Negocio.RegistroDato.c_CodigoSucursal.c_Texto
                ._CondicionPago = xdataventa._CondicionPago
                ._DiasCreditoOtorgado = xdataventa._DiasCredito
                ._DirDespacho = xdataventa._DirDespacho
                ._EstacionEquipoProceso = g_EquipoEstacion.p_EstacionNombre
                ._FactorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                ._FechaOrdenCompra = xdataventa._FechaOrdenCompra
                ._MontoBase_1 = xdataventa._MontoBase_1
                ._MontoBase_2 = xdataventa._MontoBase_2
                ._MontoBase_3 = xdataventa._MontoBase_3
                ._MontoExento = xdataventa._MontoExento
                ._MontoSaldoPendiente = 0
                ._MontoSubtotal = xdataventa._MontoSubTotal
                ._NotasDocumento = xdataventa._NotasDetalle
                ._NumeroPedido = xdataventa._NumeroPedido
                ._OrdenCompraNumero = xdataventa._NumeroOrdenCompra
                ._SerieFiscalAsignada = ""
                ._TasaCargos = xdataventa._TasaCargo
                ._TasaDescuento_1 = xdataventa._TasaDescuento_1
                ._TasaDescuento_2 = xdataventa._TasaDescuento_2
                ._TasaIva_1 = xdataventa._TasaIva_1
                ._TasaIva_2 = xdataventa._TasaIva_2
                ._TasaIva_3 = xdataventa._TasaIva_3
                ._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Presupuesto
                ._DiasValidezDocumento = xdataventa._DiasValidezDocumento
                ._DescuentoPorProntoPago = 0
            End With

            For Each xrow As DataRow In xtabla.Rows
                Dim xreg As New FichaVentas.V_TemporalVenta.c_Registro
                Dim xdetalle As New FichaVentas.V_VentasDetalle.AgregarDetalleVenta
                Dim xprd As New FichaProducto.Prd_Producto
                Dim xdeposito As New FichaGlobal.c_Depositos

                xreg.CargarRegistro(xrow)
                xprd.F_BuscarProducto(xreg._AutoProducto)
                xdeposito.F_BuscarDeposito(xreg._AutoDeposito)

                With xdetalle
                    ._AutoDepartamento = xprd.RegistroDato._AutoDepartamento
                    ._AutoGrupo = xprd.RegistroDato._AutoGrupo
                    ._AutoProducto = xreg._AutoProducto
                    ._AutoSubGrupo = xprd.RegistroDato._AutoSubGrupo
                    ._CantidadDespachada = xreg._CantidadDespachar
                    ._CategoriaProducto = xprd.RegistroDato._CategoriaDelProducto
                    ._ContenidoEmpaque = xreg._ContenidoEmpaque
                    ._CodigoProducto = xreg._CodigoProducto
                    'PRODUCTO SE FACTURA CON COSTO ACTUALIZADO AL DIA
                    ._CostoInventario = xprd.RegistroDato._CostoCompra._Base_Inv
                    ._CostoVenta = Decimal.Round(xprd.RegistroDato._CostoCompra._Base_Inv * xreg._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                    ._DescuentoTasa_1 = xreg._Descuento
                    ._DetalleNotas = xreg._ItemNotas
                    ._DiasGarantia = xprd.RegistroDato._DiasDeGarantia
                    ._EstatusGarantia = xprd.RegistroDato._EstatusGarantia
                    ._EstatusSerial = xprd.RegistroDato._EstatusSerial
                    ._NombreEmpaque = xreg._NombreEmpaque
                    ._NombreProducto = xreg._NombreProducto
                    ._NumeroDecimales = xreg._NumeroDecimalesMedida
                    ._PrecioNeto = xreg._PrecioNeto
                    ._PrecioSugerido = xreg._PSugerido
                    ._ReferenciaEmpaque = xreg._ReferenciaEmpaque
                    ._TasaIva = xreg._TasaIva
                    ._TipoTasaIva = xreg._TipoTasa
                    ._AutoDeposito = xdeposito.RegistroDato._Automatico
                    ._NombreDeposito = xdeposito.RegistroDato._Nombre
                    ._CodigoDeposito = xdeposito.RegistroDato._Codigo
                    ._DepositoBloqueado = xreg._BloquearExistencia
                    ._AutoMedidaEmpaque = xreg._AutoMedida
                    ._TipoCalculoUtilidad = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad
                    ._EsPesado = xreg._EsPesado
                    ._ForzarMedida = xreg._ForzarMedida
                    ._DescripcionCortaProducto = xprd.RegistroDato._DescripcionResumenDelProducto
                End With
                xventa_detalle.Add(xdetalle)
            Next

            If xtabla.Rows.Count > 0 Then
                Dim xcond As New FichaVentas.CondicionesParaVenta _
                     With {._Permitir_PrecioCero = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Precio_En_Cero, _
                           ._Permitir_PrecioMenorCosto = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Por_Debajo_Costo, _
                           ._Permitir_RupturaPorExistencia = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Ruptura_Por_Existencia}

                AddHandler xventas.DocumentoProcesado, AddressOf ImprimirDoc
                xventas.F_GrabarPresupuesto(g_ConfiguracionSistema._Id_UnicoDelEquipo, xventa_encabezado, xventa_detalle, xcond)
                RaiseEvent DocumentoProcesado()
                Return True
            Else
                Throw New Exception("Error... Al Parecer Otro Usuario Ya Dispuso De Esta Ficha")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub ImprimirDoc(ByVal xauto As String)
        Try
            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PRESUPUESTO_MODO_IMPRESION = TipoImpresora.Grafico Then
                VisualizarDoc_Ventas(xauto)
            ElseIf g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PRESUPUESTO_MODO_IMPRESION = TipoImpresora.Texto Then
                Dim xfactura As LibImprimir.LibImprimir
                xfactura = New LibImprimir.LibImprimir(xauto, _MiCadenaConexion)
                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTexto, My.Application.Info.DirectoryPath + "\FORMATOS\PRESUP.XML")
            End If
        Catch ex As Exception
            _form.Focus()
            _form.Select()
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Public Function DsctoFormaPago(ByRef xtotales As TotalesDoc) As Boolean Implements IProcesarDocumento.DsctoFormaPago
        Dim xretorna As Boolean = False
        Dim xficha As New Dscto_FormaPago(xtotales, False)
        With xficha
            .ShowDialog()
            xretorna = ._EstatusSalida
        End With

        Return xretorna
    End Function

    Public ReadOnly Property _ActivarDiasValidez() As Boolean Implements IProcesarDocumento._ActivarDiasValidez
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property _ActivarNumeroOrdenCompra() As Boolean Implements IProcesarDocumento._ActivarNumeroOrdenCompra
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property _ActivarNumeroPedido() As Boolean Implements IProcesarDocumento._ActivarNumeroPedido
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property _TipoDocumento() As String Implements IProcesarDocumento._TipoDocumento
        Get
            Return "3"
        End Get
    End Property

    Public Property _DocumentoOrigen() As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro Implements IProcesarDocumento._DocumentoOrigen
        Get
            Return Nothing
        End Get
        Set(ByVal value As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro)
        End Set
    End Property
End Class

Public Class ProcesarDocumentoNotaEntrega
    Implements IProcesarDocumento
    Public Event DocumentoProcesado() Implements IProcesarDocumento.DocumentoProcesado

    Dim xdoc_origen As FichaVentas.V_Ventas.c_Registro
    WithEvents _form As System.Windows.Forms.Form

    Public ReadOnly Property _ActivarDiasValidez() As Boolean Implements IProcesarDocumento._ActivarDiasValidez
        Get
            Return True
        End Get
    End Property

    Public Function ProcesarDoc(ByVal xdataventa As IProcesarDocumento.DatosVenta, ByVal xform As Object) As Boolean Implements IProcesarDocumento.ProcesarDoc
        Try
            Dim xventa_encabezado As New FichaVentas.V_Ventas.AgregarVenta
            Dim xventa_detalle As New List(Of FichaVentas.V_VentasDetalle.AgregarDetalleVenta)
            Dim xventas As New FichaVentas
            Dim xtabla As New DataTable
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@autousuario", g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario)
            _form = CType(xform, System.Windows.Forms.Form)

            g_MiData.F_GetData("select * from temporalventa where idunico=@idunico and tipodocumento='2' and autousuario=@autousuario", xtabla, xp1, xp2)

            Dim xautodoc_origen As String = ""
            If (_DocumentoOrigen IsNot Nothing) Then
                xautodoc_origen = _DocumentoOrigen._AutoDocumento
            End If

            With xventa_encabezado
                ._FichaCliente = xdataventa._Cliente
                ._FichaVendedor = xdataventa._Vendedor
                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._CantidadRenglones = xdataventa._TotalRenglones
                ._CodigoSucursal = g_MiData.f_FichaGlobal.f_Negocio.RegistroDato.c_CodigoSucursal.c_Texto
                ._CondicionPago = xdataventa._CondicionPago
                ._DiasCreditoOtorgado = xdataventa._DiasCredito
                ._DirDespacho = xdataventa._DirDespacho
                ._EstacionEquipoProceso = g_EquipoEstacion.p_EstacionNombre
                ._FactorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                ._FechaOrdenCompra = xdataventa._FechaOrdenCompra
                ._MontoBase_1 = xdataventa._MontoBase_1
                ._MontoBase_2 = xdataventa._MontoBase_2
                ._MontoBase_3 = xdataventa._MontoBase_3
                ._MontoExento = xdataventa._MontoExento
                ._MontoSaldoPendiente = 0
                ._MontoSubtotal = xdataventa._MontoSubTotal
                ._NotasDocumento = xdataventa._NotasDetalle
                ._NumeroPedido = xdataventa._NumeroPedido
                ._OrdenCompraNumero = xdataventa._NumeroOrdenCompra
                ._SerieFiscalAsignada = g_ConfiguracionSistema._SerieNotaEntegra
                ._TasaCargos = xdataventa._TasaCargo
                ._TasaDescuento_1 = xdataventa._TasaDescuento_1
                ._TasaDescuento_2 = xdataventa._TasaDescuento_2
                ._TasaIva_1 = xdataventa._TasaIva_1
                ._TasaIva_2 = xdataventa._TasaIva_2
                ._TasaIva_3 = xdataventa._TasaIva_3
                ._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.NotaEntrega
                ._DocumentoOrigen_PresupuestoPedidoNotaEntrega = xautodoc_origen
                ._DiasValidezDocumento = xdataventa._DiasValidezDocumento
                ._DescuentoPorProntoPago = 0
            End With

            For Each xrow As DataRow In xtabla.Rows
                Dim xreg As New FichaVentas.V_TemporalVenta.c_Registro
                Dim xdetalle As New FichaVentas.V_VentasDetalle.AgregarDetalleVenta
                Dim xprd As New FichaProducto.Prd_Producto
                Dim xdeposito As New FichaGlobal.c_Depositos

                xreg.CargarRegistro(xrow)
                xprd.F_BuscarProducto(xreg._AutoProducto)
                xdeposito.F_BuscarDeposito(xreg._AutoDeposito)

                With xdetalle
                    ._AutoDepartamento = xprd.RegistroDato._AutoDepartamento
                    ._AutoGrupo = xprd.RegistroDato._AutoGrupo
                    ._AutoProducto = xreg._AutoProducto
                    ._AutoSubGrupo = xprd.RegistroDato._AutoSubGrupo
                    ._CantidadDespachada = xreg._CantidadDespachar
                    ._CategoriaProducto = xprd.RegistroDato._CategoriaDelProducto
                    ._ContenidoEmpaque = xreg._ContenidoEmpaque
                    ._CodigoProducto = xreg._CodigoProducto
                    'PRODUCTO SE FACTURA CON COSTO ACTUALIZADO AL DIA
                    ._CostoInventario = xprd.RegistroDato._CostoCompra._Base_Inv
                    ._CostoVenta = Decimal.Round(xprd.RegistroDato._CostoCompra._Base_Inv * xreg._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                    ._DescuentoTasa_1 = xreg._Descuento
                    ._DetalleNotas = xreg._ItemNotas
                    ._DiasGarantia = xprd.RegistroDato._DiasDeGarantia
                    ._EstatusGarantia = xprd.RegistroDato._EstatusGarantia
                    ._EstatusSerial = xprd.RegistroDato._EstatusSerial
                    ._NombreEmpaque = xreg._NombreEmpaque
                    ._NombreProducto = xreg._NombreProducto
                    ._NumeroDecimales = xreg._NumeroDecimalesMedida
                    ._PrecioNeto = xreg._PrecioNeto
                    ._PrecioSugerido = xreg._PSugerido
                    ._ReferenciaEmpaque = xreg._ReferenciaEmpaque
                    ._TasaIva = xreg._TasaIva
                    ._TipoTasaIva = xreg._TipoTasa
                    ._AutoDeposito = xdeposito.RegistroDato._Automatico
                    ._NombreDeposito = xdeposito.RegistroDato._Nombre
                    ._CodigoDeposito = xdeposito.RegistroDato._Codigo
                    ._DepositoBloqueado = xreg._BloquearExistencia
                    ._AutoMedidaEmpaque = xreg._AutoMedida
                    ._TipoCalculoUtilidad = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad
                    ._EsPesado = xreg._EsPesado
                    ._ForzarMedida = xreg._ForzarMedida
                    ._DescripcionCortaProducto = xprd.RegistroDato._DescripcionResumenDelProducto
                End With
                xventa_detalle.Add(xdetalle)
            Next

            If xtabla.Rows.Count > 0 Then


                Dim zFiscal = 0
                Dim xbase = (xdataventa._MontoBase_1 + xdataventa._MontoBase_2 + xdataventa._MontoBase_3)
                Dim ximp1 = (xdataventa._MontoBase_1 * xdataventa._TasaIva_1 / 100)
                Dim ximp2 = (xdataventa._MontoBase_2 * xdataventa._TasaIva_1 / 100)
                Dim ximp3 = (xdataventa._MontoBase_3 * xdataventa._TasaIva_1 / 100)
                Dim ximp = ximp1 + ximp2 + ximp3
                Dim xtot = xdataventa._MontoExento + xbase + ximp
                Dim saldoP = IIf(xdataventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado, 0, xtot)

                Dim tserieFiscal = xventas.F_SerieFiscal_GetBySerie(g_ConfiguracionSistema._SerieNotaEntegra)
                If tserieFiscal.IsError Then
                    Throw New Exception(tserieFiscal.Mensaje)
                End If

                Dim tdeposito = xventas.F_Deposito_GetById(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoInventarioVentas)
                If tdeposito.IsError Then
                    Throw New Exception(tdeposito.Mensaje)
                End If

                Dim tconceptoInv = xventas.F_ConceptoInv_GetById("0000000006")
                If tconceptoInv.IsError Then
                    Throw New Exception(tconceptoInv.Mensaje)
                End If

                Dim numpedido = ""
                If Not IsNothing(_DocumentoOrigen) Then
                    numpedido = _DocumentoOrigen._Documento
                End If

                Dim ficha As GenFactura = New GenFactura
                Dim encabezado As GenEncabezado = New GenEncabezado
                With encabezado
                    .serieAuto = tserieFiscal.Entidad.auto
                    .bloquearAlmacen = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Ruptura_Por_Existencia, "1", "0")
                    .cliAuto = xdataventa._Cliente.r_Automatico
                    .cliCiRif = xdataventa._Cliente.r_CiRif
                    .cliCodigo = xdataventa._Cliente.r_CodigoCliente
                    .cliDirDespacho = xdataventa._DirDespacho
                    .cliDirFiscal = xdataventa._Cliente.r_DirFiscal
                    .cliNombre = xdataventa._Cliente.r_NombreRazonSocial
                    .cliTelefono = xdataventa._Cliente.r_Telefono_1
                    .condPago = IIf(xdataventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado, "CONTADO", "CREDITO")
                    .condPagoIsContado = xdataventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado
                    .control = ""
                    .diasCredito = xdataventa._DiasCredito
                    .estacionEquipo = g_EquipoEstacion.p_EstacionNombre
                    .factorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                    .fechaPedido = Now.Date
                    .montoBase = xbase
                    .montoBase1 = xdataventa._MontoBase_1
                    .montoBase2 = xdataventa._MontoBase_2
                    .montoBase3 = xdataventa._MontoBase_3
                    .montoCargo = xdataventa.CargoGeneralMonto
                    .montoDescuento = xdataventa.DsctoGeneralMonto
                    .montoDivisa = xtot / g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                    .montoExento = xdataventa._MontoExento
                    .montoImpuesto = ximp
                    .montoImpuesto1 = ximp1
                    .montoImpuesto2 = ximp2
                    .montoImpuesto3 = ximp3
                    .montoTotal = xtot
                    .Notas = xdataventa._NotasDetalle
                    .numPedido = numpedido
                    .ordeCompra = xdataventa._NumeroOrdenCompra
                    .porcCargo = xdataventa._TasaCargo
                    .porcDescuento = xdataventa._TasaDescuento_1
                    .renglones = xtabla.Rows.Count
                    .saldoPend = saldoP
                    .serieNombre = tserieFiscal.Entidad.nombre
                    .serieSerial = tserieFiscal.Entidad.numeroRegistroFiscal
                    .subTotal = (xdataventa._MontoSubTotal + xdataventa.DsctoGeneralMonto - xdataventa.CargoGeneralMonto)
                    .tasa1 = xdataventa._TasaIva_1
                    .tasa2 = xdataventa._TasaIva_2
                    .tasa3 = xdataventa._TasaIva_3
                    .usuAuto = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario
                    .usuCodigo = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._CodigoUsuario
                    .usuNombre = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
                    .vendAuto = xdataventa._Vendedor.r_Automatico
                    .vendCodigo = xdataventa._Vendedor.r_CodigoVendedor
                    .vendNombre = xdataventa._Vendedor.r_NombreVendedor
                    .zFiscal = zFiscal
                    .depAuto = tdeposito.Entidad.auto
                    .depCodigo = tdeposito.Entidad.codigo
                    .depNombre = tdeposito.Entidad.nombre
                    .conceptoAuto = tconceptoInv.Entidad.auto
                    .conceptoCodigo = tconceptoInv.Entidad.codigo
                    .conceptoNombre = tconceptoInv.Entidad.nombre
                    .cobradorAuto = xdataventa._Cliente.r_AutoCobrador
                    .cobradorCodigo = ""
                    .cobradorNombre = xdataventa._Cliente.r_NombreCobrador
                End With

                Dim lDetalles As List(Of GenDetalle) = New List(Of GenDetalle)
                For Each xrow As DataRow In xtabla.Rows
                    Dim xreg As New FichaVentas.V_TemporalVenta.c_Registro
                    Dim xprd As New FichaProducto.Prd_Producto

                    xreg.CargarRegistro(xrow)
                    xprd.F_BuscarProducto(xreg._AutoProducto)

                    Dim xpItem = xreg._PrecioNeto - (xreg._PrecioNeto * xreg._Descuento / 100)
                    Dim xtneto = xpItem * xreg._CantidadDespachar
                    Dim ximpuesto = xtneto * xreg._TasaIva / 100
                    Dim xpFinal As Decimal = xpItem
                    xpFinal = Decimal.Round(xpFinal - (xpFinal * xdataventa._TasaDescuento_1 / 100), 2, MidpointRounding.AwayFromZero)
                    xpFinal = Decimal.Round(xpFinal + (xpFinal * xdataventa._TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
                    Dim xpFinalInv = Decimal.Round(xpFinal / xreg._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                    Dim tVenta = xpFinal * xreg._CantidadDespachar
                    Dim tCosto = (xprd.RegistroDato._CostoCompra._Base_Inv * xreg._ContenidoEmpaque) * xreg._CantidadDespachar
                    Dim tMargen = tVenta - tCosto
                    Dim tTasaMargen = 0D
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        tTasaMargen = UtilidadBaseCosto(tCosto, tMargen)
                    Else
                        tTasaMargen = UtilidadBasePrecioVenta(tVenta, tMargen)
                    End If

                    Dim detalle As GenDetalle = New GenDetalle
                    With detalle
                        .cantidad = xreg._CantidadDespachar
                        .cantUnd = xreg._CantidadDespachar * xreg._ContenidoEmpaque
                        .categoria = xprd.RegistroDato._CategoriaDelProducto
                        .codigoTasaIva = xreg._TipoTasa
                        .confTipoCalcUtilidad = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto, "C", "V")
                        .contEmpaque = xreg._ContenidoEmpaque
                        .costo = Decimal.Round(xprd.RegistroDato._CostoCompra._Base_Inv * xreg._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                        .costoUnd = xprd.RegistroDato._CostoCompra._Base_Inv
                        .departAuto = xprd.RegistroDato._AutoDepartamento
                        .descMonto_1 = xreg._DsctoMonto
                        .descMonto_2 = 0D
                        .descMonto_3 = 0D
                        .descPorc_1 = xreg._Descuento
                        .descPorc_2 = 0D
                        .descPorc_3 = 0D
                        .detalle = xreg._ItemNotas
                        .empaque = xreg._NombreEmpaque
                        .empaqueTipo = xreg._ReferenciaEmpaque
                        .grupoAuto = xprd.RegistroDato._AutoGrupo
                        .impuesto = Decimal.Round(ximpuesto, 2, MidpointRounding.AwayFromZero)
                        .medidaAuto = xreg._AutoMedida
                        .medidaDecimales = xreg._NumeroDecimalesMedida
                        .medidaForzar = IIf(xreg._ForzarMedida, "1", "0")
                        .prdAuto = xprd.RegistroDato._AutoProducto
                        .prdCodigo = xprd.RegistroDato._CodigoProducto
                        .prdDescripcion = xprd.RegistroDato._DescripcionDetallaDelProducto
                        .prdNombre = xprd.RegistroDato._DescripcionResumenDelProducto
                        .precioFinal = xpFinal
                        .precioInv = xpFinalInv
                        .precioItem = xpItem
                        .precioNeto = xreg._PrecioNeto
                        .psv = xreg._PSugerido
                        .subGrupAuto = xprd.RegistroDato._AutoSubGrupo
                        .tasaIva = xreg._TasaIva
                        .total = Decimal.Round(xtneto + ximpuesto, 2, MidpointRounding.AwayFromZero)
                        .totalNeto = Decimal.Round(xtneto, 2, MidpointRounding.AwayFromZero)
                        .medidaNombre = xreg._NombreEmpaque
                        .utilidad = tMargen
                        .utilidadPorc = tTasaMargen
                        .idItemTemp = xreg._AutoItem
                        .provDocOrigen = IIf(xreg._AutoDocumentoOrigen <> "", True, False)
                    End With
                    lDetalles.Add(detalle)
                Next

                With ficha
                    .LimiteRenglonesPorDoc = 0
                    .Encabezado = encabezado
                    .Detalles = lDetalles
                End With

                If xautodoc_origen <> "" AndAlso (Not IsNothing(_DocumentoOrigen) And _DocumentoOrigen._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Pedido) Then
                    Dim xr1 = xventas.F_Pedido_Involucrado_GetData(xautodoc_origen)
                    If xr1.IsError = True Then
                        Throw New Exception(xr1.Mensaje)
                    End If

                    Dim xr2 = xventas.F_Pedido_ListaPrd_Involucrado(xautodoc_origen)
                    If xr2.IsError = True Then
                        Throw New Exception(xr2.Mensaje)
                    End If

                    If xr1.Entidad.estatus <> "0" Then
                        Throw New Exception("PROBLEMA ESTATUS DEL DOCUMENTO [ ACTIVO ], VERIFIQUE POR FAVOR")
                    End If

                    Dim docInvolucrado = New DataSistema.DocumentoInvolucrado
                    With docInvolucrado
                        .autoDoc = xautodoc_origen
                        .diasValidezDoc = xr1.Entidad.diasValidez
                        .fechaEmisionDoc = xr1.Entidad.fechaEmision
                        .numDoc = xr1.Entidad.documentoNro
                        .tipoDoc = xr1.Entidad.tipoDoc
                        .estatusBloqueoAlm = IIf(xr1.Entidad.estatusBloqueoDeposito = "1", True, False)
                        .listPrd = xr2.Lista.Select(Function(x)
                                                        Dim rg = New DataSistema.DocumentoInvolucrado_Producto(x.autoPrd, x.autoDep, x.cnt, x.nomPrd)
                                                        Return rg
                                                    End Function).ToList
                    End With

                    Dim DocGenerar = New FichaVentas.GenerarFacturas
                    With DocGenerar
                        .Lista = ficha.Documentos
                        .ListaPrdDeposito = ficha.ListaPrdDeposito
                        .DocInvloucrado = docInvolucrado
                    End With

                    Dim result = xventas.F_GenerarNotaEntrega(DocGenerar)
                    If result.IsError Then
                        Throw New Exception(result.Mensaje)
                    End If
                Else
                    Dim xcond As New FichaVentas.CondicionesParaVenta _
                         With {._Permitir_PrecioCero = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Precio_En_Cero, _
                               ._Permitir_PrecioMenorCosto = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Por_Debajo_Costo, _
                               ._Permitir_RupturaPorExistencia = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Ruptura_Por_Existencia}

                    AddHandler xventas.DocumentoProcesado, AddressOf ImprimirDoc
                    xventas.F_GrabarNotaEntrega(g_ConfiguracionSistema._Id_UnicoDelEquipo, xventa_encabezado, xventa_detalle, xcond)
                End If

                RaiseEvent DocumentoProcesado()
                Return True
            Else
                Throw New Exception("Error... Al Parecer Otro Usuario Ya Dispuso De Esta Ficha")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Function UtilidadBaseCosto(ByVal xcosto As Decimal, ByVal xmargen As Decimal) As Decimal
        If xcosto > 0 Then
            Dim x As Decimal = 0
            x = (xmargen / xcosto) * 100
            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
            Return x
        Else
            Return 100
        End If
    End Function

    Function UtilidadBasePrecioVenta(ByVal xpventa As Decimal, ByVal xmargen As Decimal) As Decimal
        If xpventa > 0 Then
            Dim x As Decimal = 0
            x = (xmargen / xpventa) * 100
            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
            Return x
        Else
            Return -100
        End If
    End Function

    Sub ImprimirDoc(ByVal xauto As String)
        Try
            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._NOTAENTREGA_MODO_IMPRESION = TipoImpresora.Grafico Then
                VisualizarDoc_Ventas(xauto)
            ElseIf g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._NOTAENTREGA_MODO_IMPRESION = TipoImpresora.Texto Then
                Dim xfactura As LibImprimir.LibImprimir
                xfactura = New LibImprimir.LibImprimir(xauto, _MiCadenaConexion)
                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTexto, My.Application.Info.DirectoryPath + "\FORMATOS\NOTAE.XML")
            End If
        Catch ex As Exception
            _form.Focus()
            _form.Select()
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Public Function DsctoFormaPago(ByRef xtotales As TotalesDoc) As Boolean Implements IProcesarDocumento.DsctoFormaPago
        Dim xretorna As Boolean = False
        Dim xficha As New Dscto_FormaPago(xtotales, False)
        With xficha
            .ShowDialog()
            xretorna = ._EstatusSalida
        End With
        Return xretorna
    End Function

    Public ReadOnly Property _ActivarNumeroOrdenCompra() As Boolean Implements IProcesarDocumento._ActivarNumeroOrdenCompra
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property _ActivarNumeroPedido() As Boolean Implements IProcesarDocumento._ActivarNumeroPedido
        Get
            If _DocumentoOrigen IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        End Get
        'Get
        '    Return False
        'End Get
    End Property

    Public ReadOnly Property _TipoDocumento() As String Implements IProcesarDocumento._TipoDocumento
        Get
            Return "2"
        End Get
    End Property

    Public Property _DocumentoOrigen() As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro Implements IProcesarDocumento._DocumentoOrigen
        Get
            Return xdoc_origen
        End Get
        Set(ByVal value As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro)
            xdoc_origen = value
        End Set
        'Get
        '    Return Nothing
        'End Get
        'Set(ByVal value As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro)
        'End Set
    End Property
End Class

Public Class ProcesarDocumentoPedido
    Implements IProcesarDocumento
    Public Event DocumentoProcesado() Implements IProcesarDocumento.DocumentoProcesado

    WithEvents _form As System.Windows.Forms.Form
    Dim xdoc_origen As FichaVentas.V_Ventas.c_Registro
    Dim estatusDivisa As Boolean = False


    Public ReadOnly Property _ActivarDiasValidez() As Boolean Implements IProcesarDocumento._ActivarDiasValidez
        Get
            Return True
        End Get
    End Property

    Public Function ProcesarDoc(ByVal xdataventa As IProcesarDocumento.DatosVenta, ByVal xform As Object) As Boolean Implements IProcesarDocumento.ProcesarDoc
        Try
            Dim xventa_encabezado As New FichaVentas.V_Ventas.AgregarVenta
            Dim xventa_detalle As New List(Of FichaVentas.V_VentasDetalle.AgregarDetalleVenta)
            Dim xventas As New FichaVentas
            Dim xtabla As New DataTable
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@autousuario", g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario)
            _form = CType(xform, System.Windows.Forms.Form)

            Dim xautodoc_origen As String = ""
            If _DocumentoOrigen IsNot Nothing Then
                xautodoc_origen = _DocumentoOrigen._AutoDocumento
            End If

            g_MiData.F_GetData("select * from temporalventa where idunico=@idunico and tipodocumento='4' and autousuario=@autousuario", xtabla, xp1, xp2)

            With xventa_encabezado
                ._FichaCliente = xdataventa._Cliente
                ._FichaVendedor = xdataventa._Vendedor
                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._CantidadRenglones = xdataventa._TotalRenglones
                ._CodigoSucursal = g_MiData.f_FichaGlobal.f_Negocio.RegistroDato.c_CodigoSucursal.c_Texto
                ._CondicionPago = xdataventa._CondicionPago
                ._DiasCreditoOtorgado = xdataventa._DiasCredito
                ._DirDespacho = xdataventa._DirDespacho
                ._EstacionEquipoProceso = g_EquipoEstacion.p_EstacionNombre
                ._FactorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                ._FechaOrdenCompra = xdataventa._FechaOrdenCompra
                ._MontoBase_1 = xdataventa._MontoBase_1
                ._MontoBase_2 = xdataventa._MontoBase_2
                ._MontoBase_3 = xdataventa._MontoBase_3
                ._MontoExento = xdataventa._MontoExento
                ._MontoSaldoPendiente = 0
                ._MontoSubtotal = xdataventa._MontoSubTotal
                ._NotasDocumento = xdataventa._NotasDetalle
                ._NumeroPedido = xdataventa._NumeroPedido
                ._OrdenCompraNumero = xdataventa._NumeroOrdenCompra
                ._SerieFiscalAsignada = g_ConfiguracionSistema._SerieFactura
                ._TasaCargos = xdataventa._TasaCargo
                ._TasaDescuento_1 = xdataventa._TasaDescuento_1
                ._TasaDescuento_2 = xdataventa._TasaDescuento_2
                ._TasaIva_1 = xdataventa._TasaIva_1
                ._TasaIva_2 = xdataventa._TasaIva_2
                ._TasaIva_3 = xdataventa._TasaIva_3
                ._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Pedido
                ._DocumentoOrigen_PresupuestoPedidoNotaEntrega = xautodoc_origen
                ._DiasValidezDocumento = xdataventa._DiasValidezDocumento
                ._DescuentoPorProntoPago = 0
                ''
                ._FactorCambio = xdataventa.FactorCambio
                .estatusDivisa = estatusDivisa
            End With

            For Each xrow As DataRow In xtabla.Rows
                Dim xreg As New FichaVentas.V_TemporalVenta.c_Registro
                Dim xdetalle As New FichaVentas.V_VentasDetalle.AgregarDetalleVenta
                Dim xprd As New FichaProducto.Prd_Producto
                Dim xdeposito As New FichaGlobal.c_Depositos

                xreg.CargarRegistro(xrow)
                xprd.F_BuscarProducto(xreg._AutoProducto)
                xdeposito.F_BuscarDeposito(xreg._AutoDeposito)

                With xdetalle
                    ._AutoDepartamento = xprd.RegistroDato._AutoDepartamento
                    ._AutoGrupo = xprd.RegistroDato._AutoGrupo
                    ._AutoProducto = xreg._AutoProducto
                    ._AutoSubGrupo = xprd.RegistroDato._AutoSubGrupo
                    ._CantidadDespachada = xreg._CantidadDespachar
                    ._CategoriaProducto = xprd.RegistroDato._CategoriaDelProducto
                    ._ContenidoEmpaque = xreg._ContenidoEmpaque
                    ._CodigoProducto = xreg._CodigoProducto
                    'PRODUCTO SE FACTURA CON COSTO ACTUALIZADO AL DIA
                    ._CostoInventario = xprd.RegistroDato._CostoCompra._Base_Inv
                    ._CostoVenta = Decimal.Round(xprd.RegistroDato._CostoCompra._Base_Inv * xreg._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                    ._DescuentoTasa_1 = xreg._Descuento
                    ._DetalleNotas = xreg._ItemNotas
                    ._DiasGarantia = xprd.RegistroDato._DiasDeGarantia
                    ._EstatusGarantia = xprd.RegistroDato._EstatusGarantia
                    ._EstatusSerial = xprd.RegistroDato._EstatusSerial
                    ._NombreEmpaque = xreg._NombreEmpaque
                    ._NombreProducto = xreg._NombreProducto
                    ._NumeroDecimales = xreg._NumeroDecimalesMedida
                    ._PrecioNeto = xreg._PrecioNeto
                    ._PrecioSugerido = xreg._PSugerido
                    ._ReferenciaEmpaque = xreg._ReferenciaEmpaque
                    ._TasaIva = xreg._TasaIva
                    ._TipoTasaIva = xreg._TipoTasa
                    ._AutoDeposito = xdeposito.RegistroDato._Automatico
                    ._NombreDeposito = xdeposito.RegistroDato._Nombre
                    ._CodigoDeposito = xdeposito.RegistroDato._Codigo
                    ._DepositoBloqueado = xreg._BloquearExistencia
                    ._AutoMedidaEmpaque = xreg._AutoMedida
                    ._TipoCalculoUtilidad = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad
                    ._EsPesado = xreg._EsPesado
                    ._ForzarMedida = xreg._ForzarMedida
                    ._DescripcionCortaProducto = xprd.RegistroDato._DescripcionResumenDelProducto
                End With
                xventa_detalle.Add(xdetalle)
            Next

            Dim xlistapago As New List(Of FichaCtasCobrar.c_ModosPago.AgregarModoPago)
            For Each xregpago As DataRow In xdataventa._TablaPagos.Rows
                If xregpago.RowState <> DataRowState.Deleted Then
                    Dim xpago As New FichaCtasCobrar.c_ModosPago.AgregarModoPago
                    With xpago
                        ._AutoAgencia = ""
                        ._AutoTipoPago = xregpago("AutoTipoPago").ToString.Trim
                        ._CodigoTipoPago = xregpago("CodigoTipoPago").ToString.Trim
                        ._MontoImporte = xregpago("Monto").ToString.Trim
                        ._MontoRecibido = xregpago("Monto").ToString.Trim
                        ._NombreAgencia = xregpago("Agencia").ToString.Trim
                        ._NombreTipoPago = xregpago("TipoPago").ToString.Trim
                        ._Numero = xregpago("Planilla").ToString.Trim
                    End With
                    xlistapago.Add(xpago)
                End If
            Next

            If xtabla.Rows.Count > 0 Then
                If xdataventa._DocChimbo = True Then
                Else
                    'If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_Factura > 0 Then
                    '    If xtabla.Rows.Count <= g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_Factura Then
                    '    Else
                    '        Throw New Exception("ERROR ... NUMERO DE RENGLONES SUPERA EL LIMITE")
                    '    End If
                    'End If
                End If
                Dim xcond As New FichaVentas.CondicionesParaVenta _
                     With {._Permitir_PrecioCero = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Precio_En_Cero, _
                           ._Permitir_PrecioMenorCosto = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Por_Debajo_Costo, _
                           ._Permitir_RupturaPorExistencia = True}
                ' SIEMPRE SERA TRUE, PARA APARTAR LA MERCANCIA, AUNQUE NO EXISTA
                'g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Ruptura_Por_Existencia 

                AddHandler xventas.DocumentoProcesado, AddressOf ImprimirDoc
                xventas.F_GrabarPedido(g_ConfiguracionSistema._Id_UnicoDelEquipo, xventa_encabezado, xventa_detalle, xlistapago, xcond)
                RaiseEvent DocumentoProcesado()
                Return True
            Else
                Throw New Exception("Error... Al Parecer Otro Usuario Ya Dispuso De Esta Ficha")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub ImprimirDoc(ByVal xauto As String)
        Try
            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PEDIDO_MODO_IMPRESION = TipoImpresora.Grafico Then
                VisualizarDoc_Ventas(xauto)
            ElseIf g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PEDIDO_MODO_IMPRESION = TipoImpresora.Texto Then
                Dim xfactura As LibImprimir.LibImprimir
                xfactura = New LibImprimir.LibImprimir(xauto, _MiCadenaConexion)
                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTexto, My.Application.Info.DirectoryPath + "\FORMATOS\PEDIDO.XML")
            End If
        Catch ex As Exception
            _form.Focus()
            _form.Select()
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Public Function DsctoFormaPago(ByRef xtotales As TotalesDoc) As Boolean Implements IProcesarDocumento.DsctoFormaPago
        Dim xretorna As Boolean = False
        Dim xficha As New Dscto_FormaPago(xtotales, g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PermitirEntradaDeAnticipos_EnPedido, False)
        xficha.SetHabilitarSolicitudDivsa(True)
        With xficha
            .ShowDialog()
            xretorna = ._EstatusSalida
        End With
        estatusDivisa = xficha.EstatusDivisa

        Return xretorna
    End Function

    Public ReadOnly Property _ActivarNumeroOrdenCompra() As Boolean Implements IProcesarDocumento._ActivarNumeroOrdenCompra
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property _ActivarNumeroPedido() As Boolean Implements IProcesarDocumento._ActivarNumeroPedido
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property _TipoDocumento() As String Implements IProcesarDocumento._TipoDocumento
        Get
            Return "4"
        End Get
    End Property

    Public Property _DocumentoOrigen() As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro Implements IProcesarDocumento._DocumentoOrigen
        Get
            Return xdoc_origen
        End Get
        Set(ByVal value As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro)
            xdoc_origen = value
        End Set
    End Property
End Class