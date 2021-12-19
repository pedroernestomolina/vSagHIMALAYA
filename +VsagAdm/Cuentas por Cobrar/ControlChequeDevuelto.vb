Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles

Public Class ControlChequeDevuelto
    Dim _Plantilla As IControlChequeDevuelto

    Sub New(ByVal xplantilla As IControlChequeDevuelto)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Plantilla = xplantilla
    End Sub

    Private Sub ChequeDevuelto_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            _Plantilla.Inicializar(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub ChequeDevuelto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ControlChequeDevuelto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Interface IControlChequeDevuelto
    Sub Inicializar(ByVal xobj As Object)
End Interface

Public Class ControlChequeDevueltoCxc
    Implements IControlChequeDevuelto

    Event _DocumentoProcesado()
    Private Const SELECT_AGENCIAS As String = "SELECT nombre xnombre, auto xauto, * FROM agencias order by nombre"

    'CONTROLES DEL FORMULARIO
    WithEvents _MiFormulario As System.Windows.Forms.Form
    WithEvents MN_NUMERO_CHEQUE As MisNumeros
    WithEvents MCB_AGENCIA As MisComboBox
    WithEvents MF_EMISION As MisFechas
    WithEvents MF_DEVOLUCION As MisFechas
    WithEvents MN_MONTO As MisNumeros
    WithEvents MT_MOTIVO As MisTextos
    WithEvents MN_COMISION_MONTO As MisNumeros
    WithEvents BT_PROCESAR As Button
    WithEvents LK_AGENCIA As LinkLabel

    Dim xfichacliente As FichaClientes.c_Clientes.c_Registro
    Dim xtb_agencia As DataTable
    Dim xbs_agencia As BindingSource
    Dim xsalida As Boolean

    Property _SalidaExitosa() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Property _FichaClientes() As FichaClientes.c_Clientes.c_Registro
        Get
            Return xfichacliente
        End Get
        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
            xfichacliente = value
        End Set
    End Property

    Sub New(ByVal xcliente As FichaClientes.c_Clientes.c_Registro)
        Me._FichaClientes = xcliente

        xtb_agencia = New DataTable
        xbs_agencia = New BindingSource(xtb_agencia, "")
        _SalidaExitosa = False
    End Sub

    Public Sub Inicializar(ByVal xobj As Object) Implements IControlChequeDevuelto.Inicializar
        Try
            _MiFormulario = xobj
            MN_NUMERO_CHEQUE = _MiFormulario.Controls.Find("MN_1", True)(0)
            MCB_AGENCIA = _MiFormulario.Controls.Find("MCB_1", True)(0)
            MF_EMISION = _MiFormulario.Controls.Find("MF_1", True)(0)
            MF_DEVOLUCION = _MiFormulario.Controls.Find("MF_2", True)(0)
            MN_MONTO = _MiFormulario.Controls.Find("MN_2", True)(0)
            MN_COMISION_MONTO = _MiFormulario.Controls.Find("MN_3", True)(0)
            MT_MOTIVO = _MiFormulario.Controls.Find("MT_1", True)(0)
            BT_PROCESAR = _MiFormulario.Controls.Find("BT_1", True)(0)
            LK_AGENCIA = _MiFormulario.Controls.Find("LK_AGENCIA", True)(0)

            InicializarControles()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub CargarAgencias()
        Try
            g_MiData.F_GetData(SELECT_AGENCIAS, xtb_agencia)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub InicializarControles()
        With Me.MN_NUMERO_CHEQUE
            .Text = ""
            ._Formato = "9999999999"
            ._ConSigno = False
            .Enabled = True
        End With
        With Me.MN_COMISION_MONTO
            .Text = String.Format("{0:#0.00}", g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloCxCobrar._ComisionChequeDevuelto)
            ._Formato = "99999999999.99"
            ._ConSigno = False
            .Enabled = True
        End With
        With Me.MN_MONTO
            .Text = "0.0"
            ._Formato = "99999999999.99"
            ._ConSigno = False
            .Enabled = True
        End With
        With Me.MT_MOTIVO
            .Text = ""
            .MaxLength = 120
            .Enabled = True
        End With
        Me.MF_EMISION.Value = Date.Now
        Me.MF_DEVOLUCION.Value = Date.Now

        CargarAgencias()
        With Me.MCB_AGENCIA
            .DataSource = xbs_agencia
            .DisplayMember = "xnombre"
            .ValueMember = "xauto"
        End With
    End Sub

    Function ValidarCampos() As Boolean
        If MN_NUMERO_CHEQUE._Valor = 0 Then
            MessageBox.Show("DEBE REGISTRAR EL NUMERO DEL CHEQUE, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_NUMERO_CHEQUE.Select()
            MN_NUMERO_CHEQUE.Focus()
            Return False
        End If

        If MN_MONTO._Valor = 0 Then
            MessageBox.Show("DEBE REGISTRAR MONTO DEL CHEQUE, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MN_MONTO.SelectAll()
            MN_MONTO.Focus()
            Return False
        End If

        If MT_MOTIVO.r_Valor = "" Then
            MessageBox.Show("DEBE REGISTRAR EL DETALLE DEL DOCUMENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MT_MOTIVO.Select()
            MT_MOTIVO.Focus()
            Return False
        End If

        If MF_EMISION.Value > g_MiData.p_FechaDelMotorBD Then
            MessageBox.Show("FECHA EMISION DEL CHEQUE INCORRECTA, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MF_EMISION.Select()
            MF_EMISION.Focus()
            Return False
        End If

        If MF_DEVOLUCION.Value > g_MiData.p_FechaDelMotorBD Then
            MessageBox.Show("FECHA DEVOLUCION DEL CHEQUE INCORRECTA, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MF_DEVOLUCION.Select()
            MF_DEVOLUCION.Focus()
            Return False
        End If

        If MF_DEVOLUCION.Value < MF_EMISION.Value Then
            MessageBox.Show("FECHA DEVOLUCION DEL CHEQUE INCORRECTA, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MF_DEVOLUCION.Select()
            MF_DEVOLUCION.Focus()
            Return False
        End If

        If xbs_agencia.Current Is Nothing Then
            MessageBox.Show("DEBE SELECCIONAR / CREAR UNA AGENCIA PARA ESTE MOVIMIENTO, POR FAVOR VERIFIQUE", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.MCB_AGENCIA.Select()
            Me.MCB_AGENCIA.Focus()
        End If

        Return True
    End Function

    Private Sub BT_PROCESAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If ValidarCampos() Then
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Grabar Este Registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim xficha As New FichaCtasCobrar
                    Dim xagregar As New FichaCtasCobrar.c_CxC.c_AgregarChequeDevuelto
                    Dim xagencia As New FichaBancos.c_Agencias

                    If xbs_agencia.Current IsNot Nothing Then
                        Dim xr As DataRow = CType(xbs_agencia.Current, DataRowView).Row
                        xagencia.M_CargarFicha(xr)
                    End If

                    With xagregar
                        ._ComisionCheque = Me.MN_COMISION_MONTO._Valor
                        ._FechaDevolucion = Me.MF_DEVOLUCION.Value
                        ._FechaEmision = Me.MF_EMISION.Value
                        ._FechaProceso = g_MiData.p_FechaDelMotorBD
                        ._FichaAgencia = xagencia.RegistroDato
                        ._FichaCliente = _FichaClientes
                        ._MontoCheque = Me.MN_MONTO._Valor
                        ._NotasDetalle = Me.MT_MOTIVO.r_Valor
                        ._NumeroCheque = Me.MN_NUMERO_CHEQUE.Text
                    End With
                    xficha.F_GrabarChequeDevuelto(xagregar)
                    MessageBox.Show("DOCUMENTO REGISTRADO EXITOSAMENTE...OK", "*** Mensaje OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RaiseEvent _DocumentoProcesado()

                    _SalidaExitosa = True
                    _MiFormulario.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub MN_COMISION_MONTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MN_COMISION_MONTO.Validating
        If Me.MN_COMISION_MONTO._Valor > Me.MN_MONTO._Valor Then
            e.Cancel = True
            MessageBox.Show("ERROR... MONTO POR COMISION NO PUEDE SER MAYOR AL MONTO DEL CHEQUE... VERIFIQUE ", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub _MiFormulario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles _MiFormulario.FormClosing
        If _SalidaExitosa Then
            e.Cancel = False
        Else
            Dim xresultado As DialogResult = MessageBox.Show("¿Esta Seguro De Salir?, Se Perderan los Datos Actuales", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xresultado = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub LK_AGENCIA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LK_AGENCIA.Click
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloAgenciaBancaria.F_Permitir()

            Dim xficha As New Plantilla_1(New Agencias)
            With xficha
                AddHandler .ActualizarFicha, AddressOf CargarAgencias
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class