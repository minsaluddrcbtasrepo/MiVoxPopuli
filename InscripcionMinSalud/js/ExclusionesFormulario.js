$(document).ready(function () {

    var postulacionModel = {};
    var tecnologias = []; // Almacena todas las filas de la tabla de tecnologias
    var criteriosList = []; // Almacena todas las criterios
    var indicacionesList = []; // Almacena todas las indicaciones
    var itemsPerPage = 10; // Número de filas por página
    var $rows = undefined; //se define cuando se cargue el listado de tecnologias
    var totalItems = undefined;//se define cuando se cargue el listado de tecnologias
    var totalPages = undefined;//se define cuando se cargue el listado de tecnologias
    var criterioSelect = 0;
    // Cargar las tecnologías excluidas al iniciar la página
    cargarTecnologiasExcluidas();




    //------------------------------------------------------------------Eventos--------------------------------------------------------------//

    // Event listener para el botón de filtro
    $('#btn-filtrar').on('click', function () {
        event.preventDefault(); // Evita el refresco de la página
        applyFilter();
    });

    // Event listener para el filtro con la tecla Enter
    $('#filtro-tecnologias').on('keypress', function (e) {
        if (e.which === 13) { // Código de tecla Enter
            e.preventDefault(); // Evita que el Enter active otros eventos
            applyFilter();
        }
    });


    // Evento click en los botones de acción de la tabla de tecnologías
    $('#tabla-tecnologias').on('click', '.btn-accion', function (event) {
        event.preventDefault(); // Evita el refresco de la página
        var vigencia = $(this).data('vigencia');
        var tecnologia = $(this).data('tecnologia');
        var idTecnologia = $(this).data('idtecnologia');
        $('#panel2').removeClass('hidden');
        $('#panel1').addClass('hidden');
        $('#TecnologiaSeleccionada').text(tecnologia);

        postulacionModel = {
            conflictoInteres: false,
            conflictoInteresModel: {
                conflictoInteres: ''
            }
        };
        postulacionModel.vigencia = vigencia;
        postulacionModel.tecnologia = tecnologia;
        postulacionModel.idTecnologia = idTecnologia;

        cargarIndicaciones(idTecnologia);
        cargarCriterios(idTecnologia);

    });

    // Evento click para levantar el modal de carga de archivos
    $('#panel2').on('click', '.btn-back', function () {
        event.preventDefault(); // Evita el refresco de la página

        $('#panel1').removeClass('hidden');
        $('#panel2').addClass('hidden');
        $('#TecnologiaSeleccionada').text("");
    });

    // Evento click para levantar el modal de carga de archivos
    $('#tabla-criterios').on('click', '.btn-revision', function () {
        event.preventDefault(); // Evita el refresco de la página
        criterioSelect = $(this).data('criterioid');
        var criterio = postulacionModel.criterios.find(x => x.Id == criterioSelect);
        if (criterio && criterio.Revisado === false) {
            criterio.anexos = [];

            limpiarFormularioRevision(true);
            var criterioNombre = $(this).data('criterio-nombre');
            $('#CriterioNombre').text(criterioNombre);
            $('#modalCargarArchivos').modal('show');
        }
        validateCriterios();
    });

    $('#btnAnexar').on('click', function () {
        event.preventDefault(); // Evita el refresco de la página

        // Obtener los valores del formulario
        const archivoInput = document.getElementById('archivoCargar');
        const descripcionArchivo = document.getElementById('descripcionArchivo').value;
        const justificacionRevision = document.getElementById('justificacionRevision').value;

        // Verificar si se ha seleccionado un archivo y si hay una descripción
        if (archivoInput.files.length > 0 && descripcionArchivo && justificacionRevision) {
            const btnGuardarCriterio = document.getElementById('btnGuardarCriterio');
            const archivo = archivoInput.files[0];
            const tabla = document.getElementById('tablaArchivosAnexados').getElementsByTagName('tbody')[0];


            // Crear nueva fila para la tabla
            const nuevaFila = tabla.insertRow();
            const celdaArchivo = nuevaFila.insertCell(0);
            const celdaJustificacion = nuevaFila.insertCell(1);
            const celdaDescripcion = nuevaFila.insertCell(2);
            const celdaAcciones = nuevaFila.insertCell(3);

            // Añadir información del archivo
            celdaArchivo.textContent = archivo.name;
            celdaJustificacion.textContent = justificacionRevision;
            celdaDescripcion.textContent = descripcionArchivo;

            // Añadir botones de acciones
            const btnBorrar = document.createElement('button');
            btnBorrar.className = 'btn btn-danger btn-sm';
            btnBorrar.textContent = 'Borrar';
            btnBorrar.onclick = function () {
                index = nuevaFila.rowIndex - 1;
                if (index > -1 && index < criterio.anexos.length) {
                    criterio.anexos.splice(index, 1);
                    tabla.deleteRow(index);
                }

                if (tabla.rows.length === 0) {
                    btnGuardarCriterio.disabled = true;
                }
            };

            const btnVer = document.createElement('button');
            btnVer.className = 'btn btn-info btn-sm ms-2';
            btnVer.textContent = 'Ver';
            btnVer.onclick = function () {
                event.preventDefault(); // Evita el refresco de la página
                // Implementar lógica para ver archivo, por ejemplo, abrir en una nueva ventana
                window.open(URL.createObjectURL(archivo), '_blank');
            };

            celdaAcciones.appendChild(btnBorrar);
            celdaAcciones.appendChild(btnVer);

            //actualizar modelo

            var criterio = postulacionModel.criterios.find(x => x.Id == criterioSelect);
            if (criterio) {
                criterio.anexos.push({
                    archivo: archivo,
                    descripcion: descripcionArchivo,
                    justificacion: justificacionRevision,

                });
            }
            // Limpiar campos de entrada
            limpiarFormularioRevision();
            btnGuardarCriterio.disabled = false;

            


        } else {
            alert('Por favor, seleccione un archivo y añada una Justificación y una descripción.');
        }
    });
    function limpiarFormularioRevision(borrarTabla = false) {
        const archivoInput = document.getElementById('archivoCargar');
        archivoInput.value = '';
        document.getElementById('descripcionArchivo').value = '';
        document.getElementById('justificacionRevision').value = '';
        limpiarArchivo();

        if (borrarTabla) {
            const tabla = document.getElementById('tablaArchivosAnexados').getElementsByTagName('tbody')[0];
            while (tabla.rows.length > 0) {
                tabla.deleteRow(0);
            }
            document.getElementById('btnGuardarCriterio').disabled = true;
        }
    }

    $('#btn-close-modal-criterios').on('click', function () {
        $('#CriterioNombre').text('');
        $('#modalCargarArchivos').modal('hide');
        validateCriterios();
    });


    $('input[name="conflictos-intereses"]').on('change', function () {
        var valorSeleccionado = $('input[name="conflictos-intereses"]:checked').val();
        postulacionModel.conflictoInteres = false;
        if (valorSeleccionado) {
            if (valorSeleccionado == 'si') {
                postulacionModel.conflictoInteres = true;
                $('#panelConflictos1').removeClass('hidden');
                $('#panelConflictos2').removeClass('hidden');
            } else {
                $('#panelConflictos1').addClass('hidden');
                $('#panelConflictos2').addClass('hidden');
            }
        }
        validateCriterios();
    });





    function validateCriterios() {
        setTimeout(function () {
            let allValid = true;

            // Ejemplo de validaciones 
            var indicaciones = obtenerCheckboxesSeleccionados();
            if (indicaciones.length === 0) {
                $('#errorIndicacion').show();
                allValid = false;
            } else {
                $('#errorIndicacion').hide();
            }

            var criteriosFaltantes = postulacionModel.criterios.filter(criterio => criterio.Revisado === false);

            if (criteriosFaltantes.length > 0) {
                $('#errorCriterio').show();
                allValid = false;
            } else {
                $('#errorCriterio').hide();
            }

            $('#errorConflicto').hide();
            if (postulacionModel.conflictoInteres == true) {

                if (postulacionModel.conflictoInteresModel.conflictoInteres === '') {
                    $('#errorConflicto').show();
                    allValid = false;
                }
            }




            // Habilitar o deshabilitar el botón
            $('#btnFinalizar').prop('disabled', !allValid);
        }, 100); 
    }


    function verificarCheckbox(id) {
        var checkbox = $('#' + id);
        return checkbox.is(':checked');

    }
    $('#archivoCargar').on('change', function () {
        actualizarNombreArchivo();
    });

    $('#clearIcon').on('click', function () {
        limpiarArchivo();
    });


    $('#conflictoInteresStr').on('change', function () {
        var valor = $('#conflictoInteresStr').val();
        postulacionModel.conflictoInteresModel.conflictoInteres = valor;
        validateCriterios();

    });


    $('.conflicto-checkbox').on('change', function () {
        var id = $(this).attr('id');
        var checked = $(this).is(':checked');
        postulacionModel.conflictoInteresModel[id] = checked;
    });



    // Función para actualizar el nombre del archivo seleccionado
    function actualizarNombreArchivo() {
        var input = document.getElementById('archivoCargar');
        var nombreArchivo = document.getElementById('nombreArchivo');
        var clearIcon = document.getElementById('clearIcon');

        if (input.files.length > 0) {
            nombreArchivo.textContent = input.files[0].name;
            clearIcon.style.display = 'inline'; // Mostrar el ícono de clear
        } else {
            nombreArchivo.textContent = "Ningún archivo seleccionado";
            clearIcon.style.display = 'none'; // Ocultar el ícono de clear si no hay archivo
        }
    }

    // Función para limpiar el archivo seleccionado
    function limpiarArchivo() {
        var input = document.getElementById('archivoCargar');
        var nombreArchivo = document.getElementById('nombreArchivo');
        var clearIcon = document.getElementById('clearIcon');

        input.value = ""; // Limpiar el archivo seleccionado
        nombreArchivo.textContent = "Ningún archivo seleccionado";
        clearIcon.style.display = 'none'; // Ocultar el ícono de clear
    }



    //---------------------------------AJAX-----------------------------------------//

    // Función para cargar tecnologías excluidas
    function cargarTecnologiasExcluidas() {
        $.ajax({
            type: "POST",
            url: "frmExclusiones_EtapaI_Solicitud.aspx/GetTecnologiasExcluidas",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                tecnologias = response.d;
                renderizarTablaTecnologias(tecnologias);


            }
        });
    }


    // Función para cargar indicaciones
    function cargarIndicaciones(idTecnologia) {
        $.ajax({
            type: "POST",
            url: "frmExclusiones_EtapaI_Solicitud.aspx/GetIndicaciones",
            data: JSON.stringify({ idTecnologia: idTecnologia }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                indicacionesList = response.d;
                var indicacionesDiv = $('#indicaciones');
                indicacionesDiv.empty();

                // Checkbox "Seleccionar todo"
                if (indicacionesList.length > 1) {

                    var selectAllCheckbox = `
                                             <div class="row">
                                                <div class="col d-flex align-items-center">
                                                   <input class="form-check-input indicacion-checkbox" type="checkbox" id="selectAll">
                                                    <label class="form-check-label " for="selectAll">Seleccionar Todo</label>
                                                </div>
                                             </div>`;
                    indicacionesDiv.append(selectAllCheckbox);
                }

                // Checkbox para cada indicación
                indicacionesList.forEach(function (indicacion) {
                    var checkbox = `
                 <div class="row">
                    <div class="col d-flex align-items-center">
                        <input class="form-check-input indicacion-checkbox" type="checkbox" value="${indicacion.Id}" id="indicacion${indicacion.Id}">
                        <label class="form-check-label " for="indicacion${indicacion.Id}">${indicacion.Nombre}</label>
                    </div>
                 </div>
                    `;
                    indicacionesDiv.append(checkbox);
                });

                // Lógica para el "Seleccionar todo"
                $('#selectAll').on('change', function () {
                    var isChecked = $(this).is(':checked');
                    $('.indicacion-checkbox').prop('checked', isChecked);
                });

                // Lógica para desmarcar "Seleccionar todo" si un checkbox individual es desmarcado
                $(document).on('change', '.indicacion-checkbox', function () {
                    if (!$(this).is(':checked')) {
                        $('#selectAll').prop('checked', false);
                    }
                });
            }
        });
    }


    // Función para cargar criterios
    function cargarCriterios(idTecnologia) {
        $.ajax({
            type: "POST",
            url: "frmExclusiones_EtapaI_Solicitud.aspx/GetCriterios",
            data: JSON.stringify({ idTecnologia: idTecnologia }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                criteriosList = response.d;
                cargarTablaCriterios(criteriosList);
                postulacionModel.criterios = criteriosList;
            }
        });
    }

    function cargarTablaCriterios(criteriosList) {
        var tbody = $('#tabla-criterios tbody');
        tbody.empty();
        criteriosList.forEach(function (criterio) {
            var revisado = criterio.Revisado == true ? "✓" : "✕";
            var revisadoClass = criterio.Revisado == true ? "revisado" : "error-validacion";
            var fila = `
                    <tr >
                        <td class="${revisadoClass}">${revisado}</td>
                        <td class="${revisadoClass}">${criterio.Nombre}</td>
                        <td class="${revisadoClass}">
                            ${criterio.Revisado == false
                    ? `<button class="btn btn-warning btn-revision" data-criterioid="${criterio.Id}" data-criterio-nombre="${criterio.Nombre}">Revisión</button>`
                    : 'Revisado'
                }
                        </td>
                    </tr>`;
            tbody.append(fila);
        });
    }



    // Función para manejar el evento de clic en el botón guardar criterio
    $('#btnGuardarCriterio').on('click', function () {
        var criterio = postulacionModel.criterios.find(x => x.Id == criterioSelect);
        if (criterio) {
            if (criterio.hasOwnProperty('__type')) {
                delete criterio.__type;
            }
            if (criterio.anexos.length > 0) {

                var totalAnexos = criterio.anexos.length;
                var anexosExitosos = 0;
                var anexosFallidos = 0;



                function verificarCargas() {

                    if ((anexosExitosos + anexosFallidos) === totalAnexos) {
                        // Todos los archivos han sido procesados
                        if (anexosFallidos === 0) {

                            criterio.Revisado = true;

                            // Buscar en postulacionModel.criterios si falta alguno por revisar
                            var criterioPendiente = postulacionModel.criterios.find(criterio => criterio.Revisado === false);

                            // Si hay un criterio pendiente por revisar, mostrar un alert al usuario
                            if (criterioPendiente) {
                                alert('Por favor, continúa con el siguiente criterio.');
                            }

                            $('#modalCargarArchivos').modal('hide');
                            cargarTablaCriterios(postulacionModel.criterios);
                            validateCriterios();

                        } else {
                            // Si hubo algún error
                            alert('Se produjo un error al cargar algunos archivos. Archivos cargados exitosamente: ' + anexosExitosos + ', archivos fallidos: ' + anexosFallidos);
                        }
                    }
                }

                criterio.anexos.forEach(function (anexo) {


                    var reader = new FileReader();
                    reader.onload = function (e) {
                        var archivoBase64 = e.target.result.split(',')[1]; // Obtiene solo la parte de los datos Base64
                        var archivoName = anexo.archivo.name;
                        // Preparar los datos a enviar
                        var data = JSON.stringify({
                            nombreArchivo: archivoName,
                            archivoBytes: archivoBase64
                        });



                        // Enviar el archivo al WebMethod con $.ajax
                        $.ajax({
                            type: "POST",
                            url: "frmExclusiones_EtapaI_Solicitud.aspx/GuardarAnexo", // URL del WebMethod
                            data: data,
                            contentType: "application/json; charset=utf-8", // Especificar que el contenido es JSON
                            dataType: "json", // Especificar que esperamos JSON de vuelta
                            success: function (response) {
                                if (response.d.includes('error')) {
                                    anexosFallidos++; // Incrementar el contador de archivos fallidos
                                } else {

                                    anexo.rutaArchivo = response.d; // Guardar la ruta del archivo en el objeto anexo
                                    anexo.archivo = null;
                                    anexo.nombre = archivoName;
                                    anexosExitosos++; // Incrementar el contador de archivos exitosos
                                }
                                verificarCargas(); // Verificar si se han procesado todos los archivos
                            },
                            error: function (xhr, status, error) {
                                console.error('Error al enviar el archivo:', error);
                                anexosFallidos++;
                            }
                        });


                    };
                    // Leer el archivo como Data URL
                    reader.readAsDataURL(anexo.archivo);
                });


            } else {
                alert("El criterio debe tener un archivo anexo");
            }
        }



    });



    $('#btnFinalizar').on('click', function () {


        event.preventDefault(); // Evita el refresco de la página
        postulacionModel.indicadores = obtenerCheckboxesSeleccionados();
        // Enviar el objeto al WebMethod usando $.ajax
        $.ajax({
            type: "POST",
            url: "frmExclusiones_EtapaI_Solicitud.aspx/GuardarDatos", // URL del WebMethod
            data: JSON.stringify({ postulacionModel }), // Convertir el objeto a JSON
            contentType: "application/json; charset=utf-8", // Establecer el contentType a JSON
            dataType: "json", // Esperar una respuesta JSON
            success: function (response) {
                // Manejar la respuesta del WebMethod
                alert('Datos enviados exitosamente.');
                setTimeout(function () {
                    location.reload();
                }, 1000); // 1000 milisegundos = 1 segundo
            },
            error: function (xhr, status, error) {
                // Manejar errores
                console.error('Error al enviar los datos:', error);
                alert('Error al enviar los datos.');
            }
        });
    });




    //-------------------------------------------------Auxiliares------------------------------------------
    function renderizarTablaTecnologias(data) {
        var tbody = $('#tabla-tecnologias tbody');
        tbody.empty();
        data.forEach(function (tecnologia) {
            var fila = `
                                <tr>
                                    <td>${tecnologia.Tecnologia}</td>
                                    <td>${tecnologia.Vigencia}</td>
                                    <td>
                                        ${!tecnologia.Postulado
                    ? `<button class="btn btn-primary btn-accion" data-vigencia="${tecnologia.Vigencia}" data-idtecnologia="${tecnologia.Id}" data-tecnologia="${tecnologia.Tecnologia}">Postular</button>`
                    : `<label>Postulado</label>`
                }
                                    </td>
                                </tr>`;

            tbody.append(fila);
        });


        $rows = $('#tabla-tecnologias tbody tr');
        totalItems = $rows.length;
        totalPages = Math.ceil(totalItems / itemsPerPage);

        // Inicializa la tabla con la primera página y la paginación
        generatePagination();
        showPage(1);
    }

    // Función para aplicar el filtro
    function applyFilter() {
        var searchTerm = $('#filtro-tecnologias').val().toLowerCase();
        $('#tabla-tecnologias tbody').empty();
        var filteredRows = tecnologias.filter(function (row) {
            return (row.Tecnologia + row.Vigencia).toLowerCase().indexOf(searchTerm) !== -1;
        });
        renderizarTablaTecnologias(filteredRows);
    }


    $('#indicaciones').on('change', 'input[type="checkbox"]', function () {
        var checkedCount = $('#indicaciones input[type="checkbox"]:checked').length;

        console.log('Número de checkboxes seleccionados:', checkedCount);


        validateCriterios();
    });



    // Función para buscar todos los checkboxes de indicacion seleccionados
    function obtenerCheckboxesSeleccionados() {
        var seleccionados = [];
        $('.indicacion-checkbox:checked').each(function () {
            seleccionados.push($(this).val());
        });
        return seleccionados;
    }


    // Función para mostrar las filas según la página
    function showPage(page) {
        $rows.hide();
        $rows.slice((page - 1) * itemsPerPage, page * itemsPerPage).show();
    }

    // Función para generar la paginación
    function generatePagination() {
        $('#pagination-container').empty();
        for (var i = 1; i <= totalPages; i++) {
            $('#pagination-container').append('<button class="page-link btn btn-light">' + i + '</button>');
        }

        // Agrega evento click a los botones de paginación
        $('#pagination-container .page-link').on('click', function () {
            event.preventDefault(); // Evita el refresco de la página
            var page = $(this).text();
            showPage(page);
        });
    }

});