<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/masterb.Master" AutoEventWireup="true" CodeBehind="frmInscripcionProcesoUPC.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmInscripcionProcesoUPC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../blueimp/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../blueimp/jquery.iframe-transport.js" type="text/javascript"></script>
    <script src="../../blueimp/jquery.fileupload.js" type="text/javascript"></script>

     <style type="text/css">               

    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    </style>

    <style type="text/css">
.ui-autocomplete { position: absolute; cursor: default; background-color:whitesmoke; }   

html .ui-autocomplete { width:1px; } 
.ui-menu {
    list-style:none;
    padding: 2px;
    margin: 0;
    display:block;
    float: left;
}
.ui-menu .ui-menu {
    margin-top: -3px;
}
.ui-menu .ui-menu-item {
    margin:0;
    padding: 0;
    zoom: 1;
    float: left;
    clear: left;
    width: 100%;
}
.ui-menu .ui-menu-item a {
    text-decoration:none;
    display:block;
    padding:.2em .4em;
    line-height:1.5;
    zoom:1;
}
.ui-menu .ui-menu-item a.ui-state-hover,
.ui-menu .ui-menu-item a.ui-state-active {
    font-weight: normal;
    margin: -1px;
}
    
</style>
    
    <style>


        input#btnGuardarContinuar{
background: #30798d;
background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
border-radius: 5px;color: #fff;font-size: 1.9rem;padding: 15px 30px;border: none;
font-weight: bold;width: 250px;margin: 40px auto;text-align: center;
}
         input#btnGuardar{
