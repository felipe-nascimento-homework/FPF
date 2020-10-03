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
            
            List<RelatorioDTO> resultado = db.Employees
                .GroupBy(g => g.RuleID)
                .Select(s => new RelatorioDTO
                {
                    Departamento = s.FirstOrDefault().Rule.name,
                    Salario = s.Sum(c => c.salary)
                }).ToList();


            return View(resultado);
        }


        [HttpPost]
        public JsonResult NewChart()
        {
            List<object> iData = new List<object>();
            //Creating sample data  
            DataTable dt = new DataTable();
            dt.Columns.Add("Employee", System.Type.GetType("System.String"));
            dt.Columns.Add("Credit", System.Type.GetType("System.Int32"));

            DataRow dr = dt.NewRow();
            dr["Employee"] = "Sam";
            dr["Credit"] = 123;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = "Alex";
            dr["Credit"] = 456;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = "Michael";
            dr["Credit"] = 587;
            dt.Rows.Add(dr);
            //Looping and extracting each DataColumn to List<Object>  
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }


    }
}