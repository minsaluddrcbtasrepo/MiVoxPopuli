<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/masterb.Master" AutoEventWireup="true" CodeBehind="frmMigrarCuenta.aspx.cs" Inherits="InscripcionMinSalud.frm.registro.frmMigrarCuenta" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../blueimp/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../blueimp/jquery.iframe-transport.js" type="text/javascript"></script>
    <script src="../../blueimp/jquery.fileupload.js" type="text/javascript"></script>
 


        <style>
        input#btnRegistrar{
background: #30798d;
background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
border-radius: 5px;
color: #fff;
font-size: 1.9rem;
padding: 15px 30px;
border: none;
font-weight: bold;
width: 250px;
margin: 40px auto;
text-align: center;
}

                input#btnCancelar{
background: #30798d;
background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
border-radius: 5px;
color: #fff;
font-size: 1.9rem;
padding: 15px 30px;
border: none;
font-weight: bold;
width: 250px;
margin: 40px auto;
text-align: center;
}

        .checkper{
margin-right:7px !important;
}

        .checkper input{
margin-right:7px !important;
}
        /*form registro*/
        input#chkAutorizo {
position: relative !important;
}

              input#chkTerminosYCondiciones {
position: relative !important;
}

               input#chkCertifico {
position: relative !important;
}
        .form-control {
display: block;
width: 100%;
height: 34px;
padding: 6px 12px;
font-size: 14px;
line-height: 1.42857143;
color: #555;
background-color: #fff;
background-image: none;
border: 1px solid #bde7ef !important;
border-radius: 4px;
-webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
-webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
-o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
}
h2.tag {
    font-size: 3rem;
    font-weight: bold;
    color: #17a9c7 !important;
    text-align: center;
    width: 500px;
    margin: 40px auto 20px auto !important;
}

p.centerp {
    text-align: center;
}

strong {
    color: #0aa1bc;
}

fieldset.form-group {
    margin: 40px 0px;
}

legend span {
    color: #17a9c7;
    font-weight: 700;
}

legend {
     border-bottom: 1px solid #f3a740 !important;
}

label {
       color: #266373 !important;
       margin: 20px 0px 5px 0px !important;
}

