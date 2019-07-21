USE [SSTLocal]
GO
/****** Object:  Table [dbo].[MedidasDeControleExistentes]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedidasDeControleExistentes](
	[IDMedidasDeControle] [nvarchar](128) NOT NULL,
	[MedidasExistentes] [nvarchar](max) NULL,
	[EClassificacaoDaMedida] [int] NOT NULL,
	[NomeDaImagem] [nvarchar](max) NULL,
	[Imagem] [nvarchar](max) NULL,
	[EControle] [int] NOT NULL,
	[IDTipoDeRisco] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.MedidasDeControleExistentes] PRIMARY KEY CLUSTERED 
(
	[IDMedidasDeControle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rel_AtivEstabTipoRisco]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rel_AtivEstabTipoRisco](
	[IDAtivEstabTipoRisco] [nvarchar](128) NOT NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Rel_AtivEstabTipoRisco] PRIMARY KEY CLUSTERED 
(
	[IDAtivEstabTipoRisco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbAdmissao]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAdmissao](
	[IDAdmissao] [nvarchar](128) NOT NULL,
	[IDEmpregado] [nvarchar](128) NULL,
	[IDEmpresa] [nvarchar](128) NULL,
	[DataAdmissao] [nvarchar](max) NOT NULL,
	[DataDemissao] [nvarchar](max) NULL,
	[Imagem] [nvarchar](max) NULL,
	[Admitido] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbAdmissao] PRIMARY KEY CLUSTERED 
(
	[IDAdmissao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbAlocacao]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAlocacao](
	[IDAlocacao] [nvarchar](128) NOT NULL,
	[IdAdmissao] [nvarchar](128) NULL,
	[Ativado] [nvarchar](max) NULL,
	[IdContrato] [nvarchar](128) NULL,
	[IDDepartamento] [nvarchar](128) NULL,
	[IDCargo] [nvarchar](128) NULL,
	[IDFuncao] [nvarchar](128) NULL,
	[idEstabelecimento] [nvarchar](128) NULL,
	[IDEquipe] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbAlocacao] PRIMARY KEY CLUSTERED 
(
	[IDAlocacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbAnaliseRisco]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAnaliseRisco](
	[IDAnaliseRisco] [nvarchar](128) NOT NULL,
	[IDAtividadeAlocada] [nvarchar](128) NULL,
	[IDAlocacao] [nvarchar](128) NULL,
	[IDAtividadesDoEstabelecimento] [nvarchar](max) NULL,
	[IDEventoPerigoso] [nvarchar](max) NULL,
	[IDPerigoPotencial] [nvarchar](max) NULL,
	[Conhecimento] [bit] NOT NULL,
	[BemEstar] [bit] NOT NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
	[RiscoAdicional] [nvarchar](max) NULL,
	[ControleProposto] [nvarchar](max) NULL,
	[DataRealizada] [datetime] NOT NULL DEFAULT ('1900-01-01T00:00:00.000'),
 CONSTRAINT [PK_dbo.tbAnaliseRisco] PRIMARY KEY CLUSTERED 
(
	[IDAnaliseRisco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbAtividade]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAtividade](
	[IDAtividade] [nvarchar](128) NOT NULL,
	[Descricao] [nvarchar](max) NULL,
	[idFuncao] [nvarchar](128) NULL,
	[idDiretoria] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
	[NomeDaImagem] [nvarchar](max) NULL,
	[Imagem] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tbAtividade] PRIMARY KEY CLUSTERED 
(
	[IDAtividade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbAtividadeAlocada]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAtividadeAlocada](
	[IDAtividadeAlocada] [nvarchar](128) NOT NULL,
	[idAtividadesDoEstabelecimento] [nvarchar](128) NULL,
	[idAlocacao] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbAtividadeAlocada] PRIMARY KEY CLUSTERED 
(
	[IDAtividadeAlocada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbAtividadeFuncaoLiberada]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAtividadeFuncaoLiberada](
	[IDAtividadeFuncaoLiberada] [nvarchar](128) NOT NULL,
	[IDFuncao] [nvarchar](128) NULL,
	[IDAtividade] [nvarchar](128) NULL,
	[IDAlocacao] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbAtividadeFuncaoLiberada] PRIMARY KEY CLUSTERED 
(
	[IDAtividadeFuncaoLiberada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbAtividadesDoEstabelecimento]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAtividadesDoEstabelecimento](
	[IDAtividadesDoEstabelecimento] [nvarchar](128) NOT NULL,
	[Ativo] [nvarchar](max) NULL,
	[DescricaoDestaAtividade] [nvarchar](max) NULL,
	[NomeDaImagem] [nvarchar](max) NULL,
	[Imagem] [nvarchar](max) NULL,
	[IDEstabelecimentoImagens] [nvarchar](128) NULL,
	[IDEstabelecimento] [nvarchar](128) NULL,
	[IDPossiveisDanos] [nvarchar](128) NULL,
	[IDEventoPerigoso] [nvarchar](128) NULL,
	[IDAlocacao] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbAtividadesDoEstabelecimento] PRIMARY KEY CLUSTERED 
(
	[IDAtividadesDoEstabelecimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbCargo]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCargo](
	[IDCargo] [nvarchar](128) NOT NULL,
	[NomeDoCargo] [nvarchar](max) NULL,
	[IDDiretoria] [nvarchar](128) NOT NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbCargo] PRIMARY KEY CLUSTERED 
(
	[IDCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbCNAE]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCNAE](
	[IDCNAE] [nvarchar](128) NOT NULL,
	[Codigo] [nvarchar](max) NULL,
	[DescricaoCNAE] [nvarchar](max) NULL,
	[Titulo] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbCNAE] PRIMARY KEY CLUSTERED 
(
	[IDCNAE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbContrato]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbContrato](
	[IDContrato] [nvarchar](128) NOT NULL,
	[NumeroContrato] [nvarchar](max) NULL,
	[DescricaoContrato] [nvarchar](max) NULL,
	[DataInicio] [nvarchar](max) NULL,
	[DataFim] [nvarchar](max) NULL,
	[IdEmpresa] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbContrato] PRIMARY KEY CLUSTERED 
(
	[IDContrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbDepartamento]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDepartamento](
	[IDDepartamento] [nvarchar](128) NOT NULL,
	[Codigo] [nvarchar](max) NOT NULL,
	[Sigla] [nvarchar](max) NOT NULL,
	[Descricao] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[IDEmpresa] [nvarchar](128) NULL,
	[IDDiretoria] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbDepartamento] PRIMARY KEY CLUSTERED 
(
	[IDDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbDiretoria]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDiretoria](
	[IDDiretoria] [nvarchar](128) NOT NULL,
	[Codigo] [nvarchar](max) NOT NULL,
	[Sigla] [nvarchar](max) NOT NULL,
	[Descricao] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[IDEmpresa] [nvarchar](128) NOT NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbDiretoria] PRIMARY KEY CLUSTERED 
(
	[IDDiretoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbDocAtividade]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDocAtividade](
	[IDDocAtividade] [nvarchar](128) NOT NULL,
	[IDUniqueKey] [nvarchar](max) NULL,
	[IDDocumentosEmpregado] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
	[UniqueKey_IDAtividade] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.tbDocAtividade] PRIMARY KEY CLUSTERED 
(
	[IDDocAtividade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbDocsPorAtividade]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDocsPorAtividade](
	[IDDocAtividade] [nvarchar](128) NOT NULL,
	[IDAtividade] [nvarchar](128) NULL,
	[IDDocumentosEmpregado] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbDocsPorAtividade] PRIMARY KEY CLUSTERED 
(
	[IDDocAtividade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbDocumentosPessoal]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDocumentosPessoal](
	[IDDocumentosEmpregado] [nvarchar](128) NOT NULL,
	[NomeDocumento] [nvarchar](max) NULL,
	[DescriçãoDocumento] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbDocumentosPessoal] PRIMARY KEY CLUSTERED 
(
	[IDDocumentosEmpregado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbEmpregado]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbEmpregado](
	[IDEmpregado] [nvarchar](128) NOT NULL,
	[CPF] [nvarchar](max) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Endereco] [nvarchar](max) NULL,
	[Admitido] [bit] NOT NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbEmpregado] PRIMARY KEY CLUSTERED 
(
	[IDEmpregado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbEmpresa]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbEmpresa](
	[IDEmpresa] [nvarchar](128) NOT NULL,
	[CNPJ] [nvarchar](max) NOT NULL,
	[RazaoSocial] [nvarchar](max) NULL,
	[NomeFantasia] [nvarchar](max) NOT NULL,
	[URL_Site] [nvarchar](max) NULL,
	[URL_LogoMarca] [nvarchar](max) NOT NULL,
	[URL_WS] [nvarchar](max) NULL,
	[URL_AD] [nvarchar](max) NULL,
	[RamoDeAtividade] [nvarchar](max) NULL,
	[idCNAE] [nvarchar](128) NULL,
	[GrauDeRisco] [nvarchar](max) NULL,
	[GrupoCIPA] [nvarchar](max) NULL,
	[Endereco] [nvarchar](max) NULL,
	[NumeroDeEmpregados] [nvarchar](max) NULL,
	[Masculino] [nvarchar](max) NULL,
	[Feminino] [nvarchar](max) NULL,
	[Menores] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbEmpresa] PRIMARY KEY CLUSTERED 
(
	[IDEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbEquipe]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbEquipe](
	[IDEquipe] [nvarchar](128) NOT NULL,
	[NomeDaEquipe] [nvarchar](max) NULL,
	[ResumoAtividade] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbEquipe] PRIMARY KEY CLUSTERED 
(
	[IDEquipe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbEstabelecimento]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbEstabelecimento](
	[IDEstabelecimento] [nvarchar](128) NOT NULL,
	[TipoDeEstabelecimento] [int] NOT NULL,
	[Codigo] [nvarchar](max) NULL,
	[Descricao] [nvarchar](max) NULL,
	[NomeCompleto] [nvarchar](max) NULL,
	[IDDepartamento] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbEstabelecimento] PRIMARY KEY CLUSTERED 
(
	[IDEstabelecimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbEstabelecimentoAmbiente]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbEstabelecimentoAmbiente](
	[IDEstabelecimentoImagens] [nvarchar](128) NOT NULL,
	[ResumoDoLocal] [nvarchar](max) NULL,
	[NomeDaImagem] [nvarchar](max) NULL,
	[Imagem] [nvarchar](max) NULL,
	[IDEstabelecimento] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbEstabelecimentoAmbiente] PRIMARY KEY CLUSTERED 
(
	[IDEstabelecimentoImagens] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbEventoPerigoso]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbEventoPerigoso](
	[IDEventoPerigoso] [nvarchar](128) NOT NULL,
	[Descricao] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbEventoPerigoso] PRIMARY KEY CLUSTERED 
(
	[IDEventoPerigoso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbExposicao]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbExposicao](
	[IDExposicao] [nvarchar](128) NOT NULL,
	[idAtividadeAlocada] [nvarchar](128) NULL,
	[idAlocacao] [nvarchar](max) NULL,
	[idTipoDeRisco] [nvarchar](128) NULL,
	[TempoEstimado] [nvarchar](max) NULL,
	[EExposicaoInsalubre] [int] NOT NULL,
	[EExposicaoCalor] [int] NOT NULL,
	[EExposicaoSeg] [int] NOT NULL,
	[EProbabilidadeSeg] [int] NOT NULL,
	[ESeveridadeSeg] [int] NOT NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbExposicao] PRIMARY KEY CLUSTERED 
(
	[IDExposicao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbFuncao]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbFuncao](
	[IDFuncao] [nvarchar](128) NOT NULL,
	[NomeDaFuncao] [nvarchar](max) NULL,
	[IdCargo] [nvarchar](128) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbFuncao] PRIMARY KEY CLUSTERED 
(
	[IDFuncao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbPerigoPotencial]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbPerigoPotencial](
	[IDPerigoPotencial] [nvarchar](128) NOT NULL,
	[DescricaoEvento] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbPerigoPotencial] PRIMARY KEY CLUSTERED 
(
	[IDPerigoPotencial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbPlanoDeAcao]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbPlanoDeAcao](
	[IDPlanoDeAcao] [nvarchar](128) NOT NULL,
	[TipoDoPlanoDeAcao] [int] NOT NULL,
	[DescricaoDoPlanoDeAcao] [nvarchar](200) NOT NULL,
	[Responsavel] [nvarchar](max) NULL,
	[DataPrevista] [datetime] NOT NULL,
	[Entregue] [nvarchar](max) NULL,
	[ResponsavelPelaEntrega] [nvarchar](max) NULL,
	[Identificador] [nvarchar](max) NULL,
	[Gerencia] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbPlanoDeAcao] PRIMARY KEY CLUSTERED 
(
	[IDPlanoDeAcao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbPossiveisDanos]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbPossiveisDanos](
	[IDPossiveisDanos] [nvarchar](128) NOT NULL,
	[DescricaoDanos] [nvarchar](max) NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbPossiveisDanos] PRIMARY KEY CLUSTERED 
(
	[IDPossiveisDanos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbTipoDeRisco]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTipoDeRisco](
	[IDTipoDeRisco] [nvarchar](128) NOT NULL,
	[idPerigoPotencial] [nvarchar](128) NULL,
	[idPossiveisDanos] [nvarchar](128) NULL,
	[idEventoPerigoso] [nvarchar](128) NULL,
	[idAtividadesDoEstabelecimento] [nvarchar](128) NULL,
	[EClasseDoRisco] [int] NOT NULL,
	[FonteGeradora] [nvarchar](max) NULL,
	[Tragetoria] [nvarchar](max) NULL,
	[Vinculado] [bit] NOT NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
	[idAtividade] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.tbTipoDeRisco] PRIMARY KEY CLUSTERED 
(
	[IDTipoDeRisco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbUsuario]    Script Date: 08/07/2019 10:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUsuario](
	[IDUsuario] [nvarchar](128) NOT NULL,
	[CPF] [nvarchar](max) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Login] [nvarchar](max) NOT NULL,
	[Senha] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[IDEmpresa] [nvarchar](max) NOT NULL,
	[IDDepartamento] [nvarchar](max) NOT NULL,
	[TipoDeAcesso] [int] NOT NULL,
	[UsuarioInclusao] [nvarchar](max) NULL,
	[DataInclusao] [datetime] NOT NULL,
	[UsuarioExclusao] [nvarchar](max) NULL,
	[DataExclusao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tbUsuario] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[MedidasDeControleExistentes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MedidasDeControleExistentes_dbo.tbTipoDeRisco_IDTipoDeRisco] FOREIGN KEY([IDTipoDeRisco])
REFERENCES [dbo].[tbTipoDeRisco] ([IDTipoDeRisco])
GO
ALTER TABLE [dbo].[MedidasDeControleExistentes] CHECK CONSTRAINT [FK_dbo.MedidasDeControleExistentes_dbo.tbTipoDeRisco_IDTipoDeRisco]
GO
ALTER TABLE [dbo].[tbAdmissao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAdmissao_dbo.tbEmpregado_IDEmpregado] FOREIGN KEY([IDEmpregado])
REFERENCES [dbo].[tbEmpregado] ([IDEmpregado])
GO
ALTER TABLE [dbo].[tbAdmissao] CHECK CONSTRAINT [FK_dbo.tbAdmissao_dbo.tbEmpregado_IDEmpregado]
GO
ALTER TABLE [dbo].[tbAdmissao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAdmissao_dbo.tbEmpresa_IDEmpresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[tbEmpresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[tbAdmissao] CHECK CONSTRAINT [FK_dbo.tbAdmissao_dbo.tbEmpresa_IDEmpresa]
GO
ALTER TABLE [dbo].[tbAlocacao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbAdmissao_IdAdmissao] FOREIGN KEY([IdAdmissao])
REFERENCES [dbo].[tbAdmissao] ([IDAdmissao])
GO
ALTER TABLE [dbo].[tbAlocacao] CHECK CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbAdmissao_IdAdmissao]
GO
ALTER TABLE [dbo].[tbAlocacao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbCargo_IDCargo] FOREIGN KEY([IDCargo])
REFERENCES [dbo].[tbCargo] ([IDCargo])
GO
ALTER TABLE [dbo].[tbAlocacao] CHECK CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbCargo_IDCargo]
GO
ALTER TABLE [dbo].[tbAlocacao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbContrato_IdContrato] FOREIGN KEY([IdContrato])
REFERENCES [dbo].[tbContrato] ([IDContrato])
GO
ALTER TABLE [dbo].[tbAlocacao] CHECK CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbContrato_IdContrato]
GO
ALTER TABLE [dbo].[tbAlocacao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbDepartamento_IDDepartamento] FOREIGN KEY([IDDepartamento])
REFERENCES [dbo].[tbDepartamento] ([IDDepartamento])
GO
ALTER TABLE [dbo].[tbAlocacao] CHECK CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbDepartamento_IDDepartamento]
GO
ALTER TABLE [dbo].[tbAlocacao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbEquipe_IDEquipe] FOREIGN KEY([IDEquipe])
REFERENCES [dbo].[tbEquipe] ([IDEquipe])
GO
ALTER TABLE [dbo].[tbAlocacao] CHECK CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbEquipe_IDEquipe]
GO
ALTER TABLE [dbo].[tbAlocacao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbEstabelecimento_idEstabelecimento] FOREIGN KEY([idEstabelecimento])
REFERENCES [dbo].[tbEstabelecimento] ([IDEstabelecimento])
GO
ALTER TABLE [dbo].[tbAlocacao] CHECK CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbEstabelecimento_idEstabelecimento]
GO
ALTER TABLE [dbo].[tbAlocacao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbFuncao_IDFuncao] FOREIGN KEY([IDFuncao])
REFERENCES [dbo].[tbFuncao] ([IDFuncao])
GO
ALTER TABLE [dbo].[tbAlocacao] CHECK CONSTRAINT [FK_dbo.tbAlocacao_dbo.tbFuncao_IDFuncao]
GO
ALTER TABLE [dbo].[tbAnaliseRisco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAnaliseRisco_dbo.tbAlocacao_IDAlocacao] FOREIGN KEY([IDAlocacao])
REFERENCES [dbo].[tbAlocacao] ([IDAlocacao])
GO
ALTER TABLE [dbo].[tbAnaliseRisco] CHECK CONSTRAINT [FK_dbo.tbAnaliseRisco_dbo.tbAlocacao_IDAlocacao]
GO
ALTER TABLE [dbo].[tbAnaliseRisco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAnaliseRisco_dbo.tbAtividadeAlocada_IDAtividadeAlocada] FOREIGN KEY([IDAtividadeAlocada])
REFERENCES [dbo].[tbAtividadeAlocada] ([IDAtividadeAlocada])
GO
ALTER TABLE [dbo].[tbAnaliseRisco] CHECK CONSTRAINT [FK_dbo.tbAnaliseRisco_dbo.tbAtividadeAlocada_IDAtividadeAlocada]
GO
ALTER TABLE [dbo].[tbAtividade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividade_dbo.tbDiretoria_idDiretoria] FOREIGN KEY([idDiretoria])
REFERENCES [dbo].[tbDiretoria] ([IDDiretoria])
GO
ALTER TABLE [dbo].[tbAtividade] CHECK CONSTRAINT [FK_dbo.tbAtividade_dbo.tbDiretoria_idDiretoria]
GO
ALTER TABLE [dbo].[tbAtividade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividade_dbo.tbFuncao_idFuncao] FOREIGN KEY([idFuncao])
REFERENCES [dbo].[tbFuncao] ([IDFuncao])
GO
ALTER TABLE [dbo].[tbAtividade] CHECK CONSTRAINT [FK_dbo.tbAtividade_dbo.tbFuncao_idFuncao]
GO
ALTER TABLE [dbo].[tbAtividadeAlocada]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividadeAlocada_dbo.tbAlocacao_idAlocacao] FOREIGN KEY([idAlocacao])
REFERENCES [dbo].[tbAlocacao] ([IDAlocacao])
GO
ALTER TABLE [dbo].[tbAtividadeAlocada] CHECK CONSTRAINT [FK_dbo.tbAtividadeAlocada_dbo.tbAlocacao_idAlocacao]
GO
ALTER TABLE [dbo].[tbAtividadeAlocada]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividadeAlocada_dbo.tbAtividadesDoEstabelecimento_idAtividadesDoEstabelecimento] FOREIGN KEY([idAtividadesDoEstabelecimento])
REFERENCES [dbo].[tbAtividadesDoEstabelecimento] ([IDAtividadesDoEstabelecimento])
GO
ALTER TABLE [dbo].[tbAtividadeAlocada] CHECK CONSTRAINT [FK_dbo.tbAtividadeAlocada_dbo.tbAtividadesDoEstabelecimento_idAtividadesDoEstabelecimento]
GO
ALTER TABLE [dbo].[tbAtividadeFuncaoLiberada]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividadeFuncaoLiberada_dbo.tbAlocacao_IDAlocacao] FOREIGN KEY([IDAlocacao])
REFERENCES [dbo].[tbAlocacao] ([IDAlocacao])
GO
ALTER TABLE [dbo].[tbAtividadeFuncaoLiberada] CHECK CONSTRAINT [FK_dbo.tbAtividadeFuncaoLiberada_dbo.tbAlocacao_IDAlocacao]
GO
ALTER TABLE [dbo].[tbAtividadeFuncaoLiberada]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividadeFuncaoLiberada_dbo.tbAtividade_IDAtividade] FOREIGN KEY([IDAtividade])
REFERENCES [dbo].[tbAtividade] ([IDAtividade])
GO
ALTER TABLE [dbo].[tbAtividadeFuncaoLiberada] CHECK CONSTRAINT [FK_dbo.tbAtividadeFuncaoLiberada_dbo.tbAtividade_IDAtividade]
GO
ALTER TABLE [dbo].[tbAtividadeFuncaoLiberada]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividadeFuncaoLiberada_dbo.tbFuncao_IDFuncao] FOREIGN KEY([IDFuncao])
REFERENCES [dbo].[tbFuncao] ([IDFuncao])
GO
ALTER TABLE [dbo].[tbAtividadeFuncaoLiberada] CHECK CONSTRAINT [FK_dbo.tbAtividadeFuncaoLiberada_dbo.tbFuncao_IDFuncao]
GO
ALTER TABLE [dbo].[tbAtividadesDoEstabelecimento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividadesDoEstabelecimento_dbo.tbEstabelecimento_IDEstabelecimento] FOREIGN KEY([IDEstabelecimento])
REFERENCES [dbo].[tbEstabelecimento] ([IDEstabelecimento])
GO
ALTER TABLE [dbo].[tbAtividadesDoEstabelecimento] CHECK CONSTRAINT [FK_dbo.tbAtividadesDoEstabelecimento_dbo.tbEstabelecimento_IDEstabelecimento]
GO
ALTER TABLE [dbo].[tbAtividadesDoEstabelecimento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividadesDoEstabelecimento_dbo.tbEstabelecimentoAmbiente_IDEstabelecimentoImagens] FOREIGN KEY([IDEstabelecimentoImagens])
REFERENCES [dbo].[tbEstabelecimentoAmbiente] ([IDEstabelecimentoImagens])
GO
ALTER TABLE [dbo].[tbAtividadesDoEstabelecimento] CHECK CONSTRAINT [FK_dbo.tbAtividadesDoEstabelecimento_dbo.tbEstabelecimentoAmbiente_IDEstabelecimentoImagens]
GO
ALTER TABLE [dbo].[tbAtividadesDoEstabelecimento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividadesDoEstabelecimento_dbo.tbEventoPerigoso_IDEventoPerigoso] FOREIGN KEY([IDEventoPerigoso])
REFERENCES [dbo].[tbEventoPerigoso] ([IDEventoPerigoso])
GO
ALTER TABLE [dbo].[tbAtividadesDoEstabelecimento] CHECK CONSTRAINT [FK_dbo.tbAtividadesDoEstabelecimento_dbo.tbEventoPerigoso_IDEventoPerigoso]
GO
ALTER TABLE [dbo].[tbAtividadesDoEstabelecimento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbAtividadesDoEstabelecimento_dbo.tbPossiveisDanos_IDPossiveisDanos] FOREIGN KEY([IDPossiveisDanos])
REFERENCES [dbo].[tbPossiveisDanos] ([IDPossiveisDanos])
GO
ALTER TABLE [dbo].[tbAtividadesDoEstabelecimento] CHECK CONSTRAINT [FK_dbo.tbAtividadesDoEstabelecimento_dbo.tbPossiveisDanos_IDPossiveisDanos]
GO
ALTER TABLE [dbo].[tbCargo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbCargo_dbo.tbDiretoria_IDDiretoria] FOREIGN KEY([IDDiretoria])
REFERENCES [dbo].[tbDiretoria] ([IDDiretoria])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbCargo] CHECK CONSTRAINT [FK_dbo.tbCargo_dbo.tbDiretoria_IDDiretoria]
GO
ALTER TABLE [dbo].[tbContrato]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbContrato_dbo.tbEmpresa_IdEmpresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[tbEmpresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[tbContrato] CHECK CONSTRAINT [FK_dbo.tbContrato_dbo.tbEmpresa_IdEmpresa]
GO
ALTER TABLE [dbo].[tbDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbDepartamento_dbo.tbDiretoria_IDDiretoria] FOREIGN KEY([IDDiretoria])
REFERENCES [dbo].[tbDiretoria] ([IDDiretoria])
GO
ALTER TABLE [dbo].[tbDepartamento] CHECK CONSTRAINT [FK_dbo.tbDepartamento_dbo.tbDiretoria_IDDiretoria]
GO
ALTER TABLE [dbo].[tbDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbDepartamento_dbo.tbEmpresa_IDEmpresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[tbEmpresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[tbDepartamento] CHECK CONSTRAINT [FK_dbo.tbDepartamento_dbo.tbEmpresa_IDEmpresa]
GO
ALTER TABLE [dbo].[tbDiretoria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbDiretoria_dbo.tbEmpresa_IDEmpresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[tbEmpresa] ([IDEmpresa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbDiretoria] CHECK CONSTRAINT [FK_dbo.tbDiretoria_dbo.tbEmpresa_IDEmpresa]
GO
ALTER TABLE [dbo].[tbDocAtividade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbDocAtividade_dbo.tbAtividade_UniqueKey_IDAtividade] FOREIGN KEY([UniqueKey_IDAtividade])
REFERENCES [dbo].[tbAtividade] ([IDAtividade])
GO
ALTER TABLE [dbo].[tbDocAtividade] CHECK CONSTRAINT [FK_dbo.tbDocAtividade_dbo.tbAtividade_UniqueKey_IDAtividade]
GO
ALTER TABLE [dbo].[tbDocAtividade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbDocAtividade_dbo.tbDocumentosPessoal_IDDocumentosEmpregado] FOREIGN KEY([IDDocumentosEmpregado])
REFERENCES [dbo].[tbDocumentosPessoal] ([IDDocumentosEmpregado])
GO
ALTER TABLE [dbo].[tbDocAtividade] CHECK CONSTRAINT [FK_dbo.tbDocAtividade_dbo.tbDocumentosPessoal_IDDocumentosEmpregado]
GO
ALTER TABLE [dbo].[tbDocsPorAtividade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbDocsPorAtividade_dbo.tbAtividade_idAtividade] FOREIGN KEY([IDAtividade])
REFERENCES [dbo].[tbAtividade] ([IDAtividade])
GO
ALTER TABLE [dbo].[tbDocsPorAtividade] CHECK CONSTRAINT [FK_dbo.tbDocsPorAtividade_dbo.tbAtividade_idAtividade]
GO
ALTER TABLE [dbo].[tbDocsPorAtividade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbDocsPorAtividade_dbo.tbDocumentosEmpregado_IDDocumentosEmpregado] FOREIGN KEY([IDDocumentosEmpregado])
REFERENCES [dbo].[tbDocumentosPessoal] ([IDDocumentosEmpregado])
GO
ALTER TABLE [dbo].[tbDocsPorAtividade] CHECK CONSTRAINT [FK_dbo.tbDocsPorAtividade_dbo.tbDocumentosEmpregado_IDDocumentosEmpregado]
GO
ALTER TABLE [dbo].[tbEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbEmpresa_dbo.tbCNAE_idCNAE] FOREIGN KEY([idCNAE])
REFERENCES [dbo].[tbCNAE] ([IDCNAE])
GO
ALTER TABLE [dbo].[tbEmpresa] CHECK CONSTRAINT [FK_dbo.tbEmpresa_dbo.tbCNAE_idCNAE]
GO
ALTER TABLE [dbo].[tbEstabelecimento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbEstabelecimento_dbo.tbDepartamento_IDDepartamento] FOREIGN KEY([IDDepartamento])
REFERENCES [dbo].[tbDepartamento] ([IDDepartamento])
GO
ALTER TABLE [dbo].[tbEstabelecimento] CHECK CONSTRAINT [FK_dbo.tbEstabelecimento_dbo.tbDepartamento_IDDepartamento]
GO
ALTER TABLE [dbo].[tbEstabelecimentoAmbiente]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbEstabelecimentoAmbiente_dbo.tbEstabelecimento_IDEstabelecimento] FOREIGN KEY([IDEstabelecimento])
REFERENCES [dbo].[tbEstabelecimento] ([IDEstabelecimento])
GO
ALTER TABLE [dbo].[tbEstabelecimentoAmbiente] CHECK CONSTRAINT [FK_dbo.tbEstabelecimentoAmbiente_dbo.tbEstabelecimento_IDEstabelecimento]
GO
ALTER TABLE [dbo].[tbExposicao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbExposicao_dbo.tbAtividadeAlocada_idAtividadeAlocada] FOREIGN KEY([idAtividadeAlocada])
REFERENCES [dbo].[tbAtividadeAlocada] ([IDAtividadeAlocada])
GO
ALTER TABLE [dbo].[tbExposicao] CHECK CONSTRAINT [FK_dbo.tbExposicao_dbo.tbAtividadeAlocada_idAtividadeAlocada]
GO
ALTER TABLE [dbo].[tbExposicao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbExposicao_dbo.tbTipoDeRisco_idTipoDeRisco] FOREIGN KEY([idTipoDeRisco])
REFERENCES [dbo].[tbTipoDeRisco] ([IDTipoDeRisco])
GO
ALTER TABLE [dbo].[tbExposicao] CHECK CONSTRAINT [FK_dbo.tbExposicao_dbo.tbTipoDeRisco_idTipoDeRisco]
GO
ALTER TABLE [dbo].[tbFuncao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbFuncao_dbo.tbCargo_IdCargo] FOREIGN KEY([IdCargo])
REFERENCES [dbo].[tbCargo] ([IDCargo])
GO
ALTER TABLE [dbo].[tbFuncao] CHECK CONSTRAINT [FK_dbo.tbFuncao_dbo.tbCargo_IdCargo]
GO
ALTER TABLE [dbo].[tbTipoDeRisco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbTipoDeRisco_dbo.tbAtividade_idAtividade] FOREIGN KEY([idAtividade])
REFERENCES [dbo].[tbAtividade] ([IDAtividade])
GO
ALTER TABLE [dbo].[tbTipoDeRisco] CHECK CONSTRAINT [FK_dbo.tbTipoDeRisco_dbo.tbAtividade_idAtividade]
GO
ALTER TABLE [dbo].[tbTipoDeRisco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbTipoDeRisco_dbo.tbAtividadesDoEstabelecimento_idAtividadesDoEstabelecimento] FOREIGN KEY([idAtividadesDoEstabelecimento])
REFERENCES [dbo].[tbAtividadesDoEstabelecimento] ([IDAtividadesDoEstabelecimento])
GO
ALTER TABLE [dbo].[tbTipoDeRisco] CHECK CONSTRAINT [FK_dbo.tbTipoDeRisco_dbo.tbAtividadesDoEstabelecimento_idAtividadesDoEstabelecimento]
GO
ALTER TABLE [dbo].[tbTipoDeRisco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbTipoDeRisco_dbo.tbEventoPerigoso_idEventoPerigoso] FOREIGN KEY([idEventoPerigoso])
REFERENCES [dbo].[tbEventoPerigoso] ([IDEventoPerigoso])
GO
ALTER TABLE [dbo].[tbTipoDeRisco] CHECK CONSTRAINT [FK_dbo.tbTipoDeRisco_dbo.tbEventoPerigoso_idEventoPerigoso]
GO
ALTER TABLE [dbo].[tbTipoDeRisco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbTipoDeRisco_dbo.tbPerigoPotencial_idPerigoPotencial] FOREIGN KEY([idPerigoPotencial])
REFERENCES [dbo].[tbPerigoPotencial] ([IDPerigoPotencial])
GO
ALTER TABLE [dbo].[tbTipoDeRisco] CHECK CONSTRAINT [FK_dbo.tbTipoDeRisco_dbo.tbPerigoPotencial_idPerigoPotencial]
GO
ALTER TABLE [dbo].[tbTipoDeRisco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tbTipoDeRisco_dbo.tbPossiveisDanos_idPossiveisDanos] FOREIGN KEY([idPossiveisDanos])
REFERENCES [dbo].[tbPossiveisDanos] ([IDPossiveisDanos])
GO
ALTER TABLE [dbo].[tbTipoDeRisco] CHECK CONSTRAINT [FK_dbo.tbTipoDeRisco_dbo.tbPossiveisDanos_idPossiveisDanos]
GO
