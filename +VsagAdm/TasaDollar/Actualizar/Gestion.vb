Namespace TasaDollar.Actualizar


    Public Class Gestion


        Private _tasaActual As Decimal
        Private _actualizarTasaIsOk As Boolean


        ReadOnly Property TasaActual As Decimal
            Get
                Return _tasaActual
            End Get
        End Property

        ReadOnly Property ActualizarTasaIsOk As Boolean
            Get
                Return _actualizarTasaIsOk
            End Get
        End Property


        Sub New()
            _tasaActual = 0.0
        End Sub


        Dim frm As TasaDollarFrm
        Sub Inicia()
            If CargarData() Then
                If frm Is Nothing Then
                    frm = New TasaDollarFrm
                    frm.setGestion(Me)
                End If
                frm.ShowDialog()
            End If
        End Sub

        Private Function CargarData() As Boolean
            Dim rt As Boolean = True

            Dim r01 = g_MiData.TasaActualDolar_GetData()
            If r01.Result = DataSistema.MiDataSistema.DataSistema.Resultado.EnumResult.isError Then
                MessageBox.Show(r01.Mensaje, "*** ERROR ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
            _tasaActual = r01.Entidad

            Return rt
        End Function

        Sub Guardar()
            _actualizarTasaIsOk = False
            If _tasaActual <> 0 Then
                Dim msg = MessageBox.Show("Actualizar Valor Tasa ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msg = DialogResult.Yes Then
                    Actualizar()
                End If
            End If
        End Sub

        Sub setTasaActual(valor As Decimal)
            _tasaActual = valor
        End Sub

        Private Sub Actualizar()
            Dim r01 = g_MiData.TasaActualDolar_ActualizarData(_tasaActual)
            If r01.Result = DataSistema.MiDataSistema.DataSistema.Resultado.EnumResult.isError Then
                MessageBox.Show(r01.Mensaje, "*** ERROR ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            MessageBox.Show("TASA ACTUALIZADA", "*** OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _actualizarTasaIsOk = True
        End Sub


    End Class


End Namespace