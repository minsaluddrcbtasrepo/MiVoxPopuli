using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.informes
{
    public partial class frmReportViewerHuerfanas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
            Participacion2017DataSetHuerfanas ds = new Participacion2017DataSetHuerfanas();

            int tipoReporte = 0;
            int codigoNominacion = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["rpt"]))
            {
                tipoReporte = Convert.ToInt32(Request.QueryString["rpt"]);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["cod"]))
            {
                codigoNominacion = Convert.ToInt32(Request.QueryString["cod"]);
            }

            string conexionString = "";
            if (ConfigurationManager.ConnectionStrings["participacion2017ConnectionString"] != null)
            {
                conexionString = ConfigurationManager.ConnectionStrings["participacion2017ConnectionString"].ConnectionString;
            }
            

            if (tipoReporte > 0 && codigoNominacion > 0)
            {
                ds.EnforceConstraints = false;

                string reporte = "";
                ReportDataSource datasource1 = null;

                switch (tipoReporte)
                {
                    case 1:
                        Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_1TableAdapter tbl = new Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_1TableAdapter();
                        tbl.Connection.ConnectionString = conexionString;
                        tbl.Fill(ds.VW_NOMINCACION_HUERFANAS_1, codigoNominacion);                        
                        datasource1 = new ReportDataSource("DataSet2", ds.Tables["VW_NOMINCACION_HUERFANAS_1"]);
                        reporte = "~/frm/informes/rptNominacionHuerfana1.rdlc";
                        break;
                    case 2:
                        Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_2TableAdapter tbl2 = new Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_2TableAdapter();
                        tbl2.Connection.ConnectionString = conexionString;
                        tbl2.Fill(ds.VW_NOMINCACION_HUERFANAS_2, codigoNominacion);                        
                        datasource1 = new ReportDataSource("DataSet2", ds.Tables["VW_NOMINCACION_HUERFANAS_2"]);
                        reporte = "~/frm/informes/rptNominacionHuerfana2.rdlc";
                        break;
                    case 3:
                        Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_3TableAdapter tbl3 = new Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_3TableAdapter();
                        tbl3.Connection.ConnectionString = conexionString;
                        tbl3.Fill(ds.VW_NOMINCACION_HUERFANAS_3, codigoNominacion);                        
                        datasource1 = new ReportDataSource("DataSet2", ds.Tables["VW_NOMINCACION_HUERFANAS_3"]);
                        reporte = "~/frm/informes/rptNominacionHuerfana3.rdlc";
                        break;
                    case 4:
                        Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_4TableAdapter tbl4 = new Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_4TableAdapter();
                        tbl4.Connection.ConnectionString = conexionString;
                        tbl4.Fill(ds.VW_NOMINCACION_HUERFANAS_4, codigoNominacion);                        
                        datasource1 = new ReportDataSource("DataSet2", ds.Tables["VW_NOMINCACION_HUERFANAS_4"]);
                        reporte = "~/frm/informes/rptNominacionHuerfana4.rdlc";
                        break;
                    case 5:
                        Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_5TableAdapter tbl5 = new Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_5TableAdapter();
                        tbl5.Connection.ConnectionString = conexionString;
                        tbl5.Fill(ds.VW_NOMINCACION_HUERFANAS_5, codigoNominacion);                        
                        datasource1 = new ReportDataSource("DataSet2", ds.Tables["VW_NOMINCACION_HUERFANAS_5"]);
                        reporte = "~/frm/informes/rptNominacionHuerfana5.rdlc";
                        break;
                    case 6:
                        Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_6TableAdapter tbl6 = new Participacion2017DataSetHuerfanasTableAdapters.VW_NOMINCACION_HUERFANAS_6TableAdapter();
                        tbl6.Connection.ConnectionString = conexionString;
                        tbl6.Fill(ds.VW_NOMINCACION_HUERFANAS_6, codigoNominacion);                        
                        datasource1 = new ReportDataSource("DataSet2", ds.Tables["VW_NOMINCACION_HUERFANAS_6"]);
                        reporte = "~/frm/informes/rptNominacionHuerfana6.rdlc";
                        break;
                }

                if (reporte != "" && datasource1 != null) 
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath(reporte);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource1);

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string filenameExtension;
                    byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    //generamos el pdf          
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename= reporteNominacionHuerfana" + ".pdf");
                    Response.OutputStream.Write(bytes, 0, bytes.Length); // create the file  
                    Response.Flush(); // send it to the client to download  
                    Response.End();
                }
            }
        }
    }
}