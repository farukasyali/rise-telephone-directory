using PhoneBook.Services.PersonApi.Models;
using PhoneBook.Services.PersonApi.Repositories.Abstract;
using PhoneBook.Services.PersonApi.Services.Abstract;
using PhoneBook.Services.PersonApi.UnitOfWorks;

namespace PhoneBook.Services.PersonApi.Services.Concrete
{
    public class PersonService : Service<Persons>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork, IRepository<Persons> repository) : base(unitOfWork, repository)
        {
        }
    }
}
