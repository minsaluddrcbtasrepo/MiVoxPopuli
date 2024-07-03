using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.Aspx.Reportes
{
    public partial class frmReporteDetalleDepartamento : System.Web.UI.Page
    {
        /// <summary>
        /// Carga la página y establece el título del informe de participantes detallado por departamento.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitulo.InnerText = "Listado total participantes detallado por Departamento ";
                lblTitulo.InnerHtml = lblTitulo.InnerText;
            }
        }

        /// <summary>
        /// Exporta los datos a un archivo de Excel cuando se hace clic en el botón de exportar a Excel.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            exportDatos.WriteXlsToResponse();
        }

        /// <summary>
        /// Redirige a la página de informes de usuarios inscritos cuando se hace clic en el botón Regresar.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Aspx/Reportes/frmReporteInscritos.aspx");
        }

    }
}