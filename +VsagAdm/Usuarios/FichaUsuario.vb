Imports DataSistema.MiDataSistema.DataSistema

Public Class FichaUsuario
    Dim pb_tm As Size
    Dim xf_accion As TipoAccionFicha
    Dim xficha As FichaGlobal.c_Usuario
    Dim xestatus As String() = {"Activo", "Inactivo"}

    Dim xtb As DataTable
    Dim xtb_grupos As DataTable
    Dim xbs As BindingSource
    Dim xbs_grupos As BindingSource

    Sub ApagarEncenderControles(ByVal xestatus As Boolean)
        Me.PB_1.Enabled = xestatus
        Me.PB_2.Enabled = xestatus
        Me.PB_3.Enabled = xestatus
        Me.MisGrid1.Enabled = xestatus

        Me.BT_GRABAR.Enabled = Not xestatus
        Me.MT_CLAV_USUARIO.Enabled = Not xestatus
        Me.MT_COD_USUARIO.Enabled = Not xestatus
        Me.MT_NOM_USUARIO.Enabled = Not xestatus
        Me.MCB_ESTATUS.Enabled = Not xestatus
        Me.MCB_GRUPO.Enabled = Not xestatus
    End Sub

    Property _FichaAccion() As TipoAccionFicha
        Get
            Return xf_accion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xf_accion = value

            If value = TipoAccionFicha.Consultar Then
                ApagarEncenderControles(True)
                Me.MisGrid1.Select()
                Me.MisGrid1.Focus()
            End If

            If value = TipoAccionFicha.Adicionar Then
                Me.MT_CLAV_USUARIO.Text = ""
                Me.MT_COD_USUARIO.Text = ""
                Me.MT_NOM_USUARIO.Text = ""
                Me.MCB_ESTATUS.SelectedIndex = 0
                Me.MCB_GRUPO.SelectedIndex = 0

                ApagarEncenderControles(False)
                Me.MT_NOM_USUARIO.Select()
                Me.MT_NOM_USUARIO.Focus()
            End If

            If value = TipoAccionFicha.Modificar Then
                ApagarEncenderControles(False)
                Me.MT_NOM_USUARIO.Select()
                Me.MT_NOM_USUARIO.Focus()
            End If
        End Set
    End Property

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
            .Size = New Size(pb_tm.Width + factor, pb_tm.Height + factor)
            .Cursor = Cursors.Hand
        End With
    End Sub

    Private Sub FichaUsuario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FichaAccion = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If _FichaAccion = TipoAccionFicha.Adicionar Or _FichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Estas Seguro De Peder Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                    Actualiza()
                    Me._FichaAccion = TipoAccionFicha.Consultar
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FichaUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                AgregarRegistro()
            End If
        End If
        If e.KeyValue = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                ModificarRegistro()
            End If
        End If
        If e.KeyValue = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                EliminarRegistro()
            End If
        End If
        If e.KeyValue = Keys.F4 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Adicionar Or _FichaAccion = TipoAccionFicha.Modificar Then
                Grabar()
            End If
        End If
    End Sub

    Sub Inicializa()
        Try
            Me._FichaAccion = TipoAccionFicha.Consultar
            pb_tm = PB_1.Size

            xtb = New DataTable
            xbs = New BindingSource(xtb, "")

            xtb_grupos = New DataTable
            xbs_grupos = New BindingSource(xtb_grupos, "")

            xficha = New FichaGlobal.c_Usuario

            With Me.MT_NOM_USUARIO
                .Text = ""
                .MaxLength = xficha.RegistroDato.c_UsuarioNombre.c_Largo
            End With
            With Me.MT_COD_USUARIO
                .Text = ""
                .MaxLength = xficha.RegistroDato.c_UsuarioCodigo.c_Largo
            End With
            With Me.MT_CLAV_USUARIO
                .Text = ""
                .MaxLength = xficha.RegistroDato.c_UsuarioClave.c_Largo
            End With

            With Me.MCB_ESTATUS
                .DataSource = xestatus
                .SelectedIndex = 0
            End With

            CargarGrupos()
            With Me.MCB_GRUPO
                .DataSource = XBS_GRUPOS
                .DisplayMember = "NOMBRE"
                .ValueMember = "auto"
            End With

            AddHandler xficha.ActualizarFicha, AddressOf CargarData
            xtb = New DataTable
            xbs = New BindingSource(xtb, "")
            CargarData()
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With MisGrid1
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)

                AddHandler .CellFormatting, AddressOf MiFormato
            End With

            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error *** ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If MisGrid1.Rows(e.RowIndex).Cells("estatus").Value.ToString.Trim.ToUpper <> "ACTIVO" Then
            MisGrid1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from usuarios order by nombre", xtb)
    End Sub

    Sub CargarGrupos()
        g_MiData.F_GetData("select nombre nom, * from grupo_usuario order by nombre", xtb_grupos)
        Actualiza()
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xficha.M_CargarRegistro(CType(xbs.Current, System.Data.DataRowView).Row)
        Else
            xficha.RegistroDato.LimpiarRegistro()
        End If

        Me.MT_NOM_USUARIO.Text = xficha.RegistroDato._NombreUsuario
        Me.MT_COD_USUARIO.Text = xficha.RegistroDato._CodigoUsuario
        Me.MT_CLAV_USUARIO.Text = ""

        Me.MCB_GRUPO.Enabled = True
        Me.MCB_GRUPO.SelectedValue = xficha.RegistroDato._AutoGrupo
        Me.MCB_GRUPO.Enabled = False

        If xficha.RegistroDato._TipoEstatus Then
            Me.MCB_ESTATUS.SelectedIndex = 0
        Else
            Me.MCB_ESTATUS.SelectedIndex = 1
        End If

        Me.E_REGISTROS.Text = xbs.Count.ToString
    End Sub

    Private Sub FichaUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FichaUsuario_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarRegistro()
    End Sub

    Sub EliminarRegistro()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloUsuario_Eliminar.F_Permitir()

            If MessageBox.Show("Estas Seguro De Eliminar Dicho Usuario ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                xficha.F_EliminaRegistro(xficha.RegistroDato._AutoUsuario)
                MessageBox.Show("Usuario Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarRegistro()
    End Sub

    Sub AgregarRegistro()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloUsuario_Ingresar.F_Permitir()
            Me._FichaAccion = TipoAccionFicha.Adicionar
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        Grabar()
    End Sub

    Sub Grabar()
        If _FichaAccion = TipoAccionFicha.Adicionar Then
            If Me.MT_NOM_USUARIO.r_Valor <> "" Then
                If MessageBox.Show("Estas Seguro De Agregar Este Nuevo Usuario?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim xuser As New FichaGlobal.c_Usuario.c_NuevoUsuario
                        With xuser
                            ._AutoGrupo = Me.MCB_GRUPO.SelectedValue
                            ._ClaveUsuario = Me.MT_CLAV_USUARIO.r_Valor
                            ._CodigoUsuario = Me.MT_COD_USUARIO.r_Valor
                            ._EstatusUsuario = IIf(Me.MCB_ESTATUS.SelectedIndex = 0, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._NombreUsuario = Me.MT_NOM_USUARIO.r_Valor
                        End With
                        xficha.F_IngresaRegistro(xuser)
                        Me._FichaAccion = TipoAccionFicha.Consultar
                        MessageBox.Show("Usuario Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Actualiza()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Else
                Me.MT_NOM_USUARIO.Select()
                Me.MT_NOM_USUARIO.Focus()
                MessageBox.Show("Error En El Nombre Del Usuario, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If Me.MT_NOM_USUARIO.r_Valor <> "" Then
                If MessageBox.Show("Estas Seguro De Modificar Este Usuario?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim xuser As New FichaGlobal.c_Usuario.c_ModificaUsuario
                        With xuser
                            ._AutoGrupo = Me.MCB_GRUPO.SelectedValue
                            ._ClaveUsuario = Me.MT_CLAV_USUARIO.r_Valor
                            ._CodigoUsuario = Me.MT_COD_USUARIO.r_Valor
                            ._EstatusUsuario = IIf(Me.MCB_ESTATUS.SelectedIndex = 0, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._NombreUsuario = Me.MT_NOM_USUARIO.r_Valor
                            ._AutoUsuario = xficha.RegistroDato._AutoUsuario
                            ._IdSeguridad = xficha.RegistroDato._IdSeguridad
                        End With
                        xficha.F_ModificaRegistro(xuser)
                        Me._FichaAccion = TipoAccionFicha.Consultar
                        MessageBox.Show("Usuario Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Actualiza()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Else
                Me.MT_NOM_USUARIO.Select()
                Me.MT_NOM_USUARIO.Focus()
                MessageBox.Show("Error En El Nombre Del Usuario, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarRegistro()
    End Sub

    Sub ModificarRegistro()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloUsuario_Modificar.F_Permitir()
            Me._FichaAccion = TipoAccionFicha.Modificar
            Me.MT_CLAV_USUARIO.Text = xficha.RegistroDato._ClaveUsuario
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LINK_GRUPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_GRUPO.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoUsuario.F_Permitir()

            Dim xForm As New Plantilla_1(New GrupoUsuario)
            AddHandler xForm.ActualizarFicha, AddressOf CargarGrupos
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FichaUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class