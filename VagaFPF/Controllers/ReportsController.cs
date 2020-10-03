using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VagaFPF.DTO;
using VagaFPF.Models;

namespace VagaFPF.Controllers
{
    public class ReportsController : Controller
    {
        private EntityDBContext db = new EntityDBContext();
        // GET: Reports
        public ActionResult Index()
        {
            List<RelatorioDTO> resultado = ObterTotalSalarios();
            return View(resultado);
        }


        [HttpPost]
        public JsonResult NewChart()
        {
            List<object> iData = new List<object>();
            
            List<RelatorioDTO> resultado = ObterTotalSalarios();

            List<object> aLabels = new List<object>();
            List<object> aDatasets1 = new List<object>();

            foreach (RelatorioDTO item in resultado)
            {
                aLabels.Add(item.Departamento);
                aDatasets1.Add(item.Salario);
            }

            if (aLabels.Count > 0) {
                iData.Add(aLabels);
                iData.Add(aDatasets1);
            }
            

            return Json(iData, JsonRequestBehavior.AllowGet);
        }



        private List<RelatorioDTO> ObterTotalSalarios() {

            List<RelatorioDTO> resultado = db.Employees
             .GroupBy(g => g.RuleID)
             .Select(s => new RelatorioDTO
             {
                 Departamento = s.FirstOrDefault().Rule.name,
                 Salario = s.Sum(c => c.salary)
             }).ToList();

            return resultado;
        }

    }
}