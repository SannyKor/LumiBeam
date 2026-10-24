namespace LumiBeam.API.Services.Interfaces
{
    public interface IPasswordHasherService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
