Public Class BusAvanzadaProveedor
    Event LlamarReceptor(ByVal xsql As String)

    Dim limite As String() = {"Mayor o Igual A", "Menor o Igual A"}
    Dim estatus As String() = {"Activo / Habilitado", "Inactivo / Desactivado"}
    Dim origen As String() = {"Nacional", "Extranjero"}

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

    Private Sub BusAvanzadaProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If EstatusSalida = True Then
            e.Cancel = False
        Else
            If MessageBox.Show("Estas Seguro De Abandonar Esta Ficha De Busqueda ?", "*** Mensaje De Alerta *** ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BusAvanzadaProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Sub ApagarControles()
        Me.MN_LIMITE_CR.Enabled = False
        Me.MCB_CREDITO.Enabled = False
        Me.MCB_DENOMINACION.Enabled = False
        Me.MCB_ESTATUS.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MCB_ORIGEN.Enabled = False
        Me.MCB_LIMITE_CR.Enabled = False
        Me.MF_DESDE.Enabled = False
        Me.MF_HASTA.Enabled = False

        With Me.MN_LIMITE_CR
            ._ConSigno = False
            ._Formato = "9999999.99"
            .Text = "0.0"
            .Enabled = False
        End With
    End Sub

    Sub CargarData()
        xtb_grupo = New DataTable
        g_MiData.F_GetData("select nombre,auto from grupo_proveedor order by nombre", xtb_grupo)
        With Me.MCB_GRUPO
            .DataSource = xtb_grupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_DENOMINACION
            .DataSource = g_MiData.f_FichaProveedores.f_Proveedor.p_DenominacionFiscal
            .SelectedIndex = 0
        End With

        With Me.MCB_LIMITE_CR
            .DataSource = limite
            .SelectedIndex = 0
        End With

        With Me.MCB_ESTATUS
            .DataSource = estatus
            .SelectedIndex = 0
        End With

        With Me.MCB_CREDITO
            .DataSource = estatus
            .SelectedIndex = 0
        End With

        With Me.MCB_ORIGEN
            .DataSource = origen
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

    Private Sub BusAvanzadaProveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EstatusSalida = False
    End Sub

    Private Sub MCHB_GRUPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_GRUPO.CheckedChanged
        Me.MCB_GRUPO.Enabled = MCHB_GRUPO.Checked
    End Sub

    Private Sub MCHB_DENOMINACION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_DENOMINACION.CheckedChanged
        Me.MCB_DENOMINACION.Enabled = MCHB_DENOMINACION.Checked
    End Sub

    Private Sub MCHB_CREDITO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_CREDITO.CheckedChanged
        Me.MCB_CREDITO.Enabled = MCHB_CREDITO.Checked
    End Sub

    Private Sub MCHB_LIMITE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_LIMITE.CheckedChanged
        Me.MCB_LIMITE_CR.Enabled = MCHB_LIMITE.Checked
        Me.MN_LIMITE_CR.Enabled = Me.MCHB_LIMITE.Checked
    End Sub

    Private Sub MCHB_ESTATUS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ESTATUS.CheckedChanged
        Me.MCB_ESTATUS.Enabled = MCHB_ESTATUS.Checked
    End Sub

    Private Sub MCHB_FECHA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_FECHA.CheckedChanged
        Me.MF_DESDE.Enabled = MCHB_FECHA.Checked
        Me.MF_HASTA.Enabled = MCHB_FECHA.Checked
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        Dim xbus_prv As String = ""
        Dim xfil As String = ""

        Try
            If Me.MCHB_GRUPO.Checked Then
                xfil += " and auto_grupo='" + Me.MCB_GRUPO.SelectedValue + "'"
            End If

            If Me.MCHB_DENOMINACION.Checked Then
                xfil += " and denominacion_fiscal='" + Me.MCB_DENOMINACION.SelectedItem.ToString.Trim + "'"
            End If

            If Me.MCHB_CREDITO.Checked Then
                xfil += IIf(Me.MCB_CREDITO.SelectedIndex = 0, " and credito='1'", " and credito='0'")
            End If

            If Me.MCHB_ESTATUS.Checked Then
                xfil += IIf(Me.MCB_ESTATUS.SelectedIndex = 0, " and estatus='Activo'", " and estatus='Inactivo'")
            End If

            If Me.MCHB_ORIGEN.Checked Then
                xfil += " and tipoorigen='" + Me.MCB_ORIGEN.SelectedItem.ToString.Trim + "'"
            End If

            If Me.MCHB_LIMITE.Checked Then
                If MCB_LIMITE_CR.SelectedIndex = 0 Then
                    xfil += " and limite_credito>=" + Me.MN_LIMITE_CR._Valor.ToString.Replace(",", ".")
                Else
                    xfil += " and limite_credito<=" + Me.MN_LIMITE_CR._Valor.ToString.Replace(",", ".")
                End If
            End If

            If Me.MCHB_FECHA.Checked Then
                If MF_DESDE.Checked Then
                    xfil += " and fecha_alta>='" + Me.MF_DESDE.r_Valor.ToShortDateString + "'"
                End If
                If MF_HASTA.Checked Then
                    xfil += " and fecha_alta<='" + Me.MF_HASTA.r_Valor.ToShortDateString + "'"
                End If
            End If

            Dim xsql As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from proveedores where auto<>'' "
            xsql += xfil + " order by nombre"

            EstatusSalida = True
            RaiseEvent LlamarReceptor(xsql)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error Al Realizar Busqueda Avanzada: " + ex.Message, "ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub BusAvanzadaProveedor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub MCHB_ORIGEN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ORIGEN.CheckedChanged
        Me.MCB_ORIGEN.Enabled = MCHB_ORIGEN.Checked
    End Sub
End Class