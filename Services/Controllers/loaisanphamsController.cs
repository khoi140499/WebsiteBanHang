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
    public class loaisanphamsController : ApiController
    {
        private banhangEntities db = new banhangEntities();

        // GET: api/loaisanphams
        public IEnumerable<loaisanpham> Getloaisanphams()
        {
            return db.loaisanphams.ToList();
        }

        // GET: api/loaisanphams/5
        [ResponseType(typeof(loaisanpham))]
        public async Task<IHttpActionResult> Getloaisanpham(int id)
        {
            loaisanpham loaisanpham = await db.loaisanphams.FindAsync(id);
            if (loaisanpham == null)
            {
                return NotFound();
            }

            return Ok(loaisanpham);
        }

        // PUT: api/loaisanphams/5
        [Route("api/loaisanphams/putloaisanpham")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putloaisanpham(loaisanpham loaisanpham)
        {
            db.Entry(loaisanpham).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }
            return StatusCode(HttpStatusCode.OK);
        }

        [Route("api/loaisanphams/postloaisanpham")]
        // POST: api/loaisanphams
        [ResponseType(typeof(loaisanpham))]
        public async Task<IHttpActionResult> Postloaisanpham(loaisanpham loaisanpham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.loaisanphams.Add(loaisanpham);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/loaisanphams/5
        [Route("api/loaisanphams/deletelsp")]
        [ResponseType(typeof(loaisanpham))]
        public async Task<IHttpActionResult> Deleteloaisanpham(int id)
        {
            loaisanpham loaisanpham = await db.loaisanphams.FindAsync(id);
            if (loaisanpham == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            db.loaisanphams.Remove(loaisanpham);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.OK);
        }

        //DELET: api/loaisanphams/5
        [Route("api/loaisanphams/deletealllsp")]
        [ResponseType(typeof(loaisanpham))]
        public async Task<IHttpActionResult> Deletelsp(int madm)
        {
            var list = db.loaisanphams.ToList();
            foreach(var item in list)
            {
                if(item.madm == madm)
                {
                    db.loaisanphams.Remove(item);
                    await db.SaveChangesAsync();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }
            }
            
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

        private bool loaisanphamExists(int id)
        {
            return db.loaisanphams.Count(e => e.maloai == id) > 0;
        }
    }
}