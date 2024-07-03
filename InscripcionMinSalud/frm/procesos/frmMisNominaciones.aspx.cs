using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmMisNominaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                Response.Redirect("~/default.aspx");
                return;
            }
        }

        /// <summary>
        /// Determina y devuelve el tipo de acuerdo con las categorías proporcionadas.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si es un dispositivo.</param>
        /// <param name="esOtro">Indica si pertenece a otra categoría.</param>
        /// <returns>
        /// Cadena que representa el tipo correspondiente: "Medicamentos", "Procedimientos", "Dispositivos", "Otro"; 
        /// o una cadena vacía si ninguna categoría es verdadera o todos los objetos son nulos o DBNull.
        /// </returns>
        public string VerTipo(object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro)
        {
            // Determina y devuelve el tipo correspondiente según las categorías proporcionadas.
            if (esMedicamento != null && esMedicamento != System.DBNull.Value && (bool)esMedicamento)
            {
                return "Medicamentos";
            }
            if (esProcedimiento != null && esProcedimiento != System.DBNull.Value && (bool)esProcedimiento)
            {
                return "Procedimientos";
            }
            if (esDispositivo != null && esDispositivo != System.DBNull.Value && (bool)esDispositivo)
            {
                return "Dispositivos";
            }
            if (esOtro != null && esOtro != System.DBNull.Value && (bool)esOtro)
            {
                return "Otro";
            }

            // Si ninguna categoría es verdadera o todos los objetos son nulos o DBNull, devuelve una cadena vacía.
            return "";
        }

        /// <summary>
        /// Evalúa un objeto de conflicto y devuelve una cadena que indica la presencia o ausencia de conflicto.
        /// </summary>
        /// <param name="conflicto">El objeto que se evalúa para determinar la presencia o ausencia de conflicto.</param>
        /// <returns>
        /// Cadena que indica si hay conflicto ("SI"), no hay conflicto ("NO"), o si el objeto es nulo ("No definido").
        /// </returns>
        public string VerConflicto(object conflicto)
        {
            // Si el objeto de conflicto es nulo, devuelve "No definido".
            if (conflicto == null)
            {
                return "No definido";
            }

            // Si el objeto de conflicto no es nulo, no es DBNull y es evaluado como verdadero, devuelve "SI".
            if (!(conflicto is System.DBNull) && (bool)conflicto)
            {
                return "SI";
            }

            // En cualquier otro caso, devuelve "NO".
            return "NO";
        }


        /// <summary>
        /// Evalúa un objeto de evidencia y devuelve una cadena que indica la presencia o ausencia de evidencia.
        /// </summary>
        /// <param name="evidencia">El objeto que se evalúa para determinar la presencia o ausencia de evidencia.</param>
        /// <returns>
        /// Cadena que indica si hay evidencia ("SI"), no hay evidencia ("NO"), o si el objeto es nulo ("No definido").
        /// </returns>
        public string VerEvidencia(object evidencia)
        {
            // Si el objeto de evidencia es nulo, devuelve "No definido".
            if (evidencia == null)
            {
                return "No definido";
            }

            // Si el objeto de evidencia no es nulo, no es DBNull y es evaluado como verdadero, devuelve "SI".
            if (!(evidencia is System.DBNull) && (bool)evidencia)
            {
                return "SI";
            }

            // En cualquier otro caso, devuelve "NO".
            return "NO";
        }


        /// <summary>
        /// Concatena las letras correspondientes a los criterios de exclusión que están activos.
        /// </summary>
        /// <param name="a">Indica si el criterio A está activo.</param>
        /// <param name="b">Indica si el criterio B está activo.</param>
        /// <param name="c">Indica si el criterio C está activo.</param>
        /// <param name="d">Indica si el criterio D está activo.</param>
        /// <param name="e">Indica si el criterio E está activo.</param>
        /// <param name="f">Indica si el criterio F está activo.</param>
        /// <returns>
        /// Cadena que contiene las letras correspondientes a los criterios de exclusión activos, separadas por comas;
        /// o una cadena vacía si ninguno de los criterios está activo.
        /// </returns>
        public string CriteriosExclusion(object a, object b, object c, object d, object e, object f)
        {
            string resultado = "";

            // Concatena las letras correspondientes a los criterios de exclusión que están activos.
            if (a != null && (bool)a)
            {
                resultado += "A,";
            }
            if (b != null && (bool)b)
            {
                resultado += "B,";
            }
            if (c != null && (bool)c)
            {
                resultado += "C,";
            }
            if (d != null && (bool)d)
            {
                resultado += "D,";
            }
            if (e != null && (bool)e)
            {
                resultado += "E,";
            }
            if (f != null && (bool)f)
            {
                resultado += "F,";
            }

            // Elimina la última coma si la cadena no está vacía.
            if (!string.IsNullOrEmpty(resultado))
            {
                resultado = resultado.Substring(0, resultado.Length - 1);
            }

            return resultado;
        }

        /// <summary>
        /// Determina y devuelve el tipo de acuerdo con las categorías proporcionadas.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si es un dispositivo.</param>
        /// <param name="esOtro">Indica si pertenece a otra categoría.</param>
        /// <returns>
        /// Cadena que representa el tipo correspondiente: "Medicamentos", "Procedimientos", "Dispositivos", "Otro"; 
        /// o una cadena vacía si ninguna categoría es verdadera o todos los objetos son nulos.
        /// </returns>
        public string verTipo(object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro)
        {
            // Determina y devuelve el tipo correspondiente según las categorías proporcionadas.
            if (esMedicamento != null && (bool)esMedicamento)
            {
                return "Medicamentos";
            }
            if (esProcedimiento != null && (bool)esProcedimiento)
            {
                return "Procedimientos";
            }
            if (esDispositivo != null && (bool)esDispositivo)
            {
                return "Dispositivos";
            }
            if (esOtro != null && (bool)esOtro)
            {
                return "Otro";
            }

            // Si ninguna categoría es verdadera o todos los objetos son nulos, devuelve una cadena vacía.
            return "";
        }

    }
}