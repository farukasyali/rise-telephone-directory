using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services.PersonApi.Dtos;
using PhoneBook.Services.PersonApi.Models;
using PhoneBook.Services.PersonApi.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonContactController : ControllerBase
    {
        private readonly IPersonContactService _personContactService;
        private readonly IMapper _mapper;

        public PersonContactController(IMapper mapper, IPersonContactService personContactService)
        {
            _personContactService = personContactService;
            _mapper = mapper;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ContactTypeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getContactTypes")]
        public async Task<IActionResult> GetList()
        {
            var result = await _personContactService.GetContactTypeList();
            
            return Ok(_mapper.Map<List<ContactTypeDto>>(result));

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonContactDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet]
        [Route("/api/[controller]/getAllByPersonId/{id}")]
        public async Task<IActionResult> GetByPersonId(Guid id)
        {
            var result = await _personContactService.GetAllByPersonId(id);

            return Ok(_mapper.Map<List<PersonContactDto>>(result));

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonContactDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("savePersonContact")]
        public async Task<IActionResult> SavePerson([FromBody] PersonContactDto model)
        {
            var entity = _mapper.Map<PersonContacts>(model);
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
                entity = await _personContactService.AddAsync(entity);
            }
            else
            {
                entity = _personContactService.Update(entity);
            }

            return Ok(_mapper.Map<PersonContactDto>(entity));

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        [Route("/api/[controller]/deletePersonContact/{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var entity = await _personContactService.GetByIdAsync(id);

            if (entity == null)
                return BadRequest("Kayıt bulunamadı");

            _personContactService.Remove(entity);

            return Ok(true);
        }


        


    }
}
