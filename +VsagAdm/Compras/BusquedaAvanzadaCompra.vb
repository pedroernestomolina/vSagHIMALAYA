Public Class BusquedaAvanzadaCompra
    Event _LlamarReceptor(ByVal xsql As String)

#Region "FUNCIONES SELECT"
    Const SELECT_COMPRAS As String = "select top(@top) c.fecha, " & _
                                         "(case c.tipo when '01' then 'Compra' " & _
                                         "             when '02' then 'Nota Débito' " & _
                                         "             when '03' then 'Nota Crédito' " & _
                                         "             when '04' then 'Orden Compra' end) tipo, " & _
                                         "documento, " & _
                                         "fecha_vencimiento, " & _
                                         "dias, " & _
                                         "c.nombre, " & _
                                         "c.ci_rif, " & _
                                         "c.total, " & _
                                         "(case c.estatus when '0' then 'Activo' " & _
                                         "              when '1' then 'Anulado' end) estatus, " & _
                                         "c.auto, c.n_serie " & _
                                     "from compras c, proveedores p "
#End Region

    Dim estatus As String() = {"Activo", "Anulados"}
    Dim tipo As String() = {"Nacionales", "Extranjeros"}
    Dim xtb_grupo As DataTable
    Dim xmostrar_estatus As Boolean

    Property _MostrarEstatus() As Boolean
        Get
            Return xmostrar_estatus
        End Get
        Set(ByVal value As Boolean)
            xmostrar_estatus = value
        End Set
    End Property

    Sub ApagarControles()
        Me.MCB_TIPO.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MCB_ESTATUS.Enabled = False
        Me.MT_DOCUMENTO.Enabled = False
        Me.MT_SERIE.Enabled = False
    End Sub

    Sub CargarData()
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

    Private Sub MCHB_TIPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_TIPO.CheckedChanged
        Me.MCB_TIPO.Enabled = MCHB_TIPO.Checked
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
            Dim xcondicion As String = "where "
            xcondicion += "c.tipo in ('01','02','03','04') and c.auto_entidad=p.auto "
            Dim xdocumento As String = ""

            If Me.MCHB_GRUPO.Checked Then
                xcondicion += "and p.auto_grupo ='" + Me.MCB_GRUPO.SelectedValue + "' "
            End If

            If Me.MCHB_ESTATUS.Checked Then
                xcondicion += IIf(Me.MCB_ESTATUS.SelectedIndex = 0, " and c.estatus='0' ", " and c.estatus='1' ")
            End If

            If Me.MCHB_TIPO.Checked Then
                xcondicion += IIf(Me.MCB_TIPO.SelectedIndex = 0, " and p.tipoorigen='Nacional' ", " and p.tipoorigen='Extranjero' ")
            End If

            If Me.MCHB_SERIE.Checked Then
                Dim xserie = ""
                If Me.MT_SERIE.Text.Trim <> "" Then
                    xserie = Me.MT_SERIE.Text.Trim + "%"
                    xcondicion += " and c.n_serie like '" + xserie + "'"
                End If
            End If

            If Me.MCHB_DOCUMENTO.Checked Then
                If MT_DOCUMENTO.r_Valor <> "" Then
                    If MT_DOCUMENTO.r_Valor.Substring(0, 1) = "*" Then
                        xdocumento = MT_DOCUMENTO.r_Valor.Substring(1)
                    Else
                        xdocumento = MT_DOCUMENTO.r_Valor
                    End If

                    Select Case MT_DOCUMENTO.r_Valor.Substring(0, 1)
                        Case "*" : xcondicion += "and c.documento like '%" + xdocumento + "%' "
                        Case Else : xcondicion += "and c.documento like '" + xdocumento + "%' "
                    End Select
                End If
            End If

            Dim xcond As String = SELECT_COMPRAS & xcondicion & " order by c.fecha desc"

            RaiseEvent _LlamarReceptor(xcond)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error Al Realizar Busqueda Avanzada: " + ex.Message, "ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BusquedaAvanzadaCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MCHB_SERIE_CheckedChanged(sender As Object, e As EventArgs) Handles MCHB_SERIE.CheckedChanged
        Me.MT_SERIE.Enabled = Me.MCHB_SERIE.Checked
    End Sub

End Class