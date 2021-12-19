Imports DataSistema
Imports ImpFiscales.MisFiscales
Imports System.Data.SqlClient
Imports System.Xml
Imports DataSistema.MiDataSistema.DataSistema
Imports ImpresoraMatriz.ImpresoraMatriz
Imports VisorPrecio.MiVisorFiscal

''' <summary>
''' DEFINE EL EQUIPO - ESTACION DE TRABAJO A CONECTARSE AL SISTEMA
''' </summary>
Public Class EquipoEstacion
    Dim xnombre As String
    Dim xip As String

    ''' <summary>
    ''' NOMBRE DEL EQUIPO LOCAL
    ''' </summary>
    Property p_EstacionNombre() As String
        Get
            Return xnombre.Trim
        End Get
        Set(ByVal value As String)
            xnombre = value
        End Set
    End Property

    ''' <summary> 
    ''' IP DEL EQUIPO LOCAL
    ''' </summary>
    Property p_EstacionIp() As String
        Get
            Return xip.Trim
        End Get
        Set(ByVal value As String)
            xip = value
        End Set
    End Property

    Sub New()
        Try
            Me.p_EstacionIp = ""
            Me.p_EstacionNombre = ""
            With Me
                .p_EstacionNombre = My.Computer.Name
                .p_EstacionIp = RetornaIp()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

''' <summary>
''' DEFINE EL USUARIO A CONECTARSE AL SISTEMA
''' </summary>
''' <remarks></remarks>
Public Class Usuario
    Dim xnombre As String
    Dim xclave As String

    Property p_Usuario() As String
        Get
            Return xnombre.Trim
        End Get
        Set(ByVal value As String)
            xnombre = value
        End Set
    End Property

    Property p_Clave() As String
        Get
            Return xclave.Trim
        End Get
        Set(ByVal value As String)
            xclave = value
        End Set
    End Property

    Sub New()
        Me.p_Clave = ""
        Me.p_Usuario = ""
    End Sub
End Class

''' <summary>
''' DEFINE LAS POSIBLES ACCIONES A EFECTUAR EN UNA FICHA 
''' </summary>
Public Enum TipoAccionFicha As Integer
    Consultar = 1
    Adicionar = 2
    Modificar = 3
    Eliminar = 4
    Inactivo = 5
    ModificarOtro = 6
End Enum

''' <summary>
''' DEFINE LAS POSIBLES ACCIONES AL ENTRAR A UNA IMAGEN PICTUREBOX
''' </summary>
Public Enum EntradaSalida As Integer
    Entrada = 1
    Salida = 2
End Enum

''' <summary>
''' DEFINE LAS POSIBLES ACCIONES PARA EL USO DE LAS FICHAS
''' </summary>
Public Enum Encendido As Integer
    Encender = 1
    Apagar = 0
End Enum

''' <summary>
''' CLASE PARA EL MANEJO Y USO DE IMPRESORA FISCALL
''' </summary>
Public Class ImpresoraFiscal
    Private xpuerto As Integer
    Private xmodelo As Integer
    Private xestatus As Boolean
    Private ximpresora As IFiscal

    Property _Estatus() As Boolean
        Get
            Return xestatus
        End Get
        Set(ByVal value As Boolean)
            xestatus = value
        End Set
    End Property

    Property _Impresora() As IFiscal
        Get
            Return ximpresora
        End Get
        Set(ByVal value As IFiscal)
            ximpresora = value
        End Set
    End Property

    Property _Puerto() As Integer
        Get
            Return xpuerto
        End Get
        Set(ByVal value As Integer)
            xpuerto = value
        End Set
    End Property

    Property _Modelo() As Integer
        Get
            Return xmodelo
        End Get
        Set(ByVal value As Integer)
            xmodelo = value
        End Set
    End Property

    Sub New()
        _Estatus = False
        _Impresora = Nothing
        _Puerto = 0
        _Modelo = 0
    End Sub
End Class

''' <summary>
''' CLASE PARA EL MANEJO Y USO DE VISOR DE PRECIO
''' </summary>
Public Class VisorPrecio
    Private xestatus As Boolean
    Private xpuerto As Integer

    Property _Estatus() As Boolean
        Get
            Return xestatus
        End Get
        Set(ByVal value As Boolean)
            xestatus = value
        End Set
    End Property

    Property _Puerto() As Integer
        Get
            Return xpuerto
        End Get
        Set(ByVal value As Integer)
            xpuerto = value
        End Set
    End Property

    Sub New()
        _Estatus = False
        _Puerto = 0
    End Sub
End Class

