<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarItem
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.MCHB_2 = New MisControles.Controles.MisCheckBox
        Me.E_IMPORTE = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.MN_DESCUENTO = New MisControles.Controles.MisNumeros
        Me.MN_PRECIO = New MisControles.Controles.MisNumeros
        Me.MN_CANTIDAD = New MisControles.Controles.MisNumeros
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.E_PLIQUIDA = New System.Windows.Forms.Label
        Me.E_PSUGERIDO = New System.Windows.Forms.Label
        Me.E_IVA = New System.Windows.Forms.Label
        Me.E_EMPAQUE_CONTENIDO = New System.Windows.Forms.Label
        Me.E_EMPAQUE_NOMBRE = New System.Windows.Forms.Label
        Me.E_CODIGO = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.E_NOMBRE = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BT_GRABAR = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(617, 336)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.StatusStrip1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 307.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(615, 334)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.StatusStrip1, 2)
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 307)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(615, 27)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(230, 22)
        Me.ToolStripStatusLabel1.Text = "Presione La Tecla < Esc > Para Salir"
        '
        'Panel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel2.Size = New System.Drawing.Size(609, 301)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 335.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel6, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 213.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(605, 297)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel3, 2)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(599, 28)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 27)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(599, 1)
        Me.Panel4.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Actualizar Item !!!"
        '
        'Panel5
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel5, 2)
        Me.Panel5.Controls.Add(Me.MCHB_2)
        Me.Panel5.Controls.Add(Me.E_IMPORTE)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.MN_DESCUENTO)
        Me.Panel5.Controls.Add(Me.MN_PRECIO)
        Me.Panel5.Controls.Add(Me.MN_CANTIDAD)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.E_PLIQUIDA)
        Me.Panel5.Controls.Add(Me.E_PSUGERIDO)
        Me.Panel5.Controls.Add(Me.E_IVA)
        Me.Panel5.Controls.Add(Me.E_EMPAQUE_CONTENIDO)
        Me.Panel5.Controls.Add(Me.E_EMPAQUE_NOMBRE)
        Me.Panel5.Controls.Add(Me.E_CODIGO)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.E_NOMBRE)
        Me.Panel5.Controls.Add(Me.ShapeContainer1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 37)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel5.Size = New System.Drawing.Size(599, 207)
        Me.Panel5.TabIndex = 1
        '
        'MCHB_2
        '
        Me.MCHB_2.AutoSize = True
        Me.MCHB_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_2.Location = New System.Drawing.Point(432, 78)
        Me.MCHB_2.Name = "MCHB_2"
        Me.MCHB_2.Size = New System.Drawing.Size(90, 20)
        Me.MCHB_2.TabIndex = 34
        Me.MCHB_2.TabStop = False
        Me.MCHB_2.Text = "Precio &Full"
        Me.MCHB_2.UseVisualStyleBackColor = True
        '
        'E_IMPORTE
        '
        Me.E_IMPORTE.BackColor = System.Drawing.Color.Gainsboro
        Me.E_IMPORTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_IMPORTE.Location = New System.Drawing.Point(432, 169)
        Me.E_IMPORTE.Name = "E_IMPORTE"
        Me.E_IMPORTE.Size = New System.Drawing.Size(126, 24)
        Me.E_IMPORTE.TabIndex = 21
        Me.E_IMPORTE.Text = "99999999.99"
        Me.E_IMPORTE.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(370, 175)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 16)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Importe:"
        '
        'MN_DESCUENTO
        '
        Me.MN_DESCUENTO._ConSigno = False
        Me.MN_DESCUENTO._Formato = ""
        Me.MN_DESCUENTO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_DESCUENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_DESCUENTO.ForeColor = System.Drawing.Color.Black
        Me.MN_DESCUENTO.Location = New System.Drawing.Point(432, 136)
        Me.MN_DESCUENTO.Name = "MN_DESCUENTO"
        Me.MN_DESCUENTO.Size = New System.Drawing.Size(126, 26)
        Me.MN_DESCUENTO.TabIndex = 2
        Me.MN_DESCUENTO.Text = "0"
        Me.MN_DESCUENTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_PRECIO
        '
        Me.MN_PRECIO._ConSigno = False
        Me.MN_PRECIO._Formato = ""
        Me.MN_PRECIO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_PRECIO.ForeColor = System.Drawing.Color.Black
        Me.MN_PRECIO.Location = New System.Drawing.Point(432, 104)
        Me.MN_PRECIO.Name = "MN_PRECIO"
        Me.MN_PRECIO.Size = New System.Drawing.Size(126, 26)
        Me.MN_PRECIO.TabIndex = 1
        Me.MN_PRECIO.Text = "0"
        Me.MN_PRECIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_CANTIDAD
        '
        Me.MN_CANTIDAD._ConSigno = False
        Me.MN_CANTIDAD._Formato = ""
        Me.MN_CANTIDAD.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_CANTIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MN_CANTIDAD.ForeColor = System.Drawing.Color.Black
        Me.MN_CANTIDAD.Location = New System.Drawing.Point(432, 46)
        Me.MN_CANTIDAD.Name = "MN_CANTIDAD"
        Me.MN_CANTIDAD.Size = New System.Drawing.Size(126, 26)
        Me.MN_CANTIDAD.TabIndex = 0
        Me.MN_CANTIDAD.Text = "0"
        Me.MN_CANTIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(330, 142)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 16)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Descuento(%):"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(343, 110)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 16)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Precio/Neto:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(279, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(147, 16)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Cantidad A Despachar:"
        '
        'E_PLIQUIDA
        '
        Me.E_PLIQUIDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_PLIQUIDA.Location = New System.Drawing.Point(94, 169)
        Me.E_PLIQUIDA.Name = "E_PLIQUIDA"
        Me.E_PLIQUIDA.Size = New System.Drawing.Size(116, 18)
        Me.E_PLIQUIDA.TabIndex = 12
        Me.E_PLIQUIDA.Text = "99999999.99"
        Me.E_PLIQUIDA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_PSUGERIDO
        '
        Me.E_PSUGERIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_PSUGERIDO.Location = New System.Drawing.Point(94, 147)
        Me.E_PSUGERIDO.Name = "E_PSUGERIDO"
        Me.E_PSUGERIDO.Size = New System.Drawing.Size(116, 18)
        Me.E_PSUGERIDO.TabIndex = 11
        Me.E_PSUGERIDO.Text = "99999999.99"
        Me.E_PSUGERIDO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_IVA
        '
        Me.E_IVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_IVA.Location = New System.Drawing.Point(94, 127)
        Me.E_IVA.Name = "E_IVA"
        Me.E_IVA.Size = New System.Drawing.Size(49, 18)
        Me.E_IVA.TabIndex = 10
        Me.E_IVA.Text = "99.99"
        Me.E_IVA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_EMPAQUE_CONTENIDO
        '
        Me.E_EMPAQUE_CONTENIDO.AutoSize = True
        Me.E_EMPAQUE_CONTENIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_EMPAQUE_CONTENIDO.Location = New System.Drawing.Point(94, 96)
        Me.E_EMPAQUE_CONTENIDO.Name = "E_EMPAQUE_CONTENIDO"
        Me.E_EMPAQUE_CONTENIDO.Size = New System.Drawing.Size(53, 18)
        Me.E_EMPAQUE_CONTENIDO.TabIndex = 9
        Me.E_EMPAQUE_CONTENIDO.Text = "99999"
        Me.E_EMPAQUE_CONTENIDO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_EMPAQUE_NOMBRE
        '
        Me.E_EMPAQUE_NOMBRE.AutoSize = True
        Me.E_EMPAQUE_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_EMPAQUE_NOMBRE.Location = New System.Drawing.Point(94, 74)
        Me.E_EMPAQUE_NOMBRE.Name = "E_EMPAQUE_NOMBRE"
        Me.E_EMPAQUE_NOMBRE.Size = New System.Drawing.Size(127, 15)
        Me.E_EMPAQUE_NOMBRE.TabIndex = 8
        Me.E_EMPAQUE_NOMBRE.Text = "LARGO DE 15 CAR"
        '
        'E_CODIGO
        '
        Me.E_CODIGO.AutoSize = True
        Me.E_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_CODIGO.Location = New System.Drawing.Point(94, 54)
        Me.E_CODIGO.Name = "E_CODIGO"
        Me.E_CODIGO.Size = New System.Drawing.Size(127, 15)
        Me.E_CODIGO.TabIndex = 7
        Me.E_CODIGO.Text = "LARGO DE 15 CAR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "P/Liquida:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "P/Suegrido:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(39, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Iva(%):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Contenido:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Empaque:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Codigo:"
        '
        'E_NOMBRE
        '
        Me.E_NOMBRE.BackColor = System.Drawing.Color.WhiteSmoke
        Me.E_NOMBRE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.E_NOMBRE.Dock = System.Windows.Forms.DockStyle.Top
        Me.E_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_NOMBRE.Location = New System.Drawing.Point(1, 1)
        Me.E_NOMBRE.Name = "E_NOMBRE"
        Me.E_NOMBRE.Size = New System.Drawing.Size(597, 38)
        Me.E_NOMBRE.TabIndex = 0
        Me.E_NOMBRE.Text = "Identificacion " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Del Producto"
        Me.E_NOMBRE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.E_NOMBRE, "Modificar / Cambiar Descripcion")
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(1, 1)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(597, 205)
        Me.ShapeContainer1.TabIndex = 13
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 255
        Me.LineShape1.X2 = 255
        Me.LineShape1.Y1 = 44
        Me.LineShape1.Y2 = 195
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel6, 2)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.BT_GRABAR)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 250)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(599, 44)
        Me.Panel6.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(32, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 16)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Ver Costo / Utilidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "F1"
        '
        'BT_GRABAR
        '
        Me.BT_GRABAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GRABAR.Location = New System.Drawing.Point(491, 3)
        Me.BT_GRABAR.Name = "BT_GRABAR"
        Me.BT_GRABAR.Size = New System.Drawing.Size(92, 36)
        Me.BT_GRABAR.TabIndex = 0
        Me.BT_GRABAR.Text = "&Grabar"
        Me.BT_GRABAR.UseVisualStyleBackColor = True
        '
        'ModificarItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(621, 340)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(637, 378)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(637, 378)
        Me.Name = "ModificarItem"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents BT_GRABAR As System.Windows.Forms.Button
    Friend WithEvents E_NOMBRE As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents E_PLIQUIDA As System.Windows.Forms.Label
    Friend WithEvents E_PSUGERIDO As System.Windows.Forms.Label
    Friend WithEvents E_IVA As System.Windows.Forms.Label
    Friend WithEvents E_EMPAQUE_CONTENIDO As System.Windows.Forms.Label
    Friend WithEvents E_EMPAQUE_NOMBRE As System.Windows.Forms.Label
    Friend WithEvents E_CODIGO As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents MN_DESCUENTO As MisControles.Controles.MisNumeros
    Friend WithEvents MN_PRECIO As MisControles.Controles.MisNumeros
    Friend WithEvents MN_CANTIDAD As MisControles.Controles.MisNumeros
    Friend WithEvents E_IMPORTE As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MCHB_2 As MisControles.Controles.MisCheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
