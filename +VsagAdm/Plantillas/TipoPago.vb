Imports DataSistema.MiDataSistema.DataSistema

Public Class TipoPago
    Dim xreg As DataRow
    Dim xsalida As Boolean
    Dim xtb As DataTable

    Property _Registro() As DataRow
        Get
            Return xreg
        End Get
        Set(ByVal value As DataRow)
            xreg = value
        End Set
    End Property

    Property _EstatusSalida() As Boolean
        Get
            Return xsalida
        End Get
        Set(ByVal value As Boolean)
            xsalida = value
        End Set
    End Property

    Private Sub TipoPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Sub New(ByVal xrow As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Registro = xrow
        _EstatusSalida = False

        xtb = New DataTable
    End Sub

    Private Sub TipoPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub TipoPago_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub Inicializa()
        Try
            g_MiData.F_GetData("select nombre,auto,codigo from medios_pago where estatus='Activo' and auto not in ('NC00000001','AN00000001','RVI0000001') order by codigo", xtb)
            With MCB_TIPO
                .DataSource = xtb
                .DisplayMember = "nombre"
                .ValueMember = "auto"

                If _Registro(4).ToString.Trim = "" Then
                    .SelectedIndex = 0
                Else
                    .SelectedValue = _Registro(4).ToString.Trim
                End If
            End With

            With Me.MT_AGENCIA
                .Text = _Registro(3).ToString.Trim
                .MaxLength = 50
            End With
            With Me.MT_PLANILLA
                .Text = _Registro(2).ToString.Trim
                .MaxLength = 15
            End With
            With Me.MN_MONTO
                ._Formato = "99999999999.99"
                ._ConSigno = False
                .Text = String.Format("{0:#0.00}", _Registro(1))
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If Me.MN_MONTO._Valor > 0 Then
            Dim xrow As DataRow = xtb.Select("auto='" + Me.MCB_TIPO.SelectedValue + "'")(0)
            _Registro(1) = Me.MN_MONTO._Valor
            _Registro(2) = Me.MT_PLANILLA.r_Valor
            _Registro(3) = Me.MT_AGENCIA.r_Valor
            _Registro(4) = Me.MCB_TIPO.SelectedValue
            _Registro(0) = xrow("nombre").ToString.Trim
            _Registro(5) = xrow("codigo").ToString.Trim
            _EstatusSalida = True
        End If
        Me.Close()
    End Sub

    Private Sub MCB_TIPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_TIPO.SelectedIndexChanged
        If Me.MCB_TIPO.SelectedValue.ToString.Trim = "NC00000001" Then
            If MessageBox.Show("Deseas Utilizar El Saldo Notas De Credito A Favor Del Cliente Como Medio De Pago ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Else
            End If
        End If
        If Me.MCB_TIPO.SelectedValue.ToString.Trim = "AN00000001" Then
            If MessageBox.Show("Deseas Utilizar El Saldo Anticipo A Favor Del Cliente Como Medio De Pago ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Else
            End If
        End If
    End Sub
End Class