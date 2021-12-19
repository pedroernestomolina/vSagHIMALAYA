Imports MisControles.Controles
Imports System.Data.SqlClient

Public Class PlantillaFiltroReportesCxC
    Dim xplantilla As IPlantillaFiltroReportesCxC

    Dim xtb_cliente As DataTable
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

    Private Sub PlantillaFiltroReportesCxC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub CargarData()
        xtb_cliente = New DataTable
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

        Dim Estatus As String() = {"Todas", "Pagadas", "Pendientes"}
        With Me.MCB_ESTATUS
            .DataSource = Estatus
            .SelectedIndex = 0
        End With
    End Sub

    Sub Inicializa()
        Try
            ApagarControles()
            CargarData()
            _MiPLantilla.Inicializa(Me)

            Me.MCHB_CLIENTE.Focus()
            Me.MCHB_CLIENTE.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ApagarControles()
        Me.MCB_CLIENTE.Enabled = False
        Me.MCB_COBRADOR.Enabled = False
        Me.MCB_ESTADO.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MCB_VENDEDOR.Enabled = False
        Me.MCB_ZONA.Enabled = False
        Me.MF_DESDE.Enabled = False
        Me.MF_HASTA.Enabled = False
        Me.MCB_ESTATUS.Enabled = False
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

    Property _MiPLantilla() As IPlantillaFiltroReportesCxC
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantillaFiltroReportesCxC)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaFiltroReportesCxC)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiPLantilla = xplantilla
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

    Private Sub MCHB_ESTATUS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ESTATUS.CheckedChanged
        Me.MCB_ESTATUS.Enabled = MCHB_ESTATUS.Checked
    End Sub
End Class

Public Interface IPlantillaFiltroReportesCxC
    Sub Inicializa(ByVal xform As Object)
End Interface


Public Class ReporteCxC_DocumentosPorCobrar
    Implements IPlantillaFiltroReportesCxC

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

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCxC.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        LB_1.Text = "Documentos Pendientes Por Cobrar"

        'INACTIVAR FECHAS
        Me.CHK_7.Enabled = False
        Me.CHK_8.Enabled = False
    End Sub

    Private Sub CHK_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHK_1.Click
        Me.CB_1.Enabled = CHK_1.Checked

        Me.CHK_2.Enabled = Not Me.CHK_1.Checked
        Me.CHK_3.Enabled = Not Me.CHK_1.Checked
        Me.CHK_4.Enabled = Not Me.CHK_1.Checked
        Me.CHK_5.Enabled = Not Me.CHK_1.Checked
        Me.CHK_6.Enabled = Not Me.CHK_1.Checked

        If Me.CHK_1.Checked Then
            Me.CHK_2.Checked = False
            Me.CHK_3.Checked = False
            Me.CHK_4.Checked = False
            Me.CHK_5.Checked = False
            Me.CHK_6.Checked = False
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If CHK_1.Checked Then
            Try
                Dim xds As DataSet = New DataSet
                Dim xpar1 As New SqlParameter("@auto_cliente", CB_1.SelectedValue)
                Dim xsql = "select fecha,tipo_documento,documento,fecha_vencimiento,detalle,importe,acumulado,resta " _
                  + "from cxc where auto_cliente=@auto_cliente and cancelado<>'1' and estatus<>'1' and tipo_documento NOT IN ('PAG','ANT') order by fecha;" _
                  + "select nombre,rif,direccion from empresa;" _
                  + "select nombre,codigo,ci_rif,dir_fiscal,telefono from clientes where auto=@auto_cliente"

                g_MiData.F_GetData(xsql, xds, xpar1)
                xds.Tables(0).TableName = "Cxc"
                xds.Tables(1).TableName = "Empresa"
                xds.Tables(2).TableName = "Cliente"

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "CLIENTE_DOCUMENTOS_PENDIENTES.rpt"
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
                "gc.nombre grupo, e.nombre estado, z.nombre zona, v.nombre vendedor , co.nombre cobrador " & _
                "from clientes c join cxc cx on c.auto=cx.auto_cliente join grupo_cliente gc on c.auto_grupo=gc.auto " & _
                                "join estados e on c.auto_estado=e.auto  join zona_cliente z on c.auto_zona =z.auto " & _
                                "join vendedores v on c.auto_vendedor=v.auto join cobradores co on c.auto_cobrador=co.auto " & _
                "where cx.cancelado<>'1' and cx.estatus<>'1' and cx.tipo_documento NOT IN ('PAG','ANT') "

                If Me.CHK_2.Checked Then
                    xfil += " and c.auto_grupo='" + Me.CB_2.SelectedValue + "'"
                End If

                If Me.CHK_3.Checked Then
                    xfil += " and c.auto_estado='" + Me.CB_3.SelectedValue + "'"
                End If

                If Me.CHK_4.Checked Then
                    xfil += " and c.auto_zona='" + Me.CB_4.SelectedValue + "'"
                End If

                If Me.CHK_5.Checked Then
                    xfil += " and c.auto_vendedor='" + Me.CB_5.SelectedValue + "'"
                End If

                If Me.CHK_6.Checked Then
                    xfil += " and c.auto_cobrador='" + Me.CB_6.SelectedValue + "'"
                End If
                xsql += xfil + " order by c.nombre,cx.fecha"

                g_MiData.F_GetData(xsql, xds)
                xds.Tables(0).TableName = "Empresa"
                xds.Tables(1).TableName = "Cxc_1"

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "CXC_DOCUMENTOS_PENDIENTES.rpt"
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

