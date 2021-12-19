Imports MisControles.Controles
Imports System.Data.SqlClient

Public Class PlantillaFiltroReporteCxP
    Dim xplantilla As IPlantillaFiltroReportesCxP
    Dim xtb_proveedor As DataTable
    Dim xtb_grupo As DataTable
    Dim xtb_tipo As DataTable
    Dim tipo As String() = {"Nacionales", "Extranjeros"}
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
        xtb_proveedor = New DataTable
        g_MiData.F_GetData("select nombre,auto from proveedores order by nombre", xtb_proveedor)
        With Me.MCB_PROVEEDOR
            .DataSource = xtb_proveedor
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xtb_grupo = New DataTable
        g_MiData.F_GetData("select nombre,auto from grupo_proveedor order by nombre", xtb_grupo)
        With Me.MCB_GRUPO
            .DataSource = xtb_grupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_TIPO
            .DataSource = tipo
            .SelectedIndex = 0
        End With
    End Sub

    Sub Inicializa()
        Try
            ApagarControles()
            CargarData()
            _MiPLantilla.Inicializa(Me)

            Me.MCHB_PROVEEDOR.Focus()
            Me.MCHB_PROVEEDOR.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ApagarControles()
        Me.MCB_PROVEEDOR.Enabled = False
        Me.MCB_TIPO.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MF_DESDE.Enabled = False
        Me.MF_HASTA.Enabled = False
    End Sub

    Private Sub MCHB_PROVEEDOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_PROVEEDOR.CheckedChanged
        MCB_PROVEEDOR.Enabled = MCHB_PROVEEDOR.Checked
    End Sub

    Private Sub MCHB_GRUPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_GRUPO.CheckedChanged
        Me.MCB_GRUPO.Enabled = MCHB_GRUPO.Checked
    End Sub

    Private Sub MCHB_TIPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_TIPO.CheckedChanged
        Me.MCB_TIPO.Enabled = MCHB_TIPO.Checked
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

    Property _MiPLantilla() As IPlantillaFiltroReportesCxP
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantillaFiltroReportesCxP)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaFiltroReportesCxP)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiPLantilla = xplantilla
    End Sub
End Class

Public Interface IPlantillaFiltroReportesCxP
    Sub Inicializa(ByVal xform As Object)
End Interface


Public Class ReporteCxP_DocumentosPorPagar
    Implements IPlantillaFiltroReportesCxP

    Dim LB_1 As Label
    WithEvents xformulario As System.Windows.Forms.Form
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents CHK_4 As MisCheckBox
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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCxP.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_TIPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_TIPO", True)(0)
        LB_1.Text = "Documentos Pendientes Por Pagar"

        'INACTIVAR FECHAS
        Me.CHK_4.Enabled = False
    End Sub

    Private Sub CHK_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHK_1.Click
        Me.CB_1.Enabled = CHK_1.Checked

        Me.CHK_2.Enabled = Not Me.CHK_1.Checked
        Me.CHK_3.Enabled = Not Me.CHK_1.Checked

        If Me.CHK_1.Checked Then
            Me.CHK_2.Checked = False
            Me.CHK_3.Checked = False
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If CHK_1.Checked Then
            Try
                Dim xds As DataSet = New DataSet
                Dim xpar1 As New SqlParameter("@auto_proveedor", CB_1.SelectedValue)
                Dim xsql = "select fecha,tipo_documento,documento,fecha_vencimiento,detalle,importe,acumulado,resta " _
                  + "from cxp where auto_proveedor=@auto_proveedor and cancelado<>'1' and estatus<>'1' and tipo_documento<>'PAG' order by fecha;" _
                  + "select nombre,rif,direccion from empresa;" _
                  + "select nombre,codigo,ci_rif,dir_fiscal,telefono from proveedores where auto=@auto_proveedor"

                g_MiData.F_GetData(xsql, xds, xpar1)
                xds.Tables(0).TableName = "Cxc"
                xds.Tables(1).TableName = "Empresa"
                xds.Tables(2).TableName = "Cliente"

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "PROVEEDOR_DOCUMENTOS_PENDIENTES.rpt"
                Dim xficha As New _Reportes(xds, xrep, Nothing)
                With xficha
                    .Show()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Try
                Dim xfil As String = ""
                Dim xds As DataSet = New DataSet
                Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
                "select c.nombre,c.codigo,c.ci_rif,c.dir_fiscal,c.telefono_1,c.telefono_2,c.celular_1, " & _
                "cx.fecha ,cx.tipo_documento,cx.documento,cx.fecha_vencimiento,cx.detalle,cx.importe,cx.acumulado,cx.resta, " & _
                "gc.nombre grupo " & _
                "from proveedores c join cxp cx on c.auto=cx.auto_proveedor join grupo_proveedor gc on c.auto_grupo=gc.auto " & _
                "where cx.cancelado<>'1' and cx.estatus<>'1' and cx.tipo_documento<>'PAG' "

                If Me.CHK_2.Checked Then
                    xfil += " and c.auto_grupo='" + Me.CB_2.SelectedValue + "'"
                End If

                If Me.CHK_3.Checked Then
                    xfil += IIf(Me.CB_3.SelectedIndex = 0, " and c.tipoorigen='Nacional' ", " and c.tipoorigen='Extranjero' ")
                End If

                xsql += xfil + " order by c.nombre,cx.fecha"

                g_MiData.F_GetData(xsql, xds)
                xds.Tables(0).TableName = "Empresa"
                xds.Tables(1).TableName = "Cxp_1"

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "CXP_DOCUMENTOS_PENDIENTES.rpt"
                Dim xficha As New _Reportes(xds, xrep, Nothing)
                With xficha
                    .Show()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class

