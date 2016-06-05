CREATE PROCEDURE [dbo].[ListarHistoricoPaciente] @IdPaciente int
AS
BEGIN
SELECT cm.Data, cm.Horario, CONCAT(ps1.Nome, SPACE(1), ps1.Sobrenome) AS "Medico", e.Nome AS "Especialidade", cm.Queixa, cm.Diagnostico
FROM ConsultaMedica cm 
JOIN Medicos m ON cm.Medico = m.MedicoID
JOIN Pessoas ps1 ON m.Pessoa = ps1.PessoaID
JOIN Especialidades e ON m.Especialidade = e.EspecialidadeID
JOIN Pacientes p ON cm.Paciente = p.PacienteID
WHERE p.PacienteID = @IdPaciente
ORDER BY cm.Data, cm.Horario
END

GO


