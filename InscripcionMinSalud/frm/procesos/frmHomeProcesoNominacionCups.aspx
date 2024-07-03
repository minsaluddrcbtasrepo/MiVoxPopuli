<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeProcesoNominacionCups.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeProcesoNominacionCups" %>

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
                        Los diferentes actores del Sistema General de Seguridad Social en Salud, a través de las sociedades cientificas o agremiaciones de profesionales de la Salud, pueden presentar la nominación de un procedimiento en salud para que sea actualizado (incluido, eliminado, reubicado, declarado obsoleto, desagregado o agrupado), dentro de la Clasificación Única de Procedimientos en Salud, diligenciando el formulario de Registro Único de Procedimientos en Salud -RUPS- disponible en la presente página web, según lo establecido en los artículos 5, 6, 7 y 8 de la Resolución 3804 de 2016.
                        
                    </p>
                    <br />
                    <p id="divAnuncioActual" runat="server" style="text-align: justify;">
                        Los diferentes actores del Sistema General de Seguridad Social en Salud, a través de las agremiaciones de profesionales de la Salud pueden presentar la nominación de un procedimiento en salud para que sea actualizado (incluido, eliminado, reubicado, declarado obsoleto, desagregados o agrupados), dentro de la Clasificación Única de Procedimientos en Salud, diligenciando el formulario de Registro Único de Procedimientos en Salud -RUPS- disponible en la presente página web, según lo establecido en los artículos 5, 6, 7 y 8 de la Resolución 3804 de 2016.
                    </p>
                    <br />
                    <p style="text-align: justify;">
                        Para presentar propuestas de nominación para la Clasificación Única de Procedimientos en Salud – CUPS, se debe diligenciar el respectivo formato Web “Registro Único de Procedimientos en Salud – RUPS –“;  según se requiera, así: Formato para procedimientos nuevos en el territorio nacional, es decir que no se haya ejecutado previamente en el país, que no se encuentra en fase de experimentación, que tengan la suficiente evidencia científica de seguridad, eficacia y efectividad clínica, así como la disponibilidad de los recursos técnicos, tecnológicos y de infraestructura necesarios para ser prestados en el país o el formato para otros ajustes, de los procedimientos ya descritos en la CUPS y que requieran la modificación de su descripción, reubicación, eliminación, desagregación, agrupación o monitoreo por obsolescencia. 
                    </p>
                    <br />
                    <p style="text-align: justify;">
                        Para el diligenciamiento formato requerido, debera tener en cuenta los instructivos para su diligenciamiento según corresponda y la Metodología para la presentación de propuestas de nominación para la Actualización de la Clasificación Única de Procedimientos en Salud – CUPS. Anexos que podrá descargar en la pestaña Metodología”.
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
                                        <h3>El proceso de participación de la fase de “NOMINACIÓN Y PRIORIZACIÓN” ha finalizado para esta vigencia</h3>
                                    </asp:Panel>
                                </asp:Panel>
                            </div>

                            <div id="tab-1b" class='<%= clsTabParticipe %>'>
                                <p>
                                    Diligencie los formatos que están en el siguiente 
                                   <a href="https://mivoxpopuli.minsalud.gov.co/InscripcionParticipacionCiudadana/documentos/Metodologia/2024/anexos-metodologia-rups-2024.zip">enlace</a>
                                    y envíelos a la agremiación de profesionales de la salud para su respectivo aval. No se debe enviar directamente al Ministerio.

                                </p>

                            </div>
                        </asp:Panel>
                        <div id="tab-2" class='<%= clsTabResultados %>'>
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
                                    <asp:Parameter DefaultValue="NOMINACION" Name="SECCION" Type="String" />
                                    <asp:Parameter DefaultValue="RESULTADOS" Name="SUBSECCION" Type="String" />
                                    <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>


                            <h3></h3>
                            <div class="panel panel-default">
                                <asp:Repeater runat="server" ID="rptResultados" DataSourceID="SqlDataSource1" OnItemDataBound="rptResultados_ItemDataBound">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Tipo</th>
                                                    <th>Tecnologia</th>
                                                    <th>Fecha nominación</th>
                                                    <th>Estado</th>
                                                    <th>Opciones</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Eval("COD_NOMINACION_PROCESO_RUPS") %></th>
                                            <td><%# Eval("CALIFICACION_AJUSTE") %></td>
                                            <td><%# Eval("NOMBRE_PROCEDIMIENTO") %></td>
                                            <td><%# Eval("FECHA_REGISTRO") %></td>
                                            <td><%# Eval("NOMBRE_ESTADO_NOMINACION_RUPS") %></td>
                                            <td>
                                                <a href='<%# "../informes/frmReportViewer.aspx?rpt=2&cod="+Eval("COD_NOMINACION_PROCESO_RUPS") %>' target="_blank" id="lnkPDF">Descargar PDF</a>
                                                <asp:Panel runat="server" ID="pnlObjeciones" Visible="false">
                                                    <a data-toggle="modal" data-target='<%# "#myModalobjeciones"+Eval("COD_NOMINACION_PROCESO_RUPS")  %>' href="#">Objeciones</a>
                                                </asp:Panel>
                                                <div class="modal fade" id='<%# "myModalobjeciones"+Eval("COD_NOMINACION_PROCESO_RUPS")  %>' role="dialog" style="display: none;">
                                                    <div class="modal-dialog">

                                                        <!-- Modal login content-->
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">×</button>
                                                                <h4 class="modal-title"></h4>
                                                            </div>
                                                            <div class="modal-body row">
                                                                <div class="col-md-8 col-md-offset-2">
                                                                    <h3>Objeciones</h3>
                                                                    <asp:Label runat="server" ID="lblCodNominacion2" Visible="false" Text='<%# Eval("COD_NOMINACION_PROCESO_RUPS") %>'></asp:Label>
                                                                    <asp:GridView class="table" AutoGenerateColumns="False" runat="server" ID="grdObjeciones2" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="COD_OBJECION_PROCESO" HeaderText="#" />
                                                                            <asp:TemplateField HeaderText="Objetado por">
                                                                                <ItemTemplate>
                                                                                    <%# Eval("REGISTRO.NOMBRE")+" "+Eval("REGISTRO.APELLIDOS")  %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="FECHA_OBJECION" HeaderText="Fecha objeción" />
                                                                            <asp:TemplateField HeaderText="Opciones">
                                                                                <ItemTemplate>
                                                                                    <a href='<%# "../informes/frmReportViewer.aspx?cod="+Eval("COD_OBJECION_PROCESO")+"&rpt=1" %>' target="_blank" id="lnkPDF">Descargar PDF</a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EditRowStyle BackColor="#999999" />
                                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </div>

                                                        </div>

                                                    </div>

                                                </div>

                                            </td>

                                        </tr>

                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </tbody> </table> 
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>

                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="
                            SELECT 
