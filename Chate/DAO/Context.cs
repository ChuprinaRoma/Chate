using Chate.Business_Layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Chate.DAO
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Model.Chate> Chate { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Chate;Trusted_Connection=True;");
            }
        }
    }
}
