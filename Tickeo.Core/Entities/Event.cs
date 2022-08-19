using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.Entities
{
    public class Event :BaseClass
    {
        public string Name { get; set; }
        public string AddressStreet { get; set; }
        public string AddressState { get; set; }
        public string AddressCountry { get; set; }
        public string AddressLatitude { get; set; }
        public string AddressLongitude { get; set; }
        public string Creator { get; set; }
        public string Category { get; set; }
        public string Thumbnail { get; set; }
        public string FullImage { get; set; }
        public string Status { get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Timezone { get; set; }
        public string EventType { get; set; }
        public  List<EventTicket> ListOfTickets { get; set; }
        public string Likes { get; set; }
        public bool IsDeleted { get; set; }
      //  public virtual ICollection<EventTicket> ListOfTickets { get; set; }

    }
}
