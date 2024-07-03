<%@ Page Language="C#" MasterPageFile="~/frm/master/basicMaster.Master" AutoEventWireup="true" CodeBehind="frmParticipante.aspx.cs" Inherits="InscripcionMinSalud.Aspx.frmParticipante" ValidateRequest="false" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Registro Participación Ciudadana</title>
       
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="../../css/bootstrap-theme.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" media="all">


    <link rel="shortcut icon" href="../../img/EscudoNal.png" />
    
    
    
    <script>
         function CalcTotalAmt()
         {
 
             var combo = document.getElementById('<%= cmbTipoDocumento.ClientID  %>');
             if (combo == null) return;
            var tipoUsuario = combo.options[combo.selectedIndex].value;
            var texto = document.getElementById('<%= txtCedula.ClientID  %>');
            var textoVer = document.getElementById('<%= txtdigitoVerificacion.ClientID  %>');
            var label = document.getElementById('<%= lblSeparadoDocumento.ClientID  %>');
                textoVer.style.display = "none";
                label.style.display = "none";
                texto.style.width = "330px";
            if (tipoUsuario.toString() == '9' || tipoUsuario.toString() == '10' || tipoUsuario.toString() == '11') {
                //nit rit rut
                textoVer.style.display = "";
                label.style.display = "";
                texto.style.width = "290px";
            }
        }

           function CalcTotalAmt2()
        {
    
               var combo = document.getElementById('<%= cmbTipoDocumentoRepresentanteLegal.ClientID  %>');
               if (combo == null) return;
            var tipoUsuario = combo.options[combo.selectedIndex].value;
            var texto = document.getElementById('<%= txtIdentificacionLegal.ClientID  %>');
            var textoVer = document.getElementById('<%= txtdigitoVerificacion2.ClientID  %>');
            var label = document.getElementById('<%= lblSeparadoDocumento2.ClientID  %>');
                textoVer.style.display = "none";
                label.style.display = "none";
                texto.style.width = "330px";
            if (tipoUsuario.toString() == '9' || tipoUsuario.toString() == '10' || tipoUsuario.toString() == '11') {
                //nit rit rut
            //    textoVer.style.visibility = "";
                label.style.display = "";
                texto.style.width = "290px";
                texto.style.display="inline";
            } 
           }


           function validarpassword(event) {
               var texto = document.getElementById('<%= this.txtContrasenaInicial.ClientID%>');
               var div = document.getElementById("lblBarStrength");
               var nivel = 0;
            
               if (texto.value.length < 8) {
                   nivel = 1
               } else {
                   nivel = 2;
               }
               //var matchx= texto.match(/^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])([a-zA-Z0-9]{8,})$/);
               if (nivel == 2 && texto.value.length > 10 )
               {
                   nivel = 3;
               }
                if (texto.value.length ==0) {
                   nivel = 0;
               }
               if (nivel == 0) {
                   div.innerText = '';
               }
                   if(nivel == 1)
                   {
                       div.innerText = '<div style="width:150px;float:left;"><font color="red">Seguridad Baja</font></div>   <div style="width:30px;height:20px;background-color:red;float:left;"></div>';
                   }
                   if(nivel == 2)
                   {
                       div.innerText = '<div style="width:150px;float:left;"><font color="blue">Seguridad Aceptable</font></div> <div style="width:30px;height:20px;background-color:blue;float:left;"></div>  <div style="width:30px;height:20px;background-color:blue;float:left;margin-left:5px;"></div>';
                   }
                   if(nivel == 3)
                   {
                       div.innerText = '<div style="width:150px;float:left;"><font color="green">Contraseña Segura</font></div> <div style="width:30px;height:20px;background-color:green;float:left;"></div> <div style="width:30px;height:20px;background-color:green;float:left;margin-left:5px;"></div> <div style="width:30px;height:20px;background-color:green;float:left;margin-left:5px;"></div>';
                   }
                   div.innerHTML = div.innerText;

               //si es nit validamos que la cantidad sea la correcta

               return true;
           }

        function validarTexto(event) {
            var combo = document.getElementById('<%= cmbTipoDocumento.ClientID %>');
            var tipoUsuario = combo.options[combo.selectedIndex].value;
            var respuesta = false;
            if (tipoUsuario.toString() == '1') {//cedula
                respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 31;
            }
            if (tipoUsuario.toString() == '5' || tipoUsuario.toString() == '3') {
                //extranjeria y pasaporte
                respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 31
                || (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122);
                //del 48 al 57    del 65 al 90      del 97 al 122
            }

            if (tipoUsuario.toString() == '9' || tipoUsuario.toString() == '10' || tipoUsuario.toString() == '11') {
                //nit rit rut
                respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 31;//|| event.charCode.toString() == '45';
                //validamos que solo ingrese ub digito de verificacion
                var texto = document.getElementById("txtCedula");
                if (texto.value.indexOf('-') > 0 && texto.value.indexOf('-') + 1 < texto.value.length) {
                    respuesta = false;
                }

            }


            //si es nit validamos que la cantidad sea la correcta

            return respuesta;
        }

        function validarTexto2(event) {
            var combo = document.getElementById('<%= cmbTipoDocumentoRepresentanteLegal.ClientID %>');
            var tipoUsuario = combo.options[combo.selectedIndex].value;
            var respuesta = false;
            if (tipoUsuario.toString() == '1') {//cedula
                respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 31;
            }
            if (tipoUsuario.toString() == '5' || tipoUsuario.toString() == '3') {
                //extranjeria y pasaporte
                respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 31
                || (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122);
                //del 48 al 57    del 65 al 90      del 97 al 122
            }

            if (tipoUsuario.toString() == '9' || tipoUsuario.toString() == '10' || tipoUsuario.toString() == '11') {
                //nit rit rut
                respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 31;//|| event.charCode.toString() == '45';
                //validamos que solo ingrese ub digito de verificacion
                var texto = document.getElementById("txtIdentificacionLegal");
                if (texto.value.indexOf('-') > 0 && texto.value.indexOf('-') + 1 < texto.value.length) {
                    respuesta = false;
                }

            }


            //si es nit validamos que la cantidad sea la correcta

            return respuesta;
        }

        function validarSoloLetras(event) {

            var respuesta = false;

            respuesta =
 (event.charCode >= 65 && event.charCode <= 90)
||
 (event.charCode >= 48 && event.charCode <= 57)
||
 (event.charCode >= 97 && event.charCode <= 122)
||
 (event.charCode >= 160 && event.charCode <= 164)//tildes

|| event.charCode <= 32 //incluye espacio
            || event.charCode == 127 //suprimir
            || event.charCode == 241 //ñ
            || event.charCode == 209 //Ñ
            || event.charCode == 130 //Ñ
            ;


            return respuesta;
        }

        function validarTextoVerificacion(event) {
            var respuesta = false;

            respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 32;
            var texto = document.getElementById("txtdigitoVerificacion");
            if (texto.value.length == 1) {
                respuesta = false;
            }
            return respuesta;
        }

        function validarTextoVerificacion2(event) {
            var respuesta = false;

            respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 32;
            var texto = document.getElementById("txtdigitoVerificacion2");
            if (texto.value.length == 1) {
                respuesta = false;
            }
            return respuesta;
        }

        function validarTelefono(event) {
            var respuesta = false;

            respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 32 || event.charCode.toString() == '45';

            return respuesta;
        }


        function validarNumero(event) {
            var respuesta = false;

            respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 32;

            return respuesta;
        }

           function AjustePantalla() {
               CalcTotalAmt();
               CalcTotalAmt2();
    
               var e = document.getElementById('<%= cmbTipoUsuario.ClientID %>');
               if(e == null)return;
               var tipoUsuario = e.options[e.selectedIndex].value;
               var fl1 = document.getElementById('<%= flInformacionAcceso.ClientID %>');
               var fl2 = document.getElementById('<%= flInformacionParticipante.ClientID %>');
               if (tipoUsuario != "0") {
                   fl1.style.display = ''
                   fl2.style.display = '';
               } else {
                   fl1.style.display = 'none'
                   fl2.style.display = 'none';
               }
              
//alert(tipoUsuario.toString());

               var lblNombre = document.getElementById("lblNombre");
               var lblApellido = document.getElementById("lblApellido");

                var imgNombre = document.getElementById('<%= imgNombre.ClientID %>');
                var imgNombreOrganizacion = document.getElementById('<%= imgNombreOrganizacion.ClientID %>');
                var imgNombreSecretaria = document.getElementById('<%= imgNombreSecretaria.ClientID %>');
                imgNombreOrganizacion.style.display ='none';
                imgNombre.style.display = 'none';
                imgNombreSecretaria.style.display = 'none';

                var lblIdentificacionLegal = document.getElementById("lblIdentificacionLegal");
               var txtIdentificacionLegal = document.getElementById('<%= txtIdentificacionLegal.ClientID %>');

               var lblTipoDocumentoRepresentanteLegal = document.getElementById("lblTipoDocumentoRepresentanteLegal");
                var cmbTipoDocumentoRepresentanteLegal = document.getElementById('<%= cmbTipoDocumentoRepresentanteLegal.ClientID %>');

               
                var lblDepartamento = document.getElementById('<%= lblDepartamento.ClientID %>');
                var lblDireccion = document.getElementById('<%= lblDireccion.ClientID %>');
                var lblCiudad = document.getElementById('<%= lblCiudad.ClientID %>');

                var lblGenero = document.getElementById('<%= lblGenero.ClientID %>');
                var cmbGenero = document.getElementById('<%= cmbGenero.ClientID %>');

                var lblNumeroRepresentante = document.getElementById('<%= lblNumeroRepresentante.ClientID %>');
                var txtNumeroRepresentante = document.getElementById('<%= txtNumeroRepresentante.ClientID %>');

               if (tipoUsuario == "19" || tipoUsuario == "20" || tipoUsuario == "21" || tipoUsuario == "22" || tipoUsuario == "23" || tipoUsuario == "41") {
                        lblNombre.innerText = "Nombres <span>(*)</span>";
                        lblNombre.innerHTML = lblNombre.innerText;
                        imgNombre.style.display ='';

                        lblApellido.innerText = "Apellidos <span>(*)</span>";
                       lblApellido.innerHTML = lblApellido.innerText;

                        lblIdentificacionLegal.style.display = "none";
                        txtIdentificacionLegal.style.display = "none";

                        lblTipoDocumentoRepresentanteLegal.style.display = "none";
                        cmbTipoDocumentoRepresentanteLegal.style.display = "none";

                        lblDepartamento.innerText = "Departamento residencia <span>(*)</span>";
                        lblDepartamento.innerHTML = lblDepartamento.innerText;

                        lblCiudad.innerText = "Ciudad residencia <span>(*)</span>";
                        lblCiudad.innerHTML = lblCiudad.innerText;

                        lblDireccion.innerText = "Dirección residencia <span>(*)</span>";
                        lblDireccion.innerHTML = lblDireccion.innerText;

                        lblGenero.style.display = "";
                        cmbGenero.style.display = "";

                        lblNumeroRepresentante.style.display = "none";
                        txtNumeroRepresentante.style.display = "none";
                   
                        document.getElementById('<%= lblCertificacionConstitucion.ClientID %>').style.display = "none";
                   document.getElementById('<%= divUploadFileCertificacion.ClientID %>').style.display = "none";
                   document.getElementById('<%= lblArchivoCertificacionView.ClientID %>').style.display = "none";
                   document.getElementById('<%= lblCertificacionRepresentanteLegal.ClientID %>').style.display = "none";
                   document.getElementById('<%= divUploadFileRepresentante.ClientID %>').style.display = "none";
                   document.getElementById('<%= lblArchivoRepresentanteView.ClientID %>').style.display = "none";
                    }
            //    //1 - 10 - 12 - 9 - 3 -15 Un documento
               else 
                {
               
                        lblNombre.innerText = "Nombre organización <span>(*)</span>";
                        lblNombre.innerHTML = lblNombre.innerText;
                        imgNombreOrganizacion.style.display ='';

                        lblApellido.innerText = "Nombre del representante legal o presidente <span>(*)</span>";
                        lblApellido.innerHTML = lblApellido.innerText;

                        lblIdentificacionLegal.style.display = "";
                       txtIdentificacionLegal.style.display = "";

                        lblTipoDocumentoRepresentanteLegal.style.display = "";
                        cmbTipoDocumentoRepresentanteLegal.style.display = "";

                        if (tipoUsuario == "15") {
                            lblDepartamento.innerText = "Departamento empresa o industria <span>(*)</span>";
                            lblDepartamento.innerHTML = lblDepartamento.innerText;

                            lblCiudad.innerText = "Ciudad empresa o industria  <span>(*)</span>";
                            lblCiudad.innerHTML = lblCiudad.innerText;
                         }
                        else if (tipoUsuario == "14") {
                                lblDepartamento.innerText = "Departamento secretaria <span>(*)</span>";
                                lblDepartamento.innerHTML = lblDepartamento.innerText;

                                lblCiudad.innerText = "Ciudad secretaria  <span>(*)</span>";
                                lblCiudad.innerHTML = lblCiudad.innerText;

                                lblCertificacionRepresentanteLegal.style.display = "none";
                                imAdjuntarArchivoRepresentanteLegal.style.display = "none";
                                lblArchivoRepresentanteLegal.style.display = "none";

                                lblNombre.innerText = "Nombre de la secretaria <span>(*)</span>";
                                lblNombre.innerHTML = lblNombre.innerText;
                                imgNombreSecretaria.style.display ='visible';

                                lblApellido.innerText = "Nombre del secretario <span>(*)</span>";
                                lblApellido.innerHTML = lblApellido.innerText;
                        }
                        else {
                            lblDepartamento.innerText = "Departamento asociación <span>(*)</span>";
                            lblDepartamento.innerHTML = lblDepartamento.innerText;

                            lblCiudad.innerText = "Ciudad asociación <span>(*)</span>";
                            lblCiudad.innerHTML = lblCiudad.innerText;
                        }

                        lblDireccion.innerText = "Dirección física urbana o rural de la asociación, organización, sociedad o empresa <span>(*)</span>";
                        lblDireccion.innerHTML = lblDireccion.innerText;

                        lblGenero.style.display = "none";
                        cmbGenero.style.display = "none";

                        lblNumeroRepresentante.style.display = "";
                        txtNumeroRepresentante.style.display = "";                        
       

                }
            
           }

        function getRootWebSitePath()
        {
            var _location = document.location.toString();
            var applicationNameIndex = _location.indexOf('/', _location.indexOf('://') + 3);
            var applicationName = _location.substring(0, applicationNameIndex) + '/';
            var webFolderIndex = _location.indexOf('/', _location.indexOf(applicationName) + applicationName.length);
            var webFolderFullPath = _location.substring(0, webFolderIndex);

            return webFolderFullPath;
        }

        function UpdateUploadButtonCertificacion(s, e) {
            var text = s.GetText(e.inputIndex);          
            var file = text.replace("fakepath", "");
            var fileFin = file.replace("C:", "");
            fileFin = fileFin.replace("//", "");
            fileFin = fileFin.replace("//", "");
            fileFin = fileFin.replace("\\", "");
            fileFin = fileFin.replace("\\", "");
            var webSite = getRootWebSitePath();            
            var pathRelativo = webSite + "//files//Temporal//2-" + fileFin;
            document.getElementById('lblArchivoCertificacionView').innerHTML = "Archivo Cargado: " + fileFin;
            document.getElementById('lblArchivoCertificacionView').href = pathRelativo;
        }    

	function UpdateUploadButtonRepresentante(s, e) {
            var text = s.GetText(e.inputIndex);          
            var file = text.replace("fakepath", "");
            var fileFin = file.replace("C:", "");
            fileFin = fileFin.replace("//", "");
            fileFin = fileFin.replace("//", "");
            fileFin = fileFin.replace("\\", "");
            fileFin = fileFin.replace("\\", "");
            var webSite = getRootWebSitePath();            
            var pathRelativo = webSite + "//files//Temporal//1-" + fileFin;
            document.getElementById('lblArchivoRepresentanteView').innerHTML = "Archivo Cargado: " + fileFin;
            document.getElementById('lblArchivoRepresentanteView').href = pathRelativo;
	}

	function UpdateUploadButtonGenerico(s, e) {
	    var text = s.GetText(e.inputIndex);
	    var file = text.replace("fakepath", "");
	    var fileFin = file.replace("C:", "");
	    fileFin = fileFin.replace("//", "");
	    fileFin = fileFin.replace("//", "");
	    fileFin = fileFin.replace("\\", "");
	    fileFin = fileFin.replace("\\", "");
	    var webSite = getRootWebSitePath();
	    var pathRelativo = webSite + "//files//Temporal//1-" + fileFin;
	    document.getElementById('lblArchivoGenericoView').innerHTML = "Archivo Cargado: " + fileFin;
	    document.getElementById('lblArchivoGenericoView').href = pathRelativo;
	}
    </script>


  
    <%--<script type="text/javascript" src="../../Scripts/jquery-1.8.2.min.js"></script>--%>


   
    <script>
        $(document).ready(function () {
            $('.tooltip').tooltipster();
            $('.fancybox').fancybox();
            AjustePantalla();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    
    <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">En este módulo usted podrá inscribirse, seleccione el tipo de usuario y complete el formulario</h2>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
             <div class="col-md-6 col-md-offset-3">
                <h3 class="separation-title__another">Regístrese  </h3>

<p class="centerp">Los campos marcados con <strong> (*) son obligatorios,</strong> seleccione el tipo de usuario y diligencie el formulario </p>
<p class="centerp"><b>Advertencia:</b> Esta aplicativo no es compatible con Internet Explorer 11. Por favor utilizar Internet Explorer 10, Internet Explorer EDGE, Google Chrome o Firefox</p>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">

                    Seleccione el tipo de Perfil
                    <asp:DropDownList runat="server" ID="cmbTipoPerfil" AutoPostBack="true" OnSelectedIndexChanged="cmbTipoPerfil_SelectedIndexChanged"
                        >
                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Natural" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Juridica" Value="2"></asp:ListItem>
                    </asp:DropDownList>
            <asp:Panel runat="server" ID="pnlcontenido" Visible="false">
                        <div id="page">
                            <fieldset class="form-group">
                                <legend><span>1. Tipo usuario</span></legend>
                                <p>Seleccione el tipo de usuario al cual usted pertenece</p>
                            
                                
                                 <label for="cmbTipoUsuario">Seleccione tipo Usuario<span> (*)</span>  
                                     </label>
                                   
                                   <asp:Image  runat="server" ImageUrl="~/images/tooltipq.png" ID="imgTooltip"
                                    class="tooltip" title="Seleccione un item de la lista de elementos" />

                                <asp:DropDownList runat="server" ClientIDMode="Static"  TabIndex="0" ID="cmbTipoUsuario"  Width="100%" CssClass="form-control" 
                                     onchange="AjustePantalla();" OnSelectedIndexChanged="cmbTipoUsuario_SelectedIndexChanged"></asp:DropDownList>  
                                
                              
                            </fieldset>
                            <fieldset runat="server" id="flInformacionParticipante" class="form-group">
                                <legend><span>2. Información del participante</span></legend>
                                <p>Ingrese la información requerida de la organización o persona natural participante. <b>TENGA EN CUENTA:</b> que al ingresar al sistema <b>SOLO</b> se le pedirá el Número de documento inscrito. 
</p>
                                <label for="txtNombre" runat="server" ClientIDMode="Static" id="lblNombre">Nombres <span>(*)</span></label>
                                 <asp:Image runat="server" ImageUrl="~/images/tooltipq.png" ID="imgNombre"
                                    class="tooltip" title="Ingrese su nombre completo." />
                                 <asp:Image Width="20px" Style="float:right;visibility:hidden;" runat="server" ImageUrl="~/images/tooltipq.png" ID="imgNombreOrganizacion"
                                    class="tooltip" title="Ingrese el nombre completo de organización." />
                                 <asp:Image Width="20px" Style="float:right;visibility:hidden;" runat="server" ImageUrl="~/images/tooltipq.png" ID="imgNombreSecretaria"
                                    class="tooltip" title="Ingrese el nombre completo de la secretaria.." />


                                <asp:TextBox runat="server" onkeypress='return validarSoloLetras(event);' TabIndex="8" type="text" name="name" ID="txtNombre" MaxLength="100" CssClass="form-control" />
                         
                                <label for="txtApellido" ClientIDMode="Static" runat="server" id="lblApellido">Apellidos <span>(*)</span></label>
                                <asp:TextBox runat="server" ClientIDMode="Static"   onkeypress='return validarSoloLetras(event);'  TabIndex="9" type="text" name="name" ID="txtApellido" MaxLength="50" CssClass="form-control" />

                                <label for="cmbTipoDocumentoRepresentanteLegal" ClientIDMode="Static" runat="server" id="lblTipoDocumentoRepresentanteLegal">Tipo de documento representante legal<span> (*)</span></label>
                                <asp:DropDownList runat="server" ClientIDMode="Static" onchange="CalcTotalAmt2();" TabIndex="10" ID="cmbTipoDocumentoRepresentanteLegal" CssClass="form-control"></asp:DropDownList>
                                
                                <label for="txtIdentificacionLegal" ClientIDMode="Static" runat="server" id="lblIdentificacionLegal">Número de documento representante legal <span>(*)</span></label>
                                 <asp:Image visible="false"   runat="server" ImageUrl="~/images/tooltipq.png" ID="Image6"
                                    class="tooltip" title="ingrese el número de documento teniendo en cuenta, para cédula de ciudadania solo ingrese valores númericos, para Pasaporte ingrese valores alfanuméricos y para Nit, RIT y RUT el digito de verificación va en la casilla siguiente al documento. " />
                               <div style="display:block;width:450px;">  
                                   <asp:TextBox ID="txtIdentificacionLegal" Style="width:230px;display:inline !important;"  onkeypress='return validarTexto2(event);' runat="server" TabIndex="11" type="text" name="number" CssClass="form-control" MaxLength="30"/>
                              
                                 <asp:Label runat="server" ClientIDMode="Static" Style="display:none;display:inline !important;" ID="lblSeparadoDocumento2" Text="-"></asp:Label> 
                                  <asp:TextBox runat="server"  ClientIDMode="Static"  Style="display:none;display:inline !important;" ID="txtdigitoVerificacion2" onkeypress='return validarTextoVerificacion2(event);'  Width="40px" TabIndex="3" CssClass="form-control" MaxLength="1" ></asp:TextBox>
                                   </div>
                                                               
                                
                                <label for="divUploadFileRepresentante" ClientIDMode="Static" runat="server" id="lblCertificacionRepresentanteLegal">Certificación de representación legal de la organización, agremiación o asociación: <br />  * Debe ser un archivo tipo: .jpg,.jpeg,.gif,.png,.pdf,.bmp <br /> * Tamaño maximo: 1 Gb</label>
                                <div id="divUploadFileRepresentante"  ClientIDMode="Static" runat="server">
                                    <dx:ASPxUploadControl ID="UploadFileRepresentante" runat="server" ClientInstanceName="UploadFileRepresentante" Width="100%"
                                        UploadMode="Standard" ShowProgressPanel="true"
                                        NullText="Seleccion al archivo..."
                                        ShowUploadButton="false"
                                        autostartupload="true"
                                        OnFileUploadComplete="UploadFileRepresentante_FileUploadComplete"
                                        BrowseButton-Image-Url="~/Img/file.png"
                                        BrowseButton-Text=""
                                        BrowseButton-Image-Height="20px"
                                        BrowseButton-Image-Width="20px"
                                        ValidationSettings-MaxFileSizeErrorText="El tamaño de los archivos no debe superar 1Gb.">
                                        <AdvancedModeSettings EnableMultiSelect="false" />
                                        <ValidationSettings MaxFileSize="1100000000" AllowedFileExtensions=".jpg,.jpeg,.gif,.png,.pdf,.bmp">
                                        </ValidationSettings>
                                        <ClientSideEvents FileUploadComplete="function(s, e) { UpdateUploadButtonRepresentante(s, e); }" FilesUploadComplete="function(s, e) { UpdateUploadButtonRepresentante(); }"
                                            TextChanged="function(s, e) { s.Upload(); }" />
                                    </dx:ASPxUploadControl>
                                </div>
                                <a runat="server"  ClientIDMode="Static" id="lblArchivoRepresentanteView" style="color:#094B59" target="_blank" class="form-control"></a>
                               
                                <label for="number" ClientIDMode="Static" runat="server" id="lblCertificacionConstitucion">Copia magnética de la constitución de la asociación, organización, sociedad, agremiación o empresa: <br />  * Debe ser un archivo tipo: .jpg,.jpeg,.gif,.png,.pdf,.bmp <br /> * Tamaño maximo: 1 Gb</label>
                                <div id="divUploadFileCertificacion"  ClientIDMode="Static" runat="server">
                                    <dx:ASPxUploadControl ID="UploadFileCertificacion" runat="server" ClientInstanceName="UploadFileCertificacion" Width="100%"
                                        UploadMode="Standard" ShowProgressPanel="true"
                                        NullText="Seleccion al archivo..."
                                        ShowUploadButton="false"
                                        autostartupload="true"
                                        OnFileUploadComplete="UploadFileMedico_FileUploadComplete"
                                        BrowseButton-Image-Url="~/Img/file.png"
                                        BrowseButton-Text=""
                                        BrowseButton-Image-Height="20px"
                                        BrowseButton-Image-Width="20px"
                                        ValidationSettings-MaxFileSizeErrorText="El tamaño de los archivos no debe superar 1Gb.">
                                        <AdvancedModeSettings EnableMultiSelect="false" />
                                        <ValidationSettings MaxFileSize="1100000000" AllowedFileExtensions=".jpg,.jpeg,.gif,.png,.pdf,.bmp">
                                        </ValidationSettings>
                                        <ClientSideEvents FileUploadComplete="function(s, e) { UpdateUploadButtonCertificacion(s, e); }" FilesUploadComplete="function(s, e) { UpdateUploadButtonCertificacion(); }"
                                            TextChanged="function(s, e) { s.Upload(); }" />
                                    </dx:ASPxUploadControl>
                                </div>
                                <a runat="server" ClientIDMode="Static"    id="lblArchivoCertificacionView" style="color:#094B59" target="_blank" class="form-control"></a>

                                <label for="txtTelefono">Teléfono<span> (*)</span></label>
                                <asp:TextBox ID="txtTelefono"  ClientIDMode="Static" onkeypress='return validarTelefono(event);' runat="server" TabIndex="16" type="text" name="phone" MaxLength="20" CssClass="form-control" />

                   <label for="txtTelefonoCelular">Teléfono celular<span> (*)</span></label>
                                <asp:TextBox ID="txtTelefonoCelular"  ClientIDMode="Static"  onkeypress='return validarTelefono(event);' runat="server" TabIndex="17" type="text" name="phone" MaxLength="20" CssClass="form-control" />
      
                                <asp:UpdatePanel runat="server" ID="upDepartamento" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <label for="cmbDepartamento" runat="server" id="lblDepartamento">Departamento<span> (*)</span></label>
                                        <asp:DropDownList ClientIDMode="Static"  ID="cmbDepartamento" runat="server" TabIndex="18" DataTextField="nombre" DataValueField="nombre" OnSelectedIndexChanged="departamento_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True" CssClass="form-control"></asp:DropDownList>
                                        
                                        <label for="cmbMunicipio" runat="server" id="lblCiudad">Ciudad <span>(*)</span></label>
                                        <asp:DropDownList ID="cmbMunicipio" runat="server" DataTextField="nombre" DataValueField="nombre" AutoPostBack="True" TabIndex="19" CssClass="form-control"></asp:DropDownList>                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <label for="txtDireccion" ClientIDMode="Static" runat="server" id="lblDireccion">Dirección física urbana o rural de la asociación, organización, sociedad o empresa <span>(*)</span></label>
                                <asp:TextBox runat="server" TabIndex="20" type="text" name="name" ID="txtDireccion" MaxLength="150" TextMode="MultiLine" CssClass="form-control" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="dtDireccion" runat="server" FilterType="Custom" ValidChars="01234567989abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóúÁÉÍÓÚ " TargetControlID="txtDireccion" />
                                

                                <label for="cmbGenero" runat="server" ClientIDMode="Static" id="lblGenero">Sexo<span> (*)</span></label>
                                <asp:DropDownList ID="cmbGenero" TabIndex="21" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Femenino</asp:ListItem>
                                    <asp:ListItem Value="1">Masculino</asp:ListItem>
                                    <asp:ListItem Value="2">-Seleccione-</asp:ListItem>
                                </asp:DropDownList>
                                
                                <label for="txtNumeroRepresentante" ClientIDMode="Static" runat="server" id="lblNumeroRepresentante">Número de asociados o de entidades que representa <span>(*)</span></label>
                                <asp:TextBox ID="txtNumeroRepresentante" onkeypress='return validarNumero(event);' runat="server" TabIndex="22" type="text" name="number" Width="30%" CssClass="form-control" MaxLength="7" />
                             
                            </fieldset>
                            <fieldset runat="server" id="flInformacionAcceso" class="form-group">
                                <legend><span>3. Información de acceso</span></legend>
                                <p>Diligencie  la siguiente información que servirá como datos de acceso al sistema</p>
                                <label for="cmbTipoDocumento">Tipo de Documento<span> (*)</span></label>
                                   <asp:Image   runat="server" ImageUrl="~/images/tooltipq.png" ID="Image1"
                                    class="tooltip" title="Seleccione su tipo de documento" />
                                <asp:DropDownList onchange="CalcTotalAmt();" runat="server" TabIndex="1" ClientIDMode="Static" ID="cmbTipoDocumento" CssClass="form-control"></asp:DropDownList>                                
                                

                                <label for="txtCedula" runat="server" ClientIDMode="Static" id="lblDocumento">Número de documento <span>(*)</span></label>
                                
                                   <asp:Image   runat="server" ImageUrl="~/images/tooltipq.png" ID="Image3"
                                    class="tooltip" title="ingrese su número de documento teniendo en cuenta, para cédula de ciudadania solo ingrese valores númericos, para Pasaporte ingrese valores alfanuméricos y para Nit, RIT y RUT el digito de verificación va en la casilla siguiente al documento. " />
                               <div style="display:block;width:350px;">
                                 <asp:TextBox ID="txtCedula"  ClientIDMode="Static" Style="width:330px;display:inline !important;" onkeypress='return validarTexto(event);' runat="server" TabIndex="2" type="text" name="number" CssClass="form-control" MaxLength="25" />
                                <asp:Label runat="server" ClientIDMode="Static" Style="display:none;display:inline !important;" ID="lblSeparadoDocumento" Text="-"></asp:Label> 
                                  <asp:TextBox runat="server" ClientIDMode="Static"   Style="display:none;display:inline !important;" ID="txtdigitoVerificacion" onkeypress='return validarTextoVerificacion(event);'  Width="40px" TabIndex="3" CssClass="form-control" ></asp:TextBox>
                                   </div>
                                <label for="txtContrasenaInicial">Contraseña <span>(*) </span></label> <asp:Image   runat="server" ImageUrl="~/images/tooltipq.png" ID="Image5"
                                    class="tooltip" title="Mínimo 8 caracteres. Combine letras –MAYÚSCULAS/minúsculas- y números. " />
                                <asp:TextBox runat="server"  ClientIDMode="Static" TabIndex="3" type="password"  onkeypress='return validarpassword(event);' name="number" ID="txtContrasenaInicial" CssClass="form-control" MaxLength="16" />                                
                         <div id="lblBarStrength"></div>
                            

                                <label for="txtConfirmarContrasena"  style="width:450px;">Confirme contraseña <span>(*)</span></label>
                                <asp:TextBox runat="server"  ClientIDMode="Static" TabIndex="4" type="password" name="number" ID="txtConfirmarContrasena" CssClass="form-control" MaxLength="16"/>                                

                                <label for="txtEmail">Correo electrónico <span>(*)</span></label>
                                     <asp:Image   runat="server" ImageUrl="~/images/tooltipq.png" ID="Image2"
                                    class="tooltip" title="A este correo recibirá las notificaciones del sistema." />
                             
                                <asp:TextBox runat="server"  ClientIDMode="Static" TabIndex="5" type="email" name="email" ID="txtEmail" AutoPostBack="false" CssClass="form-control" MaxLength="100"/>                                
                                <asp:CheckBox ID="CheckAutorizoCorreo" runat="server" Text=" Autorizo el uso de mi correo para recibir información del Ministerio de Salud y Protección Social." CssClass="checkbox" />
                                <div class="form-group">
                                    <label for="cmbPregunta">Pregunta secreta <span>(*)</span></label>  
                                    <asp:Image   runat="server" ImageUrl="~/images/tooltipq.png" ID="Image4"
                                    class="tooltip" title="Será usada en el caso que olvide su contraseña." />
                             
                                    <asp:DropDownList runat="server" TabIndex="6" ID="cmbPregunta" CssClass="form-control"></asp:DropDownList><br />                                    

                                    <label for="txtRespuestaPregunta">Respuesta secreta<span> (*)</span></label>
                                    <asp:TextBox runat="server"  ClientIDMode="Static" TabIndex="7" ID="txtRespuestaPregunta" CssClass="form-control" MaxLength="30"/><br />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FtRtaSecreta" runat="server" FilterType="Custom" ValidChars="1234567890abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóúÁÉÍÓÚ " TargetControlID="txtRespuestaPregunta" />                                   
                                </div>
                           
                                <div class="form-group" style="text-align:justify;">
                                    <asp:CheckBox ID="chkCertifico" TabIndex="23" runat="server" Text="Certifico que los datos consignados son verídicos y han sido registrados por mi propia decisión y voluntad" CssClass="checkbox" Checked="true" /><br />                                    
                                
                                    <asp:CheckBox ID="chkTerminosYCondiciones" TabIndex="23" runat="server" Text="" CssClass="checkbox" Checked="false" />                                    
                                                        &nbsp;&nbsp;&nbsp;   Al registrarme <b>acepto</b> los <a href="#politicas_modal" id="terms_footer">Términos y Condiciones</a> establecidos para la participación en la herramienta Sistema de Registro Participación Ciudadana, diseñada por el Ministerio de Salud y Protección Social. <br />
                                      </div>

                                <div class="form-group">
                                    <asp:Label ID="LblValidacionCampos" runat="server" Text="" ForeColor="#E4335C" Visible="true" />
                                </div>

                                <div class="form-group">
                                    <asp:Button runat="server" TabIndex="24" type="submit" ID="btnRegistrar" Text="Enviar" CssClass="botonmin centerimagemin" Width="120px" OnClick="btnRegistrar_Click" Height="34px" />
                                    <asp:Button runat="server" type="submit" TabIndex="25" ID="btnSalir" Text="Regresar" CssClass="botonmin centerimagemin" Width="120px" OnClick="salir_Click" CausesValidation="false" Height="34px" />
                                </div>

                            </fieldset>

               

                        </div>
            </asp:Panel>
                </div>
            </div>
        </div>
    </div>    
    <div style="height: 50px;"></div>

        <div style="display: none">
        <div class="terminos" id="politicas_modal">
            <br />
              <b><span class="spantitle">&nbsp;&nbsp;&nbsp;Términos y Condiciones</span></b>

            <p class="text_terms">
Por favor, lea con detenimiento los siguientes términos y condiciones que regulan la participación en la herramienta diseñada por el Ministerio de Salud y Protección Social denominada “Sistema de Registro de Participación Ciudadana”, la cual se enmarca en lo previsto por la Circular 060 de 2015 la cual definió la estrategia para promover la participación directa y efectiva de los diferentes actores que intervienen en el Sistema de Salud en Colombia; con el fin de garantizar la inscripción y participación de todos los interesados y ciudadanía en general, así como garantizar la trazabilidad y transparencia de los resultados de los procesos de participación que desarrolle este Ministerio.
Al momento de registrarse en esta herramienta se garantiza que los participantes podrán ejercer el Control Social a lo Público, tal como lo establece el artículo 60 de la Ley 1757 de 2015, el cual va encaminado a realizar el seguimiento y evaluación de las políticas públicas y a la gestión desarrollada por las autoridades públicas; entendiéndose entonces que se aceptarán los términos y condiciones y brinda su consentimiento respecto a su aceptación.
En la herramienta “Sistema de Registro de Participación Ciudadana”  podrán participar gratuitamente todas las personas naturales y jurídicas, que tengan domicilio o residencia en Colombia, y cuyo interés de participar en los procesos colectivos sobre los aspectos de la salud en Colombia sea propositivo, constructivo y dinámico, encaminado a la búsqueda del interés común por encima de cualquier interés particular que pueda existir. Para la inscripción y  participación se deberá tener en cuenta:
               </p>
                 <ul  class="text_terms" style="padding-left:40px;">
<li>	En esta herramienta tienen lugar todas las personas mayores de edad que habitan en el territorio colombiano.
</li><li>	La información reportada en cada uno de los campos solicitados en el formulario de registro deberá ser veraz, puntual y exacta.
</li><li>	Los documentos que se adjunten en los campos que así lo requieran, se presumirán auténticos, atendiendo a lo establecido en el Art. 244 del Código General del Proceso (Ley 1564 de 2012.
</li><li>	El usuario asignado a cada participante será su número de identificación, para  y su contraseña deberá tener unos caracteres de fácil recordación.
</li><li>	En caso que la contraseña sea olvidada, deberá remitirse al módulo: ¿Olvidó su contraseña?, a través del cual podrá ingresar nuevamente a la herramienta. 
</li><li>	Las personas que se inscriban en esta herramienta deberán mantener actualizada su información de contacto.
</li><li>	En caso que los representantes legales, directores o designados de personas jurídicas sean sustituidos, su periodo haya finalizado u otra causa, deberá remitirse comunicación al correo electrónico: participaciónpos@minsalud.gov.co indicando cual será la persona que será asignada en sustitución de la anterior, acreditando de igual forma los requisitos establecidos al momento de diligenciamiento de la inscripción inicial en esta herramienta.
</li><li>	El Ministerio de Salud y Protección Social, en cualquier momento podrá suspender, retirar o cancelar la participación en la herramienta “Sistema de Registro de Participación Ciudadana”, a cualquier usuario que se evidencie no cumple con los requisitos, o que a discreción del mismo considere que afecta el óptimo desarrollo de los eventos planeados. 
                    </ul>
            <p class="text_terms">
<br /><b>Privacidad de la Información</b>
La recolección y tratamiento automatizado de los datos personales tienen como finalidad el buen y fluido mantenimiento de la relación establecida entre el participante y el Ministerio de Salud y Protección Social. Los datos personales serán de uso exclusivo para el manejo adecuado de la herramienta y serán administrados de acuerdo a lo establecido en la Ley de Habeas Data y Manejo de la Información.



<br /><br /><b>Protección de la Información.</b>
Este sitio es propiedad del Estado colombiano y es operado por el Ministerio de Salud y Protección Social.

Este aviso cubre solamente los procesos de Participación Ciudadana que desarrolle el Ministerio de Salud y Protección Social a través de la Dirección de Regulación de Beneficios, Costos y Tarifas del Aseguramiento en Salud. Los enlaces a otros sitios web no están cubiertos por este aviso.
Todos los cambios relacionados con este aviso y nuestra política de protección de datos serán fijados en esta misma herramienta.
Los datos personales que usted proporcione serán procesados según las normas legales, para el trámite de sus solicitudes o denuncias se seguirán las normas legales vigentes sobre derechos de petición e información, en interés general o particular, según el caso y en consecuencia podrán ser transmitidos, transferidos o remitidos a las autoridades o entidades pertinentes para su debido procesamiento.
Tenga en cuenta que no hay garantía de que los mensajes de correo electrónico enviados a este sistema sean recibidos de forma íntegra, segura o confidencial; al igual que su contenido se mantenga confidencial durante la transmisión electrónica de los datos.
Las comunicaciones se pueden supervisar para los propósitos del control de calidad y de la seguridad.
<br /><br /><b>Ley aplicable y jurisdicción.</b>
Las condiciones generales aquí presentes se rigen por la Ley colombiana. El Ministerio de Salud y Protección Social y el participante, renuncian expresamente a cualquier otro fuero, y se someten al de los Juzgados y Tribunales competentes de la ciudad de Bogotá D.C

         

            </p>
            <br /><br />
        </div>
    </div>

    
            <script type="text/jscript">

                $("a#terms_footer").fancybox({
                    'transitionIn': 'none',
                    'transitionOut': 'none',
                    'hideOnContentClick': false,
                    'overlayShow': true,
                    'width': 562
                });

                $("a#terms_reg").fancybox({
                    'transitionIn': 'none',
                    'transitionOut': 'none',
                    'hideOnContentClick': false,
                    'overlayShow': true,
                    'width': 562
                });

 
                $("a#terms_login").fancybox({
                    'transitionIn': 'none',
                    'transitionOut': 'none',
                    'hideOnContentClick': false,
                    'overlayShow': true,
                    'width': 562
                });

    </script>

</asp:Content>






