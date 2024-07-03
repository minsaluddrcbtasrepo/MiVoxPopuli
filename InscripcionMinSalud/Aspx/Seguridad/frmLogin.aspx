<%@ Page Language="C#"  MasterPageFile="~/frm/master/basicMaster.Master"  AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="InscripcionMinSalud.Aspx.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <title>Registro Participación Ciudadana</title>
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="../../css/bootstrap-theme.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" media="all">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">Si ya se encuentra registrado, en este módulo usted podrá administrar sus datos e inscribirse en los eventos de participación. Ingrese su usuario y contraseña.
                   <br /> Si aún no está registrado, haga clic <a href="../Registro/frmParticipante.aspx"> <u>aquí</u></a>

                </h2>

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
                            <label for="txtUsuario">Número de documento</label>
                            <asp:TextBox ID="txtUsuario" runat="server" MaxLength="20" CssClass="form-control" /><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="ftCedula" runat="server" FilterType="Custom" ValidChars="1234567890abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ- " TargetControlID="txtUsuario" />                            
                        </div>
                        <div class="form-group">
                            <label for="txtContrasena">Contraseña</label>
                            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" MaxLength="20" CssClass="form-control" /><br />                            
                        </div>
                        <asp:Button ID="btnBuscar" Text="Ingresar " runat="server" OnClick="btnBuscar_Click" CssClass="botonmin centerimagemin" Width="89px" Height="34px" />                        
                        <br />
                        <asp:Label ID="lblMensaje" Text="" runat="server" ForeColor="#a94442" Visible="false" />
                        <div class="form-group">                      
                            <asp:LinkButton ID="lnkOlvidoContrasena" Text="¿Olvidó su contraseña?" runat="server" OnClick="lnkOlvidoContrasena_Click" CausesValidation="false" CssClass="alert-info centerimagemin" />                                                        
                        </div>
          
                </div>
            </div>
        </div>
    </div>    
    <div style="height: 50px;"></div>

</asp:Content>


