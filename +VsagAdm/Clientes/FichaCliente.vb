Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class FichaCliente
    Event ActualizarDatosFicha()

    Dim pb_tm As Size
    Dim xaccion As TipoAccionFicha
    Dim xfichacli As FichaClientes

    Dim xbusquedainmediata As String

    Property CargaInmediata() As String
        Get
            Return xbusquedainmediata.Trim
        End Get
        Set(ByVal value As String)
            xbusquedainmediata = value
        End Set
    End Property

    'PARA BUSQUEDA DE CLIENTES RAPIDAS
    Const Busqueda_1 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where nombre like @data order by nombre"
    Const Busqueda_2 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where ci_rif like @data order by nombre"
    Const Busqueda_3 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where codigo like @data order by nombre"

    Property MiFichaAccion() As TipoAccionFicha
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xaccion = value

            If value = TipoAccionFicha.Inactivo Then
                xfichacli.f_Clientes.RegistroDato.M_LimpiarRegistro()

                InicializarControles()
                ActualizarCombos()
                ApagarEncenderBotones(Encendido.Apagar)
                ActivarDesactivarBotones()
                Me.MT_BUSCAR.Select()
                Me.MT_BUSCAR.Focus()
            End If

            If value = TipoAccionFicha.Adicionar Then
                ActivarDesactivarControles(Encendido.Encender)
                LimpiarControles()
                ActualizarCombos()
                ActivarDesactivarBotones()
            End If

            If value = TipoAccionFicha.Modificar Then
                ActivarDesactivarControles(Encendido.Encender)
                ActivarDesactivarBotones()
            End If

            If value = TipoAccionFicha.Consultar Then
                ActivarDesactivarControles(Encendido.Apagar)
                ActivarDesactivarBotones()
            End If
        End Set
    End Property

    Private Sub FichaCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MiFichaAccion = TipoAccionFicha.Inactivo Then
            e.Cancel = False
        Else
            If MiFichaAccion = TipoAccionFicha.Adicionar Or MiFichaAccion = TipoAccionFicha.Consultar Then
                If MessageBox.Show("Deseas Cerrar Esta Ficha De Cliente y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    MiFichaAccion = TipoAccionFicha.Inactivo
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            ElseIf MiFichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Deseas Cerrar Esta Ficha De Cliente y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ClienteNuevoRegistrado(xfichacli.f_Clientes.RegistroDato.r_Automatico)
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FichaCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            AgregarCliente()
        End If
        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            ModificarCliente()
        End If
        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            EliminarCliente()
        End If
        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
                Me.MT_BUSCAR.Select()
            End If
        End If
    End Sub

    Private Sub FichaCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        Me.TabControl1.SelectTab(1)
        Me.TabControl1.SelectTab(0)
    End Sub

    Private Sub FichaCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_tm = PB_1.Size
        Me.TabControl1.TabPages.Remove(Me.TabPage3)
    End Sub

    Sub InicializarControles()
        Dim op As Boolean = False

        Me.E_FECHA_REG.Visible = op
        Me.E_FECHA_REGISTRO.Visible = op

        With Me.MT_LICOR_LICENCIA_NOMBRE
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_LicorLicenciaNombre.c_Largo
            .Enabled = op
        End With
        With Me.MT_LICOR_LICENCIA_NUMERO
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_LicorLicenciaNumero.c_Largo
            .Enabled = op
        End With

        With Me.MT_RIF
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_RIF.c_Largo
            .Enabled = op
        End With
        With Me.MT_CODIGO
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_CodigoCliente.c_Largo
            .Enabled = op
        End With
        With Me.MT_RAZONSOCIAL
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_NombreRazonSocial.c_Largo
            .Enabled = op
        End With
        With Me.MT_DIRFISCAL
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_DirFiscal.c_Largo
            .Enabled = op
        End With
        With Me.MT_DIRDESPACHO
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_DirDespacho.c_Largo
            .Enabled = op
        End With
        With Me.MT_CONTACTO
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_ContactarA.c_Largo
            .Enabled = op
        End With
        With Me.MT_WEBSITE
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_WebSite.c_Largo
            .Enabled = op
        End With
        With Me.MT_EMAIL
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Email.c_Largo
            .Enabled = op
        End With
        With Me.MT_CEL1
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Celular_1.c_Largo
            .Enabled = op
        End With
        With Me.MT_CEL2
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Celular_2.c_Largo
            .Enabled = op
        End With
        With Me.MT_FAX1
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Fax_1.c_Largo
            .Enabled = op
        End With
        With Me.MT_FAX2
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Fax_2.c_Largo
            .Enabled = op
        End With
        With Me.MT_TEL1
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Telefono_1.c_Largo
            .Enabled = op
        End With
        With Me.MT_TEL2
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Telefono_2.c_Largo
            .Enabled = op
        End With
        With Me.MT_TEL3
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Telefono_3.c_Largo
            .Enabled = op
        End With
        With Me.MT_TEL4
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Telefono_4.c_Largo
            .Enabled = op
        End With

        With Me.MCB_GRUPO
            .Enabled = op
        End With
        With Me.MCB_ESTADO
            .Enabled = op
        End With
        With Me.MCB_ZONA
            .Enabled = op
        End With

        With Me.MN_LIMITE_CREDITO
            ._ConSigno = False
            ._Formato = "999999999.99"
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Fax_1.c_Largo
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_LIMITE_DOC
            ._ConSigno = False
            ._Formato = "999"
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Fax_1.c_Largo
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_DIAS_CREDITO
            ._Formato = "999"
            ._ConSigno = False
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Fax_1.c_Largo
            .Text = ""
            .Enabled = op
        End With

        With Me.MCHB_CREDITO
            .Checked = False
            .Enabled = op
        End With
        With Me.MCHB_DIA2
            .Checked = False
            .Enabled = op
        End With
        With Me.MCHB_DIA3
            .Checked = False
            .Enabled = op
        End With
        With Me.MCHB_DIA4
            .Checked = False
            .Enabled = op
        End With
        With Me.MCHB_DIA5
            .Checked = False
            .Enabled = op
        End With
        With Me.MCHB_DIA6
            .Checked = False
            .Enabled = op
        End With
        With Me.MCHB_DIA7
            .Checked = False
            .Enabled = op
        End With
        With Me.MCHB_DIA1
            .Checked = False
            .Enabled = op
        End With

        With Me.MCB_COBRADOR
            .Enabled = op
        End With
        With Me.MCB_VENDEDOR
            .Enabled = op
        End With
        With Me.MCB_PRECIO
            .Enabled = op
        End With
        With Me.MN_DESCUENTO
            ._Formato = "99.99"
            ._ConSigno = False
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Fax_1.c_Largo
            .Enabled = op
        End With
        With Me.MN_CARGO
            ._Formato = "99.99"
            ._ConSigno = False
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Fax_1.c_Largo
            .Enabled = op
        End With

        With Me.MCB_DEN_FISCAL
            .Enabled = op
        End With
        With Me.MN_RET_IVA
            ._Formato = "999.99"
            ._ConSigno = False
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Fax_1.c_Largo
            .Enabled = op
        End With
        With Me.MN_RET_ISLR
            ._Formato = "99.99"
            ._ConSigno = False
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Fax_1.c_Largo
            .Enabled = op
        End With

        With Me.BT_IMG_1
            .Enabled = op
        End With
        With Me.BT_IMG_2
            .Enabled = op
        End With
        With Me.BT_IMG_3
            .Enabled = op
        End With
        With Me.BT_CAMARA
            .Enabled = op
        End With

        With Me.BT_ESTATUS
            .Enabled = op
        End With

        Me.PB_ESTATUS.Image = My.Resources.NoDefinido
        Me.PB_FOTO.Image = My.Resources.NoDefinido

        '
        ' CONTROLES SEGUNDA PAGINA
        '

        With Me.MCHB_AFILIADO
            .Checked = False
            .Enabled = op
        End With
        With Me.MT_FECHA_AFILIADO
            .Text = ""
            .Enabled = op
        End With
        With Me.MN_PUNTOS
            ._Formato = "99.99"
            ._ConSigno = False
            .Text = ""
            .Enabled = op
        End With

        With Me.MT_CTA_CXC
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_ContableCXC.c_Largo
            .Enabled = op
        End With
        With Me.MT_CTA_INGRESO
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_ContableIngresos.c_Largo
            .Enabled = op
        End With
        With Me.MT_CTA_ANTICIPO
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_ContableAnticipos.c_Largo
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

        Me.E_DOC_PENDIENTES.Text = "0"
        Me.E_CREDITO_DISPONIBLE.Text = "0.0"

        With Me.MT_ADVERTENCIA
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Advertencia.c_Largo
            .Enabled = op
        End With
        With Me.MT_COMENTARIOS
            .Text = ""
            .MaxLength = xfichacli.f_Clientes.RegistroDato.c_Comentarios.c_Largo
            .Enabled = op
        End With

        With Me.MCB_BUSQUEDA
            .DataSource = xfichacli.f_Clientes.p_TipoBusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarCliente
        End With

        Me.MT_BUSCAR.Text = ""
    End Sub

    Sub LimpiarControles()
        Me.MT_LICOR_LICENCIA_NOMBRE.Text = ""
        Me.MT_LICOR_LICENCIA_NUMERO.Text = ""

        Me.MT_RIF.Text = ""
        Me.MT_CODIGO.Text = ""
        Me.MT_RAZONSOCIAL.Text = ""
        Me.MT_DIRFISCAL.Text = ""
        Me.MT_DIRDESPACHO.Text = ""
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

        Me.MN_LIMITE_CREDITO.Text = ""
        Me.MN_LIMITE_DOC.Text = ""
        Me.MN_DIAS_CREDITO.Text = ""

        Me.MCHB_DIA2.Checked = False
        Me.MCHB_DIA3.Checked = False
        Me.MCHB_DIA4.Checked = False
        Me.MCHB_DIA5.Checked = False
        Me.MCHB_DIA6.Checked = False
        Me.MCHB_DIA7.Checked = False
        Me.MCHB_DIA1.Checked = False

        Me.MCHB_CREDITO.Checked = False
        If MiFichaAccion = TipoAccionFicha.Adicionar Then
            Me.PB_ESTATUS.Image = My.Resources.ClienteActivo_1
        End If

        Me.MN_DESCUENTO.Text = ""
        Me.MN_CARGO.Text = ""

        Me.MN_RET_IVA.Text = ""
        Me.MN_RET_ISLR.Text = ""
    End Sub

    Sub ActivarDesactivarControles(ByVal op As Encendido)
        Me.MT_LICOR_LICENCIA_NUMERO.Enabled = op
        Me.MT_LICOR_LICENCIA_NOMBRE.Enabled = op

        Me.MT_RIF.Enabled = op
        Me.MT_CODIGO.Enabled = op
        Me.MT_RAZONSOCIAL.Enabled = op
        Me.MT_DIRFISCAL.Enabled = op
        Me.MT_DIRDESPACHO.Enabled = op
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
        Me.MCB_ESTADO.Enabled = op
        Me.MCB_ZONA.Enabled = op

        Me.MN_LIMITE_CREDITO.Enabled = op
        Me.MN_LIMITE_DOC.Enabled = op
        Me.MN_DIAS_CREDITO.Enabled = op

        Me.MCHB_DIA2.Enabled = op
        Me.MCHB_DIA3.Enabled = op
        Me.MCHB_DIA4.Enabled = op
        Me.MCHB_DIA5.Enabled = op
        Me.MCHB_DIA6.Enabled = op
        Me.MCHB_DIA7.Enabled = op
        Me.MCHB_DIA1.Enabled = op

        Me.MCHB_CREDITO.Enabled = op
        If MiFichaAccion = TipoAccionFicha.Adicionar Or MiFichaAccion = TipoAccionFicha.Modificar Then
            Me.MCHB_CREDITO.Checked = Not xfichacli.f_Clientes.RegistroDato.r_CreditoHabilitado
            Me.MCHB_CREDITO.Checked = xfichacli.f_Clientes.RegistroDato.r_CreditoHabilitado
        End If

        Me.MCB_COBRADOR.Enabled = op
        Me.MCB_VENDEDOR.Enabled = op
        Me.MCB_PRECIO.Enabled = op
        Me.MN_DESCUENTO.Enabled = op
        Me.MN_CARGO.Enabled = op

        Me.MCB_DEN_FISCAL.Enabled = op
        Me.MN_RET_IVA.Enabled = op
        Me.MN_RET_ISLR.Enabled = op

        If MiFichaAccion = TipoAccionFicha.Modificar Or MiFichaAccion = TipoAccionFicha.Consultar Or MiFichaAccion = TipoAccionFicha.Inactivo Then
            If Me.xfichacli.f_Clientes.RegistroDato.r_EstatusFoto Then
                Me.BT_IMG_2.Enabled = op
                Me.BT_IMG_3.Enabled = op
                Me.BT_CAMARA.Enabled = op

                If op = Encendido.Encender Then
                    Me.BT_IMG_1.Enabled = False
                Else
                    Me.BT_IMG_1.Enabled = op
                End If
            Else
                Me.BT_IMG_1.Enabled = op
                Me.BT_CAMARA.Enabled = op
            End If
        End If

        If MiFichaAccion = TipoAccionFicha.Adicionar Or MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.BT_ESTATUS.Enabled = False
        ElseIf MiFichaAccion = TipoAccionFicha.Modificar Then
            Me.BT_ESTATUS.Enabled = op
        End If

        '
        ' CONTROLES SEGUNDA PAGINA
        '

        Me.MCHB_AFILIADO.Enabled = op

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
            xfichacli = New DataSistema.MiDataSistema.DataSistema.FichaClientes
            AddHandler xfichacli.ClienteNuevo, AddressOf ClienteNuevoRegistrado

            CargarCombos()
            MiFichaAccion = TipoAccionFicha.Inactivo

            If Me.CargaInmediata <> "" Then
                ClienteNuevoRegistrado(Me.CargaInmediata)
            End If

            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FichaCliente_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
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
        AgregarCliente()
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
        xtb_grupo = New DataTable
        g_MiData.F_GetData("select nombre,auto from grupo_cliente order by nombre", xtb_grupo)
        With Me.MCB_GRUPO
            .DataSource = xtb_grupo
            .DisplayMember = "nombre"
            .ValueMember = "auto"

            If MiFichaAccion = TipoAccionFicha.Modificar Then
                .SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoGrupo
            End If
        End With

        xds = New DataSet
        xtb_estado = New DataTable("estado")
        g_MiData.F_GetData("select nombre,auto from estados order by nombre", xtb_estado)
        xds.Tables.Add(xtb_estado)

        xtb_zona = New DataTable("zona")
        g_MiData.F_GetData("select nombre,auto,auto_estado from zona_cliente order by nombre", xtb_zona)
        xds.Tables.Add(xtb_zona)

        campo_p = xds.Tables("estado").Columns("auto")
        campo_h = xds.Tables("zona").Columns("auto_estado")

        xrel_estado_zona = New DataRelation("Estado_Zona", campo_p, campo_h)
        xds.Relations.Add(xrel_estado_zona)

        xbs_estado = New BindingSource(xds, xtb_estado.TableName)
        xbs_zona = New BindingSource(xbs_estado, "Estado_Zona")

        With Me.MCB_ESTADO
            .DataSource = xbs_estado
            .DisplayMember = "nombre"
            .ValueMember = "auto"

            If MiFichaAccion = TipoAccionFicha.Modificar Then
                .SelectedValue = xfichacli.f_Clientes.RegistroDato.c_AutoEstado.c_Texto
            End If
        End With

        With Me.MCB_ZONA
            .DataSource = xbs_zona
            .DisplayMember = "nombre"
            .ValueMember = "auto"

            If MiFichaAccion = TipoAccionFicha.Modificar Then
                .SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoZona
            End If
        End With

        xtb_vendedor = New DataTable
        g_MiData.F_GetData("select nombre,auto from vendedores where estatus='Activo' order by nombre", xtb_vendedor)
        With Me.MCB_VENDEDOR
            .DataSource = xtb_vendedor
            .DisplayMember = "nombre"
            .ValueMember = "auto"

            If MiFichaAccion = TipoAccionFicha.Modificar Then
                .SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoVendedor
            End If
        End With

        xtb_cobrador = New DataTable
        g_MiData.F_GetData("select nombre,auto from cobradores where estatus='Activo' order by nombre", xtb_cobrador)
        With Me.MCB_COBRADOR
            .DataSource = xtb_cobrador
            .DisplayMember = "nombre"
            .ValueMember = "auto"

            If MiFichaAccion = TipoAccionFicha.Modificar Then
                .SelectedValue = xfichacli.f_Clientes.RegistroDato.c_AutoCobrador.c_Texto
            End If
        End With

        With Me.MCB_DEN_FISCAL
            .DataSource = xfichacli.f_Clientes.p_DenominacionFiscal
            If MiFichaAccion = TipoAccionFicha.Adicionar Then
                .SelectedIndex = 2
            End If
        End With

        With Me.MCB_PRECIO
            .DataSource = xfichacli.f_Clientes.p_TipoPrecioAsignado
            If MiFichaAccion = TipoAccionFicha.Adicionar Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Sub ActualizarCombos()
        xtb_zona.Rows.Clear()
        xtb_estado.Rows.Clear()

        g_MiData.F_GetData("select nombre,auto from grupo_cliente order by nombre", xtb_grupo)
        g_MiData.F_GetData("select nombre,auto from estados order by nombre", xtb_estado)
        g_MiData.F_GetData("select nombre,auto,auto_estado from zona_cliente order by nombre", xtb_zona)
        g_MiData.F_GetData("select nombre,auto from vendedores where estatus='Activo' order by nombre", xtb_vendedor)
        g_MiData.F_GetData("select nombre,auto from cobradores where estatus='Activo' order by nombre", xtb_cobrador)

        With Me.MCB_DEN_FISCAL
            .DataSource = xfichacli.f_Clientes.p_DenominacionFiscal
            If MiFichaAccion = TipoAccionFicha.Adicionar Then
                .SelectedIndex = 2
            End If
        End With

        With Me.MCB_PRECIO
            .DataSource = xfichacli.f_Clientes.p_TipoPrecioAsignado
            If MiFichaAccion = TipoAccionFicha.Adicionar Then
                .SelectedIndex = 0
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
            Me.BT_REPORTES.Enabled = False
            Me.MCB_BUSQUEDA.Enabled = False
            Me.MT_BUSCAR.Enabled = False
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

    Sub AgregarCliente()
        Try
            If MiFichaAccion = TipoAccionFicha.Consultar Or MiFichaAccion = TipoAccionFicha.Inactivo Then
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCliente_Ingresar.F_Permitir()
                Try
                    MiFichaAccion = TipoAccionFicha.Adicionar
                    xfichacli.f_Clientes.RegistroDato.M_LimpiarRegistro()
                Catch ex As Exception
                    MessageBox.Show("Error... " + vbCrLf + ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MCHB_CREDITO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_CREDITO.CheckedChanged
        Dim op As Boolean = Me.MCHB_CREDITO.Checked

        Me.MCHB_DIA2.Enabled = op
        Me.MCHB_DIA3.Enabled = op
        Me.MCHB_DIA4.Enabled = op
        Me.MCHB_DIA5.Enabled = op
        Me.MCHB_DIA6.Enabled = op
        Me.MCHB_DIA7.Enabled = op
        Me.MCHB_DIA1.Enabled = op

        Me.MN_LIMITE_CREDITO.Enabled = op
        Me.MN_LIMITE_DOC.Enabled = op
        Me.MN_DIAS_CREDITO.Enabled = op

        If Me.MCHB_CREDITO.Checked Then
            If Me.MN_DIAS_CREDITO._Valor = 0 Then
                Me.MN_DIAS_CREDITO.Text = "1"
            End If
        Else
            Me.MN_DIAS_CREDITO.Text = xfichacli.f_Clientes.RegistroDato.r_DiasCredito.ToString
        End If
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        GrabarCliente()
    End Sub

    Sub IniciarEnCodigo()
        Me.MT_CODIGO.Select()
        Me.MT_CODIGO.Focus()
    End Sub

    Function ValidarDatos() As Boolean
        If Me.MT_RIF.r_Valor = "" Then
            MessageBox.Show("Falta Por Registrar Ci/Rif Del Cliente... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_RIF.Select()
            Me.MT_RIF.Focus()
            Return False
        End If

        If Me.MT_RAZONSOCIAL.r_Valor = "" Then
            MessageBox.Show("Falta Por Registrar Nombre / Razon Social Del Cliente... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_RAZONSOCIAL.Select()
            Me.MT_RAZONSOCIAL.Focus()
            Return False
        End If

        If Me.MT_DIRFISCAL.r_Valor = "" Then
            MessageBox.Show("Falta Por Registrar Direccion Fiscal Del Cliente... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_DIRFISCAL.Select()
            Me.MT_DIRFISCAL.Focus()
            Return False
        End If

        If Me.MCB_GRUPO.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun Grupo Seleccionado Para Este Cliente... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_GRUPO.Select()
            Me.MCB_GRUPO.Focus()
            Return False
        End If

        If Me.MCB_ESTADO.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun Estado Seleccionado Para Este Cliente... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_ESTADO.Select()
            Me.MCB_ESTADO.Focus()
            Return False
        End If

        If Me.MCB_ZONA.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun Zona Seleccionado Para Este Cliente... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_ZONA.Select()
            Me.MCB_ZONA.Focus()
            Return False
        End If

        If Me.MCB_VENDEDOR.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun Vendedor Seleccionado Para Este Cliente... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_VENDEDOR.Select()
            Me.MCB_VENDEDOR.Focus()
            Return False
        End If

        If Me.MCB_COBRADOR.SelectedValue Is Nothing Then
            MessageBox.Show("No Hay Ningun Cobrador Seleccionado Para Este Cliente... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MCB_COBRADOR.Select()
            Me.MCB_COBRADOR.Focus()
            Return False
        End If

        Return True
    End Function

    Sub GrabarCliente()
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
                        Dim xcliente As New FichaClientes.c_Clientes.c_AgregarCliente
                        With xcliente
                            ._ActivarCredito = IIf(Me.MCHB_CREDITO.Checked, TipoSiNo.Si, TipoSiNo.No)
                            ._Adevertencia = Me.MT_ADVERTENCIA.r_Valor
                            ._AutoCobrador = IIf(Me.MCB_COBRADOR.SelectedValue IsNot Nothing, Me.MCB_COBRADOR.SelectedValue, "")
                            ._AutoEstado = IIf(Me.MCB_ESTADO.SelectedValue IsNot Nothing, Me.MCB_ESTADO.SelectedValue, "")
                            ._AutoGrupo = IIf(Me.MCB_GRUPO.SelectedValue IsNot Nothing, Me.MCB_GRUPO.SelectedValue, "")
                            ._AutoVendedor = IIf(Me.MCB_VENDEDOR.SelectedValue IsNot Nothing, Me.MCB_VENDEDOR.SelectedValue, "")
                            ._AutoZona = IIf(Me.MCB_ZONA.SelectedValue IsNot Nothing, Me.MCB_ZONA.SelectedValue, "")
                            ._CantDocCreditoPermitido = Me.MN_LIMITE_DOC._Valor
                            ._CargoAsignado = Me.MN_CARGO._Valor
                            ._Celular_1 = Me.MT_CEL1.r_Valor
                            ._Celular_2 = Me.MT_CEL2.r_Valor
                            ._Codigo = Me.MT_CODIGO.r_Valor
                            ._Comentarios = Me.MT_COMENTARIOS.r_Valor
                            ._CtaContable_Anticipos = Me.MT_CTA_ANTICIPO.r_Valor
                            ._CtaContable_CXC = Me.MT_CTA_CXC.r_Valor
                            ._CtaContable_Ingresos = Me.MT_CTA_INGRESO.r_Valor
                            ._DenominacionFiscal = Me.MCB_DEN_FISCAL.SelectedItem.ToString
                            ._Dia1 = IIf(Me.MCHB_DIA1.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia2 = IIf(Me.MCHB_DIA2.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia3 = IIf(Me.MCHB_DIA3.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia4 = IIf(Me.MCHB_DIA4.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia5 = IIf(Me.MCHB_DIA5.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia6 = IIf(Me.MCHB_DIA6.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia7 = IIf(Me.MCHB_DIA7.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._DirDespacho = Me.MT_DIRDESPACHO.r_Valor
                            ._DirFiscal = Me.MT_DIRFISCAL.r_Valor
                            ._DiasCredito = Me.MN_DIAS_CREDITO._Valor
                            ._DscAsignado = Me.MN_DESCUENTO._Valor
                            ._Email = Me.MT_EMAIL.r_Valor
                            ._EstatusAfiliacion = IIf(Me.MCHB_AFILIADO.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Fax_1 = Me.MT_FAX1.r_Valor
                            ._Fax_2 = Me.MT_FAX2.r_Valor
                            ._LimiteCreditoPermitido = Me.MN_LIMITE_CREDITO._Valor
                            ._NombreRazonSocial = Me.MT_RAZONSOCIAL.r_Valor
                            ._PersonaContacto = Me.MT_CONTACTO.r_Valor
                            ._PrecioTarifa = IIf(Me.MCB_PRECIO.SelectedIndex = 0, PrecioTarifa.Precio_1, PrecioTarifa.Precio_2)
                            ._RetencionISLR = Me.MN_RET_ISLR._Valor
                            ._RetencionIVA = Me.MN_RET_IVA._Valor
                            ._RifCi = Me.MT_RIF.r_Valor
                            ._Telf_1 = Me.MT_TEL1.r_Valor
                            ._Telf_2 = Me.MT_TEL2.r_Valor
                            ._Telf_3 = Me.MT_TEL3.r_Valor
                            ._Telf_4 = Me.MT_TEL4.r_Valor
                            ._WebSite = Me.MT_WEBSITE.r_Valor
                            ._LicorLicenciaNombre = Me.MT_LICOR_LICENCIA_NOMBRE.r_Valor
                            ._LicorLicenciaNumero = Me.MT_LICOR_LICENCIA_NUMERO.r_Valor
                        End With
                        xfichacli.F_ClienteNuevo(xcliente)
                    End If

                    If MiFichaAccion = TipoAccionFicha.Modificar Then
                        With xRegModificar
                            ._Automatico = xfichacli.f_Clientes.RegistroDato.r_Automatico
                            ._IdSeguridad = xfichacli.f_Clientes.RegistroDato.r_IdSeguridad
                            ._ActivarCredito = IIf(Me.MCHB_CREDITO.Checked, TipoSiNo.Si, TipoSiNo.No)
                            ._Adevertencia = Me.MT_ADVERTENCIA.r_Valor
                            ._AutoCobrador = Me.MCB_COBRADOR.SelectedValue
                            ._AutoEstado = Me.MCB_ESTADO.SelectedValue
                            ._AutoGrupo = Me.MCB_GRUPO.SelectedValue
                            ._AutoVendedor = Me.MCB_VENDEDOR.SelectedValue
                            ._AutoZona = Me.MCB_ZONA.SelectedValue
                            ._CantDocCreditoPermitido = Me.MN_LIMITE_DOC._Valor
                            ._CargoAsignado = Me.MN_CARGO._Valor
                            ._Celular_1 = Me.MT_CEL1.r_Valor
                            ._Celular_2 = Me.MT_CEL2.r_Valor
                            ._Codigo = Me.MT_CODIGO.r_Valor
                            ._Comentarios = Me.MT_COMENTARIOS.r_Valor
                            ._CtaContable_Anticipos = Me.MT_CTA_ANTICIPO.r_Valor
                            ._CtaContable_CXC = Me.MT_CTA_CXC.r_Valor
                            ._CtaContable_Ingresos = Me.MT_CTA_INGRESO.r_Valor
                            ._DenominacionFiscal = Me.MCB_DEN_FISCAL.SelectedItem.ToString
                            ._Dia1 = IIf(Me.MCHB_DIA1.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia2 = IIf(Me.MCHB_DIA2.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia3 = IIf(Me.MCHB_DIA3.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia4 = IIf(Me.MCHB_DIA4.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia5 = IIf(Me.MCHB_DIA5.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia6 = IIf(Me.MCHB_DIA6.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._Dia7 = IIf(Me.MCHB_DIA7.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            ._DirDespacho = Me.MT_DIRDESPACHO.r_Valor
                            ._DirFiscal = Me.MT_DIRFISCAL.r_Valor
                            ._DiasCredito = Me.MN_DIAS_CREDITO._Valor
                            ._DscAsignado = Me.MN_DESCUENTO._Valor
                            ._Email = Me.MT_EMAIL.r_Valor
                            ._EstatusAfiliacion = IIf(Me.MCHB_AFILIADO.Checked, TipoEstatus.Activo, TipoEstatus.Inactivo)
                            '._EstatusFoto=""
                            ._Fax_1 = Me.MT_FAX1.r_Valor
                            ._Fax_2 = Me.MT_FAX2.r_Valor
                            ._LimiteCreditoPermitido = Me.MN_LIMITE_CREDITO._Valor
                            ._NombreRazonSocial = Me.MT_RAZONSOCIAL.r_Valor
                            ._PersonaContacto = Me.MT_CONTACTO.r_Valor
                            ._PrecioTarifa = IIf(Me.MCB_PRECIO.SelectedIndex = 0, PrecioTarifa.Precio_1, PrecioTarifa.Precio_2)
                            ._RetencionISLR = Me.MN_RET_ISLR._Valor
                            ._RetencionIVA = Me.MN_RET_IVA._Valor
                            ._RifCi = Me.MT_RIF.r_Valor
                            ._Telf_1 = Me.MT_TEL1.r_Valor
                            ._Telf_2 = Me.MT_TEL2.r_Valor
                            ._Telf_3 = Me.MT_TEL3.r_Valor
                            ._Telf_4 = Me.MT_TEL4.r_Valor
                            ._WebSite = Me.MT_WEBSITE.r_Valor
                            ._LicorLicenciaNombre = Me.MT_LICOR_LICENCIA_NOMBRE.r_Valor
                            ._LicorLicenciaNumero = Me.MT_LICOR_LICENCIA_NUMERO.r_Valor
                        End With
                        xfichacli.F_ClienteModifica(xRegModificar)
                        RaiseEvent ActualizarDatosFicha()
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

    Sub MostrarData()
        Me.MT_LICOR_LICENCIA_NOMBRE.Text = xfichacli.f_Clientes.RegistroDato.r_LicorLicenciaNombre
        Me.MT_LICOR_LICENCIA_NUMERO.Text = xfichacli.f_Clientes.RegistroDato.r_LicorLicenciaNumero

        Me.MT_CODIGO.Text = xfichacli.f_Clientes.RegistroDato.r_CodigoCliente
        Me.MT_RIF.Text = xfichacli.f_Clientes.RegistroDato.r_CiRif
        Me.MT_RAZONSOCIAL.Text = xfichacli.f_Clientes.RegistroDato.r_NombreRazonSocial
        Me.MT_DIRFISCAL.Text = xfichacli.f_Clientes.RegistroDato.r_DirFiscal
        Me.MT_DIRDESPACHO.Text = xfichacli.f_Clientes.RegistroDato.r_DirDespacho

        Me.MCB_GRUPO.Enabled = True
        Me.MCB_ESTADO.Enabled = True
        Me.MCB_GRUPO.SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoGrupo
        Me.MCB_ESTADO.SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoEstado
        Me.MCB_GRUPO.Enabled = False
        Me.MCB_ESTADO.Enabled = False

        Me.MCB_VENDEDOR.Enabled = True
        Me.MCB_COBRADOR.Enabled = True
        Me.MCB_VENDEDOR.SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoVendedor
        Me.MCB_COBRADOR.SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoCobrador
        Me.MCB_COBRADOR.Enabled = False
        Me.MCB_VENDEDOR.Enabled = False

        Me.MCB_ZONA.Enabled = True
        Me.MCB_ZONA.SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoZona
        Me.MCB_ZONA.Enabled = False

        Me.MT_CONTACTO.Text = xfichacli.f_Clientes.RegistroDato.r_ContactarA
        Me.MT_TEL1.Text = xfichacli.f_Clientes.RegistroDato.r_Telefono_1
        Me.MT_TEL2.Text = xfichacli.f_Clientes.RegistroDato.r_Telefono_2
        Me.MT_TEL3.Text = xfichacli.f_Clientes.RegistroDato.r_Telefono_3
        Me.MT_TEL4.Text = xfichacli.f_Clientes.RegistroDato.r_Telefono_4
        Me.MT_FAX1.Text = xfichacli.f_Clientes.RegistroDato.r_Fax_1
        Me.MT_FAX2.Text = xfichacli.f_Clientes.RegistroDato.r_Fax_2
        Me.MT_CEL1.Text = xfichacli.f_Clientes.RegistroDato.r_Celular_1
        Me.MT_CEL2.Text = xfichacli.f_Clientes.RegistroDato.r_Celular_2
        Me.MT_EMAIL.Text = xfichacli.f_Clientes.RegistroDato.r_Email
        Me.MT_WEBSITE.Text = xfichacli.f_Clientes.RegistroDato.r_WebSite

        Me.MCHB_CREDITO.Checked = xfichacli.f_Clientes.RegistroDato.r_CreditoHabilitado
        Me.MN_DIAS_CREDITO.Text = xfichacli.f_Clientes.RegistroDato.r_DiasCredito.ToString
        Me.MN_LIMITE_CREDITO.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_LimiteCreditoPermitido)
        Me.MN_LIMITE_DOC.Text = String.Format("{0:#0}", xfichacli.f_Clientes.RegistroDato.r_CantDocPendPermitidos)
        Me.MCHB_DIA1.Checked = xfichacli.f_Clientes.RegistroDato.r_Dia1
        Me.MCHB_DIA2.Checked = xfichacli.f_Clientes.RegistroDato.r_Dia2
        Me.MCHB_DIA3.Checked = xfichacli.f_Clientes.RegistroDato.r_Dia3
        Me.MCHB_DIA4.Checked = xfichacli.f_Clientes.RegistroDato.r_Dia4
        Me.MCHB_DIA5.Checked = xfichacli.f_Clientes.RegistroDato.r_Dia5
        Me.MCHB_DIA6.Checked = xfichacli.f_Clientes.RegistroDato.r_Dia6
        Me.MCHB_DIA7.Checked = xfichacli.f_Clientes.RegistroDato.r_Dia7

        Me.MN_CARGO.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_CargoPorcentaje)
        Me.MN_DESCUENTO.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_DescuentoGlobal)
        If xfichacli.f_Clientes.RegistroDato.r_TipoPrecioFijado = "1" Then
            Me.MCB_PRECIO.SelectedIndex = 0
        Else
            Me.MCB_PRECIO.SelectedIndex = 1
        End If

        Me.MCB_DEN_FISCAL.SelectedItem = xfichacli.f_Clientes.RegistroDato.r_DenominacionFiscal
        Me.MN_RET_ISLR.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_RetencionISLR)
        Me.MN_RET_IVA.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_RetencionIva)

        Me.E_FECHA_REG.Visible = True
        Me.E_FECHA_REGISTRO.Visible = True
        Me.E_FECHA_REGISTRO.Text = xfichacli.f_Clientes.RegistroDato.c_FechaAlta.c_Valor.ToShortDateString

        If xfichacli.f_Clientes.RegistroDato.r_EstatusDelCliente = TipoEstatus.Activo Then
            Me.PB_ESTATUS.Image = My.Resources.ClienteActivo_1
        Else
            Me.PB_ESTATUS.Image = My.Resources.Inactivo_1
        End If

        Me.MCHB_AFILIADO.Checked = xfichacli.f_Clientes.RegistroDato.r_EstatusAfiliado
        Me.MN_PUNTOS.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_PuntoAcumulados)
        Me.MT_FECHA_AFILIADO.Text = xfichacli.f_Clientes.RegistroDato.r_FechaAfiliacion.ToShortDateString

        Me.MT_CTA_ANTICIPO.Text = xfichacli.f_Clientes.RegistroDato.r_CtaAnticipos
        Me.MT_CTA_CXC.Text = xfichacli.f_Clientes.RegistroDato.r_CtaCxC
        Me.MT_CTA_INGRESO.Text = xfichacli.f_Clientes.RegistroDato.r_CtaIngresos

        Me.MT_FECHA_ULTPAGO.Text = xfichacli.f_Clientes.RegistroDato.r_FechaUltPago.ToShortDateString
        Me.MT_FECHA_ULTVENTA.Text = xfichacli.f_Clientes.RegistroDato.r_FechaUltVenta.ToShortDateString

        Me.MN_TOTANTICIPO.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_TotalAnticipos)
        Me.MN_TOTCREDITO.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_TotalCreditos)
        Me.MN_TOTDEBITO.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_TotalDebitos)
        Me.MN_TOTSALDO.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_TotalSaldo)
        Me.E_CREDITO_DISPONIBLE.Text = String.Format("{0:#0.00}", xfichacli.f_Clientes.RegistroDato.r_CreditoDisponible)
        Me.E_DOC_PENDIENTES.Text = xfichacli.f_Clientes.RegistroDato.r_CantidadDocPendientes.ToString

        Me.MT_ADVERTENCIA.Text = xfichacli.f_Clientes.RegistroDato.r_Advertencias
        Me.MT_COMENTARIOS.Text = xfichacli.f_Clientes.RegistroDato.r_Comentarios
    End Sub

    Sub ClienteNuevoRegistrado(ByVal xauto As String)
        Try
            xfichacli.F_BuscarCliente(xauto)
            MostrarData()
            If MiFichaAccion = TipoAccionFicha.Adicionar Then
                MessageBox.Show("Cliente Registrado Con Exito...", "*** Mensaje De Exito ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Sub ControlGrupos()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoCliente.F_Permitir()

            Dim xficha As New Plantilla_1(New GrupoCliente)
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
        g_MiData.F_GetData("select nombre,auto from grupo_cliente order by nombre", xtb_grupo)
        If MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MCB_GRUPO.Enabled = True
            Me.MCB_GRUPO.SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoGrupo
            Me.MCB_GRUPO.Enabled = False
        End If
    End Sub

    Private Sub BT_BUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR.Click
        BusquedaClientes()
    End Sub

    Sub BusquedaClientes()
        If MT_BUSCAR.r_Valor <> "" Then
            Dim xsql As String = ""
            Dim xp1 As SqlParameter
            Dim xbuscar As String = ""

            Select Case CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaClientes.TipoBusquedaCliente)
                Case FichaClientes.TipoBusquedaCliente.PorNombreRazonSocial
                    xsql = Busqueda_1
                Case FichaClientes.TipoBusquedaCliente.PorRif_CI
                    xsql = Busqueda_2
                Case FichaClientes.TipoBusquedaCliente.PorCodigo
                    xsql = Busqueda_3
            End Select

            If MT_BUSCAR.Text.Substring(0, 1) = "*" Then
                xbuscar = "%" + MT_BUSCAR.r_Valor.Substring(1)
            Else
                xbuscar = MT_BUSCAR.r_Valor
            End If

            xp1 = New SqlParameter("@data", xbuscar + "%")
            Dim xficha As New Plantilla_2(New BusquedaCliente, xsql, xp1)
            With xficha
                AddHandler .EnviarAuto, AddressOf ClienteNuevoRegistrado
                .ShowDialog()
            End With
            Me.MT_BUSCAR.Text = ""
        End If
        Me.MT_BUSCAR.Select()
    End Sub

    Sub IrInicio()
        With Me.MT_BUSCAR
            .Text = ""
            .Select()
            .Focus()
        End With
    End Sub

    Private Sub MCB_BUSQUEDA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSQUEDA.SelectedIndexChanged
        IrInicio()
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarCliente()
    End Sub

    Sub EliminarCliente()
        Try
            If MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCliente_Eliminar.F_Permitir()

                    Try
                        If MessageBox.Show("Estas Seguro De Eliminar Esta Ficha De Cliente ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            If xfichacli.F_ClienteElimina(xfichacli.f_Clientes.RegistroDato.r_Automatico) Then
                                MessageBox.Show("Cliente Eliminado Con Exito...", "*** Mensaje De Exito ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                MiFichaAccion = TipoAccionFicha.Inactivo
                                RaiseEvent ActualizarDatosFicha()
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

    Sub CargarZonas()
        g_MiData.F_GetData("select nombre,auto,auto_estado from zona_cliente order by nombre", xtb_zona)
        If MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MCB_ZONA.Enabled = True
            Me.MCB_ZONA.SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoZona
            Me.MCB_ZONA.Enabled = False
        End If
    End Sub

    Private Sub LINK_ZONA_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_ZONA.LinkClicked
        ControlZonas()
    End Sub

    Sub ControlZonas()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloZonaCliente.F_Permitir()

            Dim xficha As New ZonaCliente
            AddHandler xficha.Actualizar, AddressOf CargarZonas
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

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        ModificarCliente()
    End Sub

    Dim xRegModificar As FichaClientes.c_Clientes.c_ModificarCliente
    Sub ModificarCliente()
        Try
            If MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCliente_Modificar.F_Permitir()

                    xRegModificar = New FichaClientes.c_Clientes.c_ModificarCliente()
                    xRegModificar._Estatus = xfichacli.f_Clientes.RegistroDato.r_EstatusDelCliente
                    MiFichaAccion = TipoAccionFicha.Modificar
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BT_ESTATUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ESTATUS.Click
        If xRegModificar._Estatus = TipoEstatus.Activo Then
            xRegModificar._Estatus = TipoEstatus.Inactivo
            Me.PB_ESTATUS.Image = My.Resources.Inactivo_1
        Else
            xRegModificar._Estatus = TipoEstatus.Activo
            Me.PB_ESTATUS.Image = My.Resources.ClienteActivo_1
        End If
    End Sub

    Private Sub BT_BUS_AVANZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUS_AVANZ.Click
        BusquedaAvanzada()
    End Sub

    Sub BusquedaAvanzada()
        Dim xficha As New BusAvanzadaCliente
        With xficha
            AddHandler .LlamarReceptor, AddressOf ReceptorBusAvanzada
            .ShowDialog()
        End With

        If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MT_BUSCAR.Select()
        End If
    End Sub

    Sub ReceptorBusAvanzada(ByVal xsql As String)
        Dim xficha As New Plantilla_2(New BusquedaCliente, xsql)
        With xficha
            AddHandler .EnviarAuto, AddressOf ClienteNuevoRegistrado
            .ShowDialog()
        End With
    End Sub

    Private Sub LINK_VENDEDOR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_VENDEDOR.LinkClicked
        ControlVendedores()
    End Sub

    Sub ControlVendedores()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloVendedor.F_Permitir()

            Dim xficha As New FichaVendedor(xfichacli.f_Clientes.RegistroDato.r_AutoVendedor)
            With xficha
                AddHandler xficha.ActualizarFicha, AddressOf CargarVendedores
                .ShowDialog()
            End With

            If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
                Me.MT_BUSCAR.Select()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarVendedores()
        g_MiData.F_GetData("select nombre,auto from vendedores where estatus='Activo' order by nombre", xtb_vendedor)
        If MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MCB_VENDEDOR.Enabled = True
            Me.MCB_VENDEDOR.SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoVendedor
            Me.MCB_VENDEDOR.Enabled = False
        End If
    End Sub

    Private Sub LINK_COBRADOR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_COBRADOR.LinkClicked
        ControlCobradores()
    End Sub

    Sub ControlCobradores()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCobrador.F_Permitir()

            Dim xficha As New FichaCobrador(xfichacli.f_Clientes.RegistroDato.r_AutoCobrador)
            With xficha
                AddHandler xficha.ActualizarFicha, AddressOf CargarCobradores
                .ShowDialog()
            End With

            If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
                Me.MT_BUSCAR.Select()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarCobradores()
        g_MiData.F_GetData("select nombre,auto from cobradores where estatus='Activo' order by nombre", xtb_cobrador)
        If MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MCB_COBRADOR.Enabled = True
            Me.MCB_COBRADOR.SelectedValue = xfichacli.f_Clientes.RegistroDato.r_AutoCobrador
            Me.MCB_COBRADOR.Enabled = False
        End If
    End Sub

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.CargaInmediata = ""
    End Sub

    Sub New(ByVal xauto As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.CargaInmediata = xauto
    End Sub

    Function _FechaComienzoDelMes(ByVal xfecha As Date) As Date
        Dim xsql As String = "select dateadd(month,datediff(month,'19000101',@fecha),'19000101')"
        Dim xpr1 As New SqlParameter("@fecha", xfecha)
        Return F_GetDate(xsql, xpr1)
    End Function

    Class xExeption
        Inherits Exception

        Sub New()
            MyBase.New()
        End Sub
    End Class

    Private Sub ESTADO_CUENTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ESTADO_CUENTA.Click
        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            Try

                Dim xf As New FechaInicio
                Dim xfecha As Date = Date.MinValue
                With xf
                    .ShowDialog()
                    xfecha = ._FechaIniciar
                End With
                If xfecha = Date.MinValue Then
                    Throw New xExeption
                End If

                Dim xds As New DataSet
                Dim xpar1 As New SqlParameter("@auto_cliente", xfichacli.f_Clientes.RegistroDato.r_Automatico)
                Dim xpar2 As New SqlParameter("@fecha", _FechaComienzoDelMes(xfecha))

                Dim xsql1 As String = "select fecha,tipo_documento,documento,detalle,importe,acumulado,resta,signo " & _
                   "from cxc where auto_cliente=@auto_cliente and cxc.estatus<>'1' and cxc.fecha > @fecha;" & _
                   "select nombre,rif,direccion from empresa;" & _
                   "select nombre,codigo,ci_rif,dir_fiscal,telefono,credito_disponible,total_anticipos,dias_credito,limite_credito from clientes where auto=@auto_cliente"
                g_MiData.F_GetData(xsql1, xds, xpar1, xpar2)

                xpar1 = New SqlParameter("@auto_cliente", xfichacli.f_Clientes.RegistroDato.r_Automatico)
                xpar2 = New SqlParameter("@fecha", _FechaComienzoDelMes(xfecha))
                Dim xsql2 As String = "select sum(ABS(importe)*signo) as saldo from cxc where auto_cliente=@auto_cliente and cxc.estatus<>'1' and cxc.fecha <= @fecha"
                Dim xsaldo As Decimal = F_GetDecimal(xsql2, xpar1, xpar2)

                xds.Tables(0).TableName = "Cxc"
                xds.Tables(1).TableName = "Empresa"
                xds.Tables(2).TableName = "Cliente"

                Dim xlista As New List(Of _Reportes.ParamtCrystal)
                Dim xpc1 As New _Reportes.ParamtCrystal("@fecha", _FechaComienzoDelMes(xfecha))
                Dim xpc2 As New _Reportes.ParamtCrystal("@saldo_anterior", xsaldo)
                xlista.Add(xpc1)
                xlista.Add(xpc2)

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "CLIENTE_ESTADO_CUENTA.rpt"
                Dim xficha As New _Reportes(xds, xrep, xlista)
                With xficha
                    .Show()
                End With
            Catch ex2 As xExeption
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub DOCUMENTOS_PENDIENTES_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DOCUMENTOS_PENDIENTES.Click
        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            Try
                Dim xds As DataSet = New DataSet

                Dim xpar1 As New SqlParameter("@auto_cliente", xfichacli.f_Clientes.RegistroDato.r_Automatico)
                Dim xsql = "select fecha,tipo_documento,documento,fecha_vencimiento,detalle,importe,acumulado,resta " _
                  + "from cxc where auto_cliente=@auto_cliente and cancelado<>'1' and estatus<>'1' and tipo_documento NOT IN('PAG','ANT') order by fecha;" _
                  + "select nombre,rif,direccion from empresa;" _
                  + "select nombre,codigo,ci_rif,dir_fiscal,telefono from clientes where auto=@auto_cliente"

                g_MiData.F_GetData(xsql, xds, xpar1)
                xds.Tables(0).TableName = "Cxc"
                xds.Tables(1).TableName = "Empresa"
                xds.Tables(2).TableName = "Cliente"

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "CLIENTE_DOCUMENTOS_PENDIENTES.rpt"
                Dim xficha As New _Reportes(xds, xrep, Nothing)
                With xficha
                    .Show()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub FORMATO_ENCOMIENDA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FORMATO_ENCOMIENDA.Click
        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            Try
                Dim xds As DataSet = New DataSet

                Dim xpar1 As New SqlParameter("@auto_cliente", xfichacli.f_Clientes.RegistroDato.r_Automatico)
                Dim xsql = "select nombre,rif,direccion,telefono_1,telefono_2,celular_1,contacto from empresa;" & _
                  "select c.nombre,c.codigo,c.ci_rif rif,c.dir_fiscal,c.dir_despacho,c.telefono_1,c.telefono_2,c.celular_1,c.celular_2," & _
                         "c.contacto,c.email,c.website,e.nombre as nombre_estado, cz.nombre as nombre_zona " & _
                         "from clientes c join estados e on c.auto_estado=e.auto join zona_cliente cz on c.auto_zona=cz.auto where c.auto=@auto_cliente"

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

    Private Sub BT_REPORTES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_REPORTES.Click
        IrInicio()
    End Sub

    Private Sub FICHA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FICHA.Click
        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            Try
                Dim xds As DataSet = New DataSet

                Dim xpar1 As New SqlParameter("@auto_cliente", xfichacli.f_Clientes.RegistroDato.r_Automatico)
                Dim xsql = "select nombre,rif,direccion,telefono_1,telefono_2,celular_1,contacto from empresa;" & _
                  "select c.nombre,c.codigo,c.ci_rif,c.dir_fiscal,c.dir_despacho,c.telefono_1,c.telefono_2,c.celular_1,c.celular_2," & _
                         "c.contacto,c.email,c.website,c.tarifa precio_asignado,c.descuento,c.recargo cargo,c.puntos puntos_acumulados," & _
                         "c.credito,c.dias_credito,c.limite_credito,c.doc_pendientes doc_credito,c.denominacion_fiscal,c.retencion_iva,c.retencion_islr," & _
                         "c.fecha_ult_compra,c.fecha_ult_pago,c.advertencia,c.estatus,c.total_debitos,c.total_creditos,c.total_anticipos,c.Total_saldo," & _
                         "c.credito_disponible,c.comentarios,c.contable_cxc,c.contable_ingresos,c.contable_anticipos," & _
                         "e.nombre as nombre_estado, cz.nombre as nombre_zona,gc.nombre nombre_grupo, v.nombre vendedor " & _
                         "from clientes c join estados e on c.auto_estado=e.auto join zona_cliente cz on c.auto_zona=cz.auto " & _
                         "join grupo_cliente gc on c.auto_grupo=gc.auto join vendedores v on c.auto_vendedor=v.auto where c.auto=@auto_cliente"

                g_MiData.F_GetData(xsql, xds, xpar1)
                xds.Tables(0).TableName = "empresa"
                xds.Tables(1).TableName = "ficha"

                Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                xrep += "CLEINTE_FICHA.rpt"
                Dim xficha As New _Reportes(xds, xrep, Nothing)
                With xficha
                    .Show()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub MN_DIAS_CREDITO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MN_DIAS_CREDITO.Validating
        If Me.MCHB_CREDITO.Checked Then
            If Me.MN_DIAS_CREDITO._Valor = 0 Then
                Me.MN_DIAS_CREDITO.Text = "1"
            End If
        End If
    End Sub

    Private Sub CARNET_AFILIACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CARNET_AFILIACION.Click
        If xfichacli.f_Clientes.RegistroDato.r_Automatico <> "" Then
            Try
                Dim xds As DataSet = New DataSet
                Dim xpar1 As New SqlParameter("@auto_cliente", xfichacli.f_Clientes.RegistroDato.r_Automatico)
                Dim xsql = "select codigo as codigobarra from clientes where auto=@auto_cliente"
                g_MiData.F_GetData(xsql, xds, xpar1)
                xds.Tables(0).TableName = "CarnetCliente"
                Dim xcodigo = xds.Tables(0).Rows(0)(0).ToString.Trim
                If xcodigo <> "" Then
                    xds.Tables(0).Rows(0)(0) = "*" + xcodigo + "*"
                    Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                    xrep = "C:\+VsagAdm v7.9.27\+VsagAdm\Reportes\TarjetaAfiliacion.rpt"
                    Dim xficha As New _Reportes(xds, xrep, Nothing)
                    With xficha
                        .Show()
                    End With
                Else
                    Funciones.MensajeDeAlerta("NO HAY IN CODIGO ASIGNADO AL CLIENTE")
                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If

    End Sub

  
End Class