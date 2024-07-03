<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeProcesoCups.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeProcesoCups" %>
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
						<p class="desc-title">Es el proceso que se lleva a cabo para actualizar las tecnologías en salud financiadas con recursos de la Unidad de Pago por Capitación –UPC, a las que tienen derechos todos los afiliados al Sistema General de Seguridad Social en Salud.</p>
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
								<li ><asp:HyperLink runat="server" ID="lnkNominacion" NavigateUrl="../../frm/procesos/frmHomeProcesoNominacionUpc.aspx">Nominación</asp:HyperLink></li>
							    <li><asp:HyperLink runat="server" ID="lnkDesicion"  NavigateUrl="#">Decisión y seguimiento</asp:HyperLink></li>
							</ul>
						</div>
					</div>
					<div class="col-lg-10 amp-proces">
						<h3></h3>
						<p>
                            Para garantizar el derecho a la salud, y en desarrollo de la Ley Estatutaria de Salud y del artículo 25 de la Ley 1438 de 2011, el Ministerio desarrolló la
                            <a href="https://www.minsalud.gov.co/sites/rid/Lists/BibliotecaDigital/RIDE/VP/RBC/metodologia-nominacion-actualizacion-pbsupc.zip " target="_blank"><strong>metodología</strong></a>  
                            para poder actualizar de forma <strong>transparente, técnica, permanente y continua </strong>el 
                            <a href="https://www.minsalud.gov.co/sites/rid/Lists/BibliotecaDigital/RIDE/VP/RBC/Resolucion-5269-de-2017.zip">Plan de Beneficios  en salud con cargo a la Unidad de Pago por Capitación.</a>
                            
                        </p>			
			
					</div>

				</div>
			</div>
		</div>

</asp:Content>

