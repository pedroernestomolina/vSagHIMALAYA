<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvProducto_UbicacionNivel
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.E_DEPOSITO = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.E_2 = New System.Windows.Forms.Label
        Me.E_1 = New System.Windows.Forms.Label
        Me.E_0 = New System.Windows.Forms.Label
        Me.E_PRODUCTO = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.MT_1 = New MisControles.Controles.MisTextos
        Me.Label15 = New System.Windows.Forms.Label
        Me.MN_2 = New MisControles.Controles.MisNumeros
        Me.Label20 = New System.Windows.Forms.Label
        Me.MN_1 = New MisControles.Controles.MisNumeros
        Me.Label21 = New System.Windows.Forms.Label
        Me.MT_4 = New MisControles.Controles.MisTextos
        Me.Label22 = New System.Windows.Forms.Label
        Me.MT_3 = New MisControles.Controles.MisTextos
        Me.Label28 = New System.Windows.Forms.Label
        Me.MT_2 = New MisControles.Controles.MisTextos
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(570, 343)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.59364!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.40636!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.27273!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(568, 319)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Maroon
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel2.Size = New System.Drawing.Size(304, 55)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.OrangeRed
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(300, 51)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ficha Actualizar Datos Ubicacion / Nivel Del Producto En Inventario"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel3, 2)
        Me.Panel3.Controls.Add(Me.E_DEPOSITO)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.E_2)
        Me.Panel3.Controls.Add(Me.E_1)
        Me.Panel3.Controls.Add(Me.E_0)
        Me.Panel3.Controls.Add(Me.E_PRODUCTO)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 64)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel3.Size = New System.Drawing.Size(562, 202)
        Me.Panel3.TabIndex = 1
        '
        'E_DEPOSITO
        '
        Me.E_DEPOSITO.AutoSize = True
        Me.E_DEPOSITO.Dock = System.Windows.Forms.DockStyle.Top
        Me.E_DEPOSITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_DEPOSITO.Location = New System.Drawing.Point(2, 117)
        Me.E_DEPOSITO.Name = "E_DEPOSITO"
        Me.E_DEPOSITO.Size = New System.Drawing.Size(57, 18)
        Me.E_DEPOSITO.TabIndex = 42
        Me.E_DEPOSITO.Text = "Label7"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Deposito:"
        '
        'E_2
        '
        Me.E_2.AutoSize = True
        Me.E_2.Dock = System.Windows.Forms.DockStyle.Top
        Me.E_2.Location = New System.Drawing.Point(2, 91)
        Me.E_2.Name = "E_2"
        Me.E_2.Size = New System.Drawing.Size(106, 13)
        Me.E_2.TabIndex = 40
        Me.E_2.Text = "Contenido Empaque:"
        '
        'E_1
        '
        Me.E_1.AutoSize = True
        Me.E_1.Dock = System.Windows.Forms.DockStyle.Top
        Me.E_1.Location = New System.Drawing.Point(2, 78)
        Me.E_1.Name = "E_1"
        Me.E_1.Size = New System.Drawing.Size(92, 13)
        Me.E_1.TabIndex = 39
        Me.E_1.Text = "Unidad Empaque:"
        '
        'E_0
        '
        Me.E_0.AutoSize = True
        Me.E_0.Dock = System.Windows.Forms.DockStyle.Top
        Me.E_0.Location = New System.Drawing.Point(2, 65)
        Me.E_0.Name = "E_0"
        Me.E_0.Size = New System.Drawing.Size(43, 13)
        Me.E_0.TabIndex = 38
        Me.E_0.Text = "Codigo:"
        '
        'E_PRODUCTO
        '
        Me.E_PRODUCTO.BackColor = System.Drawing.Color.Gainsboro
        Me.E_PRODUCTO.Dock = System.Windows.Forms.DockStyle.Top
        Me.E_PRODUCTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_PRODUCTO.Location = New System.Drawing.Point(2, 21)
        Me.E_PRODUCTO.Name = "E_PRODUCTO"
        Me.E_PRODUCTO.Size = New System.Drawing.Size(249, 44)
        Me.E_PRODUCTO.TabIndex = 35
        Me.E_PRODUCTO.Text = "Label3"
        Me.E_PRODUCTO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.MT_1)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.MN_2)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.MN_1)
        Me.Panel4.Controls.Add(Me.Label21)
        Me.Panel4.Controls.Add(Me.MT_4)
        Me.Panel4.Controls.Add(Me.Label22)
        Me.Panel4.Controls.Add(Me.MT_3)
        Me.Panel4.Controls.Add(Me.Label28)
        Me.Panel4.Controls.Add(Me.MT_2)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(251, 21)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(309, 179)
        Me.Panel4.TabIndex = 34
        '
        'MT_1
        '
        Me.MT_1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_1.ForeColor = System.Drawing.Color.Black
        Me.MT_1.Location = New System.Drawing.Point(109, 22)
        Me.MT_1.MaxLength = 20
        Me.MT_1.Name = "MT_1"
        Me.MT_1.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_1.p_IniciarComo = True
        Me.MT_1.Size = New System.Drawing.Size(188, 22)
        Me.MT_1.TabIndex = 21
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(9, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 18)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Ubicacion(1):"
        '
        'MN_2
        '
        Me.MN_2._ConSigno = False
        Me.MN_2._Formato = ""
        Me.MN_2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_2.ForeColor = System.Drawing.Color.Black
        Me.MN_2.Location = New System.Drawing.Point(197, 138)
        Me.MN_2.Name = "MN_2"
        Me.MN_2.Size = New System.Drawing.Size(100, 22)
        Me.MN_2.TabIndex = 26
        Me.MN_2.Text = "0"
        Me.MN_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(9, 45)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 18)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "Ubicacion(2):"
        '
        'MN_1
        '
        Me.MN_1._ConSigno = False
        Me.MN_1._Formato = ""
        Me.MN_1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_1.ForeColor = System.Drawing.Color.Black
        Me.MN_1.Location = New System.Drawing.Point(197, 114)
        Me.MN_1.Name = "MN_1"
        Me.MN_1.Size = New System.Drawing.Size(100, 24)
        Me.MN_1.TabIndex = 25
        Me.MN_1.Text = "0"
        Me.MN_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(9, 67)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 18)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "Ubicacion(3):"
        '
        'MT_4
        '
        Me.MT_4.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_4.ForeColor = System.Drawing.Color.Black
        Me.MT_4.Location = New System.Drawing.Point(109, 88)
        Me.MT_4.MaxLength = 20
        Me.MT_4.Name = "MT_4"
        Me.MT_4.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_4.p_IniciarComo = True
        Me.MT_4.Size = New System.Drawing.Size(188, 22)
        Me.MT_4.TabIndex = 24
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(9, 89)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(96, 18)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "Ubicacion(4):"
        '
        'MT_3
        '
        Me.MT_3.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_3.ForeColor = System.Drawing.Color.Black
        Me.MT_3.Location = New System.Drawing.Point(109, 66)
        Me.MT_3.MaxLength = 20
        Me.MT_3.Name = "MT_3"
        Me.MT_3.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_3.p_IniciarComo = True
        Me.MT_3.Size = New System.Drawing.Size(188, 22)
        Me.MT_3.TabIndex = 23
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(96, 117)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(97, 18)
        Me.Label28.TabIndex = 31
        Me.Label28.Text = "Nivel Minimo:"
        '
        'MT_2
        '
        Me.MT_2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_2.ForeColor = System.Drawing.Color.Black
        Me.MT_2.Location = New System.Drawing.Point(109, 44)
        Me.MT_2.MaxLength = 20
        Me.MT_2.Name = "MT_2"
        Me.MT_2.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_2.p_IniciarComo = True
        Me.MT_2.Size = New System.Drawing.Size(188, 22)
        Me.MT_2.TabIndex = 22
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(96, 139)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(97, 18)
        Me.Label31.TabIndex = 32
        Me.Label31.Text = "Nivel Optimo:"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(558, 19)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Datos Del Producto:"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel5, 2)
        Me.Panel5.Controls.Add(Me.BT_PROCESAR)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 272)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel5.Size = New System.Drawing.Size(562, 44)
        Me.Panel5.TabIndex = 2
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.Location = New System.Drawing.Point(385, 1)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(170, 43)
        Me.BT_PROCESAR.TabIndex = 0
        Me.BT_PROCESAR.Text = "Procesar / Guardar"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 319)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(568, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(234, 17)
        Me.ToolStripStatusLabel1.Text = "Presione La Tecla < Esc  > Para Salir"
        '
        'InvProducto_UbicacionNivel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Brown
        Me.ClientSize = New System.Drawing.Size(574, 347)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(590, 385)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(590, 385)
        Me.Name = "InvProducto_UbicacionNivel"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents MN_2 As MisControles.Controles.MisNumeros
    Friend WithEvents MN_1 As MisControles.Controles.MisNumeros
    Friend WithEvents MT_4 As MisControles.Controles.MisTextos
    Friend WithEvents MT_3 As MisControles.Controles.MisTextos
    Friend WithEvents MT_2 As MisControles.Controles.MisTextos
    Friend WithEvents MT_1 As MisControles.Controles.MisTextos
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents E_PRODUCTO As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
    Friend WithEvents E_2 As System.Windows.Forms.Label
    Friend WithEvents E_1 As System.Windows.Forms.Label
    Friend WithEvents E_0 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents E_DEPOSITO As System.Windows.Forms.Label
End Class
