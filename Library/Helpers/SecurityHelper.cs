using System.Security.Cryptography;
using System.Text;

namespace Library.Helpers
{
    public class SecurityHelper
    {
        public static string GenerateSaltedHash(string password, string salt)
        {
            var passwordBytes=Encoding.Unicode.GetBytes(password);
            var saltBytes=Encoding.Unicode.GetBytes(salt.ToUpper());
            var algoritm=SHA256.Create();

            var passwordWitgSaltBytes=new byte[passwordBytes.Length+saltBytes.Length];
            passwordBytes.CopyTo(passwordWitgSaltBytes, 0);
            saltBytes.CopyTo(passwordWitgSaltBytes,passwordBytes.Length);
            return Convert.ToBase64String(algoritm.ComputeHash(passwordBytes));
        }

        public static bool PasswordMatch(string password, string salt, string hash)
        {
            return hash==GenerateSaltedHash(password, salt);
        }
    }
}
