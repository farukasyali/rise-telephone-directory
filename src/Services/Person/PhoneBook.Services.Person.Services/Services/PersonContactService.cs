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
    public class PersonContactService : Service<PersonContacts>, IPersonContactService
    {
        private readonly IMapper _mapper;

        public PersonContactService(IMapper mapper, IUnitOfWork unitOfWork, IRepository<PersonContacts> repository) : base(unitOfWork,repository)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonContactDto>> GetAllByPersonId(Guid id)
        {
            var result = await _unitOfWork.PersonContacts.Where(a => a.PersonId == id);
            return _mapper.Map<List<PersonContactDto>>(result);
        }

        public async Task<IEnumerable<ContactTypeDto>> GetContactTypeList()
        {
            var result = await _unitOfWork.PersonContacts.GetContactTypeList();
            return _mapper.Map<List<ContactTypeDto>>(result);
        }

        public async Task<PersonContactDto> AddorUpdateAsync(PersonContactDto contact)
        {
            var entity = _mapper.Map<PersonContacts>(contact);
            if (contact.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                await _unitOfWork.PersonContacts.AddAsync(entity);
            }
            else
            {
                entity = _unitOfWork.PersonContacts.Update(entity);
            }

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PersonContactDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _unitOfWork.PersonContacts.GetByIdAsync(id);
            if (entity != null)
                _unitOfWork.PersonContacts.Remove(entity);
            else
                return false;

            return true;
        }
    }
}
