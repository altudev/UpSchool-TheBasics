using Application.Features.Excel.Commands.ReadCities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
  
    public class ExcelsController : ApiControllerBase
    {
        [HttpPost("ReadCities")]
        public async Task<IActionResult> ReadCitiesAsync(ExcelReadCitiesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
