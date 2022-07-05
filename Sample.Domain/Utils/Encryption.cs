using System.Security.Cryptography;
using System.Text;

namespace Sample.Domain.Utils
{
    public class Encryption
    {
        public static string Encrypt(string password)
        {
            SHA256 sha = SHA256.Create();
            ASCIIEncoding encoding = new();
            StringBuilder StringB = new();

            byte[] strem = sha.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < strem.Length; i++) StringB.AppendFormat("{0:x2}", strem[i]);

            return StringB.ToString();
        }
    }
}
