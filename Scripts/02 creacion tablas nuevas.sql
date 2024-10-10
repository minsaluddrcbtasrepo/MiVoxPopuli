create schema EXCLUSIONES

go
-- Tabla TecnoIogiaExCluida
CREATE TABLE EXCLUSIONES.TecnoIogiaExCluida (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(MAX) NOT NULL,
    DescripcionSeleccion NVARCHAR(MAX) NOT NULL 
        CONSTRAINT DF_TecnoIogiaExCluida_DescripcionSeleccion 
        DEFAULT 'Seleccione las indicaciones por las cuales considera que se debe volver a incluir la tecnología:'
);

-- Tabla TecnoIogiaExCluidaVigencia
CREATE TABLE EXCLUSIONES.TecnoIogiaExCluidaVigencia (
    Id INT PRIMARY KEY IDENTITY(1,1),
	IdTecnoIogiaExcluida INT FOREIGN KEY REFERENCES EXCLUSIONES.TecnoIogiaExCluida(Id),   
    AnhoNominacion NVARCHAR(500) NOT NULL,
	AnhoExclusion NVARCHAR(500) NOT NULL,
	Resolucion NVARCHAR(500) NOT NULL
);
-- Tabla Criterio
CREATE TABLE EXCLUSIONES.Criterio (
    Id INT PRIMARY KEY IDENTITY(1,1),    
    Nombre NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(MAX) default ''
);

-- Tabla CriterioExcIusion
CREATE TABLE EXCLUSIONES.CriterioExcIusion (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdCriterio INT FOREIGN KEY REFERENCES EXCLUSIONES.Criterio(Id),
	IdTecnoIogiaExcluida INT FOREIGN KEY REFERENCES EXCLUSIONES.TecnoIogiaExCluida(Id),    
);

-- drop table  EXCLUSIONES.PostuacionTecnoIogiaExcIuida
CREATE TABLE EXCLUSIONES.PostuacionTecnoIogiaExcIuida (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdTecnoIogiaExcluida INT FOREIGN KEY REFERENCES EXCLUSIONES.TecnoIogiaExCluida(Id),
	IdUsuario INT FOREIGN KEY REFERENCES Registro(Cod_Registro),
    FechaExcluida DATETIME NOT NULL,
    IdEstado INT, 
    TieneConflictoInteres BIT NOT NULL,
    EsFinanciero BIT,
    EsFamiliar BIT,
    EsIntelectual BIT,
    EsPertenencia BIT,
    DescripcionConflictoInteres NVARCHAR(MAX)
);

-- Tabla CriterioExcIusionPostulacion
--drop table EXCLUSIONES.CriterioExcIusionPostulacion
CREATE TABLE EXCLUSIONES.CriterioExcIusionPostulacion (
    Id INT PRIMARY KEY IDENTITY(1,1),
	IdCriterioExcIusion INT FOREIGN KEY REFERENCES EXCLUSIONES.CriterioExcIusion(Id),
    IdPostulacionTecnoIogiaExcluida INT FOREIGN KEY REFERENCES EXCLUSIONES.PostuacionTecnoIogiaExcIuida(Id)
    
);

-- Tabla AnexosCriterioExclusionPostulacion
--drop table EXCLUSIONES.AnexosCriterioExclusionPostulacion
CREATE TABLE EXCLUSIONES.AnexosCriterioExclusionPostulacion (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdCriterioExclusionPostulacion INT FOREIGN KEY REFERENCES EXCLUSIONES.CriterioExcIusionPostulacion(Id),
    Nombre NVARCHAR(255) NOT NULL,
    DescripcionArchivo NVARCHAR(MAX),
    Path NVARCHAR(500) NOT NULL,
	Justificacion NVARCHAR(MAX) NOT NULL
);

-- Tabla IndicacionExclusion
CREATE TABLE EXCLUSIONES.IndicacionExclusion (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdTecnoIogiaExcluida INT FOREIGN KEY REFERENCES EXCLUSIONES.TecnoIogiaExCluida(Id),
    Descripcion NVARCHAR(MAX)
);

-- Tabla IndicacionExclusionPostulacion
CREATE TABLE EXCLUSIONES.IndicacionExclusionPostulacion (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdPostulacionTecnologiaExcluida INT FOREIGN KEY REFERENCES EXCLUSIONES.PostuacionTecnoIogiaExcIuida(Id),
	IdIndicacionExclusion INT FOREIGN KEY REFERENCES EXCLUSIONES.IndicacionExclusion(Id)
);



SELECT * FROM EXCLUSIONES.TecnoIogiaExCluida;
SELECT * FROM EXCLUSIONES.IndicacionExclusion;
SELECT * FROM EXCLUSIONES.Criterio;
SELECT * FROM EXCLUSIONES.CriterioExcIusion;
select * FROM EXCLUSIONES.TecnoIogiaExCluidaVigencia;

SELECT * FROM EXCLUSIONES.PostuacionTecnoIogiaExcIuida;
SELECT * FROM EXCLUSIONES.CriterioExcIusionPostulacion;
SELECT * FROM EXCLUSIONES.AnexosCriterioExclusionPostulacion;
SELECT * FROM EXCLUSIONES.IndicacionExclusionPostulacion;



SELECT ce.id,c.Nombre
FROM EXCLUSIONES.TecnoIogiaExCluida te inner join EXCLUSIONES.CriterioExcIusion ce on te.Id=ce.IdTecnoIogiaExcluida
inner join EXCLUSIONES.Criterio c on c.Id=ce.IdCriterio
where ce.IdTecnoIogiaExcluida=1