''' <summary>
''' CLASE PARA DEFINIR LOS DISPOSITIVOS A CONECTAR POR EL SISTEMA
''' </summary>
Public Class Dispositivo_Sistema
    Private ximpresora As ImpresoraFiscal
    Private xvisorprecio As VisorPrecio

    Property _ImpresoraFiscal() As ImpresoraFiscal
        Get
            Return ximpresora
        End Get
        Set(ByVal value As ImpresoraFiscal)
            ximpresora = value
        End Set
    End Property

    Property _VisorPrecio() As VisorPrecio
        Get
            Return xvisorprecio
        End Get
        Set(ByVal value As VisorPrecio)
            xvisorprecio = value
        End Set
    End Property

    Sub New()
        _ImpresoraFiscal = New ImpresoraFiscal
        _VisorPrecio = New VisorPrecio
    End Sub
End Class

''' <summary>
''' CLASE PARA DEFINIR LOS RECURSOS USADOS POR LOS DISTINTOS TIPOS DE FORMATOS USADOS PARA CADA DOCUMENTO A IMPRIMIR EN MODO TEXTO
''' </summary>
Public Class FormatoModoTexto
    Private xruta As String
    Private xtipopapel As ManejoImpresora.TipoPapel
    Private xcantidadlineasdetallesimprimir As Integer

    Property _RutaImpresoraTexto() As String
        Get
            Return xruta.Trim
        End Get
        Set(ByVal value As String)
            xruta = value
        End Set
    End Property

    Property _CantidadLineasDetalleImprimir() As Integer
        Get
            Return xcantidadlineasdetallesimprimir
        End Get
        Set(ByVal value As Integer)
            xcantidadlineasdetallesimprimir = value
        End Set
    End Property

    Property _TipoPapelUsar() As ManejoImpresora.TipoPapel
        Get
            Return xtipopapel
        End Get
        Set(ByVal value As ManejoImpresora.TipoPapel)
            xtipopapel = value
        End Set
    End Property

    Sub New()
        Me._CantidadLineasDetalleImprimir = 0
        Me._TipoPapelUsar = 0
        Me._RutaImpresoraTexto = ""
    End Sub
End Class

