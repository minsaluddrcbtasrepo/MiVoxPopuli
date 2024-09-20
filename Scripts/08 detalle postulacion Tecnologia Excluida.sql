SELECT        te.Id AS TecnologiaId, te.Nombre AS TecnologiaNombre, tv.AnhoNominacion, tv.AnhoExclusion, tv.Resolucion, pt.Id AS PostulacionId, r.NOMBRE_USUARIO,r.NOMBRE, pt.FechaExcluida, pt.IdEstado, pt.TieneConflictoInteres, pt.EsFinanciero, 
                         pt.EsFamiliar, pt.EsIntelectual, pt.EsPertenencia, pt.DescripcionConflictoInteres, ie.Descripcion AS IndicacionDescripcion, an.Nombre AS AnexoNombre, an.DescripcionArchivo, an.Path, an.Justificacion
FROM            EXCLUSIONES.TecnoIogiaExCluida AS te INNER JOIN
                         EXCLUSIONES.TecnoIogiaExCluidaVigencia AS tv ON te.Id = tv.IdTecnoIogiaExcluida INNER JOIN
                         EXCLUSIONES.PostuacionTecnoIogiaExcIuida AS pt ON te.Id = pt.IdTecnoIogiaExcluida INNER JOIN
                         EXCLUSIONES.IndicacionExclusion AS ie ON te.Id = ie.IdTecnoIogiaExcluida INNER JOIN
                         EXCLUSIONES.CriterioExcIusion AS ce ON te.Id = ce.IdTecnoIogiaExcluida INNER JOIN
                         EXCLUSIONES.CriterioExcIusionPostulacion AS cep ON cep.IdCriterioExcIusion = ce.Id LEFT OUTER JOIN
                         EXCLUSIONES.AnexosCriterioExclusionPostulacion AS an ON an.IdCriterioExclusionPostulacion = cep.IdPostulacionTecnoIogiaExcluida
						 inner join REGISTRO r on pt.idusuario=r.COD_REGISTRO
ORDER BY TecnologiaNombre, pt.FechaExcluida