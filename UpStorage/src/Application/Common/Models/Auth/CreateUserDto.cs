using Domain.Identity;

namespace Application.Common.Models.Auth
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public CreateUserDto(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;

            LastName = lastName;

            Email = email;

            Password = password;
        }

        public User MapToUser()
        {
            return new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                UserName = this.Email,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = null,
            };
        }
    }
}
