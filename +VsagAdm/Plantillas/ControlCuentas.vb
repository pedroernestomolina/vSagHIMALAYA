Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports System.ComponentModel

Public Class ControlCuentas
    Dim xplantilla As IControlCuentas

    Enum E_SeleccionCheckBox As Integer
        Activado = 1
        Desactivado = 0
    End Enum

    Sub New(ByVal x_plantilla As IControlCuentas)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        xplantilla = x_plantilla
    End Sub

    Sub IrInicio()
        Me.MT_BUSCAR.Text = ""
        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()
    End Sub

    Sub Inicializar()
        xplantilla.F_Inicializar(Me)
    End Sub

    Private Sub ControlCuentas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (xplantilla._DatosFicha._DocumentosEncontrados > 0) Then
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Salir?, Se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
                IrInicio()
            End If
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub ControlCuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            IrInicio()
        End If

        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            ProcesarPago()
        End If

        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            ProcesarFactura()
        End If

        If e.KeyCode = Keys.F4 AndAlso (e.Alt = False And e.Control = False) Then
            ProcesarNotaDebito()
        End If

        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False And e.Control = False) Then
            ProcesarNotaCredito()
        End If

        If e.KeyCode = Keys.F6 AndAlso (e.Alt = False And e.Control = False) Then
            ProcesarChequeDevuelto()
        End If

        If e.KeyCode = Keys.F7 AndAlso (e.Alt = False And e.Control = False) Then
            ProcesarAnticipo()
        End If
    End Sub

    Private Sub ControlCuentas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ControlCuentas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub BT_BUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR.Click
        xplantilla.F_BuscarAhora(Me.MCB_BUSQUEDA.SelectedIndex, Me.MT_BUSCAR.r_Valor)
        IrInicio()
    End Sub

    Private Sub BT_CHEQUE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CHEQUE.Click
        ProcesarChequeDevuelto()
    End Sub

    Sub ProcesarChequeDevuelto()
        xplantilla.F_ChequeDevuelto()
        IrInicio()
    End Sub

    Private Sub BT_NOTADEBITO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_NOTADEBITO.Click
        ProcesarNotaDebito()
    End Sub

    Sub ProcesarNotaDebito()
        xplantilla.F_NotaDebito()
        IrInicio()
    End Sub

    Private Sub BT_NOTACREDITO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_NOTACREDITO.Click
        ProcesarNotaCredito()
    End Sub

    Sub ProcesarNotaCredito()
        xplantilla.F_NotaCredito()
        IrInicio()
    End Sub

    Private Sub BT_ANTICIPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ANTICIPO.Click
        ProcesarAnticipo()
    End Sub

    Sub ProcesarAnticipo()
        xplantilla.F_Anticipo()
        IrInicio()
    End Sub

    Private Sub BT_PAGO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PAGO.Click
        ProcesarPago()
    End Sub

    Sub ProcesarPago()
        IrInicio()
        xplantilla.F_Pago()
    End Sub

    Private Sub BT_FACTURA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_FACTURA.Click
        ProcesarFactura()
    End Sub

    Sub ProcesarFactura()
        xplantilla.F_Factura()
        IrInicio()
    End Sub

    Private Sub LLB_CIRIF_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLB_CIRIF.LinkClicked
        xplantilla.F_ConsultarFicha()
        IrInicio()
    End Sub

    Private Sub LLB_ACTUALIZAR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLB_ACTUALIZAR.LinkClicked
        xplantilla.F_ActualizarEntidad()
        IrInicio()
    End Sub

    Private Sub BT_LIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_LIMPIAR.Click
        xplantilla.F_LimpiarTodo()
        IrInicio()
    End Sub

    Private Sub MC_TODOS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MC_TODOS.CheckedChanged
        IrInicio()
        If Me.MC_TODOS.Checked = True Then
            xplantilla.F_ActivarDesactivarCheck(E_SeleccionCheckBox.Activado, Me.MisGrid1)
        Else
            xplantilla.F_ActivarDesactivarCheck(E_SeleccionCheckBox.Desactivado, Me.MisGrid1)
        End If
    End Sub

    Private Sub BT_AVANZADA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_AVANZADA.Click
        xplantilla.F_BusquedaAvanzada()
        IrInicio()
    End Sub

    Private Sub ControlCuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IControlCuentas
    Class c_DatosFicha
        Private xauto_entidad As String
        Private xnombre As String
        Private xci_rif As String
        Private xdebito As Decimal
        Private xcredito As Decimal
        Private xlimcred As Decimal
        Private xcredisp As Decimal
        Private xsaldo As Decimal
        Private xanticipo As Decimal
        Private xtotalhaber As Decimal
        Private xtotalimporte As Decimal
        Private xtotaldebe As Decimal
        Private xtotalmonto As Decimal
        Private x_reg_enc_1 As Integer
        Private x_reg_sel As Integer
        Private x_reg_enc_2 As Integer


        Property _AutoEntidad() As String
            Get
                Return xauto_entidad
            End Get
            Set(ByVal value As String)
                xauto_entidad = value
            End Set
        End Property

        Property _NombreRazonSocial() As String
            Get
                Return xnombre
            End Get
            Set(ByVal value As String)
                xnombre = value
            End Set
        End Property

        Property _CiRifEntidad() As String
            Get
                Return xci_rif
            End Get
            Set(ByVal value As String)
                xci_rif = value
            End Set
        End Property

        Property _MontoDebito() As Decimal
            Get
                Return xdebito
            End Get
            Set(ByVal value As Decimal)
                xdebito = value
            End Set
        End Property

        Property _MontoCredito() As Decimal
            Get
                Return xcredito
            End Get
            Set(ByVal value As Decimal)
                xcredito = value
            End Set
        End Property

        Property _MontoSaldo() As Decimal
            Get
                Return xsaldo
            End Get
            Set(ByVal value As Decimal)
                xsaldo = value
            End Set
        End Property

        Property _MontoLimiteCredito() As Decimal
            Get
                Return xlimcred
            End Get
            Set(ByVal value As Decimal)
                xlimcred = value
            End Set
        End Property

        Property _MontoCreditoDisponible() As Decimal
            Get
                Return xcredisp
            End Get
            Set(ByVal value As Decimal)
                xcredisp = value
            End Set
        End Property

        Property _MontoAnticipo() As Decimal
            Get
                Return xanticipo
            End Get
            Set(ByVal value As Decimal)
                xanticipo = value
            End Set
        End Property

        Property _MontoTotalHaber() As Decimal
            Get
                Return xtotalhaber
            End Get
            Set(ByVal value As Decimal)
                xtotalhaber = value
            End Set
        End Property

        Property _MontoTotalImporte() As Decimal
            Get
                Return xtotalimporte
            End Get
            Set(ByVal value As Decimal)
                xtotalimporte = value
            End Set
        End Property

        Property _MontoTotalDebe() As Decimal
            Get
                Return xtotaldebe
            End Get
            Set(ByVal value As Decimal)
                xtotaldebe = value
            End Set
        End Property

        Property _MontoTotal() As Decimal
            Get
                Return xtotalmonto
            End Get
            Set(ByVal value As Decimal)
                xtotalmonto = value
            End Set
        End Property

        Property _DocumentosEncontrados() As Integer
            Get
                Return x_reg_enc_1
            End Get
            Set(ByVal value As Integer)
                x_reg_enc_1 = value
            End Set
        End Property

        Property _DocumentosSeleccionados() As Integer
            Get
                Return x_reg_sel
            End Get
            Set(ByVal value As Integer)
                x_reg_sel = value
            End Set
        End Property

        Property _DocumentosRelacionadosEncontrados() As Integer
            Get
                Return x_reg_enc_2
            End Get
            Set(ByVal value As Integer)
                x_reg_enc_2 = value
            End Set
        End Property

        Sub New()
            xauto_entidad = ""
            xnombre = ""
            xci_rif = ""
            xdebito = 0
            xcredito = 0
            xsaldo = 0
            xlimcred = 0
            xcredisp = 0
            xanticipo = 0
            xtotalhaber = 0
            xtotaldebe = 0
            xtotalimporte = 0
            xtotalmonto = 0
            x_reg_enc_1 = 0
            x_reg_enc_2 = 0
        End Sub
    End Class

    Function F_BuscarAhora(ByVal xcampobusqueda As Integer, ByVal xtexto As String) As Boolean
    Function F_BusquedaAvanzada() As Boolean
    Function F_ChequeDevuelto() As Boolean
    Function F_NotaDebito() As Boolean
    Function F_NotaCredito() As Boolean
    Function F_Anticipo() As Boolean
    Function F_Pago() As Boolean
    Function F_Factura() As Boolean
    Function F_ConsultarFicha() As Boolean
    Function F_LimpiarTodo() As Boolean
    Function F_ActivarDesactivarCheck(ByVal op As Integer, ByVal xdatagrid As MisGrid) As Boolean
    Function F_ActualizarEntidad() As Boolean

    Sub F_Inicializar(ByVal xficha As Object)
    ReadOnly Property _DatosFicha() As c_DatosFicha
