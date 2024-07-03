<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmObjetar.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmObjetar" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
     <style type="text/css">

                 a#lnkPDF{
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
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    </style>
    <style>
        .ui-autocomplete { position: absolute; cursor: default; background-color:whitesmoke; }   


html .ui-autocomplete { width:1px; } 
.ui-menu {
    list-style:none;
    padding: 2px;
    margin: 0;
    display:block;
    float: left;
}
.ui-menu .ui-menu {
    margin-top: -3px;
}
.ui-menu .ui-menu-item {
    margin:0;
    padding: 0;
    zoom: 1;
    float: left;
    clear: left;
    width: 100%;
}
.ui-menu .ui-menu-item a {
    text-decoration:none;
    display:block;
    padding:.2em .4em;
    line-height:1.5;
    zoom:1;
}
.ui-menu .ui-menu-item a.ui-state-hover,
.ui-menu .ui-menu-item a.ui-state-active {
    font-weight: normal;
    margin: -1px;
}
    </style>

        
    <style>


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
            try {
                var text = s.GetText(e.inputIndex);
                var file = text.replace("fakepath", "");
                var fileFin = file.replace("C:", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("\\", "");
                fileFin = fileFin.replace("\\", "");
                var webSite = getRootWebSitePath();
                var str = document.getElementById('lblTic').textContent;

                var pathRelativo = webSite + "//files//Temporal//3-" + str + fileFin;
                document.getElementById('lblArchivoView').innerHTML = "Archivo Cargado: " + fileFin;
                document.getElementById('lblArchivoView').href = pathRelativo;
                //catrgamos un hidden para cargarlo en el load
            } catch (err) { }
        }
        $(document).ready(function () {
            
            Ajustarcheck();
            $('.fancybox').fancybox();
            $('.tooltip').tooltipster();
            
        });
        function Ajustarcheck() {
            //si esta chekeado acepto terminos muestra el boton

            var chkEsMedicamento = $('#chkEsMedicamento').prop('checked');
            var chkEsProcedimiento = $('#chkEsProcedimiento').prop('checked');
            var chkEsDispositivoMedico = $('#chkEsDispositivoMedico').prop('checked');
            var chkEsOtro = $('#chkEsOtro').prop('checked');

            var chkExclusionA = $('#chkExclusionA').prop('checked');
            var chkExclusionB = $('#chkExclusionB').prop('checked');
            var chkExclusionC = $('#chkExclusionC').prop('checked');
            var chkExclusionD = $('#chkExclusionD').prop('checked');
            var chkExclusionE = $('#chkExclusionE').prop('checked');
            var chkExclusionF = $('#chkExclusionF').prop('checked');

            var chkConflictoInteres = $('#chkConflictoInteres').prop('checked');
            var chkAdjuntaEvidencia = $('#chkAdjuntaEvidencia').prop('checked');

            /*

            if (chkEsMedicamento == true) {
                $('#divMedicamento').show();
            } else {
                $('#divMedicamento').hide();
            }

            if (chkEsProcedimiento == true) {
                $('#divProcedimiento').show();
            } else {
                $('#divProcedimiento').hide();
            }

            if (chkEsDispositivoMedico == true) {
                $('#divDispoitivoMedico').show();
            } else {
                $('#divDispoitivoMedico').hide();
            }

            if (chkEsOtro == true) {
                $('#divOtro').show();
            } else {
                $('#divOtro').hide();
            }*/

            if (chkExclusionA == true) {
                $('#divA').show();
            } else {
                $('#divA').hide();
            }

            if (chkExclusionB == true) {
                $('#divB').show();
            } else {
                $('#divB').hide();
            }
            if (chkExclusionC == true) {
                $('#divC').show();
            } else {
                $('#divC').hide();
            }
            if (chkExclusionD == true) {
                $('#divD').show();
            } else {
                $('#divD').hide();
            }
            if (chkExclusionE == true) {
                $('#divE').show();
            } else {
                $('#divE').hide();
            }

            if (chkExclusionF == true) {
                $('#divF').show();
            } else {
                $('#divF').hide();
            }

            if (chkAdjuntaEvidencia == true) {
                $('#divAdjuntaEvidencia').show();
            } else {
                $('#divAdjuntaEvidencia').hide();
            }

            if (chkConflictoInteres == true) {
                $('#divConflicto').show();
            } else {
                $('#divConflicto').hide();
            }
        }
    </script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
        .radioObjetar input, select {
            display:block !important;
            width: 30% !important;
            height: 15px !important;
            margin: 0px 10px 0px !important
        }

        .radioObjetar label{
            display:block !important;
            width: 30% !important;
            height: 15px !important;
            margin: -15px 10px 0px 130px !important;
        }

    </style>
        	<section id="sparticipa" class="temas-par" tabindex="-1">
		<div class="container">
			<div class="row">

                <div class="col-md-8 col-md-offset-2">
					<h2 class="sub">Objeción de nominación</h2>
                           <p class="centerp"><b>FORMATO DE TECNOLOGÍAS NOMINADAS PARA POSIBLE EXCLUSIÓN </b></p>

           
         
					<p class="desc-title">
