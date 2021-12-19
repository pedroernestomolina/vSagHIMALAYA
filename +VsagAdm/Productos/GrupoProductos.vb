Imports DataSistema.MiDataSistema.DataSistema

Public Class GrupoProductos
    Event _ActualizarFicha()

    Dim pb_tm As Size
    Dim xf_accion As TipoAccionFicha
    Dim xficha1 As FichaProducto.Prd_Grupo
    Dim xficha2 As FichaProducto.Prd_SubGrupo

    Dim ds As DataSet
    Dim dr As DataRelation
    Dim xtb_subgrupo As DataTable
    Dim xtb_grupo As DataTable

    Dim xbs_subgrupo As BindingSource
    Dim xbs_grupo As BindingSource

    Dim xfil As String = ""

    Sub ApagarEncenderControles(ByVal xestatus As Boolean)
        Me.RB_GRUPO.Enabled = xestatus
        Me.RB_SUBGRUPO.Enabled = xestatus
        Me.PB_1.Enabled = xestatus
        Me.PB_2.Enabled = xestatus
        Me.PB_3.Enabled = xestatus
        Me.MisGrid1.Enabled = xestatus

        Me.BT_GRABAR.Enabled = Not xestatus
        Me.MT_GRUPO.Enabled = Not xestatus
        Me.MT_SUBGRUPO.Enabled = Not xestatus
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
                ApagarEncenderControles(False)
                If Me.RB_GRUPO.Checked Then
                    Me.MT_GRUPO.Text = ""
                    Me.MT_SUBGRUPO.Text = ""

                    Me.MT_SUBGRUPO.Enabled = False
                    Me.MT_GRUPO.Select()
                    Me.MT_GRUPO.Focus()
                Else
                    Me.MT_SUBGRUPO.Text = ""

                    Me.MT_GRUPO.Enabled = False
                    Me.MT_SUBGRUPO.Select()
                    Me.MT_SUBGRUPO.Focus()
                End If
            End If

            If value = TipoAccionFicha.Modificar Then
                ApagarEncenderControles(False)
                If Me.RB_GRUPO.Checked Then
                    Me.MT_SUBGRUPO.Enabled = False
                    Me.MT_GRUPO.Select()
                    Me.MT_GRUPO.Focus()
                Else
                    Me.MT_GRUPO.Enabled = False
                    Me.MT_SUBGRUPO.Select()
                    Me.MT_SUBGRUPO.Focus()
                End If
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

    Sub Inicializa()
        Try
            Me._FichaAccion = TipoAccionFicha.Consultar
            pb_tm = PB_1.Size

            ds = New DataSet
            xtb_grupo = New DataTable
            xtb_subgrupo = New DataTable

            CargarData()
            ds.Tables.Add(xtb_grupo)
            ds.Tables.Add(xtb_subgrupo)

            Dim xcol1 As DataColumn = xtb_grupo.Columns("auto")
            Dim xcol2 As DataColumn = xtb_subgrupo.Columns("auto_grupo")
            dr = New DataRelation("GRUPO_SUBGRUPO", xcol1, xcol2, True)
            ds.Relations.Add(dr)

            xbs_grupo = New BindingSource(ds, xtb_grupo.TableName)
            xbs_subgrupo = New BindingSource(xbs_grupo, dr.RelationName)

            xficha1 = New FichaProducto.Prd_Grupo
            xficha2 = New FichaProducto.Prd_SubGrupo

            With Me.MT_GRUPO
                .Text = ""
                .MaxLength = xficha1.RegistroDato.c_NombreGrupo.c_Largo
            End With
            With Me.MT_SUBGRUPO
                .Text = ""
                .MaxLength = xficha2.RegistroDato.c_SubGrupo.c_Largo
            End With

            AddHandler xficha1._ActualizarFicha, AddressOf ActualizarData
            AddHandler xficha2._ActualizarFicha, AddressOf ActualizarData

            AddHandler xbs_grupo.PositionChanged, AddressOf Actualiza
            AddHandler xbs_subgrupo.PositionChanged, AddressOf Actualiza
            Actualiza()

            With MisGrid1
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs_grupo
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With

            With MisGrid2
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs_subgrupo
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error *** ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub CargarData()
        xtb_subgrupo.Rows.Clear()
        xtb_grupo.Rows.Clear()

        g_MiData.F_GetData("select nombre nom, * from productos_grupo order by nombre", xtb_grupo)
        g_MiData.F_GetData("select nombre nom, * from productos_subgrupo order by nombre", xtb_subgrupo)
    End Sub

    Sub ActualizarData()
        RaiseEvent _ActualizarFicha()
        CargarData()
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs_grupo.Current IsNot Nothing Then
            xficha1.M_CargarRegistro(CType(xbs_grupo.Current, System.Data.DataRowView).Row)
        Else
            xficha1.RegistroDato.LimpiarRegistro()
        End If

        If xbs_subgrupo.Current IsNot Nothing Then
            xficha2.M_CargarRegistro(CType(xbs_subgrupo.Current, System.Data.DataRowView).Row)
        Else
            xficha2.RegistroDato.LimpiarRegistro()
        End If

        Me.MT_GRUPO.Text = xficha1.RegistroDato._Nombre
        Me.MT_SUBGRUPO.Text = xficha2.RegistroDato._SubGrupo

        Me.E_ITEM.Text = xbs_grupo.Count.ToString
        Me.E_SUBITEM.Text = xbs_subgrupo.Count.ToString
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarRegistro()
    End Sub

    Sub EliminarRegistro()
        Dim xseg As Boolean = False

        If Me.RB_GRUPO.Checked Then
            If xbs_grupo.Current IsNot Nothing Then
                xseg = True
            End If
        Else
            If xbs_subgrupo.Current IsNot Nothing Then
                xseg = True
            End If
        End If

        If xseg Then
            Try
                Dim xmen As String = ""

                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_GrupoSubGrupo_Eliminar.F_Permitir()
                If Me.RB_GRUPO.Checked Then
                    xmen = "Estas Seguro De Eliminar Este Grupo ?"
                Else
                    xmen = "Estas Seguro De Eliminar Este SubGrupo ?"
                End If

                If MessageBox.Show(xmen, "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    If Me.RB_GRUPO.Checked Then
                        xficha1.F_EliminarRegistro(xficha1.RegistroDato._Automatico)
                        MessageBox.Show("Grupo Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        xficha2.F_EliminarRegistro(xficha2.RegistroDato._Automatico)
                        MessageBox.Show("SubGrupo Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarRegistro()
    End Sub

    Sub AgregarRegistro()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_GrupoSubGrupo_Ingresar.F_Permitir()
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
            Dim xseg As Boolean = False
            Dim xmen As String = ""
            If RB_GRUPO.Checked Then
                If Me.MT_GRUPO.r_Valor <> "" Then
                    xseg = True
                    xmen = "Estas Seguro De Agregar Este Grupo ?"
                End If
            Else
                If Me.MT_SUBGRUPO.r_Valor <> "" Then
                    xseg = True
                    xmen = "Estas Seguro De Agregar Este SubGrupo ?"
                End If
            End If

            If xseg Then
                If MessageBox.Show(xmen, "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        If RB_GRUPO.Checked Then
                            xficha1.F_AgregarRegistro(Me.MT_GRUPO.r_Valor)
                            Me._FichaAccion = TipoAccionFicha.Consultar
                            MessageBox.Show("Grupo Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            Dim xsubg As New FichaProducto.Prd_SubGrupo.c_AgregarSubGrupo
                            With xsubg
                                ._AutoGrupo = xficha1.RegistroDato._Automatico
                                ._SubGrupo = Me.MT_SUBGRUPO.r_Valor
                            End With
                            xficha2.F_AgregarRegistro(xsubg)
                            Me._FichaAccion = TipoAccionFicha.Consultar
                            MessageBox.Show("SubGrupo Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Err_1()
                    End Try
                Else
                    Err_1()
                End If
            Else
                Err_1()
                If Me.RB_GRUPO.Checked Then
                    xmen = "Error En El Nombre Del Grupo, No Puede Estar Vacio"
                Else
                    xmen = "Error En El Nombre Del SubGrupo, No Puede Estar Vacio"
                End If
                MessageBox.Show(xmen, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else

            Dim xseg As Boolean = False
            Dim xmen As String = "Estas Seguro De Guardar Este Nuevo Cambio ?"
            If RB_GRUPO.Checked Then
                If Me.MT_GRUPO.r_Valor <> "" Then
                    xseg = True
                End If
            Else
                If Me.MT_SUBGRUPO.r_Valor <> "" Then
                    xseg = True
                End If
            End If

            If xseg Then
                If MessageBox.Show(xmen, "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        If RB_GRUPO.Checked Then
                            Dim xgrup As New FichaProducto.Prd_Grupo.c_ModificarGrupo
                            With xgrup
                                ._AutoGrupo = xficha1.RegistroDato._Automatico
                                ._IdSeguridad = xficha1.RegistroDato._IdSeguridad
                                ._NombreGrupo = MT_GRUPO.r_Valor
                            End With
                            xficha1.F_ModificaRegistro(xgrup)
                            Me._FichaAccion = TipoAccionFicha.Consultar
                            MessageBox.Show("Grupo Modificado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            Dim xsubg As New FichaProducto.Prd_SubGrupo.c_ModificarSubGrupo
                            With xsubg
                                ._AutoGrupo = xficha1.RegistroDato._Automatico
                                ._SubGrupo = Me.MT_SUBGRUPO.r_Valor
                                ._Automatico = xficha2.RegistroDato._Automatico
                                ._IdSeguridad = xficha2.RegistroDato._IdSeguridad
                            End With
                            xficha2.F_ModificaRegistro(xsubg)
                            Me._FichaAccion = TipoAccionFicha.Consultar
                            MessageBox.Show("SubGrupo Modificado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Err_1()
                    End Try
                End If
            Else
                Err_1()
                If Me.RB_GRUPO.Checked Then
                    xmen = "Error En El Nombre Del Grupo, No Puede Estar Vacio"
                Else
                    xmen = "Error En El Nombre Del SubGrupo, No Puede Estar Vacio"
                End If
                MessageBox.Show(xmen, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub Err_1()
        If Me.RB_GRUPO.Checked Then
            Me.MT_GRUPO.Select()
            Me.MT_GRUPO.Focus()
        Else
            Me.MT_SUBGRUPO.Select()
            Me.MT_SUBGRUPO.Focus()
        End If
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarRegistro()
    End Sub

    Sub ModificarRegistro()
        Dim xseg As Boolean = False
        If Me.RB_GRUPO.Checked Then
            If xbs_grupo.Current IsNot Nothing Then
                xseg = True
            End If
        Else
            If xbs_subgrupo.Current IsNot Nothing Then
                xseg = True
            End If
        End If

        If xseg Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_GrupoSubGrupo_Modificar.F_Permitir()
                Me._FichaAccion = TipoAccionFicha.Modificar
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub GrupoProductos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub GrupoProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub GrupoProductos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub GrupoProductos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub MisGrid2_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid2.Accion
        xfil = ""
        xfil += " and p.auto_grupo='" + xficha1.RegistroDato._Automatico + "'"
        xfil += " and p.auto_subgrupo='" + xficha2.RegistroDato._Automatico + "'"
        LlamarVista()
    End Sub

    Sub LlamarVista()
        Dim TipoB As String = xfil
        Dim xsql As String = _
        "SELECT p.nombre xnom, p.codigo xcod, p.tasa xtas, p.plu xplu, p.psv, p.auto, p.estatus,p.referencia xref, " _
             + "p.contenido_empaque xempcompra, pdep.nombre ndep, pgrp.nombre ngrp, pmar.nombre nmar, pmed.nombre nmed, pmed.decimales xdec " _
             + "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto join productos_grupo pgrp on p.auto_grupo=pgrp.auto " _
             + "join productos_marca pmar on p.auto_marca=pmar.auto join productos_medida pmed on p.auto_medida_compra=pmed.auto " _
             + "where p.auto<>'' " + TipoB + " and p.estatus_departamento='0' order by p.nombre;" _
             + "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
             + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
             + "where pd.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
             + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
             + "where p.auto<>'' " + TipoB + " and  p.estatus_departamento='0');" _
             + "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, pe.*, pm.* " _
             + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
             + "where pe.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
             + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
             + "where p.auto<>'' " + TipoB + "  and p.estatus_departamento='0')"

        Dim xficha As New Plantilla_5(New VistaProductos("1"), xsql)
        With xficha
            .ShowDialog()
        End With
    End Sub

    Private Sub MisGrid1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid1.Accion
        xfil = ""
        xfil += " and p.auto_grupo='" + xficha1.RegistroDato._Automatico + "'"
        LlamarVista()
    End Sub
End Class