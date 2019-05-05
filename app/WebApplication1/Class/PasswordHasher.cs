using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApplication1.Class
{
    public static class PasswordHasher
    {
        public static string hashPassword(string password)
        {
            var hash = string.Empty;
            var crypto = new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));

            return crypto.Aggregate(hash, (current, theByte) => current + theByte.ToString("x2"));
        }
    }
}