-- Crear Base De Datos

CREATE DATABASE SleepSounds 

-- Creacion de Tablas

CREATE TABLE Paquete (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Imagen VARCHAR(MAX) NOT NULL,
    Nombre VARCHAR(255) NOT NULL,             
    CantidadDeMusica INT,
    TiempoDeDuracion INT ,
    IdCategoria INT
);

CREATE TABLE Detalle (
    IdDetalle INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    CantidadDeMusica INT,
    TiempoDeDuracion INT,
    IdCategoria INT,
    TituloDeDetalle VARCHAR(255) NOT NULL,
    Detalle VARCHAR(MAX) NOT NULL
);

CREATE TABLE Categoria (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Musica (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Artista VARCHAR(100) NOT NULL,
    Titulo VARCHAR(200) NOT NULL,
    Album VARCHAR(150) NOT NULL,
    IdCategoria INT,
    IdDePaquete INT,
    UrlDeMusica VARCHAR(MAX) NOT NULL
);

CREATE TABLE Destacado (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Imagen VARCHAR(MAX) NOT NULL,
    Nombre VARCHAR(255) NOT NULL,             
    CantidadDeMusica INT,
    IdCategoria INT
);

-- Creacion de Store Procedure
CREATE PROCEDURE USP_OBTENER_LISTA_DE_PAQUETES
AS
BEGIN
    SELECT 
    Paquete.Id, 
    Paquete.Imagen, 
    Paquete.Nombre, 
    Paquete.CantidadDeMusica, 
    Paquete.TiempoDeDuracion, 
    Categoria.Nombre AS NombreCategoria
    FROM Paquete 
    INNER JOIN Categoria
    ON Paquete.IdCategoria = Categoria.Id 
END

CREATE PROCEDURE USP_OBTENER_DETALLE_DE_PAQUETE_POR_ID(
    @Id INT
)
AS
BEGIN
    SELECT 
        Detalle.IdDetalle,
        Detalle.Nombre, 
        Detalle.CantidadDeMusica, 
        Detalle.TiempoDeDuracion, 
        Categoria.Nombre AS NombreDeCategoria, 
        Detalle.TituloDeDetalle, 
        Detalle.Detalle
    FROM Detalle
    INNER JOIN Categoria
        ON Detalle.IdCategoria = Categoria.Id
    WHERE Detalle.IdDetalle = @Id;
END;

CREATE PROCEDURE USP_OBTENER_CATEGORIA
AS
BEGIN
    SELECT *
    FROM Categoria
END

CREATE PROCEDURE USP_OBTENER_MUSICA_POR_ID(
    @IdPaquete INT
)
AS
BEGIN
    SELECT 
    Musica.Id,
    Musica.Artista,
    Musica.Titulo,
    Musica.IdDePaquete,
    Musica.Album, 
    Musica.UrlDeMusica
    FROM Musica
    WHERE 
    Musica.IdDePaquete = @IdPaquete;
END

CREATE PROCEDURE USP_OBTENER_LISTA_DE_DESTACADO
AS
BEGIN
    SELECT 
    Destacado.Id,
    Destacado.Imagen,
    Destacado.Nombre, 
    Destacado.CantidadDeMusica,
    Categoria.Nombre AS NombreDeCategoria
    FROM Destacado
    INNER JOIN Categoria
    ON Destacado.IdCategoria = Categoria.Id
END

--Ejecutar Store Procedure
EXEC USP_OBTENER_LISTA_DE_PAQUETES;
EXEC USP_OBTENER_DETALLE_DE_PAQUETE_POR_ID 1;
EXEC USP_OBTENER_MUSICA_POR_ID 1;
EXEC USP_OBTENER_LISTA_DE_DESTACADO;

-- Eliminar Store Procedure
DROP PROCEDURE USP_OBTENER_LISTA_DE_PAQUETES;
DROP PROCEDURE USP_OBTENER_DETALLE_DE_PAQUETE_POR_ID;
DROP PROCEDURE USP_OBTENER_MUSICA_POR_ID;
DROP PROCEDURE USP_OBTENER_CATEGORIA;
DROP PROCEDURE USP_OBTENER_LISTA_DE_DESTACADO;

-- Eliminar Tabla
DROP TABLE Paquete
DROP TABLE Detalle 
DROP TABLE Musica
DROP TABLE Categoria
DROP TABLE Destacado

--Llenado de tablas

    INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, idCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FGuitarCamp.png?alt=media&token=b2f13124-2ac7-402a-8fdb-6666347909f0','Guitar Camp',7, 0, 1);
    INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, idCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FChillHop.png?alt=media&token=344d4cf1-4a4f-45a8-88c1-9b0939656501','Chill-hop',7, 0, 1);
    INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, idCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FPackName.png?alt=media&token=e7eb16f4-cac1-48cd-9091-76dec6df79d1','Pack name',0, 4, 2);
    INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, idCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FPsck.png?alt=media&token=44772291-bcd2-4545-af0d-56fd5801c8d8','Pack name',0,4,3);
    INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, idCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FChillHop.png?alt=media&token=344d4cf1-4a4f-45a8-88c1-9b0939656501','Space Travel',9,0,4);
    INSERT INTO Paquete (Imagen, Nombre, CantidadDeMusica, TiempoDeDuracion, idCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FLullaby.png?alt=media&token=41081b2a-4cfe-4472-908d-0ed5f7a1b25f','Lullaby',7,0,1);

    INSERT INTO Detalle (Nombre, CantidadDeMusica,TiempoDeDuracion, IdCategoria, TituloDeDetalle, Detalle) VALUES ('Guitar Camp',7,1,1,'About this pack','An acoustic mix has been specially selected for you. The camping atmosphere will help you improve your sleep and your body as a whole. Your dreams will be delightful and vivid.');

    INSERT INTO Categoria (nombre) VALUES ('Instrumental');
    INSERT INTO Categoria (nombre) VALUES ('Acustic');
    INSERT INTO Categoria (nombre) VALUES ('Folk');
    INSERT INTO Categoria (nombre) VALUES ('Ambient');

    INSERT INTO Musica (Artista, Titulo, Album, idCategoria, idDePaquete, UrlDeMusica) VALUES ('Son By Four','The Guitars','Balada',1, 1, 'https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/MedicMeditation%2Fmusicasmp3%2FApueroDolor.mp3?alt=media&token=0d9e6158-230a-4fba-ae63-2c76b18e909f');
    INSERT INTO Musica (Artista, Titulo, Album, idCategoria, idDePaquete, UrlDeMusica) VALUES ('Link Park ','Lost Without You','Rock',1,1, 'https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/MedicMeditation%2Fmusicasmp3%2Fkukushka.mp3?alt=media&token=7e35dd0e-9b9e-4728-953c-f5fd4924d3ba');
    INSERT INTO Musica (Artista, Titulo, Album, idCategoria, idDePaquete, UrlDeMusica) VALUES ('JOSE','City Lights','Salsa',1,1, 'https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/MedicMeditation%2Fmusicasmp3%2FApueroDolor.mp3?alt=media&token=0d9e6158-230a-4fba-ae63-2c76b18e909f');
    INSERT INTO Musica (Artista, Titulo, Album, idCategoria, idDePaquete, UrlDeMusica) VALUES ('CAMILO ','Romantic','Salsa',1,1,'https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/MedicMeditation%2Fmusicasmp3%2Fkukushka.mp3?alt=media&token=7e35dd0e-9b9e-4728-953c-f5fd4924d3ba');

INSERT INTO Destacado (Imagen, Nombre, CantidadDeMusica, IdCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FChillhop.png?alt=media&token=47264e92-f332-4c61-91a8-a8e0648f2319','Chill-hop',7,1);
INSERT INTO Destacado (Imagen, Nombre, CantidadDeMusica, IdCategoria) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FLullaby.png?alt=media&token=f6698612-9358-416d-b9e4-2a736b229394','Lullaby',7,1);
