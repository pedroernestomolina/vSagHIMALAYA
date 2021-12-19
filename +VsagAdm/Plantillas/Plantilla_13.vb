Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles

Public Class Plantilla_13
    Dim xplant As IPlantilla_13
    Dim pb_tm As Size

    Property _MiPlantilla() As IPlantilla_13
        Get
            Return xplant
        End Get
        Set(ByVal value As IPlantilla_13)
            xplant = value
        End Set
    End Property

    Private Sub Plantilla_13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Sub New(ByVal xplantilla As IPlantilla_13)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _MiPlantilla = xplantilla
        pb_tm = Me.PB_1.Size
    End Sub

    Private Sub Plantilla_13_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With

        With MN_1
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "999.99"
        End With
        With MN_2
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "99999999.99"
        End With
        With MN_3
            .Text = "0.0"
            ._ConSigno = False
            ._Formato = "99999999.99"
        End With

        Me._MiPlantilla.Iniciliza(Me)
    End Sub

    Private Sub PB_1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseEnter, PB_2.MouseEnter, PB_3.MouseEnter
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseHover, PB_2.MouseHover, PB_3.MouseHover
        EntrarSalirPB(sender, EntradaSalida.Entrada)
    End Sub

    Private Sub PB_1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_1.MouseLeave, PB_2.MouseLeave, PB_3.MouseLeave
        EntrarSalirPB(sender, EntradaSalida.Salida)
    End Sub

    Sub EntrarSalirPB(ByVal sender As Object, ByVal xtipo As EntradaSalida)
        Dim PB As PictureBox = CType(sender, PictureBox)
        Dim factor As Integer = 0
        If xtipo = EntradaSalida.Entrada Then
            factor = -5
        End If

        With PB
            .Size = New Size(pb_tm.Width + factor, pb_tm.Height + factor)
            .Cursor = Cursors.Hand
        End With
    End Sub
End Class

Public Interface IPlantilla_13
    Sub Iniciliza(ByVal xobj As System.Windows.Forms.Form)
End Interface

