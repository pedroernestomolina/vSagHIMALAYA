Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plant_Compra_1
    Event ActualizarFicha()

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
        Private xmontoimplicor As Decimal
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
                    Me._MontoImpuestoLicor = 0

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
                Dim xtot As Decimal = xsubtn + xsubti + Me._MontoImpuestoLicor
                Return Decimal.Round(xtot, 2, MidpointRounding.AwayFromZero)
            End Get
        End Property

        Property _MontoImpuestoLicor() As Decimal
            Get
                Return Me.xmontoimplicor
            End Get
            Set(ByVal value As Decimal)
                Me.xmontoimplicor = value
            End Set
        End Property

        Property _TablaData() As DataTable
            Get
                Return xtabla
            End Get
            Set(ByVal value As DataTable)
                xtabla = value
            End Set
        End Property

        ReadOnly Property _AutoOrdenCompra() As String
            Get
                Dim xauto As String = ""
                For Each xrow As DataRow In Me._TablaData.Rows
                    If Not IsDBNull(xrow("AutoOrdenCompra")) Then
                        If xrow("AutoOrdenCompra") IsNot Nothing Then
                            xauto = xrow("AutoOrdenCompra").ToString.Trim
                            Exit For
                        End If
                    End If
                Next
                Return xauto
            End Get
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
            Me._MontoImpuestoLicor = 0

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
            Me._MontoImpuestoLicor = 0

            If Me._TablaData.Rows.Count >= Me._RegistrosEnTabla Then
                For Each xrow As DataRow In Me._TablaData.Rows
                    Dim xfichatemp As New FichaCompras.c_TemporalCompra
                    xfichatemp.M_CargarRegistro(xrow)
                    If xfichatemp.RegistroDato._EsPesado = "1" Then
                        Me._Kilos += xfichatemp.RegistroDato._CantidadItems
                        Me._Items += 1
                    Else
                        Me._Items += Decimal.Round(xfichatemp.RegistroDato._CantidadItems, 0, MidpointRounding.AwayFromZero)
                    End If
                    Select Case xfichatemp.RegistroDato._TipoTasa
                        Case "0"
                            Me._Exento_1 += xfichatemp.RegistroDato._CostoTotal
                        Case "1"
                            Me._Neto1_1 += xfichatemp.RegistroDato._CostoTotal
                        Case "2"
                            Me._Neto2_1 += xfichatemp.RegistroDato._CostoTotal
                        Case "3"
                            Me._Neto3_1 += xfichatemp.RegistroDato._CostoTotal
                    End Select
                    Me._Lineas += 1
                    Me._MontoImpuestoLicor += xfichatemp.RegistroDato._MontoImpuestoLicor

                    If Not IsDBNull(xrow("AutoOrdenCompra")) Then
                        If xrow("AutoOrdenCompra") IsNot Nothing Then
                        End If
                    End If
                Next
            End If
        End Sub
    End Class

    Dim pb_tm As Size
    Dim xdocumento As IPlant_Compra_1

    Dim xfichaprd As FichaProducto.Prd_Producto
    Dim xfichapro As FichaProveedores

    Dim xfichdocumento As FichaDoc
    Dim xbs_tabladata As BindingSource

    ''' <summary>
    ''' Refleja Los Totales De La Pantalla
    ''' </summary>
    Property MiFichaDoc() As FichaDoc
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
    Property MiDocumento() As IPlant_Compra_1
        Get
            Return xdocumento
        End Get
        Set(ByVal value As IPlant_Compra_1)
            xdocumento = value
        End Set
    End Property

    'Dim TasaImpuesto As Decimal = 16.0
    'Dim TipoImpuesto As String = "1"
    'Dim HabilitarPreguntaDecreto As Boolean = False

    Sub New(ByVal xtipoplantilla As IPlant_Compra_1)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MiDocumento = xtipoplantilla
        AddHandler MiDocumento.LimpiarFicha, AddressOf LimpiarFicha
        AddHandler MiDocumento.ItemFueProcesado, AddressOf CargarTabla
        AddHandler MiDocumento._AbrirPendiente, AddressOf CargarCtaPendiente

        'If TypeOf xtipoplantilla Is ControlComprasNacionales Then
        '    'If MiDecretoEmergencia.DecretoEmergenciaActivo Then
        '    '    PreguntaDecretoEmergencia()
        '    '    HabilitarPreguntaDecreto = True
        '    'Else
        '    '    TasaImpuesto = 12
        '    '    TipoImpuesto = "1"
        '    'End If
        'End If
    End Sub

    Sub PreguntaDecretoEmergencia()
        'Dim xres = MessageBox.Show("DOCUMENTOS A REGISTRAR APLICA DESCUENTO 3% DE IVA", "** ALERTA **", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If xres = Windows.Forms.DialogResult.No Then
        '    xres = MessageBox.Show("DOCUMENTOS A REGISTRAR APLICA DESCUENTO 5% DE IVA", "** ALERTA **", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If xres = Windows.Forms.DialogResult.No Then
        '        TasaImpuesto = 12
        '        TipoImpuesto = "1"
        '    Else
        '        TasaImpuesto = 7
        '        TipoImpuesto = "2"
        '    End If
        'Else
        '    TasaImpuesto = 9
        '    TipoImpuesto = "3"
        'End If
    End Sub

    Sub LimpiarFicha()
        CargarTabla()
        xfichapro.f_Proveedor.RegistroDato.LimpiarRegistro()
        CargarFichaProveedor(xfichapro.f_Proveedor.RegistroDato._Automatico)
    End Sub

    Private Sub PB_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseEnter, PB_2.MouseEnter, PB_3.MouseEnter, PB_4.MouseEnter, _
                PB_5.MouseEnter, PB_6.MouseEnter, PB_7.MouseEnter, PB_8.MouseEnter, PB_9.MouseEnter, PB_10.MouseEnter, PB_11.MouseEnter, PB_12.MouseEnter

        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseHover, PB_2.MouseHover, PB_3.MouseHover, PB_4.MouseHover, _
                PB_5.MouseHover, PB_6.MouseHover, PB_7.MouseHover, PB_8.MouseHover, PB_9.MouseHover, PB_10.MouseHover, PB_11.MouseHover, PB_12.MouseHover

        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseLeave, PB_2.MouseLeave, PB_3.MouseLeave, _
                PB_4.MouseLeave, PB_5.MouseLeave, PB_6.MouseLeave, PB_7.MouseLeave, PB_8.MouseLeave, PB_9.MouseLeave, PB_10.MouseLeave, PB_11.MouseLeave, _
                PB_12.MouseLeave

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

    Private Sub Plant_Compra_1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MiFichaDoc._Total_1 = 0 And MiFichaDoc._Items = 0 Then
            e.Cancel = False
        Else
            EliminarTodosLosItems()
            e.Cancel = True
        End If
    End Sub

    Sub IrSeleccionTipoBusqueda()
        Me.MCB_BUSQUEDA.Focus()
    End Sub

    Private Sub Plant_Compra_1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            IrInicio()
        End If

        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            IrSeleccionTipoBusqueda()
        End If

        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            BusquedaAvanzadaPrd()
        End If
        If e.KeyCode = Keys.F4 AndAlso (e.Alt = False And e.Control = False) Then
            BuscarProveedor()
        End If
        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False And e.Control = False) Then
            ModificarItem()
        End If
        If e.KeyCode = Keys.F6 AndAlso (e.Alt = False And e.Control = False) Then
            AbrirDejar_CtaPendiente()
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
        If e.KeyCode = Keys.D1 AndAlso (e.Alt = True And e.Control = False) Then
            ControlInventario()
        End If
        If e.KeyCode = Keys.D2 AndAlso (e.Alt = True And e.Control = False) Then
            ControlProveedores()
        End If
        If e.KeyCode = Keys.D3 AndAlso (e.Alt = True And e.Control = False) Then
            RecuperarDocumento()
        End If
    End Sub

    Private Sub Plant_Compra_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plant_Compra_1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pb_tm = PB_1.Size
    End Sub

    Private Sub Plant_Compra_1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub IrInicio()
        Me.MT_BUSCAR.Text = ""
        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()
    End Sub

    Sub InicializarPantalla()
        IrInicio()
        Me.Text = "Datos Del Usuario: " + g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario + ", Grupo: " + g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreGrupo
        Me.E_TITULO.Text = MiDocumento.TipoDocumento._Nombre

        Me.E_CLI_CODIGO.Text = xfichapro.f_Proveedor.RegistroDato._CodigoProveedor
        Me.E_CLI_NOMBRE.Text = xfichapro.f_Proveedor.RegistroDato._NombreRazonSocial
        Me.E_CLI_RIF.Text = xfichapro.f_Proveedor.RegistroDato._CiRif

        Me.E_ITEMS.Text = MiFichaDoc._Items.ToString
        Me.E_KILOS.Text = String.Format("{0:#0.000}", MiFichaDoc._Kilos)
        Me.E_LINEAS.Text = MiFichaDoc._Items.ToString
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", MiFichaDoc._Total_1)
        Me.E_SUBTOTAL.Text = String.Format("{0:#0.00}", MiFichaDoc._Subtotal_1)
        Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", MiFichaDoc._SubtotalIva_1)
        Me.E_DOC_PENDIENTES.Text = "0"
        Me.E_IMP_LICOR.Text = String.Format("{0:#0.00}", MiFichaDoc._MontoImpuestoLicor)

        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 500
            .UseFading = True
            .ShowAlways = True
        End With

        With Me.MCB_BUSQUEDA
            .DataSource = xfichaprd._TipoBusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProducto
        End With

        With MisGrid1
            .Columns.Add("col0", "Codigo")
            .Columns.Add("col1", "Descripcion")
            .Columns.Add("col2", "Cant")
            .Columns.Add("col3", "C/Unid")
            .Columns.Add("col4", "Dscto(Bs)")
            .Columns.Add("col5", "Importe")

            .Columns(0).Width = 80
            .Columns(2).Width = 65
            .Columns(3).Width = 90
            .Columns(4).Width = 90
            .Columns(5).Width = 100
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            CargarTabla()
            .DataSource = xbs_tabladata
            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(2).DataPropertyName = "x3"
            .Columns(3).DataPropertyName = "x4"
            .Columns(4).DataPropertyName = "x5"
            .Columns(5).DataPropertyName = "x6"
            AddHandler .CellFormatting, AddressOf MiFormato

            .Ocultar(7)
        End With
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 2 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight

            If e.ColumnIndex = 2 Then
                Dim xformato As String = "#0.000"
                Dim xd As String = MisGrid1.Rows(e.RowIndex).Cells("decimalesmedida").Value.ToString
                Dim xv As Integer = 0
                Integer.TryParse(xd, xv)
                If xv > 0 Then
                    xv += 1
                End If
                e.CellStyle.Format = xformato.Substring(0, 2 + xv)
            End If
        End If
    End Sub

    Dim xfichatem As FichaCompras.c_TemporalCompra

    Sub Inicializa()
        Try
            xfichatem = New FichaCompras.c_TemporalCompra
            xfichaprd = New FichaProducto.Prd_Producto
            xfichapro = New FichaProveedores

            MiFichaDoc = New FichaDoc

            xbs_tabladata = New BindingSource(MiFichaDoc._TablaData, "")
            AddHandler xbs_tabladata.PositionChanged, AddressOf ActualizarVistaItem
            ActualizaVistaItem()

            InicializarPantalla()

            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub ActualizarVistaItem()
        ActualizaVistaItem()
    End Sub

    Sub ActualizaVistaItem()
        Try
            If xbs_tabladata.Current IsNot Nothing Then
                Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row
                xfichatem.M_CargarRegistro(xrow)

                With xfichatem.RegistroDato
                    Me.E_V_1.Text = ._NombreProducto
                    Me.E_V_2.Text = ._CodigoProducto
                    Me.E_V_7.Text = ._NombreEmpaque
                    Me.E_V_4.Text = ._CostoTotal
                    Me.E_V_3.Text = ._ContenidoEmpaque
                    Me.E_V_5.Text = ._PSugerido
                    Me.E_IVA.Text = ._TasaIva
                    Me.E_V_8.Text = String.Format("{0:#0.00}", Decimal.Round(._CostoUnitario * (._Descuento_1._Tasa + ._Descuento_2._Tasa + ._Descuento_3._Tasa) / 100, 2, MidpointRounding.AwayFromZero))
                    Me.E_V_9.Text = String.Format("{0:#0.00}", Decimal.Round(._CostoTotal * ._TasaIva / 100, 2, MidpointRounding.AwayFromZero))
                    Me.E_V_10.Text = String.Format("{0:#0.00}", Decimal.Round(._CostoTotal + (._CostoTotal * ._TasaIva / 100) + ._MontoImpuestoLicor, 2, MidpointRounding.AwayFromZero))
                    Me.E_V_11.Text = String.Format("{0:#0.00}", ._MontoImpuestoLicor)
                    Me.E_PFINAL.Text = ._Costo_Final
                    Me.E_PNETO.Text = ._CostoUnitario
                    Me.E_COSTOPROMOCION.Text = String.Format("{0:#0.00}", (._CostoTotal + ._Descuento_1._Valor + ._Descuento_2._Valor + ._Descuento_3._Valor) / (._CantidadItems + ._Bono))
                End With

            Else
                Me.E_V_1.Text = ""
                Me.E_V_2.Text = ""
                Me.E_V_7.Text = ""
                Me.E_V_4.Text = "0"
                Me.E_V_3.Text = "0"
                Me.E_V_5.Text = "0.0"
                Me.E_IVA.Text = "0.00"
                Me.E_V_8.Text = "0.0"
                Me.E_V_9.Text = "0.0"
                Me.E_V_10.Text = "0.0"
                Me.E_V_11.TEXT = "0.0"
                Me.E_PFINAL.Text = "0.0"
                Me.E_PNETO.Text = "0.0"
                Me.E_COSTOPROMOCION.Text = "0.0"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MCB_BUSQUEDA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSQUEDA.SelectedIndexChanged
        IrInicio()
    End Sub

    Private Sub BT_BUSCAR_PRD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR_PRD.Click
        If CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorCodBarra _
          Or CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorCodigoProveedor Then
            IrInicio()
        Else
            BuscarProducto()
        End If
    End Sub

    Sub BuscarProducto()
        If MT_BUSCAR.r_Valor <> "" Then
            Dim xcondicion As String = ""
            Dim xcondpro As String = ""
            Dim xp1 As SqlParameter = Nothing
            Dim xp2 As SqlParameter = Nothing
            Dim xp3 As SqlParameter = Nothing
            Dim xp4 As SqlParameter = Nothing

            Dim xsql As String = ""
            Dim xbuscar As String = ""
            Dim TipoB As String = ""

            Select Case CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto)
                Case FichaProducto.TipoBusquedaProducto.PorCodigo
                    TipoB = "CODIGO"
                Case FichaProducto.TipoBusquedaProducto.PorDescripcion
                    TipoB = "NOMBRE"
                Case FichaProducto.TipoBusquedaProducto.PorNumParte
                    TipoB = "NUMERO_PARTE"
                Case FichaProducto.TipoBusquedaProducto.PorPlu
                    TipoB = "PLU"
                Case FichaProducto.TipoBusquedaProducto.PorReferencia
                    TipoB = "REFERENCIA"
                Case FichaProducto.TipoBusquedaProducto.PorSerial
            End Select

            If CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorSerial Then
                Dim Tipobusq As String = ""
                xsql = Tipobusq
                xp1 = New SqlParameter
                xp2 = New SqlParameter
                xp3 = New SqlParameter
                xp4 = New SqlParameter
            Else
                If MT_BUSCAR.Text.Substring(0, 1) = "*" Then
                    xbuscar = "%" + MT_BUSCAR.r_Valor.Substring(1)
                    If xfichapro.f_Proveedor.RegistroDato._Automatico <> "" Then
                        xcondpro = "join productos_proveedor pp on p.auto=pp.auto_producto "
                        xcondicion = "and pp.auto_proveedor='" + xfichapro.f_Proveedor.RegistroDato._Automatico + "' "
                    End If
                Else
                    xbuscar = MT_BUSCAR.r_Valor
                End If

                xp1 = New SqlParameter("@data1", xbuscar + "%")
                xp2 = New SqlParameter("@data2", xbuscar + "%")
                xp3 = New SqlParameter("@data3", xbuscar + "%")
                xp4 = New SqlParameter("@limite", g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._LimiteProductosMostrar_AdmBusquedaNormal)

                'RESTRINGO A UN LIMITE ESTABLECIDO
                Dim TipoBusq As String = _
                      "SELECT  top(@limite) p.nombre xnom, p.codigo xcod, p.tasa xtas, p.plu xplu, p.psv, p.auto, p.estatus,p.referencia xref, " _
                                  + "p.contenido_empaque xempcompra, pdep.nombre ndep, pgrp.nombre ngrp, pmar.nombre nmar, pmed.nombre nmed, pmed.decimales xdec " _
                                  + "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto join productos_grupo pgrp on p.auto_grupo=pgrp.auto " _
                                  + "join productos_marca pmar on p.auto_marca=pmar.auto join productos_medida pmed on p.auto_medida_compra=pmed.auto " _
                                  + "where p." + TipoB + " like @data1 and p.estatus_departamento='0' order by p." + TipoB + ";" _
                                  + "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                                  + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                                  + "where pd.auto_producto in (select top (@limite) p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                                  + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                                  + "where p." + TipoB + " like @data2 and p.estatus_departamento='0' order by p." + TipoB + ");" _
                                  + "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, pe.*, pm.* " _
                                  + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
                                  + "where pe.auto_producto in (select top (@limite) p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                                  + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                                  + "where p." + TipoB + " like @data3 and p.estatus_departamento='0' order by p." + TipoB + ") ORDER BY PE.REFERENCIA"

                '"SELECT p.nombre xnom, p.codigo xcod, p.tasa xtas, p.plu xplu, p.psv, p.auto, p.estatus,p.referencia xref, " _
                '            + "p.contenido_empaque xempcompra, pdep.nombre ndep, pgrp.nombre ngrp, pmar.nombre nmar, pmed.nombre nmed, pmed.decimales xdec " _
                '            + "from productos p " + xcondpro + "join productos_departamento pdep on p.auto_departamento=pdep.auto join productos_grupo pgrp on p.auto_grupo=pgrp.auto " _
                '            + "join productos_marca pmar on p.auto_marca=pmar.auto join productos_medida pmed on p.auto_medida_compra=pmed.auto " _
                '            + "where p." + TipoB + " like @data1 and p.estatus_departamento='0' " + xcondicion + "group by p.nombre, p.codigo, p.tasa, p.plu, p.psv, p.auto, p.estatus,p.referencia,p.contenido_empaque, pdep.nombre, pgrp.nombre, pmar.nombre, pmed.nombre, pmed.decimales order by p." + TipoB + ";" _
                '            + "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                '            + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                '            + "where pd.auto_producto in (select p.auto from productos p " + xcondpro + "join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                '            + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                '            + "where p." + TipoB + " like @data2 and p.estatus_departamento='0' " + xcondicion + ") ; " _
                '            + "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, pe.*, pm.* " _
                '            + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
                '            + "where pe.auto_producto in (select p.auto from productos p " + xcondpro + "join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                '            + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                '            + "where p." + TipoB + " like @data3 and p.estatus_departamento='0' " + xcondicion + ") order by pe.referencia "
                xsql = TipoBusq

                If xsql.Trim <> "" Then
                    Dim xficha As New Plantilla_5(New VistaVentas(), xsql, xp1, xp2, xp3, xp4)
                    With xficha
                        .ShowDialog()
                        If ._AutoItem_Devolver <> "" Then
                            CargarProducto(._AutoItem_Devolver, .TipoPrecio)
                        End If
                    End With
                End If
            End If
        End If
        IrInicio()
        Me.Select()
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        BuscarProveedor()
    End Sub

    Sub BuscarProveedor()
        Dim xficha As New Plant_Compra_2
        With xficha
            AddHandler .BuscarProveedor, AddressOf CargarFichaProveedor
            .ShowDialog()
        End With
        IrInicio()
    End Sub

    Sub CargarFichaProveedor(ByVal xauto As String)
        Try
            xfichapro.F_BuscarProveedor(xauto)

            Me.E_CLI_CODIGO.Text = xfichapro.f_Proveedor.RegistroDato._CodigoProveedor
            Me.E_CLI_NOMBRE.Text = xfichapro.f_Proveedor.RegistroDato._NombreRazonSocial
            Me.E_CLI_RIF.Text = xfichapro.f_Proveedor.RegistroDato._CiRif

        Catch ex As Exception
            xfichapro.f_Proveedor.RegistroDato.LimpiarRegistro()

            Me.E_CLI_CODIGO.Text = xfichapro.f_Proveedor.RegistroDato._CodigoProveedor
            Me.E_CLI_NOMBRE.Text = xfichapro.f_Proveedor.RegistroDato._NombreRazonSocial
            Me.E_CLI_RIF.Text = xfichapro.f_Proveedor.RegistroDato._CiRif

            IrInicio()
        End Try
    End Sub

    Sub ActualizarDataProveedor()
        CargarFichaProveedor(xfichapro.f_Proveedor.RegistroDato._Automatico)
    End Sub

    Private Sub E_RIF_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles E_RIF.LinkClicked
        If xfichapro.f_Proveedor.RegistroDato._Automatico <> "" Then
            Dim xficha As New FichaProveedor(xfichapro.f_Proveedor.RegistroDato._Automatico)
            With xficha
                AddHandler ._ActualizarFicha, AddressOf ActualizarDataProveedor
                .ShowDialog()
            End With

            IrInicio()
        End If
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        BusquedaAvanzadaPrd()
    End Sub

    Sub BusquedaAvanzadaPrd()
        Dim xficha As New BusAvanzadaPrd
        With xficha
            AddHandler .LlamarReceptor, AddressOf ReceptorBusAvanzada
            .ShowDialog()
        End With
    End Sub

    Sub ReceptorBusAvanzada(ByVal xsql As String)
        Dim xficha As Plantilla_5
        xficha = New Plantilla_5(New VistaVentas(), xsql)
        With xficha
            AddHandler .CapturarId_Producto, AddressOf CargarProducto
            .ShowDialog()
        End With
    End Sub

    Sub CargarProducto(ByVal xauto As String, ByVal xtipoprecio As String)
        Try
            Dim xcodprv As String = ""
            If CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorCodigoProveedor Then
                xcodprv = Me.MT_BUSCAR.Text
            End If

            xfichaprd.F_BuscarProducto(xauto)
            MiDocumento.ProcesarItem(xfichapro, xfichaprd, xfichaprd.RegistroDato._TasaImpuesto, xfichaprd.RegistroDato._TipoImpuesto.ToString, xcodprv)
            'TasaImpuesto, TipoImpuesto, 
            IrInicio()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarTabla()
        MiFichaDoc._RegistrosEnTabla = MiDocumento.CantidadRegistrosTablaData(g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario)
        MiDocumento.ActualizarTablaData(MiFichaDoc._TablaData, g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario)
        Me.E_LINEAS.Text = MiFichaDoc._Lineas.ToString
        Me.E_KILOS.Text = String.Format("{0:#0.000}", MiFichaDoc._Kilos)
        Me.E_ITEMS.Text = MiFichaDoc._Items.ToString
        Me.E_SUBTOTAL.Text = String.Format("{0:#0.00}", MiFichaDoc._Subtotal_1)
        Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", MiFichaDoc._SubtotalIva_1)
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", MiFichaDoc._Total_1)
        Me.E_IMP_LICOR.Text = String.Format("{0:#0.00}", MiFichaDoc._MontoImpuestoLicor)

        Dim xtipodoc As String = ""
        Select Case Me.MiDocumento.TipoDocumento._Tipo
            Case TipoDocumentoCompra.Factura
                xtipodoc = "1"
            Case TipoDocumentoCompra.NotaDebito
                xtipodoc = "2"
            Case TipoDocumentoCompra.NotaCredito
                xtipodoc = "3"
            Case TipoDocumentoCompra.OrdenCompra
                xtipodoc = "4"
        End Select

        If MiFichaDoc._AutoOrdenCompra <> "" Then
            If xfichapro IsNot Nothing Then
                If xfichapro.f_Proveedor.RegistroDato._Automatico = "" Then
                    Dim xfichaorden As New FichaCompras.c_Compra
                    xfichaorden.F_CargarCompra(MiFichaDoc._AutoOrdenCompra)
                    CargarFichaProveedor(xfichaorden.RegistroDato._AutoProveedor)
                End If
            End If
        End If

        Dim xp1 As New SqlParameter("@tipo_doc", xtipodoc)
        Me.E_DOC_PENDIENTES.Text = F_GetInteger("select count(*) from temporal_compra_pendiente where tipo_doc=@tipo_doc", xp1).ToString
    End Sub

    Sub EliminarTodosLosItems()
        If MiFichaDoc._Lineas > 0 Or MiFichaDoc._Total_1 > 0 Then
            If MessageBox.Show("Estas Segur De Querer Eliminar Todos Los Item Procesados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xfichatemporal As New FichaCompras.c_TemporalCompra
                    AddHandler xfichatemporal.ActualizarTabla, AddressOf CargarTabla

                    xfichatemporal.F_EliminarTodo(g_ConfiguracionSistema._Id_UnicoDelEquipo, g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario, MiDocumento.TipoDocumento._Tipo)
                    xfichapro.f_Proveedor.RegistroDato.LimpiarRegistro()
                    CargarFichaProveedor(xfichapro.f_Proveedor.RegistroDato._Automatico)

                    MessageBox.Show("Items Eliminados Satisfactoriamente... Ok", "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
        Me.IrInicio()
    End Sub

    Sub EliminarItem()
        If MiFichaDoc._Lineas > 0 Or MiFichaDoc._Total_1 > 0 Then
            If xbs_tabladata.Current IsNot Nothing Then
                Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row

                If MessageBox.Show("Estas Seguro De Querer Eliminar Este Item ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim xfichatemporal As New FichaCompras.c_TemporalCompra
                        xfichatemporal.M_CargarRegistro(xrow)

                        AddHandler xfichatemporal.ActualizarTabla, AddressOf CargarTabla
                        xfichatemporal.F_EliminarRegistro(xfichatemporal.RegistroDato._AutoItem)
                        MessageBox.Show("Item Eliminado Satisfactoriamente... Ok", "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
        Me.IrInicio()
    End Sub

    Private Sub PB_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_7.Click
        EliminarItem()
    End Sub

    Private Sub PB_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_5.Click
        NotasDetallesItem()
    End Sub

    Sub NotasDetallesItem()
        If MiFichaDoc._Lineas > 0 Or MiFichaDoc._Total_1 > 0 Then
            If xbs_tabladata.Current IsNot Nothing Then
                Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row
                Dim xfichatemporal As New FichaCompras.c_TemporalCompra
                xfichatemporal.M_CargarRegistro(xrow)
                Dim xnotas As String = xfichatemporal.RegistroDato._NotasItem

                Dim xficha As New NotasItem(xnotas, xfichatemporal.RegistroDato.c_NotasItem.c_Largo)
                With xficha
                    .ShowDialog()
                    If ._SalidaExitosa Then
                        Try
                            AddHandler xfichatemporal.ActualizarTabla, AddressOf CargarTabla
                            xfichatemporal.F_ActualizarItem_Notas(xfichatemporal.RegistroDato._AutoItem, ._NotasItem)
                            MessageBox.Show("Item Actualizado Satisfactoriamente... Ok", "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                End With
            End If
        End If
        Me.IrInicio()
    End Sub

    Sub ModificarItem()
        Try
            If MiFichaDoc._Lineas > 0 Or MiFichaDoc._Total_1 > 0 Then
                If xbs_tabladata.Current IsNot Nothing Then
                    Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row
                    Dim xnotas As String = xrow("NotasItem")
                    xfichaprd.F_BuscarProducto(xrow("AutoProducto"))
                    MiDocumento.ModificarItem(xrow, xfichapro, xfichaprd)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        IrInicio()
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        ModificarItem()
    End Sub

    Private Sub PB_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_4.Click
        AbrirDejar_CtaPendiente()
    End Sub

    Sub AbrirDejar_CtaPendiente()
        Dim xt As Boolean = False

        If xt = False Then
            If MiFichaDoc._Lineas = 0 And MiFichaDoc._Total_1 = 0 Then
                Abrir_CtaPendiente()
                xt = True
            End If
        End If

        If xt = False Then
            If MiFichaDoc._Lineas > 0 Or MiFichaDoc._Total_1 > 0 Then
                Dejar_CtaPendiente()
                xt = True
            End If
        End If
    End Sub

    Sub Abrir_CtaPendiente()
        MiDocumento.AbrirCtasPendientes()
    End Sub

    Sub CargarCtaPendiente(ByVal xauto As String)
        Try
            Dim xtemporal As New FichaCompras.c_TemporalCompra
            AddHandler xtemporal._AbrirPendienteOk, AddressOf CargarTabla
            AddHandler xtemporal._CargarProvCtaPendiente, AddressOf CargarFichaProveedor

            Dim xcta As New FichaCompras.c_TemporalCompra.AbrirCtaPendiente
            With xcta
                ._AutoDocumentoAbrir = xauto
                ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._IDUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
                ._TipoDocumento = Me.MiDocumento.TipoDocumento._Tipo
            End With
            xtemporal.F_AbrirCtaPendiente(xcta)

            IrInicio()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            CargarTabla()
        End Try
    End Sub

    Sub Dejar_CtaPendiente()
        If MessageBox.Show("Estas Seguro De Dejar Esta Cuenta En Pendiente ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Dim xnombre As String = ""
            Dim xficha As New PedirNombre(New Plantilla_PedirNombre_CtaPendienteCompra(xfichapro.f_Proveedor.RegistroDato._NombreRazonSocial))
            With xficha
                .ShowDialog()
                If ._EstatusSalida Then
                    xnombre = ._ValorRetornar
                End If
            End With

            If xnombre <> "" Then
                Try
                    Dim xcta As New FichaCompras.c_TemporalCompra.AgregarPendiente
                    Dim xtemporal As New FichaCompras.c_TemporalCompra
                    AddHandler xtemporal._PendienteOk, AddressOf PendienteOK

                    With xcta
                        ._ANombreDe = xnombre
                        ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                        ._FichaProveedor = xfichapro.f_Proveedor.RegistroDato
                        ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                        ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
                        ._MontoPendiente = MiFichaDoc._Total_1
                        ._TipoDocumento = MiDocumento.TipoDocumento._Tipo
                    End With
                    xtemporal.F_DejarCtaPendiente(xcta)
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                    CargarTabla()
                End Try
            End If
        End If
        IrInicio()
    End Sub

    Sub PendienteOK()
        CargarTabla()
        xfichapro.f_Proveedor.RegistroDato.LimpiarRegistro()
        CargarFichaProveedor(xfichapro.f_Proveedor.RegistroDato._Automatico)
        Funciones.MensajeDeOk("Proceso Realizado Satisfactoriamente...Ok")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub PB_12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_12.Click
        RecuperarDocumento()
    End Sub

    Sub RecuperarDocumento()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VentasAdm_RecuperarDocumentos.F_Permitir()

            If MiFichaDoc._Lineas = 0 And MiFichaDoc._Total_1 = 0 Then
                Dim xficha2 As New RecuperarDocCompra(Me.MiDocumento.TipoDocumento._Tipo)
                AddHandler xficha2._RecuperarDocumento, AddressOf RecuperarDoc
                Dim xficha As New Plant_DocPend_Compras(xficha2)
                With xficha
                    .ShowDialog()
                End With
            Else
                Funciones.MensajeDeAlerta("Para Poder Usar Esta Funcion No Debes Tener Ningun Articulo En Pantalla Procesado...")
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
        IrInicio()
    End Sub

    Sub RecuperarDoc(ByVal x1 As Date, ByVal x2 As String, ByVal x3 As String)
        Try
            Dim xfichatemporal As New FichaCompras.c_TemporalCompra
            Dim xdoc As New FichaCompras.c_TemporalCompra.RecuperarDocumento
            With xdoc
                ._AutoUsuario_Recuperar = x3
                ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                ._FechaMovimiento_Recuperar = x1
                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._IDUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
                ._IdUnico_Recuperar = x2
                ._TipoDocumento_Recuperar = Me.MiDocumento.TipoDocumento._Tipo
            End With

            AddHandler xfichatemporal._RecuperarOK, AddressOf RecuperarOk
            xfichatemporal.F_RecuperarDocumento(xdoc)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
        IrInicio()
    End Sub

    Sub RecuperarOk()
        CargarTabla()
        Funciones.MensajeDeOk("Documento Recuperado Satisfactoriamente...")
    End Sub

    Sub Procesar()
        Try
            If ValidarData Then
                Dim xtotales As New TotalesDoc
                With xtotales
                    ._Exento = xfichdocumento._Exento_1
                    ._Lineas = xfichdocumento._Lineas
                    ._Neto1 = xfichdocumento._Neto1_1
                    ._Neto2 = xfichdocumento._Neto2_1
                    ._Neto3 = xfichdocumento._Neto3_1
                    ._TasaIva1 = xfichdocumento._TasaIva1
                    ._TasaIva2 = xfichdocumento._TasaIva2
                    ._TasaIva3 = xfichdocumento._TasaIva3
                    ._ImpuestoLicor = xfichdocumento._MontoImpuestoLicor
                End With
                xdocumento.ProcesarDocumento(xfichapro.f_Proveedor.RegistroDato, xtotales)
            End If
        Catch ex As Exception
            Me.Focus()
            Me.Select()
            Funciones.MensajeDeError(ex.Message)
        End Try
        IrInicio()
    End Sub

    Function ValidarData() As Boolean
        If MiDocumento.TipoDocumento._Tipo = TipoDocumentoCompra.Factura Then
            If Me.MiFichaDoc._Total_1 > 0 Then
            Else
                Funciones.MensajeDeAlerta("Monto Total Factura No Puede Ser Cero (0), Verifique Por Favor")
                Return False
            End If
        End If

        If xfichapro.f_Proveedor.RegistroDato._Automatico = "" Then
            Funciones.MensajeDeAlerta("Falta Por Indicar El Proveedor A Quien Procesar Dicho Documento")
            Return False
        End If

        Return True
    End Function

    Private Sub PB_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_6.Click
        Procesar()
    End Sub

    Sub ControlInventario()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario.F_Permitir()

            Dim xficha As New FichaProductos
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ControlProveedores()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor.F_Permitir()

            Dim xficha As New FichaProveedor
            With xficha
                .Show()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub PB_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_9.Click
        ControlInventario()
    End Sub

    Private Sub PB_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_10.Click
        ControlProveedores()
    End Sub

    Sub AdmDocumentos()
        Try
            Dim xrevertir As Boolean

            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_AdmDocumentos.F_Permitir()
            If Me.MiFichaDoc._Total_1 > 0 Or Me.MiFichaDoc._Lineas > 0 Then
                xrevertir = False
            Else
                xrevertir = True
            End If

            Dim xclas As AdmDoc_Compras
            xclas = New AdmDoc_Compras(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCompras._Limite_Renglones_AdmDocumentos, _
                                                                      MiDocumento.TipoDocumento._Tipo)
            AddHandler xclas._ActualizarFichaDeCompras, AddressOf CargarTabla
            AddHandler xclas._OrdenTrasladar, AddressOf OrdenCompraTrasladar

            Dim xficha As New AdmDocumentosCompras(xclas, False, xrevertir)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_8.Click
        AdmDocumentos()
    End Sub

    Private Sub IngresarOtroProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarOtroProveedor.Click
        Try
            xfichapro.f_Proveedor.RegistroDato.LimpiarRegistro()

            E_CLI_RIF.Text = ""
            E_CLI_CODIGO.Text = ""
            E_CLI_NOMBRE.Text = ""
            IrInicio()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MT_BUSCAR_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MT_BUSCAR.LostFocus
        If MT_BUSCAR.r_Valor <> "" Then
            If CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorCodBarra Then
                Dim xsql As String = "SELECT auto_producto from productos_alterno where codigo=@data1"
                Dim xp1 As New SqlParameter("@data1", MT_BUSCAR.r_Valor)
                Dim xauto As String = F_GetString(xsql, xp1)
                If xauto = "" Then
                    MessageBox.Show("Codigo De Barra No Encontrado... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    IrInicio()
                Else
                    CargarProducto(xauto, "1")
                End If
            End If

            If CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorCodigoProveedor Then
                If Me.xfichapro.f_Proveedor.RegistroDato._Automatico <> "" Then
                    Dim xsql As String = "SELECT auto_producto from productos_proveedor where codigo=@data1 and auto_proveedor=@data2"
                    Dim xp1 As New SqlParameter("@data1", MT_BUSCAR.r_Valor)
                    Dim xp2 As New SqlParameter("@data2", Me.xfichapro.f_Proveedor.RegistroDato._Automatico)
                    Dim xauto As String = F_GetString(xsql, xp1, xp2)
                    If xauto = "" Then
                        MessageBox.Show("Codigo Proveedor No Encontrado... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        IrInicio()
                    Else
                        CargarProducto(xauto, "1")
                    End If
                Else
                    MessageBox.Show("Proveedor No Seleccionado... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    IrInicio()
                End If
            End If
        End If
    End Sub

    Private Sub E_V_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles E_V_1.Click
        If xbs_tabladata.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario.F_Permitir()

                Dim xficha As New FichaProductos(xbs_tabladata.Current("autoproducto"))
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub PB_11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_11.Click
        g_MiCalculadora = New MiCalculadora.Calc
        g_MiCalculadora.Show()
    End Sub

    Sub OrdenCompraTrasladar(ByVal xautodoc As String)
        Try
            If xautodoc <> "" Then
                If Me.MiFichaDoc._Total_1 > 0 Or Me.MiFichaDoc._Lineas > 0 Then
                    Throw New Exception("Problema Al Cargar Documento Orden De Compra" + vbCrLf + "No Debe Haber Items Procesados")
                Else
                    Dim xdoctrasladar As New FichaCompras.DocumentoOrdenTrasladar
                    With xdoctrasladar
                        ._AutoDocumentoTrasladar = xautodoc
                        ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                        ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                        ._IDUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
                    End With

                    Dim xtrasladar As New FichaCompras
                    AddHandler xtrasladar._CargarProveedor, AddressOf CargarFichaProveedor
                    AddHandler xtrasladar.ActualizarTabla, AddressOf CargarTabla
                    xtrasladar.F_TrasladarOrdenCompra(xdoctrasladar)
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

End Class

Public Interface IPlant_Compra_1
    Class TipoDoc
        Private xtipo As TipoDocumentoCompra
        Private xnombre As String

        Property _Tipo() As TipoDocumentoCompra
            Get
                Return xtipo
            End Get
            Set(ByVal value As TipoDocumentoCompra)
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

    ReadOnly Property TipoDocumento() As TipoDoc
    Property FichaDocumento() As Plant_Compra_1.FichaDoc
    Function ActualizarTablaData(ByRef xtabla As DataTable, ByVal xauto_usuario As String) As Boolean
    Function CantidadRegistrosTablaData(ByVal xauto_usuario As String) As Integer
    Function ProcesarDocumento(ByVal xfichaproveedor As FichaProveedores.c_Proveedor.c_Registro, ByVal xtotales As TotalesDoc) As Boolean
    Function ProcesarItem(ByVal xfichapro As FichaProveedores, ByVal xfichaprd As FichaProducto.Prd_Producto, ByVal tasaImpueto As Single, ByVal tipoImpuesto As String, Optional ByVal xcodigoprv As String = "") As Boolean
    Function ModificarItem(ByVal xrow As DataRow, ByVal xfichapro As FichaProveedores, ByVal xfichaprd As FichaProducto.Prd_Producto) As Boolean
    Function AbrirCtasPendientes() As Boolean
    Function AdmDocumentos() As Boolean

    Event LimpiarFicha()
    Event ItemFueProcesado()
    Event _AbrirPendiente(ByVal auto_doc As String)
End Interface

''
'' COMPRAS
''
Public Class ControlComprasNacionales
    Implements IPlant_Compra_1
    Public Event ItemFueProcesado() Implements IPlant_Compra_1.ItemFueProcesado
    Public Event LimpiarFicha() Implements IPlant_Compra_1.LimpiarFicha
    Public Event _AbrirPendiente(ByVal auto_doc As String) Implements IPlant_Compra_1._AbrirPendiente


    Dim xtipodoc As IPlant_Compra_1.TipoDoc
    Dim xfichadoc As Plant_Compra_1.FichaDoc

    Sub New()
        xtipodoc = New IPlant_Compra_1.TipoDoc With {._Nombre = "Control De Compras Nacionales", ._Tipo = TipoDocumentoCompra.Factura}
    End Sub

    Public Function AbrirCtasPendientes() As Boolean Implements IPlant_Compra_1.AbrirCtasPendientes
        Dim xficha2 As New DocPendCompras
        AddHandler xficha2._CargarPendiente, AddressOf AbrirCta
        Dim xficha As New Plant_DocPend_Compras(xficha2)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AbrirCta(ByVal auto_doc As String)
        RaiseEvent _AbrirPendiente(auto_doc)
    End Sub

    Public Function ActualizarTablaData(ByRef xtabla As System.Data.DataTable, ByVal xauto_usuario As String) As Boolean Implements IPlant_Compra_1.ActualizarTablaData
        Try
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "1")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            g_MiData.F_GetData("select codigo x1, producto x2, cantidad x3, costo_bruto x4, (descuento1+descuento2+descuento3) x5, costo x6, " _
                               + "* from temporal_compra where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario " _
                               + "order by autoitem desc", xtabla, xp1, xp2, xp3)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function CantidadRegistrosTablaData(ByVal xauto_usuario As String) As Integer Implements IPlant_Compra_1.CantidadRegistrosTablaData
        Try
            Dim x As Integer = 0
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "1")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            x = F_GetInteger("select count(*) from temporal_compra where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario", xp1, xp2, xp3)
            Return x
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Property FichaDocumento() As Plant_Compra_1.FichaDoc Implements IPlant_Compra_1.FichaDocumento
        Get
            Return xfichadoc
        End Get
        Set(ByVal value As Plant_Compra_1.FichaDoc)
            xfichadoc = value
        End Set
    End Property

    Public Function ProcesarDocumento(ByVal xfichaproveedor As FichaProveedores.c_Proveedor.c_Registro, ByVal xtotales As TotalesDoc) As Boolean Implements IPlant_Compra_1.ProcesarDocumento
        Dim xficha As ProcesarDoc_Compras
        Dim xtipodoc As New c_ProcesarDoc_Compras(xfichaproveedor, xtotales)
        AddHandler xtipodoc.DocumentoProcesado, AddressOf AvisoFacturaExitosa

        xficha = New ProcesarDoc_Compras(xtipodoc)
        With xficha
            .ShowDialog()
        End With
    End Function

    Public ReadOnly Property TipoDocumento() As IPlant_Compra_1.TipoDoc Implements IPlant_Compra_1.TipoDocumento
        Get
            Return xtipodoc
        End Get
    End Property

    Sub AvisoFacturaExitosa()
        RaiseEvent LimpiarFicha()
    End Sub

    Public Function ProcesarItem(ByVal xfichapro As DataSistema.MiDataSistema.DataSistema.FichaProveedores, ByVal xfichaprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto, ByVal tasaImpuesto As Single, ByVal tipoImpuesto As String, Optional ByVal xcodigoprv As String = "") As Boolean Implements IPlant_Compra_1.ProcesarItem
        Dim xficha As Plant_Compra_Item = Nothing
        Dim ItemProcesar As IItemProcesarCompras = New Item_CompraProcesar
        AddHandler ItemProcesar.ActualizarTabla, AddressOf ItemProcesado

        'If xfichaprd.RegistroDato._TipoImpuesto <> TipoTasaImpuesto.Exento Then
        '    xfichaprd.RegistroDato.SetTasaImpuesto(tasaImpuesto)
        '    xfichaprd.RegistroDato.SetTipoImpuesto(tipoImpuesto)
        'End If

        xficha = New Plant_Compra_Item(xfichaprd, ItemProcesar, xfichapro.f_Proveedor.RegistroDato._Automatico, "1")
        With xficha
            .MT_CODIGO.Text = xcodigoprv
            .ShowDialog()
        End With
    End Function

    Public Function ModificarItem(ByVal xrow As System.Data.DataRow, ByVal xfichapro As DataSistema.MiDataSistema.DataSistema.FichaProveedores, ByVal xfichaprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto) As Boolean Implements IPlant_Compra_1.ModificarItem
        Dim xficha As Plant_Compra_Item = Nothing
        Dim ItemProcesar As IItemProcesarCompras = New Item_ActualizarCompraProcesar(xrow)
        AddHandler ItemProcesar.ActualizarTabla, AddressOf ItemProcesado

        xficha = New Plant_Compra_Item(xfichaprd, ItemProcesar, xfichapro.f_Proveedor.RegistroDato._Automatico, "1")
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub ItemProcesado()
        RaiseEvent ItemFueProcesado()
    End Sub

    Public Function AdmDocumentos() As Boolean Implements IPlant_Compra_1.AdmDocumentos
    End Function

End Class

''
'' ORDEN DE COMPRA
''
Public Class ControlOrdenesCompra
    Implements IPlant_Compra_1

    Public Event ItemFueProcesado() Implements IPlant_Compra_1.ItemFueProcesado
    Public Event LimpiarFicha() Implements IPlant_Compra_1.LimpiarFicha
    Public Event _AbrirPendiente(ByVal auto_doc As String) Implements IPlant_Compra_1._AbrirPendiente

    Dim xtipodoc As IPlant_Compra_1.TipoDoc
    Dim xfichadoc As Plant_Compra_1.FichaDoc


    Sub New()
        xtipodoc = New IPlant_Compra_1.TipoDoc With {._Nombre = "Control De Orden De Compra", ._Tipo = TipoDocumentoCompra.OrdenCompra}
    End Sub

    Public Function AbrirCtasPendientes() As Boolean Implements IPlant_Compra_1.AbrirCtasPendientes
        Dim xficha2 As New DocPendOrdCompra
        AddHandler xficha2._CargarPendiente, AddressOf AbrirCta
        Dim xficha As New Plant_DocPend_Compras(xficha2)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AbrirCta(ByVal auto_doc As String)
        RaiseEvent _AbrirPendiente(auto_doc)
    End Sub

    Public Function ActualizarTablaData(ByRef xtabla As System.Data.DataTable, ByVal xauto_usuario As String) As Boolean Implements IPlant_Compra_1.ActualizarTablaData
        Try
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "4")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            g_MiData.F_GetData("select codigo x1, producto x2, cantidad x3, costo_bruto x4, (descuento1+descuento2+descuento3) x5, costo x6, " _
                               + "* from temporal_compra where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario " _
                               + "order by autoitem desc", xtabla, xp1, xp2, xp3)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function CantidadRegistrosTablaData(ByVal xauto_usuario As String) As Integer Implements IPlant_Compra_1.CantidadRegistrosTablaData
        Try
            Dim x As Integer = 0
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "4")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            x = F_GetInteger("select count(*) from temporal_compra where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario", xp1, xp2, xp3)
            Return x
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Property FichaDocumento() As Plant_Compra_1.FichaDoc Implements IPlant_Compra_1.FichaDocumento
        Get
            Return xfichadoc
        End Get
        Set(ByVal value As Plant_Compra_1.FichaDoc)
            xfichadoc = value
        End Set
    End Property

    Public Function ProcesarDocumento(ByVal xfichaproveedor As DataSistema.MiDataSistema.DataSistema.FichaProveedores.c_Proveedor.c_Registro, ByVal xtotales As TotalesDoc) As Boolean Implements IPlant_Compra_1.ProcesarDocumento
        Dim xficha As ProcesarDoc_Compras
        Dim xtipodoc As New c_ProcesarDoc_OrdenesCompra(xfichaproveedor, xtotales)
        AddHandler xtipodoc.DocumentoProcesado, AddressOf AvisoFacturaExitosa

        xficha = New ProcesarDoc_Compras(xtipodoc)
        With xficha
            .ShowDialog()
        End With
    End Function

    Public ReadOnly Property TipoDocumento() As IPlant_Compra_1.TipoDoc Implements IPlant_Compra_1.TipoDocumento
        Get
            Return xtipodoc
        End Get
    End Property

    Sub AvisoFacturaExitosa()
        RaiseEvent LimpiarFicha()
    End Sub

    Public Function AdmDocumentos() As Boolean Implements IPlant_Compra_1.AdmDocumentos
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_AdmDocumentos.F_Permitir()

            Dim xficha As New AdmDocumentosCompras(New AdmDoc_Compras(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCompras._Limite_Renglones_AdmDocumentos, _
                                                                      TipoDocumentoCompra.OrdenCompra), False, True)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function ProcesarItem(ByVal xfichapro As DataSistema.MiDataSistema.DataSistema.FichaProveedores, ByVal xfichaprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto, ByVal tasaImpueto As Single, ByVal tipoImpuesto As String, Optional ByVal xcodigoprv As String = "") As Boolean Implements IPlant_Compra_1.ProcesarItem
        Dim xficha As Plant_Compra_Item = Nothing
        Dim ItemProcesar As IItemProcesarCompras = New Item_OrdenesCompraProcesar
        AddHandler ItemProcesar.ActualizarTabla, AddressOf ItemProcesado

        xficha = New Plant_Compra_Item(xfichaprd, ItemProcesar, xfichapro.f_Proveedor.RegistroDato._Automatico, "1")
        With xficha
            .MT_CODIGO.Text = xcodigoprv
            .ShowDialog()
        End With
    End Function

    Sub ItemProcesado()
        RaiseEvent ItemFueProcesado()
    End Sub

    Public Function ModificarItem(ByVal xrow As System.Data.DataRow, ByVal xfichapro As DataSistema.MiDataSistema.DataSistema.FichaProveedores, ByVal xfichaprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto) As Boolean Implements IPlant_Compra_1.ModificarItem
        Dim xficha As Plant_Compra_Item = Nothing
        Dim ItemProcesar As IItemProcesarCompras = New Item_ActualizarOrdenesCompraProcesar(xrow)
        AddHandler ItemProcesar.ActualizarTabla, AddressOf ItemProcesado

        xficha = New Plant_Compra_Item(xfichaprd, ItemProcesar, xfichapro.f_Proveedor.RegistroDato._Automatico, "1")
        With xficha
            .ShowDialog()
        End With
    End Function

End Class


'Public Class ControlComprasImportadas
'    Implements IPlantilla_12

'    Dim xtipodoc As IPlantilla_12.TipoDoc

'    Sub New()
'        xtipodoc = New IPlantilla_12.TipoDoc With {._Nombre = "Control De Compras Importadas", ._Tipo = TipoDocumentoCompra.Factura}
'    End Sub

'    Public Function AbrirCtasPendientes() As Boolean Implements IPlantilla_12.AbrirCtasPendientes
'        Dim xficha2 As New AbrirCtaPendientesCompras
'        AddHandler xficha2.AbrirCtaPendiente, AddressOf AbrirCta

'        Dim xficha As New Plantilla_9(xficha2)
'        With xficha
'            .ShowDialog()
'        End With
'    End Function

'    Sub AbrirCta(ByVal xauto_documento As String, ByVal xauto_usuario As String)
'        RaiseEvent AbrirPendiente(xauto_documento, xauto_usuario)
'    End Sub

'    Public Event AbrirPendiente(ByVal xauto_documento As String, ByVal xauto_usuario As String) Implements IPlantilla_12.AbrirPendiente

'    Public Function ActualizarTablaData(ByRef xtabla As System.Data.DataTable, ByVal xauto_usuario As String) As Boolean Implements IPlantilla_12.ActualizarTablaData
'        Try
'            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
'            Dim xp2 As New SqlParameter("@tipodocumento", "1")
'            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

'            g_MiData.F_GetData("select codigo x1, producto x2, cantidad x3, costo_bruto x4, (descuento1+descuento2+descuento3) x5, costo x6, " _
'                               + "* from temporal_compra where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario " _
'                               + "order by autoitem desc", xtabla, xp1, xp2, xp3)
'            Return True
'        Catch ex As Exception
'            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
'            Return False
'        End Try
'    End Function

'    Public Function CantidadRegistrosTablaData(ByVal xauto_usuario As String) As Integer Implements IPlantilla_12.CantidadRegistrosTablaData
'        Try
'            Dim x As Integer = 0
'            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
'            Dim xp2 As New SqlParameter("@tipodocumento", "1")
'            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

'            x = F_GetInteger("select count(*) from temporal_compra where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario", xp1, xp2, xp3)
'            Return x
'        Catch ex As Exception
'            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
'            Return -1
'        End Try
'    End Function

'    Dim xfichadoc As Compra_Plantilla_1.FichaDoc
'    Public Property FichaDocumento() As Compra_Plantilla_1.FichaDoc Implements IPlantilla_12.FichaDocumento
'        Get
'            Return xfichadoc
'        End Get
'        Set(ByVal value As Compra_Plantilla_1.FichaDoc)
'            xfichadoc = value
'        End Set
'    End Property

'    Public Event ItemFueProcesado() Implements IPlantilla_12.ItemFueProcesado

'    Public Event LimpiarFicha() Implements IPlantilla_12.LimpiarFicha

'    Public Function ProcesarDocumento(ByVal xfichaproveedor As FichaProveedores.c_Proveedor.c_Registro, ByVal xtotales As TotalesDoc) As Boolean Implements IPlantilla_12.ProcesarDocumento
'        Dim xficha As ProcesarDoc_Compras
'        Dim xtipodoc As New c_ProcesarDoc_Compras(xfichaproveedor, xtotales)
'        AddHandler xtipodoc.DocumentoProcesado, AddressOf AvisoFacturaExitosa

'        xficha = New ProcesarDoc_Compras(xtipodoc)
'        With xficha
'            .ShowDialog()
'        End With
'    End Function

'    Public Function ProcesarItem(ByVal xfichapro As DataSistema.MiDataSistema.DataSistema.FichaProveedores, ByVal xfichaprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto) As Boolean Implements IPlantilla_12.ProcesarItem
'        Dim xficha As Plantilla_14 = Nothing
'        Dim ItemProcesar As IItemProcesarCompras = New Item_CompraProcesar
'        AddHandler ItemProcesar.ActualizarTabla, AddressOf ItemProcesado

'        xficha = New Plantilla_14(xfichaprd, ItemProcesar, xfichapro.f_Proveedor.RegistroDato._Automatico, "1")
'        With xficha
'            .ShowDialog()
'        End With
'    End Function

'    Sub ItemProcesado()
'        RaiseEvent ItemFueProcesado()
'    End Sub

'    Public ReadOnly Property TipoDocumento() As IPlantilla_12.TipoDoc Implements IPlantilla_12.TipoDocumento
'        Get
'            Return xtipodoc
'        End Get
'    End Property

'    Public Function ModificarItem(ByVal xrow As System.Data.DataRow, ByVal xfichapro As DataSistema.MiDataSistema.DataSistema.FichaProveedores, ByVal xfichaprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto) As Boolean Implements IPlantilla_12.ModificarItem
'        Dim xficha As Plantilla_14 = Nothing
'        Dim ItemProcesar As IItemProcesarCompras = New Item_ActualizarCompraProcesar(xrow)
'        AddHandler ItemProcesar.ActualizarTabla, AddressOf ItemProcesado

'        xficha = New Plantilla_14(xfichaprd, ItemProcesar, xfichapro.f_Proveedor.RegistroDato._Automatico, "1")
'        With xficha
'            .ShowDialog()
'        End With
'    End Function

'    Sub AvisoFacturaExitosa()
'        RaiseEvent LimpiarFicha()
'    End Sub

'    Public Function AdmDocumentos() As Boolean Implements IPlantilla_12.AdmDocumentos
'        Try
'            'g_MiData.f_FichaGlobal.f_PermisosUsuario.op_AdmDocumentos_Ventas.F_Permitir()

'            'Dim xficha As New AdmDocumentos(New AdmDoc_Compras(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_AdmDocumentos))
'            'With xficha
'            '    .ShowDialog()
'            'End With

'            Dim xficha As New AdmDocumentosCompras(New AdmDoc_Compras(1000), False, True)
'            With xficha
'                .ShowDialog()
'            End With
'        Catch ex As Exception
'            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Function
'End Class