using BusinessManager.Models.JointModels;
using System.Collections.Generic;

namespace BusinessManager.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Case> Cases { get; set; }
        public IList<ClientAdmin> ClientAdmins { get; set; }
        public BillingInfo BillingInfo { get; set; }
        public IList<ContactPerson> ContactPeople { get; set; }
        public int GeneralPhone { get; set; }
        public string GeneralEmail { get; set; }
        public string Address { get; set; }
    }
}