''' <summary>
''' DEFINE LA CLASE DE CONFIGURACION DEL SISTEMA
''' </summary>
Public Class ConfiguracionSistema
    Private xnombreservidor As String
    Private xinstancia As String
    Private xbasedato As String
    Private xidunicodelequipo
    Private xserie_factura As String
    Private xserie_notaentrega As String
    Private xserie_notacredito As String
    Private xserie_notadebito As String
    Private xdispositivios As Dispositivo_Sistema
    Private xdocumentofactura_modotexto As FormatoModoTexto
    Private xdocumentochimbo_modotexto As FormatoModoTexto
    Private xrutaimpresoratexto As String
    Private xrutaimpresoratexto_notas As String
    Private xmodofactura As String
    Private xitem As Integer


    Property _ModoFactura() As String
        Get
            Return xmodofactura.ToUpper.Trim
        End Get
        Set(ByVal value As String)
            xmodofactura = value
        End Set
    End Property

    Property _Item() As Integer
        Get
            Return xitem
        End Get
        Set(ByVal value As Integer)
            xitem = value
        End Set
    End Property

    Property _NombreServidor() As String
        Get
            Return xnombreservidor
        End Get
        Set(ByVal value As String)
            xnombreservidor = value
        End Set
    End Property

    Property _InstanciaServidor() As String
        Get
            Return xinstancia
        End Get
        Set(ByVal value As String)
            xinstancia = value
        End Set
    End Property

    Property _NombreBaseDato() As String
        Get
            Return xbasedato
        End Get
        Set(ByVal value As String)
            xbasedato = value
        End Set
    End Property

    Property _Id_UnicoDelEquipo() As String
        Get
            Return xidunicodelequipo
        End Get
        Set(ByVal value As String)
            xidunicodelequipo = value
        End Set
    End Property

    Property _SerieFactura() As String
        Get
            Return xserie_factura.Trim
        End Get
        Set(ByVal value As String)
            xserie_factura = value
        End Set
    End Property

    Property _SerieNotaEntegra() As String
        Get
            Return xserie_notaentrega.Trim
        End Get
        Set(ByVal value As String)
            xserie_notaentrega = value
        End Set
    End Property

    Property _SerieNotaCredito() As String
        Get
            Return xserie_notacredito.Trim
        End Get
        Set(ByVal value As String)
            xserie_notacredito = value
        End Set
    End Property

    Property _SerieNotaDebito() As String
        Get
            Return xserie_notadebito.Trim
        End Get
        Set(ByVal value As String)
            xserie_notadebito = value
        End Set
    End Property

    Property _Dispositivos() As Dispositivo_Sistema
        Get
            Return xdispositivios
        End Get
        Set(ByVal value As Dispositivo_Sistema)
            xdispositivios = value
        End Set
    End Property

    Property _DocumentoFactura_ModoTexto() As FormatoModoTexto
        Get
            Return xdocumentofactura_modotexto
        End Get
        Set(ByVal value As FormatoModoTexto)
            xdocumentofactura_modotexto = value
        End Set
    End Property

    Property _DocumentoChimbo_ModoTexto() As FormatoModoTexto
        Get
            Return xdocumentochimbo_modotexto
        End Get
        Set(ByVal value As FormatoModoTexto)
            xdocumentochimbo_modotexto = value
        End Set
    End Property

    Property _RutaImpresoraTexto() As String
        Get
            Return xrutaimpresoratexto
        End Get
        Set(ByVal value As String)
            xrutaimpresoratexto = value
        End Set
    End Property

    Property _RutaImpresoraTextoNotas() As String
        Get
            Return xrutaimpresoratexto_notas
        End Get
        Set(ByVal value As String)
            xrutaimpresoratexto_notas = value
        End Set
    End Property


    Sub New()
        _InstanciaServidor = ""
        _NombreServidor = ""
        _NombreBaseDato = ""
        _Id_UnicoDelEquipo = ""

        _SerieFactura = ""
        _SerieNotaCredito = ""
        _SerieNotaDebito = ""
        _SerieNotaEntegra = ""

        _Dispositivos = New Dispositivo_Sistema

        _DocumentoFactura_ModoTexto = New FormatoModoTexto
        _DocumentoChimbo_ModoTexto = New FormatoModoTexto
        _RutaImpresoraTexto = ""
        _RutaImpresoraTextoNotas = ""
        _ModoFactura = ""
        _Item = 0
    End Sub
End Class

Public Class TotalesDoc
    Private xlineas As Integer
    Private xneto1 As Decimal
    Private xneto2 As Decimal
    Private xneto3 As Decimal
    Private xexento As Decimal
    Private xtasa1 As Decimal
    Private xtasa2 As Decimal
    Private xtasa3 As Decimal
    Private xdescuento1_p As Decimal
    Private xdescuento1_m As Decimal
    Private xcargo_p As Decimal
    Private xchimbo As Boolean
    Private xtabla_pagos As DataTable
    Private xnotas_detalle As String
    Private xhabilitar_medios_pago As Boolean
    Private xsaldonc As Decimal
    Private xsaldoanticipo As Decimal
    Private ximpuestolicor As Decimal
    Private _cliente As FichaClientes.c_Clientes.c_Registro
    Private _items As DataTable


    Property Cliente() As FichaClientes.c_Clientes.c_Registro
        Get
            Return _cliente
        End Get
        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
            _cliente = value
        End Set
    End Property
    Property Items() As DataTable
        Get
            Return _items
        End Get
        Set(ByVal value As DataTable)
            _items = value
        End Set
    End Property


    Property _ImpuestoLicor() As Decimal
        Get
            Return ximpuestolicor
        End Get
        Set(ByVal value As Decimal)
            ximpuestolicor = value
        End Set
    End Property

    Property _SaldoAFavorNotaCredito() As Decimal
        Get
            Return xsaldonc
        End Get
        Set(ByVal value As Decimal)
            xsaldonc = value
        End Set
    End Property

    Property _SaldoAFavorAnticipo() As Decimal
        Get
            Return xsaldoanticipo
        End Get
        Set(ByVal value As Decimal)
            xsaldoanticipo = value
        End Set
    End Property

    Property _HabilitarMediosPagos() As Boolean
        Get
            Return xhabilitar_medios_pago
        End Get
        Set(ByVal value As Boolean)
            xhabilitar_medios_pago = value
        End Set
    End Property

    Property _NotasDetalle() As String
        Get
            Return xnotas_detalle.Trim
        End Get
        Set(ByVal value As String)
            xnotas_detalle = value
        End Set
    End Property

    Property _TablaPagos() As DataTable
        Get
            Return xtabla_pagos
        End Get
        Set(ByVal value As DataTable)
            xtabla_pagos = value
        End Set
    End Property

    Property _TasaCargo() As Decimal
        Get
            Return xcargo_p
        End Get
        Set(ByVal value As Decimal)
            xcargo_p = value
        End Set
    End Property

    Property _TasaDescuento() As Decimal
        Get
            Return xdescuento1_p
        End Get
        Set(ByVal value As Decimal)
            xdescuento1_p = value
            RecalcularBases()
        End Set
    End Property

    Property _MontoDescuento() As Decimal
        Get
            Return xdescuento1_m
        End Get
        Set(ByVal value As Decimal)
            xdescuento1_m = value
        End Set
    End Property

    Private _montoCargo As Decimal
    Property MontoCargo() As Decimal
        Get
            Return _montoCargo
        End Get
        Set(ByVal value As Decimal)
            _montoCargo = value
        End Set
    End Property

    Property _Lineas() As Integer
        Get
            Return xlineas
        End Get
        Set(ByVal value As Integer)
            xlineas = value
        End Set
    End Property

    Property _TasaIva1() As Decimal
        Get
            Return xtasa1
        End Get
        Set(ByVal value As Decimal)
            xtasa1 = value
        End Set
    End Property

    Property _TasaIva2() As Decimal
        Get
            Return xtasa2
        End Get
        Set(ByVal value As Decimal)
            xtasa2 = value
        End Set
    End Property

    Property _TasaIva3() As Decimal
        Get
            Return xtasa3
        End Get
        Set(ByVal value As Decimal)
            xtasa3 = value
        End Set
    End Property

    Property _Exento() As Decimal
        Get
            Return xexento
        End Get
        Set(ByVal value As Decimal)
            xexento = value
        End Set
    End Property

    Property _Neto1() As Decimal
        Get
            Return xneto1
        End Get
        Set(ByVal value As Decimal)
            xneto1 = value
        End Set
    End Property

    ReadOnly Property _Iva1() As Decimal
        Get
            Dim xt As Decimal = 0
            xt = Me._Neto1 * Me._TasaIva1 / 100
            Return xt
        End Get
    End Property

    Property _Neto2() As Decimal
        Get
            Return xneto2
        End Get
        Set(ByVal value As Decimal)
            xneto2 = value
        End Set
    End Property

    ReadOnly Property _Iva2() As Decimal
        Get
            Dim xt As Decimal = 0
            xt = Me._Neto2 * Me._TasaIva2 / 100
            Return xt
        End Get
    End Property

    Property _Neto3() As Decimal
        Get
            Return xneto3
        End Get
        Set(ByVal value As Decimal)
            xneto3 = value
        End Set
    End Property

    ReadOnly Property _Iva3() As Decimal
        Get
            Dim xt As Decimal = 0
            xt = Me._Neto3 * Me._TasaIva3 / 100
            Return xt
        End Get
    End Property

    ''' <summary>
    ''' Sumatoria de bases + exento, sin descuentos ni cargos globales
    ''' </summary>
    ReadOnly Property _Subtotal() As Decimal
        Get
            Dim xsubt As Decimal = (xexento + xneto1 + xneto2 + xneto3)
            Return Decimal.Round(xsubt, 2, MidpointRounding.AwayFromZero)
        End Get
    End Property

    ReadOnly Property _SubtotalBases() As Decimal
        Get
            Dim xsubt As Decimal = (Me._Neto1 + Me._Neto2 + Me._Neto3)
            Return Decimal.Round(xsubt, 2, MidpointRounding.AwayFromZero)
        End Get
    End Property

    ReadOnly Property _SubtotalIva() As Decimal
        Get
            Dim xsubt As Decimal = (Me._Iva1 + Me._Iva2 + Me._Iva3)
            Return Decimal.Round(xsubt, 2, MidpointRounding.AwayFromZero)
        End Get
    End Property

    ReadOnly Property _TotalGeneral() As Decimal
        Get
            Dim xtot As Decimal = Me._Subtotal + Me._SubtotalIva
            Return Decimal.Round(xtot, 2, MidpointRounding.AwayFromZero)
        End Get
    End Property

    Property _DocChimbo() As Boolean
        Get
            Return xchimbo
        End Get
        Set(ByVal value As Boolean)
            xchimbo = value
        End Set
    End Property

    Sub RecalcularBases()
        Dim d As Decimal = 0.0
        d = xexento * xdescuento1_p / 100
        xexento -= d

        d = xneto1 * xdescuento1_p / 100
        xneto1 -= d

        d = xneto2 * xdescuento1_p / 100
        xneto2 -= d

        d = xneto3 * xdescuento1_p / 100
        xneto3 -= d
    End Sub


    Sub New()
        Me._Exento = 0
        Me._Lineas = 0
        Me._Neto1 = 0
        Me._Neto2 = 0
        Me._Neto3 = 0
        Me._TasaIva1 = 0
        Me._TasaIva2 = 0
        Me._TasaIva3 = 0
        Me._DocChimbo = False
        Me._TasaDescuento = 0
        Me._TasaCargo = 0
        Me._NotasDetalle = ""
        Me._HabilitarMediosPagos = False
        Me._SaldoAFavorAnticipo = 0
        Me._SaldoAFavorNotaCredito = 0
        Me._ImpuestoLicor = 0
        Me.Cliente = New FichaClientes.c_Clientes.c_Registro
        Me.Items = New DataTable
        Me.MontoCargo = 0.0

    End Sub
