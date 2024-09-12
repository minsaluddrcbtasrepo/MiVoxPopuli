$(document).ready(function () {

    var postulacion = {};
    var tecnologias = []; // Almacena todas las filas de la tabla de tecnologias
    var criteriosList = []; // Almacena todas las criterios
    var indicacionesList = []; // Almacena todas las indicaciones
    var itemsPerPage = 10; // Número de filas por página
    var $rows = undefined; //se define cuando se cargue el listado de tecnologias
    var totalItems = undefined;//se define cuando se cargue el listado de tecnologias
    var totalPages = undefined;//se define cuando se cargue el listado de tecnologias


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

        postulacion = {};
        postulacion.vigencia = vigencia;
        postulacion.tecnologia = tecnologia;
        postulacion.idTecnologia = idTecnologia;

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
        var criterioId = $(this).data('criterioid');
        var criterioNombre = $(this).data('criterio-nombre');
        $('#CriterioNombre').text(criterioNombre);
        $('#modalCargarArchivos').modal('show');
    });

    $('input[name="conflictos-intereses"]').on('change', function () {
        var valorSeleccionado = $('input[name="conflictos-intereses"]:checked').val();
        if (valorSeleccionado) {
            console.log('Conflictos de interés:', valorSeleccionado);
            if (valorSeleccionado == 'si') {
                $('#panelConflictos').removeClass('hidden');
            } else {
                $('#panelConflictos').addClass('hidden');
            }

            var x = obtenerCheckboxesSeleccionados();
            console.log('x', x);

        }
    });

    $('#btnAnexar').on('click', function () {
        event.preventDefault(); // Evita el refresco de la página
        // Obtener los valores del formulario
        const archivoInput = document.getElementById('archivoCargar');
        const descripcionArchivo = document.getElementById('descripcionArchivo').value;

        // Verificar si se ha seleccionado un archivo y si hay una descripción
        if (archivoInput.files.length > 0 && descripcionArchivo) {
            const archivo = archivoInput.files[0];
            const tabla = document.getElementById('tablaArchivosAnexados').getElementsByTagName('tbody')[0];
            

            // Crear nueva fila para la tabla
            const nuevaFila = tabla.insertRow();
            const celdaArchivo = nuevaFila.insertCell(0);
            const celdaDescripcion = nuevaFila.insertCell(1);
            const celdaAcciones = nuevaFila.insertCell(2);

            // Añadir información del archivo
            celdaArchivo.textContent = archivo.name;
            celdaDescripcion.textContent = descripcionArchivo;

            // Añadir botones de acciones
            const btnBorrar = document.createElement('button');
            btnBorrar.className = 'btn btn-danger btn-sm';
            btnBorrar.textContent = 'Borrar';
            btnBorrar.onclick = function () {
                tabla.deleteRow(nuevaFila.rowIndex - 1);
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

            // Limpiar campos de entrada
            archivoInput.value = '';
            document.getElementById('descripcionArchivo').value = '';
        } else {
            alert('Por favor, seleccione un archivo y añada una descripción.');
        }
    });





    // Función para manejar el cierre del modal
    $('#modalCargarArchivos').on('hidden.bs.modal', function () {
        // Aquí puedes agregar lógica adicional si es necesario cuando el modal se cierra
    });

    // Función para manejar el evento de clic en el botón "Finalizar y Postular"
    $('#btnFinalizarPostular').on('click', function () {
        // Capturar la información de la tabla
        var archivosAnexados = [];
        $('#tablaArchivosAnexados tbody tr').each(function () {
            var archivo = $(this).find('td').eq(0).text(); // Nombre del archivo
            var descripcion = $(this).find('td').eq(1).text(); // Descripción del archivo
            archivosAnexados.push({ archivo: archivo, descripcion: descripcion });
        });



        // Validar que la tabla tenga información 
        if (archivosAnexados.length > 0) {
            // Mostrar la información capturada (aquí puedes reemplazar con lógica de envío o procesamiento)

            console.log('Archivos anexados:', archivosAnexados);

            // Reiniciar el formulario
            $('#formCargarArchivos')[0].reset();

            // Limpiar la tabla
            $('#tablaArchivosAnexados tbody').empty();

            // Cerrar el modal
            $('#modalCargarArchivos').modal('hide');
        } else {
            alert('Por favor, completa todos los campos del formulario y asegúrate de anexar al menos un archivo.');
        }


    });

    // Función para manejar el evento de clic en el botón "Eliminar" dentro de la tabla
    $(document).on('click', '.btnEliminar', function () {
        $(this).closest('tr').remove();
    });

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
                console.log('🚀indicaciones', indicacionesList);
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
                console.log('🚀criterios', criteriosList);
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
        });
    }

    //-------------------------------------------------Auxiliares------------------------------------------
    function renderizarTablaTecnologias(data) {
        console.log('🚀tecnologias', data);
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