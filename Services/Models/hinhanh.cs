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
    
    public partial class hinhanh
    {
        public int mahinhanh { get; set; }
        public string hinhanh1 { get; set; }
        public int masp { get; set; }
    
        public virtual sanpham sanpham { get; set; }
    }
}
