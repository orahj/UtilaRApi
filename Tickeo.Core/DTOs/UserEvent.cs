using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
    public class UserEvent
    {
        public Guid EventID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
