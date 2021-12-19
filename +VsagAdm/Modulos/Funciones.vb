Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient
Imports System.Net

Module Funciones
    Sub MensajeDeError(ByVal ex As String)
        MessageBox.Show("ERROR... !!!" + vbCrLf + ex, "*** Mensaje De ERROR ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Sub MensajeDeAlerta(ByVal ex As String)
        MessageBox.Show("Alerta... !!!" + vbCrLf + ex, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Sub MensajeDeOk(ByVal ex As String)
        MessageBox.Show("Muy Bien... !!!" + vbCrLf + ex, "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    ''' <summary>
    ''' Retorna La Ip Del Equipo
    ''' </summary>
    Function RetornaIp() As String
        Dim Host As String = Dns.GetHostName
        Dim IPs As IPHostEntry = Dns.GetHostEntry(Host)
        Dim Direcciones As IPAddress() = IPs.AddressList
        Dim xip As String = ""

        For Each x In Direcciones
            If x.IsIPv6LinkLocal Then
            Else
                xip = x.ToString
                Exit For
            End If
        Next

        Return xip
    End Function

    ''' <summary>
    ''' Retorna La Fecha Del Equipo
    ''' </summary>
    Function FechaDelSistema() As String
        Dim st As String = ""
        Select Case Date.Now.DayOfWeek
            Case DayOfWeek.Monday
                st = "Lunes, "
            Case DayOfWeek.Tuesday
                st = "Martes, "
            Case DayOfWeek.Wednesday
                st = "Miercoles, "
            Case DayOfWeek.Thursday
                st = "Jueves, "
            Case DayOfWeek.Friday
                st = "Viernes, "
            Case DayOfWeek.Saturday
                st = "Sabado, "
            Case DayOfWeek.Sunday
                st = "Domingo, "
        End Select
        st += Date.Now.Day.ToString.PadLeft(2, "0") + " De "
        Select Case Date.Now.Month
            Case 1
                st += "Enero Del "
            Case 2
                st += "Febrero Del "
            Case 3
                st += "Marzo Del "
            Case 4
                st += "Abrir Del "
            Case 5
                st += "Mayo Del "
            Case 6
                st += "Junio Del "
            Case 7
                st += "Julio Del "
            Case 8
                st += "Agosto Del "
            Case 9
                st += "Septiembre Del "
            Case 10
                st += "Octubre Del "
            Case 11
                st += "Noviembre Del "
            Case 12
                st += "Dicimbre Del "
        End Select
        st += Date.Now.Year.ToString
        Return st
    End Function


    ''' <summary>
    ''' Metodo: Usado Para Ver Los Costos, Utilidad Margen Al Facturar / Ver Inventario
    ''' </summary>
    ''' <param name="xauto_1">Auto Producto</param>
    ''' <param name="xauto_2">Referencia Empaque</param>
    ''' <param name="xauto_3">Precio A Mostrar (1,2)</param>
    ''' <remarks></remarks>
    Sub VerCostoUtilidad(ByVal xauto_1 As String, ByVal xauto_2 As String, ByVal xauto_3 As String)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_VerCosto.F_Permitir()

            Dim xp1 As New SqlParameter("@auto_producto", xauto_1)
            Dim xp2 As New SqlParameter("@referencia", xauto_2)
            Dim xp11 As New SqlParameter("@auto", xauto_1)

            Dim xrow_pv As DataRow = Nothing
            Dim xrow_prd As DataRow = Nothing

            g_MiData.F_GetData("select * from productos_empaque where auto_producto=@auto_producto and referencia=@referencia", xrow_pv, xp1, xp2)
            g_MiData.F_GetData("select * from productos where auto=@auto", xrow_prd, xp11)

            If xrow_pv IsNot Nothing Then
                If xrow_prd IsNot Nothing Then
                    Dim xprd As New FichaProducto.Prd_Producto(xrow_prd)
                    Dim xemp As New FichaProducto.Prd_Empaque(xrow_pv)
                    Dim xregistro As New VerCostoUtilidad
                    With xregistro
                        ._ContenidoEmpaqueCompra = xprd.RegistroDato._ContEmpqCompra
                        ._CostoNetoCompra = xprd.RegistroDato._CostoCompra._Base
                        If xauto_3 = "1" Then
                            ._PrecioNeto = xemp.RegistroDato._PrecioNeto_1
                            ._ContenidoEmpaqueVenta = xemp.RegistroDato._ContenidoEmpaque
                        Else
                            ._PrecioNeto = xemp.RegistroDato._PrecioNeto_2
                            ._ContenidoEmpaqueVenta = xemp.RegistroDato._ContenidoEmpaque
                        End If

                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            ._Utilidad = UtilidadBaseCosto(._CostoNeto, ._MargenGanancia)
                        Else
                            ._Utilidad = UtilidadBasePrecioVenta(._PrecioNeto, ._MargenGanancia)
                        End If
                    End With

                    Dim xficha As New MostrarCostoUtilidad(xregistro, xprd.RegistroDato._TasaImpuesto)
                    With xficha
                        .ShowDialog()
                    End With
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub VerCostoUtilidad(ByVal xauto As String)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_VerCosto.F_Permitir()

            Dim xrow_prd As DataRow = Nothing
            Dim xrow_tventa As DataRow = Nothing

            Dim xp1 As New SqlParameter("@autoitem", xauto)
            g_MiData.F_GetData("select * from temporalventa where autoitem=@autoitem", xrow_tventa, xp1)
            If xrow_tventa IsNot Nothing Then
                Dim tventa As New FichaVentas.V_TemporalVenta
                tventa.M_CargarRegistro(xrow_tventa)

                Dim xp2 As New SqlParameter("@auto", tventa.RegistroDato._AutoProducto)
                g_MiData.F_GetData("select * from productos where auto=@auto", xrow_prd, xp2)

                If xrow_prd IsNot Nothing Then
                    Dim xprd As New FichaProducto.Prd_Producto(xrow_prd)
                    Dim xregistro As New VerCostoUtilidad
                    With xregistro
                        ._ContenidoEmpaqueCompra = xprd.RegistroDato._ContEmpqCompra
                        ._ContenidoEmpaqueVenta = tventa.RegistroDato._ContenidoEmpaque
                        ._CostoNetoCompra = xprd.RegistroDato._CostoCompra._Base
                        ._PrecioNeto = tventa.RegistroDato._PrecioNeto

                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            ._Utilidad = UtilidadBaseCosto(xregistro._CostoNeto, xregistro._MargenGanancia)
                        Else
                            ._Utilidad = UtilidadBasePrecioVenta(xregistro._PrecioNeto, xregistro._MargenGanancia)
                        End If
                    End With

                    Dim xficha As New MostrarCostoUtilidad(xregistro, xprd.RegistroDato._TasaImpuesto)
                    With xficha
                        .ShowDialog()
                    End With
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Funcion: Retorna El Porcentaje de Utilidad En Base Al Costo
    ''' </summary>
    ''' <param name="xcosto"></param>
    ''' Costo de Venta
    ''' <param name="xmargen"></param>
    ''' Margen/Ganancia A Obtener
    ''' <returns></returns>
    Function UtilidadBaseCosto(ByVal xcosto As Decimal, ByVal xmargen As Decimal) As Decimal
        If xcosto > 0 Then
            Dim x As Decimal = 0
            x = (xmargen / xcosto) * 100
            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
            Return x
        Else
            Return 100
        End If
    End Function

    ''' <summary>
    ''' Funcion: Retorna El Porcentaje de Utilidad En Base Al Precio De Venta
    ''' </summary>
    ''' <param name="xpventa"></param>
    ''' Precio De Venta
    ''' <param name="xmargen"></param>
    ''' ;argen/Ganancia A Obtener
    ''' <returns></returns>
    Function UtilidadBasePrecioVenta(ByVal xpventa As Decimal, ByVal xmargen As Decimal) As Decimal
        If xpventa > 0 Then
            Dim x As Decimal = 0
            x = (xmargen / xpventa) * 100
            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
            Return x
        Else
            Return -100
        End If
    End Function

    Function VisualizarDoc_Ventas(ByVal xauto As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ventas As New DataTable("venta")
        Dim dtb_ventas_detalle As New DataTable("venta_detalle")
        Dim dtb_ventas_modo_pago As New DataTable("venta_modo_pago")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xp1 As SqlParameter
            Dim xp2 As SqlParameter
            Dim xp3 As SqlParameter
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, telefono_2, telefono_3,celular_1, celular_2, " & _
                                   "sucursal, codigo_sucursal, website, email from empresa"

            Dim xsql_2 As String = "select v.nombre, v.dir_fiscal, v.ci_rif, v.codigo_entidad, v.telefono, v.dir_despacho, v.documento " & _
                                                 ",v.fecha, v.fecha_vencimiento, v.condicion_pago, v.orden_compra, v.pedido, v.fecha_pedido " & _
                                                 ",v.codigo_vendedor, v.vendedor, v.subtotal, v.descuento1, v.cargos, v.impuesto1, v.impuesto2 " & _
                                                 ",v.total, v.tasa1, v.tasa2, v.descuento1_porcentaje, v.transporte, v.usuario, v.codigo_usuario " & _
                                                 ",v.monto_divisa, v.factor_cambio, v.nota, v.recibo, v.hora, v.estacion, v.estatus, v.saldo_pendiente " & _
                                                 ",v.dias_validez, v.tipo, v.aplica, v.base1, c.licor_licencia_nombre as licencia_nombre, c.Licor_licencia_numero as licencia_numero " & _
                                                 ",v.exento as TotalExento, v.impuesto as TotalImpuesto, v.base as TotalBase, v.impuesto3, v.tasa3 " & _
                                                 " from ventas as v join clientes as c on v.auto_entidad=c.auto where v.auto=@auto"

            Dim xsql_3 As String = "select codigo, nombre, cantidad, empaque, codigo_deposito, precio_neto, descuento1p " & _
                                                 ",tasa, dias_garantia, total_neto, detalle, n_licor_capacidad, n_licor_grados, n_licor_nacional_Importado, contenido_empaque " & _
                                                 "from ventas_detalle where auto_documento=@auto"

            Dim xsql_4 As String = "select m.nombre nombre, monto_recibido from ventas v inner join cxc_modo_pago m on v.auto_recibo=m.auto_recibo " & _
                                                             "where auto=@auto"

            xp1 = New SqlParameter("@auto", xauto)
            xp2 = New SqlParameter("@auto", xauto)
            xp3 = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql_2, dtb_ventas, xp1)
            g_MiData.F_GetData(xsql_3, dtb_ventas_detalle, xp2)
            g_MiData.F_GetData(xsql_4, dtb_ventas_modo_pago, xp3)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ventas)
            dts.Tables.Add(dtb_ventas_detalle)
            dts.Tables.Add(dtb_ventas_modo_pago)

            Dim xpagos As String = ""
            For Each xr As DataRow In dtb_ventas_modo_pago.Rows
                xpagos += xr("nombre").ToString.Trim + "=" + String.Format("{0:#0.00}", xr("monto_recibido")) + " , "
            Next

            Dim xlista As New List(Of _Reportes.ParamtCrystal)
            xlista.Add(New _Reportes.ParamtCrystal("@guarismo", Guarismo(dtb_ventas.Rows(0)("total").ToString)))
            xlista.Add(New _Reportes.ParamtCrystal("@formapago", xpagos))

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            Select Case dtb_ventas.Rows(0)("TIPO").ToString.Trim.ToUpper
                Case "01" : xrep += "VEN_FACTURA.rpt"
                Case "03" : xrep += "VEN_NOTACREDITO.rpt"
                Case "04" : xrep += "VEN_NOTAENTREGA.rpt"
                Case "05" : xrep += "VEN_PRESUPUESTO.rpt"
                Case "06" : xrep += "VEN_PEDIDO.rpt"
                Case "XX" : xrep += "VEN_XXX.rpt"
                Case "XN" : xrep += "VEN_XXX_NC.rpt"
            End Select
            Dim xficha As New _Reportes(dts, xrep, xlista)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Function VisualizarDoc_GuiaDespacho(ByVal xauto As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_ventas As New DataTable("venta")
        Dim dtb_ventas_detalle As New DataTable("venta_detalle")
        Dim dtb_ventas_modo_pago As New DataTable("venta_modo_pago")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xp1 As SqlParameter
            Dim xp2 As SqlParameter
            Dim xp3 As SqlParameter
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, telefono_2, telefono_3,celular_1, celular_2, " & _
                                   "sucursal, codigo_sucursal, website, email from empresa"

            Dim xsql_2 As String = "select nombre, dir_fiscal, ci_rif, codigo_entidad, telefono, dir_despacho, documento " & _
                                                 ",fecha, fecha_vencimiento, condicion_pago, orden_compra, pedido, fecha_pedido " & _
                                                 ",codigo_vendedor, vendedor, subtotal, descuento1, cargos, impuesto1, impuesto2 " & _
                                                 ",total, tasa1, tasa2, descuento1_porcentaje, transporte, usuario, codigo_usuario " & _
                                                 ",monto_divisa, factor_cambio, nota, recibo, hora, estacion, estatus, saldo_pendiente " & _
                                                 ",dias_validez, tipo, aplica from ventas where auto=@auto"

            Dim xsql_3 As String = "select codigo, nombre, cantidad, empaque, codigo_deposito, precio_neto, descuento1p " & _
                                                 ",tasa, dias_garantia, total_neto, detalle " & _
                                                 "from ventas_detalle where auto_documento=@auto order by nombre"

            Dim xsql_4 As String = "select m.nombre nombre, monto_recibido from ventas v inner join cxc_modo_pago m on v.auto_recibo=m.auto_recibo " & _
                                                             "where auto=@auto"

            xp1 = New SqlParameter("@auto", xauto)
            xp2 = New SqlParameter("@auto", xauto)
            xp3 = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql_2, dtb_ventas, xp1)
            g_MiData.F_GetData(xsql_3, dtb_ventas_detalle, xp2)
            g_MiData.F_GetData(xsql_4, dtb_ventas_modo_pago, xp3)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_ventas)
            dts.Tables.Add(dtb_ventas_detalle)
            dts.Tables.Add(dtb_ventas_modo_pago)

            Dim xpagos As String = ""
            For Each xr As DataRow In dtb_ventas_modo_pago.Rows
                xpagos += xr("nombre").ToString.Trim + "=" + String.Format("{0:#0.00}", xr("monto_recibido")) + " , "
            Next

            Dim xlista As New List(Of _Reportes.ParamtCrystal)
            xlista.Add(New _Reportes.ParamtCrystal("@guarismo", Guarismo(dtb_ventas.Rows(0)("total").ToString)))
            xlista.Add(New _Reportes.ParamtCrystal("@formapago", xpagos))

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            Select Case dtb_ventas.Rows(0)("TIPO").ToString.Trim.ToUpper
                Case "01" : xrep += "GUIA_DESPACHO_FACTURA.rpt"
                Case "04" : xrep += "GUIA_DESPACHO_NOTAENTREGA.rpt"
                Case "06" : xrep += "GUIA_DESPACHO_PEDIDO.rpt"
                Case "XX" : xrep += "GUIA_DESPACHO_XX.rpt"
            End Select
            Dim xficha As New _Reportes(dts, xrep, xlista)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function


    Function Guarismo(ByVal xval As String) As String
        Dim unidad As String() = {"UN", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE"}
        Dim decenas As String() = {"DIEZ", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA"}
        Dim centenas As String() = {"CIEN", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS"}
        Dim decimos As String() = {"ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE"}

        Dim xr As String = ""
        Dim v As Integer = 0

        Try
            Dim xv As String = xval.Trim.PadLeft(13, " ")
            Dim xs As Boolean = False


            'UNIDAD DE MIL millones
            If (xv(0) <> " ") Then
                Integer.TryParse(xv(2), v)
                v -= 1
                xr += unidad(v) + " MIL"
                xs = False
            End If

            'centena de millones
            If (xv(1) <> " " And xr = "") Or xs = True Then
                If xv(1) = "0" Then
                    xs = True
                Else
                    If Val(xv.Substring(2, 2)) = 0 Then
                        Integer.TryParse(xv(1), v)
                        v -= 1
                        xr += centenas(v) + " MILLONES "
                    Else
                        Integer.TryParse(xv(1), v)
                        v -= 1
                        If Val(xv(1)) = 1 Then
                            xr += "CIENTO "
                        Else
                            xr += centenas(v) + " "
                        End If
                        xs = True
                    End If
                End If
            End If

            'decena de millon
            If (xv(2) <> " " And xr = "") Or xs = True Then
                If xv(2) = "0" Then
                    xs = True
                Else
                    xs = False
                    If Val(xv(3)) = 0 Then
                        Integer.TryParse(xv(3), v)
                        v -= 1
                        xr += decenas(v) + " MILLONES "
                    Else
                        If Val(xv.Substring(2, 2)) >= 11 And Val(xv.Substring(2, 2)) <= 19 Then
                            Integer.TryParse(xv(3), v)
                            v -= 1
                            xr += decimos(v) + " MILLONES "
                        Else
                            If Val(xv.Substring(2, 1)) <> 0 Then
                                Integer.TryParse(xv(2), v)
                                v -= 1
                                xr += decenas(v) + " "
                                xs = True
                            Else
                                xs = True
                            End If
                        End If
                    End If
                End If
            End If

            'unidad de milLON
            If (xv(3) <> " " And xr = "") Or xs = True Then
                If xv(3) <> "0" Then
                    Integer.TryParse(xv(3), v)
                    v -= 1
                    xr += unidad(v) + " MILLONES "
                    xs = False
                End If
            End If

            'centena de mil
            If xv(4) <> " " Then
                If xv(4) = "0" Then
                    xs = True
                Else
                    If Val(xv.Substring(5, 2)) = 0 Then
                        Integer.TryParse(xv(4), v)
                        v -= 1
                        xr += centenas(v) + " MIL "
                    Else
                        Integer.TryParse(xv(4), v)
                        v -= 1
                        If Val(xv(4)) = 1 Then
                            xr += "CIENTO "
                        Else
                            xr += centenas(v) + " "
                        End If
                        xs = True
                    End If
                End If
            End If

            'decenas de mil
            If (xv(5) <> " " And xr = "") Or xs = True Then
                If xv(5) = "0" Then
                    xs = True
                Else
                    xs = False
                    If Val(xv(6)) = 0 Then
                        Integer.TryParse(xv(5), v)
                        v -= 1
                        xr += decenas(v) + " MIL "
                    Else
                        If Val(xv.Substring(5, 2)) >= 11 And Val(xv.Substring(5, 2)) <= 19 Then
                            Integer.TryParse(xv(6), v)
                            v -= 1
                            xr += decimos(v) + " MIL "
                        Else
                            If Val(xv.Substring(5, 1)) <> 0 Then
                                Integer.TryParse(xv(5), v)
                                v -= 1
                                xr += decenas(v) + " "
                                xs = True
                            Else
                                xs = True
                            End If
                        End If
                    End If
                End If
            End If

            'unidad de mil
            If (xv(6) <> " " And xr = "") Or xs = True Then
                If xv(6) <> "0" Then
                    Integer.TryParse(xv(6), v)
                    v -= 1
                    xr += unidad(v) + " MIL "
                    xs = False
                End If
            End If

            'centena
            If xv(7) <> " " Then
                If xv(7) = "0" Then
                    xs = True
                Else
                    xs = False
                    If Val(xv.Substring(8, 2)) = 0 Then
                        Integer.TryParse(xv(7), v)
                        v -= 1
                        xr += centenas(v) + " "
                    Else
                        Integer.TryParse(xv(7), v)
                        v -= 1
                        If Val(xv(7)) = 1 Then
                            xr += "CIENTO "
                        Else
                            xr += centenas(v) + " "
                        End If
                        xs = True
                    End If
                End If
            End If

            'decenas
            If (xv(8) <> " " And xr = "") Or xs = True Then
                If xv(8) = "0" Then
                    xs = True
                Else
                    xs = False
                    If Val(xv(9)) = 0 Then
                        Integer.TryParse(xv(8), v)
                        v -= 1
                        xr += decenas(v)
                    Else
                        If Val(xv.Substring(8, 2)) >= 11 And Val(xv.Substring(8, 2)) <= 19 Then
                            Integer.TryParse(xv(9), v)
                            v -= 1
                            xr += decimos(v) + " "
                        Else
                            If Val(xv.Substring(8, 1)) <> 0 Then
                                Integer.TryParse(xv(8), v)
                                v -= 1
                                xr += decenas(v) + " Y "
                                xs = True
                            Else
                                xs = True
                            End If
                        End If
                    End If
                End If
            End If

            'unidad
            If (xv(9) <> " " And xr = "") Or xs = True Then
                If xv(9) <> "0" Then
                    Integer.TryParse(xv(9), v)
                    v -= 1
                    If Val(xv(9)) = 1 Then
                        xr += "UNO "
                    Else
                        xr += unidad(v) + " "
                    End If
                    xs = False
                End If
            End If

            If xr <> "" Then
                xr += " CON " + xv.Substring(10, 2) + "/100 CENTIMOS"
            Else
                xr += xv.Substring(10, 2) + "/100 CENTIMOS"
            End If
        Catch ex As Exception
            xr = ""
        End Try
        Return xr
    End Function

    Function VisualizarDoc_Compras(ByVal xauto As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_compras As New DataTable("compra")
        Dim dtb_compras_detalle As New DataTable("compra_detalle")
        Dim dtb_compras_modo_pago As New DataTable("medios_pago")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xp1 As SqlParameter
            Dim xp2 As SqlParameter
            Dim xp3 As SqlParameter
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            Dim xsql_2 As String = "select nombre, dir_fiscal, ci_rif, codigo_entidad, telefono, documento, fecha " & _
                                                 ",fecha_vencimiento, subtotal, descuento1, cargos, impuesto1, impuesto2 " & _
                                                 ",total, tasa1, tasa2, descuento1_porcentaje, nota, estatus, tipo " & _
                                                 ",aplica, fletep, flete, seguro, segurop, mes_relacion, ano_relacion, control, cargos_porcentaje " & _
                                                 ",exento,base1,base2,base3,base,n_montoimplicor impuestolicor,fecha_carga, orden_compra, impuesto3, tasa3 " & _
                                                 "from compras where auto=@auto"

            Dim xsql_3 As String = "select codigo, nombre, cantidad, empaque, codigo_deposito, costo_bruto costoxunid, descuento1p " & _
                                                 ",descuento2p, descuento3p, tasa, total_neto, detalle, costo_final, costo_inventario, contenido_empaque, n_montoimplicor impuestolicor " & _
                                                 ",costo,bono from compras_detalle where auto_documento=@auto"

            xp1 = New SqlParameter("@auto", xauto)
            xp2 = New SqlParameter("@auto", xauto)
            xp3 = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql_2, dtb_compras, xp1)
            g_MiData.F_GetData(xsql_3, dtb_compras_detalle, xp2)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_compras)
            dts.Tables.Add(dtb_compras_detalle)

            Dim xlista As New List(Of _Reportes.ParamtCrystal)
            xlista.Add(New _Reportes.ParamtCrystal("@guarismo", Guarismo(dtb_compras.Rows(0)("total").ToString)))

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "rep_documento_compra.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlista)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function


    Class Registro
        Dim mFecha As String
        Dim NRF As String
        Dim FactInicio As String
        Dim FactFin As String
        Dim NCInicio As String
        Dim NCFin As String
        Dim NroFactAfect As String
        Dim TotalIVS As Decimal
        Dim Exento As Decimal
        Dim TotalBase1 As Decimal
        Dim TotalImpuesto1 As Decimal
        Dim TotalBase2 As Decimal
        Dim TotalImpuesto2 As Decimal
        Dim TotalBase3 As Decimal
        Dim TotalImpuesto3 As Decimal
        Dim Signo As Integer
        Dim CI_RIF As String
        Dim RazonSocial As String
        Dim tasa1 As Decimal
        Dim tasa2 As Decimal
        Dim tasa3 As Decimal
        Dim nro_control As String
        Dim retencion_iva As Decimal    'anexada el 01/10/2010
        Dim NDInicio As String          'anexada el 05/10/2010
        Dim NDFin As String             'anexada el 05/10/2010
        Dim Planilla_Import As String   'anexada el 05/10/2010
        Dim Expediente As String        'anexada el 05/10/2010
        Dim TipoProveedor As String        'anexada el 05/10/2010
        Dim TipoTrans As String             'anexada el 28/01/2011

        Dim xFechaRetIva As String
        Dim xCompRetIva As String

        'Propiedad Anexada el 01/10/2010
        Property RetencionIva() As Decimal
            Get
                Return retencion_iva
            End Get
            Set(ByVal value As Decimal)
                retencion_iva = value
            End Set
        End Property
        'Fin de comentario propiedad anexada 01/10/2010

        Property FechaRetencionIva() As String
            Get
                Return xFechaRetIva
            End Get
            Set(ByVal value As String)
                xFechaRetIva = value
            End Set
        End Property

        Property ComprobanteRetIva() As String
            Get
                Return xCompRetIva
            End Get
            Set(ByVal value As String)
                xCompRetIva = value
            End Set
        End Property

        'Propiedad Anexada el 05/10/2010
        Property NotaDebito_Inicio() As String
            Get
                Return NDInicio
            End Get
            Set(ByVal value As String)
                NDInicio = value
            End Set
        End Property

        Property NotaDebito_Fin() As String
            Get
                Return NDFin
            End Get
            Set(ByVal value As String)
                NDFin = value
            End Set
        End Property

        Property Planilla_Importacion() As String
            Get
                Return Planilla_Import
            End Get
            Set(ByVal value As String)
                Planilla_Import = value
            End Set
        End Property

        Property Numero_Expediente() As String
            Get
                Return Expediente
            End Get
            Set(ByVal value As String)
                Expediente = value
            End Set
        End Property

        Property Tipo_Proveedor() As String
            Get
                Return TipoProveedor
            End Get
            Set(ByVal value As String)
                TipoProveedor = value
            End Set
        End Property
        'Fin de comentario propiedad anexada 05/10/2010

        Property TasaNro2() As Decimal
            Get
                Return tasa2
            End Get
            Set(ByVal value As Decimal)
                tasa2 = value
            End Set
        End Property

        Property TasaNro1() As Decimal
            Get
                Return tasa1
            End Get
            Set(ByVal value As Decimal)
                tasa1 = value
            End Set
        End Property

        Property TasaNro3() As Decimal
            Get
                Return tasa3
            End Get
            Set(ByVal value As Decimal)
                tasa3 = value
            End Set
        End Property

        Property NroControlFactura() As String
            Get
                Return nro_control
            End Get
            Set(ByVal value As String)
                nro_control = value
            End Set
        End Property

        Property Rif_CI() As String
            Get
                Return CI_RIF
            End Get
            Set(ByVal value As String)
                CI_RIF = value.Trim
            End Set
        End Property

        Property p_RazonSocial() As String
            Get
                Return RazonSocial
            End Get
            Set(ByVal value As String)
                RazonSocial = value.Trim
            End Set
        End Property

        Property SignoRegistro() As Integer
            Get
                Return Signo
            End Get
            Set(ByVal value As Integer)
                Signo = value
            End Set
        End Property


        Property FechaRegistro() As String
            Get
                Return mFecha
            End Get
            Set(ByVal value As String)
                mFecha = value.Trim
            End Set
        End Property

        Property NumeroImpFiscal() As String
            Get
                Return NRF
            End Get
            Set(ByVal value As String)
                NRF = value.Trim
            End Set
        End Property

        Property InicioFactura() As String
            Get
                Return FactInicio
            End Get
            Set(ByVal value As String)
                FactInicio = value.Trim
            End Set
        End Property

        Property FinFactura() As String
            Get
                Return FactFin
            End Get
            Set(ByVal value As String)
                FactFin = value.Trim
            End Set
        End Property

        Property InicioNC() As String
            Get
                Return NCInicio
            End Get
            Set(ByVal value As String)
                NCInicio = value.Trim
            End Set
        End Property

        Property FinNC() As String
            Get
                Return NCFin
            End Get
            Set(ByVal value As String)
                NCFin = value.Trim
            End Set
        End Property

        Property NroFacturaAfectada() As String
            Get
                Return NroFactAfect
            End Get
            Set(ByVal value As String)
                NroFactAfect = value.Trim
            End Set
        End Property

        Property TotalFull() As Decimal
            Get
                Return TotalIVS
            End Get
            Set(ByVal value As Decimal)
                TotalIVS = value
            End Set
        End Property

        Property TotalExento() As Decimal
            Get
                Return Exento
            End Get
            Set(ByVal value As Decimal)
                Exento = value
            End Set
        End Property

        Property mTotalBase1() As Decimal
            Get
                Return TotalBase1
            End Get
            Set(ByVal value As Decimal)
                TotalBase1 = value
            End Set
        End Property

        Property mTotalImpuesto1() As Decimal
            Get
                Return TotalImpuesto1
            End Get
            Set(ByVal value As Decimal)
                TotalImpuesto1 = value
            End Set
        End Property

        Property mTotalBase2() As Decimal
            Get
                Return TotalBase2
            End Get
            Set(ByVal value As Decimal)
                TotalBase2 = value
            End Set
        End Property

        Property mTotalImpuesto2() As Decimal
            Get
                Return TotalImpuesto2
            End Get
            Set(ByVal value As Decimal)
                TotalImpuesto2 = value
            End Set
        End Property

        Property mTotalBase3() As Decimal
            Get
                Return TotalBase3
            End Get
            Set(ByVal value As Decimal)
                TotalBase3 = value
            End Set
        End Property

        Property mTotalImpuesto3() As Decimal
            Get
                Return TotalImpuesto3
            End Get
            Set(ByVal value As Decimal)
                TotalImpuesto3 = value
            End Set
        End Property

        Property mTipoTrans() As String
            Get
                Return TipoTrans
            End Get
            Set(ByVal value As String)
                TipoTrans = value
            End Set
        End Property

        Sub New()
            mFecha = ""
            NRF = ""
            FactInicio = ""
            FactFin = ""
            NCInicio = ""
            NCFin = ""
            NroFactAfect = ""
            TotalIVS = 0
            Exento = 0
            TotalBase1 = 0
            TotalImpuesto1 = 0
            TotalBase2 = 0
            TotalImpuesto2 = 0
            TotalBase3 = 0
            TotalImpuesto3 = 0
            CI_RIF = ""
            RazonSocial = ""
            tasa1 = 0
            tasa2 = 0
            tasa3 = 0
            nro_control = ""
            retencion_iva = 0       'anexado el 01/10/2010
            NDInicio = ""           'anexada el 05/10/2010
            NDFin = ""              'anexada el 05/10/2010
            Planilla_Import = ""    'anexada el 05/10/2010
            Expediente = ""         'anexada el 05/10/2010
            TipoProveedor = ""      'anexada el 05/10/2010
            TipoTrans = ""          'anexada el 28/01/2011
            xCompRetIva = ""        'anexada el 28/01/2011
        End Sub
    End Class

    Dim MiDataSet As Data.DataSet
    Dim MiDataTablaCabecera As Data.DataTable
    Dim MiDataTablaDetalle As Data.DataTable

    Sub EjecutarReportesVentasResumen(ByVal mDesde As Date, ByVal mHasta As Date, ByVal CodReport As String)
        Dim i As Single = 0
        Dim MisRegistros As Registro
        Dim MiDataSetTemporal As New Data.DataSet
        Dim mTipo As String

        Try
            MiDataSetTemporal = DevolverConsulta(mDesde, mHasta, CodReport)
            If MiDataSetTemporal.Tables(0).Rows.Count - 1 >= 0 Then
                CrearTablaTemporal()
                ArmarCabecera(mDesde, mHasta)

                For i = 0 To MiDataSetTemporal.Tables(0).Rows.Count - 1
                    mTipo = MiDataSetTemporal.Tables(0).Rows(i).Item(11)
                    MisRegistros = New Registro
                    'devolvio registros
                    MisRegistros.FechaRegistro = Strings.Left(MiDataSetTemporal.Tables(0).Rows(i).Item(0), 10)
                    MisRegistros.NumeroImpFiscal = MiDataSetTemporal.Tables(0).Rows(i).Item(1)
                    MisRegistros.TotalFull = MiDataSetTemporal.Tables(0).Rows(i).Item(5)
                    MisRegistros.TotalExento = MiDataSetTemporal.Tables(0).Rows(i).Item(6)
                    MisRegistros.mTotalBase1 = MiDataSetTemporal.Tables(0).Rows(i).Item(7)
                    MisRegistros.mTotalImpuesto1 = MiDataSetTemporal.Tables(0).Rows(i).Item(8)
                    MisRegistros.mTotalBase2 = MiDataSetTemporal.Tables(0).Rows(i).Item(9)
                    MisRegistros.mTotalImpuesto2 = MiDataSetTemporal.Tables(0).Rows(i).Item(10)
                    MisRegistros.SignoRegistro = MiDataSetTemporal.Tables(0).Rows(i).Item(12)
                    MisRegistros.mTotalBase3 = MiDataSetTemporal.Tables(0).Rows(i).Item(14)
                    MisRegistros.mTotalImpuesto3 = MiDataSetTemporal.Tables(0).Rows(i).Item(15)
                    MisRegistros.TasaNro1 = MiDataSetTemporal.Tables(0).Rows(i).Item(16)
                    MisRegistros.TasaNro2 = MiDataSetTemporal.Tables(0).Rows(i).Item(17)
                    MisRegistros.TasaNro3 = MiDataSetTemporal.Tables(0).Rows(i).Item(18)

                    If IsDBNull(MiDataSetTemporal.Tables(0).Rows(i).Item(13)) Then
                        MisRegistros.RetencionIva = 0
                    Else
                        MisRegistros.RetencionIva = MiDataSetTemporal.Tables(0).Rows(i).Item(13) 'anexada el 01/10/2010
                    End If
                    MisRegistros.mTipoTrans = MiDataSetTemporal.Tables(0).Rows(i).Item(11) 'anexada el 28/01/2011

                    If mTipo = "01" Then
                        'documento de factura, pedir la primera y ultima factura
                        MisRegistros.InicioFactura = MiDataSetTemporal.Tables(0).Rows(i).Item(2)
                        MisRegistros.FinFactura = MiDataSetTemporal.Tables(0).Rows(i).Item(3)

                    ElseIf mTipo = "03" Then
                        'documento de nota de credito, pedir la primera y ultima nota de credito
                        MisRegistros.NroFacturaAfectada = MiDataSetTemporal.Tables(0).Rows(i).Item(4).ToString
                        MisRegistros.InicioNC = MiDataSetTemporal.Tables(0).Rows(i).Item(2).ToString
                        MisRegistros.FinNC = MiDataSetTemporal.Tables(0).Rows(i).Item(3).ToString
                    End If
                    AgregarFila(MisRegistros)
                Next
                LlamarVisorCrystal(CodReport)
            Else
                MessageBox.Show("No Se Encontraron Resultados Para Este Rango De Fechas Solicitadas", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function DevolverConsulta(ByVal mDesde As Date, ByVal mHasta As Date, ByVal CodReport As String) As Data.DataSet
        Dim MiSQL As String
        Dim MiOrdenamientoSQL As String = ""
        Dim ds As New DataSet

        If CodReport.ToString.ToUpper = UCase("reporte1") Then
            MiOrdenamientoSQL = " order by nrf,fecha"
        ElseIf CodReport.ToString.ToUpper = UCase("reporte2") Then
            MiOrdenamientoSQL = " order by fecha,nrf"
        End If

        MiSQL = " select v.fecha, nrf, v.documento as inicio, v.documento as final, " & _
                    "'' as aplica, 0 as total, 0 as exento, 0  as base1, 0 as impuesto1," & _
                    "0 as base2, 0  as impuesto2, v.tipo as TipoDocumento, 1 as signo, rvd.retencion as retencion_iva, 0 as base3, 0 as impuesto3, 0 as tasa1, 0 as tasa2, 0 as tasa3 " & _
                    "from ventas v join retenciones_ventas_detalle rvd on rvd.auto_documento=v.auto " & _
                    "where rvd.fecha_retencion>=@mdesde and rvd.fecha_retencion<=@mhasta and rvd.fecha<@mdesde " & _
                    "UNION " & _
                 " select V.fecha," & _
                    "  v.nrf," & _
                    " min(v.documento) as inicio," & _
                    " max(v.documento) as final, " & _
                    " '' as aplica," & _
                    " sum(v.total) as total," & _
                    " sum(v.exento)as exento ," & _
                    " sum(v.base1) as base1," & _
                    " sum(v.impuesto1) as impuesto1," & _
                    " sum(v.base2)as base2," & _
                    " sum(v.impuesto2) as impuesto2," & _
                    " v.tipo as TipoDocumento, 1 as signo, sum(rvd.retencion) as retencion_iva, " & _
                    " sum(v.base3)as base3," & _
                    " sum(v.impuesto3) as impuesto3, v.tasa1, v.tasa2, v.tasa3 " & _
                    " from ventas v left outer join retenciones_ventas_detalle rvd on rvd.auto_documento=v.auto and " & _
                    " rvd.fecha>=@mdesde and rvd.fecha<=@mhasta and rvd.fecha_retencion>=@mdesde and rvd.fecha_retencion <=@mhasta " & _
                    " where (v.fecha between @mDesde AND  @mHasta) AND v.tipo='01' and v.estatus='0' " & _
                   " group by v.nrf,v.fecha,v.tipo, v.tasa1, v.tasa2, v.tasa3 " & _
                " UNION " & _
                " select fecha," & _
                        " nrf," & _
                        " documento as inicio," & _
                        " documento as fin," & _
                        " aplica ," & _
                        " (total) as total," & _
                        " (exento) as exento ," & _
                        " (base1) as base1," & _
                        " (impuesto1) as impuesto1," & _
                        " (base2) as base2," & _
                        " (impuesto2)as impuesto2," & _
                        " tipo as TipoDocumento, -1 as signo, retencion_iva, " & _
                        " (base3) as base3," & _
                        " (impuesto3)as impuesto3, tasa1, tasa2,tasa3 " & _
                            " from ventas " & _
                       " where fecha between @mDesde AND  @mHasta " & _
                            " AND ( tipo='02' OR tipo='03') and estatus='0' "

        MiSQL = MiSQL & " " & MiOrdenamientoSQL
        Dim xp1 As New SqlParameter("@mdesde", mDesde)
        Dim xp2 As New SqlParameter("@mhasta", mHasta)
        g_MiData.F_GetData(MiSQL, ds, xp1, xp2)
        Return ds
    End Function

    Sub CrearTablaTemporal()
        MiDataTablaCabecera = New Data.DataTable("Cabecera_Reporte")
        MiDataTablaDetalle = New Data.DataTable("Detalle_Reporte")
        MiDataSet = New Data.DataSet

        '"Tabla Detalle"
        MiDataTablaDetalle.Columns.Add("Nro_Oper", GetType(Integer))
        MiDataTablaDetalle.Columns.Add("Fecha", GetType(String))
        MiDataTablaDetalle.Columns.Add("Rif_CI", GetType(String))
        MiDataTablaDetalle.Columns.Add("RazonSocial", GetType(String))
        MiDataTablaDetalle.Columns.Add("NRF", GetType(String))
        MiDataTablaDetalle.Columns.Add("NRDiario", GetType(String))
        MiDataTablaDetalle.Columns.Add("FactInicio", GetType(String))
        MiDataTablaDetalle.Columns.Add("FactFin", GetType(String))
        MiDataTablaDetalle.Columns.Add("NCInicio", GetType(String))
        MiDataTablaDetalle.Columns.Add("NCFin", GetType(String))
        MiDataTablaDetalle.Columns.Add("TipoTrans", GetType(String))
        MiDataTablaDetalle.Columns.Add("NroFactAfect", GetType(String))
        MiDataTablaDetalle.Columns.Add("TotalIVS", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("Exento", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("TotalBase1", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("TotalImpuesto1", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("TotalBase2", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("TotalImpuesto2", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("Col75", GetType(String))
        MiDataTablaDetalle.Columns.Add("RetencionIva", GetType(Decimal)) 'modificada de string a decimal 01/10/2010
        MiDataTablaDetalle.Columns.Add("NroComprbRet", GetType(String))
        MiDataTablaDetalle.Columns.Add("FechaComprbRet", GetType(String))
        MiDataTablaDetalle.Columns.Add("Signo", GetType(Integer))
        MiDataTablaDetalle.Columns.Add("Tasa1", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("Tasa2", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("NroControlFact", GetType(String))
        MiDataTablaDetalle.Columns.Add("Planilla_Importacion", GetType(String))  'columna anexada 05/10/2010
        MiDataTablaDetalle.Columns.Add("Expediente", GetType(String))       'columna anexada 05/10/2010
        MiDataTablaDetalle.Columns.Add("NDInicio", GetType(String))         'columna anexada 05/10/2010
        MiDataTablaDetalle.Columns.Add("NDFin", GetType(String))            'columna anexada 05/10/2010
        MiDataTablaDetalle.Columns.Add("TipoProveedor", GetType(String))    'columna anexada 05/10/2010

        MiDataTablaDetalle.Columns("Nro_Oper").AutoIncrement = True
        MiDataTablaDetalle.Columns("Nro_Oper").AutoIncrementSeed = 1

        MiDataTablaDetalle.Columns.Add("Tasa3", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("TotalBase3", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("TotalImpuesto3", GetType(Decimal))

        '"Tabla Cabecera"
        MiDataTablaCabecera.Columns.Add("NombreCliente", GetType(String))
        MiDataTablaCabecera.Columns.Add("RifCliente", GetType(String))
        MiDataTablaCabecera.Columns.Add("NitCliente", GetType(String))
        MiDataTablaCabecera.Columns.Add("FechaDesde", GetType(Date))
        MiDataTablaCabecera.Columns.Add("FechaHasta", GetType(Date))
        MiDataTablaCabecera.Columns.Add("ImprsFiscal", GetType(String))

        MiDataSet.Tables.Add(MiDataTablaDetalle)
        MiDataSet.Tables.Add(MiDataTablaCabecera)
    End Sub

    Sub ArmarCabecera(ByVal mDesde As Date, ByVal mHasta As Date)
        Dim i As Integer = 0
        Dim Impresoras As String = ""
        Dim dr As Data.DataRow = MiDataTablaCabecera.NewRow
        Dim MiDataSetCabecera As New Data.DataSet

        'MiDataSetCabecera = New Data.DataSet
        MiDataSetCabecera = DevolverDatosCliente(mDesde, mHasta)
        If MiDataSetCabecera.Tables(0).Rows.Count - 1 >= 0 Then
            'obtener los datos
            If MiDataSetCabecera.Tables(1).Rows.Count - 1 >= 0 Then
                For i = 0 To MiDataSetCabecera.Tables(1).Rows.Count - 1
                    Try

                        Impresoras = Impresoras & "  /  " & MiDataSetCabecera.Tables(1).Rows(i).Item(0).ToString

                    Catch ex As Exception

                    End Try
                Next
                dr("NombreCliente") = MiDataSetCabecera.Tables(0).Rows(0).Item(0).ToString
                dr("RifCliente") = MiDataSetCabecera.Tables(0).Rows(0).Item(1).ToString
                dr("NitCliente") = MiDataSetCabecera.Tables(0).Rows(0).Item(2).ToString
                dr("FechaDesde") = mDesde.ToString  'DateSerial(CInt(mAno), CInt(mMes) + 0, 1)
                dr("FechaHasta") = mHasta.ToString  'DateSerial(CInt(mAno), CInt(mMes) + 1, 0)
                dr("ImprsFiscal") = Impresoras
                MiDataTablaCabecera.Rows.Add(dr)
            End If
        End If
    End Sub

    Private Function DevolverDatosCliente(ByVal mDesde As Date, ByVal mHasta As Date) As Data.DataSet
        Dim MiSQL As String
        Dim ds As New DataSet

        MiSQL = " select nombre, rif, nit" & _
                " from empresa" & _
                " select distinct nrf " & _
                " from ventas " & _
                " where fecha between @mDesde AND  @mHasta"

        Dim xp1 As New SqlParameter("@mdesde", mDesde)
        Dim xp2 As New SqlParameter("@mhasta", mHasta)
        g_MiData.F_GetData(MiSQL, ds, xp1, xp2)
        Return ds
    End Function

    Sub AgregarFila(ByVal MiRegistro As Registro)
        Dim dr As Data.DataRow = MiDataTablaDetalle.NewRow
        dr("Fecha") = MiRegistro.FechaRegistro
        dr("Rif_CI") = MiRegistro.Rif_CI
        dr("RazonSocial") = IIf(MiRegistro.p_RazonSocial <> "", MiRegistro.p_RazonSocial, "RESUMEN Z DIARIO")
        dr("NRF") = MiRegistro.NumeroImpFiscal
        dr("NRDiario") = ""             'NO SE LE PASA NADA
        dr("FactInicio") = MiRegistro.InicioFactura
        dr("FactFin") = MiRegistro.FinFactura
        dr("NCInicio") = MiRegistro.InicioNC
        dr("NCFin") = MiRegistro.FinNC
        dr("TipoTrans") = MiRegistro.mTipoTrans ' "1" 'aca es donde hay que modificar
        dr("NroFactAfect") = MiRegistro.NroFacturaAfectada
        dr("TotalIVS") = MiRegistro.TotalFull
        dr("Exento") = MiRegistro.TotalExento
        dr("TotalBase1") = MiRegistro.mTotalBase1
        dr("TotalImpuesto1") = MiRegistro.mTotalImpuesto1
        dr("TotalBase2") = MiRegistro.mTotalBase2
        dr("TotalImpuesto2") = MiRegistro.mTotalImpuesto2
        dr("Col75") = ""                'NO SE LE PASA NADA TASA_IVA_RET
        dr("RetencionIva") = MiRegistro.RetencionIva 'anexada el 01/10/2010 'MONTO
        dr("NroComprbRet") = MiRegistro.ComprobanteRetIva '  ""         'NO SE LE PASA NADA DOCUMENTO RET IVA
        dr("FechaComprbRet") = MiRegistro.FechaRetencionIva '""       'NO SE LE PASA NADA FECHA DOCUMENTO RET IVA
        dr("Signo") = MiRegistro.SignoRegistro

        'bloque anexado el 06/10/2010
        dr("Tasa1") = MiRegistro.TasaNro1
        dr("Tasa2") = MiRegistro.TasaNro2
        dr("NroControlFact") = MiRegistro.NroControlFactura
        dr("Planilla_Importacion") = MiRegistro.Planilla_Importacion
        dr("Expediente") = MiRegistro.Numero_Expediente
        dr("NDInicio") = MiRegistro.NotaDebito_Inicio
        dr("NDFin") = MiRegistro.NotaDebito_Fin
        dr("TipoProveedor") = MiRegistro.Tipo_Proveedor
        'fin bloque anexado el 06/10/2010

        dr("Tasa3") = MiRegistro.TasaNro3
        dr("TotalBase3") = MiRegistro.mTotalBase3
        dr("TotalImpuesto3") = MiRegistro.mTotalImpuesto3

        MiDataTablaDetalle.Rows.Add(dr)
    End Sub

    Private Sub LlamarVisorCrystal(ByVal NombreReporte As String, Optional ByVal xds As DataSet = Nothing)
        Try
            If Not IsNothing(xds) Then
                MiDataSet = xds
            End If

            If MiDataSet.Tables(0).Rows.Count - 1 >= 0 And MiDataSet.Tables(1).Rows.Count - 1 >= 0 Then
                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                If NombreReporte.ToString.ToUpper = "REPORTE1" Then
                    'xrep += "RPT_VENTAS_RESUMEN_AGRP_MAQUINA.rpt"
                    xrep += "LIBRO_VENTAS_AGRUPADO.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE2" Then
                    xrep += "RPT_VENTAS_RESUMEN_FECH_AGRP_MAQUINA.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE3" Then
                    xrep += "RPT_VENTAS_RESUMEN_MAQUINA.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE4" Then
                    xrep += "RPT_VENTAS_DETALLE_CONTR_AGRP_MAQUINA.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE5" Then
                    xrep += "RPT_VENTAS_DETALLE_CONTR_AGRP_FECH_MAQUINA.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE6" Then
                    xrep += "RPT_VENTAS_DETALLE_CONTR_MAQUINA.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE7" Then
                    xrep += "RPT_VENTAS_CONTR_NOCONTR.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE8" Then
                    xrep += "RPT_VENTAS_VENDEDOR.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE9" Then
                    xrep += "RPT_VENTAS_CONTR_NOCONTR_V2.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE10" Then 'anexada 04/10/2010
                    xrep += "RPT_VENTAS_CONTR_NOCONTR_V3.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE11" Then 'anexada 06/10/2010
                    xrep += "RPT_COMPRAS_RESUMEN_AGRP_MAQUINA.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE12" Then 'anexada 14/02/2011
                    xrep += "RPT_VENTAS_GRUPO_DETALLADO.rpt"
                ElseIf NombreReporte.ToString.ToUpper = "REPORTE0" Then 'anexada 03/04/2012
                    'xrep += "RPT_VENTAS_CONTR_NOCONTR.rpt"
                    xrep += "LIBRO_VENTAS.rpt"
                End If

                Dim xreporte As New _Reportes(MiDataSet, xrep, Nothing)
                With xreporte
                    .ShowDialog()
                End With
            Else
                Funciones.MensajeDeAlerta("No Se Encontraron Resultados Para Este Rango De Fechas Solicitadas")
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub EjecutarReportesVentasDetallado(ByVal mDesde As Date, ByVal mHasta As Date, ByVal CodReport As String)
        Try
            Dim t1 As New DataTable
            Dim t2 As New DataTable
            Dim t3 As New DataTable
            Dim xsql As String
            Dim xsql2 As String
            Dim xsqlOrder As String = ""

            If CodReport.ToString.ToUpper = UCase("Reporte4") Then
                xsqlOrder = "NRF,FECHA"
            ElseIf CodReport.ToString.ToUpper = UCase("Reporte5") Or CodReport.ToString.ToUpper = UCase("Reporte6") Then
                xsqlOrder = "FECHA,NRF"
            End If

            xsql = "SELECT  v.NOMBRE, v.CI_RIF, v.DOCUMENTO as Inicio, v.DOCUMENTO as Final, v.NRF, v.FECHA, v.aplica," _
               + "0.0 tot, 0.0 exento, 0.0 base1, 0.0 impuesto1, 0.0 base2, 0.0 impuesto2, v.tipo, 1 signo," _
               + "rv.fecha fecha_ret, rvd.retencion retencion_iva ,rvd.comprobante " _
               + "from ventas v join retenciones_ventas_detalle rvd on rvd.auto_documento=v.auto join retenciones_ventas rv on rvd.auto = rv.auto " _
               + "where rv.fecha_relacion>=@desde and rv.fecha_relacion<=@hasta and (MONTH(rv.fecha)!=MONTH(rv.fecha_relacion) or YEAR(rv.fecha)!=YEAR(rv.fecha_relacion)) " _
         + "UNION " _
         + "SELECT 'RESUMEN DIARIO Z' AS NOMBRE, '' AS CI_RIF, MIN(DOCUMENTO) as Inicio, " _
                + "MAX(DOCUMENTO) as Final, nrf, FECHA, '' as aplica, sum(total) as tot," _
                + "sum(exento)as exento, sum(base1) as base1, sum(impuesto1) as impuesto1," _
                + "sum(base2) as base2, sum(impuesto2) as impuesto2, tipo, 1 signo, null fecha_ret," _
                + "0.00 retencion_iva, '' comprobante " _
                + "FROM VENTAS where tipo='01' and fecha>=@desde and fecha<=@hasta and estatus='0' " _
                + " GROUP BY " & xsqlOrder & ",tipo " _
         + "UNION " _
         + "SELECT NOMBRE,ci_rif, DOCUMENTO as Inicio, DOCUMENTO as Final, NRF, FECHA," _
                + "aplica, total tot, exento, base1, impuesto1, base2, impuesto2, tipo," _
                + "-1 signo, null fecha_ret, retencion_iva, '' comprobante " _
                + "FROM VENTAS where fecha>=@desde and fecha<=@hasta and TIPO='03' and estatus='0' "
            xsql = xsql & " ORDER BY " & xsqlOrder & ",tipo"

            xsql2 = "SELECT v.nombre, v.ci_rif, v.DOCUMENTO as Inicio, v.DOCUMENTO as Final, v.NRF, v.FECHA," _
                    + "v.aplica, v.total tot, v.exento, v.base1, v.impuesto1, v.base2, v.impuesto2, v.tipo," _
                    + "1 signo, " _
                    + "(select rv.fecha from retenciones_ventas rv join retenciones_ventas_detalle rvd on rv.auto=rvd.auto where rvd.auto_documento=v.auto and MONTH(rv.fecha_relacion)=MONTH(v.fecha) and YEAR(rv.fecha_relacion)=year(v.fecha)) fecha_ret," _
                    + "(select rvd.retencion from retenciones_ventas rv join retenciones_ventas_detalle rvd on rv.auto=rvd.auto where rvd.auto_documento=v.auto and MONTH(rv.fecha_relacion)=MONTH(v.fecha) and YEAR(rv.fecha_relacion)=year(v.fecha)) retencion_iva," _
                    + "(select rvd.comprobante from retenciones_ventas rv join retenciones_ventas_detalle rvd on rv.auto=rvd.auto where rvd.auto_documento=v.auto and MONTH(rv.fecha_relacion)=MONTH(v.fecha) and YEAR(rv.fecha_relacion)=year(v.fecha)) comprobante " _
                    + "from ventas v where v.fecha >=@desde and v.fecha <=@hasta and v.TIPO='01' and len(v.ci_rif)>=12 and estatus='0' order by v.fecha,v.nrf,v.documento asc"

            Dim xp1 As New SqlParameter("@desde", mDesde)
            Dim xp2 As New SqlParameter("@hasta", mHasta)
            g_MiData.F_GetData(xsql, t1, xp1, xp2)

            Dim sp1 As New SqlParameter("@desde", mDesde)
            Dim sp2 As New SqlParameter("@hasta", mHasta)
            g_MiData.F_GetData(xsql2, t2, sp1, sp2)

            t3.Columns.Add("RazonSocial", GetType(System.String))   '0
            t3.Columns.Add("CI_RIF", GetType(System.String))        '1
            t3.Columns.Add("Inicio", GetType(System.String))        '2
            t3.Columns.Add("Final", GetType(System.String))         '3
            t3.Columns.Add("nrf", GetType(System.String))           '4
            t3.Columns.Add("fecha", GetType(System.DateTime))       '5
            t3.Columns.Add("Aplica", GetType(System.String))        '6
            t3.Columns.Add("tot", GetType(System.Decimal))          '7
            t3.Columns.Add("exento", GetType(System.Decimal))       '8
            t3.Columns.Add("base1", GetType(System.Decimal))        '9
            t3.Columns.Add("impuesto1", GetType(System.Decimal))    '10
            t3.Columns.Add("base2", GetType(System.Decimal))        '11
            t3.Columns.Add("impuesto2", GetType(System.Decimal))    '12
            t3.Columns.Add("TipoDocumento", GetType(System.String)) '13
            t3.Columns.Add("signo", GetType(System.Int32))          '14

            t3.Columns.Add("FechaComprbRet", GetType(System.String))       '15
            t3.Columns.Add("RetencionIva", GetType(System.Decimal))        '16
            t3.Columns.Add("NroComprbRet", GetType(System.String))         '17

            Dim xtot As Decimal = 0
            For Each dr As DataRow In t1.Rows
                xtot += (dr("tot") * dr("signo"))

                Dim xv As Boolean = False
                Dim vinicial As String = dr("Inicio")
                Dim xt As New DataTable
                Dim xsql3 As String = ""
                Dim xsql4 As String = ""
                Dim xsql5 As String = ""

                xsql3 = "SELECT 'RESUMEN DIARIO Z' AS NOMBRE,'' AS CI_RIF, MIN(DOCUMENTO) as Inicio, MAX(DOCUMENTO), NRF,FECHA,'' as aplica, sum(total) tot,sum(exento),sum(base1),sum(impuesto1),sum(base2),sum(impuesto2),tipo , 1 signo,'' fecha_ret,0.00 retencion_iva,'' comprobante " _
                + "FROM VENTAS WHERE DOCUMENTO IN (SELECT DOCUMENTO FROM VENTAS WHERE FECHA=@fecha AND NRF=@nrf AND DOCUMENTO>=@n1 AND DOCUMENTO<@n2 and tipo='01' and estatus='0' ) " _
                + "GROUP BY " & xsqlOrder & ",TIPO ORDER BY " & xsqlOrder & " ,TIPO"

                xsql4 = "SELECT 'RESUMEN DIARIO Z' AS NOMBRE, '' AS CI_RIF, MIN(DOCUMENTO) as Inicio, MAX(DOCUMENTO), NRF,FECHA,'' as aplica, sum(total) tot,sum(exento),sum(base1),sum(impuesto1),sum(base2),sum(impuesto2),tipo , 1 signo,'' fecha_ret,0.00 retencion_iva,'' comprobante " _
                + "FROM VENTAS WHERE DOCUMENTO IN (SELECT DOCUMENTO FROM VENTAS WHERE FECHA=@fecha AND NRF=@nrf AND DOCUMENTO>@n1 AND DOCUMENTO<@n2 and tipo='01' and estatus='0') " _
                + "GROUP BY " & xsqlOrder & ",TIPO ORDER BY " & xsqlOrder & " ,TIPO"

                xsql5 = "SELECT 'RESUMEN DIARIO Z' AS NOMBRE,'' AS CI_RIF, MIN(DOCUMENTO) as Inicio, MAX(DOCUMENTO), NRF,FECHA,'' as aplica, sum(total) tot, sum(exento),sum(base1),sum(impuesto1),sum(base2),sum(impuesto2), tipo ,1 signo,'' fecha_ret,0.00 retencion_iva,'' comprobante " _
                + "FROM VENTAS WHERE DOCUMENTO IN (SELECT DOCUMENTO FROM VENTAS WHERE FECHA=@fecha AND NRF=@nrf AND DOCUMENTO>@n1 and tipo='01' and estatus='0' ) " _
                + "GROUP BY " & xsqlOrder & ",TIPO ORDER BY " & xsqlOrder & " ,TIPO"

                Dim xcuenta As Integer = 0
                For Each dr2 As DataRow In t2.Rows
                    If dr2("nrf") = dr("nrf") AndAlso dr2("fecha") = dr("fecha") Then
                        xv = True
                        xcuenta += 1

                        xt.Rows.Clear()
                        If xcuenta <= 1 Then
                            Dim tp1 As New SqlParameter("@fecha", dr2("fecha"))
                            Dim tp2 As New SqlParameter("@nrf", dr2("nrf"))
                            Dim tp3 As New SqlParameter("@n1", vinicial)
                            Dim tp4 As New SqlParameter("@n2", dr2("Inicio"))
                            g_MiData.F_GetData(xsql3, xt, tp1, tp2, tp3, tp4)
                        Else
                            Dim dp1 As New SqlParameter("@fecha", dr2("fecha"))
                            Dim dp2 As New SqlParameter("@nrf", dr2("nrf"))
                            Dim dp3 As New SqlParameter("@n1", vinicial)
                            Dim dp4 As New SqlParameter("@n2", dr2("Inicio"))
                            g_MiData.F_GetData(xsql4, xt, dp1, dp2, dp3, dp4)
                        End If

                        Dim xr As DataRow = xt.NewRow
                        xr(0) = dr2(0)
                        xr(1) = dr2(1)
                        xr(2) = dr2(2)
                        xr(3) = dr2(3)
                        xr(4) = dr2(4)
                        xr(5) = dr2(5)
                        xr(6) = dr2(6)
                        xr(7) = dr2(7)
                        xr(8) = dr2(8)
                        xr(9) = dr2(9)
                        xr(10) = dr2(10)
                        xr(11) = dr2(11)
                        xr(12) = dr2(12)
                        xr(13) = dr2(13)
                        xr(14) = dr2(14)

                        xr(15) = dr2(15)
                        xr(16) = dr2(16)
                        xr(17) = dr2(17)

                        xt.Rows.Add(xr)

                        vinicial = dr2("Inicio")
                        For Each l1 As DataRow In xt.Rows
                            Dim r As DataRow = t3.NewRow
                            r(0) = l1(0)
                            r(1) = l1(1)
                            r(2) = l1(2)
                            r(3) = l1(3)
                            r(4) = l1(4)
                            r(5) = l1(5)
                            r(6) = l1(6)
                            r(7) = l1(7)
                            r(8) = l1(8)
                            r(9) = l1(9)
                            r(10) = l1(10)
                            r(11) = l1(11)
                            r(12) = l1(12)
                            r(13) = l1(13)
                            r(14) = l1(14)

                            r(15) = l1(15)
                            r(16) = l1(16)
                            r(17) = l1(17)

                            t3.Rows.Add(r)
                        Next

                        dr2("nrf") = ""
                    End If
                Next

                If xv = False Then
                    Dim xr As DataRow = t3.NewRow
                    xr(0) = dr(0)
                    xr(1) = dr(1)
                    xr(2) = dr(2)
                    xr(3) = dr(3)
                    xr(4) = dr(4)
                    xr(5) = dr(5)
                    xr(6) = dr(6)
                    xr(7) = dr(7)
                    xr(8) = dr(8)
                    xr(9) = dr(9)
                    xr(10) = dr(10)
                    xr(11) = dr(11)
                    xr(12) = dr(12)
                    xr(13) = dr(13)
                    xr(14) = dr(14)

                    xr(15) = dr(15)
                    xr(16) = dr(16)
                    xr(17) = dr(17)
                    t3.Rows.Add(xr)
                Else
                    Dim xt2 As New DataTable
                    Dim zp1 As New SqlParameter("@fecha", dr("fecha"))
                    Dim zp2 As New SqlParameter("@nrf", dr("nrf"))
                    Dim zp3 As New SqlParameter("@n1", vinicial)
                    g_MiData.F_GetData(xsql5, xt2, zp1, zp2, zp3)

                    For Each r As DataRow In xt2.Rows
                        Dim xr As DataRow = t3.NewRow
                        xr(0) = r(0)
                        xr(1) = r(1)
                        xr(2) = r(2)
                        xr(3) = r(3)
                        xr(4) = r(4)
                        xr(5) = r(5)
                        xr(6) = r(6)
                        xr(7) = r(7)
                        xr(8) = r(8)
                        xr(9) = r(9)
                        xr(10) = r(10)
                        xr(11) = r(11)
                        xr(12) = r(12)
                        xr(13) = r(13)
                        xr(14) = r(14)

                        xr(15) = r(15)
                        xr(16) = r(16)
                        xr(17) = r(17)
                        t3.Rows.Add(xr)
                    Next
                    vinicial = ""
                End If
            Next

            CrearTablaTemporal()
            ArmarCabecera(mDesde, mHasta)
            Dim i As Integer
            Dim MisRegistros As Registro

            If t3.Rows.Count - 1 >= 0 Then
                'pasar los datos de esta tabla a la tabla del dataset
                For i = 0 To t3.Rows.Count - 1
                    MisRegistros = New Registro

                    MisRegistros.p_RazonSocial = t3.Rows(i).Item("RazonSocial")
                    MisRegistros.Rif_CI = t3.Rows(i).Item("CI_RIF")
                    If t3.Rows(i).Item("TipoDocumento") = "01" Then
                        MisRegistros.InicioFactura = t3.Rows(i).Item("Inicio")
                        MisRegistros.FinFactura = t3.Rows(i).Item("Final")
                    Else
                        MisRegistros.InicioNC = t3.Rows(i).Item("Inicio")
                        MisRegistros.FinNC = t3.Rows(i).Item("Final")
                        MisRegistros.NroFacturaAfectada = t3.Rows(i).Item("Aplica")
                    End If
                    MisRegistros.NumeroImpFiscal = t3.Rows(i).Item("nrf")
                    MisRegistros.FechaRegistro = t3.Rows(i).Item("fecha")
                    MisRegistros.TotalFull = t3.Rows(i).Item("tot")
                    MisRegistros.TotalExento = t3.Rows(i).Item("exento")
                    MisRegistros.mTotalBase1 = t3.Rows(i).Item("base1")
                    MisRegistros.mTotalImpuesto1 = t3.Rows(i).Item("impuesto1")
                    MisRegistros.mTotalBase2 = t3.Rows(i).Item("base2")
                    MisRegistros.mTotalImpuesto2 = t3.Rows(i).Item("impuesto2")
                    MisRegistros.SignoRegistro = t3.Rows(i).Item("signo")
                    MisRegistros.mTipoTrans = t3.Rows(i).Item("TipoDocumento") 'anexada 28/01/2011

                    If Not IsDBNull(t3.Rows(i).Item("FechaComprbRet")) Then
                        If t3.Rows(i).Item("FechaComprbRet") = "" Then
                        Else
                            MisRegistros.FechaRetencionIva = CType(t3.Rows(i).Item("FechaComprbRet"), Date)  't3.Rows(i).Item("FechaComprbRet")
                        End If
                    End If

                    If Not IsDBNull(t3.Rows(i).Item("NroComprbRet")) Then
                        MisRegistros.ComprobanteRetIva = t3.Rows(i).Item("NroComprbRet")
                    End If

                    If Not IsDBNull(t3.Rows(i).Item("RetencionIva")) Then
                        MisRegistros.RetencionIva = t3.Rows(i).Item("RetencionIva")
                    End If
                    AgregarFila(MisRegistros)
                Next
                LlamarVisorCrystal(CodReport)
            Else
                MessageBox.Show("No Se Encontraron Resultados Para Este Rango De Fechas", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub EjecutarReporteContribuyenteNoContribuyentes(ByVal mDesde As Date, ByVal mHasta As Date, ByVal CodReport As String)
        Try
            Dim t1 As New DataTable
            Dim t2 As New DataTable
            Dim t3 As New DataTable
            Dim xsql As String
            Dim xsql2 As String
            Dim xsqlOrder As String = ""

            xsqlOrder = "FECHA,NRF"

            xsql = "SELECT  v.NOMBRE, v.CI_RIF, v.DOCUMENTO as Inicio, v.DOCUMENTO as Final, v.NRF, v.FECHA, v.aplica," _
               + "0.0 as tot, 0.0 as exento, 0.0 as base1, 0.0 as impuesto1, 0.0 as base2, 0.0 as impuesto2, v.tipo, 1 as signo, v.tasa1, v.tasa2, '' as control," _
               + "rvd.fecha_retencion as fecha_ret, rvd.retencion as retencion_iva ,rvd.comprobante " _
               + "from ventas v join retenciones_ventas_detalle rvd on rvd.auto_documento=v.auto " _
               + "where rvd.fecha_retencion>=@desde and rvd.fecha_retencion<=@hasta and rvd.fecha<@desde " _
         + "UNION " _
         + "SELECT 'RESUMEN DIARIO Z' AS NOMBRE, '' AS CI_RIF, MIN(DOCUMENTO) as Inicio, " _
                + "MAX(DOCUMENTO) as Final, nrf, FECHA, '' as aplica, sum(total) as tot," _
                + "sum(exento)as exento, sum(base1) as base1, sum(impuesto1) as impuesto1," _
                + "sum(base2) as base2, sum(impuesto2) as impuesto2, tipo, 1 signo, tasa1, tasa2, '' control, null fecha_ret," _
                + "0.00 retencion_iva, '' comprobante " _
                + "FROM VENTAS where tipo='01' and fecha>=@desde and fecha<=@hasta and estatus='0' " _
                + " GROUP BY " & xsqlOrder & ",tipo,tasa1,tasa2 " _
         + "UNION " _
         + "SELECT NOMBRE,ci_rif, DOCUMENTO as Inicio, DOCUMENTO as Final, NRF, FECHA," _
                + "aplica, total tot, exento, base1, impuesto1, base2, impuesto2, tipo," _
                + "-1 signo, tasa1, tasa2, control, null fecha_ret, retencion_iva, '' comprobante " _
                + "FROM VENTAS where fecha>=@desde and fecha<=@hasta and TIPO='03' and estatus='0' "
            xsql = xsql & " ORDER BY " & xsqlOrder & ",tipo"

            'xsql2 = "SELECT v.nombre, v.ci_rif, v.DOCUMENTO as Inicio, v.DOCUMENTO as Final, v.NRF, v.FECHA," _
            '        + "v.aplica, v.total tot, v.exento, v.base1, v.impuesto1, v.base2, v.impuesto2, v.tipo," _
            '        + "1 signo, tasa1, tasa2, '' control," _
            '        + "(select rv.fecha from retenciones_ventas rv join retenciones_ventas_detalle rvd on rv.auto=rvd.auto where rvd.auto_documento=v.auto and MONTH(rv.fecha_relacion)=MONTH(v.fecha) and YEAR(rv.fecha_relacion)=year(v.fecha)) fecha_ret," _
            '        + "(select rvd.retencion from retenciones_ventas rv join retenciones_ventas_detalle rvd on rv.auto=rvd.auto where rvd.auto_documento=v.auto and MONTH(rv.fecha_relacion)=MONTH(v.fecha) and YEAR(rv.fecha_relacion)=year(v.fecha)) retencion_iva," _
            '        + "(select rvd.comprobante from retenciones_ventas rv join retenciones_ventas_detalle rvd on rv.auto=rvd.auto where rvd.auto_documento=v.auto and MONTH(rv.fecha_relacion)=MONTH(v.fecha) and YEAR(rv.fecha_relacion)=year(v.fecha)) comprobante " _
            '        + "from ventas v where v.fecha >=@desde and v.fecha <=@hasta and v.TIPO='01' and len(v.ci_rif)>=12 and estatus='0' order by v.fecha,v.nrf,v.documento asc"


            xsql2 = "with c as " & _
                        "(select v.nombre, v.ci_rif, v.DOCUMENTO as Inicio, v.DOCUMENTO as Final, v.NRF, v.FECHA, " & _
                        "        v.aplica, v.total AS tot, v.exento, v.base1, v.impuesto1, v.base2, v.impuesto2, v.tipo," & _
                        "        1 AS signo, tasa1, tasa2, '' control, rvd.fecha as fecha1 , rvd.retencion, rvd.comprobante  " & _
                        "        from ventas v left outer join retenciones_ventas_detalle rvd on rvd.auto_documento=v.auto and rvd.fecha_retencion >=@desde and rvd.fecha_retencion  <=@hasta " & _
                        "        where v.fecha >=@desde and v.fecha <=@hasta and v.TIPO='01' and len(v.ci_rif)>=12 and v.estatus='0') " & _
                    "select * from c " & _
                    "UNION " & _
                    "   select 'ANULADO' AS NOMBRE, '' AS CI_RIF, v.DOCUMENTO as Inicio, v.DOCUMENTO as Final, v.NRF, v.FECHA, " & _
                    "          v.aplica, 0 AS tot, 0 AS exento, 0 AS base1, 0 AS impuesto1, 0 AS base2, 0 AS impuesto2, v.tipo, " & _
                    "          1 as signo, tasa1, tasa2, '' AS control, null, null, null " & _
                    "          from ventas v where v.fecha >=@desde and v.fecha <=@hasta and v.TIPO='01' and v.estatus='1'" & _
                    "order by c.fecha,c.nrf, c.Inicio"

            Dim xp1 As New SqlParameter("@desde", mDesde)
            Dim xp2 As New SqlParameter("@hasta", mHasta)
            g_MiData.F_GetData(xsql, t1, xp1, xp2)

            xp1 = New SqlParameter("@desde", mDesde)
            xp2 = New SqlParameter("@hasta", mHasta)
            g_MiData.F_GetData(xsql2, t2, xp1, xp2)

            t3.Columns.Add("RazonSocial", GetType(System.String))       '0
            t3.Columns.Add("CI_RIF", GetType(System.String))            '1
            t3.Columns.Add("Inicio", GetType(System.String))            '2
            t3.Columns.Add("Final", GetType(System.String))             '3
            t3.Columns.Add("nrf", GetType(System.String))               '4
            t3.Columns.Add("fecha", GetType(System.DateTime))           '5
            t3.Columns.Add("Aplica", GetType(System.String))            '6
            t3.Columns.Add("tot", GetType(System.Decimal))              '7
            t3.Columns.Add("exento", GetType(System.Decimal))           '8
            t3.Columns.Add("base1", GetType(System.Decimal))            '9
            t3.Columns.Add("impuesto1", GetType(System.Decimal))        '10
            t3.Columns.Add("base2", GetType(System.Decimal))            '11
            t3.Columns.Add("impuesto2", GetType(System.Decimal))        '12
            t3.Columns.Add("TipoDocumento", GetType(System.String))     '13
            t3.Columns.Add("signo", GetType(System.Int32))              '14
            t3.Columns.Add("tasa1", GetType(System.Decimal))            '15
            t3.Columns.Add("tasa2", GetType(System.Decimal))            '16
            t3.Columns.Add("NroControlFact", GetType(System.String))    '17

            t3.Columns.Add("FechaComprbRet", GetType(System.String))       '19
            t3.Columns.Add("RetencionIva", GetType(System.Decimal))    '18 agregada 01/10/2010
            t3.Columns.Add("NroComprbRet", GetType(System.String))         '20

            Dim xtot As Decimal = 0
            For Each dr As DataRow In t1.Rows
                xtot += (dr("tot") * dr("signo"))

                Dim xv As Boolean = False
                Dim vinicial As String = dr("Inicio")
                Dim xt As New DataTable
                Dim xsql3 As String = ""
                Dim xsql4 As String = ""
                Dim xsql5 As String = ""

                xsql3 = "SELECT 'RESUMEN DIARIO Z' AS NOMBRE,'' AS CI_RIF, MIN(DOCUMENTO) as Inicio, MAX(DOCUMENTO), " _
                + "NRF,FECHA,'' as aplica, sum(total) tot,sum(exento),sum(base1),sum(impuesto1),sum(base2),sum(impuesto2)," _
                + "tipo , 1 signo, tasa1,tasa2,'' as control, '' as fecha_ret, 0.00 as retencion_iva, '' comprobante " _
                + "FROM VENTAS WHERE DOCUMENTO IN (SELECT DOCUMENTO FROM VENTAS WHERE FECHA=@fecha AND NRF=@nrf AND DOCUMENTO>=@n1 AND DOCUMENTO<@n2 and tipo='01' and estatus='0' ) " _
                + "GROUP BY " & xsqlOrder & ",TIPO,tasa1,tasa2 ORDER BY " & xsqlOrder & " ,TIPO"

                xsql4 = "SELECT 'RESUMEN DIARIO Z' AS NOMBRE, '' AS CI_RIF, MIN(DOCUMENTO) as Inicio, MAX(DOCUMENTO), " _
                + "NRF,FECHA,'' as aplica, sum(total) tot,sum(exento),sum(base1),sum(impuesto1),sum(base2),sum(impuesto2), " _
                + "tipo , 1 signo, tasa1,tasa2,'' as control, '' as fecha_ret, 0.00 as retencion_iva, '' comprobante  " _
                + "FROM VENTAS WHERE DOCUMENTO IN (SELECT DOCUMENTO FROM VENTAS WHERE FECHA=@fecha AND NRF=@nrf AND DOCUMENTO>@n1 AND DOCUMENTO<@n2 and tipo='01' and estatus='0') " _
                + "GROUP BY " & xsqlOrder & ",TIPO,tasa1,tasa2 ORDER BY " & xsqlOrder & " ,TIPO"

                xsql5 = "SELECT 'RESUMEN DIARIO Z' AS NOMBRE,'' AS CI_RIF, MIN(DOCUMENTO) as Inicio, MAX(DOCUMENTO), " _
                + "NRF,FECHA,'' as aplica, sum(total) tot, sum(exento),sum(base1),sum(impuesto1),sum(base2),sum(impuesto2), " _
                + "tipo ,1 signo, tasa1,tasa2,'' as control, '' as fecha_ret, 0.00 as retencion_iva, '' comprobante  " _
                + "FROM VENTAS WHERE DOCUMENTO IN (SELECT DOCUMENTO FROM VENTAS WHERE FECHA=@fecha AND NRF=@nrf AND DOCUMENTO>@n1 and tipo='01' and estatus='0') " _
                + "GROUP BY " & xsqlOrder & ",TIPO,tasa1,tasa2 ORDER BY " & xsqlOrder & " ,TIPO"

                Dim xcuenta As Integer = 0
                For Each dr2 As DataRow In t2.Rows
                    If dr2("nrf") = dr("nrf") AndAlso dr2("fecha") = dr("fecha") Then
                        xv = True
                        xcuenta += 1

                        xt.Rows.Clear()
                        Dim xt1 As New SqlParameter("@fecha", dr2("fecha"))
                        Dim xt2 As New SqlParameter("@nrf", dr2("nrf"))
                        Dim xt3 As New SqlParameter("@n1", vinicial)
                        Dim xt4 As New SqlParameter("@n2", dr2("Inicio"))
                        If xcuenta <= 1 Then
                            g_MiData.F_GetData(xsql3, xt, xt1, xt2, xt3, xt4)
                        Else
                            g_MiData.F_GetData(xsql4, xt, xt1, xt2, xt3, xt4)
                        End If

                        Dim xr As DataRow = xt.NewRow
                        xr(0) = dr2(0)
                        xr(1) = dr2(1)
                        xr(2) = dr2(2)
                        xr(3) = dr2(3)
                        xr(4) = dr2(4)
                        xr(5) = dr2(5)
                        xr(6) = dr2(6)
                        xr(7) = dr2(7)
                        xr(8) = dr2(8)
                        xr(9) = dr2(9)
                        xr(10) = dr2(10)
                        xr(11) = dr2(11)
                        xr(12) = dr2(12)
                        xr(13) = dr2(13)
                        xr(14) = dr2(14)
                        xr(15) = dr2(15)
                        xr(16) = dr2(16)
                        xr(17) = dr2(17)
                        xr(18) = dr2(18) 'anexada el 01/10/2010

                        xr(19) = dr2(19) 'anexada el 29/01/2011
                        xr(20) = dr2(20) 'anexada el 29/01/2011

                        xt.Rows.Add(xr)

                        vinicial = dr2("Inicio")
                        For Each l1 As DataRow In xt.Rows
                            Dim r As DataRow = t3.NewRow
                            r(0) = l1(0)
                            r(1) = l1(1)
                            r(2) = l1(2)
                            r(3) = l1(3)
                            r(4) = l1(4)
                            r(5) = l1(5)
                            r(6) = l1(6)
                            r(7) = l1(7)
                            r(8) = l1(8)
                            r(9) = l1(9)
                            r(10) = l1(10)
                            r(11) = l1(11)
                            r(12) = l1(12)
                            r(13) = l1(13)
                            r(14) = l1(14)
                            r(15) = l1(15)
                            r(16) = l1(16)
                            r(17) = l1(17)
                            r(18) = l1(18) 'anexada el 01/10/2010

                            r(19) = l1(19) 'anexada el 29/01/2011
                            r(20) = l1(20) 'anexada el 29/01/2011

                            t3.Rows.Add(r)
                        Next

                        dr2("nrf") = ""
                    End If
                Next

                If xv = False Then
                    Dim xr As DataRow = t3.NewRow
                    xr(0) = dr(0)
                    xr(1) = dr(1)
                    xr(2) = dr(2)
                    xr(3) = dr(3)
                    xr(4) = dr(4)
                    xr(5) = dr(5)
                    xr(6) = dr(6)
                    xr(7) = dr(7)
                    xr(8) = dr(8)
                    xr(9) = dr(9)
                    xr(10) = dr(10)
                    xr(11) = dr(11)
                    xr(12) = dr(12)
                    xr(13) = dr(13)
                    xr(14) = dr(14)
                    xr(15) = dr(15)
                    xr(16) = dr(16)
                    xr(17) = dr(17)
                    xr(18) = dr(18) 'anexada el 01/10/2010

                    xr(19) = dr(19) 'anexada el 29/01/2011
                    xr(20) = dr(20) 'anexada el 29/01/2011

                    t3.Rows.Add(xr)
                Else
                    Dim xt2 As New DataTable

                    Dim xd1 As New SqlParameter("@fecha", dr("fecha"))
                    Dim xd2 As New SqlParameter("@nrf", dr("nrf"))
                    Dim xd3 As New SqlParameter("@n1", vinicial)
                    g_MiData.F_GetData(xsql5, xt2, xd1, xd2, xd3)

                    For Each r As DataRow In xt2.Rows
                        Dim xr As DataRow = t3.NewRow
                        xr(0) = r(0)
                        xr(1) = r(1)
                        xr(2) = r(2)
                        xr(3) = r(3)
                        xr(4) = r(4)
                        xr(5) = r(5)
                        xr(6) = r(6)
                        xr(7) = r(7)
                        xr(8) = r(8)
                        xr(9) = r(9)
                        xr(10) = r(10)
                        xr(11) = r(11)
                        xr(12) = r(12)
                        xr(13) = r(13)
                        xr(14) = r(14)
                        xr(15) = r(15)
                        xr(16) = r(16)
                        xr(17) = r(17)
                        xr(18) = r(18) 'anexada el 01/10/2010

                        xr(19) = r(19) 'anexada el 29/01/2011
                        xr(20) = r(20) 'anexada el 29/01/2011

                        t3.Rows.Add(xr)
                    Next
                    vinicial = ""
                End If
            Next

            CrearTablaTemporal_2()
            ArmarCabecera(mDesde, mHasta)
            Dim i As Integer
            Dim MisRegistros As Registro

            If t3.Rows.Count - 1 >= 0 Then
                'pasar los datos de esta tabla a la tabla del dataset
                For i = 0 To t3.Rows.Count - 1
                    MisRegistros = New Registro

                    MisRegistros.p_RazonSocial = t3.Rows(i).Item("RazonSocial")
                    MisRegistros.Rif_CI = t3.Rows(i).Item("CI_RIF")
                    If t3.Rows(i).Item("TipoDocumento") = "01" Then
                        MisRegistros.InicioFactura = t3.Rows(i).Item("Inicio")
                        MisRegistros.FinFactura = t3.Rows(i).Item("Final")
                    Else
                        MisRegistros.InicioNC = t3.Rows(i).Item("Inicio")
                        MisRegistros.FinNC = t3.Rows(i).Item("Final")
                        MisRegistros.NroFacturaAfectada = t3.Rows(i).Item("Aplica")
                    End If
                    MisRegistros.NumeroImpFiscal = t3.Rows(i).Item("nrf")
                    MisRegistros.FechaRegistro = t3.Rows(i).Item("fecha")
                    MisRegistros.TotalFull = t3.Rows(i).Item("tot")
                    MisRegistros.TotalExento = t3.Rows(i).Item("exento")
                    MisRegistros.mTotalBase1 = t3.Rows(i).Item("base1")
                    MisRegistros.mTotalImpuesto1 = t3.Rows(i).Item("impuesto1")
                    MisRegistros.mTotalBase2 = t3.Rows(i).Item("base2")
                    MisRegistros.mTotalImpuesto2 = t3.Rows(i).Item("impuesto2")
                    MisRegistros.SignoRegistro = t3.Rows(i).Item("signo")
                    MisRegistros.TasaNro1 = t3.Rows(i).Item("tasa1")
                    MisRegistros.TasaNro2 = t3.Rows(i).Item("tasa2")
                    MisRegistros.NroControlFactura = t3.Rows(i).Item("NroControlFact")

                    'MisRegistros.RetencionIva = t3.Rows(i).Item("RetencionIva") 'anexada el 01/10/2010
                    MisRegistros.mTipoTrans = t3.Rows(i).Item("TipoDocumento") 'anexada el 28/01/2011

                    If Not IsDBNull(t3.Rows(i).Item("FechaComprbRet")) Then
                        If t3.Rows(i).Item("FechaComprbRet") = "" Then
                        Else
                            MisRegistros.FechaRetencionIva = CType(t3.Rows(i).Item("FechaComprbRet"), Date).ToShortDateString
                        End If
                    End If

                    If Not IsDBNull(t3.Rows(i).Item("NroComprbRet")) Then
                        MisRegistros.ComprobanteRetIva = t3.Rows(i).Item("NroComprbRet")
                    End If

                    If Not IsDBNull(t3.Rows(i).Item("RetencionIva")) Then
                        MisRegistros.RetencionIva = t3.Rows(i).Item("RetencionIva")
                    End If
                    AgregarFila_2(MisRegistros)
                Next
                LlamarVisorCrystal(CodReport)
            Else
                MessageBox.Show("Error... No Hay Registros Para Este Rango De Fechas Dado !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub EjecutarReportesGeneralVentas(ByVal mDesde As Date, ByVal mHasta As Date, ByVal CodReport As String)
        Try
            Dim t1 As New DataTable("DETALLE_REPORTE_CONT_NOCONT")
            Dim t2 As New DataTable
            Dim T3 As New DataTable("CABECERA_REPORTE")
            Dim T4 As New DataTable

            Dim xsql0 As String = "select nombre as nombrecliente ,rif as rifcliente ,nit as nitcliente , @DESDE AS  fechadesde, @HASTA AS fechahasta, " & _
                                  "'' as imprsfiscal from empresa"

            Dim xsql1 As String = "SELECT 0 as nro_oper, v.fecha as fecha, v.CI_RIF as rif_ci, v.NOMBRE as razonsocial," & _
                "v.NRF as nrf, '' nrdiario,  factinicio=case v.tipo when '01' then v.documento else '' end, " & _
                " ncinicio=case v.tipo when '03' then v.documento else '' end, " & _
                " ncfin=case v.tipo when '03' then v.documento else '' end, " & _
                " factfin=case v.tipo when '01' then v.documento else '' end, " & _
                " signo=case v.tipo when '01' then 1 else -1 end, " & _
                " v.tipo as tipotrans, v.aplica as nrofactafect, " & _
                " case v.estatus when '0' then v.total  else 0 end as totalivs, " & _
                " case v.estatus when '0' then v.exento else 0 end as exento, " & _
                " case v.estatus when '0' then v.base1  else 0 end as totalbase1, " & _
                " case v.estatus when '0' then v.impuesto1 else 0 end totalimpuesto1, " & _
                " case v.estatus when '0' then v.base2  else 0 end as totalbase2, " & _
                " case v.estatus when '0' then v.impuesto2 else 0 end as totalimpuesto2, " & _
                " case v.estatus when '0' then v.base3  else 0 end as totalbase3, " & _
                " case v.estatus when '0' then v.impuesto3 else 0 end as totalimpuesto3, " & _
                " v.tasa1 as tasa1, v.tasa2 as tasa2, v.tasa3 as tasa3, v.control as nrocontrolfact, " & _
                " 0.00 as retencioniva, V.AUTO, V.DOCUMENTO, '' as comprobante_retencion, '' as fecha_retencion,  v.relacion_z as Z " & _
                " FROM VENTAS v where v.tipo in ('01','03') and v.fecha>=@desde and v.fecha<=@hasta " & _
            " UNION " & _
                " SELECT 0 as nro_oper, v.fecha as fecha, v.CI_RIF as rif_ci, v.NOMBRE as razonsocial," & _
                " v.NRF as nrf, '' nrdiario,  factinicio=case v.tipo when '01' then v.documento else '' end, " & _
                " ncinicio=case v.tipo when '03' then v.documento else '' end, " & _
                " ncfin=case v.tipo when '03' then v.documento else '' end, " & _
                " factfin=case v.tipo when '01' then v.documento else '' end, " & _
                " signo=case v.tipo when '01' then 1 else -1 end, " & _
                " v.tipo as tipotrans, v.aplica as nrofactafect, 0 as totalivs, 0 as exento, 0 as totalbase1, 0 as totalimpuesto1," & _
                " 0 as totalbase2, 0 as totalimpuesto2, 0 as totalbase3, 0 as totalimpuesto3, v.tasa1 as tasa1, v.tasa2 as tasa2, v.tasa3 as tasa3, v.control as nrocontrolfact, " & _
                " rvd.retencion AS RETENCIONIVA, rvd.auto_documento AUTO, RVD.DOCUMENTO, rvd.comprobante as comprobante_retencion,  convert(NCHAR(10),fecha_retencion,103), v.relacion_z as Z " & _
                " FROM retenciones_ventas_detalle rvd join ventas v on rvd.auto_documento=v.auto " & _
                " WHERE rvd.fecha_retencion >=@desde and rvd.fecha_retencion <=@hasta AND " & _
                " rvd.auto_documento not in (select auto from ventas where tipo in ('01','03') and fecha>=@desde and fecha<=@hasta and estatus='0' ) " & _
                " ORDER BY fecha, DOCUMENTO"

            Dim xsql2 As String = "SELECT rvd.auto_documento as auto, rvd.retencion, rvd.comprobante, rvd.fecha_retencion FROM retenciones_ventas_detalle rvd " & _
                "where rvd.fecha_retencion>=@desde and rvd.fecha_retencion <=@hasta"

            Dim xsql3 As String = "select distinct(nrf) from series_fiscales where nrf<>'' order by nrf"


            Dim xp1 As SqlParameter
            Dim xp2 As SqlParameter
            xp1 = New SqlParameter("@desde", mDesde)
            xp2 = New SqlParameter("@hasta", mHasta)
            g_MiData.F_GetData(xsql0, T3, xp1, xp2)

            xp1 = New SqlParameter("@desde", mDesde)
            xp2 = New SqlParameter("@hasta", mHasta)
            g_MiData.F_GetData(xsql1, t1, xp1, xp2)

            xp1 = New SqlParameter("@desde", mDesde)
            xp2 = New SqlParameter("@hasta", mHasta)
            g_MiData.F_GetData(xsql2, t2, xp1, xp2)

            g_MiData.F_GetData(xsql3, T4)

            If t1.Rows.Count - 1 >= 0 Then
                Dim xser As String = ""
                For Each dr As DataRow In T4.Rows
                    xser += dr(0).ToString + ", "
                Next
                T3.Rows(0)("imprsfiscal") = xser

                For Each DR In t2.Rows
                    For Each XR As DataRow In t1.Rows
                        If DR("AUTO").TRIM = XR("AUTO").TRIM Then
                            XR("RETENCIONIVA") = DR("RETENCION")
                            XR("COMPROBANTE_RETENCION") = DR("COMPROBANTE")
                            XR("FECHA_RETENCION") = CType(DR("FECHA_RETENCION"), Date).Date.ToShortDateString
                            Exit For
                        End If
                    Next
                Next

                Dim x As Integer = 0
                For Each XR As DataRow In t1.Rows
                    x += 1
                    XR(0) = x.ToString
                Next
                Dim ds As New DataSet
                ds.Tables.Add(t1)
                ds.Tables.Add(T3)

                LlamarVisorCrystal("REPORTE0", ds)
            Else
                Funciones.MensajeDeAlerta("No Se Encontraron Resultados Para Este Rango De Fechas")
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub


    Sub CrearTablaTemporal_2()
        MiDataTablaCabecera = New Data.DataTable("Cabecera_Reporte")
        MiDataTablaDetalle = New Data.DataTable("Detalle_Reporte_Cont_NoCont")
        MiDataSet = New Data.DataSet

        '"Tabla Detalle"
        MiDataTablaDetalle.Columns.Add("Nro_Oper", GetType(Integer))
        MiDataTablaDetalle.Columns.Add("Fecha", GetType(String))
        MiDataTablaDetalle.Columns.Add("Rif_CI", GetType(String))
        MiDataTablaDetalle.Columns.Add("RazonSocial", GetType(String))
        MiDataTablaDetalle.Columns.Add("NRF", GetType(String))
        MiDataTablaDetalle.Columns.Add("NRDiario", GetType(String))
        MiDataTablaDetalle.Columns.Add("FactInicio", GetType(String))
        MiDataTablaDetalle.Columns.Add("FactFin", GetType(String))
        MiDataTablaDetalle.Columns.Add("NCInicio", GetType(String))
        MiDataTablaDetalle.Columns.Add("NCFin", GetType(String))
        MiDataTablaDetalle.Columns.Add("TipoTrans", GetType(String))
        MiDataTablaDetalle.Columns.Add("NroFactAfect", GetType(String))
        MiDataTablaDetalle.Columns.Add("TotalIVS", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("Exento", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("TotalBase1", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("TotalImpuesto1", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("TotalBase2", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("TotalImpuesto2", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("Tasa1", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("Tasa2", GetType(Decimal))
        MiDataTablaDetalle.Columns.Add("NroControlFact", GetType(String))
        MiDataTablaDetalle.Columns.Add("Signo", GetType(Integer))
        MiDataTablaDetalle.Columns.Add("RetencionIva", GetType(Decimal))    'columna anexada 01/10/2010
        MiDataTablaDetalle.Columns.Add("NroComprbRet", GetType(String))
        MiDataTablaDetalle.Columns.Add("FechaComprbRet", GetType(String))
        MiDataTablaDetalle.Columns("Nro_Oper").AutoIncrement = True
        MiDataTablaDetalle.Columns("Nro_Oper").AutoIncrementSeed = 1

        '"Tabla Cabecera"
        MiDataTablaCabecera.Columns.Add("NombreCliente", GetType(String))
        MiDataTablaCabecera.Columns.Add("RifCliente", GetType(String))
        MiDataTablaCabecera.Columns.Add("NitCliente", GetType(String))
        MiDataTablaCabecera.Columns.Add("FechaDesde", GetType(Date))
        MiDataTablaCabecera.Columns.Add("FechaHasta", GetType(Date))
        MiDataTablaCabecera.Columns.Add("ImprsFiscal", GetType(String))

        MiDataSet.Tables.Add(MiDataTablaDetalle)
        MiDataSet.Tables.Add(MiDataTablaCabecera)
    End Sub

    Sub AgregarFila_2(ByVal MiRegistro As Registro)
        Dim dr As Data.DataRow = MiDataTablaDetalle.NewRow

        dr("Fecha") = MiRegistro.FechaRegistro
        dr("Rif_CI") = MiRegistro.Rif_CI
        dr("RazonSocial") = IIf(MiRegistro.p_RazonSocial <> "", MiRegistro.p_RazonSocial, "RESUMEN Z DIARIO")
        dr("NRF") = MiRegistro.NumeroImpFiscal
        dr("NRDiario") = ""             'NO SE LE PASA NADA
        dr("FactInicio") = MiRegistro.InicioFactura
        dr("FactFin") = MiRegistro.FinFactura
        dr("NCInicio") = MiRegistro.InicioNC
        dr("NCFin") = MiRegistro.FinNC
        dr("TipoTrans") = MiRegistro.mTipoTrans ' "1"
        dr("NroFactAfect") = MiRegistro.NroFacturaAfectada
        dr("TotalIVS") = MiRegistro.TotalFull
        dr("Exento") = MiRegistro.TotalExento
        dr("TotalBase1") = MiRegistro.mTotalBase1
        dr("TotalImpuesto1") = MiRegistro.mTotalImpuesto1
        dr("TotalBase2") = MiRegistro.mTotalBase2
        dr("TotalImpuesto2") = MiRegistro.mTotalImpuesto2
        dr("tasa1") = MiRegistro.TasaNro1
        dr("tasa2") = MiRegistro.TasaNro2
        dr("NroControlFact") = MiRegistro.NroControlFactura
        dr("Signo") = MiRegistro.SignoRegistro
        dr("RetencionIva") = MiRegistro.RetencionIva 'anexada el 01/10/2010

        dr("NroComprbRet") = MiRegistro.ComprobanteRetIva
        dr("FechaComprbRet") = MiRegistro.FechaRetencionIva

        MiDataTablaDetalle.Rows.Add(dr)
    End Sub

    Function _FechaComienzoDelMes(ByVal xfecha As Date) As Date
        Dim xsql As String = "select dateadd(month,datediff(month,'19000101',@fecha),'19000101')"
        Dim xpr1 As New SqlParameter("@fecha", xfecha)
        Return F_GetDate(xsql, xpr1)
    End Function

    Function VisualizarAllRet_Compras(ByVal xsql As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_retenciones As New DataTable("retenciones_compras")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql, dtb_retenciones)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_retenciones)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "rep_retenciones_compras.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Function ImprimirReciboPagoCxC(ByVal xdocumento As String) As Boolean
        Const SELECT_DATAEMPRESA As String = "select nombre" & _
                                                    ", rif" & _
                                                    ", direccion" & _
                                                    ", telefono_1 telefono" & _
                                                    ", sucursal" & _
                                                    ", codigo_sucursal, telefono_1, telefono_2,telefono_3, celular_1, email,website " & _
                                              "from empresa"

        Const SELECT_DATARECIBO As String = "SELECT cxc_r.numero" & _
                                                    ", cxc_r.fecha as fecha_proceso, cxc.fecha_emision" & _
                                                    ", cxc_r.cobrador" & _
                                                    ", cxc_r.nombre_cliente cliente" & _
                                                    ", cxc_r.ci_rif_cliente" & _
                                                    ", cxc_r.codigo_cliente" & _
                                                    ", cxc_r.direccion dir_fiscal_cliente" & _
                                                    ", cxc_r.telefono telefono_cliente" & _
                                                    ", cxc_r.detalle" & _
                                                    ", (cxc_r.importe-isnull(cxc_r.monto_nc_pagadas,0)-cxc_r.anticipos) importe" & _
                                                    ", cxc_r.estatus " & _
                                             "FROM cxc_recibos as cxc_r join cxc as cxc on cxc_r.auto_cxc=cxc.auto " & _
                                             "WHERE cxc_r.auto=@auto"

        Const SELECT_DATADOCUMENTOS As String = "SELECT origen" & _
                                                        ", documento" & _
                                                        ", monto" & _
                                                        ", monto_pendiente SALDOPENDIENTE_ANTES_DEL_PAGO " & _
                                                 "FROM cxc_documentos WHERE auto_cxc_recibo=@auto"

        Const SELECT_DATAMODOSPAGOS As String = "SELECT nombre" & _
                                                        ", monto_recibido " & _
                                                        ", importe, NUMERO, AGENCIA " & _
                                                 "FROM cxc_modo_pago " & _
                                                 "WHERE auto_recibo=@auto"



        Dim xnumero As String = xdocumento
        Dim xauto As String = ""
        Dim dts As New DataSet
        Dim dtb_empresa As New DataTable("empresa")
        Dim xrecibo As New FichaCtasCobrar.c_Recibos

        Dim dtb_cxc_recibo As New DataTable("recibo")
        Dim dtb_cxc_documentos As New DataTable("documentos")
        Dim dtb_cxc_modos_pagos As New DataTable("cxc_modo_pago")
        Dim xparam As SqlParameter
        Try
            g_MiData.F_GetData(SELECT_DATAEMPRESA, dtb_empresa)
            dts.Tables.Add(dtb_empresa)

            Dim xp1 As New SqlParameter("@numero", xnumero)
            xauto = F_GetString("select auto from cxc_recibos where numero=@numero", xp1)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(SELECT_DATARECIBO, dtb_cxc_recibo, xparam)
            dts.Tables.Add(dtb_cxc_recibo)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(SELECT_DATADOCUMENTOS, dtb_cxc_documentos, xparam)
            dts.Tables.Add(dtb_cxc_documentos)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(SELECT_DATAMODOSPAGOS, dtb_cxc_modos_pagos, xparam)
            dts.Tables.Add(dtb_cxc_modos_pagos)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "rep_cxc_recibo.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function


    Sub ImprimirReciboAnticipo(ByVal xdocumento As String)
        Const SELECT_DATAEMPRESA As String = "select nombre" & _
                                                    ", rif" & _
                                                    ", direccion" & _
                                                    ", telefono_1 telefono" & _
                                                    ", sucursal" & _
                                                    ", codigo_sucursal, telefono_1, telefono_2,telefono_3, celular_1, email,website " & _
                                              "from empresa"

        Const SELECT_DATARECIBO As String = "SELECT numero" & _
                                                    ", fecha" & _
                                                    ", cobrador" & _
                                                    ", nombre_cliente cliente" & _
                                                    ", ci_rif_cliente" & _
                                                    ", codigo_cliente" & _
                                                    ", direccion dir_fiscal_cliente" & _
                                                    ", telefono telefono_cliente" & _
                                                    ", detalle " & _
                                                    ", importe " & _
                                                    ", estatus " & _
                                             "FROM cxc_recibos " & _
                                             "WHERE auto=@auto"

        Const SELECT_DATADOCUMENTOS As String = "SELECT origen" & _
                                                        ", documento" & _
                                                        ", monto" & _
                                                        ", monto_pendiente SALDOPENDIENTE_ANTES_DEL_PAGO " & _
                                                 "FROM cxc_documentos WHERE auto_cxc_recibo=@auto"

        Const SELECT_DATAMODOSPAGOS As String = "SELECT nombre" & _
                                                        ", monto_recibido " & _
                                                        ", importe " & _
                                                 "FROM cxc_modo_pago " & _
                                                 "WHERE auto_recibo=@auto"



        Dim xnumero As String = xdocumento
        Dim xauto As String = ""
        Dim dts As New DataSet
        Dim dtb_empresa As New DataTable("empresa")
        Dim xrecibo As New FichaCtasCobrar.c_Recibos

        Dim dtb_cxc_recibo As New DataTable("recibo")
        Dim dtb_cxc_documentos As New DataTable("documentos")
        Dim dtb_cxc_modos_pagos As New DataTable("cxc_modo_pago")
        Dim xparam As SqlParameter
        Try
            g_MiData.F_GetData(SELECT_DATAEMPRESA, dtb_empresa)
            dts.Tables.Add(dtb_empresa)

            Dim xp1 As New SqlParameter("@numero", xnumero)
            xauto = F_GetString("select auto from cxc_recibos where numero=@numero", xp1)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(SELECT_DATARECIBO, dtb_cxc_recibo, xparam)
            dts.Tables.Add(dtb_cxc_recibo)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(SELECT_DATADOCUMENTOS, dtb_cxc_documentos, xparam)
            dts.Tables.Add(dtb_cxc_documentos)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(SELECT_DATAMODOSPAGOS, dtb_cxc_modos_pagos, xparam)
            dts.Tables.Add(dtb_cxc_modos_pagos)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "rep_cxc_recibo.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function VisualizarComprobanteEgreso(ByVal xauto As String) As Boolean
        Try
            Dim dts As New DataSet
            Dim dtb_comprobante As New DataTable("comprobante_egreso")
            Dim dtb_empresa As New DataTable("empresa")

            Dim xp1 As SqlParameter
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                   "from empresa"

            Dim xsql_2 As String = "select 'CHEQUE' tipo_mov, comprobante,codigo codigo_cuenta, nombre nombre_cuenta,importe, " & _
                                   "documento,banco,usuario, autorizado, titular_cuenta titular, numero_cuenta  " & _
                                   ",entidad,ci_rif_entidad ci_rif, fecha, m.detalle, mp.detalle detalle_plan " & _
                                   "from movimientos m join movimientos_plan_cuentas mp on m.auto=mp.auto_movimientos " & _
                                   "where m.auto=@auto order by codigo"

            xp1 = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql_2, dtb_comprobante, xp1)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_comprobante)

            Dim ximporte As String = ""
            ximporte = "* " + dtb_comprobante.Rows(0)("importe").ToString + " *"

            Dim xlista As New List(Of _Reportes.ParamtCrystal)
            xlista.Add(New _Reportes.ParamtCrystal("@guarismo", Guarismo(dtb_comprobante.Rows(0)("importe").ToString)))
            xlista.Add(New _Reportes.ParamtCrystal("@importe", ximporte))

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "RPT_COMPROBANTE_EGRESO.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlista)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Function VisualizarComprobanteEgresoGeneral(ByVal xauto As String) As Boolean
        Try
            Dim dts As New DataSet
            Dim dtb_comprobante As New DataTable("comprobante_egreso")
            Dim dtb_empresa As New DataTable("empresa")

            Dim xp1 As SqlParameter
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                   "from empresa"

            Dim xsql_2 As String = "select (case m.tipo when 'TRF' then 'TRANSFERENCIA' when 'RET' then 'RETIRO' end) tipo_mov, comprobante,codigo codigo_cuenta, nombre nombre_cuenta,importe, " & _
                                   "documento,banco,usuario, autorizado, titular_cuenta titular, numero_cuenta  " & _
                                   ",entidad,ci_rif_entidad ci_rif, fecha, m.detalle, mp.detalle detalle_plan " & _
                                   "from movimientos m join movimientos_plan_cuentas mp on m.auto=mp.auto_movimientos " & _
                                   "where m.auto=@auto order by codigo"


            xp1 = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql_2, dtb_comprobante, xp1)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_comprobante)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "RPT_COMPROBANTE_EGRESO_GENERAL.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Function VisualizarReciboCxP(ByVal xauto As String) As Boolean
        Try
            Dim dts As New DataSet
            Dim dtb_empresa As New DataTable("empresa")
            Dim dtb_cxp_recibo As New DataTable("recibo_cxp")
            Dim dtb_cxp_documentos As New DataTable("documentos")
            Dim xparam As SqlParameter

            Dim xsql_1 As String = "select nombre" & _
                                        ", rif" & _
                                        ", direccion" & _
                                        ", telefono_1 telefono" & _
                                        ", sucursal" & _
                                        ", codigo_sucursal " & _
                                  "from empresa"
            Dim xsql_2 As String = "SELECT numero" & _
                                        ", fecha" & _
                                        ", nombre_proveedor entidad" & _
                                        ", ci_rif_proveedor ci_rif_entidad" & _
                                        ", codigo_proveedor codigo_entidad" & _
                                        ", detalle" & _
                                        ", importe" & _
                                        ", estatus " & _
                                 "FROM cxp_recibos " & _
                                 "WHERE auto=@auto"
            Dim xsql_3 As String = "SELECT origen" & _
                                        ", cd.documento" & _
                                        ", monto" & _
                                        ", resta " & _
                                 "FROM cxp_documentos cd inner join cxp c on c.auto=cd.auto_cxp " & _
                                 "WHERE auto_cxp_recibo=@auto"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            dts.Tables.Add(dtb_empresa)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(xsql_2, dtb_cxp_recibo, xparam)
            dts.Tables.Add(dtb_cxp_recibo)

            xparam = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(xsql_3, dtb_cxp_documentos, xparam)
            dts.Tables.Add(dtb_cxp_documentos)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "rep_cxp_recibo.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()
            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Function VisualizarRet_Compras(ByVal xauto_ret As String, ByVal xauto_ent As String, ByVal xdocumento As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_empresa As New DataTable("empresa")
        Dim dtb_retenciones As New DataTable("retenciones_compras")
        Dim dtb_retenciones_detalle As New DataTable("retenciones_compras_detalle")

        Try
            Dim xparam1 As SqlParameter = New SqlParameter("@auto", xauto_ret)
            Dim xparam2 As SqlParameter = New SqlParameter("@auto", xauto_ret)

            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                   "from empresa"

            Dim xsql_2 As String = "select documento" & _
                                    ", nombre" & _
                                    ", ci_rif" & _
                                    ", dir_fiscal" & _
                                    ", fecha" & _
                                    ", ano_relacion" & _
                                    ", mes_relacion" & _
                                    ", base" & _
                                    ", impuesto" & _
                                    ", retencion" & _
                                    ", tasa_retencion" & _
                                    ", total" & _
                                    ", exento " & _
                                    ", estatus " & _
                                "from retenciones_compras " & _
                                "where auto=@auto "

            Dim xsql_3 As String = "select * " & _
                                   "from ( " & _
                                        "select rcd.documento" & _
                                            ", rcd.fecha" & _
                                            ", rcd.impuesto1 impuesto" & _
                                            ", rcd.tasa1 tasa" & _
                                            ", rcd.aplica" & _
                                            ", rcd.control" & _
                                            ", rcd.tipo" & _
                                            ", '1' tipo_impuesto" & _
                                            ", rcd.exento " & _
                                            ", rcd.base1 base, c.n_serie as serie " & _
                                         "from retenciones_compras_detalle as rcd join compras as c on (rcd.auto_documento=c.auto) " & _
                                         "where rcd.auto=@auto and rcd.impuesto1<>0 " & _
                                         "union " & _
                                         "select documento" & _
                                            ", fecha" & _
                                            ", impuesto2 impuesto" & _
                                            ", tasa2 tasa" & _
                                            ", aplica" & _
                                            ", control" & _
                                            ", tipo" & _
                                            ", '2' tipo_impuesto" & _
                                            ", (case when impuesto1 <>0 then 0 else exento end) exento" & _
                                            ", base2 base, '          ' as serie " & _
                                         "from retenciones_compras_detalle " & _
                                         "where auto=@auto and impuesto2<>0 " & _
                                         "union " & _
                                         "select documento" & _
                                            ", fecha" & _
                                            ", impuesto3 impuesto" & _
                                            ", tasa3 tasa" & _
                                            ", aplica" & _
                                            ", control" & _
                                            ", tipo" & _
                                            ", '3' tipo_impuesto" & _
                                            ", (case when impuesto1 <>0 then 0 else exento end) exento" & _
                                            ", base3 base, '          ' as serie " & _
                                         "from retenciones_compras_detalle " & _
                                         "where auto=@auto and impuesto3<>0 ) T " & _
                                    "order by t.documento, t.tasa desc"

            g_MiData.F_GetData(xsql_1, dtb_empresa)
            dts.Tables.Add(dtb_empresa)

            g_MiData.F_GetData(xsql_2, dtb_retenciones, xparam1)
            dts.Tables.Add(dtb_retenciones)
            If dtb_retenciones.Rows.Count = 0 Then
                Throw New Exception("DOCUMENTO NO ENCONTRADO / FUE ANULADO POR OTRO USUARIO")
            End If

            g_MiData.F_GetData(xsql_3, dtb_retenciones_detalle, xparam2)
            dts.Tables.Add(dtb_retenciones_detalle)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "rep_planilla_retencion_iva_compras.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Function VisualizarDoc_Gastos(ByVal xauto As String) As Boolean
        Dim dts As New DataSet
        Dim dtb_compras As New DataTable("compra")
        Dim dtb_empresa As New DataTable("empresa")

        Try
            Dim xp1 As SqlParameter
            Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                 "from empresa"

            Dim xsql_2 As String = "select nombre, dir_fiscal, ci_rif, codigo_entidad, telefono, documento, fecha " & _
                                                 ",fecha_vencimiento, subtotal, descuento1, cargos, impuesto1, impuesto2 " & _
                                                 ",total, tasa1, tasa2, descuento1_porcentaje, nota, estatus, tipo " & _
                                                 ",aplica, fletep, flete, seguro, segurop, mes_relacion, ano_relacion, control, cargos_porcentaje,fecha_carga " & _
                                                 ",impuesto3, tasa3, n_serie as serie from compras where auto=@auto"

            xp1 = New SqlParameter("@auto", xauto)
            g_MiData.F_GetData(xsql_1, dtb_empresa)
            g_MiData.F_GetData(xsql_2, dtb_compras, xp1)

            dts.Tables.Add(dtb_empresa)
            dts.Tables.Add(dtb_compras)

            Dim xlista As New List(Of _Reportes.ParamtCrystal)
            xlista.Add(New _Reportes.ParamtCrystal("@guarismo", Guarismo(dtb_compras.Rows(0)("total").ToString)))

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "rep_compra_gasto.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlista)
            xficha.ShowDialog()

            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Function RetornarPeriodoRetencion(ByVal xfecha As Date)
        If xfecha.Day >= 1 And xfecha.Day <= 15 Then
            Return 1
        Else
            Return 2
        End If
    End Function
End Module