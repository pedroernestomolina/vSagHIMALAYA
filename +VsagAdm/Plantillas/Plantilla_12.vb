Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema

Public Class Plantilla_12
    Dim xplant As IPlantilla_12
    Dim pb_tm As Size

    Property _MiPlantilla() As IPlantilla_12
        Get
            Return xplant
        End Get
        Set(ByVal value As IPlantilla_12)
            xplant = value
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

    Private Sub Plantilla_12_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub DeptoPtoVenta_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        _MiPlantilla.Inicializa(Me)
    End Sub

    Sub New(ByVal xplant As IPlantilla_12)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _MiPlantilla = xplant
        pb_tm = PB_1.Size
    End Sub
End Class

Public Interface IPlantilla_12
    Sub Inicializa(ByVal xobj As Object)
End Interface

Public Class MediosPago
    Implements IPlantilla_12

    Dim xf_accion As TipoAccionFicha
    Dim xficha As FichaGlobal.c_MediosPagos
    Dim xestatus As String() = {"Activo", "Inactivo"}

    Dim xtb As DataTable
    Dim xbs As BindingSource

    WithEvents xform As System.Windows.Forms.Form
    WithEvents misgrid1 As MisGrid
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents MT_1 As MisTextos
    WithEvents MT_2 As MisTextos
    WithEvents MCB_1 As MisComboBox
    WithEvents PB_1 As PictureBox
    WithEvents PB_2 As PictureBox
    WithEvents PB_3 As PictureBox
    WithEvents BT_1 As Button

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Sub ApagarEncenderControles(ByVal xestatus As Boolean)
        Me.PB_1.Enabled = xestatus
        Me.PB_2.Enabled = xestatus
        Me.PB_3.Enabled = xestatus
        Me.MisGrid1.Enabled = xestatus

        Me.BT_1.Enabled = Not xestatus
        Me.MT_1.Enabled = Not xestatus
        Me.MT_2.Enabled = Not xestatus
        Me.MCB_1.Enabled = Not xestatus
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
                Me.MT_1.Text = ""
                Me.MT_2.Text = ""
                Me.MCB_1.SelectedIndex = 0
                ApagarEncenderControles(False)
                Me.MT_1.Select()
                Me.MT_1.Focus()
            End If

            If value = TipoAccionFicha.Modificar Then
                ApagarEncenderControles(False)
                Me.MT_1.Select()
                Me.MT_1.Focus()
            End If
        End Set
    End Property

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If MisGrid1.Rows(e.RowIndex).Cells("estatus").Value.ToString.Trim.ToUpper <> "ACTIVO" Then
            MisGrid1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_12.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            misgrid1 = _MiFormulario.Controls.Find("MisGrid1", True)(0)
            PB_1 = _MiFormulario.Controls.Find("PB_1", True)(0)
            PB_2 = _MiFormulario.Controls.Find("PB_2", True)(0)
            PB_3 = _MiFormulario.Controls.Find("PB_3", True)(0)
            BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
            MT_1 = _MiFormulario.Controls.Find("MT_1", True)(0)
            MT_2 = _MiFormulario.Controls.Find("MT_2", True)(0)
            MCB_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)

            lb_1.Text = "Control Medios De Pagos"
            lb_2.Text = "0"
            _MiFormulario.Text = "Medios Pagos"

            With Me.MT_1
                .Text = ""
                .MaxLength = xficha.RegistroDato.c_NombrePago.c_Largo
            End With
            With Me.MT_2
                .Text = ""
                .MaxLength = xficha.RegistroDato.c_CodigoPago.c_Largo
            End With
            With Me.MCB_1
                .DataSource = xestatus
                .SelectedIndex = 0
            End With

            CargarData()
            AddHandler xficha._ACTUALIZAR, AddressOf CargarData
            AddHandler xbs.PositionChanged, AddressOf ActualizarData

            With misgrid1
                .Columns.Add("col0", "Nombre")
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "xnom"
                .Ocultar(2)

                AddHandler .CellFormatting, AddressOf MiFormato
            End With

            Me._FichaAccion = TipoAccionFicha.Consultar
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre xnom, * from medios_pago order by nombre", xtb)
        Actualiza()
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xficha.M_CargarRegistro(CType(xbs.Current, System.Data.DataRowView).Row)
        Else
            xficha.RegistroDato.LimpiarRegistro()
        End If

        Me.MT_1.Text = xficha.RegistroDato._NombreTipoPago
        Me.MT_2.Text = xficha.RegistroDato._CodigoTipoPago
        If xficha.RegistroDato._EstatusTipoPago Then
            Me.MCB_1.SelectedIndex = 0
        Else
            Me.MCB_1.SelectedIndex = 1
        End If
        Me.lb_2.Text = xbs.Count.ToString
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarRegistro()
    End Sub

    Sub EliminarRegistro()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloMedioPago_Eliminar.F_Permitir()

            If MessageBox.Show("Estas Seguro De Eliminar Dicho Departamento ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                xficha.F_EliminarMedioPago(xficha.RegistroDato._AutoTipoPago, xficha.RegistroDato._IdSeguridad)
                MessageBox.Show("Departamento Eliminado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New FichaGlobal.c_MediosPagos
    End Sub

    Private Sub xform_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles xform.FormClosing
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

    Private Sub xform_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles xform.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            _MiFormulario.Close()
        End If
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarRegistro()
    End Sub

    Sub AgregarRegistro()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloMedioPago_Ingresar.F_Permitir()

            Me._FichaAccion = TipoAccionFicha.Adicionar
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarRegistro()
    End Sub

    Sub ModificarRegistro()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloMedioPago_Modificar.F_Permitir()

            Me._FichaAccion = TipoAccionFicha.Modificar
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub xform_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles xform.KeyDown
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

    Function Validar() As Boolean
        If MT_1.r_Valor = "" Then
            MessageBox.Show("Error... Faltan Datos Por Asignar. Nombre Del Medio De Pago No Puede Estar En Blanco", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_1.Select()
            Me.MT_1.Focus()
            Return False
        End If

        If MT_2.r_Valor = "" Then
            MessageBox.Show("Error... Faltan Datos Por Asignar. Codigo Del Medio De Pago No Puede Estar En Blanco", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_1.Select()
            Me.MT_1.Focus()
            Return False
        End If

        Return True
    End Function

    Sub Grabar()
        If _FichaAccion = TipoAccionFicha.Adicionar Then
            If Validar() Then
                If MessageBox.Show("Estas Seguro De Guardar Este Nuevo Medio De Pago ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim xreg As New FichaGlobal.c_MediosPagos.c_AgregarMedioPago
                        With xreg
                            ._CodigoAsignado = MT_2.r_Valor
                            ._NombreAsignado = MT_1.r_Valor
                            ._Estatus = IIf(Me.MCB_1.SelectedIndex = 0, TipoEstatus.Activo, TipoEstatus.Inactivo)
                        End With
                        xficha.F_AgregarMedioPago(xreg)
                        Me._FichaAccion = TipoAccionFicha.Consultar
                        MessageBox.Show("Medio De Pago Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Actualiza()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        Else
            If Validar() Then
                If MessageBox.Show("Estas Seguro De Modificar Este Departamento ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim xreg As New FichaGlobal.c_MediosPagos.c_ModificarMedioPago
                        With xreg
                            ._CodigoAsignado = MT_2.r_Valor
                            ._NombreAsignado = MT_1.r_Valor
                            ._Estatus = IIf(Me.MCB_1.SelectedIndex = 0, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._idseguridad = xficha.RegistroDato._IdSeguridad
                            ._AutoMedioPago = xficha.RegistroDato._AutoTipoPago
                        End With
                        xficha.F_ModificarMedioPago(xreg)
                        Me._FichaAccion = TipoAccionFicha.Consultar
                        MessageBox.Show("Medio De Pago Agregado Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Actualiza()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Grabar()
    End Sub
End Class