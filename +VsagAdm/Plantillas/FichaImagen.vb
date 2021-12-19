Imports DataSistema.MiDataSistema.DataSistema
Imports System.IO

Public Class FichaImagen
    Dim xprd As FichaProducto.Prd_Producto.c_Registro

    Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
        Get
            Return xprd
        End Get
        Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
            xprd = value
        End Set
    End Property

    Sub New(ByVal xprd As FichaProducto.Prd_Producto.c_Registro)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _FichaProducto = xprd
    End Sub

    Private Sub FichaImagen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FichaImagen_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Dim im As Image
            If _FichaProducto._EstatusFoto = TipoEstatus.Activo Then
                Using xst As StreamReader = New StreamReader(g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloInventario._RutaImagenesProductos + "\" + _FichaProducto._AutoProducto)
                    im = Image.FromStream(xst.BaseStream)
                    PictureBox1.Image = im
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class