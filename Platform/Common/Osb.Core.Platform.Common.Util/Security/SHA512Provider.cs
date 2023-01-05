using System;
using System.Security.Cryptography;

namespace Osb.Core.Platform.Common.Util.Security
{
    public static class SHA512Provider
    {
        public static string Encrypt(string plainValue, string salt)
        {
            byte[] valueBytes = System.Text.Encoding.UTF8.GetBytes(plainValue);
            var hmacSHA512 = new HMACSHA512(System.Text.Encoding.UTF8.GetBytes(salt));
            byte[] hash = hmacSHA512.ComputeHash(valueBytes);

            return Convert.ToBase64String(hash);
        }


        public static bool Compare(string plainValue, string hashedValue, string salt, string secret = null)
        {
            return Encrypt(plainValue, salt).Equals(hashedValue);
        }

        public static string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
