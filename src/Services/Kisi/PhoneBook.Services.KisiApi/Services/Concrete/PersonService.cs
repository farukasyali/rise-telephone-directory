using PhoneBook.Services.PersonApi.Models;
using PhoneBook.Services.PersonApi.Repositories.Abstract;
using PhoneBook.Services.PersonApi.Services.Abstract;

namespace PhoneBook.Services.PersonApi.Services.Concrete
{
    public class PersonService : Service<Person>, IPersonService
    {
        public PersonService(IRepository<Person> repository) : base( repository)
        {
        }
    }
}
