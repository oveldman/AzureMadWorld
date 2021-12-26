using System;
using System.IO;
using System.Text;

namespace MadWorld.Shared.Helper
{
    /// <summary>
    /// This class helps you with simple converters like Base64 and more soon.
    /// </summary>
    public static class SimpleConverter
    {
        /// <summary>
        /// From plaintext to base64.
        /// </summary>
        public static string ConvertToBase64(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return string.Empty;

            byte[] body = Encoding.ASCII.GetBytes(plainText);
            return Convert.ToBase64String(body);
        }

        /// <summary>
        /// From base64 to plaintext.
        /// </summary>
        public static string ConvertToString(string base64Text)
        {
            if (string.IsNullOrEmpty(base64Text)) return string.Empty;

            byte[] body = Convert.FromBase64String(base64Text);
            return Encoding.ASCII.GetString(body);
        }

        public static string ConvertToBase64(Stream stream)
        {
            byte[] body;

            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                body = ms.ToArray();
            }

            return System.Text.Encoding.UTF8.GetString(body);
        }
    }
}


