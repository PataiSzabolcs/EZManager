using BusinessManager.Models;
using BusinessManager.Repositories;
using BusinessManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Services
{
    public class UserService
    {
        private UserRepository userRepository;
        private User user;  

        public UserService(UserRepository userRepository, User user)
        {
            this.userRepository = userRepository;
            this.user = user;
        }

        public void AddUser(string username, string password)
        {
            string salt = GenerateSalt();
            userRepository.AddUser(username, GetHash(salt, password), salt);
        }

        public void AddClient(string name, int clientAdminId)
        {
            userRepository.AddClient(name, clientAdminId);
        }

        public void SetUser(int userId)
        {
            user.Username = userRepository.GetUser(userId).Username;
            user.Id = userRepository.GetUser(userId).Id;
            user.AdministeredCases = userRepository.GetUser(userId).AdministeredCases;
            user.AdministeredClients = userRepository.GetUser(userId).AdministeredClients;
            user.Billables = userRepository.GetUser(userId).Billables;
            user.Events = userRepository.GetUser(userId).Events;
        }

        public List<Client> GetClients()
        {
            return userRepository.GetClients(user.Id);
        }

        public void GetAllEntries()
        {
            userRepository.GetAllEntries();
        }

        public UserCasesViewModel GetCases()
        {
            return new UserCasesViewModel() { User = user, Cases = userRepository.GetCases(user.Id) };
        }

        public void StartTimer(int caseId, int userId, string narrative)
        {
            userRepository.StartTimer(caseId, userId, narrative);
        }

        public User GetUser()
        {
            return user;
        }

        public void StopTimer(int caseId, int userId, string narrative)
        {
            userRepository.StopTimer(caseId, userId, narrative);
        }

        public User GetUser(int userId)
        {
            return userRepository.GetUser(userId);
        }

        public void GetAllClientAdmins()
        {
            userRepository.GetAllClientAdmins();
        }

        public void GetAllCaseAdmins()
        {
            userRepository.GetAllCaseAdmins();
        }

        public void GetAllBillables()
        {
            userRepository.GetAllBillables();
        }

        public void AddCase(int clientId, string title, int caseAdminId)
        {
            userRepository.AddCase(clientId, title, caseAdminId);
        }

        public void AddFeeEarner(int caseId, int feeEarnerId, double rate)
        {
            userRepository.AddFeeEarner(caseId, feeEarnerId, rate);
        }

        public void AddEvent(int caseId, string title, DateTime date)
        {
            userRepository.AddEvent(caseId, title, date);
        }

        public void AddDocument(string title, string path, int caseId)
        {
            userRepository.AddDocument(title, path, caseId);
        }

        public List<Client> GetAllClients()
        {
            return userRepository.GetAllClients();
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public UserClientViewModel GetAllClientsAndUsers()
        {
            UserClientViewModel allClientAndUsers = new UserClientViewModel()
            {
                Clients = GetAllClients(),
                Users = GetAllUsers()
            };

            return allClientAndUsers;
        }

        public CaseUserViewModel GetAllCaseAndUsers()
        {
            CaseUserViewModel allCasesAndUsers = new CaseUserViewModel()
            {
                Cases = GetAllCases(),
                Users = GetAllUsers()
            };

            return allCasesAndUsers;
        }

        public List<Case> GetAllCases()
        {
            return userRepository.GetAllCases();
        }
        
        public string GenerateSalt()
        {
            Random random = new Random();
            int char1 = random.Next(48, 127);
            int char2 = random.Next(48, 127);

            char[] chars = new char[] { (char)char1, (char)char2 };
            string salt = new string(chars);

            return salt;
        }

        public static string GetHash(string salt, string text)
        {
            string salted = string.Concat(salt, text);
            char[] chars = salted.ToArray();
            int[] digits = new int[chars.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                digits[i] = chars[i];
            }
            double number = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                number = number + digits[i] * Math.Pow(10, (digits.Length - i - 1));
            }
            if (digits.Length > 9)
            {
                number = Math.Sqrt(number);
            }
            number = Math.Pow(number, 3);
            long numberLong = (long)number;
            List<long> listOfDigits = new List<long>();
            while (numberLong > 0)
            {
                listOfDigits.Add(numberLong % 10);
                numberLong = numberLong / 10;
            }
            listOfDigits.Reverse();
            long[] longArray = listOfDigits.ToArray();
            List<int> intList = new List<int>();
            for (int i = 0; i < (longArray.Length - 3) / 2; i++)
            {
                intList.Add((int)longArray[i * 2] + (int)longArray[i * 2 + 1]);
            }
            char[] finalChars = new char[intList.Count];
            for (int i = 0; i < intList.Count; i++)
            {
                intList[i] = (int)((intList[i] * 3.23) + 61);
                finalChars[i] = (char)intList[i];
            }
            string hashedString = new string(finalChars);
            return hashedString;
        }
    }
}
