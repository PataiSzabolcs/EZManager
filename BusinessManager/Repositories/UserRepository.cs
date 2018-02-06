using BusinessManager.Entities;
using BusinessManager.Models;
using BusinessManager.Models.JointModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Repositories
{
    public class UserRepository
    {
        private BusinessContext businessContext;

        public UserRepository(BusinessContext businessContext)
        {
            this.businessContext = businessContext;
        }

        public void AddUser(string username, string password, string salt)
        {
            businessContext.Users.Add(new User
            {
                Username = username,
                Password = password,
                Salt = salt,
                AdministeredClients = new List<ClientAdmin>(),
                Billables = new List<Billable>(),
                Events = new List<Event>(),
                Entries = new List<Entry>()
            });
            businessContext.SaveChanges();
        }

        public void AddClient(string name, int clientAdminId)
        {
            businessContext.Users.Load();
            businessContext.Clients.Add(new Client
            {
                Name = name,
                ClientAdmins = new List<ClientAdmin>()
                {
                    new ClientAdmin() { Admin = GetUser(clientAdminId) }
                },
                Cases = new List<Case>(),
                BillingInfo = new BillingInfo(),
                ContactPeople = new List<ContactPerson>()
            });
            businessContext.SaveChanges();
        }

        public List<Entry> GetAllEntries()
        {
            return businessContext.Entries.ToList();
        }

        public List<Client> GetClients(int userId)
        {
            businessContext.ClientAdmins.Load();
            return businessContext.Clients.Where(c => c.ClientAdmins.Any(a => a.UserId == userId)).ToList();
        }

        public void StartTimer(int caseId, int userId, string narrative)
        {
            Case curentcase = businessContext.Cases.FirstOrDefault(c => c.Id == caseId);
            User feeEarner = businessContext.Users.FirstOrDefault(u => u.Id == userId);
            Billable billable = businessContext.Billables.FirstOrDefault(b => b.CaseId == curentcase.Id && b.FeeEarner.Id == feeEarner.Id);

            if (curentcase.Entries == null)
            {
                curentcase.Entries = new List<Entry>();
            }

            if (feeEarner.Entries == null)
            {
                feeEarner.Entries = new List<Entry>();
            }

            if (billable.Entries == null)
            {
                billable.Entries = new List<Entry>();
            }

            Entry entry = new Entry()
            {
                Case = businessContext.Cases.FirstOrDefault(c => c.Id == caseId),
                FeeEarner = businessContext.Users.FirstOrDefault(u => u.Id == userId),
                Narrative = narrative, WorkStarted = DateTime.Now,
                Ongoing = true
            };
            billable.Entries.Add(entry);
            curentcase.Entries.Add(entry);
            feeEarner.Entries.Add(entry);
            businessContext.SaveChanges();
        }

        public void StopTimer(int caseId, int userId, string narrative)
        {
            Billable billable = businessContext.Billables.Where(b => b.CaseId == caseId).FirstOrDefault(c => c.FeeEarner.Id == userId);
            Entry entry = businessContext.Entries.Where(b => b.FeeEarner.Id == userId && b.Case.Id == caseId).FirstOrDefault(e => e.Ongoing);
            entry.WorkEnded = DateTime.Now;
            entry.Ongoing = false;
            var workedHours = entry.WorkEnded.Subtract(entry.WorkStarted).TotalHours;
            if (workedHours > 100000.00)
            {
                return;
            }
            billable.Hours += workedHours;
            entry.Hours += workedHours;
            entry.Narrative = narrative;
            businessContext.SaveChanges();
        }

        public List<Case> GetCases(int userId)
        {
            businessContext.CaseAdmins.Load();
            businessContext.Billables.Load();
            businessContext.Entries.Load();
            return businessContext.Cases
                .Where(c => c.CaseAdmins
                .Any(a => a.UserId == userId)
                || c.Billables
                .Any(b => b.FeeEarner.Id == userId))
                .ToList();
        }

        internal void AddDocument(string title, string path, int caseId)
        {
            businessContext.Documents.Add(new Document
            {
                Title = title,
                Path = path,
                Case = GetCase(caseId),
                Events = new List<DocumentEvent>()
            });
            businessContext.SaveChanges();
        }

        public void AddEvent(int caseId, string title, DateTime date)
        {
            businessContext.Events.Add(new Event
            {
                Case = GetCase(caseId),
                Title = title,
                Date = date,
                Participants = new List<UserEvent>(),
                Documents = new List<DocumentEvent>()
            });
            businessContext.SaveChanges();
        }

        public void AddCase(int clientId, string title, int caseAdminId)
        {
            businessContext.Users.Load();
            businessContext.Clients.Load();
            businessContext.Cases.Add(new Case
            {
                Client = GetClient(clientId),
                Title = title,
                CaseAdmins = new List<CaseAdmin>()
                {
                    new CaseAdmin() { Admin = GetUser(caseAdminId) }
                },
                Billables = new List<Billable>(),
                Documents = new List<Document>(),
                Events = new List<Event>(),
                Entries = new List<Entry>()
            });
            businessContext.SaveChanges();
        }
        
        public void AddFeeEarner(int caseId, int feeEarnerId, double rate)
        {
            businessContext.Users.Load();
            businessContext.Cases.Load();
            businessContext.Billables.Add(new Billable
            {
                Case = GetCase(caseId),
                FeeEarner = GetUser(feeEarnerId),
                HourlyRate = rate,
                Entries = new List<Entry>()
            });
            businessContext.SaveChanges();
        }

        public User GetUser(int userId)
        {
            businessContext.ClientAdmins.Where(a => a.UserId == userId);
            businessContext.CaseAdmins.Where(a => a.UserId == userId);
            businessContext.Billables.Where(a => a.UserId == userId);
            businessContext.UserEvents.Where(a => a.UserId == userId);
            return businessContext.Users.FirstOrDefault(u => u.Id == userId);
        }

        private Client GetClient(int id)
        {
            return businessContext.Clients.FirstOrDefault(c => c.Id == id);
        }

        private Case GetCase(int id)
        {
            return businessContext.Cases.FirstOrDefault(c => c.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return businessContext.Users.ToList();
        }

        public List<Client> GetAllClients()
        {
            return businessContext.Clients.ToList();
        }

        public List<ClientAdmin>GetAllClientAdmins()
        {
            return businessContext.ClientAdmins.ToList();
        }

        public List<Case> GetAllCases()
        {
            return businessContext.Cases.ToList();
        }

        public List<CaseAdmin> GetAllCaseAdmins()
        {
            return businessContext.CaseAdmins.ToList();
        }

        public List<Billable> GetAllBillables()
        {
            return businessContext.Billables.ToList();
        }
    }
}
