using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace DatosInscripcionMinSalud
{
    public class DatosParticipante
    {

        public DataRow BuscarParticipante(string usuario)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = string.Format("SELECT digitoVerificacion,digitoVerificacionRepresentante,Nombres, Apellidos, NumeroIdentificacion, IdEstadoUsuario FROM Participante WHERE NumeroIdentificacion = '{0}' ", usuario);

            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta);


            if (resultado.Rows.Count > 0)
            {
                return resultado.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public DataRow BuscarParticipante(string usuario, string contrasena)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = string.Format("SELECT digitoVerificacion,digitoVerificacionRepresentante,Nombres, Apellidos, NumeroIdentificacion, IdEstadoUsuario FROM Participante WHERE NumeroIdentificacion = '{0}' AND Contrasena = '{1}'", usuario, contrasena);

            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta);


            if (resultado.Rows.Count > 0)
            {
                return resultado.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public void deleteParticipantePorNumeroIdentificacion(string numeroIdentificacion)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = string.Format("DELETE FROM Participante WHERE NumeroIdentificacion = '{0}' ",
                numeroIdentificacion.Trim());

            helper.EjecutarSentenciaDB(sqlConsulta);
        }

        public DataRow BuscarParticipantePorNumeroIdentificacion(string numeroIdentificacion)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = string.Format("SELECT digitoVerificacion,digitoVerificacionRepresentante,NumeroIdentificacion,IdTipoUsuario,Nombres,Apellidos,NombreRepresentanteLegal,IdTipoIdentificacion,IdTipoIdentificacionRepresentante, " +
            "NumeroIdentificacionRepresentante,PathNumeroIdentificacion,PathConstitucionGrupo,PatologiaAsociacion,PathCertificacionPatologia,Email,Telefono, " +
            "Celular,NumeroAsociados,Direccion,Genero,Certifico,Autorizo,Contrasena,FechaRetiro,IdPreguntaSecreta,RespuestaPregunta,IdEstadoUsuario,IdMunicipio, " +
            "FechaRegistro,FechaActualizacion, IdDepartamento, " +
            "AutorizoEmail, ValorContrasena FROM Participante INNER JOIN Municipio ON Participante.IdMunicipio = Municipio.Id WHERE NumeroIdentificacion = '{0}' ", numeroIdentificacion.Trim());

            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta);


            if (resultado.Rows.Count > 0)
            {
                return resultado.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public DataRow BuscarParticipantePorCorreo(string correo)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = string.Format("SELECT digitoVerificacion,digitoVerificacionRepresentante,NumeroIdentificacion,IdTipoUsuario,Nombres,Apellidos,NombreRepresentanteLegal,IdTipoIdentificacion,IdTipoIdentificacionRepresentante, " +
            "NumeroIdentificacionRepresentante,PathNumeroIdentificacion,PathConstitucionGrupo,PatologiaAsociacion,PathCertificacionPatologia,Email,Telefono, " +
            "Celular,NumeroAsociados,Direccion,Genero,Certifico,Autorizo,Contrasena,FechaRetiro,IdPreguntaSecreta,RespuestaPregunta,IdEstadoUsuario,IdMunicipio, " +
            "FechaRegistro,FechaActualizacion, IdDepartamento, " +
            "AutorizoEmail, ValorContrasena FROM Participante INNER JOIN Municipio ON Participante.IdMunicipio = Municipio.Id WHERE Email = '{0}' ", correo);

            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta);


            if (resultado.Rows.Count > 0)
            {
                return resultado.Rows[0];
            }
            else
            {
                return null;
            }
        }


        public void InsertarParticipanteBD(string numeroIdentificacion, Int16 idTipoUsuario, string nombres, string apellidos, string nombreRepresentanteLegal,
            Int16 idTipoIdentificacion, Int16 idTipoIdentificacionRepresentante, string numeroIdentificacionRepresentante, string pathNumeroIdentificacion,
            string pathConstitucionGrupo, string email, string telefono, string celular,
            int numeroAsociados, string direccion, char genero, bool certifico, bool autorizo, string contrasena, Int16 idPreguntaSecreta,
            string respuestaPregunta, Int16 idEstadoUsuario, Int16 idMunicipio, bool autorizoEmail, string valorContrasena, string digitoVerificacion, string digitoVerificacionRepresentante)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = "INSERT Participante(digitoVerificacion,digitoVerificacionRepresentante,NumeroIdentificacion,IdTipoUsuario,Nombres,Apellidos,NombreRepresentanteLegal,IdTipoIdentificacion,IdTipoIdentificacionRepresentante," +
            "NumeroIdentificacionRepresentante,PathNumeroIdentificacion,PathConstitucionGrupo,Email,Telefono, " +
            "Celular,NumeroAsociados,Direccion,Genero,Certifico,Autorizo,Contrasena,IdPreguntaSecreta,RespuestaPregunta,IdEstadoUsuario,IdMunicipio, " +
            "FechaRegistro,AutorizoEmail,ValorContrasena) " +
            " values (@digitoVerificacion,@digitoVerificacionRepresentante,@numeroIdentificacion,@idTipoUsuario,@nombres,@apellidos,@nombreRepresentanteLegal,@idTipoIdentificacion,@idTipoIdentificacionRepresentante," +
            "@numeroIdentificacionRepresentante,@pathNumeroIdentificacion,@pathConstitucionGrupo,@email,@telefono, " +
            "@celular,@numeroAsociados,@direccion,@genero,@certifico,@autorizo,@contrasena,@idPreguntaSecreta,@respuestaPregunta,@idEstadoUsuario,@idMunicipio, " +
            "@fechaRegistro,@autorizoEmail,@valorContrasena)";

            SqlCommand comandoInsercion = new SqlCommand(sqlConsulta);
            SqlParameter parametrodigitoVerificacion = new SqlParameter("digitoVerificacion", SqlDbType.VarChar);
            parametrodigitoVerificacion.Value = digitoVerificacion;
            comandoInsercion.Parameters.Add(parametrodigitoVerificacion);

            SqlParameter parametrodigitoVerificacionRepresentanten = new SqlParameter("digitoVerificacionRepresentante", SqlDbType.VarChar);
            parametrodigitoVerificacionRepresentanten.Value = digitoVerificacionRepresentante;
            comandoInsercion.Parameters.Add(parametrodigitoVerificacionRepresentanten);

            SqlParameter parametroNumeroIdentificacion = new SqlParameter("numeroIdentificacion", SqlDbType.VarChar);
            parametroNumeroIdentificacion.Value = numeroIdentificacion;
            comandoInsercion.Parameters.Add(parametroNumeroIdentificacion);

            SqlParameter parametroIdTipoUsuario = new SqlParameter("idTipoUsuario", SqlDbType.SmallInt);
            parametroIdTipoUsuario.Value = idTipoUsuario;
            comandoInsercion.Parameters.Add(parametroIdTipoUsuario);

            SqlParameter parametroNombres = new SqlParameter("nombres", SqlDbType.VarChar);
            parametroNombres.Value = nombres;
            comandoInsercion.Parameters.Add(parametroNombres);

            SqlParameter parametroApellidos = new SqlParameter("apellidos", SqlDbType.VarChar);
            parametroApellidos.Value = apellidos;
            comandoInsercion.Parameters.Add(parametroApellidos);

            SqlParameter parametroNombreRepresentanteLegal = new SqlParameter("nombreRepresentanteLegal", SqlDbType.VarChar);
            parametroNombreRepresentanteLegal.Value = nombreRepresentanteLegal;
            comandoInsercion.Parameters.Add(parametroNombreRepresentanteLegal);

            SqlParameter parametroIdtipoidentificacion = new SqlParameter("idtipoidentificacion", SqlDbType.SmallInt);
            parametroIdtipoidentificacion.Value = idTipoIdentificacion;
            comandoInsercion.Parameters.Add(parametroIdtipoidentificacion);

            SqlParameter parametroIdTipoIdentificacionRepresentante = new SqlParameter("idTipoIdentificacionRepresentante", SqlDbType.SmallInt);
            parametroIdTipoIdentificacionRepresentante.Value = idTipoIdentificacionRepresentante;
            comandoInsercion.Parameters.Add(parametroIdTipoIdentificacionRepresentante);

            SqlParameter parametroNumeroIdentificacionRepresentante = new SqlParameter("numeroIdentificacionRepresentante", SqlDbType.VarChar);
            parametroNumeroIdentificacionRepresentante.Value = numeroIdentificacionRepresentante;
            comandoInsercion.Parameters.Add(parametroNumeroIdentificacionRepresentante);

            SqlParameter parametroPathNumeroIdentificacion = new SqlParameter("pathNumeroIdentificacion", SqlDbType.VarChar);
            parametroPathNumeroIdentificacion.Value = pathNumeroIdentificacion;
            comandoInsercion.Parameters.Add(parametroPathNumeroIdentificacion);

            SqlParameter parametroPathConstitucionGrupo = new SqlParameter("pathConstitucionGrupo", SqlDbType.VarChar);
            parametroPathConstitucionGrupo.Value = pathConstitucionGrupo;
            comandoInsercion.Parameters.Add(parametroPathConstitucionGrupo);

            SqlParameter parametroEmail = new SqlParameter("email", SqlDbType.VarChar);
            parametroEmail.Value = email;
            comandoInsercion.Parameters.Add(parametroEmail);

            SqlParameter parametroTelefono = new SqlParameter("telefono", SqlDbType.VarChar);
            parametroTelefono.Value = telefono;
            comandoInsercion.Parameters.Add(parametroTelefono);

            SqlParameter parametroCelular = new SqlParameter("celular", SqlDbType.VarChar);
            parametroCelular.Value = celular;
            comandoInsercion.Parameters.Add(parametroCelular);

            SqlParameter parametroNumeroAsociados = new SqlParameter("numeroAsociados", SqlDbType.Int);
            parametroNumeroAsociados.Value = numeroAsociados;
            comandoInsercion.Parameters.Add(parametroNumeroAsociados);

            SqlParameter parametroDireccion = new SqlParameter("direccion", SqlDbType.VarChar);
            parametroDireccion.Value = direccion;
            comandoInsercion.Parameters.Add(parametroDireccion);

            SqlParameter parametroGenero = new SqlParameter("genero", SqlDbType.Char);
            parametroGenero.Value = genero;
            comandoInsercion.Parameters.Add(parametroGenero);

            SqlParameter parametroCertifico = new SqlParameter("certifico", SqlDbType.Bit);
            parametroCertifico.Value = certifico;
            comandoInsercion.Parameters.Add(parametroCertifico);

            SqlParameter parametroAutorizo = new SqlParameter("Autorizo", SqlDbType.Bit);
            parametroAutorizo.Value = autorizo;
            comandoInsercion.Parameters.Add(parametroAutorizo);

            SqlParameter parametroContrasena = new SqlParameter("contrasena", SqlDbType.VarChar);
            parametroContrasena.Value = contrasena;
            comandoInsercion.Parameters.Add(parametroContrasena);

            SqlParameter parametroIdPreguntaSecreta = new SqlParameter("idpreguntasecreta", SqlDbType.Int);
            parametroIdPreguntaSecreta.Value = idPreguntaSecreta;
            comandoInsercion.Parameters.Add(parametroIdPreguntaSecreta);

            SqlParameter parametroRespuestaPregunta = new SqlParameter("respuestapregunta", SqlDbType.VarChar);
            parametroRespuestaPregunta.Value = respuestaPregunta;
            comandoInsercion.Parameters.Add(parametroRespuestaPregunta);

            SqlParameter parametroIdEstadoUsuario = new SqlParameter("idestadousuario", SqlDbType.Int);
            parametroIdEstadoUsuario.Value = idEstadoUsuario;
            comandoInsercion.Parameters.Add(parametroIdEstadoUsuario);

            SqlParameter parametroIdMunicipio = new SqlParameter("idmunicipio", SqlDbType.Int);
            parametroIdMunicipio.Value = idMunicipio;
            comandoInsercion.Parameters.Add(parametroIdMunicipio);

            SqlParameter parametroFechaRegistro = new SqlParameter("FechaRegistro", SqlDbType.DateTime);
            parametroFechaRegistro.Value = DateTime.Now;
            comandoInsercion.Parameters.Add(parametroFechaRegistro);

            SqlParameter parametroAutorizoEmail = new SqlParameter("AutorizoEmail", SqlDbType.Bit);
            parametroAutorizoEmail.Value = autorizoEmail;
            comandoInsercion.Parameters.Add(parametroAutorizoEmail);

            SqlParameter parametroContrasenaValor = new SqlParameter("valorContrasena", SqlDbType.VarChar);
            parametroContrasenaValor.Value = valorContrasena;
            comandoInsercion.Parameters.Add(parametroContrasenaValor);

            helper.EjecutarQuerySinDevolver(comandoInsercion);
        }

        public void ActualizarEstadoValidacion(string numeroIdentificacion)
        {

            SQLServerHelper helper = new SQLServerHelper();

            string sql = null;

            sql = "UPDATE Participante set IdEstadoUsuario= 1 WHERE NumeroIdentificacion= @numeroIdentificador and IdEstadoUsuario=0";



            SqlCommand comandoUpdate = new SqlCommand(sql);



            SqlParameter parametroNumeroIdentificacion = new SqlParameter("@numeroIdentificador", SqlDbType.VarChar);
            parametroNumeroIdentificacion.Value = numeroIdentificacion;
            comandoUpdate.Parameters.Add(parametroNumeroIdentificacion);


            helper.EjecutarQuerySinDevolver(comandoUpdate);
        }


        public void ActualizarDatosClaveCorreo(string numeroIdentificacion, string email, string contrasena, string valorContrasena)
        {

            SQLServerHelper helper = new SQLServerHelper();

            string sql = null;
            if (contrasena == null)
            {
                sql = "UPDATE Participante set NumeroIdentificacion= @numeroIdentificador, email =@email WHERE NumeroIdentificacion= @numeroIdentificador ";
            }
            else
            {
                sql = "UPDATE Participante set NumeroIdentificacion= @numeroIdentificador, email =@email, contrasena =@contrasena, ValorContrasena = @valorContrasena WHERE NumeroIdentificacion= @numeroIdentificador ";
            }


            SqlCommand comandoUpdate = new SqlCommand(sql);



            SqlParameter parametroNumeroIdentificacion = new SqlParameter("@numeroIdentificador", SqlDbType.VarChar);
            parametroNumeroIdentificacion.Value = numeroIdentificacion;
            comandoUpdate.Parameters.Add(parametroNumeroIdentificacion);

            SqlParameter parametroEmail = new SqlParameter("@email", SqlDbType.VarChar);
            parametroEmail.Value = email;
            comandoUpdate.Parameters.Add(parametroEmail);

            if (contrasena != null)
            {
                SqlParameter parametroContrasena = new SqlParameter("@contrasena", SqlDbType.VarChar);
                parametroContrasena.Value = contrasena;
                comandoUpdate.Parameters.Add(parametroContrasena);

                SqlParameter parametroContrasenaValor = new SqlParameter("@valorContrasena", SqlDbType.VarChar);
                parametroContrasenaValor.Value = valorContrasena;
                comandoUpdate.Parameters.Add(parametroContrasenaValor);
            }

            helper.EjecutarQuerySinDevolver(comandoUpdate);
        }

        public void ActualizarDatos(string numeroIdentificacion, Int16 idTipoUsuario, string nombres, string apellidos, string nombreRepresentanteLegal,
            Int16 idTipoIdentificacion, Int16 idTipoIdentificacionRepresentante, string numeroIdentificacionRepresentante, string pathNumeroIdentificacion,
            string pathConstitucionGrupo, string email, string telefono, string celular,
            int numeroAsociados, string direccion, char genero, bool certifico, bool autorizo, string contrasena, Int16 idPreguntaSecreta,
            string respuestaPregunta, Int16 idMunicipio, bool autorizoEmail, string valorContrasena, string digitoVerificacion, string digitoVerificacionRepresentante)
        {

            SQLServerHelper helper = new SQLServerHelper();

            string sql = null;


            sql = @"UPDATE Participante SET digitoVerificacion = @digitoVerificacion,digitoVerificacionRepresentante = @digitoVerificacionRepresentante ,
                IdTipoUsuario = @idTipoUsuario, Nombres = @nombres, Apellidos = @apellidos, " +
            "NombreRepresentanteLegal = @nombreRepresentanteLegal, IdTipoIdentificacion = @idTipoIdentificacion, " +
            "IdTipoIdentificacionRepresentante = @idTipoIdentificacionRepresentante, NumeroIdentificacionRepresentante = @numeroIdentificacionRepresentante, " +
            "PathNumeroIdentificacion = @pathNumeroIdentificacion, PathConstitucionGrupo = @pathConstitucionGrupo, " +
            "Email = @email, Telefono = @telefono, Celular = @celular, NumeroAsociados = @numeroAsociados, " +
            "Direccion = @direccion, Genero = @genero, Certifico = @certifico, Autorizo = @autorizo, Contrasena = @contrasena, " +
            "IdPreguntaSecreta = @idPreguntaSecreta, RespuestaPregunta = @respuestaPregunta, IdMunicipio = @idMunicipio, " +
            "FechaActualizacion = @fechaActualizacion, AutorizoEmail = @autorizoEmail, ValorContrasena = @valorContrasena " +
            "WHERE NumeroIdentificacion = @numeroIdentificacion";

            if (contrasena == null)
            {
                sql = sql.Replace("@contrasena", "contrasena");
                sql = sql.Replace("@valorContrasena", "valorContrasena");
            }


            SqlCommand comandoUpdate = new SqlCommand(sql);
            SqlParameter parametrodigitoVerificacion = new SqlParameter("digitoVerificacion", SqlDbType.VarChar);
            parametrodigitoVerificacion.Value = digitoVerificacion;
            comandoUpdate.Parameters.Add(parametrodigitoVerificacion);

            SqlParameter parametrodigitoVerificacionRepresentanten = new SqlParameter("digitoVerificacionRepresentante", SqlDbType.VarChar);
            parametrodigitoVerificacionRepresentanten.Value = digitoVerificacionRepresentante;
            comandoUpdate.Parameters.Add(parametrodigitoVerificacionRepresentanten);

            SqlParameter parametroNumeroIdentificacion = new SqlParameter("numeroIdentificacion", SqlDbType.VarChar);
            parametroNumeroIdentificacion.Value = numeroIdentificacion;
            comandoUpdate.Parameters.Add(parametroNumeroIdentificacion);

            SqlParameter parametroIdTipoUsuario = new SqlParameter("idTipoUsuario", SqlDbType.SmallInt);
            parametroIdTipoUsuario.Value = idTipoUsuario;
            comandoUpdate.Parameters.Add(parametroIdTipoUsuario);

            SqlParameter parametroNombres = new SqlParameter("nombres", SqlDbType.VarChar);
            parametroNombres.Value = nombres;
            comandoUpdate.Parameters.Add(parametroNombres);

            SqlParameter parametroApellidos = new SqlParameter("apellidos", SqlDbType.VarChar);
            parametroApellidos.Value = apellidos;
            comandoUpdate.Parameters.Add(parametroApellidos);

            SqlParameter parametroNombreRepresentanteLegal = new SqlParameter("nombreRepresentanteLegal", SqlDbType.VarChar);
            parametroNombreRepresentanteLegal.Value = nombreRepresentanteLegal;
            comandoUpdate.Parameters.Add(parametroNombreRepresentanteLegal);

            SqlParameter parametroIdtipoidentificacion = new SqlParameter("idtipoidentificacion", SqlDbType.SmallInt);
            parametroIdtipoidentificacion.Value = idTipoIdentificacion;
            comandoUpdate.Parameters.Add(parametroIdtipoidentificacion);

            SqlParameter parametroIdTipoIdentificacionRepresentante = new SqlParameter("idTipoIdentificacionRepresentante", SqlDbType.SmallInt);
            parametroIdTipoIdentificacionRepresentante.Value = idTipoIdentificacionRepresentante;
            comandoUpdate.Parameters.Add(parametroIdTipoIdentificacionRepresentante);

            SqlParameter parametroNumeroIdentificacionRepresentante = new SqlParameter("numeroIdentificacionRepresentante", SqlDbType.VarChar);
            parametroNumeroIdentificacionRepresentante.Value = numeroIdentificacionRepresentante;
            comandoUpdate.Parameters.Add(parametroNumeroIdentificacionRepresentante);

            SqlParameter parametroPathNumeroIdentificacion = new SqlParameter("pathNumeroIdentificacion", SqlDbType.VarChar);
            parametroPathNumeroIdentificacion.Value = pathNumeroIdentificacion;
            comandoUpdate.Parameters.Add(parametroPathNumeroIdentificacion);

            SqlParameter parametroPathConstitucionGrupo = new SqlParameter("pathConstitucionGrupo", SqlDbType.VarChar);
            parametroPathConstitucionGrupo.Value = pathConstitucionGrupo;
            comandoUpdate.Parameters.Add(parametroPathConstitucionGrupo);

            SqlParameter parametroEmail = new SqlParameter("email", SqlDbType.VarChar);
            parametroEmail.Value = email;
            comandoUpdate.Parameters.Add(parametroEmail);

            SqlParameter parametroTelefono = new SqlParameter("telefono", SqlDbType.VarChar);
            parametroTelefono.Value = telefono;
            comandoUpdate.Parameters.Add(parametroTelefono);

            SqlParameter parametroCelular = new SqlParameter("celular", SqlDbType.VarChar);
            parametroCelular.Value = celular;
            comandoUpdate.Parameters.Add(parametroCelular);

            SqlParameter parametroNumeroAsociados = new SqlParameter("numeroAsociados", SqlDbType.Int);
            parametroNumeroAsociados.Value = numeroAsociados;
            comandoUpdate.Parameters.Add(parametroNumeroAsociados);

            SqlParameter parametroDireccion = new SqlParameter("direccion", SqlDbType.VarChar);
            parametroDireccion.Value = direccion;
            comandoUpdate.Parameters.Add(parametroDireccion);

            SqlParameter parametroGenero = new SqlParameter("genero", SqlDbType.Char);
            parametroGenero.Value = genero;
            comandoUpdate.Parameters.Add(parametroGenero);

            SqlParameter parametroCertifico = new SqlParameter("certifico", SqlDbType.Bit);
            parametroCertifico.Value = certifico;
            comandoUpdate.Parameters.Add(parametroCertifico);

            SqlParameter parametroAutorizo = new SqlParameter("Autorizo", SqlDbType.Bit);
            parametroAutorizo.Value = autorizo;
            comandoUpdate.Parameters.Add(parametroAutorizo);

            if (contrasena != null)
            {
                SqlParameter parametroContrasena = new SqlParameter("contrasena", SqlDbType.VarChar);
                parametroContrasena.Value = contrasena;
                comandoUpdate.Parameters.Add(parametroContrasena);

                SqlParameter parametroContrasenaValor = new SqlParameter("valorContrasena", SqlDbType.VarChar);
                parametroContrasenaValor.Value = valorContrasena;
                comandoUpdate.Parameters.Add(parametroContrasenaValor);
            }

            SqlParameter parametroIdPreguntaSecreta = new SqlParameter("idpreguntasecreta", SqlDbType.Int);
            parametroIdPreguntaSecreta.Value = idPreguntaSecreta;
            comandoUpdate.Parameters.Add(parametroIdPreguntaSecreta);

            SqlParameter parametroRespuestaPregunta = new SqlParameter("respuestapregunta", SqlDbType.VarChar);
            parametroRespuestaPregunta.Value = respuestaPregunta;
            comandoUpdate.Parameters.Add(parametroRespuestaPregunta);

            SqlParameter parametroIdMunicipio = new SqlParameter("idmunicipio", SqlDbType.Int);
            parametroIdMunicipio.Value = idMunicipio;
            comandoUpdate.Parameters.Add(parametroIdMunicipio);

            SqlParameter parametroFechaActualizacion = new SqlParameter("fechaActualizacion", SqlDbType.DateTime);
            parametroFechaActualizacion.Value = DateTime.Now;
            comandoUpdate.Parameters.Add(parametroFechaActualizacion);

            SqlParameter parametroAutorizoEmail = new SqlParameter("AutorizoEmail", SqlDbType.Bit);
            parametroAutorizoEmail.Value = autorizoEmail;
            comandoUpdate.Parameters.Add(parametroAutorizoEmail);

            helper.EjecutarQuerySinDevolver(comandoUpdate);

        }

        public DataTable CargarListaBD(TipoLista tipoLista, string parametro = null)
        {
            string sql = "";

            switch (tipoLista)
            {
                case TipoLista.ComoEntero:
                    sql = "SELECT Id, Nombre FROM ComoEntero ORDER BY Nombre";
                    break;
                case TipoLista.Departamento:
                    sql = "SELECT id, nombre FROM Departamento ORDER BY nombre";
                    break;
                case TipoLista.EstadoCivil:
                    sql = "SELECT Id, Nombre FROM EstadoCivil ORDER BY Nombre";
                    break;
                case TipoLista.Municipio:
                    sql = "SELECT id, nombre FROM Municipio WHERE IdDepartamento = " + parametro + " ORDER BY nombre";
                    break;
                case TipoLista.Pregunta:
                    sql = "SELECT Id, TextoPregunta FROM PreguntaSecreta ORDER BY TextoPregunta";
                    break;
                case TipoLista.TipoDocumento:
                    sql = "SELECT Id, Nombre FROM TipoIdentificacion ORDER BY Nombre";
                    break;

                case TipoLista.TipoDocumentoJuridico:
                    sql = "SELECT Id, Nombre FROM TipoIdentificacion where espersona=0 ORDER BY Nombre";
                    break;
                case TipoLista.TipoDocumentoNatural:
                    sql = "SELECT Id, Nombre FROM TipoIdentificacion  where espersona=1 ORDER BY Nombre";
                    break;
                case TipoLista.TipoUsuario:
                    sql = "SELECT Id, Nombre FROM TipoUsuario ORDER BY Nombre";
                    break;
                case TipoLista.tipoUsuarioNuevoNatural:
                    sql = "SELECT Id, Nombre FROM TipoUsuario WHERE ES_NUEVO =  1 and es_natural=1 ORDER BY Nombre";
                    break;
                case TipoLista.tipoUsuarioNuevoJuridico:
                    sql = "SELECT Id, Nombre FROM TipoUsuario WHERE ES_NUEVO =  1 and es_natural=0 ORDER BY Nombre";
                    break;
                case TipoLista.tipoUsuarioViejo:
                    sql = "SELECT Id, Nombre FROM TipoUsuario WHERE ES_NUEVO = 0 ORDER BY Nombre";
                    break;
            }

            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = string.Format(sql);
            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta);
            if (resultado.Rows.Count > 0)
            {
                return resultado;
            }
            else
            {
                return null;
            }
        }

        public DataRow BuscarTipoUsuarioCodigo(string tipoUsuario)
        {
            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = string.Format("SELECT Id, Nombre FROM TipoUsuario WHERE Id = {0} ", tipoUsuario);

            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta);

            if (resultado.Rows.Count > 0)
            {
                return resultado.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public int ObtenerMayorRango()
        {
            string sql = "SELECT ISNULL(MAX(NUMERO),1) FROM VW_RESUMEN_TIPO";


            SQLServerHelper helper = new SQLServerHelper();

            string sqlConsulta = string.Format(sql);
            DataTable resultado = helper.EjecutarQueryDevolver(sqlConsulta);
            if (resultado.Rows.Count > 0)
            {
                return Convert.ToInt32(resultado.Rows[0][0]);
            }
            else
            {
                return 1;
            }
        }
    }

    public enum TipoLista
    {
        ComoEntero = 0,
        Departamento = 1,
        EstadoCivil = 2,
        Municipio = 3,
        Pregunta = 4,
        TipoDocumento = 5,
        TipoDocumentoJuridico = 6,
        TipoDocumentoNatural = 7,
        TipoUsuario,
        tipoUsuarioNuevoNatural,
        tipoUsuarioNuevoJuridico,
        tipoUsuarioViejo
    }
}
