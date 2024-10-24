﻿using System;
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

        public static List<TecnologiaExcluidaDto> GetListadoTecnoIogiaExCluidaParaUsuario(int UsuarioRegistrado)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = @"SELECT        te.Id, te.Nombre AS tecnologia,te.DescripcionSeleccion, tv.AnhoExclusion AS vigencia, 0 AS postulado
                                    FROM            EXCLUSIONES.TecnoIogiaExCluida AS te INNER JOIN
                                                             EXCLUSIONES.TecnoIogiaExCluidaVigencia AS tv ON te.Id = tv.IdTecnoIogiaExcluida
						 
                                    where te.id not in ( select IdTecnoIogiaExcluida from EXCLUSIONES.PostuacionTecnoIogiaExcIuida where idUsuario=@idUsuario)
                                    ORDER BY vigencia, tecnologia
 ";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idUsuario", SqlDbType.Int) { Value = UsuarioRegistrado });

            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta, parametros);

            var resultadoList = resultado.ToList<TecnologiaExcluidaDto>();

            return resultadoList;
        }
        public static List<IndicacionExclusionDto> GetListadoTecnoIogiaExCluida(Int32 idTecnologia)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = @"
                                    select id,Descripcion as Nombre
                                    from EXCLUSIONES.IndicacionExclusion
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
                                    FROM EXCLUSIONES.TecnoIogiaExCluida te inner join EXCLUSIONES.CriterioExcIusion ce on te.Id=ce.IdTecnoIogiaExcluida
                                    inner join EXCLUSIONES.Criterio c on c.Id=ce.IdCriterio
                                    where ce.IdTecnoIogiaExcluida=@idTecnologia ";
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@idTecnologia", SqlDbType.Int) { Value = idTecnologia });

            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta, parametros);

            var resultadoList = resultado.ToList<CriterioExcIusionDto>();

            return resultadoList;
        }



        public static Int32 InsertPostuacionTecnoIogiaExcIuida(
                                                   PostulacionModel p)
        {
            SQLServerHelper helper = new SQLServerHelper();

            // Crear la consulta SQL con parámetros
            string sqlConsulta = @"
                    INSERT INTO EXCLUSIONES.PostuacionTecnoIogiaExcIuida (
                        IdTecnoIogiaExcluida,
                        FechaExcluida,
                        IdEstado,
                        IdUsuario,
                        TieneConflictoInteres,
                        EsFinanciero,
                        EsFamiliar,
                        EsIntelectual,
                        EsPertenencia,
                        DescripcionConflictoInteres
                    )
                    VALUES (
                        @IdTecnoIogiaExcluida,
                        @FechaExcluida,
                        @IdEstado,
                        @IdUsuario,
                        @TieneConflictoInteres,
                        @EsFinanciero,
                        @EsFamiliar,
                        @EsIntelectual,
                        @EsPertenencia,
                        @DescripcionConflictoInteres
                    )";

            // Crear los parámetros para la consulta SQL
            var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@IdTecnoIogiaExcluida", p.IdTecnologia),
                    new SqlParameter("@FechaExcluida", DateTime.Now),
                    new SqlParameter("@IdEstado", true ),
                    new SqlParameter("@IdUsuario", p.IdUsuario ),
                    new SqlParameter("@TieneConflictoInteres", p.ConflictoInteres),
                    new SqlParameter("@EsFinanciero", p.ConflictoInteresModel.ConflictoFinanciero),
                    new SqlParameter("@EsFamiliar", p.ConflictoInteresModel.ConflictoFamiliar),
                    new SqlParameter("@EsIntelectual", p.ConflictoInteresModel.ConflictoIntelectual),
                    new SqlParameter("@EsPertenencia", p.ConflictoInteresModel.ConflictoPertenencia),
                    new SqlParameter("@DescripcionConflictoInteres", p.ConflictoInteresModel.ConflictoInteres)
                };

            // Ejecutar la consulta SQL con los parámetros
            return helper.EjecutarSentenciaDB(sqlConsulta, parametros, true);
        }


        public static int InsertarCriterioExcIusionPostulacion(int idCriterioExcIusion, int idPostulacionTecnoIogiaExcluida)
        {
            SQLServerHelper helper = new SQLServerHelper();
            string sqlInsert = "INSERT INTO EXCLUSIONES.CriterioExcIusionPostulacion (IdCriterioExcIusion, IdPostulacionTecnoIogiaExcluida) " +
                               "VALUES (@IdCriterioExcIusion, @IdPostulacionTecnoIogiaExcluida)";

            List<SqlParameter> parametros = new List<SqlParameter>
                    {
                        new SqlParameter("@IdCriterioExcIusion", idCriterioExcIusion),
                        new SqlParameter("@IdPostulacionTecnoIogiaExcluida", idPostulacionTecnoIogiaExcluida),
                    };

            return helper.EjecutarSentenciaDB(sqlInsert, parametros, true);
        }

        public static int InsertarAnexoCriterioExcIusionPostulacion(int idCriterioPostulacion, string nombre, string descripcion, string rutaArchivo, string justificacion)
        {
            SQLServerHelper helper = new SQLServerHelper();
            // Definir la consulta SQL de inserción
            string sqlInsert = @"
                    INSERT INTO EXCLUSIONES.AnexosCriterioExclusionPostulacion
                    (IdCriterioExclusionPostulacion, Nombre, DescripcionArchivo, Path, Justificacion)
                    VALUES
                    (@IdCriterioExclusionPostulacion, @Nombre, @DescripcionArchivo, @Path, @Justificacion);                    ";

            // Crear la lista de parámetros
            List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@IdCriterioExclusionPostulacion", idCriterioPostulacion),
                    new SqlParameter("@Nombre", nombre),
                    new SqlParameter("@DescripcionArchivo", descripcion),
                    new SqlParameter("@Path", rutaArchivo),
                    new SqlParameter("@Justificacion", justificacion)
                };

            // Llamar al método para ejecutar la consulta e insertar el registro
            return helper.EjecutarSentenciaDB(sqlInsert, parametros, devuelveId: true);
        }




        public static int InsertarIndicadorPostulacion(int idPostulacion, int indicadorId)
        {

            SQLServerHelper helper = new SQLServerHelper();

            // Definir la consulta SQL de inserción
            string sqlInsert = @"
        INSERT INTO EXCLUSIONES.IndicacionExclusionPostulacion
        (IdPostulacionTecnologiaExcluida, IdIndicacionExclusion)
        VALUES
        (@IdPostulacionTecnologiaExcluida, @IdIndicacionExclusion);
        ";

            // Crear la lista de parámetros
            List<SqlParameter> parametros = new List<SqlParameter>
    {
        new SqlParameter("@IdPostulacionTecnologiaExcluida", idPostulacion),
        new SqlParameter("@IdIndicacionExclusion", indicadorId)
    };

            // Llamar al método para ejecutar la consulta e insertar el registro
            return helper.EjecutarSentenciaDB(sqlInsert, parametros, devuelveId: true);
        }

    }

    public class TecnologiaExcluidaDto
    {
        public int Id { get; set; }
        public string Tecnologia { get; set; }
        public string DescripcionSeleccion { get; set; }
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

    /// <summary>
    /// ////////////////////////////////////////
    /// </summary>
    /// 

    public class PostulacionModel
    {
        public int IdUsuario { get; set; }
        public bool ConflictoInteres { get; set; }
        public ConflictoInteresModel ConflictoInteresModel { get; set; }
        public int Vigencia { get; set; }
        public string Tecnologia { get; set; }
        public int IdTecnologia { get; set; }
        public List<Criterio> Criterios { get; set; }
        public List<string> Indicadores { get; set; }
    }


    public class PostulacionModelTEst
    {
        public bool ConflictoInteres { get; set; }
        public ConflictoInteresModel ConflictoInteresModel { get; set; }
        public int Vigencia { get; set; }
        public string Tecnologia { get; set; }
        public int IdTecnologia { get; set; }
        //public List<Criterio> Criterios { get; set; }
        public List<string> Indicadores { get; set; }
    }




    public class ConflictoInteresModel
    {
        public string ConflictoInteres { get; set; }
        public bool ConflictoFinanciero { get; set; }
        public bool ConflictoIntelectual { get; set; }
        public bool ConflictoPertenencia { get; set; }
        public bool ConflictoFamiliar { get; set; }
    }

    public class Criterio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Revisado { get; set; }
        public List<Anexo> Anexos { get; set; }
    }
    public class Anexo
    {
        public string Descripcion { get; set; }
        public string Justificacion { get; set; }
        public string RutaArchivo { get; set; }
        public string Nombre { get; set; }
    }



}
