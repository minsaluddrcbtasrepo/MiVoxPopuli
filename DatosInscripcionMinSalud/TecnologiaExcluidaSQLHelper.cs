using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace DatosInscripcionMinSalud
{

    public class TecnologiaExcluidaSQLHelper
    {

        public static List<TecnologiaExcluidaDto> GetListadoTecnoIogiaExCluida()
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = @"SELECT te.id ,te.Nombre as tecnologia,tv.AnhoExclusion as vigencia,0 as postulado 
                                    FROM TecnoIogiaExCluida te inner join TecnoIogiaExCluidaVigencia tv on te.Id=tv.IdTecnoIogiaExcluida
                                    ORDER BY tv.AnhoExclusion ,te.Nombre ";

            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta);

            var resultadoList = resultado.ToList<TecnologiaExcluidaDto>();

            return resultadoList;
        }
        public static List<IndicacionExclusionDto> GetListadoTecnoIogiaExCluida(Int32 idTecnologia)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = @"
                                    select id,Descripcion as Nombre
                                    from IndicacionExclusion
                                    where IdTecnoIogiaExcluida=@idTecnologia ";
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@idTecnologia", SqlDbType.Int) { Value = idTecnologia });

            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta, parametros);

            var resultadoList = resultado.ToList<IndicacionExclusionDto>();

            return resultadoList;
        }

        public static List<CriterioExcIusionDto> GetListadoCriterioExcIusion(Int32 idTecnologia)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = @"
                                    SELECT ce.id,c.Nombre
                                    FROM TecnoIogiaExCluida te inner join CriterioExcIusion ce on te.Id=ce.IdTecnoIogiaExcluida
                                    inner join Criterio c on c.Id=ce.IdCriterio
                                    where ce.IdTecnoIogiaExcluida=@idTecnologia ";
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@idTecnologia", SqlDbType.Int) { Value = idTecnologia });

            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta, parametros);

            var resultadoList = resultado.ToList<CriterioExcIusionDto>();

            return resultadoList;
        }



    }
    public class TecnologiaExcluidaDto
    {
        public int Id { get; set; }
        public string Tecnologia { get; set; }
        public string Vigencia { get; set; }
        public Boolean Postulado { get; set; }
    }

    public class IndicacionExclusionDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class CriterioExcIusionDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Boolean Revisado { get; set; }
    }

}
