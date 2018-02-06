using BusinessManager.Models.JointModels;
using System;
using System.Collections.Generic;

namespace BusinessManager.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public IList<UserEvent> Participants { get; set; }
        public Case Case { get; set; }
        public string Description { get; set; }
        public IList<DocumentEvent> Documents { get; set; }
    }
}