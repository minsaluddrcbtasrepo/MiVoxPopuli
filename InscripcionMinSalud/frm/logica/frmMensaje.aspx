<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmMensaje.aspx.cs" Inherits="InscripcionMinSalud.frm.logica.frmMensaje" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBienvenido" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
     <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="../../css/bootstrap-theme.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" media="all">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag"><asp:Label runat="server" ID="lbltitulo"></asp:Label></h2>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
            <div class="col-md-12">
           
                <p class="tag">
                    <asp:Label runat="server" ID="lblmensaje"></asp:Label>
                     </p>
        
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
            
                        <div class="form-group">

                       </div>                        
                   
                </div>
            </div>
        </div>
    </div>    
    <div style="height: 50px;"></div>
</asp:Content>
