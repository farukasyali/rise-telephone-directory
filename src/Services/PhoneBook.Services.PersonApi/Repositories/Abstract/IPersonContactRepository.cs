using PhoneBook.Services.PersonApi.Dtos;
using PhoneBook.Services.PersonApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.Repositories.Abstract
{
    public interface IPersonContactRepository : IRepository<PersonContact>
    {
        Task<IEnumerable<ContactType>> GetContactTypeList();
    }
}
