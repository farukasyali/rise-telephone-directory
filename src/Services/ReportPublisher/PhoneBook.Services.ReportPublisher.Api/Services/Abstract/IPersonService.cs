using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.ReportPublisher.Api.Services.Abstract
{
   public interface IPersonService
    {
        Task<string> GetReportData();
    }
}
