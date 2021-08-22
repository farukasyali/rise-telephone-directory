using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.Person.Core.Models;
using PhoneBook.Services.Person.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Person.Data.Repositories.EntityFramework
{
    public class PersonContactRepository : EfRepository<PersonContacts>, IPersonContactRepository
    {
        private PhoneBookDbContext _appDbContext { get => _context as PhoneBookDbContext; }

        public PersonContactRepository(PhoneBookDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ContactTypes>> GetContactTypeList()
        {
            return await _appDbContext.ContactTypes.ToListAsync();
        }
    }
}
