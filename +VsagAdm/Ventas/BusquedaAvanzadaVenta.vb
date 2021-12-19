Public Class BusquedaAvanzadaVenta
    Event _LlamarReceptor(ByVal xsql As String)

    Dim estatus As String() = {"Activo", "Anulados"}
    Dim xtb_grupo As DataTable
    Dim xtb_serie As DataTable
    Dim xtb_estado As DataTable
    Dim xtb_zona As DataTable
    Dim xtb_vendedor As DataTable
    Dim xbs_estado As BindingSource
    Dim xbs_zona As BindingSource
    Dim xrel_estado_zona As DataRelation
    Dim xds As DataSet

    Dim campo_p As DataColumn
    Dim campo_h As DataColumn

    Dim xmostrar_chimbo As Boolean

    Property _MostrarChimbo() As Boolean
        Get
            Return xmostrar_chimbo
        End Get
        Set(ByVal value As Boolean)
            xmostrar_chimbo = value
        End Set
    End Property

    Sub ApagarControles()
        Me.MCB_ESTADO.Enabled = False
        Me.MCB_SERIE.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MCB_VENDEDOR.Enabled = False
        Me.MCB_ZONA.Enabled = False
        Me.MCB_ESTATUS.Enabled = False
        Me.MT_DOCUMENTO.Enabled = False
    End Sub

    Sub CargarData()
        xtb_grupo = New DataTable
        g_MiData.F_GetData("select nombre,auto from grupo_cliente order by nombre", xtb_grupo)
        With Me.MCB_GRUPO
            .DataSource = xtb_grupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xtb_serie = New DataTable
        g_MiData.F_GetData("select nombre from series_fiscales order by nombre", xtb_serie)
        With Me.MCB_SERIE
            .DataSource = xtb_serie
            .DisplayMember = "nombre"
            .ValueMember = "nombre"
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

        With Me.MCB_ESTATUS
            .DataSource = estatus
            .SelectedIndex = 0
        End With
    End Sub

    Sub Inicializa()
        Try
            ApagarControles()
            CargarData()
            Me.MCHB_GRUPO.Focus()
            Me.MCHB_GRUPO.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BusquedaAvanzadaVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub BusquedaAvanzadaVenta_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
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

    Private Sub MCHB_SERIE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_SERIE.CheckedChanged
        Me.MCB_SERIE.Enabled = MCHB_SERIE.Checked
    End Sub

    Private Sub MCHB_ESTATUS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ESTATUS.CheckedChanged
        Me.MCB_ESTATUS.Enabled = MCHB_ESTATUS.Checked
    End Sub

    Private Sub MCHB_DOCUMENTO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_DOCUMENTO.CheckedChanged
        MT_DOCUMENTO.Enabled = Me.MCHB_DOCUMENTO.Checked
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        Dim xbus_prv As String = ""
        Dim xfil As String = ""

        Try

            Dim xcondicion As String = ""
            If _MostrarChimbo Then
                xcondicion = "v.tipo in ('XX') and v.auto_entidad=c.auto "
            Else
                xcondicion = "v.tipo in ('01','02','03','04','05','06') and v.auto_entidad=c.auto "
            End If
            Dim xdocumento As String = ""

            If Me.MCHB_GRUPO.Checked Then
                xcondicion += "and c.auto_grupo ='" + Me.MCB_GRUPO.SelectedValue + "' "
            End If

            If Me.MCHB_VENDEDOR.Checked Then
                xcondicion += "and v.auto_vendedor ='" + Me.MCB_VENDEDOR.SelectedValue + "' "
            End If

            If Me.MCHB_ESTADO.Checked Then
                xcondicion += "and c.auto_estado='" + Me.MCB_ESTADO.SelectedValue + "' "
            End If

            If Me.MCHB_ZONA.Checked Then
                xcondicion += "and c.auto_zona='" + Me.MCB_ZONA.SelectedValue + "' "
            End If

            If Me.MCHB_ESTATUS.Checked Then
                xcondicion += IIf(Me.MCB_ESTATUS.SelectedIndex = 0, " and v.estatus='0'", " and v.estatus='1'")
            End If

            If Me.MCHB_SERIE.Checked Then
                xcondicion += "and v.serie ='" + Me.MCB_SERIE.SelectedValue + "' "
            End If

            If Me.MCHB_DOCUMENTO.Checked Then
                If MT_DOCUMENTO.r_Valor <> "" Then
                    If MT_DOCUMENTO.r_Valor.Substring(0, 1) = "*" Then
                        xdocumento = MT_DOCUMENTO.r_Valor.Substring(1)
                    Else
                        xdocumento = MT_DOCUMENTO.r_Valor
                    End If

                    Select Case MT_DOCUMENTO.r_Valor.Substring(0, 1)
                        Case "*" : xcondicion += "and v.documento like '%" + xdocumento + "%' "
                        Case Else : xcondicion += "and v.documento like '" + xdocumento + "%' "
                    End Select
                End If
            End If

            Dim xcond As String = "select top (@top) fecha, (case v.tipo when '01' then 'Factura' when '02' then 'Nota Débito' " & _
                                     "when '03' then 'Nota Crédito' when '04' then 'Nota Entrega' " & _
                                     "when '05' then 'Presupuesto' when '06' then 'Pedido' end) tipo, " & _
                                     "documento, fecha_vencimiento, dias, v.nombre nombre, v.ci_rif ci_rif, " & _
                                     "total, (case v.estatus when '0' then 'Activo' when '1' then 'Anulado' when '2' then 'Procesado' end) estatus, v.auto " & _
                                     "from ventas v, clientes c where " & xcondicion & " order by fecha desc"

            RaiseEvent _LlamarReceptor(xcond)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error Al Realizar Busqueda Avanzada: " + ex.Message, "ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub New(Optional ByVal xestatus_chimbo As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MostrarChimbo = xestatus_chimbo
    End Sub
End Class