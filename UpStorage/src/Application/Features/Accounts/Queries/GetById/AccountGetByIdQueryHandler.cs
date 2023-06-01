using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Accounts.Queries.GetById
{
    public class AccountGetByIdQueryHandler:IRequestHandler<AccountGetByIdQuery,AccountGetByIdDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;

        public AccountGetByIdQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
        }

        public async Task<AccountGetByIdDto> Handle(AccountGetByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _applicationDbContext
                .Accounts
                .AsNoTracking()
                .Where(x=>x.UserId == _currentUserService.UserId)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var categories = await _applicationDbContext
                .Categories
                .Where(x=>x.AccountCategories.Any(ac => ac.AccountId == account.Id))
                .ToListAsync(cancellationToken);

        }
    }
}
