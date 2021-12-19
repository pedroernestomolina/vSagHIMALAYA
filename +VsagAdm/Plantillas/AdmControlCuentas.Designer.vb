<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdmControlCuentas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.MT_TEXTOBUSQUEDA = New MisControles.Controles.MisTextos
        Me.MCB_TIPOBUSQUEDA = New MisControles.Controles.MisComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel13 = New System.Windows.Forms.Panel
        Me.MF_HASTA = New MisControles.Controles.MisFechas
        Me.MF_DESDE = New MisControles.Controles.MisFechas
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel14 = New System.Windows.Forms.Panel
        Me.MCB_TIPODOCUMENTO = New MisControles.Controles.MisComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel15 = New System.Windows.Forms.Panel
        Me.BT_AVANZADA = New System.Windows.Forms.Button
        Me.BT_BUSCARAHORA = New System.Windows.Forms.Button
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.LB_DEBE = New System.Windows.Forms.Label
        Me.LB_HABER = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LB_ITEMS_E = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.LB_NOMBREENTIDAD = New System.Windows.Forms.Label
        Me.LB_TITULOENTIDAD = New System.Windows.Forms.Label
        Me.BT_ANULAR = New System.Windows.Forms.Button
        Me.BT_VISUALIZAR = New System.Windows.Forms.Button
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.MG_DOCUMENTOS = New MisControles.Controles.MisGrid
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LB_TITULO = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.MG_DOCUMENTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MintCream
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(930, 560)
        Me.Panel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 25)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(930, 513)
        Me.Panel4.TabIndex = 3
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel11, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.22113!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.77886!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(930, 513)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel11.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(3, 3)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(924, 82)
        Me.Panel11.TabIndex = 3
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 378.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel12, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel13, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel14, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel15, 3, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.9434!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.0566!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(924, 82)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.Label3)
        Me.Panel12.Controls.Add(Me.MT_TEXTOBUSQUEDA)
        Me.Panel12.Controls.Add(Me.MCB_TIPOBUSQUEDA)
        Me.Panel12.Controls.Add(Me.Label7)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(3, 3)
        Me.Panel12.Name = "Panel12"
        Me.TableLayoutPanel4.SetRowSpan(Me.Panel12, 2)
        Me.Panel12.Size = New System.Drawing.Size(372, 76)
        Me.Panel12.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Maroon
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(4, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = " F1 "
        '
        'MT_TEXTOBUSQUEDA
        '
        Me.MT_TEXTOBUSQUEDA.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_TEXTOBUSQUEDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_TEXTOBUSQUEDA.ForeColor = System.Drawing.Color.Black
        Me.MT_TEXTOBUSQUEDA.Location = New System.Drawing.Point(71, 33)
        Me.MT_TEXTOBUSQUEDA.MaxLength = 20
        Me.MT_TEXTOBUSQUEDA.Name = "MT_TEXTOBUSQUEDA"
        Me.MT_TEXTOBUSQUEDA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_TEXTOBUSQUEDA.p_IniciarComo = True
        Me.MT_TEXTOBUSQUEDA.Size = New System.Drawing.Size(285, 38)
        Me.MT_TEXTOBUSQUEDA.TabIndex = 1
        '
        'MCB_TIPOBUSQUEDA
        '
        Me.MCB_TIPOBUSQUEDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_TIPOBUSQUEDA.DropDownWidth = 200
        Me.MCB_TIPOBUSQUEDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_TIPOBUSQUEDA.FormattingEnabled = True
        Me.MCB_TIPOBUSQUEDA.Location = New System.Drawing.Point(122, 6)
        Me.MCB_TIPOBUSQUEDA.Name = "MCB_TIPOBUSQUEDA"
        Me.MCB_TIPOBUSQUEDA.Size = New System.Drawing.Size(234, 24)
        Me.MCB_TIPOBUSQUEDA.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(39, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Buscar Por:"
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.MF_HASTA)
        Me.Panel13.Controls.Add(Me.MF_DESDE)
        Me.Panel13.Controls.Add(Me.Label9)
        Me.Panel13.Controls.Add(Me.Label8)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(381, 3)
        Me.Panel13.Name = "Panel13"
        Me.TableLayoutPanel4.SetRowSpan(Me.Panel13, 2)
        Me.Panel13.Size = New System.Drawing.Size(212, 76)
        Me.Panel13.TabIndex = 1
        '
        'MF_HASTA
        '
        Me.MF_HASTA.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_HASTA.Checked = False
        Me.MF_HASTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MF_HASTA.ForeColor = System.Drawing.Color.Black
        Me.MF_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_HASTA.Location = New System.Drawing.Point(61, 35)
        Me.MF_HASTA.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_HASTA.Name = "MF_HASTA"
        Me.MF_HASTA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.p_IniciarComo = True
        Me.MF_HASTA.ShowCheckBox = True
        Me.MF_HASTA.Size = New System.Drawing.Size(145, 24)
        Me.MF_HASTA.TabIndex = 1
        Me.MF_HASTA.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MF_DESDE
        '
        Me.MF_DESDE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_DESDE.Checked = False
        Me.MF_DESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MF_DESDE.ForeColor = System.Drawing.Color.Black
        Me.MF_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_DESDE.Location = New System.Drawing.Point(61, 9)
        Me.MF_DESDE.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_DESDE.Name = "MF_DESDE"
        Me.MF_DESDE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.p_IniciarComo = True
        Me.MF_DESDE.ShowCheckBox = True
        Me.MF_DESDE.Size = New System.Drawing.Size(145, 24)
        Me.MF_DESDE.TabIndex = 0
        Me.MF_DESDE.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 16)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Hasta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Desde:"
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.MCB_TIPODOCUMENTO)
        Me.Panel14.Controls.Add(Me.Label10)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(599, 3)
        Me.Panel14.Name = "Panel14"
        Me.TableLayoutPanel4.SetRowSpan(Me.Panel14, 2)
        Me.Panel14.Size = New System.Drawing.Size(162, 76)
        Me.Panel14.TabIndex = 2
        '
        'MCB_TIPODOCUMENTO
        '
        Me.MCB_TIPODOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_TIPODOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_TIPODOCUMENTO.FormattingEnabled = True
        Me.MCB_TIPODOCUMENTO.Location = New System.Drawing.Point(5, 29)
        Me.MCB_TIPODOCUMENTO.Name = "MCB_TIPODOCUMENTO"
        Me.MCB_TIPODOCUMENTO.Size = New System.Drawing.Size(150, 24)
        Me.MCB_TIPODOCUMENTO.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 16)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Tipo Documento"
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.BT_AVANZADA)
        Me.Panel15.Controls.Add(Me.BT_BUSCARAHORA)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel15.Location = New System.Drawing.Point(767, 3)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Padding = New System.Windows.Forms.Padding(15)
        Me.TableLayoutPanel4.SetRowSpan(Me.Panel15, 2)
        Me.Panel15.Size = New System.Drawing.Size(154, 76)
        Me.Panel15.TabIndex = 3
        '
        'BT_AVANZADA
        '
        Me.BT_AVANZADA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_AVANZADA.Location = New System.Drawing.Point(12, 35)
        Me.BT_AVANZADA.Name = "BT_AVANZADA"
        Me.BT_AVANZADA.Size = New System.Drawing.Size(135, 40)
        Me.BT_AVANZADA.TabIndex = 1
        Me.BT_AVANZADA.Text = "&Busqueda Avanzada"
        Me.BT_AVANZADA.UseVisualStyleBackColor = True
        '
        'BT_BUSCARAHORA
        '
        Me.BT_BUSCARAHORA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_BUSCARAHORA.Location = New System.Drawing.Point(13, 3)
        Me.BT_BUSCARAHORA.Name = "BT_BUSCARAHORA"
        Me.BT_BUSCARAHORA.Size = New System.Drawing.Size(134, 25)
        Me.BT_BUSCARAHORA.TabIndex = 0
        Me.BT_BUSCARAHORA.Text = "&Buscar Ahora"
        Me.BT_BUSCARAHORA.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 91)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(924, 419)
        Me.Panel5.TabIndex = 4
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel8, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel7, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel6, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.08498!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.915014!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(924, 419)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.LB_DEBE)
        Me.Panel8.Controls.Add(Me.LB_HABER)
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Controls.Add(Me.LB_ITEMS_E)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 332)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(918, 30)
        Me.Panel8.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(588, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Totales:"
        Me.Label1.Visible = False
        '
        'LB_DEBE
        '
        Me.LB_DEBE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_DEBE.Location = New System.Drawing.Point(715, 6)
        Me.LB_DEBE.Name = "LB_DEBE"
        Me.LB_DEBE.Size = New System.Drawing.Size(84, 15)
        Me.LB_DEBE.TabIndex = 5
        Me.LB_DEBE.Text = "9999999999.99"
        Me.LB_DEBE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LB_DEBE.Visible = False
        '
        'LB_HABER
        '
        Me.LB_HABER.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_HABER.Location = New System.Drawing.Point(799, 6)
        Me.LB_HABER.Name = "LB_HABER"
        Me.LB_HABER.Size = New System.Drawing.Size(84, 15)
        Me.LB_HABER.TabIndex = 4
        Me.LB_HABER.Text = "9999999999.99"
        Me.LB_HABER.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LB_HABER.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(249, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cantidad Documentos Encontrados:"
        '
        'LB_ITEMS_E
        '
        Me.LB_ITEMS_E.AutoSize = True
        Me.LB_ITEMS_E.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_ITEMS_E.Location = New System.Drawing.Point(257, 5)
        Me.LB_ITEMS_E.Name = "LB_ITEMS_E"
        Me.LB_ITEMS_E.Size = New System.Drawing.Size(62, 18)
        Me.LB_ITEMS_E.TabIndex = 3
        Me.LB_ITEMS_E.Text = "999999"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.LB_NOMBREENTIDAD)
        Me.Panel7.Controls.Add(Me.LB_TITULOENTIDAD)
        Me.Panel7.Controls.Add(Me.BT_ANULAR)
        Me.Panel7.Controls.Add(Me.BT_VISUALIZAR)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 368)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(918, 48)
        Me.Panel7.TabIndex = 2
        '
        'LB_NOMBREENTIDAD
        '
        Me.LB_NOMBREENTIDAD.BackColor = System.Drawing.Color.LightGray
        Me.LB_NOMBREENTIDAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_NOMBREENTIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_NOMBREENTIDAD.Location = New System.Drawing.Point(78, 3)
        Me.LB_NOMBREENTIDAD.Name = "LB_NOMBREENTIDAD"
        Me.LB_NOMBREENTIDAD.Size = New System.Drawing.Size(505, 40)
        Me.LB_NOMBREENTIDAD.TabIndex = 6
        Me.LB_NOMBREENTIDAD.Text = "Nombre Entidad"
        Me.LB_NOMBREENTIDAD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LB_TITULOENTIDAD
        '
        Me.LB_TITULOENTIDAD.AutoSize = True
        Me.LB_TITULOENTIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_TITULOENTIDAD.Location = New System.Drawing.Point(3, 3)
        Me.LB_TITULOENTIDAD.Name = "LB_TITULOENTIDAD"
        Me.LB_TITULOENTIDAD.Size = New System.Drawing.Size(69, 18)
        Me.LB_TITULOENTIDAD.TabIndex = 6
        Me.LB_TITULOENTIDAD.Text = "Entidad:"
        '
        'BT_ANULAR
        '
        Me.BT_ANULAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_ANULAR.Location = New System.Drawing.Point(817, 3)
        Me.BT_ANULAR.Name = "BT_ANULAR"
        Me.BT_ANULAR.Size = New System.Drawing.Size(93, 42)
        Me.BT_ANULAR.TabIndex = 5
        Me.BT_ANULAR.Text = "&Anular Document"
        Me.BT_ANULAR.UseVisualStyleBackColor = True
        '
        'BT_VISUALIZAR
        '
        Me.BT_VISUALIZAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_VISUALIZAR.Location = New System.Drawing.Point(718, 3)
        Me.BT_VISUALIZAR.Name = "BT_VISUALIZAR"
        Me.BT_VISUALIZAR.Size = New System.Drawing.Size(93, 42)
        Me.BT_VISUALIZAR.TabIndex = 4
        Me.BT_VISUALIZAR.Text = "&Visualizar Document"
        Me.BT_VISUALIZAR.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DimGray
        Me.Panel6.Controls.Add(Me.MG_DOCUMENTOS)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel6.Size = New System.Drawing.Size(918, 323)
        Me.Panel6.TabIndex = 0
        '
        'MG_DOCUMENTOS
        '
        Me.MG_DOCUMENTOS.AllowUserToAddRows = False
        Me.MG_DOCUMENTOS.AllowUserToDeleteRows = False
        Me.MG_DOCUMENTOS.AllowUserToResizeColumns = False
        Me.MG_DOCUMENTOS.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan
        Me.MG_DOCUMENTOS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.MG_DOCUMENTOS.BackgroundColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MG_DOCUMENTOS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MG_DOCUMENTOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MG_DOCUMENTOS.DefaultCellStyle = DataGridViewCellStyle3
        Me.MG_DOCUMENTOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MG_DOCUMENTOS.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.MG_DOCUMENTOS.Location = New System.Drawing.Point(2, 2)
        Me.MG_DOCUMENTOS.MultiSelect = False
        Me.MG_DOCUMENTOS.Name = "MG_DOCUMENTOS"
        Me.MG_DOCUMENTOS.ReadOnly = True
        Me.MG_DOCUMENTOS.RowHeadersVisible = False
        Me.MG_DOCUMENTOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MG_DOCUMENTOS.Size = New System.Drawing.Size(914, 319)
        Me.MG_DOCUMENTOS.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.LB_TITULO)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(930, 25)
        Me.Panel2.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(930, 1)
        Me.Panel3.TabIndex = 1
        '
        'LB_TITULO
        '
        Me.LB_TITULO.AutoSize = True
        Me.LB_TITULO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_TITULO.Location = New System.Drawing.Point(3, 3)
        Me.LB_TITULO.Name = "LB_TITULO"
        Me.LB_TITULO.Size = New System.Drawing.Size(111, 18)
        Me.LB_TITULO.TabIndex = 0
        Me.LB_TITULO.Text = "Titulo Modulo"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 538)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(930, 22)
        Me.StatusStrip1.TabIndex = 1
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
        'AdmControlCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGreen
        Me.ClientSize = New System.Drawing.Size(934, 564)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(950, 602)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(950, 602)
        Me.Name = "AdmControlCuentas"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Titulo Modulo"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        CType(Me.MG_DOCUMENTOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LB_TITULO As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MT_TEXTOBUSQUEDA As MisControles.Controles.MisTextos
    Friend WithEvents MCB_TIPOBUSQUEDA As MisControles.Controles.MisComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents MF_HASTA As MisControles.Controles.MisFechas
    Friend WithEvents MF_DESDE As MisControles.Controles.MisFechas
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents MCB_TIPODOCUMENTO As MisControles.Controles.MisComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents BT_BUSCARAHORA As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents MG_DOCUMENTOS As MisControles.Controles.MisGrid
    Friend WithEvents BT_AVANZADA As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents BT_ANULAR As System.Windows.Forms.Button
    Friend WithEvents BT_VISUALIZAR As System.Windows.Forms.Button
    Friend WithEvents LB_ITEMS_E As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents LB_DEBE As System.Windows.Forms.Label
    Friend WithEvents LB_NOMBREENTIDAD As System.Windows.Forms.Label
    Friend WithEvents LB_TITULOENTIDAD As System.Windows.Forms.Label
    Friend WithEvents LB_HABER As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
