Public Class BusquedaAvanzadaAdmCxP

    Event _LlamarReceptor(ByVal xsql As String)

    Dim estatus As String() = {"Pendientes", "Pendientes Vencidos", "Solventes", "Anulados"}
    Dim tipo As String() = {"Nacionales", "Extranjeros"}
    Dim xtb_grupo As DataTable

    Enum E_TiposDocumentos As Integer
        DocumentosPendientes = 0
        DocumentosPendientesVencidos = 1
        DocumentosSolventes = 2
        DocumentosAnulados = 3
    End Enum

    Dim xmostrar_estatus As Boolean

    Property _MostrarEstatus() As Boolean
        Get
            Return xmostrar_estatus
        End Get
        Set(ByVal value As Boolean)
            xmostrar_estatus = value
        End Set
    End Property

    Dim xsalida As Boolean
    Property _Salida() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Sub ApagarControles()
        Me.MCB_TIPO.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MCB_ESTATUS.Enabled = False
        Me.MT_DOCUMENTO.Enabled = False
    End Sub

    Sub CargarData()
        _Salida = False
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

    Private Sub BusquedaAvanzada_AdmCC_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _Salida = False Then
            Dim xresultado As DialogResult = MessageBox.Show("Estas De Acuerdo En Salir Sin Procesar La Consulta ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
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

            Dim xcondicion As String = "where cxp.auto<>'' "

            Dim xdocumento As String = ""

            If Me.MCHB_GRUPO.Checked Then
                xcondicion += "and proveedores.auto_grupo ='" + Me.MCB_GRUPO.SelectedValue + "' "
            End If

            If Me.MCHB_ESTATUS.Checked Then
                Select Case MCB_ESTATUS.SelectedIndex
                    Case E_TiposDocumentos.DocumentosPendientes
                        xcondicion += "and cxp.cancelado='0' and cxp.tipo_documento<>'PAG' and cxp.estatus='0' "
                    Case E_TiposDocumentos.DocumentosPendientesVencidos
                        xcondicion += "and cxp.cancelado='0' and cxp.fecha_vencimiento<getdate() and cxp.tipo_documento<>'PAG' and cxp.estatus='0' "
                    Case E_TiposDocumentos.DocumentosSolventes
                        xcondicion += "and cxp.cancelado='1' and cxp.tipo_documento<>'PAG' and cxp.estatus='0' "
                    Case E_TiposDocumentos.DocumentosAnulados
                        xcondicion += "and cxp.estatus='1' and cxp.tipo_documento<>'PAG' "
                End Select
            End If

            If Me.MCHB_TIPO.Checked Then
                xcondicion += IIf(Me.MCB_TIPO.SelectedIndex = 0, " and proveedores.tipoorigen='Nacional' ", " and proveedores.tipoorigen='Extranjero' ")
            End If

            If Me.MCHB_DOCUMENTO.Checked Then
                If MT_DOCUMENTO.r_Valor <> "" Then
                    If MT_DOCUMENTO.r_Valor.Substring(0, 1) = "*" Then
                        xdocumento = MT_DOCUMENTO.r_Valor.Substring(1)
                    Else
                        xdocumento = MT_DOCUMENTO.r_Valor
                    End If

                    Select Case MT_DOCUMENTO.r_Valor.Substring(0, 1)
                        Case "*" : xcondicion += "and cxp.documento like '%" + xdocumento + "%' "
                        Case Else : xcondicion += "and cxp.documento like '" + xdocumento + "%' "
                    End Select
                End If
            End If

            RaiseEvent _LlamarReceptor(xcondicion)
            _Salida = True
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error Al Realizar Busqueda Avanzada: " + ex.Message, "ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class