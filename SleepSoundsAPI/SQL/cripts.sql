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

CREATE TABLE Child (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Imagen VARCHAR(MAX) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
);

CREATE TABLE Nature (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Imagen VARCHAR(MAX) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
);

CREATE TABLE Animal (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Imagen VARCHAR(MAX) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
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

CREATE PROCEDURE USP_OBTENER_LISTA_CHILD
AS
BEGIN
    SELECT *
    FROM Child
END;

CREATE PROCEDURE USP_OBTENER_LISTA_NATURE
AS
BEGIN
    SELECT *
    FROM Nature
END;

CREATE PROCEDURE USP_OBTENER_LISTA_ANIMAL
AS
BEGIN
    SELECT *
    FROM Animal
END;

--Ejecutar Store Procedure
EXEC USP_OBTENER_LISTA_DE_PAQUETES;
EXEC USP_OBTENER_DETALLE_DE_PAQUETE_POR_ID 1;
EXEC USP_OBTENER_MUSICA_POR_ID 1;
EXEC USP_OBTENER_LISTA_DE_DESTACADO;
EXEC USP_OBTENER_LISTA_CHILD;
EXEC USP_OBTENER_LISTA_NATURE;
EXEC USP_OBTENER_LISTA_ANIMAL;

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

INSERT INTO Child (Imagen, Nombre) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FChild.svg?alt=media&token=f0d8a303-51b0-4f6e-a5ba-3e3e061d1e10','Female voice');
INSERT INTO Child (Imagen, Nombre) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FNoize.svg?alt=media&token=e20d43fa-1d6c-4161-a661-7cfde6ddd987','White noize');
INSERT INTO Child (Imagen, Nombre) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FLullaby.svg?alt=media&token=441d0b96-aa2b-4e20-91cc-f150a1f488e2','Lullaby');

INSERT INTO Nature (Imagen, Nombre) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FLluiva.png?alt=media&token=6b28f281-306e-446c-b514-e01d9d5243c4','Rain');
INSERT INTO Nature (Imagen, Nombre) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FForest.png?alt=media&token=cb1dcb95-7304-4808-9d92-36aecaa0a2e1','Forest');
INSERT INTO Nature (Imagen, Nombre) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FOcean.png?alt=media&token=dd94d9d2-23c4-4a69-95ef-d1c9081a6273','Ocean');
INSERT INTO Nature (Imagen, Nombre) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FFire.png?alt=media&token=a5b50e7e-bf48-4ece-9527-1ec2cbf5c1d7','Fire');

INSERT INTO Animal (Imagen, Nombre) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FBird.png?alt=media&token=bf04dce7-e3c6-46e5-85e1-aaf0f399bac9','Birds');
INSERT INTO Animal (Imagen, Nombre) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FCat.png?alt=media&token=60560a48-47f1-435e-a0e1-b8221e3c2017','Cats');
INSERT INTO Animal (Imagen, Nombre) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FFrogs.png?alt=media&token=8ba62bb6-d7ff-45c6-8c78-14a94dc67b49','Frogs');