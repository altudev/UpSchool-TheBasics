using System.Net;
using System.Net.Mail;
using Application.Common.Interfaces;
using Application.Common.Models.Email;

namespace Infrastructure.Services;

public class EmailManager:IEmailService
{
    public void SendEmailConfirmation(SendEmailConfirmationDto sendEmailConfirmationDto)
    {
        var htmlContent = $"<h4>Hello {sendEmailConfirmationDto.Name}</h4></br><p>Your email activation token:{sendEmailConfirmationDto.Token}</p>";

        var subject = $"Confirm your email address";
        
        Send(new SendEmailDto(sendEmailConfirmationDto.Email,htmlContent,subject));

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