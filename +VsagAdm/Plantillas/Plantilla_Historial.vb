Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema

Public Class Plantilla_Historial
    Dim xplant As IPlantilla_Historial

    Property _Plantilla() As IPlantilla_Historial
        Get
            Return xplant
        End Get
        Set(ByVal value As IPlantilla_Historial)
            xplant = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantilla_Historial)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Private Sub Plantilla_Historial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_Historial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Plantilla_Historial_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            _Plantilla.CargarData(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub
End Class

Public Interface IPlantilla_Historial
    Sub CargarData(ByVal xform As Object)
End Interface

Public Class Hisotirial_ProductoCosto
    Implements IPlantilla_Historial
    Dim xfichaprd As FichaProducto.Prd_Producto.c_Registro

    Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
        Get
            Return xfichaprd
        End Get
        Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
            xfichaprd = value
        End Set
    End Property

    Sub New(ByVal xfichaprd As FichaProducto.Prd_Producto.c_Registro)
        _FichaProducto = xfichaprd
    End Sub

    Dim xform As System.Windows.Forms.Form
    WithEvents MG As MisControles.Controles.MisGrid
    Dim E1 As System.Windows.Forms.Label
    Dim E2 As System.Windows.Forms.Label
    Dim E3 As System.Windows.Forms.Label
    Dim xtb As DataTable
    Dim xbs As BindingSource

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Sub CargarData()
        Dim xp1 As New SqlParameter("@auto", xfichaprd._AutoProducto)
        Dim xsql As String = "select fecha_emision x1, fecha_carga x2, estacion x3, usuario x4, hora x5, empaque x6, contenido_empaque x7, costo_actual x8," & _
                      "costo_nuevo x9, costo x10, CASE origen WHEN '0301' THEN 'INVENTARIO' WHEN '0701' THEN 'COMPRA' END x11, " & _
                      "DOCUMENTO x13, entidad x14, nota x12, * from productos_historico_costos where auto_producto=@AUTO AND estatus='0' ORDER BY fecha_carga,auto"
        g_MiData.F_GetData(xsql, xtb, xp1)
    End Sub

    Public Sub CargarData(ByVal xform As Object) Implements IPlantilla_Historial.CargarData
        Try
            _MiFormulario = CType(xform, System.Windows.Forms.Form)
            _MiFormulario.Text = "Productos"

            E1 = _MiFormulario.Controls.Find("E_1", True)(0)
            E2 = _MiFormulario.Controls.Find("E_2", True)(0)
            E3 = _MiFormulario.Controls.Find("E_3", True)(0)
            MG = _MiFormulario.Controls.Find("MisGrid1", True)(0)

            E1.Text = "Historico Costos"
            E2.Text = "0"
            E3.Text = ""

            xtb = New DataTable
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarFicha
            ActualizaFicha()

            CargarData()
            With MG
                .Columns.Add("col0", "F/Emision")
                .Columns.Add("col1", "F/Proceso")
                .Columns.Add("col2", "Equipo")
                .Columns.Add("col3", "Usuario")
                .Columns.Add("col4", "Hora")
                .Columns.Add("col5", "Empaque")
                .Columns.Add("col6", "Cont")
                .Columns.Add("col7", "C/Anterior")
                .Columns.Add("col8", "C/Nuevo")
                .Columns.Add("col9", "C/Referenc")
                .Columns.Add("col10", "Origen")

                .Columns(0).Width = 80
                .Columns(1).Width = 80
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 60
                .Columns(5).Width = 90
                .Columns(6).Width = 60
                .Columns(7).Width = 90
                .Columns(8).Width = 90
                .Columns(9).Width = 90
                .Columns(10).Width = 100

                .DataSource = xbs
                .Columns(0).DataPropertyName = "x1"
                .Columns(1).DataPropertyName = "x2"
                .Columns(2).DataPropertyName = "x3"
                .Columns(3).DataPropertyName = "x4"
                .Columns(4).DataPropertyName = "x5"
                .Columns(5).DataPropertyName = "x6"
                .Columns(6).DataPropertyName = "x7"
                .Columns(7).DataPropertyName = "x8"
                .Columns(8).DataPropertyName = "x9"
                .Columns(9).DataPropertyName = "x10"
                .Columns(10).DataPropertyName = "x11"
                .Ocultar(12)

                AddHandler .CellFormatting, AddressOf MiFormato
            End With

            Me.E2.Text = xtb.Rows.Count.ToString.Trim
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ActualizarFicha(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizaFicha()
    End Sub

    Sub ActualizaFicha()
        If xbs.Current IsNot Nothing Then
            Me.E3.Text = xbs.Current("x12").ToString.Trim
        Else
            Me.E3.Text = ""
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 6 And e.ColumnIndex <= 9 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Private Sub MG_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG.Accion
        Try
            Dim xr As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
            Dim xhistorial As New FichaProducto.Prd_HistoricoCostos.c_Registro
            xhistorial.CargarRegistro(xr)
            If xhistorial._AutoDocumento <> "" Then
                VisualizarDoc_Compras(xhistorial._AutoDocumento)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class Hisotirial_ProductoPrecios
    Implements IPlantilla_Historial
    Dim xfichaprd As FichaProducto.Prd_Producto.c_Registro

    Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
        Get
            Return xfichaprd
        End Get
        Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
            xfichaprd = value
        End Set
    End Property

    Sub New(ByVal xfichaprd As FichaProducto.Prd_Producto.c_Registro)
        _FichaProducto = xfichaprd
    End Sub

    Dim xform As System.Windows.Forms.Form
    Dim MG As MisControles.Controles.MisGrid
    Dim E1 As System.Windows.Forms.Label
    Dim E2 As System.Windows.Forms.Label
    Dim E3 As System.Windows.Forms.Label
    Dim xtb As DataTable
    Dim xbs As BindingSource

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Sub CargarData()
        Dim xp1 As New SqlParameter("@auto", xfichaprd._AutoProducto)
        Dim xsql As String = "select fecha x1,estacion x2,usuario x3,hora x4,precio_anterior x5,precio_nuevo x6,empaque x7,contenido_empaque x8, precio_id x9, nota xa " & _
            "from productos_historico_precios where auto_producto=@auto and precio_id<>'COSTO' ORDER BY auto DESC"
        g_MiData.F_GetData(xsql, xtb, xp1)
    End Sub

    Public Sub CargarData(ByVal xform As Object) Implements IPlantilla_Historial.CargarData
        Try
            _MiFormulario = CType(xform, System.Windows.Forms.Form)
            _MiFormulario.Text = "Productos"

            E1 = _MiFormulario.Controls.Find("E_1", True)(0)
            E2 = _MiFormulario.Controls.Find("E_2", True)(0)
            E3 = _MiFormulario.Controls.Find("E_3", True)(0)
            MG = _MiFormulario.Controls.Find("MisGrid1", True)(0)

            E1.Text = "Historico Precios"
            E2.Text = "0"
            E3.Text = ""

            xtb = New DataTable
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarFicha
            ActualizaFicha()

            CargarData()
            With MG
                .Columns.Add("col0", "Fecha")
                .Columns.Add("col1", "Equipo")
                .Columns.Add("col2", "Usuario")
                .Columns.Add("col3", "Hora")
                .Columns.Add("col4", "P/Anterior")
                .Columns.Add("col5", "P/Nuevo")
                .Columns.Add("col6", "Empaque")
                .Columns.Add("col7", "Cont")
                .Columns.Add("col8", "P/Ref")

                .Columns(0).Width = 80
                .Columns(2).Width = 120
                .Columns(3).Width = 60
                .Columns(4).Width = 80
                .Columns(5).Width = 80
                .Columns(6).Width = 80
                .Columns(7).Width = 50
                .Columns(8).Width = 50
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "x1"
                .Columns(1).DataPropertyName = "x2"
                .Columns(2).DataPropertyName = "x3"
                .Columns(3).DataPropertyName = "x4"
                .Columns(4).DataPropertyName = "x5"
                .Columns(5).DataPropertyName = "x6"
                .Columns(6).DataPropertyName = "x7"
                .Columns(7).DataPropertyName = "x8"
                .Columns(8).DataPropertyName = "x9"
                .Ocultar(10)

                AddHandler .CellFormatting, AddressOf MiFormato
            End With

            Me.E2.Text = xtb.Rows.Count.ToString.Trim
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ActualizarFicha(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizaFicha()
    End Sub

    Sub ActualizaFicha()
        If xbs.Current IsNot Nothing Then
            Me.E3.Text = xbs.Current("xa").ToString.Trim
        Else
            Me.E3.Text = ""
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 4 Then
            If e.ColumnIndex <> 6 Then
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
            End If
        End If
    End Sub
End Class
