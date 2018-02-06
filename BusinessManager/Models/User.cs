using BusinessManager.Models.JointModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public IList<ClientAdmin> AdministeredClients { get; set; }
        public IList<CaseAdmin> AdministeredCases { get; set; }
        public IList<Billable> Billables { get; set; }
        public IList<Event> Events { get; set; }
        public IList<Entry> Entries { get; set; }
    }
}
