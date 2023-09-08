using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string SiteUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        

        public void SetPassword(string password)
        {
            // Parolayı güvenli bir şekilde şifrele
            Password = EncryptPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            // Kullanıcının girdiği parolayı şifreleyin ve saklanan parola ile karşılaştırın
            string inputPasswordHash = EncryptPassword(password);
            return Password == inputPasswordHash;
        }

        private string EncryptPassword(string password)
        {
            // Parolayı güvenli bir şekilde şifreleyin (örneğin, SHA256 kullanabilirsiniz)
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }

}


