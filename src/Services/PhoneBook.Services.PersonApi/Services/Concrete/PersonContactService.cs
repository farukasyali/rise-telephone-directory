using PhoneBook.Services.PersonApi.Models;
using PhoneBook.Services.PersonApi.Repositories.Abstract;
using PhoneBook.Services.PersonApi.Services.Abstract;

namespace PhoneBook.Services.PersonApi.Services.Concrete
{
    public class PersonContactService : Service<PersonContact>, IPersonContactService
    {
        public PersonContactService(IRepository<PersonContact> repository) : base(repository)
        {
        }
    }
}
