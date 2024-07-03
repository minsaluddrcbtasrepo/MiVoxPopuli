<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/frm/master/basicMaster.Master"  CodeBehind="frmOpcionesUsuario.aspx.cs" Inherits="InscripcionMinSalud.Aspx.Registro.frmOpcionesUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Registro Participación Ciudadana</title>
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="../../css/bootstrap-theme.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" media="all">

    <link rel="shortcut icon" href="../../img/EscudoNal.png" />

    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700' rel='stylesheet' type='text/css'>
 <script src="../../Scripts/jquery-1.9.1.js"></script>
<script src="../../Scripts/jquery.min.js"></script>

<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



   
    <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">Estas son las opciones habilitadas para su usuario en el Sistema de Registro de Participación Ciudadana, seleccione la que desea utilizar</h2>
            </div>
        </div>
    </div>

        <div class="row">
            <div class="container">
                <div class="col-md-12">
                    <h3 class="separation-title__another">Opciones del sistema  </h3>
                </div>
                <div class="row">

                    <div class="col-md-8 col-md-offset-3">
                        <h4 runat="server" id="lblNombres"><strong>Nombre del Participante:</strong> Pepito Perez</h4>
                        <h4 runat="server" id="txtCedulas"><strong>Número de identificación:</strong> 1019015415</h4>
                    </div>

                    <div class="col-md-8 col-md-offset-3">
                        <h1></h1>
                    </div>

                    <div class="col-md-4">
                        <asp:ImageButton runat="server" name="btnModificarDatos2" ID="btnModificarDatos2" class="img-responsive centerimagemin" text="Modificar Datos" src="../../images/md.jpg" OnClick="btnModificarDatos2_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:ImageButton runat="server" name="btnImprimirCarnet2" ID="btnEventos" class="img-responsive centerimagemin" text="Inscribirte a un Evento" src="../../images/ie.jpg" OnClick="btnEventos_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:ImageButton runat="server" name="btnSalir2" ID="btnSalir2" class="img-responsive centerimagemin" text="Salir Sistema" src="../../images/s.jpg" OnClick="btnSalir2_Click" />
                    </div>

                </div>
            </div>
        </div>
   
    <div style="height: 50px;"></div>

</asp:Content>



