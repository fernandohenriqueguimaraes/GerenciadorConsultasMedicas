//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GerenciadorConsultasMedicas.Models
{
    using System;
    
    public partial class ListarHistoricoPaciente_Result
    {
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<System.TimeSpan> Horario { get; set; }
        public string Medico { get; set; }
        public string Especialidade { get; set; }
        public string Queixa { get; set; }
        public string Diagnostico { get; set; }
    }
}
