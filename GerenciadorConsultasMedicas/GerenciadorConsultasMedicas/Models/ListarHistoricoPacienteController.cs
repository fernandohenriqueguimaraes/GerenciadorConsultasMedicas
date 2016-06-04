using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using GerenciadorConsultasMedicas.Models;

namespace GerenciadorConsultasMedicas.Models
{
    public class ListarHistoricoPacienteController : Controller
    {
        private GerenciadorConsultasMedicasEntities db = new GerenciadorConsultasMedicasEntities();

        // GET: ListarHistoricoPaciente/5
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var consultaListaHistoricoPaciente = db.ListarHistoricoPaciente(id);
            if (consultaListaHistoricoPaciente == null)
            {
                return HttpNotFound();
            }

            List<ListarHistoricoPaciente> listaHistoricoPacientes = new List<ListarHistoricoPaciente>();
            var resultadoListaHistoricoPaciente = consultaListaHistoricoPaciente.ToList();

            for (int i = 0; i < resultadoListaHistoricoPaciente.Count(); i++)
            {
                ListarHistoricoPaciente listaHistoricoPaciente = new ListarHistoricoPaciente();
                listaHistoricoPaciente.Data = (DateTime)resultadoListaHistoricoPaciente[i].Data;
                listaHistoricoPaciente.Horario = (TimeSpan)resultadoListaHistoricoPaciente[i].Horario;
                listaHistoricoPaciente.Medico = resultadoListaHistoricoPaciente[i].Medico;
                listaHistoricoPaciente.Especialidade = resultadoListaHistoricoPaciente[i].Especialidade;
                listaHistoricoPaciente.Queixa = resultadoListaHistoricoPaciente[i].Queixa;
                listaHistoricoPaciente.Diagnostico = resultadoListaHistoricoPaciente[i].Diagnostico;
                listaHistoricoPacientes.Add(listaHistoricoPaciente);
            }

            return View(listaHistoricoPacientes);
        }
    }
}