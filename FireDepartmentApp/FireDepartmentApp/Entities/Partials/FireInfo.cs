using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartmentApp.Entities
{
    public partial class FireInfo
    {
        public string ListSubdivisions
        {
            get
            {
                string subdivisions = "";
                foreach (var i in FireInfoSubdivisions)
                    subdivisions += $"{i.Subdivision.SubdivisionName}, ";
                if (subdivisions.Length > 2)
                    subdivisions = subdivisions.Remove(subdivisions.Length - 2);
                return subdivisions;
            }
        }
    }
}
