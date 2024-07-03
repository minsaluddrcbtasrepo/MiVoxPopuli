<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/masterb.Master" AutoEventWireup="true" CodeBehind="verificar.aspx.cs" Inherits="InscripcionMinSalud.frm.registro.verificar" EnableEventValidation="false" %>

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
                <h2 class="tag">Verificación  de registro </h2>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
            <div class="col-md-12">
                <h3 class="separation-title__another">
                    <asp:Panel runat="server" ID="lnkNovalido" Visible="false">
                        <p>Link de Verificación no valido </p>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="lnkValido" Visible="false">
                        <p>
                            Muchas gracias por inscribirse a Mi Vox-Populi del Ministerio de Salud y Protección Social. En este momento, 
                                                                <%--<b>la Dirección de Regulación de Beneficios, Costos y Tarifas del Aseguramiento en Salud está validando su información. </b>--%>

                            <b>la Dirección de Regulación de Beneficios, Costos y Tarifas del Aseguramiento en Salud está validando su información. </b>
                            <br />
                            <br />
                            En un plazo máximo de <b>8 días</b> se le enviará una respuesta a su solicitud a la dirección de correo electrónico registrado.


                        </p>
                    </asp:Panel>


                    <asp:Panel runat="server" ID="lnkValidadoPrevio" Visible="false">
                        <p>
                            Su cuenta de correo fue validada previamente.
                        </p>
                    </asp:Panel>

                    <br />
                    <br />
                    <br />
                    <asp:Button runat="server" TabIndex="10" type="submit" ID="btnSalir" Text="Salir" CssClass="botonmin centerimagemin" Width="120px" OnClick="btnSalir_Click" Height="34px" />


                </h3>
            </div>

        </div>
    </div>
    <div style="height: 50px;"></div>
</asp:Content>



