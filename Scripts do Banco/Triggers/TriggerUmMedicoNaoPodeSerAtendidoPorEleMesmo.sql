CREATE TRIGGER [dbo].[UmMedicoNaoPodeSerAtendidoPorEleMesmo] ON [dbo].[ConsultaMedica]
FOR INSERT, UPDATE AS
IF EXISTS (SELECT * 
	FROM inserted i 
	JOIN Medicos m ON i.Medico = m.MedicoID 
	JOIN Pacientes p ON i.Paciente = p.PacienteID 
	WHERE m.Pessoa = p.Pessoa)
BEGIN
RAISERROR ('Você não pode agendar uma consulta médica para uma pessoa ser atendido por ela mesma', 16, 1);
ROLLBACK TRANSACTION
END
GO


