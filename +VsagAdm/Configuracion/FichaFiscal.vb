Public Class FichaFiscal
    Dim tip_doc As String() = {"Factura", "Nota Credito"}
    Dim tip_resumen As String() = {"Detallado", "Mensual", "Total", "Por Rango Z"}

    Sub Inicio()
        Me.RB_REP_X.Checked = False
        Me.RB_REP_Z.Checked = False

        Me.RB_REP_ACUM_FECHA.Checked = False
        Me.RB_REP_ACUM_Z.Checked = False

        Me.RB_TIPO_DOC.Checked = False

        With Me.MN_ACUM_DESDE
            ._Formato = "999999"
            ._ConSigno = False
            .Text = "1"
            .Enabled = False
        End With

        With Me.MN_ACUM_HASTA
            ._Formato = "999999"
            ._ConSigno = False
            .Text = "1"
            .Enabled = False
        End With

        With Me.MN_DOC_INICIO
            ._Formato = "999999"
            ._ConSigno = False
            .Text = "1"
            .Enabled = False
        End With

        With Me.MN_DOC_HASTA
            ._Formato = "999999"
            ._ConSigno = False
            .Text = "1"
            .Enabled = False
        End With

        With Me.MF_INICIO
            .Value = Date.Today
            .Enabled = False
        End With
        With Me.MF_HASTA
            .Value = Date.Today
            .Enabled = False
        End With

        With Me.MCB_TIPO_DOC
            .DataSource = tip_doc
            .SelectedIndex = 0
            .Enabled = False
        End With

        With Me.MCB_RESUMEN
            .DataSource = tip_resumen
            .SelectedIndex = 0
            .Enabled = False
        End With

        Me.E_FACTURA.Text = ""
        Me.E_FECHA.Text = ""
        Me.E_HORA.Text = ""
        Me.E_SERIAL.Text = ""
        Me.E_RIF.Text = ""
        Me.E_Z.Text = ""
    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicio()
    End Sub

    Private Sub BT_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_2.Click
        Me.BT_2.Enabled = False

        Dim xp As String = ""
        If Me.RB_REP_X.Checked Or Me.RB_REP_Z.Checked Then
            If Me.RB_REP_X.Checked Then
                xp = "Estas Seguro De Imprimir Reporte 'X' Fiscal ?"
            Else
                xp = "Estas Seguro De Imprimir Reporte 'Z' Fiscal ?"
            End If
            If MessageBox.Show(xp, "*** ALERTA ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If Me.RB_REP_X.Checked Then
                    Try
                        g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VisorFiscal_X.F_Permitir()
                        g_ImpFiscal.Reporte_X_Fiscal()
                        Funciones.MensajeDeOk("Proceso Realizado Con Exito")
                    Catch ex As Exception
                        Funciones.MensajeDeError(ex.Message)
                    End Try
                Else
                    Try
                        g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VisorFiscal_Z.F_Permitir()
                        BT_2.Enabled = False
                        g_ImpFiscal.Reporte_Z_Fiscal()
                        Funciones.MensajeDeOk("Proceso Realizado Con Exito")
                    Catch ex As Exception
                        Funciones.MensajeDeError(ex.Message)
                    End Try
                End If
            End If
        Else
            Funciones.MensajeDeAlerta("Reportes Ventas Del Dia" + vbCrLf + "!!! DEBES SELECCIONAR UNA OPCION DE LA LISTA !!!")
        End If
        With Me.BT_2
            .Enabled = True
            .Focus()
            .Select()
        End With
        Inactivar()
    End Sub

    Sub Inactivar()
        Me.RB_REP_X.Checked = False
        Me.RB_REP_Z.Checked = False
        Me.RB_REP_ACUM_FECHA.Checked = False
        Me.RB_REP_ACUM_Z.Checked = False
        Me.RB_TIPO_DOC.Checked = False
    End Sub

    Private Sub BT_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Me.E_FACTURA.Text = ""
            Me.E_FECHA.Text = ""
            Me.E_HORA.Text = ""
            Me.E_SERIAL.Text = ""
            Me.E_Z.Text = ""
            Me.E_RIF.Text = ""
            Me.BT_1.Enabled = False

            g_ImpFiscal.Estatus()
            Me.E_FACTURA.Text = g_ImpFiscal.Ver_UltimaFacturaRegistrada
            Me.E_FECHA.Text = g_ImpFiscal.Ver_FechaImpresoraFiscal
            Me.E_HORA.Text = g_ImpFiscal.Ver_HoraImpresoraFiscal.Substring(0, 5)
            Me.E_SERIAL.Text = g_ImpFiscal.Ver_SerialImpresoraFiscal
            Me.E_Z.Text = g_ImpFiscal.Ver_UltimoZFiscal
            Me.E_RIF.Text = g_ImpFiscal.Ver_RifImpresoraFiscal

            Funciones.MensajeDeOk("Proceso Realizado Con Exito")
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        Finally
            Me.BT_1.Enabled = True
            Inactivar()
            Me.BT_1.Focus()
            Me.BT_1.Select()
        End Try
    End Sub

    Private Sub BT_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_3.Click
        Me.BT_3.Enabled = False
        Dim xp As String = ""
        If Me.RB_REP_ACUM_FECHA.Checked Or Me.RB_REP_ACUM_Z.Checked Then
            If Me.RB_REP_ACUM_FECHA.Checked Then
                xp = "Estas Seguro De Imprimir Este Rango De Fechas Fiscal ?"
            Else
                xp = "Estas Seguro De Imprimir Este Rango De Numeros Fiscal ?"
            End If
            If MessageBox.Show(xp, "*** ALERTA ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If Me.RB_REP_ACUM_Z.Checked Then
                    Try
                        g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VisorFiscal_Reportes_Z.F_Permitir()
                        If MN_ACUM_DESDE._Valor > 0 And MN_ACUM_DESDE._Valor <= MN_ACUM_HASTA._Valor Then
                        Else
                            Throw New Exception("NUMERO DE DOCUMENTO Z INVALIDO... VERIFIQUE POR FAVOR")
                        End If

                        g_ImpFiscal.ReporteFiscalPorNumeroZ(Me.MN_ACUM_DESDE._Valor, Me.MN_ACUM_HASTA._Valor, _
                                                                            Me.MCB_RESUMEN.SelectedIndex + 1)
                        Funciones.MensajeDeOk("Proceso Realizado Con Exito")
                    Catch ex As Exception
                        Funciones.MensajeDeError(ex.Message)
                    End Try
                Else
                    Try
                        g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VisorFiscal_Reportes_Z.F_Permitir()
                        If MF_INICIO.Value.Date <= MF_HASTA.Value.Date Then
                        Else
                            Throw New Exception("FECHA DE DOCUMENTO Z INVALIDO... VERIFIQUE POR FAVOR")
                        End If

                        g_ImpFiscal.ReporteFiscalPorFechas(Me.MF_INICIO.Value.Date, Me.MF_HASTA.Value.Date, _
                                                                            Me.MCB_RESUMEN.SelectedIndex + 1)
                        Funciones.MensajeDeOk("Proceso Realizado Con Exito")
                    Catch ex As Exception
                        Funciones.MensajeDeError(ex.Message)
                    End Try
                End If
            End If
        Else
            Funciones.MensajeDeAlerta("Reportes (Z) Acumulados" + vbCrLf + "!!! DEBES SELECCIONAR UNA OPCION DE LA LISTA !!!")
        End If
        Me.BT_3.Enabled = True
        Me.BT_3.Select()
        Me.BT_3.Focus()

        Inactivar()
        Me.MF_INICIO.Value = Date.Today
        Me.MF_HASTA.Value = Date.Today
        Me.MN_ACUM_DESDE.Text = "1"
        Me.MN_ACUM_HASTA.Text = "1"
        Me.RB_REP_ACUM_FECHA.Checked = False
        Me.RB_REP_ACUM_Z.Checked = False
    End Sub

    Private Sub RB_REP_ACUM_Z_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_REP_ACUM_Z.CheckedChanged
        If Me.RB_REP_ACUM_Z.Checked Then
            Me.MN_ACUM_DESDE.Enabled = True
            Me.MN_ACUM_HASTA.Enabled = True
            Me.MCB_RESUMEN.Enabled = True

            Me.MN_ACUM_DESDE.Select()
            Me.MN_ACUM_DESDE.Focus()
        Else
            Me.MN_ACUM_HASTA.Enabled = False
            Me.MN_ACUM_DESDE.Enabled = False
            Me.MCB_RESUMEN.Enabled = False
        End If
    End Sub

    Private Sub RB_REP_ACUM_FECHA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_REP_ACUM_FECHA.CheckedChanged
        If Me.RB_REP_ACUM_FECHA.Checked Then
            Me.MF_INICIO.Enabled = True
            Me.MF_HASTA.Enabled = True
            Me.MCB_RESUMEN.Enabled = True

            Me.MF_INICIO.Select()
            Me.MF_INICIO.Focus()
        Else
            Me.MF_INICIO.Enabled = False
            Me.MF_HASTA.Enabled = False
            Me.MCB_RESUMEN.Enabled = False
        End If
    End Sub

    Private Sub MN_ACUM_DESDE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MN_ACUM_DESDE.Validating
        MyBase.Validate()

        If Me.MN_ACUM_DESDE._Valor >= Me.MN_ACUM_HASTA._Valor Then
            Me.MN_ACUM_HASTA.Text = Me.MN_ACUM_DESDE.Text
        End If
    End Sub

    Private Sub MN_ACUM_HASTA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MN_ACUM_HASTA.Validating
        MyBase.Validate()

        If Me.MN_ACUM_HASTA._Valor <= Me.MN_ACUM_DESDE._Valor Then
            Me.MN_ACUM_HASTA.Text = Me.MN_ACUM_DESDE.Text
        End If
    End Sub

    Private Sub MF_INICIO_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_INICIO.ValueChanged
        If Me.MF_INICIO.Value >= Me.MF_HASTA.Value Then
            Me.MF_HASTA.Value = Me.MF_INICIO.Value
        End If
    End Sub

    Private Sub MF_HASTA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MF_HASTA.ValueChanged
        If Me.MF_HASTA.Value <= Me.MF_INICIO.Value Then
            Me.MF_HASTA.Value = Me.MF_INICIO.Value
        End If
    End Sub

    Private Sub RB_TIPO_DOC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_TIPO_DOC.CheckedChanged
        Me.MCB_TIPO_DOC.Enabled = Me.RB_TIPO_DOC.Checked
        Me.MN_DOC_INICIO.Enabled = Me.RB_TIPO_DOC.Checked
        Me.MN_DOC_HASTA.Enabled = Me.RB_TIPO_DOC.Checked
    End Sub

    Private Sub BT_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_4.Click
        Me.BT_4.Enabled = False

        Dim xp As String = ""
        If Me.RB_TIPO_DOC.Checked Then
            xp = "Estas Seguro De Imprimir Este Rango De Documentos Fiscales ?"
            If MessageBox.Show(xp, "*** ALERTA ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    g_MiData.f_FichaGlobal.f_PermisosUsuario.op_VisorFiscal_Reportes_Doc.F_Permitir()
                    If Me.MN_DOC_INICIO._Valor > 0 And MN_DOC_INICIO._Valor <= MN_DOC_HASTA._Valor Then
                    Else
                        Throw New Exception("NUMERO DE DOCUMENTO INVALIDO... VERIFIQUE POR FAVOR")
                    End If

                    If Me.MCB_TIPO_DOC.SelectedIndex = 0 Then
                        g_ImpFiscal.ReImprimirDocumentos(ImpFiscales.MisFiscales.IFiscal.TipoDoc.Factura, Me.MN_DOC_INICIO._Valor, Me.MN_DOC_HASTA._Valor)
                    Else
                        g_ImpFiscal.ReImprimirDocumentos(ImpFiscales.MisFiscales.IFiscal.TipoDoc.NotaCredito, Me.MN_DOC_INICIO._Valor, Me.MN_DOC_HASTA._Valor)
                    End If

                    Funciones.MensajeDeOk("Proceso Realizado Con Exito")
                Catch ex As Exception
                    Funciones.MensajeDeError(ex.Message)
                End Try
            End If
        Else
            Funciones.MensajeDeAlerta("Reportes Documentos Acumulados" + vbCrLf + "!!! DEBES SELECCIONAR UNA OPCION DE LA LISTA !!!")
        End If
        Me.MN_DOC_INICIO.Text = "1"
        Me.MN_DOC_HASTA.Text = "1"
        Me.MCB_TIPO_DOC.SelectedIndex = 0
        Me.RB_TIPO_DOC.Checked = False

        With Me.BT_4
            .Enabled = True
            .Focus()
            .Select()
        End With
    End Sub

    Private Sub MN_DOC_INICIO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MN_DOC_INICIO.Validating
        MyBase.Validate()
        If Me.MN_DOC_INICIO._Valor >= Me.MN_DOC_HASTA._Valor Then
            Me.MN_DOC_HASTA.Text = Me.MN_DOC_INICIO.Text
        End If
    End Sub

    Private Sub MN_DOC_HASTA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MN_DOC_HASTA.Validating
        MyBase.Validate()
        If Me.MN_DOC_HASTA._Valor <= Me.MN_DOC_INICIO._Valor Then
            Me.MN_DOC_HASTA.Text = Me.MN_DOC_INICIO.Text
        End If
    End Sub
End Class