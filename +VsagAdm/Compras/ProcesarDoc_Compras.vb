Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles

Public Class ProcesarDoc_Compras
    Dim xplantilla As IProcesarDocumentoCompra
    Dim xestatus_salida As Boolean

    Property _EstatusSalida() As Boolean
        Get
            Return xestatus_salida
        End Get
        Set(ByVal value As Boolean)
            xestatus_salida = value
        End Set
    End Property

    Property _Plantilla() As IProcesarDocumentoCompra
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IProcesarDocumentoCompra)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xtipodoc As IProcesarDocumentoCompra)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Plantilla = xtipodoc
    End Sub

    Private Sub ProcesarDoc_Compra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub ProcesarDoc_Compra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ProcesarDoc_Compra_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            _EstatusSalida = False
            _Plantilla.Inicializar(Me)
            IrInicio()

            Dim xfec_v As Date = DateAdd(DateInterval.Day, Me.MN_DIAS_CREDITO._Valor, Me.MF_FECHAEMISION.Value).Date
            Me.E_FECHA_VENCIMIENTO.Text = xfec_v.ToShortDateString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub MN_DIAS_CREDITO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MN_DIAS_CREDITO.TextChanged
        Dim xfec_v As Date = DateAdd(DateInterval.Day, Me.MN_DIAS_CREDITO._Valor, Me.MF_FECHAEMISION.Value).Date
        Me.E_FECHA_VENCIMIENTO.Text = xfec_v.ToShortDateString
        Me.Refresh()
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        Try
            _EstatusSalida = _Plantilla.ProcesarDoc()
            If _EstatusSalida = True Then
                Me.Close()
            Else
                IrInicio()
            End If
        Catch ex As Exception
            Me.Select()
            Me.Focus()
            IrInicio()

            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub IrInicio()
        Me.MT_SERIE.Select()
        Me.MT_SERIE.Focus()
    End Sub

    Private Sub MF_FECHAEMISION_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MF_FECHAEMISION.Validating
        If Me.MF_FECHAEMISION.Value > g_MiData.p_FechaDelMotorBD Then
            MessageBox.Show("Fecha Incorrecta.. Verifique Por Favor", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MF_FECHAEMISION.Value = g_MiData.p_FechaDelMotorBD
            e.Cancel = False
        End If
    End Sub

    Private Sub MF_FECHAEMISION_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MF_FECHAEMISION.ValueChanged
        Dim xfec_v As Date = DateAdd(DateInterval.Day, Me.MN_DIAS_CREDITO._Valor, Me.MF_FECHAEMISION.Value).Date
        Me.E_FECHA_VENCIMIENTO.Text = xfec_v.ToShortDateString
        Me.Refresh()
    End Sub

    Private Sub ProcesarDoc_Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MT_DOCUMENTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MT_DOCUMENTO.TextChanged

    End Sub
End Class

Public Interface IProcesarDocumentoCompra
    Function ProcesarDoc() As Boolean
    Sub Inicializar(ByVal xficha As Object)
    Event DocumentoProcesado()
End Interface

Class c_ProcesarDoc_Compras
    Implements IProcesarDocumentoCompra
    Public Event DocumentoProcesado() Implements IProcesarDocumentoCompra.DocumentoProcesado

    Dim _MiFormulario As Windows.Forms.Form
    Dim MT_DOCUMENTO As MisTextos
    Dim MT_CONTROL As MisTextos
    Dim MT_ORDEN As MisTextos
    Dim MT_NOTAS As MisTextos
    Dim MT_SERIE As MisTextos
    Dim MN_DIAS As MisNumeros
    Dim MF_FECHA As MisFechas
    Dim LB_FECHA As Windows.Forms.Label
    Dim LB_VENCE As Windows.Forms.Label
    Dim LB_CIRIF As Windows.Forms.Label
    Dim LB_CODIGO As Windows.Forms.Label
    Dim LB_NOMBRE As Windows.Forms.Label
    Dim LB_DIRFISCAL As Windows.Forms.Label

    Dim xfichapro As FichaProveedores.c_Proveedor.c_Registro
    Dim xtotales As TotalesDoc
    Dim xestatus_salida As Boolean
    Dim xfichaOrdenCompra As FichaCompras.c_Compra = Nothing

    Property _FichaProveedor() As FichaProveedores.c_Proveedor.c_Registro
        Get
            Return xfichapro
        End Get
        Set(ByVal value As FichaProveedores.c_Proveedor.c_Registro)
            xfichapro = value
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

    Sub New(ByVal xproveedor As FichaProveedores.c_Proveedor.c_Registro, ByVal xtotales As TotalesDoc)
        Me._FichaProveedor = xproveedor
        Me._MisTotales = xtotales
    End Sub

    Public Function DsctoFormaPago() As Boolean
        Dim xretorna As Boolean = False
        Dim xficha As New Dscto_FormaPagoCompras(_MisTotales, True)
        With xficha
            .ShowDialog()
            xretorna = ._EstatusSalida
        End With

        Return xretorna
    End Function

    Function Procesar() As Boolean
        Dim xcompra_encabezado As New FichaCompras.c_Compra.AgregarCompra
        Dim xcompra_detalle As New List(Of FichaCompras.c_ComprasDetalle.AgregarDetalleCompra)
        Dim xcompras As New FichaCompras

        Dim xtabla As DataTable
        Dim xp1 As SqlParameter
        Dim xp2 As SqlParameter

        Dim xerror As Boolean = False

        Try
            xtabla = New DataTable
            xp1 = New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            xp2 = New SqlParameter("@autousuario", g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario)
            g_MiData.F_GetData("select * from temporal_compra where idunico=@idunico and tipodocumento='1' and autousuario=@autousuario", xtabla, xp1, xp2)

            With xcompra_encabezado
                ._CantidadRenglones = _MisTotales._Lineas
                ._DiasCreditoOtorgado = MN_DIAS._Valor
                ._FactorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                ._FechaEmision = MF_FECHA.Value
                ._FechaProceso = g_MiData.p_FechaDelMotorBD
                ._Hora = g_MiData.p_HoraDelMotorBD
                ._MontoBase_1 = _MisTotales._Neto1
                ._MontoBase_2 = _MisTotales._Neto2
                ._MontoBase_3 = _MisTotales._Neto3
                ._MontoExento = _MisTotales._Exento
                ._MontoSubtotal = _MisTotales._Subtotal
                ._NombreEstacionEquipo = g_EquipoEstacion.p_EstacionNombre
                ._NotasDocumento = MT_NOTAS.r_Valor
                ._NumeroControl = MT_CONTROL.r_Valor
                ._NumeroDocumento = MT_DOCUMENTO.r_Valor
                ._OrdenCompraNumero = MT_ORDEN.r_Valor
                ._Proveedor = xfichapro
                ._SerieDocumento = MT_SERIE.r_Valor
                ._TasaCargos = _MisTotales._TasaCargo
                ._TasaDescuento_1 = _MisTotales._TasaDescuento
                ._TasaDescuento_2 = 0
                ._TasaIva_1 = _MisTotales._TasaIva1
                ._TasaIva_2 = _MisTotales._TasaIva2
                ._TasaIva_3 = _MisTotales._TasaIva3
                ._TipoDocumento = TipoDocumentoCompra.Factura
                ._Usuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._MontoImpuestoLicor = _MisTotales._ImpuestoLicor
                If xfichaOrdenCompra IsNot Nothing Then
                    ._FichaOrdenCompra = xfichaOrdenCompra.RegistroDato
                Else
                    ._FichaOrdenCompra = Nothing
                End If
            End With

            For Each xrow As DataRow In xtabla.Rows
                Dim xreg As New FichaCompras.c_TemporalCompra.c_Registro
                Dim xdetalle As New FichaCompras.c_ComprasDetalle.AgregarDetalleCompra
                Dim xprd As New FichaProducto.Prd_Producto
                Dim xdeposito As New FichaGlobal.c_Depositos
                Dim xcostocompra As Decimal = 0
                Dim xcostoinventario As Decimal = 0

                xreg.CargarRegistro(xrow)
                xprd.F_BuscarProducto(xreg._AutoProducto)
                'xprd.RegistroDato.SetTasaImpuesto(9)
                'xprd.RegistroDato.SetTipoImpuesto("3")
                xdeposito.F_BuscarDeposito(xreg._AutoDeposito)

                With xdetalle
                    ._CantidadCompra = xreg._CantidadItems
                    ._CantidadPromo = xreg._Bono
                    ._CostoBruto = xreg._CostoUnitario
                    ._CostoItem = xreg._Costo_Final
                    ._FichaDeposito = xdeposito.RegistroDato
                    ._FichaProducto = xprd.RegistroDato
                    ._MontoDescuento1 = xreg._Descuento_1._Valor()
                    ._MontoDescuento2 = xreg._Descuento_2._Valor
                    ._MontoDescuento3 = xreg._Descuento_3._Valor
                    ._NotasDetalles = xreg._NotasItem
                    ._PrecioSugerido = xreg._PSugerido
                    ._ProductoCodigoProveedor = xreg._CodigoProductoProveedor
                    ._TasaDescuento1 = xreg._Descuento_1._Tasa
                    ._TasaDescuento2 = xreg._Descuento_2._Tasa
                    ._TasaDescuento3 = xreg._Descuento_3._Tasa
                    ._TotalImporte = xreg._CostoTotal
                    ._MontoImpuestoLicor = xreg._MontoImpuestoLicor
                    ._ContenidoEmpaque = xreg._ContenidoEmpaque
                    ._AutoMedidaEmpaque = xreg._AutoMedida
                    ._NombreMedidaEmpaque = xreg._NombreEmpaque
                    ._ForzarMedidaEmpaque = xreg._ForzarMedida
                    ._NumeroDecimalesMedidaEmpaque = xreg._NumeroDecimalesMedida
                End With
                xcompra_detalle.Add(xdetalle)
            Next

            Dim xgrabar As New FichaCompras.GrabarCompra
            xgrabar._Compra = xcompra_encabezado
            xgrabar._CompraDetalle = xcompra_detalle
            xgrabar._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo

            If xtabla.Rows.Count > 0 Then
                AddHandler xcompras.FacturaExitosa, AddressOf VisualizarReporte
                xcompras.F_GrabarCompra(xgrabar)
                RaiseEvent DocumentoProcesado()
                Return True
            Else
                Throw New Exception("Error... Al Parecer Otro Usuario Ya Dispuso De Esta Ficha")
            End If
        Catch ex As Exception
            _MiFormulario.Select()
            _MiFormulario.Focus()
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub VisualizarReporte(ByVal xauto As String)
        VisualizarDoc_Compras(xauto)
    End Sub

    Public Function ProcesarDoc() As Boolean Implements IProcesarDocumentoCompra.ProcesarDoc
        If ValidarCampos() Then
            If DsctoFormaPago() Then
                Try
                    Return Procesar()
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                MT_DOCUMENTO.Select()
                MT_DOCUMENTO.Focus()
            End If
        End If
    End Function

    Public Sub Inicializar(ByVal xficha As Object) Implements IProcesarDocumentoCompra.Inicializar
        _MiFormulario = xficha

        MT_SERIE = _MiFormulario.Controls.Find("MT_SERIE", True)(0)
        MT_DOCUMENTO = _MiFormulario.Controls.Find("MT_DOCUMENTO", True)(0)
        MT_CONTROL = _MiFormulario.Controls.Find("MT_CONTROL", True)(0)
        MT_ORDEN = _MiFormulario.Controls.Find("MT_ORDEN_COMPRA", True)(0)
        MT_NOTAS = _MiFormulario.Controls.Find("MT_NOTAS", True)(0)
        MN_DIAS = _MiFormulario.Controls.Find("MN_DIAS_CREDITO", True)(0)
        MF_FECHA = _MiFormulario.Controls.Find("MF_FECHAEMISION", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("E_FECHAPROCESO", True)(0)
        LB_VENCE = _MiFormulario.Controls.Find("E_FECHA_VENCIMIENTO", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("E_RIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("E_CODIGO", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("E_NOMBRE", True)(0)
        LB_DIRFISCAL = _MiFormulario.Controls.Find("E_DIRECCION", True)(0)

        _MiFormulario.Text = "Compra"

        Inicializar()
    End Sub

    Sub Inicializar()
        With Me.MN_DIAS
            ._ConSigno = False
            ._Formato = "999"
            .Text = xfichapro._DiasCredito.ToString
        End With

        With Me.MT_SERIE
            .MaxLength = 10
            .Text = ""
        End With

        With Me.MT_DOCUMENTO
            .MaxLength = 15
            .Text = ""
        End With

        With Me.MT_CONTROL
            .MaxLength = 15
            .Text = ""
        End With

        With Me.MT_ORDEN
            .MaxLength = 10
            .Text = ""
        End With

        With Me.MT_NOTAS
            .MaxLength = 120
            .Text = ""
        End With

        Me.MF_FECHA.Value = g_MiData.p_FechaDelMotorBD

        _MisTotales._TasaDescuento = 0
        _MisTotales._TasaCargo = 0

        Me.LB_FECHA.Text = g_MiData.p_FechaDelMotorBD
        Me.LB_VENCE.Text = g_MiData.p_FechaDelMotorBD

        Me.LB_CODIGO.Text = Me._FichaProveedor._CodigoProveedor
        Me.LB_DIRFISCAL.Text = Me._FichaProveedor._DirFiscal
        Me.LB_NOMBRE.Text = Me._FichaProveedor._NombreRazonSocial
        Me.LB_CIRIF.Text = Me._FichaProveedor._CiRif

        Me.MT_SERIE.Select()
        Me.MT_SERIE.Focus()


        Dim xtabla As DataTable
        Dim xp1 As SqlParameter
        Dim xp2 As SqlParameter
        Dim xauto As String = ""

        xtabla = New DataTable
        xp1 = New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
        xp2 = New SqlParameter("@autousuario", g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario)
        g_MiData.F_GetData("select autoordencompra as auto from temporal_compra with (READPAST) where idunico=@idunico and tipodocumento='1' and autousuario=@autousuario group by autoordencompra", xtabla, xp1, xp2)
        For Each xr In xtabla.Rows
            If Not IsDBNull(xr("auto")) Then
                If xr("auto") IsNot Nothing Then
                    If xr("auto").ToString.Trim <> "" Then
                        xauto = xr("auto").ToString.Trim
                        Exit For
                    End If
                End If
            End If
        Next

        If xauto <> "" Then
            xfichaOrdenCompra = New FichaCompras.c_Compra
            xfichaOrdenCompra.F_CargarCompra(xauto)
            MT_ORDEN.Text = xfichaOrdenCompra.RegistroDato._NumeroDocumentoCompra
            MT_ORDEN.ReadOnly = True
        End If
    End Sub

    Function ValidarCampos() As Boolean
        If MT_DOCUMENTO.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR UN NUMERO DE DOCUMENTO, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DOCUMENTO.Select()
            MT_DOCUMENTO.Focus()
            Return False
        End If

        If MT_CONTROL.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR UN NUMERO DE CONTROL, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_CONTROL.Select()
            MT_CONTROL.Focus()
            Return False
        End If
        Return True
    End Function
End Class

Class c_ProcesarDoc_OrdenesCompra
    Implements IProcesarDocumentoCompra
    Public Event DocumentoProcesado() Implements IProcesarDocumentoCompra.DocumentoProcesado

    Dim _MiFormulario As Windows.Forms.Form
    Dim MT_DOCUMENTO As MisTextos
    Dim MT_CONTROL As MisTextos
    Dim MT_ORDEN As MisTextos
    Dim MT_NOTAS As MisTextos
    Dim MT_SERIE As MisTextos
    Dim MN_DIAS As MisNumeros
    Dim MF_FECHA As MisFechas
    Dim LB_FECHA As Windows.Forms.Label
    Dim LB_VENCE As Windows.Forms.Label
    Dim LB_CIRIF As Windows.Forms.Label
    Dim LB_CODIGO As Windows.Forms.Label
    Dim LB_NOMBRE As Windows.Forms.Label
    Dim LB_DIRFISCAL As Windows.Forms.Label

    Dim xfichapro As FichaProveedores.c_Proveedor.c_Registro
    Dim xtotales As TotalesDoc
    Dim xestatus_salida As Boolean

    Property _FichaProveedor() As FichaProveedores.c_Proveedor.c_Registro
        Get
            Return xfichapro
        End Get
        Set(ByVal value As FichaProveedores.c_Proveedor.c_Registro)
            xfichapro = value
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

    Sub New(ByVal xproveedor As FichaProveedores.c_Proveedor.c_Registro, ByVal xtotales As TotalesDoc)
        Me._FichaProveedor = xproveedor
        Me._MisTotales = xtotales
    End Sub

    Function Procesar() As Boolean
        Dim xcompra_encabezado As New FichaCompras.c_Compra.AgregarCompra
        Dim xcompra_detalle As New List(Of FichaCompras.c_ComprasDetalle.AgregarDetalleCompra)
        Dim xcompras As New FichaCompras

        Dim xtabla As DataTable
        Dim xp1 As SqlParameter
        Dim xp2 As SqlParameter

        Dim xerror As Boolean = False

        Try
            xtabla = New DataTable
            xp1 = New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            xp2 = New SqlParameter("@autousuario", g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario)
            g_MiData.F_GetData("select * from temporal_compra where idunico=@idunico and tipodocumento='4' and autousuario=@autousuario", xtabla, xp1, xp2)

            With xcompra_encabezado
                ._CantidadRenglones = _MisTotales._Lineas
                ._DiasCreditoOtorgado = MN_DIAS._Valor
                ._FactorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                ._FechaEmision = MF_FECHA.Value
                ._FechaProceso = g_MiData.p_FechaDelMotorBD
                ._Hora = g_MiData.p_HoraDelMotorBD
                ._MontoBase_1 = _MisTotales._Neto1
                ._MontoBase_2 = _MisTotales._Neto2
                ._MontoBase_3 = _MisTotales._Neto3
                ._MontoExento = _MisTotales._Exento
                ._MontoSubtotal = _MisTotales._Subtotal
                ._NombreEstacionEquipo = g_EquipoEstacion.p_EstacionNombre
                ._NotasDocumento = MT_NOTAS.r_Valor
                ._NumeroControl = MT_CONTROL.r_Valor
                ._NumeroDocumento = MT_DOCUMENTO.r_Valor
                ._OrdenCompraNumero = MT_ORDEN.r_Valor
                ._Proveedor = xfichapro
                ._SerieDocumento = MT_SERIE.r_Valor
                ._TasaCargos = _MisTotales._TasaCargo
                ._TasaDescuento_1 = _MisTotales._TasaDescuento
                ._TasaDescuento_2 = 0
                ._TasaIva_1 = _MisTotales._TasaIva1
                ._TasaIva_2 = _MisTotales._TasaIva2
                ._TasaIva_3 = _MisTotales._TasaIva3
                ._TipoDocumento = TipoDocumentoCompra.OrdenCompra
                ._Usuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._MontoImpuestoLicor = _MisTotales._ImpuestoLicor
            End With

            For Each xrow As DataRow In xtabla.Rows
                Dim xreg As New FichaCompras.c_TemporalCompra.c_Registro
                Dim xdetalle As New FichaCompras.c_ComprasDetalle.AgregarDetalleCompra
                Dim xprd As New FichaProducto.Prd_Producto
                Dim xdeposito As New FichaGlobal.c_Depositos
                Dim xcostocompra As Decimal = 0
                Dim xcostoinventario As Decimal = 0

                xreg.CargarRegistro(xrow)
                xprd.F_BuscarProducto(xreg._AutoProducto)
                xdeposito.F_BuscarDeposito(xreg._AutoDeposito)

                With xdetalle
                    ._CantidadCompra = xreg._CantidadItems
                    ._CantidadPromo = xreg._Bono
                    ._CostoBruto = xreg._CostoUnitario
                    ._CostoItem = xreg._Costo_Final
                    ._FichaDeposito = xdeposito.RegistroDato
                    ._FichaProducto = xprd.RegistroDato
                    ._MontoDescuento1 = xreg._Descuento_1._Valor()
                    ._MontoDescuento2 = xreg._Descuento_2._Valor
                    ._MontoDescuento3 = xreg._Descuento_3._Valor
                    ._NotasDetalles = xreg._NotasItem
                    ._PrecioSugerido = xreg._PSugerido
                    ._ProductoCodigoProveedor = xreg._CodigoProductoProveedor
                    ._TasaDescuento1 = xreg._Descuento_1._Tasa
                    ._TasaDescuento2 = xreg._Descuento_2._Tasa
                    ._TasaDescuento3 = xreg._Descuento_3._Tasa
                    ._TotalImporte = xreg._CostoTotal
                    ._MontoImpuestoLicor = xreg._MontoImpuestoLicor
                End With
                xcompra_detalle.Add(xdetalle)
            Next

            Dim xgrabar As New FichaCompras.GrabarCompra
            xgrabar._Compra = xcompra_encabezado
            xgrabar._CompraDetalle = xcompra_detalle
            xgrabar._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo

            If xtabla.Rows.Count > 0 Then
                AddHandler xcompras.FacturaExitosa, AddressOf VisualizarReporte
                xcompras.F_GrabarOrdenCompra(xgrabar)
                RaiseEvent DocumentoProcesado()
                Return True
            Else
                Throw New Exception("Error... Al Parecer Otro Usuario Ya Dispuso De Esta Ficha")
            End If
        Catch ex As Exception
            _MiFormulario.Select()
            _MiFormulario.Focus()
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub VisualizarReporte(ByVal xauto As String)
        VisualizarDoc_Compras(xauto)
    End Sub

    Public Function ProcesarDoc() As Boolean Implements IProcesarDocumentoCompra.ProcesarDoc
        Try
            If DsctoFormaPago() Then
                Try
                    Return Procesar()
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                MT_DOCUMENTO.Select()
                MT_DOCUMENTO.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function DsctoFormaPago() As Boolean
        Dim xretorna As Boolean = False
        Dim xficha As New Dscto_FormaPagoCompras(_MisTotales, True)
        With xficha
            .ShowDialog()
            xretorna = ._EstatusSalida
        End With

        Return xretorna
    End Function

    Public Sub Inicializar(ByVal xficha As Object) Implements IProcesarDocumentoCompra.Inicializar
        _MiFormulario = xficha

        MT_SERIE = _MiFormulario.Controls.Find("MT_SERIE", True)(0)
        MT_DOCUMENTO = _MiFormulario.Controls.Find("MT_DOCUMENTO", True)(0)
        MT_CONTROL = _MiFormulario.Controls.Find("MT_CONTROL", True)(0)
        MT_ORDEN = _MiFormulario.Controls.Find("MT_ORDEN_COMPRA", True)(0)
        MT_NOTAS = _MiFormulario.Controls.Find("MT_NOTAS", True)(0)
        MN_DIAS = _MiFormulario.Controls.Find("MN_DIAS_CREDITO", True)(0)
        MF_FECHA = _MiFormulario.Controls.Find("MF_FECHAEMISION", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("E_FECHAPROCESO", True)(0)
        LB_VENCE = _MiFormulario.Controls.Find("E_FECHA_VENCIMIENTO", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("E_RIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("E_CODIGO", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("E_NOMBRE", True)(0)
        LB_DIRFISCAL = _MiFormulario.Controls.Find("E_DIRECCION", True)(0)

        _MiFormulario.Text = "Orden De Compra"

        Inicializar()
    End Sub

    Sub Inicializar()
        With Me.MN_DIAS
            ._ConSigno = False
            ._Formato = "999"
            .Text = xfichapro._DiasCredito.ToString
        End With

        With Me.MT_SERIE
            .ReadOnly = True
            .Text = ""
        End With

        With Me.MT_DOCUMENTO
            .ReadOnly = True
            .Text = ""
        End With

        With Me.MT_CONTROL
            .ReadOnly = True
            .Text = ""
        End With

        With Me.MT_ORDEN
            .ReadOnly = True
            .Text = ""
        End With

        With Me.MT_NOTAS
            .MaxLength = 120
            .Text = ""
        End With

        Me.MF_FECHA.Value = g_MiData.p_FechaDelMotorBD

        _MisTotales._TasaDescuento = 0
        _MisTotales._TasaCargo = 0

        Me.LB_FECHA.Text = g_MiData.p_FechaDelMotorBD
        Me.LB_VENCE.Text = g_MiData.p_FechaDelMotorBD

        Me.LB_CODIGO.Text = Me._FichaProveedor._CodigoProveedor
        Me.LB_DIRFISCAL.Text = Me._FichaProveedor._DirFiscal
        Me.LB_NOMBRE.Text = Me._FichaProveedor._NombreRazonSocial
        Me.LB_CIRIF.Text = Me._FichaProveedor._CiRif

        Me.MT_SERIE.Select()
        Me.MT_SERIE.Focus()
    End Sub
End Class

Class c_ProcesarDoc_NC
    Implements IProcesarDocumentoCompra
    Public Event DocumentoProcesado() Implements IProcesarDocumentoCompra.DocumentoProcesado

    Dim _MiFormulario As Windows.Forms.Form
    Dim MT_DOCUMENTO As MisTextos
    Dim MT_CONTROL As MisTextos
    Dim MT_ORDEN As MisTextos
    Dim MT_NOTAS As MisTextos
    Dim MT_SERIE As MisTextos
    Dim MN_DIAS As MisNumeros
    Dim MF_FECHA As MisFechas
    Dim LB_FECHA As Windows.Forms.Label
    Dim LB_VENCE As Windows.Forms.Label
    Dim LB_CIRIF As Windows.Forms.Label
    Dim LB_CODIGO As Windows.Forms.Label
    Dim LB_NOMBRE As Windows.Forms.Label
    Dim LB_DIRFISCAL As Windows.Forms.Label

    Dim xfichapro As FichaProveedores.c_Proveedor.c_Registro
    Dim xtotales As TotalesDoc
    Dim xestatus_salida As Boolean

    Dim xtabla As DataTable
    Dim xficha_compra As FichaCompras.c_Compra.c_Registro

    Property _FichaProveedor() As FichaProveedores.c_Proveedor.c_Registro
        Get
            Return xfichapro
        End Get
        Set(ByVal value As FichaProveedores.c_Proveedor.c_Registro)
            xfichapro = value
        End Set
    End Property

    Property _TablaData() As DataTable
        Get
            Return xtabla
        End Get
        Set(ByVal value As DataTable)
            xtabla = value
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

    Property _FichaCompra() As FichaCompras.c_Compra.c_Registro
        Get
            Return xficha_compra
        End Get
        Set(ByVal value As FichaCompras.c_Compra.c_Registro)
            xficha_compra = value
        End Set
    End Property

    Sub New(ByVal xproveedor As FichaProveedores.c_Proveedor.c_Registro, ByVal xtotalesdoc As TotalesDoc, ByVal xdata As DataTable, ByVal xfichacompra As FichaCompras.c_Compra.c_Registro)
        Me._FichaProveedor = xproveedor
        Me._MisTotales = xtotalesdoc
        Me._TablaData = xdata
        Me._FichaCompra = xfichacompra
    End Sub

    Public Function DsctoFormaPago() As Boolean
        Dim xretorna As Boolean = False
        Dim xficha As New Dscto_FormaPagoCompras(_MisTotales, False)
        With xficha
            .ShowDialog()
            xretorna = ._EstatusSalida
        End With

        Return xretorna
    End Function

    Function Procesar() As Boolean
        Dim xcompra_encabezado As New FichaCompras.c_Compra.AgregarCompra
        Dim xcompra_detalle As New List(Of FichaCompras.c_ComprasDetalle.AgregarDetalleNC)
        Dim xcompras As New FichaCompras

        For Each xrow As DataRow In _TablaData.Rows
            If xrow("x7") = 1 Then
                Dim xdetalle As New FichaCompras.c_ComprasDetalle.AgregarDetalleNC
                Dim xdet As New FichaCompras.c_ComprasDetalle
                xdet.RegistroDato.M_CargarData(xrow)
                Dim xentrar As Boolean = True

                If _MisTotales._TasaDescuento > 0 Then
                    If xrow("x8").ToString.Trim = "D" And xrow("x3") < xdet.RegistroDato._CantidadCompra Then
                        Throw New Exception("ERROR... NO SE PUEDE ASIGNAR DESCUENTO GLOBAL A UNA DEVOLUCIÓN, VERIFIQUE")
                    Else
                        If xrow("x8").ToString.Trim = "D" Then
                            xentrar = False
                        End If
                        Dim xdetalle1 As New FichaCompras.c_ComprasDetalle.AgregarDetalleNC
                        With xdetalle1
                            ._Cantidad = xrow("x3")
                            ._Importe = Decimal.Round(xdet.RegistroDato._TotalNeto * _MisTotales._TasaDescuento / 100, 2, MidpointRounding.AwayFromZero)
                            ._NotasItem = "FALTO DESCUENTO GLOBAL"
                            ._ItemDetalleOrigen = xdet.RegistroDato
                            ._TipoMovimiento = TipoMovimientoCompraDetalle.AjusteGlobal
                        End With
                        xcompra_detalle.Add(xdetalle1)

                        Select Case xdet.RegistroDato._TipoTasa
                            Case "0"
                                _MisTotales._Exento += Decimal.Round(xdet.RegistroDato._TotalNeto * _MisTotales._TasaDescuento / 100, 2, MidpointRounding.AwayFromZero)
                            Case "1"
                                _MisTotales._Neto1 += Decimal.Round(xdet.RegistroDato._TotalNeto * _MisTotales._TasaDescuento / 100, 2, MidpointRounding.AwayFromZero)
                            Case "2"
                                _MisTotales._Neto2 += Decimal.Round(xdet.RegistroDato._TotalNeto * _MisTotales._TasaDescuento / 100, 2, MidpointRounding.AwayFromZero)
                            Case "3"
                                _MisTotales._Neto3 += Decimal.Round(xdet.RegistroDato._TotalNeto * _MisTotales._TasaDescuento / 100, 2, MidpointRounding.AwayFromZero)
                        End Select
                    End If
                End If

                If xentrar Then
                    With xdetalle
                        ._Cantidad = xrow("x3")
                        ._TasaDescuento1 = xrow("x9")
                        ._TasaDescuento2 = xrow("x10")
                        ._TasaDescuento3 = xrow("x11")
                        ._CostoNeto = xrow("x4")
                        ._Importe = xrow("x6")
                        ._NotasItem = xrow("x12")
                        ._ItemDetalleOrigen = xdet.RegistroDato
                        ._TipoMovimiento = IIf(xrow("x8").ToString.Trim = "A", TipoMovimientoCompraDetalle.Ajuste, TipoMovimientoCompraDetalle.Devolucion)
                    End With
                    xcompra_detalle.Add(xdetalle)
                Else
                    Select Case xdet.RegistroDato._TipoTasa
                        Case "0"
                            _MisTotales._Exento -= Decimal.Round(xrow("x6"), 2, MidpointRounding.AwayFromZero)
                        Case "1"
                            _MisTotales._Neto1 -= Decimal.Round(xrow("x6"), 2, MidpointRounding.AwayFromZero)
                        Case "2"
                            _MisTotales._Neto2 -= Decimal.Round(xrow("x6"), 2, MidpointRounding.AwayFromZero)
                        Case "3"
                            _MisTotales._Neto3 -= Decimal.Round(xrow("x6"), 2, MidpointRounding.AwayFromZero)
                    End Select
                End If
            End If
        Next

        With xcompra_encabezado
            ._CantidadRenglones = xcompra_detalle.Count
            ._DiasCreditoOtorgado = MN_DIAS._Valor
            ._FactorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
            ._FechaEmision = MF_FECHA.Value
            ._FechaProceso = g_MiData.p_FechaDelMotorBD
            ._Hora = g_MiData.p_HoraDelMotorBD
            ._MontoBase_1 = _MisTotales._Neto1
            ._MontoBase_2 = _MisTotales._Neto2
            ._MontoBase_3 = _MisTotales._Neto3
            ._MontoExento = _MisTotales._Exento
            ._MontoSubtotal = _MisTotales._Subtotal
            ._NombreEstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            ._NotasDocumento = MT_NOTAS.r_Valor
            ._NumeroControl = MT_CONTROL.r_Valor
            ._NumeroDocumento = MT_DOCUMENTO.r_Valor
            ._OrdenCompraNumero = MT_ORDEN.r_Valor
            ._Proveedor = xfichapro
            ._SerieDocumento = MT_SERIE.r_Valor
            ._TasaCargos = _MisTotales._TasaCargo
            ._TasaDescuento_1 = 0
            ._TasaDescuento_2 = 0
            ._TasaIva_1 = _MisTotales._TasaIva1
            ._TasaIva_2 = _MisTotales._TasaIva2
            ._TasaIva_3 = _MisTotales._TasaIva3
            ._TipoDocumento = TipoDocumentoCompra.NotaCredito
            ._Usuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
        End With

        Dim xgrabarnc As New FichaCompras.GrabarNC
        xgrabarnc._Compra_NC = xcompra_encabezado
        xgrabarnc._CompraDetalle_NC = xcompra_detalle
        xgrabarnc._FichaCompraOrigen = _FichaCompra
        If _TablaData.Rows.Count > 0 Then
            AddHandler xcompras.FacturaExitosa, AddressOf VisualizarReporte
            xcompras.F_GrabarNC(xgrabarnc)
            RaiseEvent DocumentoProcesado()
            Return True
        Else
            Throw New Exception("Error... Al Parecer Otro Usuario Ya Dispuso De Esta Ficha")
        End If
    End Function

    Sub VisualizarReporte(ByVal xauto As String)
        VisualizarDoc_Compras(xauto)
    End Sub

    Public Function ProcesarDoc() As Boolean Implements IProcesarDocumentoCompra.ProcesarDoc
        Try
            If ValidarCampos() Then
                If DsctoFormaPago() Then
                    Return Procesar()
                Else
                    MT_SERIE.Select()
                    MT_SERIE.Focus()
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Inicializar(ByVal xficha As Object) Implements IProcesarDocumentoCompra.Inicializar
        _MiFormulario = xficha
        _MiFormulario.Text = "Nota De Credito"

        MT_SERIE = _MiFormulario.Controls.Find("MT_SERIE", True)(0)
        MT_DOCUMENTO = _MiFormulario.Controls.Find("MT_DOCUMENTO", True)(0)
        MT_CONTROL = _MiFormulario.Controls.Find("MT_CONTROL", True)(0)
        MT_ORDEN = _MiFormulario.Controls.Find("MT_ORDEN_COMPRA", True)(0)
        MT_NOTAS = _MiFormulario.Controls.Find("MT_NOTAS", True)(0)
        MN_DIAS = _MiFormulario.Controls.Find("MN_DIAS_CREDITO", True)(0)
        MF_FECHA = _MiFormulario.Controls.Find("MF_FECHAEMISION", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("E_FECHAPROCESO", True)(0)
        LB_VENCE = _MiFormulario.Controls.Find("E_FECHA_VENCIMIENTO", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("E_RIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("E_CODIGO", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("E_NOMBRE", True)(0)
        LB_DIRFISCAL = _MiFormulario.Controls.Find("E_DIRECCION", True)(0)

        Inicializar()
    End Sub

    Sub Inicializar()
        With Me.MN_DIAS
            ._ConSigno = False
            ._Formato = "999"
            .Text = "0"
            .Enabled = False
        End With

        With Me.MT_SERIE
            .MaxLength = 10
            .Text = ""
        End With

        With Me.MT_DOCUMENTO
            .MaxLength = 15
            .Text = ""
        End With

        With Me.MT_CONTROL
            .MaxLength = 10
            .Text = ""
        End With

        With Me.MT_ORDEN
            .MaxLength = 10
            .Text = ""
        End With

        With Me.MT_NOTAS
            .MaxLength = 120
            .Text = ""
        End With

        Me.MF_FECHA.Value = g_MiData.p_FechaDelMotorBD

        _MisTotales._TasaDescuento = 0
        _MisTotales._TasaCargo = 0

        Me.LB_FECHA.Text = g_MiData.p_FechaDelMotorBD
        Me.LB_VENCE.Text = g_MiData.p_FechaDelMotorBD

        Me.LB_CODIGO.Text = Me._FichaProveedor._CodigoProveedor
        Me.LB_DIRFISCAL.Text = Me._FichaProveedor._DirFiscal
        Me.LB_NOMBRE.Text = Me._FichaProveedor._NombreRazonSocial
        Me.LB_CIRIF.Text = Me._FichaProveedor._CiRif

        Me.MT_SERIE.Select()
        Me.MT_SERIE.Focus()
    End Sub

    Function ValidarCampos() As Boolean
        'If MT_SERIE.r_Valor = "" Then
        '    MessageBox.Show("DEBE REGISTRAR UN NUMERO DE SERIE, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    MT_SERIE.Select()
        '    MT_SERIE.Focus()
        '    Return False
        'End If

        If MT_DOCUMENTO.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR UN NUMERO DE DOCUMENTO, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DOCUMENTO.Select()
            MT_DOCUMENTO.Focus()
            Return False
        End If

        If MT_CONTROL.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR UN NUMERO DE CONTROL, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_CONTROL.Select()
            MT_CONTROL.Focus()
            Return False
        End If
        Return True
    End Function
End Class
