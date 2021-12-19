Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plantilla_ConfiguracionModulo_4
    Dim xplantilla As IPlantilla_ConfiguracionModulo_4

    Property _MiPlantilla() As IPlantilla_ConfiguracionModulo_4
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantilla_ConfiguracionModulo_4)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplant As IPlantilla_ConfiguracionModulo_4)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _MiPlantilla = xplant
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_ConfiguracionModulo_4_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me._MiPlantilla.Inicializa(Me)
    End Sub
End Class

Public Interface IPlantilla_ConfiguracionModulo_4
    Sub Inicializa(ByVal xobj As Object)
End Interface

Public Class RutaReportes
    Implements IPlantilla_ConfiguracionModulo_4
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents TB_1 As MisTextos
    WithEvents bT_1 As Button
    WithEvents LL_1 As LinkLabel

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_4.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            tb_1 = _MiFormulario.Controls.Find("TB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
            LL_1 = _MiFormulario.Controls.Find("LL_1", True)(0)

            With LL_1
                .Visible = True
                .Enabled = True
            End With

            lb_1.Text = "Reportes Sistema"
            lb_2.Text = "Indique La Ruta:"
            _MiFormulario.Text = "Global"

            With TB_1
                .Text = ""
                .MaxLength = 60
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
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_03", Me.TB_1.r_Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LL_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LL_1.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog
        Try
            With FolderBrowserDialog1
                .Reset() ' resetea   

                ' leyenda   
                .Description = " Seleccionar una Carpeta "
                ' Path " Mis documentos "   
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

                ' deshabilita el botón " crear nueva carpeta "   
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo   

                ' si se presionó el botón aceptar ...   
                If ret = Windows.Forms.DialogResult.OK Then
                    Me.TB_1.Text = .SelectedPath
                    Me.BT_1.Select()
                    Me.BT_1.Focus()
                End If
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ClaveMaxima
    Implements IPlantilla_ConfiguracionModulo_4
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents TB_1 As MisTextos
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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_4.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            tb_1 = _MiFormulario.Controls.Find("TB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Nivel Seguridad"
            lb_2.Text = "Clave Maxima:"
            _MiFormulario.Text = "Global"

            With TB_1
                .Text = ""
                .MaxLength = 60
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
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_10", Me.TB_1.r_Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ClaveMedia
    Implements IPlantilla_ConfiguracionModulo_4
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents TB_1 As MisTextos
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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_4.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            tb_1 = _MiFormulario.Controls.Find("TB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Nivel Seguridad"
            lb_2.Text = "Clave Media:"
            _MiFormulario.Text = "Global"

            With TB_1
                .Text = ""
                .MaxLength = 60
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
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_11", Me.TB_1.r_Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class ClaveMinima
    Implements IPlantilla_ConfiguracionModulo_4
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents TB_1 As MisTextos
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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_4.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            tb_1 = _MiFormulario.Controls.Find("TB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)

            lb_1.Text = "Nivel Seguridad"
            lb_2.Text = "Clave Minima:"
            _MiFormulario.Text = "Global"

            With TB_1
                .Text = ""
                .MaxLength = 60
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
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_12", Me.TB_1.r_Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RespaldoBd
    Implements IPlantilla_ConfiguracionModulo_4
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents TB_1 As MisTextos
    WithEvents bT_1 As Button
    WithEvents LL_1 As LinkLabel

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_4.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            tb_1 = _MiFormulario.Controls.Find("TB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
            LL_1 = _MiFormulario.Controls.Find("LL_1", True)(0)

            With LL_1
                .Visible = True
                .Enabled = True
            End With

            lb_1.Text = "Respaldo BD"
            lb_2.Text = "Indique La Ruta:"
            _MiFormulario.Text = "Global"

            With TB_1
                .Text = ""
                .MaxLength = 60
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
                xgl.F_ActualizarOpcionConfiguracion("GLOBAL_18", Me.TB_1.r_Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LL_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LL_1.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog
        Try
            With FolderBrowserDialog1
                .Reset() ' resetea   

                ' leyenda   
                .Description = " Seleccionar una Carpeta "
                ' Path " Mis documentos "   
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

                ' deshabilita el botón " crear nueva carpeta "   
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo   

                ' si se presionó el botón aceptar ...   
                If ret = Windows.Forms.DialogResult.OK Then
                    Me.TB_1.Text = .SelectedPath
                    Me.bT_1.Select()
                    Me.bT_1.Focus()
                End If

                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class RutaCarpetaImgInventario
    Implements IPlantilla_ConfiguracionModulo_4
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents TB_1 As MisTextos
    WithEvents bT_1 As Button
    WithEvents LL_1 As LinkLabel

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_4.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            tb_1 = _MiFormulario.Controls.Find("TB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
            LL_1 = _MiFormulario.Controls.Find("LL_1", True)(0)

            With LL_1
                .Visible = True
                .Enabled = True
            End With

            lb_1.Text = "Carpeta Imagenes"
            lb_2.Text = "Indique La Ruta:"
            _MiFormulario.Text = "Inventario"

            With TB_1
                .Text = ""
                .MaxLength = 60
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
                xgl.F_ActualizarOpcionConfiguracion("INVENT_07", Me.TB_1.r_Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                MessageBox.Show("Opcion Actualizada Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub LL_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LL_1.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog
        Try
            With FolderBrowserDialog1
                .Reset() ' resetea   

                ' leyenda   
                .Description = " Seleccionar una Carpeta "
                ' Path " Mis documentos "   
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

                ' deshabilita el botón " crear nueva carpeta "   
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo   

                ' si se presionó el botón aceptar ...   
                If ret = Windows.Forms.DialogResult.OK Then
                    Me.TB_1.Text = .SelectedPath
                    Me.BT_1.Select()
                    Me.BT_1.Focus()
                End If
                .Dispose()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class SUBDETALLE_FISCAL
    Implements IPlantilla_ConfiguracionModulo_4
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents TB_1 As MisTextos
    WithEvents bT_1 As Button
    WithEvents CB_AYUDA As ComboBox

    Dim xid As Byte()
    Dim xcodigo As String

    Property _Id() As Byte()
        Get
            Return xid
        End Get
        Set(ByVal value As Byte())
            xid = value
        End Set
    End Property

    Property _Item() As String
        Get
            Return Me.xcodigo
        End Get
        Set(ByVal value As String)
            Me.xcodigo = value
        End Set
    End Property

    Sub New(ByVal codigoitem As String, ByVal id As Byte())
        _Id = id
        _Item = codigoitem
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_4.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            tb_1 = _MiFormulario.Controls.Find("TB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
            CB_AYUDA = _MiFormulario.Controls.Find("CB_AYUDA", True)(0)

            lb_1.Text = "SubDetalle Fiscal"
            lb_2.Text = "Codigo Etiqueta A Desplegar:"
            _MiFormulario.Text = "Ventas:"

            With TB_1
                .Text = ""
                .MaxLength = 60
                .Select()
                .Focus()
                .ReadOnly = True
            End With
            CB_AYUDA.Visible = True
            CB_AYUDA.SelectedItem = 0
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub bT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bT_1.Click
        Try
            If MessageBox.Show("Deseas Guardar Esta Opcion Como Predeterminada ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim xgl As New FichaGlobal
                xgl.F_ActualizarOpcionConfiguracion(_Item, Me.TB_1.r_Valor, _Id)
                RaiseEvent _ActualizarOpcion()

                Funciones.MensajeDeOk("Opcion Actualizada Exitosamente...")
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub CB_AYUDA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_AYUDA.SelectedIndexChanged
        Me.TB_1.Text = Me.CB_AYUDA.SelectedItem.ToString
    End Sub
End Class

Public Class RESTAURANT_RUTACARPETAIMAGENES_SISTEMA
    Implements IPlantilla_ConfiguracionModulo_4
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents TB_1 As MisTextos
    WithEvents bT_1 As Button
    WithEvents LL_1 As LinkLabel

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_4.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            tb_1 = _MiFormulario.Controls.Find("TB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
            LL_1 = _MiFormulario.Controls.Find("LL_1", True)(0)

            With LL_1
                .Visible = True
                .Enabled = True
            End With

            lb_1.Text = "Carpeta Imagenes"
            lb_2.Text = "Indique La Ruta:"
            _MiFormulario.Text = "Restaurant"

            With TB_1
                .Text = ""
                .MaxLength = 60
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
                xgl.F_ActualizarOpcionConfiguracion("REST_07", Me.TB_1.r_Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                Funciones.MensajeDeOk("Opcion Actualizada Exitosamente... ")
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub LL_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LL_1.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog
        Try
            With FolderBrowserDialog1
                .Reset() ' resetea   

                ' leyenda   
                .Description = " Seleccionar una Carpeta "
                ' Path " Mis documentos "   
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

                ' deshabilita el botón " crear nueva carpeta "   
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo   

                ' si se presionó el botón aceptar ...   
                If ret = Windows.Forms.DialogResult.OK Then
                    Me.TB_1.Text = .SelectedPath
                    Me.BT_1.Select()
                    Me.BT_1.Focus()
                End If
                .Dispose()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class RESTAURANT_RUTACARPETAIMAGENES_WEB
    Implements IPlantilla_ConfiguracionModulo_4
    Event _ActualizarOpcion()

    Dim xform As System.Windows.Forms.Form
    Dim lb_1 As Label
    Dim lb_2 As Label
    WithEvents TB_1 As MisTextos
    WithEvents bT_1 As Button
    WithEvents LL_1 As LinkLabel

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

    Public Sub Inicializa(ByVal xobj As Object) Implements IPlantilla_ConfiguracionModulo_4.Inicializa
        Try
            _MiFormulario = xobj

            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            lb_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            tb_1 = _MiFormulario.Controls.Find("TB_1", True)(0)
            bT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
            LL_1 = _MiFormulario.Controls.Find("LL_1", True)(0)

            With LL_1
                .Visible = True
                .Enabled = True
            End With

            lb_1.Text = "Carpeta Imagenes"
            lb_2.Text = "Indique La Ruta:"
            _MiFormulario.Text = "Restaurant Movil"

            With TB_1
                .Text = ""
                .MaxLength = 60
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
                xgl.F_ActualizarOpcionConfiguracion("REST_08", Me.TB_1.r_Valor, _Id)
                RaiseEvent _ActualizarOpcion()
                Funciones.MensajeDeOk("Opcion Actualizada Exitosamente... ")
                _MiFormulario.Close()
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub LL_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LL_1.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog
        Try
            With FolderBrowserDialog1
                .Reset() ' resetea   

                ' leyenda   
                .Description = " Seleccionar una Carpeta "
                ' Path " Mis documentos "   
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

                ' deshabilita el botón " crear nueva carpeta "   
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo   

                ' si se presionó el botón aceptar ...   
                If ret = Windows.Forms.DialogResult.OK Then
                    Me.TB_1.Text = .SelectedPath
                    Me.BT_1.Select()
                    Me.BT_1.Focus()
                End If
                .Dispose()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class
