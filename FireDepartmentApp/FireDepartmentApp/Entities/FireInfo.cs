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
    
    public partial class FireInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FireInfo()
        {
            this.FireInfoSubdivisions = new HashSet<FireInfoSubdivision>();
        }
    
        public int FireInfoId { get; set; }
        public System.DateTime DateTimeEntry { get; set; }
        public int DepartureId { get; set; }
        public Nullable<int> BroadcastId { get; set; }
        public Nullable<int> BarrelTypeId { get; set; }
        public Nullable<byte> BarrelCount { get; set; }
        public Nullable<int> CombatAreaId { get; set; }
        public Nullable<int> MissionTypeId { get; set; }
        public Nullable<int> WorkAreaId { get; set; }
        public string InfoPlace { get; set; }
        public string WorkVariety { get; set; }
        public string AddInfo { get; set; }
        public Nullable<int> FireAreaCount { get; set; }
    
        public virtual BarrelType BarrelType { get; set; }
        public virtual Broadcast Broadcast { get; set; }
        public virtual CombatArea CombatArea { get; set; }
        public virtual Departure Departure { get; set; }
        public virtual MissionType MissionType { get; set; }
        public virtual WorkArea WorkArea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FireInfoSubdivision> FireInfoSubdivisions { get; set; }
    }
}
