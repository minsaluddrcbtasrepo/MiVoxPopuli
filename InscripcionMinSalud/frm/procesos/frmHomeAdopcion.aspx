<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeAdopcion.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeAdopcion" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderBienvenido" runat="server">
</asp:Content>
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
						<p class="desc-title">Conjunto de fases que tiene que atravesar un servicio o tecnología en salud para dejar de ser financiada con recursos públicos destinados a la salud</p>
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
								<li><asp:HyperLink runat="server" ID="lnkHome" NavigateUrl="../../frm/procesos/frmHomeProceso.aspx">Nominación y priorización</asp:HyperLink></li>
			                    <li><asp:HyperLink runat="server" ID="lnkAnalisis" NavigateUrl="../../frm/procesos/frmHomeProcesoAnalisis.aspx">Análisis técnico - científico</asp:HyperLink></li>
					
							    <li><asp:HyperLink runat="server" ID="lnkConsultas"  NavigateUrl="../../frm/procesos/frmHomeProcesoConsultas.aspx">Consulta pacientes</asp:HyperLink></li>
								<li class="active"><asp:HyperLink runat="server" ID="lnkAdopcion"  NavigateUrl="#">Adopción y publicación</asp:HyperLink></li>
						</ul>
						</div>
					</div>
					<div class="col-lg-10 amp-proces">
						<h3>ADOPCIÓN Y PUBLICACIÓN DE LAS DECISIONES</h3>
						<p>Conozca el listado de servicios y tecnologías que han sido excluidos de la financiación pública con recursos a la salud
 
 </p>
						<hr>
						<div class="uitabs">
							<ul class="tabs">
								
								<li class="tab-link current active"  data-tab="tab-2">Resultados</li>
						
							</ul>
                            
							
							<div id="tab-2" class="tab-content current">
                                       <asp:Repeater runat="server" ID="rptMetodlogia" DataSourceID="SqlDataSourceArchivosMetodologia">
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
    		                    <asp:SqlDataSource ID="SqlDataSourceArchivosMetodologia" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" 
                                    SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] WHERE (([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO))">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                        <asp:Parameter DefaultValue="PUBLICACION" Name="SECCION" Type="String" />
                                        <asp:Parameter DefaultValue="METODOLOGIA" Name="SUBSECCION" Type="String" />
                                        <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <h3><asp:Label ID="lblMensaje" runat="server"></asp:Label></h3>
						    </div>

							
</div>
			
					</div>

				</div>
			</div>
		</div>

</asp:Content>