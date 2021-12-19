Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema

Public Class PlantillaRetencionIva
    Dim xplantillaretencion_iva As IPlantillaRetencionIva
    Dim xcontroles As IPlantillaRetencionIva.Controles

    Property _Plantilla() As IPlantillaRetencionIva
        Get
            Return xplantillaretencion_iva
        End Get
        Set(ByVal value As IPlantillaRetencionIva)
            xplantillaretencion_iva = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaRetencionIva)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Plantilla = xplantilla
        AddHandler Me._Plantilla.ActualizarControles, AddressOf ActualizarPantallaControles
        xcontroles = New IPlantillaRetencionIva.Controles
    End Sub

    Sub Actualizar()
        Me.E_CIRIF.Text = xcontroles._Rif
        Me.E_NOMBRE.Text = xcontroles._Nombre
        Me.E_CODIGO.Text = xcontroles._Codigo
        Me.E_TOTAL_ITEMS.Text = String.Format("{0:#0}", xcontroles._ItemsEncontrados)
        Me.E_TOTAL_PLANILLA.Text = String.Format("{0:#0.00}", xcontroles._Importe)
        Me.E_DOC_A_PROCESAR.Text = String.Format("{0:#0}", xcontroles._ItemsProcesar)
        Me.MN_RETENCION.Text = String.Format("{0:#0.00}", xcontroles._TasaRetencionIva)

        If xcontroles._ItemsEncontrados > 0 Then
            Me.MCHKB_TODOS.Enabled = True
        Else
            Me.MCHKB_TODOS.Checked = False
            Me.MCHKB_TODOS.Enabled = False
        End If
    End Sub

    Sub ActualizarPantallaControles(ByRef xcontroles_ev As IPlantillaRetencionIva.Controles)
        xcontroles = xcontroles_ev
        Actualizar()
    End Sub

    Private Sub PlantillaRetencionIva_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If xcontroles._ItemsEncontrados > 0 Then
            If MessageBox.Show("Estas Seguro De Abandonar Y Perder Los Datos de Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub PlantillaRetencionIva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            Me.MT_BUSCAR.Text = ""
            Me.MT_BUSCAR.Select()
            Me.MT_BUSCAR.Focus()
        End If
    End Sub

    Private Sub PlantillaRetencionIva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub PlantillaRetencionIva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PlantillaRetencionIva_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializa()
            _Plantilla._CargarGrids(Me.MisGrid1, Me.MisGrid2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error *** ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub Inicializa()
        Actualizar()

        With Me.MCB_BUSQUEDA
            .DataSource = _Plantilla.p_TipoBusqueda
            .SelectedIndex = _Plantilla.p_OpcionPredeterminadaTipoBusqueda
        End With

        With MT_PLANILLA
            .Text = ""
            .MaxLength = 8
        End With

        With MN_RETENCION
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With

        With MF_EMISION
            .Value = Date.Today
        End With

        Me.Text = _Plantilla.p_TituloVentana
        With Me.MT_BUSCAR
            .Text = ""
            .Select()
            .Focus()
        End With

        Me.MCHKB_TODOS.Enabled = False
    End Sub

    Private Sub BT_BUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR.Click
        If Me.MT_BUSCAR.r_Valor <> "" Then
            _Plantilla._Bucar(Me.MT_BUSCAR.r_Valor, Me.MCB_BUSQUEDA.SelectedIndex)
        End If
        Me.MT_BUSCAR.Text = ""
        MT_BUSCAR.Select()
    End Sub

    Private Sub MCB_BUSQUEDA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSQUEDA.SelectedIndexChanged
        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()
    End Sub

    Private Sub LINK_FICHA_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_FICHA.LinkClicked
        _Plantilla.F_ConsultarFicha()
        IrInicio()
    End Sub

    Sub IrInicio()
        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()
        Me.MT_BUSCAR.Text = ""
        Me.Select()
    End Sub

    Private Sub MCHKB_TODOS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHKB_TODOS.CheckedChanged
        _Plantilla._SeleccionarTodos(Me.MCHKB_TODOS.Checked)
    End Sub

    Private Sub MN_RETENCION_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_RETENCION.LostFocus
        If Me.MN_RETENCION._Valor > 0 Then
            If xcontroles._TasaRetencionIva <> Me.MN_RETENCION._Valor Then
                _Plantilla._ActualizarTasaRetencion = Me.MN_RETENCION._Valor
            End If
        Else
            Me.MN_RETENCION.Text = String.Format("{0:#0.00}", xcontroles._TasaRetencionIva)
        End If
    End Sub

    Private Sub BT_LIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_LIMPIAR.Click
        If MessageBox.Show("Estas Seguro De Limpiar Toda La Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            _Plantilla._LimpiarTodo()
            Inicializa()
        End If
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If xcontroles._ItemsProcesar > 0 Then
            If Me.MT_PLANILLA.r_Valor <> "" Then
                If Me.MF_EMISION.r_Valor <= g_MiData.p_FechaDelMotorBD Then
                    If Me.MN_RETENCION._Valor = 75 Or Me.MN_RETENCION._Valor = 100 Then
                        If _Plantilla._ProcesarDocumento(Me.MF_EMISION.Value, Me.MT_PLANILLA.r_Valor) Then
                            MessageBox.Show("Documento Procesado Con Exito", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Inicializa()
                        End If
                    Else
                        MessageBox.Show("Error... Tasa Retencion A Aplicar Incorrecta. Verifique !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.MN_RETENCION.Select()
                        Me.MN_RETENCION.Focus()
                    End If
                Else
                    MessageBox.Show("Error... Fecha De Emision Incorrecta. Verifique !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MF_EMISION.Select()
                    Me.MF_EMISION.Focus()
                End If
            Else
                MessageBox.Show("Error... Falta Indicar El Numero De Planilla !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MT_PLANILLA.Select()
                Me.MT_PLANILLA.Focus()
            End If
        Else
            Me.MT_BUSCAR.Select()
            Me.MT_BUSCAR.Focus()
        End If
    End Sub

    Private Sub MF_EMISION_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_EMISION.ValueChanged
        Me.E_ANO.Text = Year(Me.MF_EMISION.Value)
        Me.E_MES.Text = Month(Me.MF_EMISION.Value).ToString.Trim.PadLeft(2, "0")
    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub
End Class

Public Interface IPlantillaRetencionIva
    Event ActualizarControles(ByRef xcont As Controles)

    Class Controles
        Private xitem_procesar As Integer
        Private xitem_encontrado As Integer
        Private ximporte As Decimal

        Private xnombre As String
        Private xrif As String
        Private xcodigo As String

        Private xtasa_retencion_iva As Decimal

        Property _TasaRetencionIva() As Decimal
            Get
                Return xtasa_retencion_iva
            End Get
            Set(ByVal value As Decimal)
                xtasa_retencion_iva = value
            End Set
        End Property

        Property _ItemsProcesar() As Integer
            Get
                Return xitem_procesar
            End Get
            Set(ByVal value As Integer)
                xitem_procesar = value
            End Set
        End Property

        Property _ItemsEncontrados() As Integer
            Get
                Return xitem_encontrado
            End Get
            Set(ByVal value As Integer)
                xitem_encontrado = value
            End Set
        End Property

        Property _Importe() As Decimal
            Get
                Return ximporte
            End Get
            Set(ByVal value As Decimal)
                ximporte = value
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

        Property _Rif() As String
            Get
                Return xrif
            End Get
            Set(ByVal value As String)
                xrif = value
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
            _Codigo = ""
            _Importe = 0
            _ItemsEncontrados = 0
            _ItemsProcesar = 0
            _Nombre = ""
            _Rif = ""
            _TasaRetencionIva = 75
        End Sub
    End Class

    Sub _CargarGrids(ByRef xgrid_1 As MisControles.Controles.MisGrid, ByRef xgrid_2 As MisControles.Controles.MisGrid)
    Sub _Bucar(ByVal xtexto As String, ByVal xseleccion As Integer)
    Function F_ConsultarFicha() As Boolean
    Sub _SeleccionarTodos(ByVal xopc As Boolean)
    Sub _LimpiarTodo()
    Function _ProcesarDocumento(ByVal xfecha As Date, ByVal xplanilla As String) As Boolean

    ReadOnly Property p_TipoBusqueda() As String()
    ReadOnly Property p_OpcionPredeterminadaTipoBusqueda() As Integer
    ReadOnly Property p_TituloVentana() As String
    Property _ActualizarTasaRetencion() As Decimal
End Interface

Public Class RetencionIva_Venta
    Implements IPlantillaRetencionIva

    Dim xtb_principal As DataTable
    Dim xbs_principal As BindingSource
    Dim xtb_secundaria As DataTable

    Dim xgrid1 As MisControles.Controles.MisGrid
    Dim xgrid2 As MisControles.Controles.MisGrid

    Dim xcliente As FichaClientes
    Dim _ActivarTodo As Boolean
    Dim xcontroles As IPlantillaRetencionIva.Controles

    Dim xactualizar_tasa_retencion As Decimal

    Property _MisControles() As IPlantillaRetencionIva.Controles
        Get
            Return xcontroles
        End Get
        Set(ByVal value As IPlantillaRetencionIva.Controles)
            xcontroles = value
        End Set
    End Property

    Sub New()
        xtb_principal = New DataTable
        xbs_principal = New BindingSource(xtb_principal, "")

        xtb_secundaria = New DataTable
        xtb_secundaria.Columns.Add("c0", GetType(String))
        xtb_secundaria.Columns.Add("c1", GetType(Date))
        xtb_secundaria.Columns.Add("c2", GetType(Decimal))
        xtb_secundaria.Columns.Add("c3", GetType(Decimal))
        xtb_secundaria.Columns.Add("c4", GetType(Decimal))
        xtb_secundaria.Columns.Add("c5", GetType(Decimal))
        xtb_secundaria.Columns.Add("c6", GetType(Decimal))
        xtb_secundaria.Columns.Add("c7", GetType(String))
        xtb_secundaria.Columns.Add("c8", GetType(Integer))
        xtb_secundaria.Columns.Add("c9", GetType(Decimal))
        xtb_secundaria.Columns.Add("c10", GetType(String))
        xtb_secundaria.Columns.Add("c11", GetType(String))
        xtb_secundaria.Columns.Add("c12", GetType(String))

        xcliente = New FichaClientes
        _MisControles = New IPlantillaRetencionIva.Controles

        AddHandler xtb_secundaria.RowChanging, AddressOf ActualizarTablaSecundaria

        _ActivarTodo = False
    End Sub

    Sub ActualizarTabla_2()
        Dim xr As Integer = 0
        Dim xt As Decimal = 0

        For Each x As DataRow In xtb_secundaria.Rows
            If x.RowState <> DataRowState.Deleted Then
                xr += 1
                xt += (x(6) * x(8))
            End If
        Next
        xcontroles._Importe = xt
        xcontroles._ItemsProcesar = xr
        RaiseEvent ActualizarControles(xcontroles)
    End Sub

    Sub ActualizarTablaSecundaria(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        ActualizarTabla_2()
    End Sub

    Public Function F_ConsultarFicha() As Boolean Implements IPlantillaRetencionIva.F_ConsultarFicha
        If xcliente.f_Clientes.RegistroDato.r_Automatico <> "" Then
            Try
                Dim xficha As New FichaCliente(xcliente.f_Clientes.RegistroDato.r_Automatico)
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                Throw New Exception("RETENCIONES IVA VENTAS" + vbCrLf + "CONSULTAR FICHA DEL CLIENTE" + vbCrLf + ex.Message)
            End Try
        End If
    End Function

    Public ReadOnly Property p_OpcionPredeterminadaTipoBusqueda() As Integer Implements IPlantillaRetencionIva.p_OpcionPredeterminadaTipoBusqueda
        Get
            Return g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarCliente
        End Get
    End Property

    Public ReadOnly Property p_TipoBusqueda() As String() Implements IPlantillaRetencionIva.p_TipoBusqueda
        Get
            Return g_MiData.f_FichaClientes.f_Clientes.p_TipoBusqueda
        End Get
    End Property

    Public ReadOnly Property p_TituloVentana() As String Implements IPlantillaRetencionIva.p_TituloVentana
        Get
            Return "Documento De Retención En Ventas"
        End Get
    End Property

    Public Sub _CargarGrids(ByRef xgrid_1 As MisControles.Controles.MisGrid, ByRef xgrid_2 As MisControles.Controles.MisGrid) Implements IPlantillaRetencionIva._CargarGrids
        CargarData("")

        Dim xcheckdatagrid As New DataGridViewCheckBoxColumn
        With xcheckdatagrid
            .Name = "*"
            .Width = 20
            .ReadOnly = False
        End With
        With xgrid_1
            .Columns.Add("col0", "Tipo")
            .Columns.Add("col1", "Documento")
            .Columns.Add("col2", "Fecha")
            .Columns.Add("col3", "Total")
            .Columns.Add(xcheckdatagrid)

            .DataSource = xbs_principal

            .Columns(0).DataPropertyName = "tipo"
            .Columns(1).DataPropertyName = "documento"
            .Columns(2).DataPropertyName = "fecha"
            .Columns(3).DataPropertyName = "total"
            .Columns(4).DataPropertyName = "*"
            .Columns(4).ReadOnly = False

            .Columns(0).Width = 90
            .Columns(1).Width = 100
            .Columns(2).Width = 80
            .Columns(3).Width = 80
            .Columns(4).Visible = 20
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Ocultar(6)
            AddHandler .CellFormatting, AddressOf AplicarFormato1
            AddHandler .CellDoubleClick, AddressOf VerificarRegistro
        End With
        xgrid1 = xgrid_1

        With xgrid_2
            .Columns.Add("col0", "Documento")
            .Columns.Add("col1", "Fecha")
            .Columns.Add("col2", "Total")
            .Columns.Add("col3", "Exento")
            .Columns.Add("col4", "Base")
            .Columns.Add("col5", "Iva")
            .Columns.Add("col6", "Retención")

            .DataSource = xtb_secundaria

            .Columns(0).DataPropertyName = "c0"
            .Columns(1).DataPropertyName = "c1"
            .Columns(2).DataPropertyName = "c2"
            .Columns(3).DataPropertyName = "c3"
            .Columns(4).DataPropertyName = "c4"
            .Columns(5).DataPropertyName = "c5"
            .Columns(6).DataPropertyName = "c6"

            .Columns(0).Width = 85
            .Columns(1).Width = 70
            .Columns(2).Width = 90
            .Columns(3).Width = 80
            .Columns(4).Width = 90
            .Columns(5).Width = 85
            .Columns(6).Width = 90
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Ocultar(8)
            AddHandler .CellFormatting, AddressOf AplicarFormato2
        End With
        xgrid2 = xgrid_2
    End Sub

    Sub VerificarRegistro(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If _ActivarTodo = False Then
            If xbs_principal.Current IsNot Nothing Then
                If e.RowIndex <> -1 Then
                    If e.ColumnIndex = 4 Then
                        If xgrid1.CurrentCell.Value = 0 Then
                            xgrid1.CurrentCell.Value = 1
                        Else
                            xgrid1.CurrentCell.Value = 0
                        End If
                        xgrid1.EndEdit()
                        CargarQuitarRegistro_Tabla_2(xbs_principal.Current)
                    End If
                End If
            End If
        End If
    End Sub

    Sub CargarQuitarRegistro_Tabla_2(ByVal xobject As Object)
        Dim xenc As Boolean = False
        Dim xregistro As DataRow = CType(xobject, DataRowView).Row

        For Each xr As DataRow In xtb_secundaria.Rows
            If xr("c7").ToString.Trim = xregistro("auto").ToString.Trim Then
                xtb_secundaria.Rows.Remove(xr)
                xenc = True
                Exit For
            End If
        Next
        If xenc = False Then
            Dim xrow As DataRow = xtb_secundaria.NewRow
            Dim xrt As Decimal = xregistro(8) * xcontroles._TasaRetencionIva / 100

            xrow(0) = xregistro(1)
            xrow(1) = xregistro(2)
            xrow(2) = xregistro(3)
            xrow(3) = xregistro(6)
            xrow(4) = xregistro(7)
            xrow(5) = xregistro(8)
            xrow(6) = Decimal.Round(xrt, 2, MidpointRounding.AwayFromZero)
            xrow(7) = xregistro(5)
            xrow(8) = IIf(xregistro("xtipo").ToString.Trim <> "03", 1, -1)
            xrow(9) = xregistro(10)
            xrow(10) = xregistro(11)
            xrow(11) = xregistro(12)
            xrow(12) = xregistro(13)

            xtb_secundaria.Rows.Add(xrow)
            xtb_secundaria.AcceptChanges()
        End If
    End Sub

    Sub AplicarFormato1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If xgrid1.Rows(e.RowIndex).Cells("xtipo").Value.ToString.Trim = "03" Then
            xgrid1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
        If e.ColumnIndex = 3 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Sub AplicarFormato2(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If xtb_secundaria.Rows(e.RowIndex)(8) = -1 Then
            xgrid2.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
        If e.ColumnIndex >= 2 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Sub CargarData(ByVal xauto As String)
        Dim xsentencia As String = ""
        Dim xparam As SqlParameter
        Try
            xsentencia = "select (case tipo when '01' then 'FACTURA' when '02' then 'N/DEBITO' " & _
                             "when '03' then 'N/CREDITO' end) tipo, documento, fecha, total, 0 " & _
                             ", auto, exento, base, impuesto, cast((impuesto*0.75) as decimal(10,2)) retencion " & _
                             ", tasa1, control, aplica,tipo as xtipo from ventas where auto_entidad=@auto_entidad and " & _
                             "tipo in ('01','02','03') and estatus='0' and comprobante_retencion = '' and impuesto>0 " & _
                             "order by fecha desc"
            xparam = New SqlParameter("@auto_entidad", xauto)
            g_MiData.F_GetData(xsentencia, xtb_principal, xparam)
        Catch ex As Exception
            Throw New Exception("CARGAR DATA:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub LimpiarTodo()
        Me.xtb_principal.Rows.Clear()
        Me.xtb_secundaria.Rows.Clear()
        Me.xcliente.f_Clientes.RegistroDato.M_LimpiarRegistro()

        _MisControles._Codigo = xcliente.f_Clientes.RegistroDato.r_CodigoCliente
        _MisControles._Nombre = xcliente.f_Clientes.RegistroDato.r_NombreRazonSocial
        _MisControles._Rif = xcliente.f_Clientes.RegistroDato.r_CiRif
        _MisControles._ItemsEncontrados = 0
        _MisControles._ItemsProcesar = 0
        _MisControles._Importe = 0
        _MisControles._TasaRetencionIva = 75

        ActualizarTabla_2()
    End Sub

    Public Sub _Bucar(ByVal xtexto As String, ByVal xseleccion As Integer) Implements IPlantillaRetencionIva._Bucar
        Dim xseg As Boolean
        If xtb_principal.Rows.Count > 0 Then
            Dim xresultado As DialogResult = MessageBox.Show("Estas Seguro de Realizar la Busqueda?, se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                xseg = True
                LimpiarTodo()
            End If
        Else
            xseg = True
        End If

        If xseg Then
            Dim xsentencia As String = ""
            Dim xp1 As SqlParameter
            Dim xbuscar As String = ""
            Try
                Select Case xseleccion
                    Case 0 : xsentencia = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where nombre like @data order by nombre"
                    Case 1 : xsentencia = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where ci_rif like @data order by nombre"
                    Case 2 : xsentencia = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where codigo like @data order by nombre"
                End Select
                If xtexto.Substring(0, 1) = "*" Then
                    xbuscar = "%" + xtexto.Substring(1)
                Else
                    xbuscar = xtexto
                End If

                xp1 = New SqlParameter("@data", xbuscar + "%")
                Dim xficha As New Plantilla_2(New BusquedaCliente, xsentencia, xp1)
                With xficha
                    AddHandler .EnviarAuto, AddressOf CapturaCliente
                    .ShowDialog()
                End With
            Catch ex As Exception
                Throw New Exception("RETENCIONES IVA VENTAS" + vbCrLf + "BUSQUEDA CLIENTE" + vbCrLf + ex.Message)
            End Try
        End If
    End Sub

    Sub CapturaCliente(ByVal xauto As String)
        Try
            xcliente.F_BuscarCliente(xauto)
            CargarData(xauto)

            _MisControles._Codigo = xcliente.f_Clientes.RegistroDato.r_CodigoCliente
            _MisControles._Nombre = xcliente.f_Clientes.RegistroDato.r_NombreRazonSocial
            _MisControles._Rif = xcliente.f_Clientes.RegistroDato.r_CiRif
            _MisControles._ItemsEncontrados = xtb_principal.Rows.Count
            _MisControles._ItemsProcesar = 0
            _MisControles._Importe = 0
            _MisControles._TasaRetencionIva = 75
            If xcliente.f_Clientes.RegistroDato.r_RetencionIva = 100 Then
                _MisControles._TasaRetencionIva = xcliente.f_Clientes.RegistroDato.r_RetencionIva
            End If
            RaiseEvent ActualizarControles(_MisControles)
        Catch ex As Exception
            Throw New Exception("RETENCIONES IVA VENTAS" + vbCrLf + "CARGAR DATA" + ex.Message)
        End Try
    End Sub

    Public Event ActualizarControles(ByRef xcont As IPlantillaRetencionIva.Controles) Implements IPlantillaRetencionIva.ActualizarControles

    Public Sub _SeleccionarTodos(ByVal xopc As Boolean) Implements IPlantillaRetencionIva._SeleccionarTodos
        _ActivarTodo = True
        Me.xtb_secundaria.Rows.Clear()
        If xopc Then
            For Each x As DataGridViewRow In xgrid1.Rows
                x.Cells(4).Value = True
                xbs_principal.Position = x.Index
                CargarQuitarRegistro_Tabla_2(xbs_principal.Current)
            Next
        Else
            For Each x As DataGridViewRow In xgrid1.Rows
                x.Cells(4).Value = False
                xbs_principal.Position = x.Index
            Next
            ActualizarTabla_2()
        End If
        _ActivarTodo = False
    End Sub

    Public Property _ActualizarTasaRetencion() As Decimal Implements IPlantillaRetencionIva._ActualizarTasaRetencion
        Get
            Return xactualizar_tasa_retencion
        End Get
        Set(ByVal value As Decimal)
            xcontroles._TasaRetencionIva = value
            For Each xrow As DataRow In xtb_secundaria.Rows
                Dim xrt As Decimal = xrow(5) * xcontroles._TasaRetencionIva / 100
                xrow(6) = Decimal.Round(xrt, 2, MidpointRounding.AwayFromZero)
            Next
        End Set
    End Property

    Public Sub _LimpiarTodo() Implements IPlantillaRetencionIva._LimpiarTodo
        LimpiarTodo()
    End Sub

    Public Function _ProcesarDocumento(ByVal xfecha As Date, ByVal xplanilla As String) As Boolean Implements IPlantillaRetencionIva._ProcesarDocumento
        Try
            Dim encabezado As New FichaVentas.V_RetencionesIva.AgregarRetencionIva
            Dim xretenciones_detalle As New List(Of FichaVentas.V_RetencionesIvaDetalle.AgregarRetencionIvaDetalle)

            g_MiData.f_FichaCobradores.F_BuscarCobrador(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloClientes._AutoCobrador_ARegistrar_PorDefecto)

            For Each dr As DataRow In xtb_secundaria.Rows
                Dim xdetalle As New FichaVentas.V_RetencionesIvaDetalle.AgregarRetencionIvaDetalle

                With xdetalle
                    ._AutoDocumento = dr(7)
                    ._NumeroDocumento = dr(0)
                    ._FechaEmision = dr(1)
                    ._MontoExento = Decimal.Round((dr(3) * dr(8)), 2, MidpointRounding.AwayFromZero)
                    ._MontoBase = Decimal.Round((dr(4) * dr(8)), 2, MidpointRounding.AwayFromZero)
                    ._MontoImpuesto = Decimal.Round((dr(5) * dr(8)), 2, MidpointRounding.AwayFromZero)
                    ._MontoTotal = Decimal.Round((dr(2) * dr(8)), 2, MidpointRounding.AwayFromZero)
                    ._TasaRetencion = xcontroles._TasaRetencionIva
                    ._MontoRetencion = Decimal.Round((dr(6) * dr(8)), 2, MidpointRounding.AwayFromZero)
                    ._NumeroControlFiscal = dr(10)
                    ._DocumentoAplica = dr(11)
                    ._TipoDocumento = dr(12)
                    ._Tasa = dr(9)
                    ._CiRifCliente = xcliente.f_Clientes.RegistroDato.r_CiRif
                End With
                xretenciones_detalle.Add(xdetalle)
            Next

            Dim x1 As Decimal = 0
            Dim x2 As Decimal = 0
            Dim x3 As Decimal = 0
            Dim x4 As Decimal = 0
            Dim x5 As Decimal = 0
            With encabezado
                ._FechaRelacion = g_MiData.p_FechaDelMotorBD
                ._NumeroPlanillaRetencion = xplanilla
                ._FechaEmision = xfecha
                ._NombreCliente = xcliente.f_Clientes.RegistroDato.r_NombreRazonSocial
                ._DirFiscalCliente = xcliente.f_Clientes.RegistroDato.r_DirFiscal
                ._CiRifCliente = xcliente.f_Clientes.RegistroDato.r_CiRif
                ._CodigoCliente = xcliente.f_Clientes.RegistroDato.r_CodigoCliente
                ._AutoCliente = xcliente.f_Clientes.RegistroDato.r_Automatico
                ._TipoDocumentoRetencion = TipoDocumentoRetencion.IVA
                ._TasaRetencion = xcontroles._TasaRetencionIva
                ._AutoUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._AutoUsuario
                ._NombreUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario
                ._AutoCobrador = g_MiData.f_FichaCobradores.f_Cobrador.RegistroDato.r_Automatico
                ._NombreCobrador = g_MiData.f_FichaCobradores.f_Cobrador.RegistroDato.r_NombreCobrador

                For Each xr As DataRow In xtb_secundaria.Rows
                    x1 += (xr(3) * xr(8))
                    x2 += (xr(4) * xr(8))
                    x3 += (xr(5) * xr(8))
                    x4 += (xr(2) * xr(8))
                    x5 += (xr(6) * xr(8))
                Next

                ._MontoExento = Decimal.Round(x1, 2, MidpointRounding.AwayFromZero)
                ._MontoBase = Decimal.Round(x2, 2, MidpointRounding.AwayFromZero)
                ._MontoImpuesto = Decimal.Round(x3, 2, MidpointRounding.AwayFromZero)
                ._MontoTotalGeneral = Decimal.Round(x4, 2, MidpointRounding.AwayFromZero)
                ._MontoRetencion = Decimal.Round(x5, 2, MidpointRounding.AwayFromZero)
            End With

            If xtb_secundaria.Rows.Count > g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_Retenciones Then
                Throw New Exception("Error Al Procesar Retencion" + vbCrLf + "Ficha Supera El Numero De Maximo De Renglones Permitos")
            Else
                If MessageBox.Show("Estas Seguro De Procesar Esta Planilla ?", "*** Mensaje De Error ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    g_MiData.f_FichaVentas.F_GrabarRetencionIva(encabezado, xretenciones_detalle)
                    LimpiarTodo()
                    Return True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class
