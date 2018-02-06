using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.ViewModels
{
    public class UserClientViewModel
    {
        public List<Client> Clients { get; set; }
        public List<User> Users { get; set; }
    }
}
