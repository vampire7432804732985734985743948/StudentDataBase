using System;
using System.Security.Cryptography;

namespace Problem.StudentDataBase.TechnicalStuff
{
    internal class PasswordHasher
    {
        private const int SaltSize = 16; 
        private const int HashSize = 20;
        private const int Iterations = 10000;

        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }

            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(enteredPassword))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(enteredPassword));
            }

            if (string.IsNullOrWhiteSpace(storedHash))
            {
                throw new ArgumentException("Stored hash cannot be null or empty.", nameof(storedHash));
            }
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            byte[] storedHashPart = new byte[HashSize];
            Array.Copy(hashBytes, SaltSize, storedHashPart, 0, HashSize);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] enteredPasswordHash = pbkdf2.GetBytes(HashSize);

            for (int i = 0; i < HashSize; i++)
            {
                if (storedHashPart[i] != enteredPasswordHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
