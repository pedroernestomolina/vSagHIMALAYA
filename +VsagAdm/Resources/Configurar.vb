Imports System.Xml

Public Class Configurar
    Dim xtb1 As DataTable
    Dim xtb2 As DataTable

    Private Sub Configurar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case Me.TabControl1.SelectedIndex
            Case 0
                Me.PB_IMAGEN.Image = My.Resources.Balanza_1
                Me.BT_PRUEBA.Enabled = True
            Case 1
                Me.PB_IMAGEN.Image = My.Resources.PreEmpaque_1
                Me.BT_PRUEBA.Enabled = False
            Case 2
                Me.PB_IMAGEN.Image = My.Resources.BalanzaColgante_1
                Me.BT_PRUEBA.Enabled = False
            Case 3
                Me.PB_IMAGEN.Image = My.Resources.PoleDisplay_1
                Me.BT_PRUEBA.Enabled = True
            Case 4
                Me.PB_IMAGEN.Image = My.Resources.ImpFiscal_1
                Me.BT_PRUEBA.Enabled = True
            Case 5
                Me.PB_IMAGEN.Image = My.Resources.AsignarSerial_1
                Me.BT_PRUEBA.Enabled = False
            Case 6
                Me.PB_IMAGEN.Image = My.Resources.Serie_1
                Me.BT_PRUEBA.Enabled = False
            Case 7
                Me.PB_IMAGEN.Image = My.Resources.DataActualizar
                Me.BT_PRUEBA.Enabled = False
        End Select
    End Sub

    Sub Inicializa()
        Try
            xtb1 = New DataTable
            xtb2 = New DataTable

            Me.TabControl1.SelectedIndex = 0

            Me.MCB_FISCAL_PUERTO.DataSource = [Enum].GetValues(GetType(ImpFiscales.MisFiscales.Com))
            Me.MCB_FISCAL_MODELO.DataSource = [Enum].GetValues(GetType(ImpFiscales.MisFiscales.ModelosFiscales))
            Me.MCB_VISOR_PUERTO.DataSource = [Enum].GetValues(GetType(VisorPrecio.MiVisorFiscal.MiVisorPrecio.Com))
            Me.MCB_BAL_MODELO.DataSource = [Enum].GetValues(GetType(Balanzas.MisBalanzas.ModeloBalanza))
            Me.MCB_BAL_PUERTO.DataSource = [Enum].GetValues(GetType(Balanzas.MisBalanzas.Com))

            Me.E_SERIAL.Text = ""

            'CARGA DE SERIES
            _MiData.F_GetData("select nombre from series_fiscales where estatus='Activo' order by nombre", xtb1)
            _MiData.F_GetData("select nombre from series_fiscales where estatus='Activo' order by nombre", xtb2)

            'COMBO PARA SERIE FACTURA
            Me.MCB_SERIE_FACTURA.DataSource = xtb1
            Me.MCB_SERIE_FACTURA.DisplayMember = "nombre"
            Me.MCB_SERIE_FACTURA.ValueMember = "NOMBRE"

            'COMBO PARA SERIE NC
            Me.MCB_SERIE_NC.DataSource = xtb2
            Me.MCB_SERIE_NC.DisplayMember = "nombre"
            Me.MCB_SERIE_NC.ValueMember = "NOMBRE"

            'Imp Fiscal
            Me.MCHB_FISCAL.Checked = Not _DataCnfDispositivos._ImpFiscal._Estatus
            Me.MCHB_FISCAL.Checked = _DataCnfDispositivos._ImpFiscal._Estatus
            Me.MCB_FISCAL_PUERTO.SelectedIndex = _DataCnfDispositivos._ImpFiscal._Puerto
            Me.MCB_FISCAL_MODELO.SelectedIndex = (_DataCnfDispositivos._ImpFiscal._Modelo - 1)

            'VISOR PRECIO
            Me.MCHB_VISOR.Checked = Not _DataCnfDispositivos._Visor._Estatus
            Me.MCHB_VISOR.Checked = _DataCnfDispositivos._Visor._Estatus
            Me.MCB_VISOR_PUERTO.SelectedIndex = _DataCnfDispositivos._Visor._Puerto

            'Serial Fiscal
            Me.E_SERIAL.Text = _DataCnfDispositivos._ImpFiscal._Serial

            'Series Documentos
            Me.MCB_SERIE_FACTURA.SelectedValue = _DataCnfDispositivos._SeriesDocumento._Factura
            Me.MCB_SERIE_NC.SelectedValue = _DataCnfDispositivos._SeriesDocumento._NotaCredito

            'BALANZA
            Me.MCHB_BALANZA.Checked = Not _DataCnfDispositivos._Balanza._Estatus
            Me.MCHB_BALANZA.Checked = _DataCnfDispositivos._Balanza._Estatus
            Me.MCB_BAL_PUERTO.SelectedIndex = _DataCnfDispositivos._Balanza._Puerto
            Me.MCB_BAL_MODELO.SelectedIndex = (_DataCnfDispositivos._Balanza._Modelo - 1)
            Me.RB_BAL_ELECT.Checked = IIf(_DataCnfDispositivos._Balanza._TipoUsar = ConfiguraDispositivos.Balanza.TipoUsar.Auto, True, False)
            Me.RB_BAL_MANUAL.Checked = IIf(_DataCnfDispositivos._Balanza._TipoUsar = ConfiguraDispositivos.Balanza.TipoUsar.Manual, True, False)

            'CONTROL VENTAS
            Me.MCH_VENTA_MONITOR.Checked = _DataConfiguracion._ControlVentas._Monitoreo
            Me.MCH_VENTA_DEPARTAMENTO.Checked = _DataConfiguracion._ControlVentas._VentaDepartamento
            Me.MCH_VENTA_MAYOR.Checked = _DataConfiguracion._ControlVentas._VentaAlMayor

            'PRE-EMPAQUE
            Me.MCH_PRE_EMPAQUE.Checked = Not _DataCnfDispositivos._PreEmpaque._Estatus
            Me.MCH_PRE_EMPAQUE.Checked = _DataCnfDispositivos._PreEmpaque._Estatus
            Me.MT_PRE_EMPAQUE.Text = _DataCnfDispositivos._PreEmpaque._Formato

            'TICKET
            Me.MCH_TICKET.Checked = Not _DataCnfDispositivos._TicketBalanza._Estatus
            Me.MCH_TICKET.Checked = _DataCnfDispositivos._TicketBalanza._Estatus
            Me.MT_TICKET.Text = _DataCnfDispositivos._TicketBalanza._Formato
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub MCHB_BALANZA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHB_BALANZA.CheckedChanged
        Me.RB_BAL_MANUAL.Enabled = Me.MCHB_BALANZA.Checked
        Me.RB_BAL_ELECT.Enabled = Me.MCHB_BALANZA.Checked
        Me.MCB_BAL_PUERTO.Enabled = Me.MCHB_BALANZA.Checked
        Me.MCB_BAL_MODELO.Enabled = Me.MCHB_BALANZA.Checked
    End Sub

    Private Sub BT_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GUARDAR.Click
        Select Case Me.TabControl1.SelectedIndex
            Case 0
                If MessageBox.Show("Deseas Guardar Esta Configuracion Para Esta Balanza ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarBalanza()
                End If
            Case 1
                If MessageBox.Show("Deseas Guardar Esta Configuracion Para PRE - EMPAQUE ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarPreEmpaque()
                End If
            Case 2
                If MessageBox.Show("Deseas Guardar Esta Configuracion Para Los Tickets Generados Por La Balanza ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarTicket()
                End If
            Case 3
                If MessageBox.Show("Deseas Guardar Esta Configuracion Para Este Visor De Precio ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarVisor()
                End If
            Case 4
                If MessageBox.Show("Deseas Guardar Esta Configuracion Para Esta Impresora Fiscal ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarFiscal()
                End If
            Case 5
                If Me.E_SERIAL.Text.Trim <> "" Then
                    If MessageBox.Show("Deseas Asignar Este Serial De Impresora Al Sistema Para Poder Trabajar ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        ActualizarSerial()
                    End If
                Else
                    MessageBox.Show("ERROR... NO HAY NINGUN SERIAL ASIGNADO, VERIFIQUE POR FAVOR", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Case 6
                If MessageBox.Show("Deseas Asignar Estos Seriales De Documentos Al Sistema Para Poder Trabajar ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarSeries()
                End If
            Case 7
                If MessageBox.Show("Deseas Guardar Esta Configuracion De Ventas ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ActualizarControlVentas()
                End If
        End Select
    End Sub

    Sub ActualizarBalanza()
        Try
            _DataCnfDispositivos._Balanza._Estatus = Me.MCHB_BALANZA.Checked
            _DataCnfDispositivos._Balanza._Modelo = CType((Me.MCB_BAL_MODELO.SelectedIndex + 1), Balanzas.MisBalanzas.ModeloBalanza)
            _DataCnfDispositivos._Balanza._Puerto = Me.MCB_BAL_PUERTO.SelectedIndex
            If Me.RB_BAL_ELECT.Checked Then
                _DataCnfDispositivos._Balanza._TipoUsar = ConfiguraDispositivos.Balanza.TipoUsar.Auto
            End If
            If Me.RB_BAL_MANUAL.Checked Then
                _DataCnfDispositivos._Balanza._TipoUsar = ConfiguraDispositivos.Balanza.TipoUsar.Manual
            End If

            If _DataCnfDispositivos._Balanza._Estatus Then
                If BalanzaSoloPeso IsNot Nothing Then
                    With BalanzaSoloPeso
                        .Modelo = _DataCnfDispositivos._Balanza._Modelo
                        .Puerto = _DataCnfDispositivos._Balanza._Puerto
                    End With
                Else
                    BalanzaSoloPeso = New Balanzas.MisBalanzas.TipoBalanza
                    With BalanzaSoloPeso
                        .Modelo = _DataCnfDispositivos._Balanza._Modelo
                        .Puerto = _DataCnfDispositivos._Balanza._Puerto
                    End With
                End If
            Else
                BalanzaSoloPeso = Nothing
            End If
            GrabarImpFiscal(5)
            Funciones.MensajeOk("CONFIGURACION GRABADA CON EXITO")
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarPreEmpaque()
        Try
            If Me.MCH_PRE_EMPAQUE.Checked Then
                If Me.MT_PRE_EMPAQUE.r_Valor = "" Then
                    Throw New Exception("HACE FALTA ESPECIFICAR EL FORMATO A DECODIFICAR")
                End If
            End If

            _DataCnfDispositivos._PreEmpaque._Estatus = Me.MCH_PRE_EMPAQUE.Checked
            _DataCnfDispositivos._PreEmpaque._Formato = Me.MT_PRE_EMPAQUE.r_Valor

            GrabarImpFiscal(8)
            Funciones.MensajeOk("CONFIGURACION GRABADA CON EXITO")
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarTicket()
        Try
            If Me.MCH_TICKET.Checked Then
                If Me.MT_TICKET.r_Valor = "" Then
                    Throw New Exception("HACE FALTA ESPECIFICAR EL FORMATO A DECODIFICAR")
                End If
            End If

            _DataCnfDispositivos._TicketBalanza._Estatus = Me.MCH_TICKET.Checked
            _DataCnfDispositivos._TicketBalanza._Formato = Me.MT_TICKET.r_Valor

            GrabarImpFiscal(9)
            Funciones.MensajeOk("CONFIGURACION GRABADA CON EXITO")
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarVisor()
        Try
            _DataCnfDispositivos._Visor._Estatus = Me.MCHB_VISOR.Checked
            _DataCnfDispositivos._Visor._Puerto = Me.MCB_VISOR_PUERTO.SelectedIndex

            If VisorPrecioPtoventa Is Nothing Then
                If _DataCnfDispositivos._Visor._Estatus Then
                    VisorPrecioPtoventa = New VisorPrecio.MiVisorFiscal.MiVisorPrecio(_DataCnfDispositivos._Visor._Puerto)
                End If
            Else
                If _DataCnfDispositivos._Visor._Estatus Then
                    VisorPrecioPtoventa.puerto = _DataCnfDispositivos._Visor._Puerto
                Else
                    VisorPrecioPtoventa = Nothing
                End If
            End If

            GrabarImpFiscal(4)
            Funciones.MensajeOk("CONFIGURACION GRABADA CON EXITO")
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarFiscal()
        Try
            If ImpresoraFiscal Is Nothing Then
                If Me.MCHB_FISCAL.Checked Then
                    Select Case Me.MCB_FISCAL_MODELO.SelectedIndex
                        Case 0, 1, 2, 3, 6, 7
                            Dim modelo As ImpFiscales.MisFiscales.ModelosFiscales = CType([Enum].Parse(GetType(ImpFiscales.MisFiscales.ModelosFiscales), _
                                                       Me.MCB_FISCAL_MODELO.SelectedItem.ToString),  _
                                                       ImpFiscales.MisFiscales.ModelosFiscales)
                            ImpresoraFiscal = New ImpFiscales.MisFiscales.Samsung(Me.MCB_FISCAL_PUERTO.SelectedIndex, modelo)
                            _DataCnfDispositivos._ImpFiscal._Estatus = True
                            _DataCnfDispositivos._ImpFiscal._Modelo = modelo
                            _DataCnfDispositivos._ImpFiscal._Puerto = Me.MCB_FISCAL_PUERTO.SelectedIndex

                        Case 4, 5
                            Dim modelo As ImpFiscales.MisFiscales.ModelosFiscales = CType([Enum].Parse(GetType(ImpFiscales.MisFiscales.ModelosFiscales), _
                                                       Me.MCB_FISCAL_MODELO.SelectedItem.ToString),  _
                                                       ImpFiscales.MisFiscales.ModelosFiscales)
                            ImpresoraFiscal = New ImpFiscales.MisFiscales.Epson(Me.MCB_FISCAL_PUERTO.SelectedIndex, modelo)
                            _DataCnfDispositivos._ImpFiscal._Estatus = True
                            _DataCnfDispositivos._ImpFiscal._Modelo = modelo
                            _DataCnfDispositivos._ImpFiscal._Puerto = Me.MCB_FISCAL_PUERTO.SelectedIndex

                        Case 8
                            Dim modelo As ImpFiscales.MisFiscales.ModelosFiscales = CType([Enum].Parse(GetType(ImpFiscales.MisFiscales.ModelosFiscales), _
                                                       Me.MCB_FISCAL_MODELO.SelectedItem.ToString),  _
                                                       ImpFiscales.MisFiscales.ModelosFiscales)
                            ImpresoraFiscal = New ImpFiscales.MisFiscales.Bematech(Me.MCB_FISCAL_PUERTO.SelectedIndex, modelo)
                            _DataCnfDispositivos._ImpFiscal._Estatus = True
                            _DataCnfDispositivos._ImpFiscal._Modelo = modelo
                            _DataCnfDispositivos._ImpFiscal._Puerto = Me.MCB_FISCAL_PUERTO.SelectedIndex
                    End Select
                Else
                    ImpresoraFiscal = Nothing
                    _DataCnfDispositivos._ImpFiscal._Estatus = False
                End If
            Else
                If Me.MCHB_FISCAL.Checked Then
                    Select Case Me.MCB_FISCAL_MODELO.SelectedIndex
                        Case 0, 1, 2, 3, 6, 7
                            Dim modelo As ImpFiscales.MisFiscales.ModelosFiscales = CType([Enum].Parse(GetType(ImpFiscales.MisFiscales.ModelosFiscales), _
                                                       Me.MCB_FISCAL_MODELO.SelectedItem.ToString),  _
                                                       ImpFiscales.MisFiscales.ModelosFiscales)
                            ImpresoraFiscal = New ImpFiscales.MisFiscales.Samsung(Me.MCB_FISCAL_PUERTO.SelectedIndex, modelo)
                            _DataCnfDispositivos._ImpFiscal._Estatus = True
                            _DataCnfDispositivos._ImpFiscal._Modelo = modelo
                            _DataCnfDispositivos._ImpFiscal._Puerto = Me.MCB_FISCAL_PUERTO.SelectedIndex

                        Case 4, 5
                            Dim modelo As ImpFiscales.MisFiscales.ModelosFiscales = CType([Enum].Parse(GetType(ImpFiscales.MisFiscales.ModelosFiscales), _
                                                       Me.MCB_FISCAL_MODELO.SelectedItem.ToString),  _
                                                       ImpFiscales.MisFiscales.ModelosFiscales)
                            ImpresoraFiscal = New ImpFiscales.MisFiscales.Epson(Me.MCB_FISCAL_PUERTO.SelectedIndex, modelo)
                            _DataCnfDispositivos._ImpFiscal._Estatus = True
                            _DataCnfDispositivos._ImpFiscal._Modelo = modelo
                            _DataCnfDispositivos._ImpFiscal._Puerto = Me.MCB_FISCAL_PUERTO.SelectedIndex

                        Case 8
                            Dim modelo As ImpFiscales.MisFiscales.ModelosFiscales = CType([Enum].Parse(GetType(ImpFiscales.MisFiscales.ModelosFiscales), _
                                                       Me.MCB_FISCAL_MODELO.SelectedItem.ToString),  _
                                                       ImpFiscales.MisFiscales.ModelosFiscales)
                            ImpresoraFiscal = New ImpFiscales.MisFiscales.Bematech(Me.MCB_FISCAL_PUERTO.SelectedIndex, modelo)
                            _DataCnfDispositivos._ImpFiscal._Estatus = True
                            _DataCnfDispositivos._ImpFiscal._Modelo = modelo
                            _DataCnfDispositivos._ImpFiscal._Puerto = Me.MCB_FISCAL_PUERTO.SelectedIndex
                    End Select
                Else
                    ImpresoraFiscal = Nothing
                    _DataCnfDispositivos._ImpFiscal._Estatus = False
                End If
            End If

            GrabarImpFiscal(1)
            Funciones.MensajeOk("CONFIGURACION GRABADA CON EXITO")
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Function GrabarImpFiscal(ByVal xgrupo As Integer) As Boolean
        Try
            Dim doc As New XmlDocument
            doc.Load(_DataConfiguracion._UbicacionSistema & "\Configuracion.XML")

            If doc.HasChildNodes Then
                For Each node_raiz As XmlNode In doc
                    If node_raiz.LocalName.ToUpper.Trim = "CONFIGURACION" Then
                        For Each xnode_elemento As XmlNode In node_raiz.ChildNodes
                            If xnode_elemento.LocalName.ToUpper.Trim = "DISPOSITIVOS" Then
                                For Each s1nodo As XmlNode In xnode_elemento.ChildNodes
                                    If s1nodo.LocalName.ToUpper.Trim = "IMPFISCAL" Then
                                        For Each s2nodo As XmlNode In s1nodo.ChildNodes
                                            If xgrupo = 1 Then
                                                If s2nodo.LocalName.ToUpper.Trim = "ESTATUS" Then
                                                    If _DataCnfDispositivos._ImpFiscal._Estatus Then
                                                        s2nodo.InnerText = "SI"
                                                    Else
                                                        s2nodo.InnerText = "NO"
                                                    End If
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "PUERTO" Then
                                                    Dim x As Integer = _DataCnfDispositivos._ImpFiscal._Puerto
                                                    s2nodo.InnerText = x.ToString.Trim.PadLeft(2, "0")
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "MODELO" Then
                                                    Dim x As Integer = _DataCnfDispositivos._ImpFiscal._Modelo
                                                    s2nodo.InnerText = x.ToString.Trim.PadLeft(2, "0")
                                                End If
                                            End If
                                            If xgrupo = 2 Then
                                                If s2nodo.LocalName.ToUpper.Trim = "SERIAL" Then
                                                    s2nodo.InnerText = _DataCnfDispositivos._ImpFiscal._Serial
                                                End If
                                            End If
                                        Next
                                    End If

                                    If xgrupo = 4 Then
                                        If s1nodo.LocalName.ToUpper.Trim = "VISORPRECIO" Then
                                            For Each s2nodo As XmlNode In s1nodo.ChildNodes
                                                If s2nodo.LocalName.ToUpper.Trim = "ESTATUS" Then
                                                    If _DataCnfDispositivos._Visor._Estatus Then
                                                        s2nodo.InnerText = "SI"
                                                    Else
                                                        s2nodo.InnerText = "NO"
                                                    End If
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "PUERTO" Then
                                                    Dim x As Integer = _DataCnfDispositivos._Visor._Puerto
                                                    s2nodo.InnerText = x.ToString.Trim.PadLeft(2, "0")
                                                End If
                                            Next
                                        End If
                                    End If

                                    If xgrupo = 5 Then
                                        If s1nodo.LocalName.ToUpper.Trim = "BALANZA" Then
                                            For Each s2nodo As XmlNode In s1nodo.ChildNodes
                                                If s2nodo.LocalName.ToUpper.Trim = "ESTATUS" Then
                                                    If _DataCnfDispositivos._Balanza._Estatus Then
                                                        s2nodo.InnerText = "SI"
                                                    Else
                                                        s2nodo.InnerText = "NO"
                                                    End If
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "PUERTO" Then
                                                    Dim x As Integer = _DataCnfDispositivos._Balanza._Puerto
                                                    s2nodo.InnerText = x.ToString.Trim.PadLeft(2, "0")
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "MODELO" Then
                                                    Dim x As Integer = _DataCnfDispositivos._Balanza._Modelo
                                                    s2nodo.InnerText = x.ToString.Trim.PadLeft(2, "0")
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "TIPO" Then
                                                    If _DataCnfDispositivos._Balanza._TipoUsar = ConfiguraDispositivos.Balanza.TipoUsar.Auto Then
                                                        s2nodo.InnerText = "AUTO"
                                                    Else
                                                        s2nodo.InnerText = "MANUAL"
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If

                                    If xgrupo = 8 Then
                                        If s1nodo.LocalName.ToUpper.Trim = "PREEMPAQUE" Then
                                            For Each s2nodo As XmlNode In s1nodo.ChildNodes
                                                If s2nodo.LocalName.ToUpper.Trim = "ESTATUS" Then
                                                    If _DataCnfDispositivos._PreEmpaque._Estatus Then
                                                        s2nodo.InnerText = "SI"
                                                    Else
                                                        s2nodo.InnerText = "NO"
                                                    End If
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "FORMATO" Then
                                                    s2nodo.InnerText = _DataCnfDispositivos._PreEmpaque._Formato
                                                End If
                                            Next
                                        End If
                                    End If

                                    If xgrupo = 9 Then
                                        If s1nodo.LocalName.ToUpper.Trim = "TICKET_BALANZA" Then
                                            For Each s2nodo As XmlNode In s1nodo.ChildNodes
                                                If s2nodo.LocalName.ToUpper.Trim = "ESTATUS" Then
                                                    If _DataCnfDispositivos._TicketBalanza._Estatus Then
                                                        s2nodo.InnerText = "SI"
                                                    Else
                                                        s2nodo.InnerText = "NO"
                                                    End If
                                                End If
                                                If s2nodo.LocalName.ToUpper.Trim = "FORMATO" Then
                                                    s2nodo.InnerText = _DataCnfDispositivos._TicketBalanza._Formato
                                                End If
                                            Next
                                        End If
                                    End If

                                Next
                            End If

                            If xgrupo = 3 Then
                                If xnode_elemento.LocalName.ToUpper.Trim = "SERIESDOCUMENTOS" Then
                                    For Each s1nodo As XmlNode In xnode_elemento.ChildNodes
                                        If s1nodo.LocalName.ToUpper.Trim = "FACTURA" Then
                                            s1nodo.InnerText = _DataCnfDispositivos._SeriesDocumento._Factura
                                        End If
                                        If s1nodo.LocalName.ToUpper.Trim = "NOTACREDITO" Then
                                            s1nodo.InnerText = _DataCnfDispositivos._SeriesDocumento._NotaCredito
                                        End If
                                    Next
                                End If
                            End If

                            If xgrupo = 7 Then
                                If xnode_elemento.LocalName.ToUpper.Trim = "CONTROLVENTAS" Then
                                    For Each s1nodo As XmlNode In xnode_elemento.ChildNodes
                                        If s1nodo.LocalName.ToUpper.Trim = "ACTIVAR_VENTAS_MAYOR" Then
                                            If _DataConfiguracion._ControlVentas._VentaAlMayor Then
                                                s1nodo.InnerText = "SI"
                                            Else
                                                s1nodo.InnerText = "NO"
                                            End If
                                        End If
                                        If s1nodo.LocalName.ToUpper.Trim = "ACTIVAR_VENTAS_DEPARTAMENTO" Then
                                            If _DataConfiguracion._ControlVentas._VentaDepartamento Then
                                                s1nodo.InnerText = "SI"
                                            Else
                                                s1nodo.InnerText = "NO"
                                            End If
                                        End If
                                        If s1nodo.LocalName.ToUpper.Trim = "ACTIVAR_MONITOREO" Then
                                            If _DataConfiguracion._ControlVentas._Monitoreo Then
                                                s1nodo.InnerText = "SI"
                                            Else
                                                s1nodo.InnerText = "NO"
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            End If
            doc.Save(_DataConfiguracion._UbicacionSistema & "\Configuracion.XML")
            Return True
        Catch ex As Exception
            Throw New Exception("MODULO: FUNCIONES - CARGAR XML" + vbCrLf + ex.Message + vbCrLf)
        End Try
    End Function

    Sub ActualizarSerial()
        Try
            If ImpresoraFiscal IsNot Nothing Then
                _DataCnfDispositivos._ImpFiscal._Serial = Me.E_SERIAL.Text.Trim
                GrabarImpFiscal(2)
                Funciones.MensajeOk("CONFIGURACION GRABADA CON EXITO")
            Else
                Funciones.MensajeAlerta("IMPRESORA FISCAL NO DEFINIDA... VERIFIQUE POR FAVOR")
            End If
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarSeries()
        Try
            If Me.MCB_SERIE_FACTURA.SelectedIndex >= 0 Then
                _DataCnfDispositivos._SeriesDocumento._Factura = Me.MCB_SERIE_FACTURA.SelectedItem(0).ToString.Trim
            End If
            If Me.MCB_SERIE_NC.SelectedIndex >= 0 Then
                _DataCnfDispositivos._SeriesDocumento._NotaCredito = Me.MCB_SERIE_NC.SelectedItem(0).ToString.Trim
            End If
            GrabarImpFiscal(3)
            Funciones.MensajeOk("CONFIGURACION GRABADA CON EXITO")
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarControlVentas()
        Try
            _DataConfiguracion._ControlVentas._VentaAlMayor = Me.MCH_VENTA_MAYOR.Checked
            _DataConfiguracion._ControlVentas._VentaDepartamento = Me.MCH_VENTA_DEPARTAMENTO.Checked
            _DataConfiguracion._ControlVentas._Monitoreo = Me.MCH_VENTA_MONITOR.Checked

            GrabarImpFiscal(7)
            Funciones.MensajeOk("CONFIGURACION GRABADA CON EXITO")
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub RB_BAL_ELECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_BAL_ELECT.CheckedChanged
        Me.P_BAL.Enabled = Me.RB_BAL_ELECT.Checked
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
            Case 0
                If Me.RB_BAL_ELECT.Checked Then
                    PruebaBalanzaElectronica()
                End If
            Case 3
                PruebaVisorPrecio()
            Case 4
                PruebaFiscal()
        End Select
    End Sub

    Sub PruebaBalanzaElectronica()
        Try
            If Me.MCHB_BALANZA.Checked AndAlso Me.RB_BAL_ELECT.Checked Then
                If BalanzaSoloPeso IsNot Nothing Then
                    With BalanzaSoloPeso
                        .Puerto = Me.MCB_BAL_PUERTO.SelectedIndex
                        .Modelo = (Me.MCB_BAL_MODELO.SelectedIndex + 1)
                    End With
                    MessageBox.Show("Coloque un producto a ser pesado en la balanza y presione la Tecla Enter", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageBox.Show("Tu Peso Es: " + BalanzaSoloPeso.LeerPeso().ToString, "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Funciones.MensajeAlerta("NO SE HA DEFINIDO UNA BALANZA... VERIFIQUE POR FAVOR")
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Sub PruebaVisorPrecio()
        Try
            If Me.MCHB_VISOR.Checked Then
                If VisorPrecioPtoventa IsNot Nothing Then
                    VisorPrecioPtoventa.puerto = Me.MCB_VISOR_PUERTO.SelectedIndex
                    VisorPrecioPtoventa.Texto("HOLA", " TODO OK")
                    MessageBox.Show("Verifica si en el visor de precio aparece un mensaje indcando lo siguiente: HOLA, TODO OK", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Funciones.MensajeAlerta("NO SE HA DEFINIDO UN VISOR DE PRECIO... VERIFIQUE POR FAVOR")
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Sub PruebaFiscal()
        Try
            If Me.MCHB_FISCAL.Checked Then
                If ImpresoraFiscal IsNot Nothing Then
                    ImpresoraFiscal.PuertoConexion = Me.MCB_FISCAL_PUERTO.SelectedIndex
                    ImpresoraFiscal.ModeloFiscal = Me.MCB_FISCAL_PUERTO.SelectedIndex + 1

                    MessageBox.Show("Encienda la impresora y verifique que tenga papel, se va a enviar un texto de prueba", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ImpresoraFiscal.TextoDNF("HOLA A TODOS....")
                Else
                    Funciones.MensajeAlerta("NO SE HA DEFINIDO UNA IMPRESORA FISCAL... VERIFIQUE POR FAVOR")
                End If
            End If
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub Configurar_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub Configurar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub BT_SERIAL_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SERIAL.Click
        Try
            If ImpresoraFiscal IsNot Nothing Then
                Me.E_SERIAL.Text = ""
                Me.Refresh()

                ImpresoraFiscal.Estatus()
                Me.E_SERIAL.Text = ImpresoraFiscal.Ver_SerialImpresoraFiscal
            Else
                Funciones.MensajeAlerta("IMPRESORA FISCAL NO DEFINIDA... VERIFIQUE POR FAVOR")
            End If
        Catch ex As Exception
            Funciones.MensajeError(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.MT_PRE_EMPAQUE.Text = "28IIIIIWWWWWC"
    End Sub

    Private Sub MCH_PRE_EMPAQUE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCH_PRE_EMPAQUE.CheckedChanged
        Me.MT_PRE_EMPAQUE.Enabled = Me.MCH_PRE_EMPAQUE.Checked
    End Sub

    Private Sub MCH_TICKET_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCH_TICKET.CheckedChanged
        Me.MT_TICKET.Enabled = Me.MCH_TICKET.Checked
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Me.MT_TICKET.Text = "21TTTTMMMMMMC"
    End Sub
End Class