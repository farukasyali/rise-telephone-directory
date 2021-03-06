using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Services.Abstract
{
    public interface IReportService
    {
        Task<string> GetList();

        Task<string> SaveReport();

        Task<string> GetReportData(Guid id);

    }
}
