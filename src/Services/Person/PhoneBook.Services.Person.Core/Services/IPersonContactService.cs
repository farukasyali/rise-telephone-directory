using PhoneBook.Services.Person.Core.Dtos;
using PhoneBook.Services.Person.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Person.Core.Services
{
    public interface IPersonContactService : IService<PersonContacts>
    {
        Task<IEnumerable<ContactTypeDto>> GetContactTypeList();

        Task<IEnumerable<PersonContactDto>> GetAllByPersonId(Guid id);

        Task<PersonContactDto> AddorUpdateAsync(PersonContactDto contact);

        Task<bool> DeleteAsync(Guid id);


    }
}
