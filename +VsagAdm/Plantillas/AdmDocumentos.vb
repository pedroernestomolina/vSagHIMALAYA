Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports ImpresoraMatriz.ImpresoraMatriz

Public Class AdmDocumentos
    Event _AutoDocumento(ByVal xauto_doc As String)

    Dim xplantilla As IAdministradorDocumentos
    Dim xbinding As BindingSource
    Dim xhabilitar_retorno As Boolean
    Dim xhabilitar_revertir As Boolean
    Dim xtipodocumento_revertir As TipoDocumentoVenta

    Property _HabilitarRevertir() As Boolean
        Get
            Return xhabilitar_revertir
        End Get
        Set(ByVal value As Boolean)
            xhabilitar_revertir = value
        End Set
    End Property

    Property _TipoDocumentoRevertir() As TipoDocumentoVenta
        Get
            Return xtipodocumento_revertir
        End Get
        Set(ByVal value As TipoDocumentoVenta)
            xtipodocumento_revertir = value
        End Set
    End Property

    Property _HabilitarRetorno()
        Get
            Return xhabilitar_retorno
        End Get
        Set(ByVal value)
            xhabilitar_retorno = value
        End Set
    End Property

    Property _Plantilla() As IAdministradorDocumentos
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IAdministradorDocumentos)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xtipo_plantilla As IAdministradorDocumentos, Optional ByVal RetornarAuto As Boolean = False)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xtipo_plantilla
        AddHandler _Plantilla.ActualizarFicha, AddressOf ActualizarItems

        _HabilitarRetorno = RetornarAuto
        _HabilitarRevertir = False
    End Sub

    Sub ActualizarItems()
        Me.E_ITEMS_1.Text = _Plantilla._CantidadRegistros
        Me.E_ITEMS_2.Text = _Plantilla._CantidadRegistrosRelacionados
    End Sub

    Sub Inicializa()
        Me.E_ITEMS_1.Text = "0"
        Me.E_ITEMS_2.Text = "0"

        xplantilla.Inicializa(Me, TRASLADAR_VENTA)
        xbinding = xplantilla.CargarDataGrid(Me.MisGrid1, Me.MisGrid2)
        _Plantilla.CargarComboBuscarPor(Me.MCB_BUSCAR)
        xplantilla.CargarComboTipoDocumento(Me.MCB_TIPO_DOC)

        Me.Text = _Plantilla._TituloVentana

        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()

        Me.BT_REVERTIR.Enabled = _HabilitarRevertir
    End Sub

    Private Sub AdmDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            Me.MT_BUSCAR.Select()
            Me.MT_BUSCAR.Focus()
        End If

        If e.KeyCode = Keys.N AndAlso (e.Alt = True And e.Control = True) Then
            If _Plantilla._MostrarChimbo Then
                _Plantilla._ActivarChimbo = Not _Plantilla._ActivarChimbo

                If _Plantilla._ActivarChimbo Then
                    Me.Panel2.BackColor = Color.Maroon
                    Me.Label1.ForeColor = Color.White
                Else
                    Me.Panel2.BackColor = Color.WhiteSmoke
                    Me.Label1.ForeColor = Color.Black
                End If

                IrBuscar()
            End If
        End If
    End Sub

    Private Sub AdmDocumentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializa()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub MisFechas1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MisFechas1.ValueChanged
        If xplantilla IsNot Nothing Then
            If (Me.MisFechas2.Checked) Then
                If (MisFechas1.Value.Date > MisFechas2.Value.Date) Then
                    Funciones.MensajeDeAlerta("Fecha Incorrecta Verifique Por Favor...")
                    MisFechas1.Value = MisFechas2.Value
                End If
            End If
            xplantilla._FilterData._DesdeFecha = MisFechas1.Value.Date
        End If
    End Sub

    Private Sub MisFechas2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MisFechas2.ValueChanged
        If xplantilla IsNot Nothing Then
            If (Me.MisFechas1.Checked) Then
                If (MisFechas2.Value.Date < MisFechas1.Value.Date) Then
                    Funciones.MensajeDeAlerta("Fecha Incorrecta Verifique Por Favor...")
                    MisFechas2.Value = MisFechas1.Value
                End If
            End If
            xplantilla._FilterData._HastaFecha = MisFechas2.Value.Date
        End If
    End Sub

    Private Sub MT_BUSCAR_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MT_BUSCAR.LostFocus
        Me._Plantilla._FilterData._Texto = Me.MT_BUSCAR.r_Valor
    End Sub

    Private Sub MCB_BUSCAR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSCAR.SelectedIndexChanged
        Me.MT_BUSCAR.Text = ""
        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()
    End Sub

    Private Sub BusquedaAvanzada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_AVANZADA.Click
        _Plantilla._BusquedaAvanzada()
    End Sub

    Private Sub BT_BUSCAR_AHORA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR_AHORA.Click
        IrBuscar()
    End Sub

    Sub IrBuscar()
        Try
            _Plantilla._BuscarAhora(_Plantilla._FilterData)
            Me.MT_BUSCAR.Text = ""
            Me.MisGrid1.Select()
            Me.MisGrid1.Focus()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub MisGrid1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid1.Accion
        If _HabilitarRetorno Then
            RaiseEvent _AutoDocumento(_Plantilla._AutoDocumento)
            Me.Close()
        Else
            _Plantilla._ConsultarDocumento()
        End If
    End Sub

    Private Sub AdmDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub BT_REIMPRIMIR_DOC_Click(sender As Object, e As EventArgs) Handles BT_REIMPRIMIR_DOC.Click
        _Plantilla._ReimprimirDocumento()
    End Sub

    Private Sub BT_VISUALIZAR_Click(sender As Object, e As EventArgs) Handles BT_VISUALIZAR.Click
        _Plantilla._VisualizarDocumento()
    End Sub

    Private Sub BT_GUIA_DESPACHO_Click_1(sender As Object, e As EventArgs) Handles BT_GUIA_DESPACHO.Click
        _Plantilla._GuiaDespacho()
    End Sub

    Private Sub BT_ANULAR_Click(sender As Object, e As EventArgs) Handles BT_ANULAR.Click
        _Plantilla._AnularDocumento()
    End Sub

    Private Sub BT_REVERTIR_Click_1(sender As Object, e As EventArgs) Handles BT_REVERTIR.Click
        _Plantilla._RevertirDocumento(Me._TipoDocumentoRevertir)
        Me.Close()
    End Sub

    Private Sub BT_CAMBIAR_ESTATUS_Click(sender As Object, e As EventArgs) Handles BT_CAMBIAR_ESTATUS.Click
        If _Plantilla._CAMBIAR_ESTATUS_DOCUMENTO() Then
            IrBuscar()
        End If
    End Sub

