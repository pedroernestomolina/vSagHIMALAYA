Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plantilla_ConfiguracionModulo_5
    Dim xplantilla As IPlantilla_ConfiguracionModulo_5

    Property _MiPlantilla() As IPlantilla_ConfiguracionModulo_5
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantilla_ConfiguracionModulo_5)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplant As IPlantilla_ConfiguracionModulo_5)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _MiPlantilla = xplant
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_5_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me._MiPlantilla.Inicializa(Me)
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IPlantilla_ConfiguracionModulo_5
    Sub Inicializa(ByVal xobj As Object)
End Interface

Public Class MontoComisionChequeDevuelto
    Implements IPlantilla_ConfiguracionModulo_5
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents nb_1 As MisNumeros
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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_5.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            nb_1 = _MiFormulario.Controls.Find("NB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Comision Por Cheque Devuelto"
            lb_2.Text = "Indique El Monto:"
            _MiFormulario.Text = "Cuentas por Cobrar"

            With nb_1
                ._ConSigno = False
                ._Formato = "9999999.99"
                .Text = ""
                .Select()
                .Focus()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("CXC_02", Me.nb_1._Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class MontoComisionVendedor
    Implements IPlantilla_ConfiguracionModulo_5
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents nb_1 As MisNumeros
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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_5.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            nb_1 = _MiFormulario.Controls.Find("NB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Comision (%)"
            lb_2.Text = "Indique El Monto:"
            _MiFormulario.Text = "Vendedor"

            With nb_1
                ._ConSigno = False
                ._Formato = "9999999.99"
                .Text = ""
                .Select()
                .Focus()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("VENDED_01", Me.nb_1._Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class MontoComisionCobrador
    Implements IPlantilla_ConfiguracionModulo_5
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents nb_1 As MisNumeros
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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_5.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            nb_1 = _MiFormulario.Controls.Find("NB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Comision (%)"
            lb_2.Text = "Indique El Monto:"
            _MiFormulario.Text = "Cobrador:"

            With nb_1
                ._ConSigno = False
                ._Formato = "9999999.99"
                .Text = ""
                .Select()
                .Focus()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("COBRAD_01", Me.nb_1._Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class TarifaHoraEstacionamiento
    Implements IPlantilla_ConfiguracionModulo_5
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents nb_1 As MisNumeros
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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_5.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            nb_1 = _MiFormulario.Controls.Find("NB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Tarifa Hora (Bs)"
            lb_2.Text = "Indique El Monto:"
            _MiFormulario.Text = "Estacionamiento"

            With nb_1
                ._ConSigno = False
                ._Formato = "999.99"
                .Text = ""
                .Select()
                .Focus()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("COBRAD_01", Me.nb_1._Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RESTAURANT_TASA_SERVICIO
    Implements IPlantilla_ConfiguracionModulo_5
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents nb_1 As MisNumeros
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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_5.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            nb_1 = _MiFormulario.Controls.Find("NB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Tasa Servicio A La Mesa"
            lb_2.Text = "Indique El Monto:"
            _MiFormulario.Text = "Restaurant"

            With nb_1
                ._ConSigno = False
                ._Formato = "99.99"
                .Text = ""
                .Select()
                .Focus()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("REST_03", Me.nb_1._Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class CxC_DescuentoPorProntoPago
    Implements IPlantilla_ConfiguracionModulo_5
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents nb_1 As MisNumeros
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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_5.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            nb_1 = _MiFormulario.Controls.Find("NB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Descuento Por Pronto Pago"
            lb_2.Text = "Indique El (%):"
            _MiFormulario.Text = "Cuentas por Cobrar"

            With nb_1
                ._ConSigno = False
                ._Formato = "999.99"
                .Text = ""
                .Select()
                .Focus()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion("CXC_03", Me.nb_1._Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                Funciones.MensajeDeOk("Opcion Actualizada Exitosamente... Ok")
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class


Public Class Inventario_PorcentajeIncrementar
    Implements IPlantilla_ConfiguracionModulo_5
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents nb_1 As MisNumeros
    WithEvents bT_1 As Button
    Private _porcentajeSeleccionado As Decimal

    Sub New()
        PorcentajeSeleccionado = 0
    End Sub

    Property PorcentajeSeleccionado() As Decimal
        Get
            Return _porcentajeSeleccionado
        End Get
        Set(ByVal value As Decimal)
            _porcentajeSeleccionado = value
        End Set
    End Property

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_5.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            nb_1 = _MiFormulario.Controls.Find("NB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Porcentaje A Incrementar"
            lb_2.Text = "Indique El (%):"
            _MiFormulario.Text = "Inventario De Productos"

            With nb_1
                ._ConSigno = False
                ._Formato = "999.99"
                .Text = ""
                .Select()
                .Focus()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If nb_1._Valor > 0 Then
                If MessageBox.Show("Deseas Aplicar Este Porcentaje A Todos Los Productos Seleccionados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    PorcentajeSeleccionado = nb_1._Valor
                    _MiFormulario.Close()
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class