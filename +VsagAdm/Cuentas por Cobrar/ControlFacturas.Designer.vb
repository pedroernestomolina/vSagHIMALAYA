<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlFacturas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LB_TITULO = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.LB_CODIGO = New System.Windows.Forms.Label
        Me.LB_CIRIF = New System.Windows.Forms.Label
        Me.LB_NOMBRE = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.MN_IMPORTE = New MisControles.Controles.MisNumeros
        Me.MT_DETALLE = New MisControles.Controles.MisTextos
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.MN_SALDOPENDIENTE = New MisControles.Controles.MisNumeros
        Me.Label1 = New System.Windows.Forms.Label
        Me.MN_DIAS = New MisControles.Controles.MisNumeros
        Me.MF_FECHA = New MisControles.Controles.MisFechas
        Me.MT_DOCUMENTO = New MisControles.Controles.MisTextos
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.MCB_DOCUMENTO = New MisControles.Controles.MisComboBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.LB_TEXTO = New System.Windows.Forms.Label
        Me.BT_GUARDAR = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(670, 398)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 209.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(670, 376)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel2.Size = New System.Drawing.Size(664, 89)
        Me.Panel2.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.57576!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.42424!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.90124!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.09877!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(660, 85)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel3.Controls.Add(Me.LB_TITULO)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel3.Size = New System.Drawing.Size(209, 51)
        Me.Panel3.TabIndex = 0
        '
        'LB_TITULO
        '
        Me.LB_TITULO.BackColor = System.Drawing.Color.MidnightBlue
        Me.LB_TITULO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_TITULO.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_TITULO.ForeColor = System.Drawing.Color.White
        Me.LB_TITULO.Location = New System.Drawing.Point(2, 2)
        Me.LB_TITULO.Name = "LB_TITULO"
        Me.LB_TITULO.Size = New System.Drawing.Size(205, 47)
        Me.LB_TITULO.TabIndex = 2
        Me.LB_TITULO.Text = "Nuevo Documento"
        Me.LB_TITULO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Azure
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 60)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(209, 22)
        Me.Panel4.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.LB_CODIGO)
        Me.Panel5.Controls.Add(Me.LB_CIRIF)
        Me.Panel5.Controls.Add(Me.LB_NOMBRE)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(218, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.SetRowSpan(Me.Panel5, 2)
        Me.Panel5.Size = New System.Drawing.Size(439, 79)
        Me.Panel5.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(216, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Código:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 54)
        Me.Label8.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 20)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "CI/RIF:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LB_CODIGO
        '
        Me.LB_CODIGO.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LB_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_CODIGO.ForeColor = System.Drawing.Color.Yellow
        Me.LB_CODIGO.Location = New System.Drawing.Point(286, 54)
        Me.LB_CODIGO.Name = "LB_CODIGO"
        Me.LB_CODIGO.Size = New System.Drawing.Size(149, 18)
        Me.LB_CODIGO.TabIndex = 39
        Me.LB_CODIGO.Text = "000-01"
        '
        'LB_CIRIF
        '
        Me.LB_CIRIF.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LB_CIRIF.AutoSize = True
        Me.LB_CIRIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_CIRIF.ForeColor = System.Drawing.Color.Yellow
        Me.LB_CIRIF.Location = New System.Drawing.Point(73, 54)
        Me.LB_CIRIF.Name = "LB_CIRIF"
        Me.LB_CIRIF.Size = New System.Drawing.Size(110, 18)
        Me.LB_CIRIF.TabIndex = 38
        Me.LB_CIRIF.Text = "J-12345678-9"
        '
        'LB_NOMBRE
        '
        Me.LB_NOMBRE.Dock = System.Windows.Forms.DockStyle.Top
        Me.LB_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_NOMBRE.ForeColor = System.Drawing.Color.White
        Me.LB_NOMBRE.Location = New System.Drawing.Point(2, 2)
        Me.LB_NOMBRE.Name = "LB_NOMBRE"
        Me.LB_NOMBRE.Size = New System.Drawing.Size(435, 45)
        Me.LB_NOMBRE.TabIndex = 4
        Me.LB_NOMBRE.Text = "Nombre / Razon Social" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Max 2 Lineas"
        Me.LB_NOMBRE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel6, 2)
        Me.Panel6.Controls.Add(Me.MN_IMPORTE)
        Me.Panel6.Controls.Add(Me.MT_DETALLE)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.Label25)
        Me.Panel6.Controls.Add(Me.MN_SALDOPENDIENTE)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.MN_DIAS)
        Me.Panel6.Controls.Add(Me.MF_FECHA)
        Me.Panel6.Controls.Add(Me.MT_DOCUMENTO)
        Me.Panel6.Controls.Add(Me.Label34)
        Me.Panel6.Controls.Add(Me.Label36)
        Me.Panel6.Controls.Add(Me.Label38)
        Me.Panel6.Controls.Add(Me.MCB_DOCUMENTO)
        Me.Panel6.Controls.Add(Me.Label39)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 98)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel6.Size = New System.Drawing.Size(664, 203)
        Me.Panel6.TabIndex = 1
        '
        'MN_IMPORTE
        '
        Me.MN_IMPORTE._ConSigno = False
        Me.MN_IMPORTE._Formato = ""
        Me.MN_IMPORTE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_IMPORTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_IMPORTE.ForeColor = System.Drawing.Color.Black
        Me.MN_IMPORTE.Location = New System.Drawing.Point(307, 53)
        Me.MN_IMPORTE.Name = "MN_IMPORTE"
        Me.MN_IMPORTE.Size = New System.Drawing.Size(136, 26)
        Me.MN_IMPORTE.TabIndex = 4
        Me.MN_IMPORTE.Text = "9999999.99"
        Me.MN_IMPORTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MT_DETALLE
        '
        Me.MT_DETALLE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_DETALLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_DETALLE.ForeColor = System.Drawing.Color.Black
        Me.MT_DETALLE.Location = New System.Drawing.Point(307, 120)
        Me.MT_DETALLE.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.MT_DETALLE.MaxLength = 120
        Me.MT_DETALLE.Multiline = True
        Me.MT_DETALLE.Name = "MT_DETALLE"
        Me.MT_DETALLE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_DETALLE.p_IniciarComo = True
        Me.MT_DETALLE.Size = New System.Drawing.Size(332, 70)
        Me.MT_DETALLE.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(511, 29)
        Me.Label3.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "Saldo Pendiente:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(306, 103)
        Me.Label25.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(116, 16)
        Me.Label25.TabIndex = 106
        Me.Label25.Text = "Detalle/Concepto:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MN_SALDOPENDIENTE
        '
        Me.MN_SALDOPENDIENTE._ConSigno = False
        Me.MN_SALDOPENDIENTE._Formato = ""
        Me.MN_SALDOPENDIENTE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_SALDOPENDIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_SALDOPENDIENTE.ForeColor = System.Drawing.Color.Black
        Me.MN_SALDOPENDIENTE.Location = New System.Drawing.Point(503, 53)
        Me.MN_SALDOPENDIENTE.Name = "MN_SALDOPENDIENTE"
        Me.MN_SALDOPENDIENTE.Size = New System.Drawing.Size(136, 26)
        Me.MN_SALDOPENDIENTE.TabIndex = 5
        Me.MN_SALDOPENDIENTE.Text = "9999999.99"
        Me.MN_SALDOPENDIENTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(305, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 20)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Importe Documento:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MN_DIAS
        '
        Me.MN_DIAS._ConSigno = False
        Me.MN_DIAS._Formato = ""
        Me.MN_DIAS.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_DIAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_DIAS.ForeColor = System.Drawing.Color.Black
        Me.MN_DIAS.Location = New System.Drawing.Point(160, 149)
        Me.MN_DIAS.Name = "MN_DIAS"
        Me.MN_DIAS.Size = New System.Drawing.Size(53, 24)
        Me.MN_DIAS.TabIndex = 3
        Me.MN_DIAS.Text = "0"
        Me.MN_DIAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MF_FECHA
        '
        Me.MF_FECHA.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_FECHA.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MF_FECHA.ForeColor = System.Drawing.Color.Black
        Me.MF_FECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_FECHA.Location = New System.Drawing.Point(27, 147)
        Me.MF_FECHA.Margin = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.MF_FECHA.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_FECHA.Name = "MF_FECHA"
        Me.MF_FECHA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_FECHA.p_IniciarComo = True
        Me.MF_FECHA.Size = New System.Drawing.Size(110, 24)
        Me.MF_FECHA.TabIndex = 2
        Me.MF_FECHA.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MT_DOCUMENTO
        '
        Me.MT_DOCUMENTO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_DOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_DOCUMENTO.ForeColor = System.Drawing.Color.Black
        Me.MT_DOCUMENTO.Location = New System.Drawing.Point(27, 96)
        Me.MT_DOCUMENTO.MaxLength = 30
        Me.MT_DOCUMENTO.Name = "MT_DOCUMENTO"
        Me.MT_DOCUMENTO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_DOCUMENTO.p_IniciarComo = True
        Me.MT_DOCUMENTO.Size = New System.Drawing.Size(186, 26)
        Me.MT_DOCUMENTO.TabIndex = 1
        '
        'Label34
        '
        Me.Label34.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(149, 130)
        Me.Label34.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(104, 16)
        Me.Label34.TabIndex = 110
        Me.Label34.Text = "Dias de Crédito:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label36
        '
        Me.Label36.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(26, 130)
        Me.Label36.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(100, 16)
        Me.Label36.TabIndex = 109
        Me.Label36.Text = "Fecha Emisión:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label38
        '
        Me.Label38.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(26, 76)
        Me.Label38.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(152, 16)
        Me.Label38.TabIndex = 108
        Me.Label38.Text = "Número De Documento:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MCB_DOCUMENTO
        '
        Me.MCB_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_DOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_DOCUMENTO.FormattingEnabled = True
        Me.MCB_DOCUMENTO.Location = New System.Drawing.Point(27, 44)
        Me.MCB_DOCUMENTO.Name = "MCB_DOCUMENTO"
        Me.MCB_DOCUMENTO.Size = New System.Drawing.Size(186, 24)
        Me.MCB_DOCUMENTO.TabIndex = 0
        '
        'Label39
        '
        Me.Label39.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(26, 24)
        Me.Label39.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(132, 16)
        Me.Label39.TabIndex = 107
        Me.Label39.Text = "Tipo De Documento:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Lavender
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel7, 2)
        Me.Panel7.Controls.Add(Me.LB_TEXTO)
        Me.Panel7.Controls.Add(Me.BT_GUARDAR)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 307)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel7.Size = New System.Drawing.Size(664, 66)
        Me.Panel7.TabIndex = 2
        '
        'LB_TEXTO
        '
        Me.LB_TEXTO.Dock = System.Windows.Forms.DockStyle.Left
        Me.LB_TEXTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_TEXTO.ForeColor = System.Drawing.Color.Maroon
        Me.LB_TEXTO.Location = New System.Drawing.Point(2, 2)
        Me.LB_TEXTO.Name = "LB_TEXTO"
        Me.LB_TEXTO.Size = New System.Drawing.Size(284, 62)
        Me.LB_TEXTO.TabIndex = 10
        Me.LB_TEXTO.Text = "Documento Pendiente A Registrar"
        Me.LB_TEXTO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BT_GUARDAR
        '
        Me.BT_GUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GUARDAR.Location = New System.Drawing.Point(484, 5)
        Me.BT_GUARDAR.Name = "BT_GUARDAR"
        Me.BT_GUARDAR.Size = New System.Drawing.Size(155, 55)
        Me.BT_GUARDAR.TabIndex = 9
        Me.BT_GUARDAR.Text = "&Guardar / Grabar"
        Me.BT_GUARDAR.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 376)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(670, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(230, 17)
        Me.ToolStripStatusLabel1.Text = "Presione La Tecla < Esc > Para Salir"
        '
        'ControlFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(674, 402)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(690, 440)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(690, 440)
        Me.Name = "ControlFacturas"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control De Documentos Nuevos"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents LB_TITULO As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents LB_NOMBRE As System.Windows.Forms.Label
    Friend WithEvents LB_CODIGO As System.Windows.Forms.Label
    Friend WithEvents LB_CIRIF As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents MN_IMPORTE As MisControles.Controles.MisNumeros
    Friend WithEvents MT_DETALLE As MisControles.Controles.MisTextos
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents MN_SALDOPENDIENTE As MisControles.Controles.MisNumeros
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MN_DIAS As MisControles.Controles.MisNumeros
    Friend WithEvents MF_FECHA As MisControles.Controles.MisFechas
    Friend WithEvents MT_DOCUMENTO As MisControles.Controles.MisTextos
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents MCB_DOCUMENTO As MisControles.Controles.MisComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents BT_GUARDAR As System.Windows.Forms.Button
    Friend WithEvents LB_TEXTO As System.Windows.Forms.Label
End Class
