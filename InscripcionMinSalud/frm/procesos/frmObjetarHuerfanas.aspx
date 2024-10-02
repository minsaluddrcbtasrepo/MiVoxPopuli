<%@ Page Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmObjetarHuerfanas.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmObjetarHuerfanas" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
    </style>
    <style type="text/css">
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
            padding: 5px;
            border: none;
            font-weight: bold;
            width: 250px;
            margin: 40px auto;
            text-align: center;
        }

        input#btnCancelar {
            background: #30798d;
            background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
            background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
            background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
            border-radius: 5px;
            color: #fff;
            font-size: 1.9rem;
            padding: 5px;
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
        $(function () {
            $("#txtEnfermedad2").autocomplete({
                select: function (e, ui) { $("#txtEnfermedad2").prop('title', ui.item.label); },
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
        $(function () {
            $("#txtEnfermedad3").autocomplete({
                select: function (e, ui) { $("#txtEnfermedad3").prop('title', ui.item.label); },
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

        $(function () {
            $("#txtEspecialidad").autocomplete({
                select: function (e, ui) { $("#txtEspecialidad").prop('title', ui.item.label); },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerEspecialidad",
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
            $("#txtEspecialidad2").autocomplete({
                select: function (e, ui) { $("#txtEspecialidad2").prop('title', ui.item.label); },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerEspecialidad",
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
            $("#txtEspecialidad3").autocomplete({
                select: function (e, ui) { $("#txtEspecialidad3").prop('title', ui.item.label); },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerEspecialidad",
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
            $("#txtEspecialidad4").autocomplete({
                select: function (e, ui) { $("#txtEspecialidad4").prop('title', ui.item.label); },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerEspecialidad",
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
            $("#txtEspecialidad5").autocomplete({
                select: function (e, ui) { $("#txtEspecialidad5").prop('title', ui.item.label); },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerEspecialidad",
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
            $("#txtEspecialidad6").autocomplete({
                select: function (e, ui) { $("#txtEspecialidad6").prop('title', ui.item.label); },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerEspecialidad",
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
            $("#txtCups1").autocomplete({
                select: function (e, ui) { $("#txtCups1").prop('title', ui.item.label); },
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
        });
        $(function () {
            $("#txtCups2").autocomplete({
                select: function (e, ui) { $("#txtCups2").prop('title', ui.item.label); },
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
        });
        $(function () {
            $("#txtCups3").autocomplete({
                select: function (e, ui) { $("#txtCups3").prop('title', ui.item.label); },
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
        });

        $(function () {
            $("#txtCupsOpcional1").autocomplete({
                select: function (e, ui) { $("#txtCupsOpcional1").prop('title', ui.item.label); },
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
        });

        $(function () {
            $("#txtCupsOpcional2").autocomplete({
                select: function (e, ui) { $("#txtCupsOpcional2").prop('title', ui.item.label); },
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
        });

        $(function () {
            $("#txtCupsOpcional3").autocomplete({
                select: function (e, ui) { $("#txtCupsOpcional3").prop('title', ui.item.label); },
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

                var pathRelativo = webSite + "//files//DocumentosHuerfanas//3-" + str + fileFin;
                document.getElementById('lblArchivoView').innerHTML = "Archivo Cargado: " + fileFin;
                document.getElementById('lblArchivoView').href = pathRelativo;
                //catrgamos un hidden para cargarlo en el load
            } catch (err) { }
        }

    </script>
    <script type="text/javascript" language="javascript">
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
    </script>
    <script type="text/javascript" language="javascript">
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
            $('#formulario').hide();
            var chkEsIncluir = $('#chkEsIncluir').prop('checked');
            var chkEsExcluir = $('#chkEsExcluir').prop('checked');
            var chkEsCambio = $('#chkEsCambio').prop('checked');
            var chkCodigo = $('#chkCodigo').prop('checked');
            var chkPruebaDiagnostica = $('#chkPruebaDiagnostica').prop('checked');
            var chkDiciplina = $('#chkDiciplina').prop('checked');
            var chkAdjuntaEvidencia = $('#chkAdjuntaEvidencia').prop('checked');

            if (chkEsIncluir == true) {
                $('#formulario').show();
                $('#TipoConfirmacion').show();
                $('#TipoConfirmacion').children().attr('readonly', true);
                $('#Confirmatoria').show();
                $('#Confirmatoria').children().attr('readonly', true);
                $('#Especialidad').show();
                $('#Especialidad').children().attr('readonly', true);
                $('#nuevoNombre').hide();
                $('#lblNombreTecnologia').text("Nombre de la enfermedad huérfana a nominar");
                $('#Cie10').show();
                $('#Cie10').children().attr('readonly', true);
                $('#lblCie10').text("Código CIE-10 (Si aplica)");
                $('#nuevoCodigo').hide();
                $('#modificacionPrueba').hide();
                $('#modificacionEspecialidad').hide();
                $('#lblJustificacion').text("Descripción y justificación de la nominación ");

            } else if (chkEsExcluir == true) {
                $('#formulario').show();
                $('#lblNombreTecnologia').text("Nombre de la enfermedad huérfana a excluir. ");
                $('#Cie10').show();
                $('#lblCie10').text("Código CIE-10 de la enfermedad huerfana a excluir (Si aplica)");
                $('#nuevoNombre').hide();
                $('#TipoConfirmacion').hide();
                $('#Confirmatoria').hide();
                $('#nuevoCodigo').hide();
                $('#Especialidad').hide();
                $('#modificacionPrueba').hide();
                $('#modificacionEspecialidad').hide();
                $('#lblJustificacion').text("Descripción y justificación de la exclusión ");

            } else if (chkEsCambio == true) {
                $('#formulario').show();
                $('#lblNombreTecnologia').text("Nombre de la enfermedad huérfana a modificar. ");
                $('#nuevoNombre').show();
                $('#Cie10').show();
                $('#lblCie10').text("Código CIE-10 de la enfermedad huerfana a modificar (Si aplica)");
                $('#TipoConfirmacion').hide();
                $('#Confirmatoria').hide();
                $('#nuevoCodigo').hide();
                $('#Especialidad').hide();
                $('#modificacionPrueba').hide();
                $('#modificacionEspecialidad').hide();
                $('#lblJustificacion').text("Descripción y justificación de la modificación");

            } else if (chkCodigo == true) {
                $('#formulario').show();
                $('#lblNombreTecnologia').text("Nombre de la enfermedad huérfana cuyo código se propone modificar o incluir ");
                $('#nuevoNombre').hide();
                $('#Cie10').hide();
                $('#TipoConfirmacion').hide();
                $('#Confirmatoria').hide();
                $('#nuevoCodigo').show();
                $('#Especialidad').hide();
                $('#modificacionPrueba').hide();
                $('#modificacionEspecialidad').hide();
                $('#lblJustificacion').text("Descripción y justificación de la modificación/Inclusion");

            } else if (chkPruebaDiagnostica == true) {
                $('#formulario').show();
                $('#lblNombreTecnologia').text("Nombre de la enfermedad huérfana en la que la prueba diagnostica confirmatoria se propone modificar");
                $('#nuevoNombre').hide();
                $('#lblCie10').text("Código CIE-10 (Si aplica)");
                $('#Cie10').show();
                $('#TipoConfirmacion').hide();
                $('#Confirmatoria').hide();
                $('#nuevoCodigo').hide();
                $('#Especialidad').hide();
                $('#modificacionPrueba').show();
                $('#modificacionEspecialidad').hide();
                $('#lblJustificacion').text("Descripción y justificación de la modificacion de la prueba confirmatoria");

            } else if (chkDiciplina == true) {
                $('#formulario').show();
                $('#lblNombreTecnologia').text("Nombre de la enfermedad huérfana en la que se modificarán las disciplinas o las  especialidades");
                $('#nuevoNombre').hide();
                $('#lblCie10').text("Código CIE-10 (Si aplica)");
                $('#Cie10').show();
                $('#TipoConfirmacion').hide();
                $('#Confirmatoria').hide();
                $('#nuevoCodigo').hide();
                $('#Especialidad').hide();
                $('#modificacionPrueba').hide();
                $('#modificacionEspecialidad').show();
                $('#lblJustificacion').text("Descripción y justificación del cambio/inclusion de especialidades");

            } else {
                $('#formulario').hide();
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


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="lblTic" ClientIDMode="Static" Style="display: none;"></asp:Label>
    <asp:Label runat="server" ID="lblCodNominacionProceso" ClientIDMode="Static" Style="display: none;"></asp:Label>
    <asp:PlaceHolder runat="server" ID="posibleAclaracioes" Visible="true">
        <div class="row text-warning warning alert" style="width: 100%; text-align: center; margin-top: 30px; background-color: palegoldenrod">
            Si desea objetar la nominación recuerde que debe ingresar primero con su usuario y contraseña
        <asp:HyperLink runat="server" ID="lnkInicioPosible" NavigateUrl="~/frm/seguridad/frmLogin.aspx" Text="Ingresar"></asp:HyperLink>
        </div>
    </asp:PlaceHolder>
    <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">Complete el siguiente formulario para objetar la nominación</h2>

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

                <p class="centerp"><b>Información de la Enfermedad Huérfana o cambio en el listado oficial nominado</b></p>
                <p class="centerp">DIRECCIÓN DE PROMOCIÓN Y PREVENCIÓN - SUBDIRECCION DE ENFERMEDADES NO TRANSMISIBLES</p>
            </div>
            <div class="row">

                <%--Nominador--%>

                <div class="col-md-8 col-md-offset-2">
                    <asp:Panel runat="server" ID="pnlNominador" Visible="true">
                        <fieldset runat="server" id="Fieldset2" class="form-group">
                            <legend><span>
                                <label runat="server" clientidmode="Static" id="Label27">Información del nominador </label>
                            </span></legend>

                            <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label41">Tipo de Actor del SGSSS </label>

                            <asp:TextBox runat="server" ReadOnly="true" Text="" type="text" name="name" ID="txtTipoAator" MaxLength="100" CssClass="form-control" />

                            <label for="txtIdentificacionNominador" clientidmode="Static" runat="server" id="Label5">Número de identificación </label>
                            <asp:TextBox runat="server" Text="" ReadOnly="true" type="text" name="name" ID="txtIdentificacionNominador" MaxLength="100" CssClass="form-control" />

                            <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label42">Nombre persona natural  o de la entidad proponente (según corresponda) </label>

                            <asp:TextBox runat="server" Text="" ReadOnly="true" type="text" name="name" ID="txtNombreNominador" MaxLength="100" CssClass="form-control" />

                            <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label28">Email </label>

                            <asp:TextBox runat="server" Text="" ReadOnly="true" type="text" name="name" ID="txtEmailNominador" MaxLength="100" CssClass="form-control" />



                        </fieldset>
                    </asp:Panel>

                    <fieldset runat="server" id="Fieldset1" class="form-group">
                        <legend><span>
                            <label runat="server" clientidmode="Static" id="lblenumeracionNatural">1 Categoría de la nominación</label></span></legend>
                        <p>Ingrese la información requerida. </p>


                        <div style="border-color: #f3a740; border-style: solid; border-width: 1px; padding: 10px 10px 10px 10px;">
                            <label for="chkPatologia" clientidmode="Static" runat="server" id="Label2">Seleccionar la opción que mejor describe el cambio a nominar. </label>
                            <br />
                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkEsIncluir" />

                                <label>Inclusión de un nuevo diagnóstico/enfermedad en el listado</label>
                            </div>
                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkEsExcluir" />

                                <label>Exclusión de un diagnóstico/enfermedad en el listado</label>
                            </div>
                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkEsCambio" />

                                <label>Modificación del nombre de un diagnóstico/enfermedad del listado.</label>
                            </div>

                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkCodigo" />

                                <label>Modificación de algún código del listado actual (CIE-10, ORPHA, OMIM)</label>
                            </div>

                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkPruebaDiagnostica" />

                                <label>Modificación de la Prueba Diagnóstica Confirmatoria de un </label>
                                <label>diagnóstico/enfermedad del listado actual</label>
                            </div>


                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkDiciplina" />

                                <label>Modificación en las disciplinas o especialidades que intervienen en el diagnóstico </label>
                                <label>y liderazgo del manejo integral de una enfermedad.</label>
                            </div>

                        </div>
                        <br />
                    </fieldset>
                    <fieldset>

                        <%--Nombre Nominacion--%>
                        <label clientidmode="Static" runat="server" id="lblNombreTecnologia"></label>
                        <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNombreTecnologia" MaxLength="100" CssClass="form-control" />
                        <br />

                        <%--CIE-10 # 1--%>
                        <div id="Cie10">
                            <label clientidmode="Static" runat="server" id="lblCie10"></label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCie10" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />
                        </div>

                        <div id="nuevoNombre">
                            <label clientidmode="Static" runat="server" id="lblNuevoNombre">Nuevo nombre de la enfermedad huérfana a modificar</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNuevoNombre" MaxLength="100" CssClass="form-control" />

                            <label clientidmode="Static" runat="server" id="Label7">Código CIE-10 (Si aplica)</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCie10NuevoNombre" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />

                        </div>


                        <br />
                        <div id="TipoConfirmacion">
                            <label for="cmbTipoConfirmacion" clientidmode="Static" runat="server" id="lblTipoConfirmacion">Tipo de confirmación diagnóstica de la enfermedad huérfana</label>
                            <asp:DropDownList class="form-control" runat="server" ID="cmbTipoConfirmacion">
                                <asp:ListItem Text="Seleccione" Value=""></asp:ListItem>
                                <asp:ListItem Text="Clínica" Value="Clínica"></asp:ListItem>
                                <asp:ListItem Text="Laboratorio" Value="Laboratorio "></asp:ListItem>
                                <asp:ListItem Text="Clínica y Laboratorio" Value="Clínica y Laboratorio"></asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <div id="nuevoCodigo">
                            <label clientidmode="Static" runat="server" id="Label11">Código a modificar </label>
                            <asp:DropDownList class="form-control" runat="server" ID="cmbCodigoModificar">
                                <asp:ListItem Text="Seleccione" Value=""></asp:ListItem>
                                <asp:ListItem Text="CIE 10" Value="CIE 10"></asp:ListItem>
                                <asp:ListItem Text="OMIM" Value="OMIM "></asp:ListItem>
                                <asp:ListItem Text="ORPHA" Value="ORPHA"></asp:ListItem>
                            </asp:DropDownList>
                            <label clientidmode="Static" runat="server" id="Label12">Nuevo Código Propuesto</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNuevoCodigo" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />

                        </div>

                        <div id="modificacionPrueba">

                            <label clientidmode="Static" runat="server" id="lblConfirmatoriaActual">Prueba diagnóstica confirmatoria actual </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtConfirmatoriaActual" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />

                            <label clientidmode="Static" runat="server" id="lblCupsConfirmatoriaActual">CUPS de prueba diagnóstica confirmatoria actual </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsConfirmatoriaActual" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />

                            <label clientidmode="Static" runat="server" id="lblConfirmatoriaPropuesta">Prueba diagnóstica propuesta</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtConformatoriaPropuesta" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />

                            <label clientidmode="Static" runat="server" id="lblCupsConfirmatoriaPropuesta">CUPS de prueba diagnóstica propuesta</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsConformatoriaPropuesta" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />

                            <label clientidmode="Static" runat="server" id="Label20">CUPS de prueba diagnóstica alterna</label>
                            <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image18"
                                title="Escoja el código CUPS (Clasificación Única de Procedimientos en Salud -CUPS) de la prueba diagnóstica alterna, si aplica." /><label>Ayuda</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCUPSPruebaAlterna" MaxLength="500" CssClass="form-control" ClientIDMode="Static" ReadOnly="true" />


                        </div>

                        <div id="modificacionEspecialidad">

                            <label clientidmode="Static" runat="server" id="Label15">Especialidades actuales</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEspecialidadesActuales" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />

                            <label clientidmode="Static" runat="server" id="Label16">Especialidades propuestas</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEspecialidadesPropuestas" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />

                        </div>


                        <%--Pruebas confirmatorias--%>
                        <div id="Confirmatoria">
                            <legend id="legConfirmatoria">Información de prueba diagnóstica confirmatoria propuesta para la enfermedad </legend>
                            <label for="txtConfirmatoria1" clientidmode="Static" runat="server" id="lblConfirmatoria">Nombre prueba diagnóstica confirmatoria de laboratorio (Si aplica)</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtConfirmatoria1"></asp:TextBox>
                            <label for="txtCups1" clientidmode="Static" runat="server" id="lblCupsConfirmatoria">CUPS prueba diagnóstica confirmatoria (Si aplica)</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCups1" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />
                        </div>

                        <%--Especialidades--%>
                        <br />

                        <div id="Especialidad">
                            <legend id="legEspecialidad">Especialidades propuestas para el análisis diagnóstico  </legend>

                            <p id="pEspecialidad">Ingrese la especialidad o especialidades que deberán participar en el análisis para el diagnóstico de la enfermedad huérfana</p>

                            <label for="txtEspecialidad" clientidmode="Static" runat="server" id="lblEspecialidad">Especialidad 1</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEspecialidad" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />


                            <label for="txtEspecialidad2" clientidmode="Static" runat="server" id="lblEspecialidad2">Especialidad 2</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEspecialidad2" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />


                            <label for="txtEspecialidad3" clientidmode="Static" runat="server" id="lblEspecialidad3">Especialidad 3</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEspecialidad3" MaxLength="500" CssClass="form-control" ClientIDMode="Static" />

                        </div>


                        <%--Justificacion--%>
                        <label for="txtDescripJustifaca" clientidmode="Static" runat="server" id="Label14">Descripción y justificación </label>
                        <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtDescriptJustifica" TextMode="MultiLine" Height="200px" CssClass="form-control" ClientIDMode="Static" />

                    </fieldset>


                    <legend>Información adicional</legend>
                    <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label24">Adjunta evidencia  </label>
                    <asp:RadioButton GroupName="evidencia" onchange="Ajustarcheck();" ID="chkAdjuntaEvidencia" runat="server"
                        ClientIDMode="Static" Text="SI" />
                    <asp:RadioButton GroupName="evidencia" onchange="Ajustarcheck();" ID="chkNoAdjuntaEvidencia" runat="server"
                        ClientIDMode="Static" Text="NO" />

                    <div id="divAdjuntaEvidencia" style="display: none;">
                        <label for="txtEvidencia" clientidmode="Static" runat="server" id="Label13">Usando el <a href="https://www.uahurtado.cl/pdf/Cita_y_Referencia_Bibliogrfica_gua_basada_en_las_normas_APA.pdf#page=20" target="_blank">formato APA</a> relacione y anexe las referencias de evidencia científica que soportan la nominación y realice un breve resumen de la referencia. </label>
                        <label></label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEvidencia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                        <label for="divDocumentoNatural2" clientidmode="Static" runat="server" id="Label10">Documentos adjuntos a esta nominación  </label>
                        <div runat="server" id="urlEvidencia"></div>

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
                    <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label25">Declaración de posibles conflictos de intereses </label>
                    <div>
                        <asp:RadioButton GroupName="conflicto" ID="chkConflictoInteres" runat="server"
                            ClientIDMode="Static" Text="SI" />
                        <asp:RadioButton GroupName="conflicto" ID="chkNoConflictoInteres" runat="server"
                            ClientIDMode="Static" Text="NO" />
                    </div>
                    <br />
                    <%--<div id="divConflicto" >--%>
                    <label for="txtConflicto" clientidmode="Static" runat="server" id="Label3">Objetivo:</label>
                    <p>La presente declaración tiene por objeto garantizar en el ejercicio trasparente de la participación ciudadana, la imparcialidad de los participantes con derecho a voto en el proceso actual, de modo que se conozca el posible o posibles conflictos de intereses y su relación de causalidad frente a las opiniones o recomendaciones que incidirán en la toma de decisiones relacionadas con las políticas en salud.</p>
                    <p>Las actividades que pueden generar conflicto de intereses son aquellas en las que el juicio del profesional en salud o la de un agremiado, agente o actor del sector salud puede estar afectado por un interés primario, que incida en su actividad participativa.</p>
                    <label for="txtConflicto" clientidmode="Static" runat="server" id="Label1">Describa el conflicto de intereses teniendo en cuenta los siguientes aspectos:</label>
                    <label for="txtConflicto" clientidmode="Static" runat="server" id="Label4">Tipos de conflictos:</label>
                    <ul>
                        <ol><strong>Financiero:</strong> Cuando el individuo tiene participación en una empresa, organización o equivalente que se relaciona directamente (socio, accionista, propietario, empleado) o indirectamente (proveedor, asesor, consultor) con las actividades para las cuales fue convocado a participar.</ol>
                        <ol><strong>Intelectual:</strong> Cuando se tiene un interés intelectual, académico o científico en un tema en particular. La declaración de este tipo de interés es indispensable para salvaguardar la calidad y objetividad del trabajo científico.</ol>
                        <ol><strong>Pertenencia:</strong> Derechos de propiedad intelectual o industrial que estén directamente relacionados con las temáticas o actividades a abordar.</ol>
                        <ol><strong>Familiar:</strong>  Cuando alguno de los familiares, hasta el tercer grado de consanguinidad y segundo de afinidad o primero civil, están relacionados de manera directa o indirecta en los aspectos financiero o intelectual, con las actividades y temáticas a desarrollar</ol>
                    </ul>
                    <label for="txtConflicto" clientidmode="Static" runat="server" id="Label6">Declaración:</label>
                    <p>He leído y comprendo el objetivo de la declaración de conflicto de intereses</p>
                    <p>Por lo tanto, en forma espontánea y libre de todo apremio doy fe acerca de los posibles intereses que podrían afectar mis actuaciones en el proceso al que he sido convocado a participar.</p>
                    <p>Esta declaración, también hace referencia a los vínculos y posibles intereses de mis parientes consanguíneos, afines o civiles, durante los últimos dos (2) años.</p>
                    <label for="txtConflicto" clientidmode="Static" runat="server" id="Label8">A continuación, describo los conflictos de intereses que poseo:</label>
                    <ul>

                        <asp:TextBox runat="server" CssClass="form-control" ID="txtInteresEconomico" TextMode="MultiLine" Width="700px" Height="80px" Visible="false"></asp:TextBox>

                        <ol>
                            <strong>Descripción del conflicto de  Interés</strong>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtConflicto" TextMode="MultiLine" Width="700px" Height="80px"></asp:TextBox>
                        </ol>

                    </ul>

                    <fieldset runat="server" id="Fieldset3" class="form-group">
                        <h2 style="color: brown;">Resultado de la validación</h2>
                        <h3 runat="server" id="lblConceptoValidacion" style="color: #266373 !important;">Concepto general de la validación: </h3>

                        <hr style="width: 800px; height: 2px; border-width: 0; color: gray; background-color: gray;" />
                        <h4>Existe completitud, correspondencia y coherencia de la nominación: Coherencia entre la categoría de la nominación y la propuesta presentada, asi como, la correspondencia del código CIE con el diagnóstico/enfermedad nominada y la categoría de la etiología de la enfermedad</h4>
                        <h3 runat="server" id="lblConceptoPlenitud" style="color: #266373 !important;"></h3>

                        <hr style="width: 800px; height: 2px; border-width: 0; color: gray; background-color: gray;" />
                        <h4>La nominación ya está incluida en la Resolución vigente.</h4>
                        <h3 runat="server" id="lblConceptoIncluida" style="color: #266373 !important;"></h3>

                        <hr style="width: 800px; height: 2px; border-width: 0; color: gray; background-color: gray;" />
                        <h4>La prueba diagnóstica sugerida corresponde con la nominación, así como el Código Único de Prestación de Servicios (CUPS).</h4>
                        <h3 runat="server" id="lblConceptoCUPS" style="color: #266373 !important;"></h3>

                        <hr style="width: 800px; height: 2px; border-width: 0; color: gray; background-color: gray;" />
                        <h4>Al menos una especialidad está registrada y correponde con la nominación propuesta.</h4>
                        <h3 runat="server" id="lblConceptoEspecialidad" style="color: #266373 !important;"></h3>

                        <hr style="width: 800px; height: 2px; border-width: 0; color: gray; background-color: gray;" />
                        <h4>Los documentos y enlaces aportados realmente contienen la evidencia correspondiente con la EHR nominada.</h4>
                        <h3 runat="server" id="lblConceptoEvidencia" style="color: #266373 !important;"></h3>

                    </fieldset>

                    <hr style="width: 800px; height: 2px; border-width: 0; color: gray; background-color: gray;" />
                    <h3 style="color: #266373 !important;">Amplie la información para justificar la validación de la nominación rechazada:</h3>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtObservacionesGenerales" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                    <label for="divDocumentoNatural2" clientidmode="Static" runat="server" id="lblAdjunteDocumento">En caso de tener información adicional que respalde su objeción, adjúntela</label>
                    <asp:Button runat="server" ID="Button1" Text="Subir Archivo" OnClick="btnArchivo_Click" />

                    <asp:UpdatePanel runat="server" ID="pnlGrillaArchivos2" UpdateMode="Conditional">
                        <ContentTemplate>

                            <asp:DataList Width="600px" runat="server" ID="grdArchivos2">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <asp:ImageButton
                                                Visible="<%# Button1.Visible %>"
                                                Width="40px" runat="server" ID="btnelimnarARchivo" ImageUrl="~/img/web/delete.png" OnClick="btnelimnarARchivo_Click" ValidationGroup='<%# Eval("url") %>' Text="Eliminar archivo" />
                                        </div>
                                        <div class="col-md-9">
                                            <asp:HyperLink runat="server" Text='<%# "Archivo cargado:"+Eval("descripcion") %>'
                                                Target="_blank" NavigateUrl='<%# "~"+Eval("url").ToString().Substring(Eval("url").ToString().IndexOf("\\files\\DocumentosHuerfanas")) %>'></asp:HyperLink>
                                            </col>
                                        
                                        </div>
                                </ItemTemplate>

                            </asp:DataList>

                        </ContentTemplate>
                    </asp:UpdatePanel>



                    <div class="form-group">
                        <asp:Label ID="LblValidacionCampos" runat="server" ForeColor="#E4335C" Font-Size="14pt" />
                    </div>

                    <div class="form-group">

                        <asp:Button runat="server"
                            ClientIDMode="Static" OnClick="btnGuardar_Click" type="submit" ID="btnGuardar" Text="Objetar" CssClass="callpart" />

                        <asp:Button runat="server"
                            ClientIDMode="Static" OnClick="btnCancelar_Click" type="submit" ID="btnCancelar" Text="Cancelar" CssClass="callpart" />

                    </div>
                </div>

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
                                <asp:Button ID="btnAceptarDetalle" runat="server" Text="Aceptar" OnClick="btnAceptarDetalle_Click" CausesValidation="true"
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
    </div>
</asp:Content>
