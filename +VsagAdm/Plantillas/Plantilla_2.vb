Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

''' <summary>
''' DEFINE PROCEDMIENTOS GLOBAL DE LA PLANTILLA
''' </summary>
Public Class Plantilla_2
    Event EnviarAuto(ByVal xauto As String)
    WithEvents xmetodo As IPlantilla_2

    Private Sub Plantilla_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Sub New(ByVal xtipo_metodo As IPlantilla_2, ByVal xsql As String, ByVal ParamArray xlista() As SqlParameter)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        xmetodo = xtipo_metodo
        xmetodo._SqlBusqueda = xsql
        xmetodo._SqlParametros = xlista
    End Sub

    Private Sub xmetodo_AutoEnviar(ByVal xauto As String) Handles xmetodo.AutoEnviar
        RaiseEvent EnviarAuto(xauto)
        Me.Close()
    End Sub

    Private Sub Plantilla_2_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            Me.Text = xmetodo._TituloVentana
            Me.E_TITULO.Text = xmetodo._TituloFormulario

            xmetodo._Controles(Me.MisGrid1, Me.E_1, Me.E_2, Me.E_3, Me.E_4, Me.E_5, Me.E_6)
            Me.E_REGISTROS.Text = xmetodo._TotalRegistros.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje de Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub Plantilla_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class

''' <summary>
''' DEFINE INTERFAZ A EJECUTAR
''' </summary>
Public Interface IPlantilla_2
    ReadOnly Property _TituloFormulario() As String
    ReadOnly Property _TituloVentana() As String
    ReadOnly Property _TotalRegistros() As Integer
    Property _SqlBusqueda() As String
    Property _SqlParametros() As SqlParameter()

    Sub _Controles(ByRef xgrid As MisControles.Controles.MisGrid, ByRef E_1 As Label, ByRef E_2 As Label, ByRef E_3 As Label, _
                   ByRef E_4 As Label, ByRef E_5 As Label, ByRef E_6 As Label)
    Event AutoEnviar(ByVal xauto As String)
End Interface

