Imports DataSistema.MiDataSistema.DataSistema

Public Class Plantilla_11
    Event ActualizarFicha()

    Dim pb_tm As Size
    Dim xf_accion As TipoAccionFicha
    Dim xplantilla As IPlantilla_11

    Sub ApagarControles()
        Me.PB_1.Enabled = False
        Me.PB_2.Enabled = False
        Me.PB_3.Enabled = False
        Me.MisGrid1.Enabled = False
    End Sub

    Sub EncenderControles()
        Me.MT_1.Enabled = False
        Me.MT_2.Enabled = False
        Me.MCHB_1.Enabled = False
        Me.N_1.Enabled = False
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
                Me.BT_GRABAR.Enabled = True
                ApagarControles()
            End If

            If value = TipoAccionFicha.Modificar Then
                Me.BT_GRABAR.Enabled = True
                ApagarControles()
            End If
        End Set
    End Property

    Property _MiPlantilla() As IPlantilla_11
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantilla_11)
            xplantilla = value
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

    Private Sub Plantilla_11_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FichaAccion = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If _FichaAccion = TipoAccionFicha.Adicionar Or _FichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Estas Seguro De Peder Los cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                    Me._FichaAccion = TipoAccionFicha.Consultar
                    _MiPlantilla._RefrescarData()
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub Plantilla_11_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Sub New(ByVal xplantilla As IPlantilla_11)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._MiPlantilla = xplantilla
    End Sub

    Sub Inicializa()
        Try
            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With

            Me._FichaAccion = TipoAccionFicha.Consultar
            pb_tm = PB_1.Size
            _MiPlantilla._Inicializa(Me)
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
        If Me._MiPlantilla._AgregarRegistro Then
            Me._FichaAccion = TipoAccionFicha.Adicionar
        End If
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        Grabar()
    End Sub

    Sub Grabar()
        If _FichaAccion = TipoAccionFicha.Adicionar Then
            If Me._MiPlantilla._GrabarNuevoRegistro Then
                RaiseEvent ActualizarFicha()
                Me._FichaAccion = TipoAccionFicha.Consultar
            End If
        Else
            If Me._MiPlantilla._GrabarModificacionRegistro Then
                RaiseEvent ActualizarFicha()
                Me._FichaAccion = TipoAccionFicha.Consultar
            End If
        End If
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarRegistro()
    End Sub

    Sub ModificarRegistro()
        If Me._MiPlantilla._ModificarRegistro Then
            Me._FichaAccion = TipoAccionFicha.Modificar
        End If
    End Sub

    Private Sub Plantilla_11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub N_1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles N_1.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.FindForm.SelectNextControl(Me, True, True, True, True)
        End If
    End Sub
End Class

Public Interface IPlantilla_11
    Sub _Inicializa(ByVal formulario As Object)
    Function _AgregarRegistro() As Boolean
    Function _ModificarRegistro() As Boolean
    Function _GrabarNuevoRegistro() As Boolean
    Function _GrabarModificacionRegistro() As Boolean
    Function _EliminarRegistro() As Boolean
    Sub _RefrescarData()
End Interface

