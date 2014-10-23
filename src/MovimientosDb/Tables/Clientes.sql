CREATE TABLE [dbo].[Clientes]
(
	[ClienteId] INT NOT NULL PRIMARY KEY, 
    [Nombre] VARCHAR(60) NOT NULL, 
    [ts] ROWVERSION NOT NULL
)
