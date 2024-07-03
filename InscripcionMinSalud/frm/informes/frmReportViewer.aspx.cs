using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.informes
{
    public partial class frmReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
            Participacion2017DataSet ds = new Participacion2017DataSet();
            ds.EnforceConstraints = false;

            if (Request.QueryString["rpt"] == null)
            {
                Participacion2017DataSetTableAdapters.tblNominacionTableAdapter tbl = new Participacion2017DataSetTableAdapters.tblNominacionTableAdapter();
                
                tbl.Fill(ds.tblNominacion, int.Parse(Request.QueryString["cod"]));
                ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables["tblNominacion"]);
                string reporte = "~/frm/informes/rptNominacion.rdlc";
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(reporte);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource1);

            } else if (Request.QueryString["rpt"] == "1") {
                Participacion2017DataSetTableAdapters.tblObjecionTableAdapter tbl = new Participacion2017DataSetTableAdapters.tblObjecionTableAdapter();
                tbl.Fill(ds.tblObjecion, int.Parse(Request.QueryString["cod"]));
                ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables["tblObjecion"]);

                string reporte = "~/frm/informes/rptObjecion.rdlc";
               
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(reporte);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
            }
            else if (Request.QueryString["rpt"] == "2")//nominacion rups
            {
                Participacion2017DataSetTableAdapters.dtaRUPS tbl = new Participacion2017DataSetTableAdapters.dtaRUPS();

                tbl.Fill(ds.dtRUPS, int.Parse(Request.QueryString["cod"]));
                ReportDataSource datasource1 = new ReportDataSource("DataSet2", ds.Tables["dtRUPS"]);

                string reporte = "~/frm/informes/rptNominacionRupsNuevo.rdlc";
                if (ds.dtRUPS.Rows.Count > 0)
                {
                    if (ds.dtRUPS[0]["CALIFICACION_AJUSTE"].ToString() != "Incluir Procedimiento NUEVO")
                    {
                        reporte = "~/frm/informes/rptNominacionRupsAjuste.rdlc";
                    }
                }                
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(reporte);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
            }
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
                Response.AddHeader("content-disposition", "attachment; filename= reporteNominacion" + ".pdf");
                Response.OutputStream.Write(bytes, 0, bytes.Length); // create the file  
                Response.Flush(); // send it to the client to download  
                Response.End();
        }
    }
}