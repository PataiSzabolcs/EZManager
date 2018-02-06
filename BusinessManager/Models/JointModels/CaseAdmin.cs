using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Models.JointModels
{
    public class CaseAdmin
    {
        public int CaseId { get; set; }
        public int UserId { get; set; }
        public Case Case { get; set; }
        public User Admin { get; set; }
    }
}
