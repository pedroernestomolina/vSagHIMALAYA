declare @desde as date
declare @hasta as date
set @desde= convert(date,'2012/08/01')
set @hasta= convert(date,'2012/08/31')


         SELECT  v.NOMBRE, v.CI_RIF, v.DOCUMENTO as Inicio, v.DOCUMENTO as Final, v.NRF, v.FECHA, v.aplica,
               0.0 as tot, 0.0 as exento, 0.0 as base1, 0.0 as impuesto1, 0.0 as base2, 0.0 as impuesto2, 
               v.tipo, 1 as signo,v.tasa1, v.tasa2, '' as control, rvd.fecha_retencion  as fecha_ret, rvd.retencion retencion_iva ,
               rvd.comprobante from ventas v join retenciones_ventas_detalle rvd on rvd.auto_documento=v.auto 
               where rvd.fecha_retencion>=@desde and rvd.fecha_retencion<=@hasta 
         UNION 
         SELECT 'RESUMEN DIARIO Z' AS NOMBRE, '' AS CI_RIF, MIN(DOCUMENTO) as Inicio,
                MAX(DOCUMENTO) as Final, nrf, FECHA, '' as aplica, sum(total) as tot,
                sum(exento)as exento, sum(base1) as base1, sum(impuesto1) as impuesto1,
                sum(base2) as base2, sum(impuesto2) as impuesto2, tipo, 1 as signo, tasa1, tasa2, '' as control, null as fecha_ret,
                0.00 as retencion_iva, '' as comprobante 
                FROM VENTAS where tipo='01' and fecha>=@desde and fecha<=@hasta and estatus='0' 
                gROUP BY FECHA,NRF,tipo,tasa1,tasa2 
         UNION 
         SELECT NOMBRE,ci_rif, DOCUMENTO as Inicio, DOCUMENTO as Final, NRF, FECHA,
                aplica, total tot, exento, base1, impuesto1, base2, impuesto2, tipo,
                -1 as signo, tasa1, tasa2, control, null as fecha_ret, retencion_iva, '' as comprobante 
                FROM VENTAS where fecha>=@desde and fecha<=@hasta and TIPO='03' and estatus='0' 
         order by FECHA,NRF,tipo
