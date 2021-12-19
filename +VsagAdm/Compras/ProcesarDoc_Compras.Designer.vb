<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcesarDoc_Compras
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
        Me.Panel14 = New System.Windows.Forms.Panel
        Me.Label23 = New System.Windows.Forms.Label
        Me.MT_NOTAS = New MisControles.Controles.MisTextos
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.BT_PROCESAR = New System.Windows.Forms.Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.MT_SERIE = New MisControles.Controles.MisTextos
        Me.Label17 = New System.Windows.Forms.Label
        Me.MT_ORDEN_COMPRA = New MisControles.Controles.MisTextos
        Me.Label12 = New System.Windows.Forms.Label
        Me.MT_CONTROL = New MisControles.Controles.MisTextos
        Me.Label9 = New System.Windows.Forms.Label
        Me.MT_DOCUMENTO = New MisControles.Controles.MisTextos
        Me.MF_FECHAEMISION = New MisControles.Controles.MisFechas
        Me.E_FECHA_VENCIMIENTO = New System.Windows.Forms.Label
        Me.E_FECHAPROCESO = New System.Windows.Forms.Label
        Me.MN_DIAS_CREDITO = New MisControles.Controles.MisNumeros
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.E_DIRECCION = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.E_NOMBRE = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.E_CODIGO = New System.Windows.Forms.Label
        Me.E_RIF = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(580, 465)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 329.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 251.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel14, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 35)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 302.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(580, 408)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Panel14
        '
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel14.Controls.Add(Me.Label23)
        Me.Panel14.Controls.Add(Me.MT_NOTAS)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(3, 305)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel14.Size = New System.Drawing.Size(323, 100)
        Me.Panel14.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(260, 18)
        Me.Label23.TabIndex = 19
        Me.Label23.Text = "Notas Adicionales Al Documento:"
        '
        'MT_NOTAS
        '
        Me.MT_NOTAS.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_NOTAS.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MT_NOTAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_NOTAS.ForeColor = System.Drawing.Color.Black
        Me.MT_NOTAS.Location = New System.Drawing.Point(2, 36)
        Me.MT_NOTAS.MaxLength = 20
        Me.MT_NOTAS.Multiline = True
        Me.MT_NOTAS.Name = "MT_NOTAS"
        Me.MT_NOTAS.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_NOTAS.p_IniciarComo = True
        Me.MT_NOTAS.Size = New System.Drawing.Size(317, 60)
        Me.MT_NOTAS.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.BT_PROCESAR)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(332, 305)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(20)
        Me.Panel3.Size = New System.Drawing.Size(245, 100)
        Me.Panel3.TabIndex = 4
        '
        'BT_PROCESAR
        '
        Me.BT_PROCESAR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BT_PROCESAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_PROCESAR.Location = New System.Drawing.Point(20, 20)
        Me.BT_PROCESAR.Name = "BT_PROCESAR"
        Me.BT_PROCESAR.Size = New System.Drawing.Size(205, 60)
        Me.BT_PROCESAR.TabIndex = 6
        Me.BT_PROCESAR.Text = "&Procesar / Grabar Documento"
        Me.BT_PROCESAR.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(574, 296)
        Me.Panel4.TabIndex = 5
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 574.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel6, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(574, 296)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(568, 27)
        Me.Panel5.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(568, 27)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DATOS DEL DOCUMENTO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 36)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(568, 257)
        Me.Panel6.TabIndex = 2
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 568.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel7, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel9, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(568, 257)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label3)
        Me.Panel7.Controls.Add(Me.MT_SERIE)
        Me.Panel7.Controls.Add(Me.Label17)
        Me.Panel7.Controls.Add(Me.MT_ORDEN_COMPRA)
        Me.Panel7.Controls.Add(Me.Label12)
        Me.Panel7.Controls.Add(Me.MT_CONTROL)
        Me.Panel7.Controls.Add(Me.Label9)
        Me.Panel7.Controls.Add(Me.MT_DOCUMENTO)
        Me.Panel7.Controls.Add(Me.MF_FECHAEMISION)
        Me.Panel7.Controls.Add(Me.E_FECHA_VENCIMIENTO)
        Me.Panel7.Controls.Add(Me.E_FECHAPROCESO)
        Me.Panel7.Controls.Add(Me.MN_DIAS_CREDITO)
        Me.Panel7.Controls.Add(Me.Label10)
        Me.Panel7.Controls.Add(Me.Label14)
        Me.Panel7.Controls.Add(Me.Label26)
        Me.Panel7.Controls.Add(Me.Label27)
        Me.Panel7.Controls.Add(Me.Label18)
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(562, 120)
        Me.Panel7.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Serie Asignada:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MT_SERIE
        '
        Me.MT_SERIE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_SERIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_SERIE.ForeColor = System.Drawing.Color.Black
        Me.MT_SERIE.Location = New System.Drawing.Point(128, 8)
        Me.MT_SERIE.MaxLength = 10
        Me.MT_SERIE.Name = "MT_SERIE"
        Me.MT_SERIE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_SERIE.p_IniciarComo = True
        Me.MT_SERIE.Size = New System.Drawing.Size(125, 24)
        Me.MT_SERIE.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 82)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(110, 30)
        Me.Label17.TabIndex = 53
        Me.Label17.Text = "Orden Compra Numero:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MT_ORDEN_COMPRA
        '
        Me.MT_ORDEN_COMPRA.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_ORDEN_COMPRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_ORDEN_COMPRA.ForeColor = System.Drawing.Color.Black
        Me.MT_ORDEN_COMPRA.Location = New System.Drawing.Point(128, 85)
        Me.MT_ORDEN_COMPRA.MaxLength = 10
        Me.MT_ORDEN_COMPRA.Name = "MT_ORDEN_COMPRA"
        Me.MT_ORDEN_COMPRA.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_ORDEN_COMPRA.p_IniciarComo = True
        Me.MT_ORDEN_COMPRA.Size = New System.Drawing.Size(125, 24)
        Me.MT_ORDEN_COMPRA.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(19, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 16)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Control Numero:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MT_CONTROL
        '
        Me.MT_CONTROL.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_CONTROL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_CONTROL.ForeColor = System.Drawing.Color.Black
        Me.MT_CONTROL.Location = New System.Drawing.Point(128, 59)
        Me.MT_CONTROL.MaxLength = 15
        Me.MT_CONTROL.Name = "MT_CONTROL"
        Me.MT_CONTROL.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_CONTROL.p_IniciarComo = True
        Me.MT_CONTROL.Size = New System.Drawing.Size(125, 24)
        Me.MT_CONTROL.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 15)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Documento Numero:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MT_DOCUMENTO
        '
        Me.MT_DOCUMENTO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_DOCUMENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MT_DOCUMENTO.ForeColor = System.Drawing.Color.Black
        Me.MT_DOCUMENTO.Location = New System.Drawing.Point(128, 33)
        Me.MT_DOCUMENTO.MaxLength = 15
        Me.MT_DOCUMENTO.Name = "MT_DOCUMENTO"
        Me.MT_DOCUMENTO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_DOCUMENTO.p_IniciarComo = True
        Me.MT_DOCUMENTO.Size = New System.Drawing.Size(125, 24)
        Me.MT_DOCUMENTO.TabIndex = 1
        '
        'MF_FECHAEMISION
        '
        Me.MF_FECHAEMISION.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MF_FECHAEMISION.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MF_FECHAEMISION.ForeColor = System.Drawing.Color.Black
        Me.MF_FECHAEMISION.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MF_FECHAEMISION.Location = New System.Drawing.Point(431, 12)
        Me.MF_FECHAEMISION.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MF_FECHAEMISION.MaximumSize = New System.Drawing.Size(125, 24)
        Me.MF_FECHAEMISION.MinimumSize = New System.Drawing.Size(125, 24)
        Me.MF_FECHAEMISION.Name = "MF_FECHAEMISION"
        Me.MF_FECHAEMISION.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MF_FECHAEMISION.p_IniciarComo = True
        Me.MF_FECHAEMISION.Size = New System.Drawing.Size(125, 24)
        Me.MF_FECHAEMISION.TabIndex = 4
        Me.MF_FECHAEMISION.Value = New Date(2020, 12, 31, 0, 0, 0, 0)
        '
        'E_FECHA_VENCIMIENTO
        '
        Me.E_FECHA_VENCIMIENTO.AutoSize = True
        Me.E_FECHA_VENCIMIENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_FECHA_VENCIMIENTO.Location = New System.Drawing.Point(428, 91)
        Me.E_FECHA_VENCIMIENTO.Name = "E_FECHA_VENCIMIENTO"
        Me.E_FECHA_VENCIMIENTO.Size = New System.Drawing.Size(66, 18)
        Me.E_FECHA_VENCIMIENTO.TabIndex = 47
        Me.E_FECHA_VENCIMIENTO.Text = "Label30"
        '
        'E_FECHAPROCESO
        '
        Me.E_FECHAPROCESO.AutoSize = True
        Me.E_FECHAPROCESO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_FECHAPROCESO.Location = New System.Drawing.Point(428, 43)
        Me.E_FECHAPROCESO.Name = "E_FECHAPROCESO"
        Me.E_FECHAPROCESO.Size = New System.Drawing.Size(66, 18)
        Me.E_FECHAPROCESO.TabIndex = 46
        Me.E_FECHAPROCESO.Text = "Label29"
        '
        'MN_DIAS_CREDITO
        '
        Me.MN_DIAS_CREDITO._ConSigno = False
        Me.MN_DIAS_CREDITO._Formato = ""
        Me.MN_DIAS_CREDITO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MN_DIAS_CREDITO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MN_DIAS_CREDITO.ForeColor = System.Drawing.Color.Black
        Me.MN_DIAS_CREDITO.Location = New System.Drawing.Point(431, 64)
        Me.MN_DIAS_CREDITO.Name = "MN_DIAS_CREDITO"
        Me.MN_DIAS_CREDITO.Size = New System.Drawing.Size(62, 24)
        Me.MN_DIAS_CREDITO.TabIndex = 5
        Me.MN_DIAS_CREDITO.Text = "0"
        Me.MN_DIAS_CREDITO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(500, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 16)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Dias"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(319, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 16)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Dias De Credito:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(301, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(124, 16)
        Me.Label26.TabIndex = 39
        Me.Label26.Text = "Fecha De Proceso:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(299, 93)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 16)
        Me.Label27.TabIndex = 42
        Me.Label27.Text = "Fecha Vencimiento:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(289, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(136, 36)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Fecha Emision Documento:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Black
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 119)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(562, 1)
        Me.Panel8.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Controls.Add(Me.E_DIRECCION)
        Me.Panel9.Controls.Add(Me.Label15)
        Me.Panel9.Controls.Add(Me.E_NOMBRE)
        Me.Panel9.Controls.Add(Me.Label13)
        Me.Panel9.Controls.Add(Me.E_CODIGO)
        Me.Panel9.Controls.Add(Me.E_RIF)
        Me.Panel9.Controls.Add(Me.Label11)
        Me.Panel9.Controls.Add(Me.Label8)
        Me.Panel9.Controls.Add(Me.Label6)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 129)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(562, 125)
        Me.Panel9.TabIndex = 1
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Black
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 124)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(562, 1)
        Me.Panel10.TabIndex = 29
        '
        'E_DIRECCION
        '
        Me.E_DIRECCION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_DIRECCION.Location = New System.Drawing.Point(92, 88)
        Me.E_DIRECCION.Name = "E_DIRECCION"
        Me.E_DIRECCION.Size = New System.Drawing.Size(440, 31)
        Me.E_DIRECCION.TabIndex = 28
        Me.E_DIRECCION.Text = "DIRECCIÓN DEL PROVEEDOR " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "EN DOS LINEAS"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 16)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Dir. Fiscal:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_NOMBRE
        '
        Me.E_NOMBRE.BackColor = System.Drawing.Color.WhiteSmoke
        Me.E_NOMBRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_NOMBRE.Location = New System.Drawing.Point(92, 51)
        Me.E_NOMBRE.Name = "E_NOMBRE"
        Me.E_NOMBRE.Size = New System.Drawing.Size(440, 31)
        Me.E_NOMBRE.TabIndex = 26
        Me.E_NOMBRE.Text = "NOMBRE DEL PROVEEDOR " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "EN DOS LINEAS"
        Me.E_NOMBRE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(23, 51)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 16)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Nombre:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'E_CODIGO
        '
        Me.E_CODIGO.AutoSize = True
        Me.E_CODIGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_CODIGO.Location = New System.Drawing.Point(310, 27)
        Me.E_CODIGO.Name = "E_CODIGO"
        Me.E_CODIGO.Size = New System.Drawing.Size(159, 20)
        Me.E_CODIGO.TabIndex = 24
        Me.E_CODIGO.Text = "123456789012345"
        '
        'E_RIF
        '
        Me.E_RIF.AutoSize = True
        Me.E_RIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E_RIF.Location = New System.Drawing.Point(91, 27)
        Me.E_RIF.Name = "E_RIF"
        Me.E_RIF.Size = New System.Drawing.Size(120, 20)
        Me.E_RIF.TabIndex = 23
        Me.E_RIF.Text = "J-12345678-9"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(241, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "CODIGO:"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(29, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "CI / RIF:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Datos Del Proveedor:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 443)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(580, 22)
        Me.StatusStrip1.TabIndex = 2
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
        Me.Panel2.BackColor = System.Drawing.Color.DarkRed
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(580, 35)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Procesar Documento !!!"
        '
        'ProcesarDoc_Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(584, 469)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 507)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 507)
        Me.Name = "ProcesarDoc_Compras"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "."
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents MT_NOTAS As MisControles.Controles.MisTextos
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BT_PROCESAR As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents MT_ORDEN_COMPRA As MisControles.Controles.MisTextos
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents MT_CONTROL As MisControles.Controles.MisTextos
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MT_DOCUMENTO As MisControles.Controles.MisTextos
    Friend WithEvents MF_FECHAEMISION As MisControles.Controles.MisFechas
    Friend WithEvents E_FECHA_VENCIMIENTO As System.Windows.Forms.Label
    Friend WithEvents E_FECHAPROCESO As System.Windows.Forms.Label
    Friend WithEvents MN_DIAS_CREDITO As MisControles.Controles.MisNumeros
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents E_DIRECCION As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents E_NOMBRE As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents E_CODIGO As System.Windows.Forms.Label
    Friend WithEvents E_RIF As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MT_SERIE As MisControles.Controles.MisTextos
End Class
