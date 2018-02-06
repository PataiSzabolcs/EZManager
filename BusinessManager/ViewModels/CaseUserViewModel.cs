using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.ViewModels
{
    public class CaseUserViewModel
    {
        public List<Case> Cases { get; set; }
        public List<User> Users { get; set; }
    }
}
