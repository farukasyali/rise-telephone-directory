using PhoneBook.Services.PersonApi.Data;
using PhoneBook.Services.PersonApi.Models;
using PhoneBook.Services.PersonApi.Repositories.Abstract;

namespace PhoneBook.Services.PersonApi.Repositories.Concrete.EntityFramework
{
    public class PersonRepository : EfRepository<Persons>, IPersonRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public PersonRepository(AppDbContext context) : base(context)
        {
        }

    }
}
