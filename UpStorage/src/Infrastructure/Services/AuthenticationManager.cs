using Application.Common.Interfaces;
using Application.Common.Models.Auth;
using Domain.Identity;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AuthenticationManager:IAuthenticationService
    {
        private readonly UserManager<User> _userManager;

        public AuthenticationManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken)
        {
            var user = createUserDto.MapToUser();

            var identityResult = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!identityResult.Succeeded)
            {
                var failures = identityResult.Errors
                    .Select(x => new ValidationFailure(x.Code, x.Description));

                throw new ValidationException(failures);
            }

            return user.Id;

        }

        public async Task<string> GenerateEmailActivationTokenAsync(string userId, CancellationToken cancellationToken)
        {
           var user = await _userManager.FindByIdAsync(userId);

           return await _userManager.GenerateEmailConfirmationTokenAsync(user);

        }

        public Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken)
        {
            return _userManager.Users.AnyAsync(x => x.Email == email,cancellationToken);
        }
    }
}
