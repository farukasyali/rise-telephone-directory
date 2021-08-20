using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PhoneBook.Services.PersonApi.Models
{
    public class Person : IEntity
    {
        public Person()
        {
            PersonContacts = new Collection<PersonContact>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual ICollection<PersonContact> PersonContacts { get; set; }
    }
}
