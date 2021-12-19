Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plant_DocPend_Compras
    Dim xplantilla As IPLANT_DocPendCompras


    Property _MiPlantilla() As IPLANT_DocPendCompras
        Get
            Return Me.xplantilla
        End Get
        Set(ByVal value As IPLANT_DocPendCompras)
            Me.xplantilla = value
        End Set
    End Property


    Sub New(ByVal xplant As IPLANT_DocPendCompras)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._MiPlantilla = xplant
    End Sub

    Private Sub Plant_DocPend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plant_DocPend_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Me._MiPlantilla.Inicializa(Me)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub Plant_DocPend_Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub
End Class


Public Interface IPLANT_DocPendCompras
    Sub Inicializa(ByVal xform As Object)
End Interface


Class DocPendCompras
    Implements IPLANT_DocPendCompras
    Event _CargarPendiente(ByVal xautodoc As String)

    WithEvents _MiForm As System.Windows.Forms.Form
    WithEvents L1 As Label
    WithEvents L2 As Label
    WithEvents L3 As Label
    WithEvents BT_1 As Button
    WithEvents MG_1 As MisControles.Controles.MisGrid

    Const xSQL As String = "select fecha_doc x1, nombre_pendiente x2, nombre_usuario x3, equipoestacion x4, monto_doc x5, items_doc x6, * " _
           + "from temporal_compra_pendiente readpast where tipo_doc='1' order by fecha_doc, nombre_pendiente"

    Dim xbs As BindingSource
    Dim xtb As DataTable
    Dim xdoc As FichaCompras.c_TemporalCompraPendiente.c_Registro


    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xdoc = New FichaCompras.c_TemporalCompraPendiente.c_Registro
        AddHandler xbs.PositionChanged, AddressOf MostrarData
    End Sub

    Sub MostrarData()
        If xbs.Current IsNot Nothing Then
            Dim xrow As DataRow = CType(xbs.Current, DataRowView).Row
            xdoc.CargarRegistro(xrow)

            Me.L2.Text = xdoc._NombreCtaPendiente
            Me.L3.Text = xbs.Count.ToString
        Else
            Me.L2.Text = ""
            Me.L3.Text = "0"
        End If
    End Sub

    Public Sub Inicializa(ByVal xform As Object) Implements IPLANT_DocPendCompras.Inicializa
        _MiForm = CType(xform, System.Windows.Forms.Form)
        L1 = _MiForm.FindForm.Controls.Find("L_1", True)(0)
        L2 = _MiForm.FindForm.Controls.Find("L_2", True)(0)
        L3 = _MiForm.FindForm.Controls.Find("L_3", True)(0)
        BT_1 = _MiForm.FindForm.Controls.Find("BT_1", True)(0)
        MG_1 = _MiForm.FindForm.Controls.Find("MG_1", True)(0)

        InicializarControles()
    End Sub

    Sub InicializarControles()
        L1.Text = "Documentos De Compras Pendientes Por Procesar !!!"
        L2.Text = ""
        L3.Text = "0"

        g_MiData.F_GetData(xSQL, xtb)
        With MG_1
            .Columns.Add("col0", "De Fecha")
            .Columns.Add("col1", "De Nombre")
            .Columns.Add("col2", "Del Usuario")
            .Columns.Add("col3", "Del Equipo")
            .Columns.Add("col4", "De Monto")
            .Columns.Add("col5", "# Items")

            .Columns(0).Width = 110
            .Columns(2).Width = 140
            .Columns(3).Width = 140
            .Columns(4).Width = 100
            .Columns(5).Width = 80
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            .DataSource = xbs
            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(2).DataPropertyName = "x3"
            .Columns(3).DataPropertyName = "x4"
            .Columns(4).DataPropertyName = "x5"
            .Columns(5).DataPropertyName = "x6"

            .Ocultar(7)
            .Select()
            .Focus()
        End With

        If xtb.Rows.Count = 0 Then
            Funciones.MensajeDeAlerta("NO HAY REGISTROS QUE MOSTRAR... ")
            _MiForm.Close()
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If xbs.Current IsNot Nothing Then
            Try
                Dim xficha As New Plant_MostrarItem_Compra(New MostrarItem_DocCompraPendiente(xdoc._AutoMovimiento))
                With xficha
                    xficha.ShowDialog()
                End With
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub MG_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_1.Accion
        If MessageBox.Show("Estas De Acuerdo En Abrir Este Documento ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            RaiseEvent _CargarPendiente(xdoc._AutoMovimiento)
            _MiForm.Close()
        End If
    End Sub
End Class


Class DocPendOrdCompra
    Implements IPLANT_DocPendCompras
    Event _CargarPendiente(ByVal xautodoc As String)

    WithEvents _MiForm As System.Windows.Forms.Form
    WithEvents L1 As Label
    WithEvents L2 As Label
    WithEvents L3 As Label
    WithEvents BT_1 As Button
    WithEvents MG_1 As MisControles.Controles.MisGrid


    Const xSQL As String = "select fecha_doc x1, nombre_pendiente x2, nombre_usuario x3, equipoestacion x4, monto_doc x5, items_doc x6, * " _
           + "from temporal_compra_pendiente readpast where tipo_doc='4' order by fecha_doc, nombre_pendiente"


    Dim xbs As BindingSource
    Dim xtb As DataTable
    Dim xdoc As FichaCompras.c_TemporalCompraPendiente.c_Registro


    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xdoc = New FichaCompras.c_TemporalCompraPendiente.c_Registro
        AddHandler xbs.PositionChanged, AddressOf MostrarData
    End Sub

    Sub MostrarData()
        If xbs.Current IsNot Nothing Then
            Dim xrow As DataRow = CType(xbs.Current, DataRowView).Row
            xdoc.CargarRegistro(xrow)

            Me.L2.Text = xdoc._NombreCtaPendiente
            Me.L3.Text = xbs.Count.ToString
        Else
            Me.L2.Text = ""
            Me.L3.Text = "0"
        End If
    End Sub

    Public Sub Inicializa(ByVal xform As Object) Implements IPLANT_DocPendCompras.Inicializa
        _MiForm = CType(xform, System.Windows.Forms.Form)
        L1 = _MiForm.FindForm.Controls.Find("L_1", True)(0)
        L2 = _MiForm.FindForm.Controls.Find("L_2", True)(0)
        L3 = _MiForm.FindForm.Controls.Find("L_3", True)(0)
        BT_1 = _MiForm.FindForm.Controls.Find("BT_1", True)(0)
        MG_1 = _MiForm.FindForm.Controls.Find("MG_1", True)(0)

        InicializarControles()
    End Sub

    Sub InicializarControles()
        L1.Text = "Documentos Orden De Compras Pendientes Por Procesar !!!"
        L2.Text = ""
        L3.Text = "0"

        g_MiData.F_GetData(xSQL, xtb)
        With MG_1
            .Columns.Add("col0", "De Fecha")
            .Columns.Add("col1", "De Nombre")
            .Columns.Add("col2", "Del Usuario")
            .Columns.Add("col3", "Del Equipo")
            .Columns.Add("col4", "De Monto")
            .Columns.Add("col5", "# Items")

            .Columns(0).Width = 110
            .Columns(2).Width = 140
            .Columns(3).Width = 140
            .Columns(4).Width = 100
            .Columns(5).Width = 80
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            .DataSource = xbs
            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(2).DataPropertyName = "x3"
            .Columns(3).DataPropertyName = "x4"
            .Columns(4).DataPropertyName = "x5"
            .Columns(5).DataPropertyName = "x6"

            .Ocultar(7)
            .Select()
            .Focus()
        End With

        If xtb.Rows.Count = 0 Then
            Funciones.MensajeDeAlerta("NO HAY REGISTROS QUE MOSTRAR... ")
            _MiForm.Close()
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If xbs.Current IsNot Nothing Then
            Try
                Dim xficha As New Plant_MostrarItem_Compra(New MostrarItem_DocCompraPendiente(xdoc._AutoMovimiento))
                With xficha
                    xficha.ShowDialog()
                End With
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub MG_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_1.Accion
        If MessageBox.Show("Estas De Acuerdo En Abrir Este Documento ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            RaiseEvent _CargarPendiente(xdoc._AutoMovimiento)
            _MiForm.Close()
        End If
    End Sub
End Class


Class RecuperarDocCompra
    Implements IPLANT_DocPendCompras
    Event _RecuperarDocumento(ByVal xfecha As Date, ByVal xidunico As String, ByVal xauto_usuario As String)

    WithEvents _MiForm As System.Windows.Forms.Form
    WithEvents L1 As Label
    WithEvents L2 As Label
    WithEvents L3 As Label
    WithEvents BT_1 As Button
    WithEvents MG_1 As MisControles.Controles.MisGrid


    Const xSQL As String = "select fecha x1, nombreusuario x2, estacion x3, SUM(costo) x4, COUNT(*) x5, IdUnico x6, AutoUsuario x7 from Temporal_Compra " _
               + "where TipoDocumento=@tipodocumento group by IdUnico,fecha,autousuario,nombreusuario,estacion"


    Dim xbs As BindingSource
    Dim xtb As DataTable
    Dim xdoc As FichaCompras.c_TemporalCompraPendiente.c_Registro
    Dim xtipodocumento As String
    Dim xp1 As SqlParameter


    Property _TipoDocumento() As String
        Get
            Return Me.xtipodocumento
        End Get
        Set(ByVal value As String)
            Me.xtipodocumento = value
        End Set
    End Property


    Sub New(ByVal xtipodoc As TipoDocumentoCompra)
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xdoc = New FichaCompras.c_TemporalCompraPendiente.c_Registro
        AddHandler xbs.PositionChanged, AddressOf MostrarData

        Select Case xtipodoc
            Case TipoDocumentoCompra.Factura : Me._TipoDocumento = "1"
            Case TipoDocumentoCompra.NotaDebito : Me._TipoDocumento = "2"
            Case TipoDocumentoCompra.NotaCredito : Me._TipoDocumento = "3"
            Case TipoDocumentoCompra.OrdenCompra : Me._TipoDocumento = "4"
        End Select
        xp1 = New SqlParameter("@tipodocumento", Me._TipoDocumento)
    End Sub

    Sub MostrarData()
        If xbs.Current IsNot Nothing Then
            Me.L2.Text = xbs.Current("x2").ToString.Trim
            Me.L3.Text = xbs.Count.ToString
        Else
            Me.L2.Text = ""
            Me.L3.Text = "0"
        End If
    End Sub

    Public Sub Inicializa(ByVal xform As Object) Implements IPLANT_DocPendCompras.Inicializa
        _MiForm = CType(xform, System.Windows.Forms.Form)
        L1 = _MiForm.FindForm.Controls.Find("L_1", True)(0)
        L2 = _MiForm.FindForm.Controls.Find("L_2", True)(0)
        L3 = _MiForm.FindForm.Controls.Find("L_3", True)(0)
        BT_1 = _MiForm.FindForm.Controls.Find("BT_1", True)(0)
        MG_1 = _MiForm.FindForm.Controls.Find("MG_1", True)(0)

        InicializarControles()
    End Sub

    Sub InicializarControles()
        L1.Text = "Documentos Posibles Por Rescatar !!!"
        L2.Text = ""
        L3.Text = "0"

        g_MiData.F_GetData(xSQL, xtb, xp1)
        With MG_1
            .Columns.Add("col0", "De Fecha")
            .Columns.Add("col1", "Del Usuario")
            .Columns.Add("col2", "Del Equipo")
            .Columns.Add("col3", "De Monto")
            .Columns.Add("col4", "# Items")

            .Columns(0).Width = 110
            .Columns(1).Width = 160
            .Columns(2).Width = 160
            .Columns(3).Width = 100
            .Columns(4).Width = 80

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xbs
            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(2).DataPropertyName = "x3"
            .Columns(3).DataPropertyName = "x4"
            .Columns(4).DataPropertyName = "x5"
            .Ocultar(6)

            .Select()
            .Focus()
        End With

        If xtb.Rows.Count = 0 Then
            Funciones.MensajeDeAlerta("NO HAY REGISTROS QUE MOSTRAR... ")
            _MiForm.Close()
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        If xbs.Current IsNot Nothing Then
            Try
                Dim xficha As New Plant_MostrarItem_Compra(New MostrarItem_RcuperarDocCompra(xbs.Current("x1"), xbs.Current("x6"), xbs.Current("x7"), Me._TipoDocumento))
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub MG_1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_1.Accion
        Dim xr As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
        If MessageBox.Show("Estas Seguro Que El Documento A Rescatar No Esta Siendo Procesado Por Ningun Usuario ?", "*** Mensaje De Alerta ***", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            If MessageBox.Show("Estas De Acuerdo En Rescatar Este Documento ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                RaiseEvent _RecuperarDocumento(xr("x1"), xr("x6"), xr("x7"))
                _MiForm.Close()
            End If
        End If
    End Sub
End Class