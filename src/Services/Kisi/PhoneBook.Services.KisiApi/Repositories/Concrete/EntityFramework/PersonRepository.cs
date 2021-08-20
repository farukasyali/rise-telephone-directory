using PhoneBook.Services.KisiApi.Data;
using PhoneBook.Services.PersonApi.Models;

namespace PhoneBook.Services.PersonApi.Repositories.Concrete.EntityFramework
{
    public class PersonRepository : EfRepository<Person>
    {
        internal  AppDbContext _appDbContext { get => _context as AppDbContext; }

        public PersonRepository(AppDbContext context) : base(context)
        {
        }

    }
}
