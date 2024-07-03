<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeProcesoNominacionUPC.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeProcesoNominacionUPC" %>


<%@ Register Src="~/frm/controles/controlLogin.ascx" TagPrefix="uc1" TagName="controlLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceBanner" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
       	<div class="container">
			<div class="row">
				<div class="col-md-10 col-md-offset-1">
					<div class="titular">
						<h2 class="sub"><asp:Label runat="server" ID="lblNombreProceso"></asp:Label></h2>
						<p class="desc-title">
                            Es el proceso que se lleva a cabo para actualizar el listado de las tecnologías en salud financiadas con recursos de la Unidad de Pago por Capitación –UPC, a las que tienen derechos todos los afiliados al Sistema General de Seguridad Social en Salud. 

						</p>
					</div>
				</div>
			</div>
		</div>
		<div class="proces">
			<div class="container">
				<div class="row">

					<div class="col-lg-2 mtabs	">
						<div class="menu-cont">
							<ul>
                               <li><asp:HyperLink runat="server" ID="lnkIntroduccion" NavigateUrl="../../frm/procesos/frmHomeProcesoCups.aspx">Introducción</asp:HyperLink></li>
							
								<li class="active"><a  ID="lnkNominacion">Nominación</a></li>
								<li><asp:HyperLink runat="server" ID="lnkDesicion"  NavigateUrl="#">Decisión y seguimiento</asp:HyperLink></li>
							</ul>
						</div>
					</div>
					<div class="col-lg-10 amp-proces">
						<h3>Fase de nominación</h3> 
                        <div style="color:red;"> Las nominaciones serán recibidas únicamente del 1 de abril al 31 de mayo de cada año.</div>
						<p><br />
  Todos los actores del sistema de salud podrán presentar una nominación de un medicamento, procedimiento o servicio para que sean tenidos en cuenta en los procesos de actualización integral del Plan de Beneficios en Salud con cargo a la UPC. 
                            <br /><br />
Recuerde, que la nominación deberá cumplir los requisitos y condiciones descritos en la <strong> metodología</strong>
          </p>
						<hr>
                        <div class="uitabs">
							<ul class="tabs">
	
								<li class='<%= clsAgremiacion %>'  data-tab="tab-1">Nominar</li>
								<li class='<%= clsResultados %>'  data-tab="tab-2">Resultados</li>
                                <li class='tab-link'  data-tab="tab-1b">Metodologia</li>
							</ul>
                            
							<div id="tab-1" class='<%= clsTabAgremiacion %>'>

								<div class="col-md-8 col-md-offset-2">
									<asp:panel runat="server" ID="pnlRegistrese">
                                    <uc1:controlLogin runat="server" id="controlLogin" />

                                        </asp:panel>

										</div>

                                <iframe runat="server" id="iframeNominar" style="width:900px;min-height:1500px;border-width:0px;" ></iframe>
									</div>

                           
                            
							<div id="tab-2" class='<%= clsTabResultados %>'>
                                <asp:Repeater runat="server" ID="rptArchivosResultados" DataSourceID="SqlDataSourceArchivosResultados">
                                    <HeaderTemplate>

                               <ul class="docsarchivos">
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                   <li>
                                <a target="_blank" href='<%# Eval("URL") %>'><%# Eval("TEXTO") %>  </a>
                                   </li>
								

                                    </ItemTemplate>
                                    
                                    <FooterTemplate>

                                    </ul>
                                    </FooterTemplate>
                                </asp:Repeater>
    		                    <asp:SqlDataSource ID="SqlDataSourceArchivosResultados" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" 
                                    SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] 
                                    WHERE (([VIGENCIA] = 1) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) 
                                    AND ([COD_PROCESO] = @COD_PROCESO))">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                        <asp:Parameter DefaultValue="NOMINACION" Name="SECCION" Type="String" />
                                        <asp:Parameter DefaultValue="RESULTADOS" Name="SUBSECCION" Type="String" />
                                        <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                
                                
                   
                            </div>
						    
							
							<div id="tab-1b" class="tab-content">
                                
                                  <ul class="docsarchivos">
                                       <li>
                                <a target="_blank" href='https://www.minsalud.gov.co/sites/rid/Lists/BibliotecaDigital/RIDE/VP/RBC/metodologia-nominacion-actualizacion-pbsupc.zip'>Descargar metodologia  </a>
                                   </li>
                                   </ul>
							</div>
</div>
						
			
					</div>

				</div>
			</div>
</div>

</asp:Content>
