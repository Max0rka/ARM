using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartmentApp.Entities
{
    public partial class PositionType
    {
        public bool ArrivalChecked { get; set; } = false;
        public DateTime TimeArrival { get; set; }
        public static int PeopleCountGeneral {get;set;}
    }
}
