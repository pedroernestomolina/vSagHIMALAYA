Imports DataSistema.MiDataSistema.DataSistema

Public Class DetalleDocumentosCxC
    Dim _Plantilla As IDetalleDocumentosCxC

    Sub New(ByVal xplantilla As IDetalleDocumentosCxC)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Sub Inicializar()
        _Plantilla.Inicializar(Me)
    End Sub

    Private Sub DetalleDocumentoCxC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DetalleDocumentoCxC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializar()
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR FORMULARIO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub
End Class

Public Interface IDetalleDocumentosCxC
    Sub Inicializar(ByVal xformulario As Object)
End Interface


''
'' CUENTAS POR COBRAR
''
Class c_DetalleDocumentosCxC
    Implements IDetalleDocumentosCxC

    'LABELS
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_DOCUMENTO As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_FECHAEMISION As System.Windows.Forms.Label
    Dim LB_FECHAVENCIMIENTO As System.Windows.Forms.Label
    Dim LB_DETALLE As System.Windows.Forms.Label
    Dim LB_NUMERO As System.Windows.Forms.Label
    Dim LB_AGENCIA As System.Windows.Forms.Label
    Dim LB_FECHADEVOLUCION As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim LB_ACUMULADO As System.Windows.Forms.Label
    Dim LB_RESTA As System.Windows.Forms.Label
    Dim LB_ESTATUS As System.Windows.Forms.Label
    Dim LB_APLICA As System.Windows.Forms.Label

    Dim _CxC_Registro As FichaCtasCobrar.c_CxC.c_Registro
    Dim xcxc_moventrada As FichaCtasCobrar.c_MovimientosEntrada

    Property _MovimientoEntradaCxC() As FichaCtasCobrar.c_MovimientosEntrada
        Get
            Return xcxc_moventrada
        End Get
        Set(ByVal value As FichaCtasCobrar.c_MovimientosEntrada)
            xcxc_moventrada = value
        End Set
    End Property

    Sub New(ByVal xficha1 As FichaCtasCobrar.c_CxC.c_Registro)
        _CxC_Registro = xficha1
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IDetalleDocumentosCxC.Inicializar
        Try
            Dim _MiFormulario As System.Windows.Forms.Form = xformulario
            LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
            LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
            LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
            LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
            LB_DOCUMENTO = _MiFormulario.Controls.Find("LB_DOCUMENTO", True)(0)
            LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
            LB_FECHAEMISION = _MiFormulario.Controls.Find("LB_FECHAEMISION", True)(0)
            LB_FECHAVENCIMIENTO = _MiFormulario.Controls.Find("LB_FECHAVENCIMIENTO", True)(0)
            LB_DETALLE = _MiFormulario.Controls.Find("LB_DETALLE", True)(0)
            LB_NUMERO = _MiFormulario.Controls.Find("LB_NUMERO", True)(0)
            LB_AGENCIA = _MiFormulario.Controls.Find("LB_AGENCIA", True)(0)
            LB_FECHADEVOLUCION = _MiFormulario.Controls.Find("LB_FECHADEVOLUCION", True)(0)
            LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
            LB_ACUMULADO = _MiFormulario.Controls.Find("LB_ACUMULADO", True)(0)
            LB_RESTA = _MiFormulario.Controls.Find("LB_RESTA", True)(0)
            LB_ESTATUS = _MiFormulario.Controls.Find("LB_ESTATUS", True)(0)
            LB_APLICA = _MiFormulario.Controls.Find("LB_APLICA", True)(0)

            _MovimientoEntradaCxC = New FichaCtasCobrar.c_MovimientosEntrada
            _MovimientoEntradaCxC.M_CargarRegistro(_CxC_Registro._AutoMovimientoEntrada)
            InicializarData()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub InicializarData()
        Select Case _MovimientoEntradaCxC.RegistroDato._TipoDocumento
            Case TipoDocumentoMovEntradaCxC.Factura
                LB_TITULO.Text = "FACTURA"
                LB_NUMERO.Text = "N/A"
                LB_AGENCIA.Text = "N/A"
                LB_FECHADEVOLUCION.Text = "N/A"
                LB_FECHAVENCIMIENTO.Text = _MovimientoEntradaCxC.RegistroDato._FechaVencimiento.ToShortDateString
            Case TipoDocumentoMovEntradaCxC.NotaDebito
                LB_TITULO.Text = "NOTA DE DÉBITO"
                LB_NUMERO.Text = "N/A"
                LB_AGENCIA.Text = "N/A"
                LB_FECHADEVOLUCION.Text = "N/A"
                LB_FECHAVENCIMIENTO.Text = "N/A"
            Case TipoDocumentoMovEntradaCxC.NotaCredito
                LB_TITULO.Text = "NOTA DE CRÉDITO"
                LB_NUMERO.Text = "N/A"
                LB_AGENCIA.Text = "N/A"
                LB_FECHADEVOLUCION.Text = "N/A"
                LB_FECHAVENCIMIENTO.Text = _MovimientoEntradaCxC.RegistroDato._FechaVencimiento.ToShortDateString
            Case TipoDocumentoMovEntradaCxC.ChequeDevuelto
                LB_TITULO.Text = "CHEQUE DEVUELTO"
                LB_NUMERO.Text = _MovimientoEntradaCxC.RegistroDato._NumeroPlanilla
                LB_AGENCIA.Text = _MovimientoEntradaCxC.RegistroDato._NombreAgencia
                LB_FECHADEVOLUCION.Text = _MovimientoEntradaCxC.RegistroDato._FechaDevolucion.ToShortDateString
                LB_FECHAVENCIMIENTO.Text = "N/A"
            Case TipoDocumentoMovEntradaCxC.Prestamo
                LB_TITULO.Text = "PRESTAMO"
                LB_NUMERO.Text = "N/A"
                LB_AGENCIA.Text = "N/A"
                LB_FECHADEVOLUCION.Text = "N/A"
                LB_FECHAVENCIMIENTO.Text = _MovimientoEntradaCxC.RegistroDato._FechaVencimiento.ToShortDateString
            Case TipoDocumentoMovEntradaCxC.Anticipos
                LB_TITULO.Text = "ACTICIPOS"
                LB_NUMERO.Text = _MovimientoEntradaCxC.RegistroDato._NumeroPlanilla
                LB_AGENCIA.Text = _MovimientoEntradaCxC.RegistroDato._NombreAgencia
                LB_FECHADEVOLUCION.Text = "N/A"
                LB_FECHAVENCIMIENTO.Text = _MovimientoEntradaCxC.RegistroDato._FechaVencimiento.ToShortDateString
        End Select

        LB_NOMBRE.Text = _MovimientoEntradaCxC.RegistroDato._NombreCliente
        LB_CIRIF.Text = _MovimientoEntradaCxC.RegistroDato._CiRifCliente
        LB_CODIGO.Text = _MovimientoEntradaCxC.RegistroDato._CodigoCliente
        LB_DOCUMENTO.Text = _MovimientoEntradaCxC.RegistroDato._Documento
        LB_FECHA.Text = _MovimientoEntradaCxC.RegistroDato._FechaProceso.ToShortDateString
        LB_FECHAEMISION.Text = _MovimientoEntradaCxC.RegistroDato._FechaEmision.ToShortDateString
        LB_DETALLE.Text = _MovimientoEntradaCxC.RegistroDato._NotasDocumento
        LB_IMPORTE.Text = String.Format("{0:#0.00}", _MovimientoEntradaCxC.RegistroDato._TotalGenereal)
        LB_ACUMULADO.Text = String.Format("{0:#0.00}", Math.Abs(_CxC_Registro._MontoAcumulado))
        LB_RESTA.Text = String.Format("{0:#0.00}", Math.Abs(_CxC_Registro._MontoPorCobrar))
        LB_APLICA.Text = _MovimientoEntradaCxC.RegistroDato._DocumentoAplica

        If _MovimientoEntradaCxC.RegistroDato._EstatusDocumento = TipoEstatus.Activo Then
            LB_ESTATUS.Text = "ACTIVO"
            LB_ESTATUS.ForeColor = Color.Black
        Else
            LB_ESTATUS.Text = "ANULADO"
            LB_ESTATUS.ForeColor = Color.Red
        End If
    End Sub