End Class

Public Class DocumentosPagar
    Private xfecha As Date
    Private xtipodoc As String
    Private xnumerodoc As String
    Private xresta As Decimal
    Private xauto As String
    Private xidseguridad As Byte()

    Property _FechaEmision() As Date
        Get
            Return xfecha
        End Get
        Set(ByVal value As Date)
            xfecha = value
        End Set
    End Property

    Property _TipoDocumento() As String
        Get
            Return xtipodoc.Trim
        End Get
        Set(ByVal value As String)
            xtipodoc = value
        End Set
    End Property

    Property _NumeroDocumento() As String
        Get
            Return xnumerodoc.Trim
        End Get
        Set(ByVal value As String)
            xnumerodoc = value
        End Set
    End Property

    Property _MontoPendiente() As Decimal
        Get
            Return xresta
        End Get
        Set(ByVal value As Decimal)
            xresta = value
        End Set
    End Property

    Property _AutoDocumento() As String
        Get
            Return xauto.Trim
        End Get
        Set(ByVal value As String)
            xauto = value
        End Set
    End Property

    Property _IdSeguridad() As Byte()
        Get
            Return xidseguridad
        End Get
        Set(ByVal value As Byte())
            xidseguridad = value
        End Set
    End Property

    Sub New()
        Me._AutoDocumento = ""
        Me._FechaEmision = Date.MinValue
        Me._MontoPendiente = 0
        Me._NumeroDocumento = ""
        Me._TipoDocumento = ""
    End Sub
End Class

