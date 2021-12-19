Imports DataSistema.MiDataSistema.DataSistema

''' <summary>
''' DEFINE EL FUNCIONAMIENTO GENERAL DE LA PLANTILLA
''' </summary>
Public Class Plantilla_1
    Event ActualizarFicha()

    Dim pb_tm As Size
    Dim xf_accion As TipoAccionFicha
    Dim xplantilla As IPlantilla_1

    Sub ApagarControles()
        Me.PB_1.Enabled = False
        Me.PB_2.Enabled = False
        Me.PB_3.Enabled = False
        Me.MisGrid1.Enabled = False
    End Sub

    Sub EncenderControles()
        Me.MT_1.Enabled = False
        Me.BT_GRABAR.Enabled = False

        Me.PB_1.Enabled = True
        Me.PB_2.Enabled = True
        Me.PB_3.Enabled = True
        Me.MisGrid1.Enabled = True
    End Sub

    Property _FichaAccion() As TipoAccionFicha
        Get
            Return xf_accion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xf_accion = value

            If value = TipoAccionFicha.Consultar Then
                EncenderControles()
                Me.MisGrid1.Select()
                Me.MisGrid1.Focus()
            End If

            If value = TipoAccionFicha.Adicionar Then
                Me.MT_1.Enabled = True
                Me.MT_1.Text = ""
                Me.BT_GRABAR.Enabled = True
                ApagarControles()
                Me.MT_1.Select()
                Me.MT_1.Focus()
            End If

            If value = TipoAccionFicha.Modificar Then
                Me.MT_1.Enabled = True
                Me.BT_GRABAR.Enabled = True
                ApagarControles()
                Me.MT_1.Select()
                Me.MT_1.Focus()
            End If
        End Set
    End Property

    Property _MiPlantilla() As IPlantilla_1
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantilla_1)
            xplantilla = value
        End Set
    End Property

    WriteOnly Property _TituloFormulario() As String
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    WriteOnly Property _TituloVentana() As String
        Set(ByVal value As String)
            Me.E_TITULO.Text = value
        End Set
    End Property

    WriteOnly Property _Cabecera() As String
        Set(ByVal value As String)
            Me.E_CABECERA.Text = value
        End Set
    End Property

    WriteOnly Property _TotalRegistros() As Integer
        Set(ByVal value As Integer)
            Me.E_REGISTROS.Text = String.Format("{0:0}", Me._MiPlantilla._TotalRegistro)
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

    Private Sub Plantilla_1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FichaAccion = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If _FichaAccion = TipoAccionFicha.Adicionar Or _FichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Estas Seguro De Peder Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                    Me._MiPlantilla._ActualizarRegistro()
                    Me._FichaAccion = TipoAccionFicha.Consultar
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub Plantilla_1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub Plantilla_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Sub New(ByVal xplantilla As IPlantilla_1)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._MiPlantilla = xplantilla
        AddHandler Me._MiPlantilla.RegistroEditar, AddressOf Informa
    End Sub

    Sub Informa(ByVal xdata As String)
        Me.MT_1.Text = xdata
        Me._TotalRegistros = Me._MiPlantilla._TotalRegistro
    End Sub

    Sub Inicializa()
        Try
            Me._FichaAccion = TipoAccionFicha.Consultar

            pb_tm = PB_1.Size
            With Me.MT_1
                .Text = ""
                .MaxLength = Me._MiPlantilla._LargoEntrada
            End With

            Me._MiPlantilla._MiGrid(MisGrid1)
            Me._Cabecera = Me._MiPlantilla._Cabecera
            Me._TituloFormulario = Me._MiPlantilla._TituloFormulario
            Me._TituloVentana = Me._MiPlantilla._TituloVentana
            Me._TotalRegistros = Me._MiPlantilla._TotalRegistro

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

    Private Sub Plantilla_1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarRegistro()
    End Sub

    Sub EliminarRegistro()
        If Me._MiPlantilla._EliminarRegistro() Then
            RaiseEvent ActualizarFicha()
        End If
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarRegistro()
    End Sub

    Sub AgregarRegistro()
        If Me._MiPlantilla._VerificarSiPuedoAgregarRegistro Then
            Me._FichaAccion = TipoAccionFicha.Adicionar
        End If
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        Grabar()
    End Sub

    Sub Grabar()
        If _FichaAccion = TipoAccionFicha.Adicionar Then
            If Me._MiPlantilla._AdicionaRegistro(Me.MT_1.r_Valor) Then
                Me._FichaAccion = TipoAccionFicha.Consultar
                RaiseEvent ActualizarFicha()
            Else
                Me.MT_1.Select()
            End If
        Else
            If Me._MiPlantilla._ModificaRegistro(Me.MT_1.r_Valor) Then
                Me._FichaAccion = TipoAccionFicha.Consultar
                RaiseEvent ActualizarFicha()
            Else
                Me.MT_1.Select()
            End If
        End If
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarRegistro()
    End Sub

    Sub ModificarRegistro()
        If Me._MiPlantilla._VerificarSiPuedoModificarRegistro Then
            Me._FichaAccion = TipoAccionFicha.Modificar
        End If
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class

''' <summary>
''' DEFINE LA INTERFAZ A SOLICITAR PARA LAS CLASES A TRABAJAR
''' </summary>
Public Interface IPlantilla_1
    Event RegistroEditar(ByVal xdata As String)
    ReadOnly Property _TituloFormulario() As String
    ReadOnly Property _TituloVentana() As String
    ReadOnly Property _Cabecera() As String
    ReadOnly Property _LargoEntrada() As Integer
    ReadOnly Property _TotalRegistro() As Integer

    Sub _MiGrid(ByRef xgrid As MisControles.Controles.MisGrid)
    Sub _ActualizarRegistro()

    Function _VerificarSiPuedoAgregarRegistro() As Boolean
    Function _VerificarSiPuedoModificarRegistro() As Boolean
    Function _VerificarSiPuedoEliminarRegistro() As Boolean

    Function _AdicionaRegistro(ByVal xtexto As String) As Boolean
    Function _ModificaRegistro(ByVal xtexto As String) As Boolean
    Function _EliminarRegistro() As Boolean
