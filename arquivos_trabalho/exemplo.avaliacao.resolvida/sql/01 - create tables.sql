USE [AppAvaliacao]
GO

/*	

------ Script de Rollback ------

DROP TABLE [ProvaDeConceito].[dbo].[Tarefa];
GO

DROP TABLE [ProvaDeConceito].[dbo].[Funcionario];
GO

*/

CREATE TABLE [dbo].[Funcionario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[Situacao] [char](1) NULL
)
GO


CREATE TABLE [dbo].[Tarefa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFuncionario] [int] NOT NULL,
	[Titulo] [varchar](200) NULL,
	[Descricao] [varchar](max) NULL,
	[Executada] [bit] NULL,
	[Situacao] [char](1) NULL
)
GO

ALTER TABLE [dbo].[Funcionario] ADD CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [dbo].[Tarefa] ADD CONSTRAINT [PK_Tarefa] PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [dbo].[Tarefa] ADD CONSTRAINT [FK_Tarefa_Funcionario] FOREIGN KEY([IdFuncionario]) REFERENCES [dbo].[Funcionario] ([Id])
GO