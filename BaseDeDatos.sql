CREATE DATABASE sicap;
go

USE sicap;
go

-- Drop the function if it already exists
  IF OBJECT_ID('dbo.InitCap') IS NOT NULL
	DROP FUNCTION dbo.InitCap;
  GO
 
 -- Implementing Oracle INITCAP function
 CREATE FUNCTION dbo.InitCap (@inStr VARCHAR(8000))
  RETURNS VARCHAR(8000)
  AS
  BEGIN
    DECLARE @outStr VARCHAR(8000) = LOWER(@inStr),
		 @char CHAR(1),	
		 @alphanum BIT = 0,
		 @len INT = LEN(@inStr),
                 @pos INT = 1;		  
 
    -- Iterate through all characters in the input string
    WHILE @pos <= @len BEGIN
 
      -- Get the next character
      SET @char = SUBSTRING(@inStr, @pos, 1);
 
      -- If the position is first, or the previous characater is not alphanumeric
      -- convert the current character to upper case
      IF @pos = 1 OR @alphanum = 0
        SET @outStr = STUFF(@outStr, @pos, 1, UPPER(@char));
 
      SET @pos = @pos + 1;
 
      -- Define if the current character is non-alphanumeric
      IF ASCII(@char) <= 47 OR (ASCII(@char) BETWEEN 58 AND 64) OR
	  (ASCII(@char) BETWEEN 91 AND 96) OR (ASCII(@char) BETWEEN 123 AND 126)
	  SET @alphanum = 0;
      ELSE
	  SET @alphanum = 1;
 
    END
 
   RETURN @outStr;		   
  END
  GO

CREATE TABLE areas
(
	id_area		INT IDENTITY (1,1) PRIMARY KEY,
	area		VARCHAR (MAX)
);
GO

CREATE TABLE activos
(
	id_activo		INT PRIMARY KEY IDENTITY(1,1),
	activo			VARCHAR(100)
);
GO

INSERT INTO activos(activo) VALUES('habilitado'),('inhabilitado');
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
('Ventas');
GO


CREATE TABLE usuarios
(
	id_usuario		INT IDENTITY (1,1) PRIMARY KEY, 
	nombre			VARCHAR (900),
	paterno			VARCHAR (900),
	materno			VARCHAR (900),
	rol				INT DEFAULT 1  NOT NULL,
	contrasena		VARCHAR (MAX) NOT NULL,
	area			INT FOREIGN KEY REFERENCES areas(id_area) NOT NULL,
	telefono		VARCHAR (150) NOT NULL,
	email			VARCHAR (300) UNIQUE NOT NULL,
	especialidad	VARCHAR (900),
	ruta			VARCHAR (MAX) NOT NULL,
	id_activo		INT FOREIGN KEY REFERENCES activos(id_activo) DEFAULT 1
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
	ArchivoRuta		VARCHAR(MAX) DEFAULT '',
	id_actividad	INT FOREIGN KEY REFERENCES actividades(id_actividad) NOT NULL,
	id_usuario		INT FOREIGN KEY REFERENCES usuarios (id_usuario) NOT NULL,
	id_proyecto		INT FOREIGN KEY REFERENCES proyectos (id_proyecto) NOT NULL,
	fecha_registro	DATETIME DEFAULT GETDATE()
);
go


INSERT INTO usuarios (nombre, paterno, materno, email, contrasena, especialidad, area, rol, telefono, ruta) 
VALUES
('Admin','','','admin@admin.com','d033e22ae348aeb5660fc2140aec35850c4da997','admin', 1,1, '', 'Imagenes/default.png')
go



SELECT U.id_usuario, U.nombre,U.paterno,U.materno,A.area, U.especialidad  FROM usuarios U INNER JOIN areas A ON U.area = A.id_area;

SELECT U.id_usuario, U.nombre,U.paterno,U.materno,U.email,U.telefono,U.ruta,A.area, U.especialidad, R.rol FROM usuarios U INNER JOIN areas A ON U.area = A.id_area INNER JOIN roles R ON U.rol = R.id_rol;
SELECT * FROM usuarios U INNER JOIN areas A ON U.area = A.id_area INNER JOIN roles R ON U.rol = R.id_rol;

