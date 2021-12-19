Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles

Public Class ProcesarGastos_NC
    Dim xpla As IProcesarGastos_NC

    Property _MiPlantilla() As IProcesarGastos_NC
        Get
            Return xpla
        End Get
        Set(ByVal value As IProcesarGastos_NC)
            xpla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IProcesarGastos_NC)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _MiPlantilla = xplantilla
    End Sub

    Sub Inicializar()
        Try
            _MiPlantilla.Inicializar(Me)
            Me.Label6.Text = g_MiData.p_FechaDelMotorBD.ToShortDateString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub ProcesarGastos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializar()
    End Sub

End Class

Public Interface IProcesarGastos_NC
    Sub Inicializar(ByVal xform As Object)
End Interface

Class c_ProcesarGastos_NC
    Implements IProcesarGastos_NC

    'MIS CONTROLES
    WithEvents T_1 As MisTextos
    WithEvents T_2 As MisTextos
    WithEvents T_3 As MisTextos
    WithEvents T_5 As MisTextos
    WithEvents N_1 As MisNumeros
    WithEvents N_2 As MisNumeros
    WithEvents N_3 As MisNumeros
    WithEvents N_4 As MisNumeros
    WithEvents F_1 As MisFechas
    WithEvents LB_1 As Label
    WithEvents LB_2 As Label
    WithEvents LB_3 As Label
    WithEvents LB_4 As Label
    WithEvents LB_5 As Label
    WithEvents LB_6 As Label
    WithEvents LB_7 As Label
    WithEvents LB_8 As Label
    WithEvents LB_9 As Label
    WithEvents LB_10 As Label
    WithEvents LB_11 As Label
    WithEvents LB_12 As Label
    WithEvents LB_13 As Label
    WithEvents LB_14 As Label
    WithEvents LB_15 As Label
    WithEvents LLB_2 As LinkLabel
    WithEvents BT_1 As Button
    WithEvents _MiFormulario As Form
    WithEvents xToolTip As New System.Windows.Forms.ToolTip()

    Dim xpro As FichaProveedores
    Dim xficha_compra As FichaCompras
    Dim xtotales As TotalesDoc
    Dim xautodoccompra As String
    Dim xestatussalida As Boolean

    Sub New(ByVal xautocompra As String)
        _FichaCompra = New FichaCompras
        _FichaProveedor = New FichaProveedores
        Me._MisTotales = New TotalesDoc
        Me._EstatusSalida = True

        Me._AutoDocCompraCargar = xautocompra
    End Sub

    Property _EstatusSalida() As Boolean
        Get
            Return xestatussalida
        End Get
        Set(ByVal value As Boolean)
            xestatussalida = value
        End Set
    End Property

    Property _AutoDocCompraCargar() As String
        Get
            Return xautodoccompra
        End Get
        Set(ByVal value As String)
            xautodoccompra = value
        End Set
    End Property

    Property _FichaProveedor() As FichaProveedores
        Get
            Return xpro
        End Get
        Set(ByVal value As FichaProveedores)
            xpro = value
        End Set
    End Property

    Property _FichaCompra() As FichaCompras
        Get
            Return xficha_compra
        End Get
        Set(ByVal value As FichaCompras)
            xficha_compra = value
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

    Public Sub Inicializar(ByVal xform As Object) Implements IProcesarGastos_NC.Inicializar
        Try
            _MiFormulario = CType(xform, Form)

            T_1 = _MiFormulario.Controls.Find("MT_1", True)(0)
            T_2 = _MiFormulario.Controls.Find("MT_2", True)(0)
            T_3 = _MiFormulario.Controls.Find("MT_3", True)(0)
            T_5 = _MiFormulario.Controls.Find("MT_5", True)(0)
            N_1 = _MiFormulario.Controls.Find("MN_1", True)(0)
            N_2 = _MiFormulario.Controls.Find("MN_2", True)(0)
            N_3 = _MiFormulario.Controls.Find("MN_3", True)(0)
            N_4 = _MiFormulario.Controls.Find("MN_4", True)(0)
            F_1 = _MiFormulario.Controls.Find("MF_1", True)(0)
            LB_1 = _MiFormulario.Controls.Find("E_1", True)(0)
            LB_2 = _MiFormulario.Controls.Find("E_2", True)(0)
            LB_3 = _MiFormulario.Controls.Find("E_3", True)(0)
            LB_4 = _MiFormulario.Controls.Find("E_4", True)(0)
            LB_5 = _MiFormulario.Controls.Find("E_5", True)(0)
            LB_6 = _MiFormulario.Controls.Find("E_6", True)(0)
            LB_7 = _MiFormulario.Controls.Find("E_7", True)(0)
            LB_8 = _MiFormulario.Controls.Find("E_8", True)(0)
            LB_9 = _MiFormulario.Controls.Find("E_9", True)(0)
            LB_10 = _MiFormulario.Controls.Find("E_10", True)(0)
            LB_11 = _MiFormulario.Controls.Find("E_11", True)(0)
            LB_12 = _MiFormulario.Controls.Find("E_12", True)(0)
            LB_13 = _MiFormulario.Controls.Find("E_13", True)(0)
            LB_14 = _MiFormulario.Controls.Find("E_14", True)(0)
            LB_15 = _MiFormulario.Controls.Find("E_15", True)(0)
            LLB_2 = _MiFormulario.Controls.Find("LLB_2", True)(0)
            BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            xToolTip.SetToolTip(LLB_2, "Ir A Ficha Proveedores")
            InicializarControles()

            _FichaCompra.F_Compras.F_CargarCompra(Me._AutoDocCompraCargar)
            If _FichaCompra.F_Compras.RegistroDato._TipoCompraRegistrada = TipoCompraRegistrada.CompraGasto Then
                MostrarDoc()
            Else
                Me._EstatusSalida = False
                Throw New Exception("LA NOTA DE CREDITO PARA ESTE DOCUMENTO NO PUEDE SER PROCESADA POR ESTE MODULO. VERIFIQUE")
            End If
        Catch ex As Exception
            Me._EstatusSalida = False
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub InicializarControles()
        With T_1
            .Enabled = False
            .Text = ""
            .MaxLength = 10
        End With

        With T_2
            .Enabled = False
            .Text = ""
            .MaxLength = 15
        End With

        With T_3
            .Enabled = False
            .Text = ""
            .MaxLength = 10
        End With

        With T_5
            .Enabled = False
            .Text = ""
            .MaxLength = 120
        End With

        With N_1
            .Enabled = False
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
        End With

        With N_2
            .Enabled = False
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
        End With

        With N_3
            .Enabled = False
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
        End With

        With N_4
            .Enabled = False
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
        End With

        LB_1.Text = ""
        LB_2.Text = ""
        LB_3.Text = ""
        LB_4.Text = ""
        LB_5.Text = ""
        LB_6.Text = ""
        LB_7.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_1)
        LB_8.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_2)
        LB_9.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_3)

        _MisTotales._TasaIva1 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_1
        _MisTotales._TasaIva2 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_2
        _MisTotales._TasaIva3 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_3

        LB_10.Text = "0.00"
        LB_11.Text = "0.00"
        LB_12.Text = "0.00"
        LB_13.Text = "0.00"
        LB_14.Text = "0.00"
        LB_15.Text = "0.00"

        BT_1.Enabled = False
        F_1.Enabled = False

        IrInicio()
    End Sub

    Private Sub _MiFormulario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles _MiFormulario.FormClosing
        If _EstatusSalida Then
            If MessageBox.Show("¿Esta Seguro De Salir De La Plantilla?", "*** Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Sub IrInicio()
        T_1.Select()
        T_1.Focus()
    End Sub

    Private Sub _MiFormulario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _MiFormulario.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            _MiFormulario.Close()
        End If
    End Sub

    Private Sub LLB_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LLB_2.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor.F_Permitir()

            Dim xficha As New FichaProveedor(Me._FichaProveedor.f_Proveedor.RegistroDato._Automatico)
            With xficha
                .Show()
            End With
            IrInicio()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub F_1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_1.ValueChanged
        If F_1.r_Valor.Date > g_MiData.p_FechaDelMotorBD.Date Then
            F_1.Value = g_MiData.p_FechaDelMotorBD
        End If
    End Sub

    Private Sub ActualizarImportes(ByVal sender As Object, ByVal e As System.EventArgs) Handles N_1.LostFocus, N_2.LostFocus, N_3.LostFocus, N_4.LostFocus
        ActualizaImportes()
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            If ValidarCampos() Then
                If MessageBox.Show("¿Esta Seguro De Registrar Este Documento?", "*** Mensaje ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If Procesar() Then
                        Me._EstatusSalida = False
                        Me._MiFormulario.Close()
                        'LimpiarControles()
                    End If
                Else
                    T_1.Select()
                    T_1.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function Procesar() As Boolean
        Dim xcompra_encabezado As New FichaCompras.c_Compra.AgregarCompra
        Dim xcompras As New FichaCompras
        Try
            With xcompra_encabezado
                ._CantidadRenglones = 0
                ._DiasCreditoOtorgado = 0
                ._FactorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                ._FechaEmision = F_1.r_Valor
                ._FechaProceso = g_MiData.p_FechaDelMotorBD
                ._Hora = g_MiData.p_HoraDelMotorBD
                ._MontoBase_1 = _MisTotales._Neto1
                ._MontoBase_2 = _MisTotales._Neto2
                ._MontoBase_3 = _MisTotales._Neto3
                ._MontoExento = _MisTotales._Exento
                ._MontoSubtotal = _MisTotales._Subtotal
                ._NombreEstacionEquipo = g_EquipoEstacion.p_EstacionNombre
                ._NotasDocumento = T_5.r_Valor
                ._NumeroControl = T_3.r_Valor
                ._NumeroDocumento = T_2.r_Valor
                ._OrdenCompraNumero = ""
                ._Proveedor = Me._FichaProveedor.f_Proveedor.RegistroDato
                ._SerieDocumento = T_1.r_Valor
                ._TasaCargos = 0
                ._TasaDescuento_1 = 0
                ._TasaDescuento_2 = 0
                ._TasaIva_1 = _MisTotales._TasaIva1
                ._TasaIva_2 = _MisTotales._TasaIva2
                ._TasaIva_3 = _MisTotales._TasaIva3
                ._TipoDocumento = TipoDocumentoCompra.NotaCredito
                ._Usuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
            End With

            Dim xgrabar As New FichaCompras.GrabarGasto_NC
            xgrabar._Compra_NC = xcompra_encabezado
            xgrabar._FichaCompraOrigen = _FichaCompra.F_Compras.RegistroDato

            AddHandler xcompras.FacturaExitosa, AddressOf VisualizarReporte
            xcompras.F_GrabarGasto_NC(xgrabar)
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub VisualizarReporte(ByVal xauto As String)
        MessageBox.Show("EL DOCUMENTO DE NOTA DE CRÉDITO SE REGISTRO CORRECTAMENTE!!!", "*Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
        VisualizarDoc_Gastos(xauto)
    End Sub

    Sub ActivarDesactivarControles(ByVal op As Boolean)
        Me.T_1.Enabled = op
        Me.T_2.Enabled = op
        Me.T_3.Enabled = op
        Me.T_5.Enabled = op
        Me.N_1.Enabled = op
        Me.N_2.Enabled = op
        Me.N_3.Enabled = op
        Me.N_4.Enabled = op
        Me.BT_1.Enabled = op
        Me.F_1.Enabled = op
    End Sub

    Sub LimpiarControles()
        T_1.Text = ""
        T_2.Text = ""
        T_3.Text = ""
        T_5.Text = ""

        N_1.Text = "0.00"
        N_2.Text = "0.00"
        N_3.Text = "0.00"
        N_4.Text = "0.00"

        LB_1.Text = ""
        LB_2.Text = ""
        LB_3.Text = ""
        LB_4.Text = ""

        LB_5.Text = ""
        LB_6.Text = ""

        LB_7.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_1)
        LB_8.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_2)
        LB_9.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_3)

        _MisTotales._Exento = 0
        _MisTotales._Neto1 = 0
        _MisTotales._Neto2 = 0
        _MisTotales._Neto3 = 0
        _MisTotales._TasaIva1 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_1
        _MisTotales._TasaIva2 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_2
        _MisTotales._TasaIva3 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_3

        LB_10.Text = "0.00"
        LB_11.Text = "0.00"
        LB_12.Text = "0.00"
        LB_13.Text = "0.00"
        LB_14.Text = "0.00"
        LB_15.Text = "0.00"

        _FichaCompra.F_Compras.RegistroDato.M_LimpiarRegistro()

        ActivarDesactivarControles(False)
    End Sub

    Function ValidarCampos() As Boolean
        If T_2.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR UN NUMERO DE DOCUMENTO, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            T_2.Select()
            T_2.Focus()
            Return False
        End If

        If T_3.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR UN NUMERO DE CONTROL, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            T_3.Select()
            T_3.Focus()
            Return False
        End If

        If _MisTotales._TotalGeneral = 0 Then
            MessageBox.Show("EL MONTO A PAGAR DEBE SER MAYOR A CERO (0), VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            N_2.Select()
            N_2.Focus()
            Return False
        End If

        If T_5.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR UN MOTIVO, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            T_5.Select()
            T_5.Focus()
            Return False
        End If

        If F_1.r_Valor.Date < _FichaCompra.F_Compras.RegistroDato._FechaEmision.Date Then
            MessageBox.Show("DISCULPE LA FECHA NO PUEDE SER MENOR A LA FECHA DEL DOCUMENTO ORIGEN, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            F_1.Select()
            F_1.Focus()
            Return False
        End If

        Return True
    End Function

    Sub MostrarDoc()
        _FichaProveedor.F_BuscarProveedor(_FichaCompra.F_Compras.RegistroDato._AutoProveedor)

        Me.LB_1.Text = _FichaCompra.F_Compras.RegistroDato._CiRifProveedor
        Me.LB_2.Text = _FichaCompra.F_Compras.RegistroDato._CodigoProveedor
        Me.LB_3.Text = _FichaCompra.F_Compras.RegistroDato._NombreProveedor
        Me.LB_4.Text = _FichaCompra.F_Compras.RegistroDato._DirFiscalProveedor
        Me.LB_5.Text = _FichaCompra.F_Compras.RegistroDato._NumeroDocumentoCompra
        Me.LB_6.Text = _FichaCompra.F_Compras.RegistroDato._FechaEmision.ToShortDateString
        Me.N_1.Text = _FichaCompra.F_Compras.RegistroDato._MontoExento
        Me.N_2.Text = _FichaCompra.F_Compras.RegistroDato._BaseImpuestoTasa1._Base
        Me.N_3.Text = _FichaCompra.F_Compras.RegistroDato._BaseImpuestoTasa2._Base
        Me.N_4.Text = _FichaCompra.F_Compras.RegistroDato._BaseImpuestoTasa3._Base

        ActivarDesactivarControles(True)
        ActualizaImportes()
        IrInicio()
    End Sub

    Sub ActualizaImportes()
        Try
            Dim xm_1 As Decimal = 0
            Dim xm_2 As Decimal = 0
            Dim xm_3 As Decimal = 0
            Dim xm_4 As Decimal = 0

            Dim xi_1 As Decimal = 0
            Dim xi_2 As Decimal = 0
            Dim xi_3 As Decimal = 0

            Dim xt_1 As Decimal = 0
            Dim xt_2 As Decimal = 0
            Dim xt_3 As Decimal = 0

            xm_1 = N_1._Valor
            xm_2 = N_2._Valor
            xm_3 = N_3._Valor
            xm_4 = N_4._Valor

            xi_1 = xm_2 * g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_1 / 100
            xi_2 = xm_3 * g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_2 / 100
            xi_3 = xm_4 * g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_3 / 100

            xt_1 = xm_1 + xm_2 + xm_3 + xm_4
            xt_2 = xi_1 + xi_2 + xi_3
            xt_3 = xt_1 + xt_2

            xi_1 = Decimal.Round(xi_1, 2, MidpointRounding.AwayFromZero)
            xi_2 = Decimal.Round(xi_2, 2, MidpointRounding.AwayFromZero)
            xi_3 = Decimal.Round(xi_3, 2, MidpointRounding.AwayFromZero)

            xt_1 = Decimal.Round(xt_1, 2, MidpointRounding.AwayFromZero)
            xt_2 = Decimal.Round(xt_2, 2, MidpointRounding.AwayFromZero)
            xt_3 = Decimal.Round(xt_3, 2, MidpointRounding.AwayFromZero)

            _MisTotales._Exento = Decimal.Round(xm_1, 2, MidpointRounding.AwayFromZero)
            _MisTotales._Neto1 = Decimal.Round(xm_2, 2, MidpointRounding.AwayFromZero)
            _MisTotales._Neto2 = Decimal.Round(xm_3, 2, MidpointRounding.AwayFromZero)
            _MisTotales._Neto3 = Decimal.Round(xm_4, 2, MidpointRounding.AwayFromZero)


            LB_10.Text = String.Format("{0:#0.00}", xi_1)
            LB_11.Text = String.Format("{0:#0.00}", xi_2)
            LB_12.Text = String.Format("{0:#0.00}", xi_3)

            LB_13.Text = String.Format("{0:#0.00}", xt_1)
            LB_14.Text = String.Format("{0:#0.00}", xt_2)
            LB_15.Text = String.Format("{0:#0.00}", xt_3)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Class c_ProcesarDescuento_Compras
    Implements IProcesarGastos_NC
    Event _DocumentoProcesado()

    'MIS CONTROLES
    WithEvents T_1 As MisTextos
    WithEvents T_2 As MisTextos
    WithEvents T_3 As MisTextos
    WithEvents T_5 As MisTextos
    WithEvents N_1 As MisNumeros
    WithEvents N_2 As MisNumeros
    WithEvents N_3 As MisNumeros
    WithEvents N_4 As MisNumeros
    WithEvents F_1 As MisFechas
    WithEvents LB_1 As Label
    WithEvents LB_2 As Label
    WithEvents LB_3 As Label
    WithEvents LB_4 As Label
    WithEvents LB_5 As Label
    WithEvents LB_6 As Label
    WithEvents LB_7 As Label
    WithEvents LB_8 As Label
    WithEvents LB_9 As Label
    WithEvents LB_10 As Label
    WithEvents LB_11 As Label
    WithEvents LB_12 As Label
    WithEvents LB_13 As Label
    WithEvents LB_14 As Label
    WithEvents LB_15 As Label
    WithEvents LLB_2 As LinkLabel
    WithEvents BT_1 As Button
    WithEvents _MiFormulario As Form
    WithEvents xToolTip As New System.Windows.Forms.ToolTip()

    Dim xpro As FichaProveedores
    Dim xficha_compra As FichaCompras
    Dim xtotales As TotalesDoc
    Dim xautodoccompra As String
    Dim xestatussalida As Boolean

    Sub New(ByVal xautocompra As String)
        _FichaCompra = New FichaCompras
        _FichaProveedor = New FichaProveedores
        Me._MisTotales = New TotalesDoc
        Me._EstatusSalida = True

        Me._AutoDocCompraCargar = xautocompra
    End Sub

    Property _EstatusSalida() As Boolean
        Get
            Return xestatussalida
        End Get
        Set(ByVal value As Boolean)
            xestatussalida = value
        End Set
    End Property

    Property _AutoDocCompraCargar() As String
        Get
            Return xautodoccompra
        End Get
        Set(ByVal value As String)
            xautodoccompra = value
        End Set
    End Property

    Property _FichaProveedor() As FichaProveedores
        Get
            Return xpro
        End Get
        Set(ByVal value As FichaProveedores)
            xpro = value
        End Set
    End Property

    Property _FichaCompra() As FichaCompras
        Get
            Return xficha_compra
        End Get
        Set(ByVal value As FichaCompras)
            xficha_compra = value
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

    Public Sub Inicializar(ByVal xform As Object) Implements IProcesarGastos_NC.Inicializar
        Try
            _MiFormulario = CType(xform, Form)

            T_1 = _MiFormulario.Controls.Find("MT_1", True)(0)
            T_2 = _MiFormulario.Controls.Find("MT_2", True)(0)
            T_3 = _MiFormulario.Controls.Find("MT_3", True)(0)
            T_5 = _MiFormulario.Controls.Find("MT_5", True)(0)
            N_1 = _MiFormulario.Controls.Find("MN_1", True)(0)
            N_2 = _MiFormulario.Controls.Find("MN_2", True)(0)
            N_3 = _MiFormulario.Controls.Find("MN_3", True)(0)
            N_4 = _MiFormulario.Controls.Find("MN_4", True)(0)
            F_1 = _MiFormulario.Controls.Find("MF_1", True)(0)
            LB_1 = _MiFormulario.Controls.Find("E_1", True)(0)
            LB_2 = _MiFormulario.Controls.Find("E_2", True)(0)
            LB_3 = _MiFormulario.Controls.Find("E_3", True)(0)
            LB_4 = _MiFormulario.Controls.Find("E_4", True)(0)
            LB_5 = _MiFormulario.Controls.Find("E_5", True)(0)
            LB_6 = _MiFormulario.Controls.Find("E_6", True)(0)
            LB_7 = _MiFormulario.Controls.Find("E_7", True)(0)
            LB_8 = _MiFormulario.Controls.Find("E_8", True)(0)
            LB_9 = _MiFormulario.Controls.Find("E_9", True)(0)
            LB_10 = _MiFormulario.Controls.Find("E_10", True)(0)
            LB_11 = _MiFormulario.Controls.Find("E_11", True)(0)
            LB_12 = _MiFormulario.Controls.Find("E_12", True)(0)
            LB_13 = _MiFormulario.Controls.Find("E_13", True)(0)
            LB_14 = _MiFormulario.Controls.Find("E_14", True)(0)
            LB_15 = _MiFormulario.Controls.Find("E_15", True)(0)
            LLB_2 = _MiFormulario.Controls.Find("LLB_2", True)(0)
            BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            xToolTip.SetToolTip(LLB_2, "Ir A Ficha Proveedores")
            InicializarControles()

            _FichaCompra.F_Compras.F_CargarCompra(Me._AutoDocCompraCargar)
            If _FichaCompra.F_Compras.RegistroDato._TipoCompraRegistrada = TipoCompraRegistrada.CompraMercancia Then
                MostrarDoc()
            Else
                Me._EstatusSalida = False
                Throw New Exception("LA NOTA DE CREDITO PARA ESTE DOCUMENTO NO PUEDE SER PROCESADA POR ESTE MODULO. VERIFIQUE")
            End If
        Catch ex As Exception
            Me._EstatusSalida = False
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub InicializarControles()
        With T_1
            .Enabled = False
            .Text = ""
            .MaxLength = 10
        End With

        With T_2
            .Enabled = False
            .Text = ""
            .MaxLength = 15
        End With

        With T_3
            .Enabled = False
            .Text = ""
            .MaxLength = 10
        End With

        With T_5
            .Enabled = False
            .Text = ""
            .MaxLength = 120
        End With

        With N_1
            .Enabled = False
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
        End With

        With N_2
            .Enabled = False
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
        End With

        With N_3
            .Enabled = False
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
        End With

        With N_4
            .Enabled = False
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
        End With

        LB_1.Text = ""
        LB_2.Text = ""
        LB_3.Text = ""
        LB_4.Text = ""
        LB_5.Text = ""
        LB_6.Text = ""
        LB_7.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_1)
        LB_8.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_2)
        LB_9.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_3)

        _MisTotales._TasaIva1 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_1
        _MisTotales._TasaIva2 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_2
        _MisTotales._TasaIva3 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_3

        LB_10.Text = "0.00"
        LB_11.Text = "0.00"
        LB_12.Text = "0.00"
        LB_13.Text = "0.00"
        LB_14.Text = "0.00"
        LB_15.Text = "0.00"

        BT_1.Enabled = False
        F_1.Enabled = False

        IrInicio()
    End Sub

    Private Sub _MiFormulario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles _MiFormulario.FormClosing
        If _EstatusSalida Then
            If MessageBox.Show("¿Esta Seguro De Salir De La Plantilla?", "*** Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Sub IrInicio()
        T_1.Select()
        T_1.Focus()
    End Sub

    Private Sub _MiFormulario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _MiFormulario.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            _MiFormulario.Close()
        End If
    End Sub

    Private Sub LLB_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LLB_2.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor.F_Permitir()

            Dim xficha As New FichaProveedor(Me._FichaProveedor.f_Proveedor.RegistroDato._Automatico)
            With xficha
                .Show()
            End With
            IrInicio()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub F_1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_1.ValueChanged
        If F_1.r_Valor.Date > g_MiData.p_FechaDelMotorBD.Date Then
            F_1.Value = g_MiData.p_FechaDelMotorBD
        End If
    End Sub

    Private Sub ActualizarImportes(ByVal sender As Object, ByVal e As System.EventArgs) Handles N_1.LostFocus, N_2.LostFocus, N_3.LostFocus, N_4.LostFocus
        ActualizaImportes()
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            If ValidarCampos() Then
                If MessageBox.Show("¿Esta Seguro De Registrar Este Documento?", "*** Mensaje ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If Procesar() Then
                        Me._EstatusSalida = False
                        Me._MiFormulario.Close()
                        'LimpiarControles()
                    End If
                Else
                    T_1.Select()
                    T_1.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function Procesar() As Boolean
        Dim xcompra_encabezado As New FichaCompras.c_Compra.AgregarCompra
        Dim xcompras As New FichaCompras
        Try
            With xcompra_encabezado
                ._CantidadRenglones = 0
                ._DiasCreditoOtorgado = 0
                ._FactorCambio = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaDivisaActual.c_Valor
                ._FechaEmision = F_1.r_Valor
                ._FechaProceso = g_MiData.p_FechaDelMotorBD
                ._Hora = g_MiData.p_HoraDelMotorBD
                ._MontoBase_1 = _MisTotales._Neto1
                ._MontoBase_2 = _MisTotales._Neto2
                ._MontoBase_3 = _MisTotales._Neto3
                ._MontoExento = _MisTotales._Exento
                ._MontoSubtotal = _MisTotales._Subtotal
                ._NombreEstacionEquipo = g_EquipoEstacion.p_EstacionNombre
                ._NotasDocumento = T_5.r_Valor
                ._NumeroControl = T_3.r_Valor
                ._NumeroDocumento = T_2.r_Valor
                ._OrdenCompraNumero = ""
                ._Proveedor = Me._FichaProveedor.f_Proveedor.RegistroDato
                ._SerieDocumento = T_1.r_Valor
                ._TasaCargos = 0
                ._TasaDescuento_1 = 0
                ._TasaDescuento_2 = 0
                ._TasaIva_1 = _MisTotales._TasaIva1
                ._TasaIva_2 = _MisTotales._TasaIva2
                ._TasaIva_3 = _MisTotales._TasaIva3
                ._TipoDocumento = TipoDocumentoCompra.NotaCredito
                ._Usuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
            End With

            Dim xgrabar As New FichaCompras.GrabarGasto_NC
            xgrabar._Compra_NC = xcompra_encabezado
            xgrabar._FichaCompraOrigen = _FichaCompra.F_Compras.RegistroDato

            AddHandler xcompras.FacturaExitosa, AddressOf VisualizarReporte
            xcompras.F_GrabarGasto_NC(xgrabar)
            RaiseEvent _DocumentoProcesado()

            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub VisualizarReporte(ByVal xauto As String)
        MessageBox.Show("EL DOCUMENTO DE NOTA DE CRÉDITO SE REGISTRO CORRECTAMENTE!!!", "*Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
        VisualizarDoc_Gastos(xauto)
    End Sub

    Sub ActivarDesactivarControles(ByVal op As Boolean)
        Me.T_1.Enabled = op
        Me.T_2.Enabled = op
        Me.T_3.Enabled = op
        Me.T_5.Enabled = op
        Me.N_1.Enabled = op
        Me.N_2.Enabled = op
        Me.N_3.Enabled = op
        Me.N_4.Enabled = op
        Me.BT_1.Enabled = op
        Me.F_1.Enabled = op
    End Sub

    Sub LimpiarControles()
        T_1.Text = ""
        T_2.Text = ""
        T_3.Text = ""
        T_5.Text = ""

        N_1.Text = "0.00"
        N_2.Text = "0.00"
        N_3.Text = "0.00"
        N_4.Text = "0.00"

        LB_1.Text = ""
        LB_2.Text = ""
        LB_3.Text = ""
        LB_4.Text = ""

        LB_5.Text = ""
        LB_6.Text = ""

        LB_7.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_1)
        LB_8.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_2)
        LB_9.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_3)

        _MisTotales._Exento = 0
        _MisTotales._Neto1 = 0
        _MisTotales._Neto2 = 0
        _MisTotales._Neto3 = 0
        _MisTotales._TasaIva1 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_1
        _MisTotales._TasaIva2 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_2
        _MisTotales._TasaIva3 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_3

        LB_10.Text = "0.00"
        LB_11.Text = "0.00"
        LB_12.Text = "0.00"
        LB_13.Text = "0.00"
        LB_14.Text = "0.00"
        LB_15.Text = "0.00"

        _FichaCompra.F_Compras.RegistroDato.M_LimpiarRegistro()

        ActivarDesactivarControles(False)
    End Sub

    Function ValidarCampos() As Boolean
        If T_2.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR UN NUMERO DE DOCUMENTO, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            T_2.Select()
            T_2.Focus()
            Return False
        End If

        If T_3.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR UN NUMERO DE CONTROL, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            T_3.Select()
            T_3.Focus()
            Return False
        End If

        If _MisTotales._TotalGeneral = 0 Then
            MessageBox.Show("EL MONTO A PAGAR DEBE SER MAYOR A CERO (0), VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            N_2.Select()
            N_2.Focus()
            Return False
        End If

        If T_5.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR UN MOTIVO, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            T_5.Select()
            T_5.Focus()
            Return False
        End If

        If F_1.r_Valor.Date < _FichaCompra.F_Compras.RegistroDato._FechaEmision.Date Then
            MessageBox.Show("DISCULPE LA FECHA NO PUEDE SER MENOR A LA FECHA DEL DOCUMENTO ORIGEN, VERIFIQUE", "*** Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            F_1.Select()
            F_1.Focus()
            Return False
        End If

        Return True
    End Function

    Sub MostrarDoc()
        _FichaProveedor.F_BuscarProveedor(_FichaCompra.F_Compras.RegistroDato._AutoProveedor)

        Me.LB_1.Text = _FichaCompra.F_Compras.RegistroDato._CiRifProveedor
        Me.LB_2.Text = _FichaCompra.F_Compras.RegistroDato._CodigoProveedor
        Me.LB_3.Text = _FichaCompra.F_Compras.RegistroDato._NombreProveedor
        Me.LB_4.Text = _FichaCompra.F_Compras.RegistroDato._DirFiscalProveedor
        Me.LB_5.Text = _FichaCompra.F_Compras.RegistroDato._NumeroDocumentoCompra
        Me.LB_6.Text = _FichaCompra.F_Compras.RegistroDato._FechaEmision.ToShortDateString
        Me.N_1.Text = _FichaCompra.F_Compras.RegistroDato._MontoExento
        Me.N_2.Text = _FichaCompra.F_Compras.RegistroDato._BaseImpuestoTasa1._Base
        Me.N_3.Text = _FichaCompra.F_Compras.RegistroDato._BaseImpuestoTasa2._Base
        Me.N_4.Text = _FichaCompra.F_Compras.RegistroDato._BaseImpuestoTasa3._Base

        ActivarDesactivarControles(True)
        ActualizaImportes()
        IrInicio()
    End Sub

    Sub ActualizaImportes()
        Try
            Dim xm_1 As Decimal = 0
            Dim xm_2 As Decimal = 0
            Dim xm_3 As Decimal = 0
            Dim xm_4 As Decimal = 0

            Dim xi_1 As Decimal = 0
            Dim xi_2 As Decimal = 0
            Dim xi_3 As Decimal = 0

            Dim xt_1 As Decimal = 0
            Dim xt_2 As Decimal = 0
            Dim xt_3 As Decimal = 0

            xm_1 = N_1._Valor
            xm_2 = N_2._Valor
            xm_3 = N_3._Valor
            xm_4 = N_4._Valor

            xi_1 = xm_2 * g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_1 / 100
            xi_2 = xm_3 * g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_2 / 100
            xi_3 = xm_4 * g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.r_TasaIva_3 / 100

            xt_1 = xm_1 + xm_2 + xm_3 + xm_4
            xt_2 = xi_1 + xi_2 + xi_3
            xt_3 = xt_1 + xt_2

            xi_1 = Decimal.Round(xi_1, 2, MidpointRounding.AwayFromZero)
            xi_2 = Decimal.Round(xi_2, 2, MidpointRounding.AwayFromZero)
            xi_3 = Decimal.Round(xi_3, 2, MidpointRounding.AwayFromZero)

            xt_1 = Decimal.Round(xt_1, 2, MidpointRounding.AwayFromZero)
            xt_2 = Decimal.Round(xt_2, 2, MidpointRounding.AwayFromZero)
            xt_3 = Decimal.Round(xt_3, 2, MidpointRounding.AwayFromZero)

            _MisTotales._Exento = Decimal.Round(xm_1, 2, MidpointRounding.AwayFromZero)
            _MisTotales._Neto1 = Decimal.Round(xm_2, 2, MidpointRounding.AwayFromZero)
            _MisTotales._Neto2 = Decimal.Round(xm_3, 2, MidpointRounding.AwayFromZero)
            _MisTotales._Neto3 = Decimal.Round(xm_4, 2, MidpointRounding.AwayFromZero)


            LB_10.Text = String.Format("{0:#0.00}", xi_1)
            LB_11.Text = String.Format("{0:#0.00}", xi_2)
            LB_12.Text = String.Format("{0:#0.00}", xi_3)

            LB_13.Text = String.Format("{0:#0.00}", xt_1)
            LB_14.Text = String.Format("{0:#0.00}", xt_2)
            LB_15.Text = String.Format("{0:#0.00}", xt_3)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

