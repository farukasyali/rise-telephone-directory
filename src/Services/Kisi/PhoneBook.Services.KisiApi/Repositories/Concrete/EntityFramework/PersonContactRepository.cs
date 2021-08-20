using PhoneBook.Services.KisiApi.Data;
using PhoneBook.Services.PersonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.Repositories.Concrete.EntityFramework
{
    public class PersonContactRepository : EfRepository<PersonContact>
    {
        internal AppDbContext _appDbContext { get => _context as AppDbContext; }

        public PersonContactRepository(AppDbContext context) : base(context)
        {
        }

    }
}
