using System;

namespace PhoneBook.Services.Report.Core.Dtos
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
    }
}
