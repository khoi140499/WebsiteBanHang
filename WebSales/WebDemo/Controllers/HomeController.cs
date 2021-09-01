using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using System.Data.Entity;
using PagedList;
using System.Data.Entity.Validation;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        BanHangEntities2 db = new BanHangEntities2();
        public ActionResult Index()
        {
            var listsanpham = db.Sanphams.ToList();
            return View(listsanpham);
        }

        [HttpGet]
        public ActionResult SanPhamMoi(int? fmin, int? fmax, int? page)
        {
            if (fmin == null && fmax == null)
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);

                var listsanpham = db.Sanphams.ToList();
                var listsp = new List<Sanpham>();
                string date = DateTime.Today + "";
                string[] arr = date.Split(' ');
                DateTime date1 = Convert.ToDateTime(arr[0]);
                foreach (Sanpham sp in listsanpham)
                {
                    DateTime dat2 = Convert.ToDateTime(sp.ngaydang);
                    TimeSpan time = date1 - dat2;
                    int tsngay = time.Days;
                    if (tsngay < 12)
                    {
                        listsp.Add(sp);
                    }
                }
                return View(listsp.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);

                var listsanpham = db.Sanphams.ToList();
                var listsp = new List<Sanpham>();
                string date = DateTime.Today + "";
                string[] arr = date.Split(' ');
                DateTime date1 = Convert.ToDateTime(arr[0]);
                foreach (Sanpham sp in listsanpham)
                {
                    DateTime dat2 = Convert.ToDateTime(sp.ngaydang);
                    TimeSpan time = date1 - dat2;
                    int tsngay = time.Days;
                    if (sp.giasp >= fmin && sp.giasp <= fmax && tsngay < 12)
                    {
                        listsp.Add(sp);
                    }
                }
                return View(listsp.ToPagedList(pageNumber, pageSize));
            }
            return View();
        }
        [HttpGet]
        public ActionResult ThoiTrangNam(int? fmin, int? fmax, int? page)
        {
            if (fmin == null && fmax == null)
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "thoitrangnam")
                    {
                        listsanpham.Add(sp);
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "thoitrangnam")
                    {
                        if (sp.giasp >= fmin && sp.giasp <= fmax)
                        {
                            listsanpham.Add(sp);
                        }
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            return View();
        }
        [HttpGet]
        public ActionResult ThoiTrangNu(int? fmin, int? fmax, int? page)
        {
            if (fmin == null && fmax == null)
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "thoitrangnu")
                    {
                        listsanpham.Add(sp);
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "thoitrangnu")
                    {
                        if (sp.giasp >= fmin && sp.giasp <= fmax)
                        {
                            listsanpham.Add(sp);
                        }
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            return View();
        }
        [HttpGet]
        public ActionResult ThoiTrangDong(int? fmin, int? fmax, int? page)
        {
            if (fmin == null && fmax == null)
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "thoitrangdong")
                    {
                        listsanpham.Add(sp);
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "thoitrangdong")
                    {
                        if (sp.giasp >= fmin && sp.giasp <= fmax)
                        {
                            listsanpham.Add(sp);
                        }
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            return View();
        }
        [HttpGet]
        public ActionResult PhuKienNam(int? fmin, int? fmax, int? page)
        {
            if (fmin == null && fmax == null)
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "pknam")
                    {
                        listsanpham.Add(sp);
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "pknam")
                    {
                        if (sp.giasp >= fmin && sp.giasp <= fmax)
                        {
                            listsanpham.Add(sp);
                        }
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            return View();
        }
        [HttpGet]
        public ActionResult PhuKienNu(int? fmin, int? fmax, int? page)
        {
            if (fmin == null && fmax == null)
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "pknu")
                    {
                        listsanpham.Add(sp);
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "pknu")
                    {
                        if (sp.giasp >= fmin && sp.giasp <= fmax)
                        {
                            listsanpham.Add(sp);
                        }
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            return View();
        }
        [HttpGet]
        public ActionResult Sale(int? fmin, int? fmax, int? page)
        {
            if (fmin == null && fmax == null)
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "sale")
                    {
                        listsanpham.Add(sp);
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var listsanpham = new List<Sanpham>();
                var listsp = db.Sanphams.ToList();
                foreach (Sanpham sp in listsp)
                {
                    if (sp.loaisanpham.TrimEnd() == "sale")
                    {
                        if (sp.giasp >= fmin && sp.giasp <= fmax)
                        {
                            listsanpham.Add(sp);
                        }
                    }
                }
                return View(listsanpham.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult Infomation()
        {
            HttpCookie cookie = Request.Cookies["users"];

            if (cookie != null && cookie.Value != "")
            {
                var user = db.Users.ToList();
                foreach (User ass in user)
                {
                    User a = ass;
                    return View(a);
                }
            }
            return View();
        }

        public ActionResult ChangeInfomation()
        {
            HttpCookie cookie = Request.Cookies["users"];
            if (cookie != null && cookie.Value != null)
            {
                var user = db.Users.ToList();
                foreach (User us in user)
                {
                    User a = us;
                    return View(a);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult ChangeInfomation(FormCollection f)
        {
            string username = f.Get("txtUsername").ToString();
            string password = f.Get("txtPassword").ToString();
            string fullname = f.Get("txtFullname").ToString();
            int age = Int32.Parse(f.Get("txtAge").ToString());
            string phone = f.Get("txtPhone").ToString();
            string email = f.Get("txtEmail").ToString();
            string address = f.Get("txtAddress").ToString();
            var usa = (from us in db.Users where us.username == username select us).FirstOrDefault();
            usa.password = password;
            usa.fullname = fullname;
            usa.age = age;
            usa.phone = phone;
            usa.email = email;
            usa.address = address;
            db.Entry(usa).State = EntityState.Modified;
            db.SaveChanges();
            TempData["name"] = "Thay đổi thông tin thành công!";
            return View();
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            HttpCookie cookie = Request.Cookies["users"];
            if (cookie != null && cookie.Value != "")
            {
                cookie.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Search(string currenrsearch, string search, int? page)
        {
            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currenrsearch;
            }
            ViewBag.currenrsearch = search;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            var listsp = db.Sanphams.ToList();
            var listsanpham = new List<Sanpham>();
            string[] arr1 = search.Split(' ');
            foreach (var item in listsp)
            {
                string[] arr = item.tensp.TrimEnd().Split(' ');
                foreach (var it in arr1)
                {
                    foreach (var it1 in arr)
                    {
                        if (it.ToString() == it1.ToString())
                        {
                            listsanpham.Add(item);
                        }
                    }
                }
            }

            return View(listsanpham.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public int AddCart(int masanpham)
        {
            HttpCookie cookie = Request.Cookies["users"];
            string s = "";
            if (cookie != null && cookie.Value != "")
            {
                try
                {
                    var ls = db.GioHangs.ToList();
                    GioHang a = new GioHang(
                        magh: ls.Count + 1,
                        name: cookie["username"],
                        masp: masanpham,
                        soluong: 1
                        );
                    db.GioHangs.Add(a);
                    db.SaveChanges();
                    s = cookie["username"];
                }
                catch (DbEntityValidationException ex)
                {
                    System.Console.WriteLine(ex);
                }
            }
            var list = new List<GioHang>();
            var lss = (from giohang in db.GioHangs where giohang.name == s select giohang).ToList();
            HttpCookie ck = new HttpCookie("giohang1");
            ck["count"] = lss.Count + "";
            ck.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Add(ck);
            return lss.Count;
        }
        public ActionResult ThanhToan()
        {
            MultiModel model = new MultiModel();
            model.GHang = db.GioHangs.ToList();
            model.SPham = db.Sanphams.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult TT(int? magh)
        {
            int? ma = magh;
            var list = db.GioHangs.ToList();
            foreach(var item in list)
            {
                if(item.magh == ma)
                {
                    db.GioHangs.Remove(item);
                    db.SaveChanges();
                    HttpCookie ck = Request.Cookies["giohang1"];
                    if(ck!=null && ck.Value != "")
                    {
                        int count = Int32.Parse(ck["count"])-1;
                        HttpCookie cookie = new HttpCookie("giohang1");
                        cookie["count"] = count+"";
                        cookie.Expires = DateTime.Now.AddDays(10);
                        Response.Cookies.Add(cookie);
                        return RedirectToAction("ThanhToan", "Home");
                    }
                }
            }
           return RedirectToAction("ThanhToan", "Home");
        }

        public ActionResult DatHang()
        {
            HttpCookie cookie = Request.Cookies["users"];
            var list2 = new List<ThanhToan>();
            if(cookie!=null && cookie.Value != "")
            {
                string us = cookie["username"];
                var list = (from gh in db.GioHangs where gh.name == us select gh).ToList();
                var ls = db.Sanphams.ToList();
                foreach(var item in list)
                {
                    foreach(var it in ls)
                    {
                        if(item.masp == it.masp)
                        {
                            ThanhToan a = new ThanhToan(it.masp, it.anh, it.tensp, it.kichco,(long)it.giasp);
                            list2.Add(a);
                        }
                    }
                }
            }
            return View(list2);
        }
        [HttpPost]
        public ActionResult DatHang(FormCollection f)
        {
            string address = f.Get("address").ToString();
            string note = f.Get("note").ToString();
            HttpCookie cookie = Request.Cookies["users"];
            if(cookie == null) {
                return RedirectToAction("Login", "Login");
            }
            string name = cookie["username"];
            var user = from us in db.Users where us.username == name select us;
            var listgh = (from gh in db.GioHangs where gh.name == name select gh).ToList();
            string date = DateTime.Today + "";
            string[] arr = date.Split(' ');
            DateTime date1 = Convert.ToDateTime(arr[0]);
            var listsp = db.Sanphams.ToList();
            foreach(var item in listgh)
            {
                foreach(var it in listsp)
                {
                    if(item.masp == it.masp)
                    {
                        DatHang a = new DatHang(
                            madon: (db.DatHangs.ToList()).Count + 1,
                            masp: item.masp,
                            soluong: 1,
                            size: it.kichco,
                            thanhtien: it.giasp,
                            ngaydat: date1,
                            ghichu: note,
                            diachi: address
                            );
                        db.DatHangs.Add(a);
                        db.SaveChanges();
                        db.GioHangs.Remove(item);
                        db.SaveChanges();
                    }
                }
            }
           
            HttpCookie ck = Request.Cookies["giohang1"];
            HttpCookie cookies = new HttpCookie("giohang1");
            cookies["count"] = 0 + "";
            cookies.Expires = DateTime.Now.AddDays(-10);
            Response.Cookies.Add(cookies);
            return View();
        }
        [HttpGet]
        public ActionResult Deltails(int? masp)
        {
            int? ma = masp;
            Sanpham a = new Sanpham();
            var list = db.Sanphams.ToList();
            foreach(var sp in list)
            {
                if(sp.masp == ma)
                {
                    a = sp;
                }
            }
            return View(a);
        }
        [HttpGet]
        public ActionResult Previous(int masp) {
            var list = db.Sanphams.ToList();
            string loaisanpham="";
            Sanpham a = new Sanpham();
            foreach(var it in list)
            {
                if(it.masp == masp)
                {
                    loaisanpham = it.loaisanpham;
                }
            }
            var list1 = (from sp in db.Sanphams where sp.loaisanpham == loaisanpham select sp).ToList();
            for(int i = 0; i < list1.Count(); i++)
            {
                if(list1[i].masp == masp)
                {
                    if((i-1) > 0)
                    {
                        a = list1[i - 1];
                    }
                    else if ((i - 1) == 0)
                    {
                        a = list1[list1.Count() - 1];
                    } 
                }
            }
            return RedirectToAction("Deltails", "Home", a);
        }

        [HttpGet]
        public ActionResult Next(int masp)
        {
            var list = db.Sanphams.ToList();
            string loaisanpham = "";
            Sanpham a = new Sanpham();
            foreach (var it in list)
            {
                if (it.masp == masp)
                {
                    loaisanpham = it.loaisanpham;
                }
            }
            var list1 = (from sp in db.Sanphams where sp.loaisanpham == loaisanpham select sp).ToList();
            for (int i = 0; i < list1.Count(); i++)
            {
                if (list1[i].masp == masp)
                {
                    if ((i + 1) < (list1.Count()))
                    {
                        a = list1[i + 1];
                    }
                    else if ((i + 1) == (list1.Count()))
                    {
                        a = list1[0];
                    }
                }
            }
            return RedirectToAction("Deltails", "Home", a);
        }

        public ActionResult GetAll(int masanpham)
        {
            int ma = masanpham;
            var list = db.Sanphams.ToList();
            var loaisanpham = "";
            foreach(var it in list)
            {
                if(it.masp == ma)
                {
                    loaisanpham = it.loaisanpham;
                }
            }
            var listsp = (from sp in db.Sanphams where sp.loaisanpham == loaisanpham select sp).ToList();
            var lis = new List<CompareProduct>();
            foreach(var it in listsp)
            {
                lis.Add(new CompareProduct(ma, it));
            }
            return PartialView("~/Views/Home/GetAllProduct.cshtml", lis);
        }

        public ActionResult CompareProduct(int masp1, int masp2)
        {
            var listsp = db.Sanphams.ToList();
            var list = new List<Sanpham>();
            foreach(var it in listsp)
            {
                if(it.masp == masp1 | it.masp == masp2)
                {
                    list.Add(it);
                }
            }
            return View(list);
        }
    }
}