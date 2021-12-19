Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports System.Data.SqlClient

Public Class PlantillaFiltroReportesProveedores
    Dim xplantilla As IPlantillaFiltroReportesProveedores

    Dim estatus As String() = {"Activo / Habilitado", "Inactivo / Desactivado"}

    Dim xtb_grupo As DataTable
    
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
        g_MiData.F_GetData("select nombre,auto from grupo_proveedor order by nombre", xtb_grupo)
        With Me.MCB_GRUPO
            .DataSource = xtb_grupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_CREDITO
            .DataSource = estatus
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
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ApagarControles()
        Me.MCB_CREDITO.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MCHB_FECHA.Checked = True
        Me.MF_DESDE.Checked = True
        Me.MF_HASTA.Checked = True
    End Sub

    Private Sub MCHB_GRUPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_GRUPO.CheckedChanged
        Me.MCB_GRUPO.Enabled = MCHB_GRUPO.Checked
    End Sub

    Private Sub MCHB_CREDITO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MCHB_CREDITO.CheckedChanged
        Me.MCB_CREDITO.Enabled = MCHB_CREDITO.Checked
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

    Property _MiPLantilla() As IPlantillaFiltroReportesProveedores
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantillaFiltroReportesProveedores)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaFiltroReportesProveedores)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiPLantilla = xplantilla
    End Sub


End Class

Public Interface IPlantillaFiltroReportesProveedores
    Sub Inicializa(ByVal xform As Object)
End Interface

Public Class ReporteProveedores_DatosContacto
    Implements IPlantillaFiltroReportesProveedores

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesProveedores.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_CREDITO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_CREDITO", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Maestro De Proveedores/Datos De Contacto"

    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select *, '' telefono " & _
                                 "from proveedores " & _
                                 "where estatus='Activo' "

            If Me.CHK_1.Checked Then
                xfil += " and auto_grupo='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and credito='" + Me.CB_2.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_3.Checked And MF_1.Checked Then
                xfil += " and fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_3.Checked And MF_2.Checked Then
                xfil += " and fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            xsql += xfil + " order by nombre"

            VisualizarReportesProveedoresDatosContacto(xsql)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesProveedoresDatosContacto(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("proveedores")
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
            xrep += "PROVEEDORES_DATOS_CONTACTO.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

Public Class ReporteProveedores_DatosComerciales
    Implements IPlantillaFiltroReportesProveedores

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesProveedores.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_CREDITO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_CREDITO", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Maestro De Clientes/Datos Comerciales"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select *, doc_pendientes " & _
                                 "from proveedores " & _
                                 "where estatus='Activo' "

            If Me.CHK_1.Checked Then
                xfil += " and auto_grupo='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and credito='" + Me.CB_2.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_3.Checked And MF_1.Checked Then
                xfil += " and fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_3.Checked And MF_2.Checked Then
                xfil += " and fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            xsql += xfil + " order by nombre"

            VisualizarReportesProveedoresDatosComerciales(xsql)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesProveedoresDatosComerciales(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ficha As New DataTable("proveedores")
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
                Dim xsql_2 As String = "select count(*) from cxp where estatus='0' " _
                  + "and auto_proveedor= @auto_proveedor and cancelado='0' and tipo_documento not in('PAG','NCF')"
                Dim xp1 As New SqlParameter("@auto_proveedor", xrow("auto"))
                xdoc = F_GetInteger(xsql_2, xp1)
                xrow("doc_pendientes") = xdoc
            Next

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "PROVEEDORES_DATOS_COMERCIALES.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

Public Class ReporteProveedores_EstadoCuenta
    Implements IPlantillaFiltroReportesProveedores

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesProveedores.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_CREDITO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_CREDITO", True)(0)

        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Estado De Cuenta De Proveedores"

    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xsql As String = "select auto " & _
                                 "from proveedores " & _
                                 "where estatus='Activo' "

            If Me.CHK_1.Checked Then
                xfil += " and auto_grupo='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and credito='" + Me.CB_2.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_3.Checked And MF_1.Checked Then
                xfil += " and fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_3.Checked And MF_2.Checked Then
                xfil += " and fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            xsql += xfil

            VisualizarReportesProveedoresEstadoCuenta(xsql)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesProveedoresEstadoCuenta(ByVal xsql As String) As Boolean
        Try
            Dim xds As New DataSet
            Dim xfecha As Date = DateAdd(DateInterval.Month, -3, g_MiData.p_FechaDelMotorBD)

            Dim xpar1 As New SqlParameter("@fecha", _FechaComienzoDelMes(xfecha))

            Dim xsql1 As String = "select cxp.fecha,cxp.tipo_documento,cxp.documento,cxp.detalle,cxp.importe,cxp.acumulado,cxp.resta,cxp.signo, " & _
               "p.nombre,p.codigo,p.ci_rif,p.dir_fiscal,p.telefono,p.credito_disponible,p.total_anticipos,p.dias_credito,p.limite_credito, 0 saldo_anterior, p.auto " & _
               "from proveedores p inner join cxp on p.auto=cxp.auto_proveedor where p.auto in (" + xsql + ") and cxp.estatus<>'1' and cxp.fecha > @fecha order by nombre; " & _
               "select nombre,rif,direccion from empresa;"
            g_MiData.F_GetData(xsql1, xds, xpar1)

            For Each xrow In xds.Tables(0).Rows
                xpar1 = New SqlParameter("@fecha", _FechaComienzoDelMes(xfecha))
                Dim xpar2 As New SqlParameter("@auto_proveedor", xrow("auto"))
                Dim xsql2 As String = "select sum(importe*signo) as saldo from cxp where auto_proveedor=@auto_proveedor and cxp.estatus<>'1' and cxp.fecha <= @fecha"
                Dim xsaldo As Decimal = F_GetDecimal(xsql2, xpar1, xpar2)
                xrow("saldo_anterior") = xsaldo
            Next

            xds.Tables(0).TableName = "Cxp_Proveedor"
            xds.Tables(1).TableName = "Empresa"

            Dim xlista As New List(Of _Reportes.ParamtCrystal)
            Dim xpc1 As New _Reportes.ParamtCrystal("@fecha", _FechaComienzoDelMes(xfecha))
            xlista.Add(xpc1)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "PROVEEDORES_ESTADO_CUENTA.rpt"
            Dim xficha As New _Reportes(xds, xrep, xlista)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class

Public Class ReporteProveedores_RetencionesIva
    Implements IPlantillaFiltroReportesProveedores

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesProveedores.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_CREDITO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_CREDITO", True)(0)
        
        MF_1 = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_2 = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Retenciones Iva De Proveedores"

    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""

            If Me.CHK_1.Checked Then
                xfil += " and auto_grupo='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and credito='" + Me.CB_2.SelectedIndex.ToString + "'"
            End If

            If Me.CHK_3.Checked And MF_1.Checked Then
                xfil += " and fecha_alta>='" + Me.MF_1.r_Valor.ToShortDateString + "'"
            End If

            If Me.CHK_3.Checked And MF_2.Checked Then
                xfil += " and fecha_alta<='" + Me.MF_2.r_Valor.ToShortDateString + "'"
            End If

            VisualizarReportesProveedoresRetencionesIva(xfil)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function VisualizarReportesProveedoresRetencionesIva(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_retenciones As New DataTable("retenciones_compras")
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
            "from proveedores p join retenciones_compras r on p.auto=r.auto_entidad join retenciones_compras_detalle rd on r.auto=rd.auto " & _
            "where p.estatus='Activo' " + xsql + " group by r.fecha" & _
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
            xrep += "PROVEEDORES_RETENCIONES.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class