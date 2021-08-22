using PhoneBook.Services.Report.Core.Dtos;
using PhoneBook.Services.Report.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Core.Services
{
    public interface IReportService : IService<Reports>
    {
        Task<IEnumerable<ReportDto>> GetListAsync();
        
        Task<ReportDto> AddAsync();

        Task<bool> SaveRepotData(Guid id, string data);
    }
}
