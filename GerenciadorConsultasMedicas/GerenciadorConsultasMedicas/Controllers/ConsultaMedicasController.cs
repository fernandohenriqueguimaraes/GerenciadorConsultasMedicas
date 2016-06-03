using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciadorConsultasMedicas.Models;

namespace GerenciadorConsultasMedicas.Controllers
{
    public class ConsultaMedicasController : Controller
    {
        private GerenciadorConsultasMedicasEntities db = new GerenciadorConsultasMedicasEntities();

        // GET: ConsultaMedicas
        public ActionResult Index()
        {
            var consultasMedicas = db.ConsultaMedica.Include(c => c.Medicos).Include(c => c.Pacientes).OrderByDescending(c => c.Data).OrderByDescending(c => c.Horario);
            return View(consultasMedicas.ToList());
        }

        // GET: ConsultaMedicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultaMedica consultaMedica = db.ConsultaMedica.Find(id);
            if (consultaMedica == null)
            {
                return HttpNotFound();
            }
            return View(consultaMedica);
        }

        // GET: ConsultaMedicas/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> selectMedicosList = from m in db.Medicos join p in db.Pessoas
                                                            on m.Pessoa equals p.PessoaID
                                                            select new SelectListItem
                                                            {
                                                                Value = m.MedicoID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };
            IEnumerable<SelectListItem> selectPacientesList = from pc in db.Pacientes join p in db.Pessoas
                                                        on pc.Pessoa equals p.PessoaID
                                                            select new SelectListItem
                                                            {
                                                                Value = pc.PacienteID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };

            ViewBag.Medico = new SelectList(selectMedicosList, "Value", "Text");
            ViewBag.Paciente = new SelectList(selectPacientesList, "Value", "Text");
            return View();
        }

        // POST: ConsultaMedicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsultaMedicaID,Paciente,Medico,Queixa,Diagnostico,Data,Horario")] ConsultaMedica consultaMedica)
        {
            if (ModelState.IsValid)
            {
                db.ConsultaMedica.Add(consultaMedica);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex.InnerException.InnerException, "ConsultaMedicas", "Create"));
                }
            }

            IEnumerable<SelectListItem> selectMedicosList = from m in db.Medicos
                                                            join p in db.Pessoas
                                      on m.Pessoa equals p.PessoaID
                                                            select new SelectListItem
                                                            {
                                                                Value = m.MedicoID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };
            IEnumerable<SelectListItem> selectPacientesList = from pc in db.Pacientes
                                                              join p in db.Pessoas
                                on pc.Pessoa equals p.PessoaID
                                                              select new SelectListItem
                                                              {
                                                                  Value = pc.PacienteID.ToString(),
                                                                  Text = p.Nome + " " + p.Sobrenome
                                                              };

            ViewBag.Medico = new SelectList(selectMedicosList, "Value", "Text", consultaMedica.Medico);
            ViewBag.Paciente = new SelectList(selectPacientesList, "Value", "Text", consultaMedica.Paciente);
            return View(consultaMedica);
        }

        // GET: ConsultaMedicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultaMedica consultaMedica = db.ConsultaMedica.Find(id);
            if (consultaMedica == null)
            {
                return HttpNotFound();
            }

            IEnumerable<SelectListItem> selectMedicosList = from m in db.Medicos
                                                            join p in db.Pessoas
                                      on m.Pessoa equals p.PessoaID
                                                            select new SelectListItem
                                                            {
                                                                Value = m.MedicoID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };
            IEnumerable<SelectListItem> selectPacientesList = from pc in db.Pacientes
                                                              join p in db.Pessoas
                                on pc.Pessoa equals p.PessoaID
                                                              select new SelectListItem
                                                              {
                                                                  Value = pc.PacienteID.ToString(),
                                                                  Text = p.Nome + " " + p.Sobrenome
                                                              };

            ViewBag.Medico = new SelectList(selectMedicosList, "Value", "Text", consultaMedica.Medico);
            ViewBag.Paciente = new SelectList(selectPacientesList, "Value", "Text", consultaMedica.Paciente);

            return View(consultaMedica);
        }

        // POST: ConsultaMedicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsultaMedicaID,Paciente,Medico,Queixa,Diagnostico,Local,Data,Horario")] ConsultaMedica consultaMedica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultaMedica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> selectMedicosList = from m in db.Medicos
                                                            join p in db.Pessoas
                                      on m.Pessoa equals p.PessoaID
                                                            select new SelectListItem
                                                            {
                                                                Value = m.MedicoID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };
            IEnumerable<SelectListItem> selectPacientesList = from pc in db.Pacientes
                                                              join p in db.Pessoas
                                on pc.Pessoa equals p.PessoaID
                                                              select new SelectListItem
                                                              {
                                                                  Value = pc.PacienteID.ToString(),
                                                                  Text = p.Nome + " " + p.Sobrenome
                                                              };

            ViewBag.Medico = new SelectList(selectMedicosList, "Value", "Text", consultaMedica.Medico);
            ViewBag.Paciente = new SelectList(selectPacientesList, "Value", "Text", consultaMedica.Paciente);
            return View(consultaMedica);
        }

        // GET: ConsultaMedicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultaMedica consultaMedica = db.ConsultaMedica.Find(id);
            if (consultaMedica == null)
            {
                return HttpNotFound();
            }
            return View(consultaMedica);
        }

        // POST: ConsultaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConsultaMedica consultaMedica = db.ConsultaMedica.Find(id);
            db.ConsultaMedica.Remove(consultaMedica);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
