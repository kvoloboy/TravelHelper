using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.UserManagement
{
    public static class PasswordHasher
    {
        public static byte[] CreateHash(string password)
        {
            var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));

            return hash;
        }
    }
}
