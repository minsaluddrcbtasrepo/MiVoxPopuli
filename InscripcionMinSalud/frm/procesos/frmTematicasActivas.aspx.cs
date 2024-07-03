using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmTematicasActivas : System.Web.UI.Page
    {
        /// <summary>
        /// Este método se ejecuta al cargar la página.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Actualiza y enlaza los datos al GridView al cargar la página por primera vez.
                grdProcesos.DataBind();

                // Verifica si hay elementos en el GridView y ajusta la visibilidad de los paneles en consecuencia.
                if (grdProcesos.Items.Count == 0)
                {
                    pnlNoEventos.Visible = true;
                    pnleventos.Visible = false;
                }
                else
                {
                    pnlNoEventos.Visible = false;
                    pnleventos.Visible = true;
                }
            }
        }

    }
}