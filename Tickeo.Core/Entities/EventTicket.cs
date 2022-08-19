using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.Entities
{
    public class EventTicket : BaseClass
    {
        //  public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal Amount { get; set; }

    }
}
