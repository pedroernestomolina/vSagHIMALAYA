Imports DataSistema.MiDataSistema.DataSistema

Public Class DeptoPtoVenta
    Dim pb_tm As Size
    Dim xf_accion As TipoAccionFicha
    Dim xficha As FichaProducto.Prd_Producto
    Dim xestatus As String() = {"Activo", "Inactivo"}

    Dim xtb As DataTable
    Dim xtb_depto As DataTable
    Dim xtb_grupo As DataTable

    Dim xbs As BindingSource
    Dim xbs_depto As BindingSource
    Dim xbs_grupo As BindingSource

    WithEvents OF1 As OpenFileDialog

    Sub ApagarEncenderControles(ByVal xestatus As Boolean)
        Me.PB_1.Enabled = xestatus
        Me.PB_2.Enabled = xestatus
        Me.PB_3.Enabled = xestatus
        Me.MisGrid1.Enabled = xestatus

        Me.BT_GRABAR.Enabled = Not xestatus
        Me.MT_DPTO.Enabled = Not xestatus
        Me.MCB_ESTATUS.Enabled = Not xestatus
        Me.MCB_IVA.Enabled = Not xestatus
        Me.MCB_DEPTO.Enabled = Not xestatus
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
                Me.MT_DPTO.Text = ""
                Me.MCB_ESTATUS.SelectedIndex = 0
                Me.MCB_DEPTO.SelectedIndex = 0
                Me.MCB_IVA.SelectedIndex = 0
                Me.MCB_GRUPO.SelectedIndex = 0
                ApagarEncenderControles(False)
                Me.MT_DPTO.Select()
                Me.MT_DPTO.Focus()
            End If

            If value = TipoAccionFicha.Modificar Then
                ApagarEncenderControles(False)
                Me.MT_DPTO.Select()
                Me.MT_DPTO.Focus()
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
            OF1 = New OpenFileDialog

            Me._FichaAccion = TipoAccionFicha.Consultar
            pb_tm = PB_1.Size

            xtb = New DataTable
            xbs = New BindingSource(xtb, "")

            xtb_depto = New DataTable
            xbs_depto = New BindingSource(xtb_depto, "")

            xtb_grupo = New DataTable
            xbs_grupo = New BindingSource(xtb_grupo, "")

            xficha = New FichaProducto.Prd_Producto

            With Me.MT_DPTO
                .Text = ""
                .MaxLength = xficha.RegistroDato.c_NombreProductoResumen.c_Largo
            End With

            With Me.MCB_ESTATUS
                .DataSource = xestatus
                .SelectedIndex = 0
            End With

            CargarDepto()
            With Me.MCB_DEPTO
                .DataSource = xbs_depto
                .DisplayMember = "NOMBRE"
                .ValueMember = "auto"
            End With

            CargarGrupos()
            With Me.MCB_GRUPO
                .DataSource = xbs_grupo
                .DisplayMember = "NOMBRE"
                .ValueMember = "auto"
            End With

            With Me.MCB_IVA
                .DataSource = g_MiData.f_FichaGlobal.f_Fiscal.r_ListaTasasFiscales
                .DisplayMember = "_TasaNombre"
                .ValueMember = "_Tasa"
            End With

            AddHandler xficha._ActualizarFicha, AddressOf CargarData
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

        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If MisGrid1.Rows(e.RowIndex).Cells("estatus").Value.ToString.Trim.ToUpper <> "ACTIVO" Then
            MisGrid1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre as nom, auto, estatus from PRODUCTOS with (readpast) WHERE ESTATUS_DEPARTAMENTO='1' order by nombre", xtb)
    End Sub

    Sub CargarDepto()
        g_MiData.F_GetData("select nombre , auto from productos_departamento with (readpast) order by nombre", xtb_depto)
        Actualiza()
    End Sub

    Sub CargarGrupos()
        g_MiData.F_GetData("select nombre , auto from productos_grupo with (readpast) order by nombre", xtb_grupo)
        Actualiza()
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xficha.F_BuscarCargarFichaProducto(xbs.Current("auto"))
        Else
            xficha.RegistroDato.LimpiarRegistro()
        End If

        Dim xt As IEnumerable(Of FichaGlobal.c_TasasFiscales.Tasas) = _
               g_MiData.f_FichaGlobal.f_Fiscal.r_ListaTasasFiscales.Where(Function(p) _
                                                                              p._TasaValor = xficha.RegistroDato._TasaImpuesto And p._TasaTipo = xficha.RegistroDato._TipoImpuesto)
        Dim xv As FichaGlobal.c_TasasFiscales.Tasas = xt(0)

        Me.MT_DPTO.Text = xficha.RegistroDato._DescripcionDetallaDelProducto
        Me.MCB_DEPTO.SelectedValue = xficha.RegistroDato._AutoDepartamento
        Me.MCB_GRUPO.SelectedValue = xficha.RegistroDato._AutoGrupo
        Me.MCB_IVA.SelectedValue = xv

        If xficha.RegistroDato._EstatusProducto Then
            Me.MCB_ESTATUS.SelectedIndex = 0
        Else
            Me.MCB_ESTATUS.SelectedIndex = 1
        End If

        If xficha.RegistroDato._EstatusFoto = TipoEstatus.Activo Then
            Me.T1.Enabled = True
            Me.T3.Enabled = True
        Else
            Me.T1.Enabled = False
            Me.T3.Enabled = False
        End If

        Me.E_REGISTROS.Text = xbs.Count.ToString
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        If xbs.Current IsNot Nothing Then
            EliminarRegistro()
        End If
    End Sub

    Sub EliminarRegistro()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_DeptoPtoVenta_Eliminar.F_Permitir()
            If MessageBox.Show("Estas Seguro De Eliminar Dicho Departamento ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                xficha.F_EliminarDeptoPtoVenta(xficha.RegistroDato._AutoProducto)
                Funciones.MensajeDeOk("Registro Eliminado Satisfactoriamente...")
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarRegistro()
    End Sub

    Sub AgregarRegistro()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_DeptoPtoVenta_Ingresar.F_Permitir()
            Me._FichaAccion = TipoAccionFicha.Adicionar
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        Grabar()
    End Sub

    Sub Grabar()
        If _FichaAccion = TipoAccionFicha.Adicionar Then
            If Me.MT_DPTO.r_Valor <> "" Then
                If MessageBox.Show("Estas Seguro De Agregar Este Nuevo Departamento ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim xtasa As FichaGlobal.c_TasasFiscales.Tasas = CType(Me.MCB_IVA.SelectedValue, FichaGlobal.c_TasasFiscales.Tasas)
                        Dim xdpto As New FichaProducto.Prd_Producto.c_AgregarDepartamentoPtoventas
                        With xdpto
                            ._AutoDepartamento = Me.MCB_DEPTO.SelectedValue
                            ._NombreNuevoDeptoPtoVenta = Me.MT_DPTO.r_Valor
                            ._TasaIva = xtasa._TasaValor
                            ._TipoImpuesto = xtasa._TasaTipo
                            ._Estatus = IIf(Me.MCB_ESTATUS.SelectedIndex = 0, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._FechaAlta = g_MiData.p_FechaDelMotorBD
                            ._AutoGrupo = Me.MCB_GRUPO.SelectedValue
                            ._AutoEmpqCompra = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._AutoEmpqCompra_PorDefecto
                            ._AutoEmpqVenta = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._AutoEmpqVenta_PorDefecto
                            ._AutoMarca = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._AutoMarca_PorDefecto
                        End With
                        xficha.F_IngresarDeptoPtoVenta(xdpto)
                        Me._FichaAccion = TipoAccionFicha.Consultar
                        Funciones.MensajeDeOk("Registro Agregado Satisfactoriamente...")
                        Actualiza()
                    Catch ex As Exception
                        Funciones.MensajeDeError(ex.Message)
                    End Try
                End If
            Else
                Me.MT_DPTO.Select()
                Me.MT_DPTO.Focus()
                Funciones.MensajeDeAlerta("Nombre Del Departamento No Puede Estar Vacio")
            End If
        Else
            If Me.MT_DPTO.r_Valor <> "" Then
                If MessageBox.Show("Estas Seguro De Modificar Este Departamento ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim xtasa As FichaGlobal.c_TasasFiscales.Tasas = CType(Me.MCB_IVA.SelectedValue, FichaGlobal.c_TasasFiscales.Tasas)
                        Dim xdpto As New FichaProducto.Prd_Producto.c_ModificarDepartamentoPtoVentas
                        With xdpto
                            ._AutoDepartamento = Me.MCB_DEPTO.SelectedValue
                            ._AutoEmpqCompra = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._AutoEmpqCompra_PorDefecto
                            ._AutoEmpqVenta = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._AutoEmpqVenta_PorDefecto
                            ._AutoGrupo = Me.MCB_GRUPO.SelectedValue
                            ._AutoMarca = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._AutoMarca_PorDefecto
                            ._AutoProducto = xficha.RegistroDato._AutoProducto
                            ._Estatus = IIf(Me.MCB_ESTATUS.SelectedIndex = 0, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._FechaAlta = g_MiData.p_FechaDelMotorBD
                            ._IdSeguridad = xficha.RegistroDato._IdSeguridad
                            ._NombreNuevoDeptoPtoVenta = Me.MT_DPTO.r_Valor
                            ._TasaIva = xtasa._TasaValor
                            ._TipoImpuesto = xtasa._TasaTipo
                        End With
                        xficha.F_ModificarDeptoPtoVenta(xdpto)
                        Me._FichaAccion = TipoAccionFicha.Consultar

                        Funciones.MensajeDeOk("Registro Actualizado Satisfactoriamente...")
                        Actualiza()
                    Catch ex As Exception
                        Funciones.MensajeDeError(ex.Message)
                    End Try
                End If
            Else
                Me.MT_DPTO.Select()
                Me.MT_DPTO.Focus()
                Funciones.MensajeDeAlerta("Nombre Del Departamento No Puede Estar Vacio")
            End If
        End If
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        If xbs.Current IsNot Nothing Then
            ModificarRegistro()
        End If
    End Sub

    Sub ModificarRegistro()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_DeptoPtoVenta_Modificar.F_Permitir()
            Me._FichaAccion = TipoAccionFicha.Modificar
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub DeptoPtoVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub DeptoPtoVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DeptoPtoVenta_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub DeptoPtoVenta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub LINK_DEPARTAMENTOS_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_DEPARTAMENTOS.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Depart.F_Permitir()

            Dim xForm As New Plantilla_1(New ProductosDepartamento)
            With xForm
                AddHandler .ActualizarFicha, AddressOf CargarDepto
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub LINK_GRUPOS_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_GRUPOS.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_GrupoSubGrupo.F_Permitir()

            Dim xForm As New GrupoProductos
            AddHandler xForm._ActualizarFicha, AddressOf CargarGrupos
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub DeptoPtoVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Sub MostrarImagen()
        Try
            Dim xfichaimg As New FichaImagen(xficha.RegistroDato)
            With xfichaimg
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub T1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T1.Click
        MostrarImagen()
    End Sub

    Private Sub T3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T3.Click
        Try
            If MessageBox.Show("Estas Seguro De Eliminar La Imagen Asignada A Este Departamento ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                xficha.F_ModificarFichaFoto(xficha.RegistroDato, False)
                My.Computer.FileSystem.DeleteFile(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos + "\" + xficha.RegistroDato._AutoProducto)
                CargarData()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub T2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T2.Click
        CargarImagen()
    End Sub

    Sub CargarImagen()
        Try
            With OF1
                .InitialDirectory = "c:\"
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub OF1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OF1.FileOk
        Dim xr As Boolean = True
        If MessageBox.Show("Estas Seguro De Asignar Esta Imagen Al Grupo ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                If My.Computer.FileSystem.GetDirectoryInfo(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos).Exists Then
                    If My.Computer.FileSystem.FileExists(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos + "\" + xficha.RegistroDato._AutoProducto) Then
                        If MessageBox.Show("Deseas Reemplazar La Imagen Existente ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            My.Computer.FileSystem.DeleteFile(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos + "\" + xficha.RegistroDato._AutoProducto)
                        Else
                            xr = False
                        End If
                    End If
                    If xr Then
                        My.Computer.FileSystem.CopyFile(OF1.FileName, g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos + "\" + xficha.RegistroDato._AutoProducto)
                        xficha.F_ModificarFichaFoto(xficha.RegistroDato, True)
                        CargarData()
                    End If
                Else
                    Funciones.MensajeDeAlerta("Directorio: " & g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos & ", No Existe.. Verifique Por Favor")
                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub P5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P5.Click
        MostrarImagen()
    End Sub
End Class