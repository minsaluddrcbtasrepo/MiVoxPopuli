<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/frm/master/basicMaster.Master" CodeBehind="frmConfirmacionEvento.aspx.cs" Inherits="InscripcionMinSalud.Aspx.evento.frmConfirmacionEvento" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"><meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Registro Participaciòn Ciudadana</title>



<link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css">
<link href="../../css/bootstrap-theme.css" rel="stylesheet" type="text/css" media="all">
<link href="../../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" media="all">

<link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700' rel='stylesheet' type='text/css'>

<script src="../../Scripts/jquery-1.9.1.js"></script>
<script src="../../Scripts/jquery.min.js"></script>

<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
     <style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    
    .imagenP img{
             max-height:200px;
             max-width:200px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
<div class="tagline">
<div class="container">
<h2 class="tag"><strong>Participe activamente en el desarrollo del Procedimiento técnico-científico (PTC). </h2>
</div>
</div>
</div>
    
  
<div class="row">
<div class="container">
    
    <asp:UpdatePanel runat="server" ID="pnlForm" UpdateMode="Conditional" >
        <Triggers>
            <asp:PostBackTrigger ControlID="btnconfirmar" />
        </Triggers>
        <ContentTemplate>

        
    <asp:panel runat="server" ID="pnlinicial" Visible="true" >
<div class="col-md-6 col-md-offset-3 formre">
    <br />
<p>En este espacio usted podrá hacer parte de nuestra convocatoria para el desarrollo de la fase tres del PTC:Consulta a pacientes potencialmente afectados.
 
Esta fase tiene como objetivo consultar la opinión de los pacientes acerca de la conveniencia de declarar las tecnologías nominadas como una exclusión, es decir, que no será financiada con recursos que el país asigna para la salud. 
 
Si a usted le interesa hacer parte de esta consulta, inscríbase a continuación:</p>
   

    <asp:Label runat="server" ID="lblError" Text="" ForeColor="Red"></asp:Label>
    <div  class="c2a">
        <asp:Button runat="server"  class="botonmin1" Text="Confirmar" ID="btnconfirmar" OnClick="btnconfirmar_Click" />
        
    </div>
  



</div>
        </asp:panel>
    <asp:panel runat="server" ID="pnlfinal" visible="false"  >
        <div class="container">
            
<h2 class="tag"><strong>gracias</strong>  por confirmar su asistencia. </h2>
</div>
        
    </asp:panel>
            </ContentTemplate>
    </asp:UpdatePanel>
</div>
</div>




<div class="footer"></div>
<div style="height:50px;"></div>

<!--3 modal-->



    <asp:Label runat="server" ID="lblInvicible"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="popupNuevo" runat="server"
        BackgroundCssClass="modalBackground" TargetControlID="lblInvicible" 
        DropShadow="true" PopupControlID="pnlCaptura" >
    </ajaxToolkit:ModalPopupExtender>

      <asp:Panel runat="server" ID="pnlCaptura" Width="400px" Height="580px" style="display:none;" >
    <asp:UpdatePanel ID="upnNuevo" runat="server" UpdateMode="Conditional">
            <ContentTemplate>      
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        
        <h4 class="modal-title" id="myModalLabel">Confirmar Asistencia</h4>
      </div>
      <div class="modal-body">
          <asp:Panel runat="server" ID="pnlDelegadoSolo" Visible="true">
      <p> <asp:label runat="server" ID="lblDelegado" Text="Ingrese la información del delegado."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombre"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellido"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtEmail"  ></asp:textbox><br>
          </asp:Panel>
          <asp:panel runat="server" ID="pnlDelegadosExtras" visible="false">
              <div style="overflow-y: scroll; height:400px;">
                  <asp:panel runat="server" ID="pnldelegado1">
                          <div class="modal-body">
      <p> <asp:label runat="server" ID="Label10" Text="Ingrese la información del delegado 1."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombre1"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellido1"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtEmail1"  ></asp:textbox><br>

          

      </div>
                      </asp:panel>
                  <asp:panel runat="server" ID="pnldelegado2">
               <div class="modal-body">
      <p> <asp:label runat="server" ID="Label1" Text="Ingrese la información del delegado 2."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombre2"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellido2"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtEmail2"  ></asp:textbox><br>

          

      </div>
                      </asp:panel>
                  <asp:panel runat="server" ID="pnldelegado3">
              <div class="modal-body">
      <p> <asp:label runat="server" ID="Label2" Text="Ingrese la información del delegado 3."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombre3"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellido3"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtEmail3"  ></asp:textbox><br>

          

      </div>
                      </asp:panel>
                  <asp:panel runat="server" ID="pnldelegado4">
              <div class="modal-body">
      <p> <asp:label runat="server" ID="Label3" Text="Ingrese la información del delegado 4."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombre4"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellido4"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtemail4"  ></asp:textbox><br>

          

      </div>
                      </asp:panel>
                  <asp:panel runat="server" ID="pnldelegado5">
              <div class="modal-body">
      <p> <asp:label runat="server" ID="Label4" Text="Ingrese la información del delegado 5."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombre5"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellido5"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtemail5"  ></asp:textbox><br>

          

      </div>
                      </asp:panel>
                  <asp:panel runat="server" ID="pnldelegado6">
              <div class="modal-body">
      <p> <asp:label runat="server" ID="Label5" Text="Ingrese la información del delegado 6."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombre6"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellido6"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtEmail6"  ></asp:textbox><br>

          

      </div>
                      </asp:panel>
                  <asp:panel runat="server" ID="pnldelegado7">
              <div class="modal-body">
      <p> <asp:label runat="server" ID="Label6" Text="Ingrese la información del delegado 7."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombre7"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellido7"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtEmail7"  ></asp:textbox><br>

          

      </div>
                      </asp:panel>
                  <asp:panel runat="server" ID="pnldelegado8">
              <div class="modal-body">
      <p> <asp:label runat="server" ID="Label7" Text="Ingrese la información del delegado 8."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombre8"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellido8"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtEmail8"  ></asp:textbox><br>

          

      </div>
                      </asp:panel>
                  <asp:panel runat="server" ID="pnldelegado9">
              <div class="modal-body">
      <p> <asp:label runat="server" ID="Label8" Text="Ingrese la información del delegado 9."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombres9"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellidos9"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtEmail9"  ></asp:textbox><br>

          

      </div>
                      </asp:panel>
                  <asp:panel runat="server" ID="pnldelegado10">
              <div class="modal-body">
      <p> <asp:label runat="server" ID="Label9" Text="Ingrese la información del delegado 10."></asp:label> </p>
 
  <label>Nombre</label><br>
  <asp:textbox runat="server" ID="txtNombre10"  ></asp:textbox><br>
 <label> Apellido</label> <br>
 <asp:textbox runat="server" ID="txtApellido10"  ></asp:textbox><br>
           <label> Email</label> <br>
<asp:textbox runat="server" ID="txtEmail10"  ></asp:textbox><br>

          

      </div>
                      </asp:panel>
                  

        </div>

          </asp:panel>



          <asp:label runat="server" ID="lblErrorPopUp" ForeColor="Red"></asp:label><br>
         <asp:Button runat="server" ID="btnAceptar" Text="Confirmar Delegado" OnClick="btnAceptar_Click" />


      </div>
      <div class="modal-footer">
          <asp:Button runat="server"  ID="btnConfirmarsinAcompanante" Text="Confirmar sin Delegado" OnClick="btnConfirmarsinAcompanante_Click" />
          <asp:Button runat="server"  ID="btnCancelarDetalle" Text="Cancelar" OnClick="btnCancelarDetalle_Click" />
      
       
      </div>
    </div>
</ContentTemplate>
    </asp:UpdatePanel>
      </asp:Panel>
                
</asp:Content>




