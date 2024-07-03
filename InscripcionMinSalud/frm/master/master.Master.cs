using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.master
{
	public partial class master : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            //Response.Redirect("~/aspx/Seguridad/frmLogin.aspx");
            //if (Session["SS_COD_REGISTRO"] == null || Session["SS_COD_REGISTRO"].ToString().Trim() == string.Empty)
            //{
            //    pnlOffline.Visible = true;
            //    pnlOnline.Visible = false;
            //}
            //else {
            //    pnlOnline.Visible = true;
            //    pnlOffline.Visible = false;
            //}
            //if (this.Page.Request.RawUrl.ToString().ToLower().Contains("default.aspx") == false)
            //{
            //    pnlOffline.Visible = false;
            //    pnlOnline.Visible = false;
            //}
            //if (Session["SS_NOMBRE"] != null)
            //{
            //    lblNombreUsuario.Text = Session["SS_NOMBRE"].ToString();
            //}
            if (Session["IdentificacionParticipante"] != null && Session["IdentificacionParticipante"].ToString().Trim() != string.Empty)
            {
                //lo obligamos a ir a frm migrar cuenta
                if (Request.Url.AbsoluteUri.ToLower().IndexOf("frmmigrarcuenta") <0) {
                    Response.Redirect("~/frm/registro/frmMigrarCuenta.aspx");
                }
            }
            else {

                //if (Session["SS_COD_REGISTRO"] == null || Session["SS_COD_REGISTRO"].ToString().Trim() == string.Empty)
                //{
                //    pnlLinkIniciarSesion.Visible = true;
                //    pnlLinkCerrarSesion.Visible = false;
                //    pnlCambiarPassword.Visible = false;
                //    lnkRegistrese.Visible = true;
                //    lnkEditarPerfil.Visible = false;
                //}
                //else {
                //    pnlLinkIniciarSesion.Visible = false;
                //    pnlLinkCerrarSesion.Visible = true;
                //    pnlCambiarPassword.Visible = true;
                //    lnkRegistrese.Visible = false;
                //    lnkEditarPerfil.Visible = true;
                //}
            }
		}
	}
}