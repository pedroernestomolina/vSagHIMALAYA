Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient


Public Class Plant_MostrarItem_Compra
    Dim xplantilla As IPlant_MostrarItem_Compra


    Property _MiPlantilla() As IPlant_MostrarItem_Compra
        Get
            Return Me.xplantilla
        End Get
        Set(ByVal value As IPlant_MostrarItem_Compra)
            Me.xplantilla = value
        End Set
    End Property


    Sub New(ByVal xtipoplantilla As IPlant_MostrarItem_Compra)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._MiPlantilla = xtipoplantilla
    End Sub

    Private Sub Plant_MostrarItem_Compra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plant_MostrarItem_Compra_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            Me._MiPlantilla.Inicializa(Me)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub
End Class


Public Interface IPlant_MostrarItem_Compra
    Sub Inicializa(ByVal xform As Object)
End Interface


Class MostrarItem_DocCompraPendiente
    Implements IPlant_MostrarItem_Compra

    WithEvents _MiForm As Form
    WithEvents L_1 As Label
    WithEvents L_2 As Label
    WithEvents L_3 As Label
    WithEvents L_4 As Label
    WithEvents L_5 As Label
    WithEvents L_6 As Label
    WithEvents L_7 As Label
    WithEvents L_8 As Label
    WithEvents MG_1 As MisControles.Controles.MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xp1 As SqlParameter
    Dim xsql_1 As String = "select * from temporal_compra_pendiente where auto_doc=@auto_doc"
    Dim xsql_2 As String = "select producto x1, cantidad x2, decimalesmedida x3, * " _
                       + "from temporal_compra_pendientedetalle where auto_doc=@auto_doc order by producto"

    Dim xtmp_pend As FichaCompras.c_TemporalCompraPendiente
    Dim xtmp_pend_det As FichaCompras.c_TemporalCompraPendienteDetalle

    Sub New(ByVal xautodoc As String)
        Try
            xtb = New DataTable
            xbs = New BindingSource(xtb, "")
            xp1 = New SqlParameter("@auto_doc", xautodoc)

            xtmp_pend = New FichaCompras.c_TemporalCompraPendiente
            xtmp_pend_det = New FichaCompras.c_TemporalCompraPendienteDetalle
            xtmp_pend.F_BuscarCargar(xautodoc)

            AddHandler xbs.PositionChanged, AddressOf MostrarData
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub MostrarData()
        Try
            Dim xformato As String = ".000"
            If xbs.Current IsNot Nothing Then
                Dim xrw As DataRow = CType(xbs.Current, DataRowView).Row
                xtmp_pend_det.M_CargarRegistro(xrw)

                If xtmp_pend_det.RegistroDato._NumeroDecimalesMedida > 0 Then
                    xformato = xformato.Substring(0, xtmp_pend_det.RegistroDato._NumeroDecimalesMedida + 1)
                Else
                    xformato = ""
                End If

                Me.L_1.Text = xtmp_pend_det.RegistroDato._NombreProducto
                Me.L_2.Text = xtmp_pend_det.RegistroDato._CodigoProductoProveedor
                Me.L_3.Text = xtmp_pend_det.RegistroDato._NombreEmpaque
                Me.L_4.Text = xtmp_pend_det.RegistroDato._ContenidoEmpaque.ToString
                Me.L_5.Text = String.Format("{0:#0" + xformato + "}", xtmp_pend_det.RegistroDato._CantidadItems)
                Me.L_6.Text = String.Format("{0:#0.00}", xtmp_pend_det.RegistroDato._CostoUnitario)
                Me.L_7.Text = String.Format("{0:#0.00}", xtmp_pend_det.RegistroDato._TasaIva) + "%"
            Else
                LimpiarControles()
            End If
        Catch ex As Exception
            Funciones.MensajeDeAlerta(ex.Message)
        End Try
    End Sub

    Public Sub Inicializa(ByVal xform As Object) Implements IPlant_MostrarItem_Compra.Inicializa
        _MiForm = CType(xform, System.Windows.Forms.Form)
        L_1 = _MiForm.Controls.Find("L_1", True)(0)
        L_2 = _MiForm.Controls.Find("L_2", True)(0)
        L_3 = _MiForm.Controls.Find("L_3", True)(0)
        L_4 = _MiForm.Controls.Find("L_4", True)(0)
        L_5 = _MiForm.Controls.Find("L_5", True)(0)
        L_6 = _MiForm.Controls.Find("L_6", True)(0)
        L_7 = _MiForm.Controls.Find("L_7", True)(0)
        L_7 = _MiForm.Controls.Find("L_7", True)(0)
        L_8 = _MiForm.Controls.Find("L_8", True)(0)
        MG_1 = _MiForm.Controls.Find("MG_1", True)(0)

        If xtmp_pend.RegistroDato._TipoDocumento = TipoDocumentoCompra.Factura Then
            _MiForm.Text = "COMPRA - Pendiente"
        ElseIf xtmp_pend.RegistroDato._TipoDocumento = TipoDocumentoCompra.OrdenCompra Then
            _MiForm.Text = "ORDEN DE COMPRA - Pendiente"
        End If

        InicializarControles()
        Me.L_8.Text = xbs.Count.ToString
    End Sub

    Sub LimpiarControles()
        L_1.Text = ""
        L_2.Text = ""
        L_3.Text = ""
        L_4.Text = "0"
        L_5.Text = "0.0"
        L_6.Text = "0.0"
        L_7.Text = "0.0%"
        L_8.Text = "0"
    End Sub

    Sub InicializarControles()
        LimpiarControles()

        g_MiData.F_GetData(xsql_2, xtb, xp1)
        With MG_1
            .Columns.Add("col0", "Descripcion")
            .Columns.Add("col1", "Cant")
            .Columns(1).Width = 80
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xbs
            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            AddHandler .CellFormatting, AddressOf MiFormato
            .Ocultar(3)
            .Select()
            .Focus()
        End With
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 1 Then
            Dim xformato As String = "#0.000"

            Dim xd As String = sender.Rows(e.RowIndex).Cells("x3").Value.ToString
            Dim xv As Integer = 0
            Integer.TryParse(xd, xv)
            If xv > 0 Then
                xv += 1
            End If
            e.CellStyle.Format = xformato.Substring(0, 2 + xv)
        End If
    End Sub
