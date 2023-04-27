using Application.Common.Models.Auth;

namespace Application.Common.Interfaces;

public interface ITwoFactorService
{
    TwoFactorGeneratedDto Generate(string email);
    bool Validate(string userCode);
}