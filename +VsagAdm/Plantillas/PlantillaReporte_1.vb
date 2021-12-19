Public Class PlantillaReporte_1
    Event _ReportePeriodo(ByVal Mes As Integer, ByVal Ano As Integer)
    Event _ReporteFecha(ByVal desde As Date, ByVal hasta As Date)

    Dim xdesde As Date
    Dim xhasta As Date
    Dim xok As Boolean
    Dim xmes As String() = {"Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"}

    Property p_EscapePantalla() As Boolean
        Get
            Return xok
        End Get
        Set(ByVal value As Boolean)
            xok = value
        End Set
    End Property

    Property p_FechaDesde() As Date
        Get
            Return xdesde
        End Get
        Set(ByVal value As Date)
            xdesde = value
        End Set
    End Property

    Property p_FechaHasta() As Date
        Get
            Return xhasta
        End Get
        Set(ByVal value As Date)
            xhasta = value
        End Set
    End Property

    Private Sub PlantillaReporte_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub PlantillaReporte_1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.p_EscapePantalla = True
        With Me.MCB_MESES
            .DataSource = xmes
            .SelectedIndex = Month(Date.Now) - 1
        End With
        Me.NumericUpDown1.Value = Year(Date.Now)
    End Sub

    Private Sub BT_MES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_MES.Click
        Me.p_FechaDesde = New Date(Me.NumericUpDown1.Value, Me.MCB_MESES.SelectedIndex + 1, 1)
        Me.p_FechaHasta = DateAdd(DateInterval.Day, Date.DaysInMonth(Year(Me.p_FechaDesde), Month(Me.p_FechaDesde)) - 1, Me.p_FechaDesde)
        Me.p_EscapePantalla = False
        RaiseEvent _ReportePeriodo(Me.MCB_MESES.SelectedIndex + 1, Me.NumericUpDown1.Value)
        Me.Close()
    End Sub

    Private Sub BT_DESDE_HASTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DESDE_HASTA.Click
        If Me.MF_HASTA.Value >= Me.MF_DESDE.Value Then
            Me.p_FechaDesde = Me.MF_DESDE.Value.Date
            Me.p_FechaHasta = Me.MF_HASTA.Value.Date
            Me.p_EscapePantalla = False

            RaiseEvent _ReporteFecha(Me.MF_DESDE.Value.Date, Me.MF_HASTA.Value.Date)
            Me.Close()
        Else
            Me.MF_HASTA.Value = Me.MF_DESDE.Value
            MessageBox.Show("Error Al Definir Rango De Fecha... Verifique Por Favor", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MF_DESDE.Select()
        End If
    End Sub
End Class