//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FireDepartmentApp.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepartureSubdivision
    {
        public int DepartureSubdivisionId { get; set; }
        public int SubdivisionId { get; set; }
        public int DepartureId { get; set; }
        public System.DateTime DateTimeDeparture { get; set; }
        public Nullable<System.DateTime> DateTimeArrival { get; set; }
        public Nullable<short> CountPeople { get; set; }
    
        public virtual Departure Departure { get; set; }
        public virtual Subdivision Subdivision { get; set; }
    }
}
