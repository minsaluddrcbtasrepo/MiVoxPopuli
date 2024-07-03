<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmhomeProcesoConsultas.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmhomeProcesoConsultas" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderBienvenido" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                            <li>
                                <asp:HyperLink runat="server" ID="lnkAnalisis" NavigateUrl="../../frm/procesos/frmHomeProcesoAnalisis.aspx">Análisis técnico - científico</asp:HyperLink></li>
                            <li class="active">
                                <asp:HyperLink runat="server" ID="lnkConsultas" NavigateUrl="#">Consulta pacientes</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkAdopcion" NavigateUrl="../../frm/procesos/frmHomeAdopcion.aspx">Adopción y publicación</asp:HyperLink></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-10 amp-proces">
                    <h3>CONSULTA A PACIENTES POTENCIALMENTE AFECTADOS Y CIUDADANÍA</h3>
                    <p>
                        Conozca los resultados de los encuentros con usuarios, pacientes y la ciudadanía en general sobre la conveniencia de declarar dichas tecnologías nominadas para ser excluidas de la financiación con recursos públicos asignados a la salud. 

                    </p>
                    <hr>
                    <div class="uitabs">
                        <ul class="tabs">
                            <li class="tab-link" data-tab="tab-0">Participe</li>
                            <li class="tab-link" data-tab="tab-3">Metodología</li>
                            <li class="tab-link current active" data-tab="tab-2">Resultados</li>
                            
                        </ul>

                        <div id="tab-0" class="tab-content">
                         <h3><asp:Label ID="lblMensajeParticipe" runat="server" Text="El proceso de participación de la fase de “CONSULTA A PACIENTES POTENCIALMENTE AFECTADOS Y CIUDADANÍA” ha finalizado para esta vigencia" Visible="false"></asp:Label></h3>
                         <asp:Repeater runat="server" ID="rptParticipar" DataSourceID="SqlDataSourceArchivosParticipe">
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
                            <asp:SqlDataSource ID="SqlDataSourceArchivosParticipe" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] WHERE (([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO))">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                    <asp:Parameter DefaultValue="PACIENTES" Name="SECCION" Type="String" />
                                    <asp:Parameter DefaultValue="PARTICIPE" Name="SUBSECCION" Type="String" />
                                    <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>


                        
                        
                        </div>


                        <div id="tab-2" class="tab-content  current">
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
                                    <asp:Parameter DefaultValue="PACIENTES" Name="SECCION" Type="String" />
                                    <asp:Parameter DefaultValue="RESULTADOS" Name="SUBSECCION" Type="String" />
                                    <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <h3><asp:Label ID="lblMensaje" runat="server"></asp:Label></h3>
                        </div>
                        <div id="tab-3" class="tab-content ">

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
                            <asp:SqlDataSource ID="SqlDataSourceArchivosMetodologia" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] WHERE (([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO))">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                    <asp:Parameter DefaultValue="PACIENTES" Name="SECCION" Type="String" />
                                    <asp:Parameter DefaultValue="METODOLOGIA" Name="SUBSECCION" Type="String" />
                                    <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>


                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>

</asp:Content>