End Interface

Class ControlCxC
    Implements IControlCuentas

#Region "FUNCIONES SELECT"
    Protected Friend Const SELECT_DOCUMENTOS_SOLVENTES As String = "SELECT TOP (@top) c.fecha" & _
                                ",(CASE tipo_documento WHEN 'FAC' THEN 'FACTURA' " & _
                                "                      WHEN 'NDF' THEN 'NOTA DÉBITO' " & _
                                "                      WHEN 'NCF' THEN 'NOTA CRÉDITO' " & _
                                "                      WHEN 'ND' THEN 'NOTA DÉBITO' " & _
                                "                      WHEN 'NC' THEN 'NOTA CRÉDITO' " & _
                                "                      WHEN 'CHD' THEN 'CHEQUE DEVUELTO' " & _
                                "                      WHEN 'PRE' THEN 'PRESTAMO' END) tipo" & _
                                ",c.documento" & _
                                ",c.fecha_vencimiento" & _
                                ",0 dias" & _
                                ",c.importe" & _
                                ",c.acumulado haber" & _
                                ",c.resta debe" & _
                                ",0 'check'" & _
                                ",c.detalle " & _
                                ",c.auto " & _
                                ",c.id_seguridad " & _
                                ",* " & _
                             "FROM cxc c " & _
                             "WHERE c.auto_cliente=@auto_entidad and c.cancelado = '1' and c.tipo_documento in ('FAC','NCF','NDF','CHD','ND','PRE','NC') and estatus='0' " & _
                             "ORDER BY c.fecha"
    Protected Friend Const SELECT_DOCUMENTOS_SOLVENTES_RELACIONADOS As String = "select cd.fecha" & _
                                ",cd.tipo" & _
                                ",cd.documento" & _
                                ",cd.operacion" & _
                                ",cd.monto" & _
                                ",cr.cobrador" & _
                                ",cd.detalle" & _
                                ",(CASE cr.estatus WHEN '1' THEN 'ANULADO' ELSE '' END) estatus" & _
                                ",cd.auto_cxc" & _
                                ",auto_cxc_recibo" & _
                                ",numero_recibo recibo " & _
                             "from cxc_documentos cd left join cxc_recibos cr on cd.auto_cxc_recibo=cr.auto " & _
                             "where cd.auto_cxc in (select top(@top) auto " & _
                                                   "from cxc " & _
                                                   "where auto_cliente=@auto_entidad and cancelado = '1' and tipo_documento in ('FAC','NCF','NDF','CHD','ND','PRE','NC') and estatus='0' " & _
                                                   "order by fecha desc) and operacion<>'ANTICIPO' " & _
                             "order by cd.fecha desc"
    Protected Friend Const SELECT_DATA_ENCONTRADA As String = "SELECT TOP (@top) c.fecha" & _
                                ",(CASE tipo_documento WHEN 'FAC' THEN 'FACTURA' " & _
                                "                      WHEN 'NDF' THEN 'NOTA DÉBITO' " & _
                                "                      WHEN 'NCF' THEN 'NOTA CRÉDITO' " & _
                                "                      WHEN 'ND' THEN 'NOTA DÉBITO' " & _
                                "                      WHEN 'NC' THEN 'NOTA CRÉDITO' " & _
                                "                      WHEN 'CHD' THEN 'CHEQUE DEVUELTO' " & _
                                "                      WHEN 'PRE' THEN 'PRESTAMO' END) tipo" & _
                                ",c.documento" & _
                                ",c.fecha_vencimiento" & _
                                ",(case when (datediff(dd,fecha_vencimiento,getDate()))>0 then datediff(day,fecha_vencimiento,getDate()) else 0 end) dias" & _
                                ",c.importe" & _
                                ",c.acumulado haber" & _
                                ",c.resta debe" & _
                                ",0 'check'" & _
                                ",c.detalle " & _
                                ",c.auto " & _
                                ",c.id_seguridad " & _
                                ",* " & _
                             "FROM cxc c " & _
                             "WHERE c.auto_cliente=@auto_entidad and c.cancelado = '0' and c.tipo_documento in ('FAC','NCF','NDF','CHD','ND','PRE','NC') and estatus='0' " & _
                             "ORDER BY c.fecha"
    Protected Friend Const SELECT_DATA_RELACIONADA As String = "select cd.fecha" & _
                                ",cd.tipo" & _
                                ",cd.documento" & _
                                ",cd.operacion" & _
                                ",cd.monto" & _
                                ",cr.cobrador" & _
                                ",cd.detalle" & _
                                ",(CASE cr.estatus WHEN '1' THEN 'ANULADO' ELSE '' END) estatus" & _
                                ",cd.auto_cxc" & _
                                ",auto_cxc_recibo" & _
                                ",numero_recibo recibo " & _
                             "from cxc_documentos cd left join cxc_recibos cr on cd.auto_cxc_recibo=cr.auto " & _
                             "where cd.auto_cxc in (select top(@top) auto " & _
                                                   "from cxc " & _
                                                   "where auto_cliente=@auto_entidad and cancelado = '0' and tipo_documento in ('FAC','NCF','NDF','CHD','ND','PRE','NC') and estatus='0' " & _
                                                   "order by fecha desc) and operacion<>'ANTICIPO' " & _
                             "order by cd.fecha desc"
