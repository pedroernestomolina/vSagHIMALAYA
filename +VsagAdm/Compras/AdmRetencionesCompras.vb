Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles

Public Class AdmRetencionesCompras
    Dim xplantilla As IAdministradorRetencionesCompras

    Property _Plantilla() As IAdministradorRetencionesCompras
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IAdministradorRetencionesCompras)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xtipo_plantilla As IAdministradorRetencionesCompras)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Plantilla = xtipo_plantilla
        AddHandler _Plantilla.ActualizarFicha, AddressOf ActualizarItems
    End Sub

    Sub ActualizarItems()
        Me.E_ITEMS_1.Text = _Plantilla._CantidadRegistros
        Me.E_ITEMS_2.Text = _Plantilla._CantidadRegistrosRelacionados
    End Sub

    Sub Inicializa()
        Me.Text = _Plantilla._TituloVentana

        Me.E_ITEMS_1.Text = "0"
        Me.E_ITEMS_2.Text = "0"

        _Plantilla._CargarComboBuscarPor(Me.MCB_BUSCAR)

        With Me.MCB_TIPO_DOC
            .DataSource = _Plantilla._CargarComboTipoDocumento
            .SelectedIndex = 0
        End With

        xplantilla._CargarDataGrid(Me.MisGrid1, Me.MisGrid2)

        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()
    End Sub

    Sub IrInicio()
        Me.MT_BUSCAR.Text = ""
        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()
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
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub MisFechas1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (Me.MisFechas2.Checked) Then
            If (MisFechas1.Value.Date > MisFechas2.Value.Date) Then
                MessageBox.Show("Fecha Incorrecta verifique Por Favor...", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MisFechas1.Value = MisFechas2.Value
            End If
        End If
    End Sub

    Private Sub MisFechas2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (Me.MisFechas1.Checked) Then
            If (MisFechas2.Value.Date < MisFechas1.Value.Date) Then
                MessageBox.Show("Fecha Incorrecta verifique Por Favor...", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MisFechas2.Value = MisFechas1.Value
            End If
        End If
    End Sub

    Private Sub MCB_BUSCAR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSCAR.SelectedIndexChanged
        IrInicio()
    End Sub

    Private Sub Visualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_VISUALIZAR.Click
        Try
            _Plantilla._VisualizarDocumento()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        IrInicio()
    End Sub

    Private Sub Anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ANULAR.Click
        Try
            _Plantilla._AnularDocumento()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        IrInicio()
    End Sub

    Private Sub BT_BUSCAR_AHORA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR_AHORA.Click
        Try
            Dim xfiltro As New IAdministradorRetencionesCompras._FilterData
            With xfiltro
                ._DesdeFecha = IIf(Me.MisFechas1.Checked, Me.MisFechas1.Value.Date, Date.MinValue)
                ._HastaFecha = IIf(Me.MisFechas2.Checked, Me.MisFechas2.Value.Date, Date.MinValue)
                ._Texto = Me.MT_BUSCAR.r_Valor
                ._TipoDocumento = Me.MCB_TIPO_DOC.SelectedIndex
                ._TipoFilter = Me.MCB_BUSCAR.SelectedIndex
            End With
            _Plantilla._BuscarAhora(xfiltro)

            Me.MT_BUSCAR.Text = ""
            Me.MisGrid1.Select()
            Me.MisGrid1.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BT_VISUALIZAR_RETENCIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_VISUALIZAR_RETENCIONES.Click
        _Plantilla._VisualizarRetenciones()
        IrInicio()
    End Sub
End Class

Public Interface IAdministradorRetencionesCompras
    Event ActualizarFicha()

    Function _VisualizarDocumento() As Boolean
    Function _AnularDocumento() As Boolean
    Function _VisualizarRetenciones() As Boolean

    Function _CargarDataGrid(ByVal xdatagrid As MisGrid, ByVal xdatagrid_2 As MisGrid) As BindingSource
    Function _BuscarAhora(ByVal xfilterdata As _FilterData) As Boolean
    Sub _CargarComboBuscarPor(ByVal xcombo As MisControles.Controles.MisComboBox)

    ReadOnly Property _CantidadRegistros() As String
    ReadOnly Property _CantidadRegistrosRelacionados() As String
    ReadOnly Property _TituloVentana() As String
    ReadOnly Property _CargarComboTipoDocumento() As String()

    Class _FilterData
        Private f_tipofilter As Integer
        Private f_texto As String
        Private f_desdefecha As DateTime
        Private f_hastafecha As DateTime
        Private f_tipodocumento As Integer

        Property _TipoFilter() As Integer
            Get
                Return f_tipofilter
            End Get
            Set(ByVal value As Integer)
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

        Property _DesdeFecha() As DateTime
            Get
                Return f_desdefecha
            End Get
            Set(ByVal value As DateTime)
                f_desdefecha = value
            End Set
        End Property

        Property _HastaFecha() As DateTime
            Get
                Return f_hastafecha
            End Get
            Set(ByVal value As DateTime)
                f_hastafecha = value
            End Set
        End Property

        Property _TipoDocumento() As Integer
            Get
                Return f_tipodocumento
            End Get
            Set(ByVal value As Integer)
                f_tipodocumento = value
            End Set
        End Property

        Sub New()
            _TipoFilter = 0
            _TipoDocumento = 0
            _Texto = ""
            _DesdeFecha = Date.MinValue
            _HastaFecha = Date.MinValue
        End Sub
    End Class
End Interface

Public Class AdmRet_Compras
    Implements IAdministradorRetencionesCompras

    Dim xds As DataSet
    Dim xtb_1 As DataTable
    Dim xtb_2 As DataTable

    Dim f_binding As BindingSource
    Dim f_binding_2 As BindingSource

    Dim f_condicion As String = "auto<>''"

    Dim xcombo1 As MisComboBox
    Dim xcombo2 As MisComboBox

    Dim xultimofiltro As IAdministradorRetencionesCompras._FilterData

    Enum _TipoBusqueda As Integer
        codigo_entidad = FichaProveedores.TipoBusqueda.PorCodigo
        nombre = FichaProveedores.TipoBusqueda.PorNombreRazonSocial
        ci_rif = FichaProveedores.TipoBusqueda.PorRif_CI
    End Enum

    ReadOnly Property _MaximoItemsMostrar() As Integer
        Get
            Return g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_AdmDocumentos
        End Get
    End Property

    Sub New()
        xtb_1 = New DataTable("retenciones_compras")
        xtb_2 = New DataTable
        xds = New DataSet
        xds.Tables.Add(xtb_1)
        xds.Tables.Add(xtb_2)
        xultimofiltro = New IAdministradorRetencionesCompras._FilterData
    End Sub

    Function GetCondicionBusqueda(ByVal xfilterdata As IAdministradorRetencionesCompras._FilterData) As String
        _Condicion_1 = ""
        Dim xtexto As String = xfilterdata._Texto
        If (xfilterdata._Texto <> "") Then
            If xtexto.Substring(0, 1) = "*" Then
                xtexto = xtexto.Substring(1)
            End If

            Dim xt As _TipoBusqueda = xfilterdata._TipoFilter
            Select Case xfilterdata._Texto.Substring(0, 1)
                Case "*" : xcond += "and r." + xt.ToString() + " like '%" + xtexto + "%' "
                Case Else : xcond += "and r." + xt.ToString() + " like '" + xtexto + "%' "
            End Select
        End If

        If xfilterdata._TipoDocumento <> 0 Then
            Select Case xfilterdata._TipoDocumento
                Case 1 : xcond += " and rd.tipo = '01' "
                Case 2 : xcond += " and rd.tipo = '02' "
                Case 3 : xcond += " and rd.tipo = '03' "
            End Select
        End If

        If (xfilterdata._DesdeFecha <> Date.MinValue) Then
            xcond += "and r.fecha >= '" & xfilterdata._DesdeFecha & "' "
        End If

        If (xfilterdata._HastaFecha <> Date.MinValue) Then
            xcond += "and r.fecha <= '" & xfilterdata._HastaFecha & "' "
        End If
        Return xcond
    End Function

    Private Const xsentencia_1 = "select distinct top(@top) r.fecha" & _
        ", r.documento" & _
        ", r.nombre" & _
        ", r.ci_rif" & _
        ", r.tasa_retencion" & _
        ", r.retencion" & _
        ", (case r.estatus when '1' then 'Anulado' else 'Activo' end) xestatus" & _
        ", r.ano_relacion" & _
        ", r.mes_relacion" & _
        ", r.auto_entidad" & _
        ", r.auto " & _
        "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto " & _
        "where "

    Private Const xsentencia_2 = "SELECT rd.fecha" & _
            ", (case rd.tipo when '01' then 'COMPRAS' when '02' then 'NOTA DÉBITO' when '03' then 'NOTA CRÉDITO' end) xtipo " & _
            ", rd.documento" & _
            ", rd.exento exento" & _
            ", rd.base base" & _
            ", rd.impuesto impuesto" & _
            ", rd.retencion retencion" & _
            ", rd.total importe " & _
            ",(case c.estatus when '0' then 'Activo' when '1' then 'Anulado' end) xestatus, rd.auto, rd.auto_documento " & _
            "FROM retenciones_compras_detalle rd join compras c on rd.auto_documento=c.auto " & _
            "where rd.auto in (select distinct top(@top) r.auto from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto where "

    Dim xcond As String = ""
    Property _Condicion_1() As String
        Get
            Return xcond
        End Get
        Set(ByVal value As String)
            xcond = value
        End Set
    End Property

    ReadOnly Property _Sentencia_1() As String
        Get
            'Return xsentencia_1 + " r.auto<>'' " + _Condicion_1 + " group by  r.fecha" & _
            '", r.documento" & _
            '", r.nombre" & _
            '", r.ci_rif" & _
            '", r.tasa_retencion" & _
            '", r.retencion" & _
            '", r.estatus" & _
            '", r.ano_relacion" & _
            '", r.mes_relacion" & _
            '", r.auto_entidad" & _
            '", r.auto order by r.fecha desc, r.auto desc"

            Return xsentencia_1 + " r.auto<>'' " + _Condicion_1 + " order by r.auto desc"
        End Get
    End Property

    ReadOnly Property _Sentencia_2() As String
        Get
            Return xsentencia_2 + " r.auto<>'' " + _Condicion_1 + " order by r.auto desc)"
        End Get
    End Property

    Sub CargardataInicial()
        Try
            Dim xp1 As New SqlParameter("@top", _MaximoItemsMostrar)
            Dim xp2 As New SqlParameter("@top", _MaximoItemsMostrar)

            g_MiData.F_GetData(_Sentencia_1, xtb_1, xp1)
            g_MiData.F_GetData(_Sentencia_2, xtb_2, xp2)
            f_binding = New BindingSource(xds, xtb_1.TableName)

            Dim xcol1 As DataColumn = xtb_1.Columns("auto")
            Dim xcol2 As DataColumn = xtb_2.Columns("auto")
            Dim xrelation As New DataRelation("RET_COMPRA_RET_COMPRA_DETALLE", xcol1, xcol2, True)
            xds.Relations.Add(xrelation)

            f_binding_2 = New BindingSource(f_binding, "RET_COMPRA_RET_COMPRA_DETALLE")
        Catch ex As Exception
            Throw New Exception("CARGAR DATA RETENCIONES" + vbCrLf + ex.Message)
        End Try
    End Sub

    Public Function _CargarDataGrid(ByVal xdatagrid As MisGrid, ByVal xdatagrid_2 As MisGrid) As System.Windows.Forms.BindingSource Implements IAdministradorRetencionesCompras._CargarDataGrid
        Try
            CargardataInicial()
            With xdatagrid
                .Columns.Add("col0", "F/Emisión")
                .Columns.Add("col1", "Documento")
                .Columns.Add("col2", "Cliente")
                .Columns.Add("col3", "CI/RIF")
                .Columns.Add("col4", "Tasa")
                .Columns.Add("col5", "Retención")
                .Columns.Add("col6", "Estatus")

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "documento"
                .Columns(2).DataPropertyName = "nombre"
                .Columns(3).DataPropertyName = "ci_rif"
                .Columns(4).DataPropertyName = "tasa_retencion"
                .Columns(5).DataPropertyName = "retencion"
                .Columns(6).DataPropertyName = "xestatus"

                .DataSource = f_binding

                .Columns(0).Width = 70
                .Columns(1).Width = 150
                .Columns(3).Width = 110
                .Columns(4).Width = 100
                .Columns(5).Width = 100
                .Columns(6).Width = 100
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .Ocultar(8)
                AddHandler .CellFormatting, AddressOf MiFormato
                AddHandler f_binding.PositionChanged, AddressOf ActualizarItems
                AddHandler .Accion, AddressOf VisualizarPlanillaRetencion
            End With

            With xdatagrid_2
                .Columns.Add("col0", "Fecha")
                .Columns.Add("col1", "Movimiento")
                .Columns.Add("col2", "Documento")
                .Columns.Add("col3", "Exento")
                .Columns.Add("col4", "Base")
                .Columns.Add("col5", "Impuesto")
                .Columns.Add("col6", "Retención")
                .Columns.Add("col7", "Importe")
                .Columns.Add("col8", "Estatus")

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "xtipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "exento"
                .Columns(4).DataPropertyName = "base"
                .Columns(5).DataPropertyName = "impuesto"
                .Columns(6).DataPropertyName = "retencion"
                .Columns(7).DataPropertyName = "importe"
                .Columns(8).DataPropertyName = "xestatus"

                .DataSource = f_binding_2

                .Columns(0).Width = 70
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(2).Width = 130
                .Columns(3).Width = 95
                .Columns(4).Width = 95
                .Columns(5).Width = 95
                .Columns(6).Width = 95
                .Columns(7).Width = 95
                .Columns(8).Width = 60

                .Ocultar(10)
                AddHandler .CellFormatting, AddressOf MiFormato2
                AddHandler .Accion, AddressOf VisualizarDocumentoCompra
            End With

            RaiseEvent ActualizarFicha()
            Return f_binding
        Catch ex As Exception
            Throw New Exception("RETENCIONES IVA COMPRAS" + vbCrLf + "CARGAR DATAGRIDVIEW" + vbCrLf + ex.Message)
        End Try
    End Function

    Sub VisualizarPlanillaRetencion(ByVal xrow As System.Windows.Forms.DataGridViewRow)
        Try
            Dim xreg As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
            Dim xret As New FichaCompras.c_Retenciones
            xret.F_BuscarDocumento(xreg("auto"))

            If xret.RegistroDato._EstatusRetencion = TipoEstatus.Activo Then
                VisualizarRet_Compras(xret.RegistroDato._AutoRetencion, "", "")
            Else
                Dim xcxp As New FichaCtasPagar.c_CxP
                xcxp.F_CargarRegistro(xret.RegistroDato._AutoCxP)
                Dim xficha As New DetalleDocumentosAnulados(New c_DetalleDocumentosAnuladosCxP(xcxp.RegistroDato._AutoCxP))
                xficha.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub VisualizarDocumentoCompra(ByVal xrow As System.Windows.Forms.DataGridViewRow)
        Try
            Dim xreg As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
            Dim xcompra As New FichaCompras.c_Compra

            xcompra.F_CargarCompra(xreg("auto_documento").ToString.Trim)
            If xcompra.RegistroDato._TipoCompraRegistrada = TipoCompraRegistrada.CompraMercancia Then
                VisualizarDoc_Compras(xcompra.RegistroDato._AutoDocumentoCompra)
            Else
                VisualizarDoc_Gastos(xcompra.RegistroDato._AutoDocumentoCompra)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarItems()
        If f_binding.Current IsNot Nothing Then
            RaiseEvent ActualizarFicha()
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Dim xgrid As DataGridView = sender
        If xgrid.Rows(e.RowIndex).Cells(6).Value = "Anulado" Then
            e.CellStyle.ForeColor = Color.Red
        End If

        If e.ColumnIndex >= 4 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If

    End Sub

    Sub MiFormato2(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 3 And e.ColumnIndex <= 7 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Public ReadOnly Property _TituloVentana() As String Implements IAdministradorRetencionesCompras._TituloVentana
        Get
            Return "Administrador De Retenciones De Compras"
        End Get
    End Property

    Public ReadOnly Property _CantidadRegistros() As String Implements IAdministradorRetencionesCompras._CantidadRegistros
        Get
            Return xtb_1.Rows.Count.ToString()
        End Get
    End Property

    Public ReadOnly Property _CantidadRegistrosRelacionados() As String Implements IAdministradorRetencionesCompras._CantidadRegistrosRelacionados
        Get
            Return f_binding_2.Count.ToString
        End Get
    End Property

    Public ReadOnly Property _CargarComboTipoDocumento() As String() Implements IAdministradorRetencionesCompras._CargarComboTipoDocumento
        Get
            Dim xlista As String() = {"Todos", "Compras", "Nota Débito", "Nota Crédito"}
            Return xlista
        End Get
    End Property

    Public Sub _CargarComboBuscarPor(ByVal xcombo As MisControles.Controles.MisComboBox) Implements IAdministradorRetencionesCompras._CargarComboBuscarPor
        With xcombo
            .DataSource = g_MiData.f_FichaClientes.f_Clientes.p_TipoBusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarCliente
        End With
    End Sub

    Public Function _BuscarAhora(ByVal xfilterdata As IAdministradorRetencionesCompras._FilterData) As Boolean Implements IAdministradorRetencionesCompras._BuscarAhora
        Try
            xtb_2.Rows.Clear()
            xtb_1.Rows.Clear()

            Dim xp1 As New SqlParameter("@top", _MaximoItemsMostrar)
            Dim xp2 As New SqlParameter("@top", _MaximoItemsMostrar)
            xcond = GetCondicionBusqueda(xfilterdata)
            xultimofiltro = xfilterdata

            g_MiData.F_GetData(_Sentencia_1, xtb_1, xp1)
            g_MiData.F_GetData(_Sentencia_2, xtb_2, xp2)

            RaiseEvent ActualizarFicha()
        Catch ex As Exception
            Throw New Exception("RETENCIONES IVA COMPRAS" + vbCrLf + "BUSCAR AHORA" + vbCrLf + ex.Message)
        End Try
    End Function

    Public Function _AnularDocumento() As Boolean Implements IAdministradorRetencionesCompras._AnularDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                If f_binding.Current("xestatus").ToString.Trim = "Anulado" Then
                    Throw New Exception("Error Al Anular... El Documento Ya Fue Anulado")
                End If

                If MessageBox.Show("Estas Seguro De Querer Anular Esta Retencion ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                    Dim xficha As New FichaCompras
                    xficha.F_Retenciones.F_BuscarDocumento(xreg("auto"))

                    If xficha.F_Retenciones.RegistroDato.VerificarDocumento_AnoMesPeriodo(g_MiData.p_FechaDelMotorBD) Then
                        Dim _Doc_Anulados As New FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro
                        Dim xdetalle As String = ""
                        Dim xseg As Boolean = False

                        Dim xficha_anular As New AnularDocumento(New AnularDocumento_RetencionCompra("Retencion Iva Compra"))
                        With xficha_anular
                            .ShowDialog()
                            xseg = ._EstatusSalida
                            xdetalle = ._DetalleNotas
                        End With

                        If xseg Then
                            With _Doc_Anulados
                                ._AutoDocumento = ""
                                ._CodigoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._CodigoUsuario
                                ._EstacionEquipo = g_EquipoEstacion.p_EstacionNombre
                                ._FechaEmision = g_MiData.p_FechaDelMotorBD
                                ._Hora = g_MiData.p_HoraDelMotorBD.ToString
                                ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
                                ._NotasDetalle = xdetalle
                            End With

                            g_MiData.f_FichaCompras.F_AnularRetencionIva(xficha.F_Retenciones.RegistroDato._AutoRetencion, _Doc_Anulados)
                            MessageBox.Show("Documento De Retencion Anulado Satisfactoriamente", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        Throw New Exception("ERROR... NO SE PUEDE ANULAR UN DOCUMENTO DE PERIODOS ANTERIORES, POR FAVOR VERIFIQUE")
                    End If
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            ActualizarData()
        End If
    End Function

    Function RetornarPeriodo(ByVal xfecha As Date)
        If xfecha.Day >= 1 And xfecha.Day <= 15 Then
            Return 1
        Else
            Return 2
        End If
    End Function

    Sub ActualizarData()
        _BuscarAhora(xultimofiltro)
    End Sub

    Public Function _VisualizarDocumento() As Boolean Implements IAdministradorRetencionesCompras._VisualizarDocumento
        If f_binding.Current IsNot Nothing Then
            Try
                Dim xauto_ret As String = f_binding.Current("auto")
                Dim xauto_ent As String = f_binding.Current("auto_entidad")
                Dim xdocumento As String = f_binding.Current("documento")

                VisualizarRet_Compras(xauto_ret, xauto_ent, xdocumento)
            Catch ex As Exception
                Throw New Exception("RETENCIONES IVA COMPRAS" + vbCrLf + "VISUALIZAR DOCUMENTO" + vbCrLf + ex.Message)
            End Try
        End If
    End Function

    Function SelectUltimoFiltro() As String
        Dim Sel As String = "select r.documento" & _
                ", r.nombre" & _
                ", r.ci_rif" & _
                ", r.fecha" & _
                ", r.ano_relacion" & _
                ", r.mes_relacion" & _
                ", r.base" & _
                ", r.impuesto" & _
                ", r.retencion" & _
                ", r.tasa_retencion" & _
                ", r.total" & _
                ", r.exento " & _
            "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto " & _
            "where r.auto<>'' and r.estatus='0' " + GetCondicionBusqueda(xultimofiltro) + "group by  r.fecha" & _
                ", r.documento" & _
                ", r.nombre" & _
                ", r.ci_rif" & _
                ", r.tasa_retencion" & _
                ", r.retencion" & _
                ", r.ano_relacion" & _
                ", r.mes_relacion" & _
                ", r.base" & _
                ", r.impuesto" & _
                ", r.total" & _
                ", r.exento" & _
                "  order by r.fecha desc"
        Return Sel
    End Function

    Public Function _VisualizarRetenciones() As Boolean Implements IAdministradorRetencionesCompras._VisualizarRetenciones
        Try
            VisualizarAllRet_Compras(SelectUltimoFiltro)
        Catch ex As Exception
            Throw New Exception("RETENCIONES IVA COMPRAS" + vbCrLf + "VISUALIZAR RETENCIONES" + vbCrLf + ex.Message)
        End Try
    End Function

    Public Event ActualizarFicha() Implements IAdministradorRetencionesCompras.ActualizarFicha
End Class