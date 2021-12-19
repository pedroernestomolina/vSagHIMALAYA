Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles

Public Class DetalleDocumentosAnulados
    Dim _Plantilla As IDetalleDocumentosAnulados

    Sub New(ByVal xplantilla As IDetalleDocumentosAnulados)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Sub Inicializar()
        _Plantilla.Inicializar(Me)
    End Sub

    Private Sub DetalleDocumentosAnulados_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DetalleDocumentosAnulados_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializar()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

End Class

Public Interface IDetalleDocumentosAnulados
    Sub Inicializar(ByVal xformulario As Object)
End Interface

''
'' CUENTAS POR COBRAR
''
Class c_DetalleDocumentosAnuladosCxC
    Implements IDetalleDocumentosAnulados

    'LABELS
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_DOCUMENTO As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_HORA As System.Windows.Forms.Label
    Dim LB_USUARIO As System.Windows.Forms.Label
    Dim LB_ESTACION As System.Windows.Forms.Label
    Dim LB_DETALLE As System.Windows.Forms.Label

    Dim _CxC As FichaCtasCobrar.c_CxC
    Dim _DocumentosAnulados As New FichaGlobal.c_DocumentosAnulados
    Dim xcodigo As String = ""
    Dim xtipo As String = ""
    Dim xtipo1 As String = ""
    Dim xauto_documento As String = ""

    Property _TipoDocumento() As String
        Get
            Select Case xtipo
                Case "FAC"
                    Return "FACTURA"
                Case "NDF"
                    Return "NOTA DÉBITO"
                Case "ND"
                    Return "NOTA DÉBITO"
                Case "NCF"
                    Return "NOTA CRÉDITO"
                Case "NC"
                    Return "NOTA CRÉDITO"
                Case "CHD"
                    Return "CHEQUE DEVUELTO"
                Case "PRE"
                    Return "PRESTAMO"
                Case Else
                    Return "PAGO"
            End Select
        End Get
        Set(ByVal value As String)
            xtipo = value
        End Set
    End Property

    Sub New(ByVal xrow As DataRow)
        _CxC = New FichaCtasCobrar.c_CxC
        _CxC.F_CargarRegistro(xrow("auto").ToString)
        _TipoDocumento = _CxC.RegistroDato._TipoDocumento

        If _CxC.RegistroDato._AutoDocumento.Trim <> "" And _CxC.RegistroDato._TipoDocumento <> "PAG" Then
            xauto_documento = _CxC.RegistroDato._AutoDocumento
            Select Case _CxC.RegistroDato._TipoDocumento
                Case "FAC"
                    xcodigo = "0801"
                Case "NDF"
                    xcodigo = "0802"
                Case "NCF"
                    xcodigo = "0803"
            End Select
        Else
            xauto_documento = _CxC.RegistroDato._AutoCxC
            xcodigo = "0401"
        End If
        _DocumentosAnulados.F_CargarRegistro(xauto_documento, xcodigo)
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IDetalleDocumentosAnulados.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        LB_DOCUMENTO = _MiFormulario.Controls.Find("LB_DOCUMENTO", True)(0)
        LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
        LB_HORA = _MiFormulario.Controls.Find("LB_HORA", True)(0)
        LB_USUARIO = _MiFormulario.Controls.Find("LB_USUARIO", True)(0)
        LB_ESTACION = _MiFormulario.Controls.Find("LB_ESTACION", True)(0)
        LB_DETALLE = _MiFormulario.Controls.Find("LB_DETALLE", True)(0)

        _MiFormulario.Text = "Detalle De Documentos Anulados"
        InicializarData()
    End Sub

    Sub InicializarData()
        LB_TITULO.Text = _TipoDocumento
        LB_NOMBRE.Text = _CxC.RegistroDato._NombreCliente
        LB_CIRIF.Text = _CxC.RegistroDato._CiRifCliente
        LB_CODIGO.Text = _CxC.RegistroDato._CodigoCliente
        LB_DOCUMENTO.Text = _CxC.RegistroDato._NumeroDocumento
        LB_IMPORTE.Text = _CxC.RegistroDato._MontoImporte
        LB_FECHA.Text = _DocumentosAnulados.RegistroDato._FechaEmision
        LB_HORA.Text = _DocumentosAnulados.RegistroDato._HoraAnulacion
        LB_USUARIO.Text = _DocumentosAnulados.RegistroDato._NombreUsuario
        LB_ESTACION.Text = _DocumentosAnulados.RegistroDato._NombreEstacion
        LB_DETALLE.Text = _DocumentosAnulados.RegistroDato._NotaDetalleAnulacion
    End Sub
End Class


