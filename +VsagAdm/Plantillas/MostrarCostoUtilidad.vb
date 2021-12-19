Imports DataSistema.MiDataSistema.DataSistema

Public Class MostrarCostoUtilidad
    Dim xreg As VerCostoUtilidad
    Dim xcosto As Precio
    Dim xprecio As Precio

    Property _RegVisualizar() As VerCostoUtilidad
        Get
            Return xreg
        End Get
        Set(ByVal value As VerCostoUtilidad)
            xreg = value
        End Set
    End Property

    Sub New(ByVal xregistro As VerCostoUtilidad, ByVal xtasa As Decimal)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._RegVisualizar = xregistro
        xcosto = New Precio(xregistro._CostoNeto, xtasa)
        xprecio = New Precio(xregistro._PrecioNeto, xtasa)
    End Sub

    Private Sub MostrarCostoUtilidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub MostrarCostoUtilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.E_1.Text = String.Format("{0:#0.00}", Me._RegVisualizar._CostoNeto)
        Me.E_2.Text = String.Format("{0:#0}", Me._RegVisualizar._ContenidoEmpaqueVenta)
        Me.E_3.Text = String.Format("{0:#0.00}", Me._RegVisualizar._CostoNetoInv)
        Me.E_4.Text = String.Format("{0:#0.00}", Me._RegVisualizar._PrecioNeto)
        Me.E_5.Text = String.Format("{0:#0.00}", Me._RegVisualizar._MargenGanancia)
        Me.E_6.Text = String.Format("{0:#0.00}", Me._RegVisualizar._Utilidad)

        Dim xcu As Decimal = Decimal.Round(xcosto._Full / Me._RegVisualizar._ContenidoEmpaqueVenta, 2, MidpointRounding.AwayFromZero)
        Dim xmg As Decimal = Decimal.Round(xprecio._Full - xcosto._Full, 2, MidpointRounding.AwayFromZero)

        Me.E_COSTO_FULL.Text = String.Format("{0:#0.00}", xcosto._Full)
        Me.E_COSTO_FULL_UNIDAD.Text = String.Format("{0:#0.00}", xcu)
        Me.E_PV_FULL.Text = String.Format("{0:#0.00}", xprecio._Full)
        Me.E_MARGEN_FULL.Text = String.Format("{0:#0.00}", xmg)
    End Sub
End Class