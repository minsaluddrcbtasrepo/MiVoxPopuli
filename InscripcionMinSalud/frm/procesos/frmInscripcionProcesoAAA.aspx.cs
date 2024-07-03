using NegocioInscripcionMinSalud;
using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.procesos
{
    public partial class frmInscripcionProcesoAAA : System.Web.UI.Page
    {
        class archivos
        {
            public string descripcion { set; get; }
            public string url { set; get; }
        }

        private List<archivos> ArchivosCargados
        {
            get
            {
                if (Session["ArchivosCargadosN"] == null)
                {
                    Session["ArchivosCargadosN"] = new List<archivos>();
                }
                return (List<archivos>)Session["ArchivosCargadosN"];
            }
        }

        private bool ValidarArchivoCargado()
        {
            foreach (var archivoCargado in ArchivosCargados)
            {
                string nombreArchivo = System.IO.Path.GetFileName(archivoCargado.url);

                if (nombreArchivo.StartsWith("3-"))
                {
                    return true;
                }
            }
            return false;
        }


        protected void DescargarDocumentos()
        {
            string archivo = "";
            archivo = "3-" + Session["ticsfile"] + uploadDocumentoNatural.UploadedFiles[0].FileName;
            string pathArchivo = Server.MapPath("~/files/DocumentosHuerfanas");
            if (!System.IO.Directory.Exists(pathArchivo))
            {
                System.IO.Directory.CreateDirectory(pathArchivo);
            }
            pathArchivo = System.IO.Path.Combine(pathArchivo, archivo);
            uploadDocumentoNatural.UploadedFiles.First().SaveAs(pathArchivo);
            Session["archivoPuente"] = pathArchivo;
        }

        protected void uploadDocumentoNatural_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (uploadDocumentoNatural.UploadedFiles.Count() > 0)
            {
                DescargarDocumentos();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                lnkInicioPosible.NavigateUrl = lnkInicioPosible.NavigateUrl + "?page=" + Request.RawUrl.Replace("InscripcionParticipacionCiudadana", "").Replace("/", "@@").Replace("=", "**").Replace("&", "$$");
            }
            //      lblPaginaAnterior.Text = "~/" + Request.QueryString["page"].Replace("@@", "/").Replace("**", "=").Replace("$$", "");
            if (Session["SS_NOMBRE_USUARIO"] == null || Session["SS_NOMBRE_USUARIO"].ToString() == string.Empty)
            {
                btnGuardar.Visible = false;
                btnGuardarContinuar.Visible = false;
                posibleAclaracioes.Visible = true;
            }
            else
            {
                posibleAclaracioes.Visible = false;
            }



            if (Request.QueryString["codProceso"] == null || Request.QueryString["codProceso"].ToString().Trim() == string.Empty)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
            #region ocultamos paneles de validacion


            pnlValidacionConflicto.Visible = false;

           
            pnlValidacionEvidencia.Visible = false;
            #endregion
            bool editaAclaraciones = false;
            if (!IsPostBack)
            {
                lblTic.Text = DateTime.Now.Ticks.ToString().Substring(10);
                Session["ticsfile"] = lblTic.Text;
                Session["ArchivosCargadosN"] = null;

                int codR = 0;
                if (Session["SS_COD_REGISTRO"] != null) codR = int.Parse(Session["SS_COD_REGISTRO"].ToString());

                //cargamos la infomracion del registro
                clsNegocio obj = new clsNegocio();
                if (codR != 0)
                {
                    var reg = obj.obtenerRegistroxCodigo(codR);
                    #region ajustamos visibilidad de los paneles para la nominacion
                    if (reg.COD_TIPO_JURIDICO == 1 || reg.COD_TIPO_JURIDICO == 4 || reg.COD_TIPO_JURIDICO == 5 ||
                        reg.COD_TIPO_JURIDICO == 6 || reg.COD_TIPO_JURIDICO == 7 ||
                        reg.COD_TIPO_JURIDICO == 8 || reg.COD_TIPO_JURIDICO == 9 || reg.COD_TIPO_JURIDICO == 10 || reg.COD_TIPO_JURIDICO == 11 || reg.COD_TIPO_JURIDICO == 12 ||
                        reg.COD_TIPO_JURIDICO == 28 || reg.COD_TIPO_JURIDICO == 29 || reg.COD_TIPO_JURIDICO == 30 ||
                        reg.COD_TIPO_JURIDICO == 31 || reg.COD_TIPO_JURIDICO == 26 ||
                        reg.COD_TIPO_JURIDICO == 27 || reg.COD_TIPO_JURIDICO == 13 || reg.COD_TIPO_JURIDICO == 14 ||
                        reg.COD_TIPO_JURIDICO == 15 ||
                        reg.COD_TIPO_JURIDICO == 16 || reg.COD_TIPO_JURIDICO == 17 || reg.COD_TIPO_JURIDICO == 18 ||
                        reg.COD_TIPO_JURIDICO == 19 || reg.COD_TIPO_JURIDICO == 20 ||
                        reg.COD_TIPO_JURIDICO == 21 || reg.COD_TIPO_JURIDICO == 22 || reg.COD_TIPO_JURIDICO == 23 ||
                        reg.COD_TIPO_JURIDICO == 24 || reg.COD_TIPO_JURIDICO == 25
                        )
                    {
                        //   pnlMensajeNoNominador.Visible = false;
                        //   pnlFormulario.Visible = true;
                    }
                    else
                    {
                        //   pnlMensajeNoNominador.Visible = true;
                        //   pnlFormulario.Visible = false;
                    }
                    #endregion
                    #region ajustamos visibilidad de paneles de acuerdo al que va a nominar
                    if (reg.ES_PERSONA_NATURAL)
                    {

                        txtNombreNominador.Text = reg.NOMBRE.Trim() + " " + reg.APELLIDOS;
                        txtTipoAator.Text = "Persona natural";
                        txtIdentificacionNominador.Text = reg.DOCUMENTO;
                        txtEmailNominador.Text = reg.CORREO;
                    }
                    else
                    {

                        txtNombreNominador.Text = reg.NOMBRE.Trim();
                        txtTipoAator.Text = "Pesona Juridica";
                        txtIdentificacionNominador.Text = reg.DOCUMENTO;
                        txtEmailNominador.Text = reg.CORREO;
                    }
                    #endregion
                }


                if (Request.QueryString["codN"] != null && Request.QueryString["codN"] != string.Empty)
                {
                    lnkPDF.Visible = true;
                    lnkPDF.HRef = "../informes/frmReportViewer.aspx?cod=" + Request.QueryString["codN"];
                    var registro = obj.obtenerNOMINACION_PROCESO(int.Parse(Request.QueryString["codN"]));
                    pnlNominador.Visible = true;

                    foreach (var k in registro.ARCHIVOXNOMINACION)
                    {
                        archivos a = new archivos();
                        a.descripcion = k.DESCRIPCION_ARCHIVO;
                        a.url = k.URL_ARCHIVO;
                        ArchivosCargados.Add(a);
                    }

                    lblCodNominacionProceso.Text = registro.COD_NOMINACION_PROCESO.ToString();
                    txtNombreTecnologia.Text = registro.ID_MANUAL.Trim() + "-" + registro.NOMBRE_TECNOLOGIA;
                    txtConflicto.Text = registro.OBSERVACIONES_CONFLICTO;
                    //txtEnfermedad.Text = registro.NOMBRE_ENFERMEDAD_CONDICION_SALUD;
                    //txtEnfermedad2.Text = registro.OBSERVACION_TECNOLOGIA;

                    txtEvidencia.Text = registro.OBSERVACIONES_EVIDENCIA;

                    if (DateTime.Now > new DateTime(2019, 05, 25, 23, 59, 59))
                    {
                        btnObjetar.Visible = false;
                    }

             

                    if (
                        (Session["SS_COD_REGISTRO"] != null && registro.COD_REGISTRO.ToString() == Session["SS_COD_REGISTRO"].ToString())
                        &&
                        (registro.COD_ESTADO_NOMINACION == 1 || registro.COD_ESTADO_NOMINACION == 4)

                        )
                    {
                        //permite editar lo diligenciado, por defecto viene diligenciado.
                    }
                    else
                    {
                        #region los campos no se pueden modificar en este estado
                        txtConflicto.ReadOnly = true;
                        txtInteresEconomico.ReadOnly = true;

                        //txtEnfermedad.ReadOnly = true;
                        //txtEnfermedad2.ReadOnly = true;

                        txtNombreTecnologia.ReadOnly = true;

                        //chkAdjuntaEvidencia.Enabled = false;
                        //chkConflictoInteres.Enabled = false;
                        //  chkEsDispositivoMedico.Enabled = false;
                        // chkEsMedicamento.Enabled = false;
                        // chkEsOtro.Enabled = false;
                        // chkEsProcedimiento.Enabled = false;

                        //chkNoAdjuntaEvidencia.Enabled = false;
                        //chkNoConflictoInteres.Enabled = false;

                        btnGuardar.Visible = false;
                        btnGuardarContinuar.Visible = false;
                        btnArchivo.Visible = false;
                        #endregion
                    }

                    if (registro.COD_ESTADO_NOMINACION > 2 && Session["SS_COD_REGISTRO"] != null && (registro.COD_REGISTRO.ToString() == Session["SS_COD_REGISTRO"].ToString())
                        )
                    {
                        if (registro.COD_ESTADO_NOMINACION == 4)
                        { //siginifica que va  editar los campos 
                            btnGuardarContinuar.Visible = true;
                            txtConflicto.ReadOnly = false;

                            //txtEnfermedad.ReadOnly = false;
                            //txtEnfermedad2.ReadOnly = false;
                            txtEvidencia.ReadOnly = false;

                            txtNombreTecnologia.ReadOnly = false;


                        }

                  
                        pnlValidacionConflicto.Visible = true;


             
                        pnlValidacionEvidencia.Visible = true;
                     
                        var nominacion = obj.obtenerVALIDACION_PROCESO(registro.COD_NOMINACION_PROCESO);
                        var parametros = obj.obtenerPARAMETRO_VALIDACION();
                     
                        var valA = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 1).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valA != null)
                        {
                          
                        }

                        var valB = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 2 && x3.detalle.CONSECUTIVO == 1).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valB != null)
                        {
                          
                        }

                        var valB2 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 2 && x3.detalle.CONSECUTIVO == 2).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valB2 != null)
                        {
                           
                        }

                        var valB3 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 2 && x3.detalle.CONSECUTIVO == 3).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valB3 != null)
                        {
                            
                        }



                        var valG = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 7 && x3.detalle.CONSECUTIVO == 1).Select(x3 => x3.parametro).FirstOrDefault();

                        var valG5 = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 7 && x3.detalle.CONSECUTIVO == 5).Select(x3 => x3.parametro).FirstOrDefault();


                        var valH = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 8).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valH != null)
                        {
                            cmbGrupoEvidencia.SelectedValue = valH.COD_PARAMETRO_VALIDACION.ToString();
                            
                        }

                        var valK = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 9).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valK != null)
                        {
                            cmbGrupoConflicto.SelectedValue = valK.COD_PARAMETRO_VALIDACION.ToString();
                           
                        }
                        var valconcepto = nominacion.DETALLE_VALIDACION_PROCESO.Join(parametros, x => x.COD_PARAMETRO_VALIDACION, x2 => x2.COD_PARAMETRO_VALIDACION, (x, x2) => new { detalle = x, parametro = x2 })
                            .Where(x3 => x3.parametro.COD_GRUPO_PARAMETRO_VALIDACION == 10).Select(x3 => x3.parametro).FirstOrDefault();
                        if (valconcepto != null)
                        {
                          
                        }
                    }

                }
            }

            renderArchivos();
        }

        protected void btnGuardarContinuar_Click(object sender, EventArgs e)
        {
            guardar();
            if (validar())
            {
                enviar();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private bool validar()
        {
            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";
            opcionCambio.Attributes.Remove("border-color");
            opcionCambio.Attributes.CssStyle.Add("border-color", "#f3a740");
            if (!chkInnovacion.Checked && !chkEnfermedad.Checked && !chkFinanciero.Checked && !chkIncorporada.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Debe seleccionar la opción describe el cambio a nominar,  ";
                opcionCambio.Attributes.CssStyle.Add("border-color", "red");
            }
          
            #region nombre nominacion
            txtNombreTecnologia.CssClass = "";
            txtNombreTecnologia.Attributes.Remove("placeholder");
            if (String.IsNullOrEmpty(txtNombreTecnologia.Text.Trim()))
            {
                error = true;
                LblValidacionCampos.Text += "Nombre de la nominación, ";
                txtNombreTecnologia.Attributes.Add("placeholder", "Debe ingresar el nombre de la nomación ");
                txtNombreTecnologia.CssClass = "form-control errormin";
            }
            else
            {
                txtNombreTecnologia.CssClass = "form-control";
            }
            #endregion

            txtInteresEconomico.CssClass = "";
            txtInteresEconomico.Attributes.Remove("placeholder");
            if (String.IsNullOrEmpty(txtInteresEconomico.Text.Trim()))
            {
                error = true;
                LblValidacionCampos.Text += "Debe informar si tiene conflicto de intereses, ";
                txtInteresEconomico.Attributes.Add("placeholder", "Descripción del conflicto ");
                txtInteresEconomico.CssClass = "form-control errormin";
            }
            txtConflicto.CssClass = "";
            txtConflicto.Attributes.Remove("placeholder");
            if (String.IsNullOrEmpty(txtConflicto.Text.Trim()))
            {
                error = true;
                LblValidacionCampos.Text += "Debe informar si tiene conflicto de intereses, ";
                txtConflicto.Attributes.Add("placeholder", "Descripción del conflicto ");
                txtConflicto.CssClass = "form-control errormin";
            }

            return !error;

        }

        private void enviar()
        {
            clsNegocio cls = new clsNegocio();

            try
            {
                int id = int.Parse(lblCodNominacionProceso.Text);
            }
            catch
            {
                if (Request.QueryString["v"] == null || Session["SS_COD_REGISTRO"] == null)
                {
                    Response.Redirect("~/aspx/seguridad/frmLogin.aspx?page=aspx@@evento@@frmconfirmacionevento.aspx");
                    return;
                }
            }


            var obj = cls.obtenerNOMINACION_HUERFANA(int.Parse(lblCodNominacionProceso.Text));
            var proceso = cls.obtenerProceso(obj.COD_PROCESO);
            if (obj.COD_ESTADO_NOMINACION == 1)
            {
                string textoNuevo = "Queremos informarle que su nominación ha sido recibida";
                if (lblCodNominacionProceso.Text != string.Empty)
                {
                    textoNuevo = "Queremos informarle que los cambios de su nominación han sido recibidos";
                }
                cls.enviarNominacionExlcusiones(int.Parse(lblCodNominacionProceso.Text), 2);
                Session["msgtitulo"] = "Gracias por completar su nominación";
                Session["msgmsg"] = @"Muchas gracias por su participación en el  " + proceso.NOMBRE_PROCESO + @". " + textoNuevo + @"
                                    <br>
                                    <br>
                                    Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su nominación.
                                    <br>
                                    <br>
                                    ";

                clsWebUtils email = new clsWebUtils();
                string asunto = Session["msgtitulo"].ToString();

                string cuerpo = Session["msgmsg"].ToString();
                email.enviarEmail(asunto, cuerpo, Session["SS_CORREO"].ToString());

            }
            else
            {
                cls.enviarNominacionHuerfana(int.Parse(lblCodNominacionProceso.Text), 2);
                Session["msgtitulo"] = "Gracias por enviar su nominación ";
                //Session["msgmsg"] = @"Muchas gracias por su participación en el  " + proceso.NOMBRE_PROCESO + @" Queremos informarle que su nominación ha sido recibida.
                Session["msgmsg"] = @"Muchas gracias por su participación en la Actualización del listado oficial de las Enfermedades Huerfanas. Queremos informarle que su nominación ha sido recibida.
                        <br>
                        <br>
                        Le comunicaremos oportunamente cualquier tipo de novedad con respecto a su nominación.
                        <br>
                        <br>";

                clsWebUtils email = new clsWebUtils();
                string asunto = Session["msgtitulo"].ToString();

                string cuerpo = Session["msgmsg"].ToString();
                email.enviarEmailHuerfanas(asunto, cuerpo, Session["SS_CORREO"].ToString());
            }

            Response.Redirect("~/frm/logica/frmMensajeIframe.aspx");
        }

        private void guardar()
        {

            if (Session["SS_COD_REGISTRO"] == null)
            {
                Response.Redirect("~/aspx/seguridad/frmLogin.aspx");
                return;
            }

            int vigencia = 0;
            if (Request.QueryString["codN"] == null)
            {
                if (Request.QueryString["v"] == null || Session["SS_COD_REGISTRO"] == null)
                {
                    Response.Redirect("~/aspx/seguridad/frmLogin.aspx?page=aspx@@evento@@frmconfirmacionevento.aspx");
                    return;
                }
                else
                {
                    vigencia = int.Parse(Request.QueryString["v"]);
                }
            }


            clsNegocio cls = new clsNegocio();
            int? codN = null;
            if (lblCodNominacionProceso.Text.Trim() != string.Empty)
            {
                codN = int.Parse(lblCodNominacionProceso.Text);
            }
            List<ARCHIVOXNOMINACION_HUERFANA> lista = new List<ARCHIVOXNOMINACION_HUERFANA>();

            for (int k = 0; k < ArchivosCargados.Count; k++)
            {
                ARCHIVOXNOMINACION_HUERFANA ar = new ARCHIVOXNOMINACION_HUERFANA();
                ar.DESCRIPCION_ARCHIVO = ArchivosCargados[k].descripcion;
                ar.URL_ARCHIVO = ArchivosCargados[k].url;
                lista.Add(ar);
            }
         
            bool evidencia;
            bool conflictoIntereses;

           
            if (!String.IsNullOrEmpty(txtInteresEconomico.Text.Trim()) && !String.IsNullOrEmpty(txtConflicto.Text.Trim()))
            {

                if (txtInteresEconomico.Text.Trim().ToUpper() == "NINGUNO" && txtConflicto.Text.Trim().ToUpper() == "NINGUNO")
                {
                    conflictoIntereses = false;
                }
                else
                {
                    conflictoIntereses = true;
                }
            }
            else
            {

                conflictoIntereses = false;
            }

           

            LblValidacionCampos.Text = "La información ha sido guardada exitosamente.";

        }

        protected void btnArchivo_Click(object sender, EventArgs e)
        {
            Session["archivoPuente"] = null;
            popupNuevo.Show();
            txtDescripcionArchivo.Text = "";
            lblErrorDetalle.Text = "";
        }



        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {

            popupNuevo.Hide();
        }

        protected void btnAceptarDetalle_Click(object sender, EventArgs e)
        {
            if (txtDescripcionArchivo.Text == string.Empty)
            {
                lblErrorDetalle.Text = "Debe ingresar la descripción del archivo";
                return;
            }
            if ((Session["archivoPuente"] == null || Session["archivoPuente"].ToString() == string.Empty))
            {
                lblErrorDetalle.Text = "Debe adjuntar el archivo";
                return;
            }
            archivos ar = new archivos();
            ar.descripcion = txtDescripcionArchivo.Text;
            ar.url = Session["archivoPuente"].ToString();
            ArchivosCargados.Add(ar);

            popupNuevo.Hide();
            renderArchivos();
        }

        private void renderArchivos()
        {
            grdArchivos.DataSource = ArchivosCargados;
            grdArchivos.DataBind();
            pnlGrillaArchivos.Update();
        }

        protected void btnelimnarARchivo_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            for (int k = 0; k < ArchivosCargados.Count; k++)
            {
                if (ArchivosCargados[k].url == b.ValidationGroup)
                {
                    ArchivosCargados.RemoveAt(k);
                    break;
                }
            }
            renderArchivos();
        }

        protected void btnObjetar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmObjetarAAA.aspx?codN=" + Request.QueryString["codN"] + "&codProceso=" + Request.QueryString["codProceso"]);
        }
    }
}