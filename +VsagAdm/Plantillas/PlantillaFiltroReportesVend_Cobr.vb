Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports System.Data.SqlClient

Public Class PlantillaFiltroReportesVend_Cobr
    Dim xplantilla As IPlantillaFiltroReportesVend_Cobr

    Dim tipo_comision As String() = {"Sin Comision", "Comision Global", "Comision Rango", "Personalizada"}
    Dim estatus As String() = {"Activo", "Inactivo"}

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
        EstatusSalida = False
    End Sub

    Private Sub PlantillaFiltroReportesCxC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
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

    Sub CargarData()
        With Me.MCB_ESTATUS
            .DataSource = estatus
            .SelectedIndex = 0
        End With

        With Me.MCB_TIPO_COMISION
            .DataSource = tipo_comision
            .SelectedIndex = 0
        End With
    End Sub

    Sub ApagarControles()
        Me.MCB_ESTATUS.Enabled = False
        Me.MCB_TIPO_COMISION.Enabled = False
        Me.MCHB_FECHA.Checked = True
        Me.MF_DESDE.Checked = True
        Me.MF_HASTA.Checked = True
    End Sub

    Private Sub MCHB_ESTATUS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ESTATUS.CheckedChanged
        Me.MCB_ESTATUS.Enabled = MCHB_ESTATUS.Checked
    End Sub

    Private Sub MCHB_TPO_COMISION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_TPO_COMISION.CheckedChanged
        MCB_TIPO_COMISION.Enabled = MCHB_TPO_COMISION.Checked
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

    Property _MiPLantilla() As IPlantillaFiltroReportesVend_Cobr
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantillaFiltroReportesVend_Cobr)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaFiltroReportesVend_Cobr)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiPLantilla = xplantilla
    End Sub
End Class

Public Interface IPlantillaFiltroReportesVend_Cobr
    Sub Inicializa(ByVal xform As Object)
End Interface

'' VENDEDORES

