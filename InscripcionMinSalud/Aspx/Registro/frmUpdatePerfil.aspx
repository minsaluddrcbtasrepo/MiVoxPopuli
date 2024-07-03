<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/basicMaster.Master" AutoEventWireup="true" CodeBehind="frmUpdatePerfil.aspx.cs" Inherits="InscripcionMinSalud.Aspx.Registro.frmUpdatePerfil" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Registro Participación Ciudadana</title>
       
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="../../css/bootstrap-theme.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" media="all">


    <link rel="shortcut icon" href="../../img/EscudoNal.png" />
    
    
    

  
    <%--<script type="text/javascript" src="../../Scripts/jquery-1.8.2.min.js"></script>--%>


   
    <script>
        $(document).ready(function () {
            $('.tooltip').tooltipster();
            $('.fancybox').fancybox();
            AjustePantalla();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    
    <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">Antes de actualizar sus datos, debera actualizar el tipo de usuario registrado.</h2>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
             <div class="col-md-6 col-md-offset-3">
                <h3 class="separation-title__another">Actualización tipo de usario  </h3>

<p class="centerp">Debido a una actualizacion de la plataforma, es necesario actualizar el tipo de usuario asociado al registro.
     </p>

            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">

                 
                        <div id="page">
                            <fieldset class="form-group">
                                <legend><span>1. Tipo usuario registrado</span></legend>
                                
                            
                                
                                 <label for="cmbTipoUsuario">tipo Usuario<span> (Registrado)</span>  
                                     </label>
                                   
                                   <asp:Image Width="20px" Style="float:right;" runat="server" ImageUrl="~/img/web/help.gif" ID="imgTooltip"
                                    class="tooltip" title="Seleccione un item de la lista de elementos" />

                                <asp:DropDownList Enabled="false" runat="server" ClientIDMode="Static"  TabIndex="0" ID="cmbTipoUsuario"  Width="100%" CssClass="form-control" ></asp:DropDownList>  
                                
                              
                            </fieldset>

                               <fieldset class="form-group">
                                <legend><span>1. Tipo usuario nuevo</span></legend>
                                <p>Seleccione el tipo de usuario al cual usted pertenece</p>
                               Seleccione el tipo de Perfil
                    <asp:DropDownList runat="server" ID="cmbTipoPerfil" AutoPostBack="true" OnSelectedIndexChanged="cmbTipoPerfil_SelectedIndexChanged"
                        >
                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Natural" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Juridica" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                                <asp:Panel runat="server" ID="pnlFuturo" Visible="false">
                                 <label for="cmbTipoUsuario">Seleccione tipo Usuario<span> (*)</span>  
                                     </label>
                                   
                                   <asp:Image Width="20px" Style="float:right;" runat="server" ImageUrl="~/img/web/help.gif" ID="Image7"
                                    class="tooltip" title="Seleccione un item de la lista de elementos" />

                                <asp:DropDownList runat="server" ClientIDMode="Static"  TabIndex="0" ID="cmbTipoFuturo"  Width="100%" CssClass="form-control" 
                                     ></asp:DropDownList>  
                                </asp:Panel>
                              
                            </fieldset>

                            
                            <fieldset runat="server" id="flInformacionAcceso" class="form-group">
                            
                                <div class="form-group">
                                    <asp:Label ID="LblValidacionCampos" runat="server" Text="" ForeColor="#E4335C" Visible="true" />
                                </div>

                                <div class="form-group">
                                    <asp:Button runat="server" TabIndex="24" type="submit" ID="btnRegistrar" Text="Enviar" CssClass="botonmin centerimagemin" Width="120px" OnClick="btnRegistrar_Click" Height="34px" />
                                    <asp:Button runat="server" type="submit" TabIndex="25" ID="btnSalir" Text="Regresar" CssClass="botonmin centerimagemin" Width="120px" OnClick="salir_Click" CausesValidation="false" Height="34px" />
                                </div>

                            </fieldset>

               

                        </div>

                </div>
            </div>
        </div>
    </div>    
    <div style="height: 50px;"></div>

    

</asp:Content>






