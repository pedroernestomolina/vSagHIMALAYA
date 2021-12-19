<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dscto_FormaPagoCompras
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
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.E_IMPUESTO = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.E_SUB_2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.E_TOTAL = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.E_SUB_1 = New System.Windows.Forms.Label
        Me.MN_CARGO2 = New MisControles.Controles.MisNumeros
        Me.Label2 = New System.Windows.Forms.Label
        Me.MN_DSC2 = New MisControles.Controles.MisNumeros
        Me.Label3 = New System.Windows.Forms.Label
        Me.MN_CARGO1 = New MisControles.Controles.MisNumeros
        Me.Label4 = New System.Windows.Forms.Label
        Me.MN_DSC1 = New MisControles.Controles.MisNumeros
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(430, 285)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 430.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(430, 237)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.BT_PROCESAR)
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 153)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(424, 81)
        Me.Panel4.TabIndex = 1
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.ForeColor = System.Drawing.Color.Black
        Me.BT_PROCESAR.Location = New System.Drawing.Point(284, 32)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(118, 39)
        Me.BT_PROCESAR.TabIndex = 20
        Me.BT_PROCESAR.Text = "&Procesar"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Black
        Me.Panel8.Location = New System.Drawing.Point(12, 14)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(401, 3)
        Me.Panel8.TabIndex = 19
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.E_IMPUESTO)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.E_SUB_2)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.E_TOTAL)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.E_SUB_1)
        Me.Panel3.Controls.Add(Me.MN_CARGO2)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.MN_DSC2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.MN_CARGO1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.MN_DSC1)
        Me.Panel3.Controls.Add(Me.ShapeContainer1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(424, 144)
        Me.Panel3.TabIndex = 0
        '
        'E_IMPUESTO
        '
        Me.E_IMPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_IMPUESTO.ForeColor = System.Drawing.Color.Black
        Me.E_IMPUESTO.Location = New System.Drawing.Point(109, 120)
        Me.E_IMPUESTO.Name = "E_IMPUESTO"
        Me.E_IMPUESTO.Size = New System.Drawing.Size(142, 20)
        Me.E_IMPUESTO.TabIndex = 22
        Me.E_IMPUESTO.Text = "999999999.99"
        Me.E_IMPUESTO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(39, 123)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 16)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Impuesto:"
        '
        'E_SUB_2
        '
        Me.E_SUB_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_SUB_2.ForeColor = System.Drawing.Color.Black
        Me.E_SUB_2.Location = New System.Drawing.Point(109, 96)
        Me.E_SUB_2.Name = "E_SUB_2"
        Me.E_SUB_2.Size = New System.Drawing.Size(142, 20)
        Me.E_SUB_2.TabIndex = 20
        Me.E_SUB_2.Text = "999999999.99"
        Me.E_SUB_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(36, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "SubTotal :"
        '
        'E_TOTAL
        '
        Me.E_TOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_TOTAL.ForeColor = System.Drawing.Color.MidnightBlue
        Me.E_TOTAL.Location = New System.Drawing.Point(254, 116)
        Me.E_TOTAL.Name = "E_TOTAL"
        Me.E_TOTAL.Size = New System.Drawing.Size(163, 25)
        Me.E_TOTAL.TabIndex = 18
        Me.E_TOTAL.Text = "999999999.99"
        Me.E_TOTAL.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(281, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 18)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Total General:"
        '
        'E_SUB_1
        '
        Me.E_SUB_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_SUB_1.ForeColor = System.Drawing.Color.Black
        Me.E_SUB_1.Location = New System.Drawing.Point(107, 6)
        Me.E_SUB_1.Name = "E_SUB_1"
        Me.E_SUB_1.Size = New System.Drawing.Size(144, 20)
        Me.E_SUB_1.TabIndex = 15
        Me.E_SUB_1.Text = "999999999.99"
        Me.E_SUB_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MN_CARGO2
        '
        Me.MN_CARGO2._ConSigno = False
        Me.MN_CARGO2._Formato = ""
        Me.MN_CARGO2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_CARGO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_CARGO2.ForeColor = System.Drawing.Color.Black
        Me.MN_CARGO2.Location = New System.Drawing.Point(171, 56)
        Me.MN_CARGO2.Name = "MN_CARGO2"
        Me.MN_CARGO2.Size = New System.Drawing.Size(80, 24)
        Me.MN_CARGO2.TabIndex = 14
        Me.MN_CARGO2.Text = "0"
        Me.MN_CARGO2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(36, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "SubTotal :"
        '
        'MN_DSC2
        '
        Me.MN_DSC2._ConSigno = False
        Me.MN_DSC2._Formato = ""
        Me.MN_DSC2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_DSC2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_DSC2.ForeColor = System.Drawing.Color.Black
        Me.MN_DSC2.Location = New System.Drawing.Point(171, 31)
        Me.MN_DSC2.Name = "MN_DSC2"
        Me.MN_DSC2.Size = New System.Drawing.Size(80, 24)
        Me.MN_DSC2.TabIndex = 10
        Me.MN_DSC2.Text = "99999.99"
        Me.MN_DSC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Descuento(%):"
        '
        'MN_CARGO1
        '
        Me.MN_CARGO1._ConSigno = False
        Me.MN_CARGO1._Formato = ""
        Me.MN_CARGO1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_CARGO1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_CARGO1.ForeColor = System.Drawing.Color.Black
        Me.MN_CARGO1.Location = New System.Drawing.Point(107, 56)
        Me.MN_CARGO1.Name = "MN_CARGO1"
        Me.MN_CARGO1.Size = New System.Drawing.Size(62, 24)
        Me.MN_CARGO1.TabIndex = 13
        Me.MN_CARGO1.Text = "0"
        Me.MN_CARGO1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(37, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Cargo(%):"
        '
        'MN_DSC1
        '
        Me.MN_DSC1._ConSigno = False
        Me.MN_DSC1._Formato = ""
        Me.MN_DSC1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_DSC1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_DSC1.ForeColor = System.Drawing.Color.Black
        Me.MN_DSC1.Location = New System.Drawing.Point(107, 31)
        Me.MN_DSC1.Name = "MN_DSC1"
        Me.MN_DSC1.Size = New System.Drawing.Size(62, 24)
        Me.MN_DSC1.TabIndex = 8
        Me.MN_DSC1.Text = "99.99"
        Me.MN_DSC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(424, 144)
        Me.ShapeContainer1.TabIndex = 16
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 9
        Me.LineShape1.X2 = 416
        Me.LineShape1.Y1 = 87
        Me.LineShape1.Y2 = 87
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(430, 26)
        Me.Panel2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(262, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descuentos y Cargos Adicionales"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 263)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(430, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(230, 17)
        Me.ToolStripStatusLabel1.Text = "Presione La Tecla < Esc > Para Salir"
        '
        'Dscto_FormaPagoCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(434, 289)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(450, 327)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(450, 327)
        Me.Name = "Dscto_FormaPagoCompras"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents E_SUB_1 As System.Windows.Forms.Label
    Friend WithEvents MN_CARGO2 As MisControles.Controles.MisNumeros
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MN_DSC2 As MisControles.Controles.MisNumeros
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MN_CARGO1 As MisControles.Controles.MisNumeros
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MN_DSC1 As MisControles.Controles.MisNumeros
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents E_IMPUESTO As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents E_SUB_2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents E_TOTAL As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
End Class
