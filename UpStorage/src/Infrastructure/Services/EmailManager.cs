using System.Net;
using System.Net.Mail;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Common.Models.Email;

namespace Infrastructure.Services;

public class EmailManager:IEmailService
{
    private readonly string _wwwrootPath;
    public EmailManager(string wwwrootPath)
    {
        _wwwrootPath = wwwrootPath;
    }
    public void SendEmailConfirmation(SendEmailConfirmationDto sendEmailConfirmationDto)
    {
        var htmlContent = File.ReadAllText($"{_wwwrootPath}/email_templates/email_confirmation.html");
        
        htmlContent = htmlContent.Replace("{{subject}}", MessagesHelper.Email.Confirmation.Subject);
        
        htmlContent = htmlContent.Replace("{{name}}", MessagesHelper.Email.Confirmation.Name(sendEmailConfirmationDto.Name));
        
        htmlContent = htmlContent.Replace("{{activationMessage}}", MessagesHelper.Email.Confirmation.ActivationMessage);

        htmlContent = htmlContent.Replace("{{buttonText}}", MessagesHelper.Email.Confirmation.ButtonText);
        
        htmlContent = htmlContent.Replace("{{buttonLink}}", MessagesHelper.Email.Confirmation.Buttonlink(sendEmailConfirmationDto.Email,sendEmailConfirmationDto.Token));

        Send(new SendEmailDto(sendEmailConfirmationDto.Email,htmlContent,MessagesHelper.Email.Confirmation.Subject));

    }

    private void Send(SendEmailDto sendEmailDto)
    {
        MailMessage message = new MailMessage();
        
        sendEmailDto.EmailAddresses.ForEach(emailAddress=> message.To.Add(emailAddress));

        message.From = new MailAddress("noreply@entegraturk.com");

        message.Subject = sendEmailDto.Subject;

        message.IsBodyHtml = true;

        message.Body = sendEmailDto.Content;

        SmtpClient client = new SmtpClient();

        client.Port = 587;

        client.Host = "mail.entegraturk.com";

        client.EnableSsl = false;

        client.UseDefaultCredentials = false;

        client.Credentials = new NetworkCredential("noreply@entegraturk.com", "xzx2xg4Jttrbzm5nIJ2kj1pE4l");

        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        
        client.Send(message);


    }
}