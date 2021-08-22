using PhoneBook.Services.Person.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Person.Core.Repositories
{
    public interface IPersonContactRepository : IRepository<PersonContacts>
    {
        Task<IEnumerable<ContactTypes>> GetContactTypeList();
    }
}
