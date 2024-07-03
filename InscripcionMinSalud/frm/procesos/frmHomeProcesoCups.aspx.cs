using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioInscripcionMinSalud.data;


namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeProcesoCups : System.Web.UI.Page
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
        /// Obtiene una representación de cadena del tipo basado en las banderas indicadoras.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si es un dispositivo.</param>
        /// <param name="esOtro">Indica si es de otro tipo.</param>
        /// <returns>String que representa el tipo.</returns>
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
        /// Obtiene una representación de cadena indicando la presencia de conflicto.
        /// </summary>
        /// <param name="conflicto">Indica si hay conflicto.</param>
        /// <returns>String que representa la presencia de conflicto.</returns>
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
        /// Obtiene una representación de cadena indicando si hay evidencia o no.
        /// </summary>
        /// <param name="evidencia">Indica si hay evidencia.</param>
        /// <returns>String que representa la presencia de evidencia.</returns>
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
        /// Genera un string concatenando los criterios de exclusión que cumplen con ciertas condiciones.
        /// </summary>
        /// <param name="a">Indica si se cumple el criterio A.</param>
        /// <param name="b">Indica si se cumple el criterio B.</param>
        /// <param name="c">Indica si se cumple el criterio C.</param>
        /// <param name="d">Indica si se cumple el criterio D.</param>
        /// <param name="e">Indica si se cumple el criterio E.</param>
        /// <param name="f">Indica si se cumple el criterio F.</param>
        /// <returns>String que contiene los criterios de exclusión que cumplen con ciertas condiciones.</returns>
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
        /// Retorna una descripción basada en el tipo de elemento y su valor correspondiente.
        /// </summary>
        /// <param name="esMedicamento">Indica si el elemento es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si el elemento es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si el elemento es un dispositivo.</param>
        /// <param name="esOtro">Indica si el elemento es de otro tipo.</param>
        /// <param name="medicamento">Valor correspondiente al medicamento.</param>
        /// <param name="procedimiento">Valor correspondiente al procedimiento.</param>
        /// <param name="dispositivo">Valor correspondiente al dispositivo.</param>
        /// <param name="otro">Valor correspondiente a otro tipo.</param>
        /// <returns>Descripción basada en el tipo de elemento y su valor correspondiente.</returns>
        public string verDescripcionTipo(
            object esMedicamento, object esProcedimiento, object esDispositivo, object esOtro,
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
        /// Maneja el evento ItemDataBound del DataList datos.
        /// Agrega datos al control Repeater grdObjeciones y establece su origen de datos.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void datos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Encuentra el control Label lblCodNominacion en el elemento del DataList
            Label lbl = (Label)e.Item.FindControl("lblCodNominacion");

            // Encuentra el control Repeater grdObjeciones en el elemento del DataList
            Repeater grd = (Repeater)e.Item.FindControl("grdObjeciones");

            // Instancia del objeto de negocio
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Establece el origen de datos del Repeater con las objeciones para la nominación específica
            grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
            grd.DataBind();
        }

        /// <summary>
        /// Maneja el evento ItemDataBound del Repeater rptResultados.
        /// Agrega datos al control GridView y gestiona la visibilidad del panel de objeciones.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void rptResultados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                // Encuentra el control Label lblCodNominacion2 en el elemento del Repeater
                Label lbl = (Label)e.Item.FindControl("lblCodNominacion2");

                // Encuentra el control GridView grdObjeciones2 en el elemento del Repeater
                GridView grd = (GridView)e.Item.FindControl("grdObjeciones2");

                // Instancia del objeto de negocio
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Establece el origen de datos del GridView con las objeciones para la nominación específica
                grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
                grd.DataBind();

                // Gestiona la visibilidad del panel de objeciones
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