using PhoneBook.Services.Report.Core.Models;
using PhoneBook.Services.Report.Core.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Data.Repositories.EntityFramework
{
    public class ReportsRepository : EfRepository<Reports>, IReportsRepository
    {
        private PhoneBookReportDbContext _appDbContext { get => _context as PhoneBookReportDbContext; }

        public ReportsRepository(PhoneBookReportDbContext context) : base(context)
        {
        }

    }
}
