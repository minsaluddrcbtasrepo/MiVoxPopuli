<%@ Page Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="RevisionExclusionesNoAplicacion.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.RevisionExclusionesNoAplicacion" %>

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
                            <li><a href="#">Nominación y priorización</a></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkAnalisis" NavigateUrl="../../frm/procesos/frmHomeProcesoAnalisis.aspx">Análisis técnico - científico</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkConsultas" NavigateUrl="../../frm/procesos/frmHomeProcesoConsultas.aspx">Consulta pacientes</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink runat="server" ID="lnkAdopcion" NavigateUrl="../../frm/procesos/frmHomeAdopcion.aspx">Adopción y publicación</asp:HyperLink></li>
                            <li class="active">
                                <asp:HyperLink runat="server" ID="lnkRevision" NavigateUrl="../../frm/procesos/RevisionExclusionesNoAplicacion.aspx">Revisión de la decisión de una tecnología previamente excluida</asp:HyperLink></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-10 amp-proces">
                    <h3>Nominación para revisión de criteros excluyentes</h3>
                    <p>
                        En esta fase cualquier ciudadano puede participar nominando para revisión de criterios excluyentes a los  servicios y tecnologías que fueron excluidas de la financiación con recursos públicos destinados a la salud. 
                    </p>
                    <hr>
                    <div class="uitabs">
                        <ul class="tabs">
                            <li class='<%= clsResultados %>' data-tab="tab-2">Tecnologías excluidas</li>
                        </ul>
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
                            <asp:SqlDataSource ID="SqlDataSourceArchivosResultados" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [URL], [TEXTO] FROM [ARCHIVOXPROCESO] WHERE (([VIGENCIA] = @VIGENCIA) AND ([SECCION] = @SECCION) AND ([SUBSECCION] = @SUBSECCION) AND ([COD_PROCESO] = @COD_PROCESO))">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" Type="Int32" />
                                    <asp:Parameter DefaultValue="NOMINACION" Name="SECCION" Type="String" />
                                    <asp:Parameter DefaultValue="RESULTADOS" Name="SUBSECCION" Type="String" />
                                    <asp:QueryStringParameter Name="COD_PROCESO" QueryStringField="cod" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>


                            <h3>Tecnologías nominadas que pueden ser revisadas por no aplicación de criterio(s) excluyente(s)</h3>

                        
                      <div class="row">
                            <span class="callres">
                                <a data-toggle="modal" href="#">Exclusiones vigentes resolución 2273 de 2021</a>
                             </span>
                          </div>
                      <br />
                            <div class="panel panel-default">
                                <asp:Repeater runat="server" ID="rptResultados" DataSourceID="SqlDataSource1" OnItemDataBound="rptResultados_ItemDataBound">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Tecnología Excluida</th>
                                                    <th>Fecha nominación</th>
                                                    <th>Opciones</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Eval("ID_MANUAL") %></th>
                                            <td><%# Eval("NOMBRE_TECNOLOGIA") %></td>
                                            <td><%# Eval("FECHA_NOMINACION") %></td>
                                            <td>
                                                <%--<a href='<%# "../informes/frmReportViewer.aspx?cod="+Eval("COD_NOMINACION_PROCESO") %>' target="_blank" id="lnkPDF">Ver PDF de la nominación</a>--%>

                                                 <asp:Button runat="server" Visible="true"
                                                    CommandArgument='<%# Eval("COD_NOMINACION_PROCESO") %>' Text="Postular para revisión" ID="btnRevision" OnClick="btnRevision_Click"  />

                                                <%--  para ver las objeciones que tuvo esta nominacion           --%>                                   
    
                                                <asp:Panel runat="server" ID="pnlObjeciones" Visible="true">
                                                        <%--<a data-toggle="modal" data-target='<%# "#myModalobjeciones"+Eval("COD_NOMINACION_PROCESO")  %>' href="#">Objeciones a esta nominación</a>--%>
                                                </asp:Panel>
                                                <div class="modal fade" id='<%# "myModalobjeciones"+Eval("COD_NOMINACION_PROCESO")  %>' role="dialog" style="display: none;">
                                                    <div class="modal-dialog">

                                                        <!-- Modal login content-->
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">×</button>
                                                                <h4 class="modal-title"></h4>
                                                            </div>
                                                            <div class="modal-body row">
                                                                <div class="col-md-8 col-md-offset-2" visible="false">
                                                                    <h3>Objeciones</h3>
                                                                    <asp:Label runat="server" ID="lblCodNominacion2" Visible="false" Text='<%# Eval("COD_NOMINACION_PROCESO") %>'></asp:Label>
                                                                    <asp:GridView class="table" AutoGenerateColumns="False" runat="server" ID="grdObjeciones2" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="COD_OBJECION_PROCESO" HeaderText="#" />
                                                                            <asp:TemplateField HeaderText="Objetado por">
                                                                                <ItemTemplate>
                                                                                    <%# Eval("REGISTRO.NOMBRE").ToString().ToUpper()+" "+((Eval("REGISTRO.APELLIDOS") == null)?"":Eval("REGISTRO.APELLIDOS").ToString().ToUpper())  %>
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

                            <asp:DataList Visible="false" runat="server" ID="datos" DataKeyField="COD_NOMINACION_PROCESO" DataSourceID="SqlDataSource1" OnItemDataBound="datos_ItemDataBound">
                                <ItemTemplate>
                                    <fieldset runat="server" id="Fieldset1" class="form-group" style="margin: 10px !important;">
                                        <legend><span><%# Eval("NOMBRE_PROCESO") %></span> </legend>

                                        <div class="row" style="margin-top: -40px; margin-bottom: 10px !important;">
                                            <div class="pull-left">

                                                <label for="txtNumeroDocumentoNatural" clientidmode="Static" runat="server" id="lbl2">
                                                    <span>Nombre de la Tecnologia:</span></label>
                                                <%# Eval("ID_MANUAL") %>-<%# Eval("NOMBRE_TECNOLOGIA") %><br />
                                                <label for="txtNumeroDocumentoNatural" clientidmode="Static" runat="server" id="Label1"><span>Estado:</span></label><%# Eval("NOMBRE_ESTADO_NOMINACION") %><br />
                                                <label for="txtNumeroDocumentoNatural" clientidmode="Static" runat="server" id="Label4"><span>Fecha nominación:</span></label><%# Eval("FECHA_NOMINACION") %>
                                            </div>
                                            <div class="pull-right">
                                                <br />
                                                <br />
                                                <a visible=""href='<%# "frmInscripcionProceso.aspx?codN="+Eval("COD_NOMINACION_PROCESO")+"&codProceso="+Eval("COD_PROCESO") %>' id="lnkVerMas">Ver más</a>

                                                <a href='<%# "../informes/frmReportViewer.aspx?cod="+Eval("COD_NOMINACION_PROCESO") %>' target="_blank" id="lnkPDF">Descargar PDF</a>

                                            </div>
                                        </div>

                                        <div class="row" visible="false">
                                            Objeciones presentadas a esta nominación
                                        <asp:Label runat="server" ID="lblCodNominacion" Visible="false" Text='<%# Eval("COD_NOMINACION_PROCESO") %>'></asp:Label>
                                            <asp:Repeater runat="server" ID="grdObjeciones">
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="lnkObjecion"
                                                        NavigateUrl='<%# "frmObjetar.aspx?codN="+Eval("COD_NOMINACION_PROCESO")+"&codobjecion="+Eval("COD_OBJECION_PROCESO") %>'
                                                        Text='<%# Eval("REGISTRO.NOMBRE").ToString()
                                                        +" "+ Eval("REGISTRO.APELLIDOS") + " documento: "+Eval("REGISTRO.DOCUMENTO").ToString()
                                                        + " Fecha objeción:"+ Eval("FECHA_OBJECION")+"<br>" %>'></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>

                                    </fieldset>
                                </ItemTemplate>

                            </asp:DataList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="
                                    SELECT distinct
                                    NOMINACION_PROCESO.COD_NOMINACION_PROCESO,
                                    FECHA_FIN_OBJECION,
                                    RTRIM(ID_MANUAL) ID_MANUAL,
                                    case when NOMBRE_TIPO_JURIDICO is null 
                                    then  dbo.verNombreTipoNatural(registro.COD_REGISTRO) else dbo.verNombreTipo( registro.COD_TIPO_JURIDICO)  end
                                    as TipoUsuario,REGISTRO.DOCUMENTO+''+isnull('-'+DIGITO_VERIFICACION,'') NumeroIdentificacion,    
                                    ESTADO_NOMINACION.NOMBRE_ESTADO_NOMINACION, NOMINACION_PROCESO.COD_NOMINACION_PROCESO, PROCESO.NOMBRE_PROCESO, NOMINACION_PROCESO.ES_MEDICAMENTO, NOMINACION_PROCESO.ES_PROCEDIMIENTO, NOMINACION_PROCESO.ES_DISPOSITIVO_MEDICO, NOMINACION_PROCESO.ES_OTRO, NOMINACION_PROCESO.COD_PROCESO, NOMINACION_PROCESO.NOMBRE_TECNOLOGIA, NOMINACION_PROCESO.CIE10, NOMINACION_PROCESO.CIE10_2, NOMINACION_PROCESO.CIE10_INDICACION, NOMINACION_PROCESO.MEDICAMENTOS, NOMINACION_PROCESO.PROCEDIMIENTO, NOMINACION_PROCESO.DISPOSITIVO, NOMINACION_PROCESO.DESCRIPCION_OTRO, NOMINACION_PROCESO.CRITERIO_A, NOMINACION_PROCESO.CRITERIO_B, NOMINACION_PROCESO.CRITERIO_C, 
                                    NOMINACION_PROCESO.CRITERIO_D, NOMINACION_PROCESO.CRITERIO_E, NOMINACION_PROCESO.CRITERIO_F, NOMINACION_PROCESO.ADJUNTA_EVIDENCIA, 
                                    NOMINACION_PROCESO.CONFLICTO_INTERES, NOMINACION_PROCESO.FECHA_NOMINACION, REGISTRO.ES_PERSONA_NATURAL, REGISTRO.ES_PERSONA_JURIDICA,
                                    REGISTRO.NOMBRE + isnull(REGISTRO.APELLIDOS,'') 'NOMBRE'
                                    FROM ESTADO_NOMINACION 
                                    INNER JOIN NOMINACION_PROCESO ON ESTADO_NOMINACION.COD_ESTADO_NOMINACION = NOMINACION_PROCESO.COD_ESTADO_NOMINACION
                                    INNER JOIN PROCESO ON NOMINACION_PROCESO.COD_PROCESO = PROCESO.COD_PROCESO
                                    INNER JOIN REGISTRO ON NOMINACION_PROCESO.COD_REGISTRO = REGISTRO.COD_REGISTRO 
                                    left join TIPO_JURIDICO on registro.cod_tipo_juridico = TIPO_JURIDICO.COD_TIPO_JURIDICO
                                    INNER JOIN VIGENCIA ON VIGENCIA.COD_PROCESO = PROCESO.COD_PROCESO 
                                    WHERE (NOMINACION_PROCESO.COD_ESTADO_NOMINACION =3)
                                    AND NOMINACION_PROCESO.CRITERIO_A !=1
                                    AND (YEAR(GETDATE())-(NOMINACION_PROCESO.ANNO_RES_EXCLUSION))>=5
                                    ORDER BY NOMINACION_PROCESO.COD_NOMINACION_PROCESO">

                                <SelectParameters>
                                    <asp:QueryStringParameter Name="proceso" QueryStringField="cod" />
                                    <asp:QueryStringParameter Name="VIGENCIA" QueryStringField="v" />
                                </SelectParameters>

                            </asp:SqlDataSource>
                        </div>

                   
                </div>

            </div>
        </div>
    </div>

</asp:Content>

