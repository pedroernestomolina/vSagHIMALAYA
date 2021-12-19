<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichaDeposito
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
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.E_PEDIDO_MINIMO = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.E_DEPOSITO = New System.Windows.Forms.Label
        Me.E_OPTIMO = New System.Windows.Forms.Label
        Me.E_PEDIDO_OPTIMO = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.E_MINIMO = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.E_UB_4 = New System.Windows.Forms.Label
        Me.E_UB_3 = New System.Windows.Forms.Label
        Me.E_UB_2 = New System.Windows.Forms.Label
        Me.E_UB_1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.E_PRODUCTO = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.BT_ACTUALIZAR = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(405, 443)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 334.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(403, 393)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.E_PEDIDO_MINIMO)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.E_DEPOSITO)
        Me.Panel3.Controls.Add(Me.E_OPTIMO)
        Me.Panel3.Controls.Add(Me.E_PEDIDO_OPTIMO)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.E_MINIMO)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.E_UB_4)
        Me.Panel3.Controls.Add(Me.E_UB_3)
        Me.Panel3.Controls.Add(Me.E_UB_2)
        Me.Panel3.Controls.Add(Me.E_UB_1)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.E_PRODUCTO)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.ShapeContainer1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel3.Size = New System.Drawing.Size(397, 328)
        Me.Panel3.TabIndex = 0
        '
        'E_PEDIDO_MINIMO
        '
        Me.E_PEDIDO_MINIMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_PEDIDO_MINIMO.Location = New System.Drawing.Point(256, 273)
        Me.E_PEDIDO_MINIMO.Name = "E_PEDIDO_MINIMO"
        Me.E_PEDIDO_MINIMO.Size = New System.Drawing.Size(123, 25)
        Me.E_PEDIDO_MINIMO.TabIndex = 29
        Me.E_PEDIDO_MINIMO.Text = "99999.999"
        Me.E_PEDIDO_MINIMO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(73, 278)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(177, 18)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Punto De Pedido Minimo:"
        '
        'E_DEPOSITO
        '
        Me.E_DEPOSITO.AutoSize = True
        Me.E_DEPOSITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_DEPOSITO.Location = New System.Drawing.Point(86, 42)
        Me.E_DEPOSITO.Name = "E_DEPOSITO"
        Me.E_DEPOSITO.Size = New System.Drawing.Size(51, 18)
        Me.E_DEPOSITO.TabIndex = 27
        Me.E_DEPOSITO.Text = "Label8"
        '
        'E_OPTIMO
        '
        Me.E_OPTIMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_OPTIMO.Location = New System.Drawing.Point(127, 237)
        Me.E_OPTIMO.Name = "E_OPTIMO"
        Me.E_OPTIMO.Size = New System.Drawing.Size(85, 20)
        Me.E_OPTIMO.TabIndex = 26
        Me.E_OPTIMO.Text = "99999.999"
        Me.E_OPTIMO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_PEDIDO_OPTIMO
        '
        Me.E_PEDIDO_OPTIMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_PEDIDO_OPTIMO.Location = New System.Drawing.Point(256, 302)
        Me.E_PEDIDO_OPTIMO.Name = "E_PEDIDO_OPTIMO"
        Me.E_PEDIDO_OPTIMO.Size = New System.Drawing.Size(123, 25)
        Me.E_PEDIDO_OPTIMO.TabIndex = 25
        Me.E_PEDIDO_OPTIMO.Text = "99999.999"
        Me.E_PEDIDO_OPTIMO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(73, 307)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(177, 18)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Punto De Pedido Optimo:"
        '
        'E_MINIMO
        '
        Me.E_MINIMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_MINIMO.Location = New System.Drawing.Point(127, 207)
        Me.E_MINIMO.Name = "E_MINIMO"
        Me.E_MINIMO.Size = New System.Drawing.Size(85, 20)
        Me.E_MINIMO.TabIndex = 22
        Me.E_MINIMO.Text = "99999.999"
        Me.E_MINIMO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(28, 238)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 18)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Nivel Optimo:"
        '
        'E_UB_4
        '
        Me.E_UB_4.AutoSize = True
        Me.E_UB_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_UB_4.Location = New System.Drawing.Point(128, 169)
        Me.E_UB_4.Name = "E_UB_4"
        Me.E_UB_4.Size = New System.Drawing.Size(168, 18)
        Me.E_UB_4.TabIndex = 20
        Me.E_UB_4.Text = "12345678901234567890"
        '
        'E_UB_3
        '
        Me.E_UB_3.AutoSize = True
        Me.E_UB_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_UB_3.Location = New System.Drawing.Point(128, 139)
        Me.E_UB_3.Name = "E_UB_3"
        Me.E_UB_3.Size = New System.Drawing.Size(168, 18)
        Me.E_UB_3.TabIndex = 19
        Me.E_UB_3.Text = "12345678901234567890"
        '
        'E_UB_2
        '
        Me.E_UB_2.AutoSize = True
        Me.E_UB_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_UB_2.Location = New System.Drawing.Point(128, 109)
        Me.E_UB_2.Name = "E_UB_2"
        Me.E_UB_2.Size = New System.Drawing.Size(168, 18)
        Me.E_UB_2.TabIndex = 18
        Me.E_UB_2.Text = "12345678901234567890"
        '
        'E_UB_1
        '
        Me.E_UB_1.AutoSize = True
        Me.E_UB_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_UB_1.Location = New System.Drawing.Point(128, 79)
        Me.E_UB_1.Name = "E_UB_1"
        Me.E_UB_1.Size = New System.Drawing.Size(168, 18)
        Me.E_UB_1.TabIndex = 17
        Me.E_UB_1.Text = "12345678901234567890"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 18)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Ubicacion (4):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 18)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Ubicacion (3):"
        '
        'E_PRODUCTO
        '
        Me.E_PRODUCTO.BackColor = System.Drawing.Color.Gainsboro
        Me.E_PRODUCTO.Dock = System.Windows.Forms.DockStyle.Top
        Me.E_PRODUCTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_PRODUCTO.Location = New System.Drawing.Point(2, 2)
        Me.E_PRODUCTO.Name = "E_PRODUCTO"
        Me.E_PRODUCTO.Size = New System.Drawing.Size(393, 38)
        Me.E_PRODUCTO.TabIndex = 7
        Me.E_PRODUCTO.Text = "Producto" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Maximo Dos Lineas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.E_PRODUCTO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 18)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Nivel Minimo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Ubicacion (2):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Ubicacion (1):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Deposito:"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(2, 2)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(393, 324)
        Me.ShapeContainer1.TabIndex = 14
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 377
        Me.LineShape2.X2 = 14
        Me.LineShape2.Y1 = 264
        Me.LineShape2.Y2 = 264
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 376
        Me.LineShape1.X2 = 13
        Me.LineShape1.Y1 = 196
        Me.LineShape1.Y2 = 196
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(403, 26)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Informacion Del Deposito !!"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 419)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(403, 22)
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
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Firebrick
        Me.Panel4.Controls.Add(Me.BT_ACTUALIZAR)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 337)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(397, 53)
        Me.Panel4.TabIndex = 1
        '
        'BT_ACTUALIZAR
        '
        Me.BT_ACTUALIZAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_ACTUALIZAR.Location = New System.Drawing.Point(261, 3)
        Me.BT_ACTUALIZAR.Name = "BT_ACTUALIZAR"
        Me.BT_ACTUALIZAR.Size = New System.Drawing.Size(131, 47)
        Me.BT_ACTUALIZAR.TabIndex = 0
        Me.BT_ACTUALIZAR.Text = "&Actualizar Datos"
        Me.BT_ACTUALIZAR.UseVisualStyleBackColor = True
        '
        'FichaDeposito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(409, 447)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(425, 485)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(425, 485)
        Me.Name = "FichaDeposito"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Producto Deposito"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents E_PRODUCTO As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents E_UB_4 As System.Windows.Forms.Label
    Friend WithEvents E_UB_3 As System.Windows.Forms.Label
    Friend WithEvents E_UB_2 As System.Windows.Forms.Label
    Friend WithEvents E_UB_1 As System.Windows.Forms.Label
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents E_MINIMO As System.Windows.Forms.Label
    Friend WithEvents E_PEDIDO_OPTIMO As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents E_OPTIMO As System.Windows.Forms.Label
    Friend WithEvents E_DEPOSITO As System.Windows.Forms.Label
    Friend WithEvents E_PEDIDO_MINIMO As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BT_ACTUALIZAR As System.Windows.Forms.Button
End Class
