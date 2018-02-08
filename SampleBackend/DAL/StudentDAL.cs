using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using SampleBackend.Models;

namespace SampleBackend.DAL
{
    public class StudentDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["SchoolContext"].ConnectionString;
        }

        public IEnumerable<Student> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"select * from Students order by FirstName asc";
                return conn.Query<Student>(strSql, conn);
            }
        }
    }
}