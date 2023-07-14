using Application.Features.Accounts.Queries.GetById;

namespace Application.Common.Models.WorkerService
{
    public class WorkerServiceNewAccountAddedDto
    {
        public AccountGetByIdDto Account { get; set; }
        public string AccessToken { get; set; }

        public WorkerServiceNewAccountAddedDto(AccountGetByIdDto account, string accessToken)
        {
            Account = account;

            AccessToken = accessToken;
        }
    }
}
