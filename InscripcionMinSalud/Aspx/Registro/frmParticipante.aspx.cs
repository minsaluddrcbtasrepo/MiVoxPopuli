using C1.C1Report;
using InscripcionMinSalud.Aspx.Registro;
using NegocioInscripcionMinSalud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace InscripcionMinSalud.Aspx
{
    public partial class frmParticipante : System.Web.UI.Page
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
            bool error = false;
            LblValidacionCampos.Text = "";
            LblValidacionCampos.Text += "Verifique los Siguientes Campos: ";

            cmbTipoUsuario.CssClass = "";
            cmbTipoUsuario.Attributes.Remove("placeholder");
            if (cmbTipoUsuario.SelectedValue == "0")
            {
                error = true;
                LblValidacionCampos.Text += "Tipo usuario, ";
                cmbTipoUsuario.Attributes.Add("placeholder", "Debe seleccionar un tipo de usuario");
                cmbTipoUsuario.CssClass = "form-control errormin";
            }
            else
            {
                cmbTipoUsuario.CssClass = "form-control";
            }

            cmbTipoDocumento.CssClass = "";
            cmbTipoDocumento.Attributes.Remove("placeholder");
            if (cmbTipoDocumento.SelectedValue == "8")
            {
                error = true;
                LblValidacionCampos.Text += "Tipo documento, ";
                cmbTipoDocumento.Attributes.Add("placeholder", "Debe seleccionar un tipo de documento");
                cmbTipoDocumento.CssClass = "form-control errormin";
            }
            else
            {
                cmbTipoDocumento.CssClass = "form-control";
            }

            txtCedula.CssClass = "";
            txtCedula.Attributes.Remove("placeholder");
            if (txtCedula.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Número de identificación, ";
                txtCedula.Attributes.Add("placeholder", "Debe ingresar el número de documento");
                txtCedula.CssClass = "form-control errormin";
            }
            else
            {
                txtCedula.CssClass = "form-control";                
            }
            //validamos si es cedula nit rit o rut que no tenga valores que no sean numeros
            int test = 0;
            if (
                int.TryParse(txtCedula.Text,out test) == false &&
                (cmbTipoDocumento.SelectedValue== "1" || cmbTipoDocumento.SelectedValue == "9"
                || cmbTipoDocumento.SelectedValue == "10" || cmbTipoDocumento.SelectedValue == "11")
                )
            {
                error = true;
                LblValidacionCampos.Text += "Número de identificación, ";
                txtCedula.Attributes.Add("placeholder", "Debe ingresar un número de documento valido");
                txtCedula.CssClass = "form-control errormin";
            }
            //
            if (txtdigitoVerificacion.Text.Trim() == string.Empty
                && (cmbTipoDocumento.SelectedValue == "9"
                || cmbTipoDocumento.SelectedValue == "10" || cmbTipoDocumento.SelectedValue == "11"))
            {
                error = true;
                LblValidacionCampos.Text += "Digito de verificación, ";
                txtdigitoVerificacion.CssClass = "form-control errormin";
            }else{

                txtdigitoVerificacion.CssClass = "form-control";
            }

            if (txtdigitoVerificacion2.Text.Trim() == string.Empty
               && (cmbTipoDocumentoRepresentanteLegal.SelectedValue == "9"
               || cmbTipoDocumentoRepresentanteLegal.SelectedValue == "10" || cmbTipoDocumentoRepresentanteLegal.SelectedValue == "11"))
            {
                error = true;
                LblValidacionCampos.Text += "Digito de verificación representante legal, ";
                txtdigitoVerificacion2.CssClass = "form-control errormin";
            }
            else {

                txtdigitoVerificacion2.CssClass = "form-control";
            }


            #region validacion de contraseña
            txtContrasenaInicial.CssClass = "";
            txtContrasenaInicial.Attributes.Remove("placeholder");
            if (txtContrasenaInicial.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Contraseña, ";
                txtContrasenaInicial.Attributes.Add("placeholder", "Debe ingresar la contraseña");
                txtContrasenaInicial.CssClass = "form-control errormin";
            }
            else
            {
                txtContrasenaInicial.CssClass = "form-control";                
            }

            txtConfirmarContrasena.CssClass = "";
            txtConfirmarContrasena.Attributes.Remove("placeholder");
            if (txtConfirmarContrasena.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Confirmar contraseña, ";
                txtConfirmarContrasena.Attributes.Add("placeholder", "Debe ingresar la confirmación de la contraseña");
                txtConfirmarContrasena.CssClass = "form-control errormin";
            }
            else
            {
                if (txtContrasenaInicial.Text != txtConfirmarContrasena.Text)
                {
                    error = true;
                    LblValidacionCampos.Text += "Confirmar contraseña, ";
                    txtConfirmarContrasena.Attributes.Add("placeholder", "Debe ingresar el mismo valor para las dos contraseñas");
                    txtConfirmarContrasena.CssClass = "form-control errormin";
                }
                else
                {
                    if (txtContrasenaInicial.Text.Length < 8 && txtContrasenaInicial.Text != "INS_p")
                    {
                        txtConfirmarContrasena.Text = "";
                        error = true;
                        LblValidacionCampos.Text += "Confirmar contraseña, ";
                        txtConfirmarContrasena.Attributes.Add("placeholder", "La contraseña debe contener minimo 8 caracteres");
                        txtConfirmarContrasena.CssClass = "form-control errormin";
                    }
                    else
                    {
                        txtConfirmarContrasena.CssClass = "form-control";
                    }
                }
            }
#endregion
            txtEmail.CssClass = "";
            txtEmail.Attributes.Remove("placeholder");
            if (txtEmail.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "E-mail, ";
                txtEmail.Attributes.Add("placeholder", "Debe ingresar la dirección correo");
                txtEmail.CssClass = "form-control errormin";
            }
            else
            {
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    error = true;
                    LblValidacionCampos.Text += "E-mail, ";
                    txtEmail.Attributes.Add("placeholder", "Dirección correo electrónico NO valida");
                    txtEmail.CssClass = "form-control errormin";
                }
                else
                {
                    txtEmail.CssClass = "form-control";
                }
            }

            cmbPregunta.CssClass = "";
            cmbPregunta.Attributes.Remove("placeholder");
            if (cmbPregunta.SelectedValue == "5")
            {
                error = true;
                LblValidacionCampos.Text += "Pregunta secreta, ";
                cmbPregunta.Attributes.Add("placeholder", "Seleccione la pregunta secreta");
                cmbPregunta.CssClass = "form-control errormin";
            }
            else
            {
                cmbPregunta.CssClass = "form-control";
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

            txtNombre.CssClass = "";
            txtNombre.Attributes.Remove("placeholder");
            if (txtNombre.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Nombre, ";
                txtNombre.Attributes.Add("placeholder", "Ingrese su nombre o el de la asociación");
                txtNombre.CssClass = "form-control errormin";
            }
            else
            {
                txtNombre.CssClass = "form-control";
            }

            txtApellido.CssClass = "";
            txtApellido.Attributes.Remove("placeholder");
            if (txtApellido.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Apellido, ";
                txtApellido.Attributes.Add("placeholder", "Este campo no puede estar en blanco");
                txtApellido.CssClass = "form-control errormin";
            }
            else
            {
                txtApellido.CssClass = "form-control";
            }

            txtTelefono.CssClass = "";
            txtTelefono.Attributes.Remove("placeholder");
            if (txtTelefono.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Teléfono fijo, ";
                txtTelefono.Attributes.Add("placeholder", "Ingrese el número de teléfono fijo");
                txtTelefono.CssClass = "form-control errormin";
            }
            else
            {
                txtTelefono.CssClass = "form-control";
            }

            txtTelefonoCelular.CssClass = "";
            txtTelefonoCelular.Attributes.Remove("placeholder");
            if (txtTelefonoCelular.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Teléfono celular, ";
                txtTelefonoCelular.Attributes.Add("placeholder", "Ingrese el número de teléfono celular");
                txtTelefonoCelular.CssClass = "form-control errormin";
            }
            else
            {
                txtTelefonoCelular.CssClass = "form-control";
            }

            cmbDepartamento.CssClass = "";
            cmbDepartamento.Attributes.Remove("placeholder");
            if (cmbDepartamento.SelectedValue == "0")
            {
                error = true;
                LblValidacionCampos.Text += "Departamento, ";
                cmbDepartamento.Attributes.Add("placeholder", "Debe seleccionar un departamento");
                cmbDepartamento.CssClass = "form-control errormin";
            }
            else
            {
                cmbDepartamento.CssClass = "form-control";
            }

            cmbMunicipio.CssClass = "";
            cmbMunicipio.Attributes.Remove("placeholder");
            if (cmbMunicipio.SelectedValue == "0")
            {
                error = true;
                LblValidacionCampos.Text += "Municipio, ";
                cmbMunicipio.Attributes.Add("placeholder", "Debe seleccionar un municipio");
                cmbMunicipio.CssClass = "form-control errormin";
            }
            else
            {
                cmbMunicipio.CssClass = "form-control";
            }

            txtDireccion.CssClass = "";
            txtDireccion.Attributes.Remove("placeholder");
            if (txtDireccion.Text == "")
            {
                error = true;
                LblValidacionCampos.Text += "Dirección, ";
                txtDireccion.Attributes.Add("placeholder", "Ingrese la dirección");
                txtDireccion.CssClass = "form-control errormin";
            }
            else
            {
                txtDireccion.CssClass = "form-control";
            }


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

            //SOLO PERSONA NATURAL
            cmbGenero.CssClass = "form-control";
            cmbGenero.Attributes.Remove("placeholder");

            //SOLO ASOCIACIONES
            cmbTipoDocumentoRepresentanteLegal.CssClass = "form-control";
            cmbTipoDocumentoRepresentanteLegal.Attributes.Remove("placeholder");

            txtNumeroRepresentante.CssClass = "form-control";
            txtNumeroRepresentante.Attributes.Remove("placeholder");

            txtIdentificacionLegal.CssClass = "form-control";
            txtIdentificacionLegal.Attributes.Remove("placeholder");

            UploadFileRepresentante.CssClass = "";
            UploadFileRepresentante.Attributes.Remove("placeholder");

            UploadFileCertificacion.CssClass = "";
            UploadFileCertificacion.Attributes.Remove("placeholder");

            if (cmbTipoUsuario.SelectedValue.ToString() == "19" || cmbTipoUsuario.SelectedValue.ToString() == "20"
                ||
                cmbTipoUsuario.SelectedValue.ToString() == "21" || cmbTipoUsuario.SelectedValue.ToString() == "22"
                ||
                cmbTipoUsuario.SelectedValue.ToString() == "23" ||
                cmbTipoUsuario.SelectedValue.ToString() == "41"
                )
            {
                if (cmbGenero.SelectedValue == "2")
                {
                    error = true;
                    LblValidacionCampos.Text += "Genero, ";
                    cmbGenero.Attributes.Add("placeholder", "Debe seleccionar genero");
                    cmbGenero.CssClass = "form-control errormin";
                }

                //if (cmbTipoUsuario.SelectedValue.ToString() == "11")
                //{
                //    if (!ValidarArchivoCargado(1))
                //    {
                //        error = true;
                //        LblValidacionCampos.Text += "Archivo documento, ";
                //        UploadFileRepresentante.Attributes.Add("placeholder", "Seleccione el archivo de documento");
                //        UploadFileRepresentante.NullTextStyle.ForeColor = ColorTranslator.FromHtml("#E4335C");
                //    }

                //    if (!ValidarArchivoCargado(2))
                //    {
                //        error = true;
                //        LblValidacionCampos.Text += "Archivo tarjeta profesional, ";
                //        UploadFileCertificacion.Attributes.Add("placeholder", "Seleccione el archivo de tarjeta profesional");
                //        UploadFileCertificacion.NullTextStyle.ForeColor = ColorTranslator.FromHtml("#E4335C");
                //    }
                //}
                //else
                //{
                //    if (!ValidarArchivoCargado(1))
                //    {
                //        error = true;
                //        LblValidacionCampos.Text += "Archivo documento, ";
                //        UploadFileRepresentante.Attributes.Add("placeholder", "Seleccione el archivo de documento");
                //        UploadFileRepresentante.NullTextStyle.ForeColor = ColorTranslator.FromHtml("#E4335C");
                //        LblValidacionCampos.Text += "Archivo representante legal, ";
                //    }
                //}
            }
            else
            {
                if (cmbTipoDocumentoRepresentanteLegal.SelectedValue == "8")
                {
                    error = true;
                    cmbTipoDocumentoRepresentanteLegal.Attributes.Add("placeholder", "Debe seleccionar un tipo de documento");
                    cmbTipoDocumentoRepresentanteLegal.CssClass = "form-control errormin";
                    LblValidacionCampos.Text += "Tipo de documento representante legal, ";
                }

                if (txtNumeroRepresentante.Text == "")
                {
                    error = true;
                    txtNumeroRepresentante.Attributes.Add("placeholder", "Número Asociados");
                    txtNumeroRepresentante.CssClass = "form-control errormin";
                    LblValidacionCampos.Text += "Número personas que representa, ";
                }

                if (txtIdentificacionLegal.Text == "")
                {
                    error = true;
                    txtIdentificacionLegal.Attributes.Add("placeholder", "Debe ingresar el número de identificación del representante legal");
                    txtIdentificacionLegal.CssClass = "form-control errormin";
                    LblValidacionCampos.Text += "Número identificación representante legal, ";
                }

                if (!ValidarArchivoCargado(1))
                {
                    error = true;
                    UploadFileRepresentante.Attributes.Add("placeholder", "Seleccione el archivo de certificación para el representante legal");
                    UploadFileRepresentante.NullTextStyle.ForeColor = ColorTranslator.FromHtml("#E4335C");
                    LblValidacionCampos.Text += "Archivo representante legal, ";
                }

                //if (cmbTipoUsuario.SelectedValue == "2" || cmbTipoUsuario.SelectedValue == "4" ||
                //    cmbTipoUsuario.SelectedValue == "5" || cmbTipoUsuario.SelectedValue == "6" ||
                //    cmbTipoUsuario.SelectedValue == "7" || cmbTipoUsuario.SelectedValue == "8" ||
                //    cmbTipoUsuario.SelectedValue == "11" || cmbTipoUsuario.SelectedValue == "13")
                //{
                    if (!ValidarArchivoCargado(2))
                    {
                        error = true;
                        UploadFileCertificacion.Attributes.Add("placeholder", "Seleccione el archivo de constitución de la sociedad");
                        UploadFileCertificacion.NullTextStyle.ForeColor = ColorTranslator.FromHtml("#E4335C");
                        LblValidacionCampos.Text += "Archivo asociación, ";
                    }
               // }
            }

            if (error)
            {
                return false;
            }
            if (btnRegistrar.Text == "Actualizar")
            {
                return true;
            }

            return ValidarExisteParticipante();
        }

        private bool ValidarArchivoCargado(Int16 tipo)
        {
            foreach (string archivoCargado in ArchivosCargados)
            {
                string nombreArchivo = System.IO.Path.GetFileName(archivoCargado);

                if (nombreArchivo.StartsWith(tipo.ToString() + "-"))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidarExisteParticipante()
        {
            NegocioInscripcionMinSalud.Participante participante = NegocioInscripcionMinSalud.Participante.ObtenerParticipanteNumeroIdentificacion(txtCedula.Text);
            txtCedula.CssClass = "";
            txtCedula.Attributes.Remove("placeholder");
            txtCedula.ToolTip = "";
            if (participante != null)
            {                
                if (participante.IdEstadoUsuario == 1)
                {
                    LblValidacionCampos.Text += "El número de identificación ya esta registrado, su inscripción esta en proceso de validación";
                    txtCedula.Attributes.Add("placeholder", "El número de identificación ya esta registrado, su inscripción esta en proceso de validación");
                    txtCedula.ToolTip= "El número de identificación ya esta registrado, su inscripción esta en proceso de validación";
                }
                else
                {
                    LblValidacionCampos.Text += "El número de identificación ya existe y tiene un usuario valido en el sistema";
                   txtCedula.Attributes.Add("placeholder", "El número de identificación ya existe y tiene un usuario valido en el sistema");
                    txtCedula.ToolTip= "El número de identificación ya existe y tiene un usuario valido en el sistema";
                }
                txtCedula.CssClass = "form-control errormin";
                return false;
            }
            else
            {
                txtCedula.CssClass = "form-control";
                return true;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                NegocioInscripcionMinSalud.Participante participante = new NegocioInscripcionMinSalud.Participante();

                participante.NumeroIdentificacion = txtCedula.Text;
                participante.IdTipoUsuario = Convert.ToInt16(cmbTipoUsuario.SelectedValue);
                participante.Nombres = txtNombre.Text;
                participante.Apellidos = txtApellido.Text;
                participante.NombreRepresentanteLegal = txtApellido.Text;
                participante.IdTipoIdentificacion = Convert.ToInt16(cmbTipoDocumento.SelectedValue);
                participante.IdTipoIdentificacionRepresentante = Convert.ToInt16(cmbTipoDocumentoRepresentanteLegal.SelectedValue);
                participante.NumeroIdentificacionRepresentante = txtIdentificacionLegal.Text;

                if (participante.IdTipoUsuario == 1 || participante.IdTipoUsuario == 10 || participante.IdTipoUsuario == 12 || participante.IdTipoUsuario == 9 || participante.IdTipoUsuario == 3 || participante.IdTipoUsuario == 15)
                {
                    participante.PathConstitucionGrupo = "";

                    if (btnRegistrar.Text != "Actualizar")
                    {
                        string directorioIPS = Server.MapPath("~/files/Preregistro/" + txtCedula.Text);
                        if (System.IO.Directory.Exists(directorioIPS))
                        {
                            System.IO.Directory.Delete(directorioIPS, true);
                        }
                        System.IO.Directory.CreateDirectory(directorioIPS);
                        foreach (string archivoCargado in ArchivosCargados)
                        {
                            string nombreArchivo = System.IO.Path.GetFileName(archivoCargado);
                            string pathMover = System.IO.Path.Combine(directorioIPS, nombreArchivo.Replace("%", ""));

                            System.IO.File.Move(archivoCargado, pathMover);

                            if (nombreArchivo.StartsWith("1-"))
                            {
                                participante.PathNumeroIdentificacion = pathMover;
                            }

                            if (System.IO.File.Exists(archivoCargado))
                            {
                                System.IO.File.Delete(archivoCargado);
                            }
                        }
                    }
                    else
                    {
                        string directorioIPS = Server.MapPath("~/files/Aceptado/" + txtCedula.Text);
                        foreach (string archivoCargado in ArchivosCargados)
                        {
                            string nombreArchivo = System.IO.Path.GetFileName(archivoCargado);
                            if (!archivoCargado.Contains("Aceptado"))
                            {
                                string pathMover = System.IO.Path.Combine(directorioIPS, nombreArchivo.Replace("%", ""));

                                System.IO.File.Move(archivoCargado, pathMover);

                                if (nombreArchivo.StartsWith("1-"))
                                {
                                    participante.PathNumeroIdentificacion = pathMover;
                                }

                                if (System.IO.File.Exists(archivoCargado))
                                {
                                    System.IO.File.Delete(archivoCargado);
                                }
                            }
                            else
                            {
                                if (nombreArchivo.StartsWith("1-"))
                                {
                                    participante.PathNumeroIdentificacion = archivoCargado;
                                }
                            }
                        }
                    }

                    if (participante.IdTipoUsuario == 9)
                    {
                        if (cmbGenero.SelectedValue == "0")
                        {
                            participante.Genero = "F";
                        }
                        else
                        {
                            participante.Genero = "M";
                        }
                        participante.NumeroAsociados = 0;
                    }
                    else
                    {
                        participante.Genero = "F";

                        if (txtNumeroRepresentante.Text == "")
                        {
                            txtNumeroRepresentante.Text = "0";
                        }
                        participante.NumeroAsociados = Convert.ToInt32(txtNumeroRepresentante.Text);
                    }                    
                }
                else
                {
                    participante.PathNumeroIdentificacion = "";
                    participante.PathConstitucionGrupo = "";

                    if (btnRegistrar.Text != "Actualizar")
                    {
                        string directorioIPS = Server.MapPath("~/files/Preregistro/" + txtCedula.Text);
                        if (System.IO.Directory.Exists(directorioIPS))
                        {
                            System.IO.Directory.Delete(directorioIPS, true);
                        }
                        System.IO.Directory.CreateDirectory(directorioIPS);
                        foreach (string archivoCargado in ArchivosCargados)
                        {
                            string nombreArchivo = System.IO.Path.GetFileName(archivoCargado);
                            string pathMover = System.IO.Path.Combine(directorioIPS, nombreArchivo.Replace("%", ""));

                            System.IO.File.Move(archivoCargado, pathMover);

                            if (nombreArchivo.StartsWith("1-"))
                            {
                                participante.PathNumeroIdentificacion = pathMover;
                            }
                            else if (nombreArchivo.StartsWith("2-"))
                            {
                                participante.PathConstitucionGrupo = pathMover;
                            }

                            if (System.IO.File.Exists(archivoCargado))
                            {
                                System.IO.File.Delete(archivoCargado);
                            }
                        }
                    }
                    else
                    {
                        string directorioIPS = Server.MapPath("~/files/Aceptado/" + txtCedula.Text);
                        foreach (string archivoCargado in ArchivosCargados)
                        {
                            string nombreArchivo = System.IO.Path.GetFileName(archivoCargado);
                            if (!archivoCargado.Contains("Aceptado"))
                            {
                                string pathMover = System.IO.Path.Combine(directorioIPS, nombreArchivo.Replace("%", ""));

                                System.IO.File.Move(archivoCargado, pathMover);

                                if (nombreArchivo.StartsWith("1-"))
                                {
                                    participante.PathNumeroIdentificacion = pathMover;
                                }
                                else if (nombreArchivo.StartsWith("2-"))
                                {
                                    participante.PathConstitucionGrupo = pathMover;
                                }

                                if (System.IO.File.Exists(archivoCargado))
                                {
                                    System.IO.File.Delete(archivoCargado);
                                }
                            }
                            else
                            {
                                if (nombreArchivo.StartsWith("1-"))
                                {
                                    participante.PathNumeroIdentificacion = archivoCargado;
                                }
                                else if (nombreArchivo.StartsWith("2-"))
                                {
                                    participante.PathConstitucionGrupo = archivoCargado;
                                }
                            }
                        }
                    }
                    participante.Genero = " ";

                    if (txtNumeroRepresentante.Text == "")
                    {
                        txtNumeroRepresentante.Text = "0";
                    }
                    participante.NumeroAsociados = Convert.ToInt32(txtNumeroRepresentante.Text);
                }


                participante.Email = txtEmail.Text;
                participante.Telefono = txtTelefono.Text;
                participante.Celular = txtTelefonoCelular.Text;
                participante.Direccion = txtDireccion.Text;
                participante.Certifico = chkCertifico.Checked;
                participante.Autorizo = CheckAutorizoCorreo.Checked;
                participante.ContrasenaValor = txtContrasenaInicial.Text;
                participante.IdPreguntaSecreta = Convert.ToInt16(cmbPregunta.SelectedValue);
                participante.RespuestaPregunta = txtRespuestaPregunta.Text;
                participante.IdMunicipio = Convert.ToInt16(cmbMunicipio.SelectedValue);
                participante.AutorizoEmail = CheckAutorizoCorreo.Checked;
                participante.digitoVerificacion = txtdigitoVerificacion.Text;
                participante.digitoVerificacionRepresentante = txtdigitoVerificacion2.Text;
              
                if (btnRegistrar.Text.Trim().ToLower() == "actualizar")
                {
                    participante.IdEstadoUsuario = 2;
                    NegocioInscripcionMinSalud.Participante.ActualizarParticipanteBD(participante);
                    this.DireccionarPagina();
                }
                else
                {
                    participante.IdEstadoUsuario = 1;
                    NegocioInscripcionMinSalud.Participante.GuardarParticipanteBD(participante);
                    this.IdentificacionParticipante = participante.NumeroIdentificacion;
                    //NegocioInscripcionMinSalud.Participante.EmailRegistroSatisfactorio(this.IdentificacionParticipante);
                    enviarEmailInscripcion(txtEmail.Text);
                    Response.Redirect("~/Aspx/Registro/confirmar.aspx");
                    Session.Remove("ArchivosCargados");
                }
            }            
        }

        private void CargarCombosFormulario()
        {
          

            cmbDepartamento.DataSource = NegocioInscripcionMinSalud.Departamento.ObtenerDepartamento();
            cmbDepartamento.DataTextField = "Nombre";
            cmbDepartamento.DataValueField = "Id";
            cmbDepartamento.DataBind();            

            cmbPregunta.DataSource = NegocioInscripcionMinSalud.PreguntaSecreta.ObtenerPregunta();
            cmbPregunta.DataTextField = "TextoPregunta";
            cmbPregunta.DataValueField = "Id";
            cmbPregunta.DataBind();

            cmbMunicipio.DataSource = NegocioInscripcionMinSalud.Municipio.ObtenerMunicipio(0);
            cmbMunicipio.DataTextField = "Nombre";
            cmbMunicipio.DataValueField = "Id";
            cmbMunicipio.DataBind();
            

            cmbTipoDocumentoRepresentanteLegal.DataTextField = "Nombre";
            cmbTipoDocumentoRepresentanteLegal.DataValueField = "Id";
            cmbTipoDocumentoRepresentanteLegal.DataSource = NegocioInscripcionMinSalud.TipoDocumento.ObtenerTiposDocumentosNatural();
            cmbTipoDocumentoRepresentanteLegal.DataBind();
        }

        private void cargarTiposUsuario()
        {
            if (Session["IdentificacionParticipante"] == null)
            {
                if (cmbTipoPerfil.SelectedValue == "1")
                {
                    cmbTipoUsuario.DataSource = NegocioInscripcionMinSalud.TipoUsuario.ObtenerTiposUsuarionUEVONatural();
                    cmbTipoDocumento.DataSource = NegocioInscripcionMinSalud.TipoDocumento.ObtenerTiposDocumentosNatural();
                }
                else {
                    cmbTipoUsuario.DataSource = NegocioInscripcionMinSalud.TipoUsuario.ObtenerTiposUsuarionUEVOJuridico();
                    cmbTipoDocumento.DataSource = NegocioInscripcionMinSalud.TipoDocumento.ObtenerTiposDocumentosJuridico();
                }
            }
            else {
                pnlcontenido.Visible = true;

                NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
                var p = obj.obtenerParticipantexdocumento(Session["IdentificacionParticipante"].ToString());

                if (p.TipoUsuario.ES_NATURAL.HasValue && p.TipoUsuario.ES_NATURAL.Value)
                {
                    cmbTipoPerfil.SelectedValue = "1";
                }
                else {
                    cmbTipoPerfil.SelectedValue = "2";
                }


                if (p.TipoUsuario.ES_NUEVO.HasValue && p.TipoUsuario.ES_NUEVO.Value)
                {
                    if (cmbTipoPerfil.SelectedValue == "1")
                    {
                        cmbTipoUsuario.DataSource = NegocioInscripcionMinSalud.TipoUsuario.ObtenerTiposUsuarionUEVONatural();

                        cmbTipoDocumento.DataSource = NegocioInscripcionMinSalud.TipoDocumento.ObtenerTiposDocumentosNatural();
                    }
                    else {
                        cmbTipoUsuario.DataSource = NegocioInscripcionMinSalud.TipoUsuario.ObtenerTiposUsuarionUEVOJuridico();

                        cmbTipoDocumento.DataSource = NegocioInscripcionMinSalud.TipoDocumento.ObtenerTiposDocumentosJuridico();
                    }
                }
                else {
                    cmbTipoUsuario.DataSource = NegocioInscripcionMinSalud.TipoUsuario.ObtenerTiposUsuarioviejo();
                }
          
            }         cmbTipoUsuario.DataTextField = "Nombre";
                    cmbTipoUsuario.DataValueField = "Id";
                    cmbTipoUsuario.DataBind();


            cmbTipoDocumento.DataTextField = "Nombre";
            cmbTipoDocumento.DataValueField = "Id";
            
            cmbTipoDocumento.DataBind();
        }

        public void CargarDatos()
        {
            NegocioInscripcionMinSalud.Participante participante = NegocioInscripcionMinSalud.Participante.ObtenerParticipanteNumeroIdentificacion(IdentificacionParticipante);
            if (participante.IdEstadoUsuario == 0 ||
                participante.IdEstadoUsuario == 1 ||
                participante.IdEstadoUsuario == 3)
            {
                Response.Redirect("~/Aspx/Seguridad/frmLogoOut.aspx");
                return;
            }
            txtCedula.Text = participante.NumeroIdentificacion;
            pnlcontenido.Visible = true;
            //

            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var p = obj.obtenerParticipantexdocumento(Session["IdentificacionParticipante"].ToString());
            if (p.TipoUsuario.ES_NUEVO.HasValue && p.TipoUsuario.ES_NUEVO.Value)
            {
                if (p.TipoUsuario.ES_NATURAL.HasValue && p.TipoUsuario.ES_NATURAL.Value)
                {
                    cmbTipoPerfil.SelectedValue = "1";
                }
                else {
                    cmbTipoPerfil.SelectedValue = "2";
                    cmbTipoPerfil.Enabled = false;
                }
            }else {
                if (Session["IdentificacionParticipante"] != null)
                {
                    Response.Redirect("~/Aspx/Registro/frmUpdatePerfil.aspx?participante=" + IdentificacionParticipante);
                }
            }
            cargarTiposUsuario();
            cmbTipoUsuario.SelectedValue = participante.IdTipoUsuario.ToString();
            txtNombre.Text = participante.Nombres;
            txtApellido.Text = participante.Apellidos;
            txtApellido.Text = participante.NombreRepresentanteLegal;
            cmbTipoDocumento.SelectedValue = participante.IdTipoIdentificacion.ToString();
            cmbTipoDocumentoRepresentanteLegal.SelectedValue = participante.IdTipoIdentificacionRepresentante.ToString();
            txtIdentificacionLegal.Text = participante.NumeroIdentificacionRepresentante;

            if (participante.IdTipoUsuario == 1 || participante.IdTipoUsuario == 10 || participante.IdTipoUsuario == 12 || participante.IdTipoUsuario == 9 || participante.IdTipoUsuario == 3 || participante.IdTipoUsuario == 15)                            
            {
                if (participante.PathNumeroIdentificacion.Trim() != "")
                {
                    ArchivosCargados.Add(participante.PathNumeroIdentificacion);
                    lblArchivoRepresentanteView.InnerText = System.IO.Path.GetFileName(participante.PathNumeroIdentificacion);

                    if (participante.PathNumeroIdentificacion.Contains("\\files\\Aceptado"))
                    {
                        string pathRelativo = participante.PathNumeroIdentificacion.Substring(participante.PathNumeroIdentificacion.IndexOf("\\files\\Aceptado"));
                        pathRelativo = "~" + pathRelativo;
                        lblArchivoRepresentanteView.HRef = pathRelativo;
                    }
                }
            
                lblArchivoCertificacionView.InnerText = "";

                if (participante.IdTipoUsuario == 9)
                {
                    if (participante.Genero == "F")
                    {
                        cmbGenero.SelectedValue = "0";
                    }
                    else
                    {
                        cmbGenero.SelectedValue = "1";
                    }
                    txtNumeroRepresentante.Text = "0";
                }
                else
                {
                    txtNumeroRepresentante.Text = participante.NumeroAsociados.ToString();
                }
            }
            else
            {
                if (participante.PathNumeroIdentificacion.Trim() != "")
                {
                    ArchivosCargados.Add(participante.PathNumeroIdentificacion);
                    lblArchivoRepresentanteView.InnerText = System.IO.Path.GetFileName(participante.PathNumeroIdentificacion);

                    if (participante.PathNumeroIdentificacion.Contains("\\files\\Aceptado"))
                    {
                        string pathRelativo = participante.PathNumeroIdentificacion.Substring(participante.PathNumeroIdentificacion.IndexOf("\\files\\Aceptado"));
                        pathRelativo = "~" + pathRelativo;
                        lblArchivoRepresentanteView.HRef = pathRelativo;
                    }
                }

                if (participante.PathConstitucionGrupo.Trim() != "")
                {
                    ArchivosCargados.Add(participante.PathConstitucionGrupo);
                    lblArchivoCertificacionView.InnerText = System.IO.Path.GetFileName(participante.PathConstitucionGrupo);

                    if (participante.PathConstitucionGrupo.Contains("\\files\\Aceptado"))
                    {
                        string pathRelativo2 = participante.PathConstitucionGrupo.Substring(participante.PathConstitucionGrupo.IndexOf("\\files\\Aceptado"));
                        pathRelativo2 = "~" + pathRelativo2;
                        lblArchivoCertificacionView.HRef = pathRelativo2;
                    }
                }

                txtNumeroRepresentante.Text = participante.NumeroAsociados.ToString();
            }

            txtEmail.Text = participante.Email;
            txtTelefono.Text = participante.Telefono;
            txtTelefonoCelular.Text = participante.Celular;
            txtDireccion.Text = participante.Direccion;
            chkCertifico.Checked = participante.Certifico;
            CheckAutorizoCorreo.Checked = participante.Autorizo;
            txtContrasenaInicial.Text = participante.ContrasenaValor;
            cmbPregunta.SelectedValue = participante.IdPreguntaSecreta.ToString();
            txtRespuestaPregunta.Text = participante.RespuestaPregunta;
            CheckAutorizoCorreo.Checked = participante.AutorizoEmail;
            cmbDepartamento.SelectedValue = participante.IdDepartamento.ToString();
            txtdigitoVerificacion.Text = participante.digitoVerificacion;
            txtdigitoVerificacion2.Text = participante.digitoVerificacionRepresentante;
            this.txtContrasenaInicial.Text = "INS_p";
            this.txtConfirmarContrasena.Text = "INS_p";

            cmbMunicipio.DataSource = NegocioInscripcionMinSalud.Municipio.ObtenerMunicipio(participante.IdDepartamento);
            cmbMunicipio.DataTextField = "Nombre";
            cmbMunicipio.DataValueField = "Id";
            cmbMunicipio.DataBind();

            this.cmbMunicipio.SelectedValue = participante.IdMunicipio.ToString();

            
        }

        protected void Page_Load(object sender, EventArgs e)        
        {
            Response.Redirect("~/frm/registro/frmregistro.aspx");
            if (!IsPostBack)
            {
                Session.Remove("ArchivosCargados");
                cmbTipoUsuario.Attributes.Add("onchange", "AjustePantalla();");
                CargarCombosFormulario();

                if ( Session["IdentificacionParticipante"] != null)
                {
                    txtCedula.ReadOnly = true;                    
                    this.CargarDatos();
                    btnRegistrar.Text = "Actualizar";
                }else{                


                    IdentificacionParticipante = null;
                    btnRegistrar.Text = "Registrarme";
                }
            }
            else
            {
                
                CargarDatosArchivos();
            }
        }

        /// <summary>
        /// Carga los datos de los archivos previamente cargados en la aplicación.
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

                    if (nombreArchivo.StartsWith("1-"))
                    {
                        lblArchivoRepresentanteView.InnerText = nombreArchivo;
                        lblArchivoRepresentanteView.HRef = pathRelativo;
                    }
                    else
                    {
                        lblArchivoCertificacionView.InnerText = nombreArchivo;
                        lblArchivoCertificacionView.HRef = pathRelativo;
                    }
                }

            }
        }


        /// <summary>
        /// Envía un correo electrónico de confirmación de inscripción al participante.
        /// </summary>
        /// <param name="correo">La dirección de correo electrónico del participante.</param>
        private void enviarEmailInscripcion(string correo)
        {
            clsWebUtils email = new clsWebUtils();
            System.Configuration.AppSettingsReader ar = new System.Configuration.AppSettingsReader();
            string url = ar.GetValue("urllocal", typeof(string)).ToString();
            string asunto = "Confirmación inscripción Participación Ciudadana";
            // enmascaramos el correo
            var c = correo.ToCharArray();
            string cr = "";
            for (int k = 0; k < c.Length; k++)
            {
                c[k] = (char)(c[k] + 4);
                cr = cr + c[k];
            }

            string cuerpo = @"Muchas gracias por inscribirse al Sistema de Participación Ciudadana.<br>
                Para continuar con el proceso de registro, haga clic en el siguiente enlace.<a href='" + url + "/aspx/registro/verificar.aspx?token=" + cr + "' >Continuar</a> ";

            email.enviarEmail(asunto, cuerpo, correo);
        }


        /// <summary>
        /// Evento que se activa cuando cambia la selección del departamento. Actualiza el origen de datos del ComboBox de municipios con los municipios correspondientes al departamento seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMunicipio.DataSource = NegocioInscripcionMinSalud.Municipio.ObtenerMunicipio(Convert.ToInt16(cmbDepartamento.SelectedValue));
            cmbMunicipio.DataTextField = "Nombre";
            cmbMunicipio.DataValueField = "Id";
            cmbMunicipio.DataBind();
        }


        protected void salir_Click(object sender, EventArgs e)
        {
            this.DireccionarPagina();
        }

        /// <summary>
        /// Direccióna la página actual en función de la sesión del participante. Si no hay una identificación de participante, redirecciona a la página de inicio de sesión. De lo contrario, redirecciona a la página de opciones de usuario con la identificación del participante.
        /// </summary>
        private void DireccionarPagina()
        {
            Session.Remove("ArchivosCargados");
            if (IdentificacionParticipante == null)
            {
                Response.Redirect("~/Aspx/Seguridad/frmLogin.aspx");
            }
            else
            {
                Response.Redirect("~/Aspx/Registro/frmOpcionesUsuario.aspx?participante=" + IdentificacionParticipante);
            }
        }


        /// <summary>
        /// Maneja el evento de carga de archivos completada para el archivo médico y llama al método DescargarDocumentos para el tipo de documento especificado.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento FileUploadComplete.</param>
        protected void UploadFileMedico_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (UploadFileCertificacion.UploadedFiles.Count() > 0)
            {
                DescargarDocumentos(2);
            }
        }



        /// <summary>
        /// Descarga los documentos según el tipo especificado en una carpeta temporal y actualiza la lista de archivos cargados.
        /// </summary>
        /// <param name="idTipo">El identificador del tipo de documento que se está descargando.</param>
        protected void DescargarDocumentos(Int16 idTipo)
        {
            string archivo = "";
            // Revisamos si ya existe uno anterior
            string archivoEliminar = null;
            foreach (string archivoCargado in ArchivosCargados)
            {
                if (archivoCargado.StartsWith(idTipo.ToString() + "-"))
                {
                    archivoEliminar = archivoCargado;
                    break;
                }
            }

            if (archivoEliminar != null)
            {
                if (System.IO.File.Exists(archivoEliminar))
                {
                    System.IO.File.Delete(archivoEliminar);
                }
                ArchivosCargados.Remove(archivoEliminar);
            }

            // Guardamos el archivo en una carpeta temporal
            switch (idTipo)
            {
                case 1:
                    archivo = idTipo.ToString() + "-" + UploadFileRepresentante.UploadedFiles[0].FileName;
                    break;
                case 2:
                    archivo = idTipo.ToString() + "-" + UploadFileCertificacion.UploadedFiles[0].FileName;
                    break;
                default:
                    return;
            }

            string pathArchivo = Server.MapPath("~/files/Temporal");
            if (!System.IO.Directory.Exists(pathArchivo))
            {
                System.IO.Directory.CreateDirectory(pathArchivo);
            }
            pathArchivo = System.IO.Path.Combine(pathArchivo, archivo);

            // Guardamos el archivo en una carpeta temporal
            switch (idTipo)
            {
                case 1:
                    UploadFileRepresentante.UploadedFiles.First().SaveAs(pathArchivo);
                    break;
                case 2:
                    UploadFileCertificacion.UploadedFiles.First().SaveAs(pathArchivo);
                    break;
            }
            ArchivosCargados.Add(pathArchivo);
        }



        /// <summary>
        /// Valida la subida de archivos y realiza validaciones específicas.
        /// Verifica si se ha ingresado un número de identificación y si existe un participante con ese número.
        /// Realiza ajustes visuales y devuelve un valor booleano que indica si la validación ha sido exitosa.
        /// </summary>
        /// <returns>Un valor booleano que indica si la validación de la subida de archivos ha sido exitosa.</returns>
        private bool ValidarSubirArchivos()
        {
            // Restablece las clases y atributos de estilo para los controles de entrada de texto
            txtCedula.CssClass = "";
            txtCedula.Attributes.Remove("placeholder");

            // Verifica si se ha ingresado un número de identificación
            if (txtCedula.Text == "")
            {
                LblValidacionCampos.Text += "Número de identificación, ";
                txtCedula.Attributes.Add("placeholder", "Ingrese el número de identificación");
                txtCedula.CssClass = "form-control errormin";

                // Ajusta el estilo del control 'UploadFileRepresentante'
                UploadFileRepresentante.Attributes.Add("placeholder", "Ingrese el número de identificación");
                UploadFileRepresentante.NullTextStyle.ForeColor = ColorTranslator.FromHtml("#E4335C");

                return false; // Indica que la validación ha fallado
            }
            else
            {
                // Verifica si ya existe un participante con el número de identificación ingresado
                if (!ValidarExisteParticipante())
                {
                    // Ajusta el estilo del control 'UploadFileRepresentante' si ya existe un participante con el número de identificación ingresado
                    UploadFileRepresentante.Attributes.Add("placeholder", "Ya existe un participante con ese número de identificación");
                    UploadFileRepresentante.NullTextStyle.ForeColor = ColorTranslator.FromHtml("#E4335C");

                    txtCedula.CssClass = "form-control errormin";
                    return false; // Indica que la validación ha fallado
                }
                else
                {
                    txtCedula.CssClass = "form-control";
                    return true; // Indica que la validación ha tenido éxito
                }
            }
        }


        /// <summary>
        /// Maneja el evento de carga de archivos completada del control 'UploadFileRepresentante'.
        /// Comprueba si se han cargado archivos y luego llama al método 'DescargarDocumentos' con un parámetro específico.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento de carga de archivos completada.</param>
        protected void UploadFileRepresentante_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (UploadFileRepresentante.UploadedFiles.Count() > 0)
            {
                DescargarDocumentos(1); // Llama al método 'DescargarDocumentos' con el parámetro 1 si se han cargado archivos en el control 'UploadFileRepresentante'
            }
        }


        protected void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Maneja el evento de cambio de índice seleccionado del control 'cmbTipoPerfil'.
        /// Controla la visibilidad del panel 'pnlcontenido' en función del valor seleccionado en 'cmbTipoPerfil' y luego llama al método 'cargarTiposUsuario'.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        protected void cmbTipoPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoPerfil.SelectedValue == "0")
            {
                pnlcontenido.Visible = false; // Oculta el panel 'pnlcontenido' si el valor seleccionado en 'cmbTipoPerfil' es "0"
            }
            else
            {
                pnlcontenido.Visible = true; // Muestra el panel 'pnlcontenido' si el valor seleccionado en 'cmbTipoPerfil' no es "0"
            }
            cargarTiposUsuario(); // Llama al método 'cargarTiposUsuario' para realizar acciones específicas basadas en la selección de 'cmbTipoPerfil'
        }


        //protected void grdRoles_ItemDataBound(object sender, DataListItemEventArgs e)
        //{
        //   var grillaObj= e.Item.FindControl("grdDetalle");
        //    if (grillaObj == null) return;

        //    var grilla = (DataList)grillaObj;

        //    var check = (CheckBox)e.Item.FindControl("chkPerfil");
        //    NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
        //     grilla.DataSource=  obj.obtenerArchivosPorPerfil(int.Parse(check.ValidationGroup));
        //    grilla.DataBind();

        //}

        //protected void UploadFileGenerico_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        //{
        //    //if (UploadFileGenerico.UploadedFiles.Count() > 0)
        //    //{
        //    //    DescargarDocumentos(3);
        //    //}
        //}
    }

}