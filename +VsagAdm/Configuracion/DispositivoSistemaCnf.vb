Imports System.Xml

Public Class DispositivoSistemaCnf
    Dim xtb1 As DataTable
    Dim xtb2 As DataTable
    Dim xtb3 As DataTable
    Dim xtb4 As DataTable


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case Me.TabControl1.SelectedIndex
            Case 0
                Me.PB_IMAGEN.Image = My.Resources.ImpFiscal_1
                Me.BT_PRUEBA.Enabled = True
            Case 1
                Me.PB_IMAGEN.Image = My.Resources.Serie_1
                Me.BT_PRUEBA.Enabled = False
            Case 2
                Me.PB_IMAGEN.Image = My.Resources.PoleDisplay_1
                Me.BT_PRUEBA.Enabled = True
            Case 3
                Me.PB_IMAGEN.Image = My.Resources.EPSONLX300
                Me.BT_PRUEBA.Enabled = True
        End Select
    End Sub

    Sub Inicializa()
        Try
            xtb1 = New DataTable
            xtb2 = New DataTable
            xtb3 = New DataTable
            xtb4 = New DataTable

            Me.TabControl1.SelectedTab = TabPage3
            Me.TabControl1.SelectedIndex = 0
            Me.PB_IMAGEN.Image = My.Resources.ImpFiscal_1
            Me.BT_PRUEBA.Enabled = True

            Me.MCB_FISCAL_PUERTO.DataSource = [Enum].GetValues(GetType(ImpFiscales.MisFiscales.Com))
            Me.MCB_FISCAL_MODELO.DataSource = [Enum].GetValues(GetType(ImpFiscales.MisFiscales.ModelosFiscales))
            Me.MCB_VISOR_PUERTO.DataSource = [Enum].GetValues(GetType(Global.VisorPrecio.MiVisorFiscal.MiVisorPrecio.Com))

            'CARGA DE SERIES
            g_MiData.F_GetData("select nombre from series_fiscales where estatus='Activo' order by nombre", xtb1)
            g_MiData.F_GetData("select nombre from series_fiscales where estatus='Activo' order by nombre", xtb2)
            g_MiData.F_GetData("select nombre from series_fiscales where estatus='Activo' order by nombre", xtb3)
            g_MiData.F_GetData("select nombre from series_fiscales where estatus='Activo' order by nombre", xtb4)

            'COMBO PARA SERIE FACTURA
            With Me.MCB_SERIE_FACTURA
                .DataSource = xtb1
                .DisplayMember = "nombre"
                .ValueMember = "NOMBRE"
            End With

            'COMBO PARA SERIE NC
            With Me.MCB_SERIE_NC
                .DataSource = xtb2
                .DisplayMember = "nombre"
                .ValueMember = "NOMBRE"
            End With

            'COMBO PARA SERIE ND
            With Me.MCB_SERIE_ND
                .DataSource = xtb3
                .DisplayMember = "nombre"
                .ValueMember = "NOMBRE"
            End With

            'COMBO PARA SERIE NE
            With Me.MCB_SERIE_NE
                .DataSource = xtb4
                .DisplayMember = "nombre"
                .ValueMember = "NOMBRE"
            End With

            'Imp Fiscal
            Me.MCHB_FISCAL.Checked = Not g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Estatus
            Me.MCHB_FISCAL.Checked = g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Estatus
            Me.MCB_FISCAL_PUERTO.SelectedIndex = g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._puerto
            Me.MCB_FISCAL_MODELO.SelectedIndex = g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Modelo - 1

            'VISOR PRECIO
            Me.MCHB_VISOR.Checked = Not g_ConfiguracionSistema._Dispositivos._VisorPrecio._Estatus
            Me.MCHB_VISOR.Checked = g_ConfiguracionSistema._Dispositivos._VisorPrecio._Estatus
            Me.MCB_VISOR_PUERTO.SelectedIndex = g_ConfiguracionSistema._Dispositivos._VisorPrecio._Puerto

            'Series Documentos
            Me.MCB_SERIE_FACTURA.SelectedValue = g_ConfiguracionSistema._SerieFactura
            Me.MCB_SERIE_NC.SelectedValue = g_ConfiguracionSistema._SerieNotaCredito
            Me.MCB_SERIE_ND.SelectedValue = g_ConfiguracionSistema._SerieNotaDebito
            Me.MCB_SERIE_NE.SelectedValue = g_ConfiguracionSistema._SerieNotaEntegra

            Me.RUTA_IMPRESORA.Text = g_ConfiguracionSistema._RutaImpresoraTexto
            Me.RUTA_IMPRESORA_NOTA.Text = g_ConfiguracionSistema._RutaImpresoraTextoNotas
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        Select Case Me.TabControl1.SelectedIndex
            Case 2
                If MessageBox.Show("Deseas Guardar Esta Configuracion Para Este Visor De Precio ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarVisor()
                End If
            Case 0
                If MessageBox.Show("Deseas Guardar Esta Configuracion Para Esta Impresora Fiscal ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarFiscal()
                End If
            Case 1
                If MessageBox.Show("Deseas Asignar Estos Seriales De Documentos Al Sistema Para Poder Trabajar ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarSeries()
                End If
            Case 3
                If MessageBox.Show("Deseas Guardar Esta Configuracion ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarRutaImpresora()
                End If
        End Select
    End Sub

    Sub ActualizarVisor()
        Try
            GrabarImpFiscal(4)
            Funciones.MensajeDeOk("CONFIGURACION GRABADA CON EXITO...")
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarFiscal()
        Try
            GrabarImpFiscal(1)
            Funciones.MensajeDeOk("CONFIGURACION GRABADA CON EXITO")
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarRutaImpresora()
        Try
            GrabarImpFiscal(5)
            Funciones.MensajeDeOk("CONFIGURACION GRABADA CON EXITO")
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Function GrabarImpFiscal(ByVal xgrupo As Integer) As Boolean
        Try
            Dim doc As New XmlDocument
            doc.Load(My.Application.Info.DirectoryPath + "\Configuracion.XML")

            If doc.HasChildNodes Then
                For Each node_raiz As XmlNode In doc
                    If node_raiz.LocalName.ToUpper.Trim = "CONFIGURACION" Then
                        For Each xnode_elemento As XmlNode In node_raiz.ChildNodes
                            If xnode_elemento.LocalName.ToUpper.Trim = "DISPOSITIVOS" Then
                                For Each s1nodo As XmlNode In xnode_elemento.ChildNodes
                                    If s1nodo.LocalName.ToUpper.Trim = "IMPRESORAFISCAL" Then
                                        For Each s2nodo As XmlNode In s1nodo.ChildNodes
                                            If xgrupo = 1 Then
                                                If s2nodo.LocalName.ToUpper.Trim = "ACTIVAR" Then
                                                    If Me.MCHB_FISCAL.Checked Then
                                                        s2nodo.InnerText = "SI"
                                                    Else
                                                        s2nodo.InnerText = "NO"
                                                    End If
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "PUERTOCONECTAR" Then
                                                    Dim x As Integer = Me.MCB_FISCAL_PUERTO.SelectedIndex
                                                    s2nodo.InnerText = x.ToString.Trim.PadLeft(2, "0")
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "MODELOUSAR" Then
                                                    Dim x As Integer = Me.MCB_FISCAL_MODELO.SelectedIndex + 1
                                                    s2nodo.InnerText = x.ToString.Trim.PadLeft(2, "0")
                                                End If
                                            End If
                                        Next
                                    End If

                                    If xgrupo = 4 Then
                                        If s1nodo.LocalName.ToUpper.Trim = "VISORPRECIOS" Then
                                            For Each s2nodo As XmlNode In s1nodo.ChildNodes
                                                If s2nodo.LocalName.ToUpper.Trim = "ACTIVAR" Then
                                                    If Me.MCHB_VISOR.Checked Then
                                                        s2nodo.InnerText = "SI"
                                                    Else
                                                        s2nodo.InnerText = "NO"
                                                    End If
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "PUERTOCONECTAR" Then
                                                    Dim x As Integer = Me.MCB_VISOR_PUERTO.SelectedIndex
                                                    s2nodo.InnerText = x.ToString.Trim.PadLeft(2, "0")
                                                End If
                                            Next
                                        End If
                                    End If
                                Next
                            End If

                            If xgrupo = 3 Then
                                If xnode_elemento.LocalName.ToUpper.Trim = "VARIABLESDECONFIGURACION" Then
                                    For Each s2nodo As XmlNode In xnode_elemento.ChildNodes
                                        If s2nodo.LocalName.ToUpper.Trim = "DEFINESERIESDOCUMENTOS" Then
                                            For Each s3nodo As XmlNode In s2nodo.ChildNodes
                                                If s3nodo.LocalName.ToUpper.Trim = "FACTURA" Then
                                                    If Me.MCB_SERIE_FACTURA.SelectedIndex >= 0 Then
                                                        s3nodo.InnerText = Me.MCB_SERIE_FACTURA.SelectedValue.ToString.Trim
                                                    Else
                                                        s3nodo.InnerText = ""
                                                    End If
                                                End If
                                                If s3nodo.LocalName.ToUpper.Trim = "NOTAENTREGA" Then
                                                    If Me.MCB_SERIE_NE.SelectedIndex >= 0 Then
                                                        s3nodo.InnerText = Me.MCB_SERIE_NE.SelectedValue.ToString.Trim
                                                    Else
                                                        s3nodo.InnerText = ""
                                                    End If
                                                End If
                                                If s3nodo.LocalName.ToUpper.Trim = "NOTACREDITO" Then
                                                    If Me.MCB_SERIE_NC.SelectedIndex >= 0 Then
                                                        s3nodo.InnerText = Me.MCB_SERIE_NC.SelectedValue.ToString.Trim
                                                    Else
                                                        s3nodo.InnerText = ""
                                                    End If
                                                End If
                                                If s3nodo.LocalName.ToUpper.Trim = "NOTADEBITO" Then
                                                    If Me.MCB_SERIE_ND.SelectedIndex >= 0 Then
                                                        s3nodo.InnerText = Me.MCB_SERIE_ND.SelectedValue.ToString.Trim
                                                    Else
                                                        s3nodo.InnerText = ""
                                                    End If
                                                End If
                                            Next
                                        End If
                                    Next
                                End If
                            End If

                            If xgrupo = 5 Then
                                If xnode_elemento.LocalName.ToUpper.Trim = "RUTAIMPRESORATEXTO" Then
                                    xnode_elemento.InnerText = Me.RUTA_IMPRESORA.Text.Trim
                                End If
                                If xnode_elemento.LocalName.ToUpper.Trim = "RUTAIMPRESORATEXTOOTRAS" Then
                                    xnode_elemento.InnerText = Me.RUTA_IMPRESORA_NOTA.Text.Trim
                                End If
                            End If
                        Next
                    End If
                Next
            End If
            doc.Save(My.Application.Info.DirectoryPath + "\Configuracion.XML")
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub ActualizarSeries()
        Try
            GrabarImpFiscal(3)
            Funciones.MensajeDeOk("CONFIGURACION GRABADA CON EXITO...")
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub MCHB_VISOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_VISOR.CheckedChanged
        Me.MCB_VISOR_PUERTO.Enabled = Me.MCHB_VISOR.Checked
    End Sub

    Private Sub MCHB_FISCAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_FISCAL.CheckedChanged
        Me.MCB_FISCAL_PUERTO.Enabled = Me.MCHB_FISCAL.Checked
        Me.MCB_FISCAL_MODELO.Enabled = Me.MCHB_FISCAL.Checked
    End Sub

    Private Sub BT_PRUEBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PRUEBA.Click
        Select Case Me.TabControl1.SelectedIndex
            Case 2
                PruebaVisorPrecio()
            Case 0
                PruebaFiscal()
        End Select
    End Sub

    Sub PruebaVisorPrecio()
        Try
            If Me.MCHB_VISOR.Checked Then
                Dim xvisor As New Global.VisorPrecio.MiVisorFiscal.MiVisorPrecio(Me.MCB_VISOR_PUERTO.SelectedIndex)
                With xvisor
                    .Texto("HOLA", " TODO OK")
                End With
                MessageBox.Show("Verifica si en el visor de precio aparece un mensaje indcando lo siguiente: HOLA, TODO OK", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Funciones.MensajeDeAlerta("NO SE HA DEFINIDO UN VISOR DE PRECIO... VERIFIQUE POR FAVOR")
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub PruebaFiscal()
        Try
            If Me.MCHB_FISCAL.Checked Then
                Dim xfiscal As ImpFiscales.MisFiscales.IFiscal
                Select Case (Me.MCB_FISCAL_MODELO.SelectedIndex + 1)
                    Case ImpFiscales.MisFiscales.ModelosFiscales.Bixolon_270, ImpFiscales.MisFiscales.ModelosFiscales.Bixolon_350, _
                        ImpFiscales.MisFiscales.ModelosFiscales.Kube, ImpFiscales.MisFiscales.ModelosFiscales.Star
                        xfiscal = New ImpFiscales.MisFiscales.Samsung(0, ImpFiscales.MisFiscales.Samsung.xModelosFiscales.Bixolon_270)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.Bixolon_350
                        xfiscal = New ImpFiscales.MisFiscales.Samsung_350(0)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.BIXOLON_812
                        xfiscal = New ImpFiscales.MisFiscales.BIXOLON_812(0)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.Aclas
                        xfiscal = New ImpFiscales.MisFiscales.Aclas(0, ImpFiscales.MisFiscales.Aclas.xModelosFiscales.Aclas)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.BmcSpark_614
                        xfiscal = New ImpFiscales.MisFiscales.BMC(0, ImpFiscales.MisFiscales.BMC.xModelosFiscales.BmcSpark_614)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.EPSON_PF220
                        xfiscal = New ImpFiscales.MisFiscales.Epson_PF220(0, ImpFiscales.MisFiscales.ModelosFiscales.EPSON_PF220)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.EPSON_PF300, _
                        ImpFiscales.MisFiscales.ModelosFiscales.EPSON_PF300_BLANCA
                        xfiscal = New ImpFiscales.MisFiscales.Epson_PF300(0, ImpFiscales.MisFiscales.ModelosFiscales.EPSON_PF300)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.MP_4000
                        xfiscal = New ImpFiscales.MisFiscales.Bematech(0, ImpFiscales.MisFiscales.ModelosFiscales.MP_4000)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.Dascom_Tally_1125
                        xfiscal = New ImpFiscales.MisFiscales.DasconTally(0)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.Oki
                        xfiscal = New ImpFiscales.MisFiscales.Oky(0)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.HKA112
                        xfiscal = New ImpFiscales.MisFiscales.HKA_112(0)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.CUSTOM_KUBE_II
                        xfiscal = New ImpFiscales.MisFiscales.Custom_KUBE_II(0)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.DT230
                        'xfiscal = New ImpFiscales.MisFiscales.DT230(0)
                        xfiscal = New ImpFiscales.MisFiscales.DT230_Fachada(Me.MCB_FISCAL_PUERTO.SelectedIndex)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.ACLAS_PP9
                        xfiscal = New ImpFiscales.MisFiscales.ACLAS_PP9(Me.MCB_FISCAL_PUERTO.SelectedIndex)

                    Case ImpFiscales.MisFiscales.ModelosFiscales.LIB_FISCAL_TFHKA
                        xfiscal = New ImpFiscales.MisFiscales.Tfhka(Me.MCB_FISCAL_PUERTO.SelectedIndex)

                    Case Else
                        xfiscal = Nothing
                End Select

                If xfiscal IsNot Nothing Then
                    With xfiscal
                        .PuertoConexion = Me.MCB_FISCAL_PUERTO.SelectedIndex
                        MessageBox.Show("Encienda la impresora y verifique que tenga papel, se va a enviar un texto de prueba", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        .TextoDNF("HOLA A TODOS....")
                    End With
                Else
                    Funciones.MensajeDeAlerta("NO SE HA DEFINIDO UNA IMPRESORA FISCAL... VERIFIQUE POR FAVOR")
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub DispositivoSistemaCnf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub DispositivoSistemaCnf_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub DispositivoSistemaCnf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BT_IMPRESORA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_IMPRESORA.Click
        Try
            With Me.PrintDialog1
                .PrinterSettings.PrinterName = g_ConfiguracionSistema._RutaImpresoraTexto
                .ShowDialog()
                Me.RUTA_IMPRESORA.Text = .PrinterSettings.PrinterName
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub BT_LIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_LIMPIAR.Click
        Me.RUTA_IMPRESORA.Text = ""
    End Sub

    Private Sub BT_IMPRESORA_NOTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_IMPRESORA_NOTA.Click
        Try
            With Me.PrintDialog1
                .PrinterSettings.PrinterName = g_ConfiguracionSistema._RutaImpresoraTextoNotas
                .ShowDialog()
                Me.RUTA_IMPRESORA_NOTA.Text = .PrinterSettings.PrinterName
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub BT_LIMPIAR_NOTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_LIMPIAR_NOTA.Click
        Me.RUTA_IMPRESORA_NOTA.Text = ""
    End Sub

End Class