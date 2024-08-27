$(document).ready(function () {

    var postulacion = {};
    var tecnologias = []; // Almacena todas las filas de la tabla de tecnologias
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
        // $('#panel1').addClass('hidden');
        $('#TecnologiaSeleccionada').text(tecnologia);
        cargarIndicaciones(idTecnologia);
        cargarCriterios(idTecnologia);
        postulacion = {};
        postulacion.vigencia = vigencia;
        postulacion.tecnologia = tecnologia;
        postulacion.idTecnologia = idTecnologia;
    });

    // Evento click para levantar el modal de carga de archivos
    $('#tabla-criterios').on('click', '.btn-revision', function () {
        event.preventDefault(); // Evita el refresco de la página
        var criterioId = $(this).data('criterioid');
        var criterioNombre = $(this).data('criterio-nombre');
        $('#CriterioNombre').text(criterioNombre);
        $('#modalCargarArchivos').modal('show');
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
                var indicaciones = response.d;
                console.log('🚀indicaciones', indicaciones);
                var indicacionesDiv = $('#indicaciones');
                indicacionesDiv.empty();

                // Checkbox "Seleccionar todo"
                var selectAllCheckbox = `
             <div class="row">
                <div class="col d-flex align-items-center">
                    <input class="form-check-input indicacion-checkbox" type="checkbox" id="selectAll">
                    <label class="form-check-label " for="selectAll">Seleccionar Todo</label>
                </div>
             </div>`;
                indicacionesDiv.append(selectAllCheckbox);

                // Checkbox para cada indicación
                indicaciones.forEach(function (indicacion) {
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
                var criterios = response.d;
                console.log('🚀criterios', criterios);
                var tbody = $('#tabla-criterios tbody');
                tbody.empty();
                postulacion.criterios = criterios;
                criterios[0].Revisado = true;
                criterios.forEach(function (criterio) {
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