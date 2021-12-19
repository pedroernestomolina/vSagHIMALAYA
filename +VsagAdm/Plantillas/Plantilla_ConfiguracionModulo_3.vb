Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plantilla_ConfiguracionModulo_3
    Dim xplantilla As IPlantilla_ConfiguracionModulo_3

    Property _MiPlantilla() As IPlantilla_ConfiguracionModulo_3
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantilla_ConfiguracionModulo_3)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplant As IPlantilla_ConfiguracionModulo_3)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _MiPlantilla = xplant
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_3_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me._MiPlantilla.Inicializa(Me)
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IPlantilla_ConfiguracionModulo_3
    Sub Inicializa(ByVal xobj As Object)
End Interface

Public Class LimiteFacturar
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            nm_1.Value = 12
            nm_1.Minimum = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_15", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class LimiteAdmDocumentos
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            nm_1.Minimum = 100
            nm_1.Maximum = 10000
            nm_1.Value = 1000
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_21", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class LimiteRetenciones
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            nm_1.Value = 10
            nm_1.Minimum = 1
            nm_1.Maximum = 10
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_22", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class LimiteAdmDocumentosCxc
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Cuentas por Cobrar"

            nm_1.Minimum = 100
            nm_1.Maximum = 10000
            nm_1.Value = 1000
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("CXC_01", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class LimiteAdmDocumentos_Compras
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            nm_1.Minimum = 100
            nm_1.Maximum = 10000
            nm_1.Value = 1000
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("COMPRAS_02", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class LimiteMaxTarjetas
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            nm_1.Minimum = 1
            nm_1.Maximum = 1000
            nm_1.Value = 100
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("PANAD_01", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class LimiteAdmDocumentosCxP
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Cuentas por Pagar"

            nm_1.Minimum = 100
            nm_1.Maximum = 10000
            nm_1.Value = 1000
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("CXP_02", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class LimiteDiasTrasladarDocumento
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            nm_1.Value = 0
            nm_1.Minimum = 0
            nm_1.Maximum = 1000
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENTAS_42", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class LimiteProductosMostrarAdmBusquedaNormal
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Inventario"

            nm_1.Value = 0
            nm_1.Minimum = 0
            nm_1.Maximum = 1000
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("INVENT_05", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class FASTFOOD_LIMITEADMDOCUMENTOS
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Sub New(ByVal id As Byte(), ByVal codigo_opc As String)
        _Id = id
        _CodigoOpcion = codigo_opc
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "FASTFOOD (POS)"

            nm_1.Minimum = 1
            nm_1.Maximum = 1000
            nm_1.Value = 100
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(_CodigoOpcion, xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RESTAURANT_NUMERO_MAXIMO_MESAS
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Numero Maximo De Mesas"
            _MiFormulario.Text = "Restaurant"

            nm_1.Minimum = 1
            nm_1.Maximum = 1000
            nm_1.Value = 20
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xvalor As Integer = Me.nm_1.Value
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("REST_02", xvalor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RetencionesIva_Compras
    Implements IPlantilla_ConfiguracionModulo_3
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    WithEvents nm_1 As NumericUpDown
    WithEvents bT_1 As Button

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_3.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            nm_1 = _MiFormulario.Controls.Find("NM_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Opciones Varias"
            _MiFormulario.Text = "Venta"

            nm_1.Value = 0
            nm_1.Minimum = 0
            nm_1.Maximum = 99999999
        Catch ex As Exception
            MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                If g_MiData.f_FichaCompras.F_HayRetenciones() Then
                    Throw New Exception("NO PUEDES ACTUALIZAR ESTE VALOR, YA QUE HAY RETENCIONES REALIZADAS")
                Else
                    Dim xvalor As Integer = Me.nm_1.Value
                    Dim xgl As New FichaGlobal
                    xgl.F_ActualizarOpcionConfiguracion("COMPRAS_03", xvalor, _Id)
                    RaiseEvent _ActualizarOpcion()
                    MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _MiFormulario.Close()
                End If
            End If
        Catch ex As Exception
            MensajeDeError(ex.Message)
        End Try
    End Sub
End Class
