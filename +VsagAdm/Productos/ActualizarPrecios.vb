Imports DataSistema.MiDataSistema.DataSistema

Public Class ActualizarPrecios
    Event _ActualizarProducto()
    Event _ActualizarProductoId(ByVal xautoprd As String)

    Dim xinterface_implementar As IActualizarPrecios
    Property _InterfaceImplementar() As IActualizarPrecios
        Get
            Return xinterface_implementar
        End Get
        Set(ByVal value As IActualizarPrecios)
            xinterface_implementar = value
        End Set
    End Property

    Enum TipoAccion
        Consulta = 1
        Actualizar = 2
    End Enum

    Dim xaccion As TipoAccion
    Dim xprd As FichaProducto

    Dim emp_venta_1 As DataTable
    Dim emp_venta_2 As DataTable
    Dim emp_venta_3 As DataTable
    Dim emp_venta_4 As DataTable
    Dim emp_venta_detal As DataTable
    Dim xtb_medida As DataTable

    Dim xficha_empaque_1 As FichaProducto.Prd_Empaque.c_Registro
    Dim xficha_empaque_2 As FichaProducto.Prd_Empaque.c_Registro
    Dim xficha_empaque_3 As FichaProducto.Prd_Empaque.c_Registro
    Dim xficha_empaque_4 As FichaProducto.Prd_Empaque.c_Registro

    Dim xficha_medida_1 As FichaProducto.Prd_Medida
    Dim xficha_medida_2 As FichaProducto.Prd_Medida
    Dim xficha_medida_3 As FichaProducto.Prd_Medida
    Dim xficha_medida_4 As FichaProducto.Prd_Medida

    Dim xprecio_oferta As Decimal
    Dim xinicio_oferta As Date
    Dim xfin_oferta As Date
    Dim xutilidad_oferta As Decimal

    Property _FichaProducto() As FichaProducto
        Get
            Return xprd
        End Get
        Set(ByVal value As FichaProducto)
            xprd = value
        End Set
    End Property

    ReadOnly Property _Off() As Boolean
        Get
            Return False
        End Get
    End Property

    ReadOnly Property _On() As Boolean
        Get
            Return True
        End Get
    End Property

    Property _FichaAccion() As TipoAccion
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccion)
            xaccion = value

            If value = TipoAccion.Consulta Then
                LimpiarControles()
                ActualizarControles()
                ApagarTodo()
            ElseIf value = TipoAccion.Actualizar Then
                Controles(_On)
            End If
        End Set
    End Property

    Private Sub ActualizarPrecios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FichaAccion = TipoAccion.Consulta Then
            e.Cancel = False
        Else
            If MessageBox.Show("Deseas Cerrar Esta Ficha De Producto y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                _FichaAccion = TipoAccion.Consulta
                e.Cancel = True
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub ActualizarPrecios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ActualizarPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub ActualizarPrecios_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub LimpiarControles()
        Me.E_CONTENIDO.Text = "0"
        Me.E_COST_1.Text = "0.0"
        Me.E_COST_2.Text = "0.0"
        Me.E_COST_3.Text = "0.0"
        Me.E_COST_4.Text = "0.0"
        Me.E_COST_DETAL.Text = "0.0"
        Me.E_COSTO.Text = "0.0"
        Me.E_EMPAQUE.Text = ""
        Me.E_IVA.Text = "0.0"
        Me.E_NOMBRE.Text = ""
        Me.E_PVENTA.Text = "0.0"
        Me.E_VALIDO_HASTA.Text = ""
    End Sub

    Sub ActualizarControles()
        Me.E_NOMBRE.Text = _FichaProducto.f_PrdProducto.RegistroDato._DescripcionDetallaDelProducto
        Me.E_IVA.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto)
        Me.E_EMPAQUE.Text = _FichaProducto.f_PrdProducto.RegistroDato._NombreEmpaqueCompra
        Me.E_CONTENIDO.Text = String.Format("{0:#0}", _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra)
        Me.E_COSTO.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdProducto.RegistroDato._CostoCompra._Base)

        Dim xprecio_empaque As New FichaProducto.Prd_Empaque()
        For Each xrow As DataRow In _FichaProducto.f_PrdProducto.RegistroDato.tb_Precios.Rows
            xprecio_empaque.M_Cargardata(xrow)
            'xprecio_empaque.RegistroDato._CostoInventario = _FichaProducto.f_PrdProducto.RegistroDato._CostoCompra._Base_Inv
            xprecio_empaque.RegistroDato._CostoInventario = _FichaProducto.f_PrdProducto.RegistroDato._CostoCompra._Base / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
            xprecio_empaque.RegistroDato._TasaIva = _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto

            Select Case xprecio_empaque.RegistroDato._ReferenciaEmpaqueSeleccionado
                Case "1"
                    Me.MCB_1.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida

                    Me.MN_CONT_1.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                    Me.MN_PN1_1.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                    Me.MN_PF1_1.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                    Me.E_COST_1.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)
                    If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Dim xcostop As Decimal = xprecio_empaque.RegistroDato._CostoInventario * xprecio_empaque.RegistroDato._ContenidoEmpaque
                            Me.MN_UT1_1.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcostop, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        Else
                            Me.MN_UT1_1.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        End If
                    Else
                        Me.MN_UT1_1.Text = "0.0"
                    End If

                    Me.MN_PN2_1.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_2)
                    Me.MN_PF2_1.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_2)
                    If xprecio_empaque.RegistroDato._PrecioNeto_2 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Dim xcostop As Decimal = xprecio_empaque.RegistroDato._CostoInventario * xprecio_empaque.RegistroDato._ContenidoEmpaque
                            Me.MN_UT2_1.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcostop, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                        Else
                            Me.MN_UT2_1.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_2, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                        End If
                    Else
                        Me.MN_UT2_1.Text = "0.0"
                    End If

                Case "2"
                    Me.MCB_2.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                    Me.MN_CONT_2.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                    Me.MN_PN1_2.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                    Me.MN_PF1_2.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                    Me.E_COST_2.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)
                    If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Me.MN_UT1_2.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        Else
                            Me.MN_UT1_2.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        End If
                    Else
                        Me.MN_UT1_2.Text = "0.0"
                    End If

                    Me.MN_PN2_2.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_2)
                    Me.MN_PF2_2.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_2)
                    If xprecio_empaque.RegistroDato._PrecioNeto_2 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Me.MN_UT2_2.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                        Else
                            Me.MN_UT2_2.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_2, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                        End If
                    Else
                        Me.MN_UT2_2.Text = "0.0"
                    End If

                Case "3"
                    Me.MCB_3.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                    Me.MN_CONT_3.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                    Me.MN_PN1_3.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                    Me.MN_PF1_3.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                    Me.E_COST_3.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)
                    If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Me.MN_UT1_3.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        Else
                            Me.MN_UT1_3.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        End If
                    Else
                        Me.MN_UT1_3.Text = "0.0"
                    End If

                    Me.MN_PN2_3.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_2)
                    Me.MN_PF2_3.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_2)
                    If xprecio_empaque.RegistroDato._PrecioNeto_2 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Me.MN_UT2_3.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                        Else
                            Me.MN_UT2_3.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_2, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                        End If
                    Else
                        Me.MN_UT2_3.Text = "0.0"
                    End If

                Case "4"
                    Me.MCB_4.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                    Me.MN_CONT_4.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                    Me.MN_PN1_4.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                    Me.MN_PF1_4.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                    Me.E_COST_4.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)
                    If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Me.MN_UT1_4.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        Else
                            Me.MN_UT1_4.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        End If
                    Else
                        Me.MN_UT1_4.Text = "0.0"
                    End If

                    Me.MN_PN2_4.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_2)
                    Me.MN_PF2_4.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_2)
                    If xprecio_empaque.RegistroDato._PrecioNeto_2 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Me.MN_UT2_4.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                        Else
                            Me.MN_UT2_4.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_2, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                        End If
                    Else
                        Me.MN_UT2_4.Text = "0.0"
                    End If
            End Select
        Next

        Dim xcosto As Decimal = 0
        Dim xprecio As Decimal = 0
        Dim xmargen As Decimal = 0
        xprecio = _FichaProducto.f_PrdProducto.RegistroDato._PrecioDetal._Base

        If _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra > 0 Then
            xcosto = _FichaProducto.f_PrdProducto.RegistroDato._CostoCompra._Base / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
            xcosto = xcosto * _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqVentaDetal
        End If
        xmargen = xprecio - xcosto

        Me.E_COST_DETAL.Text = String.Format("{0:#0.00}", xcosto)
        Me.MCB_DETAL.SelectedValue = _FichaProducto.f_PrdProducto.RegistroDato._AutoEmpaqueVentaDetal
        Me.MN_CONT_DETAL.Text = String.Format("{0:#0}", _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqVentaDetal)
        If xprecio > 0 Then
            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                Me.MN_UT_DETAL.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
            Else
                Me.MN_UT_DETAL.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio, xmargen))
            End If
        Else
            Me.MN_UT_DETAL.Text = String.Format("{0:#0.00}", 0)
        End If
        Me.MN_PF_DETAL.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdProducto.RegistroDato._PrecioDetal._Full)
        Me.MN_PN_DETAL.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdProducto.RegistroDato._PrecioDetal._Base)
        Me.MN_PSUGERIDO.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdProducto.RegistroDato._PrecioSugerido)

        If _FichaProducto.f_PrdProducto.RegistroDato.f_VerificarOferta Then
            Me.E_VALIDO_HASTA.Text = _FichaProducto.f_PrdProducto.RegistroDato._FechaCulminacionOferta.ToShortDateString
            Me.E_PVENTA.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdProducto.RegistroDato._PrecioOferta._Full)
        Else
            Me.E_VALIDO_HASTA.Text = ""
            Me.E_PVENTA.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdProducto.RegistroDato._PrecioDetal._Full)
        End If
    End Sub

    Sub ApagarTodo()
        Dim xop As Boolean = False

        With Me.MN_CONT_1
            .Enabled = xop
        End With
        With Me.MN_CONT_2
            .Enabled = xop
        End With
        With Me.MN_CONT_3
            .Enabled = xop
        End With
        With Me.MN_CONT_4
            .Enabled = xop
        End With
        With Me.MN_CONT_DETAL
            .Enabled = xop
        End With

        With Me.MN_UT1_1
            .Enabled = xop
        End With
        With Me.MN_UT1_2
            .Enabled = xop
        End With
        With Me.MN_UT1_3
            .Enabled = xop
        End With
        With Me.MN_UT1_4
            .Enabled = xop
        End With

        With Me.MN_UT2_1
            .Enabled = xop
        End With
        With Me.MN_UT2_2
            .Enabled = xop
        End With
        With Me.MN_UT2_3
            .Enabled = xop
        End With
        With Me.MN_UT2_4
            .Enabled = xop
        End With

        With Me.MN_UT_DETAL
            .Enabled = xop
        End With

        With Me.MN_PN1_1
            .Enabled = xop
        End With
        With Me.MN_PN1_2
            .Enabled = xop
        End With
        With Me.MN_PN1_3
            .Enabled = xop
        End With
        With Me.MN_PN1_4
            .Enabled = xop
        End With

        With Me.MN_PN2_1
            .Enabled = xop
        End With
        With Me.MN_PN2_2
            .Enabled = xop
        End With
        With Me.MN_PN2_3
            .Enabled = xop
        End With
        With Me.MN_PN2_4
            .Enabled = xop
        End With

        With Me.MN_PF1_1
            .Enabled = xop
        End With
        With Me.MN_PF1_2
            .Enabled = xop
        End With
        With Me.MN_PF1_3
            .Enabled = xop
        End With
        With Me.MN_PF1_4
            .Enabled = xop
        End With

        With Me.MN_PF2_1
            .Enabled = xop
        End With
        With Me.MN_PF2_2
            .Enabled = xop
        End With
        With Me.MN_PF2_3
            .Enabled = xop
        End With
        With Me.MN_PF2_4
            .Enabled = xop
        End With

        Me.MCB_1.Enabled = xop
        Me.MCB_2.Enabled = xop
        Me.MCB_3.Enabled = xop
        Me.MCB_4.Enabled = xop

        With Me.MN_PN_DETAL
            .Enabled = xop
        End With
        With Me.MN_PF_DETAL
            .Enabled = xop
        End With
        With Me.MN_PSUGERIDO
            .Enabled = xop
        End With

        Me.MCB_DETAL.Enabled = xop

        Me.BT_ACTUALIZAR.Enabled = Not xop
        Me.BT_GUARDAR.Enabled = xop
    End Sub

    Sub Controles(ByVal xop As Boolean)
        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.Ambos _
                Or g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.PMayor Then
            With Me.MN_CONT_1
                .Enabled = xop
            End With
            With Me.MN_CONT_2
                .Enabled = xop
            End With
            With Me.MN_CONT_3
                .Enabled = xop
            End With
            With Me.MN_CONT_4
                .Enabled = xop
            End With

            With Me.MN_UT1_1
                .Enabled = xop
            End With
            With Me.MN_UT1_2
                .Enabled = xop
            End With
            With Me.MN_UT1_3
                .Enabled = xop
            End With
            With Me.MN_UT1_4
                .Enabled = xop
            End With

            With Me.MN_UT2_1
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With
            With Me.MN_UT2_2
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With
            With Me.MN_UT2_3
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With
            With Me.MN_UT2_4
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With

            With Me.MN_PN1_1
                .Enabled = xop
            End With
            With Me.MN_PN1_2
                .Enabled = xop
            End With
            With Me.MN_PN1_3
                .Enabled = xop
            End With
            With Me.MN_PN1_4
                .Enabled = xop
            End With

            With Me.MN_PN2_1
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With
            With Me.MN_PN2_2
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With
            With Me.MN_PN2_3
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With
            With Me.MN_PN2_4
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With

            With Me.MN_PF1_1
                .Enabled = xop
            End With
            With Me.MN_PF1_2
                .Enabled = xop
            End With
            With Me.MN_PF1_3
                .Enabled = xop
            End With
            With Me.MN_PF1_4
                .Enabled = xop
            End With

            With Me.MN_PF2_1
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With
            With Me.MN_PF2_2
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With
            With Me.MN_PF2_3
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With
            With Me.MN_PF2_4
                .Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xop, False)
            End With

            Me.MCB_1.Enabled = xop
            Me.MCB_2.Enabled = xop
            Me.MCB_3.Enabled = xop
            Me.MCB_4.Enabled = xop

            With Me.MN_PSUGERIDO
                .Enabled = xop
            End With
        End If

        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.Ambos _
                Or g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.PDetal Then

            With Me.MN_CONT_DETAL
                .Enabled = xop
            End With

            With Me.MN_UT_DETAL
                .Enabled = xop
            End With

            With Me.MN_PN_DETAL
                .Enabled = xop
            End With
            With Me.MN_PF_DETAL
                .Enabled = xop
            End With
            With Me.MN_PSUGERIDO
                .Enabled = xop
            End With

            Me.MCB_DETAL.Enabled = xop
        End If

        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.Ambos _
          Or g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.PMayor Then
            Me.MCB_1.Select()
            Me.MCB_1.Focus()
        Else
            Me.MCB_DETAL.Select()
            Me.MCB_DETAL.Focus()
        End If

        Me.BT_ACTUALIZAR.Enabled = Not xop
        Me.BT_GUARDAR.Enabled = xop
    End Sub

    Sub InicializarControles()
        With Me.MN_CONT_1
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999"
        End With
        With Me.MN_CONT_2
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999"
        End With
        With Me.MN_CONT_3
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999"
        End With
        With Me.MN_CONT_4
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999"
        End With
        With Me.MN_CONT_DETAL
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999"
        End With

        With Me.MN_UT1_1
            .Text = ""
            ._ConSigno = False
            ._Formato = "999.99"
        End With
        With Me.MN_UT1_2
            .Text = ""
            ._ConSigno = False
            ._Formato = "999.99"
        End With
        With Me.MN_UT1_3
            .Text = ""
            ._ConSigno = False
            ._Formato = "999.99"
        End With
        With Me.MN_UT1_4
            .Text = ""
            ._ConSigno = False
            ._Formato = "999.99"
        End With

        With Me.MN_UT2_1
            .Text = ""
            ._ConSigno = False
            ._Formato = "999.99"
        End With
        With Me.MN_UT2_2
            .Text = ""
            ._ConSigno = False
            ._Formato = "999.99"
        End With
        With Me.MN_UT2_3
            .Text = ""
            ._ConSigno = False
            ._Formato = "999.99"
        End With
        With Me.MN_UT2_4
            .Text = ""
            ._ConSigno = False
            ._Formato = "999.99"
        End With

        With Me.MN_UT_DETAL
            .Text = ""
            ._ConSigno = False
            ._Formato = "999.99"
        End With

        With Me.MN_PN1_1
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PN1_2
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PN1_3
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PN1_4
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With

        With Me.MN_PN2_1
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PN2_2
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PN2_3
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PN2_4
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With

        With Me.MN_PF1_1
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PF1_2
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PF1_3
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PF1_4
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With

        With Me.MN_PF2_1
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PF2_2
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PF2_3
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PF2_4
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With

        With Me.MN_PN_DETAL
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PF_DETAL
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_PSUGERIDO
            .Text = ""
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
    End Sub

    Sub Inicializa()
        Try
            InicializarControles()
            CargarCombos()
            _FichaAccion = TipoAccion.Consulta

            If _FichaProducto.f_PrdProducto.RegistroDato.tb_Precios.Rows.Count = 0 Then
                Throw New Exception("PRODUCTO NO TIENE PRECIOS ASIGNADOS... FAVOR COMUNICARSE CON SU PROVEEDOR DE SISTEMA")
            End If

            If _FichaProducto.f_PrdProducto.RegistroDato.f_VerificarOferta Then
                Me.E_OFERTA.Visible = True
            Else
                Me.E_OFERTA.Visible = False
            End If

            xficha_empaque_1.Cargardata(_FichaProducto.f_PrdProducto.RegistroDato.tb_Precios.Rows(0))
            xficha_empaque_2.Cargardata(_FichaProducto.f_PrdProducto.RegistroDato.tb_Precios.Rows(1))
            xficha_empaque_3.Cargardata(_FichaProducto.f_PrdProducto.RegistroDato.tb_Precios.Rows(2))
            xficha_empaque_4.Cargardata(_FichaProducto.f_PrdProducto.RegistroDato.tb_Precios.Rows(3))

            Me.BT_ACTUALIZAR.Select()
            Me.BT_ACTUALIZAR.Focus()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub CargarCombos()
        CargarEmpaques()

        With Me.MCB_1
            .DataSource = emp_venta_1
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
        With Me.MCB_2
            .DataSource = emp_venta_2
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
        With Me.MCB_3
            .DataSource = emp_venta_3
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
        With Me.MCB_4
            .DataSource = emp_venta_4
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
        With Me.MCB_DETAL
            .DataSource = emp_venta_detal
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
    End Sub

    Sub CargarEmpaques()
        emp_venta_1.Rows.Clear()
        emp_venta_2.Rows.Clear()
        emp_venta_3.Rows.Clear()
        emp_venta_4.Rows.Clear()
        emp_venta_detal.Rows.Clear()

        g_MiData.F_GetData("select nombre x1,auto x2, * from productos_medida order by nombre", xtb_medida)

        emp_venta_1.Load(xtb_medida.CreateDataReader)
        emp_venta_2.Load(xtb_medida.CreateDataReader)
        emp_venta_3.Load(xtb_medida.CreateDataReader)
        emp_venta_4.Load(xtb_medida.CreateDataReader)
        emp_venta_detal.Load(xtb_medida.CreateDataReader)
    End Sub


    Public Sub New(ByVal xprd As FichaProducto, ByVal xinterfaceImplementar As IActualizarPrecios)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _FichaProducto = xprd
        _InterfaceImplementar = xinterfaceImplementar

        xtb_medida = New DataTable
        emp_venta_1 = New DataTable
        emp_venta_2 = New DataTable
        emp_venta_3 = New DataTable
        emp_venta_4 = New DataTable
        emp_venta_detal = New DataTable

        xficha_empaque_1 = New FichaProducto.Prd_Empaque.c_Registro
        xficha_empaque_2 = New FichaProducto.Prd_Empaque.c_Registro
        xficha_empaque_3 = New FichaProducto.Prd_Empaque.c_Registro
        xficha_empaque_4 = New FichaProducto.Prd_Empaque.c_Registro

        xficha_medida_1 = New FichaProducto.Prd_Medida
        xficha_medida_2 = New FichaProducto.Prd_Medida
        xficha_medida_3 = New FichaProducto.Prd_Medida
        xficha_medida_4 = New FichaProducto.Prd_Medida

        xinicio_oferta = _FichaProducto.f_PrdProducto.RegistroDato._FechaInicioOferta
        xfin_oferta = _FichaProducto.f_PrdProducto.RegistroDato._FechaCulminacionOferta
        xprecio_oferta = _FichaProducto.f_PrdProducto.RegistroDato._PrecioOferta._Full
        xutilidad_oferta = _FichaProducto.f_PrdProducto.RegistroDato._UtilidadPrecioOferta
    End Sub

    Private Sub LK_PRODUCTO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LK_PRODUCTO.LinkClicked
        If _InterfaceImplementar._LLamarFichaProducto Then
            If _FichaAccion = TipoAccion.Consulta Then
                Dim xficha As New FichaProductos(_FichaProducto.f_PrdProducto.RegistroDato._AutoProducto)
                With xficha
                    .ShowDialog()
                End With
                Me.Close()
            End If
        Else
            If _FichaAccion = TipoAccion.Consulta Then
                Try
                    _FichaProducto.f_PrdProducto.F_BuscarProducto(_FichaProducto.f_PrdProducto.RegistroDato._AutoProducto)
                    _FichaAccion = TipoAccion.Consulta

                    If _FichaProducto.f_PrdProducto.RegistroDato.f_VerificarOferta Then
                        Me.E_OFERTA.Visible = True
                    Else
                        Me.E_OFERTA.Visible = False
                    End If
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub BT_ACTUALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ACTUALIZAR.Click
        _FichaAccion = TipoAccion.Actualizar
    End Sub

    Private Sub MN_CONT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_CONT_1.LostFocus, MN_CONT_2.LostFocus, _
        MN_CONT_3.LostFocus, MN_CONT_4.LostFocus, MN_CONT_DETAL.LostFocus

        ActualizarCostos(sender)
    End Sub

    Sub ActualizarCostos(ByVal xsender As Object)
        Dim xcosto_empaque As Decimal = 0

        Dim xobj As MisControles.Controles.MisNumeros = CType(xsender, MisControles.Controles.MisNumeros)
        If xobj._Valor = 0 Then
            xobj.Text = String.Format("{0:#0}", 1)
        End If

        'xcosto_empaque = Decimal.Round(_FichaProducto.f_PrdProducto.RegistroDato._CostoCompra._Base_Inv * xobj._Valor, 2, MidpointRounding.AwayFromZero)

        If _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra > 0 Then
            xcosto_empaque = (_FichaProducto.f_PrdProducto.RegistroDato._CostoCompra._Base / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra) * xobj._Valor
        End If

        Select Case xobj.Name
            Case "MN_CONT_1"
                Me.E_COST_1.Text = String.Format("{0:#0.00}", xcosto_empaque)
                'CalculaUtilidad(1)
            Case "MN_CONT_2"
                Me.E_COST_2.Text = String.Format("{0:#0.00}", xcosto_empaque)
                'CalculaUtilidad(2)
            Case "MN_CONT_3"
                Me.E_COST_3.Text = String.Format("{0:#0.00}", xcosto_empaque)
                'CalculaUtilidad(3)
            Case "MN_CONT_4"
                Me.E_COST_4.Text = String.Format("{0:#0.00}", xcosto_empaque)
                'CalculaUtilidad(4)
            Case "MN_CONT_DETAL"
                Me.E_COST_DETAL.Text = String.Format("{0:#0.00}", xcosto_empaque)
                'CalculaUtilidad(0)
        End Select
    End Sub

    Private Sub MN_UT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_UT1_1.LostFocus, MN_UT1_2.LostFocus, _
                      MN_UT1_3.LostFocus, MN_UT1_4.LostFocus, MN_UT2_1.LostFocus, MN_UT2_2.LostFocus, _
                      MN_UT2_3.LostFocus, MN_UT2_4.LostFocus, MN_UT_DETAL.LostFocus

        ActualizaPrecios(sender)
    End Sub

    Sub ActualizaPrecios(ByVal xobj As Object)
        Dim xprecio As New DataSistema.MiDataSistema.DataSistema.Precio
        Dim xcont As MisControles.Controles.MisNumeros = CType(xobj, MisControles.Controles.MisNumeros)
        Dim xcosto As Decimal = 0
        Try


            If _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra > 0 Then
                xcosto = (_FichaProducto.f_PrdProducto.RegistroDato._CostoCompra._Base / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra)
            End If

            Dim xpn As Decimal = 0
            Select Case xcont.Name
                Case "MN_UT1_1"
                    xcosto = xcosto * Me.MN_CONT_1._Valor
                    If xcosto > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            xpn = Decimal.Round(xcosto + (xcosto * xcont._Valor / 100), 2, MidpointRounding.AwayFromZero)
                        Else
                            xpn = Decimal.Round(xcosto / ((100 - xcont._Valor) / 100), 2, MidpointRounding.AwayFromZero)
                        End If
                    Else
                        xpn = Me.MN_PN1_1._Valor
                    End If
                    With xprecio
                        ._Tasa = _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto
                        ._Base = xpn
                    End With
                    Me.MN_PN1_1.Text = String.Format("{0:#0.00}", xprecio._Base)
                    Me.MN_PF1_1.Text = String.Format("{0:#0.00}", xprecio._Full)
                Case "MN_UT1_2"
                    xcosto = xcosto * Me.MN_CONT_2._Valor
                    If xcosto > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            xpn = Decimal.Round(xcosto + (xcosto * xcont._Valor / 100), 2, MidpointRounding.AwayFromZero)
                        Else
                            xpn = Decimal.Round(xcosto / ((100 - xcont._Valor) / 100), 2, MidpointRounding.AwayFromZero)
                        End If
                    Else
                        xpn = Me.MN_PN1_2._Valor
                    End If

                    With xprecio
                        ._Tasa = _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto
                        ._Base = xpn
                    End With
                    Me.MN_PN1_2.Text = String.Format("{0:#0.00}", xprecio._Base)
                    Me.MN_PF1_2.Text = String.Format("{0:#0.00}", xprecio._Full)

                Case "MN_UT1_3"
                    xcosto = xcosto * Me.MN_CONT_3._Valor
                    If xcosto > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            xpn = Decimal.Round(xcosto + (xcosto * xcont._Valor / 100), 2, MidpointRounding.AwayFromZero)
                        Else
                            xpn = Decimal.Round(xcosto / ((100 - xcont._Valor) / 100), 2, MidpointRounding.AwayFromZero)
                        End If
                    Else
                        xpn = Me.MN_PN1_3._Valor
                    End If
                    With xprecio
                        ._Tasa = _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto
                        ._Base = xpn
                    End With
                    Me.MN_PN1_3.Text = String.Format("{0:#0.00}", xprecio._Base)
                    Me.MN_PF1_3.Text = String.Format("{0:#0.00}", xprecio._Full)

                Case "MN_UT1_4"
                    xcosto = xcosto * Me.MN_CONT_4._Valor
                    If xcosto > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            xpn = Decimal.Round(xcosto + (xcosto * xcont._Valor / 100), 2, MidpointRounding.AwayFromZero)
                        Else
                            xpn = Decimal.Round(xcosto / ((100 - xcont._Valor) / 100), 2, MidpointRounding.AwayFromZero)
                        End If
                    Else
                        xpn = Me.MN_PN1_4._Valor
                    End If
                    With xprecio
                        ._Tasa = _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto
                        ._Base = xpn
                    End With
                    Me.MN_PN1_4.Text = String.Format("{0:#0.00}", xprecio._Base)
                    Me.MN_PF1_4.Text = String.Format("{0:#0.00}", xprecio._Full)

                    'PRECIO #2

                Case "MN_UT2_1"
                    xcosto = xcosto * Me.MN_CONT_1._Valor
                    If xcosto > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            xpn = Decimal.Round(xcosto + (xcosto * xcont._Valor / 100), 2, MidpointRounding.AwayFromZero)
                        Else
                            xpn = Decimal.Round(xcosto / ((100 - xcont._Valor) / 100), 2, MidpointRounding.AwayFromZero)
                        End If
                    Else
                        xpn = Me.MN_PN2_1._Valor
                    End If
                    With xprecio
                        ._Tasa = _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto
                        ._Base = xpn
                    End With
                    Me.MN_PN2_1.Text = String.Format("{0:#0.00}", xprecio._Base)
                    Me.MN_PF2_1.Text = String.Format("{0:#0.00}", xprecio._Full)

                Case "MN_UT2_2"
                    xcosto = xcosto * Me.MN_CONT_2._Valor
                    If xcosto > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            xpn = Decimal.Round(xcosto + (xcosto * xcont._Valor / 100), 2, MidpointRounding.AwayFromZero)
                        Else
                            xpn = Decimal.Round(xcosto / ((100 - xcont._Valor) / 100), 2, MidpointRounding.AwayFromZero)
                        End If
                    Else
                        xpn = Me.MN_PN2_2._Valor
                    End If
                    With xprecio
                        ._Tasa = _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto
                        ._Base = xpn
                    End With
                    Me.MN_PN2_2.Text = String.Format("{0:#0.00}", xprecio._Base)
                    Me.MN_PF2_2.Text = String.Format("{0:#0.00}", xprecio._Full)

                Case "MN_UT2_3"
                    xcosto = xcosto * Me.MN_CONT_3._Valor
                    If xcosto > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            xpn = Decimal.Round(xcosto + (xcosto * xcont._Valor / 100), 2, MidpointRounding.AwayFromZero)
                        Else
                            xpn = Decimal.Round(xcosto / ((100 - xcont._Valor) / 100), 2, MidpointRounding.AwayFromZero)
                        End If
                    Else
                        xpn = Me.MN_PN2_3._Valor
                    End If
                    With xprecio
                        ._Tasa = _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto
                        ._Base = xpn
                    End With
                    Me.MN_PN2_3.Text = String.Format("{0:#0.00}", xprecio._Base)
                    Me.MN_PF2_3.Text = String.Format("{0:#0.00}", xprecio._Full)

                Case "MN_UT2_4"
                    xcosto = xcosto * Me.MN_CONT_4._Valor
                    If xcosto > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            xpn = Decimal.Round(xcosto + (xcosto * xcont._Valor / 100), 2, MidpointRounding.AwayFromZero)
                        Else
                            xpn = Decimal.Round(xcosto / ((100 - xcont._Valor) / 100), 2, MidpointRounding.AwayFromZero)
                        End If
                    Else
                        xpn = Me.MN_PN2_4._Valor
                    End If
                    With xprecio
                        ._Tasa = _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto
                        ._Base = xpn
                    End With
                    Me.MN_PN2_4.Text = String.Format("{0:#0.00}", xprecio._Base)
                    Me.MN_PF2_4.Text = String.Format("{0:#0.00}", xprecio._Full)

                Case "MN_UT_DETAL"
                    xcosto = xcosto * Me.MN_CONT_DETAL._Valor
                    If xcosto > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            xpn = Decimal.Round(xcosto + (xcosto * xcont._Valor / 100), 2, MidpointRounding.AwayFromZero)
                        Else
                            xpn = Decimal.Round(xcosto / ((100 - xcont._Valor) / 100), 2, MidpointRounding.AwayFromZero)
                            xpn = Math.Abs(xpn)
                        End If
                    Else
                        xpn = Me.MN_PN_DETAL._Valor
                    End If
                    With xprecio
                        ._Tasa = _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto
                        ._Base = xpn
                    End With
                    Me.MN_PN_DETAL.Text = String.Format("{0:#0.00}", xprecio._Base)
                    Me.MN_PF_DETAL.Text = String.Format("{0:#0.00}", xprecio._Full)
            End Select
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub MN_PN_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_PN1_1.LostFocus, MN_PN1_2.LostFocus, _
                           MN_PN1_3.LostFocus, MN_PN1_4.LostFocus, MN_PN2_1.LostFocus, MN_PN2_2.LostFocus, _
                           MN_PN2_3.LostFocus, MN_PN2_4.LostFocus, MN_PN_DETAL.LostFocus

        Dim xcont As MisControles.Controles.MisNumeros = CType(sender, MisControles.Controles.MisNumeros)
        Dim xcosto As Decimal = 0
        Dim xmargen As Decimal = 0
        Dim xprecio As New DataSistema.MiDataSistema.DataSistema.Precio(xcont._Valor, _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto)

        If _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra > 0 Then
            xcosto = _FichaProducto.f_PrdProducto.RegistroDato._CostoCompra._Base / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
        End If

        Select Case xcont.Name
            Case "MN_PN1_1"
                Me.MN_PN1_1.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF1_1.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT1_1.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT1_1, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_1._Valor
                    If xcosto > 0 Then
                        xmargen = (xprecio._Base - xcosto)
                    End If
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT1_1.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT1_1.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT1_1._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT1_1, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT1_1, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN1_1, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF1_1, "")
                    End If
                End If

            Case "MN_PN1_2"
                Me.MN_PN1_2.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF1_2.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT1_2.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT1_2, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_2._Valor
                    If xcosto > 0 Then
                        xmargen = (xprecio._Base - xcosto)
                    End If

                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT1_2.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT1_2.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT1_2._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT1_2, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT1_2, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN1_2, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF1_2, "")
                    End If
                End If

            Case "MN_PN1_3"
                Me.MN_PN1_3.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF1_3.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT1_3.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT1_3, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_3._Valor
                    If xcosto > 0 Then
                        xmargen = (xprecio._Base - xcosto)
                    End If

                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT1_3.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT1_3.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT1_3._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT1_3, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT1_3, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN1_3, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF1_3, "")
                    End If
                End If

            Case "MN_PN1_4"
                Me.MN_PN1_4.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF1_4.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT1_4.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT1_4, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_4._Valor
                    If xcosto > 0 Then
                        xmargen = (xprecio._Base - xcosto)
                    End If

                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT1_4.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT1_4.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT1_4._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT1_4, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT1_4, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN1_4, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF1_4, "")
                    End If
                End If

                'PRECIO #2
            Case "MN_PN2_1"
                Me.MN_PN2_1.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF2_1.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT2_1.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT2_1, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_1._Valor
                    If xcosto > 0 Then
                        xmargen = (xprecio._Base - xcosto)
                    End If

                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT2_1.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT2_1.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT2_1._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT2_1, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT2_1, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN2_1, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF2_1, "")
                    End If
                End If

            Case "MN_PN2_2"
                Me.MN_PN2_2.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF2_2.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT2_2.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT2_2, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_2._Valor
                    If xcosto > 0 Then
                        xmargen = (xprecio._Base - xcosto)
                    End If

                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT2_2.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT2_2.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT2_2._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT2_2, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT2_2, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN2_2, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF2_2, "")
                    End If
                End If

            Case "MN_PN2_3"
                Me.MN_PN2_3.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF2_3.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT2_3.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT2_3, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_3._Valor
                    If xcosto > 0 Then
                        xmargen = (xprecio._Base - xcosto)
                    End If

                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT2_3.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT2_3.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT2_3._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT2_3, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT2_3, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN2_3, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF2_3, "")
                    End If
                End If

            Case "MN_PN2_4"
                Me.MN_PN2_4.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF2_4.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT2_4.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT2_4, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_4._Valor
                    If xcosto > 0 Then
                        xmargen = (xprecio._Base - xcosto)
                    End If

                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT2_4.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT2_4.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT2_4._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT2_4, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT2_4, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN2_4, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF2_4, "")
                    End If
                End If

            Case "MN_PN_DETAL"
                Me.MN_PN_DETAL.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF_DETAL.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT_DETAL.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT_DETAL, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_DETAL._Valor
                    If xcosto > 0 Then
                        xmargen = (xprecio._Base - xcosto)
                    End If

                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT_DETAL.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT_DETAL.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT_DETAL._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT_DETAL, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT_DETAL, "")
                    End If
                End If
        End Select
    End Sub

    Private Sub MN_PF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_PF1_1.LostFocus, MN_PF1_2.LostFocus, _
                          MN_PF1_3.LostFocus, MN_PF1_4.LostFocus, MN_PF2_1.LostFocus, MN_PF2_2.LostFocus, _
                          MN_PF2_3.LostFocus, MN_PF2_4.LostFocus, MN_PF_DETAL.LostFocus

        Dim xcont As MisControles.Controles.MisNumeros = CType(sender, MisControles.Controles.MisNumeros)
        Dim xcosto As Decimal = 0
        Dim xmargen As Decimal = 0
        Dim xprecio As New DataSistema.MiDataSistema.DataSistema.Precio(xcont._Valor, _FichaProducto.f_PrdProducto.RegistroDato._TasaImpuesto, Precio.TipoFuncion.Desglozar)

        If _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra > 0 Then
            xcosto = _FichaProducto.f_PrdProducto.RegistroDato._CostoCompra._Base / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
        End If

        Select Case xcont.Name
            Case "MN_PF1_1"
                Me.MN_PN1_1.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF1_1.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT1_1.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT1_1, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_1._Valor
                    If xcosto > 0 Then
                        xmargen = (Me.MN_PN1_1._Valor - xcosto)
                    End If
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT1_1.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT1_1.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT1_1._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT1_1, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT1_1, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF1_1, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN1_1, "")
                    End If
                End If

            Case "MN_PF1_2"
                Me.MN_PN1_2.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF1_2.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT1_2.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT1_2, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_2._Valor
                    If xcosto > 0 Then
                        xmargen = (Me.MN_PN1_2._Valor - xcosto)
                    End If
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT1_2.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT1_2.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT1_2._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT1_2, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT1_2, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF1_2, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN1_2, "")
                    End If
                End If

            Case "MN_PF1_3"
                Me.MN_PN1_3.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF1_3.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT1_3.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT1_3, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_3._Valor
                    If xcosto > 0 Then
                        xmargen = (Me.MN_PN1_3._Valor - xcosto)
                    End If
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT1_3.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT1_3.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT1_3._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT1_3, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT1_3, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF1_3, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN1_3, "")
                    End If
                End If

            Case "MN_PF1_4"
                Me.MN_PN1_4.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF1_4.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT1_4.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT1_4, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_4._Valor
                    If xcosto > 0 Then
                        xmargen = (Me.MN_PN1_4._Valor - xcosto)
                    End If
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT1_4.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT1_4.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT1_4._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT1_4, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT1_4, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF1_4, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN1_4, "")
                    End If
                End If

                'PRECIO #2
            Case "MN_PF2_1"
                Me.MN_PN2_1.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF2_1.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT2_1.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT2_1, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_1._Valor
                    If xcosto > 0 Then
                        xmargen = (Me.MN_PN2_1._Valor - xcosto)
                    End If
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT2_1.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT2_1.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT2_1._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT2_1, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT2_1, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF2_1, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN2_1, "")
                    End If
                End If

            Case "MN_PF2_2"
                Me.MN_PN2_2.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF2_2.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT2_2.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT2_2, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_2._Valor
                    If xcosto > 0 Then
                        xmargen = (Me.MN_PN2_2._Valor - xcosto)
                    End If
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT2_2.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT2_2.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT2_2._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT2_2, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT2_2, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF2_2, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN2_2, "")
                    End If
                End If

            Case "MN_PF2_3"
                Me.MN_PN2_3.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF2_3.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT2_3.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT2_3, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_3._Valor
                    If xcosto > 0 Then
                        xmargen = (Me.MN_PN2_3._Valor - xcosto)
                    End If
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT2_3.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT2_3.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT2_3._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT2_3, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT2_3, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF2_3, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN2_3, "")
                    End If
                End If

            Case "MN_PF2_4"
                Me.MN_PN2_4.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF2_4.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT2_4.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT2_4, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_4._Valor
                    If xcosto > 0 Then
                        xmargen = (Me.MN_PN2_4._Valor - xcosto)
                    End If
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT2_4.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT2_4.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT2_4._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT2_4, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT2_4, "")
                        Me.ErrorProvider1.SetError(Me.MN_PF2_4, "")
                        Me.ErrorProvider1.SetError(Me.MN_PN2_4, "")
                    End If
                End If

            Case "MN_PF_DETAL"
                Me.MN_PN_DETAL.Text = String.Format("{0:#0.00}", xprecio._Base)
                Me.MN_PF_DETAL.Text = String.Format("{0:#0.00}", xprecio._Full)

                If xprecio._Base = 0 Then
                    Me.MN_UT_DETAL.Text = String.Format("{0:#0.00}", 0)
                    Me.ErrorProvider1.SetError(Me.MN_UT_DETAL, "")
                Else
                    xcosto = xcosto * Me.MN_CONT_DETAL._Valor
                    If xcosto > 0 Then
                        xmargen = (Me.MN_PN_DETAL._Valor - xcosto)
                    End If

                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                        Me.MN_UT_DETAL.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xcosto, xmargen))
                    Else
                        Me.MN_UT_DETAL.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio._Base, xmargen))
                    End If

                    If Me.MN_UT_DETAL._Valor < 0 Then
                        Me.ErrorProvider1.SetError(Me.MN_UT_DETAL, "Precio Por Debajo Del Costo")
                    Else
                        Me.ErrorProvider1.SetError(Me.MN_UT_DETAL, "")
                    End If
                End If
        End Select
    End Sub

    Function VerificarOk() As Boolean
        Dim xret As Boolean = True

        If MN_UT1_1._Valor >= 0 And MN_UT1_2._Valor >= 0 And MN_UT1_3._Valor >= 0 And MN_UT1_4._Valor >= 0 _
          And MN_UT2_1._Valor >= 0 And MN_UT2_2._Valor >= 0 And MN_UT2_3._Valor >= 0 And MN_UT2_4._Valor >= 0 And MN_UT_DETAL._Valor >= 0 Then

            Me.ErrorProvider1.SetError(MN_UT1_1, "")
            Me.ErrorProvider1.SetError(MN_UT2_1, "")
            Me.ErrorProvider1.SetError(MN_UT1_2, "")
            Me.ErrorProvider1.SetError(MN_UT2_2, "")
            Me.ErrorProvider1.SetError(MN_UT1_3, "")
            Me.ErrorProvider1.SetError(MN_UT2_3, "")
            Me.ErrorProvider1.SetError(MN_UT1_4, "")
            Me.ErrorProvider1.SetError(MN_UT2_4, "")
            Me.ErrorProvider1.SetError(MN_UT_DETAL, "")
        Else
            xret = False
        End If

        Dim xcost As Decimal = 0
        Decimal.TryParse(E_COST_1.Text, xcost)
        If (Me.MN_PN1_1._Valor = 0) Then
            Me.ErrorProvider1.SetError(Me.MN_PN1_1, "")
        Else
            If Me.MN_PN1_1._Valor < xcost Then
                Me.ErrorProvider1.SetError(Me.MN_PN1_1, "Precio Por Debajo Del Costo")
                xret = False
            Else
                Me.ErrorProvider1.SetError(Me.MN_PN1_1, "")
            End If
        End If
        If (Me.MN_PN2_1._Valor = 0) Then
            Me.ErrorProvider1.SetError(Me.MN_PN2_1, "")
        Else
            If Me.MN_PN2_1._Valor < xcost Then
                Me.ErrorProvider1.SetError(Me.MN_PN2_1, "Precio Por Debajo Del Costo")
                xret = False
            Else
                Me.ErrorProvider1.SetError(Me.MN_PN2_1, "")
            End If
        End If

        xcost = 0
        Decimal.TryParse(E_COST_2.Text, xcost)
        If (Me.MN_PN1_2._Valor = 0) Then
            Me.ErrorProvider1.SetError(Me.MN_PN1_2, "")
        Else
            If Me.MN_PN1_2._Valor < xcost Then
                Me.ErrorProvider1.SetError(Me.MN_PN1_2, "Precio Por Debajo Del Costo")
                xret = False
            Else
                Me.ErrorProvider1.SetError(Me.MN_PN1_2, "")
            End If
        End If
        If (Me.MN_PN2_2._Valor = 0) Then
            Me.ErrorProvider1.SetError(Me.MN_PN2_2, "")
        Else
            If Me.MN_PN2_2._Valor < xcost Then
                Me.ErrorProvider1.SetError(Me.MN_PN2_2, "Precio Por Debajo Del Costo")
                xret = False
            Else
                Me.ErrorProvider1.SetError(Me.MN_PN2_2, "")
            End If
        End If

        xcost = 0
        Decimal.TryParse(E_COST_3.Text, xcost)
        If (Me.MN_PN1_3._Valor = 0) Then
            Me.ErrorProvider1.SetError(Me.MN_PN1_3, "")
        Else
            If Me.MN_PN1_3._Valor < xcost Then
                Me.ErrorProvider1.SetError(Me.MN_PN1_3, "Precio Por Debajo Del Costo")
                xret = False
            Else
                Me.ErrorProvider1.SetError(Me.MN_PN1_3, "")
            End If
        End If
        If (Me.MN_PN2_3._Valor = 0) Then
            Me.ErrorProvider1.SetError(Me.MN_PN2_3, "")
        Else
            If Me.MN_PN2_3._Valor < xcost Then
                Me.ErrorProvider1.SetError(Me.MN_PN2_3, "Precio Por Debajo Del Costo")
                xret = False
            Else
                Me.ErrorProvider1.SetError(Me.MN_PN2_3, "")
            End If
        End If

        xcost = 0
        Decimal.TryParse(E_COST_4.Text, xcost)
        If (Me.MN_PN1_4._Valor = 0) Then
            Me.ErrorProvider1.SetError(Me.MN_PN1_4, "")
        Else
            If Me.MN_PN1_4._Valor < xcost Then
                Me.ErrorProvider1.SetError(Me.MN_PN1_4, "Precio Por Debajo Del Costo")
                xret = False
            Else
                Me.ErrorProvider1.SetError(Me.MN_PN1_4, "")
            End If
        End If
        If (Me.MN_PN2_4._Valor = 0) Then
            Me.ErrorProvider1.SetError(Me.MN_PN2_4, "")
        Else
            If Me.MN_PN2_4._Valor < xcost Then
                Me.ErrorProvider1.SetError(Me.MN_PN2_4, "Precio Por Debajo Del Costo")
                xret = False
            Else
                Me.ErrorProvider1.SetError(Me.MN_PN2_4, "")
            End If
        End If

        xcost = 0
        Decimal.TryParse(E_COST_DETAL.Text, xcost)
        If (Me.MN_PN_DETAL._Valor = 0) Then
            Me.ErrorProvider1.SetError(Me.MN_PN_DETAL, "")
        Else
            If Me.MN_PN_DETAL._Valor < xcost Then
                Me.ErrorProvider1.SetError(Me.MN_PN_DETAL, "Precio Por Debajo Del Costo")
                xret = False
            Else
                Me.ErrorProvider1.SetError(Me.MN_PN_DETAL, "")
            End If
        End If

        Return xret
    End Function

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        If VerificarOk() Then
            GuardarPrecios()
        Else
            Funciones.MensajeDeAlerta("Hay Precios Por Debajo Del Costo, Verifique Por Favor...")
        End If
    End Sub

    Sub GuardarPrecios()
        If MessageBox.Show("Estas Seguro De Querer Actualizar Estos Precios De Venta ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim empq1 As New FichaProducto.Prd_Producto.c_AgregarPrecioEmpaque
                Dim empq2 As New FichaProducto.Prd_Producto.c_AgregarPrecioEmpaque
                Dim empq3 As New FichaProducto.Prd_Producto.c_AgregarPrecioEmpaque
                Dim empq4 As New FichaProducto.Prd_Producto.c_AgregarPrecioEmpaque
                Dim xlista As New List(Of FichaProducto.Prd_Producto.c_AgregarPrecioEmpaque)

                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.Ambos Or _
                    g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.PMayor Then

                    If MN_PN1_1._Valor <> xficha_empaque_1._PrecioNeto_1 Or _
                      MN_PN2_1._Valor <> xficha_empaque_1._PrecioNeto_2 Or _
                      Me.MCB_1.SelectedValue <> xficha_empaque_1._AutoMedida Or _
                      Me.MN_CONT_1._Valor <> xficha_empaque_1._ContenidoEmpaque Then

                        xficha_medida_1.F_BuscarMedida(Me.MCB_1.SelectedValue)
                        With empq1
                            ._ContenidoEmpaque = Me.MN_CONT_1._Valor
                            ._FichaMedidaEmpaque = xficha_medida_1.RegistroDato
                            ._IdSeguridad = xficha_empaque_1._IdSeguridad
                            ._PrecioAnterior_1 = xficha_empaque_1._PrecioNeto_1
                            ._PrecioAnterior_2 = xficha_empaque_1._PrecioNeto_2
                            ._PrecioReferencia = xficha_empaque_1._ReferenciaEmpaqueSeleccionado
                            ._PrecioNuevo_1 = Me.MN_PN1_1._Valor
                            ._PrecioNuevo_2 = Me.MN_PN2_1._Valor
                            ._UtilidadPrecio_1 = Me.MN_UT1_1._Valor
                            ._UtilidadPrecio_2 = Me.MN_UT2_1._Valor
                        End With
                        xlista.Add(empq1)
                    End If

                    If MN_PN1_2._Valor <> xficha_empaque_2._PrecioNeto_1 Or _
                      MN_PN2_2._Valor <> xficha_empaque_2._PrecioNeto_2 Or _
                      Me.MCB_2.SelectedValue <> xficha_empaque_2._AutoMedida Or _
                      Me.MN_CONT_2._Valor <> xficha_empaque_2._ContenidoEmpaque Then

                        xficha_medida_2.F_BuscarMedida(Me.MCB_2.SelectedValue)
                        With empq2
                            ._ContenidoEmpaque = Me.MN_CONT_2._Valor
                            ._FichaMedidaEmpaque = xficha_medida_2.RegistroDato
                            ._IdSeguridad = xficha_empaque_2._IdSeguridad
                            ._PrecioAnterior_1 = xficha_empaque_2._PrecioNeto_1
                            ._PrecioAnterior_2 = xficha_empaque_2._PrecioNeto_2
                            ._PrecioReferencia = xficha_empaque_2._ReferenciaEmpaqueSeleccionado
                            ._PrecioNuevo_1 = Me.MN_PN1_2._Valor
                            ._PrecioNuevo_2 = Me.MN_PN2_2._Valor
                            ._UtilidadPrecio_1 = Me.MN_UT1_2._Valor
                            ._UtilidadPrecio_2 = Me.MN_UT2_2._Valor
                        End With
                        xlista.Add(empq2)
                    End If

                    If MN_PN1_3._Valor <> xficha_empaque_3._PrecioNeto_1 Or _
                      MN_PN2_3._Valor <> xficha_empaque_3._PrecioNeto_2 Or _
                      Me.MCB_3.SelectedValue <> xficha_empaque_3._AutoMedida Or _
                      Me.MN_CONT_3._Valor <> xficha_empaque_3._ContenidoEmpaque Then

                        xficha_medida_3.F_BuscarMedida(Me.MCB_3.SelectedValue)
                        With empq3
                            ._ContenidoEmpaque = Me.MN_CONT_3._Valor
                            ._FichaMedidaEmpaque = xficha_medida_3.RegistroDato
                            ._IdSeguridad = xficha_empaque_3._IdSeguridad
                            ._PrecioAnterior_1 = xficha_empaque_3._PrecioNeto_1
                            ._PrecioAnterior_2 = xficha_empaque_3._PrecioNeto_2
                            ._PrecioReferencia = xficha_empaque_3._ReferenciaEmpaqueSeleccionado
                            ._PrecioNuevo_1 = Me.MN_PN1_3._Valor
                            ._PrecioNuevo_2 = Me.MN_PN2_3._Valor
                            ._UtilidadPrecio_1 = Me.MN_UT1_3._Valor
                            ._UtilidadPrecio_2 = Me.MN_UT2_3._Valor
                        End With
                        xlista.Add(empq3)
                    End If

                    If MN_PN1_4._Valor <> xficha_empaque_4._PrecioNeto_1 Or _
                      MN_PN2_4._Valor <> xficha_empaque_4._PrecioNeto_2 Or _
                      Me.MCB_4.SelectedValue <> xficha_empaque_4._AutoMedida Or _
                      Me.MN_CONT_4._Valor <> xficha_empaque_4._ContenidoEmpaque Then

                        xficha_medida_4.F_BuscarMedida(Me.MCB_4.SelectedValue)
                        With empq4
                            ._ContenidoEmpaque = Me.MN_CONT_4._Valor
                            ._FichaMedidaEmpaque = xficha_medida_4.RegistroDato
                            ._IdSeguridad = xficha_empaque_4._IdSeguridad
                            ._PrecioAnterior_1 = xficha_empaque_4._PrecioNeto_1
                            ._PrecioAnterior_2 = xficha_empaque_4._PrecioNeto_2
                            ._PrecioReferencia = xficha_empaque_4._ReferenciaEmpaqueSeleccionado
                            ._PrecioNuevo_1 = Me.MN_PN1_4._Valor
                            ._PrecioNuevo_2 = Me.MN_PN2_4._Valor
                            ._UtilidadPrecio_1 = Me.MN_UT1_4._Valor
                            ._UtilidadPrecio_2 = Me.MN_UT2_4._Valor
                        End With
                        xlista.Add(empq4)
                    End If
                End If

                Dim xdetal As New FichaProducto.Prd_Producto.Detal
                _FichaProducto.f_PrdMedida.F_BuscarMedida(Me.MCB_DETAL.SelectedValue)
                With xdetal
                    ._ContenidoEmpaqueVenta = Me.MN_CONT_DETAL._Valor
                    ._EstatusOferta = _FichaProducto.f_PrdProducto.RegistroDato._EstatusOferta
                    ._FichaMedidaEmpaqueVenta = _FichaProducto.f_PrdMedida.RegistroDato
                    ._FinOferta = xfin_oferta
                    ._InicioOferta = xinicio_oferta
                    ._PrecioAnterior = _FichaProducto.f_PrdProducto.RegistroDato._PrecioDetal._Base
                    ._PrecioOferta = xprecio_oferta
                    ._PrecioSugerido = Me.MN_PSUGERIDO._Valor
                    ._PrecioVenta = Me.MN_PN_DETAL._Valor
                    ._UtilidadOferta = xutilidad_oferta
                    ._UtilidadVenta = Me.MN_UT_DETAL._Valor
                End With

                Dim xprecios As New FichaProducto.Prd_Producto.ActualizarPrecioMayor
                With xprecios
                    ._AutoProducto = _FichaProducto.f_PrdProducto.RegistroDato._AutoProducto
                    ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                    ._Fecha = g_MiData.p_FechaDelMotorBD
                    ._Hora = g_MiData.p_HoraDelMotorBD
                    ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                    ._ListaEmpaquesMayor = xlista
                    ._IdSeguridadProducto = _FichaProducto.f_PrdProducto.RegistroDato._IdSeguridad
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.PMayor Then
                        ._TipoPrecioModificar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.Ambos
                    Else
                        ._TipoPrecioModificar = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar
                    End If
                    ._VentaDetal = xdetal
                End With

                _FichaProducto.f_PrdProducto.F_ActualizarPrecios(xprecios)
                RaiseEvent _ActualizarProducto()
                RaiseEvent _ActualizarProductoId(_FichaProducto.f_PrdProducto.RegistroDato._AutoProducto)

                ActualizarProducto()
                _FichaAccion = TipoAccion.Consulta
                Funciones.MensajeDeOk("Precios Actualizados Satisfactoriamente...")
                Me.Close()
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.PDetal Then
                    Me.MCB_DETAL.Select()
                    Me.MCB_DETAL.Focus()
                Else
                    Me.MCB_1.Select()
                    Me.MCB_1.Focus()
                End If
            End Try
        Else
            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._TipoPrecioManejar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.PDetal Then
                Me.MCB_DETAL.Select()
                Me.MCB_DETAL.Focus()
            Else
                Me.MCB_1.Select()
                Me.MCB_1.Focus()
            End If
        End If
    End Sub

    Sub ActualizarProducto()
        _FichaProducto.f_PrdProducto.F_BuscarProducto(_FichaProducto.f_PrdProducto.RegistroDato._AutoProducto)
        xficha_empaque_1.Cargardata(_FichaProducto.f_PrdProducto.RegistroDato.tb_Precios.Rows(0))
        xficha_empaque_2.Cargardata(_FichaProducto.f_PrdProducto.RegistroDato.tb_Precios.Rows(1))
        xficha_empaque_3.Cargardata(_FichaProducto.f_PrdProducto.RegistroDato.tb_Precios.Rows(2))
        xficha_empaque_4.Cargardata(_FichaProducto.f_PrdProducto.RegistroDato.tb_Precios.Rows(3))
    End Sub

    Private Sub MN_UT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MN_UT1_1.Validating, MN_UT1_2.Validating, _
                MN_UT1_3.Validating, MN_UT1_4.Validating, MN_UT2_1.Validating, MN_UT2_2.Validating, MN_UT2_3.Validating, MN_UT2_4.Validating, MN_UT_DETAL.Validating

        Dim xut As MisControles.Controles.MisNumeros = CType(sender, MisControles.Controles.MisNumeros)
        If xut._Valor >= 100 And g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlPrecioVenta Then
            xut.Text = "0.0"
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label21.Click

    End Sub

    Private Sub Panel7_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class

Public Interface IActualizarPrecios
    ReadOnly Property _LLamarFichaProducto() As Boolean
End Interface

Public Class ActualizarPrecio_Compra
    Implements IActualizarPrecios

    Public ReadOnly Property _LLamarFichaProducto() As Boolean Implements IActualizarPrecios._LLamarFichaProducto
        Get
            Return True
        End Get
    End Property
End Class

Public Class ActualizarPrecio_Inventario
    Implements IActualizarPrecios

    Public ReadOnly Property _LLamarFichaProducto() As Boolean Implements IActualizarPrecios._LLamarFichaProducto
        Get
            Return False
        End Get
    End Property
End Class