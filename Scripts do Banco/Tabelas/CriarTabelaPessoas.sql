USE [GerenciadorConsultasMedicas]
GO

/****** Object:  Table [dbo].[Pessoas]    Script Date: 04/06/2016 20:58:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Pessoas](
	[PessoaID] [int] IDENTITY(1,1) NOT NULL,
	[CPF] [char](14) NULL,
	[Nome] [varchar](50) NOT NULL,
	[Sobrenome] [varchar](50) NOT NULL,
	[Sexo] [char](1) NULL,
	[DataNascimento] [date] NULL,
 CONSTRAINT [pk_pessoa_pid] PRIMARY KEY CLUSTERED 
(
	[PessoaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


