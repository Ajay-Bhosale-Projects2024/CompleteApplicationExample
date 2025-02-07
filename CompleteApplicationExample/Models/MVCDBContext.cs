using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using CompleteApplicationExample.Migrations;


namespace CompleteApplicationExample.Models
{
    public class MVCDBContext:DbContext
    {
        public MVCDBContext():base("Constr")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<MVCDBContext>());

           Database.SetInitializer(new MigrateDatabaseToLatestVersion<MVCDBContext, Configuration>());
        }

      

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Registration> Registrations { get; set; }

    }
}