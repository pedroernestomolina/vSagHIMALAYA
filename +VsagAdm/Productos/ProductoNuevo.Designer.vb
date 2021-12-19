<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductoNuevo
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
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.MN_COSTO_FULL = New MisControles.Controles.MisNumeros
        Me.MN_COSTO_NETO = New MisControles.Controles.MisNumeros
        Me.Label9 = New System.Windows.Forms.Label
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel
        Me.MCB_MARCA = New MisControles.Controles.MisComboBox
        Me.MN_CONTENIDO = New MisControles.Controles.MisNumeros
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel
        Me.Label13 = New System.Windows.Forms.Label
        Me.MCB_EMPAQUE = New MisControles.Controles.MisComboBox
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label8 = New System.Windows.Forms.Label
        Me.MCB_SUBGRUPO = New MisControles.Controles.MisComboBox
        Me.MCB_GRUPO = New MisControles.Controles.MisComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.MCB_CATEGORIA = New MisControles.Controles.MisComboBox
        Me.MCB_ORIGEN = New MisControles.Controles.MisComboBox
        Me.MCB_DEPARTAMENTO = New MisControles.Controles.MisComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.MCB_TASA = New MisControles.Controles.MisComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.MT_NOMBRE_CORTO = New MisControles.Controles.MisTextos
        Me.MT_NOMBRE_LARGO = New MisControles.Controles.MisTextos
        Me.MT_CODIGO = New MisControles.Controles.MisTextos
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.BT_GRABAR = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(666, 513)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 551.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 33)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 389.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(664, 456)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Info
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.MN_COSTO_FULL)
        Me.Panel4.Controls.Add(Me.MN_COSTO_NETO)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.LinkLabel5)
        Me.Panel4.Controls.Add(Me.MCB_MARCA)
        Me.Panel4.Controls.Add(Me.MN_CONTENIDO)
        Me.Panel4.Controls.Add(Me.LinkLabel4)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.MCB_EMPAQUE)
        Me.Panel4.Controls.Add(Me.LinkLabel3)
        Me.Panel4.Controls.Add(Me.LinkLabel2)
        Me.Panel4.Controls.Add(Me.LinkLabel1)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.MCB_SUBGRUPO)
        Me.Panel4.Controls.Add(Me.MCB_GRUPO)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.MCB_CATEGORIA)
        Me.Panel4.Controls.Add(Me.MCB_ORIGEN)
        Me.Panel4.Controls.Add(Me.MCB_DEPARTAMENTO)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.MCB_TASA)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.MT_NOMBRE_CORTO)
        Me.Panel4.Controls.Add(Me.MT_NOMBRE_LARGO)
        Me.Panel4.Controls.Add(Me.MT_CODIGO)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.ShapeContainer1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(658, 383)
        Me.Panel4.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(546, 320)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 15)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Con Iva / Full"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(452, 320)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 15)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Sin Iva / Neto"
        '
        'MN_COSTO_FULL
        '
        Me.MN_COSTO_FULL._ConSigno = False
        Me.MN_COSTO_FULL._Formato = ""
        Me.MN_COSTO_FULL.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_COSTO_FULL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_COSTO_FULL.ForeColor = System.Drawing.Color.Black
        Me.MN_COSTO_FULL.Location = New System.Drawing.Point(547, 341)
        Me.MN_COSTO_FULL.Name = "MN_COSTO_FULL"
        Me.MN_COSTO_FULL.Size = New System.Drawing.Size(90, 24)
        Me.MN_COSTO_FULL.TabIndex = 18
        Me.MN_COSTO_FULL.Text = "0"
        Me.MN_COSTO_FULL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_COSTO_NETO
        '
        Me.MN_COSTO_NETO._ConSigno = False
        Me.MN_COSTO_NETO._Formato = ""
        Me.MN_COSTO_NETO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_COSTO_NETO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_COSTO_NETO.ForeColor = System.Drawing.Color.Black
        Me.MN_COSTO_NETO.Location = New System.Drawing.Point(455, 341)
        Me.MN_COSTO_NETO.Name = "MN_COSTO_NETO"
        Me.MN_COSTO_NETO.Size = New System.Drawing.Size(90, 24)
        Me.MN_COSTO_NETO.TabIndex = 17
        Me.MN_COSTO_NETO.Text = "0"
        Me.MN_COSTO_NETO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(310, 344)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 15)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "Ultimo Costo Proveedor:"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel5.Location = New System.Drawing.Point(17, 187)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(102, 15)
        Me.LinkLabel5.TabIndex = 9
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Marca:"
        Me.LinkLabel5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MCB_MARCA
        '
        Me.MCB_MARCA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_MARCA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_MARCA.FormattingEnabled = True
        Me.MCB_MARCA.Location = New System.Drawing.Point(125, 184)
        Me.MCB_MARCA.Name = "MCB_MARCA"
        Me.MCB_MARCA.Size = New System.Drawing.Size(520, 24)
        Me.MCB_MARCA.TabIndex = 10
        '
        'MN_CONTENIDO
        '
        Me.MN_CONTENIDO._ConSigno = False
        Me.MN_CONTENIDO._Formato = ""
        Me.MN_CONTENIDO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_CONTENIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_CONTENIDO.ForeColor = System.Drawing.Color.Black
        Me.MN_CONTENIDO.Location = New System.Drawing.Point(125, 341)
        Me.MN_CONTENIDO.Name = "MN_CONTENIDO"
        Me.MN_CONTENIDO.Size = New System.Drawing.Size(100, 24)
        Me.MN_CONTENIDO.TabIndex = 16
        Me.MN_CONTENIDO.Text = "0"
        Me.MN_CONTENIDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LinkLabel4
        '
        Me.LinkLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel4.Location = New System.Drawing.Point(19, 305)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(100, 31)
        Me.LinkLabel4.TabIndex = 14
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Empaque Compra:"
        Me.LinkLabel4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(53, 344)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 15)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "Contenido:"
        '
        'MCB_EMPAQUE
        '
        Me.MCB_EMPAQUE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_EMPAQUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_EMPAQUE.FormattingEnabled = True
        Me.MCB_EMPAQUE.Location = New System.Drawing.Point(125, 312)
        Me.MCB_EMPAQUE.Name = "MCB_EMPAQUE"
        Me.MCB_EMPAQUE.Size = New System.Drawing.Size(218, 24)
        Me.MCB_EMPAQUE.TabIndex = 15
        '
        'LinkLabel3
        '
        Me.LinkLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel3.Location = New System.Drawing.Point(17, 161)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(102, 15)
        Me.LinkLabel3.TabIndex = 7
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "SubGrupo:"
        Me.LinkLabel3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(17, 135)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(102, 15)
        Me.LinkLabel2.TabIndex = 5
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Grupo:"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(17, 109)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(102, 15)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Departamento:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(56, 239)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 15)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Categoria:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MCB_SUBGRUPO
        '
        Me.MCB_SUBGRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_SUBGRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_SUBGRUPO.FormattingEnabled = True
        Me.MCB_SUBGRUPO.Location = New System.Drawing.Point(125, 158)
        Me.MCB_SUBGRUPO.Name = "MCB_SUBGRUPO"
        Me.MCB_SUBGRUPO.Size = New System.Drawing.Size(520, 24)
        Me.MCB_SUBGRUPO.TabIndex = 8
        '
        'MCB_GRUPO
        '
        Me.MCB_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_GRUPO.FormattingEnabled = True
        Me.MCB_GRUPO.Location = New System.Drawing.Point(125, 132)
        Me.MCB_GRUPO.Name = "MCB_GRUPO"
        Me.MCB_GRUPO.Size = New System.Drawing.Size(520, 24)
        Me.MCB_GRUPO.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(72, 213)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 15)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Origen:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MCB_CATEGORIA
        '
        Me.MCB_CATEGORIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_CATEGORIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_CATEGORIA.FormattingEnabled = True
        Me.MCB_CATEGORIA.Location = New System.Drawing.Point(125, 236)
        Me.MCB_CATEGORIA.Name = "MCB_CATEGORIA"
        Me.MCB_CATEGORIA.Size = New System.Drawing.Size(218, 24)
        Me.MCB_CATEGORIA.TabIndex = 12
        '
        'MCB_ORIGEN
        '
        Me.MCB_ORIGEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ORIGEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ORIGEN.FormattingEnabled = True
        Me.MCB_ORIGEN.Location = New System.Drawing.Point(125, 210)
        Me.MCB_ORIGEN.Name = "MCB_ORIGEN"
        Me.MCB_ORIGEN.Size = New System.Drawing.Size(218, 24)
        Me.MCB_ORIGEN.TabIndex = 11
        '
        'MCB_DEPARTAMENTO
        '
        Me.MCB_DEPARTAMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_DEPARTAMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_DEPARTAMENTO.FormattingEnabled = True
        Me.MCB_DEPARTAMENTO.Location = New System.Drawing.Point(125, 106)
        Me.MCB_DEPARTAMENTO.Name = "MCB_DEPARTAMENTO"
        Me.MCB_DEPARTAMENTO.Size = New System.Drawing.Size(520, 24)
        Me.MCB_DEPARTAMENTO.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 267)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 15)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Tasa / Impuesto:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MCB_TASA
        '
        Me.MCB_TASA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_TASA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_TASA.FormattingEnabled = True
        Me.MCB_TASA.Location = New System.Drawing.Point(125, 262)
        Me.MCB_TASA.Name = "MCB_TASA"
        Me.MCB_TASA.Size = New System.Drawing.Size(218, 24)
        Me.MCB_TASA.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(35, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 15)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Descrip/Corta:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MT_NOMBRE_CORTO
        '
        Me.MT_NOMBRE_CORTO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_NOMBRE_CORTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_NOMBRE_CORTO.ForeColor = System.Drawing.Color.Black
        Me.MT_NOMBRE_CORTO.Location = New System.Drawing.Point(125, 82)
        Me.MT_NOMBRE_CORTO.MaxLength = 20
        Me.MT_NOMBRE_CORTO.Name = "MT_NOMBRE_CORTO"
        Me.MT_NOMBRE_CORTO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_NOMBRE_CORTO.p_IniciarComo = True
        Me.MT_NOMBRE_CORTO.Size = New System.Drawing.Size(520, 22)
        Me.MT_NOMBRE_CORTO.TabIndex = 2
        Me.MT_NOMBRE_CORTO.Text = "SDKLFJKSDL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ASDDASDSA"
        '
        'MT_NOMBRE_LARGO
        '
        Me.MT_NOMBRE_LARGO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_NOMBRE_LARGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_NOMBRE_LARGO.ForeColor = System.Drawing.Color.Black
        Me.MT_NOMBRE_LARGO.Location = New System.Drawing.Point(125, 41)
        Me.MT_NOMBRE_LARGO.MaxLength = 20
        Me.MT_NOMBRE_LARGO.Multiline = True
        Me.MT_NOMBRE_LARGO.Name = "MT_NOMBRE_LARGO"
        Me.MT_NOMBRE_LARGO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_NOMBRE_LARGO.p_IniciarComo = True
        Me.MT_NOMBRE_LARGO.Size = New System.Drawing.Size(520, 39)
        Me.MT_NOMBRE_LARGO.TabIndex = 1
        Me.MT_NOMBRE_LARGO.Text = "SDKLFJKSDL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ASDDASDSA"
        '
        'MT_CODIGO
        '
        Me.MT_CODIGO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_CODIGO.ForeColor = System.Drawing.Color.Black
        Me.MT_CODIGO.Location = New System.Drawing.Point(125, 17)
        Me.MT_CODIGO.MaxLength = 20
        Me.MT_CODIGO.Name = "MT_CODIGO"
        Me.MT_CODIGO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_CODIGO.p_IniciarComo = True
        Me.MT_CODIGO.Size = New System.Drawing.Size(218, 22)
        Me.MT_CODIGO.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 36)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Descripcion Detallada:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 15)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Codigo a Asignar:"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(656, 381)
        Me.ShapeContainer1.TabIndex = 84
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.BorderWidth = 2
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 25
        Me.LineShape1.X2 = 636
        Me.LineShape1.Y1 = 298
        Me.LineShape1.Y2 = 298
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel3, 2)
        Me.Panel3.Controls.Add(Me.BT_GRABAR)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 392)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(658, 61)
        Me.Panel3.TabIndex = 2
        '
        'BT_GRABAR
        '
        Me.BT_GRABAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GRABAR.Location = New System.Drawing.Point(511, 4)
        Me.BT_GRABAR.Name = "BT_GRABAR"
        Me.BT_GRABAR.Size = New System.Drawing.Size(126, 51)
        Me.BT_GRABAR.TabIndex = 0
        Me.BT_GRABAR.Text = "&Grabar"
        Me.ToolTip1.SetToolTip(Me.BT_GRABAR, "Guaradar / Grabar Cambios Efectuados")
        Me.BT_GRABAR.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(664, 33)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Agregar Nuevo Producto"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 489)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(664, 22)
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
        'ProductoNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGreen
        Me.ClientSize = New System.Drawing.Size(672, 519)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProductoNuevo"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ficha Producto"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MCB_TASA As MisControles.Controles.MisComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MT_NOMBRE_CORTO As MisControles.Controles.MisTextos
    Friend WithEvents MT_NOMBRE_LARGO As MisControles.Controles.MisTextos
    Friend WithEvents MT_CODIGO As MisControles.Controles.MisTextos
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MCB_SUBGRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_GRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MCB_CATEGORIA As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ORIGEN As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_DEPARTAMENTO As MisControles.Controles.MisComboBox
    Friend WithEvents MN_CONTENIDO As MisControles.Controles.MisNumeros
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MCB_EMPAQUE As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_MARCA As MisControles.Controles.MisComboBox
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MN_COSTO_FULL As MisControles.Controles.MisNumeros
    Friend WithEvents MN_COSTO_NETO As MisControles.Controles.MisNumeros
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BT_GRABAR As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
