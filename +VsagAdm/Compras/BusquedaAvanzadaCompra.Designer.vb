<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaAvanzadaCompra
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.MCHB_SERIE = New MisControles.Controles.MisCheckBox()
        Me.MT_SERIE = New MisControles.Controles.MisTextos()
        Me.MT_DOCUMENTO = New MisControles.Controles.MisTextos()
        Me.MCHB_ESTATUS = New MisControles.Controles.MisCheckBox()
        Me.MCB_ESTATUS = New MisControles.Controles.MisComboBox()
        Me.MCHB_DOCUMENTO = New MisControles.Controles.MisCheckBox()
        Me.MCHB_TIPO = New MisControles.Controles.MisCheckBox()
        Me.MCHB_GRUPO = New MisControles.Controles.MisCheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MCB_TIPO = New MisControles.Controles.MisComboBox()
        Me.MCB_GRUPO = New MisControles.Controles.MisComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BT_PROCESAR = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.Panel1.Size = New System.Drawing.Size(482, 272)
        Me.Panel1.TabIndex = 1
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.74627!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.25373!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(480, 217)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel4
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.MCHB_SERIE)
        Me.Panel4.Controls.Add(Me.MT_SERIE)
        Me.Panel4.Controls.Add(Me.MT_DOCUMENTO)
        Me.Panel4.Controls.Add(Me.MCHB_ESTATUS)
        Me.Panel4.Controls.Add(Me.MCB_ESTATUS)
        Me.Panel4.Controls.Add(Me.MCHB_DOCUMENTO)
        Me.Panel4.Controls.Add(Me.MCHB_TIPO)
        Me.Panel4.Controls.Add(Me.MCHB_GRUPO)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.MCB_TIPO)
        Me.Panel4.Controls.Add(Me.MCB_GRUPO)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(474, 158)
        Me.Panel4.TabIndex = 0
        '
        'MCHB_SERIE
        '
        Me.MCHB_SERIE.AutoSize = True
        Me.MCHB_SERIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_SERIE.Location = New System.Drawing.Point(27, 126)
        Me.MCHB_SERIE.Name = "MCHB_SERIE"
        Me.MCHB_SERIE.Size = New System.Drawing.Size(155, 20)
        Me.MCHB_SERIE.TabIndex = 9
        Me.MCHB_SERIE.Text = "Por Serie Documento"
        Me.MCHB_SERIE.UseVisualStyleBackColor = True
        '
        'MT_SERIE
        '
        Me.MT_SERIE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_SERIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_SERIE.ForeColor = System.Drawing.Color.Black
        Me.MT_SERIE.Location = New System.Drawing.Point(218, 126)
        Me.MT_SERIE.MaxLength = 10
        Me.MT_SERIE.Name = "MT_SERIE"
        Me.MT_SERIE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_SERIE.p_IniciarComo = True
        Me.MT_SERIE.Size = New System.Drawing.Size(249, 24)
        Me.MT_SERIE.TabIndex = 8
        '
        'MT_DOCUMENTO
        '
        Me.MT_DOCUMENTO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_DOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_DOCUMENTO.ForeColor = System.Drawing.Color.Black
        Me.MT_DOCUMENTO.Location = New System.Drawing.Point(218, 75)
        Me.MT_DOCUMENTO.MaxLength = 20
        Me.MT_DOCUMENTO.Name = "MT_DOCUMENTO"
        Me.MT_DOCUMENTO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_DOCUMENTO.p_IniciarComo = True
        Me.MT_DOCUMENTO.Size = New System.Drawing.Size(249, 24)
        Me.MT_DOCUMENTO.TabIndex = 5
        '
        'MCHB_ESTATUS
        '
        Me.MCHB_ESTATUS.AutoSize = True
        Me.MCHB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ESTATUS.Location = New System.Drawing.Point(27, 101)
        Me.MCHB_ESTATUS.Name = "MCHB_ESTATUS"
        Me.MCHB_ESTATUS.Size = New System.Drawing.Size(95, 20)
        Me.MCHB_ESTATUS.TabIndex = 6
        Me.MCHB_ESTATUS.Text = "Por Estatus"
        Me.MCHB_ESTATUS.UseVisualStyleBackColor = True
        '
        'MCB_ESTATUS
        '
        Me.MCB_ESTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTATUS.FormattingEnabled = True
        Me.MCB_ESTATUS.Location = New System.Drawing.Point(218, 101)
        Me.MCB_ESTATUS.Name = "MCB_ESTATUS"
        Me.MCB_ESTATUS.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ESTATUS.TabIndex = 7
        '
        'MCHB_DOCUMENTO
        '
        Me.MCHB_DOCUMENTO.AutoSize = True
        Me.MCHB_DOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_DOCUMENTO.Location = New System.Drawing.Point(27, 75)
        Me.MCHB_DOCUMENTO.Name = "MCHB_DOCUMENTO"
        Me.MCHB_DOCUMENTO.Size = New System.Drawing.Size(171, 20)
        Me.MCHB_DOCUMENTO.TabIndex = 4
        Me.MCHB_DOCUMENTO.Text = "Por Numero Documento"
        Me.MCHB_DOCUMENTO.UseVisualStyleBackColor = True
        '
        'MCHB_TIPO
        '
        Me.MCHB_TIPO.AutoSize = True
        Me.MCHB_TIPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_TIPO.Location = New System.Drawing.Point(27, 49)
        Me.MCHB_TIPO.Name = "MCHB_TIPO"
        Me.MCHB_TIPO.Size = New System.Drawing.Size(182, 20)
        Me.MCHB_TIPO.TabIndex = 2
        Me.MCHB_TIPO.Text = "Por Tipo De Proveedores"
        Me.MCHB_TIPO.UseVisualStyleBackColor = True
        '
        'MCHB_GRUPO
        '
        Me.MCHB_GRUPO.AutoSize = True
        Me.MCHB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_GRUPO.Location = New System.Drawing.Point(27, 24)
        Me.MCHB_GRUPO.Name = "MCHB_GRUPO"
        Me.MCHB_GRUPO.Size = New System.Drawing.Size(190, 20)
        Me.MCHB_GRUPO.TabIndex = 0
        Me.MCHB_GRUPO.Text = "Por Grupos De Provedores"
        Me.MCHB_GRUPO.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 0
        '
        'MCB_TIPO
        '
        Me.MCB_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_TIPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_TIPO.FormattingEnabled = True
        Me.MCB_TIPO.Location = New System.Drawing.Point(218, 49)
        Me.MCB_TIPO.Name = "MCB_TIPO"
        Me.MCB_TIPO.Size = New System.Drawing.Size(249, 24)
        Me.MCB_TIPO.TabIndex = 3
        '
        'MCB_GRUPO
        '
        Me.MCB_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_GRUPO.FormattingEnabled = True
        Me.MCB_GRUPO.Location = New System.Drawing.Point(218, 24)
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
        Me.Panel5.Location = New System.Drawing.Point(3, 167)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(474, 47)
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
        Me.BT_PROCESAR.Location = New System.Drawing.Point(354, 6)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(112, 36)
        Me.BT_PROCESAR.TabIndex = 0
        Me.BT_PROCESAR.Text = "&Procesar"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 248)
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
        'BusquedaAvanzadaCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(488, 278)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(504, 317)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(504, 317)
        Me.Name = "BusquedaAvanzadaCompra"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documentos De Compras"
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
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents MT_DOCUMENTO As MisControles.Controles.MisTextos
    Friend WithEvents MCHB_ESTATUS As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_ESTATUS As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_DOCUMENTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_TIPO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_GRUPO As MisControles.Controles.MisCheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MCB_TIPO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_GRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MCHB_SERIE As MisControles.Controles.MisCheckBox
    Friend WithEvents MT_SERIE As MisControles.Controles.MisTextos
End Class