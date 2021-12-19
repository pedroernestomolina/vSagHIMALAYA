Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class UsuariosPermiso
    Enum AccionEjecutar As Integer
        Actualizar = 1
        Guardar = 2
        Nada = 3
    End Enum

    Dim xtb As DataTable
    Dim xtb_opciones As DataTable
    Dim xbs As BindingSource
    Dim xbs_opciones As BindingSource
    Dim xvalor_opcion As String
    Dim xmodulos As String() = {"Clientes", "Productos", "Proveedor", "Vendedores", "Cobradores", _
                                "Ventas", "Cuentas Por Cobrar", "Servicio Fiscal", "Compras", "Gastos", "Cuentas Por Pagar", "Usuarios", _
                                "Configuracion Dispositivos", "Configuracion Sistema", "Servicios", _
                                "Punto De Venta Off Line", "Punto De Venta On Line", "Punto De Venta On Line Ver Nueva", _
                                "(FastFood / Restaurant)"}
    Dim xaccion As AccionEjecutar

    Property _MiAccion() As AccionEjecutar
        Get
            Return xaccion
        End Get
        Set(ByVal value As AccionEjecutar)
            xaccion = value

            Select Case value
                Case AccionEjecutar.Nada
                    Me.MisGrid1.ReadOnly = True
                    Me.BT_ACTUALIZAR.Enabled = True
                    Me.BT_GRABAR.Enabled = False
                    Me.MCB_1.Enabled = True
                    Me.MCB_2.Enabled = True
                Case AccionEjecutar.Actualizar
                    Me.MisGrid1.ReadOnly = False
                    Me.MisGrid1.Columns(0).ReadOnly = True
                    Me.MisGrid1.Columns(2).ReadOnly = True
                    Me.BT_ACTUALIZAR.Enabled = False
                    Me.BT_GRABAR.Enabled = True
                    Me.MCB_1.Enabled = False
                    Me.MCB_2.Enabled = False
            End Select
        End Set
    End Property

    Property _ValorOpcion() As String
        Get
            Return xvalor_opcion
        End Get
        Set(ByVal value As String)
            xvalor_opcion = value
        End Set
    End Property

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xtb_opciones = New DataTable
        xbs_opciones = New BindingSource(xtb_opciones, "")
    End Sub

    Private Sub UsuariosPermiso_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _MiAccion = AccionEjecutar.Actualizar Then
            If MessageBox.Show("Estas Seguro De Salir Y Perder Los Cambios Efectuados ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub UsuariosPermiso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub UsuariosPermiso_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub CargarData()
        g_MiData.F_GetData("select nombre nom, * from grupo_usuario order by nombre", xtb)
    End Sub

    Sub Inicializa()
        Try
            CargarData()
            With Me.MCB_1
                .DataSource = xbs
                .DisplayMember = "nombre"
                .ValueMember = "auto"
                AddHandler .SelectedIndexChanged, AddressOf ActualizarGrupoUsuario
            End With

            CargarOpciones()
            Dim xcol1 As New DataGridViewCheckBoxColumn
            With xcol1
                .Name = "col1"
                .HeaderText = "Permiso"
                .Width = 80
            End With

            With Me.MisGrid1
                .Columns.Add("col0", "Nombre / Funcion")
                .Columns.Add(xcol1)
                .Columns.Add("col2", "Nivel")

                .Columns(2).Width = 100
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs_opciones
                .Columns(0).DataPropertyName = "xnom"
                .Columns(1).DataPropertyName = "xestatus"
                .Columns(2).DataPropertyName = "xseguridad"

                .Ocultar(4)
            End With

            With Me.MCB_2
                .DataSource = xmodulos
                .SelectedIndex = 0
                AddHandler .SelectedIndexChanged, AddressOf ActualizarFiltro
            End With
            ActualizarFiltro()

            With Me.ToolTip1
                .Active = True
                .AutomaticDelay = 100
                .AutoPopDelay = 5000
            End With

            Me._MiAccion = AccionEjecutar.Nada
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Sub ActualizarFiltro()
        Select Case Me.MCB_2.SelectedIndex
            Case 0 : xbs_opciones.Filter = "((xcodigo like '0101%') or (xcodigo like '0102%') or (xcodigo like '0103%') or (xcodigo like '0199%'))" 'Clientes
            Case 1 : xbs_opciones.Filter = "((xcodigo like '0301%') or (xcodigo like '0302%') or (xcodigo like '0303%') or (xcodigo like '0304%') " & _
                                             "or (xcodigo like '0305%') or (xcodigo like '0306%') or (xcodigo like '0307%') or (xcodigo like '0310%') " & _
                                             "or (xcodigo like '0399%'))"
            Case 2 : xbs_opciones.Filter = "((xcodigo like '02%') or (xcodigo like '0602%'))"   'Proveedores
            Case 3 : xbs_opciones.Filter = "xcodigo like '09%'"   'Vendedores
            Case 4 : xbs_opciones.Filter = "xcodigo like '0104%'" 'Cobradores
            Case 5 : xbs_opciones.Filter = "((xcodigo like '08%') and (xcodigo not like '0808%'))" ' ventas
            Case 6 : xbs_opciones.Filter = "xcodigo like '04%'"   'Cuentas por Cobrar
            Case 7 : xbs_opciones.Filter = "xcodigo like ''" 'SERVICIO FISCAL
            Case 8 ' Compras
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_TipoSistemaInstalado > TipoSistemaInstalado.Basico Then
                    xbs_opciones.Filter = "xcodigo like '07%'"   '
                Else
                    MessageBox.Show("Modulo No Activado", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MCB_2.SelectedIndex = 0
                End If
            Case 9 : xbs_opciones.Filter = "xcodigo like ''" 'Gastos
            Case 10 ' Cuentas Por Pagar
                If g_MiData.f_FichaGlobal.f_ConfSistema.cnf_TipoSistemaInstalado > TipoSistemaInstalado.Basico Then
                    xbs_opciones.Filter = "xcodigo like '05%'"   'Cuentas Por Pagar
                Else
                    MessageBox.Show("Modulo No Activado", "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MCB_2.SelectedIndex = 0
                End If
            Case 11 : xbs_opciones.Filter = "((xcodigo like '1207%') or (xcodigo like '1208%') or (xcodigo like '1215%'))" 'Usuarios
            Case 12 : xbs_opciones.Filter = "xcodigo like '13%'" ' CONFIGURACION DISPOSITIVOS
            Case 13 : xbs_opciones.Filter = "((xcodigo like '1201%') or (xcodigo like '1202%') or (xcodigo like '1204%') or (xcodigo like '1206%') " & _
                                           "or (xcodigo like '0601%'))" 'Configuracion SISTEMA
            Case 14 : xbs_opciones.Filter = "((xcodigo like '1212%') or (xcodigo like '1213%') or (xcodigo like '1101%') or (xcodigo like '1216%')) or (xcodigo like '1217%')" 'Servicio
            Case 15 : xbs_opciones.Filter = "(xcodigo like '0808%')  AND (xcodigo not like '0808FF%') AND (xcodigo not like '0808RT%') AND (xcodigo not like '0808POS%')"   'Punto De Ventas Off LIne
            Case 16 : xbs_opciones.Filter = "(xcodigo like '0808%') and (xcodigo not like '080803%') AND (xcodigo not like '080804%') " & _
                                           "AND (xcodigo not like '080810%') AND (xcodigo not like '080811%') AND (xcodigo not like '080815%') AND (xcodigo not like '080816%') " & _
                                           "AND (xcodigo not like '080825%') AND (xcodigo not like '080826%') AND (xcodigo not like '080833%') AND (xcodigo not like '080834%') " & _
                                           "AND (xcodigo not like '080835%') AND (xcodigo not like '0808FF%') AND (xcodigo not like '0808RT%') AND (xcodigo not like '0808POS%')" 'Punto De Ventas On Line
            Case 17 : xbs_opciones.Filter = "xcodigo like '0808POS%'"
            Case 18 : xbs_opciones.Filter = "(xcodigo like '0808FF%') or (xcodigo like '0808RT%')" 'comida rapida FASTFOOD / RESTAURANT
        End Select
    End Sub

    Sub ActualizarGrupoUsuario()
        Try
            Dim xp1 As New SqlParameter("@grupo", Me.MCB_1.SelectedValue)
            Dim xsql As String = "select o.nombre xnom , case og.estatus when '1' then 1 when '0' then 0 end xestatus, og.seguridad xseguridad," & _
              "o.codigo xcodigo, o.*, og.* from opciones o join grupo_opciones og on o.codigo=og.codigo_opcion " & _
              "where og.codigo_grupo=@grupo and o.estatus='0' order by og.codigo_opcion "
            g_MiData.F_GetData(xsql, xtb_opciones, xp1)
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub CargarOpciones()
        If xbs.Current IsNot Nothing Then
            ActualizarGrupoUsuario()
        Else
            Funciones.MensajeDeAlerta("Problema Al Cargar Opciones")
            Me.Close()
        End If
    End Sub

    Private Sub MisGrid1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MisGrid1.CellDoubleClick
        If _MiAccion = AccionEjecutar.Actualizar Then
            If e.RowIndex <> -1 Then
                If e.ColumnIndex = 2 Then
                    Dim xclas As New NivelSeguridad
                    AddHandler xclas._EnviarOpcion, AddressOf GuardarOpcion
                    Dim xnivel As New Plantilla_ConfiguracionModulo_2(xclas)
                    xnivel.ShowDialog()

                    If _ValorOpcion <> "" Then
                        xbs_opciones.Current("xseguridad") = _ValorOpcion
                    End If
                End If
            End If
        End If
    End Sub

    Sub GuardarOpcion(ByVal xop As String)
        _ValorOpcion = xop
    End Sub

    Private Sub BT_ACTUALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ACTUALIZAR.Click
        Me._MiAccion = AccionEjecutar.Actualizar
    End Sub

    Private Sub BT_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GRABAR.Click
        If MessageBox.Show("Estas Seguro De Querer Guardar Todos Estos Nuevos Cambios Para Este Grupo ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                For Each dr As DataRowView In xbs_opciones
                    Dim xrw As DataRow = CType(dr, DataRowView).Row
                    Dim xficha As New FichaGlobal.OpcionPermiso
                    With xficha
                        If xrw("xestatus").ToString.Trim.ToUpper = "1" Then
                            ._EstatusOpcion = "1"
                        Else
                            ._EstatusOpcion = "0"
                        End If
                        ._GrupoUsuario = Me.MCB_1.SelectedValue
                        Select Case xrw("xseguridad").ToString.Trim.ToUpper
                            Case "MAXIMO" : ._NivelSeguridad = FichaGlobal.c_PermisosDelUsuario.Nivel.Nivel_Maximo
                            Case "MEDIO" : ._NivelSeguridad = FichaGlobal.c_PermisosDelUsuario.Nivel.Nivel_Medio
                            Case "MINIMO" : ._NivelSeguridad = FichaGlobal.c_PermisosDelUsuario.Nivel.Nivel_Minimo
                            Case "NINGUNA" : ._NivelSeguridad = FichaGlobal.c_PermisosDelUsuario.Nivel.Nivel_Libre
                        End Select
                        ._OpcionCambiar = xrw("xcodigo")
                    End With
                    g_MiData.f_FichaGlobal.F_ActualizarPermiso(xficha)
                Next
                Funciones.MensajeDeOk("Opciones Actualizadas Con Exito...")
                _MiAccion = AccionEjecutar.Nada
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LK_1.LinkClicked
        Try
            g_MiData.f_FichaGlobal.f_PermisosUsuario.op_ModuloGrupoUsuario.F_Permitir()

            Dim xForm As New Plantilla_1(New GrupoUsuario)
            With xForm
                .ShowDialog()
            End With
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub

    Private Sub UsuariosPermiso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class