Imports DataSistema.MiDataSistema.DataSistema

Public Class ProductoOfertaPromocion
    Event _ActualizarFicha()

    Dim xfichaprd As FichaProducto.Prd_Producto.c_Registro
    Dim xcosto As Decimal
    Dim xmargen As Decimal
    Dim xutilidad As Decimal
    Dim xsalida As Boolean

    Property _SalidaOk() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
        Get
            Return xfichaprd
        End Get
        Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
            xfichaprd = value
        End Set
    End Property

    Private Sub ProductoOfertaPromocion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _SalidaOk Then
            e.Cancel = False
        Else
            If MessageBox.Show("Estas Seguro De Salir Sin Guardar Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
                Me.MF_INICIO.Select()
                Me.MF_INICIO.Focus()
            End If
        End If
    End Sub

    Private Sub ProductoOfertaPromocion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ProductoOfertaPromocion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ProductoOfertaPromocion_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()

        If _FichaProducto.f_VerificarOferta Then
            Me.MF_INICIO.Value = _FichaProducto._FechaInicioOferta
            Me.MF_FIN.Value = _FichaProducto._FechaCulminacionOferta
            Me.MN_PRECIO.Text = String.Format("{0:#0.00}", _FichaProducto._PrecioOferta._Full)

            xcosto = Decimal.Round(_FichaProducto._CostoCompra._Base_Inv * _FichaProducto._ContEmpqVentaDetal, 2, MidpointRounding.AwayFromZero)
            xmargen = _FichaProducto._PrecioOferta._Base - xcosto

            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                xutilidad = UtilidadBaseCosto(xcosto, xmargen)
            Else
                xutilidad = UtilidadBasePrecioVenta(_FichaProducto._PrecioOferta._Base, xmargen)
            End If

            Me.E_DIAS.Text = (DateDiff(DateInterval.Day, Me.MF_INICIO.Value, Me.MF_FIN.Value) + 1).ToString
            Me.E_PNETO.Text = String.Format("{0:#0.00}", _FichaProducto._PrecioOferta._Base)
            Me.E_UTILIDAD.Text = String.Format("{0:#0.00}", xutilidad)
            Me.E_MARGEN.Text = String.Format("{0:#0.00}", xmargen)
        End If
    End Sub

    Sub Inicializa()
        Me.E_DIAS.Text = "0"
        Me.E_MARGEN.Text = "0.0"
        Me.E_PNETO.Text = "0.0"
        Me.E_UTILIDAD.Text = "0.0"

        Me.MF_INICIO.Value = Date.Now
        Me.MF_FIN.Value = Date.Now

        With Me.MN_PRECIO
            .Text = "0.0"
            ._Formato = "999999999.99"
            ._ConSigno = False
        End With

        Me.MF_INICIO.Select()
        Me.MF_INICIO.Focus()
    End Sub

    Sub New(ByVal xprd As FichaProducto.Prd_Producto.c_Registro)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _FichaProducto = xprd

        Me.xcosto = 0
        Me.xmargen = 0
        Me.xutilidad = 0
        Me.xsalida = False
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If Me.MF_FIN.Value >= Me.MF_INICIO.Value Then
            If xmargen > 0 Then

                If Me.MN_PRECIO._Valor < _FichaProducto._PrecioDetal._Full Then
                    If MessageBox.Show("Deseas Activar Esta Promocion A Este Producto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        GuardarOferta()
                    Else
                        Me.MF_INICIO.Select()
                        Me.MF_INICIO.Focus()
                    End If
                Else
                    MessageBox.Show("Error En Precio De Promocion Del Producto... Precio Debe Ser Menor Al Precio Detal", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MF_INICIO.Select()
                    Me.MF_INICIO.Focus()
                End If
            Else
                MessageBox.Show("Error En Precio De Promocion Del Producto... Precio Por Debajo Del Costo", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MF_INICIO.Select()
                Me.MF_INICIO.Focus()
            End If
        Else
            MessageBox.Show("Error... Rango De Fechas Incorrecto, Verifique", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MF_INICIO.Select()
            Me.MF_INICIO.Focus()
        End If
    End Sub

    Private Sub MN_PRECIO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_PRECIO.LostFocus
        If Me.MN_PRECIO._Valor >= 0 Then
            Dim xp As New Precio(Me.MN_PRECIO._Valor, _FichaProducto._TasaImpuesto, Precio.TipoFuncion.Desglozar)

            xcosto = Decimal.Round(_FichaProducto._CostoCompra._Base_Inv * _FichaProducto._ContEmpqVentaDetal, 2, MidpointRounding.AwayFromZero)
            xmargen = xp._Base - xcosto

            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                xutilidad = UtilidadBaseCosto(xcosto, xmargen)
            Else
                xutilidad = UtilidadBasePrecioVenta(xp._Base, xmargen)
            End If

            Me.E_PNETO.Text = String.Format("{0:#0.00}", xp._Base)
            Me.E_UTILIDAD.Text = String.Format("{0:#0.00}", xutilidad)
            Me.E_MARGEN.Text = String.Format("{0:#0.00}", xmargen)
        End If
    End Sub

    Private Sub MF_INICIO_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_INICIO.ValueChanged
        Me.MF_FIN.Value = Me.MF_INICIO.Value
        Me.E_DIAS.Text = (DateDiff(DateInterval.Day, Me.MF_INICIO.Value, Me.MF_FIN.Value) + 1).ToString
    End Sub

    Private Sub MF_FIN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_FIN.ValueChanged
        If MF_FIN.Value < MF_INICIO.Value Then
            MF_FIN.Value = MF_INICIO.Value
        End If
        Me.E_DIAS.Text = (DateDiff(DateInterval.Day, Me.MF_INICIO.Value, Me.MF_FIN.Value) + 1).ToString
    End Sub

    Sub GuardarOferta()
        Try
            Dim xprd As New FichaProducto.Prd_Producto
            Dim xprecios As New FichaProducto.Prd_Producto.c_ProductoOferta

            With xprecios
                ._AutoProducto = _FichaProducto._AutoProducto
                ._FinOferta = Me.MF_FIN.Value
                ._IdSeguridadProducto = _FichaProducto._IdSeguridad
                ._InicioOferta = Me.MF_INICIO.Value
                ._PrecioOferta = Me.MN_PRECIO._Valor
                ._UtilidadOferta = xutilidad
                ._Fecha = g_MiData.p_FechaDelMotorBD
            End With

            xprd.F_ActualizarActivarOferta(xprecios)
            RaiseEvent _ActualizarFicha()
            MessageBox.Show("Oferta / Promocion Efectuada Con  Exito... Ok", "*** Mensaje De Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _SalidaOk = True
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MF_INICIO.Select()
            Me.MF_INICIO.Focus()
        End Try
    End Sub
End Class