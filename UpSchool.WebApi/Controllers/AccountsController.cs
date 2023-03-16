using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Utilities;

namespace UpSchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AccountsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //0bb85132-e3fa-4229-a3cf-f817baa418f5
        //f4c43715-59d6-4806-9ee9-8cf8a1de8d19
        //bf5f7461-becc-46f8-b4cd-a39b8e6ca626
        private static List<Account> _accounts = new()
        {
            new Account()
            {
                Id = new Guid("0bb85132-e3fa-4229-a3cf-f817baa418f5"),
                UserName = "mrpickle",
                Password = StringHelper.Base64Encode("123pickle123"),
                IsFavourite = false,
                CreatedOn = DateTimeOffset.Now,
                Title = "UpSchool",
                Url = "https://www.upschool.com",
            },

            new Account()
            {
            Id = new Guid("f4c43715-59d6-4806-9ee9-8cf8a1de8d19"),
            UserName = "fullspeed@gmail.com",
            Password = StringHelper.Base64Encode("123fullspeed123"),
            IsFavourite = true,
            CreatedOn = DateTimeOffset.Now,
            Title = "Gmail",
            Url = "https://www.google.com/intl/tr/gmail/about/",
            },

       new Account
        {
            Id = new Guid("bf5f7461-becc-46f8-b4cd-a39b8e6ca626"),
            UserName = "movieguy",
            Password = StringHelper.Base64Encode("123movieguy123"),
            IsFavourite = false,
            CreatedOn = DateTimeOffset.Now,
            Title = "Sinemalar",
            Url = "https://www.sinemalar.com",
        }
    };

        

        [HttpGet]
        public IActionResult GetAll()
        {
            var accountDtos = _accounts.Select(account => AccountDto.MapFromAccount(account));

            return Ok(accountDtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var account = _accounts.FirstOrDefault(x => x.Id == id);

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

            _accounts.Add(account);

            return Ok(AccountDto.MapFromAccount(account));
        }

        [HttpPut]
        public IActionResult Edit(AccountEditDto accountEditDto)
        {
            var accountIndex = _accounts.FindIndex(x => x.Id == accountEditDto.Id);

            if (accountIndex == -1) return NotFound("The selected account was not found.");

            var updatedAccount = _mapper.Map<AccountEditDto,Account>(accountEditDto, _accounts[accountIndex]);

            _accounts[accountIndex] = updatedAccount;

            return Ok(_mapper.Map<AccountDto>(updatedAccount));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var account = _accounts.FirstOrDefault(x => x.Id == id);

            if (account is null) return NotFound("The selected account was not found.");

            _accounts.Remove(account);

            return NoContent();
        }
    }
}
