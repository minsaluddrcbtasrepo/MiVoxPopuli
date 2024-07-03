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

        public DataTable EjecutarQueryDevolver(string sqlConsulta)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter(sqlConsulta, conexionSQL);
            DataTable respuesta = new DataTable();

            adaptador.Fill(respuesta);

            return respuesta;
        }

        public void EjecutarQuerySinDevolver(SqlCommand sqlConsulta)
        {
            conexionSQL.Open();
            sqlConsulta.Connection = conexionSQL;            
            sqlConsulta.ExecuteNonQuery();            
        }
    }
}
