using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mvc_CRUD_Nimap.Models
{
    public class ServicesContext : DbContext
    {
        public DbSet<Product> product { get; set; }
        public DbSet<Class1> Category { get; set; }


    }
}