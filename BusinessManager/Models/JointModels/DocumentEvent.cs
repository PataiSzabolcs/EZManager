using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Models.JointModels
{
    public class DocumentEvent
    {
        public int DocumentId { get; set; }
        public int EventId { get; set; }
        public Document Document { get; set; }
        public Event Event { get; set; }
    }
}
