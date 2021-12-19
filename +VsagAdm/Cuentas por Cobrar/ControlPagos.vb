Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class ControlPagos
    Dim _Plantilla As IControlPagos

    Sub New(ByVal xplantilla As IControlPagos)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Private Sub ControlPagos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ControlPagos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            _Plantilla.Inicializar(Me)
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR FORMULARIO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub ControlPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub BT_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_1.Click

    End Sub
End Class

Public Interface IControlPagos
    Sub Inicializar(ByVal xficha As Object)
End Interface

Public Class ControlPagosClientes
    Implements IControlPagos
    Event _DocumentoProcesado()
    Protected Friend Const SELECT_COBRADORES As String = "SELECT nombre xnom, auto xauto, * FROM cobradores WHERE estatus='Activo' ORDER BY nombre"


    Enum E_TipoEstatus As Integer
        Nuevo = 0
        Modificado = 1
        NCF = 2
        ANT = 3
    End Enum

    'CONTROLES
    WithEvents xformulario As System.Windows.Forms.Form
    WithEvents MisGrid1 As MisGrid
    WithEvents MisGrid2 As MisGrid
    WithEvents MisGrid3 As MisGrid
    WithEvents LK_1 As System.Windows.Forms.LinkLabel
    WithEvents LK_2 As System.Windows.Forms.LinkLabel
    Dim LB_1 As System.Windows.Forms.Label
    Dim LB_2 As System.Windows.Forms.Label
    Dim LB_3 As System.Windows.Forms.Label
    Dim LB_4 As System.Windows.Forms.Label
    Dim LB_5 As System.Windows.Forms.Label
    Dim LB_6 As System.Windows.Forms.Label
    Dim LB_7 As System.Windows.Forms.Label
    Dim LB_8 As System.Windows.Forms.Label
    Dim LB_9 As System.Windows.Forms.Label
    Dim LB_10 As System.Windows.Forms.Label
    Dim LB_11 As System.Windows.Forms.Label
    WithEvents MF_1 As MisFechas
    WithEvents MCHKB_1 As MisCheckBox
    WithEvents MT_1 As MisTextos
    WithEvents MCB_1 As MisComboBox
    WithEvents BT_1 As Button

    Dim xcliente As FichaClientes.c_Clientes.c_Registro
    Dim xmontopagar As Decimal
    Dim xmontonc As Decimal
    Dim xmontoabonado As Decimal

    Dim xtb_cobrador As DataTable
    Dim xbinding_cobrador As BindingSource
    Dim _Data_1 As List(Of DocumentosPagar) 'TABLA DOCUMENTOS SELECCIONADOS A PAGAR
    Dim _Data_2 As BindingList(Of DocumentosNC) 'TABLA DOCUMENTOS NOTA DE CREDITO A FAVOR DEL CLIENTE
    Dim xbinding_data2 As BindingSource
    Dim xsalida As Boolean

    WithEvents _Data_3 As DataTable
    Dim xbinding_modopago As BindingSource

    Dim xbinding_2 As BindingSource
    Dim _Indicador As Boolean = False

    Property _SalidaOk() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Property _MontoPagar() As Decimal
        Get
            Return xmontopagar
        End Get
        Set(ByVal value As Decimal)
            xmontopagar = value
        End Set
    End Property

    Property _MontoNC() As Decimal
        Get
            Return xmontonc
        End Get
        Set(ByVal value As Decimal)
            xmontonc = value
        End Set
    End Property

    ReadOnly Property _MontoPendiente() As Decimal
        Get
            Dim xr As Decimal = Me.xmontopagar - Me.xmontoabonado
            If xr > 0 Then
                Return xr
            Else
                Return 0
            End If
        End Get
    End Property

    Property _MontoAbonado() As Decimal
        Set(ByVal value As Decimal)
            xmontoabonado = value
        End Set
        Get
            Return xmontoabonado
        End Get
    End Property

    Sub New(ByVal xcliente As FichaClientes.c_Clientes.c_Registro, ByVal xlista_1 As List(Of DocumentosPagar), ByVal xlista_2 As BindingList(Of DocumentosNC))
        _FichaCliente = xcliente
        _Data_1 = xlista_1 'Documentos
        _Data_2 = xlista_2 'N/C
        _Data_3 = New DataTable  'Modos Pagos

        _MontoPagar = 0
        _MontoNC = 0
        _MontoAbonado = 0
        _SalidaOk = False

        xtb_cobrador = New DataTable
        xbinding_cobrador = New BindingSource(xtb_cobrador, "")
        xbinding_data2 = New BindingSource(_Data_2, "")

        With _Data_3
            .Columns.Add("forma_pago", GetType(String))
            .Columns.Add("importe", GetType(Decimal))
            .Columns.Add("numero", GetType(String))
            .Columns.Add("agencia", GetType(String))
            .Columns.Add("auto_forma_pago", GetType(String))
            .Columns.Add("detalle", GetType(String))

            AddHandler .RowChanged, AddressOf ActualizarImporteAbono
            AddHandler .RowDeleted, AddressOf ActualizarImporteAbono
        End With
        xbinding_modopago = New BindingSource(_Data_3, "")
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
        Get
            Return Me.xcliente
        End Get
        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
            Me.xcliente = value
        End Set
    End Property

    Public Sub Inicializar(ByVal xficha As Object) Implements IControlPagos.Inicializar
        Try
            _MiFormulario = xficha
            LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            LB_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            LB_3 = _MiFormulario.Controls.Find("LB_3", True)(0)
            LB_4 = _MiFormulario.Controls.Find("LB_4", True)(0)
            LB_5 = _MiFormulario.Controls.Find("LB_5", True)(0)
            LB_6 = _MiFormulario.Controls.Find("LB_6", True)(0)
            LB_7 = _MiFormulario.Controls.Find("LB_7", True)(0)
            LB_8 = _MiFormulario.Controls.Find("LB_8", True)(0)
            LB_9 = _MiFormulario.Controls.Find("LB_9", True)(0)
            LB_10 = _MiFormulario.Controls.Find("LB_10", True)(0)
            LB_11 = _MiFormulario.Controls.Find("LB_11", True)(0)

            LK_1 = _MiFormulario.Controls.Find("LK_1", True)(0) 'FICHA CLIENTE
            LK_2 = _MiFormulario.Controls.Find("LK_2", True)(0) 'FICHA COBRADOR

            MisGrid1 = _MiFormulario.Controls.Find("MisGrid1", True)(0)
            MisGrid2 = _MiFormulario.Controls.Find("MisGrid2", True)(0)
            MisGrid3 = _MiFormulario.Controls.Find("MisGrid3", True)(0)
            MCHKB_1 = _MiFormulario.Controls.Find("MCHKB_1", True)(0)
            MF_1 = _MiFormulario.Controls.Find("MF_1", True)(0)
            MT_1 = _MiFormulario.Controls.Find("MT_1", True)(0)
            MCB_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            InicializarData()
            CargarGrids()

            Me.MF_1.Value = g_MiData.p_FechaDelMotorBD
            With Me.MT_1
                .Text = ""
                .MaxLength = 120
                .Select()
                .Focus()
            End With

            'CARGAR COBRADORES
            CargarCobrador()
            With MCB_1
                .DataSource = xbinding_cobrador
                .DisplayMember = "xnom"
                .ValueMember = "xauto"
                .SelectedValue = _FichaCliente.r_AutoCobrador
            End With

            Me.LB_11.Text = String.Format("{0:#0.00}", _FichaCliente.r_TotalAnticipos)
            If _FichaCliente.r_TotalAnticipos <= 0 Then
                Me.MCHKB_1.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _MiFormulario.Close()
        End Try
    End Sub

    Sub InicializarData()
        LB_1.Text = _FichaCliente.r_NombreRazonSocial
        LB_2.Text = _FichaCliente.r_CiRif
        LB_3.Text = _FichaCliente.r_CodigoCliente
        LB_4.Text = String.Format("{0:#0}", 0)
        LB_5.Text = String.Format("{0:#0.00}", 0)
        LB_6.Text = String.Format("{0:#0}", 0)
        LB_7.Text = String.Format("{0:#0.00}", 0)
        LB_8.Text = String.Format("{0:#0.00}", 0)
        LB_9.Text = String.Format("{0:#0.00}", 0)
        LB_10.Text = String.Format("{0:#0.00}", 0)
        LB_11.Text = String.Format("{0:#0.00}", 0)
    End Sub

    Sub CargarGrids()
        'GRIDS DE DOCUMENTOS A PAGAR
        With MisGrid1
            .Columns.Add("col0", "F/Emisión")
            .Columns.Add("col1", "T/Documento")
            .Columns.Add("col2", "Documento")
            .Columns.Add("col3", "Resta")

            .Columns(0).Width = 90
            .Columns(2).Width = 100
            .Columns(3).Width = 90
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = _Data_1
            .Columns(0).DataPropertyName = "_FechaEmision"
            .Columns(1).DataPropertyName = "_TipoDocumento"
            .Columns(2).DataPropertyName = "_NumeroDocumento"
            .Columns(3).DataPropertyName = "_MontoPendiente"
            .Ocultar(5)
        End With
        _MontoPagar = _Data_1.Sum(Function(x) x._MontoPendiente)
        Me.LB_4.Text = String.Format("{0:#0}", _Data_1.Count)
        Me.LB_5.Text = String.Format("{0:#0.00}", _MontoPagar)
        Me.LB_8.Text = String.Format("{0:#0.00}", _MontoPagar)

        Dim xcol3 As New DataGridViewCheckBoxColumn
        With xcol3
            .ReadOnly = False
            .Name = "col3"
            .Width = 30
            .HeaderText = "*"
        End With

        'NOTAS DE CREDITO
        With MisGrid2
            .Columns.Add("col0", "F/Emisión")
            .Columns.Add("col1", "Documento")
            .Columns.Add("col2", "Importe")
            .Columns.Add(xcol3)

            .Columns(0).Width = 100
            .Columns(2).Width = 100
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xbinding_data2
            .Columns(0).DataPropertyName = "_FechaEmision"
            .Columns(1).DataPropertyName = "_NumeroDocumento"
            .Columns(2).DataPropertyName = "_MontoImporte"
            .Columns(3).DataPropertyName = "_Estatus"
            .Ocultar(5)

        End With
        _MontoNC = _Data_2.Sum(Function(x) x._MontoImporte)
        Me.LB_6.Text = String.Format("{0:#0}", _Data_2.Count)
        Me.LB_7.Text = String.Format("{0:#0.00}", _MontoNC)
        Me.LB_9.Text = String.Format("{0:#0.00}", _MontoPendiente)
        Me.LB_10.Text = String.Format("{0:#0.00}", _MontoAbonado)

        'GRIDS DE PAGOS
        With MisGrid3
            .Columns.Add("col0", "Forma")
            .Columns.Add("col1", "Importe")
            .Columns.Add("col2", "Número")
            .Columns.Add("col3", "Banco")

            .Columns(0).Width = 120
            With .Columns(1)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 70
            End With
            .Columns(2).Width = 100
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xbinding_modopago
            .Columns(0).DataPropertyName = "forma_pago"
            .Columns(1).DataPropertyName = "importe"
            .Columns(2).DataPropertyName = "numero"
            .Columns(3).DataPropertyName = "agencia"

            .Ocultar(5)
            .AllowUserToDeleteRows = True
        End With
    End Sub

    Sub CargarCobrador()
        Try
            g_MiData.F_GetData(SELECT_COBRADORES, xtb_cobrador)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function PagoCombinado() As Boolean
        Try
            If _MontoPagar > _MontoAbonado Then
                Dim xrow As DataRow = _Data_3.NewRow
                Dim xficha As New TipoPago(xrow)
                With xficha
                    .ShowDialog()
                    If ._EstatusSalida Then
                        _Data_3.Rows.Add(xrow)
                        _Data_3.AcceptChanges()
                    End If
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function PagoDirecto() As Boolean
        Try
            If _MontoPagar > _MontoAbonado Then
                Dim xpg As New FichaGlobal.c_MediosPagos
                xpg.F_BuscarRegistro(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoMedioPago_Por_Defecto)

                Dim xrow As DataRow = _Data_3.NewRow
                xrow("forma_pago") = xpg.RegistroDato._NombreTipoPago
                xrow("importe") = _MontoPendiente
                xrow("numero") = ""
                xrow("agencia") = ""
                xrow("auto_forma_pago") = xpg.RegistroDato._AutoTipoPago
                xrow("detalle") = ""
                _Data_3.Rows.Add(xrow)
                _Data_3.AcceptChanges()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Sub ImprimirRecibo(ByVal xauto As String)
        MessageBox.Show("DOCUMENTO REGISTRADO EXITOSAMENTE", "***Información***", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Funciones.ImprimirReciboPagoCxC(xauto)
    End Sub

    Private Sub MisGrid2_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MisGrid2.CellContentClick
        If e.RowIndex <> -1 Then
            If e.ColumnIndex = 3 Then
                If (xbinding_data2.Current IsNot Nothing) Then
                    Dim xr As DocumentosNC = CType(xbinding_data2.Current, DocumentosNC)
                    If xr._Estatus = 1 Then
                        _Data_2.Item(xbinding_data2.Position)._Estatus = 0
                    Else
                        If _MontoAbonado < _MontoPagar Then
                            _Data_2.Item(xbinding_data2.Position)._Estatus = 1
                        Else
                            MessageBox.Show("Monto Abonado Supera / Igual Al Monto A Pagar, Verifique Por favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
                ActualizarImporteAbono()
            End If
        End If
    End Sub

    Sub ActualizarImporteAbono()
        Dim x2 As Decimal = 0
        For Each xr As DocumentosNC In _Data_2
            If xr._Estatus = 1 Then
                x2 += xr._MontoImporte
            End If
        Next

        For Each xrow As DataRow In _Data_3.Rows
            If xrow.RowState <> DataRowState.Deleted Then
                x2 += xrow("importe")
            End If
        Next

        _MontoAbonado = x2
        Me.LB_9.Text = String.Format("{0:#0.00}", _MontoPendiente)
        Me.LB_10.Text = String.Format("{0:#0.00}", _MontoAbonado)
    End Sub

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

    Private Sub LK_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LK_1.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCliente.F_Permitir()
            Dim xficha As New FichaCliente(_FichaCliente.r_Automatico)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub LK_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LK_2.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCobrador.F_Permitir()
            Dim xficha As New FichaCobrador()
            With xficha
                AddHandler .ActualizarFicha, AddressOf CargarCobrador
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ValidarCampos() As Boolean
        If (MT_1.r_Valor = "") Then
            MessageBox.Show("FALTA ESPECIFICAR ALGUN MOTIVO DEL PAGO / ABONO , POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_1.Select()
            MT_1.Focus()
            Return False
        End If

        If (_MontoAbonado = 0) Then
            MessageBox.Show("DEBES REALIZAR UN PAGO / ABONO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If (Me.MF_1.Value > g_MiData.p_FechaDelMotorBD) Then
            MessageBox.Show("FECHA DEL PAGO / ABONO INCORRECTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.MF_1.Select()
            Me.MF_1.Focus()
            Return False
        End If

        If (Me.MCB_1.SelectedValue = "" Or Me.MCB_1.SelectedValue Is Nothing) Then
            MessageBox.Show("DEBES SELECCIONAR / AGREGAR UN COBRADOR PARA EL PAGO / ABONO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.MCB_1.Select()
            Me.MCB_1.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If ValidarCampos() = True Then
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Grabar Este Registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                Try
                    GrabarPago()
                    RaiseEvent _DocumentoProcesado()

                    _SalidaOk = True
                    _MiFormulario.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Public Function GrabarPago() As Boolean
        Try
            Dim xficha As New FichaCtasCobrar
            Dim xcobrador As New FichaCobradores
            xcobrador.F_BuscarCobrador(Me.MCB_1.SelectedValue)

            Dim xlist As New List(Of FichaCtasCobrar.c_CxC.c_AgregarPagos.Doc)
            For Each xd As DocumentosPagar In _Data_1
                Dim xdoc As New FichaCtasCobrar.c_CxC.c_AgregarPagos.Doc
                With xdoc
                    ._AutoDocumento = xd._AutoDocumento
                    ._IdDocumento = xd._IdSeguridad
                End With
                xlist.Add(xdoc)
            Next

            Dim xlist2 As New List(Of FichaCtasCobrar.c_CxC.c_AgregarPagos.Doc)
            For Each x2 As DocumentosNC In _Data_2
                If x2._Estatus = 1 Then
                    Dim xdoc As New FichaCtasCobrar.c_CxC.c_AgregarPagos.Doc
                    With xdoc
                        ._AutoDocumento = x2._AutoDocumento
                        ._IdDocumento = x2._IdSeguridad
                    End With
                    xlist2.Add(xdoc)
                End If
            Next

            Dim xanticipo As Decimal = 0
            Dim xlist3 As New List(Of FichaCtasCobrar.c_CxC.c_AgregarPagos.ModoPagos)
            For Each x3 As DataRow In _Data_3.Rows
                If x3.RowState <> DataRowState.Deleted Then
                    If x3("forma_pago").ToString.Trim.ToUpper = "ANTICIPO" Then
                        xanticipo = x3("importe")
                    Else
                        Dim xpg As New FichaGlobal.c_MediosPagos
                        xpg.F_BuscarRegistro(x3("auto_forma_pago"))

                        Dim xmodo As New FichaCtasCobrar.c_CxC.c_AgregarPagos.ModoPagos
                        With xmodo
                            ._Agencia = x3("agencia")
                            ._MedioPago = xpg.RegistroDato
                            ._MontoImporte = x3("importe")
                            ._MontoRecibido = x3("importe")
                            ._PlanillaCheque = x3("numero")
                        End With
                        xlist3.Add(xmodo)
                    End If
                End If
            Next

            Dim xagregarpagos As New FichaCtasCobrar.c_CxC.c_AgregarPagos
            With xagregarpagos
                ._FechaProceso = g_MiData.p_FechaDelMotorBD
                ._FechaEmision = Me.MF_1.Value.Date
                ._FichaCliente = _FichaCliente
                ._FichaCobrador = xcobrador.f_Cobrador.RegistroDato
                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._MontoAnticipoUsado = xanticipo
                ._MontoImporte = _MontoAbonado
                ._NotasDetalle = MT_1.r_Valor
                ._ListaDocumentosPagar = xlist
                ._ListaDocumentosNC_ModoPago = xlist2
                ._ListaModosPagos = xlist3
            End With

            AddHandler xficha.RetornarAutoRecibo, AddressOf ImprimirRecibo
            xficha.F_GrabarAbono(xagregarpagos)
        Catch ex As Exception
            Throw New Exception("CONTROL PAGOS" + vbCrLf + "GRABAR" + vbCrLf + ex.Message)
        End Try
    End Function

    Private Sub xformulario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles xformulario.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            PagoDirecto()
        End If

        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            PagoCombinado()
        End If
    End Sub

    Private Sub MisGrid3_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid3.Accion
        Dim xw As DataRow = CType(xbinding_modopago.Current, DataRowView).Row
        If xw.RowState <> DataRowState.Deleted Then
            If xw("forma_pago").ToString.Trim.ToUpper = "ANTICIPO" Then
                MessageBox.Show("ALERTA ... ESTE MODO DE PAGO NO PUEDE MODIFICARSE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim xficha As New TipoPago(xw)
                With xficha
                    .ShowDialog()
                    If ._EstatusSalida Then
                        xbinding_modopago.Current(0) = ._Registro(0)
                        xbinding_modopago.Current(1) = ._Registro(1)
                        xbinding_modopago.Current(2) = ._Registro(2)
                        xbinding_modopago.Current(3) = ._Registro(3)
                        xbinding_modopago.Current(4) = ._Registro(4)
                        xbinding_modopago.Current(5) = ._Registro(5)
                        _Data_3.AcceptChanges()
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub MCHKB_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCHKB_1.Click
        Try
            If MCHKB_1.Checked = False Then
                For Each xr As DataRow In _Data_3.Rows
                    If xr("forma_pago").ToString.Trim.ToUpper = "ANTICIPO" Then
                        _Data_3.Rows.Remove(xr)
                        _Data_3.AcceptChanges()
                        Exit For
                    End If
                Next
            Else
                If _MontoPagar > _MontoAbonado Then
                    Dim xrow As DataRow = _Data_3.NewRow
                    xrow("forma_pago") = "ANTICIPO"
                    xrow("importe") = IIf(_FichaCliente.r_TotalAnticipos > _MontoPendiente, _MontoPendiente, _FichaCliente.r_TotalAnticipos)
                    xrow("numero") = ""
                    xrow("agencia") = ""
                    xrow("auto_forma_pago") = "ANTICIPO"
                    xrow("detalle") = "PAGO/ABONO POR ANTICIPO"
                    _Data_3.Rows.Add(xrow)
                    _Data_3.AcceptChanges()
                Else
                    MessageBox.Show("Monto Abonado Supera / Igual Al Monto A Pagar, Verifique Por favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MisGrid3_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles MisGrid3.UserDeletingRow
        Try
            Dim rw As DataRow = CType(e.Row.DataBoundItem, DataRowView).Row
            If rw("forma_pago").ToString.Trim.ToUpper = "ANTICIPO" Then
                e.Cancel = True
                Throw New Exception("PARA ELIMINAR ESTE MEDIO DE PAGO DEBES USAR LA CASILLA ANTICIPOS. GRACIAS")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class