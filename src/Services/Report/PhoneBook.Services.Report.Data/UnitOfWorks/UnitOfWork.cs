using PhoneBook.Services.Report.Core.UnitOfWorks;
using PhoneBook.Services.Report.Data.Repositories.EntityFramework;
using PhoneBook.Services.Report.Core.Repositories;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhoneBookReportDbContext _context;

        private ReportsRepository _reportsRepository;

        public IReportsRepository Report => _reportsRepository = _reportsRepository ?? new ReportsRepository(_context);

        public UnitOfWork(PhoneBookReportDbContext appDbContext)
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
