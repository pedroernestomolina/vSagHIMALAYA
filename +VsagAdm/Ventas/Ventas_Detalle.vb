Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Ventas_Detalle
    Dim f_ventas As FichaVentas.V_Ventas
    Dim xautodoc As String
    Dim xdata As DataTable
    Dim xbs_data As BindingSource

    Property _AutoDoc() As String
        Get
            Return xautodoc.Trim
        End Get
        Set(ByVal value As String)
            xautodoc = value
        End Set
    End Property

    Sub New(ByVal xauto As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _AutoDoc = xauto
        xdata = New DataTable
    End Sub

    Sub Inicializa()
        Try
            Dim xsql As String = "select codigo, nombre, cantidad, empaque,contenido_empaque, precio_neto,descuento1p,tasa,total_neto, " & _
                                    "auto,decimales,detalle from ventas_detalle where auto_documento=@auto"
            Dim xp1 As New SqlParameter("@auto", _AutoDoc)

            f_ventas = New FichaVentas.V_Ventas
            f_ventas.F_BuscarDocumento(_AutoDoc)
            g_MiData.F_GetData(xsql, xdata, xp1)
            xbs_data = New BindingSource(xdata, "")

            MostrarDoc()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
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
        xrow("col1") = f_ventas.RegistroDato._MontoExento
        xrow("col2") = 0
        xrow("col3") = 0
        xtb.Rows.Add(xrow)

        xrow = xtb.NewRow
        xrow("col0") = "Base 1"
        xrow("col1") = f_ventas.RegistroDato._MontoBase_1
        xrow("col2") = f_ventas.RegistroDato._TasaIva_1
        xrow("col3") = f_ventas.RegistroDato._MontoImpuesto_1
        xtb.Rows.Add(xrow)

        xrow = xtb.NewRow
        xrow("col0") = "Base 2"
        xrow("col1") = f_ventas.RegistroDato._MontoBase_2
        xrow("col2") = f_ventas.RegistroDato._TasaIva_2
        xrow("col3") = f_ventas.RegistroDato._MontoImpuesto_2
        xtb.Rows.Add(xrow)

        xrow = xtb.NewRow
        xrow("col0") = "Base 3"
        xrow("col1") = f_ventas.RegistroDato._MontoBase_3
        xrow("col2") = f_ventas.RegistroDato._TasaIva_3
        xrow("col3") = f_ventas.RegistroDato._MontoImpuesto_3
        xtb.Rows.Add(xrow)

        Me.E_DOCUMENTO.Text = f_ventas.RegistroDato._Documento
        Me.E_CONTROL.Text = f_ventas.RegistroDato._NumeroControlFiscal
        Me.E_NOM_VENDEDOR.Text = f_ventas.RegistroDato._NombreVendedor
        Me.E_TIPO_DOC.Text = f_ventas.RegistroDato._TipoDocumento.ToString

        Me.E_FECHA_EMISION.Text = f_ventas.RegistroDato._FechaEmision
        Me.E_FECHA_VENCE.Text = f_ventas.RegistroDato._FechaVencimiento
        Me.E_COND_PAGO.Text = f_ventas.RegistroDato._CondicionPago.ToString
        Me.E_VALIDO_POR.Text = f_ventas.RegistroDato._DiasValidezDocumento.ToString + " Dias"

        Me.E_CLI_CODIGO.Text = f_ventas.RegistroDato._CodigoCliente
        Me.E_CLI_DIRFISCAL.Text = f_ventas.RegistroDato._DirFiscalCliente
        Me.E_CLI_NOMBRE.Text = f_ventas.RegistroDato._NombreCliente
        Me.E_CLI_RIF.Text = f_ventas.RegistroDato._CiRifCliente

        Me.Label6.Text = "Descuento(" + String.Format("{0:#0.00}", f_ventas.RegistroDato._TasaDescuento_1).Trim + "%):"
        Me.Label7.Text = "   Cargos(" + String.Format("{0:#0.00}", f_ventas.RegistroDato._TasaCargos).Trim + "%):"

        Me.E_SUB_1.Text = String.Format("{0:#0.00}", f_ventas.RegistroDato._MontoSubtotal)
        Me.E_DESCTO.Text = String.Format("{0:#0.00}", f_ventas.RegistroDato._MontoDescuento_1)
        Me.E_CARGO.Text = String.Format("{0:#0.00}", f_ventas.RegistroDato._MontoCargos)

        Me.E_SUB2.Text = String.Format("{0:#0.00}", f_ventas.RegistroDato._MontoSubTotal_DespuesDescuentoCargosGlobales)
        Me.E_IVA.Text = String.Format("{0:#0.00}", f_ventas.RegistroDato._MontoTotalImpuesto)
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", f_ventas.RegistroDato._TotalGenereal)

        Me.E_NOTAS.Text = f_ventas.RegistroDato._NotasDocumento
        Me.Text = "Documento De " + RetornarTipoDocumentoString(f_ventas.RegistroDato._TipoDocumento)
        Me.E_APLICA.Text = f_ventas.RegistroDato._DocumentoAplica

        With (Me.MisGrid2)
            .Columns.Add("col0", "Código")
            .Columns.Add("col1", "Producto")
            .Columns.Add("col2", "Cantidad")
            .Columns.Add("col3", "Empq")
            .Columns.Add("col4", "Und")
            .Columns.Add("col5", "P/Neto")
            .Columns.Add("col6", "Dscto%")
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

            .Columns(0).DataPropertyName = "codigo"
            .Columns(1).DataPropertyName = "nombre"
            .Columns(2).DataPropertyName = "cantidad"
            .Columns(3).DataPropertyName = "empaque"
            .Columns(4).DataPropertyName = "contenido_empaque"
            .Columns(5).DataPropertyName = "precio_neto"
            .Columns(6).DataPropertyName = "descuento1p"
            .Columns(7).DataPropertyName = "tasa"
            .Columns(8).DataPropertyName = "total_neto"

            .Ocultar(10)
            AddHandler .CellFormatting, AddressOf MiFormato
        End With

        With (Me.MisGrid1)
            .Columns.Add("col0", "Concepto")
            .Columns.Add("col1", "Base")
            .Columns.Add("col2", "Tasa")
            .Columns.Add("col3", "Iva")

            .DataSource = xtb

            .Columns(1).Width = 90
            .Columns(2).Width = 50
            .Columns(3).Width = 90
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Columns(0).DataPropertyName = "col0"
            .Columns(1).DataPropertyName = "col1"
            .Columns(2).DataPropertyName = "col2"
            .Columns(3).DataPropertyName = "col3"

            .Ocultar(5)
            AddHandler .CellFormatting, AddressOf MiFormato2
        End With
        Me.E_Items.Text = xdata.Rows.Count.ToString()
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
            Case 1 : Return "Venta"
            Case 2 : Return "Nota Débito"
            Case 3 : Return "Nota Crédito"
            Case 4 : Return "Nota Entrega"
            Case 5 : Return "Presupuesto"
            Case 6 : Return "Pedido"
            Case Else : Return ""
        End Select
    End Function

    Private Sub Ventas_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub MisGrid2_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid2.Accion
        If xbs_data.Current IsNot Nothing Then
            Dim xficha As New MostrarDetalle(xbs_data.Current("detalle"))
            xficha.ShowDialog()
        End If
    End Sub
End Class