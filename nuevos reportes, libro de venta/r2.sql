declare @desde as date
declare @hasta as date
set @desde= convert(date,'2012/08/01')
set @hasta= convert(date,'2012/08/31')

SELECT v.nombre, v.ci_rif, v.DOCUMENTO as Inicio, v.DOCUMENTO as Final, v.NRF, v.FECHA,
                    v.aplica, v.total tot, v.exento, v.base1, v.impuesto1, v.base2, v.impuesto2, v.tipo,
                    1 signo, tasa1, tasa2, '' control,
                    (select rv.fecha from retenciones_ventas rv join retenciones_ventas_detalle rvd on rv.auto=rvd.auto where rvd.auto_documento=v.auto and MONTH(rv.fecha_relacion)=MONTH(v.fecha) and YEAR(rv.fecha_relacion)=year(v.fecha)) fecha_ret,
                    (select rvd.retencion from retenciones_ventas rv join retenciones_ventas_detalle rvd on rv.auto=rvd.auto where rvd.auto_documento=v.auto and MONTH(rv.fecha_relacion)=MONTH(v.fecha) and YEAR(rv.fecha_relacion)=year(v.fecha)) retencion_iva,
                    (select rvd.comprobante from retenciones_ventas rv join retenciones_ventas_detalle rvd on rv.auto=rvd.auto where rvd.auto_documento=v.auto and MONTH(rv.fecha_relacion)=MONTH(v.fecha) and YEAR(rv.fecha_relacion)=year(v.fecha)) comprobante 
                    from ventas v where v.fecha >=@desde and v.fecha <=@hasta and v.TIPO='01' and len(v.ci_rif)>=12 and estatus='0' order by v.fecha,v.nrf,v.documento asc
