<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaAvanzadaVenta
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
        Me.MT_DOCUMENTO = New MisControles.Controles.MisTextos
        Me.MCHB_ESTATUS = New MisControles.Controles.MisCheckBox
        Me.MCB_ESTATUS = New MisControles.Controles.MisComboBox
        Me.MCHB_DOCUMENTO = New MisControles.Controles.MisCheckBox
        Me.MCHB_SERIE = New MisControles.Controles.MisCheckBox
        Me.MCHB_VENDEDOR = New MisControles.Controles.MisCheckBox
        Me.MCHB_ZONA = New MisControles.Controles.MisCheckBox
        Me.MCHB_ESTADO = New MisControles.Controles.MisCheckBox
        Me.MCHB_GRUPO = New MisControles.Controles.MisCheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MCB_SERIE = New MisControles.Controles.MisComboBox
        Me.MCB_VENDEDOR = New MisControles.Controles.MisComboBox
        Me.MCB_ZONA = New MisControles.Controles.MisComboBox
        Me.MCB_ESTADO = New MisControles.Controles.MisComboBox
        Me.MCB_GRUPO = New MisControles.Controles.MisComboBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(482, 369)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 31)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.6526!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.34739!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(480, 314)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel4
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.MT_DOCUMENTO)
        Me.Panel4.Controls.Add(Me.MCHB_ESTATUS)
        Me.Panel4.Controls.Add(Me.MCB_ESTATUS)
        Me.Panel4.Controls.Add(Me.MCHB_DOCUMENTO)
        Me.Panel4.Controls.Add(Me.MCHB_SERIE)
        Me.Panel4.Controls.Add(Me.MCHB_VENDEDOR)
        Me.Panel4.Controls.Add(Me.MCHB_ZONA)
        Me.Panel4.Controls.Add(Me.MCHB_ESTADO)
        Me.Panel4.Controls.Add(Me.MCHB_GRUPO)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.MCB_SERIE)
        Me.Panel4.Controls.Add(Me.MCB_VENDEDOR)
        Me.Panel4.Controls.Add(Me.MCB_ZONA)
        Me.Panel4.Controls.Add(Me.MCB_ESTADO)
        Me.Panel4.Controls.Add(Me.MCB_GRUPO)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(474, 244)
        Me.Panel4.TabIndex = 0
        '
        'MT_DOCUMENTO
        '
        Me.MT_DOCUMENTO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_DOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_DOCUMENTO.ForeColor = System.Drawing.Color.Black
        Me.MT_DOCUMENTO.Location = New System.Drawing.Point(198, 162)
        Me.MT_DOCUMENTO.MaxLength = 20
        Me.MT_DOCUMENTO.Name = "MT_DOCUMENTO"
        Me.MT_DOCUMENTO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_DOCUMENTO.p_IniciarComo = True
        Me.MT_DOCUMENTO.Size = New System.Drawing.Size(249, 24)
        Me.MT_DOCUMENTO.TabIndex = 11
        '
        'MCHB_ESTATUS
        '
        Me.MCHB_ESTATUS.AutoSize = True
        Me.MCHB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ESTATUS.Location = New System.Drawing.Point(27, 188)
        Me.MCHB_ESTATUS.Name = "MCHB_ESTATUS"
        Me.MCHB_ESTATUS.Size = New System.Drawing.Size(95, 20)
        Me.MCHB_ESTATUS.TabIndex = 12
        Me.MCHB_ESTATUS.Text = "Por Estatus"
        Me.MCHB_ESTATUS.UseVisualStyleBackColor = True
        '
        'MCB_ESTATUS
        '
        Me.MCB_ESTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTATUS.FormattingEnabled = True
        Me.MCB_ESTATUS.Location = New System.Drawing.Point(198, 188)
        Me.MCB_ESTATUS.Name = "MCB_ESTATUS"
        Me.MCB_ESTATUS.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ESTATUS.TabIndex = 13
        '
        'MCHB_DOCUMENTO
        '
        Me.MCHB_DOCUMENTO.AutoSize = True
        Me.MCHB_DOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_DOCUMENTO.Location = New System.Drawing.Point(27, 162)
        Me.MCHB_DOCUMENTO.Name = "MCHB_DOCUMENTO"
        Me.MCHB_DOCUMENTO.Size = New System.Drawing.Size(171, 20)
        Me.MCHB_DOCUMENTO.TabIndex = 10
        Me.MCHB_DOCUMENTO.Text = "Por Numero Documento"
        Me.MCHB_DOCUMENTO.UseVisualStyleBackColor = True
        '
        'MCHB_SERIE
        '
        Me.MCHB_SERIE.AutoSize = True
        Me.MCHB_SERIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_SERIE.Location = New System.Drawing.Point(27, 136)
        Me.MCHB_SERIE.Name = "MCHB_SERIE"
        Me.MCHB_SERIE.Size = New System.Drawing.Size(83, 20)
        Me.MCHB_SERIE.TabIndex = 8
        Me.MCHB_SERIE.Text = "Por Serie"
        Me.MCHB_SERIE.UseVisualStyleBackColor = True
        '
        'MCHB_VENDEDOR
        '
        Me.MCHB_VENDEDOR.AutoSize = True
        Me.MCHB_VENDEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_VENDEDOR.Location = New System.Drawing.Point(27, 110)
        Me.MCHB_VENDEDOR.Name = "MCHB_VENDEDOR"
        Me.MCHB_VENDEDOR.Size = New System.Drawing.Size(111, 20)
        Me.MCHB_VENDEDOR.TabIndex = 6
        Me.MCHB_VENDEDOR.Text = "Por Vendedor"
        Me.MCHB_VENDEDOR.UseVisualStyleBackColor = True
        '
        'MCHB_ZONA
        '
        Me.MCHB_ZONA.AutoSize = True
        Me.MCHB_ZONA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ZONA.Location = New System.Drawing.Point(27, 84)
        Me.MCHB_ZONA.Name = "MCHB_ZONA"
        Me.MCHB_ZONA.Size = New System.Drawing.Size(82, 20)
        Me.MCHB_ZONA.TabIndex = 4
        Me.MCHB_ZONA.Text = "Por Zona"
        Me.MCHB_ZONA.UseVisualStyleBackColor = True
        '
        'MCHB_ESTADO
        '
        Me.MCHB_ESTADO.AutoSize = True
        Me.MCHB_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ESTADO.Location = New System.Drawing.Point(27, 58)
        Me.MCHB_ESTADO.Name = "MCHB_ESTADO"
        Me.MCHB_ESTADO.Size = New System.Drawing.Size(94, 20)
        Me.MCHB_ESTADO.TabIndex = 2
        Me.MCHB_ESTADO.Text = "Por Estado"
        Me.MCHB_ESTADO.UseVisualStyleBackColor = True
        '
        'MCHB_GRUPO
        '
        Me.MCHB_GRUPO.AutoSize = True
        Me.MCHB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_GRUPO.Location = New System.Drawing.Point(27, 32)
        Me.MCHB_GRUPO.Name = "MCHB_GRUPO"
        Me.MCHB_GRUPO.Size = New System.Drawing.Size(160, 20)
        Me.MCHB_GRUPO.TabIndex = 32
        Me.MCHB_GRUPO.Text = "Por Grupos De Cliente"
        Me.MCHB_GRUPO.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 0
        '
        'MCB_SERIE
        '
        Me.MCB_SERIE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_SERIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_SERIE.FormattingEnabled = True
        Me.MCB_SERIE.Location = New System.Drawing.Point(198, 136)
        Me.MCB_SERIE.Name = "MCB_SERIE"
        Me.MCB_SERIE.Size = New System.Drawing.Size(249, 24)
        Me.MCB_SERIE.TabIndex = 9
        '
        'MCB_VENDEDOR
        '
        Me.MCB_VENDEDOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_VENDEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_VENDEDOR.FormattingEnabled = True
        Me.MCB_VENDEDOR.Location = New System.Drawing.Point(198, 110)
        Me.MCB_VENDEDOR.Name = "MCB_VENDEDOR"
        Me.MCB_VENDEDOR.Size = New System.Drawing.Size(249, 24)
        Me.MCB_VENDEDOR.TabIndex = 7
        '
        'MCB_ZONA
        '
        Me.MCB_ZONA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ZONA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ZONA.FormattingEnabled = True
        Me.MCB_ZONA.Location = New System.Drawing.Point(198, 84)
        Me.MCB_ZONA.Name = "MCB_ZONA"
        Me.MCB_ZONA.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ZONA.TabIndex = 5
        '
        'MCB_ESTADO
        '
        Me.MCB_ESTADO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTADO.FormattingEnabled = True
        Me.MCB_ESTADO.Location = New System.Drawing.Point(198, 58)
        Me.MCB_ESTADO.Name = "MCB_ESTADO"
        Me.MCB_ESTADO.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ESTADO.TabIndex = 3
        '
        'MCB_GRUPO
        '
        Me.MCB_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_GRUPO.FormattingEnabled = True
        Me.MCB_GRUPO.Location = New System.Drawing.Point(198, 32)
        Me.MCB_GRUPO.Name = "MCB_GRUPO"
        Me.MCB_GRUPO.Size = New System.Drawing.Size(249, 24)
        Me.MCB_GRUPO.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Lavender
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel5, 2)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.BT_PROCESAR)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 253)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(474, 58)
        Me.Panel5.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(243, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Indique El Tipo De Busqueda"
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.Location = New System.Drawing.Point(324, 11)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(122, 42)
        Me.BT_PROCESAR.TabIndex = 0
        Me.BT_PROCESAR.Text = "&Procesar"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 345)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(480, 22)
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
        Me.Panel2.Size = New System.Drawing.Size(480, 31)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(480, 3)
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
        'BusquedaAvanzadaVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(488, 375)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(504, 413)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(504, 413)
        Me.Name = "BusquedaAvanzadaVenta"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documentos De Ventas"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
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
    Friend WithEvents MCHB_ESTATUS As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_ESTATUS As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_DOCUMENTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_SERIE As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_VENDEDOR As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_ZONA As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_ESTADO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_GRUPO As MisControles.Controles.MisCheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MCB_SERIE As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_VENDEDOR As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ZONA As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ESTADO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_GRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
    Friend WithEvents MT_DOCUMENTO As MisControles.Controles.MisTextos
End Class