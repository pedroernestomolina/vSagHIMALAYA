Imports DataSistema.MiDataSistema.DataSistema

Public Class ProductoNuevo
    Dim xfichaprd As FichaProducto.Prd_Producto

    Dim xtb_dep As DataTable
    Dim xtb_grp As DataTable
    Dim xtb_sub As DataTable
    Dim xtb_marca As DataTable
    Dim xtb_empaq As DataTable

    Dim xds As DataSet
    Dim xrel_grupo_subg As DataRelation
    Dim campo_p As DataColumn
    Dim campo_h As DataColumn

    Dim xbs_grupo As BindingSource
    Dim xbs_subgrupo As BindingSource

    Private Sub ProductoNuevo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Estas Seguro De Salir y Perder Los Datos ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            e.Cancel = False
        Else
            e.Cancel = True
            Me.MT_CODIGO.Select()
        End If
    End Sub

    Private Sub ProductoNuevo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ProductoNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ProductoNuevo_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub ControlesInicializar()
        With MT_CODIGO
            .Text = ""
        End With
        With MT_NOMBRE_CORTO
            .Text = ""
        End With
        With MT_NOMBRE_LARGO
            .Text = ""
        End With
        With MN_CONTENIDO
            ._Formato = "99999"
            ._ConSigno = False
            .Text = "0"
        End With
        With MN_COSTO_FULL
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
        With MN_COSTO_NETO
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
    End Sub

    Sub CargarCombos()
        g_MiData.F_GetData("select nombre,auto from PRODUCTOS_DEPARTAMENTO order by nombre", xtb_dep)
        With Me.MCB_DEPARTAMENTO
            .DataSource = xtb_dep
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        g_MiData.F_GetData("select nombre,auto from PRODUCTOS_MARCA order by nombre", xtb_marca)
        With Me.MCB_MARCA
            .DataSource = xtb_marca
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        g_MiData.F_GetData("select nombre,auto from PRODUCTOS_MEDIDA order by nombre", xtb_empaq)
        With Me.MCB_EMPAQUE
            .DataSource = xtb_empaq
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_ORIGEN
            .DataSource = xfichaprd._OrigenProducto
            .SelectedIndex = 0
        End With

        With Me.MCB_CATEGORIA
            .DataSource = xfichaprd._CategoriaProducto
            .SelectedIndex = 0
        End With

        xds = New DataSet
        g_MiData.F_GetData("select nombre,auto from productos_grupo order by nombre", xtb_grp)
        xds.Tables.Add(xtb_grp)

        g_MiData.F_GetData("select nombre,auto,auto_grupo from productos_subgrupo order by nombre", xtb_sub)
        xds.Tables.Add(xtb_sub)

        campo_p = xds.Tables("grupos").Columns("auto")
        campo_h = xds.Tables("subgrupos").Columns("auto_grupo")

        xrel_grupo_subg = New DataRelation("Grupo_SubG", campo_p, campo_h)
        xds.Relations.Add(xrel_grupo_subg)

        xbs_grupo = New BindingSource(xds, xtb_grp.TableName)
        xbs_subgrupo = New BindingSource(xbs_grupo, "Grupo_SubG")

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

        With Me.MCB_TASA
            .DataSource = g_MiData.f_FichaGlobal.f_Fiscal.r_ListaTasasFiscales
            .DisplayMember = "_TasaNombre"
            .ValueMember = "_Tasa"
        End With
    End Sub

    Sub Inicializa()
        Try
            xfichaprd = New FichaProducto.Prd_Producto

            xtb_dep = New DataTable("DEPARTAMENTOS")
            xtb_grp = New DataTable("GRUPOS")
            xtb_sub = New DataTable("SUBGRUPOS")
            xtb_marca = New DataTable("MARCAS")
            xtb_empaq = New DataTable("EMPAQUES")

            ControlesInicializar()
            CargarCombos()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        Dim xtasa As FichaGlobal.c_TasasFiscales.Tasas = CType(Me.MCB_TASA.SelectedValue, FichaGlobal.c_TasasFiscales.Tasas)
        MsgBox(xtasa._TasaNombre)
        MsgBox(xtasa._TasaTipo)
        MsgBox(xtasa._TasaValor)
    End Sub

    Private Sub MCB_TASA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_TASA.SelectedIndexChanged

    End Sub
End Class