End Class

Public Interface IAdministradorDocumentos
    Event ActualizarFicha()

    Function CargarDataGrid(ByVal xdatagrid As MisGrid, ByVal xdatagrid_2 As MisGrid) As BindingSource
    Function CargarComboBuscarPor(ByVal xcombobox As MisComboBox) As Boolean
    Function CargarComboTipoDocumento(ByVal xcombobox As MisComboBox) As Boolean
    Sub Inicializa(ByVal xobj1 As Object, ByVal xobj2 As Object)

    Function _BuscarAhora(ByVal xfilterdata As C_FilterData) As Boolean
    Function _VisualizarDocumento() As Boolean
    Function _GuiaDespacho() As Boolean
    Function _BusquedaAvanzada() As Boolean
    Function _AnularDocumento() As Boolean
    Function _RevertirDocumento(ByVal xtipodoc As TipoDocumentoVenta) As Boolean
    Function _ConsultarDocumento() As Boolean
    Function _ReimprimirDocumento() As Boolean
    Function _CAMBIAR_ESTATUS_DOCUMENTO() As Boolean

    ReadOnly Property _CantidadRegistros() As String
    ReadOnly Property _CantidadRegistrosRelacionados() As String
    ReadOnly Property _FilterData() As C_FilterData
    ReadOnly Property _TituloVentana() As String
    ReadOnly Property _AutoDocumento() As String
    ReadOnly Property _MostrarChimbo() As Boolean
    Property _ActivarChimbo() As Boolean

    Enum TipoBusqueda As Integer
        Nombre = 0
        CI_rif = 1
        Codigo_entidad = 2
        Auto = 3
    End Enum

    Class C_FilterData
        Private f_tipofilter As TipoBusqueda
        Private f_texto As String
        Private f_desdefecha As DateTime
        Private f_hastafecha As DateTime
        Private f_tipodocumento As String

        Property _TipoFilter() As TipoBusqueda
            Get
                Return f_tipofilter
            End Get
            Set(ByVal value As TipoBusqueda)
                f_tipofilter = value
            End Set
        End Property

        Property _Texto() As String
            Get
                Return f_texto
            End Get
            Set(ByVal value As String)
                f_texto = value
            End Set
        End Property

        Property _DesdeFecha() As DateTime
            Get
                Return f_desdefecha
            End Get
            Set(ByVal value As DateTime)
                f_desdefecha = value
            End Set
        End Property

        Property _HastaFecha() As DateTime
            Get
                Return f_hastafecha
            End Get
            Set(ByVal value As DateTime)
                f_hastafecha = value
            End Set
        End Property

        Property _TipoDocumento() As String
            Get
                Return f_tipodocumento
            End Get
            Set(ByVal value As String)
                f_tipodocumento = value
            End Set
        End Property

        Sub New()
            _TipoFilter = 0
            _TipoDocumento = "00"
            _Texto = ""
            _DesdeFecha = Date.MinValue
            _HastaFecha = Date.MinValue
        End Sub
    End Class
End Interface

