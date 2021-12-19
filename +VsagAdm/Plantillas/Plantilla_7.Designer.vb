<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Plantilla_7
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
        Me.MCB_BUSQUEDA = New MisControles.Controles.MisComboBox
        Me.BT_BUS_AVANZ = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.BT_BUSCAR = New System.Windows.Forms.Button
        Me.Label37 = New System.Windows.Forms.Label
        Me.MT_BUSCAR = New MisControles.Controles.MisTextos
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.MCB_BUSQUEDA)
        Me.Panel1.Controls.Add(Me.BT_BUS_AVANZ)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.BT_BUSCAR)
        Me.Panel1.Controls.Add(Me.Label37)
        Me.Panel1.Controls.Add(Me.MT_BUSCAR)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(536, 115)
        Me.Panel1.TabIndex = 0
        '
        'MCB_BUSQUEDA
        '
        Me.MCB_BUSQUEDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_BUSQUEDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_BUSQUEDA.FormattingEnabled = True
        Me.MCB_BUSQUEDA.Location = New System.Drawing.Point(116, 16)
        Me.MCB_BUSQUEDA.Name = "MCB_BUSQUEDA"
        Me.MCB_BUSQUEDA.Size = New System.Drawing.Size(178, 21)
        Me.MCB_BUSQUEDA.TabIndex = 3
        '
        'BT_BUS_AVANZ
        '
        Me.BT_BUS_AVANZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_BUS_AVANZ.Location = New System.Drawing.Point(383, 21)
        Me.BT_BUS_AVANZ.Name = "BT_BUS_AVANZ"
        Me.BT_BUS_AVANZ.Size = New System.Drawing.Size(114, 50)
        Me.BT_BUS_AVANZ.TabIndex = 2
        Me.BT_BUS_AVANZ.Text = "Busqueda &Avanzada"
        Me.BT_BUS_AVANZ.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Sienna
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(15, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 15)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "F5"
        '
        'BT_BUSCAR
        '
        Me.BT_BUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_BUSCAR.Location = New System.Drawing.Point(300, 21)
        Me.BT_BUSCAR.Name = "BT_BUSCAR"
        Me.BT_BUSCAR.Size = New System.Drawing.Size(75, 50)
        Me.BT_BUSCAR.TabIndex = 1
        Me.BT_BUSCAR.Text = "&Buscar"
        Me.BT_BUSCAR.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(44, 18)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(66, 18)
        Me.Label37.TabIndex = 43
        Me.Label37.Text = "Buscar:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MT_BUSCAR
        '
        Me.MT_BUSCAR.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_BUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_BUSCAR.ForeColor = System.Drawing.Color.Black
        Me.MT_BUSCAR.Location = New System.Drawing.Point(26, 42)
        Me.MT_BUSCAR.MaxLength = 30
        Me.MT_BUSCAR.Name = "MT_BUSCAR"
        Me.MT_BUSCAR.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_BUSCAR.p_IniciarComo = True
        Me.MT_BUSCAR.Size = New System.Drawing.Size(268, 29)
        Me.MT_BUSCAR.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 91)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(534, 22)
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
        'Plantilla_7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(540, 119)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(556, 157)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(556, 157)
        Me.Name = "Plantilla_7"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MCB_BUSQUEDA As MisControles.Controles.MisComboBox
    Friend WithEvents BT_BUS_AVANZ As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BT_BUSCAR As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents MT_BUSCAR As MisControles.Controles.MisTextos
End Class
