Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports System.ComponentModel

Public Class ControlCuentasxPagar
    Dim xplantilla As IControlCxP

    Property _MiPlantilla() As IControlCxP
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IControlCxP)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplan As IControlCxP)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _MiPlantilla = xplan
    End Sub

    Sub Inicializar()
        Try
            _MiPlantilla.Inicializar(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub ControlCuentasxPagar_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializar()
    End Sub
End Class

Public Interface IControlCxP
    Sub Inicializar(ByVal xficha As Object)
End Interface

Class c_ControlCxP
    Implements IControlCxP

    'MIS CONTROLES
    WithEvents LB_1 As System.Windows.Forms.Label
    WithEvents LB_2 As System.Windows.Forms.Label
    WithEvents LB_3 As System.Windows.Forms.Label
    WithEvents LB_4 As System.Windows.Forms.Label
    WithEvents LB_5 As System.Windows.Forms.Label
    WithEvents LB_6 As System.Windows.Forms.Label
    WithEvents LB_7 As System.Windows.Forms.Label
    WithEvents LB_8 As System.Windows.Forms.Label
    WithEvents LB_9 As System.Windows.Forms.Label
    WithEvents LB_10 As System.Windows.Forms.Label
    WithEvents LB_11 As System.Windows.Forms.Label
    WithEvents LB_12 As System.Windows.Forms.Label
    WithEvents LB_13 As System.Windows.Forms.Label
    WithEvents LB_14 As System.Windows.Forms.Label
    WithEvents LB_15 As System.Windows.Forms.Label
    WithEvents BT_1 As System.Windows.Forms.Button
    WithEvents BT_2 As System.Windows.Forms.Button
    WithEvents BT_3 As System.Windows.Forms.Button
    WithEvents BT_4 As System.Windows.Forms.Button
    WithEvents BT_5 As System.Windows.Forms.Button
    WithEvents BT_6 As System.Windows.Forms.Button
    WithEvents CHK_1 As System.Windows.Forms.CheckBox
    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents LLB_1 As System.Windows.Forms.LinkLabel
    WithEvents LLB_2 As System.Windows.Forms.LinkLabel
    WithEvents xToolTip As New System.Windows.Forms.ToolTip()
    WithEvents G_1 As MisGrid
    WithEvents G_2 As MisGrid
    WithEvents T_1 As MisTextos
    WithEvents _MiFormulario As Windows.Forms.Form

    Enum E_EstatusDocumento As Integer
        MostrarDeudas = 0
        MostrarDeudasVencidas = 1
        MostrarPagos = 2
        MostrarSolventes = 3
        MostrarAnulados = 4
    End Enum

    Enum E_TipoDocumento As Integer
        Todos = 0
        Factura = 1
        NotaDebito = 2
        NotaCredito = 3
        ChequeDevuelto = 4
    End Enum

    Dim xtipobusqueda As String() = {"Por Nombre/Razon Social", "Por RIF/CI", "Por Codigo"}
    Dim xestatusdocumento As String() = {"Deudas", "Deudas Vencidas", "Pagos", "Solventes", "Anulados"}
    Dim xtipodocumento As String() = {"Todos", "Compras", "Notas De Débito", "Notas De Crédito", "Cheques Devueltos"}

    Dim ds As DataSet
    Dim xtb_1 As DataTable
    Dim xtb_2 As DataTable
    Dim xbs_1 As BindingSource
    Dim xbs_2 As BindingSource

    Dim xproveedor As FichaProveedores

    Dim _IndicadorDocumentosSolventes As Boolean = False
    Dim _IndicadorNuevoDocumento As Boolean = False
    Dim x_maximo_items_mostrar As Integer
    Dim xmonto As Decimal

    Property _MontoTotal() As Decimal
        Get
            Return xmonto
        End Get
        Set(ByVal value As Decimal)
            xmonto = value
        End Set
    End Property

    Property _MiFichaProveedor() As FichaProveedores
        Get
            Return xproveedor
        End Get
        Set(ByVal value As FichaProveedores)
            xproveedor = value
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

    'BUSQUEDAS RAPIDAS PARA EL PROVEEDOR
    Const Busqueda_1 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from proveedores where nombre like @data order by nombre"
    Const Busqueda_2 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from proveedores where ci_rif like @data order by nombre"
    Const Busqueda_3 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from proveedores where codigo like @data order by nombre"

    Sub New()
        ds = New DataSet
        xtb_1 = New DataTable("encabezado")
        xtb_2 = New DataTable("detalle")
        ds.Tables.Add(xtb_1)
        ds.Tables.Add(xtb_2)
        _MiFichaProveedor = New FichaProveedores
        _MaximoItemsMostrar = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCxPagar._Limite_Renglones_AdmDocumentos
    End Sub

    Public Sub Inicializar(ByVal xficha As Object) Implements IControlCxP.Inicializar
        _MiFormulario = xficha

        T_1 = _MiFormulario.Controls.Find("MT_BUSCAR", True)(0)
        G_1 = _MiFormulario.Controls.Find("MisGrid1", True)(0)
        G_2 = _MiFormulario.Controls.Find("MisGrid2", True)(0)
        LB_1 = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_2 = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_3 = _MiFormulario.Controls.Find("LB_DEBITOS", True)(0)
        LB_4 = _MiFormulario.Controls.Find("LB_CREDITOS", True)(0)
        LB_5 = _MiFormulario.Controls.Find("LB_CREDDISP", True)(0)
        LB_6 = _MiFormulario.Controls.Find("LB_LIMCRED", True)(0)
        LB_7 = _MiFormulario.Controls.Find("LB_ANTICIPOS", True)(0)
        LB_8 = _MiFormulario.Controls.Find("LB_SALDO", True)(0)
        LB_9 = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
        LB_10 = _MiFormulario.Controls.Find("LB_HABER", True)(0)
        LB_11 = _MiFormulario.Controls.Find("LB_DEBE", True)(0)
        LB_12 = _MiFormulario.Controls.Find("LB_MONTO", True)(0)
        LB_13 = _MiFormulario.Controls.Find("E_ITEMS_1", True)(0)
        LB_14 = _MiFormulario.Controls.Find("E_ITEMS_2", True)(0)
        LB_15 = _MiFormulario.Controls.Find("E_ITEMS_3", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_BUSCAR", True)(0)
        BT_2 = _MiFormulario.Controls.Find("BT_AVANZADA", True)(0)
        BT_3 = _MiFormulario.Controls.Find("BT_LIMPIAR", True)(0)
        BT_4 = _MiFormulario.Controls.Find("BT_PAGO", True)(0)
        BT_5 = _MiFormulario.Controls.Find("BT_NUEVODOCUMENTO", True)(0)
        BT_6 = _MiFormulario.Controls.Find("BT_NOTADEBITO", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_BUSQUEDA", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_MOSTRAR", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_TIPODOCUMENTOS", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MC_TODOS", True)(0)
        LLB_1 = _MiFormulario.Controls.Find("LLB_CIRIF", True)(0)
        LLB_2 = _MiFormulario.Controls.Find("LLB_ACTUALIZAR", True)(0)
        xToolTip.SetToolTip(LLB_1, "Ir A Ficha De Proveedores")
        xToolTip.SetToolTip(LLB_2, "Actualizar Movimientos Del Proveedor")
        _MiFormulario.Text = "Control De Cuentas Por Pagar"

        InicializarControles()
    End Sub

    Sub LimpiarControles()
        LB_1.Text = ""
        LB_2.Text = ""
        LB_3.Text = "0.00"
        LB_4.Text = "0.00"
        LB_5.Text = "0.00"
        LB_6.Text = "0.00"
        LB_7.Text = "0.00"
        LB_8.Text = "0.00"
        LB_9.Text = "0.00"
        LB_10.Text = "0.00"
        LB_11.Text = "0.00"
        LB_12.Text = "0.00"
        LB_13.Text = "0"
        LB_14.Text = "0"
        LB_15.Text = "0"

        CHK_1.Checked = False
        CB_1.SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProveedor
        CB_2.SelectedIndex = 0
        CB_3.SelectedIndex = 0
        Me._MiFichaProveedor.f_Proveedor.M_LimpiarRegistro()

        xtb_2.Rows.Clear()
        xtb_1.Rows.Clear()
    End Sub

    Sub InicializarControles()

        LB_1.Text = ""
        LB_2.Text = ""
        LB_3.Text = "0.00"
        LB_4.Text = "0.00"
        LB_5.Text = "0.00"
        LB_6.Text = "0.00"
        LB_7.Text = "0.00"
        LB_8.Text = "0.00"
        LB_9.Text = "0.00"
        LB_10.Text = "0.00"
        LB_11.Text = "0.00"
        LB_12.Text = "0.00"
        LB_13.Text = "0"
        LB_14.Text = "0"
        LB_15.Text = "0"

        With CB_1
            .DataSource = xtipobusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProveedor
        End With

        With CB_2
            .DataSource = xestatusdocumento
            .SelectedIndex = 0
        End With

        With CB_3
            .DataSource = xtipodocumento
            .SelectedIndex = 0
        End With

        CargarDataEncontrada("")
        Dim rel As DataRelation = New DataRelation("Encabezado_Detalle", xtb_1.Columns("auto"), xtb_2.Columns("auto_cxp"))
        ds.Relations.Add(rel)
        xbs_1 = New BindingSource(ds, "encabezado")
        xbs_2 = New BindingSource(xbs_1, "Encabezado_Detalle")
        AddHandler xbs_1.ListChanged, AddressOf ActualizarTotales

        Dim xcheckdatagrid As New DataGridViewCheckBoxColumn
        With xcheckdatagrid
            .Name = "*"
            .ReadOnly = False
        End With

        With G_1
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

            .DataSource = xbs_1

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

            AddHandler xbs_1.CurrentChanged, AddressOf ActualizarItems
            AddHandler xbs_1.PositionChanged, AddressOf ActualizarItems
            AddHandler .Accion, AddressOf VerDetalleDocumento
            AddHandler .CellFormatting, AddressOf MiFormato
            AddHandler .CellContentClick, AddressOf EfectuarCambios
        End With

        With G_2
            .Columns.Add("col0", "Fecha")
            .Columns.Add("col1", "T/Documento")
            .Columns.Add("col2", "Documento")
            .Columns.Add("col3", "Operación")
            .Columns.Add("col4", "Monto")
            .Columns.Add("col5", "Detalle")
            .Columns.Add("col6", "Estatus")

            .Columns(0).DataPropertyName = "fecha"
            .Columns(1).DataPropertyName = "tipo"
            .Columns(2).DataPropertyName = "documento"
            .Columns(3).DataPropertyName = "operacion"
            .Columns(4).DataPropertyName = "monto"
            .Columns(5).DataPropertyName = "detalle"
            .Columns(6).DataPropertyName = "estatus"

            .DataSource = xbs_2

            .Columns(0).Width = 80
            .Columns(1).Width = 100
            .Columns(2).Width = 100
            .Columns(3).Width = 100
            With .Columns(4)
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(6).Width = 90

            .Ocultar(8)
            AddHandler .Accion, AddressOf VerDetallePagos
            AddHandler .CellFormatting, AddressOf MiFormato2
        End With

        IrInicio()
    End Sub

    Sub VerDetalleDocumento()
        Try
            Dim xcxp As New FichaCtasPagar.c_CxP
            Dim xrow As DataRow = CType(xbs_1.Current, DataRowView).Row
            xcxp.M_CargarRegistro(xrow)

            If xcxp.RegistroDato._AutoMovimientoEntrada <> "" Then
                Dim xficha As New DetalleDocumentosCxC(New c_DetalleDocumentosCxP(xcxp.RegistroDato))
                xficha.ShowDialog()
            Else
                Dim xcompra As New FichaCompras.c_Compra
                xcompra.F_CargarCompra(xcxp.RegistroDato._AutoDocumento)
                If xcompra.RegistroDato._TipoCompraRegistrada = TipoCompraRegistrada.CompraMercancia Then
                    VisualizarDoc_Compras(xcxp.RegistroDato._AutoDocumento)
                Else
                    VisualizarDoc_Gastos(xcxp.RegistroDato._AutoDocumento)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub VerDetallePagos()
        'Try
        '    Dim xrow As DataRow = CType(xbs_2.Current, DataRowView).Row
        '    Dim xauto As String = xrow("auto_cxp_recibo")

        '    If Not IsDBNull(xrow("tipo_pago")) Then
        '        Select Case CType(xrow("tipo_pago"), DataSistema.MiDataSistema.DataSistema.TipoPago)
        '            Case DataSistema.MiDataSistema.DataSistema.TipoPago.Cheque
        '                Dim xp1 As New SqlParameter("@auto", xauto)
        '                Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp1)
        '                VisualizarComprobanteEgreso(xauto_mov)
        '            Case DataSistema.MiDataSistema.DataSistema.TipoPago.Transferencia
        '                Dim xp1 As New SqlParameter("@auto", xauto)
        '                Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp1)
        '                VisualizarComprobanteEgresoGeneral(xauto_mov)
        '            Case DataSistema.MiDataSistema.DataSistema.TipoPago.NotaCredito
        '                VisualizarReciboCxP(xauto)
        '            Case DataSistema.MiDataSistema.DataSistema.TipoPago.Retencion
        '                Dim xp1 As New SqlParameter("@auto", xauto)
        '                Dim xauto_ret As String = F_GetString("select auto from retenciones_compras where auto_recibo_cxp=@auto", xp1)
        '                VisualizarRet_Compras(xauto_ret)
        '        End Select
        '    Else
        '        VisualizarReciboCxP(xauto)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Sub EfectuarCambios(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If xbs_1.Current IsNot Nothing Then
            If e.RowIndex <> -1 Then
                If G_1.Rows(e.RowIndex).Cells("col1").Value <> "NOTA CRÉDITO" Then
                    If e.ColumnIndex = 8 Then
                        If G_1.CurrentCell.Value = 0 Then
                            G_1.CurrentCell.Value = 1
                        Else
                            G_1.CurrentCell.Value = 0
                        End If
                        G_1.EndEdit()
                        xtb_1.AcceptChanges()
                        ActualizarTotales()
                    End If
                End If
            End If
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 4 And e.ColumnIndex <= 7 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If G_1.Rows(e.RowIndex).Cells("col1").Value = "NOTA CRÉDITO" Then
            G_1.Rows(e.RowIndex).Cells("*").ReadOnly = True
        End If
    End Sub

    Sub MiFormato2(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If G_2.Rows(e.RowIndex).Cells(6).Value = "ANULADO" Then
            G_2.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Sub CargarDataEncontrada(ByVal xauto As String)
        Try
            Dim xsql As String = "SELECT TOP (@top) c.fecha" & _
                                 ",      (CASE tipo_documento WHEN 'FAC' THEN 'COMPRA' " & _
                                            "                      WHEN 'NDF' THEN 'NOTA DÉBITO' " & _
                                            "                      WHEN 'NCF' THEN 'NOTA CRÉDITO' " & _
                                            "                      WHEN 'ND' THEN 'NOTA DÉBITO' " & _
                                            "                      WHEN 'NC' THEN 'NOTA CRÉDITO' " & _
                                            "                      WHEN 'CHD' THEN 'CHEQUE DEVUELTO' END) tipo" & _
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
                                 "FROM cxp c " & _
                                 "WHERE c.auto_proveedor=@auto_entidad and c.cancelado = '0' and c.tipo_documento in ('FAC','NCF','NDF','CHD','ND','NC') and estatus='0' " & _
                                 "ORDER BY c.fecha"

            xtb_2.Rows.Clear()
            Dim xp1 As New SqlParameter("@auto_entidad", xauto)
            Dim xp2 As New SqlParameter("@top", _MaximoItemsMostrar)
            g_MiData.F_GetData(xsql, xtb_1, xp1, xp2)
            CargarDataRelacionada(xauto)
        Catch ex As Exception
            Throw New Exception("CARGAR DATA ENCONTRADA" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarDataRelacionada(ByVal xauto As String)
        Try
            Dim xsql As String = "select cd.fecha" & _
                                        ",cd.tipo" & _
                                        ",cd.documento" & _
                                        ",cd.operacion" & _
                                        ",cd.monto" & _
                                        ",cd.detalle" & _
                                        ",(CASE cr.estatus WHEN '1' THEN 'ANULADO' ELSE '' END) estatus" & _
                                        ",auto_cxp" & _
                                        ",auto_cxp_recibo" & _
                                        ",numero_recibo recibo " & _
                                        ",tipo_pago " & _
                                 "from cxp_documentos cd left join cxp_recibos cr on cd.auto_cxp_recibo=cr.auto " & _
                                 "where cd.auto_cxp in (select top(@top) auto " & _
                                                               "from cxp " & _
                                                               "where auto_proveedor=@auto_entidad and cancelado = '0' and tipo_documento in ('FAC','NCF','NDF','CHD','ND','PRE','NC') and estatus='0' " & _
                                                               "order by fecha desc) and operacion<>'ANTICIPO' " & _
                                 "order by cd.fecha desc"

            Dim xp1 As New SqlParameter("@auto_entidad", xauto)
            Dim xp2 As New SqlParameter("@top", _MaximoItemsMostrar)
            g_MiData.F_GetData(xsql, xtb_2, xp1, xp2)
        Catch ex As Exception
            Throw New Exception("CARGAR DATA RELACIONADA" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub ActualizarTotales()
        Dim xtotalimporte As Decimal = 0
        Dim xtotalhaber As Decimal = 0
        Dim xtotaldebe As Decimal = 0
        Dim xtotalmonto As Decimal = 0

        For Each xrow In xbs_1.List
            xtotalimporte += xrow("importe")
            xtotalhaber += xrow("haber")
            xtotaldebe += xrow("debe")
        Next

        For Each xrow In xtb_1.Select("check=1")
            xtotalmonto += xrow("debe")
        Next

        _MontoTotal = xtotalmonto

        LB_9.Text = String.Format("{0:#0.00}", xtotalimporte)
        LB_10.Text = String.Format("{0:#0.00}", xtotalhaber)
        LB_11.Text = String.Format("{0:#0.00}", xtotaldebe)
        LB_12.Text = String.Format("{0:#0.00}", xtotalmonto)


        ActualizarItems()
    End Sub

    Sub ActualizarItems()
        LB_13.Text = xbs_1.Count.ToString
        LB_14.Text = xbs_2.Count.ToString
        LB_15.Text = xtb_1.Select("check=1").Count.ToString
    End Sub

    Sub IrInicio()
        T_1.Text = ""
        T_1.Select()
        T_1.Focus()
    End Sub

    Sub IrDeudas()
        _IndicadorNuevoDocumento = True
        CB_2.SelectedIndex = E_EstatusDocumento.MostrarDeudas
        _IndicadorNuevoDocumento = False
    End Sub

    Sub IrTodos()
        CB_3.SelectedIndex = E_TipoDocumento.Todos
    End Sub

    Private Sub ControlCxP_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles _MiFormulario.FormClosing
        If (xtb_1.Rows.Count > 0) Then
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

    Private Sub ControlCxP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _MiFormulario.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            IrInicio()
        End If

        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            'EfectuarPago()
            Funciones.MensajeDeAlerta("Esta Opcion Esta Solo Disponible Para Aquellos Clientes Que Manejen El Modulo De Control De Bancos, En Caso Contrario No Se Podra Usar")
        End If

        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            EfectuarNuevoDocumento()
        End If

        If e.KeyCode = Keys.F4 AndAlso (e.Alt = False And e.Control = False) Then
            'EfectuarNotaDebito()
            Funciones.MensajeDeAlerta("Esta Opcion Esta Solo Disponible Para Aquellos Clientes Que Manejen El Modulo De Control De Bancos, En Caso Contrario No Se Podra Usar")
        End If
    End Sub

    Private Sub ControlCxP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _MiFormulario.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            _MiFormulario.Close()
        End If
    End Sub

    Private Sub LLB_1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLB_1.LinkClicked
        Try
            If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor.F_Permitir()

                Dim xficha As New FichaProveedor(_MiFichaProveedor.f_Proveedor.RegistroDato._Automatico)
                With xficha
                    .ShowDialog()
                End With
            End If
            IrInicio()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub LLB_2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLB_2.LinkClicked
        Try
            If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
                Dim xauto As String = _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico
                LimpiarControles()
                CargarDataEntidad(xauto)
            End If
            IrInicio()
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR DOCUMENTOS DEL PROVEEDOR:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CHK_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_1.CheckedChanged
        If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
            If xtb_1.Rows.Count > 0 Then
                Try
                    Dim op As Boolean = CHK_1.Checked

                    xbs_1.MoveFirst()
                    For Each xrow As DataGridViewRow In G_1.Rows
                        If CType(xrow.Cells("*").Value, Boolean) <> op And xrow.Cells("col1").Value <> "NOTA CRÉDITO" Then
                            xrow.Cells("*").Value = op
                        End If
                        xbs_1.MoveNext()
                    Next
                    xbs_1.MoveFirst()
                    ActualizarTotales()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub CB_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_1.SelectedIndexChanged
        IrInicio()
    End Sub

    Private Sub CB_2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_2.SelectedIndexChanged
        Me.CHK_1.Checked = False
        ActualizarEstatusDocumento()
        IrInicio()
    End Sub

    Sub ActualizarEstatusDocumento()
        Try
            If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
                Select Case CType(CB_2.SelectedIndex, E_EstatusDocumento)
                    Case E_EstatusDocumento.MostrarPagos
                        MostrarPagos()
                    Case E_EstatusDocumento.MostrarAnulados
                        MostrarAnulaciones()
                    Case E_EstatusDocumento.MostrarSolventes
                        MostrarDocumentosSolventes()
                    Case E_EstatusDocumento.MostrarDeudas
                        If _IndicadorNuevoDocumento = False Then
                            CargarDataEntidad(_MiFichaProveedor.f_Proveedor.RegistroDato._Automatico)
                            xbs_1.Filter = "fecha <= '" + g_MiData.p_FechaDelMotorBD.ToShortDateString() + "' "
                        Else
                            If _IndicadorDocumentosSolventes Then
                                CargarDataEntidad(_MiFichaProveedor.f_Proveedor.RegistroDato._Automatico)
                                _IndicadorDocumentosSolventes = False
                            End If
                            xbs_1.Filter = "fecha <= '" + g_MiData.p_FechaDelMotorBD.ToShortDateString() + "' "
                        End If
                        IrTodos()
                    Case E_EstatusDocumento.MostrarDeudasVencidas
                        If _IndicadorNuevoDocumento = False Then
                            CargarDataEntidad(_MiFichaProveedor.f_Proveedor.RegistroDato._Automatico)
                            xbs_1.Filter = "fecha_vencimiento < '" + g_MiData.p_FechaDelMotorBD.ToShortDateString() + "' "
                        Else
                            If _IndicadorDocumentosSolventes Then
                                CargarDataEntidad(_MiFichaProveedor.f_Proveedor.RegistroDato._Automatico)
                                _IndicadorDocumentosSolventes = False
                            End If
                            xbs_1.Filter = "fecha_vencimiento < '" + g_MiData.p_FechaDelMotorBD.ToShortDateString() + "' "
                        End If
                        IrTodos()
                End Select
            Else
                IrDeudas()
            End If
        Catch ex As Exception
            MessageBox.Show("CUENTAS POR PAGAR" + vbCrLf + "ERROR AL BUSCAR DOCUMENTOS:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarPagos()
        Try
            If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
                Dim xficha As New MostrarPagos(New c_MostrarPagosCxP(_MiFichaProveedor))
                xficha.ShowDialog()
            End If
        Catch ex As Exception
            Throw New Exception("ERROR AL MOSTRAR PAGOS:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub MostrarAnulaciones()
        Try
            If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
                Dim xficha As New MostrarPagos(New c_MostrarAnulacionesCxP(_MiFichaProveedor))
                xficha.ShowDialog()
            End If
        Catch ex As Exception
            Throw New Exception("ERROR AL MOSTRAR DOCUMENTOS ANULADOS:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub MostrarDocumentosSolventes()
        Try
            If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
                CargarDocumentosSolventes(_MiFichaProveedor.f_Proveedor.RegistroDato._Automatico)
                IrInicio()
                IrTodos()
            End If
        Catch ex As Exception
            Throw New Exception("ERROR AL MOSTRAR DOCUMENTOS SOLVENTES:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarDocumentosSolventes(ByVal xauto As String)
        Try
            Dim xsql As String = "SELECT TOP (@top) c.fecha" & _
                                                    ",(CASE tipo_documento WHEN 'FAC' THEN 'COMPRA' " & _
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
                                 "FROM cxp c " & _
                                 "WHERE c.auto_proveedor=@auto_entidad and c.cancelado = '1' and c.tipo_documento in ('FAC','NCF','NDF','CHD','ND','PRE','NC') and estatus='0' " & _
                                 "ORDER BY c.fecha"
            xtb_2.Rows.Clear()

            Dim xp1 As New SqlParameter("@auto_entidad", xauto)
            Dim xp2 As New SqlParameter("@top", _MaximoItemsMostrar)

            g_MiData.F_GetData(xsql, xtb_1, xp1, xp2)

            CargarDocumentosSolventesRelacionados(xauto)
        Catch ex As Exception
            Throw New Exception("CARGAR DOCUMENTOS SOLVENTES" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarDocumentosSolventesRelacionados(ByVal xauto As String)
        Try
            Dim xsql As String = "select cd.fecha" & _
                                        ",cd.tipo" & _
                                        ",cd.documento" & _
                                        ",cd.operacion" & _
                                        ",cd.monto" & _
                                        ",cd.detalle" & _
                                        ",(CASE cr.estatus WHEN '1' THEN 'ANULADO' ELSE '' END) estatus" & _
                                        ",auto_cxp" & _
                                        ",auto_cxp_recibo" & _
                                        ",numero_recibo recibo " & _
                                        ",tipo_pago " & _
                                 "from cxp_documentos cd left join cxp_recibos cr on cd.auto_cxp_recibo=cr.auto " & _
                                 "where cd.auto_cxp in (select top(@top) auto " & _
                                                        "from cxp " & _
                                                        "where auto_proveedor=@auto_entidad and cancelado = '1' and tipo_documento in ('FAC','NCF','NDF','CHD','ND','PRE','NC') and estatus='0' " & _
                                                        "order by fecha desc) and operacion<>'ANTICIPO' " & _
                                 "order by cd.fecha desc"

            Dim xp1 As New SqlParameter("@auto_entidad", xauto)
            Dim xp2 As New SqlParameter("@top", _MaximoItemsMostrar)

            g_MiData.F_GetData(xsql, xtb_2, xp1, xp2)
        Catch ex As Exception
            Throw New Exception("CARGAR DATA RELACIONADA" + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub CB_3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_3.SelectedIndexChanged
        If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
            Try
                Select Case CType(CB_3.SelectedIndex, E_TipoDocumento)
                    Case E_TipoDocumento.Todos
                        xbs_1.Filter = "tipo<>''"
                    Case E_TipoDocumento.Factura
                        xbs_1.Filter = "tipo='COMPRA'"
                    Case E_TipoDocumento.NotaDebito
                        xbs_1.Filter = "tipo='NOTA DÉBITO'"
                    Case E_TipoDocumento.NotaCredito
                        xbs_1.Filter = "tipo='NOTA CRÉDITO'"
                    Case E_TipoDocumento.ChequeDevuelto
                        xbs_1.Filter = "tipo='CHEQUE DEVUELTO'"
                End Select
                Me.CHK_1.Checked = False
            Catch ex As Exception
                MessageBox.Show("ERROR AL ACTUALIZAR TIPO DE DOCUMENTO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        IrInicio()
    End Sub

    Private Sub BT_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_1.Click
        BuscarEntidad()
    End Sub

    Private Sub BT_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_2.Click
        BusquedaAvanzada()
    End Sub

    Private Sub BT_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_3.Click
        LimpiarTodo()
    End Sub

    Private Sub BT_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_4.Click
        'EfectuarPago()
        Funciones.MensajeDeAlerta("Esta Opcion Esta Solo Disponible Para Aquellos Clientes Que Manejen El Modulo De Control De Bancos, En Caso Contrario No Se Podra Usar")
    End Sub

    Private Sub BT_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_5.Click
        EfectuarNuevoDocumento()
    End Sub

    Private Sub BT_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_6.Click
        ' EfectuarNotaDebito()
        Funciones.MensajeDeAlerta("Esta Opcion Esta Solo Disponible Para Aquellos Clientes Que Manejen El Modulo De Control De Bancos, En Caso Contrario No Se Podra Usar")
    End Sub

    Sub BuscarEntidad()
        Try
            Dim xt As String = T_1.r_Valor
            If xt <> "" Then
                Dim op As Boolean = True
                If Me._MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
                    Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro de Realizar la Busqueda?, Se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                    If xresultado = Windows.Forms.DialogResult.Yes Then
                        LimpiarControles()
                    Else
                        op = False
                    End If
                End If

                If op Then
                    Dim xsql As String = ""
                    Dim xp1 As SqlParameter
                    Dim xbuscar As String = ""

                    Select Case CType(CB_1.SelectedIndex, FichaProveedores.TipoBusqueda)
                        Case FichaProveedores.TipoBusqueda.PorNombreRazonSocial
                            xsql = Busqueda_1
                        Case FichaProveedores.TipoBusqueda.PorRif_CI
                            xsql = Busqueda_2
                        Case FichaProveedores.TipoBusqueda.PorCodigo
                            xsql = Busqueda_3
                    End Select

                    If xt.Substring(0, 1) = "*" Then
                        xbuscar = "%" + xt.Substring(1)
                    Else
                        xbuscar = xt
                    End If

                    xp1 = New SqlParameter("@data", xbuscar + "%")
                    Dim xficha As New Plantilla_2(New BusquedaProveedor, xsql, xp1)

                    With xficha
                        AddHandler .EnviarAuto, AddressOf CargarDataEntidad
                        .ShowDialog()
                    End With
                End If
                IrInicio()
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR AL BUSCAR PROVEEDOR:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarDataEntidad(ByVal xauto As String)
        _MiFichaProveedor.F_BuscarProveedor(xauto)
        LB_1.Text = _MiFichaProveedor.f_Proveedor.RegistroDato._NombreRazonSocial
        LB_2.Text = _MiFichaProveedor.f_Proveedor.RegistroDato._CiRif
        LB_3.Text = String.Format("{0:#0.00}", _MiFichaProveedor.f_Proveedor.RegistroDato._TotalDebitos)
        LB_4.Text = String.Format("{0:#0.00}", _MiFichaProveedor.f_Proveedor.RegistroDato._TotalCreditos)
        LB_5.Text = String.Format("{0:#0.00}", _MiFichaProveedor.f_Proveedor.RegistroDato._LimiteCredito)
        LB_6.Text = String.Format("{0:#0.00}", _MiFichaProveedor.f_Proveedor.RegistroDato._CreditoDisponible)
        LB_7.Text = String.Format("{0:#0.00}", _MiFichaProveedor.f_Proveedor.RegistroDato._TotalAnticipos)
        LB_8.Text = String.Format("{0:#0.00}", _MiFichaProveedor.f_Proveedor.RegistroDato._TotalSaldo)

        CargarDataEncontrada(xauto)
        IrInicio()
    End Sub

    Sub BusquedaAvanzada()
        Try
            Dim xclase As New c_CxP_BusquedaAvanzada
            AddHandler xclase.RetornarAutoProveedor, AddressOf CargarDataEntidad
            Dim xficha As New CxP_BusquedaAvanzada(xclase)
            xficha.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR FORMULARIO DE BUSQUEDA AVANZADA" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LimpiarTodo()
        Try
            If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
                Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro Limpiar Todo?, Se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If xresultado = Windows.Forms.DialogResult.Yes Then
                    _MiFichaProveedor.f_Proveedor.M_LimpiarRegistro()
                    LimpiarControles()
                    IrDeudas()
                    IrTodos()
                End If
            End If
            IrInicio()
        Catch ex As Exception
            MessageBox.Show("ERROR AL LIMPIAR:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub EfectuarPago()
        'If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" And _IndicadorDocumentosSolventes = False Then
        '    If _MontoTotal <> 0 Then
        '        Try
        '            Dim xr1 As New FichaCtasPagar.c_CxP.c_Registro
        '            Dim xlista_1 As New List(Of DocumentosPagar)
        '            Dim xlista_2 As New BindingList(Of DocumentosNC)
        '            Dim xdoc As DocumentosPagar
        '            Dim xnc As DocumentosNC

        '            For Each xrow In xtb_1.Select("check=1")
        '                xr1.CargarFicha(xrow)
        '                xdoc = New DocumentosPagar
        '                With xdoc
        '                    ._AutoDocumento = xr1._AutoCxP
        '                    ._FechaEmision = xr1._FechaProceso
        '                    ._MontoPendiente = xr1._MontoPorPagar
        '                    ._NumeroDocumento = xr1._NumeroDocumento
        '                    ._IdSeguridad = xr1._IdSeguridad

        '                    Select Case xr1._TipoDocumento
        '                        Case "FAC" : ._TipoDocumento = "FACTURA"
        '                        Case "CHD" : ._TipoDocumento = "CHEQUE DEVUELTO"
        '                        Case "NDF", "ND" : ._TipoDocumento = "NOTA DE DEBITO"
        '                    End Select
        '                End With
        '                xlista_1.Add(xdoc)
        '            Next

        '            For Each xrow In xtb_1.Select("tipo='NOTA CRÉDITO'")
        '                xr1.CargarFicha(xrow)
        '                xnc = New DocumentosNC
        '                With xnc
        '                    ._AutoDocumento = xr1._AutoCxP
        '                    ._FechaEmision = xr1._FechaProceso
        '                    ._MontoImporte = Math.Abs(xr1._MontoPorPagar)
        '                    ._NumeroDocumento = xr1._NumeroDocumento
        '                    ._IdSeguridad = xr1._IdSeguridad
        '                    ._Estatus = 0
        '                End With
        '                xlista_2.Add(xnc)
        '            Next

        '            Dim xclas As New c_ControlPagosCxP(_MiFichaProveedor, xlista_1, xlista_2)
        '            AddHandler xclas._DocumentoProcesado, AddressOf AvisoDocumentoProcesado

        '            Dim xficha As New ControlPagosCxP(xclas)
        '            With xficha
        '                .ShowDialog()
        '            End With
        '        Catch ex As Exception
        '            MessageBox.Show("CUENTAS POR PAGAR" + vbCrLf + "ERROR AL CARGAR PAGO:" + vbCrLf + ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End Try
        '    Else
        '        MessageBox.Show("PARA PODER REALIZAR UN PAGO / ABONO DEBES SELECCIONAR UN DOCUMENTO PENDIENTE, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    End If
        'End If
    End Sub

    Sub AvisoDocumentoProcesado()
        CargarDataEntidad(_MiFichaProveedor.f_Proveedor.RegistroDato._Automatico)
    End Sub

    Sub EfectuarNuevoDocumento()
        If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
            Try
                Dim xclas As New ControlFacturasCompras(_MiFichaProveedor)
                AddHandler xclas._DocumentoProcesado, AddressOf AvisoDocumentoProcesado

                Dim xficha As New ControlFacturas(xclas)
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                MessageBox.Show("CUENTAS POR PAGAR" + vbCrLf + "ERROR AL CARGAR FACTURA:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Sub EfectuarNotaDebito()
        If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
            If xbs_1.Current IsNot Nothing Then
                If xbs_1.Current("tipo") = "COMPRA" Or xbs_1.Current("tipo") = "CHEQUE DEVUELTO" Then
                    Try
                        Dim xrw As DataRow = CType(xbs_1.Current, DataRowView).Row
                        Dim xclas As New c_ControlNotaDebitoCompras(_MiFichaProveedor, xrw)
                        AddHandler xclas._DocumentoProcesado, AddressOf AvisoDocumentoProcesado

                        Dim xficha As New Plantilla_DocumentoEntradaCxC(xclas)
                        With xficha
                            .ShowDialog()
                        End With
                    Catch ex As Exception
                        MessageBox.Show("CUENTAS POR PAGAR" + vbCrLf + "ERROR AL CARGAR NOTA DE DÉBITO:" + vbCrLf + ex.Message, "*** Mensje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub

    Sub EfectuarChequeDevuelto()
        'If _MiFichaProveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
        '    Try
        '        Dim xplantilla As New c_ControlChequeDevueltoCxp(_MiFichaProveedor.f_Proveedor.RegistroDato)
        '        AddHandler xplantilla._DocumentoProcesado, AddressOf AvisoDocumentoProcesado

        '        Dim xficha As New ControlChequeDevueltoCxP(xplantilla)
        '        With xficha
        '            .ShowDialog()
        '        End With
        '    Catch ex As Exception
        '        MessageBox.Show("CUENTAS POR PAGAR" + vbCrLf + "ERROR AL CARGAR CHEQUE DEVUELTO:" + vbCrLf + ex.Message, "*** Mensje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End If
    End Sub
End Class