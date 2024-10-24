﻿<%@ Page Language="C#" MasterPageFile="~/frm/master/masterb.Master" AutoEventWireup="true" CodeBehind="frmExclusiones_EtapaI_Solicitud.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmExclusiones_EtapaI_Solicitud" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link href="../../Scripts/fancy/source/fancyMins.css" rel="stylesheet" />
    <script src="../../blueimp/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../blueimp/jquery.iframe-transport.js" type="text/javascript"></script>
    <script src="../../blueimp/jquery.fileupload.js" type="text/javascript"></script>


    <script src="../../blueimp/jquery.fileupload.js" type="text/javascript"></script>
    <style>
        .hidden {
            display: none;
        }

        .container-check {
            margin-bottom: 0.5rem; /* Espacio inferior entre los contenedores de checkboxes */
        }



        .form-check-input {
            cursor: pointer; /* Cursor al pasar sobre el checkbox */
        }

        .form-check-label {
            font-size: 12px; /* Tamaño de fuente de la etiqueta */
            cursor: pointer; /* Cursor al pasar sobre la etiqueta */
        }

        /* Estilo adicional para asegurar que el checkbox y la etiqueta estén alineados verticalmente */
        .d-flex {
            display: flex;
            align-items: center;
        }

            /* Asegúrate de que el checkbox y el label estén en un contenedor flexible */
            .d-flex > * {
                flex: 1; /* Cada hijo toma el mismo ancho por defecto */
            }

        /* Ajusta los anchos del checkbox y la etiqueta */
        .form-check-input {
            flex: 0 0 30%; /* El checkbox toma el 30% del ancho */
            margin-right: 0.5rem; /* Espacio entre el checkbox y la etiqueta */
            cursor: pointer; /* Cursor al pasar sobre el checkbox */
        }

        .form-check-label {
            flex: 0 0 70%; /* La etiqueta toma el 70% del ancho */
            font-size: 14px; /* Tamaño de fuente de la etiqueta */
            cursor: pointer; /* Cursor al pasar sobre la etiqueta */
            margin-left: 0.5rem; /* Espacio a la izquierda de la etiqueta */
        }

        .error-validacion {
            color: #721c24;
            background-color: #f8d7da;
            border-color: #f5c6cb;
        }

            .error-validacion p {
                margin: 5px 0;
            }

        .revisado {
            color: #155724;
            background-color: #d4edda;
            border-color: #c3e6cb;
        }

        .btn {
            flex-shrink: 0;
        }

        /*.error-validacion {
            color: red;
            display: block;
        }

        .validation-message {
            display: none;*/ /* Ocultar mensajes de validación hasta que sean necesarios */
        /*}*/
    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label runat="server" ID="lblCodNominacionProceso" ClientIDMode="Static" Style="display: none;"></asp:Label>
    <asp:Panel ID="pnlMensajeNoNominador" runat="server">
        <div class="row">
            <div class="tagline">
                <div class="container">
                    <h2 class="tag">Por la plataforma sólo nominan las agremiaciones y asociaciones científicas</h2>

                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlFormulario" runat="server">
        <div class="container">
            <div id="panel1">
                <h1>Listado de Tecnologías Excluidas</h1>
                <h3>Para buscar una tecnología previemente excluida, digite el nombre (o una parte) de la tecnología y oprima le tecla ENTER.</h3>
                <div class="form-group">

                    <div class="d-flex align-items-center">
                        <input type="text" id="filtro-tecnologias" class="form-control me-2" placeholder="Buscar tecnología...🔎" />
                    </div>
                </div>



                <hr />
                <table class="table table-striped text-center" id="tabla-tecnologias">
                    <thead>
                        <tr>
                            <th>Tecnología</th>
                            <th>Vigencia</th>
                            <th>Acción</th>
                        </tr>
                    </thead>
                    <tbody>
                        <!-- Aquí se inyectarán las filas de la tabla con jQuery -->
                    </tbody>
                </table>

                <div id="pagination-container" class="d-flex justify-content-center mt-3"></div>
            </div>
            <!-- Panel 2 -->
            <div id="panel2" class="hidden">
                <div class="row">
                    <h3>Tecnología postulada para revisar la exclusión: </h3>
                    <h3><strong id="TecnologiaSeleccionada"></strong></h3>
                </div>
                <div class="row">
                    <h3>Indicaciones</h3>
                    <h4 id="DescripcionSeleccion"></h4>
                    <div id="indicaciones-container">
                        <div id="indicaciones" class="container-check">
                            <!-- Aquí se inyectarán las opciones de checkbox con jQuery -->
                        </div>
                    </div>

                </div>

                <div class="row">
                    <h3>Criterios</h3>
                    <h4>Recuerde que debe revisar TODOS los criteríos de exclusión para enviar la revisión:</h4>
                    <table class="table table-striped" id="tabla-criterios">
                        <thead>
                            <tr>
                                <th>Revisado</th>
                                <th>Criterio</th>
                                <th>Acción</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- Aquí se inyectarán las filas de la tabla con jQuery -->
                        </tbody>
                    </table>

                </div>



                <div class="row">
                    <h3>Conflicto de intereses </h3>
                    <p>
                        La presente declaración tiene por objeto garantizar el ejercicio transparente de la participación ciudadana, así como la imparcialidad de los participantes con derecho a voto en el proceso actual, de modo que se conozcan los posibles conflictos de intereses y su relación de causalidad frente a las opiniones o recomendaciones que incidan en la toma de decisiones relacionadas con las políticas en salud.
                   
                    </p>
                    <p>
                        Las actividades que pueden generar conflicto de intereses son aquellas en las que el juicio del profesional en salud o de un agremiado, agente o actor del sector salud puede estar afectado por un interés primario que incida en su actividad participativa.

                    </p>
                    <h4>Tiene conflictos de Interes?</h4>
                    <div class="row">
                        <div class="col d-flex align-items-center">
                            <input class="form-check-input" type="radio" id="conflictos-intereses-si" name="conflictos-intereses" value="si">
                            <label class="form-check-label ms-2" for="conflictos-intereses-si">Sí</label>
                        </div>
                        <div class="col d-flex align-items-center">
                            <input class="form-check-input" type="radio" id="conflictos-intereses-no" name="conflictos-intereses" value="no" checked>
                            <label class="form-check-label ms-2" for="conflictos-intereses-no">No</label>
                        </div>
                    </div>
                </div>

                <div id="panelConflictos1" class="row hidden ">

                    <h3>Describa el conflicto de intereses teniendo en cuenta los siguientes aspectos: Tipos de conflictos:</h3>

                    <div class="container-check">

                        <div class="row">
                            <div class="col d-flex align-items-center">
                                <input class="form-check-input conflicto-checkbox" type="checkbox" id="conflictoFinanciero">
                                <label class="form-check-label" for="conflictoFinanciero">
                                    Financiero: Cuando el individuo tiene participación en una empresa, organización o equivalente que se relaciona
                                        directamente (socio, accionista, propietario, empleado) o indirectamente (proveedor, asesor, consultor) con las
                                        actividades para las cuales fue convocado a participar.
                                </label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col d-flex align-items-center">
                                <input class="form-check-input conflicto-checkbox" type="checkbox" id="conflictoIntelectual">
                                <label class="form-check-label" for="conflictoIntelectual">
                                    Intelectual: Cuando se tiene un interés intelectual, académico o científico en un tema en particular. La
                                        declaración de este tipo de interés es indispensable para salvaguardar la calidad y objetividad del trabajo
                                        científico.
                                </label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col d-flex align-items-center">
                                <input class="form-check-input conflicto-checkbox" type="checkbox" id="conflictoPertenencia">
                                <label class="form-check-label" for="conflictoPertenencia">
                                    Pertenencia: Derechos de propiedad intelectual o industrial que estén directamente relacionados con las
                                        temáticas o actividades a abordar.
                                </label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col d-flex align-items-center">
                                <input class="form-check-input conflicto-checkbox" type="checkbox" id="conflictoFamiliar">
                                <label class="form-check-label" for="conflictoFamiliar">
                                    Familiar: Cuando alguno de los familiares, hasta el tercer grado de consanguinidad y segundo de afinidad o
                                        primero civil, están relacionados de manera directa o indirecta en los aspectos financiero o intelectual, con las
                                        actividades y temáticas a desarrollar.
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="panelConflictos2" class="row hidden">
                    <h3>Declaración:</h3>
                    <p>
                        He leído y comprendo el objetivo de la declaración de conflicto de intereses.
                       Por lo tanto, en forma espontánea y libre de todo apremio, doy fe acerca de los posibles intereses que podrían afectar mis actuaciones en el proceso al que he sido convocado a participar.
                       Esta declaración también hace referencia a los vínculos y posibles intereses de mis parientes consanguíneos, afines o civiles, durante los últimos dos (2) años.
                    </p>

                    <div class="form-group">
                        <h3>Describa su conflicto de interés</h3>
                        <textarea class="form-control" id="conflictoInteresStr" rows="4" placeholder="Describa aquí su conflicto de interés..."></textarea>
                    </div>

                </div>

                <div class="row">
                    <div class="error-validacion">
                        <p id="errorIndicacion" class="validation-message">Debe seleccionar por lo menos una indicación.</p>
                        <p id="errorCriterio" class="validation-message">Debe revisar todos los criterios.</p>
                        <p id="errorConflicto" class="validation-message">Debe seleccionar si presenta conflicto de interés. </p>
                    </div>
                    <div class="form-group text-right">
                        <button class="btn btn-success" id="btnFinalizar" disabled>Finalizar y Postular</button>
                    </div>
                </div>
                <div class="row">
                    <button id="btn-back" class="btn btn-danger d-flex align-items-center">
                        Regresar al listado de las tecnologías previamente excluídas                   
                    </button>
                </div>
                <hr />

            </div>
        </div>

        <!-- Modal para cargar archivos -->
        <div class="modal fade" id="modalCargarArchivos" tabindex="-1" aria-labelledby="modalLabel" aria-hidden="true" data-bs-backdrop="static" data-bs-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalLabel"></h5>
                        <button id="btn-close-modal-criterios" type="button" class="btn-close align-items-rigth" data-bs-dismiss="modal" aria-label="Close">X</button>
                    </div>
                    <div class="modal-body">
                        <!-- Formulario para cargar archivos -->
                        <form id="formCargarArchivos">
                            <!-- Título: Revisión de -->
                            <div class="mb-3">
                                <label for="tituloRevision" class="form-label">Revisión del criterio</label>
                                <h4 id="CriterioNombre"></h4>
                            </div>

                            <!-- Justificación solicitud revisión -->
                            <div class="mb-3">
                                <label for="justificacionRevision" class="form-label">1. Justificación solicitud revisión:</label>
                                <textarea class="form-control" id="justificacionRevision" rows="3" placeholder="Escribe la justificación" required></textarea>
                            </div>

                            <!-- Cargar archivo -->
                            <div class="mb-3">
                                <label for="archivoCargar" class="form-label">2. Cargue la evidencia, seleccionando el archivo:</label>
                                <div class="custom-file-input">
                                    <input type="file" id="archivoCargar" class="form-control-file" style="display: none;">
                                    <button type="button" class="btn btn-primary" onclick="document.getElementById('archivoCargar').click();">Seleccionar archivo</button>
                                    <span id="nombreArchivo">Ningún archivo seleccionado</span>
                                    <span id="clearIcon" style="display: none; cursor: pointer;">❌</span>

                                </div>
                            </div>


                            <!-- Descripción del archivo -->
                            <div class="mb-3">
                                <label for="descripcionArchivo" class="form-label">3. Ingrese una descripción para el archivo y oprima el botón anexar:</label>
                                <textarea class="form-control" id="descripcionArchivo" rows="2" placeholder="Describe el archivo" required></textarea>
                            </div>
                            <div class="mb-3" style="padding-top: 10px; padding-bottom: 10px">
                                <div class="custom-file-input">
                                    <!-- Botón Anexar -->
                                    <button type="button" class="btn btn-primary" id="btnAnexar">Anexar</button>
                                </div>
                            </div>

                            <!-- Tabla de archivos anexados -->
                            <div class="mt-4">
                                <table class="table" id="tablaArchivosAnexados">
                                    <thead>
                                        <tr>
                                            <th>Archivo</th>
                                            <th>Justificación</th>
                                            <th>Descripción</th>
                                            <th>Acciones</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <!-- Aquí se añadirán dinámicamente las filas de los archivos anexados -->
                                    </tbody>
                                </table>
                            </div>

                            <!-- Botón Finalizar y Postular -->
                            <button type="button" class="btn btn-primary mt-3" id="btnGuardarCriterio" disabled="disabled">Guardar revisión criterio</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>

        <script src="../../js/ExclusionesFormulario.js"></script>


    </asp:Panel>

</asp:Content>


