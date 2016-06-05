USE [GerenciadorConsultasMedicas]
GO

/****** Object:  Table [dbo].[ConsultaMedica]    Script Date: 04/06/2016 20:56:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ConsultaMedica](
	[ConsultaMedicaID] [int] IDENTITY(1,1) NOT NULL,
	[Paciente] [int] NOT NULL,
	[Medico] [int] NOT NULL,
	[Queixa] [varchar](1) NULL,
	[Diagnostico] [varchar](1) NULL,
	[Data] [date] NULL,
	[Horario] [time](7) NULL,
 CONSTRAINT [pk_consulta_pid] PRIMARY KEY CLUSTERED 
(
	[ConsultaMedicaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ConsultaMedica]  WITH CHECK ADD  CONSTRAINT [fk_consulta_medico_pid] FOREIGN KEY([Medico])
REFERENCES [dbo].[Medicos] ([MedicoID])
GO

ALTER TABLE [dbo].[ConsultaMedica] CHECK CONSTRAINT [fk_consulta_medico_pid]
GO

ALTER TABLE [dbo].[ConsultaMedica]  WITH CHECK ADD  CONSTRAINT [fk_consulta_paciente_pid] FOREIGN KEY([Paciente])
REFERENCES [dbo].[Pacientes] ([PacienteID])
GO

ALTER TABLE [dbo].[ConsultaMedica] CHECK CONSTRAINT [fk_consulta_paciente_pid]
GO


