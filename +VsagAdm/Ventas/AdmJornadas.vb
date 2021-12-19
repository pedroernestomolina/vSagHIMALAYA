Imports System.Data.SqlClient
Imports DataSistema.MiDataSistema.DataSistema

Public Class AdmJornadas
    Dim ds As DataSet

    Dim xtb_seriales As DataTable
    Dim xtb1 As DataTable
    Dim xtb2 As DataTable
    Dim xbs1 As BindingSource
    Dim xbs2 As BindingSource

    Dim xp1 As SqlParameter
    Dim xp2 As SqlParameter
    Dim xxp1 As SqlParameter
    Dim xxp2 As SqlParameter
    Dim xds As DataSet
    Dim Xxds As DataSet
    Dim tb1 As DataTable
    Dim tb2 As DataTable
    Dim tb2_rest As DataTable
    Dim tb3 As DataTable
    Dim tb3_rest As DataTable
    Dim tb3_rest_pend As DataTable
    Dim tb4 As DataTable
    Dim tb4_rest As DataTable
    Dim tb4_rest_pend As DataTable
    Dim tb5 As DataTable
    Dim tb6 As DataTable
    Dim tb7 As DataTable
    Dim xrel As DataRelation
    Dim Xxrel As DataRelation

    Dim mt1 As DataTable
    Dim mt2 As DataTable
    Dim mt3 As DataTable

    Dim xb1 As BindingSource
    Dim xb2 As BindingSource
    Dim xb3 As BindingSource
    Dim xb4 As BindingSource
    Dim xb5 As BindingSource
    Dim xb7 As BindingSource

    Dim xb2_REST As BindingSource
    Dim xb3_REST As BindingSource

    Dim xb2_REST_pend As BindingSource
    Dim xb3_REST_pend As BindingSource

    Dim mbs1 As BindingSource
    Dim mbs2 As BindingSource

    Dim xestatusmodofactura As Boolean

    Property _EstatusModoFactura() As Boolean
        Get
            Return xestatusmodofactura
        End Get
        Set(ByVal value As Boolean)
            xestatusmodofactura = value
        End Set
    End Property

    Private Sub AdmJornadas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub AdmJornadas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub LimpiarControles()
        Me.LB_1.Text = ""
        Me.LB_2.Text = ""
        Me.LB_3.Text = "0"
        Me.LB_4.Text = "0"
        Me.LB_5.Text = "0.0"
        Me.LB_6.Text = "0.0"

        Me.LX_1.Text = "0.0"
        Me.LX_2.Text = "0"
        Me.LX_3.Text = "0.0"
        Me.LX_4.Text = "0"
        Me.LX_5.Text = "0"

        Me.LB_TOT_DEV_FF.Text = "0.0"
        Me.LB_CANT_DEV_FF.Text = "0"

        Me.LB_CANT_ANU_FF.Text = "0"
        Me.LB_TOT_ANU_FF.Text = "0.0"

        Me.LB_TOT_PEND_FF.Text = "0.0"
        Me.LB_CANT_PEND_FF.Text = "0.0"

        Me.LM_1.Text = "0"
        Me.LM_2.Text = "0"
        Me.LM_3.Text = "0.0"
        Me.LM_4.Text = "0"
        Me.LM_5.Text = "0.0"
        Me.L_MT1.Text = ""
        Me.L_MT2.Text = ""
    End Sub

    Sub Inicializa()
        Try
            LimpiarControles()

            xtb_seriales = New DataTable
            g_MiData.F_GetData("select nrf from series_fiscales group by nrf order by nrf", xtb_seriales)

            With Me.MCB_SERIAL_FISCAL
                .DataSource = xtb_seriales
                .DisplayMember = "NRF"
                .ValueMember = "NRF"
            End With

            ds = New DataSet
            xtb1 = New DataTable("jornada")
            xtb2 = New DataTable("operador")
            ds.Tables.Add(xtb1)
            ds.Tables.Add(xtb2)

            CargarData_1()
            CargarData_2()

            Dim rel As DataRelation = New DataRelation("JORNADA_OPERADOR", xtb1.Columns("xauto"), xtb2.Columns("xautojornada"))
            ds.Relations.Add(rel)
            xbs1 = New BindingSource(ds, "jornada")
            xbs2 = New BindingSource(xbs1, "JORNADA_OPERADOR")
            AddHandler xbs1.PositionChanged, AddressOf ActualizarDatosJornada
            ActualizaJornada()

            AddHandler xbs2.PositionChanged, AddressOf CargarDataOperador
            ActualizarOperador()

            With Me.MG_JORNADA
                .Columns.Add("col0", "Fecha")
                .Columns.Add("col1", "Hora")
                .Columns.Add("col2", "Usuario")

                .DataSource = xbs1
                .Columns(0).DataPropertyName = "xfecha"
                .Columns(1).DataPropertyName = "xhora"
                .Columns(2).DataPropertyName = "xnombre"

                .Columns("col1").Width = 80
                .Columns("col2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .Ocultar(4)
            End With

            With Me.MG_OPERADOR
                .Columns.Add("col0", "Fecha")
                .Columns.Add("col1", "Hora")
                .Columns.Add("col2", "Usuario")

                .DataSource = xbs2
                .Columns(0).DataPropertyName = "xfecha"
                .Columns(1).DataPropertyName = "xhora"
                .Columns(2).DataPropertyName = "xnombre"

                .Columns("col1").Width = 80
                .Columns("col2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .Ocultar(4)
            End With


            With MG_DOC
                .Columns.Add("col0", "F/Emision")
                .Columns.Add("col1", "Tipo/Doc")
                .Columns.Add("col2", "Documento")
                .Columns.Add("col3", "Cliente")
                .Columns.Add("col4", "CI/RIF")
                .Columns.Add("col5", "Importe")
                .Columns.Add("col6", "Estatus")

                .DataSource = xb1
                .Columns(0).DataPropertyName = "fecha"
                .Columns(1).DataPropertyName = "tipo"
                .Columns(2).DataPropertyName = "documento"
                .Columns(3).DataPropertyName = "nombre"
                .Columns(4).DataPropertyName = "ci_rif"
                .Columns(5).DataPropertyName = "total"
                .Columns(6).DataPropertyName = "estatus"

                .Columns(0).Width = 90
                .Columns(1).Width = 90
                .Columns(2).Width = 110
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(4).Width = 100
                .Columns(5).Width = 80
                .Columns(6).Width = 60

                .Ocultar(8)
                AddHandler .CellFormatting, AddressOf MiFormato
            End With

            With MG_DEV_FASTFOOD
                .Columns.Add("col0", "Producto")
                .Columns.Add("col1", "Cant")
                .Columns.Add("col2", "Importe")
                .Columns.Add("col3", "Hora")
                .Columns.Add("col4", "Fecha")
                .Columns.Add("col5", "Niv/Clav")

                .DataSource = tb2
                .Columns(0).DataPropertyName = "x1"
                .Columns(1).DataPropertyName = "x2"
                .Columns(2).DataPropertyName = "x3"
                .Columns(3).DataPropertyName = "x4"
                .Columns(4).DataPropertyName = "x5"
                .Columns(5).DataPropertyName = "x6"

                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).Width = 80
                .Columns(2).Width = 80
                .Columns(3).Width = 70
                .Columns(4).Width = 90
                .Columns(5).Width = 80

                .Ocultar(7)
                AddHandler .CellFormatting, AddressOf MiFormato2
            End With


            With MG_AN_FASTFOOD
                .Columns.Add("col0", "Hora")
                .Columns.Add("col1", "Fecha")
                .Columns.Add("col2", "Importe")

                .DataSource = xb2
                .Columns(0).DataPropertyName = "x1"
                .Columns(1).DataPropertyName = "x2"
                .Columns(2).DataPropertyName = "x3"

                .Columns(0).Width = 70
                .Columns(1).Width = 90
                .Columns(2).Width = 90
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

                .Ocultar(4)
                AddHandler .CellFormatting, AddressOf MiFormato5
            End With

            With MG_DET_ANU_FASTFOOD
                .Columns.Add("col0", "Producto")
                .Columns.Add("col1", "Cant")
                .Columns.Add("col2", "Importe")
                .Columns.Add("col3", "Niv/Clav")

                .DataSource = xb3
                .Columns(0).DataPropertyName = "x1"
                .Columns(1).DataPropertyName = "x2"
                .Columns(2).DataPropertyName = "x3"
                .Columns(3).DataPropertyName = "x6"

                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).Width = 70
                .Columns(2).Width = 80
                .Columns(3).Width = 80

                .Ocultar(5)
                AddHandler .CellFormatting, AddressOf MiFormato3
            End With


            With MG_PEND_FF
                .Columns.Add("col0", "Hora")
                .Columns.Add("col1", "Fecha")
                .Columns.Add("col2", "Importe")

                .DataSource = xb4
                .Columns(0).DataPropertyName = "x1"
                .Columns(1).DataPropertyName = "x2"
                .Columns(2).DataPropertyName = "x3"

                .Columns(0).Width = 70
                .Columns(1).Width = 90
                .Columns(2).Width = 90
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

                .Ocultar(4)
                AddHandler .CellFormatting, AddressOf MiFormato5
            End With

            With MG_PEND_DET_FF
                .Columns.Add("col0", "Producto")
                .Columns.Add("col1", "Cant")
                .Columns.Add("col2", "Importe")
                .Columns.Add("col3", "Niv/Clav")

                .DataSource = xb5
                .Columns(0).DataPropertyName = "x1"
                .Columns(1).DataPropertyName = "x2"
                .Columns(2).DataPropertyName = "x3"
                .Columns(3).DataPropertyName = "x6"

                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).Width = 70
                .Columns(2).Width = 80
                .Columns(3).Width = 80

                .Ocultar(5)
                AddHandler .CellFormatting, AddressOf MiFormato7
            End With


            With MG_APERTURA
                .Columns.Add("col0", "Hora")
                .Columns.Add("col1", "Fecha")

                .DataSource = mt1
                .Columns(0).DataPropertyName = "x1"
                .Columns(1).DataPropertyName = "x2"

                .Columns(0).Width = 70
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .Ocultar(3)
            End With

            With MG_FONDO
                .Columns.Add("col0", "Hora")
                .Columns.Add("col1", "Fecha")
                .Columns.Add("col2", "Importe")

                .DataSource = mbs1
                .Columns(0).DataPropertyName = "x1"
                .Columns(1).DataPropertyName = "x2"
                .Columns(2).DataPropertyName = "x3"

                .Columns(0).Width = 70
                .Columns(1).Width = 100
                .Columns(2).Width = 90

                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Ocultar(4)
            End With

            With MG_RETIRO
                .Columns.Add("col0", "Hora")
                .Columns.Add("col1", "Fecha")
                .Columns.Add("col2", "Importe")

                .DataSource = mbs2
                .Columns(0).DataPropertyName = "x1"
                .Columns(1).DataPropertyName = "x2"
                .Columns(2).DataPropertyName = "x3"

                .Columns(0).Width = 70
                .Columns(1).Width = 100
                .Columns(2).Width = 90

                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Ocultar(4)
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub MiFormato4(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Select Case e.ColumnIndex
            Case 1, 2
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
                If e.ColumnIndex = 1 Then
                    If MG_PEND_DET_FF.Rows(e.RowIndex).Cells("x5").Value.ToString.Trim.ToUpper = "1" Then
                        e.Value = String.Format("{0:#0.000}", e.Value)
                    Else
                        e.Value = String.Format("{0:#0}", e.Value)
                    End If
                End If
        End Select
    End Sub

    Sub MiFormato3(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Select Case e.ColumnIndex
            Case 1, 2
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
                If e.ColumnIndex = 1 Then
                    If MG_DET_ANU_FASTFOOD.Rows(e.RowIndex).Cells("x5").Value.ToString.Trim.ToUpper = "1" Then
                        e.Value = String.Format("{0:#0.000}", e.Value)
                    Else
                        e.Value = String.Format("{0:#0}", e.Value)
                    End If
                End If
                If e.ColumnIndex = 2 Then
                    e.Value = String.Format("{0:#0.00}", e.Value)
                End If
        End Select
    End Sub

    Sub MiFormato2(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Select Case e.ColumnIndex
            Case 1, 2, 3
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
                If e.ColumnIndex = 1 Then
                    If MG_DEV_FASTFOOD.Rows(e.RowIndex).Cells("x7").Value.ToString.Trim.ToUpper = "1" Then
                        e.Value = String.Format("{0:#0.000}", e.Value)
                    Else
                        e.Value = String.Format("{0:#0}", e.Value)
                    End If
                End If
                If e.ColumnIndex = 2 Then
                    e.Value = String.Format("{0:#0.00}", e.Value)
                End If
        End Select
    End Sub

    Sub MiFormato5(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 2 Then
            e.Value = String.Format("{0:#0.00}", e.Value)
        End If
    End Sub

    Sub MiFormato(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 5 Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End If

        If MG_DOC.Rows(e.RowIndex).Cells(6).Value.ToString.Trim.ToUpper = "ANULADO" Then
            MG_DOC.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Sub MiFormato7(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Select Case e.ColumnIndex
            Case 1, 2
                e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight
                If e.ColumnIndex = 1 Then
                    If MG_PEND_DET_FF.Rows(e.RowIndex).Cells("x5").Value.ToString.Trim.ToUpper = "1" Then
                        e.Value = String.Format("{0:#0.000}", e.Value)
                    Else
                        e.Value = String.Format("{0:#0}", e.Value)
                    End If
                End If
                If e.ColumnIndex = 2 Then
                    e.Value = String.Format("{0:#0.00}", e.Value)
                End If
        End Select
    End Sub

    Sub CargarDataOperador()
        ActualizarOperador()
    End Sub

    Dim sql1 As String = "select fecha, (case tipo when '01' then 'Factura' when '03' then 'Nota Crédito' end) tipo, " & _
                             "documento, nombre, ci_rif, total, (case estatus when '0' then 'Activo' when '1' then 'Anulado' end) estatus, " & _
                             "auto, tipo as tipodoc, estatus xestatus from ventas where tipo in ('01','03') and auto_jornada=@jornada and auto_operador=@operador " & _
                             "and origen_documento in ('02') order by auto desc"

    Dim sql1_b As String = "select fecha, (case tipo when '01' then 'Factura' when '03' then 'Nota Crédito' end) tipo, " & _
                             "documento, nombre, ci_rif, total, (case estatus when '0' then 'Activo' when '1' then 'Anulado' end) estatus, " & _
                             "auto, tipo as tipodoc, estatus xestatus from ventas where tipo in ('XX') and auto_jornada=@jornada and auto_operador=@operador " & _
                             "and origen_documento in ('02') order by auto desc"

    Dim sql2 As String = "select prd_nombrecorto x1, prd_cantidad x2, prd_importe x3, hora_devanu x4, fecha_devanu x5, " & _
                         "case nivelclave_devanu  when '0' then 'Libre' " & _
                         "  when '1' then 'Maximo' " & _
                         "  when '2' then 'Medio' " & _
                         "  when '3' then 'Minimo' end x6, prd_espesado x7 " & _
                         "from pos_venta_DevAnulacion where autojornada_devanu=@jornada and autooperador_devanu=@operador and tipo_devanu in ('1','3')"

    Dim sql3 As String = "select hora_devanu x1, fecha_devanu x2, SUM(prd_importe) x3, auto_devanu x4  from pos_venta_devanulacion " & _
                         "where tipo_devanu='2' AND autojornada_devanu=@jornada and autooperador_devanu=@operador " & _
                         "GROUP BY auto_devanu,fecha_devanu,hora_devanu ORDER BY auto_devanu desc"

    Dim sql4 As String = "select prd_nombrecorto x1, prd_cantidad x2, prd_importe x3, auto_devanu x4, prd_espesado x5, " & _
                         "case nivelclave_devanu  when '0' then 'Libre' " & _
                         "  when '1' then 'Maximo' " & _
                         "  when '2' then 'Medio' " & _
                         "  when '3' then 'Minimo' end x6 from pos_venta_devanulacion " & _
                         "where tipo_devanu='2' AND autojornada_devanu=@jornada and autooperador_devanu=@operador"

    Dim sql5 As String = "select hora_devanu x1, fecha_devanu x2, SUM(prd_importe) x3, auto_devanu x4  from pos_venta_devanulacion " & _
                         "where tipo_devanu='4' AND autojornada_devanu=@jornada and autooperador_devanu=@operador " & _
                         "GROUP BY auto_devanu, fecha_devanu, hora_devanu ORDER BY auto_devanu desc"

    Dim sql6 As String = "select prd_nombrecorto x1, prd_cantidad x2, prd_importe x3, auto_devanu x4, prd_espesado x5, " & _
                         "case nivelclave_devanu  when '0' then 'Libre' " & _
                         "  when '1' then 'Maximo' " & _
                         "  when '2' then 'Medio' " & _
                         "  when '3' then 'Minimo' end x6 from pos_venta_devanulacion " & _
                         "where tipo_devanu='4' AND autojornada_devanu=@jornada and autooperador_devanu=@operador"


    Sub ActualizarOperador()
        If xbs2.Current IsNot Nothing Then
            Try
                Dim xop As New FastFood.OperadorJornada
                Dim xtipodoc As String = ""
                xop.F_BuscarCargar(xbs2.Current("xauto").ToString)

                ' DOCUMENTOS 
                Dim xp1 As New SqlParameter("@jornada", xop.RegistroDato._AutoJornada)
                Dim xp2 As New SqlParameter("@operador", xop.RegistroDato._AutoOperador)
                If Me._EstatusModoFactura Then 'chimbo
                    g_MiData.F_GetData(sql1_b, tb1, xp1, xp2)
                    xtipodoc = "XX"
                Else 'legal
                    g_MiData.F_GetData(sql1, tb1, xp1, xp2)
                    xtipodoc = "01"
                End If

                With MG_DOC
                    .DataSource = Nothing

                    .Columns.Add("col0", "F/Emision")
                    .Columns.Add("col1", "Tipo/Doc")
                    .Columns.Add("col2", "Documento")
                    .Columns.Add("col3", "Cliente")
                    .Columns.Add("col4", "CI/RIF")
                    .Columns.Add("col5", "Importe")
                    .Columns.Add("col6", "Estatus")

                    .DataSource = xb1
                    .Columns(0).DataPropertyName = "fecha"
                    .Columns(1).DataPropertyName = "tipo"
                    .Columns(2).DataPropertyName = "documento"
                    .Columns(3).DataPropertyName = "nombre"
                    .Columns(4).DataPropertyName = "ci_rif"
                    .Columns(5).DataPropertyName = "total"
                    .Columns(6).DataPropertyName = "estatus"

                    .Ocultar(8)
                End With

                Dim t1 = tb1.AsEnumerable.Where(Function(x) x.Field(Of String)("tipodoc") = xtipodoc And x.Field(Of String)("xestatus") <> "1").Select(Function(x) x.Field(Of Decimal)("total")).Sum
                Dim t3 = tb1.AsEnumerable.Where(Function(x) x.Field(Of String)("tipodoc") = xtipodoc And x.Field(Of String)("xestatus") <> "1").Count
                Dim t2 = tb1.AsEnumerable.Where(Function(x) x.Field(Of String)("tipodoc") = "03" And x.Field(Of String)("xestatus") <> "1").Select(Function(x) x.Field(Of Decimal)("total")).Sum
                Dim t4 = tb1.AsEnumerable.Where(Function(x) x.Field(Of String)("tipodoc") = "03" And x.Field(Of String)("xestatus") <> "1").Count
                Dim t5 = tb1.AsEnumerable.Where(Function(x) x.Field(Of String)("xestatus") = "1").Count

                Me.LX_1.Text = String.Format("{0:#0.00}", t1)
                Me.LX_3.Text = String.Format("{0:#0}", t3)
                Me.LX_2.Text = String.Format("{0:#0.00}", t2)
                Me.LX_4.Text = String.Format("{0:#0}", t4)
                Me.LX_5.Text = String.Format("{0:#0}", t5)


                'DEVOLUCIONES FASTFOOD
                Dim xxp1 As New SqlParameter("@jornada", xop.RegistroDato._AutoJornada)
                Dim xxp2 As New SqlParameter("@operador", xop.RegistroDato._AutoOperador)
                g_MiData.F_GetData(sql2, tb2, xxp1, xxp2)

                Dim xt1 = tb2.AsEnumerable.Select(Function(x) x.Field(Of Decimal)("x3")).Sum
                Dim xt2 = tb2.AsEnumerable.Count
                Me.LB_TOT_DEV_FF.Text = String.Format("{0:#0.00}", xt1)
                Me.LB_CANT_DEV_FF.Text = String.Format("{0:#0}", xt2)


                'ANULACIONES FASTFOOD
                tb4.Rows.Clear()
                Dim xxxp1 As New SqlParameter("@jornada", xop.RegistroDato._AutoJornada)
                Dim xxxp2 As New SqlParameter("@operador", xop.RegistroDato._AutoOperador)
                g_MiData.F_GetData(sql3, tb3, xxxp1, xxxp2)

                Dim xxt1 = tb3.AsEnumerable.Select(Function(x) x.Field(Of Decimal)("x3")).Sum
                Dim xxt2 = tb3.AsEnumerable.Count
                Me.LB_TOT_ANU_FF.Text = String.Format("{0:#0.00}", xxt1)
                Me.LB_CANT_ANU_FF.Text = String.Format("{0:#0}", xxt2)

                Dim xxxxp1 As New SqlParameter("@jornada", xop.RegistroDato._AutoJornada)
                Dim xxxxp2 As New SqlParameter("@operador", xop.RegistroDato._AutoOperador)
                g_MiData.F_GetData(sql4, tb4, xxxxp1, xxxxp2)


                'PENDIENTE FASTFOOD
                tb6.Rows.Clear()
                Dim Zp1 As New SqlParameter("@jornada", xop.RegistroDato._AutoJornada)
                Dim Zp2 As New SqlParameter("@operador", xop.RegistroDato._AutoOperador)
                g_MiData.F_GetData(sql5, tb5, Zp1, Zp2)

                Dim PT1 = tb5.AsEnumerable.Select(Function(x) x.Field(Of Decimal)("x3")).Sum
                Dim PT2 = tb5.AsEnumerable.Count
                Me.LB_TOT_PEND_FF.Text = String.Format("{0:#0.00}", PT1)
                Me.LB_CANT_PEND_FF.Text = String.Format("{0:#0}", PT2)

                Dim ZZp1 As New SqlParameter("@jornada", xop.RegistroDato._AutoJornada)
                Dim ZZp2 As New SqlParameter("@operador", xop.RegistroDato._AutoOperador)
                g_MiData.F_GetData(sql6, tb6, ZZp1, ZZp2)


                'APERTURAS DE GAVETA
                Dim mxp1 As SqlParameter = New SqlParameter("@jornada", xop.RegistroDato._AutoJornada)
                Dim mxp2 As SqlParameter = New SqlParameter("@operador", xop.RegistroDato._AutoOperador)
                Dim msql1 As String = "select hora x1,fecha x2  from FondoRetiroAperturaGaveta where tipo='0' and auto_jornada=@jornada and auto_operador=@operador"
                g_MiData.F_GetData(msql1, mt1, mxp1, mxp2)
                Me.LM_1.Text = String.Format("{0:#0}", mt1.Rows.Count)


                'FONDO
                Dim mFxp1 As SqlParameter = New SqlParameter("@jornada", xop.RegistroDato._AutoJornada)
                Dim mFxp2 As SqlParameter = New SqlParameter("@operador", xop.RegistroDato._AutoOperador)
                Dim mFsql1 As String = "select hora x1, fecha x2, monto x3, motivo x4 from FondoRetiroAperturaGaveta where tipo='1' and auto_jornada=@jornada and auto_operador=@operador"
                g_MiData.F_GetData(mFsql1, mt2, mFxp1, mFxp2)
                Me.LM_2.Text = String.Format("{0:#0}", mt2.Rows.Count)
                Me.LM_3.Text = String.Format("{0:#0.00}", mt2.AsEnumerable.Select(Function(x) x.Field(Of Decimal)("x3")).Sum)
                MostrarFondo()


                'RETIRO
                Dim mRxp1 As SqlParameter = New SqlParameter("@jornada", xop.RegistroDato._AutoJornada)
                Dim mRxp2 As SqlParameter = New SqlParameter("@operador", xop.RegistroDato._AutoOperador)
                Dim mRsql1 As String = "select hora x1, fecha x2, monto x3, motivo x4 from FondoRetiroAperturaGaveta where tipo='2' and auto_jornada=@jornada and auto_operador=@operador"
                g_MiData.F_GetData(mRsql1, mt3, mRxp1, mRxp2)
                Me.LM_4.Text = String.Format("{0:#0}", mt3.Rows.Count)
                Me.LM_5.Text = String.Format("{0:#0.00}", mt3.AsEnumerable.Select(Function(x) x.Field(Of Decimal)("x3")).Sum)
                MostrarRetiro()

            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        Else
            tb1.Rows.Clear()
            tb2.Rows.Clear()

            tb4.Rows.Clear()
            tb3.Rows.Clear()

            tb6.Rows.Clear()
            tb5.Rows.Clear()

            mt1.Rows.Clear()
            mt2.Rows.Clear()
            mt3.Rows.Clear()
        End If
    End Sub

    Sub ActualizaJornada()
        If xbs1.Current IsNot Nothing Then
            Try
                Dim xj As New FastFood.Jornada
                xj.F_BuscarCargar(xbs1.Current("xauto").ToString)

                With xj.RegistroDato
                    If Not IsDBNull(.c_FechaCierre._ContenidoCampo) Then
                        Me.LB_1.Text = ._FechaCierre.ToShortDateString
                    Else
                        Me.LB_1.Text = "SIN CERRAR"
                    End If
                    Me.LB_2.Text = ._HoraCierre
                    Me.LB_3.Text = ._TotalDoc_Ventas.ToString
                    Me.LB_4.Text = ._TotalDoc_NC.ToString
                    Me.LB_5.Text = String.Format("{0:#0.00}", ._TotalVentas)
                    Me.LB_6.Text = String.Format("{0:#0.00}", ._TotalNC)
                End With

                ActualizarOperador()
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        Else
            tb1.Rows.Clear()
            tb2.Rows.Clear()

            tb4.Rows.Clear()
            tb3.Rows.Clear()

            tb6.Rows.Clear()
            tb5.Rows.Clear()

            mt1.Rows.Clear()
            mt2.Rows.Clear()
            mt3.Rows.Clear()
        End If
    End Sub

    Sub ActualizarDatosJornada(ByVal sender As Object, ByVal e As System.EventArgs)
        ActualizaJornada()
    End Sub

    Sub CargarData_1()
        Try
            Dim xsql1 As String = ""
            Dim xp1 As SqlParameter
            Dim ini As SqlParameter

            xsql1 = "select fecha_apert as xfecha, hora_apert as xhora, nombre_usuario_apert as xnombre, auto as xauto from jornada " & _
                    "where SerialFiscal=@serialfiscal AND fecha_apert >=@ini order by auto desc"
            xp1 = New SqlParameter("@serialfiscal", Me.MCB_SERIAL_FISCAL.SelectedValue.ToString)
            ini = New SqlParameter("@ini", Me.MF_1.Value)
            g_MiData.F_GetData(xsql1, xtb1, xp1, ini)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub CargarData_2()
        Try
            Dim xsql1 As String = ""
            Dim xp1 As SqlParameter
            Dim ini As SqlParameter

            xsql1 = "select o.fecha_inicio as xfecha, o.hora_inicio as xhora, o.usuario_nombre as xnombre, o.auto_jornada as xautojornada, o.auto as xauto from operadorjornada o join jornada j on o.auto_jornada=j.auto " & _
                               "where j.serialfiscal=@serialfiscal AND fecha_apert >=@ini order by o.auto desc"
            xp1 = New SqlParameter("@serialfiscal", Me.MCB_SERIAL_FISCAL.SelectedValue.ToString)
            ini = New SqlParameter("@ini", Me.MF_1.Value)
            g_MiData.F_GetData(xsql1, xtb2, xp1, ini)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub New()
        Try
            ' Llamada necesaria para el Diseñador de Windows Forms.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            tb1 = New DataTable
            xb1 = New BindingSource(tb1, "")
            tb2 = New DataTable
            tb2_rest = New DataTable
            tb3 = New DataTable
            tb3_rest = New DataTable
            tb3_rest_pend = New DataTable
            tb4 = New DataTable
            tb4_rest = New DataTable
            tb4_rest_pend = New DataTable
            tb5 = New DataTable
            tb6 = New DataTable
            tb7 = New DataTable

            xds = New DataSet
            xds.Tables.Add(tb3)
            xds.Tables.Add(tb4)
            xds.Tables.Add(tb3_rest)
            xds.Tables.Add(tb4_rest)
            xds.Tables.Add(tb3_rest_pend)
            xds.Tables.Add(tb4_rest_pend)


            'ANULACIONES FASTFOOD
            xp1 = New SqlParameter("@jornada", "")
            xp2 = New SqlParameter("@operador", "")
            xxp1 = New SqlParameter("@jornada", "")
            xxp2 = New SqlParameter("@operador", "")
            g_MiData.F_GetData(sql3, tb3, xp1, xp2)
            g_MiData.F_GetData(sql4, tb4, xxp1, xxp2)
            xrel = New DataRelation("ANULACIONES", tb3.Columns("x4"), tb4.Columns("x4"))
            xds.Relations.Add(xrel)
            xb2 = New BindingSource(xds, xds.Tables(0).TableName)
            xb3 = New BindingSource(xb2, "ANULACIONES")


            Xxds = New DataSet
            Xxds.Tables.Add(tb5)
            Xxds.Tables.Add(tb6)

            'PENDIENTE
            xp1 = New SqlParameter("@jornada", "")
            xp2 = New SqlParameter("@operador", "")
            xxp1 = New SqlParameter("@jornada", "")
            xxp2 = New SqlParameter("@operador", "")
            g_MiData.F_GetData(sql5, tb5, xp1, xp2)
            g_MiData.F_GetData(sql6, tb6, xxp1, xxp2)
            Xxrel = New DataRelation("PENDIENTES", tb5.Columns("x4"), tb6.Columns("x4"))
            Xxds.Relations.Add(Xxrel)
            xb4 = New BindingSource(Xxds, Xxds.Tables(0).TableName)
            xb5 = New BindingSource(xb4, "PENDIENTES")

            mt1 = New DataTable
            mt2 = New DataTable
            mt3 = New DataTable
            mbs1 = New BindingSource(mt2, "")
            mbs2 = New BindingSource(mt3, "")

            AddHandler mbs1.PositionChanged, AddressOf ActFondo
            AddHandler mbs2.PositionChanged, AddressOf ActRetiro

            Me._EstatusModoFactura = False
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub ActFondo(ByVal sender As Object, ByVal e As System.EventArgs)
        MostrarFondo()
    End Sub

    Sub ActRetiro(ByVal sender As Object, ByVal e As System.EventArgs)
        MostrarRetiro()
    End Sub

    Sub MostrarFondo()
        If mbs1.Current IsNot Nothing Then
            Me.L_MT1.Text = mbs1.Current("x4").ToString.Trim
        Else
            Me.L_MT1.Text = ""
        End If
    End Sub

    Sub MostrarRetiro()
        If mbs2.Current IsNot Nothing Then
            Me.L_MT2.Text = mbs2.Current("x4").ToString.Trim
        Else
            Me.L_MT2.Text = ""
        End If
    End Sub

    Private Sub MG_DOC_Accion(ByVal xrow As System.Windows.Forms.DataGridViewRow) Handles MG_DOC.Accion
        If xb1.Current IsNot Nothing Then
            Dim xauto As String = xb1.Current("auto").ToString.Trim
            Funciones.VisualizarDoc_Ventas(xauto)
        End If
    End Sub

    Private Sub BT_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_1.Click
        Try
            Dim xfecha As Date = g_MiData.p_FechaDelMotorBD.Date
            Dim xfil As String = ""
            Dim xfil2 As String = ""
            Dim ini As New SqlParameter("@ini", xfecha)
            Dim fin As New SqlParameter("@fin", xfecha)
            Dim xini As New SqlParameter("@ini", xfecha)
            Dim xfin As New SqlParameter("@fin", xfecha)

            LimpiarControles()

            If MF_1.Checked Then
                ini = New SqlParameter("@ini", Me.MF_1.Value.Date)
                xini = New SqlParameter("@ini", Me.MF_1.Value.Date)
                xfil += "and fecha_apert >=@ini "
                xfil2 += "and j.fecha_apert >=@ini "
            End If

            If MF_2.Checked Then
                fin = New SqlParameter("@fin", Me.MF_2.Value.Date)
                xfin = New SqlParameter("@fin", Me.MF_2.Value.Date)
                xfil += "and fecha_apert <=@fin "
                xfil2 += "and j.fecha_apert <=@fin "
            End If

            xtb2.Rows.Clear()
            xtb1.Rows.Clear()

            Dim xsql1 As String = ""
            Dim xp1 As SqlParameter
            xsql1 = "select fecha_apert as xfecha, hora_apert as xhora, nombre_usuario_apert as xnombre, auto as xauto from jornada " & _
                    "where SerialFiscal=@serialfiscal " + xfil + " order by auto desc"
            xp1 = New SqlParameter("@serialfiscal", Me.MCB_SERIAL_FISCAL.SelectedValue.ToString)
            g_MiData.F_GetData(xsql1, xtb1, xp1, ini, fin)

            xsql1 = "select o.fecha_inicio as xfecha, o.hora_inicio as xhora, o.usuario_nombre as xnombre, o.auto_jornada as xautojornada, o.auto as xauto from operadorjornada o join jornada j on o.auto_jornada=j.auto " & _
                    "where j.serialfiscal=@serialfiscal " + xfil2 + " order by o.auto desc"
            xp1 = New SqlParameter("@serialfiscal", Me.MCB_SERIAL_FISCAL.SelectedValue.ToString)
            g_MiData.F_GetData(xsql1, xtb2, xp1, xini, xfin)

        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub ValidarFechas(ByVal sender As Object, ByVal e As System.EventArgs) Handles MF_1.ValueChanged
        If (MF_1.Value.Date > MF_2.Value.Date) Then
            MF_2.Value = MF_1.Value
        End If
        BT_1.Select()
    End Sub

    Private Sub MF_2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MF_2.ValueChanged
        If (MF_2.Value.Date < MF_1.Value.Date) Then
            MF_1.Value = MF_2.Value
        End If
        BT_1.Select()
    End Sub

    Private Sub BT_CUADRE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CUADRE.Click
        Dim ds As DataSet
        Dim xtb As DataTable

        If xbs1.Current IsNot Nothing Then
            Try
                Dim xjor As String = xbs1.Current("xauto").ToString.Trim
                If xbs2.Current IsNot Nothing Then
                    Dim xop As String = xbs2.Current("xauto").ToString.Trim

                    Dim _MiJornada As New FastFood.Jornada
                    Dim _MiOperador As New FastFood.OperadorJornada
                    _MiJornada.F_BuscarCargar(xjor)
                    _MiOperador.F_BuscarCargar(xop)

                    ds = New DataSet
                    xtb = New DataTable("CuadreCaja")
                    With xtb.Columns
                        .Add("Fecha", GetType(String))
                        .Add("Operador", GetType(String))
                        .Add("Equipo", GetType(String))
                        .Add("TotalVentas", GetType(Decimal))
                        .Add("FactEmitidas", GetType(Decimal))
                        .Add("NotasCr", GetType(Decimal))
                        .Add("NcEmitidas", GetType(Decimal))
                        .Add("VentasCredito", GetType(Decimal))
                        .Add("VentCredEmitidas", GetType(Decimal))
                        .Add("FondoMonto", GetType(Decimal))
                        .Add("CantFondo", GetType(Decimal))
                        .Add("RetiroMonto", GetType(Decimal))
                        .Add("CantRetiro", GetType(Decimal))
                        .Add("Efectivo", GetType(Decimal))
                        .Add("TDebito", GetType(Decimal))
                        .Add("C_TDebito", GetType(Decimal))
                        .Add("TCredito", GetType(Decimal))
                        .Add("C_TCredito", GetType(Decimal))
                        .Add("Tickets", GetType(Decimal))
                        .Add("C_Tickets", GetType(Decimal))
                        .Add("Otros", GetType(Decimal))
                        .Add("Devoluciones", GetType(Decimal))
                        .Add("CantDev", GetType(Decimal))
                        .Add("Anulaciones", GetType(Decimal))
                        .Add("CantAnul", GetType(Decimal))
                        .Add("Pendiente", GetType(Decimal))
                        .Add("CantPend", GetType(Decimal))
                    End With

                    Dim xdr As DataRow = xtb.NewRow
                    xdr(0) = _MiJornada.RegistroDato._FechaApertura.ToShortDateString()
                    xdr(1) = _MiOperador.RegistroDato._UsuarioNombre
                    xdr(2) = ""

                    'VENTAS GENERALES
                    Dim xtbr As New DataTable
                    Dim xsql As String = ""
                    Dim xp1 As New SqlClient.SqlParameter("@jornada", _MiJornada.RegistroDato._AutoJornada)
                    Dim xp2 As New SqlClient.SqlParameter("@operador", _MiOperador.RegistroDato._AutoOperador)
                    xsql = "select sum(total) t1 ,count(*) t2 from ventas where auto_jornada=@jornada " _
                         + "and auto_operador=@operador and tipo='01' and estatus='0'"
                    g_MiData.F_GetData(xsql, xtbr, xp1, xp2)
                    If xtbr.Rows.Count > 0 Then
                        xdr(3) = xtbr.Rows(0)(0)
                        xdr(4) = xtbr.Rows(0)(1)
                    End If


                    xtbr = New DataTable
                    xp1 = New SqlClient.SqlParameter("@jornada", _MiJornada.RegistroDato._AutoJornada)
                    xp2 = New SqlClient.SqlParameter("@operador", _MiOperador.RegistroDato._AutoOperador)
                    xsql = "select sum(total) t1 ,count(*) t2 from ventas where auto_jornada=@jornada " _
                         + "and auto_operador=@operador and tipo='03' and estatus='0'"
                    g_MiData.F_GetData(xsql, xtbr, xp1, xp2)
                    If xtbr.Rows.Count > 0 Then
                        xdr(5) = IIf(IsDBNull(xtbr.Rows(0)(0)), 0, xtbr.Rows(0)(0))
                        xdr(6) = xtbr.Rows(0)(1)
                    End If

                    xtbr = New DataTable
                    xp1 = New SqlClient.SqlParameter("@jornada", _MiJornada.RegistroDato._AutoJornada)
                    xp2 = New SqlClient.SqlParameter("@operador", _MiOperador.RegistroDato._AutoOperador)
                    xsql = "select sum(total) t1 ,count(*) t2 from ventas where auto_jornada=@jornada " _
                         + "and auto_operador=@operador and tipo='01' and estatus='0' and condicion_pago='CREDITO'"
                    g_MiData.F_GetData(xsql, xtbr, xp1, xp2)
                    If xtbr.Rows.Count > 0 Then
                        xdr(7) = IIf(IsDBNull(xtbr.Rows(0)(0)), 0, xtbr.Rows(0)(0))
                        xdr(8) = xtbr.Rows(0)(1)
                    End If

                    xtbr = New DataTable
                    xp1 = New SqlClient.SqlParameter("@jornada", _MiJornada.RegistroDato._AutoJornada)
                    xp2 = New SqlClient.SqlParameter("@operador", _MiOperador.RegistroDato._AutoOperador)
                    xsql = "select sum(monto*signo) monto ,count(*) cant from FondoRetiroAperturaGaveta " & _
                           "where auto_jornada=@jornada and auto_operador=@operador and tipo='1'"
                    g_MiData.F_GetData(xsql, xtbr, xp1, xp2)
                    If xtbr.Rows.Count > 0 Then
                        xdr(9) = IIf(IsDBNull(xtbr.Rows(0)(0)), 0, xtbr.Rows(0)(0))
                        xdr(10) = xtbr.Rows(0)(1)
                    End If

                    xtbr = New DataTable
                    xp1 = New SqlClient.SqlParameter("@jornada", _MiJornada.RegistroDato._AutoJornada)
                    xp2 = New SqlClient.SqlParameter("@operador", _MiOperador.RegistroDato._AutoOperador)
                    xsql = "select sum(monto*signo) monto ,count(*) cant from FondoRetiroAperturaGaveta " & _
                           "where auto_jornada=@jornada and auto_operador=@operador and tipo='2'"
                    g_MiData.F_GetData(xsql, xtbr, xp1, xp2)
                    If xtbr.Rows.Count > 0 Then
                        xdr(11) = IIf(IsDBNull(xtbr.Rows(0)(0)), 0, xtbr.Rows(0)(0))
                        xdr(12) = xtbr.Rows(0)(1)
                    End If

                    xtbr = New DataTable
                    xp1 = New SqlClient.SqlParameter("@jornada", _MiJornada.RegistroDato._AutoJornada)
                    xp2 = New SqlClient.SqlParameter("@operador", _MiOperador.RegistroDato._AutoOperador)
                    xsql = "select sum(cmp.importe) total ,cmp.nombre, count(*) cant from ventas v, cxc_modo_pago cmp where v.auto_recibo=cmp.auto_recibo " & _
                    "and v.auto_jornada=@jornada and v.auto_operador=@operador and v.tipo='01' and v.estatus='0' group by cmp.codigo, cmp.nombre"
                    g_MiData.F_GetData(xsql, xtbr, xp1, xp2)

                    For Each dr In xtbr.Rows
                        Select Case dr(1).ToString.Trim.ToUpper
                            Case "EFECTIVO"
                                xdr(13) = IIf(IsDBNull(dr(0)), 0, dr(0))
                            Case "T.DEBITO"
                                xdr(14) = IIf(IsDBNull(dr(0)), 0, dr(0))
                                xdr(15) = IIf(IsDBNull(dr(0)), 0, dr(2))
                            Case "T.CREDITO"
                                xdr(16) = IIf(IsDBNull(dr(0)), 0, dr(0))
                                xdr(17) = IIf(IsDBNull(dr(0)), 0, dr(2))
                            Case "TICKETS"
                                xdr(18) = IIf(IsDBNull(dr(0)), 0, dr(0))
                                xdr(19) = IIf(IsDBNull(dr(0)), 0, dr(2))
                            Case "OTROS"
                                xdr(20) = IIf(IsDBNull(dr(0)), 0, dr(0))
                        End Select
                    Next

                    xtbr = New DataTable
                    xp1 = New SqlClient.SqlParameter("@jornada", _MiJornada.RegistroDato._AutoJornada)
                    xp2 = New SqlClient.SqlParameter("@operador", _MiOperador.RegistroDato._AutoOperador)
                    xsql = "select sum(prd_importe) t1, count(*) t2, 'Devoluciones' from pos_venta_devanulacion " & _
                             " where autojornada_devanu=@jornada  and autooperador_devanu=@operador and tipo_devanu='1' "
                    g_MiData.F_GetData(xsql, xtbr, xp1, xp2)
                    If xtbr.Rows.Count > 0 Then
                        xdr(21) = IIf(IsDBNull(xtbr.Rows(0)(0)), 0, xtbr.Rows(0)(0))
                        xdr(22) = xtbr.Rows(0)(1)
                    End If

                    xtbr = New DataTable
                    xp1 = New SqlClient.SqlParameter("@jornada", _MiJornada.RegistroDato._AutoJornada)
                    xp2 = New SqlClient.SqlParameter("@operador", _MiOperador.RegistroDato._AutoOperador)
                    xsql = "select sum(prd_importe) t1, count(*) t2, 'Anulaciones' from pos_venta_devanulacion " & _
                             " where autojornada_devanu=@jornada  and autooperador_devanu=@operador and tipo_devanu='2' group by auto_devanu"
                    g_MiData.F_GetData(xsql, xtbr, xp1, xp2)
                    If xtbr.Rows.Count > 0 Then
                        Dim xf1 = xtbr.AsEnumerable.Select(Function(s) s.Field(Of Decimal)("t1")).Sum
                        xdr(23) = xf1
                        xdr(24) = xtbr.Rows.Count
                    End If

                    xtbr = New DataTable
                    xp1 = New SqlClient.SqlParameter("@jornada", _MiJornada.RegistroDato._AutoJornada)
                    xp2 = New SqlClient.SqlParameter("@operador", _MiOperador.RegistroDato._AutoOperador)
                    xsql = "select sum(prd_importe) t1, count(*) t2, 'Ctas Pendientes' from pos_venta_devanulacion" & _
                             " where autojornada_devanu=@jornada  and autooperador_devanu=@operador and tipo_devanu='4' group by auto_devanu"
                    g_MiData.F_GetData(xsql, xtbr, xp1, xp2)
                    If xtbr.Rows.Count > 0 Then
                        Dim xf1 = xtbr.AsEnumerable.Select(Function(s) s.Field(Of Decimal)("t1")).Sum
                        xdr(25) = xf1
                        xdr(26) = xtbr.Rows.Count
                    End If

                    xtb.Rows.Add(xdr)
                    ds.Tables.Add(xtb)

                    Dim xtb2 As New DataTable("Empresa")
                    Dim xsql_1 As String = "select nombre, rif, direccion, telefono_1 telefono, sucursal, codigo_sucursal from empresa"
                    g_MiData.F_GetData(xsql_1, xtb2)
                    ds.Tables.Add(xtb2)

                    Dim xrep As String = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_RutaReportesSistema
                    xrep += "CuadreCaja.rpt"
                    Dim xficha As New _Reportes(ds, xrep, Nothing)
                    xficha.ShowDialog()

                End If
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub


End Class