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
    
    public partial class TechnicDivision
    {
        public int TechnicDivisionId { get; set; }
        public int TechnicId { get; set; }
        public int DivisionId { get; set; }
        public short CountTechnic { get; set; }
    
        public virtual Division Division { get; set; }
        public virtual Technic Technic { get; set; }
    }
}
