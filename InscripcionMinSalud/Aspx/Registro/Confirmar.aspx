<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/frm/master/basicMaster.Master"  CodeBehind="Confirmar.aspx.cs" Inherits="InscripcionMinSalud.Aspx.Confirmar" %>

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
            </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
            <div class="col-md-12">
                <h3 class="separation-title__another">Gracias por su interés en el de Registro de Participación Ciudadana.  </h3>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                          <div class="form-group">
                            <p>

Hemos enviado un mensaje al correo que usted ha inscrito. Revíselo y continúe con el proceso.
                                <br />
<b>EN CASO</b> de no haberlo recibido, verifique en su carpeta de spam, o correo no deseado.

      </p>                    </div>
                        <asp:Button runat="server" TabIndex="10" type="submit" ID="btnSalir" Text="Salir" CssClass="botonmin centerimagemin" Width="120px" OnClick="btnSalir_Click" Height="34px"/>
      
                </div>                
            </div>
        </div>
    </div>    
    <div style="height: 50px;"></div>

</asp:Content>





