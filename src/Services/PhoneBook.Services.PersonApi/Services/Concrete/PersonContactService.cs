using PhoneBook.Services.PersonApi.Dtos;
using PhoneBook.Services.PersonApi.Models;
using PhoneBook.Services.PersonApi.Repositories.Abstract;
using PhoneBook.Services.PersonApi.Services.Abstract;
using PhoneBook.Services.PersonApi.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.Services.Concrete
{
    public class PersonContactService : Service<PersonContact>, IPersonContactService
    {
        public PersonContactService(IUnitOfWork unitOfWork, IRepository<PersonContact> repository) : base(unitOfWork,repository)
        {
        }

        public async Task<IEnumerable<PersonContact>> GetAllByPersonId(Guid id)
        {
            return await _unitOfWork.PersonContacts.Where(a => a.PersonId == id);
        }

        public async Task<IEnumerable<ContactType>> GetContactTypeList()
        {
            return await _unitOfWork.PersonContacts.GetContactTypeList();
        }
    }
}
