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
using Death_API.Models;

namespace Death_API.Controllers
{
    public class AppointmentsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Appointments
        public IQueryable<Appointment> GetAppointments()
        {
            return db.Appointments;
        }

        // GET: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult GetAppointments(int id)
        {
            Appointment appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return NotFound();
            }

            return Ok(appointments);
        }

        // PUT: api/Appointments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppointments(int id, Appointment appointments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointments.IdAppointment)
            {
                return BadRequest();
            }

            db.Entry(appointments).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentsExists(id))
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

        // POST: api/Appointments
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> PostAppointments(Appointment appointments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Appointments.Add(appointments);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appointments.IdAppointment }, appointments);
        }

        // DELETE: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> DeleteAppointments(int id)
        {
            Appointment appointments = await db.Appointments.FindAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }

            db.Appointments.Remove(appointments);
            await db.SaveChangesAsync();

            return Ok(appointments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppointmentsExists(int id)
        {
            return db.Appointments.Count(e => e.IdAppointment == id) > 0;
        }
    }
}