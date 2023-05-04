using Application.Features.Countries.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ApiControllerBase
    {
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(CountriesGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
