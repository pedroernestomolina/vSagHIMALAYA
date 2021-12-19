Imports MisControles.Controles
Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class DetallePagos
    Dim _Plantilla As IDetallePagos

    Sub New(ByVal xplantilla As IDetallePagos)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Sub Inicializar()
        Try
            _Plantilla.Inicializar(Me)
        Catch ex As Exception
            Throw New Exception("ERROR AL CARGAR FORMULARIO:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub DetallePagos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DetallePagos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub
End Class

Public Interface IDetallePagos
    Sub Inicializar(ByVal xformulario As Object)
End Interface

Public Class c_DetallePagosVentas
    Implements IDetallePagos

#Region "FUNCIONES SELECT"
    Const SELECT_DETALLE_DOCUMENTOS As String = "SELECT cd.origen tipo" & _
                                                        ",cd.documento" & _
                                                        ",cd.monto importe " & _
                                                "FROM cxc_documentos cd join cxc c on cd.auto_cxc=c.auto " & _
                                                "WHERE cd.auto_cxc_recibo=@auto_cxc_recibo and c.tipo_documento<>'NCF'"

    Const SELECT_DETALLE_MODOSPAGOS As String = "SELECT nombre,importe,numero,agencia " & _
                                                "FROM cxc_modo_pago where auto_recibo=@auto_cxc_recibo " & _
                                                "union select 'NOTA CREDITO',monto,'','' from cxc_documentos cd join cxc c on cd.auto_cxc = c.auto " & _
                                                "WHERE cd.auto_cxc_recibo=@auto_cxc_recibo and c.tipo_documento='NCF'"

#End Region

    'LABELS
    Dim LB_NOMBRE As System.Windows.Forms.Label
    Dim LB_CIRIF As System.Windows.Forms.Label
    Dim LB_CODIGO As System.Windows.Forms.Label
    Dim LB_FECHA As System.Windows.Forms.Label
    Dim LB_RECIBO As System.Windows.Forms.Label
    Dim LB_DETALLE As System.Windows.Forms.Label
    Dim LB_ITEMS_E_1 As System.Windows.Forms.Label
    Dim LB_ITEMS_E_2 As System.Windows.Forms.Label
    Dim LB_IMPORTE As System.Windows.Forms.Label
    Dim LB_ABONO As System.Windows.Forms.Label

    'DATAGRIDVIEW
    WithEvents xdatagrid_1 As MisGrid
    WithEvents xdatagrid_2 As MisGrid

    Dim _Data_1 As DataTable
    Dim _Data_2 As DataTable

    Dim _CxC_Recibo As New FichaCtasCobrar.c_Recibos

    ReadOnly Property _DocumentosEncontrados() As Integer
        Get
            Return _Data_1.Rows.Count
        End Get
    End Property

    ReadOnly Property _ModosPagosEncontrados() As Integer
        Get
            Return _Data_2.Rows.Count
        End Get
    End Property

    Sub New(ByVal xauto As String)
        _Data_1 = New DataTable
        _Data_2 = New DataTable
        _CxC_Recibo.M_CargarRegistro(xauto)
    End Sub

    Sub New(ByVal xrow As DataRow)
        _Data_1 = New DataTable
        _Data_2 = New DataTable
        _CxC_Recibo.M_CargarRegistro(xrow)
    End Sub

    Public Sub Inicializar(ByVal xformulario As Object) Implements IDetallePagos.Inicializar
        Dim _MiFormulario As System.Windows.Forms.Form = xformulario

        LB_NOMBRE = _MiFormulario.Controls.Find("LB_NOMBRE", True)(0)
        LB_CIRIF = _MiFormulario.Controls.Find("LB_CIRIF", True)(0)
        LB_CODIGO = _MiFormulario.Controls.Find("LB_CODIGO", True)(0)
        LB_FECHA = _MiFormulario.Controls.Find("LB_FECHA", True)(0)
        LB_RECIBO = _MiFormulario.Controls.Find("LB_RECIBO", True)(0)
        LB_DETALLE = _MiFormulario.Controls.Find("LB_DETALLE", True)(0)
        LB_ITEMS_E_1 = _MiFormulario.Controls.Find("LB_ITEMS_E_1", True)(0)
        LB_ITEMS_E_2 = _MiFormulario.Controls.Find("LB_ITEMS_E_2", True)(0)
        LB_IMPORTE = _MiFormulario.Controls.Find("LB_IMPORTE", True)(0)
        LB_ABONO = _MiFormulario.Controls.Find("LB_ABONO", True)(0)

        xdatagrid_1 = _MiFormulario.Controls.Find("MisGrid1", True)(0)
        xdatagrid_2 = _MiFormulario.Controls.Find("MisGrid2", True)(0)

        InicializarData()
        With xdatagrid_1
            .Columns.Add("col0", "T/Documento")
            .Columns.Add("col1", "Documento")
            .Columns.Add("col2", "Abono")

            .Columns(0).DataPropertyName = "tipo"
            .Columns(1).DataPropertyName = "documento"
            .Columns(2).DataPropertyName = "importe"

            .DataSource = _Data_1

            .Columns(1).Width = 150
            .Columns(2).Width = 100
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Ocultar(4)
            AddHandler .CellFormatting, AddressOf MiFormato
        End With

        With xdatagrid_2
            .Columns.Add("col0", "Forma")
            .Columns.Add("col1", "Importe")
            .Columns.Add("col2", "Número")
            .Columns.Add("col3", "Banco")

            .Columns(0).DataPropertyName = "nombre"
            .Columns(1).DataPropertyName = "importe"
            .Columns(2).DataPropertyName = "numero"
            .Columns(3).DataPropertyName = "agencia"

            .DataSource = _Data_2

            .Columns(0).Width = 120
            With .Columns(1)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 100
            End With
            .Columns(2).Width = 100
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Ocultar(5)
        End With
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 2 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Sub InicializarData()
        CargarData()

        LB_NOMBRE.Text = _CxC_Recibo.RegistroDato._NombreCliente
        LB_CIRIF.Text = _CxC_Recibo.RegistroDato._CiRifCliente
        LB_CODIGO.Text = _CxC_Recibo.RegistroDato._CodigoCliente
        LB_FECHA.Text = _CxC_Recibo.RegistroDato._FechaEmision
        LB_RECIBO.Text = _CxC_Recibo.RegistroDato._NumeroRecibo
        LB_DETALLE.Text = _CxC_Recibo.RegistroDato._NotasDetalles
        LB_ITEMS_E_1.Text = _DocumentosEncontrados
        LB_ITEMS_E_2.Text = _ModosPagosEncontrados
        LB_IMPORTE.Text = _CxC_Recibo.RegistroDato._MontoImporte
        LB_ABONO.Text = _CxC_Recibo.RegistroDato._MontoImporte
    End Sub

    Sub CargarData()
        Dim xparam As SqlParameter = Nothing

        xparam = New SqlParameter("@auto_cxc_recibo", _CxC_Recibo.RegistroDato._AutoRecibo)
        g_MiData.F_GetData(SELECT_DETALLE_MODOSPAGOS, _Data_2, xparam)

        xparam = New SqlParameter("@auto_cxc_recibo", _CxC_Recibo.RegistroDato._AutoRecibo)
        g_MiData.F_GetData(SELECT_DETALLE_DOCUMENTOS, _Data_1, xparam)

        'For Each xrow In _Data_1.Rows
        '    If xrow("tipo").ToString.Trim = "NOTA CRÉDITO" Then
        '        Dim xdatarow = _Data_2.NewRow
        '        xdatarow("nombre") = "NOTA CRÉDITO"
        '        xdatarow("importe") = xrow("importe")
        '        _Data_2.Rows.Add(xdatarow)
        '        xrow("importe") = xrow("importe") * -1
        '    End If
        'Next
    End Sub
End Class