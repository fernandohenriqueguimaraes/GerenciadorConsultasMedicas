using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using GerenciadorConsultasMedicas.Models;

namespace GerenciadorConsultasMedicas.Controllers
{
    public class ListarConsultasMedicasPorMedicoController : Controller
    {
        private GerenciadorConsultasMedicasEntities db = new GerenciadorConsultasMedicasEntities();

        // GET: ListarConsultasMedicasPorMedico/5
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var listaConsultasMedicasPorMedico = db.ListarConsultasPorMedico(id);
            if (listaConsultasMedicasPorMedico == null)
            {
                return HttpNotFound();
            }

            List<ListarConsultasMedicasPorMedico> listaConsultasMedicas = new List<ListarConsultasMedicasPorMedico>();
            var resultadoListaConsultasMedicas = listaConsultasMedicasPorMedico.ToList();

            for (int i = 0; i < resultadoListaConsultasMedicas.Count; i++)
            {
                ListarConsultasMedicasPorMedico listaConsultaMedica = new ListarConsultasMedicasPorMedico();
                listaConsultaMedica.Data = (DateTime)resultadoListaConsultasMedicas[i].Data;
                listaConsultaMedica.Horario = (TimeSpan)resultadoListaConsultasMedicas[i].Horario;
                listaConsultaMedica.Paciente = resultadoListaConsultasMedicas[i].Paciente;
                listaConsultasMedicas.Add(listaConsultaMedica);
            }
   
            return View(listaConsultasMedicas);
        }
    }
}