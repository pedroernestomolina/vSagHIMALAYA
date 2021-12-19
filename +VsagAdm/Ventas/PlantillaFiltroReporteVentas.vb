Imports MisControles.Controles
Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class PlantillaFiltroReporteVentas
    Dim xplantilla As IPlantillaFiltroReportesVentas

    Dim xdetallado As String() = {"Si", "No"}
    Dim xtb_cliente As DataTable
    Dim xtb_series As DataTable
    Dim xest_salida As Boolean

    Property EstatusSalida() As Boolean
        Get
            Return xest_salida
        End Get
        Set(ByVal value As Boolean)
            xest_salida = value
        End Set
    End Property

    Private Sub PlantillaFiltroReporteVentas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Sub CargarData()
        xtb_cliente = New DataTable

        xtb_series = New DataTable
        g_MiData.F_GetData("select NRF from series_fiscales group by nrf order by nrf", xtb_series)
        With Me.MCB_SERIES
            .DataSource = xtb_series
            .DisplayMember = "NRF"
            .ValueMember = "NRF"
        End With

        With Me.MCB_DETALLADO
            .DataSource = xdetallado
            .SelectedIndex = 0
        End With
    End Sub

    Sub Inicializa()
        Try
            ApagarControles()
            CargarData()
            _MiPLantilla.Inicializa(Me)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ApagarControles()
        Me.MCB_CLIENTE.Enabled = False
        Me.MCB_SERIES.Enabled = False
        Me.MF_DESDE.Enabled = False
        Me.MF_HASTA.Enabled = False
    End Sub

    Private Sub MCHB_SERIES_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_SERIES.CheckedChanged
        Me.MCB_SERIES.Enabled = MCHB_SERIES.Checked
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

    Property _MiPLantilla() As IPlantillaFiltroReportesVentas
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantillaFiltroReportesVentas)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaFiltroReportesVentas)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiPLantilla = xplantilla
    End Sub

    Private Sub PlantillaFiltroReporteVentas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub MCHB_CLIENTE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCHB_CLIENTE.Click
        Me.MCB_CLIENTE.Enabled = MCHB_CLIENTE.Checked
    End Sub

    Private Sub MCHB_CLIENTE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_CLIENTE.CheckedChanged
        If Me.MCHB_CLIENTE.Checked Then
            If Me.xtb_cliente.Rows.Count = 0 Then
                g_MiData.F_GetData("select nombre,auto from clientes order by nombre", xtb_cliente)
                With Me.MCB_CLIENTE
                    .DataSource = xtb_cliente
                    .DisplayMember = "nombre"
                    .ValueMember = "auto"
                End With
            End If
        End If
    End Sub

    Private Sub PlantillaFiltroReporteVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IPlantillaFiltroReportesVentas
    Sub Inicializa(ByVal xform As Object)
End Interface

