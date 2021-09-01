using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class ThanhToan
    {
        public int ma { get; set; }
        public string anh { get; set; }
        public string tensp { get; set; }
        public string kichco { get; set; }
        public long gia { get; set; }

        public ThanhToan() { }

        public ThanhToan(int ma, string anh, string tensp, long gia)
        {
            this.ma = ma;
            this.anh = anh;
            this.tensp = tensp;
            this.gia = gia;
        }

        public ThanhToan(string anh, string tensp, long gia)
        {
            this.anh = anh;
            this.tensp = tensp;
            this.gia = gia;
        }

        public ThanhToan(int ma, string anh, string tensp, string kichco, long gia)
        {
            this.ma = ma;
            this.anh = anh;
            this.tensp = tensp;
            this.kichco = kichco;
            this.gia = gia;
        }
    }
}