Imports CrystalDecisions.Shared

Public Class _Reportes

    Class ParamtCrystal
        Dim xParNombre As String
        Dim xparValor As Object

        Sub New(ByVal xnombre As String, ByVal xvalor As Object)
            xParNombre = xnombre
            xparValor = xvalor
        End Sub

        Property Nombre() As String
            Get
                Return xParNombre
            End Get
            Set(ByVal value As String)
                xParNombre = value
            End Set
        End Property

        Property Valor() As Object
            Get
                Return xparValor
            End Get
            Set(ByVal value As Object)
                xparValor = value
            End Set
        End Property
    End Class

    Dim xds As DataSet
    Dim xrp As String
    Dim xlista As List(Of ParamtCrystal)

    Property _ListaParametros() As List(Of ParamtCrystal)
        Get
            Return xlista
        End Get
        Set(ByVal value As List(Of ParamtCrystal))
            xlista = value
        End Set
    End Property

    Property _MiReporte() As String
        Get
            Return xrp.Trim
        End Get
        Set(ByVal value As String)
            xrp = value
        End Set
    End Property

    Property _MiDataSet() As DataSet
        Get
            Return xds
        End Get
        Set(ByVal value As DataSet)
            xds = value
        End Set
    End Property

    Sub New(ByVal xds As DataSet, ByVal xrep As String, ByVal xlist As List(Of ParamtCrystal))

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _MiDataSet = xds
        _MiReporte = xrep
        _ListaParametros = xlist
    End Sub

    Private Sub r_Manejador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub _Reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim CrReport As CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            CrReport.Load(_MiReporte)
            CrReport.SetDataSource(_MiDataSet)

            If _ListaParametros IsNot Nothing Then
                For Each obj As ParamtCrystal In _ListaParametros
                    CrReport.SetParameterValue(obj.Nombre, obj.Valor)
                Next
            End If

            CrystalReportViewer1.ReportSource = CrReport
        Catch ex As Exception
            Funciones.MensajeDeError(ex.Message)
        End Try
    End Sub
End Class