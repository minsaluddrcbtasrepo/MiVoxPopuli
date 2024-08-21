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
                    <p class="desc-title">Es el proceso que se lleva a cabo para actualizar el listado de los procedimientos que se realizan en el país.</p>
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
                                <asp:HyperLink runat="server" ID="lnkIntroduccion" NavigateUrl="../../frm/procesos/frmHomeProcesoRups.aspx">Introducción</asp:HyperLink></li>

                            <li class="active"><a id="lnkNominacion">Nominación</a></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkAnalisis" NavigateUrl="../../frm/procesos/frmHomeProcesoAnalisisCUPS.aspx">Análisis técnico - científico</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkDesicion" NavigateUrl="../../frm/procesos/frmDecisionSeguimientoCUPS.aspx">Decisión y seguimiento</asp:HyperLink></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-10 amp-proces">
                    <h3>Fase de nominación</h3>
                    <div style="color: red; font-size: 20px;">Esta fase está activa desde el 1 de enero hasta el 31 de marzo de 2024.</div>
                    <br />
                    <p id="divAnuncioAnterior" runat="server" visible="false" style="text-align: justify;">
                         Los diferentes actores del Sistema General de Seguridad Social en Salud, a través de las
                        sociedades cientificas o agremiaciones de profesionales de la Salud, pueden presentar la
                        nominación de un procedimiento en salud para que sea actualizado (incluido, eliminado,
                        reubicado, declarado obsoleto, desagregado o agrupado), dentro de la Clasificación Única
                        de Procedimientos en Salud, diligenciando el formulario de Registro Unico de
                        Procedimientos en Salud -RUPS- disponible en la presente página web, según Io establecido
                        en los articulos 5, 6, 7 y 8 de la Resolución 3804 de 2016.
                        
                    </p>
                   
                    <br />
                    <br />
                    <strong>A continuación verá las diferentes formas de participación. 
                    </strong>


                    <hr>
                    <div class="uitabs" style="border-style: ridge;">
                        <ul class="tabs">
                            <asp:Panel runat="server">
                                <li class='<%= clsAgremiacion %>' data-tab="tab-1">Soy agremiación o asociación de profesionales de la salud</li>
                                <li class='<%= clsAgremiacion %>' data-tab="tab-1">Soy MSPS</li>
                                <li class='<%= clsParticipe %>' data-tab="tab-1b">Soy otro actor</li>
                                <li class='<%= clsMetodologia %>' data-tab="tab-3">Metodología</li>
                                <li class='<%= clsResultados %>' data-tab="tab-2">Resultados</li>

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
                                        <iframe runat="server" id="iframeNominar" style="width: 100%; min-height: 1500px; border-width: 0px;"></iframe>
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
