<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusAvanzadaCobrador
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
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.MF_HASTA = New MisControles.Controles.MisFechas
        Me.MF_DESDE = New MisControles.Controles.MisFechas
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.MCHB_FECHA = New MisControles.Controles.MisCheckBox
        Me.MCHB_ESTATUS = New MisControles.Controles.MisCheckBox
        Me.MCHB_TPO_COMISION = New MisControles.Controles.MisCheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MCB_ESTATUS = New MisControles.Controles.MisComboBox
        Me.MCB_TIPO_COMISION = New MisControles.Controles.MisComboBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
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
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(524, 296)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 31)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 169.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(522, 241)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.BT_PROCESAR)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 172)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(516, 66)
        Me.Panel4.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(243, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Indique El Tipo De Busqueda"
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.Location = New System.Drawing.Point(375, 9)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(122, 42)
        Me.BT_PROCESAR.TabIndex = 1
        Me.BT_PROCESAR.Text = "&Procesar"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(516, 2)
        Me.Panel5.TabIndex = 0
        '
        'Panel6
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel6, 2)
        Me.Panel6.Controls.Add(Me.MF_HASTA)
        Me.Panel6.Controls.Add(Me.MF_DESDE)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.MCHB_FECHA)
        Me.Panel6.Controls.Add(Me.MCHB_ESTATUS)
        Me.Panel6.Controls.Add(Me.MCHB_TPO_COMISION)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.MCB_ESTATUS)
        Me.Panel6.Controls.Add(Me.MCB_TIPO_COMISION)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(516, 163)
        Me.Panel6.TabIndex = 1
        '
        'MF_HASTA
        '
        Me.MF_HASTA.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_HASTA.ForeColor = System.Drawing.Color.Black
        Me.MF_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_HASTA.Location = New System.Drawing.Point(292, 106)
        Me.MF_HASTA.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_HASTA.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_HASTA.Name = "MF_HASTA"
        Me.MF_HASTA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.p_IniciarComo = True
        Me.MF_HASTA.ShowCheckBox = True
        Me.MF_HASTA.Size = New System.Drawing.Size(205, 22)
        Me.MF_HASTA.TabIndex = 30
        Me.MF_HASTA.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MF_DESDE
        '
        Me.MF_DESDE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_DESDE.ForeColor = System.Drawing.Color.Black
        Me.MF_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_DESDE.Location = New System.Drawing.Point(292, 82)
        Me.MF_DESDE.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_DESDE.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_DESDE.Name = "MF_DESDE"
        Me.MF_DESDE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.p_IniciarComo = True
        Me.MF_DESDE.ShowCheckBox = True
        Me.MF_DESDE.Size = New System.Drawing.Size(205, 22)
        Me.MF_DESDE.TabIndex = 29
        Me.MF_DESDE.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(245, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(245, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Desde:"
        '
        'MCHB_FECHA
        '
        Me.MCHB_FECHA.AutoSize = True
        Me.MCHB_FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_FECHA.Location = New System.Drawing.Point(49, 82)
        Me.MCHB_FECHA.Name = "MCHB_FECHA"
        Me.MCHB_FECHA.Size = New System.Drawing.Size(164, 20)
        Me.MCHB_FECHA.TabIndex = 28
        Me.MCHB_FECHA.Text = "Por Fecha De Registro"
        Me.MCHB_FECHA.UseVisualStyleBackColor = True
        '
        'MCHB_ESTATUS
        '
        Me.MCHB_ESTATUS.AutoSize = True
        Me.MCHB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ESTATUS.Location = New System.Drawing.Point(49, 58)
        Me.MCHB_ESTATUS.Name = "MCHB_ESTATUS"
        Me.MCHB_ESTATUS.Size = New System.Drawing.Size(95, 20)
        Me.MCHB_ESTATUS.TabIndex = 26
        Me.MCHB_ESTATUS.Text = "Por Estatus"
        Me.MCHB_ESTATUS.UseVisualStyleBackColor = True
        '
        'MCHB_TPO_COMISION
        '
        Me.MCHB_TPO_COMISION.AutoSize = True
        Me.MCHB_TPO_COMISION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_TPO_COMISION.Location = New System.Drawing.Point(49, 32)
        Me.MCHB_TPO_COMISION.Name = "MCHB_TPO_COMISION"
        Me.MCHB_TPO_COMISION.Size = New System.Drawing.Size(138, 20)
        Me.MCHB_TPO_COMISION.TabIndex = 23
        Me.MCHB_TPO_COMISION.Text = "Por Tipo Comision"
        Me.MCHB_TPO_COMISION.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 14
        '
        'MCB_ESTATUS
        '
        Me.MCB_ESTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTATUS.FormattingEnabled = True
        Me.MCB_ESTATUS.Location = New System.Drawing.Point(248, 56)
        Me.MCB_ESTATUS.Name = "MCB_ESTATUS"
        Me.MCB_ESTATUS.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ESTATUS.TabIndex = 27
        '
        'MCB_TIPO_COMISION
        '
        Me.MCB_TIPO_COMISION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_TIPO_COMISION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_TIPO_COMISION.FormattingEnabled = True
        Me.MCB_TIPO_COMISION.Location = New System.Drawing.Point(248, 30)
        Me.MCB_TIPO_COMISION.Name = "MCB_TIPO_COMISION"
        Me.MCB_TIPO_COMISION.Size = New System.Drawing.Size(249, 24)
        Me.MCB_TIPO_COMISION.TabIndex = 24
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 272)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(522, 22)
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
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(522, 31)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(522, 3)
        Me.Panel3.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Busqueda Avanzada !!!"
        '
        'BusAvanzadaCobrador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(530, 302)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(546, 340)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(546, 340)
        Me.Name = "BusAvanzadaCobrador"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobrador"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents MCB_ESTATUS As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_TIPO_COMISION As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_ESTATUS As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_TPO_COMISION As MisControles.Controles.MisCheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MCHB_FECHA As MisControles.Controles.MisCheckBox
    Friend WithEvents MF_DESDE As MisControles.Controles.MisFechas
    Friend WithEvents MF_HASTA As MisControles.Controles.MisFechas
End Class