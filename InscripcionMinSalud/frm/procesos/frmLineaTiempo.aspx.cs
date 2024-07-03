using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmLineaTiempo : System.Web.UI.Page
    {
        public string clsParticipe = "tab-link";
        public string clsResultados = "tab-link";

        public string clsTabParticipe = "tab-content";
        public string clsTabResultados = "tab-content";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["r"] != null)
                {
                    clsParticipe = "tab-link";
                    clsResultados = "tab-link active current";

                    clsTabParticipe = "tab-content";
                    clsTabResultados = "tab-content current";
                }
                else
                {
                    clsParticipe = "tab-link active current";
                    clsResultados = "tab-link";
                    clsTabParticipe = "tab-content current";
                    clsTabResultados = "tab-content";
                }

                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
                var c = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));
                lblNombreProceso.Text = c.NOMBRE_PROCESO;
                if (Request.QueryString["v"] != null && Request.QueryString["v"] == "1")
                {
                    lblNombreProceso.Text = "Primer momento:" + lblNombreProceso.Text;
                }
                else if (Request.QueryString["v"] == "2")
                {
                    lblNombreProceso.Text = "Segundo momento:" + lblNombreProceso.Text;
                }
                else if (Request.QueryString["v"] == "3")
                {
                    lblNombreProceso.Text = "Tercer momento:" + lblNombreProceso.Text;
                }
                else if (Request.QueryString["v"] == "4")
                {
                    lblNombreProceso.Text = "Cuarto momento:" + lblNombreProceso.Text;
                }
              

            }
        }

        protected void Page_PreRender()
        {

            //if (Session["SS_COD_REGISTRO"] != null)
            //{
            //    pnlRegistrese.Visible = false;
            //    pnlNoRegistrese.Visible = true;


            //}
            //else
            //{
            //    pnlRegistrese.Visible = true;
            //    pnlNoRegistrese.Visible = false;
            //}
        }


        /// <summary>
        /// Obtiene una representación de texto del tipo de objeto.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento (true) o no (false).</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento (true) o no (false).</param>
        /// <param name="esDispositivo">Indica si es un dispositivo (true) o no (false).</param>
        /// <param name="esOtro">Indica si es otro tipo (true) o no (false).</param>
        /// <returns>Una cadena de texto representando el tipo de objeto.</returns>
        public string verTipo(object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro)
        {
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

            return "";
        }

        /// <summary>
        /// Obtiene una representación de texto indicando si hay conflicto de interés o no.
        /// </summary>
        /// <param name="conflicto">Indica si hay conflicto de interés (true) o no (false).</param>
        /// <returns>Una cadena de texto indicando la presencia o ausencia de conflicto de interés.</returns>
        public string verconflicto(object conflicto)
        {
            if (conflicto == null)
            {
                return "No definido";
            }

            if ((bool)conflicto)
            {
                return "SI";
            }

            return "NO";
        }


        /// <summary>
        /// Obtiene una representación de texto indicando si hay evidencia o no.
        /// </summary>
        /// <param name="evidencia">Indica si hay evidencia (true) o no (false).</param>
        /// <returns>Una cadena de texto indicando la presencia o ausencia de evidencia.</returns>
        public string verEvidencia(object evidencia)
        {
            if (evidencia == null)
            {
                return "No definido";
            }

            if ((bool)evidencia)
            {
                return "SI";
            }

            return "NO";
        }


        /// <summary>
        /// Concatena y devuelve los criterios de exclusión seleccionados.
        /// </summary>
        /// <param name="a">Indica si se seleccionó el criterio A.</param>
        /// <param name="b">Indica si se seleccionó el criterio B.</param>
        /// <param name="c">Indica si se seleccionó el criterio C.</param>
        /// <param name="d">Indica si se seleccionó el criterio D.</param>
        /// <param name="e">Indica si se seleccionó el criterio E.</param>
        /// <param name="f">Indica si se seleccionó el criterio F.</param>
        /// <returns>Una cadena que contiene los criterios de exclusión seleccionados, separados por comas.</returns>
        public string criteriosEclusion(object a, object b, object c, object d, object e, object f)
        {
            string res = "";
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
            if (res != string.Empty)
            {
                res = res.Substring(0, res.Length - 1);
            }
            return res;
        }

        /// <summary>
        /// Obtiene y devuelve la descripción del tipo según los parámetros proporcionados.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si es un dispositivo.</param>
        /// <param name="esOtro">Indica si es de otro tipo.</param>
        /// <param name="medicamento">Descripción del medicamento.</param>
        /// <param name="procedimiento">Descripción del procedimiento.</param>
        /// <param name="dispositivo">Descripción del dispositivo.</param>
        /// <param name="otro">Descripción de otro tipo.</param>
        /// <returns>La descripción del tipo correspondiente o una cadena vacía si no se encuentra.</returns>
        public string verDescripcionTipo(
            object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro,
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
        /// Maneja el evento ItemDataBound del control DataList (datos).
        /// Se utiliza para cargar datos adicionales y ajustar la visibilidad de paneles en cada elemento del DataList.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el control DataList).</param>
        /// <param name="e">Argumentos del evento que contienen la información sobre el elemento del DataList.</param>
        protected void datos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Verifica si el elemento es de tipo Item (no es un encabezado, pie de página, etc.).
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Encuentra el control Label (lblCodNominacion) y Repeater (grdObjeciones) en el elemento del DataList.
                Label lbl = (Label)e.Item.FindControl("lblCodNominacion");
                Repeater grd = (Repeater)e.Item.FindControl("grdObjeciones");

                // Instancia de la clase de negocios para obtener los datos de objeciones.
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Asigna la fuente de datos al Repeater con los resultados de objeciones.
                grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
                grd.DataBind();
            }
        }


        /// <summary>
        /// Maneja el evento ItemDataBound del control Repeater (rptResultados).
        /// Se utiliza para cargar datos adicionales y ajustar la visibilidad de paneles en cada elemento del Repeater.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el control Repeater).</param>
        /// <param name="e">Argumentos del evento que contienen la información sobre el elemento del Repeater.</param>
        protected void rptResultados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                // Encuentra el control Label (lblCodNominacion2) y GridView (grdObjeciones2) en el elemento del Repeater.
                Label lbl = (Label)e.Item.FindControl("lblCodNominacion2");
                GridView grd = (GridView)e.Item.FindControl("grdObjeciones2");

                // Instancia de la clase de negocios para obtener los datos de objeciones.
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Asigna la fuente de datos al GridView con los resultados de objeciones.
                grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
                grd.DataBind();

                // Ajusta la visibilidad del Panel (pnlObjeciones) en función de si hay o no objeciones.
                Panel pnl = (Panel)e.Item.FindControl("pnlObjeciones");
                pnl.Visible = grd.Rows.Count > 0;
            }
        }

    }
}