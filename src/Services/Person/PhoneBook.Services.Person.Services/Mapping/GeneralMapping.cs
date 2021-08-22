using AutoMapper;
using PhoneBook.Services.Person.Core.Dtos;
using PhoneBook.Services.Person.Core.Models;

namespace PhoneBook.Services.Person.Service.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Persons, PersonDto>().ReverseMap();

            CreateMap<PersonContacts, PersonContactDto>().ReverseMap();

            CreateMap<ContactTypes, ContactTypeDto>().ReverseMap();

        }
    }
}