Public Class ReporteCxP_PagosEmitidos
    Implements IPlantillaFiltroReportesCxP

    Dim LB_1 As Label
    WithEvents xformulario As System.Windows.Forms.Form
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents CHK_4 As MisCheckBox
    WithEvents CB_1 As MisComboBox
    WithEvents CB_2 As MisComboBox
    WithEvents CB_3 As MisComboBox
    WithEvents MF_I As MisFechas
    WithEvents MF_F As MisFechas

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCxP.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_TIPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CB_1 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_TIPO", True)(0)
        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Pagos Emitidos"
        Me.CHK_4.Checked = True
    End Sub

    Private Sub CHK_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHK_1.Click
        Me.CB_1.Enabled = CHK_1.Checked

        Me.CHK_2.Enabled = Not Me.CHK_1.Checked
        Me.CHK_3.Enabled = Not Me.CHK_1.Checked
        Me.CHK_4.Enabled = Not Me.CHK_1.Checked

        If Me.CHK_1.Checked Then
            Me.CHK_2.Checked = False
            Me.CHK_3.Checked = False
            Me.CHK_4.Checked = False
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = "where r.estatus='0' and r.auto_proveedor = c.auto "
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
               "select r.numero,r.fecha,r.importe,r.nombre_proveedor,r.ci_rif_proveedor, " & _
               "r.detalle, r.estatus, r.cant_doc_rel, p.banco agencia, p.nombre, p.importe IMPORTE_2, p.numero numero_2 " & _
               "from cxp_recibos r join cxp_modo_pago p on r.auto = p.auto_recibo join proveedores c on r.auto_proveedor=c.auto "

            Dim xsql2 As String = "select r.numero, r.fecha, r.importe, r.nombre_proveedor, r.ci_rif_proveedor, " & _
            "r.detalle,r.estatus,r.cant_doc_rel, '' agencia, 'NOTA DE CREDITO' nombre, cd.monto importe_2, '' numero_2 " & _
            "from cxp_recibos r join cxp_documentos cd on r.auto=cd.auto_cxp_recibo join proveedores c on r.auto_proveedor=c.auto "

            If Me.CHK_1.Checked Then
                xfil += " and c.auto='" + Me.CB_1.SelectedValue + "' "
            End If

            If Me.CHK_2.Checked Then
                xfil += " and c.auto_grupo='" + Me.CB_2.SelectedValue + "' "
            End If

            If Me.CHK_3.Checked Then
                xfil += IIf(Me.CB_3.SelectedIndex = 0, " and c.tipoorigen='Nacional' ", " and c.tipoorigen='Extranjero' ")
            End If

            If Me.CHK_4.Checked Then
                If MF_I.Checked Then
                    xfil += " and r.fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "' "
                End If
                If MF_F.Checked Then
                    xfil += " and r.fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "' "
                End If
            End If

            xsql += xfil + "union " + xsql2 + xfil + " and r.tipo_pago='2' and (cd.origen='NOTA CRÉDITO' OR cd.origen='NOTA CREDITO')"

            g_MiData.F_GetData(xsql, xds)
            xds.Tables(0).TableName = "Empresa"
            xds.Tables(1).TableName = "CXP_2"

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "CXP_PAGOS_EMITIDOS.rpt"
            Dim xficha As New _Reportes(xds, xrep, Nothing)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ReporteCxP_AnalisisVencimiento
    Implements IPlantillaFiltroReportesCxP

    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents CHK_1 As MisCheckBox
    WithEvents CHK_2 As MisCheckBox
    WithEvents CHK_3 As MisCheckBox
    WithEvents CHK_4 As MisCheckBox

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCxP.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_PROVEEDOR", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_TIPO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_PROVEEDOR", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_TIPO", True)(0)

        LB_1.Text = "Analisis De Vencimiento"

        'INACTIVAR FECHAS
        Me.CHK_4.Enabled = False
    End Sub

    Private Sub CHK_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHK_1.Click
        Me.CB_1.Enabled = CHK_1.Checked

        Me.CHK_2.Enabled = Not Me.CHK_1.Checked
        Me.CHK_3.Enabled = Not Me.CHK_1.Checked

        If Me.CHK_1.Checked Then
            Me.CHK_2.Checked = False
            Me.CHK_3.Checked = False
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If CHK_1.Checked Then
            Try
                Dim xds As DataSet = New DataSet
                Dim xpar1 As New SqlParameter("@auto_proveedor", CB_1.SelectedValue)
                Dim xsql = "select fecha,tipo_documento,documento,fecha_vencimiento,detalle,importe,acumulado,resta " _
                  + "from cxp where auto_proveedor=@auto_proveedor and cancelado<>'1' and estatus<>'1' and tipo_documento<>'PAG' order by fecha;" _
                  + "select nombre,rif,direccion from empresa;" _
                  + "select nombre,codigo,ci_rif,dir_fiscal,telefono from proveedores where auto=@auto_proveedor"

                g_MiData.F_GetData(xsql, xds, xpar1)
                xds.Tables(0).TableName = "Cxc"
                xds.Tables(1).TableName = "Empresa"
                xds.Tables(2).TableName = "Cliente"

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "PROVEEDOR_ANALISIS_VENCIMIENTO.rpt"
                Dim xficha As New _Reportes(xds, xrep, Nothing)
                With xficha
                    .Show()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Try
                Dim xfil As String = ""
                Dim xds As DataSet = New DataSet
                Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
                "select c.nombre,c.codigo,c.ci_rif,c.dir_fiscal,c.telefono_1,c.telefono_2,c.celular_1, " & _
                "cx.fecha ,cx.tipo_documento,cx.documento,cx.fecha_vencimiento,cx.detalle,cx.importe,cx.acumulado,cx.resta, " & _
                "gc.nombre grupo " & _
                "from proveedores c join cxp cx on c.auto=cx.auto_proveedor join grupo_proveedor gc on c.auto_grupo=gc.auto " & _
                "where cx.cancelado<>'1' and cx.estatus<>'1' and cx.tipo_documento<>'PAG' "

                If Me.CHK_2.Checked Then
                    xfil += " and c.auto_grupo='" + Me.CB_2.SelectedValue + "'"
                End If

                If Me.CHK_3.Checked Then
                    xfil += IIf(Me.CB_3.SelectedIndex = 0, " and c.tipoorigen='Nacional' ", " and c.tipoorigen='Extranjero' ")
                End If

                xsql += xfil + " order by c.nombre,cx.fecha"

                g_MiData.F_GetData(xsql, xds)
                xds.Tables(0).TableName = "Empresa"
                xds.Tables(1).TableName = "Cxp_1"

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "CXP_ANALISIS_VENCIMIENTO.rpt"
                Dim xficha As New _Reportes(xds, xrep, Nothing)
                With xficha
                    .Show()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
