using DevExpress.XtraCharts;
using NegocioInscripcionMinSalud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.registro
{
    public partial class frmConozca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ctReporte.DataSourceID = "sqlConsolidado";
                //ctReporte.SeriesDataMember = "TipoUsuario";
                //ctReporte.SeriesTemplate.ArgumentDataMember = "TipoUsuario";
                //ctReporte.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Numero" });
                //ctReporte.SeriesTemplate.View = new SideBySideBarSeriesView();
                ////ctReporte.SeriesTemplate.ShowInLegend = true;

                //((SideBySideBarSeriesView)ctReporte.SeriesTemplate.View).BarWidth = 10.15;
                //ctReporte.SeriesTemplate.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
                //ctReporte.SeriesTemplate.PointOptions.ValueNumericOptions.Precision = 0;

                //ctReporte.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                ////((BarSeriesLabel)ctReporte.SeriesTemplate.Label).                
                //((BarSeriesLabel)ctReporte.SeriesTemplate.Label).Position = BarSeriesLabelPosition.TopInside;

                //AxisX axisX = ((XYDiagram)ctReporte.Diagram).AxisX;
                //axisX.Label.Visible = false;

                //AxisY axisY = ((XYDiagram)ctReporte.Diagram).AxisY;
                //axisY.Logarithmic = false;
                //axisY.Range.AlwaysShowZeroLevel = false;
                //int maximo = Administrador.ObtenerMayorRango();
                //axisY.WholeRange.SetMinMaxValues(0, maximo);

                //ctReporte.DataBind();

                //foreach (Series serie in ctReporte.Series)
                //{
                //    serie.Label.LineVisible = true;
                //    ((BarSeriesLabel)serie.Label).Position = BarSeriesLabelPosition.Top;
                //}
            }
        }

        /// <summary>
        /// Este método se utiliza para calcular la visibilidad de un elemento en función del tipo de usuario. Devuelve verdadero si el tipo de usuario no es 9 o 11; de lo contrario, devuelve falso.
        /// </summary>
        /// <param name="tipoUsuario">El tipo de usuario que se va a verificar</param>
        /// <returns>Verdadero si el tipo de usuario no es 9 o 11; de lo contrario, falso.</returns>
        public bool CalcularVisible(object tipoUsuario)
        {
            if (tipoUsuario.ToString() == "9" || tipoUsuario.ToString() == "11")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /**
 * Método que redirige a los usuarios a la página de detalles de inscritos.
 * @param sender El control que invoca el evento.
 * @param e El objeto de argumentos de evento.
 */
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            // Obtiene el tipo de usuario del argumento de comando del botón
            string tipoUsuario = ((Button)sender).CommandArgument;

            // Redirige al usuario a la página de detalles de inscritos con el tipo de usuario correspondiente
            Response.Redirect("~/Aspx/Reportes/frmReporteDetalleInscritos.aspx?TipoUsuario=" + tipoUsuario);
        }

        /**
         * Método que redirige a los usuarios a la página de detalles del departamento.
         * @param sender El control que invoca el evento.
         * @param e El objeto de argumentos de evento.
         */
        protected void btnDetalleDepartamento_Click(object sender, EventArgs e)
        {
            // Obtiene el tipo de usuario del argumento de comando del botón
            string tipoUsuario = ((Button)sender).CommandArgument;

            // Redirige al usuario a la página de detalles del departamento con el tipo de usuario correspondiente
            Response.Redirect("~/Aspx/Reportes/frmReporteDetalleDepartamento.aspx?TipoUsuario=" + tipoUsuario);
        }


    }
}