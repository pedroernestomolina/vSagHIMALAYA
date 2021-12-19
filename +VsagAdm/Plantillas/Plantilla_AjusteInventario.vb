Imports DataSistema.MiDataSistema.DataSistema

Public Class Plantilla_AjusteInventario
    Event _ActualizarDepositos()

    Enum Accion As Integer
        Ajustar = 1
        Inactivo = 2
    End Enum

    Dim xprd As FichaProducto
    Dim xtb_conceptos As DataTable
    Dim xbs_conceptos As BindingSource
    Dim xbs_depositos As BindingSource
    Dim xaccion As Accion

    ReadOnly Property _On() As Boolean
        Get
            Return True
        End Get
    End Property

    ReadOnly Property _Off() As Boolean
        Get
            Return False
        End Get
    End Property

    Property _FichaAccion() As Accion
        Get
            Return xaccion
        End Get
        Set(ByVal value As Accion)
            xaccion = value

            If value = Accion.Inactivo Then
                Controles(_Off)
                LimpiarControles()
            Else
                Controles(_On)
            End If
        End Set
    End Property

    Sub Controles(ByVal xest As Boolean)
        Me.MT_DETALLE.Enabled = xest
        Me.MN_AJUSTE.Enabled = xest
        Me.MCB_CONCEPTO.Enabled = xest
        Me.BT_GUARDAR.Enabled = xest
        Me.BT_PROCESAR.Enabled = Not xest
        Me.MisGrid1.Enabled = Not xest
        Me.RB_COMPRA.Enabled = xest
        Me.RB_UNIDAD.Enabled = xest

        If xest Then
            Me.RB_COMPRA.Checked = True
            Me.MN_AJUSTE.Text = "0.0"
            Me.MT_DETALLE.Text = ""
            Me.MCB_CONCEPTO.Select()
            Me.MCB_CONCEPTO.Focus()
        End If
    End Sub

    Sub New(ByVal xfichaprd As FichaProducto)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _FichaProducto = xfichaprd
        xtb_conceptos = New DataTable
        xbs_conceptos = New BindingSource(xtb_conceptos, "")
        xbs_depositos = New BindingSource(_FichaProducto.f_PrdProducto.RegistroDato.tb_Existencia, "")
    End Sub

    Property _FichaProducto() As FichaProducto
        Get
            Return xprd
        End Get
        Set(ByVal value As FichaProducto)
            xprd = value
        End Set
    End Property

    Private Sub Plantilla_AjusteInventario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _FichaAccion = Accion.Inactivo Then
            e.Cancel = False
        Else
            If MessageBox.Show("Estas Seguro De Perder Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                _FichaAccion = Accion.Inactivo
            End If
            e.Cancel = True
        End If
    End Sub

    Private Sub Plantilla_AjusteInventario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_AjusteInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Plantilla_AjusteInventario_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub InicializarControles()
        Me.RB_COMPRA.Checked = True

        With MisGrid1
            .Columns.Add("col0", "Nombre")
            .Columns.Add("col1", "Cod")
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xbs_depositos
            .Columns(0).DataPropertyName = "xnombre"
            .Columns(1).DataPropertyName = "xcodigo"

            .Ocultar(3)
        End With

        With Me.MT_DETALLE
            .Text = ""
            .MaxLength = 120
        End With

        With Me.MN_AJUSTE
            ._ConSigno = True
            If _FichaProducto.f_PrdProducto.RegistroDato._CantDecimalesEmpaqueCompra > 0 Then
                ._Formato = "999999." + "999".Substring(0, _FichaProducto.f_PrdProducto.RegistroDato._CantDecimalesEmpaqueCompra)
            Else
                ._Formato = "999999"
            End If
            .Text = "0.0"
        End With

        With MCB_CONCEPTO
            .DataSource = xbs_conceptos
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With
    End Sub

    Sub LimpiarControles()
        Me.E_CONCEPTO_CODIGO.Text = ""
        Me.E_DEPOSITO_CODIGO.Text = ""
        Me.E_DEPOSITO_NOMBRE.Text = ""
        Me.E_EXISTENCIA_ACTUAL.Text = "0.0"
        Me.E_EXISTENCIA_DISPONIBLE.Text = "0.0"
        Me.E_EXISTENCIA_RESERVA.Text = "0.0"
        Me.E_NIVEL_MINIMO.Text = "0.0"
        Me.E_NIVEL_OPTIMO.Text = "0.0"
        Me.E_PRODUCTO.Text = ""
        Me.E_SALDO.Text = "0.0"
        Me.E_UBICACION_1.Text = ""
        Me.E_UBICACION_2.Text = ""
        Me.E_UBICACION_3.Text = ""
        Me.E_UBICACION_4.Text = ""
        Me.E_EMPAQUE.Text = ""

        Me.MT_DETALLE.Text = ""
        Me.MN_AJUSTE.Text = ""
        If xtb_conceptos.Rows.Count > 0 Then
            Me.MCB_CONCEPTO.SelectedIndex = 0
        End If

        ActualizaDeposito()
        ActualizaConcepto()
        Me.RB_COMPRA.Checked = True
        Me.E_PRODUCTO.Text = _FichaProducto.f_PrdProducto.RegistroDato._DescripcionDetallaDelProducto
        Me.E_EMPAQUE.Text = "(" + _FichaProducto.f_PrdProducto.RegistroDato._NombreEmpaqueCompra + ") / " + _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra.ToString.Trim
    End Sub

    Sub Inicializa()
        Try
            g_MiData.F_GetData("select codigo xcod, nombre xnom, * from productos_conceptos order by nombre", xtb_conceptos)

            InicializarControles()

            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With

            AddHandler xbs_depositos.PositionChanged, AddressOf ActualizarDeposito
            AddHandler xbs_conceptos.PositionChanged, AddressOf ActualizarConcepto

            _FichaAccion = Accion.Inactivo
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub ActualizarDeposito(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizaDeposito()
    End Sub

    Sub ActualizaDeposito()
        If xbs_depositos.Current IsNot Nothing Then
            Try
                Dim xdr As DataRow = CType(xbs_depositos.Current, System.Data.DataRowView).Row
                _FichaProducto.f_PrdDeposito.M_CargarRegistro(xdr)

                Me.E_DEPOSITO_NOMBRE.Text = _FichaProducto.f_PrdDeposito.RegistroDato._NombreDeposito
                Me.E_DEPOSITO_CODIGO.Text = _FichaProducto.f_PrdDeposito.RegistroDato._CodigoDeposito

                Me.E_UBICACION_1.Text = _FichaProducto.f_PrdDeposito.RegistroDato._Ubicacion_1
                Me.E_UBICACION_2.Text = _FichaProducto.f_PrdDeposito.RegistroDato._Ubicacion_2
                Me.E_UBICACION_3.Text = _FichaProducto.f_PrdDeposito.RegistroDato._Ubicacion_3
                Me.E_UBICACION_4.Text = _FichaProducto.f_PrdDeposito.RegistroDato._Ubicacion_4
                Me.E_NIVEL_MINIMO.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdDeposito.RegistroDato._NivelMinimo)
                Me.E_NIVEL_OPTIMO.Text = String.Format("{0:#0.00}", _FichaProducto.f_PrdDeposito.RegistroDato._NivelOptimo)

                Dim xreal As Decimal = 0
                Dim xreservada As Decimal = 0
                Dim xdisponible As Decimal = 0

                If _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra > 0 Then
                    xreal = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReal / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
                    xreservada = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReservada / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
                    xdisponible = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaDisponible / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
                End If

                If _FichaProducto.f_PrdProducto.RegistroDato._CantDecimalesEmpaqueCompra > 2 Then
                    Me.E_EXISTENCIA_ACTUAL.Text = String.Format("{0:#0.000}", xreal)
                    Me.E_EXISTENCIA_RESERVA.Text = String.Format("{0:#0.000}", xreservada)
                    Me.E_EXISTENCIA_DISPONIBLE.Text = String.Format("{0:#0.000}", xdisponible)
                Else
                    Me.E_EXISTENCIA_ACTUAL.Text = String.Format("{0:#0.00}", xreal)
                    Me.E_EXISTENCIA_RESERVA.Text = String.Format("{0:#0.00}", xreservada)
                    Me.E_EXISTENCIA_DISPONIBLE.Text = String.Format("{0:#0.00}", xdisponible)
                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
                Me.Close()
            End Try
        End If
    End Sub

    Sub ActualizarConcepto(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizaConcepto()
    End Sub

    Sub ActualizaConcepto()
        If xbs_conceptos.Current IsNot Nothing Then
            Try
                Dim xdr As DataRow = CType(xbs_conceptos.Current, System.Data.DataRowView).Row
                _FichaProducto.f_PrdConcepto.M_Cargardata(xdr)

                Me.E_CONCEPTO_CODIGO.Text = _FichaProducto.f_PrdConcepto.RegistroDato._CodigoConcepto
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub L_EXISTENCIA_RESERVA_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles L_EXISTENCIA_RESERVA.LinkClicked
        Dim xficha As New ExistenciaReservada(_FichaProducto.f_PrdProducto.RegistroDato._AutoProducto)
        With xficha
            .ShowDialog()
        End With
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If xbs_depositos.Current IsNot Nothing Then
            _FichaAccion = Accion.Ajustar
        Else
            Funciones.MensajeDeAlerta("No Hay Depositos Para Realizar Un Ajuste, Verifique Por Favor...")
        End If
    End Sub

    Private Sub L_CONCEPTO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles L_CONCEPTO.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Concepto.F_Permitir()

            Dim xForm As New Plantilla_11(New ProductosConcepto)
            With xForm
                AddHandler xForm.ActualizarFicha, AddressOf CargarConceptos
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub CargarConceptos()
        If _FichaAccion = Accion.Inactivo Then
            Me.MCB_CONCEPTO.Enabled = True
            g_MiData.F_GetData("select codigo xcod, nombre xnom, * from productos_conceptos order by nombre", xtb_conceptos)
            Me.MCB_CONCEPTO.Enabled = False
        Else
            g_MiData.F_GetData("select codigo xcod, nombre xnom, * from productos_conceptos order by nombre", xtb_conceptos)
        End If
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        If Math.Abs(MN_AJUSTE._Valor) > 0 Then
            If MT_DETALLE.r_Valor <> "" Then
                If MessageBox.Show("Guardar Este Movimiento Para Este Producto ?", "*** ALERTA ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim xconcepto As New FichaProducto.Prd_Concepto.c_Registro
                        Dim xdeposito As New FichaGlobal.c_Depositos.c_Registro

                        If xbs_conceptos.Current IsNot Nothing Then
                            Dim xr As DataRow = CType(xbs_conceptos.Current, System.Data.DataRowView).Row
                            xconcepto.CargarData(xr)
                        Else
                            Throw New Exception("DEBE ESPECIFICAR UN CONCEPTO DE MOVIMIENTO DEL ALMACEN")
                        End If

                        If xbs_depositos.Current IsNot Nothing Then
                            Dim xr As DataRow = CType(xbs_depositos.Current, System.Data.DataRowView).Row
                            xdeposito.CargarData(xr)
                        Else
                            Throw New Exception("DEBE ESPECIFICAR UN DEPOSITO PARA REALIZAR EL MOVIMIENTO")
                        End If

                        If MN_AJUSTE._Valor < 0 Then
                            If Me.RB_COMPRA.Checked Then
                                If Math.Abs(MN_AJUSTE._Valor) > (_FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReal / _FichaProducto.f_PrdDeposito.RegistroDato._ContenidoEmpaqueCompra) Then
                                    Throw New Exception("ERROR EN LA CANTIDAD, CANTIDAD A AJUSTAR ES MAYOR A LA CANTIDAD REAL")
                                End If
                            ElseIf Me.RB_UNIDAD.Checked Then
                                If Math.Abs(MN_AJUSTE._Valor) > _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReal Then
                                    Throw New Exception("ERROR EN LA CANTIDAD, CANTIDAD A AJUSTAR ES MAYOR A LA CANTIDAD REAL")
                                End If
                            End If
                        End If

                        Dim xmov As New FichaProducto.Prd_Movimiento.c_AgregarMovimiento
                        With xmov
                            If Me.RB_COMPRA.Checked Then
                                ._CantidadAjuste = Me.MN_AJUSTE._Valor
                            ElseIf Me.RB_UNIDAD.Checked Then
                                If _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra > 0 Then
                                    ._CantidadAjuste = Me.MN_AJUSTE._Valor / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
                                Else
                                    Throw New Exception("ERROR EN UNIDAD DE EMPAQUE DE COMPRA, NO PUEDE ESTAR EN CERO(0)")
                                End If
                            End If
                            ._ConceptoMovimiento = xconcepto
                            ._DepositoOrigen = xdeposito
                            ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                            ._FechaMovimiento = g_MiData.p_FechaDelMotorBD
                            ._Hora = g_MiData.p_HoraDelMotorBD
                            ._IdSeguridad_DepositoMovimiento = _FichaProducto.f_PrdDeposito.RegistroDato._IdSeguridad
                            ._NotasDetalle = MT_DETALLE.r_Valor
                            ._Producto = _FichaProducto.f_PrdProducto.RegistroDato
                            ._Sucursal = g_MiData.f_FichaGlobal.f_Negocio.RegistroDato.c_CodigoSucursal.c_Texto
                            ._Usuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                        End With

                        Dim xmovimiento As New FichaProducto.Prd_Movimiento
                        With xmovimiento
                            AddHandler ._ActualizarFicha, AddressOf CargarFicha
                            .F_MovimientoInventario(xmov)
                        End With
                    Catch ex As Exception
                        Funciones.MensajeDeError(ex.Message)
                    End Try
                Else
                    Me.MCB_CONCEPTO.Select()
                    Me.MCB_CONCEPTO.Focus()
                End If
            Else
                Funciones.MensajeDeAlerta("Debes Indicar El Motivo Por El Cual Estas Haciendo Este Movimiento...")
                Me.MT_DETALLE.Select()
                Me.MT_DETALLE.Focus()
            End If
        Else
            Funciones.MensajeDeAlerta("Monto Del Ajuste Debe Ser Un Valor Positivo / Negativo Dirente De Cero(0)...")
            Me.MN_AJUSTE.Select()
            Me.MN_AJUSTE.Focus()
        End If
    End Sub

    Sub CargarFicha()
        RaiseEvent _ActualizarDepositos()
        Funciones.MensajeDeOk("Movimiento Realizado Satisfactoriamente...")
        _FichaAccion = Accion.Inactivo
        Me.Close()
    End Sub

    Private Sub MN_AJUSTE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_AJUSTE.LostFocus
        If xbs_depositos.Current IsNot Nothing Then
            Try
                Dim xsaldo As Decimal = 0

                If Me.RB_COMPRA.Checked Then
                    xsaldo = (_FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReal / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra) + Me.MN_AJUSTE._Valor
                Else
                    xsaldo = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReal + Me.MN_AJUSTE._Valor
                End If

                If _FichaProducto.f_PrdProducto.RegistroDato._CantDecimalesEmpaqueCompra > 2 Then
                    Me.E_SALDO.Text = String.Format("{0:#0.000}", xsaldo)
                Else
                    Me.E_SALDO.Text = String.Format("{0:#0.00}", xsaldo)
                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub RB_UNIDAD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_UNIDAD.CheckedChanged
        Dim xreal As Decimal = 0
        Dim xreservada As Decimal = 0
        Dim xdisponible As Decimal = 0

        If RB_UNIDAD.Checked = True Then
            Me.E_EMPAQUE.Text = "(UNIDAD)/ 1"

            If _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra > 0 Then
                xreal = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReal
                xreservada = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReservada
                xdisponible = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaDisponible
            End If

            With Me.MN_AJUSTE
                ._Formato = "999999"
                .Text = ""
            End With
        Else
            Me.E_EMPAQUE.Text = "(" + _FichaProducto.f_PrdProducto.RegistroDato._NombreEmpaqueCompra + ") / " + _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra.ToString.Trim

            If _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra > 0 Then
                xreal = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReal / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
                xreservada = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaReservada / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
                xdisponible = _FichaProducto.f_PrdDeposito.RegistroDato._MercanciaDisponible / _FichaProducto.f_PrdProducto.RegistroDato._ContEmpqCompra
            End If

            With Me.MN_AJUSTE
                If _FichaProducto.f_PrdProducto.RegistroDato._CantDecimalesEmpaqueCompra > 2 Then
                    ._Formato = "999999.999"
                Else
                    ._Formato = "999999"
                End If
                .Text = ""
            End With
        End If

        Me.E_SALDO.Text = "0.0"
        Dim xformato As String = "{0:#0.00}"
        If _FichaProducto.f_PrdProducto.RegistroDato._CantDecimalesEmpaqueCompra > 2 Then
            xformato = "{0:#0.000}"
        End If

        Me.E_EXISTENCIA_ACTUAL.Text = String.Format(xformato, xreal)
        Me.E_EXISTENCIA_RESERVA.Text = String.Format(xformato, xreservada)
        Me.E_EXISTENCIA_DISPONIBLE.Text = String.Format(xformato, xdisponible)

        Me.MN_AJUSTE.Select()
        Me.MN_AJUSTE.Focus()
    End Sub
End Class