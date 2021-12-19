Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plantilla_ConfiguracionModulo_2
    Dim xplantilla As IPlantilla_ConfiguracionModulo_2

    Property _MiPlantilla() As IPlantilla_ConfiguracionModulo_2
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantilla_ConfiguracionModulo_2)
            xplantilla = value
        End Set
    End Property

    Private Sub Plantilla_ConfiguracionModulo_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_2_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        _MiPlantilla.Inicializa(Me)
    End Sub

    Sub New(ByVal xplant As IPlantilla_ConfiguracionModulo_2)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _MiPlantilla = xplant
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BT_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_1.Click

    End Sub
End Class

Public Interface IPlantilla_ConfiguracionModulo_2
    Sub Inicializa(ByVal xobj As Object)
End Interface

Public Class TipoPrecioManejar
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Precio Mayor", "Precio Detal", "Ambos"}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Modo Trabajo"
            _MiFormulario.Text = "Inventario - Precios"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Mayor"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "Detal"
                Else
                    xvalor = "Ambos"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("INVENT_04", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RupturaPorExistencia
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_01", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ConfirmarEliminarItems
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_02", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class OrdenAlImprimir
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Por Codigo", "Por Nombre", "Natural"}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Codigo"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "Nombre"
                Else
                    xvalor = "Natural"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_05", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RupturaCreditoCliente
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_11", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class FacturarPrecioCero
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_12", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class AbrirDocumentosOtrosUsuarios
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_14", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ActivarDescuentosCargos
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_17", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class FacturarPorDebajoCosto
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_18", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class PermitirPagoAnticipo
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_33", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class PermitirAnticiposPedido
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_34", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ImpresoraFactura
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Texto", "Grafico", "Fiscal "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Texto"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "Grafico"
                Else
                    xvalor = "Fiscal"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_35", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ImpresoraNC
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Texto", "Grafico", "Fiscal "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Texto"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "Grafico"
                Else
                    xvalor = "Fiscal"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_38", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ClienteBuscarPor
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Ci/Rif", "Nombre", "Codigo "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Global"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "CI/RIF"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "NOMBRE"
                Else
                    xvalor = "CODIGO"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_05", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ProveedorBuscarPor
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Ci/Rif", "Nombre", "Codigo "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Global"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "CI/RIF"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "NOMBRE"
                Else
                    xvalor = "CODIGO"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_06", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ProductoBuscarPor
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Codigo", "Nombre", "Codigo Barra", "PLU", "Numero Parte", "Referencia", "Serial"}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Global"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""

                Select Case Me.mc_1.SelectedIndex
                    Case 0 : xvalor = "Codigo"
                    Case 1 : xvalor = "Nombre"
                    Case 2 : xvalor = "Cod/Barra"
                    Case 3 : xvalor = "Plu"
                    Case 4 : xvalor = "Num/Parte"
                    Case 5 : xvalor = "Referencia"
                    Case 6 : xvalor = "Serial"
                End Select

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_04", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class CalculoUtilidad
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"En Base Al Costo", "En Base Al Precio De Venta"}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Global"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Lineal"
                Else
                    xvalor = "Financiero"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_01", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class VendedorBuscarPor
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Ci/Rif", "Nombre", "Codigo "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Global"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "CI/RIF"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "NOMBRE"
                Else
                    xvalor = "CODIGO"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_14", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class CobradorBuscarPor
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Ci/Rif", "Nombre", "Codigo "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Global"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "CI/RIF"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "NOMBRE"
                Else
                    xvalor = "CODIGO"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_15", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class NivelSeguridad
    Implements IPlantilla_ConfiguracionModulo_2
    Event _EnviarOpcion(ByVal xopcion As String)

    WithEvents xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button
    Dim xsalida As Boolean
    Dim xopcion As String

    Dim xtipo As String() = {"Maximo", "Medio", "Minimo", "Ninguna"}
    Dim xid As Byte()

    Sub New()
        xopcion = ""
        _SalidaOk = False
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Property _SalidaOk() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Nivel Seguridad"
            _MiFormulario.Text = "Opciones"

            With Me.mc_1
                .DataSource = xtipo
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Select Case Me.mc_1.SelectedIndex
            Case 0 : xopcion = "Maximo"
            Case 1 : xopcion = "Medio"
            Case 2 : xopcion = "Minimo"
            Case 3 : xopcion = "Ninguna"
        End Select
        _salidaOk = True
        _MiFormulario.Close()
    End Sub

    Private Sub xform_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles xform.FormClosing
        If _SalidaOk Then
            RaiseEvent _EnviarOpcion(xopcion)
        End If
        e.Cancel = False
    End Sub

    Private Sub xform_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles xform.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            _MiFormulario.Close()
        End If
    End Sub
End Class

