using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraCharts;
using NegocioInscripcionMinSalud;

namespace InscripcionMinSalud.Aspx.Reportes
{
    public partial class frmReporteInscritos : System.Web.UI.Page
    {
        /// <summary>
        /// Carga los datos y configura el control de gráficos al cargar la página.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    ctReporte.DataSourceID = "sqlConsolidado";
            //    ctReporte.SeriesDataMember = "TipoUsuario";
            //    ctReporte.SeriesTemplate.ArgumentDataMember = "TipoUsuario";
            //    ctReporte.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Numero" });
            //    ctReporte.SeriesTemplate.View = new SideBySideBarSeriesView();

            //    ((SideBySideBarSeriesView)ctReporte.SeriesTemplate.View).BarWidth = 10.15;
            //    ctReporte.SeriesTemplate.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            //    ctReporte.SeriesTemplate.PointOptions.ValueNumericOptions.Precision = 0;
            //    ctReporte.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            //    ((BarSeriesLabel)ctReporte.SeriesTemplate.Label).Position = BarSeriesLabelPosition.TopInside;

            //    AxisX axisX = ((XYDiagram)ctReporte.Diagram).AxisX;
            //    axisX.Label.Visible = false;

            //    AxisY axisY = ((XYDiagram)ctReporte.Diagram).AxisY;
            //    axisY.Logarithmic = false;
            //    axisY.Range.AlwaysShowZeroLevel = false;
            //    int maximo = Administrador.ObtenerMayorRango();
            //    axisY.WholeRange.SetMinMaxValues(0, maximo);

            //    ctReporte.DataBind();

            //    foreach (Series serie in ctReporte.Series)
            //    {
            //        serie.Label.LineVisible = true;
            //        ((BarSeriesLabel)serie.Label).Position = BarSeriesLabelPosition.Top;
            //    }
            //}
        }


        /// <summary>
        /// Calcula si un tipo de usuario es visible.
        /// </summary>
        /// <param name="tipoUsuario">El tipo de usuario para calcular la visibilidad.</param>
        /// <returns>Verdadero si el tipo de usuario es visible; de lo contrario, falso.</returns>
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

        /// <summary>
        /// Redirige a la página de detalle de informes de inscritos al hacer clic en el botón "Editar".
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string tipoUsuario = ((Button)sender).CommandArgument;
            Response.Redirect("~/Aspx/Reportes/frmReporteDetalleInscritos.aspx?TipoUsuario=" + tipoUsuario);
        }

        /// <summary>
        /// Redirige a la página de detalle del departamento al hacer clic en el botón "DetalleDepartamento".
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnDetalleDepartamento_Click(object sender, EventArgs e)
        {
            string tipoUsuario = ((Button)sender).CommandArgument;
            Response.Redirect("~/Aspx/Reportes/frmReporteDetalleDepartamento.aspx?TipoUsuario=" + tipoUsuario);
        }

    }
}