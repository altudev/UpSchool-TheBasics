using Application.Common.Interfaces;
using Application.Common.Models.General;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Accounts.Queries.GetAll
{
    public class AccountGetAllQueryHandler : IRequestHandler<AccountGetAllQuery, PaginatedList<AccountGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;

        public AccountGetAllQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
        }

        public async Task<PaginatedList<AccountGetAllDto>> Handle(AccountGetAllQuery request, CancellationToken cancellationToken)
        {
            var accountsQuery = GetAccountsQuery();

            var countQuery = GetCountQuery();

            var accounts = await accountsQuery
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var totalCount = await countQuery.CountAsync(cancellationToken);

            var mappedAccounts = AccountGetAllDtoMapper(accounts);

            return new PaginatedList<AccountGetAllDto>(mappedAccounts, totalCount, request.PageNumber, request.PageSize);
        }


        private List<AccountGetAllDto> AccountGetAllDtoMapper(List<Account> accounts)
        {
            List<AccountGetAllDto> accountDtos = new();

            foreach (var account in accounts)
            {
                accountDtos.Add(new AccountGetAllDto()
                {
                    Id = account.Id,
                    UserId = account.UserId,
                    IsFavourite = account.IsFavourite,
                    Password = account.Password,
                    UserName = account.UserName,
                    Title = account.Title,
                    Url = account.Url,
                    Categories = AccountGetAllCategoryDtoMapper(account.AccountCategories),
                });
            }

            return accountDtos;
        }

        private List<AccountGetAllCategoryDto> AccountGetAllCategoryDtoMapper(ICollection<AccountCategory>? accountCategories)
        {
            if (accountCategories is null || !accountCategories.Any())
                return new List<AccountGetAllCategoryDto>();

            return accountCategories
                .Select(ac =>
                    new AccountGetAllCategoryDto { Id = ac.Category.Id, Name = ac.Category.Name })
                .ToList();
        }

        private IQueryable<Account> GetAccountsQuery()
        {
            return _applicationDbContext.Accounts.AsNoTracking()
                .Where(x => x.UserId == _currentUserService.UserId)
                .Include(x=>x.AccountCategories)
                .ThenInclude(x=>x.Category);
        }

        private IQueryable<Account> GetCountQuery()
        {
            return _applicationDbContext.Accounts.AsNoTracking()
                .Where(x => x.UserId == _currentUserService.UserId);
        }
    }
}
