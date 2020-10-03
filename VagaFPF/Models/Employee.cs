using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VagaFPF.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string name { get; set; }       
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public Decimal salary { get; set; }
        public string gender { get; set; }
        public string active { get; set; }
        public DateTime created_at { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime modified_at { get; set; }

        public int RuleID { get; set; }
        public virtual Rule Rule { get; set; }
    }
}