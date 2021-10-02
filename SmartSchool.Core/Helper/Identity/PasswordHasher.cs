using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace SmartSchool.Core.Helper.Identity
{
    public static class PasswordHasher
    {
        const int SaltSize = 128 / 8;
        const int HashSize = 256 / 8;
        const KeyDerivationPrf Prf = KeyDerivationPrf.HMACSHA256;
        const int IterationCount = 10_000;

        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hash = KeyDerivation.Pbkdf2(password, salt, Prf, IterationCount, HashSize);

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null)
            {
                throw new ArgumentNullException(nameof(hashedPassword));
            }

            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var byteArray = Convert.FromBase64String(hashedPassword);
            if (byteArray.Length < 1)
            {
                return false;
            }

            var salt = new byte[SaltSize];
            Buffer.BlockCopy(byteArray, 0, salt, 0, SaltSize);

            var hashed = new byte[HashSize];
            Buffer.BlockCopy(byteArray, SaltSize, hashed, 0, HashSize);

            var hashCheck = KeyDerivation.Pbkdf2(password, salt, Prf, IterationCount, HashSize);

            if (CryptographicOperations.FixedTimeEquals(hashed, hashCheck))
            {
                return true;
            }

            return false;
        }
    }
}