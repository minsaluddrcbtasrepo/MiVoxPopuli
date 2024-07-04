<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/frm/master/basicMaster.Master" CodeBehind="frmReporteInscritos.aspx.cs" Inherits="InscripcionMinSalud.Aspx.Reportes.frmReporteInscritos" %>

<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="../../css/bootstrap-theme.css" rel="stylesheet" type="text/css" media="all">
    <link href="../../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" media="all">

</asp:Content>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
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
                <h3 class="separation-title__another">Conozca el total de usuarios inscritos en la herramienta  </h3>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                 
                        
                        <b>Conteo por tipo de usuario</b> 
                        <div class="form-group">
                            <dx:ASPxGridView ID="dtInscritos" SettingsPager-PageSize="40" ClientInstanceName="grid" runat="server" DataSourceID="sqlConsolidado"
                                KeyFieldName="TipoUsuario" Width="100%" SettingsPager-AlwaysShowPager="true"  CssClass="table table-bordered table-striped">
                                <Columns>
                                    <dx:GridViewDataColumn Caption="Id" FieldName="Id" VisibleIndex="0" Visible="false" />
                                    <dx:GridViewDataColumn Caption="Tipo usuario" FieldName="TipoUsuario" VisibleIndex="1" />
                                    <dx:GridViewDataColumn FieldName="Numero" Caption="Total Inscritos" VisibleIndex="2" />
                                    <dx:GridViewDataColumn VisibleIndex="19" Caption="Detalles">
                                        <DataItemTemplate>
                                            <asp:Button runat="server" ID="btnEditar" Text="Ver más" EnableViewState="false" CssClass="botonmin centerimagemin" Visible='<%# CalcularVisible(Eval("Id"))%>' CommandArgument='<%# Eval("Id") %>' OnClick="btnEditar_Click" />
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <Settings ShowFilterRow="false" ShowStatusBar="Hidden" ShowFooter="false" />
                            </dx:ASPxGridView>

                            <asp:SqlDataSource runat="server" ID="sqlConsolidado" SelectCommand="SELECT Id,TipoUsuario, Numero FROM VW_RESUMEN_TIPO"
                                ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>"></asp:SqlDataSource>
                        </div>
                        <div>
                            <dx:WebChartControl ID="ctReporte" runat="server" Height="400px" Width="540px" CssClass="AlignCenter TopLargeMargin"
                                ClientInstanceName="chart" ToolTipEnabled="False">
                            </dx:WebChartControl>
                        </div>                  
                        <br />
                        <b>Conteo por Departamento</b>      
                        
                        <div class="form-group">
                            <dx:ASPxGridView ID="grdDepartamento" SettingsPager-PageSize="40" ClientInstanceName="grid" runat="server" DataSourceID="SqlDepartamento"
                                KeyFieldName="Departamento" Width="100%" SettingsPager-AlwaysShowPager="true"  CssClass="table table-bordered table-striped">
                                <Columns>
                                    <dx:GridViewDataColumn Caption="Id" FieldName="Id" VisibleIndex="0" Visible="false" />
                                    <dx:GridViewDataColumn Caption="Departamento" FieldName="Departamento" VisibleIndex="1" />
                                    <dx:GridViewDataColumn FieldName="Inscritos" Caption="Total Inscritos" VisibleIndex="2" />
                                    <dx:GridViewDataColumn VisibleIndex="19" Caption="Detalles">
                                        <DataItemTemplate>
                                            <asp:Button runat="server" ID="btnDetalleDepartamento" Text="Ver más" EnableViewState="false" CssClass="botonmin centerimagemin"  CommandArgument='<%# Eval("Id") %>' OnClick="btnDetalleDepartamento_Click" />
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <Settings ShowFilterRow="false" ShowStatusBar="Hidden" ShowFooter="false" />
                            </dx:ASPxGridView>

                            <asp:SqlDataSource runat="server" ID="SqlDepartamento" SelectCommand="select 
max(Departamento.Nombre) 'Departamento',count(*) 'Inscritos',Departamento.Id
 from Participante join Municipio on Municipio.Id = Participante.IdMunicipio
join Departamento on Departamento.Id = Municipio.IdDepartamento where idEstadoUsuario =2
group by Departamento.Id order by count(*) desc"
                                ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>"></asp:SqlDataSource>
                        </div>
                     
                   
                </div>
            </div>
        </div>
    </div>    
    <div style="height: 50px;"></div>--%>
</asp:Content>






