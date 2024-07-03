<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmEventosTematica.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmEventosTematica" %>

<%@ Register Src="~/frm/controles/controlLogin.ascx" TagPrefix="uc1" TagName="controlLogin" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBienvenido" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

    <style>

  
         th, td {
    padding: 10px;
    text-align: left;
    border-bottom: 1px solid #ddd;
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

        .btnEsp{
                float: left;
                max-width: 200px;
                background-color: #d82f5e;
                color: white;
                margin-right: 20px;
                border-radius: 25px;
              }
    </style>
    <link href="../../Scripts/fancy/source/fancyMins.css" rel="stylesheet" />

    <script type="text/javascript">
        function hidepopup()
        {
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
        }
        function showPopup() {
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            

            modalPopupBehavior.show();


        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          	<section id="sparticipa" class="temas-par" tabindex="-1">
		<div class="container">
			<div class="row">

                <div class="col-md-8 col-md-offset-2">
					<h2 class="sub"><asp:Label runat="server" ID="lblNombreProceso"></asp:Label></h2>
					<p class="desc-title">
<asp:Label runat="server" ID="lblTitulo"></asp:Label> 

					</p>
				</div>

			</div>



    <div class="row stemas">
        <div class="container">
    
            <div class="row">
                
                <div class="col-md-8 col-md-offset-2">
                    
                    <asp:DataList runat="server" ID="datos" DataKeyField="COD_EVENTO" DataSourceID="SqlDataSource1"  >
                       <ItemTemplate>
                                <fieldset runat="server" id="Fieldset1" class="form-group" style=" margin:10px !important;">
                                <legend> </legend>
<table style="bor">
    <tr>
        <td>Nombre del evento</td>
        <td><b><%# Eval("NOMBRE_EVENTO") %></b></td>
    </tr>
    <tr>
        <td>Descripción</td>
        <td><%# Eval("DESCRIPCION_EVENTO") %></td>
    </tr>
    <tr>
        <td>Requisitos que deben cumplir los invitados:</td>
        <td><%# Eval("REQUISITOS") %></td>
    </tr>
    <tr>
        <td>Público objetivo:</td>
        <td><%# Eval("PUBLICO_OBJETIVO") %></td>
    </tr>
    <tr>
        <td>Lugar</td>
        <td><%# Eval("LUGAR") %></td>
    </tr>
    <tr>
        <td>Fecha del evento</td>
        <td><%# ((DateTime)Eval("FECHA")).ToLongDateString()  %></td>
    </tr>
    <tr>
        <td>Hora del evento</td>
        <td>De <%# ((DateTime)Eval("FECHA")).ToLongTimeString()  %>
            a <%# ((DateTime)Eval("FECHA")).AddHours(int.Parse(Eval("DURACION_EVENTO").ToString())).ToLongTimeString()  %></td>
    </tr>
    <tr>
        <td>Temática</td>
        <td><%# Eval("NOMBRE_TEMATICA") %></td>
    </tr>
     <tr>
        <td>Cupos</td>
        <td><%# Eval("CAPACIDAD_MAXIMA") %></td>
    </tr>

    <tr>
        <td>Cupos disponibles</td>
        <td><%# verCuposLibres( Eval("COD_EVENTO")) %></td>
    </tr>

     <tr>
        <td>Estado</td>
        <td><%# verEstado( Eval("COD_EVENTO")) %></td>
    </tr>
    <tr>
               <td colspan="2">                             
                                              <asp:Button runat="server" CssClass="btnEsp" ID="lnkVerMas" Text="Confirmar asistencia" OnClick="btnconfirmarEvento_Click" CommandArgument='<%# Eval("COD_EVENTO") %>' visible='<%# verVisibleConfirmar(Eval("COD_EVENTO")) %>' />
                                              <asp:Button runat="server" CssClass="btnEsp" ID="btnCancelar" Text="Cancelar asistencia" OnClick="btnCancelar_Click" CommandArgument='<%# Eval("COD_EVENTO") %>'  OnClientClick="return confirm('Esta seguro de cancelar su confirmación a este evento?');" visible='<%# verVisibleCancelar(Eval("COD_EVENTO")) %>' />
                                              <asp:Button runat="server" CssClass="btnEsp" ID="btncompletarInscripcion" Text="Editar asistencia" OnClick="btncompletarInscripcion_Click" CommandArgument='<%# Eval("COD_EVENTO") %>' visible='<%# verVisibleCompletar(Eval("COD_EVENTO")) %>' />

                                        

        </td>
    </tr>
</table>
                                    

                         

                                      </fieldset>
                        </ItemTemplate>

                    </asp:DataList>
                         





                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="
                            SELECT TEMATICA_EVENTO.NOMBRE_TEMATICA,
                            COD_EVENTO, TEMATICA_EVENTO.COD_TEMATICA_EVENTO, NOMBRE_EVENTO, PROYECTO_ASOCIADO, DESCRIPCION_EVENTO, PUBLICO_OBJETIVO, REQUISITOS, FECHA, LUGAR, CAPACIDAD_MAXIMA, 
                            DURACION_EVENTO,  PERMITE_REPETIR_ASISTENCIA ,PERMITE_PERSONAS_NATURALES
                            from EVENTO join TEMATICA_EVENTO on TEMATICA_EVENTO.COD_TEMATICA_EVENTO = EVENTO.COD_TEMATICA_EVENTO
                            where EVENTO.COD_TEMATICA_EVENTO= @COD_TEMATICA_EVENTO
                            and getdate() between visible_desde and visible_hasta
                            ">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="COD_TEMATICA_EVENTO" QueryStringField="cod" />
                            </SelectParameters>
                          
                    </asp:SqlDataSource>
                         





                        </div>
            </div>
            </div>
    </div>
</div>
                  </section>
    
    <asp:Label runat="server" ID="lblCodigoConfirmacion" Visible="false"></asp:Label>
    
    <asp:Label runat="server" ID="lblCodigoEvento" style="display:none;" Visible="true"></asp:Label>
    
    <asp:Label runat="server" ID="lblInvicible"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="popupIngresar" runat="server"
        BackgroundCssClass="modalBackground" TargetControlID="lblInvicible" 
         BehaviorID="programmaticModalPopupBehavior"
        DropShadow="true" PopupControlID="pnlCaptura" CancelControlID="lnkRegistrarme" >
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" BackColor="White" ID="pnlCaptura" Width="800px" Height="380px" style="display:none;" >
    
							<div id="tab-1" class="tab-content current">
   
								<div class="col-md-8 col-md-offset-2">
                                    <section class="contenedor call2">
        <div class="row registro">
            <div class="col-md-6 pad">
                <h2>¿Es nuevo en nuestra plataforma?</h2>
                <p>Si quiere empezar a participar en nuestros procesos solo debe registrarse</p>
                <div class="call">
                    <span class="callres">
      <a data-toggle="modal" id="lnkRegistrarme" runat="server" data-target="#myModal" href="#">Registrarme</a>
                    </span>
                </div>
            </div>
            <div class="col-md-6 pad">
                <h2>¿Ya está inscrito en Mi Vox-Populi?</h2>
                <p>Ingrese con el correo electrónico registrado</p>
                 <div class="call">
                    <span class="callpart">
      <a data-toggle="modal" id="lnlIngresar" data-target="#myModal2" onclick="hidepopup()" href="#">Ingresar</a>
                    </span>
                </div>
            </div>
        </div>
    </section>

             <div class="titulos">
                <asp:Button CssClass="btnEsp" BackColor="#fdb449" ForeColor="White" Font-Size="14px" Width="200" Height="45" class="boton" runat="server" ID="btnCancelarRegstro" Text="Cancelar" OnClick="btnCancelarRegstro_Click1" />

            </div>

                                    </div>
    
          </div>

      </asp:Panel>

 
    <ajaxToolkit:ModalPopupExtender ID="popupMensaje" runat="server" BackgroundCssClass="modalBackground" 
        TargetControlID="lblInvicible" DropShadow="true" PopupControlID="pnlMensaje" >
    </ajaxToolkit:ModalPopupExtender>

       <asp:Panel runat="server" BackColor="White" ID="pnlMensaje" Width="700px" Height="280px" style="display:none;" >
    
    <section class="contenedor call2" style="background-color:white !important;">
        <div class="row registro">
            
            <div class="col-md-12 pad">
                <h2>Mi Vox-Populi</h2>
                <p><asp:label runat="server" ID="lblMensaje"></asp:label></p>
                
            </div>
           
        </div>
          <div class="row registro">

             <div class="titulos">
                <asp:Button CssClass="boton" BackColor="#fdb449" ForeColor="White" Font-Size="14px" Width="200" Height="45" class="boton" runat="server" ID="btnCerrarMensaje" Text="Cerrar" OnClick="btnCerrarMensaje_Click" />

            </div>
          </div>
    </section>
      </asp:Panel>



    
    <ajaxToolkit:ModalPopupExtender ID="popupTecnologias" runat="server" BackgroundCssClass="modalBackground" 
        TargetControlID="lblInvicible" DropShadow="true" PopupControlID="pnlSeleccionarTecnologias" >
    </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" BackColor="White" ID="pnlSeleccionarTecnologias" Width="800px" Height="480px" style="display:none;" >
    
   <section class="contenedor call2" style="background-color:white !important;">
        <div class="row registro">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

            <div class="col-md-12 ">
                <h2> Seleccione las tecnologías en las cuales desea manifestar su opinión</h2>
                <asp:Button runat="server" ID="btnSeleccionarTodasTEcnologias" OnClick="btnSeleccionarTodasTEcnologias_Click" Text="Seleccionar todas" />
                 
    
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT TECNOLOGIA.COD_TECNOLOGIA, TECNOLOGIA.NOMBRE_TECNOLOGIA FROM TECNOLOGIASXEVENTO INNER JOIN TECNOLOGIA ON TECNOLOGIASXEVENTO.COD_TECNOLOGIA = TECNOLOGIA.COD_TECNOLOGIA WHERE (TECNOLOGIASXEVENTO.COD_EVENTO = @codEvento)">
         <SelectParameters>
             <asp:ControlParameter ControlID="lblCodigoEvento" Name="codEvento" PropertyName="Text" DefaultValue="1" />
         </SelectParameters>
     </asp:SqlDataSource>
                
                
            </div>
            <div class="titulos">
                <p class="tag">
   <asp:datalist runat="server" ID="grdTecnologias"  DataSourceID="SqlDataSource2" 
        DataKeyNames="COD_TECNOLOGIA"  >
       <ItemTemplate>
                    <asp:CheckBox runat="server" ID="chkSeleccionar" ValidationGroup='<%# Eval("COD_TECNOLOGIA") %>' 
         text='<%# Eval("NOMBRE_TECNOLOGIA") %>' />

       </ItemTemplate>
       
       
       
     </asp:datalist> </p>

            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
           
        </div>
       <asp:UpdatePanel runat="server" ID="pnl">
           <ContentTemplate>
        <div class="row registro">
            <asp:Label runat="server" ID="lblErrorTEcnologias" ForeColor="Red"></asp:Label>
            </div>
          <div class="row registro">

             <div class="titulos">
                <asp:Button CssClass="btnEsp" BackColor="#fdb449" ForeColor="White" Font-Size="14px" Width="200" Height="45" class="boton" runat="server" ID="btnCancelarTecnologias" Text="Cancelar" OnClick="btnCancelarTecnologias_Click" />
                 <asp:Button CssClass="btnEsp" BackColor="#fdb449" ForeColor="White" Font-Size="14px" Width="200" Height="45" class="boton" runat="server" ID="btnAceptarTecnologias" Text="Confirmar" OnClick="btnAceptarTecnologias_Click" />

            </div>
          </div>

           </ContentTemplate>
       </asp:UpdatePanel>
    </section>
      </asp:Panel>

</asp:Content>
