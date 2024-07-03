<%@ Page Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmHomeProcesoNominacionHuerfanas.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmHomeProcesoNominacionHuerfanas" %>

<%@ Register Src="~/frm/controles/controlLogin.ascx" TagPrefix="uc1" TagName="controlLogin" %>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderBienvenido" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function Click1() {
            var kli = document.getElementById("tab-3").getElementsByTagName("li");
            if (kli.length == 0) {
                var lim = document.getElementById("liMetodologia");
                lim.style.display = 'none';
            }
            var kli = document.getElementById("tab-4").getElementsByTagName("li");
            if (kli.length == 0) {
                var lim = document.getElementById("liTecnologias");
                lim.style.display = 'none';
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
            <div class="col-md-12">
                <div class="titular">
                    <h2 class="sub">
                        <asp:Label runat="server" ID="lblNombreProceso"></asp:Label></h2>
                    <p class="desc-title" runat="server" id="lblDescProceso" visible="false"></p>
                    <p class="desc-title" runat="server" id="lblDescHuerfanas" visible="false">Al presente, la Resolución 023 del 4 de enero de 2023 “Por medio de la cual se actualiza el listado de enfermedades huérfanas – raras” se encuentra en vigencia y es sobre la cual se recibirán las nominaciones en este nuevo proceso de actualización del listado. </p>
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
                            <li class="active"><a href="#">Nominación</a></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkAnalisis" NavigateUrl="../../frm/procesos/frmHomeProcesoAnalisisHuerfanas.aspx">Análisis técnico - científico</asp:HyperLink></li>

                            <li>
                                <asp:HyperLink runat="server" ID="lnkAdopcion" NavigateUrl="../../frm/procesos/frmHomeAdopcionHuerfanas.aspx">Publicación de decisiones</asp:HyperLink></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-10 amp-proces">
                    <img src="/img/LOGO EHR HORIZONTAL.PNG" />
                    <p style="text-align: justify;">
                        El proceso de inclusión y actualización del listado oficial de enfermedades huérfanas/raras, consta de tres fases: proceso de nominaciones, análisis técnico científico y decisión mediante un panel de expertos; dicho proceso culmina con la expedición de un acto administrativo (Resolución). 
                    </p>
                    <h3>Primera fase.</h3>

                    <p style="text-align: justify;">
                        Durante la primera fase se podrá nominar:
                    </p>
                
                    <br />

                    <ul style="text-align: justify;">
                        <li>Inclusión de un nuevo diagnóstico/enfermedad en el listado.</li>
                        <li>Exclusión de un diagnóstico/enfermedad en el listado.</li>
                        <li>Modificación del nombre de un diagnóstico/enfermedad del listado.</li>
                        <li>Modificación de un código del listado actual. Hace referencia a los códigos de la Clasificación Estadística CIE-10 - OMIM</li>
                        <li>Modificación de la Prueba Diagnóstica Confirmatoria de un diagnóstico/enfermedad del listado actual.</li>
                        <li>Modificación en las disciplinas o especialidades que intervienen en el diagnóstico.</li>
                    </ul>

                    <p runat="server" id="lblDescProcesoNomi" visible="false">
                        En esta fase cualquier ciudadano puede participar nominando servicios y tecnologías para ser excluidas de la financiación con recursos públicos destinados a la salud. 
                    </p>
                    <br />
                    <p runat="server" id="lblDescHuerfanasNomi" visible="true" style="text-align: justify;font-weight: bold;">
                        Es importante aclarar, que el recibir una nominación a través de esta plataforma no implica una aceptación automática sino solo el inicio del proceso. 
                    </p>
                     <h3>Segunda fase.</h3>

                    <p style="text-align: justify;">
                        Durante la segunda fase se surte el Análisis Técnico Científico, las nominaciones al listado vigente pasan a un proceso de revisión mediante un panel de expertos clínicos conformado por especialistas y subespecialistas, para su análisis y discusión.
                    </p>

                    <h3>Tercera fase.</h3>

                    <p style="text-align: justify;">
                        Durante la tercera fase se lleva a cabo la Decisión concluyente de las nominaciones presentadas; en continuidad del trámite el Ministerio de Salud y Protección Social publicará en acto administrativo las inclusiones, exclusiones y modificaciones establecidas para la siguiente vigencia. .
                    </p>
                    <hr>
                    <div class="uitabs">
                        <ul class="tabs" style="width:100%">
                            <li class='<%= clsParticipe %>' data-tab="tab-0" style="width:33.33%"><img src="/img/web/clic31.png" style="width:20%; background-color: #013144;"  /> Yo Participo</li>
                            <li class='<%= clsResultados %>' data-tab="tab-2" style="width:33.33%">Nominaciones Aceptadas</li>
                            <li id="liMetodologia" class="tab-link" data-tab="tab-3">Instructivo</li>
                            <li id="liTecnologias" class="tab-link" data-tab="tab-4">Tecnologías a evaluar</li>
                        </ul>

                        <div id="tab-0" class='<%= clsTabParticipe %>'>

                            <asp:Panel runat="server" ID="pnlRegistrese">
                                <uc1:controlLogin runat="server" ID="controlLogin" />

                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlNoRegistrese">
                                <asp:Panel runat="server" ID="pnlNoVigenciaNominacion">
                                    <h3>El proceso de participación de la fase de “NOMINACIÓN Y PRIORIZACIÓN” ha finalizado para esta vigencia</h3>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlVigenciaNominacion">

                                    <iframe runat="server" id="iframeNominar" style="width: 90%; min-height: 1500px; border-width: 0px;"></iframe>
                                </asp:Panel>
                            </asp:Panel>
                        </div>


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
                            <asp:SqlDataSource ID="SqlDataSourceArchivosResultados" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>"
                                SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] WHERE (([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO))">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                    <asp:Parameter DefaultValue="NOMINACION" Name="SECCION" Type="String" />
                                    <asp:Parameter DefaultValue="RESULTADOS" Name="SUBSECCION" Type="String" />
                                    <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>


                            <h3>Listado Registro de Nominaciones Enfermedades Huérfanas/Raras – 2024</h3>
                            <div class="panel panel-default">
                                <asp:Repeater runat="server" ID="rptResultados" DataSourceID="SqlDataSource1" OnItemDataBound="rptResultados_ItemDataBound">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Nominación</th>
                                                    <th>Fecha</th>
                                                    <th>Estado</th>
                                                    <th>Opciones</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <%--Exclusiones--%>
                                    <ItemTemplate>
                                        <div runat="server" id="resultadosExclusiones">
                                            <tr>
                                                <th scope="row"><%# Eval("COD_NOMINACION_HUERFANAS") %></th>
                                                <td><%# Eval("NOMBRE_TECNOLOGIA") %></td>
                                                <td><%# Eval("FECHA_NOMINACION") %></td>
                                                <td><%# Eval("NOMBRE_ESTADO_NOMINACION") %></td>
                                                <td>
                                                    <a href='<%# "../informes/frmReportViewerHuerfanas.aspx?cod="+Eval("COD_NOMINACION_HUERFANAS") + "&rpt=" +Eval("TIPO_REPORTE") %> ' target="_blank" id="lnkPDF">Descargar PDF</a>


                                                    <asp:Button runat="server"
                                                        CommandArgument='<%# Eval("COD_NOMINACION_HUERFANAS") %>' Text="Objetar" ID="btnObjetarHuerfanas" OnClick="btnObjetar_Click2" Visible='<%# CalcularVisibleObjecion(Eval("COD_ESTADO_NOMINACION"))%>' />

                                                    <asp:Panel runat="server" ID="pnlObjecionesHuerfanas" Visible="true">
                                                        <a data-toggle="modal" data-target='<%# "#myModalobjeciones"+Eval("COD_NOMINACION_HUERFANAS")  %>' href="#">Objeciones a esta nominación</a>
                                                    </asp:Panel>
                                                    <div class="modal fade" id='<%# "myModalobjeciones"+Eval("COD_NOMINACION_HUERFANAS")  %>' role="dialog" style="display: none;">
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
                                                                        <asp:Label runat="server" ID="lblCodNominacion2" Visible="false" Text='<%# Eval("COD_NOMINACION_HUERFANAS") %>'></asp:Label>

                                                                        <asp:GridView class="table" AutoGenerateColumns="False" runat="server" ID="grdObjeciones2" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="COD_OBJECION_HUERFANA" HeaderText="#" />
                                                                                <%--  <asp:TemplateField HeaderText="Objetado por">
                                                                                <ItemTemplate>

                                                                                    <%-- Cambiar para huerfanas en huerfanas no existe REGISTRO --%>                                                                                                                                                                <%--<%# Eval("REGISTRO.NOMBRE").ToString().ToUpper()+" "+((Eval("REGISTRO.APELLIDOS") == null)?"":Eval("REGISTRO.APELLIDOS").ToString().ToUpper())  %>--%>
                                                                                <%--</ItemTemplate>
                                                                            </asp:TemplateField>--%>
                                                                                <asp:BoundField DataField="FECHA_OBJECION" HeaderText="Fecha Objeción" />
                                                                                <asp:TemplateField HeaderText="Opciones">

                                                                                    <ItemTemplate>
                                                                                        <a href='<%# "../informes/frmReportViewerHuerfanas.aspx?cod="+Eval("COD_OBJECION_HUERFANA")+"&rpt=2" %>' target="_blank" id="lnkPDF">Descargar PDF</a>
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
                                        </div>


                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody> </table> 
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>






                            <asp:DataList Visible="false" runat="server" ID="datos" DataKeyField="COD_NOMINACION_HUERFANAS" DataSourceID="SqlDataSource1" OnItemDataBound="datos_ItemDataBound">
                                <ItemTemplate>
                                    <fieldset runat="server" id="Fieldset1" class="form-group" style="margin: 10px !important;">
                                        <legend><span><%# Eval("NOMBRE_PROCESO") %></span> </legend>

                                        <div class="row" style="margin-top: -40px; margin-bottom: 10px !important;">
                                            <div class="pull-left">


                                                <label for="txtNumeroDocumentoNatural" clientidmode="Static" runat="server" id="lbl2">
                                                    <span>Nombre de la Tecnologia:</span></label>
                                                <%# Eval("COD_NOMINACION_HUERFANAS") %>-<%# Eval("NOMBRE_TECNOLOGIA") %><br />
                                                <label for="txtNumeroDocumentoNatural" clientidmode="Static" runat="server" id="Label1"><span>Estado:</span></label><%# Eval("NOMBRE_ESTADO_NOMINACION") %><br />
                                                <label for="txtNumeroDocumentoNatural" clientidmode="Static" runat="server" id="Label4"><span>Fecha nominación:</span></label><%# Eval("FECHA_NOMINACION") %>
                                            </div>
                                            <div class="pull-right">
                                                <br />
                                                <br />

                                                <a href='<%# "frmInscripcionHuerfanas.aspx?codN="+Eval("COD_NOMINACION_HUERFANAS")+"&codProceso="+Eval("COD_PROCESO") %>' id="lnkVerMas">Ver más</a>

                                                <a href='<%# "../informes/frmReportViewerHuerfanas.aspx?cod="+Eval("COD_NOMINACION_HUERFANAS") + "&rpt=" +Eval("TIPO_REPORTE")  %>' target="_blank" id="lnkPDF">Descargar PDF</a>

                                            </div>
                                        </div>

                                        <div class="row">
                                            Objeciones
                                        <asp:Label runat="server" ID="lblCodNominacion" Visible="false" Text='<%# Eval("COD_NOMINACION_HUERFANAS") %>'></asp:Label>
                                            <asp:Repeater runat="server" ID="grdObjeciones">
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="lnkObjecion"
                                                        NavigateUrl='<%# "frmObjetarHuerfanas.aspx?codN="+Eval("COD_NOMINACION_HUERFANAS")+"&codobjecion="+Eval("COD_NOMINACION_HUERFANAS") %>'
                                                        Text='<%# Eval("REGISTRO.NOMBRE").ToString()
                                                        +" "+ Eval("REGISTRO.APELLIDOS") + " documento: "+Eval("REGISTRO.DOCUMENTO").ToString()
                                                        + " Fecha objeción:"+ Eval("FECHA_OBJECION")+"<br>" %>'>
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>

                                    </fieldset>
                                </ItemTemplate>

                            </asp:DataList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="
                                SELECT FECHA_FIN_OBJECION,
                                RTRIM(ID_MANUAL) ID_MANUAL,
                                case when NOMBRE_TIPO_JURIDICO is null 
                                then  dbo.verNombreTipoNatural(registro.COD_REGISTRO) else dbo.verNombreTipo( registro.COD_TIPO_JURIDICO)  end
                                as TipoUsuario,REGISTRO.DOCUMENTO+''+isnull('-'+DIGITO_VERIFICACION,'') NumeroIdentificacion,           
                                ESTADO_NOMINACION.NOMBRE_ESTADO_NOMINACION, 
								NOMINACION_HUERFANA.COD_NOMINACION_HUERFANAS, 
								PROCESO.NOMBRE_PROCESO,
                                NOMINACION_HUERFANA.NOMBRE AS NOMBRE_TECNOLOGIA,
								
								NOMINACION_HUERFANA.COD_PROCESO, 
								NOMINACION_HUERFANA.ADJUNTA_EVIDENCIA, 
                                NOMINACION_HUERFANA.CONFLICTO_INTERES, NOMINACION_HUERFANA.FECHA_NOMINACION, REGISTRO.ES_PERSONA_NATURAL, REGISTRO.ES_PERSONA_JURIDICA,
                                 REGISTRO.NOMBRE + isnull(REGISTRO.APELLIDOS,'') 'NOMBRE', VIGENCIA.ABIERTO,
                                E.NOMBRE_ESTADO_NOMINACION, NOMINACION_HUERFANA.COD_ESTADO_NOMINACION,                                
								CASE 
								WHEN (ES_INCLUIR = 1) THEN 1
								WHEN (ES_EXCLUIR = 1) THEN 2
								WHEN (ES_CAMBIO = 1) THEN 3
								WHEN (ES_CODIGO = 1) THEN 4
								WHEN (ES_PRUEBA = 1) THEN 5
								WHEN (ES_DICIPLINA = 1) THEN 6
								ELSE 1 END AS TIPO_REPORTE
                                  FROM ESTADO_NOMINACION 
                                INNER JOIN NOMINACION_HUERFANA ON ESTADO_NOMINACION.COD_ESTADO_NOMINACION = NOMINACION_HUERFANA.COD_ESTADO_NOMINACION
                                 INNER JOIN PROCESO ON NOMINACION_HUERFANA.COD_PROCESO = PROCESO.COD_PROCESO
                                INNER JOIN REGISTRO ON NOMINACION_HUERFANA.COD_REGISTRO = REGISTRO.COD_REGISTRO 
                                left join TIPO_JURIDICO on registro.cod_tipo_juridico = TIPO_JURIDICO.COD_TIPO_JURIDICO
                                INNER JOIN VIGENCIA ON VIGENCIA.COD_PROCESO = PROCESO.COD_PROCESO 
                                INNER JOIN ESTADO_NOMINACION E ON E.COD_ESTADO_NOMINACION = NOMINACION_HUERFANA.COD_ESTADO_NOMINACION
                                WHERE (NOMINACION_HUERFANA.cod_proceso = @proceso) and VIGENCIA = @VIGENCIA 
                                AND VIGENCIA.COD_VIGENCIA = @VIGENCIA ORDER BY FECHA_NOMINACION, CAST(COD_NOMINACION_HUERFANAS AS INT)">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="proceso" QueryStringField="cod" />
                                    <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" />
                                </SelectParameters>

                            </asp:SqlDataSource>
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
                                    <asp:Parameter DefaultValue="NOMINACION" Name="SECCION" Type="String" />
                                    <asp:Parameter DefaultValue="METODOLOGIA" Name="SUBSECCION" Type="String" />
                                    <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>

                        </div>
                        <div id="tab-4" class="tab-content ">
                            <asp:Repeater runat="server" ID="Repeater1" DataSourceID="SqlDataSourceTecnologiasEvaluar">
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
                            <asp:SqlDataSource ID="SqlDataSourceTecnologiasEvaluar" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] WHERE (([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO))">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                    <asp:Parameter DefaultValue="NOMINACION" Name="SECCION" Type="String" />
                                    <asp:Parameter DefaultValue="TECNOLOGIA" Name="SUBSECCION" Type="String" />
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

