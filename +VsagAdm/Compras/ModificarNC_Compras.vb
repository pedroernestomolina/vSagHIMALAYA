Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports System.Data.SqlClient

Public Class ModificarNC_Compras
    Dim xregistro As FichaCompras.c_ComprasDetalle.c_Registro
    Dim xestatus_salida As Boolean
    Dim xcantidad As Decimal
    Dim xcosto As Decimal
    Dim xdescto As Decimal
    Dim xdescto1 As Decimal
    Dim xdescto2 As Decimal
    Dim xdescto3 As Decimal
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

    Property _Costo_NC() As Decimal
        Get
            Return xcosto
        End Get
        Set(ByVal value As Decimal)
            xcosto = value
        End Set
    End Property


    Property _DescuentoTotal_NC() As Decimal
        Get
            Return xdescto
        End Get
        Set(ByVal value As Decimal)
            xdescto = value
        End Set
    End Property

    Property _Descuento1_NC() As Decimal
        Get
            Return xdescto1
        End Get
        Set(ByVal value As Decimal)
            xdescto1 = value
        End Set
    End Property

    Property _Descuento2_NC() As Decimal
        Get
            Return xdescto2
        End Get
        Set(ByVal value As Decimal)
            xdescto2 = value
        End Set
    End Property

    Property _Descuento3_NC() As Decimal
        Get
            Return xdescto3
        End Get
        Set(ByVal value As Decimal)
            xdescto3 = value
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

    Property _DetalleRegistro() As FichaCompras.c_ComprasDetalle.c_Registro
        Get
            Return xregistro
        End Get
        Set(ByVal value As FichaCompras.c_ComprasDetalle.c_Registro)
            xregistro = value
        End Set
    End Property

    Sub New(ByVal xreg As FichaCompras.c_ComprasDetalle.c_Registro)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _DetalleRegistro = xreg

        _EstatusSalida = False
        _Cantidad_NC = 0
        _DescuentoTotal_NC = 0
        _Descuento1_NC = 0
        _Descuento2_NC = 0
        _Descuento3_NC = 0
        _Costo_NC = 0
    End Sub

    Private Sub ModificarItem_NC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
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
        Me.E_PSUGERIDO.Text = "0.0"

        Me.MT_DETALLE.Text = ""

        With Me.MN_CANTIDAD
            ._Formato = "99999.99"
            ._ConSigno = False
        End With
        With Me.MN_DESCUENTO1
            ._Formato = "99.99"
            ._ConSigno = False
        End With
        With Me.MN_DESCUENTO2
            ._Formato = "99.99"
            ._ConSigno = False
        End With
        With Me.MN_DESCUENTO3
            ._Formato = "99.99"
            ._ConSigno = False
        End With
        With Me.MN_COSTO
            ._Formato = "9999999.99"
            ._ConSigno = False
        End With
    End Sub

    Sub CargarData()
        Dim xformato As String = "99999.999"
        Dim xformato2 As String = "{0:#0.000"

        Dim xp1 As SqlParameter = New SqlParameter("@AUTO", _DetalleRegistro._AutoProducto)
        Dim xpsv As Decimal = F_GetDecimal("SELECT PSV FROM PRODUCTOS WHERE AUTO=@AUTO", xp1)
        Me.E_NOMBRE.Text = _DetalleRegistro._NombreProducto
        Me.E_EMPAQUE_NOMBRE.Text = _DetalleRegistro._Empaque
        Me.E_CODIGO.Text = _DetalleRegistro._CodigoProducto
        Me.E_EMPAQUE_CONTENIDO.Text = _DetalleRegistro._ContenidoEmpaque.ToString
        Me.E_IVA.Text = String.Format("{0:#0.00}", _DetalleRegistro._TasaIva)
        Me.E_PSUGERIDO.Text = String.Format("{0:#0.00}", xpsv)
        Me.E_IMPORTE.Text = String.Format("{0:#0.00}", _DetalleRegistro._TotalNeto)

        Me.MN_CANTIDAD.Text = String.Format("{0:#0.00}", _DetalleRegistro._CantidadCompra)
        Me.MN_DESCUENTO1.Text = String.Format("{0:#0.00}", _DetalleRegistro._Descuento1._Tasa)
        Me.MN_DESCUENTO2.Text = String.Format("{0:#0.00}", _DetalleRegistro._Descuento2._Tasa)
        Me.MN_DESCUENTO3.Text = String.Format("{0:#0.00}", _DetalleRegistro._Descuento3._Tasa)
        Me.MN_COSTO.Text = String.Format("{0:#0.00}", _DetalleRegistro._CostoBruto)

        Dim xdec As Integer = 0
        xdec = _DetalleRegistro._CantidadDecimales
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

        If Me.MN_CANTIDAD._Valor > 0 Then
            Dim ximp1 As Decimal = 0
            Dim ximp2 As Decimal = 0
            Dim ximp3 As Decimal = 0
            Dim ximp4 As Decimal = 0

            Dim xdes1 As Decimal = 0
            Dim xdes2 As Decimal = 0
            Dim xdes3 As Decimal = 0
            Dim xdes4 As Decimal = 0

            ximp1 = Me.MN_CANTIDAD._Valor * Me.MN_COSTO._Valor
            ximp2 = ximp1 - ximp1 * Me.MN_DESCUENTO1._Valor / 100
            ximp3 = ximp2 - ximp2 * Me.MN_DESCUENTO2._Valor / 100
            ximp4 = ximp3 - ximp3 * Me.MN_DESCUENTO3._Valor / 100

            ximp = Decimal.Round(ximp4, 2, MidpointRounding.AwayFromZero)

            xdes1 = ximp1 * Me.MN_DESCUENTO1._Valor / 100
            xdes2 = ximp2 * Me.MN_DESCUENTO2._Valor / 100
            xdes3 = ximp3 * Me.MN_DESCUENTO3._Valor / 100
            xdes4 = xdes1 + xdes2 + xdes3

            _DescuentoTotal_NC = Decimal.Round(xdes4, 2, MidpointRounding.AwayFromZero)

            Me.E_IMPORTE.Text = String.Format("{0:#0.00}", ximp)
        End If
    End Sub

    Private Sub MN_CANTIDAD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_CANTIDAD.LostFocus, _
                MN_DESCUENTO1.LostFocus, MN_DESCUENTO2.LostFocus, MN_DESCUENTO3.LostFocus, MN_COSTO.LostFocus
        CalculaImporte()
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        If Me.MT_DETALLE.r_Valor <> "" Then
            If Me.MN_CANTIDAD._Valor > 0 And Me.MN_CANTIDAD._Valor <= _DetalleRegistro._CantidadCompra Then
                If Me.MN_COSTO._Valor >= 0 And Me.MN_COSTO._Valor <= _DetalleRegistro._CostoBruto Then
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
                                Me._Descuento1_NC = Me.MN_DESCUENTO1._Valor
                                Me._Descuento2_NC = Me.MN_DESCUENTO2._Valor
                                Me._Descuento3_NC = Me.MN_DESCUENTO3._Valor
                                Me._Costo_NC = Me.MN_COSTO._Valor
                                Me._Importe_NC = ximporte
                                Me._Detalle_NC = Me.MT_DETALLE.r_Valor

                                If _DetalleRegistro._CostoBruto <> Me.MN_COSTO._Valor Or _DetalleRegistro._Descuento1._Tasa <> Me.MN_DESCUENTO1._Valor Or _DetalleRegistro._Descuento2._Tasa <> Me.MN_DESCUENTO2._Valor Or _DetalleRegistro._Descuento3._Tasa <> Me.MN_DESCUENTO3._Valor Then
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
                    MessageBox.Show("Costo A Procesar Incorrecto, Verifique Por Favor !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MN_COSTO.Select()
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