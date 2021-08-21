using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Services.PersonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.Data.Seeds
{
    public class ContactTypeSeed : IEntityTypeConfiguration<ContactType>

    {
        private readonly int[] _ids;

        public ContactTypeSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.HasData(
                  new ContactType { Id = _ids[0], Value = "Telefon No" }
                , new ContactType { Id = _ids[1], Value = "E-mail" }
                , new ContactType { Id = _ids[2], Value = "Konum" });
        }

    }
}
