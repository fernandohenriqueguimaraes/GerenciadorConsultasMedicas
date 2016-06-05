CREATE PROCEDURE [dbo].[ListarConsultasPorMedico] @IdMedico int
AS
IF (@IdMedico IS NOT NULL)
BEGIN
SELECT cm.Data, cm.Horario, CONCAT(ps2.Nome, SPACE(1), ps2.Sobrenome) AS "Paciente"
FROM ConsultaMedica cm 
JOIN Medicos m ON cm.Medico = m.MedicoID
JOIN Pessoas ps1 ON m.Pessoa = ps1.PessoaID
JOIN Pacientes p ON cm.Paciente = p.PacienteID
JOIN Pessoas ps2 ON p.Pessoa = ps2.PessoaID  
WHERE m.MedicoID = @IdMedico 
ORDER BY cm.Data, cm.Horario
END
ELSE 
BEGIN
SELECT cm.Data, cm.Horario, CONCAT(ps2.Nome, SPACE(1), ps2.Sobrenome) AS "Paciente"
FROM ConsultaMedica cm 
JOIN Medicos m ON cm.Medico = m.MedicoID
JOIN Pessoas ps1 ON m.Pessoa = ps1.PessoaID
JOIN Pacientes p ON cm.Paciente = p.PacienteID
JOIN Pessoas ps2 ON p.Pessoa = ps2.PessoaID  
ORDER BY cm.Data, cm.Horario 
END

GO


