using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.Models
{
    public class ContactTypes : IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
     
    }
}
