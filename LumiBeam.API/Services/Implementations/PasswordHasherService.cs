using LumiBeam.API.Services.Interfaces;
using System.Security.Cryptography;

namespace LumiBeam.API.Services.Implementations
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private const int SaltSize = 16; // 128 біт
        private const int KeySize = 32;  // 256 біт
        private const int Iterations = 100_000;
        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

        public string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, KeySize);

            return $"{Convert.ToHexString(salt)}-{Convert.ToHexString(hash)}";
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            var parts = passwordHash.Split('-');
            if (parts.Length != 2)
                return false;

            byte[] salt = Convert.FromHexString(parts[0]);
            byte[] expectedHash = Convert.FromHexString(parts[1]);

            byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, KeySize);

            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
    }
}
