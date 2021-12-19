Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plantilla_6
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
        Private xProductosRestringido As Boolean

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
                    Me._HayProductosRestringido = False

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
                'Return Decimal.Round(xexento_1, 2, MidpointRounding.AwayFromZero)
                Return xexento_1
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
                'Return Decimal.Round(xneto1_1, 2, MidpointRounding.AwayFromZero)
                Return xneto1_1
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
                'Return Decimal.Round(xiva1_1, 2, MidpointRounding.AwayFromZero)
                Return xiva1_1
            End Get
        End Property

        ''' <summary>
        ''' Retorna Neto/Base #2, antes de los descuentos o cargos globales
        ''' </summary>
        Property _Neto2_1() As Decimal
            Get
                'Return Decimal.Round(xneto2_1, 2, MidpointRounding.AwayFromZero)
                Return xneto2_1
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
                'Return Decimal.Round(xiva2_1, 2, MidpointRounding.AwayFromZero)
                Return xiva2_1
            End Get
        End Property

        ''' <summary>
        ''' Retorna Neto/Base #3, antes de los descuentos o cargos globales
        ''' </summary>
        Property _Neto3_1() As Decimal
            Get
                'Return Decimal.Round(xneto3_1, 2, MidpointRounding.AwayFromZero)
                Return xneto3_1
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
                'Return Decimal.Round(xiva3_1, 2, MidpointRounding.AwayFromZero)
                Return xiva3_1
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

        Property _HayProductosRestringido() As Boolean
            Get
                Return xProductosRestringido
            End Get
            Set(ByVal value As Boolean)
                xProductosRestringido = value
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
            Me._HayProductosRestringido = False

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
            Me._HayProductosRestringido = False

            If Me._TablaData.Rows.Count >= Me._RegistrosEnTabla Then
                For Each xrow As DataRow In Me._TablaData.Rows
                    Dim xfichatemp As New FichaVentas.V_TemporalVenta
                    xfichatemp.M_CargarRegistro(xrow)

                    If xfichatemp.RegistroDato._RestringidoVenta = TipoSiNo.Si Then
                        Me._HayProductosRestringido = True
                    End If

                    If xfichatemp.RegistroDato._EsPesado = "1" Then
                        Me._Kilos += xfichatemp.RegistroDato._CantidadDespachar
                        Me._Items += 1
                    Else
                        Me._Items += xfichatemp.RegistroDato._CantidadDespachar
                    End If
                    Select Case xfichatemp.RegistroDato._TipoTasa
                        Case "0"
                            Me._Exento_1 += xfichatemp.RegistroDato._Importe
                        Case "1"
                            Me._Neto1_1 += xfichatemp.RegistroDato._Importe
                        Case "2"
                            Me._Neto2_1 += xfichatemp.RegistroDato._Importe
                        Case "3"
                            Me._Neto3_1 += xfichatemp.RegistroDato._Importe
                    End Select
                    Me._Lineas += 1
                Next
            End If
        End Sub
    End Class

    Dim pb_tm As Size
    Dim xdocumento As IPlantilla_6

    Dim xfichaprd As FichaProducto.Prd_Producto
    Dim xfichacli As FichaClientes
    Dim xfichdocumento As FichaDoc
    Dim xfichatem As FichaVentas.V_TemporalVenta
    Dim xbs_tabladata As BindingSource
    Dim xcantidad_personas_evento As Integer

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
    Property MiDocumento() As IPlantilla_6
        Get
            Return xdocumento
        End Get
        Set(ByVal value As IPlantilla_6)
            xdocumento = value
        End Set
    End Property

    Property _CantidadPersonasEventoPresupuesto() As Integer
        Get
            Return xcantidad_personas_evento
        End Get
        Set(ByVal value As Integer)
            xcantidad_personas_evento = value
        End Set
    End Property

    Sub New(ByVal xtipoplantilla As IPlantilla_6)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        MiDocumento = xtipoplantilla
        AddHandler MiDocumento.LimpiarFichaVenta, AddressOf LimpiarFicha
        AddHandler MiDocumento.ItemFueProcesado, AddressOf CargarTabla
        AddHandler MiDocumento.AbrirPendiente, AddressOf AbrirCta

        'Usada Para La Elabracion De Presupuesto Tipo Evento
        _CantidadPersonasEventoPresupuesto = 0
    End Sub

    Sub LimpiarFicha()
        CargarTabla()

        ULTIMABUSQUEDA = ""
        Me._CantidadPersonasEventoPresupuesto = 0
        Me.MiDocumento.CantidadPersonasEvento = Me._CantidadPersonasEventoPresupuesto

        xfichacli.f_Clientes.RegistroDato.M_LimpiarRegistro()
        CargarFichaCliente(xfichacli.f_Clientes.RegistroDato.r_Automatico)
        If g_VisorPrecio IsNot Nothing Then
            g_VisorPrecio.Texto("Bienvenido", "Proximo Cliente !")
        End If
    End Sub

    Private Sub PB_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseEnter, PB_2.MouseEnter, PB_3.MouseEnter, PB_4.MouseEnter, _
                PB_5.MouseEnter, PB_6.MouseEnter, PB_7.MouseEnter, PB_8.MouseEnter, PB_9.MouseEnter, PB_10.MouseEnter, _
                PB_11.MouseEnter, PB_12.MouseEnter, PB_13.MouseEnter

        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseHover, PB_2.MouseHover, PB_3.MouseHover, PB_4.MouseHover, _
                PB_5.MouseHover, PB_6.MouseHover, PB_7.MouseHover, PB_8.MouseHover, PB_9.MouseHover, PB_10.MouseHover, _
                PB_11.MouseHover, PB_12.MouseHover, PB_13.MouseHover

        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseLeave, PB_2.MouseLeave, PB_3.MouseLeave, _
                PB_4.MouseLeave, PB_5.MouseLeave, PB_6.MouseLeave, PB_7.MouseLeave, PB_8.MouseLeave, PB_9.MouseLeave, PB_10.MouseLeave, _
                PB_11.MouseLeave, PB_12.MouseLeave, PB_13.MouseLeave

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

    Private Sub Plantilla_6_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MiFichaDoc._Total_1 = 0 And MiFichaDoc._Items = 0 Then
            e.Cancel = False
        Else
            EliminarTodosLosItems()
            e.Cancel = True
        End If
    End Sub

    Private Sub Plantilla_6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = True And e.Control = False) Then
            If ULTIMABUSQUEDA <> "" Then
                Me.MT_BUSCAR.Text = ULTIMABUSQUEDA
                BuscarProducto()
            End If
        End If

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
            BuscarCliente()
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
            ControlClientes()
        End If
        If e.KeyCode = Keys.D3 AndAlso (e.Alt = True And e.Control = False) Then
            RecuperarDocumento()
        End If

        If e.KeyCode = Keys.N AndAlso (e.Alt = True And e.Control = True) Then
            If MiDocumento.ActivarChimbo Then
                MiFichaDoc._DocChimbo = Not MiFichaDoc._DocChimbo
                ActivarVentaChimba()
            End If
        End If

    End Sub

    Sub ActivarVentaChimba()
        If MiDocumento.ActivarChimbo Then
            If MiFichaDoc._DocChimbo Then
                Me.Panel1.BackColor = Color.Maroon
            Else
                Me.Panel1.BackColor = Color.MidnightBlue
            End If
        End If
    End Sub

    Sub IrSeleccionTipoBusqueda()
        Me.MCB_BUSQUEDA.Focus()
    End Sub

    Private Sub Plantilla_6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_tm = PB_1.Size

        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub Plantilla_6_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
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

        Me.E_CLI_CODIGO.Text = xfichacli.f_Clientes.RegistroDato.r_CodigoCliente
        Me.E_CLI_NOMBRE.Text = xfichacli.f_Clientes.RegistroDato.r_NombreRazonSocial
        Me.E_CLI_RIF.Text = xfichacli.f_Clientes.RegistroDato.r_CiRif

        Me.E_ITEMS.Text = MiFichaDoc._Items.ToString
        Me.E_KILOS.Text = String.Format("{0:#0.000}", MiFichaDoc._Kilos)
        Me.E_LINEAS.Text = MiFichaDoc._Items.ToString
        Me.E_TOTAL.Text = String.Format("{0:#0.00}", MiFichaDoc._Total_1)
        Me.E_SUBTOTAL.Text = String.Format("{0:#0.00}", MiFichaDoc._Subtotal_1)
        Me.E_IMPUESTO.Text = String.Format("{0:#0.00}", MiFichaDoc._SubtotalIva_1)
        Me.E_DOC_PENDIENTES.Text = "0"

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
            .Columns.Add("col3", "P/Neto")
            .Columns.Add("col4", "Dto %")
            .Columns.Add("col5", "Iva %")
            .Columns.Add("col6", "Importe")

            .Columns(0).Width = 80
            .Columns(2).Width = 80
            .Columns(3).Width = 120
            .Columns(4).Width = 70
            .Columns(5).Width = 70
            .Columns(6).Width = 120
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            CargarTabla()
            .DataSource = xbs_tabladata
            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(2).DataPropertyName = "x3"
            .Columns(3).DataPropertyName = "x4"
            .Columns(4).DataPropertyName = "x5"
            .Columns(5).DataPropertyName = "x6"
            .Columns(6).DataPropertyName = "x7"
            AddHandler .CellFormatting, AddressOf MiFormato

            .Ocultar(8)
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

    Sub Inicializa()
        Try
            xfichatem = New FichaVentas.V_TemporalVenta
            xfichaprd = New FichaProducto.Prd_Producto
            xfichacli = New FichaClientes

            MiFichaDoc = New FichaDoc
            AddHandler MiFichaDoc.FichaEnCero, AddressOf ActivarVentaChimba

            xbs_tabladata = New BindingSource(MiFichaDoc._TablaData, "")
            AddHandler xbs_tabladata.PositionChanged, AddressOf ActualizarVistaItem
            ActualizaVistaItem()

            InicializarPantalla()
            Me.MiDocumento.Inicializa(Me, _CantidadPersonasEventoPresupuesto)

            If g_VisorPrecio IsNot Nothing Then
                g_VisorPrecio.Texto("Bienvenido", "Proximo Cliente")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub ActualizarVistaItem()
        ActualizaVistaItem()
    End Sub

    Sub ActualizaVistaItem()
        If xbs_tabladata.Current IsNot Nothing Then
            Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row
            xfichatem.M_CargarRegistro(xrow)
            Me.E_V_1.Text = xfichatem.RegistroDato._NombreProducto
            Me.E_V_2.Text = xfichatem.RegistroDato._CodigoProducto
            Me.E_V_7.Text = xfichatem.RegistroDato._NombreEmpaque
            Me.E_V_4.Text = xfichatem.RegistroDato._Importe
            Me.E_V_3.Text = xfichatem.RegistroDato._ContenidoEmpaque
            Me.E_V_5.Text = xfichatem.RegistroDato._PSugerido
            Me.E_V_6.Text = xfichatem.RegistroDato._PLiquidaFullIva
            Me.E_V_8.Text = xfichatem.RegistroDato._DsctoMonto
            Me.E_V_9.Text = xfichatem.RegistroDato._Impuesto
            Me.E_V_10.Text = xfichatem.RegistroDato._Total
            Me.E_PFINAL.Text = xfichatem.RegistroDato._PFinal
            Me.E_PNETO.Text = xfichatem.RegistroDato._PrecioNeto
            Me.E_PFULL.Text = xfichatem.RegistroDato._PFinalFullIva
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

    Private Sub MCB_BUSQUEDA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSQUEDA.SelectedIndexChanged
        If Me.MCB_BUSQUEDA.SelectedIndex = 7 Then
            MessageBox.Show("Alerta... Esta Opcion Solo Esta Disponible Para El Modulo De Compras", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.MCB_BUSQUEDA.SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProducto
        End If
        IrInicio()
    End Sub

    Private Sub BT_BUSCAR_PRD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR_PRD.Click
        'For Each row In MiFichaDoc._TablaData.Rows
        '    If row("n_autodoc_origen").ToString.Trim <> "" Then
        '        Return
        '    End If
        'Next

        BuscarProducto()
    End Sub

    Dim ULTIMABUSQUEDA As String

    Sub BuscarProducto()
        If MT_BUSCAR.r_Valor <> "" Then
            ULTIMABUSQUEDA = MT_BUSCAR.r_Valor

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
                Case Else
                    ULTIMABUSQUEDA = ""
            End Select

            If CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorCodBarra Then
                'PARA BUSQUEDA DE PRODUCTOS RAPIDAS
                Const Busqueda_1 As String = "SELECT p.nombre xnom, p.codigo xcod, p.tasa xtas, p.plu xplu, p.psv, p.auto, p.estatus,p.referencia xref, " _
                                      + "p.contenido_empaque xempcompra, pdep.nombre ndep, pgrp.nombre ngrp, pmar.nombre nmar, pmed.nombre nmed, pmed.decimales xdec " _
                                      + "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto join productos_grupo pgrp on p.auto_grupo=pgrp.auto " _
                                      + "join productos_marca pmar on p.auto_marca=pmar.auto join productos_medida pmed on p.auto_medida_compra=pmed.auto " _
                                      + "where p.auto in (select auto_producto from productos_alterno where codigo=@data1);" _
                                      + "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                                      + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                                      + "where pd.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                                      + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                                      + "where p.auto in (select auto_producto from productos_alterno where codigo=@data2));" _
                                      + "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, pe.*, pm.* " _
                                      + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
                                      + "where pe.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                                      + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                                      + "where p.auto in (select auto_producto from productos_alterno where codigo=@data3))  ORDER BY PE.REFERENCIA"

                xsql = Busqueda_1
                xbuscar = MT_BUSCAR.r_Valor

                xp1 = New SqlParameter("@data1", xbuscar)
                xp2 = New SqlParameter("@data2", xbuscar)
                xp3 = New SqlParameter("@data3", xbuscar)
                xp4 = New SqlParameter
            Else
                If CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorSerial Then
                    Dim Tipobusq As String = ""
                    xsql = Tipobusq
                    xp1 = New SqlParameter
                    xp2 = New SqlParameter
                    xp3 = New SqlParameter
                    xp4 = New SqlParameter
                Else
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

                    ''SIN LIMITE 
                    '"SELECT p.nombre xnom, p.codigo xcod, p.tasa xtas, p.plu xplu, p.psv, p.auto, p.estatus,p.referencia xref, " _
                    '            + "p.contenido_empaque xempcompra, pdep.nombre ndep, pgrp.nombre ngrp, pmar.nombre nmar, pmed.nombre nmed, pmed.decimales xdec " _
                    '            + "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto join productos_grupo pgrp on p.auto_grupo=pgrp.auto " _
                    '            + "join productos_marca pmar on p.auto_marca=pmar.auto join productos_medida pmed on p.auto_medida_compra=pmed.auto " _
                    '            + "where p." + TipoB + " like @data1 and p.estatus_departamento='0' order by p." + TipoB + ";" _
                    '            + "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                    '            + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                    '            + "where pd.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                    '            + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                    '            + "where p." + TipoB + " like @data2 and p.estatus_departamento='0');" _
                    '            + "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, pe.*, pm.* " _
                    '            + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
                    '            + "where pe.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                    '            + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                    '            + "where p." + TipoB + " like @data3 and p.estatus_departamento='0')  ORDER BY PE.REFERENCIA"
                    xsql = TipoBusq

                    If MT_BUSCAR.Text.Substring(0, 1) = "*" Then
                        xbuscar = "%" + MT_BUSCAR.r_Valor.Substring(1)
                    Else
                        xbuscar = MT_BUSCAR.r_Valor
                    End If

                    xp1 = New SqlParameter("@data1", xbuscar + "%")
                    xp2 = New SqlParameter("@data2", xbuscar + "%")
                    xp3 = New SqlParameter("@data3", xbuscar + "%")
                    xp4 = New SqlParameter("@limite", g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._LimiteProductosMostrar_AdmBusquedaNormal)
                End If
            End If

            If xsql.Trim <> "" Then
                Dim xficha As Plantilla_5
                If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
                    xficha = New Plantilla_5(New VistaVentas(xfichacli.f_Clientes.RegistroDato.r_TipoPrecioFijado), xsql, xp1, xp2, xp3, xp4)
                Else
                    xficha = New Plantilla_5(New VistaVentas(), xsql, xp1, xp2, xp3, xp4)
                End If
                With xficha
                    .ShowDialog()
                    If ._AutoItem_Devolver <> "" Then
                        CargarProducto(._AutoItem_Devolver, .TipoPrecio)
                    Else
                        ULTIMABUSQUEDA = ""
                    End If
                End With
            End If

            Me.MT_BUSCAR.Text = ""
        End If
        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()

        Me.Select()
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        Dim seguir As Boolean = True
        If MiDocumento.TipoDocumento._Tipo = TipoDocumentoVenta.Factura Then
            If BLOQUEAR_VENTAS Then
                If MiFichaDoc._HayProductosRestringido = False Then
                Else
                    seguir = False
                End If
            Else
                seguir = False
                BuscarCliente()
            End If
        Else
            seguir = False
            BuscarCliente()
        End If

        If seguir Then
            If xfichacli.f_Clientes.RegistroDato.r_Automatico = "" Then
                Dim xficha1 As New EntradaClienteBasico
                With xficha1
                    AddHandler .ActualizarFichaCliente, AddressOf CargarFichaCliente
                    .ShowDialog()
                End With
            End If
        End If
    End Sub

    Sub BuscarCliente()
        Dim xficha As New Plantilla_7
        With xficha
            AddHandler .BuscarCliente, AddressOf CargarFichaCliente
            .ShowDialog()
        End With
    End Sub

    Sub CargarFichaCliente(ByVal xauto As String)
        Try
            Dim PermitirFact As Boolean = True

            'If MiDocumento.TipoDocumento._Tipo = TipoDocumentoVenta.Factura Then
            '    If BLOQUEAR_VENTAS Then
            '        Dim res = xfichacli.F_BuscarUltimasVentas(xauto)
            '        If res.Count > 0 Then
            '            If res(0).DiasTranscurridos <= PERIODO_VENTA_TRANSCURRIR Then
            '                Dim text As String = "Ultima Factura Procesada El Día: " + res(0).FechaEmision.ToShortDateString & _
            '                 vbCrLf + "Documento Nro: " + res(0).FacturaNro & _
            '                 vbCrLf + "Por Monto Bs: " + res(0).Monto.ToString & _
            '                 vbCrLf + "Dias Transcurridos: " + res(0).DiasTranscurridos.ToString & _
            '                 vbCrLf + "Permitir Facturar ?"
            '                If MessageBox.Show(text, "*** Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            '                    PermitirFact = False
            '                End If
            '            End If
            '        End If
            '    End If
            'End If

            If PermitirFact = True Then
                xfichacli.F_BuscarCliente(xauto)

                If xfichacli.f_Clientes.RegistroDato.r_EstatusDelCliente = TipoEstatus.Inactivo Then
                    Funciones.MensajeDeAlerta("Cliente Seleccionado En Estado Inactivo / Suspendido, Verifique Por Favor...")
                    Throw New Exception
                End If

                Me.E_CLI_CODIGO.Text = xfichacli.f_Clientes.RegistroDato.r_CodigoCliente
                Me.E_CLI_NOMBRE.Text = xfichacli.f_Clientes.RegistroDato.r_NombreRazonSocial
                Me.E_CLI_RIF.Text = xfichacli.f_Clientes.RegistroDato.r_CiRif

                If xfichacli.f_Clientes.RegistroDato.r_Advertencias <> "" Then
                    Dim xficha As New MostrarAdvertencias(xfichacli.f_Clientes.RegistroDato.r_Advertencias)
                    With xficha
                        .ShowDialog()
                    End With
                    Me.PB_ADVERTENCIAS.Visible = True
                Else
                    Me.PB_ADVERTENCIAS.Visible = False
                End If
            End If

        Catch ex As Exception
            xfichacli.f_Clientes.RegistroDato.M_LimpiarRegistro()

            Me.E_CLI_CODIGO.Text = xfichacli.f_Clientes.RegistroDato.r_CodigoCliente
            Me.E_CLI_NOMBRE.Text = xfichacli.f_Clientes.RegistroDato.r_NombreRazonSocial
            Me.E_CLI_RIF.Text = xfichacli.f_Clientes.RegistroDato.r_CiRif
            Me.PB_ADVERTENCIAS.Visible = False

            IrInicio()
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
        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            xficha = New Plantilla_5(New VistaVentas(xfichacli.f_Clientes.RegistroDato.r_TipoPrecioFijado), xsql)
        Else
            xficha = New Plantilla_5(New VistaVentas(), xsql)
        End If
        With xficha
            AddHandler .CapturarId_Producto, AddressOf CargarProducto
            .ShowDialog()
        End With
    End Sub

    Sub CargarProducto(ByVal xauto As String, ByVal xtipoprecio As String)
        Try
            Dim xs As Boolean = True

            If MiFichaDoc._DocChimbo = True Or xdocumento.TipoDocumento._Tipo = TipoDocumentoVenta.Presupuesto _
              Or xdocumento.TipoDocumento._Tipo = TipoDocumentoVenta.Pedido Or xdocumento.TipoDocumento._Tipo = TipoDocumentoVenta.NotaEntrega Then
            Else
                If xdocumento.LimiteItemsProcesar = 0 Then
                Else
                    'If MiFichaDoc._Lineas >= xdocumento.LimiteItemsProcesar Then
                    '    xs = False
                    '    Funciones.MensajeDeAlerta("Has Superado El Limite De Renglones Permitidos... Verifique Por Favor")
                    'End If
                End If
            End If

            If xs Then
                xfichaprd.F_BuscarProducto(xauto)
                If xfichaprd.RegistroDato._EstatusProducto Then

                    If MiDocumento.TipoDocumento._Tipo = TipoDocumentoVenta.Factura Then
                        If BLOQUEAR_VENTAS Then

                            If xfichaprd.RegistroDato._EstaRestringidoVenta = TipoSiNo.Si Then
                                If xfichacli.f_Clientes.RegistroDato.r_Automatico = "" Then
                                    Throw New Exception("PRODUCTO RESTRINGIDO PARA LA VENTA, DEBES SELECCIONAR UN CLIENTE POR FAVOR")
                                End If

                                Dim res = xfichacli.F_BuscarUltimasVentas(xfichacli.f_Clientes.RegistroDato.r_Automatico, xauto)
                                If res.Count > 0 Then
                                    If res(0).DiasTranscurridos <= PERIODO_VENTA_TRANSCURRIR Then
                                        Dim text As String = "Ultima Factura Procesada El Día: " + res(0).FechaEmision.ToShortDateString & _
                                         vbCrLf + "Documento Nro: " + res(0).FacturaNro & _
                                         vbCrLf + "Por Monto Bs: " + res(0).Monto.ToString & _
                                         vbCrLf + "Dias Transcurridos: " + res(0).DiasTranscurridos.ToString & _
                                         vbCrLf + "Cantidad Despachada: " + res(0).Cantidad.ToString & _
                                         vbCrLf + "Permitir Facturar ?"
                                        If MessageBox.Show(text, "*** Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                        Else
                                            Throw New Exception("NO SE PUEDE DESPACHAR, PRODUCTO RESTRINGIDO")
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    MiDocumento.ProcesarItem(xfichacli, xfichaprd, xtipoprecio, _CantidadPersonasEventoPresupuesto)
                Else
                    Throw New Exception("Producto En Estado Inactivo, Verifique Por Favor")
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
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

        Dim xtipodoc As String = ""
        Select Case Me.MiDocumento.TipoDocumento._Tipo
            Case TipoDocumentoVenta.Factura
                xtipodoc = "1"
            Case TipoDocumentoVenta.NotaEntrega
                xtipodoc = "2"
            Case TipoDocumentoVenta.Presupuesto
                xtipodoc = "3"
            Case TipoDocumentoVenta.Pedido
                xtipodoc = "4"
        End Select

        Dim xp1 As New SqlParameter("@tipo_doc", xtipodoc)
        Me.E_DOC_PENDIENTES.Text = F_GetInteger("select count(*) from temporalventa_pendiente where tipo_doc=@tipo_doc", xp1).ToString
    End Sub

    Sub EliminarTodosLosItems()
        If MiFichaDoc._Lineas > 0 Or MiFichaDoc._Total_1 > 0 Then
            If MessageBox.Show("Estas Segur De Querer Eliminar Todos Los Item Procesados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xfichatemporal As New FichaVentas.V_TemporalVenta
                    AddHandler xfichatemporal.ActualizarTabla, AddressOf CargarTabla

                    xfichatemporal.F_EliminarTodo(g_ConfiguracionSistema._Id_UnicoDelEquipo, g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario, MiDocumento.TipoDocumento._Tipo)
                    xfichacli.f_Clientes.RegistroDato.M_LimpiarRegistro()
                    CargarFichaCliente(xfichacli.f_Clientes.RegistroDato.r_Automatico)

                    If g_VisorPrecio IsNot Nothing Then
                        g_VisorPrecio.Texto("Bienvenido", "Proximo Cliente")
                    End If

                    ULTIMABUSQUEDA = ""
                    Me._CantidadPersonasEventoPresupuesto = 0
                    Me.MiDocumento.CantidadPersonasEvento = Me._CantidadPersonasEventoPresupuesto

                    Funciones.MensajeDeAlerta("Items Eliminados Satisfactoriamente...")
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        End If
        Me.IrInicio()
    End Sub

    Sub EliminarItem()
        If MiFichaDoc._Lineas > 0 Or MiFichaDoc._Total_1 > 0 Then
            If xbs_tabladata.Current IsNot Nothing Then
                Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row

                'If xrow("n_autodoc_origen").ToString.Trim <> "" Then
                '    Return
                'End If

                Dim xr As Boolean = False
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Confirmar_Eliminar_Item Then
                    If MessageBox.Show("Estas Seguro De Querer Eliminar Este Item ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        xr = True
                    End If
                Else
                    xr = True
                End If

                If xr Then
                    Try
                        Dim xfichatemporal As New FichaVentas.V_TemporalVenta
                        xfichatemporal.M_CargarRegistro(xrow)

                        AddHandler xfichatemporal.ActualizarTabla, AddressOf CargarTabla
                        xfichatemporal.F_EliminarRegistro(xfichatemporal.RegistroDato._AutoItem)
                        Funciones.MensajeDeOk("Item Eliminado Satisfactoriamente...")

                        If g_VisorPrecio IsNot Nothing Then
                            g_VisorPrecio.Venta(xfichatemporal.RegistroDato._NombreProducto, xfichatemporal.RegistroDato._PrecioNeto, xfichatemporal.RegistroDato._CantidadDespachar, 1)
                        End If

                    Catch ex As Exception
                        Funciones.MensajeDeError(ex.Message)
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

                If xrow("n_autodoc_origen").ToString.Trim <> "" Then
                    Return
                End If

                Dim xfichatemporal As New FichaVentas.V_TemporalVenta
                xfichatemporal.M_CargarRegistro(xrow)
                Dim xnotas As String = xfichatemporal.RegistroDato._ItemNotas

                Dim xficha As New NotasItem(xnotas, xfichatemporal.RegistroDato.c_ItemNotas.c_Largo)
                With xficha
                    .ShowDialog()
                    If ._SalidaExitosa Then
                        Try
                            AddHandler xfichatemporal.ActualizarTabla, AddressOf CargarTabla
                            xfichatemporal.F_ActualizarItem_Notas(xfichatemporal.RegistroDato._AutoItem, ._NotasItem)
                            Funciones.MensajeDeAlerta("Item Actualizado Satisfactoriamente...")
                        Catch ex As Exception
                            Funciones.MensajeDeError(ex.Message)
                        End Try
                    End If
                End With
            End If
        End If
        Me.IrInicio()
    End Sub

    Sub ModificarItem()
        If MiFichaDoc._Lineas > 0 Or MiFichaDoc._Total_1 > 0 Then
            If xbs_tabladata.Current IsNot Nothing Then
                Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row

                'If xrow("n_autodoc_origen").ToString.Trim <> "" Then
                '    Return
                'End If

                Dim xfichatemporal As New FichaVentas.V_TemporalVenta
                xfichatemporal.M_CargarRegistro(xrow)
                Dim xnotas As String = xfichatemporal.RegistroDato._ItemNotas

                Dim xficha As New ModificarItem(xfichatemporal.RegistroDato._AutoItem)
                With xficha
                    AddHandler .ActualizarTabla, AddressOf CargarTabla
                    .ShowDialog()
                End With
            End If
        End If
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

    Sub AbrirCta(ByVal xautodoc As String, ByVal xautousuario As String)
        Dim xs As Boolean = True
        If xautodoc <> "" And xautousuario <> "" Then
            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Abrir_DocPendientes_OtrosUsuarios Then
            Else
                If xautousuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario Then
                Else
                    Funciones.MensajeDeAlerta("Opcion No Permitida... No Puedes Abrir Documentos De Otros Usuarios, Verifique Por Favor...")
                    xs = False
                End If
            End If
        Else
            xs = False
        End If

        If xs Then
            CargarCtaPendiente(xautodoc)
        End If
    End Sub

    Sub CargarCtaPendiente(ByVal xauto As String)
        Try
            Dim xfichatemporal As New FichaVentas.V_TemporalVentaPendiente
            AddHandler xfichatemporal.ActualizarTabla, AddressOf CargarTabla
            AddHandler xfichatemporal._ActualizarFichaCliente, AddressOf CargarFichaCliente
            xfichatemporal.F_BuscarCargar(xauto)

            Dim xcta As New FichaVentas.V_TemporalVentaPendiente.CtaPendienteAbrir
            With xcta
                ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                ._FichaPendienteAbrir = xfichatemporal.RegistroDato
                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
            End With
            xfichatemporal.F_AbrirCta_Pendiente(xcta)

            If g_VisorPrecio IsNot Nothing Then
                g_VisorPrecio.SubTotal(Me.MiFichaDoc._Total_1)
            End If

            IrInicio()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub Dejar_CtaPendiente()
        If MessageBox.Show("Estas Seguro De Dejar Esta Cuenta En Pendiente ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Dim xnombre As String = ""

            Dim xficha As New PedirNombre(New Plantilla_PedirNombre_CtaPendienteVenta(xfichacli.f_Clientes.RegistroDato.r_NombreRazonSocial))
            With xficha
                .ShowDialog()
                If ._EstatusSalida Then
                    xnombre = ._ValorRetornar
                End If
            End With

            If xnombre <> "" Then
                Dim xfichatemporal As New FichaVentas.V_TemporalVentaPendiente
                AddHandler xfichatemporal.ActualizarTabla, AddressOf CargarTabla

                Try
                    CargarTabla()

                    Dim xdetalles As New List(Of FichaVentas.V_TemporalVenta.c_Registro)
                    For Each xrow In Me.MiFichaDoc._TablaData.Rows
                        Dim xdet As New FichaVentas.V_TemporalVenta.c_Registro
                        xdet.CargarRegistro(xrow)
                        xdetalles.Add(xdet)
                    Next

                    Dim xregistro As New FichaVentas.V_TemporalVentaPendiente.RegistroTemporalPendiente
                    With xregistro
                        ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                        ._FichaCliente = xfichacli.f_Clientes.RegistroDato
                        ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                        ._ListaItems = xdetalles
                        ._NombreCtaPendiente = xnombre
                        ._TipoDocumentoPendiente = Me.MiDocumento.TipoDocumento._Tipo
                    End With

                    If xdetalles.Count > 0 Then
                        xfichatemporal.F_DejarCta_Pendiente(xregistro)

                        xfichacli.f_Clientes.RegistroDato.M_LimpiarRegistro()
                        CargarFichaCliente(xfichacli.f_Clientes.RegistroDato.r_Automatico)
                        Funciones.MensajeDeAlerta("Proceso Realizado Satisfactoriamente...")

                        If g_VisorPrecio IsNot Nothing Then
                            g_VisorPrecio.Texto("Bienvenido", "Proximo Cliente !")
                        End If

                        ULTIMABUSQUEDA = ""
                        Me._CantidadPersonasEventoPresupuesto = 0
                        Me.MiDocumento.CantidadPersonasEvento = Me._CantidadPersonasEventoPresupuesto
                    Else
                        Throw New Exception("ERROR... NO HAY ITEMS PARA SER GUARDADOS EN PENDIENTE, VERIFIQUE SI OTRO USUARIO LOS HA PROCESADO")
                    End If
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        End If
        IrInicio()
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
                Dim xficha2 As New RecuperarDocumentos(Me.MiDocumento.TipoDocumento._Tipo)
                AddHandler xficha2.RecuperarDocumento, AddressOf RecuperarDoc

                Dim xficha As New Plantilla_9(xficha2)
                With xficha
                    .ShowDialog()
                End With
            Else
                Funciones.MensajeDeAlerta("Para Poder Usar Esta Funcion No Debes Tene Ningun Articulo En Pantalla Procesado...")
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
        IrInicio()
    End Sub

    Sub RecuperarDoc(ByVal x1 As Date, ByVal x2 As String, ByVal x3 As String)
        Try
            Dim xfichatemporal As New FichaVentas
            AddHandler xfichatemporal.ActualizarTabla, AddressOf CargarTabla

            Dim xrecuperardoc As New FichaVentas.RecuperarDoc
            With xrecuperardoc
                ._AutoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario
                ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                ._FechaMovimiento = Date.Now
                ._IDUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
                ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
                ._TipoDocumento = Me.MiDocumento.TipoDocumento._Tipo

                ._AutoUsuario_Recuperar = x3
                ._IdUnico_Recuperar = x2
                ._FechaMovimiento_Recuperar = x1
            End With

            xfichatemporal.F_RecuperarDocumento(xrecuperardoc)
            IrInicio()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub Procesar()
        Try
            If Me.MiFichaDoc._Total_1 > 0 Or Me.MiFichaDoc._Lineas > 0 Then
                If xfichacli.f_Clientes.RegistroDato.r_Automatico = "" Then
                    Dim xficha1 As New EntradaClienteBasico
                    With xficha1
                        AddHandler .ActualizarFichaCliente, AddressOf CargarFichaCliente
                        .ShowDialog()
                    End With
                End If

                If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
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
                        ._DocChimbo = xfichdocumento._DocChimbo
                        .Cliente = xfichacli.f_Clientes.RegistroDato
                        .Items = MiFichaDoc._TablaData
                    End With

                    If g_VisorPrecio IsNot Nothing Then
                        g_VisorPrecio.SubTotal(Me.MiFichaDoc._Total_1)
                    End If

                    xdocumento.ProcesarDocumento(xfichacli.f_Clientes.RegistroDato, xtotales)
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
        IrInicio()
    End Sub

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
            Funciones.MensajeDeError(ex.Message)
        End Try
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

    Private Sub PB_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_9.Click
        ControlInventario()
    End Sub

    Private Sub PB_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_10.Click
        ControlClientes()
    End Sub

    Sub CapturarDocumentoAFacturar(ByVal xauto As String)
        Try
            If Me.MiFichaDoc._Total_1 = 0 AndAlso Me.MiFichaDoc._Lineas = 0 Then

                Try
                    Dim xdoc As New FichaVentas.V_Ventas
                    Dim xfichatemporal As New FichaVentas
                    Dim xtrasladar As New FichaVentas.TrasladarDocVenta

                    xdoc.F_BuscarDocumento(xauto)
                    If xdoc.RegistroDato._TipoDocumento = FichaVentas.TipoDocumentoVentaRegistrado.Presupuesto Then
                        Dim xdif As Integer = DateDiff(DateInterval.Day, xdoc.RegistroDato._FechaEmision, g_MiData.p_FechaDelMotorBD)
                        If xdif > g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._CantidadDiasPermitos_TrasladarDocumento Then
                            Throw New Exception("ERROR AL CARGAR DOCUMENTO. DIAS DE VIGENCIA DEL DOCUMENTO SUPERO EL LIMITE PERMITIDO")
                        End If
                    End If

                    With xtrasladar
                        Select Case MiDocumento.TipoDocumento._Tipo
                            Case TipoDocumentoVenta.Factura
                                ._TipoDocumentoAGenerar = "1"
                            Case TipoDocumentoVenta.NotaEntrega
                                ._TipoDocumentoAGenerar = "2"
                            Case TipoDocumentoVenta.Presupuesto
                                ._TipoDocumentoAGenerar = "3"
                            Case TipoDocumentoVenta.Pedido
                                ._TipoDocumentoAGenerar = "4"
                        End Select

                        ._AutoDeposito = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoInventarioVentas
                        ._DocumentoTrasladar = xdoc.RegistroDato
                        ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                        ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                        ._IDUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
                    End With

                    ''

                    If xdoc.RegistroDato.EstatusDivisa = "1" Then
                        xtrasladar.setSolicitudDivisa(True)
                        Dim r01 = g_MiData.TasaActualDolar_GetData()
                        If (r01.Result = Resultado.EnumResult.isError) Then
                            Throw New Exception(r01.Mensaje)
                            ''MessageBox.Show(r01.Mensaje, "*** ERROR ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                        xtrasladar.setTasaDivisa(r01.Entidad)
                    End If

                    ''

                    AddHandler xfichatemporal._ActualizarFichaCliente, AddressOf CargarFichaCliente
                    AddHandler xfichatemporal.ActualizarTabla, AddressOf CargarTabla
                    xfichatemporal.F_TrasladarDocumentoAVenta(xtrasladar)

                    If g_VisorPrecio IsNot Nothing Then
                        g_VisorPrecio.SubTotal(Me.MiFichaDoc._Total_1)
                    End If

                    IrInicio()
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try

            Else
                Funciones.MensajeDeAlerta("Problema Al Intentar Cargar Documento... No Debe Haber Ningun Item Procesado, Verifique Por Favor...")
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub AdmDocumentos()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_AdmDocumentos_Ventas.F_Permitir()

            Dim xclas As New AdmDoc_Ventas(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_AdmDocumentos, MiDocumento.TipoDocumento._Tipo)
            AddHandler xclas._TrasladarDocumentoVenta, AddressOf CapturarDocumentoAFacturar
            AddHandler xclas._ActualizarFichaCliente, AddressOf CargarFichaCliente

            Dim xficha As New AdmDocumentos(xclas)
            With xficha
                If MiFichaDoc._Lineas = 0 And MiFichaDoc._Total_1 = 0 Then
                    If MiDocumento.TipoDocumento._Tipo = TipoDocumentoVenta.NotaCredito Then
                        ._HabilitarRevertir = False
                    Else
                        ._HabilitarRevertir = True
                        ._TipoDocumentoRevertir = MiDocumento.TipoDocumento._Tipo
                    End If
                End If
                .ShowDialog()
            End With
            CargarTabla()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_8.Click
        AdmDocumentos()
    End Sub

    Private Sub MT_BUSCAR_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MT_BUSCAR.LostFocus
        If Me.MT_BUSCAR.r_Valor <> "" Then
            If Me.MCB_BUSQUEDA.SelectedIndex = FichaProducto.TipoBusquedaProducto.PorCodBarra Then
                Dim xsql As String = "select auto_producto from productos_alterno where codigo=@codigo"
                Dim xp1 As New SqlParameter("@codigo", Me.MT_BUSCAR.r_Valor)
                Dim xauto As String = ""
                xauto = F_GetString(xsql, xp1)
                If xauto = "" Then
                    MessageBox.Show("Codigo De Barra No Encontrado... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
                        CargarProducto(xauto, xfichacli.f_Clientes.RegistroDato.r_TipoPrecioFijado)
                    Else
                        CargarProducto(xauto, "1")
                    End If
                End If
                Me.MT_BUSCAR.Text = ""
                Me.MT_BUSCAR.Select()
                Me.MT_BUSCAR.Focus()
            End If
        End If
    End Sub

    Private Sub SELECCIONAR_OTRO_CLIENTE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SELECCIONAR_OTRO_CLIENTE.Click
        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            Dim seguir As Boolean = True
            If MiDocumento.TipoDocumento._Tipo = TipoDocumentoVenta.Factura Then
                If BLOQUEAR_VENTAS Then
                    If MiFichaDoc._HayProductosRestringido = False Then
                    Else
                        seguir = False
                    End If
                End If
            End If

            If seguir Then
                xfichacli.f_Clientes.RegistroDato.M_LimpiarRegistro()
                Me.E_CLI_CODIGO.Text = xfichacli.f_Clientes.RegistroDato.r_CodigoCliente
                Me.E_CLI_NOMBRE.Text = xfichacli.f_Clientes.RegistroDato.r_NombreRazonSocial
                Me.E_CLI_RIF.Text = xfichacli.f_Clientes.RegistroDato.r_CiRif
                Me.PB_ADVERTENCIAS.Visible = False
            Else
                MessageBox.Show("NO PUEDES SELECCIONAR OTRO CLIENTE TENIENDO EN PANTALLAS PRODUCTOS RESTRINGIDO", "*** ALERTA ***", MessageBoxButtons.OK)
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

    Private Sub PB_ADVERTENCIAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_ADVERTENCIAS.Click
        If xfichacli.f_Clientes.RegistroDato.r_Advertencias <> "" Then
            Dim xficha As New MostrarAdvertencias(xfichacli.f_Clientes.RegistroDato.r_Advertencias)
            With xficha
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub MT_BUSCAR_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MT_BUSCAR.TextChanged

    End Sub

    Private Sub MisGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MisGrid1.CellContentClick

    End Sub

    Private Sub Panel10_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel10.Paint

    End Sub

    Private Sub IMPORTARDATAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMPORTARDATAToolStripMenuItem.Click
        If Clipboard.ContainsText Then
            Dim r As String = Clipboard.GetText().ToString.Trim
            Dim list As String() = r.Split(vbCrLf + vbCrLf)
            For Each it In list
                Me.MT_BUSCAR.Text = it
                BuscarProducto()
            Next
        End If
    End Sub
End Class

Public Interface IPlantilla_6
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

    WriteOnly Property CantidadPersonasEvento() As Integer
    ReadOnly Property TipoDocumento() As TipoDoc
    ReadOnly Property ActivarChimbo() As Boolean
    Property FichaDocumento() As Plantilla_6.FichaDoc

    Sub Inicializa(ByVal xform As Object, ByRef xcant As Integer)

    Function ActualizarTablaData(ByRef xtabla As DataTable, ByVal xauto_usuario As String) As Boolean
    Function CantidadRegistrosTablaData(ByVal xauto_usuario As String) As Integer
    ReadOnly Property LimiteItemsProcesar() As Integer
    Function ProcesarDocumento(ByVal xfichacliente As FichaClientes.c_Clientes.c_Registro, ByVal xtotales As TotalesDoc) As Boolean
    Function ProcesarItem(ByVal xfichacli As FichaClientes, ByVal xfichaprd As FichaProducto.Prd_Producto, ByVal xtipoprecio As String, ByVal xcantevento As Integer) As Boolean
    Function AbrirCtasPendientes() As Boolean

    Event LimpiarFichaVenta()
    Event ItemFueProcesado()
    Event AbrirPendiente(ByVal xauto_documento As String, ByVal xauto_usuario As String)
End Interface

Public Class ControlVenta
    Implements IPlantilla_6

    Dim xtabla As DataTable
    Dim xtipodoc As IPlantilla_6.TipoDoc
    Public ReadOnly Property TipoDocumento() As IPlantilla_6.TipoDoc Implements IPlantilla_6.TipoDocumento
        Get
            Return xtipodoc
        End Get
    End Property

    Dim xfichadoc As Plantilla_6.FichaDoc
    Public Property FichaDocumento() As Plantilla_6.FichaDoc Implements IPlantilla_6.FichaDocumento
        Get
            Return xfichadoc
        End Get
        Set(ByVal value As Plantilla_6.FichaDoc)
            xfichadoc = value
        End Set
    End Property

    Sub New()
        xtipodoc = New IPlantilla_6.TipoDoc With {._Nombre = "Control De Ventas", ._Tipo = TipoDocumentoVenta.Factura}
    End Sub

    Public Function ActualizarTablaData(ByRef xtabla As System.Data.DataTable, ByVal xauto_usuario As String) As Boolean Implements IPlantilla_6.ActualizarTablaData
        Try
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "1")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            g_MiData.F_GetData("select codigo x1, producto x2, cantidad x3, precioneto x4, descuento x5, tasaiva x6, importe x7, " _
                               + "* from temporalventa where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario " _
                               + "order by autoitem desc", xtabla, xp1, xp2, xp3)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function CantidadRegistrosTablaData(ByVal xauto_usuario As String) As Integer Implements IPlantilla_6.CantidadRegistrosTablaData
        Try
            Dim x As Integer = 0
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "1")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            x = F_GetInteger("select count(*) from temporalventa where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario", xp1, xp2, xp3)
            Return x
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public ReadOnly Property LimiteItemsProcesar() As Integer Implements IPlantilla_6.LimiteItemsProcesar
        Get
            Return g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_Factura
        End Get
    End Property

    Public Function ProcesarDocumento(ByVal xfichacliente As FichaClientes.c_Clientes.c_Registro, ByVal xtotales As TotalesDoc) As Boolean Implements IPlantilla_6.ProcesarDocumento
        Dim xficha As ProcesarDoc
        Dim xtipodoc As New ProcesarDocumentoVenta
        AddHandler xtipodoc.DocumentoProcesado, AddressOf AvisoFacturaExitosa

        xficha = New ProcesarDoc(xtipodoc, xfichacliente, xtotales)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AvisoFacturaExitosa()
        RaiseEvent LimpiarFichaVenta()
    End Sub

    Public Event LimpiarFichaVenta() Implements IPlantilla_6.LimpiarFichaVenta

    Sub ItemProcesado()
        RaiseEvent ItemFueProcesado()
    End Sub

    Public Event ItemFueProcesado() Implements IPlantilla_6.ItemFueProcesado

    Public Function AbrirCtasPendientes() As Boolean Implements IPlantilla_6.AbrirCtasPendientes
        Dim xficha2 As New AbrirCtaPendientesVentas
        AddHandler xficha2.AbrirCtaPendienteVenta, AddressOf AbrirCta

        Dim xficha As New Plantilla_9(xficha2)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AbrirCta(ByVal xauto_documento As String, ByVal xauto_usuario As String)
        RaiseEvent AbrirPendiente(xauto_documento, xauto_usuario)
    End Sub

    Public Event AbrirPendiente(ByVal xauto_documento As String, ByVal xauto_usuario As String) Implements IPlantilla_6.AbrirPendiente

    Public ReadOnly Property ActivarChimbo() As Boolean Implements IPlantilla_6.ActivarChimbo
        Get
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ControlVentasAdministrativa_Chimbas.F_Permitir()
                Return True
            Catch ex As Exception
            End Try
        End Get
    End Property

    Public Sub Inicializa(ByVal xform As Object, ByRef xcant As Integer) Implements IPlantilla_6.Inicializa
    End Sub

    Public Function ProcesarItem(ByVal xfichacli As DataSistema.MiDataSistema.DataSistema.FichaClientes, ByVal xfichaprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto, ByVal xtipoprecio As String, ByVal xcantevento As Integer) As Boolean Implements IPlantilla_6.ProcesarItem
        Dim xficha As Plantilla_8 = Nothing
        Dim ItemProcesar As IItemProcesar = New Item_VentaProcesar
        AddHandler ItemProcesar.ActualizarTabla, AddressOf ItemProcesado

        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            xficha = New Plantilla_8(xfichaprd, ItemProcesar, xfichacli.f_Clientes.RegistroDato.r_TipoPrecioFijado, 0)
        Else
            xficha = New Plantilla_8(xfichaprd, ItemProcesar, xtipoprecio, 0)
        End If
        With xficha
            .ShowDialog()
        End With
    End Function

    Public WriteOnly Property CantidadPersonasEvento() As Integer Implements IPlantilla_6.CantidadPersonasEvento
        Set(ByVal value As Integer)
        End Set
    End Property
End Class

Class ControlPresupuesto
    Implements IPlantilla_6
    Public Event LimpiarFichaVenta() Implements IPlantilla_6.LimpiarFichaVenta

    Dim xtabla As DataTable
    Dim xtipodoc As IPlantilla_6.TipoDoc
    Dim xevento_cantidad As Integer

    Property _EventoCantidad() As Integer
        Get
            Return xevento_cantidad
        End Get
        Set(ByVal value As Integer)
            xevento_cantidad = value
        End Set
    End Property

    Public Function ActualizarTablaData(ByRef xtabla As System.Data.DataTable, ByVal xauto_usuario As String) As Boolean Implements IPlantilla_6.ActualizarTablaData
        Try
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "3")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            g_MiData.F_GetData("select codigo x1, producto x2, cantidad x3, precioneto x4, descuento x5, tasaiva x6, importe x7, " _
                               + "* from temporalventa where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario " _
                               + "order by autoitem desc", xtabla, xp1, xp2, xp3)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function CantidadRegistrosTablaData(ByVal xauto_usuario As String) As Integer Implements IPlantilla_6.CantidadRegistrosTablaData
        Try
            Dim x As Integer = 0
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "3")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            x = F_GetInteger("select count(*) from temporalventa where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario", xp1, xp2, xp3)
            Return x
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Dim xfichadoc As Plantilla_6.FichaDoc
    Public Property FichaDocumento() As Plantilla_6.FichaDoc Implements IPlantilla_6.FichaDocumento
        Get
            Return xfichadoc
        End Get
        Set(ByVal value As Plantilla_6.FichaDoc)
            xfichadoc = value
        End Set
    End Property

    Public ReadOnly Property LimiteItemsProcesar() As Integer Implements IPlantilla_6.LimiteItemsProcesar
        Get
            Return 0
        End Get
    End Property

    Public Function ProcesarDocumento(ByVal xfichacliente As DataSistema.MiDataSistema.DataSistema.FichaClientes.c_Clientes.c_Registro, ByVal xtotales As TotalesDoc) As Boolean Implements IPlantilla_6.ProcesarDocumento
        Dim xficha As ProcesarDoc
        Dim xtipodoc As New ProcesarDocumentoPresupuesto
        AddHandler xtipodoc.DocumentoProcesado, AddressOf AvisoFacturaExitosa

        xficha = New ProcesarDoc(xtipodoc, xfichacliente, xtotales)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AvisoFacturaExitosa()
        _EventoCantidad = 0
        RaiseEvent LimpiarFichaVenta()
    End Sub

    Public ReadOnly Property TipoDocumento() As IPlantilla_6.TipoDoc Implements IPlantilla_6.TipoDocumento
        Get
            Return xtipodoc
        End Get
    End Property

    Sub New()
        xtipodoc = New IPlantilla_6.TipoDoc With {._Nombre = "Control De Presupuesto", ._Tipo = TipoDocumentoVenta.Presupuesto}
    End Sub

    Sub ItemProcesado()
        RaiseEvent ItemFueProcesado()
    End Sub

    Public Event ItemFueProcesado() Implements IPlantilla_6.ItemFueProcesado

    Public Function AbrirCtasPendientes() As Boolean Implements IPlantilla_6.AbrirCtasPendientes
        Dim xficha2 As New AbrirCtaPendientesPresupuesto
        AddHandler xficha2.AbrirCtaPendiente, AddressOf AbrirCta

        Dim xficha As New Plantilla_9(xficha2)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AbrirCta(ByVal xauto_documento As String, ByVal xauto_usuario As String)
        RaiseEvent AbrirPendiente(xauto_documento, xauto_usuario)
    End Sub

    Public Event AbrirPendiente(ByVal xauto_documento As String, ByVal xauto_usuario As String) Implements IPlantilla_6.AbrirPendiente

    Public ReadOnly Property ActivarChimbo() As Boolean Implements IPlantilla_6.ActivarChimbo
        Get
            Return False
        End Get
    End Property

    WithEvents xform As New System.Windows.Forms.Form
    WithEvents pb_13 As New PictureBox

    Public Sub Inicializa(ByVal xf As Object, ByRef xcant_evento As Integer) Implements IPlantilla_6.Inicializa
        _EventoCantidad = xcant_evento
        xform = CType(xf, System.Windows.Forms.Form)
        pb_13 = xform.Controls.Find("PB_13", True)(0)

        pb_13.Visible = True
        pb_13.Enabled = True
    End Sub

    Private Sub pb_13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pb_13.Click
        Dim xficha As New PresupuestoEvento(_EventoCantidad)
        AddHandler xficha._CantidadPersonasEvento, AddressOf EventoGenerar
        With xficha
            .ShowDialog()
        End With
    End Sub

    Sub EventoGenerar(ByVal xcant As Integer)
        _EventoCantidad = xcant
    End Sub

    Public Function ProcesarItem(ByVal xfichacli As DataSistema.MiDataSistema.DataSistema.FichaClientes, ByVal xfichaprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto, ByVal xtipoprecio As String, ByVal xcantevento As Integer) As Boolean Implements IPlantilla_6.ProcesarItem
        Dim xficha As Plantilla_8 = Nothing
        Dim ItemProcesar As IItemProcesar = New Item_PresupuestoProcesar
        AddHandler ItemProcesar.ActualizarTabla, AddressOf ItemProcesado

        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            xficha = New Plantilla_8(xfichaprd, ItemProcesar, xfichacli.f_Clientes.RegistroDato.r_TipoPrecioFijado, _EventoCantidad)
        Else
            xficha = New Plantilla_8(xfichaprd, ItemProcesar, xtipoprecio, _EventoCantidad)
        End If
        With xficha
            .ShowDialog()
        End With
    End Function

    Public WriteOnly Property CantidadPersonasEvento() As Integer Implements IPlantilla_6.CantidadPersonasEvento
        Set(ByVal value As Integer)
            Me._EventoCantidad = value
        End Set
    End Property
End Class

Public Class ControlNotaEntrega
    Implements IPlantilla_6

    Dim xtabla As DataTable
    Dim xtipodoc As IPlantilla_6.TipoDoc
    Public ReadOnly Property TipoDocumento() As IPlantilla_6.TipoDoc Implements IPlantilla_6.TipoDocumento
        Get
            Return xtipodoc
        End Get
    End Property

    Dim xfichadoc As Plantilla_6.FichaDoc
    Public Property FichaDocumento() As Plantilla_6.FichaDoc Implements IPlantilla_6.FichaDocumento
        Get
            Return xfichadoc
        End Get
        Set(ByVal value As Plantilla_6.FichaDoc)
            xfichadoc = value
        End Set
    End Property

    Sub New()
        xtipodoc = New IPlantilla_6.TipoDoc With {._Nombre = "Control De Notas De Entrega", ._Tipo = TipoDocumentoVenta.NotaEntrega}
    End Sub

    Public Function ActualizarTablaData(ByRef xtabla As System.Data.DataTable, ByVal xauto_usuario As String) As Boolean Implements IPlantilla_6.ActualizarTablaData
        Try
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "2")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            g_MiData.F_GetData("select codigo x1, producto x2, cantidad x3, precioneto x4, descuento x5, tasaiva x6, importe x7, " _
                               + "* from temporalventa where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario " _
                               + "order by autoitem desc", xtabla, xp1, xp2, xp3)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function CantidadRegistrosTablaData(ByVal xauto_usuario As String) As Integer Implements IPlantilla_6.CantidadRegistrosTablaData
        Try
            Dim x As Integer = 0
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "2")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            x = F_GetInteger("select count(*) from temporalventa where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario", xp1, xp2, xp3)
            Return x
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public ReadOnly Property LimiteItemsProcesar() As Integer Implements IPlantilla_6.LimiteItemsProcesar
        Get
            Return g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_NotasEntrega
        End Get
    End Property

    Public Function ProcesarDocumento(ByVal xfichacliente As FichaClientes.c_Clientes.c_Registro, ByVal xtotales As TotalesDoc) As Boolean Implements IPlantilla_6.ProcesarDocumento
        Dim xficha As ProcesarDoc
        Dim xtipodoc As New ProcesarDocumentoNotaEntrega
        AddHandler xtipodoc.DocumentoProcesado, AddressOf AvisoFacturaExitosa

        xficha = New ProcesarDoc(xtipodoc, xfichacliente, xtotales)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AvisoFacturaExitosa()
        RaiseEvent LimpiarFichaVenta()
    End Sub

    Public Event LimpiarFichaVenta() Implements IPlantilla_6.LimpiarFichaVenta

    Sub ItemProcesado()
        RaiseEvent ItemFueProcesado()
    End Sub

    Public Event ItemFueProcesado() Implements IPlantilla_6.ItemFueProcesado

    Public Function AbrirCtasPendientes() As Boolean Implements IPlantilla_6.AbrirCtasPendientes
        Dim xficha2 As New AbrirCtaPendientesNotasEntrega
        AddHandler xficha2.AbrirCtaPendiente, AddressOf AbrirCta

        Dim xficha As New Plantilla_9(xficha2)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AbrirCta(ByVal xauto_documento As String, ByVal xauto_usuario As String)
        RaiseEvent AbrirPendiente(xauto_documento, xauto_usuario)
    End Sub

    Public Event AbrirPendiente(ByVal xauto_documento As String, ByVal xauto_usuario As String) Implements IPlantilla_6.AbrirPendiente

    Public ReadOnly Property ActivarChimbo() As Boolean Implements IPlantilla_6.ActivarChimbo
        Get
            Return False
        End Get
    End Property

    Public Sub Inicializa(ByVal xform As Object, ByRef xcant As Integer) Implements IPlantilla_6.Inicializa
    End Sub

    Public Function ProcesarItem(ByVal xfichacli As DataSistema.MiDataSistema.DataSistema.FichaClientes, ByVal xfichaprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto, ByVal xtipoprecio As String, ByVal xcantevento As Integer) As Boolean Implements IPlantilla_6.ProcesarItem
        Dim xficha As Plantilla_8 = Nothing
        Dim ItemProcesar As IItemProcesar = New Item_NotaEntregaProcesar
        AddHandler ItemProcesar.ActualizarTabla, AddressOf ItemProcesado

        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            xficha = New Plantilla_8(xfichaprd, ItemProcesar, xfichacli.f_Clientes.RegistroDato.r_TipoPrecioFijado, 0)
        Else
            xficha = New Plantilla_8(xfichaprd, ItemProcesar, xtipoprecio, 0)
        End If
        With xficha
            .ShowDialog()
        End With
    End Function

    Public WriteOnly Property CantidadPersonasEvento() As Integer Implements IPlantilla_6.CantidadPersonasEvento
        Set(ByVal value As Integer)
        End Set
    End Property
