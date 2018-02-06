using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Models.JointModels
{
    public class UserDocument
    {
        public int UserId { get; set; }
        public int DocumentId { get; set; }
        public User User { get; set; }
        public Document Document { get; set; }
    }
}
