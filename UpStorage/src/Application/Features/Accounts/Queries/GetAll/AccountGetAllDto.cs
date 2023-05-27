namespace Application.Features.Accounts.Queries.GetAll
{
    public class AccountGetAllDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Url { get; set; }
        public bool IsFavourite { get; set; }
        public string UserId { get; set; }

        public List<AccountGetAllCategoryDto> Categories { get; set; }

        public AccountGetAllDto()
        {
            Categories = new List<AccountGetAllCategoryDto>();
        }
    }
}
