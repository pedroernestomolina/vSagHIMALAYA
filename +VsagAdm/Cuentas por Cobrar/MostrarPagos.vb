Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports System.Data.SqlClient

Public Class MostrarPagos
    Dim _Plantilla As IMostrarPagos

    Sub New(ByVal xplantilla As IMostrarPagos)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Sub Inicializar()
        _Plantilla.Inicializar(Me)
    End Sub

    Private Sub MostrarPagos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub MostrarPagos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializar()
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR FORMULARIO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub BT_VISUALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_VISUALIZAR.Click
        _Plantilla.F_Visualizar()
    End Sub
End Class

Public Interface IMostrarPagos
    Function F_Visualizar() As Boolean
    Sub Inicializar(ByVal xformulario As Object)
End Interface

''
'' CUENTAS POR COBRAR
''

Class c_MostrarPagos
    Implements IMostrarPagos

#Region "FUNCIONES SELECT"
    Const SELECT_PAGOS As String = "SELECT numero" & _
                                         ",fecha" & _
                                         ",importe" & _
                                         ",cobrador" & _
                                         ",detalle" & _
                                         ",(case estatus when '0' then 'Activo' else 'Anulado' end) estatus " & _
                                         ", * " & _
                                   "FROM cxc_recibos cr " & _
                                   "WHERE cr.auto_cliente=@auto_cliente " & _
                                   "ORDER BY cr.fecha desc"
