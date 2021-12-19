Imports System.Data.SqlClient
Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema

Public Class AdmControlCuentas
    Dim _Plantilla As IAdmControlCuentas

    Sub New(ByVal xplantilla As IAdmControlCuentas)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Sub Inicializar()
        _Plantilla.Inicializar(Me)
        IrAInicio()
    End Sub

    Private Sub AdmControlCuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            IrAInicio()
        End If
    End Sub

    Private Sub AdmControlCuentas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub AdmControlCuentas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializar()
        Catch ex As Exception
            Funciones.MensajeDeError("PROBLEMA AL CARGAR FORMULARIO:" + vbCrLf + ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub BT_BUSCARAHORA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCARAHORA.Click
        _Plantilla.F_BuscarAhora()
        IrAInicio()
    End Sub

    Private Sub BT_AVANZADA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_AVANZADA.Click
        _Plantilla.F_BusquedaAvanzada()
        IrAInicio()
    End Sub

    Sub IrAInicio()
        Me.MT_TEXTOBUSQUEDA.Text = ""
        Me.MT_TEXTOBUSQUEDA.Select()
        Me.MT_TEXTOBUSQUEDA.Focus()
    End Sub

    Private Sub BT_VISUALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_VISUALIZAR.Click
        _Plantilla.F_VisualizarDocumento()
        IrAInicio()
    End Sub

    Private Sub BT_ANULAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ANULAR.Click
        _Plantilla.F_AnularDocumento()
        IrAInicio()
    End Sub

    Private Sub AdmControlCuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IAdmControlCuentas
    Function F_BuscarAhora() As Boolean
    Function F_BusquedaAvanzada() As Boolean
    Function F_VisualizarDocumento() As Boolean
    Function F_AnularDocumento() As Boolean

    Sub Inicializar(ByVal xformulario As Object)
End Interface


''
'' CUENTAS POR COBRAR
''

Class c_AdmControlCxC
    Implements IAdmControlCuentas

#Region "FUNCIONES SELECT"
    Const SELECT_DOCUMENTOS_CXC As String = "SELECT TOP(@TOP) cxc.fecha_emision as fecha" & _
                                            "   ,(CASE cxc.tipo_documento WHEN 'FAC' THEN 'FACTURA' " & _
                                            "                         WHEN 'NDF' THEN 'NOTA DÉBITO' " & _
                                            "                         WHEN 'ND'  THEN 'NOTA DÉBITO' " & _
                                            "                         WHEN 'NCF' THEN 'NOTA CRÉDITO' " & _
                                            "                         WHEN 'NC'  THEN 'NOTA CRÉDITO' " & _
                                            "                         WHEN 'CHD' THEN 'CHEQUE DEVUELTO' " & _
                                            "                         WHEN 'PRE' THEN 'PRESTAMO' " & _
                                            "                         WHEN 'ANT' THEN 'ANTICIPO' " & _
                                            "                         WHEN 'PAG' THEN 'PAGO' END) tipo " & _
                                            "   ,cxc.documento " & _
                                            "   ,cxc.fecha_vencimiento " & _
                                            "   ,(CASE WHEN cxc.tipo_documento='PAG' THEN 0 WHEN (datediff(dd,fecha_vencimiento,getDate()))>0 THEN datediff(day,fecha_vencimiento,getDate()) ELSE 0 END) dias " & _
                                            "   ,cxc.cliente" & _
                                            "   ,cxc.ci_rif" & _
                                            "   ,cxc.importe importe" & _
                                            "   ,cxc.resta debe" & _
                                            "   ,cxc.acumulado haber" & _
                                            "   ,(CASE cxc.estatus WHEN '0' THEN '' ELSE 'ANULADO' END) estatus " & _
                                            "   ,cxc.auto, cxc.auto_documento " & _
                                            "FROM cxc INNER JOIN clientes ON cxc.auto_cliente=clientes.auto "
#End Region

    Class c_DatosFicha
        Private xtipobusqueda As String
        Private xtextobusqueda As String
        Private xfechadesde As Date
        Private xfechahasta As Date
        Private xtipodocumento As E_TipoDocumento

        Property _TipoBusqueda() As String
            Get
                Return xtipobusqueda
            End Get
            Set(ByVal value As String)
                xtipobusqueda = value
            End Set
        End Property

        Property _TextoABuscar() As String
            Get
                Return xtextobusqueda
            End Get
            Set(ByVal value As String)
                xtextobusqueda = value
            End Set
        End Property

        Property _FechaDesde() As Date
            Get
                Return xfechadesde
            End Get
            Set(ByVal value As Date)
                xfechadesde = value
            End Set
        End Property

        Property _TipoDocumento() As E_TipoDocumento
            Get
                Return xtipodocumento
            End Get
            Set(ByVal value As E_TipoDocumento)
                xtipodocumento = value
            End Set
        End Property

        Property _FechaHasta() As Date
            Get
                Return xfechahasta
            End Get
            Set(ByVal value As Date)
                xfechahasta = value
            End Set
        End Property

        Sub New()
            xtipobusqueda = "cliente"
            xtextobusqueda = ""
            xfechadesde = Date.MinValue
            xfechahasta = Date.MinValue
            xtipodocumento = E_TipoDocumento.Todos
        End Sub

    End Class

    Dim _DatosFicha As c_DatosFicha

    'ENUMERADOS
    Enum E_TipoBusqueda As Integer
        Nombre = 0
        CI_Rif = 1
        Codigo_Entidad = 2
    End Enum

    Enum E_TipoDocumento As Integer
        Todos = 0
        Factura = 1
        NotaDebito = 2
        NotaCredito = 3
        ChequeDevuelto = 4
        Prestamo = 5
        Pago = 6
        Anticipo = 7
    End Enum

    'BOTONES
    Dim BT_BUSCARAHORA As System.Windows.Forms.Button

    'LABELS
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_ITEMS_E As System.Windows.Forms.Label
    Dim LB_DEBE As System.Windows.Forms.Label
    Dim LB_HABER As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim LB_TITULOENTIDAD As System.Windows.Forms.Label
    Dim LB_NOMBREENTIDAD As System.Windows.Forms.Label

    'COMBOBOX
    Dim MCB_TIPOBUSQUEDA As MisComboBox
    Dim MCB_TIPODOCUMENTO As MisComboBox

    'DATETIMEPICKERS
    Dim MF_DESDE As MisFechas
    Dim MF_HASTA As MisFechas

    'DATAGRIDVIEW
    Dim MG_DOCUMENTOS As MisGrid

    'TEXTBOX
    Dim MT_TEXTOBUSQUEDA As MisTextos

    'DATATABLE
    Dim DTB_DOCUMENTOS As DataTable

    'BINDINGSOURCE
    Dim BS_DOCUMENTOS As BindingSource

    Dim xtipodocumentos As String() = {"Todos", "Factura", "Nota Débito", "Nota Crédito", "Cheque Devuelto", "Prestamo", "Pago", "Anticipos"}
    Dim _Top As Integer

    Sub New()
        _DatosFicha = New c_DatosFicha
        _Top = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCxCobrar._Limite_Renglones_AdmDocumentos
        DTB_DOCUMENTOS = New DataTable
        BS_DOCUMENTOS = New BindingSource(DTB_DOCUMENTOS, "")
    End Sub

    Sub ActualizarItemsEncontrados()
        Try
            Dim xdebe As Decimal = 0
            Dim xhaber As Decimal = 0

            LB_ITEMS_E.Text = DTB_DOCUMENTOS.Rows.Count.ToString()
            LB_DEBE.Text = String.Format("{0:#0.00}", xdebe)
            LB_HABER.Text = String.Format("{0:#0.00}", xhaber)

        Catch ex As Exception
            MessageBox.Show("ERROR AL ACTUALIZAR DATA:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarDocumentos()
        Try
            Dim xparam As New SqlParameter("@TOP", _Top)
            Dim xsentencia As String = SELECT_DOCUMENTOS_CXC
            Dim xcondicion As String = "WHERE cxc.auto<>'' "
            Dim xtexto As String = _DatosFicha._TextoABuscar

            If _DatosFicha._TextoABuscar <> "" Then
                If xtexto.Substring(0, 1) = "*" Then
                    xtexto = xtexto.Substring(1)
                End If

                Select Case _DatosFicha._TextoABuscar.Substring(0, 1)
                    Case "*" : xcondicion += "and cxc." + _DatosFicha._TipoBusqueda + " like '%" + xtexto + "%' "
                    Case Else : xcondicion += "and cxc." + _DatosFicha._TipoBusqueda + " like '" + xtexto + "%' "
                End Select
            End If

            If _DatosFicha._FechaDesde <> Date.MinValue Then
                xcondicion += "and cxc.fecha >= '" + _DatosFicha._FechaDesde + "' "
            End If

            If _DatosFicha._FechaHasta <> Date.MinValue Then
                xcondicion += "and cxc.fecha <= '" + _DatosFicha._FechaHasta + "' "
            End If

            If _DatosFicha._TipoDocumento <> E_TipoDocumento.Todos Then
                Select Case _DatosFicha._TipoDocumento
                    Case E_TipoDocumento.Factura
                        xcondicion += "and cxc.tipo_documento='FAC' "
                    Case E_TipoDocumento.NotaDebito
                        xcondicion += "and (cxc.tipo_documento='NDF' OR cxc.tipo_documento='ND') "
                    Case E_TipoDocumento.NotaCredito
                        xcondicion += "and (cxc.tipo_documento='NCF' OR cxc.tipo_documento='NC') "
                    Case E_TipoDocumento.ChequeDevuelto
                        xcondicion += "and cxc.tipo_documento='CHD' "
                    Case E_TipoDocumento.Prestamo
                        xcondicion += "and cxc.tipo_documento='PRE' "
                    Case E_TipoDocumento.Pago
                        xcondicion += "and cxc.tipo_documento='PAG' "
                    Case E_TipoDocumento.Anticipo
                        xcondicion += "and cxc.tipo_documento='ANT' "
                End Select
            End If

            xsentencia += xcondicion + "ORDER BY cxc.fecha desc, cxc.auto desc"
            g_MiData.F_GetData(xsentencia, DTB_DOCUMENTOS, xparam)
            ActualizarItemsEncontrados()
        Catch ex As Exception
            Funciones.MensajeDeError("PROBLEMA AL CARGAR DATA:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub CargarDocumentos(ByVal xcondicion As String)
        Try
            Dim xparam As New SqlParameter("@TOP", _Top)
            Dim xsentencia As String = SELECT_DOCUMENTOS_CXC
            xsentencia += xcondicion + "ORDER BY cxc.fecha desc, cxc.auto desc"
            g_MiData.F_GetData(xsentencia, DTB_DOCUMENTOS, xparam)
            ActualizarItemsEncontrados()
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR DATA:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IAdmControlCuentas.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
        LB_ITEMS_E = _MiFormulario.Controls.Find("LB_ITEMS_E", True)(0)
        LB_DEBE = _MiFormulario.Controls.Find("LB_DEBE", True)(0)
        LB_HABER = _MiFormulario.Controls.Find("LB_HABER", True)(0)
        LB_TITULOENTIDAD = _MiFormulario.Controls.Find("LB_TITULOENTIDAD", True)(0)
        LB_NOMBREENTIDAD = _MiFormulario.Controls.Find("LB_NOMBREENTIDAD", True)(0)

        MCB_TIPOBUSQUEDA = _MiFormulario.Controls.Find("MCB_TIPOBUSQUEDA", True)(0)
        MCB_TIPODOCUMENTO = _MiFormulario.Controls.Find("MCB_TIPODOCUMENTO", True)(0)

        MF_DESDE = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        With MF_DESDE
            .Value = g_MiData.p_FechaDelMotorBD
            .Checked = False
            AddHandler .ValueChanged, AddressOf GetFechaDesde
        End With
        MF_HASTA = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        With MF_HASTA
            .Value = g_MiData.p_FechaDelMotorBD
            .Checked = False
            AddHandler .ValueChanged, AddressOf GetFechaHasta
        End With
        MG_DOCUMENTOS = _MiFormulario.Controls.Find("MG_DOCUMENTOS", True)(0)

        MT_TEXTOBUSQUEDA = _MiFormulario.Controls.Find("MT_TEXTOBUSQUEDA", True)(0)
        AddHandler MT_TEXTOBUSQUEDA.LostFocus, AddressOf GetTextoBusqueda

        BT_BUSCARAHORA = _MiFormulario.Controls.Find("BT_BUSCARAHORA", True)(0)

        _MiFormulario.Text = "Documentos De Cuentas Por Cobrar"
        LB_TITULO.Text = "Administrador De Documentos De Cuentas Por Cobrar"
        LB_TITULOENTIDAD.Text = "Cliente:"

        'CARGAR SELECT DE BUSQUEDA DE DOCUMENTOS A MOSTRAR
        CargarDocumentos()

        'CARGAR COMBOS DE BUSQUEDA
        With MCB_TIPOBUSQUEDA
            .DataSource = g_MiData.f_FichaClientes.f_Clientes.p_TipoBusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarCliente
            AddHandler .SelectedIndexChanged, AddressOf GetTipoBusqueda
        End With

        With MCB_TIPODOCUMENTO
            .DataSource = xtipodocumentos
            .SelectedIndex = E_TipoDocumento.Todos
            AddHandler .SelectedIndexChanged, AddressOf GetTipoDocumento
        End With

        'INICIALIZAR GRID PRINCIPAL
        With MG_DOCUMENTOS
            .Columns.Add("col0", "F/Emisión")
            .Columns.Add("col1", "T/Documento")
            .Columns.Add("col2", "N/Documento")
            .Columns.Add("col3", "F/Venc.")
            .Columns.Add("col4", "Dias")
            .Columns.Add("col5", "Cliente")
            .Columns.Add("col6", "Ci/Rif")
            .Columns.Add("col7", "Importe")
            .Columns.Add("col8", "Debe")
            .Columns.Add("col9", "Haber")
            .Columns.Add("col10", "Est")


            .Columns(0).DataPropertyName = "fecha"
            .Columns(1).DataPropertyName = "tipo"
            .Columns(2).DataPropertyName = "documento"
            .Columns(3).DataPropertyName = "fecha_vencimiento"
            .Columns(4).DataPropertyName = "dias"
            .Columns(5).DataPropertyName = "cliente"
            .Columns(6).DataPropertyName = "ci_rif"
            .Columns(7).DataPropertyName = "importe"
            .Columns(8).DataPropertyName = "debe"
            .Columns(9).DataPropertyName = "haber"
            .Columns(10).DataPropertyName = "estatus"

            .DataSource = BS_DOCUMENTOS

            .Columns(0).Width = 70
            .Columns(1).Width = 90
            .Columns(2).Width = 90
            .Columns(3).Width = 70
            .Columns(4).Width = 40
            .Columns(6).Width = 80
            .Columns(7).Width = 90
            .Columns(8).Width = 90
            .Columns(9).Width = 90
            .Columns(10).Width = 30
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Ocultar(12)
            AddHandler .CellFormatting, AddressOf MiFormato
            AddHandler BS_DOCUMENTOS.CurrentChanged, AddressOf GetCliente
            AddHandler .Accion, AddressOf VerDetalle
        End With
        GetCliente()
    End Sub

    Sub GetFechaDesde()
        If (MF_DESDE.Checked) Then
            If (MF_DESDE.Value.Date > MF_HASTA.Value.Date) Then
                MessageBox.Show("Fecha Incorrecta Verifique Por Favor...", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MF_DESDE.Value = MF_HASTA.Value
            End If
            _DatosFicha._FechaDesde = MF_DESDE.Value.Date
        Else
            _DatosFicha._FechaDesde = Date.MinValue
        End If
    End Sub

    Sub GetFechaHasta()
        If (MF_HASTA.Checked) Then
            If (MF_HASTA.Value.Date < MF_DESDE.Value.Date) Then
                MessageBox.Show("Fecha Incorrecta Verifique Por Favor...", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MF_HASTA.Value = MF_DESDE.Value
            End If
            _DatosFicha._FechaHasta = MF_HASTA.Value.Date
        Else
            _DatosFicha._FechaHasta = Date.MinValue
        End If
    End Sub

    Sub GetTextoBusqueda()
        _DatosFicha._TextoABuscar = MT_TEXTOBUSQUEDA.r_Valor
    End Sub

    Sub GetTipoDocumento()
        _DatosFicha._TipoDocumento = MCB_TIPODOCUMENTO.SelectedIndex
    End Sub

    Sub GetTipoBusqueda()
        Select Case MCB_TIPOBUSQUEDA.SelectedIndex
            Case E_TipoBusqueda.Nombre
                _DatosFicha._TipoBusqueda = "cliente"
            Case E_TipoBusqueda.CI_Rif
                _DatosFicha._TipoBusqueda = "ci_rif"
            Case E_TipoBusqueda.Codigo_Entidad
                _DatosFicha._TipoBusqueda = "codigo_cliente"
        End Select
        MT_TEXTOBUSQUEDA.Text = ""
        MT_TEXTOBUSQUEDA.Select()
        MT_TEXTOBUSQUEDA.Focus()
    End Sub

    Sub VerDetalle()
        If BS_DOCUMENTOS.Current("estatus") = "ANULADO" Then
            VerDetalleAnulacion()
        Else
            If BS_DOCUMENTOS.Current("tipo") = "PAGO" Then
                ImprimirReciboPagoCxC(BS_DOCUMENTOS.Current("documento"))
            Else
                VerDetalleDocumento()
            End If
        End If
    End Sub

    Sub VerDetalleAnulacion()
        Dim xficha As New DetalleDocumentosAnulados(New c_DetalleDocumentosAnuladosCxC(CType(BS_DOCUMENTOS.Current, DataRowView).Row))
        xficha.ShowDialog()
    End Sub

    Sub VerDetalleDocumento()
        Dim xclass As New FichaCtasCobrar
        xclass.f_CxC.F_CargarRegistro(BS_DOCUMENTOS.Current("auto"))

        If xclass.f_CxC.RegistroDato._AutoMovimientoEntrada = "" Then
            VisualizarDoc_Ventas(xclass.f_CxC.RegistroDato._AutoDocumento)
        Else
            Dim xficha As New DetalleDocumentosCxC(New c_DetalleDocumentosCxC(xclass.f_CxC.RegistroDato))
            xficha.ShowDialog()
        End If
    End Sub

    Sub GetCliente()
        If BS_DOCUMENTOS.Current IsNot Nothing Then
            LB_NOMBREENTIDAD.Text = BS_DOCUMENTOS.Current("cliente").ToString.Trim
        Else
            LB_NOMBREENTIDAD.Text = ""
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 4 Or e.ColumnIndex = 9 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        If MG_DOCUMENTOS.Rows(e.RowIndex).Cells(10).Value = "ANULADO" Then
            MG_DOCUMENTOS.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkRed
            MG_DOCUMENTOS.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(MG_DOCUMENTOS.DefaultCellStyle.Font, FontStyle.Bold)
        End If
    End Sub

    Public Function F_BuscarAhora() As Boolean Implements IAdmControlCuentas.F_BuscarAhora
        Try
            CargarDocumentos()
        Catch ex As Exception
            MessageBox.Show("ERROR AL BUSCAR DOCUMENTOS:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function F_BusquedaAvanzada() As Boolean Implements IAdmControlCuentas.F_BusquedaAvanzada
        Try
            Dim xclase As New c_BusquedaAvanzada_AdmCxC
            AddHandler xclase.RetornarCondicionBusqueda, AddressOf CargarDocumentos
            Dim xficha As New BusquedaAvanzada_AdmCC(xclase)
            xficha.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("ERROR AL BUSCAR DOCUMENTOS:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function F_AnularDocumento() As Boolean Implements IAdmControlCuentas.F_AnularDocumento
        Try
            If BS_DOCUMENTOS.Current IsNot Nothing Then
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxCobrar_AnularDocumento.F_Permitir()

                If BS_DOCUMENTOS.Current("estatus") = "" Then
                    If BS_DOCUMENTOS.Current("auto_documento").ToString.Trim = "" Or BS_DOCUMENTOS.Current("tipo") = "PAGO" Then
                        Dim xsalida As Boolean = False
                        Dim xdetalle As String = ""
                        Dim xficha As New AnularDocumento(New AnularDocumento_CuentaPorCobrar("Documento Cuentas por Cobrar"))
                        With xficha
                            .ShowDialog()
                            xdetalle = ._DetalleNotas
                            xsalida = ._EstatusSalida
                        End With

                        If xsalida Then
                            AnularDocumento(xdetalle)
                        End If
                    Else
                        MessageBox.Show("EL DOCUMENTO NO PUEDE SER ANULADO. DEBE ANULARLO POR VENTA", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("EL DOCUMENTO YA ESTA ANULADO. NO PUEDE VOLVER A ANULARLO", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Sub AnularDocumento(ByVal xdetalle As String)
        Dim _FichaCxC As New FichaCtasCobrar
        Dim _CxC As New FichaCtasCobrar.c_CxC
        Dim _CxC_Recibos As New FichaCtasCobrar.c_Recibos
        Dim _CxC_Documentos As New List(Of FichaCtasCobrar.c_Documentos.c_Registro)
        Dim _Doc_Anulados As New FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro

        Dim xauto_recibo As String = ""
        Dim dtb_documentos As New DataTable
        Dim xnumero As String = BS_DOCUMENTOS.Current("documento")

        Dim xrow As DataRow = CType(BS_DOCUMENTOS.Current, DataRowView).Row
        _CxC.F_CargarRegistro(xrow("auto").ToString)

        If _CxC.RegistroDato._TipoDocumentoRegistradoCxC = TipoDocumentoRegistradoCxC.Pago Or _
           _CxC.RegistroDato._TipoDocumentoRegistradoCxC = TipoDocumentoRegistradoCxC.Anticipo Then

            Dim xp1 As New SqlParameter("@numero", xnumero)
            xauto_recibo = F_GetString("select auto from cxc_recibos where numero=@numero", xp1)

            Dim xparam As New SqlParameter("@auto_cxc_recibo", xauto_recibo)
            g_MiData.F_GetData("select * from cxc_documentos where auto_cxc_recibo=@auto_cxc_recibo", dtb_documentos, xparam)

            For Each xrow In dtb_documentos.Rows
                Dim xcxc_doc As New FichaCtasCobrar.c_Documentos
                xcxc_doc.M_CargarRegistro(xrow)
                _CxC_Documentos.Add(xcxc_doc.RegistroDato)
            Next
        End If

        With _Doc_Anulados
            ._CodigoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._CodigoUsuario
            ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
            ._FechaEmision = g_MiData.p_FechaDelMotorBD
            ._Hora = g_MiData.p_HoraDelMotorBD.ToString
            ._NotasDetalle = xdetalle
            ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
        End With

        Dim xanulardoc As New FichaCtasCobrar.c_CxC.c_AnularDocumentoCxC
        With xanulardoc
            ._AutoReciboCxc = xauto_recibo
            ._DocumentoAnular = _Doc_Anulados
            ._FichaRegistroCxc = _CxC.RegistroDato
            ._ListaDocumentos = _CxC_Documentos
        End With
        AddHandler _FichaCxC.DocumentoProcesado, AddressOf AvisoDocumentoProcesado
        _FichaCxC.F_AnularDocumento(xanulardoc)
    End Sub

    Sub AvisoDocumentoProcesado()
        MessageBox.Show("DOCUMENTO ANULADO EXITOSAMENTE... OK", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
        _DatosFicha._TipoBusqueda = "cliente"
        _DatosFicha._TextoABuscar = ""
        _DatosFicha._FechaDesde = Date.MinValue
        _DatosFicha._FechaHasta = Date.MinValue
        _DatosFicha._TipoDocumento = E_TipoDocumento.Todos
        CargarDocumentos()
    End Sub

    Public Function F_VisualizarDocumento() As Boolean Implements IAdmControlCuentas.F_VisualizarDocumento
        Try
            If BS_DOCUMENTOS.Current IsNot Nothing Then
                If BS_DOCUMENTOS.Current("tipo") = "PAGO" Then
                    ImprimirReciboPagoCxC(BS_DOCUMENTOS.Current("documento"))
                ElseIf BS_DOCUMENTOS.Current("tipo") = "ANTICIPO" Then
                    ImprimirReciboAnticipo(BS_DOCUMENTOS.Current("documento"))
                Else
                    VerDetalleDocumento()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR AL VISUALIZAR DOCUMENTO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class


''
'' CUENTAS POR PAGAR
''

Class c_AdmControlCxP
    Implements IAdmControlCuentas

#Region "FUNCIONES SELECT"
    Const SELECT_DOCUMENTOS_CXP As String = "SELECT TOP(@TOP) cxp.fecha" & _
                                            "   ,(CASE cxp.tipo_documento WHEN 'FAC' THEN 'FACTURA' " & _
                                            "                         WHEN 'NDF' THEN 'NOTA DÉBITO' " & _
                                            "                         WHEN 'ND'  THEN 'NOTA DÉBITO' " & _
                                            "                         WHEN 'NCF' THEN 'NOTA CRÉDITO' " & _
                                            "                         WHEN 'NC'  THEN 'NOTA CRÉDITO' " & _
                                            "                         WHEN 'CHD' THEN 'CHEQUE DEVUELTO' " & _
                                            "                         WHEN 'PAG' THEN 'PAGO' END) tipo " & _
                                            "   ,cxp.documento " & _
                                            "   ,cxp.fecha_vencimiento " & _
                                            "   ,(CASE WHEN cxp.tipo_documento='PAG' THEN 0 WHEN (datediff(dd,fecha_vencimiento,getDate()))>0 THEN datediff(day,fecha_vencimiento,getDate()) ELSE 0 END) dias " & _
                                            "   ,cxp.proveedor" & _
                                            "   ,cxp.ci_rif" & _
                                            "   ,cxp.importe importe" & _
                                            "   ,cxp.resta debe" & _
                                            "   ,cxp.acumulado haber" & _
                                            "   ,(CASE cxp.estatus WHEN '0' THEN '' ELSE 'ANULADO' END) estatus " & _
                                            "   ,cxp.auto " & _
                                            "   ,cxp.* " & _
                                            "FROM cxp INNER JOIN proveedores ON cxp.auto_proveedor=proveedores.auto "
#End Region

    Class c_DatosFicha
        Private xtipobusqueda As String
        Private xtextobusqueda As String
        Private xfechadesde As Date
        Private xfechahasta As Date
        Private xtipodocumento As E_TipoDocumento

        Property _TipoBusqueda() As String
            Get
                Return xtipobusqueda
            End Get
            Set(ByVal value As String)
                xtipobusqueda = value
            End Set
        End Property

        Property _TextoABuscar() As String
            Get
                Return xtextobusqueda
            End Get
            Set(ByVal value As String)
                xtextobusqueda = value
            End Set
        End Property

        Property _FechaDesde() As Date
            Get
                Return xfechadesde
            End Get
            Set(ByVal value As Date)
                xfechadesde = value
            End Set
        End Property

        Property _TipoDocumento() As E_TipoDocumento
            Get
                Return xtipodocumento
            End Get
            Set(ByVal value As E_TipoDocumento)
                xtipodocumento = value
            End Set
        End Property

        Property _FechaHasta() As Date
            Get
                Return xfechahasta
            End Get
            Set(ByVal value As Date)
                xfechahasta = value
            End Set
        End Property

        Sub New()
            xtipobusqueda = "proveedor"
            xtextobusqueda = ""
            xfechadesde = Date.MinValue
            xfechahasta = Date.MinValue
            xtipodocumento = E_TipoDocumento.Todos
        End Sub
    End Class

    'ENUMERADOS
    Enum E_TipoBusqueda As Integer
        Nombre = 0
        CI_Rif = 1
        Codigo_Entidad = 2
    End Enum

    Enum E_TipoDocumento As Integer
        Todos = 0
        Factura = 1
        NotaDebito = 2
        NotaCredito = 3
        ChequeDevuelto = 4
        Pago = 5
    End Enum

    ' CONTROLES
    Dim BT_BUSCARAHORA As System.Windows.Forms.Button
    Dim LB_TITULO As System.Windows.Forms.Label
    Dim LB_ITEMS_E As System.Windows.Forms.Label
    Dim LB_DEBE As System.Windows.Forms.Label
    Dim LB_HABER As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim LB_TITULOENTIDAD As System.Windows.Forms.Label
    Dim LB_NOMBREENTIDAD As System.Windows.Forms.Label
    Dim MCB_TIPOBUSQUEDA As MisComboBox
    Dim MCB_TIPODOCUMENTO As MisComboBox
    Dim MF_DESDE As MisFechas
    Dim MF_HASTA As MisFechas
    Dim MG_DOCUMENTOS As MisGrid
    Dim MT_TEXTOBUSQUEDA As MisTextos

    Dim DTB_DOCUMENTOS As DataTable
    Dim BS_DOCUMENTOS As BindingSource

    Dim _Top As Integer
    Dim _DatosFicha As c_DatosFicha
    Dim xtipodocumentos As String() = {"Todos", "Factura", "Nota Débito", "Nota Crédito", "Cheque Devuelto", "Pago"}

    Sub New()
        _DatosFicha = New c_DatosFicha
        _Top = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCxPagar._Limite_Renglones_AdmDocumentos
        DTB_DOCUMENTOS = New DataTable
        BS_DOCUMENTOS = New BindingSource(DTB_DOCUMENTOS, "")
    End Sub

    Sub ActualizarItemsEncontrados()
        Try
            Dim xdebe As Decimal = 0
            Dim xhaber As Decimal = 0

            For Each xrow In DTB_DOCUMENTOS.Rows
                If xrow("ESTATUS").ToString.Trim.ToUpper <> "ANULADO" Then
                    xdebe += xrow("debe")
                    xhaber += xrow("haber")
                End If
            Next

            LB_ITEMS_E.Text = DTB_DOCUMENTOS.Rows.Count.ToString()
            LB_DEBE.Text = String.Format("{0:#0.00}", xdebe)
            LB_HABER.Text = String.Format("{0:#0.00}", xhaber)

        Catch ex As Exception
            MessageBox.Show("ERROR AL ACTUALIZAR DATA:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarDocumentos()
        Try
            Dim xparam As New SqlParameter("@TOP", _Top)
            Dim xsentencia As String = SELECT_DOCUMENTOS_CXP
            Dim xcondicion As String = "WHERE cxp.auto<>'' "
            Dim xtexto As String = _DatosFicha._TextoABuscar

            If _DatosFicha._TextoABuscar <> "" Then
                If xtexto.Substring(0, 1) = "*" Then
                    xtexto = xtexto.Substring(1)
                End If

                Select Case _DatosFicha._TextoABuscar.Substring(0, 1)
                    Case "*" : xcondicion += "and cxp." + _DatosFicha._TipoBusqueda + " like '%" + xtexto + "%' "
                    Case Else : xcondicion += "and cxp." + _DatosFicha._TipoBusqueda + " like '" + xtexto + "%' "
                End Select
            End If

            If _DatosFicha._FechaDesde <> Date.MinValue Then
                xcondicion += "and cxp.fecha >= '" + _DatosFicha._FechaDesde + "' "
            End If

            If _DatosFicha._FechaHasta <> Date.MinValue Then
                xcondicion += "and cxp.fecha <= '" + _DatosFicha._FechaHasta + "' "
            End If

            If _DatosFicha._TipoDocumento <> E_TipoDocumento.Todos Then
                Select Case _DatosFicha._TipoDocumento
                    Case E_TipoDocumento.Factura
                        xcondicion += "and cxp.tipo_documento='FAC' "
                    Case E_TipoDocumento.NotaDebito
                        xcondicion += "and (cxp.tipo_documento='NDF' OR cxp.tipo_documento='ND') "
                    Case E_TipoDocumento.NotaCredito
                        xcondicion += "and (cxp.tipo_documento='NCF' OR cxp.tipo_documento='NC') "
                    Case E_TipoDocumento.ChequeDevuelto
                        xcondicion += "and cxp.tipo_documento='CHD' "
                    Case E_TipoDocumento.Pago
                        xcondicion += "and cxp.tipo_documento='PAG' "
                End Select
            End If

            xsentencia += xcondicion + "ORDER BY cxp.fecha desc, cxp.auto desc"
            g_MiData.F_GetData(xsentencia, DTB_DOCUMENTOS, xparam)
            ActualizarItemsEncontrados()
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR DATA:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarDocumentos(ByVal xcondicion As String)
        Try
            Dim xparam As New SqlParameter("@TOP", _Top)
            Dim xsentencia As String = SELECT_DOCUMENTOS_CXP
            xsentencia += xcondicion + "ORDER BY cxp.fecha desc, cxp.auto desc"
            g_MiData.F_GetData(xsentencia, DTB_DOCUMENTOS, xparam)
            ActualizarItemsEncontrados()
        Catch ex As Exception
            MessageBox.Show("ERROR AL CARGAR DATA:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IAdmControlCuentas.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_TITULO = _MiFormulario.Controls.Find("LB_TITULO", True)(0)
        LB_ITEMS_E = _MiFormulario.Controls.Find("LB_ITEMS_E", True)(0)
        LB_DEBE = _MiFormulario.Controls.Find("LB_DEBE", True)(0)
        LB_HABER = _MiFormulario.Controls.Find("LB_HABER", True)(0)
        LB_TITULOENTIDAD = _MiFormulario.Controls.Find("LB_TITULOENTIDAD", True)(0)
        LB_NOMBREENTIDAD = _MiFormulario.Controls.Find("LB_NOMBREENTIDAD", True)(0)
        MCB_TIPOBUSQUEDA = _MiFormulario.Controls.Find("MCB_TIPOBUSQUEDA", True)(0)
        MCB_TIPODOCUMENTO = _MiFormulario.Controls.Find("MCB_TIPODOCUMENTO", True)(0)
        MF_DESDE = _MiFormulario.Controls.Find("MF_DESDE", True)(0)
        MF_HASTA = _MiFormulario.Controls.Find("MF_HASTA", True)(0)
        MG_DOCUMENTOS = _MiFormulario.Controls.Find("MG_DOCUMENTOS", True)(0)
        MT_TEXTOBUSQUEDA = _MiFormulario.Controls.Find("MT_TEXTOBUSQUEDA", True)(0)
        BT_BUSCARAHORA = _MiFormulario.Controls.Find("BT_BUSCARAHORA", True)(0)

        With MF_DESDE
            .Value = g_MiData.p_FechaDelMotorBD
            .Checked = False
            AddHandler .ValueChanged, AddressOf GetFechaDesde
        End With

        With MF_HASTA
            .Value = g_MiData.p_FechaDelMotorBD
            .Checked = False
            AddHandler .ValueChanged, AddressOf GetFechaHasta
        End With

        AddHandler MT_TEXTOBUSQUEDA.LostFocus, AddressOf GetTextoBusqueda

        _MiFormulario.Text = "Documentos De Cuentas Por Pagar"
        LB_TITULO.Text = "Administrador De Documentos De Cuentas Por Pagar"
        LB_TITULOENTIDAD.Text = "Proveedor:"
        LB_NOMBREENTIDAD.Location = New Point(100, 3)

        'CARGAR SELECT DE BUSQUEDA DE DOCUMENTOS A MOSTRAR
        CargarDocumentos()

        'CARGAR COMBOS DE BUSQUEDA
        With MCB_TIPOBUSQUEDA
            .DataSource = g_MiData.f_FichaProveedores.f_Proveedor.p_TipoBusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProveedor
            AddHandler .SelectedIndexChanged, AddressOf GetTipoBusqueda
        End With

        With MCB_TIPODOCUMENTO
            .DataSource = xtipodocumentos
            .SelectedIndex = E_TipoDocumento.Todos
            AddHandler .SelectedIndexChanged, AddressOf GetTipoDocumento
        End With

        'INICIALIZAR GRID PRINCIPAL
        With MG_DOCUMENTOS
            .Columns.Add("col0", "F/Emisión")
            .Columns.Add("col1", "T/Documento")
            .Columns.Add("col2", "N/Documento")
            .Columns.Add("col3", "F/Venc.")
            .Columns.Add("col4", "Dias")
            .Columns.Add("col5", "Proveedor")
            .Columns.Add("col6", "Ci/Rif")
            .Columns.Add("col7", "Importe")
            .Columns.Add("col8", "Debe")
            .Columns.Add("col9", "Haber")
            .Columns.Add("col10", "Est")

            .Columns(0).DataPropertyName = "fecha"
            .Columns(1).DataPropertyName = "tipo"
            .Columns(2).DataPropertyName = "documento"
            .Columns(3).DataPropertyName = "fecha_vencimiento"
            .Columns(4).DataPropertyName = "dias"
            .Columns(5).DataPropertyName = "proveedor"
            .Columns(6).DataPropertyName = "ci_rif"
            .Columns(7).DataPropertyName = "importe"
            .Columns(8).DataPropertyName = "debe"
            .Columns(9).DataPropertyName = "haber"
            .Columns(10).DataPropertyName = "estatus"

            .DataSource = BS_DOCUMENTOS

            .Columns(0).Width = 80
            .Columns(1).Width = 110
            .Columns(2).Width = 95
            .Columns(3).Width = 80
            .Columns(4).Width = 40
            .Columns(6).Width = 90
            .Columns(7).Width = 70
            .Columns(8).Width = 70
            .Columns(9).Width = 70
            .Columns(10).Width = 30
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Ocultar(12)
            AddHandler .CellFormatting, AddressOf MiFormato
            AddHandler BS_DOCUMENTOS.CurrentChanged, AddressOf GetProveedor
            AddHandler .Accion, AddressOf VerDetalle
        End With
        GetProveedor()
    End Sub

    Sub GetFechaDesde()
        If (MF_DESDE.Checked) Then
            If (MF_DESDE.Value.Date > MF_HASTA.Value.Date) Then
                MessageBox.Show("Fecha Incorrecta Verifique Por Favor...", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MF_DESDE.Value = MF_HASTA.Value
            End If
            _DatosFicha._FechaDesde = MF_DESDE.Value.Date
        Else
            _DatosFicha._FechaDesde = Date.MinValue
        End If
    End Sub

    Sub GetFechaHasta()
        If (MF_HASTA.Checked) Then
            If (MF_HASTA.Value.Date < MF_DESDE.Value.Date) Then
                MessageBox.Show("Fecha Incorrecta Verifique Por Favor...", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MF_HASTA.Value = MF_DESDE.Value
            End If
            _DatosFicha._FechaHasta = MF_HASTA.Value.Date
        Else
            _DatosFicha._FechaHasta = Date.MinValue
        End If
    End Sub

    Sub GetTextoBusqueda()
        _DatosFicha._TextoABuscar = MT_TEXTOBUSQUEDA.r_Valor
    End Sub

    Sub GetTipoDocumento()
        _DatosFicha._TipoDocumento = MCB_TIPODOCUMENTO.SelectedIndex
    End Sub

    Sub GetTipoBusqueda()
        Select Case MCB_TIPOBUSQUEDA.SelectedIndex
            Case E_TipoBusqueda.Nombre
                _DatosFicha._TipoBusqueda = "proveedor"
            Case E_TipoBusqueda.CI_Rif
                _DatosFicha._TipoBusqueda = "ci_rif"
            Case E_TipoBusqueda.Codigo_Entidad
                _DatosFicha._TipoBusqueda = "codigo_proveedor"
        End Select
        MT_TEXTOBUSQUEDA.Text = ""
        MT_TEXTOBUSQUEDA.Select()
        MT_TEXTOBUSQUEDA.Focus()
    End Sub

    Sub VerDetalle()
        If BS_DOCUMENTOS.Current("estatus") = "ANULADO" Then
            VerDetalleAnulacion()
        Else
            If BS_DOCUMENTOS.Current("tipo") = "PAGO" Then
                Dim xp1 As New SqlParameter("@numero", BS_DOCUMENTOS.Current("documento"))
                Dim xp2 As New SqlParameter("@numero", BS_DOCUMENTOS.Current("documento"))
                Dim xtipo As String = F_GetString("select tipo_pago from cxp_recibos where numero=@numero", xp1)
                Dim xauto As String = F_GetString("select auto from cxp_recibos where numero=@numero", xp2)

                If Not IsDBNull(xtipo) And xtipo <> "" Then
                    Select Case CType(xtipo, DataSistema.MiDataSistema.DataSistema.TipoPago)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Cheque
                            Dim xp3 As New SqlParameter("@auto", xauto)
                            Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp3)
                            VisualizarComprobanteEgreso(xauto_mov)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Transferencia
                            Dim xp3 As New SqlParameter("@auto", xauto)
                            Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp3)
                            VisualizarComprobanteEgresoGeneral(xauto_mov)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.NotaCredito
                            VisualizarReciboCxP(xauto)
                        Case DataSistema.MiDataSistema.DataSistema.TipoPago.Retencion
                            Dim xp3 As New SqlParameter("@auto", xauto)
                            Dim xauto_ret As String = F_GetString("select auto from retenciones_compras where auto_recibo_cxp=@auto", xp3)
                            VisualizarRet_Compras(xauto_ret, "", "")
                    End Select
                Else
                    VisualizarReciboCxP(xauto)
                End If
            Else
                VerDetalleDocumento()
            End If
        End If
    End Sub

    Sub VerDetalleAnulacion()
        Dim xficha As New DetalleDocumentosAnulados(New c_DetalleDocumentosAnuladosCxP(CType(BS_DOCUMENTOS.Current, DataRowView).Row))
        xficha.ShowDialog()
    End Sub

    Sub VerDetalleDocumento()
        Dim xclass As New FichaCtasPagar
        xclass.F_CuentaPagar.F_CargarRegistro(BS_DOCUMENTOS.Current("auto"))

        If xclass.F_CuentaPagar.RegistroDato._AutoMovimientoEntrada <> "" Then
            Dim xficha As New DetalleDocumentosCxC(New c_DetalleDocumentosCxP(xclass.F_CuentaPagar.RegistroDato))
            xficha.ShowDialog()
        Else
            Dim xcompra As New FichaCompras.c_Compra
            xcompra.F_CargarCompra(xclass.F_CuentaPagar.RegistroDato._AutoDocumento)

            If xcompra.RegistroDato._TipoCompraRegistrada = TipoCompraRegistrada.CompraMercancia Then
                VisualizarDoc_Compras(xclass.F_CuentaPagar.RegistroDato._AutoDocumento)
            Else
                VisualizarDoc_Gastos(xclass.F_CuentaPagar.RegistroDato._AutoDocumento)
            End If
        End If
    End Sub

    Sub GetProveedor()
        If BS_DOCUMENTOS.Current IsNot Nothing Then
            LB_NOMBREENTIDAD.Text = BS_DOCUMENTOS.Current("proveedor").ToString.Trim
        Else
            LB_NOMBREENTIDAD.Text = ""
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 4 Or e.ColumnIndex = 9 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        If MG_DOCUMENTOS.Rows(e.RowIndex).Cells(10).Value = "ANULADO" Then
            MG_DOCUMENTOS.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkRed
            MG_DOCUMENTOS.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(MG_DOCUMENTOS.DefaultCellStyle.Font, FontStyle.Bold)
        End If
    End Sub

    Public Function F_BuscarAhora() As Boolean Implements IAdmControlCuentas.F_BuscarAhora
        Try
            CargarDocumentos()
        Catch ex As Exception
            MessageBox.Show("ERROR AL BUSCAR DOCUMENTOS:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function F_BusquedaAvanzada() As Boolean Implements IAdmControlCuentas.F_BusquedaAvanzada
        Try
            Dim xficha As New BusquedaAvanzadaAdmCxP
            With xficha
                AddHandler ._LlamarReceptor, AddressOf CargarDocumentos
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show("ERROR AL BUSCAR DOCUMENTOS:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function F_AnularDocumento() As Boolean Implements IAdmControlCuentas.F_AnularDocumento
        'Try
        '    If BS_DOCUMENTOS.Current IsNot Nothing Then
        '        'g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxCobrar_AnularDocumento.F_Permitir()

        '        If BS_DOCUMENTOS.Current("estatus") = "" Then
        '            If BS_DOCUMENTOS.Current("auto_documento").ToString.Trim = "" Or BS_DOCUMENTOS.Current("tipo") = "PAGO" Then
        '                Dim xsalida As Boolean = False
        '                Dim xdetalle As String = ""
        '                Dim xficha As New AnularDocumento(New AnularDocumento_CuentaPorPagar("Documento Cuentas por Pagar"))
        '                With xficha
        '                    .ShowDialog()
        '                    xdetalle = ._DetalleNotas
        '                    xsalida = ._EstatusSalida
        '                End With

        '                If xsalida Then
        '                    AnularDocumento(xdetalle)
        '                End If
        '            Else
        '                MessageBox.Show("EL DOCUMENTO NO PUEDE SER ANULADO. DEBE ANULARLO POR COMPRA", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            End If
        '        Else
        '            MessageBox.Show("EL DOCUMENTO YA ESTA ANULADO. NO PUEDE VOLVER A ANULARLO", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Function

    Sub AnularDocumento(ByVal xdetalle As String)
        'Dim _FichaCxP As New FichaCtasPagar
        'Dim _CxP As New FichaCtasPagar.c_CxP
        'Dim _CxP_Recibos As New FichaCtasPagar.c_Recibo
        'Dim _CxP_Documentos As New List(Of FichaCtasPagar.c_Documentos.c_Registro)
        'Dim _Doc_Anulados As New FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro

        'Dim xauto_recibo As String = ""
        'Dim xtipopago As String = ""
        'Dim dtb_documentos As New DataTable
        'Dim xnumero As String = BS_DOCUMENTOS.Current("documento")

        'Dim xrow As DataRow = CType(BS_DOCUMENTOS.Current, DataRowView).Row
        '_CxP.M_CargarRegistro(xrow)

        'If _CxP.RegistroDato._TipoDocumento = "PAG" Then
        '    Dim xp1 As New SqlParameter("@numero", xnumero)
        '    xauto_recibo = F_GetString("select auto from cxp_recibos where numero=@numero", xp1)

        '    Dim xparam As New SqlParameter("@auto_cxp_recibo", xauto_recibo)
        '    g_MiData.F_GetData("select * from cxp_documentos where auto_cxp_recibo=@auto_cxp_recibo", dtb_documentos, xparam)

        '    For Each xrow In dtb_documentos.Rows
        '        Dim xcxp_doc As New FichaCtasPagar.c_Documentos
        '        xcxp_doc.M_CargarRegistro(xrow)
        '        _CxP_Documentos.Add(xcxp_doc.RegistroDato)
        '    Next
        'End If

        'With _Doc_Anulados
        '    ._CodigoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._CodigoUsuario
        '    ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
        '    ._FechaEmision = g_MiData.p_FechaDelMotorBD
        '    ._Hora = g_MiData.p_HoraDelMotorBD.ToString
        '    ._NotasDetalle = xdetalle
        '    ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
        'End With

        'Dim xanulardoc As New FichaCtasPagar.c_CxP.c_AnularDocumentoCxP
        'With xanulardoc
        '    ._AutoReciboCxp = xauto_recibo
        '    ._DocumentoAnular = _Doc_Anulados
        '    ._FichaRegistroCxp = _CxP.RegistroDato
        '    ._ListaDocumentos = _CxP_Documentos
        'End With
        'AddHandler _FichaCxP.DocumentoProcesado, AddressOf AvisoDocumentoProcesado
        '_FichaCxP.F_AnularDocumento(xanulardoc)
    End Sub

    Sub AvisoDocumentoProcesado()
        MessageBox.Show("DOCUMENTO ANULADO EXITOSAMENTE... OK", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
        _DatosFicha._TipoBusqueda = "proveedor"
        _DatosFicha._TextoABuscar = ""
        _DatosFicha._FechaDesde = Date.MinValue
        _DatosFicha._FechaHasta = Date.MinValue
        _DatosFicha._TipoDocumento = E_TipoDocumento.Todos
        CargarDocumentos()
    End Sub

    Public Function F_VisualizarDocumento() As Boolean Implements IAdmControlCuentas.F_VisualizarDocumento
        Try
            If BS_DOCUMENTOS.Current IsNot Nothing Then
                If BS_DOCUMENTOS.Current("tipo") = "PAGO" Then
                    Dim xp1 As New SqlParameter("@numero", BS_DOCUMENTOS.Current("documento").ToString.Trim)
                    Dim xp2 As New SqlParameter("@numero", BS_DOCUMENTOS.Current("documento").ToString.Trim)
                    Dim xtipo As String = F_GetString("select tipo_pago from cxp_recibos where numero=@numero", xp1)
                    Dim xauto As String = F_GetString("select auto from cxp_recibos where numero=@numero", xp2)

                    If Not IsDBNull(xtipo) And xtipo <> "" Then
                        Select Case CType(xtipo, DataSistema.MiDataSistema.DataSistema.TipoPago)
                            Case DataSistema.MiDataSistema.DataSistema.TipoPago.Cheque
                                Dim xp3 As New SqlParameter("@auto", xauto)
                                Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp3)
                                VisualizarComprobanteEgreso(xauto_mov)
                            Case DataSistema.MiDataSistema.DataSistema.TipoPago.Transferencia
                                Dim xp3 As New SqlParameter("@auto", xauto)
                                Dim xauto_mov As String = F_GetString("select auto_movimientos from movimientos_cxp_recibos where auto_cxp_recibos=@auto", xp3)
                                VisualizarComprobanteEgresoGeneral(xauto_mov)
                            Case DataSistema.MiDataSistema.DataSistema.TipoPago.NotaCredito
                                VisualizarReciboCxP(xauto)
                            Case DataSistema.MiDataSistema.DataSistema.TipoPago.Retencion
                                Dim xp3 As New SqlParameter("@auto", xauto)
                                Dim xauto_ret As String = F_GetString("select auto from retenciones_compras where auto_recibo_cxp=@auto", xp3)
                                VisualizarRet_Compras(xauto_ret, "", "")
                        End Select
                    Else
                        VisualizarReciboCxP(xauto)
                    End If
                Else
                    VerDetalleDocumento()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR AL VISUALIZAR DOCUMENTO:" + vbCrLf + ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class