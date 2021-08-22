using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.Person.Data.Configurations;
using PhoneBook.Services.Person.Data.Seeds;
using PhoneBook.Services.Person.Core.Models;

namespace PhoneBook.Services.Person.Data
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options){}

        public DbSet<Persons> Persons { get; set; }

        public DbSet<PersonContacts> PersonContacts { get; set; }

        public DbSet<ContactTypes> ContactTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.ApplyConfiguration(new PersonContactConfiguration());

            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ContactTypeSeed(new int[] { 1, 2, 3 }));
        }
    }
}