End Class

Public Class ControlPedido
    Implements IPlantilla_6

    Dim xtabla As DataTable
    Dim xtipodoc As IPlantilla_6.TipoDoc
    Public ReadOnly Property TipoDocumento() As IPlantilla_6.TipoDoc Implements IPlantilla_6.TipoDocumento
        Get
            Return xtipodoc
        End Get
    End Property

    Dim xfichadoc As Plantilla_6.FichaDoc
    Public Property FichaDocumento() As Plantilla_6.FichaDoc Implements IPlantilla_6.FichaDocumento
        Get
            Return xfichadoc
        End Get
        Set(ByVal value As Plantilla_6.FichaDoc)
            xfichadoc = value
        End Set
    End Property

    Sub New()
        xtipodoc = New IPlantilla_6.TipoDoc With {._Nombre = "Control De Pedidos", ._Tipo = TipoDocumentoVenta.Pedido}
    End Sub

    Public Function ActualizarTablaData(ByRef xtabla As System.Data.DataTable, ByVal xauto_usuario As String) As Boolean Implements IPlantilla_6.ActualizarTablaData
        Try
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "4")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            g_MiData.F_GetData("select codigo x1, producto x2, cantidad x3, precioneto x4, descuento x5, tasaiva x6, importe x7, " _
                               + "* from temporalventa where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario " _
                               + "order by autoitem desc", xtabla, xp1, xp2, xp3)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function CantidadRegistrosTablaData(ByVal xauto_usuario As String) As Integer Implements IPlantilla_6.CantidadRegistrosTablaData
        Try
            Dim x As Integer = 0
            Dim xp1 As New SqlParameter("@idunico", g_ConfiguracionSistema._Id_UnicoDelEquipo)
            Dim xp2 As New SqlParameter("@tipodocumento", "4")
            Dim xp3 As New SqlParameter("@autousuario", xauto_usuario)

            x = F_GetInteger("select count(*) from temporalventa where idunico=@idunico and tipodocumento=@tipodocumento and autousuario=@autousuario", xp1, xp2, xp3)
            Return x
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public ReadOnly Property LimiteItemsProcesar() As Integer Implements IPlantilla_6.LimiteItemsProcesar
        Get
            Return g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_Factura
        End Get
    End Property

    Public Function ProcesarDocumento(ByVal xfichacliente As FichaClientes.c_Clientes.c_Registro, ByVal xtotales As TotalesDoc) As Boolean Implements IPlantilla_6.ProcesarDocumento
        Dim xficha As ProcesarDoc
        Dim xtipodoc As New ProcesarDocumentoPedido
        AddHandler xtipodoc.DocumentoProcesado, AddressOf AvisoFacturaExitosa

        xficha = New ProcesarDoc(xtipodoc, xfichacliente, xtotales)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AvisoFacturaExitosa()
        RaiseEvent LimpiarFichaVenta()
    End Sub

    Public Event LimpiarFichaVenta() Implements IPlantilla_6.LimpiarFichaVenta

    Sub ItemProcesado()
        RaiseEvent ItemFueProcesado()
    End Sub

    Public Event ItemFueProcesado() Implements IPlantilla_6.ItemFueProcesado

    Public Function AbrirCtasPendientes() As Boolean Implements IPlantilla_6.AbrirCtasPendientes
        Dim xficha2 As New AbrirCtaPendientesPedido
        AddHandler xficha2.AbrirCtaPendiente, AddressOf AbrirCta

        Dim xficha As New Plantilla_9(xficha2)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AbrirCta(ByVal xauto_documento As String, ByVal xauto_usuario As String)
        RaiseEvent AbrirPendiente(xauto_documento, xauto_usuario)
    End Sub

    Public Event AbrirPendiente(ByVal xauto_documento As String, ByVal xauto_usuario As String) Implements IPlantilla_6.AbrirPendiente

    Public ReadOnly Property ActivarChimbo() As Boolean Implements IPlantilla_6.ActivarChimbo
        Get
            Return False
        End Get
    End Property

    Public Sub Inicializa(ByVal xform As Object, ByRef xcant As Integer) Implements IPlantilla_6.Inicializa
    End Sub

    Public Function ProcesarItem(ByVal xfichacli As DataSistema.MiDataSistema.DataSistema.FichaClientes, ByVal xfichaprd As DataSistema.MiDataSistema.DataSistema.FichaProducto.Prd_Producto, ByVal xtipoprecio As String, ByVal xcantevento As Integer) As Boolean Implements IPlantilla_6.ProcesarItem
        Dim xficha As Plantilla_8 = Nothing
        Dim ItemProcesar As IItemProcesar = New Item_PedidoProcesar
        AddHandler ItemProcesar.ActualizarTabla, AddressOf ItemProcesado

        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            xficha = New Plantilla_8(xfichaprd, ItemProcesar, xfichacli.f_Clientes.RegistroDato.r_TipoPrecioFijado, 0)
        Else
            xficha = New Plantilla_8(xfichaprd, ItemProcesar, xtipoprecio, 0)
        End If
        With xficha
            .ShowDialog()
        End With
    End Function

    Public WriteOnly Property CantidadPersonasEvento() As Integer Implements IPlantilla_6.CantidadPersonasEvento
        Set(ByVal value As Integer)
        End Set
    End Property
End Class
