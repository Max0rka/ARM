using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartmentApp.Entities
{
    public partial class Division
    {
        public string ListTechnic => ListTechnicValue();
        private string ListTechnicValue()
        {
            string technics = "";
            foreach(var i in TechnicDivisions)
            {
                technics += $"{i.Technic.TechnicName} - {i.CountTechnic} ед;\n";
                
            }
            if (technics.Length > 2)
                technics = technics.Remove(technics.Length - 1);
            return technics;
        }
        public bool DivisionSelected { get; set; } = false;
    }
}
