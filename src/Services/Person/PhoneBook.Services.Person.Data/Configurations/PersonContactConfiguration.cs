using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Services.Person.Core.Models;

namespace PhoneBook.Services.Person.Data.Configurations
{
    public class PersonContactConfiguration : IEntityTypeConfiguration<PersonContacts>
    {
        public void Configure(EntityTypeBuilder<PersonContacts> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContactTypeId).IsRequired();

            builder.Property(x => x.Value).IsRequired();

            builder.ToTable("PersonContacts");
        }
    }
}
