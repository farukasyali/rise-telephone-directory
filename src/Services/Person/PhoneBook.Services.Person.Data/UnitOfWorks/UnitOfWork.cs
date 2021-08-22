using PhoneBook.Services.Person.Core.Repositories;
using PhoneBook.Services.Person.Core.UnitOfWorks;
using PhoneBook.Services.Person.Data.Repositories.EntityFramework;
using System.Threading.Tasks;

namespace PhoneBook.Services.Person.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhoneBookDbContext _context;

        private PersonContactRepository _personContactRepository;

        private PersonRepository _personRepository;

        public IPersonContactRepository PersonContacts => _personContactRepository = _personContactRepository ?? new PersonContactRepository(_context);

        public IPersonRepository Persons => _personRepository = _personRepository ?? new PersonRepository(_context);

        public UnitOfWork(PhoneBookDbContext appDbContext)
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
