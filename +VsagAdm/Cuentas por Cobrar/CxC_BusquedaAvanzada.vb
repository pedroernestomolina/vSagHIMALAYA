Imports System.Data.SqlClient
Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema

Public Class CxC_BusquedaAvanzada
    Dim _Plantilla As ICxC_BusquedaAvanzada

    Sub New(ByVal xplantilla As ICxC_BusquedaAvanzada)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Sub Inicializar()
        _Plantilla.Inicializar(Me)
    End Sub

    Private Sub CxC_BusquedaAvanzada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub CxC_BusquedaAvanzada_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializar()
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR FORMULARIO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub
End Class

Public Interface ICxC_BusquedaAvanzada
    Sub Inicializar(ByVal xformulario As Object)
End Interface

Class c_CxC_BusquedaAvanzada
    Implements ICxC_BusquedaAvanzada
    Event RetornarAutoCliente(ByVal xauto As String)

#Region "FUNCIONES SELECT"
    Const SELECT_GRUPOS As String = "SELECT nombre" & _
                                    "       ,auto " & _
                                    "FROM grupo_cliente " & _
                                    "ORDER BY nombre"

    Const SELECT_ESTADOS As String = "SELECT nombre" & _
                                    "       ,auto " & _
                                    "FROM estados " & _
                                    "ORDER BY nombre"

    Const SELECT_ZONAS As String = "SELECT nombre" & _
                                    "     ,auto " & _
                                    "     ,auto_estado " & _
                                    "FROM zona_cliente " & _
                                    "ORDER BY nombre"

    Const SELECT_VENDEDORES As String = "SELECT nombre" & _
                                        "       ,auto " & _
                                        "FROM vendedores " & _
                                        "ORDER BY nombre"

    Const SELECT_COBRADORES As String = "SELECT nombre" & _
                                        "       ,auto " & _
                                        "FROM cobradores " & _
                                        "ORDER BY nombre"
    
