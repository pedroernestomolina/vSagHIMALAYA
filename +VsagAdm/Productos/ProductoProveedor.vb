Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class ProductoProveedor
    Dim pb_tm As Size
    Dim xaccion As TipoAccionFicha

    Dim xtb_prov As DataTable
    Dim xbs As BindingSource
    Dim xbs_prov As BindingSource

    Dim xprovprd As FichaProducto.Prd_Proveedor
    Dim xproducto As FichaProducto.Prd_Producto
    Dim xproveedor As FichaProveedores.c_Proveedor

    Sub New(ByVal xprd As FichaProducto.Prd_Producto)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        xtb_prov = New DataTable
        xbs_prov = New BindingSource(xtb_prov, "")

        _FichaProducto = xprd
        xbs = New BindingSource(_FichaProducto.RegistroDato.tb_Proveedores, "")

        xprovprd = New FichaProducto.Prd_Proveedor
        AddHandler xprovprd.Actualizar, AddressOf ActualizarCodigos

        xproveedor = New FichaProveedores.c_Proveedor
    End Sub

    Property _FichaProducto() As FichaProducto.Prd_Producto
        Get
            Return xproducto
        End Get
        Set(ByVal value As FichaProducto.Prd_Producto)
            xproducto = value
        End Set
    End Property

    Property _FichaProveedorProducto() As FichaProducto.Prd_Proveedor
        Get
            Return xprovprd
        End Get
        Set(ByVal value As FichaProducto.Prd_Proveedor)
            xprovprd = value
        End Set
    End Property

    ReadOnly Property _Off() As Boolean
        Get
            Return False
        End Get
    End Property

    ReadOnly Property _On() As Boolean
        Get
            Return True
        End Get
    End Property

    Sub Controles(ByVal xop As Boolean)
        Me.PB_1.Enabled = xop
        Me.PB_2.Enabled = xop
        Me.PB_3.Enabled = xop
        Me.MG_1.Enabled = xop
    End Sub

    Property _FichaAccion() As TipoAccionFicha
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xaccion = value

            If value = TipoAccionFicha.Consultar Then
                Me.MT_1.Enabled = False
                Me.MCB_1.Enabled = False
                Me.BT_GRABAR.Enabled = False

                Controles(_On)
                Me.MG_1.Select()
                Me.MG_1.Focus()
            End If

            If value = TipoAccionFicha.Adicionar Then
                Me.MT_1.Enabled = True
                Me.MCB_1.Enabled = True
                Me.BT_GRABAR.Enabled = True

                Controles(_Off)
                With Me.MCB_1
                    .Select()
                    .Focus()
                    If xbs_prov.Count > 0 Then
                        .SelectedIndex = 0
                    End If
                End With
                Me.MT_1.Text = ""
            End If

            If value = TipoAccionFicha.Modificar Then
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

    Private Sub ProductoProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub ProductoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                AgregarRegistro()
            End If
        End If
        If e.KeyValue = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                'ModificarRegistro()
            End If
        End If
        If e.KeyValue = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                EliminarRegistro()
            End If
        End If
        If e.KeyValue = Keys.F4 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Adicionar Or _FichaAccion = TipoAccionFicha.Modificar Then
                'Grabar()
            End If
        End If
    End Sub

    Private Sub ProductoProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ProductoProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ProductoProveedor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub CargarProveedores()
        Try
            Me.MCB_1.Enabled = True
            g_MiData.F_GetData("select nombre nom, * from proveedores order by nombre", xtb_prov)
            If _FichaAccion = TipoAccionFicha.Consultar Then
                Me.MCB_1.SelectedValue = xbs.Current("auto").ToString.Trim
                Me.MCB_1.Enabled = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Inicializa()
        Try
            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With

            CargarProveedores()

            Me.E_0.Text = "0"
            Me.E_1.Text = _FichaProducto.RegistroDato._DescripcionDetallaDelProducto
            With Me.MT_1
                .Text = ""
                .MaxLength = _FichaProveedorProducto.RegistroDato.c_Codigo.c_Largo
            End With
            With Me.MCB_1
                .DataSource = xbs_prov
                .ValueMember = "auto"
                .DisplayMember = "Nombre"
            End With

            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With MG_1
                .Columns.Add("col0", "Nombre")
                .Columns.Add("col1", "Cod/Proveedor")

                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).Width = 150

                .DataSource = xbs
                .Columns(0).DataPropertyName = "xnombre"
                .Columns(1).DataPropertyName = "xcodigo"
                .Ocultar(3)
            End With

            pb_tm = PB_1.Size
            Me._FichaAccion = TipoAccionFicha.Consultar

            Me.E_0.Text = xbs.Count.ToString.Trim
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error *** ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            Me.MT_1.Text = xbs.Current("xcodigo").ToString.Trim
            Me.MCB_1.SelectedValue = xbs.Current("auto").ToString.Trim
        Else
            Me.MT_1.Text = ""
            Me.MCB_1.SelectedValue = ""
        End If
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarRegistro()
    End Sub

    Sub EliminarRegistro()
        Try
            If xbs.Current IsNot Nothing Then
                If MessageBox.Show("Estas Seguro De Eliminar Dicho Codigo Del Proveedor Para Este Producto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim xeliminar As New FichaProducto.Prd_Proveedor.c_AgregarEliminarCodigoProveedor
                    With xeliminar
                        ._AutoProducto = _FichaProducto.RegistroDato._AutoProducto
                        ._AutoProveedor = xbs.Current("auto").ToString.Trim
                        ._CodigoAsignar = Me.MT_1.r_Valor
                    End With
                    _FichaProveedorProducto.F_EliminarRegistro(xeliminar)
                    MessageBox.Show("Codigo Eliminado Satisfactoriamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            _FichaAccion = TipoAccionFicha.Consultar
        End Try
    End Sub

    Sub ActualizarCodigos()
        Try
            _FichaProducto.F_ActualizarTablaProveedores()
            Me.E_0.Text = xbs.Count.ToString.Trim
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarRegistro()
    End Sub

    Sub AgregarRegistro()
        Me._FichaAccion = TipoAccionFicha.Adicionar
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        Grabar()
    End Sub

    Sub Grabar()
        If Me.MT_1.r_Valor <> "" Then
            If MessageBox.Show("Deseas Agregar Este Codigo Del Proveedor Al Producto?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xagregar As New FichaProducto.Prd_Proveedor.c_AgregarEliminarCodigoProveedor
                    With xagregar
                        ._AutoProducto = _FichaProducto.RegistroDato._AutoProducto
                        ._AutoProveedor = IIf(xbs_prov.Current IsNot Nothing, xbs_prov.Current("AUTO").ToString.Trim, "")
                        ._CodigoAsignar = Me.MT_1.r_Valor
                    End With
                    _FichaProveedorProducto.F_AgregarRegistro(xagregar)
                    MessageBox.Show("Codigo Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _FichaAccion = TipoAccionFicha.Consultar
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                Me.MCB_1.Select()
                Me.MCB_1.Focus()
            End If
        Else
            MessageBox.Show("Error Codigo No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_1.Select()
            Me.MT_1.Focus()
        End If
    End Sub

    Private Sub L_1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles L_1.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor.F_Permitir()

            Dim xficha As New FichaProveedor
            With xficha
                AddHandler ._ActualizarFicha, AddressOf CargarProveedores
                AddHandler ._ActualizarFicha, AddressOf ActualizarCodigos
                .Show()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class