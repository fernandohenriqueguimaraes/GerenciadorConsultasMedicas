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
    public class PacientesController : Controller
    {
        private GerenciadorConsultasMedicasEntities db = new GerenciadorConsultasMedicasEntities();

        // GET: Pacientes
        public ActionResult Index()
        {
            var pacientes = db.Pacientes.Include(p => p.Pessoas);
            return View(pacientes.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> selectPessoasList = from p in db.Pessoas
                                                            select new SelectListItem
                                                            {
                                                                Value = p.PessoaID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };

            ViewBag.Pessoa = new SelectList(selectPessoasList, "Value", "Text");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PacienteID,Pessoa,PlanoSaude")] Pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(pacientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            IEnumerable<SelectListItem> selectPessoasList = from p in db.Pessoas
                                                            select new SelectListItem
                                                            {
                                                                Value = p.PessoaID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };

            ViewBag.Pessoa = new SelectList(selectPessoasList, "Value", "Text", pacientes.Pessoa);

            return View(pacientes);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            IEnumerable<SelectListItem> selectPessoasList = from p in db.Pessoas
                                                            select new SelectListItem
                                                            {
                                                                Value = p.PessoaID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };

            ViewBag.Pessoa = new SelectList(selectPessoasList, "Value", "Text", pacientes.Pessoa);
            return View(pacientes);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PacienteID,Pessoa,PlanoSaude")] Pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> selectPessoasList = from p in db.Pessoas
                                                            select new SelectListItem
                                                            {
                                                                Value = p.PessoaID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };

            ViewBag.Pessoa = new SelectList(selectPessoasList, "Value", "Text", pacientes.Pessoa);
            return View(pacientes);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacientes pacientes = db.Pacientes.Find(id);
            db.Pacientes.Remove(pacientes);
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
