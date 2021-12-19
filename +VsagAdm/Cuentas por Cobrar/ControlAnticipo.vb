Imports System.Data.SqlClient
Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema

Public Class ControlAnticipo
    Dim _Plantilla As IControlAnticipo

    Sub New(ByVal xplantilla As IControlAnticipo)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Private Sub ControlAnticipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ControlAnticipo_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            _Plantilla.Inicializar(Me)
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR FORMULARIO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub ControlAnticipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub
End Class

Public Interface IControlAnticipo
    Sub Inicializar(ByVal xformulario As Object)
End Interface

Public Class c_ControlAnticipoVentas
    Implements IControlAnticipo
    Event _DocumentoProcesado()

    'CONTROLES
    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_IMPORTE As System.Windows.Forms.Label
    WithEvents BT_GUARDAR As System.Windows.Forms.Button
    WithEvents MCB_COBRADOR As MisComboBox
    WithEvents MT_DETALLE As MisTextos
    WithEvents MF_FECHA As MisFechas
    WithEvents LK_COBRADOR As LinkLabel
    WithEvents MisGrid1 As MisGrid

    Dim ximporte As Decimal
    Dim xsalida As Boolean
    Dim xdata_1 As DataTable
    Dim xdata_2 As DataTable
    Dim xbinding_1 As BindingSource
    Dim xbinding_2 As BindingSource
    Dim xcliente As FichaClientes.c_Clientes.c_Registro

    Protected Friend Const SELECT_COBRADORES As String = "SELECT nombre xnombre" & _
                                                                ", auto xauto, * " & _
                                                         "FROM cobradores " & _
                                                         "WHERE estatus='Activo' "

    Property _MontoImporte() As Decimal
        Get
            Return ximporte
        End Get
        Set(ByVal value As Decimal)
            ximporte = value
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

    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
        Get
            Return xcliente
        End Get
        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
            xcliente = value
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

    Sub New(ByVal xcliente As FichaClientes.c_Clientes.c_Registro)
        _FichaCliente = xcliente

        xdata_1 = New DataTable 'Cobradores
        xdata_2 = New DataTable 'Modos De Pago
        xbinding_1 = New BindingSource(xdata_1, "") 'Cobradores
        xbinding_2 = New BindingSource(xdata_2, "") 'Modos De Pago

        _SalidaOk = False
        _MontoImporte = 0
    End Sub

    Sub ActualizarImporte()
        Dim xmonto As Decimal = 0
        For Each xrow As DataRow In xdata_2.Rows
            If xrow.RowState <> DataRowState.Deleted Then
                xmonto += xrow("monto")
            End If
        Next
        _MontoImporte = xmonto
        Me.LB_IMPORTE.Text = String.Format("{0:#0.00}", _MontoImporte)
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IControlAnticipo.Inicializar
        _MiFormulario = xformulario
        LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
        BT_GUARDAR = _MiFormulario.Controls.Find("BT_GUARDAR", True)(0)
        MCB_COBRADOR = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        MT_DETALLE = _MiFormulario.Controls.Find("MT_DETALLE", True)(0)
        MF_FECHA = _MiFormulario.Controls.Find("MF_FECHA", True)(0)
        LK_COBRADOR = _MiFormulario.Controls.Find("LK_COBRADOR", True)(0)
        MisGrid1 = _MiFormulario.Controls.Find("MisGrid1", True)(0)

        Inicializa()
    End Sub

    Sub CargarCobradores()
        Try
            g_MiData.F_GetData(SELECT_COBRADORES, xdata_1)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Inicializa()
        'Cargar / Crear Tablas De Trabajko
        CargarCobradores()
        With xdata_2
            .Columns.Add("TipoPago", GetType(String))
            .Columns.Add("Monto", GetType(Decimal))
            .Columns.Add("Planilla", GetType(String))
            .Columns.Add("Agencia", GetType(String))
            .Columns.Add("AutoTipoPago", GetType(String))
            .Columns.Add("CodigoTipoPago", GetType(String))
            AddHandler .RowChanged, AddressOf ActualizarImporte
            AddHandler .RowDeleted, AddressOf ActualizarImporte
        End With

        With MCB_COBRADOR
            .DataSource = xbinding_1
            .DisplayMember = "xnombre"
            .ValueMember = "xauto"
            .SelectedValue = _FichaCliente.r_AutoCobrador
        End With

        With MisGrid1
            .Columns.Add("col0", "Forma")
            .Columns.Add("col1", "Importe")
            .Columns.Add("col2", "Número")
            .Columns.Add("col3", "Banco")

            .Columns(0).Width = 100
            With .Columns(1)
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "N2"
            End With
            .Columns(2).Width = 90
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xbinding_2
            .Columns(0).DataPropertyName = "tipopago"
            .Columns(1).DataPropertyName = "monto"
            .Columns(2).DataPropertyName = "planilla"
            .Columns(3).DataPropertyName = "agencia"
            .Ocultar(5)

            .AllowUserToDeleteRows = True
        End With

        MF_FECHA.Value = g_MiData.p_FechaDelMotorBD
        Me.LB_IMPORTE.Text = String.Format("{0:#0.00}", 0)
        With Me.MT_DETALLE
            .Text = ""
            .MaxLength = 120
            .Select()
            .Focus()
        End With
    End Sub

    Sub ImprimirRecibo(ByVal xauto As String)
        MessageBox.Show("DOCUMENTO REGISTRADO EXITOSAMENTE", "***Información***", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ImprimirReciboAnticipo(xauto)
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

    Private Sub LK_COBRADOR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LK_COBRADOR.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCobrador.F_Permitir()

            Dim xficha As New FichaCobrador(_FichaCliente.r_AutoCobrador)
            With xficha
                AddHandler xficha.ActualizarFicha, AddressOf CargarCobradores
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub xformulario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles xformulario.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            ProcesarAbono()
        End If
    End Sub

    Public Function ProcesarAbono() As Boolean
        Try
            Dim xrow As DataRow = xdata_2.NewRow
            Dim xficha As New TipoPago(xrow)
            With xficha
                .ShowDialog()
                If ._EstatusSalida Then
                    xdata_2.Rows.Add(xrow)
                    xdata_2.AcceptChanges()
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("CONTROL ANTICIPO" + vbCrLf + "ERROR AL PROCESAR ABONO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub BT_GUARDAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        If ValidarCampos() = True Then
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Grabar Este Registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                Try
                    Grabar()
                    RaiseEvent _DocumentoProcesado()

                    _SalidaOk = True
                    _MiFormulario.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Function ValidarCampos() As Boolean
        If Me.MF_FECHA.Value > g_MiData.p_FechaDelMotorBD Then
            MessageBox.Show("FECHA INCORRECTA, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.MF_FECHA.Select()
            MF_FECHA.Focus()
            Return False
        End If

        If xbinding_1.Current Is Nothing Then
            MessageBox.Show("NO HAY UN COBRADOR POR DEFECTO SELECCIONADO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.MCB_COBRADOR.Select()
            Me.MCB_COBRADOR.Focus()
            Return False
        End If

        If Me.MT_DETALLE.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR EL MOTIVO DEL ANTICIPO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_DETALLE.Select()
            MT_DETALLE.Focus()
            Return False
        End If

        If (Me._MontoImporte = 0) Then
            MessageBox.Show("DEBES CARGAR UN PAGO / ABONO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        Return True
    End Function

    Public Function Grabar() As Boolean
        Try
            Dim xcobrador As New FichaCobradores.c_Cobrador
            Dim xpagoanticipo As New FichaCtasCobrar.c_CxC.c_AgregarPagoAnticipo
            Dim xlistapagos As New List(Of FichaCtasCobrar.c_CxC.c_AgregarPagoAnticipo.Pagos)
            Dim xficha As New FichaCtasCobrar

            Dim xmonto As Decimal = 0
            Dim xrw As DataRow = CType(xbinding_1.Current, DataRowView).Row
            xcobrador.M_CargarRegistro(xrw)

            For Each xrow As DataRow In xdata_2.Rows
                If xrow.RowState <> DataRowState.Deleted Then
                    Dim xmediopago As New FichaGlobal.c_MediosPagos
                    xmediopago.F_BuscarRegistro(xrow("AutoTipoPago"))

                    Dim xpagos As New FichaCtasCobrar.c_CxC.c_AgregarPagoAnticipo.Pagos
                    With xpagos
                        ._Agencia = xrow("agencia")
                        ._MedioPago = xmediopago.RegistroDato
                        ._MontoImporte = xrow("monto")
                        ._MontoRecibido = xrow("monto")
                        ._PlanillaCheque = xrow("planilla")
                    End With
                    xlistapagos.Add(xpagos)
                End If
            Next

            With xpagoanticipo
                ._FechaEmision = MF_FECHA.Value
                ._FichaCliente = _FichaCliente
                ._FichaCobrador = xcobrador.RegistroDato
                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._MontoImporte = _MontoImporte
                ._NotasDetalle = MT_DETALLE.r_Valor
                ._FechaProceso = g_MiData.p_FechaDelMotorBD
                ._ListaPagos = xlistapagos
            End With
            AddHandler xficha.RetornarAutoRecibo, AddressOf ImprimirRecibo
            xficha.F_GrabarAnticipo(xpagoanticipo)
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub MisGrid1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid1.Accion
        Dim xw As DataRow = CType(xbinding_2.Current, DataRowView).Row
        Dim xficha As New TipoPago(xw)
        With xficha
            .ShowDialog()
            If ._EstatusSalida Then
                xbinding_2.Current(0) = ._Registro(0)
                xbinding_2.Current(1) = ._Registro(1)
                xbinding_2.Current(2) = ._Registro(2)
                xbinding_2.Current(3) = ._Registro(3)
                xbinding_2.Current(4) = ._Registro(4)
                xbinding_2.Current(5) = ._Registro(5)
                xdata_2.AcceptChanges()
            End If
        End With
    End Sub
End Class