DIRECCIÓN DE REGULACIÓN DE BENEFICIOS, COSTOS Y TARIFAS DEL ASEGURAMIENTO EN SALUD

               
					</p>
				</div>

			</div>
			
		</div>
	</section>
 <asp:Label runat="server" ID="lblTic" ClientIDMode="Static" style="display:none;"></asp:Label>
    <asp:Label runat="server" ID="lblCodNominacionProceso" ClientIDMode="Static" style="display:none;"></asp:Label>
  

 


    <div class="row">
        <div class="container">
     
            <div class="row">
                
                <div class="col-md-8 col-md-offset-2">

                    <fieldset  id="Fieldset2" class="form-group">
                         <legend><span>
                                     <label  runat="server" ClientIDMode="Static" id="Label42">1 Información del Nominador </label></span></legend>
                          


                    <label for="txtNombreProceso"  ClientIDMode="Static" runat="server" id="Label43">Tipo de Actor del SGSSS  </label>  
                    <asp:TextBox ReadOnly="true" runat="server" Text=""   type="text" name="name"  ID="txttipoUsuario" 
                        MaxLength="100" CssClass="form-control" />

                    <label for="txtNombreTecnologia"  ClientIDMode="Static" runat="server" id="Label44">Nombre persona natural  o de la entidad proponente   </label>  
                    <asp:TextBox ReadOnly="true" runat="server" Text=""   type="text" name="name"  ID="txtNombre" 
                        MaxLength="100" CssClass="form-control" />

                    
                    </fieldset>

                    <fieldset runat="server"  id="FieldsetNominador" visible="false" class="form-group">
                         <legend><span>
                                     <label  runat="server" ClientIDMode="Static" id="Label51">2 Información del objetador </label></span></legend>
                          


                    <label for="txtNombreProceso"  ClientIDMode="Static" runat="server" id="Label52">Tipo de usuario </label>  
                    <asp:TextBox ReadOnly="true" runat="server" Text=""   type="text" name="name"  ID="txtTipoUsuarioObjetador" 
                        MaxLength="100" CssClass="form-control" />

                    <label for="txtNombreTecnologia"  ClientIDMode="Static" runat="server" id="Label53">Nombre  </label>  
                    <asp:TextBox ReadOnly="true" runat="server" Text=""   type="text" name="name"  ID="txtNombreObjetador" 
                        MaxLength="100" CssClass="form-control" />

                 
                    </fieldset>

                <fieldset runat="server" id="Fieldset1" class="form-group">
                                <legend><span>
                                     <label  runat="server" ClientIDMode="Static" id="lblenumeracionNatural">3 Información de la tecnología nominada para posible exclusión</label></span></legend>
                          

                    <label for="txtNombreProceso"  ClientIDMode="Static" runat="server" id="Label26">Proceso </label>  
                    <asp:TextBox runat="server" Text=""   type="text" name="name"  ID="txtNombreProceso" 
                        MaxLength="100" CssClass="form-control" />

                           <div style="border-color:#f3a740;border-style:solid;border-width:1px;padding:10px 10px 10px 10px;">
                        
                    
                    <asp:RadioButton CssClass="radioObjetar checkper" runat="server" GroupName="grupoUno"  ClientIDMode="Static" onchange="Ajustarcheck();"  ID="chkEsMedicamento" Text="Es medicamento " />
                    <asp:RadioButton CssClass="radioObjetar checkper" runat="server" GroupName="grupoUno"  ClientIDMode="Static" onchange="Ajustarcheck();"  ID="chkEsProcedimiento" Text="Es procedimiento " />
                        <br />
                    <asp:RadioButton CssClass="radioObjetar checkper" runat="server"  GroupName="grupoUno"  ClientIDMode="Static" onchange="Ajustarcheck();"  ID="chkEsDispositivoMedico" Text="Es dispositivo médico " />
                    <asp:RadioButton CssClass="radioObjetar checkper" runat="server"  GroupName="grupoUno"  ClientIDMode="Static" onchange="Ajustarcheck();"  ID="chkEsOtro" Text="Otro" />
                        </div>

                    <label for="txtNombreTecnologia"  ClientIDMode="Static" runat="server" id="Label7">Nombre de la tecnología </label>  
                    <asp:TextBox runat="server" Text=""   type="text" name="name"  ID="txtNombreTecnologia" 
                        MaxLength="100" CssClass="form-control" />

                                <label for="cmbGrupoNombreTecnologia"  ClientIDMode="Static" runat="server" id="Label28">Observaciones objeción Nombre de la tecnología </label>
                                <asp:TextBox TextMode="MultiLine" style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  CssClass="form-control" id="cmbGrupoNombreTecnologia" >
                                </asp:TextBox>

                    <br />


                              <div id="divEnfermedad" >
                                    <label for="txtEnfermedad"  ClientIDMode="Static" runat="server" id="Label9">
                                        Nombre la enfermedad o condición de salud que motiva la nominación de exclusión de la tecnologia  </label>
                                    <asp:TextBox runat="server" Text=""   type="text" name="name" ID="txtEnfermedad" MaxLength="300" CssClass="form-control" ClientIDMode="Static" />

                                    <label for="cmbGrupoCie10"  ClientIDMode="Static" runat="server" id="Label48">Observaciones objeción nombre de la enfermedad o condición de salud que motiva la nominación de exclusión de la tecnologia </label>
                                <asp:textbox TextMode="MultiLine" style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  
                                    CssClass="form-control" id="cmbGrupoCie10" >
                                      
                                </asp:textbox>

                                

                                  <label for="txtEnfermedad2"  ClientIDMode="Static" runat="server" id="Label14">breve descripción de la situación en que se da el uso de la tecnología objeto de nominación </label>
                                 
                                    <asp:TextBox runat="server" Text=""   type="text" name="name" ID="txtEnfermedad2" TextMode="MultiLine" MaxLength="300" CssClass="form-control" ClientIDMode="Static" />
                                     <label for="cmbGrupoCie10b"  ClientIDMode="Static" runat="server" id="Label49">Observaciones objeción de la descripción de la situación en que se da el uso de la tecnología objeto de nominación si no hay observaciones&nbsp;, escriba no procede </label>
                                <asp:textbox TextMode="MultiLine"  style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  
                                    CssClass="form-control" 
                                    id="cmbGrupoCie10b"  >
                               </asp:textbox>
                               </div>

             
                              
 
                      </fieldset>
                                <fieldset>
                                    <legend><span>Información de criterios de exclusión</span></legend>
                                    <div id="divA" style="display:none;">
                                           <label for="chkExclusionA"  ClientIDMode="Static" runat="server" id="Label3">A) Que tengan como finalidad principal un propósito cosmético o suntuario no relacionado con la recuperación o mantenimiento de la capacidad funcional o vital de las personas. </label>
                                     
                                        <br>  <asp:CheckBox onchange="Ajustarcheck();" id=chkExclusionA runat="server"  ClientIDMode="Static" text="Seleccionado" />  
                                   
                                        <br>
  
                                    <label for="txtJustificacionA"  ClientIDMode="Static" runat="server" id="Label4">Justifique su elección y aclare si se refiere a una tecnología con propósito cosmético, una tecnología con propósito suntuario o ambas. </label>

                                        <asp:TextBox CssClass="form-control" runat="server" id="txtJustificacionA" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <br>
                                        <label for="cmbGrupoCriterioA"  ClientIDMode="Static" runat="server" id="Label33">Objeción a la justificación del criterio de exclusión</label>
                                <asp:TextBox TextMode="MultiLine" style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  
                                    CssClass="form-control" id="cmbGrupoCriterioA"  >
                                </asp:TextBox>
                                 


                                    </div>
                                    <div id="divB" style="display:none;">
                                     <label for="chkExclusionB"  ClientIDMode="Static" runat="server" id="Label5">B) Que no exista evidencia científica sobre su seguridad y eficacia clínica. </label>
                                   
                                     <br> <asp:CheckBox  onchange="Ajustarcheck();" id=chkExclusionB runat="server"  ClientIDMode="Static" text="Seleccionado" />  
                                    <br>
                                        <label for="txtJustificacionB"  ClientIDMode="Static" runat="server" id="Label6">Justifique su elección. Asimismo, se sugiere que registre los posibles comparadores (tecnologías que cumplan con el mismo fin e indicación) y especifique si el criterio aplica por seguridad, eficacia o ambas. </label>
                                        <asp:TextBox  CssClass="form-control" runat="server" id="txtJustificacionB" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <br>
                                              <label for="cmbGrupoCriterioB"  ClientIDMode="Static" runat="server" id="Label38">Objeción a la justificación del criterio de exclusión </label>
                                <asp:TextBox TextMode="MultiLine"  style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  CssClass="form-control" id="cmbGrupoCriterioB" 
                                    >
                                </asp:TextBox>
                              
                                    </div>
                                    <div id="divC" style="display:none;">
                                    <label for="chkExclusionC"  ClientIDMode="Static" runat="server" id="Label16">C) Que no exista evidencia científica sobre su efectividad clínica. </label>
                                   
                                         <br> <asp:CheckBox  onchange="Ajustarcheck();" id=chkExclusionC runat="server"  ClientIDMode="Static" text="Seleccionado" />  
                                  <br>
                                        <label for="txtJustificacionC"  ClientIDMode="Static" runat="server" id="Label17">Justifique su elección. Asimismo, se sugiere que registre los posibles comparadores (tecnologías que cumplan con el mismo fin e indicación). </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtJustificacionC" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <br>
                                       
                                              <label for="cmbGrupoCriterioC"  ClientIDMode="Static" runat="server" id="Label37">Objeción a la justificación del criterio de exclusión </label>
                                <asp:TextBox  TextMode="MultiLine"  style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  
                                    CssClass="form-control" id="cmbGrupoCriterioC"  >

                                </asp:TextBox>
                              

                                    </div>
                                    <div id="divD" style="display:none;">
                                     <label for="chkExclusionD"  ClientIDMode="Static" runat="server" id="Label18">D) Que su uso no haya sido autorizado por la autoridad competente. </label>
                                   
                                           <br> <asp:CheckBox  onchange="Ajustarcheck();" id=chkExclusionD runat="server"  ClientIDMode="Static" text="Seleccionado" />  
                                           <br>   
                                        <label for="txtJustificacionD"  ClientIDMode="Static" runat="server" id="Label19">Justifique su elección. </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtJustificacionD" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <br>
                                              <label for="cmbGrupoCriterioD"  ClientIDMode="Static" runat="server" id="Label36">Objeción a la justificación del criterio de exclusión </label>
                                <asp:TextBox  TextMode="MultiLine"  style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  CssClass="form-control" id="cmbGrupoCriterioD"  >
                                </asp:TextBox>
                              
                                    </div>
                                    <div id="divE" style="display:none;">
                                     <label for="chkExclusionE"  ClientIDMode="Static" runat="server" id="Label20">E) Que se encuentren en fase de experimentación. </label>
                                    
                                           <br><asp:CheckBox  onchange="Ajustarcheck();" id=chkExclusionE runat="server"  ClientIDMode="Static" text="Seleccionado" />  
                                           <br> 
                                        <label for="txtJustificacionE"  ClientIDMode="Static" runat="server" id="Label21">Justifique su elección. </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtJustificacionE" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <br>
                                             <label for="cmbGrupoCriterioE"  ClientIDMode="Static" runat="server" id="Label35">Objeción a la justificación del criterio de exclusión </label>
                                <asp:TextBox  TextMode="MultiLine"  style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  CssClass="form-control" 
                                    id="cmbGrupoCriterioE"  >

                                </asp:TextBox>
                              
                                    </div>
                                    <div id="divF" style="display:none;">
                                     <label for="chkExclusionF"  ClientIDMode="Static" runat="server" id="Label22">F) Que tengan que ser prestados en el exterior. </label>
                                    
                                           <br>  <asp:CheckBox onchange="Ajustarcheck();" id=chkExclusionF runat="server"  ClientIDMode="Static" text="Seleccionado" />  
                                           <br>
                                        <label for="txtJustificacionF"  ClientIDMode="Static" runat="server" id="Label23">Justifique su elección. </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtJustificacionF" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <br> 
                                             <label for="cmbGrupoCriterioF"  ClientIDMode="Static" runat="server" id="Label34">Objeción a la justificación del criterio de exclusión </label>
                                <asp:TextBox  TextMode="MultiLine"  style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  CssClass="form-control" id="cmbGrupoCriterioF"  >
                                    
                                </asp:TextBox>
                              
                           
                                    </div>
                                </fieldset>
                           <fieldset>
                               <legend>Información adicional presentada por el nominador</legend>
                                <label for="chkConflictoInteres"  ClientIDMode="Static" runat="server" id="Label24">Adjunta evidencia </label>
                               <asp:RadioButton  CssClass="radioObjetar" GroupName="evidencia" onchange="Ajustarcheck();" id=chkAdjuntaEvidencia runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton  CssClass="radioObjetar" GroupName="evidencia" onchange="Ajustarcheck();" id=chkNoAdjuntaEvidencia runat="server"  
                                   ClientIDMode="Static" text="NO" />  
                               <div id="divAdjuntaEvidencia" style="display:none;">
                                   <label for="txtEvidencia"  ClientIDMode="Static" runat="server" id="Label13">Evidencia que soporta la justificación o justificaciones </label>
                                   
                                    
                                  <asp:TextBox runat="server"  CssClass="form-control" id="txtEvidencia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                                    <div id="pnlArchivoJuridico1">   
                                        

                                       
                                     <label for="divDocumentoNatural2" ClientIDMode="Static" runat="server" id="lbltituloArchivoJuridico1">Documento(s) de evidencia  </label>
                                        
                                    
                               <asp:UpdatePanel runat="server" ID="pnlGrillaArchivos" UpdateMode="Conditional">
                                   <ContentTemplate>

                                       <asp:DataList Width="600px" runat="server" ID="grdArchivos" >
                                           <ItemTemplate>
                                                  <div class="form-control">
                                                        <asp:HyperLink runat="server" Text='<%# "Archivo cargado:"+Eval("descripcion") %>'
                                                          target="_blank"  NavigateUrl='<%# "~"+Eval("url").ToString().Substring(Eval("url").ToString().IndexOf("\\files\\Temporal")) %>'
                                                            ></asp:HyperLink>

                                                         </div>
                                               <div>
                                       
                                                            </div>
                                           </ItemTemplate>

                                       </asp:DataList>
                               
                                   </ContentTemplate>
                               </asp:UpdatePanel>
                                        </div>
                                   
                                           <label for="cmbGrupoEvidencia"  ClientIDMode="Static" runat="server" id="Label39">Objeción evidencia </label>
                                <asp:TextBox  TextMode="MultiLine"  style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  CssClass="form-control" 
                                    id="cmbGrupoEvidencia"  >
     
                                </asp:TextBox>
                               
                               </div>

                               <br>
                               <label for="chkConflictoInteres"  ClientIDMode="Static" runat="server" id="Label25">Conflicto de interes </label>
                               
                               <asp:RadioButton   CssClass="radioObjetar" GroupName="conflicto" onchange="Ajustarcheck();" id="chkConflictoInteres" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton  CssClass="radioObjetar" GroupName="conflicto" onchange="Ajustarcheck();" id="chkNoConflictoInteres" runat="server"  
                                   ClientIDMode="Static" text="NO" />  


                               <div id="divConflicto" style="display:none;">
                                   <label for="txtConflicto"  ClientIDMode="Static" runat="server" id="Label1">Descripción conflicto de interes </label>
                                <asp:TextBox runat="server"  CssClass="form-control" id="txtConflicto" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                  

                                    <label for="cmbGrupoConflicto"  ClientIDMode="Static" runat="server" id="Label40">Objeción conflicto de interes </label>
                                <asp:TextBox  TextMode="MultiLine"  style="border-color:#DB0050 !important;border-style:solid;border-width:1px;"   runat="server"  
                                    CssClass="form-control" id="cmbGrupoConflicto"  >
                                </asp:TextBox>
                               
                                  </div>


                               
                        <div id="pnlAcepto2">
                            
                               <label for="txtConflicto"  ClientIDMode="Static" runat="server" id="Label2">Observaciones adicionales </label>
                            
                            <br />
                               <asp:TextBox TextMode="MultiLine" style="border-color:#DB0050 !important;border-style:solid;border-width:1px;" runat="server"  CssClass="form-control" 
                                   id="cmbGrupoConcepto" >
                                      
                                </asp:TextBox>

                              

                               <div id="pnlArchivoJuridico2">   
                                        

                                       
                               <label for="divDocumentoNatural2" ClientIDMode="Static" runat="server" id="lblAdjunteDocumento">En caso de tener información adicional, adjúntela</label>
                                          <asp:Button runat="server" ID="btnArchivo" text="Subir Archivo" OnClick="btnArchivo_Click" />
                                    
                               <asp:UpdatePanel runat="server" ID="pnlGrillaArchivos2" UpdateMode="Conditional">
                                   <ContentTemplate>

                                       <asp:DataList Width="600px" runat="server" ID="grdArchivos2" >
                                           <ItemTemplate>
                                                  <div class="form-control">
                                                        <asp:HyperLink runat="server" Text='<%# "Archivo cargado:"+Eval("descripcion") %>'
                                                          target="_blank"  NavigateUrl='<%# "~"+Eval("url").ToString().Substring(Eval("url").ToString().IndexOf("\\files\\Temporal")) %>'
                                                            ></asp:HyperLink>

                                                      <asp:ImageButton 
                                                          Visible=<%# btnArchivo.Visible %>
                                                          Width="10px" runat="server" ID="btnelimnarARchivo" ImageUrl="~/img/web/delete.png" OnClick="btnelimnarARchivo_Click" ValidationGroup='<%# Eval("url") %>'  />
                                                            </div>
                                               <div>
                                       
                                                            </div>
                                           </ItemTemplate>

                                       </asp:DataList>
                               
                                   </ContentTemplate>
                               </asp:UpdatePanel>
                                        </div>

                            <label for="txtConflicto"  ClientIDMode="Static" runat="server" id="Label41">Observaciones generales objeción</label>
                            
                                <asp:TextBox runat="server"  CssClass="form-control" id="txtObservacionesGenerales" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                               <div class="form-group">
                                    <asp:Label ID="LblValidacionCampos" runat="server" ForeColor="#E4335C" Font-Size="14pt" />
                                </div>

                                <div class="form-group">
                                      <asp:HyperLink ID="lnkPDF" ClientIDMode="Static" Visible="false" runat="server" Text="Generar PDF" target="_blank" 
                                     CssClass="btn green pull-right"  />

                                    <asp:Button runat="server" 
                                        ClientIDMode="Static" OnClick="btnGuardar_Click" type="submit" ID="btnGuardar" Text="Guardar" CssClass="callpart"    />
                                    
                                    <asp:Button runat="server" 
                                        ClientIDMode="Static" OnClick="btnCancelar_Click" type="submit" ID="btnCancelar" Text="Cancelar" CssClass="callpart"    />
                                   </div>
                                        </div>
                           </fieldset>


                        </div>
            </div>
            </div>
    </div>

    

        <asp:Label runat="server" ID="lblInvicible"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="popupNuevo" runat="server"
        BackgroundCssClass="modalBackground" TargetControlID="lblInvicible" 
        DropShadow="true" PopupControlID="pnlCaptura">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnlCaptura" Width="400px" Height="230px" BackColor="White">
        <asp:UpdatePanel ID="upnNuevo" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="vertical-align: central;">
                    <br />
                    <table>
                        <tr >
                            <td>&nbsp;&nbsp;&nbsp;</td>
                             
                            <td colspan="3">       <asp:Label ID="lblTituloDetalle" runat="server" Font-Bold="true" 
                                Text="Descripción del archivo."></asp:Label>
