<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusAvanzadaCliente
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
        Me.MCHB_DIA_COBRANZA = New MisControles.Controles.MisCheckBox
        Me.MCB_DIA_COBRANZA = New MisControles.Controles.MisComboBox
        Me.MF_HASTA = New MisControles.Controles.MisFechas
        Me.MF_DESDE = New MisControles.Controles.MisFechas
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.MCHB_FECHA = New MisControles.Controles.MisCheckBox
        Me.MN_PUNTOS = New MisControles.Controles.MisNumeros
        Me.MN_LIMITE_CR = New MisControles.Controles.MisNumeros
        Me.MCHB_ESTATUS = New MisControles.Controles.MisCheckBox
        Me.MCHB_PUNTOS = New MisControles.Controles.MisCheckBox
        Me.MCHB_AFILIACION = New MisControles.Controles.MisCheckBox
        Me.MCHB_CARGO = New MisControles.Controles.MisCheckBox
        Me.MCHB_DESCUENTO = New MisControles.Controles.MisCheckBox
        Me.MCHB_COBRADOR = New MisControles.Controles.MisCheckBox
        Me.MCHB_VENDEDOR = New MisControles.Controles.MisCheckBox
        Me.MCHB_LIMITE = New MisControles.Controles.MisCheckBox
        Me.MCHB_CREDITO = New MisControles.Controles.MisCheckBox
        Me.MCHB_PRECIO = New MisControles.Controles.MisCheckBox
        Me.MCHB_DENOMINACION = New MisControles.Controles.MisCheckBox
        Me.MCHB_ZONA = New MisControles.Controles.MisCheckBox
        Me.MCHB_ESTADO = New MisControles.Controles.MisCheckBox
        Me.MCHB_GRUPO = New MisControles.Controles.MisCheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MCB_ESTATUS = New MisControles.Controles.MisComboBox
        Me.MCB_PUNTOS = New MisControles.Controles.MisComboBox
        Me.MCB_AFILIACION = New MisControles.Controles.MisComboBox
        Me.MCB_COBRADOR = New MisControles.Controles.MisComboBox
        Me.MCB_VENDEDOR = New MisControles.Controles.MisComboBox
        Me.MCB_LIMITE_CR = New MisControles.Controles.MisComboBox
        Me.MCB_CREDITO = New MisControles.Controles.MisComboBox
        Me.MCB_PRECIO = New MisControles.Controles.MisComboBox
        Me.MCB_DENOMINACION = New MisControles.Controles.MisComboBox
        Me.MCB_ZONA = New MisControles.Controles.MisComboBox
        Me.MCB_ESTADO = New MisControles.Controles.MisComboBox
        Me.MCB_GRUPO = New MisControles.Controles.MisComboBox
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
        Me.Panel1.Size = New System.Drawing.Size(655, 564)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 31)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 453.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(653, 509)
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
        Me.Panel4.Location = New System.Drawing.Point(3, 456)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(647, 50)
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
        Me.BT_PROCESAR.Location = New System.Drawing.Point(512, 7)
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
        Me.Panel6.Controls.Add(Me.MCHB_DIA_COBRANZA)
        Me.Panel6.Controls.Add(Me.MCB_DIA_COBRANZA)
        Me.Panel6.Controls.Add(Me.MF_HASTA)
        Me.Panel6.Controls.Add(Me.MF_DESDE)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.MCHB_FECHA)
        Me.Panel6.Controls.Add(Me.MN_PUNTOS)
        Me.Panel6.Controls.Add(Me.MN_LIMITE_CR)
        Me.Panel6.Controls.Add(Me.MCHB_ESTATUS)
        Me.Panel6.Controls.Add(Me.MCHB_PUNTOS)
        Me.Panel6.Controls.Add(Me.MCHB_AFILIACION)
        Me.Panel6.Controls.Add(Me.MCHB_CARGO)
        Me.Panel6.Controls.Add(Me.MCHB_DESCUENTO)
        Me.Panel6.Controls.Add(Me.MCHB_COBRADOR)
        Me.Panel6.Controls.Add(Me.MCHB_VENDEDOR)
        Me.Panel6.Controls.Add(Me.MCHB_LIMITE)
        Me.Panel6.Controls.Add(Me.MCHB_CREDITO)
        Me.Panel6.Controls.Add(Me.MCHB_PRECIO)
        Me.Panel6.Controls.Add(Me.MCHB_DENOMINACION)
        Me.Panel6.Controls.Add(Me.MCHB_ZONA)
        Me.Panel6.Controls.Add(Me.MCHB_ESTADO)
        Me.Panel6.Controls.Add(Me.MCHB_GRUPO)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.MCB_ESTATUS)
        Me.Panel6.Controls.Add(Me.MCB_PUNTOS)
        Me.Panel6.Controls.Add(Me.MCB_AFILIACION)
        Me.Panel6.Controls.Add(Me.MCB_COBRADOR)
        Me.Panel6.Controls.Add(Me.MCB_VENDEDOR)
        Me.Panel6.Controls.Add(Me.MCB_LIMITE_CR)
        Me.Panel6.Controls.Add(Me.MCB_CREDITO)
        Me.Panel6.Controls.Add(Me.MCB_PRECIO)
        Me.Panel6.Controls.Add(Me.MCB_DENOMINACION)
        Me.Panel6.Controls.Add(Me.MCB_ZONA)
        Me.Panel6.Controls.Add(Me.MCB_ESTADO)
        Me.Panel6.Controls.Add(Me.MCB_GRUPO)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(647, 447)
        Me.Panel6.TabIndex = 1
        '
        'MCHB_DIA_COBRANZA
        '
        Me.MCHB_DIA_COBRANZA.AutoSize = True
        Me.MCHB_DIA_COBRANZA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_DIA_COBRANZA.Location = New System.Drawing.Point(55, 346)
        Me.MCHB_DIA_COBRANZA.Name = "MCHB_DIA_COBRANZA"
        Me.MCHB_DIA_COBRANZA.Size = New System.Drawing.Size(161, 20)
        Me.MCHB_DIA_COBRANZA.TabIndex = 26
        Me.MCHB_DIA_COBRANZA.Text = "Por Dias De Cobranza"
        Me.MCHB_DIA_COBRANZA.UseVisualStyleBackColor = True
        '
        'MCB_DIA_COBRANZA
        '
        Me.MCB_DIA_COBRANZA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_DIA_COBRANZA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_DIA_COBRANZA.FormattingEnabled = True
        Me.MCB_DIA_COBRANZA.Location = New System.Drawing.Point(254, 344)
        Me.MCB_DIA_COBRANZA.Name = "MCB_DIA_COBRANZA"
        Me.MCB_DIA_COBRANZA.Size = New System.Drawing.Size(249, 24)
        Me.MCB_DIA_COBRANZA.TabIndex = 27
        '
        'MF_HASTA
        '
        Me.MF_HASTA.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_HASTA.ForeColor = System.Drawing.Color.Black
        Me.MF_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_HASTA.Location = New System.Drawing.Point(298, 420)
        Me.MF_HASTA.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_HASTA.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_HASTA.Name = "MF_HASTA"
        Me.MF_HASTA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_HASTA.p_IniciarComo = True
        Me.MF_HASTA.ShowCheckBox = True
        Me.MF_HASTA.Size = New System.Drawing.Size(205, 22)
        Me.MF_HASTA.TabIndex = 32
        Me.MF_HASTA.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'MF_DESDE
        '
        Me.MF_DESDE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MF_DESDE.ForeColor = System.Drawing.Color.Black
        Me.MF_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_DESDE.Location = New System.Drawing.Point(298, 396)
        Me.MF_DESDE.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_DESDE.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.MF_DESDE.Name = "MF_DESDE"
        Me.MF_DESDE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_DESDE.p_IniciarComo = True
        Me.MF_DESDE.ShowCheckBox = True
        Me.MF_DESDE.Size = New System.Drawing.Size(205, 22)
        Me.MF_DESDE.TabIndex = 31
        Me.MF_DESDE.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(251, 427)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(251, 403)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Desde:"
        '
        'MCHB_FECHA
        '
        Me.MCHB_FECHA.AutoSize = True
        Me.MCHB_FECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_FECHA.Location = New System.Drawing.Point(55, 396)
        Me.MCHB_FECHA.Name = "MCHB_FECHA"
        Me.MCHB_FECHA.Size = New System.Drawing.Size(164, 20)
        Me.MCHB_FECHA.TabIndex = 30
        Me.MCHB_FECHA.Text = "Por Fecha De Registro"
        Me.MCHB_FECHA.UseVisualStyleBackColor = True
        '
        'MN_PUNTOS
        '
        Me.MN_PUNTOS._ConSigno = False
        Me.MN_PUNTOS._Formato = ""
        Me.MN_PUNTOS.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_PUNTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_PUNTOS.ForeColor = System.Drawing.Color.Black
        Me.MN_PUNTOS.Location = New System.Drawing.Point(523, 316)
        Me.MN_PUNTOS.Name = "MN_PUNTOS"
        Me.MN_PUNTOS.Size = New System.Drawing.Size(111, 24)
        Me.MN_PUNTOS.TabIndex = 25
        Me.MN_PUNTOS.Text = "0"
        Me.MN_PUNTOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MN_LIMITE_CR
        '
        Me.MN_LIMITE_CR._ConSigno = False
        Me.MN_LIMITE_CR._Formato = ""
        Me.MN_LIMITE_CR.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_LIMITE_CR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_LIMITE_CR.ForeColor = System.Drawing.Color.Black
        Me.MN_LIMITE_CR.Location = New System.Drawing.Point(523, 164)
        Me.MN_LIMITE_CR.Name = "MN_LIMITE_CR"
        Me.MN_LIMITE_CR.Size = New System.Drawing.Size(111, 24)
        Me.MN_LIMITE_CR.TabIndex = 14
        Me.MN_LIMITE_CR.Text = "0"
        Me.MN_LIMITE_CR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MCHB_ESTATUS
        '
        Me.MCHB_ESTATUS.AutoSize = True
        Me.MCHB_ESTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ESTATUS.Location = New System.Drawing.Point(55, 372)
        Me.MCHB_ESTATUS.Name = "MCHB_ESTATUS"
        Me.MCHB_ESTATUS.Size = New System.Drawing.Size(95, 20)
        Me.MCHB_ESTATUS.TabIndex = 28
        Me.MCHB_ESTATUS.Text = "Por Estatus"
        Me.MCHB_ESTATUS.UseVisualStyleBackColor = True
        '
        'MCHB_PUNTOS
        '
        Me.MCHB_PUNTOS.AutoSize = True
        Me.MCHB_PUNTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_PUNTOS.Location = New System.Drawing.Point(55, 320)
        Me.MCHB_PUNTOS.Name = "MCHB_PUNTOS"
        Me.MCHB_PUNTOS.Size = New System.Drawing.Size(170, 20)
        Me.MCHB_PUNTOS.TabIndex = 23
        Me.MCHB_PUNTOS.Text = "Por Puntos Acumulados"
        Me.MCHB_PUNTOS.UseVisualStyleBackColor = True
        '
        'MCHB_AFILIACION
        '
        Me.MCHB_AFILIACION.AutoSize = True
        Me.MCHB_AFILIACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_AFILIACION.Location = New System.Drawing.Point(55, 294)
        Me.MCHB_AFILIACION.Name = "MCHB_AFILIACION"
        Me.MCHB_AFILIACION.Size = New System.Drawing.Size(152, 20)
        Me.MCHB_AFILIACION.TabIndex = 21
        Me.MCHB_AFILIACION.Text = "Por Estatus Afiliacion"
        Me.MCHB_AFILIACION.UseVisualStyleBackColor = True
        '
        'MCHB_CARGO
        '
        Me.MCHB_CARGO.AutoSize = True
        Me.MCHB_CARGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_CARGO.Location = New System.Drawing.Point(55, 268)
        Me.MCHB_CARGO.Name = "MCHB_CARGO"
        Me.MCHB_CARGO.Size = New System.Drawing.Size(163, 20)
        Me.MCHB_CARGO.TabIndex = 20
        Me.MCHB_CARGO.Text = "Por Cargos Asignados"
        Me.MCHB_CARGO.UseVisualStyleBackColor = True
        '
        'MCHB_DESCUENTO
        '
        Me.MCHB_DESCUENTO.AutoSize = True
        Me.MCHB_DESCUENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_DESCUENTO.Location = New System.Drawing.Point(55, 242)
        Me.MCHB_DESCUENTO.Name = "MCHB_DESCUENTO"
        Me.MCHB_DESCUENTO.Size = New System.Drawing.Size(184, 20)
        Me.MCHB_DESCUENTO.TabIndex = 19
        Me.MCHB_DESCUENTO.Text = "Por Descuentos Asignado"
        Me.MCHB_DESCUENTO.UseVisualStyleBackColor = True
        '
        'MCHB_COBRADOR
        '
        Me.MCHB_COBRADOR.AutoSize = True
        Me.MCHB_COBRADOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_COBRADOR.Location = New System.Drawing.Point(55, 216)
        Me.MCHB_COBRADOR.Name = "MCHB_COBRADOR"
        Me.MCHB_COBRADOR.Size = New System.Drawing.Size(108, 20)
        Me.MCHB_COBRADOR.TabIndex = 17
        Me.MCHB_COBRADOR.Text = "Por Cobrador"
        Me.MCHB_COBRADOR.UseVisualStyleBackColor = True
        '
        'MCHB_VENDEDOR
        '
        Me.MCHB_VENDEDOR.AutoSize = True
        Me.MCHB_VENDEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_VENDEDOR.Location = New System.Drawing.Point(55, 190)
        Me.MCHB_VENDEDOR.Name = "MCHB_VENDEDOR"
        Me.MCHB_VENDEDOR.Size = New System.Drawing.Size(111, 20)
        Me.MCHB_VENDEDOR.TabIndex = 15
        Me.MCHB_VENDEDOR.Text = "Por Vendedor"
        Me.MCHB_VENDEDOR.UseVisualStyleBackColor = True
        '
        'MCHB_LIMITE
        '
        Me.MCHB_LIMITE.AutoSize = True
        Me.MCHB_LIMITE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_LIMITE.Location = New System.Drawing.Point(55, 164)
        Me.MCHB_LIMITE.Name = "MCHB_LIMITE"
        Me.MCHB_LIMITE.Size = New System.Drawing.Size(153, 20)
        Me.MCHB_LIMITE.TabIndex = 12
        Me.MCHB_LIMITE.Text = "Por Limite De Credito"
        Me.MCHB_LIMITE.UseVisualStyleBackColor = True
        '
        'MCHB_CREDITO
        '
        Me.MCHB_CREDITO.AutoSize = True
        Me.MCHB_CREDITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_CREDITO.Location = New System.Drawing.Point(55, 138)
        Me.MCHB_CREDITO.Name = "MCHB_CREDITO"
        Me.MCHB_CREDITO.Size = New System.Drawing.Size(125, 20)
        Me.MCHB_CREDITO.TabIndex = 10
        Me.MCHB_CREDITO.Text = "Por Tipo Credito"
        Me.MCHB_CREDITO.UseVisualStyleBackColor = True
        '
        'MCHB_PRECIO
        '
        Me.MCHB_PRECIO.AutoSize = True
        Me.MCHB_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_PRECIO.Location = New System.Drawing.Point(55, 112)
        Me.MCHB_PRECIO.Name = "MCHB_PRECIO"
        Me.MCHB_PRECIO.Size = New System.Drawing.Size(142, 20)
        Me.MCHB_PRECIO.TabIndex = 8
        Me.MCHB_PRECIO.Text = "Por Tipo De Precio"
        Me.MCHB_PRECIO.UseVisualStyleBackColor = True
        '
        'MCHB_DENOMINACION
        '
        Me.MCHB_DENOMINACION.AutoSize = True
        Me.MCHB_DENOMINACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_DENOMINACION.Location = New System.Drawing.Point(55, 86)
        Me.MCHB_DENOMINACION.Name = "MCHB_DENOMINACION"
        Me.MCHB_DENOMINACION.Size = New System.Drawing.Size(177, 20)
        Me.MCHB_DENOMINACION.TabIndex = 6
        Me.MCHB_DENOMINACION.Text = "Por Denominacion Fiscal"
        Me.MCHB_DENOMINACION.UseVisualStyleBackColor = True
        '
        'MCHB_ZONA
        '
        Me.MCHB_ZONA.AutoSize = True
        Me.MCHB_ZONA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCHB_ZONA.Location = New System.Drawing.Point(55, 60)
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
        Me.MCHB_ESTADO.Location = New System.Drawing.Point(55, 34)
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
        Me.MCHB_GRUPO.Location = New System.Drawing.Point(55, 8)
        Me.MCHB_GRUPO.Name = "MCHB_GRUPO"
        Me.MCHB_GRUPO.Size = New System.Drawing.Size(95, 20)
        Me.MCHB_GRUPO.TabIndex = 0
        Me.MCHB_GRUPO.Text = "Por Grupos"
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
        Me.MCB_ESTATUS.Location = New System.Drawing.Point(254, 370)
        Me.MCB_ESTATUS.Name = "MCB_ESTATUS"
        Me.MCB_ESTATUS.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ESTATUS.TabIndex = 29
        '
        'MCB_PUNTOS
        '
        Me.MCB_PUNTOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_PUNTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_PUNTOS.FormattingEnabled = True
        Me.MCB_PUNTOS.Location = New System.Drawing.Point(254, 318)
        Me.MCB_PUNTOS.Name = "MCB_PUNTOS"
        Me.MCB_PUNTOS.Size = New System.Drawing.Size(249, 24)
        Me.MCB_PUNTOS.TabIndex = 24
        '
        'MCB_AFILIACION
        '
        Me.MCB_AFILIACION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_AFILIACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_AFILIACION.FormattingEnabled = True
        Me.MCB_AFILIACION.Location = New System.Drawing.Point(254, 292)
        Me.MCB_AFILIACION.Name = "MCB_AFILIACION"
        Me.MCB_AFILIACION.Size = New System.Drawing.Size(249, 24)
        Me.MCB_AFILIACION.TabIndex = 22
        '
        'MCB_COBRADOR
        '
        Me.MCB_COBRADOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_COBRADOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_COBRADOR.FormattingEnabled = True
        Me.MCB_COBRADOR.Location = New System.Drawing.Point(254, 214)
        Me.MCB_COBRADOR.Name = "MCB_COBRADOR"
        Me.MCB_COBRADOR.Size = New System.Drawing.Size(249, 24)
        Me.MCB_COBRADOR.TabIndex = 18
        '
        'MCB_VENDEDOR
        '
        Me.MCB_VENDEDOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_VENDEDOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_VENDEDOR.FormattingEnabled = True
        Me.MCB_VENDEDOR.Location = New System.Drawing.Point(254, 188)
        Me.MCB_VENDEDOR.Name = "MCB_VENDEDOR"
        Me.MCB_VENDEDOR.Size = New System.Drawing.Size(249, 24)
        Me.MCB_VENDEDOR.TabIndex = 16
        '
        'MCB_LIMITE_CR
        '
        Me.MCB_LIMITE_CR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_LIMITE_CR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_LIMITE_CR.FormattingEnabled = True
        Me.MCB_LIMITE_CR.Location = New System.Drawing.Point(254, 162)
        Me.MCB_LIMITE_CR.Name = "MCB_LIMITE_CR"
        Me.MCB_LIMITE_CR.Size = New System.Drawing.Size(249, 24)
        Me.MCB_LIMITE_CR.TabIndex = 13
        '
        'MCB_CREDITO
        '
        Me.MCB_CREDITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_CREDITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_CREDITO.FormattingEnabled = True
        Me.MCB_CREDITO.Location = New System.Drawing.Point(254, 136)
        Me.MCB_CREDITO.Name = "MCB_CREDITO"
        Me.MCB_CREDITO.Size = New System.Drawing.Size(249, 24)
        Me.MCB_CREDITO.TabIndex = 11
        '
        'MCB_PRECIO
        '
        Me.MCB_PRECIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_PRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_PRECIO.FormattingEnabled = True
        Me.MCB_PRECIO.Location = New System.Drawing.Point(254, 110)
        Me.MCB_PRECIO.Name = "MCB_PRECIO"
        Me.MCB_PRECIO.Size = New System.Drawing.Size(249, 24)
        Me.MCB_PRECIO.TabIndex = 9
        '
        'MCB_DENOMINACION
        '
        Me.MCB_DENOMINACION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_DENOMINACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_DENOMINACION.FormattingEnabled = True
        Me.MCB_DENOMINACION.Location = New System.Drawing.Point(254, 84)
        Me.MCB_DENOMINACION.Name = "MCB_DENOMINACION"
        Me.MCB_DENOMINACION.Size = New System.Drawing.Size(249, 24)
        Me.MCB_DENOMINACION.TabIndex = 7
        '
        'MCB_ZONA
        '
        Me.MCB_ZONA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ZONA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ZONA.FormattingEnabled = True
        Me.MCB_ZONA.Location = New System.Drawing.Point(254, 58)
        Me.MCB_ZONA.Name = "MCB_ZONA"
        Me.MCB_ZONA.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ZONA.TabIndex = 5
        '
        'MCB_ESTADO
        '
        Me.MCB_ESTADO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_ESTADO.FormattingEnabled = True
        Me.MCB_ESTADO.Location = New System.Drawing.Point(254, 32)
        Me.MCB_ESTADO.Name = "MCB_ESTADO"
        Me.MCB_ESTADO.Size = New System.Drawing.Size(249, 24)
        Me.MCB_ESTADO.TabIndex = 3
        '
        'MCB_GRUPO
        '
        Me.MCB_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB_GRUPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCB_GRUPO.FormattingEnabled = True
        Me.MCB_GRUPO.Location = New System.Drawing.Point(254, 6)
        Me.MCB_GRUPO.Name = "MCB_GRUPO"
        Me.MCB_GRUPO.Size = New System.Drawing.Size(249, 24)
        Me.MCB_GRUPO.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
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
        'BusAvanzadaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(661, 570)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(677, 608)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(677, 608)
        Me.Name = "BusAvanzadaCliente"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cliente"
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
    Friend WithEvents MCB_COBRADOR As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_VENDEDOR As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_LIMITE_CR As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_CREDITO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_PRECIO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_DENOMINACION As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ZONA As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ESTADO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_GRUPO As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_ESTATUS As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_PUNTOS As MisControles.Controles.MisComboBox
    Friend WithEvents MCB_AFILIACION As MisControles.Controles.MisComboBox
    Friend WithEvents MCHB_ESTATUS As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_PUNTOS As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_AFILIACION As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_CARGO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_DESCUENTO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_COBRADOR As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_VENDEDOR As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_LIMITE As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_CREDITO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_PRECIO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_DENOMINACION As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_ZONA As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_ESTADO As MisControles.Controles.MisCheckBox
    Friend WithEvents MCHB_GRUPO As MisControles.Controles.MisCheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MN_PUNTOS As MisControles.Controles.MisNumeros
    Friend WithEvents MN_LIMITE_CR As MisControles.Controles.MisNumeros
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MCHB_FECHA As MisControles.Controles.MisCheckBox
    Friend WithEvents MF_DESDE As MisControles.Controles.MisFechas
    Friend WithEvents MF_HASTA As MisControles.Controles.MisFechas
    Friend WithEvents MCHB_DIA_COBRANZA As MisControles.Controles.MisCheckBox
    Friend WithEvents MCB_DIA_COBRANZA As MisControles.Controles.MisComboBox
End Class
