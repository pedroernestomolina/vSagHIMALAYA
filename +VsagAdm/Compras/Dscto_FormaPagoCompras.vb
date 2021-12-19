Imports DataSistema.MiDataSistema.DataSistema

Public Class Dscto_FormaPagoCompras
    Dim xestatus_salida As Boolean
    Dim xtotales As TotalesDoc
    Dim xmonto_total As Decimal
    Dim xhabcar As Boolean

    Dim xdesc As Decimal = 0
    Dim xcarg As Decimal = 0

    Property _HabilitarCargos() As Boolean
        Get
            Return xhabcar
        End Get
        Set(ByVal value As Boolean)
            xhabcar = value
        End Set
    End Property

    Property _MontoTotal() As Decimal
        Get
            Return xmonto_total
        End Get
        Set(ByVal value As Decimal)
            xmonto_total = value
        End Set
    End Property

    Property _MisTotales() As TotalesDoc
        Get
            Return xtotales
        End Get
        Set(ByVal value As TotalesDoc)
            xtotales = value
        End Set
    End Property

    Property _EstatusSalida() As Boolean
        Get
            Return xestatus_salida
        End Get
        Set(ByVal value As Boolean)
            xestatus_salida = value
        End Set
    End Property

    Property _TasaDescuento() As Decimal
        Get
            Return xdesc
        End Get
        Set(ByVal value As Decimal)
            xdesc = value
        End Set
    End Property

    Property _TasaCargo() As Decimal
        Get
            Return xcarg
        End Get
        Set(ByVal value As Decimal)
            xcarg = value
        End Set
    End Property

    Private Sub Dscto_FormaPago_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _EstatusSalida = False Then
            If MessageBox.Show("Estas Seguro De Salir y Cerrar Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Dscto_FormaPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Dscto_FormaPago_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub LimpiarPantalla()
        Me.E_IMPUESTO.Text = "0.0"
        Me.E_SUB_1.Text = "0.0"
        Me.E_SUB_2.Text = "0.0"
        Me.E_TOTAL.Text = "0.0"
    End Sub

    Sub ActualizaPlantilla()
        Me.E_SUB_1.Text = String.Format("{0:#0.00}", _MisTotales._Subtotal)
        Me.E_SUB_2.Text = String.Format("{0:#0.00}", _MisTotales._Subtotal)
        Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", _MisTotales._SubtotalIva)
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", _MisTotales._TotalGeneral)
    End Sub

    Sub Inicializa()
        Try
            _EstatusSalida = False
            LimpiarPantalla()

            With MN_DSC1
                ._ConSigno = False
                ._Formato = "99.99"
                .Text = "0.0"
            End With
            With MN_DSC2
                ._ConSigno = False
                ._Formato = "9999999.99"
                .Text = "0.0"
            End With
            With MN_CARGO1
                .Enabled = _HabilitarCargos
                ._ConSigno = False
                ._Formato = "99.99"
                .Text = "0.0"
            End With
            With MN_CARGO2
                .Enabled =_HabilitarCargos 
                ._ConSigno = False
                ._Formato = "9999999.99"
                .Text = "0.0"
            End With

            ActualizaPlantilla()
            Me.MN_DSC1.Text = String.Format("{0:#0.00}", _MisTotales._TasaDescuento)
            ReCalcular(1)
            Me.MN_CARGO1.Text = String.Format("{0:#0.00}", _MisTotales._TasaCargo)
            ReCalcular(1)

            Me.MN_DSC1.Select()
            Me.MN_DSC1.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub MN_DSC1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DSC1.LostFocus, MN_CARGO1.LostFocus
        ReCalcular(1)
    End Sub

    Private Sub MN_DSC2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DSC2.LostFocus, MN_CARGO2.LostFocus
        ReCalcular(2)
    End Sub

    Sub ReCalcular(ByVal xtipo As Integer)
        Dim xexe As Decimal = 0
        Dim xmn1 As Decimal = 0
        Dim xmn2 As Decimal = 0
        Dim xmn3 As Decimal = 0

        Dim xiv1 As Decimal = 0
        Dim xiv2 As Decimal = 0
        Dim xiv3 As Decimal = 0

        Dim xsubt As Decimal = 0
        Dim xiva As Decimal = 0
        Dim xtotal As Decimal = 0

        Dim x1 As Decimal = 0
        Dim x2 As Decimal = 0
        Dim x3 As Decimal = 0
        Dim x4 As Decimal = 0
        Dim x5 As Decimal = 0

        Dim xd1 As Decimal = 0
        Dim xd2 As Decimal = 0
        Dim xd3 As Decimal = 0
        Dim xd4 As Decimal = 0
        Dim descuento As Decimal = 0

        Dim xc1 As Decimal = 0
        Dim xc2 As Decimal = 0
        Dim xc3 As Decimal = 0
        Dim xc4 As Decimal = 0
        Dim cargo As Decimal = 0

        xexe = _MisTotales._Exento
        xmn1 = _MisTotales._Neto1
        xmn2 = _MisTotales._Neto2
        xmn3 = _MisTotales._Neto3

        If xtipo = 2 Then
            If Me.MN_DSC2._Valor >= _MisTotales._Subtotal Then
                Me.MN_DSC2.Text = "0.0"
                MessageBox.Show("Alerta... Monto Descuento No Puede Ser Superior Al SubTotal General", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Dim xt As Decimal = Decimal.Round((Me.MN_DSC2._Valor / _MisTotales._Subtotal) * 100, 2, MidpointRounding.AwayFromZero)
            _TasaDescuento = xt
            Me.MN_DSC1.Text = String.Format("{0:#0.00}", Decimal.Round(xt, 2, MidpointRounding.AwayFromZero))
        Else
            _TasaDescuento = Me.MN_DSC1._Valor
        End If

        xd1 = Decimal.Round(xexe * _TasaDescuento / 100, 2, MidpointRounding.AwayFromZero)
        xd2 = Decimal.Round(xmn1 * _TasaDescuento / 100, 2, MidpointRounding.AwayFromZero)
        xd3 = Decimal.Round(xmn2 * _TasaDescuento / 100, 2, MidpointRounding.AwayFromZero)
        xd4 = Decimal.Round(xmn3 * _TasaDescuento / 100, 2, MidpointRounding.AwayFromZero)
        descuento = Decimal.Round(xd1 + xd2 + xd3 + xd4, 2, MidpointRounding.AwayFromZero)
        Me.MN_DSC2.Text = String.Format("{0:#0.00}", descuento)

        xexe = Decimal.Round(xexe - (xexe * _TasaDescuento / 100), 2, MidpointRounding.AwayFromZero)
        xmn1 = Decimal.Round(xmn1 - (xmn1 * _TasaDescuento / 100), 2, MidpointRounding.AwayFromZero)
        xmn2 = Decimal.Round(xmn2 - (xmn2 * _TasaDescuento / 100), 2, MidpointRounding.AwayFromZero)
        xmn3 = Decimal.Round(xmn3 - (xmn3 * _TasaDescuento / 100), 2, MidpointRounding.AwayFromZero)

        If xtipo = 2 Then
            Dim xs As Decimal = xexe + xmn1 + xmn2 + xmn3
            Dim xt As Decimal = Decimal.Round((Me.MN_CARGO2._Valor / xs) * 100, 2, MidpointRounding.AwayFromZero)
            _TasaCargo = xt
            Me.MN_CARGO1.Text = String.Format("{0:#0.00}", Decimal.Round(xt, 2, MidpointRounding.AwayFromZero))
        Else
            _TasaCargo = Me.MN_CARGO1._Valor
        End If

        xc1 = Decimal.Round((xexe * _TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
        xc2 = Decimal.Round((xmn1 * _TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
        xc3 = Decimal.Round((xmn2 * _TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
        xc4 = Decimal.Round((xmn3 * _TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
        cargo = Decimal.Round(xc1 + xc2 + xc3 + xc4, 2, MidpointRounding.AwayFromZero)
        Me.MN_CARGO2.Text = String.Format("{0:#0.00}", cargo)

        xexe = Decimal.Round(xexe + (xexe * _TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
        xmn1 = Decimal.Round(xmn1 + (xmn1 * _TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
        xmn2 = Decimal.Round(xmn2 + (xmn2 * _TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
        xmn3 = Decimal.Round(xmn3 + (xmn3 * _TasaCargo / 100), 2, MidpointRounding.AwayFromZero)

        xsubt = Decimal.Round(xexe + xmn1 + xmn2 + xmn3, 2, MidpointRounding.AwayFromZero)
        xiv1 = Decimal.Round(xmn1 * _MisTotales._TasaIva1 / 100, 2, MidpointRounding.AwayFromZero)
        xiv2 = Decimal.Round(xmn2 * _MisTotales._TasaIva2 / 100, 2, MidpointRounding.AwayFromZero)
        xiv3 = Decimal.Round(xmn3 * _MisTotales._TasaIva3 / 100, 2, MidpointRounding.AwayFromZero)
        xiva = Decimal.Round(xiv1 + xiv2 + xiv3, 2, MidpointRounding.AwayFromZero)
        xtotal = Decimal.Round(xsubt + xiva, 2, MidpointRounding.AwayFromZero)

        Me.E_SUB_2.Text = String.Format("{0:#0.00}", xsubt)
        Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", xiva)
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", xtotal)

        _MontoTotal = xtotal
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If MessageBox.Show("Procesar/Guardar Este Documento ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Me._EstatusSalida = True
            Me._MisTotales._TasaDescuento = _TasaDescuento
            Me._MisTotales._TasaCargo = _TasaCargo
            Me.Close()
        End If
    End Sub

    Sub New(ByRef totales As TotalesDoc, ByVal xopc As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MisTotales = totales
        _HabilitarCargos = xopc
    End Sub

    Private Sub Dscto_FormaPagoCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class