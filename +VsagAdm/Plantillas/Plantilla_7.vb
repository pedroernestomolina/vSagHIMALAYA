Imports DataSistema.MiDataSistema.DataSistema
Imports System.Data.SqlClient

Public Class Plantilla_7
    Event BuscarCliente(ByVal xauto As String)

    Dim xfichacli As FichaClientes.c_Clientes

    'PARA BUSQUEDA DE CLIENTES RAPIDAS
    Const Busqueda_1 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where nombre like @data order by nombre"
    Const Busqueda_2 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where ci_rif like @data order by nombre"
    Const Busqueda_3 As String = "select nombre nom, telefono_1 tel, celular_1 cel, * from clientes where codigo like @data order by nombre"

    Sub Inicializa()
        Try
            xfichacli = New FichaClientes.c_Clientes

            With Me.MCB_BUSQUEDA
                .DataSource = xfichacli.p_TipoBusqueda
                .SelectedIndex = g_MiData.f_FichaGlobal.f_ConfSistema.cnf_BuscarCliente
            End With

            Me.MT_BUSCAR.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Plantilla_7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            Me.MT_BUSCAR.Select()
        End If
    End Sub

    Private Sub Plantilla_7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Plantilla_7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicializa()
    End Sub

    Private Sub MCB_BUSQUEDA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCB_BUSQUEDA.SelectedIndexChanged
        Me.MT_BUSCAR.Select()
    End Sub

    Private Sub BT_BUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUSCAR.Click
        BusquedaClientes()
    End Sub

    Sub BusquedaClientes()
        If MT_BUSCAR.r_Valor <> "" Then
            Dim xsql As String = ""
            Dim xp1 As SqlParameter
            Dim xbuscar As String = ""

            Select Case CType(Me.MCB_BUSQUEDA.SelectedIndex, FichaClientes.TipoBusquedaCliente)
                Case FichaClientes.TipoBusquedaCliente.PorNombreRazonSocial
                    xsql = Busqueda_1
                Case FichaClientes.TipoBusquedaCliente.PorRif_CI
                    xsql = Busqueda_2
                Case FichaClientes.TipoBusquedaCliente.PorCodigo
                    xsql = Busqueda_3
            End Select

            If MT_BUSCAR.Text.Substring(0, 1) = "*" Then
                xbuscar = "%" + MT_BUSCAR.r_Valor.Substring(1)
            Else
                xbuscar = MT_BUSCAR.r_Valor
            End If

            xp1 = New SqlParameter("@data", xbuscar + "%")
            Dim xficha As New Plantilla_2(New BusquedaCliente, xsql, xp1)
            With xficha
                AddHandler .EnviarAuto, AddressOf ClienteSeleccionado
                .ShowDialog()
            End With
            Me.MT_BUSCAR.Text = ""
        End If
        Me.MT_BUSCAR.Select()
    End Sub

    Private Sub BT_BUS_AVANZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_BUS_AVANZ.Click
        BusquedaAvanzada()
    End Sub

    Sub BusquedaAvanzada()
        Dim xficha As New BusAvanzadaCliente
        With xficha
            AddHandler .LlamarReceptor, AddressOf ReceptorBusAvanzada
            .ShowDialog()
        End With
    End Sub

    Sub ReceptorBusAvanzada(ByVal xsql As String)
        Dim xficha As New Plantilla_2(New BusquedaCliente, xsql)
        With xficha
            AddHandler .EnviarAuto, AddressOf ClienteSeleccionado
            .ShowDialog()
        End With
    End Sub

    Sub ClienteSeleccionado(ByVal xauto As String)
        RaiseEvent BuscarCliente(xauto)
        Me.Close()
    End Sub
End Class