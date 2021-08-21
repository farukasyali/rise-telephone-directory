using System;

namespace PhoneBook.Services.PersonApi.Models
{
    public class PersonContact : IEntity
    {
       
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public string Value { get; set; }

        public virtual Person Person { get; set; }
    }
}
