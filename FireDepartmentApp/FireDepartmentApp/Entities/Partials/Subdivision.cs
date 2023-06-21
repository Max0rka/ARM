using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartmentApp.Entities
{
    public partial class Subdivision
    {
        public bool SubdivisionSelected { get; set; } = false;
        public string SubdivisionName => $"{Technic.TechnicName} {Division.DivisionName}";
        public bool DepartureChecked { get; set; } = false;
        public DateTime TimeDeparture { get; set; }
        public bool ArrivalChecked { get; set; } = false;
        public DateTime TimeArrival { get; set; }
        public short PeopleCount { get; set; }
        public static int PeopleCountGeneral { get; set; }
        public short PeopleCountOldValue { get; set; }
    }
}
