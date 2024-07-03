<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/masterb.Master" AutoEventWireup="true" CodeBehind="frmInscripcionProcesoRups.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmInscripcionProcesoRups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../blueimp/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../blueimp/jquery.iframe-transport.js" type="text/javascript"></script>
    <script src="../../blueimp/jquery.fileupload.js" type="text/javascript"></script>


    <%-- Loading  --%>

    <style type="text/css">
        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }

        .loading {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>



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
        }

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
            $('#FileUpload3').fileupload({
                url: '../../frm/ws/FileUploadHandler.ashx?upload=start&folder=FileUpload3&frm=rups',
                add: function (e, data) {
                    var cnt = 0;
                    var ext = '';
                    $.each(data.files, function (index, file) {
                        cnt = cnt + 1;
                        ext = file.name.substring(file.name.lastIndexOf('.'));
                        if (file.size > 52428800) {
                            alert('El archivo ' + file.name + '  supera el tamaño máximo de 50 Megas.');
                            return;
                        }
                    });

                    if (cnt > 1) {
                        alert('Solo debe seleccionar un archivo');
                        return;
                    }
                    /* if (ext.toUpperCase() != '.PDF') {
                            alert('solo es valido subir archivos en formato pdf.');
                            return; } */
                    //   console.log('add', data);
                    $('#progressbar3').show();
                    data.submit();
                },
                progress: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progressbar3').css('width', progress + '%');
                },
                success: function (response, status) {
                    $('#progressbar3').hide();
                    $('#progressbar3 div').css('width', '0%');

                    if (response.indexOf("Error") >= 0) {
                        alert(response);
                    } else {
                        $("#lnkArchivo3").attr("href", "../../files/" + response);
                        $("#lnkArchivo3").text(response);
                    }
                },

                error: function (error) {
                    alert('error');
                    $('#progressbar3').hide();
                    $('#progressbar3 div').css('width', '0%');
                    console.log('error', error);
                }
            });
        });


        $(function () {
            $('#FileUpload2').fileupload({
                url: '../../frm/ws/FileUploadHandler.ashx?upload=start&folder=FileUpload2&frm=rups',
                add: function (e, data) {
                    var cnt = 0;
                    var ext = '';
                    $.each(data.files, function (index, file) {
                        cnt = cnt + 1;
                        ext = file.name.substring(file.name.lastIndexOf('.'));
                        if (file.size > 52428800) {
                            alert('El archivo ' + file.name + '  supera el tamaño máximo de 50 Megas.');
                            return;
                        }
                    });

                    if (cnt > 1) {
                        alert('Solo debe seleccionar un archivo');
                        return;
                    }
                    /* if (ext.toUpperCase() != '.PDF') {
                            alert('solo es valido subir archivos en formato pdf.');
                            return; } */
                    //   console.log('add', data);
                    $('#progressbar2').show();
                    data.submit();
                },
                progress: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progressbar2').css('width', progress + '%');
                },
                success: function (response, status) {
                    $('#progressbar2').hide();
                    $('#progressbar2 div').css('width', '0%');

                    if (response.indexOf("Error") >= 0) {
                        alert(response);
                    } else {
                        $("#lnkArchivo2").attr("href", "../../files/" + response);
                        $("#lnkArchivo2").text(response);
                    }
                },

                error: function (error) {
                    alert('error');
                    $('#progressbar2').hide();
                    $('#progressbar2 div').css('width', '0%');
                    console.log('error', error);
                }
            });
        });



        $(function () {
            $('#FileUpload1').fileupload({
                url: '../../frm/ws/FileUploadHandler.ashx?upload=start&folder=FileUpload1&frm=rups',
                add: function (e, data) {
                    var cnt = 0;
                    var ext = '';
                    $.each(data.files, function (index, file) {
                        cnt = cnt + 1;
                        ext = file.name.substring(file.name.lastIndexOf('.'));
                        if (file.size > 52428800) {
                            alert('El archivo ' + file.name + '  supera el tamaño máximo de 50 Megas.');
                            return;
                        }
                    });

                    if (cnt > 1) {
                        alert('Solo debe seleccionar un archivo');
                        return;
                    }
                    /* if (ext.toUpperCase() != '.PDF') {
                            alert('solo es valido subir archivos en formato pdf.');
                            return; } */
                    //   console.log('add', data);
                    $('#progressbar1').show();
                    data.submit();
                },
                progress: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progressbar1').css('width', progress + '%');
                },
                success: function (response, status) {
                    $('#progressbar1').hide();
                    $('#progressbar1 div').css('width', '0%');

                    if (response.indexOf("Error") >= 0) {
                        alert(response);
                    } else {
                        $("#lnkArchivo1").attr("href", "../../files/" + response);
                        $("#lnkArchivo1").text(response);
                    }
                },

                error: function (error) {
                    alert('error');
                    $('#progressbar1').hide();
                    $('#progressbar1 div').css('width', '0%');
                    console.log('error', error);
                }
            });
        });


        $(function () {

            $("#txtCupsComparador3").autocomplete({
                select: function (e, ui) { $("#txtCupsComparador3").prop('title', ui.item.label); },
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

            $("#txtCupsComparador2").autocomplete({
                select: function (e, ui) { $("#txtCupsComparador2").prop('title', ui.item.label); },
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

            $("#txtCupsComparador1").autocomplete({
                select: function (e, ui) { $("#txtCupsComparador1").prop('title', ui.item.label); },
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
            $("#txtCupsAjuste3").autocomplete({
                select: function (e, ui) { $("#txtCupsAjuste3").prop('title', ui.item.label); },
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
            $("#txtCupsAjuste2").autocomplete({
                select: function (e, ui) { $("#txtCupsAjuste2").prop('title', ui.item.label); },
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
            $("#txtCupsAjuste").autocomplete({
                select: function (e, ui) { $("#txtCupsAjuste").prop('title', ui.item.label); },
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
            $("#txtRemplaza").autocomplete({
                select: function (e, ui) { $("#txtRemplaza").prop('title', ui.item.label); },
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
            $("#txtRemplaza").autocomplete({
                select: function (e, ui) { $("#txtRemplaza").prop('title', ui.item.label); },
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
            $("#txtRemplaza").autocomplete({
                select: function (e, ui) { $("#txtRemplaza").prop('title', ui.item.label); },
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
            $("#txtCUPSRealizacion").autocomplete({
                select: function (e, ui) { $("#txtCUPSRealizacion").prop('title', ui.item.label); },
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

        function getRootWebSitePath() {
            var _location = document.location.toString();
            var applicationNameIndex = _location.indexOf('/', _location.indexOf('://') + 3);
            var applicationName = _location.substring(0, applicationNameIndex) + '/';
            var webFolderIndex = _location.indexOf('/', _location.indexOf(applicationName) + applicationName.length);
            var webFolderFullPath = _location.substring(0, webFolderIndex);
            alert('grws');
            //return applicationName;
            return webFolderFullPath;
        }

        function UpdateUploadButtonEstudiosEfectividad(s, e) {
            try {
                var text = s.GetText(e.inputIndex);
                var file = text.replace("fakepath", "");
                var fileFin = file.replace("C:", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("\\", "");
                fileFin = fileFin.replace("\\", "");
                var webSite = getRootWebSitePath();
                var str = document.getElementById('lblFile1').textContent;

                var pathRelativo = webSite + "//files//Temporal//1-" + str + fileFin;
                document.getElementById('lblArchivoView1').innerHTML = "Archivo Cargado: " + fileFin;
                document.getElementById('lblArchivoView1').href = pathRelativo;
                //catrgamos un hidden para cargarlo en el load
            } catch (err) { }
        }

        function UpdateUploadButtonEstudiosEficacia(s, e) {
            try {
                var text = s.GetText(e.inputIndex);
                var file = text.replace("fakepath", "");
                var fileFin = file.replace("C:", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("\\", "");
                fileFin = fileFin.replace("\\", "");
                var webSite = getRootWebSitePath();
                var str = document.getElementById('lblFile2').textContent;

                var pathRelativo = webSite + "//files//Temporal//2-" + str + fileFin;
                document.getElementById('lblArchivoView2').innerHTML = "Archivo Cargado: " + fileFin;
                document.getElementById('lblArchivoView2').href = pathRelativo;

            } catch (err) { }
        }

        function UpdateUploadButtonAdicional(s, e) {
            try {
                var text = s.GetText(e.inputIndex);
                var file = text.replace("fakepath", "");
                var fileFin = file.replace("C:", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("//", "");
                fileFin = fileFin.replace("\\", "");
                fileFin = fileFin.replace("\\", "");
                var webSite = getRootWebSitePath();
                var str = document.getElementById('lblFile3').textContent;

                var pathRelativo = webSite + "//files//Temporal//3-" + str + fileFin;
                document.getElementById('lblArchivoView3').innerHTML = "Archivo Cargado: " + fileFin;
                document.getElementById('lblArchivoView3').href = pathRelativo;

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

        function checkTextAreaMaxLength(textBox, e, length) {

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {

                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
                
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
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
            $('#Fieldset1').hide();

        })
        function Ajustarcheck() {
            //si esta chekeado acepto terminos muestra el boton
            var rdNombrePropio = $('#rdNombrePropio').prop('checked');//chkExclusionA
            var rdNombreTercero = $('#rdNombreTercero').prop('checked');//chkExclusionB

            var chkReduccionMortalidad = $('#chkReduccionMortalidad').prop('checked');//chkExclusionA
            var chkReduccionMorbilidad = $('#chkReduccionMorbilidad').prop('checked');//chkExclusionB
            var chkReduccionDiscapacidad = $('#chkReduccionDiscapacidad').prop('checked');//chkExclusionC
            var chkReduccionHospitalaria = $('#chkReduccionHospitalaria').prop('checked');//chkExclusionD
            var chkDisminucionComplicacion = $('#chkDisminucionComplicacion').prop('checked');   //chkExclusionE
            var chkMejoraCalidadVida = $('#chkMejoraCalidadVida').prop('checked');   //chkExclusionF
            var chkVentajaOtro = $('#chkVentajaOtro').prop('checked');   //chkExclusionF
            var chkEfectividadClinicaSi = $('#chkEfectividadClinicaSi').prop('checked');   //chkConflictoInteres
            var chkEficaciaClinicaSi = $('#chkEficaciaClinicaSi').prop('checked');   //chkConflictoInteres
            var chkRiesgosPacienteSi = $('#chkRiesgosPacienteSi').prop('checked');   //chkConflictoInteres
            var rdMedicamentoAdicionalSi = $('#rdMedicamentoAdicionalSi').prop('checked');   //chkConflictoInteres
            var rdDispositivoAdicionalSi = $('#rdDispositivoAdicionalSi').prop('checked');   //chkConflictoInteres
            var rdInVitroAdicionalSi = $('#rdInVitroAdicionalSi').prop('checked');   //chkConflictoInteres
            var rdAgenteBioAdicionalSi = $('#rdAgenteBioAdicionalSi').prop('checked');   //chkConflictoInteres
            var rdproductoBioAdicionalSi = $('#rdproductoBioAdicionalSi').prop('checked');   //chkConflictoInteres
            var rdAdicionalOtroSi = $('#rdAdicionalOtroSi').prop('checked');   //chkConflictoInteres
            var rdRemplaza = $('#rdRemplazaSI').prop('checked');
            var rdRiesgo = $('#rdRiesgoSI').prop('checked');
            var rdINVIMA1 = $('#rdINVIMA1SI').prop('checked');
            var rdINVIMA2 = $('#rdINVIMA2SI').prop('checked');
            var rdINVIMA3 = $('#rdINVIMA3SI').prop('checked');
            var rdEnTerritorio = $('#rdEnTerritorioSI').prop('checked');
            var rdRealizadoTerritorio = $('#rdRealizadoTerritorioSI').prop('checked');
            var rdOtrosSistemasCodificacion = $('#rdOtrosSistemasCodificacionSI').prop('checked');


            var rdTerceroJuridico = $('#rdTerceroJuridico').prop('checked');

            var chkConflictoInteres = $('#chkConflictoInteres').prop('checked');   //chkConflictoInteres
            var chkAdjuntaEvidencia = $('#chkAdjuntaEvidenciaSi').prop('checked');   //chkAdjuntaEvidencia
            var rdAvala = $('#rdAvalaNo').prop('checked');   //chkAdjuntaEvidencia

            var nuevo = $('#cmbCupsCalificacion')



            if (rdTerceroJuridico == true) {
                $('#divTipJugTercero').show();
            } else {
                $('#divTipJugTercero').hide();
            }


            if (rdRemplaza == true) {
                $('#divRemplaza').show();
            } else {
                $('#divRemplaza').hide();
            }

            if (rdINVIMA1 == true) {
                $('#divINVIMA1').show();
            } else {
                $('#divINVIMA1').hide();
            }
            if (rdINVIMA2 == true) {
                $('#divINVIMA2').show();
            } else {
                $('#divINVIMA2').hide();
            }
            if (rdINVIMA3 == true) {
                $('#divINVIMA3').show();
            } else {
                $('#divINVIMA3').hide();
            }

            if (rdEnTerritorio == true) {
                $('#divEnTerritorio').show();
            } else {
                $('#divEnTerritorio').hide();
            }

            if (rdRealizadoTerritorio == true) {
                $('#divRealizadoTerritorio').show();
            } else {
                $('#divRealizadoTerritorio').hide();
            }

            if (rdOtrosSistemasCodificacion == true) {
                $('#divOtrosSistemasCodificacion').show();
            } else {
                $('#divOtrosSistemasCodificacion').hide();
            }


            if (rdRiesgo == true) {
                $('#divRiesgos').show();
            } else {
                $('#divRiesgos').hide();
            }


            if (rdNombrePropio == true) {
                $('#divNombreTercero').hide();
                //$('#divNombrePropio').show();
            } else {
                if (rdNombreTercero == true) {
                    $('#divNombreTercero').show();
                }
                //$('#divNombrePropio').hide();
            }


            if (chkReduccionMortalidad == true) {
                $('#divReduccionMortalidad').show();
            } else {
                $('#divReduccionMortalidad').hide();
            }

            if (chkReduccionMorbilidad == true) {
                $('#divReduccionMorbilidad').show();
            } else {
                $('#divReduccionMorbilidad').hide();
            }
            if (chkReduccionDiscapacidad == true) {
                $('#divReduccionDiscapacidad').show();
            } else {
                $('#divReduccionDiscapacidad').hide();
            }
            if (chkReduccionHospitalaria == true) {
                $('#divReduccionHospitalaria').show();
            } else {
                $('#divReduccionHospitalaria').hide();
            }
            if (chkDisminucionComplicacion == true) {
                $('#divDisminucionComplicacion').show();
            } else {
                $('#divDisminucionComplicacion').hide();
            }

            if (chkMejoraCalidadVida == true) {
                $('#divMejoraCalidadVida').show();
            } else {
                $('#divMejoraCalidadVida').hide();
            }

            if (chkVentajaOtro == true) {
                $('#divVentajaOtro').show();
            } else {
                $('#divVentajaOtro').hide();
            }

            if (chkEfectividadClinicaSi == true) {
                $('#divEfectividadClinica').show();
            } else {
                $('#divEfectividadClinica').hide();
            }

            if (chkEficaciaClinicaSi == true) {
                $('#divEficaciaClinica').show();
            } else {
                $('#divEficaciaClinica').hide();
            }

            if (chkRiesgosPacienteSi == true) {
                $('#divcRiesgosPaciente').show();
            } else {
                $('#divcRiesgosPaciente').hide();
            }

            if (rdMedicamentoAdicionalSi == true) {
                $('#divMedicamentoAdicional').show();
            } else {
                $('#divMedicamentoAdicional').hide();
            }

            if (rdDispositivoAdicionalSi == true) {
                $('#divDispositivoAdicional').show();
            } else {
                $('#divDispositivoAdicional').hide();
            }
            if (rdInVitroAdicionalSi == true) {
                $('#divInvitroAdicional').show();
            } else {
                $('#divInvitroAdicional').hide();
            }

            if (rdAgenteBioAdicionalSi == true) {
                $('#divBioAdicional').show();
            } else {
                $('#divBioAdicional').hide();
            }
            if (rdproductoBioAdicionalSi == true) {
                $('#divBioProAdicional').show();
            } else {
                $('#divBioProAdicional').hide();
            }
            if (rdAdicionalOtroSi == true) {
                $('#divcAdicionalOtro').show();
            } else {
                $('#divcAdicionalOtro').hide();
            }


            if (chkAdjuntaEvidencia == true) {
                $('#divAdjuntaEvidencia').show();
            } else {
                $('#divAdjuntaEvidencia').hide();
            }
            if (rdAvala == true) {
                $('#divAvala').show();
            } else {
                $('#divAvala').hide();
            }

            if (chkConflictoInteres == true) {
                $('#divConflicto').show();
            } else {
                $('#divConflicto').hide();
            }
        }
    </script>

    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 20000);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });

        function ValidarGuardar() {
            var respuesta = confirm('Esta seguro de enviar el formulario una vez enviado no podra realizar ningun ajuste');
            if (respuesta == true) {
                var mywait = document.getElementById('mywaitmsg');
                mywait.style.display = 'block';

                var btnGuardarContinuar = document.getElementById('btnGuardarContinuar');
                btnGuardarContinuar.style.display = 'none';
            }

            return respuesta;
        }


    </script>

    <style>
        .textoValidacion {
            border-color: #7777FF !important;
            border-style: solid !important;
            border-width: 1px !important;
        }

        .divLine {
            display: flex;
            flex-direction: row;
            justify-content: left;
            align-items: center;
        }

            .divLine span {
                display: flex;
                flex-direction: row;
                width: 100%;
            }

                .divLine span input {
                    width: 30%;
                }

            .divLine input {
                width: 30%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label runat="server" ID="lblCodNominacionProceso" ClientIDMode="Static" Style="display: none;"></asp:Label>
    <asp:Panel ID="pnlMensajeNoNominador" runat="server">
        <div class="row">
            <div class="tagline">
                <div class="container">
                    <h2 class="tag">Por la plataforma sólo nominan las agremiaciones y asociaciones científicas</h2>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_REPRESENTADO], [TIPO_REPRESENTADO] FROM [TIPO_REPRESENTADO]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_IPS], [TIPO_IPS] FROM [TIPO_IPS]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_JURIDICO], [NOMBRE_TIPO_JURIDICO] FROM [TIPO_JURIDICO] WHERE PADRE is null"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlFormulario" runat="server">
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

                    <p class="centerp">
                        <b>Registro Único de Procedimientos en Salud - RUPS<br />
                            Actualización de la Clasificación Única de Procedimientos en Salud </b>
                    </p>

                    <p class="centerp">DIRECCIÓN DE REGULACIÓN DE BENEFICIOS, COSTOS Y TARIFAS DEL ASEGURAMIENTO EN SALUD</p>
                </div>
                <div class="row">

                    <div class="col-md-8 col-md-offset-2">
                        <div class="row">
                            <div class="divLine">
                                <asp:RadioButton ID="rdNombrePropio" GroupName="nombrePropio" Text="En nombre propio" runat="server" ClientIDMode="Static" onchange="Ajustarcheck();" />
                            </div>
                            <div class="divLine">
                                <asp:RadioButton ID="rdNombreTercero" GroupName="nombrePropio" Text="En nombre de tercero" runat="server" ClientIDMode="Static" onchange="Ajustarcheck();" />
                            </div>
                        </div>


                        <hr runat="server" id="pnlNombrePropio" style="height: 1px;"></hr>
                        <asp:Panel runat="server" ID="pnlNominador" Visible="false"></asp:Panel>
                        <div id="divNombreTercero" style="display: none;">
                            <fieldset runat="server" id="Fieldsetentidad" class="form-group">
                                <legend>Información del proponente</legend>

                                <div class="row">
                                    <div class="divLine">
                                        <asp:RadioButton ID="rdTerceroNatural" GroupName="tjt" Text="Persona Natural" runat="server" ClientIDMode="Static" onchange="Ajustarcheck();" />
                                    </div>
                                    <div class="divLine">
                                        <asp:RadioButton ID="rdTerceroJuridico" GroupName="tjt" Text="Persona jurídica" runat="server" ClientIDMode="Static" onchange="Ajustarcheck();" />
                                    </div>
                                </div>

                                <div id="divTipJugTercero" style="display: none;">
                                    <label for="cmbTipoActorNomina" clientidmode="Static" runat="server" id="Label30">Tipo de actor que nomina</label>
                                    <asp:DropDownList runat="server" type="text" name="name" ID="cmbTipoActorNomina" CssClass="form-control" DataSourceID="SqlDataSourceTipoNominador" DataTextField="NOMBRE_TIPO_JURIDICO" DataValueField="COD_TIPO_JURIDICO" />
                                    <asp:SqlDataSource ID="SqlDataSourceTipoNominador" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT * FROM [TIPO_JURIDICO] WHERE ([NOMBRE_TIPO_JURIDICO] NOT LIKE '%' + @NOMBRE_TIPO_JURIDICO + '%') ORDER BY [NOMBRE_TIPO_JURIDICO]">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="otr" Name="NOMBRE_TIPO_JURIDICO" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>

                                <label for="txtNombreNominadortercero" clientidmode="Static" runat="server" id="Label32">Nombre persona natural  o de la entidad nominadora, según corresponda</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNombreNominadortercero" MaxLength="300" CssClass="form-control" />

                                <label for="txtNitTercero" clientidmode="Static" runat="server" id="Label31">Documento de identificación del nominador</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNitTercero" MaxLength="300" CssClass="form-control" />

                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionValidador">
                                    <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label18">Observaciones validación </label>
                                    <asp:TextBox runat="server" BorderColor="Red" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionValidador" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                            </fieldset>
                        </div>

                        <div id="divNombrePropio">
                            <fieldset runat="server" id="Fieldset2" class="form-group">
                                <legend><span>
                                    <label runat="server" clientidmode="Static" id="Label27">Información del nominador </label>
                                </span></legend>

                                <label for="txtTipoAator" clientidmode="Static" runat="server" id="Label41">Agremiación de profesionales de la salud o sociedad científica a través de la cual se nomina </label>
                                <asp:TextBox runat="server" ReadOnly="true" Text="" type="text" name="name" ID="txtTipoAator" MaxLength="100" CssClass="form-control" />

                                <label for="txtIdentificacionNominador" clientidmode="Static" runat="server" id="Label42">Número de identificación </label>
                                <asp:TextBox runat="server" Text="" ReadOnly="true" type="text" name="name" ID="txtIdentificacionNominador" MaxLength="100" CssClass="form-control" />

                                <label for="txtNombreNominador" clientidmode="Static" runat="server" id="Label34">Nombre </label>
                                <asp:TextBox runat="server" Text="" ReadOnly="true" type="text" name="name" ID="txtNombreNominador" MaxLength="100" CssClass="form-control" />



                            </fieldset>
                        </div>

                        <fieldset>
                            <legend>
                                <span>
                                    <label runat="server" clientidmode="Static" id="Label116">Propuesta de Ajuste</label>
                                </span>
                            </legend>

                            <label for="txtCupsCalificacion" clientidmode="Static" runat="server" id="Label53">Tipo de ajuste </label>
                            <asp:DropDownList runat="server" TabIndex="2" ID="cmbCupsCalificacion" Width="100%" CssClass="form-control"
                                ClientIDMode="Static" OnSelectedIndexChanged="cmbCupsCalificacion_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Incluir Procedimiento NUEVO" Value="Incluir Procedimiento NUEVO"></asp:ListItem>
                                <asp:ListItem Text="Modificar la DESCRIPCIÓN" Value="Modificar la DESCRIPCIÓN"></asp:ListItem>
                                <asp:ListItem Text="REUBICAR Procedimiento" Value="REUBICAR Procedimiento"></asp:ListItem>
                                <asp:ListItem Text="Eliminar por estar CONTENIDO en otro(s) procedimiento(s)" Value="Eliminar por estar CONTENIDO en otro(s) procedimiento(s)"></asp:ListItem>
                                <asp:ListItem Text="DESAGREGAR un procedimiento" Value="DESAGREGAR un procedimiento"></asp:ListItem>
                                <asp:ListItem Text="ELIMINAR porque se AGRUPAN en otro procedimiento" Value="ELIMINAR porque se AGRUPAN en otro procedimiento"></asp:ListItem>
                                <asp:ListItem Text="MONITOREAR por OBSOLESCENCIA" Value="MONITOREAR por OBSOLESCENCIA"></asp:ListItem>
                            </asp:DropDownList>

                        </fieldset>

                        <fieldset runat="server" id="fldProcedimientoNuevo" class="form-group">

                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label118">¿El procedimiento está en fase de experimentación?</label>
                            <div id="Div1" style="color: red">
                                <h3>Recuerde que los procedimientos en fase de experimentación no pueden ser nominados para la actualización de la CUPS</h3>
                            </div>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="experimentacion" onchange="Ajustarcheck();" ID="rdExperimentacionSI" runat="server" OnCheckedChanged="rdExperimentacion_CheckedChanged" AutoPostBack="true" ClientIDMode="Static" Text="SI" Enabled="false" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="experimentacion" onchange="Ajustarcheck();" ID="rdExperimentacionNO" runat="server" OnCheckedChanged="rdExperimentacion_CheckedChanged" AutoPostBack="true" ClientIDMode="Static" Text="NO" Enabled="false" Checked="true" />
                                </div>
                            </div>
                        </fieldset>

                        <div id="msjExperimentacion" runat="server" style="color: red">
                            <h2>Recuerde que los procedimientos en fase de experimentación no pueden ser nominados para la actualización de la CUPS</h2>
                        </div>


                        <fieldset runat="server" id="fldOtrasNominaciones" class="form-group">

                            <label for="txtCupsAjuste" clientidmode="Static" runat="server" id="Label48">Este campo es autocompletable digite el PROCEDIMIENTO de la CUPS a modificar, reubicar, agrupar, etc.  </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsAjuste" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <label for="txtCupsAjuste2" clientidmode="Static" runat="server" id="Label49">Este campo es autocompletable digite el PROCEDIMIENTO de la CUPS a modificar, reubicar, agrupar, etc.  </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsAjuste2" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />


                            <label for="txtCupsAjuste3" clientidmode="Static" runat="server" id="Label50">Este campo es autocompletable digite el PROCEDIMIENTO de la CUPS a modificar, reubicar, agrupar, etc.  </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsAjuste3" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                        </fieldset>

                        <label for="txtCupsAjusteEstructura" clientidmode="Static" runat="server" id="Label51">Estructura en la CUPS del ajuste  </label>
                        <asp:DropDownList runat="server" TabIndex="2" ID="cmbCupsAjusteEstructura" Width="100%" CssClass="form-control"
                            ClientIDMode="Static">
                            <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Grupo" Value="Grupo"></asp:ListItem>
                            <asp:ListItem Text="Subgrupo" Value="Subgrupo"></asp:ListItem>
                            <asp:ListItem Text="Categoría" Value="Categoría"></asp:ListItem>
                            <asp:ListItem Text="Subcategoría" Value="Subcategoría"></asp:ListItem>
                        </asp:DropDownList>

                        <fieldset runat="server" id="fldOtrasNominaciones2" class="form-group">
                            <label for="txtCupsComparador1" clientidmode="Static" runat="server" id="Label52">Este campo es autocompletable digite el PROCEDIMIENTO de la CUPS comparador o sustituto  </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsComparador1" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <label for="txtCupsComparador2" clientidmode="Static" runat="server" id="Label54">Este campo es autocompletable digite el PROCEDIMIENTO de la CUPS comparador o sustituto  </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsComparador2" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <label for="txtCupsComparador3" clientidmode="Static" runat="server" id="Label55">Este campo es autocompletable digite el PROCEDIMIENTO de la CUPS comparador o sustituto  </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsComparador3" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                        </fieldset>


                        <fieldset id="fldCups" runat="server">

                            <label for="txtCupsPopuestoCod" clientidmode="Static" runat="server" id="Label56">Código propuesto para CUPS  </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsPopuestoCod" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <label for="txtCupsPopuestoDes" clientidmode="Static" runat="server" id="Label57">Descripción propuesto para CUPS  </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCupsPopuestoDes" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionPropuestaAjuste">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label38">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionPropuestaAjuste" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>

                        </fieldset>


                        <fieldset id="fldJustificacionNuevo" runat="server">

                            <label for="txtJustificacionNominacion" clientidmode="Static" runat="server" id="Label7">Justificación de la nominación  </label>
                            <asp:TextBox runat="server" Text="" TextMode="MultiLine" type="text" name="name" ID="txtJustificacionNuevo" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <asp:Panel runat="server" Visible="false" ID="Panel1">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label121">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="TextBox2" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>
                        </fieldset>

                        <fieldset runat="server" id="fldCarcteristicasNuevo">
                            <legend>Características del procedimiento propuesto</legend>

                            <label for="txtEnfermedad3" clientidmode="Static" runat="server" id="Label119">Descripción detallada del procedimiento (qué es, en qué consiste, cómo se ejecuta, grupo - servicio - modalidad) </label>
                            <asp:TextBox runat="server" Text="" TextMode="MultiLine" type="text" name="name" ID="txtDescProcNuevo" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <label for="txtEnfermedad3" clientidmode="Static" runat="server" id="Label120">De acuerdo con el criterio del nominador, describir la formación académica requerida para la ejecución del procedimiento</label>
                            <asp:TextBox runat="server" Text="" TextMode="MultiLine" type="text" name="name" ID="txtDecCriterioNuevo" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />
                        </fieldset>

                        <fieldset runat="server" clientidmode="Static" id="fldFinalidadProcedimiento">
                            <legend><span>Finalidad del procedimiento</span></legend>
                            <div class="row">
                                <div class="divLine">
                                    <asp:CheckBox ID="chkPromocionSalud" runat="server" ClientIDMode="Static" Text="Promoción de la salud" />
                                </div>
                                <div class="divLine">
                                    <asp:CheckBox ID="chkPrevencionEnfermedad" runat="server" ClientIDMode="Static" Text="Prevención de la enfermedad" />
                                </div>
                                <div class="divLine">
                                    <asp:CheckBox ID="chkDiagnostico" runat="server" ClientIDMode="Static" Text="Diagnostico" />
                                </div>
                                <div class="divLine">
                                    <asp:CheckBox ID="chkTratamiento" runat="server" ClientIDMode="Static" Text="Tratamiento" />
                                </div>
                                <div class="divLine">
                                    <asp:CheckBox ID="chkRehabilitacion" runat="server" ClientIDMode="Static" Text="Rehabilitación" />
                                </div>
                                <div class="divLine">
                                    <asp:CheckBox ID="chkPaliacion" runat="server" ClientIDMode="Static" Text="Paliación" />
                                </div>
                                <div class="divLine">
                                    <asp:CheckBox ID="chkcosmetico" runat="server" ClientIDMode="Static" Text="Cosmético o suntuario" />
                                </div>
                            </div>

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionFinalidadProcedimiento">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label37">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionFinalidadProcedimiento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>

                        </fieldset>




                        <fieldset runat="server" id="Fieldset1" class="form-group">
                            <legend><span>
                                <label runat="server" clientidmode="Static" id="lblenumeracionNatural">Información del procedimiento propuesto</label></span></legend>
                            <p>Ingrese la información requerida. </p>

                            <%-- <label for="txtNombreProcedimiento" clientidmode="Static" runat="server" id="Label7">Nombre del procedimiento propuesto</label>
                                <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="imgTooltip"
                                    class="tooltip" title="Se debe escribir el nombre del procedimiento." />
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNombreProcedimiento" MaxLength="300" CssClass="form-control" />--%>

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionNombreProcedimiento">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label20">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionNombreProcedimiento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>

                        </fieldset>


                        <fieldset runat="server" id="fldTipoProcedimiento">

                            <label for="cmbTipoProcedimiento" clientidmode="Static" runat="server" id="Label43">Tipo de procedimiento</label>
                            <asp:DropDownList runat="server" name="name" ID="cmbTipoProcedimiento" CssClass="form-control" DataSourceID="SqlDataSourceTipoProcedimiento" DataTextField="NOMBRE_TIPO_PROCEDIMIENTO" DataValueField="COD_TIPO_PROCEDIMIENTO">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceTipoProcedimiento" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_PROCEDIMIENTO], [NOMBRE_TIPO_PROCEDIMIENTO] FROM [TIPO_PROCEDIMIENTO] ORDER BY [NOMBRE_TIPO_PROCEDIMIENTO]"></asp:SqlDataSource>

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionTipoProcedimiento">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label22">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionTipoProcedimiento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>


                            <label for="cmbAmbitoUso" clientidmode="Static" runat="server" id="Label44">Ámbito de uso del procedimiento</label>
                            <asp:DropDownList runat="server" name="name" ID="cmbAmbitoUso" CssClass="form-control" DataSourceID="SqlDataSourceAmbito" DataTextField="TEXTO_AMBITO_PROCEDIMIENTO" DataValueField="COD_AMBITO_PROCEDIMIENTO">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceAmbito" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_AMBITO_PROCEDIMIENTO], [TEXTO_AMBITO_PROCEDIMIENTO] FROM [AMBITO_PROCEDIMIENTO] ORDER BY [TEXTO_AMBITO_PROCEDIMIENTO]"></asp:SqlDataSource>

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionAmbitoUso">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label26">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionAmbitoUso" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>

                        </fieldset>


                        <fieldset runat="server" id="fldDescripcion">
                            <label for="txtDesccripcionDetallada" clientidmode="Static" runat="server" id="Label45">Descripción detallada del procedimiento</label>
                            <asp:TextBox runat="server" Text="" type="text" TextMode="MultiLine" Height="50px" name="name" ID="txtDesccripcionDetallada" MaxLength="3000" CssClass="form-control" />
                        </fieldset>

                        <fieldset runat="server" id="fldCIE">

                            <label for="txtEnfermedad" clientidmode="Static" runat="server" id="Label9">Este campo es autocompletable digite el CIE-10 (patología o condición de salud para la cual está indicada la tecnología) </label>
                            <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image1"
                                class="tooltip" title="Ingrese el nombre la enfermedad o si conoce el CIE-10 relaciónelo " />
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEnfermedad" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <label for="txtEnfermedad2" clientidmode="Static" runat="server" id="Label14">Este campo es autocompletable digite el CIE-10 (patología o condición de salud para la cual está indicada la tecnología) </label>
                            <asp:Image Width="20px" runat="server" ImageUrl="~/img/web/help.gif" ID="Image2" class="tooltip" title="Ingrese el nombre la enfermedad o si conoce el CIE-10 relaciónelo " />
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEnfermedad2" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <label for="txtEnfermedad3" clientidmode="Static" runat="server" id="Label15">Este campo es autocompletable digite el CIE-10 (patología o condición de salud para la cual está indicada la tecnología)  </label>
                            <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtEnfermedad3" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionCie10">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label33">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionCie10" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>

                        </fieldset>


                        <fieldset runat="server" id="fldDescripcionNuevo">
                            <label for="txtDesGrupoPoblacionalNuevo" clientidmode="Static" runat="server" id="Label122">Describir el grupo poblacional y las condiciones clínicas o indicaciones del procedimiento.</label>
                            <asp:TextBox runat="server" Text="" type="text" TextMode="MultiLine" Height="50px" name="name" ID="txtDesGrupoPoblacionalNuevo" MaxLength="3000" CssClass="form-control" />

                            <label for="txtNumeroPacientes" clientidmode="Static" runat="server" id="Label123">Estimación del número de pacientes que se beneficiaran con el procedimiento.</label>
                            <asp:TextBox runat="server" Text="  " type="number" name="name" ID="txtNumeroPacientes" MaxLength="10" CssClass="form-control" />


                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label124">¿Este procedimiento remplaza alguno de los procedimientos descritos en la CUPS vigente?</label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="remplaza" onchange="Ajustarcheck();" ID="rdRemplazaSI" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="remplaza" onchange="Ajustarcheck();" ID="rdRemplazaNO" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>


                            <div id="divRemplaza" style="display: none;">
                                <label for="txtRemplaza" clientidmode="Static" runat="server" id="Label125">¿Cuál procedimiento remplaza?</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtRemplaza" CssClass="form-control" ClientIDMode="Static" />
                            </div>
                            <br />

                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label126">¿El procedimiento tiene riesgos y efectos adversos u otras complicaciones para el paciente?</label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="riesgo" onchange="Ajustarcheck();" ID="rdRiesgoSI" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="riesgo" onchange="Ajustarcheck();" ID="rdRiesgoNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>


                            <div id="divRiesgos" style="display: none;">
                                <label for="txtRiesgo" clientidmode="Static" runat="server" id="Label127">Describa las principales complicaciones del procedimiento  </label>
                                <asp:TextBox runat="server" Text="" TextMode="MultiLine" Height="50px" type="text" name="name" ID="txtRiesgo" CssClass="form-control" />
                            </div>
                            <br />
                            <label for="txtResultados" clientidmode="Static" runat="server" id="Label128">Describa los principales resultados y ventajas clínicas con el uso del procedimiento.</label>
                            <asp:TextBox runat="server" Text="" type="text" TextMode="MultiLine" Height="50px" name="name" ID="txtResultados" MaxLength="3000" CssClass="form-control" />

                            <label for="txtOtrasIntervenciones" clientidmode="Static" runat="server" id="Label129">¿Qué otras intervenciones/acciones de rutina se realizan durante el procedimiento? Por ejemplo; requiere alguna pre o post medicación.</label>
                            <asp:TextBox runat="server" Text="" type="text" TextMode="MultiLine" Height="50px" name="name" ID="txtOtrasIntervenciones" MaxLength="3000" CssClass="form-control" />

                            <label for="txtTecnologiasEjecucion" clientidmode="Static" runat="server" id="Label130">Describir la(s) tecnología(s) requerida(s) para la ejecución del procedimiento.</label>
                            <asp:TextBox runat="server" Text="" type="text" TextMode="MultiLine" Height="50px" name="name" ID="txtTecnologiasEjecucion" MaxLength="3000" CssClass="form-control" />
                            <p>
                                <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label151">Si el procedimiento requiere el uso de un dispositivo médico o un medicamento, marque esta casilla</label>
                                <asp:CheckBox ID="chkDispositivoMedicamento" runat="server" ClientIDMode="Static" Text="" OnCheckedChanged="chkDispositivoMedicamento_CheckedChanged" AutoPostBack="true" />
                                <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label152">Puede indicar hasta 3 dispositivos o medicamentos, si se requieren más se pueden relacionar en el item de información adicional.</label>
                            </p>

                        </fieldset>

                        <fieldset id="fldINVIMA" runat="server">

                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label131">Dispositivo médico o un medicamento 1: ¿Este cuenta con el Registro sanitario INVIMA vigente?</label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="INVIMA1" onchange="Ajustarcheck();" ID="rdINVIMA1SI" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="INVIMA1" onchange="Ajustarcheck();" ID="rdINVIMA1NO" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>


                            <div id="divINVIMA1" style="display: none;">
                                <label for="txtDesccripcionDetallada" clientidmode="Static" runat="server" id="Label132">Nombre del recurso adicional que requiere el procedimiento</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtINVIMA1" CssClass="form-control" ClientIDMode="Static" />

                                <label for="txtDesccripcionDetallada" clientidmode="Static" runat="server" id="Label133">No. del Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNumINVIMA1" CssClass="form-control" ClientIDMode="Static" />

                                <label for="txtCupsAjusteEstructura" clientidmode="Static" runat="server" id="Label134">Estado Registro Sanitario Invima</label>
                                <asp:DropDownList runat="server" TabIndex="2" ID="cmbEstadoINVIMA1" Width="100%" CssClass="form-control"
                                    ClientIDMode="Static">
                                    <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="VIGENTE" Value="VIGENTE"></asp:ListItem>
                                    <asp:ListItem Text="NO VIGENTE" Value="NO VIGENTE"></asp:ListItem>
                                    <asp:ListItem Text="EN PROCESO DE RENOVACIÓN" Value="EN PROCESO DE RENOVACIÓN"></asp:ListItem>
                                    <asp:ListItem Text="ES NUEVO Y NO CUENTA AUN CON REGISTRO " Value="ES NUEVO Y NO CUENTA AUN CON REGISTRO "></asp:ListItem>
                                </asp:DropDownList>


                            </div>

                            <br />
                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label135">Dispositivo médico o un medicamento 2: ¿Este cuenta con el Registro sanitario INVIMA vigente?</label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="INVIMA2" onchange="Ajustarcheck();" ID="rdINVIMA2SI" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="INVIMA2" onchange="Ajustarcheck();" ID="rdINVIMA2NO" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>


                            <div id="divINVIMA2" style="display: none;">
                                <label for="txtDesccripcionDetallada" clientidmode="Static" runat="server" id="Label136">Nombre del recurso adicional que requiere el procedimiento</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtINVIMA2" CssClass="form-control" ClientIDMode="Static" />

                                <label for="txtDesccripcionDetallada" clientidmode="Static" runat="server" id="Label137">No. del Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNumINVIMA2" CssClass="form-control" ClientIDMode="Static" />

                                <label for="txtCupsAjusteEstructura" clientidmode="Static" runat="server" id="Label138">Estado Registro Sanitario Invima</label>
                                <asp:DropDownList runat="server" TabIndex="2" ID="cmbEstadoINVIMA2" Width="100%" CssClass="form-control"
                                    ClientIDMode="Static">
                                    <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="VIGENTE" Value="VIGENTE"></asp:ListItem>
                                    <asp:ListItem Text="NO VIGENTE" Value="NO VIGENTE"></asp:ListItem>
                                    <asp:ListItem Text="EN PROCESO DE RENOVACIÓN" Value="EN PROCESO DE RENOVACIÓN"></asp:ListItem>
                                    <asp:ListItem Text="ES NUEVO Y NO CUENTA AUN CON REGISTRO " Value="ES NUEVO Y NO CUENTA AUN CON REGISTRO "></asp:ListItem>
                                </asp:DropDownList>


                            </div>
                            <br />
                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label139">Dispositivo médico o un medicamento 3: ¿Este cuenta con el Registro sanitario INVIMA vigente?</label>

                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="INVIMA3" onchange="Ajustarcheck();" ID="rdINVIMA3SI" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="INVIMA3" onchange="Ajustarcheck();" ID="rdINVIMA3NO" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>

                            <div id="divINVIMA3" style="display: none;">
                                <label for="txtINVIMA3" clientidmode="Static" runat="server" id="Label140">Nombre del recurso adicional que requiere el procedimiento</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtINVIMA3" CssClass="form-control" ClientIDMode="Static" />

                                <label for="txtNumINVIMA3" clientidmode="Static" runat="server" id="Label141">No. del Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtNumINVIMA3" CssClass="form-control" ClientIDMode="Static" />

                                <label for="cmbEstadoINVIMA3" clientidmode="Static" runat="server" id="Label142">Estado Registro Sanitario Invima</label>
                                <asp:DropDownList runat="server" TabIndex="2" ID="cmbEstadoINVIMA3" Width="100%" CssClass="form-control"
                                    ClientIDMode="Static">
                                    <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="VIGENTE" Value="VIGENTE"></asp:ListItem>
                                    <asp:ListItem Text="NO VIGENTE" Value="NO VIGENTE"></asp:ListItem>
                                    <asp:ListItem Text="EN PROCESO DE RENOVACIÓN" Value="EN PROCESO DE RENOVACIÓN"></asp:ListItem>
                                    <asp:ListItem Text="ES NUEVO Y NO CUENTA AUN CON REGISTRO " Value="ES NUEVO Y NO CUENTA AUN CON REGISTRO "></asp:ListItem>
                                </asp:DropDownList>
                            </div>


                        </fieldset>


                        <fieldset id="fldJustificacion" runat="server">

                            <label for="txtJustificacionNominacion" clientidmode="Static" runat="server" id="Label2">Justificación de la nominación  </label>
                            <asp:TextBox runat="server" Text="" TextMode="MultiLine" type="text" name="name" ID="txtJustificacionNominacion" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionJustificacion">
                                <label for="txtValidacionJustificacion" clientidmode="Static" runat="server" id="Label16">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionJustificacion" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>

                        </fieldset>


                        <fieldset runat="server" id="fldVEntajas" clientidmode="Static">
                            <label for="cmbProcedimientoNacional" clientidmode="Static" runat="server" id="Label8">¿Se realiza este procedimiento en el territorio nacional actualmente?  </label>
                            <asp:DropDownList runat="server" type="text" name="name" ID="cmbProcedimientoNacional" CssClass="form-control" ClientIDMode="Static">
                                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:DropDownList>

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionTerritorioNacional">
                                <label for="txtValidacionTerritorioNacional" clientidmode="Static" runat="server" id="Label28">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionTerritorioNacional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>
                            <br />

                            <legend><span>Características del procedimiento propuesto</span></legend>
                            <br />
                            <legend>Resultados y ventajas clínicas con el uso del procedimiento</legend>
                            <br />
                            <asp:CheckBox onchange="Ajustarcheck();" ID="chkReduccionMortalidad" runat="server" ClientIDMode="Static" Text="Reducción de mortalidad" />
                            <br />
                            <div id="divReduccionMortalidad" style="display: none;">
                                <label for="txtReduccionMortalidad" clientidmode="Static" runat="server" id="Label4">Descripción </label>
                                <asp:TextBox CssClass="form-control" runat="server" ID="txtReduccionMortalidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                <br />
                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionReduccionMortalidad">
                                    <label for="txtValidacionReduccionMortalidad" clientidmode="Static" runat="server" id="Label46">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionReduccionMortalidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                                <br />
                            </div>


                            <br />
                            <asp:CheckBox onchange="Ajustarcheck();" ID="chkReduccionMorbilidad" runat="server" ClientIDMode="Static" Text="Reducción de morbilidad" />
                            <br />
                            <div id="divReduccionMorbilidad" style="display: none;">
                                <label for="txtReduccionMorbilidad" clientidmode="Static" runat="server" id="Label6">Descripción </label>
                                <asp:TextBox CssClass="form-control" runat="server" ID="txtReduccionMorbilidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                                <asp:Panel runat="server" ID="pnlValidacionReduccionMorbilidad" Visible="false">
                                    <label for="txtValidacionReduccionMorbilidad" clientidmode="Static" runat="server" id="Label47">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionReduccionMorbilidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                                <br />
                            </div>

                            <br />
                            <asp:CheckBox onchange="Ajustarcheck();" ID="chkReduccionDiscapacidad" runat="server" ClientIDMode="Static" Text="Reducción de la condición de discapacidad" />
                            <br />
                            <div id="divReduccionDiscapacidad" style="display: none;">
                                <label for="txtReduccionDiscapacidad" clientidmode="Static" runat="server" id="Label17">Descripción </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtReduccionDiscapacidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionReduccionDiscapacidad">
                                    <label for="txtValidacionReduccionDiscapacidad" clientidmode="Static" runat="server" id="Label98">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionReduccionDiscapacidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                                <br />
                            </div>

                            <br />
                            <asp:CheckBox onchange="Ajustarcheck();" ID="chkReduccionHospitalaria" runat="server" ClientIDMode="Static" Text="Disminución de estancia hospitalaria " />
                            <br />
                            <div id="divReduccionHospitalaria" style="display: none;">
                                <label for="txtReduccionHospitalaria" clientidmode="Static" runat="server" id="Label19">Descripción </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtReduccionHospitalaria" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                                <br />
                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionReduccionEstanciaHospital">
                                    <label for="txtValidacionReduccionEstanciaHospital" clientidmode="Static" runat="server" id="Label99">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionReduccionEstanciaHospital" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                                <br />
                            </div>


                            <br />
                            <asp:CheckBox onchange="Ajustarcheck();" ID="chkDisminucionComplicacion" runat="server" ClientIDMode="Static" Text="Disminución de complicación" />
                            <br />
                            <div id="divDisminucionComplicacion" style="display: none;">
                                <label for="txtDisminucionComplicacion" clientidmode="Static" runat="server" id="Label21">Descripción </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtDisminucionComplicacion" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                <br />
                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionDismunicionComplicacion">
                                    <label for="txtValidacionDismunicionComplicacion" clientidmode="Static" runat="server" id="Label100">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionDismunicionComplicacion" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                                <br />
                            </div>


                            <br />
                            <asp:CheckBox onchange="Ajustarcheck();" ID="chkMejoraCalidadVida" runat="server" ClientIDMode="Static" Text="Mejora de la calidad de vida" />
                            <br />
                            <div id="divMejoraCalidadVida" style="display: none;">
                                <label for="txtMejoraCalidadVida" clientidmode="Static" runat="server" id="Label23">Descripción </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtMejoraCalidadVida" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                <br />
                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionMejoraCalidadVida">
                                    <label for="txtValidacionMejoraCalidadVida" clientidmode="Static" runat="server" id="Label101">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionMejoraCalidadVida" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                                <br />
                            </div>


                            <br />
                            <asp:CheckBox onchange="Ajustarcheck();" ID="chkVentajaOtro" runat="server" ClientIDMode="Static" Text="Otro" />
                            <br />
                            <div id="divVentajaOtro" style="display: none;">
                                <label for="txtVentajaOtro" clientidmode="Static" runat="server" id="Label11">Descripción </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtVentajaOtro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                <br />

                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionMejoraOtro">
                                    <label for="txtValidacionMejoraOtro" clientidmode="Static" runat="server" id="Label102">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionMejoraOtro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                                <br />

                            </div>


                        </fieldset>

                        <fieldset id="fldEfectividadClinica" runat="server">
                            <legend></legend>

                            <label for="chkEfectividadClinicaSi" clientidmode="Static" runat="server" id="Label24">¿El procedimiento cuenta con estudios de efectividad Clínica? </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="EfectividadClinica" onchange="Ajustarcheck();" ID="chkEfectividadClinicaSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="EfectividadClinica" onchange="Ajustarcheck();" ID="chkEfectividadClinicaNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>

                            <div id="divEfectividadClinica" style="display: none;">
                                <label for="divUploadEfectividad" clientidmode="Static" runat="server" id="lblArchivoEfectividad">
                                    Adjunte el archivo:
                                        <br />
                                    * Debe ser un archivo tipo: .jpg,.jpeg,.gif,.png,.pdf,.bmp
                                        <br />
                                    * Tamaño maximo: 50 Mb</label>
                                <div style=''>
                                    <div id='div1b' class='upload_input field_input' />
                                    <input type='file' name='file' id='FileUpload1' style='display: none' />
                                    <input type='button' onclick='FileUpload1.click();' style='width: 110px; height: 30px;' id='btnFileUploadText' value='Cargar Archivo' />
                                    <a runat="server" target="_blank" clientidmode="Static" id="lnkArchivo1" href=''></a>
                                </div>
                                <div class='progressbar' id='progressbar1' style='width: 100px; display: none; min-height: 10px; background-color: green;'>
                                </div>

                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionEfectividadClinica">
                                    <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label103">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionEfectividadClinica" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                            </div>


                        </fieldset>

                        <fieldset id="fldEficacia" runat="server">

                            <br />
                            <label for="chkEficaciaClinicaSi" clientidmode="Static" runat="server" id="Label35">¿El procedimiento cuenta con estudios de seguridad y eficacia Clínica? </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="EficaciaClinica" onchange="Ajustarcheck();" ID="chkEficaciaClinicaSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="EficaciaClinica" onchange="Ajustarcheck();" ID="chkEficaciaClinicaNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <div id="divEficaciaClinica" style="display: none;">
                                <label for="divUploadEficacia" clientidmode="Static" runat="server" id="Label3">
                                    Adjunte el archivo:
                                <br />
                                    * Debe ser un archivo tipo: .jpg,.jpeg,.gif,.png,.pdf,.bmp
                                <br />
                                    * Tamaño maximo: 50 Mb</label>
                                <div style=''>
                                    <div id='div2b' class='upload_input field_input' />
                                    <input type='file' name='file' id='FileUpload2' style='display: none' />
                                    <input type='button' onclick='FileUpload2.click();' style='width: 110px; height: 30px;' id='btnFileUploadText2' value='Cargar Archivo' />
                                    <a runat="server" target="_blank" clientidmode="Static" id="lnkArchivo2" href=''></a>
                                </div>
                                <div class='progressbar' id='progressbar2' style='width: 100px; display: none; min-height: 10px; background-color: green;'>
                                </div>
                            </div>

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionEstudiosSeguridad">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label104">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionEstudiosSeguridad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>
                            <br />

                        </fieldset>

                        <fieldset id="fldImplementado" runat="server">

                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label143">¿Se cuenta con la capacidad para ser implementado de manera segura, eficaz y con calidad en el Territorio Nacional? </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="EnTerritorio" onchange="Ajustarcheck();" ID="rdEnTerritorioSI" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="EnTerritorio" onchange="Ajustarcheck();" ID="rdEnTerritorioNO" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>


                            <div id="divEnTerritorio" style="display: none;">
                                <label for="txtDesccripcionDetallada" clientidmode="Static" runat="server" id="Label144">Justifique su respuesta</label>
                                <asp:TextBox runat="server" Text="" TextMode="MultiLine" type="text" name="name" ID="txtEnTerritorio" CssClass="form-control" ClientIDMode="Static" MaxLength="3000" />
                            </div>
                            <br />
                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label145">¿El procedimiento ya se está realizando en el territorio nacional? </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="RealizadoTerritorio" onchange="Ajustarcheck();" ID="rdRealizadoTerritorioSI" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="RealizadoTerritorio" onchange="Ajustarcheck();" ID="rdRealizadoTerritorioNO" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>

                            <div id="divRealizadoTerritorio" style="display: none;">
                                <label for="txtDesccripcionDetallada" clientidmode="Static" runat="server" id="Label146">¿En qué instituciones y ciudades conoce   que se realiza actualmente el procedimiento? </label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtRealizadoTerritorio" CssClass="form-control" ClientIDMode="Static" />

                                <label for="txtDesccripcionDetallada" clientidmode="Static" runat="server" id="Label147">¿Con qué código CUPS actualmente se está prescribiendo el procedimiento?</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtCUPSRealizacion" CssClass="form-control" ClientIDMode="Static" />

                                <label for="txtDesccripcionDetallada" clientidmode="Static" runat="server" id="Label148">¿Desde qué año se realiza en Colombia?</label>
                                <asp:TextBox runat="server" Text="" TextMode="Number" min="2000" max="2023" type="text" name="name" ID="txtYearRealizacion" CssClass="form-control" ClientIDMode="Static" />

                            </div>


                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label149">¿El procedimiento ha sido incluido en otros sistemas de codificación o clasificación de procedimiento de otros países?</label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="OtrosSistemasCodificacion" onchange="Ajustarcheck();" ID="rdOtrosSistemasCodificacionSI" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="OtrosSistemasCodificacion" onchange="Ajustarcheck();" ID="rdOtrosSistemasCodificacionNO" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>


                            <div id="divOtrosSistemasCodificacion" style="display: none;">
                                <label for="txtDesccripcionDetallada" clientidmode="Static" runat="server" id="Label150">Justifique su respuesta</label>
                                <asp:TextBox runat="server" Text="" type="text" name="name" ID="txtOtrosSistemasCodificacion" CssClass="form-control" ClientIDMode="Static" />
                            </div>

                        </fieldset>

                        <fieldset id="fldRiesgos" runat="server">

                            <br />
                            <label for="chkRiesgosPacienteSi" clientidmode="Static" runat="server" id="Label36">¿El procedimiento tiene riesgos y efectos adversos para el páciente? </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="RiesgosPaciente" onchange="Ajustarcheck();" ID="chkRiesgosPacienteSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="RiesgosPaciente" onchange="Ajustarcheck();" ID="chkRiesgosPacienteNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <div id="divcRiesgosPaciente" style="display: none;">
                                <label for="txtRiesgosPacienteDescripcion" clientidmode="Static" runat="server" id="Label13">Enúncielos </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRiesgosPacienteDescripcion" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </div>

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionRiesgosAdversos">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label105">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionRiesgosAdversos" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>

                            <br />
                            <label for="chkInteresSaludSi" clientidmode="Static" runat="server" id="Label58">¿El procedimiento es de interés en Salud Pública? (Plan Decenal de Salud Pública 2012-2021) </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="InteresSalud" onchange="Ajustarcheck();" ID="chkInteresSaludSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="InteresSalud" onchange="Ajustarcheck();" ID="chkInteresSaludNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <br />
                            <label for="txtObservacionInteresSalud" clientidmode="Static" runat="server" id="Label59">Observación </label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtObservacionInteresSalud" TextMode="MultiLine" Width="800px" Height="80px" MaxLength="3000"></asp:TextBox>

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionInteresSaludPublica">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label106">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionInteresSaludPublica" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>
                        </fieldset>

                        <fieldset id="fldRecomendaciones" runat="server">
                            <legend>Recomendación en Guía práctica clínica</legend>
                            <label for="txtNombreGPC" clientidmode="Static" runat="server" id="Label60">Nombre de la GPC </label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombreGPC" TextMode="SingleLine" Width="100%" MaxLength="2000"></asp:TextBox>

                            <label for="txtRecomendacionGPC" clientidmode="Static" runat="server" id="Label61">Recomendación de la GPC </label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRecomendacionGPC" TextMode="MultiLine" Width="100%" Height="80px" onkeyDown="checkTextAreaMaxLength(this,event,'2990');"></asp:TextBox>

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionGPC">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label107">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionGPC" TextMode="MultiLine" Width="100%" Height="80px"></asp:TextBox>
                            </asp:Panel>
                        </fieldset>

                        <fieldset id="fldEvidencia" runat="server">
                            <legend>Información adicional</legend>
                            <label for="chkAdjuntaEvidenciaSi" clientidmode="Static" runat="server" id="Label62">Adjunta Evidencia </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adjevidencia" onchange="Ajustarcheck();" ID="chkAdjuntaEvidenciaSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adjevidencia" onchange="Ajustarcheck();" ID="chkAdjuntaEvidenciaNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <div id="divAdjuntaEvidencia" style="display: none;">

                                <label for="txtObservacionesAdicional" clientidmode="Static" runat="server" id="Label10">Observaciónes evidencia </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtObservacionesAdicional" TextMode="MultiLine" Width="800px" Height="80px" MaxLength="2800"></asp:TextBox>


                                <label for="divUploadAdicional" clientidmode="Static" runat="server" id="Label5">
                                    Adjunte el archivo:
                                <br />
                                    * Debe ser un archivo tipo: .jpg,.jpeg,.gif,.png,.pdf,.bmp
                                <br />
                                    * Tamaño maximo: 50 Mb</label>
                                <div style=''>
                                    <div id='div3b' class='upload_input field_input' />
                                    <input type='file' name='file' id='FileUpload3' style='display: none' />
                                    <input type='button' onclick='FileUpload3.click();' style='width: 110px; height: 30px;' id='btnFileUploadText3' value='Cargar Archivo' />
                                    <a runat="server" target="_blank" clientidmode="Static" id="lnkArchivo3" href=''></a>
                                </div>
                                <div class='progressbar' id='progressbar3' style='width: 100px; display: none; min-height: 10px; background-color: green;'>
                                </div>

                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionInfoAdicional">
                                    <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label108">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionInfoAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                            </div>

                        </fieldset>

                        <br />
                        <fieldset id="fldRecursosAdicionales" runat="server">
                            <legend>Recursos adicionales para el uso del procedimiento</legend>
                            <br />
                            <label for="rdMedicamentoAdicionalSi" clientidmode="Static" runat="server" id="Label40">Medicamentos </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adicionalmedicamento" onchange="Ajustarcheck();" ID="rdMedicamentoAdicionalSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adicionalmedicamento" onchange="Ajustarcheck();" ID="rdMedicamentoAdicionalNo" runat="server" ClientIDMode="Static" Checked="true" Text="NO" />
                                </div>
                            </div>
                            <div id="divMedicamentoAdicional" style="display: none;">
                                <label for="txtRecursoAdicionalMedicamento" clientidmode="Static" runat="server" id="Label63">Nombre del recurso adicional que requiere el procedimiento</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRecursoAdicionalMedicamento" TextMode="SingleLine" Width="800px"></asp:TextBox>


                                <label for="txtEstadoInvimaMedicamenteo" clientidmode="Static" runat="server" id="Label76">Estado del Registro Sanitario Invima</label>
                                <%--<asp:TextBox runat="server"  CssClass="form-control" id="txtEstadoInvimaMedicamento" TextMode="SingleLine" Width="800px"></asp:TextBox>--%>

                                <asp:DropDownList runat="server" TabIndex="0" ID="cmbEstadoInvimaMedicamento" Width="100%" CssClass="form-control"
                                    ClientIDMode="Static">
                                    <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Vigente" Value="Vigente"></asp:ListItem>
                                    <asp:ListItem Text="Vencido" Value="Vencido"></asp:ListItem>
                                    <asp:ListItem Text="Pérdida de fuerza ejecutoria" Value="Pérdida de fuerza ejecutoria"></asp:ListItem>
                                    <asp:ListItem Text="Cancelado" Value="Cancelado"></asp:ListItem>
                                    <asp:ListItem Text="En trámite de renovación" Value="En trámite de renovación"></asp:ListItem>
                                    <asp:ListItem Text="Temporalmente no comercializado o medida cautelar" Value="Temporalmente no comercializado o medida cautelar"></asp:ListItem>
                                    <asp:ListItem Text="No aplica" Value="No aplica"></asp:ListItem>
                                </asp:DropDownList>

                                <label for="txtRegistroInvimaMedicamento" clientidmode="Static" runat="server" id="Label77">Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRegistroInvimaMedicamento" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionMedicamentoAdicional">
                                    <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label109">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionMedicamentoAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                            </div>

                            <br />
                            <label for="rdDispositivoAdicionalSi" clientidmode="Static" runat="server" id="Label64">Dispostivos </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adicionaldispositivo" onchange="Ajustarcheck();" ID="rdDispositivoAdicionalSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adicionaldispositivo" onchange="Ajustarcheck();" ID="rdDispositivoAdicionalNo" runat="server" ClientIDMode="Static" Checked="true" Text="NO" />
                                </div>
                            </div>
                            <div id="divDispositivoAdicional" style="display: none;">
                                <label for="txtRecursoAdicionalDispositivo" clientidmode="Static" runat="server" id="Label65">Nombre del recurso adicional que requiere el procedimiento</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRecursoAdicionalDispositivo" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <label for="txtEstadoInvimaDispositivo" clientidmode="Static" runat="server" id="Label78">Estado del Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEstadoInvimaDispositivo" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <label for="txtRegistroInvimaDispositivoo" clientidmode="Static" runat="server" id="Label79">Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRegistroInvimaDispositivo" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <asp:Panel runat="server" Visible="false" ID="pnlVaildacionDispositivoAdicional">
                                    <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label110">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtVaildacionDispositivoAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                            </div>

                            <br />
                            <label for="rdInVitroAdicionalSi" clientidmode="Static" runat="server" id="Label66">Reactivo In Vitro </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adicionalinvitro" onchange="Ajustarcheck();" ID="rdInVitroAdicionalSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adicionalinvitro" onchange="Ajustarcheck();" ID="rdInVitroAdicionalNo" runat="server" ClientIDMode="Static" Checked="true" Text="NO" />
                                </div>
                            </div>
                            <div id="divInvitroAdicional" style="display: none;">
                                <label for="txtRecursoAdicionalInvitro" clientidmode="Static" runat="server" id="Label67">Nombre del recurso adicional que requiere el procedimiento</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRecursoAdicionalInvitro" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <label for="txtEstadoInvimaInvitro" clientidmode="Static" runat="server" id="Label80">Estado del Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEstadoInvimaInvitro" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <label for="txtRegistroInvimaInvitro" clientidmode="Static" runat="server" id="Label81">Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRegistroInvimaInvitro" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionInvitroAdicional">
                                    <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label111">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionInvitroAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                            </div>

                            <br />
                            <label for="rdAgenteBioAdicionalSi" clientidmode="Static" runat="server" id="Label68">Agente Biológico </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adicionalagebio" onchange="Ajustarcheck();" ID="rdAgenteBioAdicionalSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adicionalagebio" onchange="Ajustarcheck();" ID="rdAgenteBioAdicionalNo" runat="server" ClientIDMode="Static" Checked="true" Text="NO" />
                                </div>
                            </div>
                            <div id="divBioAdicional" style="display: none;">
                                <label for="txtRecursoAdicionalAgebio" clientidmode="Static" runat="server" id="Label69">Nombre del recurso adicional que requiere el procedimiento</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRecursoAdicionalAgebio" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <label for="txtEstadoInvimaAgebio" clientidmode="Static" runat="server" id="Label82">Estado del Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEstadoInvimaAgebio" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <label for="txtRegistroInvimaAgeBio" clientidmode="Static" runat="server" id="Label83">Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRegistroInvimaAgeBio" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <asp:Panel runat="server" Visible="false" ID="pnlVAidacionAgenteBiologico">
                                    <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label112">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtVAidacionAgenteBiologico" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                            </div>

                            <br />
                            <label for="rdproductoBioAdicionalSi" clientidmode="Static" runat="server" id="Label70">Producto Biológico </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adicionalabiopro" onchange="Ajustarcheck();" ID="rdproductoBioAdicionalSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adicionalabiopro" onchange="Ajustarcheck();" ID="rdproductoBioAdicionalNo" runat="server" ClientIDMode="Static" Checked="true" Text="NO" />
                                </div>
                            </div>
                            <div id="divBioProAdicional" style="display: none;">
                                <label for="txtRecursoAdicionalAgeproducto" clientidmode="Static" runat="server" id="Label71">Nombre del recurso adicional que requiere el procedimiento</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRecursoAdicionalAgeproducto" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <label for="txtEstadoInvimaAgeproducto" clientidmode="Static" runat="server" id="Label72">Estado del Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEstadoInvimaAgeproducto" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <label for="txtRegistroInvimaAgeproducto" clientidmode="Static" runat="server" id="Label73">Registro Sanitario Invima</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRegistroInvimaAgeproducto" TextMode="SingleLine" Width="800px"></asp:TextBox>

                                <asp:Panel runat="server" Visible="false" ID="pnlValidacionProdcutoBilogico">
                                    <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label113">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionProdcutoBilogico" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                            </div>


                            <br />
                            <label for="rdAdicionalOtroSi" clientidmode="Static" runat="server" id="Label74">Otro </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="otroadicional" onchange="Ajustarcheck();" ID="rdAdicionalOtroSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="otroadicional" onchange="Ajustarcheck();" ID="rdAdicionalOtroNo" Checked="true" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>

                            <div id="divcAdicionalOtro" style="display: none;">
                                <label for="txtOtroAdicional" clientidmode="Static" runat="server" id="Label75">Especifique </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtOtroAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                                <asp:Panel runat="server" Visible="false" ID="pnlVaidacionOtro">
                                    <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label114">Observaciones validación </label>
                                    <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtVaidacionOtro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                </asp:Panel>
                            </div>

                        </fieldset>


                        <br />
                        <br />
                        <fieldset id="fldAtencion" runat="server">
                            <legend>El procedimiento apunta a la atención de uno de los grupos en situación de vulnerabilidad (es decir, que potencialmente contribuya a superar su situación de vulnerabilidad)</legend>
                            <label for="rdInfaciaSi" clientidmode="Static" runat="server" id="Label84">Infancia y adolecencia </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="infancia" onchange="Ajustarcheck();" ID="rdInfaciaSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="infancia" onchange="Ajustarcheck();" ID="rdInfanciaNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <br />
                            <label for="txtRelevanteInfancia" clientidmode="Static" runat="server" id="Label85">Información que considere relevante</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRelevanteInfancia" TextMode="SingleLine" Width="800px"></asp:TextBox>


                            <label for="rdEmbarazoSi" clientidmode="Static" runat="server" id="Label86">Mujeres en estado de embarazo </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="embarazo" onchange="Ajustarcheck();" ID="rdEmbarazoSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="embarazo" onchange="Ajustarcheck();" ID="rdEmbarazoNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <br />
                            <label for="txtRelevanteEmbarazo" clientidmode="Static" runat="server" id="Label87">Información que considere relevante</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRelevanteEmbarazo" TextMode="SingleLine" Width="800px"></asp:TextBox>


                            <label for="rdDesplazadosSi" clientidmode="Static" runat="server" id="Label88">Desplazados </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="Desplazados" onchange="Ajustarcheck();" ID="rdDesplazadosSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="Desplazados" onchange="Ajustarcheck();" ID="rdDesplazadosNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <br />
                            <label for="txtRelevanteDesplazados" clientidmode="Static" runat="server" id="Label89">Información que considere relevante</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRelevanteDesplazados" TextMode="SingleLine" Width="800px"></asp:TextBox>

                            <label for="rdViolenciaSi" clientidmode="Static" runat="server" id="Label90">Victimas de violencia y del conflicto armado </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="violencia" onchange="Ajustarcheck();" ID="rdViolenciaSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="violencia" onchange="Ajustarcheck();" ID="rdViolenciaNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <br />
                            <label for="txtRelevanteViolencia" clientidmode="Static" runat="server" id="Label91">Información que considere relevante</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRelevanteViolencia" TextMode="SingleLine" Width="800px"></asp:TextBox>

                            <label for="rdAdultosMayoresSi" clientidmode="Static" runat="server" id="Label92">Adultos mayores </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adul" onchange="Ajustarcheck();" ID="rdAdultosMayoresSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adul" onchange="Ajustarcheck();" ID="rdAdultosMayoresNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <br />
                            <label for="txtRelevanteAdultosMayores" clientidmode="Static" runat="server" id="Label93">Información que considere relevante</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRelevanteAdultosMayores" TextMode="SingleLine" Width="800px"></asp:TextBox>

                            <label for="rdAlgunaDiscapacidadSi" clientidmode="Static" runat="server" id="Label94">Personas con algún tipo de discapacidad </label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="aduldiscapacidad" onchange="Ajustarcheck();" ID="rdAlgunaDiscapacidadSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="aduldiscapacidad" onchange="Ajustarcheck();" ID="rdAlgunaDiscapacidadNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <br />
                            <label for="txtRelevanteAlgunaDiscapacidad" clientidmode="Static" runat="server" id="Label95">Información que considere relevante</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRelevanteAlgunaDiscapacidad" TextMode="SingleLine" Width="800px"></asp:TextBox>

                            <label for="rdHurefanasSi" clientidmode="Static" runat="server" id="Label96">Personas con enfermedades huérfanas</label>
                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adulh" onchange="Ajustarcheck();" ID="rdHurefanasSi" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="adulh" onchange="Ajustarcheck();" ID="rdHurefanasNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <br />
                            <label for="txtRelevanteHuerfanas" clientidmode="Static" runat="server" id="Label97">Información que considere relevante</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRelevanteHuerfanas" TextMode="SingleLine" Width="800px"></asp:TextBox>

                            <asp:Panel runat="server" Visible="false" ID="pnlValidacionVulnerabilidad">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label115">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtValidacionVulnerabilidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>
                        </fieldset>


                        <fieldset id="fldConflicto" runat="server">
                            <legend>Conflicto de intereses</legend>
                            <label for="txtConflicto" clientidmode="Static" runat="server" id="Label153">Declare si presenta algún conflicto de intereses teniendo en cuenta los siguientes aspectos:</label>
                            <ul>
                                <ol><strong>Financiero:</strong> Cuando el individuo tiene participación en una empresa, organización o equivalente que se relaciona directamente (socio, accionista, propietario, empleado) o indirectamente (proveedor, asesor, consultor) con las actividades para las cuales fue convocado a participar.</ol>
                                <ol><strong>Intelectual:</strong> Cuando se tiene un interés intelectual, académico o científico en un tema en particular. La declaración de este tipo de interés es indispensable para salvaguardar la calidad y objetividad del trabajo científico.</ol>
                                <ol><strong>Pertenencia:</strong> Derechos de propiedad intelectual o industrial que estén directamente relacionados con las temáticas o actividades a abordar.</ol>
                                <ol><strong>Familiar:</strong>  Cuando alguno de los familiares, hasta el tercer grado de consanguinidad y segundo de afinidad o primero civil, están relacionados de manera directa o indirecta en los aspectos financiero o intelectual, con las actividades y temáticas a desarrollar</ol>
                            </ul>
                            <br />
                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label25">Presenta algún conflicto de intereses? </label>

                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="conflicto" onchange="Ajustarcheck();" ID="chkConflictoInteres" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="conflicto" onchange="Ajustarcheck();" ID="chkNoConflictoInteres" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>


                            <div id="divConflicto" style="display: none;">
                                <label for="txtConflicto" clientidmode="Static" runat="server" id="Label1">Describa el conflicto de interes </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtConflicto" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                <label>Nota: El declarar el conflicto de intereses no limita su participación en la nominación.</label>
                            </div>

                            <br />
                            <label for="chkConflictoInteres" clientidmode="Static" runat="server" id="Label12">La agremiación o asociación científica avala la nominación </label>

                            <div class="row">
                                <div class="divLine">
                                    <asp:RadioButton GroupName="Avala" onchange="Ajustarcheck();" ID="rdAvala" runat="server" ClientIDMode="Static" Text="SI" />
                                </div>
                                <div class="divLine">
                                    <asp:RadioButton GroupName="Avala" onchange="Ajustarcheck();" ID="rdAvalaNo" runat="server" ClientIDMode="Static" Text="NO" />
                                </div>
                            </div>
                            <div id="divAvala" style="display: none;">
                                <label for="txtConflicto" clientidmode="Static" runat="server" id="Label29">Si la respuesta es "No" indique la razón </label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtRazonAvala" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </div>

                            <asp:Panel runat="server" Visible="false" ID="pnlVaidacionAvala">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label117">Observaciones validación </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtVaidacionAvala" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>

                            <asp:Panel runat="server" Visible="false" ID="pnlObservacionesValidacion">
                                <label for="txtObsrvacionesValidacion" clientidmode="Static" runat="server" id="Label39">Observaciones validación generales </label>
                                <asp:TextBox runat="server" CssClass="form-control textoValidacion" ReadOnly="true" ID="txtObservacionesValidacion" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:Panel>
                        </fieldset>



                        <div id="pnlAcepto">

                            <div class="form-group">
                                <asp:Label ID="LblValidacionCampos" runat="server" ForeColor="#E4335C" Font-Size="14pt" />
                            </div>

                            <div class="form-group" id="divGuardar" runat="server">
                                <div id="mywaitmsg" style="display: none;" class="form-group">
                                    <h3>Procesando datos, por favor espere...</h3>
                                    <div style="text-align: center">
                                        <img src="/img/loader.gif" />
                                    </div>
                                </div>

                                <asp:Button runat="server" ClientIDMode="Static"
                                    OnClientClick="ValidarGuardar()"
                                    type="submit" ID="btnGuardarContinuar" Text="Guardar y enviar" CssClass="boton2"
                                    OnClick="btnGuardarContinuar_Click" Style="height: 100px" />



                                <asp:Button runat="server" Visible="false"
                                    ClientIDMode="Static" OnClick="btnGuardar_Click" type="submit" ID="btnGuardar" Text="Guardar" CssClass="boton2" Style="height: 100px" />

                                <div class="loading" style="align-content: center">
                                    Loading. Please wait.<br />
                                    <br />
                                    <img src="/img/loader.gif" alt="" />
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
    </asp:Panel>

</asp:Content>

