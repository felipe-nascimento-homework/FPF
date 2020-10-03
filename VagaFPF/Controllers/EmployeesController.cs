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
    public class EmployeesController : Controller
    {
        private EntityDBContext db = new EntityDBContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Rule);
            return View(employees.ToList());
        }


        [HttpPost]
        public ActionResult Pesquisar([Bind(Include = "name")] Models.Employee employee)
        {

            string pesquisa = employee.name;
            List<Models.Employee> lista;
            if (pesquisa.IsNullOrWhiteSpace())
            {
                lista = db.Employees.ToList();
            }
            else
            {
                lista = db.Employees
                    .Where(w => w.name.ToUpper().Contains(pesquisa.ToUpper()))
                    .ToList();
            }

            return View("Index", lista);
        }



        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.RuleID = new SelectList(db.Rules, "RuleID", "name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,name,salary,gender,active,created_at,modified_at,RuleID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                DateTime dataAtual = DateTime.Now;
                employee.gender = employee.gender.Substring(0, 1).ToUpper();
                employee.active = "A";
                employee.created_at = dataAtual;
                employee.modified_at = dataAtual;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RuleID = new SelectList(db.Rules, "RuleID", "name", employee.RuleID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.RuleID = new SelectList(db.Rules, "RuleID", "name", employee.RuleID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,name,salary,gender,active,created_at,modified_at,RuleID")] Employee employee)
        {
            if (ModelState.IsValid)
            {

                DateTime dataAtual = DateTime.Now;
                employee.gender = employee.gender.Substring(0, 1).ToUpper();
                employee.active = "A";
                employee.created_at = dataAtual;
                employee.modified_at = dataAtual;

                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RuleID = new SelectList(db.Rules, "RuleID", "name", employee.RuleID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
