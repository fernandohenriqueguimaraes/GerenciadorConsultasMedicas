using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorConsultasMedicas.Models
{
    public class ListarConsultasMedicasPorMedico
    {
        public DateTime Data { get; set; }

        public TimeSpan Horario { get; set; }

        public string Paciente { get; set; }

    }
}