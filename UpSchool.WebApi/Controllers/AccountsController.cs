using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Utilities;
using UpSchool.Persistence.EntityFramework.Contexts;

namespace UpSchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UpStorageDbContext _dbContext;

        public AccountsController(IMapper mapper, UpStorageDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

       // private static List<Account> _accounts = new()
       // {
       //     new Account()
       //     {
       //         Id = new Guid("0bb85132-e3fa-4229-a3cf-f817baa418f5"),
       //         UserName = "mrpickle",
       //         Password = StringHelper.Base64Encode("123pickle123"),
       //         IsFavourite = false,
       //         CreatedOn = DateTimeOffset.Now,
       //         Title = "UpSchool",
       //         Url = "https://www.upschool.com",
       //     },

       //     new Account()
       //     {
       //     Id = new Guid("f4c43715-59d6-4806-9ee9-8cf8a1de8d19"),
       //     UserName = "fullspeed@gmail.com",
       //     Password = StringHelper.Base64Encode("123fullspeed123"),
       //     IsFavourite = true,
       //     CreatedOn = DateTimeOffset.Now,
       //     Title = "Gmail",
       //     Url = "https://www.google.com/intl/tr/gmail/about/",
       //     },

       //new Account
       // {
       //     Id = new Guid("bf5f7461-becc-46f8-b4cd-a39b8e6ca626"),
       //     UserName = "movieguy",
       //     Password = StringHelper.Base64Encode("123movieguy123"),
       //     IsFavourite = false,
       //     CreatedOn = DateTimeOffset.Now,
       //     Title = "Sinemalar",
       //     Url = "https://www.sinemalar.com",
       // }
    // };

        

        [HttpGet]
        public IActionResult GetAll()
        {

            var accounts = _dbContext.Accounts.ToList();

            var accountDtos = accounts.Select(account => AccountDto.MapFromAccount(account)).ToList();

            // SELECT * FROM dbo.Accounts

            return Ok(accountDtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            //var account = _accounts.FirstOrDefault(x => x.Id == id);

            var account = _dbContext.Accounts.FirstOrDefault(x => x.Id == id);

            if (account is null) return NotFound("The selected account was not found.");

            return Ok(AccountDto.MapFromAccount(account));
        }

        [HttpPost]
        public IActionResult Add(AccountAddDto accountAddDto)
        {
            var account = new Account()
            {
                Id = Guid.NewGuid(),
                Title = accountAddDto.Title,
                UserName = accountAddDto.UserName,
                Password = accountAddDto.Password,
                IsFavourite = accountAddDto.IsFavourite,
                CreatedOn = DateTimeOffset.Now,
                Url = accountAddDto.Url,
            };

            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            return Ok(AccountDto.MapFromAccount(account));
        }

        [HttpPut]
        public IActionResult Edit(AccountEditDto accountEditDto)
        {
            //var accountIndex = _accounts.FindIndex(x => x.Id == accountEditDto.Id);

            var account = _dbContext.Accounts.FirstOrDefault(x => x.Id == accountEditDto.Id);

            if (account is null) return NotFound("The selected account was not found.");

            var updatedAccount = _mapper.Map<AccountEditDto,Account>(accountEditDto, account);

            _dbContext.Accounts.Update(updatedAccount);
            _dbContext.SaveChanges();

            return Ok(_mapper.Map<AccountDto>(updatedAccount));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var account = _dbContext.Accounts.FirstOrDefault(x => x.Id == id);

            if (account is null) return NotFound("The selected account was not found.");

            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
