CREATE TABLE [dbo].[Veiculo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
	[Modelo] [nvarchar](100) NOT NULL,
	[Ano] [int] NOT NULL,
	[Placa] [nvarchar](7) NOT NULL,
	[Km] [int] NULL,
	[Cor] [nvarchar](20) NOT NULL,
	[Preco] [float] NOT NULL,
	[IdOpcional] [int] NULL,
	[PacoteICarros] [int] NULL,
	[PacoteWebMotors] [int] NULL,
 CONSTRAINT [PK_Veiculo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Veiculo] WITH CHECK ADD CONSTRAINT [FK_Veiculo_Opcional] FOREIGN KEY([IdOpcional])
REFERENCES[dbo].[Opcional]([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Veiculo] CHECK CONSTRAINT[FK_Veiculo_Opcional]
GO