using Application.Common.Interfaces;
using Application.Common.Localizations;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Application.Features.Accounts.Commands.Add
{
    public class AccountAddCommandHandler:IRequestHandler<AccountAddCommand,Response<Guid>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IStringLocalizer<CommonLocalizations> _localizer;

        public AccountAddCommandHandler(ICurrentUserService currentUserService, IApplicationDbContext applicationDbContext, IStringLocalizer<CommonLocalizations> localizer)
        {
            _currentUserService = currentUserService;
            _applicationDbContext = applicationDbContext;
            _localizer = localizer;
        }

        public async Task<Response<Guid>> Handle(AccountAddCommand request, CancellationToken cancellationToken)
        {
            var account = AccountAddCommandMapper(request);

            await _applicationDbContext.Accounts.AddAsync(account, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(_localizer[CommonLocalizationKeys.HandlerMessages.Add], account.Id);
        }

        private Account AccountAddCommandMapper(AccountAddCommand command)
        {
            var id = Guid.NewGuid();

            return new Account()
            {
                Id = id,
                Title = command.Title,
                UserName = command.UserName,
                Password = command.Password,
                Url = command.Url,
                IsFavourite = command.IsFavourite,
                UserId = _currentUserService.UserId,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = _currentUserService.UserId,
                IsDeleted = false,
                AccountCategories = AccountCategoriesMapper(command.CategoryIds, id)
            };
        }

        private List<AccountCategory> AccountCategoriesMapper(List<Guid>? categoryIds, Guid accountId)
        {
            if (categoryIds is null || !categoryIds.Any())
                return new List<AccountCategory>();

            return categoryIds
                .Select(categoryId => new AccountCategory()
                {
                    AccountId = accountId,
                    CategoryId = categoryId

                })
                .ToList();
        }
    }
}
