using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Services.PersonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.Data.Configurations 
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
