using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class CompareProduct
    {
        public int masp { get; set; }
        public Sanpham sanpham { get; set; }
        public CompareProduct() { }

        public CompareProduct(int masp, Sanpham sanpham)
        {
            this.masp = masp;
            this.sanpham = sanpham;
        }
    }
}