Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient
Imports MisControles.Controles

Public Class Plant_Compra_Item
    Dim itemprocesar_ficha As IItemProcesarCompras
    Dim xfichaprd As FichaProducto.Prd_Producto
    Dim xfichaprd_medida As FichaProducto.Prd_Medida

    Dim xtb_existencia As DataTable
    Dim xtb_hist_comp As DataTable
    Dim xtb_medidas As DataTable
    Dim xbs_existencia As BindingSource
    Dim xbs_hist_comp As BindingSource
    Dim xbs_medidas As BindingSource
    Dim xauto As String
    Dim xcodigo As String = ""
    Dim xcontenidoempaquecompra As Integer
    Dim xcontenidoempaquecompra_mostrar As Integer
    Dim xdesc1 As Decimal = 0
    Dim xdesc2 As Decimal = 0
    Dim xdesc3 As Decimal = 0
    Dim xmontodesc As Decimal = 0
    Dim xmontoimp As Decimal = 0
    Dim xcostofinal As Decimal = 0
    Dim xmontoimplicor As Decimal = 0


    Property _CodigoProductoProveedor() As String
        Get
            Return xcodigo
        End Get
        Set(ByVal value As String)
            xcodigo = value
        End Set
    End Property

    Property _ContenidoEmpaqueCompraMostrar() As Integer
        Get
            Return xcontenidoempaquecompra_mostrar
        End Get
        Set(ByVal value As Integer)
            xcontenidoempaquecompra_mostrar = value
        End Set
    End Property

    Property _ContenidoEmpaqueCompra() As Integer
        Get
            Return xcontenidoempaquecompra
        End Get
        Set(ByVal value As Integer)
            xcontenidoempaquecompra = value
        End Set
    End Property

    Property _MontoImpuestoLicor() As Decimal
        Get
            Return xmontoimplicor
        End Get
        Set(ByVal value As Decimal)
            xmontoimplicor = value
        End Set
    End Property

    Property _TasaDescuento1() As Decimal
        Get
            Return xdesc1
        End Get
        Set(ByVal value As Decimal)
            xdesc1 = value
        End Set
    End Property

    Property _TasaDescuento2() As Decimal
        Get
            Return xdesc2
        End Get
        Set(ByVal value As Decimal)
            xdesc2 = value
        End Set
    End Property

    Property _TasaDescuento3() As Decimal
        Get
            Return xdesc3
        End Get
        Set(ByVal value As Decimal)
            xdesc3 = value
        End Set
    End Property

    Property _DescuentoTotal() As Decimal
        Get
            Return xmontodesc
        End Get
        Set(ByVal value As Decimal)
            xmontodesc = value
        End Set
    End Property

    Property _TotalImporte() As Decimal
        Get
            Return xmontoimp
        End Get
        Set(ByVal value As Decimal)
            xmontoimp = value
        End Set
    End Property

    Property _CostoFinal() As Decimal
        Get
            Return xcostofinal
        End Get
        Set(ByVal value As Decimal)
            xcostofinal = value
        End Set
    End Property

    ''' <summary>
    ''' PLANTILLA USADA PARA EL COMPORTAMIENTO TIPO DE ITEM A PROCESAR: VENTA/PRESUPUESTO/NOTA/ETC
    ''' </summary>
    Property FichaItemProcesar() As IItemProcesarCompras
        Get
            Return itemprocesar_ficha
        End Get
        Set(ByVal value As IItemProcesarCompras)
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

    Property _MiFichaMedidaEmpaque() As FichaProducto.Prd_Medida
        Get
            Return Me.xfichaprd_medida
        End Get
        Set(ByVal value As FichaProducto.Prd_Medida)
            Me.xfichaprd_medida = value
        End Set
    End Property

    ''' <summary>
    ''' Auto Proveedor
    ''' </summary>
    Property _AutoProveedor() As String
        Get
            Return xauto
        End Get
        Set(ByVal value As String)
            xauto = value
        End Set
    End Property

    Dim TasaImpuesto As Decimal
    Sub New(ByVal xprd As FichaProducto.Prd_Producto, ByVal xtipoitem_procesar As IItemProcesarCompras, ByVal xautopro As String, Optional ByVal xtipoprecio_cliente As String = "1")
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.TasaImpuesto = xprd.RegistroDato._TasaImpuesto

        Me._MiProducto = xprd
        Me._MiFichaMedidaEmpaque = New FichaProducto.Prd_Medida
        Me._AutoProveedor = xautopro
        Me.FichaItemProcesar = xtipoitem_procesar

        xtb_hist_comp = New DataTable
        xbs_hist_comp = New BindingSource(xtb_hist_comp, "")
        xtb_existencia = New DataTable
        xbs_existencia = New BindingSource(xtb_existencia, "")
        xtb_medidas = New DataTable
        xbs_medidas = New BindingSource(xtb_medidas, "")

        Me._ContenidoEmpaqueCompra = Me._MiProducto.RegistroDato._ContEmpqCompra
        Me._ContenidoEmpaqueCompraMostrar = Me._MiProducto.RegistroDato._ContEmpqCompra
    End Sub

    Sub ActualizarEmpaque()
        If xbs_medidas.Current IsNot Nothing Then
            Me._MiFichaMedidaEmpaque.F_BuscarMedida(Me.MCB_MEDIDAS.SelectedValue)

            Dim xdec As Integer = Me._MiFichaMedidaEmpaque.RegistroDato._DigitosDecimalesAUsar
            Dim xformato As String = "99999.999"
            Dim xformato2 As String = "{0:#0.000"

            If xdec > 0 Then
                xdec += 1
            End If

            With Me.MN_CANTIDAD
                .Text = String.Format(xformato2.Substring(0, 5 + xdec) + "}", Me.MN_CANTIDAD._Valor)
                ._Formato = xformato.Substring(0, 5 + xdec)
            End With

            With Me.MN_BONO
                .Text = String.Format(xformato2.Substring(0, 5 + xdec) + "}", Me.MN_BONO._Valor)
                ._Formato = xformato.Substring(0, 5 + xdec)
            End With

            Me.Refresh()
            IrInicio()
        End If
    End Sub

    Sub CargarDepositos()
        Dim xp1 As New SqlParameter("@auto_producto", Me._MiProducto.RegistroDato._AutoProducto)
        Dim xsql As String = "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                                      + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                                      + "where pd.auto_producto = @auto_producto"

        g_MiData.F_GetData(xsql, xtb_existencia, xp1)
    End Sub

    Sub CargarHistoricoCompras()
        Dim xcondicion As String = ""
        Dim xp1 As New SqlParameter("@auto_producto", Me._MiProducto.RegistroDato._AutoProducto)
        Dim xsql As String = "SELECT empaque, contenido_empaque, costo_final, cantidad, fecha, auto_documento, auto_entidad " _
                          + "from compras_detalle where auto_productos = @auto_producto and costo_bruto<>0 and tipo='01' " _
                          + "order by fecha desc "
        g_MiData.F_GetData(xsql, xtb_hist_comp, xp1)
    End Sub

    Sub CargarEmpaques()
        Dim xsql As String = "SELECT nombre x1, auto x2 from productos_medida order by nombre "
        g_MiData.F_GetData(xsql, xtb_medidas)
    End Sub

    Sub Inicializa()
        Try
            CargarHistoricoCompras()
            CargarDepositos()
            CargarEmpaques()
            InicializarControles()

            ActualizaExistencia()
            AddHandler xbs_medidas.PositionChanged, AddressOf ActualizarEmpaque

            Me.E_DESCRIPCION.Text = ""
            Me.E_COSTO_NETO.Text = "0.00"
            Me.LB_IVA.Text = "Iva (00.00%):"
            Me.E_TOTAL.Text = "0.00"
            Me.E_TOT_GENERAL.Text = "0.00"
            Me.E_IMPUESTO.Text = "0.00"
            Me.E_COSTOFINAL.Text = "0.00"
            Me.E_COSTOINVENTARIO.Text = "0.00"
            Me.E_DESCUENTO.Text = "0.00"

            Me.E_DESCRIPCION.Text = Me._MiProducto.RegistroDato._DescripcionDetallaDelProducto
            Me.LB_IVA.Text = "Iva (" + String.Format("{0:#0.00}", TasaImpuesto) + "%):"
            'Me.LB_IVA.Text = "Iva (" + String.Format("{0:#0.00}", Me._MiProducto.RegistroDato._TasaImpuesto) + "%):"
            Me.MN_PSUGERIDO.Text = String.Format("{0:#0.00}", Me._MiProducto.RegistroDato._PrecioSugerido)
            Me.MN_CONTENIDO.Text = String.Format("{0:#0.00}", Me._ContenidoEmpaqueCompra)
            Me.E_COSTOACTUAL.Text = String.Format("{0:#0.00}", Me._MiProducto.RegistroDato._CostoCompra._Base)
            Me.MCB_MEDIDAS.SelectedValue = Me._MiProducto.RegistroDato._AutoEmpaqueCompra

            Dim xp1 As New SqlParameter("@auto_prd", _MiProducto.RegistroDato._AutoProducto)
            Dim xp2 As New SqlParameter("@auto_prv", _AutoProveedor)
            If _AutoProveedor <> "" Then
                Dim xtb1 As New DataTable
                Me.LK_PROV_PRODUCTO.Enabled = True

                Dim xsql As String = "select codigo from productos_proveedor where auto_producto=@auto_prd and auto_proveedor=@auto_prv order by codigo"
                g_MiData.F_GetData(xsql, xtb1, xp1, xp2)

                With Me.MCB_CODIGOS_PRV
                    .Enabled = True
                    .DataSource = xtb1
                    .DisplayMember = "codigo"
                End With
            Else
                Me.LK_PROV_PRODUCTO.Enabled = False
                Me.MCB_CODIGOS_PRV.Enabled = False
            End If

            xp1 = New SqlParameter("@auto_prd", _MiProducto.RegistroDato._AutoProducto)
            Dim xsql2 As String = "select top(1) costo_bruto from compras_detalle where auto_productos=@auto_prd and costo_bruto<>0 and tipo='01' and estatus='0'  order by fecha desc, auto desc"
            Me.E_ULTIMOCOSTO.Text = String.Format("{0:#0.00}", F_GetDecimal(xsql2, xp1))

            If FichaItemProcesar.GetType Is GetType(Item_OrdenesCompraProcesar) Then
                If _AutoProveedor <> "" Then
                    MN_COSTOXUNID.Text = Me.E_ULTIMOCOSTO.Text
                End If
            End If

            FichaItemProcesar.Inicializar(Me)
            If FichaItemProcesar._ContenidoEmpaqueCompra > 0 Then
                Me._ContenidoEmpaqueCompra = FichaItemProcesar._ContenidoEmpaqueCompra
            End If

            With MG_HC
                .Columns.Add("col0", "Empaque")
                .Columns.Add("col1", "Cont")
                .Columns.Add("col2", "Costo/F")
                .Columns.Add("col3", "Cant")
                .Columns.Add("col4", "Fecha")

                With .Columns(1)
                    .Width = 60
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                End With

                With .Columns(2)
                    .Width = 70
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                End With

                With .Columns(3)
                    .Width = 70
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                End With
                .Columns(4).Width = 80
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs_hist_comp
                .Columns(0).DataPropertyName = "empaque"
                .Columns(1).DataPropertyName = "contenido_empaque"
                .Columns(2).DataPropertyName = "costo_final"
                .Columns(3).DataPropertyName = "cantidad"
                .Columns(4).DataPropertyName = "fecha"

                .Ocultar(6)
            End With

            ActualizaRegistrosEncontrados()

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

            CalculaImporte()

            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub InicializarControles()
        With Me.MN_CANTIDAD
            .Text = "0"
            ._ConSigno = False
            ._Formato = "99999"
        End With
        With Me.MN_BONO
            .Text = "0"
            ._ConSigno = False
            ._Formato = "99999"
        End With

        With Me.MN_DSCTO1
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "99.99"
        End With
        With Me.MN_DESC_MONTO1
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "999999999.99"
        End With
        With Me.MN_DSCTO2
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "99.99"
        End With
        With Me.MN_DESC_MONTO2
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "999999999.99"
        End With
        With Me.MN_DSCTO3
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "99.99"
        End With
        With Me.MN_DESC_MONTO3
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "999999999.99"
        End With
        With Me.MN_COSTOXUNID
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "999999999.99"
        End With
        With Me.MN_PSUGERIDO
            ._ConSigno = False
            ._Formato = "999999999.99"
        End With

        With Me.MT_CODIGO
            .MaxLength = 15
        End With
        With Me.MT_NOTAS
            .Text = ""
            .MaxLength = 160
        End With

        With Me.MN_MONTO_TASA_LICOR
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "9999999.99"
        End With

        If Me._MiProducto.RegistroDato._EstatusLicor = TipoEstatus.Activo Then
            Me.MN_MONTO_TASA_LICOR.Enabled = True
        Else
            Me.MN_MONTO_TASA_LICOR.Enabled = False
        End If

        With Me.MN_CONTENIDO
            ._ConSigno = False
            ._Formato = "99999"
            .Text = String.Format("{0:#0}", _MiProducto.RegistroDato._ContEmpqCompra)
            .Enabled = False
        End With

        With Me.MCB_MEDIDAS
            .DataSource = xbs_medidas
            .DisplayMember = "x1"
            .ValueMember = "x2"
            .Enabled = False
        End With
    End Sub

    Sub ActualizaExistencia()
        If xbs_existencia.Current IsNot Nothing Then
            Dim x1 As Single = 0
            For Each dr As DataRowView In xbs_existencia
                x1 += dr.Row("disponible") / Me._ContenidoEmpaqueCompraMostrar
            Next
            Me.E_TOTAL.Text = Format(x1, IIf(Me._MiProducto.RegistroDato._EsPesado = TipoEstatus.Activo, "#0.000", "#0.00"))
        End If
    End Sub

    Sub ActualizaRegistrosEncontrados()
        If xbs_hist_comp.Current IsNot Nothing Then
            Me.E_ITEMS.Text = xtb_hist_comp.Rows.Count.ToString
        Else
            Me.E_ITEMS.Text = "0"
        End If
    End Sub

    Sub FormatoExistencia(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 1 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
            e.Value = e.Value / Me._ContenidoEmpaqueCompraMostrar
            e.Value = Format(e.Value, IIf(Me._MiProducto.RegistroDato._EsPesado = TipoEstatus.Activo, "#0.000", "#0.00"))
        End If
    End Sub

    Sub CalculaImporte(Optional ByVal xtipo As Integer = 0)
        Dim ximp As Decimal = 0
        Dim xful As Decimal = 0
        Dim xiva As Decimal = 0
        Dim xdes1 As Decimal = 0
        Dim xdes2 As Decimal = 0
        Dim xdes3 As Decimal = 0
        Dim xcosfin As Decimal = 0
        Dim xcosinv As Decimal = 0
        Dim xdestot As Decimal = 0

        If Me.MN_CANTIDAD._Valor > 0 Then
            Dim xcos As Decimal = 0

            Dim xd1 As Decimal = 0
            Dim xd2 As Decimal = 0
            Dim xd3 As Decimal = 0

            Dim xdp1 As Decimal = 0
            Dim xdp2 As Decimal = 0
            Dim xdp3 As Decimal = 0

            xcos = (Me.MN_CANTIDAD._Valor * Me.MN_COSTOXUNID._Valor)
            xcos = Decimal.Round(xcos, 2, MidpointRounding.AwayFromZero)

            If xtipo = 2 Then
                If xcos > 0 Then
                    If Me.MN_DESC_MONTO1._Valor > xcos Then
                        MessageBox.Show("Error... Descuento Superior Al Costo... Verifique", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.MN_DESC_MONTO1.Text = "0.0"
                    End If
                    Me.MN_DSCTO1.Text = String.Format("{0:#0.00}", Decimal.Round(Me.MN_DESC_MONTO1._Valor / xcos * 100, 2, MidpointRounding.AwayFromZero))
                End If
            End If
            xdp1 = Me.MN_DSCTO1._Valor
            xd1 = Decimal.Round(xcos * xdp1 / 100, 2, MidpointRounding.AwayFromZero)
            xdes1 = xd1
            xcos -= xd1

            If xtipo = 2 Then
                If xcos > 0 Then
                    If Me.MN_DESC_MONTO2._Valor > xcos Then
                        MessageBox.Show("Error... Descuento Superior Al Costo... Verifique", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.MN_DESC_MONTO2.Text = "0.0"
                    End If
                    Me.MN_DSCTO2.Text = String.Format("{0:#0.00}", Decimal.Round(Me.MN_DESC_MONTO2._Valor / xcos * 100, 2, MidpointRounding.AwayFromZero))
                End If
            End If
            xdp2 = Me.MN_DSCTO2._Valor
            xd2 = Decimal.Round(xcos * xdp2 / 100, 2, MidpointRounding.AwayFromZero)
            xdes2 = xd2
            xcos -= xd2

            If xtipo = 2 Then
                If xcos > 0 Then
                    If Me.MN_DESC_MONTO3._Valor > xcos Then
                        MessageBox.Show("Error... Descuento Superior Al Costo... Verifique", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.MN_DESC_MONTO3.Text = "0.0"
                    End If
                    Me.MN_DSCTO3.Text = String.Format("{0:#0.00}", Decimal.Round(Me.MN_DESC_MONTO3._Valor / xcos * 100, 2, MidpointRounding.AwayFromZero))
                End If
            End If
            xdp3 = Me.MN_DSCTO3._Valor
            xd3 = Decimal.Round(xcos * xdp3 / 100, 2, MidpointRounding.AwayFromZero)
            xdes3 = xd3
            xcos -= xd3

            If xcos = 0 Then
                xdp1 = 0
                xd1 = 0
                xdes1 = 0

                xdp2 = 0
                xd2 = 0
                xdes2 = 0

                xdp3 = 0
                xd3 = 0
                xdes3 = 0

                Me.MN_DSCTO1.Text = "0.0"
                Me.MN_DSCTO2.Text = "0.0"
                Me.MN_DSCTO3.Text = "0.0"
            End If

            xcosfin = Decimal.Round(xcos / Me.MN_CANTIDAD._Valor, 2, MidpointRounding.AwayFromZero)
            xcosinv = Decimal.Round(xcosfin / Me._ContenidoEmpaqueCompra, 2, MidpointRounding.AwayFromZero)

            xcos = (Me.MN_CANTIDAD._Valor * Me.MN_COSTOXUNID._Valor)
            xdestot += Decimal.Round(xcos * Me.MN_DSCTO1._Valor / 100, 2, MidpointRounding.AwayFromZero)
            xcos -= Decimal.Round(xcos * Me.MN_DSCTO1._Valor / 100, 2, MidpointRounding.AwayFromZero)
            xdestot += Decimal.Round(xcos * Me.MN_DSCTO2._Valor / 100, 2, MidpointRounding.AwayFromZero)
            xcos -= Decimal.Round(xcos * Me.MN_DSCTO2._Valor / 100, 2, MidpointRounding.AwayFromZero)
            xdestot += Decimal.Round(xcos * Me.MN_DSCTO3._Valor / 100, 2, MidpointRounding.AwayFromZero)
            xcos -= Decimal.Round(xcos * Me.MN_DSCTO3._Valor / 100, 2, MidpointRounding.AwayFromZero)

            ximp = xcos
            xiva = (ximp * TasaImpuesto) / 100
            'xiva = (ximp * xfichaprd.RegistroDato._TasaImpuesto) / 100
            xiva = Decimal.Round(xiva, 2, MidpointRounding.AwayFromZero)
            xful = Decimal.Round(ximp + xiva + Me.MN_MONTO_TASA_LICOR._Valor, 2, MidpointRounding.AwayFromZero)

            _DescuentoTotal = xdestot
            _TotalImporte = ximp
            _CostoFinal = xcosfin
            _MontoImpuestoLicor = Me.MN_MONTO_TASA_LICOR._Valor

            Me.MN_DESC_MONTO1.Text = String.Format("{0:#0.00}", xdes1)
            Me.MN_DESC_MONTO2.Text = String.Format("{0:#0.00}", xdes2)
            Me.MN_DESC_MONTO3.Text = String.Format("{0:#0.00}", xdes3)
            Me.E_COSTOFINAL.Text = String.Format("{0:#0.00}", xcosfin)
            Me.E_COSTOINVENTARIO.Text = String.Format("{0:#0.00}", xcosinv)
            Me.E_COSTO_NETO.Text = String.Format("{0:#0.00}", ximp)
            Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", xiva)
            Me.E_TOT_GENERAL.Text = String.Format("{0:#0.00}", xful)
            Me.E_DESCUENTO.Text = String.Format("{0:#0.00}", xdestot)
        End If
    End Sub

    Private Sub MN_DSCTO(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DSCTO1.LostFocus, MN_DSCTO2.LostFocus, MN_DSCTO3.LostFocus
        CalculaImporte(1)
    End Sub

    Private Sub MN_DESC_MONTO(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_DESC_MONTO1.LostFocus, MN_DESC_MONTO2.LostFocus, MN_DESC_MONTO3.LostFocus
        CalculaImporte(2)
    End Sub

    Private Sub Otros(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_BONO.LostFocus, MN_CANTIDAD.LostFocus, MN_MONTO_TASA_LICOR.LostFocus, MN_CONTENIDO.LostFocus
        If CType(sender, MisControles.Controles.MisNumeros).Name = "MN_CONTENIDO" Then
            If MN_CONTENIDO._Valor > 0 Then
                Me._ContenidoEmpaqueCompra = Me.MN_CONTENIDO._Valor
            End If
        End If
        CalculaImporte()
    End Sub

    Private Sub MN_COSTOXUNID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_COSTOXUNID.LostFocus
        If Me.MN_COSTOXUNID._Valor = 0 Then
            Me.MN_BONO.Text = "0"
            Me.MN_DSCTO1.Text = "0.0"
            Me.MN_DSCTO2.Text = "0.0"
            Me.MN_DSCTO3.Text = "0.0"
            Me.MN_DESC_MONTO1.Text = "0.0"
            Me.MN_DESC_MONTO2.Text = "0.0"
            Me.MN_DESC_MONTO3.Text = "0.0"

            Me.MN_PSUGERIDO.ReadOnly = True
            Me.MN_BONO.ReadOnly = True
            Me.MN_DSCTO1.ReadOnly = True
            Me.MN_DSCTO2.ReadOnly = True
            Me.MN_DSCTO3.ReadOnly = True
            Me.MN_DESC_MONTO1.ReadOnly = True
            Me.MN_DESC_MONTO2.ReadOnly = True
            Me.MN_DESC_MONTO3.ReadOnly = True
        Else
            Me.MN_PSUGERIDO.ReadOnly = False
            Me.MN_BONO.ReadOnly = False
            Me.MN_DESC_MONTO1.ReadOnly = False
            Me.MN_DESC_MONTO2.ReadOnly = False
            Me.MN_DESC_MONTO3.ReadOnly = False
            Me.MN_DSCTO1.ReadOnly = False
            Me.MN_DSCTO2.ReadOnly = False
            Me.MN_DSCTO3.ReadOnly = False
        End If
        CalculaImporte()
    End Sub

    Function Validar() As Boolean
        If Me.FichaItemProcesar._TipoDocumento = TipoDocumentoCompra.Factura Then
            Dim xr As Boolean = False
            If Me.MN_COSTOXUNID._Valor = 0 Then
                If Me.MT_NOTAS.r_Valor <> "" Then
                    xr = True
                Else
                    MessageBox.Show("Alerta... Debe Indicar Motivo Por El Cual La Cantidad A Registrar Es Cero(0)", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MT_NOTAS.Select()
                    Me.MT_NOTAS.Focus()
                    xr = False
                End If
            Else
                xr = True
            End If
            Return xr
        Else
            Return True
        End If
    End Function

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If Validar() Then
            If Me.MN_CANTIDAD._Valor > 0 Then
                Dim xerror As Boolean = False

                If Me._MiFichaMedidaEmpaque.RegistroDato._ForzarDecimales = TipoEstatus.Activo Then
                    If ((Me.MN_CANTIDAD._Valor - Int(Me.MN_CANTIDAD._Valor)) = 0 Or (Me.MN_CANTIDAD._Valor - Int(Me.MN_CANTIDAD._Valor)) = 0.5) And ((Me.MN_BONO._Valor - Int(Me.MN_BONO._Valor)) = 0 Or (Me.MN_BONO._Valor - Int(Me.MN_BONO._Valor)) = 0.5) Then
                    Else
                        xerror = True
                    End If
                End If

                If xerror = False Then
                    'If _DescuentoTotal <= _TotalImporte Then
                    If _DescuentoTotal <= (Me.MN_CANTIDAD._Valor * Me.MN_COSTOXUNID._Valor) Then
                        Dim xitem As New IItemProcesarCompras.Data
                        With xitem
                            ._Cantidad = Me.MN_CANTIDAD._Valor
                            ._Bono = MN_BONO._Valor
                            ._TasaDescto1 = Me.MN_DSCTO1._Valor
                            ._TasaDescto2 = Me.MN_DSCTO2._Valor
                            ._TasaDescto3 = Me.MN_DSCTO3._Valor
                            ._CostoxUnidad = Me.MN_COSTOXUNID._Valor
                            ._CodigoProducto = Me.MT_CODIGO.r_Valor
                            ._PrecioSugerido = Me.MN_PSUGERIDO._Valor
                            ._NotasItem = Me.MT_NOTAS.r_Valor
                            ._TotalImporte = _TotalImporte
                            ._CostoFinal = _CostoFinal
                            ._MontoImpuestoLicor = Me._MontoImpuestoLicor
                            ._FichaProducto = xfichaprd.RegistroDato
                            ._ContenidoEmpaque = Me._ContenidoEmpaqueCompra
                            ._AutoMedidaEmpaque = Me.MCB_MEDIDAS.SelectedValue
                        End With
                        If Me.FichaItemProcesar.ProcesarItem(xitem) Then
                            Me.Close()
                        Else
                            Me.MT_CODIGO.Select()
                        End If
                    Else
                        Funciones.MensajeDeAlerta("Descuento Supera El Monto a Pagar, Verifique Por Favor")
                        Me.MN_DSCTO1.Select()
                    End If
                Else
                    Funciones.MensajeDeAlerta("Problema En Cantidad A Facturar, No Se Aceptan Cantidades Inexactas, Verifique Por Favor")
                    Me.MN_CANTIDAD.Select()
                End If
            Else
                Funciones.MensajeDeAlerta("Cantidad A Procesar No Puede Ser Cero (0), Verifique Por Favor")
                Me.MN_CANTIDAD.Select()
            End If
        End If
    End Sub

    Private Sub Plant_Compra_Item_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plant_Compra_Item_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub LK_PROV_PRODUCTO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LK_PROV_PRODUCTO.LinkClicked
        With Me.MCB_CODIGOS_PRV
            .DroppedDown = True
            .Select()
            .Focus()
        End With
    End Sub

    Private Sub MCB_CODIGOS_PRV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_CODIGOS_PRV.SelectedIndexChanged
        If Me.MCB_CODIGOS_PRV.SelectedIndex <> -1 Then
            With Me.MT_CODIGO
                .Text = Me.MCB_CODIGOS_PRV.SelectedItem(0).ToString
                .Select()
                .Focus()
            End With
        End If
    End Sub

    Private Sub CHB_CONTENIDO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHB_CONTENIDO.CheckedChanged
        Me.MN_CONTENIDO.Enabled = Me.CHB_CONTENIDO.Checked
        If Me.CHB_CONTENIDO.Checked Then
        Else
            Me.MN_CONTENIDO.Text = String.Format("{0:#0}", Me._MiProducto.RegistroDato._ContEmpqCompra)
            Me._ContenidoEmpaqueCompra = Me._MiProducto.RegistroDato._ContEmpqCompra
        End If
        IrInicio()
        CalculaImporte()
        Me.Refresh()
    End Sub

    Private Sub CHB_POR_UNIDAD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHB_POR_UNIDAD.CheckedChanged
        If xbs_existencia.Current IsNot Nothing Then
            If Me.CHB_POR_UNIDAD.Checked Then
                Me._ContenidoEmpaqueCompraMostrar = 1
            Else
                Me._ContenidoEmpaqueCompraMostrar = Me._MiProducto.RegistroDato._ContEmpqCompra
            End If
            ActualizaExistencia()
            xbs_existencia.CurrencyManager.Refresh()
        End If
    End Sub

    Private Sub CHB_PROVEEDOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHB_PROVEEDOR.CheckedChanged
        If Me.CHB_PROVEEDOR.Checked Then
            xbs_hist_comp.Filter = "auto_entidad='" + Me._AutoProveedor + "'"
        Else
            xbs_hist_comp.Filter = "auto_entidad<>''"
        End If
    End Sub

    Private Sub MG_HC_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_HC.Accion
        Try
            Dim xcompra As New FichaCompras.c_Compra
            Dim xreg As DataRow = CType(xrow.DataBoundItem, DataRowView).Row

            xcompra.F_CargarCompra(xreg("auto_documento").ToString.Trim)
            If xcompra.RegistroDato._TipoCompraRegistrada = TipoCompraRegistrada.CompraMercancia Then
                VisualizarDoc_Compras(xcompra.RegistroDato._AutoDocumentoCompra)
            Else
                VisualizarDoc_Gastos(xcompra.RegistroDato._AutoDocumentoCompra)
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub MN_CONTENIDO_LOSTFOCUS(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_CONTENIDO.LostFocus
        If Me.MN_CONTENIDO._Valor <= 0 Then
            MN_CONTENIDO.Text = String.Format("{0:#0}", _MiProducto.RegistroDato._ContEmpqCompra)
        End If
        Me._ContenidoEmpaqueCompra = Me.MN_CONTENIDO._Valor
        IrInicio()
    End Sub

    Private Sub CHB_EMPAQUE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHB_EMPAQUE.CheckedChanged
        If Me.CHB_EMPAQUE.Checked = False Then
            Me.MCB_MEDIDAS.SelectedValue = Me._MiProducto.RegistroDato._AutoEmpaqueCompra
        End If
        Me.MCB_MEDIDAS.Enabled = Me.CHB_EMPAQUE.Checked
        IrInicio()
    End Sub

    Sub IrInicio()
        With Me.MT_CODIGO
            .Focus()
            .Select()
        End With
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

    Private Sub Plant_Compra_Item_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IItemProcesarCompras
    Class Data
        Private xcantidad As Single
        Private xcostoxunid As Decimal
        Private xdscto1p As Decimal
        Private xdscto2p As Decimal
        Private xdscto3p As Decimal
        Private xbono As Single
        Private xcodigo As String
        Private xnotas As String
        Private xpsugerido As Decimal
        Private ximporte As Decimal
        Private xcostofinal As Decimal
        Private xmontoimplicor As Decimal
        Private xcontenidoempaque As Integer
        Private xfichaprd As FichaProducto.Prd_Producto.c_Registro
        Private xauto_medida_empaque As String

        ''' <summary>
        ''' Codigo Del Producto Del Proveedor
        ''' </summary>
        Protected Friend Property _CodigoProducto() As String
            Get
                Return xcodigo
            End Get
            Set(ByVal value As String)
                xcodigo = value
            End Set
        End Property

        ''' <summary>
        ''' Notas Adicionales De La Compra Del Producto
        ''' </summary>
        Protected Friend Property _NotasItem() As String
            Get
                Return xnotas
            End Get
            Set(ByVal value As String)
                xnotas = value
            End Set
        End Property

        ''' <summary>
        ''' Precio Sugerido
        ''' </summary>
        Protected Friend Property _PrecioSugerido() As Decimal
            Get
                Return xpsugerido
            End Get
            Set(ByVal value As Decimal)
                xpsugerido = value
            End Set
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
        ''' Cantidad a Descontar
        ''' </summary>
        Protected Friend Property _Bono() As Single
            Get
                Return xbono
            End Get
            Set(ByVal value As Single)
                xbono = value
            End Set
        End Property

        ''' <summary>
        ''' Costo x Unidad, Sin Descuento
        ''' </summary>
        Protected Friend Property _CostoxUnidad() As Decimal
            Get
                Return xcostoxunid
            End Get
            Set(ByVal value As Decimal)
                xcostoxunid = value
            End Set
        End Property

        ''' <summary>
        ''' Tasa Del Descuento 1
        ''' </summary>
        Protected Friend Property _TasaDescto1() As Decimal
            Get
                Return xdscto1p
            End Get
            Set(ByVal value As Decimal)
                xdscto1p = value
            End Set
        End Property

        ''' <summary>
        ''' Tasa Del Descuento 2
        ''' </summary>
        Protected Friend Property _TasaDescto2() As Decimal
            Get
                Return xdscto2p
            End Get
            Set(ByVal value As Decimal)
                xdscto2p = value
            End Set
        End Property

        ''' <summary>
        ''' Tasa Del Descuento 3
        ''' </summary>
        Protected Friend Property _TasaDescto3() As Decimal
            Get
                Return xdscto3p
            End Get
            Set(ByVal value As Decimal)
                xdscto3p = value
            End Set
        End Property

        ''' <summary>
        ''' Total Importe Compra
        ''' </summary>
        Protected Friend Property _TotalImporte() As Decimal
            Get
                Return ximporte
            End Get
            Set(ByVal value As Decimal)
                ximporte = value
            End Set
        End Property

        ''' <summary>
        ''' Costo Final Del Producto
        ''' </summary>
        Protected Friend Property _CostoFinal() As Decimal
            Get
                Return xcostofinal
            End Get
            Set(ByVal value As Decimal)
                xcostofinal = value
            End Set
        End Property

        Protected Friend Property _MontoImpuestoLicor() As Decimal
            Get
                Return xmontoimplicor
            End Get
            Set(ByVal value As Decimal)
                xmontoimplicor = value
            End Set
        End Property

        Protected Friend Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
            Get
                Return xfichaprd
            End Get
            Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                xfichaprd = value
            End Set
        End Property

        Protected Friend Property _ContenidoEmpaque() As Integer
            Get
                Return xcontenidoempaque
            End Get
            Set(ByVal value As Integer)
                xcontenidoempaque = value
            End Set
        End Property

        Protected Friend Property _AutoMedidaEmpaque() As String
            Get
                Return Me.xauto_medida_empaque
            End Get
            Set(ByVal value As String)
                Me.xauto_medida_empaque = value
            End Set
        End Property


        Sub New()
            Me._AutoMedidaEmpaque = ""
            Me._Bono = 0
            Me._Cantidad = 0
            Me._CodigoProducto = ""
            Me._ContenidoEmpaque = 0
            Me._CostoFinal = 0
            Me._CostoxUnidad = 0
            Me._FichaProducto = Nothing
            Me._MontoImpuestoLicor = 0
            Me._NotasItem = ""
            Me._PrecioSugerido = 0
            Me._TasaDescto1 = 0
            Me._TasaDescto2 = 0
            Me._TasaDescto3 = 0
            Me._TotalImporte = 0
        End Sub
    End Class

    Event ActualizarTabla()
    Function ProcesarItem(ByVal xdata As Data) As Boolean
    Sub Inicializar(ByVal xform As Object)
    ReadOnly Property _ContenidoEmpaqueCompra() As Integer
    ReadOnly Property _TipoDocumento() As TipoDocumentoCompra
End Interface

Public Class Item_CompraProcesar
    Implements IItemProcesarCompras
    Public Event ActualizarTabla() Implements IItemProcesarCompras.ActualizarTabla

    Function Factura(ByVal xdata As IItemProcesarCompras.Data) As Boolean
        Dim xprd_medida As New FichaProducto.Prd_Medida
        Dim xdeposito As New FichaGlobal.c_Depositos

        xprd_medida.F_BuscarMedida(xdata._AutoMedidaEmpaque)
        xdeposito.F_BuscarDeposito(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoCompras)

        Dim xregistro As New FichaCompras.c_TemporalCompra.AgregarRegistro
        With xregistro
            ._Bono = xdata._Bono
            ._Cantidad = xdata._Cantidad
            ._CodigoPrdProveedor = xdata._CodigoProducto
            ._ContenidoEmpaque = xdata._ContenidoEmpaque
            ._CostoFinal = xdata._CostoFinal
            ._CostoNeto = xdata._CostoxUnidad
            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            ._FichaDeposito = xdeposito.RegistroDato
            ._FichaMedidaEmapque = xprd_medida.RegistroDato
            ._FichaProducto = xdata._FichaProducto
            ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
            ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
            ._Importe = xdata._TotalImporte
            ._ImpuestoLicor = xdata._MontoImpuestoLicor
            ._Notas = xdata._NotasItem
            ._PrecioSugerido = xdata._PrecioSugerido
            ._TasaDescuento_1 = xdata._TasaDescto1
            ._TasaDescuento_2 = xdata._TasaDescto2
            ._TasaDescuento_3 = xdata._TasaDescto3
            ._TipoDocumento = TipoDocumentoCompra.Factura
        End With

        g_MiData.f_FichaCompras.F_TemporalCompra.F_AgregarRegisto(xregistro)
        Return True
    End Function

    Public Function ProcesarItem(ByVal xdata As IItemProcesarCompras.Data) As Boolean Implements IItemProcesarCompras.ProcesarItem
        Try
            Factura(xdata)
            RaiseEvent ActualizarTabla()
            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Public Sub Inicializar(ByVal xform As Object) Implements IItemProcesarCompras.Inicializar
    End Sub

    Public ReadOnly Property _ContenidoEmpaqueCompra() As Integer Implements IItemProcesarCompras._ContenidoEmpaqueCompra
        Get
            Return 0
        End Get
    End Property

    Public ReadOnly Property _TipoDocumento() As DataSistema.MiDataSistema.DataSistema.TipoDocumentoCompra Implements IItemProcesarCompras._TipoDocumento
        Get
            Return TipoDocumentoCompra.Factura
        End Get
    End Property
End Class

Public Class Item_ActualizarCompraProcesar
    Implements IItemProcesarCompras
    Public Event ActualizarTabla() Implements IItemProcesarCompras.ActualizarTabla

    Dim _TemporalCompra As FichaCompras.c_TemporalCompra
    Dim xformulario As System.Windows.Forms.Form
    Dim MT_CODIGO As MisTextos
    Dim MT_NOTAS As MisTextos
    Dim MN_CANTIDAD As MisNumeros
    Dim MN_COSTOXUNID As MisNumeros
    Dim MN_PSUGERIDO As MisNumeros
    Dim MN_BONO As MisNumeros
    Dim MN_DSCTO1 As MisNumeros
    Dim MN_DSCTO2 As MisNumeros
    Dim MN_DSCTO3 As MisNumeros
    Dim MN_DESC_MONTO1 As MisNumeros
    Dim MN_DESC_MONTO2 As MisNumeros
    Dim MN_DESC_MONTO3 As MisNumeros
    Dim MN_IMP_LICOR As MisNumeros
    Dim MN_CONTENIDO As MisNumeros
    Dim MCB_MEDIDA As MisComboBox
    Dim CHB_CAMBIAR_CONTENIDO As CheckBox
    Dim CHB_CAMBIAR_EMPAQUE As CheckBox

    Sub New(ByVal xrow As DataRow)
        _TemporalCompra = New FichaCompras.c_TemporalCompra
        _TemporalCompra.M_CargarRegistro(xrow)
    End Sub

    Function Factura(ByVal xdata As IItemProcesarCompras.Data) As Boolean
        Dim xprd_medida As New FichaProducto.Prd_Medida
        Dim xdeposito As New FichaGlobal.c_Depositos

        xprd_medida.F_BuscarMedida(xdata._AutoMedidaEmpaque)
        xdeposito.F_BuscarDeposito(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoCompras)

        Dim xregistro As New FichaCompras.c_TemporalCompra.AgregarRegistro
        With xregistro
            ._Bono = xdata._Bono
            ._Cantidad = xdata._Cantidad
            ._CodigoPrdProveedor = xdata._CodigoProducto
            ._ContenidoEmpaque = xdata._ContenidoEmpaque
            ._CostoFinal = xdata._CostoFinal
            ._CostoNeto = xdata._CostoxUnidad
            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            ._FichaDeposito = xdeposito.RegistroDato
            ._FichaMedidaEmapque = xprd_medida.RegistroDato
            ._FichaProducto = xdata._FichaProducto
            ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
            ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
            ._Importe = xdata._TotalImporte
            ._ImpuestoLicor = xdata._MontoImpuestoLicor
            ._Notas = xdata._NotasItem
            ._PrecioSugerido = xdata._PrecioSugerido
            ._TasaDescuento_1 = xdata._TasaDescto1
            ._TasaDescuento_2 = xdata._TasaDescto2
            ._TasaDescuento_3 = xdata._TasaDescto3
            ._TipoDocumento = TipoDocumentoCompra.Factura
        End With

        g_MiData.f_FichaCompras.F_TemporalCompra.F_ActualizarRegistro(_TemporalCompra.RegistroDato._AutoItem, xregistro)
        Return True
    End Function

    Public Function ProcesarItem(ByVal xdata As IItemProcesarCompras.Data) As Boolean Implements IItemProcesarCompras.ProcesarItem
        Try
            Factura(xdata)
            RaiseEvent ActualizarTabla()
            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Public Sub Inicializar(ByVal xform As Object) Implements IItemProcesarCompras.Inicializar
        Try
            xformulario = xform
            MT_CODIGO = xformulario.Controls.Find("MT_CODIGO", True)(0)
            MT_NOTAS = xformulario.Controls.Find("MT_NOTAS", True)(0)
            MN_CANTIDAD = xformulario.Controls.Find("MN_CANTIDAD", True)(0)
            MN_COSTOXUNID = xformulario.Controls.Find("MN_COSTOXUNID", True)(0)
            MN_PSUGERIDO = xformulario.Controls.Find("MN_PSUGERIDO", True)(0)
            MN_BONO = xformulario.Controls.Find("MN_BONO", True)(0)
            MN_DSCTO1 = xformulario.Controls.Find("MN_DSCTO1", True)(0)
            MN_DSCTO2 = xformulario.Controls.Find("MN_DSCTO2", True)(0)
            MN_DSCTO3 = xformulario.Controls.Find("MN_DSCTO3", True)(0)
            MN_DESC_MONTO1 = xformulario.Controls.Find("MN_DESC_MONTO1", True)(0)
            MN_DESC_MONTO2 = xformulario.Controls.Find("MN_DESC_MONTO2", True)(0)
            MN_DESC_MONTO3 = xformulario.Controls.Find("MN_DESC_MONTO3", True)(0)
            MN_IMP_LICOR = xformulario.Controls.Find("MN_MONTO_TASA_LICOR", True)(0)
            MN_CONTENIDO = xformulario.Controls.Find("MN_CONTENIDO", True)(0)
            MCB_MEDIDA = xformulario.Controls.Find("MCB_MEDIDAS", True)(0)
            CHB_CAMBIAR_CONTENIDO = xformulario.Controls.Find("CHB_CONTENIDO", True)(0)
            CHB_CAMBIAR_EMPAQUE = xformulario.Controls.Find("CHB_EMPAQUE", True)(0)

            Dim xformato2 As String = "{0:#0.000"
            Dim xdec As Integer = _TemporalCompra.RegistroDato._NumeroDecimalesMedida
            If xdec > 0 Then
                xdec += 1
            End If

            MT_CODIGO.Text = _TemporalCompra.RegistroDato._CodigoProductoProveedor
            MT_NOTAS.Text = _TemporalCompra.RegistroDato._NotasItem
            MN_CANTIDAD.Text = String.Format(xformato2.Substring(0, 5 + xdec) + "}", _TemporalCompra.RegistroDato._CantidadItems)
            MN_COSTOXUNID.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._CostoUnitario)
            MN_PSUGERIDO.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._PSugerido)
            MN_BONO.Text = String.Format(xformato2.Substring(0, 5 + xdec) + "}", _TemporalCompra.RegistroDato._Bono)
            MN_DSCTO1.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_1._Tasa)
            MN_DSCTO2.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_2._Tasa)
            MN_DSCTO3.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_3._Tasa)
            MN_DESC_MONTO1.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_1._Valor)
            MN_DESC_MONTO2.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_2._Valor)
            MN_DESC_MONTO3.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_3._Valor)
            MN_IMP_LICOR.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._MontoImpuestoLicor)
            Me.MN_CONTENIDO.Text = String.Format("{0:#0}", _TemporalCompra.RegistroDato._ContenidoEmpaque)
            Me.MCB_MEDIDA.SelectedValue = _TemporalCompra.RegistroDato._AutoMedida
            Me.CHB_CAMBIAR_EMPAQUE.Checked = IIf(_TemporalCompra.RegistroDato._f_FichaProducto._AutoEmpaqueCompra = _TemporalCompra.RegistroDato._AutoMedida, False, True)
            Me.CHB_CAMBIAR_CONTENIDO.Checked = IIf(_TemporalCompra.RegistroDato._f_FichaProducto._ContEmpqCompra = _TemporalCompra.RegistroDato._ContenidoEmpaque, False, True)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Public ReadOnly Property _ContenidoEmpaqueCompra() As Integer Implements IItemProcesarCompras._ContenidoEmpaqueCompra
        Get
            Return _TemporalCompra.RegistroDato._ContenidoEmpaque
        End Get
    End Property

    Public ReadOnly Property _TipoDocumento() As DataSistema.MiDataSistema.DataSistema.TipoDocumentoCompra Implements IItemProcesarCompras._TipoDocumento
        Get
            Return TipoDocumentoCompra.Factura
        End Get
    End Property
End Class

Public Class Item_OrdenesCompraProcesar
    Implements IItemProcesarCompras
    Public Event ActualizarTabla() Implements IItemProcesarCompras.ActualizarTabla

    Dim xformulario As System.Windows.Forms.Form
    Dim MN_IMP_LICOR As MisNumeros

    Function Factura(ByVal xdata As IItemProcesarCompras.Data) As Boolean
        Dim xprd_medida As New FichaProducto.Prd_Medida
        Dim xdeposito As New FichaGlobal.c_Depositos

        xprd_medida.F_BuscarMedida(xdata._AutoMedidaEmpaque)
        xdeposito.F_BuscarDeposito(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoCompras)

        Dim xregistro As New FichaCompras.c_TemporalCompra.AgregarRegistro
        With xregistro
            ._Bono = xdata._Bono
            ._Cantidad = xdata._Cantidad
            ._CodigoPrdProveedor = xdata._CodigoProducto
            ._ContenidoEmpaque = xdata._ContenidoEmpaque
            ._CostoFinal = xdata._CostoFinal
            ._CostoNeto = xdata._CostoxUnidad
            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            ._FichaDeposito = xdeposito.RegistroDato
            ._FichaMedidaEmapque = xprd_medida.RegistroDato
            ._FichaProducto = xdata._FichaProducto
            ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
            ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
            ._Importe = xdata._TotalImporte
            ._ImpuestoLicor = xdata._MontoImpuestoLicor
            ._Notas = xdata._NotasItem
            ._PrecioSugerido = xdata._PrecioSugerido
            ._TasaDescuento_1 = xdata._TasaDescto1
            ._TasaDescuento_2 = xdata._TasaDescto2
            ._TasaDescuento_3 = xdata._TasaDescto3
            ._TipoDocumento = TipoDocumentoCompra.OrdenCompra
        End With

        g_MiData.f_FichaCompras.F_TemporalCompra.F_AgregarRegisto(xregistro)
        Return True
    End Function

    Public Function ProcesarItem(ByVal xdata As IItemProcesarCompras.Data) As Boolean Implements IItemProcesarCompras.ProcesarItem
        Try
            If Factura(xdata) Then
                RaiseEvent ActualizarTabla()
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Sub Inicializar(ByVal xform As Object) Implements IItemProcesarCompras.Inicializar
        Try
            xformulario = xform
            MN_IMP_LICOR = xformulario.Controls.Find("MN_MONTO_TASA_LICOR", True)(0)
            MN_IMP_LICOR.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public ReadOnly Property _ContenidoEmpaqueCompra() As Integer Implements IItemProcesarCompras._ContenidoEmpaqueCompra
        Get
        End Get
    End Property

    Public ReadOnly Property _TipoDocumento() As DataSistema.MiDataSistema.DataSistema.TipoDocumentoCompra Implements IItemProcesarCompras._TipoDocumento
        Get
            Return TipoDocumentoCompra.OrdenCompra
        End Get
    End Property
End Class

Public Class Item_ActualizarOrdenesCompraProcesar
    Implements IItemProcesarCompras
    Public Event ActualizarTabla() Implements IItemProcesarCompras.ActualizarTabla

    Dim xformulario As System.Windows.Forms.Form
    Dim MT_CODIGO As MisTextos
    Dim MT_NOTAS As MisTextos
    Dim MN_CANTIDAD As MisNumeros
    Dim MN_COSTOXUNID As MisNumeros
    Dim MN_PSUGERIDO As MisNumeros
    Dim MN_BONO As MisNumeros
    Dim MN_DSCTO1 As MisNumeros
    Dim MN_DSCTO2 As MisNumeros
    Dim MN_DSCTO3 As MisNumeros
    Dim MN_DESC_MONTO1 As MisNumeros
    Dim MN_DESC_MONTO2 As MisNumeros
    Dim MN_DESC_MONTO3 As MisNumeros
    Dim MN_IMP_LICOR As MisNumeros

    Dim _TemporalCompra As FichaCompras.c_TemporalCompra

    Sub New(ByVal xrow As DataRow)
        _TemporalCompra = New FichaCompras.c_TemporalCompra
        _TemporalCompra.M_CargarRegistro(xrow)
    End Sub

    Function Factura(ByVal xdata As IItemProcesarCompras.Data) As Boolean
        Dim xprd_medida As New FichaProducto.Prd_Medida
        Dim xdeposito As New FichaGlobal.c_Depositos

        xprd_medida.F_BuscarMedida(xdata._AutoMedidaEmpaque)
        xdeposito.F_BuscarDeposito(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoCompras)

        Dim xregistro As New FichaCompras.c_TemporalCompra.AgregarRegistro
        With xregistro
            ._Bono = xdata._Bono
            ._Cantidad = xdata._Cantidad
            ._CodigoPrdProveedor = xdata._CodigoProducto
            ._ContenidoEmpaque = xdata._ContenidoEmpaque
            ._CostoFinal = xdata._CostoFinal
            ._CostoNeto = xdata._CostoxUnidad
            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            ._FichaDeposito = xdeposito.RegistroDato
            ._FichaMedidaEmapque = xprd_medida.RegistroDato
            ._FichaProducto = xdata._FichaProducto
            ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
            ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
            ._Importe = xdata._TotalImporte
            ._ImpuestoLicor = xdata._MontoImpuestoLicor
            ._Notas = xdata._NotasItem
            ._PrecioSugerido = xdata._PrecioSugerido
            ._TasaDescuento_1 = xdata._TasaDescto1
            ._TasaDescuento_2 = xdata._TasaDescto2
            ._TasaDescuento_3 = xdata._TasaDescto3
            ._TipoDocumento = TipoDocumentoCompra.OrdenCompra
        End With

        g_MiData.f_FichaCompras.F_TemporalCompra.F_ActualizarRegistro(_TemporalCompra.RegistroDato._AutoItem, xregistro)
        Return True
    End Function

    Public Sub Inicializar(ByVal xform As Object) Implements IItemProcesarCompras.Inicializar
        Try
            xformulario = xform

            MT_CODIGO = xformulario.Controls.Find("MT_CODIGO", True)(0)
            MT_NOTAS = xformulario.Controls.Find("MT_NOTAS", True)(0)
            MN_CANTIDAD = xformulario.Controls.Find("MN_CANTIDAD", True)(0)
            MN_COSTOXUNID = xformulario.Controls.Find("MN_COSTOXUNID", True)(0)
            MN_PSUGERIDO = xformulario.Controls.Find("MN_PSUGERIDO", True)(0)
            MN_BONO = xformulario.Controls.Find("MN_BONO", True)(0)
            MN_DSCTO1 = xformulario.Controls.Find("MN_DSCTO1", True)(0)
            MN_DSCTO2 = xformulario.Controls.Find("MN_DSCTO2", True)(0)
            MN_DSCTO3 = xformulario.Controls.Find("MN_DSCTO3", True)(0)
            MN_DESC_MONTO1 = xformulario.Controls.Find("MN_DESC_MONTO1", True)(0)
            MN_DESC_MONTO2 = xformulario.Controls.Find("MN_DESC_MONTO2", True)(0)
            MN_DESC_MONTO3 = xformulario.Controls.Find("MN_DESC_MONTO3", True)(0)
            MN_IMP_LICOR = xformulario.Controls.Find("MN_MONTO_TASA_LICOR", True)(0)

            Dim xformato2 As String = "{0:#0.000"
            Dim xdec As Integer = _TemporalCompra.RegistroDato._NumeroDecimalesMedida
            If xdec > 0 Then
                xdec += 1
            End If

            MT_CODIGO.Text = _TemporalCompra.RegistroDato._CodigoProductoProveedor
            MT_NOTAS.Text = _TemporalCompra.RegistroDato._NotasItem
            MN_CANTIDAD.Text = String.Format(xformato2.Substring(0, 5 + xdec) + "}", _TemporalCompra.RegistroDato._CantidadItems)
            MN_COSTOXUNID.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._CostoUnitario)
            MN_PSUGERIDO.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._PSugerido)
            MN_BONO.Text = String.Format(xformato2.Substring(0, 5 + xdec) + "}", _TemporalCompra.RegistroDato._Bono)
            MN_DSCTO1.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_1._Tasa)
            MN_DSCTO2.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_2._Tasa)
            MN_DSCTO3.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_3._Tasa)
            MN_DESC_MONTO1.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_1._Valor)
            MN_DESC_MONTO2.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_2._Valor)
            MN_DESC_MONTO3.Text = String.Format("{0:#0.00}", _TemporalCompra.RegistroDato._Descuento_3._Valor)
            MN_IMP_LICOR.Enabled = False
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Public Function ProcesarItem(ByVal xdata As IItemProcesarCompras.Data) As Boolean Implements IItemProcesarCompras.ProcesarItem
        Try
            Factura(xdata)
            RaiseEvent ActualizarTabla()
            Return True
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Function

    Public ReadOnly Property _ContenidoEmpaqueCompra() As Integer Implements IItemProcesarCompras._ContenidoEmpaqueCompra
        Get
        End Get
    End Property

    Public ReadOnly Property _TipoDocumento() As DataSistema.MiDataSistema.DataSistema.TipoDocumentoCompra Implements IItemProcesarCompras._TipoDocumento
        Get
            Return TipoDocumentoCompra.OrdenCompra
        End Get
    End Property
End Class