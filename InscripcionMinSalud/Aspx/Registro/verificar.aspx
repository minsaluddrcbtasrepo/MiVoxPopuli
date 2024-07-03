<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verificar.aspx.cs" Inherits="InscripcionMinSalud.Aspx.Registro.verificar" %>

<!DOCTYPE HTML>
<html>
<head>
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
</head>

<body>
    <div class="row">
        <div class="lazul"></div>
        <div class="container section">
            <div class="col-md-6">
                <img class="img-responsive" src="../../images/imagenes.jpg">
            </div>
            <div class="col-md-6">
                <img class="img-responsive" src="../../images/logo-part.jpg">
            </div>
        </div>
        <div class="nav">
            <div class="container">
                <ul>
                 <li><a href="../../Aspx/Registro/frmOpcionesUsuario.aspx">Inicio</a></li>                  
                    <li class="active"><a href="../../Aspx/Registro/frmParticipante.aspx">Regístrese</a></li>
                    <li><a href="../../Aspx/Seguridad/frmLogin.aspx">Actualización datos</a></li>
                    <li><a href="../../Aspx/Reportes/frmReporteInscritos.aspx">Conozca</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="tagline">
            <div class="container">
            </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
            <div class="col-md-12">
                <h3 class="separation-title__another">Verificación  de registro  </h3>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <form runat="server" id="frmInicio">
                        <ajaxToolkit:ToolkitScriptManager ID="jquery" runat="server" AsyncPostBackTimeout="7200" EnablePartialRendering="true"></ajaxToolkit:ToolkitScriptManager>
                        <div class="form-group">
                            <asp:Panel runat="server" ID="lnkNovalido">
                                                            <p>

                Link de Verificación no valido
                                

      </p>                    
                            </asp:Panel>
                            <asp:Panel runat="server" ID="lnkValido" Visible="false">
                                                            <p>

Muchas gracias por inscribirse al Sistema de Participación Ciudadana. En este momento, 
                                                                <b>la Dirección de Regulación de Beneficios, Costos y Tarifas del Aseguramiento en Salud está validando su información. </b>
                                                                <br /> <br />
En un plazo máximo de <b>8 días</b> se le enviará una respuesta a su solicitud a la dirección de correo electrónico registrado.


      </p>                    
                            </asp:Panel>
</div>
                        <asp:Button runat="server" TabIndex="10" type="submit" ID="btnSalir" Text="Salir" CssClass="botonmin centerimagemin" Width="120px" OnClick="btnSalir_Click" Height="34px"/>
                    </form>
                </div>                
            </div>
        </div>
    </div>    
    <div style="height: 50px;"></div>
</body>
</html>