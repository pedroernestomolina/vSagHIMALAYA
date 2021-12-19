Imports DataSistema.MiDataSistema.DataSistema
Imports MisControles.Controles
Imports System.Data.SqlClient
Imports System.Collections

Public Class PlantillaFiltroGenerarRetenciones
    Dim xplantilla As IPlantillaFiltroGenerarRetenciones
    Dim xmeses As String() = {"Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"}
    Dim xperiodo As String() = {"1era Quinc", "2da Quinc"}

    Dim xest_salida As Boolean

    Property EstatusSalida() As Boolean
        Get
            Return xest_salida
        End Get
        Set(ByVal value As Boolean)
            xest_salida = value
        End Set
    End Property

    Private Sub PlantillaFiltroReporteVentas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Sub Inicializa()
        Try
            _MiPLantilla.Inicializa(Me)

            Me.N_ANO.Value = Year(g_MiData.p_FechaDelMotorBD)
            With Me.MCB_MES
                .DataSource = xmeses
                .SelectedIndex = Month(g_MiData.p_FechaDelMotorBD) - 1
            End With
            With Me.MCB_PERIODO
                .DataSource = xperiodo
                .SelectedIndex = RetornarPeriodoRetencion(g_MiData.p_FechaDelMotorBD) - 1
            End With


            BT_BUSCARRUTA.Select()
            BT_BUSCARRUTA.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Property _MiPLantilla() As IPlantillaFiltroGenerarRetenciones
        Get
            Return xplantilla
        End Get
        Set(ByVal value As IPlantillaFiltroGenerarRetenciones)
            xplantilla = value
        End Set
    End Property

    Sub New(ByVal xplantilla As IPlantillaFiltroGenerarRetenciones)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiPLantilla = xplantilla
    End Sub

    Private Sub PlantillaFiltroGenerarRetenciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me.ToolTip1
            .Active = True
            .AutomaticDelay = 100
            .AutoPopDelay = 5000
        End With
    End Sub

    Private Sub PlantillaFiltroReporteVentas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCARRUTA.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog
        Try
            With FolderBrowserDialog1

                .Reset() ' resetea   

                ' leyenda   
                .Description = " Seleccionar una Carpeta "
                ' Path " Mis documentos "   
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

                ' deshabilita el botón " crear nueva carpeta "   
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo   

                ' si se presionó el botón aceptar ...   
                If ret = Windows.Forms.DialogResult.OK Then
                    MT_RUTA.Text = .SelectedPath
                    Me.BT_1.Select()
                    Me.BT_1.Focus()
                End If

                .Dispose()

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LK_RETENCIONES_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LK_RETENCIONES.LinkClicked
        Dim xficha As New FichaWeb
        With xficha
            ._PaginaInicio = PaginaSeniatRetenciones
            .ShowDialog()
        End With
    End Sub

    Private Sub BT_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_2.Click

    End Sub
End Class

Public Interface IPlantillaFiltroGenerarRetenciones
    Sub Inicializa(ByVal xform As Object)
End Interface

