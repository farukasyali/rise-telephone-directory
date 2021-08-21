using Microsoft.AspNetCore.Mvc;
using PhoneBook.Web.Models;
using PhoneBook.Web.Services.Abstract;
using System;
using System.Threading.Tasks;

namespace PhoneBook.Web.Controllers
{
    public class KisiController : Controller
    {
        private readonly IPersonService _personService;

        public KisiController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetPersonList()
        {
            var result = await _personService.GetPersonList();

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> GetPersonContacts([FromBody] RequestModel model)
        {
            var result = await _personService.GetPersonContactsByPersonId(model.id);

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> GetContactTypes()
        {
            var result = await _personService.GetContactTypes();

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> SavePerson([FromBody] PersonDto model)
        {
            var result = await _personService.SavePerson(model);
            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpPost]
        public async Task<IActionResult> DeletePerson([FromBody] RequestModel model)
        {
            var result = await _personService.DeletePerson(model.id);
            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        
    }
}
