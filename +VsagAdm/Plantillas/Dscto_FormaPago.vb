Imports DataSistema.MiDataSistema.DataSistema

Public Class Dscto_FormaPago
    Dim xestatus_salida As Boolean
    Dim xtotales As TotalesDoc
    Dim xhabilitarpagos As Boolean
    Dim xvalidarpagos As Boolean
    Dim xtb_pagos As DataTable
    Dim xbinding As BindingSource
    Dim xmonto_pagado As Decimal
    Dim xmonto_faltante As Decimal
    Dim xmonto_total As Decimal
    Dim xdsctoTasa As Decimal

    Property _TasaDescuento() As Decimal
        Get
            Return xdsctoTasa
        End Get
        Set(ByVal value As Decimal)
            xdsctoTasa = value
        End Set
    End Property

    Property _MontoTotal() As Decimal
        Get
            Return xmonto_total
        End Get
        Set(ByVal value As Decimal)
            xmonto_total = value
        End Set
    End Property

    Property _MontoPagado() As Decimal
        Get
            Return xmonto_pagado
        End Get
        Set(ByVal value As Decimal)
            xmonto_pagado = value
        End Set
    End Property

    Property _MontoFaltante() As Decimal
        Get
            Return xmonto_faltante
        End Get
        Set(ByVal value As Decimal)
            xmonto_faltante = value
        End Set
    End Property

    Property _HabilitarPagos() As Boolean
        Get
            Return xhabilitarpagos
        End Get
        Set(ByVal value As Boolean)
            xhabilitarpagos = value
        End Set
    End Property

    Property _ValidarPagos() As Boolean
        Get
            Return xvalidarpagos
        End Get
        Set(ByVal value As Boolean)
            xvalidarpagos = value
        End Set
    End Property

    Property _MisTotales() As TotalesDoc
        Get
            Return xtotales
        End Get
        Set(ByVal value As TotalesDoc)
            xtotales = value
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

    Private Sub Dscto_FormaPago_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _EstatusSalida = False Then
            If MessageBox.Show("Estas Seguro De Salir y Cerrar Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                RecalcularMontoSinMedida(_MisTotales)
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Dscto_FormaPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False And _HabilitarPagos = True) Then
            Dim xrow As DataRow = xtb_pagos.NewRow
            If _MontoTotal > _MontoPagado Then
                Try
                    Dim xreg As New FichaGlobal.c_MediosPagos
                    xreg.F_BuscarRegistro(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoMedioPago_Por_Defecto)

                    If xreg.RegistroDato._EstatusTipoPago Then
                        xrow(0) = xreg.RegistroDato._NombreTipoPago
                        xrow(1) = _MontoFaltante
                        xrow(2) = ""
                        xrow(3) = ""
                        xrow(4) = xreg.RegistroDato._AutoTipoPago
                        xrow(5) = xreg.RegistroDato._CodigoTipoPago

                        xtb_pagos.Rows.Add(xrow)
                        xtb_pagos.AcceptChanges()
                    Else
                        MessageBox.Show("Error... Medio De Pago Seleccionado Por Defecto Esta En Estado Inactivo, Verifique Por Favor !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False And e.Control = False And _HabilitarPagos = True) Then
            AgregarModoficarTipoPago("A")
        End If
        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False And e.Control = False And _HabilitarPagos = True) Then
            PagoElectronico()
        End If
    End Sub

    Private Sub Dscto_FormaPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Dscto_FormaPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MCHB_DIVISA.Enabled = habilitarSolicitudDivisa
    End Sub

    Private Sub Dscto_FormaPago_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private _pagoElectronico As Boolean = False
    Sub PagoElectronico()
        If RecalcularMonto(_MisTotales) Then
            RecalcularMontoConMedida(_MisTotales)
            AsignarPagoElectronico(_MisTotales._TotalGeneral)
            _pagoElectronico = True
            Procesar()
        End If
    End Sub

    Function RecalcularMonto(ByVal totales As TotalesDoc) As Boolean
        Dim r As Boolean = False
        If MiDecretoEmergencia.DecretoEmergenciaActivo Then
            r = True
        End If

        'If MiDecretoEmergencia.DecretoEmergenciaActivo Then
        '    If totales._TotalGeneral <= MiDecretoEmergencia.MontoValidar Then
        '        If totales.Cliente.r_CiRif.Trim.Length <= 10 Then
        '            If _MontoPagado = 0 Then
        '                r = True
        '            End If
        '        End If
        '    End If
        'End If
        Return r
    End Function

    Sub RecalcularMontoConMedida(ByVal totales As TotalesDoc)
        Dim TasaAplica As Integer = 0
        For Each cond In MiDecretoEmergencia.Condiciones
            If totales._TotalGeneral > cond.MontoMayorA Then
                If cond.MontoMenorIgual > 0 Then
                    If totales._TotalGeneral <= cond.MontoMenorIgual Then
                        TasaAplica = cond.TasaAplica
                        Exit For
                    End If
                Else
                    TasaAplica = cond.TasaAplica
                    Exit For
                End If
            End If
        Next

        Dim mNeto As Decimal = 0.0
        Dim mImpuesto As Decimal = 0.0
        Dim mBaseExcento As Decimal = 0.0
        Dim mBase1 As Decimal = 0.0
        Dim mBase2 As Decimal = 0.0
        Dim mBase3 As Decimal = 0.0
        Dim Tasa2 As Decimal = totales._TasaIva2
        Dim Tasa3 As Decimal = totales._TasaIva3

        For Each xreg As DataRow In totales.Items.Rows
            If TasaAplica = 2 Then
                If xreg("tipoTasa") = "1" Then
                    xreg("tipoTasa") = "2"
                    xreg("TasaIva") = Tasa2
                End If
            Else
                If xreg("tipoTasa") = "1" Then
                    xreg("tipoTasa") = "3"
                    xreg("TasaIva") = Tasa3
                End If
            End If
            Dim mItem As Decimal = 0.0
            Dim mIva As Decimal = 0.0
            Dim d As Decimal = 0.0

            mItem = (xreg("cantidad") * xreg("precioNeto"))
            d = mItem * xreg("descuento") / 100
            mItem -= d
            mIva = mItem * (xreg("tasaIva") / 100)
            mNeto += mItem
            mImpuesto += mIva
            If xreg("tipoTasa") = "0" Then
                mBaseExcento += mItem
            End If
            If xreg("tipoTasa") = "1" Then
                mBase1 += mItem
            End If
            If xreg("tipoTasa") = "2" Then
                mBase2 += mItem
            End If
            If xreg("tipoTasa") = "3" Then
                mBase3 += mItem
            End If
        Next
        totales._Exento = mBaseExcento
        totales._Neto1 = mBase1
        totales._Neto2 = mBase2
        totales._Neto3 = mBase3
        ReCalcular(1)
    End Sub

    Sub RecalcularMontoSinMedida(ByVal totales As TotalesDoc)
        Dim mNeto As Decimal = 0.0
        Dim mImpuesto As Decimal = 0.0
        Dim mBaseExcento As Decimal = 0.0
        Dim mBase1 As Decimal = 0.0
        Dim mBase2 As Decimal = 0.0
        Dim mBase3 As Decimal = 0.0
        Dim Tasa1 As Decimal = totales._TasaIva1

        For Each xreg As DataRow In totales.Items.Rows
            If xreg("tipoTasa") = "3" Then
                xreg("tipoTasa") = "1"
                xreg("TasaIva") = Tasa1
            End If
            If xreg("tipoTasa") = "2" Then
                xreg("tipoTasa") = "1"
                xreg("TasaIva") = Tasa1
            End If

            Dim mItem As Decimal = 0.0
            Dim mIva As Decimal = 0.0
            Dim d As Decimal = 0.0

            mItem = (xreg("cantidad") * xreg("precioNeto"))
            d = mItem * xreg("descuento") / 100
            mItem -= d
            mIva = mItem * (xreg("tasaIva") / 100)
            mNeto += mItem
            mImpuesto += mIva
            If xreg("tipoTasa") = "0" Then
                mBaseExcento += mItem
            End If
            If xreg("tipoTasa") = "1" Then
                mBase1 += mItem
            End If
            If xreg("tipoTasa") = "2" Then
                mBase2 += mItem
            End If
            If xreg("tipoTasa") = "3" Then
                mBase3 += mItem
            End If
        Next
        totales._Exento = mBaseExcento
        totales._Neto1 = mBase1
        totales._Neto2 = mBase2
        totales._Neto3 = mBase3
        ReCalcular(1)
    End Sub

    Sub AsignarPagoElectronico(ByVal monto As Decimal)
        Dim xrow As DataRow = xtb_pagos.NewRow
        xrow(0) = "T.DEBITO"
        xrow(1) = monto
        xrow(2) = ""
        xrow(3) = ""
        xrow(4) = "0000000003"
        xrow(5) = "03"
        xtb_pagos.Rows.Add(xrow)
        xtb_pagos.AcceptChanges()
    End Sub

    Sub LimpiarPantalla()
        Me.E_IMPUESTO.Text = "0.0"
        Me.E_PAGO.Text = "0.0"
        Me.E_RESTA.Text = "0.0"
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

    Sub Inicializa()
        Try
            _EstatusSalida = False
            LimpiarPantalla()

            With MN_DSC1
                ._ConSigno = False
                ._Formato = "99.99"
                .Text = "0.0"
            End With
            With MN_DSC2
                ._ConSigno = False
                ._Formato = "999999999.99"
                .Text = "0.0"
            End With
            With MN_CARGO1
                ._ConSigno = False
                ._Formato = "99.99"
                .Text = "0.0"
            End With
            With MN_CARGO2
                ._ConSigno = False
                ._Formato = "999999999.99"
                .Text = "0.0"
            End With

            With Me.MCHB_ANTICIPO
                .Checked = False
                .Enabled = IIf(_MisTotales._SaldoAFavorAnticipo > 0, True, False)
            End With

            With Me.MCHB_NC
                .Checked = False
                .Enabled = IIf(_MisTotales._SaldoAFavorNotaCredito > 0, True, False)
            End With

            ActualizaPlantilla()
            Me.MN_DSC1.Text = String.Format("{0:#0.00}", _MisTotales._TasaDescuento)
            ReCalcular(1)
            Me.MN_CARGO1.Text = String.Format("{0:#0.00}", _MisTotales._TasaCargo)
            ReCalcular(1)

            With MisGrid1
                .Columns.Add("col0", "Tipo Pago")
                .Columns.Add("col1", "Monto")
                .Columns.Add("col2", "Numero")
                .Columns.Add("col3", "Banco")

                .Columns(0).Width = 100
                .Columns(1).Width = 120
                .Columns(2).Width = 120
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbinding

                .Columns("col0").DataPropertyName = "TipoPago"
                .Columns("col1").DataPropertyName = "Monto"
                .Columns("col2").DataPropertyName = "Planilla"
                .Columns("col3").DataPropertyName = "Agencia"

                .Columns("col1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns("col1").DefaultCellStyle.Format = "#0.00"

                .Enabled = _HabilitarPagos
                .AllowUserToDeleteRows = True
                .Ocultar(5)

                AddHandler .RowsRemoved, AddressOf ActualizarTablaEliminados
                Actualiza()
            End With

            Me.MN_DSC1.Select()
            Me.MN_DSC1.Focus()

            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._PermitirModosPagos_Anticipos_NC Then
                If _HabilitarPagos And _ValidarPagos Then
                    If _MisTotales._SaldoAFavorAnticipo > 0 Then
                        Me.MCHB_ANTICIPO.Checked = True
                    End If
                    If _MisTotales._SaldoAFavorNotaCredito > 0 Then
                        Me.MCHB_NC.Checked = True
                    End If
                Else
                    Me.MCHB_ANTICIPO.Enabled = False
                    Me.MCHB_NC.Enabled = False
                End If
            Else
                Me.MCHB_ANTICIPO.Enabled = False
                Me.MCHB_NC.Enabled = False
            End If

            If _TasaDescuento > 0 Then
                Me.MN_DSC1.Text = String.Format("{0:#0.00}", _TasaDescuento)
            End If

            RecalcularMontoSinMedida(_MisTotales)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub ActualizarTablaEliminados(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        Actualiza()
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        Procesar()

        'Dim xp As Boolean = False

        ''RecalcularMonto()
        ''For Each r In xtb_pagos.Rows
        ''    MsgBox(r(0).ToString)
        ''Next

        'If _ValidarPagos Then
        '    If _MontoPagado >= _MontoTotal Then
        '        xp = True
        '    Else
        '        MessageBox.Show("Monto Pago Incompleto, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End If
        'Else
        '    xp = True
        'End If

        'If xp Then
        '    If MessageBox.Show("Procesar/Guardar Este Documento ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
        '        Me._EstatusSalida = True
        '        Me._MisTotales._TasaDescuento = Me.MN_DSC1._Valor
        '        Me._MisTotales._TasaCargo = Me.MN_CARGO1._Valor
        '        Me._MisTotales._TablaPagos = xtb_pagos

        '        If g_VisorPrecio IsNot Nothing Then
        '            If _MontoPagado > 0 Then
        '                Dim x As Decimal = 0
        '                Decimal.TryParse(Me.E_RESTA.Text, x)
        '                g_VisorPrecio.CambioDar(x)
        '            Else
        '                Dim x As Decimal = 0
        '                Decimal.TryParse(Me.E_RESTA.Text, x)
        '                x = x * (-1)
        '                g_VisorPrecio.CambioDar(x)
        '            End If
        '        End If
        '        Me.Close()
        '    End If
        'End If
    End Sub

    Sub Procesar()
        Dim xp As Boolean = False

        'RecalcularMonto()

        If _ValidarPagos Then
            If _MontoPagado >= _MontoTotal Then
                xp = True
            Else
                MessageBox.Show("Monto Pago Incompleto, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            'If _MontoPagado >= _MisTotales._TotalGeneral Then
            '    xp = True
            'Else
            '    MessageBox.Show("Monto Pago Incompleto, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        Else
            xp = True
        End If

        If xp Then
            If MessageBox.Show("Procesar/Guardar Este Documento ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me._EstatusSalida = True
                Me._MisTotales._TasaDescuento = Me.MN_DSC1._Valor
                Me._MisTotales._TasaCargo = Me.MN_CARGO1._Valor
                Me._MisTotales._TablaPagos = xtb_pagos

                If g_VisorPrecio IsNot Nothing Then
                    If _MontoPagado > 0 Then
                        Dim x As Decimal = 0
                        Decimal.TryParse(Me.E_RESTA.Text, x)
                        g_VisorPrecio.CambioDar(x)
                    Else
                        Dim x As Decimal = 0
                        Decimal.TryParse(Me.E_RESTA.Text, x)
                        x = x * (-1)
                        g_VisorPrecio.CambioDar(x)
                    End If
                End If
                Me.Close()
            Else
                If _pagoElectronico Then
                    _pagoElectronico = False
                    RecalcularMontoSinMedida(_MisTotales)
                    xtb_pagos.Rows.Clear()
                    ReCalcular(1)
                End If
            End If
        End If
    End Sub

    Sub New(ByRef totales As TotalesDoc, ByVal habilitar_pagos As Boolean, Optional ByVal validar_pago As Boolean = True)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MisTotales = totales
        _HabilitarPagos = habilitar_pagos
        If _HabilitarPagos = False Then
            _ValidarPagos = _HabilitarPagos
        Else
            _ValidarPagos = validar_pago
        End If

        If _MisTotales._TablaPagos Is Nothing Then
            xtb_pagos = New DataTable
            AddHandler xtb_pagos.RowChanged, AddressOf ActualizarTabla

            xbinding = New BindingSource(xtb_pagos, "")

            xtb_pagos.Columns.Add("TipoPago", GetType(String))
            xtb_pagos.Columns.Add("Monto", GetType(Decimal))
            xtb_pagos.Columns.Add("Planilla", GetType(String))
            xtb_pagos.Columns.Add("Agencia", GetType(String))
            xtb_pagos.Columns.Add("AutoTipoPago", GetType(String))
            xtb_pagos.Columns.Add("CodigoTipoPago", GetType(String))
        End If

        _estatusDivisa = False
        habilitarSolicitudDivisa = False
    End Sub

    Dim ModificarCheckBox As Boolean = False
    Sub Actualiza()
        Try
            Dim xmonto As Decimal = 0
            Dim xtot As Decimal = 0
            Decimal.TryParse(Me.E_TOTAL.Text, xtot)
            Dim AnticipoEncontrado As Boolean = False
            Dim NotaCreditoEncontrado As Boolean = False

            For Each xr As DataRow In xtb_pagos.Rows
                If xr.RowState <> DataRowState.Deleted Then
                    If xr("AutoTipoPago").ToString.Trim = "AN00000001" Then
                        AnticipoEncontrado = True
                    End If
                    If xr("AutoTipoPago").ToString.Trim = "NC00000001" Then
                        NotaCreditoEncontrado = True
                    End If
                    If IsDBNull(xr) Or IsNothing(xr) Then
                    Else
                        If xr.IsNull(1) Then
                        Else
                            If xr.RowState <> DataRowState.Deleted Then
                                xmonto += xr(1)
                            End If
                        End If
                    End If
                End If
            Next
            Me.E_PAGO.Text = String.Format("{0:#0.00}", xmonto)

            Dim xt As Decimal = 0
            xt = Math.Abs(xmonto - xtot)
            If xmonto >= xtot Then
                Me.E_TIPO.Text = "Cambio:"
            Else
                Me.E_TIPO.Text = "Resta:"
            End If
            Me.E_RESTA.Text = String.Format("{0:#0.00}", xt)

            _MontoPagado = xmonto
            _MontoFaltante = xt

            If AnticipoEncontrado Then
                ModificarCheckBox = True
                Me.MCHB_ANTICIPO.Checked = True
            Else
                ModificarCheckBox = True
                Me.MCHB_ANTICIPO.Checked = False
            End If

            If NotaCreditoEncontrado Then
                ModificarCheckBox = True
                Me.MCHB_NC.Checked = True
            Else
                ModificarCheckBox = True
                Me.MCHB_NC.Checked = False
            End If

            ModificarCheckBox = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarTabla(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        Actualiza()
    End Sub

    Private Sub MN_DSC1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DSC1.LostFocus, MN_CARGO1.LostFocus
        ReCalcular(1)
    End Sub

    Private Sub MN_DSC2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DSC2.LostFocus, MN_CARGO2.LostFocus
        ReCalcular(2)
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
            If descuento > 0 Then
                d = Decimal.Round(descuento / Me._MisTotales._Subtotal * 100, 2, MidpointRounding.AwayFromZero)
                Me.MN_DSC1.Text = String.Format("{0:#0.00}", d)
            End If
        End If

        'xd1 = Decimal.Round(xexe * MN_DSC1._Valor / 100, 2, MidpointRounding.AwayFromZero)
        'xd2 = Decimal.Round(xmn1 * MN_DSC1._Valor / 100, 2, MidpointRounding.AwayFromZero)
        'xd3 = Decimal.Round(xmn2 * MN_DSC1._Valor / 100, 2, MidpointRounding.AwayFromZero)
        'xd4 = Decimal.Round(xmn3 * MN_DSC1._Valor / 100, 2, MidpointRounding.AwayFromZero)
        'descuento = Decimal.Round(xd1 + xd2 + xd3 + xd4, 2, MidpointRounding.AwayFromZero)

        xd1 = xexe * MN_DSC1._Valor / 100
        xd2 = xmn1 * MN_DSC1._Valor / 100
        xd3 = xmn2 * MN_DSC1._Valor / 100
        xd4 = xmn3 * MN_DSC1._Valor / 100
        xd1 = Decimal.Round(xd1, 2, MidpointRounding.AwayFromZero)
        xd2 = Decimal.Round(xd2, 2, MidpointRounding.AwayFromZero)
        xd3 = Decimal.Round(xd3, 2, MidpointRounding.AwayFromZero)
        xd4 = Decimal.Round(xd4, 2, MidpointRounding.AwayFromZero)
        descuento = (xd1 + xd2 + xd3 + xd4)
        Me.MN_DSC2.Text = String.Format("{0:#0.00}", descuento)

        'xexe = Decimal.Round(xexe - (xexe * MN_DSC1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'xmn1 = Decimal.Round(xmn1 - (xmn1 * MN_DSC1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'xmn2 = Decimal.Round(xmn2 - (xmn2 * MN_DSC1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'xmn3 = Decimal.Round(xmn3 - (xmn3 * MN_DSC1._Valor / 100), 2, MidpointRounding.AwayFromZero)

        xexe = (xexe - xd1)
        xmn1 = (xmn1 - xd2)
        xmn2 = (xmn2 - xd3)
        xmn3 = (xmn3 - xd4)
        xexe = Decimal.Round(xexe, 2, MidpointRounding.AwayFromZero)
        xmn1 = Decimal.Round(xmn1, 2, MidpointRounding.AwayFromZero)
        xmn2 = Decimal.Round(xmn2, 2, MidpointRounding.AwayFromZero)
        xmn3 = Decimal.Round(xmn3, 2, MidpointRounding.AwayFromZero)

        If xtipo = 2 Then
            cargo = Me.MN_CARGO2._Valor()
            Dim d As Decimal = 0
            If cargo > 0 Then
                Dim x As Decimal = Decimal.Round(Me._MisTotales._Subtotal - descuento, 2, MidpointRounding.AwayFromZero)
                d = Decimal.Round(cargo / x * 100, 2, MidpointRounding.AwayFromZero)
                Me.MN_CARGO1.Text = String.Format("{0:#0.00}", d)
            End If
        End If

        'xc1 = Decimal.Round((xexe * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'xc2 = Decimal.Round((xmn1 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'xc3 = Decimal.Round((xmn2 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'xc4 = Decimal.Round((xmn3 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'cargo = Decimal.Round(xc1 + xc2 + xc3 + xc4, 2, MidpointRounding.AwayFromZero)

        'xc1 = (xexe * MN_CARGO1._Valor / 100)
        'xc2 = (xmn1 * MN_CARGO1._Valor / 100)
        'xc3 = (xmn2 * MN_CARGO1._Valor / 100)
        'xc4 = (xmn3 * MN_CARGO1._Valor / 100)
        'cargo = (xc1 + xc2 + xc3 + xc4)
        'Me.MN_CARGO2.Text = String.Format("{0:#0.00}", cargo)

        'xexe = Decimal.Round(xexe + (xexe * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'xmn1 = Decimal.Round(xmn1 + (xmn1 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'xmn2 = Decimal.Round(xmn2 + (xmn2 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'xmn3 = Decimal.Round(xmn3 + (xmn3 * MN_CARGO1._Valor / 100), 2, MidpointRounding.AwayFromZero)
        'xsubt = Decimal.Round(xexe + xmn1 + xmn2 + xmn3, 2, MidpointRounding.AwayFromZero)

        'xexe = (xexe + (xexe * MN_CARGO1._Valor / 100))
        'xmn1 = (xmn1 + (xmn1 * MN_CARGO1._Valor / 100))
        'xmn2 = (xmn2 + (xmn2 * MN_CARGO1._Valor / 100))
        'xmn3 = (xmn3 + (xmn3 * MN_CARGO1._Valor / 100))

        'xiv1 = Decimal.Round(xmn1 * _MisTotales._TasaIva1 / 100, 2, MidpointRounding.AwayFromZero)
        'xiv2 = Decimal.Round(xmn2 * _MisTotales._TasaIva2 / 100, 2, MidpointRounding.AwayFromZero)
        'xiv3 = Decimal.Round(xmn3 * _MisTotales._TasaIva3 / 100, 2, MidpointRounding.AwayFromZero)
        'xiva = Decimal.Round(xiv1 + xiv2 + xiv3, 2, MidpointRounding.AwayFromZero)

        xsubt = (xexe + xmn1 + xmn2 + xmn3)
        xiv1 = (xmn1 * _MisTotales._TasaIva1 / 100)
        xiv2 = (xmn2 * _MisTotales._TasaIva2 / 100)
        xiv3 = (xmn3 * _MisTotales._TasaIva3 / 100)
        xiv1 = Decimal.Round(xiv1, 2, MidpointRounding.AwayFromZero)
        xiv2 = Decimal.Round(xiv2, 2, MidpointRounding.AwayFromZero)
        xiv3 = Decimal.Round(xiv3, 2, MidpointRounding.AwayFromZero)
        xiva = (xiv1 + xiv2 + xiv3)
        xtotal = (xsubt + xiva)

        Me.E_SUB_2.Text = String.Format("{0:#0.00}", xsubt)
        Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", xiva)
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", xtotal)

        Me._MisTotales.MontoCargo = cargo
        Me._MisTotales._MontoDescuento = descuento

        _MontoTotal = xtotal
        Actualiza()
    End Sub

    Private Sub MN_DSC1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DSC1.Enter, MN_DSC2.Enter, MN_CARGO1.Enter, MN_CARGO2.Enter
        Try
            Dim xmn As MisControles.Controles.MisNumeros = CType(sender, MisControles.Controles.MisNumeros)
            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Dar_Descuento_Al_Finalizar Then
                xmn.ReadOnly = False
            Else
                xmn.ReadOnly = True
            End If
        Catch ex As Exception
            Me.FindForm.SelectNextControl(sender, True, True, True, True)
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AgregarModoficarTipoPago(ByVal xtipo As String)
        Try
            Dim xest As Boolean
            Dim xrow As DataRow = Nothing
            Dim xseg As Boolean = True

            If xtipo.Trim.ToUpper = "M" Then
                If xbinding.Current IsNot Nothing Then
                    xrow = CType(xbinding.Current, DataRowView).Row
                    If xrow("AutoTipoPago").ToString.Trim = "AN00000001" Or xrow("AutoTipoPago").ToString.Trim = "NC00000001" Then
                        Throw New Exception("Modo De Pago No Puede Ser Modificado")
                    End If
                    xest = True
                Else
                    xseg = False
                End If
            Else
                xrow = xtb_pagos.NewRow
                xrow(1) = _MontoFaltante
                xest = False
            End If

            If xseg Then
                Dim xficha As New TipoPago(xrow)
                With xficha
                    .ShowDialog()

                    If ._EstatusSalida Then
                        If xest Then
                            xbinding.Current(0) = ._Registro(0)
                            xbinding.Current(1) = ._Registro(1)
                            xbinding.Current(2) = ._Registro(2)
                            xbinding.Current(3) = ._Registro(3)
                            xbinding.Current(4) = ._Registro(4)
                            xbinding.Current(5) = ._Registro(5)
                            xbinding.EndEdit()
                        Else
                            xtb_pagos.Rows.Add(xrow)
                            xtb_pagos.AcceptChanges()
                        End If
                    End If
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje DE Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AgregarModoficarTipoPagoElectronico(ByVal xtipo As String)
        Try
            Dim xest As Boolean
            Dim xrow As DataRow = Nothing
            Dim xseg As Boolean = True

            If xtipo.Trim.ToUpper = "M" Then
                If xbinding.Current IsNot Nothing Then
                    xrow = CType(xbinding.Current, DataRowView).Row
                    If xrow("AutoTipoPago").ToString.Trim = "AN00000001" Or xrow("AutoTipoPago").ToString.Trim = "NC00000001" Then
                        Throw New Exception("Modo De Pago No Puede Ser Modificado")
                    End If
                    xest = True
                Else
                    xseg = False
                End If
            Else
                xrow = xtb_pagos.NewRow
                xrow(1) = _MontoFaltante
                xest = False
            End If

            If xseg Then
                Dim xficha As New TipoPago(xrow)
                With xficha
                    .ShowDialog()

                    If ._EstatusSalida Then
                        If xest Then
                            xbinding.Current(0) = ._Registro(0)
                            xbinding.Current(1) = ._Registro(1)
                            xbinding.Current(2) = ._Registro(2)
                            xbinding.Current(3) = ._Registro(3)
                            xbinding.Current(4) = ._Registro(4)
                            xbinding.Current(5) = ._Registro(5)
                            xbinding.EndEdit()
                        Else
                            xtb_pagos.Rows.Add(xrow)
                            xtb_pagos.AcceptChanges()
                        End If
                    End If
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje DE Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MisGrid1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid1.Accion
        AgregarModoficarTipoPago("M")
    End Sub

    Private Sub MCHB_ANTICIPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ANTICIPO.CheckedChanged
        If _HabilitarPagos And _ValidarPagos Then
            If ModificarCheckBox = False Then
                If _MisTotales._SaldoAFavorAnticipo > 0 And Me._MontoFaltante >= 0 Then
                    Dim xseg As Boolean = True
                    If xtb_pagos.Rows.Count > 0 Then
                        For Each xr As DataRow In xtb_pagos.Rows
                            If xr.RowState <> DataRowState.Deleted Then
                                If xr("AutoTipoPago").ToString.Trim = "AN00000001" Then
                                    xtb_pagos.Rows.Remove(xr)
                                    xtb_pagos.AcceptChanges()
                                    xseg = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If

                    If xseg = True Then
                        Dim xrow_nuevo As DataRow = xtb_pagos.NewRow
                        xrow_nuevo(0) = "ANTICIPO"
                        xrow_nuevo(1) = IIf(_MontoFaltante >= _MisTotales._SaldoAFavorAnticipo, _MisTotales._SaldoAFavorAnticipo, _MontoFaltante)
                        xrow_nuevo(2) = ""
                        xrow_nuevo(3) = ""
                        xrow_nuevo(4) = "AN00000001"
                        xrow_nuevo(5) = "AN"

                        xtb_pagos.Rows.Add(xrow_nuevo)
                        xtb_pagos.AcceptChanges()
                    End If
                Else
                    MessageBox.Show("Error... Monto SobrePasa El Total Abonado/Pagado... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                ModificarCheckBox = False
            End If
        End If
    End Sub

    Private Sub MCHB_NC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_NC.CheckedChanged
        If _HabilitarPagos And _ValidarPagos Then
            If ModificarCheckBox = False Then
                If _MisTotales._SaldoAFavorNotaCredito > 0 And Me._MontoFaltante >= 0 Then
                    Dim xseg As Boolean = True
                    If xtb_pagos.Rows.Count > 0 Then
                        For Each xr As DataRow In xtb_pagos.Rows
                            If xr.RowState <> DataRowState.Deleted Then
                                If xr("AutoTipoPago").ToString.Trim = "NC00000001" Then
                                    xtb_pagos.Rows.Remove(xr)
                                    xtb_pagos.AcceptChanges()
                                    xseg = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If

                    If xseg = True Then
                        Dim xrow_nuevo As DataRow = xtb_pagos.NewRow
                        xrow_nuevo(0) = "NOTA CREDITO"
                        xrow_nuevo(1) = IIf(_MontoFaltante >= _MisTotales._SaldoAFavorNotaCredito, _MisTotales._SaldoAFavorNotaCredito, _MontoFaltante)
                        xrow_nuevo(2) = ""
                        xrow_nuevo(3) = ""
                        xrow_nuevo(4) = "NC00000001"
                        xrow_nuevo(5) = "NC"

                        xtb_pagos.Rows.Add(xrow_nuevo)
                        xtb_pagos.AcceptChanges()
                    End If
                Else
                    MessageBox.Show("Error... Monto SobrePasa El Total Abonado/Pagado... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                ModificarCheckBox = False
            End If
        End If
    End Sub


    ''

    Dim _estatusDivisa As Boolean
    Dim habilitarSolicitudDivisa As Boolean


    ReadOnly Property EstatusDivisa As Boolean
        Get
            Return _estatusDivisa
        End Get
    End Property


    Public Sub SetHabilitarSolicitudDivsa(valor As Boolean)
        habilitarSolicitudDivisa = valor
    End Sub


    Private Sub MCHB_DIVISA_CheckedChanged(sender As Object, e As EventArgs) Handles MCHB_DIVISA.CheckedChanged
        If habilitarSolicitudDivisa Then
            _estatusDivisa = MCHB_DIVISA.Checked
        End If
    End Sub


End Class