End Class

Class MostrarItem_RcuperarDocCompra
    Implements IPlant_MostrarItem_Compra

    WithEvents _MiForm As Form
    WithEvents L_1 As Label
    WithEvents L_2 As Label
    WithEvents L_3 As Label
    WithEvents L_4 As Label
    WithEvents L_5 As Label
    WithEvents L_6 As Label
    WithEvents L_7 As Label
    WithEvents L_8 As Label
    WithEvents MG_1 As MisControles.Controles.MisGrid

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xp1 As SqlParameter
    Dim xp2 As SqlParameter
    Dim xp3 As SqlParameter
    Dim xp4 As SqlParameter
    Dim xsql As String = "select producto x1, cantidad x2, decimalesmedida x3, * " _
                          + "from temporal_compra where fecha=@fecha and tipodocumento=@tipodocumento and idunico=@idunico and autousuario=@autousuario order by producto "

    Dim xtmp_compra As FichaCompras.c_TemporalCompra

    Sub New(ByVal xfecha As Date, ByVal xid_unico As String, ByVal xauto_usuario As String, ByVal xtipodoc As TipoDocumentoCompra)
        Try
            xtb = New DataTable
            xbs = New BindingSource(xtb, "")
            xp1 = New SqlParameter("@fecha", xfecha)
            Select Case xtipodoc
                Case TipoDocumentoCompra.Factura : xp2 = New SqlParameter("@tipodocumento", "1")
                Case TipoDocumentoCompra.OrdenCompra : xp2 = New SqlParameter("@tipodocumento", "4")
            End Select
            xp3 = New SqlParameter("@idunico", xid_unico)
            xp4 = New SqlParameter("@autousuario", xauto_usuario)

            xtmp_compra = New FichaCompras.c_TemporalCompra
            AddHandler xbs.PositionChanged, AddressOf MostrarData
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub MostrarData()
        Try
            Dim xformato As String = ".000"
            If xbs.Current IsNot Nothing Then
                Dim xrw As DataRow = CType(xbs.Current, DataRowView).Row
                xtmp_compra.M_CargarRegistro(xrw)

                If xtmp_compra.RegistroDato._NumeroDecimalesMedida > 0 Then
                    xformato = xformato.Substring(0, xtmp_compra.RegistroDato._NumeroDecimalesMedida + 1)
                Else
                    xformato = ""
                End If

                Me.L_1.Text = xtmp_compra.RegistroDato._NombreProducto
                Me.L_2.Text = xtmp_compra.RegistroDato._CodigoProductoProveedor
                Me.L_3.Text = xtmp_compra.RegistroDato._NombreEmpaque
                Me.L_4.Text = xtmp_compra.RegistroDato._ContenidoEmpaque.ToString
                Me.L_5.Text = String.Format("{0:#0" + xformato + "}", xtmp_compra.RegistroDato._CantidadItems)
                Me.L_6.Text = String.Format("{0:#0.00}", xtmp_compra.RegistroDato._CostoUnitario)
                Me.L_7.Text = String.Format("{0:#0.00}", xtmp_compra.RegistroDato._TasaIva) + "%"
            Else
                LimpiarControles()
            End If
        Catch ex As Exception
            Funciones.MensajeDeAlerta(ex.Message)
        End Try
    End Sub

    Public Sub Inicializa(ByVal xform As Object) Implements IPlant_MostrarItem_Compra.Inicializa
        _MiForm = CType(xform, System.Windows.Forms.Form)
        L_1 = _MiForm.Controls.Find("L_1", True)(0)
        L_2 = _MiForm.Controls.Find("L_2", True)(0)
        L_3 = _MiForm.Controls.Find("L_3", True)(0)
        L_4 = _MiForm.Controls.Find("L_4", True)(0)
        L_5 = _MiForm.Controls.Find("L_5", True)(0)
        L_6 = _MiForm.Controls.Find("L_6", True)(0)
        L_7 = _MiForm.Controls.Find("L_7", True)(0)
        L_7 = _MiForm.Controls.Find("L_7", True)(0)
        L_8 = _MiForm.Controls.Find("L_8", True)(0)
        MG_1 = _MiForm.Controls.Find("MG_1", True)(0)

        _MiForm.Text = "RECUPERAR DOCUMENTO"

        InicializarControles()
        Me.L_8.Text = xbs.Count.ToString
    End Sub

    Sub LimpiarControles()
        L_1.Text = ""
        L_2.Text = ""
        L_3.Text = ""
        L_4.Text = "0"
        L_5.Text = "0.0"
        L_6.Text = "0.0"
        L_7.Text = "0.0%"
        L_8.Text = "0"
    End Sub

    Sub InicializarControles()
        LimpiarControles()

        g_MiData.F_GetData(xsql, xtb, xp1, xp2, xp3, xp4)
        With MG_1
            .Columns.Add("col0", "Descripcion")
            .Columns.Add("col1", "Cant")
            .Columns(1).Width = 80
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .DataSource = xbs
            .Columns(0).DataPropertyName = "x1"
            .Columns(1).DataPropertyName = "x2"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            AddHandler .CellFormatting, AddressOf MiFormato
            .Ocultar(3)
            .Select()
            .Focus()
        End With
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 1 Then
            Dim xformato As String = "#0.000"

            Dim xd As String = sender.Rows(e.RowIndex).Cells("x3").Value.ToString
            Dim xv As Integer = 0
            Integer.TryParse(xd, xv)
            If xv > 0 Then
                xv += 1
            End If
            e.CellStyle.Format = xformato.Substring(0, 2 + xv)
        End If
    End Sub
End Class
