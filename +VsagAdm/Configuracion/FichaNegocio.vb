Imports DataSistema.MiDataSistema.DataSistema

Public Class FichaNegocio
    Event ActualizarData_Evento()

    Dim xaccion As TipoAccionFicha
    Dim xfichanegocio As FichaGlobal.c_Negocio

    Private Sub FichaNegocio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If AccionFicha = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If MessageBox.Show("Deseas Salir Sin Grabar Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Me.MT_RAZONSOCIAL.Select()
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub FichaNegocio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FichaNegocio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub FichaNegocio_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Property AccionFicha() As TipoAccionFicha
        Get
            Return xaccion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xaccion = value
        End Set
    End Property

    Sub ActualizarData()
        RaiseEvent ActualizarData_Evento()
    End Sub

    Sub Inicializa()
        Try
            AccionFicha = TipoAccionFicha.Consultar
            xfichanegocio = New FichaGlobal.c_Negocio
            AddHandler xfichanegocio.Actualizar, AddressOf ActualizarData
            xfichanegocio.F_CargarDataNegocio()

            Me.BT_ACTUALIZAR.Enabled = True
            Me.BT_GRABAR.Enabled = False
            Me.BT_ACTUALIZAR.Select()

            ApagarCajasTextos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ApagarCajasTextos()
        With Me.MT_CEL1
            .MaxLength = xfichanegocio.RegistroDato.c_Celular_1.c_Largo
            .Text = xfichanegocio.RegistroDato.c_Celular_1.c_Texto
            .Enabled = False
        End With
        With Me.MT_CEL2
            .MaxLength = xfichanegocio.RegistroDato.c_Celular_2.c_Largo
            .Text = xfichanegocio.RegistroDato.c_Celular_2.c_Texto
            .Enabled = False
        End With
        With Me.MT_CODSUCURSAL
            .MaxLength = xfichanegocio.RegistroDato.c_CodigoSucursal.c_Largo
            .Text = xfichanegocio.RegistroDato.c_CodigoSucursal.c_Texto
            .Enabled = False
        End With
        With Me.MT_CONTACTO
            .MaxLength = xfichanegocio.RegistroDato.c_ContactarA.c_Largo
            .Text = xfichanegocio.RegistroDato.c_ContactarA.c_Texto
            .Enabled = False
        End With
        With Me.MT_DIRFISCAL
            .MaxLength = xfichanegocio.RegistroDato.c_DireccionFiscal.c_Largo
            .Text = xfichanegocio.RegistroDato.c_DireccionFiscal.c_Texto
            .Enabled = False
        End With
        With Me.MT_DIRREF
            .MaxLength = xfichanegocio.RegistroDato.c_DirReferencia.c_Largo
            .Text = xfichanegocio.RegistroDato.c_DirReferencia.c_Texto
            .Enabled = False
        End With
        With Me.MT_EMAIL
            .MaxLength = xfichanegocio.RegistroDato.c_Email.c_Largo
            .Text = xfichanegocio.RegistroDato.c_Email.c_Texto
            .Enabled = False
        End With
        With Me.MT_FAX1
            .MaxLength = xfichanegocio.RegistroDato.c_Fax_1.c_Largo
            .Text = xfichanegocio.RegistroDato.c_Fax_1.c_Texto
            .Enabled = False
        End With
        With Me.MT_FAX2
            .MaxLength = xfichanegocio.RegistroDato.c_Fax_2.c_Largo
            .Text = xfichanegocio.RegistroDato.c_Fax_2.c_Texto
            .Enabled = False
        End With
        With Me.MT_RAZONSOCIAL
            .MaxLength = xfichanegocio.RegistroDato.c_RazonSocial.c_Largo
            .Text = xfichanegocio.RegistroDato.c_RazonSocial.c_Texto
            .Enabled = False
        End With
        With Me.MT_RIF
            .MaxLength = xfichanegocio.RegistroDato.c_RIF.c_Largo
            .Text = xfichanegocio.RegistroDato.c_RIF.c_Texto
            .Enabled = False
        End With
        With Me.MT_SUCURSAL
            .MaxLength = xfichanegocio.RegistroDato.c_Sucursal.c_Largo
            .Text = xfichanegocio.RegistroDato.c_Sucursal.c_Texto
            .Enabled = False
        End With
        With Me.MT_TEL1
            .MaxLength = xfichanegocio.RegistroDato.c_Telefono_1.c_Largo
            .Text = xfichanegocio.RegistroDato.c_Telefono_1.c_Texto
            .Enabled = False
        End With
        With Me.MT_TEL2
            .MaxLength = xfichanegocio.RegistroDato.c_Telefono_2.c_Largo
            .Text = xfichanegocio.RegistroDato.c_Telefono_2.c_Texto
            .Enabled = False
        End With
        With Me.MT_TEL3
            .MaxLength = xfichanegocio.RegistroDato.c_Telefono_3.c_Largo
            .Text = xfichanegocio.RegistroDato.c_Telefono_3.c_Texto
            .Enabled = False
        End With
        With Me.MT_TEL4
            .MaxLength = xfichanegocio.RegistroDato.c_Telefono_4.c_Largo
            .Text = xfichanegocio.RegistroDato.c_Telefono_4.c_Texto
            .Enabled = False
        End With
        With Me.MT_WEBSITE
            .MaxLength = xfichanegocio.RegistroDato.c_WebSite.c_Largo
            .Text = xfichanegocio.RegistroDato.c_WebSite.c_Texto
            .Enabled = False
        End With
    End Sub

    Sub Actualizar()
        Me.MT_CEL1.Enabled = True
        Me.MT_CEL2.Enabled = True
        Me.MT_CODSUCURSAL.Enabled = True
        Me.MT_CONTACTO.Enabled = True
        Me.MT_DIRFISCAL.Enabled = True
        Me.MT_DIRREF.Enabled = True
        Me.MT_EMAIL.Enabled = True
        Me.MT_FAX1.Enabled = True
        Me.MT_FAX2.Enabled = True
        Me.MT_RAZONSOCIAL.Enabled = True
        Me.MT_RIF.Enabled = True
        Me.MT_SUCURSAL.Enabled = True
        Me.MT_TEL1.Enabled = True
        Me.MT_TEL2.Enabled = True
        Me.MT_TEL3.Enabled = True
        Me.MT_TEL4.Enabled = True
        Me.MT_WEBSITE.Enabled = True
        Me.BT_ACTUALIZAR.Enabled = False
        Me.BT_GRABAR.Enabled = True
    End Sub

    Private Sub BT_ACTUALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ACTUALIZAR.Click
        AccionFicha = TipoAccionFicha.Modificar
        Actualizar()
        Me.MT_RAZONSOCIAL.Select()
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        If MessageBox.Show("Estas Seguro De Guardar Estos Cambios ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xregistro As FichaGlobal.c_Negocio.c_RegistroActualizar
                xregistro = New FichaGlobal.c_Negocio.c_RegistroActualizar
                With xregistro
                    ._Celular_1 = Me.MT_CEL1.r_Valor
                    ._Celular_2 = Me.MT_CEL2.r_Valor
                    ._CodigoSucursal = Me.MT_CODSUCURSAL.r_Valor
                    ._ContactarA = Me.MT_CONTACTO.r_Valor
                    ._DireccionFiscal = Me.MT_DIRFISCAL.r_Valor
                    ._DirReferencia = Me.MT_DIRREF.r_Valor
                    ._Email = Me.MT_EMAIL.r_Valor
                    ._Fax_1 = Me.MT_FAX1.r_Valor
                    ._Fax_2 = Me.MT_FAX2.r_Valor
                    ._IdSeguridad = xfichanegocio.RegistroDato._IdSeguridad
                    ._RazonSocial = Me.MT_RAZONSOCIAL.r_Valor
                    ._RIF = Me.MT_RIF.r_Valor
                    ._Sucursal = Me.MT_SUCURSAL.r_Valor
                    ._Telefono_1 = Me.MT_TEL1.r_Valor
                    ._Telefono_2 = Me.MT_TEL2.r_Valor
                    ._Telefono_3 = Me.MT_TEL3.r_Valor
                    ._Telefono_4 = Me.MT_TEL4.r_Valor
                    ._WebSite = Me.MT_WEBSITE.r_Valor
                End With

                xfichanegocio.F_ActualizarDataNegocio(xregistro)
                MessageBox.Show("Datos Guardados Exitosamente... Ok", "*** Mensaje Informativo *** ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.AccionFicha = TipoAccionFicha.Consultar
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.MT_RAZONSOCIAL.Select()
            End Try
        Else
            Me.MT_RAZONSOCIAL.Select()
        End If
    End Sub
End Class