using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.PersonApi.Data;
using PhoneBook.Services.PersonApi.Models;
using PhoneBook.Services.PersonApi.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.Repositories.Concrete.EntityFramework
{
    public class PersonContactRepository : EfRepository<PersonContacts>, IPersonContactRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public PersonContactRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ContactTypes>> GetContactTypeList()
        {
            return await _appDbContext.ContactTypes.ToListAsync();
        }
    }
}
