Public Class BusAvanzadaCliente
    Event LlamarReceptor(ByVal xsql As String)

    Dim limite As String() = {"Mayor o Igual A", "Menor o Igual A"}
    Dim estatus As String() = {"Activo / Habilitado", "Inactivo / Desactivado"}
    Dim dias_cobranza As String() = {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"}

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

    Private Sub BusAvanzadaCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub BusAvanzadaCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub BusAvanzadaCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EstatusSalida = False
    End Sub

    Sub ApagarControles()
        Me.MCB_AFILIACION.Enabled = False
        Me.MN_LIMITE_CR.Enabled = False
        Me.MCB_COBRADOR.Enabled = False
        Me.MCB_CREDITO.Enabled = False
        Me.MCB_DENOMINACION.Enabled = False
        Me.MCB_ESTADO.Enabled = False
        Me.MCB_ESTATUS.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MCB_LIMITE_CR.Enabled = False
        Me.MCB_PRECIO.Enabled = False
        Me.MCB_PUNTOS.Enabled = False
        Me.MCB_VENDEDOR.Enabled = False
        Me.MCB_ZONA.Enabled = False
        Me.MCB_DIA_COBRANZA.Enabled = False
        Me.MF_DESDE.Enabled = False
        Me.MF_HASTA.Enabled = False

        With Me.MN_PUNTOS
            ._ConSigno = False
            ._Formato = "9999999.99"
            .Text = "0.0"
            .Enabled = False
        End With

        With Me.MN_LIMITE_CR
            ._ConSigno = False
            ._Formato = "9999999.99"
            .Text = "0.0"
            .Enabled = False
        End With
    End Sub

    Sub CargarData()
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

        With Me.MCB_DENOMINACION
            .DataSource = g_MiData.f_FichaClientes.f_Clientes.p_DenominacionFiscal
            .SelectedIndex = 0
        End With

        With Me.MCB_PRECIO
            .DataSource = g_MiData.f_FichaClientes.f_Clientes.p_TipoPrecioAsignado
            .SelectedIndex = 0
        End With

        With Me.MCB_LIMITE_CR
            .DataSource = limite
            .SelectedIndex = 0
        End With

        With Me.MCB_PUNTOS
            .DataSource = limite
            .SelectedIndex = 0
        End With

        With Me.MCB_ESTATUS
            .DataSource = estatus
            .SelectedIndex = 0
        End With

        With Me.MCB_AFILIACION
            .DataSource = estatus
            .SelectedIndex = 0
        End With

        With Me.MCB_CREDITO
            .DataSource = estatus
            .SelectedIndex = 0
        End With

        With Me.MCB_DIA_COBRANZA
            .DataSource = dias_cobranza
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

    Private Sub BusAvanzadaCliente_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
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

    Private Sub MCHB_DENOMINACION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_DENOMINACION.CheckedChanged
        Me.MCB_DENOMINACION.Enabled = MCHB_DENOMINACION.Checked
    End Sub

    Private Sub MCHB_DIA_COBRANZA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_DIA_COBRANZA.CheckedChanged
        Me.MCB_DIA_COBRANZA.Enabled = MCHB_DIA_COBRANZA.Checked
    End Sub

    Private Sub MisCheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_PRECIO.CheckedChanged
        Me.MCB_PRECIO.Enabled = MCHB_PRECIO.Checked
    End Sub

    Private Sub MCHB_CREDITO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_CREDITO.CheckedChanged
        Me.MCB_CREDITO.Enabled = MCHB_CREDITO.Checked
    End Sub

    Private Sub MCHB_LIMITE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_LIMITE.CheckedChanged
        Me.MCB_LIMITE_CR.Enabled = MCHB_LIMITE.Checked
        Me.MN_LIMITE_CR.Enabled = Me.MCHB_LIMITE.Checked
    End Sub

    Private Sub MCHB_VENDEDOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_VENDEDOR.CheckedChanged
        Me.MCB_VENDEDOR.Enabled = MCHB_VENDEDOR.Checked
    End Sub

    Private Sub MCHB_COBRADOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_COBRADOR.CheckedChanged
        Me.MCB_COBRADOR.Enabled = MCHB_COBRADOR.Checked
    End Sub

    Private Sub MCHB_ESTATUS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ESTATUS.CheckedChanged
        Me.MCB_ESTATUS.Enabled = MCHB_ESTATUS.Checked
    End Sub

    Private Sub MCHB_PUNTOS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_PUNTOS.CheckedChanged
        Me.MCB_PUNTOS.Enabled = MCHB_PUNTOS.Checked
        Me.MN_PUNTOS.Enabled = Me.MCHB_PUNTOS.Checked
    End Sub

    Private Sub MCHB_AFILIACION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_AFILIACION.CheckedChanged
        Me.MCB_AFILIACION.Enabled = MCHB_AFILIACION.Checked
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

            If Me.MCHB_ESTADO.Checked Then
                xfil += " and auto_estado='" + Me.MCB_ESTADO.SelectedValue + "'"
            End If

            If Me.MCHB_ZONA.Checked Then
                xfil += " and auto_zona='" + Me.MCB_ZONA.SelectedValue + "'"
            End If

            If Me.MCHB_DENOMINACION.Checked Then
                xfil += " and denominacion_fiscal='" + Me.MCB_DENOMINACION.SelectedItem.ToString.Trim + "'"
            End If

            If Me.MCHB_PRECIO.Checked Then
                Select Case Me.MCB_PRECIO.SelectedIndex
                    Case 0
                        xfil += " and tarifa='1'"
                    Case 1
                        xfil += " and tarifa='2'"
                End Select
            End If

            If Me.MCHB_DIA_COBRANZA.Checked Then
                Select Case Me.MCB_DIA_COBRANZA.SelectedIndex
                    Case 0 : xfil += " and dia1='1'"
                    Case 1 : xfil += " and dia2='1'"
                    Case 2 : xfil += " and dia3='1'"
                    Case 3 : xfil += " and dia4='1'"
                    Case 4 : xfil += " and dia5='1'"
                    Case 5 : xfil += " and dia6='1'"
                    Case 6 : xfil += " and dia7='1'"
                End Select
            End If

            If Me.MCHB_CREDITO.Checked Then
                xfil += IIf(Me.MCB_CREDITO.SelectedIndex = 0, " and credito='1'", " and credito='0'")
            End If

            If Me.MCHB_ESTATUS.Checked Then
                xfil += IIf(Me.MCB_ESTATUS.SelectedIndex = 0, " and estatus='Activo'", " and estatus='Inactivo'")
            End If

            If Me.MCHB_COBRADOR.Checked Then
                xfil += " and auto_cobrador='" + Me.MCB_COBRADOR.SelectedValue + "'"
            End If

            If Me.MCHB_VENDEDOR.Checked Then
                xfil += " and auto_vendedor='" + Me.MCB_VENDEDOR.SelectedValue + "'"
            End If

            If Me.MCHB_DESCUENTO.Checked Then
                xfil += " and descuento>0"
            End If

            If Me.MCHB_CARGO.Checked Then
                xfil += " and recargo>0"
            End If

            If Me.MCHB_LIMITE.Checked Then
                If MCB_LIMITE_CR.SelectedIndex = 0 Then
                    xfil += " and limite_credito>=" + Me.MN_LIMITE_CR._Valor.ToString.Replace(",", ".")
                Else
                    xfil += " and limite_credito<=" + Me.MN_LIMITE_CR._Valor.ToString.Replace(",", ".")
                End If
            End If

            If Me.MCHB_PUNTOS.Checked Then
                If MCB_PUNTOS.SelectedIndex = 0 Then
                    xfil += " and puntos>=" + Me.MN_PUNTOS._Valor.ToString.Replace(",", ".")
                Else
                    xfil += " and puntos<=" + Me.MN_PUNTOS._Valor.ToString.Replace(",", ".")
                End If
            End If

            If Me.MCHB_AFILIACION.Checked Then
                xfil += IIf(Me.MCB_AFILIACION.SelectedIndex = 0, " and estatus_afiliado='1'", " and estatus_afiliado='0'")
            End If

            If Me.MCHB_FECHA.Checked Then
                If MF_DESDE.Checked Then
                    xfil += " and fecha_alta>='" + Me.MF_DESDE.r_Valor.ToShortDateString + "'"
                End If
                If MF_HASTA.Checked Then
                    xfil += " and fecha_alta<='" + Me.MF_HASTA.r_Valor.ToShortDateString + "'"
                End If
            End If

            Dim xsql As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where auto<>'' "
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