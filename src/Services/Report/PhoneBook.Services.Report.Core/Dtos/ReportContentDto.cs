using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Core.Dtos
{
    public class ReportContentDto
    {
        public string Location { get; set; }
        public int RegistredPersonCount { get; set; }
        public int RegisteredPhoneNoCount { get; set; }
    }
}
