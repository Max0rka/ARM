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
    
    public partial class DepartureBurn
    {
        public int DepartureBurnId { get; set; }
        public int DepartureId { get; set; }
        public int BurnTypeId { get; set; }
    
        public virtual BurnType BurnType { get; set; }
        public virtual Departure Departure { get; set; }
    }
}
