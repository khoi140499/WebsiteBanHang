//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestFulApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class size
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public size()
        {
            this.mausacs = new HashSet<mausac>();
        }
    
        public int masize { get; set; }
        public string size1 { get; set; }
        public int soluong { get; set; }
        public int masp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mausac> mausacs { get; set; }
        public virtual sanpham sanpham { get; set; }
    }
}