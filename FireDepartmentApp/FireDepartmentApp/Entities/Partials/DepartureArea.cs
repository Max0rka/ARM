using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartmentApp.Entities
{
    public partial class DepartureArea
    {
        public string ListDivisions => ListDivisionValue();
        private string ListDivisionValue()
        {
            string divisions = "";
            foreach (var i in Subdivisions)
            {
                divisions += $"{i.Division.DivisionName}\n";

            }
            if (divisions.Length > 2)
                divisions = divisions.Remove(divisions.Length - 1);
            return divisions;
        }
    }
}