End Interface

''' <summary>
''' CLASE GRUPO DE CLIENTES
''' </summary>
Public Class GrupoCliente
    Implements IPlantilla_1

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xfichacligrupo As FichaClientes.c_Grupos

    Public Event RegistroEditar(ByVal xdata As String) Implements IPlantilla_1.RegistroEditar

    Public ReadOnly Property _Cabecera() As String Implements IPlantilla_1._Cabecera
        Get
            Return "Grupo:"
        End Get
    End Property

    Public ReadOnly Property _TituloFormulario() As String Implements IPlantilla_1._TituloFormulario
        Get
            Return "Clientes"
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_1._TituloVentana
        Get
            Return "Control De Grupos"
        End Get
    End Property

    Public ReadOnly Property _TotalRegistro() As Integer Implements IPlantilla_1._TotalRegistro
        Get
            If xbs IsNot Nothing Then
                Return xbs.Count
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property _LargoEntrada() As Integer Implements IPlantilla_1._LargoEntrada
        Get
            Return xfichacligrupo.RegistroDato.c_NombreGrupo.c_Largo
        End Get
    End Property

    Public Sub _MiGrid(ByRef xgrid As MisControles.Controles.MisGrid) Implements IPlantilla_1._MiGrid
        Try
            xtb = New DataTable
            CargarData()
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With xgrid
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            Throw New Exception("CARGA DEL GRID:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from grupo_cliente order by nombre", xtb)
    End Sub

    Sub New()
        xfichacligrupo = New FichaClientes.c_Grupos
        AddHandler xfichacligrupo.Actualizar, AddressOf CargarData
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xfichacligrupo.M_CargarFicha(CType(xbs.Current, System.Data.DataRowView).Row)
        Else
            xfichacligrupo.RegistroDato.M_LimpiarRegistro()
        End If
        RaiseEvent RegistroEditar(xfichacligrupo.RegistroDato.c_NombreGrupo.c_Texto)
    End Sub

    Public Sub _ActualizarRegistro() Implements IPlantilla_1._ActualizarRegistro
        Actualiza()
    End Sub

    Public Function _AdicionaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._AdicionaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Agregar Este Nuevo Grupo ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    xfichacligrupo.F_NuevoGrupo(xtexto)
                    MessageBox.Show("Grupo Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre Del Grupo, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _ModificaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._ModificaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Guardar Estos Cambios ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xgrupomod As New FichaClientes.c_Grupos.c_ModificarGrupo
                    With xgrupomod
                        .c_AutomaticoGrupo = xfichacligrupo.RegistroDato.r_Automatico
                        .c_IdSeguridad = xfichacligrupo.RegistroDato.r_IdSeguridad
                        .c_NombreGrupo = xtexto
                    End With

                    xfichacligrupo.F_ModificaGrupo(xgrupomod)
                    MessageBox.Show("Grupo Actualizado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre Del Grupo, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _EliminarRegistro() As Boolean Implements IPlantilla_1._EliminarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoCliente_Eliminar.F_Permitir()

                If MessageBox.Show("Estas Seguro De Eliminar Dicho Grupo ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    xfichacligrupo.F_EliminaGrupo(xfichacligrupo.RegistroDato.r_Automatico)
                    MessageBox.Show("Grupo Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _VerificarSiPuedoAgregarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoAgregarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoCliente_Ingresar.F_Permitir()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _VerificarSiPuedoEliminarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoEliminarRegistro
    End Function

    Public Function _VerificarSiPuedoModificarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoModificarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoCliente_Modificar.F_Permitir()
                Return True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function
End Class


''' <summary>
''' CLASE GRUPO PROVEEDORES
''' </summary>
Public Class GrupoProveedor
    Implements IPlantilla_1

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xfichacligrupo As FichaProveedores.c_Grupos

    Public Event RegistroEditar(ByVal xdata As String) Implements IPlantilla_1.RegistroEditar

    Public ReadOnly Property _Cabecera() As String Implements IPlantilla_1._Cabecera
        Get
            Return "Grupo:"
        End Get
    End Property

    Public ReadOnly Property _TituloFormulario() As String Implements IPlantilla_1._TituloFormulario
        Get
            Return "Proveedores"
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_1._TituloVentana
        Get
            Return "Control De Grupos"
        End Get
    End Property

    Public ReadOnly Property _TotalRegistro() As Integer Implements IPlantilla_1._TotalRegistro
        Get
            If xbs IsNot Nothing Then
                Return xbs.Count
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property _LargoEntrada() As Integer Implements IPlantilla_1._LargoEntrada
        Get
            Return xfichacligrupo.RegistroDato.c_NombreGrupo.c_Largo
        End Get
    End Property

    Public Sub _MiGrid(ByRef xgrid As MisControles.Controles.MisGrid) Implements IPlantilla_1._MiGrid
        Try
            xtb = New DataTable
            CargarData()
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With xgrid
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            Throw New Exception("CARGA DEL GRID:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from grupo_proveedor order by nombre", xtb)
    End Sub

    Sub New()
        xfichacligrupo = New FichaProveedores.c_Grupos
        AddHandler xfichacligrupo.Actualizar, AddressOf CargarData
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xfichacligrupo.M_CargarFicha(CType(xbs.Current, System.Data.DataRowView).Row)
        Else
            xfichacligrupo.RegistroDato.M_LimpiarRegistro()
        End If
        RaiseEvent RegistroEditar(xfichacligrupo.RegistroDato.c_NombreGrupo.c_Texto)
    End Sub

    Public Sub _ActualizarRegistro() Implements IPlantilla_1._ActualizarRegistro
        Actualiza()
    End Sub

    Public Function _AdicionaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._AdicionaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Agregar Este Nuevo Grupo ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    xfichacligrupo.F_NuevoGrupo(xtexto)
                    MessageBox.Show("Grupo Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre Del Grupo, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _ModificaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._ModificaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Guardar Estos Cambios ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xgrupomod As New FichaProveedores.c_Grupos.c_ModificarGrupo
                    With xgrupomod
                        .c_AutomaticoGrupo = xfichacligrupo.RegistroDato.r_Automatico
                        .c_IdSeguridad = xfichacligrupo.RegistroDato.r_IdSeguridad
                        .c_NombreGrupo = xtexto
                    End With

                    xfichacligrupo.F_ModificaGrupo(xgrupomod)
                    MessageBox.Show("Grupo Actualizado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre Del Grupo, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _EliminarRegistro() As Boolean Implements IPlantilla_1._EliminarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoProveedor_Eliminar.F_Permitir()

                If MessageBox.Show("Estas Seguro De Eliminar Dicho Grupo ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    xfichacligrupo.F_EliminaGrupo(xfichacligrupo.RegistroDato.r_Automatico)
                    MessageBox.Show("Grupo Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _VerificarSiPuedoAgregarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoAgregarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoProveedor_Ingresar.F_Permitir()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _VerificarSiPuedoEliminarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoEliminarRegistro
    End Function

    Public Function _VerificarSiPuedoModificarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoModificarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoProveedor_Modificar.F_Permitir()
                Return True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function
End Class


''' <summary>
''' CLASE AGENCIAS BANCARIAS
''' </summary>
Public Class Agencias
    Implements IPlantilla_1

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xfichaagencia As FichaBancos.c_Agencias

    Public Event RegistroEditar(ByVal xdata As String) Implements IPlantilla_1.RegistroEditar

    Public ReadOnly Property _Cabecera() As String Implements IPlantilla_1._Cabecera
        Get
            Return "Agencia:"
        End Get
    End Property

    Public ReadOnly Property _TituloFormulario() As String Implements IPlantilla_1._TituloFormulario
        Get
            Return "Agencias Bancarias"
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_1._TituloVentana
        Get
            Return "Control De Agencias"
        End Get
    End Property

    Public ReadOnly Property _TotalRegistro() As Integer Implements IPlantilla_1._TotalRegistro
        Get
            If xbs IsNot Nothing Then
                Return xbs.Count
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property _LargoEntrada() As Integer Implements IPlantilla_1._LargoEntrada
        Get
            Return xfichaagencia.RegistroDato.c_NombreAgencia.c_Largo
        End Get
    End Property

    Public Sub _MiGrid(ByRef xgrid As MisControles.Controles.MisGrid) Implements IPlantilla_1._MiGrid
        Try
            xtb = New DataTable
            CargarData()
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With xgrid
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            Throw New Exception("CARGA DEL GRID:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from agencias order by nombre", xtb)
    End Sub

    Sub New()
        xfichaagencia = New FichaBancos.c_Agencias
        AddHandler xfichaagencia.Actualizar, AddressOf CargarData
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xfichaagencia.M_CargarFicha(CType(xbs.Current, System.Data.DataRowView).Row)
        Else
            xfichaagencia.RegistroDato.LimpiarRegistro()
        End If
        RaiseEvent RegistroEditar(xfichaagencia.RegistroDato.c_NombreAgencia.c_Texto)
    End Sub

    Public Sub _ActualizarRegistro() Implements IPlantilla_1._ActualizarRegistro
        Actualiza()
    End Sub

    Public Function _AdicionaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._AdicionaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Agregar Esta Nueva Agencia ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    xfichaagencia.F_NuevoAgencia(xtexto)
                    MessageBox.Show("Agencia Agregada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre Del Grupo, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _ModificaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._ModificaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Guardar Estos Cambios ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xagenciamod As New FichaBancos.c_Agencias.c_ModificarAgencia
                    With xagenciamod
                        .c_AutomaticoAgencia = xfichaagencia.RegistroDato._Automatico
                        .c_IdSeguridad = xfichaagencia.RegistroDato._IdSeguridad
                        .c_NombreAgencia = xtexto
                    End With

                    xfichaagencia.F_ModificaGrupo(xagenciamod)
                    MessageBox.Show("Agencia Actualizada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre De Agencia, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _EliminarRegistro() As Boolean Implements IPlantilla_1._EliminarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloAgenciaBancaria_Eliminar.F_Permitir()

                If MessageBox.Show("Estas Seguro De Eliminar Esta Agencia ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    xfichaagencia.F_EliminaAgencia(xfichaagencia.RegistroDato._Automatico)
                    MessageBox.Show("Agencia Eliminada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _VerificarSiPuedoAgregarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoAgregarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloAgenciaBancaria_Ingresar.F_Permitir()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _VerificarSiPuedoEliminarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoEliminarRegistro
    End Function

    Public Function _VerificarSiPuedoModificarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoModificarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloAgenciaBancaria_Modificar.F_Permitir()

                Return True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function
End Class

''' <summary>
''' CLASE GRUPO USUARIOS
''' </summary>
Public Class GrupoUsuario
    Implements IPlantilla_1

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xgrupo As FichaGlobal.c_GrupoUsuarios

    Public Event RegistroEditar(ByVal xdata As String) Implements IPlantilla_1.RegistroEditar

    Public ReadOnly Property _Cabecera() As String Implements IPlantilla_1._Cabecera
        Get
            Return "Grupo:"
        End Get
    End Property

    Public ReadOnly Property _TituloFormulario() As String Implements IPlantilla_1._TituloFormulario
        Get
            Return "Usuarios"
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_1._TituloVentana
        Get
            Return "Control De Grupos"
        End Get
    End Property

    Public ReadOnly Property _TotalRegistro() As Integer Implements IPlantilla_1._TotalRegistro
        Get
            If xbs IsNot Nothing Then
                Return xbs.Count
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property _LargoEntrada() As Integer Implements IPlantilla_1._LargoEntrada
        Get
            Return xgrupo.RegistroDato.c_Nombre.c_Largo
        End Get
    End Property

    Public Sub _MiGrid(ByRef xgrid As MisControles.Controles.MisGrid) Implements IPlantilla_1._MiGrid
        Try
            xtb = New DataTable
            CargarData()
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With xgrid
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            Throw New Exception("CARGA DEL GRID:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from grupo_usuario order by nombre", xtb)
    End Sub

    Sub New()
        xgrupo = New FichaGlobal.c_GrupoUsuarios
        AddHandler xgrupo.Actualizar, AddressOf CargarData
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xgrupo.M_CargarRegistro(CType(xbs.Current, System.Data.DataRowView).Row)
        Else
            xgrupo.RegistroDato.LimpiarRegistro()
        End If
        RaiseEvent RegistroEditar(xgrupo.RegistroDato._NombreGrupo)
    End Sub

    Public Sub _ActualizarRegistro() Implements IPlantilla_1._ActualizarRegistro
        Actualiza()
    End Sub

    Public Function _AdicionaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._AdicionaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Agregar Este Nuevo Grupo ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    xgrupo.F_NuevoGrupo(xtexto)
                    MessageBox.Show("Grupo Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre Del Grupo, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _ModificaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._ModificaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Guardar Estos Cambios ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xgrupomod As New FichaGlobal.c_GrupoUsuarios.c_ModificarGrupo
                    With xgrupomod
                        ._AutomatoGrupo = xgrupo.RegistroDato._AutoGrupo
                        ._IdSeguridad = xgrupo.RegistroDato._IdSeguridad
                        ._NombreGrupo = xtexto
                    End With

                    xgrupo.F_ModificaGrupo(xgrupomod)
                    MessageBox.Show("Grupo Actualizado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre Del Grupo, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _EliminarRegistro() As Boolean Implements IPlantilla_1._EliminarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoUsuario_Eliminar.F_Permitir()

                If MessageBox.Show("Estas Seguro De Eliminar Dicho Grupo ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    xgrupo.F_EliminaGrupo(xgrupo.RegistroDato._AutoGrupo)
                    MessageBox.Show("Grupo Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _VerificarSiPuedoAgregarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoAgregarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoUsuario_Ingresar.F_Permitir()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _VerificarSiPuedoEliminarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoEliminarRegistro
    End Function

    Public Function _VerificarSiPuedoModificarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoModificarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoUsuario_Modificar.F_Permitir()
                Return True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function
End Class

''' <summary>
''' CLASE PRODUCTOS: DEPARTAMENTOS
''' </summary>
Public Class ProductosDepartamento
    Implements IPlantilla_1

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xgrupo As FichaProducto.Prd_Departamento

    Public Event RegistroEditar(ByVal xdata As String) Implements IPlantilla_1.RegistroEditar

    Public ReadOnly Property _Cabecera() As String Implements IPlantilla_1._Cabecera
        Get
            Return "Departamento:"
        End Get
    End Property

    Public ReadOnly Property _TituloFormulario() As String Implements IPlantilla_1._TituloFormulario
        Get
            Return "Productos"
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_1._TituloVentana
        Get
            Return "Control De Departamentos"
        End Get
    End Property

    Public ReadOnly Property _TotalRegistro() As Integer Implements IPlantilla_1._TotalRegistro
        Get
            If xbs IsNot Nothing Then
                Return xbs.Count
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property _LargoEntrada() As Integer Implements IPlantilla_1._LargoEntrada
        Get
            Return xgrupo.RegistroDato.c_NombreDepart.c_Largo
        End Get
    End Property

    Public Sub _MiGrid(ByRef xgrid As MisControles.Controles.MisGrid) Implements IPlantilla_1._MiGrid
        Try
            xtb = New DataTable
            CargarData()
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With xgrid
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            Throw New Exception("CARGA DEL GRID:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from productos_departamento order by nombre", xtb)
    End Sub

    Sub New()
        xgrupo = New FichaProducto.Prd_Departamento
        AddHandler xgrupo.Actualizar, AddressOf CargarData
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xgrupo.M_CargarRegistro(CType(xbs.Current, System.Data.DataRowView).Row)
        Else
            xgrupo.RegistroDato.LimpiarRegistro()
        End If
        RaiseEvent RegistroEditar(xgrupo.RegistroDato._Nombre)
    End Sub

    Public Sub _ActualizarRegistro() Implements IPlantilla_1._ActualizarRegistro
        Actualiza()
    End Sub

    Public Function _AdicionaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._AdicionaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Agregar Este Nuevo Departamento ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    xgrupo.F_AgregarRegistro(xtexto)
                    MessageBox.Show("Departamento Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre Del Departamento, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _ModificaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._ModificaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Guardar Estos Cambios ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xgrupomod As New FichaProducto.Prd_Departamento.c_ModificarDepart
                    With xgrupomod
                        ._AutoDepart = xgrupo.RegistroDato._Auto
                        ._IdSeguridad = xgrupo.RegistroDato._IdSeguridad
                        ._NombreDepart = xtexto
                    End With

                    xgrupo.F_ModificaDepartamento(xgrupomod)
                    MessageBox.Show("Departamento Actualizado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre Del Departamento, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _EliminarRegistro() As Boolean Implements IPlantilla_1._EliminarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Depart_Eliminar.F_Permitir()

                If MessageBox.Show("Estas Seguro De Eliminar Dicho Departamento ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    xgrupo.F_EliminarRegistro(xgrupo.RegistroDato._Auto)
                    MessageBox.Show("Departamento Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _VerificarSiPuedoAgregarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoAgregarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Depart_Ingresar.F_Permitir()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _VerificarSiPuedoEliminarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoEliminarRegistro
    End Function

    Public Function _VerificarSiPuedoModificarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoModificarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Depart_Modificar.F_Permitir()
                Return True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function
End Class

''' <summary>
''' CLASE PRODUCTOS: MARCAS
''' </summary>
Public Class ProductosMarcas
    Implements IPlantilla_1

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xgrupo As FichaProducto.Prd_Marca

    Public Event RegistroEditar(ByVal xdata As String) Implements IPlantilla_1.RegistroEditar

    Public ReadOnly Property _Cabecera() As String Implements IPlantilla_1._Cabecera
        Get
            Return "Marcas:"
        End Get
    End Property

    Public ReadOnly Property _TituloFormulario() As String Implements IPlantilla_1._TituloFormulario
        Get
            Return "Productos"
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_1._TituloVentana
        Get
            Return "Control De Marcas"
        End Get
    End Property

    Public ReadOnly Property _TotalRegistro() As Integer Implements IPlantilla_1._TotalRegistro
        Get
            If xbs IsNot Nothing Then
                Return xbs.Count
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property _LargoEntrada() As Integer Implements IPlantilla_1._LargoEntrada
        Get
            Return xgrupo.RegistroDato.c_NombreMarca.c_Largo
        End Get
    End Property

    Public Sub _MiGrid(ByRef xgrid As MisControles.Controles.MisGrid) Implements IPlantilla_1._MiGrid
        Try
            xtb = New DataTable
            CargarData()
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With xgrid
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            Throw New Exception("CARGA DEL GRID:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from productos_marca order by nombre", xtb)
    End Sub

    Sub New()
        xgrupo = New FichaProducto.Prd_Marca
        AddHandler xgrupo.Actualizar, AddressOf CargarData
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xgrupo.M_CargarRegistro(CType(xbs.Current, System.Data.DataRowView).Row)
        Else
            xgrupo.RegistroDato.LimpiarRegistro()
        End If
        RaiseEvent RegistroEditar(xgrupo.RegistroDato._Nombre)
    End Sub

    Public Sub _ActualizarRegistro() Implements IPlantilla_1._ActualizarRegistro
        Actualiza()
    End Sub

    Public Function _AdicionaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._AdicionaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Agregar Esta Nueva Marca?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    xgrupo.F_AgregarRegistro(xtexto)
                    MessageBox.Show("Marca Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre De la Marca, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _ModificaRegistro(ByVal xtexto As String) As Boolean Implements IPlantilla_1._ModificaRegistro
        If xtexto <> "" Then
            If MessageBox.Show("Estas Seguro De Guardar Estos Cambios ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xgrupomod As New FichaProducto.Prd_Marca.c_ModificarMarca
                    With xgrupomod
                        ._AutoMarca = xgrupo.RegistroDato._Auto
                        ._IdSeguridad = xgrupo.RegistroDato._IdSeguridad
                        ._NombreMarca = xtexto
                    End With

                    xgrupo.F_ModificaDepartamento(xgrupomod)
                    MessageBox.Show("Marca Actualizado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Error En El Nombre De la Marca, No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Function _EliminarRegistro() As Boolean Implements IPlantilla_1._EliminarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Marca_Eliminar.F_Permitir()

                If MessageBox.Show("Estas Seguro De Eliminar Dicho Marca ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    xgrupo.F_EliminarRegistro(xgrupo.RegistroDato._Auto)
                    MessageBox.Show("Marca Eliminada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _VerificarSiPuedoAgregarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoAgregarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Marca_Ingresar.F_Permitir()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _VerificarSiPuedoEliminarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoEliminarRegistro
    End Function

    Public Function _VerificarSiPuedoModificarRegistro() As Boolean Implements IPlantilla_1._VerificarSiPuedoModificarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Marca_Modificar.F_Permitir()
                Return True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function
End Class