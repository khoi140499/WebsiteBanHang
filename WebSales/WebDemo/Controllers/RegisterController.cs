using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using System.Security.Cryptography;
using System.Text;

namespace WebDemo.Controllers
{
    public class RegisterController : Controller
    {
        BanHangEntities2 db = new BanHangEntities2();
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection f)
        {
            string username=f.Get("txtusername").ToString();
            string password = f.Get("txtPassword").ToString();
            string fullname = f.Get("txtFullname").ToString();
            int age =Int32.Parse(f.Get("txtAge").ToString());
            string phone = f.Get("txtPhone").ToString();
            string email = f.Get("txtEmail").ToString();
            string address = f.Get("txtAddress").ToString();

            var kq = (from s in db.Users where s.username == username select s).ToList();
            if (kq.Count == 0)
            {
                var list = db.Users.ToList();
                User us = new User
                {
                    matv = list.Count + 1,
                    username = username,
                    password=password,
                    fullname=fullname,
                    age=age,
                    phone=phone,
                    email=email,
                    address=address
                };
                db.Users.Add(us);
                db.SaveChanges();

                return RedirectToAction("Login", "Login", us);
            }
            return View();
        }

    }
}