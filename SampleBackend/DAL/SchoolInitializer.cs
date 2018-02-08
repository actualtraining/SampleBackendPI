using SampleBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleBackend.DAL
{
    public class SchoolInitializer : 
        System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Erick",
                    LastName = "Kurniawam",
                    EnrollmentDate=new DateTime(2016,02,02)
                },
                new Student
                {
                    FirstName = "Budi",
                    LastName = "Susanto",
                    EnrollmentDate =new DateTime(2011,04,11)
                }
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course
                {
                    CourseID=1234,
                    Title="Pemrograman Mobile",
                    Credits=3
                },
                new Course
                {
                    CourseID=2345,
                    Title="Pemrograman Web",
                    Credits=3
                }
            };

            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment
                {
                    StudentID=1,
                    CourseID=1234,
                    Grade = Grade.A
                },
                new Enrollment
                {
                    StudentID=1,
                    CourseID=2345,
                    Grade=Grade.B
                }
            };

            enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();
        }
    }
}