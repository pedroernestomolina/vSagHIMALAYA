Public Class ProcesarDoc_NC
    Dim xtotales As IPlantilla_10.Totales_Data
    Dim xestatus_salida As Boolean
    Dim xtotaldocumento As Decimal
    Dim xplant As ITipoNCND
    Dim xactivacargosydescuentos As Boolean
    Dim xtotgeneraldoc As Decimal
    Dim xAjusteGlobal As Boolean

    Property _AjusteGlobal() As Boolean
        Get
            Return xAjusteGlobal
        End Get
        Set(ByVal value As Boolean)
            xAjusteGlobal = value
        End Set
    End Property

    Property _ActivarCargosDescuentos() As Boolean
        Get
            Return xactivacargosydescuentos
        End Get
        Set(ByVal value As Boolean)
            xactivacargosydescuentos = value
        End Set
    End Property

    Property _Plantilla() As ITipoNCND
        Get
            Return xplant
        End Get
        Set(ByVal value As ITipoNCND)
            xplant = value
        End Set
    End Property

    Property _SubTotal_DocOrigen() As Decimal
        Get
            Return xtotaldocumento
        End Get
        Set(ByVal value As Decimal)
            xtotaldocumento = value
        End Set
    End Property

    Property _TotalGeneral_DocOrigen() As Decimal
        Get
            Return xtotgeneraldoc
        End Get
        Set(ByVal value As Decimal)
            xtotgeneraldoc = value
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

    Property _MisTotales() As IPlantilla_10.Totales_Data
        Get
            Return xtotales
        End Get
        Set(ByVal value As IPlantilla_10.Totales_Data)
            xtotales = value
        End Set
    End Property

    Sub New(ByVal xplantilla As ITipoNCND, ByVal TotalesData As IPlantilla_10.Totales_Data)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MisTotales = TotalesData
        _SubTotal_DocOrigen = TotalesData._FichaRegistroVentas._MontoSubtotal
        _TotalGeneral_DocOrigen = TotalesData._FichaRegistroVentas._TotalGenereal
        _Plantilla = xplantilla
        _ActivarCargosDescuentos = IIf(_MisTotales._Subtotal = _SubTotal_DocOrigen, True, False)
        _AjusteGlobal = False
    End Sub

    Sub LimpiarPantalla()
        Me.E_IMPUESTO.Text = "0.0"
        Me.E_TOTAL_MOVIMIENTO.Text = "0.0"
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
            descuento = Me.MN_DSC2._Valor()
            Dim d As Decimal = 0
            If Me._MisTotales._Subtotal > 0 Then
                d = Decimal.Round(descuento / Me._MisTotales._Subtotal * 100, 2, MidpointRounding.AwayFromZero)
                Me.MN_DSC1.Text = String.Format("{0:#0.00}", d)
            End If
        End If

        xd1 = Decimal.Round(xexe * MN_DSC1._Valor / 100, 2, MidpointRounding.AwayFromZero)
        xd2 = Decimal.Round(xmn1 * MN_DSC1._Valor / 100, 2, MidpointRounding.AwayFromZero)
        xd3 = Decimal.Round(xmn2 * MN_DSC1._Valor / 100, 2, MidpointRounding.AwayFromZero)
        xd4 = Decimal.Round(xmn3 * MN_DSC1._Valor / 100, 2, MidpointRounding.AwayFromZero)
        descuento = Decimal.Round(xd1 + xd2 + xd3 + xd4, 2, MidpointRounding.AwayFromZero)
        Me.MN_DSC2.Text = String.Format("{0:#0.00}", descuento)

        xexe = Decimal.Round(xexe - (xexe * MN_DSC1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        xmn1 = Decimal.Round(xmn1 - (xmn1 * MN_DSC1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        xmn2 = Decimal.Round(xmn2 - (xmn2 * MN_DSC1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        xmn3 = Decimal.Round(xmn3 - (xmn3 * MN_DSC1._Valor / 100), 2, MidpointRounding.AwayFromZero)

        xc1 = Decimal.Round((xexe * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        xc2 = Decimal.Round((xmn1 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        xc3 = Decimal.Round((xmn2 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        xc4 = Decimal.Round((xmn3 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        cargo = Decimal.Round(xc1 + xc2 + xc3 + xc4, 2, MidpointRounding.AwayFromZero)
        Me.MN_CARGO2.Text = String.Format("{0:#0.00}", cargo)

        xexe = Decimal.Round(xexe + (xexe * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        xmn1 = Decimal.Round(xmn1 + (xmn1 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        xmn2 = Decimal.Round(xmn2 + (xmn2 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        xmn3 = Decimal.Round(xmn3 + (xmn3 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)

        xsubt = Decimal.Round(xexe + xmn1 + xmn2 + xmn3, 2, MidpointRounding.AwayFromZero)

        xiv1 = Decimal.Round(xmn1 * _MisTotales._Tasa1 / 100, 2, MidpointRounding.AwayFromZero)
        xiv2 = Decimal.Round(xmn2 * _MisTotales._Tasa2 / 100, 2, MidpointRounding.AwayFromZero)
        xiv3 = Decimal.Round(xmn3 * _MisTotales._Tasa3 / 100, 2, MidpointRounding.AwayFromZero)
        xiva = Decimal.Round(xiv1 + xiv2 + xiv3, 2, MidpointRounding.AwayFromZero)

        xtotal = Decimal.Round(xsubt + xiva, 2, MidpointRounding.AwayFromZero)

        Me.E_SUB_2.Text = String.Format("{0:#0.00}", xsubt)
        Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", xiva)
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", xtotal)

        If _ActivarCargosDescuentos Then
            Dim xt As Decimal = 0
            If _TotalGeneral_DocOrigen = xtotal Then
                xt = xtotal
                _AjusteGlobal = False
            Else
                _AjusteGlobal = True
                xt = Decimal.Round(_TotalGeneral_DocOrigen - xtotal, 2, MidpointRounding.AwayFromZero)
            End If
            Me.E_TOTAL_MOVIMIENTO.Text = String.Format("{0:#0.00}", xt)
        Else
            Me.E_TOTAL_MOVIMIENTO.Text = String.Format("{0:#0.00}", xtotal)
        End If
    End Sub

    Sub Inicializa()
        Try
            _EstatusSalida = False
            LimpiarPantalla()
            Me.E_TITULO_1.Text = _Plantilla._TituloVentana
            Me.E_TITULO_2.Text = _Plantilla._TituloMonto

            With MN_DSC1
                ._ConSigno = False
                ._Formato = "99.99"
                .Text = "0.0"
                .Enabled = False
            End With
            With MN_DSC2
                ._ConSigno = False
                ._Formato = "9999999.99"
                .Text = "0.0"
                .Enabled = False
            End With
            With MN_CARGO1
                ._ConSigno = False
                ._Formato = "99.99"
                .Text = "0.0"
                .Enabled = False
            End With
            With MN_CARGO2
                ._ConSigno = False
                ._Formato = "9999999.99"
                .Text = "0.0"
                .Enabled = False
            End With

            With MT_NOTAS
                .Text = ""
                .MaxLength = 120
            End With

            ActualizaPlantilla()
            Me.MN_DSC1.Text = String.Format("{0:#0.00}", _MisTotales._FichaRegistroVentas._TasaDescuento_1)
            ReCalcular(1)
            Me.MN_CARGO1.Text = String.Format("{0:#0.00}", _MisTotales._FichaRegistroVentas._TasaCargos)
            ReCalcular(1)

            If _ActivarCargosDescuentos Then
                Me.MN_DSC1.Select()
                Me.MN_DSC1.Focus()
            Else
                Me.MT_NOTAS.Select()
                Me.MT_NOTAS.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub ProcesarDoc_NC_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _EstatusSalida = False Then
            If MessageBox.Show("Estas Seguro De Salir y Cerrar Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub ProcesarDoc_NC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ProcesarDoc_NC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub MN_DSC1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DSC1.LostFocus, MN_CARGO1.LostFocus
        ReCalcular(1)
    End Sub

    Private Sub MN_DSC2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DSC2.LostFocus, MN_CARGO2.LostFocus
        ReCalcular(2)
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If Me.MT_NOTAS.r_Valor <> "" Then
            Dim xtot As Decimal = 0
            Decimal.TryParse(Me.E_TOTAL.Text, xtot)

            If _Plantilla._Procesar(_TotalGeneral_DocOrigen, xtot) Then
                _EstatusSalida = True
                _MisTotales._NotasDetalles = Me.MT_NOTAS.r_Valor
                Me.Close()
            End If
        Else
            MessageBox.Show("Debes Indicar Un Detalle General Del Movimiento A Efectuar !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.MT_NOTAS.Select()
        End If
    End Sub

    Private Sub ProcesarDoc_NC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class

Public Interface ITipoNCND
    ReadOnly Property _TituloVentana() As String
    ReadOnly Property _TituloMonto() As String

    Function _Procesar(ByVal xtotal_origen As Decimal, ByVal xtotal As Decimal) As Boolean
End Interface

Public Class TipoDocumentoNC
    Implements ITipoNCND

    Public ReadOnly Property _TituloVentana() As String Implements ITipoNCND._TituloVentana
        Get
            Return "Procesar Nota Credito"
        End Get
    End Property

    Public ReadOnly Property _TituloMonto() As String Implements ITipoNCND._TituloMonto
        Get
            Return "Monto Total Nota Credito:"
        End Get
    End Property

    Public Function _Procesar(ByVal xtotal_origen As Decimal, ByVal xtotal As Decimal) As Boolean Implements ITipoNCND._Procesar
        If xtotal_origen >= xtotal Then
            If MessageBox.Show("Estas De Acuerdo En Procesar Dicho Documento ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Return True
            End If
        Else
            MessageBox.Show("Error Al Procesar Documento... Monto Total Nota De Credito Es Incorrecto, Verifique Port Favor !!!", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function
End Class