Public Class ReporteCxC_CobranzaDiaria
    Implements IPlantillaFiltroReportesCxC

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCxC.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Cobranza Diaria"
        With Me.CHK_7
            .Checked = True
            .Enabled = False
        End With

        Me.MF_I.ShowCheckBox = False
        Me.CHK_8.Enabled = False
    End Sub

    Private Sub CHK_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHK_1.Click
        Me.CB_1.Enabled = CHK_1.Checked

        Me.CHK_2.Enabled = Not Me.CHK_1.Checked
        Me.CHK_3.Enabled = Not Me.CHK_1.Checked
        Me.CHK_4.Enabled = Not Me.CHK_1.Checked
        Me.CHK_5.Enabled = Not Me.CHK_1.Checked
        Me.CHK_6.Enabled = Not Me.CHK_1.Checked

        If Me.CHK_1.Checked Then
            Me.CHK_2.Checked = False
            Me.CHK_3.Checked = False
            Me.CHK_4.Checked = False
            Me.CHK_5.Checked = False
            Me.CHK_6.Checked = False
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
              "select  r.numero,r.fecha,cx.importe,r.cobrador,r.nombre_cliente,r.ci_rif_cliente, " & _
              "r.detalle, r.estatus, r.cant_doc_rel, d.operacion, d.monto, d.documento, d.tipo, d.origen " & _
              "from  cxc_recibos r join cxc_documentos d on r.auto = d.auto_cxc_recibo " & _
              "join cxc cx on r.numero=cx.documento " & _
              "join clientes c on r.auto_cliente=c.auto " & _
              "where r.estatus='0' and r.auto_cliente=c.auto"

            If Me.CHK_1.Checked Then
                xfil += " and c.auto='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and c.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and c.auto_estado='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and c.auto_zona='" + Me.CB_4.SelectedValue + "'"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and c.auto_vendedor='" + Me.CB_5.SelectedValue + "'"
            End If

            If Me.CHK_6.Checked Then
                xfil += " and c.auto_cobrador='" + Me.CB_6.SelectedValue + "'"
            End If

            If Me.CHK_7.Checked Then
                If MF_I.Checked Then
                    xfil += " and r.fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                End If
                If MF_F.Checked Then
                    xfil += " and r.fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                End If
            End If
            xsql += xfil + " order by r.fecha, r.numero "

            g_MiData.F_GetData(xsql, xds)
            xds.Tables(0).TableName = "Empresa"
            xds.Tables(1).TableName = "CXC_2"

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "CXC_RELACION_COBRANZA.rpt"
            Dim xficha As New _Reportes(xds, xrep, Nothing)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ReporteCxC_PagosEmitidos
    Implements IPlantillaFiltroReportesCxC

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCxC.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Pagos Emitidos"
        With Me.CHK_7
            .Checked = True
            .Enabled = False
        End With
        Me.MF_I.ShowCheckBox = False
        Me.CHK_8.Enabled = False
    End Sub

    Private Sub CHK_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHK_1.Click
        Me.CB_1.Enabled = CHK_1.Checked

        Me.CHK_2.Enabled = Not Me.CHK_1.Checked
        Me.CHK_3.Enabled = Not Me.CHK_1.Checked
        Me.CHK_4.Enabled = Not Me.CHK_1.Checked
        Me.CHK_5.Enabled = Not Me.CHK_1.Checked
        Me.CHK_6.Enabled = Not Me.CHK_1.Checked

        If Me.CHK_1.Checked Then
            Me.CHK_2.Checked = False
            Me.CHK_3.Checked = False
            Me.CHK_4.Checked = False
            Me.CHK_5.Checked = False
            Me.CHK_6.Checked = False
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
               "select r.numero,r.fecha,r.importe,r.cobrador,r.nombre_cliente,r.ci_rif_cliente, " & _
               "r.detalle, r.estatus, r.cant_doc_rel, p.codigo, p.agencia, p.nombre, p.importe IMPORTE_2, p.numero numero_2 " & _
               "from cxc_recibos r join cxc_modo_pago p on r.auto = p.auto_recibo join clientes c on r.auto_cliente=c.auto " & _
               "where r.estatus='0' and r.auto_cliente = c.auto "

            If Me.CHK_1.Checked Then
                xfil += " and c.auto='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and c.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and c.auto_estado='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and c.auto_zona='" + Me.CB_4.SelectedValue + "'"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and c.auto_vendedor='" + Me.CB_5.SelectedValue + "'"
            End If

            If Me.CHK_6.Checked Then
                xfil += " and c.auto_cobrador='" + Me.CB_6.SelectedValue + "'"
            End If

            If Me.CHK_7.Checked Then
                If MF_I.Checked Then
                    xfil += " and r.fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                End If
                If MF_F.Checked Then
                    xfil += " and r.fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                End If
            End If
            xsql += xfil + " order by r.fecha, r.numero "

            g_MiData.F_GetData(xsql, xds)
            xds.Tables(0).TableName = "Empresa"
            xds.Tables(1).TableName = "CXC_3"

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "CXC_PAGOS_EMITIDOS.rpt"
            Dim xficha As New _Reportes(xds, xrep, Nothing)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ReporteCxC_AnalisisVencimiento
    Implements IPlantillaFiltroReportesCxC

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCxC.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Analisis De Vencimiento"
        Me.CHK_7.Enabled = False
        Me.CHK_8.Enabled = False
    End Sub

    Private Sub CHK_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHK_1.Click
        Me.CB_1.Enabled = CHK_1.Checked

        Me.CHK_2.Enabled = Not Me.CHK_1.Checked
        Me.CHK_3.Enabled = Not Me.CHK_1.Checked
        Me.CHK_4.Enabled = Not Me.CHK_1.Checked
        Me.CHK_5.Enabled = Not Me.CHK_1.Checked
        Me.CHK_6.Enabled = Not Me.CHK_1.Checked

        If Me.CHK_1.Checked Then
            Me.CHK_2.Checked = False
            Me.CHK_3.Checked = False
            Me.CHK_4.Checked = False
            Me.CHK_5.Checked = False
            Me.CHK_6.Checked = False
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
                                 "select cx.fecha,cx.tipo_documento,cx.documento,cx.fecha_vencimiento,cx.importe,cx.acumulado,cx.resta," & _
                                 "c.nombre, c.ci_rif, c.dir_fiscal, c.Telefono_1, c.Celular_1, c.Fax_1, c.codigo," & _
                                 "GC.nombre GRUPOS, E.nombre ESTADO, Z.nombre ZONA, V.nombre VENDEDOR, CO.nombre COBRADOR " & _
                                 "from clientes c join cxc cx on c.auto=cx.auto_cliente join grupo_cliente gc on c.auto_grupo=gc.auto " & _
                                 "join estados e on c.auto_estado=e.auto  join zona_cliente z on c.auto_zona =z.auto " & _
                                 "join vendedores v on c.auto_vendedor=v.auto join cobradores co on c.auto_cobrador=co.auto " & _
                                 "where cx.cancelado<>'1' and cx.estatus<>'1' and cx.tipo_documento not in('PAG','ANT') "

            If Me.CHK_1.Checked Then
                xfil += " and c.auto='" + Me.CB_1.SelectedValue + "'"
            End If

            If Me.CHK_2.Checked Then
                xfil += " and c.auto_grupo='" + Me.CB_2.SelectedValue + "'"
            End If

            If Me.CHK_3.Checked Then
                xfil += " and c.auto_estado='" + Me.CB_3.SelectedValue + "'"
            End If

            If Me.CHK_4.Checked Then
                xfil += " and c.auto_zona='" + Me.CB_4.SelectedValue + "'"
            End If

            If Me.CHK_5.Checked Then
                xfil += " and c.auto_vendedor='" + Me.CB_5.SelectedValue + "'"
            End If

            If Me.CHK_6.Checked Then
                xfil += " and c.auto_cobrador='" + Me.CB_6.SelectedValue + "'"
            End If
            xsql += xfil + " order by cx.fecha, cx.auto "

            g_MiData.F_GetData(xsql, xds)
            xds.Tables(0).TableName = "Empresa"
            xds.Tables(1).TableName = "CXC_4"

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "CXC_ANALISIS.rpt"
            Dim xficha As New _Reportes(xds, xrep, Nothing)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ReporteCxC_FacturasCobradas
    Implements IPlantillaFiltroReportesCxC

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCxC.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Documentos Pendientes Por Cobrar"

        'INACTIVAR FECHAS
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = False
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False

        Me.CHK_8.Enabled = True
        Me.CHK_7.Enabled = True
        Me.CHK_7.Checked = True
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
            "select v.documento,v.nombre ,v.ci_rif, case when v.tipo ='01' then 'FAC' WHEN v.tipo='03' then 'NC' else '' END as tipo , v.fecha , v.control, v.total, " & _
            "case c.cancelado when '0' then 'PEND' ELSE 'PAGADA' END AS estatus, abs(c.resta) as resta from ventas as v join cxc as c on c.auto_documento = v.auto where 1=1 and v.estatus='0' "

            If Me.CHK_8.Checked Then
                If Me.CB_7.SelectedIndex = 0 Then
                ElseIf Me.CB_7.SelectedIndex = 1 Then
                    xfil += " and c.cancelado='1' "
                Else
                    xfil += " and c.cancelado='0' "
                End If
            End If

            If Me.CHK_7.Checked Then
                If MF_I.Checked Then
                    xfil += " and v.fecha>='" + Me.MF_I.r_Valor.ToShortDateString + "'"
                End If
                If MF_F.Checked Then
                    xfil += " and v.fecha<='" + Me.MF_F.r_Valor.ToShortDateString + "'"
                End If
            End If
            xsql += xfil + " order by v.fecha, v.documento, v.tipo "

            g_MiData.F_GetData(xsql, xds)
            xds.Tables(0).TableName = "Empresa"
            xds.Tables(1).TableName = "FACTURA_COBRANZA"

            Dim list As New List(Of _Reportes.ParamtCrystal)
            Dim xf1 As New _Reportes.ParamtCrystal("@Desde", MF_I.r_Valor)
            Dim xf2 As New _Reportes.ParamtCrystal("@Hasta", MF_F.r_Valor)
            list.Add(xf1)
            list.Add(xf2)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "FACTURAS_COBRANZA.rpt"

            Dim xficha As New _Reportes(xds, xrep, list)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ReporteCxC_ClientesConAnticiposNC
    Implements IPlantillaFiltroReportesCxC

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

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroReportesCxC.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        CHK_1 = _MiFormulario.Controls.Find("MCHB_CLIENTE", True)(0)
        CHK_2 = _MiFormulario.Controls.Find("MCHB_GRUPO", True)(0)
        CHK_3 = _MiFormulario.Controls.Find("MCHB_ESTADO", True)(0)
        CHK_4 = _MiFormulario.Controls.Find("MCHB_ZONA", True)(0)
        CHK_5 = _MiFormulario.Controls.Find("MCHB_VENDEDOR", True)(0)
        CHK_6 = _MiFormulario.Controls.Find("MCHB_COBRADOR", True)(0)
        CHK_7 = _MiFormulario.Controls.Find("MCHB_FECHA", True)(0)
        CHK_8 = _MiFormulario.Controls.Find("MCHB_ESTATUS", True)(0)

        CB_1 = _MiFormulario.Controls.Find("MCB_CLIENTE", True)(0)
        CB_2 = _MiFormulario.Controls.Find("MCB_GRUPO", True)(0)
        CB_3 = _MiFormulario.Controls.Find("MCB_ESTADO", True)(0)
        CB_4 = _MiFormulario.Controls.Find("MCB_ZONA", True)(0)
        CB_5 = _MiFormulario.Controls.Find("MCB_VENDEDOR", True)(0)
        CB_6 = _MiFormulario.Controls.Find("MCB_COBRADOR", True)(0)
        CB_7 = _MiFormulario.Controls.Find("MCB_ESTATUS", True)(0)

        MF_I = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_F = _MiFormulario.Controls.Find("MF_HASTA", True)(0)

        LB_1.Text = "Clientes Con Anticipos y NC Pendientes"

        'INACTIVAR FECHAS
        Me.CHK_1.Enabled = False
        Me.CHK_2.Enabled = False
        Me.CHK_3.Enabled = False
        Me.CHK_4.Enabled = False
        Me.CHK_5.Enabled = False
        Me.CHK_6.Enabled = False
        Me.CHK_7.Enabled = False
        Me.CHK_8.Enabled = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfil As String = ""
            Dim xds As DataSet = New DataSet
            Dim xsql As String = "select nombre,rif,direccion from empresa;" & _
            "select CLIENTE AS NOMBRE , ci_rif, SUM(ABS(resta)) as resta, tipo_documento AS TIPO from cxc where tipo_documento IN  ('NCF','ANT','NC') AND cancelado='0' and estatus='0' " & _
            "GROUP BY cliente,ci_rif,auto_cliente,tipo_documento  ORDER BY cliente "

            g_MiData.F_GetData(xsql, xds)
            xds.Tables(0).TableName = "Empresa"
            xds.Tables(1).TableName = "FACTURA_COBRANZA"

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "CLIENTES_CON_ANTICIPO_NC.rpt"

            Dim xficha As New _Reportes(xds, xrep, Nothing)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