''
'' CUENTAS POR PAGAR
''
Class c_DetalleDocumentosAnuladosCxP
    Implements IDetalleDocumentosAnulados

    ' CONTROLES
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_DOCUMENTO As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_HORA As System.Windows.Forms.Label
    Dim LB_USUARIO As System.Windows.Forms.Label
    Dim LB_ESTACION As System.Windows.Forms.Label
    Dim LB_DETALLE As System.Windows.Forms.Label

    Dim xcodigo As String = ""
    Dim xauto_documento As String = ""

    Dim _CxP As FichaCtasPagar.c_CxP
    Dim _DocumentosAnulados As New FichaGlobal.c_DocumentosAnulados

    Sub New(ByVal xrow As DataRow)
        _CxP = New FichaCtasPagar.c_CxP
        _CxP.M_CargarRegistro(xrow)

        If _CxP.RegistroDato._AutoDocumento.Trim <> "" And _CxP.RegistroDato._TipoDocumento <> TipoDocumentoCuentaxPagar.Pago Then
            xauto_documento = _CxP.RegistroDato._AutoDocumento
            Select Case _CxP.RegistroDato._TipoDocumento
                Case TipoDocumentoCuentaxPagar.Factura
                    xcodigo = "0701"
                Case TipoDocumentoCuentaxPagar.NotaDebito
                    xcodigo = "0702"
                Case TipoDocumentoCuentaxPagar.NotaCredito
                    xcodigo = "0703"
            End Select
        Else
            xauto_documento = _CxP.RegistroDato._AutoCxP
            xcodigo = "0501"
        End If
        _DocumentosAnulados.F_CargarRegistro(xauto_documento, xcodigo)
    End Sub

    Sub New(ByVal xautocxp As String)
        _CxP = New FichaCtasPagar.c_CxP
        _CxP.F_CargarRegistro(xautocxp)

        If _CxP.RegistroDato._AutoDocumento.Trim <> "" And _CxP.RegistroDato._TipoDocumento <> TipoDocumentoCuentaxPagar.Pago Then
            xauto_documento = _CxP.RegistroDato._AutoDocumento
            Select Case _CxP.RegistroDato._TipoDocumento
                Case TipoDocumentoCuentaxPagar.Factura
                    xcodigo = "0701"
                Case TipoDocumentoCuentaxPagar.NotaDebito
                    xcodigo = "0702"
                Case TipoDocumentoCuentaxPagar.NotaCredito
                    xcodigo = "0703"
            End Select
        Else
            xauto_documento = _CxP.RegistroDato._AutoCxP
            xcodigo = "0501"
        End If
        _DocumentosAnulados.F_CargarRegistro(xauto_documento, xcodigo)
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IDetalleDocumentosAnulados.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        LB_DOCUMENTO = _MiFormulario.Controls.Find("LB_DOCUMENTO", True)(0)
        LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
        LB_HORA = _MiFormulario.Controls.Find("LB_HORA", True)(0)
        LB_USUARIO = _MiFormulario.Controls.Find("LB_USUARIO", True)(0)
        LB_ESTACION = _MiFormulario.Controls.Find("LB_ESTACION", True)(0)
        LB_DETALLE = _MiFormulario.Controls.Find("LB_DETALLE", True)(0)

        _MiFormulario.Text = "Detalle De Documentos Anulados"
        InicializarData()
    End Sub

    Sub InicializarData()
        Select Case _CxP.RegistroDato._TipoDocumento
            Case TipoDocumentoCuentaxPagar.Factura
                LB_TITULO.Text = "COMPRA"
            Case TipoDocumentoCuentaxPagar.NotaDebito
                LB_TITULO.Text = "NOTA DÉBITO"
            Case TipoDocumentoCuentaxPagar.NotaCredito
                LB_TITULO.Text = "NOTA CRÉDITO"
            Case TipoDocumentoCuentaxPagar.ChequeDevuelto
                LB_TITULO.Text = "CHEQUE DEVUELTO"
            Case TipoDocumentoCuentaxPagar.Pago
                LB_TITULO.Text = "PAGO"
        End Select

        LB_NOMBRE.Text = _CxP.RegistroDato._NombreProveedor
        LB_CIRIF.Text = _CxP.RegistroDato._CiRifProveedor
        LB_CODIGO.Text = _CxP.RegistroDato._CodigoProveedor
        LB_DOCUMENTO.Text = _CxP.RegistroDato._NumeroDocumento
        LB_IMPORTE.Text = _CxP.RegistroDato._MontoImporte
        LB_FECHA.Text = _DocumentosAnulados.RegistroDato._FechaEmision
        LB_HORA.Text = _DocumentosAnulados.RegistroDato._HoraAnulacion
        LB_USUARIO.Text = _DocumentosAnulados.RegistroDato._NombreUsuario
        LB_ESTACION.Text = _DocumentosAnulados.RegistroDato._NombreEstacion
        LB_DETALLE.Text = _DocumentosAnulados.RegistroDato._NotaDetalleAnulacion
    End Sub
