<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportesVarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportesVarios))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.AlmacenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AlmacenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ALM_PRECIOS = New System.Windows.Forms.ToolStripMenuItem
        Me.ALM_EXISTENCIA = New System.Windows.Forms.ToolStripMenuItem
        Me.ALM_KARDEX = New System.Windows.Forms.ToolStripMenuItem
        Me.VentasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.VENTA_LIBRO = New System.Windows.Forms.ToolStripMenuItem
        Me.VENTA_CONSOLIDADO = New System.Windows.Forms.ToolStripMenuItem
        Me.VENTA_UTILIDAD = New System.Windows.Forms.ToolStripMenuItem
        Me.VendedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VENDEDOR_COMISION = New System.Windows.Forms.ToolStripMenuItem
        Me.CuentasPorCobrarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CXC_COBRANZADIA = New System.Windows.Forms.ToolStripMenuItem
        Me.CXC_DOCUMENTOSPEND = New System.Windows.Forms.ToolStripMenuItem
        Me.FiscalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FISCAL_X = New System.Windows.Forms.ToolStripMenuItem
        Me.FISCAL_Z = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ComprasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.LIBRO_COMPRAS = New System.Windows.Forms.ToolStripMenuItem
        Me.GENERAL_COMPRAS = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(2, 258)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(295, 22)
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
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.PictureBox1)
        Me.ToolStripContainer1.ContentPanel.Padding = New System.Windows.Forms.Padding(6)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(295, 228)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(2, 2)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(295, 256)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global._VsagAdm.My.Resources.Resources.IMPRESORA
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(283, 216)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlmacenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(295, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AlmacenToolStripMenuItem
        '
        Me.AlmacenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlmacenToolStripMenuItem1, Me.VentasToolStripMenuItem1, Me.VendedoresToolStripMenuItem, Me.CuentasPorCobrarToolStripMenuItem1, Me.FiscalToolStripMenuItem, Me.ToolStripSeparator1, Me.ComprasToolStripMenuItem1})
        Me.AlmacenToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlmacenToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AlmacenToolStripMenuItem.Image = Global._VsagAdm.My.Resources.Resources.printer_2
        Me.AlmacenToolStripMenuItem.Name = "AlmacenToolStripMenuItem"
        Me.AlmacenToolStripMenuItem.Size = New System.Drawing.Size(95, 24)
        Me.AlmacenToolStripMenuItem.Text = "Modulos"
        '
        'AlmacenToolStripMenuItem1
        '
        Me.AlmacenToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ALM_PRECIOS, Me.ALM_EXISTENCIA, Me.ALM_KARDEX})
        Me.AlmacenToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlmacenToolStripMenuItem1.Image = CType(resources.GetObject("AlmacenToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.AlmacenToolStripMenuItem1.Name = "AlmacenToolStripMenuItem1"
        Me.AlmacenToolStripMenuItem1.Size = New System.Drawing.Size(205, 24)
        Me.AlmacenToolStripMenuItem1.Text = "Almacen"
        '
        'ALM_PRECIOS
        '
        Me.ALM_PRECIOS.Image = CType(resources.GetObject("ALM_PRECIOS.Image"), System.Drawing.Image)
        Me.ALM_PRECIOS.Name = "ALM_PRECIOS"
        Me.ALM_PRECIOS.Size = New System.Drawing.Size(182, 24)
        Me.ALM_PRECIOS.Text = "Lista De Precios"
        '
        'ALM_EXISTENCIA
        '
        Me.ALM_EXISTENCIA.Image = CType(resources.GetObject("ALM_EXISTENCIA.Image"), System.Drawing.Image)
        Me.ALM_EXISTENCIA.Name = "ALM_EXISTENCIA"
        Me.ALM_EXISTENCIA.Size = New System.Drawing.Size(182, 24)
        Me.ALM_EXISTENCIA.Text = "Existencias"
        '
        'ALM_KARDEX
        '
        Me.ALM_KARDEX.Image = CType(resources.GetObject("ALM_KARDEX.Image"), System.Drawing.Image)
        Me.ALM_KARDEX.Name = "ALM_KARDEX"
        Me.ALM_KARDEX.Size = New System.Drawing.Size(182, 24)
        Me.ALM_KARDEX.Text = "Kardex"
        '
        'VentasToolStripMenuItem1
        '
        Me.VentasToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VENTA_LIBRO, Me.VENTA_CONSOLIDADO, Me.VENTA_UTILIDAD})
        Me.VentasToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VentasToolStripMenuItem1.Image = CType(resources.GetObject("VentasToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.VentasToolStripMenuItem1.Name = "VentasToolStripMenuItem1"
        Me.VentasToolStripMenuItem1.Size = New System.Drawing.Size(205, 24)
        Me.VentasToolStripMenuItem1.Text = "Ventas"
        '
        'VENTA_LIBRO
        '
        Me.VENTA_LIBRO.Image = CType(resources.GetObject("VENTA_LIBRO.Image"), System.Drawing.Image)
        Me.VENTA_LIBRO.Name = "VENTA_LIBRO"
        Me.VENTA_LIBRO.Size = New System.Drawing.Size(231, 24)
        Me.VENTA_LIBRO.Text = "Libro De Ventas"
        '
        'VENTA_CONSOLIDADO
        '
        Me.VENTA_CONSOLIDADO.Image = CType(resources.GetObject("VENTA_CONSOLIDADO.Image"), System.Drawing.Image)
        Me.VENTA_CONSOLIDADO.Name = "VENTA_CONSOLIDADO"
        Me.VENTA_CONSOLIDADO.Size = New System.Drawing.Size(231, 24)
        Me.VENTA_CONSOLIDADO.Text = "Consolidado de Ventas"
        '
        'VENTA_UTILIDAD
        '
        Me.VENTA_UTILIDAD.Image = CType(resources.GetObject("VENTA_UTILIDAD.Image"), System.Drawing.Image)
        Me.VENTA_UTILIDAD.Name = "VENTA_UTILIDAD"
        Me.VENTA_UTILIDAD.Size = New System.Drawing.Size(231, 24)
        Me.VENTA_UTILIDAD.Text = "Utilidad / Ganancias"
        '
        'VendedoresToolStripMenuItem
        '
        Me.VendedoresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VENDEDOR_COMISION})
        Me.VendedoresToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VendedoresToolStripMenuItem.Image = CType(resources.GetObject("VendedoresToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VendedoresToolStripMenuItem.Name = "VendedoresToolStripMenuItem"
        Me.VendedoresToolStripMenuItem.Size = New System.Drawing.Size(205, 24)
        Me.VendedoresToolStripMenuItem.Text = "Vendedores"
        '
        'VENDEDOR_COMISION
        '
        Me.VENDEDOR_COMISION.Image = Global._VsagAdm.My.Resources.Resources.printer_2
        Me.VENDEDOR_COMISION.Name = "VENDEDOR_COMISION"
        Me.VENDEDOR_COMISION.Size = New System.Drawing.Size(150, 24)
        Me.VENDEDOR_COMISION.Text = "Comsiones"
        '
        'CuentasPorCobrarToolStripMenuItem1
        '
        Me.CuentasPorCobrarToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CXC_COBRANZADIA, Me.CXC_DOCUMENTOSPEND})
        Me.CuentasPorCobrarToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CuentasPorCobrarToolStripMenuItem1.Image = CType(resources.GetObject("CuentasPorCobrarToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.CuentasPorCobrarToolStripMenuItem1.Name = "CuentasPorCobrarToolStripMenuItem1"
        Me.CuentasPorCobrarToolStripMenuItem1.Size = New System.Drawing.Size(205, 24)
        Me.CuentasPorCobrarToolStripMenuItem1.Text = "Cuentas Por Cobrar"
        '
        'CXC_COBRANZADIA
        '
        Me.CXC_COBRANZADIA.Image = CType(resources.GetObject("CXC_COBRANZADIA.Image"), System.Drawing.Image)
        Me.CXC_COBRANZADIA.Name = "CXC_COBRANZADIA"
        Me.CXC_COBRANZADIA.Size = New System.Drawing.Size(237, 24)
        Me.CXC_COBRANZADIA.Text = "Cobranza Del Dia"
        '
        'CXC_DOCUMENTOSPEND
        '
        Me.CXC_DOCUMENTOSPEND.Image = CType(resources.GetObject("CXC_DOCUMENTOSPEND.Image"), System.Drawing.Image)
        Me.CXC_DOCUMENTOSPEND.Name = "CXC_DOCUMENTOSPEND"
        Me.CXC_DOCUMENTOSPEND.Size = New System.Drawing.Size(237, 24)
        Me.CXC_DOCUMENTOSPEND.Text = "Documentos Por Cobrar"
        '
        'FiscalToolStripMenuItem
        '
        Me.FiscalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FISCAL_X, Me.FISCAL_Z})
        Me.FiscalToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FiscalToolStripMenuItem.Image = CType(resources.GetObject("FiscalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FiscalToolStripMenuItem.Name = "FiscalToolStripMenuItem"
        Me.FiscalToolStripMenuItem.Size = New System.Drawing.Size(205, 24)
        Me.FiscalToolStripMenuItem.Text = "Fiscal"
        '
        'FISCAL_X
        '
        Me.FISCAL_X.Image = CType(resources.GetObject("FISCAL_X.Image"), System.Drawing.Image)
        Me.FISCAL_X.Name = "FISCAL_X"
        Me.FISCAL_X.Size = New System.Drawing.Size(144, 24)
        Me.FISCAL_X.Text = "Reporte X"
        '
        'FISCAL_Z
        '
        Me.FISCAL_Z.Image = CType(resources.GetObject("FISCAL_Z.Image"), System.Drawing.Image)
        Me.FISCAL_Z.Name = "FISCAL_Z"
        Me.FISCAL_Z.Size = New System.Drawing.Size(144, 24)
        Me.FISCAL_Z.Text = "Reporte Z"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(202, 6)
        '
        'ComprasToolStripMenuItem1
        '
        Me.ComprasToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LIBRO_COMPRAS, Me.GENERAL_COMPRAS})
        Me.ComprasToolStripMenuItem1.Image = Global._VsagAdm.My.Resources.Resources.printer_2
        Me.ComprasToolStripMenuItem1.Name = "ComprasToolStripMenuItem1"
        Me.ComprasToolStripMenuItem1.Size = New System.Drawing.Size(205, 24)
        Me.ComprasToolStripMenuItem1.Text = "Compras"
        '
        'LIBRO_COMPRAS
        '
        Me.LIBRO_COMPRAS.Image = CType(resources.GetObject("LIBRO_COMPRAS.Image"), System.Drawing.Image)
        Me.LIBRO_COMPRAS.Name = "LIBRO_COMPRAS"
        Me.LIBRO_COMPRAS.Size = New System.Drawing.Size(360, 24)
        Me.LIBRO_COMPRAS.Text = "Libro De Compras"
        '
        'GENERAL_COMPRAS
        '
        Me.GENERAL_COMPRAS.Image = CType(resources.GetObject("GENERAL_COMPRAS.Image"), System.Drawing.Image)
        Me.GENERAL_COMPRAS.Name = "GENERAL_COMPRAS"
        Me.GENERAL_COMPRAS.Size = New System.Drawing.Size(360, 24)
        Me.GENERAL_COMPRAS.Text = "Reporte General Documentos De Compras"
        '
        'ReportesVarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 282)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(315, 320)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(315, 320)
        Me.Name = "ReportesVarios"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso Rapido A Reportes"
        Me.TopMost = True
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AlmacenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlmacenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VendedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuentasPorCobrarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiscalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ALM_KARDEX As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ALM_PRECIOS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENTA_LIBRO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENTA_CONSOLIDADO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENDEDOR_COMISION As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FISCAL_X As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FISCAL_Z As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ALM_EXISTENCIA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENTA_UTILIDAD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CXC_COBRANZADIA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CXC_DOCUMENTOSPEND As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ComprasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LIBRO_COMPRAS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GENERAL_COMPRAS As System.Windows.Forms.ToolStripMenuItem
End Class
