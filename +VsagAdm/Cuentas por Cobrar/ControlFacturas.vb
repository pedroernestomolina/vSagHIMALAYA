Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles

Public Class ControlFacturas
    Dim _Plantilla As IControlFacturas

    Sub New(ByVal xplantilla As IControlFacturas)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Private Sub ControlFacturas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ControlFacturas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            _Plantilla.Inicializar(Me)
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR FORMULARIO" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click

    End Sub

    Private Sub ControlFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IControlFacturas
    Sub Inicializar(ByVal xformulario As Object)
End Interface

Public Class ControlFacturasVentas
    Implements IControlFacturas
    Event _DocumentoProcesado()

    'CONTROLES
    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    WithEvents MT_DOCUMENTO As MisTextos
    WithEvents MT_DETALLE As MisTextos
    Dim MN_DIAS As MisNumeros
    WithEvents MN_IMPORTE As MisNumeros
    WithEvents MN_SALDOPENDIENTE As MisNumeros
    Dim MF_FECHA As System.Windows.Forms.DateTimePicker
    WithEvents MCB_DOCUMENTO As MisComboBox
    WithEvents BT_GUARDAR As System.Windows.Forms.Button

    Dim xcliente As FichaClientes
    Dim xsalida As Boolean
    Dim xdoc() As String = {"Factura", "Nota Débito", "Nota Crédito", "Prestamos"}

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Property _FichaCliente() As FichaClientes
        Get
            Return xcliente
        End Get
        Set(ByVal value As FichaClientes)
            xcliente = value
        End Set
    End Property

    Property _SalidaOk() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Sub New(ByVal xclientes As FichaClientes)
        _FichaCliente = xclientes
        _SalidaOk = False
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IControlFacturas.Inicializar
        _MiFormulario = xformulario
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        MT_DOCUMENTO = _MiFormulario.Controls.Find("MT_DOCUMENTO", True)(0)
        MT_DETALLE = _MiFormulario.Controls.Find("MT_DETALLE", True)(0)
        MF_FECHA = _MiFormulario.Controls.Find("MF_FECHA", True)(0)
        MN_DIAS = _MiFormulario.Controls.Find("MN_DIAS", True)(0)
        MN_IMPORTE = _MiFormulario.Controls.Find("MN_IMPORTE", True)(0)
        MN_SALDOPENDIENTE = _MiFormulario.Controls.Find("MN_SALDOPENDIENTE", True)(0)
        MCB_DOCUMENTO = _MiFormulario.Controls.Find("MCB_DOCUMENTO", True)(0)
        BT_GUARDAR = _MiFormulario.Controls.Find("BT_GUARDAR", True)(0)

        With MN_DIAS
            ._Formato = "99"
            ._ConSigno = False
            .Text = "0"
        End With

        With MN_IMPORTE
            .Text = "0.00"
            ._Formato = "9999999999.99"
            ._ConSigno = False
        End With

        With MN_SALDOPENDIENTE
            .Text = "0.00"
            ._Formato = "9999999999.99"
            ._ConSigno = False
        End With

        With Me.MT_DETALLE
            .Text = ""
            .MaxLength = 120
        End With

        With Me.MT_DOCUMENTO
            .Text = ""
            .MaxLength = 10
        End With

        With Me.MCB_DOCUMENTO
            .DataSource = xdoc
            .SelectedIndex = 0
        End With

        LB_NOMBRE.Text = _FichaCliente.f_Clientes.RegistroDato.r_NombreRazonSocial
        LB_CIRIF.Text = _FichaCliente.f_Clientes.RegistroDato.r_CiRif
        LB_CODIGO.Text = _FichaCliente.f_Clientes.RegistroDato.r_CodigoCliente
        MF_FECHA.Value = g_MiData.p_FechaDelMotorBD.ToShortDateString()
    End Sub

    Function GetTipoDocumento(ByVal xtipo As String) As String
        Select Case xtipo
            Case "Factura" : Return "FAC"
            Case "Nota Débito" : Return "NDF"
            Case "Nota Crédito" : Return "NCF"
            Case Else : Return "PRE"
        End Select
    End Function

    Function ValidarCampos() As Boolean
        If MT_DOCUMENTO.r_Valor = "" And MCB_DOCUMENTO.SelectedIndex <> 3 Then
            MessageBox.Show("DEBE REGISTRAR EL NÚMERO DEL DOCUMENTO, POR FAVOR VERIFIQUE", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DOCUMENTO.Select()
            MT_DOCUMENTO.Focus()
            Return False
        End If

        If MN_IMPORTE._Valor = 0 Then
            MessageBox.Show("EL MONTO DEL DOCUMENTO NO PUEDE SER CERO (0), POR FAVOR VERIFIQUE", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_IMPORTE.Select()
            MN_IMPORTE.Focus()
            Return False
        End If

        If MN_SALDOPENDIENTE._Valor = 0 Then
            MessageBox.Show("EL MONTO A COBRAR DEL DOCUMENTO NO PUEDE SER CERO (0), POR FAVOR VERIFIQUE", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_SALDOPENDIENTE.Select()
            MN_SALDOPENDIENTE.Focus()
            Return False
        End If

        If MT_DETALLE.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR EL DETALLE DEL DOCUMENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DETALLE.Select()
            MT_DETALLE.Focus()
            Return False
        End If

        If MF_FECHA.Value > g_MiData.p_FechaDelMotorBD Then
            MessageBox.Show("FECHA DE EMISION DEL MOVIMIENTO INCORRECTA, DEBE SER MENOR O IGUAL A LA FECHA ACTUAL, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MF_FECHA.Select()
            MF_FECHA.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub MT_DOCUMENTO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MT_DOCUMENTO.LostFocus
        If MT_DOCUMENTO.r_Valor <> "" Then
            MT_DOCUMENTO.Text = MT_DOCUMENTO.Text.Trim.PadLeft(10, "0")
        End If
    End Sub

    Private Sub MN_IMPORTE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_IMPORTE.LostFocus
        If Me.MN_IMPORTE._Valor >= 0 Then
            MN_SALDOPENDIENTE.Text = String.Format("{0:#0.00}", Me.MN_IMPORTE._Valor)
        End If
    End Sub

    Private Sub MN_SALDOPENDIENTE_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_SALDOPENDIENTE.LostFocus
        If Me.MN_SALDOPENDIENTE._Valor = 0 Then
            MessageBox.Show("EL SALDO PENDIENTE NO PUEDE SER CERO (0)", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MN_SALDOPENDIENTE.Text = String.Format("{0:#0.00}", Me.MN_IMPORTE._Valor)
        End If
        If MN_SALDOPENDIENTE._Valor > MN_IMPORTE._Valor Then
            MessageBox.Show("EL SALDO PENDIENTE NO PUEDE SER MAYOR AL IMPORTE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MN_SALDOPENDIENTE.Text = String.Format("{0:#0.00}", Me.MN_IMPORTE._Valor)
        End If
    End Sub

    Private Sub MCB_DOCUMENTO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCB_DOCUMENTO.SelectedIndexChanged
        Select Case MCB_DOCUMENTO.SelectedIndex
            Case 0 'Factura
                MN_DIAS.Text = "0"
                MT_DOCUMENTO.Text = ""
                MN_DIAS.Enabled = True
                MT_DOCUMENTO.Enabled = True
            Case 1, 2 'Nota Debito, Credito
                MN_DIAS.Text = "0"
                MT_DOCUMENTO.Text = ""
                MN_DIAS.Enabled = False
                MT_DOCUMENTO.Enabled = True
            Case 3 'Prestamo
                MT_DOCUMENTO.Text = ""
                MN_DIAS.Text = "0"
                MT_DOCUMENTO.Enabled = False
                MN_DIAS.ReadOnly = False
        End Select
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        If ValidarCampos() Then
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Grabar Este Registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                Try
                    GrabarDoc()
                    MessageBox.Show("DOCUMENTO REGISTRADO EXITOSAMENTE... OK", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RaiseEvent _DocumentoProcesado()
                    _SalidaOk = True
                    _MiFormulario.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Public Function GrabarDoc() As Boolean
        Try
            Dim xagregar As New FichaCtasCobrar.c_CxC.c_AgregarDocumentoCxC
            Dim xficha As New FichaCtasCobrar

            With xagregar
                ._DiasCredito = Me.MN_DIAS._Valor
                ._FechaEmision = Me.MF_FECHA.Value
                ._FechaProceso = g_MiData.p_FechaDelMotorBD
                ._FichaCliente = _FichaCliente.f_Clientes.RegistroDato
                ._Importe = Me.MN_IMPORTE._Valor
                ._NotasDetalle = MT_DETALLE.r_Valor
                ._NumeroDocumento = MT_DOCUMENTO.r_Valor
                ._SaldoPendiente = MN_SALDOPENDIENTE._Valor
                Select Case Me.MCB_DOCUMENTO.SelectedIndex
                    Case 0 : ._TipoDocumentoProcesar = TipoDocumentoMovEntradaCxC.Factura
                    Case 1 : ._TipoDocumentoProcesar = TipoDocumentoMovEntradaCxC.NotaDebito
                    Case 2 : ._TipoDocumentoProcesar = TipoDocumentoMovEntradaCxC.NotaCreditoNoGeneradaPorSistema
                    Case 3 : ._TipoDocumentoProcesar = TipoDocumentoMovEntradaCxC.Prestamo
                End Select
            End With
            xficha.F_GrabarMovimientoEntrada(xagregar)
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub xformulario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles xformulario.FormClosing
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
End Class

Public Class ControlFacturasCompras
    Implements IControlFacturas
    Event _DocumentoProcesado()

    'CONTROLES
    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    WithEvents MT_DOCUMENTO As MisTextos
    WithEvents MT_DETALLE As MisTextos
    Dim MN_DIAS As MisNumeros
    WithEvents MN_IMPORTE As MisNumeros
    WithEvents MN_SALDOPENDIENTE As MisNumeros
    Dim MF_FECHA As System.Windows.Forms.DateTimePicker
    WithEvents MCB_DOCUMENTO As MisComboBox
    WithEvents BT_GUARDAR As System.Windows.Forms.Button

    Dim xsalida As Boolean
    Dim xdoc() As String = {"Compra", "Nota Débito", "Nota Crédito"}
    Dim xproveedor As FichaProveedores

    Property _MiFichaProveedor() As FichaProveedores
        Get
            Return xproveedor
        End Get
        Set(ByVal value As FichaProveedores)
            xproveedor = value
        End Set
    End Property

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Property _SalidaOk() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Sub New(ByVal xpro As FichaProveedores)
        _MiFichaProveedor = xpro
        _SalidaOk = False
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IControlFacturas.Inicializar
        _MiFormulario = xformulario
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        MT_DOCUMENTO = _MiFormulario.Controls.Find("MT_DOCUMENTO", True)(0)
        MT_DETALLE = _MiFormulario.Controls.Find("MT_DETALLE", True)(0)
        MF_FECHA = _MiFormulario.Controls.Find("MF_FECHA", True)(0)
        MN_DIAS = _MiFormulario.Controls.Find("MN_DIAS", True)(0)
        MN_IMPORTE = _MiFormulario.Controls.Find("MN_IMPORTE", True)(0)
        MN_SALDOPENDIENTE = _MiFormulario.Controls.Find("MN_SALDOPENDIENTE", True)(0)
        MCB_DOCUMENTO = _MiFormulario.Controls.Find("MCB_DOCUMENTO", True)(0)
        BT_GUARDAR = _MiFormulario.Controls.Find("BT_GUARDAR", True)(0)

        With MN_DIAS
            ._Formato = "99"
            ._ConSigno = False
            .Text = "0"
        End With

        With MN_IMPORTE
            .Text = "0.00"
            ._Formato = "99999999.99"
            ._ConSigno = False
        End With

        With MN_SALDOPENDIENTE
            .Text = "0.00"
            ._Formato = "99999999.99"
            ._ConSigno = False
        End With

        With Me.MT_DETALLE
            .Text = ""
            .MaxLength = 120
        End With

        With Me.MT_DOCUMENTO
            .Text = ""
            .MaxLength = 10
        End With

        With Me.MCB_DOCUMENTO
            .DataSource = xdoc
            .SelectedIndex = 0
        End With

        LB_NOMBRE.Text = _MiFichaProveedor.f_Proveedor.RegistroDato._NombreRazonSocial
        LB_CIRIF.Text = _MiFichaProveedor.f_Proveedor.RegistroDato._CiRif
        LB_CODIGO.Text = _MiFichaProveedor.f_Proveedor.RegistroDato._CodigoProveedor
        MF_FECHA.Value = g_MiData.p_FechaDelMotorBD.ToShortDateString()
    End Sub

    Function GetTipoDocumento(ByVal xtipo As String) As String
        Select Case xtipo
            Case "Factura" : Return "FAC"
            Case "Nota Débito" : Return "NDF"
            Case Else : Return "NCF"
        End Select
    End Function

    Function ValidarCampos() As Boolean
        If MT_DOCUMENTO.r_Valor = "" And MCB_DOCUMENTO.SelectedIndex <> 3 Then
            MessageBox.Show("DEBE REGISTRAR EL NÚMERO DEL DOCUMENTO, POR FAVOR VERIFIQUE", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DOCUMENTO.Select()
            MT_DOCUMENTO.Focus()
            Return False
        End If

        If MN_IMPORTE._Valor = 0 Then
            MessageBox.Show("EL MONTO DEL DOCUMENTO NO PUEDE SER CERO (0), POR FAVOR VERIFIQUE", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_IMPORTE.Select()
            MN_IMPORTE.Focus()
            Return False
        End If

        If MN_SALDOPENDIENTE._Valor = 0 Then
            MessageBox.Show("EL MONTO A COBRAR DEL DOCUMENTO NO PUEDE SER CERO (0), POR FAVOR VERIFIQUE", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_SALDOPENDIENTE.Select()
            MN_SALDOPENDIENTE.Focus()
            Return False
        End If

        If MT_DETALLE.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR EL DETALLE DEL DOCUMENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DETALLE.Select()
            MT_DETALLE.Focus()
            Return False
        End If

        If MF_FECHA.Value > g_MiData.p_FechaDelMotorBD Then
            MessageBox.Show("FECHA DE EMISION DEL MOVIMIENTO INCORRECTA, DEBE SER MENOR O IGUAL A LA FECHA ACTUAL, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MF_FECHA.Select()
            MF_FECHA.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub MT_DOCUMENTO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MT_DOCUMENTO.LostFocus
        If MT_DOCUMENTO.r_Valor <> "" Then
            MT_DOCUMENTO.Text = MT_DOCUMENTO.Text.Trim.PadLeft(10, "0")
        End If
    End Sub

    Private Sub MN_IMPORTE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_IMPORTE.LostFocus
        If Me.MN_IMPORTE._Valor >= 0 Then
            MN_SALDOPENDIENTE.Text = String.Format("{0:#0.00}", Me.MN_IMPORTE._Valor)
        End If
    End Sub

    Private Sub MN_SALDOPENDIENTE_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_SALDOPENDIENTE.LostFocus
        If Me.MN_SALDOPENDIENTE._Valor = 0 Then
            MessageBox.Show("EL SALDO PENDIENTE NO PUEDE SER CERO (0)", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MN_SALDOPENDIENTE.Text = String.Format("{0:#0.00}", Me.MN_IMPORTE._Valor)
        End If
        If MN_SALDOPENDIENTE._Valor > MN_IMPORTE._Valor Then
            MessageBox.Show("EL SALDO PENDIENTE NO PUEDE SER MAYOR AL IMPORTE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MN_SALDOPENDIENTE.Text = String.Format("{0:#0.00}", Me.MN_IMPORTE._Valor)
        End If
    End Sub

    Private Sub MCB_DOCUMENTO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCB_DOCUMENTO.SelectedIndexChanged
        Select Case MCB_DOCUMENTO.SelectedIndex
            Case 0 'Factura
                MN_DIAS.Text = "0"
                MT_DOCUMENTO.Text = ""
                MN_DIAS.Enabled = True
                MT_DOCUMENTO.Enabled = True
            Case 1, 2 'Nota Debito, Credito
                MN_DIAS.Text = "0"
                MT_DOCUMENTO.Text = ""
                MN_DIAS.Enabled = False
                MT_DOCUMENTO.Enabled = True
        End Select
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        If ValidarCampos() Then
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Grabar Este Registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                Try
                    GrabarDoc()
                    MessageBox.Show("DOCUMENTO REGISTRADO EXITOSAMENTE... OK", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RaiseEvent _DocumentoProcesado()
                    _SalidaOk = True
                    _MiFormulario.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Public Function GrabarDoc() As Boolean
        Try
            Dim xagregar As New FichaCtasPagar.c_CxP.c_AgregarDocumentoCxP
            Dim xficha As New FichaCtasPagar

            With xagregar
                ._DiasCredito = Me.MN_DIAS._Valor
                ._FechaEmision = Me.MF_FECHA.Value
                ._FechaProceso = g_MiData.p_FechaDelMotorBD
                ._FichaProveedor = _MiFichaProveedor.f_Proveedor.RegistroDato
                ._Importe = Me.MN_IMPORTE._Valor
                ._NotasDetalle = MT_DETALLE.r_Valor
                ._NumeroDocumento = MT_DOCUMENTO.r_Valor
                ._SaldoPendiente = MN_SALDOPENDIENTE._Valor
                Select Case Me.MCB_DOCUMENTO.SelectedIndex
                    Case 0 : ._TipoDocumentoProcesar = TipoDocumentoMovEntradaCxP.Factura
                    Case 1 : ._TipoDocumentoProcesar = TipoDocumentoMovEntradaCxP.NotaDebito
                    Case 2 : ._TipoDocumentoProcesar = TipoDocumentoMovEntradaCxP.NotaCreditoNoGeneradaPorSistema
                End Select
            End With
            xficha.F_GrabarMovimientoEntrada(xagregar)
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub xformulario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles xformulario.FormClosing
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
End Class