End Class


''
'' CUENTAS POR PAGAR
''
Class c_DetalleDocumentosCxP
    Implements IDetalleDocumentosCxC

    'LABELS
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_DOCUMENTO As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_FECHAEMISION As System.Windows.Forms.Label
    Dim LB_FECHAVENCIMIENTO As System.Windows.Forms.Label
    Dim LB_DETALLE As System.Windows.Forms.Label
    Dim LB_NUMERO As System.Windows.Forms.Label
    Dim LB_AGENCIA As System.Windows.Forms.Label
    Dim LB_FECHADEVOLUCION As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim LB_ACUMULADO As System.Windows.Forms.Label
    Dim LB_RESTA As System.Windows.Forms.Label
    Dim LB_ESTATUS As System.Windows.Forms.Label
    Dim LB_APLICA As System.Windows.Forms.Label
    Dim LB_1 As System.Windows.Forms.Label

    Dim _CxP_Registro As FichaCtasPagar.c_CxP.c_Registro
    Dim xcxp_moventrada As FichaCtasPagar.c_MovimientosEntrada

    Property _MovimientoEntradaCxP() As FichaCtasPagar.c_MovimientosEntrada
        Get
            Return xcxp_moventrada
        End Get
        Set(ByVal value As FichaCtasPagar.c_MovimientosEntrada)
            xcxp_moventrada = value
        End Set
    End Property

    Sub New(ByVal xficha1 As FichaCtasPagar.c_CxP.c_Registro)
        _CxP_Registro = xficha1
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IDetalleDocumentosCxC.Inicializar
        Try
            Dim _MiFormulario As System.Windows.Forms.Form = xformulario
            LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
            LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
            LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
            LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
            LB_DOCUMENTO = _MiFormulario.Controls.Find("LB_DOCUMENTO", True)(0)
            LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
            LB_FECHAEMISION = _MiFormulario.Controls.Find("LB_FECHAEMISION", True)(0)
            LB_FECHAVENCIMIENTO = _MiFormulario.Controls.Find("LB_FECHAVENCIMIENTO", True)(0)
            LB_DETALLE = _MiFormulario.Controls.Find("LB_DETALLE", True)(0)
            LB_NUMERO = _MiFormulario.Controls.Find("LB_NUMERO", True)(0)
            LB_AGENCIA = _MiFormulario.Controls.Find("LB_AGENCIA", True)(0)
            LB_FECHADEVOLUCION = _MiFormulario.Controls.Find("LB_FECHADEVOLUCION", True)(0)
            LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
            LB_ACUMULADO = _MiFormulario.Controls.Find("LB_ACUMULADO", True)(0)
            LB_RESTA = _MiFormulario.Controls.Find("LB_RESTA", True)(0)
            LB_ESTATUS = _MiFormulario.Controls.Find("LB_ESTATUS", True)(0)
            LB_APLICA = _MiFormulario.Controls.Find("LB_APLICA", True)(0)
            LB_1 = _MiFormulario.Controls.Find("LABEL8", True)(0)

            _MovimientoEntradaCxP = New FichaCtasPagar.c_MovimientosEntrada
            _MovimientoEntradaCxP.M_CargarRegistro(_CxP_Registro._AutoMovimientoEntrada)
            InicializarData()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub InicializarData()
        Select Case _MovimientoEntradaCxP.RegistroDato._TipoDocumento
            Case TipoDocumentoMovEntradaCxP.Factura
                LB_TITULO.Text = "FACTURA"
                LB_NUMERO.Text = "N/A"
                LB_AGENCIA.Text = "N/A"
                LB_FECHADEVOLUCION.Text = "N/A"
                LB_FECHAVENCIMIENTO.Text = _MovimientoEntradaCxP.RegistroDato._FechaVencimiento.ToShortDateString
            Case TipoDocumentoMovEntradaCxP.NotaDebito
                LB_TITULO.Text = "NOTA DE DÉBITO"
                LB_NUMERO.Text = "N/A"
                LB_AGENCIA.Text = "N/A"
                LB_FECHADEVOLUCION.Text = "N/A"
                LB_FECHAVENCIMIENTO.Text = "N/A"
                LB_1.Text = "Documento Al Cual Aplica:"
            Case TipoDocumentoMovEntradaCxP.NotaCredito
                LB_TITULO.Text = "NOTA DE CRÉDITO"
                LB_NUMERO.Text = "N/A"
                LB_AGENCIA.Text = "N/A"
                LB_FECHADEVOLUCION.Text = "N/A"
                LB_FECHAVENCIMIENTO.Text = _MovimientoEntradaCxP.RegistroDato._FechaVencimiento.ToShortDateString
                LB_1.Text = "Documento Al Cual Aplica:"
            Case TipoDocumentoMovEntradaCxP.ChequeDevuelto
                LB_TITULO.Text = "CHEQUE DEVUELTO"
                LB_NUMERO.Text = _MovimientoEntradaCxP.RegistroDato._NumeroPlanilla
                LB_AGENCIA.Text = _MovimientoEntradaCxP.RegistroDato._NombreAgencia
                LB_FECHADEVOLUCION.Text = _MovimientoEntradaCxP.RegistroDato._FechaDevolucion.ToShortDateString
                LB_FECHAVENCIMIENTO.Text = "N/A"
        End Select

        LB_NOMBRE.Text = _MovimientoEntradaCxP.RegistroDato._NombreProveedor
        LB_CIRIF.Text = _MovimientoEntradaCxP.RegistroDato._CiRifProveedor
        LB_CODIGO.Text = _MovimientoEntradaCxP.RegistroDato._CodigoProveedor
        LB_DOCUMENTO.Text = _MovimientoEntradaCxP.RegistroDato._Documento
        LB_FECHA.Text = _MovimientoEntradaCxP.RegistroDato._FechaProceso.ToShortDateString
        LB_FECHAEMISION.Text = _MovimientoEntradaCxP.RegistroDato._FechaEmision.ToShortDateString
        LB_DETALLE.Text = _MovimientoEntradaCxP.RegistroDato._NotasDocumento
        LB_IMPORTE.Text = String.Format("{0:#0.00}", _MovimientoEntradaCxP.RegistroDato._TotalGenereal)
        LB_ACUMULADO.Text = String.Format("{0:#0.00}", Math.Abs(_CxP_Registro._MontoAcumulado))
        LB_RESTA.Text = String.Format("{0:#0.00}", Math.Abs(_CxP_Registro._MontoPorPagar))
        LB_APLICA.Text = _MovimientoEntradaCxP.RegistroDato._DocumentoAplica

        If _MovimientoEntradaCxP.RegistroDato._EstatusDocumento = TipoEstatus.Activo Then
            LB_ESTATUS.Text = "ACTIVO"
            LB_ESTATUS.ForeColor = Color.Black
        Else
            LB_ESTATUS.Text = "ANULADO"
            LB_ESTATUS.ForeColor = Color.Red
        End If
    End Sub
End Class