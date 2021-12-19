Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports System.Data.SqlClient

Public Class PlantillaFiltroReporteCompras
    Dim xplantilla As IPlantillaFiltroReportesCompras
    Dim meses As String() = {"ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC"}

    Dim xtb_proveedor As DataTable
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
        xtb_proveedor = New DataTable
        g_MiData.F_GetData("select nombre,auto from proveedores order by nombre", xtb_proveedor)
        With Me.MCB_PROVEEDOR
            .DataSource = xtb_proveedor
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        Me.MCB_MES.DataSource = meses
        Me.MCB_MES.SelectedIndex = Month(Date.Today) - 1

        With Me.N_ANO
            .Minimum = 2000
            .Maximum = 2100
            .Value = Year(Date.Today)
        End With
    End Sub

    Sub Inicializa()
        Try
            ApagarControles()
            CargarData()
            _MiPLantilla.Inicializa(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ApagarControles()
        Me.MCB_PROVEEDOR.Enabled = False
        Me.MCB_MES.Enabled = False
        Me.N_ANO.Enabled = False
        Me.MF_DESDE.Enabled = False
        Me.MF_HASTA.Enabled = False
    End Sub

    Private Sub MCHB_FECHA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_FECHA.CheckedChanged
        Me.MF_DESDE.Enabled = MCHB_FECHA.Checked
        Me.MF_HASTA.Enabled = MCHB_FECHA.Checked

        Me.MCHB_PERIODO.Checked = Not MCHB_FECHA.Checked
        Me.MCB_MES.Enabled = Not MCHB_FECHA.Checked
        Me.N_ANO.Enabled = Not MCHB_FECHA.Checked
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

    Property _MiPLantilla() As IPlantillaFiltroReportesCompras
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantillaFiltroReportesCompras)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaFiltroReportesCompras)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiPLantilla = xplantilla
    End Sub

    Private Sub PlantillaFiltroReporteVentas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub MCHB_CLIENTE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCHB_PROVEEDOR.Click
        Me.MCB_PROVEEDOR.Enabled = MCHB_PROVEEDOR.Checked
    End Sub

    Private Sub MCHB_PERIODO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCHB_PERIODO.CheckedChanged
        Me.MCB_MES.Enabled = MCHB_PERIODO.Checked
        Me.N_ANO.Enabled = MCHB_PERIODO.Checked

        Me.MF_DESDE.Checked = Not Me.MCHB_PERIODO.Checked
        Me.MF_HASTA.Checked = Not Me.MCHB_PERIODO.Checked
        Me.MCHB_FECHA.Checked = Not Me.MCHB_PERIODO.Checked
    End Sub

    Private Sub BT_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_1.Click

    End Sub
End Class

Public Interface IPlantillaFiltroReportesCompras
    Sub Inicializa(ByVal xform As Object)
End Interface

