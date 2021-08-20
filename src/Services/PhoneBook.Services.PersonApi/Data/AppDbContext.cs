using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.PersonApi.Data.Configurations;
using PhoneBook.Services.PersonApi.Models;

namespace PhoneBook.Services.KisiApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }

        public DbSet<PersonContact> PersonContact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.ApplyConfiguration(new PersonContactConfiguration());
        }
    }
}
