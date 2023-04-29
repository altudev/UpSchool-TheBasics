namespace Application.Common.Models.Email;

public class SendEmailConfirmationDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public string Link { get; set; }
}