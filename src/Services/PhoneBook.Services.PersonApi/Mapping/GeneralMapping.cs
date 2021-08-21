using AutoMapper;
using PhoneBook.Services.PersonApi.Dtos;
using PhoneBook.Services.PersonApi.Models;

namespace PhoneBook.Services.PersonApi.Mapping
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
