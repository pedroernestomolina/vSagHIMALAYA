<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Plantilla_13
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LB_1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.PB_3 = New System.Windows.Forms.PictureBox
        Me.PB_2 = New System.Windows.Forms.PictureBox
        Me.PB_1 = New System.Windows.Forms.PictureBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.MisGrid1 = New MisControles.Controles.MisGrid
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.BT_1 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.MN_1 = New MisControles.Controles.MisNumeros
        Me.MN_3 = New MisControles.Controles.MisNumeros
        Me.MN_2 = New MisControles.Controles.MisNumeros
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PB_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.MisGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(553, 365)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 442.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 233.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(551, 341)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MidnightBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.LB_1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(545, 30)
        Me.Panel2.TabIndex = 0
        '
        'LB_1
        '
        Me.LB_1.AutoSize = True
        Me.LB_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_1.ForeColor = System.Drawing.Color.White
        Me.LB_1.Location = New System.Drawing.Point(3, 3)
        Me.LB_1.Name = "LB_1"
        Me.LB_1.Size = New System.Drawing.Size(328, 20)
        Me.LB_1.TabIndex = 0
        Me.LB_1.Text = "Definir Tabla Comisiones Para La Venta"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.PB_3)
        Me.Panel3.Controls.Add(Me.PB_2)
        Me.Panel3.Controls.Add(Me.PB_1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 39)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel3.Size = New System.Drawing.Size(103, 227)
        Me.Panel3.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Sienna
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(13, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "F3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Sienna
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(13, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "F2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Sienna
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "F1"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(2, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 14)
        Me.Label7.TabIndex = 25
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PB_3
        '
        Me.PB_3.Image = Global._VsagAdm.My.Resources.Resources.DataBorrar
        Me.PB_3.Location = New System.Drawing.Point(25, 157)
        Me.PB_3.Name = "PB_3"
        Me.PB_3.Size = New System.Drawing.Size(50, 50)
        Me.PB_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_3.TabIndex = 24
        Me.PB_3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PB_3, "Eliminar Una Regla")
        '
        'PB_2
        '
        Me.PB_2.Image = Global._VsagAdm.My.Resources.Resources.database_actualizar_1
        Me.PB_2.Location = New System.Drawing.Point(25, 96)
        Me.PB_2.Name = "PB_2"
        Me.PB_2.Size = New System.Drawing.Size(50, 50)
        Me.PB_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_2.TabIndex = 23
        Me.PB_2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PB_2, "Modificar Una Regla")
        '
        'PB_1
        '
        Me.PB_1.ErrorImage = Nothing
        Me.PB_1.Image = Global._VsagAdm.My.Resources.Resources.DataAgregar
        Me.PB_1.Location = New System.Drawing.Point(25, 35)
        Me.PB_1.Name = "PB_1"
        Me.PB_1.Size = New System.Drawing.Size(50, 50)
        Me.PB_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_1.TabIndex = 22
        Me.PB_1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PB_1, "Crear Una Nueva Regla")
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.MisGrid1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(112, 39)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel4.Size = New System.Drawing.Size(436, 227)
        Me.Panel4.TabIndex = 2
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MisGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MisGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MisGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MisGrid1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.MisGrid1.Location = New System.Drawing.Point(2, 2)
        Me.MisGrid1.MultiSelect = False
        Me.MisGrid1.Name = "MisGrid1"
        Me.MisGrid1.ReadOnly = True
        Me.MisGrid1.RowHeadersVisible = False
        Me.MisGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MisGrid1.Size = New System.Drawing.Size(432, 223)
        Me.MisGrid1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gainsboro
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel5, 2)
        Me.Panel5.Controls.Add(Me.BT_1)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.MN_1)
        Me.Panel5.Controls.Add(Me.MN_3)
        Me.Panel5.Controls.Add(Me.MN_2)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 272)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(545, 66)
        Me.Panel5.TabIndex = 0
        '
        'BT_1
        '
        Me.BT_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_1.Location = New System.Drawing.Point(431, 9)
        Me.BT_1.Name = "BT_1"
        Me.BT_1.Size = New System.Drawing.Size(111, 49)
        Me.BT_1.TabIndex = 3
        Me.BT_1.Text = "Guardar / Procesar"
        Me.BT_1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 18)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Comision (%):"
        '
        'MN_1
        '
        Me.MN_1._ConSigno = False
        Me.MN_1._Formato = ""
        Me.MN_1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_1.ForeColor = System.Drawing.Color.Black
        Me.MN_1.Location = New System.Drawing.Point(131, 24)
        Me.MN_1.Name = "MN_1"
        Me.MN_1.Size = New System.Drawing.Size(68, 24)
        Me.MN_1.TabIndex = 0
        Me.MN_1.Text = "0"
        Me.MN_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_3
        '
        Me.MN_3._ConSigno = False
        Me.MN_3._Formato = ""
        Me.MN_3.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_3.ForeColor = System.Drawing.Color.Black
        Me.MN_3.Location = New System.Drawing.Point(313, 36)
        Me.MN_3.Name = "MN_3"
        Me.MN_3.Size = New System.Drawing.Size(100, 24)
        Me.MN_3.TabIndex = 2
        Me.MN_3.Text = "0"
        Me.MN_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_2
        '
        Me.MN_2._ConSigno = False
        Me.MN_2._Formato = ""
        Me.MN_2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_2.ForeColor = System.Drawing.Color.Black
        Me.MN_2.Location = New System.Drawing.Point(313, 9)
        Me.MN_2.Name = "MN_2"
        Me.MN_2.Size = New System.Drawing.Size(100, 24)
        Me.MN_2.TabIndex = 1
        Me.MN_2.Text = "0"
        Me.MN_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(205, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Monto Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(205, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Monto Desde:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Definir Regla:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 341)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(551, 22)
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
        'Plantilla_13
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(557, 369)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(573, 407)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(573, 407)
        Me.Name = "Plantilla_13"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plantilla_13"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PB_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.MisGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
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
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents MisGrid1 As MisControles.Controles.MisGrid
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PB_3 As System.Windows.Forms.PictureBox
    Friend WithEvents PB_2 As System.Windows.Forms.PictureBox
    Friend WithEvents PB_1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MN_1 As MisControles.Controles.MisNumeros
    Friend WithEvents MN_3 As MisControles.Controles.MisNumeros
    Friend WithEvents MN_2 As MisControles.Controles.MisNumeros
    Friend WithEvents BT_1 As System.Windows.Forms.Button
End Class
