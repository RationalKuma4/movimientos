CREATE TABLE [dbo].[Fianza]
(
	[FianzaId] INT NOT NULL , 
    [EndosoId] INT NOT NULL, 
    [FiadoId] INT NOT NULL, 
    [BeneficiarioId] INT NOT NULL, 
    [Estatus] CHAR(3) NOT NULL, 
    [Total] DECIMAL(18, 2) NOT NULL, 
    [ts] ROWVERSION NOT NULL, 
    PRIMARY KEY ([FianzaId],[EndosoId]), 
    CONSTRAINT [FK_Fianzas_Clientes__Fiados] FOREIGN KEY ([FiadoId]) REFERENCES [dbo].[Cliente]([ClienteId]), 
    CONSTRAINT [FK_Fianzas_Clientes__Beneficiarios] FOREIGN KEY ([BeneficiarioId]) REFERENCES [dbo].[Cliente]([ClienteId])
)
