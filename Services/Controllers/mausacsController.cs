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
    public class mausacsController : ApiController
    {
        private banhangEntities db = new banhangEntities();

        // GET: api/mausacs
        public IQueryable<mausac> Getmausacs()
        {
            return db.mausacs;
        }

        // GET: api/mausacs/5
        [ResponseType(typeof(mausac))]
        public async Task<IHttpActionResult> Getmausac(int id)
        {
            mausac mausac = await db.mausacs.FindAsync(id);
            if (mausac == null)
            {
                return NotFound();
            }

            return Ok(mausac);
        }

        // PUT: api/mausacs/5
        [Route("api/mausacs/putmausac")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmausac(mausac mausac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(mausac).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mausacExists(mausac.mamau))
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

        // POST: api/mausacs
        [Route("api/mausacs/postmausac")]
        [ResponseType(typeof(mausac))]
        public async Task<IHttpActionResult> Postmausac(mausac mausac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mausacs.Add(mausac);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mausac.mamau }, mausac);
        }

        // DELETE: api/mausacs/5
        [Route("api/mausacs/deletemausac")]
        [ResponseType(typeof(mausac))]
        public async Task<IHttpActionResult> Deletemausac(int id)
        {
            mausac mausac = await db.mausacs.FindAsync(id);
            if (mausac == null)
            {
                return NotFound();
            }

            db.mausacs.Remove(mausac);
            await db.SaveChangesAsync();

            return Ok(mausac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mausacExists(int id)
        {
            return db.mausacs.Count(e => e.mamau == id) > 0;
        }
    }
}