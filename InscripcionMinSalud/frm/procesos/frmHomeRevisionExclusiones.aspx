<%@ Page Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeRevisionExclusiones.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeRevisionExclusiones" %>

<%@ Register Src="~/frm/controles/controlLogin.ascx" TagPrefix="uc1" TagName="controlLogin" %>

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
                    <p class="desc-title" style="text-align: justify;">Es el procedimiento por medio del cual se evalúan los posibles cambios en las condiciones o caracterísitcas de la tecnología, que ocurren con posterioridad al momento en el que fue excluida de la financiación con recursos públicos asignados a la salud.</p>
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
                            <%--<li>
                                <asp:HyperLink runat="server" ID="lnkIntroduccion" NavigateUrl="#">Introducción</asp:HyperLink></li>--%>

                            <li class="active"><a id="lnkNominacion">Solicitud de revisión de la decisión de una tecnología previamente excluida:</a></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkAnalisis" NavigateUrl="#">Análisis técnico - científico</asp:HyperLink></li>
                            <%--<li>
                                <asp:HyperLink runat="server" ID="lnkDesicion" NavigateUrl="#">Decisión y seguimiento</asp:HyperLink></li>--%>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-10 amp-proces">
                    <h3>Solicitud de revisión de la decisión de una tecnología previamente excluida</h3>
                    <div style="color: red; font-size: 20px;">Esta fase está activa desde el 15 de octubre hasta el 15 de diciembre de 2024.</div>
                    <br />
                    <p id="divAnuncioAnterior" runat="server" visible="false" style="text-align: justify;">
                        En forma directa o representativa todos los actores del SGSSS están habilitados para solicitar la revisión de la decisión de la tecnología previamente excluida con el cumplimiento de los requisitos técnicos y científicos establecidos para tal fin en el documento de la Metodología. Por lo tanto, el Ministerio de Salud y Protección Social, las Entidades Promotoras de Salud (EPS), las Instituciones Prestadoras de Servicios de Salud (IPS), las Entidades Territoriales, el Instituto de Evaluación Tecnológica en Salud (IETS), los profesionales y trabajadores de la salud, los usuarios y los pacientes de los servicios de salud, las asociaciones de profesionales de la salud, las instituciones académicas y de investigación, la industria, las entidades de control y demás interesados, pueden participar en esta etapa.
                        <br />
                        <br />
                        En esta etapa se permite la participación de todos los actores de conformidad con los
                        mecanismos de participación y las estrategias de convocatoria establecidos en la Circular
                        032 de 2022 o la que la modifique o sustituya.
                    </p>

                    <br />
                    <br />
                    <strong>A continuación verá las diferentes formas de participación. 
                    </strong>


                    <hr>
                    <div class="uitabs" style="border-style: ridge;">
                        <ul class="tabs row">
                            <asp:Panel runat="server">
                                <li class='<%= clsAgremiacion %> col-md-4' data-tab="tab-1">
                                    <img src="/img/web/clic31.png" style="width: 20%; background-color: #013144;" />Participe</li>
                                <%-- <li class='<%= clsAgremiacion %>' data-tab="tab-1">Soy MSPS</li>
                                <li class='<%= clsParticipe %>' data-tab="tab-1b">Soy otro actor</li>--%>
                                <li class='<%= clsMetodologia %>  col-md-4' data-tab="tab-3">Metodología</li>
                                <li class='<%= clsResultados %>  col-md-4' data-tab="tab-2">Resultados</li>

                            </asp:Panel>

                        </ul>

                        <div id="tab-0" class="tab-content">

                            <ul class="docsarchivos">
                                <li>
                                    <a target="_blank" href='https://www.minsalud.gov.co/sites/rid/Lists/BibliotecaDigital/RIDE/VP/RBC/anexos-metodologia-rups.zip'>Descargar formato  </a>
                                </li>
                            </ul>
                        </div>
                        <asp:Panel runat="server" ID="pnl">
                            <div id="tab-1" class='<%= clsTabAgremiacion %>'>

                                <div class="col-md-8 col-md-offset-2">
                                    <asp:Panel runat="server" ID="pnlRegistrese">
                                        <uc1:controlLogin runat="server" ID="controlLogin" />
                                    </asp:Panel>


                                </div>
                                <asp:Panel runat="server" ID="pnlNoRegistrese">
                                    <asp:Panel runat="server" ID="pnlVigenciaNominacion">
                                        <iframe runat="server" id="iframeNominar" style="width: 100%; min-height: 1500px; height: 2000px; border-width: 0px;"></iframe>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlNoVigenciaNominacion">
                                        <h3>El proceso de participación de la Etapa I “Solicitud” ha finalizado para esta vigencia</h3>
                                    </asp:Panel>
                                </asp:Panel>
                            </div>

                            <div id="tab-1b" class='<%= clsTabParticipe %>'>
                                <p>
                                </p>

                            </div>
                        </asp:Panel>
                        <div id="tab-2" class='<%= clsTabResultados %>'>

                            <h3></h3>

                        </div>
                        <div id="tab-3" class='<%=clsTabMetodologia %>'>

                            <div id="tab3Existe">
                            </div>

                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
