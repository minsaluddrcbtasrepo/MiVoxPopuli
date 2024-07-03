using NegocioInscripcionMinSalud;
using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.registro
{
    public partial class frmEditarPerfil : System.Web.UI.Page
    {

        private List<string> ArchivosCargados
        {
            get
            {
                if (Session["ArchivosCargados"] == null)
                {
                    Session["ArchivosCargados"] = new List<string>();
                }
                return (List<string>)Session["ArchivosCargados"];
            }
        }

        public bool ValidarFormularioPassword()
        {
            //los combos de sde tipo de usuario y los combos de juridicos en cadena se validan en el formulario por javascrip
            //dado que no muestro el formulario si no ha selecionado

            bool error = false;
            LblValidacionCamposContrasena.Text = "";
            LblValidacionCamposContrasena.Text += "Verifique los Siguientes Campos: ";

            #region nombre entidad
            txtActual.CssClass = "";
            txtActual.Attributes.Remove("placeholder");
            if (txtActual.Text == "")
            {
                error = true;
                LblValidacionCamposContrasena.Text += "Contraseña actual, ";
                txtActual.Attributes.Add("placeholder", "Debe ingresar la contraseña actual ");
                txtActual.CssClass = "form-control errormin";
            }
            else
            {
                txtActual.CssClass = "form-control";
            }

            txtNueva.CssClass = "";
            txtNueva.Attributes.Remove("placeholder");
            if (txtNueva.Text == "")
            {
                error = true;
                LblValidacionCamposContrasena.Text += "Contraseña nueva, ";
                txtNueva.Attributes.Add("placeholder", "Debe ingresar la contraseña nueva ");
                txtNueva.CssClass = "form-control errormin";
            }
            else
            {
                txtNueva.CssClass = "form-control";
            }

            txtConfirmacion.CssClass = "";
            txtConfirmacion.Attributes.Remove("placeholder");
            if (txtActual.Text == "")
            {
                error = true;
                LblValidacionCamposContrasena.Text += "Contraseña de confirmación, ";
                txtConfirmacion.Attributes.Add("placeholder", "Debe ingresar la contraseña de confirmación ");
                txtConfirmacion.CssClass = "form-control errormin";
            }
            else
            {
                txtConfirmacion.CssClass = "form-control";
            }
            if (error)
            {
                return false;
            }

            if (txtNueva.Text != txtConfirmacion.Text)
            {
                error = true;
                txtConfirmacion.CssClass = "";
                txtConfirmacion.Attributes.Remove("placeholder");
                txtNueva.CssClass = "";
                txtNueva.Attributes.Remove("placeholder");

                LblValidacionCamposContrasena.Text += "Contraseña de confirmación, ";
                txtConfirmacion.Attributes.Add("placeholder", "La contraseña nueva y la contraseña de confirmación no son iguales.");
                txtConfirmacion.CssClass = "form-control errormin";
                txtNueva.Attributes.Add("placeholder", "La contraseña nueva y la contraseña de confirmación no son iguales.");
                txtNueva.CssClass = "form-control errormin";


                return false;
            }

            #endregion

            clsNegocio obj = new clsNegocio();
            var usuario = obj.obtenerRegistroxCodigo(int.Parse(Session["SS_COD_REGISTRO"].ToString()));
            if (usuario != null)
            {
                if (txtActual.Text.Trim() != usuario.CONTRASENA.Trim())
                {
                    txtActual.CssClass = "";
                    error = true;
                    txtActual.Attributes.Remove("placeholder");

                    LblValidacionCamposContrasena.Text += "Contraseña actual, ";
                    txtActual.Attributes.Add("placeholder", "La contraseña actual no es valida");
                    txtActual.CssClass = "form-control errormin";

                }
            }

            if (error)
            {
                return false;
            }


            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["ss_registro_FileUpload3_filename"] = null;
                Session["ss_registro_FileUpload3_filepath"] = null;

            }
            if (Session["ss_registro_FileUpload3_filepath"] != null && Session["ss_registro_FileUpload3_filepath"].ToString() != string.Empty)
            {
                lnkArchivo3.InnerText = Session["ss_registro_FileUpload3_filepath"].ToString();
                lnkArchivo3.HRef = Session["ss_registro_FileUpload3_filepath"].ToString();
            }
            clsNegocio obj = new clsNegocio();
            if (!IsPostBack)
            {
                lblTic.Text = DateTime.Now.Ticks.ToString().Substring(10);
                Session["ticsfile"] = lblTic.Text;

                if (Request.QueryString["token"] == null || Request.QueryString["token"] == string.Empty)
                {
                    //traemos el correo de la session
                    if (Session["SS_COD_REGISTRO"] != null && Session["SS_COD_REGISTRO"].ToString() != string.Empty)
                    {
                        pnlNoValido.Visible = false;
                        pnlValido.Visible = true;
                        var r = obj.obtenerRegistroxCodigo(int.Parse(Session["SS_COD_REGISTRO"].ToString()));
                        Session.Remove("ArchivosCargados");
                        CargarDatos(r);
                        if (cmbPerfil.SelectedValue.ToString() == "2")
                        {
                            txtDocumentoJuridico.ReadOnly = true;
                        }else {
                            txtNumeroDocumentoNatural.ReadOnly = true;
                        }
                        cmbPerfil.Enabled = false;
                        pnlObservacionesValidacion.Visible = false;
                        
                        txtUsuario.ReadOnly = true;
                    }
                    else {
                        #region zona donde la sesion no esta activa
                        lblTitulo.Text = "Error";
                        lblContenido.Text = "Llamado no valido de la pagina";
                        return;
                        #endregion
                    }
                }
                else {
                    string correo = Request.QueryString["token"];
                    var c = correo.ToCharArray();
                    correo = "";
                    for (int k = 0; k < c.Length; k++)
                    {
                        c[k] = (char)(c[k] - 4);
                        correo = correo + c[k];
                    }

                    if (correo.IndexOf("₨") > 0)
                    {
                        correo = correo.Split('₨')[0];
                    }

                    if (correo.IndexOf("|") > 0)
                    {
                        correo = correo.Split('|')[0];
                    }

                    var r = obj.obtenerRegistroxCorreValidar(correo);
                    if (r == null)
                    {
                        lblTitulo.Text = "Error";
                        lblContenido.Text = "Link de verificación no valido, no se encontro el correo a validar.";
                    }else {

                        if (r.COD_ESTADO_REGISTRO != 3)
                        {
                            lblTitulo.Text = "Error";
                            lblContenido.Text = "La cuenta de usuario ya se encuentra verificada.";
                        }
                        else {
                            pnlNoValido.Visible = false;
                            pnlValido.Visible = true;

                            cmbNivelFormacion.SelectedValue = "0";
                            cmbPoblacionEspecial.SelectedValue = "0";
                            Session.Remove("ArchivosCargados");
                            CargarDatos(r);

                        }
                    }
                }
            }
        }
        /// <summary>
        /// Carga los datos de un participante en los controles de la interfaz gráfica.
        /// </summary>
        /// <param name="participante">Objeto que contiene la información del participante a cargar.</param>
        public void CargarDatos(REGISTRO participante)
        {
            clsNegocio obj = new clsNegocio();
            txtObservacionesValidacion.Text = participante.SOLICITUD_ACLARACIONES;
            if (participante.ES_PERSONA_JURIDICA)
            {
                cmbPerfil.SelectedValue = "2";
                txtcorreoinstitucional.Text = participante.CORREO;
                txtUsuarioJuridico.Text = participante.NOMBRE_USUARIO;
                txtNombreEntidad.Text = participante.NOMBRE;
                txtNombreFacultad.Text = participante.FACULTAD;
                cmbTipoDocumentoHidden.Value = participante.COD_TIPO_IDENTIFICACION.ToString();
                string[] arr = participante.DOCUMENTO.Split('-');
                txtDocumentoJuridico.Text = arr[0];
                if (arr.Length > 1) txtDigitoVerificacion.Text = arr[1];
                else txtDigitoVerificacion.Text = participante.DIGITO_VERIFICACION;
                txtFechaActa.Text = participante.FECHA_ACTA;
                txtEspecialidad.Text = participante.ESPECIALIDAD;

                if (participante.COD_TIPO_IPS.HasValue)
                    cmbTipoIps.SelectedValue = participante.COD_TIPO_IPS.Value.ToString();

                cmbDepartamentoJuridico.SelectedValue = participante.Municipio.IdDepartamento.ToString();
                cmbMunicipioJuridico.SelectedValue = participante.COD_MUNICIPIO.ToString();

                txtdireccionJuridico.Text = participante.DIRECCION;
                cmbtipoZonaJuridico.SelectedValue = participante.COD_TIPO_ZONA.Value.ToString();

                if (participante.REPRESENTADOS.HasValue)
                {
                    txtNumeroRepresentante.Text = participante.REPRESENTADOS.Value.ToString();
                }
                if (participante.COD_TIPO_REPRESENTADO.HasValue)
                {
                    cmbtipoRepresentados.SelectedValue = participante.COD_TIPO_REPRESENTADO.Value.ToString();
                }

                if (participante.REPRESENTADOS.HasValue)
                {
                    cmbsubTipo.SelectedValue = "1";
                }
                txtTelefonoJuridico.Text = participante.TELEFONO;
                txtcorreoAlternoInstitucional.Text = participante.CORREO_ALTERNO;
                cmbPreguntaSecretaJuridica.SelectedValue = participante.COD_PREGUNTA_SECRETA.Value.ToString();
                txtRespuestaPreguntaJuridica.Text = participante.RESPUESTA_PREGUNTA_SECRETA;

                if(participante.RUTA_ARCHIVO != null)
                {
                    System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
                    string url = ar.GetValue("urllocal", typeof(string)).ToString();

                    if (participante.RUTA_ARCHIVO.Contains(url))
                    {
                        lnkArchivo3.HRef = participante.RUTA_ARCHIVO;
                    }
                    else
                    {
                        lnkArchivo3.HRef = url + "/" + participante.RUTA_ARCHIVO.Replace("~", "").Replace(@"\", @"/");
                    }
                }

                if (lnkArchivo3.HRef != string.Empty)
                {
                    lnkArchivo3.InnerHtml = "Archivo cargado";
                }

                string codTipo = participante.COD_TIPO_JURIDICO.Value.ToString();
                //siempre van a tener padre juridicos son 3 niveles
                var nivelmaximo = obj.obtenerTipoJuridico(participante.COD_TIPO_JURIDICO.Value);
                TIPO_JURIDICO nivel_dos = null;
                TIPO_JURIDICO nivel_tres = null;
                cmbsubTipo.DataBind();
                if (nivelmaximo.PADRE.HasValue)
                {
                    nivel_dos = obj.obtenerTipoJuridico(nivelmaximo.PADRE.Value);
                    if (nivel_dos.PADRE.HasValue)
                    {
                        nivel_tres = obj.obtenerTipoJuridico(nivel_dos.PADRE.Value);

                        cmbsubTipo.SelectedValue = nivel_tres.COD_TIPO_JURIDICO.ToString();

                        cmbTipoHidden.Value = nivel_dos.COD_TIPO_JURIDICO.ToString();
                        cmbTipoHiddenClient.Value = nivel_dos.COD_TIPO_JURIDICO.ToString();
                        cmbTipoUsuario.SelectedValue = nivel_dos.COD_TIPO_JURIDICO.ToString();
                        // cmbTipoHidden.Value = nivel_dos.COD_TIPO_JURIDICO.ToString();


                        cmbTipo.SelectedValue = nivelmaximo.COD_TIPO_JURIDICO.ToString();
                        cmbTipoDosHidden.Value = nivelmaximo.COD_TIPO_JURIDICO.ToString();

                    }
                    else {

                        cmbsubTipo.SelectedValue = nivel_dos.COD_TIPO_JURIDICO.ToString();



                        cmbTipoUsuario.SelectedValue = nivelmaximo.COD_TIPO_JURIDICO.ToString();
                        cmbTipoHidden.Value = nivelmaximo.COD_TIPO_JURIDICO.ToString();
                        cmbTipoHiddenClient.Value = nivelmaximo.COD_TIPO_JURIDICO.ToString();
                        cmbTipoDosHidden.Value = nivelmaximo.COD_TIPO_JURIDICO.ToString();
                        //cmbTipoHiddenClient.Value = participante.TIPO_JURIDICO.PADRE.Value.ToString();
                    }
                }


                var hijo = participante.REGISTRO1.FirstOrDefault();
                if(hijo != null)
                {
                    cmbTipoDocumentoRepresentante.SelectedValue = hijo.COD_TIPO_IDENTIFICACION.ToString();
                    txtNumeroDocumentoRepresentante.Text = hijo.DOCUMENTO;
                    txtNombresRepresentante.Text = hijo.NOMBRE;
                    txtApellidosRepresentante.Text = hijo.APELLIDOS;
                    cmbSexoRepresentante.SelectedValue = hijo.COD_SEXO.Value.ToString();
                    txtTelefonoRepresentante.Text = hijo.TELEFONO;
                    txtTelefonoCelularRepresentante.Text = hijo.CELULAR;
                    txtCorreoRepresentante.Text = hijo.CORREO;
                }
                
                chkCertifico.Checked = participante.CERTIFICO.Value;
                chkAutorizo.Checked = participante.AUTORIZO.Value;
                chkTerminosYCondiciones.Checked = participante.TERMINOS.Value;
            }
            else {//en teoria solo se validan personas juridicas
                cmbPerfil.SelectedValue = "1";
                cmbTipoDocumentoNatural.SelectedValue = participante.COD_TIPO_IDENTIFICACION.ToString();
                txtNumeroDocumentoNatural.Text = participante.DOCUMENTO;
                txtNombresNatural.Text = participante.NOMBRE;
                txtApellidosNatural.Text = participante.APELLIDOS;
                cmbSexo.SelectedValue = participante.COD_SEXO.ToString();
                cmbPoblacionEspecial.SelectedValue = participante.COD_POBLACION_ESPECIAL.ToString();

                dataPerfiles.DataBind();
                for (int k = 0; k < dataPerfiles.Items.Count; k++)
                {
                    CheckBox ch = (CheckBox) dataPerfiles.Items[k].FindControl("IdLabel");
                    if (participante.TipoUsuario.Where(x => x.Id == int.Parse(ch.ValidationGroup)).Count() > 0)
                    {
                        ch.Checked = true;
                    }
                }

                cmbNivelFormacion.SelectedValue = participante.COD_NIVEL_FORMACION.ToString();
                cmbDepartamentoNatural.SelectedValue = participante.Municipio.IdDepartamento.ToString();
                cmbMunicipioNatural.SelectedValue = participante.COD_MUNICIPIO.ToString();
                txtdireccionNatural.Text = participante.DIRECCION;
                cmbTipoZona.SelectedValue = participante.COD_TIPO_ZONA.ToString();
                txtTelefonoCelularNatural.Text = participante.CELULAR;
                txtCorreoNatural.Text = participante.CORREO;
                txtCorreoNaturalAlternativo.Text = participante.CORREO_ALTERNO;
                cmbPreguntaSecreta.SelectedValue = participante.COD_PREGUNTA_SECRETA.ToString();
                txtRespuestaPregunta.Text = participante.RESPUESTA_PREGUNTA_SECRETA;
                chkAutorizo.Checked = participante.AUTORIZO.Value;
                chkCertifico.Checked = participante.CERTIFICO.Value;
                chkTerminosYCondiciones.Checked = participante.TERMINOS.Value;
                txtUsuario.Text = participante.NOMBRE_USUARIO;

            }



        }

        public bool ValidarFormulario()
        {
            //los combos de sde tipo de usuario y los combos de juridicos en cadena se validan en el formulario por javascrip
            //dado que no muestro el formulario si no ha selecionado

            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";

            if (cmbPerfil.SelectedValue == "2")
            {
                if ((cmbTipoHiddenClient.Value == "8" || cmbTipoHiddenClient.Value == "9" ||
                    cmbTipoHiddenClient.Value == "10" || cmbTipoHiddenClient.Value == "12")
                    && cmbTipoDosHidden.Value == "")
                {
                    #region tipo de documento juridico
                    error = true;
                    LblValidacionCampos.Text += "Tipo de usuario, ";
                    cmbTipo.Attributes.Add("placeholder", "Debe seleccionar un tipo de usuario");
                    cmbTipo.CssClass = "form-control errormin";

                    #endregion
                }


                #region nombre entidad
                txtNombreEntidad.CssClass = "";
                txtNombreEntidad.Attributes.Remove("placeholder");
                if (txtNombreEntidad.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Nombre, ";
                    txtNombreEntidad.Attributes.Add("placeholder", "Debe ingresar el nombre de la entidad ");
                    txtNombreEntidad.CssClass = "form-control errormin";
                }
                else
                {
                    txtNombreEntidad.CssClass = "form-control";
                }
                #endregion
                #region nombre facultad 
                if (cmbTipoHiddenClient.Value == "32")
                {
                    txtNombreFacultad.CssClass = "";
                    txtNombreFacultad.Attributes.Remove("placeholder");
                    if (txtNombreFacultad.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "nombre facultad, ";
                        txtNombreFacultad.Attributes.Add("placeholder", "Debe ingresar el nombre de la facultad ");
                        txtNombreFacultad.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtNombreFacultad.CssClass = "form-control";
                    }
                }
                #endregion
                #region tipo de documento juridico
                cmbtipodocumentoentidad.CssClass = "";
                cmbtipodocumentoentidad.Attributes.Remove("placeholder");

                if (cmbTipoDocumentoHidden.Value == null ||
                    cmbTipoDocumentoHidden.Value == "" ||
                    cmbTipoDocumentoHidden.Value == "-1" ||
                    cmbTipoDocumentoHidden.Value == "0" || cmbTipoDocumentoHidden.Value == "8")
                {
                    error = true;
                    LblValidacionCampos.Text += "Tipo documento, ";
                    cmbtipodocumentoentidad.Attributes.Add("placeholder", "Debe seleccionar un tipo de documento");
                    cmbtipodocumentoentidad.CssClass = "form-control errormin";
                }
                else
                {
                    cmbtipodocumentoentidad.CssClass = "form-control";
                }
                #endregion
                #region documento juridico
                txtDocumentoJuridico.CssClass = "";
                txtDocumentoJuridico.Attributes.Remove("placeholder");
                if (txtDocumentoJuridico.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Número de identificación, ";
                    txtDocumentoJuridico.Attributes.Add("placeholder", "Debe ingresar el número de documento");
                    txtDocumentoJuridico.CssClass = "form-control errormin";
                }
                else
                {
                    txtDocumentoJuridico.CssClass = "form-control";
                }
                #endregion
                #region digito de verificacion
                if (cmbTipoDocumentoHidden.Value == "9" || cmbTipoDocumentoHidden.Value == "10"
                    || cmbTipoDocumentoHidden.Value == "11")
                {
                    txtDigitoVerificacion.CssClass = "";
                    if (txtDigitoVerificacion.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "dígito de verificación, ";
                        txtDigitoVerificacion.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtDigitoVerificacion.CssClass = "form-control";
                    }
                }
                #endregion
                #region fecha acta
                if (cmbTipoDocumentoHidden.Value == "12")
                {
                    txtFechaActa.CssClass = "";
                    txtFechaActa.Attributes.Remove("placeholder");
                    if (txtFechaActa.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Fecha acta, ";
                        txtFechaActa.Attributes.Add("placeholder", "Debe ingresar la Fecha del acta");
                        txtFechaActa.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtFechaActa.CssClass = "form-control";
                    }
                }
                #endregion
                #region especialidad
                if (cmbTipoHiddenClient.Value == "8")
                {
                    txtEspecialidad.CssClass = "";
                    txtEspecialidad.Attributes.Remove("placeholder");
                    if (txtEspecialidad.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Especialidad, ";
                        txtEspecialidad.Attributes.Add("placeholder", "Debe ingresar la Especialidad");
                        txtEspecialidad.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtEspecialidad.CssClass = "form-control";
                    }
                }
                #endregion
                #region tipo de ips
                if (cmbTipoHiddenClient.Value == "35")
                {
                    cmbTipoIps.Attributes.Remove("placeholder");
                    if (cmbTipoIps.SelectedValue == "-1")
                    {
                        error = true;
                        LblValidacionCampos.Text += "tipo de ips, ";
                        cmbTipoIps.Attributes.Add("placeholder", "Debe seleccionar un tipo de ips");

                        cmbTipoIps.CssClass = "form-control errormin";
                    }
                    else
                    {
                        cmbTipoIps.CssClass = "form-control";
                    }
                }
                #endregion
                #region departamento municipio

                cmbDepartamentoJuridico.Attributes.Remove("placeholder");
                if (cmbDepartamentoJuridico.SelectedValue == "0")
                {
                    error = true;
                    LblValidacionCampos.Text += "Departamento, ";
                    cmbDepartamentoJuridico.Attributes.Add("placeholder", "Debe seleccionar un departamento");
                    cmbDepartamentoJuridico.CssClass = "form-control errormin";
                }
                else
                {
                    cmbDepartamentoJuridico.CssClass = "form-control";
                }

                cmbMunicipioJuridico.CssClass = "";
                cmbMunicipioJuridico.Attributes.Remove("placeholder");
                if (cmbMunicipioJuridico.SelectedValue == "0")
                {
                    error = true;
                    LblValidacionCampos.Text += "Municipio, ";
                    cmbMunicipioJuridico.Attributes.Add("placeholder", "Debe seleccionar un municipio");
                    cmbMunicipioJuridico.CssClass = "form-control errormin";
                }
                else
                {
                    cmbMunicipioJuridico.CssClass = "form-control";
                }
                #endregion
                #region direccion juridico
                txtdireccionJuridico.CssClass = "";
                txtdireccionJuridico.Attributes.Remove("placeholder");
                if (txtdireccionJuridico.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Dirección, ";
                    txtdireccionJuridico.Attributes.Add("placeholder", "Debe ingresar la Dirección");
                    txtdireccionJuridico.CssClass = "form-control errormin";
                }
                else
                {
                    txtdireccionJuridico.CssClass = "form-control";
                }
                #endregion
                #region tipo de zona
                cmbtipoZonaJuridico.CssClass = "";
                if (cmbtipoZonaJuridico.SelectedValue == "0")
                {
                    error = true;
                    LblValidacionCampos.Text += "tipo de zona, ";
                    cmbtipoZonaJuridico.Attributes.Add("placeholder", "Debe seleccionar tipo de zona");
                    cmbtipoZonaJuridico.CssClass = "form-control errormin";
                }
                else
                {
                    cmbtipoZonaJuridico.CssClass = "form-control";
                }
                #endregion
                #region numero de representante
                if (cmbsubTipo.SelectedValue == "1")
                {
                    txtNumeroRepresentante.CssClass = "";
                    txtNumeroRepresentante.Attributes.Remove("placeholder");
                    if (txtNumeroRepresentante.Text == "")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Número de asociados o agremiados, ";
                        txtNumeroRepresentante.Attributes.Add("placeholder", "Debe ingresar Número de asociados o agremiados");
                        txtNumeroRepresentante.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtNumeroRepresentante.CssClass = "form-control";
                    }

                    #region tipo de documento natural
                    cmbtipoRepresentados.CssClass = "";
                    cmbtipoRepresentados.Attributes.Remove("placeholder");
                    if (cmbtipoRepresentados.SelectedValue == "8")
                    {
                        error = true;
                        LblValidacionCampos.Text += "Tipo de asociados o agremiados, ";
                        cmbtipoRepresentados.Attributes.Add("placeholder", "Debe seleccionar un tipo de asociados o agremiados");
                        cmbtipoRepresentados.CssClass = "form-control errormin";
                    }
                    else {
                        cmbtipoRepresentados.CssClass = "form-control";
                    }
                    #endregion
                }
                #endregion
                #region telefono juridico
                txtTelefonoJuridico.CssClass = "";
                txtTelefonoJuridico.Attributes.Remove("placeholder");
                if (txtTelefonoJuridico.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Teléfono fijo, ";
                    txtTelefonoJuridico.Attributes.Add("placeholder", "Debe ingresar Teléfono fijo");
                    txtTelefonoJuridico.CssClass = "form-control errormin";
                }
                else {
                    txtTelefonoJuridico.CssClass = "form-control";
                }
                #endregion
                #region correo juridico
                txtcorreoinstitucional.CssClass = "";
                txtcorreoinstitucional.Attributes.Remove("placeholder");
                if (txtcorreoinstitucional.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "E-mail, ";
                    txtcorreoinstitucional.Attributes.Add("placeholder", "Debe ingresar la dirección correo");
                    txtcorreoinstitucional.CssClass = "form-control errormin";
                }
                else
                {
                    if (!txtcorreoinstitucional.Text.Contains("@") || !txtcorreoinstitucional.Text.Contains("."))
                    {
                        error = true;
                        LblValidacionCampos.Text += "Correo electrónico, ";
                        txtcorreoinstitucional.Attributes.Add("placeholder", "Dirección correo electrónico NO valida");
                        txtcorreoinstitucional.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtcorreoinstitucional.CssClass = "form-control";
                    }
                }
                #endregion
                #region correo juridico alternativo
                txtcorreoAlternoInstitucional.CssClass = "form-control";
                txtcorreoAlternoInstitucional.Attributes.Remove("placeholder");
                if (txtcorreoAlternoInstitucional.Text != "")
                {
                    if (!txtcorreoAlternoInstitucional.Text.Contains("@") || !txtcorreoAlternoInstitucional.Text.Contains("."))
                    {
                        error = true;
                        LblValidacionCampos.Text += "Correo electrónico alternativo, ";
                        txtcorreoAlternoInstitucional.Attributes.Add("placeholder", "Dirección correo electrónico alternativo NO valida");
                        txtcorreoAlternoInstitucional.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtcorreoAlternoInstitucional.CssClass = "form-control";
                    }
                }
                #endregion

                #region usuario
                txtUsuarioJuridico.CssClass = "";
                txtUsuarioJuridico.Attributes.Remove("placeholder");
                if (txtUsuarioJuridico.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Usuario, ";
                    txtUsuarioJuridico.Attributes.Add("placeholder", "Debe ingresar el Usuario");
                    txtUsuarioJuridico.CssClass = "form-control errormin";
                }
                else
                {
                    if (txtUsuarioJuridico.Text.Contains(" "))
                    {
                        error = true;
                        LblValidacionCampos.Text += "Usuario, ";
                        txtUsuarioJuridico.Attributes.Add("placeholder", "El Usuario no puede contener espacios");
                        txtUsuarioJuridico.CssClass = "form-control errormin";
                    }
                    else {
                        txtUsuarioJuridico.CssClass = "form-control";
                    }
                }
                #endregion

                #region pregunta secreta juridica
                cmbPreguntaSecretaJuridica.CssClass = "";
                cmbPreguntaSecretaJuridica.Attributes.Remove("placeholder");
                if (cmbPreguntaSecretaJuridica.SelectedValue == "-1")
                {
                    error = true;
                    LblValidacionCampos.Text += "Pregunta secreta, ";
                    cmbPreguntaSecretaJuridica.Attributes.Add("placeholder", "Seleccione la pregunta secreta");
                    cmbPreguntaSecretaJuridica.CssClass = "form-control errormin";
                }
                else
                {
                    cmbPreguntaSecretaJuridica.CssClass = "form-control";
                }

                txtRespuestaPreguntaJuridica.CssClass = "";
                txtRespuestaPreguntaJuridica.Attributes.Remove("placeholder");
                if (txtRespuestaPreguntaJuridica.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Respuesta a su pregunta, ";
                    txtRespuestaPreguntaJuridica.Attributes.Add("placeholder", "Ingrese la respuesta a su pregunta secreta");
                    txtRespuestaPreguntaJuridica.CssClass = "form-control errormin";
                }
                else
                {
                    txtRespuestaPreguntaJuridica.CssClass = "form-control";
                }
                #endregion
                //pendiente lo del archivo
                pnlArchivoJuridico1.Attributes["class"] = "";

                if (lnkArchivo3.HRef == string.Empty)
                {
                    error = true;
                    LblValidacionCampos.Text += "Archivo documento, ";
                    pnlArchivoJuridico1.Attributes["class"] = "errormin";

                }

                #region informacion del representante legal
                #region tipo de documento 
                cmbTipoDocumentoRepresentante.CssClass = "";
                cmbTipoDocumentoRepresentante.Attributes.Remove("placeholder");
                if (cmbTipoDocumentoRepresentante.SelectedValue == "8")
                {
                    error = true;
                    LblValidacionCampos.Text += "Tipo documento, ";
                    cmbTipoDocumentoRepresentante.Attributes.Add("placeholder", "Debe seleccionar un tipo de documento");
                    cmbTipoDocumentoRepresentante.CssClass = "form-control errormin";
                }
                else {
                    cmbTipoDocumentoRepresentante.CssClass = "form-control";
                }
                #endregion
                #region numero de documento natural
                txtNumeroDocumentoRepresentante.CssClass = "";
                txtNumeroDocumentoRepresentante.Attributes.Remove("placeholder");
                if (txtNumeroDocumentoRepresentante.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Número de identificación, ";
                    txtNumeroDocumentoRepresentante.Attributes.Add("placeholder", "Debe ingresar el número de documento");
                    txtNumeroDocumentoRepresentante.CssClass = "form-control errormin";
                }
                else
                {
                    txtNumeroDocumentoRepresentante.CssClass = "form-control";
                }
                #endregion
                #region nombres natural
                txtNombresRepresentante.CssClass = "";
                txtNombresRepresentante.Attributes.Remove("placeholder");
                if (txtNombresRepresentante.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Nombre, ";
                    txtNombresRepresentante.Attributes.Add("placeholder", "Debe ingresar el nombre");
                    txtNombresRepresentante.CssClass = "form-control errormin";
                }
                else
                {
                    txtNombresRepresentante.CssClass = "form-control";
                }
                #endregion
                #region apellidos natural
                txtApellidosRepresentante.CssClass = "";
                txtApellidosRepresentante.Attributes.Remove("placeholder");
                if (txtApellidosRepresentante.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Nombre, ";
                    txtApellidosRepresentante.Attributes.Add("placeholder", "Debe ingresar el apellido");
                    txtApellidosRepresentante.CssClass = "form-control errormin";
                }
                else
                {
                    txtApellidosRepresentante.CssClass = "form-control";
                }
                #endregion
                #region sexo
                cmbSexoRepresentante.CssClass = "";
                cmbSexoRepresentante.Attributes.Remove("placeholder");
                if (cmbSexoRepresentante.SelectedValue == "-1")
                {
                    error = true;
                    LblValidacionCampos.Text += "Sexo, ";
                    cmbSexoRepresentante.Attributes.Add("placeholder", "Debe seleccionar el sexo");
                    cmbSexoRepresentante.CssClass = "form-control errormin";
                }
                else
                {
                    cmbSexoRepresentante.CssClass = "form-control";
                }
                #endregion
                #region correo 
                txtCorreoRepresentante.CssClass = "";
                txtCorreoRepresentante.Attributes.Remove("placeholder");
                if (txtCorreoRepresentante.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "E-mail, ";
                    txtCorreoRepresentante.Attributes.Add("placeholder", "Debe ingresar la dirección correo");
                    txtCorreoRepresentante.CssClass = "form-control errormin";
                }
                else
                {
                    if (!txtCorreoRepresentante.Text.Contains("@") || !txtCorreoRepresentante.Text.Contains("."))
                    {
                        error = true;
                        LblValidacionCampos.Text += "Correo electrónico, ";
                        txtCorreoRepresentante.Attributes.Add("placeholder", "Dirección correo electrónico NO valida");
                        txtCorreoRepresentante.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtCorreoRepresentante.CssClass = "form-control";
                    }
                }
                #endregion



                #endregion

            }
            else {
                //zona de persona natural
                #region tipo de documento natural
                cmbTipoDocumentoNatural.CssClass = "";
                cmbTipoDocumentoNatural.Attributes.Remove("placeholder");
                if (cmbTipoDocumentoNatural.SelectedValue == "8")
                {
                    error = true;
                    LblValidacionCampos.Text += "Tipo documento, ";
                    cmbTipoDocumentoNatural.Attributes.Add("placeholder", "Debe seleccionar un tipo de documento");
                    cmbTipoDocumentoNatural.CssClass = "form-control errormin";
                }
                else {
                    cmbTipoDocumentoNatural.CssClass = "form-control";
                }
                #endregion
                #region numero de documento natural
                txtNumeroDocumentoNatural.CssClass = "";
                txtNumeroDocumentoNatural.Attributes.Remove("placeholder");
                if (txtNumeroDocumentoNatural.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Número de identificación, ";
                    txtNumeroDocumentoNatural.Attributes.Add("placeholder", "Debe ingresar el número de documento");
                    txtNumeroDocumentoNatural.CssClass = "form-control errormin";
                }
                else
                {
                    txtNumeroDocumentoNatural.CssClass = "form-control";
                }
                #endregion
                #region nombres natural
                txtNombresNatural.CssClass = "";
                txtNombresNatural.Attributes.Remove("placeholder");
                if (txtNombresNatural.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Nombre, ";
                    txtNombresNatural.Attributes.Add("placeholder", "Debe ingresar el nombre");
                    txtNombresNatural.CssClass = "form-control errormin";
                }
                else
                {
                    txtNombresNatural.CssClass = "form-control";
                }
                #endregion
                #region apellidos natural
                txtApellidosNatural.CssClass = "";
                txtApellidosNatural.Attributes.Remove("placeholder");
                if (txtApellidosNatural.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Apellido, ";
                    txtApellidosNatural.Attributes.Add("placeholder", "Debe ingresar el apellido");
                    txtApellidosNatural.CssClass = "form-control errormin";
                }
                else
                {
                    txtApellidosNatural.CssClass = "form-control";
                }
                #endregion
                #region sexo
                cmbSexo.CssClass = "";
                cmbSexo.Attributes.Remove("placeholder");
                if (cmbSexo.SelectedValue == "-1")
                {
                    error = true;
                    LblValidacionCampos.Text += "Sexo, ";
                    cmbSexo.Attributes.Add("placeholder", "Debe seleccionar el sexo");
                    cmbSexo.CssClass = "form-control errormin";
                }
                else
                {
                    cmbSexo.CssClass = "form-control";
                }
                #endregion
                #region poblacion especial
                cmbPoblacionEspecial.CssClass = "";
                if (cmbPoblacionEspecial.SelectedValue == "0")
                {
                    error = true;
                    LblValidacionCampos.Text += "Población Especial, ";
                    cmbPoblacionEspecial.CssClass = "form-control errormin";
                }
                else
                {
                    cmbPoblacionEspecial.CssClass = "form-control";
                }
                #endregion
                #region ultimo nivel de formacion
                cmbNivelFormacion.CssClass = "";
                if (cmbNivelFormacion.SelectedValue == "0")
                {
                    error = true;
                    LblValidacionCampos.Text += "Nivel Formación, ";
                    cmbNivelFormacion.CssClass = "form-control errormin";
                }
                else
                {
                    cmbNivelFormacion.CssClass = "form-control";
                }
                #endregion
                #region departamento municipio natural
                cmbDepartamentoNatural.Attributes.Remove("placeholder");
                if (cmbDepartamentoNatural.SelectedValue == "0")
                {
                    error = true;
                    LblValidacionCampos.Text += "Departamento, ";
                    cmbDepartamentoNatural.Attributes.Add("placeholder", "Debe seleccionar un departamento");
                    cmbDepartamentoNatural.CssClass = "form-control errormin";
                }
                else
                {
                    cmbDepartamentoNatural.CssClass = "form-control";
                }

                cmbMunicipioNatural.CssClass = "";
                cmbMunicipioNatural.Attributes.Remove("placeholder");
                if (cmbMunicipioNatural.SelectedValue == "0")
                {
                    error = true;
                    LblValidacionCampos.Text += "Municipio, ";
                    cmbMunicipioNatural.Attributes.Add("placeholder", "Debe seleccionar un municipio");
                    cmbMunicipioNatural.CssClass = "form-control errormin";
                }
                else
                {
                    cmbMunicipioNatural.CssClass = "form-control";
                }
                #endregion
                #region direccion natural
                txtdireccionNatural.CssClass = "";
                txtdireccionNatural.Attributes.Remove("placeholder");
                if (txtdireccionNatural.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Dirección, ";
                    txtdireccionNatural.Attributes.Add("placeholder", "Debe ingresar la Dirección");
                    txtdireccionNatural.CssClass = "form-control errormin";
                }
                else
                {
                    txtdireccionNatural.CssClass = "form-control";
                }
                #endregion
                #region tipo de zona
                cmbTipoZona.CssClass = "";
                cmbTipoZona.Attributes.Remove("placeholder");
                if (cmbTipoZona.SelectedValue == "0" || cmbTipoZona.SelectedValue == "8")
                {
                    error = true;
                    LblValidacionCampos.Text += "Tipo  de zona, ";
                    cmbTipoZona.Attributes.Add("placeholder", "Tipo de zona,");
                    cmbTipoZona.CssClass = "form-control errormin";
                }
                else {
                    cmbTipoZona.CssClass = "form-control";
                }
                #endregion
                #region correo natural
                txtCorreoNatural.CssClass = "";
                txtCorreoNatural.Attributes.Remove("placeholder");
                if (txtCorreoNatural.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "E-mail, ";
                    txtCorreoNatural.Attributes.Add("placeholder", "Debe ingresar la dirección correo");
                    txtCorreoNatural.CssClass = "form-control errormin";
                }
                else
                {
                    if (!txtCorreoNatural.Text.Contains("@") || !txtCorreoNatural.Text.Contains("."))
                    {
                        error = true;
                        LblValidacionCampos.Text += "Correo electrónico, ";
                        txtCorreoNatural.Attributes.Add("placeholder", "Dirección correo electrónico NO valida");
                        txtCorreoNatural.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtCorreoNatural.CssClass = "form-control";
                    }
                }
                #endregion
                #region correo natural alternativo
                txtCorreoNaturalAlternativo.CssClass = "form-control";
                txtCorreoNaturalAlternativo.Attributes.Remove("placeholder");
                if (txtCorreoNaturalAlternativo.Text != "")
                {
                    if (!txtCorreoNaturalAlternativo.Text.Contains("@") || !txtCorreoNaturalAlternativo.Text.Contains("."))
                    {
                        error = true;
                        LblValidacionCampos.Text += "Correo electrónico alternativo, ";
                        txtCorreoNaturalAlternativo.Attributes.Add("placeholder", "Dirección correo electrónico alternativo NO valida");
                        txtCorreoNaturalAlternativo.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtCorreoNaturalAlternativo.CssClass = "form-control";
                    }
                }
                #endregion


                #region usuario
                txtUsuario.CssClass = "";
                txtUsuario.Attributes.Remove("placeholder");
                if (txtUsuario.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Usuario, ";
                    txtUsuario.Attributes.Add("placeholder", "Debe ingresar el Usuario");
                    txtUsuario.CssClass = "form-control errormin";
                }
                else
                {
                    txtUsuario.CssClass = "form-control";
                }
                #endregion


                #region pregunta secreta
                cmbPreguntaSecreta.CssClass = "";
                cmbPreguntaSecreta.Attributes.Remove("placeholder");
                if (cmbPreguntaSecreta.SelectedValue == "-1")
                {
                    error = true;
                    LblValidacionCampos.Text += "Pregunta secreta, ";
                    cmbPreguntaSecreta.Attributes.Add("placeholder", "Seleccione la pregunta secreta");
                    cmbPreguntaSecreta.CssClass = "form-control errormin";
                }
                else
                {
                    cmbPreguntaSecreta.CssClass = "form-control";
                }

                txtRespuestaPregunta.CssClass = "";
                txtRespuestaPregunta.Attributes.Remove("placeholder");
                if (txtRespuestaPregunta.Text == "")
                {
                    error = true;
                    LblValidacionCampos.Text += "Respuesta a su pregunta, ";
                    txtRespuestaPregunta.Attributes.Add("placeholder", "Ingrese la respuesta a su pregunta secreta");
                    txtRespuestaPregunta.CssClass = "form-control errormin";
                }
                else
                {
                    txtRespuestaPregunta.CssClass = "form-control";
                }
                #endregion
            }
            #region validamos los check
            chkCertifico.CssClass = "";
            chkCertifico.Attributes.Remove("placeholder");
            if (!this.chkCertifico.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Certificación de autenticidad de datos , ";
                chkCertifico.Attributes.Add("placeholder", "Debe certificar sus datos");
                chkCertifico.CssClass = "checkbox errormin";
                chkCertifico.BorderColor = Color.Red;
            }
            else
            {
                chkCertifico.Attributes.Add("class", "checkbox");
                chkCertifico.BorderColor = System.Drawing.SystemColors.Control;
            }

            chkTerminosYCondiciones.CssClass = "";
            chkTerminosYCondiciones.Attributes.Remove("placeholder");
            if (!this.chkTerminosYCondiciones.Checked)
            {
                error = true;
                LblValidacionCampos.Text += "Terminos y condiciones , ";
                chkTerminosYCondiciones.Attributes.Add("placeholder", "Debe aceptar los terminos y condiciones");
                chkTerminosYCondiciones.CssClass = "checkbox errormin";
                chkTerminosYCondiciones.BorderColor = Color.Red;
            }
            else
            {
                chkTerminosYCondiciones.Attributes.Add("class", "checkbox");
                chkTerminosYCondiciones.BorderColor = System.Drawing.SystemColors.Control;
            }
            #endregion

            if (error)
            {
                return false;
            }
            if (btnRegistrar.Text == "Actualizar")
            {
                return true;
            }

            return true;
        }

        protected void btnRegistrarPassword_Click(object sender, EventArgs e)
        {

            if (ValidarFormularioPassword())
            {
                //guaradmos el registro en la base de datos

                clsNegocio obj = new clsNegocio();
                LblValidacionCamposContrasena.Text = "Contraseña actualizada satisfactoriamente.";
                obj.actualizarContrasena(int.Parse(Session["SS_COD_REGISTRO"].ToString()), txtNueva.Text);

            }
        }
        /// <summary>
        /// Envía un correo electrónico de confirmación de actualización de registro a la dirección proporcionada.
        /// </summary>
        /// <param name="correo">La dirección de correo electrónico a la que se enviará el mensaje de confirmación.</param>
        private void enviarEmailInscripcion(string correo)
        {
            clsWebUtils email = new clsWebUtils();
            System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
            string url = ar.GetValue("urllocal", typeof(string)).ToString();
            string asunto = "Actualización de registro a Mi VOX Pópuli del Ministerio de Salud y Protección Social";
            //enmascaramos el correo
            var c = correo.ToCharArray();
            string cr = "";
            for (int k = 0; k < c.Length; k++)
            {
                c[k] = (char)(c[k] + 4);
                cr = cr + c[k];
            }

            string cuerpo = @"";


            if (Session["SS_COD_REGISTRO"] != null && Session["SS_COD_REGISTRO"].ToString() != string.Empty)
            {
                cuerpo = @"Muchas gracias por actualizar su registro Mi Vox-Populi del Ministerio de Salud y Protección Social.<br>
               Su registro fue actualizado satisfactoriamente.";
            }
            else {
                cuerpo = @"Muchas gracias por actualizar su registro Mi Vox-Populi del Ministerio de Salud y Protección Social.<br>
               Su registro fue actualizado satisfactoriamente.<br>En un plazo máximo de <b>8 días</b> se le enviará una respuesta a su solicitud a la dirección de correo electrónico registrado.";
            }

                email.enviarEmail(asunto, cuerpo, correo);

        }
        /// <summary>
        /// Maneja el evento de clic en el botón "Registrar". Realiza la validación del formulario
        /// y guarda o actualiza el registro en la base de datos según corresponda.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                //guaradmos el registro en la base de datos
                string correo = "";
                clsNegocio obj = new clsNegocio();
                REGISTRO registro = null;
                REGISTRO registroHijo = null;

                if (cmbPerfil.SelectedValue == "1")
                {
                    registro = obj.obtenerRegistroxUsuario(txtUsuario.Text);
                    registroHijo = obj.obtenerRegistroxhijo(registro.COD_REGISTRO);
                    #region carga los datos de persona natural
                    correo = txtCorreoNatural.Text;
                    registro.APELLIDOS = txtApellidosNatural.Text;   //ok
                    registro.AUTORIZO = chkAutorizo.Checked;//ok
                    registro.CELULAR = txtTelefonoCelularNatural.Text;//ok
                    registro.CERTIFICO = chkCertifico.Checked;//ok                  
                    registro.COD_MUNICIPIO = short.Parse(cmbMunicipioNatural.SelectedValue);//ok
                    registro.COD_NIVEL_FORMACION = int.Parse(cmbNivelFormacion.SelectedValue);//ok
                    registro.COD_POBLACION_ESPECIAL = int.Parse(cmbPoblacionEspecial.SelectedValue);//ok
                    registro.COD_PREGUNTA_SECRETA = short.Parse(cmbPreguntaSecreta.SelectedValue);//ok
                    registro.COD_SEXO = int.Parse(cmbSexo.SelectedValue); //ok
                    registro.COD_TIPO_IDENTIFICACION = short.Parse(cmbTipoDocumentoNatural.SelectedValue);    //ok                

                    registro.COD_TIPO_ZONA = int.Parse(cmbTipoZona.SelectedValue);//ok
                    registro.CORREO = txtCorreoNatural.Text;//ok
                    registro.CORREO_ALTERNO = txtCorreoNaturalAlternativo.Text;      //ok              
                    registro.DIRECCION = txtdireccionNatural.Text;//ok
                    registro.DOCUMENTO = txtNumeroDocumentoNatural.Text;    //ok                
                    registro.ES_PERSONA_JURIDICA = false;
                    registro.ES_PERSONA_NATURAL = true;
                    
                    registro.NOMBRE = txtNombresNatural.Text;         //ok           
                    registro.RESPUESTA_PREGUNTA_SECRETA = txtRespuestaPregunta.Text;   //ok                 
                    registro.TELEFONO = txtTelefonoNatural.Text;//ok
                    registro.TERMINOS = chkTerminosYCondiciones.Checked;//ok
                    registro.NOMBRE_USUARIO = txtUsuario.Text;//ok
                    //miramos los tipos de usuario x registro
                    for (int k = 0; k < dataPerfiles.Items.Count; k++)
                    {
                        CheckBox ch = (CheckBox)dataPerfiles.Items[k].FindControl("IdLabel");
                        if (ch.Checked && registro.TipoUsuario.Where(x => x.Id == int.Parse(ch.ValidationGroup)).Count() <= 0)
                        {
                            registro.TipoUsuario.Add(obj.obtenerTipousuario(int.Parse(ch.ValidationGroup)));
                        }
                        else {
                            if (registro.TipoUsuario.Where(x => x.Id == int.Parse(ch.ValidationGroup)).Count() > 0)
                            {
                                registro.TipoUsuario.Remove(obj.obtenerTipousuario(int.Parse(ch.ValidationGroup)));
                            }
                        }
                    }
                    #endregion
                }
                else {
                    //juridico
                    registro = obj.obtenerRegistroxUsuario(txtUsuarioJuridico.Text);
                    registroHijo = obj.obtenerRegistroxhijo(registro.COD_REGISTRO);

                    if(registroHijo is null)
                    {
                        registroHijo = new REGISTRO
                        {
                            FECHA_REGISTRO = registro.FECHA_REGISTRO,
                            ES_PERSONA_JURIDICA = false,
                            ES_PERSONA_NATURAL = true,
                            COD_ESTADO_REGISTRO = 1
                        };

                        registro.REGISTRO1.Add(registroHijo);
                    }

                    string rutaArchivo = Path.GetFileName(registro.RUTA_ARCHIVO);
                    correo = txtcorreoinstitucional.Text;
 
 
                    registro.NOMBRE_USUARIO = txtUsuarioJuridico.Text;//ok


                    int codTipo = 0;
                    if ((cmbTipoHiddenClient.Value == "8" || cmbTipoHiddenClient.Value == "9" ||
                    cmbTipoHiddenClient.Value == "10" || cmbTipoHiddenClient.Value == "12"))
                    {
                        codTipo = int.Parse(cmbTipoDosHidden.Value);
                    }
                    else {
                        codTipo = int.Parse(cmbTipoHiddenClient.Value);
                    }

                    registro.COD_TIPO_JURIDICO = codTipo;
                    registro.NOMBRE = txtNombreEntidad.Text;
                    registro.FACULTAD = txtNombreFacultad.Text;

                    registro.COD_TIPO_IDENTIFICACION = short.Parse(cmbTipoDocumentoHidden.Value);
                    registro.DOCUMENTO = txtDocumentoJuridico.Text;
                        registro.DOCUMENTO = registro.DOCUMENTO ;
                    registro.DIGITO_VERIFICACION = txtDigitoVerificacion.Text;
                    registro.FECHA_ACTA = txtFechaActa.Text;

                    registro.ESPECIALIDAD = txtEspecialidad.Text;
                    if (cmbTipoHiddenClient.Value == "35")
                    {
                        registro.COD_TIPO_IPS = int.Parse(cmbTipoIps.SelectedValue.ToString());
                    }

                    registro.COD_MUNICIPIO = short.Parse(cmbMunicipioJuridico.SelectedValue);
                    registro.DIRECCION = txtdireccionJuridico.Text;
                    registro.COD_TIPO_ZONA = int.Parse(cmbtipoZonaJuridico.SelectedValue);

                    if (cmbsubTipo.SelectedValue == "1")
                    {
                        int temp = 0;
                        int.TryParse(txtNumeroRepresentante.Text, out temp);
                        registro.REPRESENTADOS = temp;
                        registro.COD_TIPO_REPRESENTADO = int.Parse(cmbtipoRepresentados.SelectedValue);
                    }

                    registro.TELEFONO = txtTelefonoJuridico.Text;
                    registro.CORREO = txtcorreoinstitucional.Text;
                    registro.CORREO_ALTERNO = txtcorreoAlternoInstitucional.Text;
                    registro.COD_PREGUNTA_SECRETA = short.Parse(cmbPreguntaSecretaJuridica.SelectedValue);
                    registro.RESPUESTA_PREGUNTA_SECRETA = txtRespuestaPreguntaJuridica.Text;

                    System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
                    string url = ar.GetValue("urllocal", typeof(string)).ToString();
                    
                    registro.RUTA_ARCHIVO = lnkArchivo3.HRef.Replace(url, "~/");

                    //todo lo del representante
                    string docRepresentante = registroHijo.DOCUMENTO;
                    registroHijo.COD_TIPO_IDENTIFICACION = short.Parse(cmbTipoDocumentoRepresentante.SelectedValue);
                    registroHijo.DOCUMENTO = txtNumeroDocumentoRepresentante.Text.Trim();//registro.COD_TIPO_IPS = txtApellidosNatural.Text;

                    registroHijo.NOMBRE = txtNombresRepresentante.Text.Trim(); //registro.COD_TIPO_JURIDICO = txtApellidosNatural.Text;
                    registroHijo.APELLIDOS = txtApellidosRepresentante.Text.Trim();
                    registroHijo.COD_SEXO = int.Parse(cmbSexoRepresentante.SelectedValue);
                    registroHijo.TELEFONO = txtTelefonoRepresentante.Text.Trim();
                    registroHijo.CELULAR = txtTelefonoCelularRepresentante.Text.Trim();
                    registroHijo.CORREO = txtCorreoRepresentante.Text;

                    registro.CERTIFICO = chkCertifico.Checked;
                    registro.AUTORIZO = chkAutorizo.Checked;
                    registro.TERMINOS = chkTerminosYCondiciones.Checked;

                    string nuevoArchivo = Path.GetFileName(registro.RUTA_ARCHIVO);
                    if (!nuevoArchivo.Equals(rutaArchivo) || !docRepresentante.Equals(registroHijo.DOCUMENTO))
                    {
                        registro.COD_ESTADO_REGISTRO = 2;
                    }

                }

                if (Session["SS_COD_REGISTRO"] != null && Session["SS_COD_REGISTRO"].ToString() != string.Empty)
                {
                    obj.updateRegistroAclaraciones(registro, registroHijo, false);
                }
                else {
                    obj.updateRegistroAclaraciones(registro, registroHijo,true);
                }

                enviarEmailInscripcion(correo);
                Session["correoRegistrado"] = correo;

                Session.Remove("ArchivosCargados");
                pnlValido.Visible = false;
                pnlNoValido.Visible = true;
                lblTitulo.Text = "Registro Actualizado";
                if (Session["SS_COD_REGISTRO"] != null && Session["SS_COD_REGISTRO"].ToString() != string.Empty)
                {
                    lblContenido.Text = "Su registro fue actualizado satisfactoriamente.";
                    if (cmbPerfil.SelectedValue != "1")
                    {
                        lblContenido.Text = "Su registro fue actualizado satisfactoriamente, se encuentra sujeto a aprobación por parte del Ministerio de Salud y Protección Social.";
                    }
                }
                else {
                    lblContenido.Text = "Su registro fue actualizado satisfactoriamente.<br>En un plazo máximo de <b>8 días</b> se le enviará una respuesta a su solicitud a la dirección de correo electrónico registrado.";
                }
            }
        }

      

    }
}