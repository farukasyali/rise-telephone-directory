using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Services.PersonApi.Models;

namespace PhoneBook.Services.PersonApi.Data.Configurations
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
