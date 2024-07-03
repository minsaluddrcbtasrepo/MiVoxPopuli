<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/masterb.Master" AutoEventWireup="true" CodeBehind="frmInscripcionProceso.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmInscripcionProceso" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .ui-autocomplete {
            position: absolute;
            cursor: default;
            background-color: whitesmoke;
        }


        html .ui-autocomplete {
            width: 1px;
        }

        .ui-menu {
            list-style: none;
            padding: 2px;
            margin: 0;
            display: block;
            float: left;
        }

            .ui-menu .ui-menu {
                margin-top: -3px;
            }

            .ui-menu .ui-menu-item {
                margin: 0;
                padding: 0;
                zoom: 1;
                float: left;
                clear: left;
                width: 100%;
            }

                .ui-menu .ui-menu-item a {
                    text-decoration: none;
                    display: block;
                    padding: .2em .4em;
                    line-height: 1.5;
                    zoom: 1;
                }

                    .ui-menu .ui-menu-item a.ui-state-hover,
                    .ui-menu .ui-menu-item a.ui-state-active {
                        font-weight: normal;
                        margin: -1px;
                    }
    </style>
    <style>
        a#lnkPDF {
            background: #30798d;
            background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
            background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
            background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
            border-radius: 5px;
            color: #fff;
            font-size: 1.9rem;
            padding: 15px 30px;
            border: none;
            font-weight: bold;
            width: 250px;
            margin: 40px auto;
            text-align: center;
        }

        input#btnObjetar {
            background: #30798d;
            background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
            background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
            background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
            border-radius: 5px;
            color: #fff;
            font-size: 1.9rem;
            padding: 15px 30px;
            border: none;
            font-weight: bold;
            width: 250px;
            margin: 40px auto;
            text-align: center;
        }

        input#btnGuardarContinuar {
            background: #30798d;
            background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
            background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
            background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
            border-radius: 5px;
            color: #fff;
            font-size: 1.9rem;
            padding: 15px 30px;
            border: none;
            font-weight: bold;
            width: 250px;
            margin: 40px auto;
            text-align: center;
        }

        input#btnGuardar {
            background: #30798d;
            background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
            background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
            background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
            border-radius: 5px;
            color: #fff;
            font-size: 1.9rem;
            padding: 15px 30px;
            border: none;
            font-weight: bold;
            width: 250px;
            margin: 40px auto;
            text-align: center;
        }

        .checkper {
            margin-right: 7px !important;
        }

            .checkper input {
                margin-right: 7px !important;
            }
        /*form registro*/
        input#chkAutorizo {
            position: relative !important;
        }

        input#chkTerminosYCondiciones {
            position: relative !important;
        }

        input#chkCertifico {
            position: relative !important;
        }

        .form-control {
            display: block;
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #bde7ef !important;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

        h2.tag {
            font-size: 3rem;
            font-weight: bold;
            color: #17a9c7 !important;
            text-align: center;
            width: 500px;
            margin: 40px auto 20px auto !important;
        }

        p.centerp {
            text-align: center;
        }

        strong {
            color: #0aa1bc;
        }

        fieldset.form-group {
            margin: 40px 0px;
        }

        legend span {
            color: #17a9c7;
            font-weight: 700;
        }

        legend {
            border-bottom: 1px solid #f3a740 !important;
        }

        label {
            color: #266373 !important;
            margin: 20px 0px 5px 0px !important;
        }

        .txtMini {
            width: 40% !important;
        }

        txtNormal {
            width: 70% !important;
        }

        .errormin {
            border-color: red !important;
            border-style: solid !important;
            border-width: 2px !important;
        }
    </style>
    <link href="../../Scripts/fancy/source/fancyMins.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#txtEnfermedad").autocomplete({
                select: function (e, ui) { $("#txtEnfermedad").prop('title', ui.item.label); },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerEnfermedad",
                        data: "{ 'criterio':'" + request.term + "' }",
                        dataType: "json", type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        timeout: 5000,
                        success: function (data) {
                            var output = eval(data.d);
                            response(jQuery.map(output, function (item) {
                                return {
                                    label: item.nombre,
                                    value: item.nombre,
                                    // value: item.codigo
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 2
            });
        });

        function getRootWebSitePath() {
            var _location = document.location.toString();
            var applicationNameIndex = _location.indexOf('/', _location.indexOf('://') + 3);
            var applicationName = _location.substring(0, applicationNameIndex) + '/';
            var webFolderIndex = _location.indexOf('/', _location.indexOf(applicationName) + applicationName.length);
            var webFolderFullPath = _location.substring(0, webFolderIndex);
            //return applicationName;
            return webFolderFullPath;
        }

        function UpdateUploadButton(s, e) {
            try {
                var text = s.GetText(e.inputIndex);
                var file = text.replace("fakepath", "");
                var fileFin = file.replace("C:", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("\\", "");
                fileFin = fileFin.replace("\\", "");
                var webSite = getRootWebSitePath();
                var str = document.getElementById('lblTic').textContent;

                var pathRelativo = webSite + "//files//Temporal//3-" + str + fileFin;
                document.getElementById('lblArchivoView').innerHTML = "Archivo Cargado: " + fileFin;
                document.getElementById('lblArchivoView').href = pathRelativo;
                //catrgamos un hidden para cargarlo en el load
            } catch (err) { }
        }

        $(function () {
            $("#txtMedicamento").autocomplete({
                select: function (e, ui) { $("#txtMedicamento").prop('title', ui.item.label); },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerMedicamento",
                        data: "{ 'criterio':'" + request.term + "' }",
                        dataType: "json", type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        timeout: 5000,
                        success: function (data) {
                            var output = eval(data.d);
                            response(jQuery.map(output, function (item) {
                                return {
                                    label: item.nombre,
                                    value: item.nombre,
                                    // value: item.codigo
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 2
            });
        });

        $(function () {
            $("#txtProcedimiento").autocomplete({
                select: function (e, ui) { $("#txtProcedimiento").prop('title', ui.item.label); },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerProcedimientos",
                        data: "{ 'criterio':'" + request.term + "' }",
                        dataType: "json", type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        timeout: 5000,
                        success: function (data) {
                            var output = eval(data.d);
                            response(jQuery.map(output, function (item) {
                                return {
                                    label: item.nombre,
                                    value: item.nombre,
                                    // value: item.codigo
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 2
            });
        });

    </script>
    <script>

        $(document).ready(function () {
            Ajustarcheck();
            $('.tooltip').tooltipster();
            $('.fancybox').fancybox();


        })
        function Ajustarcheck() {
            //si esta chekeado acepto terminos muestra el boton

            var chkEsMedicamento = $('#chkEsMedicamento').prop('checked');
            var chkEsProcedimiento = $('#chkEsProcedimiento').prop('checked');
            var chkEsDispositivoMedico = $('#chkEsDispositivoMedico').prop('checked');
            var chkServicioSalud = $('#chkServicioSalud').prop('checked');
            var chkEsOtro = $('#chkEsOtro').prop('checked');

            var chkExclusionA = $('#chkExclusionA').prop('checked');
            var chkExclusionB = $('#chkExclusionB').prop('checked');
            var chkExclusionC = $('#chkExclusionC').prop('checked');
            var chkExclusionD = $('#chkExclusionD').prop('checked');
            var chkExclusionE = $('#chkExclusionE').prop('checked');
            var chkExclusionF = $('#chkExclusionF').prop('checked');

            var chkConflictoInteres = $('#chkConflictoInteres').prop('checked');
            var chkAdjuntaEvidencia = $('#chkAdjuntaEvidencia').prop('checked');

            if (chkExclusionA == true) {
                $('#divA').show();
            } else {
                $('#divA').hide();
            }
            if (chkExclusionB == true) {
                $('#divB').show();
            } else {
                $('#divB').hide();
            }
            if (chkExclusionC == true) {
                $('#divC').show();
            } else {
                $('#divC').hide();
            }
            if (chkExclusionD == true) {
                $('#divD').show();
            } else {
                $('#divD').hide();
            }
            if (chkExclusionE == true) {
                $('#divE').show();
            } else {
                $('#divE').hide();
            }

            if (chkExclusionF == true) {
                $('#divF').show();
            } else {
                $('#divF').hide();
            }

            if (chkAdjuntaEvidencia == true) {
                $('#divAdjuntaEvidencia').show();
            } else {
                $('#divAdjuntaEvidencia').hide();
            }

            if (chkConflictoInteres == true) {
                $('#divConflicto').show();
            } else {
                $('#divConflicto').hide();
            }

            if (chkEsProcedimiento) {
                $("#txtNombreTecnologia").autocomplete({
                    select: function (e, ui) { $("#txtNombreTecnologia").prop('title', ui.item.label); },
                    messages: { noResults: '', results: function () { } },
                    source: function (request, response) {
                        $.ajax({
                            url: "../ws/ws.asmx/obtenerCups",
                            data: "{ 'criterio':'" + request.term + "' }",
                            dataType: "json", type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            timeout: 5000,
                            success: function (data) {
                                var output = eval(data.d);
                                response(jQuery.map(output, function (item) {
                                    return {
                                        label: item.nombre,
                                        value: item.nombre,
                                        // value: item.codigo
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                debugger;
                            }
                        });
                    }
                    , minLength: 2
                });
            }
            else if (chkEsMedicamento) {
                $("#txtNombreTecnologia").autocomplete({
                    select: function (e, ui) { $("#txtNombreTecnologia").prop('title', ui.item.label); },
                    messages: { noResults: '', results: function () { } },
                    source: function (request, response) {
                        $.ajax({
                            url: "../ws/ws.asmx/obtenerDCI",
                            data: "{ 'criterio':'" + request.term + "' }",
                            dataType: "json", type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            timeout: 5000,
                            success: function (data) {
                                var output = eval(data.d);
                                response(jQuery.map(output, function (item) {
                                    return {
                                        label: item.nombre,
                                        value: item.nombre,
                                        // value: item.codigo
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                debugger;
                            }
                        });
                    }
                    , minLength: 2
                });

            } else {

                $("#txtNombreTecnologia").autocomplete("destroy");
                $("#txtNombreTecnologia").removeData('autocomplete');
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="lblTic" ClientIDMode="Static" Style="display: none;"></asp:Label>
    <asp:Label runat="server" ID="lblCodNominacionProceso" ClientIDMode="Static" Style="display: none;"></asp:Label>
    <asp:PlaceHolder runat="server" ID="posibleAclaracioes" Visible="true">
        <div class="row text-warning warning alert" style="width: 100%; text-align: center; margin-top: 30px; background-color: palegoldenrod">
            Si desea realizar cambios en la nominación recuerde que debe ingresar primero con su usuario y contraseña
        <asp:HyperLink runat="server" ID="lnkInicioPosible" NavigateUrl="~/frm/seguridad/frmLogin.aspx" Text="Ingresar"></asp:HyperLink>
        </div>
    </asp:PlaceHolder>
    <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">Complete el siguiente formulario para realizar la nominación</h2>

                <asp:SqlDataSource ID="SqlDataSourceTipoRepresentados" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_REPRESENTADO], [TIPO_REPRESENTADO] FROM [TIPO_REPRESENTADO]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourcetipoIps" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_IPS], [TIPO_IPS] FROM [TIPO_IPS]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSourceTipoJuridicoCero" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_JURIDICO], [NOMBRE_TIPO_JURIDICO] FROM [TIPO_JURIDICO] WHERE PADRE is null"></asp:SqlDataSource>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
            <div class="col-md-6 col-md-offset-3">

                <h3 class="separation-title__another"></h3>
                <h3 class="separation-title__another"></h3>

                <p class="centerp"><b>FORMATO DE TECNOLOGÍAS NOMINADAS PARA POSIBLE EXCLUSIÓN </b></p>

                <p class="centerp">DIRECCIÓN DE REGULACIÓN DE BENEFICIOS, COSTOS Y TARIFAS DEL ASEGURAMIENTO EN SALUD</p>
            </div>
            <div class="row">

                <div class="col-md-8 col-md-offset-2">
                    <asp:Panel runat="server" ID="pnlNominador" Visible="false">
                        <fieldset runat="server" id="Fieldset2" class="form-group">
                            <legend><span>
                                <label runat="server" clientidmode="Static" id="Label27">1 Información del nominador </label>
                            </span></legend>

                            <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label41">Tipo de Actor del SGSSS </label>
                            <asp:TextBox runat="server" ReadOnly="true" Text="" type="text" name="name" ID="txtTipoAator" MaxLength="100" CssClass="form-control" />

                            <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label42">Nombre persona natural  o de la entidad proponente (según corresponda) </label>
                            <asp:TextBox runat="server" Text="" ReadOnly="true" type="text" name="name" ID="txtNombreNominador" MaxLength="100" CssClass="form-control" />



                        </fieldset>
                    </asp:Panel>


                    <fieldset runat="server" id="Fieldset1" class="form-group">
                        <legend><span>
                            <label runat="server" clientidmode="Static" id="lblenumeracionNatural">1 Información de la tecnología nominada para posible exclusión</label></span></legend>
                        <p>Ingrese la información requerida. </p>
                        <asp:Panel runat="server" ID="pnlFisica" Visible="false">
                            <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label45">No Radicado </label>
                            <asp:TextBox runat="server" Text="" type="text" ReadOnly="true" name="name" ID="txtRadicado" MaxLength="100" CssClass="form-control" />

                            <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label51">Anotación </label>
                            <asp:TextBox runat="server" Text="" type="text" ReadOnly="true" name="name" ID="txtAnotacion" MaxLength="100" CssClass="form-control" />
                        </asp:Panel>

                        <div style="border-color: #f3a740; border-style: solid; border-width: 1px; padding: 10px 10px 10px 10px;">
                            <label for="chkPatologia" clientidmode="Static" runat="server" id="Label2">Seleccionar la opción que mejor describe la tecnología a nominar. </label>
                            <br />
                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkEsMedicamento" />

                                <label>Es medicamento</label>
                            </div>
                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkEsProcedimiento" />

                                <label>Es procedimiento</label>
                            </div>
                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkEsDispositivoMedico" />

                                <label>Es dispositivo medico</label>
                            </div>
                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkServicioSalud" />

                                <label>Es servicio de salud</label>
                            </div>

                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkEsOtro" />

                                <label>Otro</label>

                            </div>
                        </div>
                        <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label7">Nombre de la tecnología </label>
                        <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="imgTooltip"
                            title="Se debe registrar el nombre genérico de la tecnología 
                                    En caso de medicamentos se debe realizar en la Denominación Común Internacional
                                    Si es procedimiento se debe realizar con el código y descripción CUPS
                                    Si es dispositivo médico se debe realizar acorde con su registro INVIMA (si lo tiene)
                                    " /><label>Ayuda</label>
                        <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNombreTecnologia" MaxLength="100" CssClass="form-control" ClientIDMode="Static" />

                        <asp:Panel runat="server" ID="pnlValidacionNombreTecnologia">
                            <label for="cmbGrupoNombreTecnologia" clientidmode="Static" runat="server" id="Label28">Observaciones  Validación Nombre de la tecnología </label>
                            <asp:DropDownList AppendDataBoundItems="true"
                                Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;"
                                runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoNombreTecnologia" DataSourceID="SqlDataSourceGrupoTecnologia" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                            </asp:DropDownList>

                            <asp:SqlDataSource ID="SqlDataSourceGrupoTecnologia" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_PARAMETRO_VALIDACION], [DESCRIPCION] FROM [PARAMETRO_VALIDACION] WHERE ([COD_GRUPO_PARAMETRO_VALIDACION] = @COD_GRUPO_PARAMETRO_VALIDACION) ORDER BY [DESCRIPCION]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="COD_GRUPO_PARAMETRO_VALIDACION" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                        <br />


                        <div id="divEnfermedad">
                            <label for="txtEnfermedad" clientidmode="Static" runat="server" id="Label9">Nombre la enfermedad o condición de salud que motiva la nominación de exclusión de la tecnologia.  </label>
                            <%--<label for="txtEnfermedad" clientidmode="Static" runat="server" id="Label8">Al empezar a escribir en este campo, se presentará la clasificación CIE-10. Seleccione la opción que más le convenga, en caso contrario digítela.</label>--%>
                            <p>
                                Al empezar a escribir en este campo, se presentará la clasificación CIE-10. Seleccione la opción que más le convenga, en caso contrario digítela.
                            <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image1"
                                title="Incluya como mínimo: el nombre de la patología o condición de salud asociada, por la cual debe ser excluida la tecnología nominada y la población usuaria de la tecnología nominada para esta condición (sexo, grupo etario, etnia, etc.)" /><label>Ayuda</label>
                            </p>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEnfermedad" TextMode="MultiLine" Height="50px" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />
                            <asp:Panel runat="server" ID="pnlValidacionCie10a">
                                <label for="cmbGrupoCie10" clientidmode="Static" runat="server" id="Label48">Observaciones  Validación </label>
                                <asp:DropDownList AppendDataBoundItems="true" Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoCie10" DataSourceID="SqlDataSourceGrupoNombreTecnologia" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                    <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                                </asp:DropDownList>

                                <asp:SqlDataSource ID="SqlDataSourceGrupoNombreTecnologia" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_PARAMETRO_VALIDACION], [DESCRIPCION] FROM [PARAMETRO_VALIDACION] WHERE ([COD_GRUPO_PARAMETRO_VALIDACION] = @COD_GRUPO_PARAMETRO_VALIDACION) ORDER BY [DESCRIPCION]">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="2" Name="COD_GRUPO_PARAMETRO_VALIDACION" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>

                            </asp:Panel>
                            <label for="txtEnfermedad2" clientidmode="Static" runat="server" id="Label14">Observación </label>
                            <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image2"
                                title="Describa el uso de esta tecnología" /><label>Ayuda</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEnfermedad2" TextMode="MultiLine" Height="50px" MaxLength="3500" CssClass="form-control" ClientIDMode="Static" />
                            <asp:Panel runat="server" ID="pnlValidacionCie10b">
                                <label for="cmbGrupoCie10b" clientidmode="Static" runat="server" id="Label49">Observaciones  Validación CIE-10 </label>
                                <asp:DropDownList AppendDataBoundItems="true" Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoCie10b" DataSourceID="SqlDataSourceGrupoNombreTecnologia" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                    <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                                </asp:DropDownList>

                            </asp:Panel>

                            <br />

                        </div>



                    </fieldset>
                    <fieldset>
                        <legend><span>Información de criterios de exclusión</span></legend>
                        <p>Seleccione el criterio o los criterios que justifiquen la nominación</p>


                        <div class="checklistn">


                            <asp:CheckBox onchange="Ajustarcheck();" ID="chkExclusionA" runat="server" ClientIDMode="Static" />
                            <label for="chkExclusionA" clientidmode="Static" runat="server" id="Label3">A) Que tengan como finalidad principal un propósito cosmético o suntuario no relacionado </label>
                            <label>con la recuperación o mantenimiento de la capacidad funcional o vital de las personas.</label>
                            <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image5"
                                title="Aquella tecnología cuya intención corresponde a embellecer, aumentar la atracción, alterar la apariencia física o cualquier otra característica, o aquel que de conformidad con el criterio del grupo de análisis técnico-científico pretende alcanzar un fin innecesario o prescindible en el ámbito de la salud. Es decir, el uso de la tecnología no es requerido, sin ella no está en riesgo la vida o la capacidad funcional de las personas " /><label>Ayuda</label>


                            <div id="divA" style="display: none;">
                                <label for="txtJustificacionA" clientidmode="Static" runat="server" id="Label4">Justifique su elección y aclare si se refiere a una tecnología con propósito cosmético, una tecnología con propósito suntuario o ambas. </label>

                                <asp:TextBox CssClass="form-control" runat="server" ID="txtJustificacionA" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>


                                <asp:Panel runat="server" ID="pnlValidacionA">
                                    <label for="cmbGrupoCriterioA" clientidmode="Static" runat="server" id="Label33">validación Criterios de Exclusión </label>
                                    <asp:DropDownList AppendDataBoundItems="true" Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoCriterioA" DataSourceID="SqlDataSourceCriteriosExclusion" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                        <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceCriteriosExclusion" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_PARAMETRO_VALIDACION], [DESCRIPCION] FROM [PARAMETRO_VALIDACION] WHERE ([COD_GRUPO_PARAMETRO_VALIDACION] = @COD_GRUPO_PARAMETRO_VALIDACION) ORDER BY [DESCRIPCION]">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="7" Name="COD_GRUPO_PARAMETRO_VALIDACION" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>

                                </asp:Panel>
                            </div>

                        </div>

                        <div class="checklistn">
                            <asp:CheckBox onchange="Ajustarcheck();" ID="chkExclusionB" runat="server" ClientIDMode="Static" />
                            <label for="chkExclusionB" clientidmode="Static" runat="server" id="Label5">B) Que no exista evidencia científica sobre su seguridad y eficacia clínica. </label>
                            <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image6"
                                title="Aquella tecnología que no presenta información generada de estudios de investigación en salud basados en un método objetivo, explícito y reproducible; aquella que presentando esta información no permite predecir los resultados en salud para los cuales fue diseñada o no permite establecer su grado de seguridad; o cuenta con nueva evidencia que demuestra su ineficacia o inseguridad para uso en humanos, preferentemente comparada con otras tecnologías disponibles en el país. " /><label>Ayuda</label>

                            <div id="divB" style="display: none;">
                                <label for="txtJustificacionB" clientidmode="Static" runat="server" id="Label6">Justifique su elección. Asimismo, se sugiere que registre los posibles comparadores (tecnologías que cumplan con el mismo fin e indicación) y especifique si el criterio aplica por seguridad, eficacia o ambas. </label>
                                <asp:TextBox CssClass="form-control" runat="server" ID="txtJustificacionB" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                <br>

                                <asp:Panel runat="server" ID="pnlValidacionB">
                                    <label for="cmbGrupoCriterioB" clientidmode="Static" runat="server" id="Label38">validación Criterios de Exclusión </label>
                                    <asp:DropDownList AppendDataBoundItems="true" Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoCriterioB" DataSourceID="SqlDataSourceCriteriosExclusion" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                        <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>

                                    </asp:DropDownList>

                                </asp:Panel>
                            </div>

                        </div>


                        <div class="checklistn">

                            <asp:CheckBox onchange="Ajustarcheck();" ID="chkExclusionC" runat="server" ClientIDMode="Static" />
                            <label for="chkExclusionC" clientidmode="Static" runat="server" id="Label16">C) Que no exista evidencia científica sobre su efectividad clínica. </label>
                            <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image7"
                                title="Aquella tecnología que no cuente con evidencia científica sobre su efectividad clínica o que los resultados de los estudios comparativos evidencien que su efectividad clínica es inferior frente a las alternativas disponibles. " /><label>Ayuda</label>

                            <div id="divC" style="display: none;">
                                <label for="txtJustificacionC" clientidmode="Static" runat="server" id="Label17">Justifique su elección. Asimismo, se sugiere que registre los posibles comparadores (tecnologías que cumplan con el mismo fin e indicación). </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtJustificacionC" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                                <asp:Panel runat="server" ID="pnlValidacionC">
                            </div>

                            <label for="cmbGrupoCriterioC" clientidmode="Static" runat="server" id="Label37">validación Criterios de Exclusión </label>
                            <asp:DropDownList AppendDataBoundItems="true" Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoCriterioC" DataSourceID="SqlDataSourceCriteriosExclusion" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>

                            </asp:DropDownList>
                            </asp:Panel>
                        </div>
                </div>


                <div class="checklistn">
                    <asp:CheckBox onchange="Ajustarcheck();" ID="chkExclusionD" runat="server" ClientIDMode="Static" />
                    <label for="chkExclusionD" clientidmode="Static" runat="server" id="Label18">D) Que su uso no haya sido autorizado por la autoridad competente. </label>
                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image8"
                        title="La tecnología no autorizada es aquella que no ha surtido el proceso ante la autoridad en salud competente para la autorización de su uso; o aquella que habiendo adelantado dicho trámite no reunió los estándares necesarios para su autorización. Exceptuando los medicamentos considerados por INVIMA como Vitales No Disponibles y los usos de medicamentos no incluidos en el registro sanitario definidos por el Ministerio de Salud y Protección Social, dentro del listado de usos no incluidos en el registro sanitario,-UNIRS. " /><label>Ayuda</label>

                    <div id="divD" style="display: none;">
                        <label for="txtJustificacionD" clientidmode="Static" runat="server" id="Label19">Justifique su elección. </label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtJustificacionD" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>


                        <asp:Panel runat="server" ID="pnlValidacionD">
                            <label for="cmbGrupoCriterioD" clientidmode="Static" runat="server" id="Label36">validación Criterios de Exclusión </label>
                            <asp:DropDownList AppendDataBoundItems="true" Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoCriterioD" DataSourceID="SqlDataSourceCriteriosExclusion" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>

                            </asp:DropDownList>

                        </asp:Panel>
                    </div>
                </div>

                <div class="checklistn">
                    <asp:CheckBox onchange="Ajustarcheck();" ID="chkExclusionE" runat="server" ClientIDMode="Static" />
                    <label for="chkExclusionE" clientidmode="Static" runat="server" id="Label20">E) Que se encuentren en fase de experimentación. </label>
                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image9"
                        title="Aquella tecnología que no ha culminado la secuencia de estudios que debe cumplir una tecnología para demostrar su eficacia y seguridad en seres humanos. " /><label>Ayuda</label>

                    <div id="divE" style="display: none;">
                        <label for="txtJustificacionE" clientidmode="Static" runat="server" id="Label21">Justifique su elección. </label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtJustificacionE" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        <br>

                        <asp:Panel runat="server" ID="pnlValidacionE">
                            <label for="cmbGrupoCriterioE" clientidmode="Static" runat="server" id="Label35">validación Criterios de Exclusión </label>
                            <asp:DropDownList AppendDataBoundItems="true" Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoCriterioE" DataSourceID="SqlDataSourceCriteriosExclusion" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                            </asp:DropDownList>

                        </asp:Panel>
                    </div>
                </div>

                <div class="checklistn">
                    <asp:CheckBox onchange="Ajustarcheck();" ID="chkExclusionF" runat="server" ClientIDMode="Static" />
                    <label for="chkExclusionF" clientidmode="Static" runat="server" id="Label22">F) Que tengan que ser prestados en el exterior. </label>
                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image10"
                        title="Será excluida de la financiación con recursos públicos de la salud aquella tecnología en salud que se preste fuera del país, exceptuando los estudios de laboratorio y patología ofertados y con toma de muestra en el país y procesados en el exterior. " /><label>Ayuda</label>
                    <br>

                    <br>
                    <div id="divF" style="display: none;">
                        <label for="txtJustificacionF" clientidmode="Static" runat="server" id="Label23">Justifique su elección. </label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtJustificacionF" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        <br>

                        <asp:Panel runat="server" ID="pnlValidacionF">
                            <label for="cmbGrupoCriterioF" clientidmode="Static" runat="server" id="Label34">validación Criterios de Exclusión </label>
                            <asp:DropDownList Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" AppendDataBoundItems="true" runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoCriterioF" DataSourceID="SqlDataSourceCriteriosExclusion" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>

                            </asp:DropDownList>

                        </asp:Panel>
                    </div>
                </div>

                </fieldset>
                    <fieldset>
                        <legend>Información adicional</legend>
                        <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label24">Adjunta evidencia  </label>
                        <asp:RadioButton GroupName="evidencia" onchange="Ajustarcheck();" ID="chkAdjuntaEvidencia" runat="server"
                            ClientIDMode="Static" Text="SI" />
                        <asp:RadioButton GroupName="evidencia" onchange="Ajustarcheck();" ID="chkNoAdjuntaEvidencia" runat="server"
                            ClientIDMode="Static" Text="NO" />
                        <div id="divAdjuntaEvidencia" style="display: none;">
                            <label for="txtEvidencia" clientidmode="Static" runat="server" id="Label13">Usando el <a href="https://www.uahurtado.cl/pdf/Cita_y_Referencia_Bibliogrfica_gua_basada_en_las_normas_APA.pdf#page=20" target="_blank">formato APA</a> relacione y anexe las referencias de evidencia científica que soportan la nominación y realice un breve resumen de la referencia. </label>
                            <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image11"
                                title="Para relacionar la evidencia haga uso preferiblemente de la norma APA sexta edición " /><label>Ayuda</label>
                            <label></label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEvidencia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                            <div id="pnlArchivoJuridico1">

                                <label for="divDocumentoNatural2" clientidmode="Static" runat="server" id="lbltituloArchivoJuridico1">Adjunte Documento de evidencia  </label>
                                <asp:Button runat="server" ID="btnArchivo" Text="Subir Archivo" OnClick="btnArchivo_Click" />

                                <asp:UpdatePanel runat="server" ID="pnlGrillaArchivos" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <asp:DataList Width="600px" runat="server" ID="grdArchivos">
                                            <ItemTemplate>
                                                <div class="form-control">
                                                    <asp:HyperLink runat="server" Text='<%# "Archivo cargado:"+Eval("descripcion") %>'
                                                        Target="_blank" NavigateUrl='<%# "~"+Eval("url").ToString().Substring(Eval("url").ToString().IndexOf("\\files\\Temporal")) %>'></asp:HyperLink>

                                                    <asp:ImageButton
                                                        Visible="<%# btnArchivo.Visible %>"
                                                        Width="10px" runat="server" ID="btnelimnarARchivo" ImageUrl="~/img/web/delete.png" OnClick="btnEliminarArchivo_Click" ValidationGroup='<%# Eval("url") %>' />
                                                </div>
                                                <div>
                                                </div>
                                            </ItemTemplate>

                                        </asp:DataList>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <asp:Panel runat="server" ID="pnlValidacionEvidencia">
                                <label for="cmbGrupoEvidencia" clientidmode="Static" runat="server" id="Label39">validación evidencia </label>
                                <asp:DropDownList Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" runat="server" AppendDataBoundItems="true" CssClass="form-control" Enabled="false" ID="cmbGrupoEvidencia" DataSourceID="SqlDataSourceEvidencia" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                    <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>

                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceEvidencia" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_PARAMETRO_VALIDACION], [DESCRIPCION] FROM [PARAMETRO_VALIDACION] WHERE ([COD_GRUPO_PARAMETRO_VALIDACION] = @COD_GRUPO_PARAMETRO_VALIDACION) ORDER BY [DESCRIPCION]">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="8" Name="COD_GRUPO_PARAMETRO_VALIDACION" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>

                            </asp:Panel>
                        </div>

                        <br>
                        <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label25">Conflicto de intereses </label>
                        <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image3"
                            title="Son posibles situaciones de orden moral, intelectual y económico que pueden impedirle a una persona actuar de forma objetiva e independiente, ya sea porque le resulte particularmente conveniente, le sea personalmente beneficioso o porque sus familiares en los grados indicados en la ley se vean igualmente beneficiados" /><label>Ayuda</label>

                        <asp:RadioButton GroupName="conflicto" onchange="Ajustarcheck();" ID="chkConflictoInteres" runat="server"
                            ClientIDMode="Static" Text="SI" />
                        <asp:RadioButton GroupName="conflicto" onchange="Ajustarcheck();" ID="chkNoConflictoInteres" runat="server"
                            ClientIDMode="Static" Text="NO" />


                        <div id="divConflicto" style="display: none;">
                            <label for="txtConflicto" clientidmode="Static" runat="server" id="Label1">Describa el conflicto de intereses teniendo en cuenta los siguientes aspectos:</label>
                            <ul>
                                <ol><strong>Financiero:</strong> Cuando el individuo tiene participación en una empresa, organización o equivalente que se relaciona directamente (socio, accionista, propietario, empleado) o indirectamente (proveedor, asesor, consultor) con las actividades para las cuales fue convocado a participar.</ol>
                                <ol><strong>Intelectual:</strong> Cuando se tiene un interés intelectual, académico o científico en un tema en particular. La declaración de este tipo de interés es indispensable para salvaguardar la calidad y objetividad del trabajo científico.</ol>
                                <ol><strong>Pertenencia:</strong> Derechos de propiedad intelectual o industrial que estén directamente relacionados con las temáticas o actividades a abordar.</ol>
                                <ol><strong>Familiar:</strong>  Cuando alguno de los familiares, hasta el tercer grado de consanguinidad y segundo de afinidad o primero civil, están relacionados de manera directa o indirecta en los aspectos financiero o intelectual, con las actividades y temáticas a desarrollar</ol>
                            </ul>

                            <asp:TextBox runat="server" CssClass="form-control" ID="txtConflicto" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            <label>Nota: El declarar el conflicto de intereses no limita su participación en la nominación.</label>
                            <asp:Panel runat="server" ID="pnlValidacionConflicto">
                                <label for="cmbGrupoConflicto" clientidmode="Static" runat="server" id="Label40">validación conflicto de interes </label>
                                <asp:DropDownList Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" AppendDataBoundItems="true" runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoConflicto" DataSourceID="SqlDataSourceConflictoInteres" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                                    <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceConflictoInteres" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_PARAMETRO_VALIDACION], [DESCRIPCION] FROM [PARAMETRO_VALIDACION] WHERE ([COD_GRUPO_PARAMETRO_VALIDACION] = @COD_GRUPO_PARAMETRO_VALIDACION) ORDER BY [DESCRIPCION]">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="9" Name="COD_GRUPO_PARAMETRO_VALIDACION" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>

                            </asp:Panel>
                        </div>
                    </fieldset>

                <div id="pnlAcepto">
                    <asp:Panel runat="server" ID="pnlObservacionesGenerales">
                        <asp:DropDownList Style="border-color: #DB0050 !important; border-style: solid; border-width: 1px;" AppendDataBoundItems="true" runat="server" CssClass="form-control" Enabled="false" ID="cmbGrupoConcepto" DataSourceID="SqlDataSourceConcepto" DataTextField="DESCRIPCION" DataValueField="COD_PARAMETRO_VALIDACION">
                            <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceConcepto" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_PARAMETRO_VALIDACION], [DESCRIPCION] FROM [PARAMETRO_VALIDACION] WHERE ([COD_GRUPO_PARAMETRO_VALIDACION] = @COD_GRUPO_PARAMETRO_VALIDACION) ORDER BY [DESCRIPCION]">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="10" Name="COD_GRUPO_PARAMETRO_VALIDACION" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <label for="txtObservacionesGenerales" clientidmode="Static" runat="server" id="Label26">Observaciones Generales de la validacón </label>
                        <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtObservacionesGenerales" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>


                    </asp:Panel>
                    <div class="form-group">
                        <asp:Label ID="LblValidacionCampos" runat="server" ForeColor="#E4335C" Font-Size="14pt" />
                    </div>

                    <div class="form-group">
                        <asp:Button runat="server" ClientIDMode="Static"
                            OnClientClick="return confirm('Esta seguro de enviar el formulario una vez enviado no podra realizar ningun ajuste');"
                            type="submit" ID="btnGuardarContinuar" Text="Guardar y enviar" CssClass="boton2"
                            OnClick="btnGuardarContinuar_Click" Height="50px" />

                        <asp:Button runat="server"
                            ClientIDMode="Static" OnClick="btnGuardar_Click" type="submit" ID="btnGuardar" Text="Guardar" CssClass="boton2" Height="50px" Visible="false" />
                    </div>
                </div>
                <a runat="server" clientidmode="Static" visible="false" target="_blank" id="lnkPDF">Generar PDF</a>
                <asp:Button ID="btnObjetar" ClientIDMode="Static" runat="server" Text="Objetar" OnClick="btnObjetar_Click" CausesValidation="true"
                    Visible="false" CssClass="btn green pull-right" Height="50px" />


            </div>
        </div>
    </div>

    <asp:Label runat="server" ID="lblInvicible"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="popupNuevo" runat="server"
        BackgroundCssClass="modalBackground" TargetControlID="lblInvicible"
        DropShadow="true" PopupControlID="pnlCaptura">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnlCaptura" Width="400px" Height="230px" BackColor="White">
        <asp:UpdatePanel ID="upnNuevo" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="vertical-align: central;">
                    <br />
                    <table>
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;</td>

                            <td colspan="3">
                                <asp:Label ID="lblTituloDetalle" runat="server" Font-Bold="true"
                                    Text="Descripción del archivo."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;</td>
                            <td colspan="3">
                                <asp:TextBox runat="server" ID="txtDescripcionArchivo" Width="380"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;</td>
                            <td colspan="3">Archivo
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;</td>
                            <td colspan="3">
                                <div id="div1" runat="server">
                                    <dx:ASPxUploadControl ID="uploadDocumentoNatural" runat="server"
                                        AutoStartUpload="true"
                                        BrowseButton-Image-Height="20px"
                                        BrowseButton-Image-Url="~/Img/file.png"
                                        BrowseButton-Image-Width="20px"
                                        BrowseButton-Text=""
                                        ClientInstanceName="uploadDocumentoNatural"
                                        NullText="Seleccion al archivo..."
                                        OnFileUploadComplete="uploadDocumentoNatural_FileUploadComplete"
                                        ShowProgressPanel="true"
                                        ShowUploadButton="false"
                                        UploadMode="Standard"
                                        ValidationSettings-MaxFileSizeErrorText="El tamaño de los archivos no debe superar 1Gb."
                                        Width="100%">
                                        <AdvancedModeSettings EnableMultiSelect="false" />
                                        <ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.gif,.png,.pdf,.bmp" MaxFileSize="1100000000">
                                        </ValidationSettings>
                                        <ClientSideEvents
                                            FilesUploadComplete="function(s, e) { UpdateUploadButton(); }"
                                            FileUploadComplete="function(s, e) { UpdateUploadButton(s, e); }"
                                            TextChanged="function(s, e) { s.Upload(); }" />
                                    </dx:ASPxUploadControl>
                                </div>
                                <a id="lblArchivoView" runat="server"
                                    class="form-control"
                                    clientidmode="Static"
                                    style="color: #094B59" target="_blank"></a>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblErrorDetalle" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table class="table table-striped table-bordered table-hover dataTable">
                        <tr>
                            <td style="text-align: center">
                                <asp:Button ID="btnAceptarDetalle" runat="server" Text="Aceptar" OnClick="BtnAceptarDetalle_Click" CausesValidation="true"
                                    CssClass="btn green pull-right" ValidationGroup="ValidarInsertar" />


                            </td>
                            <td style="text-align: center">
                                <asp:Button ID="btnCancelarDetalle" runat="server" Text="Cancelar" OnClick="btnCancelarDetalle_Click"
                                    CssClass="btn green pull-left" />
                            </td>
                        </tr>
                        <tr>
                            <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" ShowSummary="true" ValidationGroup="ValidarInsertar" />
                        </tr>
                    </table>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
