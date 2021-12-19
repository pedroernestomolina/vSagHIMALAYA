<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichaNegocio
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BT_ACTUALIZAR = New System.Windows.Forms.Button
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.BT_GRABAR = New System.Windows.Forms.Button
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.MT_CEL2 = New MisControles.Controles.MisTelefonos
        Me.MT_CEL1 = New MisControles.Controles.MisTelefonos
        Me.MT_FAX2 = New MisControles.Controles.MisTelefonos
        Me.MT_FAX1 = New MisControles.Controles.MisTelefonos
        Me.MT_TEL4 = New MisControles.Controles.MisTelefonos
        Me.MT_TEL3 = New MisControles.Controles.MisTelefonos
        Me.MT_TEL2 = New MisControles.Controles.MisTelefonos
        Me.MT_TEL1 = New MisControles.Controles.MisTelefonos
        Me.MT_WEBSITE = New MisControles.Controles.MisSite
        Me.MT_EMAIL = New MisControles.Controles.MisEmail
        Me.Label18 = New System.Windows.Forms.Label
        Me.MT_SUCURSAL = New MisControles.Controles.MisTextos
        Me.Label17 = New System.Windows.Forms.Label
        Me.MT_CODSUCURSAL = New MisControles.Controles.MisTextos
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.MT_CONTACTO = New MisControles.Controles.MisTextos
        Me.Label5 = New System.Windows.Forms.Label
        Me.MT_DIRREF = New MisControles.Controles.MisTextos
        Me.Label4 = New System.Windows.Forms.Label
        Me.MT_DIRFISCAL = New MisControles.Controles.MisTextos
        Me.MT_RAZONSOCIAL = New MisControles.Controles.MisTextos
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.MT_RIF = New MisControles.Controles.MisRifCI
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(768, 516)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 39)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.8427!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.1573!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(766, 453)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.AliceBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.BT_ACTUALIZAR)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.BT_GRABAR)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 391)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(760, 59)
        Me.Panel4.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global._VsagAdm.My.Resources.Resources.ActualizarDatosNegocio_1
        Me.PictureBox1.Location = New System.Drawing.Point(4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(78, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'BT_ACTUALIZAR
        '
        Me.BT_ACTUALIZAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_ACTUALIZAR.Location = New System.Drawing.Point(488, 7)
        Me.BT_ACTUALIZAR.Name = "BT_ACTUALIZAR"
        Me.BT_ACTUALIZAR.Size = New System.Drawing.Size(120, 47)
        Me.BT_ACTUALIZAR.TabIndex = 2
        Me.BT_ACTUALIZAR.Text = "&Actualizar Datos"
        Me.BT_ACTUALIZAR.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Navy
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(760, 2)
        Me.Panel6.TabIndex = 1
        '
        'BT_GRABAR
        '
        Me.BT_GRABAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GRABAR.Location = New System.Drawing.Point(614, 7)
        Me.BT_GRABAR.Name = "BT_GRABAR"
        Me.BT_GRABAR.Size = New System.Drawing.Size(120, 47)
        Me.BT_GRABAR.TabIndex = 0
        Me.BT_GRABAR.Text = "&Guardar Datos"
        Me.BT_GRABAR.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel5, 2)
        Me.Panel5.Controls.Add(Me.MT_RIF)
        Me.Panel5.Controls.Add(Me.MT_CEL2)
        Me.Panel5.Controls.Add(Me.MT_CEL1)
        Me.Panel5.Controls.Add(Me.MT_FAX2)
        Me.Panel5.Controls.Add(Me.MT_FAX1)
        Me.Panel5.Controls.Add(Me.MT_TEL4)
        Me.Panel5.Controls.Add(Me.MT_TEL3)
        Me.Panel5.Controls.Add(Me.MT_TEL2)
        Me.Panel5.Controls.Add(Me.MT_TEL1)
        Me.Panel5.Controls.Add(Me.MT_WEBSITE)
        Me.Panel5.Controls.Add(Me.MT_EMAIL)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.MT_SUCURSAL)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.MT_CODSUCURSAL)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.MT_CONTACTO)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.MT_DIRREF)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.MT_DIRFISCAL)
        Me.Panel5.Controls.Add(Me.MT_RAZONSOCIAL)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.ShapeContainer1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(760, 382)
        Me.Panel5.TabIndex = 1
        '
        'MT_CEL2
        '
        Me.MT_CEL2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_CEL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_CEL2.ForeColor = System.Drawing.Color.Black
        Me.MT_CEL2.Location = New System.Drawing.Point(523, 223)
        Me.MT_CEL2.MaxLength = 14
        Me.MT_CEL2.Name = "MT_CEL2"
        Me.MT_CEL2.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_CEL2.p_IniciarComo = True
        Me.MT_CEL2.Size = New System.Drawing.Size(211, 24)
        Me.MT_CEL2.TabIndex = 11
        '
        'MT_CEL1
        '
        Me.MT_CEL1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_CEL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_CEL1.ForeColor = System.Drawing.Color.Black
        Me.MT_CEL1.Location = New System.Drawing.Point(143, 223)
        Me.MT_CEL1.MaxLength = 14
        Me.MT_CEL1.Name = "MT_CEL1"
        Me.MT_CEL1.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_CEL1.p_IniciarComo = True
        Me.MT_CEL1.Size = New System.Drawing.Size(211, 24)
        Me.MT_CEL1.TabIndex = 10
        '
        'MT_FAX2
        '
        Me.MT_FAX2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_FAX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_FAX2.ForeColor = System.Drawing.Color.Black
        Me.MT_FAX2.Location = New System.Drawing.Point(523, 199)
        Me.MT_FAX2.MaxLength = 14
        Me.MT_FAX2.Name = "MT_FAX2"
        Me.MT_FAX2.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_FAX2.p_IniciarComo = True
        Me.MT_FAX2.Size = New System.Drawing.Size(211, 24)
        Me.MT_FAX2.TabIndex = 9
        '
        'MT_FAX1
        '
        Me.MT_FAX1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_FAX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_FAX1.ForeColor = System.Drawing.Color.Black
        Me.MT_FAX1.Location = New System.Drawing.Point(143, 199)
        Me.MT_FAX1.MaxLength = 14
        Me.MT_FAX1.Name = "MT_FAX1"
        Me.MT_FAX1.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_FAX1.p_IniciarComo = True
        Me.MT_FAX1.Size = New System.Drawing.Size(211, 24)
        Me.MT_FAX1.TabIndex = 8
        '
        'MT_TEL4
        '
        Me.MT_TEL4.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_TEL4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_TEL4.ForeColor = System.Drawing.Color.Black
        Me.MT_TEL4.Location = New System.Drawing.Point(523, 175)
        Me.MT_TEL4.MaxLength = 14
        Me.MT_TEL4.Name = "MT_TEL4"
        Me.MT_TEL4.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_TEL4.p_IniciarComo = True
        Me.MT_TEL4.Size = New System.Drawing.Size(211, 24)
        Me.MT_TEL4.TabIndex = 7
        '
        'MT_TEL3
        '
        Me.MT_TEL3.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_TEL3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_TEL3.ForeColor = System.Drawing.Color.Black
        Me.MT_TEL3.Location = New System.Drawing.Point(143, 175)
        Me.MT_TEL3.MaxLength = 14
        Me.MT_TEL3.Name = "MT_TEL3"
        Me.MT_TEL3.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_TEL3.p_IniciarComo = True
        Me.MT_TEL3.Size = New System.Drawing.Size(211, 24)
        Me.MT_TEL3.TabIndex = 6
        '
        'MT_TEL2
        '
        Me.MT_TEL2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_TEL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_TEL2.ForeColor = System.Drawing.Color.Black
        Me.MT_TEL2.Location = New System.Drawing.Point(523, 151)
        Me.MT_TEL2.MaxLength = 14
        Me.MT_TEL2.Name = "MT_TEL2"
        Me.MT_TEL2.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_TEL2.p_IniciarComo = True
        Me.MT_TEL2.Size = New System.Drawing.Size(211, 24)
        Me.MT_TEL2.TabIndex = 5
        '
        'MT_TEL1
        '
        Me.MT_TEL1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_TEL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_TEL1.ForeColor = System.Drawing.Color.Black
        Me.MT_TEL1.Location = New System.Drawing.Point(143, 151)
        Me.MT_TEL1.MaxLength = 14
        Me.MT_TEL1.Name = "MT_TEL1"
        Me.MT_TEL1.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_TEL1.p_IniciarComo = True
        Me.MT_TEL1.Size = New System.Drawing.Size(211, 24)
        Me.MT_TEL1.TabIndex = 4
        '
        'MT_WEBSITE
        '
        Me.MT_WEBSITE.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_WEBSITE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_WEBSITE.ForeColor = System.Drawing.Color.Black
        Me.MT_WEBSITE.Location = New System.Drawing.Point(143, 280)
        Me.MT_WEBSITE.MaxLength = 20
        Me.MT_WEBSITE.Name = "MT_WEBSITE"
        Me.MT_WEBSITE.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_WEBSITE.p_IniciarComo = True
        Me.MT_WEBSITE.Size = New System.Drawing.Size(591, 24)
        Me.MT_WEBSITE.TabIndex = 13
        '
        'MT_EMAIL
        '
        Me.MT_EMAIL.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_EMAIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_EMAIL.ForeColor = System.Drawing.Color.Black
        Me.MT_EMAIL.Location = New System.Drawing.Point(143, 256)
        Me.MT_EMAIL.MaxLength = 20
        Me.MT_EMAIL.Name = "MT_EMAIL"
        Me.MT_EMAIL.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_EMAIL.p_IniciarComo = True
        Me.MT_EMAIL.Size = New System.Drawing.Size(591, 24)
        Me.MT_EMAIL.TabIndex = 12
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(67, 355)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 18)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Sucursal:"
        '
        'MT_SUCURSAL
        '
        Me.MT_SUCURSAL.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_SUCURSAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_SUCURSAL.ForeColor = System.Drawing.Color.Black
        Me.MT_SUCURSAL.Location = New System.Drawing.Point(143, 352)
        Me.MT_SUCURSAL.MaxLength = 20
        Me.MT_SUCURSAL.Name = "MT_SUCURSAL"
        Me.MT_SUCURSAL.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_SUCURSAL.p_IniciarComo = True
        Me.MT_SUCURSAL.Size = New System.Drawing.Size(591, 24)
        Me.MT_SUCURSAL.TabIndex = 16
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(15, 331)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 18)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Codigo Sucursal:"
        '
        'MT_CODSUCURSAL
        '
        Me.MT_CODSUCURSAL.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_CODSUCURSAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_CODSUCURSAL.ForeColor = System.Drawing.Color.Black
        Me.MT_CODSUCURSAL.Location = New System.Drawing.Point(143, 328)
        Me.MT_CODSUCURSAL.MaxLength = 20
        Me.MT_CODSUCURSAL.Name = "MT_CODSUCURSAL"
        Me.MT_CODSUCURSAL.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_CODSUCURSAL.p_IniciarComo = True
        Me.MT_CODSUCURSAL.Size = New System.Drawing.Size(211, 24)
        Me.MT_CODSUCURSAL.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(47, 307)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 18)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Contactar A:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(69, 283)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 18)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "WebSite:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(88, 259)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 18)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Email:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(437, 226)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 18)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Celular (2):"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(57, 226)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 18)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Celular (1):"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(459, 202)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 18)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Fax (2):"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(79, 202)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 18)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Fax (1):"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(421, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 18)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Telefonos(4):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(41, 178)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 18)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Telefonos(3):"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(421, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 18)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Telefonos(2):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(41, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 18)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Telefonos(1):"
        '
        'MT_CONTACTO
        '
        Me.MT_CONTACTO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_CONTACTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_CONTACTO.ForeColor = System.Drawing.Color.Black
        Me.MT_CONTACTO.Location = New System.Drawing.Point(143, 304)
        Me.MT_CONTACTO.MaxLength = 20
        Me.MT_CONTACTO.Name = "MT_CONTACTO"
        Me.MT_CONTACTO.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_CONTACTO.p_IniciarComo = True
        Me.MT_CONTACTO.Size = New System.Drawing.Size(591, 24)
        Me.MT_CONTACTO.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 42)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Punto De Referencia:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MT_DIRREF
        '
        Me.MT_DIRREF.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_DIRREF.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_DIRREF.ForeColor = System.Drawing.Color.Black
        Me.MT_DIRREF.Location = New System.Drawing.Point(143, 106)
        Me.MT_DIRREF.MaxLength = 20
        Me.MT_DIRREF.Multiline = True
        Me.MT_DIRREF.Name = "MT_DIRREF"
        Me.MT_DIRREF.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_DIRREF.p_IniciarComo = True
        Me.MT_DIRREF.Size = New System.Drawing.Size(591, 45)
        Me.MT_DIRREF.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 18)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Direccion Fiscal:"
        '
        'MT_DIRFISCAL
        '
        Me.MT_DIRFISCAL.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_DIRFISCAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_DIRFISCAL.ForeColor = System.Drawing.Color.Black
        Me.MT_DIRFISCAL.Location = New System.Drawing.Point(143, 61)
        Me.MT_DIRFISCAL.MaxLength = 20
        Me.MT_DIRFISCAL.Multiline = True
        Me.MT_DIRFISCAL.Name = "MT_DIRFISCAL"
        Me.MT_DIRFISCAL.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_DIRFISCAL.p_IniciarComo = True
        Me.MT_DIRFISCAL.Size = New System.Drawing.Size(591, 45)
        Me.MT_DIRFISCAL.TabIndex = 2
        '
        'MT_RAZONSOCIAL
        '
        Me.MT_RAZONSOCIAL.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_RAZONSOCIAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_RAZONSOCIAL.ForeColor = System.Drawing.Color.Black
        Me.MT_RAZONSOCIAL.Location = New System.Drawing.Point(143, 13)
        Me.MT_RAZONSOCIAL.MaxLength = 20
        Me.MT_RAZONSOCIAL.Name = "MT_RAZONSOCIAL"
        Me.MT_RAZONSOCIAL.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_RAZONSOCIAL.p_IniciarComo = True
        Me.MT_RAZONSOCIAL.Size = New System.Drawing.Size(591, 24)
        Me.MT_RAZONSOCIAL.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(102, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "RIF:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Razon Social:"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(760, 382)
        Me.ShapeContainer1.TabIndex = 34
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 147
        Me.LineShape1.X2 = 730
        Me.LineShape1.Y1 = 251
        Me.LineShape1.Y2 = 251
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(766, 39)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(766, 3)
        Me.Panel3.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(389, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Datos De Identificacion De La Empresa ?"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 492)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(766, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(222, 17)
        Me.ToolStripStatusLabel1.Text = "Presione La Tecla <Esc> Para Salir"
        '
        'MT_RIF
        '
        Me.MT_RIF.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MT_RIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MT_RIF.ForeColor = System.Drawing.Color.Black
        Me.MT_RIF.Location = New System.Drawing.Point(143, 37)
        Me.MT_RIF.MaxLength = 12
        Me.MT_RIF.Name = "MT_RIF"
        Me.MT_RIF.p_ColorInicio = System.Drawing.Color.DarkSeaGreen
        Me.MT_RIF.p_IniciarComo = True
        Me.MT_RIF.Size = New System.Drawing.Size(211, 24)
        Me.MT_RIF.TabIndex = 1
        '
        'FichaNegocio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(774, 522)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(790, 560)
        Me.Name = "FichaNegocio"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuracion"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BT_GRABAR As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MT_RAZONSOCIAL As MisControles.Controles.MisTextos
    Friend WithEvents MT_CONTACTO As MisControles.Controles.MisTextos
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MT_DIRREF As MisControles.Controles.MisTextos
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MT_DIRFISCAL As MisControles.Controles.MisTextos
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents MT_SUCURSAL As MisControles.Controles.MisTextos
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents MT_CODSUCURSAL As MisControles.Controles.MisTextos
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents BT_ACTUALIZAR As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents MT_WEBSITE As MisControles.Controles.MisSite
    Friend WithEvents MT_EMAIL As MisControles.Controles.MisEmail
    Friend WithEvents MT_FAX2 As MisControles.Controles.MisTelefonos
    Friend WithEvents MT_FAX1 As MisControles.Controles.MisTelefonos
    Friend WithEvents MT_TEL4 As MisControles.Controles.MisTelefonos
    Friend WithEvents MT_TEL3 As MisControles.Controles.MisTelefonos
    Friend WithEvents MT_TEL2 As MisControles.Controles.MisTelefonos
    Friend WithEvents MT_TEL1 As MisControles.Controles.MisTelefonos
    Friend WithEvents MT_CEL2 As MisControles.Controles.MisTelefonos
    Friend WithEvents MT_CEL1 As MisControles.Controles.MisTelefonos
    Friend WithEvents MT_RIF As MisControles.Controles.MisRifCI
End Class
