<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmTematicasActivas.aspx.cs" 
    Inherits="InscripcionMinSalud.frm.procesos.frmTematicasActivas" %>
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

    div#ContentPlaceHolder1_popupTecnologias_foregroundElement {
 position: fixed;
 z-index: 100001;
 left: 453.5px;
 top: 71px;
 height: auto !important;
 overflow: auto !important;
}

div#ContentPlaceHolder1_popupTecnologias_foregroundElement label{

 color: #266373 !important;
 margin: 17px 0px 5px 10px !important;
 display: inline !important;

}
     </style>

    <style>

   .btnCancelar{
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

         a#lnkVerMas{
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

         th, td {
    padding: 10px;
    text-align: left;
    border-bottom: 1px solid #ddd;
}

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      	<section id="sparticipa" class="temas-par" tabindex="-1">
		<div class="container">
			<div class="row">

                <div class="col-md-8 col-md-offset-2">
					<h2 class="sub">Nuestros eventos vigentes</h2>
					<p class="desc-title">


                        Seleccione el tema de su interés.

					</p>
				</div>

			</div>



    <div class="row stemas">
        <asp:panel runat="server" id="pnleventos">
              <asp:Repeater runat="server" ID="grdProcesos" DataSourceID="SqlDataSource1">
            
            <ItemTemplate>
				<div class='col-md-6 col-lg-offset-3'>
					<div class="tema">

						<div class="date">
							<p><strong>

                                </strong>
                                <ol>
                                <li><asp:HyperLink  runat="server"
                                    text='<%# Eval("NOMBRE_PROCESO") %>'
                                    NavigateUrl='<%# "frmTematicasActivas2.aspx?cod="+Eval("COD_PROCESO") %>'
                                    >


                                </asp:HyperLink> </p></li>

                            </ol>
						</div>


                         
					</div>
				</div> 

                </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="


select distinct PROCESO.COD_PROCESO,PROCESO.NOMBRE_PROCESO from EVENTO
join PROCESO on PROCESO.COD_PROCESO = EVENTO.COD_PROCESO

where getdate() between EVENTO.visible_desde and EVENTO.visible_hasta ">
                         
                          
                    </asp:SqlDataSource>
       </asp:panel>
        <asp:panel runat="server" id="pnlNoEventos">
            <h2>No hay eventos de participación habilitados por el momento</h2>
        </asp:panel>
        </div>
            </div>
	</section>
   

</asp:Content>