Public Class ReporteVentas_DocumentoGeneral
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        CB_3.Enabled = False

        LB_1.Text = "Documentos En General"
        Me.CHK_1.Select()
        Me.CHK_1.Focus()
        Me.CHK_8.Checked = True
        Me.CHK_8.Enabled = False
        Me.MF_I.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
            "select fecha,documento,nombre,ci_rif,exento,base,impuesto,total,estatus,tipo  from ventas where auto<>'' "

            If Me.CHK_1.Checked Then
                xfil += " and AUTO_ENTIDAD='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and NRF='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Or Me.CHK_4.Checked Or Me.CHK_5.Checked Or Me.CHK_6.Checked Or Me.CHK_7.Checked Then
                Dim data As String = ""
                If Me.CHK_3.Checked Then 'Factura
                    data += "(tipo='01'"
                End If
                If Me.CHK_4.Checked Then 'NC
                    If data = "" Then
                        data += "(tipo='03'"
                    Else
                        data += "or tipo='03'"
                    End If
                End If
                If Me.CHK_5.Checked Then 'Pedido
                    If data = "" Then
                        data += "(tipo='06'"
                    Else
                        data += "or tipo='06'"
                    End If
                End If
                If Me.CHK_6.Checked Then 'Nota Entrega
                    If data = "" Then
                        data += "(tipo='04'"
                    Else
                        data += "or tipo='04'"
                    End If
                End If
                If Me.CHK_7.Checked Then  'Presupuesto
                    If data = "" Then
                        data += "(tipo='05'"
                    Else
                        data += "or tipo='05'"
                    End If
                End If
                xfil += "and " + data + ")"
            Else
                xfil += " and TIPO IN ('01','03','04','05','06')"
            End If

            If Me.CHK_8.Checked Then
                If MF_I.Checked Then
                    xfil += " and fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                End If
                If MF_F.Checked Then
                    xfil += " and fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                End If
            End If
            xsql += xfil + " order by fecha,auto,tipo,documento"

            g_MiData.F_GetData(xsql, xds)
            xds.Tables(0).TableName = "Empresa"
            xds.Tables(1).TableName = "VENTA_1"

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "VEN_GENERAL.rpt"
            Dim xficha As New _Reportes(xds, xrep, Nothing)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class ReporteVentas_Consolidado
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        LB_1.Text = "Consolidado De Ventas"

        'DESACTIVAR CLIENTE
        Me.CHK_1.Enabled = False
        CB_3.Enabled = False

        Me.CHK_2.Select()
        Me.CHK_2.Focus()
        Me.CHK_8.Checked = True
        Me.CHK_8.Enabled = False
        Me.MF_I.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
            "select fecha,count(documento) cnt,sum(exento) exento,sum(base) base,sum(impuesto) imp,sum(total) tot,tipo,estatus  from ventas where auto<>''"

            If Me.CHK_1.Checked Then
                xfil += " and AUTO_ENTIDAD='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and NRF='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Or Me.CHK_4.Checked Or Me.CHK_5.Checked Or Me.CHK_6.Checked Or Me.CHK_7.Checked Then
                Dim data As String = ""
                If Me.CHK_3.Checked Then 'Factura
                    data += "(tipo='01'"
                End If
                If Me.CHK_4.Checked Then 'NC
                    If data = "" Then
                        data += "(tipo='03'"
                    Else
                        data += "or tipo='03'"
                    End If
                End If
                If Me.CHK_5.Checked Then 'Pedido
                    If data = "" Then
                        data += "(tipo='06'"
                    Else
                        data += "or tipo='06'"
                    End If
                End If
                If Me.CHK_6.Checked Then 'Nota Entrega
                    If data = "" Then
                        data += "(tipo='04'"
                    Else
                        data += "or tipo='04'"
                    End If
                End If
                If Me.CHK_7.Checked Then  'Presupuesto
                    If data = "" Then
                        data += "(tipo='05'"
                    Else
                        data += "or tipo='05'"
                    End If
                End If
                xfil += "and " + data + ")"
            Else
                xfil += " and TIPO IN ('01','03','04','05','06')"
            End If

            If Me.CHK_8.Checked Then
                If MF_I.Checked Then
                    xfil += " and fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                End If
                If MF_F.Checked Then
                    xfil += " and fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                End If
            End If
            xsql += xfil + "group by fecha,tipo,estatus order by fecha,tipo,estatus"

            g_MiData.F_GetData(xsql, xds)
            xds.Tables(0).TableName = "Empresa"
            xds.Tables(1).TableName = "VENTA_2"

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "VEN_CONSOLIDADO.rpt"
            Dim xficha As New _Reportes(xds, xrep, Nothing)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class ReporteVentas_Departamento
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        LB_1.Text = "Por Departamentos"

        'DESACTIVAR CHECK
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = False
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False

        With Me.CHK_8
            .Checked = True
            .Select()
            .Focus()
            .Enabled = False
        End With
        Me.MF_I.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
            "SELECT pd.nombre nombre,vd.fecha fecha ,sum(vd.signo*vd.cantidad) cant,sum(vd.signo*vd.total_neto) vneto,SUM(vd.signo*vd.costo_venta) vcosto, " & _
            "sum (vd.signo*vd.total_neto*v.descuento1_porcentaje /100 ) vdescuento " & _
            "from ventas_detalle vd join productos_departamento pd on vd.auto_departamento=pd.auto join ventas  v on vd.auto_documento=v.auto " & _
            "where vd.estatus='0' and v.tipo in ('01', '03')"

            Dim xsql1 As String = "select nombre,rif,direccion from empresa;" & _
            "SELECT pd.nombre nombre ,sum(vd.signo*vd.cantidad) cant,sum(vd.signo*vd.total_neto) vneto,SUM(vd.signo*vd.costo_venta) vcosto, " & _
            "sum (vd.signo*vd.total_neto*v.descuento1_porcentaje /100 ) vdescuento " & _
            "from ventas_detalle vd join productos_departamento pd on vd.auto_departamento=pd.auto join ventas  v on vd.auto_documento=v.auto " & _
            "where vd.estatus='0' and v.tipo in ('01', '03')"

            If Me.CHK_8.Checked Then
                If MF_I.Checked Then
                    xfil += " and vd.fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                End If
                If MF_F.Checked Then
                    xfil += " and vd.fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                End If
            End If

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            Dim xficha As _Reportes

            If CB_3.SelectedIndex = 0 Then  'DETALLADO SI
                xsql += xfil + " group by vd.fecha, vd.auto_departamento , pd.nombre order by vd.fecha,pd.nombre"
                xrep += "VEN_DEPARTAMENTO.rpt"
                xficha = New _Reportes(xds, xrep, Nothing)
            Else ' DETALLADO NO
                xsql = xsql1 + xfil + " group by vd.auto_departamento , pd.nombre order by pd.nombre"
                xrep += "VEN_DEPARTAMENTO_1.rpt"
                Dim xlist As New List(Of _Reportes.ParamtCrystal)
                xlist.Add(New _Reportes.ParamtCrystal("@desde", IIf(Me.MF_I.Checked, MF_I.Value.ToShortDateString, "")))
                xlist.Add(New _Reportes.ParamtCrystal("@hasta", IIf(Me.MF_F.Checked, MF_F.Value.ToShortDateString, "")))
                xficha = New _Reportes(xds, xrep, xlist)
            End If

            g_MiData.F_GetData(xsql, xds)
            xds.Tables(0).TableName = "Empresa"
            xds.Tables(1).TableName = "VENTA_3"

            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class ReporteVentas_PorGrupo
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        LB_1.Text = "Ventas Por Grupo"

        'DESACTIVAR CHECK
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = False
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False

        With Me.CHK_8
            .Checked = True
            .Select()
            .Focus()
            .Enabled = False
        End With
        Me.MF_I.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
            "SELECT '' nombreg,sum(vd.signo*vd.cantidad*vd.contenido_empaque) cant,sum(vd.signo*vd.total_neto) vneto,SUM(vd.signo*vd.costo_venta) vcosto, " & _
            "sum (vd.signo*vd.total_neto*v.descuento1_porcentaje /100 ) vdescuento, vd.nombre nombreprd, vd.auto_grupo, pm.nombre as medida, " & _
            "p.contenido_empaque as contenido " & _
            "from ventas_detalle vd join ventas  v on vd.auto_documento=v.auto join productos p on vd.auto_productos=p.auto " & _
                       "join productos_medida pm on p.auto_medida_compra = pm.auto where vd.estatus='0' and v.tipo in ('01', '03')"

            Dim xsql1 As String = "select nombre,rif,direccion from empresa;" & _
                       "SELECT '' nombreg,sum(vd.signo*vd.cantidad) cant,sum(vd.signo*vd.total_neto) vneto,SUM(vd.signo*vd.costo_venta) vcosto, " & _
                       "sum (vd.signo*vd.total_neto*v.descuento1_porcentaje /100 ) vdescuento, vd.auto_grupo " & _
                       "from ventas_detalle as vd join ventas as v on vd.auto_documento=v.auto where v.estatus='0' and v.tipo in ('01', '03')"

            If Me.CHK_8.Checked Then
                If MF_I.Checked Then
                    xfil += " and v.fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                End If
                If MF_F.Checked Then
                    xfil += " and v.fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                End If
            End If

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            If Me.CB_3.SelectedIndex = 0 Then 'DETALLADO SI
                xsql += xfil + " GROUP BY vd.auto_grupo, vd.nombre, pm.nombre, p.contenido_empaque order by vd.nombre"
                xrep += "VEN_PORGRUPO.rpt"

                g_MiData.F_GetData(xsql, xds)
                xds.Tables(0).TableName = "Empresa"
                xds.Tables(1).TableName = "VENTA_4"

                Dim xgrup As String = ""
                Dim xnomg As String = ""
                Dim xp1 As SqlParameter
                For Each dr In xds.Tables(1).Rows
                    If xgrup.Trim <> dr(6).ToString.Trim Then
                        xgrup = dr(6).ToString  ' AUTO_GRUPO
                        xp1 = New SqlParameter("@auto_grupo", xgrup)
                        xnomg = DataSistema.MiDataSistema.DataSistema.F_GetString("SELECT NOMBRE FROM productos_grupo where auto=@auto_grupo", xp1)
                        dr(0) = xnomg
                    Else
                        dr(0) = xnomg
                    End If
                Next

            Else 'DETALLADO NO
                xsql = ""
                xsql = xsql1 + xfil + " group by vd.auto_grupo "
                xrep += "VEN_PORGRUPO_1.rpt"

                g_MiData.F_GetData(xsql, xds)
                xds.Tables(0).TableName = "Empresa"
                xds.Tables(1).TableName = "VENTA_4"

                Dim xgrup As String = ""
                Dim xp1 As SqlParameter
                For Each dr In xds.Tables(1).Rows
                    xgrup = dr(5).ToString  ' AUTO_GRUPO
                    xp1 = New SqlParameter("@auto_grupo", xgrup)
                    dr(0) = DataSistema.MiDataSistema.DataSistema.F_GetString("SELECT NOMBRE FROM productos_grupo where auto=@auto_grupo", xp1)
                Next
            End If


            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(New _Reportes.ParamtCrystal("@desde", IIf(Me.MF_I.Checked, MF_I.Value.ToShortDateString, "")))
            xlist.Add(New _Reportes.ParamtCrystal("@hasta", IIf(Me.MF_F.Checked, MF_F.Value.ToShortDateString, "")))

            Dim xficha As New _Reportes(xds, xrep, xlist)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class ReporteVentas_UtilidadVentas
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        LB_1.Text = "Utilidad En Ventas"
        Me.CHK_1.Select()
        Me.CHK_1.Focus()

        'DESACTIVAR CHECK DE TIPOS DE DOCUMENTOS
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False
        Me.CB_3.Enabled = False

        Me.CHK_8.Checked = True
        Me.CHK_8.Enabled = False
        Me.MF_I.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
            "SELECT v.fecha fecha, v.documento , v.nombre, v.ci_rif, sum(vd.signo*vd.total_neto) vneto,SUM(vd.signo*vd.costo_venta) vcosto, " & _
            "sum (vd.signo*vd.total_neto*v.descuento1_porcentaje /100 ) vdescuento from ventas v join ventas_detalle vd on vd.auto_documento=v.auto " & _
            "where v.auto<> '' and v.tipo in ('01','03') and v.estatus='0'"

            If Me.CHK_1.Checked Then
                xfil += " and v.AUTO_ENTIDAD='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and v.NRF='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_8.Checked Then
                If MF_I.Checked Then
                    xfil += " and v.fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                End If
                If MF_F.Checked Then
                    xfil += " and v.fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                End If
            End If
            xsql += xfil + " group by v.fecha, v.documento, v.nombre, v.ci_rif order by v.fecha,v.documento"

            g_MiData.F_GetData(xsql, xds)
            xds.Tables(0).TableName = "Empresa"
            xds.Tables(1).TableName = "VENTA_5"

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "VEN_UTILIDAD.rpt"
            Dim xficha As New _Reportes(xds, xrep, Nothing)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class ReporteVentas_FacturasDetalladas
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        LB_1.Text = "Facturas Detalladas"
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = True
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False
        Me.CHK_8.Checked = True
        Me.CHK_8.Enabled = False
        CB_3.Enabled = False

        With Me.MF_I
            .Select()
            .Focus()
            .ShowCheckBox = False
        End With
    End Sub

    'Dim xcadena As String
    'Sub New()
    '    xcadena = "Provider=vfpoledb;Data Source=C:\vsag_2009\vsag.dbc;Collating Sequence=machine;"
    'End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xfil_1 As String = ""
            Dim xds As DataSet = New DataSet
            Dim tb1 As New DataTable("EMPRESA")
            Dim tb2 As New DataTable("ENCABEZADO")
            Dim tb3 As New DataTable("DETALLE")

            Dim xsql As String = "select nombre,rif,direccion from empresa"
            Dim xsql1 As String = "select AUTO,DOCUMENTO,FECHA,NOMBRE,DIR_FISCAL,CI_RIF,EXENTO,BASE1,BASE2,BASE3,IMPUESTO1,IMPUESTO2,IMPUESTO3, " & _
            " TOTAL, NRF,CONTROL,RENGLONES,CONDICION_PAGO from ventas where estatus='0' and tipo='01' "
            Dim xsql2 As String = "select AUTO_DOCUMENTO,VD.NOMBRE,CANTIDAD,EMPAQUE,PRECIO_NETO,TASA,VD.IMPUESTO,TOTAL_NETO, VD.DESCUENTO1P from ventas_detalle vd join " & _
            " ventas v on v.auto=vd.auto_documento where v.estatus='0' and v.tipo='01' "

            If Me.CHK_8.Checked Then
                If MF_I.Checked Then
                    xfil += " and fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                    xfil_1 += " and v.fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                End If
                If MF_F.Checked Then
                    xfil += " and fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                    xfil_1 += " and v.fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                End If
            End If

            If Me.CHK_2.Checked Then
                xfil += " and nrf='" + Me.CB_2.SelectedValue + "'"
                xfil_1 += " and v.nrf='" + Me.CB_2.SelectedValue + "'"
            End If

            xsql1 += xfil + " order by auto"
            xsql2 += xfil_1 + " order by v.auto"

            g_MiData.F_GetData(xsql, tb1)
            g_MiData.F_GetData(xsql1, tb2)
            g_MiData.F_GetData(xsql2, tb3)

            xds.Tables.Add(tb1)
            xds.Tables.Add(tb2)
            xds.Tables.Add(tb3)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "RPT_VENTAS_FACTURAS_DETALLADAS.rpt"

            Dim xficha As New _Reportes(xds, xrep, Nothing)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try


        'Try
        '    Dim xfil As String = ""
        '    Dim xfil_1 As String = ""
        '    Dim xds As DataSet = New DataSet
        '    Dim tb1 As New DataTable("EMPRESA")
        '    Dim tb2 As New DataTable("ENCABEZADO")
        '    Dim tb3 As New DataTable("DETALLE")

        '    Dim xsql As String = "select NOM_EMP AS nombre, RIF_EMP AS rif, DIR_EMP AS direccion from empresa"

        '    Dim xsql1 As String = "select num_fac AS AUTO, NUM_FAC AS DOCUMENTO, FEM_FAC AS FECHA, NOM_CLI AS NOMBRE, " & _
        '        "DIR_CLI AS DIR_FISCAL, RIF_CLI AS CI_RIF, B0_FAC AS EXENTO, B1_FAC AS BASE1, B2_FAC AS BASE2, B3_FAC AS BASE3," & _
        '        "round(B1_FAC*I1_FAC/100,2) AS IMPUESTO1, round(B2_FAC*I2_FAC/100,2) AS IMPUESTO2, round(B3_FAC*I3_FAC/100,2) AS IMPUESTO3, " & _
        '        "TOT_FAC AS TOTAL, SERIAL_F AS NRF, FACTURA_F AS CONTROL, 0 AS RENGLONES, 'CONTADO' AS CONDICION_PAGO " & _
        '        "from FACTURA,CLIENTE WHERE CLI_FAC=COD_CLI"

        '    Dim xsql2 As String = "select REGFACTURA.NUM_FAC as AUTO_DOCUMENTO,des_prd as NOMBRE,can_fac as CANTIDAD,emp_fac as EMPAQUE, " & _
        '        "pne_fac as PRECIO_NETO, iva_fac as TASA, ROUND(CAN_FAC*PNE_FAC*IVA_FAC/100,2) as IMPUESTO, " & _
        '        "ROUND(CAN_FAC*PNE_FAC,2) AS TOTAL_NETO from REGFACTURA,ALMACEN,FACTURA " & _
        '        "WHERE REGFACTURA.NUM_FAC=FACTURA.NUM_FAC AND REGFACTURA.PRD_FAC=ALMACEN.COD_PRD"


        '    xsql1 += xfil + " order by auto"
        '    xsql2 += xfil_1 + " order by auto_documento"

        '    tb1 = F_getdata(xsql)
        '    tb2 = F_getdata(xsql1)
        '    tb3 = F_getdata(xsql2)

        '    tb1.TableName = "EMPRESA"
        '    tb2.TableName = "ENCABEZADO"
        '    tb3.TableName = "DETALLE"

        '    xds.Tables.Add(tb1)
        '    xds.Tables.Add(tb2)
        '    xds.Tables.Add(tb3)

        '    'Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
        '    'xrep += "RPT_VENTAS_FACTURAS_DETALLADAS.rpt"

        '    Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
        '    xrep = "C:\+VsagAdm v7.9.27\+VsagAdm\Reportes\RPT_VENTAS_FACTURAS_DETALLADAS.rpt"

        '    Dim xficha As New _Reportes(xds, xrep, Nothing)
        '    With xficha
        '        .Show()
        '    End With
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

    End Sub

    'Function F_getdata(ByVal xsql As String) As DataTable
    '    Try
    '        Dim xtb As New DataTable
    '        Using xadap As New OleDbDataAdapter(xsql, xcadena)
    '            xadap.Fill(xtb)
    '        End Using
    '        Return xtb
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Function
End Class

