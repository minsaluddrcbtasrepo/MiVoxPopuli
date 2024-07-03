<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeProcesoRups.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeProcesoRups" %>
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
						<p class="desc-title">Es el proceso que se lleva a cabo para actualizar el listado de los procedimientos que se realizan en el país.</p>
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
								<li class='active'><a href="#">Introducción</a></li>
								<li ><asp:HyperLink runat="server" ID="lnkNominacion" NavigateUrl="../../frm/procesos/frmHomeProcesoNominacionCups.aspx">Nominación</asp:HyperLink></li>
								<li><asp:HyperLink runat="server" ID="lnkAnalisis"  NavigateUrl="#">Análisis técnico - científico</asp:HyperLink></li>
								<li><asp:HyperLink runat="server" ID="lnkDesicion"  NavigateUrl="#">Decisión y seguimiento</asp:HyperLink></li>
							</ul>
						</div>
					</div>
					<div class="col-lg-10 amp-proces">
						<h3></h3>
						<p>
                            Para garantizar el derecho a la salud, y en desarrollo de la Ley Estatutaria de Salud, el Ministerio expidió la Resolución 3804 de 2016. Adicionalmente, desarrolló la 
                            
                            
                            <a href="https://www.minsalud.gov.co/sites/rid/Lists/BibliotecaDigital/RIDE/VP/RBC/metodologia-resolucion-cups.zip">

                            <strong>metodología</strong>
                            </a> y las fases que se requieren para poder actualizar de forma 
                            <strong>transparente, técnica, permanente y continua </strong>el 
                            <a target="_blank" href="https://www.minsalud.gov.co/sites/rid/Lists/BibliotecaDigital/RIDE/VP/RBC/metodologia-resolucion-cups.zip">
listado de los procedimientos
                            </a>
                             en salud que se realizan en el país.
                            <br /><br />
Las fases para actualizar la CUPS son tres: </p>
                            <ul>
                                <li>- Nominación</li>
                                <li>- Análisis técnico-científico</li>
                                <li>- Decisión y seguimiento</li>
                            </ul>

						<hr>
						
					</div>

				</div>
			</div>
		</div>

</asp:Content>