Public Class AdmDoc_Ventas
    Implements IAdministradorDocumentos
    Event _TrasladarDocumentoVenta(ByVal xauto_doc As String)
    Event _ActualizarFichaCliente(ByVal xauto_cliente As String)

    Dim f_data As DataTable
    Dim f_binding As BindingSource
    Dim f_datarelacionada As DataTable
    Dim f_bindingrelacionada As BindingSource
    Dim f_filterdata As IAdministradorDocumentos.C_FilterData
    Dim x_maximo_items_mostrar As Integer
    Dim xcombo1 As MisComboBox
    Dim xcombo2 As MisComboBox
    Dim xactivarchimbo As Boolean
    Dim xsql_busqueda_actual As String
    Dim xdocumentotipo As TipoDocumentoVenta
    Dim xlista_estatus As String() = {"Activos", "Anulados", "Procesados", "Todos"}

    Dim WithEvents xTrasladarVenta As ToolStripMenuItem
    Dim WithEvents xform As System.Windows.Forms.Form
    Dim WithEvents xgrid As MisGrid
    Dim WithEvents mcb_estatus_documento As MisComboBox
    Dim xtipo As String

    Property _TipoDocVisualizar() As String
        Get
            Return xtipo
        End Get
        Set(ByVal value As String)
            xtipo = value
        End Set
    End Property

    Class TiposDocumentos
        Private xnombre As String
        Private xcodigo As String

        Property _Nombre() As String
            Get
                Return xnombre
            End Get
            Set(ByVal value As String)
                xnombre = value
            End Set
        End Property

        Property _Codigo() As String
            Get
                Return xcodigo
            End Get
            Set(ByVal value As String)
                xcodigo = value
            End Set
        End Property

        Sub New()
            Me._Codigo = ""
            Me._Nombre = ""
        End Sub
    End Class

    Property _TipoDocumentoEnProceso() As TipoDocumentoVenta
        Get
            Return xdocumentotipo
        End Get
        Set(ByVal value As TipoDocumentoVenta)
            xdocumentotipo = value
        End Set
    End Property

    Property _SqlBusquedaActual() As String
        Get
            Return xsql_busqueda_actual
        End Get
        Set(ByVal value As String)
            xsql_busqueda_actual = value
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

    Sub New(ByVal xtope As Integer, Optional ByVal xtipodocumento As TipoDocumentoVenta = 0)
        _MaximoItemsMostrar = xtope
        _TipoDocumentoEnProceso = xtipodocumento

        f_data = New DataTable
        f_binding = New BindingSource(f_data, "")
        f_datarelacionada = New DataTable
        f_bindingrelacionada = New BindingSource(f_datarelacionada, "")
        f_filterdata = New IAdministradorDocumentos.C_FilterData
        _TipoDocVisualizar = ""

        If xtipodocumento <> 0 Then
            Select Case xtipodocumento
                Case TipoDocumentoVenta.Factura
                    _TipoDocVisualizar = "01"
                Case TipoDocumentoVenta.NotaCredito
                    _TipoDocVisualizar = "03"
                Case TipoDocumentoVenta.NotaEntrega
                    _TipoDocVisualizar = "04"
                Case TipoDocumentoVenta.Pedido
                    _TipoDocVisualizar = "06"
                Case TipoDocumentoVenta.Presupuesto
                    _TipoDocVisualizar = "05"
            End Select
        End If

        _ActivarChimbo = False
        _SqlBusquedaActual = ""
    End Sub

    Public Function CargarDataGrid(ByVal xdatagrid As MisGrid, ByVal xdatagrid_2 As MisGrid) As System.Windows.Forms.BindingSource Implements IAdministradorDocumentos.CargarDataGrid
        Dim xsentencia As String
        Try
            Dim xp1 As New SqlParameter("@top", _MaximoItemsMostrar)
            Dim xp2 As SqlParameter = Nothing

            If _TipoDocVisualizar = "" Then
                xsentencia = "select top(@top) fecha, (case tipo when '01' then 'Factura' when '02' then 'Nota Débito' " & _
                                                         "when '03' then 'Nota Crédito' when '04' then 'Nota Entrega' when '05' then 'Presupuesto' " & _
                                                         "when '06' then 'Pedido' end) tipo, documento, fecha_vencimiento, dias, nombre, ci_rif, " & _
                                                         "total, (case estatus when '0' then 'Activo' when '1' then 'Anulado' when '2' then 'Procesado' end) estatus, " & _
                                                         "auto, tipo as tipodoc from ventas where tipo in ('01','02','03','04','05','06') order by fecha desc, AUTO DESC"
                xp2 = New SqlParameter("@tipodoc", "")
            Else
                xsentencia = "select top(@top) fecha, (case tipo when '01' then 'Factura' when '02' then 'Nota Débito' " & _
                                                         "when '03' then 'Nota Crédito' when '04' then 'Nota Entrega' when '05' then 'Presupuesto' " & _
                                                         "when '06' then 'Pedido' end) tipo, documento, fecha_vencimiento, dias, nombre, ci_rif, " & _
                                                         "total, (case estatus when '0' then 'Activo' when '1' then 'Anulado' when '2' then 'Procesado' end) estatus, " & _
                                                         "auto, tipo as tipodoc from ventas where tipo = @tipodoc order by fecha desc, AUTO DESC"
                xp2 = New SqlParameter("@tipodoc", _TipoDocVisualizar)
            End If

            _SqlBusquedaActual = xsentencia
            g_MiData.F_GetData(xsentencia, f_data, xp1, xp2)
            With xdatagrid
                .Columns.Add("col0", "F/Emision")
                .Columns.Add("col1", "Tipo/Doc")
                .Columns.Add("col2", "Documento")
                .Columns.Add("col3", "F/Vencim")
                .Columns.Add("col4", "Días")
                .Columns.Add("col5", "Cliente")
                .Columns.Add("col6", "CI/RIF")
                .Columns.Add("col7", "Importe")
                .Columns.Add("col8", "Estatus")

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "tipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "fecha_vencimiento"
                .Columns(4).DataPropertyName = "dias"
                .Columns(5).DataPropertyName = "nombre"
                .Columns(6).DataPropertyName = "ci_rif"
                .Columns(7).DataPropertyName = "total"
                .Columns(8).DataPropertyName = "estatus"

                .DataSource = f_binding

                .Columns(0).Width = 70
                .Columns(1).Width = 85
                .Columns(2).Width = 110
                .Columns(3).Width = 70
                .Columns(4).Width = 40
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(6).Width = 90
                .Columns(7).Width = 90
                .Columns(8).Width = 60

                .Ocultar(10)
                AddHandler .CellFormatting, AddressOf MiFormato

                .Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(2).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(3).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(4).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(5).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(6).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(7).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(8).SortMode = DataGridViewColumnSortMode.Automatic
            End With

            With xdatagrid_2
                .Columns.Add("col0", "Fecha")
                .Columns.Add("col1", "Movimiento")
                .Columns.Add("col2", "Documento")
                .Columns.Add("col3", "Detalle")
                .Columns.Add("col4", "Importe")
                .Columns.Add("col5", "Estatus")

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "tipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "detalle"
                .Columns(4).DataPropertyName = "importe"
                .Columns(5).DataPropertyName = "estatus"

                .DataSource = f_datarelacionada

                .Columns(0).Width = 100
                .Columns(1).Width = 150
                .Columns(2).Width = 150
                .Columns(3).Width = 250
                .Columns(4).Width = 100
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .Ocultar(7)
                AddHandler .CellFormatting, AddressOf MiFormato2
            End With

            AddHandler f_binding.PositionChanged, AddressOf ActualizarDataRelacionada
            ActualizarData()
            RaiseEvent ActualizarFicha()

            Return f_binding
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub ActualizarDataRelacionada(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizarData()
    End Sub

    Sub ActualizarData()
        CargarDataRelacionada()
        RaiseEvent ActualizarFicha()
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 7 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If

        Dim xgrid As MisControles.Controles.MisGrid = CType(sender, MisGrid)
        If xgrid.Rows(e.RowIndex).Cells(8).Value.ToString.Trim.ToUpper = "ANULADO" Then
            xgrid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Sub MiFormato2(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 4 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Dim TipoBusqueda As String() = {"Por Nombre/Razon Social", "Por RIF/CI", "Por Codigo", "Codigo Barra Documento"}

    Public Function CargarComboBuscarPor(ByVal xcombobox As MisComboBox) As Boolean Implements IAdministradorDocumentos.CargarComboBuscarPor
        With xcombobox
            '.DataSource = g_MiData.f_FichaClientes.f_Clientes.p_TipoBusqueda
            '.SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarCliente
            .DataSource = TipoBusqueda
            .SelectedIndex = 0
        End With
        xcombo1 = xcombobox
        AddHandler xcombo1.SelectedIndexChanged, AddressOf ActualizarOpcionBuscar
        ActualizarBuscar()
    End Function

    Sub ActualizarOpcionBuscar(ByVal sender As Object, ByVal e As System.EventArgs)
        f_filterdata._TipoFilter = sender.SelectedIndex
    End Sub

    Sub ActualizarTipoDocumento(ByVal sender As Object, ByVal e As System.EventArgs)
        f_filterdata._TipoDocumento = sender.SelectedValue.ToString
    End Sub

    Public Function CargarComboTipoDocumento(ByVal xcombobox As MisComboBox) As Boolean Implements IAdministradorDocumentos.CargarComboTipoDocumento
        Dim xlista As New List(Of TiposDocumentos)
        xlista.Add(New TiposDocumentos With {._Nombre = "Todos", ._Codigo = "00"})
        xlista.Add(New TiposDocumentos With {._Nombre = "Factura", ._Codigo = "01"})
        xlista.Add(New TiposDocumentos With {._Nombre = "Nota Debito", ._Codigo = "02"})
        xlista.Add(New TiposDocumentos With {._Nombre = "Nota Credito", ._Codigo = "03"})
        xlista.Add(New TiposDocumentos With {._Nombre = "Nota Entrega", ._Codigo = "04"})
        xlista.Add(New TiposDocumentos With {._Nombre = "Presupuesto", ._Codigo = "05"})
        xlista.Add(New TiposDocumentos With {._Nombre = "Pedido", ._Codigo = "06"})

        With xcombobox
            .DataSource = xlista
            .DisplayMember = "_Nombre"
            .ValueMember = "_Codigo"
        End With
        xcombo2 = xcombobox
        AddHandler xcombo2.SelectedIndexChanged, AddressOf ActualizarTipoDocumento
        ActualizarDocumento()
    End Function

    Sub ActualizarBuscar()
        ActualizarOpcionBuscar(xcombo1, Nothing)
    End Sub

    Sub ActualizarDocumento()
        ActualizarTipoDocumento(xcombo2, Nothing)
    End Sub

    Public Function _BuscarAhora(ByVal xfilterdata As IAdministradorDocumentos.C_FilterData) As Boolean Implements IAdministradorDocumentos._BuscarAhora
        Dim xsentencia As String = ""
        Dim xcondicion As String = "auto<>'' "
        Dim xtexto As String = xfilterdata._Texto

        If xfilterdata._TipoFilter = IAdministradorDocumentos.TipoBusqueda.Auto Then
            If xtexto.Length >= 12 Then
                xcondicion = "auto='" + xfilterdata._Texto.Substring(1, 10) + "'"
                xsentencia = "select fecha, (case tipo when '01' then 'Factura' when '02' then 'Nota Débito' " & _
                                                         "when '03' then 'Nota Crédito' when '04' then 'Nota Entrega' when '05' then 'Presupuesto' " & _
                                                         "when '06' then 'Pedido' end) tipo, documento, fecha_vencimiento, dias, nombre, ci_rif, " & _
                                                         "total, (case estatus when '0' then 'Activo' when '1' then 'Anulado' when '2' then 'Procesado' end) estatus, auto,tipo as tipodoc " & _
                                                         "from ventas where " & xcondicion & " order by fecha desc, AUTO DESC"
            End If
        Else
            If (xfilterdata._Texto <> "") Then
                If xtexto.Substring(0, 1) = "*" Then
                    xtexto = xtexto.Substring(1)
                End If

                Select Case xfilterdata._Texto.Substring(0, 1)
                    Case "*" : xcondicion += "and " + xfilterdata._TipoFilter.ToString() + " like '%" + xtexto + "%' "
                    Case Else : xcondicion += "and " + xfilterdata._TipoFilter.ToString() + " like '" + xtexto + "%' "
                End Select
            End If

            If xfilterdata._TipoDocumento <> "00" Then
                xcondicion += "and tipo = '" + xfilterdata._TipoDocumento + "' "
            Else
                If _ActivarChimbo Then
                    xcondicion += "and tipo in ('XX','XN') "
                Else
                    xcondicion += "and tipo in ('01','02','03','04','05','06') "
                End If
            End If

            Select Case mcb_estatus_documento.SelectedIndex
                Case 0 : xcondicion += "and estatus='0' "
                Case 1 : xcondicion += "and estatus='1' "
                Case 2 : xcondicion += "and estatus='2' "
            End Select

            If (xfilterdata._DesdeFecha <> Date.MinValue) Then
                xcondicion += "and fecha >= '" & xfilterdata._DesdeFecha & "' "
            End If

            If (xfilterdata._HastaFecha <> Date.MinValue) Then
                xcondicion += "and fecha <= '" & xfilterdata._HastaFecha & "' "
            End If
            xsentencia = "select top(@top) fecha, (case tipo when '01' then 'Factura' when '02' then 'Nota Débito' " & _
                                                     "when '03' then 'Nota Crédito' when '04' then 'Nota Entrega' when '05' then 'Presupuesto' " & _
                                                     "when '06' then 'Pedido' end) tipo, documento, fecha_vencimiento, dias, nombre, ci_rif, " & _
                                                     "total, (case estatus when '0' then 'Activo' when '1' then 'Anulado' when '2' then 'Procesado' end) estatus, auto,tipo as tipodoc " & _
                                                     "from ventas where " & xcondicion & "order by fecha desc, AUTO DESC"
        End If

        If xsentencia <> "" Then
            Buscar(xsentencia)
        End If
    End Function

    Sub Buscar(ByVal xsql As String)
        _SqlBusquedaActual = xsql
        Dim xp1 As New SqlParameter("@top", _MaximoItemsMostrar)
        Dim xp2 As SqlParameter = Nothing
        xp2 = New SqlParameter("@tipodoc", _TipoDocVisualizar)

        Try
            g_MiData.F_GetData(xsql, f_data, xp1, xp2)
            RaiseEvent ActualizarFicha()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function CargarDataRelacionada() As Boolean
        Dim xsentencia As String = ""
        Dim xauto As String = ""

        If f_binding.Current IsNot Nothing Then
            xauto = f_binding.Current("auto").ToString
            Try
                xsentencia = "SELECT fecha" & _
                                 ",'CtaCobrar' tipo " & _
                                 ",documento " & _
                                 ",detalle " & _
                                 ",importe " & _
                                 ",(case estatus " & _
                                    "when '1' then 'Anulado' " & _
                                    "else case cancelado " & _
                                        "when '0' then 'Pendiente' " & _
                                        "when '1' then 'Cancelado' End " & _
                                "end) estatus " & _
                         "FROM cxc " & _
                         "WHERE auto_documento = '" & xauto & "' and tipo_documento = 'FAC' " & _
                         "UNION " & _
                         "SELECT d.fecha fecha " & _
                                 ",'Pago' tipo " & _
                                 ",numero_recibo documento " & _
                                 ",r.detalle detalle " & _
                                 ",monto importe " & _
                                 ",(case r.estatus " & _
                                     "when '1' then 'Anulado' " & _
                                     "else '' end) estatus " & _
                         "FROM cxc_documentos d inner join cxc_recibos r on d.auto_cxc_recibo = r.auto inner join cxc c on d.auto_cxc = c.auto " & _
                         "WHERE c.auto_documento = '" & xauto & "' " & _
                         "UNION " & _
                         "SELECT fecha " & _
                              ",'Retención' tipo " & _
                              ",documento " & _
                              ",'' detalle " & _
                              ",retencion importe " & _
                              ",'' estatus " & _
                         "FROM retenciones_ventas_detalle " & _
                         "WHERE auto_documento = '" & xauto & "' " & _
                         "UNION " & _
                         "SELECT fecha " & _
                                 ",(case tipo " & _
                                    "when '02' then 'Nota Débito' " & _
                                    "when '03' then 'Nota Crédito' " & _
                                    "when '04' then 'Nota Entrega' " & _
                                    "when '06' then 'Pedido' end) tipo" & _
                                 ",documento " & _
                                 ",nota detalle " & _
                                 ",total " & _
                                 ",(case estatus " & _
                                     "when '1' then 'Anulado' " & _
                                     "else '' end) estatus " & _
                         "FROM ventas " & _
                         "WHERE auto = '" & xauto & "' and tipo in ('02','03') " & _
                         "UNION " & _
                         "SELECT v.fecha " & _
                                 ",(case v.tipo " & _
                                    "when '01' then 'Factura     ' " & _
                                    "when '04' then 'Nota Entrega' " & _
                                    "when '06' then 'Pedido      ' end) tipo" & _
                                 ",v.documento " & _
                                 ",v.nombre detalle " & _
                                 ",v.total " & _
                                 ",(case v.estatus " & _
                                     "when '1' then 'Anulado' " & _
                                     "else 'Activo' end) estatus " & _
                         "FROM ventas v join ventas_presupuestopedidootros vp on vp.auto_doc_venta=v.auto " & _
                         "WHERE vp.auto_doc_origen = '" & xauto & "'"

                g_MiData.F_GetData(xsentencia, f_datarelacionada)
                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            Me.f_datarelacionada.Rows.Clear()
        End If
    End Function

    Public ReadOnly Property _CantidadRegistros() As String Implements IAdministradorDocumentos._CantidadRegistros
        Get
            Return f_data.Rows.Count.ToString()
        End Get
    End Property

    Public ReadOnly Property _FilterData() As IAdministradorDocumentos.C_FilterData Implements IAdministradorDocumentos._FilterData
        Get
            Return f_filterdata
        End Get
    End Property

    Public ReadOnly Property _CantidadRegistrosRelacionados() As String Implements IAdministradorDocumentos._CantidadRegistrosRelacionados
        Get
            Return f_datarelacionada.Rows.Count.ToString()
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IAdministradorDocumentos._TituloVentana
        Get
            Return "Administrador De Documentos De Ventas"
        End Get
    End Property

    Public ReadOnly Property _AutoDocumento() As String Implements IAdministradorDocumentos._AutoDocumento
        Get
            If f_binding.Current IsNot Nothing Then
                Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                Return xreg("auto").ToString
            Else
                Return ""
            End If
        End Get
    End Property

    Public Function _BusquedaAvanzada() As Boolean Implements IAdministradorDocumentos._BusquedaAvanzada
        Try
            Dim xficha As New BusquedaAvanzadaVenta(_ActivarChimbo)
            AddHandler xficha._LlamarReceptor, AddressOf NuevaBusqueda

            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub NuevaBusqueda(ByVal xfiltro As String)
        Buscar(xfiltro)
    End Sub

    Public Function _VisualizarDocumento() As Boolean Implements IAdministradorDocumentos._VisualizarDocumento
        If f_binding.Current IsNot Nothing Then
            Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
            VisualizarDoc_Ventas(xreg("auto").ToString.Trim)
        End If
    End Function

    Public Function _ConsultarDocumento() As Boolean Implements IAdministradorDocumentos._ConsultarDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row

                If xreg("ESTATUS").ToString.Trim.ToUpper = "ANULADO" Then
                    Dim xficha As DetalleDocumentosAnulados
                    Dim xclas As New c_DetalleDocumentosAnuladosVentas(xreg("auto").ToString)
                    xficha = New DetalleDocumentosAnulados(xclas)
                    xficha.ShowDialog()
                Else
                    Dim xficha As New Ventas_Detalle(xreg("auto").ToString)
                    With xficha
                        .ShowDialog()
                    End With
                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Function

    Public Function _AnularDocumento() As Boolean Implements IAdministradorDocumentos._AnularDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_AnularDocumentos_Ventas.F_Permitir()

                Dim xficha As AnularDocumento = Nothing
                If IsDBNull(f_binding.Current("tipo")) Then
                    xficha = New AnularDocumento(New AnularDocumento_Venta(""))
                Else
                    xficha = New AnularDocumento(New AnularDocumento_Venta(f_binding.Current("tipo")))
                End If

                With xficha
                    .ShowDialog()
                    If ._EstatusSalida Then

                        Dim xdet As String = ._DetalleNotas
                        Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                        Dim xdoc As New FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro
                        Dim xf_venta As New FichaVentas.V_Ventas
                        xf_venta.F_BuscarDocumento(xreg("auto"))

                        With xdoc
                            ._AutoDocumento = xreg("auto")
                            ._CodigoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._CodigoUsuario
                            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
                            ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
                            ._NotasDetalle = xdet
                            ._FechaEmision = g_MiData.p_FechaDelMotorBD
                            ._Hora = g_MiData.p_HoraDelMotorBD
                        End With

                        Dim xventa As New FichaVentas
                        AddHandler xventa.ActualizarTabla, AddressOf ActualizarTabla

                        If xf_venta.RegistroDato._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.NotaCredito Or _
                            xf_venta.RegistroDato._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.ChimboNC Then
                            xventa.F_AnularDocumentoNC(xdoc)
                        Else
                            xventa.F_AnularDocumento(xdoc)
                        End If

                        Funciones.MensajeDeOk("Documento Anulado Satisfactoriamente...")
                    End If
                End With
            Catch ex As Exception
                ActualizarTabla()
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Function

    Sub ActualizarTabla()
        Buscar(_SqlBusquedaActual)
    End Sub

    Sub ActualizarCliente(ByVal xauto As String)
        RaiseEvent _ActualizarFichaCliente(xauto)
    End Sub

    Public Event ActualizarFicha() Implements IAdministradorDocumentos.ActualizarFicha

    Public ReadOnly Property _MostrarChimbo() As Boolean Implements IAdministradorDocumentos._MostrarChimbo
        Get
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ControlVentasAdministrativa_Chimbas.F_Permitir()
                Return True
            Catch ex As Exception
            End Try
        End Get
    End Property

    Public Property _ActivarChimbo() As Boolean Implements IAdministradorDocumentos._ActivarChimbo
        Get
            Return xactivarchimbo
        End Get
        Set(ByVal value As Boolean)
            xactivarchimbo = value
        End Set
    End Property

    Public Function _RevertirDocumento(ByVal xtipodoc As DataSistema.MiDataSistema.DataSistema.TipoDocumentoVenta) As Boolean Implements IAdministradorDocumentos._RevertirDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_RevertirDocumentos_Ventas.F_Permitir()

                Dim xtip As TipoDocumentoVenta
                Select Case f_binding.Current("tipodoc").ToString.Trim.ToUpper
                    Case "01" : xtip = TipoDocumentoVenta.Factura
                    Case "03" : xtip = TipoDocumentoVenta.NotaCredito
                    Case "04" : xtip = TipoDocumentoVenta.NotaEntrega
                    Case "05" : xtip = TipoDocumentoVenta.Presupuesto
                    Case "06" : xtip = TipoDocumentoVenta.Pedido
                    Case "XX" : xtip = TipoDocumentoVenta.Factura
                End Select

                If xtip <> xtipodoc Then
                    Throw New Exception("ERROR AL REVERTIR DOCUMENTO, NO PUEDES REVERTIR UN DOCUMENTO DIFERENTE AL MODULO DONDE TE ENCUENTRAS")
                End If

                Dim xficha As AnularDocumento = Nothing
                If IsDBNull(f_binding.Current("tipo")) Then
                    xficha = New AnularDocumento(New AnularDocumento_Venta(""))
                Else
                    xficha = New AnularDocumento(New AnularDocumento_Venta(f_binding.Current("tipo")))
                End If

                With xficha
                    .ShowDialog()
                    If ._EstatusSalida Then

                        Dim xdet As String = ._DetalleNotas
                        Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                        Dim xdoc As New FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro
                        Dim xrevertir As New FichaVentas.RevertirDocumento

                        With xdoc
                            ._AutoDocumento = xreg("auto")
                            ._CodigoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._CodigoUsuario
                            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
                            ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
                            ._NotasDetalle = xdet
                            ._FechaEmision = g_MiData.p_FechaDelMotorBD
                            ._Hora = g_MiData.p_HoraDelMotorBD
                        End With

                        With xrevertir
                            ._AutoDeposito = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoInventarioVentas
                            ._BloquearExistencia = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Ruptura_Por_Existencia
                            ._Estacion = g_EquipoEstacion.p_EstacionNombre
                            ._Fecha = g_MiData.p_FechaDelMotorBD
                            ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                            ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
                        End With

                        Dim xventa As New FichaVentas
                        AddHandler xventa.ActualizarTabla, AddressOf ActualizarTabla
                        AddHandler xventa._ActualizarFichaCliente, AddressOf ActualizarCliente

                        xventa.F_AnularDocumento(xdoc, xrevertir)
                        MessageBox.Show("Documento Anulado Satisfactoriamente", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End With
            Catch ex As Exception
                ActualizarTabla()
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _ReimprimirDocumento() As Boolean Implements IAdministradorDocumentos._ReimprimirDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xauto As String = f_binding.Current("auto").ToString.Trim
                Dim xf As New FichaVentas.V_Ventas
                xf.F_BuscarDocumento(xauto)

                If xf.RegistroDato._EstatusDocumento = TipoEstatus.Activo Then
                    Dim xfactura As LibImprimir.LibImprimir
                    xfactura = New LibImprimir.LibImprimir(xauto, _MiCadenaConexion)
                    Select Case xf.RegistroDato._TipoDocumento
                        Case FichaVentas.TipoDocumentoVentaRegistrado.Factura
                            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = TipoImpresora.Fiscal Or g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = TipoImpresora.Texto Then
                                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTextoNotas, My.Application.Info.DirectoryPath + "\FORMATOS\FACTURA_C.XML")
                            Else
                                Funciones.VisualizarDoc_Ventas(xauto)
                            End If
                        Case FichaVentas.TipoDocumentoVentaRegistrado.NotaCredito
                            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALNCR_MedioImpresion = TipoImpresora.Fiscal Or g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = TipoImpresora.Texto Then
                                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTextoNotas, My.Application.Info.DirectoryPath + "\FORMATOS\NOTAC_C.XML")
                            Else
                                Funciones.VisualizarDoc_Ventas(xauto)
                            End If
                        Case FichaVentas.TipoDocumentoVentaRegistrado.NotaDebito
                            MessageBox.Show("Documento No Apto Para Esta Opcion, Use La Opcion Visualizar Documento", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Case FichaVentas.TipoDocumentoVentaRegistrado.NotaEntrega
                            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._NOTAENTREGA_MODO_IMPRESION = TipoImpresora.Texto Then
                                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTextoNotas, My.Application.Info.DirectoryPath + "\FORMATOS\NOTAE_C.XML")
                            Else
                                Funciones.VisualizarDoc_Ventas(xauto)
                            End If
                        Case FichaVentas.TipoDocumentoVentaRegistrado.Pedido
                            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PEDIDO_MODO_IMPRESION = TipoImpresora.Texto Then
                                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTextoNotas, My.Application.Info.DirectoryPath + "\FORMATOS\PEDIDO_C.XML")
                            Else
                                Funciones.VisualizarDoc_Ventas(xauto)
                            End If
                        Case FichaVentas.TipoDocumentoVentaRegistrado.Presupuesto
                            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PRESUPUESTO_MODO_IMPRESION = TipoImpresora.Texto Then
                                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTextoNotas, My.Application.Info.DirectoryPath + "\FORMATOS\PRESUP_C.XML")
                            Else
                                Funciones.VisualizarDoc_Ventas(xauto)
                            End If
                        Case FichaVentas.TipoDocumentoVentaRegistrado.Chimbo
                            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._OTROS_MODO_IMPRESION = TipoImpresora.Texto Then
                                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTextoNotas, My.Application.Info.DirectoryPath + "\FORMATOS\OTRA_C.XML")
                            Else
                                Funciones.VisualizarDoc_Ventas(xauto)
                            End If
                        Case FichaVentas.TipoDocumentoVentaRegistrado.ChimboNC
                            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._OTROS_MODO_IMPRESION = TipoImpresora.Texto Then
                                xfactura.ImprimirFactura(g_ConfiguracionSistema._RutaImpresoraTextoNotas, My.Application.Info.DirectoryPath + "\FORMATOS\OTRANC_C.XML")
                            Else
                                Funciones.VisualizarDoc_Ventas(xauto)
                            End If
                    End Select
                Else
                    Funciones.MensajeDeAlerta("Documento Se Encuentra Anulado, Opcion No Permitida")
                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Function

    Private Sub xTrasladarVenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles xTrasladarVenta.Click
        If _TipoDocumentoEnProceso = TipoDocumentoVenta.Factura Then
            If f_binding.Current IsNot Nothing Then
                Try
                    Dim xdoc As New FichaVentas.V_Ventas
                    xdoc.F_BuscarDocumento(f_binding.Current("auto").ToString)
                    Select Case xdoc.RegistroDato._TipoDocumento
                        Case FichaVentas.TipoDocumentoVentaRegistrado.Presupuesto
                            If xdoc.RegistroDato._EstatusDocumento = TipoEstatus.Inactivo Then
                                Throw New Exception("DOCUMENTO NO PUEDE SER TRASLADADO A VENTAS YA QUE SE ENCUENTRA ANULADO")
                            Else
                                RaiseEvent _TrasladarDocumentoVenta(xdoc.RegistroDato._AutoDocumento)
                                xform.Close()
                            End If
                        Case FichaVentas.TipoDocumentoVentaRegistrado.Pedido
                            If xdoc.RegistroDato._EstatusDocumento = TipoEstatus.Procesado Then
                                MessageBox.Show("ERROR AL TRASLADAR DOCUMENTO DE PEDIDO. DOCUMENTO YA FUE PROCESADO", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ElseIf xdoc.RegistroDato._EstatusDocumento = TipoEstatus.Activo Then
                                RaiseEvent _TrasladarDocumentoVenta(xdoc.RegistroDato._AutoDocumento)
                                xform.Close()
                            Else
                                Throw New Exception("DOCUMENTO NO PUEDE SER TRASLADADO A VENTAS YA QUE SE ENCUENTRA ANULADO")
                            End If
                        Case FichaVentas.TipoDocumentoVentaRegistrado.NotaEntrega
                            If xdoc.RegistroDato._EstatusDocumento = TipoEstatus.Procesado Then
                                MessageBox.Show("ERROR AL TRASLADAR DOCUMENTO DE PEDIDO. DOCUMENTO YA FUE PROCESADO", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ElseIf xdoc.RegistroDato._EstatusDocumento = TipoEstatus.Activo Then
                                RaiseEvent _TrasladarDocumentoVenta(xdoc.RegistroDato._AutoDocumento)
                                xform.Close()
                            Else
                                Throw New Exception("DOCUMENTO NO PUEDE SER TRASLADADO A VENTAS YA QUE SE ENCUENTRA ANULADO")
                            End If
                        Case Else
                            Funciones.MensajeDeAlerta("PROBLEMA AL SELECCIONAR TIPO DE DOCUMENTO A TRASLADAR A VENTA. SOLO SE PERIMITEN DOCUMENTO TIPO PRESUPUESTO/PEDIDO/NOTA DE ENTREGA")
                    End Select
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        ElseIf _TipoDocumentoEnProceso = TipoDocumentoVenta.NotaEntrega Then
            If f_binding.Current IsNot Nothing Then
                Try
                    Dim xdoc As New FichaVentas.V_Ventas
                    xdoc.F_BuscarDocumento(f_binding.Current("auto").ToString)
                    Select Case xdoc.RegistroDato._TipoDocumento
                        Case FichaVentas.TipoDocumentoVentaRegistrado.Pedido
                            RaiseEvent _TrasladarDocumentoVenta(xdoc.RegistroDato._AutoDocumento)
                            xform.Close()
                        Case Else
                            Funciones.MensajeDeAlerta("PROBLEMA AL SELECCIONAR TIPO DE DOCUMENTO A TRASLADAR. SOLO SE PERIMITEN DOCUMENTO TIPO PEDIDO...")
                    End Select
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        ElseIf _TipoDocumentoEnProceso = TipoDocumentoVenta.Presupuesto Then
            If f_binding.Current IsNot Nothing Then
                Try
                    Dim xdoc As New FichaVentas.V_Ventas
                    xdoc.F_BuscarDocumento(f_binding.Current("auto").ToString)
                    Select Case xdoc.RegistroDato._TipoDocumento
                        Case FichaVentas.TipoDocumentoVentaRegistrado.Presupuesto
                            RaiseEvent _TrasladarDocumentoVenta(xdoc.RegistroDato._AutoDocumento)
                            xform.Close()
                        Case Else
                            Funciones.MensajeDeAlerta("PROBLEMA AL SELECCIONAR TIPO DE DOCUMENTO A TRASLADAR A PRESUPUESTO. SOLO SE PERIMITEN DOCUMENTO TIPO PRESUPUESTO...")
                    End Select
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        ElseIf _TipoDocumentoEnProceso = TipoDocumentoVenta.Pedido Then
            If f_binding.Current IsNot Nothing Then
                Try
                    Dim xdoc As New FichaVentas.V_Ventas
                    xdoc.F_BuscarDocumento(f_binding.Current("auto").ToString)
                    Select Case xdoc.RegistroDato._TipoDocumento
                        Case FichaVentas.TipoDocumentoVentaRegistrado.Presupuesto
                            RaiseEvent _TrasladarDocumentoVenta(xdoc.RegistroDato._AutoDocumento)
                            xform.Close()
                        Case Else
                            Funciones.MensajeDeAlerta("PROBLEMA AL SELECCIONAR TIPO DE DOCUMENTO A TRASLADAR A PEDIDO. SOLO SE PERIMITEN DOCUMENTO TIPO PRESUPUESTO...")
                    End Select
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        Else
            Funciones.MensajeDeAlerta("PROBLEMA AL QUERER TRASLADAR DOCUMENTO. DEBES ESTAR EN EL MODULO DE VENTAS / PRESUPUESTOS / PEDIDO ...")
        End If
    End Sub

    Public Sub Inicializa(ByVal xobj1 As Object, ByVal xobj2 As Object) Implements IAdministradorDocumentos.Inicializa
        Try
            xform = CType(xobj1, System.Windows.Forms.Form)
            mcb_estatus_documento = xform.Controls.Find("MCB_ESTATUS_DOC", True)(0)

            xTrasladarVenta = CType(xobj2, ToolStripMenuItem)
            mcb_estatus_documento.DataSource = xlista_estatus
            mcb_estatus_documento.SelectedIndex = 3

            If _TipoDocumentoEnProceso = TipoDocumentoVenta.Presupuesto Then
                Me.xTrasladarVenta.Text = "Trasladar Documento A Presupuesto"
            ElseIf _TipoDocumentoEnProceso = TipoDocumentoVenta.Pedido Then
                Me.xTrasladarVenta.Text = "Trasladar Documento A Pedido"
            ElseIf _TipoDocumentoEnProceso = TipoDocumentoVenta.NotaEntrega Then
                Me.xTrasladarVenta.Text = "Trasladar Documento A Nota de Entrega"
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Public Function _GuiaDespacho() As Boolean Implements IAdministradorDocumentos._GuiaDespacho
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                Dim xauto As String = xreg("auto").ToString.Trim
                Dim xf As New FichaVentas.V_Ventas
                xf.F_BuscarDocumento(xauto)
                Select Case xf.RegistroDato._TipoDocumento
                    Case FichaVentas.TipoDocumentoVentaRegistrado.Chimbo, _
                        FichaVentas.TipoDocumentoVentaRegistrado.Factura, _
                        FichaVentas.TipoDocumentoVentaRegistrado.NotaEntrega, _
                        FichaVentas.TipoDocumentoVentaRegistrado.Pedido : VisualizarDoc_GuiaDespacho(xauto)
                    Case Else
                        Throw New Exception("Tipo De Documento Incorrecto... Verifique Por Favor")
                End Select
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Function

    Public Function _CAMBIAR_ESTATUS_DOCUMENTO() As Boolean Implements IAdministradorDocumentos._CAMBIAR_ESTATUS_DOCUMENTO
        Dim rt = False
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xventas As New FichaVentas
                Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                Dim xauto As String = xreg("auto").ToString.Trim
                Dim xf As New FichaVentas.V_Ventas
                xf.F_BuscarDocumento(xauto)
                If xf.RegistroDato._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Pedido Then
                    If xf.RegistroDato._EstatusDocumento = TipoEstatus.Procesado Then
                        Dim msg = MessageBox.Show("Estas Seguro De Cambiar El Estatus De Este Pedido ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If msg = DialogResult.Yes Then
                            Dim rt01 = xventas.F_Pedido_ListaPrd_Involucrado(xauto)
                            If rt01.IsError Then
                                Throw New Exception(rt01.Mensaje)
                            End If

                            Dim fichaCambioEstatus = New DataSistema.Pedido_CambioEstatusActivo
                            With fichaCambioEstatus
                                .autoDoc = xauto
                                .items = rt01.Lista.Select(Function(x)
                                                               Dim rg = New DataSistema.Pedido_CambioEstatusActivo_Item
                                                               With rg
                                                                   .auto_deposito = x.autoDep
                                                                   .auto_producto = x.autoPrd
                                                                   .cnt = x.cnt
                                                                   .nombrePrd = x.nomPrd
                                                               End With
                                                               Return rg
                                                           End Function).ToList
                            End With
                            Dim rt02 = xventas.F_Pedido_CambiarEstatusProcesado_Activo(fichaCambioEstatus)
                            If rt02.Result = Resultado.EnumResult.isError Then
                                Throw New Exception(rt02.Mensaje)
                            End If
                            Funciones.MensajeDeOk("DOCUMENTO ACTUALIZADO EXITOSAMENTE")
                            Return True
                        End If
                    Else
                        Throw New Exception("Estatus Documento Incorrecto... Verifique Por Favor")
                    End If
                Else
                    Throw New Exception("Tipo De Documento Incorrecto... Verifique Por Favor")
                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
        Return rt
    End Function

End Class