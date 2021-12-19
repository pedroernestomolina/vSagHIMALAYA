Public Class AcercaDe

    Private Sub AcercaDe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub AcercaDe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FileProperties As FileVersionInfo = _
                      FileVersionInfo.GetVersionInfo(My.Application.Info.DirectoryPath + "\" + My.Application.Info.AssemblyName + ".exe")

        Me.Label3.Text = "Versión: " + My.Application.Info.Version.ToString + ", Ultima Actualización: " + FileProperties.FileVersion.ToString + vbCrLf + My.Application.Info.Copyright

        Me.RichTextBox1.Text = "Prolongacion Avenida Michelena, Centro Comercial Mycra, Oficina #21, Valencia - Estado Carabobo. Telefonos: (0241)8389843, 8340241.Fax: (0241) 8340241."
        Me.RichTextBox2.Text = "WebSite: http://www.foxsystem.com.ve, Email: foxsystem@hotmail.com"
        Me.RichTextBox1.SelectionStart = 0
        Me.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
        Me.RichTextBox2.SelectionStart = 0
        Me.RichTextBox2.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub RichTextBox2_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles RichTextBox2.LinkClicked
        Dim xficha As New FichaWeb
        With xficha
            ._PaginaInicio = ModuloPrincipal.PaginaFoxSystem
            .ShowDialog()
        End With
    End Sub
End Class