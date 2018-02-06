using BusinessManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Services
{
    public class LoginService
    {
        private LoginRepository loginRepository;

        public LoginService(LoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public bool IsAuthorized(string username, string password)
        {
            return username != null &&
                loginRepository.UserExists(username) &&
                loginRepository.CorrectPassword(username, UserService.GetHash(loginRepository.GetSalt(username), password));
        }

        public int GetUserId(string username)
        {
            return loginRepository.GetUserId(username);
        }
    }
}
