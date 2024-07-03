<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmOlvidoContrasena.aspx.cs" Inherits="InscripcionMinSalud.frm.seguridad.frmOlvidoContrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="../../css/bootstrap-theme.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" media="all">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">Recuperar contraseña</h2>

            </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
            <div class="col-md-12">
                <h3 class="separation-title__another">Mi cuenta  </h3>
            </div>
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
          
                        <asp:Label runat="server" ID="lblPaginaAnterior" Visible="false"></asp:Label>
                     
                        <div class="form-group">
                            <label for="txtUsuario">Ingrese su Nombre de Usuario</label>
                            <asp:TextBox ID="txtUsuario" runat="server" MaxLength="20" CssClass="form-control" /><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="ftCedula" runat="server" FilterType="Custom" ValidChars="1234567890abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ- " TargetControlID="txtUsuario" />                            
                        </div>
                        
                        <asp:Button ID="btnRecuperar" Text="Recuperar contraseña " runat="server" OnClick="btnRecuperar_Click" CssClass="botonmin centerimagemin" Width="190px" Height="34px" />                        
                        <br />
                        <asp:Label ID="lblMensaje" Text="" runat="server" ForeColor="#a94442" Visible="true" />
                        <div class="form-group">   
                                               ¿Olvidó su Usuario?, puede recuperar su nombre de usuario dando click en el siguiente 
                            <asp:LinkButton ID="lnkOlvidoContrasena" Text="vinculo" runat="server" OnClick="lnkOlvidoContrasena_Click" CausesValidation="false" CssClass="alert-info centerimagemin" />                                                        
                        </div>
          
                </div>
            </div>
        </div>
    </div>    
    <div style="height: 50px;"></div>

</asp:Content>
