Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class FichaProveedor
    Event _ActualizarFicha()

    Dim pb_tm As Size
    Dim xaccion As TipoAccionFicha
    Dim xfichaprv As DataSistema.MiDataSistema.DataSistema.FichaProveedores

    Dim xtb_ctas As DataTable
    Dim xbs_ctas As BindingSource

    'PARA BUSQUEDA DE PROVEEDORES RAPIDAS
    Const Busqueda_1 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from PROVEEDORES where nombre like @data order by nombre"
    Const Busqueda_2 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from PROVEEDORES where ci_rif like @data order by nombre"
    Const Busqueda_3 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from PROVEEDORES where codigo like @data order by nombre"

    Dim xbusquedainmediata As String

    Property _CargaInmediata() As String
        Get
            Return xbusquedainmediata.Trim
        End Get
        Set(ByVal value As String)
            xbusquedainmediata = value
        End Set
    End Property

    Property MiFichaAccion() As TipoAccionFicha
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xaccion = value

            If value = TipoAccionFicha.Inactivo Then
                xfichaprv.f_Proveedor.M_LimpiarRegistro()
                InicializarControles()
                ApagarEncenderBotones(Encendido.Apagar)
                ActivarDesactivarBotones()
                Me.MT_BUSCAR.Select()
                Me.MT_BUSCAR.Focus()
                ModuloCtasBancarias(False)
            End If

            If value = TipoAccionFicha.Adicionar Then
                ActivarDesactivarControles(Encendido.Encender)
                LimpiarControles()
                CargarCombos()
                ActivarDesactivarBotones()
                ModuloCtasBancarias(False)

                xfichaprv.f_Proveedor.M_LimpiarRegistro()
                CargarCtas_Proveedor()
            End If

            If value = TipoAccionFicha.Modificar Then
                ActivarDesactivarControles(Encendido.Encender)
                CargarCombos()
                ActivarDesactivarBotones()
                ModuloCtasBancarias(True)
            End If

            If value = TipoAccionFicha.Consultar Then
                ActivarDesactivarControles(Encendido.Apagar)
                ActivarDesactivarBotones()
                ModuloCtasBancarias(True)
            End If
        End Set
    End Property

    Sub ModuloCtasBancarias(ByVal xop As Boolean)
        Me.BT_CTAS.Enabled = xop
        Me.MisGrid1.Enabled = xop
    End Sub

    Private Sub FichaProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MiFichaAccion = TipoAccionFicha.Inactivo Then
            e.Cancel = False
        Else
            If MiFichaAccion = TipoAccionFicha.Adicionar Or MiFichaAccion = TipoAccionFicha.Consultar Then
                If MessageBox.Show("Deseas Cerrar Esta Ficha De Proveedor y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    MiFichaAccion = TipoAccionFicha.Inactivo
                    CargarCtas_Proveedor()
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            ElseIf MiFichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Deseas Cerrar Esta Ficha De Proveedor y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ProveedorNuevoRegistrado(xfichaprv.f_Proveedor.RegistroDato._Automatico)
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub FichaProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            AgregarProveedor()
        End If
        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            ModificarProveedor()
        End If
        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            EliminarProveedor()
        End If
        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
                Me.MT_BUSCAR.Select()
            End If
        End If
    End Sub

    Private Sub FichaProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        Me.TabControl1.SelectTab(1)
        Me.TabControl1.SelectTab(0)
    End Sub

    Private Sub FichaProveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pb_tm = PB_1.Size
        Me.TabControl1.TabPages.Remove(Me.TabPage3)
    End Sub

    Sub InicializarControles()
        Dim op As Boolean = False

        Me.E_FECHA_REG.Visible = op
        Me.E_FECHA_REGISTRO.Visible = op

        With Me.MT_RIF
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_RIF.c_Largo
            .Enabled = op
        End With
        With Me.MT_CODIGO
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_CodigoProveedor.c_Largo
            .Enabled = op
        End With
        With Me.MT_RAZONSOCIAL
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_NombreRazonSocial.c_Largo
            .Enabled = op
        End With
        With Me.MT_DIRFISCAL
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_DirFiscal.c_Largo
            .Enabled = op
        End With
        With Me.MT_CONTACTO
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_ContactarA.c_Largo
            .Enabled = op
        End With
        With Me.MT_WEBSITE
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_WebSite.c_Largo
            .Enabled = op
        End With
        With Me.MT_EMAIL
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Email.c_Largo
            .Enabled = op
        End With
        With Me.MT_CEL1
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Celular_1.c_Largo
            .Enabled = op
        End With
        With Me.MT_CEL2
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Celular_2.c_Largo
            .Enabled = op
        End With
        With Me.MT_FAX1
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Fax_1.c_Largo
            .Enabled = op
        End With
        With Me.MT_FAX2
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Fax_2.c_Largo
            .Enabled = op
        End With
        With Me.MT_TEL1
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Telefono_1.c_Largo
            .Enabled = op
        End With
        With Me.MT_TEL2
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Telefono_2.c_Largo
            .Enabled = op
        End With
        With Me.MT_TEL3
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Telefono_3.c_Largo
            .Enabled = op
        End With
        With Me.MT_TEL4
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Telefono_4.c_Largo
            .Enabled = op
        End With

        With Me.MCB_GRUPO
            .DataSource = Nothing
            .Enabled = op
        End With
        With Me.MCB_ORIGEN
            .DataSource = Nothing
            .Enabled = op
        End With

        With Me.MN_LIMITE_CREDITO
            ._ConSigno = False
            ._Formato = "9999999.99"
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_LIMITE_DOC
            ._ConSigno = False
            ._Formato = "999"
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_DIAS_CREDITO
            ._Formato = "999"
            ._ConSigno = False
            .Text = ""
            .Enabled = op
        End With

        With Me.MCHB_CREDITO
            .Checked = False
            .Enabled = op
        End With

        With Me.MCB_DEN_FISCAL
            .DataSource = Nothing
            .Enabled = op
        End With
        With Me.MN_RET_IVA
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_RET_ISLR
            ._Formato = "99.99"
            ._ConSigno = False
            .Text = ""
            .Enabled = op
        End With

        With Me.BT_ESTATUS
            .Enabled = op
        End With

        Me.PB_ESTATUS.Image = My.Resources.NoDefinido

        '
        ' CONTROLES SEGUNDA PAGINA
        '
        With Me.MT_CTA_CXC
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_ContableCXP.c_Largo
            .Enabled = op
        End With
        With Me.MT_CTA_INGRESO
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_ContableIngresos.c_Largo
            .Enabled = op
        End With
        With Me.MT_CTA_ANTICIPO
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_ContableAnticipos.c_Largo
            .Enabled = op
        End With

        With Me.MT_FECHA_ULTVENTA
            .Text = ""
            .Enabled = op
        End With
        With Me.MT_FECHA_ULTPAGO
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_TOTANTICIPO
            ._Formato = "9999999.99"
            ._Formato = False
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_TOTCREDITO
            ._Formato = "9999999.99"
            ._Formato = False
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_TOTDEBITO
            ._Formato = "9999999.99"
            ._Formato = False
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_TOTSALDO
            ._Formato = "9999999.99"
            ._Formato = False
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_CR_DISPONIBLE
            ._Formato = "9999999.99"
            ._Formato = False
            .Text = ""
            .Enabled = op
        End With

        With Me.MT_ADVERTENCIA
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Advertencia.c_Largo
            .Enabled = op
        End With
        With Me.MT_COMENTARIOS
            .Text = ""
            .MaxLength = xfichaprv.f_Proveedor.RegistroDato.c_Comentarios.c_Largo
            .Enabled = op
        End With

        With Me.MCB_BUSQUEDA
            .DataSource = xfichaprv.f_Proveedor.p_TipoBusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarProveedor
        End With

        Me.E_DOC_PENDIENTES.Text = "0"

        Me.MT_BUSCAR.Text = ""
    End Sub

    Sub LimpiarControles()
        Me.MT_RIF.Text = ""
        Me.MT_CODIGO.Text = ""
        Me.MT_RAZONSOCIAL.Text = ""
        Me.MT_DIRFISCAL.Text = ""
        Me.MT_CONTACTO.Text = ""
        Me.MT_WEBSITE.Text = ""
        Me.MT_EMAIL.Text = ""
        Me.MT_CEL1.Text = ""
        Me.MT_CEL2.Text = ""
        Me.MT_FAX1.Text = ""
        Me.MT_FAX2.Text = ""
        Me.MT_TEL1.Text = ""
        Me.MT_TEL2.Text = ""
        Me.MT_TEL3.Text = ""
        Me.MT_TEL4.Text = ""

        Me.MCB_GRUPO.DataSource = Nothing
        Me.MCB_ORIGEN.DataSource = Nothing

        Me.MN_LIMITE_CREDITO.Text = ""
        Me.MN_LIMITE_DOC.Text = ""
        Me.MN_DIAS_CREDITO.Text = ""

        Me.MCHB_CREDITO.Checked = False
        If MiFichaAccion = TipoAccionFicha.Adicionar Then
            Me.PB_ESTATUS.Image = My.Resources.ClienteActivo_1
        End If

        Me.MCB_DEN_FISCAL.DataSource = Nothing
        Me.MN_RET_IVA.Text = ""
        Me.MN_RET_ISLR.Text = ""
    End Sub

    Sub ActivarDesactivarControles(ByVal op As Encendido)
        Me.MT_RIF.Enabled = op
        Me.MT_CODIGO.Enabled = op
        Me.MT_RAZONSOCIAL.Enabled = op
        Me.MT_DIRFISCAL.Enabled = op
        Me.MT_CONTACTO.Enabled = op
        Me.MT_WEBSITE.Enabled = op
        Me.MT_EMAIL.Enabled = op
        Me.MT_CEL1.Enabled = op
        Me.MT_CEL2.Enabled = op
        Me.MT_FAX1.Enabled = op
        Me.MT_FAX2.Enabled = op
        Me.MT_TEL1.Enabled = op
        Me.MT_TEL2.Enabled = op
        Me.MT_TEL3.Enabled = op
        Me.MT_TEL4.Enabled = op

        Me.MCB_GRUPO.Enabled = op
        Me.MCB_ORIGEN.Enabled = op

        Me.MN_LIMITE_CREDITO.Enabled = op
        Me.MN_LIMITE_DOC.Enabled = op
        Me.MN_DIAS_CREDITO.Enabled = op

        Me.MCHB_CREDITO.Enabled = op
        If op = Encendido.Encender Then
            Me.MN_LIMITE_CREDITO.Enabled = Me.MCHB_CREDITO.Checked
            Me.MN_LIMITE_DOC.Enabled = Me.MCHB_CREDITO.Checked
            Me.MN_DIAS_CREDITO.Enabled = Me.MCHB_CREDITO.Checked
        Else
            Me.MN_LIMITE_CREDITO.Enabled = op
            Me.MN_LIMITE_DOC.Enabled = op
            Me.MN_DIAS_CREDITO.Enabled = op
        End If

        Me.MCB_DEN_FISCAL.Enabled = op
        Me.MN_RET_IVA.Enabled = op
        Me.MN_RET_ISLR.Enabled = op

        If MiFichaAccion = TipoAccionFicha.Adicionar Or MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.BT_ESTATUS.Enabled = False
        ElseIf MiFichaAccion = TipoAccionFicha.Modificar Then
            Me.BT_ESTATUS.Enabled = op
        End If

        '
        ' CONTROLES SEGUNDA PAGINA
        '
        Me.MT_CTA_ANTICIPO.Enabled = op
        Me.MT_CTA_CXC.Enabled = op
        Me.MT_CTA_INGRESO.Enabled = op

        Me.MT_COMENTARIOS.Enabled = op
        Me.MT_ADVERTENCIA.Enabled = op
    End Sub

    Sub ApagarEncenderBotones(ByVal op As Encendido)
        Me.BT_GRABAR.Enabled = op
        Me.PB_2.Enabled = op
        Me.PB_3.Enabled = op
    End Sub

    Sub Inicializa()
        Try
            xtb_grupo = New DataTable

            xfichaprv = New DataSistema.MiDataSistema.DataSistema.FichaProveedores
            AddHandler xfichaprv.ProveedorNuevo, AddressOf ProveedorNuevoRegistrado

            MiFichaAccion = TipoAccionFicha.Inactivo

            xtb_ctas = New DataTable("Ctas")
            xbs_ctas = New BindingSource(xtb_ctas, "")
            CargarCtas_Proveedor()

            With MisGrid1
                .Columns.Add("col0", "Agencia")
                .Columns.Add("col1", "Nro. Cuenta")

                .Columns(0).Width = 150
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs_ctas
                .Columns(0).DataPropertyName = "age"
                .Columns(1).DataPropertyName = "num"

                .Ocultar(3)
            End With

            If _CargaInmediata <> "" Then
                ProveedorNuevoRegistrado(_CargaInmediata)
            End If

            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub FichaProveedor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub BT_SALIDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SALIDA.Click
        Me.Close()
    End Sub

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

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.MiFichaAccion = TipoAccionFicha.Inactivo Then
            Me.MT_BUSCAR.Focus()
        End If
    End Sub

    Private Sub LINK_RIF_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_RIF.LinkClicked
        Dim xficha As New FichaWeb
        With xficha
            ._PaginaInicio = PaginaInicioSeniat
            .ShowDialog()
        End With

        If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MT_BUSCAR.Select()
        End If
    End Sub

    Private Sub LINK_GRUPO_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_GRUPO.LinkClicked
        ControlGrupos()
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarProveedor()
    End Sub

    Sub AgregarProveedor()
        Try
            If MiFichaAccion = TipoAccionFicha.Consultar Or MiFichaAccion = TipoAccionFicha.Inactivo Then
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor_Ingresar.F_Permitir()
                Try
                    MiFichaAccion = TipoAccionFicha.Adicionar
                    xfichaprv.f_Proveedor.M_LimpiarRegistro()
                Catch ex As Exception
                    MessageBox.Show("Error... " + vbCrLf + ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim xtb_grupo As DataTable
    Dim xtb_estado As DataTable
    Dim xtb_zona As DataTable
    Dim xtb_vendedor As DataTable
    Dim xtb_cobrador As DataTable

    Dim xbs_estado As BindingSource
    Dim xbs_zona As BindingSource
    Dim xrel_estado_zona As DataRelation
    Dim xds As DataSet

    Dim campo_p As DataColumn
    Dim campo_h As DataColumn

    Sub CargarCombos()
        g_MiData.F_GetData("select nombre,auto from grupo_proveedor order by nombre", xtb_grupo)

        With Me.MCB_GRUPO
            .DataSource = xtb_grupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"

            If MiFichaAccion = TipoAccionFicha.Modificar Then
                .SelectedValue = xfichaprv.f_Proveedor.RegistroDato.c_AutoGrupo.c_Texto
            End If
        End With

        With Me.MCB_ORIGEN
            .DataSource = xfichaprv.f_Proveedor.p_TipoOrigen
            If MiFichaAccion = TipoAccionFicha.Adicionar Then
                .SelectedIndex = 0
            End If
        End With

        With Me.MCB_DEN_FISCAL
            .DataSource = xfichaprv.f_Proveedor.p_DenominacionFiscal
            If MiFichaAccion = TipoAccionFicha.Adicionar Then
                .SelectedIndex = 2
            End If
        End With
    End Sub

    Sub ActivarDesactivarBotones()
        If Me.MiFichaAccion = TipoAccionFicha.Adicionar Or MiFichaAccion = TipoAccionFicha.Modificar Then
            Me.PB_1.Enabled = False
            Me.PB_2.Enabled = False
            Me.PB_3.Enabled = False
            Me.BT_GRABAR.Enabled = True
            Me.BT_BUSCAR.Enabled = False
            Me.BT_BUS_AVANZ.Enabled = False
            Me.MCB_BUSQUEDA.Enabled = False
            Me.MT_BUSCAR.Enabled = False
            Me.BT_REPORTES.Enabled = False
            Me.MT_CODIGO.Select()
            Me.MT_CODIGO.Focus()
        End If
        If Me.MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.PB_1.Enabled = True
            Me.PB_2.Enabled = True
            Me.PB_3.Enabled = True
            Me.BT_GRABAR.Enabled = False
            Me.BT_BUSCAR.Enabled = True
            Me.BT_BUS_AVANZ.Enabled = True
            Me.MCB_BUSQUEDA.Enabled = True
            Me.BT_REPORTES.Enabled = True

            With Me.MT_BUSCAR
                .Enabled = True
                .Text = ""
                .Focus()
                .Select()
            End With
        End If
        If Me.MiFichaAccion = TipoAccionFicha.Inactivo Then
            Me.PB_1.Enabled = True
            Me.BT_GRABAR.Enabled = False
            Me.BT_BUSCAR.Enabled = True
            Me.BT_BUS_AVANZ.Enabled = True
            Me.MT_BUSCAR.Enabled = True
            Me.MCB_BUSQUEDA.Enabled = True
            Me.BT_REPORTES.Enabled = False
        End If
    End Sub

    Sub ControlGrupos()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoProveedor.F_Permitir()

            Dim xficha As New Plantilla_1(New GrupoProveedor)
            AddHandler xficha.ActualizarFicha, AddressOf CargarGrupos
            With xficha
                .ShowDialog()
            End With

            If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
                Me.MT_BUSCAR.Select()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarGrupos()
        g_MiData.F_GetData("select nombre,auto from grupo_proveedor order by nombre", xtb_grupo)
        If MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MCB_GRUPO.Enabled = True
            Me.MCB_GRUPO.SelectedValue = xfichaprv.f_Proveedor.RegistroDato._AutoGrupo
            Me.MCB_GRUPO.Enabled = False
        End If
    End Sub

    Private Sub BT_BUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR.Click
        BusquedaProveedores()
    End Sub

    Sub BusquedaProveedores()
        If MT_BUSCAR.r_Valor <> "" Then
            Dim xsql As String = ""
            Dim xp1 As SqlParameter
            Dim xbuscar As String = ""

            Select Case CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaProveedores.TipoBusqueda)
                Case FichaProveedores.TipoBusqueda.PorNombreRazonSocial
                    xsql = Busqueda_1
                Case FichaProveedores.TipoBusqueda.PorRif_CI
                    xsql = Busqueda_2
                Case FichaProveedores.TipoBusqueda.PorCodigo
                    xsql = Busqueda_3
            End Select

            If MT_BUSCAR.Text.Substring(0, 1) = "*" Then
                xbuscar = "%" + MT_BUSCAR.r_Valor.Substring(1)
            Else
                xbuscar = MT_BUSCAR.r_Valor
            End If

            xp1 = New SqlParameter("@data", xbuscar + "%")
            Dim xficha As New Plantilla_2(New BusquedaProveedor, xsql, xp1)
            With xficha
                AddHandler .EnviarAuto, AddressOf ProveedorNuevoRegistrado
                .ShowDialog()
            End With
            Me.MT_BUSCAR.Text = ""
        End If
        Me.MT_BUSCAR.Select()
    End Sub

    Sub IrInicio()
        With Me.MT_BUSCAR
            .Text = ""
            .Enabled = True
            .Select()
            .Focus()
        End With
    End Sub

    Private Sub MCB_BUSQUEDA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSQUEDA.SelectedIndexChanged
        IrInicio()
    End Sub

    Private Sub BT_BUS_AVANZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUS_AVANZ.Click
        BusquedaAvanzada()
    End Sub

    Sub BusquedaAvanzada()
        Dim xficha As New BusAvanzadaProveedor
        With xficha
            AddHandler .LlamarReceptor, AddressOf ReceptorBusAvanzada
            .ShowDialog()
        End With

        If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
            IrInicio()
        End If
    End Sub

    Sub ReceptorBusAvanzada(ByVal xsql As String)
        Dim xficha As New Plantilla_2(New BusquedaProveedor, xsql)
        With xficha
            AddHandler .EnviarAuto, AddressOf ProveedorNuevoRegistrado
            .ShowDialog()
        End With
    End Sub

    Sub ProveedorNuevoRegistrado(ByVal xauto As String)
        Try
            xfichaprv.F_BuscarProveedor(xauto)
            MostrarData()
            CargarCtas_Proveedor()

            If MiFichaAccion = TipoAccionFicha.Adicionar Then
                MessageBox.Show("Proveedor Registrado Con Exito...", "*** Mensaje De Exito ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            MiFichaAccion = TipoAccionFicha.Consultar
        Catch ex As Exception
            MiFichaAccion = TipoAccionFicha.Inactivo
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LINK_WEBSITE_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_WEBSITE.LinkClicked
        If Me.MT_WEBSITE.r_Valor <> "" Then
            Dim xficha As New FichaWeb
            With xficha
                ._PaginaInicio = Me.MT_WEBSITE.r_Valor
                .ShowDialog()
            End With
        End If

        If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MT_BUSCAR.Select()
        End If
    End Sub

    Sub MostrarData()
        CargarCombos()

        Me.MT_CODIGO.Text = xfichaprv.f_Proveedor.RegistroDato._CodigoProveedor
        Me.MT_RIF.Text = xfichaprv.f_Proveedor.RegistroDato._CiRif
        Me.MT_RAZONSOCIAL.Text = xfichaprv.f_Proveedor.RegistroDato._NombreRazonSocial
        Me.MT_DIRFISCAL.Text = xfichaprv.f_Proveedor.RegistroDato._DirFiscal
        Me.MT_CONTACTO.Text = xfichaprv.f_Proveedor.RegistroDato._ContactarA
        Me.MT_TEL1.Text = xfichaprv.f_Proveedor.RegistroDato._Telefono_1
        Me.MT_TEL2.Text = xfichaprv.f_Proveedor.RegistroDato._Telefono_2
        Me.MT_TEL3.Text = xfichaprv.f_Proveedor.RegistroDato._Telefono_3
        Me.MT_TEL4.Text = xfichaprv.f_Proveedor.RegistroDato._Telefono_4
        Me.MT_FAX1.Text = xfichaprv.f_Proveedor.RegistroDato._Fax_1
        Me.MT_FAX2.Text = xfichaprv.f_Proveedor.RegistroDato._Fax_2
        Me.MT_CEL1.Text = xfichaprv.f_Proveedor.RegistroDato._Celular_1
        Me.MT_CEL2.Text = xfichaprv.f_Proveedor.RegistroDato._Celular_2
        Me.MT_EMAIL.Text = xfichaprv.f_Proveedor.RegistroDato._Email
        Me.MT_WEBSITE.Text = xfichaprv.f_Proveedor.RegistroDato._WebSite

        Me.MCB_GRUPO.SelectedValue = xfichaprv.f_Proveedor.RegistroDato._AutoGrupo
        Me.MCB_ORIGEN.SelectedItem = xfichaprv.f_Proveedor.RegistroDato._TipoOrigen

        Me.MCHB_CREDITO.Checked = IIf(xfichaprv.f_Proveedor.RegistroDato._EstatusCredito = TipoEstatus.Activo, True, False)
        Me.MN_DIAS_CREDITO.Text = String.Format("{0:#0}", xfichaprv.f_Proveedor.RegistroDato._DiasCredito)
        Me.MN_LIMITE_CREDITO.Text = String.Format("{0:#0.00}", xfichaprv.f_Proveedor.RegistroDato._LimiteCredito)
        Me.MN_LIMITE_DOC.Text = String.Format("{0:#0}", xfichaprv.f_Proveedor.RegistroDato._DocPendientesPermitidos)

        Me.MCB_DEN_FISCAL.SelectedItem = xfichaprv.f_Proveedor.RegistroDato._DenominacionFiscal
        Me.MN_RET_ISLR.Text = String.Format("{0:#0.00}", xfichaprv.f_Proveedor.RegistroDato._TasaRetencionISLR)
        Me.MN_RET_IVA.Text = String.Format("{0:#0.00}", xfichaprv.f_Proveedor.RegistroDato._TasaRetencionIva)

        Me.E_FECHA_REG.Visible = True
        Me.E_FECHA_REGISTRO.Visible = True
        Me.E_FECHA_REGISTRO.Text = xfichaprv.f_Proveedor.RegistroDato._FechaAlta

        If xfichaprv.f_Proveedor.RegistroDato._EstatusDelProveedor = TipoEstatus.Activo Then
            Me.PB_ESTATUS.Image = My.Resources.ClienteActivo_1
        Else
            Me.PB_ESTATUS.Image = My.Resources.Inactivo_1
        End If

        Me.MT_CTA_ANTICIPO.Text = xfichaprv.f_Proveedor.RegistroDato._ContableAnticipos
        Me.MT_CTA_CXC.Text = xfichaprv.f_Proveedor.RegistroDato._ContableCXP
        Me.MT_CTA_INGRESO.Text = xfichaprv.f_Proveedor.RegistroDato._ContableIngresos

        Me.MT_FECHA_ULTPAGO.Text = xfichaprv.f_Proveedor.RegistroDato._FechaUltPago
        Me.MT_FECHA_ULTVENTA.Text = xfichaprv.f_Proveedor.RegistroDato._FechaUltCompra

        Me.MN_TOTANTICIPO.Text = String.Format("{0:#0.00}", xfichaprv.f_Proveedor.RegistroDato._TotalAnticipos)
        Me.MN_TOTCREDITO.Text = String.Format("{0:#0.00}", xfichaprv.f_Proveedor.RegistroDato._TotalCreditos)
        Me.MN_TOTDEBITO.Text = String.Format("{0:#0.00}", xfichaprv.f_Proveedor.RegistroDato._TotalDebitos)
        Me.MN_TOTSALDO.Text = String.Format("{0:#0.00}", xfichaprv.f_Proveedor.RegistroDato._TotalSaldo)
        Me.MN_CR_DISPONIBLE.Text = String.Format("{0:#0.00}", xfichaprv.f_Proveedor.RegistroDato._CreditoDisponible)

        Me.MT_ADVERTENCIA.Text = xfichaprv.f_Proveedor.RegistroDato._Advertencia
        Me.MT_COMENTARIOS.Text = xfichaprv.f_Proveedor.RegistroDato._Comentarios

        Me.E_DOC_PENDIENTES.Text = xfichaprv.f_Proveedor.RegistroDato._CantidadDocPendientes
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        GrabarProveedor()
    End Sub

    Sub IniciarEnCodigo()
        Me.MT_CODIGO.Select()
        Me.MT_CODIGO.Focus()
    End Sub

    Function VerificarProveedor() As Boolean
        If Me.MT_RAZONSOCIAL.r_Valor <> "" And Me.MT_DIRFISCAL.r_Valor <> "" Then
            If Me.MCB_ORIGEN.SelectedIndex = 0 Then
                If Me.MT_RIF.r_Valor <> "" Then
                    Return True
                Else
                    MessageBox.Show("Error... Faltan Datos Por Completar, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                If Me.MT_RIF.r_Valor = "" Then
                    Return True
                Else
                    MessageBox.Show("Error... Para Proveedores Extranjero El Campo RIF/CI Debe Estar En Blanco, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Error... Faltan Datos Por Completar, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Function ValidarDatos() As Boolean
        If Me.MT_RIF.r_Valor = "" Then
            If Me.MCB_ORIGEN.SelectedIndex = 1 Then
            Else
                MessageBox.Show("Falta Por Registrar Ci/Rif Del Proveedor... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MT_RIF.Select()
                Me.MT_RIF.Focus()
                Return False
            End If
        End If

        If Me.MT_RAZONSOCIAL.r_Valor = "" Then
            MessageBox.Show("Falta Por Registrar Nombre / Razon Social Del Proveedor... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_RAZONSOCIAL.Select()
            Me.MT_RAZONSOCIAL.Focus()
            Return False
        End If

        If Me.MT_DIRFISCAL.r_Valor = "" Then
            MessageBox.Show("Falta Por Registrar Direccion Fiscal Del Proveedor... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_DIRFISCAL.Select()
            Me.MT_DIRFISCAL.Focus()
            Return False
        End If

        If Me.MCB_GRUPO.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun Grupo Seleccionado Para Este Proveedor... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_GRUPO.Select()
            Me.MCB_GRUPO.Focus()
            Return False
        End If

        Return True
    End Function

    Sub GrabarProveedor()
        If ValidarDatos() Then
            Try
                Dim xms As String
                If MiFichaAccion = TipoAccionFicha.Adicionar Then
                    xms = "Deseas Guardar Este Registro Nuevo En El Sistema ?"
                Else
                    xms = "Deseas Guardar Los Cambios Efectuados ?"
                End If
                If MessageBox.Show(xms, "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    If MiFichaAccion = TipoAccionFicha.Adicionar Then
                        Dim xproveedor As New FichaProveedores.c_Proveedor.c_AgregarProveedor

                        With xproveedor
                            ._ActivarCredito = IIf(Me.MCHB_CREDITO.Checked, TipoSiNo.Si, TipoSiNo.No)
                            ._Adevertencia = Me.MT_ADVERTENCIA.r_Valor
                            ._AutoGrupo = Me.MCB_GRUPO.SelectedValue
                            ._CantDocCreditoPermitido = Me.MN_LIMITE_DOC._Valor
                            ._Celular_1 = Me.MT_CEL1.r_Valor
                            ._Celular_2 = Me.MT_CEL2.r_Valor
                            ._Codigo = Me.MT_CODIGO.r_Valor
                            ._Comentarios = Me.MT_COMENTARIOS.r_Valor
                            ._CtaContable_Anticipos = Me.MT_CTA_ANTICIPO.r_Valor
                            ._CtaContable_CXP = Me.MT_CTA_CXC.r_Valor
                            ._CtaContable_Ingresos = Me.MT_CTA_INGRESO.r_Valor
                            ._DenominacionFiscal = Me.MCB_DEN_FISCAL.SelectedItem.ToString
                            ._DirFiscal = Me.MT_DIRFISCAL.r_Valor
                            ._DiasCredito = Me.MN_DIAS_CREDITO._Valor
                            ._Email = Me.MT_EMAIL.r_Valor
                            ._Fax_1 = Me.MT_FAX1.r_Valor
                            ._Fax_2 = Me.MT_FAX2.r_Valor
                            ._LimiteCreditoPermitido = Me.MN_LIMITE_CREDITO._Valor
                            ._NombreRazonSocial = Me.MT_RAZONSOCIAL.r_Valor
                            ._PersonaContacto = Me.MT_CONTACTO.r_Valor
                            ._RetencionISLR = Me.MN_RET_ISLR._Valor
                            ._RetencionIVA = Me.MN_RET_IVA._Valor
                            ._RifCi = Me.MT_RIF.r_Valor
                            ._Telf_1 = Me.MT_TEL1.r_Valor
                            ._Telf_2 = Me.MT_TEL2.r_Valor
                            ._Telf_3 = Me.MT_TEL3.r_Valor
                            ._Telf_4 = Me.MT_TEL4.r_Valor
                            ._WebSite = Me.MT_WEBSITE.r_Valor
                            ._TipoOrigen = Me.MCB_ORIGEN.SelectedItem.ToString
                        End With
                        xfichaprv.F_ProveedorNuevo(xproveedor)
                        RaiseEvent _ActualizarFicha()
                    End If

                    If MiFichaAccion = TipoAccionFicha.Modificar Then
                        Dim xRegModificar As New FichaProveedores.c_Proveedor.c_ModificarProveedor
                        With xRegModificar
                            ._Automatico = xfichaprv.f_Proveedor.RegistroDato._Automatico
                            ._IdSeguridad = xfichaprv.f_Proveedor.RegistroDato._IdSeguridad
                            ._ActivarCredito = IIf(Me.MCHB_CREDITO.Checked, TipoSiNo.Si, TipoSiNo.No)
                            ._Adevertencia = Me.MT_ADVERTENCIA.r_Valor
                            ._AutoGrupo = Me.MCB_GRUPO.SelectedValue
                            ._CantDocCreditoPermitido = Me.MN_LIMITE_DOC._Valor
                            ._Celular_1 = Me.MT_CEL1.r_Valor
                            ._Celular_2 = Me.MT_CEL2.r_Valor
                            ._Codigo = Me.MT_CODIGO.r_Valor
                            ._Comentarios = Me.MT_COMENTARIOS.r_Valor
                            ._CtaContable_Anticipos = Me.MT_CTA_ANTICIPO.r_Valor
                            ._CtaContable_CXP = Me.MT_CTA_CXC.r_Valor
                            ._CtaContable_Ingresos = Me.MT_CTA_INGRESO.r_Valor
                            ._DenominacionFiscal = Me.MCB_DEN_FISCAL.SelectedItem.ToString
                            ._DirFiscal = Me.MT_DIRFISCAL.r_Valor
                            ._DiasCredito = Me.MN_DIAS_CREDITO._Valor
                            ._Email = Me.MT_EMAIL.r_Valor
                            ._Fax_1 = Me.MT_FAX1.r_Valor
                            ._Fax_2 = Me.MT_FAX2.r_Valor
                            ._LimiteCreditoPermitido = Me.MN_LIMITE_CREDITO._Valor
                            ._NombreRazonSocial = Me.MT_RAZONSOCIAL.r_Valor
                            ._PersonaContacto = Me.MT_CONTACTO.r_Valor
                            ._RetencionISLR = Me.MN_RET_ISLR._Valor
                            ._RetencionIVA = Me.MN_RET_IVA._Valor
                            ._RifCi = Me.MT_RIF.r_Valor
                            ._Telf_1 = Me.MT_TEL1.r_Valor
                            ._Telf_2 = Me.MT_TEL2.r_Valor
                            ._Telf_3 = Me.MT_TEL3.r_Valor
                            ._Telf_4 = Me.MT_TEL4.r_Valor
                            ._WebSite = Me.MT_WEBSITE.r_Valor
                            ._Estatus = IIf(xestatus, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._TipoOrigen = Me.MCB_ORIGEN.SelectedItem.ToString
                        End With
                        xfichaprv.F_ProveedorModifica(xRegModificar)
                        RaiseEvent _ActualizarFicha()
                    End If
                Else
                    IniciarEnCodigo()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                IniciarEnCodigo()
            End Try
        End If
    End Sub

    Private Sub MCHB_CREDITO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_CREDITO.CheckedChanged
        Me.MN_LIMITE_CREDITO.Enabled = Me.MCHB_CREDITO.Checked
        Me.MN_LIMITE_DOC.Enabled = Me.MCHB_CREDITO.Checked
        Me.MN_DIAS_CREDITO.Enabled = Me.MCHB_CREDITO.Checked
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarProveedor()
    End Sub

    Sub EliminarProveedor()
        Try
            If MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprv.f_Proveedor.RegistroDato._Automatico <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor_Eliminar.F_Permitir()

                    Try
                        If MessageBox.Show("Estas Seguro De Eliminar Esta Ficha De Proveedor ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            If xfichaprv.F_ProveedorElimina(xfichaprv.f_Proveedor.RegistroDato._Automatico) Then
                                MessageBox.Show("Proveedor Eliminado Con Exito...", "*** Mensaje De Exito ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                MiFichaAccion = TipoAccionFicha.Inactivo
                                RaiseEvent _ActualizarFicha()
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

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarProveedor()
    End Sub

    Dim xestatus As Boolean
    Sub ModificarProveedor()
        Try
            If MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichaprv.f_Proveedor.RegistroDato._Automatico <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor_Modificar.F_Permitir()

                    xestatus = IIf(xfichaprv.f_Proveedor.RegistroDato._EstatusDelProveedor = TipoEstatus.Activo, True, False)
                    MiFichaAccion = TipoAccionFicha.Modificar
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BT_ESTATUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ESTATUS.Click
        xestatus = Not xestatus
        If xestatus Then
            Me.PB_ESTATUS.Image = My.Resources.ClienteActivo_1
        Else
            Me.PB_ESTATUS.Image = My.Resources.Inactivo_1
        End If
    End Sub

    Sub ControlCtas()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCtaBancariaProveedor.F_Permitir()

            Dim xficha As New Plantilla_3(New ProveedorCtaBancaria(xfichaprv.f_Proveedor.RegistroDato._Automatico))
            With xficha
                AddHandler .ActualizarFicha, AddressOf CargarCtas_Proveedor
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MT_BUSCAR.Select()
        End If
    End Sub

    Private Sub BT_CTAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CTAS.Click
        ControlCtas()
    End Sub

    Sub CargarCtas_Proveedor()
        Try
            Dim xsql As String = "select ag.nombre age ,pa.numero num, pa.nombre_id nom, pa.tipo tip, pa.* " _
                + " from proveedores_agencias pa join agencias ag on pa.auto_agencia=ag.auto where pa.auto_proveedor=@auto order by ag.nombre,pa.numero"
            Dim xpar1 As New SqlClient.SqlParameter("@auto", xfichaprv.f_Proveedor.RegistroDato._Automatico)
            g_MiData.F_GetData(xsql, xtb_ctas, xpar1)

            Me.E_CTAS_REG.Text = "Total Registro(s) Encontrado(s): " + String.Format("{0:#}", xbs_ctas.Count)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub MisGrid1_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MisGrid1.Accion
        If xrow IsNot Nothing Then
            Try
                Dim xcta As New FichaProveedores.c_CtasBancarias
                Dim xreg As DataRow = CType(xrow.DataBoundItem, DataRowView).Row
                xcta.M_CargarFicha(xreg)

                Dim xficha As New Plantilla_4(New MostrarCtaProveedor(xcta))
                With xficha
                    .ShowDialog()
                End With

            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MT_BUSCAR.Select()
        End If
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        xbusquedainmediata = ""
    End Sub

    Public Sub New(ByVal xauto_cargar As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        xbusquedainmediata = xauto_cargar
    End Sub

    Private Sub M_FICHAPROVEEDOR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles M_FICHAPROVEEDOR.Click
        If xfichaprv.f_Proveedor.RegistroDato._Automatico <> "" Then
            Try
                Dim xds As DataSet = New DataSet

                Dim xpar1 As New SqlParameter("@auto", xfichaprv.f_Proveedor.RegistroDato._Automatico)

                Dim xsql = "select nombre,rif,direccion,telefono_1,telefono_2,celular_1,contacto from empresa;" & _
                    "select p.nombre,p.codigo,p.ci_rif,p.dir_fiscal,p.telefono_1,p.telefono_2,p.celular_1,p.celular_2," & _
                         "p.contacto,p.email,p.website,p.credito,p.dias_credito,p.limite_credito,p.doc_pendientes doc_credito," & _
                         "p.denominacion_fiscal,p.retencion_iva,p.retencion_islr,p.fecha_ult_compra,p.fecha_ult_pago," & _
                         "p.advertencia,p.estatus,p.total_debitos,p.total_creditos,p.total_anticipos,p.Total_saldo," & _
                         "p.credito_disponible, p.comentarios, p.contable_cxp, p.contable_ingresos, p.contable_anticipos " & _
                         "from proveedores p join grupo_proveedor gp on p.auto_grupo=gp.auto where p.auto=@auto"

                g_MiData.F_GetData(xsql, xds, xpar1)
                xds.Tables(0).TableName = "empresa"
                xds.Tables(1).TableName = "ficha"

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "PROVEEDOR_FICHA.rpt"
                Dim xficha As New _Reportes(xds, xrep, Nothing)
                With xficha
                    .Show()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub M_FORMATOENCOMIENDA_PROVEEDOR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles M_FORMATOENCOMIENDA_PROVEEDOR.Click
        If xfichaprv.f_Proveedor.RegistroDato._Automatico <> "" Then
            Try
                Dim xds As DataSet = New DataSet

                Dim xpar1 As New SqlParameter("@auto", xfichaprv.f_Proveedor.RegistroDato._Automatico)
                Dim xsql = "select nombre,rif,direccion,telefono_1,telefono_2,celular_1,contacto from empresa;" & _
                  "select P.nombre,P.codigo,P.ci_rif rif,P.dir_fiscal,P.dir_fiscal dir_despacho,P.telefono_1,P.telefono_2,P.celular_1,P.celular_2," & _
                         "P.contacto,P.email,P.website " & _
                         "from PROVEEDORES P  where P.auto=@auto"

                g_MiData.F_GetData(xsql, xds, xpar1)
                xds.Tables(0).TableName = "Emisor"
                xds.Tables(1).TableName = "Receptor"

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "FORMATO_ENCOMIENDA.rpt"
                Dim xficha As New _Reportes(xds, xrep, Nothing)
                With xficha
                    .Show()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class