Public Class ReportesVarios

    Private Sub ReportesVarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ALM_PRECIOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALM_PRECIOS.Click
        Try
            Dim xficha As PlantillaFiltroReportesInventario = Nothing
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteInventario_ListaPrecio.F_Permitir()
            xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_ListaPrecios)

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ALM_EXISTENCIA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALM_EXISTENCIA.Click
        Try
            Dim xficha As PlantillaFiltroReportesInventario = Nothing
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteInventario_Existencia.F_Permitir()
            xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_ExistenciasDeposito)

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ALM_KARDEX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALM_KARDEX.Click
        Try
            Dim xficha As PlantillaFiltroReportesInventario = Nothing
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Kardex.F_Permitir()
            xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_Kardex)

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VENTA_LIBRO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VENTA_LIBRO.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReportesVentasDetallado(.p_FechaDesde, .p_FechaHasta, "reporte5")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VENTA_CONSOLIDADO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VENTA_CONSOLIDADO.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_Consolidado.F_Permitir()

            Dim xficha As New PlantillaFiltroReporteVentas(New ReporteVentas_Consolidado)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VENTA_UTILIDAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VENTA_UTILIDAD.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_Utilidad.F_Permitir()

            Dim xficha As New PlantillaFiltroReporteVentas(New ReporteVentas_UtilidadVentas)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VENDEDOR_COMISION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VENDEDOR_COMISION.Click
        Try
            Dim xficha As PlantillaFiltroReportesVend_Cobr = Nothing
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVendedor_Comisiones.F_Permitir()
            xficha = New PlantillaFiltroReportesVend_Cobr(New ReporteVendedores_Comisiones)

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CXC_COBRANZADIA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CXC_COBRANZADIA.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxCobrar_Reportes_CobranzaDiaria.F_Permitir()

            Dim xficha As New PlantillaFiltroReportesCxC(New ReporteCxC_CobranzaDiaria)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CXC_DOCUMENTOSPEND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CXC_DOCUMENTOSPEND.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxCobrar_Reportes_DocumentosCobrar.F_Permitir()

            Dim xficha As New PlantillaFiltroReportesCxC(New ReporteCxC_DocumentosPorCobrar)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FISCAL_X_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FISCAL_X.Click
        If g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Estatus Then
            Dim xp As String = ""
            xp = "Estas Seguro De Imprimir Reporte 'X' Fiscal ?"
            If MessageBox.Show(xp, "*** ALERTA ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VisorFiscal_X.F_Permitir()

                    g_ImpFiscal.Reporte_X_Fiscal()
                Catch ex As Exception
                    MessageBox.Show("ERROR:" + vbCrLf + ex.Message, "*** ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("IMPRESORA FISCAL NO DEFINIDA PARA TRABAJAR CON ESTE EQUIPO, VERIFIQUE POR FAVOR", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub FISCAL_Z_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FISCAL_Z.Click
        If g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Estatus Then
            Dim xp As String = ""
            xp = "Estas Seguro De Imprimir Reporte 'Z' Fiscal ?"
            If MessageBox.Show(xp, "*** ALERTA ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VisorFiscal_X.F_Permitir()

                    g_ImpFiscal.Reporte_Z_Fiscal()
                Catch ex As Exception
                    MessageBox.Show("ERROR:" + vbCrLf + ex.Message, "*** ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("IMPRESORA FISCAL NO DEFINIDA PARA TRABAJAR CON ESTE EQUIPO, VERIFIQUE POR FAVOR", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ReportesVarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ComprasToolStripMenuItem1.Visible = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_TipoSistemaInstalado > DataSistema.MiDataSistema.DataSistema.TipoSistemaInstalado.Basico, True, False)
    End Sub

    Private Sub LIBRO_COMPRAS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LIBRO_COMPRAS.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompras_Reportes_LibroCompra.F_Permitir()

            Dim xficha As New PlantillaFiltroReporteCompras(New ReporteCompras_LibroCompras)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GENERAL_COMPRAS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GENERAL_COMPRAS.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompras_Reportes_GeneralCompras.F_Permitir()

            Dim xficha As New PlantillaFiltroReporteCompras(New ReporteCompras_General)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class