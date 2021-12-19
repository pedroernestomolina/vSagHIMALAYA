<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Plantilla_AjusteInventario
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.MisGrid1 = New MisControles.Controles.MisGrid
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.E_EMPAQUE = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.E_NIVEL_OPTIMO = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.E_NIVEL_MINIMO = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.E_UBICACION_4 = New System.Windows.Forms.Label
        Me.E_UBICACION_3 = New System.Windows.Forms.Label
        Me.E_UBICACION_2 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.E_UBICACION_1 = New System.Windows.Forms.Label
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
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.BT_GUARDAR = New System.Windows.Forms.Button
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.RB_UNIDAD = New System.Windows.Forms.RadioButton
        Me.RB_COMPRA = New System.Windows.Forms.RadioButton
        Me.L_CONCEPTO = New System.Windows.Forms.LinkLabel
        Me.E_CONCEPTO_CODIGO = New System.Windows.Forms.Label
        Me.E_SALDO = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.MT_DETALLE = New MisControles.Controles.MisTextos
        Me.Label11 = New System.Windows.Forms.Label
        Me.MN_AJUSTE = New MisControles.Controles.MisNumeros
        Me.Label10 = New System.Windows.Forms.Label
        Me.MCB_CONCEPTO = New MisControles.Controles.MisComboBox
        Me.E_DEPOSITO_CODIGO = New System.Windows.Forms.Label
        Me.E_DEPOSITO_NOMBRE = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.MisGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(824, 508)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.91572!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.08428!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 32)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.81416!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.18584!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(822, 452)
        Me.TableLayoutPanel1.TabIndex = 2
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(264, 183)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGray
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(258, 23)
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
        Me.MisGrid1.Location = New System.Drawing.Point(3, 32)
        Me.MisGrid1.MultiSelect = False
        Me.MisGrid1.Name = "MisGrid1"
        Me.MisGrid1.ReadOnly = True
        Me.MisGrid1.RowHeadersVisible = False
        Me.MisGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MisGrid1.Size = New System.Drawing.Size(258, 148)
        Me.MisGrid1.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.E_EMPAQUE)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.E_NIVEL_OPTIMO)
        Me.Panel5.Controls.Add(Me.Label31)
        Me.Panel5.Controls.Add(Me.E_NIVEL_MINIMO)
        Me.Panel5.Controls.Add(Me.Label28)
        Me.Panel5.Controls.Add(Me.E_UBICACION_4)
        Me.Panel5.Controls.Add(Me.E_UBICACION_3)
        Me.Panel5.Controls.Add(Me.E_UBICACION_2)
        Me.Panel5.Controls.Add(Me.Label24)
        Me.Panel5.Controls.Add(Me.E_UBICACION_1)
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
        Me.Panel5.Size = New System.Drawing.Size(546, 183)
        Me.Panel5.TabIndex = 1
        '
        'E_EMPAQUE
        '
        Me.E_EMPAQUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_EMPAQUE.Location = New System.Drawing.Point(51, 67)
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
        Me.Panel7.Size = New System.Drawing.Size(11, 133)
        Me.Panel7.TabIndex = 22
        '
        'E_NIVEL_OPTIMO
        '
        Me.E_NIVEL_OPTIMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_NIVEL_OPTIMO.Location = New System.Drawing.Point(440, 159)
        Me.E_NIVEL_OPTIMO.Name = "E_NIVEL_OPTIMO"
        Me.E_NIVEL_OPTIMO.Size = New System.Drawing.Size(87, 18)
        Me.E_NIVEL_OPTIMO.TabIndex = 21
        Me.E_NIVEL_OPTIMO.Text = "999999.99"
        Me.E_NIVEL_OPTIMO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(337, 159)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(97, 18)
        Me.Label31.TabIndex = 20
        Me.Label31.Text = "Nivel Optimo:"
        '
        'E_NIVEL_MINIMO
        '
        Me.E_NIVEL_MINIMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_NIVEL_MINIMO.Location = New System.Drawing.Point(439, 141)
        Me.E_NIVEL_MINIMO.Name = "E_NIVEL_MINIMO"
        Me.E_NIVEL_MINIMO.Size = New System.Drawing.Size(88, 18)
        Me.E_NIVEL_MINIMO.TabIndex = 19
        Me.E_NIVEL_MINIMO.Text = "999999.99"
        Me.E_NIVEL_MINIMO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(337, 141)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(97, 18)
        Me.Label28.TabIndex = 18
        Me.Label28.Text = "Nivel Minimo:"
        '
        'E_UBICACION_4
        '
        Me.E_UBICACION_4.AutoSize = True
        Me.E_UBICACION_4.BackColor = System.Drawing.Color.Gainsboro
        Me.E_UBICACION_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_UBICACION_4.ForeColor = System.Drawing.Color.Black
        Me.E_UBICACION_4.Location = New System.Drawing.Point(339, 111)
        Me.E_UBICACION_4.Name = "E_UBICACION_4"
        Me.E_UBICACION_4.Size = New System.Drawing.Size(188, 18)
        Me.E_UBICACION_4.TabIndex = 17
        Me.E_UBICACION_4.Text = "12345678901234567890"
        '
        'E_UBICACION_3
        '
        Me.E_UBICACION_3.AutoSize = True
        Me.E_UBICACION_3.BackColor = System.Drawing.Color.Gainsboro
        Me.E_UBICACION_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_UBICACION_3.ForeColor = System.Drawing.Color.Black
        Me.E_UBICACION_3.Location = New System.Drawing.Point(339, 92)
        Me.E_UBICACION_3.Name = "E_UBICACION_3"
        Me.E_UBICACION_3.Size = New System.Drawing.Size(188, 18)
        Me.E_UBICACION_3.TabIndex = 16
        Me.E_UBICACION_3.Text = "12345678901234567890"
        '
        'E_UBICACION_2
        '
        Me.E_UBICACION_2.AutoSize = True
        Me.E_UBICACION_2.BackColor = System.Drawing.Color.Gainsboro
        Me.E_UBICACION_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_UBICACION_2.ForeColor = System.Drawing.Color.Black
        Me.E_UBICACION_2.Location = New System.Drawing.Point(339, 73)
        Me.E_UBICACION_2.Name = "E_UBICACION_2"
        Me.E_UBICACION_2.Size = New System.Drawing.Size(188, 18)
        Me.E_UBICACION_2.TabIndex = 15
        Me.E_UBICACION_2.Text = "12345678901234567890"
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
        'E_UBICACION_1
        '
        Me.E_UBICACION_1.AutoSize = True
        Me.E_UBICACION_1.BackColor = System.Drawing.Color.Gainsboro
        Me.E_UBICACION_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_UBICACION_1.ForeColor = System.Drawing.Color.Black
        Me.E_UBICACION_1.Location = New System.Drawing.Point(339, 54)
        Me.E_UBICACION_1.Name = "E_UBICACION_1"
        Me.E_UBICACION_1.Size = New System.Drawing.Size(188, 18)
        Me.E_UBICACION_1.TabIndex = 13
        Me.E_UBICACION_1.Text = "12345678901234567890"
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
        Me.L_EXISTENCIA_RESERVA.TabIndex = 8
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
        Me.ShapeContainer2.Size = New System.Drawing.Size(540, 177)
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
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.BT_GUARDAR)
        Me.Panel4.Controls.Add(Me.BT_PROCESAR)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 192)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(816, 257)
        Me.Panel4.TabIndex = 2
        '
        'BT_GUARDAR
        '
        Me.BT_GUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GUARDAR.Location = New System.Drawing.Point(660, 174)
        Me.BT_GUARDAR.Name = "BT_GUARDAR"
        Me.BT_GUARDAR.Size = New System.Drawing.Size(147, 62)
        Me.BT_GUARDAR.TabIndex = 2
        Me.BT_GUARDAR.Text = "&Guardar Ajuste"
        Me.ToolTip1.SetToolTip(Me.BT_GUARDAR, "Guardar Cambios Efectuados")
        Me.BT_GUARDAR.UseVisualStyleBackColor = True
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.Location = New System.Drawing.Point(660, 106)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(147, 62)
        Me.BT_PROCESAR.TabIndex = 1
        Me.BT_PROCESAR.Text = "Efectuar / Procesar &Ajuste"
        Me.ToolTip1.SetToolTip(Me.BT_PROCESAR, "Efectuar / Procesar Ajuste")
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.RB_UNIDAD)
        Me.GroupBox1.Controls.Add(Me.RB_COMPRA)
        Me.GroupBox1.Controls.Add(Me.L_CONCEPTO)
        Me.GroupBox1.Controls.Add(Me.E_CONCEPTO_CODIGO)
        Me.GroupBox1.Controls.Add(Me.E_SALDO)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.MT_DETALLE)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.MN_AJUSTE)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.MCB_CONCEPTO)
        Me.GroupBox1.Controls.Add(Me.E_DEPOSITO_CODIGO)
        Me.GroupBox1.Controls.Add(Me.E_DEPOSITO_NOMBRE)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ShapeContainer1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(632, 221)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ajuste A Realizar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 18)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Tipo Empaque A Ajustar: "
        '
        'RB_UNIDAD
        '
        Me.RB_UNIDAD.AutoSize = True
        Me.RB_UNIDAD.Location = New System.Drawing.Point(391, 114)
        Me.RB_UNIDAD.Name = "RB_UNIDAD"
        Me.RB_UNIDAD.Size = New System.Drawing.Size(88, 17)
        Me.RB_UNIDAD.TabIndex = 3
        Me.RB_UNIDAD.TabStop = True
        Me.RB_UNIDAD.Text = "Por Unidad"
        Me.ToolTip1.SetToolTip(Me.RB_UNIDAD, "La Minima Unidad Soprtada Por El Empaque De Compra Actual")
        Me.RB_UNIDAD.UseVisualStyleBackColor = True
        '
        'RB_COMPRA
        '
        Me.RB_COMPRA.AutoSize = True
        Me.RB_COMPRA.Location = New System.Drawing.Point(209, 114)
        Me.RB_COMPRA.Name = "RB_COMPRA"
        Me.RB_COMPRA.Size = New System.Drawing.Size(163, 17)
        Me.RB_COMPRA.TabIndex = 2
        Me.RB_COMPRA.TabStop = True
        Me.RB_COMPRA.Text = "Empaque Compra Actual"
        Me.ToolTip1.SetToolTip(Me.RB_COMPRA, "Contenido Actual Del Empaque")
        Me.RB_COMPRA.UseVisualStyleBackColor = True
        '
        'L_CONCEPTO
        '
        Me.L_CONCEPTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_CONCEPTO.Location = New System.Drawing.Point(12, 61)
        Me.L_CONCEPTO.Name = "L_CONCEPTO"
        Me.L_CONCEPTO.Size = New System.Drawing.Size(181, 45)
        Me.L_CONCEPTO.TabIndex = 0
        Me.L_CONCEPTO.TabStop = True
        Me.L_CONCEPTO.Text = "Codigo y Descripcion Movimiento A Efectuar:"
        Me.L_CONCEPTO.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.L_CONCEPTO, "Control Conceptos De Movimiento De Inventario")
        '
        'E_CONCEPTO_CODIGO
        '
        Me.E_CONCEPTO_CODIGO.AutoSize = True
        Me.E_CONCEPTO_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_CONCEPTO_CODIGO.Location = New System.Drawing.Point(206, 61)
        Me.E_CONCEPTO_CODIGO.Name = "E_CONCEPTO_CODIGO"
        Me.E_CONCEPTO_CODIGO.Size = New System.Drawing.Size(98, 18)
        Me.E_CONCEPTO_CODIGO.TabIndex = 15
        Me.E_CONCEPTO_CODIGO.Text = "1234567890"
        '
        'E_SALDO
        '
        Me.E_SALDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_SALDO.Location = New System.Drawing.Point(474, 141)
        Me.E_SALDO.Name = "E_SALDO"
        Me.E_SALDO.Size = New System.Drawing.Size(94, 20)
        Me.E_SALDO.TabIndex = 5
        Me.E_SALDO.Text = "99999.999"
        Me.E_SALDO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(66, 169)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 18)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Detalle Del Ajuste:"
        '
        'MT_DETALLE
        '
        Me.MT_DETALLE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_DETALLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_DETALLE.ForeColor = System.Drawing.Color.Black
        Me.MT_DETALLE.Location = New System.Drawing.Point(204, 166)
        Me.MT_DETALLE.MaxLength = 20
        Me.MT_DETALLE.Multiline = True
        Me.MT_DETALLE.Name = "MT_DETALLE"
        Me.MT_DETALLE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_DETALLE.p_IniciarComo = True
        Me.MT_DETALLE.Size = New System.Drawing.Size(391, 44)
        Me.MT_DETALLE.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(388, 142)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 18)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Saldo Final:"
        '
        'MN_AJUSTE
        '
        Me.MN_AJUSTE._ConSigno = False
        Me.MN_AJUSTE._Formato = ""
        Me.MN_AJUSTE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_AJUSTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_AJUSTE.ForeColor = System.Drawing.Color.Black
        Me.MN_AJUSTE.Location = New System.Drawing.Point(204, 139)
        Me.MN_AJUSTE.Name = "MN_AJUSTE"
        Me.MN_AJUSTE.Size = New System.Drawing.Size(100, 24)
        Me.MN_AJUSTE.TabIndex = 4
        Me.MN_AJUSTE.Text = "0"
        Me.MN_AJUSTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 142)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(172, 18)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Cantidad A Ajustar( + / -):"
        '
        'MCB_CONCEPTO
        '
        Me.MCB_CONCEPTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_CONCEPTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_CONCEPTO.FormattingEnabled = True
        Me.MCB_CONCEPTO.Location = New System.Drawing.Point(204, 84)
        Me.MCB_CONCEPTO.Name = "MCB_CONCEPTO"
        Me.MCB_CONCEPTO.Size = New System.Drawing.Size(391, 24)
        Me.MCB_CONCEPTO.TabIndex = 1
        '
        'E_DEPOSITO_CODIGO
        '
        Me.E_DEPOSITO_CODIGO.BackColor = System.Drawing.Color.DimGray
        Me.E_DEPOSITO_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_DEPOSITO_CODIGO.ForeColor = System.Drawing.Color.White
        Me.E_DEPOSITO_CODIGO.Location = New System.Drawing.Point(375, 26)
        Me.E_DEPOSITO_CODIGO.Name = "E_DEPOSITO_CODIGO"
        Me.E_DEPOSITO_CODIGO.Size = New System.Drawing.Size(98, 18)
        Me.E_DEPOSITO_CODIGO.TabIndex = 4
        Me.E_DEPOSITO_CODIGO.Text = "1234567890"
        '
        'E_DEPOSITO_NOMBRE
        '
        Me.E_DEPOSITO_NOMBRE.BackColor = System.Drawing.Color.DimGray
        Me.E_DEPOSITO_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_DEPOSITO_NOMBRE.ForeColor = System.Drawing.Color.White
        Me.E_DEPOSITO_NOMBRE.Location = New System.Drawing.Point(102, 26)
        Me.E_DEPOSITO_NOMBRE.Name = "E_DEPOSITO_NOMBRE"
        Me.E_DEPOSITO_NOMBRE.Size = New System.Drawing.Size(188, 18)
        Me.E_DEPOSITO_NOMBRE.TabIndex = 3
        Me.E_DEPOSITO_NOMBRE.Text = "12345678901234567890"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(301, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 18)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = ", Codigo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Deposito:"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 16)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(626, 202)
        Me.ShapeContainer1.TabIndex = 8
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 9
        Me.LineShape1.X2 = 612
        Me.LineShape1.Y1 = 37
        Me.LineShape1.Y2 = 37
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(816, 27)
        Me.Panel6.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(190, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Movimiento A Efectuar"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 484)
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
        Me.Label1.Text = "Ajustar / Modificar Existencia Del Producto !!!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Plantilla_AjusteInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(828, 512)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(844, 550)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(844, 550)
        Me.Name = "Plantilla_AjusteInventario"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Producto"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.MisGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents E_DEPOSITO_CODIGO As System.Windows.Forms.Label
    Friend WithEvents E_DEPOSITO_NOMBRE As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MCB_CONCEPTO As MisControles.Controles.MisComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents MT_DETALLE As MisControles.Controles.MisTextos
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents MN_AJUSTE As MisControles.Controles.MisNumeros
    Friend WithEvents E_SALDO As System.Windows.Forms.Label
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
    Friend WithEvents E_PRODUCTO As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents E_EXISTENCIA_DISPONIBLE As System.Windows.Forms.Label
    Friend WithEvents E_EXISTENCIA_RESERVA As System.Windows.Forms.Label
    Friend WithEvents E_EXISTENCIA_ACTUAL As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents L_EXISTENCIA_RESERVA As System.Windows.Forms.LinkLabel
    Friend WithEvents E_UBICACION_1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents E_UBICACION_4 As System.Windows.Forms.Label
    Friend WithEvents E_UBICACION_3 As System.Windows.Forms.Label
    Friend WithEvents E_UBICACION_2 As System.Windows.Forms.Label
    Friend WithEvents E_NIVEL_MINIMO As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents E_NIVEL_OPTIMO As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents E_CONCEPTO_CODIGO As System.Windows.Forms.Label
    Friend WithEvents BT_GUARDAR As System.Windows.Forms.Button
    Friend WithEvents L_CONCEPTO As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents E_EMPAQUE As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RB_UNIDAD As System.Windows.Forms.RadioButton
    Friend WithEvents RB_COMPRA As System.Windows.Forms.RadioButton
End Class
