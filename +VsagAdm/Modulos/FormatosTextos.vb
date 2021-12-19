Imports ImpresoraMatriz.ImpresoraMatriz
Imports DataSistema.MiDataSistema.DataSistema
Imports System.Text

Module FormatosTextos

    'FORMATO VENTA CHIMBO
    Sub FormatoXX_COPIA(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._DirFiscalCliente, 63) + Space(3) + Chr(27) + "W1" + "COPIA" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .Rayado()
                .TextoImprimir("CANT     EMPAQ     DESCRIPCION          P/SUG  UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreEmpaque, 7)
                    xt += Space(2)
                    xt += Chr(15) + .Porcion(xventadetalle._NombreProducto, 32) + Chr(18)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioSugerido, 4, 1)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()

                        .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._DirFiscalCliente, 63) + Space(3) + Chr(27) + "W1" + "COPIA" + Chr(27) + "W0"
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        .Rayado()
                        .TextoImprimir("CANT     EMPAQ     DESCRIPCION          P/SUG  UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()
                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Credito Then
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0) + Space(5) + "Condicion Pago: Credito " + xventa._DiasCreditoOtorgado.ToString.Trim + " Dias"
                Else
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatoXX_COPIA_MODELO_2(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._DirFiscalCliente, 63) + Space(3) + Chr(27) + "W1" + "COPIA" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .Rayado()
                .TextoImprimir("CANT     EMPAQ     DESCRIPCION          P/SUG  UNIDAD  P/UNIT           SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreEmpaque, 7)
                    xt += Space(2)
                    xt += Chr(15) + .Porcion(xventadetalle._NombreProducto, 32) + Chr(18)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioSugerido, 4, 1)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioItem_FullIva, 5, 2)
                    xt += Space(7)
                    xt += .Formato(xventadetalle._TotalGeneral, 5, 2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()

                        .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._DirFiscalCliente, 63) + Space(3) + Chr(27) + "W1" + "COPIA" + Chr(27) + "W0"
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        .Rayado()
                        .TextoImprimir("CANT     EMPAQ     DESCRIPCION          P/SUG  UNIDAD  P/UNIT           SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()
                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Credito Then
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0) + Space(5) + "Condicion Pago: Credito " + xventa._DiasCreditoOtorgado.ToString.Trim + " Dias"
                Else
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                'xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                '.TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                'xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                '.TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                'xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                '.TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatoXX_COPIA_MODELO_5(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "COPIA" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .Rayado()
                .TextoImprimir("CANT     DESCRIPCION                    P/SUG  UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += Chr(15) + .Porcion(xventadetalle._NombreProducto, 40) + Chr(18)
                    xt += Space(5)
                    xt += .Formato(xventadetalle._PrecioSugerido, 4, 1)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()

                        .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        .Rayado()
                        .TextoImprimir("CANT     DESCRIPCION                    P/SUG  UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()

                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Credito Then
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0) + Space(5) + "Condicion Pago: Credito " + xventa._DiasCreditoOtorgado.ToString.Trim + " Dias"
                Else
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'FORMATO FACTURA CHIMBO
    Sub FormatoXX_ORIGINAL(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .Rayado()
                .TextoImprimir("CANT     EMPAQ     DESCRIPCION          P/SUG  UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreEmpaque, 7)
                    xt += Space(2)
                    xt += Chr(15) + .Porcion(xventadetalle._NombreProducto, 32) + Chr(18)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioSugerido, 4, 1)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()

                        .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        .Rayado()
                        .TextoImprimir("CANT     EMPAQ     DESCRIPCION          P/SUG  UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()

                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Credito Then
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0) + Space(5) + "Condicion Pago: Credito " + xventa._DiasCreditoOtorgado.ToString.Trim + " Dias"
                Else
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'FORMATO FACTURA CHIMBO
    Sub FormatoXX_ORIGINAL_MODELO_2(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .Rayado()
                .TextoImprimir("CANT     EMPAQ     DESCRIPCION          P/SUG  UNIDAD  P/UNIT           SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreEmpaque, 7)
                    xt += Space(2)
                    xt += Chr(15) + .Porcion(xventadetalle._NombreProducto, 32) + Chr(18)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioSugerido, 4, 1)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioItem_FullIva, 5, 2)
                    xt += Space(7)
                    xt += .Formato(xventadetalle._TotalGeneral, 5, 2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()

                        .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        .Rayado()
                        .TextoImprimir("CANT     EMPAQ     DESCRIPCION          P/SUG  UNIDAD  P/UNIT           SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()

                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Credito Then
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0) + Space(5) + "Condicion Pago: Credito " + xventa._DiasCreditoOtorgado.ToString.Trim + " Dias"
                Else
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()
                'xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                '.TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                'xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                '.TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                'xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                '.TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'FORMATO FACTURA CHIMBO
    Sub FormatoXX_ORIGINAL_MODELO_3(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro
            Dim xpagina As Integer = 1

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente.PadRight(12, " ") + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(12) + "COND/PAGO: " + xventa._CondicionPago.ToString
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = Chr(15) + .Porcion(xventa._NombreCliente, 75) + Chr(18) + Space(8) + "F/Venc: " + xventa._FechaVencimiento.ToShortDateString
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                xt = Chr(15) + .Porcion(xventa._DirFiscalCliente, 75) + Chr(18) + Space(8) + "Vended: " + Chr(15) + .Porcion(xventa._NombreVendedor, 30) + Chr(18)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                xt = Chr(15) + .Porcion(xventa._DirFiscalCliente, 75, 2) + Chr(18) + Space(8) + "Telf: " + Chr(15) + xventa._f_FichaVendedor.r_Telefono_1.PadRight(15, " ") + Chr(18)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                xt = "Telefono: " + xventa._TelefonoCliente.PadRight(15, " ") + Space(27) + "Pag/No: " + xpagina.ToString.Trim
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                .LineaBlanco()
                .Rayado()
                .TextoImprimir("CANT     EMPAQ     DESCRIPCION          P/SUG  UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreEmpaque, 7)
                    xt += Space(2)
                    xt += Chr(15) + .Porcion(xventadetalle._NombreProducto, 32) + Chr(18)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioSugerido, 4, 1)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()
                        xpagina += 1

                        .LineaBlanco()
                        .LineaBlanco()
                        .LineaBlanco()
                        .LineaBlanco()
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente.PadRight(12, " ") + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(12) + "COND/PAGO: " + xventa._CondicionPago.ToString
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = Chr(15) + .Porcion(xventa._NombreCliente, 75) + Chr(18) + Space(8) + "F/Venc: " + xventa._FechaVencimiento.ToShortDateString
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                        xt = Chr(15) + .Porcion(xventa._DirFiscalCliente, 75) + Chr(18) + Space(8) + "Vended: " + Chr(15) + .Porcion(xventa._NombreVendedor, 30) + Chr(18)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                        xt = Chr(15) + .Porcion(xventa._DirFiscalCliente, 75, 2) + Chr(18) + Space(8) + "Telf: " + Chr(15) + xventa._f_FichaVendedor.r_Telefono_1.PadRight(15, " ") + Chr(18)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                        xt = "Telefono: " + xventa._TelefonoCliente.PadRight(15, " ") + Space(27) + "Pag/No: " + xpagina.ToString.Trim
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                        .LineaBlanco()
                        .Rayado()
                        .TextoImprimir("CANT     EMPAQ     DESCRIPCION          P/SUG  UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()

                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Credito Then
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0) + Space(5) + "Condicion Pago: Credito " + xventa._DiasCreditoOtorgado.ToString.Trim + " Dias"
                Else
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'FORMATO FACTURA CHIMBO
    Sub FormatoXX_ORIGINAL_MODELO_4(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()

                xt = Space(43) + "DATOS DEL CLIENTE:"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = Space(43) + xventa._CiRifCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = Space(43) + Chr(15) + xventa._NombreCliente + Chr(18)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                xt = Space(43) + Chr(15) + .Porcion(xventa._DirFiscalCliente, 60) + Chr(18)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                If .Porcion(xventa._DirFiscalCliente, 60, 2).Trim <> "" Then
                    xt = Space(43) + Chr(15) + .Porcion(xventa._DirFiscalCliente, 60, 2) + Chr(18)
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xt = Space(43) + xventa._TelefonoCliente
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                Else
                    xt = Space(43) + xventa._TelefonoCliente
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                    .LineaBlanco()
                End If

                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()

                Dim xr As String = IIf(xventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado, "CONTADO ", "CREDITO")
                xt = Space(5) + xventa._FechaEmision.ToShortDateString + Space(3) + Chr(15) + .Porcion(xventa._NombreVendedor, 40) + Chr(18) + Space(6) + xr + Space(5) + Chr(27) + "W1" + "FACTURA" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = Space(18) + xventa._f_FichaVendedor.r_CodigoVendedor.PadRight(xventa._f_FichaVendedor.c_CodigoVendedor.c_Largo, " ") + Space(15) + xventa._DiasCreditoOtorgado.ToString + " Dias" + Space(12) + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += Space(2) + Chr(15) + xventadetalle._CodigoProducto.PadLeft(xventadetalle.c_CodigoProducto.c_Largo, " ") + Space(2) + .Porcion(xventadetalle._NombreProducto, 50) + Chr(18)
                    xt += Space(2) + .Formato(xventadetalle._CantidadDespachada, 4, 2) + Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2) + Space(2)
                    xt += .Formato(xventadetalle._Tasa_Descuento1, 2, 2) + Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xlinea += 1
                    xresta -= 1
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .LineaBlanco()
                .LineaBlanco()

                xt = Space(58) + "     EXENTO" + Space(3) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = Space(58) + "BI (" + String.Format("{0:#0.00}", xventa._TasaIva_1) + "%)" + Space(3) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = Space(58) + "IVA(" + String.Format("{0:#0.00}", xventa._TasaIva_1) + "%)" + Space(3) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = Space(58) + "TOTAL VENTA" + Space(3) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'FORMATO FACTURA CHIMBO
    Sub FormatoXX_ORIGINAL_MODELO_5(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .Rayado()
                .TextoImprimir("CANT     DESCRIPCION                    P/SUG  UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += Chr(15) + .Porcion(xventadetalle._NombreProducto, 40) + Chr(18)
                    xt += Space(5)
                    xt += .Formato(xventadetalle._PrecioSugerido, 4, 1)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()

                        .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        .Rayado()
                        .TextoImprimir("CANT     DESCRIPCION                    P/SUG  UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()

                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Credito Then
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0) + Space(5) + "Condicion Pago: Credito " + xventa._DiasCreditoOtorgado.ToString.Trim + " Dias"
                Else
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'FORMATO VENTA 
    Sub FormatoFactura_COPIA(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente + Space(2) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(2) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "FACTURA: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._DirFiscalCliente, 63) + Space(3) + Chr(27) + "W1" + "COPIA" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .Rayado()
                .TextoImprimir("CANT     EMPAQ     DESCRIPCION                 UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreEmpaque, 7)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreProducto, 25)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)
                    xt += Space(2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()

                        .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente + Space(3) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(3) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "NOTA: " + xventa._Documento
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._DirFiscalCliente, 63) + Space(3) + Chr(27) + "W1" + "COPIA" + Chr(27) + "W0"
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        .Rayado()
                        .TextoImprimir("CANT     EMPAQ     DESCRIPCION                 UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()


                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Credito Then
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0) + Space(5) + "Condicion Pago: Credito " + xventa._DiasCreditoOtorgado.ToString.Trim + " Dias"
                Else
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'FORMATO FACTURA ORIGINAL 
    Sub FormatoFactura_ORIGINAL(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente + Space(2) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(2) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "FACTURA: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .Rayado()
                .TextoImprimir("CANT     EMPAQ     DESCRIPCION                 UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreEmpaque, 7)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreProducto, 25)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)
                    xt += Space(2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()

                        .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente + Space(2) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(2) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "FACTURA: " + xventa._Documento
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        .Rayado()
                        .TextoImprimir("CANT     EMPAQ     DESCRIPCION                 UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()

                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Credito Then
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0) + Space(5) + "Condicion Pago: Credito " + xventa._DiasCreditoOtorgado.ToString.Trim + " Dias"
                Else
                    xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'FORMATO FACTURA ORIGINAL
    Sub FormatoFactura_ORIGINAL_MODELO_4(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()

                xt = Space(43) + "DATOS DEL CLIENTE:"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = Space(43) + xventa._CiRifCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = Space(43) + Chr(15) + xventa._NombreCliente + Chr(18)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                xt = Space(43) + Chr(15) + .Porcion(xventa._DirFiscalCliente, 60) + Chr(18)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                If .Porcion(xventa._DirFiscalCliente, 60, 2).Trim <> "" Then
                    xt = Space(43) + Chr(15) + .Porcion(xventa._DirFiscalCliente, 60, 2) + Chr(18)
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xt = Space(43) + xventa._TelefonoCliente
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                Else
                    xt = Space(43) + xventa._TelefonoCliente
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                    .LineaBlanco()
                End If

                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()

                Dim xr As String = IIf(xventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado, "CONTADO ", "CREDITO")
                xt = Space(5) + xventa._FechaEmision.ToShortDateString + Space(3) + Chr(15) + .Porcion(xventa._NombreVendedor, 40) + Chr(18) + Space(6) + xr + Space(5) + Chr(27) + "W1" + "FACTURA" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = Space(18) + xventa._f_FichaVendedor.r_CodigoVendedor.PadRight(xventa._f_FichaVendedor.c_CodigoVendedor.c_Largo, " ") + Space(15) + xventa._DiasCreditoOtorgado.ToString + " Dias" + Space(12) + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += Space(2) + Chr(15) + xventadetalle._CodigoProducto.PadLeft(xventadetalle.c_CodigoProducto.c_Largo, " ") + Space(2) + .Porcion(xventadetalle._NombreProducto, 50) + Chr(18)
                    xt += Space(2) + .Formato(xventadetalle._CantidadDespachada, 4, 2) + Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2) + Space(2)
                    xt += .Formato(xventadetalle._Tasa_Descuento1, 2, 2) + Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xlinea += 1
                    xresta -= 1
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)

                .LineaBlanco()
                .LineaBlanco()

                xt = Space(58) + "     EXENTO" + Space(3) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = Space(58) + "BI (" + String.Format("{0:#0.00}", xventa._TasaIva_1) + "%)" + Space(3) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = Space(58) + "IVA(" + String.Format("{0:#0.00}", xventa._TasaIva_1) + "%)" + Space(3) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = Space(58) + "TOTAL VENTA" + Space(3) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'FORMATO N/C ORIGINAL
    Sub FormatoNC_ORIGINAL(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente + Space(2) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(2) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "N/CREDIT:" + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .Rayado()
                .TextoImprimir("CANT     EMPAQ     DESCRIPCION                 UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreEmpaque, 7)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreProducto, 25)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)
                    xt += Space(2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()

                        .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente + Space(2) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(2) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "N/CREDIT:" + xventa._Documento
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._DirFiscalCliente, 60) + Space(3) + Chr(27) + "W1" + "ORIGINAL" + Chr(27) + "W0"
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        .Rayado()
                        .TextoImprimir("CANT     EMPAQ     DESCRIPCION                 UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()

                xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatoNC_ORIGINAL_MODELO_4(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()

                xt = Space(43) + "DATOS DEL CLIENTE:"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = Space(43) + xventa._CiRifCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = Space(43) + Chr(15) + xventa._NombreCliente + Chr(18)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                xt = Space(43) + Chr(15) + .Porcion(xventa._DirFiscalCliente, 60) + Chr(18)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)

                If .Porcion(xventa._DirFiscalCliente, 60, 2).Trim <> "" Then
                    xt = Space(43) + Chr(15) + .Porcion(xventa._DirFiscalCliente, 60, 2) + Chr(18)
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xt = Space(43) + xventa._TelefonoCliente
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                Else
                    xt = Space(43) + xventa._TelefonoCliente
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                    .LineaBlanco()
                End If

                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()

                Dim xr As String = IIf(xventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado, "CONTADO ", "CREDITO")
                xt = Space(5) + xventa._FechaEmision.ToShortDateString + Space(3) + Chr(15) + .Porcion(xventa._NombreVendedor, 40) + Chr(18) + Space(6) + xr + Space(1) + Chr(27) + "W1" + "N/CREDITO" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = Space(18) + xventa._f_FichaVendedor.r_CodigoVendedor.PadRight(xventa._f_FichaVendedor.c_CodigoVendedor.c_Largo, " ") + Space(15) + xventa._DiasCreditoOtorgado.ToString + " Dias" + Space(12) + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .LineaBlanco()
                .LineaBlanco()
                .LineaBlanco()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += Space(2) + Chr(15) + xventadetalle._CodigoProducto.PadLeft(xventadetalle.c_CodigoProducto.c_Largo, " ") + Space(2) + .Porcion(xventadetalle._NombreProducto, 50) + Chr(18)
                    xt += Space(2) + .Formato(xventadetalle._CantidadDespachada, 4, 2) + Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2) + Space(2)
                    xt += .Formato(xventadetalle._Tasa_Descuento1, 2, 2) + Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                    xlinea += 1
                    xresta -= 1
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .LineaBlanco()
                .LineaBlanco()

                xt = Space(58) + "     EXENTO" + Space(3) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = Space(58) + "BI (" + String.Format("{0:#0.00}", xventa._TasaIva_1) + "%)" + Space(3) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = Space(58) + "IVA(" + String.Format("{0:#0.00}", xventa._TasaIva_1) + "%)" + Space(3) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = Space(58) + "TOTAL VENTA" + Space(3) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'FORMATO N/C COPIA
    Sub FormatoNC_COPIA(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta
                ._CantidadLineasDetalleImprimir = xlineas

                .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                .LineaBlanco()

                xt = "CI/RIF: " + xventa._CiRifCliente + Space(2) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(2) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "N/CREDIT:" + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                xt = .Porcion(xventa._DirFiscalCliente, 63) + Space(3) + Chr(27) + "W1" + "COPIA" + Chr(27) + "W0"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                .Rayado()
                .TextoImprimir("CANT     EMPAQ     DESCRIPCION                 UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                .Rayado()

                Dim xlinea As Integer = 0
                Dim xresta As Integer = 0
                xresta = xdata.Tables(2).Rows.Count
                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreEmpaque, 7)
                    xt += Space(2)
                    xt += .Porcion(xventadetalle._NombreProducto, 25)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioLiquida, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)
                    xt += Space(2)

                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                    xlinea += 1
                    xresta -= 1

                    If (xlinea >= ximp._CantidadLineasDetalleImprimir) And xresta > 0 Then
                        xlinea = 0
                        .Continuar()

                        .TextoImprimir(xempresa._RazonSocial, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._DireccionFiscal, ManejoImpresora.ModoImprimir.Centrado)
                        .TextoImprimir(xempresa._RIF, ManejoImpresora.ModoImprimir.Centrado)
                        .LineaBlanco()

                        xt = "CI/RIF: " + xventa._CiRifCliente + Space(2) + "FECHA: " + xventa._FechaEmision.ToShortDateString + Space(2) + "COND/PAGO: " + xventa._CondicionPago.ToString + Space(2) + "N/CREDIT:" + xventa._Documento
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._NombreCliente, 58) + Space(3) + "Cajero: " + .Porcion(xventa._NombreUsuario, 10)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        xt = .Porcion(xventa._DirFiscalCliente, 63) + Space(3) + Chr(27) + "W1" + "COPIA" + Chr(27) + "W0"
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                        .Rayado()
                        .TextoImprimir("CANT     EMPAQ     DESCRIPCION                 UNIDAD  P/UNIT    %ALIC  SUBTOTAL", ManejoImpresora.ModoImprimir.Normal)
                        .Rayado()
                    End If
                Next
                .AvanzarLineas(._CantidadLineasDetalleImprimir - xlinea)
                .Rayado()

                xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "EXENTO     " + Space(60) + .Formato(xventa._MontoExento, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "BI         " + Space(60) + .Formato(xventa._MontoTotalBases, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "IVA        " + Space(60) + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "TOTAL VENTA" + Space(60) + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)
                .AvanzarPapel()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Sub FormatoXX_COPIA_TICKET(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta

                xt = xempresa._RazonSocial
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = "RIF: " + xempresa._RIF
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = xempresa._DireccionFiscal
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = "Telf: " + xempresa._Telefono_1
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .LineaBlanco()

                xt = "  COPIA / COPIA /COPIA / COPIA / COPIA  "
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "Documento: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "De Fecha : " + xventa._FechaEmision.ToShortDateString
                xt += ", Hora: " + xventa._HoraDocumento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado Then
                    xt = "Cond/Pago: CONTADO"
                Else
                    xt = "Cond/Pago: CREDITO, Dias:" + xventa._DiasCreditoOtorgado.ToString.Trim
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .LineaBlanco()

                xt = "Datos Del Cliente:"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = xventa._NombreCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = "CI/RIF: " + xventa._CiRifCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = xventa._DirFiscalCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                .LineaBlanco()

                xt = "Cant       P/Neto   Dsct   Iva SubTotal"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                .Rayado()

                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._Tasa_Descuento1, 2, 2)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                    xt = ""
                    xt += .Porcion(xventadetalle._NombreProducto, 35)
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                    xt = ""
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PermitirImprimirLinea_EmpaqueSugeridoContenido_ImpFiscal_AlFacturar Then
                        xt += "Pvs:" + .Formato(xventadetalle._PrecioSugerido, 5, 2) + Space(2) + ", Empq:" + .Porcion(xventadetalle._NombreEmpaque, 10) + "/" + .Formato(xventadetalle._ContenidoEmpaque, 4, 0)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                    End If
                Next
                .Rayado()
                xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                     SUBTOTAL: " + .Formato(xventa._MontoSubtotal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                    DESCUENTO: " + .Formato(xventa._MontoDescuento_1, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                          IVA: " + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                  TOTAL VENTA: " + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)

                For x = 1 To 8
                    .LineaBlanco()
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatoXX_ORIGINAL_TICKET(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta

                xt = xempresa._RazonSocial
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = "RIF: " + xempresa._RIF
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = xempresa._DireccionFiscal
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = "Telf: " + xempresa._Telefono_1
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .LineaBlanco()

                xt = "Documento: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "De Fecha : " + xventa._FechaEmision.ToShortDateString
                xt += ", Hora: " + xventa._HoraDocumento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado Then
                    xt = "Cond/Pago: CONTADO"
                Else
                    xt = "Cond/Pago: CREDITO, Dias:" + xventa._DiasCreditoOtorgado.ToString.Trim
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .LineaBlanco()

                xt = "Datos Del Cliente:"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = xventa._NombreCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = "CI/RIF: " + xventa._CiRifCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = xventa._DirFiscalCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                .LineaBlanco()

                xt = "Cant       P/Neto   Dsct   Iva SubTotal"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                .Rayado()

                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._Tasa_Descuento1, 2, 2)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                    xt = ""
                    xt += .Porcion(xventadetalle._NombreProducto, 35)
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                    xt = ""
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PermitirImprimirLinea_EmpaqueSugeridoContenido_ImpFiscal_AlFacturar Then
                        xt += "Pvs:" + .Formato(xventadetalle._PrecioSugerido, 5, 2) + Space(2) + ", Empq:" + .Porcion(xventadetalle._NombreEmpaque, 10) + "/" + .Formato(xventadetalle._ContenidoEmpaque, 4, 0)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                    End If
                Next
                .Rayado()
                xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                     SUBTOTAL: " + .Formato(xventa._MontoSubtotal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                    DESCUENTO: " + .Formato(xventa._MontoDescuento_1, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                          IVA: " + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                  TOTAL VENTA: " + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)

                For x = 1 To 8
                    .LineaBlanco()
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatoFactura_COPIA_TICKET(ByVal xdata As DataSet, ByVal xpapel As ManejoImpresora.TipoPapel, ByVal xruta As String, ByVal xlineas As Integer)
        Try
            Dim xempresa As New FichaGlobal.c_Negocio.c_Registro
            Dim xventa As New FichaVentas.V_Ventas.c_Registro
            Dim xventadetalle As New FichaVentas.V_VentasDetalle.c_Registro

            Dim xt As String = ""
            Dim ximp As New ManejoImpresora

            xempresa.CargarRegistro(xdata.Tables(0).Rows(0))
            xventa.CargarRegistro(xdata.Tables(1).Rows(0))
            With ximp
                ._MiPapel = xpapel
                ._RutaImpresora = xruta

                xt = xempresa._RazonSocial
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = "RIF: " + xempresa._RIF
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = xempresa._DireccionFiscal
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = "Telf: " + xempresa._Telefono_1
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .LineaBlanco()

                xt = "  COPIA / COPIA /COPIA / COPIA / COPIA  "
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "Documento: " + xventa._Documento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "De Fecha : " + xventa._FechaEmision.ToShortDateString
                xt += ", Hora: " + xventa._HoraDocumento
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                If xventa._CondicionPago = FichaVentas.TipoCondcionPago.Contado Then
                    xt = "Cond/Pago: CONTADO"
                Else
                    xt = "Cond/Pago: CREDITO, Dias:" + xventa._DiasCreditoOtorgado.ToString.Trim
                End If
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .LineaBlanco()

                xt = "Datos Del Cliente:"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = xventa._NombreCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                xt = "CI/RIF: " + xventa._CiRifCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = xventa._DirFiscalCliente
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                .LineaBlanco()

                xt = "Cant       P/Neto   Dsct   Iva SubTotal"
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal, False)
                .Rayado()

                For Each dr As DataRow In xdata.Tables(2).Rows
                    xventadetalle.M_CargarFicha(dr)

                    xt = ""
                    xt += .Formato(xventadetalle._CantidadDespachada, 4, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._PrecioNeto, 5, 2)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._Tasa_Descuento1, 2, 2)
                    xt += Space(1)
                    xt += .Formato(xventadetalle._TasaIva, 2, 2)
                    xt += Space(2)
                    xt += .Formato(xventadetalle._TotalNeto, 5, 2)
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                    xt = ""
                    xt += .Porcion(xventadetalle._NombreProducto, 35)
                    .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)

                    xt = ""
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PermitirImprimirLinea_EmpaqueSugeridoContenido_ImpFiscal_AlFacturar Then
                        xt += "Pvs:" + .Formato(xventadetalle._PrecioSugerido, 5, 2) + Space(2) + ", Empq:" + .Porcion(xventadetalle._NombreEmpaque, 10) + "/" + .Formato(xventadetalle._ContenidoEmpaque, 4, 0)
                        .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                    End If
                Next
                .Rayado()
                xt = "Total Lineas: " + .Formato(xventa._CantidadRenglones, 4, 0)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                     SUBTOTAL: " + .Formato(xventa._MontoSubtotal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                    DESCUENTO: " + .Formato(xventa._MontoDescuento_1, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                          IVA: " + .Formato(xventa._MontoTotalImpuesto, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                xt = "                  TOTAL VENTA: " + .Formato(xventa._TotalGenereal, 5, 2)
                .TextoImprimir(xt, ManejoImpresora.ModoImprimir.Normal)
                .Rayado()
                .TextoImprimir("GRACIAS POR SU COMPRA", ManejoImpresora.ModoImprimir.Normal)

                For x = 1 To 8
                    .LineaBlanco()
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
