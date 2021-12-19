Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class FichaCobrador
    Event ActualizarFicha()

    Dim pb_tm As Size
    Dim xaccion As TipoAccionFicha
    Dim xfichacob As FichaCobradores
    Dim xtb_comisiones As DataTable
    Dim xautcobrador As String

    'PARA BUSQUEDA DE COBRADORES RAPIDAS
    Const Busqueda_1 As String = "select nombre nom, telefono1 tel, celular1 cel, * from cobradores where nombre like @data order by nombre"
    Const Busqueda_2 As String = "select nombre nom, telefono1 tel, celular1 cel, * from cobradores where ci like @data order by ci"
    Const Busqueda_3 As String = "select nombre nom, telefono1 tel, celular1 cel, * from cobradores where codigo like @data order by codigo"

    Property _AutoCobradorCagar() As String
        Get
            Return xautcobrador
        End Get
        Set(ByVal value As String)
            xautcobrador = value
        End Set
    End Property

    Property MiFichaAccion() As TipoAccionFicha
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xaccion = value

            If value = TipoAccionFicha.Inactivo Then
                xtb_comisiones.Rows.Clear()
                InicializarControles()
                ApagarEncenderBotones(Encendido.Apagar)
                ActivarDesactivarBotones()
                Me.MT_BUSCAR.Select()
                Me.MT_BUSCAR.Focus()
            End If

            If value = TipoAccionFicha.Adicionar Then
                ActivarDesactivarControles(Encendido.Encender)
                LimpiarControles()
                CargarCombos()
                ActivarDesactivarBotones()
            End If

            If value = TipoAccionFicha.Modificar Then
                ActivarDesactivarControles(Encendido.Encender)
                CargarCombos()
                ActivarDesactivarBotones()
            End If

            If value = TipoAccionFicha.Consultar Then
                ActivarDesactivarControles(Encendido.Apagar)
                ActivarDesactivarBotones()
            End If
        End Set
    End Property

    Private Sub FichaCobrador_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MiFichaAccion = TipoAccionFicha.Inactivo Then
            e.Cancel = False
        Else
            If MiFichaAccion = TipoAccionFicha.Adicionar Or MiFichaAccion = TipoAccionFicha.Consultar Then
                If MessageBox.Show("Deseas Cerrar Esta Ficha De Cobrador y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    MiFichaAccion = TipoAccionFicha.Inactivo
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            ElseIf MiFichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Deseas Cerrar Esta Ficha De Cobrador y/o Perder Los Datos ?", "*** MENSAJE DE ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    CobradorNuevoRegistrado(xfichacob.f_Cobrador.RegistroDato.r_Automatico)
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FichaCobrador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            AgregarCobrador()
        End If
        If e.KeyCode = Keys.F2 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            ModificarCobrador()
        End If
        If e.KeyCode = Keys.F3 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            EliminarCobrador()
        End If
        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
                Me.MT_BUSCAR.Select()
            End If
        End If
    End Sub

    Private Sub FichaCobrador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FichaCobrador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pb_tm = PB_1.Size
    End Sub

    Sub InicializarControles()
        Dim op As Boolean = False

        Me.E_FECHA_REG.Visible = op
        Me.E_FECHA_REGISTRO.Visible = op

        With Me.MT_RIF
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_CiRif.c_Largo
            .Enabled = op
        End With
        With Me.MT_CODIGO
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Comentarios.c_Largo
            .Enabled = op
        End With
        With Me.MT_NOMBRE
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_NombreCobrador.c_Largo
            .Enabled = op
        End With
        With Me.MT_DIRECCION
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Direccion.c_Largo
            .Enabled = op
        End With
        With Me.MT_CONTACTO
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_ContactarA.c_Largo
            .Enabled = op
        End With
        With Me.MT_EMAIL
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Email.c_Largo
            .Enabled = op
        End With
        With Me.MT_CEL1
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Celular_1.c_Largo
            .Enabled = op
        End With
        With Me.MT_CEL2
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Celular_2.c_Largo
            .Enabled = op
        End With
        With Me.MT_FAX1
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Fax_1.c_Largo
            .Enabled = op
        End With
        With Me.MT_FAX2
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Fax_2.c_Largo
            .Enabled = op
        End With
        With Me.MT_TEL1
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Telefono_1.c_Largo
            .Enabled = op
        End With
        With Me.MT_TEL2
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Telefono_2.c_Largo
            .Enabled = op
        End With

        With Me.MCB_TIPO_COMISION
            .DataSource = Nothing
            .Enabled = op
        End With

        With Me.MN_COMISION
            .Text = ""
            ._Formato = "999.99"
            ._ConSigno = False
            .Enabled = op
        End With
        With Me.MisGrid1
            .Enabled = op
        End With

        With Me.MT_ADVERTENCIA
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Advertencia.c_Largo
            .Enabled = op
        End With
        With Me.MT_COMENTARIOS
            .Text = ""
            .MaxLength = xfichacob.f_Cobrador.RegistroDato.c_Comentarios.c_Largo
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
        With Me.BT_GUARDA_IMAGEN
            .Enabled = op
        End With

        With Me.BT_ESTATUS
            .Enabled = op
        End With

        Me.PB_ESTATUS.Image = My.Resources.NoDefinido
        Me.PB_FOTO.Image = My.Resources.NoDefinido

        With Me.MCB_BUSQUEDA
            .DataSource = xfichacob.f_Cobrador.p_TipoBusqueda
            .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarCobrador
        End With

        Me.MT_BUSCAR.Text = ""
    End Sub

    Sub LimpiarControles()
        Me.MT_RIF.Text = ""
        Me.MT_CODIGO.Text = ""
        Me.MT_NOMBRE.Text = ""
        Me.MT_DIRECCION.Text = ""
        Me.MT_CONTACTO.Text = ""
        Me.MT_EMAIL.Text = ""
        Me.MT_CEL1.Text = ""
        Me.MT_CEL2.Text = ""
        Me.MT_FAX1.Text = ""
        Me.MT_FAX2.Text = ""
        Me.MT_TEL1.Text = ""
        Me.MT_TEL2.Text = ""

        Me.MT_COMENTARIOS.Text = ""
        Me.MT_ADVERTENCIA.Text = ""

        If MiFichaAccion = TipoAccionFicha.Adicionar Then
            Me.PB_ESTATUS.Image = My.Resources.ClienteActivo_1
        End If
    End Sub

    Sub ActivarDesactivarControles(ByVal op As Encendido)
        Me.MT_RIF.Enabled = op
        Me.MT_CODIGO.Enabled = op
        Me.MT_NOMBRE.Enabled = op
        Me.MT_DIRECCION.Enabled = op
        Me.MT_CONTACTO.Enabled = op
        Me.MT_EMAIL.Enabled = op
        Me.MT_CEL1.Enabled = op
        Me.MT_CEL2.Enabled = op
        Me.MT_FAX1.Enabled = op
        Me.MT_FAX2.Enabled = op
        Me.MT_TEL1.Enabled = op
        Me.MT_TEL2.Enabled = op

        If MiFichaAccion = TipoAccionFicha.Modificar Or MiFichaAccion = TipoAccionFicha.Consultar Or MiFichaAccion = TipoAccionFicha.Inactivo Then
            If Me.xfichacob.f_Cobrador.RegistroDato.r_EstatusFoto Then
                Me.BT_IMG_2.Enabled = op
                Me.BT_IMG_3.Enabled = op
                Me.BT_CAMARA.Enabled = op
                Me.BT_GUARDA_IMAGEN.Enabled = op

                If op = Encendido.Encender Then
                    Me.BT_IMG_1.Enabled = False
                Else
                    Me.BT_IMG_1.Enabled = op
                End If
            Else
                Me.BT_IMG_1.Enabled = op
                Me.BT_CAMARA.Enabled = op
                Me.BT_GUARDA_IMAGEN.Enabled = op
            End If
        End If

        Me.MCB_TIPO_COMISION.Enabled = op
        Me.MN_COMISION.Enabled = op

        If MiFichaAccion = TipoAccionFicha.Adicionar Or MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.BT_ESTATUS.Enabled = False
        ElseIf MiFichaAccion = TipoAccionFicha.Modificar Then
            Me.BT_ESTATUS.Enabled = op
        End If

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
            xfichacob = New DataSistema.MiDataSistema.DataSistema.FichaCobradores
            AddHandler xfichacob.CobradorNuevo, AddressOf CobradorNuevoRegistrado

            xtb_comisiones = New DataTable
            MiFichaAccion = TipoAccionFicha.Inactivo

            With MisGrid1
                .Columns.Add("col0", "Desde")
                .Columns.Add("col1", "Hasta")
                .Columns.Add("col2", "Comision(%)")

                .Columns(0).Width = 120
                .Columns(1).Width = 120
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                AddHandler .CellFormatting, AddressOf MiFormato
            End With

            If _AutoCobradorCagar <> "" Then
                CobradorNuevoRegistrado(_AutoCobradorCagar)
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

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex >= 0 Then
            e.Value = String.Format("{0:#0.00}", e.Value)
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If
    End Sub

    Private Sub FichaCobrador_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
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

    Sub CargarCombos()
        With Me.MCB_TIPO_COMISION
            .DataSource = xfichacob.f_Cobrador.p_TipoComsion
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
        End If
    End Sub

    Private Sub BT_BUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR.Click
        BusquedaCobradores()
    End Sub

    Sub BusquedaCobradores()
        If MT_BUSCAR.r_Valor <> "" Then
            Dim xsql As String = ""
            Dim xp1 As SqlParameter
            Dim xbuscar As String = ""

            Select Case CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaCobradores.TipoBusqueda)
                Case FichaCobradores.TipoBusqueda.PorNombre
                    xsql = Busqueda_1
                Case FichaCobradores.TipoBusqueda.PorRif_CI
                    xsql = Busqueda_2
                Case FichaCobradores.TipoBusqueda.PorCodigo
                    xsql = Busqueda_3
            End Select

            If MT_BUSCAR.Text.Substring(0, 1) = "*" Then
                xbuscar = "%" + MT_BUSCAR.r_Valor.Substring(1)
            Else
                xbuscar = MT_BUSCAR.r_Valor
            End If

            xp1 = New SqlParameter("@data", xbuscar + "%")
            Dim xficha As New Plantilla_2(New BusquedaCobrador, xsql, xp1)
            With xficha
                AddHandler .EnviarAuto, AddressOf CobradorNuevoRegistrado
                .ShowDialog()
            End With
            Me.MT_BUSCAR.Text = ""
        End If
        IrInicio()
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

    Sub CobradorNuevoRegistrado(ByVal xauto As String)
        Try
            xfichacob.F_BuscarCobrador(xauto)
            MostrarData()
            If MiFichaAccion = TipoAccionFicha.Adicionar Then
                MessageBox.Show("Cobrador Registrado Con Exito...", "*** Mensaje De Exito ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            MiFichaAccion = TipoAccionFicha.Consultar
        Catch ex As Exception
            MiFichaAccion = TipoAccionFicha.Inactivo
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarData()
        CargarCombos()

        Me.MT_CODIGO.Text = xfichacob.f_Cobrador.RegistroDato.r_CodigoCobrador
        Me.MT_RIF.Text = xfichacob.f_Cobrador.RegistroDato.r_CiRif
        Me.MT_NOMBRE.Text = xfichacob.f_Cobrador.RegistroDato.r_NombreCobrador
        Me.MT_DIRECCION.Text = xfichacob.f_Cobrador.RegistroDato.r_DireccionCobrador
        Me.MT_CONTACTO.Text = xfichacob.f_Cobrador.RegistroDato.r_ContactarA
        Me.MT_TEL1.Text = xfichacob.f_Cobrador.RegistroDato.r_Telefono_1
        Me.MT_TEL2.Text = xfichacob.f_Cobrador.RegistroDato.r_Telefono_2
        Me.MT_FAX1.Text = xfichacob.f_Cobrador.RegistroDato.r_Fax_1
        Me.MT_FAX2.Text = xfichacob.f_Cobrador.RegistroDato.r_Fax_2
        Me.MT_CEL1.Text = xfichacob.f_Cobrador.RegistroDato.r_Celular_1
        Me.MT_CEL2.Text = xfichacob.f_Cobrador.RegistroDato.r_Celular_2
        Me.MT_EMAIL.Text = xfichacob.f_Cobrador.RegistroDato.r_Email
        Me.MN_COMISION.Text = String.Format("{0:#0.00}", xfichacob.f_Cobrador.RegistroDato.r_ComisionPersonalizada)
        Me.MCB_TIPO_COMISION.SelectedIndex = xfichacob.f_Cobrador.RegistroDato.r_TipoComisionAsignada
        CargarTipoComision()

        Me.E_FECHA_REG.Visible = True
        Me.E_FECHA_REGISTRO.Visible = True
        Me.E_FECHA_REGISTRO.Text = xfichacob.f_Cobrador.RegistroDato.r_FechaCreacion.ToShortDateString

        If xfichacob.f_Cobrador.RegistroDato.r_EstatusCobrador = TipoEstatus.Activo Then
            Me.PB_ESTATUS.Image = My.Resources.ClienteActivo_1
        Else
            Me.PB_ESTATUS.Image = My.Resources.Inactivo_1
        End If

        Me.MT_ADVERTENCIA.Text = xfichacob.f_Cobrador.RegistroDato.c_Advertencia.c_Texto
        Me.MT_COMENTARIOS.Text = xfichacob.f_Cobrador.RegistroDato.c_Comentarios.c_Texto
    End Sub

    Private Sub BT_BUS_AVANZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUS_AVANZ.Click
        BusquedaAvanzada()
    End Sub

    Sub BusquedaAvanzada()
        Dim xficha As New BusAvanzadaCobrador
        With xficha
            AddHandler .LlamarReceptor, AddressOf ReceptorBusAvanzada
            .ShowDialog()
        End With

        If MiFichaAccion = TipoAccionFicha.Inactivo Or MiFichaAccion = TipoAccionFicha.Consultar Then
            Me.MT_BUSCAR.Select()
        End If
    End Sub

    Sub ReceptorBusAvanzada(ByVal xsql As String)
        Dim xficha As New Plantilla_2(New BusquedaCobrador, xsql)
        With xficha
            AddHandler .EnviarAuto, AddressOf CobradorNuevoRegistrado
            .ShowDialog()
        End With
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        AgregarCobrador()
    End Sub

    Sub AgregarCobrador()
        Try
            If MiFichaAccion = TipoAccionFicha.Consultar Or MiFichaAccion = TipoAccionFicha.Inactivo Then
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCobrador_Ingresar.F_Permitir()
                Try
                    MiFichaAccion = TipoAccionFicha.Adicionar
                    xfichacob.f_Cobrador.RegistroDato.LimpiarRegistro()
                Catch ex As Exception
                    MessageBox.Show("Error... " + vbCrLf + ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MT_NOMBRE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MT_NOMBRE.LostFocus
        If MiFichaAccion = TipoAccionFicha.Adicionar Then
            If Me.MT_CONTACTO.r_Valor = "" Then
                Me.MT_CONTACTO.Text = Me.MT_NOMBRE.Text
            End If
        End If
    End Sub

    Private Sub MCB_TIPO_COMISION_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_TIPO_COMISION.SelectedIndexChanged
        If MiFichaAccion = TipoAccionFicha.Adicionar Or MiFichaAccion = TipoAccionFicha.Modificar Then
            CargarTipoComision()
        End If
    End Sub

    Sub CargarTipoComision()
        Select Case CType(MCB_TIPO_COMISION.SelectedIndex, FichaCobradores.TipoComision)
            Case FichaCobradores.TipoComision.SinComision
                xtb_comisiones.Rows.Clear()
                Me.MN_COMISION.Text = "0.0"
                Me.MN_COMISION.ReadOnly = True
            Case FichaCobradores.TipoComision.ComisionGlobal
                xtb_comisiones.Rows.Clear()
                Me.MN_COMISION.Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCobrador._ComisionGlobalAsignada)
                Me.MN_COMISION.ReadOnly = True
            Case FichaCobradores.TipoComision.ComisionRango
                CargarTablaCobradores()
                Me.MN_COMISION.Text = "0.0"
                Me.MN_COMISION.ReadOnly = True
            Case FichaCobradores.TipoComision.ComisionPersonalizada
                xtb_comisiones.Rows.Clear()
                Me.MN_COMISION.Text = String.Format("{0:#0.00}", xfichacob.f_Cobrador.RegistroDato.r_ComisionPersonalizada)
                Me.MN_COMISION.ReadOnly = False
        End Select
    End Sub

    Sub CargarTablaCobradores()
        Try
            g_MiData.F_GetData("select desde,hasta,comision from comisionrango_vendcob where tipo='C' order by desde ", xtb_comisiones)
            With Me.MisGrid1
                .DataSource = xtb_comisiones
                .Columns(0).DataPropertyName = "desde"
                .Columns(1).DataPropertyName = "hasta"
                .Columns(2).DataPropertyName = "comision"

                .Ocultar(4)
                .Enabled = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        GrabarCobrador()
    End Sub

    Sub GrabarCobrador()
        If VerificarCobrador() Then
            Try
                Dim xms As String
                If MiFichaAccion = TipoAccionFicha.Adicionar Then
                    xms = "Deseas Guardar Este Registro Nuevo En El Sistema ?"
                Else
                    xms = "Deseas Guardar Los Cambios Efectuados ?"
                End If
                If MessageBox.Show(xms, "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    If MiFichaAccion = TipoAccionFicha.Adicionar Then
                        Dim xvendedor As New FichaCobradores.c_Cobrador.c_AgregarCobrador

                        With xvendedor
                            ._Adevertencia = Me.MT_ADVERTENCIA.r_Valor
                            ._Celular_1 = Me.MT_CEL1.r_Valor
                            ._Celular_2 = Me.MT_CEL2.r_Valor
                            ._Codigo = Me.MT_CODIGO.r_Valor
                            ._Comentarios = Me.MT_COMENTARIOS.r_Valor
                            ._Direccion = Me.MT_DIRECCION.r_Valor
                            ._Email = Me.MT_EMAIL.r_Valor
                            ._Fax_1 = Me.MT_FAX1.r_Valor
                            ._Fax_2 = Me.MT_FAX2.r_Valor
                            ._Nombre = Me.MT_NOMBRE.r_Valor
                            ._PersonaContacto = Me.MT_CONTACTO.r_Valor
                            ._CiRif = Me.MT_RIF.r_Valor
                            ._Telefono_1 = Me.MT_TEL1.r_Valor
                            ._Telefono_2 = Me.MT_TEL2.r_Valor
                            ._TipoComision = Me.MCB_TIPO_COMISION.SelectedIndex
                            ._Comision = Me.MN_COMISION._Valor
                        End With
                        xfichacob.F_CobradorNuevo(xvendedor)
                    End If

                    If MiFichaAccion = TipoAccionFicha.Modificar Then
                        With xRegModificar
                            ._Adevertencia = Me.MT_ADVERTENCIA.r_Valor
                            ._Automatico = xfichacob.f_Cobrador.RegistroDato.r_Automatico
                            ._Celular_1 = Me.MT_CEL1.r_Valor
                            ._Celular_2 = Me.MT_CEL2.r_Valor
                            ._CiRif = Me.MT_RIF.r_Valor
                            ._Codigo = Me.MT_CODIGO.r_Valor
                            ._Comentarios = Me.MT_COMENTARIOS.r_Valor
                            ._Direccion = Me.MT_DIRECCION.r_Valor
                            ._Email = Me.MT_EMAIL.r_Valor
                            ._Fax_1 = Me.MT_FAX1.r_Valor
                            ._Fax_2 = Me.MT_FAX2.r_Valor
                            ._IdSeguridad = xfichacob.f_Cobrador.RegistroDato.r_IdSeguridad
                            ._Nombre = Me.MT_NOMBRE.r_Valor
                            ._PersonaContacto = Me.MT_CONTACTO.r_Valor
                            ._Telefono_1 = Me.MT_TEL1.r_Valor
                            ._Telefono_2 = Me.MT_TEL2.r_Valor
                            ._TipoComision = Me.MCB_TIPO_COMISION.SelectedIndex
                            ._Comision = Me.MN_COMISION._Valor
                        End With
                        xfichacob.F_CobradorModifica(xRegModificar)
                    End If

                    RaiseEvent ActualizarFicha()
                Else
                    IniciarEnCodigo()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                IniciarEnCodigo()
            End Try
        Else
            IniciarEnCodigo()
        End If
    End Sub

    Function VerificarCobrador() As Boolean
        If Me.MT_RIF.r_Valor <> "" And Me.MT_NOMBRE.r_Valor <> "" And Me.MT_DIRECCION.r_Valor <> "" Then
            Return True
        Else
            MessageBox.Show("Error... Faltan Datos Por Completar, Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Sub IniciarEnCodigo()
        Me.MT_CODIGO.Select()
        Me.MT_CODIGO.Focus()
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarCobrador()
    End Sub

    Sub EliminarCobrador()
        Try
            If MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichacob.f_Cobrador.RegistroDato.r_Automatico <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCobrador_Eliminar.F_Permitir()

                    Try
                        If MessageBox.Show("Estas Seguro De Eliminar Esta Ficha De Cobrador ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            If xfichacob.F_CobradorElimina(xfichacob.f_Cobrador.RegistroDato.r_Automatico) Then
                                RaiseEvent ActualizarFicha()
                                MessageBox.Show("Cobrador Eliminado Con Exito...", "*** Mensaje De Exito ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                MiFichaAccion = TipoAccionFicha.Inactivo
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
        ModificarCobrador()
    End Sub

    Dim xRegModificar As FichaCobradores.c_Cobrador.c_ModificarCobrador
    Sub ModificarCobrador()
        Try
            If MiFichaAccion = TipoAccionFicha.Consultar Then
                If xfichacob.f_Cobrador.RegistroDato.r_Automatico <> "" Then
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCobrador_Modificar.F_Permitir()

                    xRegModificar = New FichaCobradores.c_Cobrador.c_ModificarCobrador
                    xRegModificar._Estatus = xfichacob.f_Cobrador.RegistroDato.r_EstatusCobrador
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

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub New(ByVal xauto As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _AutoCobradorCagar = xauto
    End Sub
End Class