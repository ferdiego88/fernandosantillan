exec spAddPersonal '45299668','Santillan','Varas','Fernando','Diego','06/09/1988','06/04/2009'
exec spActualizarHijo '45299668','Santillan','Varas','Fernando','Diego','06/09/1988','06/04/2009'
go
exec spAddHijos 'Santillan','Varas','Fernando','Diego','06/09/1988','45299668'
exec spActualizarPersonal  '75262305','Santilla  n','Varas','Fernando','Alnso','06/09/1988','06/04/2009'

select * from HIJOS
select * from PERSONAL
/* aqui comienza el script */	
USE MASTER
GO
CREATE DATABASE FERNANDOSANTILLAN
go

IF (EXISTS(SELECT * FROM sys.databases WHERE name = 'FERNANDOSANTILLAN'))
	DROP DATABASE FERNANDOSANTILLAN
	CREATE DATABASE FERNANDOSANTILLAN
	USE FERNANDOSANTILLAN
	CREATE TABLE PERSONAL(
		IdPersonal INT primary key NOT NULL,
		ApPaterno VARCHAR(50) NOT NULL,
		ApMaterno VARCHAR(50) NOT NULL,
		Nombre1 VARCHAR(50) NOT NULL,
		Nombre2 VARCHAR(50) NULL,
		NombreCompleto VARCHAR(MAX) NOT NULL,
		FchNac DATE NOT NULL,
		FchIngreso DATE NOT NULL
	)
GO
CREATE PROC spAddPersonal(
		@IdPersonal INT,
		@ApPaterno VARCHAR(50),
		@ApMaterno VARCHAR(50),
		@Nombre1 VARCHAR(50),
		@Nombre2 VARCHAR(50),
		@FchNac DATE,
		@FchIngreso DATE
	)
	AS
	BEGIN
		INSERT INTO PERSONAL(IdPersonal,ApPaterno,ApMaterno,Nombre1,Nombre2, NombreCompleto,FchNac,FchIngreso)
		VALUES (@IdPersonal,@ApPaterno,@ApMaterno,@Nombre1,@Nombre2,@Nombre1 + SPACE(1) + @Nombre2,@FchNac,@FchIngreso)
	END
GO

CREATE PROC spActualizarPersonal(
		@IdPersonal int,
		@ApPaterno VARCHAR(50),
		@ApMaterno VARCHAR(50),
		@Nombre1 VARCHAR(50),
		@Nombre2 VARCHAR(50),
		@FchNac DATE,
		@FchIngreso DATE
)
AS
	BEGIN
		UPDATE PERSONAL
		SET IdPersonal = @IdPersonal,
		ApPaterno= @ApPaterno,
		ApMaterno = @ApMaterno,
		Nombre1 = @Nombre1,
		Nombre2 = @Nombre2,
		NombreCompleto = @Nombre1 + SPACE(1) + @Nombre2,
		FchNac = @FchNac,
		FchIngreso = @FchIngreso
		where IdPersonal=@IdPersonal

	END
GO
CREATE PROC spBorrarPersonal(
	@IdPersonal INT
)
AS
	BEGIN
		DELETE FROM PERSONAL where IdPersonal = @IdPersonal
	END
GO

CREATE PROC spGetAllPersonal
AS
	BEGIN
		SELECT * 
		FROM PERSONAL
		ORDER BY NombreCompleto
	END
GO
CREATE TABLE HIJOS(
		IdDerhab INT IDENTITY(1,1) NOT NULL,
		IdPersonal INT,
		ApPaterno VARCHAR(50) NOT NULL,
		ApMaterno VARCHAR(50) NOT NULL,
		Nombre1 VARCHAR(50) NOT NULL,
		Nombre2 VARCHAR(50) NULL,
		NombreCompleto VARCHAR(MAX) NOT NULL,
		FchNac DATE NOT NULL,
		CONSTRAINT fk_Personal FOREIGN KEY(IdPersonal) REFERENCES PERSONAL(IdPersonal)
	)
GO
CREATE PROC spAddHijos(
		@ApPaterno VARCHAR(50),
		@ApMaterno VARCHAR(50),
		@Nombre1 VARCHAR(50),
		@Nombre2 VARCHAR(50),
		@FchNac DATE,
		@IdPersonal INT
	)
	AS
	BEGIN
		INSERT INTO HIJOS(ApPaterno,ApMaterno,Nombre1,Nombre2, NombreCompleto,FchNac,IdPersonal)
		VALUES (@ApPaterno,@ApMaterno,@Nombre1,@Nombre2,@Nombre1 + SPACE(1) + @Nombre2,@FchNac,@IdPersonal)
	END
GO


CREATE PROC spActualizarHijo(
		@ApPaterno VARCHAR(50),
		@ApMaterno VARCHAR(50),
		@Nombre1 VARCHAR(50),
		@Nombre2 VARCHAR(50),
		@FchNac DATE,
		@IdPersonal INT,
		@IdDerhab INT
)
AS
	BEGIN
		UPDATE HIJOS
		SET ApPaterno= @ApPaterno,
		ApMaterno = @ApMaterno,
		Nombre1 = @Nombre1,
		Nombre2 = @Nombre2,
		NombreCompleto = @Nombre1 + SPACE(1) + @Nombre2,
		FchNac = @FchNac,
		IdPersonal = @IdPersonal
		where IdDerhab=@IdDerhab

	END
GO
CREATE PROC spBorrarHijos(
	@IdDerhab INT
)
AS
	BEGIN
		DELETE FROM HIJOS where IdDerhab = @IdDerhab
	END
GO

CREATE PROC spGetAllHijos
AS
	BEGIN
		SELECT * 
		FROM PERSONAL
		ORDER BY NombreCompleto
	END
