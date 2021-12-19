Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema

Public Class PlantillaRetencionIvaCompras
    Dim xplantillaretencion_iva As IPlantillaRetencionIvaCompras
    Dim xcontroles As IPlantillaRetencionIvaCompras.Controles

    Property _Plantilla() As IPlantillaRetencionIvaCompras
        Get
            Return xplantillaretencion_iva
        End Get
        Set(ByVal value As IPlantillaRetencionIvaCompras)
            xplantillaretencion_iva = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaRetencionIvaCompras)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Plantilla = xplantilla
        AddHandler Me._Plantilla.ActualizarControles, AddressOf ActualizarPantallaControles
        xcontroles = New IPlantillaRetencionIvaCompras.Controles
    End Sub

    Sub Actualizar()
        Me.E_CIRIF.Text = xcontroles._Rif
        Me.E_NOMBRE.Text = xcontroles._Nombre
        Me.E_CODIGO.Text = xcontroles._Codigo
        Me.E_TOTAL_ITEMS.Text = String.Format("{0:#0}", xcontroles._ItemsEncontrados)
        Me.E_TOTAL_PLANILLA.Text = String.Format("{0:#0.00}", xcontroles._Importe)
        Me.E_DOC_A_PROCESAR.Text = String.Format("{0:#0}", xcontroles._ItemsProcesar)
        Me.MN_RETENCION.Text = String.Format("{0:#0.00}", xcontroles._TasaRetencionIva)
        Me.E_PLANILLA.Text = g_MiData.f_FichaCompras.F_ProximaPlanillaRetencionGenerar

        If xcontroles._ItemsEncontrados > 0 Then
            Me.MCHKB_TODOS.Enabled = True
        Else
            Me.MCHKB_TODOS.Checked = False
            Me.MCHKB_TODOS.Enabled = False
        End If
    End Sub

    Sub ActualizarPantallaControles(ByRef xcontroles_ev As IPlantillaRetencionIvaCompras.Controles)
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

        With MN_RETENCION
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With

        LB_FECHA.Text = g_MiData.p_FechaDelMotorBD.ToString("dd/MM/yyyy")

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
            If (Me.MN_RETENCION._Valor = 75) Or (Me.MN_RETENCION._Valor = 100) Then
                If _Plantilla._ProcesarDocumento() Then
                    MessageBox.Show("Documento Procesado Con Exito", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Inicializa()
                End If
            Else
                MessageBox.Show("Error... Tasa Retencion A Aplicar Incorrecta. Verifique !!!", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MN_RETENCION.Select()
                Me.MN_RETENCION.Focus()
            End If
        Else
            Me.MT_BUSCAR.Select()
            Me.MT_BUSCAR.Focus()
        End If
    End Sub

    Private Sub PlantillaRetencionIvaCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IPlantillaRetencionIvaCompras
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
    Function _ProcesarDocumento() As Boolean

    ReadOnly Property p_TipoBusqueda() As String()
    ReadOnly Property p_OpcionPredeterminadaTipoBusqueda() As Integer
    ReadOnly Property p_TituloVentana() As String
    Property _ActualizarTasaRetencion() As Decimal
End Interface

Public Class RetencionIva_Compra
    Implements IPlantillaRetencionIvaCompras

    Dim xtb_principal As DataTable
    Dim xbs_principal As BindingSource
    Dim xtb_secundaria As DataTable

    Dim xgrid1 As MisControles.Controles.MisGrid
    Dim xgrid2 As MisControles.Controles.MisGrid

    Dim xproveedor As FichaProveedores
    Dim _ActivarTodo As Boolean
    Dim xcontroles As IPlantillaRetencionIvaCompras.Controles

    Dim xactualizar_tasa_retencion As Decimal

    Property _MisControles() As IPlantillaRetencionIvaCompras.Controles
        Get
            Return xcontroles
        End Get
        Set(ByVal value As IPlantillaRetencionIvaCompras.Controles)
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
        xtb_secundaria.Columns.Add("c10", GetType(Decimal))
        xtb_secundaria.Columns.Add("c11", GetType(Decimal))
        xtb_secundaria.Columns.Add("c12", GetType(Decimal))
        xtb_secundaria.Columns.Add("c13", GetType(Decimal))
        xtb_secundaria.Columns.Add("c14", GetType(Decimal))
        xtb_secundaria.Columns.Add("c15", GetType(Decimal))
        xtb_secundaria.Columns.Add("c16", GetType(Decimal))
        xtb_secundaria.Columns.Add("c17", GetType(Decimal))
        xtb_secundaria.Columns.Add("c18", GetType(String))
        xtb_secundaria.Columns.Add("c19", GetType(String))
        xtb_secundaria.Columns.Add("c20", GetType(String))
        xtb_secundaria.Columns.Add("c21", GetType(String))
        xtb_secundaria.Columns.Add("c22", GetType(String))

        xproveedor = New FichaProveedores
        _MisControles = New IPlantillaRetencionIvaCompras.Controles

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

    Public Function F_ConsultarFicha() As Boolean Implements IPlantillaRetencionIvaCompras.F_ConsultarFicha
        If xproveedor.f_Proveedor.RegistroDato._Automatico <> "" Then
            Try
                Dim xficha As New FichaProveedor(xproveedor.f_Proveedor.RegistroDato._Automatico)
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                Throw New Exception("RETENCIONES IVA COMPRAS" + vbCrLf + "CONSULTAR FICHA DEL CLIENTE" + vbCrLf + ex.Message)
            End Try
        End If
    End Function

    Public ReadOnly Property p_OpcionPredeterminadaTipoBusqueda() As Integer Implements IPlantillaRetencionIvaCompras.p_OpcionPredeterminadaTipoBusqueda
        Get
            Return g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProveedor
        End Get
    End Property

    Public ReadOnly Property p_TipoBusqueda() As String() Implements IPlantillaRetencionIvaCompras.p_TipoBusqueda
        Get
            Return g_MiData.f_FichaProveedores.f_Proveedor.p_TipoBusqueda
        End Get
    End Property

    Public ReadOnly Property p_TituloVentana() As String Implements IPlantillaRetencionIvaCompras.p_TituloVentana
        Get
            Return "Documento De Retención En Compras"
        End Get
    End Property

    Public Sub _CargarGrids(ByRef xgrid_1 As MisControles.Controles.MisGrid, ByRef xgrid_2 As MisControles.Controles.MisGrid) Implements IPlantillaRetencionIvaCompras._CargarGrids
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

            .Columns(0).Width = 80
            .Columns(1).Width = 100
            .Columns(2).Width = 70
            .Columns(3).Width = 100
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

            .Columns(0).Width = 90
            .Columns(1).Width = 70
            .Columns(2).Width = 90
            .Columns(3).Width = 80
            .Columns(4).Width = 90
            .Columns(5).Width = 80
            .Columns(6).Width = 80
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Ocultar(8)
            AddHandler .CellFormatting, AddressOf AplicarFormato2
        End With
        xgrid2 = xgrid_2
    End Sub

    Sub VerificarRegistro(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If _ActivarTodo = False Then
            If xbs_principal.Current IsNot Nothing Then
                If e.ColumnIndex = 4 And e.RowIndex <> -1 Then
                    If xgrid1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red Then
                    Else
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
            If Not IsDBNull(xregistro(24)) Then
                xrow(3) = xregistro(6) + xregistro(24)
            Else
                xrow(3) = xregistro(6)
            End If
            xrow(4) = xregistro(7)
            xrow(5) = xregistro(8)
            xrow(6) = Decimal.Round(xrt, 2, MidpointRounding.AwayFromZero)
            xrow(7) = xregistro(5)
            xrow(8) = IIf(xregistro("xtipo").ToString.Trim <> "03", 1, -1)
            xrow(9) = xregistro(10)
            xrow(10) = xregistro(11)
            xrow(11) = xregistro(12)
            xrow(12) = xregistro(13)
            xrow(13) = xregistro(14)
            xrow(14) = xregistro(15)
            xrow(15) = xregistro(16)
            xrow(16) = xregistro(17)
            xrow(17) = xregistro(18)
            xrow(18) = xregistro(19)
            xrow(19) = xregistro(20)
            xrow(20) = xregistro(21)
            xrow(21) = xregistro(22)
            xrow(22) = xregistro(23)

            xtb_secundaria.Rows.Add(xrow)
            xtb_secundaria.AcceptChanges()

            If xtb_principal.Select("n_serieaplica='" + xregistro(22).ToString.Trim + "' and aplica='" + xregistro(1).ToString.Trim + "'").Count > 0 Then
                Dim xrow_nc As DataRow() = xtb_principal.Select("n_serieaplica='" + xregistro(22) + "' and aplica='" + xregistro(1) + "'")
                For Each xr1 As DataRow In xrow_nc
                    Dim xr As DataRow = xtb_secundaria.NewRow
                    Dim xrt1 As Decimal = xr1(8) * xcontroles._TasaRetencionIva / 100

                    xr(0) = xr1(1)
                    xr(1) = xr1(2)
                    xr(2) = xr1(3)
                    xr(3) = xr1(6)
                    xr(4) = xr1(7)
                    xr(5) = xr1(8)
                    xr(6) = Decimal.Round(xrt1, 2, MidpointRounding.AwayFromZero)
                    xr(7) = xr1(5)
                    xr(8) = IIf(xr1("xtipo").ToString.Trim <> "03", 1, -1)
                    xr(9) = xr1(10)
                    xr(10) = xr1(11)
                    xr(11) = xr1(12)
                    xr(12) = xr1(13)
                    xr(13) = xr1(14)
                    xr(14) = xr1(15)
                    xr(15) = xr1(16)
                    xr(16) = xr1(17)
                    xr(17) = xr1(18)
                    xr(18) = xr1(19)
                    xr(19) = xr1(20)
                    xr(20) = xr1(21)
                    xr(21) = xr1(22)
                    xr(22) = xr1(23)

                    xtb_secundaria.Rows.Add(xr)
                    xtb_secundaria.AcceptChanges()
                Next
            End If
        Else
            If xtb_secundaria.Select("c22='" + xregistro(22).ToString.Trim + "' and c19='" + xregistro(1).ToString.Trim + "'").Count > 0 Then
                For xcont As Integer = 0 To xtb_secundaria.Select("c22='" + xregistro(22).ToString.Trim + "' and c19='" + xregistro(1).ToString.Trim + "'").Count
                    For Each xr As DataRow In xtb_secundaria.Rows
                        If xr(22).ToString.Trim = xregistro(22).ToString.Trim And xr(19).ToString.Trim = xregistro(1).ToString.Trim Then
                            xtb_secundaria.Rows.Remove(xr)
                            Exit For
                        End If
                    Next
                Next
            End If
        End If
    End Sub

    Sub AplicarFormato1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 3 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If

        Dim xdoc As String = ""
        Dim xserie As String = ""
        xdoc = xgrid1.Rows(e.RowIndex).Cells(25).Value.ToString().Trim
        xserie = xgrid1.Rows(e.RowIndex).Cells(28).Value.ToString().Trim

        If xdoc <> "" Then 'ES N/C
            If xtb_principal.Select("DOCUMENTO='" + xdoc + "' and n_serie='" + xserie + "'").Count() > 0 Then
                xgrid1.Rows(e.RowIndex).Cells(4).ReadOnly = True
                xgrid1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
            End If
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
        Dim xparam1 As SqlParameter
        Dim xparam2 As SqlParameter
        Dim xparam3 As SqlParameter
        Try
            xsentencia = "select (case tipo when '01' then 'COMPRA' else '' end) tipo, documento, fecha, total, 0 " & _
                             ", auto, exento, base,impuesto,cast((impuesto*0.75) as decimal(18,2)) retencion " & _
                             ", base1,base2,base3, impuesto1,impuesto2,impuesto3,tasa1,tasa2,tasa3, control " & _
                             ", aplica,tipo as xtipo,n_serie,n_serieaplica, n_montoimplicor from compras where auto_entidad=@auto_entidad and " & _
                             "tipo in ('01','02','03') and estatus='0' and comprobante_retencion = '' and impuesto>0 and " & _
                             "ano_relacion=@ano_relacion and mes_relacion=@mes_relacion and n_periodo = @periodo " & _
                             "order by fecha desc"
            xparam = New SqlParameter("@auto_entidad", xauto)
            xparam1 = New SqlParameter("@ano_relacion", g_MiData.p_FechaDelMotorBD.Year.ToString)
            xparam2 = New SqlParameter("@mes_relacion", g_MiData.p_FechaDelMotorBD.Month.ToString.Trim.PadLeft(2, "0"))
            xparam3 = New SqlParameter("@periodo", RetornarPeriodo(g_MiData.p_FechaDelMotorBD))
            g_MiData.F_GetData(xsentencia, xtb_principal, xparam, xparam1, xparam2, xparam3)

        Catch ex As Exception
            Throw New Exception("CARGAR DATA:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub LimpiarTodo()
        Me.xtb_principal.Rows.Clear()
        Me.xtb_secundaria.Rows.Clear()
        Me.xproveedor.f_Proveedor.RegistroDato.LimpiarRegistro()

        _MisControles._Codigo = xproveedor.f_Proveedor.RegistroDato._CodigoProveedor
        _MisControles._Nombre = xproveedor.f_Proveedor.RegistroDato._NombreRazonSocial
        _MisControles._Rif = xproveedor.f_Proveedor.RegistroDato._CiRif
        _MisControles._ItemsEncontrados = 0
        _MisControles._ItemsProcesar = 0
        _MisControles._Importe = 0
        _MisControles._TasaRetencionIva = 75

        ActualizarTabla_2()
    End Sub

    Public Sub _Bucar(ByVal xtexto As String, ByVal xseleccion As Integer) Implements IPlantillaRetencionIvaCompras._Bucar
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
                    Case 0 : xsentencia = "select nombre nom, telefono_1 tel, celular_1 cel, * from proveedores where nombre like @data order by nombre"
                    Case 1 : xsentencia = "select nombre nom, telefono_1 tel, celular_1 cel, * from proveedores where ci_rif like @data order by nombre"
                    Case 2 : xsentencia = "select nombre nom, telefono_1 tel, celular_1 cel, * from proveedores where codigo like @data order by nombre"
                End Select
                If xtexto.Substring(0, 1) = "*" Then
                    xbuscar = "%" + xtexto.Substring(1)
                Else
                    xbuscar = xtexto
                End If

                xp1 = New SqlParameter("@data", xbuscar + "%")
                Dim xficha As New Plantilla_2(New BusquedaProveedor, xsentencia, xp1)
                With xficha
                    AddHandler .EnviarAuto, AddressOf CapturaProveedor
                    .ShowDialog()
                End With
            Catch ex As Exception
                Throw New Exception("RETENCIONES IVA COMPRAS" + vbCrLf + "BUSQUEDA PROVEEDOR" + vbCrLf + ex.Message)
            End Try
        End If
    End Sub

    Sub CapturaProveedor(ByVal xauto As String)
        Try
            xproveedor.F_BuscarProveedor(xauto)
            CargarData(xauto)

            _MisControles._Codigo = xproveedor.f_Proveedor.RegistroDato._CodigoProveedor
            _MisControles._Nombre = xproveedor.f_Proveedor.RegistroDato._NombreRazonSocial
            _MisControles._Rif = xproveedor.f_Proveedor.RegistroDato._CiRif
            _MisControles._ItemsEncontrados = xtb_principal.Select("xtipo='01'").Count
            _MisControles._ItemsProcesar = 0
            _MisControles._Importe = 0
            _MisControles._TasaRetencionIva = xproveedor.f_Proveedor.RegistroDato._TasaRetencionIva

            RaiseEvent ActualizarControles(_MisControles)
        Catch ex As Exception
            Throw New Exception("RETENCIONES IVA COMPRAS" + vbCrLf + "CARGAR DATA" + ex.Message)
        End Try
    End Sub

    Public Event ActualizarControles(ByRef xcont As IPlantillaRetencionIvaCompras.Controles) Implements IPlantillaRetencionIvaCompras.ActualizarControles

    Public Sub _SeleccionarTodos(ByVal xopc As Boolean) Implements IPlantillaRetencionIvaCompras._SeleccionarTodos
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

    Public Property _ActualizarTasaRetencion() As Decimal Implements IPlantillaRetencionIvaCompras._ActualizarTasaRetencion
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

    Public Sub _LimpiarTodo() Implements IPlantillaRetencionIvaCompras._LimpiarTodo
        LimpiarTodo()
    End Sub

    Public Function _ProcesarDocumento() As Boolean Implements IPlantillaRetencionIvaCompras._ProcesarDocumento
        Try
            Dim xcompras As New FichaCompras
            Dim encabezado As New FichaCompras.c_Retenciones.AgregarRetencionIva
            Dim xretenciones_detalle As New List(Of FichaCompras.c_RetencionesDetalle.AgregarRetencionIvaDetalle)

            For Each dr As DataRow In xtb_secundaria.Rows
                Dim xdetalle As New FichaCompras.c_RetencionesDetalle.AgregarRetencionIvaDetalle

                With xdetalle
                    ._NumeroDocumento = dr(0)
                    ._FechaEmision = dr(1)
                    ._MontoTotal = Decimal.Round((dr(2) * dr(8)), 2, MidpointRounding.AwayFromZero)
                    ._MontoExento = Decimal.Round((dr(3) * dr(8)), 2, MidpointRounding.AwayFromZero)
                    ._MontoBase = Decimal.Round((dr(4) * dr(8)), 2, MidpointRounding.AwayFromZero)
                    ._MontoImpuesto = Decimal.Round((dr(5) * dr(8)), 2, MidpointRounding.AwayFromZero)
                    ._TasaRetencion = xcontroles._TasaRetencionIva
                    ._MontoRetencion = Decimal.Round((dr(6) * dr(8)), 2, MidpointRounding.AwayFromZero)
                    ._AutoDocumento = dr(7)
                    ._MontoBase1 = Decimal.Round((dr(8) * dr(9)), 2, MidpointRounding.AwayFromZero)
                    ._MontoBase2 = Decimal.Round((dr(8) * dr(10)), 2, MidpointRounding.AwayFromZero)
                    ._MontoBase3 = Decimal.Round((dr(8) * dr(11)), 2, MidpointRounding.AwayFromZero)
                    ._MontoImpuesto1 = Decimal.Round((dr(8) * dr(12)), 2, MidpointRounding.AwayFromZero)
                    ._MontoImpuesto2 = Decimal.Round((dr(8) * dr(13)), 2, MidpointRounding.AwayFromZero)
                    ._MontoImpuesto3 = Decimal.Round((dr(8) * dr(14)), 2, MidpointRounding.AwayFromZero)
                    ._Tasa1 = dr(15)
                    ._Tasa2 = dr(16)
                    ._Tasa3 = dr(17)
                    ._NumeroControlFiscal = dr(18)
                    ._DocumentoAplica = dr(19)
                    ._TipoDocumento = dr(20)
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
                ._FechaEmision = g_MiData.p_FechaDelMotorBD
                ._TipoDocumentoRetencion = TipoDocumentoRetencion.IVA
                ._TasaRetencion = xcontroles._TasaRetencionIva

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

            Dim xgrabar As New FichaCompras.GrabarRetenciones
            xgrabar._Proveedor = xproveedor.f_Proveedor.RegistroDato
            xgrabar._Retencion = encabezado
            xgrabar._RetencionDetalle = xretenciones_detalle
            xgrabar._Usuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato

            If MessageBox.Show("Estas Seguro De Procesar Esta Planilla ?", "*** Mensaje De Error ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                AddHandler xcompras._RetencionOk_Generada, AddressOf MostrarPlanilla
                xcompras.F_GrabarRetencionIva(xgrabar)
                LimpiarTodo()
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Function RetornarPeriodo(ByVal xfecha As Date)
        If xfecha.Day >= 1 And xfecha.Day <= 15 Then
            Return 1
        Else
            Return 2
        End If
    End Function

    Sub MostrarPlanilla(ByVal xauto_ret As String)
        Try
            VisualizarRet_Compras(xauto_ret, "", "")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class