using LumiBeam.Domain.Entities;

namespace LumiBeam.API.Services.Interfaces
{
    public interface ITokenService
    {
        (string Token, DateTime ExpiresAt) GenerateToken(User user);
    }
}
