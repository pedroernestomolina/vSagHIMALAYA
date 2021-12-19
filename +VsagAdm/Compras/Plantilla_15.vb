Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles

Public Class Plantilla_15

    Dim xdocumento As IPlantilla_15
    Dim pb_tm As Size
    Dim xestatus As Boolean

    ''' <summary>
    ''' Refleja El Tipo De Documento en Proceso
    ''' </summary>
    Property MiDocumento() As IPlantilla_15
        Get
            Return xdocumento
        End Get
        Set(ByVal value As IPlantilla_15)
            xdocumento = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantilla_15)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MiDocumento = xplantilla
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

    Private Sub Plantilla_15_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MiDocumento._EstatusSalida Then
            e.Cancel = False
        Else
            EliminarTodosLosItems()
            e.Cancel = True
        End If
    End Sub

    Private Sub Plantilla_15_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        If e.KeyCode = Keys.D1 AndAlso (e.Alt = True And e.Control = False) Then
            ControlInventario()
        End If
        If e.KeyCode = Keys.D2 AndAlso (e.Alt = True And e.Control = False) Then
            ControlEntidad()
        End If
    End Sub

    Private Sub Plantilla_15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_15_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_tm = PB_3.Size
    End Sub

    Private Sub Plantilla_15_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub BT_SALIDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SALIDA.Click
        Me.Close()
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        ModificarItem()
    End Sub

    Private Sub PB_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_5.Click
        NotasDetallesItem()
    End Sub

    Private Sub PB_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_7.Click
        EliminarItem()
    End Sub

    Private Sub PB_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_6.Click
        Procesar()
    End Sub

    Private Sub PB_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_8.Click
        AdmDocumentos()
    End Sub

    Private Sub PB_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_9.Click
        ControlInventario()
    End Sub

    Private Sub PB_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_10.Click
        ControlEntidad()
    End Sub

    Sub Inicializa()
        If MiDocumento.Inicializar(Me, Me.ToolTip1) Then
        Else
            Me.Close()
        End If
    End Sub

    Sub EliminarTodosLosItems()
        MiDocumento.F_EliminarTodosLosItems()
    End Sub

    Sub ModificarItem()
        MiDocumento.F_ModificarItem()
    End Sub

    Sub NotasDetallesItem()
        MiDocumento.F_NotasDetallesItem()
    End Sub

    Sub EliminarItem()
        MiDocumento.F_EliminarItem()
    End Sub

    Sub Procesar()
        MiDocumento.F_ProcesarDocumento()
    End Sub

    Sub AdmDocumentos()
        MiDocumento.F_AdmDocumentos()
    End Sub

    Sub ControlEntidad()
        MiDocumento.F_ControlEntidad()
    End Sub
    Sub ControlInventario()
        MiDocumento.F_ControlInventario()
    End Sub

    Private Sub E_RIF_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles E_RIF.LinkClicked
        MiDocumento.F_FichaEntidad()
    End Sub

    Private Sub PB_11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_11.Click
        g_MiCalculadora = New MiCalculadora.Calc
        g_MiCalculadora.Show()
    End Sub
End Class

Public Interface IPlantilla_15
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
                Dim xfichatemp As New FichaCompras.c_ComprasDetalle.c_Registro
                For Each xrow As DataRow In Me._TablaData.Rows
                    xfichatemp.M_CargarData(xrow)
                    If xrow("x7") = 1 Then
                        Dim x1 As Decimal = xrow(5)
                        If xrow("x8") = "D" Then
                            Select Case xfichatemp._TipoTasa
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
                            Dim t1 As Decimal = xrow("costo")
                            Dim t2 As Decimal = Decimal.Round(t1 * (xrow("cantidad") - xrow(2)), 2, MidpointRounding.AwayFromZero)
                            Dim t3 As Decimal = Decimal.Round(xrow(5), 2, MidpointRounding.AwayFromZero)
                            Dim t4 As Decimal = Decimal.Round(xrow("total_neto"), 2, MidpointRounding.AwayFromZero)
                            Dim t5 As Decimal = Decimal.Round(t4 - (t2 + t3), 2, MidpointRounding.AwayFromZero)
                            x2 = t5
                            Select Case xfichatemp._TipoTasa
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

    Function Inicializar(ByVal xficha As Object, ByVal xtooltip As Windows.Forms.ToolTip) As Boolean

    Function F_ControlInventario() As Boolean
    Function F_ControlEntidad() As Boolean
    Function F_EliminarTodosLosItems() As Boolean
    Function F_ModificarItem() As Boolean
    Function F_NotasDetallesItem() As Boolean
    Function F_EliminarItem() As Boolean
    Function F_ProcesarDocumento() As Boolean
    Function F_AdmDocumentos() As Boolean

    Function F_FichaEntidad() As Boolean

    ReadOnly Property _EstatusSalida() As Boolean
End Interface

Class NotaCredito_Compras
    Implements IPlantilla_15

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

    'FORMS
    Dim xformulario As Windows.Forms.Form

    ''' <summary>
    ''' Mi Formulario, Controla Todos Los Controles De La Plantilla
    ''' </summary>
    Property _MiFormulario() As Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    'MISGRID
    Dim MG_1 As MisGrid

    'LABELS
    Dim TITULO As Windows.Forms.Label
    Dim CODIGO As Windows.Forms.Label
    Dim NOMBRE As Windows.Forms.Label
    Dim CIRIF As Windows.Forms.Label
    Dim ITEMS As Windows.Forms.Label
    Dim KILOS As Windows.Forms.Label
    Dim LINEAS As Windows.Forms.Label
    Dim TOTAL As Windows.Forms.Label
    Dim SUBTOTAL As Windows.Forms.Label
    Dim IMPUESTO As Windows.Forms.Label
    Dim DOC_PENDIENTES As Windows.Forms.Label
    Dim DOCUMENTO As Windows.Forms.Label
    Dim FECHA As Windows.Forms.Label

    WithEvents PRODUCTO As Windows.Forms.Label
    Dim CODPRODUCTO As Windows.Forms.Label
    Dim EMPAQUE As Windows.Forms.Label
    Dim CONTENIDO As Windows.Forms.Label
    Dim PSUGERIDO As Windows.Forms.Label
    Dim IVA As Windows.Forms.Label
    Dim SUBTOTAL_1 As Windows.Forms.Label
    Dim IMPUESTO_1 As Windows.Forms.Label
    Dim TOTAL_1 As Windows.Forms.Label
    Dim CNETO As Windows.Forms.Label
    Dim CPROMOCION As Windows.Forms.Label
    Dim TDESCUENTO As Windows.Forms.Label
    Dim CFINAL As Windows.Forms.Label

    Dim LB_1 As Windows.Forms.Label
    Dim LB_2 As Windows.Forms.Label
    Dim LB_3 As Windows.Forms.Label
    Dim LB_4 As Windows.Forms.Label
    Dim LB_5 As Windows.Forms.Label


    Dim xbs_tabladata As BindingSource
    Dim xtotales As TotalesDoc

    Dim xfichaprd As FichaProducto.Prd_Producto
    Dim xfichapro As FichaProveedores
    Dim xfichatem As FichaCompras.c_ComprasDetalle
    Dim xfichacompra As FichaCompras

    Dim xfichdocumento As IPlantilla_15.FichaDoc

    ''' <summary>
    ''' Refleja Los Totales De La Pantalla
    ''' </summary>
    Property _MiFichaDoc() As IPlantilla_15.FichaDoc
        Get
            Return xfichdocumento
        End Get
        Set(ByVal value As IPlantilla_15.FichaDoc)
            xfichdocumento = value
        End Set
    End Property

    Dim xtipodoc As TipoDoc

    ''' <summary>
    ''' Refleja El Tipo De Documento
    ''' </summary>
    Property _TipoDoc() As TipoDoc
        Get
            Return xtipodoc
        End Get
        Set(ByVal value As TipoDoc)
            xtipodoc = value
        End Set
    End Property

    Dim xestatus As Boolean

    ReadOnly Property _EstatusSalida() As Boolean Implements IPlantilla_15._EstatusSalida
        Get
            If _MiFichaDoc._TablaData.Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    Sub New()
        xfichacompra = New FichaCompras
        xfichapro = New FichaProveedores
        _TipoDoc = New TipoDoc With {._Nombre = "Control De Notas De Credito", ._Tipo = TipoDocumentoCompra.NotaCredito}
    End Sub

    Sub LimpiarFicha()
        xfichapro.f_Proveedor.RegistroDato.LimpiarRegistro()
        xfichacompra.F_Compras.RegistroDato.M_LimpiarRegistro()
        _MiFichaDoc._RegistrosEnTabla = 0
        _MiFichaDoc._TablaData.Rows.Clear()

        _MiFormulario.Text = "Datos Del Usuario: " + g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario + ", Grupo: " + g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreGrupo
        TITULO.Text = _TipoDoc._Nombre

        CODIGO.Text = xfichapro.f_Proveedor.RegistroDato._CodigoProveedor
        NOMBRE.Text = xfichapro.f_Proveedor.RegistroDato._NombreRazonSocial
        CIRIF.Text = xfichapro.f_Proveedor.RegistroDato._CiRif

        ITEMS.Text = _MiFichaDoc._Items.ToString
        KILOS.Text = String.Format("{0:#0.000}", _MiFichaDoc._Kilos)
        LINEAS.Text = _MiFichaDoc._Items.ToString
        TOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Total_1)
        SUBTOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Subtotal_1)
        IMPUESTO.Text = String.Format("{0:#0.00}", _MiFichaDoc._SubtotalIva_1)
        DOC_PENDIENTES.Text = "0"

        DOCUMENTO.Text = ""
        FECHA.Text = ""

        IrInicio()
    End Sub

    Sub InicializarPantalla(ByVal xtooltip As Windows.Forms.ToolTip)
        IrInicio()
        _MiFormulario.Text = "Datos Del Usuario: " + g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario + ", Grupo: " + g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreGrupo
        TITULO.Text = _TipoDoc._Nombre

        LB_1.Text = "Iva %:"
        LB_2.Text = "C/Neto:"
        LB_3.Text = "C/Promo:"
        LB_4.Text = "T/Dscto(Bs):"
        LB_5.Text = "C/Final:"

        CODIGO.Text = xfichapro.f_Proveedor.RegistroDato._CodigoProveedor
        NOMBRE.Text = xfichapro.f_Proveedor.RegistroDato._NombreRazonSocial
        CIRIF.Text = xfichapro.f_Proveedor.RegistroDato._CiRif

        ITEMS.Text = _MiFichaDoc._Items.ToString
        KILOS.Text = String.Format("{0:#0.000}", _MiFichaDoc._Kilos)
        LINEAS.Text = _MiFichaDoc._Items.ToString
        TOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Total_1)
        SUBTOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Subtotal_1)
        IMPUESTO.Text = String.Format("{0:#0.00}", _MiFichaDoc._SubtotalIva_1)
        DOC_PENDIENTES.Text = "0"

        DOCUMENTO.Text = ""
        FECHA.Text = ""

        With xtooltip
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
            .UseFading = True
            .ShowAlways = True
        End With

        Dim xcol As New DataGridViewCheckBoxColumn
        xcol.HeaderText = "*"
        With MG_1
            .Columns.Add("col0", "Codigo")
            .Columns.Add("col1", "Descripcion")
            .Columns.Add("col2", "Cant")
            .Columns.Add("col3", "C/Unid")
            .Columns.Add("col4", "Dscto(Bs)")
            .Columns.Add("col5", "Importe")
            .Columns.Add(xcol)
            .Columns.Add("col7", "T")


            .Columns(0).Width = 80
            .Columns(2).Width = 80
            .Columns(3).Width = 80
            .Columns(4).Width = 100
            .Columns(5).Width = 100
            .Columns(6).Width = 20
            .Columns(7).Width = 30
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
            AddHandler .CellFormatting, AddressOf MiFormato
            AddHandler .CellDoubleClick, AddressOf ActualizarCheck
            .Ocultar(9)
        End With
    End Sub

    Sub ActualizarCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = 6 And e.RowIndex <> -1 Then
            If MG_1.Rows(e.RowIndex).Cells(3).Value > 0 Then
                If MG_1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1 Then
                    MG_1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                Else
                    MG_1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1
                End If
                _MiFichaDoc._TablaData.AcceptChanges()
            Else
                MessageBox.Show("Opcion No Permitida Para Este Item", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Sub CargarData(ByVal xauto As String)
        Dim xp1 As New SqlParameter("@auto_documento", xauto)
        Dim xp2 As New SqlParameter("@auto_documento", xauto)
        _MiFichaDoc._RegistrosEnTabla = F_GetInteger("select COUNT(*) from compras_detalle where auto_documento=@auto_documento", xp1)
        g_MiData.F_GetData("select codigo x1, nombre x2, cantidad x3, costo_bruto x4, (descuento1+descuento2+descuento3) x5, total_neto x6, " & _
                           "(case costo_bruto when 0 then 0 else 0 end) x7, 'D' AS x8, descuento1p x9, descuento2p x10, descuento3p x11, " & _
                           "detalle x12, * from COMPRAS_DETALLE where auto_documento=@auto_documento", _MiFichaDoc._TablaData, xp2)
        CargarTabla()

        'LIMPIAR LOS DETALLES QUE TRAE DE LA VENTA, PARA INCIALIZAR LA NOTA DE CREDITO
        Dim xficha As New FichaCompras.c_ComprasDetalle.c_Registro
        For Each xrow As DataRow In _MiFichaDoc._TablaData.Rows
            xrow(xficha.c_NotasItem.c_NombreInterno) = ""
        Next
    End Sub

    Sub CargarTabla()
        LINEAS.Text = _MiFichaDoc._Lineas.ToString
        KILOS.Text = String.Format("{0:#0.000}", _MiFichaDoc._Kilos)
        ITEMS.Text = _MiFichaDoc._Items.ToString
        SUBTOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Subtotal_1)
        IMPUESTO.Text = String.Format("{0:#0.00}", _MiFichaDoc._SubtotalIva_1)
        TOTAL.Text = String.Format("{0:#0.00}", _MiFichaDoc._Total_1)
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 2 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight

            If e.ColumnIndex = 2 Then
                Dim xformato As String = "#0.000"
                Dim xd As String = MG_1.Rows(e.RowIndex).Cells("decimales").Value.ToString
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

    Sub IrInicio()
        _MiFormulario.Select()
    End Sub

    Public Function F_AdmDocumentos() As Boolean Implements IPlantilla_15.F_AdmDocumentos
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_AdmDocumentos.F_Permitir()

            Dim xficha As New AdmDocumentosCompras(New AdmDoc_Compras(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCompras._Limite_Renglones_AdmDocumentos), True)
            With xficha
                AddHandler xficha._AutoDocumento, AddressOf CapturarDoc
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Sub CapturarDoc(ByVal xauto As String)
        If _MiFichaDoc._Total_1 = 0 And _MiFichaDoc._Lineas = 0 And _MiFichaDoc._TablaData.Rows.Count = 0 Then
            Try
                xfichacompra.F_Compras.F_CargarCompra(xauto)

                If xfichacompra.F_Compras.RegistroDato._TipoDocumentoCompra <> TipoDocumentoCompra.Factura Then
                    Throw New Exception("ERROR AL CARGAR TIPO DE DOCUMENTO, SOLO SE PODRAN CARGAR DOCUMENTOS DE COMPRAS")
                Else
                    If xfichacompra.F_Compras.RegistroDato._EstatusCompra = TipoEstatus.Inactivo Then
                        Throw New Exception("ERROR ... DOCUMENTO SE ENCUENTRA ANULADO, VERIFIQUE POR FAVOR")
                    Else
                        If xfichacompra.F_Compras.RegistroDato._TipoCompraRegistrada = TipoCompraRegistrada.CompraMercancia Then
                            MostrarDoc()
                        Else
                            Dim xform As New ProcesarGastos_NC(New c_ProcesarGastos_NC(xauto))
                            With xform
                                .ShowDialog()
                            End With
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No Se Pueden Cargar Mas De Un Documento De Compra A La Vez, Verifique Por Favor...", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub MostrarDoc()
        With xfichacompra.F_Compras.RegistroDato
            DOCUMENTO.Text = ._NumeroDocumentoCompra
            FECHA.Text = ._FechaEmision
            CargarFichaProveedor(._AutoProveedor)
        End With
        CargarData(xfichacompra.F_Compras.RegistroDato._AutoDocumentoCompra)
    End Sub

    Public Function F_ControlEntidad() As Boolean Implements IPlantilla_15.F_ControlEntidad
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor.F_Permitir()

            Dim xficha As New FichaProveedor
            With xficha
                .Show()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Function

    Sub ActualizarDataProveedor()
        CargarFichaProveedor(xfichapro.f_Proveedor.RegistroDato._Automatico)
    End Sub

    Sub CargarFichaProveedor(ByVal xauto As String)
        Try
            xfichapro.F_BuscarProveedor(xauto)
            CODIGO.Text = xfichapro.f_Proveedor.RegistroDato._CodigoProveedor
            NOMBRE.Text = xfichapro.f_Proveedor.RegistroDato._NombreRazonSocial
            CIRIF.Text = xfichapro.f_Proveedor.RegistroDato._CiRif

        Catch ex As Exception
            xfichapro.f_Proveedor.RegistroDato.LimpiarRegistro()

            CODIGO.Text = xfichapro.f_Proveedor.RegistroDato._CodigoProveedor
            NOMBRE.Text = xfichapro.f_Proveedor.RegistroDato._NombreRazonSocial
            CIRIF.Text = xfichapro.f_Proveedor.RegistroDato._CiRif

            IrInicio()
        End Try
    End Sub

    Public Function F_ControlInventario() As Boolean Implements IPlantilla_15.F_ControlInventario
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario.F_Permitir()

            Dim xficha As New FichaProductos
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function F_EliminarItem() As Boolean Implements IPlantilla_15.F_EliminarItem
        If _MiFichaDoc._TablaData.Rows.Count > 0 Then
            If MessageBox.Show("Estas Seguro De Marcar Todos Los Items Para La Devolucion Total ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                For Each xrow As DataRow In _MiFichaDoc._TablaData.Rows
                    If xrow("x4") > 0 Then
                        xrow("x7") = 1
                    Else
                        xrow("x7") = 0
                    End If
                Next
            End If
        End If
        Me.IrInicio()
    End Function

    Public Function F_EliminarTodosLosItems() As Boolean Implements IPlantilla_15.F_EliminarTodosLosItems
        If _MiFichaDoc._Lineas > 0 Or _MiFichaDoc._Total_1 > 0 Or _MiFichaDoc._TablaData.Rows.Count > 0 Then
            If MessageBox.Show("Estas Segur De Querer Eliminar Todos Los Item Procesados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Me._MiFichaDoc._RegistrosEnTabla = 0
                    Me._MiFichaDoc._TablaData.Rows.Clear()
                    xfichapro.f_Proveedor.RegistroDato.LimpiarRegistro()
                    CargarFichaProveedor(xfichapro.f_Proveedor.RegistroDato._Automatico)
                    DOCUMENTO.Text = ""
                    FECHA.Text = ""

                    MessageBox.Show("Items Eliminados Satisfactoriamente... Ok", "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.IrInicio()
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
        Me.IrInicio()
    End Function

    Public Function F_ModificarItem() As Boolean Implements IPlantilla_15.F_ModificarItem
        If xbs_tabladata.Current IsNot Nothing Then
            If xbs_tabladata.Current("x7") = 1 Then
                Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row
                Dim xfichatemporal As New FichaCompras.c_ComprasDetalle
                xfichatemporal.RegistroDato.M_CargarData(xrow)

                Dim xficha As New ModificarNC_Compras(xfichatemporal.RegistroDato)
                With xficha
                    .ShowDialog()
                    If ._EstatusSalida Then
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(2) = ._Cantidad_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(3) = ._Costo_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(4) = ._DescuentoTotal_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(5) = ._Importe_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(7) = ._Tipo_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(8) = ._Descuento1_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(9) = ._Descuento2_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(10) = ._Descuento3_NC
                        _MiFichaDoc._TablaData.Rows(xbs_tabladata.Position)(11) = ._Detalle_NC
                        _MiFichaDoc._TablaData.AcceptChanges()
                        xbs_tabladata.CurrencyManager.Refresh()
                    End If
                End With
            End If
        End If
        IrInicio()
    End Function

    Public Function F_NotasDetallesItem() As Boolean Implements IPlantilla_15.F_NotasDetallesItem
        If xbs_tabladata.Current IsNot Nothing Then
            If xbs_tabladata.Current("x7") = 1 Then
                Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row
                Dim xfichatemporal As New FichaCompras.c_ComprasDetalle
                xfichatemporal.RegistroDato.M_CargarData(xrow)
                Dim xnotas As String = xbs_tabladata.Current(11)

                Dim xficha As New NotasItem(xnotas, xfichatemporal.RegistroDato.c_NotasItem.c_Largo)
                With xficha
                    .ShowDialog()
                    If ._SalidaExitosa Then
                        Try
                            xbs_tabladata.Current(11) = ._NotasItem
                            _MiFichaDoc._TablaData.AcceptChanges()
                            MessageBox.Show("Item Actualizado Satisfactoriamente... Ok", "*** Mensaje De OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                End With
            Else
                MessageBox.Show("Item Marcado Como Protegido, Veirifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        Me.IrInicio()
    End Function

    Public Function F_ProcesarDocumento() As Boolean Implements IPlantilla_15.F_ProcesarDocumento
        Try
            If xfichacompra.F_Compras.RegistroDato._AutoDocumentoCompra <> "" Then
                If Me._MiFichaDoc._Total_1 > 0 Or Me._MiFichaDoc._Lineas > 0 Then
                    If Procesar() Then
                        MessageBox.Show("Documento Procesado Con Exito !!!", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                ElseIf Me._MiFichaDoc._Total_1 = 0 AndAlso Me._MiFichaDoc._Lineas = 0 Then
                    Dim xclas As New c_ProcesarDescuento_Compras(xfichacompra.F_Compras.RegistroDato._AutoDocumentoCompra)
                    AddHandler xclas._DocumentoProcesado, AddressOf LimpiarFicha

                    Dim xform As New ProcesarGastos_NC(xclas)
                    With xform
                        .ShowDialog()
                    End With
                Else
                    MessageBox.Show("Error... No Hay Items Seleccionados Para Procesar El Documento !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            _MiFormulario.Select()
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        IrInicio()
    End Function


    Function Procesar() As Boolean
        Dim xtotales As New TotalesDoc
        With xtotales
            ._Exento = _MiFichaDoc._Exento_1
            ._Lineas = _MiFichaDoc._Lineas
            ._Neto1 = _MiFichaDoc._Neto1_1
            ._Neto2 = _MiFichaDoc._Neto2_1
            ._Neto3 = _MiFichaDoc._Neto3_1
            ._TasaIva1 = _MiFichaDoc._TasaIva1
            ._TasaIva2 = _MiFichaDoc._TasaIva2
            ._TasaIva3 = _MiFichaDoc._TasaIva3
        End With

        Dim xficha As ProcesarDoc_Compras
        Dim xtipodocu As New c_ProcesarDoc_NC(xfichapro.f_Proveedor.RegistroDato, xtotales, _MiFichaDoc._TablaData, xfichacompra.F_Compras.RegistroDato)
        AddHandler xtipodocu.DocumentoProcesado, AddressOf AvisoFacturaExitosa

        xficha = New ProcesarDoc_Compras(xtipodocu)
        With xficha
            .ShowDialog()
        End With
    End Function

    Sub AvisoFacturaExitosa()
        LimpiarFicha()
    End Sub

    Public Function Inicializar(ByVal xficha As Object, ByVal xtooltip As Windows.Forms.ToolTip) As Boolean Implements IPlantilla_15.Inicializar
        Try
            _MiFormulario = xficha

            'MISGRID
            MG_1 = _MiFormulario.Controls.Find("MisGrid1", True)(0)

            'LABELS
            TITULO = _MiFormulario.Controls.Find("E_TITULO", True)(0)
            CODIGO = _MiFormulario.Controls.Find("E_ENT_CODIGO", True)(0)
            NOMBRE = _MiFormulario.Controls.Find("E_ENT_NOMBRE", True)(0)
            CIRIF = _MiFormulario.Controls.Find("E_ENT_RIF", True)(0)
            ITEMS = _MiFormulario.Controls.Find("E_ITEMS", True)(0)
            KILOS = _MiFormulario.Controls.Find("E_KILOS", True)(0)
            LINEAS = _MiFormulario.Controls.Find("E_LINEAS", True)(0)
            TOTAL = _MiFormulario.Controls.Find("E_TOTAL", True)(0)
            SUBTOTAL = _MiFormulario.Controls.Find("E_SUBTOTAL", True)(0)
            IMPUESTO = _MiFormulario.Controls.Find("E_IMPUESTO", True)(0)
            DOC_PENDIENTES = _MiFormulario.Controls.Find("E_DOC_PENDIENTES", True)(0)
            DOCUMENTO = _MiFormulario.Controls.Find("E_DOCUMENTO", True)(0)
            FECHA = _MiFormulario.Controls.Find("E_FECHA", True)(0)

            PRODUCTO = _MiFormulario.Controls.Find("E_V_1", True)(0)
            CODPRODUCTO = _MiFormulario.Controls.Find("E_V_2", True)(0)
            EMPAQUE = _MiFormulario.Controls.Find("E_V_3", True)(0)
            CONTENIDO = _MiFormulario.Controls.Find("E_V_4", True)(0)
            PSUGERIDO = _MiFormulario.Controls.Find("E_V_5", True)(0)
            IVA = _MiFormulario.Controls.Find("E_V_6", True)(0)
            SUBTOTAL_1 = _MiFormulario.Controls.Find("E_V_7", True)(0)
            IMPUESTO_1 = _MiFormulario.Controls.Find("E_V_8", True)(0)
            TOTAL_1 = _MiFormulario.Controls.Find("E_V_9", True)(0)
            CNETO = _MiFormulario.Controls.Find("E_V_10", True)(0)
            CPROMOCION = _MiFormulario.Controls.Find("E_V_11", True)(0)
            TDESCUENTO = _MiFormulario.Controls.Find("E_V_12", True)(0)
            CFINAL = _MiFormulario.Controls.Find("E_V_13", True)(0)

            LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            LB_2 = _MiFormulario.Controls.Find("LB_2", True)(0)
            LB_3 = _MiFormulario.Controls.Find("LB_3", True)(0)
            LB_4 = _MiFormulario.Controls.Find("LB_4", True)(0)
            LB_5 = _MiFormulario.Controls.Find("LB_5", True)(0)

            xfichatem = New FichaCompras.c_ComprasDetalle
            xfichaprd = New FichaProducto.Prd_Producto
            xfichapro = New FichaProveedores

            _MiFichaDoc = New IPlantilla_15.FichaDoc
            AddHandler _MiFichaDoc.FichaEnCero, AddressOf CargarTabla

            xbs_tabladata = New BindingSource(_MiFichaDoc._TablaData, "")
            AddHandler xbs_tabladata.PositionChanged, AddressOf ActualizarVistaItem
            ActualizaVistaItem()

            InicializarPantalla(xtooltip)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Sub ActualizarVistaItem()
        ActualizaVistaItem()
    End Sub

    Sub ActualizaVistaItem()
        Try
            If xbs_tabladata.Current IsNot Nothing Then
                Dim xrow As DataRow = CType(xbs_tabladata.Current, DataRowView).Row
                xfichatem.RegistroDato.M_CargarData(xrow)
                Dim xp1 As SqlParameter = New SqlParameter("@AUTO", xfichatem.RegistroDato._AutoProducto)
                With xfichatem.RegistroDato
                    PRODUCTO.Text = ._NombreProducto
                    CODPRODUCTO.Text = ._CodigoProducto
                    EMPAQUE.Text = ._Empaque
                    CONTENIDO.Text = ._ContenidoEmpaque
                    PSUGERIDO.Text = F_GetDecimal("SELECT PSV FROM PRODUCTOS WHERE AUTO=@AUTO", xp1)
                    IVA.Text = ._TasaIva

                    SUBTOTAL_1.Text = ._TotalNeto
                    IMPUESTO_1.Text = String.Format("{0:#0.00}", Decimal.Round(._TotalNeto * ._TasaIva / 100, 2, MidpointRounding.AwayFromZero))
                    TOTAL_1.Text = String.Format("{0:#0.00}", Decimal.Round(._TotalNeto + (._TotalNeto * ._TasaIva / 100), 2, MidpointRounding.AwayFromZero))

                    CNETO.Text = ._CostoBruto
                    CPROMOCION.Text = String.Format("{0:#0.00}", (._CantidadCompra + ._CostoBruto) / (._CantidadCompra + ._Bono))
                    TDESCUENTO.Text = String.Format("{0:#0.00}", Decimal.Round((._Descuento1._Valor + ._Descuento2._Valor + ._Descuento3._Valor) / ._CantidadCompra, 2, MidpointRounding.AwayFromZero))
                    CFINAL.Text = ._Costo
                End With

            Else
                PRODUCTO.Text = ""
                CODPRODUCTO.Text = ""
                EMPAQUE.Text = ""
                CONTENIDO.Text = "0"
                PSUGERIDO.Text = "0.00"
                IVA.Text = "0.00"

                SUBTOTAL_1.Text = "0.00"
                IMPUESTO_1.Text = "0.00"
                TOTAL_1.Text = "0.00"

                CNETO.Text = "0.00"
                CPROMOCION.Text = "0.00"
                TDESCUENTO.Text = "0.00"
                CFINAL.Text = "0.00"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function F_FichaEntidad() As Boolean Implements IPlantilla_15.F_FichaEntidad
        If xfichapro.f_Proveedor.RegistroDato._Automatico <> "" Then
            Dim xficha As New FichaProveedor(xfichapro.f_Proveedor.RegistroDato._Automatico)
            With xficha
                AddHandler ._ActualizarFicha, AddressOf ActualizarDataProveedor
                .ShowDialog()
            End With
            IrInicio()
        End If
    End Function

    Private Sub PRODUCTO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PRODUCTO.Click
        If xbs_tabladata.Current IsNot Nothing Then
            If xfichatem.RegistroDato._AutoProducto <> "" Then
                Try
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario.F_Permitir()

                    Dim xficha As New FichaProductos(xfichatem.RegistroDato._AutoProducto)
                    With xficha
                        .ShowDialog()
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub
End Class