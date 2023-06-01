using Application.Features.Accounts.Queries.GetAll;

namespace Application.Features.Accounts.Queries.GetById
{
    public class AccountGetByIdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Url { get; set; }
        public bool IsFavourite { get; set; }
        public string UserId { get; set; }

        public List<AccountGetByIdCategoryDto> Categories { get; set; }

        public AccountGetByIdDto()
        {
            Categories = new List<AccountGetByIdCategoryDto>();
        }
    }
}
