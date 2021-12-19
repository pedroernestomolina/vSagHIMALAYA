<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlantillaRetencionIva
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.E_DOC_A_PROCESAR = New System.Windows.Forms.Label
        Me.E_TOTAL_PLANILLA = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.MCHKB_TODOS = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.MisGrid1 = New MisControles.Controles.MisGrid
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.E_TOTAL_ITEMS = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel13 = New System.Windows.Forms.Panel
        Me.MisGrid2 = New MisControles.Controles.MisGrid
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.Panel14 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel15 = New System.Windows.Forms.Panel
        Me.MT_BUSCAR = New MisControles.Controles.MisTextos
        Me.Label17 = New System.Windows.Forms.Label
        Me.MCB_BUSQUEDA = New MisControles.Controles.MisComboBox
        Me.BT_BUSCAR = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Panel16 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.E_CODIGO = New System.Windows.Forms.Label
        Me.LINK_FICHA = New System.Windows.Forms.LinkLabel
        Me.E_CIRIF = New System.Windows.Forms.Label
        Me.E_NOMBRE = New System.Windows.Forms.Label
        Me.Panel17 = New System.Windows.Forms.Panel
        Me.MN_RETENCION = New MisControles.Controles.MisNumeros
        Me.Label12 = New System.Windows.Forms.Label
        Me.MT_PLANILLA = New MisControles.Controles.MisTextos
        Me.E_MES = New System.Windows.Forms.Label
        Me.E_ANO = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.MF_EMISION = New MisControles.Controles.MisFechas
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BT_LIMPIAR = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.MisGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        CType(Me.MisGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1020, 538)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 617.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 401.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel10, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel14, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 32)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 326.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1018, 482)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.E_DOC_A_PROCESAR)
        Me.Panel4.Controls.Add(Me.E_TOTAL_PLANILLA)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 425)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(611, 54)
        Me.Panel4.TabIndex = 0
        '
        'E_DOC_A_PROCESAR
        '
        Me.E_DOC_A_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_DOC_A_PROCESAR.Location = New System.Drawing.Point(174, 24)
        Me.E_DOC_A_PROCESAR.Name = "E_DOC_A_PROCESAR"
        Me.E_DOC_A_PROCESAR.Size = New System.Drawing.Size(43, 24)
        Me.E_DOC_A_PROCESAR.TabIndex = 3
        Me.E_DOC_A_PROCESAR.Text = "999"
        Me.E_DOC_A_PROCESAR.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_TOTAL_PLANILLA
        '
        Me.E_TOTAL_PLANILLA.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_TOTAL_PLANILLA.Location = New System.Drawing.Point(435, 20)
        Me.E_TOTAL_PLANILLA.Name = "E_TOTAL_PLANILLA"
        Me.E_TOTAL_PLANILLA.Size = New System.Drawing.Size(165, 29)
        Me.E_TOTAL_PLANILLA.TabIndex = 2
        Me.E_TOTAL_PLANILLA.Text = "999999999.99"
        Me.E_TOTAL_PLANILLA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(325, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Total Importe:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(214, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Total Documentos a Procesar"
        '
        'Panel5
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel5, 2)
        Me.Panel5.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 99)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1012, 320)
        Me.Panel5.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Gainsboro
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 605.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 399.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel6, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel11, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1012, 320)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(616, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel6.Size = New System.Drawing.Size(393, 314)
        Me.Panel6.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel7, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel8, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel9, 0, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(389, 310)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gray
        Me.TableLayoutPanel3.SetColumnSpan(Me.Panel7, 2)
        Me.Panel7.Controls.Add(Me.MCHKB_TODOS)
        Me.Panel7.Controls.Add(Me.Label6)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(383, 24)
        Me.Panel7.TabIndex = 0
        '
        'MCHKB_TODOS
        '
        Me.MCHKB_TODOS.AutoSize = True
        Me.MCHKB_TODOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHKB_TODOS.ForeColor = System.Drawing.Color.Gold
        Me.MCHKB_TODOS.Location = New System.Drawing.Point(221, 3)
        Me.MCHKB_TODOS.Name = "MCHKB_TODOS"
        Me.MCHKB_TODOS.Size = New System.Drawing.Size(159, 20)
        Me.MCHKB_TODOS.TabIndex = 4
        Me.MCHKB_TODOS.Text = "Seleccionar Todos"
        Me.MCHKB_TODOS.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(185, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Documentos Encontrados"
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.MisGrid1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 33)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel8.Size = New System.Drawing.Size(383, 231)
        Me.Panel8.TabIndex = 1
        '
        'MisGrid1
        '
        Me.MisGrid1.AllowUserToAddRows = False
        Me.MisGrid1.AllowUserToDeleteRows = False
        Me.MisGrid1.AllowUserToResizeColumns = False
        Me.MisGrid1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan
        Me.MisGrid1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.MisGrid1.BackgroundColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MisGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MisGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MisGrid1.DefaultCellStyle = DataGridViewCellStyle3
        Me.MisGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MisGrid1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.MisGrid1.Location = New System.Drawing.Point(2, 2)
        Me.MisGrid1.MultiSelect = False
        Me.MisGrid1.Name = "MisGrid1"
        Me.MisGrid1.ReadOnly = True
        Me.MisGrid1.RowHeadersVisible = False
        Me.MisGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MisGrid1.Size = New System.Drawing.Size(379, 227)
        Me.MisGrid1.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.E_TOTAL_ITEMS)
        Me.Panel9.Controls.Add(Me.Label7)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 270)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(383, 37)
        Me.Panel9.TabIndex = 2
        '
        'E_TOTAL_ITEMS
        '
        Me.E_TOTAL_ITEMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_TOTAL_ITEMS.Location = New System.Drawing.Point(328, 3)
        Me.E_TOTAL_ITEMS.Name = "E_TOTAL_ITEMS"
        Me.E_TOTAL_ITEMS.Size = New System.Drawing.Size(39, 20)
        Me.E_TOTAL_ITEMS.TabIndex = 4
        Me.E_TOTAL_ITEMS.Text = "999"
        Me.E_TOTAL_ITEMS.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(233, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 16)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Total Items:"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(3, 3)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel11.Size = New System.Drawing.Size(599, 314)
        Me.Panel11.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel12, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel13, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.933775!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.06622!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(595, 310)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel12.Controls.Add(Me.Label9)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(3, 3)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(589, 24)
        Me.Panel12.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(202, 16)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Documentos Seleccionados"
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.MisGrid2)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(3, 33)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel13.Size = New System.Drawing.Size(589, 274)
        Me.Panel13.TabIndex = 1
        '
        'MisGrid2
        '
        Me.MisGrid2.AllowUserToAddRows = False
        Me.MisGrid2.AllowUserToDeleteRows = False
        Me.MisGrid2.AllowUserToResizeColumns = False
        Me.MisGrid2.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightCyan
        Me.MisGrid2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.MisGrid2.BackgroundColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MisGrid2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.MisGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MisGrid2.DefaultCellStyle = DataGridViewCellStyle6
        Me.MisGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MisGrid2.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.MisGrid2.Location = New System.Drawing.Point(2, 2)
        Me.MisGrid2.MultiSelect = False
        Me.MisGrid2.Name = "MisGrid2"
        Me.MisGrid2.ReadOnly = True
        Me.MisGrid2.RowHeadersVisible = False
        Me.MisGrid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MisGrid2.Size = New System.Drawing.Size(585, 270)
        Me.MisGrid2.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel10.Controls.Add(Me.BT_PROCESAR)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(620, 425)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel10.Size = New System.Drawing.Size(395, 54)
        Me.Panel10.TabIndex = 2
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.Location = New System.Drawing.Point(5, 5)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(385, 44)
        Me.BT_PROCESAR.TabIndex = 0
        Me.BT_PROCESAR.Text = "&Procesar Planilla"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.White
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel14, 2)
        Me.Panel14.Controls.Add(Me.TableLayoutPanel5)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(3, 3)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(1012, 90)
        Me.Panel14.TabIndex = 3
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 370.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Panel15, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel16, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel17, 2, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1010, 88)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.White
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.MT_BUSCAR)
        Me.Panel15.Controls.Add(Me.Label17)
        Me.Panel15.Controls.Add(Me.MCB_BUSQUEDA)
        Me.Panel15.Controls.Add(Me.BT_BUSCAR)
        Me.Panel15.Controls.Add(Me.Label16)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel15.Location = New System.Drawing.Point(3, 3)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(364, 82)
        Me.Panel15.TabIndex = 0
        '
        'MT_BUSCAR
        '
        Me.MT_BUSCAR.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_BUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_BUSCAR.ForeColor = System.Drawing.Color.Black
        Me.MT_BUSCAR.Location = New System.Drawing.Point(77, 33)
        Me.MT_BUSCAR.MaxLength = 30
        Me.MT_BUSCAR.Name = "MT_BUSCAR"
        Me.MT_BUSCAR.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_BUSCAR.p_IniciarComo = True
        Me.MT_BUSCAR.Size = New System.Drawing.Size(189, 29)
        Me.MT_BUSCAR.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Maroon
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(44, 38)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(27, 18)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "F1"
        '
        'MCB_BUSQUEDA
        '
        Me.MCB_BUSQUEDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_BUSQUEDA.DropDownWidth = 200
        Me.MCB_BUSQUEDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_BUSQUEDA.FormattingEnabled = True
        Me.MCB_BUSQUEDA.Location = New System.Drawing.Point(77, 7)
        Me.MCB_BUSQUEDA.Name = "MCB_BUSQUEDA"
        Me.MCB_BUSQUEDA.Size = New System.Drawing.Size(171, 24)
        Me.MCB_BUSQUEDA.TabIndex = 0
        '
        'BT_BUSCAR
        '
        Me.BT_BUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_BUSCAR.Location = New System.Drawing.Point(276, 20)
        Me.BT_BUSCAR.Name = "BT_BUSCAR"
        Me.BT_BUSCAR.Size = New System.Drawing.Size(75, 35)
        Me.BT_BUSCAR.TabIndex = 2
        Me.BT_BUSCAR.Text = "&Buscar"
        Me.BT_BUSCAR.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 16)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "A Buscar:"
        '
        'Panel16
        '
        Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel16.Controls.Add(Me.Label5)
        Me.Panel16.Controls.Add(Me.E_CODIGO)
        Me.Panel16.Controls.Add(Me.LINK_FICHA)
        Me.Panel16.Controls.Add(Me.E_CIRIF)
        Me.Panel16.Controls.Add(Me.E_NOMBRE)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.Location = New System.Drawing.Point(373, 3)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel16.Size = New System.Drawing.Size(344, 82)
        Me.Panel16.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(179, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Codigo:"
        '
        'E_CODIGO
        '
        Me.E_CODIGO.AutoSize = True
        Me.E_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_CODIGO.Location = New System.Drawing.Point(240, 40)
        Me.E_CODIGO.Name = "E_CODIGO"
        Me.E_CODIGO.Size = New System.Drawing.Size(98, 18)
        Me.E_CODIGO.TabIndex = 3
        Me.E_CODIGO.Text = "1234567890"
        '
        'LINK_FICHA
        '
        Me.LINK_FICHA.AutoSize = True
        Me.LINK_FICHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LINK_FICHA.Location = New System.Drawing.Point(5, 40)
        Me.LINK_FICHA.Name = "LINK_FICHA"
        Me.LINK_FICHA.Size = New System.Drawing.Size(27, 16)
        Me.LINK_FICHA.TabIndex = 1
        Me.LINK_FICHA.TabStop = True
        Me.LINK_FICHA.Text = "Rif:"
        '
        'E_CIRIF
        '
        Me.E_CIRIF.AutoSize = True
        Me.E_CIRIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_CIRIF.Location = New System.Drawing.Point(38, 38)
        Me.E_CIRIF.Name = "E_CIRIF"
        Me.E_CIRIF.Size = New System.Drawing.Size(110, 18)
        Me.E_CIRIF.TabIndex = 2
        Me.E_CIRIF.Text = "J-12345678-9"
        '
        'E_NOMBRE
        '
        Me.E_NOMBRE.BackColor = System.Drawing.Color.Gainsboro
        Me.E_NOMBRE.Dock = System.Windows.Forms.DockStyle.Top
        Me.E_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_NOMBRE.Location = New System.Drawing.Point(2, 2)
        Me.E_NOMBRE.Name = "E_NOMBRE"
        Me.E_NOMBRE.Size = New System.Drawing.Size(338, 32)
        Me.E_NOMBRE.TabIndex = 0
        Me.E_NOMBRE.Text = "Datos Del Cliente Maximo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dos lineas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.E_NOMBRE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel17
        '
        Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel17.Controls.Add(Me.MN_RETENCION)
        Me.Panel17.Controls.Add(Me.Label12)
        Me.Panel17.Controls.Add(Me.MT_PLANILLA)
        Me.Panel17.Controls.Add(Me.E_MES)
        Me.Panel17.Controls.Add(Me.E_ANO)
        Me.Panel17.Controls.Add(Me.Label8)
        Me.Panel17.Controls.Add(Me.Label4)
        Me.Panel17.Controls.Add(Me.MF_EMISION)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel17.Location = New System.Drawing.Point(723, 3)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(284, 82)
        Me.Panel17.TabIndex = 2
        '
        'MN_RETENCION
        '
        Me.MN_RETENCION._ConSigno = False
        Me.MN_RETENCION._Formato = ""
        Me.MN_RETENCION.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_RETENCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_RETENCION.ForeColor = System.Drawing.Color.Black
        Me.MN_RETENCION.Location = New System.Drawing.Point(109, 55)
        Me.MN_RETENCION.Name = "MN_RETENCION"
        Me.MN_RETENCION.Size = New System.Drawing.Size(70, 22)
        Me.MN_RETENCION.TabIndex = 2
        Me.MN_RETENCION.Text = "75.00"
        Me.MN_RETENCION.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 16)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Retencion(%):"
        '
        'MT_PLANILLA
        '
        Me.MT_PLANILLA.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_PLANILLA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_PLANILLA.ForeColor = System.Drawing.Color.Black
        Me.MT_PLANILLA.Location = New System.Drawing.Point(186, 31)
        Me.MT_PLANILLA.MaxLength = 8
        Me.MT_PLANILLA.Name = "MT_PLANILLA"
        Me.MT_PLANILLA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_PLANILLA.p_IniciarComo = True
        Me.MT_PLANILLA.Size = New System.Drawing.Size(78, 22)
        Me.MT_PLANILLA.TabIndex = 1
        Me.MT_PLANILLA.Text = "12345678"
        '
        'E_MES
        '
        Me.E_MES.AutoSize = True
        Me.E_MES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_MES.Location = New System.Drawing.Point(155, 34)
        Me.E_MES.Name = "E_MES"
        Me.E_MES.Size = New System.Drawing.Size(24, 16)
        Me.E_MES.TabIndex = 5
        Me.E_MES.Text = "03"
        '
        'E_ANO
        '
        Me.E_ANO.AutoSize = True
        Me.E_ANO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_ANO.Location = New System.Drawing.Point(106, 34)
        Me.E_ANO.Name = "E_ANO"
        Me.E_ANO.Size = New System.Drawing.Size(40, 16)
        Me.E_ANO.TabIndex = 4
        Me.E_ANO.Text = "2011"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 16)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Planilla:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Fecha Emision:"
        '
        'MF_EMISION
        '
        Me.MF_EMISION.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_EMISION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_EMISION.ForeColor = System.Drawing.Color.Black
        Me.MF_EMISION.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_EMISION.Location = New System.Drawing.Point(109, 7)
        Me.MF_EMISION.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_EMISION.Name = "MF_EMISION"
        Me.MF_EMISION.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_EMISION.p_IniciarComo = True
        Me.MF_EMISION.Size = New System.Drawing.Size(155, 22)
        Me.MF_EMISION.TabIndex = 0
        Me.MF_EMISION.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 514)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1018, 22)
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.BT_LIMPIAR)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1018, 32)
        Me.Panel2.TabIndex = 0
        '
        'BT_LIMPIAR
        '
        Me.BT_LIMPIAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_LIMPIAR.Location = New System.Drawing.Point(837, 3)
        Me.BT_LIMPIAR.Name = "BT_LIMPIAR"
        Me.BT_LIMPIAR.Size = New System.Drawing.Size(155, 27)
        Me.BT_LIMPIAR.TabIndex = 2
        Me.BT_LIMPIAR.Text = "&Limpiar Todo"
        Me.BT_LIMPIAR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Planilla Retencion IVA "
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1018, 1)
        Me.Panel3.TabIndex = 0
        '
        'PlantillaRetencionIva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(1024, 542)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1040, 580)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1040, 580)
        Me.Name = "PlantillaRetencionIva"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PlantillaRetencionIva"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        CType(Me.MisGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        CType(Me.MisGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents E_DOC_A_PROCESAR As System.Windows.Forms.Label
    Friend WithEvents E_TOTAL_PLANILLA As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents E_TOTAL_ITEMS As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents E_NOMBRE As System.Windows.Forms.Label
    Friend WithEvents E_CIRIF As System.Windows.Forms.Label
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BT_BUSCAR As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LINK_FICHA As System.Windows.Forms.LinkLabel
    Friend WithEvents MT_BUSCAR As MisControles.Controles.MisTextos
    Friend WithEvents MCB_BUSQUEDA As MisControles.Controles.MisComboBox
    Friend WithEvents MisGrid1 As MisControles.Controles.MisGrid
    Friend WithEvents MisGrid2 As MisControles.Controles.MisGrid
    Friend WithEvents MCHKB_TODOS As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents E_CODIGO As System.Windows.Forms.Label
    Friend WithEvents E_MES As System.Windows.Forms.Label
    Friend WithEvents E_ANO As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MF_EMISION As MisControles.Controles.MisFechas
    Friend WithEvents MT_PLANILLA As MisControles.Controles.MisTextos
    Friend WithEvents MN_RETENCION As MisControles.Controles.MisNumeros
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BT_LIMPIAR As System.Windows.Forms.Button
End Class

