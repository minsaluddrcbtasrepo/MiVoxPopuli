<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmLineaTiempo.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmLineaTiempo" %>
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
						<h2 class="sub">¿Cómo vamos?</h2>
                            <asp:Label runat="server" ID="lblNombreProceso" Visible="false"></asp:Label>
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
								<li class="active"><a href="#">¿Cómo vamos?</a></li>
							</ul>
						</div>
					</div>
					<div class="col-lg-10 amp-proces">
			
						<div style="width: 100%;"><div style="position: relative; padding-bottom: 56.25%; padding-top: 0; height: 0;"><iframe frameborder="0" width="1200" height="675" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;" src="https://www.genial.ly/View/Index/59f8c038fc317c16a0d39acc" type="text/html" allowscriptaccess="always" allowfullscreen="true" scrolling="yes" allownetworking="all"></iframe></div></div>

					</div>

				</div>
			</div>
		</div>

</asp:Content>
