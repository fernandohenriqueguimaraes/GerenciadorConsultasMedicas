CREATE TRIGGER [dbo].[GeriatrasSoApartirDe40Anos] ON [dbo].[ConsultaMedica]
FOR INSERT, UPDATE AS
IF EXISTS (SELECT *
	FROM inserted i 
	JOIN Medicos m ON i.Medico = m.MedicoID
	JOIN Especialidades e ON m.Especialidade = e.EspecialidadeID 
	JOIN Pacientes p ON i.Paciente = p.PacienteID
	JOIN Pessoas ps ON p.Pessoa = ps.PessoaID 
	WHERE e.Nome = 'Geriatria' AND
		(SELECT COUNT(*)
		 FROM Pessoas ps2
		 JOIN Pacientes p2 ON p2.Pessoa = ps2.PessoaID
		 JOIN inserted i2 ON i2.Paciente = p2.PacienteID
		 WHERE (DATEDIFF(hour,ps2.DataNascimento,GETDATE())/8766) < 18) > 0
	) 
BEGIN
RAISERROR ('Um Geriatra não pode atender um paciente com menos de 40 anos', 16, 1);
ROLLBACK TRANSACTION
END
GO


