using NegocioInscripcionMinSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace InscripcionMinSalud.frm.ws
{




    /// <summary>
    /// Summary description for ws
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ws : System.Web.Services.WebService
    {
        public class combo
        {
            public string codigo
            {
                set; get;
            }

            public string nombre
            {
                set; get;
            }

        }

        [WebMethod()]
        public static string getAttachmentStatus(string pAttachment_id, int idproyecto, string uploadedfilename)
        {
            /* Inicialización de variables */
            string sourcePath = "";
            string destinationPath = "";
            string destinationURL = "";
            bool showAdvancedForm = false;

            int attachment_id = 0;

            String rootPath = HttpContext.Current.Server.MapPath("~");
            String uploadFolderName = "/uploads/";

            //if (HttpContext.Current.Session["user_id"] != null && Convert.ToInt32(HttpContext.Current.Session["user_id"]) > 0)
            //{
            //    /* Si el usuario está autenticado verificamos el rol y el permiso asignado para la visualización del listado */
            //    User userObj = new User();
            //    userObj.user_id = Convert.ToInt32(HttpContext.Current.Session["user_id"]);

            //    if (userObj.checkPermission("ver-formulario-gestion-solicitud"))
            //    {
            //        showAdvancedForm = true;
            //    }
            //}

            ///* Valida si el parametro del id del adjunto es numerico caso en el cual se trata como 
            // * un adjunto normal de la aplicación, o si tiene una cadena de caracteres se trata como
            // * un adjunto de personal (hoja de vida, contrato o cédula)
            // */
            //if (pAttachment_id.Contains("identification") || pAttachment_id.Contains("cv") || pAttachment_id.Contains("contract"))
            //{
            //    int project_staff_id = 0;
            //    string project_staff_attachment_type = "";
            //    string[] attachment_id_part;
            //    string attachmentName = "";

            //    if (idproyecto > 0)
            //    {
            //        attachment_id_part = pAttachment_id.Split(new string[] { "_" }, StringSplitOptions.None);

            //        project_staff_id = Convert.ToInt32(attachment_id_part[0]);
            //        project_staff_attachment_type = attachment_id_part[1];

            //        /* Obtenemos la extensión del archivo cargado */
            //        string[] uploadedfilenamesplit = uploadedfilename.Split('.');
            //        string extension = uploadedfilenamesplit[(uploadedfilenamesplit.Count() - 1)];

            //        /* Se definen las rutas del archivo de origen y destino */

            //        if (producer_id != 0)
            //        {
            //            sourcePath = @rootPath + "uploads\\" + idproyecto + "\\" + producer_id + "\\" + uploadedfilename;
            //            destinationPath = @rootPath + "uploads\\" + idproyecto + "\\" + producer_id + "\\" + pAttachment_id + "." + extension;
            //            destinationURL = @uploadFolderName + idproyecto + producer_id + "/" + pAttachment_id + "." + extension;
            //        }
            //        else
            //        {
            //            sourcePath = @rootPath + "uploads\\" + idproyecto + "\\" + uploadedfilename;
            //            destinationPath = @rootPath + "uploads\\" + idproyecto + "\\" + pAttachment_id + "." + extension;
            //            destinationURL = @uploadFolderName + "/" + idproyecto + "/" + pAttachment_id + "." + extension;
            //        }

            //        string unic = DateTime.Now.Ticks.ToString().Substring(8);
            //        sourcePath = @rootPath + "uploads\\" + idproyecto + "\\" + uploadedfilename;
            //        destinationPath = @rootPath + "uploads\\" + idproyecto + "\\" + unic + pAttachment_id + "." + extension;
            //        destinationURL = @uploadFolderName + idproyecto + "/" + unic + pAttachment_id + "." + extension;

            //        try
            //        {
            //            /* Se verifica si el archivo ya existe en la carpeta y de ser así se elimina
            //             * para permitir la carga del nuevo archivo */
            //            // Ensure that the target does not exist.
            //            if (File.Exists(destinationPath))
            //            {
            //                File.Delete(destinationPath);
            //            }

            //            /* renombramos el archivo recien cargado */
            //            File.Move(sourcePath, destinationPath);
            //        }
            //        catch (Exception ex)
            //        {
            //            return "Error: " + ex.Message;
            //        }

            //        /* Instancia el objeto que representa la información de una persona en el proyecto */
            //        Staff staffObj = new Staff(project_staff_id);

            //        //Inicializamos variable para definir el nombre del checkbox
            //        string staff_name_checkbox = "";

            //        /* Se guarda la ruta al archivo en el campo correspondiente según
            //         * el nombre del archivo */
            //        switch (project_staff_attachment_type)
            //        {
            //            case "identification":
            //                staffObj.project_staff_identification_attachment = destinationURL;
            //                attachmentName = "Cédula";
            //                staff_name_checkbox = "identification_attachment_approved_" + project_staff_id;
            //                break;
            //            case "cv":
            //                staffObj.project_staff_cv_attachment = destinationURL;
            //                attachmentName = "Hoja de Vida";
            //                staff_name_checkbox = "cv_attachment_approved_" + project_staff_id;
            //                break;
            //            case "contract":
            //                staffObj.project_staff_contract_attachment = destinationURL;
            //                attachmentName = "Contrato";
            //                staff_name_checkbox = "contract_attachment_approved_" + project_staff_id;
            //                break;
            //            default:
            //                break;
            //        }

            //        /* Se guarda la información del adjunto en la base de datos */
            //        staffObj.Save();

            //        if (showAdvancedForm)
            //        {
            //            /* Devuelve el checkbox de aprobacion y el vínculo de acceso al archivo recien cargado */
            //            return "<input type=\"checkbox\" name=\"" + staff_name_checkbox + "\" value=\"" + project_staff_id + "\" />" +
            //                   "<a target=\"_blank\"  title='" + uploadedfilename + "' href=\"" + destinationURL + " \">" + attachmentName + "</a>";
            //        }
            //        else
            //        {
            //            /* Devuelve el vínculo de acceso al archivo recien cargado */
            //            return "<a target=\"_blank\"  title='" + uploadedfilename + "' href=\"" + destinationURL + " \">" + attachmentName + "</a>";
            //        }
            //    }
            //}
            //else
            //{
            //    attachment_id = Convert.ToInt32(pAttachment_id);

            //    /* Instancia la clase Attachment */
            //    Attachment attachmentObj = new Attachment();
            //    attachmentObj.LoadAttachment(attachment_id);
            //    ProjectAttachment projectAttachmentObj = new ProjectAttachment();

            //    /* Se valida que se tenga un proyecto en sesión */
            //    if (idproyecto > 0)
            //    {
            //        if (producer_id == 0)
            //        {
            //            projectAttachmentObj.LoadProjectAttachment(idproyecto, attachment_id);
            //        }
            //        else
            //        {
            //            projectAttachmentObj.loadAttachmentByFhaterAndProducerId(idproyecto, attachment_id, producer_id);
            //        }

            //        /* Obtenemos la extensión del archivo cargado */
            //        string[] uploadedfilenamesplit = uploadedfilename.Split('.');
            //        string extension = uploadedfilenamesplit[(uploadedfilenamesplit.Count() - 1)];

            //        /* Se definen las rutas del archivo de origen y destino */
            //        string unic = DateTime.Now.Ticks.ToString().Substring(8);
            //        if (producer_id != 0)
            //        {
            //            sourcePath = @rootPath + "uploads\\" + idproyecto + "\\" + producer_id + "\\" + uploadedfilename;
            //            destinationPath = @rootPath + "uploads\\" + idproyecto + "\\" + producer_id + "\\" + unic + attachmentObj.attachment_machine_name + "." + extension;
            //            destinationURL = @uploadFolderName + idproyecto + "/" + producer_id + "/" + unic + attachmentObj.attachment_machine_name + "." + extension;
            //        }
            //        else
            //        {
            //            sourcePath = @rootPath + "uploads\\" + idproyecto + "\\" + uploadedfilename;
            //            destinationPath = @rootPath + "uploads\\" + idproyecto + "\\" + unic + attachmentObj.attachment_machine_name + "." + extension;
            //            destinationURL = @uploadFolderName + idproyecto + "/" + unic + attachmentObj.attachment_machine_name + "." + extension;
            //        }

            //        try
            //        {
            //            /* Se verifica si el archivo ya existe en la carpeta y de ser así se elimina
            //             * para permitir la carga del nuevo archivo */
            //            // Ensure that the target does not exist.
            //            if (File.Exists(destinationPath))
            //            {
            //                File.Delete(destinationPath);
            //            }

            //            /* renombramos el archivo recien cargado */
            //            File.Move(sourcePath, destinationPath);
            //        }
            //        catch (Exception ex)
            //        {
            //            return "Error: " + ex.Message;
            //        }

            //        /* Se guarda la información del adjunto en la base de datos */
            //        projectAttachmentObj.project_id = idproyecto;
            //        if (producer_id != 0)
            //        {
            //            projectAttachmentObj.project_attachement_producer_id = producer_id;
            //        }
            //        projectAttachmentObj.attachment = new Attachment(attachment_id);
            //        projectAttachmentObj.project_attachment_path = destinationURL;
            //        projectAttachmentObj.project_attachment_date = System.DateTime.Now;
            //        projectAttachmentObj.nombre_original = uploadedfilename;
            //        projectAttachmentObj.Save();

            //        //Validamos si ya existe un project_attachment_id asignado, si no, volvemos a cargar el proyecto
            //        //para obtener el nuevo id
            //        if (projectAttachmentObj.project_attachment_id == 0)
            //        {
            //            projectAttachmentObj.LoadProjectAttachment(idproyecto, attachment_id);
            //        }

            //        if (showAdvancedForm)
            //        {
            //            string attachment_checkbox_approved = "<input type=\"checkbox\" name=\"attachment_approved_" + projectAttachmentObj.project_attachment_id + "\" value=\"" + projectAttachmentObj.project_attachment_id + "\"/>";
            //            string attachment_file_link = "<a target=\"_blank\"  title='" + uploadedfilename + "' href=\"" + destinationURL + "\">" + attachmentObj.attachment_name + "</a>";

            //            /* Devuelve el vínculo de acceso al archivo recien cargado */
            //            return attachment_checkbox_approved + attachment_file_link;
            //        }
            //        else
            //        {
            //            /* Devuelve el vínculo de acceso al archivo recien cargado */
            //            return "<a target=\"_blank\"  title='" + uploadedfilename + "' href=\"" + destinationURL + " \">" + attachmentObj.attachment_name + "</a>";
            //        }
            //    }
            //}

            return "";
        }

        [WebMethod]
        public string autenticar(string txtUsuario, string password)
        {
            clsNegocio obj = new clsNegocio();
            var usuario = obj.obtenerRegistroxUsuario(txtUsuario);
            string respuesta = "";
            if (usuario != null)
            {
                if (usuario.COD_ESTADO_REGISTRO == 1)
                {
                    respuesta = "El usuario no ha validado el corrreo electrónico";
                }
                else if (usuario.COD_ESTADO_REGISTRO == 2 || usuario.COD_ESTADO_REGISTRO == 4)
                {
                    respuesta = "El registro del usuario esta en proceso de validación";
                }
                else if (usuario.COD_ESTADO_REGISTRO == 3)
                {
                    respuesta = "El registro del usuario esta en proceso de validación";
                }
                else if (usuario.COD_ESTADO_REGISTRO == 5)
                {
                    //vaidamos que solo puedan ingresar las sociedades cientificas
                    if (usuario.ES_PERSONA_NATURAL)
                    {
                        return "Solo pueden ingresar las Asociaciones y agremiaciones.";
                    }else if(usuario.COD_TIPO_JURIDICO.HasValue == false ||
                        (usuario.COD_TIPO_JURIDICO.Value == 2 ||
                        usuario.COD_TIPO_JURIDICO.Value == 3 ||
                        usuario.COD_TIPO_JURIDICO.Value > 31
                        )  
                    )
                    {
                        return "Solo pueden ingresar las Asociaciones y agremiaciones.";
                    }

                    if (password.Trim() == usuario.CONTRASENA.Trim())
                    {
                        respuesta += "OK";
                        respuesta += "|codr:" + usuario.COD_REGISTRO;
                        respuesta += "|usuario:" + usuario.NOMBRE_USUARIO;
                        respuesta += "|documento:" + usuario.DOCUMENTO;


                        if (usuario.ES_PERSONA_NATURAL)
                            respuesta += "|nombre:" + usuario.NOMBRE.Trim() + " " + usuario.APELLIDOS;
                        else
                            respuesta += "|nombre:" + usuario.NOMBRE.Trim();

                        respuesta += "|correo:" + usuario.CORREO;
                     
                    }
                    else
                    {

                        respuesta = "Usuario y/o contraseña invalido!";
                    }
                }
                else
                {
                    respuesta = "El usuario cancelo la cuenta";
                }
            }else {
                respuesta = "Usuario no existe";
            }
            return respuesta;
        }

        [WebMethod]
        public string obtenerPerfil(int padre)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerPerfil(padre);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.COD_TIPO_JURIDICO.ToString();
                c.nombre = item.NOMBRE_TIPO_JURIDICO;
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }

        [WebMethod]
        public string obtenerCups(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerCups(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.COD_CUPS.ToString();
                c.nombre = item.CUPS1.Trim() + " (" + item.COD_CUPS.ToString().Trim() + ")";
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }

        [WebMethod]
        public string obtenerCupsEHF(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerCupsEHF(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.COD_CUPS.ToString();
                c.nombre = item.CUPS1.Trim() + "-" + item.COD_CUPS.ToString().Trim();
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }


        [WebMethod]
        public string obtenerDCI(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerDCI(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.COD_MEDICAMENTO.ToString();
                c.nombre = item.MEDICAMENTO.Trim() + " (" + item.COD_MEDICAMENTO.ToString().Trim() + ")";
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }

        [WebMethod]
        public string obtenerCIE(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerCIE(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.COD_CIE10.ToString();
                //c.nombre = item.NOMBRE_CIE10.Trim() + " (" + item.COD_CIE10.ToString().Trim() + ")";
                c.nombre = item.COD_CIE10.ToString() + "-" + item.NOMBRE_CIE10.Trim();
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }



        [WebMethod]
        public string obtenerEnfermedadListado(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerNombreListado(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.ID.ToString();
                //c.nombre = item.NOMBRE_CIE10.Trim() + " (" + item.COD_CIE10.ToString().Trim() + ")";
                c.nombre = item.ID.ToString()+";"+item.Enfermedad.Trim() + ";" + item.CIE.ToString().Trim();
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }

        [WebMethod]
        public string obtenerCodigoEnfermedadListado(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerCodigoListado(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.ID.ToString();
                //c.nombre = item.NOMBRE_CIE10.Trim() + " (" + item.COD_CIE10.ToString().Trim() + ")";
                c.nombre = item.ID.ToString() + ";" + item.Enfermedad.Trim() + ";" + item.CIE.ToString().Trim();
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }

        [WebMethod]
        public string obtenerCIEEnfermedadListado(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerCIEListado(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.ID.ToString();
                //c.nombre = item.NOMBRE_CIE10.Trim() + " (" + item.COD_CIE10.ToString().Trim() + ")";
                c.nombre = item.ID.ToString() + ";" + item.Enfermedad.Trim() + ";" + item.CIE.ToString().Trim();
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }

        [WebMethod]
        public string obtenerEnfermedad(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerCIE(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.COD_CIE10.ToString();
                c.nombre = item.NOMBRE_CIE10.Trim() + " (" + item.COD_CIE10.ToString().Trim() + ")";
                //c.nombre = item.ID.ToString() + ";" + item.Enfermedad.Trim() + ";" + item.CIE.ToString().Trim();
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }

        [WebMethod]
        public string obtenerMedicamento(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerMedicamentos(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.COD_MEDICAMENTOS.ToString().Trim();
                c.nombre = item.NOMBRE_MEDICAMENTOS.Trim() + " (" + item.COD_MEDICAMENTOS.ToString().Trim()+ ")";
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }

        [WebMethod]
        public string obtenerProcedimientos(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerPROCEDIMIENTO(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.COD_PROCEDIMIENTO.ToString();
                // c.nombre = item.NOMBRE_PROCEDIMIENTO.Trim() + " (" + item.COD_PROCEDIMIENTO.ToString().Trim() + ")";
                c.nombre = item.NOMBRE_PROCEDIMIENTO.Trim();
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }

        [WebMethod]
        public string obtenerTipoDocumentoJuridico(int tipoPersona)
        {
            bool esActa = false;
            if (tipoPersona == 7 || tipoPersona == 4 || tipoPersona == 6)
            {
                esActa = true;
            }
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerTipoDocumentoJuridico(esActa);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.Id.ToString();
                c.nombre = item.Nombre;
                lst.Add(c);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }

        [WebMethod]
        public string obtenerPais()
        {
            return "";
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var v= obj.obtenerPais();
            //return serializer.Serialize(v);
        }

        [WebMethod]
        public string obtenerEspecialidad(string criterio)
        {
            NegocioInscripcionMinSalud.data.clsNegocio obj = new NegocioInscripcionMinSalud.data.clsNegocio();
            var v = obj.obtenerEspecialidad(criterio);
            List<combo> lst = new List<combo>();
            foreach (var item in v)
            {
                combo c = new combo();
                c.codigo = item.COD_ESPECIALIDAD.ToString();
                c.nombre = item.NOMBRE_ESPECIALIDAD.Trim(); // + " (" + item.COD_ESPECIALIDAD.ToString().Trim() + ")";
                lst.Add(c);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(lst);
        }


    }
}
