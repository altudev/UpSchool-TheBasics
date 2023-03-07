using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Utilities;

namespace UpSchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly PasswordGenerator _passwordGenerator;
        private readonly GeneratePasswordDto _generatePasswordDto;

        public PasswordsController()
        {
            _passwordGenerator = new PasswordGenerator();

            _generatePasswordDto = new GeneratePasswordDto
            {
                Length = 15,
                IncludeSpecialCharacters = true,
                IncludeUppercaseCharacters = true
            };
        }

        [HttpGet]
        public IActionResult GetPasswords()
        {
            List<string> passwords = new List<string>();

            for (int i = 0; i < 9; i++)
                passwords.Add(_passwordGenerator.Generate(_generatePasswordDto));

            return Ok(passwords);
        }
    }
}
