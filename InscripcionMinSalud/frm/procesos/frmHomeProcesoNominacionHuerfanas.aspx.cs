using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeProcesoNominacionHuerfanas : System.Web.UI.Page
    {

        public string clsParticipe = "tab-link";
        public string clsResultados = "tab-link";
        public string clsTabParticipe = "tab-content";
        public string clsTabResultados = "tab-content";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["cod"] == null)
                {
                    Response.Redirect("../logica/frmDefault.aspx");
                }

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
                var proceso = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));

                //Enfermedades Huerfanas
                //cod = 18 & v = 9 & r = 1
                if (proceso != null && (proceso.COD_PROCESO == 21 || proceso.COD_PROCESO == 18))
                {
                    lblDescProceso.Visible = false;
                    lblDescHuerfanas.Visible = true;
                    lblDescProcesoNomi.Visible = false;


                    lblDescHuerfanasNomi.Visible = true;
                    iframeNominar.Src = "frmInscripcionHuerfanas.aspx?codProceso=" + proceso.COD_PROCESO + "&v=" + Request.QueryString["v"];
                }

                lblNombreProceso.Text = proceso.NOMBRE_PROCESO;
                

                lnkAdopcion.NavigateUrl = lnkAdopcion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkAnalisis.NavigateUrl = lnkAnalisis.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                

                VIGENCIA vigencia = proceso.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));


                if (vigencia != null)
                {
                    lblNombreProceso.Text = lblNombreProceso.Text + " - " + vigencia.DESCRIPCION;
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

                    if (vigencia.ABIERTO)
                    {
                        pnlRegistrese.Visible = true;
                        pnlNoRegistrese.Visible = false;
                    }
                    else
                    {
                        pnlRegistrese.Visible = false;
                        pnlNoRegistrese.Visible = true;
                    }

                    pnlVigenciaNominacion.Visible = false;
                    pnlNoVigenciaNominacion.Visible = true;
                }
                else
                {
                    pnlVigenciaNominacion.Visible = false;
                    pnlNoVigenciaNominacion.Visible = true;
                }
            }
        }

        /// <summary>
        /// Maneja el evento PreRender de la página.
        /// </summary>
        protected void Page_PreRender()
        {
            if (Session["SS_COD_REGISTRO"] != null)
            {
                pnlRegistrese.Visible = false;
                pnlNoRegistrese.Visible = true;
            }
            else
            {
                NegocioInscripcionMinSalud.data.clsNegocio negocio = new NegocioInscripcionMinSalud.data.clsNegocio();
                var proceso = negocio.obtenerProceso(int.Parse(Request.QueryString["cod"]));

                VIGENCIA vigencia = proceso.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                if (vigencia != null)
                {
                    if (vigencia.ABIERTO)
                    {
                        pnlRegistrese.Visible = true;
                        pnlNoRegistrese.Visible = false;
                    }
                    else
                    {
                        pnlRegistrese.Visible = false;
                        pnlNoRegistrese.Visible = true;
                    }
                }
                else
                {
                    pnlRegistrese.Visible = true;
                    pnlNoRegistrese.Visible = false;
                }
            }
        }


        /// <summary>
        /// Obtiene la representación de cadena del tipo basado en los valores de las propiedades.
        /// </summary>
        /// <param name="esMedicamento">Indica si es un medicamento.</param>
        /// <param name="esProcedimiento">Indica si es un procedimiento.</param>
        /// <param name="esDispositivo">Indica si es un dispositivo.</param>
        /// <param name="esOtro">Indica si es otro.</param>
        /// <returns>Una cadena que representa el tipo.</returns>
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
        /// Obtiene la representación de cadena de un valor de conflicto.
        /// </summary>
        /// <param name="conflicto">El valor de conflicto a evaluar.</param>
        /// <returns>Una cadena que indica si hay conflicto o no.</returns>
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
        /// Obtiene la representación de cadena de un valor de evidencia.
        /// </summary>
        /// <param name="evidencia">El valor de evidencia a evaluar.</param>
        /// <returns>Una cadena que indica si hay evidencia o no.</returns>
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
        /// Maneja el evento DataBound del control de datos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void datos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Se obtiene la etiqueta que contiene el código de nominación.
            Label lbl = (Label)e.Item.FindControl("lblCodNominacion");

            // Se obtiene el repeater que contiene las objeciones.
            Repeater grd = (Repeater)e.Item.FindControl("grdObjeciones");

            // Se crea una instancia del objeto de negocio.
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Se asigna la fuente de datos al repeater.
            grd.DataSource = obj.obtenerObjecionxNominacion(int.Parse(lbl.Text));

            // Se realiza el enlace de datos.
            grd.DataBind();
        }

        /**
 * Evento que se ejecuta al enlazar datos a un control Repeater durante la creación de elementos en el evento ItemDataBound.
 * 
 * @param sender: El objeto que desencadenó el evento (rptResultados).
 * @param e: Un objeto RepeaterItemEventArgs que contiene los datos del evento.
 */
        protected void rptResultados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Se crea una instancia del objeto de negocios para acceder a la lógica de negocio.
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();

            // Se obtiene el objeto de proceso correspondiente al código proporcionado en la consulta.
            var proceso = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));

            // Se verifica si el elemento es de tipo Item o AlternatingItem en el Repeater.
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Se encuentra el control Label lblCodNominacion2 en el elemento Repeater actual.
                Label lbl = (Label)e.Item.FindControl("lblCodNominacion2");

                // Se encuentra el control GridView grdObjeciones2 en el elemento Repeater actual.
                GridView grd = (GridView)e.Item.FindControl("grdObjeciones2");

                // Se crea una nueva instancia del objeto de negocios para obtener objeciones específicas.
                NegocioInscripcionMinSalud.data.clsNegocio obj2 = new NegocioInscripcionMinSalud.data.clsNegocio();

                // Se establece el origen de datos del GridView con las objeciones obtenidas por el método obtenerObjecionxNominacionHuerfana.
                grd.DataSource = obj2.obtenerObjecionxNominacionHuerfana(int.Parse(lbl.Text));

                // Se enlaza el origen de datos al GridView.
                grd.DataBind();

                // Se verifica si el GridView tiene filas.
                if (grd.Rows.Count == 0)
                {
                    // Si el GridView no tiene filas, se oculta el panel de objeciones.
                    Panel pnl = (Panel)e.Item.FindControl("pnlObjecionesHuerfanas");
                    pnl.Visible = false;
                }
                else
                {
                    // Si el GridView tiene filas, se muestra el panel de objeciones.
                    Panel pnl = (Panel)e.Item.FindControl("pnlObjecionesHuerfanas");
                    pnl.Visible = true;
                }
            }
        }


        /// <summary>
        /// Maneja el evento Click del botón de objetar.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void btnObjetar_Click2(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Response.Redirect("../procesos/frmObjetarHuerfanas.aspx?codN=" + b.CommandArgument + "&codProceso=" + Request.QueryString["cod"]);
        }

        public int CalcularVisibleObjecion(object codEstado, object resultado, object idUsuario, object objecion)
        {
            int idUsuarioLogin = -1;
            if (Session["SS_COD_REGISTRO"] != null)
            {
                idUsuarioLogin = Convert.ToInt32(Session["SS_COD_REGISTRO"]);
            }

            if (Convert.ToInt32(codEstado) >= 3 && resultado.ToString() == "Rechazada" && Convert.ToInt32(idUsuario) == idUsuarioLogin)
            {
                if (Convert.ToInt32(objecion) > 0)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (Convert.ToInt32(objecion) > 0)
                {
                    return 3;
                }
                else
                {
                    return 2;
                }                   
            }            
        }
    }
}