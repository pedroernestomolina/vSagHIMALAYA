Imports DataSistema.MiDataSistema.DataSistema

Public Class ModificarItem
    Event ActualizarTabla()

    Dim xitem As String
    Dim xtemporal As FichaVentas.V_TemporalVenta
    Dim PRECIO_ACTUAL As Decimal
    Dim DESCUENTO_ACTUAL As Decimal

    Property _FichaTemporal() As FichaVentas.V_TemporalVenta
        Get
            Return xtemporal
        End Get
        Set(ByVal value As FichaVentas.V_TemporalVenta)
            xtemporal = value
        End Set
    End Property

    Property _AutoItem() As String
        Get
            Return xitem
        End Get
        Set(ByVal value As String)
            xitem = value
        End Set
    End Property

    Sub New(ByVal xautoitem As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _AutoItem = xautoitem
    End Sub

    Private Sub ModificarItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.F1 Then
            VerCostoUtilidad(_FichaTemporal.RegistroDato._AutoItem)
        End If
    End Sub

    Private Sub ModificarItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ModificarItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub ModificarItem_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
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
            ._Formato = "99999999.99"
            ._ConSigno = False
        End With
    End Sub

    Sub CargarData()
        Dim xformato As String = "99999.999"
        Dim xformato2 As String = "{0:#0.000"

        Me.E_NOMBRE.Text = _FichaTemporal.RegistroDato._NombreProducto
        Me.E_EMPAQUE_NOMBRE.Text = _FichaTemporal.RegistroDato._NombreEmpaque
        Me.E_CODIGO.Text = _FichaTemporal.RegistroDato._CodigoProducto
        Me.E_EMPAQUE_CONTENIDO.Text = _FichaTemporal.RegistroDato._ContenidoEmpaque.ToString
        Me.E_IVA.Text = String.Format("{0:#0.00}", _FichaTemporal.RegistroDato._TasaIva)
        Me.E_PLIQUIDA.Text = String.Format("{0:#0.00}", _FichaTemporal.RegistroDato._PLiquidaFullIva)
        Me.E_PSUGERIDO.Text = String.Format("{0:#0.00}", _FichaTemporal.RegistroDato._PSugerido)
        Me.E_IMPORTE.Text = String.Format("{0:#0.00}", _FichaTemporal.RegistroDato._Importe)

        Me.MN_CANTIDAD.Text = String.Format("{0:#0.00}", _FichaTemporal.RegistroDato._CantidadDespachar)
        Me.MN_DESCUENTO.Text = String.Format("{0:#0.00}", _FichaTemporal.RegistroDato._Descuento)
        Me.MN_PRECIO.Text = String.Format("{0:#0.00}", _FichaTemporal.RegistroDato._PrecioNeto)

        Dim xdec As Integer = 0
        xdec = _FichaTemporal.RegistroDato._NumeroDecimalesMedida
        If xdec > 0 Then
            xdec += 1
        End If

        Me.MN_CANTIDAD._Formato = xformato.Substring(0, 5 + xdec)
        Me.MN_CANTIDAD.Text = String.Format(xformato2.Substring(0, 5 + xdec) + "}", Me.MN_CANTIDAD._Valor)

        Me.MN_CANTIDAD.Focus()
        Me.MN_CANTIDAD.Select()

        Me.PRECIO_ACTUAL = Me.MN_PRECIO._Valor
        Me.DESCUENTO_ACTUAL = Me.MN_DESCUENTO._Valor
    End Sub

    Sub Inicializa()
        Try
            Limpiar()
            _FichaTemporal = New FichaVentas.V_TemporalVenta
            AddHandler _FichaTemporal.ActualizarTabla, AddressOf CapturarEvento

            _FichaTemporal.F_BuscarRegistro(_AutoItem)
            CargarData()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
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
            x2 = Decimal.Round(x2, 2, MidpointRounding.AwayFromZero)

            'ximp = Decimal.Round(x1 - x2, 2, MidpointRounding.AwayFromZero)
            ximp = (x1 - x2)

            Dim xiva As Decimal = 0.0
            xiva = ximp * _FichaTemporal.RegistroDato._TasaIva / 100
            xiva = Decimal.Round(xiva, 2, MidpointRounding.AwayFromZero)

            xful = ximp + xiva
            xful = Decimal.Round(xful, 2, MidpointRounding.AwayFromZero)

            xliq = xful / Me.MN_CANTIDAD._Valor / _FichaTemporal.RegistroDato._ContenidoEmpaque

            Me.E_IMPORTE.Text = String.Format("{0:#0.00}", ximp)
            Me.E_PLIQUIDA.Text = String.Format("{0:#0.00}", xliq)
        End If
    End Sub

    Private Sub MN_CANTIDAD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_CANTIDAD.LostFocus, _
                MN_DESCUENTO.LostFocus
        Try
            If Me.DESCUENTO_ACTUAL <> Me.MN_DESCUENTO._Valor Then
                If g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_DarDescuento_Item.r_PermitirOpcion Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_DarDescuento_Item.F_Permitir()
                    Me.DESCUENTO_ACTUAL = Me.MN_DESCUENTO._Valor
                Else
                    Throw New Exception("NO TIENES PERMISO DE PODER ASIGNAR UN DESCUENTO AL ARTICULO")
                End If
            End If
        Catch ex As Exception
            Me.MN_DESCUENTO.Text = String.Format("{0:#0.00}", Me.DESCUENTO_ACTUAL)
            Me.FindForm.SelectNextControl(sender, True, True, True, True)
            Funciones.MensajeDeError(ex.Message)
        Finally
            CalculaImporte()
        End Try
    End Sub

    Private Sub MN_PRECIO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_PRECIO.LostFocus
        Try
            Dim xprecio As Decimal = 0
            If Me.MCHB_2.Checked Then
                Dim xpv As New Precio(Me.MN_PRECIO._Valor, _FichaTemporal.RegistroDato._TasaIva, Precio.TipoFuncion.Desglozar)
                xprecio = xpv._Base
            Else
                xprecio = Me.MN_PRECIO._Valor
            End If

            If Me.PRECIO_ACTUAL <> Me.MN_PRECIO._Valor Then
                If g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_PrecioLibre.r_PermitirOpcion Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_PrecioLibre.F_Permitir()
                    Me.PRECIO_ACTUAL = xprecio
                    Me.MN_PRECIO.Text = String.Format("{0:#0.00}", Me.PRECIO_ACTUAL)
                    Me.MCHB_2.Checked = False
                Else
                    Throw New Exception("NO TIENES PERMISO DE PODER CAMBIAR EL PRECIO DE VEBNTA ")
                End If
            End If
        Catch ex As Exception
            Me.MN_PRECIO.Text = String.Format("{0:#0.00}", Me.PRECIO_ACTUAL)
            Me.MCHB_2.Checked = False
            Me.FindForm.SelectNextControl(sender, True, True, True, True)
            Funciones.MensajeDeError(ex.Message)
        Finally
            CalculaImporte()
        End Try
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        Try
            If Me.MN_CANTIDAD._Valor > 0 Then
                If MessageBox.Show("Estas Seguro De Actualizar Este Item ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim xerror As Boolean = False

                    If _FichaTemporal.RegistroDato._ForzarMedida Then
                        If (Me.MN_CANTIDAD._Valor - Int(Me.MN_CANTIDAD._Valor)) = 0 Or (Me.MN_CANTIDAD._Valor - Int(Me.MN_CANTIDAD._Valor)) = 0.5 Then
                        Else
                            Throw New Exception("Problema En Cantidad A Facturar, No Se Aceptan Cantidades Inexactas, Verifique Por Favor...")
                        End If
                    End If

                    If (_FichaTemporal.RegistroDato._f_FichaVentaDetalle_AutoItem_DocumentoOrigen IsNot Nothing) Then
                        If Me.MN_CANTIDAD._Valor > _FichaTemporal.RegistroDato._f_FichaVentaDetalle_AutoItem_DocumentoOrigen._CantidadDespachada AndAlso _
                        Me._FichaTemporal.RegistroDato._f_FichaVentaDetalle_AutoItem_DocumentoOrigen._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.NotaEntrega Then
                            Throw New Exception("Problema En Cantidad A Facturar, No Se Puede Aumentar La Cantidad A Facturar Por Ser Un Item Procesado Por Nota De Entrega, Verifique Por Favor...")
                        End If
                    End If

                    Dim xitem As New IItemProcesar.Item.c_Actualizar
                    With xitem
                        ._CostoVenta = _FichaTemporal.RegistroDato._CostoVenta
                        ._Cantidad = Me.MN_CANTIDAD._Valor
                        ._Descto = Me.MN_DESCUENTO._Valor
                        ._PrecioNeto = Me.MN_PRECIO._Valor
                    End With
                    If ProcesarItem(xitem) Then
                        Me.Close()
                    Else
                        Me.MN_CANTIDAD.Select()
                    End If
                Else
                    Me.MN_CANTIDAD.Select()
                End If
            Else
                Throw New Exception("Cantidad A Procesar No Puede Ser Cero (0), Verifique Por Favor...")
            End If
        Catch ex As Exception
            Funciones.MensajeDeAlerta(ex.Message)
            Me.MN_CANTIDAD.Select()
        End Try
    End Sub

    Public Function ProcesarItem(ByVal xitem As IItemProcesar.Item.c_Actualizar) As Boolean
        Try
            If xitem._RegEntrada._Precio = 0 Then
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Precio_En_Cero Then
                    Return Factura()
                Else
                    Throw New Exception("No Puedo Facturar Sin Un Precio Dado, Verifique Por Favor...")
                End If
            Else
                If xitem._RegEntrada._PrecioFinal < xitem._RegEntrada._CostoVenta Then
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Por_Debajo_Costo Then
                        Return Factura()
                    Else
                        Throw New Exception("No Puedo Facturar Con Un Precio Por Debajo Del Costo, Verifique Por Favor...")
                    End If
                Else
                    Return Factura()
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Return False
        End Try
    End Function

    Function Factura() As Boolean
        Try
            Dim xficha As New FichaVentas.V_TemporalVenta.ActualizarRegistroTemporalVenta
            With xficha
                ._Cantidad = Me.MN_CANTIDAD._Valor
                ._Descuento = Me.MN_DESCUENTO._Valor
                ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                ._FichaItemDetalleActualizar = Me._FichaTemporal.RegistroDato
                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
                ._PrecioNeto = Me.MN_PRECIO._Valor
            End With

            _FichaTemporal.F_ActualizarRegistro(xficha)
            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Return False
        End Try
    End Function

    Sub CapturarEvento()
        RaiseEvent ActualizarTabla()
        Funciones.MensajeDeAlerta("Item Actualizado Satisfactoriamente...")
    End Sub

    Private Sub MCHB_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_2.CheckedChanged
        Me.MN_PRECIO.Select()
        Me.MN_PRECIO.Focus()
    End Sub

    Private Sub E_NOMBRE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles E_NOMBRE.Click
        Dim xclas As New EntradaTexto_Venta(_FichaTemporal.RegistroDato._NombreProducto, 120)
        AddHandler xclas._TextoReemplazar, AddressOf ActualizarTexto

        Dim xficha As New EntradaTexto(xclas)
        With xficha
            .ShowDialog()
        End With
        Me.Close()
    End Sub

    Sub ActualizarTexto(ByVal xtexto As String)
        Try
            _FichaTemporal.F_ActualizarDescripcionItem(_FichaTemporal.RegistroDato._AutoItem, xtexto)
            Me.E_NOMBRE.Text = xtexto
        Catch ex As Exception
            Me.E_NOMBRE.Text = _FichaTemporal.RegistroDato._NombreProducto
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class