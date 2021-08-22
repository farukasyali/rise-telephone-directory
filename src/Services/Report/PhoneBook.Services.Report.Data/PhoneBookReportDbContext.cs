using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.Report.Core.Models;
using PhoneBook.Services.Report.Data.Configurations;

namespace PhoneBook.Services.Report.Data
{
    public class PhoneBookReportDbContext : DbContext
    {
        public PhoneBookReportDbContext(DbContextOptions<PhoneBookReportDbContext> options) : base(options){}

        public DbSet<Reports> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReportsConfiguration());
        }
    }
}
