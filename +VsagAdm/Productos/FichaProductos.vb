Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient


Public Class FichaProductos
    Dim pb_tm As Size
    Dim xestatus As Boolean
    Dim xaccion As TipoAccionFicha
    Dim xfichaprd As FichaProducto

    Dim xds As DataSet
    Dim xtb_departamento As DataTable
    Dim xtb_marca As DataTable
    Dim xtb_grupo As DataTable
    Dim xtb_subgrupo As DataTable
    Dim xtb_medida As DataTable
    Dim emp_compras As DataTable
    Dim emp_venta As DataTable

    Dim emp_venta_1 As DataTable
    Dim emp_venta_2 As DataTable
    Dim emp_venta_3 As DataTable
    Dim emp_venta_4 As DataTable

    Dim xrel_grupo_subgrupo As DataRelation

    Dim xbs_grupo As BindingSource
    Dim xbs_subgrupo As BindingSource
    Dim xbs_existencia As BindingSource
    Dim xbs_proveedores As BindingSource

    Dim campo_p As DataColumn
    Dim campo_h As DataColumn

    Dim xempaque_mostrar As Integer

    Dim xtipousobalanza As String() = {"Pesado", "Unidad"}

    Dim xtipofichamodificar As TipoFicha

    Dim xautoprdcargar As String

    Property _AutoProductoCargar() As String
        Get
            Return xautoprdcargar
        End Get
        Set(ByVal value As String)
            xautoprdcargar = value
        End Set
    End Property

    Property _FichaModificar() As TipoFicha
        Get
            Return xtipofichamodificar
        End Get
        Set(ByVal value As TipoFicha)
            xtipofichamodificar = value

            Select Case value
                Case TipoFicha.Ninguna
                    Me.GroupBox3.BackColor = Color.GhostWhite
                    Me.GroupBox7.BackColor = Color.GhostWhite
                    Me.GroupBox12.BackColor = Color.Lavender
                    Me.GroupBox8.BackColor = Color.GhostWhite
                    Me.GroupBox9.BackColor = Color.Lavender
                    Me.GroupBox10.BackColor = Color.GhostWhite
                    Me.GroupBox11.BackColor = Color.Lavender
                    Me.GroupBox15.BackColor = Color.GhostWhite
                    Me.GroupBox16.BackColor = Color.Lavender
                    Me.GroupBox17.BackColor = Color.GhostWhite
                    Me.GroupBox18.BackColor = Color.Lavender

                Case TipoFicha.Balanza
                    Me.GroupBox7.BackColor = Color.Peru
                    Me.MCB_TIPO_BALANZA.Enabled = True
                    Me.MN_PLU.Enabled = Me.MCHB_BALANZA.Checked
                    Me.BT_GRABAR.Enabled = Me.MCHB_BALANZA.Checked
                    With Me.MCHB_BALANZA
                        .Enabled = True
                        .Select()
                        .Focus()
                    End With

                Case TipoFicha.Garantia
                    Me.GroupBox8.BackColor = Color.Peru
                    MCHB_GARANTIA.Enabled = Me.MCHB_GARANTIA.Checked
                    Me.MN_GARANTIA_DIAS.Enabled = Me.MCHB_GARANTIA.Checked
                    With Me.MCHB_GARANTIA
                        .Enabled = True
                        .Select()
                        .Focus()
                    End With

                Case TipoFicha.Licor
                    Me.GroupBox12.BackColor = Color.Peru
                    MCHB_LICOR.Enabled = True
                    Me.MN_LICOR_CAPACIDAD.Enabled = Me.MCHB_LICOR.Checked
                    Me.MN_LICOR_GRADOS.Enabled = Me.MCHB_LICOR.Checked
                    Me.MN_LICOR_TASA.Enabled = Me.MCHB_LICOR.Checked
                    With Me.MCHB_LICOR
                        .Enabled = True
                        .Select()
                        .Focus()
                    End With

                Case TipoFicha.Dimensiones
                    Me.GroupBox9.BackColor = Color.Peru
                    Me.MN_DIM_ALTO.Enabled = True
                    Me.MN_DIM_ANCHO.Enabled = True
                    Me.MN_DIM_LARGO.Enabled = True
                    Me.MN_DIM_PESO.Enabled = True
                    Me.MN_DIM_TASA_ARANCEL.Enabled = True
                    Me.MT_DIM_CODIGO_ARANCEL.Enabled = True
                    With Me.MN_DIM_ALTO
                        .Select()
                        .Focus()
                    End With

                Case TipoFicha.Contable
                    Me.GroupBox10.BackColor = Color.Peru
                    With Me.MT_CONTABLE
                        .Enabled = True
                        .Select()
                        .Focus()
                    End With

                Case TipoFicha.Detalle
                    Me.GroupBox11.BackColor = Color.Peru
                    Me.MT_MODELO.Enabled = True
                    Me.MT_REFERENCIA.Enabled = True
                    Me.MT_NUM_PARTE.Enabled = True
                    With Me.MT_MODELO
                        .Select()
                        .Focus()
                    End With

                Case TipoFicha.Costo
                    Me.GroupBox3.BackColor = Color.Peru
                    Me.MN_CT_PROV_NETO.Enabled = True
                    Me.MN_CT_PROV_FULL.Enabled = True
                    With Me.MN_CT_PROV_NETO
                        .Select()
                        .Focus()
                    End With

                Case TipoFicha.EventoPresupuesto
                    Me.GroupBox15.BackColor = Color.Peru
                    MCHB_EVENTO.Enabled = Me.MCHB_EVENTO.Checked
                    Me.MN_CONSUMO_PERSONA.Enabled = True
                    With Me.MCHB_EVENTO
                        .Enabled = True
                        .Select()
                        .Focus()
                    End With

                Case TipoFicha.WEB
                    Me.GroupBox16.BackColor = Color.Peru
                    MCHB_WEB.Enabled = Me.MCHB_WEB.Checked
                    With Me.MCHB_WEB
                        .Enabled = True
                        .Select()
                        .Focus()
                    End With

                Case TipoFicha.SERIAL
                    Me.GroupBox17.BackColor = Color.Peru
                    MCHB_SERIAL.Enabled = Me.MCHB_SERIAL.Checked
                    With Me.MCHB_SERIAL
                        .Enabled = True
                        .Select()
                        .Focus()
                    End With


                    '25/11/2014
                Case TipoFicha.ESTATUS_PRODUCTO
                    Me.GroupBox18.BackColor = Color.Peru
                    MCHB_REGULADO.Enabled = True
                    MCHB_RESTRINGIDO.Enabled = True
                    With Me.MCHB_REGULADO
                        .Enabled = True
                        .Select()
                        .Focus()
                    End With

            End Select
        End Set
    End Property

    Property _TipoUsoBalanza() As String()
        Get
            Return xtipousobalanza
        End Get
        Set(ByVal value As String())
            xtipousobalanza = value
        End Set
    End Property

    Property _EmpaqueMostrar() As Integer
        Get
            Return xempaque_mostrar
        End Get
        Set(ByVal value As Integer)
            xempaque_mostrar = value
        End Set
    End Property

    ReadOnly Property _On() As Boolean
        Get
            Return True
        End Get
    End Property
    ReadOnly Property _Off() As Boolean
        Get
            Return False
        End Get
    End Property

    Sub IrInicio()
        With Me
            .Focus()
            .Select()

            .MT_BUSCAR.Enabled = True
            .MT_BUSCAR.Text = ""
            .MT_BUSCAR.Select()
            .MT_BUSCAR.Focus()
        End With
    End Sub

    Enum Controles As Integer
        Apagar = 0
        Encender = 1
    End Enum

    Sub InicializarControles()
        With Me.MT_CODIGO
            .Text = ""
            .MaxLength = xfichaprd.f_PrdProducto.RegistroDato.c_CodigoProducto.c_Largo
        End With
        With Me.MT_DES_CORTA
            .Text = ""
            .MaxLength = xfichaprd.f_PrdProducto.RegistroDato.c_NombreProductoResumen.c_Largo
        End With
        With Me.MT_DES_GENERAL
            .Text = ""
            .MaxLength = xfichaprd.f_PrdProducto.RegistroDato.c_NombreProducto.c_Largo
        End With

        With Me.MN_CONT_EMP_COMPRA
            .Text = "1"
            ._Formato = "99999"
            ._ConSigno = False
        End With
        With Me.MN_CONT_EMP_VENTA
            .Text = "1"
            ._Formato = "99999"
            ._ConSigno = False
        End With

        CargarDepartamento()
        CargarGruposSubgrupo()
        CargarMarcas()
        CargarEmpaques()

        With Me.MCB_DEPARTAMENTO
            .DataSource = xtb_departamento
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_GRUPO
            .DataSource = xbs_grupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_SUBGRUPO
            .DataSource = xbs_subgrupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_MARCA
            .DataSource = xtb_marca
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_CATEGORIA
            .DataSource = g_MiData.f_FichaProducto.f_PrdProducto._CategoriaProducto
            .SelectedIndex = 0
        End With

        With Me.MCB_ORIGEN
            .DataSource = g_MiData.f_FichaProducto.f_PrdProducto._OrigenProducto
            .SelectedIndex = 0
        End With

        With Me.MCB_IMPUESTO
            .DataSource = g_MiData.f_FichaGlobal.f_Fiscal.r_ListaTasasFiscales
            .DisplayMember = "_TasaNombre"
            .ValueMember = "_Tasa"
        End With

        With Me.MCB_EMP_COMPRA
            .DataSource = emp_compras
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With

        With Me.MCB_EMP_VENTA
            .DataSource = emp_venta
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With

        With Me.MN_CT_PROV_NETO
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With
        With Me.MN_CT_PROV_FULL
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "99999999999.99"
        End With

        Me.E_COST_IMPORTACION.Text = "0.0"
        Me.E_COST_OTROS.Text = "0.0"
        Me.E_COST_PROM_FULL.Text = "0.0"
        Me.E_COST_PROM_NETO.Text = "0.0"
        Me.E_COST_PROM_UNI_FULL.Text = "0.0"
        Me.E_COST_PROM_UNI_NETO.Text = "0.0"
        Me.E_COST_TOT_UNI_FULL.Text = "0.0"
        Me.E_COST_TOT_UNI_NETO.Text = "0.0"
        Me.E_COST_TOTAL_FULL.Text = "0.0"
        Me.E_COST_TOTAL_NETO.Text = "0.0"

        Me.E_EMP_COSTO_VENTA_1.Text = "0.0"
        Me.E_EMP_COSTO_VENTA_2.Text = "0.0"
        Me.E_EMP_COSTO_VENTA_3.Text = "0.0"
        Me.E_EMP_COSTO_VENTA_4.Text = "0.0"

        Me.E_EMP_PFULL_VENTA_1.Text = "0.0"
        Me.E_EMP_PFULL_VENTA_2.Text = "0.0"
        Me.E_EMP_PFULL_VENTA_3.Text = "0.0"
        Me.E_EMP_PFULL_VENTA_4.Text = "0.0"

        Me.E_EMP_PNETO_VENTA_1.Text = "0.0"
        Me.E_EMP_PNETO_VENTA_2.Text = "0.0"
        Me.E_EMP_PNETO_VENTA_3.Text = "0.0"
        Me.E_EMP_PNETO_VENTA_4.Text = "0.0"

        Me.E_EMP_UTIL_VENTA_1.Text = "0.0"
        Me.E_EMP_UTIL_VENTA_2.Text = "0.0"
        Me.E_EMP_UTIL_VENTA_3.Text = "0.0"
        Me.E_EMP_UTIL_VENTA_4.Text = "0.0"

        Me.E_EMP_VENTA_1.Text = "0"
        Me.E_EMP_VENTA_2.Text = "0"
        Me.E_EMP_VENTA_3.Text = "0"
        Me.E_EMP_VENTA_4.Text = "0"

        Me.E_PRECIO_DETAL.Text = "0.0"
        Me.E_PRECIO_OFERTA.Text = "0.0"
        Me.E_PRECIO_SUGERIDO.Text = "0.0"
        Me.E_OFERTA_VALIDA.Text = ""

        With Me.MCB_BUSQUEDA
            .DataSource = xfichaprd.f_PrdProducto._TipoBusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProducto
        End With
        Me.MT_BUSCAR.Text = ""

        With Me.MCB_EMP_1
            .DataSource = emp_venta_1
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
        With Me.MCB_EMP_2
            .DataSource = emp_venta_2
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
        With Me.MCB_EMP_3
            .DataSource = emp_venta_3
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
        With Me.MCB_EMP_4
            .DataSource = emp_venta_4
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With

        Me.E_INV_REAL.Text = "0.0"
        Me.E_INV_RESERVADO.Text = "0.0"
        Me.E_INV_DISPONIBLE.Text = "0.0"

        Me.E_ESTATUS.Text = ""
        Me.E_FECHA_ACTUALIZACION.Text = ""
        Me.PB_ESTATUS.Enabled = False

        Me.BT_CODIGOS_ALTERNOS.Enabled = False

        Me.E_EMPAQUE_REFERENCIA.Text = ""

        '
        'PAGINA #2
        '

        With Me.MCB_TIPO_BALANZA
            .DataSource = _TipoUsoBalanza
            .SelectedIndex = 0
        End With

        With Me.MN_PLU
            ._Formato = "99999"
            ._ConSigno = False
            .Text = "0"
        End With
        With Me.MN_LICOR_CAPACIDAD
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
        With Me.MN_LICOR_GRADOS
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
        With Me.MN_LICOR_TASA
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With

        With Me.MN_GARANTIA_DIAS
            ._Formato = "999"
            ._ConSigno = False
            .Text = "0"
        End With

        With Me.MN_DIM_ALTO
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
        With Me.MN_DIM_ANCHO
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
        With Me.MN_DIM_LARGO
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
        With Me.MN_DIM_PESO
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
        With Me.MN_DIM_TASA_ARANCEL
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With

        Me.MT_DIM_CODIGO_ARANCEL.Text = ""
        Me.MT_CONTABLE.Text = ""

        Me.MT_MODELO.Text = ""
        Me.MT_REFERENCIA.Text = ""
        Me.MT_NUM_PARTE.Text = ""

        Me.E_PROVEEDORES_ENCONTRADOS.Text = "0"

        'PAGINA #3

        With Me.MN_CONSUMO_PERSONA
            ._Formato = "9999.999"
            ._ConSigno = False
            .Text = "0"
        End With
    End Sub

    Sub LimpiarFicha()
        _EmpaqueMostrar = 1
        xfichaprd.f_PrdProducto.M_LimpiarFicha()

        With Me.MT_CODIGO
            .Text = ""
        End With
        With Me.MT_DES_CORTA
            .Text = ""
        End With
        With Me.MT_DES_GENERAL
            .Text = ""
        End With
        With Me.MN_CONT_EMP_COMPRA
            .Text = "1"
        End With
        With Me.MN_CONT_EMP_VENTA
            .Text = "1"
        End With

        With Me.MCB_DEPARTAMENTO
            .DataSource = Nothing
        End With

        With Me.MCB_GRUPO
            .DataSource = Nothing
        End With

        With Me.MCB_SUBGRUPO
            .DataSource = Nothing
        End With

        With Me.MCB_MARCA
            .DataSource = Nothing
        End With

        With Me.MCB_CATEGORIA
            .DataSource = Nothing
        End With

        With Me.MCB_ORIGEN
            .DataSource = Nothing
        End With

        With Me.MCB_IMPUESTO
            .DataSource = Nothing
        End With

        With Me.MCB_EMP_COMPRA
            .DataSource = Nothing
        End With

        With Me.MCB_EMP_VENTA
            .DataSource = Nothing
        End With

        With Me.MN_CT_PROV_NETO
            .Text = "0.0"
        End With
        With Me.MN_CT_PROV_FULL
            .Text = "0.0"
        End With

        Me.E_COST_IMPORTACION.Text = "0.0"
        Me.E_COST_OTROS.Text = "0.0"
        Me.E_COST_PROM_FULL.Text = "0.0"
        Me.E_COST_PROM_NETO.Text = "0.0"
        Me.E_COST_PROM_UNI_FULL.Text = "0.0"
        Me.E_COST_PROM_UNI_NETO.Text = "0.0"
        Me.E_COST_TOT_UNI_FULL.Text = "0.0"
        Me.E_COST_TOT_UNI_NETO.Text = "0.0"
        Me.E_COST_TOTAL_FULL.Text = "0.0"
        Me.E_COST_TOTAL_NETO.Text = "0.0"

        Me.E_EMP_COSTO_VENTA_1.Text = "0.0"
        Me.E_EMP_COSTO_VENTA_2.Text = "0.0"
        Me.E_EMP_COSTO_VENTA_3.Text = "0.0"
        Me.E_EMP_COSTO_VENTA_4.Text = "0.0"

        Me.E_EMP_PFULL_VENTA_1.Text = "0.0"
        Me.E_EMP_PFULL_VENTA_2.Text = "0.0"
        Me.E_EMP_PFULL_VENTA_3.Text = "0.0"
        Me.E_EMP_PFULL_VENTA_4.Text = "0.0"

        Me.E_EMP_PNETO_VENTA_1.Text = "0.0"
        Me.E_EMP_PNETO_VENTA_2.Text = "0.0"
        Me.E_EMP_PNETO_VENTA_3.Text = "0.0"
        Me.E_EMP_PNETO_VENTA_4.Text = "0.0"

        Me.E_EMP_UTIL_VENTA_1.Text = "0.0"
        Me.E_EMP_UTIL_VENTA_2.Text = "0.0"
        Me.E_EMP_UTIL_VENTA_3.Text = "0.0"
        Me.E_EMP_UTIL_VENTA_4.Text = "0.0"

        Me.E_EMP_VENTA_1.Text = "0"
        Me.E_EMP_VENTA_2.Text = "0"
        Me.E_EMP_VENTA_3.Text = "0"
        Me.E_EMP_VENTA_4.Text = "0"

        Me.E_PRECIO_DETAL.Text = "0.0"
        Me.E_PRECIO_OFERTA.Text = "0.0"
        Me.E_PRECIO_SUGERIDO.Text = "0.0"
        Me.E_OFERTA_VALIDA.Text = ""

        With Me.MCB_BUSQUEDA
            .DataSource = xfichaprd.f_PrdProducto._TipoBusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProducto
        End With
        Me.MT_BUSCAR.Text = ""

        With Me.MCB_EMP_1
            .DataSource = Nothing
        End With
        With Me.MCB_EMP_2
            .DataSource = Nothing
        End With
        With Me.MCB_EMP_3
            .DataSource = Nothing
        End With
        With Me.MCB_EMP_4
            .DataSource = Nothing
        End With

        Me.E_INV_REAL.Text = "0.0"
        Me.E_INV_RESERVADO.Text = "0.0"
        Me.E_INV_DISPONIBLE.Text = "0.0"

        Me.E_ESTATUS.Text = ""
        Me.E_FECHA_ACTUALIZACION.Text = ""
        Me.PB_ESTATUS.Enabled = False

        Me.BT_CODIGOS_ALTERNOS.Enabled = False

        Me.E_EMPAQUE_REFERENCIA.Text = ""

        '
        ' Pagina #2
        '

        With Me.MCB_TIPO_BALANZA
            .DataSource = Nothing
        End With

        Me.MN_PLU.Text = "0"
        Me.MN_LICOR_CAPACIDAD.Text = "0.0"
        Me.MN_LICOR_GRADOS.Text = "0.0"
        Me.MN_LICOR_TASA.Text = "0.0"

        Me.MN_GARANTIA_DIAS.Text = "0"

        Me.MN_DIM_ALTO.Text = "0.0"
        Me.MN_DIM_ANCHO.Text = "0.0"
        Me.MN_DIM_LARGO.Text = "0.0"
        Me.MN_DIM_PESO.Text = "0.0"
        Me.MN_DIM_TASA_ARANCEL.Text = "0.0"

        Me.MT_DIM_CODIGO_ARANCEL.Text = ""
        Me.MT_CONTABLE.Text = ""

        Me.MT_MODELO.Text = ""
        Me.MT_REFERENCIA.Text = ""
        Me.MT_NUM_PARTE.Text = ""

        Me.E_PROVEEDORES_ENCONTRADOS.Text = "0"

        Me.MCHB_BALANZA.Checked = False
        Me.MCHB_LICOR.Checked = False
        Me.MCHB_GARANTIA.Checked = False
        Me.MCHB_PRECIO_2.Checked = False

        'PAGINA #3
        Me.MN_CONSUMO_PERSONA.Text = "0.0"
        Me.MCHB_EVENTO.Checked = False
        Me.MCHB_WEB.Checked = False
        Me.MCHB_SERIAL.Checked = False

        '25/11/2014
        Me.MCHB_REGULADO.Checked = False
        Me.MCHB_RESTRINGIDO.Checked = False
    End Sub

    Sub CargarDepartamento()
        g_MiData.F_GetData("select nombre,auto from productos_departamento order by nombre", xtb_departamento)
        If _MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MCB_DEPARTAMENTO.Enabled = True
            Me.MCB_DEPARTAMENTO.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoDepartamento
            Me.MCB_DEPARTAMENTO.Enabled = False
        End If
    End Sub

    Sub CargarGrupos()
        xtb_subgrupo.Clear()
        xtb_grupo.Clear()

        g_MiData.F_GetData("select nombre,auto from productos_grupo order by nombre", xtb_grupo)
        g_MiData.F_GetData("select nombre,auto,auto_grupo from productos_subgrupo order by nombre", xtb_subgrupo)
        If _MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MCB_GRUPO.Enabled = True
            Me.MCB_SUBGRUPO.Enabled = True
            Me.MCB_GRUPO.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoGrupo
            Me.MCB_SUBGRUPO.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoSubGrupo
            Me.MCB_SUBGRUPO.Enabled = False
            Me.MCB_GRUPO.Enabled = False
        End If
    End Sub

    Sub CargarGruposSubgrupo()
        CargarGrupos()

        xds.Tables.Add(xtb_grupo)
        xds.Tables.Add(xtb_subgrupo)

        campo_p = xds.Tables(xtb_grupo.TableName).Columns("auto")
        campo_h = xds.Tables(xtb_subgrupo.TableName).Columns("auto_grupo")

        xrel_grupo_subgrupo = New DataRelation("Grupo_Subgrupo", campo_p, campo_h)
        xds.Relations.Add(xrel_grupo_subgrupo)

        xbs_grupo = New BindingSource(xds, xtb_grupo.TableName)
        xbs_subgrupo = New BindingSource(xbs_grupo, xrel_grupo_subgrupo.RelationName)
    End Sub

    Sub CargarMarcas()
        g_MiData.F_GetData("select nombre,auto from productos_marca order by nombre", xtb_marca)
        If _MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MCB_MARCA.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoMarca
        End If
    End Sub

    Sub CargarEmpaques()
        emp_compras.Rows.Clear()
        emp_venta.Rows.Clear()

        emp_venta_1.Rows.Clear()
        emp_venta_2.Rows.Clear()
        emp_venta_3.Rows.Clear()
        emp_venta_4.Rows.Clear()

        g_MiData.F_GetData("select nombre x1,auto x2, * from productos_medida order by nombre", xtb_medida)

        emp_compras.Load(xtb_medida.CreateDataReader)
        emp_venta.Load(xtb_medida.CreateDataReader)

        emp_venta_1.Load(xtb_medida.CreateDataReader)
        emp_venta_2.Load(xtb_medida.CreateDataReader)
        emp_venta_3.Load(xtb_medida.CreateDataReader)
        emp_venta_4.Load(xtb_medida.CreateDataReader)

        If _MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MCB_EMP_COMPRA.Enabled = True
            Me.MCB_EMP_VENTA.Enabled = True
            Me.MCB_EMP_1.Enabled = True
            Me.MCB_EMP_2.Enabled = True
            Me.MCB_EMP_3.Enabled = True
            Me.MCB_EMP_4.Enabled = True

            With Me.MCB_EMP_COMPRA
                .DataSource = emp_compras
                .DisplayMember = "x1"
                .ValueMember = "x2"
            End With

            With Me.MCB_EMP_VENTA
                .DataSource = emp_venta
                .DisplayMember = "x1"
                .ValueMember = "x2"
            End With

            With Me.MCB_EMP_1
                .DataSource = emp_venta_1
                .DisplayMember = "x1"
                .ValueMember = "x2"
            End With
            With Me.MCB_EMP_2
                .DataSource = emp_venta_2
                .DisplayMember = "x1"
                .ValueMember = "x2"
            End With
            With Me.MCB_EMP_3
                .DataSource = emp_venta_3
                .DisplayMember = "x1"
                .ValueMember = "x2"
            End With
            With Me.MCB_EMP_4
                .DataSource = emp_venta_4
                .DisplayMember = "x1"
                .ValueMember = "x2"
            End With

            Me.MCB_EMP_COMPRA.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoEmpaqueCompra
            Me.MCB_EMP_VENTA.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoEmpaqueVentaDetal

            Dim xprecio_empaque As New FichaProducto.Prd_Empaque()
            For Each xrow As DataRow In xfichaprd.f_PrdProducto.RegistroDato.tb_Precios.Rows
                xprecio_empaque.M_Cargardata(xrow)
                Select Case xprecio_empaque.RegistroDato._ReferenciaEmpaqueSeleccionado
                    Case "1"
                        Me.MCB_EMP_1.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                    Case "2"
                        Me.MCB_EMP_2.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                    Case "3"
                        Me.MCB_EMP_3.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                    Case "4"
                        Me.MCB_EMP_4.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                End Select
            Next

            Me.MCB_EMP_COMPRA.Enabled = False
            Me.MCB_EMP_VENTA.Enabled = False
            Me.MCB_EMP_1.Enabled = False
            Me.MCB_EMP_2.Enabled = False
            Me.MCB_EMP_3.Enabled = False
            Me.MCB_EMP_4.Enabled = False

            xbs_existencia.CurrencyManager.Refresh()
            ActualizarTotalesExistencia()
        End If
    End Sub

    Sub ActualizarTotalesExistencia()
        Dim xreal As Decimal = 0
        Dim xreservada As Decimal = 0
        Dim xdisponible As Decimal = 0

        If _EmpaqueMostrar > 0 Then
            For Each xr As DataRow In xfichaprd.f_PrdProducto.RegistroDato.tb_Existencia.Rows
                xreal += xr("xreal") / _EmpaqueMostrar
                xreservada += xr("xreservada") / _EmpaqueMostrar
                xdisponible += xr("xdisponible") / _EmpaqueMostrar
            Next
        End If

        Dim xformato As String = "0:#0.00"
        If xfichaprd.f_PrdProducto.RegistroDato._CantDecimalesEmpaqueCompra > 2 Then
            xformato = "0:#0.000"
        End If

        Me.E_INV_REAL.Text = String.Format("{" & xformato & "}", xreal)
        Me.E_INV_RESERVADO.Text = String.Format("{" & xformato & "}", xreservada)
        Me.E_INV_DISPONIBLE.Text = String.Format("{" & xformato & "}", xdisponible)
    End Sub

    Sub ApagarEncenderControles(ByVal xest As Controles)
        Me.MT_CODIGO.Enabled = xest
        Me.MT_DES_CORTA.Enabled = xest
        Me.MT_DES_GENERAL.Enabled = xest

        Me.MCB_CATEGORIA.Enabled = xest
        Me.MCB_DEPARTAMENTO.Enabled = xest
        Me.MCB_GRUPO.Enabled = xest
        Me.MCB_IMPUESTO.Enabled = xest
        Me.MCB_MARCA.Enabled = xest
        Me.MCB_ORIGEN.Enabled = xest
        Me.MCB_SUBGRUPO.Enabled = xest

        Me.MCB_EMP_COMPRA.Enabled = xest
        Me.MCB_EMP_VENTA.Enabled = xest

        Me.MN_CONT_EMP_COMPRA.Enabled = xest
        Me.MN_CONT_EMP_VENTA.Enabled = xest

        Me.MN_CT_PROV_NETO.Enabled = xest
        Me.MN_CT_PROV_FULL.Enabled = xest

        Me.MCB_EMP_1.Enabled = xest
        Me.MCB_EMP_2.Enabled = xest
        Me.MCB_EMP_3.Enabled = xest
        Me.MCB_EMP_4.Enabled = xest

        Me.MCHB_PRECIO_2.Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, xest, False)

        '
        ' Pagina #2
        '
        MCHB_BALANZA.Enabled = xest
        MCHB_GARANTIA.Enabled = xest
        MCHB_LICOR.Enabled = xest

        Me.MN_PLU.Enabled = xest
        Me.MCB_TIPO_BALANZA.Enabled = xest

        Me.MN_LICOR_CAPACIDAD.Enabled = xest
        Me.MN_LICOR_GRADOS.Enabled = xest
        Me.MN_LICOR_TASA.Enabled = xest

        Me.MN_GARANTIA_DIAS.Enabled = xest

        Me.MN_DIM_ALTO.Enabled = xest
        Me.MN_DIM_ANCHO.Enabled = xest
        Me.MN_DIM_LARGO.Enabled = xest
        Me.MN_DIM_PESO.Enabled = xest
        Me.MN_DIM_TASA_ARANCEL.Enabled = xest
        Me.MT_DIM_CODIGO_ARANCEL.Enabled = xest

        Me.MT_CONTABLE.Enabled = xest

        Me.MT_MODELO.Enabled = xest
        Me.MT_REFERENCIA.Enabled = xest
        Me.MT_NUM_PARTE.Enabled = xest

        ' PAGINA #3
        Me.MCHB_EVENTO.Enabled = xest
        Me.MN_CONSUMO_PERSONA.Enabled = xest
        Me.MCHB_WEB.Enabled = xest
        Me.MCHB_SERIAL.Enabled = xest

        '25/11/2014
        Me.MCHB_REGULADO.Enabled = xest
        Me.MCHB_RESTRINGIDO.Enabled = xest

    End Sub

    Enum TipoEntrada As Integer
        ProductoNuevo = 1
        ModificarProducto = 2
    End Enum

    Enum TipoFicha As Integer
        Ninguna = 0
        Balanza = 1
        Licor = 2
        Garantia = 3
        Dimensiones = 4
        Contable = 5
        Detalle = 6
        Costo = 7
        Proveedor = 8
        EventoPresupuesto = 9
        WEB = 10
        SERIAL = 11
        ESTATUS_PRODUCTO = 12
    End Enum

    Sub ActivarEntradaProducto(Optional ByVal xop As TipoEntrada = TipoEntrada.ProductoNuevo)
        If xop = TipoEntrada.ProductoNuevo Then
            CargarDepartamento()
            CargarGrupos()
            CargarMarcas()
            CargarEmpaques()

            With Me.MCB_DEPARTAMENTO
                .DataSource = xtb_departamento
                .DisplayMember = "nombre"
                .ValueMember = "auto"
            End With

            With Me.MCB_GRUPO
                .DataSource = xbs_grupo
                .DisplayMember = "nombre"
                .ValueMember = "auto"
            End With

            With Me.MCB_SUBGRUPO
                .DataSource = xbs_subgrupo
                .DisplayMember = "nombre"
                .ValueMember = "auto"
            End With

            With Me.MCB_MARCA
                .DataSource = xtb_marca
                .DisplayMember = "nombre"
                .ValueMember = "auto"
            End With

            With Me.MCB_CATEGORIA
                .DataSource = g_MiData.f_FichaProducto.f_PrdProducto._CategoriaProducto
                .SelectedIndex = 0
            End With

            With Me.MCB_ORIGEN
                .DataSource = g_MiData.f_FichaProducto.f_PrdProducto._OrigenProducto
                .SelectedIndex = 0
            End With

            With Me.MCB_IMPUESTO
                .DataSource = g_MiData.f_FichaGlobal.f_Fiscal.r_ListaTasasFiscales
                .DisplayMember = "_TasaNombre"
                .ValueMember = "_Tasa"
                .SelectedIndex = 1
            End With

            With Me.MCB_EMP_COMPRA
                .DataSource = emp_compras
                .DisplayMember = "x1"
                .ValueMember = "x2"
            End With

            With Me.MCB_EMP_VENTA
                .DataSource = emp_venta
                .DisplayMember = "x1"
                .ValueMember = "x2"
            End With
        End If

        Me.MT_CODIGO.Enabled = True
        Me.MT_DES_CORTA.Enabled = True
        Me.MT_DES_GENERAL.Enabled = True

        Me.MCB_CATEGORIA.Enabled = True
        Me.MCB_DEPARTAMENTO.Enabled = True
        Me.MCB_GRUPO.Enabled = True
        Me.MCB_IMPUESTO.Enabled = True
        Me.MCB_MARCA.Enabled = True
        Me.MCB_ORIGEN.Enabled = True
        Me.MCB_SUBGRUPO.Enabled = True

        Me.MCB_EMP_COMPRA.Enabled = True
        Me.MCB_EMP_VENTA.Enabled = True

        Me.MN_CONT_EMP_COMPRA.Enabled = True
        Me.MN_CONT_EMP_VENTA.Enabled = True

        Me.MT_CODIGO.Select()
        Me.MT_CODIGO.Focus()
    End Sub

    Sub ActivarDesactivarBotones()
        If Me._MiFichaAccion = TipoAccionFicha.Adicionar Or _MiFichaAccion = TipoAccionFicha.Modificar Or _MiFichaAccion = TipoAccionFicha.ModificarOtro Then
            Me.PB_1.Enabled = False
            Me.PB_2.Enabled = False
            Me.PB_3.Enabled = False
            Me.BT_GRABAR.Enabled = True
            Me.BT_BUSCAR.Enabled = False
            Me.BT_BUS_AVANZ.Enabled = False
            Me.MCB_BUSQUEDA.Enabled = False
            Me.MT_BUSCAR.Enabled = False
            Me.MCHB_PRECIO_2.Enabled = False
            Me.BT_CODIGOS_ALTERNOS.Enabled = False

            Me.MG_CODIGOS.Enabled = False
            Me.MG_EXISTENCIA.Enabled = False
            Me.MG_PROVEEDORES.Enabled = False

            If _MiFichaAccion = TipoAccionFicha.Modificar Then
                _EstatusProducto = xfichaprd.f_PrdProducto.RegistroDato._EstatusProducto
                Me.PB_ESTATUS.Enabled = True
            End If

            If _MiFichaAccion <> TipoAccionFicha.ModificarOtro Then
                Me.MT_CODIGO.Select()
                Me.MT_CODIGO.Focus()
            End If
        End If
        If Me._MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.PB_1.Enabled = True
            Me.PB_2.Enabled = True
            Me.PB_3.Enabled = True
            Me.BT_GRABAR.Enabled = False
            Me.BT_BUSCAR.Enabled = True
            Me.BT_BUS_AVANZ.Enabled = True
            Me.MCB_BUSQUEDA.Enabled = True
            Me.MCHB_PRECIO_2.Enabled = IIf(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2, True, False)
            Me.BT_CODIGOS_ALTERNOS.Enabled = True

            Me.MG_CODIGOS.Enabled = True
            Me.MG_EXISTENCIA.Enabled = True
            Me.MG_PROVEEDORES.Enabled = True

            IrInicio()
        End If
        If Me._MiFichaAccion = TipoAccionFicha.Inactivo Then
            Me.PB_1.Enabled = True
            Me.PB_2.Enabled = False
            Me.PB_3.Enabled = False
            Me.BT_GRABAR.Enabled = False
            Me.BT_BUSCAR.Enabled = True
            Me.BT_BUS_AVANZ.Enabled = True
            Me.MT_BUSCAR.Enabled = True
            Me.MCB_BUSQUEDA.Enabled = True
            Me.PB_ESTATUS.Image = My.Resources.mypc_info
            Me.BT_CODIGOS_ALTERNOS.Enabled = False

            Me.MG_CODIGOS.Enabled = True
            Me.MG_EXISTENCIA.Enabled = True
            Me.MG_PROVEEDORES.Enabled = True

            IrInicio()
        End If
    End Sub

    Property _MiFichaAccion() As TipoAccionFicha
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xaccion = value

            If value = TipoAccionFicha.Inactivo Then
                LimpiarFicha()
                ApagarEncenderControles(Controles.Apagar)
                ActivarDesactivarBotones()
                _FichaModificar = TipoFicha.Ninguna
                Me.PB_FOTO._CargarImagen("")
                Me.GroupBox14.Enabled = False
            End If

            If value = TipoAccionFicha.Adicionar Then
                LimpiarFicha()
                ActivarEntradaProducto()
                ActivarDesactivarBotones()
            End If

            If value = TipoAccionFicha.Modificar Then
                ActivarEntradaProducto(TipoEntrada.ModificarProducto)
                ActivarDesactivarBotones()
            End If

            If value = TipoAccionFicha.Consultar Then
                ApagarEncenderControles(Controles.Apagar)
                ActivarDesactivarBotones()
                _FichaModificar = TipoFicha.Ninguna
                Me.GroupBox14.Enabled = True
                IrInicio()
            End If

            If value = TipoAccionFicha.ModificarOtro Then
                ActivarDesactivarBotones()
            End If
        End Set
    End Property

    Sub ActivarBotones()
        Me.MCHB_PRECIO_2.Enabled = True
        Me.BT_CODIGOS_ALTERNOS.Enabled = True
        Me.PB_2.Enabled = True
        Me.PB_3.Enabled = True
        Me.BT_GRABAR.Enabled = False
    End Sub

    Property _EstatusProducto() As Boolean
        Get
            Return xestatus
        End Get
        Set(ByVal value As Boolean)
            xestatus = value
        End Set
    End Property

    Private Sub PB_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseEnter, PB_2.MouseEnter, PB_3.MouseEnter
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseHover, PB_2.MouseHover, PB_3.MouseHover
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseLeave, PB_2.MouseLeave, PB_3.MouseLeave
        EntrarSalirPB(sender, EntradaSalida.Salida)
    End Sub

    Sub EntrarSalirPB(ByVal sender As Object, ByVal xtipo As EntradaSalida)
        Dim PB As PictureBox = CType(sender, PictureBox)
        Dim factor As Integer = 0
        If xtipo = EntradaSalida.Entrada Then
            factor = -5
        End If

        With PB
            .Size = New Size(pb_tm.Width + factor, pb_tm.Height + factor)
            .Cursor = Cursors.Hand
        End With
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_ESTATUS.Click
        _EstatusProducto = Not _EstatusProducto
        If _EstatusProducto = True Then
            Me.PB_ESTATUS.Image = New Bitmap(My.Resources.mypc_ok)
            Me.E_ESTATUS.Text = "Activo"
        Else
            Me.PB_ESTATUS.Image = New Bitmap(My.Resources.mypc_delete)
            Me.E_ESTATUS.Text = "Inactivo"
        End If
    End Sub

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        EntradaInicial()
        _AutoProductoCargar = ""
    End Sub

    Sub New(ByVal xautoprd As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        EntradaInicial()
        _AutoProductoCargar = xautoprd
    End Sub

    Sub EntradaInicial()
        _EstatusProducto = True
        _FichaModificar = TipoFicha.Ninguna

        pb_tm = New Size(PB_1.Size)

        xfichaprd = New FichaProducto
        AddHandler xfichaprd.f_PrdProducto._ActualizarFicha, AddressOf ActualizarFicha
        AddHandler xfichaprd.f_PrdProducto._ProductoRegistrado, AddressOf ProductoNuevoAgregado

        xds = New DataSet
        xtb_departamento = New DataTable
        xtb_grupo = New DataTable
        xtb_marca = New DataTable
        xtb_subgrupo = New DataTable
        xtb_medida = New DataTable
        emp_compras = New DataTable
        emp_venta = New DataTable

        emp_venta_1 = New DataTable
        emp_venta_2 = New DataTable
        emp_venta_3 = New DataTable
        emp_venta_4 = New DataTable
    End Sub

    Private Sub FichaProductos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _MiFichaAccion = TipoAccionFicha.Inactivo Then
            e.Cancel = False
        Else
            If _MiFichaAccion = TipoAccionFicha.Adicionar Or _MiFichaAccion = TipoAccionFicha.Consultar Then
                If MessageBox.Show("Deseas Cerrar Esta Ficha De Producto y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    _MiFichaAccion = TipoAccionFicha.Inactivo
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            ElseIf _MiFichaAccion = TipoAccionFicha.Modificar Or _MiFichaAccion = TipoAccionFicha.ModificarOtro Then
                If MessageBox.Show("Deseas Cerrar Esta Ficha De Producto y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ProductoNuevoAgregado(xfichaprd.f_PrdProducto.RegistroDato._AutoProducto)
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FichaProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            AgregarProducto()
        End If
        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            ModificarProducto()
        End If
        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            EliminarProducto()
        End If
        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            If _MiFichaAccion = TipoAccionFicha.Inactivo Or _MiFichaAccion = TipoAccionFicha.Consultar Then
                IrInicio()
            End If
        End If
    End Sub

    Private Sub FichaProductos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FichaProductos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        AddHandler PB_FOTO._ImagenCargada, AddressOf ActualizarEstatusImagenProducto_Asignar
        AddHandler PB_FOTO._ImagenEliminada, AddressOf ActualizarEstatusImagenProducto_Eliminar
        Inicializa()
    End Sub

    Sub ActualizarEstatusImagenProducto_Asignar(ByVal img As String)
        Try
            Dim xr As Boolean = True
            If My.Computer.FileSystem.GetDirectoryInfo(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos).Exists Then
                If My.Computer.FileSystem.FileExists(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos + "\" + xfichaprd.f_PrdProducto.RegistroDato._AutoProducto) Then
                    My.Computer.FileSystem.DeleteFile(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos + "\" + xfichaprd.f_PrdProducto.RegistroDato._AutoProducto)
                End If
                If xr Then
                    My.Computer.FileSystem.CopyFile(img, g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos + "\" + xfichaprd.f_PrdProducto.RegistroDato._AutoProducto)
                    Dim xprd As New FichaProducto.Prd_Producto
                    AddHandler xprd._ActualizarFicha, AddressOf ProductoActualizado
                    xprd.F_ModificarFichaFoto(xfichaprd.f_PrdProducto.RegistroDato, True)
                End If
            Else
                Funciones.MensajeDeAlerta("Directorio: " & g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos & ", No Existe.. Verifique Por Favor")
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarEstatusImagenProducto_Eliminar()
        Try
            Dim xprd As New FichaProducto.Prd_Producto
            AddHandler xprd._ActualizarFicha, AddressOf ProductoActualizado
            xprd.F_ModificarFichaFoto(xfichaprd.f_PrdProducto.RegistroDato, False)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ProductoActualizado()
        Funciones.MensajeDeOk("Producto Actualizado Correctamente")
        IrInicio()
    End Sub

    Sub ActualizarRegistroProveedores(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs)
        Me.E_PROVEEDORES_ENCONTRADOS.Text = xbs_proveedores.Count.ToString
    End Sub

    Sub Inicializa()
        Try
            InicializarControles()
            xbs_existencia = New BindingSource()
            xbs_proveedores = New BindingSource()
            AddHandler xbs_proveedores.ListChanged, AddressOf ActualizarRegistroProveedores

            _MiFichaAccion = TipoAccionFicha.Inactivo
            _EmpaqueMostrar = 1

            With MG_EXISTENCIA
                .Columns.Add("col0", "Deposito")
                .Columns.Add("col1", "Cod/Dep")
                .Columns.Add("col2", "Ex. Real")
                .Columns.Add("col3", "Ex. Reserv")
                .Columns.Add("col4", "Ex. Disp")

                .Columns(1).Width = 80
                .Columns(2).Width = 80
                .Columns(3).Width = 80
                .Columns(4).Width = 80
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                AddHandler .CellFormatting, AddressOf FormatoExistencia
            End With

            With MG_CODIGOS
                .Columns.Add("col0", "Codigos")
                .Columns.Add("col1", "Descripcion")

                .Columns(0).Width = 150
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            With MG_PROVEEDORES
                .Columns.Add("col0", "Nombre")
                .Columns.Add("col1", "Cod/Proveedor")

                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).Width = 150
            End With

            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With

            Me.MCHB_PRECIO_2.Enabled = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._PermitirTrabajarPrecio_2

            If _AutoProductoCargar <> "" Then
                CargarProducto(_AutoProductoCargar)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub FormatoExistencia(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Dim xformato As String = "#0.000"
        Dim xv As Integer = 0
        If e.ColumnIndex >= 2 Then
            xv = xfichaprd.f_PrdProducto.RegistroDato._CantDecimalesEmpaqueCompra
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
            If _EmpaqueMostrar > 0 Then
                e.Value = e.Value / _EmpaqueMostrar
            End If
            e.Value = Format(e.Value, IIf(xv < 3, xformato.Substring(0, 5), xformato.Substring(0, 6)))
        End If
    End Sub

    Private Sub BT_SALIDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SALIDA.Click
        Me.Close()
    End Sub

    Private Sub LINK_EMPAQUE(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_EMP_COMPRA.LinkClicked, LINK_EMP_VENTA.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Medida.F_Permitir()

            Dim xForm As New Plantilla_11(New ProductosMedida)
            With xForm
                AddHandler .ActualizarFicha, AddressOf CargarEmpaques
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        IrInicio()
    End Sub

    Private Sub LINK_DEPARTAMENTO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_DEPARTAMENTO.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Depart.F_Permitir()

            Dim xForm As New Plantilla_1(New ProductosDepartamento)
            With xForm
                AddHandler .ActualizarFicha, AddressOf CargarDepartamento
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        IrInicio()
    End Sub

    Private Sub LINK_GRUPO_SUBGRUPO(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_GRUPO.LinkClicked, LINK_SUBGRUPO.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_GrupoSubGrupo.F_Permitir()

            Dim xForm As New GrupoProductos
            With xForm
                AddHandler ._ActualizarFicha, AddressOf CargarGrupos
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        IrInicio()
    End Sub

    Private Sub LINK_MARCA_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_MARCA.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Marca.F_Permitir()

            Dim xForm As New Plantilla_1(New ProductosMarcas)
            With xForm
                AddHandler .ActualizarFicha, AddressOf CargarMarcas
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        IrInicio()
    End Sub

    Private Sub MCB_BUSQUEDA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSQUEDA.SelectedIndexChanged
        If Me.MCB_BUSQUEDA.SelectedIndex = 7 Then
            MessageBox.Show("Alerta... Esta Opcion Solo Esta Disponible Para El Modulo De Compras", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.MCB_BUSQUEDA.SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProducto
        Else
            Me.MT_BUSCAR.Select()
        End If
    End Sub

    Private Sub BT_BUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR.Click
        BusquedaProducto()
    End Sub

    Sub BusquedaProducto()
        If MT_BUSCAR.r_Valor <> "" Then
            Dim xp1 As SqlParameter = Nothing
            Dim xp2 As SqlParameter = Nothing
            Dim xp3 As SqlParameter = Nothing
            Dim xp4 As SqlParameter = Nothing

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
                xp4 = New SqlParameter
            Else
                If CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProducto.TipoBusquedaProducto) = FichaProducto.TipoBusquedaProducto.PorSerial Then
                    Dim Tipobusq As String = ""
                    xsql = Tipobusq
                    xp1 = New SqlParameter
                    xp2 = New SqlParameter
                    xp3 = New SqlParameter
                    xp4 = New SqlParameter
                Else
                    'RESTRINGO A UN LIMITE ESTABLECIDO
                    Dim TipoBusq As String = _
                          "SELECT  top(@limite) p.nombre xnom, p.codigo xcod, p.tasa xtas, p.plu xplu, p.psv, p.auto, p.estatus,p.referencia xref, " _
                                      + "p.contenido_empaque xempcompra, pdep.nombre ndep, pgrp.nombre ngrp, pmar.nombre nmar, pmed.nombre nmed, pmed.decimales xdec " _
                                      + "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto join productos_grupo pgrp on p.auto_grupo=pgrp.auto " _
                                      + "join productos_marca pmar on p.auto_marca=pmar.auto join productos_medida pmed on p.auto_medida_compra=pmed.auto " _
                                      + "where p." + TipoB + " like @data1 and p.estatus_departamento='0' order by p." + TipoB + ";" _
                                      + "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                                      + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                                      + "where pd.auto_producto in (select top (@limite) p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                                      + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                                      + "where p." + TipoB + " like @data2 and p.estatus_departamento='0' order by p." + TipoB + ");" _
                                      + "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, pe.*, pm.* " _
                                      + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
                                      + "where pe.auto_producto in (select top (@limite) p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                                      + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                                      + "where p." + TipoB + " like @data3 and p.estatus_departamento='0' order by p." + TipoB + ") ORDER BY PE.REFERENCIA"

                    '' SIN RESTRINGIR
                    '"SELECT  p.nombre xnom, p.codigo xcod, p.tasa xtas, p.plu xplu, p.psv, p.auto, p.estatus,p.referencia xref, " _
                    '            + "p.contenido_empaque xempcompra, pdep.nombre ndep, pgrp.nombre ngrp, pmar.nombre nmar, pmed.nombre nmed, pmed.decimales xdec " _
                    '            + "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto join productos_grupo pgrp on p.auto_grupo=pgrp.auto " _
                    '            + "join productos_marca pmar on p.auto_marca=pmar.auto join productos_medida pmed on p.auto_medida_compra=pmed.auto " _
                    '            + "where p." + TipoB + " like @data1 and p.estatus_departamento='0' order by p." + TipoB + ";" _
                    '            + "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                    '            + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                    '            + "where pd.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                    '            + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                    '            + "where p." + TipoB + " like @data2 and p.estatus_departamento='0');" _
                    '            + "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, pe.*, pm.* " _
                    '            + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
                    '            + "where pe.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                    '            + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                    '            + "where p." + TipoB + " like @data3 and p.estatus_departamento='0') ORDER BY PE.REFERENCIA"
                    xsql = TipoBusq

                    If MT_BUSCAR.Text.Substring(0, 1) = "*" Then
                        xbuscar = "%" + MT_BUSCAR.r_Valor.Substring(1)
                    Else
                        xbuscar = MT_BUSCAR.r_Valor
                    End If

                    xp1 = New SqlParameter("@data1", xbuscar + "%")
                    xp2 = New SqlParameter("@data2", xbuscar + "%")
                    xp3 = New SqlParameter("@data3", xbuscar + "%")
                    xp4 = New SqlParameter("@limite", g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._LimiteProductosMostrar_AdmBusquedaNormal)
                End If
            End If

            If xsql.Trim <> "" Then
                Dim xficha As New Plantilla_5(New VistaProductos, xsql, xp1, xp2, xp3, xp4)
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

        If _MiFichaAccion = TipoAccionFicha.Inactivo Or _MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MT_BUSCAR.Select()
        End If
    End Sub

    Sub ReceptorBusAvanzada(ByVal xsql As String)
        Dim xficha As New Plantilla_5(New VistaProductos("1"), xsql)
        With xficha
            AddHandler .CapturarId_Producto, AddressOf CargarProducto
            .ShowDialog()
        End With
    End Sub

    Sub CargarProducto(ByVal id As String, Optional ByVal xtipoprecio As String = "1")
        Try
            xfichaprd.f_PrdProducto.F_BuscarProducto(id)
            MostrarData()
            _MiFichaAccion = TipoAccionFicha.Consultar
        Catch ex As Exception
            _MiFichaAccion = TipoAccionFicha.Inactivo
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarData()
        CargarDepartamento()
        CargarGrupos()
        CargarMarcas()
        CargarEmpaques()

        With Me.MCB_DEPARTAMENTO
            .DataSource = xtb_departamento
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_GRUPO
            .DataSource = xbs_grupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_SUBGRUPO
            .DataSource = xbs_subgrupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_MARCA
            .DataSource = xtb_marca
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_CATEGORIA
            .DataSource = g_MiData.f_FichaProducto.f_PrdProducto._CategoriaProducto
            .SelectedIndex = 0
        End With

        With Me.MCB_ORIGEN
            .DataSource = g_MiData.f_FichaProducto.f_PrdProducto._OrigenProducto
            .SelectedIndex = 0
        End With

        With Me.MCB_IMPUESTO
            .DataSource = g_MiData.f_FichaGlobal.f_Fiscal.r_ListaTasasFiscales
            .DisplayMember = "_TasaNombre"
            .ValueMember = "_Tasa"
            .SelectedIndex = 0
        End With

        With Me.MCB_EMP_COMPRA
            .DataSource = emp_compras
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With

        With Me.MCB_EMP_VENTA
            .DataSource = emp_venta
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With

        With Me.MCB_EMP_1
            .DataSource = emp_venta_1
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
        With Me.MCB_EMP_2
            .DataSource = emp_venta_2
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
        With Me.MCB_EMP_3
            .DataSource = emp_venta_3
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With
        With Me.MCB_EMP_4
            .DataSource = emp_venta_4
            .DisplayMember = "x1"
            .ValueMember = "x2"
        End With

        _EmpaqueMostrar = xfichaprd.f_PrdProducto.RegistroDato._ContEmpqCompra

        Dim xt As IEnumerable(Of FichaGlobal.c_TasasFiscales.Tasas) = _
               g_MiData.f_FichaGlobal.f_Fiscal.r_ListaTasasFiscales.Where(Function(p) _
                                                                              p._TasaTipo = xfichaprd.f_PrdProducto.RegistroDato._TipoImpuesto)
        Dim xv As FichaGlobal.c_TasasFiscales.Tasas = xt(0)

        With MG_CODIGOS
            .DataSource = xfichaprd.f_PrdProducto.RegistroDato.tb_CodigosAlternos
            .Columns(0).DataPropertyName = "xcodigo"
            .Columns(1).DataPropertyName = "xdetalle"
            .Ocultar(3)
        End With

        xbs_existencia.DataSource = xfichaprd.f_PrdProducto.RegistroDato.tb_Existencia
        xbs_existencia.DataMember = ""

        With MG_EXISTENCIA
            .DataSource = xbs_existencia
            .Columns(0).DataPropertyName = "xnombre"
            .Columns(1).DataPropertyName = "xcodigo"
            .Columns(2).DataPropertyName = "xreal"
            .Columns(3).DataPropertyName = "xreservada"
            .Columns(4).DataPropertyName = "xdisponible"
            .Ocultar(6)
        End With

        xbs_proveedores.DataSource = xfichaprd.f_PrdProducto.RegistroDato.tb_Proveedores
        xbs_proveedores.DataMember = ""
        Me.E_PROVEEDORES_ENCONTRADOS.Text = xbs_proveedores.Count.ToString

        With MG_PROVEEDORES
            .DataSource = xbs_proveedores
            .Columns(0).DataPropertyName = "xnombre"
            .Columns(1).DataPropertyName = "xcodigo"
            .Ocultar(3)
        End With

        Me.MT_CODIGO.Text = xfichaprd.f_PrdProducto.RegistroDato._CodigoProducto
        Me.MT_DES_GENERAL.Text = xfichaprd.f_PrdProducto.RegistroDato._DescripcionDetallaDelProducto
        Me.MT_DES_CORTA.Text = xfichaprd.f_PrdProducto.RegistroDato._DescripcionResumenDelProducto

        Me.MCB_DEPARTAMENTO.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoDepartamento()

        Me.MCB_GRUPO.Enabled = True
        Me.MCB_SUBGRUPO.Enabled = True
        Me.MCB_GRUPO.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoGrupo
        Me.MCB_SUBGRUPO.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoSubGrupo
        Me.MCB_SUBGRUPO.Enabled = False
        Me.MCB_GRUPO.Enabled = False

        Me.MCB_MARCA.Enabled = True
        Me.MCB_MARCA.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoMarca
        Me.MCB_MARCA.Enabled = False

        Me.MCB_CATEGORIA.SelectedItem = xfichaprd.f_PrdProducto.RegistroDato._CategoriaDelProducto
        Me.MCB_ORIGEN.SelectedItem = xfichaprd.f_PrdProducto.RegistroDato._OrigenDelProducto
        Me.MCB_IMPUESTO.SelectedValue = xv

        Me.MCB_EMP_COMPRA.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoEmpaqueCompra
        Me.MCB_EMP_VENTA.SelectedValue = xfichaprd.f_PrdProducto.RegistroDato._AutoEmpaqueVentaDetal
        Me.MN_CONT_EMP_COMPRA.Text = xfichaprd.f_PrdProducto.RegistroDato._ContEmpqCompra.ToString
        Me.MN_CONT_EMP_VENTA.Text = xfichaprd.f_PrdProducto.RegistroDato._ContEmpqVentaDetal.ToString

        Me.E_ESTATUS.Text = IIf(xfichaprd.f_PrdProducto.RegistroDato._EstatusProducto, "Activo", "Inactivo")
        Me.E_FECHA_ACTUALIZACION.Text = xfichaprd.f_PrdProducto.RegistroDato._FechaUltCambioPrecio
        If xfichaprd.f_PrdProducto.RegistroDato._EstatusProducto Then
            Me.PB_ESTATUS.Image = My.Resources.mypc_ok
        Else
            Me.PB_ESTATUS.Image = My.Resources.mypc_delete
        End If

        Me.MN_CT_PROV_NETO.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoProveedorCompra._Base)
        Me.MN_CT_PROV_FULL.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoProveedorCompra._Full)

        Me.E_COST_IMPORTACION.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoImportacionCompra._Base)
        Me.E_COST_OTROS.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoVariosCompra._Base)
        Me.E_COST_TOTAL_NETO.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoCompra._Base)
        Me.E_COST_TOTAL_FULL.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoCompra._Full)
        Me.E_COST_PROM_NETO.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoPromedioCompra._Base)
        Me.E_COST_PROM_FULL.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoPromedioCompra._Full)

        Me.E_COST_TOT_UNI_NETO.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoCompra._Base_Inv)
        Me.E_COST_TOT_UNI_FULL.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoCompra._Full_Inv)
        Me.E_COST_PROM_UNI_NETO.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoPromedioCompra._Base_Inv)
        Me.E_COST_PROM_UNI_FULL.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CostoPromedioCompra._Full_Inv)

        ActualizarTotalesExistencia()

        Dim xprecio_empaque As New FichaProducto.Prd_Empaque()
        For Each xrow As DataRow In xfichaprd.f_PrdProducto.RegistroDato.tb_Precios.Rows
            xprecio_empaque.M_Cargardata(xrow)

            xprecio_empaque.RegistroDato._CostoInventario = xfichaprd.f_PrdProducto.RegistroDato._CostoCompra._Base / xfichaprd.f_PrdProducto.RegistroDato._ContEmpqCompra
            xprecio_empaque.RegistroDato._TasaIva = xfichaprd.f_PrdProducto.RegistroDato._TasaImpuesto

            Select Case xprecio_empaque.RegistroDato._ReferenciaEmpaqueSeleccionado
                Case "1"
                    Me.MCB_EMP_1.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                    Me.E_EMP_VENTA_1.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                    Me.E_EMP_PNETO_VENTA_1.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                    Me.E_EMP_PFULL_VENTA_1.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                    Me.E_EMP_COSTO_VENTA_1.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)

                    If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Me.E_EMP_UTIL_VENTA_1.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        Else
                            Me.E_EMP_UTIL_VENTA_1.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        End If
                    Else
                        Me.E_EMP_UTIL_VENTA_1.Text = String.Format("{0:#0.00}", 0)
                    End If
                Case "2"
                    Me.MCB_EMP_2.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                    Me.E_EMP_VENTA_2.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                    Me.E_EMP_PNETO_VENTA_2.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                    Me.E_EMP_PFULL_VENTA_2.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                    Me.E_EMP_COSTO_VENTA_2.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)

                    If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Me.E_EMP_UTIL_VENTA_2.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        Else
                            Me.E_EMP_UTIL_VENTA_2.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        End If
                    Else
                        Me.E_EMP_UTIL_VENTA_2.Text = String.Format("{0:#0.00}", 0)
                    End If
                Case "3"
                    Me.MCB_EMP_3.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                    Me.E_EMP_VENTA_3.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                    Me.E_EMP_PNETO_VENTA_3.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                    Me.E_EMP_PFULL_VENTA_3.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                    Me.E_EMP_COSTO_VENTA_3.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)

                    If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Me.E_EMP_UTIL_VENTA_3.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        Else
                            Me.E_EMP_UTIL_VENTA_3.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        End If
                    Else
                        Me.E_EMP_UTIL_VENTA_3.Text = String.Format("{0:#0.00}", 0)
                    End If
                Case "4"
                    Me.MCB_EMP_4.SelectedValue = xprecio_empaque.RegistroDato._AutoMedida
                    Me.E_EMP_VENTA_4.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                    Me.E_EMP_PNETO_VENTA_4.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                    Me.E_EMP_PFULL_VENTA_4.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                    Me.E_EMP_COSTO_VENTA_4.Text = String.Format("{0:#,#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)

                    If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                        If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                            Me.E_EMP_UTIL_VENTA_4.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        Else
                            Me.E_EMP_UTIL_VENTA_4.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                        End If
                    Else
                        Me.E_EMP_UTIL_VENTA_4.Text = String.Format("{0:#0.00}", 0)
                    End If
            End Select
        Next

        Me.E_PRECIO_SUGERIDO.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._PrecioSugerido)
        Me.E_PRECIO_DETAL.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._PrecioDetal._Full)

        If xfichaprd.f_PrdProducto.RegistroDato.f_VerificarOferta Then
            Me.E_OFERTA_VALIDA.Text = xfichaprd.f_PrdProducto.RegistroDato._FechaCulminacionOferta.ToShortDateString
            Me.E_PRECIO_OFERTA.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._PrecioOferta._Full)
        Else
            Me.E_OFERTA_VALIDA.Text = ""
            Me.E_PRECIO_OFERTA.Text = String.Format("{0:#,#0.00}", xfichaprd.f_PrdProducto.RegistroDato._PrecioDetal._Full)
        End If

        Me.E_EMPAQUE_REFERENCIA.Text = xfichaprd.f_PrdProducto.RegistroDato._NombreEmpaqueCompra


        '
        ' Pagina #2
        '
        With Me.MCB_TIPO_BALANZA
            .DataSource = _TipoUsoBalanza
            .SelectedIndex = IIf(xfichaprd.f_PrdProducto.RegistroDato._TipoProducto = TipoProductoBalanza.Pesado, 0, 1)
        End With

        Me.MCHB_BALANZA.Checked = xfichaprd.f_PrdProducto.RegistroDato._EstatusBalanza
        Me.MN_PLU.Text = xfichaprd.f_PrdProducto.RegistroDato._PLU

        Me.MCHB_LICOR.Checked = xfichaprd.f_PrdProducto.RegistroDato._EstatusLicor
        Me.MN_LICOR_CAPACIDAD.Text = String.Format("{0:#0.00}", xfichaprd.f_PrdProducto.RegistroDato._CapacidadBotellaLicor)
        Me.MN_LICOR_GRADOS.Text = String.Format("{0:#0.00}", xfichaprd.f_PrdProducto.RegistroDato._GradosAlcoholdBotellaLicor)
        Me.MN_LICOR_TASA.Text = String.Format("{0:#0.00}", xfichaprd.f_PrdProducto.RegistroDato._TasaBotellaLicor)

        Me.MCHB_GARANTIA.Checked = xfichaprd.f_PrdProducto.RegistroDato._EstatusGarantia
        Me.MN_GARANTIA_DIAS.Text = xfichaprd.f_PrdProducto.RegistroDato._DiasDeGarantia

        Me.MN_DIM_ALTO.Text = String.Format("{0:#0.00}", xfichaprd.f_PrdProducto.RegistroDato._MedidaAlto)
        Me.MN_DIM_ANCHO.Text = String.Format("{0:#0.00}", xfichaprd.f_PrdProducto.RegistroDato._MedidaAncho)
        Me.MN_DIM_LARGO.Text = String.Format("{0:#0.00}", xfichaprd.f_PrdProducto.RegistroDato._MedidaLargo)
        Me.MN_DIM_PESO.Text = String.Format("{0:#0.00}", xfichaprd.f_PrdProducto.RegistroDato._MedidaPeso)
        Me.MN_DIM_TASA_ARANCEL.Text = String.Format("{0:#0.00}", xfichaprd.f_PrdProducto.RegistroDato._TasaArancelDelProducto)

        Me.MT_DIM_CODIGO_ARANCEL.Text = xfichaprd.f_PrdProducto.RegistroDato._CodigoArancelDelProducto
        Me.MT_CONTABLE.Text = xfichaprd.f_PrdProducto.RegistroDato._CtaContable

        Me.MT_MODELO.Text = xfichaprd.f_PrdProducto.RegistroDato._Modelo
        Me.MT_REFERENCIA.Text = xfichaprd.f_PrdProducto.RegistroDato._Referencia
        Me.MT_NUM_PARTE.Text = xfichaprd.f_PrdProducto.RegistroDato._NumeroParte

        ' PAGINA #3
        Me.MCHB_EVENTO.Checked = xfichaprd.f_PrdProducto.RegistroDato._EstatusConsumo
        Me.MN_CONSUMO_PERSONA.Text = String.Format("{0:#0.000}", xfichaprd.f_PrdProducto.RegistroDato._CantConsumo)

        '25/11/2014
        Me.MCHB_REGULADO.Checked = IIf(xfichaprd.f_PrdProducto.RegistroDato._EstaRegulado = TipoSiNo.Si, True, False)
        Me.MCHB_RESTRINGIDO.Checked = IIf(xfichaprd.f_PrdProducto.RegistroDato._EstaRestringidoVenta = TipoSiNo.Si, True, False)


        If xfichaprd.f_PrdProducto.RegistroDato._EstatusFoto = TipoEstatus.Activo Then
            Try
                Me.TabControl1.SelectedTab = TabPage2
                Dim xruta As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos + "\" + xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                PB_FOTO._CargarImagen(xruta)
            Catch ex As Exception
                PB_FOTO._CargarImagen("")
                Funciones.MensajeDeError("AL CARGAR IMAGEN DEL PRODUCTO" + vbCrLf + ex.Message)
            Finally
                Me.TabControl1.SelectedTab = TabPage1
            End Try
        Else
            PB_FOTO._CargarImagen("")
        End If
        Me.MCHB_WEB.Checked = IIf(xfichaprd.f_PrdProducto.RegistroDato._EstatusWeb = TipoEstatus.Activo, True, False)
        Me.MCHB_SERIAL.Checked = IIf(xfichaprd.f_PrdProducto.RegistroDato._EstatusSerial = TipoEstatus.Activo, True, False)
        Me.Refresh()
    End Sub

    Private Sub MG_PROVEEDORES_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_PROVEEDORES.Accion
        If _MiFichaAccion = TipoAccionFicha.Consultar Then
            If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                Try
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor.F_Permitir()
                    Dim xprv As New FichaProveedores.c_Proveedor
                    xprv.M_CargarFicha(CType(xrow.DataBoundItem, DataRowView).Row)

                    Dim xtb As New DataTable
                    Dim xsql As String = "select C.FECHA xfecha,C.DOCUMENTO xdocumento,CD.costo_final xprecio,CD.contenido_empaque xcontenido from compras_detalle CD " & _
                      "JOIN COMPRAS C ON CD.auto_documento = C.auto WHERE CD.auto_entidad=@entidad AND CD.auto_productos=@producto and c.tipo='01' ORDER BY c.fecha DESC"
                    Dim xp1 As New SqlParameter("@entidad", xprv.RegistroDato._Automatico)
                    Dim xp2 As New SqlParameter("@producto", xfichaprd.f_PrdProducto.RegistroDato._AutoProducto)
                    g_MiData.F_GetData(xsql, xtb, xp1, xp2)

                    Dim xficha As New FichaProveedor
                    With xficha
                        ._CargaInmediata = xprv.RegistroDato._Automatico
                        .Show()
                    End With

                    Dim xficha2 As New VerCostosProveedor(xtb)
                    With xficha2
                        .ShowDialog()
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            End If
        End If
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarProducto()
    End Sub

    Sub AgregarProducto()
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Or _MiFichaAccion = TipoAccionFicha.Inactivo Then
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Ingresar.F_Permitir()

                _MiFichaAccion = TipoAccionFicha.Adicionar
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        If _MiFichaAccion = TipoAccionFicha.Adicionar Then
            GrabarFichaProductoNuevo()

        Else
            Select Case _MiFichaAccion
                Case TipoAccionFicha.Modificar
                    GrabarProductoFichaPrincipalModificada()

                Case TipoAccionFicha.ModificarOtro
                    Select Case _FichaModificar
                        Case TipoFicha.Balanza
                            GrabarBalanza()
                        Case TipoFicha.Licor
                            GrabarLicor()
                        Case TipoFicha.Garantia
                            GrabarGarantia()
                        Case TipoFicha.Dimensiones
                            GrabarDimensiones()
                        Case TipoFicha.Contable
                            GrabarContable()
                        Case TipoFicha.Detalle
                            GrabarDetalle()
                        Case TipoFicha.Costo
                            GrabarCosto()
                        Case TipoFicha.EventoPresupuesto
                            GrabarPresupuestoEvento()
                        Case TipoFicha.WEB
                            GrabarWEB()
                        Case TipoFicha.SERIAL
                            GrabarSerial()
                        Case TipoFicha.ESTATUS_PRODUCTO
                            GrabarEstatusProducto()
                    End Select
            End Select
        End If
    End Sub

    Function ValidarDatos() As Boolean
        If MT_DES_GENERAL.r_Valor = "" Then
            MessageBox.Show("Descripcion Del Producto Incorrecta... Verifique Por Favor", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_DES_GENERAL.Select()
            Me.MT_DES_GENERAL.Focus()
            Return False
        End If

        If Me.MCB_DEPARTAMENTO.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun Departamento Seleccionado Para Este Producto... Verifique Por Favor", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_DEPARTAMENTO.Select()
            Me.MCB_DEPARTAMENTO.Focus()
            Return False
        End If

        If Me.MCB_GRUPO.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun Grupo Seleccionado Para Este Producto... Verifique Por Favor", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_GRUPO.Select()
            Me.MCB_GRUPO.Focus()
            Return False
        End If

        If Me.MCB_SUBGRUPO.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun SubGrupo Seleccionado Para Este Producto... Verifique Por Favor", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_SUBGRUPO.Select()
            Me.MCB_SUBGRUPO.Focus()
            Return False
        End If

        If Me.MCB_MARCA.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ninguna Marca Seleccionada Para Este Producto... Verifique Por Favor", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_MARCA.Select()
            Me.MCB_MARCA.Focus()
            Return False
        End If

        If Me.MCB_EMP_COMPRA.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun Empaque De Compra Seleccionado Para Este Producto... Verifique Por Favor", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_EMP_COMPRA.Select()
            Me.MCB_EMP_COMPRA.Focus()
            Return False
        End If

        If Me.MCB_EMP_VENTA.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun Empaque De Venta Seleccionado Para Este Producto... Verifique Por Favor", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_EMP_VENTA.Select()
            Me.MCB_EMP_VENTA.Focus()
            Return False
        End If

        Return True
    End Function

    Sub GrabarFichaProductoNuevo()
        If ValidarDatos() Then
            If MessageBox.Show("Deseas Guardar Esta Ficha De Producto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xtasa As FichaGlobal.c_TasasFiscales.Tasas = Me.MCB_IMPUESTO.SelectedValue
                    Dim xagregar As New FichaProducto.Prd_Producto.c_AgregarProducto
                    With xagregar
                        ._AutoDepartamento = Me.MCB_DEPARTAMENTO.SelectedValue
                        ._AutoEmpqCompra = Me.MCB_EMP_COMPRA.SelectedValue
                        ._AutoEmpqVenta = Me.MCB_EMP_VENTA.SelectedValue
                        ._AutoGrupo = Me.MCB_GRUPO.SelectedValue
                        ._AutoMarca = Me.MCB_MARCA.SelectedValue
                        ._AutoSubGrupo = Me.MCB_SUBGRUPO.SelectedValue
                        ._Categoria = Me.MCB_CATEGORIA.SelectedItem
                        ._CodigoProducto = Me.MT_CODIGO.r_Valor
                        ._ContenidoEmpqCompra = Me.MN_CONT_EMP_COMPRA._Valor
                        ._ContenidoEmpqVentaDetal = Me.MN_CONT_EMP_VENTA._Valor
                        ._DescripcionGeneral = Me.MT_DES_GENERAL.r_Valor
                        ._DescripcionResumen = Me.MT_DES_CORTA.r_Valor
                        ._Estatus = TipoEstatus.Activo
                        ._FechaAlta = g_MiData.p_FechaDelMotorBD
                        ._Origen = Me.MCB_ORIGEN.SelectedItem
                        ._TasaIva = xtasa._TasaValor
                        ._TipoImpuesto = xtasa._TasaTipo
                        ._AutoDepositoDefecto = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoInventarioVentas
                        ._Hora = g_MiData.p_HoraDelMotorBD
                        ._Equipoestacion = g_EquipoEstacion.p_EstacionNombre
                        ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                    End With
                    xfichaprd.f_PrdProducto.F_AgregarProducto(xagregar)
                    MessageBox.Show("Producto Registrado Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                Me.MT_DES_GENERAL.Select()
                Me.MT_DES_GENERAL.Focus()
            End If
        End If
    End Sub

    Sub GrabarProductoFichaPrincipalModificada()
        Try
            If ValidarDatos() Then
                If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim xtasa As FichaGlobal.c_TasasFiscales.Tasas = Me.MCB_IMPUESTO.SelectedValue
                        Dim xmodificar As New FichaProducto.Prd_Producto.c_ModificarFichaPrincipalProducto
                        With xmodificar
                            ._AutoDepartamento = Me.MCB_DEPARTAMENTO.SelectedValue
                            ._AutoEmpqCompra = Me.MCB_EMP_COMPRA.SelectedValue
                            ._AutoEmpqVenta = Me.MCB_EMP_VENTA.SelectedValue
                            ._AutoGrupo = Me.MCB_GRUPO.SelectedValue
                            ._AutoMarca = Me.MCB_MARCA.SelectedValue
                            ._AutoSubGrupo = Me.MCB_SUBGRUPO.SelectedValue
                            ._Categoria = Me.MCB_CATEGORIA.SelectedItem
                            ._CodigoProducto = Me.MT_CODIGO.r_Valor
                            ._ContenidoEmpqCompra = IIf(Me.MN_CONT_EMP_COMPRA._Valor > 0, Me.MN_CONT_EMP_COMPRA._Valor, 1)
                            ._ContenidoEmpqVentaDetal = IIf(Me.MN_CONT_EMP_VENTA._Valor > 0, Me.MN_CONT_EMP_VENTA._Valor, 1)
                            ._DescripcionGeneral = Me.MT_DES_GENERAL.r_Valor
                            ._DescripcionResumen = Me.MT_DES_CORTA.r_Valor
                            ._Estatus = IIf(_EstatusProducto, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._FechaAlta = g_MiData.p_FechaDelMotorBD
                            ._Origen = Me.MCB_ORIGEN.SelectedItem
                            ._TasaIva = xtasa._TasaValor
                            ._TipoImpuesto = xtasa._TasaTipo
                            ._AutoDepositoDefecto = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_AutoDepositoMovimientoInventarioVentas
                            ._Hora = g_MiData.p_HoraDelMotorBD
                            ._Equipoestacion = g_EquipoEstacion.p_EstacionNombre
                            ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato

                            ._AutoProducto = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                            ._FechaModificacion = g_MiData.p_FechaDelMotorBD
                            ._IdSeguridad = xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad
                        End With
                        xfichaprd.f_PrdProducto.F_ModificarProducto_FichaPrincipal(xmodificar)
                        MessageBox.Show("Producto Registrado Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    Me.MT_DES_GENERAL.Select()
                    Me.MT_DES_GENERAL.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GrabarBalanza()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xficha As New FichaProducto.Prd_Producto.c_ModificarFichaBalanza
                With xficha
                    ._AutoProducto = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                    If Me.MN_PLU._Valor > 0 Then
                        ._CodigoPLU = Me.MN_PLU._Valor.ToString.Trim.PadLeft(5, "0")
                    End If
                    ._EstatusBalanza = IIf(Me.MCHB_BALANZA.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                    ._TipoPesado = IIf(Me.MCB_TIPO_BALANZA.SelectedIndex = 0, TipoProductoBalanza.Pesado, TipoProductoBalanza.Unidad)
                    ._IdSeguridad = xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad
                End With
                xfichaprd.f_PrdProducto.F_ModificarFichaBalanza(xficha)
                MessageBox.Show("Producto Registrado Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Me.MCHB_BALANZA.Select()
        End If
    End Sub

    Sub GrabarLicor()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xficha As New FichaProducto.Prd_Producto.c_ModificarFichaLicor
                With xficha
                    ._AutoProducto = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                    ._CapacidadBotella = Me.MN_LICOR_CAPACIDAD._Valor
                    ._EstatusLicor = IIf(Me.MCHB_LICOR.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                    ._GradosAlcohol = Me.MN_LICOR_GRADOS._Valor
                    ._TasaLicor = Me.MN_LICOR_TASA._Valor
                    ._IdSeguridad = xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad
                End With
                xfichaprd.f_PrdProducto.F_ModificarFichaLicor(xficha)
                MessageBox.Show("Producto Registrado Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Me.MCHB_LICOR.Select()
        End If
    End Sub

    Sub GrabarGarantia()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xficha As New FichaProducto.Prd_Producto.c_ModificarFichaGarantia
                With xficha
                    ._AutoProducto = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                    ._DiasGarantia = Me.MN_GARANTIA_DIAS._Valor
                    ._EstatusGarantia = IIf(Me.MCHB_GARANTIA.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                    ._IdSeguridad = xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad
                End With
                xfichaprd.f_PrdProducto.F_ModificarFichaGarantia(xficha)
                MessageBox.Show("Producto Registrado Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Me.MCHB_GARANTIA.Select()
        End If
    End Sub

    Sub GrabarDimensiones()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xficha As New FichaProducto.Prd_Producto.c_ModificarFichaDimensiones
                With xficha
                    ._AutoProducto = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                    ._Alto = Me.MN_DIM_ALTO._Valor
                    ._Ancho = Me.MN_DIM_ANCHO._Valor
                    ._CodigoArancel = Me.MT_DIM_CODIGO_ARANCEL.r_Valor
                    ._Largo = Me.MN_DIM_LARGO._Valor
                    ._Peso = Me.MN_DIM_PESO._Valor
                    ._TasaArancel = Me.MN_DIM_TASA_ARANCEL._Valor
                    ._IdSeguridad = xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad
                End With
                xfichaprd.f_PrdProducto.F_ModificarFichaDimensiones(xficha)
                MessageBox.Show("Producto Registrado Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Me.MN_DIM_ALTO.Select()
        End If
    End Sub

    Sub GrabarContable()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xficha As New FichaProducto.Prd_Producto.c_ModificarFichaContabilidad
                With xficha
                    ._AutoProducto = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                    ._CtaContable = Me.MT_CONTABLE.r_Valor
                    ._IdSeguridad = xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad
                End With
                xfichaprd.f_PrdProducto.F_ModificarFichaContable(xficha)
                MessageBox.Show("Producto Registrado Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Me.MT_CONTABLE.Select()
        End If
    End Sub

    Sub GrabarDetalle()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xficha As New FichaProducto.Prd_Producto.c_ModificarFichaDetalle
                With xficha
                    ._AutoProducto = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                    ._Modelo = Me.MT_MODELO.r_Valor
                    ._NumParte = Me.MT_NUM_PARTE.r_Valor
                    ._Referencia = Me.MT_REFERENCIA.r_Valor
                    ._IdSeguridad = xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad
                End With
                xfichaprd.f_PrdProducto.F_ModificarFichaDetalle(xficha)
                MessageBox.Show("Producto Registrado Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Me.MT_MODELO.Select()
        End If
    End Sub

    Sub GrabarCosto()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xficha As New FichaProducto.Prd_Producto.c_ModificarCosto
                With xficha
                    ._AutoProducto = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                    ._CostoAnterior = xfichaprd.f_PrdProducto.RegistroDato._CostoProveedorCompra._Base
                    ._CostoNuevo = Me.MN_CT_PROV_NETO._Valor
                    ._EmpaqueMedida = xfichaprd.f_PrdProducto.RegistroDato._NombreEmpaqueCompra
                    ._Equipoestacion = g_EquipoEstacion.p_EstacionNombre
                    ._FechaMovimiento = g_MiData.p_FechaDelMotorBD
                    ._FichaUsuario = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato
                    ._Hora = g_MiData.p_HoraDelMotorBD
                    ._ContenidoEmpaque = xfichaprd.f_PrdProducto.RegistroDato._ContEmpqCompra
                    ._IdSeguridad = xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad
                End With
                xfichaprd.f_PrdProducto.F_ModificarFichaCosto(xficha)
                MessageBox.Show("Producto Registrado Exitosamente... Ok", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Me.MN_CT_PROV_NETO.Select()
        End If
    End Sub

    Sub ActualizarFicha()
        Dim xauto As String = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
        LimpiarFicha()
        CargarProducto(xauto)
    End Sub

    Sub ProductoNuevoAgregado(ByVal xauto As String)
        LimpiarFicha()
        CargarProducto(xauto)
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarProducto()
    End Sub

    Sub EliminarProducto()
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Eliminar.F_Permitir()

                    Try
                        If MessageBox.Show("Estas Seguro De Eliminar Esta Ficha De Producto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            If xfichaprd.f_PrdProducto.F_EliminarProducto(xfichaprd.f_PrdProducto.RegistroDato._AutoProducto) Then
                                MessageBox.Show("Producto Eliminado Con Exito...", "*** Mensaje De Exito ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                _MiFichaAccion = TipoAccionFicha.Inactivo
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarPrecioVenta()
        Try
            If Me.MCHB_PRECIO_2.Checked = False Then
                Dim xprecio_empaque As New FichaProducto.Prd_Empaque()
                For Each xrow As DataRow In xfichaprd.f_PrdProducto.RegistroDato.tb_Precios.Rows
                    xprecio_empaque.M_Cargardata(xrow)
                    xprecio_empaque.RegistroDato._CostoInventario = xfichaprd.f_PrdProducto.RegistroDato._CostoCompra._Base_Inv
                    xprecio_empaque.RegistroDato._TasaIva = xfichaprd.f_PrdProducto.RegistroDato._TasaImpuesto

                    Select Case xprecio_empaque.RegistroDato._ReferenciaEmpaqueSeleccionado
                        Case "1"
                            Me.E_EMP_VENTA_1.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                            Me.E_EMP_PNETO_VENTA_1.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                            Me.E_EMP_PFULL_VENTA_1.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                            Me.E_EMP_COSTO_VENTA_1.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)

                            If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    Me.E_EMP_UTIL_VENTA_1.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                                Else
                                    Me.E_EMP_UTIL_VENTA_1.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                                End If
                            Else
                                Me.E_EMP_UTIL_VENTA_1.Text = String.Format("{0:#0.00}", 0)
                            End If
                        Case "2"
                            Me.E_EMP_VENTA_2.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                            Me.E_EMP_PNETO_VENTA_2.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                            Me.E_EMP_PFULL_VENTA_2.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                            Me.E_EMP_COSTO_VENTA_2.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)

                            If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    Me.E_EMP_UTIL_VENTA_2.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                                Else
                                    Me.E_EMP_UTIL_VENTA_2.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                                End If
                            Else
                                Me.E_EMP_UTIL_VENTA_2.Text = String.Format("{0:#0.00}", 0)
                            End If
                        Case "3"
                            Me.E_EMP_VENTA_3.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                            Me.E_EMP_PNETO_VENTA_3.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                            Me.E_EMP_PFULL_VENTA_3.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                            Me.E_EMP_COSTO_VENTA_3.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)

                            If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    Me.E_EMP_UTIL_VENTA_3.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                                Else
                                    Me.E_EMP_UTIL_VENTA_3.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                                End If
                            Else
                                Me.E_EMP_UTIL_VENTA_3.Text = String.Format("{0:#0.00}", 0)
                            End If
                        Case "4"
                            Me.E_EMP_VENTA_4.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                            Me.E_EMP_PNETO_VENTA_4.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_1)
                            Me.E_EMP_PFULL_VENTA_4.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_1)
                            Me.E_EMP_COSTO_VENTA_4.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._CostoEmpaque)

                            If xprecio_empaque.RegistroDato._PrecioNeto_1 > 0 Then
                                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    Me.E_EMP_UTIL_VENTA_4.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                                Else
                                    Me.E_EMP_UTIL_VENTA_4.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_1, xprecio_empaque.RegistroDato._MargenUtilidad_1))
                                End If
                            Else
                                Me.E_EMP_UTIL_VENTA_4.Text = String.Format("{0:#0.00}", 0)
                            End If
                    End Select
                Next
            Else
                Dim xprecio_empaque As New FichaProducto.Prd_Empaque()
                For Each xrow As DataRow In xfichaprd.f_PrdProducto.RegistroDato.tb_Precios.Rows
                    xprecio_empaque.M_Cargardata(xrow)
                    xprecio_empaque.RegistroDato._CostoInventario = xfichaprd.f_PrdProducto.RegistroDato._CostoCompra._Base_Inv
                    xprecio_empaque.RegistroDato._TasaIva = xfichaprd.f_PrdProducto.RegistroDato._TasaImpuesto

                    Select Case xprecio_empaque.RegistroDato._ReferenciaEmpaqueSeleccionado
                        Case "1"
                            Me.E_EMP_VENTA_1.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                            Me.E_EMP_PNETO_VENTA_1.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_2)
                            Me.E_EMP_PFULL_VENTA_1.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_2)
                            Me.E_EMP_COSTO_VENTA_1.Text = xprecio_empaque.RegistroDato._CostoEmpaque
                            If xprecio_empaque.RegistroDato._PrecioNeto_2 > 0 Then
                                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    Me.E_EMP_UTIL_VENTA_1.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                                Else
                                    Me.E_EMP_UTIL_VENTA_1.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_2, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                                End If
                            Else
                                Me.E_EMP_UTIL_VENTA_1.Text = "0.0"
                            End If
                        Case "2"
                            Me.E_EMP_VENTA_2.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                            Me.E_EMP_PNETO_VENTA_2.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_2)
                            Me.E_EMP_PFULL_VENTA_2.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_2)
                            Me.E_EMP_COSTO_VENTA_2.Text = xprecio_empaque.RegistroDato._CostoEmpaque
                            If xprecio_empaque.RegistroDato._PrecioNeto_2 > 0 Then
                                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    Me.E_EMP_UTIL_VENTA_2.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                                Else
                                    Me.E_EMP_UTIL_VENTA_2.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_2, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                                End If
                            Else
                                Me.E_EMP_UTIL_VENTA_2.Text = "0.0"
                            End If
                        Case "3"
                            Me.E_EMP_VENTA_3.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                            Me.E_EMP_PNETO_VENTA_3.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_2)
                            Me.E_EMP_PFULL_VENTA_3.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_2)
                            Me.E_EMP_COSTO_VENTA_3.Text = xprecio_empaque.RegistroDato._CostoEmpaque
                            If xprecio_empaque.RegistroDato._PrecioNeto_2 > 0 Then
                                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    Me.E_EMP_UTIL_VENTA_3.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                                Else
                                    Me.E_EMP_UTIL_VENTA_3.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_2, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                                End If
                            Else
                                Me.E_EMP_UTIL_VENTA_3.Text = "0.0"
                            End If
                        Case "4"
                            Me.E_EMP_VENTA_4.Text = xprecio_empaque.RegistroDato._ContenidoEmpaque.ToString
                            Me.E_EMP_PNETO_VENTA_4.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioNeto_2)
                            Me.E_EMP_PFULL_VENTA_4.Text = String.Format("{0:#0.00}", xprecio_empaque.RegistroDato._PrecioFull_2)
                            Me.E_EMP_COSTO_VENTA_4.Text = xprecio_empaque.RegistroDato._CostoEmpaque
                            If xprecio_empaque.RegistroDato._PrecioNeto_2 > 0 Then
                                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    Me.E_EMP_UTIL_VENTA_4.Text = String.Format("{0:#0.00}", UtilidadBaseCosto(xprecio_empaque.RegistroDato._CostoEmpaque, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                                Else
                                    Me.E_EMP_UTIL_VENTA_4.Text = String.Format("{0:#0.00}", UtilidadBasePrecioVenta(xprecio_empaque.RegistroDato._PrecioNeto_2, xprecio_empaque.RegistroDato._MargenUtilidad_2))
                                End If
                            Else
                                Me.E_EMP_UTIL_VENTA_4.Text = "0.0"
                            End If
                    End Select
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MCHB_PRECIO_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_PRECIO_2.CheckedChanged
        If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
            MostrarPrecioVenta()
        End If
        IrInicio()
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarProducto()
    End Sub

    Sub ModificarProducto()
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _MiFichaAccion = TipoAccionFicha.Modificar
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MG_EXISTENCIA_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_EXISTENCIA.Accion
        If _MiFichaAccion = TipoAccionFicha.Consultar Then
            If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                Try
                    Dim xr As DataRow = CType(xrow.DataBoundItem, System.Data.DataRowView).Row
                    Dim xprddep As New FichaProducto.Prd_Deposito(xr)

                    Dim xficha As New FichaDeposito(xprddep)
                    AddHandler xficha._ActualizarFichaProducto, AddressOf ActualizarTablaDepositos
                    With xficha
                        .ShowDialog()
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub ActualizarCosto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActualizarCosto.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_ModificarCosto.F_Permitir()

                    _FichaModificar = TipoFicha.Costo
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub HistoricoCostos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles HistoricoCostos.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then

                    Dim xficha As New Plantilla_Historial(New Hisotirial_ProductoCosto(xfichaprd.f_PrdProducto.RegistroDato))
                    With xficha
                        .ShowDialog()
                    End With
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarFichaBalanza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActualizarFichaBalanza.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _FichaModificar = TipoFicha.Balanza
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarFichaLicor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActualizarFichaLicor.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _FichaModificar = TipoFicha.Licor
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarFichaGarantia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActualizarFichaGarantia.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _FichaModificar = TipoFicha.Garantia
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarFichaDimensiones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActualizarFichaDimensiones.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _FichaModificar = TipoFicha.Dimensiones
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarFichaContable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActualizarFichaContable.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _FichaModificar = TipoFicha.Contable
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarFichaDetalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActualizarFichaDetalle.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _FichaModificar = TipoFicha.Detalle
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarFichaProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActualizarFichaProveedor.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    Dim xficha As New ProductoProveedor(xfichaprd.f_PrdProducto)
                    With xficha
                        .ShowDialog()
                    End With
                    ActualizarCodigosProveedores()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarCodigosProveedores()
        Try
            CargarProducto(xfichaprd.f_PrdProducto.RegistroDato._AutoProducto)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub MCHB_BALANZA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_BALANZA.CheckedChanged
        Me.MN_PLU.Enabled = Me.MCHB_BALANZA.Checked
        Me.MCB_TIPO_BALANZA.Enabled = Me.MCHB_BALANZA.Checked
    End Sub

    Private Sub MCHB_LICOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_LICOR.CheckedChanged
        Me.MN_LICOR_CAPACIDAD.Enabled = Me.MCHB_LICOR.Checked
        Me.MN_LICOR_GRADOS.Enabled = Me.MCHB_LICOR.Checked
        Me.MN_LICOR_TASA.Enabled = Me.MCHB_LICOR.Checked
    End Sub

    Private Sub MCHB_GARANTIA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_GARANTIA.CheckedChanged
        Me.MN_GARANTIA_DIAS.Enabled = Me.MCHB_GARANTIA.Checked
    End Sub

    Sub CodigosAlternos()
        If _MiFichaAccion = TipoAccionFicha.Consultar Then
            If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                Dim xficha As New ProductosAlternos(xfichaprd.f_PrdProducto.RegistroDato)
                With xficha
                    AddHandler .ActualizarTablas, AddressOf ActualizarTablaAlternos
                    .ShowDialog()
                End With
            End If
        End If
        IrInicio()
    End Sub

    Private Sub BT_CODIGOS_ALTERNOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CODIGOS_ALTERNOS.Click
        CodigosAlternos()
    End Sub

    Sub ActualizarTablaAlternos()
        Try
            If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                xfichaprd.f_PrdProducto.F_ActualizarTablaCodigosAlternos()
                Me.MG_CODIGOS.DataSource = xfichaprd.f_PrdProducto.RegistroDato.tb_CodigosAlternos
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub MG_CODIGOS_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_CODIGOS.Accion
        CodigosAlternos()
    End Sub

    Private Sub MN_CT_PROV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MN_CT_PROV_NETO.LostFocus, MN_CT_PROV_FULL.LostFocus
        CalcularCosto(sender)
    End Sub

    Sub CalcularCosto(ByVal sender As Object)
        Dim xc As MisControles.Controles.MisNumeros = CType(sender, MisControles.Controles.MisNumeros)
        Dim xcost As Precio = Nothing
        Dim xcost_total As Precio = Nothing
        Dim xcost_total_inv As PrecioCosto = Nothing

        If xc.Name = "MN_CT_PROV_NETO" Then
            xcost = New Precio(xc._Valor, xfichaprd.f_PrdProducto.RegistroDato._TasaImpuesto)
            Me.MN_CT_PROV_FULL.Text = String.Format("{0:#0.00}", xcost._Full)
        ElseIf xc.Name = "MN_CT_PROV_FULL" Then
            xcost = New Precio(xc._Valor, xfichaprd.f_PrdProducto.RegistroDato._TasaImpuesto, Precio.TipoFuncion.Desglozar)
            Me.MN_CT_PROV_NETO.Text = String.Format("{0:#0.00}", xcost._Base)
        End If

        Dim xbase As Decimal = xfichaprd.f_PrdProducto.RegistroDato._CostoImportacionCompra._Base + _
                                xfichaprd.f_PrdProducto.RegistroDato._CostoVariosCompra._Base + _
                                 xcost._Base

        xcost_total = New Precio(xbase, xfichaprd.f_PrdProducto.RegistroDato._TasaImpuesto)
        Me.E_COST_TOTAL_NETO.Text = String.Format("{0:#0.00}", xcost_total._Base)
        Me.E_COST_TOTAL_FULL.Text = String.Format("{0:#0.00}", xcost_total._Full)
        Me.E_COST_PROM_NETO.Text = String.Format("{0:#0.00}", xcost_total._Base)
        Me.E_COST_PROM_FULL.Text = String.Format("{0:#0.00}", xcost_total._Full)

        xcost_total_inv = New PrecioCosto(xcost_total._Base, xfichaprd.f_PrdProducto.RegistroDato._TasaImpuesto, xfichaprd.f_PrdProducto.RegistroDato._ContEmpqCompra)
        Me.E_COST_TOT_UNI_NETO.Text = String.Format("{0:#0.00}", xcost_total_inv._Base_Inv)
        Me.E_COST_TOT_UNI_FULL.Text = String.Format("{0:#0.00}", xcost_total_inv._Full_Inv)
        Me.E_COST_PROM_UNI_NETO.Text = String.Format("{0:#0.00}", xcost_total_inv._Base_Inv)
        Me.E_COST_PROM_UNI_FULL.Text = String.Format("{0:#0.00}", xcost_total_inv._Full_Inv)
    End Sub

    Private Sub VER_UNIDADCOMPRA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VER_UNIDADCOMPRA.Click
        If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
            _EmpaqueMostrar = xfichaprd.f_PrdProducto.RegistroDato._ContEmpqCompra
            Me.E_EMPAQUE_REFERENCIA.Text = xfichaprd.f_PrdProducto.RegistroDato._NombreEmpaqueCompra
            xbs_existencia.CurrencyManager.Refresh()
            ActualizarTotalesExistencia()
        End If
    End Sub

    Private Sub VER_UNIDADVENTADETAL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VER_UNIDADVENTADETAL.Click
        If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
            _EmpaqueMostrar = xfichaprd.f_PrdProducto.RegistroDato._ContEmpqVentaDetal
            Me.E_EMPAQUE_REFERENCIA.Text = xfichaprd.f_PrdProducto.RegistroDato._NombreEmpaqueVentaDetal
            xbs_existencia.CurrencyManager.Refresh()
            ActualizarTotalesExistencia()
        End If
    End Sub

    Private Sub KARDEX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KARDEX.Click
        If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Kardex.F_Permitir()

                Dim xini As Date
                Dim xfin As Date
                Dim xest As Boolean

                Dim xficha As New Plantilla_DesdeHasta
                With xficha
                    .ShowDialog()
                    If ._Estatus Then
                        xini = ._FechaInicio
                        xfin = ._FechaFin
                        xest = ._Estatus
                    End If
                End With

                If xest Then
                    Dim xds As DataSet = New DataSet
                    Dim xpar1 As New SqlParameter("@auto_producto", xfichaprd.f_PrdProducto.RegistroDato._AutoProducto)
                    Dim xpar2 As New SqlParameter("@fecha", xini.Date)
                    Dim xpar3 As New SqlParameter("@fecha_i", xini.Date)
                    Dim xpar4 As New SqlParameter("@fecha_f", xfin.Date)
                    Dim xpar5 As New SqlParameter("@auto", xfichaprd.f_PrdProducto.RegistroDato._AutoProducto)

                    Dim xsql As String = "SELECT (SELECT SUM(CANTIDAD_INVENTARIO*SIGNO) FROM PRODUCTOS_KARDEX " _
                      + "WHERE AUTO_PRODUCTO=pk.auto_producto AND estatus='0' AND fecha <@fecha " _
                      + "and auto_deposito=pk.auto_deposito) SALDO_ANTERIOR, " _
                      + "PK.FECHA, PK.DOCUMENTO, PK.ENTIDAD, " _
                      + "Pk.n_NombreMedidaEmpaque NOM_MEDIDA, Pk.n_ContenidoMedidaEmpaque CONTENIDO, PK.CANTIDAD_INVENTARIO CANTIDAD, pk.n_codigoconcepto COD_CONCEPTO, " _
                      + "pk.n_NombreConcepto NOM_CONCEPTO, PK.SIGNO,d.nombre NOM_DEPOSITO,d.codigo COD_DEPOSITO " _
                      + "FROM PRODUCTOS_KARDEX PK JOIN depositos d on pk.auto_deposito=d.auto " _
                      + "WHERE PK.AUTO_PRODUCTO=@auto_producto AND PK.estatus='0' " _
                      + "AND PK.fecha >=@fecha_i AND PK.fecha <=@fecha_f ORDER BY pk.fecha,PK.DOCUMENTO;" _
                      + "SELECT nombre,rif,direccion from empresa;" _
                      + "SELECT nombre,codigo from productos where auto=@auto"

                    g_MiData.F_GetData(xsql, xds, xpar1, xpar2, xpar3, xpar4, xpar5)
                    xds.Tables(0).TableName = "Kardex"
                    xds.Tables(1).TableName = "Empresa"
                    xds.Tables(2).TableName = "Producto"

                    Dim xp1 As New _Reportes.ParamtCrystal("@fecha", xini.Date)
                    Dim xp2 As New _Reportes.ParamtCrystal("@fecha_f", xfin.Date)
                    Dim xlist As New List(Of _Reportes.ParamtCrystal)
                    xlist.Add(xp1)
                    xlist.Add(xp2)

                    Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                    xrep += "KARDEX.rpt"
                    Dim xficha2 As New _Reportes(xds, xrep, xlist)
                    With xficha2
                        .Show()
                    End With

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ACTUALIZARINVENTARIO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ACTUALIZARINVENTARIO.Click
        ActualizarAjustarInventario()
    End Sub

    Sub ActualizarAjustarInventario()
        If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_ModificarExistencia.F_Permitir()

                Dim xficha As New Plantilla_AjusteInventario(xfichaprd)
                With xficha
                    AddHandler ._ActualizarDepositos, AddressOf ActualizarTablaDepositos
                    .ShowDialog()
                End With
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Sub ActualizarTablaDepositos()
        Try
            If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                CargarProducto(xfichaprd.f_PrdProducto.RegistroDato._AutoProducto)
                'xfichaprd.f_PrdProducto.F_ActualizarTablaDepositos()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarCargaDepositos(ByVal xautoprd As String)
        Try
            _MiFichaAccion = TipoAccionFicha.Consultar
            xfichaprd.f_PrdProducto.F_BuscarProducto(xautoprd)
            MostrarData()
        Catch ex As Exception
            Funciones.MensajeDeAlerta(ex.Message)
        End Try
    End Sub

    Private Sub ASIGNARELIMINARDEPOSITO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ASIGNARELIMINARDEPOSITO.Click
        If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_ModificarExistencia.F_Permitir()

                Dim xficha As New InventarioDepositos(xfichaprd)
                With xficha
                    AddHandler ._ActualizarCargaDepositos, AddressOf ActualizarCargaDepositos
                    AddHandler ._ActualizarDepositos, AddressOf ActualizarTablaDepositos
                    .ShowDialog()
                End With
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ActualizarPrecio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActualizarPrecio.Click
        If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_ModificarPrecios.F_Permitir()

                Dim xficha As New ActualizarPrecios(xfichaprd, New ActualizarPrecio_Inventario)
                AddHandler xficha._ActualizarProductoId, AddressOf CargarProducto
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub HistorialDePrecios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles HistorialDePrecios.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then

                    Dim xficha As New Plantilla_Historial(New Hisotirial_ProductoPrecios(xfichaprd.f_PrdProducto.RegistroDato))
                    With xficha
                        .ShowDialog()
                    End With
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ContextMenuStrip2_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        If _MiFichaAccion = TipoAccionFicha.Consultar Then
            If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" And xfichaprd.f_PrdProducto.RegistroDato.f_VerificarOferta Then
                OfertaPromocion_Desactivar.Enabled = True
            Else
                OfertaPromocion_Desactivar.Enabled = False
            End If
        End If
    End Sub

    Private Sub OfertaPromocion_Desactivar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OfertaPromocion_Desactivar.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    If xfichaprd.f_PrdProducto.RegistroDato.f_VerificarOferta Then

                        If MessageBox.Show("Deseas Desactivar La Oferta / Promocion Para Este Producto ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Try
                                xfichaprd.f_PrdProducto.F_DesactivarOfertaProducto(xfichaprd.f_PrdProducto.RegistroDato._AutoProducto, xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad)
                                MessageBox.Show("Cambio Efectuado Satisfactoriamente... OK", "*** Mensaje De Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally
                                CargarProducto(xfichaprd.f_PrdProducto.RegistroDato._AutoProducto)
                            End Try
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OfertaPromocion_Activar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OfertaPromocion_Activar.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    Dim xficha As New ProductoOfertaPromocion(xfichaprd.f_PrdProducto.RegistroDato)
                    AddHandler xficha._ActualizarFicha, AddressOf PromocionActualizarFicha
                    With xficha
                        .ShowDialog()
                    End With
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub PromocionActualizarFicha()
        CargarProducto(xfichaprd.f_PrdProducto.RegistroDato._AutoProducto)
    End Sub

    Private Sub ContextMenuStrip11_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip11.Opening
        If _MiFichaAccion = TipoAccionFicha.Consultar Then
            If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" And xfichaprd.f_PrdProducto.RegistroDato._EstatusFoto Then
            Else
                CARGAR_IMAGEN.Enabled = True
                ACTIVAR_CAMARA.Enabled = True
                ELIMINAR_IMAGEN.Enabled = False
                ACTUALIZAR_IMAGEN.Enabled = False
            End If
        End If
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

    Private Sub IMPORTARFICHANUEVA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IMPORTARFICHANUEVA.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    Dim x1 As String = xfichaprd.f_PrdProducto.RegistroDato._CodigoProducto
                    Dim x2 As String = xfichaprd.f_PrdProducto.RegistroDato._DescripcionDetallaDelProducto
                    Dim x3 As String = xfichaprd.f_PrdProducto.RegistroDato._DescripcionResumenDelProducto
                    Dim x4 As String = xfichaprd.f_PrdProducto.RegistroDato._AutoDepartamento
                    Dim x5 As String = xfichaprd.f_PrdProducto.RegistroDato._AutoGrupo
                    Dim x6 As String = xfichaprd.f_PrdProducto.RegistroDato._AutoSubGrupo
                    Dim x7 As String = xfichaprd.f_PrdProducto.RegistroDato._AutoMarca
                    Dim x8 As String = xfichaprd.f_PrdProducto.RegistroDato._OrigenDelProducto
                    Dim x9 As String = xfichaprd.f_PrdProducto.RegistroDato._CategoriaDelProducto
                    Dim xa As String = xfichaprd.f_PrdProducto.RegistroDato._AutoEmpaqueCompra
                    Dim xb As Integer = xfichaprd.f_PrdProducto.RegistroDato._ContEmpqCompra
                    Dim xc As String = xfichaprd.f_PrdProducto.RegistroDato._AutoEmpaqueVentaDetal
                    Dim xd As Integer = xfichaprd.f_PrdProducto.RegistroDato._ContEmpqVentaDetal
                    Dim xe As FichaGlobal.c_TasasFiscales.Tasas = Me.MCB_IMPUESTO.SelectedValue

                    AgregarProducto()
                    Me.MT_CODIGO.Text = x1
                    Me.MT_DES_GENERAL.Text = x2
                    Me.MT_DES_CORTA.Text = x3
                    Me.MCB_DEPARTAMENTO.SelectedValue = x4
                    Me.MCB_GRUPO.SelectedValue = x5
                    Me.MCB_SUBGRUPO.SelectedValue = x6
                    Me.MCB_MARCA.SelectedValue = x7
                    Me.MCB_ORIGEN.SelectedItem = x8
                    Me.MCB_CATEGORIA.SelectedItem = x9
                    Me.MCB_EMP_COMPRA.SelectedValue = xa
                    Me.MN_CONT_EMP_COMPRA.Text = xb.ToString
                    Me.MCB_EMP_VENTA.SelectedValue = xc
                    Me.MN_CONT_EMP_VENTA.Text = xd.ToString
                    Me.MCB_IMPUESTO.SelectedValue = xe._Tasa
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MN_CONT_EMP_COMPRA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MN_CONT_EMP_COMPRA.Validating
        If Me.MN_CONT_EMP_COMPRA._Valor > 0 Then
            e.Cancel = False
        Else
            Me.MN_CONT_EMP_COMPRA.Text = "1"
            e.Cancel = True
        End If
    End Sub

    Private Sub MN_CONT_EMP_VENTA_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MN_CONT_EMP_VENTA.Validating
        If Me.MN_CONT_EMP_VENTA._Valor > 0 Then
            e.Cancel = False
        Else
            Me.MN_CONT_EMP_VENTA.Text = "1"
            e.Cancel = True
        End If
    End Sub

    Private Sub SolicitudEvento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudEvento.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _FichaModificar = TipoFicha.EventoPresupuesto
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub GrabarPresupuestoEvento()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xficha As New FichaProducto.Prd_Producto.c_ModificarFichaEventoPresupuesto
                With xficha
                    ._AutoPrd = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                    ._ID = xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad
                    ._HabilitarParaPresupuestoEvento = Me.MCHB_EVENTO.Checked
                    ._CantidadConsumoPorPersona = Me.MN_CONSUMO_PERSONA._Valor
                End With

                xfichaprd.f_PrdProducto.F_ModificarFichaPresupuestoEvento(xficha)
                Funciones.MensajeDeOk("Producto Actualizado Exitosamente...")
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        Else
            Me.MCHB_EVENTO.Focus()
        End If
    End Sub

    Private Sub SOLICITUD_WEB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SOLICITUD_WEB.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _FichaModificar = TipoFicha.WEB
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub GrabarWEB()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                xfichaprd.f_PrdProducto.F_ModificarFichaWeb(xfichaprd.f_PrdProducto.RegistroDato, Me.MCHB_WEB.Checked)
                Funciones.MensajeDeOk("Producto Actualizado Exitosamente...")
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        Else
            Me.MCHB_WEB.Focus()
            Me.MCHB_WEB.Select()
        End If
    End Sub

    Private Sub SOLICITUD_SERIAL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SOLICITUD_SERIAL.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _FichaModificar = TipoFicha.serial
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub GrabarSerial()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                xfichaprd.f_PrdProducto.F_ModificarFichaSerial(xfichaprd.f_PrdProducto.RegistroDato, Me.MCHB_SERIAL.Checked)
                Funciones.MensajeDeOk("Producto Actualizado Exitosamente...")
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        Else
            Me.MCHB_SERIAL.Focus()
            Me.MCHB_SERIAL.Select()
        End If
    End Sub

    Private Sub ActivarEstatusProducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActivarEstatusProducto.Click
        Try
            If _MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprd.f_PrdProducto.RegistroDato._AutoProducto <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Modificar.F_Permitir()

                    _FichaModificar = TipoFicha.ESTATUS_PRODUCTO
                    _MiFichaAccion = TipoAccionFicha.ModificarOtro
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GrabarEstatusProducto()
        If MessageBox.Show("Deseas Guardar Estas Cambios Para Esta Ficha ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xficha As New FichaProducto.Prd_Producto.c_ModificarFichaEstatusProducto
                With xficha
                    ._AutoPrd = xfichaprd.f_PrdProducto.RegistroDato._AutoProducto
                    ._ID = xfichaprd.f_PrdProducto.RegistroDato._IdSeguridad
                    ._Regulado = IIf(Me.MCHB_REGULADO.Checked, TipoSiNo.Si, TipoSiNo.No)
                    ._Restringido = IIf(Me.MCHB_RESTRINGIDO.Checked, TipoSiNo.Si, TipoSiNo.No)
                End With

                xfichaprd.f_PrdProducto.F_ModificarFichaEstatusProducto(xficha)
                Funciones.MensajeDeOk("Producto Actualizado Exitosamente...")
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        Else
            Me.MCHB_REGULADO.Focus()
            Me.MCHB_REGULADO.Select()
        End If
    End Sub


End Class