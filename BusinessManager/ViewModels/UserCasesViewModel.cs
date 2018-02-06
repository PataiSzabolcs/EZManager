using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.ViewModels
{
    public class UserCasesViewModel
    {
        public User User { get; set; }
        public List<Case> Cases { get; set; }
    }
}
