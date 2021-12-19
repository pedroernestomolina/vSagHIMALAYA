Imports MisControles.Controles

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configurar
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
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.MCHB_BALANZA = New MisControles.Controles.MisCheckBox
        Me.RB_BAL_MANUAL = New System.Windows.Forms.RadioButton
        Me.P_BAL = New System.Windows.Forms.Panel
        Me.MCB_BAL_PUERTO = New MisControles.Controles.MisComboBox
        Me.MCB_BAL_MODELO = New MisControles.Controles.MisComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.RB_BAL_ELECT = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.Label18 = New System.Windows.Forms.Label
        Me.MCH_PRE_EMPAQUE = New MisControles.Controles.MisCheckBox
        Me.MT_PRE_EMPAQUE = New MisControles.Controles.MisTextos
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel13 = New System.Windows.Forms.Panel
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Panel14 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.MCH_TICKET = New MisControles.Controles.MisCheckBox
        Me.MT_TICKET = New MisControles.Controles.MisTextos
        Me.Label19 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.MCB_VISOR_PUERTO = New MisControles.Controles.MisComboBox
        Me.MCHB_VISOR = New MisControles.Controles.MisCheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.MCB_FISCAL_PUERTO = New MisControles.Controles.MisComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.MCB_FISCAL_MODELO = New MisControles.Controles.MisComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.MCHB_FISCAL = New MisControles.Controles.MisCheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.E_SERIAL = New System.Windows.Forms.Label
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.BT_SERIAL = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.MCB_SERIE_NC = New MisControles.Controles.MisComboBox
        Me.MCB_SERIE_FACTURA = New MisControles.Controles.MisComboBox
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel16 = New System.Windows.Forms.Panel
        Me.MCH_VENTA_DEPARTAMENTO = New MisControles.Controles.MisCheckBox
        Me.Panel15 = New System.Windows.Forms.Panel
        Me.MCH_VENTA_MAYOR = New MisControles.Controles.MisCheckBox
        Me.Panel17 = New System.Windows.Forms.Panel
        Me.MCH_VENTA_MONITOR = New MisControles.Controles.MisCheckBox
        Me.Label46 = New System.Windows.Forms.Label
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
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.P_BAL.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.PB_IMAGEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(5, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(348, 322)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.MCHB_BALANZA)
        Me.TabPage1.Controls.Add(Me.RB_BAL_MANUAL)
        Me.TabPage1.Controls.Add(Me.P_BAL)
        Me.TabPage1.Controls.Add(Me.RB_BAL_ELECT)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(340, 294)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Balanza Solo Peso"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'MCHB_BALANZA
        '
        Me.MCHB_BALANZA.AutoSize = True
        Me.MCHB_BALANZA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_BALANZA.Location = New System.Drawing.Point(29, 46)
        Me.MCHB_BALANZA.Name = "MCHB_BALANZA"
        Me.MCHB_BALANZA.Size = New System.Drawing.Size(137, 22)
        Me.MCHB_BALANZA.TabIndex = 0
        Me.MCHB_BALANZA.Text = "Activar Opcion"
        Me.MCHB_BALANZA.UseVisualStyleBackColor = True
        '
        'RB_BAL_MANUAL
        '
        Me.RB_BAL_MANUAL.AutoSize = True
        Me.RB_BAL_MANUAL.Enabled = False
        Me.RB_BAL_MANUAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_BAL_MANUAL.Location = New System.Drawing.Point(49, 76)
        Me.RB_BAL_MANUAL.Name = "RB_BAL_MANUAL"
        Me.RB_BAL_MANUAL.Size = New System.Drawing.Size(113, 24)
        Me.RB_BAL_MANUAL.TabIndex = 1
        Me.RB_BAL_MANUAL.TabStop = True
        Me.RB_BAL_MANUAL.Text = "Tipo Manual"
        Me.RB_BAL_MANUAL.UseVisualStyleBackColor = True
        '
        'P_BAL
        '
        Me.P_BAL.Controls.Add(Me.MCB_BAL_PUERTO)
        Me.P_BAL.Controls.Add(Me.MCB_BAL_MODELO)
        Me.P_BAL.Controls.Add(Me.Label5)
        Me.P_BAL.Controls.Add(Me.Label4)
        Me.P_BAL.Location = New System.Drawing.Point(68, 136)
        Me.P_BAL.Name = "P_BAL"
        Me.P_BAL.Size = New System.Drawing.Size(256, 65)
        Me.P_BAL.TabIndex = 12
        '
        'MCB_BAL_PUERTO
        '
        Me.MCB_BAL_PUERTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_BAL_PUERTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_BAL_PUERTO.FormattingEnabled = True
        Me.MCB_BAL_PUERTO.Location = New System.Drawing.Point(79, 4)
        Me.MCB_BAL_PUERTO.Name = "MCB_BAL_PUERTO"
        Me.MCB_BAL_PUERTO.Size = New System.Drawing.Size(167, 26)
        Me.MCB_BAL_PUERTO.TabIndex = 0
        '
        'MCB_BAL_MODELO
        '
        Me.MCB_BAL_MODELO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_BAL_MODELO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MCB_BAL_MODELO.FormattingEnabled = True
        Me.MCB_BAL_MODELO.Location = New System.Drawing.Point(79, 33)
        Me.MCB_BAL_MODELO.Name = "MCB_BAL_MODELO"
        Me.MCB_BAL_MODELO.Size = New System.Drawing.Size(167, 26)
        Me.MCB_BAL_MODELO.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 18)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Modelo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Puerto:"
        '
        'RB_BAL_ELECT
        '
        Me.RB_BAL_ELECT.AutoSize = True
        Me.RB_BAL_ELECT.Enabled = False
        Me.RB_BAL_ELECT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_BAL_ELECT.Location = New System.Drawing.Point(49, 106)
        Me.RB_BAL_ELECT.Name = "RB_BAL_ELECT"
        Me.RB_BAL_ELECT.Size = New System.Drawing.Size(140, 24)
        Me.RB_BAL_ELECT.TabIndex = 2
        Me.RB_BAL_ELECT.TabStop = True
        Me.RB_BAL_ELECT.Text = "Tipo Electronica"
        Me.RB_BAL_ELECT.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(334, 33)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "BALANZA:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(340, 294)
        Me.TabPage2.TabIndex = 7
        Me.TabPage2.Text = "Balanza Pre-Empaque"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel12, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel11, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 36)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.86274!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.13726!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(334, 255)
        Me.TableLayoutPanel3.TabIndex = 37
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TableLayoutPanel3.SetColumnSpan(Me.Panel12, 2)
        Me.Panel12.Controls.Add(Me.FlowLayoutPanel2)
        Me.Panel12.Controls.Add(Me.Label17)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(3, 96)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel12.Size = New System.Drawing.Size(328, 156)
        Me.Panel12.TabIndex = 1
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label14)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label35)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label37)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label38)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label39)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label40)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label41)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label42)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(114, 18)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(212, 136)
        Me.FlowLayoutPanel2.TabIndex = 39
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(156, 16)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "0..9 = Digitos"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(5, 18)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(156, 16)
        Me.Label35.TabIndex = 1
        Me.Label35.Text = "I = Codigo Item"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(5, 34)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(156, 16)
        Me.Label37.TabIndex = 2
        Me.Label37.Text = "W = Peso"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(5, 50)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(156, 16)
        Me.Label38.TabIndex = 3
        Me.Label38.Text = "P = Precio"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(5, 66)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(183, 16)
        Me.Label39.TabIndex = 4
        Me.Label39.Text = "C = Digito De Control"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(5, 82)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(156, 16)
        Me.Label40.TabIndex = 5
        Me.Label40.Text = "S = Seccion"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(5, 98)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(156, 16)
        Me.Label41.TabIndex = 6
        Me.Label41.Text = "D = Departamento"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(5, 114)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(108, 16)
        Me.Label42.TabIndex = 7
        Me.Label42.Text = "V = Vendedor"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(2, 2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 16)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Leyenda:"
        '
        'Panel11
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.Panel11, 2)
        Me.Panel11.Controls.Add(Me.PictureBox2)
        Me.Panel11.Controls.Add(Me.Label18)
        Me.Panel11.Controls.Add(Me.MCH_PRE_EMPAQUE)
        Me.Panel11.Controls.Add(Me.MT_PRE_EMPAQUE)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(3, 3)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel11.Size = New System.Drawing.Size(328, 87)
        Me.Panel11.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(33, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 18)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "Formato:"
        '
        'MCH_PRE_EMPAQUE
        '
        Me.MCH_PRE_EMPAQUE.AutoSize = True
        Me.MCH_PRE_EMPAQUE.Dock = System.Windows.Forms.DockStyle.Top
        Me.MCH_PRE_EMPAQUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCH_PRE_EMPAQUE.Location = New System.Drawing.Point(2, 2)
        Me.MCH_PRE_EMPAQUE.Name = "MCH_PRE_EMPAQUE"
        Me.MCH_PRE_EMPAQUE.Size = New System.Drawing.Size(324, 20)
        Me.MCH_PRE_EMPAQUE.TabIndex = 1
        Me.MCH_PRE_EMPAQUE.Text = "Activar Opcion"
        Me.MCH_PRE_EMPAQUE.UseVisualStyleBackColor = True
        '
        'MT_PRE_EMPAQUE
        '
        Me.MT_PRE_EMPAQUE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_PRE_EMPAQUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_PRE_EMPAQUE.ForeColor = System.Drawing.Color.Black
        Me.MT_PRE_EMPAQUE.Location = New System.Drawing.Point(36, 50)
        Me.MT_PRE_EMPAQUE.MaxLength = 20
        Me.MT_PRE_EMPAQUE.Name = "MT_PRE_EMPAQUE"
        Me.MT_PRE_EMPAQUE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_PRE_EMPAQUE.p_IniciarComo = True
        Me.MT_PRE_EMPAQUE.Size = New System.Drawing.Size(287, 29)
        Me.MT_PRE_EMPAQUE.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Gainsboro
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(334, 33)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "PRE - EMPAQUE:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.TableLayoutPanel4)
        Me.TabPage5.Controls.Add(Me.Label19)
        Me.TabPage5.Location = New System.Drawing.Point(4, 24)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(340, 294)
        Me.TabPage5.TabIndex = 8
        Me.TabPage5.Text = "Balanza De Tickets"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel13, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel14, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 36)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.86274!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.13726!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(334, 255)
        Me.TableLayoutPanel4.TabIndex = 38
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TableLayoutPanel4.SetColumnSpan(Me.Panel13, 2)
        Me.Panel13.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel13.Controls.Add(Me.Label25)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(3, 96)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel13.Size = New System.Drawing.Size(328, 156)
        Me.Panel13.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Label24)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label27)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label28)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label29)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label30)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label31)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label32)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label33)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label34)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label36)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(8, 18)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(318, 136)
        Me.FlowLayoutPanel1.TabIndex = 38
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(5, 2)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(156, 16)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "0..9 = Digitos"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(5, 18)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(156, 16)
        Me.Label27.TabIndex = 1
        Me.Label27.Text = "I = Codigo Item"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(5, 34)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(156, 16)
        Me.Label28.TabIndex = 2
        Me.Label28.Text = "W = Peso"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(5, 50)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(156, 16)
        Me.Label29.TabIndex = 3
        Me.Label29.Text = "P = Precio"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(5, 66)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(178, 16)
        Me.Label30.TabIndex = 4
        Me.Label30.Text = "C = Digito De Control"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(5, 82)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(156, 16)
        Me.Label31.TabIndex = 5
        Me.Label31.Text = "S = Seccion"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(5, 98)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(156, 16)
        Me.Label32.TabIndex = 6
        Me.Label32.Text = "D = Departamento"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(5, 114)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(107, 16)
        Me.Label33.TabIndex = 7
        Me.Label33.Text = "V = Vendedor"
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(189, 2)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(94, 16)
        Me.Label34.TabIndex = 8
        Me.Label34.Text = "T = Ticket"
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(189, 18)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(94, 16)
        Me.Label36.TabIndex = 10
        Me.Label36.Text = "M = TOTAL"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(2, 2)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 16)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "Leyenda:"
        '
        'Panel14
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.Panel14, 2)
        Me.Panel14.Controls.Add(Me.PictureBox3)
        Me.Panel14.Controls.Add(Me.Label26)
        Me.Panel14.Controls.Add(Me.MCH_TICKET)
        Me.Panel14.Controls.Add(Me.MT_TICKET)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(3, 3)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel14.Size = New System.Drawing.Size(328, 87)
        Me.Panel14.TabIndex = 0
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(33, 25)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 18)
        Me.Label26.TabIndex = 29
        Me.Label26.Text = "Formato:"
        '
        'MCH_TICKET
        '
        Me.MCH_TICKET.AutoSize = True
        Me.MCH_TICKET.Dock = System.Windows.Forms.DockStyle.Top
        Me.MCH_TICKET.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCH_TICKET.Location = New System.Drawing.Point(2, 2)
        Me.MCH_TICKET.Name = "MCH_TICKET"
        Me.MCH_TICKET.Size = New System.Drawing.Size(324, 20)
        Me.MCH_TICKET.TabIndex = 1
        Me.MCH_TICKET.Text = "Activar Opcion"
        Me.MCH_TICKET.UseVisualStyleBackColor = True
        '
        'MT_TICKET
        '
        Me.MT_TICKET.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_TICKET.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_TICKET.ForeColor = System.Drawing.Color.Black
        Me.MT_TICKET.Location = New System.Drawing.Point(36, 50)
        Me.MT_TICKET.MaxLength = 20
        Me.MT_TICKET.Name = "MT_TICKET"
        Me.MT_TICKET.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_TICKET.p_IniciarComo = True
        Me.MT_TICKET.Size = New System.Drawing.Size(287, 29)
        Me.MT_TICKET.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Gainsboro
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(334, 33)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "BALANZA DE TICKETS"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage6.Controls.Add(Me.Label20)
        Me.TabPage6.Location = New System.Drawing.Point(4, 24)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(340, 294)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Asignar Serial Fiscal"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.17647!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.82353!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel9, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel10, 1, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 36)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(334, 255)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'Panel9
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel9, 2)
        Me.Panel9.Controls.Add(Me.E_SERIAL)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 110)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel9.Size = New System.Drawing.Size(328, 50)
        Me.Panel9.TabIndex = 0
        '
        'E_SERIAL
        '
        Me.E_SERIAL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.E_SERIAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_SERIAL.Location = New System.Drawing.Point(2, 2)
        Me.E_SERIAL.Name = "E_SERIAL"
        Me.E_SERIAL.Size = New System.Drawing.Size(324, 46)
        Me.E_SERIAL.TabIndex = 34
        Me.E_SERIAL.Text = "Label21"
        Me.E_SERIAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.BT_SERIAL)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(107, 166)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel10.Size = New System.Drawing.Size(224, 86)
        Me.Panel10.TabIndex = 1
        '
        'BT_SERIAL
        '
        Me.BT_SERIAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_SERIAL.Location = New System.Drawing.Point(8, 33)
        Me.BT_SERIAL.Name = "BT_SERIAL"
        Me.BT_SERIAL.Size = New System.Drawing.Size(214, 48)
        Me.BT_SERIAL.TabIndex = 33
        Me.BT_SERIAL.Text = "Leer Serial Impresora Fiscal"
        Me.BT_SERIAL.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Gainsboro
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(334, 33)
        Me.Label20.TabIndex = 30
        Me.Label20.Text = "SERIAL IMPRESORA FISCAL:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage7
        '
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
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.TableLayoutPanel5)
        Me.TabPage8.Controls.Add(Me.Label46)
        Me.TabPage8.Location = New System.Drawing.Point(4, 24)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(340, 294)
        Me.TabPage8.TabIndex = 9
        Me.TabPage8.Text = "Control De Ventas"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 334.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Panel16, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel15, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel17, 0, 2)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 36)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 4
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(334, 255)
        Me.TableLayoutPanel5.TabIndex = 33
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.MCH_VENTA_DEPARTAMENTO)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.Location = New System.Drawing.Point(3, 38)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel16.Size = New System.Drawing.Size(328, 29)
        Me.Panel16.TabIndex = 1
        '
        'MCH_VENTA_DEPARTAMENTO
        '
        Me.MCH_VENTA_DEPARTAMENTO.AutoSize = True
        Me.MCH_VENTA_DEPARTAMENTO.Dock = System.Windows.Forms.DockStyle.Top
        Me.MCH_VENTA_DEPARTAMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCH_VENTA_DEPARTAMENTO.Location = New System.Drawing.Point(2, 2)
        Me.MCH_VENTA_DEPARTAMENTO.Name = "MCH_VENTA_DEPARTAMENTO"
        Me.MCH_VENTA_DEPARTAMENTO.Size = New System.Drawing.Size(324, 20)
        Me.MCH_VENTA_DEPARTAMENTO.TabIndex = 2
        Me.MCH_VENTA_DEPARTAMENTO.Text = "Activar Ventas Por Departamento"
        Me.MCH_VENTA_DEPARTAMENTO.UseVisualStyleBackColor = True
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.MCH_VENTA_MAYOR)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel15.Location = New System.Drawing.Point(3, 3)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel15.Size = New System.Drawing.Size(328, 29)
        Me.Panel15.TabIndex = 0
        '
        'MCH_VENTA_MAYOR
        '
        Me.MCH_VENTA_MAYOR.AutoSize = True
        Me.MCH_VENTA_MAYOR.Dock = System.Windows.Forms.DockStyle.Top
        Me.MCH_VENTA_MAYOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCH_VENTA_MAYOR.Location = New System.Drawing.Point(2, 2)
        Me.MCH_VENTA_MAYOR.Name = "MCH_VENTA_MAYOR"
        Me.MCH_VENTA_MAYOR.Size = New System.Drawing.Size(324, 20)
        Me.MCH_VENTA_MAYOR.TabIndex = 2
        Me.MCH_VENTA_MAYOR.Text = "Activar Ventas De Mayor"
        Me.MCH_VENTA_MAYOR.UseVisualStyleBackColor = True
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.MCH_VENTA_MONITOR)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel17.Location = New System.Drawing.Point(3, 73)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel17.Size = New System.Drawing.Size(328, 29)
        Me.Panel17.TabIndex = 2
        '
        'MCH_VENTA_MONITOR
        '
        Me.MCH_VENTA_MONITOR.AutoSize = True
        Me.MCH_VENTA_MONITOR.Dock = System.Windows.Forms.DockStyle.Top
        Me.MCH_VENTA_MONITOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCH_VENTA_MONITOR.Location = New System.Drawing.Point(2, 2)
        Me.MCH_VENTA_MONITOR.Name = "MCH_VENTA_MONITOR"
        Me.MCH_VENTA_MONITOR.Size = New System.Drawing.Size(324, 20)
        Me.MCH_VENTA_MONITOR.TabIndex = 3
        Me.MCH_VENTA_MONITOR.Text = "Activar Monitoreo De Ventas"
        Me.MCH_VENTA_MONITOR.UseVisualStyleBackColor = True
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Gainsboro
        Me.Label46.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(3, 3)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(334, 33)
        Me.Label46.TabIndex = 32
        Me.Label46.Text = "CONTROL DE VENTAS"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global._VsagAdm.My.Resources.Resources.PORDEFECTO
        Me.PictureBox2.Location = New System.Drawing.Point(286, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(37, 28)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 30
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Seleccionar Valor Por Defecto")
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = Global._VsagAdm.My.Resources.Resources.PORDEFECTO
        Me.PictureBox3.Location = New System.Drawing.Point(286, 16)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(37, 28)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 31
        Me.PictureBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "Seleccionar Valor Por Defecto")
        '
        'Configurar
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
        Me.Name = "Configurar"
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
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.P_BAL.ResumeLayout(False)
        Me.P_BAL.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.PB_IMAGEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents BT_PRUEBA As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PB_IMAGEN As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MCB_VISOR_PUERTO As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_VISOR As MisControles.Controles.MisCheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MCHB_BALANZA As MisControles.Controles.MisCheckBox
    Friend WithEvents RB_BAL_MANUAL As System.Windows.Forms.RadioButton
    Friend WithEvents P_BAL As System.Windows.Forms.Panel
    Friend WithEvents MCB_BAL_PUERTO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_BAL_MODELO As MisControles.Controles.MisComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RB_BAL_ELECT As System.Windows.Forms.RadioButton
    Friend WithEvents MCB_FISCAL_PUERTO As MisControles.Controles.MisComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents MCB_FISCAL_MODELO As MisControles.Controles.MisComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MCHB_FISCAL As MisControles.Controles.MisCheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents MCB_SERIE_NC As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_SERIE_FACTURA As MisControles.Controles.MisComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents E_SERIAL As System.Windows.Forms.Label
    Friend WithEvents BT_SERIAL As System.Windows.Forms.Button
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MCHB_PREEMPAQ As MisCheckBox
    Friend WithEvents MT_PREEMPQ As MisTextos
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents MT_PRE_EMPAQUE As MisControles.Controles.MisTextos
    Friend WithEvents MCH_PRE_EMPAQUE As MisControles.Controles.MisCheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents MCH_TICKET As MisControles.Controles.MisCheckBox
    Friend WithEvents MT_TICKET As MisControles.Controles.MisTextos
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents MisComboBox1 As MisControles.Controles.MisComboBox
    Friend WithEvents MisComboBox2 As MisControles.Controles.MisComboBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents MCH_VENTA_DEPARTAMENTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCH_VENTA_MAYOR As MisControles.Controles.MisCheckBox
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents MCH_VENTA_MONITOR As MisControles.Controles.MisCheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
