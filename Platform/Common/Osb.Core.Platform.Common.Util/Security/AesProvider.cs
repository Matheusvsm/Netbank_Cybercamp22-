using System;
using System.IO;
using System.Security.Cryptography;

namespace Osb.Core.Platform.Common.Util.Security
{
    public class AesProvider
    {
        private static int aesKeySize = 256;
        private static int aesBlockSize = 128;

        public static string Encrypt(string plainValue, string salt, string secret, string IV)
        {
            using var aes = InitializeAes(salt, secret, IV);
            ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] encrypted;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainValue + salt);
                    };
                };
                encrypted = memoryStream.ToArray();
            };

            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string value, string salt, string secret, string IV)
        {
            using var aes = InitializeAes(salt, secret, IV);
            ICryptoTransform decryptor = aes.CreateDecryptor();
            string decryptedValue;

            using (var memoryStream = new MemoryStream(Convert.FromBase64String(value)))
            {
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (var streamReader = new StreamReader(cryptoStream))
                    {
                        decryptedValue = streamReader.ReadToEnd();
                    };
                };
            };

            return decryptedValue.Substring(0, decryptedValue.Length - salt.Length);
        }

        public static bool Compare(string plainValue, string encryptedValue, string salt, string secret, string IV)
        {
            using var aesProvider = InitializeAes(salt, secret, IV);
            return Encrypt(plainValue, salt, secret, IV).Equals(encryptedValue);
        }

        private static Aes InitializeAes(string salt, string secret, string IV)
        {
            var aes = Aes.Create();
            aes.BlockSize = aesBlockSize;
            aes.KeySize = aesKeySize;
            aes.Key = System.Text.Encoding.UTF8.GetBytes(secret);
            aes.IV = System.Text.Encoding.UTF8.GetBytes(IV);
            return aes;
        }
    }
}