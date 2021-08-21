using PhoneBook.Web.Models;
using System;
using System.Threading.Tasks;

namespace PhoneBook.Web.Services.Abstract
{
    public interface IPersonService
    {
        Task<string> GetPerson();

        Task<string> GetPersonList();

        Task<string> GetPersonContactsByPersonId(Guid id);

        Task<string> GetContactTypes();

        Task<string> SavePerson(PersonDto model);

        Task<string> DeletePerson(Guid id);

    }
}
