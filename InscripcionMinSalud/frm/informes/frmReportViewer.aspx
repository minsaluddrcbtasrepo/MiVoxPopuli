<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmReportViewer.aspx.cs" Inherits="InscripcionMinSalud.frm.informes.frmReportViewer" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBienvenido" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <rsweb:reportviewer  id="ReportViewer1" runat="server" AsyncRendering="False"  Width="1400px" Height="800px">
</rsweb:reportviewer>
<p>
</p>
</asp:Content>
