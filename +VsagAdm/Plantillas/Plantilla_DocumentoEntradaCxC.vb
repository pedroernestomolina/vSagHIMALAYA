Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plantilla_DocumentoEntradaCxC
    Dim _Plantilla As IControlNotaDebitoCredito

    Sub New(ByVal xplantilla As IControlNotaDebitoCredito)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Private Sub Plantilla_DocumentoEntradaCxC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_DocumentoEntradaCxC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            _Plantilla.F_Inicializar(Me)
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR FORMULARIO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub Plantilla_DocumentoEntradaCxC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IControlNotaDebitoCredito
    Sub F_Inicializar(ByVal xficha As Object)
End Interface


''
''  CUENTAS POR COBRAR
''

Public Class c_ControlNotaDebitoVentas
    Implements IControlNotaDebitoCredito
    Event _DocumentoProcesado()

    'CONTROLES
    WithEvents Formulario As System.Windows.Forms.Form
    WithEvents BT_GUARDAR As System.Windows.Forms.Button

    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_TITULO_1 As System.Windows.Forms.Label
    Dim LB_APLICA As System.Windows.Forms.Label
    Dim LB_RESTA As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_FECHA_DOCUMENTO As System.Windows.Forms.Label
    Dim LB_RIF As System.Windows.Forms.Label
    Dim MT_DETALLE As MisTextos
    Dim MN_MONTO As MisNumeros

    Private xsentencia As String = ""
    Dim xcliente As FichaClientes
    Dim xcxc As New FichaCtasCobrar.c_CxC
    Dim xsalida As Boolean

    Sub New(ByVal xcliente As FichaClientes, ByVal xrow As DataRow)
        _FichaCliente = xcliente
        _FichaCxC = New FichaCtasCobrar.c_CxC
        _FichaCxC.M_CargarRegistro(xrow)
        _SalidaOk = False
    End Sub

    Property _SalidaOk() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return Me.Formulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            Me.Formulario = value
        End Set
    End Property

    Property _FichaCliente() As FichaClientes
        Get
            Return Me.xcliente
        End Get
        Set(ByVal value As FichaClientes)
            Me.xcliente = value
        End Set
    End Property

    Property _FichaCxC() As FichaCtasCobrar.c_CxC
        Get
            Return Me.xCxC
        End Get
        Set(ByVal value As FichaCtasCobrar.c_CxC)
            Me.xCxC = value
        End Set
    End Property

    Public Sub F_Inicializar(ByVal xficha As Object) Implements IControlNotaDebitoCredito.F_Inicializar
        _MiFormulario = xficha
        LB_TITULO = _MiFormulario.Controls.Find("TITULO", True)(0)
        LB_TITULO_1 = _MiFormulario.Controls.Find("TITULO_1", True)(0)
        LB_APLICA = _MiFormulario.Controls.Find("LB_APLICA", True)(0)
        LB_RESTA = _MiFormulario.Controls.Find("LB_RESTA", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
        LB_FECHA_DOCUMENTO = _MiFormulario.Controls.Find("LB_FECHA_DOCUMENTO", True)(0)
        LB_RIF = _MiFormulario.Controls.Find("LB_RIF", True)(0)
        MT_DETALLE = _MiFormulario.Controls.Find("MT_DETALLE", True)(0)
        MN_MONTO = _MiFormulario.Controls.Find("MN_MONTO", True)(0)
        BT_GUARDAR = _MiFormulario.Controls.Find("BT_GUARDAR", True)(0)

        _MiFormulario.Text = "Control De Notas De Débito"
        LB_TITULO.Text = "Nota De Débito"
        LB_TITULO_1.Text = "Nueva Nota De Débito"
        LB_FECHA.Text = g_MiData.p_FechaDelMotorBD.ToShortDateString
        MT_DETALLE.Text = ""
        With MN_MONTO
            ._Formato = "9999999999.99"
            ._ConSigno = False
            .Text = "0.00"
            .Select()
            .Focus()
        End With

        LB_RIF.Text = _FichaCliente.f_Clientes.RegistroDato.r_CiRif
        LB_FECHA_DOCUMENTO.Text = _FichaCxC.RegistroDato._FechaEmision.ToShortDateString
        LB_APLICA.Text = _FichaCxC.RegistroDato._NumeroDocumento
        LB_RESTA.Text = _FichaCxC.RegistroDato._MontoPorCobrar
        LB_NOMBRE.Text = _FichaCliente.f_Clientes.RegistroDato.r_NombreRazonSocial
    End Sub

    Function ValidarCampos() As Boolean
        If MN_MONTO._Valor = 0 Then
            MessageBox.Show("DEBE REGISTRAR UN MONTO MAYOR A CERO (0), POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_MONTO.SelectAll()
            MN_MONTO.Focus()
            Return False
        End If

        If MT_DETALLE.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR EL DETALLE DEL DOCUMENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DETALLE.Select()
            MT_DETALLE.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub Formulario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Formulario.FormClosing
        If _SalidaOk Then
            e.Cancel = False
        Else
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Salir?, Se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        If ValidarCampos() Then
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro Grabar Este Registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xficha As New FichaCtasCobrar
                    Dim xagregarnd As New FichaCtasCobrar.c_CxC.c_AgregarNotaDebito

                    With xagregarnd
                        ._FechaProceso = g_MiData.p_FechaDelMotorBD
                        ._FichaCliente = _FichaCliente.f_Clientes.RegistroDato
                        ._Monto = Me.MN_MONTO._Valor
                        ._NotasDetalle = Me.MT_DETALLE.r_Valor
                        ._NumeroDocumentoAplica = _FichaCxC.RegistroDato._NumeroDocumento
                    End With
                    xficha.F_GrabarNotaDebito(xagregarnd)

                    RaiseEvent _DocumentoProcesado()
                    MessageBox.Show("DOCUMENTO REGISTRADO EXITOSAMENTE... OK", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _SalidaOk = True
                    _MiFormulario.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub
End Class

Public Class c_DocumentoNotaCreditoVentas
    Implements IControlNotaDebitoCredito
    Event _DocumentoProcesado()

    'CONTROLES
    WithEvents Formulario As System.Windows.Forms.Form
    WithEvents BT_GUARDAR As System.Windows.Forms.Button

    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_TITULO_1 As System.Windows.Forms.Label
    Dim LB_APLICA As System.Windows.Forms.Label
    Dim LB_RESTA As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_FECHA_DOCUMENTO As System.Windows.Forms.Label
    Dim LB_RIF As System.Windows.Forms.Label
    Dim label5 As System.Windows.Forms.Label
    Dim MT_DETALLE As MisTextos
    Dim MN_MONTO As MisNumeros

    Private xsentencia As String = ""
    Dim xcliente As FichaClientes
    Dim xcxc As New FichaCtasCobrar.c_CxC
    Dim xsalida As Boolean

    Sub New(ByVal xcliente As FichaClientes, ByVal xrow As DataRow)
        _FichaCliente = xcliente
        _FichaCxC = New FichaCtasCobrar.c_CxC
        _FichaCxC.M_CargarRegistro(xrow)
        _SalidaOk = False
    End Sub

    Property _SalidaOk() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return Me.Formulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            Me.Formulario = value
        End Set
    End Property

    Property _FichaCliente() As FichaClientes
        Get
            Return Me.xcliente
        End Get
        Set(ByVal value As FichaClientes)
            Me.xcliente = value
        End Set
    End Property

    Property _FichaCxC() As FichaCtasCobrar.c_CxC
        Get
            Return Me.xcxc
        End Get
        Set(ByVal value As FichaCtasCobrar.c_CxC)
            Me.xcxc = value
        End Set
    End Property

    Public Sub F_Inicializar(ByVal xficha As Object) Implements IControlNotaDebitoCredito.F_Inicializar
        _MiFormulario = xficha
        LB_TITULO = _MiFormulario.Controls.Find("TITULO", True)(0)
        LB_TITULO_1 = _MiFormulario.Controls.Find("TITULO_1", True)(0)
        LB_APLICA = _MiFormulario.Controls.Find("LB_APLICA", True)(0)
        LB_RESTA = _MiFormulario.Controls.Find("LB_RESTA", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
        LB_FECHA_DOCUMENTO = _MiFormulario.Controls.Find("LB_FECHA_DOCUMENTO", True)(0)
        LB_RIF = _MiFormulario.Controls.Find("LB_RIF", True)(0)
        MT_DETALLE = _MiFormulario.Controls.Find("MT_DETALLE", True)(0)
        MN_MONTO = _MiFormulario.Controls.Find("MN_MONTO", True)(0)
        BT_GUARDAR = _MiFormulario.Controls.Find("BT_GUARDAR", True)(0)
        label5 = _MiFormulario.Controls.Find("label5", True)(0)

        _MiFormulario.Text = "Control De Notas De Crédito"
        LB_TITULO.Text = "Nota De Crédito"
        LB_TITULO_1.Text = "Nueva Nota De Crédito"
        label5.Text = "Monto Importe:"
        LB_FECHA.Text = g_MiData.p_FechaDelMotorBD.ToShortDateString
        MT_DETALLE.Text = ""

        With MN_MONTO
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
            .Select()
            .Focus()
        End With

        LB_RIF.Text = _FichaCliente.f_Clientes.RegistroDato.r_CiRif
        LB_FECHA_DOCUMENTO.Text = _FichaCxC.RegistroDato._FechaEmision.ToShortDateString
        LB_APLICA.Text = _FichaCxC.RegistroDato._NumeroDocumento
        LB_RESTA.Text = _FichaCxC.RegistroDato._MontoImporte
        LB_NOMBRE.Text = _FichaCliente.f_Clientes.RegistroDato.r_NombreRazonSocial
    End Sub

    Function ValidarCampos() As Boolean
        If MN_MONTO._Valor = 0 Then
            MessageBox.Show("DEBE REGISTRAR UN MONTO MAYOR A CERO (0), POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_MONTO.SelectAll()
            MN_MONTO.Focus()
            Return False
        End If

        If MN_MONTO._Valor > _FichaCxC.RegistroDato._MontoImporte Then
            MessageBox.Show("MONTO A REGSITRAR DEBE SER MENOR O IGUAL AL MONTO IMPORTE DEL DOCUMENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_MONTO.SelectAll()
            MN_MONTO.Focus()
            Return False
        End If

        If MT_DETALLE.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR EL DETALLE DEL DOCUMENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DETALLE.Select()
            MT_DETALLE.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub Formulario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Formulario.FormClosing
        If _SalidaOk Then
            e.Cancel = False
        Else
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Salir?, Se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        If ValidarCampos() Then
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro Grabar Este Registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xficha As New FichaCtasCobrar
                    Dim xagregar As New FichaCtasCobrar.c_CxC.c_AgregarDocumentoCxC

                    With xagregar
                        ._DiasCredito = 0
                        ._FechaEmision = g_MiData.p_FechaDelMotorBD
                        ._FechaProceso = g_MiData.p_FechaDelMotorBD
                        ._FichaCliente = _FichaCliente.f_Clientes.RegistroDato
                        ._Importe = MN_MONTO._Valor
                        ._NotasDetalle = MT_DETALLE.r_Valor
                        ._NumeroDocumento = _FichaCxC.RegistroDato._NumeroDocumento
                        ._SaldoPendiente = MN_MONTO._Valor
                        ._TipoDocumentoProcesar = TipoDocumentoMovEntradaCxC.NotaCreditoGeneradaPorSistema
                    End With
                    xficha.F_GrabarMovimientoEntrada(xagregar)
                    RaiseEvent _DocumentoProcesado()
                    MessageBox.Show("DOCUMENTO REGISTRADO EXITOSAMENTE... OK", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _SalidaOk = True
                    _MiFormulario.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub
End Class

Public Class c_ModoPagoNotaCreditoVentas
    Implements IControlNotaDebitoCredito
    Event _DocumentoProcesado()

    'CONTROLES
    WithEvents Formulario As System.Windows.Forms.Form
    WithEvents BT_GUARDAR As System.Windows.Forms.Button

    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_TITULO_1 As System.Windows.Forms.Label
    Dim LB_APLICA As System.Windows.Forms.Label
    Dim LB_RESTA As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_FECHA_DOCUMENTO As System.Windows.Forms.Label
    Dim LB_RIF As System.Windows.Forms.Label
    Dim label5 As System.Windows.Forms.Label
    Dim MT_DETALLE As MisTextos
    Dim MN_MONTO As MisNumeros

    Private xsentencia As String = ""
    Dim xcliente As FichaClientes
    Dim xcxc As New FichaCtasCobrar.c_CxC
    Dim xsalida As Boolean

    Sub New(ByVal xcliente As FichaClientes, ByVal xrow As DataRow)
        _FichaCliente = xcliente
        _FichaCxC = New FichaCtasCobrar.c_CxC
        _FichaCxC.M_CargarRegistro(xrow)
        _SalidaOk = False
    End Sub

    Property _SalidaOk() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return Me.Formulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            Me.Formulario = value
        End Set
    End Property

    Property _FichaCliente() As FichaClientes
        Get
            Return Me.xcliente
        End Get
        Set(ByVal value As FichaClientes)
            Me.xcliente = value
        End Set
    End Property

    Property _FichaCxC() As FichaCtasCobrar.c_CxC
        Get
            Return Me.xcxc
        End Get
        Set(ByVal value As FichaCtasCobrar.c_CxC)
            Me.xcxc = value
        End Set
    End Property

    Public Sub F_Inicializar(ByVal xficha As Object) Implements IControlNotaDebitoCredito.F_Inicializar
        _MiFormulario = xficha
        LB_TITULO = _MiFormulario.Controls.Find("TITULO", True)(0)
        LB_TITULO_1 = _MiFormulario.Controls.Find("TITULO_1", True)(0)
        LB_APLICA = _MiFormulario.Controls.Find("LB_APLICA", True)(0)
        LB_RESTA = _MiFormulario.Controls.Find("LB_RESTA", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
        LB_FECHA_DOCUMENTO = _MiFormulario.Controls.Find("LB_FECHA_DOCUMENTO", True)(0)
        LB_RIF = _MiFormulario.Controls.Find("LB_RIF", True)(0)
        MT_DETALLE = _MiFormulario.Controls.Find("MT_DETALLE", True)(0)
        MN_MONTO = _MiFormulario.Controls.Find("MN_MONTO", True)(0)
        BT_GUARDAR = _MiFormulario.Controls.Find("BT_GUARDAR", True)(0)

        _MiFormulario.Text = "Control De Notas De Crédito"
        LB_TITULO.Text = "Nota De Crédito"
        LB_TITULO_1.Text = "Nueva Nota De Crédito"
        LB_FECHA.Text = g_MiData.p_FechaDelMotorBD.ToShortDateString
        MT_DETALLE.Text = ""

        With MN_MONTO
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
            .Select()
            .Focus()
        End With

        LB_RIF.Text = _FichaCliente.f_Clientes.RegistroDato.r_CiRif
        LB_FECHA_DOCUMENTO.Text = _FichaCxC.RegistroDato._FechaEmision.ToShortDateString
        LB_APLICA.Text = _FichaCxC.RegistroDato._NumeroDocumento
        LB_RESTA.Text = _FichaCxC.RegistroDato._MontoPorCobrar
        LB_NOMBRE.Text = _FichaCliente.f_Clientes.RegistroDato.r_NombreRazonSocial
    End Sub

    Function ValidarCampos() As Boolean
        If MN_MONTO._Valor = 0 Then
            MessageBox.Show("DEBE REGISTRAR UN MONTO MAYOR A CERO (0), POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_MONTO.SelectAll()
            MN_MONTO.Focus()
            Return False
        End If

        If MN_MONTO._Valor > _FichaCxC.RegistroDato._MontoPorCobrar Then
            MessageBox.Show("MONTO A REGSITRAR DEBE SER MENOR O IGUAL AL MONTO PENDIENTE POR COBRAR DEL DOCUMENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_MONTO.SelectAll()
            MN_MONTO.Focus()
            Return False
        End If

        If MT_DETALLE.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR EL DETALLE DEL DOCUMENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DETALLE.Select()
            MT_DETALLE.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub Formulario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Formulario.FormClosing
        If _SalidaOk Then
            e.Cancel = False
        Else
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Salir?, Se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        If ValidarCampos() Then
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro Grabar Este Registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xficha As New FichaCtasCobrar
                    Dim xpagonc As New FichaCtasCobrar.c_CxC.c_AgregarPagoNotaCredito
                    Dim xcobrador As New FichaCobradores
                    xcobrador.F_BuscarCobrador(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloClientes._AutoCobrador_ARegistrar_PorDefecto)

                    With xpagonc
                        ._FechaEmision = g_MiData.p_FechaDelMotorBD
                        ._FichaCliente = _FichaCliente.f_Clientes.RegistroDato
                        ._FichaCobrador = xcobrador.f_Cobrador.RegistroDato
                        ._FichaCxC = _FichaCxC.RegistroDato
                        ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                        ._MontoImporte = Me.MN_MONTO._Valor
                        ._NotasDetalle = Me.MT_DETALLE.r_Valor
                    End With
                    AddHandler xficha.RetornarAutoRecibo, AddressOf ImprimirRecibo
                    'xficha.F_GrabarNotaCreditoPago(xpagonc)

                    RaiseEvent _DocumentoProcesado()
                    MessageBox.Show("DOCUMENTO REGISTRADO EXITOSAMENTE... OK", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _SalidaOk = True
                    _MiFormulario.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Sub ImprimirRecibo(ByVal xauto As String)
        Dim dts As New DataSet
        Dim dtb_empresa As New DataTable("empresa")
        Dim dtb_cxc_recibo As New DataTable("recibo")
        Dim dtb_cxc_documentos As New DataTable("documentos")
        Dim dtb_cxc_modos_pagos As New DataTable("cxc_modo_pago")
        Dim xparam As SqlParameter
        Try
            g_MiData.F_GetData(SELECT_DATAEMPRESA, dtb_empresa)
            dts.Tables.Add(dtb_empresa)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(SELECT_DATARECIBO, dtb_cxc_recibo, xparam)
            dts.Tables.Add(dtb_cxc_recibo)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(SELECT_DATADOCUMENTOS, dtb_cxc_documentos, xparam)
            dts.Tables.Add(dtb_cxc_documentos)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(SELECT_DATAMODOSPAGOS, dtb_cxc_modos_pagos, xparam)
            dts.Tables.Add(dtb_cxc_modos_pagos)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "rep_cxc_recibo.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR RECIBO DE PAGO" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "FUNCIONES SELECT"
    Protected Friend Const SELECT_DATAEMPRESA As String = "select nombre" & _
                                                                ", rif" & _
                                                                ", direccion" & _
                                                                ", telefono_1 telefono" & _
                                                                ", sucursal" & _
                                                                ", codigo_sucursal " & _
                                                          "from empresa"

    Protected Friend Const SELECT_DATARECIBO As String = "SELECT numero" & _
                                                                ", fecha" & _
                                                                ", cobrador" & _
                                                                ", nombre_cliente cliente" & _
                                                                ", ci_rif_cliente" & _
                                                                ", codigo_cliente" & _
                                                                ", direccion dir_fiscal_cliente" & _
                                                                ", telefono telefono_cliente" & _
                                                                ", detalle" & _
                                                                ", importe" & _
                                                                ", estatus " & _
                                                         "FROM cxc_recibos " & _
                                                         "WHERE auto=@auto"

    Protected Friend Const SELECT_DATADOCUMENTOS As String = "SELECT origen" & _
                                                                ", documento" & _
                                                                ", monto" & _
                                                                ", monto_pendiente saldopendiente_antes_del_pago " & _
                                                         "FROM cxc_documentos WHERE auto_cxc_recibo=@auto"

    Protected Friend Const SELECT_DATAMODOSPAGOS As String = "SELECT nombre" & _
                                                                ", monto_recibido " & _
                                                                ", importe " & _
                                                         "FROM cxc_modo_pago " & _
                                                         "WHERE auto_recibo=@auto"
#End Region

End Class



''
''  CUENTAS POR PAGAR
''

Public Class c_ControlNotaDebitoCompras
    Implements IControlNotaDebitoCredito
    Event _DocumentoProcesado()

    'CONTROLES
    WithEvents Formulario As System.Windows.Forms.Form
    WithEvents BT_GUARDAR As System.Windows.Forms.Button
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_TITULO_1 As System.Windows.Forms.Label
    Dim LB_APLICA As System.Windows.Forms.Label
    Dim LB_RESTA As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_FECHA_DOCUMENTO As System.Windows.Forms.Label
    Dim LB_RIF As System.Windows.Forms.Label
    Dim MT_DETALLE As MisTextos
    Dim MN_MONTO As MisNumeros

    Private xsentencia As String = ""
    Dim xproveedor As FichaProveedores
    Dim xcxp As New FichaCtasPagar.c_CxP
    Dim xsalida As Boolean

    Sub New(ByVal xpro As FichaProveedores, ByVal xrow As DataRow)
        _FichaProveedor = xpro
        _FichaCxP = New FichaCtasPagar.c_CxP
        _FichaCxP.M_CargarRegistro(xrow)
        _SalidaOk = False
    End Sub

    Property _SalidaOk() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return Me.Formulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            Me.Formulario = value
        End Set
    End Property

    Property _FichaProveedor() As FichaProveedores
        Get
            Return Me.xproveedor
        End Get
        Set(ByVal value As FichaProveedores)
            Me.xproveedor = value
        End Set
    End Property

    Property _FichaCxP() As FichaCtasPagar.c_CxP
        Get
            Return Me.xcxp
        End Get
        Set(ByVal value As FichaCtasPagar.c_CxP)
            Me.xcxp = value
        End Set
    End Property

    Public Sub F_Inicializar(ByVal xficha As Object) Implements IControlNotaDebitoCredito.F_Inicializar
        _MiFormulario = xficha
        LB_TITULO = _MiFormulario.Controls.Find("TITULO", True)(0)
        LB_TITULO_1 = _MiFormulario.Controls.Find("TITULO_1", True)(0)
        LB_APLICA = _MiFormulario.Controls.Find("LB_APLICA", True)(0)
        LB_RESTA = _MiFormulario.Controls.Find("LB_RESTA", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
        LB_FECHA_DOCUMENTO = _MiFormulario.Controls.Find("LB_FECHA_DOCUMENTO", True)(0)
        LB_RIF = _MiFormulario.Controls.Find("LB_RIF", True)(0)
        MT_DETALLE = _MiFormulario.Controls.Find("MT_DETALLE", True)(0)
        MN_MONTO = _MiFormulario.Controls.Find("MN_MONTO", True)(0)
        BT_GUARDAR = _MiFormulario.Controls.Find("BT_GUARDAR", True)(0)

        _MiFormulario.Text = "Control De Notas De Débito"
        LB_TITULO.Text = "Nota De Débito"
        LB_TITULO_1.Text = "Nueva Nota De Débito"
        LB_FECHA.Text = g_MiData.p_FechaDelMotorBD.ToShortDateString
        MT_DETALLE.Text = ""
        With MN_MONTO
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.00"
            .Select()
            .Focus()
        End With

        LB_RIF.Text = _FichaProveedor.f_Proveedor.RegistroDato._CiRif
        LB_FECHA_DOCUMENTO.Text = _FichaCxP.RegistroDato._FechaEmision.ToShortDateString
        LB_APLICA.Text = _FichaCxP.RegistroDato._NumeroDocumento
        LB_RESTA.Text = _FichaCxP.RegistroDato._MontoPorPagar
        LB_NOMBRE.Text = _FichaProveedor.f_Proveedor.RegistroDato._NombreRazonSocial
    End Sub

    Function ValidarCampos() As Boolean
        If MN_MONTO._Valor = 0 Then
            MessageBox.Show("DEBE REGISTRAR UN MONTO MAYOR A CERO (0), POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_MONTO.SelectAll()
            MN_MONTO.Focus()
            Return False
        End If

        If MT_DETALLE.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR EL DETALLE DEL DOCUMENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DETALLE.Select()
            MT_DETALLE.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub Formulario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Formulario.FormClosing
        If _SalidaOk Then
            e.Cancel = False
        Else
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Salir?, Se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        If ValidarCampos() Then
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro Grabar Este Registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xficha As New FichaCtasPagar
                    Dim xagregarnd As New FichaCtasPagar.c_CxP.c_AgregarNotaDebito

                    With xagregarnd
                        ._FechaProceso = g_MiData.p_FechaDelMotorBD
                        ._FichaProveedor = _FichaProveedor.f_Proveedor.RegistroDato
                        ._Monto = Me.MN_MONTO._Valor
                        ._NotasDetalle = Me.MT_DETALLE.r_Valor
                        ._NumeroDocumentoAplica = _FichaCxP.RegistroDato._NumeroDocumento
                    End With
                    xficha.F_GrabarNotaDebito(xagregarnd)
                    RaiseEvent _DocumentoProcesado()

                    MessageBox.Show("DOCUMENTO REGISTRADO EXITOSAMENTE... OK", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _SalidaOk = True
                    _MiFormulario.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub
End Class
