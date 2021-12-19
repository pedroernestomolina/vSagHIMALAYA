Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles

Public Class AdmRetenciones
    Dim xplantilla As IAdministradorRetenciones

    Property _Plantilla() As IAdministradorRetenciones
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IAdministradorRetenciones)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xtipo_plantilla As IAdministradorRetenciones)

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

    Private Sub MisFechas1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MisFechas1.ValueChanged
        If (Me.MisFechas2.Checked) Then
            If (MisFechas1.Value.Date > MisFechas2.Value.Date) Then
                MessageBox.Show("Fecha Incorrecta verifique Por Favor...", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MisFechas1.Value = MisFechas2.Value
            End If
        End If
    End Sub

    Private Sub MisFechas2_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MisFechas2.ValueChanged
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
            Dim xfiltro As New IAdministradorRetenciones._FilterData
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

    Private Sub AdmRetenciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

End Class

Public Interface IAdministradorRetenciones
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

Public Class AdmRet_Ventas
    Implements IAdministradorRetenciones

    Dim xds As DataSet
    Dim xtb_1 As DataTable
    Dim xtb_2 As DataTable

    Dim f_binding As BindingSource
    Dim f_binding_2 As BindingSource

    Dim f_condicion As String = "auto<>''"

    Dim xcombo1 As MisComboBox
    Dim xcombo2 As MisComboBox

    Dim xultimofiltro As IAdministradorRetenciones._FilterData

    Enum _TipoBusqueda As Integer
        codigo_entidad = FichaClientes.TipoBusquedaCliente.PorCodigo
        nombre = FichaClientes.TipoBusquedaCliente.PorNombreRazonSocial
        ci_rif = FichaClientes.TipoBusquedaCliente.PorRif_CI
    End Enum

    ReadOnly Property _MaximoItemsMostrar() As Integer
        Get
            Return g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_AdmDocumentos
        End Get
    End Property

#Region "FUNCIONES SELECT"
    Protected Friend Const SELECT_DATAEMPRESA As String = "select nombre" & _
            ", rif" & _
            ", direccion" & _
            ", telefono_1 telefono" & _
            ", sucursal" & _
            ", codigo_sucursal " & _
        "from empresa"

    Protected Friend Const SELECT_RETENCIONES_VENTAS As String = "select documento" & _
            ", nombre" & _
            ", ci_rif" & _
            ", fecha" & _
            ", ano_relacion" & _
            ", mes_relacion" & _
            ", base" & _
            ", impuesto" & _
            ", retencion" & _
            ", tasa_retencion" & _
            ", total" & _
            ", exento " & _
        "from retenciones_ventas " & _
        "where auto=@auto "

    Protected Friend Const SELECT_RETENCIONES_VENTAS_DETALLE As String = "select * " & _
        "from ( " & _
            "select documento" & _
                ", fecha" & _
                ", impuesto1 impuesto" & _
                ", tasa1 tasa" & _
                ", aplica" & _
                ", control" & _
                ", tipo" & _
                ", '1' tipo_impuesto" & _
                ", exento " & _
                ", base1 base " & _
             "from ventas " & _
             "where auto_entidad=@auto_entidad and comprobante_retencion=@comprobante_retencion and impuesto1<>0 " & _
             "union " & _
             "select documento" & _
                ", fecha" & _
                ", impuesto2 impuesto" & _
                ", tasa2 tasa" & _
                ", aplica" & _
                ", control" & _
                ", tipo" & _
                ", '2' tipo_impuesto" & _
                ", (case when impuesto1 <>0 then 0 else exento end) exento" & _
                ", base2 base " & _
             "from ventas " & _
             "where auto_entidad=@auto_entidad and comprobante_retencion=@comprobante_retencion and impuesto2<>0 ) T " & _
         "order by t.documento, t.tasa desc"
#End Region

    Sub New()
        xtb_1 = New DataTable("retenciones_ventas")
        xtb_2 = New DataTable
        xds = New DataSet
        xds.Tables.Add(xtb_1)
        xds.Tables.Add(xtb_2)
        xultimofiltro = New IAdministradorRetenciones._FilterData
    End Sub

    Function GetCondicionBusqueda(ByVal xfilterdata As IAdministradorRetenciones._FilterData) As String
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

    Private Const xsentencia_1 = "select top(@top) r.fecha" & _
        ", r.documento" & _
        ", r.nombre" & _
        ", r.ci_rif" & _
        ", r.tasa_retencion" & _
        ", r.retencion" & _
        ", r.ano_relacion" & _
        ", r.mes_relacion" & _
        ", r.auto_entidad" & _
        ", r.auto " & _
     "from retenciones_ventas r join retenciones_ventas_detalle rd on r.auto=rd.auto " & _
     "where "

    Private Const xsentencia_2 = "SELECT rd.fecha" & _
            ", (case rd.tipo when '01' then 'VENTAS' when '02' then 'NOTA DÉBITO' when '03' then 'NOTA CRÉDITO' end) tipo " & _
            ", rd.documento" & _
            ", rd.exento exento" & _
            ", rd.base base" & _
            ", rd.impuesto impuesto" & _
            ", rd.retencion retencion" & _
            ", rd.total importe " & _
            ",(case v.estatus when '0' then 'Activo' when '1' then 'Anulado' end) estatus, rd.auto " & _
          "FROM retenciones_ventas_detalle rd join ventas v on rd.auto_documento=v.auto " & _
          "where rd.auto in (select top(@top) r.auto from retenciones_ventas r where "

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
            Return xsentencia_1 + "r.auto<>''" + _Condicion_1 + "group by  r.fecha" & _
            ", r.documento" & _
            ", r.nombre" & _
            ", r.ci_rif" & _
            ", r.tasa_retencion" & _
            ", r.retencion" & _
            ", r.ano_relacion" & _
            ", r.mes_relacion" & _
            ", r.auto_entidad" & _
            ", r.auto order by r.fecha desc"
        End Get
    End Property

    ReadOnly Property _Sentencia_2() As String
        Get
            Return xsentencia_2 + "r.auto<>''" + _Condicion_1 + " order by r.fecha desc)"
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
            Dim xrelation As New DataRelation("RET_VENTA_RET_VENTA_DETALLE", xcol1, xcol2, True)
            xds.Relations.Add(xrelation)

            f_binding_2 = New BindingSource(f_binding, "RET_VENTA_RET_VENTA_DETALLE")
        Catch ex As Exception
            Throw New Exception("CARGAR DATA RETENCIONES" + vbCrLf + ex.Message)
        End Try
    End Sub

    Public Function _CargarDataGrid(ByVal xdatagrid As MisGrid, ByVal xdatagrid_2 As MisGrid) As System.Windows.Forms.BindingSource Implements IAdministradorRetenciones._CargarDataGrid
        Try
            CargardataInicial()
            With xdatagrid
                .Columns.Add("col0", "F/Emisión")
                .Columns.Add("col1", "Documento")
                .Columns.Add("col2", "Cliente")
                .Columns.Add("col3", "CI/RIF")
                .Columns.Add("col4", "Tasa")
                .Columns.Add("col5", "Retención")

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "documento"
                .Columns(2).DataPropertyName = "nombre"
                .Columns(3).DataPropertyName = "ci_rif"
                .Columns(4).DataPropertyName = "tasa_retencion"
                .Columns(5).DataPropertyName = "retencion"

                .DataSource = f_binding

                .Columns(0).Width = 100
                .Columns(1).Width = 150
                .Columns(3).Width = 110
                .Columns(4).Width = 100
                .Columns(5).Width = 100
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .Ocultar(7)
                AddHandler .CellFormatting, AddressOf MiFormato
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
                .Columns(1).DataPropertyName = "tipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "exento"
                .Columns(4).DataPropertyName = "base"
                .Columns(5).DataPropertyName = "impuesto"
                .Columns(6).DataPropertyName = "retencion"
                .Columns(7).DataPropertyName = "importe"
                .Columns(8).DataPropertyName = "estatus"

                .DataSource = f_binding_2

                .Columns(0).Width = 90
                .Columns(1).Width = 130
                .Columns(2).Width = 130
                .Columns(3).Width = 90
                .Columns(4).Width = 90
                .Columns(5).Width = 90
                .Columns(6).Width = 90
                .Columns(7).Width = 90
                .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .Ocultar(10)
                AddHandler .CellFormatting, AddressOf MiFormato2
            End With

            RaiseEvent ActualizarFicha()
            Return f_binding
        Catch ex As Exception
            Throw New Exception("RETENCIONES IVA VENTAS" + vbCrLf + "CARGAR DATAGRIDVIEW" + vbCrLf + ex.Message)
        End Try
    End Function

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 4 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Sub MiFormato2(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 3 And e.ColumnIndex <= 7 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Public ReadOnly Property _TituloVentana() As String Implements IAdministradorRetenciones._TituloVentana
        Get
            Return "Administrador De Retenciones De Ventas"
        End Get
    End Property

    Public ReadOnly Property _CantidadRegistros() As String Implements IAdministradorRetenciones._CantidadRegistros
        Get
            Return xtb_1.Rows.Count.ToString()
        End Get
    End Property

    Public ReadOnly Property _CantidadRegistrosRelacionados() As String Implements IAdministradorRetenciones._CantidadRegistrosRelacionados
        Get
            Return f_binding_2.Count.ToString
        End Get
    End Property

    Public ReadOnly Property _CargarComboTipoDocumento() As String() Implements IAdministradorRetenciones._CargarComboTipoDocumento
        Get
            Dim xlista As String() = {"Todos", "Ventas", "Nota Débito", "Nota Crédito"}
            Return xlista
        End Get
    End Property

    Public Sub _CargarComboBuscarPor(ByVal xcombo As MisControles.Controles.MisComboBox) Implements IAdministradorRetenciones._CargarComboBuscarPor
        With xcombo
            .DataSource = g_MiData.f_FichaClientes.f_Clientes.p_TipoBusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarCliente
        End With
    End Sub

    Public Function _BuscarAhora(ByVal xfilterdata As IAdministradorRetenciones._FilterData) As Boolean Implements IAdministradorRetenciones._BuscarAhora
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
            Throw New Exception("RETENCIONES IVA VENTAS" + vbCrLf + "BUSCAR AHORA" + vbCrLf + ex.Message)
        End Try
    End Function

    Public Function _AnularDocumento() As Boolean Implements IAdministradorRetenciones._AnularDocumento
        If f_binding.Current IsNot Nothing Then
            If MessageBox.Show("Estas Seguro De Querer Anular Esta Retencion ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                    Dim xficha As New FichaVentas

                    xficha.F_RetencionesIva.F_BuscarDocumento(xreg("auto"))
                    Dim xano_actual As Integer = g_MiData.p_FechaDelMotorBD.Year
                    Dim xmes_actual As Integer = g_MiData.p_FechaDelMotorBD.Month

                    If xficha.F_RetencionesIva.RegistroDato._AnoRelacion = xano_actual And xficha.F_RetencionesIva.RegistroDato._MesRelacion = xmes_actual Then
                        Dim _Doc_Anulados As New FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro
                        Dim xdetalle As String = ""
                        Dim xseg As Boolean = False

                        Dim xficha_anular As New AnularDocumento(New AnularDocumento_RetencionVenta("Retencion Iva Venta"))
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

                            g_MiData.f_FichaVentas.F_AnularRetencionIva(xficha.F_RetencionesIva.RegistroDato, _Doc_Anulados)
                            MessageBox.Show("Documento De Retencion Anulado Satisfactoriamente", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        Throw New Exception("ERROR... NO SE PUEDE ANULAR UN DOCUMENTO DE PERIODOS ANTERIORES, POR FAVOR VERIFIQUE")
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
                ActualizarData()
            End If
        End If
    End Function

    Sub ActualizarData()
        _BuscarAhora(xultimofiltro)
    End Sub

    Public Function _VisualizarDocumento() As Boolean Implements IAdministradorRetenciones._VisualizarDocumento
        If f_binding.Current IsNot Nothing Then
            Dim dts As New DataSet
            Dim dtb_empresa As New DataTable("empresa")
            Dim dtb_retenciones As New DataTable("retenciones_ventas")
            Dim dtb_retenciones_detalle As New DataTable("retenciones_ventas_detalle")

            Try
                Dim xreg As DataRow = CType(f_binding.Current, DataRowView).Row
                Dim xparam1 As SqlParameter = New SqlParameter("@auto", xreg("auto").ToString())
                Dim xparam2() As SqlParameter = {New SqlParameter("@auto_entidad", xreg("auto_entidad").ToString()), New SqlParameter("@comprobante_retencion", xreg("documento").ToString())}
                g_MiData.F_GetData(SELECT_DATAEMPRESA, dtb_empresa)
                dts.Tables.Add(dtb_empresa)

                g_MiData.F_GetData(SELECT_RETENCIONES_VENTAS, dtb_retenciones, xparam1)
                dts.Tables.Add(dtb_retenciones)
                If dtb_retenciones.Rows.Count = 0 Then
                    Throw New Exception("DOCUMENTO NO ENCONTRADO / FUE ANULADO POR OTRO USUARIO")
                End If

                g_MiData.F_GetData(SELECT_RETENCIONES_VENTAS_DETALLE, dtb_retenciones_detalle, xparam2)
                dts.Tables.Add(dtb_retenciones_detalle)

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "rep_planilla_retencion_iva.rpt"
                Dim xficha As New _Reportes(dts, xrep, Nothing)
                xficha.ShowDialog()
            Catch ex As Exception
                Throw New Exception("RETENCIONES IVA VENTAS" + vbCrLf + "VISUALIZAR DOCUMENTO" + vbCrLf + ex.Message)
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
            "from retenciones_ventas r join retenciones_ventas_detalle rd on r.auto=rd.auto " & _
            "where r.auto<>'' " + GetCondicionBusqueda(xultimofiltro) + "group by  r.fecha" & _
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

    Public Function _VisualizarRetenciones() As Boolean Implements IAdministradorRetenciones._VisualizarRetenciones
        Dim dts As New DataSet
        Dim dtb_empresa As New DataTable("empresa")
        Dim dtb_retenciones As New DataTable("retenciones_ventas")

        Try
            g_MiData.F_GetData(SELECT_DATAEMPRESA, dtb_empresa)
            dts.Tables.Add(dtb_empresa)

            g_MiData.F_GetData(SelectUltimoFiltro, dtb_retenciones)
            dts.Tables.Add(dtb_retenciones)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "rep_retenciones_ventas.rpt"
            Dim xficha As New _Reportes(dts, xrep, Nothing)
            xficha.ShowDialog()
        Catch ex As Exception
            Throw New Exception("RETENCIONES IVA VENTAS" + vbCrLf + "VISUALIZAR RETENCIONES" + vbCrLf + ex.Message)
        End Try
    End Function

    Public Event ActualizarFicha() Implements IAdministradorRetenciones.ActualizarFicha
End Class