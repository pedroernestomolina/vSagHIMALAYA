<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventarioDepositos
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.BT_GRABAR = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.PB_3 = New System.Windows.Forms.PictureBox
        Me.PB_1 = New System.Windows.Forms.PictureBox
        Me.PB_2 = New System.Windows.Forms.PictureBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.MisGrid1 = New MisControles.Controles.MisGrid
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.MN_2 = New MisControles.Controles.MisNumeros
        Me.MN_1 = New MisControles.Controles.MisNumeros
        Me.MT_4 = New MisControles.Controles.MisTextos
        Me.MT_3 = New MisControles.Controles.MisTextos
        Me.MT_2 = New MisControles.Controles.MisTextos
        Me.MT_1 = New MisControles.Controles.MisTextos
        Me.E_EMPAQUE = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.L_EXISTENCIA_RESERVA = New System.Windows.Forms.LinkLabel
        Me.E_EXISTENCIA_DISPONIBLE = New System.Windows.Forms.Label
        Me.E_EXISTENCIA_RESERVA = New System.Windows.Forms.Label
        Me.E_EXISTENCIA_ACTUAL = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.E_PRODUCTO = New System.Windows.Forms.Label
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.L_DEPOSITOS = New System.Windows.Forms.LinkLabel
        Me.MCB_DEPOSITOS = New MisControles.Controles.MisComboBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.PB_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.MisGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(824, 327)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.91572!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.08428!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 32)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.16974!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.83026!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(822, 271)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel8.Controls.Add(Me.BT_GRABAR)
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Controls.Add(Me.Label5)
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.PB_3)
        Me.Panel8.Controls.Add(Me.PB_1)
        Me.Panel8.Controls.Add(Me.PB_2)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(273, 203)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(546, 65)
        Me.Panel8.TabIndex = 3
        '
        'BT_GRABAR
        '
        Me.BT_GRABAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GRABAR.Location = New System.Drawing.Point(414, 11)
        Me.BT_GRABAR.Name = "BT_GRABAR"
        Me.BT_GRABAR.Size = New System.Drawing.Size(114, 45)
        Me.BT_GRABAR.TabIndex = 0
        Me.BT_GRABAR.Text = "&Guardar Datos"
        Me.ToolTip1.SetToolTip(Me.BT_GRABAR, "Guardar Cambios Efectuados")
        Me.BT_GRABAR.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Sienna
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(207, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 15)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "F3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Sienna
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(115, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 15)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "F2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Sienna
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(23, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 15)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "F1"
        '
        'PB_3
        '
        Me.PB_3.Image = Global._VsagAdm.My.Resources.Resources.DataBorrar
        Me.PB_3.Location = New System.Drawing.Point(226, 11)
        Me.PB_3.Name = "PB_3"
        Me.PB_3.Size = New System.Drawing.Size(50, 45)
        Me.PB_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_3.TabIndex = 29
        Me.PB_3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PB_3, "Eliminar Item")
        '
        'PB_1
        '
        Me.PB_1.ErrorImage = Nothing
        Me.PB_1.Image = Global._VsagAdm.My.Resources.Resources.DataAgregar
        Me.PB_1.Location = New System.Drawing.Point(42, 11)
        Me.PB_1.Name = "PB_1"
        Me.PB_1.Size = New System.Drawing.Size(50, 45)
        Me.PB_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_1.TabIndex = 27
        Me.PB_1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PB_1, "Agregar Nuevo Item")
        '
        'PB_2
        '
        Me.PB_2.Image = Global._VsagAdm.My.Resources.Resources.database_actualizar_1
        Me.PB_2.Location = New System.Drawing.Point(133, 11)
        Me.PB_2.Name = "PB_2"
        Me.PB_2.Size = New System.Drawing.Size(50, 45)
        Me.PB_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_2.TabIndex = 28
        Me.PB_2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PB_2, "Modificar / Actualizar Item")
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.MisGrid1, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.39344!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.60656!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(264, 194)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGray
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(258, 25)
        Me.Panel3.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Depositos Asisgnados"
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MisGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MisGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MisGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MisGrid1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.MisGrid1.Location = New System.Drawing.Point(3, 34)
        Me.MisGrid1.MultiSelect = False
        Me.MisGrid1.Name = "MisGrid1"
        Me.MisGrid1.ReadOnly = True
        Me.MisGrid1.RowHeadersVisible = False
        Me.MisGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MisGrid1.Size = New System.Drawing.Size(258, 157)
        Me.MisGrid1.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.MN_2)
        Me.Panel5.Controls.Add(Me.MN_1)
        Me.Panel5.Controls.Add(Me.MT_4)
        Me.Panel5.Controls.Add(Me.MT_3)
        Me.Panel5.Controls.Add(Me.MT_2)
        Me.Panel5.Controls.Add(Me.MT_1)
        Me.Panel5.Controls.Add(Me.E_EMPAQUE)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Label31)
        Me.Panel5.Controls.Add(Me.Label28)
        Me.Panel5.Controls.Add(Me.Label24)
        Me.Panel5.Controls.Add(Me.Label22)
        Me.Panel5.Controls.Add(Me.Label21)
        Me.Panel5.Controls.Add(Me.Label20)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.L_EXISTENCIA_RESERVA)
        Me.Panel5.Controls.Add(Me.E_EXISTENCIA_DISPONIBLE)
        Me.Panel5.Controls.Add(Me.E_EXISTENCIA_RESERVA)
        Me.Panel5.Controls.Add(Me.E_EXISTENCIA_ACTUAL)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Controls.Add(Me.E_PRODUCTO)
        Me.Panel5.Controls.Add(Me.ShapeContainer2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(273, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel5.Size = New System.Drawing.Size(546, 194)
        Me.Panel5.TabIndex = 1
        '
        'MN_2
        '
        Me.MN_2._ConSigno = False
        Me.MN_2._Formato = ""
        Me.MN_2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_2.ForeColor = System.Drawing.Color.Black
        Me.MN_2.Location = New System.Drawing.Point(427, 166)
        Me.MN_2.Name = "MN_2"
        Me.MN_2.Size = New System.Drawing.Size(100, 22)
        Me.MN_2.TabIndex = 6
        Me.MN_2.Text = "0"
        Me.MN_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_1
        '
        Me.MN_1._ConSigno = False
        Me.MN_1._Formato = ""
        Me.MN_1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_1.ForeColor = System.Drawing.Color.Black
        Me.MN_1.Location = New System.Drawing.Point(427, 142)
        Me.MN_1.Name = "MN_1"
        Me.MN_1.Size = New System.Drawing.Size(100, 24)
        Me.MN_1.TabIndex = 5
        Me.MN_1.Text = "0"
        Me.MN_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MT_4
        '
        Me.MT_4.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_4.ForeColor = System.Drawing.Color.Black
        Me.MT_4.Location = New System.Drawing.Point(339, 116)
        Me.MT_4.MaxLength = 20
        Me.MT_4.Name = "MT_4"
        Me.MT_4.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_4.p_IniciarComo = True
        Me.MT_4.Size = New System.Drawing.Size(188, 22)
        Me.MT_4.TabIndex = 4
        '
        'MT_3
        '
        Me.MT_3.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_3.ForeColor = System.Drawing.Color.Black
        Me.MT_3.Location = New System.Drawing.Point(339, 94)
        Me.MT_3.MaxLength = 20
        Me.MT_3.Name = "MT_3"
        Me.MT_3.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_3.p_IniciarComo = True
        Me.MT_3.Size = New System.Drawing.Size(188, 22)
        Me.MT_3.TabIndex = 3
        '
        'MT_2
        '
        Me.MT_2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_2.ForeColor = System.Drawing.Color.Black
        Me.MT_2.Location = New System.Drawing.Point(339, 72)
        Me.MT_2.MaxLength = 20
        Me.MT_2.Name = "MT_2"
        Me.MT_2.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_2.p_IniciarComo = True
        Me.MT_2.Size = New System.Drawing.Size(188, 22)
        Me.MT_2.TabIndex = 2
        '
        'MT_1
        '
        Me.MT_1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_1.ForeColor = System.Drawing.Color.Black
        Me.MT_1.Location = New System.Drawing.Point(339, 50)
        Me.MT_1.MaxLength = 20
        Me.MT_1.Name = "MT_1"
        Me.MT_1.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_1.p_IniciarComo = True
        Me.MT_1.Size = New System.Drawing.Size(188, 22)
        Me.MT_1.TabIndex = 1
        '
        'E_EMPAQUE
        '
        Me.E_EMPAQUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_EMPAQUE.Location = New System.Drawing.Point(52, 69)
        Me.E_EMPAQUE.Name = "E_EMPAQUE"
        Me.E_EMPAQUE.Size = New System.Drawing.Size(146, 16)
        Me.E_EMPAQUE.TabIndex = 23
        Me.E_EMPAQUE.Text = "(Unidad Empaque) / 12"
        Me.E_EMPAQUE.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Lavender
        Me.Panel7.Location = New System.Drawing.Point(212, 43)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(11, 144)
        Me.Panel7.TabIndex = 22
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(324, 166)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(97, 18)
        Me.Label31.TabIndex = 20
        Me.Label31.Text = "Nivel Optimo:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(324, 145)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(97, 18)
        Me.Label28.TabIndex = 18
        Me.Label28.Text = "Nivel Minimo:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(45, 93)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 18)
        Me.Label24.TabIndex = 14
        Me.Label24.Text = "Actual:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(237, 111)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(96, 18)
        Me.Label22.TabIndex = 12
        Me.Label22.Text = "Ubicacion(4):"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(237, 92)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 18)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Ubicacion(3):"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(237, 73)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 18)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Ubicacion(2):"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(237, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 18)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Ubicacion(1):"
        '
        'L_EXISTENCIA_RESERVA
        '
        Me.L_EXISTENCIA_RESERVA.AutoSize = True
        Me.L_EXISTENCIA_RESERVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_EXISTENCIA_RESERVA.Location = New System.Drawing.Point(13, 115)
        Me.L_EXISTENCIA_RESERVA.Name = "L_EXISTENCIA_RESERVA"
        Me.L_EXISTENCIA_RESERVA.Size = New System.Drawing.Size(84, 18)
        Me.L_EXISTENCIA_RESERVA.TabIndex = 0
        Me.L_EXISTENCIA_RESERVA.TabStop = True
        Me.L_EXISTENCIA_RESERVA.Text = "Reservado:"
        Me.ToolTip1.SetToolTip(Me.L_EXISTENCIA_RESERVA, "Mercancia En Reserva")
        '
        'E_EXISTENCIA_DISPONIBLE
        '
        Me.E_EXISTENCIA_DISPONIBLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_EXISTENCIA_DISPONIBLE.Location = New System.Drawing.Point(103, 144)
        Me.E_EXISTENCIA_DISPONIBLE.Name = "E_EXISTENCIA_DISPONIBLE"
        Me.E_EXISTENCIA_DISPONIBLE.Size = New System.Drawing.Size(94, 18)
        Me.E_EXISTENCIA_DISPONIBLE.TabIndex = 6
        Me.E_EXISTENCIA_DISPONIBLE.Text = "999999.999"
        Me.E_EXISTENCIA_DISPONIBLE.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_EXISTENCIA_RESERVA
        '
        Me.E_EXISTENCIA_RESERVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_EXISTENCIA_RESERVA.Location = New System.Drawing.Point(113, 115)
        Me.E_EXISTENCIA_RESERVA.Name = "E_EXISTENCIA_RESERVA"
        Me.E_EXISTENCIA_RESERVA.Size = New System.Drawing.Size(84, 18)
        Me.E_EXISTENCIA_RESERVA.TabIndex = 5
        Me.E_EXISTENCIA_RESERVA.Text = "999999.999"
        Me.E_EXISTENCIA_RESERVA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_EXISTENCIA_ACTUAL
        '
        Me.E_EXISTENCIA_ACTUAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_EXISTENCIA_ACTUAL.Location = New System.Drawing.Point(113, 93)
        Me.E_EXISTENCIA_ACTUAL.Name = "E_EXISTENCIA_ACTUAL"
        Me.E_EXISTENCIA_ACTUAL.Size = New System.Drawing.Size(84, 18)
        Me.E_EXISTENCIA_ACTUAL.TabIndex = 4
        Me.E_EXISTENCIA_ACTUAL.Text = "999999.999"
        Me.E_EXISTENCIA_ACTUAL.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 144)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 18)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Disponible:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 20)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Existencia:"
        '
        'E_PRODUCTO
        '
        Me.E_PRODUCTO.BackColor = System.Drawing.Color.Gainsboro
        Me.E_PRODUCTO.Dock = System.Windows.Forms.DockStyle.Top
        Me.E_PRODUCTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_PRODUCTO.Location = New System.Drawing.Point(2, 2)
        Me.E_PRODUCTO.Name = "E_PRODUCTO"
        Me.E_PRODUCTO.Size = New System.Drawing.Size(540, 38)
        Me.E_PRODUCTO.TabIndex = 0
        Me.E_PRODUCTO.Text = "PRODUCTO MAXIMO DOS LINEAS " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DE TEXTO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.E_PRODUCTO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(2, 2)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2})
        Me.ShapeContainer2.Size = New System.Drawing.Size(540, 188)
        Me.ShapeContainer2.TabIndex = 7
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 103
        Me.LineShape2.X2 = 195
        Me.LineShape2.Y1 = 134
        Me.LineShape2.Y2 = 134
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.L_DEPOSITOS)
        Me.Panel6.Controls.Add(Me.MCB_DEPOSITOS)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 203)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(264, 65)
        Me.Panel6.TabIndex = 2
        '
        'L_DEPOSITOS
        '
        Me.L_DEPOSITOS.AutoSize = True
        Me.L_DEPOSITOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_DEPOSITOS.Location = New System.Drawing.Point(3, 3)
        Me.L_DEPOSITOS.Name = "L_DEPOSITOS"
        Me.L_DEPOSITOS.Size = New System.Drawing.Size(149, 16)
        Me.L_DEPOSITOS.TabIndex = 1
        Me.L_DEPOSITOS.TabStop = True
        Me.L_DEPOSITOS.Text = "Depositos Encontrados"
        Me.ToolTip1.SetToolTip(Me.L_DEPOSITOS, "Control De Depositos")
        '
        'MCB_DEPOSITOS
        '
        Me.MCB_DEPOSITOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_DEPOSITOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_DEPOSITOS.FormattingEnabled = True
        Me.MCB_DEPOSITOS.Location = New System.Drawing.Point(38, 26)
        Me.MCB_DEPOSITOS.Name = "MCB_DEPOSITOS"
        Me.MCB_DEPOSITOS.Size = New System.Drawing.Size(223, 26)
        Me.MCB_DEPOSITOS.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 303)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(822, 22)
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
        Me.Panel2.BackColor = System.Drawing.Color.Maroon
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel2.Size = New System.Drawing.Size(822, 32)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(818, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Crear / Eliminar Depositos Del Producto !!!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InventarioDepositos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(828, 331)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(844, 369)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(844, 369)
        Me.Name = "InventarioDepositos"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Producto"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.PB_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.MisGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents MisGrid1 As MisControles.Controles.MisGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents E_PRODUCTO As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents E_EXISTENCIA_DISPONIBLE As System.Windows.Forms.Label
    Friend WithEvents E_EXISTENCIA_RESERVA As System.Windows.Forms.Label
    Friend WithEvents E_EXISTENCIA_ACTUAL As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents L_EXISTENCIA_RESERVA As System.Windows.Forms.LinkLabel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents E_EMPAQUE As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents MCB_DEPOSITOS As MisControles.Controles.MisComboBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents BT_GRABAR As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PB_3 As System.Windows.Forms.PictureBox
    Friend WithEvents PB_1 As System.Windows.Forms.PictureBox
    Friend WithEvents PB_2 As System.Windows.Forms.PictureBox
    Friend WithEvents MT_1 As MisControles.Controles.MisTextos
    Friend WithEvents MT_4 As MisControles.Controles.MisTextos
    Friend WithEvents MT_3 As MisControles.Controles.MisTextos
    Friend WithEvents MT_2 As MisControles.Controles.MisTextos
    Friend WithEvents MN_2 As MisControles.Controles.MisNumeros
    Friend WithEvents MN_1 As MisControles.Controles.MisNumeros
    Friend WithEvents L_DEPOSITOS As System.Windows.Forms.LinkLabel
End Class