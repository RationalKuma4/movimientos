CREATE TABLE [dbo].[Movimiento]
(
	[FianzaId] INT NOT NULL , 
    [EndosoId] INT NOT NULL, 
    [MovimientoId] INT NOT NULL, 
    [Total] DECIMAL(18, 2) NOT NULL, 
    [Estatus] CHAR(3) NOT NULL, 
    [TipoMovimiento] CHAR(3) NOT NULL, 
    [ts] ROWVERSION NOT NULL, 
    PRIMARY KEY ([FianzaId], [MovimientoId], [EndosoId]), 
    CONSTRAINT [FK_Movimientos_Fianzas] FOREIGN KEY ([FianzaId], [EndosoId]) REFERENCES [dbo].[Fianza]([FianzaId], [EndosoId])
)
