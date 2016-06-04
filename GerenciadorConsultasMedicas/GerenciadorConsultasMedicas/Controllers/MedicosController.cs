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
    public class MedicosController : Controller
    {
        private GerenciadorConsultasMedicasEntities db = new GerenciadorConsultasMedicasEntities();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include(m => m.Especialidades).Include(m => m.Pessoas);
            return View(medicos.ToList());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }

            var consultasMedicas = db.ListarConsultasPorIdMedico(id);

            return View(medicos);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> selectPessoasList = from p in db.Pessoas
                                                     select new SelectListItem
                                                     {
                                                         Value = p.PessoaID.ToString(),
                                                         Text = p.Nome + " " + p.Sobrenome
                                                     };

            ViewBag.Pessoa = new SelectList(selectPessoasList, "Value", "Text");
            ViewBag.Especialidade = new SelectList(db.Especialidades, "EspecialidadeID", "Nome");
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicoID,CRM,Pessoa,Especialidade,Titularidade")] Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            IEnumerable<SelectListItem> selectPessoasList = from p in db.Pessoas
                                                            select new SelectListItem
                                                            {
                                                                Value = p.PessoaID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };

            ViewBag.Pessoa = new SelectList(selectPessoasList, "Value", "Text");
            ViewBag.Especialidade = new SelectList(db.Especialidades, "EspecialidadeID", "Nome");

            return View(medicos);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            IEnumerable<SelectListItem> selectPessoasList = from p in db.Pessoas
                                                            select new SelectListItem
                                                            {
                                                                Value = p.PessoaID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };

            ViewBag.Pessoa = new SelectList(selectPessoasList, "Value", "Text", medicos.Pessoa);
            ViewBag.Especialidade = new SelectList(db.Especialidades, "EspecialidadeID", "Nome", medicos.Especialidade);
            return View(medicos);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicoID,CRM,Pessoa,Especialidade,Titularidade")] Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> selectPessoasList = from p in db.Pessoas
                                                            select new SelectListItem
                                                            {
                                                                Value = p.PessoaID.ToString(),
                                                                Text = p.Nome + " " + p.Sobrenome
                                                            };

            ViewBag.Pessoa = new SelectList(selectPessoasList, "Value", "Text", medicos.Pessoa);
            ViewBag.Especialidade = new SelectList(db.Especialidades, "EspecialidadeID", "Nome", medicos.Especialidade);
            return View(medicos);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicos medicos = db.Medicos.Find(id);
            db.Medicos.Remove(medicos);
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
