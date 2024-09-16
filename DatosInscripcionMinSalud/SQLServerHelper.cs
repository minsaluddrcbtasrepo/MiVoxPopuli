using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosInscripcionMinSalud
{
    public class SQLServerHelper
    {
        private SqlConnection conexionSQL = null;

        public SQLServerHelper()
        {
            ConnectionStringSettings configuracion = ConfigurationManager.ConnectionStrings["TRANSPLANTESConnectionString"];

            if (configuracion == null)
            {
                this.conexionSQL = new SqlConnection("data source=MAMBAPRUEBAS\\PRUEBAS;initial catalog=TRANSPLANTES;persist security info=True;user id=fabrica_ins;password=fabrica_ins2013;");
            }
            else
            {
                this.conexionSQL = new SqlConnection(configuracion.ConnectionString);
            }
        }

        public void AbrirConexion()
        {
            if (this.conexionSQL.State == ConnectionState.Closed)
            {
                this.conexionSQL.Open();
            }
        }

        public void CerrarConexion()
        {
            if (this.conexionSQL.State == ConnectionState.Open)
            {
                this.conexionSQL.Close();
            }
        }

        public int EjecutarSentenciaDB(string sqlConsulta, List<SqlParameter> parametros = null, bool devuelveId = false)
        {
            try
            {

                using (SqlCommand comando = new SqlCommand(sqlConsulta, conexionSQL))
                {
                    // Si se proporcionan parámetros, añádelos al comando
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros.ToArray());
                    }

                    // Abrir la conexión si no está abierta
                    if (conexionSQL.State != ConnectionState.Open)
                    {
                        conexionSQL.Open();
                    }
                    if (devuelveId)
                    {
                        // Para operaciones de inserción, agregar la instrucción para obtener el último ID generado
                        comando.CommandText += "; SELECT SCOPE_IDENTITY();";

                        // Ejecutar la consulta y obtener el ID
                        var id = comando.ExecuteScalar();

                        // Convertir el resultado a entero
                        return Convert.ToInt32(id);
                    }
                    else
                    {
                        // Para operaciones que no devuelven un ID (como DELETE), solo ejecutar la consulta
                        comando.ExecuteNonQuery();
                        return 0; // O algún valor que indique éxito sin ID
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente, registrar el error, etc.
                Console.Error.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                return -1; // Retorna -1 o un valor que indique error
            }
            finally
            {
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();
                }
            }
        }



        public DataTable EjecutarQueryDevolver(string sqlConsulta, List<SqlParameter> parametros = null)
        {
            using (SqlCommand comando = new SqlCommand(sqlConsulta, conexionSQL))
            {
                // Agregar los parámetros al comando si se proporcionan
                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros.ToArray());
                }

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable respuesta = new DataTable();

                try
                {
                    // Abrir la conexión si no está abierta
                    if (conexionSQL.State != ConnectionState.Open)
                    {
                        conexionSQL.Open();
                    }

                    // Llenar el DataTable con los resultados de la consulta
                    adaptador.Fill(respuesta);
                }
                catch (Exception ex)
                {
                    // Manejar excepciones (logging, rethrow, etc.)
                    throw new Exception("Error al ejecutar la consulta.", ex);
                }
                finally
                {
                    // Cerrar la conexión si está abierta
                    if (conexionSQL.State == ConnectionState.Open)
                    {
                        conexionSQL.Close();
                    }
                }

                return respuesta;
            }
        }

        public void EjecutarQuerySinDevolver(SqlCommand sqlConsulta)
        {
            conexionSQL.Open();
            sqlConsulta.Connection = conexionSQL;
            sqlConsulta.ExecuteNonQuery();
        }
    }
}
