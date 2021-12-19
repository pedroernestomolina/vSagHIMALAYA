Imports DataSistema.MiDataSistema.DataSistema
Imports ImpresoraMatriz.ImpresoraMatriz

Public Class ProductosAlternos
    Event ActualizarTablas()

    Dim pb_tm As Size
    Dim xaccion As TipoAccionFicha

    Dim xprd_producto As FichaProducto.Prd_Producto.c_Registro
    Dim xprd_alternos As FichaProducto.Prd_Alterno

    Dim xbs As BindingSource
    Dim xtb_alternos As DataTable

    Property _ProductosAlterno() As FichaProducto.Prd_Alterno
        Get
            Return xprd_alternos
        End Get
        Set(ByVal value As FichaProducto.Prd_Alterno)
            xprd_alternos = value
        End Set
    End Property

    Property _Producto() As FichaProducto.Prd_Producto.c_Registro
        Get
            Return xprd_producto
        End Get
        Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
            xprd_producto = value
        End Set
    End Property

    Sub New(ByVal xfichaprd As FichaProducto.Prd_Producto.c_Registro)
 
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Producto = xfichaprd
    End Sub

    Property MiFichaAccion() As TipoAccionFicha
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xaccion = value

            If value = TipoAccionFicha.Consultar Then
                MisControles(False)
                ApagarEncender(True)
                Me.MisGrid1.Select()
                Me.MisGrid1.Focus()
                ActualizaRegistro()
            End If

            If value = TipoAccionFicha.Adicionar Then
                MisControles(True)
                ApagarEncender(False)
                LimpiarControles()
                Me.MT_CODIGO.Select()
                Me.MT_CODIGO.Focus()
            End If

            If value = TipoAccionFicha.Modificar Then
                MisControles(True)
                ApagarEncender(False)
                Me.MT_DETALLE.Select()
                Me.MT_DETALLE.Focus()
            End If
        End Set
    End Property

    Sub ApagarEncender(ByVal xop As Boolean)
        Me.PB_1.Enabled = xop
        Me.PB_2.Enabled = xop
        Me.PB_3.Enabled = xop
        Me.MisGrid1.Enabled = xop
        Me.BT_GRABAR.Enabled = Not xop
    End Sub

    Sub MisControles(ByVal xop As Boolean)
        If MiFichaAccion = TipoAccionFicha.Modificar Then
            Me.MT_CODIGO.Enabled = False
        Else
            Me.MT_CODIGO.Enabled = xop
        End If
        Me.MT_DETALLE.Enabled = xop
        Me.BT_GRABAR.Enabled = xop
    End Sub

    Sub LimpiarControles()
        Me.MT_CODIGO.Text = ""
        Me.MT_DETALLE.Text = ""
    End Sub

    Private Sub ProductosAlternos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MiFichaAccion = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If MiFichaAccion = TipoAccionFicha.Adicionar Or MiFichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Deseas Cerrar Esta Ficha y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    MiFichaAccion = TipoAccionFicha.Consultar
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub ProductosAlternos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            AgregarCodigoAlterno()
        End If
        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            ModificarCodigos()
        End If
        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            EliminarAlterno()
        End If
    End Sub

    Private Sub ProductosAlternos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ProductosAlternos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_tm = PB_1.Size
    End Sub

    Private Sub PB_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_4.Click
        ImprimirCodigoBarra()
    End Sub

    Private Sub PB_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseEnter, PB_2.MouseEnter, PB_3.MouseEnter, PB_4.MouseEnter
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseHover, PB_2.MouseHover, PB_3.MouseHover, PB_4.MouseHover
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseLeave, PB_2.MouseLeave, PB_3.MouseLeave, PB_4.MouseLeave
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

    Private Sub ProductosAlternos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub ActualizarControles()
        With Me.MT_CODIGO
            .Text = ""
            .MaxLength = _ProductosAlterno.RegistroDato.c_Codigo.c_Largo
        End With
        With Me.MT_DETALLE
            .Text = ""
            .MaxLength = _ProductosAlterno.RegistroDato.c_Detalle.c_Largo
        End With

        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Sub ActualizarTabla()
        CargarData()
        ActualizaRegistro()
        Me.E_REG.Text = xbs.Count.ToString
    End Sub

    Sub Inicializa()
        Try
            _ProductosAlterno = New FichaProducto.Prd_Alterno

            ActualizarControles()
            xtb_alternos = New DataTable()
            xbs = New BindingSource(xtb_alternos, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarRegistro
            AddHandler _ProductosAlterno.Actualizar, AddressOf ActualizarTabla
            ActualizarTabla()

            With MisGrid1
                .Columns.Add("col0", "Codigos")
                .Columns.Add("col1", "Descripcion")

                .Columns(0).Width = 150
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "xcod"
                .Columns(1).DataPropertyName = "xdet"
                .Ocultar(3)
            End With

            MiFichaAccion = TipoAccionFicha.Consultar
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub CargarData()
        _ProductosAlterno.F_CargarCodigosAlternos(_Producto._AutoProducto, xtb_alternos)
    End Sub

    Sub ActualizarRegistro(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizaRegistro()
    End Sub

    Sub ActualizaRegistro()
        If xbs.Current IsNot Nothing Then
            Dim xrow As DataRow = CType(xbs.Current, DataRowView).Row
            _ProductosAlterno.M_Cargardata(xrow)
            Me.MT_CODIGO.Text = _ProductosAlterno.RegistroDato._CodigoBarraAlterno
            Me.MT_DETALLE.Text = _ProductosAlterno.RegistroDato._DetalleDelCodigo
        Else
            Me.MT_CODIGO.Text = ""
            Me.MT_DETALLE.Text = ""
        End If
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarAlterno()
    End Sub

    Sub EliminarAlterno()
        If MiFichaAccion = TipoAccionFicha.Consultar Then
            If xbs.Current IsNot Nothing Then
                If MessageBox.Show("Estas Seguro De Eliminar Este Codigo De Barra Alterno ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Try
                        _ProductosAlterno.F_EliminarRegistro(_ProductosAlterno.RegistroDato._CodigoBarraAlterno)
                        Funciones.MensajeDeOk("Codigo Eliminado Exitosamente... ")
                    Catch ex As Exception
                        Funciones.MensajeDeError(ex.Message)
                    Finally
                        RaiseEvent ActualizarTablas()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarCodigoAlterno()
    End Sub

    Sub AgregarCodigoAlterno()
        If MiFichaAccion = TipoAccionFicha.Consultar Then
            MiFichaAccion = TipoAccionFicha.Adicionar
        End If
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        Grabar()
    End Sub

    Sub Grabar()
        If MT_CODIGO.r_Valor <> "" Then
            If MiFichaAccion = TipoAccionFicha.Adicionar Then
                Try
                    Dim xagregar As New FichaProducto.Prd_Alterno.c_AgregarCodigoAlterno
                    With xagregar
                        ._AutoProducto = _Producto._AutoProducto
                        ._CodigoAlterno = Me.MT_CODIGO.r_Valor
                        ._Detalle = Me.MT_DETALLE.r_Valor
                        ._Estatus = _Producto._EstatusProducto
                    End With
                    _ProductosAlterno.F_AgregarRegistro(xagregar)
                    Funciones.MensajeDeOk("Codigo Alterno Registrado Exitosamente...")
                    MiFichaAccion = TipoAccionFicha.Consultar
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                    Me.MT_CODIGO.Select()
                Finally
                    RaiseEvent ActualizarTablas()
                End Try
            End If

            If MiFichaAccion = TipoAccionFicha.Modificar Then
                Try
                    Dim xmodificar As New FichaProducto.Prd_Alterno.c_ModificarCodigoAlterno
                    With xmodificar
                        ._CodigoAlterno = Me.MT_CODIGO.r_Valor
                        ._Detalle = Me.MT_DETALLE.r_Valor
                        ._IdSeguridad = _ProductosAlterno.RegistroDato._IdSeguridad
                    End With
                    _ProductosAlterno.F_ActualizarRegistro(xmodificar)
                    Funciones.MensajeDeOk("Codigo Alterno Registrado Exitosamente...")
                    MiFichaAccion = TipoAccionFicha.Consultar
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                    MiFichaAccion = TipoAccionFicha.Consultar
                Finally
                    RaiseEvent ActualizarTablas()
                End Try
            End If
        Else
            ErrorRegresarInicio()
        End If
    End Sub

    Sub ErrorRegresarInicio()
        Funciones.MensajeDeAlerta("Faltan Datos Por Completar, Verifique Por Favor...")
        Me.MT_CODIGO.Select()
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarCodigos()
    End Sub

    Sub ModificarCodigos()
        If MiFichaAccion = TipoAccionFicha.Consultar Then
            If xbs.Current IsNot Nothing Then
                MiFichaAccion = TipoAccionFicha.Modificar
            End If
        End If
    End Sub

    Class EtiquetasBarra
        Private xmedida, xrazonsocial, xrif, xproducto, xcodigobarra, xancho, xalto, xprecio As String

        Property Medida() As String
            Get
                Return xmedida.trim
            End Get
            Set(ByVal value As String)
                xmedida = value
            End Set
        End Property

        Property RazonSocial() As String
            Get
                Return xrazonsocial.Trim
            End Get
            Set(ByVal value As String)
                xrazonsocial = value
            End Set
        End Property

        Property Rif() As String
            Get
                Return xrif.Trim
            End Get
            Set(ByVal value As String)
                xrif = value
            End Set
        End Property

        Property Producto() As String
            Get
                Return xproducto.Trim
            End Get
            Set(ByVal value As String)
                xproducto = value
            End Set
        End Property

        Property CodigoBarra() As String
            Get
                Return xcodigobarra.Trim
            End Get
            Set(ByVal value As String)
                xcodigobarra = value
            End Set
        End Property

        Property Ancho() As String
            Get
                Return xancho.trim
            End Get
            Set(ByVal value As String)
                xancho = value
            End Set
        End Property

        Property Alto() As String
            Get
                Return xalto.Trim
            End Get
            Set(ByVal value As String)
                xalto = value
            End Set
        End Property

        Property Precio() As String
            Get
                Return xprecio.Trim
            End Get
            Set(ByVal value As String)
                xprecio = value
            End Set
        End Property

        Sub New()
            Me.Medida = ""
            Me.Producto = ""
            Me.RazonSocial = ""
            Me.Rif = ""
            Me.CodigoBarra = ""
            Me.Ancho = ""
            Me.Alto = ""
            Me.Precio = ""
        End Sub
    End Class

    Dim xlistaetiquetas As List(Of EtiquetasBarra)

    Sub CargarEtiquetas()
        Try
            Dim XARCHIVO As New XDocument
            XARCHIVO = XDocument.Load(My.Application.Info.DirectoryPath + "\EtiquetasBarra.xml")
            Dim xetiquetas = From xetiq In XARCHIVO.Element("Etiquetas").Descendants("Etiqueta")
            xlistaetiquetas = New List(Of EtiquetasBarra)

            Dim x As Integer = 0
            For Each xelemento As XElement In xetiquetas
                Dim xetiquetabarra As New EtiquetasBarra
                For Each xnodo In xelemento.Elements
                    Select Case xnodo.Name.ToString.Trim.ToUpper
                        Case "RIF" : xetiquetabarra.Rif = xnodo.Value
                        Case "MEDIDA" : xetiquetabarra.Medida = xnodo.Value
                        Case "RAZONSOCIAL" : xetiquetabarra.RazonSocial = xnodo.Value
                        Case "CODIGOBARRA" : xetiquetabarra.CodigoBarra = xnodo.Value
                        Case "PRODUCTO" : xetiquetabarra.Producto = xnodo.Value
                        Case "ANCHO" : xetiquetabarra.Ancho = xnodo.Value
                        Case "ALTO" : xetiquetabarra.Alto = xnodo.Value
                        Case "PRECIO" : xetiquetabarra.Precio = xnodo.Value
                    End Select
                Next
                xlistaetiquetas.Add(xetiquetabarra)
            Next
        Catch ex As Exception
            MensajeDeError(ex.Message)
        End Try
    End Sub


    Private Sub ImprimirCodigoBarra()
        If xbs.Current IsNot Nothing Then
            Try
                CargarEtiquetas()

                Dim xresul As DialogResult = Me.PrintDialog1.ShowDialog
                If xresul = Windows.Forms.DialogResult.OK Then

                    ''FORMATO 6cm x 2cm
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, Chr(10))
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "N" + Chr(10))
                    'Dim XT As String = "A10,5,0,1,1,1,N," + Chr(34) + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RazonSocial + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'XT = "A10,20,0,1,1,1,N," + Chr(34) + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RIF + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'XT = "A10,35,0,1,1,1,N," + Chr(34) + _Producto._DescripcionResumenDelProducto + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'XT = "B60,50,0,1,3,5,50,B," + Chr(34) + _ProductosAlterno.RegistroDato._CodigoBarraAlterno + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "P" + Me.PrintDialog1.PrinterSettings.Copies.ToString.Trim + Chr(10))

                    ''FORMATO 2,45cm x 2,45cm
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, Chr(10))
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "N" + Chr(10))
                    'Dim XT As String = "A10,10,0,1,1,1,N," + Chr(34) + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RazonSocial + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'XT = "A10,30,0,2,1,1,N," + Chr(34) + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RIF + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'XT = "B10,60,0,1,2,2,50,B," + Chr(34) + _ProductosAlterno.RegistroDato._CodigoBarraAlterno + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'XT = "A10,150,0,1,1,1,N," + Chr(34) + _Producto._DescripcionResumenDelProducto + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "P" + Me.PrintDialog1.PrinterSettings.Copies.ToString.Trim + Chr(10))

                    ''FORMATO 2,45cm x 2,45cm
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "N" + Chr(10))
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "ZT" + Chr(10))
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "S2" + Chr(10))
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "Q203,24" + Chr(10))
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "q254" + Chr(10))
                    'Dim XT As String = "A10,20,0,1,1,1,N," + Chr(34) + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RazonSocial + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'XT = "A10,35,0,1,1,1,N," + Chr(34) + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RIF + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'XT = "A10,50,0,1,1,1,N," + Chr(34) + _Producto._DescripcionResumenDelProducto + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'XT = "B8,70,0,1,2,2,50,B," + Chr(34) + _ProductosAlterno.RegistroDato._CodigoBarraAlterno + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'XT = "A10,150,0,1,1,1,N," + Chr(34) + "Precio Bs: " + String.Format("{0:#0.00}", _Producto._PrecioDetal._Full) + Chr(34) + Chr(10)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, XT)
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "P" + Me.PrintDialog1.PrinterSettings.Copies.ToString.Trim + Chr(10))

                    If xlistaetiquetas.Count >= 1 Then
                        ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "N" + Chr(10))
                        ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "ZT" + Chr(10))
                        ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "S2" + Chr(10))
                        ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, xlistaetiquetas(0).Alto + Chr(10))
                        ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, xlistaetiquetas(0).Ancho + Chr(10))

                        Dim xt As String = ""
                        If xlistaetiquetas(0).RazonSocial <> "" Then
                            xt = xlistaetiquetas(0).RazonSocial + Chr(34) + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RazonSocial + Chr(34) + Chr(10)
                            ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, xt)
                        End If

                        If xlistaetiquetas(0).Rif <> "" Then
                            xt = xlistaetiquetas(0).Rif + Chr(34) + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RIF + Chr(34) + Chr(10)
                            ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, xt)
                        End If

                        If xlistaetiquetas(0).Producto <> "" Then
                            xt = xlistaetiquetas(0).Producto + Chr(34) + _Producto._DescripcionResumenDelProducto + Chr(34) + Chr(10)
                            ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, xt)
                        End If

                        If xlistaetiquetas(0).CodigoBarra <> "" Then
                            xt = xlistaetiquetas(0).CodigoBarra + Chr(34) + _ProductosAlterno.RegistroDato._CodigoBarraAlterno + Chr(34) + Chr(10)
                            ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, xt)
                        End If

                        If xlistaetiquetas(0).Precio <> "" Then
                            xt = xlistaetiquetas(0).Precio + Chr(34) + "Precio Bs: " + String.Format("{0:#0.00}", _Producto._PrecioDetal._Full) + Chr(34) + Chr(10)
                            ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, xt)
                        End If

                        ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, "P" + Me.PrintDialog1.PrinterSettings.Copies.ToString.Trim + Chr(10))
                    End If


                    ''
                    ''IMPRESORA DATAMAX ONEIL E-CLASS MARK III, E-4204B
                    ''TAMAÑO DE LA ETIQUETA: 60 DE ANCHO, 37 DE ALTO
                    'Dim xcomando As String = Chr(2) + "L" + "H07" + "D11" & _
                    '         "1F0005000350015" + _ProductosAlterno.RegistroDato._CodigoBarraAlterno + Chr(13) + _
                    '         "121100000000015" + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RazonSocial.Trim + Chr(13) + _
                    '         "121100000150015" + "Rif:" + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RIF.Trim + Chr(13) + _
                    '         "121100001050015" + _Producto._DescripcionResumenDelProducto + Chr(13) + _
                    '         "Q" + Me.PrintDialog1.PrinterSettings.Copies.ToString.Trim.PadLeft(5, "0") + Chr(13) + "E"
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, xcomando)


                    ''
                    ''IMPRESORA DATAMAX ONEIL E-CLASS MARK III, E-4204B
                    ''TAMAÑO DE LA ETIQUETA: 60 DE ANCHO, 19 DE ALTO
                    'Dim xcomando As String = Chr(2) + "L" + "H07" + "D11" & _
                    '         "1F0003000200015" + _ProductosAlterno.RegistroDato._CodigoBarraAlterno + Chr(13) + _
                    '         "121000000000015" + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RazonSocial.Trim + Chr(13) + _
                    '         "121000000100015" + "Rif:" + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RIF.Trim + Chr(13) + _
                    '         "121000000620015" + _Producto._DescripcionResumenDelProducto + Chr(13) + _
                    '         "Q" + Me.PrintDialog1.PrinterSettings.Copies.ToString.Trim.PadLeft(5, "0") + Chr(13) + "E"
                    'ManejoImpresora.SendStringToPrinter(Me.PrintDialog1.PrinterSettings.PrinterName, xcomando)


                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub
End Class