#End Region

    'FORMULARIOS
    Dim _MiFormulario As System.Windows.Forms.Form = Nothing

    'CONTROLES A MANEJAR
    Dim LB_ITEMS_1 As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim MC_GRUPOS As MisCheckBox
    Dim MC_ESTADOS As MisCheckBox
    Dim MC_ZONAS As MisCheckBox
    Dim MC_VENDEDORES As MisCheckBox
    Dim MC_COBRADORES As MisCheckBox
    Dim MC_TIPODOCUMENTOS As MisCheckBox
    Dim MC_NRODOCUMENTO As MisCheckBox
    Dim MCB_GRUPOS As MisComboBox
    Dim MCB_ESTADOS As MisComboBox
    Dim MCB_ZONAS As MisComboBox
    Dim MCB_VENDEDORES As MisComboBox
    Dim MCB_COBRADORES As MisComboBox
    Dim MCB_TIPODOCUMENTOS As MisComboBox
    Dim MT_NRODOCUMENTO As MisTextos
    Dim MG_CLIENTE As MisGrid
    WithEvents BT_PROCESAR As Button

    Dim DTS_ESTADOS As DataSet
    Dim DTB_GRUPOS As DataTable
    Dim DTB_ESTADOS As DataTable
    Dim DTB_ZONAS As DataTable
    Dim DTB_VENDEDORES As DataTable
    Dim DTB_COBRADORES As DataTable
    Dim DTB_CLIENTES As DataTable
    Dim BS_CLIENTES As BindingSource
    Dim BS_ESTADOS As BindingSource
    Dim BS_ZONAS As BindingSource

    Dim V_TIPODOCUMENTO As String() = {"PENDIENTES", "PENDIENTES VENCIDOS", "SOLVENTES", "ANULADOS"}

    'PROPERTY
    ReadOnly Property _RegistrosEncontrados()
        Get
            Return DTB_CLIENTES.Rows.Count
        End Get
    End Property

    Dim xtotal As Decimal = 0
    Property _TotalImporte() As Decimal
        Get
            Return xtotal
        End Get
        Set(ByVal value As Decimal)
            xtotal = value
        End Set
    End Property

    'ENUMERADOS
    Enum E_TiposDocumentos As Integer
        DocumentosPendientes = 0
        DocumentosPendientesVencidos = 1
        DocumentosSolventes = 2
        DocumentosAnulados = 3
    End Enum

    Sub New()
        DTB_GRUPOS = New DataTable
        DTB_ESTADOS = New DataTable("ESTADOS")
        DTB_ZONAS = New DataTable("ZONAS")
        DTB_VENDEDORES = New DataTable
        DTB_COBRADORES = New DataTable

        g_MiData.F_GetData(SELECT_GRUPOS, DTB_GRUPOS)
        g_MiData.F_GetData(SELECT_ESTADOS, DTB_ESTADOS)
        g_MiData.F_GetData(SELECT_ZONAS, DTB_ZONAS)
        g_MiData.F_GetData(SELECT_VENDEDORES, DTB_VENDEDORES)
        g_MiData.F_GetData(SELECT_COBRADORES, DTB_COBRADORES)

        DTS_ESTADOS = New DataSet

        DTS_ESTADOS.Tables.Add(DTB_ESTADOS)
        DTS_ESTADOS.Tables.Add(DTB_ZONAS)

        Dim rel As DataRelation = New DataRelation("ESTADOS_ZONAS", DTB_ESTADOS.Columns("auto"), DTB_ZONAS.Columns("auto_estado"))
        DTS_ESTADOS.Relations.Add(rel)

        BS_ESTADOS = New BindingSource(DTS_ESTADOS, "ESTADOS")
        BS_ZONAS = New BindingSource(BS_ESTADOS, "ESTADOS_ZONAS")

        DTB_CLIENTES = New DataTable
        BS_CLIENTES = New BindingSource(DTB_CLIENTES, "")
    End Sub

    Sub ActualizarRegistrosEncontrados()
        Dim ximporte As Decimal = 0
        For Each xrow In DTB_CLIENTES.Rows
            ximporte += xrow("debe")
        Next
        _TotalImporte = ximporte
        LB_ITEMS_1.Text = _RegistrosEncontrados.ToString()
        LB_IMPORTE.Text = String.Format("{0:#0.00}", _TotalImporte)
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements ICxC_BusquedaAvanzada.Inicializar
        _MiFormulario = xformulario

        LB_ITEMS_1 = _MiFormulario.Controls.Find("LB_ITEMS_1", True)(0)
        LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
        MC_GRUPOS = _MiFormulario.Controls.Find("MC_GRUPOS", True)(0)
        MC_ESTADOS = _MiFormulario.Controls.Find("MC_ESTADOS", True)(0)
        MC_ZONAS = _MiFormulario.Controls.Find("MC_ZONAS", True)(0)
        MC_VENDEDORES = _MiFormulario.Controls.Find("MC_VENDEDORES", True)(0)
        MC_COBRADORES = _MiFormulario.Controls.Find("MC_COBRADORES", True)(0)
        MC_TIPODOCUMENTOS = _MiFormulario.Controls.Find("MC_TIPODOCUMENTOS", True)(0)
        MC_NRODOCUMENTO = _MiFormulario.Controls.Find("MC_NRODOCUMENTO", True)(0)
        MCB_GRUPOS = _MiFormulario.Controls.Find("MCB_GRUPOS", True)(0)
        MCB_ESTADOS = _MiFormulario.Controls.Find("MCB_ESTADOS", True)(0)
        MCB_ZONAS = _MiFormulario.Controls.Find("MCB_ZONAS", True)(0)
        MCB_VENDEDORES = _MiFormulario.Controls.Find("MCB_VENDEDORES", True)(0)
        MCB_COBRADORES = _MiFormulario.Controls.Find("MCB_COBRADORES", True)(0)
        MCB_TIPODOCUMENTOS = _MiFormulario.Controls.Find("MCB_TIPODOCUMENTOS", True)(0)
        MT_NRODOCUMENTO = _MiFormulario.Controls.Find("MT_NRODOCUMENTO", True)(0)
        MG_CLIENTE = _MiFormulario.Controls.Find("MG_CLIENTE", True)(0)
        BT_PROCESAR = _MiFormulario.Controls.Find("BT_PROCESAR", True)(0)
        _MiFormulario.Text = "Busqueda Avanzada De Clientes"

        MT_NRODOCUMENTO.p_IniciarComo = False
        AddHandler MT_NRODOCUMENTO.LostFocus, AddressOf ActualizarClientes

        InicializarCheckBox()
        F_CargarCombos()
        F_CargarDataGridView()

        Me.LB_ITEMS_1.Text = String.Format("{0:#0}", 0)
        Me.LB_IMPORTE.Text = String.Format("{0:#0.00}", 0)
    End Sub

    Sub InicializarCheckBox()
        With MC_GRUPOS
            .Checked = False
            AddHandler .CheckedChanged, AddressOf EstatusGrupos
        End With

        With MC_ESTADOS
            .Checked = False
            AddHandler .CheckedChanged, AddressOf EstatusEstados
        End With

        With MC_ZONAS
            .Checked = False
            AddHandler .CheckedChanged, AddressOf EstatusZonas
        End With

        With MC_VENDEDORES
            .Checked = False
            AddHandler .CheckedChanged, AddressOf EstatusVendedores
        End With

        With MC_COBRADORES
            .Checked = False
            AddHandler .CheckedChanged, AddressOf EstatusCobradores
        End With

        With MC_TIPODOCUMENTOS
            .Checked = False
            AddHandler .CheckedChanged, AddressOf EstatusTipoDocumento
        End With

        With MC_NRODOCUMENTO
            .Checked = False
            AddHandler .CheckedChanged, AddressOf EstatusNumeroDocumento
        End With
    End Sub

    Sub EstatusGrupos()
        MCB_GRUPOS.Enabled = MC_GRUPOS.Checked
    End Sub

    Sub EstatusZonas()
        If Me.MC_ESTADOS.Checked Then
            MCB_ZONAS.Enabled = Me.MC_ZONAS.Checked
        Else
            MC_ZONAS.Checked = False
        End If
    End Sub

    Sub EstatusEstados()
        MCB_ESTADOS.Enabled = MC_ESTADOS.Checked
        If MC_ESTADOS.Checked = False Then
            MCB_ZONAS.Enabled = False
            MC_ZONAS.Checked = False
        End If
    End Sub

    Sub EstatusVendedores()
        MCB_VENDEDORES.Enabled = MC_VENDEDORES.Checked
    End Sub

    Sub EstatusCobradores()
        MCB_COBRADORES.Enabled = MC_COBRADORES.Checked
    End Sub

    Sub EstatusTipoDocumento()
        MCB_TIPODOCUMENTOS.Enabled = MC_TIPODOCUMENTOS.Checked
    End Sub

    Sub EstatusNumeroDocumento()
        MT_NRODOCUMENTO.p_IniciarComo = MC_NRODOCUMENTO.Checked
    End Sub

    Sub ActualizarClientes()
        Dim xsentencia As String = "select cliente.nombre" & _
                                   "    ,cliente.ci_rif" & _
                                   "    ,sum(cxc.resta) debe" & _
                                   "    ,cliente.auto " & _
                                   "from clientes cliente inner join cxc on cliente.auto=cxc.auto_cliente "

        Dim xcondicion As String = "where cliente.AUTO<>'' "

        If MC_GRUPOS.Checked And MCB_GRUPOS.SelectedIndex > 0 Then
            xcondicion += "and cliente.auto_grupo='" + MCB_GRUPOS.SelectedValue + "' "
        End If

        If MC_ESTADOS.Checked And MCB_ESTADOS.SelectedIndex > 0 Then
            xcondicion += "and cliente.auto_estado='" + MCB_ESTADOS.SelectedValue + "' "
        End If

        If MC_ZONAS.Checked And MCB_ZONAS.SelectedIndex > 0 Then
            xcondicion += "and cliente.auto_zona='" + MCB_ZONAS.SelectedValue + "' "
        End If

        If MC_VENDEDORES.Checked And MCB_VENDEDORES.SelectedIndex > 0 Then
            xcondicion += "and cliente.auto_vendedor='" + MCB_VENDEDORES.SelectedValue + "' "
        End If

        If MC_COBRADORES.Checked And MCB_COBRADORES.SelectedIndex > 0 Then
            xcondicion += "and cliente.auto_cobrador='" + MCB_COBRADORES.SelectedValue + "' "
        End If

        If MC_TIPODOCUMENTOS.Checked Then
            Select Case MCB_TIPODOCUMENTOS.SelectedIndex
                Case E_TiposDocumentos.DocumentosPendientes
                    xcondicion += "and cxc.cancelado='0' and cxc.tipo_documento<>'PAG' and cxc.estatus='0' "
                Case E_TiposDocumentos.DocumentosPendientesVencidos
                    xcondicion += "and cxc.cancelado='0' and cxc.fecha_vencimiento<getdate() and cxc.tipo_documento<>'PAG' and cxc.estatus='0' "
                Case E_TiposDocumentos.DocumentosSolventes
                    xcondicion += "and cxc.cancelado='1' and cxc.tipo_documento<>'PAG' and cxc.estatus='0' "
                Case E_TiposDocumentos.DocumentosAnulados
                    xcondicion += "and cxc.estatus='1' and cxc.tipo_documento<>'PAG' "
            End Select
        End If

        If MC_NRODOCUMENTO.Checked Then
            xcondicion += "and cxc.documento='" + MT_NRODOCUMENTO.r_Valor + "' "
        End If
        xsentencia += xcondicion + "group by cliente.nombre, cliente.ci_rif, cliente.auto order by cliente.nombre"
        g_MiData.F_GetData(xsentencia, DTB_CLIENTES)
        ActualizarRegistrosEncontrados()
    End Sub

    Public Function F_CargarCombos() As Boolean
        With MCB_GRUPOS
            .DataSource = DTB_GRUPOS
            .DisplayMember = "nombre"
            .ValueMember = "auto"
            .Enabled = False
        End With

        With MCB_ESTADOS
            .DataSource = BS_ESTADOS
            .DisplayMember = "nombre"
            .ValueMember = "auto"
            .Enabled = False
        End With

        With MCB_ZONAS
            .DataSource = BS_ZONAS
            .DisplayMember = "nombre"
            .ValueMember = "auto"
            .Enabled = False
        End With

        With MCB_VENDEDORES
            .DataSource = DTB_VENDEDORES
            .DisplayMember = "nombre"
            .ValueMember = "auto"
            .Enabled = False
        End With

        With MCB_COBRADORES
            .DataSource = DTB_COBRADORES
            .DisplayMember = "nombre"
            .ValueMember = "auto"
            .Enabled = False
        End With

        With MCB_TIPODOCUMENTOS
            .DataSource = V_TIPODOCUMENTO
            .SelectedIndex = 0
            .Enabled = False
        End With

        Return True
    End Function

    Public Function F_CargarDataGridView() As Boolean
        With MG_CLIENTE
            .Columns.Add("col0", "Cliente")
            .Columns.Add("col1", "CI/RIF")
            .Columns.Add("col2", "Debe")

            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).Width = 90
            .Columns(2).Width = 70
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            AddHandler .Accion, AddressOf ObtenerCliente
        End With
    End Function

    Sub ObtenerCliente()
        Dim xauto As String = BS_CLIENTES.Current("auto")
        RaiseEvent RetornarAutoCliente(xauto)
        _MiFormulario.Close()
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        ActualizarClientes()
        With MG_CLIENTE
            .DataSource = BS_CLIENTES
            .Columns(0).DataPropertyName = "nombre"
            .Columns(1).DataPropertyName = "ci_rif"
            .Columns(2).DataPropertyName = "debe"
            .Ocultar(4)
        End With
    End Sub
End Class