Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Habladores
    Dim xtipo As String() = {"Pequeño", "Mediano Tipo 1", "Mediano Tipo 2", "Grande"}
    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xitems As Integer
    Dim xfichaprd As FichaProducto.Prd_Producto
    Dim xsalida As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        xtb = New DataTable("hablador")
        xbs = New BindingSource(xtb, "")
        _SalidaOk = False
    End Sub

    Property _SalidaOk() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Property _Items() As Integer
        Get
            Return xitems
        End Get
        Set(ByVal value As Integer)
            xitems = value
        End Set
    End Property

    Sub IrInicio()
        With MT_BUSCAR
            .Text = ""
            .Select()
            .Focus()
        End With
    End Sub

    Private Sub FichaProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            IrInicio()
        End If
    End Sub

    Private Sub Habladores_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _SalidaOk Then
            e.Cancel = False
        Else
            If _Items = 0 Then
                e.Cancel = False
            Else
                If MessageBox.Show("Deseas Cerrar Esta Ficha y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub Habladores_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Habladores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Habladores_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            xfichaprd = New FichaProducto.Prd_Producto
            xtb.Columns.Add("Codigo", GetType(System.String))
            xtb.Columns.Add("Nombre", GetType(System.String))
            xtb.Columns.Add("Auto", GetType(System.String))
            xtb.Columns.Add("pneto", GetType(System.Decimal))
            xtb.Columns.Add("impuesto", GetType(System.Decimal))
            xtb.Columns.Add("tasa", GetType(System.Decimal))
            xtb.Columns.Add("precio", GetType(System.Decimal))
            xtb.Columns.Add("oferta", GetType(System.String))
            xtb.Columns.Add("hasta", GetType(System.String))
            xtb.Columns.Add("pregular", GetType(System.Decimal))

            With Me.MCB_TIPO
                .DataSource = xtipo
                .SelectedIndex = 0
            End With

            Me.E_ITEMS.Text = String.Format("{0:#0}", _Items)

            With Me.MCB_BUSQUEDA
                .DataSource = xfichaprd._TipoBusqueda
                .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProducto
            End With
            Me.MT_BUSCAR.Text = ""

            With MisGrid1
                .AllowUserToDeleteRows = True

                .Columns.Add("col0", "Codigo")
                .Columns.Add("col1", "Nombre / Descripcion")
                .Columns(0).Width = 150
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "codigo"
                .Columns(1).DataPropertyName = "nombre"
                .Ocultar(3)
            End With

            AddHandler xtb.RowChanged, AddressOf Actualizar
            AddHandler xtb.RowDeleted, AddressOf Actualizar
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Actualizar()
        Dim xt As Integer = 0
        For Each dr As DataRow In xtb.Rows
            If dr.RowState <> DataRowState.Deleted Then
                xt += 1
            End If
        Next
        _Items = xt
        Me.E_ITEMS.Text = String.Format("{0:#0}", _Items)
    End Sub

    Private Sub BT_BUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR.Click
        BusquedaProducto()
    End Sub

    Sub BusquedaProducto()
        If MT_BUSCAR.r_Valor <> "" Then
            Dim xp1 As SqlParameter = Nothing
            Dim xp2 As SqlParameter = Nothing
            Dim xp3 As SqlParameter = Nothing

            Dim xsql As String = ""
            Dim xbuscar As String = ""
            Dim TipoB As String = ""

            Select Case CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto)
                Case FichaProducto.TipoBusquedaProducto.PorCodigo
                    TipoB = "CODIGO"
                Case FichaProducto.TipoBusquedaProducto.PorDescripcion
                    TipoB = "NOMBRE"
                Case FichaProducto.TipoBusquedaProducto.PorNumParte
                    TipoB = "NUMERO_PARTE"
                Case FichaProducto.TipoBusquedaProducto.PorPlu
                    TipoB = "PLU"
                Case FichaProducto.TipoBusquedaProducto.PorReferencia
                    TipoB = "REFERENCIA"
                Case FichaProducto.TipoBusquedaProducto.PorSerial
            End Select

            If CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorCodBarra Then
                'PARA BUSQUEDA DE PRODUCTOS RAPIDAS
                Const Busqueda_1 As String = "SELECT p.nombre xnom, p.codigo xcod, p.tasa xtas, p.plu xplu, p.psv, p.auto, p.estatus,p.referencia xref, " _
                                      + "p.contenido_empaque xempcompra, pdep.nombre ndep, pgrp.nombre ngrp, pmar.nombre nmar, pmed.nombre nmed, pmed.decimales xdec " _
                                      + "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto join productos_grupo pgrp on p.auto_grupo=pgrp.auto " _
                                      + "join productos_marca pmar on p.auto_marca=pmar.auto join productos_medida pmed on p.auto_medida_compra=pmed.auto " _
                                      + "where p.auto in (select auto_producto from productos_alterno where codigo=@data1);" _
                                      + "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                                      + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                                      + "where pd.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                                      + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                                      + "where p.auto in (select auto_producto from productos_alterno where codigo=@data2));" _
                                      + "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, pe.*, pm.* " _
                                      + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
                                      + "where pe.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                                      + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                                      + "where p.auto in (select auto_producto from productos_alterno where codigo=@data3)) ORDER BY PE.REFERENCIA"

                xsql = Busqueda_1
                xbuscar = MT_BUSCAR.r_Valor

                xp1 = New SqlParameter("@data1", xbuscar)
                xp2 = New SqlParameter("@data2", xbuscar)
                xp3 = New SqlParameter("@data3", xbuscar)
            Else
                If CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorSerial Then
                    Dim Tipobusq As String = ""
                    xsql = Tipobusq
                    xp1 = New SqlParameter
                    xp2 = New SqlParameter
                    xp3 = New SqlParameter
                Else
                    Dim TipoBusq As String = _
                          "SELECT p.nombre xnom, p.codigo xcod, p.tasa xtas, p.plu xplu, p.psv, p.auto, p.estatus,p.referencia xref, " _
                                      + "p.contenido_empaque xempcompra, pdep.nombre ndep, pgrp.nombre ngrp, pmar.nombre nmar, pmed.nombre nmed, pmed.decimales xdec " _
                                      + "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto join productos_grupo pgrp on p.auto_grupo=pgrp.auto " _
                                      + "join productos_marca pmar on p.auto_marca=pmar.auto join productos_medida pmed on p.auto_medida_compra=pmed.auto " _
                                      + "where p." + TipoB + " like @data1 and p.estatus_departamento='0' order by p." + TipoB + ";" _
                                      + "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                                      + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                                      + "where pd.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                                      + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                                      + "where p." + TipoB + " like @data2 and p.estatus_departamento='0');" _
                                      + "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, pe.*, pm.* " _
                                      + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
                                      + "where pe.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                                      + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                                      + "where p." + TipoB + " like @data3 and p.estatus_departamento='0') ORDER BY PE.REFERENCIA"
                    xsql = TipoBusq

                    If MT_BUSCAR.Text.Substring(0, 1) = "*" Then
                        xbuscar = "%" + MT_BUSCAR.r_Valor.Substring(1)
                    Else
                        xbuscar = MT_BUSCAR.r_Valor
                    End If

                    xp1 = New SqlParameter("@data1", xbuscar + "%")
                    xp2 = New SqlParameter("@data2", xbuscar + "%")
                    xp3 = New SqlParameter("@data3", xbuscar + "%")
                End If
            End If

            If xsql.Trim <> "" Then
                Dim xficha As New Plantilla_5(New VistaProductos, xsql, xp1, xp2, xp3)
                With xficha
                    AddHandler .CapturarId_Producto, AddressOf CargarProducto
                    .ShowDialog()
                End With
            End If

            Me.MT_BUSCAR.Text = ""
        End If
        Me.MT_BUSCAR.Select()
    End Sub

    Private Sub BT_BUS_AVANZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUS_AVANZ.Click
        BusquedaAvanzada()
    End Sub

    Sub BusquedaAvanzada()
        Dim xficha As New BusAvanzadaPrd
        With xficha
            AddHandler .LlamarReceptor, AddressOf ReceptorBusAvanzada
            .ShowDialog()
        End With
        IrInicio()
    End Sub

    Sub ReceptorBusAvanzada(ByVal xsql As String)
        Dim xficha As New Plantilla_5(New VistaProductos("1"), xsql)
        With xficha
            AddHandler .CapturarId_Producto, AddressOf CargarProducto
            .ShowDialog()
        End With
    End Sub

    Private Sub MCB_BUSQUEDA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSQUEDA.SelectedIndexChanged
        IrInicio()
    End Sub

    Private Sub MT_BUSCAR_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MT_BUSCAR.LostFocus
        If Me.MT_BUSCAR.r_Valor <> "" Then
            If Me.MCB_BUSQUEDA.SelectedIndex = FichaProducto.TipoBusquedaProducto.PorCodBarra Then
                Dim xsql As String = "select auto_producto from productos_alterno where codigo=@codigo"
                Dim xp1 As New SqlParameter("@codigo", Me.MT_BUSCAR.r_Valor)
                Dim xauto As String = ""
                xauto = F_GetString(xsql, xp1)
                If xauto = "" Then
                    MessageBox.Show("Codigo De Barra No Encontrado... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MT_BUSCAR.Text = ""
                    Me.MT_BUSCAR.Focus()
                Else
                    CargarProducto(xauto)
                End If
            End If
        End If
    End Sub

    Sub CargarProducto(ByVal id As String, Optional ByVal xtipoprecio As String = "1")
        Try
            xfichaprd.F_BuscarProducto(id)

            Dim xn As DataRow = xtb.NewRow
            xn(0) = xfichaprd.RegistroDato._CodigoProducto
            xn(1) = xfichaprd.RegistroDato._DescripcionDetallaDelProducto
            xn(2) = xfichaprd.RegistroDato._AutoProducto
            If xfichaprd.RegistroDato.f_VerificarOferta Then
                xn(3) = xfichaprd.RegistroDato._PrecioOferta._Base
                xn(4) = xfichaprd.RegistroDato._PrecioOferta._Iva
                xn(5) = xfichaprd.RegistroDato._PrecioOferta._Tasa
                xn(6) = xfichaprd.RegistroDato._PrecioOferta._Full
                xn(7) = "S"
                xn(8) = xfichaprd.RegistroDato._FechaCulminacionOferta.ToShortDateString
            Else
                xn(3) = xfichaprd.RegistroDato._PrecioDetal._Base
                xn(4) = xfichaprd.RegistroDato._PrecioDetal._Iva
                xn(5) = xfichaprd.RegistroDato._PrecioDetal._Tasa
                xn(6) = xfichaprd.RegistroDato._PrecioDetal._Full
                xn(7) = "N"
                xn(8) = ""
            End If
            xn(9) = xfichaprd.RegistroDato._PrecioDetal._Full

            xtb.Rows.Add(xn)
            xtb.AcceptChanges()

            IrInicio()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BT_IMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_IMPRIMIR.Click
        If _Items > 0 Then
            If MessageBox.Show("Estas Seguro De Imprimir Estos Habladores ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Dim dts As New DataSet
                Dim dtb_empresa As New DataTable("empresa")

                Try
                    Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal " & _
                                                         "from empresa"

                    g_MiData.F_GetData(xsql_1, dtb_empresa)
                    dts.Tables.Add(dtb_empresa)
                    dts.Tables.Add(xtb)

                    Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                    Select Case Me.MCB_TIPO.SelectedIndex
                        Case 0 : xrep += "HABLADOR_PEQ.rpt"
                        Case 1 : xrep += "HABLADOR_MED_1.rpt"
                        Case 2 : xrep += "HABLADOR_MED_2.rpt"
                        Case 3 : xrep += "HABLADOR_GDE.rpt"
                    End Select
                    Dim xficha As New _Reportes(dts, xrep, Nothing)
                    xficha.ShowDialog()

                    _SalidaOk = True
                    Me.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub
End Class