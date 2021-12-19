<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlantillaFiltroReporteVentas
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
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.MCB_DETALLADO = New MisControles.Controles.MisComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.MCHB_PRESUPUESTO = New MisControles.Controles.MisCheckBox
        Me.MCHB_NE = New MisControles.Controles.MisCheckBox
        Me.MCHB_PEDIDO = New MisControles.Controles.MisCheckBox
        Me.MCHB_NC = New MisControles.Controles.MisCheckBox
        Me.MCHB_FACTURA = New MisControles.Controles.MisCheckBox
        Me.MCHB_CLIENTE = New MisControles.Controles.MisCheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.MCB_CLIENTE = New MisControles.Controles.MisComboBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.MF_HASTA = New MisControles.Controles.MisFechas
        Me.MF_DESDE = New MisControles.Controles.MisFechas
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.MCHB_FECHA = New MisControles.Controles.MisCheckBox
        Me.MCHB_SERIES = New MisControles.Controles.MisCheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MCB_SERIES = New MisControles.Controles.MisComboBox
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
        Me.Panel1.Size = New System.Drawing.Size(572, 387)
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(570, 363)
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
        Me.Panel2.Size = New System.Drawing.Size(564, 32)
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 41)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.03448!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.96552!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(153, 319)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.BT_1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 229)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4)
        Me.Panel3.Size = New System.Drawing.Size(147, 87)
        Me.Panel3.TabIndex = 0
        '
        'BT_1
        '
        Me.BT_1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BT_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_1.Location = New System.Drawing.Point(4, 43)
        Me.BT_1.Name = "BT_1"
        Me.BT_1.Size = New System.Drawing.Size(139, 40)
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
        Me.Panel4.Size = New System.Drawing.Size(147, 220)
        Me.Panel4.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global._VsagAdm.My.Resources.Resources.IMPRESORA
        Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(143, 216)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.MCHB_PRESUPUESTO)
        Me.Panel5.Controls.Add(Me.MCHB_NE)
        Me.Panel5.Controls.Add(Me.MCHB_PEDIDO)
        Me.Panel5.Controls.Add(Me.MCHB_NC)
        Me.Panel5.Controls.Add(Me.MCHB_FACTURA)
        Me.Panel5.Controls.Add(Me.MCHB_CLIENTE)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.MCB_CLIENTE)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.MF_HASTA)
        Me.Panel5.Controls.Add(Me.MF_DESDE)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.MCHB_FECHA)
        Me.Panel5.Controls.Add(Me.MCHB_SERIES)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.MCB_SERIES)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(162, 41)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel5.Size = New System.Drawing.Size(405, 319)
        Me.Panel5.TabIndex = 2
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.LightGray
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Controls.Add(Me.MCB_DETALLADO)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(2, 271)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(399, 44)
        Me.Panel7.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(49, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 18)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Detallado:"
        '
        'MCB_DETALLADO
        '
        Me.MCB_DETALLADO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_DETALLADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_DETALLADO.FormattingEnabled = True
        Me.MCB_DETALLADO.Location = New System.Drawing.Point(140, 10)
        Me.MCB_DETALLADO.Name = "MCB_DETALLADO"
        Me.MCB_DETALLADO.Size = New System.Drawing.Size(243, 24)
        Me.MCB_DETALLADO.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(139, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 16)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Por Tipo Documento:"
        '
        'MCHB_PRESUPUESTO
        '
        Me.MCHB_PRESUPUESTO.AutoSize = True
        Me.MCHB_PRESUPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_PRESUPUESTO.Location = New System.Drawing.Point(142, 168)
        Me.MCHB_PRESUPUESTO.Name = "MCHB_PRESUPUESTO"
        Me.MCHB_PRESUPUESTO.Size = New System.Drawing.Size(110, 20)
        Me.MCHB_PRESUPUESTO.TabIndex = 8
        Me.MCHB_PRESUPUESTO.Text = "Presupuestos"
        Me.MCHB_PRESUPUESTO.UseVisualStyleBackColor = True
        '
        'MCHB_NE
        '
        Me.MCHB_NE.AutoSize = True
        Me.MCHB_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_NE.Location = New System.Drawing.Point(257, 142)
        Me.MCHB_NE.Name = "MCHB_NE"
        Me.MCHB_NE.Size = New System.Drawing.Size(134, 20)
        Me.MCHB_NE.TabIndex = 7
        Me.MCHB_NE.Text = "Notas De Entrega"
        Me.MCHB_NE.UseVisualStyleBackColor = True
        '
        'MCHB_PEDIDO
        '
        Me.MCHB_PEDIDO.AutoSize = True
        Me.MCHB_PEDIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_PEDIDO.Location = New System.Drawing.Point(142, 142)
        Me.MCHB_PEDIDO.Name = "MCHB_PEDIDO"
        Me.MCHB_PEDIDO.Size = New System.Drawing.Size(78, 20)
        Me.MCHB_PEDIDO.TabIndex = 6
        Me.MCHB_PEDIDO.Text = "Pedidos"
        Me.MCHB_PEDIDO.UseVisualStyleBackColor = True
        '
        'MCHB_NC
        '
        Me.MCHB_NC.AutoSize = True
        Me.MCHB_NC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_NC.Location = New System.Drawing.Point(257, 116)
        Me.MCHB_NC.Name = "MCHB_NC"
        Me.MCHB_NC.Size = New System.Drawing.Size(130, 20)
        Me.MCHB_NC.TabIndex = 5
        Me.MCHB_NC.Text = "Notas De Credito"
        Me.MCHB_NC.UseVisualStyleBackColor = True
        '
        'MCHB_FACTURA
        '
        Me.MCHB_FACTURA.AutoSize = True
        Me.MCHB_FACTURA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_FACTURA.Location = New System.Drawing.Point(142, 116)
        Me.MCHB_FACTURA.Name = "MCHB_FACTURA"
        Me.MCHB_FACTURA.Size = New System.Drawing.Size(79, 20)
        Me.MCHB_FACTURA.TabIndex = 4
        Me.MCHB_FACTURA.Text = "Facturas"
        Me.MCHB_FACTURA.UseVisualStyleBackColor = True
        '
        'MCHB_CLIENTE
        '
        Me.MCHB_CLIENTE.AutoSize = True
        Me.MCHB_CLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_CLIENTE.Location = New System.Drawing.Point(13, 36)
        Me.MCHB_CLIENTE.Name = "MCHB_CLIENTE"
        Me.MCHB_CLIENTE.Size = New System.Drawing.Size(92, 20)
        Me.MCHB_CLIENTE.TabIndex = 0
        Me.MCHB_CLIENTE.Text = "Por Cliente"
        Me.MCHB_CLIENTE.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 43
        '
        'MCB_CLIENTE
        '
        Me.MCB_CLIENTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_CLIENTE.DropDownWidth = 400
        Me.MCB_CLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_CLIENTE.FormattingEnabled = True
        Me.MCB_CLIENTE.Location = New System.Drawing.Point(142, 36)
        Me.MCB_CLIENTE.Name = "MCB_CLIENTE"
        Me.MCB_CLIENTE.Size = New System.Drawing.Size(249, 24)
        Me.MCB_CLIENTE.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkRed
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(2, 2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(399, 21)
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
        Me.MF_HASTA.Location = New System.Drawing.Point(172, 241)
        Me.MF_HASTA.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_HASTA.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_HASTA.Name = "MF_HASTA"
        Me.MF_HASTA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.p_IniciarComo = True
        Me.MF_HASTA.ShowCheckBox = True
        Me.MF_HASTA.Size = New System.Drawing.Size(205, 22)
        Me.MF_HASTA.TabIndex = 11
        Me.MF_HASTA.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MF_DESDE
        '
        Me.MF_DESDE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_DESDE.ForeColor = System.Drawing.Color.Black
        Me.MF_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_DESDE.Location = New System.Drawing.Point(172, 217)
        Me.MF_DESDE.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_DESDE.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_DESDE.Name = "MF_DESDE"
        Me.MF_DESDE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.p_IniciarComo = True
        Me.MF_DESDE.ShowCheckBox = True
        Me.MF_DESDE.Size = New System.Drawing.Size(205, 22)
        Me.MF_DESDE.TabIndex = 10
        Me.MF_DESDE.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(128, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(125, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Desde:"
        '
        'MCHB_FECHA
        '
        Me.MCHB_FECHA.AutoSize = True
        Me.MCHB_FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_FECHA.Location = New System.Drawing.Point(23, 195)
        Me.MCHB_FECHA.Name = "MCHB_FECHA"
        Me.MCHB_FECHA.Size = New System.Drawing.Size(92, 20)
        Me.MCHB_FECHA.TabIndex = 9
        Me.MCHB_FECHA.Text = "Por Fecha "
        Me.MCHB_FECHA.UseVisualStyleBackColor = True
        '
        'MCHB_SERIES
        '
        Me.MCHB_SERIES.AutoSize = True
        Me.MCHB_SERIES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_SERIES.Location = New System.Drawing.Point(13, 62)
        Me.MCHB_SERIES.Name = "MCHB_SERIES"
        Me.MCHB_SERIES.Size = New System.Drawing.Size(122, 20)
        Me.MCHB_SERIES.TabIndex = 2
        Me.MCHB_SERIES.Text = "Por Serie Fiscal"
        Me.MCHB_SERIES.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 0
        '
        'MCB_SERIES
        '
        Me.MCB_SERIES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_SERIES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_SERIES.FormattingEnabled = True
        Me.MCB_SERIES.Location = New System.Drawing.Point(142, 62)
        Me.MCB_SERIES.Name = "MCB_SERIES"
        Me.MCB_SERIES.Size = New System.Drawing.Size(249, 24)
        Me.MCB_SERIES.TabIndex = 3
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 363)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(570, 22)
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
        'PlantillaFiltroReporteVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(576, 391)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(592, 429)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(592, 429)
        Me.Name = "PlantillaFiltroReporteVentas"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes Ventas"
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
    Friend WithEvents MCHB_SERIES As MisControles.Controles.MisCheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MCB_SERIES As MisControles.Controles.MisComboBox
    Friend WithEvents MF_HASTA As MisControles.Controles.MisFechas
    Friend WithEvents MF_DESDE As MisControles.Controles.MisFechas
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MCHB_FECHA As MisControles.Controles.MisCheckBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MCHB_CLIENTE As MisControles.Controles.MisCheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MCB_CLIENTE As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_FACTURA As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_PRESUPUESTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_NE As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_PEDIDO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_NC As MisControles.Controles.MisCheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MCB_DETALLADO As MisControles.Controles.MisComboBox
End Class