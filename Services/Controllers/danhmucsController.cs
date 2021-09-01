using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RestFulApi.Models;

namespace RestFulApi.Controllers
{
    public class danhmucsController : ApiController
    {
        private banhangEntities db = new banhangEntities();

        // GET: api/danhmucs
        [Route("api/danhmucs/getdanhmuc")]
        public IEnumerable<danhmuc> Getdanhmucs()
        {
            return db.danhmucs.ToList();
        }


        // PUT: api/danhmucs/5
        
        [Route("api/danhmucs/putdanhmuc")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putdanhmuc(danhmuc danhmuc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(danhmuc).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!danhmucExists(danhmuc.madm))
                {
                    return StatusCode(HttpStatusCode.Found);
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }
        [Route("api/danhmucs/postdanhmuc")]
        // POST: api/danhmucs
        [ResponseType(typeof(danhmuc))]
        public async Task<IHttpActionResult> Postdanhmuc(danhmuc danhmuc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.danhmucs.Add(danhmuc);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/danhmucs/5
        [Route("api/danhmucs/deletedanhmuc")]
        [ResponseType(typeof(danhmuc))]
        public async Task<IHttpActionResult> Deletedanhmuc(int id)
        {
            var listlsp = (from lsp in db.loaisanphams where lsp.madm == id select lsp);
            db.loaisanphams.RemoveRange(listlsp);
            danhmuc danhmuc = await db.danhmucs.FindAsync(id);
            if (danhmuc == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            
            db.danhmucs.Remove(danhmuc);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool danhmucExists(int id)
        {
            return db.danhmucs.Count(e => e.madm == id) > 0;
        }
    }
}