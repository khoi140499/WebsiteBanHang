using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SaleWebsite.Models;

namespace SaleWebsite.Controllers
{
    public class AdminSanPhamController : Controller
    {
        // GET: AdminSanPham
        private string Baseurl = "https://localhost:44390/";
        public async Task<ActionResult> Index()
        {
            var list = new List<sanpham>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/sanphams");
                if (Res.IsSuccessStatusCode)
                {
                    var lsdm = Res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<sanpham>>(lsdm);
                }
            }
            return View(list);
        }
        [HttpPost]
        public async Task<ActionResult> ViewAll(int masp)
        {
            var list = new List<sanpham>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/sanphams");
                if (Res.IsSuccessStatusCode)
                {
                    var lsdm = Res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<sanpham>>(lsdm);
                }
            }
            sanpham sanpham = new sanpham();
            foreach(var it in list) {
                if(it.masp == masp)
                {
                    sanpham = it;
                }
            }
            return PartialView("~/Views/AdminSanPham/ViewAll.cshtml", sanpham);
        }

        [HttpPost]
        public async Task<ActionResult> ViewColor(int masize)
        {
            var size = new size();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/sizes/getsize?id="+masize);
                if (res.IsSuccessStatusCode)
                {
                    var s= res.Content.ReadAsStringAsync().Result;
                    size = JsonConvert.DeserializeObject<size>(s);
                }
            }

            return PartialView("~/Views/AdminSanPham/ViewColor.cshtml", size);
        }
        [HttpPost]
        public async Task<ActionResult> getAllLSP()
        {
            var list = new List<loaisanpham>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res=await client.GetAsync("/api/loaisanphams");
                if (res.IsSuccessStatusCode)
                {
                    var ls = res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<loaisanpham>>(ls);
                }
            }
            return PartialView("~/Views/AdminSanPham/getAllLSP.cshtml", list);
        }

        [HttpPost]
        public async Task<ActionResult> getAllSize(int masp)
        {
            var list = new List<sanpham>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/sanphams");
                if (Res.IsSuccessStatusCode)
                {
                    var lsdm = Res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<sanpham>>(lsdm);
                }
            }
            sanpham sanpham = new sanpham();
            foreach (var it in list)
            {
                if (it.masp == masp)
                {
                    sanpham = it;
                }
            }
            return PartialView("~/Views/AdminSanPham/getAllSize.cshtml", sanpham.sizes);
        }

        [HttpPost]
        public async Task<string> DeleteSP(int masp)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.DeleteAsync("/api/sanphams/deletesp?id=" + masp);
                if (res.IsSuccessStatusCode)
                {
                    return "true";
                }
            }
            return "false";
        }
        [HttpPost]
        public async Task<ActionResult> getLSP()
        {
            var list = new List<loaisanpham>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("/api/loaisanphams");
                if (res.IsSuccessStatusCode)
                {
                    var ls = res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<loaisanpham>>(ls);
                }
            }
            return PartialView("~/Views/AdminSanPham/getLSP.cshtml", list);
        }
        [HttpPost]
        public async Task<string> DeleteSize(int masize)
        {
            using(var client  = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.DeleteAsync("/api/sizes/deletesize?id=" + masize);
                if (res.IsSuccessStatusCode)
                {
                    return "true";
                }
            }
            return "fails";
        }
        [HttpPost]
        public async Task<string> DeleteColor(int mamau)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.DeleteAsync("/api/mausacs/deletemausac?id=" + mamau);
                if (res.IsSuccessStatusCode)
                {
                    return "true";
                }
            }
            return "fails";
        }
        [HttpPost]
        public async Task<string> EditSize(int masize, string tensize, int soluong, int masp)
        {
            size sz = new size(masize, tensize, soluong, masp);
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.PutAsJsonAsync("/api/sizes/putsize", sz);
                if (res.IsSuccessStatusCode)
                {
                    return "true";
                }
            }
            return "fails";
        }

        [HttpPost]
        public async Task<string> EditSP(int masp, string tensp, int dongia,
            string chatlieu, string bio, string date, int lsp)
        {
            
            
            
            return "fails";
        }
    }
}