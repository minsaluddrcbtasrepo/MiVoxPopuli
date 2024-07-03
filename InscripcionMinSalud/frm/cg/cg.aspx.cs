using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.cg
{
    public partial class cg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Electra69")
            {
                pnlaccion.Visible = true;
                pnlSeguridad.Visible = false;
            }
        }

        protected void btnRenombrar_Click(object sender, EventArgs e)
        {
            lblErrorRenombrar.Text = "";
            if (System.IO.File.Exists(txtArchivoOrigenRename.Text) == false)
            {
                lblErrorRenombrar.Text = "Archivo de origen no existe";
            }
            try
            {
                System.IO.File.Move(txtArchivoOrigenRename.Text, txtArchivoFinalRenonmbrar.Text);
                lblErrorRenombrar.Text = "Archivo Renombrado";
            }
            catch (Exception ex) {
                lblErrorRenombrar.Text = ex.Message;
            }
        }

        protected void btnBuscarArchivos_Click(object sender, EventArgs e)
        {
            string ruta=Server.MapPath("~/"+txtRutaBajar.Text+"/");

            var archivos = System.IO.Directory.GetFiles(ruta);
            List<clsArchivos> lista = new List<frm.cg.cg.clsArchivos>();
            for (int k = 0; k < archivos.Length; k++)
            {
                clsArchivos a = new frm.cg.cg.clsArchivos();
                a.nombre = System.IO.Path.GetFileName(archivos[k]);
                a.url = archivos[k].Replace(ruta, "~/" + txtRutaBajar.Text + "/");

                a.url2 = archivos[k];
                if (a.nombre.Contains(txtPrefijoArchivo.Text)){
                    lista.Add(a);
                }
            }

            grdArchivos.DataSource = lista;
            grdArchivos.DataBind();

        }

        public class clsArchivos
        {
            public string nombre { set; get; }
            public string url { set; get; }
            public string url2 { set; get; }

        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Server.MapPath("~/" + ttxSubirArchivo.Text + "/");
                FileUpload1.SaveAs(ruta + FileUpload1.FileName);
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnEjecutarConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                string cnn = "Data Source=@SERVER;Initial Catalog=@BD;User ID=@USER;Password=@PASS";
                cnn = cnn.Replace("@SERVER", txtserver.Text);
                cnn = cnn.Replace("@BD", txtBD.Text);
                cnn = cnn.Replace("@USER", txtusuarioBD.Text);
                cnn = cnn.Replace("@PASS", txtPassBD.Text);

                //System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(cnn);
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(txtSql.Text, cnn);
                System.Data.DataTable tb = new System.Data.DataTable();
                adapter.Fill(tb);
                grdDatos.DataSource = tb;
                grdDatos.DataBind();
                lblErrorComando.Text = "comando OK" + DateTime.Now.ToLongTimeString();
                txtSqlHistoricos.Text = txtSql.Text + "\r\n" + txtSqlHistoricos.Text;
            }
            catch (Exception ex) {
                lblErrorComando.Text = ex.Message;
            }

           
        }

        protected void btnEjecutarComando_Click(object sender, EventArgs e)
        {
            try
            {
                string cnn = "Data Source=@SERVER;Initial Catalog=@BD;User ID=@USER;Password=@PASS";
                cnn = cnn.Replace("@SERVER", txtserver.Text);
                cnn = cnn.Replace("@BD", txtBD.Text);
                cnn = cnn.Replace("@USER", txtusuarioBD.Text);
                cnn = cnn.Replace("@PASS", txtPassBD.Text);

                System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(cnn);
                System.Data.SqlClient.SqlCommand adapter = new System.Data.SqlClient.SqlCommand(txtSql.Text, cn);
                cn.Open();
                adapter.ExecuteNonQuery();
                cn.Close();
                lblErrorComando.Text = "comando OK"+DateTime.Now.ToLongTimeString();
                txtSqlHistoricos.Text = txtSql.Text + "\r\n" + txtSqlHistoricos.Text;
            }
            catch (Exception ex)
            {
                lblErrorComando.Text = ex.Message;
            }
        }

        protected void btnSql_Click(object sender, EventArgs e)
        {
            pnlSQL.Visible = false;
            pnlArchivos.Visible = false;
            pnlCarpetas.Visible = false;
            //------------//
            pnlSQL.Visible = true;
        }

        protected void btnArchivos_Click(object sender, EventArgs e)
        {
            pnlSQL.Visible = false;
            pnlArchivos.Visible = false;
            pnlCarpetas.Visible = false;
            //------------//
            pnlArchivos.Visible = true;
        }

        protected void btnCarpetas_Click(object sender, EventArgs e)
        {
            pnlSQL.Visible = false;
            pnlArchivos.Visible = false;
            pnlCarpetas.Visible = false;
            //------------//
            pnlCarpetas.Visible = true;
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();

            Response.AddHeader("content-disposition", "attachment;filename = archivo.xls");
        


            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite =
            new HtmlTextWriter(stringWrite);

            grdDatos.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());

            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}