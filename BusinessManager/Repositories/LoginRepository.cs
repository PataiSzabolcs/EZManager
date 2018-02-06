using BusinessManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Repositories
{
    public class LoginRepository
    {
        private BusinessContext businessContext;

        public LoginRepository(BusinessContext businessContext)
        {
            this.businessContext = businessContext;
        }

        public bool UserExists(string username)
        {
            return businessContext.Users.Any(u => u.Username.Equals(username));
        }

        public bool CorrectPassword(string username, string password)
        {
            return businessContext.Users.FirstOrDefault(u => u.Username.Equals(username)).Password.Equals(password);
        }

        public int GetUserId(string username)
        {
            return businessContext.Users.FirstOrDefault(u => u.Username.Equals(username)).Id;
        }

        public string GetSalt(string username)
        {
            return businessContext.Users.FirstOrDefault(u => u.Username.Equals(username)).Salt;
        }
    }
}