#End Region

    'LABELS
    Dim LB_DEBITOS As System.Windows.Forms.Label
    Dim LB_CREDITOS As System.Windows.Forms.Label
    Dim LB_CREDDISP As System.Windows.Forms.Label
    Dim LB_SALDO As System.Windows.Forms.Label
    Dim LB_LIMCRED As System.Windows.Forms.Label
    Dim LB_ANTICIPOS As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim LB_ACUMULADO As System.Windows.Forms.Label
    Dim LB_RESTA As System.Windows.Forms.Label
    Dim LB_MONTO As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_E_ITEMS_1 As System.Windows.Forms.Label
    Dim LB_E_ITEMS_2 As System.Windows.Forms.Label
    Dim LB_E_ITEMS_3 As System.Windows.Forms.Label
    'BOTONES
    Dim BT_LIMPIAR As System.Windows.Forms.Button
    'CHECKBOX
    Dim MC_TODOS As System.Windows.Forms.CheckBox
    'COMBOBOX
    WithEvents MCB_BUSQUEDA As MisComboBox
    WithEvents MCB_MOSTRAR As MisComboBox
    WithEvents MCB_TIPODOCUMENTOS As MisComboBox
    'LINKLABEL
    Dim LLB_CIRIF As System.Windows.Forms.LinkLabel
    Dim LLB_ACTUALIZAR As System.Windows.Forms.LinkLabel
    'TOOLTIP
    Dim xToolTip As New System.Windows.Forms.ToolTip()
    'DATGRIDVIEW
    Dim xdatagrid1 As MisGrid
    Dim xdatagrid2 As MisGrid
    'TEXTBOX
    WithEvents MT_BUSCAR As MisTextos

    Dim xtipobusqueda As String() = {"Por Nombre/Razon Social", "Por RIF/CI", "Por Codigo"}
    Dim xestatusdocumento As String() = {"Deudas", "Deudas Vencidas", "Pagos", "Solventes", "Anulados"}
    Dim xtipodocumento As String() = {"Todos", "Facturas", "Notas De Débito", "Notas De Crédito", "Cheques Devueltos", "Prestamos"}

    Dim ds As DataSet
    Dim xdata_1 As DataTable
    Dim xdata_2 As DataTable
    Dim xbinding_1 As BindingSource
    Dim xbinding_2 As BindingSource

    Dim xcliente As FichaClientes
    Dim xdatosficha As IControlCuentas.c_DatosFicha

    Dim _IndicadorDocumentosSolventes As Boolean = False
    Dim _IndicadorNuevoDocumento As Boolean = False
    Dim x_maximo_items_mostrar As Integer


    Property _FichaCliente() As FichaClientes
        Get
            Return xcliente
        End Get
        Set(ByVal value As FichaClientes)
            xcliente = value
        End Set
    End Property

    Property _MaximoItemsMostrar() As Integer
        Get
            Return x_maximo_items_mostrar
        End Get
        Set(ByVal value As Integer)
            x_maximo_items_mostrar = value
        End Set
    End Property

    Enum E_EstatusDocumento As Integer
        MostrarDeudas = 0
        MostrarDeudasVencidas = 1
        MostrarPagos = 2
        MostrarSolventes = 3
        MostrarAnulados = 4
    End Enum

    Enum E_TipoDocumento As Integer
        Todos = 0
        Facturas = 1
        NotaDebito = 2
        NotaCredito = 3
        ChequeDevuelto = 4
        Prestamo = 5
    End Enum

    Enum E_Tipo_Busqueda As Integer
        Nombre = 0
        Ci_rif = 1
        Codigo = 2
    End Enum

    Sub New()
        ds = New DataSet
        xdata_1 = New DataTable("encabezado")
        xdata_2 = New DataTable("detalle")
        ds.Tables.Add(xdata_1)
        ds.Tables.Add(xdata_2)

        _FichaCliente = New FichaClientes
        xdatosficha = New IControlCuentas.c_DatosFicha
        _MaximoItemsMostrar = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCxCobrar._Limite_Renglones_AdmDocumentos
    End Sub

    Sub CargarDataCliente()
        LB_NOMBRE.Text = xdatosficha._NombreRazonSocial
        LB_CIRIF.Text = xdatosficha._CiRifEntidad
        LB_DEBITOS.Text = String.Format("{0:#0.00}", xdatosficha._MontoDebito)
        LB_CREDITOS.Text = String.Format("{0:#0.00}", xdatosficha._MontoCredito)
        LB_LIMCRED.Text = String.Format("{0:#0.00}", xdatosficha._MontoLimiteCredito)
        LB_CREDDISP.Text = String.Format("{0:#0.00}", xdatosficha._MontoCreditoDisponible)
        LB_SALDO.Text = String.Format("{0:#0.00}", xdatosficha._MontoSaldo)
        LB_ANTICIPOS.Text = String.Format("{0:#0.00}", xdatosficha._MontoAnticipo)

        If xdatosficha._AutoEntidad <> "" Then
            EstatusControles(True)
        Else
            EstatusControles(False)
        End If
    End Sub

    Sub CargarTotales()
        With Me
            '.LB_IMPORTE.Text = String.Format("{0:#0.00}", xdatosficha._MontoTotalImporte)
            '.LB_ACUMULADO.Text = String.Format("{0:#0.00}", xdatosficha._MontoTotalHaber)
            .LB_RESTA.Text = String.Format("{0:#0.00}", xdatosficha._MontoTotalDebe)
        End With

        If xdatosficha._DocumentosEncontrados > 0 Then
            MC_TODOS.Visible = True
        Else
            MC_TODOS.Visible = False
        End If
        CargarItems()
    End Sub

    Sub CargarMonto()
        Me.LB_MONTO.Text = String.Format("{0:#0.00}", xdatosficha._MontoTotal)
        CargarItems()
    End Sub

    Sub CargarItems()
        LB_E_ITEMS_1.Text = xdatosficha._DocumentosEncontrados.ToString()
        LB_E_ITEMS_3.Text = xdatosficha._DocumentosRelacionadosEncontrados.ToString()
        LB_E_ITEMS_2.Text = xdatosficha._DocumentosSeleccionados.ToString()
    End Sub

    Sub EstatusControles(ByVal op As Boolean)
        'OCULTAR CONTROLES
        LB_NOMBRE.Visible = op
        LLB_CIRIF.Visible = op
        LB_CIRIF.Visible = op
        BT_LIMPIAR.Visible = op
    End Sub

    Sub InicializarData()
        xdatosficha._AutoEntidad = ""
        xdatosficha._NombreRazonSocial = ""
        xdatosficha._CiRifEntidad = ""
        xdatosficha._MontoDebito = 0
        xdatosficha._MontoCredito = 0
        xdatosficha._MontoSaldo = 0
        xdatosficha._MontoLimiteCredito = 0
        xdatosficha._MontoCreditoDisponible = 0
        xdatosficha._MontoAnticipo = 0
        xdatosficha._MontoTotalImporte = 0
        xdatosficha._MontoTotalHaber = 0
        xdatosficha._MontoTotalDebe = 0
        xdatosficha._MontoTotal = 0
        xdatosficha._DocumentosEncontrados = 0
        xdatosficha._DocumentosSeleccionados = 0
        xdatosficha._DocumentosRelacionadosEncontrados = 0

        MC_TODOS.Checked = False

        CargarDataCliente()
        CargarTotales()
        CargarMonto()
    End Sub

    Sub ActualizarCliente(ByVal xauto As String)
        xcliente.F_BuscarCliente(xauto)
        xdatosficha._AutoEntidad = xauto
        xdatosficha._NombreRazonSocial = xcliente.f_Clientes.RegistroDato.r_NombreRazonSocial
        xdatosficha._CiRifEntidad = xcliente.f_Clientes.RegistroDato.r_CiRif
        xdatosficha._MontoDebito = xcliente.f_Clientes.RegistroDato.r_TotalDebitos
        xdatosficha._MontoCredito = xcliente.f_Clientes.RegistroDato.r_TotalCreditos
        xdatosficha._MontoSaldo = xcliente.f_Clientes.RegistroDato.r_TotalSaldo
        xdatosficha._MontoLimiteCredito = xcliente.f_Clientes.RegistroDato.r_LimiteCreditoPermitido
        xdatosficha._MontoCreditoDisponible = xcliente.f_Clientes.RegistroDato.r_CreditoDisponible
        xdatosficha._MontoAnticipo = xcliente.f_Clientes.RegistroDato.r_TotalAnticipos
        CargarDataCliente()
    End Sub

    Sub ActualizarTotales()
        Dim xtotalimporte As Decimal = 0
        Dim xtotalhaber As Decimal = 0
        Dim xtotaldebe As Decimal = 0
        Dim xtotalmonto As Decimal = 0
        Dim xtotalseleccionados As Decimal = 0

        For Each xrow In xbinding_1.List
            xtotalimporte += xrow("importe")
            xtotalhaber += xrow("haber")
            xtotaldebe += xrow("debe")
        Next

        For Each xrow In xdata_1.Select("check=1")
            xtotalmonto += xrow("debe")
            xtotalseleccionados += 1
        Next

        xdatosficha._MontoTotalImporte = xtotalimporte
        xdatosficha._MontoTotalHaber = xtotalhaber
        xdatosficha._MontoTotalDebe = xtotaldebe
        xdatosficha._MontoTotal = xtotalmonto

        xdatosficha._DocumentosEncontrados = xbinding_1.Count
        xdatosficha._DocumentosSeleccionados = xtotalseleccionados

        CargarTotales()
        CargarMonto()
        ActualizarItems()
    End Sub

    Sub ActualizarItems()
        xdatosficha._DocumentosRelacionadosEncontrados = xbinding_2.List.Count
        CargarItems()
    End Sub

    Sub GetDataCliente(ByVal xauto As String)
        Try
            CargarDataEncontrada(xauto)
            ActualizarCliente(xauto)
            IrADeudas()
            IrATodos()
        Catch ex As Exception
            Throw New Exception("CARGAR DATA CLIENTE" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarDataEncontrada(ByVal xauto As String)
        Try
            xdata_2.Rows.Clear()

            Dim xparam() As SqlParameter = {New SqlParameter("@auto_entidad", xauto), New SqlParameter("@top", _MaximoItemsMostrar)}
            g_MiData.F_GetData(SELECT_DATA_ENCONTRADA, xdata_1, xparam)
            CargarDataRelacionada(xauto)
        Catch ex As Exception
            Throw New Exception("CARGAR DATA ENCONTRADA" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarDataRelacionada(ByVal xauto As String)
        Try
            Dim xparam() As SqlParameter = {New SqlParameter("@auto_entidad", xauto), New SqlParameter("@top", _MaximoItemsMostrar)}
            g_MiData.F_GetData(SELECT_DATA_RELACIONADA, xdata_2, xparam)
        Catch ex As Exception
            Throw New Exception("CARGAR DATA RELACIONADA" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarDocumentosSolventes()
        Try
            Dim xparam() As SqlParameter = {New SqlParameter("@auto_entidad", xcliente.f_Clientes.RegistroDato.r_Automatico), New SqlParameter("@top", _MaximoItemsMostrar)}
            xdata_2.Rows.Clear()

            g_MiData.F_GetData(SELECT_DOCUMENTOS_SOLVENTES, xdata_1, xparam)
            CargarDocumentosSolventesRelacionados()
        Catch ex As Exception
            Throw New Exception("CARGAR DOCUMENTOS SOLVENTES" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarDocumentosSolventesRelacionados()
        Try
            Dim xparam() As SqlParameter = {New SqlParameter("@auto_entidad", xcliente.f_Clientes.RegistroDato.r_Automatico), New SqlParameter("@top", _MaximoItemsMostrar)}
            g_MiData.F_GetData(SELECT_DOCUMENTOS_SOLVENTES_RELACIONADOS, xdata_2, xparam)
        Catch ex As Exception
            Throw New Exception("CARGAR DOCUMENTOS SOLVENTES RELACIONADOS" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub BusquedaCliente(ByVal xtipobusqueda As Integer, ByVal xtexto As String)
        Dim xcampobusqueda As E_Tipo_Busqueda = xtipobusqueda
        Dim xsentencia As String = ""
        Dim xp1 As SqlParameter
        Dim xbuscar As String = ""
        If xtexto <> "" Then

            xsentencia = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where " + xcampobusqueda.ToString() + " like @data order by nombre"

            If xtexto.Substring(0, 1) = "*" Then
                xbuscar = "%" + xtexto.Substring(1)
            Else
                xbuscar = xtexto
            End If

            xp1 = New SqlParameter("@data", xbuscar + "%")
            Dim xficha As New Plantilla_2(New BusquedaCliente, xsentencia, xp1)

            With xficha
                AddHandler .EnviarAuto, AddressOf GetDataCliente
                .ShowDialog()
            End With
        Else
            Throw New Exception("CAMPO VACIO, POR FAVOR VERIFIQUE")
        End If
    End Sub

    Sub AvisoDocumentoProcesado()
        GetDataCliente(xdatosficha._AutoEntidad)
    End Sub

    Sub EfectuarCambios(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If xbinding_1.Current IsNot Nothing Then
            If e.RowIndex <> -1 Then
                If xdatagrid1.Rows(e.RowIndex).Cells("col1").Value <> "NOTA CRÉDITO" Then
                    If xdatagrid1.Columns(e.ColumnIndex).Name = "*" Then
                        If xdatagrid1.Rows(e.RowIndex).Cells("*").Value = "0" Then
                            xdatagrid1.Rows(e.RowIndex).Cells("*").Value = "1"
                        Else
                            xdatagrid1.Rows(e.RowIndex).Cells("*").Value = "0"
                        End If
                        xdata_1.AcceptChanges()
                    End If
                End If
            End If
        End If
    End Sub

    Sub IrADeudas()
        _IndicadorNuevoDocumento = True
        MCB_MOSTRAR.SelectedIndex = E_EstatusDocumento.MostrarDeudas
        _IndicadorNuevoDocumento = False
    End Sub

    Sub IrATodos()
        MCB_TIPODOCUMENTOS.SelectedIndex = E_TipoDocumento.Todos
    End Sub

    Sub MostrarPagos()
        Try
            If xdatosficha._AutoEntidad <> "" Then
                Dim xficha As New MostrarPagos(New c_MostrarPagos(xcliente))
                xficha.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL CARGAR PAGOS:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarAnulaciones()
        Try
            If xdatosficha._AutoEntidad <> "" Then
                Dim xficha As New MostrarPagos(New c_MostrarAnulaciones(xcliente))
                xficha.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL CARGAR PAGOS:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarDocumentosSolventes()
        Try
            If xdatosficha._AutoEntidad <> "" Then
                CargarDocumentosSolventes()
                ActualizarCliente(xcliente.f_Clientes.RegistroDato.r_Automatico)
            End If
        Catch ex As Exception
            Throw New Exception("MOSTRAR DOCUMENTOS SOLVENTES" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub VerDetalleDocumento()
        Try
            Dim xcxc As New FichaCtasCobrar.c_CxC
            Dim xrow As DataRow = CType(xbinding_1.Current, DataRowView).Row
            xcxc.M_CargarRegistro(xrow)

            If xcxc.RegistroDato._AutoMovimientoEntrada <> "" Then
                Dim xficha As New DetalleDocumentosCxC(New c_DetalleDocumentosCxC(xcxc.RegistroDato))
                xficha.ShowDialog()
            Else
                VisualizarDoc_Ventas(xcxc.RegistroDato._AutoDocumento)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function F_CargarDataGridView() As Boolean
        Try
            CargarDataEncontrada("")

            Dim rel As DataRelation = New DataRelation("Encabezado_Detalle", xdata_1.Columns("auto"), xdata_2.Columns("auto_cxc"))
            ds.Relations.Add(rel)

            xbinding_1 = New BindingSource(ds, "encabezado")
            xbinding_2 = New BindingSource(xbinding_1, "Encabezado_Detalle")

            AddHandler xbinding_1.ListChanged, AddressOf ActualizarTotales

            Dim xcheckdatagrid As New DataGridViewCheckBoxColumn
            With xcheckdatagrid
                .Name = "*"
                .ReadOnly = False
            End With
            With xdatagrid1
                .Columns.Add("col0", "F/Emisión")
                .Columns.Add("col1", "T/Documento")
                .Columns.Add("col2", "Documento")
                .Columns.Add("col3", "F/Venc.")
                .Columns.Add("col4", "Dias")
                .Columns.Add("col5", "Importe")
                .Columns.Add("col6", "Haber")
                .Columns.Add("col7", "Debe")
                .Columns.Insert(.Columns.Count, xcheckdatagrid)

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "tipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "fecha_vencimiento"
                .Columns(4).DataPropertyName = "dias"
                .Columns(5).DataPropertyName = "importe"
                .Columns(6).DataPropertyName = "haber"
                .Columns(7).DataPropertyName = "debe"
                .Columns(8).DataPropertyName = "check"

                .DataSource = xbinding_1

                .Columns(0).Width = 80
                .Columns(1).Width = 155
                .Columns(3).Width = 80
                .Columns(4).Width = 50
                .Columns(5).Width = 90
                .Columns(6).Width = 90
                .Columns(7).Width = 90
                .Columns(8).Width = 30
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(10)

                AddHandler .CellFormatting, AddressOf BloquearCelda
                AddHandler xbinding_1.CurrentChanged, AddressOf ActualizarItems
                AddHandler xbinding_1.PositionChanged, AddressOf ActualizarItems
                AddHandler .Accion, AddressOf VerDetalleDocumento
                AddHandler .CellContentClick, AddressOf EfectuarCambios
            End With

            With xdatagrid2
                .Columns.Add("col0", "Fecha")
                .Columns.Add("col1", "T/Documento")
                .Columns.Add("col2", "Documento")
                .Columns.Add("col3", "Operación")
                .Columns.Add("col4", "Monto")
                .Columns.Add("col5", "Cobrador")
                .Columns.Add("col6", "Detalle")
                .Columns.Add("col7", "Estatus")

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "tipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "operacion"
                .Columns(4).DataPropertyName = "monto"
                .Columns(5).DataPropertyName = "cobrador"
                .Columns(6).DataPropertyName = "detalle"
                .Columns(7).DataPropertyName = "estatus"

                .DataSource = xbinding_2

                .Columns(0).Width = 80
                .Columns(1).Width = 100
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                With .Columns(4)
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                .Columns(5).Width = 220
                .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(7).Width = 90

                .Ocultar(9)
                AddHandler .Accion, AddressOf VerDetallePagos
                AddHandler .CellFormatting, AddressOf MiFormato
            End With
        Catch ex As Exception
            Throw New Exception("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL CARGAR DATAGRIDVIEW" + vbCrLf + ex.Message)
        End Try
    End Function

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Dim xgrid As MisGrid = sender
        If xgrid.Rows(e.RowIndex).Cells(7).Value = "ANULADO" Then
            xgrid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Sub VerDetallePagos()
        Dim xficha As New DetallePagos(New c_DetallePagosVentas(xbinding_2.Current("auto_cxc_recibo").ToString))
        xficha.ShowDialog()
    End Sub

    Sub BloquearCelda(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 4 And e.ColumnIndex <= 8 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If xdatagrid1.Rows(e.RowIndex).Cells("col1").Value = "NOTA CRÉDITO" Then
            xdatagrid1.Rows(e.RowIndex).Cells("*").ReadOnly = True
        End If
    End Sub

    Public Function F_BuscarAhora(ByVal xtipobusqueda As Integer, ByVal xtexto As String) As Boolean Implements IControlCuentas.F_BuscarAhora
        If xtexto <> "" Then
            Try
                If (xdatosficha._DocumentosEncontrados > 0) Then
                    Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro de Realizar la Busqueda?, Se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                    If xresultado = Windows.Forms.DialogResult.Yes Then
                        xdata_2.Rows.Clear()
                        xdata_1.Rows.Clear()
                        BusquedaCliente(xtipobusqueda, xtexto)
                    End If
                Else
                    BusquedaCliente(xtipobusqueda, xtexto)
                End If
            Catch ex As Exception
                MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL BUSCAR CLIENTE:" + vbCrLf + ex.Message)
            End Try
        End If
    End Function

    Public Function F_ChequeDevuelto() As Boolean Implements IControlCuentas.F_ChequeDevuelto
        If xdatosficha._AutoEntidad <> "" Then
            Try
                Dim xplantilla As New ControlChequeDevueltoCxc(xcliente.f_Clientes.RegistroDato)
                AddHandler xplantilla._DocumentoProcesado, AddressOf AvisoDocumentoProcesado

                Dim xficha As New ControlChequeDevuelto(xplantilla)
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL CARGAR CHEQUE DEVUELTO:" + vbCrLf + ex.Message, "*** Mensje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function F_NotaCredito() As Boolean Implements IControlCuentas.F_NotaCredito
        If xdatosficha._AutoEntidad <> "" Then
            If xbinding_1.Current IsNot Nothing Then
                If xbinding_1.Current("tipo") = "FACTURA" Or xbinding_1.Current("tipo") = "CHEQUE DEVUELTO" Or xbinding_1.Current("tipo") = "NOTA DÉBITO" Then
                    Try
                        Dim xrw As DataRow = CType(xbinding_1.Current, DataRowView).Row
                        Dim xcxc As New FichaCtasCobrar.c_CxC
                        xcxc.M_CargarRegistro(xrw)

                        Dim xficha As Plantilla_DocumentoEntradaCxC = Nothing
                        If xcxc.RegistroDato._EstatusCancelado = TipoSiNo.Si Then
                            Dim xclas As New c_DocumentoNotaCreditoVentas(xcliente, xrw)
                            AddHandler xclas._DocumentoProcesado, AddressOf AvisoDocumentoProcesado
                            xficha = New Plantilla_DocumentoEntradaCxC(xclas)
                        Else
                            Dim xclas As New c_ModoPagoNotaCreditoVentas(xcliente, xrw)
                            AddHandler xclas._DocumentoProcesado, AddressOf AvisoDocumentoProcesado
                            xficha = New Plantilla_DocumentoEntradaCxC(xclas)
                        End If

                        With xficha
                            .ShowDialog()
                        End With
                    Catch ex As Exception
                        MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL CARGAR NOTA DE CRÉDITO:" + vbCrLf + ex.Message)
                    End Try
                End If
            End If
        End If
    End Function

    Public Function F_NotaDebito() As Boolean Implements IControlCuentas.F_NotaDebito
        If xdatosficha._AutoEntidad <> "" Then
            If xbinding_1.Current IsNot Nothing Then
                If xbinding_1.Current("tipo") = "FACTURA" Or xbinding_1.Current("tipo") = "CHEQUE DEVUELTO" Then
                    Try
                        Dim xrw As DataRow = CType(xbinding_1.Current, DataRowView).Row
                        Dim xclas As New c_ControlNotaDebitoVentas(xcliente, xrw)
                        AddHandler xclas._DocumentoProcesado, AddressOf AvisoDocumentoProcesado

                        Dim xficha As New Plantilla_DocumentoEntradaCxC(xclas)
                        With xficha
                            .ShowDialog()
                        End With
                    Catch ex As Exception
                        MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL CARGAR NOTA DE DÉBITO:" + vbCrLf + ex.Message, "*** Mensje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Function

    Public Function F_Anticipo() As Boolean Implements IControlCuentas.F_Anticipo
        If xdatosficha._AutoEntidad <> "" Then
            Try
                Dim xclas As New c_ControlAnticipoVentas(_FichaCliente.f_Clientes.RegistroDato)
                AddHandler xclas._DocumentoProcesado, AddressOf AvisoDocumentoProcesado

                Dim xficha As New ControlAnticipo(xclas)
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL CARGAR ANTICIPO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function F_Pago() As Boolean Implements IControlCuentas.F_Pago
        If xdatosficha._AutoEntidad <> "" And _IndicadorDocumentosSolventes = False Then
            If xdatosficha._MontoTotal <> 0 Then
                Try
                    Dim xr1 As New FichaCtasCobrar.c_CxC.c_Registro
                    Dim xlista_1 As New List(Of DocumentosPagar)
                    Dim xlista_2 As New BindingList(Of DocumentosNC)
                    Dim xdoc As DocumentosPagar
                    Dim xnc As DocumentosNC

                    For Each xrow In xdata_1.Select("check=1")
                        xr1.CargarFicha(xrow)
                        xdoc = New DocumentosPagar
                        With xdoc
                            ._AutoDocumento = xr1._AutoCxC
                            ._FechaEmision = xr1._FechaProceso
                            ._MontoPendiente = xr1._MontoPorCobrar
                            ._NumeroDocumento = xr1._NumeroDocumento
                            ._IdSeguridad = xr1._IdSeguridad

                            Select Case xr1._TipoDocumento
                                Case "FAC" : ._TipoDocumento = "FACTURA"
                                Case "CHD" : ._TipoDocumento = "CHEQUE DEVUELTO"
                                Case "NDF", "ND" : ._TipoDocumento = "NOTA DE DEBITO"
                                Case "NCF", "NC" : ._TipoDocumento = "NOTA DE CREDITO"
                                Case "PRE" : ._TipoDocumento = "PRESTAMO"
                            End Select
                        End With
                        xlista_1.Add(xdoc)
                    Next

                    For Each xrow In xdata_1.Select("tipo='NOTA CRÉDITO'")
                        xr1.CargarFicha(xrow)
                        xnc = New DocumentosNC
                        With xnc
                            ._AutoDocumento = xr1._AutoCxC
                            ._FechaEmision = xr1._FechaProceso
                            ._MontoImporte = Math.Abs(xr1._MontoPorCobrar)
                            ._NumeroDocumento = xr1._NumeroDocumento
                            ._IdSeguridad = xr1._IdSeguridad
                            ._Estatus = 0
                        End With
                        xlista_2.Add(xnc)
                    Next

                    Dim xclas As New ControlPagosClientes(xcliente.f_Clientes.RegistroDato, xlista_1, xlista_2)
                    AddHandler xclas._DocumentoProcesado, AddressOf AvisoDocumentoProcesado

                    Dim xficha As New ControlPagos(xclas)
                    With xficha
                        .ShowDialog()
                    End With
                Catch ex As Exception
                    MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL CARGAR PAGO:" + vbCrLf + ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("PARA PODER REALIZAR UN PAGO / ABONO DEBES SELECCIONAR UN DOCUMENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Function


    Public Function F_Factura() As Boolean Implements IControlCuentas.F_Factura
        If xdatosficha._AutoEntidad <> "" Then
            Try
                Dim xclas As New ControlFacturasVentas(xcliente)
                AddHandler xclas._DocumentoProcesado, AddressOf AvisoDocumentoProcesado

                Dim xficha As New ControlFacturas(xclas)
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL CARGAR FACTURA:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function F_ConsultarFicha() As Boolean Implements IControlCuentas.F_ConsultarFicha
        Try
            If xdatosficha._AutoEntidad <> "" Then
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCliente.F_Permitir()

                Dim xficha As New FichaCliente(xdatosficha._AutoEntidad)
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Function

    Public Function F_ActivarDesactivarCheck(ByVal op As Integer, ByVal xdatagrid As MisGrid) As Boolean Implements IControlCuentas.F_ActivarDesactivarCheck
        Try
            xbinding_1.MoveFirst()
            For Each xrow As DataGridViewRow In xdatagrid.Rows
                If xrow.Cells("*").Value.ToString <> op And xrow.Cells("col1").Value <> "NOTA CRÉDITO" Then
                    xrow.Cells("*").Value = op
                End If
                xbinding_1.MoveNext()
            Next
            xbinding_1.MoveFirst()
        Catch ex As Exception
            MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL ACTUALIZAR DATAGRIDVIEW:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function F_LimpiarTodo() As Boolean Implements IControlCuentas.F_LimpiarTodo
        Try
            If xdatosficha._AutoEntidad <> "" Then
                Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro Limpiar Todo?, Se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If xresultado = Windows.Forms.DialogResult.Yes Then
                    _FichaCliente.f_Clientes.RegistroDato.M_LimpiarRegistro()
                    xdata_2.Rows.Clear()
                    xdata_1.Rows.Clear()

                    MCB_BUSQUEDA.SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarCliente
                    MCB_MOSTRAR.SelectedIndex = 0
                    MCB_TIPODOCUMENTOS.SelectedIndex = 0

                    InicializarData()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL LIMPIAR DATA:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function F_ActualizarEntidad() As Boolean Implements IControlCuentas.F_ActualizarEntidad
        Try
            If xdatosficha._AutoEntidad <> "" Then
                GetDataCliente(xdatosficha._AutoEntidad)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR DOCUMENTOS DEL CLIENTE:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Sub F_Inicializar(ByVal xficha As Object) Implements IControlCuentas.F_Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xficha

        MT_BUSCAR = _MiFormulario.Controls.Find("MT_BUSCAR", True)(0)
        xdatagrid1 = _MiFormulario.Controls.Find("MisGrid1", True)(0)
        xdatagrid2 = _MiFormulario.Controls.Find("MisGrid2", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_DEBITOS = _MiFormulario.Controls.Find("LB_DEBITOS", True)(0)
        LB_CREDITOS = _MiFormulario.Controls.Find("LB_CREDITOS", True)(0)
        LB_CREDDISP = _MiFormulario.Controls.Find("LB_CREDDISP", True)(0)
        LB_LIMCRED = _MiFormulario.Controls.Find("LB_LIMCRED", True)(0)
        LB_ANTICIPOS = _MiFormulario.Controls.Find("LB_ANTICIPOS", True)(0)
        LB_SALDO = _MiFormulario.Controls.Find("LB_SALDO", True)(0)
        'LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
        'LB_ACUMULADO = _MiFormulario.Controls.Find("LB_HABER", True)(0)
        LB_RESTA = _MiFormulario.Controls.Find("LB_DEBE", True)(0)
        LB_MONTO = _MiFormulario.Controls.Find("LB_MONTO", True)(0)
        LB_E_ITEMS_1 = _MiFormulario.Controls.Find("E_ITEMS_1", True)(0)
        LB_E_ITEMS_2 = _MiFormulario.Controls.Find("E_ITEMS_2", True)(0)
        LB_E_ITEMS_3 = _MiFormulario.Controls.Find("E_ITEMS_3", True)(0)
        BT_LIMPIAR = _MiFormulario.Controls.Find("BT_LIMPIAR", True)(0)
        MC_TODOS = _MiFormulario.Controls.Find("MC_TODOS", True)(0)
        MCB_BUSQUEDA = _MiFormulario.Controls.Find("MCB_BUSQUEDA", True)(0)
        MCB_MOSTRAR = _MiFormulario.Controls.Find("MCB_MOSTRAR", True)(0)
        MCB_TIPODOCUMENTOS = _MiFormulario.Controls.Find("MCB_TIPODOCUMENTOS", True)(0)
        LLB_CIRIF = _MiFormulario.Controls.Find("LLB_CIRIF", True)(0)
        LLB_ACTUALIZAR = _MiFormulario.Controls.Find("LLB_ACTUALIZAR", True)(0)
        xToolTip.SetToolTip(LLB_CIRIF, "Ir A Ficha De Clientes")
        xToolTip.SetToolTip(LLB_ACTUALIZAR, "Actualizar Movimientos Del Cliente")
        _MiFormulario.Text = "Control De Cuentas Por Cobrar"

        InicializarData()
        'CARGAR COMBOS PLANTILLA
        With MCB_BUSQUEDA
            .DataSource = xtipobusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarCliente
        End With

        With MCB_MOSTRAR
            .DataSource = xestatusdocumento
            .SelectedIndex = 0
        End With

        With MCB_TIPODOCUMENTOS
            .DataSource = xtipodocumento
            .SelectedIndex = 0
        End With

        'CARGAR GRIDS PLANTILLAS
        F_CargarDataGridView()

        'CREAR LOS EVENTOS CORRESPONDIENTES
        AddHandler xdata_1.TableCleared, AddressOf InicializarData
        AddHandler xdata_1.RowChanged, AddressOf ActualizarTotales
        AddHandler xdata_2.RowChanged, AddressOf ActualizarItems
        AddHandler xdata_2.TableCleared, AddressOf ActualizarItems
    End Sub

    Public ReadOnly Property _DatosFicha() As IControlCuentas.c_DatosFicha Implements IControlCuentas._DatosFicha
        Get
            Return xdatosficha
        End Get
    End Property

    Public Function F_BusquedaAvanzada() As Boolean Implements IControlCuentas.F_BusquedaAvanzada
        Try
            Dim xclase As New c_CxC_BusquedaAvanzada
            AddHandler xclase.RetornarAutoCliente, AddressOf GetDataCliente
            Dim xficha As New CxC_BusquedaAvanzada(xclase)
            xficha.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR FORMULARIO DE BUSQUEDA AVANZADA" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub MCB_TIPODOCUMENTOS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCB_TIPODOCUMENTOS.SelectedIndexChanged
        If xdatosficha._AutoEntidad <> "" Then
            Try
                Select Case MCB_TIPODOCUMENTOS.SelectedIndex
                    Case E_TipoDocumento.Todos
                        xbinding_1.Filter = "tipo<>''"
                    Case E_TipoDocumento.Facturas
                        xbinding_1.Filter = "tipo='FACTURA'"
                    Case E_TipoDocumento.NotaDebito
                        xbinding_1.Filter = "tipo='NOTA DÉBITO'"
                    Case E_TipoDocumento.NotaCredito
                        xbinding_1.Filter = "tipo='NOTA CRÉDITO'"
                    Case E_TipoDocumento.ChequeDevuelto
                        xbinding_1.Filter = "tipo='CHEQUE DEVUELTO'"
                    Case E_TipoDocumento.Prestamo
                        xbinding_1.Filter = "tipo='PRESTAMO'"
                End Select
            Catch ex As Exception
                MessageBox.Show("ERROR AL ACTUALIZAR TIPO DE DOCUMENTOS:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        IrInicio()
    End Sub

    Sub IrInicio()
        Me.MT_BUSCAR.Text = ""
        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()
    End Sub

    Private Sub MCB_BUSQUEDA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCB_BUSQUEDA.SelectedIndexChanged
        IrInicio()
    End Sub

    Private Sub MCB_MOSTRAR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCB_MOSTRAR.SelectedIndexChanged
        F_ActualizarEstatusDocumento(Me.MCB_MOSTRAR.SelectedIndex)
        IrInicio()
    End Sub

    Public Function F_ActualizarEstatusDocumento(ByVal xindice As Integer) As Boolean
        Try
            If xdatosficha._AutoEntidad <> "" Then
                If xindice = E_EstatusDocumento.MostrarPagos Then
                    MostrarPagos()
                Else
                    If xindice = E_EstatusDocumento.MostrarAnulados Then
                        MostrarAnulaciones()
                    Else
                        If xindice = E_EstatusDocumento.MostrarSolventes Then
                            MostrarDocumentosSolventes()
                        Else
                            If _IndicadorNuevoDocumento = False Then
                                GetDataCliente(xdatosficha._AutoEntidad)
                                Select Case xindice
                                    Case E_EstatusDocumento.MostrarDeudas
                                        xbinding_1.Filter = "fecha <= '" + g_MiData.p_FechaDelMotorBD.ToShortDateString() + "' "
                                    Case E_EstatusDocumento.MostrarDeudasVencidas
                                        xbinding_1.Filter = "fecha_vencimiento < '" + g_MiData.p_FechaDelMotorBD.ToShortDateString() + "' "
                                End Select
                            Else
                                If _IndicadorDocumentosSolventes Then
                                    GetDataCliente(xdatosficha._AutoEntidad)
                                    _IndicadorDocumentosSolventes = False
                                End If
                                Select Case xindice
                                    Case E_EstatusDocumento.MostrarDeudas
                                        xbinding_1.Filter = "fecha <= '" + g_MiData.p_FechaDelMotorBD.ToShortDateString() + "' "
                                    Case E_EstatusDocumento.MostrarDeudasVencidas
                                        xbinding_1.Filter = "fecha_vencimiento < '" + g_MiData.p_FechaDelMotorBD.ToShortDateString() + "' "
                                End Select
                            End If
                        End If
                    End If
                End If
            Else
                IrADeudas()
            End If
        Catch ex As Exception
            MessageBox.Show("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL BUSCAR DOCUMENTOS:" + vbCrLf + ex.Message)
        End Try
    End Function
End Class