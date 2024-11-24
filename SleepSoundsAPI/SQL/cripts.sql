-- Crear Base De Datos

CREATE DATABASE SleepSounds 

-- Creacion de Tablas

CREATE TABLE Paquete (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Imagen VARCHAR(MAX) NOT NULL,
    Nombre VARCHAR(255) NOT NULL,             
    CantidadDeMusica INT,
    TiempoDeDuracion INT ,
    NombreDeCategoria VARCHAR(255) NOT NULL
);

CREATE TABLE Detalle (
    IdDetalle INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    CantidadDeMusica INT,
    TiempoDeDuracion INT,
    NombreDeCategoria VARCHAR(255) NOT NULL,
    TituloDeDetalle VARCHAR(255) NOT NULL,
    Detalle VARCHAR(MAX) NOT NULL
);

CREATE TABLE Musica (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Artista VARCHAR(100) NOT NULL,
    Titulo VARCHAR(200) NOT NULL,
    Album VARCHAR(150) NOT NULL,
    Categoria VARCHAR(50) NOT NULL
);

-- Creacion de Store Procedure
CREATE PROCEDURE USP_OBTENER_LISTA_DE_PAQUETES
AS
BEGIN
    SELECT *
    FROM 
    Paquete
END

CREATE PROCEDURE USP_OBTENER_DETALLE_DE_PAQUETE_POR_ID(
    @Id INT
)
AS
BEGIN
    SELECT *
    FROM Detalle
    WHERE IdDetalle = @Id
END

CREATE PROCEDURE USP_OBTENER_MUSICA
AS
BEGIN
    SELECT *
    FROM Musica
END

--Ejecutar Store Procedure
EXEC USP_OBTENER_LISTA_DE_PAQUETES;
EXEC USP_OBTENER_DETALLE_DE_PAQUETE_POR_ID 1;
EXEC USP_OBTENER_MUSICA;

-- Eliminar Store Procedure
DROP PROCEDURE USP_OBTENER_LISTA_DE_PAQUETES;
DROP PROCEDURE USP_OBTENER_DETALLE_DE_PAQUETE_POR_ID;
DROP PROCEDURE USP_OBTENER_MUSICA;

-- Ejecutar para eliminar tabla
DROP PROCEDURE USP_OBTENER_LISTA_DE_MUSICA_DISCOVER
DROP TABLE Detalle
DROP TABLE Musica
--Llenado de tablas

INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, NombreDeCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FGuitarCamp.png?alt=media&token=b2f13124-2ac7-402a-8fdb-6666347909f0','Guitar Camp',7,0,'Instrumental');
INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, NombreDeCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FChillHop.png?alt=media&token=344d4cf1-4a4f-45a8-88c1-9b0939656501','Chill-hop',7,0,'Instrumental');
INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, NombreDeCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FPackName.png?alt=media&token=e7eb16f4-cac1-48cd-9091-76dec6df79d1','Pack name',0,4,'Category name');
INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, NombreDeCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FPsck.png?alt=media&token=44772291-bcd2-4545-af0d-56fd5801c8d8','Pack name',0,4,'Category name');
INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, NombreDeCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FChillHop.png?alt=media&token=344d4cf1-4a4f-45a8-88c1-9b0939656501','Space Travel',9,0,'Ambient');
INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, NombreDeCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FLullaby.png?alt=media&token=41081b2a-4cfe-4472-908d-0ed5f7a1b25f','Lullaby',7,0,'Instrumental');

INSERT INTO Detalle (Nombre, CantidadDeMusica, TiempoDeDuracion, NombreDeCategoria, TituloDeDetalle, Detalle) VALUES ('Guitar Camp',7,0,'Instrumental','About this pack','An acoustic mix has been specially selected for you. The camping atmosphere will help you improve your sleep and your body as a whole. Your dreams will be delightful and vivid.');

INSERT INTO Musica (Artista, Titulo, Album, Categoria) VALUES ('The Guitars ','Lost Without You','City Lights','Romantic');