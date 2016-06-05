USE [GerenciadorConsultasMedicas]
GO

/****** Object:  Table [dbo].[Medicos]    Script Date: 04/06/2016 20:57:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Medicos](
	[MedicoID] [int] IDENTITY(1,1) NOT NULL,
	[CRM] [char](5) NOT NULL,
	[Pessoa] [int] NOT NULL,
	[Especialidade] [int] NOT NULL,
	[Titularidade] [varchar](50) NULL,
 CONSTRAINT [pk_medico_pid] PRIMARY KEY CLUSTERED 
(
	[MedicoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [fk_medico_especialidade_pid] FOREIGN KEY([Especialidade])
REFERENCES [dbo].[Especialidades] ([EspecialidadeID])
GO

ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [fk_medico_especialidade_pid]
GO

ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [fk_medico_pessoa_pid] FOREIGN KEY([Pessoa])
REFERENCES [dbo].[Pessoas] ([PessoaID])
GO

ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [fk_medico_pessoa_pid]
GO


