Imports MisControles.Controles
Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema


Public Class PlantillaFiltroReportesInventario
    Dim xplantilla As IPlantillaFiltroReportesInventario

    Dim precios As String() = {"Precio 1", "Precio 2", "Precio 3", "Precio 4"}
    Dim plu As String() = {"Todos", "Pesados", "Unidad"}
    Dim estatus As String() = {"Activos/Habilitados", "Inactivos/Deshabilitados"}
    Dim Orden As String() = {"Por Nombre/Descripcion", "Por Codigo", "Por Plu"}
    Dim NivelStock As String() = {"Por Debajo Nivel Minimo", "Por Encima o Igual Al Nivel Optimo"}

    Dim xtb_grupo As DataTable
    Dim xtb_subgrupo As DataTable
    Dim xtb_departamento As DataTable
    Dim xtb_proveedor As DataTable
    Dim xtb_marca As DataTable
    Dim xtb_deposito As DataTable
    Dim xtb_conceptos As DataTable

    Dim xbs_grupo As BindingSource
    Dim xbs_subgrupo As BindingSource
    Dim xrel_grupo_subgrupo As DataRelation
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

    Private Sub PlantillaFiltroReportesCxC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub CargarData()
        xtb_deposito = New DataTable
        g_MiData.F_GetData("select nombre,auto from depositos order by nombre", xtb_deposito)
        With Me.MCB_DEPOSITO
            .DataSource = xtb_deposito
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xtb_departamento = New DataTable
        g_MiData.F_GetData("select nombre,auto from productos_departamento order by nombre", xtb_departamento)
        With Me.MCB_DEPARTAMENTO
            .DataSource = xtb_departamento
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xds = New DataSet
        xtb_grupo = New DataTable("grupo")
        g_MiData.F_GetData("select nombre,auto from productos_grupo order by nombre", xtb_grupo)
        xds.Tables.Add(xtb_grupo)

        xtb_subgrupo = New DataTable("subgrupo")
        g_MiData.F_GetData("select nombre,auto,auto_grupo from productos_subgrupo order by nombre", xtb_subgrupo)
        xds.Tables.Add(xtb_subgrupo)

        campo_p = xds.Tables("grupo").Columns("auto")
        campo_h = xds.Tables("subgrupo").Columns("auto_grupo")

        xrel_grupo_subgrupo = New DataRelation("Grupo_Subgrupo", campo_p, campo_h)
        xds.Relations.Add(xrel_grupo_subgrupo)

        xbs_grupo = New BindingSource(xds, xtb_grupo.TableName)
        xbs_subgrupo = New BindingSource(xbs_grupo, "Grupo_Subgrupo")

        With Me.MCB_GRUPO
            .DataSource = xbs_grupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_SUBGRUPO
            .DataSource = xbs_subgrupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xtb_proveedor = New DataTable
        g_MiData.F_GetData("select nombre,auto from proveedores order by nombre", xtb_proveedor)
        With Me.MCB_PROVEEDOR
            .DataSource = xtb_proveedor
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xtb_marca = New DataTable
        g_MiData.F_GetData("select nombre,auto from productos_marca order by nombre", xtb_marca)
        With Me.MCB_MARCA
            .DataSource = xtb_marca
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xtb_conceptos = New DataTable
        g_MiData.F_GetData("select nombre,auto from productos_conceptos order by nombre", xtb_conceptos)
        With Me.MCB_CONCEPTO
            .DataSource = xtb_conceptos
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With MCB_PRECIO
            .DataSource = precios
            .SelectedIndex = 0
        End With

        With MCB_PLU
            .DataSource = plu
            .SelectedIndex = 0
        End With

        With MCB_ESTATUS
            .DataSource = estatus
            .SelectedIndex = 0
        End With

        With Me.MCB_ORDEN
            .DataSource = Orden
            .SelectedIndex = 0
        End With

        With Me.MCB_NIVEL_STOCK
            .DataSource = NivelStock
            .SelectedIndex = 0
        End With

    End Sub

    Sub Inicializa()
        Try
            ApagarControles()
            CargarData()
            _MiPLantilla.Inicializa(Me)

            Me.MCHB_DEPARTAMENTO.Focus()
            Me.MCHB_DEPARTAMENTO.Select()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ApagarControles()
        Me.MCB_DEPOSITO.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MCB_DEPARTAMENTO.Enabled = False
        Me.MCB_PROVEEDOR.Enabled = False
        Me.MCB_SUBGRUPO.Enabled = False
        Me.MF_DESDE.Enabled = False
        Me.MF_HASTA.Enabled = False
        Me.MCB_PLU.Enabled = False
        Me.MCB_PRECIO.Enabled = False
        Me.MCHB_FECHA.Checked = True
        Me.MF_DESDE.Checked = True
        Me.MF_HASTA.Checked = True
        Me.MCB_ESTATUS.Enabled = False
        Me.MCB_MARCA.Enabled = False
        Me.MCB_NIVEL_STOCK.Enabled = False
        Me.MCB_CONCEPTO.Enabled = False
        Me.MCHB_SIN_MOVIMIENTO.Enabled = False
    End Sub

    Private Sub MCHB_GRUPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_GRUPO.CheckedChanged
        Me.MCB_GRUPO.Enabled = MCHB_GRUPO.Checked
        If MCHB_GRUPO.Checked = False Then
            Me.MCHB_SUBGRUPO.Checked = False
            Me.MCB_SUBGRUPO.Enabled = False
        End If
    End Sub

    Private Sub MCHB_SUBGRUPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_SUBGRUPO.CheckedChanged
        If MCHB_GRUPO.Checked Then
            Me.MCB_SUBGRUPO.Enabled = MCHB_SUBGRUPO.Checked
        Else
            Me.MCHB_SUBGRUPO.Checked = False
        End If
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

    Private Sub MCHB_DEPARTAMENTO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_DEPARTAMENTO.CheckedChanged
        Me.MCB_DEPARTAMENTO.Enabled = Me.MCHB_DEPARTAMENTO.Checked
    End Sub

    Private Sub MCHB_PROVEEDOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_PROVEEDOR.CheckedChanged
        Me.MCB_PROVEEDOR.Enabled = Me.MCHB_PROVEEDOR.Checked
    End Sub

    Private Sub MCHB_DEPOSITO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_DEPOSITO.CheckedChanged
        Me.MCB_DEPOSITO.Enabled = MCHB_DEPOSITO.Checked
    End Sub

    Private Sub MCHB_PLU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_PLU.CheckedChanged
        Me.MCB_PLU.Enabled = MCHB_PLU.Checked
    End Sub

    Property _MiPLantilla() As IPlantillaFiltroReportesInventario
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantillaFiltroReportesInventario)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaFiltroReportesInventario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiPLantilla = xplantilla
    End Sub

    Private Sub MCHB_ESTATUS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ESTATUS.CheckedChanged
        Me.MCB_ESTATUS.Enabled = MCHB_ESTATUS.Checked
    End Sub

    Private Sub MCHB_MARCA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_MARCA.CheckedChanged
        Me.MCB_MARCA.Enabled = MCHB_MARCA.Checked
    End Sub

    Private Sub MCHB_NIVEL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_NIVEL.CheckedChanged
        Me.MCB_NIVEL_STOCK.Enabled = MCHB_NIVEL.Checked
    End Sub

    Private Sub MCHB_CONCEPTO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_CONCEPTO.CheckedChanged
        Me.MCB_CONCEPTO.Enabled = MCHB_CONCEPTO.Checked
    End Sub

    Private Sub PlantillaFiltroReportesInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub MCHB_PRECIO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_PRECIO.CheckedChanged
        Me.MCB_PRECIO.Enabled = MCHB_PRECIO.Checked
    End Sub

