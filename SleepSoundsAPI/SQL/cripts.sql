-- Crear Base De Datos

CREATE DATABASE SleepSounds 

-- Creacion de Tablas

CREATE TABLE AllMusica (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Imagen VARCHAR(MAX) NOT NULL,
    Nombre VARCHAR(255) NOT NULL,             
    Songs INT,
    Instrumental VARCHAR(255) NOT NULL
);

CREATE TABLE Detalle (
    IdDetalle INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Songs INT,
    Instrumental VARCHAR(255) NOT NULL,
    TituloDeDetalle VARCHAR(255) NOT NULL,
    Detalle VARCHAR(MAX) NOT NULL
);

-- Creacion de Store Procedure
CREATE PROCEDURE USP_OBTENER_LISTA_DE_MUSICA_DISCOVER
AS
BEGIN
    SELECT *
    FROM 
    AllMusica
END

CREATE PROCEDURE USP_OBTENER_DETALLE_DE_MUSICA_DISCOVER_POR_ID(
    @Id INT
)
AS
BEGIN
    SELECT *
    FROM Detalle
    WHERE IdDetalle = @Id
END

--Ejecutar Store Procedure
EXEC USP_OBTENER_LISTA_DE_MUSICA_DISCOVER;
EXEC USP_OBTENER_DETALLE_DE_MUSICA_DISCOVER_POR_ID 1

--Llenado de tablas

INSERT INTO AllMusica (Imagen, Nombre, Songs, Instrumental) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FGuitarCamp.png?alt=media&token=b2f13124-2ac7-402a-8fdb-6666347909f0','Guitar Camp',7,'Instrumental');
INSERT INTO AllMusica (Imagen, Nombre, Songs, Instrumental) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FChillHop.png?alt=media&token=344d4cf1-4a4f-45a8-88c1-9b0939656501','Chill-hop',7,'Instrumental');
INSERT INTO AllMusica (Imagen, Nombre, Songs, Instrumental) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FPackName.png?alt=media&token=e7eb16f4-cac1-48cd-9091-76dec6df79d1','Pack name',4,'Category name');
INSERT INTO AllMusica (Imagen, Nombre, Songs, Instrumental) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FPsck.png?alt=media&token=44772291-bcd2-4545-af0d-56fd5801c8d8','Pack name',4,'Category name');
INSERT INTO AllMusica (Imagen, Nombre, Songs, Instrumental) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FChillHop.png?alt=media&token=344d4cf1-4a4f-45a8-88c1-9b0939656501','Space Travel',9,'Ambient');
INSERT INTO AllMusica (Imagen, Nombre, Songs, Instrumental) VALUES ('https://firebasestorage.googleapis.com/v0/b/upn-firebase-proyect.appspot.com/o/SleepSounds%2FImagenes%2FLullaby.png?alt=media&token=41081b2a-4cfe-4472-908d-0ed5f7a1b25f','Lullaby',7,'Instrumental');


INSERT INTO Detalle (Nombre, Songs, Instrumental, tituloDeDetalle, Detalle) VALUES ('Guitar Camp',7,'Instrumental','About this pack','An acoustic mix has been specially selected for you. The camping atmosphere will help you improve your sleep and your body as a whole. Your dreams will be delightful and vivid.')