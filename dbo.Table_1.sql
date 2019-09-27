CREATE TABLE [dbo].[Tiempos]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [fchJuego] DATETIME NULL, 
    [fchSorteo] DATETIME NOT NULL, 
    [Numero] INT NOT NULL, 
    [Apuesta] INT NOT NULL, 
    [hora] INT NULL, 
    [Identificador] VARCHAR(20) NULL
)
