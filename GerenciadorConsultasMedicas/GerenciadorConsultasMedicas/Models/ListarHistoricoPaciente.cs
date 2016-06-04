using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorConsultasMedicas.Models
{
    public class ListarHistoricoPaciente
    {
        public DateTime Data { get; set; }

        public TimeSpan Horario { get; set; }

        public string Medico { get; set; }

        public string Especialidade { get; set; }

        public string Queixa { get; set; }

        public string Diagnostico { get; set; }
    }
}