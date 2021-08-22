using AutoMapper;
using PhoneBook.Services.Report.Core.Dtos;
using PhoneBook.Services.Report.Core.Models;

namespace PhoneBook.Services.Report.Api.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Reports, ReportDto>().ReverseMap();
        }
    }
}
