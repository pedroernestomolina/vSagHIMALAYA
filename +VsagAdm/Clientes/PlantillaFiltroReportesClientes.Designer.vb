﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlantillaFiltroReportesClientes
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
        Me.MCHB_ESTATUS = New MisControles.Controles.MisCheckBox
        Me.MCB_ESTATUS = New MisControles.Controles.MisComboBox
        Me.MCHB_CREDITO = New MisControles.Controles.MisCheckBox
        Me.MCB_CREDITO = New MisControles.Controles.MisComboBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.MF_HASTA = New MisControles.Controles.MisFechas
        Me.MF_DESDE = New MisControles.Controles.MisFechas
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.MCHB_FECHA = New MisControles.Controles.MisCheckBox
        Me.MCHB_COBRADOR = New MisControles.Controles.MisCheckBox
        Me.MCHB_VENDEDOR = New MisControles.Controles.MisCheckBox
        Me.MCB_COBRADOR = New MisControles.Controles.MisComboBox
        Me.MCB_VENDEDOR = New MisControles.Controles.MisComboBox
        Me.MCHB_ZONA = New MisControles.Controles.MisCheckBox
        Me.MCHB_ESTADO = New MisControles.Controles.MisCheckBox
        Me.MCHB_GRUPO = New MisControles.Controles.MisCheckBox
        Me.MCB_ZONA = New MisControles.Controles.MisComboBox
        Me.MCB_ESTADO = New MisControles.Controles.MisComboBox
        Me.MCB_GRUPO = New MisControles.Controles.MisComboBox
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
        Me.Panel1.Size = New System.Drawing.Size(572, 379)
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(570, 355)
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
        Me.Panel2.Size = New System.Drawing.Size(564, 31)
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 40)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.03448!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.96552!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(153, 312)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.BT_1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 224)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4)
        Me.Panel3.Size = New System.Drawing.Size(147, 85)
        Me.Panel3.TabIndex = 0
        '
        'BT_1
        '
        Me.BT_1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BT_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_1.Location = New System.Drawing.Point(4, 41)
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
        Me.Panel4.Size = New System.Drawing.Size(147, 215)
        Me.Panel4.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global._VsagAdm.My.Resources.Resources.IMPRESORA
        Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(143, 211)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.MCHB_ESTATUS)
        Me.Panel5.Controls.Add(Me.MCB_ESTATUS)
        Me.Panel5.Controls.Add(Me.MCHB_CREDITO)
        Me.Panel5.Controls.Add(Me.MCB_CREDITO)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.MF_HASTA)
        Me.Panel5.Controls.Add(Me.MF_DESDE)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.MCHB_FECHA)
        Me.Panel5.Controls.Add(Me.MCHB_COBRADOR)
        Me.Panel5.Controls.Add(Me.MCHB_VENDEDOR)
        Me.Panel5.Controls.Add(Me.MCB_COBRADOR)
        Me.Panel5.Controls.Add(Me.MCB_VENDEDOR)
        Me.Panel5.Controls.Add(Me.MCHB_ZONA)
        Me.Panel5.Controls.Add(Me.MCHB_ESTADO)
        Me.Panel5.Controls.Add(Me.MCHB_GRUPO)
        Me.Panel5.Controls.Add(Me.MCB_ZONA)
        Me.Panel5.Controls.Add(Me.MCB_ESTADO)
        Me.Panel5.Controls.Add(Me.MCB_GRUPO)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(162, 40)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel5.Size = New System.Drawing.Size(405, 312)
        Me.Panel5.TabIndex = 1
        '
        'MCHB_ESTATUS
        '
        Me.MCHB_ESTATUS.AutoSize = True
        Me.MCHB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ESTATUS.Location = New System.Drawing.Point(23, 195)
        Me.MCHB_ESTATUS.Name = "MCHB_ESTATUS"
        Me.MCHB_ESTATUS.Size = New System.Drawing.Size(95, 20)
        Me.MCHB_ESTATUS.TabIndex = 12
        Me.MCHB_ESTATUS.Text = "Por Estatus"
        Me.MCHB_ESTATUS.UseVisualStyleBackColor = True
        '
        'MCB_ESTATUS
        '
        Me.MCB_ESTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTATUS.FormattingEnabled = True
        Me.MCB_ESTATUS.Location = New System.Drawing.Point(142, 193)
        Me.MCB_ESTATUS.Name = "MCB_ESTATUS"
        Me.MCB_ESTATUS.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ESTATUS.TabIndex = 13
        '
        'MCHB_CREDITO
        '
        Me.MCHB_CREDITO.AutoSize = True
        Me.MCHB_CREDITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_CREDITO.Location = New System.Drawing.Point(23, 169)
        Me.MCHB_CREDITO.Name = "MCHB_CREDITO"
        Me.MCHB_CREDITO.Size = New System.Drawing.Size(94, 20)
        Me.MCHB_CREDITO.TabIndex = 10
        Me.MCHB_CREDITO.Text = "Por Crédito"
        Me.MCHB_CREDITO.UseVisualStyleBackColor = True
        '
        'MCB_CREDITO
        '
        Me.MCB_CREDITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_CREDITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_CREDITO.FormattingEnabled = True
        Me.MCB_CREDITO.Location = New System.Drawing.Point(142, 167)
        Me.MCB_CREDITO.Name = "MCB_CREDITO"
        Me.MCB_CREDITO.Size = New System.Drawing.Size(249, 24)
        Me.MCB_CREDITO.TabIndex = 11
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
        Me.MF_HASTA.Location = New System.Drawing.Point(172, 275)
        Me.MF_HASTA.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_HASTA.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_HASTA.Name = "MF_HASTA"
        Me.MF_HASTA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.p_IniciarComo = True
        Me.MF_HASTA.ShowCheckBox = True
        Me.MF_HASTA.Size = New System.Drawing.Size(205, 22)
        Me.MF_HASTA.TabIndex = 16
        Me.MF_HASTA.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MF_DESDE
        '
        Me.MF_DESDE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_DESDE.ForeColor = System.Drawing.Color.Black
        Me.MF_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_DESDE.Location = New System.Drawing.Point(172, 251)
        Me.MF_DESDE.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_DESDE.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_DESDE.Name = "MF_DESDE"
        Me.MF_DESDE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.p_IniciarComo = True
        Me.MF_DESDE.ShowCheckBox = True
        Me.MF_DESDE.Size = New System.Drawing.Size(205, 22)
        Me.MF_DESDE.TabIndex = 15
        Me.MF_DESDE.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(128, 278)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(125, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Desde:"
        '
        'MCHB_FECHA
        '
        Me.MCHB_FECHA.AutoSize = True
        Me.MCHB_FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_FECHA.Location = New System.Drawing.Point(23, 229)
        Me.MCHB_FECHA.Name = "MCHB_FECHA"
        Me.MCHB_FECHA.Size = New System.Drawing.Size(164, 20)
        Me.MCHB_FECHA.TabIndex = 14
        Me.MCHB_FECHA.Text = "Por Fecha De Registro"
        Me.MCHB_FECHA.UseVisualStyleBackColor = True
        '
        'MCHB_COBRADOR
        '
        Me.MCHB_COBRADOR.AutoSize = True
        Me.MCHB_COBRADOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_COBRADOR.Location = New System.Drawing.Point(23, 143)
        Me.MCHB_COBRADOR.Name = "MCHB_COBRADOR"
        Me.MCHB_COBRADOR.Size = New System.Drawing.Size(108, 20)
        Me.MCHB_COBRADOR.TabIndex = 8
        Me.MCHB_COBRADOR.Text = "Por Cobrador"
        Me.MCHB_COBRADOR.UseVisualStyleBackColor = True
        '
        'MCHB_VENDEDOR
        '
        Me.MCHB_VENDEDOR.AutoSize = True
        Me.MCHB_VENDEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_VENDEDOR.Location = New System.Drawing.Point(23, 117)
        Me.MCHB_VENDEDOR.Name = "MCHB_VENDEDOR"
        Me.MCHB_VENDEDOR.Size = New System.Drawing.Size(111, 20)
        Me.MCHB_VENDEDOR.TabIndex = 6
        Me.MCHB_VENDEDOR.Text = "Por Vendedor"
        Me.MCHB_VENDEDOR.UseVisualStyleBackColor = True
        '
        'MCB_COBRADOR
        '
        Me.MCB_COBRADOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_COBRADOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_COBRADOR.FormattingEnabled = True
        Me.MCB_COBRADOR.Location = New System.Drawing.Point(142, 141)
        Me.MCB_COBRADOR.Name = "MCB_COBRADOR"
        Me.MCB_COBRADOR.Size = New System.Drawing.Size(249, 24)
        Me.MCB_COBRADOR.TabIndex = 9
        '
        'MCB_VENDEDOR
        '
        Me.MCB_VENDEDOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_VENDEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_VENDEDOR.FormattingEnabled = True
        Me.MCB_VENDEDOR.Location = New System.Drawing.Point(142, 115)
        Me.MCB_VENDEDOR.Name = "MCB_VENDEDOR"
        Me.MCB_VENDEDOR.Size = New System.Drawing.Size(249, 24)
        Me.MCB_VENDEDOR.TabIndex = 7
        '
        'MCHB_ZONA
        '
        Me.MCHB_ZONA.AutoSize = True
        Me.MCHB_ZONA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ZONA.Location = New System.Drawing.Point(23, 91)
        Me.MCHB_ZONA.Name = "MCHB_ZONA"
        Me.MCHB_ZONA.Size = New System.Drawing.Size(82, 20)
        Me.MCHB_ZONA.TabIndex = 4
        Me.MCHB_ZONA.Text = "Por Zona"
        Me.MCHB_ZONA.UseVisualStyleBackColor = True
        '
        'MCHB_ESTADO
        '
        Me.MCHB_ESTADO.AutoSize = True
        Me.MCHB_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ESTADO.Location = New System.Drawing.Point(23, 65)
        Me.MCHB_ESTADO.Name = "MCHB_ESTADO"
        Me.MCHB_ESTADO.Size = New System.Drawing.Size(94, 20)
        Me.MCHB_ESTADO.TabIndex = 2
        Me.MCHB_ESTADO.Text = "Por Estado"
        Me.MCHB_ESTADO.UseVisualStyleBackColor = True
        '
        'MCHB_GRUPO
        '
        Me.MCHB_GRUPO.AutoSize = True
        Me.MCHB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_GRUPO.Location = New System.Drawing.Point(23, 37)
        Me.MCHB_GRUPO.Name = "MCHB_GRUPO"
        Me.MCHB_GRUPO.Size = New System.Drawing.Size(95, 20)
        Me.MCHB_GRUPO.TabIndex = 0
        Me.MCHB_GRUPO.Text = "Por Grupos"
        Me.MCHB_GRUPO.UseVisualStyleBackColor = True
        '
        'MCB_ZONA
        '
        Me.MCB_ZONA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ZONA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ZONA.FormattingEnabled = True
        Me.MCB_ZONA.Location = New System.Drawing.Point(142, 89)
        Me.MCB_ZONA.Name = "MCB_ZONA"
        Me.MCB_ZONA.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ZONA.TabIndex = 5
        '
        'MCB_ESTADO
        '
        Me.MCB_ESTADO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTADO.FormattingEnabled = True
        Me.MCB_ESTADO.Location = New System.Drawing.Point(142, 63)
        Me.MCB_ESTADO.Name = "MCB_ESTADO"
        Me.MCB_ESTADO.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ESTADO.TabIndex = 3
        '
        'MCB_GRUPO
        '
        Me.MCB_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_GRUPO.FormattingEnabled = True
        Me.MCB_GRUPO.Location = New System.Drawing.Point(142, 37)
        Me.MCB_GRUPO.Name = "MCB_GRUPO"
        Me.MCB_GRUPO.Size = New System.Drawing.Size(249, 24)
        Me.MCB_GRUPO.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 355)
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
        'PlantillaFiltroReportesClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(576, 383)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(592, 421)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(592, 421)
        Me.Name = "PlantillaFiltroReportesClientes"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes Clientes"
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
    Friend WithEvents MCHB_ZONA As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_ESTADO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_GRUPO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_ZONA As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ESTADO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_GRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_COBRADOR As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_VENDEDOR As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_COBRADOR As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_VENDEDOR As MisControles.Controles.MisComboBox
    Friend WithEvents MF_HASTA As MisControles.Controles.MisFechas
    Friend WithEvents MF_DESDE As MisControles.Controles.MisFechas
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MCHB_FECHA As MisControles.Controles.MisCheckBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MCHB_CREDITO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_CREDITO As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_ESTATUS As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_ESTATUS As MisControles.Controles.MisComboBox
End Class
