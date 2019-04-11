CREATE DATABASE sicap;
go

USE sicap;
go

CREATE TABLE areas
(
	id_area		INT IDENTITY (1,1) PRIMARY KEY,
	area		VARCHAR (MAX)
);
go

INSERT INTO areas (area)  
VALUES 
('Administracion'),
('Recursos Humanos'),
('Ventas')
GO

CREATE TABLE usuarios
(
	id_usuario		INT IDENTITY (1,1) PRIMARY KEY, 
	nombre			VARCHAR (120),
	paterno			VARCHAR (180),
	materno			VARCHAR (180),
	rol				INT DEFAULT 1  NOT NULL,
	contrasena		VARCHAR (MAX) NOT NULL,
	area			INT FOREIGN KEY REFERENCES areas(id_area) NOT NULL,
	telefono		VARCHAR (12) NOT NULL,
	email			VARCHAR (120) UNIQUE NOT NULL,
	especialidad	VARCHAR (MAX),
	ruta			VARCHAR (MAX) NOT NULL
);
go

-- el catalogo de estatus
CREATE TABLE estatus
(
	id_estatus		INT IDENTITY (1,1) PRIMARY KEY,
	estatus			VARCHAR(15) NOT NULL
);
go

INSERT INTO estatus (estatus)
VALUES 
	('Activo'),
	('Concluido'),
	('Cancelado');
go

CREATE TABLE proyectos
(
	id_proyecto		INT IDENTITY (1,1) PRIMARY KEY,
	proyecto		VARCHAR (MAX) NOT NULL,
	fecha_registro	DATETIME DEFAULT GETDATE(),
	fecha_inicio	DATETIME NOT NULL,
	fecha_final		DATETIME NOT NULL,
	estatus			INT FOREIGN KEY REFERENCES estatus(id_estatus) NOT NULL
);
go

CREATE TABLE avances
(
	id_avance			INT IDENTITY (1,1) PRIMARY KEY,
	titulo				VARCHAR (MAX) NOT NULL,
	observaciones		VARCHAR (MAX) NOT NULL,
	fecha_entrega		DATETIME NOT NULL,
	estatus				INT FOREIGN KEY REFERENCES estatus(id_estatus) NOT NULL,
	id_usuario			INT FOREIGN KEY REFERENCES usuarios (id_usuario) NOT NULL,
	id_proyecto			INT FOREIGN KEY REFERENCES proyectos (id_proyecto) NOT NULL,	
);
go

CREATE TABLE documentos
(
	id_documento	INT IDENTITY (1,1) PRIMARY KEY,
	observaciones	VARCHAR (MAX),
	ruta			VARCHAR(MAX) NOT NULL,
	id_avance		INT FOREIGN KEY REFERENCES avances(id_avance) NOT NULL,
	id_usuario		INT FOREIGN KEY REFERENCES usuarios (id_usuario) NOT NULL,
	id_proyecto		INT FOREIGN KEY REFERENCES proyectos (id_proyecto) NOT NULL,
);
go


INSERT INTO usuarios (nombre, paterno, materno, email, contrasena, especialidad, area, rol, telefono, ruta) 
VALUES
('','','','admin',ENCRYPTBYPASSPHRASE('PASS',CONVERT(VARCHAR, 'admin')),'', 1,0, '', 'sources/Materialize/Imagenes/perflDefault.png')



SELECT U.id_usuario, U.nombre,U.paterno,U.materno,A.area FROM usuarios U INNER JOIN areas A ON U.area = A.id_area;
--go