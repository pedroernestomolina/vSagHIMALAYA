Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plantilla_8
    Dim xfichaprd As FichaProducto.Prd_Producto
    Dim xtb_precios As DataTable
    Dim xtb_existencia As DataTable
    Dim xbs_precios As BindingSource
    Dim xbs_existencia As BindingSource

    Dim xtipoprecio As String
    Dim xcontemp_exp As Integer
    Dim xdecemp_exp As String
    Dim xnomemp_exp As String
    Dim xcostemp_exp As Single
    Dim itemprocesar_ficha As IItemProcesar
    Dim xcant_evento_solo_presupuesto As Integer
    Dim PRECIO_ACTUAL As Decimal


    Property _SoloPresupuetoEvento() As Integer
        Get
            Return xcant_evento_solo_presupuesto
        End Get
        Set(ByVal value As Integer)
            xcant_evento_solo_presupuesto = value
        End Set
    End Property

    ''' <summary>
    ''' PLANTILLA USADA PARA EL COMPORTAMIENTO TIPO DE ITEM A PROCESAR: VENTA/PRESUPUESTO/NOTA/ETC
    ''' </summary>
    Property FichaItemProcesar() As IItemProcesar
        Get
            Return itemprocesar_ficha
        End Get
        Set(ByVal value As IItemProcesar)
            itemprocesar_ficha = value
        End Set
    End Property

    ''' <summary>
    ''' Ficha Producto
    ''' </summary>
    Property _MiProducto() As FichaProducto.Prd_Producto
        Get
            Return xfichaprd
        End Get
        Set(ByVal value As FichaProducto.Prd_Producto)
            xfichaprd = value
        End Set
    End Property

    ''' <summary>
    ''' Tipo Precio Seleccionado
    ''' </summary>
    Property TipoPrecio() As String
        Get
            Return xtipoprecio
        End Get
        Set(ByVal value As String)
            xtipoprecio = value
        End Set
    End Property

    Sub New(ByVal xprd As FichaProducto.Prd_Producto, ByVal xtipoitem_procesar As IItemProcesar, Optional ByVal xtipoprecio_cliente As String = "1", Optional ByVal xcantevento As Integer = 0)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._MiProducto = xprd
        Me.TipoPrecio = xtipoprecio_cliente

        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2 = False Then
            Me.TipoPrecio = "1"
        End If

        xcontemp_exp = xprd.RegistroDato._ContEmpqCompra
        xnomemp_exp = xprd.RegistroDato._NombreEmpaqueCompra
        xdecemp_exp = xprd.RegistroDato._CantDecimalesEmpaqueCompra
        xcostemp_exp = 0

        Me.FichaItemProcesar = xtipoitem_procesar
        _SoloPresupuetoEvento = xcantevento
    End Sub

    Sub CargarPrecios()
        Dim xp1 As New SqlParameter("@auto_producto", Me._MiProducto.RegistroDato._AutoProducto)
        Dim xsql As String = "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, " _
                                   + "pe.auto_producto, pe.precio_1, pe.precio_2, pe.auto_medida, pe.contenido, pe.utilidad_1, pe.utilidad_2, pe.referencia, pe.ID_SEGURIDAD, pm.* " _
                                  + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
                                  + "where pe.auto_producto = @auto_producto  and (Pe.precio_1>0 or pe.precio_2>0) " & _
                              "UNION " & _
                              "SELECT pm.nombre xnom, p.contenido_empaque_venta xcont, p.precio_pto_venta  xpn1, 0.0 xpf1, 0, 0.0 xpf2, " & _
                              "p.AUTO auto_producto, p.precio_pto_venta precio_1, 0 precio_2, p.auto_medida_venta auto_medida, " & _
                              "p.contenido_empaque_venta contenido, p.utilidad_pto_venta utilidad_1, 0 utilidad_2, '5' referencia, " & _
                              "p.id_seguridad , pm.* from productos p join productos_medida pm on p.auto_medida_venta=pm.auto " & _
                              "where p.AUTO= @AUTO_PRODUCTO ORDER BY REFERENCIA"
        g_MiData.F_GetData(xsql, xtb_precios, xp1)
        Dim xtasa As Single = Me._MiProducto.RegistroDato._TasaImpuesto
        For Each dr As DataRow In xtb_precios.Rows
            Dim xf As Decimal = Decimal.Round(dr("xpn1") + (dr("xpn1") * xtasa / 100), 2, MidpointRounding.AwayFromZero)
            dr("xpf1") = String.Format("{0:#0.00}", xf)

            Dim xf2 As Decimal = Decimal.Round(dr("xpn2") + (dr("xpn2") * xtasa / 100), 2, MidpointRounding.AwayFromZero)
            dr("xpf2") = String.Format("{0:#0.00}", xf2)
        Next
    End Sub

    Sub CargarDepositos()
        Dim xp1 As New SqlParameter("@auto_producto", Me._MiProducto.RegistroDato._AutoProducto)
        Dim xsql As String = "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                                      + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                                      + "where pd.auto_producto = @auto_producto"

        g_MiData.F_GetData(xsql, xtb_existencia, xp1)
    End Sub

    Sub ActualizarEmpaque()
        ActualizaEmpaque()
    End Sub

    Sub ActualizaEmpaque()
        PRECIO_ACTUAL = 0
        If xbs_precios.Current IsNot Nothing Then
            xcontemp_exp = xbs_precios.Current("xcont")
            xdecemp_exp = xbs_precios.Current("decimales")
            xnomemp_exp = xbs_precios.Current("xnom")
            xcostemp_exp = (xfichaprd.RegistroDato._CostoCompra._Base / xfichaprd.RegistroDato._ContEmpqCompra) * xcontemp_exp

            Me.E_CONTENIDO.Text = xcontemp_exp.ToString
            Me.E_NOMEMP_EXP.Text = xnomemp_exp
            Me.E_CONEMP_EXP.Text = xcontemp_exp.ToString

            Dim xliq As Decimal = 0
            If Me.TipoPrecio = "1" Then
                Me.MN_PRECIO.Text = xbs_precios.Current("xpn1")
                xliq = xbs_precios.Current("xpf1") / xcontemp_exp
            Else
                Me.MN_PRECIO.Text = xbs_precios.Current("xpn2")
                xliq = xbs_precios.Current("xpf2") / xcontemp_exp
            End If
            Me.E_LIQUIDA.Text = String.Format("{0:#0.00}", xliq)
            PRECIO_ACTUAL = Me.MN_PRECIO._Valor

            Dim xformato As String = "99999.999"
            Dim xformato2 As String = "{0:#0.000"
            Dim xdec As Integer = 0
            Integer.TryParse(xbs_precios.Current("decimales"), xdec)
            If xdec > 0 Then
                xdec += 1
            End If
            Me.MN_CANTIDAD._Formato = xformato.Substring(0, 5 + xdec)
            Me.MN_CANTIDAD.Text = String.Format(xformato2.Substring(0, 5 + xdec) + "}", Me.MN_CANTIDAD._Valor)

            CalculaImporte()

            xbs_existencia.CurrencyManager.Refresh()
            ActualizaExistencia()
        End If
    End Sub

    Sub ActualizaExistencia()
        If xbs_existencia.Current IsNot Nothing Then
            If xbs_precios.Current IsNot Nothing Then
                Dim xformato As String = "#0.000"
                Dim xdec As Integer = 0
                Integer.TryParse(xbs_precios.Current("decimales").ToString, xdec)

                Dim x1 As Single = 0
                For Each dr As DataRowView In xbs_existencia
                    x1 += dr.Row("disponible") / xcontemp_exp
                Next

                Me.E_TOTAL.Text = Format(x1, IIf(xdec > 0, xformato.Substring(0, 3 + xdec), xformato.Substring(0, 2)))
            End If
        End If
    End Sub

    Sub Inicializa()
        Try
            Me.E_DESCRIPCION.Text = ""
            Me.E_IMPORTE.Text = "0.00"
            Me.E_IVA.Text = "0.00"
            Me.E_CONTENIDO.Text = "0"
            Me.E_LIQUIDA.Text = "0.00"
            Me.E_SUGERIDO.Text = "0.00"
            Me.E_TOTAL.Text = "0.00"
            Me.E_TOT_GENERAL.Text = "0.00"
            Me.E_IMPUESTO.Text = "0.00"

            Me.E_CONEMP_EXP.Text = ""
            Me.E_NOMEMP_EXP.Text = ""

            With Me.MN_CANTIDAD
                .Text = "1"
                ._ConSigno = False
                ._Formato = "99999.999"
            End With
            With Me.MN_DSCTO
                .Text = "0.0"
                ._ConSigno = False
                ._Formato = "99.99"
            End With
            With Me.MN_DESC_MONTO
                .Text = "0.0"
                ._ConSigno = False
                ._Formato = "999999999.99"
            End With
            With Me.MN_PRECIO
                .Text = "0.0"
                ._ConSigno = False
                ._Formato = "999999999.99"
            End With

            xtb_precios = New DataTable
            xtb_existencia = New DataTable
            CargarPrecios()
            CargarDepositos()
            xbs_precios = New BindingSource(xtb_precios, "")
            xbs_existencia = New BindingSource(xtb_existencia, "")

            If _SoloPresupuetoEvento > 0 Then
                If _MiProducto.RegistroDato._EstatusConsumo AndAlso _MiProducto.RegistroDato._CantConsumo > 0 Then
                    Dim xcnt As Decimal = 0
                    xcnt = Decimal.Round(_SoloPresupuetoEvento * _MiProducto.RegistroDato._CantConsumo, 2, MidpointRounding.AwayFromZero)
                    Me.MN_CANTIDAD.Text = String.Format("{0:#0.000}", xcnt)
                End If
            End If

            AddHandler xbs_precios.PositionChanged, AddressOf ActualizarEmpaque
            ActualizaEmpaque()

            Me.E_DESCRIPCION.Text = Me._MiProducto.RegistroDato._DescripcionDetallaDelProducto
            Me.E_IVA.Text = String.Format("{0:#0.00}", Me._MiProducto.RegistroDato._TasaImpuesto)
            Me.E_SUGERIDO.Text = String.Format("{0:#0.00}", Me._MiProducto.RegistroDato._PrecioSugerido)

            With MG_PV
                .Columns.Add("col0", "Empaque")
                .Columns.Add("col1", "Cont")
                .Columns.Add("col2", "P/Neto ")
                .Columns.Add("col3", "P/Neto ")
                .Columns.Add("col4", "P/Full ")
                .Columns.Add("col5", "P/Full ")
                AddHandler .CellFormatting, AddressOf FormatoPrecio

                .Columns(1).Width = 80
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 100
                .Columns(5).Width = 100
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs_precios
                .Columns(0).DataPropertyName = "xnom"
                .Columns(1).DataPropertyName = "xcont"
                .Columns(2).DataPropertyName = "xpn1"
                .Columns(3).DataPropertyName = "xpn2"
                .Columns(4).DataPropertyName = "xpf1"
                .Columns(5).DataPropertyName = "xpf2"
                .Ocultar(7)

                .Columns(3).Visible = False
                .Columns(5).Visible = False
            End With

            With MG_PE
                .Columns.Add("col0", "Deposito")
                .Columns.Add("col1", "Ex. Real")
                .Columns.Add("col2", "Ex. Resv")
                .Columns.Add("col3", "Ex. Disp")
                AddHandler .CellFormatting, AddressOf FormatoExistencia

                .Columns(1).Width = 85
                .Columns(2).Width = 85
                .Columns(3).Width = 85
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs_existencia
                .Columns(0).DataPropertyName = "nombre"
                .Columns(1).DataPropertyName = "real"
                .Columns(2).DataPropertyName = "reservada"
                .Columns(3).DataPropertyName = "disponible"
                .Ocultar(5)
            End With

            With Me.MCB_EMPAQUE
                .DataSource = xbs_precios
                .DisplayMember = "xnom"
                .ValueMember = "referencia"

                .Select()
                .Focus()
            End With

            If TipoPrecio = "2" Then
                Me.MCHB_PRECIO.Checked = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, True, False)
            End If

            Me.MCHB_PRECIO.Enabled = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2

            If xfichaprd.RegistroDato._TasaImpuesto > 0 Then
                Me.MCHB_2.Enabled = True
            Else
                Me.MCHB_2.Enabled = False
            End If

            If _MiProducto.RegistroDato._EstatusFoto = TipoEstatus.Activo Then
                Try
                    Dim xruta As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos + "\" + _MiProducto.RegistroDato._AutoProducto
                    Me.ControlImagen1._CargarImagen(xruta)
                    Me.ControlImagen1.Enabled = True
                    Me.ControlImagen1._OpcionesMenu = False
                Catch ex As Exception
                    Me.ControlImagen1._CargarImagen("")
                    Me.ControlImagen1.Enabled = False
                End Try
            Else
                Me.ControlImagen1._CargarImagen("")
                Me.ControlImagen1.Enabled = False
            End If

        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub FormatoPrecio(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 1 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Sub FormatoExistencia(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Dim xformato As String = "#0.000"
        If e.ColumnIndex >= 1 Then
            Dim xv As Integer = 0
            Dim xd As String = xdecemp_exp

            Integer.TryParse(xd, xv)
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
            e.Value = e.Value / xcontemp_exp
            e.Value = Format(e.Value, IIf(xv > 0, xformato.Substring(0, 3 + xv), xformato.Substring(0, 2)))
        End If
    End Sub

    Private Sub Plantilla_8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            Me.MCB_EMPAQUE.Select()
            Me.MCB_EMPAQUE.Focus()
        End If
    End Sub

    Private Sub Plantilla_8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub Plantilla_8_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub MN_CANTIDAD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_CANTIDAD.LostFocus
        ActualizaEmpaque()
        CalculaImporte()
    End Sub

    'Private Sub Descuentos(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DSCTO.Enter, MN_DESC_MONTO.Enter
    '    'Try
    '    '    Dim xmn As MisControles.Controles.MisNumeros = CType(sender, MisControles.Controles.MisNumeros)
    '    '    If g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_DarDescuento_Item.r_PermitirOpcion Then
    '    '        g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_DarDescuento_Item.F_Permitir()
    '    '        xmn.ReadOnly = False
    '    '    Else
    '    '        xmn.ReadOnly = True
    '    '    End If
    '    'Catch ex As Exception
    '    '    Me.FindForm.SelectNextControl(sender, True, True, True, True)
    '    '    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    'End Try
    'End Sub

    Sub CalculaImporte(Optional ByVal xtipodescuento As Integer = 0)
        Dim ximp As Decimal = 0
        Dim xful As Decimal = 0
        Dim xliq As Decimal = 0
        Dim xiva As Decimal = 0
        Dim xdes As Decimal = 0

        If Me.MN_CANTIDAD._Valor > 0 Then
            Dim x1 As Decimal = 0
            Dim x2 As Decimal = 0
            x1 = Me.MN_CANTIDAD._Valor * Me.MN_PRECIO._Valor

            If xtipodescuento = 1 Then
                x2 = x1 * Me.MN_DSCTO._Valor / 100
            End If

            'If xtipodescuento = 2 Then
            '    x2 = Me.MN_DESC_MONTO._Valor
            '    Dim x As Decimal = 0
            '    If x1 > 0 Then
            '        x = Decimal.Round(x2 * 100 / x1, 2, MidpointRounding.AwayFromZero)
            '    End If
            '    Me.MN_DSCTO.Text = String.Format("{0:#0.00}", x)

            '    x2 = x1 * Me.MN_DSCTO._Valor / 100
            'End If

            'xdes = Decimal.Round(x2, 2, MidpointRounding.AwayFromZero)
            'ximp = Decimal.Round(x1 - x2, 2, MidpointRounding.AwayFromZero)
            'xiva = Decimal.Round(ximp * xfichaprd.RegistroDato._TasaImpuesto / 100, 2, MidpointRounding.AwayFromZero)
            xdes = Decimal.Round(x2, 2, MidpointRounding.AwayFromZero)
            ximp = (x1 - xdes)
            Dim t As Decimal = xfichaprd.RegistroDato._TasaImpuesto
            xiva = ximp * t / 100
            xiva = Decimal.Round(xiva, 2, MidpointRounding.AwayFromZero)
            xful = ximp + xiva
            xful = Decimal.Round(xful, 2, MidpointRounding.AwayFromZero)
            xliq = xful / Me.MN_CANTIDAD._Valor / xcontemp_exp

            Me.E_IMPORTE.Text = String.Format("{0:#0.00}", ximp)
            Me.E_LIQUIDA.Text = String.Format("{0:#0.00}", xliq)
            Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", xiva)
            Me.E_TOT_GENERAL.Text = String.Format("{0:#0.00}", xful)
            Me.MN_DESC_MONTO.Text = String.Format("{0:#0.00}", xdes)
        End If
    End Sub

    Private Sub MN_DSCTO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DSCTO.LostFocus
        'CalculaImporte(1)

        Try
            If MN_DSCTO._Valor > 0 Then
                If g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_DarDescuento_Item.r_PermitirOpcion Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_DarDescuento_Item.F_Permitir()
                Else
                    Throw New Exception("NO TIENES PERMISO DE PODER ASIGNAR DESCUENTO AL ARTICULO")
                End If
            End If
        Catch ex As Exception
            Me.MN_DSCTO.Text = "0.0"
            Me.MN_DESC_MONTO.Text = "0.0"
            Me.FindForm.SelectNextControl(sender, True, True, True, True)
            Funciones.MensajeDeError(ex.Message)
        Finally
            CalculaImporte(1)
        End Try

    End Sub

    Private Sub MN_DESC_MONTO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DESC_MONTO.LostFocus
        Try
            If MN_DESC_MONTO._Valor > 0 Then
                If g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_DarDescuento_Item.r_PermitirOpcion Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_DarDescuento_Item.F_Permitir()
                Else
                    Throw New Exception("NO TIENES PERMISO DE PODER ASIGNAR DESCUENTO AL ARTICULO")
                End If
            End If
        Catch ex As Exception
            Me.MN_DSCTO.Text = "0.0"
            Me.MN_DESC_MONTO.Text = "0.0"
            Me.FindForm.SelectNextControl(sender, True, True, True, True)
            Funciones.MensajeDeError(ex.Message)
        Finally
            CalculaImporte(2)
        End Try
    End Sub

    Private Sub MN_PRECIO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_PRECIO.LostFocus
        Dim xprecio As Decimal = 0
        Try
            If Me.MCHB_2.Checked Then
                Dim xpv As New Precio(Me.MN_PRECIO._Valor, xfichaprd.RegistroDato._TasaImpuesto, Precio.TipoFuncion.Desglozar)
                xprecio = xpv._Base
            Else
                xprecio = Me.MN_PRECIO._Valor
            End If

            If xprecio <> PRECIO_ACTUAL Then
                If g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_PrecioLibre.r_PermitirOpcion Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_PrecioLibre.F_Permitir()
                    PRECIO_ACTUAL = xprecio
                    Me.MN_PRECIO.Text = String.Format("{0:#0.00}", PRECIO_ACTUAL)
                Else
                    Throw New Exception("NO TIENES PERMISO DE PODER ACTUALIZAR EL PRECIO DE VENTA")
                End If
            End If
        Catch ex As Exception
            Me.MCHB_2.Checked = False
            Me.MN_PRECIO.Text = String.Format("{0:#0.00}", PRECIO_ACTUAL)
            Me.FindForm.SelectNextControl(sender, True, True, True, True)
            Funciones.MensajeDeError(ex.Message)
        Finally
            CalculaImporte()
        End Try
    End Sub

    Private Sub MisCheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_PRECIO.CheckedChanged
        If Me.MCHB_PRECIO.Checked Then
            Me.TipoPrecio = "2"
        Else
            Me.TipoPrecio = "1"
        End If

        If Me.TipoPrecio = "2" Then
            Me.MG_PV.Columns(3).Visible = True
            Me.MG_PV.Columns(5).Visible = True

            Me.MG_PV.Columns(2).Visible = False
            Me.MG_PV.Columns(4).Visible = False
        Else
            Me.MG_PV.Columns(3).Visible = False
            Me.MG_PV.Columns(5).Visible = False

            Me.MG_PV.Columns(2).Visible = True
            Me.MG_PV.Columns(4).Visible = True
        End If

        ActPrecio()
        Me.MCB_EMPAQUE.Select()
    End Sub

    Sub ActPrecio()
        If xbs_precios.Current IsNot Nothing Then
            ActualizaEmpaque()
        End If
    End Sub

    Private Sub MG_PV_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_PV.Accion
        Dim xreg As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
        VerCostoUtilidad(xfichaprd.RegistroDato._AutoProducto, xreg("referencia"), TipoPrecio)
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If Me.MN_CANTIDAD._Valor > 0 Then
            If xbs_precios.Current IsNot Nothing Then
                Dim xmedida As New FichaProducto.Prd_Medida(CType(xbs_precios.Current, DataRowView).Row)
                Dim xempaque As New FichaProducto.Prd_Empaque(CType(xbs_precios.Current, DataRowView).Row)
                Dim xerror As Boolean = False

                If xmedida.RegistroDato._ForzarDecimales Then
                    If (Me.MN_CANTIDAD._Valor - Int(Me.MN_CANTIDAD._Valor)) = 0 Or (Me.MN_CANTIDAD._Valor - Int(Me.MN_CANTIDAD._Valor)) = 0.5 Then
                    Else
                        xerror = True
                    End If
                End If

                If xerror = False Then
                    Dim xitem As New IItemProcesar.Item.c_Entrada
                    With xitem
                        ._AutoMedida = xmedida.RegistroDato._Automatico
                        ._Cantidad = Me.MN_CANTIDAD._Valor
                        ._ContenidoEmpaque = xempaque.RegistroDato._ContenidoEmpaque
                        ._CostoVenta = xcostemp_exp
                        ._DecimalesUsar = xmedida.RegistroDato._DigitosDecimalesAUsar
                        ._Descto = Me.MN_DSCTO._Valor
                        ._ForzarCantidad = xmedida.RegistroDato._ForzarDecimales
                        ._NombreMedida = xmedida.RegistroDato._NombreMedida
                        ._PrecioNeto = Me.MN_PRECIO._Valor
                        ._ReferenciaEmpaque = xempaque.RegistroDato._ReferenciaEmpaqueSeleccionado
                    End With
                    If Me.FichaItemProcesar.ProcesarItem(xfichaprd, xitem) Then
                        Me.Close()
                    Else
                        Me.MCB_EMPAQUE.Select()
                    End If
                Else
                    MessageBox.Show("Error En Cantidad A Facturar, No Se Aceptan Cantidades Inexactas, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MCB_EMPAQUE.Select()
                End If
            Else
                MessageBox.Show("No Hay Empaque Definido Para Despachar, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MCB_EMPAQUE.Select()
            End If
        Else
            MessageBox.Show("Cantidad A Procesar No Puede Ser Cero (0), Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_EMPAQUE.Select()
        End If
    End Sub

    Private Sub MCB_EMPAQUE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MCB_EMPAQUE.KeyDown
        If xbs_precios.Current IsNot Nothing Then
            If e.KeyCode = Keys.F1 Then
                Dim xreg As DataRow = CType(xbs_precios.Current, DataRowView).Row
                VerCostoUtilidad(xfichaprd.RegistroDato._AutoProducto, xreg("referencia"), TipoPrecio)
            End If
        End If
    End Sub

    Private Sub MCHB_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_2.CheckedChanged
        Me.MN_PRECIO.Select()
        Me.MN_PRECIO.Focus()
    End Sub

    Private Sub MG_PE_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_PE.Accion
        If xbs_existencia.Current IsNot Nothing Then
            Dim xPrdDep As New FichaProducto.Prd_Deposito
            xPrdDep.F_BuscarDepositoProducto(xbs_existencia.Current("auto_producto").ToString, xbs_existencia.Current("auto_deposito").ToString)

            Dim xficha As New FichaDeposito(xPrdDep, New FichaDeposito_SoloMostrar)
            With xficha
                .ShowDialog()
            End With
        End If
    End Sub

   
    Private Sub MN_DSCTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MN_DSCTO.TextChanged

    End Sub
End Class

Public Interface IItemProcesar
    Class Item
        Class c_Entrada
            Private xreg As c_Registro

            ''' <summary>
            ''' Contenido Empaque A Despachar
            ''' </summary>
            WriteOnly Property _ContenidoEmpaque() As Integer
                Set(ByVal value As Integer)
                    xreg._ContenidoEmpaque = value
                End Set
            End Property

            ''' <summary>
            ''' Referencia Empaque A Despachar, es decir tipo de empaque (1,2,3,4)
            ''' </summary>
            WriteOnly Property _ReferenciaEmpaque() As String
                Set(ByVal value As String)
                    xreg._ReferenciaEmpaque = value
                End Set
            End Property

            ''' <summary>
            ''' Automatico Producto_Medida, usada para identificar la unidad de medida usada para despachar
            ''' </summary>
            WriteOnly Property _AutoMedida() As String
                Set(ByVal value As String)
                    xreg._AutoMedida = value
                End Set
            End Property

            ''' <summary>
            ''' Nombre Medida, Identifica El Nombre Del Empaque
            ''' </summary>
            WriteOnly Property _NombreMedida() As String
                Set(ByVal value As String)
                    xreg._NombreMedida = value
                End Set
            End Property

            ''' <summary>
            ''' Decimales A Usar, Indica el formato de entrada de la cantidad
            ''' </summary>
            WriteOnly Property _DecimalesUsar() As Integer
                Set(ByVal value As Integer)
                    xreg._DecimalesUsar = value
                End Set
            End Property

            ''' <summary>
            ''' Indica Si Se Aplica/No a cantidades exactas
            ''' </summary>
            WriteOnly Property _ForzarCantidad() As Boolean
                Set(ByVal value As Boolean)
                    xreg._ForzarCantidad = value
                End Set
            End Property

            ''' <summary>
            ''' Costo De Venta
            ''' </summary>
            WriteOnly Property _CostoVenta() As Decimal
                Set(ByVal value As Decimal)
                    xreg._CostoVenta = value
                End Set
            End Property

            ''' <summary>
            ''' Cantidad A Procesar
            ''' </summary>
            WriteOnly Property _Cantidad() As Single
                Set(ByVal value As Single)
                    xreg._Cantidad = value
                End Set
            End Property

            ''' <summary>
            ''' Precio Neto, Antes Del Descuento
            ''' </summary>
            WriteOnly Property _PrecioNeto() As Decimal
                Set(ByVal value As Decimal)
                    xreg._Precio = value
                End Set
            End Property

            ''' <summary>
            ''' Descuento A Dar
            ''' </summary>
            WriteOnly Property _Descto() As Decimal
                Set(ByVal value As Decimal)
                    xreg._Descto = value
                End Set
            End Property

            Protected Friend Property _RegEntrada() As c_Registro
                Get
                    Return xreg
                End Get
                Set(ByVal value As c_Registro)
                    xreg = value
                End Set
            End Property

            Sub New()
                Me._RegEntrada = New c_Registro
            End Sub
        End Class

        Class c_Actualizar
            Private xreg As c_Registro

            ''' <summary>
            ''' Cantidad A Procesar
            ''' </summary>
            WriteOnly Property _Cantidad() As Single
                Set(ByVal value As Single)
                    xreg._Cantidad = value
                End Set
            End Property

            ''' <summary>
            ''' Precio Neto, Antes Del Descuento
            ''' </summary>
            WriteOnly Property _PrecioNeto() As Decimal
                Set(ByVal value As Decimal)
                    xreg._Precio = value
                End Set
            End Property

            ''' <summary>
            ''' Descuento A Dar
            ''' </summary>
            WriteOnly Property _Descto() As Decimal
                Set(ByVal value As Decimal)
                    xreg._Descto = value
                End Set
            End Property

            ''' <summary>
            ''' Costo De Venta
            ''' </summary>
            WriteOnly Property _CostoVenta() As Decimal
                Set(ByVal value As Decimal)
                    xreg._CostoVenta = value
                End Set
            End Property

            Protected Friend Property _RegEntrada() As c_Registro
                Get
                    Return xreg
                End Get
                Set(ByVal value As c_Registro)
                    xreg = value
                End Set
            End Property

            Sub New()
                Me._RegEntrada = New c_Registro
            End Sub
        End Class

        Class c_Registro
            Private xcantidad As Single
            Private xprecio As Decimal
            Private xdscto As Decimal
            Private xtipoprecio As String
            Private xcosto As Decimal
            Private xcontenido_empaque As Integer
            Private xreferencia_empaque As String
            Private xauto_medida As String
            Private xnombre_medida As String
            Private xdecimales_medida As Integer
            Private xforzardecimales_medida As String
            Private xpliquida As Decimal

            ''' <summary>
            ''' Contenido Empaque A Despachar
            ''' </summary>
            Protected Friend Property _ContenidoEmpaque() As Integer
                Get
                    Return xcontenido_empaque
                End Get
                Set(ByVal value As Integer)
                    xcontenido_empaque = value
                End Set
            End Property

            ''' <summary>
            ''' Referencia Empaque A Despachar, es decir tipo de empaque (1,2,3,4)
            ''' </summary>
            Protected Friend Property _ReferenciaEmpaque() As String
                Get
                    Return xreferencia_empaque
                End Get
                Set(ByVal value As String)
                    xreferencia_empaque = value
                End Set
            End Property

            ''' <summary>
            ''' Automatico Producto_Medida, usada para identificar la unidad de medida usada para despachar
            ''' </summary>
            Protected Friend Property _AutoMedida() As String
                Get
                    Return xauto_medida
                End Get
                Set(ByVal value As String)
                    xauto_medida = value
                End Set
            End Property

            ''' <summary>
            ''' Nombre Medida, Identifica El Nombre Del Empaque
            ''' </summary>
            Protected Friend Property _NombreMedida() As String
                Get
                    Return xnombre_medida
                End Get
                Set(ByVal value As String)
                    xnombre_medida = value
                End Set
            End Property

            ''' <summary>
            ''' Decimales A Usar, Indica el formato de entrada de la cantidad
            ''' </summary>
            Protected Friend Property _DecimalesUsar() As Integer
                Get
                    Return xdecimales_medida
                End Get
                Set(ByVal value As Integer)
                    xdecimales_medida = value
                End Set
            End Property

            ''' <summary>
            ''' Indica Si Se Aplica/No a cantidades exactas
            ''' </summary>
            Protected Friend Property _ForzarCantidad() As Boolean
                Get
                    Return xforzardecimales_medida
                End Get
                Set(ByVal value As Boolean)
                    xforzardecimales_medida = value
                End Set
            End Property

            ''' <summary>
            ''' Costo De Venta
            ''' </summary>
            Protected Friend Property _CostoVenta() As Decimal
                Get
                    Return xcosto
                End Get
                Set(ByVal value As Decimal)
                    xcosto = value
                End Set
            End Property

            ReadOnly Property _CostoInventario() As Decimal
                Get
                    Return Decimal.Round(_CostoVenta / _ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                End Get
            End Property

            ''' <summary>
            ''' Cantidad A Procesar
            ''' </summary>
            Protected Friend Property _Cantidad() As Single
                Get
                    Return xcantidad
                End Get
                Set(ByVal value As Single)
                    xcantidad = value
                End Set
            End Property

            ''' <summary>
            ''' Precio Neto, Antes Del Descuento
            ''' </summary>
            Protected Friend Property _Precio() As Decimal
                Get
                    Return xprecio
                End Get
                Set(ByVal value As Decimal)
                    xprecio = value
                End Set
            End Property

            ''' <summary>
            ''' Descuento A Dar
            ''' </summary>
            Protected Friend Property _Descto() As Decimal
                Get
                    Return xdscto
                End Get
                Set(ByVal value As Decimal)
                    xdscto = value
                End Set
            End Property

            ''' <summary>
            ''' Precio Neto Ya Con Descuento
            ''' </summary>
            Protected Friend ReadOnly Property _PrecioFinal() As Decimal
                Get
                    Dim xp As Decimal = 0
                    xp = Me._Precio
                    xp = xp - (xp * Me._Descto / 100)
                    Return Decimal.Round(xp, 2, MidpointRounding.AwayFromZero)
                End Get
            End Property

            ReadOnly Property _Pliquida() As Decimal
                Get
                    Dim xliq As Decimal = 0
                    xliq = Decimal.Round(_PrecioFinal / _ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                    Return xliq
                End Get
            End Property

            Sub New()
                _AutoMedida = ""
                _Cantidad = 0
                _ContenidoEmpaque = 0
                _CostoVenta = 0
                _DecimalesUsar = 0
                _Descto = 0
                _ForzarCantidad = False
                _NombreMedida = ""
                _Precio = 0
                _ReferenciaEmpaque = ""
            End Sub
        End Class
    End Class

    Function ProcesarItem(ByVal xprd As FichaProducto.Prd_Producto, ByVal xitem As Item.c_Entrada) As Boolean
    Event ActualizarTabla()
End Interface

Public Class Item_VentaProcesar
    Implements IItemProcesar

    Dim xproducto As FichaProducto.Prd_Producto
    Dim xdatositem As IItemProcesar.Item.c_Entrada

    Function Factura() As Boolean
        Dim xregistro As New FichaVentas.V_TemporalVenta.c_AgregarRegistro
        With xregistro
            ._AutoDeposito = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoInventarioVentas
            ._AutoMedida = xdatositem._RegEntrada._AutoMedida
            ._AutoProducto = xproducto.RegistroDato._AutoProducto
            ._Cantidad = xdatositem._RegEntrada._Cantidad
            ._CodigoProducto = xproducto.RegistroDato._CodigoProducto
            ._ContenidoEmpaque = xdatositem._RegEntrada._ContenidoEmpaque
            ._Descuento = xdatositem._RegEntrada._Descto
            ._EsPesado = xproducto.RegistroDato._EsPesado
            ._ForzarMedida = xdatositem._RegEntrada._ForzarCantidad
            ._NombreEmpaque = xdatositem._RegEntrada._NombreMedida
            ._NombreProducto = xproducto.RegistroDato._DescripcionDetallaDelProducto
            ._NumeroDecimalesMedida = xdatositem._RegEntrada._DecimalesUsar
            ._PrecioNeto = xdatositem._RegEntrada._Precio
            ._ReferenciaEmpaque = xdatositem._RegEntrada._ReferenciaEmpaque
            ._TasaIva = xproducto.RegistroDato._TasaImpuesto

            ._AutoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario
            ._CostoInventario = xdatositem._RegEntrada._CostoInventario
            ._CostoVenta = xdatositem._RegEntrada._CostoVenta
            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            ._FechaProceso = Date.Now
            ._ItemNotas = ""
            ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
            ._PSugerido = xproducto.RegistroDato._PrecioSugerido
            ._TipoDocumento = "1"
            ._TipoTasa = xproducto.RegistroDato._TipoImpuesto

            ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo

            ._RestringidoVenta = xproducto.RegistroDato._EstaRestringidoVenta
        End With

        Dim xcond As New FichaVentas.V_TemporalVenta.Condiciones
        With xcond
            ._AgruparItems = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._AgruparItems_Al_Impimir
            ._BloquearExistencia = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Ruptura_Por_Existencia
        End With

        If g_MiData.f_FichaVentas.F_TemporalVenta.F_AgregarRegisto(xregistro, xcond) Then
            If g_VisorPrecio IsNot Nothing Then
                g_VisorPrecio.Venta(xproducto.RegistroDato._DescripcionDetallaDelProducto, xdatositem._RegEntrada._Precio, xdatositem._RegEntrada._Cantidad)
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ProcesarItem(ByVal xprd As FichaProducto.Prd_Producto, ByVal xitem As IItemProcesar.Item.c_Entrada) As Boolean Implements IItemProcesar.ProcesarItem
        Try
            xproducto = xprd
            xdatositem = xitem

            If xitem._RegEntrada._Precio = 0 Then
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Precio_En_Cero Then
                    If Factura() Then
                        RaiseEvent ActualizarTabla()
                        Return True
                    End If
                Else
                    Throw New Exception("Error... No Puedo Facturar Sin Un Precio Dado, Verifique Por Favor...")
                End If
            Else
                If xitem._RegEntrada._PrecioFinal < xitem._RegEntrada._CostoVenta Then
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Por_Debajo_Costo Then
                        If Factura() Then
                            RaiseEvent ActualizarTabla()
                            Return True
                        End If
                    Else
                        Throw New Exception("Error... No Puedo Facturar Con Un Precio Por Debajo Del Costo, Verifique Por Favor...")
                    End If
                Else
                    If Factura() Then
                        RaiseEvent ActualizarTabla()
                        Return True
                    End If
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Return False
        End Try
    End Function

    Public Event ActualizarTabla() Implements IItemProcesar.ActualizarTabla
End Class

Public Class Item_PresupuestoProcesar
    Implements IItemProcesar

    Dim xproducto As FichaProducto.Prd_Producto
    Dim xdatositem As IItemProcesar.Item.c_Entrada

    Function Factura() As Boolean
        Dim xregistro As New FichaVentas.V_TemporalVenta.c_AgregarRegistro
        With xregistro
            ._AutoDeposito = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoInventarioVentas
            ._AutoMedida = xdatositem._RegEntrada._AutoMedida
            ._AutoProducto = xproducto.RegistroDato._AutoProducto
            ._Cantidad = xdatositem._RegEntrada._Cantidad
            ._CodigoProducto = xproducto.RegistroDato._CodigoProducto
            ._ContenidoEmpaque = xdatositem._RegEntrada._ContenidoEmpaque
            ._Descuento = xdatositem._RegEntrada._Descto
            ._EsPesado = xproducto.RegistroDato._EsPesado
            ._ForzarMedida = xdatositem._RegEntrada._ForzarCantidad
            ._NombreEmpaque = xdatositem._RegEntrada._NombreMedida
            ._NombreProducto = xproducto.RegistroDato._DescripcionDetallaDelProducto
            ._NumeroDecimalesMedida = xdatositem._RegEntrada._DecimalesUsar
            ._PrecioNeto = xdatositem._RegEntrada._Precio
            ._ReferenciaEmpaque = xdatositem._RegEntrada._ReferenciaEmpaque
            ._TasaIva = xproducto.RegistroDato._TasaImpuesto

            ._AutoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario
            ._CostoInventario = xdatositem._RegEntrada._CostoInventario
            ._CostoVenta = xdatositem._RegEntrada._CostoVenta
            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            ._FechaProceso = Date.Now
            ._ItemNotas = ""
            ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
            ._PSugerido = xproducto.RegistroDato._PrecioSugerido
            ._TipoDocumento = "3"
            ._TipoTasa = xproducto.RegistroDato._TipoImpuesto

            ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
        End With

        Dim xcond As New FichaVentas.V_TemporalVenta.Condiciones
        With xcond
            ._AgruparItems = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._AgruparItems_Al_Impimir
            ._BloquearExistencia = False
        End With

        Return g_MiData.f_FichaVentas.F_TemporalVenta.F_AgregarRegisto(xregistro, xcond)
    End Function

    Public Event ActualizarTabla() Implements IItemProcesar.ActualizarTabla

    Public Function ProcesarItem(ByVal xprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto, ByVal xitem As IItemProcesar.Item.c_Entrada) As Boolean Implements IItemProcesar.ProcesarItem
        Try
            xproducto = xprd
            xdatositem = xitem

            If xitem._RegEntrada._Precio = 0 Then
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Precio_En_Cero Then
                    If Factura() Then
                        RaiseEvent ActualizarTabla()
                        Return True
                    End If
                Else
                    Throw New Exception("Error... No Puedo Facturar Sin Un Precio Dado, Verifique Por Favor...")
                End If
            Else
                If xitem._RegEntrada._PrecioFinal < xitem._RegEntrada._CostoVenta Then
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Por_Debajo_Costo Then
                        If Factura() Then
                            RaiseEvent ActualizarTabla()
                            Return True
                        End If
                    Else
                        Throw New Exception("Error... No Puedo Facturar Con Un Precio Por Debajo Del Costo, Verifique Por Favor...")
                    End If
                Else
                    If Factura() Then
                        RaiseEvent ActualizarTabla()
                        Return True
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje de Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class

Public Class Item_NotaEntregaProcesar
    Implements IItemProcesar

    Dim xproducto As FichaProducto.Prd_Producto
    Dim xdatositem As IItemProcesar.Item.c_Entrada

    Function Factura() As Boolean
        Dim xregistro As New FichaVentas.V_TemporalVenta.c_AgregarRegistro
        With xregistro
            ._AutoDeposito = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoInventarioVentas
            ._AutoMedida = xdatositem._RegEntrada._AutoMedida
            ._AutoProducto = xproducto.RegistroDato._AutoProducto
            ._Cantidad = xdatositem._RegEntrada._Cantidad
            ._CodigoProducto = xproducto.RegistroDato._CodigoProducto
            ._ContenidoEmpaque = xdatositem._RegEntrada._ContenidoEmpaque
            ._Descuento = xdatositem._RegEntrada._Descto
            ._EsPesado = xproducto.RegistroDato._EsPesado
            ._ForzarMedida = xdatositem._RegEntrada._ForzarCantidad
            ._NombreEmpaque = xdatositem._RegEntrada._NombreMedida
            ._NombreProducto = xproducto.RegistroDato._DescripcionDetallaDelProducto
            ._NumeroDecimalesMedida = xdatositem._RegEntrada._DecimalesUsar
            ._PrecioNeto = xdatositem._RegEntrada._Precio
            ._ReferenciaEmpaque = xdatositem._RegEntrada._ReferenciaEmpaque
            ._TasaIva = xproducto.RegistroDato._TasaImpuesto

            ._AutoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario
            ._CostoInventario = xdatositem._RegEntrada._CostoInventario
            ._CostoVenta = xdatositem._RegEntrada._CostoVenta
            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            ._FechaProceso = Date.Now
            ._ItemNotas = ""
            ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
            ._PSugerido = xproducto.RegistroDato._PrecioSugerido
            ._TipoDocumento = "2"
            ._TipoTasa = xproducto.RegistroDato._TipoImpuesto

            ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
        End With

        Dim xcond As New FichaVentas.V_TemporalVenta.Condiciones
        With xcond
            ._AgruparItems = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._AgruparItems_Al_Impimir
            ._BloquearExistencia = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Ruptura_Por_Existencia
        End With

        Return g_MiData.f_FichaVentas.F_TemporalVenta.F_AgregarRegisto(xregistro, xcond)
    End Function

    Public Function ProcesarItem(ByVal xprd As FichaProducto.Prd_Producto, ByVal xitem As IItemProcesar.Item.c_Entrada) As Boolean Implements IItemProcesar.ProcesarItem
        Try
            xproducto = xprd
            xdatositem = xitem

            If xitem._RegEntrada._Precio = 0 Then
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Precio_En_Cero Then
                    If Factura() Then
                        RaiseEvent ActualizarTabla()
                        Return True
                    End If
                Else
                    Throw New Exception("Error... No Puedo Facturar Sin Un Precio Dado, Verifique Por Favor...")
                End If
            Else
                If xitem._RegEntrada._PrecioFinal < xitem._RegEntrada._CostoVenta Then
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Por_Debajo_Costo Then
                        If Factura() Then
                            RaiseEvent ActualizarTabla()
                            Return True
                        End If
                    Else
                        Throw New Exception("Error... No Puedo Facturar Con Un Precio Por Debajo Del Costo, Verifique Por Favor...")
                    End If
                Else
                    If Factura() Then
                        RaiseEvent ActualizarTabla()
                        Return True
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje de Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Event ActualizarTabla() Implements IItemProcesar.ActualizarTabla
End Class

Public Class Item_PedidoProcesar
    Implements IItemProcesar

    Dim xproducto As FichaProducto.Prd_Producto
    Dim xdatositem As IItemProcesar.Item.c_Entrada

    Function Factura() As Boolean
        Dim xregistro As New FichaVentas.V_TemporalVenta.c_AgregarRegistro
        With xregistro
            ._AutoDeposito = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoInventarioVentas
            ._AutoMedida = xdatositem._RegEntrada._AutoMedida
            ._AutoProducto = xproducto.RegistroDato._AutoProducto
            ._Cantidad = xdatositem._RegEntrada._Cantidad
            ._CodigoProducto = xproducto.RegistroDato._CodigoProducto
            ._ContenidoEmpaque = xdatositem._RegEntrada._ContenidoEmpaque
            ._Descuento = xdatositem._RegEntrada._Descto
            ._EsPesado = xproducto.RegistroDato._EsPesado
            ._ForzarMedida = xdatositem._RegEntrada._ForzarCantidad
            ._NombreEmpaque = xdatositem._RegEntrada._NombreMedida
            ._NombreProducto = xproducto.RegistroDato._DescripcionDetallaDelProducto
            ._NumeroDecimalesMedida = xdatositem._RegEntrada._DecimalesUsar
            ._PrecioNeto = xdatositem._RegEntrada._Precio
            ._ReferenciaEmpaque = xdatositem._RegEntrada._ReferenciaEmpaque
            ._TasaIva = xproducto.RegistroDato._TasaImpuesto

            ._AutoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario
            ._CostoInventario = xdatositem._RegEntrada._CostoInventario
            ._CostoVenta = xdatositem._RegEntrada._CostoVenta
            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            ._FechaProceso = Date.Now
            ._ItemNotas = ""
            ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
            ._PSugerido = xproducto.RegistroDato._PrecioSugerido
            ._TipoDocumento = "4"
            ._TipoTasa = xproducto.RegistroDato._TipoImpuesto

            ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
        End With

        'Dim xcond As New FichaVentas.V_TemporalVenta.Condiciones
        'With xcond
        '    ._AgruparItems = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._AgruparItems_Al_Impimir
        '    ._BloquearExistencia = True 'SIEMPRE DEBE SER TRUE, PARA APARTAR LA MERCANCIA AUNQUE NO EXISTA
        '    'g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Ruptura_Por_Existencia
        'End With

        'Return g_MiData.f_FichaVentas.F_TemporalVenta.F_AgregarRegisto(xregistro, xcond)


        Dim xcond As New FichaVentas.V_TemporalVenta.Condiciones
        With xcond
            ._AgruparItems = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._AgruparItems_Al_Impimir
            ._BloquearExistencia = True
        End With

        If g_MiData.f_FichaVentas.F_TemporalVenta.F_AgregarRegisto(xregistro, xcond) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ProcesarItem(ByVal xprd As FichaProducto.Prd_Producto, ByVal xitem As IItemProcesar.Item.c_Entrada) As Boolean Implements IItemProcesar.ProcesarItem
        Try
            xproducto = xprd
            xdatositem = xitem

            If xitem._RegEntrada._Precio = 0 Then
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Precio_En_Cero Then
                    If Factura() Then
                        RaiseEvent ActualizarTabla()
                        Return True
                    End If
                Else
                    Throw New Exception("Error... No Puedo Facturar Sin Un Precio Dado, Verifique Por Favor...")
                End If
            Else
                If xitem._RegEntrada._PrecioFinal < xitem._RegEntrada._CostoVenta Then
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Facturar_Por_Debajo_Costo Then
                        If Factura() Then
                            RaiseEvent ActualizarTabla()
                            Return True
                        End If
                    Else
                        Throw New Exception("Error... No Puedo Facturar Con Un Precio Por Debajo Del Costo, Verifique Por Favor...")
                    End If
                Else
                    If Factura() Then
                        RaiseEvent ActualizarTabla()
                        Return True
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje de Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Event ActualizarTabla() Implements IItemProcesar.ActualizarTabla
End Class