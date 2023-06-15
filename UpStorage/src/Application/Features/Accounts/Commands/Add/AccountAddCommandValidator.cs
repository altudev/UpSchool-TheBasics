using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Features.Accounts.Commands.Add
{
    public class AccountAddCommandValidator:AbstractValidator<AccountAddCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public AccountAddCommandValidator(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required.");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username is required.")
                .MinimumLength(2)
                .WithMessage("Username must be at least 2 characters."); ;

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters.");

            RuleFor(x => x.Url)
                .NotEmpty()
                .WithMessage("URL is required.")
                .Must(BeAValidUrl)
                .WithMessage("URL must be valid."); 
        }

        private bool BeAValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }
    }
}
