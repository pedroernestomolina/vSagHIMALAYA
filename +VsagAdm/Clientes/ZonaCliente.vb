Imports DataSistema.MiDataSistema.DataSistema

Public Class ZonaCliente
    Event Actualizar()

    Dim pb_tm As Size
    Dim xds As DataSet
    Dim xtb_estado As DataTable
    Dim xtb_zona As DataTable
    Dim campo_p As DataColumn
    Dim campo_h As DataColumn
    Dim xrel_estado_zona As DataRelation

    Dim xbs_estado As BindingSource
    Dim xbs_zona As BindingSource

    Dim xaccion As TipoAccionFicha
    Dim xarbol As TreeNode

    Dim xfichazona As FichaClientes.c_Zonas

    Sub EncenderControles(ByVal xop As Boolean)
        Me.PB_1.Enabled = Not xop
        Me.PB_2.Enabled = Not xop
        Me.PB_3.Enabled = Not xop
        Me.MisGrid1.Enabled = Not xop
        Me.TreeView1.Enabled = Not xop

        Me.BT_GRABAR.Enabled = xop
        With Me.MT_ZONA
            If FichaAccion = TipoAccionFicha.Adicionar Then
                .Text = ""
            End If
            .Enabled = xop
            If xop = True Then
                .Select()
                .Focus()
            End If
        End With

        If xop = False Then
            If Me.TreeView1.Nodes.Count > 0 Then
                Me.TreeView1.SelectedNode = Me.TreeView1.Nodes(0)
            End If
            Me.MisGrid1.Focus()
            Me.MisGrid1.Select()
        End If
    End Sub

    Property FichaAccion() As TipoAccionFicha
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xaccion = value

            If value = TipoAccionFicha.Adicionar Then
                EncenderControles(True)
            End If

            If value = TipoAccionFicha.Consultar Then
                EncenderControles(False)
            End If

            If value = TipoAccionFicha.Modificar Then
                EncenderControles(True)
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

    Private Sub ZonaCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If FichaAccion = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If FichaAccion = TipoAccionFicha.Adicionar Or FichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Estas Seguro De Perder Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    FichaAccion = TipoAccionFicha.Consultar
                    e.Cancel = True
                Else
                    e.Cancel = True
                    Me.MT_ZONA.Select()
                End If
            End If
        End If
    End Sub

    Private Sub ZonaCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            If FichaAccion = TipoAccionFicha.Consultar Then
                FichaAccion = TipoAccionFicha.Adicionar
            End If
        End If
        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            If FichaAccion = TipoAccionFicha.Consultar Then
                ModificarZona()
            End If
        End If
        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            If FichaAccion = TipoAccionFicha.Consultar Then
                Eliminar()
            End If
        End If
    End Sub

    Private Sub ZonaCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ZonaCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_tm = PB_1.Size
    End Sub

    Private Sub ZonaCliente_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            xfichazona = New FichaClientes.c_Zonas
            AddHandler xfichazona.Actualizar, AddressOf EventoActualizar

            FichaAccion = TipoAccionFicha.Consultar

            xds = New DataSet
            xtb_estado = New DataTable("estado")
            g_MiData.F_GetData("select nombre,auto from estados order by nombre", xtb_estado)
            xds.Tables.Add(xtb_estado)

            xtb_zona = New DataTable("zona")
            g_MiData.F_GetData("select nombre nom,* from zona_cliente order by nombre", xtb_zona)
            xds.Tables.Add(xtb_zona)

            campo_p = xds.Tables("estado").Columns("auto")
            campo_h = xds.Tables("zona").Columns("auto_estado")

            xrel_estado_zona = New DataRelation("Estado_Zona", campo_p, campo_h)
            xds.Relations.Add(xrel_estado_zona)

            xbs_estado = New BindingSource(xds, xtb_estado.TableName)
            AddHandler xbs_estado.PositionChanged, AddressOf ActualizarZonas
            xbs_zona = New BindingSource(xbs_estado, "Estado_Zona")
            ActualizaZona()

            With Me.MT_ZONA
                .MaxLength = xfichazona.RegistroDato.c_NombreZona.c_Largo
            End With

            With MisGrid1
                .Columns.Add("col0", "Estados")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DataSource = xbs_estado
                .Columns(0).DataPropertyName = "nombre"

                .Ocultar(2)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EventoActualizar()
        Try
            RaiseEvent Actualizar()

            g_MiData.F_GetData("select nombre nom,* from zona_cliente order by nombre", xtb_zona)
            ActualizarZonas()
            If FichaAccion = TipoAccionFicha.Adicionar Then
                MessageBox.Show("Zona Creada Exitosamente... OK", "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If FichaAccion = TipoAccionFicha.Eliminar Then
                MessageBox.Show("Zona Eliminada Exitosamente... OK", "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If FichaAccion = TipoAccionFicha.Modificar Then
                MessageBox.Show("Zona Actualizada Exitosamente... OK", "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            FichaAccion = TipoAccionFicha.Consultar
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarZonas()
        ActualizaZona()
    End Sub

    Sub ActualizaZona()
        If xbs_estado.Current IsNot Nothing Then
            Dim xzona As TreeNode = Nothing
            Me.TreeView1.Nodes.Clear()

            xarbol = New TreeNode("Zonas Registradas")
            Dim xrow As DataRow = CType(xbs_estado.Current, System.Data.DataRowView).Row
            Me.E_ESTADO.Text = xrow("nombre").ToString
            For Each xzon As DataRow In xrow.GetChildRows(xrel_estado_zona)
                xzona = New TreeNode(xzon("nombre").ToString)
                xzona.Tag = xzon
                xarbol.Nodes.Add(xzona)
            Next

            Me.MT_ZONA.Text = ""
            Me.TreeView1.Nodes.Add(xarbol)
            Me.TreeView1.ExpandAll()
        End If
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarZona()
    End Sub

    Sub AgregarZona()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloZonaCliente_Ingresar.F_Permitir()
            FichaAccion = TipoAccionFicha.Adicionar
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        If Me.MT_ZONA.r_Valor <> "" Then
            BotonGrabar()
        Else
            Me.MT_ZONA.Select()
        End If
    End Sub

    Sub BotonGrabar()
        If FichaAccion = TipoAccionFicha.Adicionar Then
            If MessageBox.Show("Estas Seguro De Guardar Esta Nueva Zona ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xzona As New FichaClientes.c_Zonas.c_AgregarZona
                    With xzona
                        .c_AutomaticoEstado = xbs_estado.Current("auto").ToString
                        .c_NombreZona = Me.MT_ZONA.r_Valor
                    End With
                    xfichazona.F_NuevaZona(xzona)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                Me.MT_ZONA.Select()
            End If
        Else
            If MessageBox.Show("Estas Seguro De Guardar Estos Cambios ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xrow As DataRow = CType(Me.TreeView1.SelectedNode.Tag, DataRow)
                    Dim xreg As New FichaClientes.c_Zonas.c_Registro
                    xreg.CargarRegistro(xrow)

                    Dim xzona As New FichaClientes.c_Zonas.c_ModificarZona
                    With xzona
                        .c_AutomaticoZona = xreg.r_Automatico
                        .c_IdSeguridad = xreg.r_IdSeguridad
                        .c_NombreZona = Me.MT_ZONA.r_Valor
                    End With
                    xfichazona.F_ModificarZona(xzona)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                Me.MT_ZONA.Select()
            End If
        End If
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        Eliminar()
    End Sub

    Sub Eliminar()
        Try
            If Me.TreeView1.SelectedNode IsNot Nothing Then
                Dim xrow As DataRow = Nothing
                xrow = CType(Me.TreeView1.SelectedNode.Tag, DataRow)
                If xrow IsNot Nothing Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloZonaCliente_Eliminar.F_Permitir()

                    Dim xreg As New FichaClientes.c_Zonas.c_Registro
                    xreg.CargarRegistro(xrow)
                    EliminarZona(xreg.r_Automatico)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub EliminarZona(ByVal xauto As String)
        If FichaAccion = TipoAccionFicha.Consultar Then
            Try
                If MessageBox.Show("Estas Seguro De Eliminar Esta Zona ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    FichaAccion = TipoAccionFicha.Eliminar
                    xfichazona.F_EliminarZona(xauto)
                End If
            Catch ex As Exception
                FichaAccion = TipoAccionFicha.Consultar
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Me.TreeView1.SelectedNode IsNot Nothing Then
            Dim xrow As DataRow = CType(Me.TreeView1.SelectedNode.Tag, DataRow)
            If xrow IsNot Nothing Then
                Dim xreg As New FichaClientes.c_Zonas.c_Registro
                xreg.CargarRegistro(xrow)

                If xreg.r_Automatico <> "" Then
                    Me.MT_ZONA.Text = xreg.c_NombreZona.c_Texto
                End If
            Else
                Me.MT_ZONA.Text = ""
            End If
        Else
            Me.MT_ZONA.Text = ""
        End If
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarZona()
    End Sub

    Sub ModificarZona()
        Try
            If Me.TreeView1.SelectedNode IsNot Nothing Then
                Dim xrow As DataRow = Nothing
                xrow = CType(Me.TreeView1.SelectedNode.Tag, DataRow)
                If xrow IsNot Nothing Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloZonaCliente_Modificar.F_Permitir()

                    Dim xreg As New FichaClientes.c_Zonas.c_Registro
                    xreg.CargarRegistro(xrow)
                    If xreg.r_Automatico <> "" Then
                        FichaAccion = TipoAccionFicha.Modificar
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class