Public Class TablaVendedor
    Implements IPlantilla_13

    WithEvents xform As System.Windows.Forms.Form
    WithEvents misgrid1 As MisGrid
    Dim lb_1 As Label
    WithEvents PB_1 As PictureBox
    WithEvents PB_2 As PictureBox
    WithEvents PB_3 As PictureBox
    WithEvents BT_1 As Button
    WithEvents MN_1 As MisNumeros
    WithEvents MN_2 As MisNumeros
    WithEvents MN_3 As MisNumeros

    Dim xf_accion As TipoAccionFicha
    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xfichacomsiones As FichaGlobal.c_TablaComisiones

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Iniciliza(ByVal xobj As System.Windows.Forms.Form) Implements IPlantilla_13.Iniciliza
        Try
            _MiFormulario = xobj
            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            misgrid1 = _MiFormulario.Controls.Find("MisGrid1", True)(0)
            PB_1 = _MiFormulario.Controls.Find("PB_1", True)(0)
            PB_2 = _MiFormulario.Controls.Find("PB_2", True)(0)
            PB_3 = _MiFormulario.Controls.Find("PB_3", True)(0)
            BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
            MN_1 = _MiFormulario.Controls.Find("MN_1", True)(0)
            MN_2 = _MiFormulario.Controls.Find("MN_2", True)(0)
            MN_3 = _MiFormulario.Controls.Find("MN_3", True)(0)

            Me.lb_1.Text = "Definir Tabla Comisiones Para La Venta"
            Me._MiFormulario.Text = "Vendedor"

            _FichaAccion = TipoAccionFicha.Consultar
            xfichacomsiones = New FichaGlobal.c_TablaComisiones
            AddHandler xfichacomsiones._ActualizarRegla, AddressOf Actualiza

            CargarDataTabla()
            AddHandler xbs.PositionChanged, AddressOf ActualizarComision
            ActualizaComision()

            With misgrid1
                .Columns.Add("col0", "Comsion %")
                .Columns.Add("col1", "Desde Monto")
                .Columns.Add("col2", "Hasta Monto")

                .Columns(0).Width = 120
                .Columns(1).Width = 120
                .Columns(2).Width = 120
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "xcom"
                .Columns(1).DataPropertyName = "xdesde"
                .Columns(2).DataPropertyName = "xhasta"
                AddHandler .CellFormatting, AddressOf MiFormato

                .Ocultar(4)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Actualiza()
        CargarDataTabla()
        ActualizaComision()
    End Sub

    Sub ActualizarComision()
        ActualizaComision()
    End Sub

    Sub ActualizaComision()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xfichacomsiones.M_CargarRegistro(xr)

            Me.MN_1.Text = String.Format("{0:#0.00}", xfichacomsiones.RegistroDato._Comision)
            Me.MN_2.Text = String.Format("{0:#0.00}", xfichacomsiones.RegistroDato._DesdeMonto)
            Me.MN_3.Text = String.Format("{0:#0.00}", xfichacomsiones.RegistroDato._HastaMonto)
        Else
            Me.MN_1.Text = String.Format("{0:#0.00}", 0)
            Me.MN_2.Text = String.Format("{0:#0.00}", 0)
            Me.MN_3.Text = String.Format("{0:#0.00}", 0)
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
    End Sub

    Sub CargarDataTabla()
        g_MiData.F_GetData("select comision xcom, desde xdesde, hasta xhasta, *  from comisionrango_vendcob where tipo='V' order by desde", xtb)
    End Sub

    Property _FichaAccion() As TipoAccionFicha
        Get
            Return xf_accion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xf_accion = value

            If value = TipoAccionFicha.Consultar Then
                ApagarEncenderControles(True)
                Me.MisGrid1.Select()
                Me.MisGrid1.Focus()
            End If

            If value = TipoAccionFicha.Adicionar Then
                ApagarEncenderControles(False)
                AgregarModificarRegla(value)
            End If
        End Set
    End Property

    Sub AgregarModificarRegla(ByVal xtipo As TipoAccionFicha)
        If xtipo = TipoAccionFicha.Adicionar Then
            Me.MN_1.Text = "0.0"
            Me.MN_2.Text = "0.0"
            Me.MN_3.Text = "0.0"
        End If

        Me.MN_1.Select()
        Me.MN_1.Focus()
    End Sub

    Sub ApagarEncenderControles(ByVal xestatus As Boolean)
        Me.PB_1.Enabled = xestatus
        Me.PB_2.Enabled = xestatus
        Me.PB_3.Enabled = xestatus
        Me.MisGrid1.Enabled = xestatus

        Me.BT_1.Enabled = Not xestatus
        Me.Mn_1.Enabled = Not xestatus
        Me.Mn_2.Enabled = Not xestatus
        Me.Mn_3.Enabled = Not xestatus
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        Me._FichaAccion = TipoAccionFicha.Adicionar
    End Sub

    Private Sub xform_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles xform.FormClosing
        If _FichaAccion = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If _FichaAccion = TipoAccionFicha.Adicionar Or _FichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Estas Seguro De Peder Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                    ActualizaComision()
                    Me._FichaAccion = TipoAccionFicha.Consultar
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Function Validar() As Boolean
        Dim xr As Boolean = True

        If MN_1._Valor <= 0 Then
            MessageBox.Show("Error... Monto Comision Debe Ser Un Valor Mayor A Cero (0)", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MN_1.Select()
            Me.MN_1.Focus()
            xr = False
        End If

        If MN_2._Valor > MN_3._Valor And xr Then
            MessageBox.Show("Error... Monto Calculo Regla Incorrecto. Verifique...", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MN_2.Select()
            Me.MN_2.Focus()
            xr = False
        End If

        If MN_3._Valor < MN_2._Valor And xr Then
            MessageBox.Show("Error... Monto Calculo Regla Incorrecto. Verifique...", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MN_2.Select()
            Me.MN_2.Focus()
            xr = False
        End If

        Return xr
    End Function

    Private Sub BT_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Grabar()
    End Sub

    Sub Grabar()
        If _FichaAccion = TipoAccionFicha.Adicionar Then
            If Validar() Then
                If MessageBox.Show("Estas Seguro De Guardar Esta Nueva Regla De Calculo ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim xreg As New FichaGlobal.c_TablaComisiones.c_AgregarRegla
                        With xreg
                            ._Comision = MN_1._Valor
                            ._MontoDesde = MN_2._Valor
                            ._MontoHasta = MN_3._Valor
                            ._Tipo = TipoTablaComision.Vendedor
                        End With
                        xfichacomsiones.F_AgregarRegla(xreg)

                        Me._FichaAccion = TipoAccionFicha.Consultar
                        MessageBox.Show("Regla Agregada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarRegistro()
    End Sub

    Sub EliminarRegistro()
        Try
            If MessageBox.Show("Estas Seguro De Eliminar Esta Regla De Calculo ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                xfichacomsiones.F_EliminarRegla(xfichacomsiones.RegistroDato._Auto)
                MessageBox.Show("Regla Ha Sido Eliminada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PB_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_2.Click
        MessageBox.Show("Opcion No Activada, Se Recomienda Eliminar Y Crear Una Nueva Regla.", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub xform_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles xform.KeyDown
        If e.KeyValue = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                Me._FichaAccion = TipoAccionFicha.Adicionar
            End If
        End If
        If e.KeyValue = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                MessageBox.Show("Opcion No Activada, Se Recomienda Eliminar Y Crear Una Nueva Regla.", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyValue = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                EliminarRegistro()
            End If
        End If
    End Sub
End Class

Public Class TablaCobrador
    Implements IPlantilla_13

    WithEvents xform As System.Windows.Forms.Form
    WithEvents misgrid1 As MisGrid
    Dim lb_1 As Label
    WithEvents PB_1 As PictureBox
    WithEvents PB_2 As PictureBox
    WithEvents PB_3 As PictureBox
    WithEvents BT_1 As Button
    WithEvents MN_1 As MisNumeros
    WithEvents MN_2 As MisNumeros
    WithEvents MN_3 As MisNumeros

    Dim xf_accion As TipoAccionFicha
    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xfichacomsiones As FichaGlobal.c_TablaComisiones

    Sub New()
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
    End Sub

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xform
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xform = value
        End Set
    End Property

    Public Sub Iniciliza(ByVal xobj As System.Windows.Forms.Form) Implements IPlantilla_13.Iniciliza
        Try
            _MiFormulario = xobj
            lb_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
            misgrid1 = _MiFormulario.Controls.Find("MisGrid1", True)(0)
            PB_1 = _MiFormulario.Controls.Find("PB_1", True)(0)
            PB_2 = _MiFormulario.Controls.Find("PB_2", True)(0)
            PB_3 = _MiFormulario.Controls.Find("PB_3", True)(0)
            BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
            MN_1 = _MiFormulario.Controls.Find("MN_1", True)(0)
            MN_2 = _MiFormulario.Controls.Find("MN_2", True)(0)
            MN_3 = _MiFormulario.Controls.Find("MN_3", True)(0)

            Me.lb_1.Text = "Definir Tabla Comisiones Para La Cobranza"
            Me._MiFormulario.Text = "Cobrador"

            _FichaAccion = TipoAccionFicha.Consultar
            xfichacomsiones = New FichaGlobal.c_TablaComisiones
            AddHandler xfichacomsiones._ActualizarRegla, AddressOf Actualiza

            CargarDataTabla()
            AddHandler xbs.PositionChanged, AddressOf ActualizarComision
            ActualizaComision()

            With misgrid1
                .Columns.Add("col0", "Comsion %")
                .Columns.Add("col1", "Desde Monto")
                .Columns.Add("col2", "Hasta Monto")

                .Columns(0).Width = 120
                .Columns(1).Width = 120
                .Columns(2).Width = 120
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "xcom"
                .Columns(1).DataPropertyName = "xdesde"
                .Columns(2).DataPropertyName = "xhasta"
                AddHandler .CellFormatting, AddressOf MiFormato

                .Ocultar(4)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Actualiza()
        CargarDataTabla()
        ActualizaComision()
    End Sub

    Sub ActualizarComision()
        ActualizaComision()
    End Sub

    Sub ActualizaComision()
        If xbs.Current IsNot Nothing Then
            Dim xr As DataRow = CType(xbs.Current, DataRowView).Row
            xfichacomsiones.M_CargarRegistro(xr)

            Me.MN_1.Text = String.Format("{0:#0.00}", xfichacomsiones.RegistroDato._Comision)
            Me.MN_2.Text = String.Format("{0:#0.00}", xfichacomsiones.RegistroDato._DesdeMonto)
            Me.MN_3.Text = String.Format("{0:#0.00}", xfichacomsiones.RegistroDato._HastaMonto)
        Else
            Me.MN_1.Text = String.Format("{0:#0.00}", 0)
            Me.MN_2.Text = String.Format("{0:#0.00}", 0)
            Me.MN_3.Text = String.Format("{0:#0.00}", 0)
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
    End Sub

    Sub CargarDataTabla()
        g_MiData.F_GetData("select comision xcom, desde xdesde, hasta xhasta, *  from comisionrango_vendcob where tipo='C' order by desde", xtb)
    End Sub

    Property _FichaAccion() As TipoAccionFicha
        Get
            Return xf_accion
        End Get
        Set(ByVal value As TipoAccionFicha)
            xf_accion = value

            If value = TipoAccionFicha.Consultar Then
                ApagarEncenderControles(True)
                Me.MisGrid1.Select()
                Me.MisGrid1.Focus()
            End If

            If value = TipoAccionFicha.Adicionar Then
                ApagarEncenderControles(False)
                AgregarModificarRegla(value)
            End If
        End Set
    End Property

    Sub AgregarModificarRegla(ByVal xtipo As TipoAccionFicha)
        If xtipo = TipoAccionFicha.Adicionar Then
            Me.MN_1.Text = "0.0"
            Me.MN_2.Text = "0.0"
            Me.MN_3.Text = "0.0"
        End If

        Me.MN_1.Select()
        Me.MN_1.Focus()
    End Sub

    Sub ApagarEncenderControles(ByVal xestatus As Boolean)
        Me.PB_1.Enabled = xestatus
        Me.PB_2.Enabled = xestatus
        Me.PB_3.Enabled = xestatus
        Me.MisGrid1.Enabled = xestatus

        Me.BT_1.Enabled = Not xestatus
        Me.Mn_1.Enabled = Not xestatus
        Me.Mn_2.Enabled = Not xestatus
        Me.Mn_3.Enabled = Not xestatus
    End Sub

    Private Sub PB_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_1.Click
        Me._FichaAccion = TipoAccionFicha.Adicionar
    End Sub

    Private Sub xform_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles xform.FormClosing
        If _FichaAccion = TipoAccionFicha.Consultar Then
            e.Cancel = False
        Else
            If _FichaAccion = TipoAccionFicha.Adicionar Or _FichaAccion = TipoAccionFicha.Modificar Then
                If MessageBox.Show("Estas Seguro De Peder Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = True
                    ActualizaComision()
                    Me._FichaAccion = TipoAccionFicha.Consultar
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Function Validar() As Boolean
        Dim xr As Boolean = True

        If MN_1._Valor <= 0 Then
            MessageBox.Show("Error... Monto Comision Debe Ser Un Valor Mayor A Cero (0)", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MN_1.Select()
            Me.MN_1.Focus()
            xr = False
        End If

        If MN_2._Valor > MN_3._Valor And xr Then
            MessageBox.Show("Error... Monto Calculo Regla Incorrecto. Verifique...", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MN_2.Select()
            Me.MN_2.Focus()
            xr = False
        End If

        If MN_3._Valor < MN_2._Valor And xr Then
            MessageBox.Show("Error... Monto Calculo Regla Incorrecto. Verifique...", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.MN_2.Select()
            Me.MN_2.Focus()
            xr = False
        End If

        Return xr
    End Function

    Private Sub BT_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Grabar()
    End Sub

    Sub Grabar()
        If _FichaAccion = TipoAccionFicha.Adicionar Then
            If Validar() Then
                If MessageBox.Show("Estas Seguro De Guardar Esta Nueva Regla De Calculo ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Try
                        Dim xreg As New FichaGlobal.c_TablaComisiones.c_AgregarRegla
                        With xreg
                            ._Comision = MN_1._Valor
                            ._MontoDesde = MN_2._Valor
                            ._MontoHasta = MN_3._Valor
                            ._Tipo = TipoTablaComision.Cobrador
                        End With
                        xfichacomsiones.F_AgregarRegla(xreg)

                        Me._FichaAccion = TipoAccionFicha.Consultar
                        MessageBox.Show("Regla Agregada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub PB_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3.Click
        EliminarRegistro()
    End Sub

    Sub EliminarRegistro()
        Try
            If MessageBox.Show("Estas Seguro De Eliminar Esta Regla De Calculo ?", "*** Mensaje De Alerta ****", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                xfichacomsiones.F_EliminarRegla(xfichacomsiones.RegistroDato._Auto)
                MessageBox.Show("Regla Ha Sido Eliminada Exitosamente... Ok", "*** Mensaje Ok ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PB_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PB_2.Click
        MessageBox.Show("Opcion No Activada, Se Recomienda Eliminar Y Crear Una Nueva Regla.", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub xform_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles xform.KeyDown
        If e.KeyValue = Keys.F1 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                Me._FichaAccion = TipoAccionFicha.Adicionar
            End If
        End If
        If e.KeyValue = Keys.F2 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                MessageBox.Show("Opcion No Activada, Se Recomienda Eliminar Y Crear Una Nueva Regla.", "*** Mensaje De Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyValue = Keys.F3 AndAlso (e.Alt = False And e.Control = False) Then
            If _FichaAccion = TipoAccionFicha.Consultar Then
                EliminarRegistro()
            End If
        End If
    End Sub
End Class