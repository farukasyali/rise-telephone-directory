using PhoneBook.Services.Person.Core.Models;
using PhoneBook.Services.Person.Core.Repositories;

namespace PhoneBook.Services.Person.Data.Repositories.EntityFramework
{
    public class PersonRepository : EfRepository<Persons>, IPersonRepository
    {
        private PhoneBookDbContext _appDbContext { get => _context as PhoneBookDbContext; }

        public PersonRepository(PhoneBookDbContext context) : base(context)
        {
        }

    }
}
