using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Testing.Models
{
    public class TestDb:DbContext
    {
        public TestDb():base("connection")
        {

        }

        public DbSet<Test1> Tests { get; set; }
    }
}