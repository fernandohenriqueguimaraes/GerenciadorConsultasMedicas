USE [GerenciadorConsultasMedicas]
GO

/****** Object:  Table [dbo].[Pacientes]    Script Date: 04/06/2016 20:58:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Pacientes](
	[PacienteID] [int] IDENTITY(1,1) NOT NULL,
	[Pessoa] [int] NOT NULL,
	[PlanoSaude] [varchar](50) NULL,
 CONSTRAINT [pk_paciente_pid] PRIMARY KEY CLUSTERED 
(
	[PacienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [fk_paciente_pessoa_pid] FOREIGN KEY([Pessoa])
REFERENCES [dbo].[Pessoas] ([PessoaID])
GO

ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [fk_paciente_pessoa_pid]
GO


