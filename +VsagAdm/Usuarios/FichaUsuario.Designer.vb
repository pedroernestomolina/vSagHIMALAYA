<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichaUsuario
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.MisGrid1 = New MisControles.Controles.MisGrid
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.E_REGISTROS = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.LINK_GRUPO = New System.Windows.Forms.LinkLabel
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.MCB_ESTATUS = New MisControles.Controles.MisComboBox
        Me.MCB_GRUPO = New MisControles.Controles.MisComboBox
        Me.MT_CLAV_USUARIO = New MisControles.Controles.MisTextos
        Me.MT_COD_USUARIO = New MisControles.Controles.MisTextos
        Me.MT_NOM_USUARIO = New MisControles.Controles.MisTextos
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.BT_GRABAR = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PB_3 = New System.Windows.Forms.PictureBox
        Me.PB_1 = New System.Windows.Forms.PictureBox
        Me.PB_2 = New System.Windows.Forms.PictureBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.MisGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.PB_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(750, 339)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 319.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 429.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(748, 315)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(313, 31)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Control De Usuarios !!!"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.MisGrid1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel3.Size = New System.Drawing.Size(313, 272)
        Me.Panel3.TabIndex = 1
        '
        'MisGrid1
        '
        Me.MisGrid1.AllowUserToAddRows = False
        Me.MisGrid1.AllowUserToDeleteRows = False
        Me.MisGrid1.AllowUserToResizeColumns = False
        Me.MisGrid1.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.MisGrid1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.MisGrid1.BackgroundColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MisGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.MisGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MisGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MisGrid1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.MisGrid1.Location = New System.Drawing.Point(2, 2)
        Me.MisGrid1.MultiSelect = False
        Me.MisGrid1.Name = "MisGrid1"
        Me.MisGrid1.ReadOnly = True
        Me.MisGrid1.RowHeadersVisible = False
        Me.MisGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MisGrid1.Size = New System.Drawing.Size(309, 268)
        Me.MisGrid1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(322, 3)
        Me.Panel4.Name = "Panel4"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel4, 2)
        Me.Panel4.Size = New System.Drawing.Size(423, 309)
        Me.Panel4.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 423.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel6, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel7, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 218.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(423, 309)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel5.Size = New System.Drawing.Size(417, 28)
        Me.Panel5.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(2, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(413, 24)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Detalles Del Usuario"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.E_REGISTROS)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.LINK_GRUPO)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.MCB_ESTATUS)
        Me.Panel6.Controls.Add(Me.MCB_GRUPO)
        Me.Panel6.Controls.Add(Me.MT_CLAV_USUARIO)
        Me.Panel6.Controls.Add(Me.MT_COD_USUARIO)
        Me.Panel6.Controls.Add(Me.MT_NOM_USUARIO)
        Me.Panel6.Controls.Add(Me.ShapeContainer1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 37)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(417, 212)
        Me.Panel6.TabIndex = 0
        '
        'E_REGISTROS
        '
        Me.E_REGISTROS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_REGISTROS.Location = New System.Drawing.Point(352, 186)
        Me.E_REGISTROS.Name = "E_REGISTROS"
        Me.E_REGISTROS.Size = New System.Drawing.Size(49, 20)
        Me.E_REGISTROS.TabIndex = 13
        Me.E_REGISTROS.Text = "9999"
        Me.E_REGISTROS.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(212, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 18)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Items Encontrados:"
        '
        'LINK_GRUPO
        '
        Me.LINK_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LINK_GRUPO.Location = New System.Drawing.Point(11, 106)
        Me.LINK_GRUPO.Name = "LINK_GRUPO"
        Me.LINK_GRUPO.Size = New System.Drawing.Size(103, 36)
        Me.LINK_GRUPO.TabIndex = 11
        Me.LINK_GRUPO.TabStop = True
        Me.LINK_GRUPO.Text = "Grupo Al Cual Pertenece:"
        Me.LINK_GRUPO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(52, 148)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 18)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Estatus:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(65, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 18)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Clave:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(54, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 18)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Codigo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 18)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Usuario:"
        '
        'MCB_ESTATUS
        '
        Me.MCB_ESTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_ESTATUS.FormattingEnabled = True
        Me.MCB_ESTATUS.Location = New System.Drawing.Point(143, 145)
        Me.MCB_ESTATUS.Name = "MCB_ESTATUS"
        Me.MCB_ESTATUS.Size = New System.Drawing.Size(167, 26)
        Me.MCB_ESTATUS.TabIndex = 4
        '
        'MCB_GRUPO
        '
        Me.MCB_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPO.DropDownWidth = 250
        Me.MCB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_GRUPO.FormattingEnabled = True
        Me.MCB_GRUPO.Location = New System.Drawing.Point(143, 112)
        Me.MCB_GRUPO.Name = "MCB_GRUPO"
        Me.MCB_GRUPO.Size = New System.Drawing.Size(167, 26)
        Me.MCB_GRUPO.TabIndex = 3
        '
        'MT_CLAV_USUARIO
        '
        Me.MT_CLAV_USUARIO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_CLAV_USUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_CLAV_USUARIO.ForeColor = System.Drawing.Color.Black
        Me.MT_CLAV_USUARIO.Location = New System.Drawing.Point(143, 74)
        Me.MT_CLAV_USUARIO.MaxLength = 20
        Me.MT_CLAV_USUARIO.Name = "MT_CLAV_USUARIO"
        Me.MT_CLAV_USUARIO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_CLAV_USUARIO.p_IniciarComo = True
        Me.MT_CLAV_USUARIO.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.MT_CLAV_USUARIO.Size = New System.Drawing.Size(167, 24)
        Me.MT_CLAV_USUARIO.TabIndex = 2
        '
        'MT_COD_USUARIO
        '
        Me.MT_COD_USUARIO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_COD_USUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_COD_USUARIO.ForeColor = System.Drawing.Color.Black
        Me.MT_COD_USUARIO.Location = New System.Drawing.Point(142, 48)
        Me.MT_COD_USUARIO.MaxLength = 20
        Me.MT_COD_USUARIO.Name = "MT_COD_USUARIO"
        Me.MT_COD_USUARIO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_COD_USUARIO.p_IniciarComo = True
        Me.MT_COD_USUARIO.Size = New System.Drawing.Size(168, 24)
        Me.MT_COD_USUARIO.TabIndex = 1
        '
        'MT_NOM_USUARIO
        '
        Me.MT_NOM_USUARIO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_NOM_USUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_NOM_USUARIO.ForeColor = System.Drawing.Color.Black
        Me.MT_NOM_USUARIO.Location = New System.Drawing.Point(142, 22)
        Me.MT_NOM_USUARIO.MaxLength = 20
        Me.MT_NOM_USUARIO.Name = "MT_NOM_USUARIO"
        Me.MT_NOM_USUARIO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_NOM_USUARIO.p_IniciarComo = True
        Me.MT_NOM_USUARIO.Size = New System.Drawing.Size(168, 24)
        Me.MT_NOM_USUARIO.TabIndex = 0
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(417, 212)
        Me.ShapeContainer1.TabIndex = 8
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 23
        Me.LineShape1.X2 = 395
        Me.LineShape1.Y1 = 101
        Me.LineShape1.Y2 = 101
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel7.Controls.Add(Me.BT_GRABAR)
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Controls.Add(Me.Label3)
        Me.Panel7.Controls.Add(Me.Label2)
        Me.Panel7.Controls.Add(Me.PB_3)
        Me.Panel7.Controls.Add(Me.PB_1)
        Me.Panel7.Controls.Add(Me.PB_2)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 255)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(417, 103)
        Me.Panel7.TabIndex = 2
        '
        'BT_GRABAR
        '
        Me.BT_GRABAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GRABAR.Location = New System.Drawing.Point(285, 6)
        Me.BT_GRABAR.Name = "BT_GRABAR"
        Me.BT_GRABAR.Size = New System.Drawing.Size(116, 43)
        Me.BT_GRABAR.TabIndex = 19
        Me.BT_GRABAR.Text = "&Guardar Datos"
        Me.BT_GRABAR.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Sienna
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(201, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 15)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "F3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Sienna
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(109, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 15)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "F2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Sienna
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(17, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 15)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "F1"
        '
        'PB_3
        '
        Me.PB_3.Image = Global._VsagAdm.My.Resources.Resources.DataBorrar
        Me.PB_3.Location = New System.Drawing.Point(215, 6)
        Me.PB_3.Name = "PB_3"
        Me.PB_3.Size = New System.Drawing.Size(50, 43)
        Me.PB_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_3.TabIndex = 22
        Me.PB_3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PB_3, "Eliminar Item")
        '
        'PB_1
        '
        Me.PB_1.ErrorImage = Nothing
        Me.PB_1.Image = Global._VsagAdm.My.Resources.Resources.DataAgregar
        Me.PB_1.Location = New System.Drawing.Point(31, 6)
        Me.PB_1.Name = "PB_1"
        Me.PB_1.Size = New System.Drawing.Size(50, 43)
        Me.PB_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_1.TabIndex = 20
        Me.PB_1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PB_1, "Agregar Nuevo Item")
        '
        'PB_2
        '
        Me.PB_2.Image = Global._VsagAdm.My.Resources.Resources.database_actualizar_1
        Me.PB_2.Location = New System.Drawing.Point(123, 6)
        Me.PB_2.Name = "PB_2"
        Me.PB_2.Size = New System.Drawing.Size(50, 43)
        Me.PB_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_2.TabIndex = 21
        Me.PB_2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PB_2, "Modificar  Item")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 315)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(748, 22)
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
        'FichaUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(754, 343)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(770, 381)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(770, 381)
        Me.Name = "FichaUsuario"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuario"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.MisGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.PB_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents MisGrid1 As MisControles.Controles.MisGrid
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents BT_GRABAR As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PB_3 As System.Windows.Forms.PictureBox
    Friend WithEvents PB_1 As System.Windows.Forms.PictureBox
    Friend WithEvents PB_2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MCB_ESTATUS As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_GRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents MT_CLAV_USUARIO As MisControles.Controles.MisTextos
    Friend WithEvents MT_COD_USUARIO As MisControles.Controles.MisTextos
    Friend WithEvents MT_NOM_USUARIO As MisControles.Controles.MisTextos
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LINK_GRUPO As System.Windows.Forms.LinkLabel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents E_REGISTROS As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
