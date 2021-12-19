Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient


Public Class Principal
    Dim PB_TM As Size

    Private Sub Principal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SalirDelSistema()
        e.Cancel = False
    End Sub

    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Sub MostrarHora()
        Me.E_HORA.Text = "Hora: " + Date.Now.ToLongTimeString
    End Sub

    Private Sub PB_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseEnter, PB_2.MouseEnter, PB_3.MouseEnter, PB_4.MouseEnter, _
        PB_5.MouseEnter, PB_6.MouseEnter, PB_7.MouseEnter, PB_8.MouseEnter, PB_9.MouseEnter, PB_10.MouseEnter, PB_11.MouseEnter, PB_12.MouseEnter, _
        PB_13.MouseEnter, PB_14.MouseEnter, PB_15.MouseEnter

        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseHover, PB_2.MouseHover, PB_3.MouseHover, PB_4.MouseHover, _
        PB_5.MouseHover, PB_6.MouseHover, PB_7.MouseHover, PB_8.MouseHover, PB_9.MouseHover, PB_10.MouseHover, PB_11.MouseHover, PB_12.MouseHover, _
        PB_13.MouseHover, PB_14.MouseHover, PB_15.MouseHover

        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseLeave, PB_2.MouseLeave, PB_3.MouseLeave, PB_4.MouseLeave, _
        PB_5.MouseLeave, PB_6.MouseLeave, PB_7.MouseLeave, PB_8.MouseLeave, PB_9.MouseLeave, PB_10.MouseLeave, PB_11.MouseLeave, PB_12.MouseLeave, _
        PB_13.MouseLeave, PB_14.MouseLeave, PB_15.MouseLeave

        EntrarSalirPB(sender, EntradaSalida.Salida)
    End Sub

    Sub EntrarSalirPB(ByVal sender As Object, ByVal xtipo As EntradaSalida)
        Dim PB As PictureBox = CType(sender, PictureBox)
        Dim factor As Integer = 0
        If xtipo = EntradaSalida.Entrada Then
            factor = -5
        End If

        With PB
            .Size = New Size(PB_TM.Width + factor, PB_TM.Height + factor)
            .Cursor = Cursors.Hand
        End With
    End Sub

    Private Sub Principal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Inicializa()

            If Date.Now.Date <> g_MiData.p_FechaDelMotorBD Then
                Throw New Exception("ERROR... FECHA INCORRECTA DEL EQUIPO CON RESPECTO AL MOTOR DE BASE DATOS DEL SERVIDOR")
            Else
                MessageBox.Show("Bienvenido Al Sistema... " + vbCrLf + "Presiona La Tecla Enter Para Continuar", "*** Mensaje De Bienvenida ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If Me.MenuArbol.Enabled = True Then
                    MenuArbol.SelectedNode = MenuArbol.SelectedNode.Nodes(0)
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub Inicializa()
        PB_TM = Me.PB_1.Size

        Me.Text = "+ Vsag Administrativo => Version Empresarial: " + My.Application.Info.Version.ToString
        With g_MiHora
            .Enabled = True
            .Interval = 1000
            AddHandler .Tick, AddressOf MostrarHora
        End With

        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With

        Me.E_FECHA.Text = "Hoy: " + FechaDelSistema()

        Me.E_USUARIO_CODIGO.Text = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._CodigoUsuario
        Me.E_USUARIO_GRUPO.Text = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreGrupo
        Me.E_USUARIO_NOMBRE.Text = g_MiData.f_FichaGlobal.f_Usuario.RegistroDato._NombreUsuario

        Me.E_EQUIPO_IP.Text = g_EquipoEstacion.p_EstacionIp
        Me.E_EQUIPO_NOMBRE.Text = g_EquipoEstacion.p_EstacionNombre

        Me.E_NEGOCIO_NOMBRE.Text = g_MiData.f_FichaGlobal.f_Negocio.RegistroDato.c_RazonSocial.c_Texto
        Me.E_NEGOCIO_RIF.Text = "RIF: " + g_MiData.f_FichaGlobal.f_Negocio.RegistroDato.c_RIF.c_Texto

        MostrarHora()
        CargarMiMenu()

        If g_MiData.f_FichaGlobal.f_MiInstalacion._InstalacionOk Then
            If g_MiData.f_FichaGlobal.f_MiInstalacion.RegistroDato._EstatusInstalacion = TipoEstatusInstalacion.Instalada Then
                Me.LINK_VALIDAR_CLAVE.Visible = False
                Me.E_ORIGINAL.Visible = True
            End If
        Else
            Me.MenuArbol.Enabled = False
            Dim xd As String = "Por Favor Debe Activar / Validar Su Sistema ... Gracias " + vbCrLf + "Para Mayor Informacion Comuniquese Con El Soporte Tecnico De Fox System, C.A."
            Funciones.MensajeDeAlerta(xd)
        End If
    End Sub

    Sub ActualizarDataNegocio()
        g_MiData.f_FichaGlobal.f_Negocio.F_CargarDataNegocio()
        Me.E_NEGOCIO_NOMBRE.Text = g_MiData.f_FichaGlobal.f_Negocio.RegistroDato.c_RazonSocial.c_Texto
        Me.E_NEGOCIO_RIF.Text = g_MiData.f_FichaGlobal.f_Negocio.RegistroDato.c_RIF.c_Texto
    End Sub

    Sub CargarMiMenu()
        Dim mp As TreeNode
        Me.MenuArbol.Nodes.Clear()
        mp = Me.MenuArbol.Nodes.Add("M1", "Inicio - Home")
        With mp
            .Nodes.Add("01", "Maestro De Clientes       ", 0)
            .Nodes.Add("02", "Maestro De Productos      ", 1)
            .Nodes.Add("03", "Maestro De Proveedores    ")
            .Nodes.Add("04", "Maestro De Vendedores     ")
            .Nodes.Add("05", "Maestro De Cobradores     ")
            .Nodes.Add("06", "Control De Ventas         ")
            .Nodes.Add("09", "Cuentas x Cobrar          ")
            .Nodes.Add("07", "Control Fiscal            ")

            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_TipoSistemaInstalado = TipoSistemaInstalado.Administrativo Or _
                g_MiData.f_FichaGlobal.f_ConfSistema.cnf_TipoSistemaInstalado = TipoSistemaInstalado.Full Then
                .Nodes.Add("08", "Control De Compras        ")
                .Nodes.Add("16", "Control De Gastos         ")
                .Nodes.Add("10", "Cuentas x Pagar           ")
                Me.PB_MODELOSISTEMA.Image = My.Resources.logoFullAdministrativo
            End If

            .Nodes.Add("12", "Control De Usuarios       ")
            .Nodes.Add("15", "Configuracion Dispositivos")
            .Nodes.Add("13", "Configuracion Sistema     ")
            .Nodes.Add("14", "Salida                    ")
            .Expand()
        End With
    End Sub

    Private Sub MenuArbol_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MenuArbol.AfterSelect
        Select Case Me.MenuArbol.SelectedNode.Name
            Case "M1"
                ApagarMenus()
                'MenuCero()
            Case "01"
                MenuClientes()
            Case "02"
                MenuProductos()
            Case "03"
                MenuProveedores()
            Case "04"
                MenuVendedores()
            Case "05"
                MenuCobradores()
            Case "06"
                MenuVentas()
            Case "07"
                MenuFiscal()
            Case "08"
                MenuCompras()
            Case "09"
                MenuCxC()
            Case "10"
                MenuCxP()
            Case "11"
                MenuBancos()
            Case "12"
                MenuUsuarios()
            Case "13"
                MenuConfiguracion()
            Case "14"
                MenuSalida()
            Case "15"
                MenuConfDispositivo()
            Case "16"
                MenuGastos()
        End Select
    End Sub

    Private Sub MenuArbol_BeforeCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs)
        e.Cancel = True
    End Sub

    Sub ApagarMenus()
        Me.M_CLIENTE.Visible = False
        Me.M_PROVEEDOR.Visible = False
        Me.M_PRODUCTO.Visible = False
        Me.M_VENTA.Visible = False
        Me.M_CXC.Visible = False
        Me.M_CONFIGURACION.Visible = False
        Me.M_USUARIOS.Visible = False
        Me.M_SALIDA.Visible = False
        Me.M_VENDEDOR.Visible = False
        Me.M_COBRADOR.Visible = False
        Me.M_FISCAL.Visible = False
        Me.M_COMPRAS.Visible = False
        Me.M_CXP.Visible = False
        Me.M_CONG_DISPOSITVOS.Visible = False
        Me.M_GASTOS.Visible = False
    End Sub

    Sub MenuClientes()
        ApagarMenus()

        With M_CLIENTE
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuProveedores()
        ApagarMenus()

        With M_PROVEEDOR
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuVendedores()
        ApagarMenus()

        With M_VENDEDOR
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuCobradores()
        ApagarMenus()

        With M_COBRADOR
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuProductos()
        ApagarMenus()

        With M_PRODUCTO
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuVentas()
        ApagarMenus()

        With M_VENTA
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuCxC()
        ApagarMenus()

        With M_CXC
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuCxP()
        ApagarMenus()

        With M_CXP
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuBancos()
        ApagarMenus()

        'With M_CXP
        '    .Visible = True
        '    .Select()
        '    .ShowDropDown()
        'End With
    End Sub

    Sub MenuFiscal()
        ApagarMenus()

        With M_FISCAL
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuCompras()
        ApagarMenus()

        With M_COMPRAS
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuUsuarios()
        ApagarMenus()

        With M_USUARIOS
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuConfiguracion()
        ApagarMenus()

        With M_CONFIGURACION
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuSalida()
        ApagarMenus()

        With M_SALIDA
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuConfDispositivo()
        ApagarMenus()

        With M_CONG_DISPOSITVOS
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub MenuGastos()
        ApagarMenus()

        With M_GASTOS
            .Visible = True
            .Select()
            .ShowDropDown()
        End With
    End Sub

    Sub SalirDelSistema()
        MessageBox.Show("Buena Suerte... Hasta Pronto", "*** Mensaje De Despedida ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SalirDelSistemaTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirDelSistemaTM.Click
        Me.Close()
    End Sub

    Private Sub DatosDelNegocioTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatosDelNegocioTM.Click
        DatosDelNegocio()
    End Sub

    Sub DatosDelNegocio()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_DatosNegocio.F_Permitir()
            Dim xficha As New FichaNegocio
            AddHandler xficha.ActualizarData_Evento, AddressOf ActualizarDataNegocio
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_8.Click
        LLamadaAlWeb()
    End Sub

    Sub LLamadaAlWeb()
        Dim xficha As New FichaWeb
        With xficha
            ._PaginaInicio = PaginaInicioWeb
            .ShowDialog()
        End With
    End Sub

    Private Sub TasasDeImpuestoTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TasasDeImpuestoTM.Click
        TasasFiscales()
    End Sub

    Sub TasasFiscales()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_TasasFiscales.F_Permitir()
            Dim xficha As New TasasFiscales
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub SeriesFiscalesTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeriesFiscalesTM.Click
        SeriesFiscales()
    End Sub

    Sub SeriesFiscales()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_SeriesFiscales.F_Permitir()
            Dim xficha As New SeriesFiscales
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlDeClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeClientesToolStripMenuItem.Click
        ControlClientes()
    End Sub

    Sub ControlClientes()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCliente.F_Permitir()
            Dim xficha As New FichaCliente
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ControlClientes()
    End Sub

    Private Sub ControlDeGruposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeGruposToolStripMenuItem.Click
        GrupoCliente()
    End Sub

    Sub GrupoCliente()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoCliente.F_Permitir()
            Dim xficha As New Plantilla_1(New GrupoCliente)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlDeZonasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeZonasToolStripMenuItem.Click
        ControlZonas()
    End Sub

    Sub ControlZonas()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloZonaCliente.F_Permitir()
            Dim xficha As New ZonaCliente
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        ControlProveedor()
    End Sub

    Sub ControlProveedor()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloProveedor.F_Permitir()
            Dim xficha As New FichaProveedor
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub GrupoProveedor()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoProveedor.F_Permitir()
            Dim xficha As New Plantilla_1(New GrupoProveedor)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub GRUPO_PROVEEDOR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRUPO_PROVEEDOR.Click
        GrupoProveedor()
    End Sub

    Private Sub ControlDeInventarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeInventarioToolStripMenuItem.Click
        ControlInventario()
    End Sub

    Sub ControlInventario()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario.F_Permitir()
            Dim xficha As New FichaProductos
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlDeVendedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeVendedoresToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloVendedor.F_Permitir()
            Dim xficha As New FichaVendedor
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlDeCobradoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeCobradoresToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCobrador.F_Permitir()
            Dim xficha As New FichaCobrador
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_4.Click
        'Dim xficha As New FichaCamara
        'xficha.ShowDialog()
    End Sub

    Private Sub ControlVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlVentas.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ControlVentasAdministrativa.F_Permitir()

            Dim xficha As New Plantilla_6(New ControlVenta)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlFiscalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlFiscalToolStripMenuItem.Click
        If g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Estatus Then
            Try
                g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VisorFiscal.F_Permitir()
                Dim xficha As New FichaFiscal
                With xficha
                    .ShowDialog()
                End With
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        Else
            Funciones.MensajeDeAlerta("IMPRESORA FISCAL NO DEFINIDA PARA TRABAJAR CON ESTE EQUIPO, VERIFIQUE POR FAVOR...")
        End If
    End Sub

    Private Sub ControlDePresupuestosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDePresupuestosToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ControlPresupuestos.F_Permitir()

            Dim xficha As New Plantilla_6(New ControlPresupuesto)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_14.Click
        AcercaDe()
    End Sub

    Sub AcercaDe()
        Dim xficha As New AcercaDe
        xficha.ShowDialog()
    End Sub

    Private Sub PB_11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_11.Click
        If g_MiData.f_FichaGlobal.f_MiInstalacion._InstalacionOk Then
            CompactarBd()
        Else
            Me.MenuArbol.Enabled = False
            Dim xd As String = "Por Favor Debe Activar / Validar Su Sistema ... Gracias " + vbCrLf + "Para Mayor Informacion Comuniquese Con El Soporte Tecnico De Fox System, C.A."
            MessageBox.Show(xd, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub CompactarBd()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ServicioBD_Compactar.F_Permitir()

            Dim xm As String = "Este Procedimiento Reducira El Tamano Del Archivo De Transacciones A Su Nivel Mas Bajo, Estas De Acuerdo En Efectuar Este Procedimiento ?"
            If MessageBox.Show(xm, "*** Mensaje De Alerta ***", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If g_MiData.F_CompactarBD("") Then
                    Funciones.MensajeDeOk("Procedimiento Efectuado Satisfactoriamente... Todo OK")
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_12.Click
        If g_MiData.f_FichaGlobal.f_MiInstalacion._InstalacionOk Then
            RespaldarBd()
        Else
            Me.MenuArbol.Enabled = False
            Dim xd As String = "Por Favor Debe Activar / Validar Su Sistema ... Gracias " + vbCrLf + "Para Mayor Informacion Comuniquese Con El Soporte Tecnico De Fox System, C.A."
            MessageBox.Show(xd, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub RespaldarBd()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ServicioBD_Respaldar.F_Permitir()

            If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaRespaldoBD <> "" Then
                Dim xm As String = "Este Procedimiento Permite Respaldar La Base De Datos En La Ruta Establecida Por El Administrador, Estas De Acuerdo En Efectuar Este Procedimiento ?"
                If MessageBox.Show(xm, "*** Mensaje De Alerta ***", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    If g_MiData.F_RespaldarBD(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaRespaldoBD) Then
                        Funciones.MensajeDeOk("Procedimiento Efectuado Satisfactoriamente... Todo OK")
                    End If
                End If
            Else
                Funciones.MensajeDeAlerta("Problema... Debes Especificar La Ruta Donde Se Realizara El Respado !!!")
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlDeNotasDeEntregaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeNotasDeEntregaToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ControlNotasEntrega.F_Permitir()

            Dim xficha As New Plantilla_6(New ControlNotaEntrega)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlDePedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDePedidosToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ControlPedidos.F_Permitir()

            Dim xficha As New Plantilla_6(New ControlPedido)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub AdministradorDeDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministradorDeDocumentosToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_AdmDocumentos_Ventas.F_Permitir()

            Dim xficha As New AdmDocumentos(New AdmDoc_Ventas(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_AdmDocumentos))
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub NotasDeCreditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotasDeCreditToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ControlNotasCredito_Ventas.F_Permitir()

            Dim xficha As New Plantilla_10(New NotaCredito_Ventas)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RetencionesDeIvaEnVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetencionesDeIvaEnVentasToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ControlRetencionesIva_Ventas.F_Permitir()

            Dim xficha As New PlantillaRetencionIva(New RetencionIva_Venta)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AdministradorDeDocumentosDeRetencionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministradorDeDocumentosDeRetencionesToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_AdmDocumentosRetenciones_Ventas.F_Permitir()

            Dim xficha As New AdmRetenciones(New AdmRet_Ventas)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ControlGrupoUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlGrupoUsuarios.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoUsuario.F_Permitir()

            Dim xForm As New Plantilla_1(New GrupoUsuario)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ControlDeDepartamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeDepartamentosToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Depart.F_Permitir()

            Dim xForm As New Plantilla_1(New ProductosDepartamento)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ControlDeMarcasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeMarcasToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Marca.F_Permitir()

            Dim xForm As New Plantilla_1(New ProductosMarcas)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReporteFiscal_AgrupadoMaquina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteFiscal_AgrupadoMaquina.Click
        '(reporte1)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReportesVentasResumen(.p_FechaDesde, .p_FechaHasta, "reporte1")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReporteFiscal_PorFechaAgrupadoPorMaquina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteFiscal_PorFechaAgrupadoPorMaquina.Click
        '(reporte2)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReportesVentasResumen(.p_FechaDesde, .p_FechaHasta, "reporte2")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReporteFiscal_PorMaquina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteFiscal_PorMaquina.Click
        '(reporte3)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReportesVentasResumen(.p_FechaDesde, .p_FechaHasta, "reporte3")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReporteDetalladoAgrupadoPorMaquina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDetalladoAgrupadoPorMaquina.Click
        '(reporte4)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReportesVentasDetallado(.p_FechaDesde, .p_FechaHasta, "reporte4")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReporteDetalladoAgrupadoPorFechaMaquina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDetalladoAgrupadoPorFechaMaquina.Click
        '(reporte5)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReportesVentasDetallado(.p_FechaDesde, .p_FechaHasta, "reporte5")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReporteDetalladoPorMaquina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDetalladoPorMaquina.Click
        '(reporte6)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReportesVentasDetallado(.p_FechaDesde, .p_FechaHasta, "reporte6")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DetalleContribuyenteNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleContribuyenteNo.Click
        '(reporte7)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReporteContribuyenteNoContribuyentes(.p_FechaDesde, .p_FechaHasta, "reporte7")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DetalleContribuyenteNoLeyenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleContribuyenteNoLeyenda.Click
        '(reporte8)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReporteContribuyenteNoContribuyentes(.p_FechaDesde, .p_FechaHasta, "reporte9")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DetalleContribuyenteNoAgrupadoFechaMaquinaLeyenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleContribuyenteNoAgrupadoFechaMaquinaLeyenda.Click
        '(reporte9)
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReporteContribuyenteNoContribuyentes(.p_FechaDesde, .p_FechaHasta, "reporte10")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ProductoDepositos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductoDepositos.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Deposito.F_Permitir()

            Dim xForm As New Plantilla_11(New Depositos)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ProductoConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductoConcepto.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Concepto.F_Permitir()
            Dim xForm As New Plantilla_11(New ProductosConcepto)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ProductosMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosMedida.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Medida.F_Permitir()
            Dim xForm As New Plantilla_11(New ProductosMedida)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlUsuarios.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloUsuario.F_Permitir()
            Dim xForm As New FichaUsuario
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub DeptoPtoVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeptoPtoVenta.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_DeptoPtoVenta.F_Permitir()
            Dim xForm As New DeptoPtoVenta
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub GruposSubGruposProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GruposSubGruposProductos.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_GrupoSubGrupo.F_Permitir()
            Dim xForm As New GrupoProductos
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub CXC_CONTROL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CXC_CONTROL.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxCobrar_ControlCuentas.F_Permitir()
            Dim xForm As New ControlCuentas(New ControlCxC)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub CXC_ADM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CXC_ADM.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxCobrar_AdministradorDocumentos.F_Permitir()
            Dim xForm As New AdmControlCuentas(New c_AdmControlCxC)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub RelacionDeDocumentosPorCobrarAClientes_CXC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelacionDeDocumentosPorCobrarAClientes_CXC.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxCobrar_Reportes_DocumentosCobrar.F_Permitir()
            Dim xficha As New PlantillaFiltroReportesCxC(New ReporteCxC_DocumentosPorCobrar)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub RelacionDeCobranzaDiaria_CXC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelacionDeCobranzaDiaria_CXC.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxCobrar_Reportes_CobranzaDiaria.F_Permitir()
            Dim xficha As New PlantillaFiltroReportesCxC(New ReporteCxC_CobranzaDiaria)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PagosEmitidosDelCliente_CXC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagosEmitidosDelCliente_CXC.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxCobrar_Reportes_PagosEmitidos.F_Permitir()
            Dim xficha As New PlantillaFiltroReportesCxC(New ReporteCxC_PagosEmitidos)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub AnalisisDeVencimiento_CXC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalisisDeVencimiento_CXC.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxCobrar_Reportes_AnalisiVencimiento.F_Permitir()
            Dim xficha As New PlantillaFiltroReportesCxC(New ReporteCxC_AnalisisVencimiento)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReporteGeneralDocumentosDeVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteGeneralDocumentosDeVentasToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_DocumentosGeneral.F_Permitir()
            Dim xficha As New PlantillaFiltroReporteVentas(New ReporteVentas_DocumentoGeneral)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReporteConsolidadoDeDocumentosDeVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteConsolidadoDeDocumentosDeVentasToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_Consolidado.F_Permitir()
            Dim xficha As New PlantillaFiltroReporteVentas(New ReporteVentas_Consolidado)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReporteGeneralDeVebntasPorDepartamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteGeneralDeVebntasPorDepartamentosToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_PorDepartamento.F_Permitir()
            Dim xficha As New PlantillaFiltroReporteVentas(New ReporteVentas_Departamento)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReporteGenerealDeVentasPorGruposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteGenerealDeVentasPorGruposToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_PorGrupo.F_Permitir()
            Dim xficha As New PlantillaFiltroReporteVentas(New ReporteVentas_PorGrupo)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReporteUtilidadEnVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteUtilidadEnVentasToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_Utilidad.F_Permitir()

            Dim xficha As New PlantillaFiltroReporteVentas(New ReporteVentas_UtilidadVentas)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfiguracionDeModulosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ConfiguracionDeModulosToolStripMenuItem.Click, PB_5.Click

        If g_MiData.f_FichaGlobal.f_MiInstalacion._InstalacionOk Then
            ConfSistema()
        Else
            Me.MenuArbol.Enabled = False
            Dim xd As String = "Por Favor Debe Activar / Validar Su Sistema ... Gracias " + vbCrLf + "Para Mayor Informacion Comuniquese Con El Soporte Tecnico De Fox System, C.A."
            Funciones.MensajeDeAlerta(xd)
        End If
    End Sub

    Sub ConfSistema()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_Configuracion.F_Permitir()
            Dim xficha As New ModuloConfiguracionSistema
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReportesCliente(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaestroDeClientesDatosDeContacto.Click, _
          MaestroDeClientesDatosComerciales.Click, EstadoDeCuentaDelCliente.Click, RetencionesDeIvaAClientes.Click, REP_CLIENTE_ANTICIPOS_NC_PENDIENTE.Click

        Try
            Dim xficha As PlantillaFiltroReportesClientes = Nothing
            Dim xop As String = CType(sender, ToolStripMenuItem).Name
            Select Case xop
                Case "MaestroDeClientesDatosDeContacto"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteCliente_DatosContacto.F_Permitir()
                    xficha = New PlantillaFiltroReportesClientes(New ReporteClientes_DatosContacto)
                Case "MaestroDeClientesDatosComerciales"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteCliente_DatosComerciales.F_Permitir()
                    xficha = New PlantillaFiltroReportesClientes(New ReporteClientes_DatosComerciales)
                Case "EstadoDeCuentaDelCliente"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteCliente_EstadoCuenta.F_Permitir()
                    xficha = New PlantillaFiltroReportesClientes(New ReporteClientes_EstadoCuenta)
                Case "RetencionesDeIvaAClientes"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteCliente_RetencionesIva.F_Permitir()
                    xficha = New PlantillaFiltroReportesClientes(New ReporteClientes_RetencionesIva)
                Case "REP_CLIENTE_ANTICIPOS_NC_PENDIENTE"
                    'g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteCliente_RetencionesIva.F_Permitir()
                    xficha = New PlantillaFiltroReportesClientes(New AnticiposNCPendientes)
            End Select

            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReportesProveedor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROV_DATOS_CONTACTO.Click, PROV_DATOS_COMERCIALES.Click, _
               PROV_EDO_CUENTA.Click, PROV_RETENCIONES.Click
        Try
            Dim xficha As PlantillaFiltroReportesProveedores = Nothing
            Dim xop As String = CType(sender, ToolStripMenuItem).Name
            Select Case xop
                Case "PROV_DATOS_CONTACTO"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteProveedor_DatosContacto.F_Permitir()
                    xficha = New PlantillaFiltroReportesProveedores(New ReporteProveedores_DatosContacto)
                Case "PROV_DATOS_COMERCIALES"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteProveedor_DatosComerciales.F_Permitir()
                    xficha = New PlantillaFiltroReportesProveedores(New ReporteProveedores_DatosComerciales)
                Case "PROV_EDO_CUENTA"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteProveedor_EstadoCuenta.F_Permitir()
                    xficha = New PlantillaFiltroReportesProveedores(New ReporteProveedores_EstadoCuenta)
                Case "PROV_RETENCIONES"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteProveedor_RetencionesIva.F_Permitir()
                    xficha = New PlantillaFiltroReportesProveedores(New ReporteProveedores_RetencionesIva)
            End Select

            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlPermisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlPermisos.Click, PB_6.Click
        If g_MiData.f_FichaGlobal.f_MiInstalacion._InstalacionOk Then
            PermisosUsuario()
        Else
            Me.MenuArbol.Enabled = False
            Dim xd As String = "Por Favor Debe Activar / Validar Su Sistema ... Gracias " + vbCrLf + "Para Mayor Informacion Comuniquese Con El Soporte Tecnico De Fox System, C.A."
            MessageBox.Show(xd, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub PermisosUsuario()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoUsuario_Permisos.F_Permitir()
            Dim xficha As New UsuariosPermiso
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlMediosDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlMediosDePagoToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloMedioPago.F_Permitir()
            Dim xficha As New Plantilla_12(New MediosPago)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReportesInventario(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REPORTE_INV_DATOS_ARTICULO.Click, REPORTE_INV_LISTA_PRECIOS.Click, _
      REPORTE_INV_EXISTENCIA.Click, REPORTE_INV_PRECIOS_INV.Click, REPORTE_INV_KARDEX.Click, _
      REPORTE_INV_VALORIZACION.Click, REPORTE_INV_MOVIMINETO_CONCEPTO.Click, REPORTE_INV_PROYECCION.Click, _
      REPORTE_INV_SENIAT.Click, REPORTE_INV_MOVIMIENTO.Click, REPORTE_INV_EXISTENCIA_PRECIO.Click, _
      ACTUALIZACION_PRECIOS_VENTA.Click

        Try
            Dim xficha As PlantillaFiltroReportesInventario = Nothing
            Dim xop As String = CType(sender, ToolStripMenuItem).Name
            Select Case xop
                Case "REPORTE_INV_DATOS_ARTICULO"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteInventario_MaestroDatos.F_Permitir()
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_DatosArticulo)
                Case "REPORTE_INV_LISTA_PRECIOS"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteInventario_ListaPrecio.F_Permitir()
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_ListaPrecios)
                Case "REPORTE_INV_EXISTENCIA"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteInventario_Existencia.F_Permitir()
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_ExistenciasDeposito)
                Case "REPORTE_INV_PRECIOS_INV"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteInventario_PrecioInventario.F_Permitir()
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_PreciosArticulo)
                Case "REPORTE_INV_KARDEX"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloInventario_Kardex.F_Permitir()
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_Kardex)
                Case "REPORTE_INV_VALORIZACION"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteInventario_Valorizacion.F_Permitir()
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_Valorizacion)
                Case "REPORTE_INV_MOVIMINETO_CONCEPTO"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteInventario_MovimientoPorConcepto.F_Permitir()
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_MovimientoConcepto)
                Case "REPORTE_INV_PROYECCION"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteInventario_ProyeccionVenta.F_Permitir()
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_Proyeccion)
                Case "REPORTE_INV_SENIAT"
                    'g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteInventario_ProyeccionVenta.F_Permitir()
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_Seniat)
                Case "REPORTE_INV_MOVIMIENTO"
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_Movimiento)
                Case "REPORTE_INV_EXISTENCIA_PRECIO"
                    xficha = New PlantillaFiltroReportesInventario(New ReporteInventario_PreciosArticulo_Existencia)

                Case "ACTUALIZACION_PRECIOS_VENTA"
                    xficha = New PlantillaFiltroReportesInventario(New ActualizacionPrecios_Grupo)
            End Select

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReporteVendedores(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaestroVendedores.Click, ReporteComisionVendedores.Click _
                     , COMISIONES_DETALLE.Click
        Try
            Dim xficha As PlantillaFiltroReportesVend_Cobr = Nothing
            Dim xop As String = CType(sender, ToolStripMenuItem).Name
            Select Case xop
                Case "MaestroVendedores"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVendedor_Maestro.F_Permitir()
                    xficha = New PlantillaFiltroReportesVend_Cobr(New ReporteVendedores_DatosContacto)
                Case "ReporteComisionVendedores"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVendedor_Comisiones.F_Permitir()
                    xficha = New PlantillaFiltroReportesVend_Cobr(New ReporteVendedores_Comisiones)
                Case "COMISIONES_DETALLE"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVendedor_ComisionesVentasDetalle.F_Permitir()
                    xficha = New PlantillaFiltroReportesVend_Cobr(New ReporteVendedores_ComisionesVentasDetalle)
            End Select

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub TablaComisionVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TablaComisionVendedor.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloVendedor_TablaComisiones.F_Permitir()
            Dim xficha As New Plantilla_13(New TablaVendedor)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReporteCobradores(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaestroCobradores.Click, ReporteComisionesCobradores.Click
        Try
            Dim xficha As PlantillaFiltroReportesVend_Cobr = Nothing
            Dim xop As String = CType(sender, ToolStripMenuItem).Name
            Select Case xop
                Case "MaestroCobradores"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteCobrador_Maestro.F_Permitir()
                    xficha = New PlantillaFiltroReportesVend_Cobr(New ReporteCobradores_DatosContacto)
                Case "ReporteComisionesCobradores"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteCobrador_Comisiones.F_Permitir()
                    xficha = New PlantillaFiltroReportesVend_Cobr(New ReporteCobradores_Comisiones)
            End Select

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub TablaComisionesCobrador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TablaComisionesCobrador.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCobrador_TablaComisiones.F_Permitir()
            Dim xficha As New Plantilla_13(New TablaCobrador)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_13.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_Consolidado.F_Permitir()

            Throw New Exception("Sitio Web No Encontrado / Opcion No Activada")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PB_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_9.Click
        If g_MiData.f_FichaGlobal.f_MiInstalacion._InstalacionOk Then
            MisReportesRapidos()
        Else
            Me.MenuArbol.Enabled = False
            Dim xd As String = "Por Favor Debe Activar / Validar Su Sistema ... Gracias " + vbCrLf + "Para Mayor Informacion Comuniquese Con El Soporte Tecnico De Fox System, C.A."
            MessageBox.Show(xd, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub MisReportesRapidos()
        Dim xficha As New ReportesVarios
        With xficha
            .ShowDialog()
        End With
    End Sub

    Private Sub ALM_HABLADORES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALM_HABLADORES.Click
        Dim xficha As New Habladores
        With xficha
            .ShowDialog()
        End With
    End Sub

    Private Sub PB_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_2.Click
        Dim xficha As New DataSistema.AgendaTelefonica(g_ConstructorCadena.ConnectionString)
        xficha.Show()
    End Sub

    Private Sub ComprasNacionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComprasNacionales.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_ControlCompra.F_Permitir()
            Dim xficha As New Plant_Compra_1(New ControlComprasNacionales)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ORDENCOMPRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ORDENCOMPRA.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_OrdenCompra.F_Permitir()
            Dim xficha As New Plant_Compra_1(New ControlOrdenesCompra)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ADMCOMPRAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADMCOMPRAS.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_AdmDocumentos.F_Permitir()
            Dim xficha As New AdmDocumentosCompras(New AdmDoc_Compras(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCompras._Limite_Renglones_AdmDocumentos, 0))
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReportesCompras(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMP_SENIAT.Click, COMP_GENERAL.Click, COMP_DEPART.Click, _
                                                                                                    COMP_GRUPO.Click, COMP_RETENCIONES.Click, COMP_CONCEPTO.Click

        Try
            Dim xficha As PlantillaFiltroReporteCompras = Nothing
            Dim xop As String = CType(sender, ToolStripMenuItem).Name
            Select Case xop
                Case "COMP_SENIAT"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompras_Reportes_LibroCompra.F_Permitir()
                    xficha = New PlantillaFiltroReporteCompras(New ReporteCompras_LibroCompras)
                Case "COMP_GENERAL"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompras_Reportes_GeneralCompras.F_Permitir()
                    xficha = New PlantillaFiltroReporteCompras(New ReporteCompras_General)
                Case "COMP_DEPART"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompras_Reportes_PorDepartamentos.F_Permitir()
                    xficha = New PlantillaFiltroReporteCompras(New ReporteCompras_GeneralDepartamento)
                Case "COMP_GRUPO"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompras_Reportes_PorGrupos.F_Permitir()
                    xficha = New PlantillaFiltroReporteCompras(New ReporteCompras_GeneralGrupo)
                Case "COMP_RETENCIONES"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompras_Reportes_Retenciones.F_Permitir()
                    xficha = New PlantillaFiltroReporteCompras(New ReporteCompras_RetencionesIva)
                Case "COMP_CONCEPTO"
                    'g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompras_Reportes_Retenciones.F_Permitir()
                    xficha = New PlantillaFiltroReporteCompras(New ReporteCompras_Concepto)
            End Select

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub GENERARTXT_COMPRAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERARTXT_COMPRAS.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompras_GenerarTxT.F_Permitir()
            Dim xficha As New PlantillaFiltroGenerarRetenciones(New c_GenerarRetencionesIva)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub RETENCIONESCOMPRAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETENCIONESCOMPRAS.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_Retenciones.F_Permitir()
            Dim xficha As New PlantillaRetencionIvaCompras(New RetencionIva_Compra())
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ADMRETENCIONES_COMPRAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADMRETENCIONES_COMPRAS.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_AdmRetenciones.F_Permitir()
            Dim xficha As New AdmRetencionesCompras(New AdmRet_Compras)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub COMPRAS_PRECIOSVENTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMPRAS_PRECIOSVENTA.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_ActualizarPreciosVentas.F_Permitir()
            Dim xficha As New AdmDocumentosCompras(New AdmDoc_CostosCompras(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCompras._Limite_Renglones_AdmDocumentos), False, False, False)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub NCCOMPRAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NCCOMPRAS.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_ControlNotasCredito.F_Permitir()
            Dim xficha As New Plantilla_15(New NotaCredito_Compras)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub CONTROLCXP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTROLCXP.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxPagar_ControlCuentas.F_Permitir()
            Dim xficha As New ControlCuentasxPagar(New c_ControlCxP)
            With xficha
                .showdialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ADMCXP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ADMCXP.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxPagar_AdministradorDocumentos.F_Permitir()
            Dim xficha As New AdmControlCuentas(New c_AdmControlCxP)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ReportesCuentasxPagar(ByVal sender As Object, ByVal e As System.EventArgs) Handles REP_CXP.Click, REP_PAGOS_CXP.Click, REP_ANALISIS_CXP.Click
        Try
            Dim xficha As PlantillaFiltroReporteCxP = Nothing
            Dim xop As String = CType(sender, ToolStripMenuItem).Name
            Select Case xop
                Case "REP_CXP"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxPagar_Reportes_DocumentosxPagar.F_Permitir()
                    xficha = New PlantillaFiltroReporteCxP(New ReporteCxP_DocumentosPorPagar)
                Case "REP_PAGOS_CXP"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxPagar_Reportes_PagosEmitidos.F_Permitir()
                    xficha = New PlantillaFiltroReporteCxP(New ReporteCxP_PagosEmitidos)
                Case "REP_ANALISIS_CXP"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCxPagar_Reportes_AnalisiVencimiento.F_Permitir()
                    xficha = New PlantillaFiltroReporteCxP(New ReporteCxP_AnalisisVencimiento)
            End Select

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub COMPRASGASTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMPRASGASTOS.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCompra_ControlCompraGastos.F_Permitir()
            Dim xficha As New ProcesarGastos(New c_ProcesarGastos)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        g_MiCalculadora = New MiCalculadora.Calc
        g_MiCalculadora.Show()
    End Sub

    Private Sub RPT_GENERAL_VENTAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPT_GENERAL_VENTAS.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()
            Dim xForm As New PlantillaReporte_1
            With xForm
                .ShowDialog()
                If Not .p_EscapePantalla Then
                    If (.p_FechaDesde.ToString) <> "" And (.p_FechaHasta.ToString) <> "" Then
                        EjecutarReportesGeneralVentas(.p_FechaDesde, .p_FechaHasta, "reporte0")
                    End If
                End If
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ControlDispositivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDispositivos.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloCnfDispositivo.F_Permitir()
            Dim xficha As New DispositivoSistemaCnf
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub LINK_VALIDAR_CLAVE_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LINK_VALIDAR_CLAVE.LinkClicked
        Dim xficha As New ClaveRegistro
        Dim xver As String = ""
        With xficha
            .ShowDialog()
            xver = ._ClaveRetornar
        End With
        If xver = "" Then
        Else
            Try
                g_MiData.f_FichaGlobal.f_MiInstalacion.F_VerificarClaveInstalacion(xver, g_MiData.f_FichaGlobal.f_Negocio.RegistroDato._RIF)
                Funciones.MensajeDeOk("VALIDACION REALIZADA SATISFACTORIAMENTE... SISTEMA VERIFICADO Y APROBADO")
                Me.E_ORIGINAL.Visible = True
                Me.LINK_VALIDAR_CLAVE.Visible = False
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub EST_VENT_MENSUALES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EST_VENT_MENSUALES.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_Estadistico.F_Permitir()

            Dim xForm As New PlantillaFiltroReporteVentas(New REP_ESTADISTICA_VENTAS_MENSUAL)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub EST_VENTA_DEPART_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EST_VENTA_DEPART.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_Estadistico.F_Permitir()

            Dim xForm As New PlantillaFiltroReporteVentas(New REP_ESTADISTICA_VENTAS_DEPARTAMENTOS)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub EST_VENT_GRUPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EST_VENT_GRUPO.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_Estadistico.F_Permitir()

            Dim xForm As New PlantillaFiltroReporteVentas(New REP_ESTADISTICA_VENTAS_GRUPOS)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub AnalisisDeDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalisisDeDocumentosToolStripMenuItem.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_Estadistico.F_Permitir()

            Dim xForm As New PlantillaFiltroReporteVentas(New REP_ESTADISTICA_ANALISIS_DOCUMENTOS)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub CONCEPTOS_GASTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONCEPTOS_GASTOS.Click
        ConceptosGastos()
    End Sub

    Sub ConceptosGastos()
        Dim xtipo As New GastosConceptos
        Dim xficha As New Def_ConceptosGastos(xtipo)
        With xficha
            .ShowDialog()
        End With
    End Sub

    Private Sub USUARIO_VINCULO_VENDEDOR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USUARIO_VINCULO_VENDEDOR.Click
        Dim xficha As New VinculoUsuarioVendedor
        With xficha
            .showdialog()
        End With
    End Sub

    Private Sub ReporteRetencionesVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteRetencionesVentas.Click
        Try
            'g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_LibroSeniat.F_Permitir()

            Dim xForm As New PlantillaReporte_1
            AddHandler xForm._ReportePeriodo, AddressOf RetencionesPeriodo
            AddHandler xForm._ReporteFecha, AddressOf RetencionesFecha
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub RetencionesPeriodo(ByVal xmes As Integer, ByVal xano As Integer)
        Try
            Dim xp1 As New SqlParameter("@ano", xano)
            Dim xp2 As New SqlParameter("@mes", xmes)
            Dim xsql_1 As String = "select documento,fecha,nombre,ci_rif, exento, base, impuesto, " & _
                                    "total, tasa_retencion, retencion, fecha_relacion from retenciones_ventas " & _
                                    "where ano_relacion = @ano and mes_relacion=@mes order by auto"
            Dim xsql_2 As String = "select nombre, rif from empresa"

            Dim xds As New DataSet
            Dim xtb1 As New DataTable("RetencionesVentas")
            Dim xtb2 As New DataTable("Empresa")
            g_MiData.F_GetData(xsql_1, xtb1, xp1, xp2)
            g_MiData.F_GetData(xsql_2, xtb2)

            xds.Tables.Add(xtb1)
            xds.Tables.Add(xtb2)

            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xlist.Add(New _Reportes.ParamtCrystal("@MES", xmes))
            xlist.Add(New _Reportes.ParamtCrystal("@ANO", xano))
            xrep += "RET_VENTAS.rpt"

            Dim xficha As New _Reportes(xds, xrep, xlist)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub RetencionesFecha(ByVal xdesde As Date, ByVal xhasta As Date)
        Try
            Dim xp1 As New SqlParameter("@DESDE", xdesde)
            Dim xp2 As New SqlParameter("@HASTA", xhasta)
            Dim xsql_1 As String = "select documento,fecha,nombre,ci_rif, exento, base, impuesto, " & _
                                    "total, tasa_retencion, retencion, fecha_relacion from retenciones_ventas " & _
                                    "where FECHA>=@DESDE and FECHA<=@HASTA  order by auto"
            Dim xsql_2 As String = "select nombre, rif from empresa"

            Dim xds As New DataSet
            Dim xtb1 As New DataTable("RetencionesVentas")
            Dim xtb2 As New DataTable("Empresa")
            g_MiData.F_GetData(xsql_1, xtb1, xp1, xp2)
            g_MiData.F_GetData(xsql_2, xtb2)

            xds.Tables.Add(xtb1)
            xds.Tables.Add(xtb2)

            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xlist.Add(New _Reportes.ParamtCrystal("@DESDE", xdesde))
            xlist.Add(New _Reportes.ParamtCrystal("@HASTA", xhasta))
            xrep += "RET_VENTAS_FECHA.rpt"

            Dim xficha As New _Reportes(xds, xrep, xlist)
            With xficha
                .Show()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub SUBCONCEPTOS_GASTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUBCONCEPTOS_GASTOS.Click
        Dim xtipo As New GastosSubConceptos
        Dim xficha As New Def_ConceptosGastos(xtipo)
        With xficha
            .ShowDialog()
        End With
    End Sub

    Private Sub ENTRADA_GASTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRADA_GASTOS.Click
        Me.Hide()

        Dim xficha As New FichaGasto
        With xficha
            .ShowDialog()
        End With

        Me.Show()
    End Sub

    Private Sub ControlAgenciasBancarias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlAgenciasBancarias.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloAgenciaBancaria.F_Permitir()

            Dim xficha As New Plantilla_1(New Agencias)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub MONITOR_POS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MONITOR_POS.Click
        Me.Hide()

        Dim xficha As New AdmJornadas
        With xficha
            .ShowDialog()
        End With

        Me.Show()
    End Sub


    Private Sub ReporteResumenCuadreVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteResumenCuadreVentas.Click, _
            RPT_FACTURAS_DETALLADAS.Click
        Try
            Dim xficha As PlantillaFiltroReporteVentas = Nothing
            Dim xop As String = CType(sender, ToolStripMenuItem).Name.Trim.ToUpper
            Select xop
                Case "REPORTERESUMENCUADREVENTAS"
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_ResumenCuadre.F_Permitir()
                    xficha = New PlantillaFiltroReporteVentas(New ReporteVentas_CuadroResumen)
                Case "RPT_FACTURAS_DETALLADAS"
                    'g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ReporteVentas_ResumenCuadre.F_Permitir()
                    xficha = New PlantillaFiltroReporteVentas(New ReporteVentas_FacturasDetalladas)
            End Select

            If xficha IsNot Nothing Then
                With xficha
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub PB_15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_15.Click
        If g_MiData.f_FichaGlobal.f_MiInstalacion._InstalacionOk Then
            MantenimientoBD()
        Else
            Me.MenuArbol.Enabled = False
            Dim xd As String = "Por Favor Debe Activar / Validar Su Sistema ... Gracias " + vbCrLf + "Para Mayor Informacion Comuniquese Con El Soporte Tecnico De Fox System, C.A."
            Funciones.MensajeDeError(xd)
        End If
    End Sub

    Sub MantenimientoBD()
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ServicioBD_Mantenimiento.F_Permitir()

            Dim xm As String = "Este Procedimiento Puede Demorar Un Poco, Por Lo Tanto Se Recomienda Que Ningun Usuario Este Usando El Sistema, Estas De Acuerdo En Efectuar Este Procedimiento ?"
            If MessageBox.Show(xm, "*** Mensaje De Alerta ***", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If g_MiData.F_MantenimientoBD() Then
                    Funciones.MensajeDeOk("Procedimiento Efectuado Satisfactoriamente... Todo OK")
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub FACTURAS_COBRADAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FACTURAS_COBRADAS.Click
        Try
            Dim xficha As New PlantillaFiltroReportesCxC(New ReporteCxC_FacturasCobradas)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ANTICIPIOS_NC_FAVOR_CLIENTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ANTICIPIOS_NC_FAVOR_CLIENTE.Click
        Try
            Dim xficha As New PlantillaFiltroReportesCxC(New ReporteCxC_ClientesConAnticiposNC)
            With xficha
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub M_CLIENTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M_CLIENTE.Click

    End Sub

    Private Sub PB_1_Click(sender As Object, e As EventArgs) Handles PB_1.Click
        ActualizarTasaActualDollar()
    End Sub


    Private _gestion As Gestion

    Private Sub ActualizarTasaActualDollar()
        _gestion.ActualizarTasaActualDollar()
    End Sub

    Sub setGestion(gestion As Gestion)
        _gestion = gestion
    End Sub

End Class