background: #30798d;
background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
border-radius: 5px;color: #fff;font-size: 1.9rem;padding: 15px 30px;border: none;
font-weight: bold;width: 250px;margin: 40px auto;text-align: center;
}

        .checkper{
margin-right:7px !important;
}

        .checkper input{
margin-right:7px !important;
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

.txtMini{
	width:40% !important;
}
txtNormal{
	width:70% !important;
}
        .errormin {
        border-color:red !important;
        border-style:solid !important;
        border-width:2px !important;
        }
    </style>
    <link href="../../Scripts/fancy/source/fancyMins.css" rel="stylesheet" />

       <script type="text/javascript" language="javascript">

               $(function () {
                $('#FileUpload7').fileupload({
                    url: '../../frm/ws/FileUploadHandler.ashx?upload=start&folder=FileUpload7&frm=upc',
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

                        if (cnt > 1){
                            alert('Solo debe seleccionar un archivo');
                            return;
                        }
                        /* if (ext.toUpperCase() != '.PDF') {
                                alert('solo es valido subir archivos en formato pdf.');
                                return; } */
                        //   console.log('add', data);
                        $('#progressbar7').show();
                        data.submit();
                    },
                    progress: function (e, data) {
                        var progress = parseInt(data.loaded / data.total * 100, 10);
                        $('#progressbar7').css('width', progress + '%');
                    },
                    success: function (response, status) {
                        $('#progressbar7').hide();
                        $('#progressbar7 div').css('width', '0%');

                            if (response.indexOf("Error") >= 0) {
                                alert(response);
                            } else {
                                $("#lnkArchivo7").attr("href", "../../files/"+response);
                                $("#lnkArchivo7").text(response);
                            }
                    },

                    error: function (error) {
                        alert('error');
                        $('#progressbar7').hide();
                        $('#progressbar7 div').css('width', '0%');
                        console.log('error', error);
                    }
                });
              });

               $(function () {
                $('#FileUpload6').fileupload({
                    url: '../../frm/ws/FileUploadHandler.ashx?upload=start&folder=FileUpload6&frm=upc',
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

                        if (cnt > 1){
                            alert('Solo debe seleccionar un archivo');
                            return;
                        }
                        /* if (ext.toUpperCase() != '.PDF') {
                                alert('solo es valido subir archivos en formato pdf.');
                                return; } */
                        //   console.log('add', data);
                        $('#progressbar6').show();
                        data.submit();
                    },
                    progress: function (e, data) {
                        var progress = parseInt(data.loaded / data.total * 100, 10);
                        $('#progressbar6').css('width', progress + '%');
                    },
                    success: function (response, status) {
                        $('#progressbar6').hide();
                        $('#progressbar6 div').css('width', '0%');

                            if (response.indexOf("Error") >= 0) {
                                alert(response);
                            } else {
                                $("#lnkArchivo6").attr("href", "../../files/"+response);
                                $("#lnkArchivo6").text(response);
                            }
                    },

                    error: function (error) {
                        alert('error');
                        $('#progressbar6').hide();
                        $('#progressbar6 div').css('width', '0%');
                        console.log('error', error);
                    }
                });
              });

  

           $(function () {
               $('#FileUpload4').fileupload({
                   url: '../../frm/ws/FileUploadHandler.ashx?upload=start&folder=FileUpload4&frm=upc',
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
                       $('#progressbar4').show();
                       data.submit();
                   },
                   progress: function (e, data) {
                       var progress = parseInt(data.loaded / data.total * 100, 10);
                       $('#progressbar4').css('width', progress + '%');
                   },
                   success: function (response, status) {
                       $('#progressbar4').hide();
                       $('#progressbar4 div').css('width', '0%');

                       if (response.indexOf("Error") >= 0) {
                           alert(response);
                       } else {
                           $("#lnkArchivo4").attr("href", "../../files/" + response);
                           $("#lnkArchivo4").text(response);
                       }
                   },

                   error: function (error) {
                       alert('error');
                       $('#progressbar4').hide();
                       $('#progressbar4 div').css('width', '0%');
                       console.log('error', error);
                   }
               });
           });

   $(function () {
                $('#FileUpload3').fileupload({
                    url: '../../frm/ws/FileUploadHandler.ashx?upload=start&folder=FileUpload3&frm=upc',
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

                        if (cnt > 1){
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
                                $("#lnkArchivo3").attr("href", "../../files/"+response);
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
                    url: '../../frm/ws/FileUploadHandler.ashx?upload=start&folder=FileUpload2&frm=upc',
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

                        if (cnt > 1){
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
                                $("#lnkArchivo2").attr("href", "../../files/"+response);
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
                    url: '../../frm/ws/FileUploadHandler.ashx?upload=start&folder=FileUpload1&frm=upc',
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

                        if (cnt > 1){
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
                                $("#lnkArchivo1").attr("href", "../../files/"+response);
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
               
               $("#txtCupsAjusteEstructura").autocomplete({
                   select: function (e, ui) { $("#txtCupsAjusteEstructura").prop('title', ui.item.label); },
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
            $("#txtEnfermedad").autocomplete({
                select: function(e, ui) { $("#txtEnfermedad").prop('title', ui.item.label); },
                messages: { noResults: '', results: function() {} },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerEnfermedad",
                        data: "{ 'criterio':'" + request.term + "' }",
                        dataType: "json", type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        timeout : 5000,
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
    </script>
     <script type="text/javascript" language="javascript">
        $(function () {
            $("#txtMedicamento").autocomplete({
                select: function (e, ui) { $("#txtMedicamento").prop('title', ui.item.label); },
                messages: { noResults: '', results: function() {} },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerMedicamento",
                        data: "{ 'criterio':'" + request.term + "' }",
                        dataType: "json", type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        timeout : 5000,
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
            $("#txtCodigoATCComparador").autocomplete({
                select: function (e, ui) { $("#txtCodigoATCComparador").prop('title', ui.item.label); },
                messages: { noResults: '', results: function() {} },
                source: function (request, response) {
                    $.ajax({
                        url: "../ws/ws.asmx/obtenerProcedimientos",
                        data: "{ 'criterio':'" + request.term + "' }",
                        dataType: "json", type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        timeout : 5000,
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


            var chkInterrupcion = $('#chkInterrupcion').prop('checked');//chkInterrupcion
            var chkInteracciones = $('#chkInteracciones').prop('checked');//chkInteracciones
            var chkAdvertenciasPrecauciones = $('#chkAdvertenciasPrecauciones').prop('checked');//chkAdvertenciasPrecauciones
            var chkContraindicaciones = $('#chkContraindicaciones').prop('checked');//chkContraindicaciones
            var chkReaccionesAdversas = $('#chkReaccionesAdversas').prop('checked');//chkReaccionesAdversas

            var chkTitularRegistro = $('#chkTitularRegistro').prop('checked');//chkExclusionA
            var chkFabricante = $('#chkFabricante').prop('checked');//chkExclusionB
            var chkImportador = $('#chkImportador').prop('checked');//chkExclusionC
            var chkAcondicionador = $('#chkAcondicionador').prop('checked');//chkExclusionD
            var chkPrestadorServicio = $('#chkPrestadorServicio').prop('checked');   //chkExclusionE
            var chkUsuarioTecnologia = $('#chkUsuarioTecnologia').prop('checked');   //chkExclusionF
            var chkRelacionOtro = $('#chkRelacionOtro').prop('checked');   //
            var chkReduccionMortalidad = $('#chkReduccionMortalidad').prop('checked');//chkExclusionA
            var chkReduccionMorbilidad = $('#chkReduccionMorbilidad').prop('checked');//chkExclusionB
            var chkReduccionHospitalaria = $('#chkReduccionHospitalaria').prop('checked');//chkExclusionD
            var chkDisminucionComplicacion = $('#chkDisminucionComplicacion').prop('checked');   //chkExclusionE
            var chkMejoraCalidadVida = $('#chkMejoraCalidadVida').prop('checked');   //chkExclusionF
            var chkVentajaOtro = $('#chkVentajaOtro').prop('checked');   //chkExclusionF
            var chkEfectividadClinicaSi = $('#chkEfectividadClinicaSi').prop('checked');   //chkConflictoInteres
            var chkSeguridadClinicaSi = $('#chkSeguridadClinicaSi').prop('checked');   //chkConflictoInteres
            var chkEficaciaClinicaSi = $('#chkEficaciaClinicaSi').prop('checked');   //chkConflictoInteres
            var chkEvidenciaOtroSi = $('#chkEvidenciaOtroSi').prop('checked');   //chkConflictoInteres
            var rdMedicamentoAdicionalSi = $('#rdMedicamentoAdicionalSi').prop('checked');   //chkConflictoInteres
            var rdDispositivoAdicionalSi = $('#rdDispositivoAdicionalSi').prop('checked');   //chkConflictoInteres
            var rdInVitroAdicionalSi = $('#rdInVitroAdicionalSi').prop('checked');   //chkConflictoInteres
            var rdAgenteBioAdicionalSi = $('#rdAgenteBioAdicionalSi').prop('checked');   //chkConflictoInteres
            var rdproductoBioAdicionalSi = $('#rdproductoBioAdicionalSi').prop('checked');   //chkConflictoInteres
            var rdAdicionalOtroSi = $('#rdAdicionalOtroSi').prop('checked');   //chkConflictoInteres
            var chkConflictoInteres = $('#chkConflictoInteres').prop('checked');   //chkConflictoInteres
            var chkAdjuntaEvidencia = $('#chkAdjuntaEvidenciaSi').prop('checked');   //chkAdjuntaEvidencia
            var rdMedicamento = $('#rdMedicamento').prop('checked');   //chkAdjuntaEvidencia
            var rdProcedimiento = $('#rdProcedimiento').prop('checked');   //chkAdjuntaEvidencia
            var rdDispositivoMedico = $('#rdDispositivoMedico').prop('checked');   //chkAdjuntaEvidencia
            var rdOtro = $('#rdOtro').prop('checked');   //chkAdjuntaEvidencia
       
            if (chkInterrupcion == true) {
                $('#divInterrupcion').show();
            } else {
                $('#divInterrupcion').hide();
            }
            if (chkInteracciones == true) {
                $('#divInteracciones').show();
            } else {
                $('#divInteracciones').hide();
            }
            if (chkAdvertenciasPrecauciones == true) {
                $('#divAdvertenciasPrecauciones').show();
            } else {
                $('#divAdvertenciasPrecauciones').hide();
            }
            if (chkContraindicaciones == true) {
                $('#divContraindicaciones').show();
            } else {
                $('#divContraindicaciones').hide();
            }
            if (chkReaccionesAdversas == true) {
                $('#divReaccionesAdversas').show();
            } else {
                $('#divReaccionesAdversas').hide();
            }
          
            if (rdDispositivoMedico == true){
                $('#divtipoDispositivo').show();
            }else{
                $('#divtipoDispositivo').hide();
            }
            if (rdProcedimiento == true) {
                $('#divtipoProcedimiento').show();
                $('#procedimientosFrm3').show();
            } else {
                $('#divtipoProcedimiento').hide();
                $('#procedimientosFrm3').hide();
            }
            if (rdMedicamento == true) {
                $('#divtipoMedicamento').show();
                $('#medicamentosFrm3').show();
            } else {
                $('#divtipoMedicamento').hide();
                $('#medicamentosFrm3').hide();
            }

            if (chkTitularRegistro == true) {
                $('#divTitularRegistro').show();
            } else {
                $('#divTitularRegistro').hide();
            }
            if (chkFabricante == true) {
                $('#divFabricante').show();
            } else {
                $('#divFabricante').hide();
            }

            if (chkImportador == true) {
                $('#divImportador').show();
            } else {
                $('#divImportador').hide();
            }
            if (chkAcondicionador == true) {
                $('#divAcondicionador').show();
            } else {
                $('#divAcondicionador').hide();
            }
            if (chkPrestadorServicio == true) {
                $('#divPrestadorServicioo').show();
            } else {
                $('#divPrestadorServicioo').hide();
            }
            if (chkUsuarioTecnologia == true) {
                $('#divUsuarioTecnologia').show();
            } else {
                $('#divUsuarioTecnologia').hide();
            }
            if (chkRelacionOtro == true) {
                $('#divRelacionOtro').show();
            } else {
                $('#divRelacionOtro').hide();
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
            if (chkSeguridadClinicaSi == true) {
                $('#divSeguridadClinica').show();
            } else {
                $('#divSeguridadClinica').hide();
            }
            if (chkEficaciaClinicaSi == true) {
                $('#divEficaciaClinica').show();
            } else {
                $('#divEficaciaClinica').hide();
            }
            if (chkEvidenciaOtroSi == true) {
                $('#divEvidenciaOtro').show();
            } else {
                $('#divEvidenciaOtro').hide();
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
            
            if (chkConflictoInteres == true) {
                $('#divConflicto').show();
            } else {
                $('#divConflicto').hide();
            }
        }
    </script>

    <style>
        
           .textoValidacion {
            border-color:#7777FF !important;
            border-style:solid !important;
            border-width:1px !important;
        } 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label runat="server" ID="lblCodNominacionUPC" ClientIDMode="Static" style="display:none;"></asp:Label>
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
                
                 <h3 class="separation-title__another">  
                    </h3>
                  <h3 class="separation-title__another">  
                    </h3>
             
                <p class="centerp"><b>Formato de Nominación en Tecnologías en Salud <br/>para Posible Inclusión en el Plan de Beneficios con Cargo a la UPC
                     </b>

                </p>

                 <p class="centerp">DIRECCIÓN DE REGULACIÓN DE BENEFICIOS, COSTOS Y TARIFAS DEL ASEGURAMIENTO EN SALUD</p>
            </div>
            <div class="row">
                
                <div class="col-md-8 col-md-offset-2">

                     <asp:Panel runat="server" ID="pnlValidacionGeneral" visible="false">
                        <fieldset>
                        <legend>Observaciones de validación</legend>
                                       <asp:TextBox Readonly="true" runat="server"  CssClass="form-control" id="txtValidacionGeneral" TextMode="MultiLine" Width="800px" Height="180px"></asp:TextBox>
                                       
                    
                    </fieldset>
                        </asp:Panel>

                <hr runat="server" id="pnlNombrePropio" style="height:1px;"></hr> 
                    
                <fieldset runat="server" id="Fieldset2" class="form-group">
                         <legend><span>
                                     <label  runat="server" ClientIDMode="Static" id="Label27">Información del proponente </label></span></legend>
                            
                    <label for="txtTipoAator"  ClientIDMode="Static" runat="server" id="Label41">Agremiación de profesionales de la salud o sociedad científica a través de la cual se nomina </label>                     
                    <asp:TextBox runat="server" ReadOnly="true" Text=""   type="text" name="name"  ID="txtTipoAator" MaxLength="100" CssClass="form-control" />

                    <label for="txtIdentificacionNominador"  ClientIDMode="Static" runat="server" id="Label42">Número de identificación </label>                     
                    <asp:TextBox runat="server" Text=""  ReadOnly="true"  type="text" name="name"  ID="txtIdentificacionNominador" MaxLength="100" CssClass="form-control" />

                    <label for="txtNombreNominador"  ClientIDMode="Static" runat="server" id="Label34">Nombre </label>                     
                    <asp:TextBox runat="server" Text=""  ReadOnly="true"  type="text" name="name"  ID="txtNombreNominador" MaxLength="100" CssClass="form-control" />

            

                </fieldset>
                    <fieldset>
                        <legend>Carta de presentación</legend>
                         <label for="txtCartaPresentacion"  ClientIDMode="Static" runat="server" id="lblTitletxtCartaPresentacion">especifique: si la TS junto con su indicación ha sido nominada previamente para su posible inclusión al Plan de Beneficios precisando la fecha de dicha nominación. Esta carta debe relacionar los nombres de los participantes en la construcción de la nominación </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtCartaPresentacion" TextMode="MultiLine" Width="800px" Height="180px"></asp:TextBox>
                                       
                    
                    </fieldset>

                    <fieldset runat="server" id="fldRelacionTsn"  ClientIDMode="Static" >
                        <legend>Relación del nominador con la TSN</legend>
                            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkTitularRegistro" runat="server"  ClientIDMode="Static" text="Títular del Registro Sanitario " />  
                            <br><div id="divTitularRegistro" style="display:none;">
                                        <label for="txtTitularRegistro"  ClientIDMode="Static" runat="server" id="Label1b">Observación </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtTitularRegistro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <asp:Panel runat="server" Visible="false" ID="pnlValidacionTitularRegistro">
                                            <label for="txtObservacionesValidacionTitularRegistro"  ClientIDMode="Static" runat="server" id="Label5b">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObservacionesValidacionTitularRegistro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:Panel>
                               </div>

                        
                            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkFabricante" runat="server"  ClientIDMode="Static" text="Fabricante " />  
                            <br><div id="divFabricante" style="display:none;">
                                        <label for="txtFabricante"  ClientIDMode="Static" runat="server" id="Label10b">Observación </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtFabricante" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <asp:Panel runat="server" Visible="false" ID="pnlValidacionFabricante">
                                            <label for="txtObservacionesValidacionFabricante"  ClientIDMode="Static" runat="server" id="Label12a">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObservacionesValidacionFabricante" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:Panel>
                               </div>

                        
                            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkImportador" runat="server"  ClientIDMode="Static" text="Importador " />  
                            <br><div id="divImportador" style="display:none;">
                                        <label for="txtImportador"  ClientIDMode="Static" runat="server" id="Label13b">Observación </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtImportador" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <asp:Panel runat="server" Visible="false" ID="pnlValidacionImportador">
                                            <label for="txtObservacionesValidacionImportador"  ClientIDMode="Static" runat="server" id="Label18">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObservacionesValidacionImportador" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:Panel>
                               </div>

                        
                            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkAcondicionador" runat="server"  ClientIDMode="Static" text="Acondicionador" />  
                            <br><div id="divAcondicionador" style="display:none;">
                                        <label for="txtAcondicionador"  ClientIDMode="Static" runat="server" id="Label25b">Observación </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtAcondicionador" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <asp:Panel runat="server" Visible="false" ID="pnlValidacionAcondicionador">
                                            <label for="txtObservacionesValidacionAcondicionador"  ClientIDMode="Static" runat="server" id="Label29b">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObservacionesValidacionAcondicionador" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:Panel>
                               </div>

                        
                            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkPrestadorServicio" runat="server"  ClientIDMode="Static" text="Prestador del servicio" />  
                            <br><div id="divPrestadorServicioo" style="display:none;">
                                        <label for="txtPrestadorServicio"  ClientIDMode="Static" runat="server" id="Label30">Observación </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtPrestadorServicio" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <asp:Panel runat="server" Visible="false" ID="pnlValidacionPrestadorServicio">
                                            <label for="txtObservacionesValidacionPrestadorServicio"  ClientIDMode="Static" runat="server" id="Label31">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObservacionesValidacionPrestadorServicio" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:Panel>
                               </div>

                        
                            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkUsuarioTecnologia" runat="server"  ClientIDMode="Static" text="Usuario de la tecnología" />  
                            <br><div id="divUsuarioTecnologia" style="display:none;">
                                        <label for="txtUsuarioTecnologia"  ClientIDMode="Static" runat="server" id="Label32">Observación </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtUsuarioTecnologia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <asp:Panel runat="server" Visible="false" ID="pnlValidacionUsuarioTecnologia">
                                            <label for="txtObservacionesValidacionUsuarioTecnologia"  ClientIDMode="Static" runat="server" id="Label36">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObservacionesValidacionUsuarioTecnologia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:Panel>
                               </div>

                           <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkRelacionOtro" runat="server"  ClientIDMode="Static" text="Otro" />  
                            <br><div id="divRelacionOtro" style="display:none;">
                                        <label for="txtRelacionOtro"  ClientIDMode="Static" runat="server" id="Label39a">Especifique </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtRelacionOtro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <asp:Panel runat="server" Visible="false" ID="pnlValidacionRelacionOtro">
                                            <label for="txtObservacionesValidacionRelacionOtro"  ClientIDMode="Static" runat="server" id="Label40a">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObservacionesValidacionRelacionOtro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:Panel>
                               </div>
                     
                    </fieldset>
                  
                <fieldset runat="server" id="fldTipoTEcnologia" class="form-group">
                                <legend><span>
                                     <label  runat="server" ClientIDMode="Static" id="lblenumeracionNatural">Información de la tecnología propuesta</label></span></legend>
                                <p>Tipo de tecnología. </p>
                    <div> <asp:RadioButton runat="server"   ClientIDMode="Static"  onchange="Ajustarcheck();"  Text="Medicamento" ID="rdMedicamento" GroupName="tipomed" />
                        <asp:RadioButton runat="server"  ClientIDMode="Static"  onchange="Ajustarcheck();"  Text="Procedimiento" ID="rdProcedimiento" GroupName="tipomed" />
<asp:RadioButton runat="server" onchange="Ajustarcheck();" ClientIDMode="Static"  Text="Dispositivo médico" ID="rdDispositivoMedico" GroupName="tipomed" />
<asp:RadioButton runat="server" onchange="Ajustarcheck();"  ClientIDMode="Static"  Text="Otro" ID="rdOtro" GroupName="tipomed" />
                    </div>

                    <label for="txtNombreTecnologia"  ClientIDMode="Static" runat="server" id="Label7">Nombre de la tecnología</label>  
                    <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="imgTooltip"
                                    class="tooltip" title="Se debe registrar el nombre genérico de la tecnología " />
                    <asp:TextBox runat="server" Text=""   type="text" name="name"  ID="txtNombreTecnologia" MaxLength="300" CssClass="form-control" />

                    <asp:panel runat="server" Visible="false" ID="pnlValidacionNombreTecnologia">
                        <label for="txtValidacionNombreTecnologia"  ClientIDMode="Static" runat="server" id="Label20">Observaciones validación </label>
                        <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionNombreTecnologia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                    </asp:panel>

                    
                    <label for="txtNombreComercialTecnologia"  ClientIDMode="Static" runat="server" id="Label1">Nombre(s) comercial(es) de la tecnología propuesta</label>  
                    <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image3"
                                    class="tooltip" title="En este campo registre el (los) nombre(s) comercial(es) de la tecnología propuesta " />
                    <asp:TextBox runat="server" Text=""   type="text" name="name"  ID="txtNombreComercialTecnologia" MaxLength="300" CssClass="form-control" />

                    <asp:panel runat="server" Visible="false" ID="pnlValidacionNombreComercial">
                        <label for="txtValidacionNombreTecnologia"  ClientIDMode="Static" runat="server" id="Label5">Observaciones validación </label>
                        <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionNombreComercial" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                    </asp:panel>


                    
                    <label for="txtIndicacionUsoTecnologia"  ClientIDMode="Static" runat="server" id="Label13">Indicación de uso de la tecnología propuesta</label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" Height="50px" name="name"  ID="txtIndicacionUsoTecnologia" MaxLength="3000" CssClass="form-control" />
                    
                    <asp:panel runat="server" Visible="false" ID="pnlValidacionIndicacionUsoTecnologia">
                        <label for="txtValidacionIndicacionUsoTecnologia"  ClientIDMode="Static" runat="server" id="Label22">Observaciones validación </label>
                        <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionIndicacionUsoTecnologia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                    </asp:panel>


                    <label for="txtEnfermedad"  ClientIDMode="Static" runat="server" id="Label9">CIE-10 (patología o condición de salud para la cual está indicada la tecnología) </label>
                                                      <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image1"
                                    class="tooltip" title="Ingrese el nombre la enfermedad o si conoce el CIE-10 relaciónelo " />
                                    <asp:TextBox runat="server" Text=""   type="text" name="name" ID="txtEnfermedad" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />
                                  
                                  <label for="txtEnfermedad2"  ClientIDMode="Static" runat="server" id="Label14">CIE-10 (patología o condición de salud para la cual está indicada la tecnología) </label>
                                  <asp:Image Width="20px"   runat="server" ImageUrl="~/img/web/help.gif" ID="Image2"  class="tooltip" title="Ingrese el nombre la enfermedad o si conoce el CIE-10 relaciónelo " />
                                    <asp:TextBox runat="server" Text=""   type="text" name="name" ID="txtEnfermedad2" MaxLength="600" CssClass="form-control" ClientIDMode="Static" />

                                  <label for="txtEnfermedad3"  ClientIDMode="Static" runat="server" id="Label15">CIE-10 (patología o condición de salud para la cual está indicada la tecnología)  </label>
                                    <asp:TextBox  runat="server" Text=""   type="text" name="name" ID="txtEnfermedad3" MaxLength="600"  CssClass="form-control" ClientIDMode="Static"   />
                  
                    <asp:panel runat="server" Visible="false" ID="pnlValidacionCie10">
                        <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label33">Observaciones validación </label>
                        <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionCie10" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                    </asp:panel>

                    <label for="txtJustificacionPropuesta"  ClientIDMode="Static" runat="server" id="Label45">Justificación de la propuesta</label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" Height="50px" name="name"  ID="txtJustificacionPropuesta" MaxLength="3000" CssClass="form-control" />
                    
                    <asp:panel runat="server" Visible="false" ID="pnlValidacionJustificacionPropuesta">
                        <label for="txtValidacionJustificacionPropuesta"  ClientIDMode="Static" runat="server" id="Label12">Observaciones validación </label>
                        <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionJustificacionPropuesta" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                   </asp:panel>

                    <div id="divtipoMedicamento">
                    <label for="txtPrincipioActivo"  ClientIDMode="Static" runat="server" id="Label25">Principio activo </label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" name="name"  ID="txtPrincipioActivo" MaxLength="3000" CssClass="form-control" />
                 
                    <label for="txtCodigoATC"  ClientIDMode="Static" runat="server" id="Label26">Codigo ATC </label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" name="name"  ID="txtCodigoATC" MaxLength="3000" CssClass="form-control" />
                 
                    <label for="txtFormaFarmaceutica"  ClientIDMode="Static" runat="server" id="Label29">Forma farmacéutica (si es más de uno separarlo por "";"")   </label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" name="name"  ID="txtFormaFarmaceutica" MaxLength="3000" CssClass="form-control" />
                 
                    <label for="txtConcentracion"  ClientIDMode="Static" runat="server" id="Label39">Concentración (si es más de uno separarlo por "";"")    </label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" name="name"  ID="txtConcentracion" MaxLength="3000" CssClass="form-control" />
                 
                    <label for="txtViaAdministracion"  ClientIDMode="Static" runat="server" id="Label40">Vía de administración (si es más de uno separarlo por "";"")     </label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" name="name"  ID="txtViaAdministracion" MaxLength="3000" CssClass="form-control" />
                 
                    <label for="txtOtraIndicacionesMedicamento"  ClientIDMode="Static" runat="server" id="Label43">Otras indicaciones autorizadas (si es más de uno separarlo por "";"")     </label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" name="name"  ID="txtOtraIndicacionesMedicamento" MaxLength="3000" CssClass="form-control" />
                 
                    <label for="txtRegistroSanitario"  ClientIDMode="Static" runat="server" id="Label44">Registro Sanitario (si es más de uno separarlo por "";")"      </label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" name="name"  ID="txtRegistroSanitario" MaxLength="3000" CssClass="form-control" />
                 
                    <label for="txtObservacionesMedicamento"  ClientIDMode="Static" runat="server" id="Label116">Observaciones: En este campo debe registrar aclaraciones adicionales si se necesitan     </label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" name="name" Height="50px"  ID="txtObservacionesMedicamento" MaxLength="3000" CssClass="form-control" />
                 
                       <asp:panel runat="server" Visible="false" ID="pnlValidacionMedicamento">
                            <label for="txtObservacionesValidacionMedicamento"  ClientIDMode="Static" runat="server" id="Label118">Observaciones validación </label>
                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObservacionesValidacionMedicamento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </asp:panel>

                    </div>
                    <div id="divtipoProcedimiento">
                        <label for="txtCupsAjuste"  ClientIDMode="Static" runat="server" id="Label48">Código CUPS.  </label>
                        <asp:TextBox  runat="server" Text=""   type="text" name="name" ID="txtCupsAjuste" MaxLength="600"  CssClass="form-control" ClientIDMode="Static"   />
    
                        <label for="txtIndicionesProcedimiento"  ClientIDMode="Static" runat="server" id="Label119">Indicaciones diferentes a la propuesta.  </label>
                        <asp:TextBox  runat="server" Text=""   type="text" name="name" ID="txtIndicionesProcedimiento" MaxLength="600"  CssClass="form-control" ClientIDMode="Static"   />
    
                        <label for="cmbTipoProcedimiento"  ClientIDMode="Static" runat="server" id="Label121">Tipo de procedimiento</label>  
                        <asp:DropDownList runat="server" name="name"  ID="cmbTipoProcedimiento" CssClass="form-control" DataSourceID="SqlDataSourceTipoProcedimiento" DataTextField="NOMBRE_TIPO_PROCEDIMIENTO" DataValueField="COD_TIPO_PROCEDIMIENTO" >
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceTipoProcedimiento" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_PROCEDIMIENTO], [NOMBRE_TIPO_PROCEDIMIENTO] FROM [TIPO_PROCEDIMIENTO] ORDER BY [NOMBRE_TIPO_PROCEDIMIENTO]"></asp:SqlDataSource>
                        
                        <label for="txtObservacionesProcedimientos"  ClientIDMode="Static" runat="server" id="Label120">Observaciones</label>  
                        <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" Height="50px" name="name"  ID="txtObservacionesProcedimientos" MaxLength="3000" CssClass="form-control" />
                       <asp:panel runat="server" Visible="false" ID="pnlValidacionProcedimiento">
                            <label for="txtObsValidacionProcedimiento"  ClientIDMode="Static" runat="server" id="Label129">Observaciones validación </label>
                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObsValidacionProcedimiento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </asp:panel>
                        
                          </div>
                    <div id="divtipoDispositivo">

                         <label for="txtRegistroSanitarioDispositivo"  ClientIDMode="Static" runat="server" id="Label122">Registro Sanitario (si es más de uno separarlo por ";")  </label>
                        <asp:TextBox  runat="server" Text=""   type="text" name="name" ID="txtRegistroSanitarioDispositivo" MaxLength="600"  CssClass="form-control" ClientIDMode="Static"   />
    
                         <label for="cmbTipoDispositivo"  ClientIDMode="Static" runat="server" id="Label123">Tipo de dispositivo</label>  
                        <asp:DropDownList runat="server" name="name"  ID="cmbTipoDispositivo" CssClass="form-control" DataSourceID="SqlDataSourceTipoDispostivo" DataTextField="NOMBRE_TIPO_DISPOSITIVO" DataValueField="COD_TIPO_DISPOSITIVO" >
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceTipoDispostivo" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_DISPOSITIVO], [NOMBRE_TIPO_DISPOSITIVO] FROM [TIPO_DISPOSITIVO] ORDER BY [NOMBRE_TIPO_DISPOSITIVO]"></asp:SqlDataSource>
                        
                        <label for="cmbClasificacionRiesgo"  ClientIDMode="Static" runat="server" id="Label124">Clasificación de riesgo</label>  
                        <p>Clasificación de riesgo: Este campo permite seleccionar la clasificación de los dispositivos médicos realizada por el fabricante, según el Artículo 5 del Decreto 4725 de 2005 "Clasificación". Se puede seleccionar alguna de las siguientes clases:
<BR />Clase I. Son aquellos dispositivos médicos de bajo riesgo, sujetos a controles generales, no destinados para proteger o mantener la vida o para un uso de importancia especial en la prevención del deterioro de la salud humana y que no representan un riesgo potencial no razonable de enfermedad o lesión.
<BR />Clase IIa. Son los dispositivos médicos de riesgo moderado, sujetos a controles especiales en la fase de fabricación para demostrar su seguridad y efectividad.
<BR />Clase Ilb. Son los dispositivos médicos de riesgo alto, sujetos a controles especiales en el diseño y fabricación para demostrar su seguridad y efectividad.
<BR />Clase III. Son los dispositivos médicos de muy alto riesgo sujetos a controles especiales, destinados a proteger o mantener la vida o para un uso de importancia sustancial en la prevención del deterioro de la salud humana, o si su uso presenta un riesgo potencial de enfermedad o lesión.
</p>
                        <asp:DropDownList runat="server" name="name"  ID="cmbClasificacionRiesgo" CssClass="form-control" DataSourceID="SqlDataSourceClasificacionRiesgo" DataTextField="NOMBRE_CLASIFICACION_RIESGO" DataValueField="COD_CLASIFICACION_RIESGO" >
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceClasificacionRiesgo" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_CLASIFICACION_RIESGO], [NOMBRE_CLASIFICACION_RIESGO] FROM [CLASIFICACION_RIESGO] ORDER BY [NOMBRE_CLASIFICACION_RIESGO]"></asp:SqlDataSource>
                        
                        <label for="txtIndicionesDispositivo"  ClientIDMode="Static" runat="server" id="Label125">Indicaciones diferentes a la propuesta.  </label>
                        <asp:TextBox  runat="server" Text=""   type="text" name="name" ID="txtIndicionesDispositivo" MaxLength="600"  CssClass="form-control" ClientIDMode="Static"   />
    
                        <label for="txtObservacionesDispositivo"  ClientIDMode="Static" runat="server" id="Label126">Observaciones</label>  
                        <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" Height="50px" name="name"  ID="txtObservacionesDispositivo" MaxLength="3000" CssClass="form-control" />
                    
                        <asp:panel runat="server" Visible="false" ID="pnlValidacionDispositivo">
                            <label for="txtObsValidacionDispositivo"  ClientIDMode="Static" runat="server" id="Label128">Observaciones validación </label>
                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObsValidacionDispositivo" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </asp:panel>

                    </div>
 </fieldset>

                       <fieldset runat="server"  ClientIDMode="Static" id="fldFinalidadProcedimiento">
                            <legend><span>Importancia de la tecnología</span></legend>
                          <asp:CheckBox  id="chkPrimeraLinea" runat="server"  ClientIDMode="Static" text="Primera línea" />        
                                    
                      <br>  
                                   
                    <asp:CheckBox  id="chkSegundaLinea" runat="server"  ClientIDMode="Static" text="Segunda línea" />
                      <br>
                           <asp:CheckBox  id="chkTerceraLinea" runat="server"  ClientIDMode="Static" text="Tercera línea" />
                           <br>

                    <asp:CheckBox  id="chkUsocotidiano" runat="server"  ClientIDMode="Static" text="Uso cotidíano" />
                      <br>
                        
                    <asp:CheckBox  id="chkOtroImportacia" runat="server"  ClientIDMode="Static" text="Otro Especifíque" />
                       <br>
                    <label for="txtObservacionesImportancia"  ClientIDMode="Static" runat="server" id="Label127">Observaciones</label>  
                    <asp:TextBox runat="server" Text=""   type="text" TextMode="MultiLine" Height="50px" name="name"  ID="txtObservacionesImportancia" MaxLength="3000" CssClass="form-control" />
                    

                        <asp:panel runat="server" Visible="false" ID="pnlValidacionImportancia">
                            <label for="txtObservacionesValidacionImportancia"  ClientIDMode="Static" runat="server" id="Label37">Observaciones validación </label>
                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObsrvacionesValidacionImportancia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </asp:panel>

                      </fieldset>

                    <fieldset  runat="server"  ClientIDMode="Static" id="Fieldsetpoblacionobj">
                        <legend>Población objetivo de la tecnología</legend>
                    
                        <table class="table">
                            <tr>
                                <td>Marque con una "x" según corresponda</td>
                                <td>Mujer</td>
                                <td>Hombre</td>
                                <td>Observaciones</td>
                            </tr>

                            
                            <tr>
                                <td>Menores de una año</td>
                                <td><asp:CheckBox runat="server" ID="chkObj0a1Mujer"></asp:CheckBox></td>
                                <td><asp:CheckBox runat="server" ID="chkObj0a1Hombre"></asp:CheckBox></td>
                                <td><asp:TextBox runat="server" ID="txtObj0a1" Width="300px" ></asp:TextBox></td>
                            </tr>

                            
                            <tr>
                               <td>1-4 años</td>
                                <td><asp:CheckBox runat="server" ID="chkObj1a4Mujer"></asp:CheckBox></td>
                                <td><asp:CheckBox runat="server" ID="chkObj1a4Hombre"></asp:CheckBox></td>
                                <td><asp:TextBox runat="server" ID="txtObj1a4" Width="300px"></asp:TextBox></td>
                            </tr>
                            <tr>
                               <td>5-14 años</td>
                                <td><asp:CheckBox runat="server" ID="chkObj5a14Mujer"></asp:CheckBox></td>
                                <td><asp:CheckBox runat="server" ID="chkObj5a14Hombre"></asp:CheckBox></td>
                                <td><asp:TextBox runat="server" ID="txtObj5a14" Width="300px"></asp:TextBox></td>
                            </tr>
                            <tr>
                               <td>15-28 años</td>
                                <td><asp:CheckBox runat="server" ID="chkObj15a28Mujer"></asp:CheckBox></td>
                                <td><asp:CheckBox runat="server" ID="chkObj15a28Hombre"></asp:CheckBox></td>
                                <td><asp:TextBox runat="server" ID="txtObj15a28" Width="300px"></asp:TextBox></td>
                            </tr>

                             <tr>
                               <td>19-29 años</td>
                                <td><asp:CheckBox runat="server" ID="chkObj19a29Mujer"></asp:CheckBox></td>
                                <td><asp:CheckBox runat="server" ID="chkObj19a29Hombre"></asp:CheckBox></td>
                                <td><asp:TextBox runat="server" ID="txtObj19a29" Width="300px"></asp:TextBox></td>
                            </tr>
                            
                             <tr>
                               <td>30-44 años</td>
                                <td><asp:CheckBox runat="server" ID="chkObj30a44Mujer"></asp:CheckBox></td>
                                <td><asp:CheckBox runat="server" ID="chkObj30a44Hombre"></asp:CheckBox></td>
                                <td><asp:TextBox runat="server" ID="txtObj30a44" Width="300px"></asp:TextBox></td>
                            </tr> 

                             <tr>
                               <td>45-59 años</td>
                                <td><asp:CheckBox runat="server" ID="chkObj45a59Mujer"></asp:CheckBox></td>
                                <td><asp:CheckBox runat="server" ID="chkObj45a59Hombre"></asp:CheckBox></td>
                                <td><asp:TextBox runat="server" ID="txtObj45a59" Width="300px"></asp:TextBox></td>
                            </tr>

                              <tr>
                               <td>60-69 años</td>
                                <td><asp:CheckBox runat="server" ID="chkObj60a69Mujer"></asp:CheckBox></td>
                                <td><asp:CheckBox runat="server" ID="chkObj60a69Hombre"></asp:CheckBox></td>
                                <td><asp:TextBox runat="server" ID="txtObj60a69" Width="300px"></asp:TextBox></td>
                            </tr>
                            
                              <tr>
                               <td>70-79 años</td>
                                <td><asp:CheckBox runat="server" ID="chkObj70a79Mujer"></asp:CheckBox></td>
                                <td><asp:CheckBox runat="server" ID="chkObj70a79Hombre"></asp:CheckBox></td>
                                <td><asp:TextBox runat="server" ID="txtObj70a79" Width="300px"></asp:TextBox></td>
                            </tr>

                            
                              <tr>
                               <td>80 años y mayores</td>
                                <td><asp:CheckBox runat="server" ID="chkObj80a100Mujer"></asp:CheckBox></td>
                                <td><asp:CheckBox runat="server" ID="chkObj80a100Hombre"></asp:CheckBox></td>
                                <td><asp:TextBox runat="server" ID="txtObj80a100" Width="300px"></asp:TextBox></td>
                            </tr>
                        </table>

                        
                        <asp:panel runat="server" Visible="false" ID="pnlValidacionPoblacionObjetivo">
                            <label for="txtValidacionPoblacionObjetivo"  ClientIDMode="Static" runat="server" id="Label131">Observaciones validación </label>
                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionPoblacionObjetivo" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </asp:panel>
                    </fieldset>


                       <fieldset runat="server"  ClientIDMode="Static" id="FieldsetEtapa" >
                            <legend><span>Etapa del ciclo de atención</span></legend>
                          <asp:CheckBox  id="chkEtapaPromocionSalud" runat="server"  ClientIDMode="Static" text="Promoción de la salud" />        
                                    
                      <br>  
                                   
                    <asp:CheckBox  id="chkEtapaPrevencionEnfermedad" runat="server"  ClientIDMode="Static" text="Prevención de la enfermedad" />
                      <br>
                           <asp:CheckBox  id="chkEtapaDiagnostico" runat="server"  ClientIDMode="Static" text="Diagnostico" />
                           <br>

                    <asp:CheckBox  id="chkEtapaTratamiento" runat="server"  ClientIDMode="Static" text="Tratamiento" />
                      <br>

                    <asp:CheckBox  id="chkEtapaRehabilitacion" runat="server"  ClientIDMode="Static" text="Rehabilitación" />
                       <br>

                    <asp:CheckBox  id="chkEtapaPaliacion" runat="server"  ClientIDMode="Static" text="Paliación" />
                      <br>

                    <asp:CheckBox  id="chkEtapacosmetico" runat="server"  ClientIDMode="Static" text="Cosmético o suntuario" />
                       <br>
                        <asp:panel runat="server" Visible="false" ID="pnlValidacionEtapa">
                            <label for="txtObsrvacionesValidacionEtapa"  ClientIDMode="Static" runat="server" id="Label130">Observaciones validación </label>
                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtObsrvacionesValidacionEtapa" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </asp:panel>
                           <hr />
                               <label for="cmbAmbitoUso"  ClientIDMode="Static" runat="server" id="Label132">Ámbito de uso de la tecnología</label>  
                    <asp:DropDownList runat="server" name="name"  ID="cmbAmbitoUso" CssClass="form-control" DataSourceID="SqlDataSourceAmbito" DataTextField="NOMBRE_AMBITO_UPC" DataValueField="COD_AMBITO_UPC" >
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceAmbito" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_AMBITO_UPC], [NOMBRE_AMBITO_UPC] FROM [AMBITO_UPC] ORDER BY [NOMBRE_AMBITO_UPC]"></asp:SqlDataSource>


                      </fieldset>

    <fieldset runat="server" id="fldVEntajas"  ClientIDMode="Static">
                                    <legend><span>Resultados clínicos con el uso  de la tecnología</span></legend>
                                                                       
                                        <br>  <asp:CheckBox onchange="Ajustarcheck();" id="chkReduccionMortalidad" runat="server"  ClientIDMode="Static" text="Reducción de mortalidad" />  
                                      <br />
                                     <div id="divReduccionMortalidad" style="display:none;">
                                           <label for="txtReduccionMortalidad"  ClientIDMode="Static" runat="server" id="Label4">Descripción </label>
                                        <asp:TextBox CssClass="form-control" runat="server" id="txtReduccionMortalidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <br>
                                         <asp:Panel runat="server" Visible="false" ID="pnlValidacionReduccionMortalidad">
                                           <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label46">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionReduccionMortalidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                           </asp:Panel>
                                          <br />
                                     </div>

                                    
                                     <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkReduccionMorbilidad" runat="server"  ClientIDMode="Static" text="Reducción de morbilidad" />  
                                    <br>
                                    <div id="divReduccionMorbilidad" style="display:none;">
                                        <label for="txtReduccionMorbilidadB"  ClientIDMode="Static" runat="server" id="Label6">Descripción </label>
                                        <asp:TextBox  CssClass="form-control" runat="server" id="txtReduccionMorbilidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                                     
                                        <asp:Panel runat="server" ID="pnlValidacionReduccionMorbilidad" Visible="false">        
                                            <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label47">Observaciones validación </label>
                                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionReduccionMorbilidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:Panel> 
                                        <br />
                                    </div>

                                                                      
            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkReduccionHospitalaria" runat="server"  ClientIDMode="Static" text="Disminución de estancia hospitalaria " />  
                                           <br>   
                                    <div id="divReduccionHospitalaria" style="display:none;">
                                        <label for="txtReduccionHospitalaria"  ClientIDMode="Static" runat="server" id="Label19">Descripción </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtReduccionHospitalaria" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                       
                                         <br>
                                        <asp:Panel runat="server" Visible="false" ID="pnlValidacionReduccionEstanciaHospital">
                                            <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label99">Observaciones validación </label>
                                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionReduccionEstanciaHospital" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:Panel>
                                            <br />
                                    </div>

                                    
                                      <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkDisminucionComplicacion" runat="server"  ClientIDMode="Static" text="Disminución de complicación" />  
                                           <br> 
                                    <div id="divDisminucionComplicacion" style="display:none;">
                                        <label for="txtDisminucionComplicacion"  ClientIDMode="Static" runat="server" id="Label21">Descripción </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtDisminucionComplicacion" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <br>
                                         <asp:panel runat="server" Visible="false" ID="pnlValidacionDismunicionComplicacion">
                                           <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label100">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionDismunicionComplicacion" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:panel>
                                        <br />
                                    </div>
                                    
                                   
                                           <br>  <asp:CheckBox onchange="Ajustarcheck();" id="chkMejoraCalidadVida" runat="server"  ClientIDMode="Static" text="Mejora de la calidad de vida" />  
                                           <br>
                                    <div id="divMejoraCalidadVida" style="display:none;">
                                        <label for="txtMejoraCalidadVida"  ClientIDMode="Static" runat="server" id="Label23">Descripción </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtMejoraCalidadVida" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <br>
                                        <asp:panel runat="server" Visible="false" ID="pnlValidacionMejoraCalidadVida">
                                           <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label101">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionMejoraCalidadVida" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                       </asp:panel>
                                             <br>
                                    </div>
                                         
                                   
                                           <br>  <asp:CheckBox onchange="Ajustarcheck();" id="chkVentajaOtro" runat="server"  ClientIDMode="Static" text="Otro" />  
                                           <br>
                                    <div id="divVentajaOtro" style="display:none;">
                                        <label for="txtVentajaOtro"  ClientIDMode="Static" runat="server" id="Label11">Descripción </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtVentajaOtro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        <br>
                                        
                                        <asp:panel runat="server" Visible="false" ID="pnlValidacionMejoraOtro">
                                            <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label102">Observaciones validación </label>
                                           <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionMejoraOtro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                        </asp:panel>
                                        <br />
                                    </div>
                                </fieldset>
                    
                    
                    <fieldset>
                        <legend>La tecnología cuenta con evidencia científica?</legend>

                        <label for="chkEfectividadClinicaSi"  ClientIDMode="Static" runat="server" id="Label24">¿El procedimiento cuenta con estudios de efectividad? </label>
                        <asp:RadioButton GroupName="EfectividadClinica" onchange="Ajustarcheck();" id="chkEfectividadClinicaSi" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                        <asp:RadioButton GroupName="EfectividadClinica" onchange="Ajustarcheck();" id="chkEfectividadClinicaNo" runat="server"  
                                   ClientIDMode="Static" text="NO" />  

                        <div id="divEfectividadClinica"  style="display:none;">
                                      <label for="divUploadEfectividad" ClientIDMode="Static" runat="server" id="lblArchivoEfectividad">Adjunte el archivo: <br />  * Debe ser un archivo tipo: .jpg,.jpeg,.gif,.png,.pdf,.bmp <br /> * Tamaño maximo: 50 Mb</label>
                                     <div style=''>
                                         <div id='div1b' class='upload_input field_input' >
                                                <input type='file' name='file' id='FileUpload1' style='display:none' />  
                                                <input type='button'onclick='FileUpload1.click();' style='width:110px;height:30px;' id='btnFileUploadText' value='Cargar Archivo' />
                                                <a runat="server" target="_blank" ClientIDMode="Static" id="lnkArchivo1" href=''></a>
                                        </div>
                                        <div class='progressbar' id='progressbar1' style='width:100px;display:none;min-height:10px;background-color:green;'>
                                        </div>
                                    </div>
                            <asp:panel runat="server" Visible="false" ID="pnlValidacionEfectividadClinica">
                                <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label103">Observaciones validación </label>
                                <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionEfectividadClinica" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:panel>
                      </div>
                              
                        
                       <label for="chkSeguridadClinicaSi"  ClientIDMode="Static" runat="server" id="Label17">¿El procedimiento cuenta con estudios de seguridad? </label>
                               <asp:RadioButton GroupName="seguridadClinica" onchange="Ajustarcheck();" id="chkSeguridadClinicaSi" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="seguridadClinica" onchange="Ajustarcheck();" id="chkSeguridadClinicaNo" runat="server"  
                                   ClientIDMode="Static" text="NO" />  
                        <div id="divSeguridadClinica"  style="display:none;">
                                    <label for="divUploadSeguridad" ClientIDMode="Static" runat="server" id="Label98">Adjunte el archivo: <br />  * Debe ser un archivo tipo: .jpg,.jpeg,.gif,.png,.pdf,.bmp <br /> * Tamaño maximo: 50 Mb</label>
                                   <div style=''>
                                        <div id='div2b' class='upload_input field_input' >
                                             <input type='file' name='file' id='FileUpload2' style='display:none' />  
                                             <input type='button'onclick='FileUpload2.click();' style='width:110px;height:30px;' id='btnFileUploadText2' value='Cargar Archivo' />
                                             <a runat="server" target="_blank"   ClientIDMode="Static" id="lnkArchivo2" href=''></a>
                                        </div>
                                    <div class='progressbar' id='progressbar2' style='width:100px;display:none;min-height:10px;background-color:green;'></div>
                                    <asp:panel runat="server" Visible="false" ID="pnlValidacionEstudiosSeguridad">
                                         <label for="txtValidacionEstudiosSeguridad"  ClientIDMode="Static" runat="server" id="Label133">Observaciones validación </label>
                                         <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionEstudiosSeguridad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                    </asp:panel>
                                 </div>
                            </div>

                            <label for="chkEficaciaClinicaSi"  ClientIDMode="Static" runat="server" id="Label35">¿El procedimiento cuenta con estudios de eficacia? </label>
                               <asp:RadioButton GroupName="EficaciaClinica" onchange="Ajustarcheck();" id="chkEficaciaClinicaSi" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="EficaciaClinica" onchange="Ajustarcheck();" id="chkEficaciaClinicaNo" runat="server"  
                                   ClientIDMode="Static" text="NO" />  
                                <div id="divEficaciaClinica"  style="display:none;">
                                        <label for="divUploadEficacia" ClientIDMode="Static" runat="server" id="Label3">Adjunte el archivo: <br />  * Debe ser un archivo tipo: .jpg,.jpeg,.gif,.png,.pdf,.bmp <br /> * Tamaño maximo: 50 Mb</label>
                                        <div style=''>
                                            <div id='div3b' class='upload_input field_input' >
                                                <input type='file' name='file' id='FileUpload3' style='display:none' />  
                                                <input type='button'onclick='FileUpload3.click();' style='width:110px;height:30px;' id='btnFileUploadText3' value='Cargar Archivo' />
                                                <a runat="server" target="_blank"   ClientIDMode="Static" id="lnkArchivo3" href=''></a>
                                            </div>
                                            <div class='progressbar' id='progressbar3' style='width:100px;display:none;min-height:10px;background-color:green;'>
                                            </div>

                                           <asp:panel runat="server" Visible="false" ID="pnlValidacionEstudiosEficacia">
                                               <label for="txtValidacionEstudiosEficacia"  ClientIDMode="Static" runat="server" id="Label104">Observaciones validación </label>
                                               <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionEstudiosEficacia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                           </asp:panel>
                                        </div>
                                 </div>
                        <br />
                            <label for="chkEvidenciaOtroSi"  ClientIDMode="Static" runat="server" id="Label36b">Otro </label>
                               <asp:RadioButton GroupName="evidenciaOtro" onchange="Ajustarcheck();" id="chkEvidenciaOtroSi" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="evidenciaOtro" onchange="Ajustarcheck();" id="chkEvidenciaOtroNo" runat="server"  
                                   ClientIDMode="Static" text="NO" />  
                        <div id="divEvidenciaOtro"  style="display:none;">
                                   <label for="txtEvidenciaOtro"  ClientIDMode="Static" runat="server" id="Label13a">Enúncielo </label>
                                  <asp:TextBox runat="server"  CssClass="form-control" id="txtEvidenciaOtro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                            <asp:panel runat="server" Visible="false" ID="pnlValidacionEvidenciaOtro">
                                <label for="txtValidacionEvidenciaOtro"  ClientIDMode="Static" runat="server" id="Label105">Observaciones validación </label>
                                <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionEvidenciaOtro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:panel>
                        </div>

                        <hr class="alert-danger" />
                <label for="chkPrestaExteriorSI"  ClientIDMode="Static" runat="server" id="Label58">La tecnología  se presta en el exterior? </label>
                               <asp:RadioButton GroupName="prestaext"  id="chkPrestaExteriorSI" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="prestaext" id="chkPrestaExteriorNo" runat="server"  
                                   ClientIDMode="Static" text="NO" />
                        <br />
                                   <label for="txtObservacionInteresSalud"  ClientIDMode="Static" runat="server" id="Label59">Observación </label>
                                  <asp:TextBox runat="server"  CssClass="form-control" id="txtObservacionPrestaExterior" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                
                            <asp:panel runat="server" Visible="false" ID="pnlValidacionObservacionPrestaExterior">
                                 <label for="txtValidacionObservacionPrestaExterior"  ClientIDMode="Static" runat="server" id="Label106">Observaciones validación </label>
                                 <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionObservacionPrestaExterior" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:panel>
                </fieldset>
                    
                        <br />
                    <fieldset>
                        <legend>Objeción, Observación o aporte en Guía  de Práctica Clínica (GPC) de la tecnología propuesta</legend>
                          <label for="txtNombreGPC"  ClientIDMode="Static" runat="server" id="Label60">Nombre de la GPC </label>
                                  <asp:TextBox runat="server"  CssClass="form-control" id="txtNombreGPC" TextMode="SingleLine" Width="800px" ></asp:TextBox>

                          <label for="txtRecomendacionGPC"  ClientIDMode="Static" runat="server" id="Label61">Recomendación de la GPC </label>
                                  <asp:TextBox runat="server"  CssClass="form-control" id="txtRecomendacionGPC" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                        <asp:panel runat="server" Visible="false" ID="pnlValidacionGPC">
                            <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label107">Observaciones validación </label>
                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionGPC" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </asp:panel>
                    </fieldset>
                    <br />
                 <fieldset>
                        <legend>La tecnología propuesta apunta a la atención de algún grupo en situación de vulnerabilidad (según el Plan decenal de Salud Pública)</legend>
                         <label for="rdInfaciaSi"  ClientIDMode="Static" runat="server" id="Label84">Primera Infancia y adolecencia </label>
                               <asp:RadioButton GroupName="infanciax"  id="rdInfaciaSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="infanciax"  id="rdInfanciaNo" runat="server" ClientIDMode="Static" text="NO" /> 
                        <br /> 
                                   <label for="txtRelevanteInfancia"  ClientIDMode="Static" runat="server" id="Label85">Información que considere relevante</label>
                                  <asp:TextBox runat="server"  CssClass="form-control"  Height="50px"  id="txtRelevanteInfancia" TextMode="MultiLine" Width="800px"></asp:TextBox>

                        
                         <label for="rdEmbarazoSi"  ClientIDMode="Static" runat="server" id="Label86">Mujeres en estado de embarazo </label>
                               <asp:RadioButton GroupName="embarazo"  id="rdEmbarazoSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="embarazo"  id="rdEmbarazoNo" runat="server" ClientIDMode="Static" text="NO" />  
                                    <br />  <label for="txtRelevanteEmbarazo"  ClientIDMode="Static" runat="server" id="Label87">Información que considere relevante</label>
                                  <asp:TextBox runat="server"  Height="50px"   CssClass="form-control" id="txtRelevanteEmbarazo" TextMode="MultiLine" Width="800px"></asp:TextBox>

                        
                         <label for="rdDesplazadosSi"  ClientIDMode="Static" runat="server" id="Label88">Desplazados </label>
                               <asp:RadioButton GroupName="Desplazados"  id="rdDesplazadosSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="Desplazados"  id="rdDesplazadosNo" runat="server" ClientIDMode="Static" text="NO" />  
                                    <br />  <label for="txtRelevanteDesplazados"  ClientIDMode="Static" runat="server" id="Label89">Información que considere relevante</label>
                                  <asp:TextBox runat="server"  Height="50px"   CssClass="form-control" id="txtRelevanteDesplazados" TextMode="MultiLine" Width="800px"></asp:TextBox>

                         <label for="rdViolenciaSi"  ClientIDMode="Static" runat="server" id="Label90">Victimas de violencia y del conflicto armado </label>
                               <asp:RadioButton GroupName="violencia" id="rdViolenciaSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="violencia"  id="rdViolenciaNo" runat="server" ClientIDMode="Static" text="NO" />  
                                   <br /><label for="txtRelevanteViolencia"  ClientIDMode="Static" runat="server" id="Label91">Información que considere relevante</label>
                                  <asp:TextBox runat="server"  Height="50px"   CssClass="form-control" id="txtRelevanteViolencia" TextMode="MultiLine" Width="800px"></asp:TextBox>

                         <label for="rdAdultosMayoresSi"  ClientIDMode="Static" runat="server" id="Label92">Adultos mayores </label>
                               <asp:RadioButton GroupName="adul"  id="rdAdultosMayoresSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="adul"  id="rdAdultosMayoresNo" runat="server" ClientIDMode="Static" text="NO" />  
                                  <br /> <label for="txtRelevanteAdultosMayores"  ClientIDMode="Static" runat="server" id="Label93">Información que considere relevante</label>
                                  <asp:TextBox runat="server"  Height="50px"   CssClass="form-control" id="txtRelevanteAdultosMayores" TextMode="MultiLine" Width="800px"></asp:TextBox>
                        
                         <label for="rdAlgunaDiscapacidadSi"  ClientIDMode="Static" runat="server" id="Label94">Personas con algún tipo de discapacidad </label>
                               <asp:RadioButton GroupName="aduldiscapacidad"  id="rdAlgunaDiscapacidadSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="aduldiscapacidad"  id="rdAlgunaDiscapacidadNo" runat="server" ClientIDMode="Static" text="NO" />  
                                  <br /> <label for="txtRelevanteAlgunaDiscapacidad"  ClientIDMode="Static" runat="server" id="Label95">Información que considere relevante</label>
                                  <asp:TextBox runat="server"  Height="50px"   CssClass="form-control" id="txtRelevanteAlgunaDiscapacidad" TextMode="MultiLine" Width="800px"></asp:TextBox>
                        
                         <label for="rdHurefanasSi"  ClientIDMode="Static" runat="server" id="Label96">Personas con enfermedades huérfanas</label>
                               <asp:RadioButton GroupName="adulh"  id="rdHurefanasSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="adulh"  id="rdHurefanasNo" runat="server" ClientIDMode="Static" text="NO" />  
                                   <br /> <label for="txtRelevanteHuerfanas"  ClientIDMode="Static" runat="server" id="Label97">Información que considere relevante</label>
                                  <asp:TextBox runat="server" Height="50px"  CssClass="form-control" id="txtRelevanteHuerfanas" TextMode="MultiLine" Width="800px"></asp:TextBox>
                        
                        <asp:panel runat="server" Visible="false" ID="pnlValidacionVulnerabilidad">
                            <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label115">Observaciones validación </label>
                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionVulnerabilidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </asp:panel>

                     <hr class="alert-danger" />
                        <label for="rdInteresSaludSi"  ClientIDMode="Static" runat="server" id="Label134">la tecnología es de interes en salud pública? (Plan Decenal de Salud Pública 2012-2021)</label>
                               <asp:RadioButton GroupName="infancia" id="rdInteresSaludSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="infancia" id="rdInteresSaludNo" runat="server" ClientIDMode="Static" text="NO" /> 
                        <br /> <label for="txtRelevanteHuerfanas"  ClientIDMode="Static" runat="server" id="Label135">Observaciones</label>
                                  <asp:TextBox runat="server"  CssClass="form-control" Height="50px" id="txtObservacionesInteresSalud" TextMode="MultiLine" Width="800px"></asp:TextBox>
                        
                        <asp:panel runat="server" Visible="false" ID="pnlValidacionInteresSalud">
                            <label for="txtValidacionInteresSalud" ClientIDMode="Static" runat="server" id="Label136">Observaciones validación </label>
                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtVAlidacionInteresSalud" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </asp:panel>
                    </fieldset>
                   
                    <fieldset>
                        <legend>Recursos adicionales para el uso de la tecnología </legend>
                        <br />
                         <label for="rdMedicamentoAdicionalSi"  ClientIDMode="Static" runat="server" id="Label40b">Medicamentos </label>
                               <asp:RadioButton GroupName="adicionalmedicamento" onchange="Ajustarcheck();" id="rdMedicamentoAdicionalSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="adicionalmedicamento" onchange="Ajustarcheck();" id="rdMedicamentoAdicionalNo" runat="server" ClientIDMode="Static"  text="NO" />  
                        <div id="divMedicamentoAdicional"  style="display:none;">
                            
                            <label for="txtRecursoAdicionalMedicamento"  ClientIDMode="Static" runat="server" id="Label63">Nombre del recurso adicional</label>
                            <asp:TextBox runat="server"  CssClass="form-control" id="txtRecursoAdicionalMedicamento" TextMode="SingleLine" Width="800px"></asp:TextBox>

                            <asp:panel runat="server" Visible="false" ID="pnlValidacionMedicamentoAdicional"> 
                                <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label109">Observaciones validación </label>
                                <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionMedicamentoAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:panel>
                        </div>
                        
                        <br />
                    <label for="rdDispositivoAdicionalSi"  ClientIDMode="Static" runat="server" id="Label64">Dispostivos </label>
                               <asp:RadioButton GroupName="adicionaldispositivo" onchange="Ajustarcheck();" id="rdDispositivoAdicionalSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="adicionaldispositivo" onchange="Ajustarcheck();" id="rdDispositivoAdicionalNo" runat="server" ClientIDMode="Static"  text="NO" />  
                        <div id="divDispositivoAdicional"  style="display:none;">
                            <label for="txtRecursoAdicionalDispositivo"  ClientIDMode="Static" runat="server" id="Label65">Nombre del recurso adicional</label>
                            <asp:TextBox runat="server"  CssClass="form-control" id="txtRecursoAdicionalDispositivo" TextMode="SingleLine" Width="800px"></asp:TextBox>
                            
                            <asp:panel runat="server" Visible="false" ID="pnlVaildacionDispositivoAdicional"> 
                                <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label110">Observaciones validación </label>
                                <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtVaildacionDispositivoAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:panel>
                        </div>
                        
                        <br />
  <label for="rdInVitroAdicionalSi"  ClientIDMode="Static" runat="server" id="Label66">Reactivo In Vitro </label>
                               <asp:RadioButton GroupName="adicionalinvitro" onchange="Ajustarcheck();" id="rdInVitroAdicionalSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="adicionalinvitro" onchange="Ajustarcheck();" id="rdInVitroAdicionalNo" runat="server" ClientIDMode="Static"  text="NO" />  
                        <div id="divInvitroAdicional"  style="display:none;">
                            <label for="txtRecursoAdicionalInvitro"  ClientIDMode="Static" runat="server" id="Label67">Nombre del recurso adicional</label>
                            <asp:TextBox runat="server"  CssClass="form-control" id="txtRecursoAdicionalInvitro" TextMode="SingleLine" Width="800px"></asp:TextBox>

                            <asp:panel runat="server" Visible="false" ID="pnlValidacionInvitroAdicional"> 
                                <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label111">Observaciones validación </label>
                                <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionInvitroAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:panel>
                        </div>
                        
                        <br />
<label for="rdAgenteBioAdicionalSi"  ClientIDMode="Static" runat="server" id="Label68">Agente Biológico </label>
                               <asp:RadioButton GroupName="adicionalagebio" onchange="Ajustarcheck();" id="rdAgenteBioAdicionalSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="adicionalagebio" onchange="Ajustarcheck();" id="rdAgenteBioAdicionalNo" runat="server" ClientIDMode="Static"  text="NO" />  
                        <div id="divBioAdicional"  style="display:none;">
                                   <label for="txtRecursoAdicionalAgebio"  ClientIDMode="Static" runat="server" id="Label69">Nombre del recurso adicional</label>
                                  <asp:TextBox runat="server"  CssClass="form-control" id="txtRecursoAdicionalAgebio" TextMode="SingleLine" Width="800px"></asp:TextBox>

                            <asp:panel runat="server" Visible="false" ID="pnlVAidacionAgenteBiologico"> 
                                <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label112">Observaciones validación </label>
                                <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtVAidacionAgenteBiologico" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:panel>
                        </div>
                        
                        <br />
   <label for="rdproductoBioAdicionalSi"  ClientIDMode="Static" runat="server" id="Label70">Producto Biológico </label>
                               <asp:RadioButton GroupName="adicionalabiopro" onchange="Ajustarcheck();" id="rdproductoBioAdicionalSi" runat="server" ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="adicionalabiopro" onchange="Ajustarcheck();" id="rdproductoBioAdicionalNo" runat="server" ClientIDMode="Static"  text="NO" />  
                        <div id="divBioProAdicional"  style="display:none;">
                                   <label for="txtRecursoAdicionalAgeproducto"  ClientIDMode="Static" runat="server" id="Label71">Nombre del recurso adicional</label>
                                  <asp:TextBox runat="server"  CssClass="form-control" id="txtRecursoAdicionalAgeproducto" TextMode="SingleLine" Width="800px"></asp:TextBox>

                            <asp:panel runat="server" Visible="false" ID="pnlValidacionProdcutoBilogico">
                                <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label113">Observaciones validación </label>
                                <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionProdcutoBilogico" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:panel>
                        </div>

                      
                        <br />
                          <label for="rdAdicionalOtroSi"  ClientIDMode="Static" runat="server" id="Label74">Otro </label>
                               <asp:RadioButton GroupName="otroadicional" onchange="Ajustarcheck();" id="rdAdicionalOtroSi" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="otroadicional" onchange="Ajustarcheck();" id="rdAdicionalOtroNo"  runat="server"  
                                   ClientIDMode="Static" text="NO" />  
                        <div id="divcAdicionalOtro"  style="display:none;">
                                   <label for="txtOtroAdicional"  ClientIDMode="Static" runat="server" id="Label75">Especifique </label>
                                  <asp:TextBox runat="server"  CssClass="form-control" id="txtOtroAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                            <asp:panel runat="server" Visible="false" ID="pnlVaidacionOtro">
                                <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label114">Observaciones validación </label>
                                <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtVaidacionOtro" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                            </asp:panel>
                        </div>

                    </fieldset>
                    <br>
                    <fieldset>
                        <legend>Comparadores o tecnología(s) para la mísma indicación</legend>
                       
                           <label for="txtComparador"  ClientIDMode="Static" runat="server" id="Label49">Nombre del comparador (si es más de uno separelo por ";")  </label>
                                    <asp:TextBox  runat="server" Text=""   type="text" name="name" ID="txtComparador" MaxLength="600"  CssClass="form-control" ClientIDMode="Static"   />
    

                           <label for="txtCodigoATCComparador"  ClientIDMode="Static" runat="server" id="Label50">Código ATC/CUPS  (si es más de uno separelo por ";") </label>
                                    <asp:TextBox  runat="server" Text=""   type="text" name="name" ID="txtCodigoATCComparador" MaxLength="600"  CssClass="form-control" ClientIDMode="Static"   />
    

                           <label for="txtCoberturaPbsupc"  ClientIDMode="Static" runat="server" id="Label51">Cobertura en el PBSUPC  (si es más de uno separelo por ";")  </label>
                                    <asp:TextBox  runat="server" Text=""   type="text" name="name" ID="txtCoberturaPbsupc" MaxLength="600"  CssClass="form-control" ClientIDMode="Static"   />
    
                        <asp:panel runat="server" Visible="false" ID="pnlValidacionComparador">
                            <label for="txtValidacionComparador"  ClientIDMode="Static" runat="server" id="Label38">Observaciones validación </label>
                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionComparador" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </asp:panel>
                    </fieldset>
                    <br>
                    <fieldset>
                               <legend>Información adicional</legend>
                               <label for="chkAdjuntaEvidenciaSi"  ClientIDMode="Static" runat="server" id="Label62">Adjunta Evidencia </label>
                               <asp:RadioButton GroupName="adjevidencia" onchange="Ajustarcheck();" id="chkAdjuntaEvidenciaSi" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="adjevidencia" onchange="Ajustarcheck();" id="chkAdjuntaEvidenciaNo" runat="server"  
                                   ClientIDMode="Static" text="NO" />
                               <div id="divAdjuntaEvidencia" style="display:none;">
                                   
                                   <label for="txtObservacionesAdicional"  ClientIDMode="Static" runat="server" id="Label10">Observaciónes evidencia </label>
                                   <asp:TextBox runat="server"  CssClass="form-control" id="txtObservacionesAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>


                                <label for="divUploadAdicional" ClientIDMode="Static" runat="server" id="Label5a">Adjunte el archivo: <br />  * Debe ser un archivo tipo: .jpg,.jpeg,.gif,.png,.pdf,.bmp <br /> * Tamaño maximo: 50 Mb</label>
                                     <div style=''>
                                        <div id='div4b' class='upload_input field_input' >
                                              <input type='file' name='file' id='FileUpload4' style='display:none' />  
                                              <input type='button'onclick='FileUpload4.click();' style='width:110px;height:30px;' id='btnFileUploadText4' value='Cargar Archivo' />
                                              <a runat="server" target="_blank"   ClientIDMode="Static" id="lnkArchivo4" href=''></a>
                                        </div>
                                        <div class='progressbar' id='progressbar4' style='width:100px;display:none;min-height:10px;background-color:green;'>
                                        </div>

                                         <asp:panel runat="server" Visible="false" ID="pnlValidacionInfoAdicional">                    
                                           <label for="txtObsrvacionesValidacion"  ClientIDMode="Static" runat="server" id="Label108">Observaciones validación </label>
                                            <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionInfoAdicional" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                         </asp:panel>
                               </div>
                        </div>
                         
                        
                         </fieldset>
                  <br/><br/>
                    <fieldset>
                        <legend></legend>

                               <br />
                               <label for="chkConflictoInteres"  ClientIDMode="Static" runat="server" id="Label25a">Presenta algún conflicto de intereses </label>
                               
                               <asp:RadioButton GroupName="conflicto" onchange="Ajustarcheck();" id="chkConflictoInteres" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="conflicto" onchange="Ajustarcheck();" id="chkNoConflictoInteres" runat="server"  
                                   ClientIDMode="Static" text="NO" />  


                               <div id="divConflicto" style="display:none;">
                                   <label for="txtConflicto"  ClientIDMode="Static" runat="server" id="Label1a">Describa el conflicto de interes </label>
                                <asp:TextBox runat="server"  CssClass="form-control" id="txtConflicto" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                  </div>

                           </fieldset>
                    <br />
                    <p>   Obligatoriamente los actores industria relacionada a la salud y sociedades 
                            científicas deben diligenciar los siguientes campos, los demás actores lo podrán hacer de forma opcional (voluntaria)</p>
                    <div id="medicamentosFrm3"  style="display:none;">
                    <fieldset>
                        <legend>Descripción de la tecnología en caso de ser medicamento</legend>

                             <label for="cmbTipoNominacionMedicamento"  ClientIDMode="Static" runat="server" id="Label52">Seleccione la opción acorde al medicamento propuesto de la lista desplegable. Si necesita realizar alguna aclaración utilice para ello el campo observaciones </label>
                             <asp:DropDownList runat="server" name="name"  ID="cmbTipoNominacionMedicamento" CssClass="form-control" DataSourceID="SqlTipoNominacionMedicamento" DataTextField="NOMBRE_TIPO_NOMINACION_MEDICAMENTO" DataValueField="COD_TIPO_NOMINACION_MEDICAMENTO" >
                             </asp:DropDownList>
                             <asp:SqlDataSource ID="SqlTipoNominacionMedicamento" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="SELECT [COD_TIPO_NOMINACION_MEDICAMENTO], [NOMBRE_TIPO_NOMINACION_MEDICAMENTO] FROM [TIPO_NOMINACION_MEDICAMENTO] ORDER BY [NOMBRE_TIPO_NOMINACION_MEDICAMENTO]"></asp:SqlDataSource>

                             <label for="txtObstipoTecnologia"  ClientIDMode="Static" runat="server" id="Label53">Observaciones </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtObstipoTecnologia" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                   
                             <label for="txtNumCasasFarmaceuticas"  ClientIDMode="Static" runat="server" id="Label56">¿En su conocimiento cuantas casas farmacéuticas comercializan el principio activo? </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtNumCasasFarmaceuticas" TextMode="Number" Width="800px" ></asp:TextBox>
                        
                             <label for="txtNumAnosMedicamento"  ClientIDMode="Static" runat="server" id="Label57">Número de años que lleva comercializando el medicamento en Colombia </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtNumAnosMedicamento" TextMode="Number" Width="800px" ></asp:TextBox>
                        
                             <label for="txtCodCumMedicamento"  ClientIDMode="Static" runat="server" id="Label72">Códigos CUM correspondientes al laboratorio que nomina el medicamento, separando cada código CUM por ";". Ejemplo: 12345678-01;12345678-02 (Los códigos deben ser validados en la herramienta definida por el INVIMA, disponible en el siguiente <a target="_blank" href="https://enlinea.invima.gov.co/rs/cum/comprob_cum.jsp">link </a>) </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtCodCumMedicamento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                       </fieldset>
                        <fieldset>
                        <legend>Registre la dosis, régimen de dosificación, vía de administración y duración promedio de uso del medicamento por paciente, recomendados para la indicación objeto de la nominación (en el caso de tratamiento crónico registre indefinido).</legend>
                        <label for="txtDosisPediatraMedicamentos"  ClientIDMode="Static" runat="server" id="Label73">Pediatría </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtDosisPediatraMedicamentos" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                        <label for="txtDosisAdultosMedicamentos"  ClientIDMode="Static" runat="server" id="Label76">Adultos </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtDosisAdultosMedicamentos" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                           
                         <label for="txtIndicacionMedicamento"  ClientIDMode="Static" runat="server" id="Label78">Registre para la indicación objeto de la solicitud </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtIndicacionMedicamento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                   
                   
                         </fieldset>
                        <fieldset>
                            <legend>Registre para la indicación objeto de la solicitud</legend>
                             <label for="txtPrecioPorFormaFarma"  ClientIDMode="Static" runat="server" id="Label77">Precio por forma farmacéutica   </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtPrecioPorFormaFarma" TextMode="Number" Width="800px" ></asp:TextBox>
                        
                             <label for="txtPrecioPorConcentracion"  ClientIDMode="Static" runat="server" id="Label79">Precio por concentración   </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtPrecioPorConcentracion" TextMode="Number" Width="800px" ></asp:TextBox>
                        
                             <label for="txtPrecioPorPresentacion"  ClientIDMode="Static" runat="server" id="Label80">Precio por presentación comercial asociada para cada CUM </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtPrecioPorPresentacion" TextMode="Number" Width="800px" ></asp:TextBox>
                            <br />
                            <p>Valor total COP (actualizado al año de nominación) del tratamiento por paciente (En el caso de tratamientos mayores a un mes o tratamientos crónicos, es necesario indicar el valor total promedio por paciente en un mes y en un año)  </p>
                           <br />
                            
                        
                             <label for="txtValorCOPMedicamento"  ClientIDMode="Static" runat="server" id="Label82">Valor total COP por tratamiento (por persona):</label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtValorCOPMedicamento" TextMode="Number" Width="800px" ></asp:TextBox>

                            
                             <label for="txtUnidadMedidaMedicamento"  ClientIDMode="Static" runat="server" id="Label83">Unidad de medida (Día, Mes, Año, Ciclo)</label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtUnidadMedidaMedicamento" Width="800px" ></asp:TextBox>
                        </fieldset>
                        <fieldset>
                            <legend>Señale los aspectos relevantes de seguridad</legend>
                              <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkReaccionesAdversas" runat="server"  ClientIDMode="Static" text="Reacciones adversas" />  
                                           <br>   
                                    <div id="divReaccionesAdversas" style="display:none;">
                                        <label for="txtReaccionesAdversas"  ClientIDMode="Static" runat="server" id="Label81">Descripción </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtReaccionesAdversas" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                    </div>
                            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkContraindicaciones" runat="server"  ClientIDMode="Static" text="Contraindicaciones" />  
                                           <br>   
                                    <div id="divContraindicaciones" style="display:none;">
                                        <label for="txtContraindicaciones"  ClientIDMode="Static" runat="server" id="Label117">Descripción </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtContraindicaciones" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                    </div>
                            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkAdvertenciasPrecauciones" runat="server"  ClientIDMode="Static" text="Advertencias y precauciones" />  
                                           <br>   
                                    <div id="divAdvertenciasPrecauciones" style="display:none;">
                                        <label for="txtAdvertenciasPrecauciones"  ClientIDMode="Static" runat="server" id="Label137">Descripción </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtAdvertenciasPrecauciones" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                    </div>
                            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkInteracciones" runat="server"  ClientIDMode="Static" text="Interacciones" />  
                                           <br>   
                                    <div id="divInteracciones" style="display:none;">
                                        <label for="txtInteracciones"  ClientIDMode="Static" runat="server" id="Label138">Descripción </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtInteracciones" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                    </div>
                            <br> <asp:CheckBox  onchange="Ajustarcheck();" id="chkInterrupcion" runat="server"  ClientIDMode="Static" text="Interrupción del uso de la tecnología propuesta" />  
                                           <br>   
                                    <div id="divInterrupcion" style="display:none;">
                                        <label for="txtInterrupcion"  ClientIDMode="Static" runat="server" id="Label139">Descripción </label>
                                        <asp:TextBox runat="server"  CssClass="form-control" id="txtInterrupcion" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                    </div>
                            <br />
                             <label for="rdListadoEscencialesSi"  ClientIDMode="Static" runat="server" id="Label140">Indique si la tecnología hace parte del Listado de Medicamentos Esenciales de la OMS en caso afirmativo registre el número de la versión consultada en el campo observaciones. </label>
                        <asp:RadioButton GroupName="EfectividadClinicax" onchange="Ajustarcheck();" id="rdListadoEscencialesSi" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                        <asp:RadioButton GroupName="EfectividadClinicax" onchange="Ajustarcheck();" id="rdListadoEscencialesNo" runat="server"  
                                   ClientIDMode="Static" text="NO" />  

                            <label for="txtObservacionesListadoEscencial"  ClientIDMode="Static" runat="server" id="Label141">Observaciones </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtObservacionesListadoEscencial" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </fieldset>
                        <fieldset>
                            <legend>Si la tecnología ha sido recomendada por las Guías de Práctica Clínica oficiales, indique el nombre de la GPC y transcriba la recomendación completa.</legend>
                        
                           <label for="txtNombreGPCMedicamento"  ClientIDMode="Static" runat="server" id="Label142">Nombre de la GPC  </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtNombreGPCMedicamento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                       
                               <label for="txtRecomendacionMedicamentoGPC"  ClientIDMode="Static" runat="server" id="Label143">Recomendación </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtRecomendacionMedicamentoGPC" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                       
                               <label for="txtGradoRecomendacionMedicamentoGPC"  ClientIDMode="Static" runat="server" id="Label144">Grado de recomendación </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtGradoRecomendacionMedicamentoGPC" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </fieldset>
                    </div>
                     <br/><br/>

                     <div id="procedimientosFrm3"  style="display:none;">
                         <fieldset>
                      <legend>Descripción de la tecnología en caso de ser procedimiento</legend>

                       <label for="rdNuevoProcedimientoSi"  ClientIDMode="Static" runat="server" id="Label145">¿El procedimiento nominado corresponde a una nueva indicación de un procedimiento ya cubierto en el Plan de Beneficios? (Especifique cual en el campo observaciones) </label>
                               
                               <asp:RadioButton GroupName="conflictoxx" onchange="Ajustarcheck();" id="rdNuevoProcedimientoSi" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                               <asp:RadioButton GroupName="conflictoxx" onchange="Ajustarcheck();" id="rdNuevoProcedimientoNo" runat="server"  
                                   ClientIDMode="Static" text="NO" />  
                         <br />
                         <label for="txtObservacionesNuevoProcedimiento"  ClientIDMode="Static" runat="server" id="Label146">Observaciones </label>
                                <asp:TextBox runat="server"  CssClass="form-control" id="txtObservacionesNuevoProcedimiento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                            <label for="txtIpsREalizanProcedimiento"  ClientIDMode="Static" runat="server" id="Label147">En su conocimiento, ¿cuáles IPS realizan el procedimiento actualmente en Colombia? </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtIpsREalizanProcedimiento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                             <label for="txtNumAnosProcedimento"  ClientIDMode="Static" runat="server" id="Label148">Número de años que lleva siendo utilizado el procedimiento nominado en Colombia </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtNumAnosProcedimento" TextMode="Number" Width="800px" ></asp:TextBox>
                         
                             <label for="txtFrecuenciaProcedimiento"  ClientIDMode="Static" runat="server" id="Label149">Indique la frecuencia de aplicación del procedimiento en un paciente </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtFrecuenciaProcedimiento"  Width="800px" ></asp:TextBox>

                             <label for="txtFrecuenciaAplicacionProcedimiento"  ClientIDMode="Static" runat="server" id="Label150">Indique la frecuencia de aplicación del procedimiento en un paciente</label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtFrecuenciaAplicacionProcedimiento"  Width="800px" ></asp:TextBox>

                         
                             <label for="txtDuracionProcedimiento"  ClientIDMode="Static" runat="server" id="Label151">Indique la duración del procedimiento</label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtDuracionProcedimiento"  Width="800px" ></asp:TextBox>

                          <label for="txtPrecioDuracionProcedimiento"  ClientIDMode="Static" runat="server" id="Label152">Indique el precio de la realización del  procedimiento (Valor en COP actualizado al año de nominación) </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtPrecioDuracionProcedimiento" TextMode="Number" Width="800px" ></asp:TextBox>
                         </fieldset>
                         <fieldset>
                            <legend>Si la tecnología ha sido recomendada por las Guías de Práctica Clínica oficiales, indique el nombre de la GPC y transcriba la recomendación completa..</legend>
                        
                           <label for="txtNombreGPCProcedimiento"  ClientIDMode="Static" runat="server" id="Label153">Nombre de la GPC  </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtNombreGPCProcedimiento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                       
                               <label for="txtRecomendacionProcedimientoGPC"  ClientIDMode="Static" runat="server" id="Label154">Recomendación </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtRecomendacionProcedimientoGPC" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                       
                               <label for="txtGradoRecomendacionProcedimientoGPC"  ClientIDMode="Static" runat="server" id="Label155">Grado de recomendación </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtGradoRecomendacionProcedimientoGPC" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        </fieldset>
                         <fieldset>
                             <legend></legend>
                              <label for="txtdesenlacesProcedimiento"  ClientIDMode="Static" runat="server" id="Label156">Describa los desenlaces esperados con el uso de la TSN (incluya desenlaces duros, blandos y subrogados de acuerdo a las características clínicas). </label>
                                <asp:TextBox runat="server"  CssClass="form-control" id="txtdesenlacesProcedimiento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                                <label for="txtResultadosSeguridadProcedimiento"  ClientIDMode="Static" runat="server" id="Label157">Describa los resultados de seguridad y tolerancia del procedimiento nominado. </label>
                                <asp:TextBox runat="server"  CssClass="form-control" id="txtResultadosSeguridadProcedimiento" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>

                         </fieldset>
                  
                     </div>

                    <fieldset>
                        <legend>Información que sustenta la nominación </legend>
                            <label for="txtTamanoPoblacion"  ClientIDMode="Static" runat="server" id="Label158">Tamaño de la población afectada con el problema de salud en la población colombiana. (Si requiere discrimine por grupo etario y género) </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtTamanoPoblacion" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        
                            <label for="txtTamanoPoblacionColombiana"  ClientIDMode="Static" runat="server" id="Label159">Tamaño de la población colombiana que  se beneficia con el uso de la TSN. (Si requiere discrimine por grupo etario y género) </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtTamanoPoblacionColombiana" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        
                            <label for="txtRElacionTsnCArgaEnfermedad"  ClientIDMode="Static" runat="server" id="Label160">Describa la relación de la TSN con la carga de enfermedad para Colombia según los resultados del Informe: Estimación de la Carga de enfermedad para Colombia 2010. Emplee en su descripción datos de AVISAS por mortalidad, por discapacidad y totales, discriminados por grupo etario y género.  
(Información disponible en el siguiente <a href="http://www.javeriana.edu.co/documents/12789/4434885/Carga+de+Enfermedad+Colombia+2010.pdf/e0dbfe7b-40a2-49cb-848e-bd67bf7bc62e">enlace</a>)
 </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtRElacionTsnCArgaEnfermedad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        
                           <label for="txtBeneficios"  ClientIDMode="Static" runat="server" id="Label161">Describa los beneficios para el paciente con el uso de la TSN. 
(Por ejemplo: Reducción del número de dosis diarias administradas, cambio de vía de administración que facilita la adherencia a la terapia)
 </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtBeneficios" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        <br />
                          <label for="rdTSNReduceMortalidadSi"  ClientIDMode="Static" runat="server" id="Label162">La TSN contribuye directamente a la reducción de la mortalidad. En caso afirmativo registre el indicador y resultado que demuestre la disminución de la tasa de mortalidad asociada al uso de la TSN. </label>
                        <asp:RadioButton GroupName="EfectividadClinicaxxx" onchange="Ajustarcheck();" id="rdTSNReduceMortalidadSi" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                        <asp:RadioButton GroupName="EfectividadClinicaxxx" onchange="Ajustarcheck();" id="rdTSNReduceMortalidadNo" runat="server"  
                                   ClientIDMode="Static" text="NO" />  
                         <label for="txtTSNReduceMortalidad"  ClientIDMode="Static" runat="server" id="Label163">Observaciones </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtTSNReduceMortalidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        <br />
                          <label for="rdTSNReduceMortalidadSi"  ClientIDMode="Static" runat="server" id="Label164">La TSN contribuye directamente a la mejora de la condición de discapacidad. En caso afirmativo, registre el indicador y resultado que demuestre la mejora de la condición de discapacidad asociada al uso de la TSN. </label>
                        <asp:RadioButton GroupName="rdTSNMejoraDiscapacidadSix" onchange="Ajustarcheck();" id="rdTSNMejoraDiscapacidadSi" runat="server"  
                                   ClientIDMode="Static" text="SI" />  
                        <asp:RadioButton GroupName="rdTSNMejoraDiscapacidadSix" onchange="Ajustarcheck();" id="rdTSNMejoraDiscapacidadNo" runat="server"  
                                   ClientIDMode="Static" text="NO" />  
                         <label for="txtTSNMejoraDiscapacidad"  ClientIDMode="Static" runat="server" id="Label165">Observaciones </label>
                             <asp:TextBox runat="server"  CssClass="form-control" id="txtTSNMejoraDiscapacidad" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                        
                    </fieldset>
                    <fieldset>
                        <legend></legend>
                        <p>
                        Obligatoriamente los actores industria relacionada a la salud y sociedades 
                            científicas deben diligenciar los siguientes formatos, los demás actores lo podrán hacer de forma opcional (voluntaria). 
                        </p>
                                        
                                

                                         <label for="" ClientIDMode="Static" runat="server" id="Label16">Adjunte el archivo: con el <asp:hyperlink runat="server" id="Hyperlink1" text="Formato 4" target="_blank" navigateUrl="../../documentos/Formato 4 Formato para la presentación de reportes.pdf"></asp:hyperlink>   diligenciado</label>
                                       <div style=''>
                                            <div id='div6b' class='upload_input field_input' >
                                                <input type='file' name='file' id='FileUpload6' style='display:none' />  
                                                <input type='button'onclick='FileUpload6.click();' style='width:110px;height:30px;' id='btnFileUploadText6' value='Cargar Archivo' />
                                                <a runat="server" target="_blank"   ClientIDMode="Static" id="lnkArchivo6" href=''></a>
                                            </div>
                                            <div class='progressbar' id='progressbar6' style='width:100px;display:none;min-height:10px;background-color:green;'>
                                            </div>

                                           <asp:panel runat="server" Visible="false" ID="pnlValidacionFormato4">
                                               <label for="txtValidacionFormato4"  ClientIDMode="Static" runat="server" id="Label28">Observaciones validación </label>
                                               <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionFormato4" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                           </asp:panel>
                                        </div>

                                        <label for="" ClientIDMode="Static" runat="server" id="Label54">Adjunte el archivo: con el <asp:hyperlink runat="server" id="Hyperlink3" text="Formato 5" target="_blank" navigateUrl="../../documentos/Formato 5 Criterios verificación calidad.pdf"></asp:hyperlink>   diligenciado</label>
                                       <div style=''>
                                            <div id='div7b' class='upload_input field_input' >
                                                <input type='file' name='file' id='FileUpload7' style='display:none' />  
                                                <input type='button'onclick='FileUpload7.click();' style='width:110px;height:30px;' id='btnFileUploadText7' value='Cargar Archivo' />
                                                <a runat="server" target="_blank"   ClientIDMode="Static" id="lnkArchivo7" href=''></a>
                                            </div>
                                            <div class='progressbar' id='progressbar7' style='width:100px;display:none;min-height:10px;background-color:green;'>
                                            </div>

                                           <asp:panel runat="server" Visible="false" ID="pnlValidacionFormato5">
                                               <label for="txtValidacionFormato5"  ClientIDMode="Static" runat="server" id="Label55">Observaciones validación </label>
                                               <asp:TextBox  runat="server"   CssClass="form-control textoValidacion" Readonly="true"  id="txtValidacionFormato5" TextMode="MultiLine" Width="800px" Height="80px"></asp:TextBox>
                                           </asp:panel>
                                        </div>

                   </fieldset>

                     </div>
                             <div id="pnlAcepto">
                                    <div class="form-group">
                                    <asp:Label ID="LblValidacionCampos" runat="server" ForeColor="#E4335C" Font-Size="14pt" />
                                </div>

                                <div class="form-group">
                                    <asp:Button runat="server" ClientIDMode="Static" 
                                        OnClientClick="return confirm('Esta seguro de enviar el formulario una vez enviado no podra realizar ningun ajuste');"
                                        type="submit" ID="btnGuardarContinuar" Text="Guardar y enviar" CssClass="boton2"
                                         OnClick="btnGuardarContinuar_Click" />

                                    <asp:Button runat="server" visible="false"
                                        ClientIDMode="Static" OnClick="btnGuardar_Click" type="submit" ID="btnGuardar" Text="Guardar" CssClass="boton2"    />
                                   </div>
                            </div> 
                </div>
            </div>
        </div>
</asp:Content>


