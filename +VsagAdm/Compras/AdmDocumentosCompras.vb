Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles

Public Class AdmDocumentosCompras
    Event _AutoDocumento(ByVal xauto_doc As String)

    Dim xhabilitar_retorno As Boolean
    Dim xhabilitarrevertir As Boolean
    Dim xhabilitarbotones As Boolean

    Dim xplantilla As IAdministradorDocumentosCompras

    Property _HabilitarRetorno()
        Get
            Return xhabilitar_retorno
        End Get
        Set(ByVal value)
            xhabilitar_retorno = value
        End Set
    End Property

    Property _HabilitarRevertir() As Boolean
        Get
            Return xhabilitarrevertir
        End Get
        Set(ByVal value As Boolean)
            xhabilitarrevertir = value
        End Set
    End Property

    Property _HabilitarBotones() As Boolean
        Get
            Return xhabilitarbotones
        End Get
        Set(ByVal value As Boolean)
            xhabilitarbotones = value
        End Set
    End Property

    Property _Plantilla() As IAdministradorDocumentosCompras
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IAdministradorDocumentosCompras)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xtipo_plantilla As IAdministradorDocumentosCompras, Optional ByVal RetornarAuto As Boolean = False, Optional ByVal xhabilitar_revertir As Boolean = False, Optional ByVal xhabilitar_botones As Boolean = True)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xtipo_plantilla
        _HabilitarRetorno = RetornarAuto
        _HabilitarBotones = xhabilitar_botones
        _HabilitarRevertir = xhabilitar_revertir
    End Sub

    Sub Inicializa()
        Me.E_ITEMS_1.Text = "0"
        Me.E_ITEMS_2.Text = "0"

        BT_ANULAR.Enabled = _HabilitarBotones
        BT_REVERTIR.Enabled = (_HabilitarBotones And _HabilitarRevertir)
        BT_VISUALIZAR.Enabled = _HabilitarBotones

        _Plantilla.Inicializar(Me)
        IrInicio()
    End Sub

    Private Sub AdmDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            IrInicio()
        End If
    End Sub

    Private Sub AdmDocumentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializa()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub MisFechas1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (Me.MisFechas2.Checked) Then
            If (MisFechas1.Value.Date > MisFechas2.Value.Date) Then
                Funciones.MensajeDeAlerta("Fecha Incorrecta Verifique Por Favor...")
                MisFechas1.Value = MisFechas2.Value
            End If
        End If
    End Sub

    Private Sub MisFechas2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (Me.MisFechas1.Checked) Then
            If (MisFechas2.Value.Date < MisFechas1.Value.Date) Then
                Funciones.MensajeDeAlerta("Fecha Incorrecta Verifique Por Favor...")
                MisFechas2.Value = MisFechas1.Value
            End If
        End If
    End Sub

    Sub IrInicio()
        With Me.MT_BUSCAR
            .Text = ""
            .Select()
            .Focus()
        End With
    End Sub

    Private Sub MCB_BUSCAR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSCAR.SelectedIndexChanged
        IrInicio()
    End Sub

    Private Sub BusquedaAvanzada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_AVANZADA.Click
        _Plantilla._BusquedaAvanzada()
    End Sub

    Private Sub Visualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_VISUALIZAR.Click
        _Plantilla._VisualizarDocumento()
    End Sub

    Private Sub Anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ANULAR.Click
        _Plantilla._AnularDocumento()
    End Sub

    Private Sub BT_BUSCAR_AHORA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR_AHORA.Click
        IrBuscar()
    End Sub

    Sub IrBuscar()
        Try
            _Plantilla._BuscarAhora()
            Me.MT_BUSCAR.Text = ""
            Me.MisGrid1.Select()
            Me.MisGrid1.Focus()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub MisGrid1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid1.Accion
        If _HabilitarRetorno Then
            RaiseEvent _AutoDocumento(_Plantilla._AutoDocumento)
            Me.Close()
        Else
            _Plantilla._ConsultarDocumento()
        End If
    End Sub

    Private Sub BT_REVERTIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_REVERTIR.Click
        If _HabilitarRevertir Then
            If _Plantilla._RevertirDocumento() Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub AdmDocumentosCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IAdministradorDocumentosCompras
    Function _BuscarAhora() As Boolean
    Function _VisualizarDocumento() As Boolean
    Function _BusquedaAvanzada() As Boolean
    Function _AnularDocumento(Optional ByVal revertir As Boolean = False) As Boolean
    Function _ConsultarDocumento() As Boolean
    Function _RevertirDocumento() As Boolean

    ReadOnly Property _AutoDocumento() As String

    Sub Inicializar(ByVal xobj As Object)

    Enum TipoBusqueda As Integer
        Nombre = 0
        CI_rif = 1
        Codigo_entidad = 2
    End Enum

    Class C_FilterData
        Private f_tipofilter As TipoBusqueda
        Private f_texto As String
        Private f_desdefecha As DateTime
        Private f_hastafecha As DateTime
        Private f_tipodocumento As String

        Property _TipoFilter() As TipoBusqueda
            Get
                Return f_tipofilter
            End Get
            Set(ByVal value As TipoBusqueda)
                f_tipofilter = value
            End Set
        End Property

        Property _Texto() As String
            Get
                Return f_texto
            End Get
            Set(ByVal value As String)
                f_texto = value
            End Set
        End Property

        Property _DesdeFecha() As Date
            Get
                Return f_desdefecha.Date
            End Get
            Set(ByVal value As Date)
                f_desdefecha = value
            End Set
        End Property

        Property _HastaFecha() As Date
            Get
                Return f_hastafecha.Date
            End Get
            Set(ByVal value As Date)
                f_hastafecha = value
            End Set
        End Property

        Property _TipoDocumento() As String
            Get
                Return f_tipodocumento
            End Get
            Set(ByVal value As String)
                f_tipodocumento = value
            End Set
        End Property

        Sub New()
            Limpiar()
        End Sub

        Sub Limpiar()
            _TipoFilter = 0
            _TipoDocumento = "00"
            _Texto = ""
            _DesdeFecha = Date.MinValue
            _HastaFecha = Date.MinValue
        End Sub
    End Class
