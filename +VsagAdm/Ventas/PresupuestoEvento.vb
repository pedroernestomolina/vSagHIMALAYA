Public Class PresupuestoEvento
    Event _CantidadPersonasEvento(ByVal xcant As Integer)
    Dim xevento As Integer

    Sub New(ByVal xcant As Integer)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._CantidadPersonas = xcant
    End Sub

    Property _CantidadPersonas() As Integer
        Get
            Return xevento
        End Get
        Set(ByVal value As Integer)
            xevento = value
        End Set
    End Property

    Private Sub PresupuestoEvento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub PresupuestoEvento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.MN_1
            .Text = String.Format("{0:#0}", _CantidadPersonas)
            ._Formato = "9999"
            ._ConSigno = False
            .Focus()
            .SelectAll()
        End With
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If MessageBox.Show("Aceptar Este Valor Para El Presupuesto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            RaiseEvent _CantidadPersonasEvento(Me.MN_1._Valor)
            Me.Close()
        End If
    End Sub
End Class