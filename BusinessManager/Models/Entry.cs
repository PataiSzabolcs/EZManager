using BusinessManager.Models.JointModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public double Hours { get; set; }
        public string Narrative { get; set; }
        public Case Case { get; set; }
        public User FeeEarner { get; set; }
        public Billable Billable { get; set; }
        public DateTime WorkStarted { get; set; }
        public DateTime WorkEnded { get; set; }
        public bool Ongoing { get; set; }
    }
}
