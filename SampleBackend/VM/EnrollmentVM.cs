using SampleBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleBackend.VM
{
    public class EnrollmentVM
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public Grade? Grade { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string Title { get; set; }
        public int Credits { get; set; }
    }
}