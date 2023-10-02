using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ScannerFinalPDF.Model.Data
{
    class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<RS> RS { get; set; }
        public DbSet<Sroki> Sroki { get; set; }



        public ApplicationContext() : base("DefaultConnection") { }

    }
}
