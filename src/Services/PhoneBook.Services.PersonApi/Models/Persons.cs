using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PhoneBook.Services.PersonApi.Models
{
    public class Persons : IEntity
    {
        public Persons()
        {
            PersonContacts = new Collection<PersonContacts>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual ICollection<PersonContacts> PersonContacts { get; set; }
    }
}
