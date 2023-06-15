using Application.Features.Accounts.Commands.Add;
using Application.Features.Accounts.Queries.GetAll;
using Application.Features.Accounts.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AccountsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(AccountAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber=1,int pageSize=10)
        {
            return Ok(await Mediator.Send(new AccountGetAllQuery(pageNumber,pageSize)));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await Mediator.Send(new AccountGetByIdQuery(id)));
        }
    }
}
