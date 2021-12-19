<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusAvanzadaPrd
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.MCHB_BALANZA = New MisControles.Controles.MisCheckBox
        Me.MCHB_OFERTA = New MisControles.Controles.MisCheckBox
        Me.MCB_BALANZA = New MisControles.Controles.MisComboBox
        Me.MCB_OFERTA = New MisControles.Controles.MisComboBox
        Me.MCHB_DEPARTAMENTO = New MisControles.Controles.MisCheckBox
        Me.MF_HASTA = New MisControles.Controles.MisFechas
        Me.MF_DESDE = New MisControles.Controles.MisFechas
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.MCHB_FECHA = New MisControles.Controles.MisCheckBox
        Me.MCHB_ESTATUS = New MisControles.Controles.MisCheckBox
        Me.MCHB_DEPOSITO = New MisControles.Controles.MisCheckBox
        Me.MCHB_MARCA = New MisControles.Controles.MisCheckBox
        Me.MCHB_PROVEEDOR = New MisControles.Controles.MisCheckBox
        Me.MCHB_IMPUESTO = New MisControles.Controles.MisCheckBox
        Me.MCHB_ORIGEN = New MisControles.Controles.MisCheckBox
        Me.MCHB_CATEGORIA = New MisControles.Controles.MisCheckBox
        Me.MCHB_SUBGRUPO = New MisControles.Controles.MisCheckBox
        Me.MCHB_GRUPO = New MisControles.Controles.MisCheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MCB_ESTATUS = New MisControles.Controles.MisComboBox
        Me.MCB_DEPOSITO = New MisControles.Controles.MisComboBox
        Me.MCB_MARCA = New MisControles.Controles.MisComboBox
        Me.MCB_PROVEEDOR = New MisControles.Controles.MisComboBox
        Me.MCB_IMPUESTO = New MisControles.Controles.MisComboBox
        Me.MCB_ORIGEN = New MisControles.Controles.MisComboBox
        Me.MCB_CATEGORIA = New MisControles.Controles.MisComboBox
        Me.MCB_SUBGRUPO = New MisControles.Controles.MisComboBox
        Me.MCB_GRUPO = New MisControles.Controles.MisComboBox
        Me.MCB_DEPARTAMENTO = New MisControles.Controles.MisComboBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(655, 502)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.07657!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.92343!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 31)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 373.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(653, 447)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.BT_PROCESAR)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 376)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(647, 68)
        Me.Panel4.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(243, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Indique El Tipo De Busqueda"
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.Location = New System.Drawing.Point(511, 11)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(122, 42)
        Me.BT_PROCESAR.TabIndex = 1
        Me.BT_PROCESAR.Text = "&Procesar"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(647, 2)
        Me.Panel5.TabIndex = 0
        '
        'Panel6
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel6, 2)
        Me.Panel6.Controls.Add(Me.MCHB_BALANZA)
        Me.Panel6.Controls.Add(Me.MCHB_OFERTA)
        Me.Panel6.Controls.Add(Me.MCB_BALANZA)
        Me.Panel6.Controls.Add(Me.MCB_OFERTA)
        Me.Panel6.Controls.Add(Me.MCHB_DEPARTAMENTO)
        Me.Panel6.Controls.Add(Me.MF_HASTA)
        Me.Panel6.Controls.Add(Me.MF_DESDE)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.MCHB_FECHA)
        Me.Panel6.Controls.Add(Me.MCHB_ESTATUS)
        Me.Panel6.Controls.Add(Me.MCHB_DEPOSITO)
        Me.Panel6.Controls.Add(Me.MCHB_MARCA)
        Me.Panel6.Controls.Add(Me.MCHB_PROVEEDOR)
        Me.Panel6.Controls.Add(Me.MCHB_IMPUESTO)
        Me.Panel6.Controls.Add(Me.MCHB_ORIGEN)
        Me.Panel6.Controls.Add(Me.MCHB_CATEGORIA)
        Me.Panel6.Controls.Add(Me.MCHB_SUBGRUPO)
        Me.Panel6.Controls.Add(Me.MCHB_GRUPO)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.MCB_ESTATUS)
        Me.Panel6.Controls.Add(Me.MCB_DEPOSITO)
        Me.Panel6.Controls.Add(Me.MCB_MARCA)
        Me.Panel6.Controls.Add(Me.MCB_PROVEEDOR)
        Me.Panel6.Controls.Add(Me.MCB_IMPUESTO)
        Me.Panel6.Controls.Add(Me.MCB_ORIGEN)
        Me.Panel6.Controls.Add(Me.MCB_CATEGORIA)
        Me.Panel6.Controls.Add(Me.MCB_SUBGRUPO)
        Me.Panel6.Controls.Add(Me.MCB_GRUPO)
        Me.Panel6.Controls.Add(Me.MCB_DEPARTAMENTO)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(647, 367)
        Me.Panel6.TabIndex = 1
        '
        'MCHB_BALANZA
        '
        Me.MCHB_BALANZA.AutoSize = True
        Me.MCHB_BALANZA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_BALANZA.Location = New System.Drawing.Point(54, 268)
        Me.MCHB_BALANZA.Name = "MCHB_BALANZA"
        Me.MCHB_BALANZA.Size = New System.Drawing.Size(128, 20)
        Me.MCHB_BALANZA.TabIndex = 20
        Me.MCHB_BALANZA.Text = "Por Uso Balanza"
        Me.MCHB_BALANZA.UseVisualStyleBackColor = True
        '
        'MCHB_OFERTA
        '
        Me.MCHB_OFERTA.AutoSize = True
        Me.MCHB_OFERTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_OFERTA.Location = New System.Drawing.Point(54, 242)
        Me.MCHB_OFERTA.Name = "MCHB_OFERTA"
        Me.MCHB_OFERTA.Size = New System.Drawing.Size(94, 20)
        Me.MCHB_OFERTA.TabIndex = 18
        Me.MCHB_OFERTA.Text = "Por Ofertas"
        Me.MCHB_OFERTA.UseVisualStyleBackColor = True
        '
        'MCB_BALANZA
        '
        Me.MCB_BALANZA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_BALANZA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_BALANZA.FormattingEnabled = True
        Me.MCB_BALANZA.Location = New System.Drawing.Point(254, 266)
        Me.MCB_BALANZA.Name = "MCB_BALANZA"
        Me.MCB_BALANZA.Size = New System.Drawing.Size(379, 24)
        Me.MCB_BALANZA.TabIndex = 21
        '
        'MCB_OFERTA
        '
        Me.MCB_OFERTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_OFERTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_OFERTA.FormattingEnabled = True
        Me.MCB_OFERTA.Location = New System.Drawing.Point(254, 240)
        Me.MCB_OFERTA.Name = "MCB_OFERTA"
        Me.MCB_OFERTA.Size = New System.Drawing.Size(379, 24)
        Me.MCB_OFERTA.TabIndex = 19
        '
        'MCHB_DEPARTAMENTO
        '
        Me.MCHB_DEPARTAMENTO.AutoSize = True
        Me.MCHB_DEPARTAMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_DEPARTAMENTO.Location = New System.Drawing.Point(54, 8)
        Me.MCHB_DEPARTAMENTO.Name = "MCHB_DEPARTAMENTO"
        Me.MCHB_DEPARTAMENTO.Size = New System.Drawing.Size(137, 20)
        Me.MCHB_DEPARTAMENTO.TabIndex = 0
        Me.MCHB_DEPARTAMENTO.Text = "Por Departamento"
        Me.MCHB_DEPARTAMENTO.UseVisualStyleBackColor = True
        '
        'MF_HASTA
        '
        Me.MF_HASTA.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_HASTA.ForeColor = System.Drawing.Color.Black
        Me.MF_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_HASTA.Location = New System.Drawing.Point(298, 342)
        Me.MF_HASTA.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_HASTA.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_HASTA.Name = "MF_HASTA"
        Me.MF_HASTA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.p_IniciarComo = True
        Me.MF_HASTA.ShowCheckBox = True
        Me.MF_HASTA.Size = New System.Drawing.Size(205, 22)
        Me.MF_HASTA.TabIndex = 26
        Me.MF_HASTA.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MF_DESDE
        '
        Me.MF_DESDE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_DESDE.ForeColor = System.Drawing.Color.Black
        Me.MF_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_DESDE.Location = New System.Drawing.Point(298, 318)
        Me.MF_DESDE.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_DESDE.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_DESDE.Name = "MF_DESDE"
        Me.MF_DESDE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.p_IniciarComo = True
        Me.MF_DESDE.ShowCheckBox = True
        Me.MF_DESDE.Size = New System.Drawing.Size(205, 22)
        Me.MF_DESDE.TabIndex = 25
        Me.MF_DESDE.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(251, 349)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(251, 325)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Desde:"
        '
        'MCHB_FECHA
        '
        Me.MCHB_FECHA.AutoSize = True
        Me.MCHB_FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_FECHA.Location = New System.Drawing.Point(55, 318)
        Me.MCHB_FECHA.Name = "MCHB_FECHA"
        Me.MCHB_FECHA.Size = New System.Drawing.Size(164, 20)
        Me.MCHB_FECHA.TabIndex = 24
        Me.MCHB_FECHA.Text = "Por Fecha De Registro"
        Me.MCHB_FECHA.UseVisualStyleBackColor = True
        '
        'MCHB_ESTATUS
        '
        Me.MCHB_ESTATUS.AutoSize = True
        Me.MCHB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ESTATUS.Location = New System.Drawing.Point(55, 294)
        Me.MCHB_ESTATUS.Name = "MCHB_ESTATUS"
        Me.MCHB_ESTATUS.Size = New System.Drawing.Size(95, 20)
        Me.MCHB_ESTATUS.TabIndex = 22
        Me.MCHB_ESTATUS.Text = "Por Estatus"
        Me.MCHB_ESTATUS.UseVisualStyleBackColor = True
        '
        'MCHB_DEPOSITO
        '
        Me.MCHB_DEPOSITO.AutoSize = True
        Me.MCHB_DEPOSITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_DEPOSITO.Location = New System.Drawing.Point(55, 216)
        Me.MCHB_DEPOSITO.Name = "MCHB_DEPOSITO"
        Me.MCHB_DEPOSITO.Size = New System.Drawing.Size(106, 20)
        Me.MCHB_DEPOSITO.TabIndex = 16
        Me.MCHB_DEPOSITO.Text = "Por Deposito"
        Me.MCHB_DEPOSITO.UseVisualStyleBackColor = True
        '
        'MCHB_MARCA
        '
        Me.MCHB_MARCA.AutoSize = True
        Me.MCHB_MARCA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_MARCA.Location = New System.Drawing.Point(55, 190)
        Me.MCHB_MARCA.Name = "MCHB_MARCA"
        Me.MCHB_MARCA.Size = New System.Drawing.Size(89, 20)
        Me.MCHB_MARCA.TabIndex = 14
        Me.MCHB_MARCA.Text = "Por Marca"
        Me.MCHB_MARCA.UseVisualStyleBackColor = True
        '
        'MCHB_PROVEEDOR
        '
        Me.MCHB_PROVEEDOR.AutoSize = True
        Me.MCHB_PROVEEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_PROVEEDOR.Location = New System.Drawing.Point(55, 164)
        Me.MCHB_PROVEEDOR.Name = "MCHB_PROVEEDOR"
        Me.MCHB_PROVEEDOR.Size = New System.Drawing.Size(115, 20)
        Me.MCHB_PROVEEDOR.TabIndex = 12
        Me.MCHB_PROVEEDOR.Text = "Por Proveedor"
        Me.MCHB_PROVEEDOR.UseVisualStyleBackColor = True
        '
        'MCHB_IMPUESTO
        '
        Me.MCHB_IMPUESTO.AutoSize = True
        Me.MCHB_IMPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_IMPUESTO.Location = New System.Drawing.Point(55, 138)
        Me.MCHB_IMPUESTO.Name = "MCHB_IMPUESTO"
        Me.MCHB_IMPUESTO.Size = New System.Drawing.Size(158, 20)
        Me.MCHB_IMPUESTO.TabIndex = 10
        Me.MCHB_IMPUESTO.Text = "Por Tipo De Impuesto"
        Me.MCHB_IMPUESTO.UseVisualStyleBackColor = True
        '
        'MCHB_ORIGEN
        '
        Me.MCHB_ORIGEN.AutoSize = True
        Me.MCHB_ORIGEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ORIGEN.Location = New System.Drawing.Point(55, 112)
        Me.MCHB_ORIGEN.Name = "MCHB_ORIGEN"
        Me.MCHB_ORIGEN.Size = New System.Drawing.Size(172, 20)
        Me.MCHB_ORIGEN.TabIndex = 8
        Me.MCHB_ORIGEN.Text = "Por Origen Del Producto"
        Me.MCHB_ORIGEN.UseVisualStyleBackColor = True
        '
        'MCHB_CATEGORIA
        '
        Me.MCHB_CATEGORIA.AutoSize = True
        Me.MCHB_CATEGORIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_CATEGORIA.Location = New System.Drawing.Point(55, 86)
        Me.MCHB_CATEGORIA.Name = "MCHB_CATEGORIA"
        Me.MCHB_CATEGORIA.Size = New System.Drawing.Size(110, 20)
        Me.MCHB_CATEGORIA.TabIndex = 6
        Me.MCHB_CATEGORIA.Text = "Por Categoria"
        Me.MCHB_CATEGORIA.UseVisualStyleBackColor = True
        '
        'MCHB_SUBGRUPO
        '
        Me.MCHB_SUBGRUPO.AutoSize = True
        Me.MCHB_SUBGRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_SUBGRUPO.Location = New System.Drawing.Point(55, 60)
        Me.MCHB_SUBGRUPO.Name = "MCHB_SUBGRUPO"
        Me.MCHB_SUBGRUPO.Size = New System.Drawing.Size(110, 20)
        Me.MCHB_SUBGRUPO.TabIndex = 4
        Me.MCHB_SUBGRUPO.Text = "Por Subgrupo"
        Me.MCHB_SUBGRUPO.UseVisualStyleBackColor = True
        '
        'MCHB_GRUPO
        '
        Me.MCHB_GRUPO.AutoSize = True
        Me.MCHB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_GRUPO.Location = New System.Drawing.Point(55, 34)
        Me.MCHB_GRUPO.Name = "MCHB_GRUPO"
        Me.MCHB_GRUPO.Size = New System.Drawing.Size(88, 20)
        Me.MCHB_GRUPO.TabIndex = 2
        Me.MCHB_GRUPO.Text = "Por Grupo"
        Me.MCHB_GRUPO.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 14
        '
        'MCB_ESTATUS
        '
        Me.MCB_ESTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTATUS.FormattingEnabled = True
        Me.MCB_ESTATUS.Location = New System.Drawing.Point(254, 292)
        Me.MCB_ESTATUS.Name = "MCB_ESTATUS"
        Me.MCB_ESTATUS.Size = New System.Drawing.Size(379, 24)
        Me.MCB_ESTATUS.TabIndex = 23
        '
        'MCB_DEPOSITO
        '
        Me.MCB_DEPOSITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_DEPOSITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_DEPOSITO.FormattingEnabled = True
        Me.MCB_DEPOSITO.Location = New System.Drawing.Point(254, 214)
        Me.MCB_DEPOSITO.Name = "MCB_DEPOSITO"
        Me.MCB_DEPOSITO.Size = New System.Drawing.Size(379, 24)
        Me.MCB_DEPOSITO.TabIndex = 17
        '
        'MCB_MARCA
        '
        Me.MCB_MARCA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_MARCA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_MARCA.FormattingEnabled = True
        Me.MCB_MARCA.Location = New System.Drawing.Point(254, 188)
        Me.MCB_MARCA.Name = "MCB_MARCA"
        Me.MCB_MARCA.Size = New System.Drawing.Size(379, 24)
        Me.MCB_MARCA.TabIndex = 15
        '
        'MCB_PROVEEDOR
        '
        Me.MCB_PROVEEDOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_PROVEEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_PROVEEDOR.FormattingEnabled = True
        Me.MCB_PROVEEDOR.Location = New System.Drawing.Point(254, 162)
        Me.MCB_PROVEEDOR.Name = "MCB_PROVEEDOR"
        Me.MCB_PROVEEDOR.Size = New System.Drawing.Size(379, 24)
        Me.MCB_PROVEEDOR.TabIndex = 13
        '
        'MCB_IMPUESTO
        '
        Me.MCB_IMPUESTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_IMPUESTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_IMPUESTO.FormattingEnabled = True
        Me.MCB_IMPUESTO.Location = New System.Drawing.Point(254, 136)
        Me.MCB_IMPUESTO.Name = "MCB_IMPUESTO"
        Me.MCB_IMPUESTO.Size = New System.Drawing.Size(379, 24)
        Me.MCB_IMPUESTO.TabIndex = 11
        '
        'MCB_ORIGEN
        '
        Me.MCB_ORIGEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ORIGEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ORIGEN.FormattingEnabled = True
        Me.MCB_ORIGEN.Location = New System.Drawing.Point(254, 110)
        Me.MCB_ORIGEN.Name = "MCB_ORIGEN"
        Me.MCB_ORIGEN.Size = New System.Drawing.Size(379, 24)
        Me.MCB_ORIGEN.TabIndex = 9
        '
        'MCB_CATEGORIA
        '
        Me.MCB_CATEGORIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_CATEGORIA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_CATEGORIA.FormattingEnabled = True
        Me.MCB_CATEGORIA.Location = New System.Drawing.Point(254, 84)
        Me.MCB_CATEGORIA.Name = "MCB_CATEGORIA"
        Me.MCB_CATEGORIA.Size = New System.Drawing.Size(379, 24)
        Me.MCB_CATEGORIA.TabIndex = 7
        '
        'MCB_SUBGRUPO
        '
        Me.MCB_SUBGRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_SUBGRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_SUBGRUPO.FormattingEnabled = True
        Me.MCB_SUBGRUPO.Location = New System.Drawing.Point(254, 58)
        Me.MCB_SUBGRUPO.Name = "MCB_SUBGRUPO"
        Me.MCB_SUBGRUPO.Size = New System.Drawing.Size(379, 24)
        Me.MCB_SUBGRUPO.TabIndex = 5
        '
        'MCB_GRUPO
        '
        Me.MCB_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_GRUPO.FormattingEnabled = True
        Me.MCB_GRUPO.Location = New System.Drawing.Point(254, 32)
        Me.MCB_GRUPO.Name = "MCB_GRUPO"
        Me.MCB_GRUPO.Size = New System.Drawing.Size(379, 24)
        Me.MCB_GRUPO.TabIndex = 3
        '
        'MCB_DEPARTAMENTO
        '
        Me.MCB_DEPARTAMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_DEPARTAMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_DEPARTAMENTO.FormattingEnabled = True
        Me.MCB_DEPARTAMENTO.Location = New System.Drawing.Point(254, 6)
        Me.MCB_DEPARTAMENTO.Name = "MCB_DEPARTAMENTO"
        Me.MCB_DEPARTAMENTO.Size = New System.Drawing.Size(379, 24)
        Me.MCB_DEPARTAMENTO.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 478)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(653, 22)
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
        Me.Panel2.Size = New System.Drawing.Size(653, 31)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(653, 3)
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
        'BusAvanzadaPrd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(661, 508)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(677, 546)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(677, 546)
        Me.Name = "BusAvanzadaPrd"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
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
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents MCB_DEPOSITO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_MARCA As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_PROVEEDOR As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_IMPUESTO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ORIGEN As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_CATEGORIA As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_SUBGRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_GRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_DEPARTAMENTO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ESTATUS As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_ESTATUS As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_DEPOSITO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_MARCA As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_PROVEEDOR As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_IMPUESTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_ORIGEN As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_CATEGORIA As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_SUBGRUPO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_GRUPO As MisControles.Controles.MisCheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MCHB_FECHA As MisControles.Controles.MisCheckBox
    Friend WithEvents MF_DESDE As MisControles.Controles.MisFechas
    Friend WithEvents MF_HASTA As MisControles.Controles.MisFechas
    Friend WithEvents MCHB_DEPARTAMENTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_BALANZA As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_OFERTA As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_BALANZA As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_OFERTA As MisControles.Controles.MisComboBox
End Class