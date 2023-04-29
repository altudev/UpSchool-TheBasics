namespace Application.Common.Models.Email;

public class SendEmailDto
{
    public List<string> EmailAddresses { get; set; }
    public string Content { get; set; }
    public string Subject { get; set; }
    

    public SendEmailDto(List<string> emailAddresses, string content, string subject)
    {
        EmailAddresses = emailAddresses;

        Content = content;

        Subject = subject;
    }
    
    public SendEmailDto(string emailAddress, string content, string subject)
    {
        EmailAddresses = new List<string>(){emailAddress};

        Content = content;

        Subject = subject;
    }
}