End Class


''
'' DOCUMENTO DE VENTAS
''
Class c_DetalleDocumentosAnuladosVentas
    Implements IDetalleDocumentosAnulados

    ' CONTROLES
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_DOCUMENTO As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_HORA As System.Windows.Forms.Label
    Dim LB_USUARIO As System.Windows.Forms.Label
    Dim LB_ESTACION As System.Windows.Forms.Label
    Dim LB_DETALLE As System.Windows.Forms.Label

    Dim _Ventas As FichaVentas.V_Ventas
    Dim _DocumentosAnulados As FichaGlobal.c_DocumentosAnulados
    Dim xauto_documento As String = ""
    Dim xcodigo_anulacion As String = ""

    Property _DocumentoACargar() As String
        Get
            Return Me.xauto_documento
        End Get
        Set(ByVal value As String)
            Me.xauto_documento = value
        End Set
    End Property

    Property _CodigoAnulacion() As String
        Get
            Return Me.xcodigo_anulacion
        End Get
        Set(ByVal value As String)
            Me.xcodigo_anulacion = value
        End Set
    End Property

    Sub New(ByVal xautodoc As String)
        _Ventas = New FichaVentas.V_Ventas
        _DocumentosAnulados = New FichaGlobal.c_DocumentosAnulados
        Me._DocumentoACargar = xautodoc
    End Sub

    Sub CargarData()
        Try
            _Ventas.F_BuscarDocumento(Me._DocumentoACargar)
            Select Case _Ventas.RegistroDato._TipoDocumento
                Case FichaVentas.TipoDocumentoVentaRegistrado.Factura : Me._CodigoAnulacion = "0801"
                Case FichaVentas.TipoDocumentoVentaRegistrado.NotaCredito : Me._CodigoAnulacion = "0803"
                Case FichaVentas.TipoDocumentoVentaRegistrado.NotaDebito : Me._CodigoAnulacion = "0801"
                Case FichaVentas.TipoDocumentoVentaRegistrado.NotaEntrega : Me._CodigoAnulacion = "0804"
                Case FichaVentas.TipoDocumentoVentaRegistrado.Pedido : Me._CodigoAnulacion = "0806"
                Case FichaVentas.TipoDocumentoVentaRegistrado.Presupuesto : Me._CodigoAnulacion = "0805"
                Case FichaVentas.TipoDocumentoVentaRegistrado.Chimbo : Me._CodigoAnulacion = "08XX"
                Case FichaVentas.TipoDocumentoVentaRegistrado.ChimboNC : Me._CodigoAnulacion = "0803"
            End Select
            _DocumentosAnulados.F_CargarRegistro(xauto_documento, _CodigoAnulacion)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IDetalleDocumentosAnulados.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        LB_DOCUMENTO = _MiFormulario.Controls.Find("LB_DOCUMENTO", True)(0)
        LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
        LB_HORA = _MiFormulario.Controls.Find("LB_HORA", True)(0)
        LB_USUARIO = _MiFormulario.Controls.Find("LB_USUARIO", True)(0)
        LB_ESTACION = _MiFormulario.Controls.Find("LB_ESTACION", True)(0)
        LB_DETALLE = _MiFormulario.Controls.Find("LB_DETALLE", True)(0)

        _MiFormulario.Text = "Detalle De Documentos Anulados"
        CargarData()
        InicializarData()
    End Sub

    Sub InicializarData()
        Select Case _Ventas.RegistroDato._TipoDocumento
            Case FichaVentas.TipoDocumentoVentaRegistrado.Factura : LB_TITULO.Text = "FACTURA"
            Case FichaVentas.TipoDocumentoVentaRegistrado.NotaCredito : LB_TITULO.Text = "NOTA CREDITO"
            Case FichaVentas.TipoDocumentoVentaRegistrado.NotaDebito : LB_TITULO.Text = "NOTA DEBITO"
            Case FichaVentas.TipoDocumentoVentaRegistrado.NotaEntrega : LB_TITULO.Text = "NOTA ENTREGA"
            Case FichaVentas.TipoDocumentoVentaRegistrado.Pedido : LB_TITULO.Text = "PEDIDO"
            Case FichaVentas.TipoDocumentoVentaRegistrado.Presupuesto : LB_TITULO.Text = "PRESUPUESTO"
            Case FichaVentas.TipoDocumentoVentaRegistrado.Chimbo : LB_TITULO.Text = "NOTA / GUIA"
            Case FichaVentas.TipoDocumentoVentaRegistrado.ChimboNC : LB_TITULO.Text = "NOTA / GUIA - NC"
        End Select

        LB_NOMBRE.Text = _Ventas.RegistroDato._NombreCliente
        LB_CIRIF.Text = _Ventas.RegistroDato._CiRifCliente
        LB_CODIGO.Text = _Ventas.RegistroDato._CodigoCliente
        LB_DOCUMENTO.Text = _Ventas.RegistroDato._Documento
        LB_IMPORTE.Text = String.Format("{0:#0.00}", _Ventas.RegistroDato._TotalGenereal)
        LB_FECHA.Text = _DocumentosAnulados.RegistroDato._FechaEmision
        LB_HORA.Text = _DocumentosAnulados.RegistroDato._HoraAnulacion
        LB_USUARIO.Text = _DocumentosAnulados.RegistroDato._NombreUsuario
        LB_ESTACION.Text = _DocumentosAnulados.RegistroDato._NombreEstacion
        LB_DETALLE.Text = _DocumentosAnulados.RegistroDato._NotaDetalleAnulacion
    End Sub
