using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;



namespace DAL
{
    
    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=fly")
        {
            Database.CreateIfNotExists();

           
        }

        public DbSet<Flyreise> Flyreise { get; set; }
        public DbSet<Kunde> Kunde { get; set; }
        public DbSet<Billett> Billett { get; set; }
        public DbSet<Admin> Admin { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    public class dbAdmin
    {
        [Key]
        public string Bruker { get; set; }
        public byte[] Passord { get; set; }
    }
}
