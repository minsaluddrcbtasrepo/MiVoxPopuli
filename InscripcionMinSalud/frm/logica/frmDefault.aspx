<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmDefault.aspx.cs" Inherits="InscripcionMinSalud.frm.logica.frmDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBienvenido" runat="server">

    <div class="container banner">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="titularb">
                    <h2>Bienvenido a Mi Vox-pópuli</h2>
                    <p class="tagline">El portal de participación ciudadana del Ministerio de Salud y Protección Social. </p>

                    <div class="col-md-10 col-md-offset-1">
                        <iframe width="100%" height="250" src="https://www.youtube.com/embed/jfphQY3aKK4" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="calendario">
        <a href="../../frm/procesos/frmTematicasActivas.aspx">
            <img src="../../images/calendario.png"></a>
    </div>



    <section>
        <div id="sparticipa">
            <div class="proces1">
                <h2 class="sub">Temas de participación</h2>
                <p class="desc-title">
                    <a href="#">Ver todos</a>
                </p>
            </div>
            <asp:Label runat="server" ID="lblClase" Text="col-md-6" Visible="false"></asp:Label>

            <div class="container-fluid stemas">
                <div class="row">
                    <asp:Repeater runat="server" ID="grdProcesos" OnItemDataBound="grdProcesos_ItemDataBound" DataSourceID="SqlDataSourceProcesos">
                        <ItemTemplate>
                            <div class='col-md-4 stema1'>
                                <div class="tema">
                                    <div class="tema-cont">
                                        <h3>
                                            <%# "<a data-toggle='modal' data-target='#myModalfases"+Eval("COD_PROCESO") +"' href='#'>"+Eval("NOMBRE_PROCESO").ToString()+"</a>"
                                            .Replace("Actualización","<strong>Actualización</strong> ")
                                            .Replace("exclusión ","<strong>exclusión</strong> ") %>                                         
                                        </h3>
                                        <h3>
                                            <asp:HyperLink ID="hlAviso" data-toggle="modal" data-target="#modalAvisoInformativo" NavigateUrl="#" runat="server" ForeColor="Black" Visible='<%# Eval("COD_PROCESO").ToString() == "1"%>' Text="AVISO INFORMATIVO">
                                            </asp:HyperLink>

                                            <asp:HyperLink ID="hlAvisoActualizar" data-toggle="modal" data-target="#modalAvisoInformativoActualizar" NavigateUrl="#" runat="server" ForeColor="Black" Visible='<%# Eval("COD_PROCESO").ToString() == "6" %>' Text="AVISO INFORMATIVO">
                                            </asp:HyperLink>

                                            <asp:HyperLink ID="hlAvisoActualizarHuerfanas" data-toggle="modal" data-target="#modalAvisoInformativoActualizarHuerfanas" NavigateUrl="#" runat="server" ForeColor="Black" Visible='<%# Eval("COD_PROCESO").ToString() == "21" || Eval("COD_PROCESO").ToString() == "18" %>' Text="AVISO INFORMATIVO">
                                            </asp:HyperLink>
                                        </h3>

                                        <div class="call" style="display: none;">

                                            <span class='<%# (Eval("ACTIVO_PARTICIPAR") != null && Eval("ACTIVO_PARTICIPAR") != System.DBNull.Value && bool.Parse( Eval("ACTIVO_PARTICIPAR").ToString())) ?"callpart":"callparti" %>'>
                                                <%# (Eval("ACTIVO_PARTICIPAR") != null && Eval("ACTIVO_PARTICIPAR") != System.DBNull.Value && bool.Parse( Eval("ACTIVO_PARTICIPAR").ToString())) ?("<a href='"+Eval("URL_ACTIVO_PARTICIPAR").ToString()+"'>Participar</a>"):"<a>Participar</a>" %>
                                            </span>
                                            <span class='<%# (Eval("ACTIVO_RESULTADOS") != null && Eval("ACTIVO_RESULTADOS") != System.DBNull.Value && bool.Parse( Eval("ACTIVO_RESULTADOS").ToString())) ?"callres":"callparti" %>'>
                                                <%# (Eval("ACTIVO_RESULTADOS") != null && Eval("ACTIVO_RESULTADOS") != System.DBNull.Value && bool.Parse( Eval("ACTIVO_RESULTADOS").ToString())) 
                                                ?("<a data-toggle='modal' data-target='#myModalfases"+Eval("COD_PROCESO") +"' href='#'>Resultados</a>")
                                                :"<a>Resultados</a>" %>
                                            </span>

                                            <span style='<%# ((Eval("COD_PROCESO").ToString() != "10")?"display:none": "") %>;' class='callpart'>
                                                <a href='../procesos/frmLineatiempo.aspx?cod=1&V=3'>¿Cómo vamos?</a>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="modal fade" id='<%# "myModalfases"+Eval("COD_PROCESO")  %>' role="dialog" style="display: none;">
                                <div class="modal-dialog">
                                    <!-- Modal login content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">×</button>
                                            <h4 class="modal-title"></h4>
                                        </div>
                                        <div class="modal-body row">
                                            <div class="col-md-8 col-md-offset-2">
                                                <h3>Escoja la vigencia de su interés</h3>
                                                <p class="mdescription">
                                                </p>
                                                <asp:Label runat="server" ID="lblVigencias" Visible="false" Text='<%# Eval("VIGENCIAS") %>'></asp:Label>
                                                <asp:Label runat="server" ID="lblCodProceso" Visible="false" Text='<%# Eval("COD_PROCESO") %>'></asp:Label>
                                                <asp:CheckBox runat="server" ID="chkESRups" Visible="false" Checked='<%# Eval("ES_RUPS") %>'></asp:CheckBox>
                                                <asp:CheckBox runat="server" ID="chkEsUPC" Visible="false" Checked='<%# Eval("ES_UPC") %>'></asp:CheckBox>
                                                <asp:CheckBox runat="server" ID="chkEsHuerfana" Visible="false" Checked='<%# Eval("ES_HUERFANA") %>'></asp:CheckBox>
                                                <asp:CheckBox runat="server" ID="chkEsAAA" Visible="false" Checked='<%# Eval("ES_AAA") %>'></asp:CheckBox>

                                                <asp:Repeater runat="server" ID="rptVigencias">
                                                    <HeaderTemplate>
                                                        <ul class="vigencias">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <li>
                                                            <asp:HyperLink runat="server" NavigateUrl='<%# Eval("url") %>' Text='<%# Eval("vigencia") %>' Font-Bold="true" style="font-size: 24px;"></asp:HyperLink>
                                                        </li>
                                                    </ItemTemplate>

                                                    <FooterTemplate>
                                                        </ul>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div></div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlOnline" Visible="false"></asp:Panel>
        <asp:SqlDataSource ID="SqlDataSourceProcesos" runat="server" ConnectionString="<%$ConnectionStrings:TRANSPLANTESConnectionString %>"
            SelectCommand="SELECT VIGENCIAS,URL_ACTIVO_PARTICIPAR, ROW_NUMBER( ) OVER (ORDER BY COD_PROCESO DESC) FILA, TOTAL, CASE WHEN ROW_NUMBER() OVER (ORDER BY FECHA_FIN_NOMINACION)= TOTAL THEN  CASE WHEN TOTAL %2 = 1 THEN 'col-md-3' END ELSE 'col-md-3' END CLASE, cast (case when GETDATE() < fecha_fin_nominacion then ACTIVO_PARTICIPAR else 0 end as bit)  ACTIVO_PARTICIPAR, ACTIVO_RESULTADOS,ES_RUPS,ES_UPC,ES_HUERFANA,ES_AAA, datediff(day,getdate(),dateadd(day,1,FECHA_FIN_NOMINACION)) DIAS, [COD_PROCESO], [NOMBRE_PROCESO], TEXTO_DIRIGIDO_A,OBSERVACIONES_PROCESO, cast ([FECHA_INICIO_NOMINACION] as char(12)) FECHA_INICIO_NOMINACION2, cast( [FECHA_FIN_NOMINACION] as char(12)) FECHA_FIN_NOMINACION2,FECHA_INICIO_NOMINACION, FECHA_FIN_NOMINACION, FORMAT(FECHA_INICIO_PRIMERA_VIGENCIA,' dd/MM/yyyy ' ) FECHA_INICIO_PRIMERA_VIGENCIA,FORMAT(FECHA_FIN_PRIMERA_VIGENCIA,' dd/MM/yyyy ' ) FECHA_FIN_PRIMERA_VIGENCIA, FORMAT(FECHA_INICIO_SEGUNDA_VIGENCIA,' dd/MM/yyyy ' ) FECHA_INICIO_SEGUNDA_VIGENCIA, FORMAT(FECHA_FIN_SEGUNDA_VIGENCIA,' dd/MM/yyyy ' ) FECHA_FIN_SEGUNDA_VIGENCIA FROM [PROCESO] JOIN (SELECT COUNT(*) TOTAL FROM PROCESO WHERE ACTIVO = 1) ST ON ST.TOTAL > 0  where ACTIVO = 1 order by COD_PROCESO asc"></asp:SqlDataSource>
    </section>

    <div class="modal fade" id='modalAvisoInformativo' role="dialog" style="display: none;">
        <div class="modal-dialog">
            <!-- Modal login content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">x</button>
                    <h4 class="modal-title">AVISO INFORMATIVO</h4>
                </div>
                <div class="modal-body row">
                    <p>Se informa a la ciudadania en general que, desde el 1 de marzo hasta 30 de abril de 2024, podrán nominar las tecnologías o servicios Que NO deben ser financiados con recursos públicos asignados a la salud. Estas nominaciones se pueden realizar fácilmente a través de esta herramienta.</p>
                    <p>Nota: recuerde que la nominación no es una exclusión, es una tecnología en estudio. La exclusión se declara con la expedición de un acto administrativo. Actualmente las tecnologías excluidas corresponden a los criterios de exclusión del artículo 15 de la Ley Estatutaria de Salud (1751 de 2015) y a las contenidas en la Resolución 2273 de 2021.</p>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id='modalAvisoInformativoActualizar' role="dialog" style="display: none;">
        <div class="modal-dialog">
            <!-- Modal login content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">x</button>
                    <h4 class="modal-title">AVISO INFORMATIVO</h4>
                </div>
                <div class="modal-body row">
                    <p>Se informa a los diferentes actores del Sistema de Salud que, desde el 1 de enero de 2024 y hasta el 31 de marzo de 2024, se encuentra habilitada la plataforma para presentar nominaciones para la actualización de la Clasificación Única de Procedimientos en Salud - CUPS, de acuerdo con lo establecido en el artículo 8o de la Resolución 3804 de 2016.</p>
                </div>
            </div>
        </div>
    </div>

     <div class="modal fade" id='modalAvisoInformativoActualizarHuerfanas' role="dialog" style="display: none;">
        <div class="modal-dialog">
            <!-- Modal login content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">x</button>
                    <h4 class="modal-title">AVISO INFORMATIVO</h4>
                </div>
                <div class="modal-body row">
                    <img src="/img/LOGO EHR HORIZONTAL.PNG" />
                    <p>Acorde a la Ley 1392 del 2010 parágrafo del artículo 2, el Ministerio de Salud y Protección Social con el propósito de mantener unificada la lista de denominación de las enfermedades huérfanas, realiza el proceso periódico de actualización del listado oficial de enfermedades huérfanas/raras EHR.  Para el presente 2024 mediante la plataforma “Mi Vox Populi” se realiza las nominaciones de EHR.</p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
