//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace T3H_K35DL1_Winforms.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class HocKi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocKi()
        {
            this.Diems = new HashSet<Diem>();
            this.HanhKiems = new HashSet<HanhKiem>();
            this.KhoaHocs = new HashSet<KhoaHoc>();
        }
    
        public int KiHoc { get; set; }
        public Nullable<System.DateTime> BatDau { get; set; }
        public Nullable<System.DateTime> KetThuc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diem> Diems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HanhKiem> HanhKiems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
    }
}
