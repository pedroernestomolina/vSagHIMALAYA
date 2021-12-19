Imports DataSistema.MiDataSistema.DataSistema.FichaProveedores

Public Class Plantilla_3
    Event ActualizarFicha()

    Dim pb_tm As Size
    Dim xf_accion As TipoAccionFicha
    Dim xplantilla As IPlantilla_3

    Dim xtb As DataTable
    Dim xbs As BindingSource

    Dim xtipo_cta() As String = {"Ahorro", "Corriente"}
    Dim xestatus_cta() As String = {"Activa/Habilitado", "Inactiva/Suspendida"}

    ReadOnly Property _TipoCta() As String()
        Get
            Return xtipo_cta
        End Get
    End Property

    ReadOnly Property _EstatusCta() As String()
        Get
            Return xestatus_cta
        End Get
    End Property

    Sub ControlesMenu(ByVal xop As Boolean)
        Me.PB_1.Enabled = xop
        Me.PB_2.Enabled = xop
        Me.PB_3.Enabled = xop
        Me.MisGrid1.Enabled = xop
    End Sub

    Sub ControlesEntrada(ByVal xop As Boolean)
        Me.MT_ANOMBRE.Enabled = xop
        Me.MT_NUMERO.Enabled = xop
        Me.MCB_AGENCIA.Enabled = xop
        Me.MCB_ESTATUS.Enabled = xop
        Me.MCB_TIPO.Enabled = xop

        Me.BT_GRABAR.Enabled = xop
    End Sub

    Sub ControlesEntradaLimpiar()
        Me.MT_ANOMBRE.Text = ""
        Me.MT_NUMERO.Text = ""
        Me.MCB_ESTATUS.SelectedIndex = 0
        Me.MCB_TIPO.SelectedIndex = 0
    End Sub

    Property _FichaAccion() As TipoAccionFicha
        Get
            Return xf_accion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xf_accion = value

            If value = TipoAccionFicha.Consultar Then
                ControlesMenu(True)
                ControlesEntrada(False)

                Me.MisGrid1.Select()
                Me.MisGrid1.Focus()
            End If

            If value = TipoAccionFicha.Adicionar Then
                ControlesMenu(False)
                ControlesEntrada(True)
                ControlesEntradaLimpiar()

                Me.MCB_AGENCIA.Select()
                Me.MCB_AGENCIA.Focus()
            End If

            If value = TipoAccionFicha.Modificar Then
                ControlesMenu(False)
                ControlesEntrada(True)

                Me.MCB_AGENCIA.Select()
                Me.MCB_AGENCIA.Focus()
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

    Sub CargarAgencias()
        Me.MCB_AGENCIA.Enabled = True
        g_MiData.F_GetData("select nombre,auto from agencias order by nombre", xtb)
        With Me.MCB_AGENCIA
            .DataSource = xbs
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xplantilla._ActualizarRegistro()

        If Me._FichaAccion = TipoAccionFicha.Adicionar Or Me._FichaAccion = TipoAccionFicha.Modificar Then
        Else
            Me.MCB_AGENCIA.Enabled = False
        End If
    End Sub

    Sub Inicializa()
        Try
            Me._FichaAccion = TipoAccionFicha.Consultar
            pb_tm = PB_1.Size

            Me.Text = Me.Plantilla._TituloVentana

            With Me.MCB_TIPO
                .DataSource = Me._TipoCta
                .SelectedIndex = 0
            End With

            With Me.MCB_ESTATUS
                .DataSource = Me._EstatusCta
                .SelectedIndex = 0
            End With

            xtb = New DataTable("Agencias")
            xbs = New BindingSource(xtb, "")

            Me.Plantilla._Controles(MisGrid1, MT_NUMERO, MT_ANOMBRE, MCB_AGENCIA, MCB_TIPO, MCB_ESTATUS, Me.E_TOTAL_REG)
            CargarAgencias()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error *** ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub Plantilla_3_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FichaAccion = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If _FichaAccion = TipoAccionFicha.Adicionar Or _FichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Estas Seguro De Peder Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                    Me.Plantilla._ActualizarRegistro()
                    Me._FichaAccion = TipoAccionFicha.Consultar
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub Plantilla_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_3_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Property Plantilla() As IPlantilla_3
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantilla_3)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantilla_3)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.Plantilla = xplantilla
    End Sub

    Private Sub Plantilla_3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarCta()
    End Sub

    Sub AgregarCta()
        If Me.Plantilla._VerificarSiPuedoAgregarRegistro Then
            Me._FichaAccion = TipoAccionFicha.Adicionar
        End If
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        Grabar()
    End Sub

    Sub Grabar()
        If Me.MT_ANOMBRE.r_Valor <> "" And Me.MT_NUMERO.r_Valor <> "" Then
            If _FichaAccion = TipoAccionFicha.Adicionar Then
                If Me.Plantilla._AdicionarRegistro() Then
                    Me._FichaAccion = TipoAccionFicha.Consultar
                    RaiseEvent ActualizarFicha()
                Else
                    Me.MCB_AGENCIA.Select()
                End If
            Else
                If Me.Plantilla._ModificarRegistro Then
                    Me._FichaAccion = TipoAccionFicha.Consultar
                    RaiseEvent ActualizarFicha()
                Else
                    Me.MCB_AGENCIA.Select()
                End If
            End If
        Else
            MessageBox.Show("Error... Faltan Campos Por Rellenar, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.MCB_AGENCIA.Select()
        End If
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarRegistro()
    End Sub

    Sub EliminarRegistro()
        If Me.Plantilla._EliminarRegistro() Then
            RaiseEvent ActualizarFicha()
        End If
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarRegistro()
    End Sub

    Sub ModificarRegistro()
        If Me.Plantilla._VerificarSiPuedoModificarRegistro Then
            Me._FichaAccion = TipoAccionFicha.Modificar
        End If
    End Sub

    Private Sub Plantilla_3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                AgregarCta()
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

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ControlAgencias()
    End Sub

    Sub ControlAgencias()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloAgenciaBancaria.F_Permitir()

            Dim xficha As New Plantilla_1(New Agencias)
            With xficha
                AddHandler .ActualizarFicha, AddressOf ActualizarAgencias
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarAgencias()
        CargarAgencias()
    End Sub
End Class

Public Interface IPlantilla_3
    ReadOnly Property _TituloVentana() As String
    Property _AutomaticoPlantillaGestionar() As String
    Sub _ActualizarRegistro()
    Sub _Controles(ByRef xgrid As MisControles.Controles.MisGrid, ByRef T_1 As MisControles.Controles.MisTextos, ByRef T_2 As MisControles.Controles.MisTextos, _
                   ByRef C_1 As MisControles.Controles.MisComboBox, ByRef C_2 As MisControles.Controles.MisComboBox, ByRef C_3 As MisControles.Controles.MisComboBox, _
                   ByRef E_1 As Label)
    Function _AdicionarRegistro() As Boolean
    Function _EliminarRegistro() As Boolean
    Function _ModificarRegistro() As Boolean

    Function _VerificarSiPuedoAgregarRegistro() As Boolean
    Function _VerificarSiPuedoModificarRegistro() As Boolean
    Function _VerificarSiPuedoEliminarRegistro() As Boolean
End Interface

''' <summary>
''' CLASE CTAS BANCARIAS PROVEEDOR
''' </summary>
Public Class ProveedorCtaBancaria
    Implements IPlantilla_3

    Dim xg As MisControles.Controles.MisGrid
    Dim t1 As MisControles.Controles.MisTextos
    Dim t2 As MisControles.Controles.MisTextos
    Dim c1 As MisControles.Controles.MisComboBox
    Dim c2 As MisControles.Controles.MisComboBox
    Dim c3 As MisControles.Controles.MisComboBox
    Dim e1 As System.Windows.Forms.Label

    Dim xautoplantilla_gestionar As String

    Dim xfichacta As c_CtasBancarias
    Dim xbs As BindingSource
    Dim xtb As DataTable

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_3._TituloVentana
        Get
            Return "Proveedores / Cuentas"
        End Get
    End Property

    Sub CargarData()
        Dim xsql As String = "select ag.nombre age ,pa.numero num, pa.nombre_id nom, pa.tipo tip, pa.* " _
            + " from proveedores_agencias pa join agencias ag on pa.auto_agencia=ag.auto where pa.auto_proveedor=@auto order by ag.nombre,pa.numero"
        Dim xpar1 As New SqlClient.SqlParameter("@auto", Me._AutomaticoPlantillaGestionar)

        g_MiData.F_GetData(xsql, xtb, xpar1)
    End Sub

    Sub ActualizarRegistros()
        CargarData()
        e1.Text = xbs.Count.ToString
    End Sub

    Sub New(ByVal xauto As String)
        Try
            xfichacta = New DataSistema.MiDataSistema.DataSistema.FichaProveedores.c_CtasBancarias
            AddHandler xfichacta.Actualizar, AddressOf ActualizarRegistros

            Me._AutomaticoPlantillaGestionar = xauto
            xtb = New DataTable("CtasProveedor")
            CargarData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarVista()
        ActualizaVista()
    End Sub

    Sub ActualizaVista()
        If xbs.Current IsNot Nothing Then
            Dim xrow As DataRow = CType(xbs.Current, System.Data.DataRowView).Row
            xfichacta.M_CargarFicha(xrow)

            Me.c1.SelectedValue = xfichacta.RegistroDato.c_AutomaticoAgencia.c_Texto
            Me.c2.SelectedItem = xfichacta.RegistroDato.c_TipoCta.c_Texto
            If xfichacta.RegistroDato.r_EstatusCta Then
                Me.c3.SelectedIndex = 0
            Else
                Me.c3.SelectedIndex = 1
            End If
        Else
            xfichacta.RegistroDato.M_LimpiarFicha()
            Me.c2.SelectedIndex = 0
            Me.c3.SelectedIndex = 0
        End If

        Me.t1.Text = xfichacta.RegistroDato.c_NumeroCta.c_Texto
        Me.t2.Text = xfichacta.RegistroDato.c_A_Favor_De.c_Texto
    End Sub

    Public Sub _Controles(ByRef xgrid As MisControles.Controles.MisGrid, ByRef T_1 As MisControles.Controles.MisTextos, _
                          ByRef T_2 As MisControles.Controles.MisTextos, ByRef C_1 As MisControles.Controles.MisComboBox, _
                          ByRef C_2 As MisControles.Controles.MisComboBox, ByRef C_3 As MisControles.Controles.MisComboBox, _
                          ByRef E_1 As System.Windows.Forms.Label) Implements IPlantilla_3._Controles

        Try
            xg = xgrid
            t1 = T_1
            t2 = T_2
            c1 = C_1
            c2 = C_2
            c3 = C_3
            e1 = E_1

            With t1
                .Text = ""
                .MaxLength = xfichacta.RegistroDato.c_NumeroCta.c_Largo
            End With

            With t2
                .Text = ""
                .MaxLength = xfichacta.RegistroDato.c_A_Favor_De.c_Largo
            End With

            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarVista
            ActualizaVista()
            e1.Text = xbs.Count.ToString

            With xg
                .Columns.Add("col0", "Agencia")
                .Columns.Add("col1", "Numero Cta")
                .Columns.Add("col2", "A Nombre De")
                .Columns.Add("col3", "Tipo")

                .Columns(0).Width = 100
                .Columns(1).Width = 100
                .Columns(3).Width = 100
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                AddHandler .CellFormatting, AddressOf MiFormato

                .DataSource = xbs
                .Columns(0).DataPropertyName = "age"
                .Columns(1).DataPropertyName = "num"
                .Columns(2).DataPropertyName = "nom"
                .Columns(3).DataPropertyName = "tip"

                .Ocultar(5)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If xg.Rows(e.RowIndex).Cells("estatus").Value.ToString.Trim = "1" Then
            xg.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Public Function _AdicionarRegistro() As Boolean Implements IPlantilla_3._AdicionarRegistro
        Try
            Dim xficha As New c_CtasBancarias.c_AgregarCta
            With xficha
                ._AutoProveedor = Me._AutomaticoPlantillaGestionar
                ._ANombreDe = Me.t2.r_Valor
                ._NumertoCta = Me.t1.r_Valor
                ._AutoAgencia = Me.c1.SelectedValue
                ._TipoCta = Me.c2.SelectedItem.ToString
                ._Estatus = IIf(Me.c3.SelectedIndex = 0, DataSistema.MiDataSistema.DataSistema.TipoEstatus.Activo, DataSistema.MiDataSistema.DataSistema.TipoEstatus.Inactivo)
            End With

            If MessageBox.Show("Estas De Acuerdo En Guardar Esta Cuenta Para Este Proveedor ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                xfichacta.F_AgregarCta(xficha)
                MessageBox.Show("Cuenta Bancaria Registrada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Property _AutomaticoPlantillaGestionar() As String Implements IPlantilla_3._AutomaticoPlantillaGestionar
        Get
            Return xautoplantilla_gestionar
        End Get
        Set(ByVal value As String)
            xautoplantilla_gestionar = value
        End Set
    End Property

    Public Function _EliminarRegistro() As Boolean Implements IPlantilla_3._EliminarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCtaBancariaProveedor_Eliminar.F_Permitir()

                If MessageBox.Show("Estas Seguro De Eliminar Esta Cuenta ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    xfichacta.F_EliminaCta(xfichacta.RegistroDato.r_AutomaticoCta)
                    MessageBox.Show("Cuenta Eliminada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Sub _ActualizarRegistro() Implements IPlantilla_3._ActualizarRegistro
        ActualizaVista()
    End Sub

    Public Function _VerificarSiPuedoAgregarRegistro() As Boolean Implements IPlantilla_3._VerificarSiPuedoAgregarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCtaBancariaProveedor_Ingresar.F_Permitir()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _VerificarSiPuedoEliminarRegistro() As Boolean Implements IPlantilla_3._VerificarSiPuedoEliminarRegistro
    End Function

    Public Function _VerificarSiPuedoModificarRegistro() As Boolean Implements IPlantilla_3._VerificarSiPuedoModificarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCtaBancariaProveedor_Modificar.F_Permitir()
                Return True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _ModificarRegistro() As Boolean Implements IPlantilla_3._ModificarRegistro
        Try
            Dim xficha As New c_CtasBancarias.c_ModificarCta
            With xficha
                ._Automatico = xfichacta.RegistroDato.r_AutomaticoCta
                ._ANombreDe = Me.t2.r_Valor
                ._NumertoCta = Me.t1.r_Valor
                ._AutoAgencia = Me.c1.SelectedValue
                ._TipoCta = Me.c2.SelectedItem.ToString
                ._Estatus = IIf(Me.c3.SelectedIndex = 0, DataSistema.MiDataSistema.DataSistema.TipoEstatus.Activo, DataSistema.MiDataSistema.DataSistema.TipoEstatus.Inactivo)
            End With

            If MessageBox.Show("Estas De Acuerdo En Guardar Esta Cuenta Para Este Proveedor ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                xfichacta.F_ModificarCta(xficha)
                MessageBox.Show("Cuenta Bancaria Registrada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class