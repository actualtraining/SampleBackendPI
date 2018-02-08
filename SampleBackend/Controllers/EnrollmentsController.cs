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
using SampleBackend.DAL;
using SampleBackend.Models;
using SampleBackend.VM;

namespace SampleBackend.Controllers
{
    public class EnrollmentsController : ApiController
    {
        //http://arunendapally.com/post/implementation-of-single-sign-on-(sso)-in-asp.net-mvc

        private SchoolContext db = new SchoolContext();

        // GET: api/Enrollments
        public IEnumerable<EnrollmentVM> GetEnrollments()
        {
            var results = from e in db.Enrollments.Include("Student").Include("Course")
                          where e.Course.Title.Contains("Mobi")
                          select new EnrollmentVM
                          {
                              EnrollmentID = e.EnrollmentID,
                              StudentID = e.StudentID,
                              CourseID = e.CourseID,
                              FirstName = e.Student.FirstName,
                              LastName = e.Student.LastName,
                              EnrollmentDate = e.Student.EnrollmentDate,
                              Title = e.Course.Title,
                              Credits = e.Course.Credits,
                              Grade = e.Grade
                          };

            /*var results = from e in db.Enrollments
                          select new EnrollmentVM
                          {
                              EnrollmentID = e.EnrollmentID,
                              StudentID = e.StudentID,
                              CourseID = e.CourseID,
                              FirstName = e.Student.FirstName,
                              LastName = e.Student.LastName,
                              EnrollmentDate = e.Student.EnrollmentDate,
                              Title = e.Course.Title,
                              Credits = e.Course.Credits,
                              Grade = e.Grade
                          };*/

            return results;

            //return db.Enrollments.Include("Student").Include("Course").ToList();
        }

        // GET: api/Enrollments/5
        [ResponseType(typeof(Enrollment))]
        public async Task<IHttpActionResult> GetEnrollment(int id)
        {
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }

        // PUT: api/Enrollments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEnrollment(int id, Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enrollment.EnrollmentID)
            {
                return BadRequest();
            }

            db.Entry(enrollment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(id))
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

        // POST: api/Enrollments
        [ResponseType(typeof(Enrollment))]
        public async Task<IHttpActionResult> PostEnrollment(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Enrollments.Add(enrollment);
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException duEx)
            {
                return InternalServerError(duEx);
            }
          
            return CreatedAtRoute("DefaultApi", new { id = enrollment.EnrollmentID }, enrollment);
        }

        // DELETE: api/Enrollments/5
        [ResponseType(typeof(Enrollment))]
        public async Task<IHttpActionResult> DeleteEnrollment(int id)
        {
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            db.Enrollments.Remove(enrollment);
            await db.SaveChangesAsync();

            return Ok(enrollment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnrollmentExists(int id)
        {
            return db.Enrollments.Count(e => e.EnrollmentID == id) > 0;
        }
    }
}