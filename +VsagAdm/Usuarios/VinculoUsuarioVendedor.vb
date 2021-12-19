Imports DataSistema.MiDataSistema.DataSistema

Public Class VinculoUsuarioVendedor
    Dim pb_tm As Size
    Dim xtb_usuario As DataTable
    Dim xbs_usuario As BindingSource
    Dim xvinculousuariovendedor As UsuarioVendedor

    Property _VinculoUsuVend() As UsuarioVendedor
        Get
            Return xvinculousuariovendedor
        End Get
        Set(ByVal value As UsuarioVendedor)
            xvinculousuariovendedor = value
        End Set
    End Property

    Private Sub PB_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseEnter, PB_2.MouseEnter, PB_4.MouseEnter
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseHover, PB_2.MouseHover, PB_4.MouseHover
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseLeave, PB_2.MouseLeave, PB_4.MouseLeave
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

    Private Sub VinculoUsuarioVendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub VinculoUsuarioVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_tm = PB_1.Size
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub VinculoUsuarioVendedor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        xtb_usuario = New DataTable
        xbs_usuario = New BindingSource(xtb_usuario, "")
        _VinculoUsuVend = New UsuarioVendedor

        AddHandler _VinculoUsuVend._ActualizarTabla, AddressOf Actualizar
        AddHandler xbs_usuario.PositionChanged, AddressOf ActualizarData
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualizar()
    End Sub

    Sub Actualizar()
        If xbs_usuario.Current IsNot Nothing Then
            Try
                Dim xusuario As New FichaGlobal.c_Usuario
                xusuario.F_BuscarRegistro(xbs_usuario.Current("xauto").ToString.Trim)
                Me._VinculoUsuVend.F_BuscarCargar(xusuario.RegistroDato._AutoUsuario)

                Me.L_1.Text = Me._VinculoUsuVend.RegistroDato._f_FichaVendedor.r_NombreVendedor
                Me.PB_VINCULO.Visible = True
            Catch ex As Exception
                LimpiarVinculo()
            End Try
        Else
            LimpiarVinculo()
        End If
    End Sub

    Sub LimpiarVinculo()
        Me.L_1.Text = ""
        Me.PB_VINCULO.Visible = False
    End Sub

    Sub Inicializa()
        Try
            g_MiData.F_GetData("select nombre as xnom, auto as xauto , * from usuarios where estatus='Activo' order by nombre", xtb_usuario)

            With Me.MG_1
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs_usuario
                .Columns(0).DataPropertyName = "xnom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        If xbs_usuario.Current IsNot Nothing Then
            AgregarCrearVinculo()
        End If
    End Sub

    Sub AgregarCrearVinculo()
        Try
            Dim xsql As String = "select nombre nom, telefono1 tel, celular1 cel, * from vendedores where estatus='Activo' order by nombre"
            Dim xficha As New Plantilla_2(New BusquedaVendedor, xsql, Nothing)
            AddHandler xficha.EnviarAuto, AddressOf CaptarVendedor
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub CaptarVendedor(ByVal xauto As String)
        If MessageBox.Show("Estas Seguro De Hacer El Vinculo ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xusuario As String = xbs_usuario.Current("xauto").ToString.Trim
                Dim xvendedor As String = xauto
                _VinculoUsuVend.F_AgregarCrearVinculo(xusuario, xauto)
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        If xbs_usuario.Current IsNot Nothing Then
            If MessageBox.Show("Estas Seguro De Eliminar El Vinculo ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xusuario As String = xbs_usuario.Current("xauto").ToString.Trim
                    _VinculoUsuVend.F_EliminarVinculo(xusuario)
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        End If
    End Sub
End Class