Public Class ReporteVendedores_DatosContacto
    Implements IPlantillaFiltroReportesVend_Cobr

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVend_Cobr.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_TPO_COMISION", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_TIPO_COMISION", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Maestro De Vendedores/Datos De Contacto"

        _MiFormulario.Text = "Reportes De Vendedores"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select *, '' telefono " & _
                                 "from vendedores " & _
                                 "where auto<>'' "

            If Me.CHK_1.Checked Then
                xfil += " and tipo_comision='" + Me.CB_1.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and estatus='" + Me.CB_2.SelectedValue.ToString + "'"
            End If
            If Me.CHK_3.Checked And MF_1.Checked Then
                xfil += " and fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_3.Checked And MF_2.Checked Then
                xfil += " and fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            xsql += xfil + " order by nombre"

            VisualizarReportesVendedoresDatosContacto(xsql)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesVendedoresDatosContacto(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("vendedores")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                Dim xtel As String = ""
                If xrow("telefono1").ToString.Trim <> "" Then
                    xtel = xrow("telefono1")
                End If

                If xrow("telefono2").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("telefono2")
                    Else
                        xtel = xrow("telefono2")
                    End If
                End If

                If xrow("celular1").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("celular1")
                    Else
                        xtel = xrow("celular1")
                    End If
                End If

                If xrow("celular2").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("celular2")
                    Else
                        xtel = xrow("celular2")
                    End If
                End If
                xrow("telefono") = xtel
            Next
            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "VENDEDOR_DATOS_CONTACTO.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

Public Class ReporteVendedores_Comisiones
    Implements IPlantillaFiltroReportesVend_Cobr

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVend_Cobr.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_TPO_COMISION", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_TIPO_COMISION", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Comisiones De Vendedores"

        _MiFormulario.Text = "Reportes De Vendedores"
        CHK_3.Text = "Fecha"
        CHK_3.Enabled = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            If Me.CHK_1.Checked And Me.CB_1.SelectedIndex = 0 Then
                MessageBox.Show("ERROR... NO SE PUEDE MOSTRAR COMISIONES A VENDEDORES QUE NO TIENEN COMISIÓN,VERIFIQUE")
            Else
                Dim xfil As String = ""
                Dim xsql As String = "select vd.*, vn.fecha,vn.documento, (vn.exento+vn.base) importe, " & _
                                     "(case vn.tipo when '01' then 'FACTURA' when '02' then 'NOTA DÉBITO' when '03' then 'NOTA CRÉDITO' end) origen, " & _
                                     "(case vn.tipo when '03' then -1 else 1 end) signo, vn.auto as autodocumento  " & _
                                     "from ventas vn inner join vendedores vd on vn.auto_vendedor=vd.auto " & _
                                     "where vn.estatus='0' and vn.tipo in ('01','02','03') and vd.tipo_comision<>'0' "

                If Me.CHK_1.Checked Then
                    xfil += " and vd.tipo_comision='" + Me.CB_1.SelectedIndex.ToString + "'"
                End If

                If Me.CHK_2.Checked Then
                    xfil += " and vd.estatus='" + Me.CB_2.SelectedValue.ToString + "'"
                End If
                If MF_1.Checked Then
                    xfil += " and vn.fecha>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
                End If

                If MF_2.Checked Then
                    xfil += " and vn.fecha<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
                End If

                xsql += xfil + " order by vd.nombre"


                Dim xsql2 As String = "select vnd.auto_documento as autodocumento , vnd.nombre as DetalleItem  " & _
                                     "from ventas vn inner join vendedores vd on vn.auto_vendedor=vd.auto " & _
                                     "join ventas_detalle as vnd on vnd.auto_documento=vn.auto " & _
                                     "where vn.estatus='0' and vn.tipo in ('01','02','03') and vd.tipo_comision<>'0' "
                xsql2 += xfil + " order by vd.nombre"

                VisualizarReportesVendedoresComisiones(xsql, xsql2, MF_1.r_Valor, MF_2.r_Valor)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesVendedoresComisiones(ByVal xsql As String, ByVal xsql2 As String, ByVal xfecha_ini As Date, ByVal xfecha_fin As Date) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("vendedores")
        Dim dtb_ficha_detalle As New DataTable("vendedoresDetalle")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)
            g_MiData.F_GetData(xsql2, dtb_ficha_detalle)


            For Each xrow In dtb_ficha.Rows
                Select Case xrow("tipo_comision").ToString.Trim
                    Case "1"
                        Dim xcomision As Decimal = 0
                        xcomision = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVendedor._ComisionGlobalAsignada
                        xrow("comision") = xcomision
                        xrow("tipo_Comision") = "Comisión Global"
                    Case "2"
                        Dim xcomision As Decimal = 0
                        Dim xparam1 As New SqlParameter("@importe", xrow("importe"))
                        xcomision = F_GetDecimal("select comision from comisionrango_vendcob where desde<=@importe and hasta>=@importe and tipo='V'", xparam1)
                        xrow("comision") = xcomision
                        xrow("tipo_Comision") = "Comisión Rango"
                    Case "3"
                        xrow("tipo_Comision") = "Comisión Personalizada"
                End Select
            Next
            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)
            dts.Tables.Add(dtb_ficha_detalle)

            Dim xp1 As New _Reportes.ParamtCrystal("@fecha", xfecha_ini)
            Dim xp2 As New _Reportes.ParamtCrystal("@fecha_f", xfecha_fin)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xp1)
            xlist.Add(xp2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "VENDEDOR_COMISIONES.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

Public Class ReporteVendedores_ComisionesVentasDetalle
    Implements IPlantillaFiltroReportesVend_Cobr

    WithEvents xformulario As System.Windows.Forms.Form
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents MF_1 As MisFechas
    WithEvents MF_2 As MisFechas

    Dim LB_1 As Label

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVend_Cobr.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_TPO_COMISION", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_TIPO_COMISION", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Comisiones Por Ventas Detalle"

        _MiFormulario.Text = "Reportes De Vendedores"
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = False

        CHK_3.Text = "Fecha"
        CHK_3.Enabled = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select v.codigo,v.nombre,v.tipo_comision,v.comision," & _
                         "count(vd.n_etiq_vendedor) as Operaciones," & _
                         "sum(vd.precio_final*vd.cantidad*vd.signo ) as Total " & _
                         "from ventas_detalle vd, vendedores v where v.codigo<>'' and v.codigo = vd.n_etiq_vendedor " & _
                         "and vd.tipo in ('01','02','03','XX') and vd.estatus='0' "

            If MF_1.Checked Then
                xfil += " and vd.fecha>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If MF_2.Checked Then
                xfil += " and vd.fecha<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            xsql += xfil + " group by v.codigo, v.nombre,v.tipo_comision,v.comision order by v.codigo"

            VisualizarReportesVendedoresComisiones(xsql, MF_1.r_Valor, MF_2.r_Valor)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesVendedoresComisiones(ByVal xsql As String, ByVal xfecha_ini As Date, ByVal xfecha_fin As Date) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("COM_VENTA_DET_VEND")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                Select Case xrow("tipo_comision").ToString.Trim
                    Case "1"
                        Dim xcomision As Decimal = 0
                        xcomision = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVendedor._ComisionGlobalAsignada
                        xrow("comision") = xcomision
                    Case "2"
                        Dim xcomision As Decimal = 0
                        Dim xparam1 As New SqlParameter("@importe", xrow("importe"))
                        xcomision = F_GetDecimal("select comision from comisionrango_vendcob where desde<=@importe and hasta>=@importe and tipo='V'", xparam1)
                        xrow("comision") = xcomision
                    Case "3"
                End Select
            Next
            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xp1 As New _Reportes.ParamtCrystal("@fecha", xfecha_ini)
            Dim xp2 As New _Reportes.ParamtCrystal("@fecha_f", xfecha_fin)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xp1)
            xlist.Add(xp2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "COMISIONES_VENTAS_VENDEDOR_DETALLE.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class


'' COBRADORES

Public Class ReporteCobradores_DatosContacto
    Implements IPlantillaFiltroReportesVend_Cobr

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVend_Cobr.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_TPO_COMISION", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_TIPO_COMISION", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Maestro De Cobradores/Datos De Contacto"

        _MiFormulario.Text = "Reportes De Cobradores"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select *, '' telefono " & _
                                 "from cobradores " & _
                                 "where auto<>'' "

            If Me.CHK_1.Checked Then
                xfil += " and tipo_comision='" + Me.CB_1.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and estatus='" + Me.CB_2.SelectedValue.ToString + "'"
            End If
            If Me.CHK_3.Checked And MF_1.Checked Then
                xfil += " and fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_3.Checked And MF_2.Checked Then
                xfil += " and fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            xsql += xfil + " order by nombre"

            VisualizarReportesCobradoresDatosContacto(xsql)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesCobradoresDatosContacto(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("cobradores")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                Dim xtel As String = ""
                If xrow("telefono1").ToString.Trim <> "" Then
                    xtel = xrow("telefono1")
                End If

                If xrow("telefono2").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("telefono2")
                    Else
                        xtel = xrow("telefono2")
                    End If
                End If

                If xrow("celular1").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("celular1")
                    Else
                        xtel = xrow("celular1")
                    End If
                End If

                If xrow("celular2").ToString.Trim <> "" Then
                    If xtel <> "" Then
                        xtel += " / " + xrow("celular2")
                    Else
                        xtel = xrow("celular2")
                    End If
                End If
                xrow("telefono") = xtel
            Next
            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "COBRADOR_DATOS_CONTACTO.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

Public Class ReporteCobradores_Comisiones
    Implements IPlantillaFiltroReportesVend_Cobr

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox

    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesVend_Cobr.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_TPO_COMISION", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_TIPO_COMISION", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Comisiones De Cobradores"

        _MiFormulario.Text = "Reportes De Cobradores"
        CHK_3.Text = "Fecha"
        CHK_3.Enabled = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            If Me.CHK_1.Checked And Me.CB_1.SelectedIndex = 0 Then
                MessageBox.Show("ERROR... NO SE PUEDE MOSTRAR COMISIONES A VENDEDORES QUE NO TIENEN COMISIÓN,VERIFIQUE")
            Else
                Dim xfil As String = ""
                Dim xsql As String = "select c.*, r.fecha,r.numero documento, r.importe " & _
                                     "from cxc_recibos r inner join cobradores c on r.auto_cobrador=c.auto " & _
                                     "where r.estatus='0' and c.tipo_comision<>'0' "

                If Me.CHK_1.Checked Then
                    xfil += " and c.tipo_comision='" + Me.CB_1.SelectedIndex.ToString + "'"
                End If

                If Me.CHK_2.Checked Then
                    xfil += " and c.estatus='" + Me.CB_2.SelectedValue.ToString + "'"
                End If
                If MF_1.Checked Then
                    xfil += " and r.fecha>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
                End If

                If MF_2.Checked Then
                    xfil += " and r.fecha<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
                End If

                xsql += xfil + " order by c.nombre"

                VisualizarReportesCobradoresComisiones(xsql, MF_1.r_Valor, MF_2.r_Valor)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesCobradoresComisiones(ByVal xsql As String, ByVal xfecha_ini As Date, ByVal xfecha_fin As Date) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("cobradores")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_ficha)

            For Each xrow In dtb_ficha.Rows
                Select Case xrow("tipo_comision").ToString.Trim
                    Case "1"
                        Dim xcomision As Decimal = 0
                        xcomision = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCobrador._ComisionGlobalAsignada
                        xrow("comision") = xcomision
                        xrow("tipo_Comision") = "Comisión Global"
                    Case "2"
                        Dim xcomision As Decimal = 0
                        Dim xparam1 As New SqlParameter("@importe", xrow("importe"))
                        xcomision = F_GetDecimal("select comision from comisionrango_vendcob where desde<=@importe and hasta>=@importe and tipo='C'", xparam1)
                        xrow("comision") = xcomision
                        xrow("tipo_Comision") = "Comisión Rango"
                    Case "3"
                        xrow("tipo_Comision") = "Comisión Personalizada"
                End Select
            Next
            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ficha)

            Dim xp1 As New _Reportes.ParamtCrystal("@fecha", xfecha_ini)
            Dim xp2 As New _Reportes.ParamtCrystal("@fecha_f", xfecha_fin)
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            xlist.Add(xp1)
            xlist.Add(xp2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "COBRADOR_COMISIONES.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