#End Region

    'LABELS 
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_TITULO_1 As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_ITEMS_1 As System.Windows.Forms.Label
    Dim LB_TOTALIMPORTE As System.Windows.Forms.Label

    'DATAGRIDVIEW
    WithEvents xdatagrid As MisGrid

    Dim x_data As DataTable
    Dim x_binding As BindingSource
    Dim _Cliente As FichaClientes

    Dim xitems As Integer = 0
    Dim xmonto As Decimal = 0

    Property _DocumentosEncontrados() As Integer
        Get
            Return xitems
        End Get
        Set(ByVal value As Integer)
            xitems = value
        End Set
    End Property

    Property _MontoImporte() As Decimal
        Get
            Return xmonto
        End Get
        Set(ByVal value As Decimal)
            xmonto = value
        End Set
    End Property

    Sub New(ByVal xcliente As FichaClientes)
        x_data = New DataTable
        x_binding = New BindingSource(x_data, "")
        _Cliente = xcliente
        AddHandler x_data.RowChanged, AddressOf CargarData
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IMostrarPagos.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
        LB_TITULO_1 = _MiFormulario.Controls.Find("LB_TITULO_1", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        LB_ITEMS_1 = _MiFormulario.Controls.Find("LB_ITEMS_1", True)(0)
        LB_TOTALIMPORTE = _MiFormulario.Controls.Find("LB_TOTALIMPORTE", True)(0)
        xdatagrid = _MiFormulario.Controls.Find("MisGrid1", True)(0)
        _MiFormulario.Text = "Administrador De Pagos"

        'INCIALIZAR GRID PRINCIPAL
        InicializarData()
        With xdatagrid
            .Columns.Add("col0", "Número")
            .Columns.Add("col1", "F/Emisión")
            .Columns.Add("col2", "Importe")
            .Columns.Add("col3", "Cobrador")
            .Columns.Add("col4", "Detalle")
            .Columns.Add("col5", "Estatus")

            .Columns(0).DataPropertyName = "numero"
            .Columns(1).DataPropertyName = "fecha"
            .Columns(2).DataPropertyName = "importe"
            .Columns(3).DataPropertyName = "cobrador"
            .Columns(4).DataPropertyName = "detalle"
            .Columns(5).DataPropertyName = "estatus"

            .DataSource = x_binding

            .Columns(0).Width = 100
            .Columns(1).Width = 80
            .Columns(2).Width = 80
            .Columns(3).Width = 200
            .Columns(5).Width = 100
            .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Ocultar(7)

            AddHandler .CellFormatting, AddressOf FormatoEstatus
        End With
    End Sub

    Sub InicializarData()
        Dim xparam As New SqlParameter("@auto_cliente", _Cliente.f_Clientes.RegistroDato.r_Automatico)
        g_MiData.F_GetData(SELECT_PAGOS, x_data, xparam)

        LB_TITULO.Text = "Recibos De Pago"
        LB_TITULO_1.Text = "Recibos De Pago"
        LB_NOMBRE.Text = _Cliente.f_Clientes.RegistroDato.r_NombreRazonSocial
        LB_CIRIF.Text = _Cliente.f_Clientes.RegistroDato.r_CiRif
        LB_CODIGO.Text = _Cliente.f_Clientes.RegistroDato.r_CodigoCliente
        LB_ITEMS_1.Text = String.Format("{0:#0.00}", _DocumentosEncontrados)
        LB_TOTALIMPORTE.Text = String.Format("{0:#0.00}", _MontoImporte)
    End Sub

    Sub CargarData()
        Dim ximporte As Decimal = 0
        For Each xrow In x_data.Rows
            If xrow("estatus").ToString.Trim.ToUpper <> "ANULADO" Then
                ximporte += xrow("importe")
            End If
        Next
        _MontoImporte = ximporte
        _DocumentosEncontrados = x_data.Rows.Count
    End Sub

    Sub FormatoEstatus(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 2 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If xdatagrid.Rows(e.RowIndex).Cells("col5").Value.ToString.Trim.ToUpper = "ANULADO" Then
            xdatagrid.Rows(e.RowIndex).Cells("col5").Style.ForeColor = Color.Red
        End If
    End Sub

    Public Function F_Visualizar() As Boolean Implements IMostrarPagos.F_Visualizar
        If x_binding.Current IsNot Nothing Then
            Try
                Dim xrecibopagocxc As New FichaCtasCobrar.c_Recibos
                Dim xauto As String = x_binding.Current("auto").ToString.Trim

                xrecibopagocxc.M_CargarRegistro(xauto)
                If xrecibopagocxc.RegistroDato._TipoDocOrigen = TipoDocumentoRegistradoCxC.Anticipo Then
                    ImprimirReciboAnticipo(xauto)
                Else
                    ImprimirReciboPagoCxC(xauto)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Private Sub xdatagrid_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles xdatagrid.Accion
        Try
            Dim xr As DataRow = CType(x_binding.Current, DataRowView).Row
            Dim xficha As New DetallePagos(New c_DetallePagosVentas(xr("auto").ToString))
            xficha.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Class c_MostrarAnulaciones
    Implements IMostrarPagos

#Region "FUNCIONES SELECT"
    Const SELECT_ANULACIONES As String = "SELECT fecha" & _
                                         ",documento" & _
                                         ",(CASE tipo_documento WHEN 'FAC' THEN 'FACTURA' " & _
                                         "                      WHEN 'NDF' THEN 'NOTA DÉBITO' " & _
                                         "                      WHEN 'NCF' THEN 'NOTA CRÉDITO' " & _
                                         "                      WHEN 'ND' THEN 'NOTA DÉBITO' " & _
                                         "                      WHEN 'NC' THEN 'NOTA CRÉDITO' " & _
                                         "                      WHEN 'CHD' THEN 'CHEQUE DEVUELTO' " & _
                                         "                      WHEN 'PAG' THEN 'PAGO' " & _
                                         "                      WHEN 'PRE' THEN 'PRESTAMO' END) tipo" & _
                                         ",importe" & _
                                         ",detalle" & _
                                         ",* " & _
                                   "FROM cxc " & _
                                   "WHERE estatus='1' and auto_cliente=@auto_cliente and tipo_documento in ('FAC','NDF','NCF','ND','NC','CHD','PAG','PRE') " & _
                                   "ORDER BY cxc.fecha desc"


    Protected Friend Const SELECT_DATAEMPRESA As String = "select nombre" & _
                                                                ", rif" & _
                                                                ", direccion" & _
                                                                ", telefono_1 telefono" & _
                                                                ", sucursal" & _
                                                                ", codigo_sucursal " & _
                                                          "from empresa"


#End Region

    'LABELS 
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_TITULO_1 As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_ITEMS_1 As System.Windows.Forms.Label
    Dim LB_TOTALIMPORTE As System.Windows.Forms.Label

    'DATAGRIDVIEW
    WithEvents xdatagrid As MisGrid

    Dim x_data As DataTable
    Dim x_binding As BindingSource
    Dim _Cliente As FichaClientes

    Dim xitems As Integer = 0
    Dim xmonto As Decimal = 0

    Property _DocumentosEncontrados() As Integer
        Get
            Return xitems
        End Get
        Set(ByVal value As Integer)
            xitems = value
        End Set
    End Property

    Property _MontoImporte() As Decimal
        Get
            Return xmonto
        End Get
        Set(ByVal value As Decimal)
            xmonto = value
        End Set
    End Property

    Sub New(ByVal xcliente As FichaClientes)
        x_data = New DataTable
        x_binding = New BindingSource(x_data, "")
        _Cliente = xcliente
        AddHandler x_data.RowChanged, AddressOf CargarData
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IMostrarPagos.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
        LB_TITULO_1 = _MiFormulario.Controls.Find("LB_TITULO_1", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        LB_ITEMS_1 = _MiFormulario.Controls.Find("LB_ITEMS_1", True)(0)
        LB_TOTALIMPORTE = _MiFormulario.Controls.Find("LB_TOTALIMPORTE", True)(0)
        xdatagrid = _MiFormulario.Controls.Find("MisGrid1", True)(0)
        _MiFormulario.Text = "Administrador De Documentos Anulados"

        'CARGAR DATA GRID VIEW
        InicializarData()
        With xdatagrid
            .Columns.Add("col0", "F/Emisión")
            .Columns.Add("col1", "N/Documento")
            .Columns.Add("col2", "T/Documento")
            .Columns.Add("col3", "Importe")
            .Columns.Add("col4", "Detalle")

            .Columns(0).DataPropertyName = "fecha"
            .Columns(1).DataPropertyName = "documento"
            .Columns(2).DataPropertyName = "tipo"
            .Columns(3).DataPropertyName = "importe"
            .Columns(4).DataPropertyName = "detalle"

            .DataSource = x_binding

            .Columns(0).Width = 80
            .Columns(1).Width = 100
            .Columns(2).Width = 130
            .Columns(3).Width = 100
            .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Ocultar(6)

            AddHandler .CellFormatting, AddressOf MiFormato
            AddHandler .Accion, AddressOf VerDetalleAnulacion
        End With
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 3 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Sub InicializarData()
        Dim xparam As New SqlParameter("@auto_cliente", _Cliente.f_Clientes.RegistroDato.r_Automatico)
        g_MiData.F_GetData(SELECT_ANULACIONES, x_data, xparam)

        LB_TITULO.Text = "Documentos Anulados"
        LB_TITULO_1.Text = "Documentos Anulados"
        LB_NOMBRE.Text = _Cliente.f_Clientes.RegistroDato.r_NombreRazonSocial
        LB_CIRIF.Text = _Cliente.f_Clientes.RegistroDato.r_CiRif
        LB_CODIGO.Text = _Cliente.f_Clientes.RegistroDato.r_CodigoCliente
        LB_ITEMS_1.Text = _DocumentosEncontrados.ToString
        LB_TOTALIMPORTE.Text = _MontoImporte.ToString
    End Sub

    Sub CargarData()
        Dim ximporte As Decimal = 0
        For Each xrow In x_data.Rows
            ximporte += xrow("importe")
        Next
        _MontoImporte = ximporte
        _DocumentosEncontrados = x_data.Rows.Count
    End Sub

    Sub VerDetalleAnulacion()
        Dim xclass As New FichaCtasCobrar
        xclass.f_CxC.F_CargarRegistro(x_binding.Current("auto"))

        If xclass.f_CxC.RegistroDato._AutoDocumento = "" Then
            Dim xficha As New DetalleDocumentosAnulados(New c_DetalleDocumentosAnuladosCxC(CType(x_binding.Current, DataRowView).Row))
            xficha.ShowDialog()
        Else
            VisualizarDoc_Ventas(xclass.f_CxC.RegistroDato._AutoDocumento)
        End If
    End Sub

    Public Function F_Visualizar() As Boolean Implements IMostrarPagos.F_Visualizar
        Try
            If x_binding.Current IsNot Nothing Then
                If x_binding.Current("tipo") = "PAGO" Then
                    ImprimirReciboPagoCxC(x_binding.Current("documento"))
                Else
                    VerDetalleDocumento()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR DETALLE DE ANULACIÓN:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Sub VerDetalleDocumento()
        Dim xclass As New FichaCtasCobrar
        xclass.f_CxC.F_CargarRegistro(x_binding.Current("auto"))

        If xclass.f_CxC.RegistroDato._AutoMovimientoEntrada = "" Then
            VisualizarDoc_Ventas(xclass.f_CxC.RegistroDato._AutoDocumento)
        Else
            Dim xficha As New DetalleDocumentosCxC(New c_DetalleDocumentosCxC(xclass.f_CxC.RegistroDato))
            xficha.ShowDialog()
        End If
    End Sub
End Class



''
'' CUENTAS POR PAGAR
''

Class c_MostrarPagosCxP
    Implements IMostrarPagos

#Region "FUNCIONES SELECT"
    Const SELECT_PAGOS As String = "SELECT numero" & _
                                         ",fecha" & _
                                         ",importe" & _
                                         ",detalle" & _
                                         ",(case estatus when '0' then 'Activo' else 'Anulado' end) estatus " & _
                                         ", * " & _
                                   "FROM cxp_recibos cr " & _
                                   "WHERE cr.auto_proveedor=@auto_proveedor " & _
                                   "ORDER BY cr.fecha desc"


#End Region

    'CONTROLES
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_TITULO_1 As System.Windows.Forms.Label
    Dim LB_TITULO_2 As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_ITEMS_1 As System.Windows.Forms.Label
    Dim LB_TOTALIMPORTE As System.Windows.Forms.Label
    WithEvents xdatagrid As MisGrid

    Dim x_data As DataTable
    Dim x_binding As BindingSource
    Dim _Proveedor As FichaProveedores

    Dim xitems As Integer = 0
    Dim xmonto As Decimal = 0

    Property _DocumentosEncontrados() As Integer
        Get
            Return xitems
        End Get
        Set(ByVal value As Integer)
            xitems = value
        End Set
    End Property

    Property _MontoImporte() As Decimal
        Get
            Return xmonto
        End Get
        Set(ByVal value As Decimal)
            xmonto = value
        End Set
    End Property

    Sub New(ByVal xpro As FichaProveedores)
        x_data = New DataTable
        x_binding = New BindingSource(x_data, "")
        _Proveedor = xpro
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IMostrarPagos.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
        LB_TITULO_1 = _MiFormulario.Controls.Find("LB_TITULO_1", True)(0)
        LB_TITULO_2 = _MiFormulario.Controls.Find("LABEL2", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        LB_ITEMS_1 = _MiFormulario.Controls.Find("LB_ITEMS_1", True)(0)
        LB_TOTALIMPORTE = _MiFormulario.Controls.Find("LB_TOTALIMPORTE", True)(0)
        xdatagrid = _MiFormulario.Controls.Find("MisGrid1", True)(0)
        _MiFormulario.Text = "Administrador De Pagos"

        'INCIALIZAR GRID PRINCIPAL
        InicializarData()
        With xdatagrid
            .Columns.Add("col0", "Número")
            .Columns.Add("col1", "F/Emisión")
            .Columns.Add("col2", "Importe")
            .Columns.Add("col3", "Detalle")
            .Columns.Add("col4", "Estatus")

            .Columns(0).DataPropertyName = "numero"
            .Columns(1).DataPropertyName = "fecha"
            .Columns(2).DataPropertyName = "importe"
            .Columns(3).DataPropertyName = "detalle"
            .Columns(4).DataPropertyName = "estatus"

            .DataSource = x_binding

            .Columns(0).Width = 100
            .Columns(1).Width = 80
            .Columns(2).Width = 80
            .Columns(4).Width = 100
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Ocultar(6)

            AddHandler .CellFormatting, AddressOf FormatoEstatus
        End With
    End Sub

    Sub InicializarData()
        Dim xparam As New SqlParameter("@auto_proveedor", _Proveedor.f_Proveedor.RegistroDato._Automatico)
        g_MiData.F_GetData(SELECT_PAGOS, x_data, xparam)
        CargarData()

        LB_TITULO.Text = "Recibos De Pago"
        LB_TITULO_1.Text = "Recibos De Pago"
        LB_TITULO_2.Text = "Datos Del Proveedor:"
        LB_NOMBRE.Text = _Proveedor.f_Proveedor.RegistroDato._NombreRazonSocial
        LB_CIRIF.Text = _Proveedor.f_Proveedor.RegistroDato._CiRif
        LB_CODIGO.Text = _Proveedor.f_Proveedor.RegistroDato._CodigoProveedor
        LB_ITEMS_1.Text = String.Format("{0:#0}", _DocumentosEncontrados)
        LB_TOTALIMPORTE.Text = String.Format("{0:#0.00}", _MontoImporte)
    End Sub

    Sub CargarData()
        Dim ximporte As Decimal = 0
        For Each xrow In x_data.Rows
            If xrow("estatus").ToString.Trim.ToUpper <> "ANULADO" Then
                ximporte += xrow("importe")
            End If
        Next
        _MontoImporte = ximporte
        _DocumentosEncontrados = x_data.Rows.Count
    End Sub

    Sub FormatoEstatus(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 2 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If xdatagrid.Rows(e.RowIndex).Cells("col4").Value.ToString.Trim.ToUpper = "ANULADO" Then
            xdatagrid.Rows(e.RowIndex).Cells("col4").Style.ForeColor = Color.Red
        End If
    End Sub

    Public Function F_Visualizar() As Boolean Implements IMostrarPagos.F_Visualizar
        If x_binding.Current IsNot Nothing Then
            Try
                Dim xauto As String = x_binding.Current("auto")

                If Not IsDBNull(x_binding.Current("tipo_pago")) Then
                    Select Case CType(x_binding.Current("tipo_pago"), DataSistema.MiDataSistema.DataSistema.TipoPago)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Cheque
                            Dim xp1 As New SqlParameter("@auto", xauto)
                            Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp1)
                            VisualizarComprobanteEgreso(xauto_mov)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Transferencia
                            Dim xp1 As New SqlParameter("@auto", xauto)
                            Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp1)
                            VisualizarComprobanteEgresoGeneral(xauto_mov)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.NotaCredito
                            VisualizarReciboCxP(xauto)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Retencion
                            Dim xp1 As New SqlParameter("@auto", xauto)
                            Dim xauto_ret As String = F_GetString("select auto from retenciones_compras where auto_recibo_cxp=@auto", xp1)
                            VisualizarRet_Compras(xauto_ret, "", "")
                    End Select
                Else
                    VisualizarReciboCxP(xauto)
                End If

            Catch ex As Exception
                MessageBox.Show("ERROR AL CARGAR RECIBO DE PAGO" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Private Sub xdatagrid_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles xdatagrid.Accion
        If x_binding.Current IsNot Nothing Then
            Try
                Dim xauto As String = x_binding.Current("auto")
                If Not IsDBNull(x_binding.Current("tipo_pago")) Then
                    Select Case CType(x_binding.Current("tipo_pago"), DataSistema.MiDataSistema.DataSistema.TipoPago)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Cheque
                            Dim xp1 As New SqlParameter("@auto", xauto)
                            Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp1)
                            VisualizarComprobanteEgreso(xauto_mov)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Transferencia
                            Dim xp1 As New SqlParameter("@auto", xauto)
                            Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp1)
                            VisualizarComprobanteEgresoGeneral(xauto_mov)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.NotaCredito
                            VisualizarReciboCxP(xauto)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Retencion
                            Dim xp1 As New SqlParameter("@auto", xauto)
                            Dim xauto_ret As String = F_GetString("select auto from retenciones_compras where auto_recibo_cxp=@auto", xp1)
                            VisualizarRet_Compras(xauto_ret, "", "")
                    End Select
                Else
                    VisualizarReciboCxP(xauto)
                End If
            Catch ex As Exception
                MessageBox.Show("ERROR AL CARGAR RECIBO DE PAGO" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class

Class c_MostrarAnulacionesCxP
    Implements IMostrarPagos

#Region "FUNCIONES SELECT"
    Const SELECT_ANULACIONES As String = "SELECT fecha " & _
                                         ",documento " & _
                                         ",(CASE tipo_documento WHEN 'FAC' THEN 'COMPRA' " & _
                                         "                      WHEN 'NDF' THEN 'NOTA DÉBITO' " & _
                                         "                      WHEN 'NCF' THEN 'NOTA CRÉDITO' " & _
                                         "                      WHEN 'ND' THEN 'NOTA DÉBITO' " & _
                                         "                      WHEN 'NC' THEN 'NOTA CRÉDITO' " & _
                                         "                      WHEN 'CHD' THEN 'CHEQUE DEVUELTO' " & _
                                         "                      WHEN 'PAG' THEN 'PAGO' " & _
                                         "                      WHEN 'PRE' THEN 'PRESTAMO' END) tipo" & _
                                         ",importe" & _
                                         ",detalle" & _
                                         ",* " & _
                                   "FROM cxp " & _
                                   "WHERE estatus='1' and auto_proveedor=@auto_proveedor and tipo_documento in ('FAC','NDF','NCF','ND','NC','CHD','PAG','PRE') " & _
                                   "ORDER BY cxp.fecha desc"
#End Region

    'CONTROLES
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_TITULO_1 As System.Windows.Forms.Label
    Dim LB_TITULO_2 As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_ITEMS_1 As System.Windows.Forms.Label
    Dim LB_TOTALIMPORTE As System.Windows.Forms.Label
    WithEvents xdatagrid As MisGrid

    Dim x_data As DataTable
    Dim x_binding As BindingSource
    Dim _Proveedor As FichaProveedores

    Dim xitems As Integer = 0
    Dim xmonto As Decimal = 0

    Property _DocumentosEncontrados() As Integer
        Get
            Return xitems
        End Get
        Set(ByVal value As Integer)
            xitems = value
        End Set
    End Property

    Property _MontoImporte() As Decimal
        Get
            Return xmonto
        End Get
        Set(ByVal value As Decimal)
            xmonto = value
        End Set
    End Property

    Sub New(ByVal xpro As FichaProveedores)
        x_data = New DataTable
        x_binding = New BindingSource(x_data, "")
        _Proveedor = xpro
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IMostrarPagos.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
        LB_TITULO_1 = _MiFormulario.Controls.Find("LB_TITULO_1", True)(0)
        LB_TITULO_2 = _MiFormulario.Controls.Find("label2", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        LB_ITEMS_1 = _MiFormulario.Controls.Find("LB_ITEMS_1", True)(0)
        LB_TOTALIMPORTE = _MiFormulario.Controls.Find("LB_TOTALIMPORTE", True)(0)
        xdatagrid = _MiFormulario.Controls.Find("MisGrid1", True)(0)
        _MiFormulario.Text = "Administrador De Documentos Anulados"

        'CARGAR DATA GRID VIEW
        InicializarData()
        With xdatagrid
            .Columns.Add("col0", "F/Emisión")
            .Columns.Add("col1", "N/Documento")
            .Columns.Add("col2", "T/Documento")
            .Columns.Add("col3", "Importe")
            .Columns.Add("col4", "Detalle")

            .Columns(0).DataPropertyName = "fecha"
            .Columns(1).DataPropertyName = "documento"
            .Columns(2).DataPropertyName = "tipo"
            .Columns(3).DataPropertyName = "importe"
            .Columns(4).DataPropertyName = "detalle"

            .DataSource = x_binding

            .Columns(0).Width = 80
            .Columns(1).Width = 100
            .Columns(2).Width = 130
            .Columns(3).Width = 100
            .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Ocultar(6)

            AddHandler .CellFormatting, AddressOf MiFormato
            AddHandler .Accion, AddressOf VerDetalleAnulacion
        End With
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 3 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Sub InicializarData()
        Dim xparam As New SqlParameter("@auto_proveedor", _Proveedor.f_Proveedor.RegistroDato._Automatico)
        g_MiData.F_GetData(SELECT_ANULACIONES, x_data, xparam)
        CargarData()

        LB_TITULO.Text = "Documentos Anulados"
        LB_TITULO_1.Text = "Documentos Anulados"
        LB_TITULO_2.Text = "Datos Del Proveedor"
        LB_NOMBRE.Text = _Proveedor.f_Proveedor.RegistroDato._NombreRazonSocial
        LB_CIRIF.Text = _Proveedor.f_Proveedor.RegistroDato._CiRif
        LB_CODIGO.Text = _Proveedor.f_Proveedor.RegistroDato._CodigoProveedor
        LB_ITEMS_1.Text = String.Format("{0:#0}", _DocumentosEncontrados)
        LB_TOTALIMPORTE.Text = String.Format("{0:#0.00}", _MontoImporte)
    End Sub

    Sub CargarData()
        Dim ximporte As Decimal = 0
        For Each xrow In x_data.Rows
            ximporte += xrow("importe")
        Next
        _MontoImporte = ximporte
        _DocumentosEncontrados = x_data.Rows.Count
    End Sub

    Sub VerDetalleAnulacion()
        If xdatagrid.CurrentRow.Index <> -1 Then
            Dim xficha As New DetalleDocumentosAnulados(New c_DetalleDocumentosAnuladosCxP(CType(x_binding.Current, DataRowView).Row))
            xficha.ShowDialog()
        End If
    End Sub

    Public Function F_Visualizar() As Boolean Implements IMostrarPagos.F_Visualizar
        Try
            If x_binding.Current IsNot Nothing Then
                VerDetalleDocumento()
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR DETALLE DE ANULACIÓN:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Sub VerDetalleDocumento()
        Dim xclass As New FichaCtasPagar
        xclass.F_CuentaPagar.F_CargarRegistro(x_binding.Current("auto"))

        If xclass.F_CuentaPagar.RegistroDato._AutoMovimientoEntrada <> "" And xclass.F_CuentaPagar.RegistroDato._TipoDocumento <> TipoDocumentoCuentaxPagar.Pago Then
            Dim xficha As New DetalleDocumentosCxC(New c_DetalleDocumentosCxP(xclass.F_CuentaPagar.RegistroDato))
            xficha.ShowDialog()
        Else
            If xclass.F_CuentaPagar.RegistroDato._TipoDocumento <> TipoDocumentoCuentaxPagar.Pago Then
                VisualizarDoc_Compras(xclass.F_CuentaPagar.RegistroDato._AutoDocumento)
            Else
                Dim xp1 As New SqlParameter("@numero", x_binding.Current("documento"))
                Dim xp2 As New SqlParameter("@numero", x_binding.Current("documento"))
                Dim xtipo As String = F_GetString("select tipo_pago from cxp_recibos where numero=@numero", xp1)
                Dim xauto As String = F_GetString("select auto from cxp_recibos where numero=@numero", xp2)

                If Not IsDBNull(xtipo) And xtipo <> "" Then
                    Select Case CType(xtipo, DataSistema.MiDataSistema.DataSistema.TipoPago)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Cheque
                            Dim xp3 As New SqlParameter("@auto", xauto)
                            Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp3)
                            VisualizarComprobanteEgreso(xauto_mov)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Transferencia
                            Dim xp3 As New SqlParameter("@auto", xauto)
                            Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp3)
                            VisualizarComprobanteEgresoGeneral(xauto_mov)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.NotaCredito
                            VisualizarReciboCxP(xauto)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Retencion
                            Dim xp3 As New SqlParameter("@auto", xauto)
                            Dim xauto_ret As String = F_GetString("select auto from retenciones_compras where auto_recibo_cxp=@auto", xp3)
                            VisualizarRet_Compras(xauto_ret, "", "")
                    End Select
                Else
                    VisualizarReciboCxP(xauto)
                End If
            End If
        End If
    End Sub
End Class