Public Class DocumentosNC
    Private xfecha As Date
    Private xnumerodoc As String
    Private xmonto As Decimal
    Private xestatus As Integer
    Private xauto As String
    Private xidseguridad As Byte()

    Property _FechaEmision() As Date
        Get
            Return xfecha
        End Get
        Set(ByVal value As Date)
            xfecha = value
        End Set
    End Property

    Property _NumeroDocumento() As String
        Get
            Return xnumerodoc.Trim
        End Get
        Set(ByVal value As String)
            xnumerodoc = value
        End Set
    End Property

    Property _MontoImporte() As Decimal
        Get
            Return xmonto
        End Get
        Set(ByVal value As Decimal)
            xmonto = value
        End Set
    End Property

    Property _AutoDocumento() As String
        Get
            Return xauto.Trim
        End Get
        Set(ByVal value As String)
            xauto = value
        End Set
    End Property

    Property _Estatus() As Integer
        Get
            Return xestatus
        End Get
        Set(ByVal value As Integer)
            xestatus = value
        End Set
    End Property

    Property _IdSeguridad() As Byte()
        Get
            Return xidseguridad
        End Get
        Set(ByVal value As Byte())
            xidseguridad = value
        End Set
    End Property

    Sub New()
        Me._AutoDocumento = ""
        Me._FechaEmision = Date.MinValue
        Me._MontoImporte = 0
        Me._NumeroDocumento = ""
        Me._Estatus = 0
    End Sub
End Class

Public Class DecretoEmergencia

    Class Condicion

        Private _montoMayorA As Decimal
        Property MontoMayorA() As Decimal
            Get
                Return _montoMayorA
            End Get
            Set(ByVal value As Decimal)
                _montoMayorA = value
            End Set
        End Property

        Private _montoMenorIgual As Decimal
        Property MontoMenorIgual() As Decimal
            Get
                Return _montoMenorIgual
            End Get
            Set(ByVal value As Decimal)
                _montoMenorIgual = value
            End Set
        End Property

        Private _tasaAplica As Integer
        Property TasaAplica() As Integer
            Get
                Return _tasaAplica
            End Get
            Set(ByVal value As Integer)
                _tasaAplica = value
            End Set
        End Property


        Sub New()
            With Me
                .MontoMayorA = 0
                .MontoMenorIgual = 0
                .TasaAplica = 0
            End With
        End Sub
    End Class

    Private _desdeFecha As Date
    Property DesdeFecha() As Date
        Get
            Return _desdeFecha
        End Get
        Set(ByVal value As Date)
            _desdeFecha = value
        End Set
    End Property

    Private _periodoDias As Integer
    Property PeriodoDias() As Integer
        Get
            Return _periodoDias
        End Get
        Set(ByVal value As Integer)
            _periodoDias = value
        End Set
    End Property

    Private _claveSeguridad As String
    Property ClaveSeguridad() As String
        Get
            Return _claveSeguridad
        End Get
        Set(ByVal value As String)
            _claveSeguridad = value
        End Set
    End Property

    Private _activarDecreto As Boolean
    Property ActivarDecreto() As Boolean
        Get
            Return _activarDecreto
        End Get
        Set(ByVal value As Boolean)
            _activarDecreto = value
        End Set
    End Property

    ReadOnly Property DecretoEmergenciaActivo() As Boolean
        Get
            Dim r As Boolean = False
            If ActivarDecreto Then
                Dim fecha As Date = Now.Date
                Dim HastaFecha As Date = Now.Date
                If PeriodoDias > 0 Then
                    HastaFecha = DateAdd(DateInterval.Day, PeriodoDias, DesdeFecha)
                End If
                If fecha >= DesdeFecha AndAlso fecha <= HastaFecha Then
                    r = True
                End If
            End If
            Return r
        End Get
    End Property

    Private _condiciones As List(Of Condicion)
    Property Condiciones() As List(Of Condicion)
        Get
            Return _condiciones
        End Get
        Set(ByVal value As List(Of Condicion))
            _condiciones = value
        End Set
    End Property

    Sub New()
        With Me
            .DesdeFecha = Date.Now
            .PeriodoDias = 0
            .ClaveSeguridad = ""
            .ActivarDecreto = False
            .Condiciones = New List(Of Condicion)
            .Condiciones.Add(New Condicion With {.MontoMayorA = 0, .MontoMenorIgual = 2000000, .TasaAplica = 3})
            .Condiciones.Add(New Condicion With {.MontoMayorA = 2000000, .MontoMenorIgual = 0, .TasaAplica = 2})
        End With
    End Sub

End Class