case when NOMBRE_TIPO_JURIDICO is null 
then  dbo.verNombreTipoNatural(registro.COD_REGISTRO) else dbo.verNombreTipo( registro.COD_TIPO_JURIDICO)  end
as TipoUsuario,REGISTRO.DOCUMENTO+''+isnull('-'+DIGITO_VERIFICACION,'') NumeroIdentificacion,
ESTADO_NOMINACION_RUPS.NOMBRE_ESTADO_NOMINACION_RUPS, NOMINACION_PROCESO_RUPS.COD_NOMINACION_PROCESO_RUPS,
REGISTRO.ES_PERSONA_NATURAL, REGISTRO.ES_PERSONA_JURIDICA,
REGISTRO.NOMBRE + isnull(REGISTRO.APELLIDOS,'') 'NOMBRE', NOMINACION_PROCESO_RUPS.FECHA_REGISTRO,
 NOMINACION_PROCESO_RUPS.COD_PROCESO, CASE WHEN (CALIFICACION_AJUSTE = 'Incluir Procedimiento NUEVO') THEN DESCRIPCION_PROPUESTO ELSE ISNULL(NOMINACION_PROCESO_RUPS.NOMBRE_PROCEDIMIENTO, DESCRIPCION) END AS NOMBRE_PROCEDIMIENTO, NOMINACION_PROCESO_RUPS.COD_ESTADO_NOMINACION_RUPS, CALIFICACION_AJUSTE
FROM ESTADO_NOMINACION_RUPS 
INNER JOIN NOMINACION_PROCESO_RUPS ON ESTADO_NOMINACION_RUPS.COD_ESTADO_NOMINACION_RUPS = NOMINACION_PROCESO_RUPS.COD_ESTADO_NOMINACION_RUPS
INNER JOIN PROCESO ON NOMINACION_PROCESO_RUPS.COD_PROCESO = PROCESO.COD_PROCESO
INNER JOIN REGISTRO ON NOMINACION_PROCESO_RUPS.COD_REGISTRO = REGISTRO.COD_REGISTRO 
left join TIPO_JURIDICO on registro.cod_tipo_juridico = TIPO_JURIDICO.COD_TIPO_JURIDICO
WHERE --(NOMINACION_PROCESO_RUPS.COD_ESTADO_NOMINACION_RUPS =3) AND 
(NOMINACION_PROCESO_RUPS.cod_proceso = @proceso) 
and (vigencia = @vigencia or (@vigencia =2 and vigencia is null))
">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="proceso" QueryStringField="cod" />
                                    <asp:QueryStringParameter Name="vigencia" QueryStringField="V" />
                                </SelectParameters>

                            </asp:SqlDataSource>
                        </div>
                        <div id="tab-3" class='<%=clsTabMetodologia %>'>

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
                                <asp:SqlDataSource ID="SqlDataSourceArchivosMetodologia" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] WHERE (([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO))">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                        <asp:Parameter DefaultValue="NOMINACION" Name="SECCION" Type="String" />
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
    </div>

</asp:Content>
