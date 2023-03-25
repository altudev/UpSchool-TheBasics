using UpSchool.Domain.Entities;

namespace UpSchool.Domain.Dtos
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Url { get; set; }
        public bool IsFavourite { get; set; }
        public bool ShowPassword { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public AccountDto()
        {
            ShowPassword = false;
        }

        public static AccountDto MapFromAccount(Account account)
        {
            return new AccountDto()
            {
                Id = account.Id,
                Title = account.Title,
                UserName = account.UserName,
                Password = account.Password,
                Url = account.Url,
                ShowPassword = false,
                CreatedOn = account.CreatedOn,
                IsFavourite = account.IsFavourite
            };
        }
    }
}
