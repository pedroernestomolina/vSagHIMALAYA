Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema

Public Class InventarioDepositos
    Event _ActualizarDepositos()
    Event _ActualizarCargaDepositos(ByVal xautoprd As String)

    Enum Accion As Integer
        Agregar = 1
        Modificar = 2
        Eliminar = 3
        Consulta = 4
    End Enum

    Dim pb_tm As Size
    Dim xtb_depositos As DataTable
    Dim xbs_depositos As BindingSource
    Dim xbs_depositos_prd As BindingSource
    Dim xaccion As Accion
    Dim xprd As FichaProducto

    ReadOnly Property _On() As Boolean
        Get
            Return True
        End Get
    End Property

    ReadOnly Property _Off() As Boolean
        Get
            Return False
        End Get
    End Property

    Property _FichaAccion() As Accion
        Get
            Return xaccion
        End Get
        Set(ByVal value As Accion)
            xaccion = value

            If value = Accion.Consulta Then
                Controles(_Off)
                LimpiarControles()
            ElseIf value = Accion.Modificar Then
                Controles(_On)
                Me.MT_1.Select()
                Me.MT_1.Focus()
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

    Sub Controles(ByVal xest As Boolean)
        Me.MT_1.Enabled = xest
        Me.MT_2.Enabled = xest
        Me.MT_3.Enabled = xest
        Me.MT_4.Enabled = xest
        Me.MN_1.Enabled = xest
        Me.MN_2.Enabled = xest

        Me.BT_GRABAR.Enabled = xest
        Me.MisGrid1.Enabled = Not xest

        Me.PB_1.Enabled = Not xest
        Me.PB_2.Enabled = Not xest
        Me.PB_3.Enabled = Not xest
    End Sub

    Sub New(ByVal xfichaprd As FichaProducto)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        pb_tm = PB_1.Size
        _FichaProducto = xfichaprd
        xbs_depositos_prd = New BindingSource(_FichaProducto.f_PrdProducto.RegistroDato.tb_Existencia, "")

        xtb_depositos = New DataTable
        xbs_depositos = New BindingSource(xtb_depositos, "")
    End Sub

    Property _FichaProducto() As FichaProducto
        Get
            Return xprd
        End Get
        Set(ByVal value As FichaProducto)
            xprd = value
        End Set
    End Property

    Private Sub InventarioDepositos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FichaAccion = Accion.Consulta Then
            e.Cancel = False
        Else
            If _FichaAccion = Accion.Modificar Then
                If MessageBox.Show("Estas Seguro De Peder Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                    ActualizaDeposito()
                    Me._FichaAccion = Accion.Consulta
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub InventarioDepositos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = Accion.Consulta Then
                AgregarRegistro()
            End If
        End If
        If e.KeyValue = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = Accion.Consulta Then
                ModificarRegistro()
            End If
        End If
        If e.KeyValue = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = Accion.Consulta Then
                EliminarRegistro()
            End If
        End If
        If e.KeyValue = Keys.F4 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = Accion.Consulta Then
                'Grabar()
            End If
        End If
    End Sub

    Private Sub InventarioDepositos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub InventarioDepositos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            InicializarControles()

            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With

            AddHandler xbs_depositos_prd.PositionChanged, AddressOf ActualizarDeposito
            _FichaAccion = Accion.Consulta
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub CargarDepositos()
        Try
            Dim xp1 As New SqlParameter("@auto_producto", _FichaProducto.f_PrdProducto.RegistroDato._AutoProducto)
            Dim xsql As String = "select d.codigo xcod, d.nombre xnom, d.* from depositos d " & _
                "where d.auto not in (select auto_deposito from productos_deposito where auto_producto =@auto_producto) order by d.nombre "
            g_MiData.F_GetData(xsql, xtb_depositos, xp1)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub InicializarControles()
        With MisGrid1
            .Columns.Add("col0", "Nombre")
            .Columns.Add("col1", "Cod")
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xbs_depositos_prd
            .Columns(0).DataPropertyName = "xnombre"
            .Columns(1).DataPropertyName = "xcodigo"

            .Ocultar(3)
        End With

        With Me.MT_1
            .Text = ""
            .MaxLength = _FichaProducto.f_PrdDeposito.RegistroDato.c_Ubicacion1.c_Largo
        End With
        With Me.MT_2
            .Text = ""
            .MaxLength = _FichaProducto.f_PrdDeposito.RegistroDato.c_Ubicacion2.c_Largo
        End With
        With Me.MT_3
            .Text = ""
            .MaxLength = _FichaProducto.f_PrdDeposito.RegistroDato.c_Ubicacion3.c_Largo
        End With
        With Me.MT_4
            .Text = ""
            .MaxLength = _FichaProducto.f_PrdDeposito.RegistroDato.c_Ubicacion4.c_Largo
        End With

        With Me.MN_1
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
        With Me.MN_2
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With

        CargarDepositos()
        With MCB_DEPOSITOS
            .DataSource = xbs_depositos
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With
    End Sub

    Sub LimpiarControles()
        Me.E_EXISTENCIA_ACTUAL.Text = "0.0"
        Me.E_EXISTENCIA_DISPONIBLE.Text = "0.0"
        Me.E_EXISTENCIA_RESERVA.Text = "0.0"
        Me.E_PRODUCTO.Text = ""
        Me.E_EMPAQUE.Text = ""

        ActualizaDeposito()
        Me.E_PRODUCTO.Text = _FichaProducto.f_PrdProducto.RegistroDato._DescripcionDetallaDelProducto
        Me.E_EMPAQUE.Text = "(" + _FichaProducto.f_PrdProducto.RegistroDato._NombreEmpaqueCompra + ") / " + _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra.ToString.Trim
    End Sub

    Sub ActualizarDeposito(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizaDeposito()
    End Sub

    Sub ActualizaDeposito()
        If xbs_depositos_prd.Current IsNot Nothing Then
            Try
                Dim xdr As DataRow = CType(xbs_depositos_prd.Current, System.Data.DataRowView).Row
                _FichaProducto.f_PrdDeposito.M_CargarRegistro(xdr)

                Me.MT_1.Text = _FichaProducto.f_PrdDeposito.RegistroDato._Ubicacion_1
                Me.MT_2.Text = _FichaProducto.f_PrdDeposito.RegistroDato._Ubicacion_2
                Me.MT_3.Text = _FichaProducto.f_PrdDeposito.RegistroDato._Ubicacion_3
                Me.MT_4.Text = _FichaProducto.f_PrdDeposito.RegistroDato._Ubicacion_4
                Me.MN_1.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdDeposito.RegistroDato._NivelMinimo)
                Me.MN_2.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdDeposito.RegistroDato._NivelOptimo)

                Dim xreal As Decimal = 0
                Dim xreservada As Decimal = 0
                Dim xdisponible As Decimal = 0

                If _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra > 0 Then
                    xreal = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReal / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
                    xreservada = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReservada / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
                    xdisponible = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaDisponible / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
                End If

                Me.E_EXISTENCIA_ACTUAL.Text = String.Format("{0:#0.00}", xreal)
                Me.E_EXISTENCIA_RESERVA.Text = String.Format("{0:#0.00}", xreservada)
                Me.E_EXISTENCIA_DISPONIBLE.Text = String.Format("{0:#0.00}", xdisponible)
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub L_EXISTENCIA_RESERVA_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles L_EXISTENCIA_RESERVA.LinkClicked
        Dim xficha As New ExistenciaReservada(_FichaProducto.f_PrdProducto.RegistroDato._AutoProducto)
        With xficha
            .ShowDialog()
        End With
    End Sub

    Private Sub L_DEPOSITOS_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles L_DEPOSITOS.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Deposito.F_Permitir()

            Dim xForm As New Plantilla_11(New Depositos)
            With xForm
                AddHandler .ActualizarFicha, AddressOf CargarDepositos
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarRegistro()
    End Sub

    Sub AgregarRegistro()
        If xbs_depositos.Current IsNot Nothing Then
            If MessageBox.Show("Estas Seguro De Agregar Este Deposito A Este Producto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xr As DataRow = CType(xbs_depositos.Current, DataRowView).Row
                    Dim xdep As New FichaGlobal.c_Depositos.c_Registro
                    xdep.CargarData(xr)

                    Dim xagregar As New FichaProducto.Prd_Producto.c_AgregarProductoDeposito
                    With xagregar
                        ._AutoDeposito = xdep._Automatico
                        ._AutoProducto = _FichaProducto.f_PrdProducto.RegistroDato._AutoProducto
                    End With
                    _FichaProducto.f_PrdProducto.F_AgregarDeposito(xagregar)
                    RaiseEvent _ActualizarCargaDepositos(_FichaProducto.f_PrdProducto.RegistroDato._AutoProducto)

                    'CargarDepositos()
                    'Funciones.MensajeDeOk("Movimiento Realizado Satisfactoriamente... ")
                    Me.Close()
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarRegistro()
    End Sub

    Sub EliminarRegistro()
        If xbs_depositos_prd.Current IsNot Nothing Then
            If MessageBox.Show("Estas Seguro De Eliminar Este Deposito A Este Producto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xr As DataRow = CType(xbs_depositos_prd.Current, DataRowView).Row
                    Dim xprd_dep As New FichaProducto.Prd_Deposito
                    xprd_dep.M_CargarRegistro(xr)

                    Dim xagregar As New FichaProducto.Prd_Producto.c_AgregarProductoDeposito
                    With xagregar
                        ._AutoDeposito = xprd_dep.RegistroDato._AutoDeposito
                        ._AutoProducto = xprd_dep.RegistroDato._AutoProducto
                    End With
                    _FichaProducto.f_PrdProducto.F_EliminarDeposito(xagregar)
                    RaiseEvent _ActualizarDepositos()
                    CargarDepositos()
                    Funciones.MensajeDeOk("Movimiento Realizado Satisfactoriamente... ")
                    Me.Close()
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarRegistro()
    End Sub

    Sub ModificarRegistro()
        _FichaAccion = Accion.Modificar
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        Grabar()
    End Sub

    Sub Grabar()
        If MessageBox.Show("Estas Seguro De Guardar Estos Cambios Para Este Producto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xr As DataRow = CType(xbs_depositos_prd.Current, DataRowView).Row
                Dim xprd_dep As New FichaProducto.Prd_Deposito
                xprd_dep.M_CargarRegistro(xr)

                Dim xmod As New FichaProducto.Prd_Producto.c_ModificarDatosDeposito
                With xmod
                    ._NivelMinimo = MN_1._Valor
                    ._NivelOptimo = MN_2._Valor
                    ._Ubicacion1 = MT_1.r_Valor
                    ._Ubicacion2 = MT_2.r_Valor
                    ._Ubicacion3 = MT_3.r_Valor
                    ._Ubicacion4 = MT_4.r_Valor
                    ._FichaProductoDeposito = _FichaProducto.f_PrdDeposito.RegistroDato
                End With
                _FichaProducto.f_PrdProducto.F_ModficarDatosDeposito(xmod)
                RaiseEvent _ActualizarCargaDepositos(_FichaProducto.f_PrdProducto.RegistroDato._AutoProducto)
                Me._FichaAccion = Accion.Consulta

                Me.Close()
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        Else
            Me.MT_1.Select()
            Me.MT_1.Focus()
        End If
    End Sub
End Class