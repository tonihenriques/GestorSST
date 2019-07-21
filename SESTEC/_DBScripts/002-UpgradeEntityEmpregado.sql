ALTER TABLE [dbo].[tbEmpregado] ALTER COLUMN [CPF] NVARCHAR(11) NOT NULL;

GO

ALTER TABLE [dbo].[tbEmpregado] ALTER COLUMN [Nome] NVARCHAR(100) NOT NULL;

GO

ALTER TABLE [dbo].[tbEmpregado] ALTER COLUMN [Email] NVARCHAR(50) NOT NULL;

GO

ALTER TABLE [dbo].[tbEmpregado] ALTER COLUMN [UsuarioInclusao] NVARCHAR(50) NULL;

GO

ALTER TABLE [dbo].[tbEmpregado] ALTER COLUMN [UsuarioExclusao] NVARCHAR(50) NULL;

GO

CREATE UNIQUE INDEX [IX_tbEmpregado_CPF] ON [dbo].[tbEmpregado] ([CPF]);

GO

CREATE INDEX [IX_tbEmpregado_Nome] ON [dbo].[tbEmpregado] ([Nome]);

GO

ALTER TABLE [dbo].[tbEmpregado] ADD [Telefone] nvarchar(50) NULL;

GO

ALTER TABLE [dbo].[tbEmpregado] ADD [Matricula] nvarchar(50) NULL;

GO

ALTER TABLE [dbo].[tbEmpregado] ADD [Status] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [dbo].[tbEmpregado] DROP COLUMN [Endereco];

GO

ALTER TABLE [dbo].[tbEmpregado] DROP COLUMN [Admitido];

GO