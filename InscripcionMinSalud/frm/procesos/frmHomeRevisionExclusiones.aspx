<%@ Page Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeRevisionExclusiones.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeRevisionExclusiones" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceBanner" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .row {
            margin-bottom: 20px;
        }

        .col-md-6 {
            padding: 15px;
            background-color: #f7f7f7;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }
        .col-md-6>h2{
            height:50px;
        }
         .col-md-6>p{
            height:80px;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="titular">
                    <h2 class="sub">
                        <asp:Label runat="server" ID="lblNombreProceso"></asp:Label></h2>
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
                            <li>
                                <asp:HyperLink runat="server" ID="lnkNominacion" NavigateUrl="#">Tab1</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkAnalisis" NavigateUrl="#">Tab2</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkDesicion" NavigateUrl="#">Tab3</asp:HyperLink></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-10 amp-proces">
                    <h3></h3>
                    <p>
                        Los diferentes actores del Sistema General de Seguridad Social en Salud, a través de las
                        sociedades cientificas o agremiaciones de profesionales de la Salud, pueden presentar la
                        nominación de un procedimiento en salud para que sea actualizado (incluido, eliminado,
                        reubicado, declarado obsoleto, desagregado o agrupado), dentro de la Clasificación Única
                        de Procedimientos en Salud, diligenciando el formulario de Registro Unico de
                        Procedimientos en Salud -RUPS- disponible en la presente página web, según Io establecido
                        en los articulos 5, 6, 7 y 8 de la Resolución 3804 de 2016.
                    </p>

                    <div class="row d-flex justify-content-between">
                        <div class="col-md-6 align-self-start">
                            <h2>¿Es nuevo en nuestra plataforma?
                            </h2>
                            <br />
                            <p>Si quiere empezar a participar en nuestros procesos solo debe registrase</p>
                            <asp:Button ID="btnRegistro" runat="server" Text="Registrarme" CssClass="btn btn-primary register" />
                        </div>
                        <div class="col-md-6 align-self-start">
                            <h2>¿Ya está inscrito en <strong>Mi Vox-Populi</strong>?</h2>
                            <br />
                            <p>Ingrese con el correo electrónico registrado

                            </p>
                            <asp:Button ID="btnIngreso" runat="server" Text="Ingresar" CssClass="btn btn-primary" />
                        </div>
                    </div>

                    <hr>
                </div>

            </div>
        </div>
    </div>

</asp:Content>

