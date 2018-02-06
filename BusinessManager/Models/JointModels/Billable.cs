using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Models.JointModels
{
    public class Billable
    {
        public int CaseId { get; set; }
        public int UserId { get; set; }
        public Case Case { get; set; }
        public User FeeEarner { get; set; }
        public double HourlyRate { get; set; }
        public double Hours { get; set; }
        public DateTime WorkStarted { get; set; }
        public IList<Entry> Entries { get; set; }
    }
}
