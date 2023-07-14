using Application.Common.Models.WorkerService;
using Application.Features.Accounts.Commands.Add;
using Application.Features.Accounts.Queries.GetAll;
using Application.Features.Accounts.Queries.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    public class AccountsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(AccountAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("CrawlerServiceExample")]
        public async Task<IActionResult> CrawlerServiceExampleAsync(WorkerServiceNewAccountAddedDto newAccountAddedDto)
        {
            return Ok();
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
