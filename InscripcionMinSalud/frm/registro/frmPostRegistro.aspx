<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/masterb.Master" AutoEventWireup="true" CodeBehind="frmPostRegistro.aspx.cs" Inherits="InscripcionMinSalud.frm.registro.frmPostRegistro" %>
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
                <h2 class="tag">Registro Satisfactorio</h2>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
            <div class="col-md-12">
           
                <h2 class="tag">Se ha enviado un mensaje al correo 
                    <asp:Label runat="server" ID="lblCorreo" Text="ingresado"></asp:Label>, para finalizar el registro. 
                    por favor ingrese a la cuenta de correo electrónico registrado y localice el mensaje de confirmación (puede estar en la carpeta de correo no deseado o spam) con el asunto "Verificación de registro a Mi VOX  Pópuli del Ministerio de Salud y Protección Social" y siga los pasos que aparecen en el mensaje para activar la validación de su registro
                     </h2>
        
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