</td>
                        </tr>
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;</td> 
                            <td colspan="3">
                             <asp:TextBox runat="server" ID="txtDescripcionArchivo" Width="380"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;</td> 
                            <td colspan="3">
                            Archivo
                            </td>
                        </tr>
                      
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;</td>
                            <td colspan="3">
                                <div id="div1" runat="server">
                                    <dx:ASPxUploadControl ID="uploadDocumentoNatural" runat="server"
                                        autostartupload="true"
                                        BrowseButton-Image-Height="20px"
                                        BrowseButton-Image-Url="~/Img/file.png"
                                        BrowseButton-Image-Width="20px"
                                        BrowseButton-Text=""
                                        ClientInstanceName="uploadDocumentoNatural"
                                        NullText="Seleccion al archivo..."
                                        OnFileUploadComplete="uploadDocumentoNatural_FileUploadComplete"
                                        ShowProgressPanel="true"
                                        ShowUploadButton="false"
                                        UploadMode="Standard"
                                        ValidationSettings-MaxFileSizeErrorText="El tamaño de los archivos no debe superar 1Gb."
                                        Width="100%">
                                        <AdvancedModeSettings EnableMultiSelect="false" />
                                        <ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.gif,.png,.pdf,.bmp" MaxFileSize="1100000000">
                                        </ValidationSettings>
                                        <ClientSideEvents
                                            FilesUploadComplete="function(s, e) { UpdateUploadButton(); }"
                                            FileUploadComplete="function(s, e) { UpdateUploadButton(s, e); }"
                                            TextChanged="function(s, e) { s.Upload(); }" />
                                    </dx:ASPxUploadControl>
                                </div>
                                <a id="lblArchivoView" runat="server"
                                    class="form-control"
                                    clientidmode="Static"
                                    style="color: #094B59" target="_blank"></a>

                            </td>
                        </tr>


                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblErrorDetalle" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>

                    </table>
                    <table class="table table-striped table-bordered table-hover dataTable">
                        <tr>
                            <td style="text-align: center">
                                <asp:Button ID="btnAceptarDetalle" runat="server" Text="Aceptar" OnClick="btnAceptarDetalle_Click" CausesValidation="true"
                                     CssClass="btn green pull-right" ValidationGroup="ValidarInsertar" />

                                
                            </td>
                            <td style="text-align: center">
                                <asp:Button ID="btnCancelarDetalle" runat="server" Text="Cancelar" OnClick="btnCancelarDetalle_Click"
                                     CssClass="btn green pull-left" />
                            </td>
                        </tr>
                        <tr>
                            <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" ShowSummary="true" ValidationGroup="ValidarInsertar" />
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
