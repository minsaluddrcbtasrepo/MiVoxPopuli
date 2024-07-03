using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioInscripcionMinSalud.data;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeProcesoRups : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["cod"] == null)
                {
                    Response.Redirect("../logica/frmDefault.aspx");
                }

                if (Request.QueryString["r"] != null && Request.QueryString["r"].Trim() != string.Empty)
                {
                    Response.Redirect("frmHomeProcesoNominacionCups.aspx?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "");
                }

                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
                var c = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));
                if (c != null)
                {
                    VIGENCIA vigencia = c.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));
                    lblNombreProceso.Text = c.NOMBRE_PROCESO + " - " + vigencia.DESCRIPCION;
                }
                lnkNominacion.NavigateUrl = lnkNominacion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";

            }
        }

        /// <summary>
        /// Devuelve una cadena que representa el tipo de tecnología.
        /// </summary>
        /// <param name="esMedicamento">Valor booleano que indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Valor booleano que indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Valor booleano que indica si es un dispositivo.</param>
        /// <param name="esOtro">Valor booleano que indica si es otro tipo.</param>
        /// <returns>
        /// Cadena que representa el tipo de tecnología:
        /// - "Medicamentos" si es un medicamento.
        /// - "Procedimientos" si es un procedimiento.
        /// - "Dispositivos" si es un dispositivo.
        /// - "Otro" si es otro tipo.
        /// - Cadena vacía si no se cumple ninguna condición.
        /// </returns>
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
        /// Devuelve una cadena que indica si hay conflicto o no.
        /// </summary>
        /// <param name="conflicto">El valor booleano que indica la presencia de conflicto.</param>
        /// <returns>La cadena "SI" si hay conflicto, "NO" si no hay conflicto y "No definido" si el valor es nulo.</returns>
        public string verconflicto(object conflicto)
        {
            if (conflicto == null)
            {
                return "No definido";
            }
            if (conflicto != null && (bool)conflicto)
            {
                return "SI";
            }
            return "NO";
        }


        /// <summary>
        /// Obtiene una cadena que representa la existencia de evidencia.
        /// </summary>
        /// <param name="evidencia">Indica si hay evidencia.</param>
        /// <returns>Una cadena que representa la existencia de evidencia.</returns>
        public string verEvidencia(object evidencia)
        {
            if (evidencia == null)
            {
                return "No definido";
            }
            if (evidencia != null && (bool)evidencia)
            {
                return "SI";
            }
            return "NO";
        }

        /// <summary>
        /// Genera una cadena que representa los criterios de exclusión seleccionados.
        /// </summary>
        /// <param name="a">Indica si se seleccionó el criterio A.</param>
        /// <param name="b">Indica si se seleccionó el criterio B.</param>
        /// <param name="c">Indica si se seleccionó el criterio C.</param>
        /// <param name="d">Indica si se seleccionó el criterio D.</param>
        /// <param name="e">Indica si se seleccionó el criterio E.</param>
        /// <param name="f">Indica si se seleccionó el criterio F.</param>
        /// <returns>Una cadena que representa los criterios de exclusión seleccionados, separados por comas.</returns>
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
        /// Devuelve la descripción del tipo basándose en los parámetros proporcionados.
        /// </summary>
        /// <param name="esMedicamento">Indica si el tipo es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si el tipo es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si el tipo es un dispositivo.</param>
        /// <param name="esOtro">Indica si el tipo es otro.</param>
        /// <param name="medicamento">Descripción del medicamento.</param>
        /// <param name="procedimiento">Descripción del procedimiento.</param>
        /// <param name="dispositivo">Descripción del dispositivo.</param>
        /// <param name="otro">Descripción de otro tipo.</param>
        /// <returns>La descripción del tipo o una cadena vacía si no se cumple ninguna condición.</returns>
        public string VerDescripcionTipo(object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro,
            object medicamento, object procedimiento, object dispositivo, object otro)
        {
            if (esMedicamento != null && (bool)esMedicamento)
            {
                return medicamento?.ToString() ?? "";
            }
            if (esProcedimiento != null && (bool)esProcedimiento)
            {
                return procedimiento?.ToString() ?? "";
            }
            if (esDispositivo != null && (bool)esDispositivo)
            {
                return dispositivo?.ToString() ?? "";
            }
            if (esOtro != null && (bool)esOtro)
            {
                return otro?.ToString() ?? "";
            }
            return "";
        }


        /// <summary>
        /// Maneja el evento ItemDataBound del control DataList (datos).
        /// Este evento se dispara para cada elemento en el DataList durante la vinculación de datos.
        /// </summary>
        /// <param name="sender">El objeto que activa el evento.</param>
        /// <param name="e">La información del evento y los datos asociados.</param>
        protected void datos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Encuentra los controles dentro del elemento DataList
            Label lbl = (Label)e.Item.FindControl("lblCodNominacion");
            Repeater grd = (Repeater)e.Item.FindControl("grdObjeciones");
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Rellena el Repeater con datos basados en el elemento
            grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
            grd.DataBind();
        }

        /// <summary>
        /// Maneja el evento ItemDataBound del control Repeater (rptResultados).
        /// Este evento se dispara para cada elemento en el Repeater durante la vinculación de datos.
        /// </summary>
        /// <param name="sender">El objeto que activa el evento.</param>
        /// <param name="e">La información del evento y los datos asociados.</param>
        protected void rptResultados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Verifica si el tipo de elemento es ListItemType.Item
            if (e.Item.ItemType == ListItemType.Item)
            {
                // Encuentra los controles dentro del elemento Repeater
                Label lbl = (Label)e.Item.FindControl("lblCodNominacion2");
                GridView grd = (GridView)e.Item.FindControl("grdObjeciones2");
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Rellena el GridView con datos basados en el elemento
                grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
                grd.DataBind();

                // Muestra u oculta un Panel según si el GridView tiene filas
                if (grd.Rows.Count == 0)
                {
                    Panel pnl = (Panel)e.Item.FindControl("pnlObjeciones");
                    pnl.Visible = false;
                }
                else
                {
                    Panel pnl = (Panel)e.Item.FindControl("pnlObjeciones");
                    pnl.Visible = true;
                }
            }
        }


    }
}