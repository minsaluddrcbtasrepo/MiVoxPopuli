
-- Tabla TecnoIogiaExCluida
CREATE TABLE TecnoIogiaExCluida (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(MAX) NOT NULL
);

-- Tabla TecnoIogiaExCluidaVigencia
CREATE TABLE TecnoIogiaExCluidaVigencia (
    Id INT PRIMARY KEY IDENTITY(1,1),
	IdTecnoIogiaExcluida INT FOREIGN KEY REFERENCES TecnoIogiaExCluida(Id),   
    AnhoNominacion NVARCHAR(500) NOT NULL,
	AnhoExclusion NVARCHAR(500) NOT NULL,
	Resolucion NVARCHAR(500) NOT NULL
);
-- Tabla Criterio
CREATE TABLE Criterio (
    Id INT PRIMARY KEY IDENTITY(1,1),    
    Nombre NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(MAX) default ''
);

-- Tabla CriterioExcIusion
CREATE TABLE CriterioExcIusion (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdCriterio INT FOREIGN KEY REFERENCES Criterio(Id),
	IdTecnoIogiaExcluida INT FOREIGN KEY REFERENCES TecnoIogiaExCluida(Id),    
);

-- Tabla PostuacionTecnoIogiaExcIuida
CREATE TABLE PostuacionTecnoIogiaExcIuida (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdTecnoIogiaExcluida INT FOREIGN KEY REFERENCES TecnoIogiaExCluida(Id),
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
CREATE TABLE CriterioExcIusionPostulacion (
    Id INT PRIMARY KEY IDENTITY(1,1),
	IdCriterioExcIusion INT FOREIGN KEY REFERENCES CriterioExcIusion(Id),
    IdPostulacionTecnoIogiaExcluida INT FOREIGN KEY REFERENCES PostuacionTecnoIogiaExcIuida(Id),
    Justificacion NVARCHAR(MAX) NOT NULL
);

-- Tabla AnexosCriterioExclusionPostulacion
CREATE TABLE AnexosCriterioExclusionPostulacion (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdCriterioExclusionPostulacion INT FOREIGN KEY REFERENCES CriterioExcIusionPostulacion(Id),
    Nombre NVARCHAR(255) NOT NULL,
    DescripcionArchivo NVARCHAR(MAX),
    Path NVARCHAR(500) NOT NULL
);

-- Tabla IndicacionExclusion
CREATE TABLE IndicacionExclusion (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdTecnoIogiaExcluida INT FOREIGN KEY REFERENCES TecnoIogiaExCluida(Id),
    Descripcion NVARCHAR(MAX)
);

-- Tabla IndicacionExclusionPostulacion
CREATE TABLE IndicacionExclusionPostulacion (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdPostulacionTecnologiaExcluida INT FOREIGN KEY REFERENCES PostuacionTecnoIogiaExcIuida(Id),
	IdIndicacionExclusion INT FOREIGN KEY REFERENCES IndicacionExclusion(Id)
);



SELECT * FROM TecnoIogiaExCluida;
SELECT * FROM IndicacionExclusion;
SELECT * FROM Criterio;
SELECT * FROM CriterioExcIusion;
select * FROM TecnoIogiaExCluidaVigencia;

SELECT * FROM PostuacionTecnoIogiaExcIuida;
SELECT * FROM CriterioExcIusionPostulacion;
SELECT * FROM AnexosCriterioExclusionPostulacion;
SELECT * FROM IndicacionExclusionPostulacion;



SELECT ce.id,c.Nombre
FROM TecnoIogiaExCluida te inner join CriterioExcIusion ce on te.Id=ce.IdTecnoIogiaExcluida
inner join Criterio c on c.Id=ce.IdCriterio
where ce.IdTecnoIogiaExcluida=1




