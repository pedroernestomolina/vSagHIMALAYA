Imports DataSistema.MiDataSistema.DataSistema

Public Class InvProducto_UbicacionNivel
    Event _FichaDepositoActualizada_ok()

    Dim xprd_dep As FichaProducto.Prd_Deposito.c_Registro
    Dim xsalida As Boolean = False


    Property _ProductoDeposito() As FichaProducto.Prd_Deposito.c_Registro
        Get
            Return Me.xprd_dep
        End Get
        Set(ByVal value As FichaProducto.Prd_Deposito.c_Registro)
            Me.xprd_dep = value
        End Set
    End Property

    Property _SalidaOk() As Boolean
        Get
            Return Me.xsalida
        End Get
        Set(ByVal value As Boolean)
            Me.xsalida = value
        End Set
    End Property

    Sub New(ByVal xprdoducto_deposito As FichaProducto.Prd_Deposito.c_Registro)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._ProductoDeposito = xprdoducto_deposito
    End Sub

    Private Sub InvProducto_UbicacionNivel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _SalidaOk Then
            e.Cancel = False
        Else
            If MessageBox.Show("Estas Seguro De Perder Los Datos Modificados En Esta Plantilla ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub InvProducto_UbicacionNivel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub InvProducto_UbicacionNivel_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub InicializarControles()
        With Me.MT_1
            .Text = ""
            .MaxLength = _ProductoDeposito.c_Ubicacion1.c_Largo
        End With
        With Me.MT_2
            .Text = ""
            .MaxLength = _ProductoDeposito.c_Ubicacion2.c_Largo
        End With
        With Me.MT_3
            .Text = ""
            .MaxLength = _ProductoDeposito.c_Ubicacion3.c_Largo
        End With
        With Me.MT_4
            .Text = ""
            .MaxLength = _ProductoDeposito.c_Ubicacion4.c_Largo
        End With

        With Me.MN_1
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
        With Me.MN_2
            ._Formato = "9999999.99"
            ._ConSigno = False
            .Text = "0.0"
        End With
    End Sub

    Sub ActualizarData()
        Me.E_DEPOSITO.Text = _ProductoDeposito._f_FichaDeposito._Nombre
        Me.E_PRODUCTO.Text = _ProductoDeposito._f_FichaProducto._DescripcionDetallaDelProducto
        Me.E_0.Text = "Codigo: " + _ProductoDeposito._f_FichaProducto._CodigoProducto
        Me.E_1.Text = "Unidad/Empaque: " + _ProductoDeposito._f_FichaProducto._NombreEmpaqueCompra
        Me.E_2.Text = "Contenido/Empaque: " + String.Format("{0:#0}", _ProductoDeposito._f_FichaProducto._ContEmpqCompra)

        Me.MT_1.Text = _ProductoDeposito._Ubicacion_1
        Me.MT_2.Text = _ProductoDeposito._Ubicacion_2
        Me.MT_3.Text = _ProductoDeposito._Ubicacion_3
        Me.MT_4.Text = _ProductoDeposito._Ubicacion_4
        Me.MN_1.Text = String.Format("{0:#0.00}", _ProductoDeposito._NivelMinimo)
        Me.MN_2.Text = String.Format("{0:#0.00}", _ProductoDeposito._NivelOptimo)
    End Sub

    Sub Inicializa()
        Try
            InicializarControles()
            ActualizarData()
            IrInicio()
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub BT_PROCESAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_PROCESAR.Click
        If MessageBox.Show("Deseas Guardar Estos Cambios ?", "*** Mensaje De Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim xmod As New FichaProducto.Prd_Producto.c_ModificarDatosDeposito
                With xmod
                    ._NivelMinimo = MN_1._Valor
                    ._NivelOptimo = MN_2._Valor
                    ._Ubicacion1 = MT_1.r_Valor
                    ._Ubicacion2 = MT_2.r_Valor
                    ._Ubicacion3 = MT_3.r_Valor
                    ._Ubicacion4 = MT_4.r_Valor
                    ._FichaProductoDeposito = _ProductoDeposito
                End With
                Dim xficha As New FichaProducto.Prd_Producto
                xficha.F_ModficarDatosDeposito(xmod)
                Funciones.MensajeDeOk("Movimiento Realizado Satisfactoriamente...")

                RaiseEvent _FichaDepositoActualizada_ok()
                _SalidaOk = True
                Me.Close()
            Catch ex As Exception
                Funciones.MensajeDeError(ex.Message)
            End Try
        Else
            IrInicio()
        End If
    End Sub

    Sub IrInicio()
        Me.MT_1.Select()
        Me.MT_1.Focus()
    End Sub
End Class