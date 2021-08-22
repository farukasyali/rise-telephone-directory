using PhoneBook.Services.Person.Core.Dtos;
using PhoneBook.Services.Person.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Person.Core.Repositories
{
    public interface IPersonRepository : IRepository<Persons>
    {
        Task<IEnumerable<ReportDataDto>> GetReportData();
    }
}
