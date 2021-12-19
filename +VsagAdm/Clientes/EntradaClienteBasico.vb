Imports DataSistema.MiDataSistema.DataSistema

Public Class EntradaClienteBasico
    Event ActualizarFichaCliente(ByVal xauto As String)

    Dim xestatus_salida As Boolean
    Dim xcliente As FichaClientes

    Property _EstatusSalida() As Boolean
        Get
            Return xestatus_salida
        End Get
        Set(ByVal value As Boolean)
            xestatus_salida = value
        End Set
    End Property

    Private Sub EntradaClienteBasico_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _EstatusSalida = True Then
            e.Cancel = False
        Else
            If MessageBox.Show("Estas Seguro De Salir Sin Guardar Estos Datos ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub EntradaClienteBasico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub EntradaClienteBasico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub EntradaClienteBasico_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub LimpiarFicha()
        Me.MT_RIF.Text = ""
        With Me.MT_RIF
            .Text = ""
            .MaxLength = xcliente.f_Clientes.RegistroDato.c_NombreRazonSocial.c_Largo
        End With
        With Me.MT_NOMBRE
            .Text = ""
            .MaxLength = xcliente.f_Clientes.RegistroDato.c_NombreRazonSocial.c_Largo
        End With
        With Me.MT_DIR
            .Text = ""
            .MaxLength = xcliente.f_Clientes.RegistroDato.c_DirFiscal.c_Largo
        End With
        With Me.MT_CONTACTO
            .Text = ""
            .MaxLength = xcliente.f_Clientes.RegistroDato.c_ContactarA.c_Largo
        End With
        With Me.MT_EMAIL
            .Text = ""
            .MaxLength = xcliente.f_Clientes.RegistroDato.c_Email.c_Largo
        End With
        With Me.MT_TELEFONO
            .Text = ""
            .MaxLength = xcliente.f_Clientes.RegistroDato.c_Telefono_1.c_Largo
        End With
    End Sub

    Sub Inicializa()
        Try
            _EstatusSalida = False
            xcliente = New FichaClientes
            AddHandler xcliente.ClienteNuevo, AddressOf ActualizarDatos
            LimpiarFicha()

            Me.MT_RIF.Select()
            Me.MT_RIF.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarDatos(ByVal xauto As String)
        RaiseEvent ActualizarFichaCliente(xauto)
    End Sub

    Private Sub MT_RIF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MT_RIF.KeyDown
        If e.KeyData = Keys.Escape Then
            e.SuppressKeyPress = True
            Me.MT_RIF.Text = ""
            _EstatusSalida = True
            Me.Close()
        End If
    End Sub

    Private Sub MT_RIF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MT_RIF.LostFocus
        Dim xop As Boolean = True

        If Me.MT_RIF.r_Valor <> "" Then
            Try
                xcliente.F_BuscarRif(Me.MT_RIF.r_Valor)
                Me.MT_NOMBRE.Text = xcliente.f_Clientes.RegistroDato.r_NombreRazonSocial
                Me.MT_DIR.Text = xcliente.f_Clientes.RegistroDato.r_DirFiscal
                Me.MT_EMAIL.Text = xcliente.f_Clientes.RegistroDato.r_Email
                Me.MT_CONTACTO.Text = xcliente.f_Clientes.RegistroDato.r_ContactarA
                Me.MT_TELEFONO.Text = xcliente.f_Clientes.RegistroDato.r_Telefono_1
                xop = True
                _EstatusSalida = True
                RaiseEvent ActualizarFichaCliente(xcliente.f_Clientes.RegistroDato.r_Automatico)
                Me.Close()
            Catch ex As Exception
                Me.MT_NOMBRE.Text = ""
                Me.MT_DIR.Text = ""
                Me.MT_CONTACTO.Text = ""
                Me.MT_EMAIL.Text = ""
                Me.MT_TELEFONO.Text = ""
                xop = False
            End Try

            Me.BT_GUARDAR.Enabled = Not xop
            Me.MT_NOMBRE.ReadOnly = xop
            Me.MT_EMAIL.ReadOnly = xop
            Me.MT_DIR.ReadOnly = xop
            Me.MT_CONTACTO.ReadOnly = xop
            Me.MT_TELEFONO.ReadOnly = xop
        End If
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        If MT_RIF.r_Valor <> "" And Me.MT_NOMBRE.r_Valor <> "" And Me.MT_DIR.r_Valor <> "" Then
            If MessageBox.Show("Deseas Guardar Este Cliente ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                _EstatusSalida = GrabarCliente()
                Me.Close()
            Else
                Me.MT_RIF.Select()
            End If
        Else
            MessageBox.Show("Error... Faltan Campos Por Completar, Verifique Por Favor...", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MT_RIF.Select()
        End If
    End Sub

    Function GrabarCliente() As Boolean
        Try
            Dim xreg As New FichaClientes.c_Clientes.c_AgregarClienteBasico
            With xreg
                ._AutoCobrador = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloClientes._AutoCobrador_ARegistrar_PorDefecto
                ._AutoEstado = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloClientes._AutoEstado_ARegistrar_PorDefecto
                ._AutoGrupo = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloClientes._AutoGrupo_ARegistrar_PorDefecto
                ._AutoVendedor = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloClientes._AutoVendedor_ARegistrar_PorDefecto
                ._AutoZona = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloClientes._AutoZona_ARegistrar_PorDefecto
                ._DirFiscal = Me.MT_DIR.r_Valor
                ._Email = Me.MT_EMAIL.r_Valor
                ._NombreRazonSocial = Me.MT_NOMBRE.r_Valor
                ._PersonaContacto = Me.MT_CONTACTO.r_Valor
                ._RifCi = Me.MT_RIF.r_Valor
                ._Telf_1 = Me.MT_TELEFONO.r_Valor
            End With
            xcliente.F_ClienteNuevoBasico(xreg)
            MessageBox.Show("Cliente Grabado Con Exito", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class