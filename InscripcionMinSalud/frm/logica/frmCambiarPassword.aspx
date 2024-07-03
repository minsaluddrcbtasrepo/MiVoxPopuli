<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmCambiarPassword.aspx.cs" Inherits="InscripcionMinSalud.frm.logica.frmCambiarPassword" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBienvenido" runat="server">
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="../../css/bootstrap-theme.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" media="all">



      <style>
        input#btnRegistrar{
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
height:50px;
margin: 40px auto;
text-align: center;
}

          input#btnRechazar{
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
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">            

      <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">Actualización de contraseña</h2>
              </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
             <div class="col-md-6 col-md-offset-3">
                <h3 class="separation-title__another">  
                    </h3>
                 <p class="separation-title__another">  
                  </p>

           </div>
            <div class="row">
                
                <div class="col-md-8 col-md-offset-2">
                      <div class="form-group">
                            <label for="txtObservacionesValidacion" id="lbl50">Contraseña actual</label>
                                        <asp:TextBox  ID="txtActual"  
                                            runat="server" CssClass="form-control" TextMode="Password" Width="700" >
                                        </asp:TextBox>

                           <label for="txtObservacionesValidacion" id="lbl50">Contraseña nueva</label>
                                        <asp:TextBox  ID="txtNueva" 
                                            runat="server" CssClass="form-control" TextMode="Password" Width="700"  >
                                        </asp:TextBox>

                           <label for="txtObservacionesValidacion" id="lbl50">Contraseña confirmación</label>
                                        <asp:TextBox  ID="txtConfirmacion"  
                                            runat="server" CssClass="form-control" TextMode="Password" Width="700"  >
                                        </asp:TextBox>
                                </div>
                      <div class="form-group">
                                    <asp:Label ID="LblValidacionCampos" runat="server" ForeColor="#E4335C" Font-Size="14pt" />
                          </div>
                      <div class="form-group">
                                    <asp:Button runat="server" ClientIDMode="Static" OnClientClick="test();"
                                         ID="btnRegistrar" Text="Actualizar contraseña" CssClass="boton2"  OnClick="btnRegistrar_Click"  />
                                       
                                   
                                   </div>
                </div>

              </div>
            </div>
            </div>

    <div style="height: 50px;"></div>
 
</asp:Content>
