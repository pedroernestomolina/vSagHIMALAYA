<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarNC_Compras
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
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.MT_DETALLE = New MisControles.Controles.MisTextos
        Me.BT_GRABAR = New System.Windows.Forms.Button
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.E_IMPORTE = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.MN_DESCUENTO3 = New MisControles.Controles.MisNumeros
        Me.Label8 = New System.Windows.Forms.Label
        Me.MN_DESCUENTO2 = New MisControles.Controles.MisNumeros
        Me.Label2 = New System.Windows.Forms.Label
        Me.MN_DESCUENTO1 = New MisControles.Controles.MisNumeros
        Me.MN_COSTO = New MisControles.Controles.MisNumeros
        Me.MN_CANTIDAD = New MisControles.Controles.MisNumeros
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.E_PSUGERIDO = New System.Windows.Forms.Label
        Me.E_IVA = New System.Windows.Forms.Label
        Me.E_EMPAQUE_CONTENIDO = New System.Windows.Forms.Label
        Me.E_EMPAQUE_NOMBRE = New System.Windows.Forms.Label
        Me.E_CODIGO = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.E_NOMBRE = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(644, 375)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42038!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.57962!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(644, 353)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.MT_DETALLE)
        Me.Panel6.Controls.Add(Me.BT_GRABAR)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 302)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(638, 48)
        Me.Panel6.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 16)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Motivo:"
        '
        'MT_DETALLE
        '
        Me.MT_DETALLE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_DETALLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_DETALLE.ForeColor = System.Drawing.Color.Black
        Me.MT_DETALLE.Location = New System.Drawing.Point(65, 9)
        Me.MT_DETALLE.MaxLength = 60
        Me.MT_DETALLE.Name = "MT_DETALLE"
        Me.MT_DETALLE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_DETALLE.p_IniciarComo = True
        Me.MT_DETALLE.Size = New System.Drawing.Size(365, 24)
        Me.MT_DETALLE.TabIndex = 0
        '
        'BT_GRABAR
        '
        Me.BT_GRABAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GRABAR.Location = New System.Drawing.Point(491, 3)
        Me.BT_GRABAR.Name = "BT_GRABAR"
        Me.BT_GRABAR.Size = New System.Drawing.Size(92, 38)
        Me.BT_GRABAR.TabIndex = 1
        Me.BT_GRABAR.Text = "&Grabar"
        Me.BT_GRABAR.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.E_IMPORTE)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.MN_DESCUENTO3)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.MN_DESCUENTO2)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.MN_DESCUENTO1)
        Me.Panel5.Controls.Add(Me.MN_COSTO)
        Me.Panel5.Controls.Add(Me.MN_CANTIDAD)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.E_PSUGERIDO)
        Me.Panel5.Controls.Add(Me.E_IVA)
        Me.Panel5.Controls.Add(Me.E_EMPAQUE_CONTENIDO)
        Me.Panel5.Controls.Add(Me.E_EMPAQUE_NOMBRE)
        Me.Panel5.Controls.Add(Me.E_CODIGO)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.E_NOMBRE)
        Me.Panel5.Controls.Add(Me.ShapeContainer1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 40)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel5.Size = New System.Drawing.Size(638, 256)
        Me.Panel5.TabIndex = 2
        '
        'E_IMPORTE
        '
        Me.E_IMPORTE.BackColor = System.Drawing.Color.SteelBlue
        Me.E_IMPORTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_IMPORTE.Location = New System.Drawing.Point(501, 219)
        Me.E_IMPORTE.Name = "E_IMPORTE"
        Me.E_IMPORTE.Size = New System.Drawing.Size(126, 24)
        Me.E_IMPORTE.TabIndex = 27
        Me.E_IMPORTE.Text = "999999.99"
        Me.E_IMPORTE.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(419, 221)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 20)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "Importe:"
        '
        'MN_DESCUENTO3
        '
        Me.MN_DESCUENTO3._ConSigno = False
        Me.MN_DESCUENTO3._Formato = ""
        Me.MN_DESCUENTO3.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_DESCUENTO3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_DESCUENTO3.ForeColor = System.Drawing.Color.Black
        Me.MN_DESCUENTO3.Location = New System.Drawing.Point(398, 176)
        Me.MN_DESCUENTO3.Name = "MN_DESCUENTO3"
        Me.MN_DESCUENTO3.Size = New System.Drawing.Size(126, 24)
        Me.MN_DESCUENTO3.TabIndex = 24
        Me.MN_DESCUENTO3.Text = "0"
        Me.MN_DESCUENTO3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(287, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 16)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Descuento 3 (%):"
        '
        'MN_DESCUENTO2
        '
        Me.MN_DESCUENTO2._ConSigno = False
        Me.MN_DESCUENTO2._Formato = ""
        Me.MN_DESCUENTO2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_DESCUENTO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_DESCUENTO2.ForeColor = System.Drawing.Color.Black
        Me.MN_DESCUENTO2.Location = New System.Drawing.Point(398, 146)
        Me.MN_DESCUENTO2.Name = "MN_DESCUENTO2"
        Me.MN_DESCUENTO2.Size = New System.Drawing.Size(126, 24)
        Me.MN_DESCUENTO2.TabIndex = 22
        Me.MN_DESCUENTO2.Text = "0"
        Me.MN_DESCUENTO2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(287, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 16)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Descuento 2 (%):"
        '
        'MN_DESCUENTO1
        '
        Me.MN_DESCUENTO1._ConSigno = False
        Me.MN_DESCUENTO1._Formato = ""
        Me.MN_DESCUENTO1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_DESCUENTO1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_DESCUENTO1.ForeColor = System.Drawing.Color.Black
        Me.MN_DESCUENTO1.Location = New System.Drawing.Point(398, 116)
        Me.MN_DESCUENTO1.Name = "MN_DESCUENTO1"
        Me.MN_DESCUENTO1.Size = New System.Drawing.Size(126, 24)
        Me.MN_DESCUENTO1.TabIndex = 2
        Me.MN_DESCUENTO1.Text = "0"
        Me.MN_DESCUENTO1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_COSTO
        '
        Me.MN_COSTO._ConSigno = False
        Me.MN_COSTO._Formato = ""
        Me.MN_COSTO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_COSTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_COSTO.ForeColor = System.Drawing.Color.Black
        Me.MN_COSTO.Location = New System.Drawing.Point(398, 86)
        Me.MN_COSTO.Name = "MN_COSTO"
        Me.MN_COSTO.Size = New System.Drawing.Size(126, 24)
        Me.MN_COSTO.TabIndex = 1
        Me.MN_COSTO.Text = "0"
        Me.MN_COSTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_CANTIDAD
        '
        Me.MN_CANTIDAD._ConSigno = False
        Me.MN_CANTIDAD._Formato = ""
        Me.MN_CANTIDAD.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_CANTIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_CANTIDAD.ForeColor = System.Drawing.Color.Black
        Me.MN_CANTIDAD.Location = New System.Drawing.Point(398, 56)
        Me.MN_CANTIDAD.Name = "MN_CANTIDAD"
        Me.MN_CANTIDAD.Size = New System.Drawing.Size(126, 24)
        Me.MN_CANTIDAD.TabIndex = 0
        Me.MN_CANTIDAD.Text = "0"
        Me.MN_CANTIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(287, 121)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 16)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Descuento 1 (%):"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(346, 91)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 16)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Costo:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(331, 61)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 16)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Cantidad:"
        '
        'E_PSUGERIDO
        '
        Me.E_PSUGERIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_PSUGERIDO.Location = New System.Drawing.Point(94, 160)
        Me.E_PSUGERIDO.Name = "E_PSUGERIDO"
        Me.E_PSUGERIDO.Size = New System.Drawing.Size(67, 15)
        Me.E_PSUGERIDO.TabIndex = 11
        Me.E_PSUGERIDO.Text = "99999.99"
        Me.E_PSUGERIDO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_IVA
        '
        Me.E_IVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_IVA.Location = New System.Drawing.Point(94, 136)
        Me.E_IVA.Name = "E_IVA"
        Me.E_IVA.Size = New System.Drawing.Size(67, 15)
        Me.E_IVA.TabIndex = 10
        Me.E_IVA.Text = "99.99"
        Me.E_IVA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_EMPAQUE_CONTENIDO
        '
        Me.E_EMPAQUE_CONTENIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_EMPAQUE_CONTENIDO.Location = New System.Drawing.Point(94, 112)
        Me.E_EMPAQUE_CONTENIDO.Name = "E_EMPAQUE_CONTENIDO"
        Me.E_EMPAQUE_CONTENIDO.Size = New System.Drawing.Size(67, 15)
        Me.E_EMPAQUE_CONTENIDO.TabIndex = 9
        Me.E_EMPAQUE_CONTENIDO.Text = "99999"
        Me.E_EMPAQUE_CONTENIDO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_EMPAQUE_NOMBRE
        '
        Me.E_EMPAQUE_NOMBRE.AutoSize = True
        Me.E_EMPAQUE_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_EMPAQUE_NOMBRE.Location = New System.Drawing.Point(94, 88)
        Me.E_EMPAQUE_NOMBRE.Name = "E_EMPAQUE_NOMBRE"
        Me.E_EMPAQUE_NOMBRE.Size = New System.Drawing.Size(127, 15)
        Me.E_EMPAQUE_NOMBRE.TabIndex = 8
        Me.E_EMPAQUE_NOMBRE.Text = "LARGO DE 15 CAR"
        '
        'E_CODIGO
        '
        Me.E_CODIGO.AutoSize = True
        Me.E_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_CODIGO.Location = New System.Drawing.Point(94, 68)
        Me.E_CODIGO.Name = "E_CODIGO"
        Me.E_CODIGO.Size = New System.Drawing.Size(127, 15)
        Me.E_CODIGO.TabIndex = 7
        Me.E_CODIGO.Text = "LARGO DE 15 CAR"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "P/Suegrido:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(39, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Iva(%):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Contenido:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Empaque:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Codigo:"
        '
        'E_NOMBRE
        '
        Me.E_NOMBRE.BackColor = System.Drawing.Color.WhiteSmoke
        Me.E_NOMBRE.Dock = System.Windows.Forms.DockStyle.Top
        Me.E_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_NOMBRE.Location = New System.Drawing.Point(1, 1)
        Me.E_NOMBRE.Name = "E_NOMBRE"
        Me.E_NOMBRE.Size = New System.Drawing.Size(636, 38)
        Me.E_NOMBRE.TabIndex = 0
        Me.E_NOMBRE.Text = "Identificacion " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Del Producto"
        Me.E_NOMBRE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(1, 1)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(636, 254)
        Me.ShapeContainer1.TabIndex = 13
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 255
        Me.LineShape1.X2 = 255
        Me.LineShape1.Y1 = 44
        Me.LineShape1.Y2 = 245
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(638, 31)
        Me.Panel3.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(638, 1)
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 353)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(644, 22)
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
        'ModificarNC_Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(648, 379)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(664, 417)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(664, 417)
        Me.Name = "ModificarNC_Compras"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents MN_DESCUENTO1 As MisControles.Controles.MisNumeros
    Friend WithEvents MN_COSTO As MisControles.Controles.MisNumeros
    Friend WithEvents MN_CANTIDAD As MisControles.Controles.MisNumeros
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents E_PSUGERIDO As System.Windows.Forms.Label
    Friend WithEvents E_IVA As System.Windows.Forms.Label
    Friend WithEvents E_EMPAQUE_CONTENIDO As System.Windows.Forms.Label
    Friend WithEvents E_EMPAQUE_NOMBRE As System.Windows.Forms.Label
    Friend WithEvents E_CODIGO As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents E_NOMBRE As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents E_IMPORTE As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents MN_DESCUENTO3 As MisControles.Controles.MisNumeros
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MN_DESCUENTO2 As MisControles.Controles.MisNumeros
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MT_DETALLE As MisControles.Controles.MisTextos
    Friend WithEvents BT_GRABAR As System.Windows.Forms.Button
End Class
