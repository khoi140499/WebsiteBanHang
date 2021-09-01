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
    public class sanphamsController : ApiController
    {
        private banhangEntities db = new banhangEntities();

        // GET: api/sanphams
        public IEnumerable<sanpham> Getsanphams()
        {
            return db.sanphams.ToList();
        }

        // GET: api/sanphams/5
        [ResponseType(typeof(sanpham))]
        public async Task<IHttpActionResult> Getsanpham(int id)
        {
            sanpham sanpham = await db.sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return Ok(sanpham);
        }

        // PUT: api/sanphams/5
        [Route("api/sanphams/putsanpham")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putsanpham(int id, sanpham sanpham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanpham.masp)
            {
                return BadRequest();
            }

            db.Entry(sanpham).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sanphamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/sanphams
        [Route("api/sanphams/postsanpham")]
        [ResponseType(typeof(sanpham))]
        public async Task<IHttpActionResult> Postsanpham(sanpham sanpham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sanphams.Add(sanpham);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sanpham.masp }, sanpham);
        }

        // DELETE: api/sanphams/5
        [Route("api/sanphams/deletesp")]
        [ResponseType(typeof(sanpham))]
        public async Task<IHttpActionResult> Deletesanpham(int id)
        {
            sanpham sanpham = await db.sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }

            db.sanphams.Remove(sanpham);
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

        private bool sanphamExists(int id)
        {
            return db.sanphams.Count(e => e.masp == id) > 0;
        }
    }
}