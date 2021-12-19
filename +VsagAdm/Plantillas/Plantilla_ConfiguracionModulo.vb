Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plantilla_ConfiguracionModulo
    Dim xplantilla As IPlantilla_ConfiguracionModulo

    Property _MiPlantilla() As IPlantilla_ConfiguracionModulo
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantilla_ConfiguracionModulo)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplant As IPlantilla_ConfiguracionModulo)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiPlantilla = xplant
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        _MiPlantilla.Inicializa(Me)
    End Sub
End Class

Public Interface IPlantilla_ConfiguracionModulo
    Sub Inicializa(ByVal xobj As Object)
End Interface

Public Class ListaGrupoCliente
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaProducto.Prd_Grupo.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Lista De Grupos"
            lb_2.Text = ""
            _MiFormulario.Text = "Clientes - Grupos"

            g_MiData.F_GetData("select nombre xnom, * from grupo_cliente order by nombre", xtb)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Grupo")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarFicha(xr)
            Me.lb_2.Text = xficha._Nombre
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaProducto.Prd_Grupo.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("CLIENTE_01", xficha._Automatico, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ListaCobradores
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaCobradores.c_Cobrador.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Cobradores"
            lb_2.Text = ""
            _MiFormulario.Text = "Cobradores"

            g_MiData.F_GetData("select nombre xnom, * from cobradores order by nombre", xtb)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Nombre")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarRegistro(xr)
            Me.lb_2.Text = xficha.r_NombreCobrador
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaCobradores.c_Cobrador.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("CLIENTE_05", xficha.r_Automatico, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ListaVendedores
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaVendedores.c_Vendedor.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Vendedores"
            lb_2.Text = ""
            _MiFormulario.Text = "Vendedores"

            g_MiData.F_GetData("select nombre xnom, * from vendedores order by nombre", xtb)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Nombre")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarRegistro(xr)
            Me.lb_2.Text = xficha.r_NombreVendedor
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaVendedores.c_Vendedor.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("CLIENTE_04", xficha.r_Automatico, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ListaEstados
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaGlobal.c_Estados.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Estados"
            lb_2.Text = ""
            _MiFormulario.Text = "Estados"

            g_MiData.F_GetData("select nombre xnom, * from estados order by nombre", xtb)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Nombre")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarRegistro(xr)
            Me.lb_2.Text = xficha._NombreEstado
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaGlobal.c_Estados.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("CLIENTE_02", xficha._AutoEstado, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ListaZonasCliente
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaClientes.c_Zonas.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            Dim xestado As String = ""
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Zonas"
            lb_2.Text = ""
            _MiFormulario.Text = "Zonas"

            xestado = F_GetString("select usuario from opciones where codigo='CLIENTE_02'")
            Dim xp1 As New SqlParameter("@estado", xestado)
            g_MiData.F_GetData("select nombre xnom, * from zona_cliente where auto_estado=@estado order by nombre", xtb, xp1)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Nombre")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarRegistro(xr)
            Me.lb_2.Text = xficha.r_NombreZona
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaClientes.c_Zonas.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("CLIENTE_03", xficha.r_Automatico, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ListaMarcasProducto
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaProducto.Prd_Marca.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Marcas"
            lb_2.Text = ""
            _MiFormulario.Text = "Marcas"

            g_MiData.F_GetData("select nombre xnom, * from productos_marca order by nombre", xtb)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Nombre")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarFicha(xr)
            Me.lb_2.Text = xficha._Nombre
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaProducto.Prd_Marca.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("INVENT_01", xficha._Auto, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ListaEmpaquesProducto_Compra
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaProducto.Prd_Medida.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Medida/Empaque"
            lb_2.Text = ""
            _MiFormulario.Text = "Medida/Empaque"

            g_MiData.F_GetData("select nombre xnom, * from productos_medida order by nombre", xtb)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Nombre")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarData(xr)
            Me.lb_2.Text = xficha._NombreMedida
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaProducto.Prd_Medida.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("INVENT_02", xficha._Automatico, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ListaEmpaquesProducto_Venta
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaProducto.Prd_Medida.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Medida/Empaque"
            lb_2.Text = ""
            _MiFormulario.Text = "Medida/Empaque"

            g_MiData.F_GetData("select nombre xnom, * from productos_medida order by nombre", xtb)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Nombre")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarData(xr)
            Me.lb_2.Text = xficha._NombreMedida
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaProducto.Prd_Medida.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("INVENT_03", xficha._Automatico, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class DepositoAsignado
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaGlobal.c_Depositos.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Depositos"
            lb_2.Text = ""
            _MiFormulario.Text = "Depositos"

            g_MiData.F_GetData("select nombre xnom, * from depositos order by nombre", xtb)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Nombre")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarData(xr)
            Me.lb_2.Text = xficha._Codigo
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaGlobal.c_Depositos.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_16", xficha._Automatico, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ModoPagoPorDefecto
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaGlobal.c_MediosPagos.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Medios Pagos"
            lb_2.Text = ""
            _MiFormulario.Text = "Medios Pagos"

            g_MiData.F_GetData("select nombre xnom, * from medios_pago order by nombre", xtb)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Nombre")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarFicha(xr)
            Me.lb_2.Text = xficha._NombreTipoPago
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaGlobal.c_MediosPagos.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_17", xficha._AutoTipoPago, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class DepositoAsignadoCompras
    Implements IPlantilla_ConfiguracionModulo
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents mg_1 As MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As FichaGlobal.c_Depositos.c_Registro
    Dim xid As Byte()

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _ID() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            mg_1 = _MiFormulario.Controls.Find("MG_1", True)(0)

            lb_1.Text = "Depositos"
            lb_2.Text = ""
            _MiFormulario.Text = "Depositos"

            g_MiData.F_GetData("select nombre xnom, * from depositos order by nombre", xtb)
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            ActualizaData()
            With mg_1
                .Columns.Add("col0", "Nombre")

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(2)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarData()
        ActualizaData()
    End Sub

    Sub ActualizaData()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xficha.CargarData(xr)
            Me.lb_2.Text = xficha._Codigo
        Else
            Me.lb_2.Text = ""
        End If
    End Sub

    Sub New(ByVal xid As Byte())
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaGlobal.c_Depositos.c_Registro

        _ID = xid
    End Sub

    Private Sub mg_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles mg_1.Accion
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_19", xficha._Automatico, _ID)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class