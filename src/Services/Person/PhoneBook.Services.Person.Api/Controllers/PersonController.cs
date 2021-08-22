using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services.Person.Core.Dtos;
using PhoneBook.Services.Person.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Person.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IMapper mapper, IPersonService personService)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _personService.GetListAsync();

            return Ok(result);

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("savePerson")]
        public async Task<IActionResult> SavePerson([FromBody] PersonDto model)
        {
            var result = await _personService.AddorUpdateAsync(model);
            return Ok(result);

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        [Route("/api/[controller]/deletePerson/{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var entity = await _personService.GetByIdAsync(id);

            if (entity == null)
                return BadRequest("Kayıt bulunamadı");

            _personService.Remove(entity);

            return Ok(true);
        }

        
    }
}
