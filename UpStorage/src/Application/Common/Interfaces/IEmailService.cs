using Application.Common.Models.Email;

namespace Application.Common.Interfaces;

public interface IEmailService
{
    void SendEmailConfirmation(SendEmailConfirmationDto sendEmailConfirmationDto);
}