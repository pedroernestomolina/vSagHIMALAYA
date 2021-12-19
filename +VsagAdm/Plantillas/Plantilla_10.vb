Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema

Public Class Plantilla_10
    ''' <summary>
    ''' Clase Ficha Documento Usada Para El Control De Totales En Pantalla
    ''' </summary>
    Class FichaDoc
        Event FichaEnCero()

        Private xRegistrosTabla As Integer

        Private xlineas As Integer
        Private xitems As Integer
        Private xkilos As Single
        Private xtotal_1 As Decimal
        Private xsubtotal_1 As Decimal
        Private xneto1_1 As Decimal
        Private xneto2_1 As Decimal
        Private xneto3_1 As Decimal
        Private xexento_1 As Decimal
        Private xiva1_1 As Decimal
        Private xiva2_1 As Decimal
        Private xiva3_1 As Decimal
        Private xtasa1 As Decimal
        Private xtasa2 As Decimal
        Private xtasa3 As Decimal
        Private xtotalneto_1 As Decimal
        Private xtotaliva_1 As Decimal
        Private xnotas As String

        Private xchimbo As Boolean

        Private xtabla As DataTable

        Property _RegistrosEnTabla() As Integer
            Get
                Return xRegistrosTabla
            End Get
            Set(ByVal value As Integer)
                xRegistrosTabla = value
                If value = 0 Then
                    Me._Exento_1 = 0
                    Me._Items = 0
                    Me._Kilos = 0
                    Me._Lineas = 0
                    Me._Neto1_1 = 0
                    Me._Neto2_1 = 0
                    Me._Neto3_1 = 0

                    Me._DocChimbo = False
                    RaiseEvent FichaEnCero()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Retorna el numero de lineas facturadas
        ''' </summary>
        Property _Lineas() As Integer
            Get
                Return xlineas
            End Get
            Set(ByVal value As Integer)
                xlineas = value
            End Set
        End Property

        ''' <summary>
        ''' Retorna la cantidad total de items facturados
        ''' </summary>
        Property _Items() As Integer
            Get
                Return xitems
            End Get
            Set(ByVal value As Integer)
                xitems = value
            End Set
        End Property

        ''' <summary>
        ''' Retorna la cantidad de kilos facturados
        ''' </summary>
        Property _Kilos() As Single
            Get
                Return xkilos
            End Get
            Set(ByVal value As Single)
                xkilos = value
            End Set
        End Property

        ''' <summary>
        ''' Retorna La Tasa Impuesto #1
        ''' </summary>
        Property _TasaIva1() As Decimal
            Get
                Return xtasa1
            End Get
            Set(ByVal value As Decimal)
                xtasa1 = value
            End Set
        End Property

        ''' <summary>
        ''' Retorna La Tasa Impuesto #2
        ''' </summary>
        Property _TasaIva2() As Decimal
            Get
                Return xtasa2
            End Get
            Set(ByVal value As Decimal)
                xtasa2 = value
            End Set
        End Property

        ''' <summary>
        ''' Retorna La Tasa Impuesto #3
        ''' </summary>
        Property _TasaIva3() As Decimal
            Get
                Return xtasa3
            End Get
            Set(ByVal value As Decimal)
                xtasa3 = value
            End Set
        End Property

        ''' <summary>
        ''' Retorna Exento, antes de los descuentos o cargos globales
        ''' </summary>
        Property _Exento_1() As Decimal
            Get
                Return Decimal.Round(xexento_1, 2, MidpointRounding.AwayFromZero)
            End Get
            Set(ByVal value As Decimal)
                xexento_1 = value
            End Set
        End Property

        ''' <summary>
        ''' Retorna Neto/Base #1, antes de los descuentos o cargos globales
        ''' </summary>
        Property _Neto1_1() As Decimal
            Get
                Return Decimal.Round(xneto1_1, 2, MidpointRounding.AwayFromZero)
            End Get
            Set(ByVal value As Decimal)
                xneto1_1 = value
                xiva1_1 = value * (Me._TasaIva1 / 100)
            End Set
        End Property

        ''' <summary>
        ''' Retorna Impuesto #1, antes de los descuentos o cargos globales
        ''' </summary>
        ReadOnly Property _Iva1_1() As Decimal
            Get
                Return Decimal.Round(xiva1_1, 2, MidpointRounding.AwayFromZero)
            End Get
        End Property

        ''' <summary>
        ''' Retorna Neto/Base #2, antes de los descuentos o cargos globales
        ''' </summary>
        Property _Neto2_1() As Decimal
            Get
                Return Decimal.Round(xneto2_1, 2, MidpointRounding.AwayFromZero)
            End Get
            Set(ByVal value As Decimal)
                xneto2_1 = value
                xiva2_1 = value * (Me._TasaIva2 / 100)
            End Set
        End Property

        ''' <summary>
        ''' Retorna Impuesto #2, antes de los descuentos o cargos globales
        ''' </summary>
        ReadOnly Property _Iva2_1() As Decimal
            Get
                Return Decimal.Round(xiva2_1, 2, MidpointRounding.AwayFromZero)
            End Get
        End Property

        ''' <summary>
        ''' Retorna Neto/Base #3, antes de los descuentos o cargos globales
        ''' </summary>
        Property _Neto3_1() As Decimal
            Get
                Return Decimal.Round(xneto3_1, 2, MidpointRounding.AwayFromZero)
            End Get
            Set(ByVal value As Decimal)
                xneto3_1 = value
                xiva3_1 = value * (Me._TasaIva3 / 100)
            End Set
        End Property

        ''' <summary>
        ''' Retorna Impuesto #3, antes de los descuentos o cargos globales
        ''' </summary>
        ReadOnly Property _Iva3_1() As Decimal
            Get
                Return Decimal.Round(xiva3_1, 2, MidpointRounding.AwayFromZero)
            End Get
        End Property

        ''' <summary>
        ''' Retorna Subtotal, antes de los descuentos o cargos globales
        ''' </summary>
        ReadOnly Property _Subtotal_1() As Decimal
            Get
                Dim xsubt As Decimal = (Me._Exento_1 + Me._Neto1_1 + Me._Neto2_1 + Me._Neto3_1)
                Return Decimal.Round(xsubt, 2, MidpointRounding.AwayFromZero)
            End Get
        End Property

        ''' <summary>
        ''' Retorna Subtotal Solo Bases, antes de los descuentos o cargos globales
        ''' </summary>
        ReadOnly Property _SubtotalNeto_1() As Decimal
            Get
                Dim xsubt As Decimal = (Me._Neto1_1 + Me._Neto2_1 + Me._Neto3_1)
                Return Decimal.Round(xsubt, 2, MidpointRounding.AwayFromZero)
            End Get
        End Property

        ''' <summary>
        ''' Retorna Subtotal Solo Iva, antes de los descuentos o cargos globales
        ''' </summary>
        ReadOnly Property _SubtotalIva_1() As Decimal
            Get
                Dim xsubt As Decimal = (Me._Iva1_1 + Me._Iva2_1 + Me._Iva3_1)
                Return Decimal.Round(xsubt, 2, MidpointRounding.AwayFromZero)
            End Get
        End Property

        ''' <summary>
        ''' Retorna Notas / Inf adicional del documento
        ''' </summary>
        Property _NotasDocumento() As String
            Get
                Return xnotas
            End Get
            Set(ByVal value As String)
                xnotas = value
            End Set
        End Property

        ''' <summary>
        ''' Retorna Total, antes de los descuentos y cargos globales
        ''' </summary>
        ReadOnly Property _Total_1() As Decimal
            Get
                Dim xsubtn As Decimal = (Me._Exento_1 + Me._Neto1_1 + Me._Neto2_1 + Me._Neto3_1)
                Dim xsubti As Decimal = (Me._Iva1_1 + Me._Iva2_1 + Me._Iva3_1)
                Dim xtot As Decimal = xsubtn + xsubti
                Return Decimal.Round(xtot, 2, MidpointRounding.AwayFromZero)
            End Get
        End Property

        Property _TablaData() As DataTable
            Get
                Return xtabla
            End Get
            Set(ByVal value As DataTable)
                xtabla = value
            End Set
        End Property

        Property _DocChimbo() As Boolean
            Get
                Return xchimbo
            End Get
            Set(ByVal value As Boolean)
                xchimbo = value
            End Set
        End Property

        Sub New()
            Me._RegistrosEnTabla = 0

            Me._Exento_1 = 0
            Me._Items = 0
            Me._Kilos = 0
            Me._Lineas = 0
            Me._Neto1_1 = 0
            Me._Neto2_1 = 0
            Me._Neto3_1 = 0
            Me._NotasDocumento = ""
            Me._TasaIva1 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaIva_1.c_Valor
            Me._TasaIva2 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaIva_2.c_Valor
            Me._TasaIva3 = g_MiData.f_FichaGlobal.f_Fiscal.RegistroDato.c_TasaIva_3.c_Valor

            Me._DocChimbo = False

            Me._TablaData = New DataTable
            AddHandler Me._TablaData.RowChanging, AddressOf ActualizarDatos
        End Sub

        Sub ActualizarDatos(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
            Me._Lineas = 0
            Me._Kilos = 0
            Me._Items = 0
            Me._Neto1_1 = 0
            Me._Neto2_1 = 0
            Me._Neto3_1 = 0
            Me._Exento_1 = 0

            If Me._TablaData.Rows.Count >= Me._RegistrosEnTabla Then
                Dim xfichatemp As New FichaVentas.V_VentasDetalle.c_Registro
                For Each xrow As DataRow In Me._TablaData.Rows
                    xfichatemp.M_CargarFicha(xrow)
                    If xrow("x8") = 1 Then
                        Dim x1 As Decimal = Decimal.Round(((xrow(2) * xrow(3)) - (xrow(2) * xrow(3) * xrow(4) / 100)), 2, MidpointRounding.AwayFromZero)
                        If xrow("x9") = "D" Then
                            Select Case xfichatemp._TipoTasaIva
                                Case "0"
                                    Me._Exento_1 += x1
                                Case "1"
                                    Me._Neto1_1 += x1
                                Case "2"
                                    Me._Neto2_1 += x1
                                Case "3"
                                    Me._Neto3_1 += x1
                            End Select
                        Else
                            Dim x2 As Decimal = 0
                            If xrow("cantidad") = xrow(2) Then 'AJUSTE POR PRECIO
                                x2 = Decimal.Round((xrow("total_neto") - x1), 2, MidpointRounding.AwayFromZero)
                            Else 'AJUSTE POR CANTIDAD
                                x2 = Decimal.Round(xrow("total_neto") - (x1 + (xrow("precio_item") * (xrow("cantidad") - xrow(2)))), 2, MidpointRounding.AwayFromZero)
                            End If
                            Select Case xfichatemp._TipoTasaIva
                                Case "0"
                                    Me._Exento_1 += x2
                                Case "1"
                                    Me._Neto1_1 += x2
                                Case "2"
                                    Me._Neto2_1 += x2
                                Case "3"
                                    Me._Neto3_1 += x2
                            End Select
                        End If

                        If xfichatemp._PTO_EsPesado Then
                            Me._Kilos += xrow(2)
                            Me._Items += 1
                        Else
                            Me._Items += xrow(2)
                        End If
                        Me._Lineas += 1
                    End If
                Next
            End If

            RaiseEvent FichaEnCero()
        End Sub
    End Class

    Dim pb_tm As Size
    Dim xdocumento As IPlantilla_10
    Dim xfichdocumento As FichaDoc
    Dim xbs_tabladata As BindingSource
    Dim xtotales As TotalesDoc

    Dim xfichaprd As FichaProducto.Prd_Producto
    Dim xfichacli As FichaClientes
    Dim xfichatem As FichaVentas.V_VentasDetalle
    Dim xfichaventa As FichaVentas

    ''' <summary>
    ''' Refleja Los Totales De La Pantalla
    ''' </summary>
    Property _MiFichaDoc() As FichaDoc
        Get
            Return xfichdocumento
        End Get
        Set(ByVal value As FichaDoc)
            xfichdocumento = value
        End Set
    End Property

    ''' <summary>
    ''' Refleja El Tipo De Documento en Proceso
    ''' </summary>
    Property _MiPlantilla() As IPlantilla_10
        Get
            Return xdocumento
        End Get
        Set(ByVal value As IPlantilla_10)
            xdocumento = value
        End Set
    End Property

    Sub New(ByVal xtipoplantilla As IPlantilla_10)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        xfichaventa = New FichaVentas
        xfichacli = New FichaClientes
        _MiPlantilla = xtipoplantilla
        AddHandler _MiPlantilla._EventoExitoso, AddressOf LimpiarFicha
    End Sub

    Sub LimpiarFicha()
        xfichacli.f_Clientes.RegistroDato.M_LimpiarRegistro()
        xfichaventa.F_Venta.RegistroDato.M_LimpiarRegistro()
        _MiFichaDoc._RegistrosEnTabla = 0
        _MiFichaDoc._TablaData.Rows.Clear()

        Me.Text = "Datos Del Usuario: " + g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario + ", Grupo: " + g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreGrupo
        Me.E_TITULO.Text = _MiPlantilla.TipoDocumento._Nombre

        Me.E_CLI_CODIGO.Text = xfichacli.f_Clientes.RegistroDato.r_CodigoCliente
        Me.E_CLI_NOMBRE.Text = xfichacli.f_Clientes.RegistroDato.r_NombreRazonSocial
        Me.E_CLI_RIF.Text = xfichacli.f_Clientes.RegistroDato.r_CiRif

        Me.E_ITEMS.Text = _MiFichaDoc._Items.ToString
        Me.E_KILOS.Text = String.Format("{0:#0.000}", _MiFichaDoc._Kilos)
        Me.E_LINEAS.Text = _MiFichaDoc._Items.ToString
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Total_1)
        Me.E_SUBTOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Subtotal_1)
        Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", _MiFichaDoc._SubtotalIva_1)
        Me.E_DOC_PENDIENTES.Text = "0"

        Me.E_DOCUMENTO.Text = ""
        Me.E_FECHA.Text = ""
        Me.E_PAGO.Text = ""

        IrInicio()
    End Sub

    Private Sub PB_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_3.MouseEnter, _
                PB_5.MouseEnter, PB_6.MouseEnter, PB_7.MouseEnter, PB_8.MouseEnter, PB_9.MouseEnter, PB_10.MouseEnter, PB_11.MouseEnter

        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_3.MouseHover, _
                PB_5.MouseHover, PB_6.MouseHover, PB_7.MouseHover, PB_8.MouseHover, PB_9.MouseHover, PB_10.MouseHover, PB_11.MouseHover

        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_3.MouseLeave, _
                PB_5.MouseLeave, PB_6.MouseLeave, PB_7.MouseLeave, PB_8.MouseLeave, PB_9.MouseLeave, PB_10.MouseLeave, PB_11.MouseLeave

        EntrarSalirPB(sender, EntradaSalida.Salida)
    End Sub

    Sub EntrarSalirPB(ByVal sender As Object, ByVal xtipo As EntradaSalida)
        Dim PB As PictureBox = CType(sender, PictureBox)
        Dim factor As Integer = 0
        If xtipo = EntradaSalida.Entrada Then
            factor = -5
        End If

        With PB
            .Size = New Size(pb_tm.Width + factor, pb_tm.Height + factor)
            .Cursor = Cursors.Hand
        End With
    End Sub

    Private Sub Plantilla_10_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _MiFichaDoc._Total_1 = 0 And _MiFichaDoc._Items = 0 And _MiFichaDoc._TablaData.Rows.Count = 0 Then
            e.Cancel = False
        Else
            EliminarTodosLosItems()
            e.Cancel = True
        End If
    End Sub

    Sub EliminarTodosLosItems()
        If (_MiFichaDoc._Lineas > 0 And _MiFichaDoc._Total_1 > 0) Or _MiFichaDoc._TablaData.Rows.Count > 0 Then
            If MessageBox.Show("Estas Segur De Querer Eliminar Todos Los Item Procesados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Me._MiFichaDoc._RegistrosEnTabla = 0
                    Me._MiFichaDoc._TablaData.Rows.Clear()
                    xfichacli.f_Clientes.RegistroDato.M_LimpiarRegistro()
                    CargarFichaCliente(xfichacli.f_Clientes.RegistroDato.r_Automatico)

                    MessageBox.Show("Items Eliminados Satisfactoriamente... Ok", "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
        Me.IrInicio()
    End Sub

    Private Sub Plantilla_10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False And e.Control = False) Then
            ModificarItem()
        End If
        If e.KeyCode = Keys.F7 AndAlso (e.Alt = False And e.Control = False) Then
            NotasDetallesItem()
        End If
        If e.KeyCode = Keys.Delete AndAlso (e.Alt = False And e.Control = False) Then
            EliminarItem()
        End If
        If e.KeyCode = Keys.F8 AndAlso (e.Alt = False And e.Control = False) Then
            Procesar()
        End If
        If e.KeyCode = Keys.F10 AndAlso (e.Alt = False And e.Control = False) Then
            AdmDocumentos()
        End If
        If e.KeyCode = Keys.D2 AndAlso (e.Alt = True And e.Control = False) Then
            ControlClientes()
        End If
    End Sub

    Private Sub Plantilla_10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_tm = PB_3.Size
    End Sub

    Private Sub Plantilla_10_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            xfichatem = New FichaVentas.V_VentasDetalle
            xfichaprd = New FichaProducto.Prd_Producto
            xfichacli = New FichaClientes

            _MiFichaDoc = New FichaDoc
            AddHandler _MiFichaDoc.FichaEnCero, AddressOf CargarTabla

            xbs_tabladata = New BindingSource(_MiFichaDoc._TablaData, "")
            AddHandler xbs_tabladata.PositionChanged, AddressOf ActualizarVistaItem
            ActualizaVistaItem()

            InicializarPantalla()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub IrInicio()
        Me.Select()
    End Sub

    Sub InicializarPantalla()
        IrInicio()
        Me.Text = "Datos Del Usuario: " + g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario + ", Grupo: " + g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreGrupo
        Me.E_TITULO.Text = _MiPlantilla.TipoDocumento._Nombre

        Me.E_CLI_CODIGO.Text = xfichacli.f_Clientes.RegistroDato.r_CodigoCliente
        Me.E_CLI_NOMBRE.Text = xfichacli.f_Clientes.RegistroDato.r_NombreRazonSocial
        Me.E_CLI_RIF.Text = xfichacli.f_Clientes.RegistroDato.r_CiRif

        Me.E_ITEMS.Text = _MiFichaDoc._Items.ToString
        Me.E_KILOS.Text = String.Format("{0:#0.000}", _MiFichaDoc._Kilos)
        Me.E_LINEAS.Text = _MiFichaDoc._Items.ToString
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Total_1)
        Me.E_SUBTOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Subtotal_1)
        Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", _MiFichaDoc._SubtotalIva_1)
        Me.E_DOC_PENDIENTES.Text = "0"

        Me.E_DOCUMENTO.Text = ""
        Me.E_FECHA.Text = ""
        Me.E_PAGO.Text = ""

        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 500
            .UseFading = True
            .ShowAlways = True
        End With

        Dim xcol As New DataGridViewCheckBoxColumn
        xcol.HeaderText = "*"
        With MisGrid1
            .Columns.Add("col0", "Codigo")
            .Columns.Add("col1", "Descripcion")
            .Columns.Add("col2", "Cant")
            .Columns.Add("col3", "P/Neto")
            .Columns.Add("col4", "Dto %")
            .Columns.Add("col5", "Iva %")
            .Columns.Add("col6", "Importe")
            .Columns.Add(xcol)
            .Columns.Add("col8", "T")


            .Columns(0).Width = 80
            .Columns(2).Width = 80
            .Columns(3).Width = 80
            .Columns(4).Width = 70
            .Columns(5).Width = 70
            .Columns(6).Width = 100
            .Columns(7).Width = 20
            .Columns(8).Width = 30
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            CargarData("")

            .DataSource = xbs_tabladata
            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(2).DataPropertyName = "x3"
            .Columns(3).DataPropertyName = "x4"
            .Columns(4).DataPropertyName = "x5"
            .Columns(5).DataPropertyName = "x6"
            .Columns(6).DataPropertyName = "x7"
            .Columns(7).DataPropertyName = "x8"
            .Columns(8).DataPropertyName = "x9"
            AddHandler .CellFormatting, AddressOf MiFormato

            .Ocultar(10)
        End With
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 2 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight

            If e.ColumnIndex = 2 Then
                Dim xformato As String = "#0.000"
                Dim xd As String = MisGrid1.Rows(e.RowIndex).Cells("decimales").Value.ToString
                Dim xv As Integer = 0
                Integer.TryParse(xd, xv)
                If xv > 0 Then
                    xv += 1
                End If
                e.CellStyle.Format = xformato.Substring(0, 2 + xv)
            End If
            If e.ColumnIndex >= 2 And e.ColumnIndex <= 6 Then
                e.Value = String.Format("{0:#0.00}", e.Value)
            End If
        End If
    End Sub

    Sub ActualizarVistaItem()
        ActualizaVistaItem()
    End Sub

    Sub ActualizaVistaItem()
        If xbs_tabladata.Current IsNot Nothing Then
            Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row
            xfichatem.RegistroDato.M_CargarFicha(xrow)
            Me.E_V_1.Text = xfichatem.RegistroDato._NombreProducto
            Me.E_V_2.Text = xfichatem.RegistroDato._CodigoProducto
            Me.E_V_7.Text = xfichatem.RegistroDato._NombreEmpaque
            Me.E_V_4.Text = xfichatem.RegistroDato._TotalNeto
            Me.E_V_3.Text = xfichatem.RegistroDato._ContenidoEmpaque
            Me.E_V_5.Text = xfichatem.RegistroDato._PrecioSugerido
            Me.E_V_6.Text = xfichatem.RegistroDato._PrecioLiquida
            Me.E_V_8.Text = xfichatem.RegistroDato._Monto_Descuento1
            Me.E_V_9.Text = xfichatem.RegistroDato._MontoIva
            Me.E_V_10.Text = xfichatem.RegistroDato._TotalGeneral
            Me.E_PFINAL.Text = xfichatem.RegistroDato._PrecioFinal
            Me.E_PNETO.Text = xfichatem.RegistroDato._PrecioNeto
            Me.E_PFULL.Text = xfichatem.RegistroDato._PrecioItem_FullIva
        Else
            Me.E_V_1.Text = ""
            Me.E_V_2.Text = ""
            Me.E_V_7.Text = ""
            Me.E_V_4.Text = "0"
            Me.E_V_3.Text = "0"
            Me.E_V_5.Text = "0.0"
            Me.E_V_6.Text = "0.0"
            Me.E_V_8.Text = "0.0"
            Me.E_V_9.Text = "0.0"
            Me.E_V_10.Text = "0.0"
            Me.E_PFINAL.Text = "0.0"
            Me.E_PNETO.Text = "0.0"
            Me.E_PFULL.Text = "0.0"
        End If
    End Sub

    Sub CargarTabla()
        Me.E_LINEAS.Text = _MiFichaDoc._Lineas.ToString
        Me.E_KILOS.Text = String.Format("{0:#0.000}", _MiFichaDoc._Kilos)
        Me.E_ITEMS.Text = _MiFichaDoc._Items.ToString
        Me.E_SUBTOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Subtotal_1)
        Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", _MiFichaDoc._SubtotalIva_1)
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Total_1)
    End Sub

    Private Sub BT_SALIDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SALIDA.Click
        Me.Close()
    End Sub

    Private Sub PB_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_10.Click
        ControlClientes()
    End Sub

    Sub ControlClientes()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCliente.F_Permitir()

            Dim xficha As New FichaCliente
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarDataCliente()
        CargarFichaCliente(xfichacli.f_Clientes.RegistroDato.r_Automatico)
    End Sub

    Private Sub E_RIF_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles E_RIF.LinkClicked
        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            Dim xficha As New FichaCliente(xfichacli.f_Clientes.RegistroDato.r_Automatico)
            With xficha
                AddHandler .ActualizarDatosFicha, AddressOf ActualizarDataCliente
                .ShowDialog()
            End With
            IrInicio()
        End If
    End Sub

    Sub CargarFichaCliente(ByVal xauto As String)
        Try
            xfichacli.F_BuscarCliente(xauto)
            If xfichacli.f_Clientes.RegistroDato.r_EstatusDelCliente = TipoEstatus.Inactivo Then
                MessageBox.Show("Cliente Seleccionado Esta Inactivo / Suspendido, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Throw New Exception
            Else
                Me.E_CLI_CODIGO.Text = xfichacli.f_Clientes.RegistroDato.r_CodigoCliente
                Me.E_CLI_NOMBRE.Text = xfichacli.f_Clientes.RegistroDato.r_NombreRazonSocial
                Me.E_CLI_RIF.Text = xfichacli.f_Clientes.RegistroDato.r_CiRif
            End If
        Catch ex As Exception
            xfichacli.f_Clientes.RegistroDato.M_LimpiarRegistro()

            Me.E_CLI_CODIGO.Text = xfichacli.f_Clientes.RegistroDato.r_CodigoCliente
            Me.E_CLI_NOMBRE.Text = xfichacli.f_Clientes.RegistroDato.r_NombreRazonSocial
            Me.E_CLI_RIF.Text = xfichacli.f_Clientes.RegistroDato.r_CiRif

            IrInicio()
        End Try
    End Sub

    Sub AdmDocumentos()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_AdmDocumentos_Ventas.F_Permitir()

            Dim xficha As New AdmDocumentos(New AdmDoc_Ventas(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_AdmDocumentos, TipoDocumentoVenta.Factura), True)
            With xficha
                AddHandler xficha._AutoDocumento, AddressOf CapturarDoc
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_8.Click
        AdmDocumentos()
    End Sub

    Sub CapturarDoc(ByVal xauto As String)
        If _MiFichaDoc._Total_1 = 0 And _MiFichaDoc._Lineas = 0 And _MiFichaDoc._TablaData.Rows.Count = 0 Then
            Try
                xfichaventa.F_Venta.F_BuscarDocumento(xauto)
                If xfichaventa.F_Venta.RegistroDato._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Factura Or xfichaventa.F_Venta.RegistroDato._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Chimbo Then
                    If xfichaventa.F_Venta.RegistroDato._EstatusDocumento = TipoEstatus.Inactivo Then
                        Throw New Exception("ERROR ... DOCUMENTO SE ENCUENTRA ANULADO, VERIFIQUE POR FAVOR")
                    Else
                        MostrarDoc()
                    End If
                Else
                    Throw New Exception("ERROR AL CARGAR TIPO DE DOCUMENTO, SOLO SE PODRAN CARGAR DOCUMENTOS DE VENTAS")
                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        Else
            Funciones.MensajeDeAlerta("No Se Pueden Cargar Mas De Un Documento De Venta A La Vez, Verifique Por Favor...")
        End If
    End Sub

    Sub MostrarDoc()
        With xfichaventa.F_Venta.RegistroDato
            Me.E_DOCUMENTO.Text = ._Documento
            Me.E_FECHA.Text = ._FechaEmision
            Me.E_PAGO.Text = ._CondicionPago.ToString
            CargarFichaCliente(._AutoCliente)
        End With

        CargarData(xfichaventa.F_Venta.RegistroDato._AutoDocumento)
    End Sub

    Sub CargarData(ByVal xauto As String)
        Dim xp1 As New SqlParameter("@auto_documento", xauto)
        Dim xp2 As New SqlParameter("@auto_documento", xauto)
        _MiFichaDoc._RegistrosEnTabla = F_GetInteger("select COUNT(*) from ventas_detalle where auto_documento=@auto_documento", xp1)
        g_MiData.F_GetData("select codigo x1, nombre x2, cantidad x3, precio_neto x4, descuento1p x5, tasa x6, total_neto x7, 0 x8, 'D' AS x9, " _
                           + "* from VENTAS_DETALLE where auto_documento=@auto_documento", _MiFichaDoc._TablaData, xp2)
        CargarTabla()

        'LIMPIAR LOS DETALLES QUE TRAE DE LA VENTA, PARA INCIALIZAR LA NOTA DE CREDITO
        Dim xficha As New FichaVentas.V_VentasDetalle.c_Registro
        For Each xrow As DataRow In _MiFichaDoc._TablaData.Rows
            xrow(xficha.c_DetalleNotas.c_NombreInterno) = ""
        Next
    End Sub

    Private Sub MisGrid1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MisGrid1.CellDoubleClick
        If e.RowIndex <> -1 Then
            If e.ColumnIndex = 7 Then
                If MisGrid1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1 Then
                    MisGrid1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                Else
                    MisGrid1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1
                End If
                _MiFichaDoc._TablaData.AcceptChanges()
            End If
        End If
    End Sub

    Private Sub PB_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_5.Click
        NotasDetallesItem()
    End Sub

    Sub NotasDetallesItem()
        If xbs_tabladata.Current IsNot Nothing Then
            If xbs_tabladata.Current("x8") = 1 Then
                Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row
                Dim xfichatemporal As New FichaVentas.V_VentasDetalle
                xfichatemporal.RegistroDato.M_CargarFicha(xrow)
                Dim xnotas As String = xfichatemporal.RegistroDato._DetalleNotas

                Dim xficha As New NotasItem(xnotas, xfichatemporal.RegistroDato.c_DetalleNotas.c_Largo)
                With xficha
                    .ShowDialog()
                    If ._SalidaExitosa Then
                        Try
                            MisGrid1.CurrentRow.Cells(xfichatemporal.RegistroDato.c_DetalleNotas.c_NombreInterno).Value = ._NotasItem
                            _MiFichaDoc._TablaData.AcceptChanges()
                            MessageBox.Show("Item Actualizado Satisfactoriamente... Ok", "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As Exception
                            Funciones.MensajeDeError(ex.Message)
                        End Try
                    End If
                End With
            Else
                Funciones.MensajeDeAlerta("Item Marcado Como Protegido, Veirifique Por Favor...")
            End If
        End If
        Me.IrInicio()
    End Sub

    Private Sub PB_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_7.Click
        EliminarItem()
    End Sub

    Sub EliminarItem()
        If _MiFichaDoc._TablaData.Rows.Count > 0 Then
            If MessageBox.Show("Estas Seguro De Marcar Todos Los Items Para La Devolucion Total ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                For Each xrow As DataRow In _MiFichaDoc._TablaData.Rows
                    xrow("x8") = 1
                Next
            End If
        End If
        Me.IrInicio()
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        ModificarItem()
    End Sub

    Sub ModificarItem()
        If xbs_tabladata.Current IsNot Nothing Then
            If xbs_tabladata.Current("x8") = 1 Then
                Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row
                Dim xfichatemporal As New FichaVentas.V_VentasDetalle
                xfichatemporal.RegistroDato.M_CargarFicha(xrow)

                Dim xficha As New ModificarItem_NC(xfichatemporal.RegistroDato)
                With xficha
                    .ShowDialog()
                    If ._EstatusSalida Then
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(2) = ._Cantidad_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(3) = ._Precio_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(4) = ._Descuento_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(6) = ._Importe_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(xfichatemporal.RegistroDato.c_DetalleNotas.c_NombreInterno) = ._Detalle_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(8) = ._Tipo_NC
                        _MiFichaDoc._TablaData.AcceptChanges()
                        xbs_tabladata.CurrencyManager.Refresh()
                    End If
                End With
            End If
        End If
        IrInicio()
    End Sub

    Private Sub PB_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_6.Click
        Procesar()
    End Sub

    Sub Procesar()
        Try
            If xfichaventa.F_Venta.RegistroDato._AutoDocumento <> "" Then
                If Me._MiFichaDoc._Total_1 >= 0 And Me._MiFichaDoc._Lineas > 0 Then
                    Dim xtot As New IPlantilla_10.Totales_Data
                    With xtot
                        ._Exento = _MiFichaDoc._Exento_1
                        ._Neto1 = _MiFichaDoc._Neto1_1
                        ._Neto2 = _MiFichaDoc._Neto2_1
                        ._Neto3 = _MiFichaDoc._Neto3_1
                        ._NumeroLineas = _MiFichaDoc._Lineas
                        ._RegistrosTabla = _MiFichaDoc._TablaData
                        ._Tasa1 = _MiFichaDoc._TasaIva1
                        ._Tasa2 = _MiFichaDoc._TasaIva2
                        ._Tasa3 = _MiFichaDoc._TasaIva3
                        ._FichaRegistroVentas = xfichaventa.F_Venta.RegistroDato
                    End With

                    If _MiPlantilla.ProcesarDocumento(xfichaventa.F_Venta.RegistroDato, xtot) Then
                        Funciones.MensajeDeOk("Documento Procesado Con Exito... !!!")
                    End If
                Else
                    Funciones.MensajeDeAlerta("No Hay Items Seleccionados Para Procesar El Documento !!!")
                End If
            End If
        Catch ex As Exception
            Me.Select()
            Me.BT_SALIDA.Select()
            Me.BT_SALIDA.Focus()
            Funciones.MensajeDeError(ex.Message)
        End Try
        IrInicio()
    End Sub

    Private Sub PB_11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_11.Click
        g_MiCalculadora = New MiCalculadora.Calc
        g_MiCalculadora.Show()
    End Sub
End Class

Public Interface IPlantilla_10
    Class TipoDoc
        Private xtipo As TipoDocumentoVenta
        Private xnombre As String

        Property _Tipo() As TipoDocumentoVenta
            Get
                Return xtipo
            End Get
            Set(ByVal value As TipoDocumentoVenta)
                xtipo = value
            End Set
        End Property

        Property _Nombre() As String
            Get
                Return xnombre
            End Get
            Set(ByVal value As String)
                xnombre = value
            End Set
        End Property
    End Class

    Class Totales_Data
        Dim xlineas As Integer
        Dim xexento As Decimal
        Dim xneto1 As Decimal
        Dim xneto2 As Decimal
        Dim xneto3 As Decimal
        Dim xtasa1 As Decimal
        Dim xtasa2 As Decimal
        Dim xtasa3 As Decimal
        Dim xtabla As DataTable
        Dim xfichaventa As FichaVentas.V_Ventas.c_Registro
        Dim xdetalles As String

        Property _NotasDetalles() As String
            Get
                Return xdetalles
            End Get
            Set(ByVal value As String)
                xdetalles = value
            End Set
        End Property

        Property _FichaRegistroVentas() As FichaVentas.V_Ventas.c_Registro
            Get
                Return xfichaventa
            End Get
            Set(ByVal value As FichaVentas.V_Ventas.c_Registro)
                xfichaventa = value
            End Set
        End Property

        Property _NumeroLineas() As Integer
            Get
                Return xlineas
            End Get
            Set(ByVal value As Integer)
                xlineas = value
            End Set
        End Property

        Property _Exento() As Decimal
            Get
                Return Decimal.Round(xexento, 2, MidpointRounding.AwayFromZero)
            End Get
            Set(ByVal value As Decimal)
                xexento = value
            End Set
        End Property

        Property _Neto1() As Decimal
            Get
                Return Decimal.Round(xneto1, 2, MidpointRounding.AwayFromZero)
            End Get
            Set(ByVal value As Decimal)
                xneto1 = value
            End Set
        End Property

        Property _Tasa1() As Decimal
            Get
                Return xtasa1
            End Get
            Set(ByVal value As Decimal)
                xtasa1 = value
            End Set
        End Property

        ReadOnly Property _Iva1() As Decimal
            Get
                Dim xiva As Decimal = 0
                xiva = Decimal.Round(_Neto1 * _Tasa1 / 100, 2, MidpointRounding.AwayFromZero)
                Return xiva
            End Get
        End Property

        Property _Neto2() As Decimal
            Get
                Return Decimal.Round(xneto2, 2, MidpointRounding.AwayFromZero)
            End Get
            Set(ByVal value As Decimal)
                xneto2 = value
            End Set
        End Property

        Property _Tasa2() As Decimal
            Get
                Return xtasa2
            End Get
            Set(ByVal value As Decimal)
                xtasa2 = value
            End Set
        End Property

        ReadOnly Property _Iva2() As Decimal
            Get
                Dim xiva As Decimal = 0
                xiva = Decimal.Round(_Neto1 * _Tasa1 / 100, 2, MidpointRounding.AwayFromZero)
                Return xiva
            End Get
        End Property

        Property _Neto3() As Decimal
            Get
                Return Decimal.Round(xneto3, 2, MidpointRounding.AwayFromZero)
            End Get
            Set(ByVal value As Decimal)
                xneto3 = value
            End Set
        End Property

        Property _Tasa3() As Decimal
            Get
                Return xtasa3
            End Get
            Set(ByVal value As Decimal)
                xtasa3 = value
            End Set
        End Property

        ReadOnly Property _Iva3() As Decimal
            Get
                Dim xiva As Decimal = 0
                xiva = Decimal.Round(_Neto1 * _Tasa1 / 100, 2, MidpointRounding.AwayFromZero)
                Return xiva
            End Get
        End Property

        Property _RegistrosTabla() As DataTable
            Get
                Return xtabla
            End Get
            Set(ByVal value As DataTable)
                xtabla = value
            End Set
        End Property

        ReadOnly Property _SubTotal() As Decimal
            Get
                Dim xrt As Decimal = 0
                xrt = Decimal.Round(_Neto1 + _Neto2 + _Neto3 + _Exento, 2, MidpointRounding.AwayFromZero)
                Return xrt
            End Get
        End Property

        ReadOnly Property _SubTotalIva() As Decimal
            Get
                Dim xrt As Decimal = 0
                xrt = Decimal.Round(_Iva1 + _Iva2 + _Iva3, 2, MidpointRounding.AwayFromZero)
                Return xrt
            End Get
        End Property

        ReadOnly Property _TotalGeneral() As Decimal
            Get
                Dim xrt As Decimal = 0
                xrt = Decimal.Round(_SubTotal + _SubTotalIva, 2, MidpointRounding.AwayFromZero)
                Return xrt
            End Get
        End Property

        Sub New()
            _Exento = 0
            _Neto1 = 0
            _Neto2 = 0
            _Neto3 = 0
            _Tasa1 = 0
            _Tasa2 = 0
            _Tasa3 = 0
            _NumeroLineas = 0
            _NotasDetalles = ""
        End Sub
    End Class

    Event _EventoExitoso()
    ReadOnly Property TipoDocumento() As TipoDoc
    Function ProcesarDocumento(ByVal xfichaventa As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro, _
                          ByVal Totales_Tabla As Totales_Data) As Boolean
End Interface

Public Class NotaCredito_Ventas
    Implements IPlantilla_10

    Dim xtipodoc As IPlantilla_10.TipoDoc

    Sub New()
        xtipodoc = New IPlantilla_10.TipoDoc With {._Nombre = "Control De Notas De Credito", ._Tipo = TipoDocumentoVenta.NotaCredito}
    End Sub

    Public ReadOnly Property TipoDocumento() As IPlantilla_10.TipoDoc Implements IPlantilla_10.TipoDocumento
        Get
            Return xtipodoc
        End Get
    End Property

    Sub CapturarRespuesta()
        RaiseEvent _EventoExitoso()
    End Sub

    Public Event _EventoExitoso() Implements IPlantilla_10._EventoExitoso

    Public Function ProcesarDocumento(ByVal xfichaventa As DataSistema.MiDataSistema.DataSistema.FichaVentas.V_Ventas.c_Registro, ByVal Totales_Tabla As IPlantilla_10.Totales_Data) As Boolean Implements IPlantilla_10.ProcesarDocumento
        Dim AjusteGlobal As Boolean = False
        Dim xseg As Boolean = False
        Dim xficha As New ProcesarDoc_NC(New TipoDocumentoNC, Totales_Tabla)
        With xficha
            .ShowDialog()
            xseg = ._EstatusSalida
        End With

        If xseg Then
            Dim xventa_encabezado As New FichaVentas.V_Ventas.AgregarNotaCredito
            Dim xventa_detalle As New List(Of FichaVentas.V_VentasDetalle.AgregarDetalleNotaCredito)
            Dim xventas As New FichaVentas
            Dim xtabla As New DataTable

            Try
                With xventa_encabezado
                    ._CantidadRenglones = Totales_Tabla._NumeroLineas
                    ._CodigoSucursal = g_MiData.f_FichaGlobal.f_Negocio.RegistroDato.c_CodigoSucursal.c_Texto
                    ._EstacionEquipoProceso = g_EquipoEstacion.p_EstacionNombre
                    ._FichaRegistroVentaOrigen = xfichaventa
                    ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                    ._MontoBase_1 = Totales_Tabla._Neto1
                    ._MontoBase_2 = Totales_Tabla._Neto2
                    ._MontoBase_3 = Totales_Tabla._Neto3
                    ._MontoExento = Totales_Tabla._Exento
                    ._MontoSubtotal = Totales_Tabla._SubTotal
                    ._NotasDocumento = Totales_Tabla._NotasDetalles
                    ._SerieFiscalAsignada = g_ConfiguracionSistema._SerieNotaCredito
                End With

                For Each xrow As DataRow In Totales_Tabla._RegistrosTabla.Rows
                    If xrow("x8") = 1 Then
                        Dim xdetalle As New FichaVentas.V_VentasDetalle.AgregarDetalleNotaCredito
                        Dim xdet As New FichaVentas.V_VentasDetalle
                        xdet.RegistroDato.M_CargarFicha(xrow)

                        With xdetalle
                            ._Cantidad = xrow("x3")
                            ._Descto = xrow("x5")
                            ._PrecioNeto = xrow("x4")
                            ._Importe = xrow("x7")
                            ._NotasDetalle = xdet.RegistroDato._DetalleNotas
                            ._ItemDetalleOrigen = xdet.RegistroDato
                            ._TipoMovimiento = IIf(xrow("x9").ToString.Trim = "A", TipoMovimientoNC.AJUSTE, TipoMovimientoNC.DEVOLUCION)
                        End With
                        xventa_detalle.Add(xdetalle)
                    End If
                Next

                Dim ximpresora As New FichaVentas.ModoImprimirFactura
                With ximpresora
                    ._FormatoNombre = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALNCR_Formato
                    ._ModoImpresion = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALNCR_MedioImpresion
                    ._RutaImpresora = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALNCR_RutaImpresora
                    ._Impresora = g_ImpFiscal
                End With

                If xventa_encabezado._FichaRegistroVentaOrigen._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Factura Then
                    If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALNCR_MedioImpresion = TipoImpresora.Grafico Then
                        AddHandler xventas.DocumentoProcesado, AddressOf VisualizarDoc_Ventas
                    ElseIf g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALNCR_MedioImpresion = TipoImpresora.Texto Then
                        AddHandler xventas.DocumentoProcesado, AddressOf ImprimirNC
                    Else
                        ximpresora._Impresora.Estatus()
                    End If
                Else
                    AddHandler xventas.DocumentoProcesado, AddressOf ImprimirNC_CHIMBA
                End If

                AddHandler xventas.FacturaExitosa, AddressOf CapturarRespuesta

                If xventa_encabezado._FichaRegistroVentaOrigen._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Factura Then
                    xventas.F_GrabarNotaCredito(xventa_encabezado, xventa_detalle, ximpresora)
                Else
                    xventas.F_GrabarNotaCreditoChimba(xventa_encabezado, xventa_detalle)
                End If

                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End If
    End Function

    Sub ImprimirNC(ByVal xauto As String)
        Try
            Dim xfactura As LibImprimir.LibImprimir
            xfactura = New LibImprimir.LibImprimir(xauto, _MiCadenaConexion)
            xfactura.ImprimirFactura("NOTAS", My.Application.Info.DirectoryPath + "\FORMATOS\NOTAC.XML")
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ImprimirNC_CHIMBA(ByVal xauto As String)
        Try
            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._OTROS_MODO_IMPRESION = TipoImpresora.Texto Then
                Dim xfactura As LibImprimir.LibImprimir
                xfactura = New LibImprimir.LibImprimir(xauto, _MiCadenaConexion)
                xfactura.ImprimirFactura("NOTAS", My.Application.Info.DirectoryPath + "\FORMATOS\OTRANC.XML")
            Else
                VisualizarDoc_Ventas(xauto)
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class