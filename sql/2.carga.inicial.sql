INSERT INTO [ProvaDeConceito].[dbo].[Funcionario]([Nome],[Email],[Situacao])
VALUES ('Rodrigo','rlessa@ldsoft.com.br','A')
GO

INSERT INTO [ProvaDeConceito].[dbo].[Tarefa] ([IdFuncionario],[Descricao],[Executada])
VALUES((SELECT TOP 1 Id FROM [ProvaDeConceito].[dbo].[Funcionario] WHERE Email LIKE 'rlessa@ldsoft.com.br'),'Intranet - Corrigir o utilit�rio de altera��o de usu�rio APOL',0)
GO