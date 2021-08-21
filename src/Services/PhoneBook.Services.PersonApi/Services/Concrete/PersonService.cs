using PhoneBook.Services.PersonApi.Models;
using PhoneBook.Services.PersonApi.Repositories.Abstract;
using PhoneBook.Services.PersonApi.Services.Abstract;
using PhoneBook.Services.PersonApi.UnitOfWorks;

namespace PhoneBook.Services.PersonApi.Services.Concrete
{
    public class PersonService : Service<Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork, IRepository<Person> repository) : base(unitOfWork, repository)
        {
        }
    }
}
