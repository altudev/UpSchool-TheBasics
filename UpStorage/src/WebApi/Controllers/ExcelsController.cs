using Application.Features.Excel.Commands.ReadCities;
using Application.Features.Excel.Commands.ReadCountries;
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

        [HttpPost("ReadCountries")]
        public async Task<IActionResult> ReadCountries(ExcelReadCountriesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
