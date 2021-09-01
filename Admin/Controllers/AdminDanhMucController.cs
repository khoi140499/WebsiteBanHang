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
    public class AdminDanhMucController : Controller
    {
        // GET: AdminDanhMuc
        private string Baseurl = "https://localhost:44390/";
        public async Task<ActionResult> Index()
        {
            var list = new List<danhmuc>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/danhmucs/getdanhmuc");
                if (Res.IsSuccessStatusCode)
                {
                    var lsdm = Res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<danhmuc>>(lsdm);
                }
            }
            return View(list);
        }
        [HttpPost]
        public async Task<ActionResult> getAllLoaiSP(int madm)
        {
            var list = new List<loaisanpham>();
            var ls = new List<loaisanpham>();
            HttpResponseMessage res = await GetApiAsync(Baseurl, "api/loaisanphams");
            if (res.IsSuccessStatusCode)
            {
                var lst = res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<loaisanpham>>(lst);
            }
            foreach(var item in list)
            {
                if(item.madm == madm)
                {
                    ls.Add(item);
                }
            }
            return PartialView("~/Views/AdminDanhMuc/getAllLoaiSP.cshtml", ls);
        }

        [HttpPost]
        public async Task<string> AddDM(string tendm)
        {
            using(var client = new HttpClient())
            {
                danhmuc danhmuc = new danhmuc(tendm);
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync("/api/danhmucs/postdanhmuc", danhmuc);
                if (response.IsSuccessStatusCode)
                {
                    return "Thêm thành công";
                }
                return "Thêm thất bại";
            }
        }

        [HttpPost]
        public async Task<string> AddLSP(string loaisanpham)
        {
            var lsp = loaisanpham.Split('+');
            string ten = lsp[0];
            int madm = Int32.Parse(lsp[1]);
            loaisanpham loaisp = new loaisanpham(ten, madm);
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage rest = await client.PostAsJsonAsync("/api/loaisanphams/postloaisanpham", loaisp);
                if (rest.IsSuccessStatusCode)
                {
                    return "Thêm thành công";
                }
            }
            return "Thêm thất bại";
        }
        [HttpPost]
        public async Task<string> EditDM(string danhmuc)
        {
            var tch = danhmuc.Split('-');
            danhmuc dm = new danhmuc(Int32.Parse(tch[0]), tch[1]);
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage rest = await client.PutAsJsonAsync("/api/danhmucs/putdanhmuc", dm);
                if (rest.IsSuccessStatusCode)
                {
                    return "Chỉnh sửa thành công";
                }
            }
            return "Chỉnh sửa thất bại";
        }

        [HttpPost]
        public async Task<string> DeleteDM(int madm)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage rest = await client.DeleteAsync("/api/danhmucs/deletedanhmuc?id="+ madm);
                return "Xóa thành công";
            }
        }

        [HttpPost]
        public async Task<string> EditLSP(string loaisp)
        {
            var lsp = loaisp.Split('-');
            loaisanpham loaisanpham = new loaisanpham(Int32.Parse(lsp[0]), lsp[1], Int32.Parse(lsp[2]));
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage rest = await client.PutAsJsonAsync("/api/loaisanphams/putloaisanpham", loaisanpham);
                if (rest.IsSuccessStatusCode)
                {
                    return "Success";
                }
            }
            return "Fails";
        }
        [HttpPost]
        public async Task<string> DeleteLSP(int madm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage rest = await client.DeleteAsync("/api/loaisanphams/deletelsp?id=" + madm);
                return "Xóa thành công";
            }
            return "Xóa thất bại";
        }
        private async Task<HttpResponseMessage> GetApiAsync(string baseurl, string api)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = await client.GetAsync(api);
            return res;
        }
    }
}