CREATE DATABASE DB_PruebaTecnica;
GO

USE DB_PruebaTecnica;
GO

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL
);
GO

SELECT * FROM Clientes;