End Class

''
'' DOCUMENTO DE COMPRAS
''
Class c_DetalleDocumentosAnuladosCompras
    Implements IDetalleDocumentosAnulados

    ' CONTROLES
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_DOCUMENTO As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_HORA As System.Windows.Forms.Label
    Dim LB_USUARIO As System.Windows.Forms.Label
    Dim LB_ESTACION As System.Windows.Forms.Label
    Dim LB_DETALLE As System.Windows.Forms.Label

    Dim _Compras As FichaCompras.c_Compra
    Dim _DocumentosAnulados As FichaGlobal.c_DocumentosAnulados
    Dim xauto_documento As String = ""
    Dim xcodigo_anulacion As String = ""

    Property _DocumentoACargar() As String
        Get
            Return Me.xauto_documento
        End Get
        Set(ByVal value As String)
            Me.xauto_documento = value
        End Set
    End Property

    Property _CodigoAnulacion() As String
        Get
            Return Me.xcodigo_anulacion
        End Get
        Set(ByVal value As String)
            Me.xcodigo_anulacion = value
        End Set
    End Property

    Sub New(ByVal xautodoc As String)
        _Compras = New FichaCompras.c_Compra
        _DocumentosAnulados = New FichaGlobal.c_DocumentosAnulados
        Me._DocumentoACargar = xautodoc
    End Sub

    Sub CargarData()
        Try
            _Compras.F_CargarCompra(Me._DocumentoACargar)
            Select Case _Compras.RegistroDato._TipoDocumentoCompra
                Case TipoDocumentoCompra.Factura : Me._CodigoAnulacion = "0701"
                Case TipoDocumentoCompra.NotaCredito : Me._CodigoAnulacion = "0703"
                Case TipoDocumentoCompra.OrdenCompra : Me._CodigoAnulacion = "0704"
            End Select
            _DocumentosAnulados.F_CargarRegistro(xauto_documento, _CodigoAnulacion)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IDetalleDocumentosAnulados.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        LB_DOCUMENTO = _MiFormulario.Controls.Find("LB_DOCUMENTO", True)(0)
        LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
        LB_HORA = _MiFormulario.Controls.Find("LB_HORA", True)(0)
        LB_USUARIO = _MiFormulario.Controls.Find("LB_USUARIO", True)(0)
        LB_ESTACION = _MiFormulario.Controls.Find("LB_ESTACION", True)(0)
        LB_DETALLE = _MiFormulario.Controls.Find("LB_DETALLE", True)(0)

        _MiFormulario.Text = "Detalle De Documentos Anulados"
        CargarData()
        InicializarData()
    End Sub

    Sub InicializarData()
        Select Case _Compras.RegistroDato._TipoDocumentoCompra
            Case TipoDocumentoCompra.Factura : LB_TITULO.Text = "FACTURA"
            Case TipoDocumentoCompra.NotaCredito : LB_TITULO.Text = "NOTA CREDITO"
            Case TipoDocumentoCompra.OrdenCompra : LB_TITULO.Text = "ORDEN COMPRA"
        End Select

        LB_NOMBRE.Text = _Compras.RegistroDato._NombreProveedor
        LB_CIRIF.Text = _Compras.RegistroDato._CiRifProveedor
        LB_CODIGO.Text = _Compras.RegistroDato._CodigoProveedor
        LB_DOCUMENTO.Text = _Compras.RegistroDato._NumeroDocumentoCompra
        LB_IMPORTE.Text = String.Format("{0:#0.00}", _Compras.RegistroDato._TotalGeneral)
        LB_FECHA.Text = _DocumentosAnulados.RegistroDato._FechaEmision
        LB_HORA.Text = _DocumentosAnulados.RegistroDato._HoraAnulacion
        LB_USUARIO.Text = _DocumentosAnulados.RegistroDato._NombreUsuario
        LB_ESTACION.Text = _DocumentosAnulados.RegistroDato._NombreEstacion
        LB_DETALLE.Text = _DocumentosAnulados.RegistroDato._NotaDetalleAnulacion
    End Sub
End Class