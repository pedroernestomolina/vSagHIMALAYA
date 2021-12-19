Imports DataSistema.MiDataSistema.DataSistema

Public Class TasasFiscales
    Dim xtasasfiscales As FichaGlobal.c_TasasFiscales
    Dim xaccion As TipoAccionFicha

    Property AccionFicha() As TipoAccionFicha
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xaccion = value
        End Set
    End Property

    Private Sub TasasFiscales_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If AccionFicha = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If MessageBox.Show("Deseas Salir Sin Grabar Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Me.MN_TASA1.Select()
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub TasasFiscales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub TasasFiscales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub TasasFiscales_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub ActualizarTasas()
        g_MiData.f_FichaGlobal.f_Fiscal.F_CargarTasasFiscales()
    End Sub

    Sub Inicializa()
        Try
            AccionFicha = TipoAccionFicha.Consultar
            xtasasfiscales = New FichaGlobal.c_TasasFiscales
            xtasasfiscales.F_CargarTasasFiscales()
            AddHandler xtasasfiscales.Actualizar, AddressOf ActualizarTasas

            Me.E_TASA1.Text = String.Format("{0:#0.00}", xtasasfiscales.RegistroDato.c_TasaIva_1.c_Valor)
            Me.E_TASA2.Text = String.Format("{0:#0.00}", xtasasfiscales.RegistroDato.c_TasaIva_2.c_Valor)
            Me.E_TASA3.Text = String.Format("{0:#0.00}", xtasasfiscales.RegistroDato.c_TasaIva_3.c_Valor)

            Me.BT_ACTUALIZAR.Enabled = True
            Me.BT_GRABAR.Enabled = False

            With Me.MN_TASA1
                ._Formato = "99.99"
                ._ConSigno = False
                .Text = Me.E_TASA1.Text
                .Enabled = False
            End With
            With Me.MN_TASA2
                ._Formato = "99.99"
                ._ConSigno = False
                .Text = Me.E_TASA2.Text
                .Enabled = False
            End With
            With Me.MN_TASA3
                ._Formato = "99.99"
                ._ConSigno = False
                .Text = Me.E_TASA3.Text
                .Enabled = False
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BT_ACTUALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ACTUALIZAR.Click
        AccionFicha = TipoAccionFicha.Modificar

        Me.BT_ACTUALIZAR.Enabled = False
        Me.BT_GRABAR.Enabled = True

        Me.MN_TASA1.Enabled = True
        Me.MN_TASA2.Enabled = True
        Me.MN_TASA3.Enabled = True

        Me.MN_TASA1.Focus()
        Me.MN_TASA1.Select()
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        If MessageBox.Show("Estas Seguro De Guardar Estos Cambios ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                xtasasfiscales.F_ActualizarTasasFiscales(Me.MN_TASA1._Valor, Me.MN_TASA2._Valor, Me.MN_TASA3._Valor)
                MessageBox.Show("Datos Guardados Exitosamente... Ok", "*** Mensaje Informativo *** ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                AccionFicha = TipoAccionFicha.Consultar
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MN_TASA1.Select()
                Me.MN_TASA1.Focus()
            End Try
        Else
            Me.MN_TASA1.Select()
            Me.MN_TASA1.Focus()
        End If
    End Sub
End Class