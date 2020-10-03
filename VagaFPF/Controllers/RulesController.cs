using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VagaFPF.Models;

namespace VagaFPF.Controllers
{
    public class RulesController : Controller
    {
        private EntityDBContext db = new EntityDBContext();

        // GET: Rules
        public ActionResult Index()
        {
            return View(db.Rules.ToList());
        }

        [HttpPost]
        public ActionResult Pesquisar([Bind(Include = "name")] Models.Rule rule)
        {

            string pesquisa = rule.name;
            List<Models.Rule> lista;
            if (pesquisa.IsNullOrWhiteSpace())
            {
                lista = db.Rules.ToList();
            }
            else {
                lista = db.Rules
                    .Where(w => w.name.ToUpper().Contains(pesquisa.ToUpper()))
                    .ToList();
            }

            return View("Index", lista);
        }



        // GET: Rules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Rule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        // GET: Rules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RuleID,name,active,created_at,modified_at")] Models.Rule rule)
        {
            if (ModelState.IsValid)
            {
                DateTime dataAtual = DateTime.Now;
                rule.active = "A";
                rule.created_at = dataAtual;
                rule.modified_at = dataAtual;
                db.Rules.Add(rule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rule);
        }

        // GET: Rules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Rule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        // POST: Rules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RuleID,name,active,created_at,modified_at")] Models.Rule rule)
        {
            if (ModelState.IsValid)
            {
                DateTime dataAtual = DateTime.Now;
                rule.active = "A";
                rule.created_at = dataAtual;
                rule.modified_at = dataAtual;
                db.Entry(rule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rule);
        }

        // GET: Rules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Rule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        // POST: Rules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Rule rule = db.Rules.Find(id);
            db.Rules.Remove(rule);
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
