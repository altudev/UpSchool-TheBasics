namespace Application.Common.Models.Auth;

public class TwoFactorGeneratedDto
{
    public byte[] QrCodeImage { get; set; }
    public string Key { get; set; }
}