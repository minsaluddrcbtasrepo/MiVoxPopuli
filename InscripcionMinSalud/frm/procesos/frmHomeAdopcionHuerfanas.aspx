<%@ Page Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeAdopcionHuerfanas.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeAdopcionHuerfanas" %>

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
						<p class="desc-title">Fases validadas para la definición de novedades en el listado oficial de las enfermedades huérfanas del país, en el marco de la ley 1392 de 2010 y 1438 de 2011.</p>
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
								<li><asp:HyperLink runat="server" ID="lnkHome" NavigateUrl="../../frm/procesos/frmHomeProcesoNominacionHuerfanas.aspx">Nominación</asp:HyperLink></li>
		                    	<li><asp:HyperLink runat="server" ID="lnkAnalisis" NavigateUrl="../../frm/procesos/frmHomeProcesoAnalisisHuerfanas.aspx">Análisis técnico - científico</asp:HyperLink></li>
							    
								<li class="active"><asp:HyperLink runat="server" ID="lnkAdopcion"  NavigateUrl="#">Publicación de decisiones</asp:HyperLink></li>
						</ul>
						</div>
					</div>
					<div class="col-lg-10 amp-proces">
						<h3>ADOPCIÓN Y PUBLICACIÓN DE LAS DECISIONES</h3>
						<p>Conozca las deciones sobre proceso realizado a las nominaciones</p>
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