End Interface

Public Class AdmDoc_Compras
    Implements IAdministradorDocumentosCompras
    Event _ActualizarFichaDeCompras()
    Event _OrdenTrasladar(ByVal xautodoc As String)


    Class TiposDocumentos
        Private xnombre As String
        Private xcodigo As String

        Property _Nombre() As String
            Get
                Return xnombre
            End Get
            Set(ByVal value As String)
                xnombre = value
            End Set
        End Property

        Property _Codigo() As String
            Get
                Return xcodigo
            End Get
            Set(ByVal value As String)
                xcodigo = value
            End Set
        End Property

        Sub New()
            Me._Codigo = ""
            Me._Nombre = ""
        End Sub
    End Class

#Region "FUNCIONES SELECT"

    Const SELECT_COMPRAS As String = "select top(@top) fecha, " & _
                                         "(case tipo when '01' then 'Compra' " & _
                                         "           when '02' then 'Nota Débito' " & _
                                         "           when '03' then 'Nota Crédito' " & _
                                         "           when '04' then 'Orden Compra' end) tipo, " & _
                                         "documento, " & _
                                         "fecha_vencimiento, " & _
                                         "dias, " & _
                                         "nombre, " & _
                                         "ci_rif, " & _
                                         "total, " & _
                                         "(case estatus when '0' then 'Activo   ' " & _
                                         "              when '2' then 'Procesado' " & _
                                         "              when '1' then 'Anulado  ' end) estatus, " & _
                                         "auto, * " & _
                                     "from compras c "

    Const SELECT_RELACION_COMPRAS As String = "SELECT fecha" & _
                                                     ",'CtaPagar' tipo " & _
                                                     ",documento " & _
                                                     ",detalle " & _
                                                     ",importe " & _
                                                     ",(case estatus " & _
                                                        "when '1' then 'Anulado' " & _
                                                        "else case cancelado " & _
                                                            "when '0' then 'Pendiente' " & _
                                                            "when '1' then 'Cancelado' End " & _
                                                    "end) estatus " & _
                                             "FROM cxp " & _
                                             "WHERE auto_documento = @auto_documento and tipo_documento in ('FAC','NCF') " & _
                                             "UNION " & _
                                             "SELECT d.fecha fecha " & _
                                                     ",'Pago' tipo " & _
                                                     ",numero_recibo documento " & _
                                                     ",r.detalle detalle " & _
                                                     ",monto importe " & _
                                                     ",(case r.estatus " & _
                                                         "when '1' then 'Anulado' " & _
                                                         "else '' end) estatus " & _
                                             "FROM cxp_documentos d inner join cxp_recibos r on d.auto_cxp_recibo = r.auto inner join cxp c on d.auto_cxp = c.auto " & _
                                             "WHERE c.auto_documento = @auto_documento " & _
                                             "UNION " & _
                                             "SELECT fecha " & _
                                                  ",'Retención' tipo " & _
                                                  ",documento " & _
                                                  ",'' detalle " & _
                                                  ",retencion importe " & _
                                                  ",(case estatus " & _
                                                        "when '1' then 'Anulado' " & _
                                                        "else  '' End) estatus " & _
                                             "FROM retenciones_compras_detalle " & _
                                             "WHERE auto_documento = @auto_documento " & _
                                             "UNION " & _
                                             "SELECT fecha " & _
                                                     ",(case tipo " & _
                                                        "when '02' then 'Nota Débito' " & _
                                                        "when '03' then 'Nota Crédito' end) tipo" & _
                                                     ",documento " & _
                                                     ",nota detalle " & _
                                                     ",total " & _
                                                     ",(case estatus " & _
                                                         "when '1' then 'Anulado' " & _
                                                         "else '' end) estatus " & _
                                             "FROM compras " & _
                                             "WHERE aplica = @aplica and n_serieaplica=@serie and auto_entidad=@auto_entidad and tipo in ('02','03') "
