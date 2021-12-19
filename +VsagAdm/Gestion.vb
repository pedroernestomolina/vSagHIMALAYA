Public Class Gestion


    Private _gestionDollar As TasaDollar.Actualizar.Gestion


    Public Sub New()
        _gestionDollar = New TasaDollar.Actualizar.Gestion
    End Sub


    Sub ActualizarTasaActualDollar()
        _gestionDollar.Inicia()
    End Sub


End Class