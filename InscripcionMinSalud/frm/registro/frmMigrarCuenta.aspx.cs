using NegocioInscripcionMinSalud;
using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscripcionMinSalud.frm.registro
{
    public partial class frmMigrarCuenta : System.Web.UI.Page
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

        public string IdentificacionParticipante
        {
            get
            {
                if (Session["IdentificacionParticipante"] == null)
                {
                    return null;
                }
                return Session["IdentificacionParticipante"].ToString();
            }
            set
            {
                Session["IdentificacionParticipante"] = value;
            }
        }

        private bool? Ingreso
        {
            get
            {
                if (Session["ingreso"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToBoolean(Session["ingreso"]);
                }
            }
            set
            {
                Session["ingreso"] = value;
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
                    txtUsuarioJuridico.CssClass = "form-control";
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

            return (ValidarExisteParticipante() && ValidarExisteUsuario() && ValidarExisteCorreo());
        }

        /// <summary>
        /// Valida si hay un archivo cargado cuyo nombre comienza con "3-".
        /// </summary>
        /// <returns>
        ///   <c>true</c> si se encuentra un archivo cargado cuyo nombre comienza con "3-"; de lo contrario, <c>false</c>.
        /// </returns>
        private bool ValidarArchivoCargado()
        {
            // Iterar a través de la lista de archivos cargados
            foreach (string archivoCargado in ArchivosCargados)
            {
                // Obtener el nombre del archivo sin la ruta
                string nombreArchivo = System.IO.Path.GetFileName(archivoCargado);

                // Verificar si el nombre del archivo comienza con "3-"
                if (nombreArchivo.StartsWith("3-"))
                {
                    // Devolver true si se encuentra un archivo cuyo nombre comienza con "3-"
                    return true;
                }
            }

            // Devolver false si no se encuentra ningún archivo cuyo nombre comience con "3-"
            return false;
        }

        /// <summary>
        /// Valida la existencia del participante según el tipo de perfil y el número de documento.
        /// </summary>
        /// <returns>
        ///   <c>true</c> si el participante no existe o existe pero está en un estado válido; de lo contrario, <c>false</c>.
        /// </returns>
        private bool ValidarExisteParticipante()
        {
            clsNegocio obj = new clsNegocio();

            string documento = "";
            if (cmbPerfil.SelectedValue == "1")
            {//juridico
                documento = txtNumeroDocumentoNatural.Text;
            }
            else {
                documento = txtDocumentoJuridico.Text;
                if (txtDigitoVerificacion.Text != string.Empty)
                {
                    documento = documento + "-" + txtDigitoVerificacion.Text.Trim().Substring(0, 1);
                }
            }

            var c = obj.obtenerRegistroxdocumento(documento);


            if (c != null)
            {
                if (c.COD_ESTADO_REGISTRO == 1)
                {
                    LblValidacionCampos.Text += "El número de identificación ya esta registrado, pero no ha validado su correo electrónico";
                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 2 || c.COD_ESTADO_REGISTRO == 4)
                {
                    LblValidacionCampos.Text += "El número de identificación ya esta registrado,  su inscripción esta en proceso de validación";
                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 3)
                {
                    LblValidacionCampos.Text += "El número de identificación ya esta registrado,  se solicitaron aclaraciones de su registro las cuales podra encontrar en su correo electrónico";
                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 5)
                {
                    return true;
                }
                else if (c.COD_ESTADO_REGISTRO == 6)
                {
                    LblValidacionCampos.Text += "El número de identificación ya esta registrado, y la cuenta fue cancelada por el usuario";
                    return false;
                }


                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida la existencia del usuario según el tipo de perfil y el nombre de usuario.
        /// </summary>
        /// <returns>
        ///   <c>true</c> si el usuario no existe o existe pero está en un estado válido; de lo contrario, <c>false</c>.
        /// </returns>
        private bool ValidarExisteUsuario()
        {
            clsNegocio obj = new clsNegocio();
            string usuario = "";
            if (cmbPerfil.SelectedValue == "1")
            {//juridico
                usuario = txtUsuario.Text;
            }
            else {
                usuario = txtUsuarioJuridico.Text;
            }

            var c = obj.obtenerRegistroxUsuario(usuario);


            if (c != null)
            {
                if (cmbPerfil.SelectedValue == "2")
                {
                    txtUsuarioJuridico.CssClass = "";
                    txtUsuarioJuridico.Attributes.Remove("placeholder");

                    txtUsuarioJuridico.CssClass = "form-control errormin";

                }
                else {

                    txtUsuario.Attributes.Remove("placeholder");

                    txtUsuario.CssClass = "form-control errormin";

                }

                if (c.COD_ESTADO_REGISTRO == 1)
                {
                    LblValidacionCampos.Text += "El Usuario ya esta registrado, pero no ha validado su correo electrónico";
                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 2 || c.COD_ESTADO_REGISTRO == 4)
                {
                    LblValidacionCampos.Text += "El Usuario ya esta registrado,  su inscripción esta en proceso de validación";
                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 3)
                {
                    LblValidacionCampos.Text += "El Usuario ya esta registrado,  se solicitaron aclaraciones de su registro las cuales podra encontrar en su correo electrónico";
                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 5)
                {
                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 6)
                {
                    LblValidacionCampos.Text += "El Usuario ya esta registrado, y la cuenta fue cancelada por el usuario";
                    return false;
                }
                else
                {
                    LblValidacionCampos.Text += "El Usuario ya esta registrado.";
                    return false;
                }


            }

            return true;
        }
        /// <summary>
        /// Valida la existencia del correo electrónico según el tipo de perfil y la dirección de correo.
        /// </summary>
        /// <returns>
        ///   <c>true</c> si el correo electrónico no existe o existe pero está en un estado válido; de lo contrario, <c>false</c>.
        /// </returns>
        private bool ValidarExisteCorreo()
        {
            clsNegocio obj = new clsNegocio();
            string usuario = "";
            if (cmbPerfil.SelectedValue == "1")
            {//juridico
                usuario = txtCorreoNatural.Text;
            }
            else {
                usuario = txtcorreoinstitucional.Text;
            }

            var c = obj.obtenerRegistroxCorreo(usuario, 0);


            if (c != null)
            {
                if (cmbPerfil.SelectedValue == "2")
                {
                    txtcorreoinstitucional.CssClass = "";
                    txtcorreoinstitucional.Attributes.Remove("placeholder");

                    txtcorreoinstitucional.CssClass = "form-control errormin";

                }
                else {

                    txtCorreoNatural.Attributes.Remove("placeholder");

                    txtCorreoNatural.CssClass = "form-control errormin";

                }

                if (c.COD_ESTADO_REGISTRO == 1)
                {
                    LblValidacionCampos.Text += "El correo electrónico ya esta registrado, pero no se ha validado.";
                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 2 || c.COD_ESTADO_REGISTRO == 4)
                {
                    LblValidacionCampos.Text += "El correo electrónico ya esta registrado,  su inscripción esta en proceso de validación";
                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 3)
                {
                    LblValidacionCampos.Text += "El correo electrónico ya esta registrado,  se solicitaron aclaraciones de su registro las cuales podra encontrar en su buzon de correo.";
                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 5)
                {
                    LblValidacionCampos.Text += "El correo electrónico ya esta registrado,  con otra cuenta de usuario '"+c.NOMBRE_USUARIO+"'";

                    return false;
                }
                else if (c.COD_ESTADO_REGISTRO == 6)
                {
                    LblValidacionCampos.Text += "El correo electrónico ya esta registrado, y la cuenta fue cancelada por el usuario";
                    return false;
                }
                else
                {
                    LblValidacionCampos.Text += "El correo electrónico ya esta registrado.";
                    return false;
                }


            }

            return true;
        }
        /// <summary>
        /// Maneja el evento Click del botón "Registrar".
        /// Realiza la validación del formulario y crea un nuevo registro en la base de datos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el botón "Registrar").</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            //
            if (ValidarFormulario())
            {
                //guaradmos el registro en la base de datos
                string correo = "";
                REGISTRO registro = new REGISTRO();
                REGISTRO registroHijo = null;
                clsNegocio obj = new clsNegocio();

                if (cmbPerfil.SelectedValue == "1")
                {
                    #region carga los datos de persona natural
                    correo = txtCorreoNatural.Text;
                    registro.APELLIDOS = txtApellidosNatural.Text;   //ok
                    registro.AUTORIZO = chkAutorizo.Checked;//ok
                    registro.CELULAR = txtTelefonoCelularNatural.Text;//ok
                    registro.CERTIFICO = chkCertifico.Checked;//ok
                    registro.COD_ESTADO_REGISTRO = 1;
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
                    registro.FECHA_REGISTRO = DateTime.Now;
                    registro.NOMBRE = txtNombresNatural.Text;         //ok           
                    registro.RESPUESTA_PREGUNTA_SECRETA = txtRespuestaPregunta.Text;   //ok                 
                    registro.TELEFONO = txtTelefonoNatural.Text;//ok
                    registro.TERMINOS = chkTerminosYCondiciones.Checked;//ok
                    registro.NOMBRE_USUARIO = txtUsuario.Text;//ok
                    //miramos los tipos de usuario x registro
                    for (int k = 0; k < dataPerfiles.Items.Count; k++)
                    {
                        CheckBox ch = (CheckBox)dataPerfiles.Items[k].FindControl("IdLabel");
                        if (ch.Checked)
                        {
                            registro.TipoUsuario.Add(obj.obtenerTipousuario(int.Parse(ch.ValidationGroup)));
                        }
                    }
                    #endregion
                }
                else {
                    //juridico
                    correo = txtcorreoinstitucional.Text;
                    registro.ES_PERSONA_JURIDICA = true;
                    registro.ES_PERSONA_NATURAL = false;
                    registro.FECHA_REGISTRO = DateTime.Now;
                    registro.COD_ESTADO_REGISTRO = 1;
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

                    registro.COD_TIPO_IDENTIFICACION = short.Parse(cmbTipoDocumentoHidden.Value);// int.Parse( cmbTipoDocumentoHidden.Value);
                    registro.DOCUMENTO = txtDocumentoJuridico.Text;
                    if (txtDigitoVerificacion.Text.Trim() != string.Empty)
                    {
                        registro.DOCUMENTO = registro.DOCUMENTO + "-" + txtDigitoVerificacion.Text;
                    }
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


                    registro.RUTA_ARCHIVO = lnkArchivo3.HRef;

                    //todo lo del representante
                    registroHijo = new REGISTRO();
                    registroHijo.ES_PERSONA_JURIDICA = false;
                    registroHijo.ES_PERSONA_NATURAL = true;
                    registroHijo.FECHA_REGISTRO = DateTime.Now;
                    registroHijo.COD_ESTADO_REGISTRO = 1;
                    registroHijo.COD_TIPO_IDENTIFICACION = short.Parse(cmbTipoDocumentoRepresentante.SelectedValue);
                    registroHijo.DOCUMENTO = txtNumeroDocumentoRepresentante.Text.Trim();//registro.COD_TIPO_IPS = txtApellidosNatural.Text;
                    registroHijo.NOMBRE = txtNombresRepresentante.Text.Trim(); //registro.COD_TIPO_JURIDICO = txtApellidosNatural.Text;
                    registroHijo.APELLIDOS = txtApellidosRepresentante.Text.Trim();
                    registroHijo.COD_SEXO = int.Parse(cmbSexoRepresentante.SelectedValue);
                    registroHijo.TELEFONO = txtTelefonoRepresentante.Text.Trim();
                    registroHijo.CELULAR = txtTelefonoCelularRepresentante.Text.Trim();
                    registroHijo.CORREO = txtCorreoRepresentante.Text;
                    registroHijo.FECHA_REGISTRO = DateTime.Now;
                    registro.CERTIFICO = chkCertifico.Checked;
                    registro.AUTORIZO = chkAutorizo.Checked;
                    registro.TERMINOS = chkTerminosYCondiciones.Checked;
                }

                obj.crearRegistro(registro, registroHijo);
                //validamos automaticamente la cuenta                
                var r = obj.obtenerRegistroxCorreo(correo, 0);
                if (r == null)
                {
                    if(txtDocumentoJuridico.Text != string.Empty)
                        r = obj.obtenerRegistroxdocumento(txtDocumentoJuridico.Text);
                    else
                        r = obj.obtenerRegistroxdocumento(txtNumeroDocumentoNatural.Text);

                }

                if (r== null)
                {
                     r = obj.obtenerRegistroxCorreo(r.CORREO, 0);
                    if (r == null)
                        r = obj.obtenerRegistroxdocumento(r.DOCUMENTO);
                    
                }
                if (r == null)
                {
                    r = obj.obtenerRegistroxCodigo(r.COD_REGISTRO);
                }


                bool b = false;
                obj.validarCorreoElectronico(r, null, out b);
                Session["correoRegistrado"] = correo;
                Session.Remove("ArchivosCargados");


                clsWebUtils email = new clsWebUtils();
                string asunto = "Actualización registro Mi VOX Pópuli del Ministerio de Salud y Protección Social";
                string password = Guid.NewGuid().ToString();
                password = password.Substring(2, 8);
                obj.actualizarContrasena(r.COD_REGISTRO, password);

                string cuerpo = @"Muchas gracias por Actualizar su registro en Mi VOX Pópuli del Ministerio de Salud y Protección Social. Queremos informarle que su solicitud ha sido <b>ACEPTADA.</b>
<br>Los datos de ingreso al sistema son desde ahora<br>
<br>Usuario: <b>" + r.NOMBRE_USUARIO + @"</b>
<br>Contraseña :<b>" + password + @"</b>
<br><br>Le pedimos esté atento de los correos que recibirá de parte del Ministerio de Salud y Protección Social.<br> ";
                email.enviarEmail(asunto, cuerpo, correo);
                Session["SS_COD_REGISTRO"] = r.COD_REGISTRO;
                Session["SS_NOMBRE_USUARIO"] = r.NOMBRE_USUARIO;

                //elimnamos el registro
                try {
                    NegocioInscripcionMinSalud.Participante.EliminarParticipanteNumeroIdentificacion(Session["IdentificacionParticipante"].ToString());
                }catch (Exception)
                {

                }

                Session["IdentificacionParticipante"] = null;
                Response.Redirect("~/Default.aspx");

            }
        }

        public void CargarDatos(NegocioInscripcionMinSalud.Participante participante)
        {

            //////////txtCedula.Text = participante.NumeroIdentificacion;
            //////////cmbTipoUsuario.SelectedValue = participante.IdTipoUsuario.ToString();
            txtNombresNatural.Text = participante.Nombres;
            txtNombreEntidad.Text = participante.Nombres;

            txtApellidosNatural.Text = participante.Apellidos;

            cmbTipoDocumentoHiddenClient.Value = participante.IdTipoIdentificacion.ToString();
            cmbTipoDocumentoRepresentante.SelectedValue = participante.IdTipoIdentificacionRepresentante.ToString();

            txtNumeroDocumentoRepresentante.Text = participante.NumeroIdentificacionRepresentante;
            txtNumeroDocumentoNatural.Text = participante.NumeroIdentificacion;
            cmbSexo.SelectedValue = participante.Genero.Trim()== "M"?"1":"0";
            cmbSexoRepresentante.SelectedValue = participante.Genero.Trim() == "M" ? "1" : "0";
            //////////if (participante.IdTipoUsuario == 1 || participante.IdTipoUsuario == 10 || participante.IdTipoUsuario == 12 || participante.IdTipoUsuario == 9 || participante.IdTipoUsuario == 3 || participante.IdTipoUsuario == 15)
            //////////{
            //////////    if (participante.PathNumeroIdentificacion.Trim() != "")
            //////////    {
            //////////        ArchivosCargados.Add(participante.PathNumeroIdentificacion);
            //////////        lblArchivoRepresentanteView.InnerText = System.IO.Path.GetFileName(participante.PathNumeroIdentificacion);

            //////////        if (participante.PathNumeroIdentificacion.Contains("\\files\\Aceptado"))
            //////////        {
            //////////            string pathRelativo = participante.PathNumeroIdentificacion.Substring(participante.PathNumeroIdentificacion.IndexOf("\\files\\Aceptado"));
            //////////            pathRelativo = "~" + pathRelativo;
            //////////            lblArchivoRepresentanteView.HRef = pathRelativo;
            //////////        }
            //////////    }

            //////////    lblArchivoCertificacionView.InnerText = "";

            //////////    if (participante.IdTipoUsuario == 9)
            //////////    {
            //////////        if (participante.Genero == "F")
            //////////        {
            //////////            cmbGenero.SelectedValue = "0";
            //////////        }
            //////////        else
            //////////        {
            //////////            cmbGenero.SelectedValue = "1";
            //////////        }
            //////////        txtNumeroRepresentante.Text = "0";
            //////////    }
            //////////    else
            //////////    {
            //////////        txtNumeroRepresentante.Text = participante.NumeroAsociados.ToString();
            //////////    }
            //////////}
            //////////else
            //////////{
            //////////    if (participante.PathNumeroIdentificacion.Trim() != "")
            //////////    {
            //////////        ArchivosCargados.Add(participante.PathNumeroIdentificacion);
            //////////        lblArchivoRepresentanteView.InnerText = System.IO.Path.GetFileName(participante.PathNumeroIdentificacion);

            //////////        if (participante.PathNumeroIdentificacion.Contains("\\files\\Aceptado"))
            //////////        {
            //////////            string pathRelativo = participante.PathNumeroIdentificacion.Substring(participante.PathNumeroIdentificacion.IndexOf("\\files\\Aceptado"));
            //////////            pathRelativo = "~" + pathRelativo;
            //////////            lblArchivoRepresentanteView.HRef = pathRelativo;
            //////////        }
            //////////    }

            //////////    if (participante.PathConstitucionGrupo.Trim() != "")
            //////////    {
            //////////        ArchivosCargados.Add(participante.PathConstitucionGrupo);
            //////////        lblArchivoCertificacionView.InnerText = System.IO.Path.GetFileName(participante.PathConstitucionGrupo);

            //////////        if (participante.PathConstitucionGrupo.Contains("\\files\\Aceptado"))
            //////////        {
            //////////            string pathRelativo2 = participante.PathConstitucionGrupo.Substring(participante.PathConstitucionGrupo.IndexOf("\\files\\Aceptado"));
            //////////            pathRelativo2 = "~" + pathRelativo2;
            //////////            lblArchivoCertificacionView.HRef = pathRelativo2;
            //////////        }
            //////////    }

            txtNumeroRepresentante.Text = participante.NumeroAsociados.ToString();
            

            txtCorreoNatural.Text = participante.Email;
            txtcorreoinstitucional.Text = participante.Email;

            txtUsuario.Text = participante.NumeroIdentificacion;
            txtUsuarioJuridico.Text = participante.NumeroIdentificacion;

            txtTelefonoNatural.Text = participante.Telefono;
            txtTelefonoJuridico.Text = participante.Telefono;

            txtRespuestaPregunta.Text = participante.RespuestaPregunta;
            txtRespuestaPreguntaJuridica.Text = participante.RespuestaPregunta;

            cmbPreguntaSecreta.SelectedValue = participante.IdPreguntaSecreta.ToString();
            cmbPreguntaSecretaJuridica.SelectedValue = participante.IdPreguntaSecreta.ToString();

            txtdireccionJuridico.Text = participante.Direccion;
            txtdireccionNatural.Text = participante.Direccion;

            txtTelefonoCelularNatural.Text = participante.Celular;
            txtTelefonoCelularRepresentante.Text = participante.Celular;

            
            
            cmbDepartamentoJuridico.SelectedValue = participante.IdDepartamento.ToString();
            cmbDepartamentoNatural.SelectedValue = participante.IdDepartamento.ToString();

            cmbMunicipioJuridico.SelectedValue = participante.IdMunicipio.ToString();
            cmbMunicipioNatural.SelectedValue = participante.IdMunicipio.ToString();

            //////////ConfigurarPantalla();
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
            //this.cmbTipoHidden.Value = cmbTipoUsuario.SelectedValue;
            if (!IsPostBack)
            {
                cmbNivelFormacion.SelectedValue = "0";
                cmbPoblacionEspecial.SelectedValue = "0";
                Session.Remove("ArchivosCargados");
                string documento = Session["IdentificacionParticipante"].ToString();
                NegocioInscripcionMinSalud.Participante participante = 
                    NegocioInscripcionMinSalud.Participante.ObtenerParticipanteNumeroIdentificacion(documento);
                CargarDatos(participante);

                //    if (Session["IdentificacionParticipante"] != null)
                //    {
                //      //  mnuInicio.Attributes.Add("class", "active");

                //        txtCedula.ReadOnly = true;

                //        this.CargarDatos();
                //        btnRegistrar.Text = "Actualizar";
                //    }
                //    else {
                //     //   mnuRegistro.Attributes.Add("class", "active");
                //        flInformacionParticipante.Style.Add("visibility", "hidden");
                //        flInformacionAcceso.Style.Add("visibility", "hidden");

                //        IdentificacionParticipante = null;
                //        btnRegistrar.Text = "Registrarme";
                //    }
            }
            else
            {
                CargarDatosArchivos();
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón "Registrar".
        /// Realiza la validación del formulario y crea un nuevo registro en la base de datos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el botón "Registrar").</param>
        /// <param name="e">Argumentos del evento.</param>
        private void enviarEmailInscripcion(string correo)
        {
            clsWebUtils email = new clsWebUtils();
            System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
            string url = ar.GetValue("urllocal", typeof(string)).ToString();
            string asunto = "Verificación de registro a Mi VOX Pópuli del Ministerio de Salud y Protección Social";
            //enmascaramos el correo
            var c = correo.ToCharArray();
            string cr = "";
            for (int k = 0; k < c.Length; k++)
            {
                c[k] = (char)(c[k] + 4);
                cr = cr + c[k];
            }

            string cuerpo = @"Muchas gracias por inscribirse a Mi Vox-Populi del Ministerio de Salud y Protección Social.<br>
                Para continuar con el proceso de registro, haga clic en el siguiente enlace.<a href='" + url + "/frm/registro/verificar.aspx?token=" + cr + "' >Continuar</a>,  " +
                "</br>Si no funciona, cópielo y péguelo directamente en la barra de direcciones del navegador de Internet. enlace: " + url + "/aspx/registro/verificar.aspx?token=" + cr + " ";

            email.enviarEmail(asunto, cuerpo, correo);

        }
        /// <summary>
        /// Carga los datos de los archivos adjuntos, enlazando los nombres de los archivos a sus ubicaciones relativas.
        /// </summary>
        private void CargarDatosArchivos()
        {
            foreach (string archivo in ArchivosCargados)
            {
                string nombreArchivo = System.IO.Path.GetFileName(archivo);

                if (archivo.Contains("\\files\\Temporal"))
                {
                    string pathRelativo = archivo.Substring(archivo.IndexOf("\\files\\Temporal"));
                    pathRelativo = "~" + pathRelativo;
                    lnkArchivo3.InnerText = nombreArchivo;
                    lnkArchivo3.HRef = pathRelativo;
                }
            }
        }
        /// <summary>
        /// Maneja el evento Click del botón "Cancelar".
        /// Limpia la sesión actual y redirige al usuario a la página principal.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el botón "Cancelar").</param>
        /// <param name="e">Argumentos del evento.</param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/default.aspx");
        }

    }
}