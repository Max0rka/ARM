using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartmentApp.Entities
{
    public partial class ServiceType
    {
        public bool DepartureChecked { get; set; } = false;
        public DateTime TimeDeparture { get; set; }
        public bool ArrivalChecked { get; set; } = false;
        public DateTime TimeArrival { get; set; }
        public short PeopleCount { get; set; }
        public static int PeopleCountGeneral { get; set; }
        public static int TechnicCountGeneral { get; set; }
        public short TechnicCount { get; set; }
    }
}
