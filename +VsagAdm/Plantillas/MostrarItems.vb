Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class MostrarItems
    Dim xplantilla As IMostrarItems

    Sub New(ByVal xtipoplantilla As IMostrarItems)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        xplantilla = xtipoplantilla
    End Sub

    Private Sub MostrarItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub MostrarItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub MostrarItems_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            Me.Label3.Text = "0"
            xplantilla.InicializaGrid(Me.MisGrid1)
            Me.Label3.Text = xplantilla.TotalItems.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub
End Class

Public Interface IMostrarItems
    Sub InicializaGrid(ByRef xgrid As MisControles.Controles.MisGrid)
    ReadOnly Property TotalItems() As Integer
End Interface

'
' MODULO DE VENTAS
'

Public Class MostrarItems_DocumentoVenta
    Implements IMostrarItems

    Dim xtb As DataTable
    Dim xp1 As SqlParameter
    Dim xsql As String = "select codigo x1, producto x2, cantidad x3, decimalesmedida x4 " _
                       + "from temporalventa_pendientedetalle where auto_doc=@auto_doc order by producto"

    Sub New(ByVal xauto_doc As String)
        xtb = New DataTable
        xp1 = New SqlParameter("@auto_doc", xauto_doc)
    End Sub

    Public Sub InicializaGrid(ByRef xgrid As MisControles.Controles.MisGrid) Implements IMostrarItems.InicializaGrid
        g_MiData.F_GetData(xsql, xtb, xp1)

        With xgrid
            .Columns.Add("col0", "Codigo")
            .Columns.Add("col1", "Descripcion")
            .Columns.Add("col2", "Cant")

            .Columns(0).Width = 80
            .Columns(2).Width = 80
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xtb
            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(2).DataPropertyName = "x3"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            AddHandler .CellFormatting, AddressOf MiFormato

            .Ocultar(4)
        End With
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 2 Then
            Dim xformato As String = "#0.000"

            Dim xd As String = sender.Rows(e.RowIndex).Cells("x4").Value.ToString
            Dim xv As Integer = 0
            Integer.TryParse(xd, xv)
            If xv > 0 Then
                xv += 1
            End If
            e.CellStyle.Format = xformato.Substring(0, 2 + xv)
        End If
    End Sub

    Public ReadOnly Property TotalItems() As Integer Implements IMostrarItems.TotalItems
        Get
            Return xtb.Rows.Count
        End Get
    End Property
End Class

Public Class MostrarItems_RescatarDocumento
    Implements IMostrarItems

    Dim xtb As DataTable
    Dim xp1 As SqlParameter
    Dim xp2 As SqlParameter
    Dim xp3 As SqlParameter
    Dim xp4 As SqlParameter
    Dim xsql As String = "select codigo x1, producto x2, cantidad x3, decimalesmedida x4 " _
                       + "from temporalventa where fecha=@fecha and tipodocumento=@tipodocumento and idunico=@idunico and autousuario=@autousuario order by producto "

    Sub New(ByVal xobj As Object, ByVal xtipodoc As String)
        xtb = New DataTable
        xp1 = New SqlParameter("@fecha", xobj("x1"))
        xp2 = New SqlParameter("@tipodocumento", xtipodoc)
        xp3 = New SqlParameter("@idunico", xobj("x6"))
        xp4 = New SqlParameter("@autousuario", xobj("x7"))
    End Sub

    Public Sub InicializaGrid(ByRef xgrid As MisControles.Controles.MisGrid) Implements IMostrarItems.InicializaGrid
        g_MiData.F_GetData(xsql, xtb, xp1, xp2, xp3, xp4)

        With xgrid
            .Columns.Add("col0", "Codigo")
            .Columns.Add("col1", "Descripcion")
            .Columns.Add("col2", "Cant")

            .Columns(0).Width = 80
            .Columns(2).Width = 80
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xtb
            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(2).DataPropertyName = "x3"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            AddHandler .CellFormatting, AddressOf MiFormato

            .Ocultar(4)
        End With
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 2 Then
            Dim xformato As String = "#0.000"

            Dim xd As String = sender.Rows(e.RowIndex).Cells("x4").Value.ToString
            Dim xv As Integer = 0
            Integer.TryParse(xd, xv)
            If xv > 0 Then
                xv += 1
            End If
            e.CellStyle.Format = xformato.Substring(0, 2 + xv)
        End If
    End Sub

    Public ReadOnly Property TotalItems() As Integer Implements IMostrarItems.TotalItems
        Get
            Return xtb.Rows.Count
        End Get
    End Property
End Class

