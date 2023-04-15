namespace Application.Features.Auth.Commands.Register
{
    public class AuthRegisterDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ActivationToken { get; set; }

        public AuthRegisterDto(string email, string fullName, string activationToken)
        {
            Email = email;
            FullName =fullName;
            ActivationToken = activationToken;
        }
    }
}
