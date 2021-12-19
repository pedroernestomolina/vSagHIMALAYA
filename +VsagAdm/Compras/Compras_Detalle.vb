Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Compras_Detalle
    Dim f_compras As FichaCompras.c_Compra
    Dim xautodoc As String
    Dim xdata As DataTable
    Dim xbs_data As BindingSource
    Dim xtb_descuentos As DataTable
    Dim xactivar_precios_venta As Boolean

    Property _AutoDoc() As String
        Get
            Return xautodoc.Trim
        End Get
        Set(ByVal value As String)
            xautodoc = value
        End Set
    End Property

    Property _ActivarModificar_PreciosVentas() As Boolean
        Get
            Return xactivar_precios_venta
        End Get
        Set(ByVal value As Boolean)
            xactivar_precios_venta = value
        End Set
    End Property

    Sub New(ByVal xauto As String, Optional ByVal xmodificar_precios_ventas As Boolean = False)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _AutoDoc = xauto
        xdata = New DataTable
        _ActivarModificar_PreciosVentas = xmodificar_precios_ventas
    End Sub

    Sub Inicializa()
        Try
            Me.E_CFINAL.Text = "0.0"
            Me.E_PROMO.Text = "0.0"
            Me.E_CINVFINAL.Text = "0.0"

            Dim xsql As String = "select codigo x1, nombre x2, cantidad x3, empaque x4,contenido_empaque x5, costo_bruto x6,(descuento1+descuento2+descuento3) x7,tasa x8,total_neto x9, " & _
                                    "auto xa, decimales xb, detalle xc, * from compras_detalle where auto_documento=@auto"

            Dim xp1 As New SqlParameter("@auto", _AutoDoc)
            Dim xp2 As New SqlParameter("@auto", _AutoDoc)

            f_compras = New FichaCompras.c_Compra
            f_compras.F_CargarCompra(_AutoDoc)
            g_MiData.F_GetData(xsql, xdata, xp1)
            xbs_data = New BindingSource(xdata, "")

            xtb_descuentos = New DataTable
            With xtb_descuentos
                .Columns.Add("desc", GetType(String))
                .Columns.Add("tasa", GetType(Decimal))
            End With

            MostrarDoc()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Ventas_Detalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Form2_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub MostrarDoc()
        Dim xtb As New DataTable
        With xtb
            .Columns.Add("col0", GetType(String))
            .Columns.Add("col1", GetType(Decimal))
            .Columns.Add("col2", GetType(Decimal))
            .Columns.Add("col3", GetType(Decimal))
        End With

        Dim xrow As DataRow = xtb.NewRow
        xrow("col0") = "Exento"
        xrow("col1") = f_compras.RegistroDato._MontoExento
        xrow("col2") = 0
        xrow("col3") = 0
        xtb.Rows.Add(xrow)

        xrow = xtb.NewRow
        xrow("col0") = "Base 1"
        xrow("col1") = f_compras.RegistroDato._BaseImpuestoTasa1._Base
        xrow("col2") = f_compras.RegistroDato._BaseImpuestoTasa1._Tasa
        xrow("col3") = f_compras.RegistroDato._BaseImpuestoTasa1._Impuesto
        xtb.Rows.Add(xrow)

        xrow = xtb.NewRow
        xrow("col0") = "Base 2"
        xrow("col1") = f_compras.RegistroDato._BaseImpuestoTasa2._Base
        xrow("col2") = f_compras.RegistroDato._BaseImpuestoTasa2._Tasa
        xrow("col3") = f_compras.RegistroDato._BaseImpuestoTasa2._Impuesto
        xtb.Rows.Add(xrow)

        xrow = xtb.NewRow
        xrow("col0") = "Base 3"
        xrow("col1") = f_compras.RegistroDato._BaseImpuestoTasa3._Base
        xrow("col2") = f_compras.RegistroDato._BaseImpuestoTasa3._Tasa
        xrow("col3") = f_compras.RegistroDato._BaseImpuestoTasa3._Impuesto
        xtb.Rows.Add(xrow)

        Me.E_DOCUMENTO.Text = f_compras.RegistroDato._NumeroDocumentoCompra
        Me.E_CONTROL.Text = f_compras.RegistroDato._NumeroControlDocumento
        Me.E_TIPO_DOC.Text = RetornarTipoDocumentoString(f_compras.RegistroDato._TipoDocumentoCompra)

        Me.E_FECHA_EMISION.Text = f_compras.RegistroDato._FechaEmision
        Me.E_FECHA_VENCE.Text = f_compras.RegistroDato._FechaVencimiento

        Me.E_CODIGO.Text = f_compras.RegistroDato._CodigoProveedor
        Me.E_DIRFISCAL.Text = f_compras.RegistroDato._DirFiscalProveedor
        Me.E_NOMBRE.Text = f_compras.RegistroDato._NombreProveedor
        Me.E_RIF.Text = f_compras.RegistroDato._CiRifProveedor

        Me.Label6.Text = "Descuento(" + String.Format("{0:#0.00}", f_compras.RegistroDato._Descuento1._Tasa).Trim + "%):"
        Me.Label7.Text = "   Cargos(" + String.Format("{0:#0.00}", f_compras.RegistroDato._Cargos._Tasa).Trim + "%):"

        Me.E_SUB_1.Text = String.Format("{0:#0.00}", f_compras.RegistroDato._MontoSubtotal)
        Me.E_DESCTO.Text = String.Format("{0:#0.00}", f_compras.RegistroDato._Descuento1._Valor)
        Me.E_CARGO.Text = String.Format("{0:#0.00}", f_compras.RegistroDato._Cargos._Valor)

        Me.E_SUB2.Text = String.Format("{0:#0.00}", f_compras.RegistroDato._MontoSubtotal - f_compras.RegistroDato._Descuento1._Valor + f_compras.RegistroDato._Cargos._Valor)
        Me.E_IVA.Text = String.Format("{0:#0.00}", f_compras.RegistroDato._MontoTotalImpuesto)
        Me.E_LISAYEA.Text = String.Format("{0:#0.00}", f_compras.RegistroDato._MontoImpuestoLicor)
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", f_compras.RegistroDato._TotalGeneral)

        Me.E_NOTAS.Text = f_compras.RegistroDato._NotasDetalleCompra
        Me.Text = "Documento De " + RetornarTipoDocumentoString(f_compras.RegistroDato._TipoDocumentoCompra)
        Me.E_APLICA.Text = f_compras.RegistroDato._DocumentoAplica

        If f_compras.RegistroDato._EstatusCompra = TipoEstatus.Activo Then
            E_ESTATUS.Text = "ACTIVO"
            E_ESTATUS.ForeColor = Color.Blue
        Else
            E_ESTATUS.Text = "INACTIVO"
            E_ESTATUS.ForeColor = Color.Red
        End If

        With (Me.MisGrid3)
            .Columns.Add("col0", "Descripción")
            .Columns.Add("col1", "Tasa")
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).Width = 90
            .DataSource = xtb_descuentos
            .Columns(0).DataPropertyName = "desc"
            .Columns(1).DataPropertyName = "tasa"
            .Ocultar(3)
        End With

        With (Me.MisGrid2)
            .Columns.Add("col0", "Código")
            .Columns.Add("col1", "Producto")
            .Columns.Add("col2", "Cantidad")
            .Columns.Add("col3", "Empq")
            .Columns.Add("col4", "Und")
            .Columns.Add("col5", "P/Neto")
            .Columns.Add("col6", "Dscto(Bs)")
            .Columns.Add("col7", "Iva%")
            .Columns.Add("col8", "Importe")

            .Columns(0).Width = 100
            .Columns(2).Width = 90
            .Columns(3).Width = 100
            .Columns(4).Width = 60
            .Columns(5).Width = 90
            .Columns(6).Width = 70
            .Columns(7).Width = 70
            .Columns(8).Width = 90
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xbs_data

            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(2).DataPropertyName = "x3"
            .Columns(3).DataPropertyName = "x4"
            .Columns(4).DataPropertyName = "x5"
            .Columns(5).DataPropertyName = "x6"
            .Columns(6).DataPropertyName = "x7"
            .Columns(7).DataPropertyName = "x8"
            .Columns(8).DataPropertyName = "x9"

            .Ocultar(10)
            AddHandler .CellFormatting, AddressOf MiFormato
        End With

        AddHandler xbs_data.PositionChanged, AddressOf ActualizarDataItem
        ActualizaDataItem()

        With (Me.MisGrid1)
            .Columns.Add("col0", "Concepto")
            .Columns.Add("col1", "Base")
            .Columns.Add("col2", "Tasa")
            .Columns.Add("col3", "Iva")

            .DataSource = xtb

            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).Width = 80
            .Columns(2).Width = 60
            .Columns(3).Width = 80

            .Columns(0).DataPropertyName = "col0"
            .Columns(1).DataPropertyName = "col1"
            .Columns(2).DataPropertyName = "col2"
            .Columns(3).DataPropertyName = "col3"

            .Ocultar(5)
            AddHandler .CellFormatting, AddressOf MiFormato2
        End With
        Me.E_Items.Text = xdata.Rows.Count.ToString()
    End Sub

    Sub ActualizarDataItem()
        ActualizaDataItem()
    End Sub

    Sub ActualizaDataItem()
        If xbs_data.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs_data.Current, DataRowView).Row
            Dim xdetcompra As New FichaCompras.c_ComprasDetalle.c_Registro
            xdetcompra.M_CargarData(xr)
            Me.E_CINVFINAL.Text = String.Format("{0:#0.00}", xdetcompra._CostoInventario)
            Me.E_CFINAL.Text = String.Format("{0:#0.00}", xdetcompra._Costofinal)
            Me.E_PROMO.Text = String.Format("{0:#0.00}", xdetcompra._Bono)
            Me.E_IMP_LICOR.Text = String.Format("{0:#0.00}", xdetcompra._MontoImpuestoLicor)

            xtb_descuentos.Rows.Clear()
            Dim xrw As DataRow = xtb_descuentos.NewRow
            xrw(0) = "Descuento 1"
            xrw(1) = xdetcompra._Descuento1._Tasa
            xtb_descuentos.Rows.Add(xrw)

            xrw = xtb_descuentos.NewRow
            xrw(0) = "Descuento 2"
            xrw(1) = xdetcompra._Descuento2._Tasa
            xtb_descuentos.Rows.Add(xrw)

            xrw = xtb_descuentos.NewRow
            xrw(0) = "Descuento 3"
            xrw(1) = xdetcompra._Descuento3._Tasa
            xtb_descuentos.Rows.Add(xrw)
        Else
            Me.E_CINVFINAL.Text = String.Format("{0:#0.00}", 0.0)
            Me.E_CFINAL.Text = String.Format("{0:#0.00}", 0.0)
            Me.E_PROMO.Text = String.Format("{0:#0.00}", 0.0)
            Me.E_IMP_LICOR.Text = String.Format("{0:#0.00}", 0.0)
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 2 Then
            If e.ColumnIndex = 3 Then
            Else
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
            End If

            If e.ColumnIndex = 2 Then
                Dim xformato As String = "#0.000"
                Dim xd As String = MisGrid2.Rows(e.RowIndex).Cells("decimales").Value.ToString
                Dim xv As Integer = 0
                Integer.TryParse(xd, xv)
                If xv > 0 Then
                    xv += 1
                End If
                e.CellStyle.Format = xformato.Substring(0, 2 + xv)
            End If
        End If
    End Sub

    Sub MiFormato2(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 1 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Function RetornarTipoDocumentoString(ByVal xtipo As Integer) As String
        Select Case xtipo
            Case 1 : Return "Compra"
            Case 2 : Return "Nota Débito"
            Case 3 : Return "Nota Crédito"
            Case 4 : Return "Orden Compra"
            Case Else : Return ""
        End Select
    End Function

    Private Sub MisGrid2_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid2.Accion
        If xbs_data.Current IsNot Nothing Then
            If _ActivarModificar_PreciosVentas Then
                Try
                    Dim xrw As DataRow = CType(xbs_data.Current, DataRowView).Row
                    Dim xcdet As New FichaCompras.c_ComprasDetalle
                    xcdet.RegistroDato.M_CargarData(xrw)

                    Dim xprd As New FichaProducto
                    xprd.f_PrdProducto.F_BuscarProducto(xcdet.RegistroDato._AutoProducto)

                    Dim xficha As New ActualizarPrecios(xprd, New ActualizarPrecio_Compra)
                    With xficha
                        .ShowDialog()
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                Dim xficha As New MostrarDetalle(xbs_data.Current("detalle"))
                xficha.ShowDialog()
            End If
        End If
    End Sub

    Private Sub Compras_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class