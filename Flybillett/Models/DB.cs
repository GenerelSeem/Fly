using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Flybillett.Models
{

    public class flyreise
        {
        public int id { get; set; }
        public string fraBy { get; set; }
        public string tilBy { get; set; }
        public string dato { get; set; }
        public string tid { get; set; }
        public string pris { get; set; }
        }

    public class kunde
        {
       public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        }

    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=Fly")
            {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
            }

        public DbSet<flyreise> Flyreise { get; set; }
        public DbSet<kunde> Kunde { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}