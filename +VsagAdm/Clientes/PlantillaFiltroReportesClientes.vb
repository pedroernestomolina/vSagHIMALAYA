Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports System.Data.SqlClient

Public Class PlantillaFiltroReportesClientes
    Dim xplantilla As IPlantillaFiltroReportesClientes

    Dim estatus As String() = {"Activo / Habilitado", "Inactivo / Desactivado"}
    Dim estatus2 As String() = {"Activo / Habilitado", "Inactivo / Desactivado"}

    Dim xtb_grupo As DataTable
    Dim xtb_estado As DataTable
    Dim xtb_zona As DataTable
    Dim xtb_vendedor As DataTable
    Dim xtb_cobrador As DataTable

    Dim xbs_estado As BindingSource
    Dim xbs_zona As BindingSource
    Dim xrel_estado_zona As DataRelation
    Dim xds As DataSet

    Dim campo_p As DataColumn
    Dim campo_h As DataColumn

    Dim xest_salida As Boolean

    Property EstatusSalida() As Boolean
        Get
            Return xest_salida
        End Get
        Set(ByVal value As Boolean)
            xest_salida = value
        End Set
    End Property

    Private Sub PlantillaFiltroReportesCxC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub PlantillaFiltroReportesCxC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PlantillaFiltroReportesCxC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub CargarData()

        xtb_grupo = New DataTable
        g_MiData.F_GetData("select nombre,auto from grupo_cliente order by nombre", xtb_grupo)
        With Me.MCB_GRUPO
            .DataSource = xtb_grupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xds = New DataSet
        xtb_estado = New DataTable("estado")
        g_MiData.F_GetData("select nombre,auto from estados order by nombre", xtb_estado)
        xds.Tables.Add(xtb_estado)

        xtb_zona = New DataTable("zona")
        g_MiData.F_GetData("select nombre,auto,auto_estado from zona_cliente order by nombre", xtb_zona)
        xds.Tables.Add(xtb_zona)

        campo_p = xds.Tables("estado").Columns("auto")
        campo_h = xds.Tables("zona").Columns("auto_estado")

        xrel_estado_zona = New DataRelation("Estado_Zona", campo_p, campo_h)
        xds.Relations.Add(xrel_estado_zona)

        xbs_estado = New BindingSource(xds, xtb_estado.TableName)
        xbs_zona = New BindingSource(xbs_estado, "Estado_Zona")

        With Me.MCB_ESTADO
            .DataSource = xbs_estado
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_ZONA
            .DataSource = xbs_zona
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xtb_vendedor = New DataTable
        g_MiData.F_GetData("select nombre,auto from vendedores order by nombre", xtb_vendedor)
        With Me.MCB_VENDEDOR
            .DataSource = xtb_vendedor
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xtb_cobrador = New DataTable
        g_MiData.F_GetData("select nombre,auto from cobradores order by nombre", xtb_cobrador)
        With Me.MCB_COBRADOR
            .DataSource = xtb_cobrador
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_CREDITO
            .DataSource = estatus
            .SelectedIndex = 0
        End With

        With Me.MCB_ESTATUS
            .DataSource = estatus2
            .SelectedIndex = 0
        End With
    End Sub

    Sub Inicializa()
        Try
            ApagarControles()
            CargarData()
            _MiPLantilla.Inicializa(Me)

            Me.MCHB_GRUPO.Focus()
            Me.MCHB_GRUPO.Select()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ApagarControles()
        Me.MCB_CREDITO.Enabled = False
        Me.MCB_COBRADOR.Enabled = False
        Me.MCB_ESTADO.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MCB_VENDEDOR.Enabled = False
        Me.MCB_ZONA.Enabled = False
        Me.MCB_ESTATUS.Enabled = False
        Me.MCHB_FECHA.Checked = True
        Me.MF_DESDE.Checked = True
        Me.MF_HASTA.Checked = True
    End Sub

    Private Sub MCHB_GRUPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_GRUPO.CheckedChanged
        Me.MCB_GRUPO.Enabled = MCHB_GRUPO.Checked
    End Sub

    Private Sub MCHB_ESTADO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ESTADO.CheckedChanged
        Me.MCB_ESTADO.Enabled = MCHB_ESTADO.Checked
        If MCHB_ESTADO.Checked = False Then
            Me.MCHB_ZONA.Checked = False
            Me.MCB_ZONA.Enabled = False
        End If
    End Sub

    Private Sub MCHB_ZONA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ZONA.CheckedChanged
        If MCHB_ESTADO.Checked Then
            Me.MCB_ZONA.Enabled = MCHB_ZONA.Checked
        Else
            Me.MCHB_ZONA.Checked = False
        End If
    End Sub

    Private Sub MCHB_VENDEDOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_VENDEDOR.CheckedChanged
        Me.MCB_VENDEDOR.Enabled = MCHB_VENDEDOR.Checked
    End Sub

    Private Sub MCHB_COBRADOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_COBRADOR.CheckedChanged
        Me.MCB_COBRADOR.Enabled = MCHB_COBRADOR.Checked
    End Sub

    Private Sub MCHB_CREDITO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCHB_CREDITO.CheckedChanged
        Me.MCB_CREDITO.Enabled = MCHB_CREDITO.Checked
    End Sub

    Private Sub MCHB_ESTATUS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ESTATUS.CheckedChanged
        Me.MCB_ESTATUS.Enabled = MCHB_ESTATUS.Checked
    End Sub

    Private Sub MCHB_FECHA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_FECHA.CheckedChanged
        Me.MF_DESDE.Enabled = MCHB_FECHA.Checked
        Me.MF_HASTA.Enabled = MCHB_FECHA.Checked
    End Sub

    Private Sub MF_DESDE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_DESDE.ValueChanged
        If MF_HASTA.Checked Then
            If MF_DESDE.r_Valor <= MF_HASTA.r_Valor Then
            Else
                MF_HASTA.Value = MF_DESDE.Value
            End If
        End If
    End Sub

    Private Sub MF_HASTA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_HASTA.ValueChanged
        If MF_DESDE.Checked Then
            If MF_HASTA.r_Valor >= MF_DESDE.r_Valor Then
            Else
                Me.MF_DESDE.Value = Me.MF_HASTA.Value
            End If
        End If
    End Sub

    Property _MiPLantilla() As IPlantillaFiltroReportesClientes
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantillaFiltroReportesClientes)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaFiltroReportesClientes)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiPLantilla = xplantilla
    End Sub
