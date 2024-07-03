using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeProcesoNominacionCups : System.Web.UI.Page
    {

        public string clsParticipe = "tab-link col-md";
        public string clsResultados = "tab-link";
        public string clsAgremiacion = "tab-link";
        public string clsMetodologia = "tab-link";
        public string clsTabParticipe = "tab-content";
        public string clsTabAgremiacion = "tab-content";
        public string clsTabResultados = "tab-content";
        public string clsTabMetodologia = "tab-content";

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
                    clsMetodologia = "tab-link";

                    clsTabAgremiacion = "tab-content";
                    clsTabParticipe = "tab-content";
                    clsTabResultados = "tab-content current";
                    clsTabMetodologia = "tab-content";
                }
                else
                {
                    clsAgremiacion = "tab-link current";
                    clsParticipe = "tab-link";
                    clsResultados = "tab-link";
                    clsMetodologia = "tab-link";

                    clsTabAgremiacion = "tab-content current";
                    clsTabParticipe = "tab-content";
                    clsTabResultados = "tab-content";
                    clsTabMetodologia = "tab-content";
                }

                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

                var c = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));
                lblNombreProceso.Text = c.NOMBRE_PROCESO;
               
                lnkIntroduccion.NavigateUrl = lnkIntroduccion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkAnalisis.NavigateUrl = lnkAnalisis.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkDesicion.NavigateUrl = lnkDesicion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";

                iframeNominar.Src = "frmInscripcionProcesoRups.aspx?codProceso=" + c.COD_PROCESO+"&v=" + Request.QueryString["v"];

                VIGENCIA vigencia = c.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                if (vigencia != null)
                {
                    lblNombreProceso.Text = lblNombreProceso.Text + " - " + vigencia.DESCRIPCION;
                    if (vigencia.COD_VIGENCIA == 14)
                    {
                        divAnuncioAnterior.Visible = false;
                        divAnuncioActual.Visible = true;
                    }
                    else
                    {
                        divAnuncioAnterior.Visible = true;
                        divAnuncioActual.Visible = false;
                    }


                    if (DateTime.Now > vigencia.FECHA_INICIO && DateTime.Now <= vigencia.FECHA_FIN)
                    {
                        pnlVigenciaNominacion.Visible = true;
                        pnlNoVigenciaNominacion.Visible = false;
                    }
                    else
                    {
                        pnlVigenciaNominacion.Visible = false;
                        pnlNoVigenciaNominacion.Visible = true;
                    }
                    /*
                    if (vigencia.ABIERTO)
                    {
                        pnlRegistrese.Visible = true;
                        pnlNoRegistrese.Visible = false;
                    }
                    else
                    {
                        pnlRegistrese.Visible = false;
                        pnlNoRegistrese.Visible = true;
                    }*/
                }
                else
                {
                    pnlVigenciaNominacion.Visible = false;
                    pnlNoVigenciaNominacion.Visible = true;
                }
            


             }

        }

        /// <summary>
        /// Este método se ejecuta antes de renderizar la página y maneja la visibilidad de los paneles según la existencia de la sesión "SS_COD_REGISTRO".
        /// </summary>
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
        /// Retorna una cadena que indica el tipo según los parámetros proporcionados.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si es un dispositivo.</param>
        /// <param name="esOtro">Indica si es otro tipo.</param>
        /// <returns>Una cadena que representa el tipo ("Medicamentos", "Procedimientos", "Dispositivos" o "Otro").</returns>
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
        /// Retorna una cadena que indica si hay conflicto o no, basándose en el valor del parámetro conflicto.
        /// </summary>
        /// <param name="conflicto">El valor que indica si hay conflicto o no.</param>
        /// <returns>Una cadena que representa si hay conflicto ("SI") o no ("NO").</returns>
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
        /// Retorna una cadena que indica si hay evidencia o no, basándose en el valor del parámetro evidencia.
        /// </summary>
        /// <param name="evidencia">El valor que indica si hay evidencia o no.</param>
        /// <returns>Una cadena que representa si hay evidencia ("SI") o no ("NO").</returns>
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
        /// Retorna los criterios de exclusión como una cadena concatenada basada en los parámetros proporcionados.
        /// </summary>
        /// <param name="a">Indica si se cumple el criterio A.</param>
        /// <param name="b">Indica si se cumple el criterio B.</param>
        /// <param name="c">Indica si se cumple el criterio C.</param>
        /// <param name="d">Indica si se cumple el criterio D.</param>
        /// <param name="e">Indica si se cumple el criterio E.</param>
        /// <param name="f">Indica si se cumple el criterio F.</param>
        /// <returns>Una cadena con los criterios de exclusión concatenados.</returns>
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
        /// Retorna la descripción del tipo basado en los parámetros proporcionados.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si es un dispositivo.</param>
        /// <param name="esOtro">Indica si es otro tipo.</param>
        /// <param name="medicamento">El valor del medicamento.</param>
        /// <param name="procedimiento">El valor del procedimiento.</param>
        /// <param name="dispositivo">El valor del dispositivo.</param>
        /// <param name="otro">El valor de otro.</param>
        /// <returns>La descripción del tipo.</returns>
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
            if (esDispositivo != null && (bool)esMedicamento)
            {
                return dispositivo.ToString();
            }
            if (esOtro != null && (bool)esMedicamento)
            {
                return otro.ToString();
            }
            return "";
        }

        protected void datos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lblCodNominacion");
            Repeater grd = (Repeater)e.Item.FindControl("grdObjeciones");
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text))
                ;
            grd.DataBind();
        }
        /// <summary>
        /// Maneja el evento ItemDataBound del control Repeater (rptResultados).
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void rptResultados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                //CUPS NO HAY OBJECIONES EN LA NOMINACION
                Panel pnl = (Panel)e.Item.FindControl("pnlObjeciones");
                pnl.Visible = false;
               
            }
        }

    }
}