using PhoneBook.Services.PersonApi.Dtos;
using PhoneBook.Services.PersonApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.Services.Abstract
{
    public interface IPersonContactService : IService<PersonContacts>
    {
        Task<IEnumerable<ContactTypes>> GetContactTypeList();
        Task<IEnumerable<PersonContacts>> GetAllByPersonId(Guid id);
        
    }
}