#End Region

    Dim f_data As DataTable
    Dim f_binding As BindingSource
    Dim f_datarelacionada As DataTable
    Dim f_bindingrelacionada As BindingSource
    Dim f_filterdata As IAdministradorDocumentosCompras.C_FilterData

    Dim xlista_estatus As String() = {"Activos", "Anulados", "Todos"}
    Dim xtipodoc As TipoDocumentoCompra
    Dim x_maximo_items_mostrar As Integer
    Dim xsql_busqueda_actual As String

    Property _SqlBusquedaActual() As String
        Get
            Return xsql_busqueda_actual
        End Get
        Set(ByVal value As String)
            xsql_busqueda_actual = value
        End Set
    End Property

    Property _MaximoItemsMostrar() As Integer
        Get
            Return x_maximo_items_mostrar
        End Get
        Set(ByVal value As Integer)
            x_maximo_items_mostrar = value
        End Set
    End Property

    Property _TipoDocumento() As TipoDocumentoCompra
        Get
            Return xtipodoc
        End Get
        Set(ByVal value As TipoDocumentoCompra)
            xtipodoc = value
        End Set
    End Property

    Sub New(ByVal xtope As Integer, Optional ByVal xtipo As TipoDocumentoCompra = TipoDocumentoCompra.Factura)
        _MaximoItemsMostrar = xtope

        f_data = New DataTable
        f_binding = New BindingSource(f_data, "")
        f_datarelacionada = New DataTable
        f_bindingrelacionada = New BindingSource(f_datarelacionada, "")

        f_filterdata = New IAdministradorDocumentosCompras.C_FilterData

        _SqlBusquedaActual = ""
        _TipoDocumento = xtipo
    End Sub

    Public Function _BuscarAhora() As Boolean Implements IAdministradorDocumentosCompras._BuscarAhora
        With f_filterdata
            If MF_INICIO.Checked Then
                ._DesdeFecha = MF_INICIO.Value
            End If
            If MF_HASTA.Checked Then
                ._HastaFecha = MF_HASTA.Value
            End If
            ._Texto = MT_BUSCAR.r_Valor
            ._TipoDocumento = MCB_TIPO_DOC.SelectedValue
            ._TipoFilter = MCB_BUSCAR.SelectedIndex
        End With

        Dim xsentencia As String = ""
        Dim xcondicion As String = "where c.auto<>'' "
        Dim xtexto As String = f_filterdata._Texto

        If (f_filterdata._Texto <> "") Then
            If xtexto.Substring(0, 1) = "*" Then
                xtexto = xtexto.Substring(1)
            End If

            Select Case f_filterdata._Texto.Substring(0, 1)
                Case "*" : xcondicion += "and c." + f_filterdata._TipoFilter.ToString() + " like '%" + xtexto + "%' "
                Case Else : xcondicion += "and c." + f_filterdata._TipoFilter.ToString() + " like '" + xtexto + "%' "
            End Select
        End If

        If f_filterdata._TipoDocumento <> "00" Then
            If f_filterdata._TipoDocumento = "05" Then
                xcondicion += "and c.N_tipo_compra='2' "
            Else
                xcondicion += "and c.N_tipo_compra='1' and c.tipo = '" + f_filterdata._TipoDocumento + "' "
            End If
        Else
            xcondicion += "and c.tipo in ('01','02','03','04') "
        End If

        Dim xdesde As New SqlParameter("", "")
        Dim xhasta As New SqlParameter("", "")
        If (f_filterdata._DesdeFecha <> Date.MinValue) Then
            'xcondicion += "and c.fecha >= '" & f_filterdata._DesdeFecha & "' "
            xcondicion += " and c.fecha >= @desde "
            xdesde.ParameterName = "@desde"
            xdesde.Value = f_filterdata._DesdeFecha
        End If

        If (f_filterdata._HastaFecha <> Date.MinValue) Then
            'xcondicion += "and c.fecha <= '" & f_filterdata._HastaFecha & "' "
            xcondicion += " and c.fecha <= @hasta "
            xhasta.ParameterName = "@hasta"
            xhasta.Value = f_filterdata._HastaFecha
        End If

        Select Case MCB_ESTATUS_DOC.SelectedIndex
            Case 0 : xcondicion += "and estatus='0' "
            Case 1 : xcondicion += "and estatus='1' "
        End Select

        xsentencia = SELECT_COMPRAS & xcondicion & "order by c.fecha desc, c.tipo, c.auto desc"
        Dim xp1 As New SqlParameter("@top", _MaximoItemsMostrar)
        Buscar(xsentencia, xp1, xdesde, xhasta)
        f_filterdata.Limpiar()
    End Function

    Sub Buscar(ByVal xsql As String, ParamArray p() As SqlParameter)
        _SqlBusquedaActual = xsql
        Try
            g_MiData.F_GetData(xsql, f_data, p)
            LB1.Text = f_binding.Count.ToString
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Buscar(ByVal xsql As String)
        _SqlBusquedaActual = xsql
        Dim xp1 As New SqlParameter("@top", _MaximoItemsMostrar)
        Try
            g_MiData.F_GetData(xsql, f_data, xp1)
            LB1.Text = f_binding.Count.ToString
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public ReadOnly Property _AutoDocumento() As String Implements IAdministradorDocumentosCompras._AutoDocumento
        Get
            If f_binding.Current IsNot Nothing Then
                Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                Return xreg("auto").ToString
            Else
                Return ""
            End If
        End Get
    End Property

    Public Function _BusquedaAvanzada() As Boolean Implements IAdministradorDocumentosCompras._BusquedaAvanzada
        Try
            Dim xficha As New BusquedaAvanzadaCompra()
            AddHandler xficha._LlamarReceptor, AddressOf NuevaBusqueda

            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub NuevaBusqueda(ByVal xfiltro As String)
        Buscar(xfiltro)
    End Sub

    Public Function _VisualizarDocumento() As Boolean Implements IAdministradorDocumentosCompras._VisualizarDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                Dim xcompra As New FichaCompras.c_Compra

                xcompra.F_CargarCompra(xreg("auto").ToString.Trim)
                If xcompra.RegistroDato._TipoCompraRegistrada = TipoCompraRegistrada.CompraMercancia Then
                    VisualizarDoc_Compras(xreg("auto").ToString.Trim)
                Else
                    VisualizarDoc_Gastos(xreg("auto").ToString.Trim)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _ConsultarDocumento() As Boolean Implements IAdministradorDocumentosCompras._ConsultarDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                Dim xcompra As New FichaCompras.c_Compra
                xcompra.F_CargarCompra(xreg("auto").ToString.Trim)

                If xcompra.RegistroDato._EstatusCompra = TipoEstatus.Inactivo Then
                    Dim xficha As DetalleDocumentosAnulados
                    Dim xclas As New c_DetalleDocumentosAnuladosCompras(xcompra.RegistroDato._AutoDocumentoCompra)
                    xficha = New DetalleDocumentosAnulados(xclas)
                    xficha.ShowDialog()
                Else
                    If xcompra.RegistroDato._TipoCompraRegistrada = TipoCompraRegistrada.CompraMercancia Then
                        Dim xficha As New Compras_Detalle(xreg("auto").ToString)
                        With xficha
                            .ShowDialog()
                        End With
                    Else
                        VisualizarDoc_Gastos(xcompra.RegistroDato._AutoDocumentoCompra)
                    End If
                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Function

    Public Function _AnularDocumento(Optional ByVal revertir As Boolean = False) As Boolean Implements IAdministradorDocumentosCompras._AnularDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_AnularDocumento.F_Permitir()

                Dim xficha As New AnularDocumento(New AnularDocumento_Compra(f_binding.Current("tipo")))
                With xficha
                    .ShowDialog()
                    If ._EstatusSalida Then
                        Dim xdet As String = ._DetalleNotas
                        Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                        Dim xdoc As New FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro
                        Dim xdocrevertir As FichaCompras.DocRevertir = Nothing

                        With xdoc
                            ._AutoDocumento = xreg("auto")
                            ._CodigoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._CodigoUsuario
                            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
                            ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
                            ._NotasDetalle = xdet
                            ._FechaEmision = g_MiData.p_FechaDelMotorBD
                            ._Hora = g_MiData.p_HoraDelMotorBD
                        End With

                        If revertir Then
                            xdocrevertir = New FichaCompras.DocRevertir
                            With xdocrevertir
                                ._EquipoEstacion = g_EquipoEstacion.p_EstacionNombre
                                ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                                ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
                            End With
                        End If

                        Dim xcompra As New FichaCompras
                        AddHandler xcompra.ActualizarTabla, AddressOf ActualizarTabla

                        xcompra.F_AnularDocumento(xdoc, xdocrevertir)
                        MessageBox.Show("Documento Anulado Satisfactoriamente", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    End If
                End With
            Catch ex As Exception
                ActualizarTabla()
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Function

    Sub ActualizarTabla()
        Buscar(_SqlBusquedaActual)
    End Sub

    Public Function _RevertirDocumento() As Boolean Implements IAdministradorDocumentosCompras._RevertirDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xfichacompra As New FichaCompras
                Dim xauto As String = f_binding.Current("auto")
                xfichacompra.F_Compras.F_CargarCompra(xauto)

                If xfichacompra.F_Compras.RegistroDato._TipoDocumentoCompra = _TipoDocumento Then
                    If xfichacompra.F_Compras.RegistroDato._TipoCompraRegistrada = TipoCompraRegistrada.CompraMercancia Then
                        If _AnularDocumento(True) Then
                            CargarTemporalCompra(xauto, xfichacompra.F_Compras.RegistroDato._TipoDocumentoCompra)
                            RaiseEvent _ActualizarFichaDeCompras()
                            Return True
                        End If
                    Else
                        Throw New Exception("ERROR AL CARGAR TIPO DE DOCUMENTO, DOCUMENTO NO TIENES ITEMS PARA REVERSAR")
                    End If
                Else
                    Throw New Exception("ERROR AL CARGAR TIPO DE DOCUMENTO, DEBE SELECCIONAR UN DOCUMENTO DE " + _TipoDocumento.ToString.ToUpper)
                End If
            Catch ex As Exception
                ActualizarTabla()
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Sub CargarTemporalCompra(ByVal xauto As String, ByVal xtipo As Integer)
        Dim xtabla As New DataTable
        Dim xp1 As SqlParameter = New SqlParameter("@auto_documento", xauto)
        g_MiData.F_GetData("select auto x1 from compras_detalle where auto_documento=@auto_documento", xtabla, xp1)

        Dim xpro As New FichaProducto.Prd_Producto
        For Each xrow In xtabla.Rows
            'Dim xcompra_detalle As New FichaCompras.c_ComprasDetalle
            'xcompra_detalle.F_CargarCompraDetalle(xrow("x1"), xauto)

            'xpro.M_LimpiarRegistro()
            'xpro.F_BuscarProducto(xcompra_detalle.RegistroDato._AutoProducto)

            'Dim xregistro As New FichaCompras.c_TemporalCompra.AgregarRegistro
            'With xregistro
            '    ._Bono = xcompra_detalle.RegistroDato._Bono
            '    ._Cantidad = xcompra_detalle.RegistroDato._CantidadCompra
            '    ._CodigoPrdProveedor = xcompra_detalle.RegistroDato._CodigoProveedor
            '    ._CostoFinal = xcompra_detalle.RegistroDato._Costo
            '    ._CostoNeto = xcompra_detalle.RegistroDato._CostoBruto
            '    ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            '    ._FichaDeposito=
            '    ._FichaMedidaEmapque=
            '    ._FichaProducto = xcompra_detalle
            '    ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato







            '    ._AutoDeposito = xcompra_detalle.RegistroDato._AutoDeposito
            '    ._AutoMedida = xcompra_detalle.RegistroDato._AutoMedida
            '    ._AutoProducto = xcompra_detalle.RegistroDato._AutoProducto
            '    ._CantidadItems = xcompra_detalle.RegistroDato._CantidadCompra
            '    ._CodigoProducto = xcompra_detalle.RegistroDato._CodigoProducto
            '    ._ContenidoEmpaque = xcompra_detalle.RegistroDato._ContenidoEmpaque
            '    ._TasaDescuento_1 = xcompra_detalle.RegistroDato._Descuento1._Tasa
            '    ._TasaDescuento_2 = xcompra_detalle.RegistroDato._Descuento2._Tasa
            '    ._TasaDescuento_3 = xcompra_detalle.RegistroDato._Descuento3._Tasa
            '    ._TotalImporte = xcompra_detalle.RegistroDato._TotalNeto
            '    ._CostoFinal = xcompra_detalle.RegistroDato._Costo
            '    ._ForzarMedida = xcompra_detalle.RegistroDato._ForzarMedida
            '    ._NombreEmpaque = xcompra_detalle.RegistroDato._Empaque
            '    ._NombreProducto = xcompra_detalle.RegistroDato._NombreProducto
            '    ._EsPesado = xcompra_detalle.RegistroDato._PTO_EsPesado
            '    ._NumeroDecimalesMedida = xcompra_detalle.RegistroDato._CantidadDecimales
            '    ._CostoUnitario = xcompra_detalle.RegistroDato._CostoBruto
            '    ._TasaIva = xcompra_detalle.RegistroDato._TasaIva
            '    ._Bono = xcompra_detalle.RegistroDato._Bono
            '    ._CodigoProductoProveedor = xcompra_detalle.RegistroDato._CodigoProveedor
            '    ._AutoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario
            '    ._NombreEstacionEquipo = g_EquipoEstacion.p_EstacionNombre
            '    ._FechaProceso = g_MiData.p_FechaDelMotorBD
            '    ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
            '    ._PSugerido = xpro.RegistroDato._PrecioSugerido
            '    ._TipoDocumento = xtipo.ToString
            '    ._TipoTasa = xcompra_detalle.RegistroDato._TipoTasa
            '    ._NotasItem = xcompra_detalle.RegistroDato._NotasItem
            '    ._IdUnico = g_ConfiguracionSistema._Id_UnicoDelEquipo
            '    ._MontoImpuestoLicor = xcompra_detalle.RegistroDato.c_MontoImpuestoLicor.c_Valor
            'End With
            'g_MiData.f_FichaCompras.F_TemporalCompra.F_AgregarRegisto(xregistro)
        Next
    End Sub

    Sub CargarDataInicial()
        Dim xsentencia As String
        Dim xp1 As New SqlParameter("@top", _MaximoItemsMostrar)
        xsentencia = SELECT_COMPRAS & _
                    "where c.tipo in ('01','02','03','04') " & _
                    "order by c.fecha desc,c.tipo,c.auto desc"
        _SqlBusquedaActual = xsentencia
        g_MiData.F_GetData(xsentencia, f_data, xp1)
    End Sub

    Dim xform As System.Windows.Forms.Form
    WithEvents MG1 As MisGrid
    WithEvents MG2 As MisGrid
    WithEvents MCB_BUSCAR As MisComboBox
    WithEvents MCB_TIPO_DOC As MisComboBox
    WithEvents MCB_ESTATUS_DOC As MisComboBox
    Dim LB1 As Label
    Dim LB2 As Label
    WithEvents MF_INICIO As MisFechas
    WithEvents MF_HASTA As MisFechas
    WithEvents MT_BUSCAR As MisTextos
    WithEvents BT_TRASLADAR As Button

    Public Sub Inicializar(ByVal xobj As Object) Implements IAdministradorDocumentosCompras.Inicializar
        Try
            xform = xobj

            MG1 = xform.Controls.Find("MISGRID1", True)(0)
            MG2 = xform.Controls.Find("MISGRID2", True)(0)
            MCB_BUSCAR = xform.Controls.Find("MCB_BUSCAR", True)(0)
            MCB_TIPO_DOC = xform.Controls.Find("MCB_TIPO_DOC", True)(0)
            MCB_ESTATUS_DOC = xform.Controls.Find("MCB_ESTATUS_DOC", True)(0)
            LB1 = xform.Controls.Find("E_ITEMS_1", True)(0)
            LB2 = xform.Controls.Find("E_ITEMS_2", True)(0)
            MF_INICIO = xform.Controls.Find("MISFECHAS1", True)(0)
            MF_HASTA = xform.Controls.Find("MISFECHAS2", True)(0)
            MT_BUSCAR = xform.Controls.Find("MT_BUSCAR", True)(0)
            BT_TRASLADAR = xform.Controls.Find("BT_TRASLADAR", True)(0)

            CargarDataInicial()
            With MG1
                .Columns.Add("col0", "F/Emision")
                .Columns.Add("col1", "Tipo/Doc")
                .Columns.Add("col2", "Documento")
                .Columns.Add("col3", "F/Vencim")
                .Columns.Add("col4", "Días")
                .Columns.Add("col5", "Proveedor")
                .Columns.Add("col6", "CI/RIF")
                .Columns.Add("col7", "Importe")
                .Columns.Add("col8", "Estatus")

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "tipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "fecha_vencimiento"
                .Columns(4).DataPropertyName = "dias"
                .Columns(5).DataPropertyName = "nombre"
                .Columns(6).DataPropertyName = "ci_rif"
                .Columns(7).DataPropertyName = "total"
                .Columns(8).DataPropertyName = "estatus"

                .DataSource = f_binding

                .Columns(0).Width = 75
                .Columns(1).Width = 80
                .Columns(2).Width = 110
                .Columns(3).Width = 75
                .Columns(4).Width = 40
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(6).Width = 100
                .Columns(7).Width = 100
                .Columns(8).Width = 55

                .Ocultar(10)
                AddHandler .CellFormatting, AddressOf MiFormato

                .Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(2).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(3).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(4).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(5).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(6).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(7).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(8).SortMode = DataGridViewColumnSortMode.Automatic
            End With

            With MG2
                .Columns.Add("col0", "Fecha")
                .Columns.Add("col1", "Movimiento")
                .Columns.Add("col2", "Documento")
                .Columns.Add("col3", "Detalle")
                .Columns.Add("col4", "Importe")
                .Columns.Add("col5", "Estatus")

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "tipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "detalle"
                .Columns(4).DataPropertyName = "importe"
                .Columns(5).DataPropertyName = "estatus"

                .DataSource = f_datarelacionada

                .Columns(0).Width = 100
                .Columns(1).Width = 150
                .Columns(2).Width = 150
                .Columns(3).Width = 250
                .Columns(4).Width = 100
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .Ocultar(7)
                AddHandler .CellFormatting, AddressOf MiFormato2
            End With

            AddHandler f_binding.PositionChanged, AddressOf ActualizarDataRelacionada
            ActualizarData()

            With MCB_BUSCAR
                .DataSource = g_MiData.f_FichaProveedores.f_Proveedor.p_TipoBusqueda
                .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProveedor
            End With

            Dim xlista As New List(Of TiposDocumentos)
            xlista.Add(New TiposDocumentos With {._Nombre = "Todos", ._Codigo = "00"})
            xlista.Add(New TiposDocumentos With {._Nombre = "Compra Mercancia", ._Codigo = "01"})
            xlista.Add(New TiposDocumentos With {._Nombre = "Nota Débito", ._Codigo = "02"})
            xlista.Add(New TiposDocumentos With {._Nombre = "Nota Crédito", ._Codigo = "03"})
            xlista.Add(New TiposDocumentos With {._Nombre = "Orden Compra", ._Codigo = "04"})
            xlista.Add(New TiposDocumentos With {._Nombre = "Compra Gastos", ._Codigo = "05"})

            With MCB_TIPO_DOC
                .DataSource = xlista
                .DisplayMember = "_Nombre"
                .ValueMember = "_Codigo"
            End With

            MCB_ESTATUS_DOC.DataSource = xlista_estatus

            xform.Text = "Administrador De Documentos De Compras"
            xform.BackColor = Color.DarkGray

            Me.LB1.Text = f_binding.Count.ToString
            Me.LB2.Text = f_bindingrelacionada.Count.ToString

            If _TipoDocumento = TipoDocumentoCompra.Factura Then
                BT_TRASLADAR.Enabled = True
            Else
                BT_TRASLADAR.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 7 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If

        Dim xgrid As MisControles.Controles.MisGrid = CType(sender, MisGrid)
        If xgrid.Rows(e.RowIndex).Cells(8).Value.ToString.Trim.ToUpper = "ANULADO" Then
            xgrid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Sub MiFormato2(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 4 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Sub ActualizarDataRelacionada(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizarData()
    End Sub

    Sub ActualizarData()
        CargarDataRelacionada()
    End Sub

    Public Function CargarDataRelacionada() As Boolean
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xsentencia As String = ""
                Dim xparam1 As SqlParameter = Nothing
                Dim xparam2 As SqlParameter = Nothing
                Dim xparam3 As SqlParameter = Nothing
                Dim xparam4 As SqlParameter = Nothing

                xparam1 = New SqlParameter("@auto_documento", f_binding.Current("auto"))
                xparam2 = New SqlParameter("@aplica", f_binding.Current("documento"))
                xparam3 = New SqlParameter("@serie", f_binding.Current("n_serie"))
                xparam4 = New SqlParameter("@auto_entidad", f_binding.Current("auto_entidad"))

                g_MiData.F_GetData(SELECT_RELACION_COMPRAS, f_datarelacionada, xparam1, xparam2, xparam3, xparam4)
                Me.LB2.Text = f_bindingrelacionada.Count.ToString
                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            Me.f_datarelacionada.Rows.Clear()
        End If
    End Function

    Private Sub BT_TRASLADAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_TRASLADAR.Click
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xfichacompra As New FichaCompras
                Dim xauto As String = f_binding.Current("auto")
                xfichacompra.F_Compras.F_CargarCompra(xauto)

                If xfichacompra.F_Compras.RegistroDato._TipoDocumentoCompra = TipoDocumentoCompra.OrdenCompra Then
                    If MessageBox.Show("Trasladar Documento A Compra ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        RaiseEvent _OrdenTrasladar(xauto)
                        xform.Close()
                    End If
                Else
                    Throw New Exception("PROBLEMA AL SELECCIONAR TIPO DE DOCUMENTO")
                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub
End Class

Public Class AdmDoc_CostosCompras
    Implements IAdministradorDocumentosCompras

    Class TiposDocumentos
        Private xnombre As String
        Private xcodigo As String

        Property _Nombre() As String
            Get
                Return xnombre
            End Get
            Set(ByVal value As String)
                xnombre = value
            End Set
        End Property

        Property _Codigo() As String
            Get
                Return xcodigo
            End Get
            Set(ByVal value As String)
                xcodigo = value
            End Set
        End Property

        Sub New()
            Me._Codigo = ""
            Me._Nombre = ""
        End Sub
    End Class

#Region "FUNCIONES SELECT"
    Const SELECT_COMPRAS As String = "select top(@top) fecha, " & _
                                         "(case tipo when '01' then 'Compra' " & _
                                         "           when '02' then 'Nota Débito' " & _
                                         "           when '03' then 'Nota Crédito' " & _
                                         "           when '04' then 'Orden Compra' end) xtipo, " & _
                                         "documento, " & _
                                         "fecha_vencimiento, " & _
                                         "dias, " & _
                                         "nombre, " & _
                                         "ci_rif, " & _
                                         "total, " & _
                                         "'Activo' xestatus, " & _
                                         "auto, * " & _
                                     "from compras c "

    Const SELECT_RELACION_COMPRAS As String = "SELECT fecha" & _
                                                     ",'CtaPagar' tipo " & _
                                                     ",documento " & _
                                                     ",detalle " & _
                                                     ",importe " & _
                                                     ",(case estatus " & _
                                                        "when '1' then 'Anulado' " & _
                                                        "else case cancelado " & _
                                                            "when '0' then 'Pendiente' " & _
                                                            "when '1' then 'Cancelado' End " & _
                                                    "end) estatus " & _
                                             "FROM cxp " & _
                                             "WHERE auto_documento = @auto_documento and tipo_documento in ('FAC','NCF') " & _
                                             "UNION " & _
                                             "SELECT d.fecha fecha " & _
                                                     ",'Pago' tipo " & _
                                                     ",numero_recibo documento " & _
                                                     ",r.detalle detalle " & _
                                                     ",monto importe " & _
                                                     ",(case r.estatus " & _
                                                         "when '1' then 'Anulado' " & _
                                                         "else '' end) estatus " & _
                                             "FROM cxp_documentos d inner join cxp_recibos r on d.auto_cxp_recibo = r.auto inner join cxp c on d.auto_cxp = c.auto " & _
                                             "WHERE c.auto_documento = @auto_documento " & _
                                             "UNION " & _
                                             "SELECT fecha " & _
                                                  ",'Retención' tipo " & _
                                                  ",documento " & _
                                                  ",'' detalle " & _
                                                  ",retencion importe " & _
                                                  ", (case estatus " & _
                                                         "when '1' then 'Anulado' " & _
                                                         "else '' end) estatus  " & _
                                             "FROM retenciones_compras_detalle " & _
                                             "WHERE auto_documento = @auto_documento " & _
                                             "UNION " & _
                                             "SELECT fecha " & _
                                                     ",(case tipo " & _
                                                        "when '02' then 'Nota Débito' " & _
                                                        "when '03' then 'Nota Crédito' end) tipo" & _
                                                     ",documento " & _
                                                     ",nota detalle " & _
                                                     ",total " & _
                                                     ",(case estatus " & _
                                                         "when '1' then 'Anulado' " & _
                                                         "else '' end) estatus " & _
                                             "FROM compras " & _
                                             "WHERE aplica = @aplica and n_serieaplica=@serie and auto_entidad=@auto_entidad and tipo in ('02','03') "
#End Region

    Dim f_data As DataTable
    Dim f_binding As BindingSource
    Dim f_datarelacionada As DataTable
    Dim f_bindingrelacionada As BindingSource
    Dim f_filterdata As IAdministradorDocumentosCompras.C_FilterData

    Dim xtipodoc As TipoDocumentoCompra
    Dim x_maximo_items_mostrar As Integer
    Dim xsql_busqueda_actual As String

    Property _SqlBusquedaActual() As String
        Get
            Return xsql_busqueda_actual
        End Get
        Set(ByVal value As String)
            xsql_busqueda_actual = value
        End Set
    End Property

    Property _MaximoItemsMostrar() As Integer
        Get
            Return x_maximo_items_mostrar
        End Get
        Set(ByVal value As Integer)
            x_maximo_items_mostrar = value
        End Set
    End Property

    Property _TipoDocumento() As TipoDocumentoCompra
        Get
            Return xtipodoc
        End Get
        Set(ByVal value As TipoDocumentoCompra)
            xtipodoc = value
        End Set
    End Property

    Sub New(ByVal xtope As Integer)
        _MaximoItemsMostrar = xtope

        f_data = New DataTable
        f_binding = New BindingSource(f_data, "")
        f_datarelacionada = New DataTable
        f_bindingrelacionada = New BindingSource(f_datarelacionada, "")

        f_filterdata = New IAdministradorDocumentosCompras.C_FilterData

        _SqlBusquedaActual = ""
    End Sub

    Public Function _RevertirDocumento() As Boolean Implements IAdministradorDocumentosCompras._RevertirDocumento
    End Function

    Public Function _BuscarAhora() As Boolean Implements IAdministradorDocumentosCompras._BuscarAhora
        With f_filterdata
            If MF_INICIO.Checked Then
                ._DesdeFecha = MF_INICIO.Value
            End If
            If MF_HASTA.Checked Then
                ._HastaFecha = MF_HASTA.Value
            End If
            ._Texto = MT_BUSCAR.r_Valor
            ._TipoDocumento = MCB_TIPO_DOC.SelectedValue
            ._TipoFilter = MCB_BUSCAR.SelectedIndex
        End With

        Dim xsentencia As String = ""
        Dim xcondicion As String = ""
        Dim xtexto As String = f_filterdata._Texto

        If (f_filterdata._Texto <> "") Then
            If xtexto.Substring(0, 1) = "*" Then
                xtexto = xtexto.Substring(1)
            End If

            Select Case f_filterdata._Texto.Substring(0, 1)
                Case "*" : xcondicion += "and c." + f_filterdata._TipoFilter.ToString() + " like '%" + xtexto + "%' "
                Case Else : xcondicion += "and c." + f_filterdata._TipoFilter.ToString() + " like '" + xtexto + "%' "
            End Select
        End If

        xsentencia = SELECT_COMPRAS & "where c.tipo ='01' and c.estatus='0' and month(c.fecha_carga)=month(getdate()) and year(c.fecha_carga)=year(getdate()) " & _
                     xcondicion & "order by c.fecha desc,c.tipo,c.auto desc"

        Buscar(xsentencia)
        f_filterdata.Limpiar()
    End Function

    Public ReadOnly Property _AutoDocumento() As String Implements IAdministradorDocumentosCompras._AutoDocumento
        Get
            Return ""
        End Get
    End Property

    Public Function _BusquedaAvanzada() As Boolean Implements IAdministradorDocumentosCompras._BusquedaAvanzada
    End Function

    Public Function _ConsultarDocumento() As Boolean Implements IAdministradorDocumentosCompras._ConsultarDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row

                Dim xficha As New Compras_Detalle(xreg("auto"), True)
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Public Function _VisualizarDocumento() As Boolean Implements IAdministradorDocumentosCompras._VisualizarDocumento
        If f_binding.Current IsNot Nothing Then
            Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
            VisualizarDoc_Compras(xreg("auto").ToString.Trim)
        End If
    End Function

    Dim xform As System.Windows.Forms.Form
    WithEvents MG1 As MisGrid
    WithEvents MG2 As MisGrid
    WithEvents MCB_BUSCAR As MisComboBox
    WithEvents MCB_TIPO_DOC As MisComboBox
    WithEvents MCB_ESTATUS_DOC As MisComboBox
    Dim LB1 As Label
    Dim LB2 As Label
    WithEvents MF_INICIO As MisFechas
    WithEvents MF_HASTA As MisFechas
    WithEvents MT_BUSCAR As MisTextos
    WithEvents BT_AVANZADA As Button
    WithEvents BT_VISUALIZAR As Button

    Public Sub Inicializar(ByVal xobj As Object) Implements IAdministradorDocumentosCompras.Inicializar
        Try
            xform = xobj

            MG1 = xform.Controls.Find("MISGRID1", True)(0)
            MG2 = xform.Controls.Find("MISGRID2", True)(0)
            MCB_BUSCAR = xform.Controls.Find("MCB_BUSCAR", True)(0)
            MCB_TIPO_DOC = xform.Controls.Find("MCB_TIPO_DOC", True)(0)
            MCB_ESTATUS_DOC = xform.Controls.Find("MCB_ESTATUS_DOC", True)(0)
            LB1 = xform.Controls.Find("E_ITEMS_1", True)(0)
            LB2 = xform.Controls.Find("E_ITEMS_2", True)(0)
            MF_INICIO = xform.Controls.Find("MISFECHAS1", True)(0)
            MF_HASTA = xform.Controls.Find("MISFECHAS2", True)(0)
            MT_BUSCAR = xform.Controls.Find("MT_BUSCAR", True)(0)
            BT_AVANZADA = xform.Controls.Find("BT_AVANZADA", True)(0)
            BT_VISUALIZAR = xform.Controls.Find("BT_VISUALIZAR", True)(0)

            Me.MCB_TIPO_DOC.Enabled = False
            Me.MCB_ESTATUS_DOC.Enabled = False
            Me.MF_HASTA.Enabled = False
            Me.MF_INICIO.Enabled = False
            Me.BT_AVANZADA.Enabled = False
            Me.BT_VISUALIZAR.Enabled = True

            CargarDataInicial()
            With MG1
                .Columns.Add("col0", "F/Emision")
                .Columns.Add("col1", "Tipo/Doc")
                .Columns.Add("col2", "Documento")
                .Columns.Add("col3", "F/Vencim")
                .Columns.Add("col4", "Días")
                .Columns.Add("col5", "Proveedor")
                .Columns.Add("col6", "CI/RIF")
                .Columns.Add("col7", "Importe")
                .Columns.Add("col8", "Estatus")

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "xtipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "fecha_vencimiento"
                .Columns(4).DataPropertyName = "dias"
                .Columns(5).DataPropertyName = "nombre"
                .Columns(6).DataPropertyName = "ci_rif"
                .Columns(7).DataPropertyName = "total"
                .Columns(8).DataPropertyName = "xestatus"

                .DataSource = f_binding

                .Columns(0).Width = 90
                .Columns(1).Width = 90
                .Columns(2).Width = 110
                .Columns(3).Width = 90
                .Columns(4).Width = 40
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(6).Width = 100
                .Columns(7).Width = 80
                .Columns(8).Width = 60

                .Ocultar(10)
                AddHandler .CellFormatting, AddressOf MiFormato

                .Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(2).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(3).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(4).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(5).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(6).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(7).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(8).SortMode = DataGridViewColumnSortMode.Automatic
            End With

            With MG2
                .Columns.Add("col0", "Fecha")
                .Columns.Add("col1", "Movimiento")
                .Columns.Add("col2", "Documento")
                .Columns.Add("col3", "Detalle")
                .Columns.Add("col4", "Importe")
                .Columns.Add("col5", "Estatus")

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "tipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "detalle"
                .Columns(4).DataPropertyName = "importe"
                .Columns(5).DataPropertyName = "estatus"

                .DataSource = f_datarelacionada

                .Columns(0).Width = 100
                .Columns(1).Width = 150
                .Columns(2).Width = 150
                .Columns(3).Width = 250
                .Columns(4).Width = 100
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .Ocultar(7)
                AddHandler .CellFormatting, AddressOf MiFormato2
            End With

            AddHandler f_binding.PositionChanged, AddressOf ActualizarDataRelacionada
            ActualizarData()

            With MCB_BUSCAR
                .DataSource = g_MiData.f_FichaProveedores.f_Proveedor.p_TipoBusqueda
                .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProveedor
            End With

            Dim xlista As New List(Of TiposDocumentos)
            xlista.Add(New TiposDocumentos With {._Nombre = "Todos", ._Codigo = "00"})
            With MCB_TIPO_DOC
                .DataSource = xlista
                .DisplayMember = "_Nombre"
                .ValueMember = "_Codigo"
            End With

            xform.Text = "Administrador De Documentos De Compras"
            xform.BackColor = Color.DarkGray

            Me.LB1.Text = f_binding.Count.ToString
            Me.LB2.Text = f_bindingrelacionada.Count.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 7 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If

        Dim xgrid As MisControles.Controles.MisGrid = CType(sender, MisGrid)
        If xgrid.Rows(e.RowIndex).Cells(8).Value.ToString.Trim.ToUpper = "ANULADO" Then
            xgrid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Sub MiFormato2(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 4 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Sub CargarDataInicial()
        Dim xsentencia As String
        Dim xp1 As New SqlParameter("@top", _MaximoItemsMostrar)
        xsentencia = SELECT_COMPRAS & _
                    "where c.tipo ='01' and c.estatus='0' and month(fecha_carga)=month(getdate()) and year(fecha_carga)=year(getdate()) and (c.n_tipo_compra is NULL OR c.n_tipo_compra='1') " & _
                    "order by c.fecha desc,c.tipo,c.auto desc"

        _SqlBusquedaActual = xsentencia
        g_MiData.F_GetData(xsentencia, f_data, xp1)
    End Sub

    Sub ActualizarDataRelacionada(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizarData()
    End Sub

    Sub ActualizarData()
        CargarDataRelacionada()
    End Sub

    Public Function CargarDataRelacionada() As Boolean
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xsentencia As String = ""
                Dim xparam1 As SqlParameter = Nothing
                Dim xparam2 As SqlParameter = Nothing
                Dim xparam3 As SqlParameter = Nothing
                Dim xparam4 As SqlParameter = Nothing

                xparam1 = New SqlParameter("@auto_documento", f_binding.Current("auto"))
                xparam2 = New SqlParameter("@aplica", f_binding.Current("documento"))
                xparam3 = New SqlParameter("@serie", f_binding.Current("n_serie"))
                xparam4 = New SqlParameter("@auto_entidad", f_binding.Current("auto_entidad"))

                g_MiData.F_GetData(SELECT_RELACION_COMPRAS, f_datarelacionada, xparam1, xparam2, xparam3, xparam4)
                Me.LB2.Text = f_bindingrelacionada.Count.ToString
                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Else
            Me.f_datarelacionada.Rows.Clear()
        End If
    End Function

    Sub Buscar(ByVal xsql As String)
        _SqlBusquedaActual = xsql
        Dim xp1 As New SqlParameter("@top", _MaximoItemsMostrar)
        Try
            g_MiData.F_GetData(xsql, f_data, xp1)
            LB1.Text = f_binding.Count.ToString
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function _AnularDocumento(Optional ByVal revertir As Boolean = False) As Boolean Implements IAdministradorDocumentosCompras._AnularDocumento
    End Function
End Class