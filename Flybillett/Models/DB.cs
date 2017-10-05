

using Flybillett.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace Flybillett.Models
{

    public class Flyreise
    {
        public int id { get; set; }
        public string fraBy { get; set; }
        public string tilBy { get; set; }
        public string dato { get; set; }
        public string tid { get; set; }
        public string pris { get; set; }
    }

    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=Fly")
            {
            Database.CreateIfNotExists();

            Database.SetInitializer(new DBInit());
            }

        public DbSet<Flyreise> Flyreise { get; set; }
    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}