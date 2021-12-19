Imports DataSistema.MiDataSistema.DataSistema

Public Class SeriesFiscales
    Dim PB_TM As Size
    Dim bs As BindingSource
    Dim xtb As DataTable
    Dim xseriesfiscales As FichaGlobal.c_SeriesFiscales
    Dim xaccion As TipoAccionFicha

    Property AccionFicha() As TipoAccionFicha
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xaccion = value
        End Set
    End Property

    Private Sub SeriesFiscales_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If AccionFicha = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If MessageBox.Show("Deseas Salir Sin Grabar Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Me.MT_PREFIJO.Select()
            Else
                IniciaFicha()
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub PB_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseEnter, PB_2.MouseEnter, PB_3.MouseEnter
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseHover, PB_2.MouseHover, PB_3.MouseHover
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseLeave, PB_2.MouseLeave, PB_3.MouseLeave
        EntrarSalirPB(sender, EntradaSalida.Salida)
    End Sub

    Sub EntrarSalirPB(ByVal sender As Object, ByVal xtipo As EntradaSalida)
        Dim PB As PictureBox = CType(sender, PictureBox)
        Dim factor As Integer = 0
        If xtipo = EntradaSalida.Entrada Then
            factor = -5
        End If

        With PB
            .Size = New Size(PB_TM.Width + factor, PB_TM.Height + factor)
            .Cursor = Cursors.Hand
        End With
    End Sub

    Private Sub SeriesFiscales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = False AndAlso e.Control = False Then
            If e.KeyCode = Keys.F1 Then
                AgregarSerie()
            ElseIf e.KeyCode = Keys.F2 Then
                ModificarSerie()
            ElseIf e.KeyCode = Keys.F3 Then
                EliminarSerie()
            End If
        End If
    End Sub

    Private Sub SeriesFiscales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub SeriesFiscales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PB_TM = PB_1.Size
    End Sub

    Private Sub SeriesFiscales_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializa()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub ActualizarLista()
        g_MiData.F_GetData("select nombre pre, correlativo cor, nrf ser, estatus est , * from series_fiscales order by nombre", xtb)
        Me.ToolStripStatusLabel3.Text = "Cantidad De Registro(s) Encontrado(s): " + xtb.Rows.Count.ToString
    End Sub

    Sub Inicializa()
        xtb = New DataTable
        xseriesfiscales = New FichaGlobal.c_SeriesFiscales
        Me.AccionFicha = TipoAccionFicha.Consultar

        AddHandler xseriesfiscales.Actualizar, AddressOf ActualizarLista
        ActualizarLista()
        Me.MCB_ESTATUS.DataSource = xseriesfiscales.RegistroDato.r_ListaOpciones

        With Me.MT_PREFIJO
            .MaxLength = xseriesfiscales.RegistroDato.c_PreFijoSerie.c_Largo
            .Text = ""
            .Enabled = False
        End With
        With Me.MT_SERIAL
            .MaxLength = xseriesfiscales.RegistroDato.c_SerialFiscal.c_Largo
            .Text = ""
            .Enabled = False
        End With
        With Me.MN_CORRELATIVO
            ._ConSigno = False
            ._Formato = "999999"
            .Text = "0"
            .Enabled = False
        End With

        Me.MCHB_NC.Enabled = False
        Me.MCHB_ND.Enabled = False
        Me.MCHB_NE.Enabled = False
        Me.MCHB_VENTA.Enabled = False
        Me.MCB_ESTATUS.Enabled = False
        Me.BT_GRABAR.Enabled = False
        Me.MisGrid1.Select()
        Me.MisGrid1.Focus()

        bs = New BindingSource(xtb, "")
        AddHandler bs.PositionChanged, AddressOf ActualizarPosicion
        ActualizaPosicion()

        With MisGrid1
            .Columns.Add("col0", "PreFijo")
            .Columns.Add("col1", "Correlativo")
            .Columns.Add("col2", "Serial Fiscal")
            .Columns.Add("col3", "Estatus")

            .Columns(1).Width = 150
            .Columns(3).Width = 150
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            AddHandler .CellFormatting, AddressOf ActualizarFormatoRegistro

            .DataSource = bs
            .Columns(0).DataPropertyName = "pre"
            .Columns(1).DataPropertyName = "cor"
            .Columns(2).DataPropertyName = "ser"
            .Columns(3).DataPropertyName = "est"

            .Ocultar(5)
        End With

        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Sub ActualizarFormatoRegistro(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 1 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
        If MisGrid1.Rows(e.RowIndex).Cells("est").Value.ToString.Trim.ToUpper <> "ACTIVO" Then
            MisGrid1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Sub ActualizarPosicion()
        ActualizaPosicion()
    End Sub

    Sub ActualizaPosicion()
        If bs.Current IsNot Nothing Then
            Dim xdr As DataRow = CType(bs.Current, System.Data.DataRowView).Row
            xseriesfiscales.M_CargarFicha(xdr)

            Me.MT_PREFIJO.Text = xseriesfiscales.RegistroDato.r_PrefijoSerie
            Me.MT_SERIAL.Text = xseriesfiscales.RegistroDato.r_SerialFiscal
            Me.MN_CORRELATIVO.Text = xseriesfiscales.RegistroDato.r_CorrelativoSerie.ToString
            Me.MCB_ESTATUS.SelectedIndex = IIf(xseriesfiscales.RegistroDato.r_EstatusSerie, 0, 1)
            Me.MCHB_VENTA.Checked = xseriesfiscales.RegistroDato.r_EstatusParaVentas
            Me.MCHB_NE.Checked = xseriesfiscales.RegistroDato.r_EstatusParaNE
            Me.MCHB_ND.Checked = xseriesfiscales.RegistroDato.r_EstatusParaND
            Me.MCHB_NC.Checked = xseriesfiscales.RegistroDato.r_EstatusParaNC
        End If
    End Sub

    Private Sub BT_SALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SALIR.Click
        Me.Close()
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarSerie()
    End Sub

    Sub Switcher(ByVal xopc As Boolean)
        Me.MT_PREFIJO.Enabled = xopc
        Me.MT_SERIAL.Enabled = xopc
        Me.MCHB_NC.Enabled = xopc
        Me.MCHB_ND.Enabled = xopc
        Me.MCHB_NE.Enabled = xopc
        Me.MCHB_VENTA.Enabled = xopc
        Me.MCB_ESTATUS.Enabled = xopc
        Me.MN_CORRELATIVO.Enabled = xopc
        Me.BT_GRABAR.Enabled = xopc
        Me.BT_SALIR.Enabled = Not xopc
        Me.MisGrid1.Enabled = Not xopc

        Me.PB_1.Enabled = Not xopc
        Me.PB_2.Enabled = Not xopc
        Me.PB_3.Enabled = Not xopc

        If xopc Then
            Me.MT_PREFIJO.Select()
            Me.MT_PREFIJO.Focus()
        Else
            Me.MisGrid1.Select()
            Me.MisGrid1.Focus()
        End If
    End Sub

    Sub AgregarSerie()
        Try
            If AccionFicha = TipoAccionFicha.Consultar Then
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_SeriesFiscales_Ingresar.F_Permitir()

                Me.AccionFicha = TipoAccionFicha.Adicionar
                Switcher(True)

                Me.MT_PREFIJO.Text = ""
                Me.MT_SERIAL.Text = ""
                Me.MN_CORRELATIVO.Text = ""
                Me.MCB_ESTATUS.SelectedIndex = 0
                Me.MCHB_NC.Checked = False
                Me.MCHB_ND.Checked = False
                Me.MCHB_NE.Checked = False
                Me.MCHB_VENTA.Checked = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Sub IniciaFicha()
        Switcher(False)
        ActualizaPosicion()
        Me.AccionFicha = TipoAccionFicha.Consultar
        Me.MisGrid1.Select()
        Me.MisGrid1.Focus()
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        If MT_PREFIJO.r_Valor <> "" Then
            Dim xms As String = "Deseas Agregar Este Nuevo Registro Al Sistema ?"
            If Me.AccionFicha = TipoAccionFicha.Modificar Then
                xms = "Deseas Actualizar Estos Cambios Al Sistema ?"
            End If

            If MessageBox.Show(xms, "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    If Me.AccionFicha = TipoAccionFicha.Adicionar Then
                        Dim xregistro As New FichaGlobal.c_SeriesFiscales.c_RegistroMovimientoAgregar
                        With xregistro
                            ._Correlativo = Me.MN_CORRELATIVO._Valor
                            ._EstatusFiscal = TipoEstatus.Inactivo
                            ._EstatusParaNC = IIf(Me.MCHB_NC.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._EstatusParaND = IIf(Me.MCHB_ND.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._EstatusParaNE = IIf(Me.MCHB_NE.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._EstatusParaVentas = IIf(Me.MCHB_VENTA.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._EstatusSerie = IIf(Me.MCB_ESTATUS.SelectedIndex = 0, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._PreFijoSerie = Me.MT_PREFIJO.r_Valor
                            ._SerialFiscal = Me.MT_SERIAL.r_Valor
                        End With

                        xseriesfiscales.F_AgregarNuevaSerie(xregistro)
                    Else
                        Dim xregistro As New FichaGlobal.c_SeriesFiscales.c_RegistroMovimientoEditar
                        With xregistro
                            ._Correlativo = Me.MN_CORRELATIVO._Valor
                            ._EstatusParaNC = IIf(Me.MCHB_NC.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._EstatusParaND = IIf(Me.MCHB_ND.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._EstatusParaNE = IIf(Me.MCHB_NE.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._EstatusParaVentas = IIf(Me.MCHB_VENTA.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._EstatusSerie = IIf(Me.MCB_ESTATUS.SelectedIndex = 0, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._PreFijoSerie = Me.MT_PREFIJO.r_Valor
                            ._SerialFiscal = Me.MT_SERIAL.r_Valor
                            ._IdSeguridad = Me.xseriesfiscales.RegistroDato.r_IdSeguridad
                        End With

                        xseriesfiscales.F_ModificarSerie(xseriesfiscales.RegistroDato.r_AutomaticoSerie, xregistro)
                    End If
                    Me.AccionFicha = TipoAccionFicha.Consultar
                    Switcher(False)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MT_PREFIJO.Select()
                End Try
            Else
                Me.MT_PREFIJO.Select()
            End If
        Else
            MessageBox.Show("Error... Faltan Datos Por Completar", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_PREFIJO.Select()
        End If
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarSerie()
    End Sub

    Sub EliminarSerie()
        If AccionFicha = TipoAccionFicha.Consultar Then
            Try
                If bs.Current IsNot Nothing Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_SeriesFiscales_Eliminar.F_Permitir()

                    If MessageBox.Show("Estas Seguro De Eliminar Esta Serie ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        xseriesfiscales.F_EliminarSerie(xseriesfiscales.RegistroDato.r_AutomaticoSerie)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarSerie()
    End Sub

    Sub ModificarSerie()
        Try
            If AccionFicha = TipoAccionFicha.Consultar Then
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_SeriesFiscales_Modificar.F_Permitir()

                Me.AccionFicha = TipoAccionFicha.Modificar
                Switcher(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class