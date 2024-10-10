
ALTER TABLE EXCLUSIONES.TecnoIogiaExCluida
ADD DescripcionSeleccion NVARCHAR(MAX) NOT NULL 
CONSTRAINT DF_TecnoIogiaExCluida_DescripcionSeleccion DEFAULT 'Seleccione las indicaciones por las cuales considera que se debe volver a incluir la tecnolog�a:';



update te set DescripcionSeleccion='Seleccione los CIE-10 relacionados a Dolor Neurop�tico de acuerdo a su solicitud de revisi�n de la decisi�n'
--select *
from EXCLUSIONES.TecnoIogiaExCluida te
where Nombre in ('ACETAMINOFEN + CODEINA�','ACETAMINOFEN + HIDROCODONA','BUPRENORFINA�')

select * from EXCLUSIONES.TecnoIogiaExCluida where Nombre in ('ACETAMINOFEN + CODEINA�','ACETAMINOFEN + HIDROCODONA','BUPRENORFINA�')


--------------------------------

delete  EXCLUSIONES.IndicacionExclusion where id in (
		select i.Id 
		from EXCLUSIONES.IndicacionExclusion i
		inner join EXCLUSIONES.TecnoIogiaExCluida te on te.Id=i.IdTecnoIogiaExcluida
		where te.Nombre in ('ACETAMINOFEN + CODEINA�','ACETAMINOFEN + HIDROCODONA','BUPRENORFINA�')
		and (Descripcion like '%Exclu_do en Dolor Neurop_tico%'
		or Descripcion like '%Diagn_sticos CIE-10 relacionados%'
		or Descripcion like '%Seleccionar Todo%'
		)
)


---------------------------
update ce set IdCriterio =4
--select * 
from EXCLUSIONES.TecnoIogiaExCluida te
inner join EXCLUSIONES.CriterioExcIusion ce on te.Id=ce.IdTecnoIogiaExcluida
where te.Nombre='ANAKINRA' and ce.IdCriterio=4