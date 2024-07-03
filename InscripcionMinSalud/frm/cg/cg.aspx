<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cg.aspx.cs" Inherits="InscripcionMinSalud.frm.cg.cg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel runat="server" ID="pnlSeguridad">
<asp:TextBox TextMode="Password" ID="txtPassword" runat="server"></asp:TextBox>
        <asp:Button runat="server" ID="btnPassword" Text="Ingresar" OnClick="btnPassword_Click" />


    </asp:Panel>

            <asp:Panel runat="server" ID="pnlaccion" Visible="false">
                <asp:Button ID="btnSql" runat="server" Text="SQL" OnClick="btnSql_Click" />
                <asp:Button ID="btnArchivos" runat="server" Text="Archivos" OnClick="btnArchivos_Click" />
                <asp:Button ID="btnCarpetas" runat="server" Text="Carpetas" OnClick="btnCarpetas_Click" />
                <asp:Panel runat="server" ID="pnlSQL" Visible="false">
                     <table class="auto-style1">
                    <tr>
                        <td>Comando SQL</td>
                        <td>Server
                            <asp:TextBox ID="txtserver" runat="server" Width="200px">172.16.1.215\SQL_SVR_2016</asp:TextBox>
                            &nbsp;usuario
                            <asp:TextBox ID="txtusuarioBD" runat="server" Width="200px">participacion</asp:TextBox>
                            &nbsp;<br /> password
                            <asp:TextBox ID="txtPassBD" runat="server" Width="200px">participacion2017</asp:TextBox>
                            &nbsp;bd
                            <asp:TextBox ID="txtBD" runat="server" Width="200px">Participacion2017</asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="6">
                            <asp:TextBox ID="txtSql" runat="server" Height="92px" Width="1008px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblErrorComando" runat="server"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnEjecutarConsulta" runat="server" Text="Ejecutar consulta" OnClick="btnEjecutarConsulta_Click" />
                            <asp:Button ID="btnEjecutarComando" runat="server" OnClick="btnEjecutarComando_Click" Text="Ejecutar comando" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:TextBox ID="txtSqlHistoricos" runat="server" Height="113px" TextMode="MultiLine" Width="908px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Button runat="server" ID="btnExcel" Text="Exportar Excel" OnClick="btnExcel_Click"  />
                            <asp:GridView ID="grdDatos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                            </asp:GridView>
                        </td>
                    </tr>
 
                                       <tr>
                        <td style="background-color: #FF0066">&nbsp;</td>
                        <td style="background-color: #FF0066">&nbsp;</td>
                        <td style="background-color: #FF0066">&nbsp;</td>
                        <td style="background-color: #FF0066">&nbsp;</td>
                        <td style="background-color: #FF0066">&nbsp;</td>
                        <td style="background-color: #FF0066">&nbsp;</td>
                    </tr>
                 
                </table>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlArchivos" Visible="false">
                    
                <table class="auto-style1">
   <tr>
                        <td><strong>ZONA DE ARCHIVOS</strong></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>subir archivos</td>
                        <td>ruta ~/<asp:TextBox ID="ttxSubirArchivo" runat="server"></asp:TextBox>
                            /<asp:Label ID="lblErrorSubir" runat="server" ForeColor="Red"></asp:Label>
                            <br />
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="btnSubir" runat="server" OnClick="btnSubir_Click" Text="Subir" />
                            <br />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="background-color: #0066FF">&nbsp;</td>
                        <td style="background-color: #0066FF">&nbsp;</td>
                        <td style="background-color: #0066FF">&nbsp;</td>
                        <td style="background-color: #0066FF">&nbsp;</td>
                        <td style="background-color: #0066FF">&nbsp;</td>
                        <td style="background-color: #0066FF">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>bajar archivos</td>
                        <td>ruta ~/<asp:TextBox ID="txtRutaBajar" runat="server"></asp:TextBox>
                            /&nbsp;
                            <br />
                            prefijo archivo&nbsp;<asp:TextBox ID="txtPrefijoArchivo" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            &nbsp;
                            <asp:Button ID="btnBuscarArchivos" runat="server" OnClick="btnBuscarArchivos_Click" Text="Buscar Archivos" />
                            <br />
                            <asp:GridView ID="grdArchivos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="10000">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" NavigateUrl='<%# Eval("url") %>' Target="_blank" Text='<%# Eval("nombre") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="background-color: #3399FF">&nbsp;</td>
                        <td colspan="5" style="background-color: #3399FF">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="5">para renombrar poner c:\servidor\ruta\nombre</td>
                    </tr>
                    <tr>
                        <td>Renombrar archivos</td>
                        <td colspan="5">arhivo origen<asp:TextBox ID="txtArchivoOrigenRename" runat="server" Width="643px"></asp:TextBox>
                            <asp:Label ID="lblErrorRenombrar" runat="server" ForeColor="Red"></asp:Label>
                            <br />
                            archivo final
                            <asp:TextBox ID="txtArchivoFinalRenonmbrar" runat="server" Width="643px"></asp:TextBox>
                            <asp:Button ID="btnRenombrar" runat="server" OnClick="btnRenombrar_Click" Text="Renombrar" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlCarpetas" Visible="false">
                    PROXIMAMENTE
                </asp:Panel>
                
    </asp:Panel>

    </div>
    </form>
</body>
</html>
