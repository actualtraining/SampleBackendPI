using SampleBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleBackend.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        private List<Student> listStudents;

        public ValuesController()
        {
            listStudents = new List<Student>()
            {
                new Student{StudentID=1,FirstName="Erick",LastName="Kurniawan",EnrollmentDate=new DateTime(2016,02,03)},
                new Student{StudentID=2,FirstName="Budi",LastName="Sutejo",EnrollmentDate=new DateTime(2015,12,11)}
            };
        }

        [Route("api/Values/HelloWorld")]
        [HttpGet]
        public string HelloWorld()
        {
            return "Hello World !";
        }

        public IEnumerable<Student> Get()
        {
            return listStudents;
        }

        // GET api/values/5
        public Student Get(int id)
        {
            /*Student currStudent = (from s in listStudents
                                  where s.StudentID == id
                                  select s).SingleOrDefault();*/
            var currStudent = listStudents.Where(s => s.StudentID == id).SingleOrDefault();
            return currStudent;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
