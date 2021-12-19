Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class ExistenciaReservada
    Dim xautoprd As String
    Dim xtb As DataTable
    Dim xbs_xtb As BindingSource

    Property _AutoProducto() As String
        Get
            Return xautoprd
        End Get
        Set(ByVal value As String)
            xautoprd = value
        End Set
    End Property

    Const ConsultaSql As String = _
    "select  tvp.fecha_doc fecha, tvp.nombre_usuario usuario, tvp.equipoestacion equipo, tvpd.Cantidad, " _
             + "tvpd.NombreEmpaque, tvpd.ContenidoEmpaque,'Pendiente' movimiento ,tvp.nombre_pendiente para, " _
             + "case when tvp.tipo_doc ='1' then 'Factura' " _
             + "     when tvp.tipo_doc='2' then 'Nota Entrega' " _
             + "     when tvp.tipo_doc='4' then 'Pedido' " _
             + "     when tvp.tipo_doc='3' then 'Presupuesto' " _
             + "end tipodocumento, tvpd.producto nombreprd, tvpd.decimalesmedida decimales, '' autodoc " _
             + "from TemporalVenta_Pendiente tvp join TemporalVenta_PendienteDetalle tvpd on tvp.auto_doc=tvpd.auto_doc " _
             + "where tvpd.AutoProducto=@autoproducto and tvpd.BloquearExistencia='1' " _
             + "union " _
             + "select  t.fecha fecha, t.nombreusuario usuario, t.estacion equipo, t.Cantidad, t.NombreEmpaque, t.ContenidoEmpaque,'En Proceso' movimiento ,'' para," _
             + "        case  when t.tipodocumento ='1' then 'Factura' " _
             + "              when t.tipodocumento='2' then 'Nota Entrega' " _
             + "              when t.tipodocumento='4' then 'Pedido' " _
             + "              when t.tipodocumento='3' then 'Presupuesto' " _
             + "        end tipodocumento, t.producto nombreprd, t.decimalesmedida decimales, '' autodoc  " _
             + "    from TemporalVenta t where t.AutoProducto=@autoproducto and t.BloquearExistencia='1' " _
             + "union " _
             + "select p.fecha fecha, p.nombre usuario, '' equipo, pd.Cantidad, pd.empaque NombreEmpaque, pd.contenido_empaque ContenidoEmpaque, " _
             + "       'DOC/BD' movimiento ,p.nombre para,  case  when P.tipo='06' then 'Pedido' end tipodocumento, pd.nombre nombreprd, pd.decimales decimales, p.auto autodoc " _
             + "       from ventas p join ventas_detalle pd on pd.auto_documento=p.auto where p.tipo='06' and p.bloquear_almacen='1' and p.estatus='0' " _
             + "       and pd.auto_productos =@autoproducto " _
             + "order by fecha,tipodocumento"

    Private Sub ExistenciaReservada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ExistenciaReservada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ExistenciaReservada_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            Me.E_CLIENTE.Text = ""
            Me.E_PRODUCTO.Text = ""
            Me.E_TIPODOCUMENTO.Text = ""

            xtb = New DataTable
            xbs_xtb = New BindingSource(xtb, "")
            AddHandler xbs_xtb.PositionChanged, AddressOf ActualizarFicha

            Dim xp1 As New SqlParameter("@autoproducto", Me._AutoProducto)
            g_MiData.F_GetData(ConsultaSql, xtb, xp1)

            With MisGrid1
                .Columns.Add("col0", "Fecha")
                .Columns.Add("col1", "Usuario")
                .Columns.Add("col2", "Estacion")
                .Columns.Add("col3", "Cant")
                .Columns.Add("col4", "Empaque")
                .Columns.Add("col5", "Cont")
                .Columns.Add("col6", "Movimiento")

                .Columns(0).Width = 110
                .Columns(1).Width = 120
                .Columns(2).Width = 120
                .Columns(3).Width = 80
                .Columns(4).Width = 120
                .Columns(5).Width = 60
                .Columns("col6").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                AddHandler .CellFormatting, AddressOf MiFormato

                .DataSource = xbs_xtb
                ActualizaFicha()

                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "usuario"
                .Columns(2).DataPropertyName = "equipo"
                .Columns(3).DataPropertyName = "cantidad"
                .Columns(4).DataPropertyName = "nombreempaque"
                .Columns(5).DataPropertyName = "contenidoempaque"
                .Columns(6).DataPropertyName = "movimiento"

                .Ocultar(8)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarFicha()
        ActualizaFicha()
    End Sub

    Sub ActualizaFicha()
        If xbs_xtb.Current IsNot Nothing Then
            Me.E_PRODUCTO.Text = xbs_xtb.Current("NOMBREPRD").ToString.Trim
            Me.E_CLIENTE.Text = xbs_xtb.Current("PARA").ToString.Trim
            Me.E_TIPODOCUMENTO.Text = xbs_xtb.Current("TIPODOCUMENTO").ToString.Trim
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 3 Or e.ColumnIndex = 5 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If

        If e.ColumnIndex = 3 Then
            Dim xformato As String = "#0.000"
            Dim xv As Integer = 2
            Dim xd As String = MisGrid1.Rows(e.RowIndex).Cells("decimales").Value

            Integer.TryParse(xd, xv)
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
            e.Value = Format(e.Value, IIf(xv > 0, xformato.Substring(0, 3 + xv), xformato.Substring(0, 2)))
        End If
    End Sub

    Public Sub New(ByVal xautoprd As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _AutoProducto = xautoprd
    End Sub

    Private Sub MisGrid1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid1.Accion
        Dim xauto As String = CType(xrow.DataBoundItem, DataRowView).Row("autodoc").ToString.Trim
        If xauto <> "" Then
            VisualizarDoc_Ventas(xauto)
        End If
    End Sub
End Class