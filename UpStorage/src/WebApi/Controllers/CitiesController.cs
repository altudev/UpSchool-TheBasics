using Application.Features.Cities.Commands.Add;
using Application.Features.Cities.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Authorize]
    public class CitiesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(CityAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(CityGetAllQuery query)
        {
            
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await Mediator.Send(new CityGetAllQuery(id,null)));
        }
    }
}