End Class

Public Interface IPlantillaFiltroReportesInventario
    Sub Inicializa(ByVal xform As Object)
End Interface


Public Class ReporteInventario_DatosArticulo
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_8 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_8 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Maestro De Inventario/Datos Del Articulo"

        Me.CHK_7.Enabled = False
        Me.CHK_8.Checked = False
        Me.CHK_11.Enabled = False
        Me.CHK_12.Enabled = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select p.codigo, p.nombre, p.tasa, p.categoria, p.origen, pdep.nombre departamento, " & _
                                 "pgru.nombre grupo, psgr.nombre subgrupo, pmar.nombre marca, p.plu " & _
                                 "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " & _
                                 "join productos_grupo pgru on p.auto_grupo=pgru.auto " & _
                                 "join productos_subgrupo psgr on p.auto_subgrupo=psgr.auto " & _
                                 "join productos_marca pmar on p.auto_marca=pmar.auto " & _
                                 "where p.auto<>'' "

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.CB_4.SelectedValue + "')"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.CB_5.SelectedValue + "')"
            End If

            If Me.CHK_9.Checked Then
                xfil += IIf(Me.CB_8.SelectedIndex = 0, " and p.estatus='Activo'", " and p.estatus='Inactivo'")
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            If Me.CHK_8.Checked And MF_1.Checked Then
                xfil += " and p.fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked And MF_2.Checked Then
                xfil += " and p.fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            Select Case Me.CB_9.SelectedIndex
                Case 0 : xsql += xfil + " order by p.nombre"
                Case 1 : xsql += xfil + " order by p.codigo"
                Case 2 : xsql += xfil + " order by p.plu"
            End Select

            VisualizarReportesInventarioDatosArticulo(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioDatosArticulo(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("inventario")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_DATOS_ARTICULO.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteInventario_PreciosArticulo
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        Me.CHK_7.Enabled = False
        Me.CHK_8.Checked = False
        Me.CHK_8.Enabled = False
        Me.CHK_9.Enabled = False
        Me.CHK_11.Enabled = False
        Me.CHK_12.Enabled = False

        Me.MF_1.Enabled = False
        Me.MF_2.Enabled = False
        LB_1.Text = "Maestro De Inventario/Precio Del Articulo"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select p.codigo, p.nombre, p.tasa, p.categoria, p.origen, p.psv, p.precio_pto_venta, " & _
                                 "pmed.nombre medida_venta, 0.00 utilidad_pto_venta, p.auto, p.costo_inventario, " & _
                                 "pg.nombre grupo, psg.nombre subgrupo, p.plu , pdpto.nombre as departamento , pmarca.nombre as marca " & _
                                 "from productos p join productos_medida pmed on p.auto_medida_venta=pmed.auto " & _
                                 "join productos_departamento pdpto on p.auto_departamento=pdpto.auto " & _
                                 "join productos_marca pmarca on p.auto_marca=pmarca.auto " & _
                                 "join productos_grupo pg on p.auto_grupo=pg.auto " & _
                                 "join productos_subgrupo psg on p.auto_subgrupo=psg.auto " & _
                                 "where estatus='Activo' "

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.CB_4.SelectedValue + "')"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.CB_5.SelectedValue + "')"
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            If Me.CHK_8.Checked And MF_1.Checked Then
                xfil += " and p.fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked And MF_2.Checked Then
                xfil += " and p.fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            Select Case Me.CB_9.SelectedIndex
                Case 0 : xsql += xfil + " order by p.nombre"
                Case 1 : xsql += xfil + " order by p.codigo"
                Case 2 : xsql += xfil + " order by p.plu"
            End Select

            VisualizarReportesInventarioPrecioArticulo(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioPrecioArticulo(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("inventario")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                Dim xmargen As Decimal = Decimal.Round(xrow("precio_pto_venta") - xrow("costo_inventario"), 2, MidpointRounding.AwayFromZero)
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                    xrow("utilidad_pto_venta") = Decimal.Round(UtilidadBaseCosto(xrow("costo_inventario"), xmargen), 2, MidpointRounding.AwayFromZero)
                Else
                    xrow("utilidad_pto_venta") = Decimal.Round(UtilidadBasePrecioVenta(xrow("precio_pto_venta"), xmargen), 2, MidpointRounding.AwayFromZero)
                End If
            Next
            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_PRECIOS_ARTICULO.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteInventario_ListaPrecios
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Maestro De Inventario/Lista De Precios"

        Me.CHK_7.Enabled = False
        Me.CHK_7.Checked = True
        Me.CB_7.Enabled = True
        Me.CHK_9.Enabled = False
        Me.CHK_11.Enabled = False
        Me.CHK_12.Enabled = False

        Me.CHK_8.Checked = False
        Me.CHK_8.Enabled = False
        Me.MF_1.Enabled = False
        Me.MF_2.Enabled = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xprecio As String = ""

            Select Case Me.CB_7.SelectedIndex
                Case 0
                    xprecio = "pe.precio_1"
                Case 1
                    xprecio = "pe.precio_2"
            End Select
            Dim xfil As String = ""

            Dim xsql As String = "select " + xprecio + " precio, pm.nombre as medida, pe.auto_producto, pe.contenido " & _
                                 "from productos_empaque pe join productos_medida pm on pm.auto=pe.auto_medida "

            Dim xsql_1 As String = "select p.auto, p.nombre, p.codigo, '' medida_precio_1, '' medida_precio_2, " & _
                                 "'' medida_precio_3, '' medida_precio_4, 0.00 precio_1, 0.00 precio_2, 0.00 precio_3, 0.00 precio_4, " & _
                                 "pg.nombre grupo, psg.nombre subgrupo, p.plu, pdpto.nombre as departamento , pmarca.nombre as marca, p.tasa, " & _
                                 "0.00 as precio_1_full, 0.00 as precio_2_full, 0.00 as precio_3_full, 0.00 as precio_4_full  " & _
                                 "from productos p " & _
                                 "join productos_departamento pdpto on p.auto_departamento=pdpto.auto " & _
                                 "join productos_marca pmarca on p.auto_marca=pmarca.auto " & _
                                 "inner join productos_grupo pg on p.auto_grupo=pg.auto inner join productos_subgrupo psg on p.auto_subgrupo=psg.auto " & _
                                 "where estatus='Activo' and p.auto in (select auto_producto from productos_empaque group by auto_producto) "

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.CB_4.SelectedValue + "')"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.CB_5.SelectedValue + "')"
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            If Me.CHK_8.Checked And MF_1.Checked Then
                xfil += " and p.fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked And MF_2.Checked Then
                xfil += " and p.fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            Select Case Me.CB_9.SelectedIndex
                Case 0 : xsql_1 += xfil + " order by p.nombre"
                Case 1 : xsql_1 += xfil + " order by p.codigo"
                Case 2 : xsql_1 += xfil + " order by p.plu"
            End Select

            VisualizarReportesInventarioListaPrecios(xsql, xsql_1)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioListaPrecios(ByVal xsql As String, ByVal xsql_1 As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_precios As New DataTable("productos_empaque")
        Dim dtb_ficha As New DataTable("inventario")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_2 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_2, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_precios)
            g_MiData.F_GetData(xsql_1, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                Dim xrow_1 As DataRow() = dtb_precios.Select("auto_producto='" + xrow("auto") + "'")
                If xrow_1.Count = 4 Then
                    xrow("medida_precio_1") = xrow_1(0)("medida").ToString.Trim + " / " + xrow_1(0)("contenido").ToString.Trim
                    xrow("precio_1") = xrow_1(0)("precio")
                    xrow("medida_precio_2") = xrow_1(1)("medida").ToString.Trim + " / " + xrow_1(1)("contenido").ToString.Trim
                    xrow("precio_2") = xrow_1(1)("precio")
                    xrow("medida_precio_3") = xrow_1(2)("medida").ToString.Trim + " / " + xrow_1(2)("contenido").ToString.Trim
                    xrow("precio_3") = xrow_1(2)("precio")
                    xrow("medida_precio_4") = xrow_1(3)("medida").ToString.Trim + " / " + xrow_1(3)("contenido").ToString.Trim
                    xrow("precio_4") = xrow_1(3)("precio")

                    Dim t As Decimal = xrow_1(0)("precio") + (xrow_1(0)("precio") * xrow("tasa") / 100)
                    xrow("precio_1_full") = Math.Round(t, 2, MidpointRounding.AwayFromZero)

                    t = xrow_1(1)("precio") + (xrow_1(1)("precio") * xrow("tasa") / 100)
                    xrow("precio_2_full") = Math.Round(t, 2, MidpointRounding.AwayFromZero)

                    t = xrow_1(2)("precio") + (xrow_1(2)("precio") * xrow("tasa") / 100)
                    xrow("precio_3_full") = Math.Round(t, 2, MidpointRounding.AwayFromZero)

                    t = xrow_1(3)("precio") + (xrow_1(3)("precio") * xrow("tasa") / 100)
                    xrow("precio_4_full") = Math.Round(t, 2, MidpointRounding.AwayFromZero)
                End If
            Next

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_LISTA_PRECIOS.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteInventario_ExistenciasDeposito
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Maestro De Inventario/Existencias Por Deposito"

        Me.CHK_7.Enabled = False
        Me.CHK_8.Checked = False
        Me.CHK_8.Enabled = False
        Me.CHK_9.Enabled = False
        Me.CHK_12.Enabled = False

        Me.MF_1.Enabled = False
        Me.MF_2.Enabled = False
        Me.CB_9.Enabled = True
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""

            Dim xsql As String = "select p.codigo as codigo_producto, p.nombre as nombre_producto, p.plu, dep.codigo as codigo_deposito, " & _
                                 "dep.nombre as nombre_deposito, pd.disponible, pd.reservada, pd.real, pg.nombre as grupo, psg.nombre as subgrupo, " & _
                                 "pm.nombre as empaque, p.contenido_empaque, pmarca.nombre as marca, pdpto.nombre as departamento, " & _
                                 "pd.nivel_minimo as niv_min, pd.nivel_optimo as niv_opt " & _
                                 "from productos p inner join productos_deposito pd on p.auto=pd.auto_producto " & _
                                 "inner join depositos dep on pd.auto_deposito=dep.auto " & _
                                 "inner join productos_grupo pg on p.auto_grupo=pg.auto " & _
                                 "inner join productos_subgrupo psg on p.auto_subgrupo=psg.auto " & _
                                 "inner join productos_medida pm on p.auto_medida_compra=pm.auto " & _
                                 "inner join productos_marca pmarca on p.auto_marca=pmarca.auto " & _
                                 "inner join productos_departamento pdpto on p.auto_departamento=pdpto.auto " & _
                                 "where p.estatus='Activo' "

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_11.Checked Then
                If Me.CB_11.SelectedIndex = 0 Then
                    xfil += " and pd.real < pd.nivel_minimo"
                Else
                    xfil += " and pd.real >= pd.nivel_optimo"
                End If
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.CB_4.SelectedValue + "')"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.CB_5.SelectedValue + "')"
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            If Me.CHK_8.Checked And MF_1.Checked Then
                xfil += " and p.fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked And MF_2.Checked Then
                xfil += " and p.fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            Select Case CB_9.SelectedIndex
                Case 0 : xsql += xfil + " order by p.nombre"
                Case 1 : xsql += xfil + " order by p.codigo"
                Case 2 : xsql += xfil + " order by p.plu"
            End Select

            VisualizarReportesInventarioExistenciasDeposito(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioExistenciasDeposito(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("productos_deposito")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_EXISTENCIAS_DEPOSITOS.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteInventario_Kardex
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox
    WithEvents CHK_13 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox
    WithEvents CB_12 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)
        CHK_13 = _MiFormulario.Controls.Find("MCHB_SIN_MOVIMIENTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)
        CB_12 = _MiFormulario.Controls.Find("MCB_CONCEPTO", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Kardex Del Inventario"

        Me.CHK_7.Enabled = False
        Me.CHK_8.Enabled = False
        Me.CHK_9.Enabled = False
        Me.CHK_8.Checked = True
        Me.CHK_11.Enabled = False
        Me.CHK_13.Enabled = True

        Me.MF_1.Enabled = True
        Me.MF_2.Enabled = True
        Me.CB_9.Enabled = False
        Me.MF_1.ShowCheckBox = False
        Me.CHK_8.Text = "Por Fecha De Movimiento"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            If Me.CHK_13.Checked = False Then
                Dim xfil As String = ""

                Dim xsql As String = "SELECT (SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX " _
                          + "WHERE AUTO_PRODUCTO=pk.auto_producto AND estatus='0' AND fecha <'" + MF_1.r_Valor.ToShortDateString + "' " _
                          + "and auto_deposito=pk.auto_deposito) SALDO_ANTERIOR, " _
                          + "PK.FECHA, PK.DOCUMENTO, PK.ENTIDAD, " _
                          + "Pk.n_NombreMedidaEmpaque NOM_MEDIDA, Pk.n_ContenidoMedidaEmpaque CONTENIDO, PK.CANTIDAD_INVENTARIO CANTIDAD, pk.n_codigoconcepto COD_CONCEPTO, " _
                          + "pk.n_NombreConcepto NOM_CONCEPTO, PK.SIGNO,d.nombre NOM_DEPOSITO,d.codigo COD_DEPOSITO, " _
                          + "p.nombre NOM_PRODUCTO,p.codigo COD_PRODUCTO, PG.NOMBRE GRUPO, PSG.NOMBRE SUBGRUPO, " _
                          + "pmarca.nombre as marca, pdpto.nombre as departamento " _
                          + "FROM PRODUCTOS_KARDEX PK " _
                          + "JOIN DEPOSITOS D ON D.AUTO=PK.AUTO_DEPOSITO " _
                          + "JOIN PRODUCTOS P ON P.AUTO=PK.AUTO_PRODUCTO " _
                          + "JOIN PRODUCTOS_GRUPO PG ON PG.AUTO=P.AUTO_GRUPO " _
                          + "JOIN PRODUCTOS_SUBGRUPO PSG ON PSG.AUTO=P.AUTO_SUBGRUPO " _
                          + "join productos_marca pmarca on p.auto_marca=pmarca.auto " _
                          + "join productos_departamento pdpto on p.auto_departamento=pdpto.auto " _
                          + "WHERE PK.estatus='0' "

                If Me.CHK_12.Checked Then
                    xfil += " and pK.auto_CONCEPTO='" + Me.CB_12.SelectedValue + "'"
                End If

                If Me.CHK_10.Checked Then
                    xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
                End If

                If Me.CHK_1.Checked Then
                    xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
                End If

                If Me.CHK_2.Checked Then
                    xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
                End If

                If Me.CHK_3.Checked Then
                    xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue.ToString + "'"
                End If

                If Me.CHK_4.Checked Then
                    xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.CB_4.SelectedValue + "')"
                End If

                If Me.CHK_5.Checked Then
                    xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.CB_5.SelectedValue + "')"
                End If

                If Me.CHK_6.Checked Then
                    Select Case Me.CB_6.SelectedIndex
                        Case 0
                            xfil += " and p.estatus_balanza='1'"
                        Case 1
                            xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                        Case 2
                            xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                    End Select
                End If

                If Me.CHK_8.Checked And MF_1.Checked Then
                    xfil += " and pk.fecha>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
                End If

                If Me.CHK_8.Checked And MF_2.Checked Then
                    xfil += " and pk.fecha<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
                End If

                xsql += xfil + " ORDER BY pk.fecha,PK.DOCUMENTO"

                VisualizarReportesInventarioKardex(xsql, MF_1.r_Valor, MF_2.r_Valor)
            Else
                Dim xfil As String = ""
                Dim xfil2 As String = ""

                If Me.CHK_12.Checked Then
                    xfil2 += " and pK.auto_CONCEPTO='" + Me.CB_12.SelectedValue + "'"
                End If

                If Me.CHK_10.Checked Then
                    xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
                End If

                If Me.CHK_1.Checked Then
                    xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
                End If

                If Me.CHK_2.Checked Then
                    xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
                End If

                If Me.CHK_3.Checked Then
                    xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
                End If

                If Me.CHK_6.Checked Then
                    Select Case Me.CB_6.SelectedIndex
                        Case 0
                            xfil += " and p.estatus_balanza='1'"
                        Case 1
                            xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                        Case 2
                            xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                    End Select
                End If

                If Me.CHK_8.Checked And MF_1.Checked Then
                    xfil2 += " and pk.fecha>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
                End If

                If Me.CHK_8.Checked And MF_2.Checked Then
                    xfil2 += " and pk.fecha<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
                End If

                Dim XSQL As String = "select p.codigo, p.nombre, p.tasa, p.categoria, p.origen, pdep.nombre departamento, " & _
                                 "pgru.nombre grupo, psgr.nombre subgrupo, pmar.nombre marca, p.plu " & _
                                 "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " & _
                                 "join productos_grupo pgru on p.auto_grupo=pgru.auto " & _
                                 "join productos_subgrupo psgr on (p.auto_subgrupo=psgr.auto and psgr.auto_grupo=pgru.auto) " & _
                                 "join productos_marca pmar on p.auto_marca=pmar.auto " & _
                                 "where P.AUTO NOT IN " & _
                                 "(SELECT PK.AUTO_PRODUCTO FROM productos_kardex PK WHERE PK.auto_producto = P.AUTO " & xfil2 & ") " & _
                                 xfil & "ORDER BY P.NOMBRE"

                VisualizarReportesInventarioKardexSinMovimiento(XSQL)
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioKardex(ByVal xsql As String, ByVal xfecha_ini As Date, ByVal xfecha_fin As Date) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("kardex")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xp1 As New _Reportes.ParamtCrystal("@fecha", xfecha_ini)
            Dim xp2 As New _Reportes.ParamtCrystal("@fecha_f", xfecha_fin)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xp1)
            xlist.Add(xp2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_KARDEX.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Function VisualizarReportesInventarioKardexSinMovimiento(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("inventario")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_SIN_MOVIMIENTO.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

End Class

Public Class ReporteInventario_Valorizacion
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Valorización Del Inventario"

        Me.CHK_7.Enabled = False
        Me.CHK_8.Checked = False
        Me.CHK_8.Enabled = False
        Me.CHK_9.Enabled = False
        Me.CHK_11.Enabled = False
        Me.CHK_12.Enabled = False

        Me.MF_1.Enabled = False
        Me.MF_2.Enabled = False
        Me.CB_9.Enabled = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""

            Dim xsql As String = "select p.codigo codigo_producto, p.nombre nombre_producto, dep.codigo codigo_deposito, dep.nombre nombre_deposito, pd.disponible, pd.reservada, pd.real, " & _
                                 "pg.nombre grupo, psg.nombre subgrupo, pm.nombre empaque, p.contenido_empaque, p.costo_compra costo, " & _
                                 "pmarca.nombre as marca, pdpto.nombre as departamento " & _
                                 "from productos p inner join productos_deposito pd on p.auto=pd.auto_producto " & _
                                 "inner join depositos dep on pd.auto_deposito=dep.auto " & _
                                 "inner join productos_grupo pg on p.auto_grupo=pg.auto " & _
                                 "inner join productos_subgrupo psg on p.auto_subgrupo=psg.auto " & _
                                 "inner join productos_medida pm on p.auto_medida_compra=pm.auto " & _
                                 "inner join productos_marca pmarca on p.auto_marca=pmarca.auto " & _
                                 "inner join productos_departamento pdpto on p.auto_departamento=pdpto.auto " & _
                                 "where p.estatus='Activo' "

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.CB_4.SelectedValue + "')"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.CB_5.SelectedValue + "')"
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            If Me.CHK_8.Checked And MF_1.Checked Then
                xfil += " and p.fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked And MF_2.Checked Then
                xfil += " and p.fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            xsql += xfil + " order by p.nombre"

            VisualizarReportesInventarioValorizacion(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioValorizacion(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("productos_deposito")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                xrow("disponible") = Decimal.Round(xrow("disponible") / xrow("contenido_empaque"), 2, MidpointRounding.AwayFromZero)
                xrow("reservada") = Decimal.Round(xrow("reservada") / xrow("contenido_empaque"), 2, MidpointRounding.AwayFromZero)
                xrow("real") = Decimal.Round(xrow("real") / xrow("contenido_empaque"), 2, MidpointRounding.AwayFromZero)
            Next

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_VALORIZACION.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteInventario_MovimientoConcepto
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox
    WithEvents CB_12 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)
        CB_12 = _MiFormulario.Controls.Find("MCB_CONCEPTO", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Movimientos Del Inventario"

        Me.CHK_7.Enabled = False
        Me.CHK_8.Enabled = False
        Me.CHK_9.Enabled = False
        Me.CHK_8.Checked = True
        Me.CHK_11.Enabled = False

        Me.MF_1.Enabled = True
        Me.MF_1.ShowCheckBox = False
        Me.MF_2.Enabled = True
        Me.CB_9.Enabled = False

        Me.CHK_8.Text = "Por Fecha De Movimiento"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "SELECT (SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX " _
                                 + "WHERE AUTO_PRODUCTO=pk.auto_producto AND estatus='0' AND fecha <'" + MF_1.r_Valor.ToShortDateString + "' " _
                                 + "and auto_deposito=pk.auto_deposito) SALDO_ANTERIOR, " _
                                 + "PK.FECHA, PK.DOCUMENTO, PK.ENTIDAD, " _
                                 + "Pk.n_NombreMedidaEmpaque NOM_MEDIDA, Pk.n_ContenidoMedidaEmpaque CONTENIDO, PK.CANTIDAD_INVENTARIO CANTIDAD, pk.n_codigoconcepto COD_CONCEPTO, " _
                                 + "pk.n_NombreConcepto NOM_CONCEPTO, PK.SIGNO,pk.n_NombreDeposito NOM_DEPOSITO,pk.n_codigodeposito COD_DEPOSITO, " _
                                 + "p.nombre NOM_PRODUCTO,p.codigo COD_PRODUCTO, PG.NOMBRE GRUPO, PSG.NOMBRE SUBGRUPO, " _
                                 + "pmarca.nombre as marca, pdpto.nombre as departamento " _
                                 + "FROM PRODUCTOS_KARDEX PK " _
                                 + "JOIN PRODUCTOS P ON P.AUTO=PK.AUTO_PRODUCTO " _
                                 + "JOIN PRODUCTOS_GRUPO PG ON PG.AUTO=P.AUTO_GRUPO " _
                                 + "JOIN PRODUCTOS_SUBGRUPO PSG ON PSG.AUTO=P.AUTO_SUBGRUPO " _
                                 + "join productos_marca pmarca on p.auto_marca=pmarca.auto " _
                                 + "join productos_departamento pdpto on p.auto_departamento=pdpto.auto " _
                                 + "WHERE PK.estatus='0' "

            If Me.CHK_12.Checked Then
                xfil += " and pK.auto_concepto='" + Me.CB_12.SelectedValue + "'"
            End If

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.CB_4.SelectedValue + "')"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.CB_5.SelectedValue + "')"
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            If Me.CHK_8.Checked And MF_1.Checked Then
                xfil += " and pk.fecha>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked And MF_2.Checked Then
                xfil += " and pk.fecha<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            xsql += xfil + " ORDER BY pk.fecha,PK.DOCUMENTO"

            VisualizarReportesInventarioMovimientoConcepto(xsql, MF_1.r_Valor, MF_2.r_Valor)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioMovimientoConcepto(ByVal xsql As String, ByVal xfecha_ini As Date, ByVal xfecha_fin As Date) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("kardex")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xp1 As New _Reportes.ParamtCrystal("@fecha", xfecha_ini)
            Dim xp2 As New _Reportes.ParamtCrystal("@fecha_f", xfecha_fin)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xp1)
            xlist.Add(xp2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_MOVIMIENTOS.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteInventario_Proyeccion
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Proyeccion Venta Del Inventario"

        Me.CHK_7.Enabled = False
        Me.CHK_8.Checked = False
        Me.CHK_8.Enabled = False
        Me.CHK_9.Enabled = False
        Me.CHK_11.Enabled = False
        Me.CHK_12.Enabled = False

        Me.MF_1.Enabled = False
        Me.MF_2.Enabled = False
        Me.CB_9.Enabled = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""

            Dim xsql As String = "select p.codigo codigo_producto, p.nombre nombre_producto, dep.codigo codigo_deposito, dep.nombre nombre_deposito, pd.disponible, pd.reservada, pd.real, " & _
                                 "pg.nombre grupo, psg.nombre subgrupo, pm.nombre empaque, p.contenido_empaque, p.costo_compra costo, " & _
                                 "pmarca.nombre as marca, pdpto.nombre as departamento, " & _
                                 "0.00 as contenido_empaque_venta, '' empaque_venta, 0.00 precio_venta, p.auto as auto " & _
                                 "from productos p inner join productos_deposito pd on p.auto=pd.auto_producto " & _
                                 "inner join depositos dep on pd.auto_deposito=dep.auto " & _
                                 "inner join productos_grupo pg on p.auto_grupo=pg.auto " & _
                                 "inner join productos_subgrupo psg on p.auto_subgrupo=psg.auto " & _
                                 "inner join productos_medida pm on p.auto_medida_compra=pm.auto " & _
                                 "inner join productos_marca pmarca on p.auto_marca=pmarca.auto " & _
                                 "inner join productos_departamento pdpto on p.auto_departamento=pdpto.auto " & _
                                 "where p.estatus='Activo' "

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.CB_4.SelectedValue + "')"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.CB_5.SelectedValue + "')"
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            If Me.CHK_8.Checked And MF_1.Checked Then
                xfil += " and p.fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked And MF_2.Checked Then
                xfil += " and p.fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            xsql += xfil + " order by p.nombre"

            VisualizarReportesInventarioValorizacion(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioValorizacion(ByVal xsql As String) As Boolean
        Try
            Dim dts As New DataSet
            Dim dtb_ficha As New DataTable("productos_deposito")
            Dim dtb_empresa As New DataTable("empresa")
            Dim tb As New DataTable

            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"
            Dim xsql_2 As String = "select pe.auto_producto as auto, pe.contenido as contenido, pe.precio_1 as precio, pm.nombre as empaque from " & _
            "productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto  where referencia='1' "

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)
            g_MiData.F_GetData(xsql_2, tb)

            For Each xrow As DataRow In dtb_ficha.Rows
                Dim xauto As String = xrow("auto").ToString.Trim
                For Each xrw As DataRow In tb.Rows
                    If xauto = xrw("auto").ToString.Trim Then
                        xrow("contenido_empaque_venta") = xrw("contenido")
                        xrow("empaque_venta") = xrw("empaque").ToString.Trim
                        xrow("precio_venta") = xrw("precio")
                        Exit For
                    End If
                Next

                xrow("disponible") = Decimal.Round(xrow("disponible") / xrow("contenido_empaque_venta"), 2, MidpointRounding.AwayFromZero)
                xrow("reservada") = Decimal.Round(xrow("reservada") / xrow("contenido_empaque_venta"), 2, MidpointRounding.AwayFromZero)
                xrow("real") = Decimal.Round(xrow("real") / xrow("contenido_empaque_venta"), 2, MidpointRounding.AwayFromZero)
            Next

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_PROYECCION.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteInventario_Seniat
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox
    WithEvents CHK_13 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox
    WithEvents CB_12 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)
        CHK_13 = _MiFormulario.Controls.Find("MCHB_SIN_MOVIMIENTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)
        CB_12 = _MiFormulario.Controls.Find("MCB_CONCEPTO", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Libro Inventario SENIAT"

        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_7.Enabled = False
        Me.CHK_8.Enabled = False
        Me.CHK_9.Enabled = False
        Me.CHK_8.Checked = True
        Me.CHK_11.Enabled = False
        Me.CHK_12.Enabled = False
        Me.CHK_13.Enabled = False

        Me.MF_1.Enabled = True
        Me.MF_2.Enabled = True
        Me.CB_9.Enabled = True
        Me.MF_1.ShowCheckBox = False
        Me.CHK_8.Text = "Por Fecha De Movimiento"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select 0 as item, p.nombre, COSTO_PROMEDIO_COMPRA as costop, COSTO_COMPRA as costo, pm.nombre as empaque, " & _
                "contenido_empaque as contenido, PG.NOMBRE as GRUPO, PSG.NOMBRE as SUBGRUPO, pmarca.nombre as marca, pdpto.nombre as departamento, " & _
                "(SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX  WHERE estatus='0' AND fecha<@FINI and AUTO_PRODUCTO=p.auto) as inv_inicial, " & _
                "(SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX  WHERE estatus='0' AND fecha >=@FINI and fecha<=@FFIN and AUTO_PRODUCTO=p.auto " & _
                "and auto_concepto in ('0000000002','0000000009')) as entradas, " & _
                "(SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX WHERE estatus='0' AND fecha >=@FINI and fecha<=@FFIN and AUTO_PRODUCTO=p.auto " & _
                "and auto_concepto in ('0000000008','0000000003')) as salidas, " & _
                "(SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX  WHERE estatus='0' AND fecha<=@FFIN and AUTO_PRODUCTO=p.auto) as existencia " & _
                "from productos p " & _
                "JOIN productos_medida pm on pm.auto =p.auto_medida_compra " & _
                "JOIN PRODUCTOS_GRUPO PG ON PG.AUTO=P.AUTO_GRUPO " & _
                "JOIN PRODUCTOS_SUBGRUPO PSG ON PSG.AUTO=P.AUTO_SUBGRUPO " & _
                "JOIN productos_marca pmarca on p.auto_marca=pmarca.auto " & _
                "JOIN productos_departamento pdpto on p.auto_departamento=pdpto.auto " & _
                "WHERE P.estatus='Activo' "

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            Select Case CB_9.SelectedIndex
                Case 0 : xsql += xfil + " order by p.nombre"
                Case 1 : xsql += xfil + " order by p.codigo"
                Case 2 : xsql += xfil + " order by p.plu"
            End Select

            VisualizarReportesInventarioKardex(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioKardex(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("InvSeniat")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xp1 As New SqlParameter("@fini", Me.MF_1.Value.Date)
            Dim xp2 As New SqlParameter("@ffin", Me.MF_2.Value.Date)
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha, xp1, xp2)

            Dim xt As Integer = 0
            For Each xr As DataRow In dtb_ficha.Rows
                xt += 1
                xr("item") = xt
            Next

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xf1 As New _Reportes.ParamtCrystal("@FECHA_I", Me.MF_1.Value.Date)
            Dim xf2 As New _Reportes.ParamtCrystal("@FECHA_F", Me.MF_2.Value.Date)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xf1)
            xlist.Add(xf2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_SENIAT.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteInventario_Movimiento
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox
    WithEvents CHK_13 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox
    WithEvents CB_12 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)
        CHK_13 = _MiFormulario.Controls.Find("MCHB_SIN_MOVIMIENTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)
        CB_12 = _MiFormulario.Controls.Find("MCB_CONCEPTO", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Libro Inventario / Movimiento"

        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_7.Enabled = False
        Me.CHK_8.Enabled = False
        Me.CHK_9.Enabled = False
        Me.CHK_8.Checked = True
        Me.CHK_11.Enabled = False
        Me.CHK_12.Enabled = False
        Me.CHK_13.Enabled = False

        Me.MF_1.Enabled = True
        Me.MF_2.Enabled = True
        Me.CB_9.Enabled = True
        Me.MF_1.ShowCheckBox = False
        Me.CHK_8.Text = "Por Fecha De Movimiento"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select 0 as item, p.nombre, COSTO_PROMEDIO_COMPRA as costop, COSTO_COMPRA as costo, (P.precio_pto_venta+(P.precio_pto_venta*p.tasa/100)) as precio_sugerido , p.codigo as codigo_producto,  pm.nombre as empaque, " & _
                "contenido_empaque as contenido, PG.NOMBRE as GRUPO, PSG.NOMBRE as SUBGRUPO, pmarca.nombre as marca, pdpto.nombre as departamento, " & _
                "(SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX  WHERE estatus='0' AND fecha<@FINI and AUTO_PRODUCTO=p.auto) as inv_inicial, " & _
                "(SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX  WHERE estatus='0' AND fecha >=@FINI and fecha<=@FFIN and AUTO_PRODUCTO=p.auto " & _
                "and auto_concepto in ('0000000002','0000000009')) as entradas, " & _
                "(SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX WHERE estatus='0' AND fecha >=@FINI and fecha<=@FFIN and AUTO_PRODUCTO=p.auto " & _
                "and auto_concepto in ('0000000008','0000000003')) as salidas, " & _
                "(SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX  WHERE estatus='0' AND fecha<=@FFIN and AUTO_PRODUCTO=p.auto) as existencia " & _
                "from productos p " & _
                "JOIN productos_medida pm on pm.auto =p.auto_medida_compra " & _
                "JOIN PRODUCTOS_GRUPO PG ON PG.AUTO=P.AUTO_GRUPO " & _
                "JOIN PRODUCTOS_SUBGRUPO PSG ON PSG.AUTO=P.AUTO_SUBGRUPO " & _
                "JOIN productos_marca pmarca on p.auto_marca=pmarca.auto " & _
                "JOIN productos_departamento pdpto on p.auto_departamento=pdpto.auto " & _
                "WHERE P.estatus='Activo' "

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            Select Case CB_9.SelectedIndex
                Case 0 : xsql += xfil + " order by p.nombre"
                Case 1 : xsql += xfil + " order by p.codigo"
                Case 2 : xsql += xfil + " order by p.plu"
            End Select

            VisualizarReportesInventarioKardex(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioKardex(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("InvSeniat")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xp1 As New SqlParameter("@fini", Me.MF_1.Value.Date)
            Dim xp2 As New SqlParameter("@ffin", Me.MF_2.Value.Date)
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha, xp1, xp2)

            Dim xt As Integer = 0
            For Each xr As DataRow In dtb_ficha.Rows
                xt += 1
                xr("item") = xt
            Next

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xf1 As New _Reportes.ParamtCrystal("@FECHA_I", Me.MF_1.Value.Date)
            Dim xf2 As New _Reportes.ParamtCrystal("@FECHA_F", Me.MF_2.Value.Date)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xf1)
            xlist.Add(xf2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "REP_INVENTARIO_MOVIMIENTO.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class

Public Class ReporteInventario_PreciosArticulo_Existencia
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        Me.CHK_7.Enabled = False
        Me.CHK_8.Checked = False
        Me.CHK_8.Enabled = False
        Me.CHK_9.Enabled = False
        Me.CHK_11.Enabled = False
        Me.CHK_12.Enabled = False

        Me.MF_1.Enabled = False
        Me.MF_2.Enabled = False
        LB_1.Text = "Maestro De Inventario/Precio Del Articulo"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select p.codigo, p.nombre, p.tasa, p.categoria, p.origen, p.psv, p.precio_pto_venta, " & _
                                 "pmed.nombre medida_venta, 0.00 utilidad_pto_venta, p.auto, p.costo_inventario, " & _
                                 "pg.nombre grupo, psg.nombre subgrupo, p.plu , pdpto.nombre as departamento , pmarca.nombre as marca, " & _
                                 "(select sum(disponible) from productos_deposito as pd where pd.auto_producto=p.auto group by pd.auto_producto) as disponible, " & _
                                 "(select sum(reservada) from productos_deposito as pd where pd.auto_producto=p.auto group by pd.auto_producto) as reservada " & _
                                 "from productos p join productos_medida pmed on p.auto_medida_venta=pmed.auto " & _
                                 "join productos_departamento pdpto on p.auto_departamento=pdpto.auto " & _
                                 "join productos_marca pmarca on p.auto_marca=pmarca.auto " & _
                                 "inner join productos_grupo pg on p.auto_grupo=pg.auto inner join productos_subgrupo psg on p.auto_subgrupo=psg.auto " & _
                                 "where estatus='Activo' "

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.CB_4.SelectedValue + "')"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.CB_5.SelectedValue + "')"
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            If Me.CHK_8.Checked And MF_1.Checked Then
                xfil += " and p.fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked And MF_2.Checked Then
                xfil += " and p.fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            Select Case Me.CB_9.SelectedIndex
                Case 0 : xsql += xfil + " order by p.nombre"
                Case 1 : xsql += xfil + " order by p.codigo"
                Case 2 : xsql += xfil + " order by p.plu"
            End Select

            VisualizarReportesInventarioPrecioArticulo(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioPrecioArticulo(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("inventario")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                Dim xmargen As Decimal = Decimal.Round(xrow("precio_pto_venta") - xrow("costo_inventario"), 2, MidpointRounding.AwayFromZero)
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                    xrow("utilidad_pto_venta") = Decimal.Round(UtilidadBaseCosto(xrow("costo_inventario"), xmargen), 2, MidpointRounding.AwayFromZero)
                Else
                    xrow("utilidad_pto_venta") = Decimal.Round(UtilidadBasePrecioVenta(xrow("precio_pto_venta"), xmargen), 2, MidpointRounding.AwayFromZero)
                End If
            Next
            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "INVENTARIO_PRECIOS_ARTICULO_EXISTENCIA.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class


Public Class ActualizacionPrecios_Grupo
    Implements IPlantillaFiltroReportesInventario

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
    WithEvents CHK_9 As MisCheckBox
    WithEvents CHK_10 As MisCheckBox
    WithEvents CHK_11 As MisCheckBox
    WithEvents CHK_12 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents CB_4 As MisComboBox
    WithEvents CB_5 As MisComboBox
    WithEvents CB_6 As MisComboBox
    WithEvents CB_7 As MisComboBox
    WithEvents CB_9 As MisComboBox
    WithEvents CB_10 As MisComboBox
    WithEvents CB_11 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesInventario.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

        CHK_1 = _MiFormulario.Controls.Find("MCHB_DEPARTAMENTO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_SUBGRUPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_DEPOSITO", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_PLU", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRECIO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_9 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_10 = _MiFormulario.Controls.Find("MCHB_MARCA", True)(0)
        CHK_11 = _MiFormulario.Controls.Find("MCHB_NIVEL", True)(0)
        CHK_12 = _MiFormulario.Controls.Find("MCHB_CONCEPTO", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_DEPARTAMENTO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_SUBGRUPO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_DEPOSITO", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_PLU", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_PRECIO", True)(0)
        CB_9 = _MiFormulario.Controls.Find("MCB_ORDEN", True)(0)
        CB_10 = _MiFormulario.Controls.Find("MCB_MARCA", True)(0)
        CB_11 = _MiFormulario.Controls.Find("MCB_NIVEL_STOCK", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        'Me.CHK_7.Enabled = False
        Me.CHK_8.Checked = False
        Me.CHK_8.Enabled = False
        Me.CHK_9.Enabled = False
        Me.CHK_11.Enabled = False
        Me.CHK_12.Enabled = False

        Me.MF_1.Enabled = False
        Me.MF_2.Enabled = False

        Me.CB_9.Enabled = False

        LB_1.Text = "Actualización General Precios Inventario"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xreferencia As String = ""
            Dim xfil As String = ""
            Dim xsql As String = "select p.auto  " & _
                                 "from productos p " & _
                                 "join productos_medida as pmed on p.auto_medida_venta=pmed.auto " & _
                                 "join productos_departamento as pdpto on p.auto_departamento=pdpto.auto " & _
                                 "join productos_marca as pmarca on p.auto_marca=pmarca.auto " & _
                                 "join productos_grupo pg on p.auto_grupo=pg.auto " & _
                                 "join productos_subgrupo psg on p.auto_subgrupo=psg.auto " & _
                                 "where estatus='Activo' "

            If Me.CHK_10.Checked Then
                xfil += " and p.auto_marca='" + Me.CB_10.SelectedValue + "'"
            End If

            If Me.CHK_1.Checked Then
                xfil += " and p.auto_departamento='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and p.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.CB_4.SelectedValue + "')"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.CB_5.SelectedValue + "')"
            End If

            If Me.CHK_6.Checked Then
                Select Case Me.CB_6.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 2
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                End Select
            End If

            If Me.CHK_8.Checked And MF_1.Checked Then
                xfil += " and p.fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_8.Checked And MF_2.Checked Then
                xfil += " and p.fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_7.Checked Then
                xreferencia = (Me.CB_7.SelectedIndex + 1).ToString
            End If

            Select Case Me.CB_9.SelectedIndex
                Case 0 : xsql += xfil + " order by p.nombre"
                Case 1 : xsql += xfil + " order by p.codigo"
                Case 2 : xsql += xfil + " order by p.plu"
            End Select

            VisualizarReportesInventarioPrecioArticulo(xsql, xreferencia)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportesInventarioPrecioArticulo(ByVal xsql As String, ByVal referencia As String) As Boolean
        Dim dtb_ficha As New DataTable
        Try
            g_MiData.F_GetData(xsql, dtb_ficha)
            If dtb_ficha.Rows.Count > 0 Then
                Dim xplant As New Inventario_PorcentajeIncrementar
                Dim xvent As New Plantilla_ConfiguracionModulo_5(xplant)
                With xvent
                    .ShowDialog()
                End With
                If xplant.PorcentajeSeleccionado > 0 Then
                    For Each xrow In dtb_ficha.Rows
                        Dim xprd As New FichaProducto.Prd_Producto.ActualizarPrecioDetal
                        With xprd
                            .AutoProducto = xrow(0)
                            .EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
                            .PorcentajeIncrementar = xplant.PorcentajeSeleccionado
                            .Usuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                            .Referencia = referencia
                        End With
                        g_MiData.f_FichaProducto.f_PrdProducto.F_ActualizarPreciosDetal(xprd)
                    Next
                    Funciones.MensajeDeOk("PRODUCTOS ACTUALIZADOS EXITOSAMENTE")
                End If
            Else
                Throw New Exception("Productos No Encontrado")
            End If

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class
