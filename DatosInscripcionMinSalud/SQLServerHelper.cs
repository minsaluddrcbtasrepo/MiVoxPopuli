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

        public bool EjecutarQuerySinDevolver(string sqlConsulta)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter(sqlConsulta, conexionSQL);
            DataTable respuesta = new DataTable();
            return false;
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
