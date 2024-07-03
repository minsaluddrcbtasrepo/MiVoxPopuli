using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioInscripcionMinSalud.data;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmNominaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            //{
            //    Response.Redirect("~/default.aspx");
            //    return;
            //}

            if (Request.QueryString["codProceso"] == null || Request.QueryString["codProceso"].ToString() == string.Empty)
            {
                Response.Redirect("~/default.aspx");
                return;
            }

            if (!IsPostBack)
            {
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
                var c=obj.obtenerProceso(int.Parse(Request.QueryString["codProceso"]));
                if (c != null)
                {
                    VIGENCIA vigencia = c.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));
                    lblNombreProceso.Text = c.NOMBRE_PROCESO + " - " + vigencia.DESCRIPCION;
                }
                
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
        /// o una cadena vacía si ninguna categoría es verdadera o todos los objetos son nulos.
        /// </returns>
        public string VerTipo(object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro)
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

            // Si el objeto de conflicto no es nulo y es evaluado como verdadero, devuelve "SI".
            if ((bool)conflicto)
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
        public string verEvidencia(object evidencia)
        {
            // Si el objeto de evidencia es nulo, devuelve "No definido".
            if (evidencia == null)
            {
                return "No definido";
            }

            // Si el objeto de evidencia no es nulo y es evaluado como verdadero, devuelve "SI".
            if ((bool)evidencia)
            {
                return "SI";
            }

            // En cualquier otro caso, devuelve "NO".
            return "NO";
        }


        /// <summary>
        /// Genera una cadena de texto que representa los criterios de exclusión seleccionados.
        /// </summary>
        /// <param name="a">Indica si el criterio A está seleccionado (true) o no (false).</param>
        /// <param name="b">Indica si el criterio B está seleccionado (true) o no (false).</param>
        /// <param name="c">Indica si el criterio C está seleccionado (true) o no (false).</param>
        /// <param name="d">Indica si el criterio D está seleccionado (true) o no (false).</param>
        /// <param name="e">Indica si el criterio E está seleccionado (true) o no (false).</param>
        /// <param name="f">Indica si el criterio F está seleccionado (true) o no (false).</param>
        /// <returns>Una cadena de texto que representa los criterios de exclusión seleccionados.</returns>
        public string criteriosExclusion(object a, object b, object c, object d, object e, object f)
        {
            string res = "";

            // Verifica cada criterio y agrega su letra correspondiente si está seleccionado.
            if (a != null && (bool)a)
            {
                res += "A,";
            }
            if (b != null && (bool)b)
            {
                res += "B,";
            }
            if (c != null && (bool)c)
            {
                res += "C,";
            }
            if (d != null && (bool)d)
            {
                res += "D,";
            }
            if (e != null && (bool)e)
            {
                res += "E,";
            }
            if (f != null && (bool)f)
            {
                res += "F,";
            }

            // Elimina la última coma si la cadena no está vacía.
            if (res != string.Empty)
            {
                res = res.Substring(0, res.Length - 1);
            }

            return res;
        }


        /// <summary>
        /// Obtiene una representación de texto del tipo de objeto.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento (true) o no (false).</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento (true) o no (false).</param>
        /// <param name="esDispositivo">Indica si es un dispositivo (true) o no (false).</param>
        /// <param name="esOtro">Indica si es otro tipo (true) o no (false).</param>
        /// <returns>Una cadena de texto representando el tipo de objeto.</returns>
        public string verDescripcionTipo(object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro,
                                          object medicamento, object procedimiento, object dispositivo, object otro)
        {
            if (esMedicamento != null && (bool)esMedicamento)
            {
                return medicamento.ToString();
            }
            if (esProcedimiento != null && (bool)esProcedimiento)
            {
                return procedimiento.ToString();
            }
            if (esDispositivo != null && (bool)esDispositivo)
            {
                return dispositivo.ToString();
            }
            if (esOtro != null && (bool)esOtro)
            {
                return otro.ToString();
            }
            return "";
        }

        /// <summary>
        /// Maneja el evento ItemDataBound del control de datos "datos".
        /// Realiza la vinculación de datos para cada elemento del control de datos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el control de datos "datos").</param>
        /// <param name="e">Argumentos del evento que contienen información sobre el elemento de datos y el elemento de interfaz de usuario asociado.</param>
        protected void datos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Encuentra el control Label "lblCodNominacion" dentro del elemento de datos actual.
            Label lbl = (Label)e.Item.FindControl("lblCodNominacion");

            // Encuentra el control Repeater "grdObjeciones" dentro del elemento de datos actual.
            Repeater grd = (Repeater)e.Item.FindControl("grdObjeciones");

            // Crea una instancia de la clase de negocios "clsNegocio".
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Configura el origen de datos del control Repeater con las objeciones obtenidas por el código de nominación.
            grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));

            // Vincula los datos al control Repeater.
            grd.DataBind();
        }



    }
}