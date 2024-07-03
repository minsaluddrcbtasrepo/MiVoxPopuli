<%@ Page Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeProcesoAnalisisHuerfanas.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeProcesoAnalisisHuerfanas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function Click1() {
            var lis = document.getElementById("tab-1").getElementsByTagName("li");
            var men1 = document.getElementById("tab1NoExiste");
            var men2 = document.getElementById("tab1Existe");
            if (lis.length > 0) {
                men1.style.display = 'none';
                men2.style.display = 'block';
            }
            else {
                men1.style.display = 'block';
                men2.style.display = 'none';
            }
        }
        function Click2() {
            var lis = document.getElementById("tab-2").getElementsByTagName("li");
            var men1 = document.getElementById("tab2NoExiste");
            var men2 = document.getElementById("tab2Existe");
            if (lis.length > 0) {
                men1.style.display = 'none';
                men2.style.display = 'block';
            }
            else {
                men1.style.display = 'block';
                men2.style.display = 'none';
            }
        }
        function Click3() {
            var lis = document.getElementById("tab-3").getElementsByTagName("li");
            var men1 = document.getElementById("tab3NoExiste");
            var men2 = document.getElementById("tab3Existe");
            if (lis.length > 0) {
                men1.style.display = 'none';
                men2.style.display = 'block';
            }
            else {
                men1.style.display = 'block';
                men2.style.display = 'none';
            }
        }

        $(document).ready(function () {
            Click1();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceBanner" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="titular">
                    <h2 class="sub">
                        <asp:Label runat="server" ID="lblNombreProceso"></asp:Label></h2>
                    <p class="desc-title">Fases validadas para la definición de novedades en el listado oficial de las enfermedades huérfanas del país, en el marco de la ley 1392 de 2010 y 1438 de 2011.</p>
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
                            <li>
                                <asp:HyperLink runat="server" ID="lnkHome" NavigateUrl="../../frm/procesos/frmHomeProcesoNominacionHuerfanas.aspx">Nominación</asp:HyperLink></li>
                            <li class="active"><a href="#">Análisis técnico - científico</a></li>
                            
                            <li>
                                <asp:HyperLink runat="server" ID="lnkAdopcion" NavigateUrl="../../frm/procesos/frmHomeAdopcionHuerfanas.aspx">Publicación de decisiones</asp:HyperLink></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-10 amp-proces">
                    <h3>ANÁLISIS TÉCNICO-CIENTÍFICO</h3>
                    <p>
                        Conozca los estudios,documentos técnicos,conceptos y recomendaciones de los diagnósticos o cambios específicos nominados para la actualización del listado oficial de las enfermedades huérfanas del país.     
                    </p>
                    <hr>
                    <div class="uitabs">
                        <ul class="tabs">
                            <%--<li class="tab-link" data-tab="tab-1" onclick="Click1()">Conceptos de las nominaciones</li>--%>
                            <li class="tab-link current active" data-tab="tab-3" onclick="Click3()">Instructivo</li>
                            <li class="tab-link" data-tab="tab-2" onclick="Click2()">Resultados</li>
                        </ul>


                        <div id="tab-2" class="tab-content">
                            <div id="tab2NoExiste">
                                <h3><asp:Label ID="lblMensaje" runat="server" Text="No existen documentos cargados para los resultados"></asp:Label></h3>
                            </div>
                            <div id="tab2Existe">
                                <asp:Repeater runat="server" ID="rptArchivosResultados" DataSourceID="SqlDataSourceArchivosResultados">
                                    <HeaderTemplate>

                                        <ul class="docsarchivos">
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <li>
                                            <a target="_blank" href='<%# Eval("URL") %>'><%# Eval("TEXTO") %>  </a>
                                        </li>


                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSourceArchivosResultados" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] WHERE (([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO))">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                        <asp:Parameter DefaultValue="TECNICO" Name="SECCION" Type="String" />
                                        <asp:Parameter DefaultValue="RESULTADOS" Name="SUBSECCION" Type="String" />
                                        <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>

                        </div>
                        <div id="tab-3" class="tab-content">
                            <div id="tab3NoExiste">
                                <h3>No existen documentos cargados para la metodología</h3>
                            </div>
                            <div id="tab3Existe">
                                <asp:Repeater runat="server" ID="rptMetodlogia" DataSourceID="SqlDataSourceArchivosMetodologia">
                                    <HeaderTemplate>

                                        <ul class="docsarchivos">
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <li>
                                            <a target="_blank" href='<%# Eval("URL") %>'><%# Eval("TEXTO") %>  </a>
                                        </li>


                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSourceArchivosMetodologia" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>"
                                    SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] WHERE (([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) 
                                    AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO))">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                        <asp:Parameter DefaultValue="TECNICO" Name="SECCION" Type="String" />
                                        <asp:Parameter DefaultValue="METODOLOGIA" Name="SUBSECCION" Type="String" />
                                        <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>

                            </div>
                        </div>

                        <div id="tab-1" class="tab-content current">
                            <div id="tab1NoExiste">
                                <h3>No existen documentos cargados para el concepto</h3>
                            </div>
                            <div id="tab1Existe">
                                <asp:Repeater runat="server" ID="Repeater1" DataSourceID="SqlDataSource1">
                                    <HeaderTemplate>

                                        <ul class="docsarchivos">
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <li>
                                            <a target="_blank" href='<%# Eval("URL") %>'><%# Eval("TEXTO") %>  </a>
                                        </li>


                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT 1 as orden,url,texto
                                FROM [ARCHIVOXPROCESO] WHERE ([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO)   ">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                        <asp:Parameter DefaultValue="TECNICO" Name="SECCION" Type="String" />
                                        <asp:Parameter DefaultValue="DANIEL" Name="SUBSECCION" Type="String" />
                                        <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>

                    </div>

                </div>

            </div>
        </div>
    </div>

</asp:Content>
