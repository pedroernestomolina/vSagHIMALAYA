Public Class BusAvanzadaVendedor
    Event LlamarReceptor(ByVal xsql As String)

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

    Private Sub BusAvanzadaVendedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub BusAvanzadaVendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub BusAvanzadaVendedor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub ApagarControles()
        Me.MCB_ESTATUS.Enabled = False
        Me.MCB_TIPO_COMISION.Enabled = False
        Me.MF_DESDE.Enabled = False
        Me.MF_HASTA.Enabled = False
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

    Sub Inicializa()
        Try
            ApagarControles()
            CargarData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BusAvanzadaVendedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EstatusSalida = False
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

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        Dim xfil As String = ""

        Try
            If Me.MCHB_TPO_COMISION.Checked Then
                xfil += " and tipo_comision='" + Me.MCB_TIPO_COMISION.SelectedIndex.ToString + "'"
            End If

            If Me.MCHB_ESTATUS.Checked Then
                xfil += " and estatus='" + Me.MCB_ESTATUS.SelectedValue.ToString + "'"
            End If

            If Me.MCHB_FECHA.Checked Then
                If MF_DESDE.Checked Then
                    xfil += " and fecha_alta>='" + Me.MF_DESDE.r_Valor.ToShortDateString + "'"
                End If
                If MF_HASTA.Checked Then
                    xfil += " and fecha_alta<='" + Me.MF_HASTA.r_Valor.ToShortDateString + "'"
                End If
            End If

            Dim xsql As String = "select nombre nom, telefono1 tel, celular1 cel, * from vendedores where auto<>'' "
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
End Class