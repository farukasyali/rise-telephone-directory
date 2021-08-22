using AutoMapper;
using PhoneBook.Services.Person.Core.Dtos;
using PhoneBook.Services.Person.Core.Models;
using PhoneBook.Services.Person.Core.Repositories;
using PhoneBook.Services.Person.Core.Services;
using PhoneBook.Services.Person.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Person.Service.Services
{
    public class PersonService : Service<Persons>, IPersonService
    {

        private readonly IMapper _mapper;

        public PersonService(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Persons> repository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }

        public async Task<PersonDto> AddorUpdateAsync(PersonDto person)
        {
            var entity = _mapper.Map<Persons>(person);
            if (person.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                await _unitOfWork.Persons.AddAsync(entity);
            }
            else
            {
                entity = _unitOfWork.Persons.Update(entity);
            }
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PersonDto>(entity);

        }

        public async Task<IEnumerable<PersonDto>> GetListAsync()
        {
            var result = await _unitOfWork.Persons.GetAllAsync();

            return _mapper.Map<List<PersonDto>>(result);
        }
    }
}
