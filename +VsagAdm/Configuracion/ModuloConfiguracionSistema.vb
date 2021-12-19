Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class ModuloConfiguracionSistema
    Dim xtb_opciones As DataTable
    Dim xbing_opciones As BindingSource
    Dim xsql As String = "select nombre xnom, '' xact, '' xnew, codigo xcod, usuario xusu, * from opciones " & _
        "where ((codigo like ('CLIENTE%')) OR (codigo like ('VENTA%')) OR (codigo like ('INVENT%')) OR (codigo like ('COMPRA%')) " & _
        "OR (codigo like ('CXC%')) OR (codigo like ('VENDED%')) OR (codigo like ('COBRAD%')) " & _
        "OR (codigo like ('CXP%')) OR (codigo like ('PANAD%')) OR (codigo like ('GLOBAL%')) " & _
        "OR (codigo like ('FAST%')) OR (codigo like ('PARK%')) OR (codigo like ('REST%'))) and estatus='0' ORDER BY CODIGO"

    Dim xopciones As String() = {"Clientes", "Inventario", "Vendedores", "Cobradores", "Ventas", "Cuentas x Cobrar", "Compras", _
                                 "Cuentas x Pagar", "Global", "Comida Rapida - FastFood", "Estacionamiento - Parking", "Restaurant"}

    Const MCliente As String = "PERMITE GESTIONAR CUALQUIER CAMBIO / MOVIMIENTO DE UN CLIENTE REGISTRADO"
    Const MInvent As String = "PERMITE GESTIONAR CUALQUIER CAMBIO / MOVIMIENTO DE UN PRODCUTO REGISTRADO"
    Const MVenta As String = "PERMITE GESTIONAR EL CONTROL DE LAS OPERACIOES DE VENTA"
    Const MCxC As String = "PERMITE GESTIONAR EL CONTROL DE LAS OPERACIOES DE COBRANZA"
    Const MGlobal As String = "PERMITE GESTIONAR LAS DIRECTRICES FUNDAMENTALES PARA TODO EL SISTEMA"
    Const MVendedor As String = "PERMITE GESTIONAR EL CONTROL DE VENDEDORES / COMISONES"
    Const MCobrador As String = "PERMITE GESTIONAR EL CONTROL DE COBRADORES / COMISONES"
    Const MCompra As String = "PERMITE GESTIONAR EL CONTROL DE LAS OPERACIONES DE COMPRAS DE MERCANCIA"
    Const MCxP As String = "PERMITE GESTIONAR EL CONTROL DE LAS OPERACIONES DE PAGOS A PROVEEDORES"
    Const PANAD As String = "GESTIONA EL CONTROL DE LAS OPERACIONES DE CARGA DE PEDIDOS (PANADERIAS)"
    Const FASTFOOD As String = "GESTIONA EL CONTROL DE LAS OPERACIONES (POS) COMIDA RAPIDA - FASTFOOD "
    Const PARKING As String = "GESTIONA EL CONTROL DE LAS OPERACIONES (POS) ESTACIONAMINETO - PARKING "
    Const RESTAURANT As String = "GESTIONA EL CONTROL DE LAS OPERACIONES (POS) RESTAURANT "

    Private Sub ModuloConfiguracionSistema_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ConfiguracionSistema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ModuloConfiguracionSistema_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            CargarValoresOpciones()
            AddHandler xbing_opciones.PositionChanged, AddressOf ActualizarData
            ActualizaData()

            With Me.MisGrid1
                .Columns.Add("col0", "Detalle De La Funcion")
                .Columns.Add("col1", "Valor Actual")
                .Columns(1).Width = 180
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbing_opciones
                .Columns(0).DataPropertyName = "xnom"
                .Columns(1).DataPropertyName = "xact"
                .Ocultar(3)
            End With

            Me.E_TEXTO.Text = ""
            With Me.MCB_1
                .DataSource = xopciones
                .SelectedIndex = 0
                AddHandler .SelectedIndexChanged, AddressOf MostrarDetalleModulo
            End With
            MostrarDetalle(Me.MCB_1.SelectedIndex)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub MostrarDetalleModulo(ByVal sender As Object, ByVal e As System.EventArgs)
        MostrarDetalle(Me.MCB_1.SelectedIndex)
    End Sub

    Sub MostrarDetalle(ByVal xopc As Integer)
        Select Case xopc
            Case 0
                Me.E_TEXTO.Text = MCliente
                xbing_opciones.Filter = "xcod LIKE 'CLIEN%'"
            Case 1
                Me.E_TEXTO.Text = MInvent
                xbing_opciones.Filter = "xcod LIKE 'INVENT%'"
            Case 2
                Me.E_TEXTO.Text = MVendedor
                xbing_opciones.Filter = "xcod LIKE 'VENDED%'"
            Case 3
                Me.E_TEXTO.Text = MCobrador
                xbing_opciones.Filter = "xcod LIKE 'COBRAD%'"
            Case 4
                Me.E_TEXTO.Text = MVenta
                xbing_opciones.Filter = "xcod LIKE 'VENT%'"
            Case 5
                Me.E_TEXTO.Text = MCxC
                xbing_opciones.Filter = "xcod LIKE 'CXC%'"
            Case 6
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_TipoSistemaInstalado > TipoSistemaInstalado.Basico Then
                    Me.E_TEXTO.Text = MCompra
                    xbing_opciones.Filter = "xcod LIKE 'COMPRA%'"
                Else
                    MessageBox.Show("Modulo No Activado", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MCB_1.SelectedIndex = 0
                End If
            Case 7
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_TipoSistemaInstalado > TipoSistemaInstalado.Basico Then
                    Me.E_TEXTO.Text = MCxP
                    xbing_opciones.Filter = "xcod LIKE 'CXP%'"
                Else
                    MessageBox.Show("Modulo No Activado", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MCB_1.SelectedIndex = 0
                End If
            Case 8
                Me.E_TEXTO.Text = MGlobal
                xbing_opciones.Filter = "xcod LIKE 'GLOBAL%'"
            Case 9
                Me.E_TEXTO.Text = FASTFOOD
                xbing_opciones.Filter = "xcod LIKE 'FAST%'"
            Case 10
                Me.E_TEXTO.Text = PARKING
                xbing_opciones.Filter = "xcod LIKE 'PARK%'"
            Case 11
                Me.E_TEXTO.Text = RESTAURANT
                xbing_opciones.Filter = "xcod LIKE 'REST%'"
        End Select
        ActualizaData()
    End Sub

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        xtb_opciones = New DataTable
        xbing_opciones = New BindingSource(xtb_opciones, "")
    End Sub

    Private Sub MisGrid1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid1.Accion
        Try
            Dim xficha As Plantilla_ConfiguracionModulo = Nothing
            Dim xficha2 As Plantilla_ConfiguracionModulo_2 = Nothing
            Dim xficha3 As Plantilla_ConfiguracionModulo_3 = Nothing
            Dim xficha4 As Plantilla_ConfiguracionModulo_4 = Nothing
            Dim xficha5 As Plantilla_ConfiguracionModulo_5 = Nothing

            Select Case xbing_opciones.Current("xcod").ToString.Trim.ToUpper
                Case "CLIENTE_01"
                    Dim xclas As New ListaGrupoCliente(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)
                Case "CLIENTE_02"
                    Dim xclas As New ListaEstados(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)
                Case "CLIENTE_03"
                    Dim xclas As New ListaZonasCliente(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)
                Case "CLIENTE_04"
                    Dim xclas As New ListaVendedores(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)
                Case "CLIENTE_05"
                    Dim xclas As New ListaCobradores(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)

                Case "INVENT_01"
                    Dim xclas As New ListaMarcasProducto(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)
                Case "INVENT_02"
                    Dim xclas As New ListaEmpaquesProducto_Compra(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)
                Case "INVENT_03"
                    Dim xclas As New ListaEmpaquesProducto_Venta(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)
                Case "INVENT_04"
                    Dim xclas As New TipoPrecioManejar(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "INVENT_05"
                    Dim xclas As New LimiteProductosMostrarAdmBusquedaNormal(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)
                Case "INVENT_06"
                    Dim xclas As New ActivarPrecio_2(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "INVENT_07"
                    Dim xclas As New RutaCarpetaImgInventario(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha4 = New Plantilla_ConfiguracionModulo_4(xclas)

                Case "VENTAS_01"
                    Dim xclas As New RupturaPorExistencia(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_02"
                    Dim xclas As New ConfirmarEliminarItems(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_05"
                    Dim xclas As New OrdenAlImprimir(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_11"
                    Dim xclas As New RupturaCreditoCliente(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_12"
                    Dim xclas As New FacturarPrecioCero(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_14"
                    Dim xclas As New AbrirDocumentosOtrosUsuarios(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_17"
                    Dim xclas As New ActivarDescuentosCargos(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_18"
                    Dim xclas As New FacturarPorDebajoCosto(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_33"
                    Dim xclas As New PermitirPagoAnticipo(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_34"
                    Dim xclas As New PermitirAnticiposPedido(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_35"
                    Dim xclas As New ImpresoraFactura(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_38"
                    Dim xclas As New ImpresoraNC(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_15"
                    Dim xclas As New LimiteFacturar(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)
                Case "VENTAS_21"
                    Dim xclas As New LimiteAdmDocumentos(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)
                Case "VENTAS_22"
                    Dim xclas As New LimiteRetenciones(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)
                Case "VENTAS_41"
                    Dim xclas As New ImprimirLineaDetalleImpFiscal(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_42"
                    Dim xclas As New LimiteDiasTrasladarDocumento(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)
                Case "VENTAS_43"
                    Dim xclas As New ImpresoraPresup(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_44"
                    Dim xclas As New ImpresoraNotaE(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_45"
                    Dim xclas As New ImpresoraPedido(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_46"
                    Dim xclas As New ImpresoraOtros(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "VENTAS_47", "VENTAS_48", "VENTAS_49", "VENTAS_50"
                    Dim xclas As New SUBDETALLE_FISCAL(xbing_opciones.Current("xcod").ToString.Trim.ToUpper, xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha4 = New Plantilla_ConfiguracionModulo_4(xclas)


                Case "CXC_01"
                    Dim xclas As New LimiteAdmDocumentosCxC(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)
                Case "CXC_02"
                    Dim xclas As New MontoComisionChequeDevuelto(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha5 = New Plantilla_ConfiguracionModulo_5(xclas)
                Case "CXC_03"
                    Dim xclas As New CxC_DescuentoPorProntoPago(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha5 = New Plantilla_ConfiguracionModulo_5(xclas)

                Case "GLOBAL_01"
                    Dim xclas As New CalculoUtilidad(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "GLOBAL_04"
                    Dim xclas As New ProductoBuscarPor(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "GLOBAL_05"
                    Dim xclas As New ClienteBuscarPor(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "GLOBAL_06"
                    Dim xclas As New ProveedorBuscarPor(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "GLOBAL_14"
                    Dim xclas As New VendedorBuscarPor(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "GLOBAL_15"
                    Dim xclas As New CobradorBuscarPor(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "GLOBAL_16"
                    Dim xclas As New DepositoAsignado(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)
                Case "GLOBAL_17"
                    Dim xclas As New ModoPagoPorDefecto(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)
                Case "GLOBAL_03"
                    Dim xclas As New RutaReportes(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha4 = New Plantilla_ConfiguracionModulo_4(xclas)
                Case "GLOBAL_10"
                    Dim xclas As New ClaveMaxima(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha4 = New Plantilla_ConfiguracionModulo_4(xclas)
                Case "GLOBAL_11"
                    Dim xclas As New ClaveMedia(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha4 = New Plantilla_ConfiguracionModulo_4(xclas)
                Case "GLOBAL_12"
                    Dim xclas As New ClaveMinima(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha4 = New Plantilla_ConfiguracionModulo_4(xclas)
                Case "GLOBAL_18"
                    Dim xclas As New RespaldoBd(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha4 = New Plantilla_ConfiguracionModulo_4(xclas)
                Case "GLOBAL_19"
                    Dim xclas As New DepositoAsignadoCompras(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha = New Plantilla_ConfiguracionModulo(xclas)
                Case "GLOBAL_09"
                    Dim xclas As New ModeloSistemaUsar(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)

                Case "VENDED_01"
                    Dim xclas As New MontoComisionVendedor(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha5 = New Plantilla_ConfiguracionModulo_5(xclas)

                Case "COBRAD_01"
                    Dim xclas As New MontoComisionCobrador(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha5 = New Plantilla_ConfiguracionModulo_5(xclas)

                Case "COMPRAS_02"
                    Dim xclas As New LimiteAdmDocumentos_Compras(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)

                Case "COMPRAS_03"
                    Dim xclas As New RetencionesIva_Compras(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)

                Case "PANAD_01"
                    Dim xclas As New LimiteMaxTarjetas(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)
                Case "PANAD_02"
                    Dim xclas As New MostarTarjetas(xbing_opciones.Current("id_seguridad"), "PANAD_02")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "PANAD_03"
                    Dim xclas As New MostarTarjetas(xbing_opciones.Current("id_seguridad"), "PANAD_03")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "PANAD_04"
                    Dim xclas As New MostarTarjetas(xbing_opciones.Current("id_seguridad"), "PANAD_04")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)

                Case "PANAD_05"
                    Dim xclas As New NivelClaveSolicitar(xbing_opciones.Current("id_seguridad"), "PANAD_05")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "PANAD_06"
                    Dim xclas As New NivelClaveSolicitar(xbing_opciones.Current("id_seguridad"), "PANAD_06")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "PANAD_07"
                    Dim xclas As New NivelClaveSolicitar(xbing_opciones.Current("id_seguridad"), "PANAD_07")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)

                Case "CXP_02"
                    Dim xclas As New LimiteAdmDocumentosCxP(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)

                Case "FAST_01"
                    Dim xclas As New FASTFOOD_ABRIR_CUENTASPENDIENTES_OTROS_USUARIOS(xbing_opciones.Current("id_seguridad"), "FAST_01")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "FAST_02"
                    Dim xclas As New FASTFOOD_VISUALIZAR_REPORTE_CUADRECAJA(xbing_opciones.Current("id_seguridad"), "FAST_02")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "FAST_03"
                    Dim xclas As New FASTFOOD_CERRAROPERADOR_CON_CTASPENDIENTES(xbing_opciones.Current("id_seguridad"), "FAST_03")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "FAST_04"
                    Dim xclas As New FASTFOOD_LIMITEADMDOCUMENTOS(xbing_opciones.Current("id_seguridad"), "FAST_04")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)
                Case "FAST_05"
                    Dim xclas As New FASTFOOD_ORDEN_PREFERIDO_BUSCAR_ARTICULO(xbing_opciones.Current("id_seguridad"), "FAST_05")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "FAST_06"
                    Dim xclas As New FASTFOOD_PRECIO_TRABAJAR(xbing_opciones.Current("id_seguridad"), "FAST_06")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)

                Case "PARK_01"
                    Dim xclas As New TarifaHoraEstacionamiento(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha5 = New Plantilla_ConfiguracionModulo_5(xclas)

                Case "REST_01"
                    Dim xclas As New RESTAURANT_PRECIO_TRABAJAR(xbing_opciones.Current("id_seguridad"), "REST_01")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "REST_02"
                    Dim xclas As New RESTAURANT_NUMERO_MAXIMO_MESAS(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha3 = New Plantilla_ConfiguracionModulo_3(xclas)
                Case "REST_03"
                    Dim xclas As New RESTAURANT_TASA_SERVICIO(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha5 = New Plantilla_ConfiguracionModulo_5(xclas)
                Case "REST_04"
                    Dim xclas As New RESTAURANT_OFERTAS_PLATOS(xbing_opciones.Current("id_seguridad"), "REST_04")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "REST_05"
                    Dim xclas As New RESTAURANT_CERRAROPERADOR_CON_CTASPENDIENTES(xbing_opciones.Current("id_seguridad"), "REST_05")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "REST_06"
                    Dim xclas As New RESTAURANT_ACTIVAR_DISPOSITIVO_MOVIL(xbing_opciones.Current("id_seguridad"), "REST_06")
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha2 = New Plantilla_ConfiguracionModulo_2(xclas)
                Case "REST_07"
                    Dim xclas As New RESTAURANT_RUTACARPETAIMAGENES_SISTEMA(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha4 = New Plantilla_ConfiguracionModulo_4(xclas)
                Case "REST_08"
                    Dim xclas As New RESTAURANT_RUTACARPETAIMAGENES_WEB(xbing_opciones.Current("id_seguridad"))
                    AddHandler xclas._ActualizarOpcion, AddressOf CargarValoresOpciones
                    xficha4 = New Plantilla_ConfiguracionModulo_4(xclas)
            End Select

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If

            If xficha2 IsNot Nothing Then
                With xficha2
                    .ShowDialog()
                End With
            End If

            If xficha3 IsNot Nothing Then
                With xficha3
                    .ShowDialog()
                End With
            End If

            If xficha4 IsNot Nothing Then
                With xficha4
                    .ShowDialog()
                End With
            End If

            If xficha5 IsNot Nothing Then
                With xficha5
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        Finally
            ActualizaData()
        End Try
    End Sub

    Sub CargarValoresOpciones()
        g_MiData.F_GetData(xsql, xtb_opciones)
        For Each dr As DataRow In xtb_opciones.Rows
            If dr("xcod").ToString.Trim.ToUpper = "CLIENTE_01" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from grupo_cliente where auto=@auto", xp1)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "CLIENTE_02" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from estados where auto=@auto", xp1)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "CLIENTE_03" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from zona_cliente where auto=@auto", xp1)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "CLIENTE_04" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from vendedores where auto=@auto", xp1)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "CLIENTE_05" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from cobradores where auto=@auto", xp1)
            End If

            If dr("xcod").ToString.Trim.ToUpper = "INVENT_01" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from productos_marca where auto=@auto", xp1)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "INVENT_02" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from productos_medida where auto=@auto", xp1)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "INVENT_03" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from productos_medida where auto=@auto", xp1)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "INVENT_04" Then
                If dr("xusu").ToString.Trim.ToUpper = "MAYOR" Then
                    dr("xact") = "Precio Mayor"
                ElseIf dr("xusu").ToString.Trim.ToUpper = "DETAL" Then
                    dr("xact") = "Precio Detal"
                Else
                    dr("xact") = "Ambos"
                End If
            End If
            If dr("xcod").ToString.Trim.ToUpper = "INVENT_05" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "INVENT_06" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "INVENT_07" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If


            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_01" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_02" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_05" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_11" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_12" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_14" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_17" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_18" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_33" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_34" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_35" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_38" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_15" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_21" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_22" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_41" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_42" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_43" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_44" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_45" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_46" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_47" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_48" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_49" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "VENTAS_50" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If


            If dr("xcod").ToString.Trim.ToUpper = "CXC_01" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "CXC_02" Then
                dr("xact") = String.Format("{0:#0.00}", dr("xusu"))
            End If
            If dr("xcod").ToString.Trim.ToUpper = "CXC_03" Then
                dr("xact") = String.Format("{0:#0.00}", dr("xusu"))
            End If

            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_01" Then
                If dr("xusu").ToString.Trim.ToUpper = "LINEAL" Then
                    dr("xact") = "En Base Al Costo"
                Else
                    dr("xact") = "En Base Al Precio De Venta"
                End If
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_04" Then
                Select Case dr("xusu").ToString.Trim.ToUpper
                    Case "CODIGO" : dr("XACT") = "POR CODIGO"
                    Case "NOMBRE" : dr("XACT") = "POR NOMBRE"
                    Case "COD/BARRA" : dr("XACT") = "POR CODIGO DE BARRA"
                    Case "PLU" : dr("XACT") = "POR CODIGO PLU"
                    Case "NUM/PARTE" : dr("XACT") = "POR NUMERO DE PARTE"
                    Case "REFERENCIA" : dr("XACT") = "POR REFERENCIA"
                    Case "SERIAL" : dr("XACT") = "POR SERIAL"
                End Select
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_05" Then
                Select Case dr("xusu").ToString.Trim.ToUpper
                    Case "CI/RIF" : dr("XACT") = "POR CI/RIF"
                    Case "CODIGO" : dr("XACT") = "POR CODIGO"
                    Case "NOMBRE" : dr("XACT") = "POR NOMBRE"
                End Select
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_06" Then
                Select Case dr("xusu").ToString.Trim.ToUpper
                    Case "CI/RIF" : dr("XACT") = "POR CI/RIF"
                    Case "CODIGO" : dr("XACT") = "POR CODIGO"
                    Case "NOMBRE" : dr("XACT") = "POR NOMBRE"
                End Select
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_14" Then
                Select Case dr("xusu").ToString.Trim.ToUpper
                    Case "CI/RIF" : dr("XACT") = "POR CI/RIF"
                    Case "CODIGO" : dr("XACT") = "POR CODIGO"
                    Case "NOMBRE" : dr("XACT") = "POR NOMBRE"
                End Select
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_15" Then
                Select Case dr("xusu").ToString.Trim.ToUpper
                    Case "CI/RIF" : dr("XACT") = "POR CI/RIF"
                    Case "CODIGO" : dr("XACT") = "POR CODIGO"
                    Case "NOMBRE" : dr("XACT") = "POR NOMBRE"
                End Select
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_16" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from depositos where auto=@auto", xp1)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_17" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from medios_pago where auto=@auto", xp1)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_10" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_11" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_12" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_03" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_18" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_19" Then
                Dim xp1 As New SqlParameter("@auto", dr("xusu").ToString.Trim())
                dr("xact") = F_GetString("select nombre from depositos where auto=@auto", xp1)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "GLOBAL_09" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If

            If dr("xcod").ToString.Trim.ToUpper = "VENDED_01" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "COBRAD_01" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "COMPRAS_02" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If

            If dr("xcod").ToString.Trim.ToUpper = "PANAD_01" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "PANAD_02" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "PANAD_03" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "PANAD_04" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "PANAD_05" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "PANAD_06" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "PANAD_07" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If

            If dr("xcod").ToString.Trim.ToUpper = "CXP_02" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If

            If dr("xcod").ToString.Trim.ToUpper = "FAST_01" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "FAST_02" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "FAST_03" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "FAST_04" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "FAST_05" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "FAST_06" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If

            If dr("xcod").ToString.Trim.ToUpper = "PARK_01" Then
                Dim x As Decimal = 0
                Decimal.TryParse(dr("xusu"), x)
                dr("xact") = String.Format("{0:#0.00}", x)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "PARK_02" Then
                Dim x As Decimal = 0
                Decimal.TryParse(dr("xusu"), x)
                dr("xact") = String.Format("{0:#0.00}", x)
            End If
            If dr("xcod").ToString.Trim.ToUpper = "PARK_03" Then
                Dim x As Decimal = 0
                Decimal.TryParse(dr("xusu"), x)
                dr("xact") = String.Format("{0:#0.00}", x)
            End If

            If dr("xcod").ToString.Trim.ToUpper = "REST_01" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "REST_02" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "REST_03" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "REST_04" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "REST_05" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "REST_06" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "REST_07" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
            If dr("xcod").ToString.Trim.ToUpper = "REST_08" Then
                dr("xact") = dr("xusu").ToString.Trim.ToUpper
            End If
        Next
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbing_opciones.Current IsNot Nothing Then
            Me.E_VALOR.Text = xbing_opciones.Current("xact").ToString.Trim
            Me.E_OPCION.Text = xbing_opciones.Current("xNOM").ToString.Trim
        Else
            Me.E_VALOR.Text = ""
            Me.E_OPCION.Text = ""
        End If
    End Sub

    Private Sub MisGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MisGrid1.CellContentClick

    End Sub
End Class