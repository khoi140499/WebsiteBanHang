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
    public class sizesController : ApiController
    {
        private banhangEntities db = new banhangEntities();

        // GET: api/sizes
        public IQueryable<size> Getsizes()
        {
            return db.sizes;
        }

        // GET: api/sizes/5
        [Route("api/sizes/getsize")]
        [ResponseType(typeof(size))]
        public async Task<IHttpActionResult> Getsize(int id)
        {
            size size = await db.sizes.FindAsync(id);
            if (size == null)
            {
                return NotFound();
            }

            return Ok(size);
        }

        // PUT: api/sizes/5
        [Route("api/sizes/putsize")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putsize(size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(size).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sizeExists(size.masize))
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

        // POST: api/sizes
        [Route("api/sizes/postsize")]
        [ResponseType(typeof(size))]
        public async Task<IHttpActionResult> Postsize(size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sizes.Add(size);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = size.masize }, size);
        }

        // DELETE: api/sizes/5
        [Route("api/sizes/deletesize")]
        [ResponseType(typeof(size))]
        public async Task<IHttpActionResult> Deletesize(int id)
        {
            var list = (from ms in db.mausacs where ms.masize == id select ms).ToList();
            db.mausacs.RemoveRange(list);
            size size = await db.sizes.FindAsync(id);
            if (size == null)
            {
                return NotFound();
            }

            db.sizes.Remove(size);
            await db.SaveChangesAsync();

            return Ok(size);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sizeExists(int id)
        {
            return db.sizes.Count(e => e.masize == id) > 0;
        }
    }
}