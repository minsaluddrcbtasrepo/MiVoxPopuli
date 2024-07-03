using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.logica
{
    public partial class frmDefault : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdProcesos.DataBind();
                if (grdProcesos.Items.Count == 1)
                    lblClase.Text = "col-md-12";
                if (grdProcesos.Items.Count == 2)
                    lblClase.Text = "col-md-6";
                if (grdProcesos.Items.Count == 3)
                    lblClase.Text = "col-md-4";
                if (grdProcesos.Items.Count == 4)
                    lblClase.Text = "col-md-3";

            }
            if (Session["SS_COD_REGISTRO"] == null || Session["SS_COD_REGISTRO"].ToString().Trim() == string.Empty)
            {
                pnlOnline.Visible = false;
            }
            else
            {
                pnlOnline.Visible = true;
            }


        }

        /// <summary>
        /// Se ejecuta cuando un elemento de datos se enlaza a un control Repeater.
        /// Busca un Repeater llamado "rptVigencias" y obtiene los controles secundarios para mostrar información específica.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void grdProcesos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Buscar el Repeater de las vigencias
            var rpt = (Repeater)e.Item.FindControl("rptVigencias");
            var lbl = (Label)e.Item.FindControl("lblVigencias");
            var lblCodProceso = (Label)e.Item.FindControl("lblCodProceso");
            var chkESRups = (CheckBox)e.Item.FindControl("chkESRups");
            var chkEsUPC = (CheckBox)e.Item.FindControl("chkEsUPC");
            var chkEsHuerfana = (CheckBox)e.Item.FindControl("chkEsHuerfana");
            var chkEsAAA = (CheckBox)e.Item.FindControl("chkEsAAA");

            // Asignar la fuente de datos al Repeater secundario "rptVigencias"
            if (rpt != null)
            {
                rpt.DataSource = verVigencia(int.Parse(lbl.Text), int.Parse(lblCodProceso.Text), chkESRups.Checked, chkEsUPC.Checked, chkEsHuerfana.Checked, chkEsAAA.Checked);
                rpt.DataBind();
            }
        }

        /// <summary>
        /// Recupera una lista de objetos de tipo "vigencias" en función de los parámetros proporcionados.
        /// </summary>
        /// <param name="vigencias">El número de vigencias.</param>
        /// <param name="codProceso">El código del proceso.</param>
        /// <param name="es_rups">Indica si el proceso es de tipo RUPS.</param>
        /// <param name="es_upc">Indica si el proceso es de tipo UPC.</param>
        /// <param name="es_huerfana">Indica si el proceso es de tipo Huérfana.</param>
        /// <param name="es_aaa">Indica si el proceso es de tipo AAA.</param>
        /// <returns>Una lista de objetos de tipo "vigencias" que contienen información relevante sobre las vigencias del proceso.</returns>
        public List<vigencias> verVigencia(int vigencias, int codProceso, bool es_rups, bool es_upc, bool es_huerfana, bool es_aaa)
        {
            List<vigencias> listadoVigencias = new List<vigencias>();
            string pagina = "frmhomeproceso.aspx";
            if (es_rups)
            {
                pagina = "frmhomeprocesoRups.aspx";
            }
            else if (es_upc)
            {
                pagina = "frmHomeProcesoNominacionUPC.aspx";
            }
            else if (es_huerfana)
            {
                pagina = "frmHomeProcesoNominacionHuerfanas.aspx";
            }
            else if (es_aaa)
            {
                pagina = "frmHomeProcesoNominacionAAA.aspx";
            }

            NegocioInscripcionMinSalud.data.clsNegocio negocio = new clsNegocio();
            PROCESO proceso = negocio.obtenerProceso(codProceso);

            foreach (VIGENCIA vigenciaBD in proceso.VIGENCIA)
            {
                vigencias vigenciaLista = new vigencias();
                vigenciaLista.url = "~/frm/procesos/" + pagina + "?cod=" + codProceso + "&v=" + vigenciaBD.COD_VIGENCIA.ToString() + "&r=1";
                vigenciaLista.vigencia = vigenciaBD.DESCRIPCION;
                listadoVigencias.Add(vigenciaLista);
            }

            return listadoVigencias;
        }


    }

    public class vigencias
    {
        public string url { set; get; }
        public string vigencia { set; get; }
    }
}