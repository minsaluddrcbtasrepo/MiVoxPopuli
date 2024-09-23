-- Script para insertar un archivo asociado a un proceso específico en la base de datos.
-- IMPORTANTE: El usuario debe asegurarse de que el archivo esté disponible en el servidor en la ruta correcta.
-- La ruta del archivo debe ser accesible y válida. Ejemplo de ruta: 
-- 'https://mivoxpopuli.minsalud.gov.co/InscripcionMinSalud/files/tecnologiasExcluidas/documentos/metodologia-revision-tecnologia-salud-previamente-excluida.pdf'

-- Declaración de variables
DECLARE @codVigencia INT
DECLARE @codProceso INT = 22
DECLARE @rutaArchivo NVARCHAR(500) = 'poner la ruta del archivo aqui'

-- Ejemplo de ruta válida:
-- 'https://mivoxpopuli.minsalud.gov.co/InscripcionMinSalud/files/tecnologiasExcluidas/documentos/metodologia-revision-tecnologia-salud-previamente-excluida.pdf'

-- Obtener el código de vigencia basado en el proceso y descripción
SELECT @codVigencia = COD_VIGENCIA 
FROM VIGENCIA 
WHERE COD_PROCESO = @codProceso AND DESCRIPCION = '2024'

-- Insertar los datos en la tabla ARCHIVOXPROCESO
-- El usuario debe asegurarse de que el archivo ya esté subido a la ruta especificada
-- Si la ruta no es válida o el archivo no está disponible, este registro no será útil
INSERT INTO ARCHIVOXPROCESO (
    VIGENCIA, 
    SECCION, 
    SUBSECCION, 
    TEXTO, 
    URL, 
    COD_PROCESO
) VALUES ( 
    @codVigencia, 
    'EXCLUSIONES', 
    'METODOLOGIA', 
    'Metodología para la revisión de la decisión de una tecnología previamente excluida', 
    @rutaArchivo,
    @codProceso
);

-- Selección de los registros insertados para verificar que todo está correcto
SELECT * 
FROM ARCHIVOXPROCESO 
WHERE COD_PROCESO = @codProceso;
