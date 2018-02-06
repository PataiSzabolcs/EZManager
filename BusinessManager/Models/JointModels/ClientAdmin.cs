using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Models.JointModels
{
    public class ClientAdmin
    {
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public User Admin { get; set; }
        public Client Client { get; set; }
    }
}
