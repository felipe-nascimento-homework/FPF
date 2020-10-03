using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VagaFPF.Models
{
    public class Rule
    {

        public int RuleID { get; set; }
        public string name { get; set; }
        public string active { get; set; }
        public DateTime created_at { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime modified_at { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }


}