''' <summary>
''' CLASE BUSQUEDA CLIENTE
''' </summary>
Public Class BusquedaCliente
    Implements IPlantilla_2

    Public Event AutoEnviar(ByVal xauto As String) Implements IPlantilla_2.AutoEnviar

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xregistro As FichaClientes.c_Clientes

    Dim xsql As String
    Dim xsql_parametros As SqlParameter()

    Dim xgrid As MisControles.Controles.MisGrid
    Dim e_1 As Label
    Dim e_2 As Label
    Dim e_3 As Label
    Dim e_4 As Label
    Dim e_5 As Label
    Dim e_6 As Label

    Property MGrid() As MisControles.Controles.MisGrid
        Get
            Return xgrid
        End Get
        Set(ByVal value As MisControles.Controles.MisGrid)
            xgrid = value
        End Set
    End Property

    Property Etiqueta_1() As Label
        Get
            Return e_1
        End Get
        Set(ByVal value As Label)
            e_1 = value
        End Set
    End Property

    Property Etiqueta_2() As Label
        Get
            Return e_2
        End Get
        Set(ByVal value As Label)
            e_2 = value
        End Set
    End Property

    Property Etiqueta_3() As Label
        Get
            Return e_3
        End Get
        Set(ByVal value As Label)
            e_3 = value
        End Set
    End Property

    Property Etiqueta_4() As Label
        Get
            Return e_4
        End Get
        Set(ByVal value As Label)
            e_4 = value
        End Set
    End Property

    Property Etiqueta_5() As Label
        Get
            Return e_5
        End Get
        Set(ByVal value As Label)
            e_5 = value
        End Set
    End Property

    Property Etiqueta_6() As Label
        Get
            Return e_6
        End Get
        Set(ByVal value As Label)
            e_6 = value
        End Set
    End Property

    Sub CargarData()
        g_MiData.F_GetData(_SqlBusqueda, xtb, _SqlParametros)
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xregistro.M_CargarFicha(CType(xbs.Current, System.Data.DataRowView).Row)
            Me.Etiqueta_1.Text = xregistro.RegistroDato.c_RIF.c_Texto
            Me.Etiqueta_2.Text = xregistro.RegistroDato.c_CodigoCliente.c_Texto
            Me.Etiqueta_3.Text = xregistro.RegistroDato.c_NombreRazonSocial.c_Texto
            Me.Etiqueta_4.Text = xregistro.RegistroDato.c_ContactarA.c_Texto
            Me.Etiqueta_5.Text = xregistro.RegistroDato.c_DirFiscal.c_Texto

            If xregistro.RegistroDato.r_EstatusDelCliente Then
                Me.Etiqueta_6.Text = "ACTIVO"
                Me.Etiqueta_6.ForeColor = Color.Blue
            Else
                Me.Etiqueta_6.Text = "SUSPENDIDO"
                Me.Etiqueta_6.ForeColor = Color.Maroon
            End If
        Else
            Me.Etiqueta_1.Text = ""
            Me.Etiqueta_2.Text = ""
            Me.Etiqueta_3.Text = ""
            Me.Etiqueta_4.Text = ""
            Me.Etiqueta_5.Text = ""
            Me.Etiqueta_6.Text = ""
        End If
    End Sub

    Sub RetornarAuto(ByVal xrow As System.Windows.Forms.DataGridViewRow)
        RaiseEvent AutoEnviar(xrow.Cells("auto").Value.ToString())
    End Sub

    Public Sub _Controles(ByRef xgrid As MisControles.Controles.MisGrid, ByRef E_1 As System.Windows.Forms.Label, _
                          ByRef E_2 As System.Windows.Forms.Label, ByRef E_3 As System.Windows.Forms.Label, _
                          ByRef E_4 As System.Windows.Forms.Label, ByRef E_5 As System.Windows.Forms.Label, _
                          ByRef E_6 As System.Windows.Forms.Label) Implements IPlantilla_2._Controles

        Try
            xtb = New DataTable
            xregistro = New FichaClientes.c_Clientes
            AddHandler xgrid.Accion, AddressOf RetornarAuto

            MGrid = xgrid
            Etiqueta_1 = E_1
            Etiqueta_2 = E_2
            Etiqueta_3 = E_3
            Etiqueta_4 = E_4
            Etiqueta_5 = E_5
            Etiqueta_6 = E_6

            CargarData()
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With xgrid
                .Columns.Add("col0", "Nombre")
                .Columns.Add("col1", "Telefono")
                .Columns.Add("col2", "Celular")

                .Columns(1).Width = 130
                .Columns(2).Width = 130
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                AddHandler .CellFormatting, AddressOf NuevoFormato

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Columns(1).DataPropertyName = "tel"
                .Columns(2).DataPropertyName = "cel"
                .Ocultar(4)
            End With
        Catch ex As Exception
            Throw New Exception("CARGA DEL GRID:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub NuevoFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If MGrid.Rows(e.RowIndex).Cells("estatus").Value.ToString.Trim.ToUpper <> "ACTIVO" Then
            MGrid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Public ReadOnly Property _TotalRegistros() As Integer Implements IPlantilla_2._TotalRegistros
        Get
            Return xbs.Count
        End Get
    End Property

    Public ReadOnly Property _TituloFormulario() As String Implements IPlantilla_2._TituloFormulario
        Get
            Return "Listado De Clientes"
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_2._TituloVentana
        Get
            Return "Clientes"
        End Get
    End Property

    Public Property _SqlBusqueda() As String Implements IPlantilla_2._SqlBusqueda
        Get
            Return xsql
        End Get
        Set(ByVal value As String)
            xsql = value
        End Set
    End Property

    Public Property _SqlParametros() As System.Data.SqlClient.SqlParameter() Implements IPlantilla_2._SqlParametros
        Get
            Return xsql_parametros
        End Get
        Set(ByVal value As System.Data.SqlClient.SqlParameter())
            xsql_parametros = value
        End Set
    End Property
End Class

''' <summary>
''' CLASE BUSQUEDA PROVEEDOR
''' </summary>
Public Class BusquedaProveedor
    Implements IPlantilla_2

    Public Event AutoEnviar(ByVal xauto As String) Implements IPlantilla_2.AutoEnviar

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xregistro As FichaProveedores.c_Proveedor

    Dim xsql As String
    Dim xsql_parametros As SqlParameter()

    Dim xgrid As MisControles.Controles.MisGrid
    Dim e_1 As Label
    Dim e_2 As Label
    Dim e_3 As Label
    Dim e_4 As Label
    Dim e_5 As Label
    Dim e_6 As Label

    Property MGrid() As MisControles.Controles.MisGrid
        Get
            Return xgrid
        End Get
        Set(ByVal value As MisControles.Controles.MisGrid)
            xgrid = value
        End Set
    End Property

    Property Etiqueta_1() As Label
        Get
            Return e_1
        End Get
        Set(ByVal value As Label)
            e_1 = value
        End Set
    End Property

    Property Etiqueta_2() As Label
        Get
            Return e_2
        End Get
        Set(ByVal value As Label)
            e_2 = value
        End Set
    End Property

    Property Etiqueta_3() As Label
        Get
            Return e_3
        End Get
        Set(ByVal value As Label)
            e_3 = value
        End Set
    End Property

    Property Etiqueta_4() As Label
        Get
            Return e_4
        End Get
        Set(ByVal value As Label)
            e_4 = value
        End Set
    End Property

    Property Etiqueta_5() As Label
        Get
            Return e_5
        End Get
        Set(ByVal value As Label)
            e_5 = value
        End Set
    End Property

    Property Etiqueta_6() As Label
        Get
            Return e_6
        End Get
        Set(ByVal value As Label)
            e_6 = value
        End Set
    End Property

    Sub CargarData()
        g_MiData.F_GetData(_SqlBusqueda, xtb, _SqlParametros)
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xregistro.M_CargarFicha(CType(xbs.Current, System.Data.DataRowView).Row)
            Me.Etiqueta_1.Text = xregistro.RegistroDato.c_RIF.c_Texto
            Me.Etiqueta_2.Text = xregistro.RegistroDato.c_CodigoProveedor.c_Texto
            Me.Etiqueta_3.Text = xregistro.RegistroDato.c_NombreRazonSocial.c_Texto
            Me.Etiqueta_4.Text = xregistro.RegistroDato.c_ContactarA.c_Texto
            Me.Etiqueta_5.Text = xregistro.RegistroDato.c_DirFiscal.c_Texto

            If xregistro.RegistroDato._EstatusDelProveedor Then
                Me.Etiqueta_6.Text = "ACTIVO"
                Me.Etiqueta_6.ForeColor = Color.Blue
            Else
                Me.Etiqueta_6.Text = "SUSPENDIDO"
                Me.Etiqueta_6.ForeColor = Color.Maroon
            End If
        Else
            Me.Etiqueta_1.Text = ""
            Me.Etiqueta_2.Text = ""
            Me.Etiqueta_3.Text = ""
            Me.Etiqueta_4.Text = ""
            Me.Etiqueta_5.Text = ""
            Me.Etiqueta_6.Text = ""
        End If
    End Sub

    Sub RetornarAuto(ByVal xrow As System.Windows.Forms.DataGridViewRow)
        RaiseEvent AutoEnviar(xrow.Cells("auto").Value.ToString())
    End Sub

    Public Sub _Controles(ByRef xgrid As MisControles.Controles.MisGrid, ByRef E_1 As System.Windows.Forms.Label, _
                          ByRef E_2 As System.Windows.Forms.Label, ByRef E_3 As System.Windows.Forms.Label, _
                          ByRef E_4 As System.Windows.Forms.Label, ByRef E_5 As System.Windows.Forms.Label, _
                          ByRef E_6 As System.Windows.Forms.Label) Implements IPlantilla_2._Controles

        Try
            xtb = New DataTable
            xregistro = New FichaProveedores.c_Proveedor
            AddHandler xgrid.Accion, AddressOf RetornarAuto

            MGrid = xgrid
            Etiqueta_1 = E_1
            Etiqueta_2 = E_2
            Etiqueta_3 = E_3
            Etiqueta_4 = E_4
            Etiqueta_5 = E_5
            Etiqueta_6 = E_6

            CargarData()
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With xgrid
                .Columns.Add("col0", "Nombre")
                .Columns.Add("col1", "Telefono")
                .Columns.Add("col2", "Celular")

                .Columns(1).Width = 130
                .Columns(2).Width = 130
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                AddHandler .CellFormatting, AddressOf NuevoFormato

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Columns(1).DataPropertyName = "tel"
                .Columns(2).DataPropertyName = "cel"
                .Ocultar(4)
            End With
        Catch ex As Exception
            Throw New Exception("CARGA DEL GRID:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub NuevoFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If MGrid.Rows(e.RowIndex).Cells("estatus").Value.ToString.Trim.ToUpper <> "ACTIVO" Then
            MGrid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Public ReadOnly Property _TotalRegistros() As Integer Implements IPlantilla_2._TotalRegistros
        Get
            Return xbs.Count
        End Get
    End Property

    Public ReadOnly Property _TituloFormulario() As String Implements IPlantilla_2._TituloFormulario
        Get
            Return "Listado De Proveedores"
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_2._TituloVentana
        Get
            Return "Proveedores"
        End Get
    End Property

    Public Property _SqlBusqueda() As String Implements IPlantilla_2._SqlBusqueda
        Get
            Return xsql
        End Get
        Set(ByVal value As String)
            xsql = value
        End Set
    End Property

    Public Property _SqlParametros() As System.Data.SqlClient.SqlParameter() Implements IPlantilla_2._SqlParametros
        Get
            Return xsql_parametros
        End Get
        Set(ByVal value As System.Data.SqlClient.SqlParameter())
            xsql_parametros = value
        End Set
    End Property
End Class

''' <summary>
''' CLASE BUSQUEDA VENDEDOR
''' </summary>
Public Class BusquedaVendedor
    Implements IPlantilla_2

    Public Event AutoEnviar(ByVal xauto As String) Implements IPlantilla_2.AutoEnviar

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xregistro As FichaVendedores.c_Vendedor

    Dim xsql As String
    Dim xsql_parametros As SqlParameter()

    Dim xgrid As MisControles.Controles.MisGrid
    Dim e_1 As Label
    Dim e_2 As Label
    Dim e_3 As Label
    Dim e_4 As Label
    Dim e_5 As Label
    Dim e_6 As Label

    Property MGrid() As MisControles.Controles.MisGrid
        Get
            Return xgrid
        End Get
        Set(ByVal value As MisControles.Controles.MisGrid)
            xgrid = value
        End Set
    End Property

    Property Etiqueta_1() As Label
        Get
            Return e_1
        End Get
        Set(ByVal value As Label)
            e_1 = value
        End Set
    End Property

    Property Etiqueta_2() As Label
        Get
            Return e_2
        End Get
        Set(ByVal value As Label)
            e_2 = value
        End Set
    End Property

    Property Etiqueta_3() As Label
        Get
            Return e_3
        End Get
        Set(ByVal value As Label)
            e_3 = value
        End Set
    End Property

    Property Etiqueta_4() As Label
        Get
            Return e_4
        End Get
        Set(ByVal value As Label)
            e_4 = value
        End Set
    End Property

    Property Etiqueta_5() As Label
        Get
            Return e_5
        End Get
        Set(ByVal value As Label)
            e_5 = value
        End Set
    End Property

    Property Etiqueta_6() As Label
        Get
            Return e_6
        End Get
        Set(ByVal value As Label)
            e_6 = value
        End Set
    End Property

    Sub CargarData()
        g_MiData.F_GetData(_SqlBusqueda, xtb, _SqlParametros)
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xregistro.M_CargarFicha(CType(xbs.Current, System.Data.DataRowView).Row)
            Me.Etiqueta_1.Text = xregistro.RegistroDato.r_CiRif
            Me.Etiqueta_2.Text = xregistro.RegistroDato.r_CodigoVendedor
            Me.Etiqueta_3.Text = xregistro.RegistroDato.r_NombreVendedor
            Me.Etiqueta_4.Text = xregistro.RegistroDato.r_ContactarA
            Me.Etiqueta_5.Text = xregistro.RegistroDato.r_DireccionVendedor

            If xregistro.RegistroDato.r_EstatusVendedor Then
                Me.Etiqueta_6.Text = "ACTIVO"
                Me.Etiqueta_6.ForeColor = Color.Blue
            Else
                Me.Etiqueta_6.Text = "SUSPENDIDO"
                Me.Etiqueta_6.ForeColor = Color.Maroon
            End If
        Else
            Me.Etiqueta_1.Text = ""
            Me.Etiqueta_2.Text = ""
            Me.Etiqueta_3.Text = ""
            Me.Etiqueta_4.Text = ""
            Me.Etiqueta_5.Text = ""
            Me.Etiqueta_6.Text = ""
        End If
    End Sub

    Sub RetornarAuto(ByVal xrow As System.Windows.Forms.DataGridViewRow)
        RaiseEvent AutoEnviar(xrow.Cells("auto").Value.ToString())
    End Sub

    Public Sub _Controles(ByRef xgrid As MisControles.Controles.MisGrid, ByRef E_1 As System.Windows.Forms.Label, _
                          ByRef E_2 As System.Windows.Forms.Label, ByRef E_3 As System.Windows.Forms.Label, _
                          ByRef E_4 As System.Windows.Forms.Label, ByRef E_5 As System.Windows.Forms.Label, _
                          ByRef E_6 As System.Windows.Forms.Label) Implements IPlantilla_2._Controles

        Try
            xtb = New DataTable
            xregistro = New FichaVendedores.c_Vendedor
            AddHandler xgrid.Accion, AddressOf RetornarAuto

            MGrid = xgrid
            Etiqueta_1 = E_1
            Etiqueta_2 = E_2
            Etiqueta_3 = E_3
            Etiqueta_4 = E_4
            Etiqueta_5 = E_5
            Etiqueta_6 = E_6

            CargarData()
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With xgrid
                .Columns.Add("col0", "Nombre")
                .Columns.Add("col1", "Telefono")
                .Columns.Add("col2", "Celular")

                .Columns(1).Width = 130
                .Columns(2).Width = 130
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                AddHandler .CellFormatting, AddressOf NuevoFormato

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Columns(1).DataPropertyName = "tel"
                .Columns(2).DataPropertyName = "cel"
                .Ocultar(4)
            End With
        Catch ex As Exception
            Throw New Exception("CARGA DEL GRID:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub NuevoFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If MGrid.Rows(e.RowIndex).Cells("estatus").Value.ToString.Trim.ToUpper <> "ACTIVO" Then
            MGrid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Public ReadOnly Property _TotalRegistros() As Integer Implements IPlantilla_2._TotalRegistros
        Get
            Return xbs.Count
        End Get
    End Property

    Public ReadOnly Property _TituloFormulario() As String Implements IPlantilla_2._TituloFormulario
        Get
            Return "Listado De Vendedores"
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_2._TituloVentana
        Get
            Return "Vendedores"
        End Get
    End Property

    Public Property _SqlBusqueda() As String Implements IPlantilla_2._SqlBusqueda
        Get
            Return xsql
        End Get
        Set(ByVal value As String)
            xsql = value
        End Set
    End Property

    Public Property _SqlParametros() As System.Data.SqlClient.SqlParameter() Implements IPlantilla_2._SqlParametros
        Get
            Return xsql_parametros
        End Get
        Set(ByVal value As System.Data.SqlClient.SqlParameter())
            xsql_parametros = value
        End Set
    End Property
End Class

''' <summary>
''' CLASE BUSQUEDA COBRADOR
''' </summary>
Public Class BusquedaCobrador
    Implements IPlantilla_2

    Public Event AutoEnviar(ByVal xauto As String) Implements IPlantilla_2.AutoEnviar

    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xregistro As FichaCobradores.c_Cobrador

    Dim xsql As String
    Dim xsql_parametros As SqlParameter()

    Dim xgrid As MisControles.Controles.MisGrid
    Dim e_1 As Label
    Dim e_2 As Label
    Dim e_3 As Label
    Dim e_4 As Label
    Dim e_5 As Label
    Dim e_6 As Label

    Property MGrid() As MisControles.Controles.MisGrid
        Get
            Return xgrid
        End Get
        Set(ByVal value As MisControles.Controles.MisGrid)
            xgrid = value
        End Set
    End Property

    Property Etiqueta_1() As Label
        Get
            Return e_1
        End Get
        Set(ByVal value As Label)
            e_1 = value
        End Set
    End Property

    Property Etiqueta_2() As Label
        Get
            Return e_2
        End Get
        Set(ByVal value As Label)
            e_2 = value
        End Set
    End Property

    Property Etiqueta_3() As Label
        Get
            Return e_3
        End Get
        Set(ByVal value As Label)
            e_3 = value
        End Set
    End Property

    Property Etiqueta_4() As Label
        Get
            Return e_4
        End Get
        Set(ByVal value As Label)
            e_4 = value
        End Set
    End Property

    Property Etiqueta_5() As Label
        Get
            Return e_5
        End Get
        Set(ByVal value As Label)
            e_5 = value
        End Set
    End Property

    Property Etiqueta_6() As Label
        Get
            Return e_6
        End Get
        Set(ByVal value As Label)
            e_6 = value
        End Set
    End Property

    Sub CargarData()
        g_MiData.F_GetData(_SqlBusqueda, xtb, _SqlParametros)
    End Sub

    Sub ActualizarData(ByVal sender As Object, ByVal e As System.EventArgs)
        Actualiza()
    End Sub

    Sub Actualiza()
        If xbs.Current IsNot Nothing Then
            xregistro.M_CargarRegistro(CType(xbs.Current, System.Data.DataRowView).Row)
            Me.Etiqueta_1.Text = xregistro.RegistroDato.r_CiRif
            Me.Etiqueta_2.Text = xregistro.RegistroDato.r_CodigoCobrador
            Me.Etiqueta_3.Text = xregistro.RegistroDato.r_NombreCobrador
            Me.Etiqueta_4.Text = xregistro.RegistroDato.r_ContactarA
            Me.Etiqueta_5.Text = xregistro.RegistroDato.r_DireccionCobrador

            If xregistro.RegistroDato.r_EstatusCobrador Then
                Me.Etiqueta_6.Text = "ACTIVO"
                Me.Etiqueta_6.ForeColor = Color.Blue
            Else
                Me.Etiqueta_6.Text = "SUSPENDIDO"
                Me.Etiqueta_6.ForeColor = Color.Maroon
            End If
        Else
            Me.Etiqueta_1.Text = ""
            Me.Etiqueta_2.Text = ""
            Me.Etiqueta_3.Text = ""
            Me.Etiqueta_4.Text = ""
            Me.Etiqueta_5.Text = ""
            Me.Etiqueta_6.Text = ""
        End If
    End Sub

    Sub RetornarAuto(ByVal xrow As System.Windows.Forms.DataGridViewRow)
        RaiseEvent AutoEnviar(xrow.Cells("auto").Value.ToString())
    End Sub

    Public Sub _Controles(ByRef xgrid As MisControles.Controles.MisGrid, ByRef E_1 As System.Windows.Forms.Label, _
                          ByRef E_2 As System.Windows.Forms.Label, ByRef E_3 As System.Windows.Forms.Label, _
                          ByRef E_4 As System.Windows.Forms.Label, ByRef E_5 As System.Windows.Forms.Label, _
                          ByRef E_6 As System.Windows.Forms.Label) Implements IPlantilla_2._Controles

        Try
            xtb = New DataTable
            xregistro = New FichaCobradores.c_Cobrador
            AddHandler xgrid.Accion, AddressOf RetornarAuto

            MGrid = xgrid
            Etiqueta_1 = E_1
            Etiqueta_2 = E_2
            Etiqueta_3 = E_3
            Etiqueta_4 = E_4
            Etiqueta_5 = E_5
            Etiqueta_6 = E_6

            CargarData()
            xbs = New BindingSource(xtb, "")
            AddHandler xbs.PositionChanged, AddressOf ActualizarData
            Actualiza()

            With xgrid
                .Columns.Add("col0", "Nombre")
                .Columns.Add("col1", "Telefono")
                .Columns.Add("col2", "Celular")

                .Columns(1).Width = 130
                .Columns(2).Width = 130
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                AddHandler .CellFormatting, AddressOf NuevoFormato

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nom"
                .Columns(1).DataPropertyName = "tel"
                .Columns(2).DataPropertyName = "cel"
                .Ocultar(4)
            End With
        Catch ex As Exception
            Throw New Exception("CARGA DEL GRID:" + vbCrLf + ex.Message)
        End Try
    End Sub

    Sub NuevoFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If MGrid.Rows(e.RowIndex).Cells("estatus").Value.ToString.Trim.ToUpper <> "ACTIVO" Then
            MGrid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Public ReadOnly Property _TotalRegistros() As Integer Implements IPlantilla_2._TotalRegistros
        Get
            Return xbs.Count
        End Get
    End Property

    Public ReadOnly Property _TituloFormulario() As String Implements IPlantilla_2._TituloFormulario
        Get
            Return "Listado De Cobradores"
        End Get
    End Property

    Public ReadOnly Property _TituloVentana() As String Implements IPlantilla_2._TituloVentana
        Get
            Return "Cobradores"
        End Get
    End Property

    Public Property _SqlBusqueda() As String Implements IPlantilla_2._SqlBusqueda
        Get
            Return xsql
        End Get
        Set(ByVal value As String)
            xsql = value
        End Set
    End Property

    Public Property _SqlParametros() As System.Data.SqlClient.SqlParameter() Implements IPlantilla_2._SqlParametros
        Get
            Return xsql_parametros
        End Get
        Set(ByVal value As System.Data.SqlClient.SqlParameter())
            xsql_parametros = value
        End Set
    End Property
End Class