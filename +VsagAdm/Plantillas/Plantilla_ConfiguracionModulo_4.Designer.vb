<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Plantilla_ConfiguracionModulo_4
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
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.CB_AYUDA = New System.Windows.Forms.ComboBox
        Me.LL_1 = New System.Windows.Forms.LinkLabel
        Me.TB_1 = New MisControles.Controles.MisTextos
        Me.BT_1 = New System.Windows.Forms.Button
        Me.LB_2 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(550, 198)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.47651!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.52349!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(548, 174)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.LB_1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(542, 31)
        Me.Panel2.TabIndex = 0
        '
        'LB_1
        '
        Me.LB_1.AutoSize = True
        Me.LB_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_1.ForeColor = System.Drawing.Color.White
        Me.LB_1.Location = New System.Drawing.Point(3, 3)
        Me.LB_1.Name = "LB_1"
        Me.LB_1.Size = New System.Drawing.Size(146, 16)
        Me.LB_1.TabIndex = 0
        Me.LB_1.Text = "Opcion A Configurar"
        '
        'Panel3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel3, 2)
        Me.Panel3.Controls.Add(Me.CB_AYUDA)
        Me.Panel3.Controls.Add(Me.LL_1)
        Me.Panel3.Controls.Add(Me.TB_1)
        Me.Panel3.Controls.Add(Me.BT_1)
        Me.Panel3.Controls.Add(Me.LB_2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4)
        Me.Panel3.Size = New System.Drawing.Size(542, 131)
        Me.Panel3.TabIndex = 1
        '
        'CB_AYUDA
        '
        Me.CB_AYUDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_AYUDA.DropDownWidth = 280
        Me.CB_AYUDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_AYUDA.FormattingEnabled = True
        Me.CB_AYUDA.Items.AddRange(New Object() {"@CODIGO_PRODUCTO", "@NOMBRE_EMPAQUE_PRODUCTO", "@CONTENIDO_EMPAQUE_PRODUCTO", "@PRECIO_SUGERIDO_PRODUCTO", "@PRECIO_LIQUIDA_PRODUCTO"})
        Me.CB_AYUDA.Location = New System.Drawing.Point(281, 7)
        Me.CB_AYUDA.Name = "CB_AYUDA"
        Me.CB_AYUDA.Size = New System.Drawing.Size(252, 24)
        Me.CB_AYUDA.TabIndex = 5
        Me.CB_AYUDA.Visible = False
        '
        'LL_1
        '
        Me.LL_1.AutoSize = True
        Me.LL_1.Enabled = False
        Me.LL_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LL_1.Location = New System.Drawing.Point(454, 10)
        Me.LL_1.Name = "LL_1"
        Me.LL_1.Size = New System.Drawing.Size(79, 16)
        Me.LL_1.TabIndex = 4
        Me.LL_1.TabStop = True
        Me.LL_1.Text = "Indicar Ruta"
        Me.LL_1.Visible = False
        '
        'TB_1
        '
        Me.TB_1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.TB_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_1.ForeColor = System.Drawing.Color.Black
        Me.TB_1.Location = New System.Drawing.Point(30, 34)
        Me.TB_1.MaxLength = 20
        Me.TB_1.Multiline = True
        Me.TB_1.Name = "TB_1"
        Me.TB_1.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.TB_1.p_IniciarComo = True
        Me.TB_1.Size = New System.Drawing.Size(503, 41)
        Me.TB_1.TabIndex = 3
        '
        'BT_1
        '
        Me.BT_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_1.Location = New System.Drawing.Point(413, 81)
        Me.BT_1.Name = "BT_1"
        Me.BT_1.Size = New System.Drawing.Size(120, 43)
        Me.BT_1.TabIndex = 2
        Me.BT_1.Text = "Procesar / &Guardar"
        Me.BT_1.UseVisualStyleBackColor = True
        '
        'LB_2
        '
        Me.LB_2.AutoSize = True
        Me.LB_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_2.Location = New System.Drawing.Point(7, 7)
        Me.LB_2.Name = "LB_2"
        Me.LB_2.Size = New System.Drawing.Size(40, 20)
        Me.LB_2.TabIndex = 1
        Me.LB_2.Text = "XX1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 174)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(548, 22)
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
        'Plantilla_ConfiguracionModulo_4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(554, 202)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(570, 240)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(570, 240)
        Me.Name = "Plantilla_ConfiguracionModulo_4"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modulo Configurar"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LB_1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LB_2 As System.Windows.Forms.Label
    Friend WithEvents BT_1 As System.Windows.Forms.Button
    Friend WithEvents TB_1 As MisControles.Controles.MisTextos
    Friend WithEvents LL_1 As System.Windows.Forms.LinkLabel
    Friend WithEvents CB_AYUDA As System.Windows.Forms.ComboBox
End Class
