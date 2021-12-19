<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CxC_BusquedaAvanzada
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
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Panel15 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.MG_CLIENTE = New MisControles.Controles.MisGrid
        Me.Panel14 = New System.Windows.Forms.Panel
        Me.LB_IMPORTE = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LB_ITEMS_1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel16 = New System.Windows.Forms.Panel
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.MT_NRODOCUMENTO = New MisControles.Controles.MisTextos
        Me.MCB_TIPODOCUMENTOS = New MisControles.Controles.MisComboBox
        Me.MCB_COBRADORES = New MisControles.Controles.MisComboBox
        Me.MCB_VENDEDORES = New MisControles.Controles.MisComboBox
        Me.MCB_ZONAS = New MisControles.Controles.MisComboBox
        Me.MCB_ESTADOS = New MisControles.Controles.MisComboBox
        Me.MCB_GRUPOS = New MisControles.Controles.MisComboBox
        Me.MC_NRODOCUMENTO = New MisControles.Controles.MisCheckBox
        Me.MC_TIPODOCUMENTOS = New MisControles.Controles.MisCheckBox
        Me.MC_COBRADORES = New MisControles.Controles.MisCheckBox
        Me.MC_VENDEDORES = New MisControles.Controles.MisCheckBox
        Me.MC_ZONAS = New MisControles.Controles.MisCheckBox
        Me.MC_ESTADOS = New MisControles.Controles.MisCheckBox
        Me.MC_GRUPOS = New MisControles.Controles.MisCheckBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.MG_CLIENTE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel14.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel5.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(970, 478)
        Me.Panel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(970, 426)
        Me.Panel4.TabIndex = 7
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.23977!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.76023!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(970, 426)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Honeydew
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Panel15)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(470, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(497, 420)
        Me.Panel6.TabIndex = 1
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel15.Controls.Add(Me.Panel16)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel15.Location = New System.Drawing.Point(0, 0)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(495, 418)
        Me.Panel15.TabIndex = 6
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.10101!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.89899!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel7, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel14, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 27)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.70077!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.29923!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(495, 391)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'Panel7
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel7, 2)
        Me.Panel7.Controls.Add(Me.MG_CLIENTE)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel7.Size = New System.Drawing.Size(489, 333)
        Me.Panel7.TabIndex = 0
        '
        'MG_CLIENTE
        '
        Me.MG_CLIENTE.AllowUserToAddRows = False
        Me.MG_CLIENTE.AllowUserToDeleteRows = False
        Me.MG_CLIENTE.AllowUserToResizeColumns = False
        Me.MG_CLIENTE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan
        Me.MG_CLIENTE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.MG_CLIENTE.BackgroundColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MG_CLIENTE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MG_CLIENTE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MG_CLIENTE.DefaultCellStyle = DataGridViewCellStyle3
        Me.MG_CLIENTE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MG_CLIENTE.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.MG_CLIENTE.Location = New System.Drawing.Point(2, 2)
        Me.MG_CLIENTE.Margin = New System.Windows.Forms.Padding(0)
        Me.MG_CLIENTE.MultiSelect = False
        Me.MG_CLIENTE.Name = "MG_CLIENTE"
        Me.MG_CLIENTE.ReadOnly = True
        Me.MG_CLIENTE.RowHeadersVisible = False
        Me.MG_CLIENTE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MG_CLIENTE.Size = New System.Drawing.Size(485, 329)
        Me.MG_CLIENTE.TabIndex = 5
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Lavender
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel14, 2)
        Me.Panel14.Controls.Add(Me.LB_IMPORTE)
        Me.Panel14.Controls.Add(Me.Label2)
        Me.Panel14.Controls.Add(Me.LB_ITEMS_1)
        Me.Panel14.Controls.Add(Me.Label9)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(3, 339)
        Me.Panel14.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel14.Size = New System.Drawing.Size(489, 52)
        Me.Panel14.TabIndex = 4
        '
        'LB_IMPORTE
        '
        Me.LB_IMPORTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_IMPORTE.Location = New System.Drawing.Point(367, 23)
        Me.LB_IMPORTE.Name = "LB_IMPORTE"
        Me.LB_IMPORTE.Size = New System.Drawing.Size(115, 24)
        Me.LB_IMPORTE.TabIndex = 44
        Me.LB_IMPORTE.Text = "9999999.99"
        Me.LB_IMPORTE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(338, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 16)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Total Importe:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LB_ITEMS_1
        '
        Me.LB_ITEMS_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_ITEMS_1.Location = New System.Drawing.Point(102, 27)
        Me.LB_ITEMS_1.Name = "LB_ITEMS_1"
        Me.LB_ITEMS_1.Size = New System.Drawing.Size(49, 20)
        Me.LB_ITEMS_1.TabIndex = 42
        Me.LB_ITEMS_1.Text = "9999"
        Me.LB_ITEMS_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 5)
        Me.Label9.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 16)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Registros Encontrados:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.Maroon
        Me.Panel16.Controls.Add(Me.Label13)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(495, 27)
        Me.Panel16.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(3, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 20)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Clientes "
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Honeydew
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.BT_PROCESAR)
        Me.Panel5.Controls.Add(Me.MT_NRODOCUMENTO)
        Me.Panel5.Controls.Add(Me.MCB_TIPODOCUMENTOS)
        Me.Panel5.Controls.Add(Me.MCB_COBRADORES)
        Me.Panel5.Controls.Add(Me.MCB_VENDEDORES)
        Me.Panel5.Controls.Add(Me.MCB_ZONAS)
        Me.Panel5.Controls.Add(Me.MCB_ESTADOS)
        Me.Panel5.Controls.Add(Me.MCB_GRUPOS)
        Me.Panel5.Controls.Add(Me.MC_NRODOCUMENTO)
        Me.Panel5.Controls.Add(Me.MC_TIPODOCUMENTOS)
        Me.Panel5.Controls.Add(Me.MC_COBRADORES)
        Me.Panel5.Controls.Add(Me.MC_VENDEDORES)
        Me.Panel5.Controls.Add(Me.MC_ZONAS)
        Me.Panel5.Controls.Add(Me.MC_ESTADOS)
        Me.Panel5.Controls.Add(Me.MC_GRUPOS)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(461, 420)
        Me.Panel5.TabIndex = 0
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.Location = New System.Drawing.Point(193, 271)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(251, 54)
        Me.BT_PROCESAR.TabIndex = 14
        Me.BT_PROCESAR.Text = "Procesar / Buscar"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'MT_NRODOCUMENTO
        '
        Me.MT_NRODOCUMENTO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_NRODOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_NRODOCUMENTO.ForeColor = System.Drawing.Color.Black
        Me.MT_NRODOCUMENTO.Location = New System.Drawing.Point(193, 210)
        Me.MT_NRODOCUMENTO.MaxLength = 20
        Me.MT_NRODOCUMENTO.Name = "MT_NRODOCUMENTO"
        Me.MT_NRODOCUMENTO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_NRODOCUMENTO.p_IniciarComo = True
        Me.MT_NRODOCUMENTO.Size = New System.Drawing.Size(251, 26)
        Me.MT_NRODOCUMENTO.TabIndex = 13
        '
        'MCB_TIPODOCUMENTOS
        '
        Me.MCB_TIPODOCUMENTOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_TIPODOCUMENTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_TIPODOCUMENTOS.FormattingEnabled = True
        Me.MCB_TIPODOCUMENTOS.Location = New System.Drawing.Point(193, 180)
        Me.MCB_TIPODOCUMENTOS.Name = "MCB_TIPODOCUMENTOS"
        Me.MCB_TIPODOCUMENTOS.Size = New System.Drawing.Size(251, 26)
        Me.MCB_TIPODOCUMENTOS.TabIndex = 11
        '
        'MCB_COBRADORES
        '
        Me.MCB_COBRADORES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_COBRADORES.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_COBRADORES.FormattingEnabled = True
        Me.MCB_COBRADORES.Location = New System.Drawing.Point(193, 150)
        Me.MCB_COBRADORES.Name = "MCB_COBRADORES"
        Me.MCB_COBRADORES.Size = New System.Drawing.Size(251, 26)
        Me.MCB_COBRADORES.TabIndex = 9
        '
        'MCB_VENDEDORES
        '
        Me.MCB_VENDEDORES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_VENDEDORES.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_VENDEDORES.FormattingEnabled = True
        Me.MCB_VENDEDORES.Location = New System.Drawing.Point(193, 120)
        Me.MCB_VENDEDORES.Name = "MCB_VENDEDORES"
        Me.MCB_VENDEDORES.Size = New System.Drawing.Size(251, 26)
        Me.MCB_VENDEDORES.TabIndex = 7
        '
        'MCB_ZONAS
        '
        Me.MCB_ZONAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ZONAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ZONAS.FormattingEnabled = True
        Me.MCB_ZONAS.Location = New System.Drawing.Point(193, 90)
        Me.MCB_ZONAS.Name = "MCB_ZONAS"
        Me.MCB_ZONAS.Size = New System.Drawing.Size(251, 26)
        Me.MCB_ZONAS.TabIndex = 5
        '
        'MCB_ESTADOS
        '
        Me.MCB_ESTADOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTADOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTADOS.FormattingEnabled = True
        Me.MCB_ESTADOS.Location = New System.Drawing.Point(193, 60)
        Me.MCB_ESTADOS.Name = "MCB_ESTADOS"
        Me.MCB_ESTADOS.Size = New System.Drawing.Size(251, 26)
        Me.MCB_ESTADOS.TabIndex = 3
        '
        'MCB_GRUPOS
        '
        Me.MCB_GRUPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_GRUPOS.FormattingEnabled = True
        Me.MCB_GRUPOS.Location = New System.Drawing.Point(193, 30)
        Me.MCB_GRUPOS.Name = "MCB_GRUPOS"
        Me.MCB_GRUPOS.Size = New System.Drawing.Size(251, 26)
        Me.MCB_GRUPOS.TabIndex = 1
        '
        'MC_NRODOCUMENTO
        '
        Me.MC_NRODOCUMENTO.AutoSize = True
        Me.MC_NRODOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_NRODOCUMENTO.Location = New System.Drawing.Point(9, 210)
        Me.MC_NRODOCUMENTO.Name = "MC_NRODOCUMENTO"
        Me.MC_NRODOCUMENTO.Size = New System.Drawing.Size(178, 24)
        Me.MC_NRODOCUMENTO.TabIndex = 12
        Me.MC_NRODOCUMENTO.Text = "Por Número De Doc.:"
        Me.MC_NRODOCUMENTO.UseVisualStyleBackColor = True
        '
        'MC_TIPODOCUMENTOS
        '
        Me.MC_TIPODOCUMENTOS.AutoSize = True
        Me.MC_TIPODOCUMENTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_TIPODOCUMENTOS.Location = New System.Drawing.Point(9, 180)
        Me.MC_TIPODOCUMENTOS.Name = "MC_TIPODOCUMENTOS"
        Me.MC_TIPODOCUMENTOS.Size = New System.Drawing.Size(152, 24)
        Me.MC_TIPODOCUMENTOS.TabIndex = 10
        Me.MC_TIPODOCUMENTOS.Text = "Por Tipo De Doc.:"
        Me.MC_TIPODOCUMENTOS.UseVisualStyleBackColor = True
        '
        'MC_COBRADORES
        '
        Me.MC_COBRADORES.AutoSize = True
        Me.MC_COBRADORES.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_COBRADORES.Location = New System.Drawing.Point(9, 150)
        Me.MC_COBRADORES.Name = "MC_COBRADORES"
        Me.MC_COBRADORES.Size = New System.Drawing.Size(143, 24)
        Me.MC_COBRADORES.TabIndex = 8
        Me.MC_COBRADORES.Text = "Por Cobradores:"
        Me.MC_COBRADORES.UseVisualStyleBackColor = True
        '
        'MC_VENDEDORES
        '
        Me.MC_VENDEDORES.AutoSize = True
        Me.MC_VENDEDORES.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_VENDEDORES.Location = New System.Drawing.Point(9, 120)
        Me.MC_VENDEDORES.Name = "MC_VENDEDORES"
        Me.MC_VENDEDORES.Size = New System.Drawing.Size(147, 24)
        Me.MC_VENDEDORES.TabIndex = 6
        Me.MC_VENDEDORES.Text = "Por Vendedores:"
        Me.MC_VENDEDORES.UseVisualStyleBackColor = True
        '
        'MC_ZONAS
        '
        Me.MC_ZONAS.AutoSize = True
        Me.MC_ZONAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_ZONAS.Location = New System.Drawing.Point(9, 90)
        Me.MC_ZONAS.Name = "MC_ZONAS"
        Me.MC_ZONAS.Size = New System.Drawing.Size(105, 24)
        Me.MC_ZONAS.TabIndex = 4
        Me.MC_ZONAS.Text = "Por Zonas:"
        Me.MC_ZONAS.UseVisualStyleBackColor = True
        '
        'MC_ESTADOS
        '
        Me.MC_ESTADOS.AutoSize = True
        Me.MC_ESTADOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_ESTADOS.Location = New System.Drawing.Point(9, 60)
        Me.MC_ESTADOS.Name = "MC_ESTADOS"
        Me.MC_ESTADOS.Size = New System.Drawing.Size(119, 24)
        Me.MC_ESTADOS.TabIndex = 2
        Me.MC_ESTADOS.Text = "Por Estados:"
        Me.MC_ESTADOS.UseVisualStyleBackColor = True
        '
        'MC_GRUPOS
        '
        Me.MC_GRUPOS.AutoSize = True
        Me.MC_GRUPOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_GRUPOS.Location = New System.Drawing.Point(9, 30)
        Me.MC_GRUPOS.Name = "MC_GRUPOS"
        Me.MC_GRUPOS.Size = New System.Drawing.Size(113, 24)
        Me.MC_GRUPOS.TabIndex = 0
        Me.MC_GRUPOS.Text = "Por Grupos:"
        Me.MC_GRUPOS.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(970, 30)
        Me.Panel2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Filtrar Clientes:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 29)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(970, 1)
        Me.Panel3.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 456)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(970, 22)
        Me.StatusStrip1.TabIndex = 5
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
        'CxC_BusquedaAvanzada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGreen
        Me.ClientSize = New System.Drawing.Size(974, 482)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(990, 520)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(990, 520)
        Me.Name = "CxC_BusquedaAvanzada"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda Avanzada De Clientes"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.MG_CLIENTE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
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
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents MG_CLIENTE As MisControles.Controles.MisGrid
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents LB_ITEMS_1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents MC_TIPODOCUMENTOS As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_COBRADORES As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_VENDEDORES As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_ZONAS As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_ESTADOS As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_GRUPOS As MisControles.Controles.MisCheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MC_NRODOCUMENTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_ZONAS As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ESTADOS As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_GRUPOS As MisControles.Controles.MisComboBox
    Friend WithEvents MT_NRODOCUMENTO As MisControles.Controles.MisTextos
    Friend WithEvents MCB_TIPODOCUMENTOS As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_COBRADORES As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_VENDEDORES As MisControles.Controles.MisComboBox
    Friend WithEvents LB_IMPORTE As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
End Class
