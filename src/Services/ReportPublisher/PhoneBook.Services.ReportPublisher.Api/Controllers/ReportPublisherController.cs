using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PhoneBook.Services.ReportPublisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportPublisherController : ControllerBase
    {
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("publish")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
