using System;
using BCrypt.Net;
using System.Security.Cryptography;

namespace Problem.StudentDataBase.TechnicalStuff
{
    internal class PasswordHasher
    {
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);

        public static bool VerifyPassword(string enteredPassword, string storedHash) => BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
    }
}
