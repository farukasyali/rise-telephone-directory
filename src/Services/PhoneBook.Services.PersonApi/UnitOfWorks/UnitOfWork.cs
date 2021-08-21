using PhoneBook.Services.PersonApi.Data;
using PhoneBook.Services.PersonApi.Repositories.Abstract;
using PhoneBook.Services.PersonApi.Repositories.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private PersonContactRepository _personContactRepository;

        private PersonRepository _personRepository;

        public IPersonContactRepository PersonContacts => _personContactRepository = _personContactRepository ?? new PersonContactRepository(_context);

        public IPersonRepository Persons => _personRepository = _personRepository ?? new PersonRepository(_context);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
