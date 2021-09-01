using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class Deltails
    {
        public Sanpham sanpham { get; set; }
        public List<Sanpham> listSanPham { get; set; }

        public Deltails() { }


    }
}