<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlantillaFiltroReporteCxP
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
        Me.MCHB_PROVEEDOR = New MisControles.Controles.MisCheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.MCB_PROVEEDOR = New MisControles.Controles.MisComboBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.MF_HASTA = New MisControles.Controles.MisFechas
        Me.MF_DESDE = New MisControles.Controles.MisFechas
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.MCHB_FECHA = New MisControles.Controles.MisCheckBox
        Me.MCHB_TIPO = New MisControles.Controles.MisCheckBox
        Me.MCHB_GRUPO = New MisControles.Controles.MisCheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MCB_TIPO = New MisControles.Controles.MisComboBox
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
        Me.Panel1.Size = New System.Drawing.Size(595, 335)
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(593, 311)
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
        Me.Panel2.Size = New System.Drawing.Size(587, 26)
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 35)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.03448!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.96552!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(159, 273)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.BT_1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 196)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4)
        Me.Panel3.Size = New System.Drawing.Size(153, 74)
        Me.Panel3.TabIndex = 0
        '
        'BT_1
        '
        Me.BT_1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BT_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_1.Location = New System.Drawing.Point(4, 30)
        Me.BT_1.Name = "BT_1"
        Me.BT_1.Size = New System.Drawing.Size(145, 40)
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
        Me.Panel4.Size = New System.Drawing.Size(153, 187)
        Me.Panel4.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global._VsagAdm.My.Resources.Resources.IMPRESORA
        Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(149, 183)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.MCHB_PROVEEDOR)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.MCB_PROVEEDOR)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.MF_HASTA)
        Me.Panel5.Controls.Add(Me.MF_DESDE)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.MCHB_FECHA)
        Me.Panel5.Controls.Add(Me.MCHB_TIPO)
        Me.Panel5.Controls.Add(Me.MCHB_GRUPO)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.MCB_TIPO)
        Me.Panel5.Controls.Add(Me.MCB_GRUPO)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(168, 35)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel5.Size = New System.Drawing.Size(422, 273)
        Me.Panel5.TabIndex = 0
        '
        'MCHB_PROVEEDOR
        '
        Me.MCHB_PROVEEDOR.AutoSize = True
        Me.MCHB_PROVEEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_PROVEEDOR.Location = New System.Drawing.Point(12, 79)
        Me.MCHB_PROVEEDOR.Name = "MCHB_PROVEEDOR"
        Me.MCHB_PROVEEDOR.Size = New System.Drawing.Size(115, 20)
        Me.MCHB_PROVEEDOR.TabIndex = 0
        Me.MCHB_PROVEEDOR.Text = "Por Proveedor"
        Me.MCHB_PROVEEDOR.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 43
        '
        'MCB_PROVEEDOR
        '
        Me.MCB_PROVEEDOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_PROVEEDOR.DropDownWidth = 450
        Me.MCB_PROVEEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_PROVEEDOR.FormattingEnabled = True
        Me.MCB_PROVEEDOR.Location = New System.Drawing.Point(164, 79)
        Me.MCB_PROVEEDOR.Name = "MCB_PROVEEDOR"
        Me.MCB_PROVEEDOR.Size = New System.Drawing.Size(241, 24)
        Me.MCB_PROVEEDOR.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkRed
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(2, 2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(416, 21)
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
        Me.MF_HASTA.Location = New System.Drawing.Point(200, 217)
        Me.MF_HASTA.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_HASTA.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_HASTA.Name = "MF_HASTA"
        Me.MF_HASTA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.p_IniciarComo = True
        Me.MF_HASTA.ShowCheckBox = True
        Me.MF_HASTA.Size = New System.Drawing.Size(205, 22)
        Me.MF_HASTA.TabIndex = 8
        Me.MF_HASTA.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MF_DESDE
        '
        Me.MF_DESDE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_DESDE.ForeColor = System.Drawing.Color.Black
        Me.MF_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_DESDE.Location = New System.Drawing.Point(200, 193)
        Me.MF_DESDE.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_DESDE.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_DESDE.Name = "MF_DESDE"
        Me.MF_DESDE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.p_IniciarComo = True
        Me.MF_DESDE.ShowCheckBox = True
        Me.MF_DESDE.Size = New System.Drawing.Size(205, 22)
        Me.MF_DESDE.TabIndex = 7
        Me.MF_DESDE.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(156, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(153, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Desde:"
        '
        'MCHB_FECHA
        '
        Me.MCHB_FECHA.AutoSize = True
        Me.MCHB_FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_FECHA.Location = New System.Drawing.Point(12, 157)
        Me.MCHB_FECHA.Name = "MCHB_FECHA"
        Me.MCHB_FECHA.Size = New System.Drawing.Size(92, 20)
        Me.MCHB_FECHA.TabIndex = 6
        Me.MCHB_FECHA.Text = "Por Fecha "
        Me.MCHB_FECHA.UseVisualStyleBackColor = True
        '
        'MCHB_TIPO
        '
        Me.MCHB_TIPO.AutoSize = True
        Me.MCHB_TIPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_TIPO.Location = New System.Drawing.Point(12, 131)
        Me.MCHB_TIPO.Name = "MCHB_TIPO"
        Me.MCHB_TIPO.Size = New System.Drawing.Size(146, 20)
        Me.MCHB_TIPO.TabIndex = 4
        Me.MCHB_TIPO.Text = "Por Tipo Proveedor"
        Me.MCHB_TIPO.UseVisualStyleBackColor = True
        '
        'MCHB_GRUPO
        '
        Me.MCHB_GRUPO.AutoSize = True
        Me.MCHB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_GRUPO.Location = New System.Drawing.Point(12, 105)
        Me.MCHB_GRUPO.Name = "MCHB_GRUPO"
        Me.MCHB_GRUPO.Size = New System.Drawing.Size(95, 20)
        Me.MCHB_GRUPO.TabIndex = 2
        Me.MCHB_GRUPO.Text = "Por Grupos"
        Me.MCHB_GRUPO.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 21
        '
        'MCB_TIPO
        '
        Me.MCB_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_TIPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_TIPO.FormattingEnabled = True
        Me.MCB_TIPO.Location = New System.Drawing.Point(164, 131)
        Me.MCB_TIPO.Name = "MCB_TIPO"
        Me.MCB_TIPO.Size = New System.Drawing.Size(241, 24)
        Me.MCB_TIPO.TabIndex = 5
        '
        'MCB_GRUPO
        '
        Me.MCB_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPO.DropDownWidth = 450
        Me.MCB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_GRUPO.FormattingEnabled = True
        Me.MCB_GRUPO.Location = New System.Drawing.Point(164, 105)
        Me.MCB_GRUPO.Name = "MCB_GRUPO"
        Me.MCB_GRUPO.Size = New System.Drawing.Size(241, 24)
        Me.MCB_GRUPO.TabIndex = 3
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 311)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(593, 22)
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
        'PlantillaFiltroReporteCxP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(599, 339)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(615, 377)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(615, 377)
        Me.Name = "PlantillaFiltroReporteCxP"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes CxP"
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
    Friend WithEvents MCHB_TIPO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_GRUPO As MisControles.Controles.MisCheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MCB_TIPO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_GRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents MF_HASTA As MisControles.Controles.MisFechas
    Friend WithEvents MF_DESDE As MisControles.Controles.MisFechas
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MCHB_FECHA As MisControles.Controles.MisCheckBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MCHB_PROVEEDOR As MisControles.Controles.MisCheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MCB_PROVEEDOR As MisControles.Controles.MisComboBox
End Class
