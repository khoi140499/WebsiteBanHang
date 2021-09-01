using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;

namespace WebDemo.Controllers
{
    public class LoginController : Controller
    {
        BanHangEntities2 db = new BanHangEntities2();
        // GET: Login
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string username = f.Get("txtUsername").ToString();
            string password = f.Get("txtPassword").ToString();
            var kq = from us in db.Users where us.username == username && us.password == password select us;
            if (kq == null)
            {
                User a = new User();
                a.fullname = "Sai thông tin đăng nhập";
                return View(a);
            }
            else
            {
                HttpCookie us = new HttpCookie("users");
                us.Values["username"] = username;
                us.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(us);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}