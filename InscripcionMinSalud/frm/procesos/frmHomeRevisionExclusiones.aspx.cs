using NegocioInscripcionMinSalud.data;
using NegocioInscripcionMinSalud;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmHomeRevisionExclusiones : System.Web.UI.Page
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
                    clsAgremiacion = "tab-link active current";
                    clsResultados = "tab-link ";
                    clsMetodologia = "tab-link";

                    clsTabAgremiacion = "tab-content active current";
                    clsTabParticipe = "tab-content";
                    clsTabResultados = "tab-content ";
                    clsTabMetodologia = "tab-content";
                }
                else
                {
                    clsAgremiacion = "tab-link active current";
                    clsParticipe = "tab-link";
                    clsResultados = "tab-link";
                    clsMetodologia = "tab-link";

                    clsTabAgremiacion = "tab-content active current";
                    clsTabParticipe = "tab-content";
                    clsTabResultados = "tab-content";
                    clsTabMetodologia = "tab-content";
                }

                NegocioInscripcionMinSalud.data.clsNegocio service = new NegocioInscripcionMinSalud.data.clsNegocio();

                var procesoEntity = service.obtenerProceso(int.Parse(Request.QueryString["cod"]));
                lblNombreProceso.Text = procesoEntity.NOMBRE_PROCESO;

                lnkIntroduccion.NavigateUrl = lnkIntroduccion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkAnalisis.NavigateUrl = lnkAnalisis.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";
                lnkDesicion.NavigateUrl = lnkDesicion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";

                iframeNominar.Src = "frmExclusiones_EtapaI_Solicitud.aspx?codProceso=" + procesoEntity.COD_PROCESO + "&v=" + Request.QueryString["v"];

                VIGENCIA vigencia = procesoEntity.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));

                if (vigencia != null)
                {
                    lblNombreProceso.Text = lblNombreProceso.Text + " - " + vigencia.DESCRIPCION;
                    if (vigencia.COD_VIGENCIA == 14)
                    {
                        divAnuncioAnterior.Visible = false;
                    }
                    else
                    {
                        divAnuncioAnterior.Visible = true;
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


        

       


    }
}