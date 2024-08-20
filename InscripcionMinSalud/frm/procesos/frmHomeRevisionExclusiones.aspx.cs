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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["cod"] == null)
                {
                    Response.Redirect("../logica/frmDefault.aspx");
                }

               

                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
                var proceso = obj.obtenerProceso(int.Parse(Request.QueryString["cod"]));
                if (proceso != null)
                {
                    VIGENCIA vigencia = proceso.VIGENCIA.FirstOrDefault(vig => vig.COD_VIGENCIA == Convert.ToInt32(Request.QueryString["v"]));
                    lblNombreProceso.Text = proceso.NOMBRE_PROCESO + " - " + vigencia.DESCRIPCION;
                }
                lnkNominacion.NavigateUrl = lnkNominacion.NavigateUrl + "?cod=" + Request.QueryString["cod"] + "&v=" + Request.QueryString["v"] + "&r=" + Request.QueryString["r"] + "";

            }
        }

     
    }
}