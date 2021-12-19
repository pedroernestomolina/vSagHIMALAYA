Public Class Login
    Dim xentradaexitosa As Boolean
    Dim xusuario As Usuario
    Dim xautomaticousuario As String

    Property _AutomaticoUsuario() As String
        Get
            Return xautomaticousuario.Trim
        End Get
        Set(ByVal value As String)
            xautomaticousuario = value
        End Set
    End Property

    Property _EntradaExitosa() As Boolean
        Get
            Return xentradaexitosa
        End Get
        Set(ByVal value As Boolean)
            xentradaexitosa = value
        End Set
    End Property

    Property UsuarioLogin() As Usuario
        Get
            Return xusuario
        End Get
        Set(ByVal value As Usuario)
            xusuario = value
        End Set
    End Property

    Function Inicia() As Boolean
        Try
            Me._EntradaExitosa = False
            Me._AutomaticoUsuario = ""

            Me.TS_VERSION.Text = "Version Empresarial: " + My.Application.Info.Version.ToString
            Me.E_ESTACION_NOMB.Text = g_EquipoEstacion.p_EstacionNombre
            Me.E_ESTACION_IP.Text = g_EquipoEstacion.p_EstacionIp
            Me.E_SERVIDORDATOS_NOMBRE.Text = g_ConfiguracionSistema._NombreServidor
            Me.E_SERVIDORDATOS_IP.Text = g_ConfiguracionSistema._InstanciaServidor

            Me.MT_LOG_USUARIO.DataBindings.Add("text", UsuarioLogin, "p_Usuario")
            Me.MT_LOG_CLAVE.DataBindings.Add("text", UsuarioLogin, "p_Clave")
            Me.MT_LOG_USUARIO.Select()
        Catch ex As Exception
            Dim xms As String = "ERROR AL INICIAR SISTEMA." + vbCrLf + vbCrLf + ex.ToString + vbCrLf
            MessageBox.Show(xms, "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Function

    Private Sub Login_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.UsuarioLogin = New Usuario
        Inicia()
    End Sub

    Private Sub BT_SALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BT_ACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ACEPTAR.Click
        If Me.UsuarioLogin.p_Usuario <> "" Then
            If VerificaUsuario() Then
                Me._EntradaExitosa = True
                Me.Close()
            Else
                Dim xms As String = "ERROR DE IDENTIFICACION." + vbCrLf + "NOMBRE DE USUARIO / CLAVE INCORRECTO, o" + vbCrLf + "USUARIO EN ESTADO INACTIVO, VERIFIQUE POR FAVOR"
                MessageBox.Show(xms, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MT_LOG_USUARIO.Select()
            End If
        Else
            Me.MT_LOG_USUARIO.Select()
        End If
    End Sub

    Function VerificaUsuario() As Boolean
        Try
            Dim xauto As Object = Nothing
            xauto = g_MiData.F_ConectarConUsuario(UsuarioLogin.p_Usuario, UsuarioLogin.p_Clave)
            If xauto IsNot Nothing Then
                Me._AutomaticoUsuario = xauto.ToString
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Error Del Sistema." + vbCrLf + ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class