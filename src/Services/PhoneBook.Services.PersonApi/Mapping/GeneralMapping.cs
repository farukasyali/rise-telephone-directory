using AutoMapper;
using PhoneBook.Services.PersonApi.Dtos;
using PhoneBook.Services.PersonApi.Models;

namespace PhoneBook.Services.PersonApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<PersonContact, PersonContactDto>().ReverseMap();

            CreateMap<ContactType, ContactTypeDto>().ReverseMap();

        }
    }
}
