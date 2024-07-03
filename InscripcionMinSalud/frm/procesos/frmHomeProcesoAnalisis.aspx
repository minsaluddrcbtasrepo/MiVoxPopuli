<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeProcesoAnalisis.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeProcesoAnalisis" %>
<%@ Register Src="~/frm/controles/controlLogin.ascx" TagPrefix="uc1" TagName="controlLogin" %>

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
                    <p class="desc-title">Conjunto de fases que tiene que atravesar un servicio o tecnología en salud para dejar de ser financiada con recursos públicos destinados a la salud</p>
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
                                <asp:HyperLink runat="server" ID="lnkHome" NavigateUrl="../../frm/procesos/frmHomeProceso.aspx">Nominación y priorización</asp:HyperLink></li>
                            <li class="active"><a href="#">Análisis técnico - científico</a></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkConsultas" NavigateUrl="../../frm/procesos/frmHomeProcesoConsultas.aspx">Consulta pacientes</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkAdopcion" NavigateUrl="../../frm/procesos/frmHomeAdopcion.aspx">Adopción y publicación</asp:HyperLink></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-10 amp-proces">
                    <h3>ANÁLISIS TÉCNICO-CIENTÍFICO</h3>
                    <p>
                        Conozca los estudios del Instituto de Evaluación
                        Tecnológica en Salud –IETS, y los conceptos y
                        recomendaciones de los servicios y tecnologías que
                        fueron nominados para ser excluidas de la financiación
                        con recursos públicos asignados a la salud.         
                    </p>
                    <hr>
                    <div class="uitabs">
                        <ul class="tabs">
                            <li class="tab-link  active" data-tab="divParticipe" onclick="Click0()">Participe</li>
                            <li class="tab-link" data-tab="tab-1" onclick="Click1()">Concepto del Instituto de Evaluación Tecnológica en Salud.</li>
                            <li class="tab-link" data-tab="tab-3" onclick="Click3()">Metodología</li>
                            <li class="tab-link" data-tab="tab-2" onclick="Click2()">Resultados</li>
                            
                        </ul>

                        <div id="divParticipe" class="tab-content current"  runat="server"  >                                
                            <div id="divXxx">  
                            <asp:Panel runat="server" ID="pnlRegistrese">                             
                                <uc1:controlLogin runat="server" ID="controlLogin" />
                            </asp:Panel>
                             <asp:Panel runat="server" ID="pnlNoRegistrese">
                                <asp:Panel runat="server" ID="pnlNoVigenciaNominacion">
                                    <h3>Este espacio de participación es exclusivo para que las sociedades científicas deleguen a sus participantes en los eventos que se realizarán en septiembre de 2020.</h3>
                                </asp:Panel>
                           </asp:Panel>
                                <asp:Panel runat="server" ID="pnlVigenciaNominacion">
                                   
                                    <iframe width="100%" height= "700px"  src= "https://forms.office.com/Pages/ResponsePage.aspx?id=OuG3v7d_FkCDDNNxbo3YuLzNwN7HGUxDmcNyONcPDKRUMDNDMlUzU1gzTEJBMTJKVDBTTlVSN1MyTiQlQCN0PWcu" allowfullscreen webkitallowfullscreen mozallowfullscreen msallowfullscreen> </iframe>
                                
                                </asp:Panel>
                            </div>
                          </div>

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
                                <asp:SqlDataSource ID="SqlDataSourceArchivosResultados" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] WHERE (([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO)) ORDER BY TEXTO">
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

                        <div id="tab-1" class="tab-content" >
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