Public Class ReporteVentas_CuadroResumen
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        LB_1.Text = "Cuadro Resumen"
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = True
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False
        Me.CHK_8.Checked = True
        Me.CHK_8.Enabled = False
        CB_3.Enabled = False

        With Me.MF_I
            .Select()
            .Focus()
            .ShowCheckBox = False
        End With
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xfil_1 As String = ""
            Dim xds As DataSet = New DataSet
            Dim tb1 As New DataTable("EMPRESA")
            Dim tb2 As New DataTable("T1")
            Dim tb3 As New DataTable("T2")
            Dim tb4 As New DataTable("T3")
            Dim tb5 As New DataTable("T4")
            Dim tb6 As New DataTable("T5")

            Dim xsql As String = "select nombre,rif,direccion from empresa"

            Dim xsql_1 As String = "SELECT SUM(TOTAL) as total, count(*) as cnt, MIN(documento) as min, MAX(documento) as max, serie, " & _
            "CASE TIPO WHEN '01' THEN 'VENTAS' WHEN '03' THEN 'NOTAS CREDITO' END AS GRUPO, " & _
            "CASE TIPO WHEN '01' THEN 1 WHEN '03' THEN -1 END AS SIGNO " & _
            "FROM ventas where tipo IN ('01','03') and estatus='0' "

            Dim xsql_3 As String = "SELECT SUM(TOTAL) as total , count(*) as cnt, condicion_pago as tipopago FROM ventas " & _
            "where tipo='01' AND estatus='0' "


            Dim xsql_5 As String = "select SUM(cmp.importe) as Importe, case cmp.estatus " & _
            "when '0' then cmp.nombre " & _
            "when '1' then +'ANULADO '+cmp.nombre " & _
            "end as MedioPago, COUNT(*) as cnt from cxc_modo_pago cmp " & _
            "join ventas v on cmp.auto_recibo = v.auto_recibo where v.tipo='01' and v.estatus='0' "

            If Me.CHK_8.Checked Then
                If MF_I.Checked Then
                    xfil += " and fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                    xfil_1 += " and v.fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                End If
                If MF_F.Checked Then
                    xfil += " and fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                    xfil_1 += " and v.fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                End If
            End If

            If Me.CHK_2.Checked Then
                xfil += " and nrf='" + Me.CB_2.SelectedValue + "'"
                xfil_1 += " and v.nrf='" + Me.CB_2.SelectedValue + "'"
            End If

            Dim xsql_4 As String = "SELECT documento, total , serie, nombre, ci_rif, fecha, '' AS TIPODOC, 'DOCUMENTOS CREDITO' AS GRUPO  FROM ventas " & _
            "where tipo='01' AND estatus='0' and condicion_pago='CREDITO' " + xfil & _
            "UNION " & _
            "SELECT documento,TOTAL,serie, nombre, ci_rif, fecha, CASE TIPO WHEN '01' THEN 'VENTA' " & _
            "WHEN '03' THEN 'NOTA CREDITO' END AS TIPODOC, 'DOCUMENTOS ANULADOS' as GRUPO FROM ventas where tipo IN ('01','03') and estatus='1' " + xfil

            xsql_1 += xfil + " group by TIPO,SERIE order by GRUPO DESC, SERIE"
            xsql_3 += xfil + " group by condicion_pago"
            xsql_4 += " ORDER BY GRUPO DESC, fecha, documento"
            xsql_5 += xfil_1 + " GROUP BY CMP.NOMBRE, CMP.ESTATUS"

            g_MiData.F_GetData(xsql, tb1)
            g_MiData.F_GetData(xsql_1, tb2)
            g_MiData.F_GetData(xsql_3, tb4)
            g_MiData.F_GetData(xsql_4, tb5)
            g_MiData.F_GetData(xsql_5, tb6)

            xds.Tables.Add(tb1)
            xds.Tables.Add(tb2)
            xds.Tables.Add(tb4)
            xds.Tables.Add(tb5)
            xds.Tables.Add(tb6)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "VEN_CUADRO_RESUMEN.rpt"

            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(New _Reportes.ParamtCrystal("@fecha_i", Me.MF_I.Value))
            If Me.MF_I.Checked Then
                xlist.Add(New _Reportes.ParamtCrystal("@fecha_f", Me.MF_F.Value))
            Else
                xlist.Add(New _Reportes.ParamtCrystal("@fecha_f", Me.MF_I.Value))
            End If

            Dim xficha As New _Reportes(xds, xrep, xlist)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class REP_ESTADISTICA_VENTAS_MENSUAL
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        CB_3.Enabled = False

        LB_1.Text = "Estadisticas Ventas Mensuales"
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = False
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False

        With Me.CHK_8
            .Select()
            .Focus()
            .Checked = True
            .Enabled = False
        End With
        Me.MF_I.ShowCheckBox = False
        Me.MF_F.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xp1 As New SqlParameter("@fecha1", Me.MF_I.Value.Date)
            Dim xp2 As New SqlParameter("@fecha2", Me.MF_F.Value.Date)

            Dim xsql_1 As String = "select sum(vd.total*vd.signo) as total," & _
                " sum(vd.utilidad*vd.signo)as ganancia," & _
                " month(vd.fecha) as mes, YEAR (vd.fecha) as ano " & _
                " from ventas_detalle as vd join ventas v on v.auto=vd.auto_documento" & _
                " where vd.fecha>=@fecha1 and vd.fecha<=@fecha2  and (v.tipo= '01' or v.tipo='03') and v.estatus = '0' " & _
                " group by month(vd.fecha) ,YEAR (vd.fecha)" & _
                " order by month(vd.fecha) asc, year (vd.fecha) "
            Dim xsql_2 As String = "select nombre, rif from empresa"

            Dim xds As New DataSet
            Dim xtb1 As New DataTable("ventas_mes")
            Dim xtb2 As New DataTable("Empresa")
            g_MiData.F_GetData(xsql_1, xtb1, xp1, xp2)
            g_MiData.F_GetData(xsql_2, xtb2)
            xds.Tables.Add(xtb1)
            xds.Tables.Add(xtb2)

            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xlist.Add(New _Reportes.ParamtCrystal("@fecha_i", Me.MF_I.Value))
            xlist.Add(New _Reportes.ParamtCrystal("@fecha_f", Me.MF_F.Value))
            xrep += "ESTADISTICA_VENTAS_MENSUAL.rpt"

            Dim xficha As New _Reportes(xds, xrep, xlist)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class REP_ESTADISTICA_VENTAS_DEPARTAMENTOS
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        CB_3.Enabled = False

        LB_1.Text = "Estadisticas Ventas x Departamentos"
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = False
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False

        With Me.CHK_8
            .Select()
            .Focus()
            .Checked = True
            .Enabled = False
        End With
        Me.MF_I.ShowCheckBox = False
        Me.MF_F.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xp1 As New SqlParameter("@fecha1", Me.MF_I.Value.Date)
            Dim xp2 As New SqlParameter("@fecha2", Me.MF_F.Value.Date)

            Dim xsql_1 As String = "select pd.nombre as departamento, sum(vd.total*vd.signo) as total," & _
                " sum(vd.utilidad*vd.signo)as ganancia " & _
                " from ventas_detalle as vd join ventas as v on v.auto=vd.auto_documento " & _
                " join productos_departamento as pd on vd.auto_departamento = pd.auto " & _
                " where vd.fecha>=@fecha1 and vd.fecha<=@fecha2 and (v.tipo= '01' or v.tipo='03') and v.estatus = '0' " & _
                " group by pd.nombre order by ganancia desc, pd.nombre"
            Dim xsql_2 As String = "select nombre, rif from empresa"

            Dim xds As New DataSet
            Dim xtb1 As New DataTable("ventas_mes")
            Dim xtb2 As New DataTable("Empresa")
            g_MiData.F_GetData(xsql_1, xtb1, xp1, xp2)
            g_MiData.F_GetData(xsql_2, xtb2)
            xds.Tables.Add(xtb1)
            xds.Tables.Add(xtb2)

            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xlist.Add(New _Reportes.ParamtCrystal("@fecha_i", Me.MF_I.Value))
            xlist.Add(New _Reportes.ParamtCrystal("@fecha_f", Me.MF_F.Value))
            xrep += "ESTADISTICA_VENTAS_DEPART.rpt"

            Dim xficha As New _Reportes(xds, xrep, xlist)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class REP_ESTADISTICA_VENTAS_GRUPOS
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        CB_3.Enabled = False

        LB_1.Text = "Estadisticas Ventas x Grupos"
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = False
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False

        With Me.CHK_8
            .Select()
            .Focus()
            .Checked = True
            .Enabled = False
        End With
        Me.MF_I.ShowCheckBox = False
        Me.MF_F.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xp1 As New SqlParameter("@fecha1", Me.MF_I.Value.Date)
            Dim xp2 As New SqlParameter("@fecha2", Me.MF_F.Value.Date)

            Dim xsql_1 As String = "select vd.auto_grupo as Agrupo, vd.auto_subgrupo as Asubgrupo, vd.nombre as producto, " & _
            "sum(vd.total*vd.signo) as total, sum(vd.utilidad*vd.signo) as ganancia , SUM(vd.cantidad_inventario) as cant, " & _
            "'' GRUPO, '' SUBGRUPO " & _
            "from ventas_detalle vd join ventas v on v.auto=vd.auto_documento where vd.fecha>=@fecha1 and vd.fecha<=@fecha2 and (v.tipo= '01' OR v.TIPO='03') and v.estatus = '0' " & _
            "group by vd.auto_grupo, vd.auto_subgrupo, vd.nombre order by ganancia DESC, grupo, subgrupo "
            Dim xsql_2 As String = "select nombre, rif from empresa"

            Dim xds As New DataSet
            Dim xtb1 As New DataTable("ventas_mes")
            Dim xtb2 As New DataTable("Empresa")
            g_MiData.F_GetData(xsql_1, xtb1, xp1, xp2)
            g_MiData.F_GetData(xsql_2, xtb2)

            Dim x1 As New SqlParameter
            Dim x2 As New SqlParameter
            For Each dr As DataRow In xtb1.Rows
                x1 = New SqlParameter("@auto", dr("Agrupo").ToString.Trim)
                dr("grupo") = DataSistema.MiDataSistema.DataSistema.F_GetString("select nombre from productos_grupo where auto=@auto", x1)

                x2 = New SqlParameter("@auto", dr("Asubgrupo").ToString.Trim)
                dr("subgrupo") = DataSistema.MiDataSistema.DataSistema.F_GetString("select nombre from productos_subgrupo where auto=@auto", x2)
            Next

            xds.Tables.Add(xtb1)
            xds.Tables.Add(xtb2)

            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xlist.Add(New _Reportes.ParamtCrystal("@fecha_i", Me.MF_I.Value))
            xlist.Add(New _Reportes.ParamtCrystal("@fecha_f", Me.MF_F.Value))
            xrep += "ESTADISTICA_VENTAS_GRUPO.rpt"

            Dim xficha As New _Reportes(xds, xrep, xlist)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class REP_ESTADISTICA_ANALISIS_DOCUMENTOS
    Implements IPlantillaFiltroReportesVentas

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

    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVentas.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_SERIES", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FACTURA", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_NC", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_PEDIDO", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_NE", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_PRESUPUESTO", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_SERIES", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_DETALLADO", True)(0)

        CB_3.Enabled = False

        LB_1.Text = "Estadisticas Analisis De Documentos"
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = False
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False

        With Me.CHK_8
            .Select()
            .Focus()
            .Checked = True
            .Enabled = False
        End With
        Me.MF_I.ShowCheckBox = False
        Me.MF_F.ShowCheckBox = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xp1 As New SqlParameter("@fecha1", Me.MF_I.Value)
            Dim xp2 As New SqlParameter("@fecha2", Me.MF_F.Value)

            Dim xsql_1 As String = "select v.documento as doc, v.fecha as fecha , v.nombre as nombre , v.ci_rif as rif , v.dias_validez as DiasValidez," & _
            "v.tipo as tipo , case v.tipo when '04' then 'NOTA ENTREGA' WHEN '05' THEN 'PRESUPUESTO' WHEN '06' THEN 'PEDIDO' END AS TipoDoc," & _
            "v.total as total ,v.condicion_pago as condicion , v.bloquear_almacen as AlmacenBloqueado , " & _
            "case v.bloquear_almacen when '1' then 'Si' else 'No' end as Bloquear , " & _
            "v.estatus, case v.estatus when '2' then 'PROCESADO' ELSE 'NO PROCESADO' end as procesado " & _
            "from ventas v where v.fecha>=@fecha1 and v.fecha<=@fecha2 and v.tipo in ('04','05','06') and v.estatus in ('0','2') " & _
            "order by tipo, documento"
            Dim xsql_2 As String = "select nombre, rif from empresa"

            Dim xds As New DataSet
            Dim xtb1 As New DataTable("AnalisiDoc")
            Dim xtb2 As New DataTable("Empresa")
            g_MiData.F_GetData(xsql_1, xtb1, xp1, xp2)
            g_MiData.F_GetData(xsql_2, xtb2)

            xds.Tables.Add(xtb1)
            xds.Tables.Add(xtb2)

            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xlist.Add(New _Reportes.ParamtCrystal("@fecha_i", Me.MF_I.Value))
            xlist.Add(New _Reportes.ParamtCrystal("@fecha_f", Me.MF_F.Value))
            xrep += "ANALISIS_DOC_VENTAS.rpt"

            Dim xficha As New _Reportes(xds, xrep, xlist)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class
