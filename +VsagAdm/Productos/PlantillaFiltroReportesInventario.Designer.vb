<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlantillaFiltroReportesInventario
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
        Me.LB_1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.BT_1 = New System.Windows.Forms.Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.MCHB_SIN_MOVIMIENTO = New MisControles.Controles.MisCheckBox
        Me.MCHB_CONCEPTO = New MisControles.Controles.MisCheckBox
        Me.MCB_CONCEPTO = New MisControles.Controles.MisComboBox
        Me.MCHB_NIVEL = New MisControles.Controles.MisCheckBox
        Me.MCB_NIVEL_STOCK = New MisControles.Controles.MisComboBox
        Me.MCHB_MARCA = New MisControles.Controles.MisCheckBox
        Me.MCB_MARCA = New MisControles.Controles.MisComboBox
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.MCB_ORDEN = New MisControles.Controles.MisComboBox
        Me.MCHB_ESTATUS = New MisControles.Controles.MisCheckBox
        Me.MCB_ESTATUS = New MisControles.Controles.MisComboBox
        Me.MCHB_PRECIO = New MisControles.Controles.MisCheckBox
        Me.MCB_PRECIO = New MisControles.Controles.MisComboBox
        Me.MCHB_PLU = New MisControles.Controles.MisCheckBox
        Me.MCB_PLU = New MisControles.Controles.MisComboBox
        Me.MCHB_PROVEEDOR = New MisControles.Controles.MisCheckBox
        Me.MCB_PROVEEDOR = New MisControles.Controles.MisComboBox
        Me.MCHB_DEPOSITO = New MisControles.Controles.MisCheckBox
        Me.MCB_DEPOSITO = New MisControles.Controles.MisComboBox
        Me.MCHB_SUBGRUPO = New MisControles.Controles.MisCheckBox
        Me.MCB_SUBGRUPO = New MisControles.Controles.MisComboBox
        Me.MCHB_GRUPO = New MisControles.Controles.MisCheckBox
        Me.MCB_GRUPO = New MisControles.Controles.MisComboBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.MF_HASTA = New MisControles.Controles.MisFechas
        Me.MF_DESDE = New MisControles.Controles.MisFechas
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.MCHB_FECHA = New MisControles.Controles.MisCheckBox
        Me.MCHB_DEPARTAMENTO = New MisControles.Controles.MisCheckBox
        Me.MCB_DEPARTAMENTO = New MisControles.Controles.MisComboBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(590, 572)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.89474!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.10526!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.57402!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.42598!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(588, 548)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.LB_1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(582, 51)
        Me.Panel2.TabIndex = 0
        '
        'LB_1
        '
        Me.LB_1.AutoSize = True
        Me.LB_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_1.Location = New System.Drawing.Point(3, 3)
        Me.LB_1.Name = "LB_1"
        Me.LB_1.Size = New System.Drawing.Size(214, 20)
        Me.LB_1.TabIndex = 0
        Me.LB_1.Text = "NOMBRE DEL REPORTE"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 60)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.87324!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.12676!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(158, 485)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.BT_1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 385)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4)
        Me.Panel3.Size = New System.Drawing.Size(152, 97)
        Me.Panel3.TabIndex = 0
        '
        'BT_1
        '
        Me.BT_1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BT_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_1.Location = New System.Drawing.Point(4, 53)
        Me.BT_1.Name = "BT_1"
        Me.BT_1.Size = New System.Drawing.Size(144, 40)
        Me.BT_1.TabIndex = 0
        Me.BT_1.Text = "&Procesar"
        Me.BT_1.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel4.Size = New System.Drawing.Size(152, 376)
        Me.Panel4.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global._VsagAdm.My.Resources.Resources.IMPRESORA
        Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(148, 372)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.MCHB_SIN_MOVIMIENTO)
        Me.Panel5.Controls.Add(Me.MCHB_CONCEPTO)
        Me.Panel5.Controls.Add(Me.MCB_CONCEPTO)
        Me.Panel5.Controls.Add(Me.MCHB_NIVEL)
        Me.Panel5.Controls.Add(Me.MCB_NIVEL_STOCK)
        Me.Panel5.Controls.Add(Me.MCHB_MARCA)
        Me.Panel5.Controls.Add(Me.MCB_MARCA)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.MCHB_ESTATUS)
        Me.Panel5.Controls.Add(Me.MCB_ESTATUS)
        Me.Panel5.Controls.Add(Me.MCHB_PRECIO)
        Me.Panel5.Controls.Add(Me.MCB_PRECIO)
        Me.Panel5.Controls.Add(Me.MCHB_PLU)
        Me.Panel5.Controls.Add(Me.MCB_PLU)
        Me.Panel5.Controls.Add(Me.MCHB_PROVEEDOR)
        Me.Panel5.Controls.Add(Me.MCB_PROVEEDOR)
        Me.Panel5.Controls.Add(Me.MCHB_DEPOSITO)
        Me.Panel5.Controls.Add(Me.MCB_DEPOSITO)
        Me.Panel5.Controls.Add(Me.MCHB_SUBGRUPO)
        Me.Panel5.Controls.Add(Me.MCB_SUBGRUPO)
        Me.Panel5.Controls.Add(Me.MCHB_GRUPO)
        Me.Panel5.Controls.Add(Me.MCB_GRUPO)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.MF_HASTA)
        Me.Panel5.Controls.Add(Me.MF_DESDE)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.MCHB_FECHA)
        Me.Panel5.Controls.Add(Me.MCHB_DEPARTAMENTO)
        Me.Panel5.Controls.Add(Me.MCB_DEPARTAMENTO)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(167, 60)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel5.Size = New System.Drawing.Size(418, 485)
        Me.Panel5.TabIndex = 0
        '
        'MCHB_SIN_MOVIMIENTO
        '
        Me.MCHB_SIN_MOVIMIENTO.AutoSize = True
        Me.MCHB_SIN_MOVIMIENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_SIN_MOVIMIENTO.Location = New System.Drawing.Point(278, 312)
        Me.MCHB_SIN_MOVIMIENTO.Name = "MCHB_SIN_MOVIMIENTO"
        Me.MCHB_SIN_MOVIMIENTO.Size = New System.Drawing.Size(118, 20)
        Me.MCHB_SIN_MOVIMIENTO.TabIndex = 22
        Me.MCHB_SIN_MOVIMIENTO.Text = "Sin Movimiento"
        Me.MCHB_SIN_MOVIMIENTO.UseVisualStyleBackColor = True
        '
        'MCHB_CONCEPTO
        '
        Me.MCHB_CONCEPTO.AutoSize = True
        Me.MCHB_CONCEPTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_CONCEPTO.Location = New System.Drawing.Point(13, 284)
        Me.MCHB_CONCEPTO.Name = "MCHB_CONCEPTO"
        Me.MCHB_CONCEPTO.Size = New System.Drawing.Size(109, 20)
        Me.MCHB_CONCEPTO.TabIndex = 20
        Me.MCHB_CONCEPTO.Text = "Por Concepto"
        Me.MCHB_CONCEPTO.UseVisualStyleBackColor = True
        '
        'MCB_CONCEPTO
        '
        Me.MCB_CONCEPTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_CONCEPTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_CONCEPTO.FormattingEnabled = True
        Me.MCB_CONCEPTO.Location = New System.Drawing.Point(153, 284)
        Me.MCB_CONCEPTO.Name = "MCB_CONCEPTO"
        Me.MCB_CONCEPTO.Size = New System.Drawing.Size(243, 24)
        Me.MCB_CONCEPTO.TabIndex = 21
        '
        'MCHB_NIVEL
        '
        Me.MCHB_NIVEL.AutoSize = True
        Me.MCHB_NIVEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_NIVEL.Location = New System.Drawing.Point(13, 258)
        Me.MCHB_NIVEL.Name = "MCHB_NIVEL"
        Me.MCHB_NIVEL.Size = New System.Drawing.Size(119, 20)
        Me.MCHB_NIVEL.TabIndex = 18
        Me.MCHB_NIVEL.Text = "Por Nivel Stock"
        Me.MCHB_NIVEL.UseVisualStyleBackColor = True
        '
        'MCB_NIVEL_STOCK
        '
        Me.MCB_NIVEL_STOCK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_NIVEL_STOCK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_NIVEL_STOCK.FormattingEnabled = True
        Me.MCB_NIVEL_STOCK.Location = New System.Drawing.Point(153, 258)
        Me.MCB_NIVEL_STOCK.Name = "MCB_NIVEL_STOCK"
        Me.MCB_NIVEL_STOCK.Size = New System.Drawing.Size(243, 24)
        Me.MCB_NIVEL_STOCK.TabIndex = 19
        '
        'MCHB_MARCA
        '
        Me.MCHB_MARCA.AutoSize = True
        Me.MCHB_MARCA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_MARCA.Location = New System.Drawing.Point(13, 232)
        Me.MCHB_MARCA.Name = "MCHB_MARCA"
        Me.MCHB_MARCA.Size = New System.Drawing.Size(89, 20)
        Me.MCHB_MARCA.TabIndex = 16
        Me.MCHB_MARCA.Text = "Por Marca"
        Me.MCHB_MARCA.UseVisualStyleBackColor = True
        '
        'MCB_MARCA
        '
        Me.MCB_MARCA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_MARCA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_MARCA.FormattingEnabled = True
        Me.MCB_MARCA.Location = New System.Drawing.Point(153, 232)
        Me.MCB_MARCA.Name = "MCB_MARCA"
        Me.MCB_MARCA.Size = New System.Drawing.Size(243, 24)
        Me.MCB_MARCA.TabIndex = 17
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.LightGray
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Controls.Add(Me.MCB_ORDEN)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(2, 439)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(412, 42)
        Me.Panel7.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ordenado Por:"
        '
        'MCB_ORDEN
        '
        Me.MCB_ORDEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ORDEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ORDEN.FormattingEnabled = True
        Me.MCB_ORDEN.Location = New System.Drawing.Point(151, 12)
        Me.MCB_ORDEN.Name = "MCB_ORDEN"
        Me.MCB_ORDEN.Size = New System.Drawing.Size(243, 24)
        Me.MCB_ORDEN.TabIndex = 0
        '
        'MCHB_ESTATUS
        '
        Me.MCHB_ESTATUS.AutoSize = True
        Me.MCHB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ESTATUS.Location = New System.Drawing.Point(13, 208)
        Me.MCHB_ESTATUS.Name = "MCHB_ESTATUS"
        Me.MCHB_ESTATUS.Size = New System.Drawing.Size(95, 20)
        Me.MCHB_ESTATUS.TabIndex = 14
        Me.MCHB_ESTATUS.Text = "Por Estatus"
        Me.MCHB_ESTATUS.UseVisualStyleBackColor = True
        '
        'MCB_ESTATUS
        '
        Me.MCB_ESTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTATUS.FormattingEnabled = True
        Me.MCB_ESTATUS.Location = New System.Drawing.Point(153, 206)
        Me.MCB_ESTATUS.Name = "MCB_ESTATUS"
        Me.MCB_ESTATUS.Size = New System.Drawing.Size(243, 24)
        Me.MCB_ESTATUS.TabIndex = 15
        '
        'MCHB_PRECIO
        '
        Me.MCHB_PRECIO.AutoSize = True
        Me.MCHB_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_PRECIO.Location = New System.Drawing.Point(13, 183)
        Me.MCHB_PRECIO.Name = "MCHB_PRECIO"
        Me.MCHB_PRECIO.Size = New System.Drawing.Size(90, 20)
        Me.MCHB_PRECIO.TabIndex = 12
        Me.MCHB_PRECIO.Text = "Por Precio"
        Me.MCHB_PRECIO.UseVisualStyleBackColor = True
        '
        'MCB_PRECIO
        '
        Me.MCB_PRECIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_PRECIO.FormattingEnabled = True
        Me.MCB_PRECIO.Location = New System.Drawing.Point(153, 181)
        Me.MCB_PRECIO.Name = "MCB_PRECIO"
        Me.MCB_PRECIO.Size = New System.Drawing.Size(243, 24)
        Me.MCB_PRECIO.TabIndex = 13
        '
        'MCHB_PLU
        '
        Me.MCHB_PLU.AutoSize = True
        Me.MCHB_PLU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_PLU.Location = New System.Drawing.Point(13, 156)
        Me.MCHB_PLU.Name = "MCHB_PLU"
        Me.MCHB_PLU.Size = New System.Drawing.Size(128, 20)
        Me.MCHB_PLU.TabIndex = 10
        Me.MCHB_PLU.Text = "Por Uso Balanza"
        Me.MCHB_PLU.UseVisualStyleBackColor = True
        '
        'MCB_PLU
        '
        Me.MCB_PLU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_PLU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_PLU.FormattingEnabled = True
        Me.MCB_PLU.Location = New System.Drawing.Point(153, 156)
        Me.MCB_PLU.Name = "MCB_PLU"
        Me.MCB_PLU.Size = New System.Drawing.Size(243, 24)
        Me.MCB_PLU.TabIndex = 11
        '
        'MCHB_PROVEEDOR
        '
        Me.MCHB_PROVEEDOR.AutoSize = True
        Me.MCHB_PROVEEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_PROVEEDOR.Location = New System.Drawing.Point(13, 133)
        Me.MCHB_PROVEEDOR.Name = "MCHB_PROVEEDOR"
        Me.MCHB_PROVEEDOR.Size = New System.Drawing.Size(130, 20)
        Me.MCHB_PROVEEDOR.TabIndex = 8
        Me.MCHB_PROVEEDOR.Text = "Por Proveedores"
        Me.MCHB_PROVEEDOR.UseVisualStyleBackColor = True
        '
        'MCB_PROVEEDOR
        '
        Me.MCB_PROVEEDOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_PROVEEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_PROVEEDOR.FormattingEnabled = True
        Me.MCB_PROVEEDOR.Location = New System.Drawing.Point(153, 131)
        Me.MCB_PROVEEDOR.Name = "MCB_PROVEEDOR"
        Me.MCB_PROVEEDOR.Size = New System.Drawing.Size(243, 24)
        Me.MCB_PROVEEDOR.TabIndex = 9
        '
        'MCHB_DEPOSITO
        '
        Me.MCHB_DEPOSITO.AutoSize = True
        Me.MCHB_DEPOSITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_DEPOSITO.Location = New System.Drawing.Point(13, 108)
        Me.MCHB_DEPOSITO.Name = "MCHB_DEPOSITO"
        Me.MCHB_DEPOSITO.Size = New System.Drawing.Size(106, 20)
        Me.MCHB_DEPOSITO.TabIndex = 6
        Me.MCHB_DEPOSITO.Text = "Por Deposito"
        Me.MCHB_DEPOSITO.UseVisualStyleBackColor = True
        '
        'MCB_DEPOSITO
        '
        Me.MCB_DEPOSITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_DEPOSITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_DEPOSITO.FormattingEnabled = True
        Me.MCB_DEPOSITO.Location = New System.Drawing.Point(153, 106)
        Me.MCB_DEPOSITO.Name = "MCB_DEPOSITO"
        Me.MCB_DEPOSITO.Size = New System.Drawing.Size(243, 24)
        Me.MCB_DEPOSITO.TabIndex = 7
        '
        'MCHB_SUBGRUPO
        '
        Me.MCHB_SUBGRUPO.AutoSize = True
        Me.MCHB_SUBGRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_SUBGRUPO.Location = New System.Drawing.Point(13, 81)
        Me.MCHB_SUBGRUPO.Name = "MCHB_SUBGRUPO"
        Me.MCHB_SUBGRUPO.Size = New System.Drawing.Size(115, 20)
        Me.MCHB_SUBGRUPO.TabIndex = 4
        Me.MCHB_SUBGRUPO.Text = "Por Sub Grupo"
        Me.MCHB_SUBGRUPO.UseVisualStyleBackColor = True
        '
        'MCB_SUBGRUPO
        '
        Me.MCB_SUBGRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_SUBGRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_SUBGRUPO.FormattingEnabled = True
        Me.MCB_SUBGRUPO.Location = New System.Drawing.Point(153, 81)
        Me.MCB_SUBGRUPO.Name = "MCB_SUBGRUPO"
        Me.MCB_SUBGRUPO.Size = New System.Drawing.Size(243, 24)
        Me.MCB_SUBGRUPO.TabIndex = 5
        '
        'MCHB_GRUPO
        '
        Me.MCHB_GRUPO.AutoSize = True
        Me.MCHB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_GRUPO.Location = New System.Drawing.Point(13, 58)
        Me.MCHB_GRUPO.Name = "MCHB_GRUPO"
        Me.MCHB_GRUPO.Size = New System.Drawing.Size(88, 20)
        Me.MCHB_GRUPO.TabIndex = 2
        Me.MCHB_GRUPO.Text = "Por Grupo"
        Me.MCHB_GRUPO.UseVisualStyleBackColor = True
        '
        'MCB_GRUPO
        '
        Me.MCB_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_GRUPO.FormattingEnabled = True
        Me.MCB_GRUPO.Location = New System.Drawing.Point(153, 56)
        Me.MCB_GRUPO.Name = "MCB_GRUPO"
        Me.MCB_GRUPO.Size = New System.Drawing.Size(243, 24)
        Me.MCB_GRUPO.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkRed
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(2, 2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(412, 21)
        Me.Panel6.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Seleccione Los Filtros A Usar:"
        '
        'MF_HASTA
        '
        Me.MF_HASTA.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_HASTA.ForeColor = System.Drawing.Color.Black
        Me.MF_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_HASTA.Location = New System.Drawing.Point(191, 370)
        Me.MF_HASTA.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_HASTA.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_HASTA.Name = "MF_HASTA"
        Me.MF_HASTA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.p_IniciarComo = True
        Me.MF_HASTA.ShowCheckBox = True
        Me.MF_HASTA.Size = New System.Drawing.Size(205, 22)
        Me.MF_HASTA.TabIndex = 25
        Me.MF_HASTA.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MF_DESDE
        '
        Me.MF_DESDE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_DESDE.ForeColor = System.Drawing.Color.Black
        Me.MF_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_DESDE.Location = New System.Drawing.Point(191, 346)
        Me.MF_DESDE.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_DESDE.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_DESDE.Name = "MF_DESDE"
        Me.MF_DESDE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.p_IniciarComo = True
        Me.MF_DESDE.ShowCheckBox = True
        Me.MF_DESDE.Size = New System.Drawing.Size(205, 22)
        Me.MF_DESDE.TabIndex = 24
        Me.MF_DESDE.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(147, 373)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(144, 351)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Desde:"
        '
        'MCHB_FECHA
        '
        Me.MCHB_FECHA.AutoSize = True
        Me.MCHB_FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_FECHA.Location = New System.Drawing.Point(13, 324)
        Me.MCHB_FECHA.Name = "MCHB_FECHA"
        Me.MCHB_FECHA.Size = New System.Drawing.Size(164, 20)
        Me.MCHB_FECHA.TabIndex = 23
        Me.MCHB_FECHA.Text = "Por Fecha De Registro"
        Me.MCHB_FECHA.UseVisualStyleBackColor = True
        '
        'MCHB_DEPARTAMENTO
        '
        Me.MCHB_DEPARTAMENTO.AutoSize = True
        Me.MCHB_DEPARTAMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_DEPARTAMENTO.Location = New System.Drawing.Point(13, 31)
        Me.MCHB_DEPARTAMENTO.Name = "MCHB_DEPARTAMENTO"
        Me.MCHB_DEPARTAMENTO.Size = New System.Drawing.Size(137, 20)
        Me.MCHB_DEPARTAMENTO.TabIndex = 0
        Me.MCHB_DEPARTAMENTO.Text = "Por Departamento"
        Me.MCHB_DEPARTAMENTO.UseVisualStyleBackColor = True
        '
        'MCB_DEPARTAMENTO
        '
        Me.MCB_DEPARTAMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_DEPARTAMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_DEPARTAMENTO.FormattingEnabled = True
        Me.MCB_DEPARTAMENTO.Location = New System.Drawing.Point(153, 31)
        Me.MCB_DEPARTAMENTO.Name = "MCB_DEPARTAMENTO"
        Me.MCB_DEPARTAMENTO.Size = New System.Drawing.Size(243, 24)
        Me.MCB_DEPARTAMENTO.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 548)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(588, 22)
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
        'PlantillaFiltroReportesInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(594, 576)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(610, 570)
        Me.Name = "PlantillaFiltroReportesInventario"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes Inventario"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LB_1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BT_1 As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents MCHB_DEPARTAMENTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_DEPARTAMENTO As MisControles.Controles.MisComboBox
    Friend WithEvents MF_HASTA As MisControles.Controles.MisFechas
    Friend WithEvents MF_DESDE As MisControles.Controles.MisFechas
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MCHB_FECHA As MisControles.Controles.MisCheckBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MCHB_GRUPO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_GRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_PRECIO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_PRECIO As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_PLU As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_PLU As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_PROVEEDOR As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_PROVEEDOR As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_DEPOSITO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_DEPOSITO As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_SUBGRUPO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_SUBGRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_ESTATUS As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_ESTATUS As MisControles.Controles.MisComboBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents MCB_ORDEN As MisControles.Controles.MisComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MCHB_NIVEL As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_NIVEL_STOCK As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_MARCA As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_MARCA As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_CONCEPTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_CONCEPTO As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_SIN_MOVIMIENTO As MisControles.Controles.MisCheckBox
End Class
