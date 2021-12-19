Imports DataSistema.MiDataSistema.DataSistema

Public Class ModificarItem_NC
    Dim xregistro As FichaVentas.V_VentasDetalle.c_Registro
    Dim xestatus_salida As Boolean
    Dim xcantidad As Decimal
    Dim xprecio As Decimal
    Dim xdescto As Decimal
    Dim ximport As Decimal
    Dim xdetall As String
    Dim xtipo As String

    Property _Cantidad_NC() As Decimal
        Get
            Return xcantidad
        End Get
        Set(ByVal value As Decimal)
            xcantidad = value
        End Set
    End Property

    Property _Precio_NC() As Decimal
        Get
            Return xprecio
        End Get
        Set(ByVal value As Decimal)
            xprecio = value
        End Set
    End Property

    Property _Descuento_NC() As Decimal
        Get
            Return xdescto
        End Get
        Set(ByVal value As Decimal)
            xdescto = value
        End Set
    End Property

    Property _Importe_NC() As Decimal
        Get
            Return ximport
        End Get
        Set(ByVal value As Decimal)
            ximport = value
        End Set
    End Property

    Property _Detalle_NC() As String
        Get
            Return xdetall
        End Get
        Set(ByVal value As String)
            xdetall = value
        End Set
    End Property

    Property _Tipo_NC() As String
        Get
            Return xtipo
        End Get
        Set(ByVal value As String)
            xtipo = value
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

    Property _DetalleRegistro() As FichaVentas.V_VentasDetalle.c_Registro
        Get
            Return xregistro
        End Get
        Set(ByVal value As FichaVentas.V_VentasDetalle.c_Registro)
            xregistro = value
        End Set
    End Property

    Sub New(ByVal xreg As FichaVentas.V_VentasDetalle.c_Registro)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _DetalleRegistro = xreg
        _EstatusSalida = False
        _Cantidad_NC = 0
        _Descuento_NC = 0
        _Precio_NC = 0
    End Sub

    Private Sub ModificarItem_NC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ModificarItem_NC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ModificarItem_NC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            Limpiar()
            CargarData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub Limpiar()
        Me.E_CODIGO.Text = ""
        Me.E_EMPAQUE_NOMBRE.Text = ""
        Me.E_NOMBRE.Text = ""
        Me.E_EMPAQUE_CONTENIDO.Text = "0.0"
        Me.E_IMPORTE.Text = "0.0"
        Me.E_IVA.Text = "0.0"
        Me.E_PLIQUIDA.Text = "0.0"
        Me.E_PSUGERIDO.Text = "0.0"

        With Me.MN_CANTIDAD
            ._Formato = "99999.99"
            ._ConSigno = False
        End With
        With Me.MN_DESCUENTO
            ._Formato = "99.99"
            ._ConSigno = False
        End With
        With Me.MN_PRECIO
            ._Formato = "9999999.99"
            ._ConSigno = False
        End With
    End Sub

    Sub CargarData()
        Dim xformato As String = "99999.999"
        Dim xformato2 As String = "{0:#0.000"

        Me.E_NOMBRE.Text = _DetalleRegistro._NombreProducto
        Me.E_EMPAQUE_NOMBRE.Text = _DetalleRegistro._NombreEmpaque
        Me.E_CODIGO.Text = _DetalleRegistro._CodigoProducto
        Me.E_EMPAQUE_CONTENIDO.Text = _DetalleRegistro._ContenidoEmpaque.ToString
        Me.E_IVA.Text = String.Format("{0:#0.00}", _DetalleRegistro._TasaIva)
        Me.E_PLIQUIDA.Text = String.Format("{0:#0.00}", _DetalleRegistro._PrecioLiquida)
        Me.E_PSUGERIDO.Text = String.Format("{0:#0.00}", _DetalleRegistro._PrecioSugerido)
        Me.E_IMPORTE.Text = String.Format("{0:#0.00}", _DetalleRegistro._TotalNeto)

        Me.MN_CANTIDAD.Text = String.Format("{0:#0.00}", _DetalleRegistro._CantidadDespachada)
        Me.MN_DESCUENTO.Text = String.Format("{0:#0.00}", _DetalleRegistro._Tasa_Descuento1)
        Me.MN_PRECIO.Text = String.Format("{0:#0.00}", _DetalleRegistro._PrecioNeto)

        Dim xdec As Integer = 0
        xdec = _DetalleRegistro._NumeroDecimales
        If xdec > 0 Then
            xdec += 1
        End If

        Me.MN_CANTIDAD._Formato = xformato.Substring(0, 5 + xdec)
        Me.MN_CANTIDAD.Text = String.Format(xformato2.Substring(0, 5 + xdec) + "}", Me.MN_CANTIDAD._Valor)

        Me.MN_CANTIDAD.Focus()
        Me.MN_CANTIDAD.Select()
    End Sub

    Sub CalculaImporte()
        Dim ximp As Decimal = 0
        Dim xful As Decimal = 0
        Dim xliq As Decimal = 0

        If Me.MN_CANTIDAD._Valor > 0 Then
            Dim x1 As Decimal = 0
            Dim x2 As Decimal = 0
            x1 = Me.MN_CANTIDAD._Valor * Me.MN_PRECIO._Valor
            x2 = x1 * Me.MN_DESCUENTO._Valor / 100
            ximp = Decimal.Round(x1 - x2, 2, MidpointRounding.AwayFromZero)

            xful = ximp + (ximp * _DetalleRegistro._TasaIva / 100)
            xful = Decimal.Round(xful, 2, MidpointRounding.AwayFromZero)

            xliq = xful / Me.MN_CANTIDAD._Valor / _DetalleRegistro._ContenidoEmpaque

            Me.E_IMPORTE.Text = String.Format("{0:#0.00}", ximp)
            Me.E_PLIQUIDA.Text = String.Format("{0:#0.00}", xliq)
        End If
    End Sub

    Private Sub MN_CANTIDAD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_CANTIDAD.LostFocus, _
                MN_DESCUENTO.LostFocus, MN_PRECIO.LostFocus
        CalculaImporte()
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        If Me.MT_DETALLE.r_Valor <> "" Then
            If Me.MN_CANTIDAD._Valor > 0 And Me.MN_CANTIDAD._Valor <= _DetalleRegistro._CantidadDespachada Then
                If Me.MN_PRECIO._Valor >= 0 And Me.MN_PRECIO._Valor <= _DetalleRegistro._PrecioNeto Then
                    If MessageBox.Show("Estas Seguro De Actualizar Este Item ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                        Dim ximporte As Decimal = 0
                        Decimal.TryParse(Me.E_IMPORTE.Text, ximporte)
                        If ximporte > _DetalleRegistro._TotalNeto Then
                            MessageBox.Show("Registro A Procesar Incorrecto, Verifique Por Favor !!!" + vbCrLf + "El Monto Importe Debe Ser Menor Al Monto Original Facturado.", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.MN_CANTIDAD.Select()
                        Else

                            Dim xerror As Boolean = False

                            If _DetalleRegistro._ForzarMedida Then
                                If (Me.MN_CANTIDAD._Valor - Int(Me.MN_CANTIDAD._Valor)) = 0 Or (Me.MN_CANTIDAD._Valor - Int(Me.MN_CANTIDAD._Valor)) = 0.5 Then
                                Else
                                    xerror = True
                                End If
                            End If

                            If xerror = False Then
                                Me._Cantidad_NC = Me.MN_CANTIDAD._Valor
                                Me._Descuento_NC = Me.MN_DESCUENTO._Valor
                                Me._Precio_NC = Me.MN_PRECIO._Valor
                                Me._Importe_NC = ximporte
                                Me._Detalle_NC = Me.MT_DETALLE.r_Valor

                                If _DetalleRegistro._PrecioNeto <> Me.MN_PRECIO._Valor Or _DetalleRegistro._Tasa_Descuento1 <> Me.MN_DESCUENTO._Valor Then
                                    Me._Tipo_NC = "A"
                                Else
                                    Me._Tipo_NC = "D"
                                End If
                                _EstatusSalida = True
                                Me.Close()
                            Else
                                MessageBox.Show("Error En Cantidad A Facturar, No Se Aceptan Cantidades Inexactas, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.MN_CANTIDAD.Select()
                            End If

                        End If
                    End If
                Else
                    MessageBox.Show("Precio A Procesar Incorrecto, Verifique Por Favor !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MN_PRECIO.Select()
                End If
            Else
                MessageBox.Show("Cantidad A Procesar Incorrecta, Verifique Por Favor !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MN_CANTIDAD.Select()
            End If
        Else
            MessageBox.Show("Debes Indicar Un Detalle Del Movimiento A Efectuar, Verifique Por Favor !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_DETALLE.Select()
        End If
    End Sub
End Class