-- Script para insertar un archivo asociado a un proceso espec�fico en la base de datos.
-- IMPORTANTE: El usuario debe asegurarse de que el archivo est� disponible en el servidor en la ruta correcta.
-- La ruta del archivo debe ser accesible y v�lida. Ejemplo de ruta: 
-- 'https://mivoxpopuli.minsalud.gov.co/InscripcionMinSalud/files/tecnologiasExcluidas/documentos/metodologia-revision-tecnologia-salud-previamente-excluida.pdf'

-- Declaraci�n de variables
DECLARE @codVigencia INT
DECLARE @codProceso INT = 22
DECLARE @rutaArchivo NVARCHAR(500) = 'poner la ruta del archivo aqui'

-- Ejemplo de ruta v�lida:
-- 'https://mivoxpopuli.minsalud.gov.co/InscripcionMinSalud/files/tecnologiasExcluidas/documentos/metodologia-revision-tecnologia-salud-previamente-excluida.pdf'

-- Obtener el c�digo de vigencia basado en el proceso y descripci�n
SELECT @codVigencia = COD_VIGENCIA 
FROM VIGENCIA 
WHERE COD_PROCESO = @codProceso AND DESCRIPCION = '2024'

-- Insertar los datos en la tabla ARCHIVOXPROCESO
-- El usuario debe asegurarse de que el archivo ya est� subido a la ruta especificada
-- Si la ruta no es v�lida o el archivo no est� disponible, este registro no ser� �til
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
    'Metodolog�a para la revisi�n de la decisi�n de una tecnolog�a previamente excluida', 
    @rutaArchivo,
    @codProceso
);

-- Selecci�n de los registros insertados para verificar que todo est� correcto
SELECT * 
FROM ARCHIVOXPROCESO 
WHERE COD_PROCESO = @codProceso;
