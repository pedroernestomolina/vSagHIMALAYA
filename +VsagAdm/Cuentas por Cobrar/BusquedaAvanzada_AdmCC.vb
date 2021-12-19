Imports System.Data.SqlClient
Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema

Public Class BusquedaAvanzada_AdmCC
    Dim _Plantilla As IBusquedaAvanzada_AdmCC
    Dim xsalida As Boolean

    Sub New(ByVal xplantilla As IBusquedaAvanzada_AdmCC)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
        _Salida = False
    End Sub

    Sub Inicializar()
        _Plantilla.Inicializar(Me)
    End Sub

    Property _Salida() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Private Sub BusquedaAvanzada_AdmCC_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _Salida = False Then
            Dim xresultado As DialogResult = MessageBox.Show("Estas Deacuerdo En Salir Sin Procesar La Consulta ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
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

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        _salida = _Plantilla.F_Procesar()
        If _salida = True Then
            Me.Close()
        End If
    End Sub

    Private Sub BusquedaAvanzada_AdmCC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IBusquedaAvanzada_AdmCC
    Function F_Procesar() As Boolean
    Sub Inicializar(ByVal xformulario As Object)
End Interface

Class c_BusquedaAvanzada_AdmCxC
    Implements IBusquedaAvanzada_AdmCC

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

    'EVENTOS
    Event RetornarCondicionBusqueda(ByVal xcondicion As String)

    'FORMULARIOS
    Dim _MiFormulario As System.Windows.Forms.Form = Nothing

    'CHECKBOX
    Dim MC_GRUPOS As MisCheckBox
    Dim MC_ESTADOS As MisCheckBox
    Dim MC_ZONAS As MisCheckBox
    Dim MC_VENDEDORES As MisCheckBox
    Dim MC_COBRADORES As MisCheckBox
    Dim MC_TIPODOCUMENTOS As MisCheckBox
    Dim MC_NRODOCUMENTO As MisCheckBox

    'COMBOBOX
    Dim MCB_GRUPOS As MisComboBox
    Dim MCB_ESTADOS As MisComboBox
    Dim MCB_ZONAS As MisComboBox
    Dim MCB_VENDEDORES As MisComboBox
    Dim MCB_COBRADORES As MisComboBox
    Dim MCB_TIPODOCUMENTOS As MisComboBox

    'TEXTBOX
    Dim MT_NRODOCUMENTO As MisTextos

    'DATASET
    Dim DTS_ESTADOS As DataSet

    'DATATABLE
    Dim DTB_GRUPOS As DataTable
    Dim DTB_ESTADOS As DataTable
    Dim DTB_ZONAS As DataTable
    Dim DTB_VENDEDORES As DataTable
    Dim DTB_COBRADORES As DataTable

    'BINDINGSOURCES
    Dim BS_ESTADOS As BindingSource
    Dim BS_ZONAS As BindingSource

    Dim V_TIPODOCUMENTO As String() = {"PENDIENTES", "PENDIENTES VENCIDOS", "SOLVENTES", "ANULADOS"}

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
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IBusquedaAvanzada_AdmCC.Inicializar
        _MiFormulario = xformulario

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

        _MiFormulario.Text = "Busqueda Avanzada De Documentos De Cuentas Por Cobrar"

        MT_NRODOCUMENTO.p_IniciarComo = False

        InicializarCheckBox()
        CargarCombos()
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
        MCB_GRUPOS.Enabled = Me.MC_GRUPOS.Checked
    End Sub

    Sub EstatusZonas()
        If MC_ZONAS.Checked Then
            If MC_ESTADOS.Checked Then
                MCB_ZONAS.Enabled = True
            Else
                MC_ZONAS.Checked = False
            End If
        Else
            MCB_ZONAS.Enabled = False
        End If
    End Sub

    Sub EstatusEstados()
        MCB_ESTADOS.Enabled = MC_ESTADOS.Checked
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
        MT_NRODOCUMENTO.Enabled = MC_NRODOCUMENTO.Checked
    End Sub

    Sub CargarCombos()
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
    End Sub

    Public Function F_Procesar() As Boolean Implements IBusquedaAvanzada_AdmCC.F_Procesar
        Try
            Dim xcondicion As String = "WHERE cxc.auto<>'' "

            If MC_GRUPOS.Checked And MCB_GRUPOS.SelectedIndex > 0 Then
                xcondicion += "and clientes.auto_grupo='" + MCB_GRUPOS.SelectedValue + "' "
            End If

            If MC_ESTADOS.Checked And MCB_ESTADOS.SelectedIndex > 0 Then
                xcondicion += "and clientes.auto_estado='" + MCB_ESTADOS.SelectedValue + "' "
            End If

            If MC_ZONAS.Checked And MCB_ZONAS.SelectedIndex > 0 Then
                xcondicion += "and clientes.auto_zona='" + MCB_ZONAS.SelectedValue + "' "
            End If

            If MC_VENDEDORES.Checked And MCB_VENDEDORES.SelectedIndex > 0 Then
                xcondicion += "and clientes.auto_vendedor='" + MCB_VENDEDORES.SelectedValue + "' "
            End If

            If MC_COBRADORES.Checked And MCB_COBRADORES.SelectedIndex > 0 Then
                xcondicion += "and clientes.auto_cobrador='" + MCB_COBRADORES.SelectedValue + "' "
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

            RaiseEvent RetornarCondicionBusqueda(xcondicion)
            Return True
        Catch ex As Exception
            MessageBox.Show("ERROR AL PROCESAR BUSQUEDA:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class