Public Class ImprimirLineaDetalleImpFiscal
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_41", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ModeloSistemaUsar
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Basico", "Full"}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Basico"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "Administrativo"
                ElseIf Me.mc_1.SelectedIndex = 2 Then
                    xvalor = "Full"
                Else
                    xvalor = "Avanzado"
                End If

                Dim xr As Boolean = False
                Dim xficha As New DataSistema.ClaveSeguridad
                With xficha
                    .ShowDialog()
                    If ._EstatusSalida Then
                        If ._ClaveRetornar = "EEE-ASPE-PEPA-CI" Then
                            xr = True
                        End If
                    End If
                End With

                If xr Then
                    Dim xgl As New FichaGlobal
                    xgl.F_ActualizarOpcionConfiguracion("GLOBAL_09", xvalor, _Id)
                    RaiseEvent _ActualizarOpcion()
                    MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error... Clave Incorrecta", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class MostarTarjetas
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Carga Pedido (Panad)"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class NivelClaveSolicitar
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    WithEvents xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Maximo", "Medio", "Minimo", "Ninguna"}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Carga Pedido (Panad)"

            With Me.mc_1
                .DataSource = xtipo
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                Select Case Me.mc_1.SelectedIndex
                    Case 0 : xvalor = "Maximo"
                    Case 1 : xvalor = "Medio"
                    Case 2 : xvalor = "Minimo"
                    Case 3 : xvalor = "Ninguna"
                End Select

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ActivarPrecio_2
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Inventario"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("INVENT_06", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class FASTFOOD_ABRIR_CUENTASPENDIENTES_OTROS_USUARIOS
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "FASTFOOD (POS)"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class FASTFOOD_VISUALIZAR_REPORTE_CUADRECAJA
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "FASTFOOD (POS)"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class FASTFOOD_CERRAROPERADOR_CON_CTASPENDIENTES
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "FASTFOOD (POS)"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class FASTFOOD_ORDEN_PREFERIDO_BUSCAR_ARTICULO
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Codigo", "Descripcion", "Codigo Barra", "PLU"}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "FASTFOOD (POS)"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                Select Case Me.mc_1.SelectedIndex
                    Case 0 : xvalor = "CODIGO"
                    Case 1 : xvalor = "NOMBRE"
                    Case 2 : xvalor = "COD/BARRA"
                    Case 3 : xvalor = "PLU"
                End Select

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class FASTFOOD_PRECIO_TRABAJAR
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"PRECIO - 1", "PRECIO - 2"}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "FASTFOOD (POS)"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                Select Case Me.mc_1.SelectedIndex
                    Case 0 : xvalor = "PRECIO 1"
                    Case 1 : xvalor = "PRECIO 2"
                End Select

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RESTAURANT_PRECIO_TRABAJAR
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"PRECIO - 1", "PRECIO - 2"}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "RESTAURANT (POS)"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                Select Case Me.mc_1.SelectedIndex
                    Case 0 : xvalor = "PRECIO 1"
                    Case 1 : xvalor = "PRECIO 2"
                End Select

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RESTAURANT_CERRAROPERADOR_CON_CTASPENDIENTES
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Cerrar Operador Con Mesas/Pedidos Pend"
            _MiFormulario.Text = "RESTAURANT (POS)"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RESTAURANT_OFERTAS_PLATOS
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Permitir Precio Oferta En Platos"
            _MiFormulario.Text = "RESTAURANT (POS)"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RESTAURANT_ACTIVAR_DISPOSITIVO_MOVIL
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Si ", "No "}
    Dim xid As Byte()
    Dim xopcion As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _CodigoOpcion() As String
        Get
            Return xopcion
        End Get
        Set(ByVal value As String)
            xopcion = value
        End Set
    End Property

    Sub New(ByVal id As Byte(), ByVal xcod_opcion As String)
        Me._Id = id
        Me._CodigoOpcion = xcod_opcion
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Activar Dispositivo Movil"
            _MiFormulario.Text = "RESTAURANT (POS)"

            With Me.mc_1
                .DataSource = xtipo
            End With

        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Si"
                Else
                    xvalor = "No"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(Me._CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                Funciones.MensajeDeOk("Opcion Actualizada Exitosamente...")
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class


Public Class ImpresoraPresup
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Texto", "Grafico"}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Texto"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "Grafico"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_43", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()

                Funciones.MensajeDeOk("Opcion Actualizada Exitosamente...")
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class ImpresoraNotaE
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Texto", "Grafico"}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Texto"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "Grafico"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_44", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()

                Funciones.MensajeDeOk("Opcion Actualizada Exitosamente...")
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class ImpresoraPedido
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Texto", "Grafico"}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Texto"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "Grafico"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_45", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()

                Funciones.MensajeDeOk("Opcion Actualizada Exitosamente...")
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class ImpresoraOtros
    Implements IPlantilla_ConfiguracionModulo_2
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents mc_1 As MisComboBox
    WithEvents bT_1 As Button

    Dim xtipo As String() = {"Texto", "Grafico"}
    Dim xid As Byte()

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Sub New(ByVal id As Byte())
        _Id = id
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_2.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            mc_1 = _MiFormulario.Controls.Find("MCB_1", True)(0)
            bt_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            With Me.mc_1
                .DataSource = xtipo
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As String = ""
                If Me.mc_1.SelectedIndex = 0 Then
                    xvalor = "Texto"
                ElseIf Me.mc_1.SelectedIndex = 1 Then
                    xvalor = "Grafico"
                End If

                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_46", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()

                Funciones.MensajeDeOk("Opcion Actualizada Exitosamente...")
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class