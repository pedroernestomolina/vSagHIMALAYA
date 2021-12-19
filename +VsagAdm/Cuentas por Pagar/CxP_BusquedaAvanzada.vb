Imports System.Data.SqlClient
Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema

Public Class CxP_BusquedaAvanzada
    Dim _Plantilla As ICxP_BusquedaAvanzada

    Sub New(ByVal xplantilla As ICxP_BusquedaAvanzada)

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

    Private Sub CxP_BusquedaAvanzada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface ICxP_BusquedaAvanzada
    Sub Inicializar(ByVal xformulario As Object)
End Interface

Class c_CxP_BusquedaAvanzada
    Implements ICxP_BusquedaAvanzada
    Event RetornarAutoProveedor(ByVal xauto As String)

#Region "FUNCIONES SELECT"
    Const SELECT_GRUPOS As String = "SELECT nombre" & _
                                    "       ,auto " & _
                                    "FROM grupo_proveedor " & _
                                    "ORDER BY nombre"
#End Region

    'FORMULARIOS
    Dim _MiFormulario As System.Windows.Forms.Form = Nothing

    'CONTROLES A MANEJAR
    Dim LB_ITEMS_1 As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim MC_GRUPOS As MisCheckBox
    Dim MC_TIPODOCUMENTOS As MisCheckBox
    WithEvents MC_NRODOCUMENTO As MisCheckBox
    Dim MCB_GRUPOS As MisComboBox
    Dim MCB_TIPODOCUMENTOS As MisComboBox
    Dim MT_NRODOCUMENTO As MisTextos
    Dim MG_PROVEEDOR As MisGrid
    WithEvents BT_PROCESAR As Button

    Dim DTB_GRUPOS As DataTable
    Dim DTB_PROVEEDORES As DataTable
    Dim BS_PROVEEDORES As BindingSource
    
    Dim V_TIPODOCUMENTO As String() = {"PENDIENTES", "PENDIENTES VENCIDOS", "SOLVENTES", "ANULADOS"}

    'PROPERTY
    ReadOnly Property _RegistrosEncontrados()
        Get
            Return DTB_PROVEEDORES.Rows.Count
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
        g_MiData.F_GetData(SELECT_GRUPOS, DTB_GRUPOS)
        DTB_PROVEEDORES = New DataTable
        BS_PROVEEDORES = New BindingSource(DTB_PROVEEDORES, "")
    End Sub

    Sub ActualizarRegistrosEncontrados()
        Dim ximporte As Decimal = 0
        For Each xrow In DTB_PROVEEDORES.Rows
            ximporte += xrow("debe")
        Next
        _TotalImporte = ximporte
        LB_ITEMS_1.Text = _RegistrosEncontrados.ToString()
        LB_IMPORTE.Text = String.Format("{0:#0.00}", _TotalImporte)
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements ICxP_BusquedaAvanzada.Inicializar
        Try
            _MiFormulario = xformulario

            LB_ITEMS_1 = _MiFormulario.Controls.Find("LB_ITEMS_1", True)(0)
            LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
            MC_GRUPOS = _MiFormulario.Controls.Find("MC_GRUPOS", True)(0)
            MC_TIPODOCUMENTOS = _MiFormulario.Controls.Find("MC_TIPODOCUMENTOS", True)(0)
            MC_NRODOCUMENTO = _MiFormulario.Controls.Find("MC_NRODOCUMENTO", True)(0)
            MCB_GRUPOS = _MiFormulario.Controls.Find("MCB_GRUPOS", True)(0)
            MCB_TIPODOCUMENTOS = _MiFormulario.Controls.Find("MCB_TIPODOCUMENTOS", True)(0)
            MT_NRODOCUMENTO = _MiFormulario.Controls.Find("MT_NRODOCUMENTO", True)(0)
            MG_PROVEEDOR = _MiFormulario.Controls.Find("MG_PROVEEDOR", True)(0)
            BT_PROCESAR = _MiFormulario.Controls.Find("BT_PROCESAR", True)(0)
            _MiFormulario.Text = "Busqueda Avanzada De Proveedores"

            With MT_NRODOCUMENTO
                .MaxLength = 15
                .Text = ""
                .p_IniciarComo = False
                AddHandler MT_NRODOCUMENTO.LostFocus, AddressOf ActualizarProveedores
            End With

            With MC_GRUPOS
                .Checked = False
                AddHandler .CheckedChanged, AddressOf EstatusGrupos
            End With

            With MC_TIPODOCUMENTOS
                .Checked = False
                AddHandler .CheckedChanged, AddressOf EstatusTipoDocumento
            End With

            With MC_NRODOCUMENTO
                .Checked = False
                AddHandler .CheckedChanged, AddressOf EstatusNumeroDocumento
            End With

            With MCB_GRUPOS
                .DataSource = DTB_GRUPOS
                .DisplayMember = "nombre"
                .ValueMember = "auto"
                .Enabled = False
            End With

            With MCB_TIPODOCUMENTOS
                .DataSource = V_TIPODOCUMENTO
                .SelectedIndex = 0
                .Enabled = False
            End With

            With MG_PROVEEDOR
                .Columns.Add("col0", "Proveedor")
                .Columns.Add("col1", "CI/RIF")
                .Columns.Add("col2", "Debe")

                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).Width = 90
                .Columns(2).Width = 90
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                AddHandler .Accion, AddressOf ObtenerProveedor
            End With

            Me.LB_ITEMS_1.Text = String.Format("{0:#0}", 0)
            Me.LB_IMPORTE.Text = String.Format("{0:#0.00}", 0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub EstatusGrupos()
        MCB_GRUPOS.Enabled = MC_GRUPOS.Checked
    End Sub

    Sub EstatusTipoDocumento()
        MCB_TIPODOCUMENTOS.Enabled = MC_TIPODOCUMENTOS.Checked
    End Sub

    Sub EstatusNumeroDocumento()
        MT_NRODOCUMENTO.p_IniciarComo = MC_NRODOCUMENTO.Checked
    End Sub

    Sub ActualizarProveedores()
        Dim xcondicion As String = ""
        Dim xsentencia As String = "select p.nombre" & _
                                   "    ,p.ci_rif" & _
                                   "    ,sum(c.resta) debe" & _
                                   "    ,p.auto " & _
                                   "from proveedores p inner join cxp c on p.auto=c.auto_proveedor where p.auto<>'' "

        If MC_GRUPOS.Checked And MCB_GRUPOS.SelectedIndex > 0 Then
            xcondicion += "and p.auto_grupo='" + MCB_GRUPOS.SelectedValue + "' "
        End If

        If MC_TIPODOCUMENTOS.Checked Then
            Select Case MCB_TIPODOCUMENTOS.SelectedIndex
                Case E_TiposDocumentos.DocumentosPendientes
                    xcondicion += "and c.cancelado='0' and c.tipo_documento<>'PAG' and c.estatus='0' "
                Case E_TiposDocumentos.DocumentosPendientesVencidos
                    Dim xfec As Date = g_MiData.p_FechaDelMotorBD
                    xcondicion += "and c.cancelado='0' and c.fecha_vencimiento<'" & xfec.ToShortDateString & "' and c.tipo_documento<>'PAG' and c.estatus='0' "
                Case E_TiposDocumentos.DocumentosSolventes
                    xcondicion += "and c.cancelado='1' and c.tipo_documento<>'PAG' and c.estatus='0' "
                Case E_TiposDocumentos.DocumentosAnulados
                    xcondicion += "and c.estatus='1' and c.tipo_documento<>'PAG' "
            End Select
        End If

        If MC_NRODOCUMENTO.Checked Then
            xcondicion += "and c.documento='" + MT_NRODOCUMENTO.r_Valor + "' "
        End If
        xsentencia += xcondicion + "group by p.nombre, p.ci_rif, p.auto order by p.nombre"
        g_MiData.F_GetData(xsentencia, DTB_PROVEEDORES)
        ActualizarRegistrosEncontrados()
    End Sub

    Sub ObtenerProveedor()
        Dim xauto As String = BS_PROVEEDORES.Current("auto")
        RaiseEvent RetornarAutoProveedor(xauto)
        _MiFormulario.Close()
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        ActualizarProveedores()
        With MG_PROVEEDOR
            .DataSource = BS_PROVEEDORES
            .Columns(0).DataPropertyName = "nombre"
            .Columns(1).DataPropertyName = "ci_rif"
            .Columns(2).DataPropertyName = "debe"
            .Ocultar(4)
        End With
    End Sub

    Private Sub MC_NRODOCUMENTO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MC_NRODOCUMENTO.Click
        Me.MT_NRODOCUMENTO.Select()
        Me.MT_NRODOCUMENTO.Focus()
    End Sub
End Class