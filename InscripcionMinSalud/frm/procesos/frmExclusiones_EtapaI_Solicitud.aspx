<%@ Page Language="C#" MasterPageFile="~/frm/master/masterb.Master" AutoEventWireup="true" CodeBehind="frmExclusiones_EtapaI_Solicitud.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmExclusiones_EtapaI_Solicitud" %>


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
    </style>

    <script src="../../js/ExclusionesFormulario.js"></script>

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

                <div class="form-group">
                    <div class="d-flex align-items-center">
                        <input type="text" id="filtro-tecnologias" class="form-control me-2" placeholder="Buscar tecnología..." />
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

                <h3>Tecnologia Seleccionada </h3>
                <h3><strong id="TecnologiaSeleccionada"></strong></h3>
                <div class="row">
                    <h3>Indicaciones</h3>
                    <div id="indicaciones-container">
                        <div id="indicaciones" class="container-check">
                            <!-- Aquí se inyectarán las opciones de checkbox con jQuery -->
                        </div>
                    </div>

                </div>

                <div class="row">
                    <h3>Criterios</h3>
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
                </div>

                <div class="row">
                    <h3>Describa el conflicto de intereses teniendo en cuenta los siguientes aspectos: Tipos de conflictos:</h3>

                    <div class="container-check">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" id="conflictoFinanciero">
                                    <label class="form-check-label" for="conflictoFinanciero">
                                        Financiero: Cuando el individuo tiene participación en una empresa, organización o equivalente que se relaciona
                                        directamente (socio, accionista, propietario, empleado) o indirectamente (proveedor, asesor, consultor) con las
                                        actividades para las cuales fue convocado a participar.
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" id="conflictoIntelectual">
                                    <label class="form-check-label" for="conflictoIntelectual">
                                        Intelectual: Cuando se tiene un interés intelectual, académico o científico en un tema en particular. La
                                        declaración de este tipo de interés es indispensable para salvaguardar la calidad y objetividad del trabajo
                                        científico.
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" id="conflictoPertenencia">
                                    <label class="form-check-label" for="conflictoPertenencia">
                                        Pertenencia: Derechos de propiedad intelectual o industrial que estén directamente relacionados con las
                                        temáticas o actividades a abordar.
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" id="conflictoFamiliar">
                                    <label class="form-check-label" for="conflictoFamiliar">
                                        Familiar: Cuando alguno de los familiares, hasta el tercer grado de consanguinidad y segundo de afinidad o
                                        primero civil, están relacionados de manera directa o indirecta en los aspectos financiero o intelectual, con las
                                        actividades y temáticas a desarrollar.
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <h3>Declaración:</h3>
                    <p>
                        He leído y comprendo el objetivo de la declaración de conflicto de intereses.
                       Por lo tanto, en forma espontánea y libre de todo apremio, doy fe acerca de los posibles intereses que podrían afectar mis actuaciones en el proceso al que he sido convocado a participar.
                       Esta declaración también hace referencia a los vínculos y posibles intereses de mis parientes consanguíneos, afines o civiles, durante los últimos dos (2) años.
                    </p>

                    <div class="form-group">
                        <h3>Describa su conflicto de interés</h3>
                        <textarea class="form-control" id="conflictoInteres" rows="4" placeholder="Describa aquí su conflicto de interés..."></textarea>
                    </div>

                </div>

                <div class="row">
                    <div class="error-validacion">
                        <p>Debe seleccionar por lo menos una indicación.</p>
                        <p>Debe revisar todos los criterios.</p>
                        <p>Debe seleccionar si presenta conflicto de interés.</p>
                    </div>
                    <div class="form-group text-right">
                        <button type="submit" class="btn btn-success">Finalizar y Postular</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal para cargar archivos -->
        <div class="modal fade" id="modalCargarArchivos" tabindex="-1" aria-labelledby="modalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalLabel">Cargar Archivos</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <!-- Formulario para cargar archivos -->
                        <form id="formCargarArchivos">
                            <!-- Título: Revisión de -->
                            <div class="mb-3">
                                <label for="tituloRevision" class="form-label">Revisión del criterio </label>                                
                                <h4 id="CriterioNombre"></h4>
                            </div>

                           <%-- <!-- Descripción del criterio -->
                            <div class="mb-3">
                                <label for="descripcionCriterio" class="form-label">Descripción del criterio:</label>                                
                            </div>--%>

                            <!-- Justificación solicitud revisión -->
                            <div class="mb-3">
                                <label for="justificacionRevision" class="form-label">Justificación solicitud revisión:</label>
                                <textarea class="form-control" id="justificacionRevision" rows="3" placeholder="Escribe la justificación" required></textarea>
                            </div>

                            <!-- Cargar archivo -->
                            <div class="mb-3">
                                <label for="archivoCargar" class="form-label">Cargar archivo:</label>
                                <input type="file" class="form-control" id="archivoCargar" required>
                            </div>

                            <!-- Descripción del archivo -->
                            <div class="mb-3">
                                <label for="descripcionArchivo" class="form-label">Descripción del archivo:</label>
                                <textarea class="form-control" id="descripcionArchivo" rows="2" placeholder="Describe el archivo" required></textarea>
                            </div>

                            <!-- Botón Anexar -->
                            <button type="button" class="btn btn-secondary" id="btnAnexar">Anexar</button>

                            <!-- Tabla de archivos anexados -->
                            <div class="mt-4">
                                <table class="table" id="tablaArchivosAnexados">
                                    <thead>
                                        <tr>
                                            <th>Archivo</th>
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
                            <button type="button" class="btn btn-primary mt-3" id="btnFinalizarPostular">Finalizar y Postular</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>




    </asp:Panel>

</asp:Content>


