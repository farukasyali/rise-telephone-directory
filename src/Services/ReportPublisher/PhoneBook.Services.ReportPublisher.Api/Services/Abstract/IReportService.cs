using System;
using System.Threading.Tasks;

namespace PhoneBook.Services.ReportPublisher.Api.Services.Abstract
{
    public interface IReportService
    {
        Task<string> SaveReportData(Guid reportId, string data);
        Task SendSignalRMessage(Guid id);
    }
}