Public Class Depositos
    Implements IPlantilla_11

    Dim xform As System.Windows.Forms.Form
    Dim MG As MisControles.Controles.MisGrid
    Dim MT1 As MisControles.Controles.MisTextos
    Dim MT2 As MisControles.Controles.MisTextos
    Dim MCHB1 As MisControles.Controles.MisCheckBox
    Dim N1 As System.Windows.Forms.NumericUpDown
    Dim E3 As System.Windows.Forms.Label
    Dim E0 As System.Windows.Forms.Label
    Dim ET As System.Windows.Forms.Label
    Dim xficha As FichaGlobal.c_Depositos

    Dim xtb As DataTable
    Dim xbs As BindingSource

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaGlobal.c_Depositos
        AddHandler xficha.Actualizar, AddressOf CargarData
    End Sub

    Public Sub _Inicializa(ByVal formulario As Object) Implements IPlantilla_11._Inicializa
        Try
            _MiFormulario = CType(formulario, System.Windows.Forms.Form)
            _MiFormulario.Text = "Productos"

            ET = _MiFormulario.Controls.Find("E_TITULO", True)(0)
            MG = _MiFormulario.Controls.Find("MisGrid1", True)(0)
            MT1 = _MiFormulario.Controls.Find("MT_1", True)(0)
            MT2 = _MiFormulario.Controls.Find("MT_2", True)(0)
            MCHB1 = _MiFormulario.Controls.Find("MCHB_1", True)(0)
            N1 = _MiFormulario.Controls.Find("N_1", True)(0)
            E3 = _MiFormulario.Controls.Find("E_3", True)(0)
            E0 = _MiFormulario.Controls.Find("E_0", True)(0)

            ET.Text = "Depositos A Manejar"
            With Me.MT1
                .MaxLength = xficha.RegistroDato.c_Codigo.c_Largo
                .Text = ""
            End With
            With Me.MT2
                .MaxLength = xficha.RegistroDato.c_Nombre.c_Largo
                .Text = ""
            End With
            With Me.E0
                .Text = "0"
            End With

            With MCHB1
                .Visible = True
            End With
            With MCHB1
                .Visible = False
            End With
            With N1
                .Visible = False
            End With
            With E3
                .Visible = False
            End With

            xtb = New DataTable
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            CargarData()

            With MG
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from depositos order by nombre", xtb)
        Actualiza()
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xficha.M_Cargardata(CType(xbs.Current, System.Data.DataRowView).Row)
            Me.E0.Text = Me.xbs.Count.ToString
        Else
            xficha.RegistroDato.M_LimpiarRegistro()
            Me.E0.Text = "0"
        End If

        Me.MT1.Text = xficha.RegistroDato._Codigo
        Me.MT2.Text = xficha.RegistroDato._Nombre
    End Sub

    Public Function _AgregarRegistro() As Boolean Implements IPlantilla_11._AgregarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Deposito_Ingresar.F_Permitir()
            With Me.MT1
                .Enabled = True
                .Text = ""
            End With
            With Me.MT2
                .Enabled = True
                .Text = ""
            End With
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _GrabarNuevoRegistro() As Boolean Implements IPlantilla_11._GrabarNuevoRegistro
        If Me.MT1.r_Valor <> "" Then
            If Me.MT2.r_Valor <> "" Then
                If MessageBox.Show("Estas De Acuerdo En Grabar Este Nuevo Deposito ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim dep As New FichaGlobal.c_Depositos.c_AgregarDeposito
                        With dep
                            ._CodigoDeposito = Me.MT1.r_Valor
                            ._NombreDeposito = Me.MT2.r_Valor
                        End With
                        xficha.F_AgregarRegistro(dep)
                        MessageBox.Show("Deposito Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    Catch ex As Exception
                        Me.MT1.Select()
                        Me.MT1.Focus()
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    Me.MT1.Select()
                    Me.MT1.Focus()
                End If
            Else
                MessageBox.Show("Error... Campo Nombre Del Deposito No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MT2.Select()
                Me.MT2.Focus()
            End If
        Else
            MessageBox.Show("Error... Campo Codigo Del Deposito No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT1.Select()
            Me.MT1.Focus()
        End If
    End Function

    Public Sub _RefrescarData() Implements IPlantilla_11._RefrescarData
        Actualiza()
    End Sub

    Public Function _EliminarRegistro() As Boolean Implements IPlantilla_11._EliminarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Deposito_Eliminar.F_Permitir()

                If MessageBox.Show("Estas Seguro De Eliminar Dicho Deposito ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    xficha.F_EliminarRegistro(xficha.RegistroDato._Automatico)
                    MessageBox.Show("Deposito Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _ModificarRegistro() As Boolean Implements IPlantilla_11._ModificarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Deposito_Modificar.F_Permitir()
            With Me.MT1
                .Enabled = True
            End With
            With Me.MT2
                .Enabled = True
            End With
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _GrabarModificacionRegistro() As Boolean Implements IPlantilla_11._GrabarModificacionRegistro
        If Me.MT1.r_Valor <> "" Then
            If Me.MT2.r_Valor <> "" Then
                If MessageBox.Show("Estas De Acuerdo En Grabar Estos Cambios Para Este Deposito ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim dep As New FichaGlobal.c_Depositos.c_ModificarDeposito
                        With dep
                            ._CodigoDeposito = Me.MT1.r_Valor
                            ._NombreDeposito = Me.MT2.r_Valor
                            ._AutoDeposito = xficha.RegistroDato._Automatico
                            ._IdSeguridad = xficha.RegistroDato._IdSeguridad
                        End With
                        xficha.F_ModificaRegistro(dep)
                        MessageBox.Show("Deposito Modificado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    Catch ex As Exception
                        Me.MT1.Select()
                        Me.MT1.Focus()
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    Me.MT1.Select()
                    Me.MT1.Focus()
                End If
            Else
                MessageBox.Show("Error... Campo Nombre Del Deposito No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MT2.Select()
                Me.MT2.Focus()
            End If
        Else
            MessageBox.Show("Error... Campo Codigo Del Deposito No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT1.Select()
            Me.MT1.Focus()
        End If
    End Function
End Class

Public Class ProductosConcepto
    Implements IPlantilla_11

    Dim xform As System.Windows.Forms.Form
    Dim MG As MisControles.Controles.MisGrid
    Dim MT1 As MisControles.Controles.MisTextos
    Dim MT2 As MisControles.Controles.MisTextos
    Dim MCHB1 As MisControles.Controles.MisCheckBox
    Dim N1 As System.Windows.Forms.NumericUpDown
    Dim E3 As System.Windows.Forms.Label
    Dim E0 As System.Windows.Forms.Label
    Dim ET As System.Windows.Forms.Label
    Dim xficha As FichaProducto.Prd_Concepto

    Dim xtb As DataTable
    Dim xbs As BindingSource

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaProducto.Prd_Concepto
        AddHandler xficha.Actualizar, AddressOf CargarData
    End Sub

    Public Sub _Inicializa(ByVal formulario As Object) Implements IPlantilla_11._Inicializa
        Try
            _MiFormulario = CType(formulario, System.Windows.Forms.Form)
            _MiFormulario.Text = "Productos"

            ET = _MiFormulario.Controls.Find("E_TITULO", True)(0)
            MG = _MiFormulario.Controls.Find("MisGrid1", True)(0)
            MT1 = _MiFormulario.Controls.Find("MT_1", True)(0)
            MT2 = _MiFormulario.Controls.Find("MT_2", True)(0)
            MCHB1 = _MiFormulario.Controls.Find("MCHB_1", True)(0)
            N1 = _MiFormulario.Controls.Find("N_1", True)(0)
            E3 = _MiFormulario.Controls.Find("E_3", True)(0)
            E0 = _MiFormulario.Controls.Find("E_0", True)(0)

            ET.Text = "Conceptos A Manejar"
            With Me.MT1
                .MaxLength = xficha.RegistroDato.c_CodigoConcepto.c_Largo
                .Text = ""
            End With
            With Me.MT2
                .MaxLength = xficha.RegistroDato.c_NombreConcepto.c_Largo
                .Text = ""
            End With
            With Me.E0
                .Text = "0"
            End With

            With MCHB1
                .Visible = True
            End With
            With MCHB1
                .Visible = False
            End With
            With N1
                .Visible = False
            End With
            With E3
                .Visible = False
            End With

            xtb = New DataTable
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            CargarData()

            With MG
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from productos_conceptos order by nombre", xtb)
        Actualiza()
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xficha.M_Cargardata(CType(xbs.Current, System.Data.DataRowView).Row)
            Me.E0.Text = Me.xbs.Count.ToString
        Else
            xficha.RegistroDato.M_LimpiarRegistro()
            Me.E0.Text = "0"
        End If

        Me.MT1.Text = xficha.RegistroDato._CodigoConcepto
        Me.MT2.Text = xficha.RegistroDato._NombreConcepto
    End Sub

    Public Function _AgregarRegistro() As Boolean Implements IPlantilla_11._AgregarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Concepto_Ingresar.F_Permitir()
            With Me.MT1
                .Enabled = True
                .Text = ""
            End With
            With Me.MT2
                .Enabled = True
                .Text = ""
            End With
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _GrabarNuevoRegistro() As Boolean Implements IPlantilla_11._GrabarNuevoRegistro
        If Me.MT1.r_Valor <> "" Then
            If Me.MT2.r_Valor <> "" Then
                If MessageBox.Show("Estas De Acuerdo En Grabar Este Nuevo Concepto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim dep As New FichaProducto.Prd_Concepto.c_AgregarConcepto
                        With dep
                            ._CodigoConcepto = Me.MT1.r_Valor
                            ._NombreConcepto = Me.MT2.r_Valor
                        End With
                        xficha.F_AgregarRegistro(dep)
                        MessageBox.Show("Concepto Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    Catch ex As Exception
                        Me.MT1.Select()
                        Me.MT1.Focus()
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    Me.MT1.Select()
                    Me.MT1.Focus()
                End If
            Else
                MessageBox.Show("Error... Campo Nombre Del Concepto No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MT2.Select()
                Me.MT2.Focus()
            End If
        Else
            MessageBox.Show("Error... Campo Codigo Del Concepto No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT1.Select()
            Me.MT1.Focus()
        End If
    End Function

    Public Sub _RefrescarData() Implements IPlantilla_11._RefrescarData
        Actualiza()
    End Sub

    Public Function _EliminarRegistro() As Boolean Implements IPlantilla_11._EliminarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Concepto_Eliminar.F_Permitir()

                If MessageBox.Show("Estas Seguro De Eliminar Dicho Concepto ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    xficha.F_EliminarRegistro(xficha.RegistroDato._Automatico)
                    MessageBox.Show("Concepto Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _ModificarRegistro() As Boolean Implements IPlantilla_11._ModificarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Concepto_Modificar.F_Permitir()
            With Me.MT1
                .Enabled = True
            End With
            With Me.MT2
                .Enabled = True
            End With
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _GrabarModificacionRegistro() As Boolean Implements IPlantilla_11._GrabarModificacionRegistro
        If Me.MT1.r_Valor <> "" Then
            If Me.MT2.r_Valor <> "" Then
                If MessageBox.Show("Estas De Acuerdo En Grabar Estos Cambios Para Este Concepto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim dep As New FichaProducto.Prd_Concepto.c_ModificarConcepto
                        With dep
                            ._CodigoConcepto = Me.MT1.r_Valor
                            ._NombreConcepto = Me.MT2.r_Valor
                            ._AutoConcepto = xficha.RegistroDato._Automatico
                            ._IdSeguridad = xficha.RegistroDato._IdSeguridad
                        End With
                        xficha.F_ModificaRegistro(dep)
                        MessageBox.Show("Concepto Modificado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    Catch ex As Exception
                        Me.MT1.Select()
                        Me.MT1.Focus()
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    Me.MT1.Select()
                    Me.MT1.Focus()
                End If
            Else
                MessageBox.Show("Error... Campo Nombre Del Concepto No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MT2.Select()
                Me.MT2.Focus()
            End If
        Else
            MessageBox.Show("Error... Campo Codigo Del Concepto No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT1.Select()
            Me.MT1.Focus()
        End If
    End Function
End Class

Public Class ProductosMedida
    Implements IPlantilla_11

    Dim xform As System.Windows.Forms.Form
    Dim MG As MisControles.Controles.MisGrid
    Dim MT1 As MisControles.Controles.MisTextos
    Dim MT2 As MisControles.Controles.MisTextos
    Dim MCHB1 As MisControles.Controles.MisCheckBox
    Dim N1 As System.Windows.Forms.NumericUpDown
    Dim E3 As System.Windows.Forms.Label
    Dim E0 As System.Windows.Forms.Label
    Dim E1 As System.Windows.Forms.Label
    Dim ET As System.Windows.Forms.Label
    Dim xficha As FichaProducto.Prd_Medida

    Dim xtb As DataTable
    Dim xbs As BindingSource

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaProducto.Prd_Medida
        AddHandler xficha.Actualizar, AddressOf CargarData
    End Sub

    Public Sub _Inicializa(ByVal formulario As Object) Implements IPlantilla_11._Inicializa
        Try
            _MiFormulario = CType(formulario, System.Windows.Forms.Form)
            _MiFormulario.Text = "Productos"

            ET = _MiFormulario.Controls.Find("E_TITULO", True)(0)
            MG = _MiFormulario.Controls.Find("MisGrid1", True)(0)
            MT2 = _MiFormulario.Controls.Find("MT_2", True)(0)
            MT1 = _MiFormulario.Controls.Find("MT_1", True)(0)
            MCHB1 = _MiFormulario.Controls.Find("MCHB_1", True)(0)
            N1 = _MiFormulario.Controls.Find("N_1", True)(0)
            E3 = _MiFormulario.Controls.Find("E_3", True)(0)
            E0 = _MiFormulario.Controls.Find("E_0", True)(0)
            E1 = _MiFormulario.Controls.Find("E_1", True)(0)

            E1.Visible = False
            MT1._EsconderControl = True

            ET.Text = "Empaques/Medidas A Manejar"
            With Me.MT2
                .MaxLength = xficha.RegistroDato.c_Nombre.c_Largo
                .Text = ""
            End With
            With Me.E0
                .Text = "0"
            End With

            With MCHB1
                .Visible = True
            End With
            With N1
                .Visible = True
            End With
            With E3
                .Visible = True
            End With

            xtb = New DataTable
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            CargarData()

            With MG
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Ocultar(2)
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from productos_medida order by nombre", xtb)
        Actualiza()
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xficha.M_Cargardata(CType(xbs.Current, System.Data.DataRowView).Row)
            Me.E0.Text = Me.xbs.Count.ToString
        Else
            xficha.RegistroDato.M_LimpiarRegistro()
            Me.E0.Text = "0"
        End If
        Me.MT2.Text = xficha.RegistroDato._NombreMedida
        Me.N1.Value = xficha.RegistroDato._DigitosDecimalesAUsar
        Me.MCHB1.Checked = xficha.RegistroDato._ForzarDecimales
    End Sub

    Public Function _AgregarRegistro() As Boolean Implements IPlantilla_11._AgregarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Medida_Ingresar.F_Permitir()
            With Me.MT2
                .Enabled = True
                .Text = ""
            End With
            With Me.N1
                .Minimum = 0
                .Maximum = 3
                .Enabled = True
            End With
            With Me.MCHB1
                .Enabled = True
            End With
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _GrabarNuevoRegistro() As Boolean Implements IPlantilla_11._GrabarNuevoRegistro
        If Me.MT2.r_Valor <> "" Then
            If MessageBox.Show("Estas De Acuerdo En Grabar Este Nuevo Empaque/Medida ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim dep As New FichaProducto.Prd_Medida.c_AgregarMedida
                    With dep
                        ._NombreEmpaque = Me.MT2.r_Valor
                        ._ForzarEmpaque = IIf(Me.MCHB1.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                        ._NumeroDecimales = Me.N1.Value
                    End With
                    xficha.F_AgregarRegistro(dep)
                    MessageBox.Show("Empaque/Medida Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    Me.MT2.Select()
                    Me.MT2.Focus()
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                Me.MT2.Select()
                Me.MT2.Focus()
            End If
        Else
            MessageBox.Show("Error... Campo Nombre Del Concepto No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT2.Select()
            Me.MT2.Focus()
        End If
    End Function

    Public Sub _RefrescarData() Implements IPlantilla_11._RefrescarData
        Actualiza()
    End Sub

    Public Function _EliminarRegistro() As Boolean Implements IPlantilla_11._EliminarRegistro
        If xbs.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Medida_Eliminar.F_Permitir()

                If MessageBox.Show("Estas Seguro De Eliminar Dicho Empaque/Medida ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    xficha.F_EliminarRegistro(xficha.RegistroDato._Automatico)
                    MessageBox.Show("Medida/Empaque Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _ModificarRegistro() As Boolean Implements IPlantilla_11._ModificarRegistro
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Medida_Modificar.F_Permitir()
            Me.MT2.Enabled = True
            Me.MCHB1.Enabled = True
            Me.N1.Enabled = True
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function _GrabarModificacionRegistro() As Boolean Implements IPlantilla_11._GrabarModificacionRegistro
        If Me.MT2.r_Valor <> "" Then
            If MessageBox.Show("Estas De Acuerdo En Grabar Estos Cambios Para Este Empaque/Medida ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim dep As New FichaProducto.Prd_Medida.c_ModificarMedida
                    With dep
                        ._NombreEmpaque = Me.MT2.r_Valor
                        ._ForzarEmpaque = IIf(Me.MCHB1.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                        ._IdSeguridad = xficha.RegistroDato._IdSeguridad
                        ._NumeroDecimales = Me.N1.Value
                        ._AutoEmpaque = xficha.RegistroDato._Automatico
                    End With
                    xficha.F_ModificaRegistro(dep)
                    MessageBox.Show("Medida/Empaque Modificado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Catch ex As Exception
                    Me.MT2.Select()
                    Me.MT2.Focus()
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                Me.MT2.Select()
                Me.MT2.Focus()
            End If
        Else
            MessageBox.Show("Error... Campo Nombre Del Empaque/Medida No Puede Estar Vacio", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT2.Select()
            Me.MT2.Focus()
        End If
    End Function
End Class