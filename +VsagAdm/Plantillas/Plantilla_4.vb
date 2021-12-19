Imports DataSistema.MiDataSistema.DataSistema

Public Class Plantilla_4
    Dim xplantilla As IPlantilla_4

    Property Plantilla() As IPlantilla_4
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantilla_4)
            xplantilla = value
        End Set
    End Property

    Private Sub Plantilla_4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Sub Inicializa()
        Try
            Me.Text = ""
            Me.E_AGENCIA.Text = ""
            Me.E_NOMBRE.Text = ""
            Me.E_NUMERO.Text = ""
            Me.E_TIPO.Text = ""

            Me.Text = Me.Plantilla._TextoVentana
            Me.E_AGENCIA.Text = Me.Plantilla._Agencia
            Me.E_NOMBRE.Text = Me.Plantilla._ANombreDe
            Me.E_NUMERO.Text = Me.Plantilla._NumeroCta
            Me.E_TIPO.Text = Me.Plantilla._TipoCta
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Plantilla_4_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub New(ByVal xcta As IPlantilla_4)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.Plantilla = xcta
    End Sub
End Class

Public Interface IPlantilla_4
    ReadOnly Property _TextoVentana() As String
    ReadOnly Property _Agencia() As String
    ReadOnly Property _TipoCta() As String
    ReadOnly Property _NumeroCta() As String
    ReadOnly Property _ANombreDe() As String
End Interface

Public Class MostrarCtaProveedor
    Implements IPlantilla_4

    Dim xcta_prv As FichaProveedores.c_CtasBancarias

    Property CtaProveedor() As FichaProveedores.c_CtasBancarias
        Get
            Return xcta_prv
        End Get
        Set(ByVal value As FichaProveedores.c_CtasBancarias)
            xcta_prv = value
        End Set
    End Property

    Sub New(ByVal xcta As FichaProveedores.c_CtasBancarias)
        Me.CtaProveedor = xcta
    End Sub

    Public ReadOnly Property _TextoVentana() As String Implements IPlantilla_4._TextoVentana
        Get
            Return "Cta / Proveedor"
        End Get
    End Property

    Public ReadOnly Property _Agencia() As String Implements IPlantilla_4._Agencia
        Get
            Try
                Return CtaProveedor.RegistroDato.r_AgenciaNombre
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
            End Try
        End Get
    End Property

    Public ReadOnly Property _ANombreDe() As String Implements IPlantilla_4._ANombreDe
        Get
            Return CtaProveedor.RegistroDato.c_A_Favor_De.c_Texto
        End Get
    End Property

    Public ReadOnly Property _NumeroCta() As String Implements IPlantilla_4._NumeroCta
        Get
            Return CtaProveedor.RegistroDato.c_NumeroCta.c_Texto
        End Get
    End Property

    Public ReadOnly Property _TipoCta() As String Implements IPlantilla_4._TipoCta
        Get
            Return CtaProveedor.RegistroDato.c_TipoCta.c_Texto
        End Get
    End Property
End Class