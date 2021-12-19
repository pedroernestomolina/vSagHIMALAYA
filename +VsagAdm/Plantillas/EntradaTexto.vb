Public Class EntradaTexto
    Dim xplantilla As IEntradaTexto

    Property _Plantilla() As IEntradaTexto
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IEntradaTexto)
            xplantilla = value
        End Set
    End Property


    Sub New(ByVal xplant As IEntradaTexto)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._Plantilla = xplant
    End Sub

    Private Sub EntradaTexto_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            Me._Plantilla.Inicializa(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub
End Class

Public Interface IEntradaTexto
    Sub Inicializa(ByVal xform As Object)
End Interface

Public Class EntradaTexto_Venta
    Implements IEntradaTexto
    Event _TextoReemplazar(ByVal xtexto As String)

    Dim xtexto As String
    Dim xlargo As Integer

    WithEvents _form As New System.Windows.Forms.Form
    WithEvents MT_1 As New MisControles.Controles.MisTextos
    WithEvents BT_1 As New Button

    Property _TextoEditar() As String
        Get
            Return xtexto.Trim
        End Get
        Set(ByVal value As String)
            xtexto = value
        End Set
    End Property

    Property _Largo() As Integer
        Get
            Return xlargo
        End Get
        Set(ByVal value As Integer)
            xlargo = value
        End Set
    End Property

    Sub New(ByVal xtexto As String, ByVal xlargo As Integer)
        Me._TextoEditar = xtexto
        Me._Largo = xlargo
    End Sub

    Public Sub Inicializa(ByVal xform As Object) Implements IEntradaTexto.Inicializa
        _form = CType(xform, System.Windows.Forms.Form)
        Me.MT_1 = _form.Controls.Find("MT_1", True)(0)
        Me.BT_1 = _form.Controls.Find("BT_PROCESAR", True)(0)

        With MT_1
            .Text = _TextoEditar
            .MaxLength = _Largo
            .Focus()
        End With
    End Sub

    Private Sub _form_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _form.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            _form.Close()
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If MT_1.r_Valor <> "" Then
            If MessageBox.Show("Deseas Guardar Esta Nueva Descripcion ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                RaiseEvent _TextoReemplazar(Me.MT_1.r_Valor)
                _form.Close()
            Else
                Me.MT_1.Focus()
            End If
        End If
    End Sub
End Class