//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaleWebsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class danhgia
    {
        public int madanhgia { get; set; }
        public float rate { get; set; }
        public int masp { get; set; }
    
        public virtual sanpham sanpham { get; set; }
    }
}
