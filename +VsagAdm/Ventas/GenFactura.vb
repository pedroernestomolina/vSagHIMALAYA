Public Class GenFactura
    Property Encabezado As GenEncabezado
    Property Detalles As List(Of GenDetalle)
    Property LimiteRenglonesPorDoc As Integer


    Sub New()
        Encabezado = New GenEncabezado
        Detalles = New List(Of GenDetalle)
        LimiteRenglonesPorDoc = 0
    End Sub


    Function Documentos() As List(Of DataSistema.MiDataSistema.DataSistema.FichaVentas.GenerarFactura)
        Dim rt = New List(Of DataSistema.MiDataSistema.DataSistema.FichaVentas.GenerarFactura)

        Dim ndoc As Integer = 0
        If LimiteRenglonesPorDoc = 0 Then
            ndoc = 1
            LimiteRenglonesPorDoc = Detalles.Count
        Else
            ndoc = Conversion.Int(Detalles.Count / LimiteRenglonesPorDoc)
            If ndoc = 0 Then
                ndoc += 1
            ElseIf (ndoc * LimiteRenglonesPorDoc) < Detalles.Count Then
                ndoc += 1
            End If
        End If

        For it = 1 To ndoc
            Dim doc = New DataSistema.MiDataSistema.DataSistema.FichaVentas.GenerarFactura
            Dim docEncabezado = New DataSistema.GenerarFacturaVenta
            Dim docDetalles = New List(Of DataSistema.GenerarFacturaVentaDetalle)
            Dim docMedidas = New List(Of DataSistema.GenerarFacturaVentaMedida)
            Dim docTempVenta = New List(Of DataSistema.GenerarFacturaVentaTemp)

            Dim salto = (it - 1) * LimiteRenglonesPorDoc
            Dim det = Detalles.Skip(salto).Take(LimiteRenglonesPorDoc)
            For Each nit In det
                Dim GenFacturaDetalle = New DataSistema.GenerarFacturaVentaDetalle
                With GenFacturaDetalle
                    .cantidad = nit.cantidad
                    .cantUnd = nit.cantUnd
                    .categoria = nit.categoria
                    .codigoTasaIva = nit.codigoTasaIva
                    .confTipoCalcUtilidad = nit.confTipoCalcUtilidad
                    .contEmpaque = nit.contEmpaque
                    .costo = nit.costo
                    .costoUnd = nit.costoUnd
                    .departAuto = nit.departAuto
                    .descMonto_1 = nit.descMonto_1
                    .descMonto_2 = nit.descMonto_2
                    .descMonto_3 = nit.descMonto_3
                    .descPorc_1 = nit.descPorc_1
                    .descPorc_2 = nit.descPorc_1
                    .descPorc_3 = nit.descPorc_1
                    .detalle = nit.detalle
                    .empaque = nit.empaque
                    .empaqueTipo = nit.empaqueTipo
                    .grupoAuto = nit.grupoAuto
                    .impuesto = nit.impuesto
                    .medidaAuto = nit.medidaAuto
                    .medidaDecimales = nit.medidaDecimales
                    .medidaForzar = nit.medidaForzar
                    .prdAuto = nit.prdAuto
                    .prdCodigo = nit.prdCodigo
                    .prdDescripcion = nit.prdDescripcion
                    .prdNombre = nit.prdNombre
                    .precioFinal = nit.precioFinal
                    .precioInv = nit.precioInv
                    .precioItem = nit.precioItem
                    .precioNeto = nit.precioNeto
                    .psv = nit.psv
                    .subGrupAuto = nit.subGrupAuto
                    .tasaIva = nit.tasaIva
                    .total = nit.total
                    .totalNeto = nit.totalNeto
                    .medidaNombre = nit.medidaNombre
                    .utilidad = nit.utilidad
                    .utilidadPorc = nit.utilidadPorc
                    .provDocOrigen = nit.provDocOrigen
                End With
                docDetalles.Add(GenFacturaDetalle)

                Dim medida As DataSistema.GenerarFacturaVentaMedida = New DataSistema.GenerarFacturaVentaMedida
                With medida
                    .autoMedida = nit.medidaAuto
                    .cantidad = nit.cantidad
                    .decimales = nit.medidaDecimales
                    .nombreMedida = nit.medidaNombre
                End With
                docMedidas.Add(medida)

                Dim tmpVenta = New DataSistema.GenerarFacturaVentaTemp
                With tmpVenta
                    .idItem = nit.idItemTemp
                End With
                docTempVenta.Add(tmpVenta)
            Next
            Dim montoExento = det.Sum(Function(s) s.montoExento)
            Dim montoBase1 = det.Where(Function(w) w.codigoTasaIva = "1").Sum(Function(s) s.montoBase)
            Dim montoBase2 = det.Where(Function(w) w.codigoTasaIva = "2").Sum(Function(s) s.montoBase)
            Dim montoBase3 = det.Where(Function(w) w.codigoTasaIva = "3").Sum(Function(s) s.montoBase)
            Dim montoBase = montoBase1 + montoBase2 + montoBase3
            Dim montoImp1 = det.Where(Function(w) w.codigoTasaIva = "1").Sum(Function(s) s.montoImpuesto)
            Dim montoImp2 = det.Where(Function(w) w.codigoTasaIva = "2").Sum(Function(s) s.montoImpuesto)
            Dim montoImp3 = det.Where(Function(w) w.codigoTasaIva = "3").Sum(Function(s) s.montoImpuesto)
            Dim montoImpuesto = montoImp1 + montoImp2 + montoImp3
            Dim importeNeto = det.Sum(Function(s) s.importeNeto)
            Dim descuento = (importeNeto * Encabezado.porcDescuento / 100)
            Dim total = montoBase + montoExento + montoImpuesto

            With docEncabezado
                .serieAuto = Encabezado.serieAuto
                .bloquearAlmacen = Encabezado.bloquearAlmacen
                .cliAuto = Encabezado.cliAuto
                .cliCiRif = Encabezado.cliCiRif
                .cliCodigo = Encabezado.cliCodigo
                .cliDirDespacho = Encabezado.cliDirDespacho
                .cliDirFiscal = Encabezado.cliDirFiscal
                .cliNombre = Encabezado.cliNombre
                .cliTelefono = Encabezado.cliTelefono
                .condPago = Encabezado.condPago
                .condPagoIsContado = Encabezado.condPagoIsContado
                .control = Encabezado.control
                .diasCredito = Encabezado.diasCredito
                .estacionEquipo = Encabezado.estacionEquipo
                .factorCambio = Encabezado.factorCambio
                .fechaPedido = Encabezado.fechaPedido
                .montoBase = montoBase
                .montoBase1 = montoBase1
                .montoBase2 = montoBase2
                .montoBase3 = montoBase3
                .montoCargo = 0
                .montoDescuento = descuento
                .montoDivisa = Decimal.Round(total / Encabezado.factorCambio, 2, MidpointRounding.AwayFromZero)
                .montoExento = montoExento
                .montoImpuesto = montoImpuesto
                .montoImpuesto1 = montoImp1
                .montoImpuesto2 = montoImp2
                .montoImpuesto3 = montoImp3
                .montoTotal = Decimal.Round(total, 2, MidpointRounding.AwayFromZero)
                .Notas = Encabezado.Notas
                .numPedido = Encabezado.numPedido
                .ordeCompra = Encabezado.ordeCompra
                .porcCargo = Encabezado.porcCargo
                .porcDescuento = Encabezado.porcDescuento
                .renglones = docDetalles.Count
                .saldoPend = IIf(Encabezado.condPagoIsContado, 0D, total)
                .serieNombre = Encabezado.serieNombre
                .serieSerial = Encabezado.serieSerial
                .subTotal = importeNeto
                .tasa1 = Encabezado.tasa1
                .tasa2 = Encabezado.tasa2
                .tasa3 = Encabezado.tasa3
                .usuAuto = Encabezado.usuAuto
                .usuCodigo = Encabezado.usuCodigo
                .usuNombre = Encabezado.usuNombre
                .vendAuto = Encabezado.vendAuto
                .vendCodigo = Encabezado.vendCodigo
                .vendNombre = Encabezado.vendNombre
                .zFiscal = Encabezado.zFiscal
                .depAuto = Encabezado.depAuto
                .depCodigo = Encabezado.depCodigo
                .depNombre = Encabezado.depNombre
                .conceptoAuto = Encabezado.conceptoAuto
                .conceptoCodigo = Encabezado.conceptoCodigo
                .conceptoNombre = Encabezado.conceptoNombre
                .cobradorAuto = Encabezado.cobradorAuto
                .cobradorCodigo = Encabezado.cobradorCodigo
                .cobradorNombre = Encabezado.cobradorNombre
            End With

            Dim lmed = docMedidas.GroupBy(Function(g) New With {
                                            Key g.autoMedida, Key g.nombreMedida, Key g.decimales}).
                                    Select(Function(gg) New DataSistema.GenerarFacturaVentaMedida With {
                                               .autoMedida = gg.Key.autoMedida,
                                               .nombreMedida = gg.Key.nombreMedida,
                                               .decimales = gg.Key.decimales,
                                               .cantidad = gg.Sum(Function(t) t.cantidad)
                                           }).ToList()

            With doc
                .Venta = docEncabezado
                .VentaDetalles = docDetalles
                .VentaMedidas = lmed
                .VentaTemp = docTempVenta
            End With

            rt.Add(doc)
        Next

        Return rt
    End Function

    Function ListaPrdDeposito() As List(Of DataSistema.PrdDeposito)
        Dim listaPrdDep = New List(Of DataSistema.PrdDeposito)
        For Each nit In Detalles
            Dim prdDep = New DataSistema.PrdDeposito
            With prdDep
                .autoDep = Encabezado.depAuto
                .autoPrd = nit.prdAuto
                .cantInv = nit.cantUnd
                .nomPrd = nit.prdNombre
            End With
            listaPrdDep.Add(prdDep)
        Next
        Return listaPrdDep
    End Function

End Class
