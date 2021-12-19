Public Class TasaDollarFrm


    Private controlador As TasaDollar.Actualizar.Gestion


    Private Sub BT_ACTUALIZAR_Click(sender As Object, e As EventArgs) Handles BT_ACTUALIZAR.Click
        Guardar()
    End Sub


    Sub setGestion(ctr As TasaDollar.Actualizar.Gestion)
        controlador = ctr
    End Sub

    Private Sub Guardar()
        controlador.Guardar()
        If controlador.ActualizarTasaIsOk Then
            Salir()
        End If
    End Sub

    Private Sub BT_SALIR_Click(sender As Object, e As EventArgs) Handles BT_SALIR.Click
        Salir()
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

    Private Sub MisNumeros1_Leave(sender As Object, e As EventArgs) Handles MisNumeros1.Leave
        controlador.setTasaActual(MisNumeros1._Valor)
    End Sub

    Private Sub TasaDollarFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MisNumeros1.Text = controlador.TasaActual.ToString("n2").Replace(".", "")
    End Sub


End Class