End Class

Public Interface IPlantillaFiltroReportesClientes
    Sub Inicializa(ByVal xform As Object)
End Interface


Public Class ReporteClientes_DatosContacto
    Implements IPlantillaFiltroReportesClientes

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents CHK_4 As MisCheckBox
    WithEvents CHK_5 As MisCheckBox
    WithEvents CHK_6 As MisCheckBox
    WithEvents CHK_7 As MisCheckBox
    WithEvents CHK_8 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox

    WithEvents MF_1 As MisFechas
    WithEvents MF_2 As MisFechas

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesClientes.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_CREDITO", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_CREDITO", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Maestro De Clientes/Datos De Contacto"
        MF_1.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select c.*, '' telefono, gc.nombre as nombre_grupo, e.nombre as nombre_estado " & _
                                 "from clientes c join grupo_cliente gc on c.auto_grupo=gc.auto join estados e on c.auto_estado=e.auto " & _
                                 "where 1=1 "

            If Me.CHK_1.Checked Then
                xfil += " and auto_grupo='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and auto_estado='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and auto_zona='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and auto_vendedor='" + Me.CB_4.SelectedValue + "'"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and auto_cobrador='" + Me.CB_5.SelectedValue + "'"
            End If

            If Me.CHK_6.Checked Then
                xfil += " and credito='" + Me.CB_6.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_7.Checked And MF_1.Checked Then
                xfil += " and fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_7.Checked And MF_2.Checked Then
                xfil += " and fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked Then
                If CB_7.SelectedIndex = 0 Then
                    xfil += " and ESTATUS ='Activo'"
                Else
                    xfil += " and ESTATUS ='Inactivo'"
                End If
            End If

            xsql += xfil + " order by nombre"

            VisualizarReportesClientesDatosContacto(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesClientesDatosContacto(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("ficha")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                Dim xtel As String = ""
                If xrow("telefono_1").ToString.Trim <> "" Then
                    xtel = xrow("telefono_1")
                End If

                If xrow("telefono_2").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("telefono_2")
                    Else
                        xtel = xrow("telefono_2")
                    End If
                End If

                If xrow("telefono_3").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("telefono_3")
                    Else
                        xtel = xrow("telefono_3")
                    End If
                End If

                If xrow("telefono_4").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("telefono_4")
                    Else
                        xtel = xrow("telefono_4")
                    End If
                End If

                If xrow("celular_1").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("celular_1")
                    Else
                        xtel = xrow("celular_1")
                    End If
                End If

                If xrow("celular_2").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("celular_2")
                    Else
                        xtel = xrow("celular_2")
                    End If
                End If
                xrow("telefono") = xtel
            Next
            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "CLIENTE_DATOS_CONTACTO.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteClientes_DatosComerciales
    Implements IPlantillaFiltroReportesClientes

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents CHK_4 As MisCheckBox
    WithEvents CHK_5 As MisCheckBox
    WithEvents CHK_6 As MisCheckBox
    WithEvents CHK_7 As MisCheckBox
    WithEvents CHK_8 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox

    WithEvents MF_1 As MisFechas
    WithEvents MF_2 As MisFechas

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesClientes.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_CREDITO", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_CREDITO", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)
        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        LB_1.Text = "Maestro De Clientes/Datos Comerciales"
        MF_1.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""

            Dim xsql As String = "select c.*, 0 AS doc_pendientes, gc.nombre as nombre_grupo, e.nombre as nombre_estado " & _
                                 "from clientes c join grupo_cliente gc on c.auto_grupo=gc.auto join estados e on c.auto_estado=e.auto " & _
                                 "where 1=1 "
            If Me.CHK_1.Checked Then
                xfil += " and auto_grupo='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and auto_estado='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and auto_zona='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and auto_vendedor='" + Me.CB_4.SelectedValue + "'"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and auto_cobrador='" + Me.CB_5.SelectedValue + "'"
            End If

            If Me.CHK_6.Checked Then
                xfil += " and credito='" + Me.CB_6.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_7.Checked And MF_1.Checked Then
                xfil += " and fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_7.Checked And MF_2.Checked Then
                xfil += " and fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked Then
                If CB_7.SelectedIndex = 0 Then
                    xfil += " and ESTATUS ='Activo'"
                Else
                    xfil += " and ESTATUS ='Inactivo'"
                End If
            End If

            xsql += xfil + " order by nombre"

            VisualizarReportesClientesDatosComerciales(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesClientesDatosComerciales(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("ficha")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)
            For Each xrow In dtb_ficha.Rows
                Dim xdoc As Integer = 0
                Dim xsql_2 As String = "select count(*) from cxc where estatus='0' " _
                  + "and auto_cliente= @auto_cliente and cancelado='0' and tipo_documento not in('PAG','NCF')"
                Dim xp1 As New SqlParameter("@auto_cliente", xrow("auto"))
                xdoc = F_GetInteger(xsql_2, xp1)
                xrow("doc_pendientes") = xdoc
            Next

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "CLIENTE_DATOS_COMERCIALES.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteClientes_EstadoCuenta
    Implements IPlantillaFiltroReportesClientes

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents CHK_4 As MisCheckBox
    WithEvents CHK_5 As MisCheckBox
    WithEvents CHK_6 As MisCheckBox
    WithEvents CHK_7 As MisCheckBox
    WithEvents CHK_8 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox

    WithEvents MF_1 As MisFechas
    WithEvents MF_2 As MisFechas

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesClientes.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_CREDITO", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_CREDITO", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)
        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        LB_1.Text = "Estado De Cuenta De Clientes"
        MF_1.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select auto " & _
                                 "from clientes " & _
                                 "where auto<>'' "

            If Me.CHK_1.Checked Then
                xfil += " and auto_grupo='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and auto_estado='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and auto_zona='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and auto_vendedor='" + Me.CB_4.SelectedValue + "'"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and auto_cobrador='" + Me.CB_5.SelectedValue + "'"
            End If

            If Me.CHK_6.Checked Then
                xfil += " and credito='" + Me.CB_6.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_7.Checked And MF_1.Checked Then
                xfil += " and fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_7.Checked And MF_2.Checked Then
                xfil += " and fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked Then
                If CB_7.SelectedIndex = 0 Then
                    xfil += " and ESTATUS ='Activo'"
                Else
                    xfil += " and ESTATUS ='Inactivo'"
                End If
            End If

            xsql += xfil

            VisualizarReportesClientesEstadoCuenta(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesClientesEstadoCuenta(ByVal xsql As String) As Boolean
        Try
            Dim xds As New DataSet
            Dim xfecha As Date = DateAdd(DateInterval.Month, -3, g_MiData.p_FechaDelMotorBD)

            Dim xpar1 As New SqlParameter("@fecha", _FechaComienzoDelMes(xfecha))

            Dim xsql1 As String = "select cxc.fecha,cxc.tipo_documento,cxc.documento,cxc.detalle,cxc.importe,cxc.acumulado,cxc.resta,cxc.signo, " & _
               "c.nombre,c.codigo,c.ci_rif,c.dir_fiscal,c.telefono,c.credito_disponible,c.total_anticipos,c.dias_credito,c.limite_credito, 0 saldo_anterior, c.auto " & _
               "from clientes c inner join cxc on c.auto=cxc.auto_cliente where c.auto in (" + xsql + ") and c.total_saldo>0 and cxc.estatus<>'1' and cxc.fecha > @fecha order by nombre; " & _
               "select nombre,rif,direccion from empresa;"
            g_MiData.F_GetData(xsql1, xds, xpar1)

            For Each xrow In xds.Tables(0).Rows
                xpar1 = New SqlParameter("@fecha", _FechaComienzoDelMes(xfecha))
                Dim xpar2 As New SqlParameter("@auto_cliente", xrow("auto"))
                Dim xsql2 As String = "select sum(ABS(importe)*signo) as saldo from cxc where auto_cliente=@auto_cliente and cxc.estatus<>'1' and cxc.fecha <= @fecha"
                Dim xsaldo As Decimal = F_GetDecimal(xsql2, xpar1, xpar2)
                xrow("saldo_anterior") = xsaldo
            Next

            xds.Tables(0).TableName = "Cxc_Cliente"
            xds.Tables(1).TableName = "Empresa"

            Dim xlista As New List(Of _Reportes.ParamtCrystal)
            Dim xpc1 As New _Reportes.ParamtCrystal("@fecha", _FechaComienzoDelMes(xfecha))
            xlista.Add(xpc1)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "CLIENTE_ESTADO_CUENTA_GRUPAL.RPT"
            Dim xficha As New _Reportes(xds, xrep, xlista)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Function _FechaComienzoDelMes(ByVal xfecha As Date) As Date
        Dim xsql As String = "select dateadd(month,datediff(month,'19000101',@fecha),'19000101')"
        Dim xpr1 As New SqlParameter("@fecha", xfecha)
        Return F_GetDate(xsql, xpr1)
    End Function
End Class

Public Class ReporteClientes_RetencionesIva
    Implements IPlantillaFiltroReportesClientes

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents CHK_4 As MisCheckBox
    WithEvents CHK_5 As MisCheckBox
    WithEvents CHK_6 As MisCheckBox
    WithEvents CHK_7 As MisCheckBox
    WithEvents CHK_8 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox

    WithEvents MF_1 As MisFechas
    WithEvents MF_2 As MisFechas

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesClientes.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_CREDITO", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_CREDITO", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)
        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        LB_1.Text = "Retenciones Iva De Clientes"
        MF_1.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""

            If Me.CHK_1.Checked Then
                xfil += " and auto_grupo='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and auto_estado='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and auto_zona='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and auto_vendedor='" + Me.CB_4.SelectedValue + "'"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and auto_cobrador='" + Me.CB_5.SelectedValue + "'"
            End If

            If Me.CHK_6.Checked Then
                xfil += " and credito='" + Me.CB_6.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_7.Checked And MF_1.Checked Then
                xfil += " and fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_7.Checked And MF_2.Checked Then
                xfil += " and fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked Then
                If CB_7.SelectedIndex = 0 Then
                    xfil += " and ESTATUS ='Activo'"
                Else
                    xfil += " and ESTATUS ='Inactivo'"
                End If
            End If

            VisualizarReportesClientesRetencionesIva(xfil)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesClientesRetencionesIva(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_retenciones As New DataTable("retenciones_ventas")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            Dim xsql_2 As String = "select r.documento" & _
                ", r.nombre" & _
                ", r.ci_rif" & _
                ", r.fecha" & _
                ", r.ano_relacion" & _
                ", r.mes_relacion" & _
                ", r.base" & _
                ", r.impuesto" & _
                ", r.retencion" & _
                ", r.tasa_retencion" & _
                ", r.total" & _
                ", r.exento " & _
            "from clientes c join retenciones_ventas r on c.auto=r.auto_entidad join retenciones_ventas_detalle rd on r.auto=rd.auto " & _
            "where c.AUTO<>'' " + xsql + " group by r.fecha" & _
                ", r.documento" & _
                ", r.nombre" & _
                ", r.ci_rif" & _
                ", r.tasa_retencion" & _
                ", r.retencion" & _
                ", r.ano_relacion" & _
                ", r.mes_relacion" & _
                ", r.base" & _
                ", r.impuesto" & _
                ", r.total" & _
                ", r.exento" & _
                "  order by r.nombre desc"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql_2, dtb_retenciones)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_retenciones)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "CLIENTES_RETENCIONES.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class AnticiposNCPendientes
    Implements IPlantillaFiltroReportesClientes

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents CHK_4 As MisCheckBox
    WithEvents CHK_5 As MisCheckBox
    WithEvents CHK_6 As MisCheckBox
    WithEvents CHK_7 As MisCheckBox
    WithEvents CHK_8 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox

    WithEvents MF_1 As MisFechas
    WithEvents MF_2 As MisFechas

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesClientes.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_CREDITO", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_CREDITO", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Anticipos / Notas Creditos Pendientes"
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False
        Me.CHK_8.Enabled = False
        Me.MF_1.Enabled = False
        Me.MF_2.Enabled = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""

            If Me.CHK_1.Checked Then
                xfil += " and auto_grupo='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and auto_estado='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and auto_zona='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and auto_vendedor='" + Me.CB_4.SelectedValue + "'"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and auto_cobrador='" + Me.CB_5.SelectedValue + "'"
            End If

            VisualizarReportesAnticiposPend(xfil)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesAnticiposPend(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("ficha")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"
            Dim xsql_2 As String = "select c.*, gc.nombre as nombre_grupo, e.nombre as nombre_estado from clientes c join grupo_cliente gc " & _
                " on c.auto_grupo=gc.auto join estados e on c.auto_estado=e.auto " & _
                " where abs(total_anticipos)>0 or abs(total_creditos)>0 " & xsql & " order by nombre "

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql_2, dtb_ficha)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "CLIENTES_ANTICIPOS_NC_PENDIENTES.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class