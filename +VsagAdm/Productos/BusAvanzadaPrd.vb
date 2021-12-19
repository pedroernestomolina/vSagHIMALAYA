Imports DataSistema.MiDataSistema.DataSistema

Public Class BusAvanzadaPrd
    Event LlamarReceptor(ByVal xsql As String)

    Dim estatus As String() = {"Activo / Habilitado", "Inactivo / Desactivado"}
    Dim oferta As String() = {"Activo / Habilitado", "Inactivo / Desactivado"}
    Dim Balanza As String() = {"Pesados", "Unidad", "Todos"}

    Dim xtb_grupo As DataTable
    Dim xtb_subgrupo As DataTable
    Dim xtb_departamento As DataTable
    Dim xtb_proveedor As DataTable
    Dim xtb_marca As DataTable
    Dim xtb_deposito As DataTable

    Dim xbs_grupo As BindingSource
    Dim xbs_subgrupo As BindingSource
    Dim xrel_grupo_subgrupo As DataRelation
    Dim xds As DataSet

    Dim campo_p As DataColumn
    Dim campo_h As DataColumn

    Dim xest_salida As Boolean

    Property EstatusSalida() As Boolean
        Get
            Return xest_salida
        End Get
        Set(ByVal value As Boolean)
            xest_salida = value
        End Set
    End Property

    Sub ApagarControles()
        Me.MCB_CATEGORIA.Enabled = False
        Me.MCB_DEPOSITO.Enabled = False
        Me.MCB_IMPUESTO.Enabled = False
        Me.MCB_CATEGORIA.Enabled = False
        Me.MCB_GRUPO.Enabled = False
        Me.MCB_ESTATUS.Enabled = False
        Me.MCB_DEPARTAMENTO.Enabled = False
        Me.MCB_PROVEEDOR.Enabled = False
        Me.MCB_ORIGEN.Enabled = False
        Me.MCB_MARCA.Enabled = False
        Me.MCB_SUBGRUPO.Enabled = False
        Me.MCB_BALANZA.Enabled = False
        Me.MCB_OFERTA.Enabled = False
        Me.MF_DESDE.Enabled = False
        Me.MF_HASTA.Enabled = False
    End Sub

    Sub CargarData()
        xtb_deposito = New DataTable
        g_MiData.F_GetData("select nombre,auto from depositos order by nombre", xtb_deposito)
        With Me.MCB_DEPOSITO
            .DataSource = xtb_deposito
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xtb_departamento = New DataTable
        g_MiData.F_GetData("select nombre,auto from productos_departamento order by nombre", xtb_departamento)
        With Me.MCB_DEPARTAMENTO
            .DataSource = xtb_departamento
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xds = New DataSet
        xtb_grupo = New DataTable("grupo")
        g_MiData.F_GetData("select nombre,auto from productos_grupo order by nombre", xtb_grupo)
        xds.Tables.Add(xtb_grupo)

        xtb_subgrupo = New DataTable("subgrupo")
        g_MiData.F_GetData("select nombre,auto,auto_grupo from productos_subgrupo order by nombre", xtb_subgrupo)
        xds.Tables.Add(xtb_subgrupo)

        campo_p = xds.Tables("grupo").Columns("auto")
        campo_h = xds.Tables("subgrupo").Columns("auto_grupo")

        xrel_grupo_subgrupo = New DataRelation("Grupo_Subgrupo", campo_p, campo_h)
        xds.Relations.Add(xrel_grupo_subgrupo)

        xbs_grupo = New BindingSource(xds, xtb_grupo.TableName)
        xbs_subgrupo = New BindingSource(xbs_grupo, "Grupo_Subgrupo")

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

        xtb_proveedor = New DataTable
        g_MiData.F_GetData("select nombre,auto from proveedores order by nombre", xtb_proveedor)
        With Me.MCB_PROVEEDOR
            .DataSource = xtb_proveedor
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        xtb_marca = New DataTable
        g_MiData.F_GetData("select nombre,auto from productos_marca order by nombre", xtb_marca)
        With Me.MCB_MARCA
            .DataSource = xtb_marca
            .DisplayMember = "nombre"
            .ValueMember = "auto"
        End With

        With Me.MCB_ESTATUS
            .DataSource = estatus
            .SelectedIndex = 0
        End With

        With Me.MCB_CATEGORIA
            .DataSource = g_MiData.f_FichaProducto.f_PrdProducto._CategoriaProducto
            .SelectedIndex = 0
        End With

        With Me.MCB_ORIGEN
            .DataSource = g_MiData.f_FichaProducto.f_PrdProducto._OrigenProducto
            .SelectedIndex = 0
        End With

        With Me.MCB_BALANZA
            .DataSource = Balanza
            .SelectedIndex = 0
        End With

        With Me.MCB_OFERTA
            .DataSource = oferta
            .SelectedIndex = 0
        End With

        With Me.MCB_IMPUESTO
            .DataSource = g_MiData.f_FichaGlobal.f_Fiscal.r_ListaTasasFiscales
            .DisplayMember = "_TasaNombre"
            .ValueMember = "_Tasa"
        End With
    End Sub

    Sub Inicializa()
        Try
            ApagarControles()
            CargarData()
            Me.MCHB_DEPARTAMENTO.Focus()
            Me.MCHB_DEPARTAMENTO.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BusAvanzadaPrd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If EstatusSalida = True Then
            e.Cancel = False
        Else
            If MessageBox.Show("Estas Seguro De Abandonar Esta Ficha De Busqueda ?", "*** Mensaje De Alerta *** ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BusAvanzadaPrd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub BusAvanzadaPrd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EstatusSalida = False
    End Sub

    Private Sub MCHB_GRUPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_GRUPO.CheckedChanged
        Me.MCB_GRUPO.Enabled = MCHB_GRUPO.Checked
        If MCHB_GRUPO.Checked = False Then
            Me.MCHB_SUBGRUPO.Checked = False
            Me.MCB_SUBGRUPO.Enabled = False
        End If
    End Sub

    Private Sub MCHB_SUBGRUPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_SUBGRUPO.CheckedChanged
        If MCHB_GRUPO.Checked Then
            Me.MCB_SUBGRUPO.Enabled = MCHB_SUBGRUPO.Checked
        Else
            Me.MCHB_SUBGRUPO.Checked = False
        End If
    End Sub

    Private Sub MCHB_ESTATUS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ESTATUS.CheckedChanged
        Me.MCB_ESTATUS.Enabled = MCHB_ESTATUS.Checked
    End Sub

    Private Sub MCHB_FECHA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_FECHA.CheckedChanged
        Me.MF_DESDE.Enabled = MCHB_FECHA.Checked
        Me.MF_HASTA.Enabled = MCHB_FECHA.Checked
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        Dim xbus_prv As String = ""
        Dim xfil As String = ""

        Try
            If Me.MCHB_DEPARTAMENTO.Checked Then
                xfil += " and p.auto_departamento='" + Me.MCB_DEPARTAMENTO.SelectedValue + "'"
            End If

            If Me.MCHB_GRUPO.Checked Then
                xfil += " and p.auto_grupo='" + Me.MCB_GRUPO.SelectedValue + "'"
            End If

            If Me.MCHB_SUBGRUPO.Checked Then
                xfil += " and p.auto_subgrupo='" + Me.MCB_SUBGRUPO.SelectedValue + "'"
            End If

            If Me.MCHB_CATEGORIA.Checked Then
                xfil += " and p.categoria='" + Me.MCB_CATEGORIA.SelectedItem.ToString.Trim + "'"
            End If

            If Me.MCHB_ORIGEN.Checked Then
                xfil += " and p.origen='" + Me.MCB_ORIGEN.SelectedItem.ToString.Trim + "'"
            End If

            If Me.MCHB_ESTATUS.Checked Then
                xfil += IIf(Me.MCB_ESTATUS.SelectedIndex = 0, " and p.estatus='Activo'", " and p.estatus='Inactivo'")
            End If

            If Me.MCHB_MARCA.Checked Then
                xfil += " and p.auto_marca='" + Me.MCB_MARCA.SelectedValue + "'"
            End If

            If Me.MCHB_OFERTA.Checked Then
                xfil += IIf(Me.MCB_ESTATUS.SelectedIndex = 0, " and p.estatus_oferta='1'", " and p.estatus_oferta='0'")
            End If

            If Me.MCHB_BALANZA.Checked Then
                Select Case Me.MCB_BALANZA.SelectedIndex
                    Case 0
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='P'"
                    Case 1
                        xfil += " and p.estatus_balanza='1' and pesado_unidad='U'"
                    Case 2
                        xfil += " and p.estatus_balanza='1'"
                End Select
            End If

            If Me.MCHB_PROVEEDOR.Checked Then
                xfil += " and p.auto in (select prv.auto_producto from productos_proveedor prv where prv.auto_proveedor='" + Me.MCB_PROVEEDOR.SelectedValue + "')"
            End If

            If Me.MCHB_DEPOSITO.Checked Then
                xfil += " and p.auto in (select dep.auto_producto from productos_deposito dep where dep.auto_deposito='" + Me.MCB_DEPOSITO.SelectedValue + "')"
            End If

            If Me.MCHB_IMPUESTO.Checked Then
                Dim xtasa As FichaGlobal.c_TasasFiscales.Tasas = CType(Me.MCB_IMPUESTO.SelectedValue, FichaGlobal.c_TasasFiscales.Tasas)
                xfil += " and p.impuesto='" + xtasa._TasaTipo + "'"
            End If

            If Me.MCHB_FECHA.Checked Then
                If MF_DESDE.Checked Then
                    xfil += " and p.fecha_alta>='" + Me.MF_DESDE.r_Valor.ToShortDateString + "'"
                End If
                If MF_HASTA.Checked Then
                    xfil += " and p.fecha_alta<='" + Me.MF_HASTA.r_Valor.ToShortDateString + "'"
                End If
            End If

            Dim TipoB As String = xfil
            Dim xsql As String = _
            "SELECT p.nombre xnom, p.codigo xcod, p.tasa xtas, p.plu xplu, p.psv, p.auto, p.estatus,p.referencia xref, " _
                 + "p.contenido_empaque xempcompra, pdep.nombre ndep, pgrp.nombre ngrp, pmar.nombre nmar, pmed.nombre nmed, pmed.decimales xdec " _
                 + "from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto join productos_grupo pgrp on p.auto_grupo=pgrp.auto " _
                 + "join productos_marca pmar on p.auto_marca=pmar.auto join productos_medida pmed on p.auto_medida_compra=pmed.auto " _
                 + "where p.auto<>'' " + TipoB + " and p.estatus_departamento='0' order by p.nombre;" _
                 + "SELECT d.nombre,pd.real,pd.reservada,pd.disponible,pd.auto_producto, pd.auto_deposito " _
                 + "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto " _
                 + "where pd.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                 + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                 + "where p.auto<>'' " + TipoB + " and  p.estatus_departamento='0');" _
                 + "SELECT pm.nombre xnom, pe.contenido xcont, pe.precio_1 xpn1, 0.0 xpf1, pe.precio_2 xpn2, 0.0 xpf2, pe.*, pm.* " _
                 + "from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto " _
                 + "where pe.auto_producto in (select p.auto from productos p join productos_departamento pdep on p.auto_departamento=pdep.auto " _
                 + "join productos_grupo pgrp on p.auto_grupo=pgrp.auto join productos_marca pmar on p.auto_marca=pmar.auto " _
                 + "where p.auto<>'' " + TipoB + "  and p.estatus_departamento='0') ORDER BY PE.REFERENCIA"

            EstatusSalida = True
            RaiseEvent LlamarReceptor(xsql)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error Al Realizar Busqueda Avanzada: " + ex.Message, "ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MF_DESDE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_DESDE.ValueChanged
        If MF_HASTA.Checked Then
            If MF_DESDE.r_Valor <= MF_HASTA.r_Valor Then
            Else
                MF_HASTA.Value = MF_DESDE.Value
            End If
        End If
    End Sub

    Private Sub MF_HASTA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_HASTA.ValueChanged
        If MF_DESDE.Checked Then
            If MF_HASTA.r_Valor >= MF_DESDE.r_Valor Then
            Else
                Me.MF_DESDE.Value = Me.MF_HASTA.Value
            End If
        End If
    End Sub

    Private Sub BusAvanzadaPrd_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub MCHB_CATEGORIA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_CATEGORIA.CheckedChanged
        Me.MCB_CATEGORIA.Enabled = MCHB_CATEGORIA.Checked
    End Sub

    Private Sub MCHB_ORIGEN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_ORIGEN.CheckedChanged
        Me.MCB_ORIGEN.Enabled = MCHB_ORIGEN.Checked
    End Sub

    Private Sub MCHB_IMPUESTO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_IMPUESTO.CheckedChanged
        Me.MCB_IMPUESTO.Enabled = Me.MCHB_IMPUESTO.Checked
    End Sub

    Private Sub MCHB_DEPARTAMENTO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_DEPARTAMENTO.CheckedChanged
        Me.MCB_DEPARTAMENTO.Enabled = Me.MCHB_DEPARTAMENTO.Checked
    End Sub

    Private Sub MCHB_PROVEEDOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_PROVEEDOR.CheckedChanged
        Me.MCB_PROVEEDOR.Enabled = Me.MCHB_PROVEEDOR.Checked
    End Sub

    Private Sub MCHB_MARCA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_MARCA.CheckedChanged
        Me.MCB_MARCA.Enabled = MCHB_MARCA.Checked
    End Sub

    Private Sub MCHB_DEPOSITO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_DEPOSITO.CheckedChanged
        Me.MCB_DEPOSITO.Enabled = MCHB_DEPOSITO.Checked
    End Sub

    Private Sub MCHB_OFERTA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_OFERTA.CheckedChanged
        Me.MCB_OFERTA.Enabled = MCHB_OFERTA.Checked
    End Sub

    Private Sub MCHB_BALANZA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_BALANZA.CheckedChanged
        Me.MCB_BALANZA.Enabled = MCHB_BALANZA.Checked
    End Sub
End Class