Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plantilla_9
    Dim xplantilla As IPlantilla_9
    Dim xbs As BindingSource

    Sub New(ByVal xtipo_plantilla As IPlantilla_9)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        xplantilla = xtipo_plantilla
    End Sub

    Private Sub Plantilla_9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_9_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            xplantilla.Inicializa(Me)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

  
End Class

Public Interface IPlantilla_9
    'Event RecuperarDocumentoVenta(ByVal xfecha As Date, ByVal xidunico As String, ByVal xauto_usuario As String)
    Sub Inicializa(ByVal xform As Object)
End Interface


'
' MODULO DE VENTAS
'

Public Class AbrirCtaPendientesVentas
    Implements IPlantilla_9
    Event AbrirCtaPendienteVenta(ByVal xauto_documento As String, ByVal xauto_usuario As String)

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xsql As String = "select fecha_doc x1, nombre_pendiente x2, nombre_usuario x3, equipoestacion x4, monto_doc x5, items_doc x6, * " _
        + "from temporalventa_pendiente where tipo_doc='1' order by nombre_pendiente"

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        AddHandler xbs.PositionChanged, AddressOf ActualizarData
    End Sub

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents DTGRID As MisControles.Controles.MisGrid
    WithEvents BT As Button
    WithEvents E_1 As Label
    WithEvents E_2 As Label
    WithEvents E_3 As Label

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantilla_9.Inicializa
        _Form = CType(xform, System.Windows.Forms.Form)
        DTGRID = _Form.Controls.Find("MISGRID1", True)(0)
        BT = _Form.Controls.Find("BT_VISUALIZAR", True)(0)
        E_1 = _Form.Controls.Find("E_TITULO", True)(0)
        E_2 = _Form.Controls.Find("E_NOMBRE", True)(0)
        E_3 = _Form.Controls.Find("E_ITEMS", True)(0)
        E_1.Text = "Documentos De Ventas Pendientes Por Procesar !!!"
        E_2.Text = ""
        E_3.Text = "0"

        CargarData()
    End Sub

    Sub CargarData()
        g_MiData.F_GetData(xsql, xtb)

        With DTGRID
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
        End With

        If xtb.Rows.Count = 0 Then
            Funciones.MensajeDeAlerta("NO HAY REGISTROS QUE MOSTRAR... ")
            _Form.Close()
        End If
    End Sub

    Sub ActualizarData()
        If xbs.Current IsNot Nothing Then
            Me.E_2.Text = xbs.Current("x2").ToString.Trim
            Me.E_3.Text = String.Format("{0:#0}", xbs.Count)
        Else
            Me.E_2.Text = ""
            Me.E_3.Text = "0"
        End If
    End Sub

    Private Sub DTGRID_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles DTGRID.Accion
        If MessageBox.Show("Abrir Este Documento Pendiente ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim xrw As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
            Dim xficha As New FichaVentas.V_TemporalVentaPendiente(xrw)
            RaiseEvent AbrirCtaPendienteVenta(xficha.RegistroDato._AutoMovimiento, xficha.RegistroDato._AutomaticoUsuario)
            _Form.Close()
        End If
    End Sub

    Private Sub BT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT.Click
        Try
            Dim xrow As DataRow = CType(xbs.Current, DataRowView).Row
            Dim xreg As New FichaVentas.V_TemporalVentaPendiente(xrow)

            Dim xficha As New Plantilla_MostrarItem_Venta(New MostrarItemsVenta(xreg.RegistroDato._AutoMovimiento))
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class AbrirCtaPendientesPresupuesto
    Implements IPlantilla_9
    Event AbrirCtaPendiente(ByVal xauto_documento As String, ByVal xauto_usuario As String)

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xsql As String = "select fecha_doc x1, nombre_pendiente x2, nombre_usuario x3, equipoestacion x4, monto_doc x5, items_doc x6, * " _
        + "from temporalventa_pendiente where tipo_doc='3' order by nombre_pendiente"

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        AddHandler xbs.PositionChanged, AddressOf ActualizarData
    End Sub

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents DTGRID As MisControles.Controles.MisGrid
    WithEvents BT As Button
    WithEvents E_1 As Label
    WithEvents E_2 As Label
    WithEvents E_3 As Label

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantilla_9.Inicializa
        _Form = CType(xform, System.Windows.Forms.Form)
        DTGRID = _Form.Controls.Find("MISGRID1", True)(0)
        BT = _Form.Controls.Find("BT_VISUALIZAR", True)(0)
        E_1 = _Form.Controls.Find("E_TITULO", True)(0)
        E_2 = _Form.Controls.Find("E_NOMBRE", True)(0)
        E_3 = _Form.Controls.Find("E_ITEMS", True)(0)
        E_1.Text = "Documentos Presupuestos Pendientes Por Procesar !!!"
        E_2.Text = ""
        E_3.Text = "0"

        CargarData()
    End Sub

    Sub CargarData()
        g_MiData.F_GetData(xsql, xtb)

        With DTGRID
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
        End With
    End Sub

    Sub ActualizarData()
        If xbs.Current IsNot Nothing Then
            Me.E_2.Text = xbs.Current("x2").ToString.Trim
            Me.E_3.Text = String.Format("{0:#0}", xbs.Count)
        Else
            Me.E_2.Text = ""
            Me.E_3.Text = "0"
        End If
    End Sub

    Private Sub DTGRID_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles DTGRID.Accion
        If MessageBox.Show("Abrir Este Documento Pendiente ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim xrw As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
            Dim xficha As New FichaVentas.V_TemporalVentaPendiente(xrw)
            RaiseEvent AbrirCtaPendiente(xficha.RegistroDato._AutoMovimiento, xficha.RegistroDato._AutomaticoUsuario)
            _Form.Close()
        End If
    End Sub

    Private Sub BT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT.Click
        Try
            Dim xrow As DataRow = CType(xbs.Current, DataRowView).Row
            Dim xreg As New FichaVentas.V_TemporalVentaPendiente(xrow)

            Dim xficha As New Plantilla_MostrarItem_Venta(New MostrarItemsVenta(xreg.RegistroDato._AutoMovimiento))
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class RecuperarDocumentos
    Implements IPlantilla_9
    Event RecuperarDocumento(ByVal xfecha As Date, ByVal xidunico As String, ByVal xauto_usuario As String)
    
    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xp1 As SqlParameter
    Dim xsql As String = "select fecha x1, nombreusuario x2, estacion x3, SUM(importe) x4, COUNT(*) x5, IdUnico x6, AutoUsuario x7 from TemporalVenta " _
               + "where TipoDocumento=@tipodocumento  group by IdUnico,fecha,autousuario,nombreusuario,estacion"
    Dim x As Integer = 0

    Sub New(ByVal xtipodoc As TipoDocumentoVenta)
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        AddHandler xbs.PositionChanged, AddressOf ActualizarData

        x = [Enum].Parse(GetType(TipoDocumentoVenta), xtipodoc)
        xp1 = New SqlParameter("@tipodocumento", x.ToString)
    End Sub

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents DTGRID As MisControles.Controles.MisGrid
    WithEvents BT As Button
    WithEvents E_1 As Label
    WithEvents E_2 As Label
    WithEvents E_3 As Label

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantilla_9.Inicializa
        _Form = CType(xform, System.Windows.Forms.Form)
        DTGRID = _Form.Controls.Find("MISGRID1", True)(0)
        BT = _Form.Controls.Find("BT_VISUALIZAR", True)(0)
        E_1 = _Form.Controls.Find("E_TITULO", True)(0)
        E_2 = _Form.Controls.Find("E_NOMBRE", True)(0)
        E_3 = _Form.Controls.Find("E_ITEMS", True)(0)
        E_1.Text = "Documentos Posibles A Recuperar !!!"
        E_2.Text = ""
        E_3.Text = "0"

        CargarData()
    End Sub

    Sub CargarData()
        g_MiData.F_GetData(xsql, xtb, xp1)

        With DTGRID
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
        End With

        If xtb.Rows.Count = 0 Then
            Funciones.MensajeDeAlerta("NO HAY REGISTROS QUE MOSTRAR... ")
            _Form.Close()
        End If
    End Sub

    Sub ActualizarData()
        If xbs.Current IsNot Nothing Then
            Me.E_2.Text = xbs.Current("x2").ToString.Trim
            Me.E_3.Text = String.Format("{0:#0}", xbs.Count)
        Else
            Me.E_2.Text = ""
            Me.E_3.Text = "0"
        End If
    End Sub

    Private Sub BT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT.Click
        If xbs.Current IsNot Nothing Then
            Try
                Dim xficha As New Plantilla_MostrarItem_Venta(New MostrarItemVenta_RcuperarDoc(xbs.Current("x1"), xbs.Current("x6"), xbs.Current("x7"), x))
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DTGRID_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles DTGRID.Accion
        Dim xr As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
        If MessageBox.Show("Estas Seguro Que El Documento A Rescatar No Esta Siendo Procesado Por Ningun Usuario ?", "*** Mensaje De Alerta ***", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            If MessageBox.Show("Estas De Acuerdo En Rescatar Este Documento ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                RaiseEvent RecuperarDocumento(xr("x1"), xr("x6"), xr("x7"))
                _Form.Close()
            End If
        End If
    End Sub
End Class

Public Class AbrirCtaPendientesNotasEntrega
    Implements IPlantilla_9
    Event AbrirCtaPendiente(ByVal xauto_documento As String, ByVal xauto_usuario As String)

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xsql As String = "select fecha_doc x1, nombre_pendiente x2, nombre_usuario x3, equipoestacion x4, monto_doc x5, items_doc x6, * " _
        + "from temporalventa_pendiente where tipo_doc='2' order by nombre_pendiente"

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        AddHandler xbs.PositionChanged, AddressOf ActualizarData
    End Sub

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents DTGRID As MisControles.Controles.MisGrid
    WithEvents BT As Button
    WithEvents E_1 As Label
    WithEvents E_2 As Label
    WithEvents E_3 As Label

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantilla_9.Inicializa
        _Form = CType(xform, System.Windows.Forms.Form)
        DTGRID = _Form.Controls.Find("MISGRID1", True)(0)
        BT = _Form.Controls.Find("BT_VISUALIZAR", True)(0)
        E_1 = _Form.Controls.Find("E_TITULO", True)(0)
        E_2 = _Form.Controls.Find("E_NOMBRE", True)(0)
        E_3 = _Form.Controls.Find("E_ITEMS", True)(0)
        E_1.Text = "Documentos Nota De Entregas Pendientes Por Procesar !!!"
        E_2.Text = ""
        E_3.Text = "0"

        CargarData()
    End Sub

    Sub CargarData()
        g_MiData.F_GetData(xsql, xtb)

        With DTGRID
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
        End With

        If xtb.Rows.Count = 0 Then
            Funciones.MensajeDeAlerta("NO HAY REGISTROS QUE MOSTRAR... ")
            _Form.Close()
        End If
    End Sub

    Sub ActualizarData()
        If xbs.Current IsNot Nothing Then
            Me.E_2.Text = xbs.Current("x2").ToString.Trim
            Me.E_3.Text = String.Format("{0:#0}", xbs.Count)
        Else
            Me.E_2.Text = ""
            Me.E_3.Text = "0"
        End If
    End Sub

    Private Sub DTGRID_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles DTGRID.Accion
        If MessageBox.Show("Abrir Este Documento Pendiente ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim xrw As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
            Dim xficha As New FichaVentas.V_TemporalVentaPendiente(xrw)
            RaiseEvent AbrirCtaPendiente(xficha.RegistroDato._AutoMovimiento, xficha.RegistroDato._AutomaticoUsuario)
            _Form.Close()
        End If
    End Sub

    Private Sub BT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT.Click
        Try
            Dim xrow As DataRow = CType(xbs.Current, DataRowView).Row
            Dim xreg As New FichaVentas.V_TemporalVentaPendiente(xrow)

            Dim xficha As New Plantilla_MostrarItem_Venta(New MostrarItemsVenta(xreg.RegistroDato._AutoMovimiento))
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class

Public Class AbrirCtaPendientesPedido
    Implements IPlantilla_9
    Event AbrirCtaPendiente(ByVal xauto_documento As String, ByVal xauto_usuario As String)

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xsql As String = "select fecha_doc x1, nombre_pendiente x2, nombre_usuario x3, equipoestacion x4, monto_doc x5, items_doc x6, * " _
        + "from temporalventa_pendiente where tipo_doc='4' order by nombre_pendiente"

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        AddHandler xbs.PositionChanged, AddressOf ActualizarData
    End Sub

    WithEvents _Form As System.Windows.Forms.Form
    WithEvents DTGRID As MisControles.Controles.MisGrid
    WithEvents BT As Button
    WithEvents E_1 As Label
    WithEvents E_2 As Label
    WithEvents E_3 As Label

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantilla_9.Inicializa
        _Form = CType(xform, System.Windows.Forms.Form)
        DTGRID = _Form.Controls.Find("MISGRID1", True)(0)
        BT = _Form.Controls.Find("BT_VISUALIZAR", True)(0)
        E_1 = _Form.Controls.Find("E_TITULO", True)(0)
        E_2 = _Form.Controls.Find("E_NOMBRE", True)(0)
        E_3 = _Form.Controls.Find("E_ITEMS", True)(0)
        E_1.Text = "Documentos Pedidos Pendientes Por Procesar !!!"
        E_2.Text = ""
        E_3.Text = "0"

        CargarData()
    End Sub

    Sub CargarData()
        g_MiData.F_GetData(xsql, xtb)

        With DTGRID
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
        End With

        If xtb.Rows.Count = 0 Then
            Funciones.MensajeDeAlerta("NO HAY REGISTROS QUE MOSTRAR... ")
            _Form.Close()
        End If
    End Sub

    Sub ActualizarData()
        If xbs.Current IsNot Nothing Then
            Me.E_2.Text = xbs.Current("x2").ToString.Trim
            Me.E_3.Text = String.Format("{0:#0}", xbs.Count)
        Else
            Me.E_2.Text = ""
            Me.E_3.Text = "0"
        End If
    End Sub

    Private Sub DTGRID_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles DTGRID.Accion
        If MessageBox.Show("Abrir Este Documento Pendiente ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim xrw As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
            Dim xficha As New FichaVentas.V_TemporalVentaPendiente(xrw)
            RaiseEvent AbrirCtaPendiente(xficha.RegistroDato._AutoMovimiento, xficha.RegistroDato._AutomaticoUsuario)
            _Form.Close()
        End If
    End Sub

    Private Sub BT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT.Click
        Try
            Dim xrow As DataRow = CType(xbs.Current, DataRowView).Row
            Dim xreg As New FichaVentas.V_TemporalVentaPendiente(xrow)

            Dim xficha As New Plantilla_MostrarItem_Venta(New MostrarItemsVenta(xreg.RegistroDato._AutoMovimiento))
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class
