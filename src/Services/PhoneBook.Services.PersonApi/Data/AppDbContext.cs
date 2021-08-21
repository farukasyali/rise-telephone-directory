using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.PersonApi.Data.Configurations;
using PhoneBook.Services.PersonApi.Data.Seeds;
using PhoneBook.Services.PersonApi.Models;

namespace PhoneBook.Services.PersonApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }

        public DbSet<PersonContact> PersonContact { get; set; }

        public DbSet<ContactType> ContactType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.ApplyConfiguration(new PersonContactConfiguration());

            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ContactTypeSeed(new int[] { 1, 2, 3 }));
        }
    }
}
