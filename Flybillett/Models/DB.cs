﻿

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
        public int idFlyreise { get; set; }
        public string fraBy { get; set; }
        public string tilBy { get; set; }        
        public string pris { get; set; }
    }

    public class Kunde
    {  
        public int idKunde { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Email { get; set; }        
    }

    public class Billett
    {
        public int idBillett { get; set; }
        public DateTime Dato { get; set; }

        // Foreign keys
        public int idFlyreise { get; set; }
        public Flyreise Flyreise { get; set; }

        public int idKunde { get; set; }
        public Kunde Kunde { get; set; }
    }

    public class Admin
    {
        public int idAdmin { get; set; }
        public string Bruker { get; set; }
        public string Passord { get; set; }        
    }

    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=fly")
            {
            Database.CreateIfNotExists();

            Database.SetInitializer(new DBInit());
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
}