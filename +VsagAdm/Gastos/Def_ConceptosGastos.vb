Imports DataSistema.MiDataSistema.DataSistema

Public Class Def_ConceptosGastos
    Dim pb_tm As Size
    Dim xficha As IFichaGastos

    Property _Ficha() As IFichaGastos
        Get
            Return xficha
        End Get
        Set(ByVal value As IFichaGastos)
            xficha = value
        End Set
    End Property

    Private Sub PB_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseEnter, PB_2.MouseEnter, PB_3.MouseEnter, PB_4.MouseEnter
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseHover, PB_2.MouseHover, PB_3.MouseHover, PB_4.MouseHover
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseLeave, PB_2.MouseLeave, PB_3.MouseLeave, PB_4.MouseLeave
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

    Private Sub Def_ConceptosGastos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Def_ConceptosGastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_tm = PB_1.Size
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub Def_ConceptosGastos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            _Ficha.Inicializa(Me)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub New(ByVal xtipo_ficha As IFichaGastos)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Ficha = xtipo_ficha
    End Sub
End Class

Public Interface IFichaGastos
    Sub Inicializa(ByVal xform As Object)
End Interface

Public Class GastosConceptos
    Implements IFichaGastos
    Event _ActualizarFicha()

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents T_1 As Label
    WithEvents L_1 As Label
    WithEvents L_2 As Label
    WithEvents L_3 As Label
    WithEvents I_1 As PictureBox
    WithEvents MG_1 As MisControles.Controles.MisGrid
    WithEvents PB_1 As PictureBox
    WithEvents PB_2 As PictureBox
    WithEvents PB_3 As PictureBox
    WithEvents PB_4 As PictureBox

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xconcepto As ControlGastos.Conceptos

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xconcepto = New ControlGastos.Conceptos
        AddHandler xbs.PositionChanged, AddressOf ActualizarData
    End Sub

    Public Sub Inicializa(ByVal xform As Object) Implements IFichaGastos.Inicializa
        Try
            _Form = CType(xform, System.Windows.Forms.Form)
            T_1 = _Form.Controls.Find("T_1", True)(0)
            L_1 = _Form.Controls.Find("L_1", True)(0)
            L_2 = _Form.Controls.Find("L_2", True)(0)
            L_3 = _Form.Controls.Find("L_3", True)(0)
            I_1 = _Form.Controls.Find("I_1", True)(0)
            PB_1 = _Form.Controls.Find("PB_1", True)(0)
            PB_2 = _Form.Controls.Find("PB_2", True)(0)
            PB_3 = _Form.Controls.Find("PB_3", True)(0)
            PB_4 = _Form.Controls.Find("PB_4", True)(0)
            MG_1 = _Form.Controls.Find("MG_1", True)(0)

            _Form.Text = "Conceptos"
            Me.T_1.Text = "Conceptos Para Control De Gastos"
            PB_4.Visible = False
            InicializaData()
            Actualiza()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            Try
                xconcepto.F_BuscarCargar(xbs.Current("auto").ToString)

                Me.L_1.Text = xconcepto.RegistroDato._NombreConcepto
                If xconcepto.RegistroDato._Estatus = TipoEstatus.Activo Then
                    Me.I_1.Image = My.Resources.notification_done
                    Me.L_3.Text = "ACTIVO"
                Else
                    Me.I_1.Image = My.Resources.notification_error
                    Me.L_3.Text = "INACTIVO"
                End If
            Catch ex As Exception
                Funciones.MensajeDeAlerta(ex.Message)
            End Try
        Else
            Limpiar()
        End If
    End Sub

    Sub Limpiar()
        Me.L_1.Text = ""
        Me.L_2.Text = "0"
        Me.L_3.Text = ""
        Me.I_1.Image = My.Resources.notification_warning
    End Sub

    Sub InicializaData()
        Try
            Limpiar()
            ActualizarTabla()
            With Me.MG_1
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

    Private Sub PB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.Click, PB_2.Click, PB_3.Click, PB_4.Click
        Dim xpb As PictureBox = CType(sender, PictureBox)
        Select Case xpb.Name
            Case "PB_1" : Agregar()
            Case "PB_2" : Modificar()
            Case "PB_3" : Eliminar()
        End Select
    End Sub

    Sub Agregar()
        Dim xclas As New AgregarConceptoGasto
        AddHandler xclas._Actualizar, AddressOf AgregarOk

        Dim xficha As New AgregarConcepto(xclas)
        With xficha
            .ShowDialog()
        End With
    End Sub

    Sub AgregarOk()
        RaiseEvent _ActualizarFicha()
        ActualizarTabla()
    End Sub

    Sub Modificar()
        If xbs.Current IsNot Nothing Then
            Dim xclas As New ModificarConceptoGasto(xconcepto)
            AddHandler xclas._Actualizar, AddressOf AgregarOk

            Dim xficha As New AgregarConcepto(xclas)
            With xficha
                .ShowDialog()
            End With
        End If
    End Sub

    Sub Eliminar()
        If xbs.Current IsNot Nothing Then
            If MessageBox.Show("Estas Seguro De Eliminar Este Concepto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xgasto As New ControlGastos
                    AddHandler xgasto._ConceptoEliminadoOk, AddressOf ConceptoEliminado
                    xgasto.F_EliminarConcepto(xbs.Current("AUTO"))
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        End If
    End Sub

    Sub ConceptoEliminado()
        RaiseEvent _ActualizarFicha()
        ActualizarTabla()
        Funciones.MensajeDeOk("Concepto Eliminado Exitosamente...")
    End Sub

    Sub ActualizarTabla()
        Try
            g_MiData.F_GetData("select nombre nom, auto from GASTOS_CONCEPTOS with (readpast) order by nombre", xtb)
            Me.L_2.Text = xtb.Rows.Count.ToString.Trim
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub _Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _Form.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            Agregar()
        End If
        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            Modificar()
        End If
        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            Eliminar()
        End If
    End Sub
End Class

Public Class GastosSubConceptos
    Implements IFichaGastos
    Event _ActualizarFicha()

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents T_1 As Label
    WithEvents L_1 As Label
    WithEvents L_2 As Label
    WithEvents L_3 As Label
    WithEvents I_1 As PictureBox
    WithEvents MG_1 As MisControles.Controles.MisGrid
    WithEvents PB_1 As PictureBox
    WithEvents PB_2 As PictureBox
    WithEvents PB_3 As PictureBox
    WithEvents PB_4 As PictureBox

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xsubconcepto As ControlGastos.SubConceptos

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xsubconcepto = New ControlGastos.SubConceptos
        AddHandler xbs.PositionChanged, AddressOf ActualizarData
    End Sub

    Public Sub Inicializa(ByVal xform As Object) Implements IFichaGastos.Inicializa
        Try
            _Form = CType(xform, System.Windows.Forms.Form)
            T_1 = _Form.Controls.Find("T_1", True)(0)
            L_1 = _Form.Controls.Find("L_1", True)(0)
            L_2 = _Form.Controls.Find("L_2", True)(0)
            L_3 = _Form.Controls.Find("L_3", True)(0)
            I_1 = _Form.Controls.Find("I_1", True)(0)
            PB_1 = _Form.Controls.Find("PB_1", True)(0)
            PB_2 = _Form.Controls.Find("PB_2", True)(0)
            PB_3 = _Form.Controls.Find("PB_3", True)(0)
            PB_4 = _Form.Controls.Find("PB_4", True)(0)
            MG_1 = _Form.Controls.Find("MG_1", True)(0)

            Me.T_1.Text = "SubConceptos Para Control De Gastos"
            _Form.Text = "SubConceptos"
            PB_4.Visible = False
            InicializaData()
            Actualiza()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            Try
                xsubconcepto.F_BuscarCargar(xbs.Current("auto").ToString)

                Me.L_1.Text = xsubconcepto.RegistroDato._NombreConcepto
                If xsubconcepto.RegistroDato._Estatus = TipoEstatus.Activo Then
                    Me.I_1.Image = My.Resources.notification_done
                    Me.L_3.Text = "ACTIVO"
                Else
                    Me.I_1.Image = My.Resources.notification_error
                    Me.L_3.Text = "INACTIVO"
                End If
            Catch ex As Exception
                Funciones.MensajeDeAlerta(ex.Message)
            End Try
        Else
            Limpiar()
        End If
    End Sub

    Sub Limpiar()
        Me.L_1.Text = ""
        Me.L_2.Text = "0"
        Me.L_3.Text = ""
        Me.I_1.Image = My.Resources.notification_warning
    End Sub

    Sub InicializaData()
        Try
            Limpiar()
            ActualizarTabla()
            With Me.MG_1
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

    Private Sub PB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.Click, PB_2.Click, PB_3.Click, PB_4.Click
        Dim xpb As PictureBox = CType(sender, PictureBox)
        Select Case xpb.Name
            Case "PB_1" : Agregar()
            Case "PB_2" : Modificar()
            Case "PB_3" : Eliminar()
        End Select
    End Sub

    Sub Agregar()
        Dim xclas As New AgregarSubConceptoGasto
        AddHandler xclas._Actualizar, AddressOf AgregarOk

        Dim xficha As New AgregarConcepto(xclas)
        With xficha
            .ShowDialog()
        End With
    End Sub

    Sub AgregarOk()
        RaiseEvent _ActualizarFicha()
        ActualizarTabla()
    End Sub

    Sub Modificar()
        If xbs.Current IsNot Nothing Then
            Dim xclas As New ModificarSubConceptoGasto(xsubconcepto)
            AddHandler xclas._Actualizar, AddressOf AgregarOk

            Dim xficha As New AgregarConcepto(xclas)
            With xficha
                .ShowDialog()
            End With
        End If
    End Sub

    Sub Eliminar()
        If xbs.Current IsNot Nothing Then
            If MessageBox.Show("Estas Seguro De Eliminar Este SubConcepto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xgasto As New ControlGastos
                    AddHandler xgasto._ConceptoEliminadoOk, AddressOf ConceptoEliminado
                    xgasto.F_EliminarSubConcepto(xbs.Current("AUTO"))
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        End If
    End Sub

    Sub ConceptoEliminado()
        RaiseEvent _ActualizarFicha()
        ActualizarTabla()
        Funciones.MensajeDeOk("SubConcepto Eliminado Exitosamente...")
    End Sub

    Sub ActualizarTabla()
        Try
            g_MiData.F_GetData("select nombre nom, auto from GASTOS_subCONCEPTOS with (readpast) order by nombre", xtb)
            Me.L_2.Text = xtb.Rows.Count.ToString.Trim
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub _Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _Form.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            Agregar()
        End If
        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            Modificar()
        End If
        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            Eliminar()
        End If
    End Sub
End Class