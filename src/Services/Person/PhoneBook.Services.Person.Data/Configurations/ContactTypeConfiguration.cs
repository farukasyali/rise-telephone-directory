using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Services.Person.Core.Models;

namespace PhoneBook.Services.Person.Data.Configurations
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactTypes>
    {
        public void Configure(EntityTypeBuilder<ContactTypes> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Value).IsRequired().HasMaxLength(50);

            builder.ToTable("ContactTypes");
        }
    }
}
