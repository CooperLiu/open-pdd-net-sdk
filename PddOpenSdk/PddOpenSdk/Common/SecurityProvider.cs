using System;
using System.Security.Cryptography;
using System.Text;

namespace PddOpenSdk.Common
{
    static class SecurityProvider
    {

        public static string Md5(this string plainText, string charset = "utf-8")
        {
            var sb = new StringBuilder(32);
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] t = md5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(plainText));
                for (int i = 0; i < t.Length; i++)
                {
                    sb.Append(t[i].ToString("x").PadLeft(2, '0'));
                }

                return sb.ToString();
            }
            
        }

        public static string Base64Encode(this string plainText, string charset = "utf-8")
        {
            try
            {
                var bytes = Encoding.GetEncoding(charset).GetBytes(plainText);
                return Convert.ToBase64String(bytes);

            }
            catch
            {
                return plainText;
            }
        }

        public static string Base64Decode(string plainText, string charset = "utf-8")
        {
            try
            {
                var bytes = Convert.FromBase64String(plainText);

                return Encoding.GetEncoding(charset).GetString(bytes);
            }
            catch
            {
                return plainText;
            }
        }
    }
}