Public Class c_GenerarRetencionesIva
    Implements IPlantillaFiltroGenerarRetenciones

    ' CONTROLES
    WithEvents xformulario As System.Windows.Forms.Form
    Dim LB_1 As Label
    WithEvents BT_1 As Button
    WithEvents BT_2 As Button
    WithEvents MT_4 As MisTextos
    WithEvents MT_5 As MisTextos
    WithEvents MCB_MES As MisComboBox
    WithEvents MCB_PER As MisComboBox
    WithEvents N_ANO As NumericUpDown

    Property _MiFormulario() As System.Windows.Forms.Form
        Get
            Return xformulario
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            xformulario = value
        End Set
    End Property

    Public Sub Inicializa(ByVal xform As Object) Implements IPlantillaFiltroGenerarRetenciones.Inicializa
        _MiFormulario = xform
        LB_1 = _MiFormulario.Controls.Find("LB_1", True)(0)
        BT_1 = _MiFormulario.Controls.Find("BT_1", True)(0)
        BT_2 = _MiFormulario.Controls.Find("BT_2", True)(0)
        N_ANO = _MiFormulario.Controls.Find("N_ANO", True)(0)
        MCB_MES = _MiFormulario.Controls.Find("MCB_MES", True)(0)
        MCB_PER = _MiFormulario.Controls.Find("MCB_PERIODO", True)(0)
        MT_4 = _MiFormulario.Controls.Find("MT_RUTA", True)(0)
        MT_5 = _MiFormulario.Controls.Find("MT_NOMBRE", True)(0)
        LB_1.Text = "Generar TXT Retenciones Iva En Compras"
        MT_5.Text = "Retenciones.txt"
    End Sub

    Private Sub BT_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            If Me.MT_4.r_Valor = "" Then
                Me.MT_4.Select()
                Me.MT_4.Select()
                Throw New Exception("ERROR... DEBE INDICAR LA RUTA DEL ARCHIVO")
            End If

            GenerarTxtRetencionesIvaCompras(MT_4.r_Valor)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim xtb As DataTable
    Sub CapturarData()
        Dim xp1 As New SqlParameter("@ano_relacion", N_ANO.Value.ToString)
        Dim xp2 As New SqlParameter("@mes_relacion", (MCB_MES.SelectedIndex + 1).ToString.Trim.PadLeft(2, "0"))
        Dim xp3 As New SqlParameter("@periodo", (MCB_PER.SelectedIndex + 1))
        Dim xsql As String = "select * " & _
                               "from ( " & _
                                    "select r.ano_relacion" & _
                                        ", r.mes_relacion" & _
                                        ", c.fecha" & _
                                        ", rd.tipo" & _
                                        ", rd.ci_rif" & _
                                        ", rd.documento" & _
                                        ", rd.control" & _
                                        ", rd.base1 base " & _
                                        ", round(rd.tasa_retencion * rd.impuesto1 /100,2) retencion" & _
                                        ", rd.impuesto1 impuesto " & _
                                        ", rd.aplica " & _
                                        ", rd.comprobante" & _
                                        ", rd.tasa1 tasa " & _
                                     "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto join compras c on rd.auto_documento=c.auto " & _
                                     "where rd.impuesto1<>0 and rd.estatus='0' and rd.tipo in ('01','02','03') and r.ano_relacion=@ano_relacion and r.mes_relacion=@mes_relacion and r.periodo=@periodo " & _
                                     " union " & _
                                     "select r.ano_relacion" & _
                                        ", r.mes_relacion" & _
                                        ", c.fecha" & _
                                        ", rd.tipo" & _
                                        ", rd.ci_rif" & _
                                        ", rd.documento" & _
                                        ", rd.control" & _
                                        ", rd.base2 base " & _
                                        ", round(rd.tasa_retencion * rd.impuesto2 /100,2) " & _
                                        ", rd.impuesto2 impuesto " & _
                                        ", rd.aplica " & _
                                        ", rd.comprobante" & _
                                        ", rd.tasa2 tasa " & _
                                     "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto join compras c on rd.auto_documento=c.auto " & _
                                     "where rd.impuesto2<>0 and rd.estatus='0' and rd.tipo in ('01','02','03') and r.ano_relacion=@ano_relacion and r.mes_relacion=@mes_relacion and r.periodo=@periodo " & _
                                     " union " & _
                                     "select r.ano_relacion" & _
                                        ", r.mes_relacion" & _
                                        ", c.fecha" & _
                                        ", rd.tipo" & _
                                        ", rd.ci_rif" & _
                                        ", rd.documento" & _
                                        ", rd.control" & _
                                        ", rd.base3 base " & _
                                        ", round(rd.tasa_retencion * rd.impuesto3 /100,2) " & _
                                        ", rd.impuesto3 impuesto " & _
                                        ", rd.aplica " & _
                                        ", rd.comprobante" & _
                                        ", rd.tasa3 tasa " & _
                                     "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto join compras c on rd.auto_documento=c.auto " & _
                                     "where rd.impuesto3<>0 and rd.estatus='0' and rd.tipo in ('01','02','03') and r.ano_relacion=@ano_relacion and r.mes_relacion=@mes_relacion and r.periodo=@periodo " & _
                                     " union " & _
                                     "select r.ano_relacion" & _
                                        ", r.mes_relacion" & _
                                        ", c.fecha" & _
                                        ", rd.tipo" & _
                                        ", rd.ci_rif" & _
                                        ", rd.documento" & _
                                        ", rd.control" & _
                                        ", rd.exento base " & _
                                        ", 0 retencion " & _
                                        ", 0 impuesto " & _
                                        ", rd.aplica " & _
                                        ", rd.comprobante" & _
                                        ", 0 tasa " & _
                                     "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto join compras c on rd.auto_documento=c.auto " & _
                                     "where rd.exento<>0 and rd.estatus='0' and rd.tipo in ('01','02','03') and r.ano_relacion=@ano_relacion and r.mes_relacion=@mes_relacion and r.periodo=@periodo) T " & _
                                "order by T.COMPROBANTE,T.TASA,t.fecha"
        xtb = New DataTable("RETENCIONES_COMPRAS_TXT")
        g_MiData.F_GetData(xsql, xtb, xp1, xp2, xp3)
    End Sub

    Private Sub BT_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_2.Click
        Try
            Dim dts As New DataSet
            Dim xlist As New List(Of _Reportes.ParamtCrystal)
            If Me.MCB_PER.SelectedIndex = 0 Then
                xlist.Add(New _Reportes.ParamtCrystal("@periodo", "01"))
            Else
                xlist.Add(New _Reportes.ParamtCrystal("@periodo", "02"))
            End If

            CapturarData()
            dts.Tables.Add(xtb)

            Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
            xrep += "RETENCIONES_COMPRAS_TXT.rpt"
            Dim xficha As New _Reportes(dts, xrep, xlist)
            xficha.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Function GenerarTxtRetencionesIvaCompras(ByVal xruta As String) As Boolean
        Dim gnErrFile As System.IO.FileStream = Nothing
        Dim oSW As System.IO.StreamWriter = Nothing
        Dim dInfo As System.IO.DirectoryInfo = Nothing

        Try
            Dim xtb As New DataTable
            Dim xrif_empresa As String = F_GetString("select rif from empresa")
            Dim xp1 As New SqlParameter("@ano_relacion", N_ANO.Value.ToString)
            Dim xp2 As New SqlParameter("@mes_relacion", (MCB_MES.SelectedIndex + 1).ToString.Trim.PadLeft(2, "0"))
            Dim xp3 As New SqlParameter("@periodo", (MCB_PER.SelectedIndex + 1))
            Dim xsql As String = "select * " & _
                                   "from ( " & _
                                        "select r.ano_relacion" & _
                                            ", r.mes_relacion" & _
                                            ", c.fecha" & _
                                            ", rd.tipo" & _
                                            ", rd.ci_rif" & _
                                            ", rd.documento" & _
                                            ", rd.control" & _
                                            ", rd.base1 base " & _
                                            ", round(rd.tasa_retencion * rd.impuesto1 /100,2) retencion" & _
                                            ", rd.impuesto1 impuesto " & _
                                            ", rd.aplica " & _
                                            ", rd.comprobante" & _
                                            ", rd.tasa1 tasa " & _
                                         "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto join compras c on rd.auto_documento=c.auto " & _
                                         "where rd.impuesto1<>0 and rd.estatus='0' and rd.tipo in ('01','02','03') and r.ano_relacion=@ano_relacion and r.mes_relacion=@mes_relacion and r.periodo=@periodo " & _
                                         " union " & _
                                         "select r.ano_relacion" & _
                                            ", r.mes_relacion" & _
                                            ", c.fecha" & _
                                            ", rd.tipo" & _
                                            ", rd.ci_rif" & _
                                            ", rd.documento" & _
                                            ", rd.control" & _
                                            ", rd.base2 base " & _
                                            ", round(rd.tasa_retencion * rd.impuesto2 /100,2) " & _
                                            ", rd.impuesto2 impuesto " & _
                                            ", rd.aplica " & _
                                            ", rd.comprobante" & _
                                            ", rd.tasa2 tasa " & _
                                         "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto join compras c on rd.auto_documento=c.auto " & _
                                         "where rd.impuesto2<>0 and rd.estatus='0' and rd.tipo in ('01','02','03') and r.ano_relacion=@ano_relacion and r.mes_relacion=@mes_relacion and r.periodo=@periodo " & _
                                         " union " & _
                                         "select r.ano_relacion" & _
                                            ", r.mes_relacion" & _
                                            ", c.fecha" & _
                                            ", rd.tipo" & _
                                            ", rd.ci_rif" & _
                                            ", rd.documento" & _
                                            ", rd.control" & _
                                            ", rd.base3  base " & _
                                            ", round(rd.tasa_retencion * rd.impuesto3 /100,2) " & _
                                            ", rd.impuesto3  impuesto " & _
                                            ", rd.aplica " & _
                                            ", rd.comprobante" & _
                                            ", rd.tasa3 tasa " & _
                                         "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto join compras c on rd.auto_documento=c.auto " & _
                                         "where rd.impuesto3<>0 and rd.estatus='0' and rd.tipo in ('01','02','03') and r.ano_relacion=@ano_relacion and r.mes_relacion=@mes_relacion and r.periodo=@periodo " & _
                                         " union " & _
                                         "select r.ano_relacion" & _
                                            ", r.mes_relacion" & _
                                            ", c.fecha" & _
                                            ", rd.tipo" & _
                                            ", rd.ci_rif" & _
                                            ", rd.documento" & _
                                            ", rd.control" & _
                                            ", rd.exento base " & _
                                            ", 0 retencion " & _
                                            ", 0 impuesto " & _
                                            ", rd.aplica " & _
                                            ", rd.comprobante" & _
                                            ", 0 tasa " & _
                                         "from retenciones_compras r join retenciones_compras_detalle rd on r.auto=rd.auto join compras c on rd.auto_documento=c.auto " & _
                                         "where rd.exento<>0 and rd.estatus='0' and rd.tipo in ('01','02','03') and r.ano_relacion=@ano_relacion and r.mes_relacion=@mes_relacion and r.periodo=@periodo) T " & _
                                    "order by t.fecha,t.ci_rif,t.documento, t.tasa desc"

            Dim c1 As String = ""
            Dim c2 As String = ""
            Dim c3 As String = ""
            Dim c4 As String = ""
            Dim c5 As String = ""
            Dim c6 As String = ""
            Dim c7 As String = ""
            Dim c8 As String = ""
            Dim c9 As String = ""
            Dim c10 As String = ""
            Dim c11 As String = ""
            Dim c12 As String = ""
            Dim c13 As String = ""
            Dim c14 As String = ""
            Dim c15 As String = ""
            Dim c16 As String = ""
            Dim xstr As String = ""

            g_MiData.F_GetData(xsql, xtb, xp1, xp2, xp3)

            If System.IO.Directory.Exists(xruta) = False Then
                System.IO.Directory.CreateDirectory(xruta)
            End If

            If System.IO.File.Exists(xruta + "\Retenciones.txt") = False Then
                gnErrFile = System.IO.File.Create(xruta + "\Retenciones.txt")
            Else
                System.IO.File.Delete(xruta + "\Retenciones.txt")
                gnErrFile = System.IO.File.Create(xruta + "\Retenciones.txt")
            End If

            oSW = New System.IO.StreamWriter(gnErrFile, System.Text.Encoding.Default)

            For Each xrow In xtb.Rows
                c1 = IIf(xrif_empresa.Trim = "", "0", xrif_empresa.Replace("-", ""))
                c2 = xrow("ano_relacion").ToString.Trim + xrow("mes_relacion").ToString.Trim
                c3 = CType(xrow("fecha"), DateTime).ToString("yyyy-MM-dd")
                c4 = "C"
                c5 = xrow("tipo").ToString.Trim
                c6 = xrow("ci_rif").ToString.Trim.Replace("-", "")
                c7 = xrow("documento").ToString.Trim
                c8 = xrow("control").ToString.Trim
                c9 = Math.Abs(Decimal.Round(xrow("base") + xrow("impuesto"), 2, MidpointRounding.AwayFromZero)).ToString
                c9 = c9.Replace(",", ".")
                c10 = Math.Abs(Decimal.Round(xrow("base"), 2, MidpointRounding.AwayFromZero)).ToString
                c10 = c10.Replace(",", ".")
                c11 = Math.Abs(Decimal.Round(xrow("retencion"), 2, MidpointRounding.AwayFromZero)).ToString
                c11 = c11.Replace(",", ".")
                c12 = IIf(xrow("aplica").ToString.Trim = "", "0", xrow("aplica").ToString.Trim)
                c13 = xrow("comprobante").ToString.Trim
                c14 = "0.00"
                c15 = Decimal.Round(xrow("tasa"), 2, MidpointRounding.AwayFromZero).ToString
                c15 = c15.Replace(",", ".")
                c16 = "0"

                xstr = c1 + Chr(9) + c2 + Chr(9) + c3 + Chr(9) + c4 + Chr(9) + c5 + Chr(9) + c6 + Chr(9) + c7 + Chr(9) + c8 + Chr(9) + c9 + Chr(9) + c10 + Chr(9) _
                     + c11 + Chr(9) + c12 + Chr(9) + c13 + Chr(9) + c14 + Chr(9) + c15 + Chr(9) + c16 + Chr(9)
                oSW.WriteLine(xstr + Chr(13) + Chr(10))
            Next
            oSW.Flush()
            oSW.Close()

            MessageBox.Show("Archivo TXT generado con exito.!!!", "Mensaje * Ok *", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If oSW IsNot Nothing Then
                oSW.Flush()
                oSW.Close()
            End If
        End Try
    End Function

    Function RetornarPeriodo(ByVal xfecha As Date)
        If xfecha.Day >= 1 And xfecha.Day <= 15 Then
            Return 1
        Else
            Return 2
        End If
    End Function
End Class