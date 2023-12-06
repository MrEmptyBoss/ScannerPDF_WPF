using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ScannerFinalPDF.Model.Data
{
    class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<RS> RS { get; set; }
        public DbSet<Sroki> Sroki { get; set; }
        public DbSet<Zayvka> Zayvka { get; set; }
        public DbSet<Maket> Maket { get; set; }
        public DbSet<Position> Positions { get; set; }




        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ScannerPdfDBAppDB;Trusted_Connection=True;");
        }


    }
}

