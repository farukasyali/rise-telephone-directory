using PhoneBook.Services.Person.Core.Dtos;
using PhoneBook.Services.Person.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Person.Core.Services
{
    public interface IPersonService : IService<Persons>
    {
        Task<PersonDto> AddorUpdateAsync(PersonDto person);

        Task<IEnumerable<PersonDto>> GetListAsync();

        Task<IEnumerable<ReportDataDto>> GetReportData();

    }
}
