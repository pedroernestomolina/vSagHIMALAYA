<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaAvanzada_AdmCC
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
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.MT_NRODOCUMENTO = New MisControles.Controles.MisTextos
        Me.MCB_TIPODOCUMENTOS = New MisControles.Controles.MisComboBox
        Me.MCB_COBRADORES = New MisControles.Controles.MisComboBox
        Me.MCB_VENDEDORES = New MisControles.Controles.MisComboBox
        Me.MCB_ZONAS = New MisControles.Controles.MisComboBox
        Me.MCB_ESTADOS = New MisControles.Controles.MisComboBox
        Me.MCB_GRUPOS = New MisControles.Controles.MisComboBox
        Me.MC_NRODOCUMENTO = New MisControles.Controles.MisCheckBox
        Me.MC_TIPODOCUMENTOS = New MisControles.Controles.MisCheckBox
        Me.MC_COBRADORES = New MisControles.Controles.MisCheckBox
        Me.MC_VENDEDORES = New MisControles.Controles.MisCheckBox
        Me.MC_ZONAS = New MisControles.Controles.MisCheckBox
        Me.MC_ESTADOS = New MisControles.Controles.MisCheckBox
        Me.MC_GRUPOS = New MisControles.Controles.MisCheckBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MintCream
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 341)
        Me.Panel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(500, 289)
        Me.Panel4.TabIndex = 7
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.08602!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.91398!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.73702!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.26298!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(500, 289)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Honeydew
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.MT_NRODOCUMENTO)
        Me.Panel5.Controls.Add(Me.MCB_TIPODOCUMENTOS)
        Me.Panel5.Controls.Add(Me.MCB_COBRADORES)
        Me.Panel5.Controls.Add(Me.MCB_VENDEDORES)
        Me.Panel5.Controls.Add(Me.MCB_ZONAS)
        Me.Panel5.Controls.Add(Me.MCB_ESTADOS)
        Me.Panel5.Controls.Add(Me.MCB_GRUPOS)
        Me.Panel5.Controls.Add(Me.MC_NRODOCUMENTO)
        Me.Panel5.Controls.Add(Me.MC_TIPODOCUMENTOS)
        Me.Panel5.Controls.Add(Me.MC_COBRADORES)
        Me.Panel5.Controls.Add(Me.MC_VENDEDORES)
        Me.Panel5.Controls.Add(Me.MC_ZONAS)
        Me.Panel5.Controls.Add(Me.MC_ESTADOS)
        Me.Panel5.Controls.Add(Me.MC_GRUPOS)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(494, 235)
        Me.Panel5.TabIndex = 0
        '
        'MT_NRODOCUMENTO
        '
        Me.MT_NRODOCUMENTO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_NRODOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_NRODOCUMENTO.ForeColor = System.Drawing.Color.Black
        Me.MT_NRODOCUMENTO.Location = New System.Drawing.Point(214, 197)
        Me.MT_NRODOCUMENTO.MaxLength = 20
        Me.MT_NRODOCUMENTO.Name = "MT_NRODOCUMENTO"
        Me.MT_NRODOCUMENTO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_NRODOCUMENTO.p_IniciarComo = True
        Me.MT_NRODOCUMENTO.Size = New System.Drawing.Size(191, 26)
        Me.MT_NRODOCUMENTO.TabIndex = 13
        '
        'MCB_TIPODOCUMENTOS
        '
        Me.MCB_TIPODOCUMENTOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_TIPODOCUMENTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_TIPODOCUMENTOS.FormattingEnabled = True
        Me.MCB_TIPODOCUMENTOS.Location = New System.Drawing.Point(214, 167)
        Me.MCB_TIPODOCUMENTOS.Name = "MCB_TIPODOCUMENTOS"
        Me.MCB_TIPODOCUMENTOS.Size = New System.Drawing.Size(267, 26)
        Me.MCB_TIPODOCUMENTOS.TabIndex = 11
        '
        'MCB_COBRADORES
        '
        Me.MCB_COBRADORES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_COBRADORES.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_COBRADORES.FormattingEnabled = True
        Me.MCB_COBRADORES.Location = New System.Drawing.Point(214, 137)
        Me.MCB_COBRADORES.Name = "MCB_COBRADORES"
        Me.MCB_COBRADORES.Size = New System.Drawing.Size(267, 26)
        Me.MCB_COBRADORES.TabIndex = 9
        '
        'MCB_VENDEDORES
        '
        Me.MCB_VENDEDORES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_VENDEDORES.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_VENDEDORES.FormattingEnabled = True
        Me.MCB_VENDEDORES.Location = New System.Drawing.Point(214, 107)
        Me.MCB_VENDEDORES.Name = "MCB_VENDEDORES"
        Me.MCB_VENDEDORES.Size = New System.Drawing.Size(267, 26)
        Me.MCB_VENDEDORES.TabIndex = 7
        '
        'MCB_ZONAS
        '
        Me.MCB_ZONAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ZONAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ZONAS.FormattingEnabled = True
        Me.MCB_ZONAS.Location = New System.Drawing.Point(214, 77)
        Me.MCB_ZONAS.Name = "MCB_ZONAS"
        Me.MCB_ZONAS.Size = New System.Drawing.Size(267, 26)
        Me.MCB_ZONAS.TabIndex = 5
        '
        'MCB_ESTADOS
        '
        Me.MCB_ESTADOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTADOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTADOS.FormattingEnabled = True
        Me.MCB_ESTADOS.Location = New System.Drawing.Point(214, 47)
        Me.MCB_ESTADOS.Name = "MCB_ESTADOS"
        Me.MCB_ESTADOS.Size = New System.Drawing.Size(267, 26)
        Me.MCB_ESTADOS.TabIndex = 3
        '
        'MCB_GRUPOS
        '
        Me.MCB_GRUPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_GRUPOS.FormattingEnabled = True
        Me.MCB_GRUPOS.Location = New System.Drawing.Point(214, 17)
        Me.MCB_GRUPOS.Name = "MCB_GRUPOS"
        Me.MCB_GRUPOS.Size = New System.Drawing.Size(267, 26)
        Me.MCB_GRUPOS.TabIndex = 1
        '
        'MC_NRODOCUMENTO
        '
        Me.MC_NRODOCUMENTO.AutoSize = True
        Me.MC_NRODOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_NRODOCUMENTO.Location = New System.Drawing.Point(9, 197)
        Me.MC_NRODOCUMENTO.Name = "MC_NRODOCUMENTO"
        Me.MC_NRODOCUMENTO.Size = New System.Drawing.Size(197, 24)
        Me.MC_NRODOCUMENTO.TabIndex = 12
        Me.MC_NRODOCUMENTO.Text = "Por Número De Doc.:"
        Me.MC_NRODOCUMENTO.UseVisualStyleBackColor = True
        '
        'MC_TIPODOCUMENTOS
        '
        Me.MC_TIPODOCUMENTOS.AutoSize = True
        Me.MC_TIPODOCUMENTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_TIPODOCUMENTOS.Location = New System.Drawing.Point(9, 167)
        Me.MC_TIPODOCUMENTOS.Name = "MC_TIPODOCUMENTOS"
        Me.MC_TIPODOCUMENTOS.Size = New System.Drawing.Size(169, 24)
        Me.MC_TIPODOCUMENTOS.TabIndex = 10
        Me.MC_TIPODOCUMENTOS.Text = "Por Tipo De Doc.:"
        Me.MC_TIPODOCUMENTOS.UseVisualStyleBackColor = True
        '
        'MC_COBRADORES
        '
        Me.MC_COBRADORES.AutoSize = True
        Me.MC_COBRADORES.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_COBRADORES.Location = New System.Drawing.Point(9, 137)
        Me.MC_COBRADORES.Name = "MC_COBRADORES"
        Me.MC_COBRADORES.Size = New System.Drawing.Size(158, 24)
        Me.MC_COBRADORES.TabIndex = 8
        Me.MC_COBRADORES.Text = "Por Cobradores:"
        Me.MC_COBRADORES.UseVisualStyleBackColor = True
        '
        'MC_VENDEDORES
        '
        Me.MC_VENDEDORES.AutoSize = True
        Me.MC_VENDEDORES.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_VENDEDORES.Location = New System.Drawing.Point(9, 107)
        Me.MC_VENDEDORES.Name = "MC_VENDEDORES"
        Me.MC_VENDEDORES.Size = New System.Drawing.Size(162, 24)
        Me.MC_VENDEDORES.TabIndex = 6
        Me.MC_VENDEDORES.Text = "Por Vendedores:"
        Me.MC_VENDEDORES.UseVisualStyleBackColor = True
        '
        'MC_ZONAS
        '
        Me.MC_ZONAS.AutoSize = True
        Me.MC_ZONAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_ZONAS.Location = New System.Drawing.Point(9, 77)
        Me.MC_ZONAS.Name = "MC_ZONAS"
        Me.MC_ZONAS.Size = New System.Drawing.Size(115, 24)
        Me.MC_ZONAS.TabIndex = 4
        Me.MC_ZONAS.Text = "Por Zonas:"
        Me.MC_ZONAS.UseVisualStyleBackColor = True
        '
        'MC_ESTADOS
        '
        Me.MC_ESTADOS.AutoSize = True
        Me.MC_ESTADOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_ESTADOS.Location = New System.Drawing.Point(9, 47)
        Me.MC_ESTADOS.Name = "MC_ESTADOS"
        Me.MC_ESTADOS.Size = New System.Drawing.Size(131, 24)
        Me.MC_ESTADOS.TabIndex = 2
        Me.MC_ESTADOS.Text = "Por Estados:"
        Me.MC_ESTADOS.UseVisualStyleBackColor = True
        '
        'MC_GRUPOS
        '
        Me.MC_GRUPOS.AutoSize = True
        Me.MC_GRUPOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MC_GRUPOS.Location = New System.Drawing.Point(9, 17)
        Me.MC_GRUPOS.Name = "MC_GRUPOS"
        Me.MC_GRUPOS.Size = New System.Drawing.Size(124, 24)
        Me.MC_GRUPOS.TabIndex = 0
        Me.MC_GRUPOS.Text = "Por Grupos:"
        Me.MC_GRUPOS.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.BT_PROCESAR)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 244)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(494, 42)
        Me.Panel6.TabIndex = 1
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.Location = New System.Drawing.Point(347, 3)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(134, 35)
        Me.BT_PROCESAR.TabIndex = 0
        Me.BT_PROCESAR.Text = "&Procesar"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(500, 30)
        Me.Panel2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Filtrar Clientes:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 29)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(500, 1)
        Me.Panel3.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 319)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(500, 22)
        Me.StatusStrip1.TabIndex = 5
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
        'BusquedaAvanzada_AdmCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGreen
        Me.ClientSize = New System.Drawing.Size(504, 345)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(520, 383)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(520, 383)
        Me.Name = "BusquedaAvanzada_AdmCC"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda Avanzada De Clientes"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
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
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents MT_NRODOCUMENTO As MisControles.Controles.MisTextos
    Friend WithEvents MCB_TIPODOCUMENTOS As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_COBRADORES As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_VENDEDORES As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ZONAS As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ESTADOS As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_GRUPOS As MisControles.Controles.MisComboBox
    Friend WithEvents MC_NRODOCUMENTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_TIPODOCUMENTOS As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_COBRADORES As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_VENDEDORES As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_ZONAS As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_ESTADOS As MisControles.Controles.MisCheckBox
    Friend WithEvents MC_GRUPOS As MisControles.Controles.MisCheckBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
End Class
