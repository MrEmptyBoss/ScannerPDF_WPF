using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace ScannerFinalPDF.Model.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }

}
