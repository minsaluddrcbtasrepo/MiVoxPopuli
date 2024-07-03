<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReporteDetalleInscritos.aspx.cs" Inherits="InscripcionMinSalud.Aspx.Reportes.frmReporteDetalleInscritos" %>

<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



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
                    <li><a href="../../Aspx/Registro/frmParticipante.aspx">Regístrese</a></li>
                    <li><a href="../../Aspx/Seguridad/frmLogin.aspx">Actualización datos</a></li>
                    <li class="active"><a href="../../Aspx/Reportes/frmReporteInscritos.aspx">Conozca</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">Consolidado de información</h2>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
            <div class="col-md-12">
                <h3 class="separation-title__another" runat="server" id="lblTitulo">Listado total participantes inscritos para el tipo de usuario: XXX  </h3>
            </div>            
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <form runat="server" id="frmInicio">                        
                        <div>
                            <table style="width: 100%">                                
                                <tr>
                                    <td colspan="2">
                                        <dx:ASPxGridView ID="grdParticipantes" ClientInstanceName="grid" runat="server" DataSourceID="SqlDataParticipantes"
                                            KeyFieldName="Nombre" Width="100%" SettingsPager-AlwaysShowPager="true" SettingsPager-PageSize="40"  CssClass="table table-bordered table-striped">
                                            <Columns>
                                                <dx:GridViewDataColumn Caption="Tipo usuario" FieldName="TipoUsuario" VisibleIndex="1" Visible="false" />
                                                <dx:GridViewDataColumn FieldName="Nombre" Caption="Nombre entidad" VisibleIndex="2" />
                                            </Columns>
                                            <Settings ShowFilterRow="false" ShowStatusBar="Visible" ShowFooter="true" />
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="Nombre" SummaryType="Count" DisplayFormat="Total Partipantes = {0}" />
                                            </TotalSummary>
                                        </dx:ASPxGridView>
                                        <dx:ASPxGridViewExporter ID="exportDatos" runat="server" GridViewID="grdParticipantes" ExportedRowType="All" />
                                    </td>
                                    <asp:SqlDataSource ID="SqlDataParticipantes" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>"
                                        SelectCommand="select b.Nombre as TipoUsuario, a.Nombres as Nombre
                                        from participante a inner join TipoUsuario b on a.IdTipoUsuario = b.Id 
                                        where a.IdTipoUsuario= @TipoUsuario and a.IdEstadoUsuario = 2">
                                        <SelectParameters>
                                            <asp:QueryStringParameter DbType="Int32" QueryStringField="TipoUsuario" Name="TipoUsuario" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </tr>
                                <tr></tr>
                                <tr>
                                    <td>
                                        <asp:Button runat="server" ID="btnExportarExcel" Text="Exportar Excel" CssClass="botonmin centerimagemin" OnClick="btnExportarExcel_Click" Width="120px" Height="34px" />                                        
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnRegresar" Text="Regresar" CssClass="botonmin centerimagemin" OnClick="btnRegresar_Click" Width="120px" Height="34px" />                                        
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>    
    <div style="height: 50px;"></div>
</body>
</html>

