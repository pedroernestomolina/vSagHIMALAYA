Public Class Plantilla_DesdeHasta
    Dim xinicio As Date
    Dim xfin As Date
    Dim xestatus As Boolean

    Property _FechaInicio() As Date
        Get
            Return xinicio
        End Get
        Set(ByVal value As Date)
            xinicio = value
        End Set
    End Property

    Property _FechaFin() As Date
        Get
            Return xfin
        End Get
        Set(ByVal value As Date)
            xfin = value
        End Set
    End Property

    Property _Estatus() As Boolean
        Get
            Return xestatus
        End Get
        Set(ByVal value As Boolean)
            xestatus = value
        End Set
    End Property

    Sub Inicio()
        MF_INICIO.Value = Date.Now
        MF_FIN.Value = Date.Now
        With Me.MF_INICIO
            .Select()
            .Focus()
        End With
    End Sub

    Private Sub Plantilla_DesdeHasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_DesdeHasta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _Estatus = False
        Inicio()
    End Sub

    Private Sub MF_INICIO_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_INICIO.ValueChanged
        Me.MF_FIN.Value = Me.MF_INICIO.Value
    End Sub

    Private Sub MF_FIN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_FIN.ValueChanged
        If MF_FIN.Value < MF_INICIO.Value Then
            MF_FIN.Value = MF_INICIO.Value
        End If
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If Me.MF_FIN.Value >= Me.MF_INICIO.Value Then
            _Estatus = True
            _FechaInicio = Me.MF_INICIO.Value
            _FechaFin = Me.MF_FIN.Value
            Me.Close()
        Else
            MessageBox.Show("Error... Rango De Fechas Incorrecto, Verifique", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Inicio()
        End If
    End Sub
End Class