Public Class ReporteCompras_LibroCompras
    Implements IPlantillaFiltroReportesCompras

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas
    WithEvents MT_1 As MisComboBox
    WithEvents MT_2 As NumericUpDown
    WithEvents CB_1 As MisComboBox

    Dim xini As Date = Date.Today
    Dim xfin As Date = Date.Today

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCompras.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_PERIODO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)

        MT_1 = _MiFormulario.Controls.Find("MCB_MES", True)(0)
        MT_2 = _MiFormulario.Controls.Find("N_ANO", True)(0)

        LB_1.Text = "Libro De Compras"

        Me.CHK_1.Enabled = False
        Me.CHK_2.Select()
        Me.CHK_2.Focus()
        Me.CHK_3.Checked = True
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "where tipo in ('01','02','03') and estatus='0' "

            If Me.CHK_1.Checked Then
                xfil += " and AUTO_ENTIDAD='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                Dim xm As String = (Me.MT_1.SelectedIndex + 1).ToString.Trim.PadLeft(2, "0")
                xfil += " and mes_relacion='" + xm + "'"
                xfil += " and ano_relacion='" + Me.MT_2.Value.ToString + "'"

                Dim dias As Long = 0
                xini = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, 1)
                xfin = DateAdd(DateInterval.Month, 1, xini)
                dias = DateDiff(DateInterval.Day, xini, xfin)
                xfin = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, dias)
            End If

            If CHK_3.Checked And (Me.MF_I.Checked Or Me.MF_F.Checked) Then
                If Me.MF_I.Checked Then
                    xini = Me.MF_I.r_Valor
                Else
                    Dim xfecha As Date = F_GetDate("select getdate()").Date
                    xini = New Date(Year(xfecha), Month(xfecha), 1)
                End If
                xfil += " and fecha>='" + xini.ToShortDateString + "'"

                If Me.MF_F.Checked Then
                    xfin = Me.MF_F.r_Valor
                Else
                    xfin = Date.Today
                End If
                xfil += " and fecha<='" + xfin.ToShortDateString + "'"
            Else
                If Me.CHK_2.Checked = False Then
                    Throw New Exception("ERROR... DEBE SELECCIONAR UN RANGO DE FECHA")
                End If
            End If

            xsql += xfil
            VisualizarReportesComprasLibroCompras(xsql)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesComprasLibroCompras(ByVal xcondicion As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("compra")
        Dim dtb_empresa As New DataTable("empresa")

        Dim xfecha_ini As Date = g_MiData.p_FechaDelMotorBD
        Dim xfecha_fin As Date = g_MiData.p_FechaDelMotorBD

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                   "from empresa"

            Dim xsql_2 As String = "select * " & _
                                   "from ( " & _
                                        "select nombre " & _
                                            ", ci_rif" & _
                                            ", documento" & _
                                            ", fecha" & _
                                            ", comprobante_retencion" & _
                                            ", anticipo_iva_importacion" & _
                                            ", retencion_iva_terceros" & _
                                            ", planilla_importacion" & _
                                            ", expediente" & _
                                            ", round(tasa_retencion_iva * impuesto1/100 ,2) retencion_iva" & _
                                            ", impuesto1 impuesto" & _
                                            ", tasa1 tasa" & _
                                            ", aplica" & _
                                            ", control" & _
                                            ", tipo" & _
                                            ", exento " & _
                                            ", base1 base " & _
                                            ", (case tipo when '03' then -1 else 1 end) signo, n_montoimplicor lisayea " & _
                                         "from compras " & _
                                         xcondicion + " and impuesto1<>0 " & _
                                         "union " & _
                                         "select nombre " & _
                                            ", ci_rif" & _
                                            ", documento" & _
                                            ", fecha" & _
                                            ", comprobante_retencion" & _
                                            ", anticipo_iva_importacion" & _
                                            ", retencion_iva_terceros" & _
                                            ", planilla_importacion" & _
                                            ", expediente" & _
                                            ", round(tasa_retencion_iva * impuesto2/100 ,2) retencion_iva" & _
                                            ", impuesto2 impuesto" & _
                                            ", tasa2 tasa" & _
                                            ", aplica" & _
                                            ", control" & _
                                            ", tipo" & _
                                            ", (case when impuesto1 <>0 then 0 else exento end) exento" & _
                                            ", base2 base " & _
                                            ", (case tipo when '03' then -1 else 1 end) signo, n_montoimplicor lisayea " & _
                                         "from compras " & _
                                         xcondicion + " and impuesto2<>0 " & _
                                         "union " & _
                                         "select nombre " & _
                                            ", ci_rif" & _
                                            ", documento" & _
                                            ", fecha" & _
                                            ", comprobante_retencion" & _
                                            ", anticipo_iva_importacion" & _
                                            ", retencion_iva_terceros" & _
                                            ", planilla_importacion" & _
                                            ", expediente" & _
                                            ", round(tasa_retencion_iva * impuesto3/100 ,2) retencion_iva" & _
                                            ", impuesto3 impuesto" & _
                                            ", tasa3 tasa" & _
                                            ", aplica" & _
                                            ", control" & _
                                            ", tipo" & _
                                            ", (case when impuesto1 <>0 then 0 else exento end) exento" & _
                                            ", base3 base " & _
                                            ", (case tipo when '03' then -1 else 1 end) signo, n_montoimplicor lisayea " & _
                                         "from compras " & _
                                         xcondicion + " and impuesto3<>0 " & _
                                         "union " & _
                                         "select nombre " & _
                                            ", ci_rif" & _
                                            ", documento" & _
                                            ", fecha" & _
                                            ", comprobante_retencion" & _
                                            ", anticipo_iva_importacion" & _
                                            ", retencion_iva_terceros" & _
                                            ", planilla_importacion" & _
                                            ", expediente" & _
                                            ", 0 retencion_iva" & _
                                            ", impuesto2 impuesto" & _
                                            ", 0.00 tasa" & _
                                            ", aplica" & _
                                            ", control" & _
                                            ", tipo" & _
                                            ", exento" & _
                                            ", 0 base " & _
                                            ", (case tipo when '03' then -1 else 1 end) signo, n_montoimplicor lisayea " & _
                                         "from compras " & _
                                         xcondicion + " and impuesto1=0 and impuesto2=0 and impuesto3=0) T " & _
                                    "order by t.fecha, t.documento, t.tasa desc"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql_2, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                If IsDBNull(xrow("lisayea")) Then
                    xrow("exento") = Decimal.Round(xrow("exento") * xrow("signo"), 2, MidpointRounding.AwayFromZero)
                Else
                    xrow("exento") = Decimal.Round((xrow("exento") + xrow("lisayea")) * xrow("signo"), 2, MidpointRounding.AwayFromZero)
                End If
                xrow("base") = Decimal.Round(xrow("base") * xrow("signo"), 2, MidpointRounding.AwayFromZero)
                xrow("impuesto") = Decimal.Round(xrow("impuesto") * xrow("signo"), 2, MidpointRounding.AwayFromZero)
                xrow("retencion_iva") = Decimal.Round(xrow("retencion_iva") * xrow("signo"), 2, MidpointRounding.AwayFromZero)
                xrow("retencion_iva_terceros") = Decimal.Round(xrow("retencion_iva_terceros") * xrow("signo"), 2, MidpointRounding.AwayFromZero)
                xrow("anticipo_iva_importacion") = Decimal.Round(xrow("anticipo_iva_importacion") * xrow("signo"), 2, MidpointRounding.AwayFromZero)
            Next

            xfecha_ini = xini
            xfecha_fin = xfin
            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)
            If dts.Tables("compra").Rows.Count > 0 Then
            Else
                Throw New Exception("DISCULPE NO HAY INFORMACIÓN PARA MOSTRAR")
            End If

            Dim xp1 As New _Reportes.ParamtCrystal("@FECHA_I", xfecha_ini)
            Dim xp2 As New _Reportes.ParamtCrystal("@FECHA_F", xfecha_fin)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xp1)
            xlist.Add(xp2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "RPT_LIBRO_COMPRAS.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

Public Class ReporteCompras_General
    Implements IPlantillaFiltroReportesCompras

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas
    WithEvents MT_1 As MisComboBox
    WithEvents MT_2 As NumericUpDown
    WithEvents CB_1 As MisComboBox

    Dim xini As Date = Date.Today
    Dim xfin As Date = Date.Today

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCompras.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_PERIODO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        MT_1 = _MiFormulario.Controls.Find("MCB_MES", True)(0)
        MT_2 = _MiFormulario.Controls.Find("N_ANO", True)(0)

        LB_1.Text = "Reporte General De Documentos De Compra"
        Me.CHK_1.Select()
        Me.CHK_1.Focus()
        Me.CHK_3.Checked = True
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select *, (case tipo when '03' then -1 else 1 end) signo  " & _
                                 "from compras where tipo in ('01','02','03') and estatus='0' "

            If Me.CHK_1.Checked Then
                xfil += " and AUTO_ENTIDAD='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                Dim xm As String = (Me.MT_1.SelectedIndex + 1).ToString.Trim.PadLeft(2, "0")
                xfil += " and mes_relacion='" + xm + "'"
                xfil += " and ano_relacion='" + Me.MT_2.Value.ToString + "'"

                Dim dias As Long = 0
                xini = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, 1)
                xfin = DateAdd(DateInterval.Month, 1, xini)
                dias = DateDiff(DateInterval.Day, xini, xfin)
                xfin = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, dias)
            End If

            If CHK_3.Checked And (Me.MF_I.Checked Or Me.MF_F.Checked) Then
                If Me.MF_I.Checked Then
                    xini = Me.MF_I.r_Valor
                Else
                    Dim xfecha As Date = F_GetDate("select getdate()").Date
                    xini = New Date(Year(xfecha), Month(xfecha), 1)
                End If
                xfil += " and fecha>='" + xini.ToShortDateString + "'"

                If Me.MF_F.Checked Then
                    xfin = Me.MF_F.r_Valor
                Else
                    xfin = Date.Today
                End If
                xfil += " and fecha<='" + xfin.ToShortDateString + "'"
            Else
                If Me.CHK_2.Checked = False Then
                    Throw New Exception("ERROR... DEBE SELECCIONAR UN RANGO DE FECHA")
                End If
            End If

            xsql += xfil + " order by fecha desc"
            VisualizarReportesComprasGeneral(xsql)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesComprasGeneral(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("compra")
        Dim dtb_empresa As New DataTable("empresa")

        Dim xfecha_ini As Date = g_MiData.p_FechaDelMotorBD
        Dim xfecha_fin As Date = g_MiData.p_FechaDelMotorBD
        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                   "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                If IsDBNull(xrow("n_montoimplicor")) Then
                    xrow("exento") = Decimal.Round(xrow("exento") * xrow("signo"), 2, MidpointRounding.AwayFromZero)
                Else
                    xrow("exento") = Decimal.Round((xrow("exento") + xrow("n_montoimplicor")) * xrow("signo"), 2, MidpointRounding.AwayFromZero)
                End If
                xrow("base") = Decimal.Round(xrow("base") * xrow("signo"), 2, MidpointRounding.AwayFromZero)
                xrow("impuesto") = Decimal.Round(xrow("impuesto") * xrow("signo"), 2, MidpointRounding.AwayFromZero)
            Next

            xfecha_ini = xini
            xfecha_fin = xfin
            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)
            If dts.Tables("compra").Rows.Count > 0 Then
            Else
                Throw New Exception("DISCULPE NO HAY INFORMACIÓN PARA MOSTRAR")
            End If

            Dim xp1 As New _Reportes.ParamtCrystal("@FECHA_I", xini)
            Dim xp2 As New _Reportes.ParamtCrystal("@FECHA_F", xfin)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xp1)
            xlist.Add(xp2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "RPT_COMPRAS_GENERAL.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

Public Class ReporteCompras_GeneralDepartamento
    Implements IPlantillaFiltroReportesCompras

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas
    WithEvents MT_1 As MisComboBox
    WithEvents MT_2 As NumericUpDown
    WithEvents CB_1 As MisComboBox

    Dim xini As Date = Date.Today
    Dim xfin As Date = Date.Today

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCompras.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_PERIODO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        MT_1 = _MiFormulario.Controls.Find("MCB_MES", True)(0)
        MT_2 = _MiFormulario.Controls.Find("N_ANO", True)(0)

        LB_1.Text = "Reporte General De Documentos De Compras Por Departamento"
        Me.CHK_1.Select()
        Me.CHK_1.Focus()
        Me.CHK_3.Checked = True
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select c.fecha,d.nombre departamento,sum(c.cantidad*c.signo) as cantidad, sum(c.total_neto*c.signo) as costo " & _
                                 "from compras inner join compras_detalle c on compras.auto=c.auto_documento inner join productos_departamento d on c.auto_departamento=d.auto " & _
                                 "where c.tipo in ('01','02','03') and c.estatus='0' "

            If Me.CHK_1.Checked Then
                xfil += " and c.AUTO_ENTIDAD='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                Dim xm As String = (Me.MT_1.SelectedIndex + 1).ToString.Trim.PadLeft(2, "0")
                xfil += " and compras.mes_relacion='" + xm + "'"
                xfil += " and compras.ano_relacion='" + Me.MT_2.Value.ToString + "'"

                Dim dias As Long = 0
                xini = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, 1)
                xfin = DateAdd(DateInterval.Month, 1, xini)
                dias = DateDiff(DateInterval.Day, xini, xfin)
                xfin = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, dias)
            End If

            If CHK_3.Checked And (Me.MF_I.Checked Or Me.MF_F.Checked) Then
                If Me.MF_I.Checked Then
                    xini = Me.MF_I.r_Valor
                Else
                    Dim xfecha As Date = F_GetDate("select getdate()").Date
                    xini = New Date(Year(xfecha), Month(xfecha), 1)
                End If
                xfil += " and c.fecha>='" + xini.ToShortDateString + "'"

                If Me.MF_F.Checked Then
                    xfin = Me.MF_F.r_Valor
                Else
                    xfin = Date.Today
                End If
                xfil += " and c.fecha<='" + xfin.ToShortDateString + "'"
            Else
                If Me.CHK_2.Checked = False Then
                    Throw New Exception("ERROR... DEBE SELECCIONAR UN RANGO DE FECHA")
                End If
            End If

            xsql += xfil + " group by c.fecha,d.nombre order by c.fecha desc"
            VisualizarReportesComprasGeneralDepartamento(xsql)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesComprasGeneralDepartamento(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("Compras_Deparamento")
        Dim dtb_empresa As New DataTable("empresa")

        Dim xfecha_ini As Date = g_MiData.p_FechaDelMotorBD
        Dim xfecha_fin As Date = g_MiData.p_FechaDelMotorBD

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                   "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            If dts.Tables("Compras_Deparamento").Rows.Count > 0 Then
                xfecha_ini = dts.Tables("Compras_Deparamento").Compute("min(fecha)", "")
                xfecha_fin = dts.Tables("Compras_Deparamento").Compute("max(fecha)", "")
            Else
                Throw New Exception("DISCULPE NO HAY INFORMACIÓN PARA MOSTRAR")
            End If

            Dim xp1 As New _Reportes.ParamtCrystal("@FECHA_I", xini)
            Dim xp2 As New _Reportes.ParamtCrystal("@FECHA_F", xfin)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xp1)
            xlist.Add(xp2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "RPT_COMPRAS_GENERAL_DEPARTAMENTOS.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

Public Class ReporteCompras_GeneralGrupo
    Implements IPlantillaFiltroReportesCompras

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas
    WithEvents MT_1 As MisComboBox
    WithEvents MT_2 As NumericUpDown
    WithEvents CB_1 As MisComboBox

    Dim xini As Date = Date.Today
    Dim xfin As Date = Date.Today

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCompras.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_PERIODO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        MT_1 = _MiFormulario.Controls.Find("MCB_MES", True)(0)
        MT_2 = _MiFormulario.Controls.Find("N_ANO", True)(0)

        LB_1.Text = "Reporte General De Documentos De Compras Por Grupo"
        Me.CHK_1.Select()
        Me.CHK_1.Focus()
        Me.CHK_3.Checked = True
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select c.nombre producto,sum(c.cantidad*c.signo) as cantidad, sum(c.total_neto*c.signo) as costo, g.nombre as grupo " & _
                                 "from compras inner join compras_detalle c on compras.auto=c.auto_documento inner join productos_grupo g on c.auto_grupo=g.auto " & _
                                 "where c.tipo in ('01','02','03') and c.estatus='0' "

            Dim xsql_1 As String = "from compras inner join compras_detalle c on compras.auto=c.auto_documento inner join productos_grupo g on c.auto_grupo=g.auto " & _
                                   "where c.tipo in ('01','02','03') and c.estatus='0' "

            If Me.CHK_1.Checked Then
                xfil += " and c.AUTO_ENTIDAD='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                Dim xm As String = (Me.MT_1.SelectedIndex + 1).ToString.Trim.PadLeft(2, "0")
                xfil += " and compras.mes_relacion='" + xm + "'"
                xfil += " and compras.ano_relacion='" + Me.MT_2.Value.ToString + "'"

                Dim dias As Long = 0
                xini = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, 1)
                xfin = DateAdd(DateInterval.Month, 1, xini)
                dias = DateDiff(DateInterval.Day, xini, xfin)
                xfin = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, dias)
            End If

            If CHK_3.Checked And (Me.MF_I.Checked Or Me.MF_F.Checked) Then
                If Me.MF_I.Checked Then
                    xini = Me.MF_I.r_Valor
                Else
                    Dim xfecha As Date = F_GetDate("select getdate()").Date
                    xini = New Date(Year(xfecha), Month(xfecha), 1)
                End If
                xfil += " and compras.fecha>='" + xini.ToShortDateString + "'"

                If Me.MF_F.Checked Then
                    xfin = Me.MF_F.r_Valor
                Else
                    xfin = Date.Today
                End If
                xfil += " and compras.fecha<='" + xfin.ToShortDateString + "'"
            Else
                If Me.CHK_2.Checked = False Then
                    Throw New Exception("ERROR... DEBE SELECCIONAR UN RANGO DE FECHA")
                End If
            End If

            xsql += xfil + " group by g.nombre, c.nombre order by g.nombre, c.nombre desc"
            xsql_1 += xfil

            VisualizarReportesComprasGeneralGrupos(xsql, xsql_1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesComprasGeneralGrupos(ByVal xsql As String, ByVal xsql1 As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("Compras_Grupos")
        Dim dtb_empresa As New DataTable("empresa")

        Dim xfecha_ini As Date = g_MiData.p_FechaDelMotorBD
        Dim xfecha_fin As Date = g_MiData.p_FechaDelMotorBD

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                   "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            If dts.Tables("Compras_Grupos").Rows.Count > 0 Then
                xfecha_ini = F_GetDate("select min(c.fecha) " + xsql1)
                xfecha_fin = F_GetDate("select max(c.fecha) " + xsql1)
            Else
                Throw New Exception("DISCULPE NO HAY INFORMACIÓN PARA MOSTRAR")
            End If

            Dim xp1 As New _Reportes.ParamtCrystal("@FECHA_I", xini)
            Dim xp2 As New _Reportes.ParamtCrystal("@FECHA_F", xfin)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xp1)
            xlist.Add(xp2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "RPT_COMPRAS_GENERAL_GRUPOS.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

Public Class ReporteCompras_RetencionesIva
    Implements IPlantillaFiltroReportesCompras

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas
    WithEvents MT_1 As MisComboBox
    WithEvents MT_2 As NumericUpDown
    WithEvents CB_1 As MisComboBox

    Dim xini As Date = Date.Today
    Dim xfin As Date = Date.Today

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCompras.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_PERIODO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        MT_1 = _MiFormulario.Controls.Find("MCB_MES", True)(0)
        MT_2 = _MiFormulario.Controls.Find("N_ANO", True)(0)

        LB_1.Text = "Reporte De Retenciones Iva En Compras"
        Me.CHK_1.Select()
        Me.CHK_1.Focus()
        Me.CHK_3.Checked = True
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim Sel As String = "select r.documento" & _
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
            "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto " & _
            "where r.auto<>'' and r.estatus='0' " 

            If Me.CHK_1.Checked Then
                xfil += " and r.AUTO_ENTIDAD='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                Dim xm As String = (Me.MT_1.SelectedIndex + 1).ToString.Trim.PadLeft(2, "0")
                xfil += " and r.mes_relacion='" + xm + "'"
                xfil += " and r.ano_relacion='" + Me.MT_2.Value.ToString + "'"

                Dim dias As Long = 0
                xini = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, 1)
                xfin = DateAdd(DateInterval.Month, 1, xini)
                dias = DateDiff(DateInterval.Day, xini, xfin)
                xfin = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, dias)
            End If

            If CHK_3.Checked And (Me.MF_I.Checked Or Me.MF_F.Checked) Then
                If Me.MF_I.Checked Then
                    xini = Me.MF_I.r_Valor
                Else
                    Dim xfecha As Date = F_GetDate("select getdate()").Date
                    xini = New Date(Year(xfecha), Month(xfecha), 1)
                End If
                xfil += " and r.fecha>='" + xini.ToShortDateString + "'"

                If Me.MF_F.Checked Then
                    xfin = Me.MF_F.r_Valor
                Else
                    xfin = Date.Today
                End If
                xfil += " and r.fecha<='" + xfin.ToShortDateString + "'"
            Else
                If Me.CHK_2.Checked = False Then
                    Throw New Exception("ERROR... DEBE SELECCIONAR UN RANGO DE FECHA")
                End If
            End If


            Sel += xfil + _
                " group by  r.fecha" & _
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
                "  order by r.fecha desc"

            VisualizarAllRet_Compras(Sel)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ReporteCompras_Concepto
    Implements IPlantillaFiltroReportesCompras

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas
    WithEvents MT_1 As MisComboBox
    WithEvents MT_2 As NumericUpDown
    WithEvents CB_1 As MisComboBox

    Dim xini As Date = Date.Today
    Dim xfin As Date = Date.Today

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCompras.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_PERIODO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        MT_1 = _MiFormulario.Controls.Find("MCB_MES", True)(0)
        MT_2 = _MiFormulario.Controls.Find("N_ANO", True)(0)

        LB_1.Text = "Reporte Por Conceptos"
        Me.CHK_1.Enabled = False
        Me.CHK_2.Select()
        Me.CHK_2.Focus()
        Me.CHK_3.Checked = True
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet

            If Me.CHK_2.Checked Then
                Dim xm As String = (Me.MT_1.SelectedIndex + 1).ToString.Trim.PadLeft(2, "0")
                xfil += " and mes_relacion='" + xm + "'"
                xfil += " and ano_relacion='" + Me.MT_2.Value.ToString + "'"

                Dim dias As Long = 0
                xini = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, 1)
                xfin = DateAdd(DateInterval.Month, 1, xini)
                dias = DateDiff(DateInterval.Day, xini, xfin)
                xfin = New Date(Me.MT_2.Value, Me.MT_1.SelectedIndex + 1, dias)
            End If

            If CHK_3.Checked And (Me.MF_I.Checked Or Me.MF_F.Checked) Then
                If Me.MF_I.Checked Then
                    xini = Me.MF_I.r_Valor
                Else
                    Dim xfecha As Date = F_GetDate("select getdate()").Date
                    xini = New Date(Year(xfecha), Month(xfecha), 1)
                End If
                xfil += " and fecha>='" + xini.ToShortDateString + "'"

                If Me.MF_F.Checked Then
                    xfin = Me.MF_F.r_Valor
                Else
                    xfin = Date.Today
                End If
                xfil += " and fecha<='" + xfin.ToShortDateString + "'"
            Else
                If Me.CHK_2.Checked = False Then
                    Throw New Exception("ERROR... DEBE SELECCIONAR UN RANGO DE FECHA")
                End If
            End If

            Dim xsql As String = "with c1 as ( select total, case tipo when '03' then -1 else 1 end signo, n_concepto_gasto from compras " & _
                                 "where tipo in ('01','02','03') " + xfil + ") select SUM(total*signo) total , n_concepto_gasto concepto ,COUNT(*) cant " & _
                                 "from c1 group by n_concepto_gasto "

            VisualizarReportes(xsql)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarReportes(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("Compras_Conceptos")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                   "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xp1 As New _Reportes.ParamtCrystal("@FECHA_I", xini)
            Dim xp2 As New _Reportes.ParamtCrystal("@FECHA_F", xfin)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xp1)
            xlist.Add(xp2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "RPT_COMPRAS_CONCEPTO.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function
End Class