.txtMini{
	width:40% !important;
}
txtNormal{
	width:70% !important;
}
        .errormin {
        border-color:red !important;
        border-style:solid !important;
        border-width:2px !important;
        }
    </style>
    <link href="../../Scripts/fancy/source/fancyMins.css" rel="stylesheet" />
    <script>

        function test() {
           
            try{
                var co = clickOnce(boton);
                if (co == false) {
                    return false;
                }
            }catch(error ){}
            var comboSub2 = $('#cmbTipoUsuario').val();
            $('#cmbTipoHiddenClient').val(comboSub2);
            //alert(comboSub2);
            var comboSub2a = $('#cmbTipo').val();
            $('#cmbTipoDosHidden').val(comboSub2a);
           // alert(comboSub2a);
            var comboSub2b = $('#cmbtipodocumentoentidad').val();
            $('#cmbTipoDocumentoHidden').val(comboSub2b);
            return true;
            //alert(comboSub2b);
        }
        var postbak=false;

        //funciones de validacion
        function validarNumero(event){
            var respuesta = false;
            respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 32;
            return respuesta;
        }

        function validarTelefono(event){
            var respuesta = false;
            respuesta = (event.charCode >= 48 && event.charCode <= 57) || event.charCode < 32 || event.charCode.toString() == '45';
            return respuesta;
        }

        function validarAlfanumerico(event){

            var respuesta = false;
            respuesta =
 (event.charCode >= 65 && event.charCode <= 90) ||  (event.charCode >= 48 && event.charCode <= 57)
|| (event.charCode >= 97 && event.charCode <= 122) ||
 (event.charCode >= 160 && event.charCode <= 164)//tildes
 || event.charCode <= 32 //incluye espacio
            || event.charCode == 127 //suprimir
            || event.charCode == 241 //ñ
            || event.charCode == 209 //Ñ
            || event.charCode == 130 //Ñ
                  || event.charCode == 225 || event.charCode == 233 || event.charCode == 237 || event.charCode == 243
            || event.charCode == 250 || event.charCode == 193 || event.charCode == 201 || event.charCode == 205
            || event.charCode == 211 || event.charCode == 218
|| event.charCode == 44 || event.charCode == 46
            ;
            return respuesta;
        }

        function validarSoloLetras(event) {
            var respuesta = false;
            respuesta = (event.charCode >= 65 && event.charCode <= 90)
|| (event.charCode >= 97 && event.charCode <= 122)
|| (event.charCode >= 160 && event.charCode <= 164)//tildes
|| event.charCode <= 32 //incluye espacio
            || event.charCode == 127 //suprimir
            || event.charCode == 241 //ñ
            || event.charCode == 209 //Ñ
            || event.charCode == 130 //Ñ
            || event.charCode == 133            || event.charCode == 138            || event.charCode == 141            || event.charCode == 144            || event.charCode == 149            || event.charCode == 151
            || event.charCode == 160            || event.charCode == 161            || event.charCode == 162            || event.charCode == 163
            || event.charCode == 164            || event.charCode == 165            || event.charCode == 181            || event.charCode == 183
            || event.charCode == 212            || event.charCode == 214            || event.charCode == 224            || event.charCode == 227
            || event.charCode == 233 || event.charCode == 235 || event.charCode == 239
                  || event.charCode == 225 || event.charCode == 233 || event.charCode == 237 || event.charCode == 243
            || event.charCode == 250 || event.charCode == 193 || event.charCode == 201 || event.charCode == 205
            || event.charCode == 211 || event.charCode == 218

            ;
            return respuesta;
        }

        function validarSoloLetrasDireccion(event) {
            var respuesta = false;

            respuesta = (event.charCode >= 65 && event.charCode <= 90)
|| (event.charCode >= 97 && event.charCode <= 122)
|| (event.charCode >= 160 && event.charCode <= 164)//tildes
|| event.charCode <= 32 //incluye espacio
            || event.charCode == 127 //suprimir
            || event.charCode == 241 //ñ
            || event.charCode == 209 //Ñ
            || event.charCode == 130 //Ñ
            || event.charCode == 133            || event.charCode == 138            || event.charCode == 141            || event.charCode == 144
            || event.charCode == 149            || event.charCode == 151            || event.charCode == 160            || event.charCode == 161
            || event.charCode == 162            || event.charCode == 163            || event.charCode == 164            || event.charCode == 165
            || event.charCode == 181            || event.charCode == 183            || event.charCode == 212            || event.charCode == 214
            || event.charCode == 224 || event.charCode == 227 || event.charCode == 233 || event.charCode == 235

            || event.charCode == 225 || event.charCode == 233 || event.charCode == 237 || event.charCode == 243
            || event.charCode == 250 || event.charCode == 193 || event.charCode == 201 || event.charCode == 205
            || event.charCode == 211 || event.charCode == 218
|| event.charCode == 44 || event.charCode == 46



            || event.charCode == 239            || event.charCode == 45//-
            || event.charCode == 239//_
            || event.charCode == 35//#
            ;
            return respuesta;
        }


        //funciones de cargar datos

        function GetDropDownData() {
          
            var combo = $('#cmbPerfil').val();
            var comboSub = $('#cmbsubTipo').val();

            $.ajax({
                type: "POST",
                url: "../ws/ws.asmx/obtenerPerfil",
                data: "{padre: " + comboSub + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                
                success: function (data) {
                    $('#cmbTipoUsuario').empty();
                    $('#cmbTipo').empty();
                    $('#cmbTipoUsuario').append($("<option></option>").val('-1').html('Seleccione'));
                    $.each(jQuery.parseJSON(data.d), function () {
                        $('#cmbTipoUsuario').append($("<option></option>").val(this['codigo']).html(this['nombre']));
                    });

                    if($('#cmbTipoHiddenClient').val() != null){
                        $('#cmbTipoUsuario').val($('#cmbTipoHiddenClient').val());
                        $('#cmbTipoHidden').val($('#cmbTipoHiddenClient').val());
                        $('#cmbTipoHiddenClient').val(null);
                    }
                },
                    failure: function () {
                        alert("problema al cargar los datos!");
                    }
                });
        }

        function GetDropDownDataDos() {            
            var combo = $('#cmbTipoUsuario').val();          
            GetDropDownDataDosP(combo);
        }

        function GetDropDownDataDosP(combo) {
            
            var itemsHijos = 0;
            $.ajax({
                type: "POST",
                url: "../ws/ws.asmx/obtenerPerfil",
                data: "{padre: " + combo + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",

                success: function (data) {

                    $('#cmbTipo').empty();
                    $('#cmbTipo').append($("<option></option>").val('-1').html('Seleccione un ítem de la lista'));
                    
                    $.each(jQuery.parseJSON(data.d), function () {
                        $('#cmbTipo').append($("<option></option>").val(this['codigo']).html(this['nombre']));
                        itemsHijos = itemsHijos + 1;
                    });
                   
                    if (itemsHijos == 0) {
                        $('#divTipoDos').hide();
                        $('#pnlDatosJuridicos').show();
                        $('#pnlAcepto').show();
                        $('#cmbTipoDosHiddenClient').val(null);
                        $('#cmbTipoDosHidden').val(null);
                    } else {
                        
                        $('#divTipoDos').show();
                           // $('#pnlDatosJuridicos').hide();
                           // $('#pnlAcepto').hide();
                           // alert('malpa' + combo);
                        
                    }
                    if (combo <= 0) {
                        $('#pnlDatosJuridicos').hide();
                        $('#pnlAcepto').hide();
                    }
                    if ($('#cmbTipoDosHiddenClient').val() != null) {
                        $('#cmbTipo').val($('#cmbTipoDosHiddenClient').val());
                        $('#cmbTipoDosHidden').val($('#cmbTipoDosHiddenClient').val());
                        $('#cmbTipoDosHiddenClient').val(null);
                    }
                },
                failure: function () {
                    alert("problema al cargar los datos!");
                }
            });

           
        }

        function GetDropDownDataDocumento() {

            var combo = $('#cmbTipoUsuario').val();
            GetDropDownDataDocumentoP(combo);
        }


        function GetDropDownDataDocumentoP(combo)
        {

            if (combo == '7' || combo == '4' || combo == '6') {
                $('#divdigitoVerificacion').hide();
            } else {
                $('#divdigitoVerificacion').show();
            }


            $.ajax({
                type: "POST",
                url: "../ws/ws.asmx/obtenerTipoDocumentoJuridico",
                data: "{tipoPersona: " + combo + "}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",

                success: function (data) {
                    $('#cmbtipodocumentoentidad').empty();
                    $('#cmbtipodocumentoentidad').append($("<option></option>").val('-1').html('Seleccione'));
                    $.each(jQuery.parseJSON(data.d), function () {
                        $('#cmbtipodocumentoentidad').append($("<option></option>").val(this['codigo']).html(this['nombre']));
                    });


                    if ($('#cmbTipoDocumentoHiddenClient').val() != null) {
                        $('#cmbtipodocumentoentidad').val($('#cmbTipoDocumentoHiddenClient').val());
                        $('#cmbTipoDocumentoHidden').val($('#cmbTipoDocumentoHiddenClient').val());
                        $('#cmbTipoDocumentoHiddenClient').val(null);
                    }
                },
                failure: function () {
                    alert("problema al cargar los datos!");
                }
            });
        }

        function AjusteComboPerfil() {
            if (ejecutando == true) return;
            AjustarPantalla();
        }

        function AjusteComboSubTipoUsuario() {
            if (ejecutando == true) return;
            GetDropDownData();
            AjustarPantalla();
        }

        function AjusteComboSubTipo() {
            if (ejecutando == true) return;
            GetDropDownDataDos();
            GetDropDownDataDocumento();
            AjustarPantalla();
        }

        function AjusteComboSubTipoDos() {
            if (ejecutando == true) return;
            AjustarPantalla();
        }

        function AjustarPantallaJuridica(perfil) {
            // alert(""+perfil);
            $('#divFacultad').hide();
            $('#divFechaActa').hide();
            $('#divespecialidad').hide();
            $('#divTipoIps').hide();
            $('#divNumeroRepresentados').hide();
            if (perfil == 32)
            {
                $('#divFacultad').show();
            }
            if (perfil == 8) {
                $('#divespecialidad').show();
            }
            if (perfil == 35) {
                $('#divTipoIps').show();
            }

            if (perfil == 4 || perfil == 5 || perfil == 6 || perfil == 7 || perfil == 8 || perfil == 9 || perfil == 10 || perfil == 11 || perfil == 12
                || perfil == 13 || perfil == 14 || perfil == 15 || perfil == 16 || perfil == 17 || perfil == 18 || perfil == 19 || perfil == 20 || perfil == 21
                || perfil == 22 || perfil == 23 || perfil == 24 || perfil == 25 || perfil == 26 || perfil == 27 || perfil == 28 || perfil == 29 || perfil == 30 || perfil == 31
                ) {
                $('#divNumeroRepresentados').show();
            }
            var combo = $('#cmbtipodocumentoentidad').val();
            AjustarActa(combo);
        }

        function AjustarActa(combo) {
            if (combo != null && combo != "" && combo == 12) {

                $('#divFechaActa').show();
            }else{
                $('#divFechaActa').hide();
            }

            if (combo == '9' || combo == '10' || combo == '11' || combo == '99') {
                $('#divdigitoVerificacion').show();
            } else {
                $('#divdigitoVerificacion').hide();
            }

        }

        function Ajustarcheck() {
 //si esta chekeado acepto terminos muestra el boton
            var chkAcepto = $('#chkTerminosYCondiciones').prop('checked');
            var chkCertifico = $('#chkCertifico').prop('checked');
            if (chkAcepto == true && chkCertifico == true) {
                $('#btnRegistrar').show();
            } else {
                $('#btnRegistrar').hide();
            }
        }
        var ejecutando = false;

        function AjustarPantalla() {
            if (ejecutando == true) {
                return;
            }
            ejecutando = true;
            Ajustarcheck();
            //ocultamos todos los paneles
            //ocultarPaneles();
          
            var combo = $('#cmbPerfil').val();           
            if (combo == null) {
                ejecutando = false;
                return;
            }

            if (combo == 1) {
                $('#pnlDatosNatural').show();
                $('#pnlAcepto').show();
                $('#pnlDatosJuridicos').hide();
                $('#pnlcombostipo').hide();
                $('#pnlcombosJuridicos').hide();
                ejecutando = false;
                return;
            }else  if (combo == 2) {
                $('#pnlDatosNatural').hide();
                $('#pnlcombosJuridicos').show();

            } else {
                ocultarPaneles();
                ejecutando = false;
                return;
            }
            //fin perfil
            //inicia sub tipo
            var stipo = $('#cmbsubTipo').val();
            if (stipo == null || stipo <= 0) {
                $('#pnlcombostipo').hide();
                $('#pnlDatosNatural').hide();
                $('#pnlDatosJuridicos').hide();
                $('#pnlAcepto').hide();
                ejecutando = false;
                return;
            }
            $('#pnlcombostipo').show();
            //fin subtipo
            //inicia tipo final nivel 1 o nivel 2
            var tipo = $('#cmbTipoUsuario').val();
            var previo = $('#cmbTipoHidden').val();
            if (tipo == null || tipo == -1) {
                if (previo != null && previo != "") {
                    $('#cmbTipoHiddenClient').val($('#cmbTipoHidden').val());
                    GetDropDownData();
                    tipo = previo;
                } else {
                    $('#divTipoDos').hide();
                    $('#pnlDatosJuridicos').hide();
                    $('#pnlAcepto').hide();
                    ejecutando = false;
                    return;
                }
            }
            $('#cmbTipoHidden').val(tipo);
            $('#cmbTipoUsuario').val(tipo);
            if (tipo == 8)
            {
                $('#divespecialidad').show();    
            }else{
                $('#divespecialidad').hide();
            }

            //validamos si debemos mostrar el segundo div
            var tipodos = $('#cmbTipo').val();
            var previodos = $('#cmbTipoDosHidden').val();
            var retornar = false;
            if (tipodos == null || tipodos <= 0) {
                if (previodos != null && previodos != "") {
                    $('#cmbTipoDosHiddenClient').val($('#cmbTipoDosHidden').val());
                    GetDropDownDataDosP(tipo);
                    tipodos = previodos;
                    $('#divTipoDos').show();
                    $('#pnlDatosJuridicos').show();
                    $('#pnlAcepto').show();
           
                } else {
                    if (tipo <= 0) {
                        $('#pnlDatosJuridicos').hide();
                        $('#pnlAcepto').hide();
                    } else {
                        $('#pnlDatosJuridicos').show();
                        $('#pnlAcepto').show();
                        AjustarPantallaJuridica(tipo);
                    }
                    if(postbak)
                    {
                        retornar = true;
                    }
                }
            }
            
                $('#cmbTipoDosHidden').val(tipodos);
                $('#cmbTipo').val(tipodos);
       
            var espe=false;
            var ips = false;
            var segundo = false;
            if (tipo == 8 ||tipo == 9 ||tipo == 10 ||tipo == 12 ) {
                segundo = true;
            }
            if(tipo==8){
                espe=true;
                }
            if(tipo==35){
                ips=true;
                }


            if (tipodos != null && tipodos > 0)
            {
                tipo = tipodos;
            }
            
            


            AjustarPantallaJuridica(tipo);  
            if(espe == true)
            {
             $('#divespecialidad').show();
            }
             if(ips == true)
            {
             $('#divTipoIps').show();
             }
             if (segundo == true) {
                 $('#divTipoDos').show();
             }
            //hacemos algo para seleccionar el tipo de documento
            var tipoD = $('#cmbtipodocumentoentidad').val();
            var previoD = $('#cmbTipoDocumentoHidden').val();
            if (tipoD == null || tipoD == -1) {
                if (previoD != null && previoD != "") {
                    $('#cmbTipoDocumentoHiddenClient').val($('#cmbTipoDocumentoHidden').val());
                    GetDropDownDataDocumentoP(tipo);
                    tipoD = previoD;
                } else {
                    GetDropDownDataDocumentoP(tipo);
                }
            }
            $('#cmbTipoDocumentoHidden').val(tipoD);
            AjustarActa(tipoD);

            //textox
            if (tipo == "39" ||tipo == "40" ||tipo == "41" ||tipo == "42" ||tipo == "43" ||tipo == "44" ||tipo == "45" ||
                tipo == "46" ||tipo == "47" ||tipo == "48" )
            {
                 lbltituloArchivoJuridico1.innerText = "Adjunte acta de posesión";
                 lbltituloArchivoJuridico1.innerHTML;
            }else if (tipo == "32" ||tipo == "33" ||tipo == "34" ||tipo == "35" ||tipo == "36" ||tipo == "37" ||tipo == "38" )
            {
                 lbltituloArchivoJuridico1.innerText = "Adjunte certificado de Cámara de Comercio";
                 lbltituloArchivoJuridico1.innerHTML;
            }else if (tipo == "9" ||tipo == "10" ||tipo == "11" ||tipo == "12" ||tipo == "5")
            {
                 lbltituloArchivoJuridico1.innerText = "Adjunte certificado de Cámara de Comercio";
                 lbltituloArchivoJuridico1.innerHTML;
            }else if (tipo == "4" ||tipo == "6" ||tipo == "7" )
            {
                if(tipoD == "12"){
                    lbltituloArchivoJuridico1.innerText = "Adjunte acta de junta directiva vigente";
                    lbltituloArchivoJuridico1.innerHTML;
                    }else if(tipoD == "13"){
                     lbltituloArchivoJuridico1.innerText = "Adjunte resolución vigente";
                    lbltituloArchivoJuridico1.innerHTML;
                    }else{
                    lbltituloArchivoJuridico1.innerText = "Adjunte  certificado de Cámara de Comercio";
                    lbltituloArchivoJuridico1.innerHTML;
                }
            }else{
                 lbltituloArchivoJuridico1.innerText = "Adjunte Documento de soporte ";
                 lbltituloArchivoJuridico1.innerHTML;
            }
//fin tipo de documento
            if (retornar)
            {
                ejecutando = false;
                return;
            }
            ejecutando = false;
            $('#pnlDatosJuridicos').show();
            $('#pnlAcepto').show();
         

        }

        function ocultarPaneles()
        {
            $('#pnlcombosJuridicos').hide();
            $('#pnlcombostipo').hide();
     
            $('#pnlDatosNatural').hide();
            $('#pnlDatosJuridicos').hide();
            $('#pnlAcepto').hide();
        }

        $(document).ready(function () {
            ocultarPaneles();
            $('.tooltip').tooltipster();
            $('.fancybox').fancybox();
            AjustarPantalla();
            postbak = true;
        })


        function getRootWebSitePath() {
            var _location = document.location.toString();
            var applicationNameIndex = _location.indexOf('/', _location.indexOf('://') + 3);
            var applicationName = _location.substring(0, applicationNameIndex) + '/';
            var webFolderIndex = _location.indexOf('/', _location.indexOf(applicationName) + applicationName.length);
            var webFolderFullPath = _location.substring(0, webFolderIndex);
            //return applicationName;
            return webFolderFullPath;
        }

        function UpdateUploadButton(s, e) {
            try{
                var text = s.GetText(e.inputIndex);
                var file = text.replace("fakepath", "");
                var fileFin = file.replace("C:", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("\\", "");
                fileFin = fileFin.replace("\\", "");
                var webSite = getRootWebSitePath();
                var pathRelativo = webSite + "//files//Temporal//3-" + fileFin;
                document.getElementById('lblArchivoView').innerHTML = "Archivo Cargado: " + fileFin;
                document.getElementById('lblArchivoView').href = pathRelativo;
                //catrgamos un hidden para cargarlo en el load
            }catch(err){}
        }
        $(function () {
            $('#FileUpload3').fileupload({
                url: '../../frm/ws/FileUploadHandler.ashx?upload=start&folder=FileUpload3&frm=registro',
                add: function (e, data) {
                    var cnt = 0;
                    var ext = '';
                    $.each(data.files, function (index, file) {
                        cnt = cnt + 1;
                        ext = file.name.substring(file.name.lastIndexOf('.'));
                        if (file.size > 52428800) {
                            alert('El archivo ' + file.name + '  supera el tamaño máximo de 50 Megas.');
                            return;
                        }
                    });

                    if (cnt > 1) {
                        alert('Solo debe seleccionar un archivo');
                        return;
                    }
                    /* if (ext.toUpperCase() != '.PDF') {
                            alert('solo es valido subir archivos en formato pdf.');
                            return; } */
                    //   console.log('add', data);
                    $('#progressbar3').show();
                    data.submit();
                },
                progress: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progressbar3').css('width', progress + '%');
                },
                success: function (response, status) {
                    $('#progressbar3').hide();
                    $('#progressbar3 div').css('width', '0%');

                    if (response.indexOf("Error") >= 0) {
                        alert(response);
                    } else {
                        $("#lnkArchivo3").attr("href", "../../files/" + response);
                        $("#lnkArchivo3").text(response);
                    }
                },

                error: function (error) {
                    alert('error');
                    $('#progressbar3').hide();
                    $('#progressbar3 div').css('width', '0%');
                    console.log('error', error);
                }
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">Es necesario que actualice la informacion de su cuenta, para continuar en Mi VOX Pópuli del Ministerio de Salud y Protección Social</h2>
                   <asp:SqlDataSource ID="SqlDataSourceTipoRepresentados" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_REPRESENTADO], [TIPO_REPRESENTADO] FROM [TIPO_REPRESENTADO]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourcetipoIps" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_IPS], [TIPO_IPS] FROM [TIPO_IPS]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceTipoJuridicoCero" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_JURIDICO], [NOMBRE_TIPO_JURIDICO] FROM [TIPO_JURIDICO] WHERE PADRE is null"></asp:SqlDataSource>
          </div>
        </div>
    </div>
     <div class="row">

             <asp:HiddenField ClientIDMode="Static" runat="server" ID="cmbTipoHidden" EnableViewState="true" />
    <asp:HiddenField ClientIDMode="Static" runat="server" ID="cmbTipoHiddenClient" EnableViewState="true" />
    
    <asp:HiddenField ClientIDMode="Static" runat="server" ID="cmbTipoDosHidden" EnableViewState="true" />
    <asp:HiddenField ClientIDMode="Static" runat="server" ID="cmbTipoDosHiddenClient" EnableViewState="true" />

    <asp:HiddenField ClientIDMode="Static" runat="server" ID="cmbTipoDocumentoHidden" EnableViewState="true" />
    <asp:HiddenField ClientIDMode="Static" runat="server" ID="cmbTipoDocumentoHiddenClient" EnableViewState="true" />

  
    <div class="row">
        <div class="container">
             <div class="col-md-6 col-md-offset-3">
                <h3 class="separation-title__another">  
                    </h3>
                 <p class="separation-title__another">  
                  </p>

<p class="centerp">Los campos marcados con <strong> (*) son obligatorios,</strong> </p>
<p class="centerp"><b>Advertencia:</b> Esta aplicativo no es compatible con Internet Explorer 11. Por favor utilizar Internet Explorer 10, Internet Explorer EDGE, Google Chrome o Firefox</p>
            </div>
            <div class="row">
                
                <div class="col-md-8 col-md-offset-2">
                    
                            <fieldset class="form-group">
                                <legend><span>1. Datos del usuario</span></legend>
                                
                                 <label for="cmbPerfil">Seleccione el tipo de persona <span> (*)</span>  
                                     </label>
                                   
                                   <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="imgTooltip"
                                    class="tooltip" title="Seleccione un item de la lista de elementos" />

                                <asp:DropDownList runat="server" TabIndex="0" ID="cmbPerfil"  Width="100%" CssClass="form-control" 
                                     onchange="AjusteComboPerfil();" ClientIDMode="Static" >
                                    <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Persona Natural" Value="1"></asp:ListItem>
                                    
                                    <asp:ListItem Text="Persona Jurídica" Value="2"></asp:ListItem>
                                </asp:DropDownList>  
                            </fieldset>
                            <div id="pnlcombosJuridicos" style="display:none;">
                                    <fieldset class="form-group">
                                <legend><span> Tipo de persona jurídíca</span></legend>
                                
                                 <label for="cmbSubtipo">Seleccione un item de la lista<span> (*)</span>  
                                     </label>
                                   
                                   <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image7"
                                    class="tooltip" title="Seleccione un item de la lista de elementos" />
                             <asp:DropDownList ID="cmbsubTipo" runat="server"
                                 ClientIDMode="Static" AppendDataBoundItems="true"
                                 CssClass="form-control"
                                 DataSourceID="SqlDataSourceTipoJuridicoCero" DataTextField="NOMBRE_TIPO_JURIDICO" DataValueField="COD_TIPO_JURIDICO"
                                  onchange="AjusteComboSubTipoUsuario();"
                                 Width="100%">
                                 <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                           
                             </asp:DropDownList>
                            </fieldset>
                            </div>
                            <div id="pnlcombostipo" style="display:none;">
                                    <fieldset class="form-group">
                                <legend><span>Actor del sístema</span></legend>
                                <p> </p>                            
                                
                                 <label for="cmbTipoUsuario">Seleccione un item de la lista<span> (*)</span>  
                                     </label>
                                   
                                   <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image8"
                                    class="tooltip"  title="Seleccione un item de la lista de elementos" />
                                <asp:DropDownList runat="server" onchange="AjusteComboSubTipo();" TabIndex="0" ID="cmbTipoUsuario"  Width="100%" CssClass="form-control" 
                                      ClientIDMode="Static" >
                                </asp:DropDownList>  

                                 <div id="divTipoDos" style="display:none;">
                                     <label for="cmbTipo">Seleccione un item de la lista<span> (*)</span>  
                                     </label>
                                    <asp:DropDownList runat="server"  onchange="AjusteComboSubTipoDos();" TabIndex="0" 
                                        ID="cmbTipo"  Width="100%" CssClass="form-control" 
                                      ClientIDMode="Static" >
                                    </asp:DropDownList>  
                                </div>
                            </fieldset>
                            </div>

                            <div id="pnlDatosJuridicos" style="display:none;">
                                <fieldset runat="server" id="fieldJuridico" class="form-group">
                                    <legend><span>2. Información de la entidad </span></legend>

                                      <label for="txtNombreEntidad" ClientIDMode="Static" runat="server" id="lblNombreEntidad">Nombre de la entidad<span>(*)</span></label>
                              <asp:Image Width="20px" Style="" runat="server" ImageUrl="~/img/web/help.gif" ID="Image3"
                                    class="tooltip" title="Ingrese el nombre de la entidad" /> 
                                <asp:TextBox runat="server"  type="text" name="name" 
                                    ID="txtNombreEntidad" 
                                    MaxLength="100" CssClass="form-control" />

                                    <div id="divFacultad">
                                    <label for="txtNombreFacultad" ClientIDMode="Static" runat="server" id="Label2">Nombre de la facultad<span>(*)</span></label>
                              <asp:Image Width="20px" Style="" runat="server" ImageUrl="~/img/web/help.gif" ID="Image1"
                                    class="tooltip" title="Ingrese el nombre de la facultad" /> 
                                <asp:TextBox runat="server"  type="text" name="name" 
                                    ID="txtNombreFacultad" 
                                    MaxLength="100" CssClass="form-control" />
                                        </div>
                             
                                       <label for="cmbtipodocumentoentidad" ClientIDMode="Static" runat="server" id="lbltipoDocumentoEntidad">Tipo de documento <span> (*)</span></label>
                                <asp:DropDownList runat="server" ID="cmbtipodocumentoentidad" onchange="AjustarPantalla();" 
                                    ClientIDMode="Static" CssClass="form-control"  DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>

                                   
                                    
                                                            
                                 <label for="txtDocumentoJuridico" ClientIDMode="Static" runat="server" id="lblDocumentoEntidad">Número de documento <span>(*)</span></label>
                              <asp:Image Width="20px" Style="" runat="server" ImageUrl="~/img/web/help.gif" ID="Image2"
                                    class="tooltip" title="Ingrese su numero de documento." /> 
                                    <div>
                                <asp:TextBox runat="server" Style="display: inline-block !important;" onkeypress='return validarNumero(event);'  type="text" name="name" 
                                    ID="txtDocumentoJuridico" 
                                    MaxLength="100" Width="180" CssClass="form-control" /><div id="divdigitoVerificacion" Style="display: inline-block !important;"> -
                                     <asp:TextBox runat="server" Style="display: inline-block !important;"  onkeypress='return validarNumero(event);'  type="text" name="name" 
                                    ID="txtDigitoVerificacion" Width="40" ClientIDMode="Static"
                                    MaxLength="1" CssClass="form-control" /></div>
                                        </div>

                                    <div id="divFechaActa">
                                          <label for="txtFechaActa" ClientIDMode="Static" runat="server" id="Label3">Fecha del Acta de constitución <span> (*)</span></label>
                                <asp:TextBox runat="server" ID="txtFechaActa" Width="180"
                                    ClientIDMode="Static" CssClass="form-control" ></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtFechaActa"  ID="calendarExtender"></ajaxToolkit:CalendarExtender>

                                    </div>

                                    <div id="divespecialidad">
                                          <label for="txtEspecialidad" ClientIDMode="Static" runat="server" id="Label4">Especialidad <span> (*)</span></label>
                                <asp:TextBox runat="server" ID="txtEspecialidad" 
                                    ClientIDMode="Static" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div id="divTipoIps">
                                           <label for="cmbTipoIps" ClientIDMode="Static" runat="server" id="Label5">Tipo de IPS <span> (*)</span></label>
                                        <asp:DropDownList ID="cmbTipoIps" runat="server"
                                 ClientIDMode="Static" AppendDataBoundItems="True"
                                 CssClass="form-control"
                                 Width="100%" DataSourceID="SqlDataSourcetipoIps" DataTextField="TIPO_IPS" DataValueField="COD_TIPO_IPS">
                                 <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                             </asp:DropDownList>
                                    </div>


                              <asp:UpdatePanel runat="server">
                              <ContentTemplate>
                                        <label for="cmbDepartamentoJuridico" ClientIDMode="Static" runat="server" id="lbl41">Departamento de Ubicación <span> (*)</span></label>
                                        <asp:DropDownList ID="cmbDepartamentoJuridico" runat="server"  DataTextField="Nombre" DataValueField="Id" 
                                            AutoPostBack="True"  CssClass="form-control" DataSourceID="SqlDataSourceDepartamento"></asp:DropDownList>
                                        
                                       
                                        <label for="cmbMunicipioJuridico" ClientIDMode="Static" runat="server" id="lbl42">Municipio o Ciudad <span>(*)</span></label>
                                        <asp:DropDownList ID="cmbMunicipioJuridico" runat="server" DataTextField="Nombre" DataValueField="Id" 
                                             CssClass="form-control" DataSourceID="SqlDataSourceMunicipioJuridico"></asp:DropDownList>                                        
                                        <asp:SqlDataSource ID="SqlDataSourceMunicipioJuridico" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [Id], [Nombre] FROM [Municipio] WHERE ([IdDepartamento] = @IdDepartamento) ORDER BY [Nombre]">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="cmbDepartamentoJuridico" Name="IdDepartamento" PropertyName="SelectedValue" Type="Int16" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                         </ContentTemplate>
                          </asp:UpdatePanel>

                                <label for="txtdireccionJuridico" ClientIDMode="Static" runat="server" id="lbl43">Dirección <span>(*)</span></label>
                                <asp:TextBox runat="server"  type="text" name="name" ID="txtdireccionJuridico" MaxLength="150" TextMode="MultiLine" 
                                    CssClass="form-control" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom" 
                                    ValidChars=",.0123465789#abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóúÁÉÍÓÚ-# " TargetControlID="txtdireccionJuridico" />
                              

                                <label for="cmbtipoZonaJuridico" ClientIDMode="Static" runat="server" id="lbl44">Tipo de zona <span>(*)</span></label>
                                <asp:DropDownList ID="cmbtipoZonaJuridico" runat="server" ClientIDMode="Static" AppendDataBoundItems="True"  CssClass="form-control"
                                 Width="100%" DataSourceID="SqlDataSourceTipoZona" DataTextField="TIPO_ZONA" DataValueField="COD_TIPO_ZONA" >
                              
                                </asp:DropDownList>

                                    <div id="divNumeroRepresentados">
                                  <label for="txtNumeroRepresentante" ClientIDMode="Static" runat="server" id="lblNumAsociados">Número de asociados o agremiados <span>(*)</span></label>
                                <asp:TextBox ID="txtNumeroRepresentante" onkeypress='return validarNumero(event);' runat="server" type="text" name="number" Width="30%" CssClass="form-control" MaxLength="7" />
                         
                                        <label for="cmbtipoRepresentados" ClientIDMode="Static" runat="server" id="Label6">Tipo del número ingresado en el campo anterior <span>(*)</span></label>
                                        <asp:DropDownList ID="cmbtipoRepresentados" runat="server" 
                                             CssClass="form-control" DataSourceID="SqlDataSourceTipoRepresentados" DataTextField="TIPO_REPRESENTADO" DataValueField="COD_TIPO_REPRESENTADO" ></asp:DropDownList>
                                        </div>

                                <label for="txtTelefonoJuridico" ClientIDMode="Static" id="lbl45">Teléfono fijo<span> (*)</span></label>
                                <asp:TextBox ID="txtTelefonoJuridico" onkeypress='return validarTelefono(event);' runat="server" type="text" name="phone" MaxLength="20" CssClass="form-control" />

                                      <label for="txtcorreoinstitucional"  ClientIDMode="Static" id="lbl18">Correo electrónico institucional<span>(*)</span></label>
                                     <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image4"
                                    class="tooltip" title="A este correo recibirá las notificaciones del sistema." />                           
                                     <asp:TextBox runat="server" type="email" name="email" ID="txtcorreoinstitucional"  CssClass="form-control" MaxLength="100"/>                                
                              
                                    <asp:panel runat="server" ID="pnlUsuarioJuridico">
                                         <label for="txtUsuarioJuridico"  ClientIDMode="Static" id="lbl18">Usuario<span>(*)</span></label>
                                     <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image15"
                                    class="tooltip" title="Con este nombre de usuario podra ingresar al Sistema." />                           
                                     <asp:TextBox runat="server" name="usuario" ID="txtUsuarioJuridico"  CssClass="form-control" MaxLength="100"/>                                
                              

                                    </asp:panel>
                                     <label for="txtcorreoAlternoInstitucional" id="lbl19">Correo electrónico alterno</label>                                     
                                    <asp:TextBox runat="server"  type="email" name="email" ID="txtcorreoAlternoInstitucional"  CssClass="form-control" MaxLength="100"/>
                                        
                                        <label for="cmbPreguntaSecretaJuridica" id="lbl49">Pregunta secreta <span>(*)</span></label>
                                        <asp:Image ID="Image6" runat="server"
                                            class="tooltip"
                                            ImageUrl="~/img/web/help.gif" 
                                            title="Será usada en el caso que olvide su contraseña."
                                            Width="20px" />

                                        <asp:DropDownList ID="cmbPreguntaSecretaJuridica" runat="server" CssClass="form-control"
                                              AppendDataBoundItems="true"
                                             DataSourceID="SqlDataSourcePreguntaSecreta" DataTextField="TextoPregunta" DataValueField="Id">
                                            <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>

                                        </asp:DropDownList>
                                       
                                        <br />

                                        <label for="txtRespuestaPreguntaJuridica" id="lbl50">Respuesta secreta<span> (*)</span></label>
                                        <asp:TextBox ID="txtRespuestaPreguntaJuridica" runat="server" CssClass="form-control" MaxLength="30" >
                                        </asp:TextBox><br />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom" TargetControlID="txtRespuestaPregunta" ValidChars="1234567890abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóúÁÉÍÓÚ ">
                                        </ajaxToolkit:FilteredTextBoxExtender>

                              
                                    <div  runat="server" id="pnlArchivoJuridico1">
                               
                                                   <label for="divDocumentoNatural2" ClientIDMode="Static" runat="server" id="lbltituloArchivoJuridico1">Adjunte Documento de soporte  </label>
                        
                                <div id="divDocumentoNatural2" runat="server">
                                                               <div style=''>
                            <div id='div3b' class='upload_input field_input' />
                                <input type='file' name='file' id='FileUpload3' style='display:none' />  
                                <input type='button'onclick='FileUpload3.click();' style='width:110px;height:30px;' id='btnFileUploadText3' value='Cargar Archivo' />
                                <a runat="server" target="_blank"   ClientIDMode="Static" id="lnkArchivo3" href=''></a>
                            </div>
                           <div class='progressbar' id='progressbar3' style='width:100px;display:none;min-height:10px;background-color:green;'>
                          </div>
                                </div>
                                        </div>
                                    </fieldset>
                            

                         
                                <fieldset runat="server" id="fldRepresentate" class="form-group">
                                <legend><span>
                                     <label  runat="server" ClientIDMode="Static" id="Label7">3 Información del representante legal, director o presidente</label></span></legend>
                       


                                <label for="cmbTipoDocumentoRepresentante"  ClientIDMode="Static" runat="server" id="Label8">Tipo de documento <span> (*)</span></label>
                                <asp:DropDownList runat="server" ID="cmbTipoDocumentoRepresentante" ClientIDMode="Static" CssClass="form-control" DataSourceID="SqlDataSourceTipoDocumentoNatural" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
                                 
                                 <label for="txtNumeroDocumentoRepresentante"  ClientIDMode="Static" runat="server" id="Label9">Número de documento <span>(*)</span></label>
                                 <asp:Image Width="20px" Style="" runat="server" ImageUrl="~/img/web/help.gif" ID="Image11"
                                    class="tooltip" title="Ingrese numero de documento." /> 
                                <asp:TextBox runat="server" onkeypress='return validarNumero(event);'  type="text" name="name" 
                                    ID="txtNumeroDocumentoRepresentante" 
                                    MaxLength="100" CssClass="form-control" />

                                
                                <label for="txtNombresRepresentante" runat="server" id="Label11">Nombres <span>(*)</span></label>
                                 <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image12"
                                    class="tooltip" title="Ingrese nombre completo." />

                                <asp:TextBox runat="server" onkeypress='return validarSoloLetras(event);'  type="text" name="name" ID="txtNombresRepresentante"
                                     MaxLength="100" CssClass="form-control" />
                         
                                <label for="txtApellidosRepresentante" runat="server" id="Label12">Apellidos <span>(*)</span></label>
                                <asp:TextBox runat="server"  onkeypress='return validarSoloLetras(event);'   type="text" name="name" 
                                    ID="txtApellidosRepresentante" MaxLength="50" CssClass="form-control" />

                                
                                <label for="cmbSexoRepresentante" runat="server" id="Label13">Sexo<span> (*)</span></label>
                                <asp:DropDownList ID="cmbSexoRepresentante"  runat="server" CssClass="form-control">
                                    <asp:ListItem Value="-1">Seleccione</asp:ListItem>
                                    <asp:ListItem Value="0">Femenino</asp:ListItem>
                                    <asp:ListItem Value="1">Masculino</asp:ListItem>
                                </asp:DropDownList>                               
              
                                <label for="txtTelefonoRepresentante" id="lbl16">Teléfono fijo</label>
                                <asp:TextBox ID="txtTelefonoRepresentante" onkeypress='return validarTelefono(event);' runat="server" type="text" name="phone" MaxLength="20" CssClass="form-control" />

                                <label for="txtTelefonoCelularRepresentante" id="lbl17">Teléfono celular</label>
                                <asp:TextBox ID="txtTelefonoCelularRepresentante"  onkeypress='return validarTelefono(event);' runat="server"  type="text" name="phone" MaxLength="20" CssClass="form-control" />
       
                                     <label for="txtCorreoRepresentante"  ClientIDMode="Static" id="lbl18">Correo electrónico <span>(*)</span></label>
                                     <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image14"
                                    class="tooltip" title="A este correo recibirá las notificaciones del sistema." />                           
                                     <asp:TextBox runat="server" type="email" name="email" ID="txtCorreoRepresentante"  CssClass="form-control" MaxLength="100"/> 
                                </fieldset>

    </div>
                         

                            <div id="pnlDatosNatural" style="display:none;" >
                                <fieldset runat="server" id="Fieldset1" class="form-group">
                                <legend><span>
                                     <label  runat="server" ClientIDMode="Static" id="lblenumeracionNatural">2 Información del participante</label></span></legend>
                                <p>Ingrese la información requerida. </p>


                                <label for="cmbTipoDocumentoNatural"  ClientIDMode="Static" runat="server" id="lbl1">Tipo de documento <span> (*)</span></label>
                                <asp:DropDownList runat="server" ID="cmbTipoDocumentoNatural" ClientIDMode="Static" CssClass="form-control" DataSourceID="SqlDataSourceTipoDocumentoNatural" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
                                 <asp:SqlDataSource ID="SqlDataSourceTipoDocumentoNatural" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [Nombre], [Id] FROM [TipoIdentificacion] WHERE ([esPersona] = @APLICA_NATURAL) ORDER BY [Id]">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="true" Name="APLICA_NATURAL" Type="Boolean" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>


                                 <label for="txtNumeroDocumentoNatural"  ClientIDMode="Static" runat="server" id="lbl2">Número de documento <span>(*)</span></label>
                                 <asp:Image Width="20px" Style="" runat="server" ImageUrl="~/img/web/help.gif" ID="Image13"
                                    class="tooltip" title="Ingrese su numero de documento." /> 
                                <asp:TextBox runat="server" onkeypress='return validarNumero(event);'  type="text" name="name" 
                                    ID="txtNumeroDocumentoNatural" 
                                    MaxLength="100" CssClass="form-control" />

                                 <label for="txtNombresNatural" runat="server" id="lbl4">Nombres <span>(*)</span></label>
                                 <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image9"
                                    class="tooltip" title="Ingrese su nombre completo." />

                                <asp:TextBox runat="server" onkeypress='return validarSoloLetras(event);'  type="text" name="name" ID="txtNombresNatural"
                                     MaxLength="100" CssClass="form-control" />
                         
                                <label for="txtApellidosNatural" runat="server" id="lbl5">Apellidos <span>(*)</span></label>
                                <asp:TextBox runat="server"  onkeypress='return validarSoloLetras(event);'   type="text" name="name" ID="txtApellidosNatural" MaxLength="50" CssClass="form-control" />

                                
                                <label for="cmbSexo" runat="server" id="lbl6">Sexo<span> (*)</span></label>
                                <asp:DropDownList ID="cmbSexo"  runat="server" CssClass="form-control">
                                    <asp:ListItem Value="-1">Seleccione</asp:ListItem>
                                    <asp:ListItem Value="0">Femenino</asp:ListItem>
                                    <asp:ListItem Value="1">Masculino</asp:ListItem>
                                </asp:DropDownList>
                                
                            <label for="cmbPoblacionEspecial" runat="server" id="lblAlgunasPoblaciones">Pertenece a alguna de las siguientes poblaciones<span> (*)</span></label>
                            <asp:DropDownList  CssClass="form-control" ID="cmbPoblacionEspecial" runat="server" DataSourceID="SqlDataSourcePoblacionEspecial" DataTextField="NOMBRE_POBLACION_ESPECIAL" DataValueField="COD_POBLACION_ESPECIAL">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourcePoblacionEspecial" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_POBLACION_ESPECIAL], [NOMBRE_POBLACION_ESPECIAL] FROM [POBLACION_ESPECIAL]"></asp:SqlDataSource>
                

                            <div id="pnlPerfilesNaturales">
                                        
                                 <label for="dataPerfiles" runat="server" id="Label1">Marque una o varias opciones según corresponda</label>

                                        <asp:DataList ID="dataPerfiles" RepeatColumns="3" runat="server" DataKeyField="Id" DataSourceID="SqlDataSourcetipoUsuarioNuevoNatural">
                                            <ItemTemplate>
                                                <div style="padding-left:10px;padding-right: 20px;padding-top:10px;">
                                                <asp:CheckBox runat="server" CssClass="checkper"  ID="IdLabel" Text='<%# Eval("Nombre") %>' ValidationGroup='<%# Eval("Id") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <asp:SqlDataSource ID="SqlDataSourcetipoUsuarioNuevoNatural" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT * FROM [TipoUsuario] WHERE id!= 41 and (([ES_NUEVO] = @ES_NUEVO) AND ([ES_NATURAL] = @ES_NATURAL))">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="true" Name="ES_NUEVO" Type="Boolean" />
                                                <asp:Parameter DefaultValue="true" Name="ES_NATURAL" Type="Boolean" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <br /><br />
                                    </div>


                             <label for="cmbNivelFormacion" runat="server" id="lblcmbNivelFormacion">Último nivel de formación<span> (*)</span></label>
                             <asp:DropDownList  CssClass="form-control" ID="cmbNivelFormacion" runat="server" DataSourceID="SqlDataSourceNivelFormacion" DataTextField="NIVEL_FORMACION" DataValueField="COD_NIVEL_FORMACION">
                             </asp:DropDownList>
                             <asp:SqlDataSource ID="SqlDataSourceNivelFormacion" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_NIVEL_FORMACION], [NIVEL_FORMACION] FROM [NIVEL_FORMACION]"></asp:SqlDataSource>
               
                                    

                            <asp:UpdatePanel runat="server">
                              <ContentTemplate>
                                        <label for="cmbDepartamentoNatural" runat="server" id="lbl11">Departamento de residencia<span> (*)</span></label>
                                        <asp:DropDownList ID="cmbDepartamentoNatural" runat="server"  DataTextField="Nombre" DataValueField="Id" 
                                            AutoPostBack="True"  CssClass="form-control" DataSourceID="SqlDataSourceDepartamento"></asp:DropDownList>
                                        
                                        <asp:SqlDataSource ID="SqlDataSourceDepartamento" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [Id], [Nombre] FROM [Departamento] ORDER BY [Nombre]"></asp:SqlDataSource>
                                        
                                        <label for="cmbMunicipioNatural"  runat="server" id="lbl12">Municipio o Ciudad <span>(*)</span></label>
                                        <asp:DropDownList ID="cmbMunicipioNatural" runat="server" DataTextField="Nombre" DataValueField="Id"   CssClass="form-control" DataSourceID="SqlDataSourceMunicipioNatural"></asp:DropDownList>                                        
                                        <asp:SqlDataSource ID="SqlDataSourceMunicipioNatural" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [Id], [Nombre] FROM [Municipio] WHERE ([IdDepartamento] = @IdDepartamento) ORDER BY [Nombre]">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="cmbDepartamentoNatural" Name="IdDepartamento" PropertyName="SelectedValue" Type="Int16" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                         </ContentTemplate>
                          </asp:UpdatePanel>

                            <label for="txtdireccionNatural" runat="server" id="lbl13">Dirección de residencia <span>(*)</span></label>
                            <asp:TextBox runat="server"  type="text" name="name" ID="txtdireccionNatural" MaxLength="150" TextMode="MultiLine" CssClass="form-control" />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom" ValidChars=",.0123465789#abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóúÁÉÍÓÚ#- " 
                                TargetControlID="txtdireccionNatural" />
                              
                             <label for="cmbTipoZona" runat="server" id="lbl14">Tipo de zona <span>(*)</span> </label>
                             <asp:DropDownList  CssClass="form-control" ID="cmbTipoZona" runat="server" DataSourceID="SqlDataSourceTipoZona" DataTextField="TIPO_ZONA" DataValueField="COD_TIPO_ZONA">
                             </asp:DropDownList>
                             <asp:SqlDataSource ID="SqlDataSourceTipoZona" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_ZONA], [TIPO_ZONA] FROM [TIPO_ZONA]"></asp:SqlDataSource>
                                <label for="txtTelefonoNatural" id="lbl16">Teléfono fijo</label>
                                <asp:TextBox ID="txtTelefonoNatural" onkeypress='return validarTelefono(event);' runat="server" type="text" name="phone" MaxLength="20" CssClass="form-control" />

                                <label for="txtTelefonoCelularNatural" id="lbl17">Teléfono celular</label>
                                <asp:TextBox ID="txtTelefonoCelularNatural"  onkeypress='return validarTelefono(event);' runat="server"  type="text" name="phone" MaxLength="20" CssClass="form-control" />
                             </fieldset>
                                <fieldset>
                                    <legend><span>Información de acceso</span></legend>
                                    <div class="form-group">

                                     <label for="txtCorreoNatural"  ClientIDMode="Static" id="lbl18">Correo electrónico <span>(*)</span></label>
                                     <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image10"
                                    class="tooltip" title="A este correo recibirá las notificaciones del sistema." />                           
                                     <asp:TextBox runat="server" type="email" name="email" ID="txtCorreoNatural"  CssClass="form-control" MaxLength="100"/>                                
                              

                                     <label for="txtCorreoNaturalAlternativo" id="lbl19">Correo electrónico alterno</label>                                     
                                    <asp:TextBox runat="server"  type="email" name="email" ID="txtCorreoNaturalAlternativo"  CssClass="form-control" MaxLength="100"/>
                                        
                                         <asp:panel runat="server" ID="pnlUsuario">
                                         <label for="txtUsuario"  ClientIDMode="Static" id="lbl18">Usuario<span>(*)</span></label>
                                     <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image16"
                                    class="tooltip" title="Con este nombre de usuario podra ingresar al Sistema." />                           
                                     <asp:TextBox runat="server" name="usuario" ID="txtUsuario"  CssClass="form-control" MaxLength="100"/> 
                                             </asp:panel>

                                        <label for="cmbPreguntaSecreta" id="lbl49">Pregunta secreta <span>(*)</span></label>
                                        <asp:Image ID="Image5" runat="server"
                                            class="tooltip"
                                            ImageUrl="~/img/web/help.gif" 
                                            title="Será usada en el caso que olvide su contraseña."
                                            Width="20px" />

                                        <asp:DropDownList ID="cmbPreguntaSecreta" runat="server" CssClass="form-control"
                                              AppendDataBoundItems="true"
                                             DataSourceID="SqlDataSourcePreguntaSecreta" DataTextField="TextoPregunta" DataValueField="Id">
                                            <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>

                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourcePreguntaSecreta" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [Id], [TextoPregunta] FROM [PreguntaSecreta]"></asp:SqlDataSource>
                                        <br />

                                        <label for="txtRespuestaPregunta" id="lbl50">Respuesta secreta<span> (*)</span></label>
                                        <asp:TextBox ID="txtRespuestaPregunta" runat="server" CssClass="form-control" MaxLength="30" >
                                        </asp:TextBox><br />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom" TargetControlID="txtRespuestaPregunta" ValidChars="1234567890abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóúÁÉÍÓÚ ">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>

                                    
                                </fieldset>
                            </div>

                        <div id="pnlAcepto">
