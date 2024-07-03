using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioInscripcionMinSalud.data;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeProcesoNominacionUPC : System.Web.UI.Page
    {
        public string clsParticipe = "tab-link";
        public string clsResultados = "tab-link";
        public string clsAgremiacion = "tab-link";
        public string clsTabParticipe = "tab-content";
        public string clsTabAgremiacion = "tab-content";
        public string clsTabResultados = "tab-content";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["cod"] == null)
                {
                    Response.Redirect("../logica/frmDefault.aspx");
                }

                if (Request.QueryString["r"] != null && Request.QueryString["r"] != string.Empty)
                {
                    clsParticipe = "tab-link";
                    clsAgremiacion = "tab-link";
                    clsResultados = "tab-link active current";

                    clsTabAgremiacion = "tab-content";
                    clsTabParticipe = "tab-content";
                    clsTabResultados = "tab-content current";
                }
                else
                {
                    clsAgremiacion = "tab-link current";
                    clsParticipe = "tab-link";
                    clsResultados = "tab-link";

                    clsTabAgremiacion = "tab-content current";
                    clsTabParticipe = "tab-content";
                    clsTabResultados = "tab-content";
                }

                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
                var c = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));
                lblNombreProceso.Text = c.NOMBRE_PROCESO;
                if (c != null)
                {
                    VIGENCIA vigencia = c.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));
                    lblNombreProceso.Text = c.NOMBRE_PROCESO + " - " + vigencia.DESCRIPCION;
                }
                lnkIntroduccion.NavigateUrl = lnkIntroduccion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                iframeNominar.Src = "frmInscripcionProcesoUPC.aspx?codProceso=" + c.COD_PROCESO;
            }

        }

        protected void Page_PreRender()
        {

            if (Session["SS_COD_REGISTRO"] != null)
            {
                pnlRegistrese.Visible = false;
                iframeNominar.Visible = true;


            }
            else
            {
                pnlRegistrese.Visible = true;
                iframeNominar.Visible = false;
            }
        }


        /// <summary>
        /// Obtiene la representación en texto del tipo de elemento.
        /// </summary>
        /// <param name="esMedicamento">Valor que indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Valor que indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Valor que indica si es un dispositivo.</param>
        /// <param name="esOtro">Valor que indica si es otro tipo de elemento.</param>
        /// <returns>Una cadena que representa el tipo de elemento.</returns>
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
            if (esDispositivo != null && (bool)esMedicamento)
            {
                return "Dispositivos";
            }
            if (esOtro != null && (bool)esMedicamento)
            {
                return "Otro";
            }
            return "";
        }

        /// <summary>
        /// Obtiene la representación en texto del conflicto.
        /// </summary>
        /// <param name="conflicto">Valor que indica la presencia o ausencia de conflicto.</param>
        /// <returns>Una cadena que representa el conflicto ("SI" o "NO").</returns>
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
        /// Obtiene la representación en texto de la evidencia.
        /// </summary>
        /// <param name="evidencia">Valor que indica la presencia o ausencia de evidencia.</param>
        /// <returns>Una cadena que representa la evidencia ("SI" o "NO").</returns>
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
        /// Obtiene los criterios de exclusión concatenados en una cadena.
        /// </summary>
        /// <param name="a">Criterio A.</param>
        /// <param name="b">Criterio B.</param>
        /// <param name="c">Criterio C.</param>
        /// <param name="d">Criterio D.</param>
        /// <param name="e">Criterio E.</param>
        /// <param name="f">Criterio F.</param>
        /// <returns>Una cadena que representa los criterios de exclusión seleccionados.</returns>
        public string criteriosExclusion(object a, object b, object c, object d, object e, object f)
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
        /// Obtiene la descripción del tipo basado en los parámetros proporcionados.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si es un dispositivo.</param>
        /// <param name="esOtro">Indica si es otro.</param>
        /// <param name="medicamento">Descripción del medicamento.</param>
        /// <param name="procedimiento">Descripción del procedimiento.</param>
        /// <param name="dispositivo">Descripción del dispositivo.</param>
        /// <param name="otro">Descripción de otro.</param>
        /// <returns>La descripción del tipo o una cadena vacía si no se cumple ninguna condición.</returns>
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
        /// Controla el evento ItemDataBound del DataList datos.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void datos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Obtener el control Label lblCodNominacion y Repeater grdObjeciones del elemento del DataList.
            Label lbl = (Label)e.Item.FindControl("lblCodNominacion");
            Repeater grd = (Repeater)e.Item.FindControl("grdObjeciones");

            // Crear una instancia de la clase de negocio clsNegocio.
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Obtener y establecer la fuente de datos para el Repeater grdObjeciones.
            grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
            grd.DataBind();
        }

        /// <summary>
        /// Controla el evento ItemDataBound del Repeater rptResultados.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void rptResultados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                // Obtener el control Label lblCodNominacion2 y GridView grdObjeciones2 del elemento del Repeater.
                Label lbl = (Label)e.Item.FindControl("lblCodNominacion2");
                GridView grd = (GridView)e.Item.FindControl("grdObjeciones2");

                // Crear una instancia de la clase de negocio clsNegocio.
                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Obtener y establecer la fuente de datos para el GridView grdObjeciones2.
                grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));
                grd.DataBind();

                // Mostrar u ocultar el Panel pnlObjeciones según la cantidad de filas en el GridView.
                Panel pnl = (Panel)e.Item.FindControl("pnlObjeciones");
                pnl.Visible = grd.Rows.Count > 0;
            }
        }

    }
}