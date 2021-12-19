<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcesarDoc_NC
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
        Me.E_IMPUESTO = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.E_SUB_2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.E_TOTAL = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.E_SUB_1 = New System.Windows.Forms.Label
        Me.MN_CARGO2 = New MisControles.Controles.MisNumeros
        Me.MN_DSC2 = New MisControles.Controles.MisNumeros
        Me.MN_CARGO1 = New MisControles.Controles.MisNumeros
        Me.MN_DSC1 = New MisControles.Controles.MisNumeros
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.E_TOTAL_MOVIMIENTO = New System.Windows.Forms.Label
        Me.E_TITULO_2 = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.MT_NOTAS = New MisControles.Controles.MisTextos
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.E_TITULO_1 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(423, 422)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(421, 372)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel3, 2)
        Me.Panel3.Controls.Add(Me.E_IMPUESTO)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.E_SUB_2)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.E_TOTAL)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.E_SUB_1)
        Me.Panel3.Controls.Add(Me.MN_CARGO2)
        Me.Panel3.Controls.Add(Me.MN_DSC2)
        Me.Panel3.Controls.Add(Me.MN_CARGO1)
        Me.Panel3.Controls.Add(Me.MN_DSC1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.ShapeContainer1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(415, 140)
        Me.Panel3.TabIndex = 0
        '
        'E_IMPUESTO
        '
        Me.E_IMPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_IMPUESTO.Location = New System.Drawing.Point(116, 116)
        Me.E_IMPUESTO.Name = "E_IMPUESTO"
        Me.E_IMPUESTO.Size = New System.Drawing.Size(125, 20)
        Me.E_IMPUESTO.TabIndex = 14
        Me.E_IMPUESTO.Text = "99999999.99"
        Me.E_IMPUESTO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(44, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 16)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Impuesto:"
        '
        'E_SUB_2
        '
        Me.E_SUB_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_SUB_2.Location = New System.Drawing.Point(116, 92)
        Me.E_SUB_2.Name = "E_SUB_2"
        Me.E_SUB_2.Size = New System.Drawing.Size(125, 20)
        Me.E_SUB_2.TabIndex = 12
        Me.E_SUB_2.Text = "99999999.99"
        Me.E_SUB_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(41, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 16)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "SubTotal :"
        '
        'E_TOTAL
        '
        Me.E_TOTAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_TOTAL.ForeColor = System.Drawing.Color.MidnightBlue
        Me.E_TOTAL.Location = New System.Drawing.Point(247, 112)
        Me.E_TOTAL.Name = "E_TOTAL"
        Me.E_TOTAL.Size = New System.Drawing.Size(155, 25)
        Me.E_TOTAL.TabIndex = 9
        Me.E_TOTAL.Text = "99999999.99"
        Me.E_TOTAL.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(279, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 18)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Total General:"
        '
        'E_SUB_1
        '
        Me.E_SUB_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_SUB_1.Location = New System.Drawing.Point(116, 8)
        Me.E_SUB_1.Name = "E_SUB_1"
        Me.E_SUB_1.Size = New System.Drawing.Size(125, 20)
        Me.E_SUB_1.TabIndex = 7
        Me.E_SUB_1.Text = "99999999.99"
        Me.E_SUB_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MN_CARGO2
        '
        Me.MN_CARGO2._ConSigno = False
        Me.MN_CARGO2._Formato = ""
        Me.MN_CARGO2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_CARGO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_CARGO2.ForeColor = System.Drawing.Color.Black
        Me.MN_CARGO2.Location = New System.Drawing.Point(180, 56)
        Me.MN_CARGO2.Name = "MN_CARGO2"
        Me.MN_CARGO2.Size = New System.Drawing.Size(80, 24)
        Me.MN_CARGO2.TabIndex = 3
        Me.MN_CARGO2.Text = "0"
        Me.MN_CARGO2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_DSC2
        '
        Me.MN_DSC2._ConSigno = False
        Me.MN_DSC2._Formato = ""
        Me.MN_DSC2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_DSC2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_DSC2.ForeColor = System.Drawing.Color.Black
        Me.MN_DSC2.Location = New System.Drawing.Point(180, 31)
        Me.MN_DSC2.Name = "MN_DSC2"
        Me.MN_DSC2.Size = New System.Drawing.Size(80, 24)
        Me.MN_DSC2.TabIndex = 1
        Me.MN_DSC2.Text = "99999.99"
        Me.MN_DSC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_CARGO1
        '
        Me.MN_CARGO1._ConSigno = False
        Me.MN_CARGO1._Formato = ""
        Me.MN_CARGO1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_CARGO1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_CARGO1.ForeColor = System.Drawing.Color.Black
        Me.MN_CARGO1.Location = New System.Drawing.Point(116, 56)
        Me.MN_CARGO1.Name = "MN_CARGO1"
        Me.MN_CARGO1.Size = New System.Drawing.Size(62, 24)
        Me.MN_CARGO1.TabIndex = 2
        Me.MN_CARGO1.Text = "0"
        Me.MN_CARGO1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_DSC1
        '
        Me.MN_DSC1._ConSigno = False
        Me.MN_DSC1._Formato = ""
        Me.MN_DSC1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_DSC1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_DSC1.ForeColor = System.Drawing.Color.Black
        Me.MN_DSC1.Location = New System.Drawing.Point(116, 31)
        Me.MN_DSC1.Name = "MN_DSC1"
        Me.MN_DSC1.Size = New System.Drawing.Size(62, 24)
        Me.MN_DSC1.TabIndex = 0
        Me.MN_DSC1.Text = "99.99"
        Me.MN_DSC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(42, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Cargo(%):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Descuento(%):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SubTotal :"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(415, 140)
        Me.ShapeContainer1.TabIndex = 10
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 3
        Me.LineShape1.X2 = 410
        Me.LineShape1.Y1 = 82
        Me.LineShape1.Y2 = 82
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 4)
        Me.Panel4.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 149)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(415, 174)
        Me.Panel4.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel7, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel6, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.09303!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.90698!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(413, 172)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel7
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel7, 2)
        Me.Panel7.Controls.Add(Me.E_TOTAL_MOVIMIENTO)
        Me.Panel7.Controls.Add(Me.E_TITULO_2)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 126)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(407, 43)
        Me.Panel7.TabIndex = 1
        '
        'E_TOTAL_MOVIMIENTO
        '
        Me.E_TOTAL_MOVIMIENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_TOTAL_MOVIMIENTO.ForeColor = System.Drawing.Color.Maroon
        Me.E_TOTAL_MOVIMIENTO.Location = New System.Drawing.Point(226, 10)
        Me.E_TOTAL_MOVIMIENTO.Name = "E_TOTAL_MOVIMIENTO"
        Me.E_TOTAL_MOVIMIENTO.Size = New System.Drawing.Size(172, 29)
        Me.E_TOTAL_MOVIMIENTO.TabIndex = 13
        Me.E_TOTAL_MOVIMIENTO.Text = "99999999.99"
        Me.E_TOTAL_MOVIMIENTO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_TITULO_2
        '
        Me.E_TITULO_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_TITULO_2.Location = New System.Drawing.Point(3, 18)
        Me.E_TITULO_2.Name = "E_TITULO_2"
        Me.E_TITULO_2.Size = New System.Drawing.Size(217, 18)
        Me.E_TITULO_2.TabIndex = 0
        Me.E_TITULO_2.Text = "Monto Total Nota Credito:"
        Me.E_TITULO_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel6
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel6, 2)
        Me.Panel6.Controls.Add(Me.MT_NOTAS)
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(407, 117)
        Me.Panel6.TabIndex = 2
        '
        'MT_NOTAS
        '
        Me.MT_NOTAS.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_NOTAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_NOTAS.ForeColor = System.Drawing.Color.Black
        Me.MT_NOTAS.Location = New System.Drawing.Point(13, 35)
        Me.MT_NOTAS.MaxLength = 20
        Me.MT_NOTAS.Multiline = True
        Me.MT_NOTAS.Name = "MT_NOTAS"
        Me.MT_NOTAS.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_NOTAS.p_IniciarComo = True
        Me.MT_NOTAS.Size = New System.Drawing.Size(385, 73)
        Me.MT_NOTAS.TabIndex = 1
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.LightGray
        Me.Panel8.Controls.Add(Me.Label5)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(407, 23)
        Me.Panel8.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(210, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Notas/Observaciones/Motivo"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel5, 2)
        Me.Panel5.Controls.Add(Me.BT_PROCESAR)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 329)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(415, 40)
        Me.Panel5.TabIndex = 2
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.Location = New System.Drawing.Point(275, 3)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(127, 34)
        Me.BT_PROCESAR.TabIndex = 0
        Me.BT_PROCESAR.Text = "&Procesar"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Maroon
        Me.Panel2.Controls.Add(Me.E_TITULO_1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(421, 26)
        Me.Panel2.TabIndex = 1
        '
        'E_TITULO_1
        '
        Me.E_TITULO_1.AutoSize = True
        Me.E_TITULO_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_TITULO_1.ForeColor = System.Drawing.Color.White
        Me.E_TITULO_1.Location = New System.Drawing.Point(3, 3)
        Me.E_TITULO_1.Name = "E_TITULO_1"
        Me.E_TITULO_1.Size = New System.Drawing.Size(139, 18)
        Me.E_TITULO_1.TabIndex = 0
        Me.E_TITULO_1.Text = "Detalle Del Pago "
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 398)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(421, 22)
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
        'ProcesarDoc_NC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(427, 426)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(443, 464)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(443, 464)
        Me.Name = "ProcesarDoc_NC"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel5.ResumeLayout(False)
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
    Friend WithEvents E_TITULO_1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MN_CARGO2 As MisControles.Controles.MisNumeros
    Friend WithEvents MN_DSC2 As MisControles.Controles.MisNumeros
    Friend WithEvents MN_CARGO1 As MisControles.Controles.MisNumeros
    Friend WithEvents MN_DSC1 As MisControles.Controles.MisNumeros
    Friend WithEvents E_SUB_1 As System.Windows.Forms.Label
    Friend WithEvents E_TOTAL As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents E_IMPUESTO As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents E_SUB_2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents E_TOTAL_MOVIMIENTO As System.Windows.Forms.Label
    Friend WithEvents E_TITULO_2 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents MT_NOTAS As MisControles.Controles.MisTextos
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class