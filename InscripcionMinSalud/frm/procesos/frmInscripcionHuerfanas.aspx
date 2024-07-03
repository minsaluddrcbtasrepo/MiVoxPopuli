<%@ Page Language="C#" MasterPageFile="~/frm/master/masterb.Master" AutoEventWireup="true" CodeBehind="frmInscripcionHuerfanas.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmInscripcionHuerfanas" %>
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
            $("#txtCIENuevoNombre").autocomplete({
                select: function (e, ui) { $("#txtCIENuevoNombre").prop('title', ui.item.label); },
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
            $("#txtEspActual").autocomplete({
                select: function (e, ui) { $("#txtEspActual").prop('title', ui.item.label); },
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
            $("#txtEspActual2").autocomplete({
                select: function (e, ui) { $("#txtEspActual2").prop('title', ui.item.label); },
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
            $("#txtEspActual3").autocomplete({
                select: function (e, ui) { $("#txtEspActual3").prop('title', ui.item.label); },
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
            $("#txtEspActual4").autocomplete({
                select: function (e, ui) { $("#txtEspActual4").prop('title', ui.item.label); },
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
            $("#txtEspActual5").autocomplete({
                select: function (e, ui) { $("#txtEspActual5").prop('title', ui.item.label); },
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
            $("#txtEspecialidadPropuesta").autocomplete({
                select: function (e, ui) { $("#txtEspecialidadPropuesta").prop('title', ui.item.label); },
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
            $("#txtEspecialidadPropuesta2").autocomplete({
                select: function (e, ui) { $("#txtEspecialidadPropuesta2").prop('title', ui.item.label); },
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
            $("#txtEspecialidadPropuesta3").autocomplete({
                select: function (e, ui) { $("#txtEspecialidadPropuesta3").prop('title', ui.item.label); },
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
            $("#txtEspecialidadPropuesta4").autocomplete({
                select: function (e, ui) { $("#txtEspecialidadPropuesta4").prop('title', ui.item.label); },
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
            $("#txtEspecialidadPropuesta5").autocomplete({
                select: function (e, ui) { $("#txtEspecialidadPropuesta5").prop('title', ui.item.label); },
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
                select: function (e, ui) {
                   
                    limpiarControles2();
                    $("#txtConfirmatoria1").val(ui.item.label.split('-')[0]);
                    $("#txtCups1").val(ui.item.label.split('-')[1]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCupsEHF",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });

         $(function () {
            $("#txtConfirmatoria1").autocomplete({
                select: function (e, ui) {
                   
                    limpiarControles2();
                    $("#txtConfirmatoria1").val(ui.item.label.split('-')[0]);
                    $("#txtCups1").val(ui.item.label.split('-')[1]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCupsEHF",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });

        
        $(function () {
            $("#txtCups1").autocomplete({
                select: function (e, ui) {
                   
                    limpiarControles2();
                    $("#txtConfirmatoria1").val(ui.item.label.split('-')[0]);
                    $("#txtCups1").val(ui.item.label.split('-')[1]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCupsEHF",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });

         $(function () {
            $("#txtConfirmatoriaActual").autocomplete({
                select: function (e, ui) {
                   
                    limpiarControles4();
                    $("#txtConfirmatoriaActual").val(ui.item.label.split('-')[0]);
                    $("#txtCupsConfirmatoriaActual").val(ui.item.label.split('-')[1]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCupsEHF",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });

        $(function () {
            $("#txtCupsConfirmatoriaActual").autocomplete({
                select: function (e, ui) {
                   
                    limpiarControles2();
                    $("#txtConfirmatoriaActual").val(ui.item.label.split('-')[0]);
                    $("#txtCupsConfirmatoriaActual").val(ui.item.label.split('-')[1]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCupsEHF",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });

         $(function () {
            $("#txtConformatoriaPropuesta").autocomplete({
                select: function (e, ui) {
                   
                    limpiarControles5();
                    $("#txtConformatoriaPropuesta").val(ui.item.label.split('-')[0]);
                    $("#txtCupsConformatoriaPropuesta").val(ui.item.label.split('-')[1]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCupsEHF",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });

        $(function () {
            $("#txtCupsConformatoriaPropuesta").autocomplete({
                select: function (e, ui) {
                   
                    limpiarControles5();
                    $("#txtConformatoriaPropuesta").val(ui.item.label.split('-')[0]);
                    $("#txtCupsConformatoriaPropuesta").val(ui.item.label.split('-')[1]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCupsEHF",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });

          $(function () {
            $("#txtPruebaAlterna").autocomplete({
                select: function (e, ui) {
                   
                    limpiarControles6();
                    $("#txtPruebaAlterna").val(ui.item.label.split('-')[0]);
                    $("#txtCUPSPruebaAlterna").val(ui.item.label.split('-')[1]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCupsEHF",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });

        $(function () {
            $("#txtCUPSPruebaAlterna").autocomplete({
                select: function (e, ui) {
                   
                    limpiarControles5();
                    $("#txtPruebaAlterna").val(ui.item.label.split('-')[0]);
                    $("#txtCUPSPruebaAlterna").val(ui.item.label.split('-')[1]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCupsEHF",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
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


        $(function () {
            $("#txtCodigo").autocomplete({
                select: function (e, ui) {
                    limpiarControles();

                    $("#txtCodigo").val(ui.item.label.split(';')[0]);
                    $("#txtNombreTecnologia").val(ui.item.label.split(';')[1]);
                    $("#txtCIE").val(ui.item.label.split(';')[2]);

                    return false;

                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCodigoEnfermedadListado",
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
                , minLength: 1
            });
        });

        $(function () {
            $("#txtNombreTecnologia").autocomplete({
                select: function (e, ui) {
                    limpiarControles();

                    $("#txtCodigo").val(ui.item.label.split(';')[0]);
                    $("#txtNombreTecnologia").val(ui.item.label.split(';')[1]);
                    $("#txtCIE").val(ui.item.label.split(';')[2]);

                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerEnfermedadListado",
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

                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });

        $(function () {
            $("#txtCIE").autocomplete({
                select: function (e, ui) {
                    limpiarControles();
                    $("#txtCodigo").val(ui.item.label.split(';')[0]);
                    $("#txtNombreTecnologia").val(ui.item.label.split(';')[1]);
                    $("#txtCIE").val(ui.item.label.split(';')[2]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCIEEnfermedadListado",
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
                , minLength: 1
            });
        });


        $(function () {
            $("#txtNombreTecnologiaInclusion").autocomplete({
                select: function (e, ui) {
                    limpiarControles();
                
                    $("#txtNombreTecnologiaInclusion").val(ui.item.label.split('-')[1]);
                    $("#txtCIEInclusion").val(ui.item.label.split('-')[0]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCIE",
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
                , minLength: 1
            });
        });


        
        $(function () {
            $("#txtCIEInclusion").autocomplete({
                select: function (e, ui) {
                       $("#txtNombreTecnologiaInclusion").val(ui.item.label.split('-')[1]);
                       $("#txtCIEInclusion").val(ui.item.label.split('-')[0]);
                        return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCIE",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });


        function limpiarControles() {
            $("#txtNombreTecnologiaInclusion").value = "";
            $("#txtCIEInclusion").value = "";
            $("#txtCodigo").value = "";
            $("#txtNombreTecnologia").value = "";
            $("#txtCIE").value = "";
        }

        function limpiarControles2() {
            $("#txtConfirmatoria1").value = "";
            $("#txtCups1").value = "";
        }

          function limpiarControles3() {
            $("#txtNuevoNombre").value = "";
            $("#txtCIENuevoNombre").value = "";
        }

         function limpiarControles4() {
            $("#txtConfirmatoriaActual").value = "";
            $("#txtCupsConfirmatoriaActual").value = "";
        }

         function limpiarControles5() {
            $("#txtConformatoriaPropuesta").value = "";
            $("#txtCupsConformatoriaPropuesta").value = "";
        }

         function limpiarControles6() {
            $("#txtPruebaAlterna").value = "";
            $("#txtCUPSPruebaAlterna").value = "";
        }

        $(function () {
            $("#txtNuevoNombre").autocomplete({
                select: function (e, ui) {
                    limpiarControles3();
                    $("#txtNuevoNombre").val(ui.item.label.split('-')[1]);
                    $("#txtCIENuevoNombre").val(ui.item.label.split('-')[0]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCIE",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });
         
        $(function () {
            $("#txtCIENuevoNombre").autocomplete({
                select: function (e, ui) {
                    limpiarControles3();
                    $("#txtNuevoNombre").val(ui.item.label.split('-')[1]);
                    $("#txtCIENuevoNombre").val(ui.item.label.split('-')[0]);
                    return false;
                },
                messages: { noResults: '', results: function () { } },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerCIE",
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
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
                }
                , minLength: 1
            });
        });


        $(document).ready(function () {
            $('#formulario').hide();
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
            var chkConflictoInteres = $('#chkConflictoInteres').prop('checked');

            var inp;
            $('#formulario > input').each(function () {
                inp = $(this).val("");
            });

            if (chkEsIncluir == true) {
                $('#formularioInclusion').show();
                $('#formularioCodigo').hide();
                $('#formulario').show();
                $('#TipoConfirmacion').show();
                $('#Confirmatoria').show();
                $('#Especialidad').show();
                $('#nuevoNombre').hide();
                $('#nuevoCodigo').hide();
                $('#modificacionPrueba').hide();
                $('#modificacionEspecialidad').hide();
                $('#lblJustificacion').text("Descripción y justificación de la nominación ");

            } else if (chkEsExcluir == true) {
                $('#formularioInclusion').hide();
                $('#formularioCodigo').show();
                $('#formulario').show();
                $('#lblNombreTecnologia').text("Nombre de la enfermedad huérfana a excluir. ");
                document.getElementById("ContentPlaceHolder1_ayudaNombreTecnologia").title = "Escriba el nombre de la Enfermedad Huérfana que excluye";
                document.getElementById("ayudaNombreTecnologia2").title = "Escriba el nombre de la Enfermedad Huérfana que excluye";

                $('#CIE').show();
                $('#lblCIE').text("Código CIE de la enfermedad huerfana a excluir ");
                $('#nuevoNombre').hide();
                $('#TipoConfirmacion').hide();
                $('#Confirmatoria').hide();
                $('#nuevoCodigo').hide();
                $('#Especialidad').hide();
                $('#modificacionPrueba').hide();
                $('#modificacionEspecialidad').hide();
                $('#lblJustificacion').text("Descripción y justificación de la exclusión ");

            } else if (chkEsCambio == true) {
                $('#formularioInclusion').hide();
                $('#formularioCodigo').show();
                $('#formulario').show();
                $('#lblNombreTecnologia').text("Nombre del diagnóstico/enfermedad huérfana a modificar. ");
                 document.getElementById("ContentPlaceHolder1_ayudaNombreTecnologia").title = "Escriba el nombre de la Enfermedad Huérfana que nómina";
                document.getElementById("ayudaNombreTecnologia2").title = "Escriba el nombre de la Enfermedad Huérfana que nómina";

                $('#nuevoNombre').show();
                $('#CIE').show();
                $('#lblCIE').text("Código CIE del diagnóstico/enfermedad huerfana a modificar ");
                $('#TipoConfirmacion').hide();
                $('#Confirmatoria').hide();
                $('#nuevoCodigo').hide();
                $('#Especialidad').hide();
                $('#modificacionPrueba').hide();
                $('#modificacionEspecialidad').hide();
                $('#lblJustificacion').text("Descripción y justificación de la modificación");

            } else if (chkCodigo == true) {
                $('#formularioInclusion').hide();
                $('#formularioCodigo').show();
                $('#formulario').show();
                $('#lblNombreTecnologia').text("Nombre de la enfermedad huérfana cuyo código se propone modificar o incluir ");
                   document.getElementById("ContentPlaceHolder1_ayudaNombreTecnologia").title = "Escriba el nombre de la Enfermedad Huérfana que nómina";
                document.getElementById("ayudaNombreTecnologia2").title = "Escriba el nombre de la Enfermedad Huérfana que nómina";

                $('#nuevoNombre').hide();
                $('#CIE').hide();
                $('#TipoConfirmacion').hide();
                $('#Confirmatoria').hide();
                $('#nuevoCodigo').show();
                $('#Especialidad').hide();
                $('#modificacionPrueba').hide();
                $('#modificacionEspecialidad').hide();
                $('#lblJustificacion').text("Descripción y justificación de la modificación/Inclusion");

            } else if (chkPruebaDiagnostica == true) {
                $('#formularioInclusion').hide();
                $('#formularioCodigo').show();
                $('#formulario').show();
                $('#lblNombreTecnologia').text("Nombre de la enfermedad huérfana en la que la prueba diagnostica confirmatoria se propone modificar");
                   document.getElementById("ContentPlaceHolder1_ayudaNombreTecnologia").title = "Escriba el nombre de la Enfermedad Huérfana que nómina";
                document.getElementById("ayudaNombreTecnologia2").title = "Escriba el nombre de la Enfermedad Huérfana que nómina";

                $('#nuevoNombre').hide();
                $('#lblCIE').text("Código CIE");
                $('#CIE').show();
                $('#TipoConfirmacion').hide();
                $('#Confirmatoria').hide();
                $('#nuevoCodigo').hide();
                $('#Especialidad').hide();
                $('#modificacionPrueba').show();
                $('#modificacionEspecialidad').hide();
                $('#lblJustificacion').text("Descripción y justificación de la modificacion de la prueba confirmatoria");

            } else if (chkDiciplina == true) {
                $('#formularioInclusion').hide();
                $('#formularioCodigo').show();
                $('#formulario').show();
                $('#lblNombreTecnologia').text("Nombre de la enfermedad huérfana en la que se modificarán las  especialidades");
                   document.getElementById("ContentPlaceHolder1_ayudaNombreTecnologia").title = "Escriba el nombre de la Enfermedad Huérfana que nómina";
                document.getElementById("ayudaNombreTecnologia2").title = "Escriba el nombre de la Enfermedad Huérfana que nómina";

                $('#nuevoNombre').hide();
                $('#lblCIE').text("Código CIE");
                $('#CIE').show();
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

    <div class="row" style="margin-right: 0px  !important; margin-left: -0px  !important;">
        <div class="container" style="width:100%">
            <div class="col-md-6 col-md-offset-3">

                <h3 class="separation-title__another"></h3>
                <h3 class="separation-title__another"></h3>

                <p class="centerp"><b>FORMATO DE NOMINACIÓN DE NOVEDADES PARA ACTUALIZAR EL LISTADO DE ENFERMEDADES HUERFANAS</b></p>
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

                            <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label41">Tipo de Usuario </label>

                            <asp:TextBox runat="server" ReadOnly="true" Text="" type="text" name="name" ID="txtTipoAator" MaxLength="100" CssClass="form-control" />

                            <label for="txtIdentificacionNominador" clientidmode="Static" runat="server" id="Label5">Documento </label>
                            <asp:TextBox runat="server" Text="" ReadOnly="true" type="text" name="name" ID="txtIdentificacionNominador" MaxLength="100" CssClass="form-control" />

                            <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label42">Nominador</label>

                            <asp:TextBox runat="server" Text="" ReadOnly="true" type="text" name="name" ID="txtNombreNominador" MaxLength="100" CssClass="form-control" />

                            <label for="txtNombreTecnologia" clientidmode="Static" runat="server" id="Label28">Email </label>

                            <asp:TextBox runat="server" Text="" ReadOnly="true" type="text" name="name" ID="txtEmailNominador" MaxLength="100" CssClass="form-control" />

                        </fieldset>
                    </asp:Panel>


                    <fieldset runat="server" id="Fieldset1" class="form-group">
                        <legend><span>
                            <label runat="server" clientidmode="Static" id="lblenumeracionNatural">1 Categoría de la nominación</label></span></legend>
                        <p>Ingrese la información requerida. </p>


                        <div style="border-color: #f3a740; border-style: solid; border-width: 1px; padding: 10px 10px 10px 10px;" id="opcionCambio" runat="server">
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

                                <label>Modificación de algún código del listado actual (CIE, ORPHA, OMIM)</label>
                            </div>

                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkPruebaDiagnostica" />

                                <label>Modificación de la Prueba Diagnóstica Confirmatoria de un diagnóstico/enfermedad del listado actual</label>
                            </div>


                            <div class="checklistn">
                                <asp:RadioButton runat="server" GroupName="grupoUno" ClientIDMode="Static" onchange="Ajustarcheck();" ID="chkDiciplina" />

                                <label>Modificación en las disciplinas o especialidades que intervienen en el diagnóstico.</label>
                                <%--<label>y liderazgo del manejo integral de una enfermedad.</label>--%>
                            </div>

                        </div>
                        <br />

                        <div id="formulario" visible="false">

                            <div id="formularioInclusion">

                                <%--Nombre Nominacion--%>
                                <label clientidmode="Static" runat="server" id="lblNombreTecnologiaNominacion">Nombre de la enfermedad huérfana a nominar</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="ayudaNombreTecnologiaNominacion"
                                    title="Escriba el nombre de la Enfermedad Huérfana que nomina" ToolTip="" /><label title="Escriba el nombre de la Enfermedad Huérfana que nomina">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNombreTecnologiaInclusion" MaxLength="100" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba el nombre de la Enfermedad Huérfana que nomina" />
                                <br />


                                <label clientidmode="Static" runat="server" id="lblCIEInclusion">Código CIE de la enfermedad que nomina</label>
                                <label title="Escoja el código CIE que más se asemeja a la enfermedad que esta nominado.">
                                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image16"
                                        title="Escoja el código CIE que más se asemeja a la enfermedad que esta nominado." />Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCIEInclusion" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Ingrese el código CIE que más se asemeja a la enfermedad que esta nominado"/>

                            </div>


                            <div id="formularioCodigo">


                                <%--Nombre Exclusiones--%>
                                <label clientidmode="Static" runat="server" id="Label17">Código de la Enfermedad Huérfana</label>
                                <label title="Escriba el código consecutivo de la enfermedad que nomina, según el listado oficial de Enfermedades Huérfanas"><asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image13"
                                    title="Escriba el código consecutivo de la enfermedad que nomina, según el listado oficial de Enfermedades Huérfanas" ToolTip="" />Ayuda</label>
                                <asp:TextBox runat="server" Text="" TextMode="Number" min="0" max="9999" name="name" ID="txtCodigo" MaxLength="100" CssClass="form-control" ClientIDMode="Static" placeholder="Código consecutivo de la enfermedad que nomina, según el listado oficial de Enfermedades Huérfanas" />



                                <label clientidmode="Static" runat="server" id="lblNombreTecnologia"></label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="ayudaNombreTecnologia"
                                    title=" " ToolTip="" /><label id="ayudaNombreTecnologia2" title=" " >Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNombreTecnologia" MaxLength="100" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba el nombre de la enfermedad huérfana que nomina"/>
                                <br />
                                <%--CIE # 1--%>
                                <div id="CIE">
                                    <label clientidmode="Static" runat="server" id="lblCIE"></label>
                                    <label title="Escoja el código CIE que más se asemeja a la patología que esta nominado.">
                                        <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image1"
                                            title="Escoja el código CIE que más se asemeja a la patología que esta nominado." />Ayuda</label>
                                    <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCIE" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Ingrese el código CIE que más se asemeja a la patología que esta nominado" />
                                </div>

                            </div>


                            <div id="nuevoNombre">
                                <label clientidmode="Static" runat="server" id="lblNuevoNombre">Nuevo nombre del diagnóstico/enfermedad huérfana propuesto</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image3"
                                    title="Sugiera el nuevo nombre para el  diagnóstico/enfermedad huérfana-rara." /><label  title="Sugiera el nuevo nombre para el  diagnóstico/enfermedad huérfana-rara.">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNuevoNombre" MaxLength="100" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba el nuevo nombre que sugiere para el diagnóstico/enfermedad huérfana-rara." />

                                <label clientidmode="Static" runat="server" id="Label3">Código CIE del nuevo del diagnóstico/enfermedad huérfana</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image4"
                                    title="Escoja el código CIE que más se asemeja a la patología que esta nominado" /><label title="Escoja el código CIE que más se asemeja a la patología que esta nominado">Ayuda</label>
                                <asp:TextBox runat="server" type="text" name="name" ID="txtCIENuevoNombre" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba el código CIE que más se asemeja al nuevo del diagnóstico/enfermedad que esta nominado" />

                            </div>


                            <br />
                            <div id="TipoConfirmacion">
                                <label for="cmbTipoConfirmacion" clientidmode="Static" runat="server" id="lblTipoConfirmacion">Tipo de confirmación diagnóstica de la enfermedad huérfana</label>
                                <asp:DropDownList class="form-control" runat="server" ID="cmbTipoConfirmacion">
                                    <asp:ListItem Text="Seleccione" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Clínica" Value="Clínica"></asp:ListItem>
                                    <asp:ListItem Text="Paraclinica(Laboratorio)" Value="Laboratorio "></asp:ListItem>
                                    <asp:ListItem Text="Ambas(Clínica y Laboratorio)" Value="Clínica y Laboratorio"></asp:ListItem>
                                </asp:DropDownList>
                            </div>


                            <div id="nuevoCodigo">
                                <label clientidmode="Static" runat="server" id="Label7">Código a modificar </label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image21"
                                    title="Seleccione el tipo de código a modificar" /><label title="Seleccione el tipo de código a modificar">Ayuda</label>
                                <asp:DropDownList class="form-control" runat="server" ID="cmbCodigoModificar">
                                    <asp:ListItem Text="Seleccione" Value=""></asp:ListItem>
                                    <asp:ListItem Text="CIE" Value="CIE"></asp:ListItem>
                                    <asp:ListItem Text="OMIM" Value="OMIM "></asp:ListItem>
                                    <asp:ListItem Text="ORPHA" Value="ORPHA"></asp:ListItem>
                                </asp:DropDownList>
                                <label clientidmode="Static" runat="server" id="Label11">Nuevo Código Propuesto</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image6"
                                    title="Escriba el código que propone para esta enfermedad." /><label title="Escriba el código que propone para esta enfermedad.">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNuevoCodigo" MaxLength="8" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba el código que propone para esta enfermedad." />

                            </div>

                            <div id="modificacionPrueba">

                                <label clientidmode="Static" runat="server" id="lblConfirmatoriaActual">Prueba diagnóstica confirmatoria actual </label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image7"
                                    title="Escriba la prueba diagnóstica confirmatoria que actualmente esta incluída en el Anexos del Protocolo Enfermedades Huerfanas -Raras." /><label title="Escriba la prueba diagnóstica confirmatoria que actualmente esta incluída en el Anexos del Protocolo Enfermedades Huerfanas -Raras.">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtConfirmatoriaActual" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba la prueba diagnóstica confirmatoria que actualmente esta incluída en el Anexos del Protocolo EHR." />

                                <label clientidmode="Static" runat="server" id="lblCupsConfirmatoriaActual">CUPS de prueba diagnóstica confirmatoria actual </label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image12"
                                    title="Escoja el código CUPS (Clasificación Única de Procedimientos en Salud -CUPS) de la prueba diagnóstica confirmatoria actual." /><label>Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsConfirmatoriaActual" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba el CUPS de la prueba diagnóstica confirmatoria que actual" />


                                <label clientidmode="Static" runat="server" id="lblConfirmatoriaPropuesta">Prueba diagnóstica confirmatoria propuesta</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image8"
                                    title="Escriba la nueva prueba diagnóstica confirmatoria propuesta para esta enfermedad huerfana-rara." /><label title="Escriba la nueva prueba diagnóstica confirmatoria propuesta para esta enfermedad huerfana-rara.">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtConformatoriaPropuesta" MaxLength="500" CssClass="form-control" ClientIDMode="Static" title="Escriba la nueva prueba diagnóstica que propone para esta enfermedad huerfana-rara."/>

                                <label clientidmode="Static" runat="server" id="lblCupsConfirmatoriaPropuesta">CUPS de prueba diagnóstica confirmatoria propuesta</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image1n3"
                                    title="Escoja el código CUPS (Clasificación Única de Procedimientos en Salud -CUPS) de la nueva prueba diagnóstica propuesta" /><label title="Escoja el código CUPS (Clasificación Única de Procedimientos en Salud -CUPS) de la nueva prueba diagnóstica propuesta">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsConformatoriaPropuesta" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba el CUPS de la prueba diagnóstica que propone para esta enfermedad huerfana-rara." />

                                 <label clientidmode="Static" runat="server" id="lblPruebaAlterna">Nombre de la prueba diagnóstica alterna</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image22"
                                    title="Escriba la  prueba diagnóstica alterna para esta enfermedad huerfana-rara." /><label title="Escriba la nueva prueba diagnóstica confirmatoria alterna para esta enfermedad huerfana-rara.">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtPruebaAlterna" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba prueba diagnóstica alterna que propone para esta enfermedad huerfana-rara."/>

                                <label clientidmode="Static" runat="server" id="Label16">CUPS de prueba diagnóstica alterna</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image17"
                                    title="Escoja el código CUPS (Clasificación Única de Procedimientos en Salud -CUPS) de la prueba diagnóstica alterna" /><label  title="Escoja el código CUPS (Clasificación Única de Procedimientos en Salud -CUPS) de la prueba diagnóstica alterna">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCUPSPruebaAlterna" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba el código CUPS (Clasificación Única de Procedimientos en Salud -CUPS) de la prueba diagnóstica alterna" />
                            </div>

                            <div id="modificacionEspecialidad">

                                <label for="txtEspActual" clientidmode="Static" runat="server" id="lblEspActual">Especialidad actual</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image9"
                                    title="Escriba la especialidad actual para el diagnóstico de esta enfermedad." /><label title="Escriba la especialidad actual para el diagnóstico de esta enfermedad.">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEspActual" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Especialidad actual para el diagnóstico de esta enfermedad"/>
                                <asp:Button ID="btnAgregarEspActual2" runat="server" Text="Agregar otra Especialidad" OnClick="btnAgregarEspActual2_Click" />


                                <div runat="server" id="divEspActual2" visible="false">
                                    <asp:Button ID="Button1" runat="server" Text="Quitar especialidad" ClientIDMode="Static" OnClick="Quitar2_Click" />
                                    <label for="txtOtrasEspActuales" clientidmode="Static" runat="server" id="lblEspActual2">Especialidad actual</label>
                                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image10"
                                        title="Escriba la especialidad actual  propuesta para el diagnóstico de esta enfermedad." /><label title="Escriba la especialidad actual para el diagnóstico de esta enfermedad.">Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspActual2" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Especialidad actual para el diagnóstico de esta enfermedad"/>
                                    <asp:Button ID="btnAgregarEspActual3" runat="server" Text="Agregar otra EspActual" OnClick="btnAgregarEspActual3_Click" />
                                </div>

                                <div runat="server" id="divEspActual3" visible="false">
                                    <asp:Button ID="Button2" runat="server" Text="Quitar especialidad" ClientIDMode="Static" OnClick="Quitar3_Click" />
                                    <label for="txtOtrasEspActuales" clientidmode="Static" runat="server" id="lblEspActual3">Especialidad actual</label>
                                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image23"
                                        title="Escriba la especialidad actual propuesta para el diagnóstico de esta enfermedad." /><label title="Escriba la especialidad actual para el diagnóstico de esta enfermedad.">Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspActual3" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Especialidad actual para el diagnóstico de esta enfermedad"/>
                                    <asp:Button ID="btnAgregarEspActual4" runat="server" Text="Agregar otra EspActual" OnClick="btnAgregarEspActual4_Click" />
                                </div>
								
								<div runat="server" id="divEspActual4" visible="false">
                                    <asp:Button ID="Button3" runat="server" Text="Quitar especialidad" ClientIDMode="Static" OnClick="Quitar4_Click" />
                                    <label for="txtOtrasEspActuales" clientidmode="Static" runat="server" id="lblEspActual4">Especialidad actual</label>
                                    <label title="Escriba la especialidad actual  propuesta para el diagnóstico de esta enfermedad."><asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image24"
                                        title="Escriba la especialidad actual  propuesta para el diagnóstico de esta enfermedad." />Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspActual4" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Especialidad actual para el diagnóstico de esta enfermedad"/>
                                    <asp:Button ID="btnAgregarEspActual5" runat="server" Text="Agregar otra especialidad" OnClick="btnAgregarEspActual5_Click" />
                                </div>

                                <div runat="server" id="divEspActual5" visible="false">
                                    <asp:Button ID="Button4" runat="server" Text="Quitar especialidad" ClientIDMode="Static" OnClick="Quitar5_Click" />
                                    <label for="txtOtrasEspActuales" clientidmode="Static" runat="server" id="lblEspActual5">Especialidad actual</label>
                                    <label title="Escriba la especialidad actual  propuesta para el diagnóstico de esta enfermedad."><asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image25"
                                        title="Escriba la especialidad actual  propuesta para el diagnóstico de esta enfermedad." />Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspActual5" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Especialidad actual para el diagnóstico de esta enfermedad" />
                                </div>



                                <label for="txtEspecialidadPropuesta" clientidmode="Static" runat="server" id="lblEspecialidadPropuesta">Especialidad propuesta</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image26"
                                    title="Escriba la especialidad que propone para el diagnóstico de esta enfermedad." /><label title="Escriba la especialidad que propone para el diagnóstico de esta enfermedad.">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEspecialidadPropuesta" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba la especialidad que propone para el diagnóstico de esta enfermedad"/>
                                <asp:Button ID="btnAgregarEspPropuesta2" runat="server" Text="Agregar otra Especialidad Propuesta" OnClick="btnAgregarEspPropuesta2_Click" />


                                <div runat="server" id="divEspecialidadPropuesta2" visible="false">
                                    <asp:Button ID="btnQuitarEspPropuesta2" runat="server" Text="btnQuitarEspPropuesta EspecialidadPropuesta" ClientIDMode="Static" OnClick="QuitarEspPropuesta2_Click" />
                                    <label for="txtOtrasEspecialidadPropuestaes" clientidmode="Static" runat="server" id="lblEspecialidadPropuesta2">Especialidad propuesta</label>
                                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image27"
                                        title="Escriba la especialidad que propone para el diagnóstico de esta enfermedad." /><label title="Escriba la especialidad que propone para el diagnóstico de esta enfermedad.">Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspecialidadPropuesta2" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba la especialidad que propone para el diagnóstico de esta enfermedad"/>
                                    <asp:Button ID="btnAgregarEspPropuesta3" runat="server" Text="Agregar otra EspecialidadPropuesta" OnClick="btnAgregarEspPropuesta3_Click" />
                                </div>

                                <div runat="server" id="divEspecialidadPropuesta3" visible="false">
                                    <asp:Button ID="btnQuitarEspPropuesta3" runat="server" Text="btnQuitarEspPropuesta EspecialidadPropuesta" ClientIDMode="Static" OnClick="QuitarEspPropuesta3_Click" />
                                    <label for="txtOtrasEspecialidadPropuestaes" clientidmode="Static" runat="server" id="lblEspecialidadPropuesta3">Especialidad propuesta</label>
                                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image28"
                                        title="Escriba la especialidad que propone para el diagnóstico de esta enfermedad." /><label title="Escriba la especialidad que propone para el diagnóstico de esta enfermedad.">Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspecialidadPropuesta3" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba la especialidad que propone para el diagnóstico de esta enfermedad"/>
                                    <asp:Button ID="btnAgregarEspPropuesta4" runat="server" Text="Agregar otra EspecialidadPropuesta" OnClick="btnAgregarEspPropuesta4_Click" />
                                </div>
								
								<div runat="server" id="divEspecialidadPropuesta4" visible="false">
                                    <asp:Button ID="btnQuitarEspPropuesta4" runat="server" Text="btnQuitarEspPropuesta EspecialidadPropuesta" ClientIDMode="Static" OnClick="QuitarEspPropuesta4_Click" />
                                    <label for="txtOtrasEspecialidadPropuestaes" clientidmode="Static" runat="server" id="lblEspecialidadPropuesta4">Especialidad propuesta</label>
                                    <label title="Escriba la especialidad que propone para el diagnóstico de esta enfermedad."><asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image29"
                                        title="Escriba la especialidad que propone para el diagnóstico de esta enfermedad." />Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspecialidadPropuesta4" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba la especialidad que propone para el diagnóstico de esta enfermedad"/>
                                    <asp:Button ID="btnAgregarEspPropuesta5" runat="server" Text="Agregar otra EspecialidadPropuesta" OnClick="btnAgregarEspPropuesta5_Click" />
                                </div>

                                <div runat="server" id="divEspecialidadPropuesta5" visible="false">
                                    <asp:Button ID="btnQuitarEspPropuesta5" runat="server" Text="btnQuitarEspPropuesta EspecialidadPropuesta" ClientIDMode="Static" OnClick="QuitarEspPropuesta5_Click" />
                                    <label for="txtOtrasEspecialidadPropuestaes" clientidmode="Static" runat="server" id="lblEspecialidadPropuesta5">Especialidad propuesta</label>
                                    <label title="Escriba la especialidad que propone para el diagnóstico de esta enfermedad."><asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image30"
                                        title="Escriba la especialidad que propone para el diagnóstico de esta enfermedad." />Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspecialidadPropuesta5" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Escriba la especialidad que propone para el diagnóstico de esta enfermedad" />
                                </div>

                            </div>



                            <br />

                            <%--Pruebas confirmatorias--%>
                            <div id="Confirmatoria" visible="false">                                
                                <legend id="legConfirmatoria">Información de prueba diagnóstica confirmatoria propuesta para la enfermedad </legend>
                                <label for="txtConfirmatoria1" clientidmode="Static" runat="server" id="lblConfirmatoria">Nombre prueba diagnóstica confirmatoria</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image14"
                                    title="Escriba la prueba diagnostica confirmatoria propuesta para esta enfermedad. " /><label title="Escriba la prueba diagnostica confirmatoria propuesta para esta enfermedad.">Ayuda</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtConfirmatoria1" ClientIDMode="Static" placeholder="Escriba la prueba diagnostica confirmatoria propuesta para esta enfermedad"></asp:TextBox>

                                <label for="txtCups1" clientidmode="Static" runat="server" id="lblCupsConfirmatoria">CUPS prueba diagnóstica confirmatoria</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image5"
                                    title="Escoja el código CUPS (Clasificación Única de Procedimientos en Salud -CUPS) de la prueba diagnóstica confirmatoria propuesta" /><label title="Escoja el código CUPS (Clasificación Única de Procedimientos en Salud -CUPS) de la prueba diagnóstica confirmatoria propuesta. ">Ayuda</label>
                                <asp:TextBox runat="server"  type="text" name="name" ID="txtCups1" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Digite el código CUPS (Clasificación Única de Procedimientos en Salud -CUPS) de la prueba diagnóstica" />

                            </div>



                            <%--Especialidades--%>
                            <br />

                            <div id="Especialidad">
                                <legend id="legEspecialidad">Especialidades propuestas para el análisis diagnóstico  </legend>

                                <p id="pEspecialidad">Ingrese la especialidad o especialidades que deberán participar en el diagnóstico y manejo de está enfermedad huérfana</p>

                                <label for="txtEspecialidad" clientidmode="Static" runat="server" id="lblEspecialidad">Especialidad</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image15"
                                    title="Escriba la especialidad propuesta para el diagnóstico de esta enfermedad." /><label title="Escriba la especialidad propuesta para el diagnóstico de esta enfermedad.">Ayuda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEspecialidad" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Especialidad propuesta para el diagnóstico de esta enfermedad"/>

                                <asp:Button ID="btnAgregar2" runat="server" Text="Agregar otra Especialidad" OnClick="btnAgregar2_Click" />


                                <div runat="server" id="divEspecialidad2" visible="false">
                                    <asp:Button ID="Quitar2" runat="server" Text="Quitar especialidad" ClientIDMode="Static" OnClick="Quitar2_Click" />
                                    <label for="txtOtrasEspecialidades" clientidmode="Static" runat="server" id="lblEspecialidad2">Especialidad</label>
                                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image161"
                                        title="Escriba la especialidad propuesta para el diagnóstico de esta enfermedad." /><label title="Escriba la especialidad propuesta para el diagnóstico de esta enfermedad.">Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspecialidad2" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Especialidad propuesta para el diagnóstico de esta enfermedad"/>
                                    <asp:Button ID="btnAgregar3" runat="server" Text="Agregar otra Especialidad" OnClick="btnAgregar3_Click" />
                                </div>

                                <div runat="server" id="divEspecialidad3" visible="false">
                                    <asp:Button ID="Quitar3" runat="server" Text="Quitar especialidad" ClientIDMode="Static" OnClick="Quitar3_Click" />
                                    <label for="txtOtrasEspecialidades" clientidmode="Static" runat="server" id="lblEspecialidad3">Especialidad</label>
                                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image18"
                                        title="Escriba la especialidad propuesta para el diagnóstico de esta enfermedad." /><label title="Escriba la especialidad propuesta para el diagnóstico de esta enfermedad.">Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspecialidad3" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Especialidad propuesta para el diagnóstico de esta enfermedad"/>
                                    <asp:Button ID="btnAgregar4" runat="server" Text="Agregar otra Especialidad" OnClick="btnAgregar4_Click" />
                                </div>
								
								<div runat="server" id="divEspecialidad4" visible="false">
                                    <asp:Button ID="Quitar4" runat="server" Text="Quitar especialidad" ClientIDMode="Static" OnClick="Quitar4_Click" />
                                    <label for="txtOtrasEspecialidades" clientidmode="Static" runat="server" id="lblEspecialidad4">Especialidad</label>
                                    <label title="Escriba la especialidad propuesta para el diagnóstico de esta enfermedad."><asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image19"
                                        title="Escriba la especialidad propuesta para el diagnóstico de esta enfermedad." />Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspecialidad4" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Especialidad propuesta para el diagnóstico de esta enfermedad"/>
                                    <asp:Button ID="btnAgregar5" runat="server" Text="Agregar otra Especialidad" OnClick="btnAgregar5_Click" />
                                </div>

                                <div runat="server" id="divEspecialidad5" visible="false">
                                    <asp:Button ID="Quitar5" runat="server" Text="Quitar especialidad" ClientIDMode="Static" OnClick="Quitar5_Click" />
                                    <label for="txtOtrasEspecialidades" clientidmode="Static" runat="server" id="lblEspecialidad5">Especialidad</label>
                                    <label title="Escriba la especialidad propuesta para el diagnóstico de esta enfermedad."><asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image20"
                                        title="Escriba la especialidad propuesta para el diagnóstico de esta enfermedad." />Ayuda</label>
                                    <asp:TextBox runat="server" Text="" TextMode="SingleLine" name="name" ID="txtEspecialidad5" MaxLength="500" CssClass="form-control" ClientIDMode="Static" placeholder="Especialidad propuesta para el diagnóstico de esta enfermedad" />
                                </div>


                            </div>


                            <%--Justificacion--%>
                            <label for="txtDescripJustifaca" clientidmode="Static" runat="server" id="lblJustificacion"></label>
                            <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image2"
                                title="Describa las razones de su nominación y justifique lo más completo posible" /><label title="Describa las razones de su nominación y justifique lo más completo posible">Ayuda</label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtDescriptJustifica" TextMode="MultiLine" Height="200px" CssClass="form-control" ClientIDMode="Static" placeholder="Describa las razones de su nominación y la justifique lo más completo posible"/>


                            <%--<fieldset>--%>
                            <br />
                            <legend>Información adicional</legend>
                            <label for="chkConflictoInteresX" clientidmode="Static" runat="server" id="Label24">Adjunta evidencia  </label>
                            <div class="checklistn">

                                <asp:RadioButton GroupName="evidencia" onchange="Ajustarcheck();" ID="chkAdjuntaEvidencia" runat="server"
                                    ClientIDMode="Static" Text="SI" />
                                <asp:RadioButton GroupName="evidencia" onchange="Ajustarcheck();" ID="chkNoAdjuntaEvidencia" runat="server"
                                    ClientIDMode="Static" Text="NO" />
                            </div>
                            <div id="divAdjuntaEvidencia" style="display: none;">
                                <label for="txtEvidencia" clientidmode="Static" runat="server" id="Label13">Usando el <a href="https://www.uahurtado.cl/pdf/Cita_y_Referencia_Bibliogrfica_gua_basada_en_las_normas_APA.pdf#page=20" target="_blank">formato APA</a> relacione y anexe las referencias de evidencia científica que soportan la nominación y realice un breve resumen de la referencia. </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEvidencia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                                <div id="pnlArchivoJuridico1">

                                    <label for="divDocumentoNatural2" clientidmode="Static" runat="server" id="lbltituloArchivoJuridico1">Adjunte Documento de evidencia  </label>
                                    <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image11"
                                        title="Adjunte un archivo de no más de 7 MB, en formato PDF o imagen JPG,JPEG, GIF, o comprimido en caso de ser mas de un archivo" /><label>Ayuda</label>
                                    <label></label>
                                    <asp:Button runat="server" ID="btnArchivo" Text="Subir Archivo" OnClick="btnArchivo_Click" />

                                    <asp:UpdatePanel runat="server" ID="pnlGrillaArchivos" UpdateMode="Conditional">
                                        <ContentTemplate>

                                            <asp:DataList Width="600px" runat="server" ID="grdArchivos">
                                                <ItemTemplate>
                                                    <div class="form-control">
                                                        <asp:HyperLink runat="server" Text='<%# "Archivo cargado:"+Eval("descripcion") %>'
                                                            Target="_blank" NavigateUrl='<%# "~"+Eval("url").ToString().Substring(Eval("url").ToString().IndexOf("\\files\\DocumentosHuerfanas")) %>'></asp:HyperLink>

                                                        <asp:ImageButton
                                                            Visible="<%# btnArchivo.Visible %>"
                                                            Width="10px" runat="server" ID="btnelimnarARchivo" ImageUrl="~/img/web/delete.png" OnClick="btnelimnarARchivo_Click" ValidationGroup='<%# Eval("url") %>' />
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

                                <legend>
                                    <label for="chkConflictoInteresX" clientidmode="Static" runat="server" id="Label25">Declaración de posibles conflictos de intereses </label>
                                </legend>
                            </br>
                            <label for="txtConflicto" clientidmode="Static" runat="server" id="Label10">Objetivo:</label>
                            <p>La presente declaración tiene por objeto garantizar en el ejercicio trasparente de la participación ciudadana, la imparcialidad de los participantes con derecho a voto en el proceso actual, de modo que se conozca el posible o posibles conflictos de intereses y su relación de causalidad frente a las opiniones o recomendaciones que incidirán en la toma de decisiones relacionadas con las políticas en salud.</p>
                            <p>Las actividades que pueden generar conflicto de intereses son aquellas en las que el juicio del profesional en salud o la de un agremiado, agente o actor del sector salud puede estar afectado por un interés primario, que incida en su actividad participativa.</p>



                            <div class="checklistn">
                                <label for="txtConflicto" clientidmode="Static" runat="server" id="Label14">Tiene conflicto de interes:</label>
                                <br />

                                <asp:RadioButton GroupName="conflicto" onchange="Ajustarcheck();" ID="chkConflictoInteres" runat="server"
                                    ClientIDMode="Static" Text="SI" />
                                <asp:RadioButton GroupName="conflicto" onchange="Ajustarcheck();" ID="chkNoConflictoInteres" runat="server"
                                    ClientIDMode="Static" Text="NO" />
                            </div>

                            <div id="divConflicto" style="display: none;">


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

                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtInteresEconomico" Visible="false" TextMode="MultiLine" Width="700px" Height="80px"></asp:TextBox>

                                    <ol>
                                        <strong>Descripción del conflicto de  Interés</strong>

                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtConflicto" TextMode="MultiLine" Width="700px" Height="80px"></asp:TextBox>
                                    </ol>

                                </ul>

                                <div id="pnlArchivoConflicto">

                                    <label clientidmode="Static" runat="server" id="Label9" visible="false">Adjunte documentos del conflicto </label>
                                    <asp:Button runat="server" ID="btnArchivoConflicto" Text="Subir Archivo" OnClick="btnArchivo_Click" Visible="false" />

                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                        <ContentTemplate>

                                            <asp:DataList Width="600px" runat="server" ID="DataList1">
                                                <ItemTemplate>
                                                    <div class="form-control">
                                                        <asp:HyperLink runat="server" Text='<%# "Archivo cargado:"+Eval("descripcion") %>'
                                                            Target="_blank" NavigateUrl='<%# "~"+Eval("url").ToString().Substring(Eval("url").ToString().IndexOf("\\files\\DocumentosHuerfanas")) %>'></asp:HyperLink>

                                                        <asp:ImageButton
                                                            Visible="<%# btnArchivo.Visible %>"
                                                            Width="10px" runat="server" ID="btnelimnarARchivo" ImageUrl="~/img/web/delete.png" OnClick="btnelimnarARchivo_Click" ValidationGroup='<%# Eval("url") %>' />
                                                    </div>
                                                    <div>
                                                    </div>
                                                </ItemTemplate>

                                            </asp:DataList>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
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
                                OnClick="btnGuardarContinuar_Click" Height="60px" />

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

    </div>
    <%--Cierre Div formulario --%>


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
</asp:Content>