<div class="form-group" style="text-align: justify;"> 
                                        <asp:CheckBox ID="chkAutorizo" ClientIDMode="Static" runat="server" CssClass="checkbox" Text=" Autorizo el uso de mi correo para recibir información del Ministerio de Salud y Protección Social." />

                                        <asp:CheckBox ID="chkCertifico" onchange="Ajustarcheck();"  ClientIDMode="Static" runat="server" CssClass="checkbox"  Text="Certifico que los datos consignados son verídicos y han sido registrados por mi propia decisión y voluntad" />

                                        <asp:CheckBox onchange="Ajustarcheck();"  ID="chkTerminosYCondiciones" ClientIDMode="Static" runat="server" Checked="false" CssClass="checkbox" Text="Al registrarme <b>acepto</b> los <a id='terms_footer' href='#politicas_modal'>Términos y Condiciones</a> establecidos para la participación en la herramienta web, diseñada por el Ministerio de Salud y Protección Social." />
                                        &nbsp;&nbsp;&nbsp;    
                                        
                                    </div>
                                       <div class="form-group">
                                    <asp:Label ID="LblValidacionCampos" runat="server" ForeColor="#E4335C" Font-Size="14pt" />
                                </div>

                                <div class="form-group">
                                    <asp:Button runat="server" style="display:none;" ClientIDMode="Static" 
                                      OnClientClick="return test(this);"
                                        type="submit" ID="btnRegistrar" Text="Enviar" CssClass="boton2"  OnClick="btnRegistrar_Click"  />

   
                                   </div>

                    <div class="form-group">
                                 <asp:Button runat="server"  ClientIDMode="Static" 
                                        
                                        type="submit" ID="btnCancelar" Text="Cancelar" CssClass="boton2"  OnClick="btnCancelar_Click" />
                    </div>


                                        </div>

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
     </div>

</asp:Content>
