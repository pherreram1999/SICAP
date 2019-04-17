CREATE DATABASE sicap;
go

USE sicap;
go

CREATE TABLE areas
(
	id_area		INT IDENTITY (1,1) PRIMARY KEY,
	area		VARCHAR (MAX)
);
GO

CREATE TABLE roles 
(
	id_rol		INT IDENTITY (1,1) PRIMARY KEY,
	rol			VARCHAR(100) NOT NULL
);

INSERT INTO roles(rol) VALUES('Administrador'),('Usuario');

GO

INSERT INTO areas (area)  
VALUES 
('Administracion'),
('Recursos Humanos'),
('Ventas')
GO


CREATE TABLE usuarios
(
	id_usuario		INT IDENTITY (1,1) PRIMARY KEY, 
	nombre			VARCHAR (MAX),
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
	observaciones	TEXT NOT NULL,
	fecha_registro	DATETIME DEFAULT GETDATE(),
	fecha_inicio	DATE NOT NULL,
	fecha_final		DATE NOT NULL,
	estatus			INT DEFAULT(1) FOREIGN KEY REFERENCES estatus(id_estatus) NOT NULL
);
go

CREATE TABLE relaciones
(
	id_relacion INT IDENTITY (1,1) PRIMARY KEY,
	id_usuarios INT FOREIGN KEY REFERENCES usuarios (id_usuario),
	id_proyecto INT FOREIGN KEY REFERENCES proyectos (id_proyecto)
);
Go

CREATE TABLE actividades
(
	id_actividad		INT IDENTITY (1,1) PRIMARY KEY,
	actividad			VARCHAR (MAX) NOT NULL,
	observaciones		TEXT NOT NULL,
	fecha_entrega		DATE NOT NULL,
	estatus				INT DEFAULT (1) FOREIGN KEY REFERENCES estatus(id_estatus) NOT NULL,	
	id_proyecto			INT FOREIGN KEY REFERENCES proyectos (id_proyecto) NOT NULL,	
);
go

CREATE TABLE avances
(
	id_avance		INT IDENTITY (1,1) PRIMARY KEY,
	avance			VARCHAR(1000) NOT NULL,
	observaciones	TEXT NOT NULL,
	ArchivoRuta		VARCHAR(MAX),
	id_actividad	INT FOREIGN KEY REFERENCES actividades(id_actividad) NOT NULL,
	id_usuario		INT FOREIGN KEY REFERENCES usuarios (id_usuario) NOT NULL,
	id_proyecto		INT FOREIGN KEY REFERENCES proyectos (id_proyecto) NOT NULL,
);
go


INSERT INTO usuarios (nombre, paterno, materno, email, contrasena, especialidad, area, rol, telefono, ruta) 
VALUES
('Pedro Alonso','Herrera','Mauricio','admin@admin.com','d033e22ae348aeb5660fc2140aec35850c4da997','admin', 1,1, '', 'Imagenes/default.png'),
('Marcos ','Ventura','Nuñez','admin@sicap.com','d033e22ae348aeb5660fc2140aec35850c4da997','admin', 1,1, '', 'Imagenes/default.png'),
('Pedro Alonso ','Herrera','Mauricio','alonso.pahm@gmail.com','d033e22ae348aeb5660fc2140aec35850c4da997','admin', 1,1, '', 'Imagenes/default.png');
go



SELECT U.id_usuario, U.nombre,U.paterno,U.materno,A.area, U.especialidad  FROM usuarios U INNER JOIN areas A ON U.area = A.id_area;

SELECT U.id_usuario, U.nombre,U.paterno,U.materno,U.email,U.telefono,U.ruta,A.area, U.especialidad, R.rol FROM usuarios U INNER JOIN areas A ON U.area = A.id_area INNER JOIN roles R ON U.rol = R.id_rol;
SELECT * FROM usuarios U INNER JOIN areas A ON U.area = A.id_area INNER JOIN roles R ON U.rol = R.id_rol;

--go

-- retorna los usuarios pertenicientes al proyecto
SELECT * FROM relaciones r INNER JOIN usuarios u ON r.id_usuarios = u.id_usuario; -- where id_proyecto = @id_proyecto ;

SELECT * FROM relaciones;

SELECT p.id_proyecto, p.proyecto, p.fecha_registro,CAST(p.fecha_inicio AS varchar) as fecha_inicio ,CAST(p.fecha_final AS varchar) as fecha_final ,p.observaciones, e.estatus FROM proyectos p INNER JOIN estatus e ON p.estatus = e.id_estatus;


SELECT CAST(fecha_inicio AS VARCHAR) as fecha_inicio FROM proyectos;


SELECT u.id_usuario, u.nombre, u.paterno, u.materno, u.especialidad FROM relaciones r INNER JOIN usuarios u ON r.id_usuarios = u.id_usuario WHERE r.id_proyecto = 1;

SELECT actividad,observaciones, CAST(fecha_entrega AS varchar) AS fecha_entrega FROM actividades WHERE id_proyecto = 3;
