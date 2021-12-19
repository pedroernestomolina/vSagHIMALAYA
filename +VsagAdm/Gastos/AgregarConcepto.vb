Imports DataSistema.MiDataSistema.DataSistema

Public Class AgregarConcepto
    Dim xplantillas As IConceptosGastos

    Sub New(ByVal xplant As IConceptosGastos)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplant
    End Sub

    Property _Plantilla() As IConceptosGastos
        Get
            Return xplantillas
        End Get
        Set(ByVal value As IConceptosGastos)
            xplantillas = value
        End Set
    End Property

    Private Sub AgregarConcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub AgregarConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub AgregarConcepto_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            _Plantilla.Inicializa(Me)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Interface IConceptosGastos
    Sub Inicializa(ByVal xform As Object)
End Interface

Public Class AgregarConceptoGasto
    Implements IConceptosGastos
    Event _Actualizar()

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents L_1 As Label
    WithEvents L_2 As Label
    WithEvents MT_1 As MisControles.Controles.MisTextos
    WithEvents MCHB_1 As MisControles.Controles.MisCheckBox
    WithEvents BT_1 As Button

    Public Sub Inicializa(ByVal xform As Object) Implements IConceptosGastos.Inicializa
        Try
            _Form = CType(xform, System.Windows.Forms.Form)
            Me.L_1 = _Form.Controls.Find("L_1", True)(0)
            Me.L_2 = _Form.Controls.Find("L_2", True)(0)
            Me.MT_1 = _Form.Controls.Find("MT_1", True)(0)
            Me.BT_1 = _Form.Controls.Find("BT_1", True)(0)
            Me.MCHB_1 = _Form.Controls.Find("MCHB_1", True)(0)

            Me.L_1.Text = "Agregar Nuevo Concepto"
            Me.L_2.Text = "Agregar / Nuevo "

            With Me.MT_1
                .Text = ""
                .MaxLength = 50
                .Focus()
                .Select()
            End With
            Me.MCHB_1.Checked = True
            Me.MCHB_1.Enabled = False
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If Me.MT_1.r_Valor <> "" Then
            If MessageBox.Show("Deseas Guardar Este Nuevo Concepto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xgasto As New ControlGastos
                    AddHandler xgasto._ActualizarTablaGastos, AddressOf OK
                    xgasto.F_AgregarConcepto(Me.MT_1.r_Valor)
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        Else
            With Me.MT_1
                .Focus()
                .Select()
            End With
        End If
    End Sub

    Sub Ok()
        RaiseEvent _Actualizar()
        Funciones.MensajeDeAlerta("Concepto Gasto Procesado Exitosamente...")
        _Form.Close()
    End Sub
End Class

Public Class ModificarConceptoGasto
    Implements IConceptosGastos
    Event _Actualizar()

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents L_1 As Label
    WithEvents L_2 As Label
    WithEvents MT_1 As MisControles.Controles.MisTextos
    WithEvents MCHB_1 As MisControles.Controles.MisCheckBox
    WithEvents BT_1 As Button
    Dim xconcepto As ControlGastos.Conceptos

    Public Sub Inicializa(ByVal xform As Object) Implements IConceptosGastos.Inicializa
        Try
            _Form = CType(xform, System.Windows.Forms.Form)
            Me.L_1 = _Form.Controls.Find("L_1", True)(0)
            Me.L_2 = _Form.Controls.Find("L_2", True)(0)
            Me.MT_1 = _Form.Controls.Find("MT_1", True)(0)
            Me.BT_1 = _Form.Controls.Find("BT_1", True)(0)
            Me.MCHB_1 = _Form.Controls.Find("MCHB_1", True)(0)

            Me.L_1.Text = "Modificar Concepto"
            Me.L_2.Text = "Modificar / Actualizar "

            With Me.MT_1
                .Text = ""
                .MaxLength = 50
                .Focus()
                .Select()
            End With
            Me.MCHB_1.Checked = False

            Me.MT_1.Text = xconcepto.RegistroDato._NombreConcepto
            Me.MCHB_1.Checked = IIf(xconcepto.RegistroDato._Estatus = TipoEstatus.Activo, True, False)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If Me.MT_1.r_Valor <> "" Then
            If MessageBox.Show("Deseas Guardar Estos Cambios ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xgastoMod As New ControlGastos.ActualizarConcepto
                    Dim xgasto As New ControlGastos
                    AddHandler xgasto._ActualizarTablaGastos, AddressOf Ok

                    With xgastoMod
                        ._Estatus = Me.MCHB_1.Checked
                        ._FichaActualizar = xconcepto.RegistroDato
                        ._NombreNuevo = Me.MT_1.r_Valor
                    End With

                    xgasto.F_ModificarConcepto(xgastoMod)
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        Else
            With Me.MT_1
                .Focus()
                .Select()
            End With
        End If
    End Sub

    Sub Ok()
        RaiseEvent _Actualizar()
        Funciones.MensajeDeAlerta("Concepto Gasto Procesado Exitosamente...")
        _Form.Close()
    End Sub

    Sub New(ByVal xconcepto_modificar As ControlGastos.Conceptos)
        xconcepto = xconcepto_modificar
    End Sub
End Class

Public Class AgregarSubConceptoGasto
    Implements IConceptosGastos
    Event _Actualizar()

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents L_1 As Label
    WithEvents L_2 As Label
    WithEvents MT_1 As MisControles.Controles.MisTextos
    WithEvents MCHB_1 As MisControles.Controles.MisCheckBox
    WithEvents BT_1 As Button

    Public Sub Inicializa(ByVal xform As Object) Implements IConceptosGastos.Inicializa
        Try
            _Form = CType(xform, System.Windows.Forms.Form)
            Me.L_1 = _Form.Controls.Find("L_1", True)(0)
            Me.L_2 = _Form.Controls.Find("L_2", True)(0)
            Me.MT_1 = _Form.Controls.Find("MT_1", True)(0)
            Me.BT_1 = _Form.Controls.Find("BT_1", True)(0)
            Me.MCHB_1 = _Form.Controls.Find("MCHB_1", True)(0)

            Me.L_1.Text = "Agregar Nuevo SubConcepto"
            Me.L_2.Text = "Agregar / Nuevo "

            With Me.MT_1
                .Text = ""
                .MaxLength = 50
                .Focus()
                .Select()
            End With
            Me.MCHB_1.Checked = True
            Me.MCHB_1.Enabled = False
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If Me.MT_1.r_Valor <> "" Then
            If MessageBox.Show("Deseas Guardar Este Nuevo SubConcepto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xgasto As New ControlGastos
                    AddHandler xgasto._ActualizarTablaGastos, AddressOf Ok
                    xgasto.F_AgregarSubConcepto(Me.MT_1.r_Valor)
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        Else
            With Me.MT_1
                .Focus()
                .Select()
            End With
        End If
    End Sub

    Sub Ok()
        RaiseEvent _Actualizar()
        Funciones.MensajeDeAlerta("SubConcepto Gasto Procesado Exitosamente...")
        _Form.Close()
    End Sub
End Class

Public Class ModificarSubConceptoGasto
    Implements IConceptosGastos
    Event _Actualizar()

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents L_1 As Label
    WithEvents L_2 As Label
    WithEvents MT_1 As MisControles.Controles.MisTextos
    WithEvents MCHB_1 As MisControles.Controles.MisCheckBox
    WithEvents BT_1 As Button
    Dim xsubconcepto As ControlGastos.SubConceptos

    Public Sub Inicializa(ByVal xform As Object) Implements IConceptosGastos.Inicializa
        Try
            _Form = CType(xform, System.Windows.Forms.Form)
            Me.L_1 = _Form.Controls.Find("L_1", True)(0)
            Me.L_2 = _Form.Controls.Find("L_2", True)(0)
            Me.MT_1 = _Form.Controls.Find("MT_1", True)(0)
            Me.BT_1 = _Form.Controls.Find("BT_1", True)(0)
            Me.MCHB_1 = _Form.Controls.Find("MCHB_1", True)(0)

            Me.L_1.Text = "Modificar SubConcepto"
            Me.L_2.Text = "Modificar / Actualizar "

            With Me.MT_1
                .Text = ""
                .MaxLength = 50
                .Focus()
                .Select()
            End With
            Me.MCHB_1.Checked = False

            Me.MT_1.Text = xsubconcepto.RegistroDato._NombreConcepto
            Me.MCHB_1.Checked = IIf(xsubconcepto.RegistroDato._Estatus = TipoEstatus.Activo, True, False)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If Me.MT_1.r_Valor <> "" Then
            If MessageBox.Show("Deseas Guardar Estos Cambios ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xgastoMod As New ControlGastos.ActualizarSubConcepto
                    Dim xgasto As New ControlGastos
                    AddHandler xgasto._ActualizarTablaGastos, AddressOf Ok

                    With xgastoMod
                        ._Estatus = Me.MCHB_1.Checked
                        ._FichaActualizar = xsubconcepto.RegistroDato
                        ._NombreNuevo = Me.MT_1.r_Valor
                    End With

                    xgasto.F_ModificarSubConcepto(xgastoMod)
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        Else
            With Me.MT_1
                .Focus()
                .Select()
            End With
        End If
    End Sub

    Sub Ok()
        RaiseEvent _Actualizar()
        Funciones.MensajeDeAlerta("Concepto Gasto Procesado Exitosamente...")
        _Form.Close()
    End Sub

    Sub New(ByVal xconcepto_modificar As ControlGastos.SubConceptos)
        xsubconcepto = xconcepto_modificar
    End Sub
End Class
