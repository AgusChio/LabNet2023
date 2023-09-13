using System.Security.Cryptography;
using System.Text;


namespace Practica3.Logic
{
    public class MarvelApiHelper
    {
        public static string GenerateHash(string timestamp, string privateKey, string publicKey)
        {
            
            string input = timestamp + privateKey + publicKey;

            
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

                
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
