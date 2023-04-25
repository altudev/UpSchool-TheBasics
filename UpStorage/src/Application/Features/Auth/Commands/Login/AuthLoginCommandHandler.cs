using Application.Common.Interfaces;
using Application.Common.Models.Auth;
using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Commands.Login
{
    public class AuthLoginCommandHandler:IRequestHandler<AuthLoginCommand,Response<AuthLoginDto>>
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthLoginCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Response<AuthLoginDto>> Handle(AuthLoginCommand request, CancellationToken cancellationToken)
        {
            var jwtDto = await _authenticationService.LoginAsync(MapLoginCommandToRequest(request), cancellationToken);

            return MapJwtDtoToAuthLoginDto(jwtDto);
        }

        private Response<AuthLoginDto> MapJwtDtoToAuthLoginDto(JwtDto jwt) => new Response<AuthLoginDto>(new AuthLoginDto(jwt.AccessToken,jwt.ExpiryDate));
        private AuthLoginRequest MapLoginCommandToRequest(AuthLoginCommand command) => new AuthLoginRequest(command.Email,command.Password);
    }
}
