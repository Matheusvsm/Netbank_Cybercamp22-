using System.IO;

namespace Osb.Core.Platform.Auth.Util
{
    public class TokenFileManagement
    {
        public void SaveTokenFile(string value, string filePath)
        {
            Directory.CreateDirectory(filePath);
            string fullPath = $"{filePath}{"TokenFile"}".ToLower();
            File.WriteAllText(fullPath + ".txt", value);
        }

    }
}