Module ModuloPrincipal
    Public Const PaginaFoxSystem As String = "http://www.foxsystem.com.ve"
    Public Const PaginaInicioWeb As String = "http://www.google.com"
    Public Const PaginaInicioSeniat As String = "http://contribuyente.seniat.gob.ve/BuscaRif/BuscaRif.jsp"
    Public Const PaginaSeniatRetenciones As String = "http://retenciones.seniat.gob.ve/retencionesivaext/prueba.do"

    Dim xdata1 As MiDataSistema.DataSistema
    Dim xcadenaconexion As SqlConnectionStringBuilder
    Dim xhora As Timer
    Dim xequipolocal As EquipoEstacion
    Dim ximpfiscal As IFiscal
    Dim xvisorprecio As MiVisorPrecio
    Dim xconfsistema As ConfiguracionSistema
    Dim xcalculadora As MiCalculadora.Calc
    Public PERIODO_VENTA_TRANSCURRIR As Integer = 0
    Public BLOQUEAR_VENTAS As Boolean = False
    Private _MiDecretoEmergencia As DecretoEmergencia


    Property g_VisorPrecio() As MiVisorPrecio
        Get
            Return xvisorprecio
        End Get
        Set(ByVal value As MiVisorPrecio)
            xvisorprecio = value
        End Set
    End Property

    Property g_ImpFiscal() As IFiscal
        Get
            Return ximpfiscal
        End Get
        Set(ByVal value As IFiscal)
            ximpfiscal = value
        End Set
    End Property

    Property g_MiData() As MiDataSistema.DataSistema
        Get
            Return xdata1
        End Get
        Set(ByVal value As DataSistema.MiDataSistema.DataSistema)
            xdata1 = value
        End Set
    End Property

    Property g_ConstructorCadena() As SqlConnectionStringBuilder
        Get
            Return xcadenaconexion
        End Get
        Set(ByVal value As SqlConnectionStringBuilder)
            xcadenaconexion = value
        End Set
    End Property

    Property g_MiHora() As Timer
        Get
            Return xhora
        End Get
        Set(ByVal value As Timer)
            xhora = value
        End Set
    End Property

    Property g_EquipoEstacion() As EquipoEstacion
        Get
            Return xequipolocal
        End Get
        Set(ByVal value As EquipoEstacion)
            xequipolocal = value
        End Set
    End Property

    Property g_ConfiguracionSistema() As ConfiguracionSistema
        Get
            Return xconfsistema
        End Get
        Set(ByVal value As ConfiguracionSistema)
            xconfsistema = value
        End Set
    End Property

    Property g_MiCalculadora() As MiCalculadora.Calc
        Get
            Return xcalculadora
        End Get
        Set(ByVal value As MiCalculadora.Calc)
            xcalculadora = value
        End Set
    End Property

    Property MiDecretoEmergencia() As DecretoEmergencia
        Get
            Return _MiDecretoEmergencia
        End Get
        Set(ByVal value As DecretoEmergencia)
            _MiDecretoEmergencia = value
        End Set
    End Property


    Sub main()
        Try
            Application.EnableVisualStyles()
            Inicializa()

            Dim xform As New Login
            With xform
                .ShowDialog()
                If ._EntradaExitosa Then
                    g_MiData.F_CargaInicial(._AutomaticoUsuario)

                    If g_ConfiguracionSistema._ModoFactura <> "" Then
                        Select Case g_ConfiguracionSistema._ModoFactura
                            Case "FISCAL" : g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = TipoImpresora.Fiscal
                                g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALNCR_MedioImpresion = TipoImpresora.Fiscal
                            Case "TEXTO" : g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = TipoImpresora.Texto
                                g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALNCR_MedioImpresion = TipoImpresora.Texto
                            Case "GRAFICO" : g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = TipoImpresora.Grafico
                                g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._ALNCR_MedioImpresion = TipoImpresora.Grafico

                        End Select
                    End If

                    If g_ConfiguracionSistema._Item > 0 Then
                        g_MiData.f_FichaGlobal.f_ConfSistema.cnf_ModuloVentas._Limite_Renglones_Factura = g_ConfiguracionSistema._Item
                    End If

                    Dim gestion As New Gestion()
                    Dim xficha As New Principal
                    xficha.setGestion(gestion)
                    xficha.ShowDialog()
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje Alerta ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Sub Inicializa()
        g_ConfiguracionSistema = New ConfiguracionSistema
        g_MiHora = New Timer
        g_EquipoEstacion = New EquipoEstacion
        MiDecretoEmergencia = New DecretoEmergencia

        CargarXmlConfiguracion()
        g_ConstructorCadena = New SqlConnectionStringBuilder
        With g_ConstructorCadena
            .DataSource = g_ConfiguracionSistema._InstanciaServidor
            .InitialCatalog = g_ConfiguracionSistema._NombreBaseDato
            'Del (Sistema)
            .Password = "112233-fs"
            .UserID = "Usuario"
            'PRUEBA
            '.Password = "1301AS"
            '.UserID = "sa"
        End With

        g_MiData = New MiDataSistema.DataSistema(g_ConstructorCadena.ConnectionString)
        g_MiData.p_TipoSistema = TipoSistema.Administrativo
        g_ImpFiscal = g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora

        If g_ConfiguracionSistema._Dispositivos._VisorPrecio._Estatus Then
            g_VisorPrecio = New MiVisorPrecio(g_ConfiguracionSistema._Dispositivos._VisorPrecio._Puerto)
        End If
    End Sub

    Sub CargarXmlConfiguracion()
        Try
            Dim doc As New XmlDocument
            doc.Load(My.Application.Info.DirectoryPath + "\Configuracion.XML")

            Dim ACTIVAR_DT230_FACHADA As Boolean = False
            If doc.HasChildNodes Then
                For Each node_raiz As XmlNode In doc
                    If node_raiz.LocalName.ToUpper.Trim = "CONFIGURACION" Then

                        For Each xnode_elemento As XmlNode In node_raiz.ChildNodes
                            If xnode_elemento.LocalName.ToUpper.Trim = "MISERVIDOR" Then
                                For Each nodo As XmlNode In xnode_elemento.ChildNodes
                                    If nodo.LocalName.ToUpper.Trim = "INSTANCIA" Then
                                        g_ConfiguracionSistema._InstanciaServidor = nodo.InnerText
                                    End If
                                    If nodo.LocalName.ToUpper.Trim = "CATALOGO" Then
                                        g_ConfiguracionSistema._NombreBaseDato = nodo.InnerText
                                    End If
                                    If nodo.LocalName.ToUpper.Trim = "NOMBRESERVIDOR" Then
                                        g_ConfiguracionSistema._NombreServidor = nodo.InnerText
                                    End If
                                Next
                            End If

                            If xnode_elemento.LocalName.ToUpper.Trim = "VARIABLESDECONFIGURACION" Then
                                For Each nodo As XmlNode In xnode_elemento.ChildNodes
                                    If nodo.LocalName.ToUpper.Trim = "ID_DEL_EQUIPO" Then
                                        If nodo.InnerText.Trim = "" Then
                                            Try
                                                AsignarId(doc, nodo)
                                            Catch ex As Exception
                                                Throw New Exception(ex.Message)
                                            End Try
                                        Else
                                            g_ConfiguracionSistema._Id_UnicoDelEquipo = nodo.InnerText
                                        End If
                                    End If

                                    If nodo.LocalName.ToUpper.Trim = "DEFINESERIESDOCUMENTOS" Then
                                        For Each nodo_2 As XmlNode In nodo.ChildNodes
                                            If nodo_2.LocalName.ToUpper.Trim = "FACTURA" Then
                                                g_ConfiguracionSistema._SerieFactura = nodo_2.InnerText
                                            End If
                                            If nodo_2.LocalName.ToUpper.Trim = "NOTAENTREGA" Then
                                                g_ConfiguracionSistema._SerieNotaEntegra = nodo_2.InnerText
                                            End If
                                            If nodo_2.LocalName.ToUpper.Trim = "NOTACREDITO" Then
                                                g_ConfiguracionSistema._SerieNotaCredito = nodo_2.InnerText
                                            End If
                                            If nodo_2.LocalName.ToUpper.Trim = "NOTADEBITO" Then
                                                g_ConfiguracionSistema._SerieNotaDebito = nodo_2.InnerText
                                            End If
                                        Next
                                    End If

                                Next
                            End If

                            If xnode_elemento.LocalName.ToUpper.Trim = "DISPOSITIVOS" Then
                                For Each nodo As XmlNode In xnode_elemento.ChildNodes
                                    If nodo.LocalName.ToUpper.Trim = "IMPRESORAFISCAL" Then
                                        For Each nodo_2 As XmlNode In nodo.ChildNodes
                                            If nodo_2.LocalName.ToUpper.Trim = "ACTIVAR" Then
                                                If nodo_2.InnerText.Trim.ToUpper = "SI" Then
                                                    g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Estatus = True
                                                Else
                                                    g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Estatus = False
                                                    Exit For
                                                End If
                                            End If
                                            If nodo_2.LocalName.ToUpper.Trim = "PUERTOCONECTAR" Then
                                                Try
                                                    Dim xr As Integer = 0
                                                    Integer.TryParse(nodo_2.InnerText, xr)
                                                    g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora.PuertoConexion = xr
                                                    g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Puerto = xr
                                                Catch ex As Exception
                                                    Throw New Exception("DEBE INDICAR PRIMERO EL MODELO A USAR Y LUEGO EL PUERTO A CONECTAR")
                                                End Try
                                            End If
                                            If nodo_2.LocalName.ToUpper.Trim = "MODELOUSAR" Then
                                                Select Case nodo_2.InnerText.Trim.ToUpper
                                                    Case "01", "14" 'SAMSUNG, STAR
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Samsung(0, Samsung.xModelosFiscales.Bixolon_270)
                                                    Case "02" 'BIXLON 350
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Samsung_350(0)
                                                    Case "03" 'ACLAS
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Aclas(0, Aclas.xModelosFiscales.Aclas)
                                                    Case "04" 'BMC
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New BMC(0, BMC.xModelosFiscales.BmcSpark_614)
                                                    Case "07" 'OKY
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Oky(0)
                                                    Case "08" 'SAMSUNG
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Samsung(0, Samsung.xModelosFiscales.Kube)
                                                    Case "05" 'EPSON PF220
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Epson_PF220(0, ModelosFiscales.EPSON_PF220)
                                                    Case "06" 'EPSON PF300
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Epson_PF300(0, ModelosFiscales.EPSON_PF300)
                                                    Case "10" 'EPSON PF300
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Epson_PF300(0, ModelosFiscales.EPSON_PF300_BLANCA)
                                                    Case "09" 'BEMATECH
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Bematech(0, Bematech.xModelosFiscales.MP_4000)
                                                    Case "11" 'DASCOM
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New DasconTally(0)
                                                    Case "12" 'HKA112
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New HKA_112(0)
                                                    Case "15" 'CUSTOM_KUBE_II
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Custom_KUBE_II(0)
                                                    Case "16" 'DT230
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New DT230(0)
                                                        ACTIVAR_DT230_FACHADA = True
                                                    Case "17" 'ACLAS PP9
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New ACLAS_PP9(0)
                                                    Case "18" '812
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New BIXOLON_812(0)
                                                    Case "19" 'LIB FISCAL THK
                                                        g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New Tfhka(0)
                                                    Case Else
                                                        Throw New Exception("DEBE DEFINIR UN MODELO DE IMPRESORA FISCAL VALIDO")
                                                End Select
                                                Dim xr As Integer = 0
                                                Integer.TryParse(nodo_2.InnerText, xr)
                                                g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Modelo = xr
                                            End If
                                        Next
                                    End If

                                    If nodo.LocalName.ToUpper.Trim = "VISORPRECIOS" Then
                                        For Each nodo_2 As XmlNode In nodo.ChildNodes
                                            If nodo_2.LocalName.ToUpper.Trim = "ACTIVAR" Then
                                                If nodo_2.InnerText.Trim.ToUpper = "SI" Then
                                                    g_ConfiguracionSistema._Dispositivos._VisorPrecio._Estatus = True
                                                Else
                                                    g_ConfiguracionSistema._Dispositivos._VisorPrecio._Estatus = False
                                                    Exit For
                                                End If
                                            End If
                                            If nodo_2.LocalName.ToUpper.Trim = "PUERTOCONECTAR" Then
                                                Dim xr As Integer = 0
                                                Integer.TryParse(nodo_2.InnerText, xr)
                                                g_ConfiguracionSistema._Dispositivos._VisorPrecio._Puerto = xr
                                            End If
                                        Next
                                    End If
                                Next
                            End If

                            If xnode_elemento.LocalName.ToUpper.Trim = "RUTAIMPRESORATEXTO" Then
                                g_ConfiguracionSistema._RutaImpresoraTexto = xnode_elemento.InnerText.Trim
                            End If
                            If xnode_elemento.LocalName.ToUpper.Trim = "RUTAIMPRESORATEXTOOTRAS" Then
                                g_ConfiguracionSistema._RutaImpresoraTextoNotas = xnode_elemento.InnerText.Trim
                            End If

                            If xnode_elemento.LocalName.ToUpper.Trim = "MODOIMPRESIONFACTURA" Then
                                For Each nodo_2 As XmlNode In xnode_elemento.ChildNodes
                                    If nodo_2.LocalName.ToUpper.Trim = "MODO" Then
                                        g_ConfiguracionSistema._ModoFactura = nodo_2.InnerText
                                    End If
                                    If nodo_2.LocalName.ToUpper.Trim = "ITEMS" Then
                                        Dim xit As Integer = 0
                                        Integer.TryParse(nodo_2.InnerText, xit)
                                        g_ConfiguracionSistema._Item = xit
                                    End If
                                Next
                            End If

                            If xnode_elemento.LocalName.ToUpper.Trim = "BLOQUEAR_VENTAS" Then
                                If xnode_elemento.InnerText.Trim.ToUpper = "SI" Then
                                    BLOQUEAR_VENTAS = True
                                End If
                            End If

                            If xnode_elemento.LocalName.ToUpper.Trim = "PERIODO_VENTA_TRANSCURRIR" Then
                                Integer.TryParse(xnode_elemento.InnerText.Trim, PERIODO_VENTA_TRANSCURRIR)
                            End If
                        Next
                    End If
                Next
            End If
            If ACTIVAR_DT230_FACHADA Then
                g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Impresora = New DT230_Fachada(g_ConfiguracionSistema._Dispositivos._ImpresoraFiscal._Puerto)
            End If

            doc.Load(My.Application.Info.DirectoryPath + "\DecretoEmergencia.xml")
            If doc.DocumentElement.HasChildNodes Then
                For Each xnode As XmlNode In doc.DocumentElement
                    If xnode.LocalName.ToUpper.Trim = "DESDE" Then
                        MiDecretoEmergencia.DesdeFecha = Date.Parse(xnode.InnerText.Trim)
                    End If
                    If xnode.LocalName.ToUpper.Trim = "PERIODODIAS" Then
                        MiDecretoEmergencia.PeriodoDias = Integer.Parse(xnode.InnerText.Trim)
                    End If
                    If xnode.LocalName.ToUpper.Trim = "ACTIVARDECRETO" Then
                        MiDecretoEmergencia.ActivarDecreto = If(xnode.InnerText.Trim.ToUpper = "SI", True, False)
                    End If
                    If xnode.LocalName.ToUpper.Trim = "DECRETONRO" Then
                        MiDecretoEmergencia.ClaveSeguridad = xnode.InnerText.Trim
                    End If
                Next
            End If
        Catch ex As Exception
            Throw New Exception("MODULO: FUNCIONES - CARGAR XML" + vbCrLf + ex.Message + vbCrLf)
        End Try
    End Sub

    Function AsignarId(ByVal xdoc As XmlDocument, ByVal xnodo As XmlNode) As Boolean
        Try
            Dim xid As New Guid
            xid = Guid.NewGuid
            g_ConfiguracionSistema._Id_UnicoDelEquipo = xid.ToString
            xnodo.InnerText = xid.ToString

            xdoc.Save(My.Application.Info.DirectoryPath + "\Configuracion.XML")
            Return True
        Catch ex As Exception
            Throw New Exception("NO SE HA PODIDO GENERAR UN ID UNICO AL EQUIPO, VERIFIQUE POR FAVOR" + vbCrLf + ex.Message)
        End Try
    End Function
End Module
