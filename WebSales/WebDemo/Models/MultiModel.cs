using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class MultiModel
    {
        public List<GioHang> GHang { get; set; }
        public List<Sanpham> SPham { get; set; }
        public MultiModel() { }
    }
}