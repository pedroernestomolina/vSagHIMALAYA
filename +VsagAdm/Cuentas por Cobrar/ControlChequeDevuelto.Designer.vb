<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlChequeDevuelto
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.BT_1 = New System.Windows.Forms.Button
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.LK_AGENCIA = New System.Windows.Forms.LinkLabel
        Me.Label10 = New System.Windows.Forms.Label
        Me.MT_1 = New MisControles.Controles.MisTextos
        Me.MN_3 = New MisControles.Controles.MisNumeros
        Me.MN_2 = New MisControles.Controles.MisNumeros
        Me.MF_2 = New MisControles.Controles.MisFechas
        Me.MF_1 = New MisControles.Controles.MisFechas
        Me.MCB_1 = New MisControles.Controles.MisComboBox
        Me.MN_1 = New MisControles.Controles.MisNumeros
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel1.Size = New System.Drawing.Size(516, 420)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.StatusStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(512, 416)
        Me.Panel2.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 28)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.60526!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.39474!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(512, 366)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel7, 2)
        Me.Panel7.Controls.Add(Me.Label8)
        Me.Panel7.Controls.Add(Me.BT_1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 294)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel7.Size = New System.Drawing.Size(506, 69)
        Me.Panel7.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkRed
        Me.Label8.Location = New System.Drawing.Point(2, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(267, 63)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Nuevo Cheque Devuelto"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BT_1
        '
        Me.BT_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_1.Location = New System.Drawing.Point(359, 12)
        Me.BT_1.Name = "BT_1"
        Me.BT_1.Size = New System.Drawing.Size(131, 48)
        Me.BT_1.TabIndex = 0
        Me.BT_1.Text = "&Guardar / Grabar"
        Me.BT_1.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel5, 2)
        Me.Panel5.Controls.Add(Me.LK_AGENCIA)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.MT_1)
        Me.Panel5.Controls.Add(Me.MN_3)
        Me.Panel5.Controls.Add(Me.MN_2)
        Me.Panel5.Controls.Add(Me.MF_2)
        Me.Panel5.Controls.Add(Me.MF_1)
        Me.Panel5.Controls.Add(Me.MCB_1)
        Me.Panel5.Controls.Add(Me.MN_1)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(506, 285)
        Me.Panel5.TabIndex = 0
        '
        'LK_AGENCIA
        '
        Me.LK_AGENCIA.AutoSize = True
        Me.LK_AGENCIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LK_AGENCIA.Location = New System.Drawing.Point(55, 33)
        Me.LK_AGENCIA.Name = "LK_AGENCIA"
        Me.LK_AGENCIA.Size = New System.Drawing.Size(126, 18)
        Me.LK_AGENCIA.TabIndex = 1
        Me.LK_AGENCIA.TabStop = True
        Me.LK_AGENCIA.Text = "Agencia Bancaria:"
        Me.ToolTip1.SetToolTip(Me.LK_AGENCIA, "Control De Agencias Bancarias")
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(187, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 18)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Monto:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MT_1
        '
        Me.MT_1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_1.ForeColor = System.Drawing.Color.Black
        Me.MT_1.Location = New System.Drawing.Point(187, 204)
        Me.MT_1.MaxLength = 20
        Me.MT_1.Multiline = True
        Me.MT_1.Name = "MT_1"
        Me.MT_1.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_1.p_IniciarComo = True
        Me.MT_1.Size = New System.Drawing.Size(304, 58)
        Me.MT_1.TabIndex = 8
        '
        'MN_3
        '
        Me.MN_3._ConSigno = False
        Me.MN_3._Formato = ""
        Me.MN_3.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_3.ForeColor = System.Drawing.Color.Black
        Me.MN_3.Location = New System.Drawing.Point(187, 167)
        Me.MN_3.Name = "MN_3"
        Me.MN_3.Size = New System.Drawing.Size(116, 22)
        Me.MN_3.TabIndex = 6
        Me.MN_3.Text = "0"
        Me.MN_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_2
        '
        Me.MN_2._ConSigno = False
        Me.MN_2._Formato = ""
        Me.MN_2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_2.ForeColor = System.Drawing.Color.Black
        Me.MN_2.Location = New System.Drawing.Point(187, 119)
        Me.MN_2.Name = "MN_2"
        Me.MN_2.Size = New System.Drawing.Size(116, 22)
        Me.MN_2.TabIndex = 5
        Me.MN_2.Text = "0"
        Me.MN_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MF_2
        '
        Me.MF_2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_2.ForeColor = System.Drawing.Color.Black
        Me.MF_2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_2.Location = New System.Drawing.Point(187, 83)
        Me.MF_2.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_2.Name = "MF_2"
        Me.MF_2.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_2.p_IniciarComo = True
        Me.MF_2.Size = New System.Drawing.Size(185, 22)
        Me.MF_2.TabIndex = 4
        Me.MF_2.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MF_1
        '
        Me.MF_1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_1.ForeColor = System.Drawing.Color.Black
        Me.MF_1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_1.Location = New System.Drawing.Point(187, 59)
        Me.MF_1.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_1.Name = "MF_1"
        Me.MF_1.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_1.p_IniciarComo = True
        Me.MF_1.Size = New System.Drawing.Size(185, 22)
        Me.MF_1.TabIndex = 3
        Me.MF_1.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MCB_1
        '
        Me.MCB_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_1.FormattingEnabled = True
        Me.MCB_1.Location = New System.Drawing.Point(187, 33)
        Me.MCB_1.Name = "MCB_1"
        Me.MCB_1.Size = New System.Drawing.Size(304, 24)
        Me.MCB_1.TabIndex = 2
        '
        'MN_1
        '
        Me.MN_1._ConSigno = False
        Me.MN_1._Formato = ""
        Me.MN_1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_1.ForeColor = System.Drawing.Color.Black
        Me.MN_1.Location = New System.Drawing.Point(187, 9)
        Me.MN_1.Name = "MN_1"
        Me.MN_1.Size = New System.Drawing.Size(185, 22)
        Me.MN_1.TabIndex = 0
        Me.MN_1.Text = "0"
        Me.MN_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 205)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 36)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Motivo De La Devolucion:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(42, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 18)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Comision A Cobrar:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(45, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 43)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Monto Del Cheque Devuelto:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 18)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Fecha Devol. Cheque:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Fecha Emision Cheque:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Numero Del Cheque:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(512, 28)
        Me.Panel3.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Datos Basicos Del Cheque"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 27)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(512, 1)
        Me.Panel4.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 394)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(512, 22)
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
        'ControlChequeDevuelto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 424)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(536, 462)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(536, 462)
        Me.Name = "ControlChequeDevuelto"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cheque Devuelto"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BT_1 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MT_1 As MisControles.Controles.MisTextos
    Friend WithEvents MN_3 As MisControles.Controles.MisNumeros
    Friend WithEvents MN_2 As MisControles.Controles.MisNumeros
    Friend WithEvents MF_2 As MisControles.Controles.MisFechas
    Friend WithEvents MF_1 As MisControles.Controles.MisFechas
    Friend WithEvents MCB_1 As MisControles.Controles.MisComboBox
    Friend WithEvents MN_1 As MisControles.Controles.MisNumeros
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LK_AGENCIA As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
