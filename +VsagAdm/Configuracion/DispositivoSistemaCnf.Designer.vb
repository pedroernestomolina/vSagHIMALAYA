Imports MisControles.Controles

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DispositivoSistemaCnf
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.BT_GUARDAR = New System.Windows.Forms.Button
        Me.BT_PRUEBA = New System.Windows.Forms.Button
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.MCB_FISCAL_PUERTO = New MisControles.Controles.MisComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.MCB_FISCAL_MODELO = New MisControles.Controles.MisComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.MCHB_FISCAL = New MisControles.Controles.MisCheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.MCB_SERIE_NE = New MisControles.Controles.MisComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.MCB_SERIE_ND = New MisControles.Controles.MisComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.MCB_SERIE_NC = New MisControles.Controles.MisComboBox
        Me.MCB_SERIE_FACTURA = New MisControles.Controles.MisComboBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.MCB_VISOR_PUERTO = New MisControles.Controles.MisComboBox
        Me.MCHB_VISOR = New MisControles.Controles.MisCheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.BT_IMPRESORA = New System.Windows.Forms.Button
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.RUTA_IMPRESORA = New System.Windows.Forms.Label
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.BT_LIMPIAR = New System.Windows.Forms.Button
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.BT_IMPRESORA_NOTA = New System.Windows.Forms.Button
        Me.Panel13 = New System.Windows.Forms.Panel
        Me.RUTA_IMPRESORA_NOTA = New System.Windows.Forms.Label
        Me.Panel14 = New System.Windows.Forms.Panel
        Me.BT_LIMPIAR_NOTA = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.PB_IMAGEN = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.MCHB_PREEMPAQ = New MisControles.Controles.MisCheckBox
        Me.MT_PREEMPQ = New MisControles.Controles.MisTextos
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.MisComboBox1 = New MisControles.Controles.MisComboBox
        Me.MisComboBox2 = New MisControles.Controles.MisComboBox
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.PB_IMAGEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(469, 463)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 359.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 38)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 328.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(469, 403)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.BT_GUARDAR)
        Me.Panel4.Controls.Add(Me.BT_PRUEBA)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 331)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(463, 69)
        Me.Panel4.TabIndex = 0
        '
        'BT_GUARDAR
        '
        Me.BT_GUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GUARDAR.Image = Global._VsagAdm.My.Resources.Resources.agt_action_success
        Me.BT_GUARDAR.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.BT_GUARDAR.Location = New System.Drawing.Point(332, 8)
        Me.BT_GUARDAR.Name = "BT_GUARDAR"
        Me.BT_GUARDAR.Size = New System.Drawing.Size(128, 57)
        Me.BT_GUARDAR.TabIndex = 1
        Me.BT_GUARDAR.Text = "&Guardar"
        Me.BT_GUARDAR.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.ToolTip1.SetToolTip(Me.BT_GUARDAR, "Guardar Los Cambios Efectuados")
        Me.BT_GUARDAR.UseVisualStyleBackColor = True
        '
        'BT_PRUEBA
        '
        Me.BT_PRUEBA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PRUEBA.Location = New System.Drawing.Point(198, 8)
        Me.BT_PRUEBA.Name = "BT_PRUEBA"
        Me.BT_PRUEBA.Size = New System.Drawing.Size(128, 57)
        Me.BT_PRUEBA.TabIndex = 0
        Me.BT_PRUEBA.Text = "&Prueba / Test"
        Me.ToolTip1.SetToolTip(Me.BT_PRUEBA, "Permite Hacer Un Test Al Dispositivo A Configurar")
        Me.BT_PRUEBA.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Navy
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(463, 3)
        Me.Panel5.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.TabControl1)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(113, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(353, 322)
        Me.Panel6.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(5, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(348, 322)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.MCB_FISCAL_PUERTO)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.MCB_FISCAL_MODELO)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.MCHB_FISCAL)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(340, 294)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Impresora Fiscal"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'MCB_FISCAL_PUERTO
        '
        Me.MCB_FISCAL_PUERTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_FISCAL_PUERTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_FISCAL_PUERTO.FormattingEnabled = True
        Me.MCB_FISCAL_PUERTO.Location = New System.Drawing.Point(115, 76)
        Me.MCB_FISCAL_PUERTO.Name = "MCB_FISCAL_PUERTO"
        Me.MCB_FISCAL_PUERTO.Size = New System.Drawing.Size(113, 26)
        Me.MCB_FISCAL_PUERTO.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Gainsboro
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(334, 33)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "IMPRESORA FISCAL:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MCB_FISCAL_MODELO
        '
        Me.MCB_FISCAL_MODELO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_FISCAL_MODELO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_FISCAL_MODELO.FormattingEnabled = True
        Me.MCB_FISCAL_MODELO.Location = New System.Drawing.Point(115, 108)
        Me.MCB_FISCAL_MODELO.Name = "MCB_FISCAL_MODELO"
        Me.MCB_FISCAL_MODELO.Size = New System.Drawing.Size(167, 26)
        Me.MCB_FISCAL_MODELO.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(50, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 18)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Modelo:"
        '
        'MCHB_FISCAL
        '
        Me.MCHB_FISCAL.AutoSize = True
        Me.MCHB_FISCAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_FISCAL.Location = New System.Drawing.Point(23, 53)
        Me.MCHB_FISCAL.Name = "MCHB_FISCAL"
        Me.MCHB_FISCAL.Size = New System.Drawing.Size(137, 22)
        Me.MCHB_FISCAL.TabIndex = 0
        Me.MCHB_FISCAL.Text = "Activar Opcion"
        Me.MCHB_FISCAL.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(50, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 18)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Puerto:"
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Label4)
        Me.TabPage7.Controls.Add(Me.MCB_SERIE_NE)
        Me.TabPage7.Controls.Add(Me.Label3)
        Me.TabPage7.Controls.Add(Me.MCB_SERIE_ND)
        Me.TabPage7.Controls.Add(Me.Label23)
        Me.TabPage7.Controls.Add(Me.Label22)
        Me.TabPage7.Controls.Add(Me.Label21)
        Me.TabPage7.Controls.Add(Me.MCB_SERIE_NC)
        Me.TabPage7.Controls.Add(Me.MCB_SERIE_FACTURA)
        Me.TabPage7.Location = New System.Drawing.Point(4, 24)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(340, 294)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Series A Usar"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 37)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Para Notas De Entrega:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MCB_SERIE_NE
        '
        Me.MCB_SERIE_NE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_SERIE_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_SERIE_NE.FormattingEnabled = True
        Me.MCB_SERIE_NE.Location = New System.Drawing.Point(155, 198)
        Me.MCB_SERIE_NE.Name = "MCB_SERIE_NE"
        Me.MCB_SERIE_NE.Size = New System.Drawing.Size(161, 26)
        Me.MCB_SERIE_NE.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 37)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Para Notas De Debito:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MCB_SERIE_ND
        '
        Me.MCB_SERIE_ND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_SERIE_ND.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_SERIE_ND.FormattingEnabled = True
        Me.MCB_SERIE_ND.Location = New System.Drawing.Point(155, 149)
        Me.MCB_SERIE_ND.Name = "MCB_SERIE_ND"
        Me.MCB_SERIE_ND.Size = New System.Drawing.Size(161, 26)
        Me.MCB_SERIE_ND.TabIndex = 32
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Gainsboro
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(334, 33)
        Me.Label23.TabIndex = 31
        Me.Label23.Text = "SERIES A USAR:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(14, 95)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(135, 37)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "Para Notas De Credito:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(17, 64)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(132, 18)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Para Facturas:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MCB_SERIE_NC
        '
        Me.MCB_SERIE_NC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_SERIE_NC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_SERIE_NC.FormattingEnabled = True
        Me.MCB_SERIE_NC.Location = New System.Drawing.Point(155, 106)
        Me.MCB_SERIE_NC.Name = "MCB_SERIE_NC"
        Me.MCB_SERIE_NC.Size = New System.Drawing.Size(161, 26)
        Me.MCB_SERIE_NC.TabIndex = 1
        '
        'MCB_SERIE_FACTURA
        '
        Me.MCB_SERIE_FACTURA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_SERIE_FACTURA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_SERIE_FACTURA.FormattingEnabled = True
        Me.MCB_SERIE_FACTURA.Location = New System.Drawing.Point(155, 61)
        Me.MCB_SERIE_FACTURA.Name = "MCB_SERIE_FACTURA"
        Me.MCB_SERIE_FACTURA.Size = New System.Drawing.Size(161, 26)
        Me.MCB_SERIE_FACTURA.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.MCB_VISOR_PUERTO)
        Me.TabPage3.Controls.Add(Me.MCHB_VISOR)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(340, 294)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Visor Precio"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'MCB_VISOR_PUERTO
        '
        Me.MCB_VISOR_PUERTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_VISOR_PUERTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_VISOR_PUERTO.FormattingEnabled = True
        Me.MCB_VISOR_PUERTO.Location = New System.Drawing.Point(125, 83)
        Me.MCB_VISOR_PUERTO.Name = "MCB_VISOR_PUERTO"
        Me.MCB_VISOR_PUERTO.Size = New System.Drawing.Size(113, 26)
        Me.MCB_VISOR_PUERTO.TabIndex = 0
        '
        'MCHB_VISOR
        '
        Me.MCHB_VISOR.AutoSize = True
        Me.MCHB_VISOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_VISOR.Location = New System.Drawing.Point(38, 57)
        Me.MCHB_VISOR.Name = "MCHB_VISOR"
        Me.MCHB_VISOR.Size = New System.Drawing.Size(137, 22)
        Me.MCHB_VISOR.TabIndex = 8
        Me.MCHB_VISOR.Text = "Activar Opcion"
        Me.MCHB_VISOR.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(60, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 18)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Puerto:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gainsboro
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(334, 33)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "VISOR DE PRECIO:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(340, 294)
        Me.TabPage1.TabIndex = 7
        Me.TabPage1.Text = "Definir Imprersora  Matriz"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.70588!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.29412!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel9, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel10, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel11, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel12, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel13, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel14, 1, 4)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 33)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(340, 261)
        Me.TableLayoutPanel2.TabIndex = 11
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.BT_IMPRESORA)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 22)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel9.Size = New System.Drawing.Size(111, 62)
        Me.Panel9.TabIndex = 0
        '
        'BT_IMPRESORA
        '
        Me.BT_IMPRESORA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BT_IMPRESORA.Location = New System.Drawing.Point(2, 2)
        Me.BT_IMPRESORA.Name = "BT_IMPRESORA"
        Me.BT_IMPRESORA.Size = New System.Drawing.Size(107, 58)
        Me.BT_IMPRESORA.TabIndex = 0
        Me.BT_IMPRESORA.Text = "Seleccione Impresora  Factura"
        Me.BT_IMPRESORA.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.RUTA_IMPRESORA)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(120, 22)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel10.Size = New System.Drawing.Size(217, 62)
        Me.Panel10.TabIndex = 1
        '
        'RUTA_IMPRESORA
        '
        Me.RUTA_IMPRESORA.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RUTA_IMPRESORA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RUTA_IMPRESORA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RUTA_IMPRESORA.Location = New System.Drawing.Point(2, 2)
        Me.RUTA_IMPRESORA.Name = "RUTA_IMPRESORA"
        Me.RUTA_IMPRESORA.Size = New System.Drawing.Size(213, 58)
        Me.RUTA_IMPRESORA.TabIndex = 0
        Me.RUTA_IMPRESORA.Text = "Label5"
        Me.RUTA_IMPRESORA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.BT_LIMPIAR)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(120, 90)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel11.Size = New System.Drawing.Size(217, 37)
        Me.Panel11.TabIndex = 2
        '
        'BT_LIMPIAR
        '
        Me.BT_LIMPIAR.Dock = System.Windows.Forms.DockStyle.Right
        Me.BT_LIMPIAR.Location = New System.Drawing.Point(140, 2)
        Me.BT_LIMPIAR.Name = "BT_LIMPIAR"
        Me.BT_LIMPIAR.Size = New System.Drawing.Size(75, 33)
        Me.BT_LIMPIAR.TabIndex = 0
        Me.BT_LIMPIAR.Text = "Limpiar"
        Me.BT_LIMPIAR.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.BT_IMPRESORA_NOTA)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(3, 133)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel12.Size = New System.Drawing.Size(111, 64)
        Me.Panel12.TabIndex = 3
        '
        'BT_IMPRESORA_NOTA
        '
        Me.BT_IMPRESORA_NOTA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BT_IMPRESORA_NOTA.Location = New System.Drawing.Point(2, 2)
        Me.BT_IMPRESORA_NOTA.Name = "BT_IMPRESORA_NOTA"
        Me.BT_IMPRESORA_NOTA.Size = New System.Drawing.Size(107, 60)
        Me.BT_IMPRESORA_NOTA.TabIndex = 0
        Me.BT_IMPRESORA_NOTA.Text = "Seleccione Impresora  Otras"
        Me.BT_IMPRESORA_NOTA.UseVisualStyleBackColor = True
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel13.Controls.Add(Me.RUTA_IMPRESORA_NOTA)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(120, 133)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel13.Size = New System.Drawing.Size(217, 64)
        Me.Panel13.TabIndex = 4
        '
        'RUTA_IMPRESORA_NOTA
        '
        Me.RUTA_IMPRESORA_NOTA.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RUTA_IMPRESORA_NOTA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RUTA_IMPRESORA_NOTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RUTA_IMPRESORA_NOTA.Location = New System.Drawing.Point(2, 2)
        Me.RUTA_IMPRESORA_NOTA.Name = "RUTA_IMPRESORA_NOTA"
        Me.RUTA_IMPRESORA_NOTA.Size = New System.Drawing.Size(213, 60)
        Me.RUTA_IMPRESORA_NOTA.TabIndex = 0
        Me.RUTA_IMPRESORA_NOTA.Text = "Label5"
        Me.RUTA_IMPRESORA_NOTA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.BT_LIMPIAR_NOTA)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(120, 203)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel14.Size = New System.Drawing.Size(217, 37)
        Me.Panel14.TabIndex = 5
        '
        'BT_LIMPIAR_NOTA
        '
        Me.BT_LIMPIAR_NOTA.Dock = System.Windows.Forms.DockStyle.Right
        Me.BT_LIMPIAR_NOTA.Location = New System.Drawing.Point(140, 2)
        Me.BT_LIMPIAR_NOTA.Name = "BT_LIMPIAR_NOTA"
        Me.BT_LIMPIAR_NOTA.Size = New System.Drawing.Size(75, 33)
        Me.BT_LIMPIAR_NOTA.TabIndex = 0
        Me.BT_LIMPIAR_NOTA.Text = "Limpiar"
        Me.BT_LIMPIAR_NOTA.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Gainsboro
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(340, 33)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "DEFINIR IMPRESORA MATRIZ:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Black
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(5, 322)
        Me.Panel7.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Controls.Add(Me.PB_IMAGEN)
        Me.Panel8.Controls.Add(Me.PictureBox1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel8.Size = New System.Drawing.Size(104, 322)
        Me.Panel8.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 200)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Configurar"
        '
        'PB_IMAGEN
        '
        Me.PB_IMAGEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB_IMAGEN.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PB_IMAGEN.Image = Global._VsagAdm.My.Resources.Resources.Balanza_1
        Me.PB_IMAGEN.Location = New System.Drawing.Point(5, 222)
        Me.PB_IMAGEN.Name = "PB_IMAGEN"
        Me.PB_IMAGEN.Size = New System.Drawing.Size(94, 95)
        Me.PB_IMAGEN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_IMAGEN.TabIndex = 1
        Me.PB_IMAGEN.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global._VsagAdm.My.Resources.Resources.Configuracion_1
        Me.PictureBox1.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(94, 111)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel2.Size = New System.Drawing.Size(469, 38)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(465, 28)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Menu De Configuracion"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Maroon
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(2, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(465, 3)
        Me.Panel3.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 441)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(469, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(222, 17)
        Me.ToolStripStatusLabel1.Text = "Presione La Tecla <Esc> Para Salir"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 18)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Formato:"
        '
        'MCHB_PREEMPAQ
        '
        Me.MCHB_PREEMPAQ.AutoSize = True
        Me.MCHB_PREEMPAQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_PREEMPAQ.Location = New System.Drawing.Point(27, 46)
        Me.MCHB_PREEMPAQ.Name = "MCHB_PREEMPAQ"
        Me.MCHB_PREEMPAQ.Size = New System.Drawing.Size(137, 22)
        Me.MCHB_PREEMPAQ.TabIndex = 0
        Me.MCHB_PREEMPAQ.Text = "Activar Opcion"
        Me.MCHB_PREEMPAQ.UseVisualStyleBackColor = True
        '
        'MT_PREEMPQ
        '
        Me.MT_PREEMPQ.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_PREEMPQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_PREEMPQ.ForeColor = System.Drawing.Color.Black
        Me.MT_PREEMPQ.Location = New System.Drawing.Point(59, 92)
        Me.MT_PREEMPQ.MaxLength = 20
        Me.MT_PREEMPQ.Name = "MT_PREEMPQ"
        Me.MT_PREEMPQ.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_PREEMPQ.p_IniciarComo = True
        Me.MT_PREEMPQ.Size = New System.Drawing.Size(239, 29)
        Me.MT_PREEMPQ.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(128, 147)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(146, 128)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "0..9 :> Digitos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "I      :> Codigo Item" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "W    :> Peso" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "P     :> Precio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "C     :> D" & _
            "igito De Control" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "S     :> Seccion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "D     :> Departamento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "V     :> Vendedor"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(56, 124)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Leyenda:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 24)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "PRE - EMPAQUE:"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Gainsboro
        Me.Label43.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(3, 3)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(334, 33)
        Me.Label43.TabIndex = 31
        Me.Label43.Text = "SERIES A USAR:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(14, 95)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(135, 37)
        Me.Label44.TabIndex = 3
        Me.Label44.Text = "Para Notas De Credito:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(17, 64)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(132, 18)
        Me.Label45.TabIndex = 2
        Me.Label45.Text = "Para Facturas:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MisComboBox1
        '
        Me.MisComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MisComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MisComboBox1.FormattingEnabled = True
        Me.MisComboBox1.Location = New System.Drawing.Point(155, 106)
        Me.MisComboBox1.Name = "MisComboBox1"
        Me.MisComboBox1.Size = New System.Drawing.Size(161, 26)
        Me.MisComboBox1.TabIndex = 1
        '
        'MisComboBox2
        '
        Me.MisComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MisComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MisComboBox2.FormattingEnabled = True
        Me.MisComboBox2.Location = New System.Drawing.Point(155, 61)
        Me.MisComboBox2.Name = "MisComboBox2"
        Me.MisComboBox2.Size = New System.Drawing.Size(161, 26)
        Me.MisComboBox2.TabIndex = 0
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'DispositivoSistemaCnf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(473, 467)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DispositivoSistemaCnf"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurar Dispositivos"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.PB_IMAGEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BT_GUARDAR As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PB_IMAGEN As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MCB_VISOR_PUERTO As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_VISOR As MisControles.Controles.MisCheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MCB_FISCAL_PUERTO As MisControles.Controles.MisComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents MCB_FISCAL_MODELO As MisControles.Controles.MisComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MCHB_FISCAL As MisControles.Controles.MisCheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents MCB_SERIE_NC As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_SERIE_FACTURA As MisControles.Controles.MisComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MCHB_PREEMPAQ As MisCheckBox
    Friend WithEvents MT_PREEMPQ As MisTextos
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents MisComboBox1 As MisControles.Controles.MisComboBox
    Friend WithEvents MisComboBox2 As MisControles.Controles.MisComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MCB_SERIE_NE As MisControles.Controles.MisComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MCB_SERIE_ND As MisControles.Controles.MisComboBox
    Friend WithEvents BT_PRUEBA As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents BT_IMPRESORA As System.Windows.Forms.Button
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents RUTA_IMPRESORA As System.Windows.Forms.Label
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents BT_LIMPIAR As System.Windows.Forms.Button
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents BT_IMPRESORA_NOTA As System.Windows.Forms.Button
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents RUTA_IMPRESORA_NOTA As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents BT_LIMPIAR_NOTA As System.Windows.Forms.Button
End Class
