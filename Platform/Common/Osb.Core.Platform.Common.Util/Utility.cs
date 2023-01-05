using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Osb.Core.Platform.Common.Util
{
    public class Utility
    {
        public static string StringToBase64(string baseString)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(baseString);
            return Convert.ToBase64String(byteArray);
        }

        public static string Base64ToString(string baseString)
        {
            byte[] encodedTextBytes = Convert.FromBase64String(baseString);
            string decodedText = Encoding.UTF8.GetString(encodedTextBytes);
            return decodedText;
        }

        public static string ConvertStringToBase64File(string baseString)
        {
            string imageBase64 = string.Empty;

            using (WebClient client = new WebClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                    | SecurityProtocolType.Tls11
                    | SecurityProtocolType.Tls12;

                var bytes = client.DownloadData(baseString);
                string base64String = Convert.ToBase64String(bytes);
                imageBase64 = base64String;
            }

            return imageBase64;
        }

        public static string CreatePassword()
        {
            Random random = new Random();
            String b = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#";
            String pass = "";
            for (int i = 0; i < 8; i++)
            {
                int a = random.Next(b.Length);
                pass += b[a];
            }
            return pass;
        }

        public static DateTime AbsoluteEnd(DateTime date)
        {
            return date.AddHours(date.Hour * -1).AddMinutes(date.Minute * -1).AddSeconds(date.Second * -1).AddDays(1).AddSeconds(-1);
        }

        public static string MaskEmail(string email)
        {
            string result = "";
            if (!string.IsNullOrEmpty(email))
            {

                string pattern = @"(?<=[\w]{2})[\w-\._\+%\\]*(?=[\w]{1}@)|(?<=@[\w]{2})[\w-_\+%]*(?=\.)";

                result = Regex.Replace(email, pattern, m => new string('*', m.Length));

            }

            return result;
        }

        public static string MaskPhone(string phone)
        {
            string result = "";
            if (!string.IsNullOrEmpty(phone))
            {
                result = Regex.Replace(phone, @"(\d{2})(\d{5})(\d{4})", "($1) $2.$3");
                result = Regex.Replace(result, "[0-9]{3}", m => new string('*', m.Length));

            }

            return result;
        }
    }
}