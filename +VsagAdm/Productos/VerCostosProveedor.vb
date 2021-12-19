Public Class VerCostosProveedor
    Dim xtb As DataTable

    Property _TablaVisualizar() As DataTable
        Get
            Return xtb
        End Get
        Set(ByVal value As DataTable)
            xtb = value
        End Set
    End Property

    Private Sub VerCostosProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub VerCostosProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Public Sub New(ByVal tabla_mostrar As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _TablaVisualizar = tabla_mostrar
    End Sub

    Private Sub VerCostosProveedor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            With MisGrid1
                .Columns.Add("col0", "Documento")
                .Columns.Add("col1", "Fecha")
                .Columns.Add("col2", "Precio")
                .Columns.Add("col3", "P/Cont")

                .Columns(1).Width = 100
                .Columns(2).Width = 80
                .Columns(3).Width = 80

                .DataSource = _TablaVisualizar
                .Columns(0).DataPropertyName = "xdocumento"
                .Columns(1).DataPropertyName = "xfecha"
                .Columns(2).DataPropertyName = "xprecio"
                .Columns(3).DataPropertyName = "xcontenido"

                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Ocultar(5)
                AddHandler .CellFormatting, AddressOf MiFormato
            End With
            Me.E_ITEMS.Text = _TablaVisualizar.Rows.Count.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 2 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub
End Class