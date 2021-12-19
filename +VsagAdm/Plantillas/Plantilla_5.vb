Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema

Public Class Plantilla_5
    Event CapturarId_Producto(ByVal xauto As String, ByVal xtipoprecio As String)

    Dim xsql As String
    Dim xpar() As SqlParameter

    Dim xds As DataSet
    Dim xrel1 As DataRelation
    Dim xrel2 As DataRelation

    Dim xbs_prd As BindingSource
    Dim xbs_exi As BindingSource
    Dim xbs_pve As BindingSource

    Dim xficha As FichaProducto.Prd_Producto

    Dim xcontenido As Integer
    Dim xtipoprecio As String

    Dim xplantilla As IPlantilla_5

    Dim _devolveritem_auto As String

    Property _AutoItem_Devolver() As String
        Get
            Return _devolveritem_auto
        End Get
        Set(ByVal value As String)
            _devolveritem_auto = value
        End Set
    End Property

    Property SqlEjecutar() As String
        Get
            Return xsql
        End Get
        Set(ByVal value As String)
            xsql = value
        End Set
    End Property

    Property SqlParametros() As SqlParameter()
        Get
            Return xpar
        End Get
        Set(ByVal value As SqlParameter())
            xpar = value
        End Set
    End Property

    Property ContEmpaque() As Integer
        Get
            Return xcontenido
        End Get
        Set(ByVal value As Integer)
            xcontenido = value
        End Set
    End Property

    Property TipoPrecio() As String
        Get
            Return xtipoprecio
        End Get
        Set(ByVal value As String)
            xtipoprecio = value
        End Set
    End Property

    Private Sub Plantilla_5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False And e.Control = False) Then
            Me.MT_BUSCAR.Text = ""
            Me.MT_BUSCAR.Select()
        End If
    End Sub

    Private Sub Plantilla_5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub


    Sub Inicializa()
        Try
            Me.ContEmpaque = 1
            Me.TipoPrecio = "1"

            Me.E_ESTATUS.Visible = False

            Me.E_DEPART.Text = ""
            Me.E_DESC.Text = ""
            Me.E_GRUPO.Text = ""
            Me.E_PARTE.Text = ""
            Me.E_REF.Text = ""
            Me.E_MARCA.Text = ""

            Me.E_CONTENIDO.Text = "0"
            Me.E_EMPAQUE.Text = ""
            Me.E_EX_DISP.Text = "0.0"
            Me.E_EX_REAL.Text = "0.0"
            Me.E_EX_RES.Text = "0.0"
            Me.E_PIVA.Text = "0.0"
            Me.E_PLIQUIDA.Text = "0.0"
            Me.E_PSUGERIDO.Text = "0.0"

            Me.E_PDETAL.Text = "0.0"
            Me.E_PDETAL_REGULAR.Text = "0.0"
            Me.E_OFERTA_VALIDA.Text = ""

            xds = New DataSet
            xds = g_MiData.F_GetData(Me.SqlEjecutar, Me.SqlParametros)

            xrel1 = New DataRelation("prd_exi", xds.Tables(0).Columns("auto"), xds.Tables(1).Columns("auto_producto"))
            xds.Relations.Add(xrel1)

            xrel2 = New DataRelation("prd_pve", xds.Tables(0).Columns("auto"), xds.Tables(2).Columns("auto_producto"))
            xds.Relations.Add(xrel2)

            xbs_prd = New BindingSource(xds, "Table")
            xbs_exi = New BindingSource(xbs_prd, "prd_exi")
            xbs_pve = New BindingSource(xbs_prd, "prd_pve")

            AddHandler xbs_prd.PositionChanged, AddressOf ActualizarData
            ActualizaData()

            AddHandler xbs_pve.PositionChanged, AddressOf ActPreciosVenta
            ActPrecio()

            With MisGrid1
                .Columns.Add("col0", "Nombre/Descripcion")
                .Columns.Add("col1", "Codigo")
                .Columns.Add("col2", "Tasa")
                .Columns.Add("col3", "Plu")

                .Columns(1).Width = 150
                .Columns(2).Width = 80
                .Columns(3).Width = 80
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                AddHandler .CellFormatting, AddressOf FormatoProducto

                .DataSource = xbs_prd
                .Columns(0).DataPropertyName = "xnom"
                .Columns(1).DataPropertyName = "xcod"
                .Columns(2).DataPropertyName = "xtas"
                .Columns(3).DataPropertyName = "xplu"

                .Ocultar(5)
                .Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(1).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(2).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns(3).SortMode = DataGridViewColumnSortMode.Automatic
            End With

            With MG_EX
                .Columns.Add("col0", "Deposito")
                .Columns.Add("col1", "Ex. Real")
                .Columns.Add("col2", "Ex. Resv")
                .Columns.Add("col3", "Ex. Disp")

                .Columns(1).Width = 85
                .Columns(2).Width = 85
                .Columns(3).Width = 85
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs_exi
                .Columns(0).DataPropertyName = "nombre"
                .Columns(1).DataPropertyName = "real"
                .Columns(2).DataPropertyName = "reservada"
                .Columns(3).DataPropertyName = "disponible"
                .Ocultar(5)
                AddHandler .CellFormatting, AddressOf FormatoExistencia
            End With

            With MG_PV
                .Columns.Add("col0", "Empaque")
                .Columns.Add("col1", "Cont")
                .Columns.Add("col2", "P/Neto ")
                .Columns.Add("col3", "P/Neto ")
                .Columns.Add("col4", "P/Full ")
                .Columns.Add("col5", "P/Full ")
                AddHandler .CellFormatting, AddressOf FormatoPrecio

                .Columns(1).Width = 80
                .Columns(2).Width = 120
                .Columns(3).Width = 120
                .Columns(4).Width = 120
                .Columns(5).Width = 120
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs_pve
                .Columns(0).DataPropertyName = "xnom"
                .Columns(1).DataPropertyName = "xcont"
                .Columns(2).DataPropertyName = "xpn1"
                .Columns(3).DataPropertyName = "xpn2"
                .Columns(4).DataPropertyName = "xpf1"
                .Columns(5).DataPropertyName = "xpf2"
                .Ocultar(7)

                .Columns(3).Visible = False
                .Columns(5).Visible = False
            End With

            Me.MCHB_PRECIO.Enabled = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2

            Me.E_TOTAL.Text = xbs_prd.Count.ToString
            Me.MisGrid1.Select()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub FormatoProducto(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If MisGrid1.Rows(e.RowIndex).Cells("estatus").Value.ToString.Trim <> "Activo" Then
            MisGrid1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Sub FormatoExistencia(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Dim xformato As String = "#0.000"
        Dim xformato2 As String = "#0.00"
        Dim xv As Integer = 0

        If xbs_pve.Current IsNot Nothing Then
            If e.ColumnIndex >= 1 Then
                Dim xd As String = xbs_pve.Current("decimales").ToString

                Integer.TryParse(xd, xv)
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
                e.Value = e.Value / Me.ContEmpaque
                e.Value = Format(e.Value, IIf(xv > 2, xformato, xformato2))
            End If
        Else
            If e.ColumnIndex >= 1 Then
                Dim xd As String = xbs_prd.Current("xdec").ToString

                Integer.TryParse(xd, xv)
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
                e.Value = e.Value / Me.ContEmpaque
                e.Value = Format(e.Value, IIf(xv > 2, xformato, xformato2))
            End If
        End If
    End Sub

    Sub FormatoPrecio(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 1 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Sub New(ByVal xtipoplantilla As IPlantilla_5, ByVal xsql As String, ByVal ParamArray xlista As SqlParameter())
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.SqlEjecutar = xsql
        Me.SqlParametros = xlista

        xplantilla = xtipoplantilla
        _AutoItem_Devolver = ""
    End Sub

    Private Sub Plantilla_5_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
        If xplantilla._PrecioMostrar <> "1" Then
            Me.MCHB_PRECIO.Checked = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, True, False)
        End If
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizaData()
    End Sub

    Sub ActualizaData()
        Try
            If xbs_prd.Current IsNot Nothing Then
                Dim xrow As DataRow = CType(xbs_prd.Current, DataRowView).Row

                Dim xprd As New FichaProducto.Prd_Producto
                xprd.F_BuscarProducto(xrow("auto").ToString, FichaProducto.Prd_Producto.ModoBusqueda.Automatico)

                Me.E_DESC.Text = xprd.RegistroDato._DescripcionDetallaDelProducto
                Me.E_DEPART.Text = xprd.RegistroDato._NombreDepartamento
                Me.E_GRUPO.Text = xprd.RegistroDato._NombreGrupo
                Me.E_MARCA.Text = xprd.RegistroDato._NombreMarca
                Me.E_REF.Text = xprd.RegistroDato._Referencia
                Me.E_EMPAQUE.Text = xprd.RegistroDato._NombreEmpaqueCompra
                Me.E_CONTENIDO.Text = xprd.RegistroDato._ContEmpqCompra
                Me.E_PSUGERIDO.Text = String.Format("{0:#0.00}", xprd.RegistroDato._PrecioSugerido)

                If xprd.RegistroDato.f_VerificarOferta Then
                    Me.E_PDETAL.Text = String.Format("{0:#,#0.00}", xprd.RegistroDato._PrecioOferta._Full)
                    Me.E_PDETAL_REGULAR.Text = String.Format("{0:#,#0.00}", xprd.RegistroDato._PrecioDetal._Full)
                    Me.E_OFERTA_VALIDA.Text = xprd.RegistroDato._FechaCulminacionOferta.ToShortDateString
                Else
                    Me.E_PDETAL.Text = String.Format("{0:#,#0.00}", xprd.RegistroDato._PrecioDetal._Full)
                    Me.E_PDETAL_REGULAR.Text = String.Format("{0:#,#0.00}", xprd.RegistroDato._PrecioDetal._Full)
                    Me.E_OFERTA_VALIDA.Text = ""
                End If

                Me.E_PIVA.Text = "0.00"
                Me.E_PLIQUIDA.Text = "0.00"

                If xrow("estatus").ToString.Trim <> "Activo" Then
                    Me.E_ESTATUS.Visible = True
                Else
                    E_ESTATUS.Visible = False
                End If

                If MCHB_EMPAQUE.Checked Then
                    Me.ContEmpaque = 1
                Else
                    Me.ContEmpaque = xrow("xempcompra")
                End If

                ActualizaExistencia()
                ActualizaTipoEmpaque()
                ActualizaPrecios()
            Else
                Me.ContEmpaque = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizaTipoEmpaque()
        If MCHB_EMPAQUE.Checked Then
            Me.ContEmpaque = 1
            Me.E_EMPAQUE.Text = "UNIDAD"
            Me.E_CONTENIDO.Text = Me.ContEmpaque.ToString
        Else
            If xbs_pve.Current IsNot Nothing Then
                Me.ContEmpaque = xbs_pve.Current("xcont")
                Me.E_EMPAQUE.Text = xbs_pve.Current("xnom")
                Me.E_CONTENIDO.Text = Me.ContEmpaque.ToString
            Else
                Me.ContEmpaque = xbs_prd.Current("xempcompra")
                Me.E_EMPAQUE.Text = xbs_prd.Current("nmed")
                Me.E_CONTENIDO.Text = Me.ContEmpaque.ToString
            End If
        End If

        ActualizaExistencia()
    End Sub

    Sub ActPreciosVenta(ByVal sender As Object, ByVal e As System.EventArgs)
        ActPrecio()
    End Sub

    Sub ActPrecio()
        If xbs_prd.Current IsNot Nothing Then
            If xbs_pve.Current IsNot Nothing Then
                Dim xiva As Decimal = 0
                Dim xliq As Decimal = 0

                If Me.TipoPrecio = 1 Then
                    xiva = (xbs_pve.Current("xpn1") * xbs_prd.Current("xtas") / 100)
                    xiva = Decimal.Round(xiva, 2, MidpointRounding.AwayFromZero)
                    xliq = xbs_pve.Current("xpf1") / xbs_pve.Current("xcont")
                Else
                    xiva = (xbs_pve.Current("xpn2") * xbs_prd.Current("xtas") / 100)
                    xiva = Decimal.Round(xiva, 2, MidpointRounding.AwayFromZero)
                    xliq = xbs_pve.Current("xpf2") / xbs_pve.Current("xcont")
                End If

                Me.E_PIVA.Text = String.Format("{0:#,#0.00}", xiva)
                Me.E_PLIQUIDA.Text = String.Format("{0:#,#0.00}", xliq)

                ActualizaTipoEmpaque()
            End If
        End If
    End Sub

    Private Sub MCHB_EMPAQUE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_EMPAQUE.CheckedChanged
        If xbs_prd.Current IsNot Nothing Then
            ActualizaTipoEmpaque()
            Me.MisGrid1.Select()
        End If
    End Sub

    Private Sub BT_BUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR.Click
        If MT_BUSCAR.r_Valor <> "" Then
            Try
                Dim xbuscar As String = MT_BUSCAR.r_Valor

                If MT_BUSCAR.Text.Substring(0, 1) = "*" Then
                    xbuscar = "%" + MT_BUSCAR.r_Valor.Substring(1)
                End If

                Dim xxp1 As SqlParameter
                Dim xxp2 As SqlParameter
                Dim xxp3 As SqlParameter
                Dim xxp4 As SqlParameter

                xxp1 = New SqlParameter("@data1", xbuscar + "%")
                xxp2 = New SqlParameter("@data2", xbuscar + "%")
                xxp3 = New SqlParameter("@data3", xbuscar + "%")
                xxp4 = New SqlParameter("@limite", g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._LimiteProductosMostrar_AdmBusquedaNormal)

                xds.Tables(2).Rows.Clear()
                xds.Tables(1).Rows.Clear()
                xds.Tables(0).Rows.Clear()

                g_MiData.F_GetData(Me.SqlEjecutar, xds, xxp1, xxp2, xxp3, xxp4)
                Me.E_TOTAL.Text = xbs_prd.Count.ToString
                ActualizaExistencia()
                ActualizaPrecios()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        Me.MisGrid1.Select()
    End Sub

    Sub ActualizaExistencia()
        If xbs_prd.Current IsNot Nothing Then
            Dim xformato As String = "#0.000"
            Dim xformato2 As String = "#0.00"
            Dim xv As Integer = 0
            Dim xd As String = ""

            If xbs_pve.Current IsNot Nothing Then
                xd = xbs_pve.Current("decimales").ToString()
            Else
                xd = xbs_prd.Current("xdec").ToString()
            End If
            Integer.TryParse(xd, xv)

            Dim x1 As Single = 0
            Dim x2 As Single = 0
            Dim x3 As Single = 0

            For Each dr As DataRowView In xbs_exi
                x1 += dr.Row("real") / Me.ContEmpaque
                x2 += dr.Row("reservada") / Me.ContEmpaque
                x3 += dr.Row("disponible") / Me.ContEmpaque
            Next

            Me.E_EX_REAL.Text = Format(x1, IIf(xv > 2, xformato, xformato2))
            Me.E_EX_RES.Text = Format(x2, IIf(xv > 2, xformato, xformato2))
            Me.E_EX_DISP.Text = Format(x3, IIf(xv > 2, xformato, xformato2))

            Me.xbs_exi.CurrencyManager.Refresh()
        End If
    End Sub

    Sub ActualizaPrecios()
        If xbs_prd.Current IsNot Nothing Then
            Dim xtasa As Single = xbs_prd.Current("xtas")

            For Each dr As DataRowView In xbs_pve
                Dim xf As Decimal = Decimal.Round(dr.Row("xpn1") + (dr.Row("xpn1") * xtasa / 100), 2, MidpointRounding.AwayFromZero)
                dr.Row("xpf1") = String.Format("{0:#,#0.00}", xf)

                Dim xf2 As Decimal = Decimal.Round(dr.Row("xpn2") + (dr.Row("xpn2") * xtasa / 100), 2, MidpointRounding.AwayFromZero)
                dr.Row("xpf2") = String.Format("{0:#,#0.00}", xf2)
            Next

            ActPrecio()
            ActualizaExistencia()
        End If
    End Sub

    Private Sub MisGrid1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid1.Accion
        Dim xreg As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
        _AutoItem_Devolver = xreg("auto")
        RaiseEvent CapturarId_Producto(xreg("auto"), TipoPrecio)
        Me.Close()
    End Sub

    Private Sub MG_EX_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_EX.Accion
        Dim xreg As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
        xplantilla.AccionExistencia(xbs_prd.Current("auto"), xreg("auto_deposito"))

        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()
        Me.Select()
    End Sub

    Private Sub MG_PV_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_PV.Accion
        Dim xreg As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
        xplantilla.AccionPrecios(xbs_prd.Current("auto"), xreg("referencia"), TipoPrecio)

        Me.MT_BUSCAR.Select()
        Me.MT_BUSCAR.Focus()
        Me.Select()
    End Sub

    Private Sub MisCheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_PRECIO.CheckedChanged
        If Me.MCHB_PRECIO.Checked Then
            Me.TipoPrecio = "2"
        Else
            Me.TipoPrecio = "1"
        End If

        If Me.TipoPrecio = "2" Then
            Me.MG_PV.Columns(3).Visible = True
            Me.MG_PV.Columns(5).Visible = True

            Me.MG_PV.Columns(2).Visible = False
            Me.MG_PV.Columns(4).Visible = False
        Else
            Me.MG_PV.Columns(3).Visible = False
            Me.MG_PV.Columns(5).Visible = False

            Me.MG_PV.Columns(2).Visible = True
            Me.MG_PV.Columns(4).Visible = True
        End If

        ActPrecio()
        Me.MisGrid1.Select()
        Me.Select()
    End Sub
End Class

Public Interface IPlantilla_5
    Sub AccionExistencia(ByVal xauto_1 As String, ByVal xauto_2 As String)
    Sub AccionPrecios(ByVal xauto_1 As String, ByVal xauto_2 As String, ByVal xauto3 As String)
    ReadOnly Property _PrecioMostrar() As String
End Interface

Class VistaProductos
    Implements IPlantilla_5
    Dim xprecio_a_mostrar As String

    Sub New(Optional ByVal xpreciomostrar As String = "1")
        xprecio_a_mostrar = xpreciomostrar
    End Sub

    Public Sub AccionExistencia(ByVal xauto_1 As String, ByVal xauto_2 As String) Implements IPlantilla_5.AccionExistencia
        Try
            Dim xprddep As New FichaProducto.Prd_Deposito
            xprddep.F_BuscarDepositoProducto(xauto_1, xauto_2)

            Dim xficha As New FichaDeposito(xprddep)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub AccionPrecios(ByVal xauto_1 As String, ByVal xauto_2 As String, ByVal xauto_3 As String) Implements IPlantilla_5.AccionPrecios
    End Sub

    Public ReadOnly Property _PrecioMostrar() As String Implements IPlantilla_5._PrecioMostrar
        Get
            Return xprecio_a_mostrar
        End Get
    End Property
End Class

Class VistaVentas
    Implements IPlantilla_5

    Dim xprecio_a_mostrar As String

    Sub New(Optional ByVal xpreciomostrar As String = "1")
        xprecio_a_mostrar = xpreciomostrar
    End Sub

    Public Sub AccionExistencia(ByVal xauto_1 As String, ByVal xauto_2 As String) Implements IPlantilla_5.AccionExistencia
        Dim xficha As New ExistenciaReservada(xauto_1)
        With xficha
            .ShowDialog()
        End With
    End Sub

    Public Sub AccionPrecios(ByVal xauto_1 As String, ByVal xauto_2 As String, ByVal xauto_3 As String) Implements IPlantilla_5.AccionPrecios
        VerCostoUtilidad(xauto_1, xauto_2, xauto_3)
    End Sub

    Public ReadOnly Property _PrecioMostrar() As String Implements IPlantilla_5._PrecioMostrar
        Get
            Return xprecio_a_mostrar
        End Get
    End Property
End Class